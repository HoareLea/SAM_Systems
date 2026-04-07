// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Analytical.Systems;
using SAM.Core;
using SAM.Core.Grasshopper;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class SAMAnalyticalSystemEnergyCentreModifyByAirflows : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("31a4c1d3-6cef-4c5b-a9b1-46684c947ea9");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.0";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM_Small;

        /// <summary>
        /// Initializes a new instance of the SAM_point3D class.
        /// </summary>
        public SAMAnalyticalSystemEnergyCentreModifyByAirflows()
          : base("SystemEnergyCentre.ModifyByAirflows", "SystemEnergyCentre.ModifyByAirflows",
              "Modify SystemEnergyCentre By Airflows",
              "SAM", "Systems")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override GH_SAMParam[] Inputs
        {
            get
            {
                Param_Boolean param_Boolean = new()
                {
                    Name = "_run",
                    NickName = "_run",
                    Description = "Set to true to run the update. If false, the component does nothing.",
                    Access = GH_ParamAccess.item
                };
                param_Boolean.SetPersistentData(false);

                List<GH_SAMParam> result =
                [
                    new GH_SAMParam(new GooAnalyticalModelParam() 
                    { 
                        Name = "_analyticalModel", 
                        NickName = "_analyticalModel", 
                        Description = "SAM AnalyticalModel", 
                        Access = GH_ParamAccess.item 
                    }, ParamVisibility.Binding),
                    
                    new GH_SAMParam(new GooSystemEnergyCentreParam() 
                    { 
                        Name = "systemEnergyCentre_", 
                        NickName = "systemEnergyCentre_", 
                        Description = "SAM SystemEnergyCentre", 
                        Access = GH_ParamAccess.item, 
                        Optional = true 
                    }, ParamVisibility.Voluntary),
                    
                    new GH_SAMParam(new Param_String() 
                    { 
                        Name = "spaceNames_", 
                        NickName = "spaceNames_", 
                        Description = "Space names", 
                        Access = GH_ParamAccess.list,
                        Optional = true
                    }, ParamVisibility.Binding),

                    new GH_SAMParam(new Param_Number()
                    {
                        Name = "_airflowFlowRates",
                        NickName = "_airflowFlowRates",
                        Description = "Airflow flow rates for the listed spaces [l/s]. Used when _airflowModifies = 1.",
                        Access = GH_ParamAccess.list,
                        Optional = true
                    }, ParamVisibility.Binding),

                    new GH_SAMParam(new Param_Number()
                    {
                        Name = "_airflowModifies",
                        NickName = "_airflowModifies",
                        Description = "Airflow update mode for each space: 0 = do not change, 1 = set value, 2 = reset.\nDefault is 0.",
                        Access = GH_ParamAccess.list,
                        Optional = true
                    }, ParamVisibility.Binding),

                    new GH_SAMParam(new Param_Number()
                    {
                        Name = "_airflowFreshAirRates",
                        NickName = "_airflowFreshAirRates",
                        Description = "Fresh air flow rates for the listed spaces [l/s]. Used when _airflowFreshAirModifies = 1.",
                        Access = GH_ParamAccess.list,
                        Optional = true
                    }, ParamVisibility.Binding),

                    new GH_SAMParam(new Param_Number()
                    {
                        Name = "_airflowFreshAirModifies",
                        NickName = "_airflowFreshAirModifies",
                        Description = "Fresh air update mode for each space: 0 = do not change, 1 = set value, 2 = reset.\nDefault is 0.",
                        Access = GH_ParamAccess.list,
                        Optional = true
                    }, ParamVisibility.Binding),

                    new GH_SAMParam(param_Boolean)

                ];

                return [.. result];
            }
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override GH_SAMParam[] Outputs
        {
            get
            {
                return
                [
                    new GH_SAMParam(new GooAnalyticalModelParam()
                    {
                        Name = "AnalyticalModel",
                        NickName = "AnalyticalModel",
                        Description = "SAM AnalyticalModel",
                        Access = GH_ParamAccess.item
                    }, ParamVisibility.Binding),

                    new GH_SAMParam(new GooSystemEnergyCentreParam()
                    {
                        Name = "SystemEnergyCentre",
                        NickName = "SystemEnergyCentre",
                        Description = "SystemEnergyCentre",
                        Access = GH_ParamAccess.item
                    }, ParamVisibility.Binding),

                    new GH_SAMParam(new Param_String()
                    {
                        Name = "SpaceNames",
                        NickName = "SpaceNames",
                        Description = "Names of the spaces that were successfully updated.",
                        Access = GH_ParamAccess.list
                    }, ParamVisibility.Binding),

                    new GH_SAMParam(new Param_Boolean()
                    {
                        Name = "Successful",
                        NickName = "Successful",
                        Description = "True if one or more spaces were successfully updated; otherwise false.",
                        Access = GH_ParamAccess.item
                    }, ParamVisibility.Binding)
                ];
            }
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="dataAccess">
        /// The DA object is used to retrieve from inputs and store in outputs.
        /// </param>
        protected override void SolveInstance(IGH_DataAccess dataAccess)
        {
            int index;

            index = Params.IndexOfInputParam("_analyticalModel");
            AnalyticalModel analyticalModel = null;
            if (!dataAccess.GetData(index, ref analyticalModel) || analyticalModel == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("systemEnergyCentre_");
            SystemEnergyCentre systemEnergyCentre = null;
            if(index != -1)
            {
                dataAccess.GetData(index, ref systemEnergyCentre);
            }

            if(systemEnergyCentre is null)
            {
                systemEnergyCentre = analyticalModel.GetValue<SystemEnergyCentre>(Analytical.Systems.AnalyticalModelParameter.SystemEnergyCentre);
            }

            if(systemEnergyCentre is null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            List<string> spacesNames = [];
            index = Params.IndexOfInputParam("spaceNames_");
            if (index == -1 || !dataAccess.GetDataList(index, spacesNames) || spacesNames is null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            List<double> airflows = [];
            index = Params.IndexOfInputParam("_airflowFlowRates");
            if (index != -1)
            {
                if (!dataAccess.GetDataList(index, airflows) || airflows is null)
                {
                    airflows = [];
                }
            }

            List<double> freshAirs = [];
            index = Params.IndexOfInputParam("_airflowFreshAirRates");
            if (index != -1)
            {
                if (!dataAccess.GetDataList(index, freshAirs) || freshAirs is null)
                {
                    freshAirs = [];
                }
            }

            List<double> airflows_Code = [];
            index = Params.IndexOfInputParam("_airflowModifies");
            if (index != -1)
            {
                if (!dataAccess.GetDataList(index, airflows_Code) || airflows_Code is null)
                {
                    airflows_Code = [];
                }
            }

            List<double> freshAirs_Code = [];
            index = Params.IndexOfInputParam("_airflowFreshAirModifies");
            if (index != -1)
            {
                if (!dataAccess.GetDataList(index, freshAirs_Code) || freshAirs_Code is null)
                {
                    freshAirs_Code = [];
                }
            }

            List<string> spaceNames_Updated = [];

            if (!((airflows is null || airflows.Count == 0) && (freshAirs is null || freshAirs.Count == 0)))
            {
                Dictionary<string, Tuple<double?, double?>> dictionary = [];
                for (int i = 0; i < spacesNames.Count; i++)
                {
                    string name = spacesNames[i];
                    if (name == null)
                    {
                        continue;
                    }

                    int code;

                    //Air Flow
                    code = 0;
                    if (airflows_Code.Count != 0)
                    {
                        code = System.Convert.ToInt32(airflows_Code[Core.Query.Clamp(i, 0, airflows_Code.Count - 1)]);
                    }

                    double? airflow = null;
                    if (code == 1 && airflows.Count != 0)
                    {
                        airflow = airflows[Core.Query.Clamp(i, 0, airflows.Count - 1)];
                    }
                    else if (code == 2)
                    {
                        airflow = double.NaN;
                    }

                    //Fresh Air
                    code = 0;
                    if (freshAirs_Code.Count != 0)
                    {
                        code = System.Convert.ToInt32(freshAirs_Code[Core.Query.Clamp(i, 0, freshAirs_Code.Count - 1)]);
                    }

                    double? freshAir = null;
                    if (code == 1 && freshAirs.Count != 0)
                    {
                        freshAir = freshAirs[Core.Query.Clamp(i, 0, freshAirs.Count - 1)];
                    }
                    else if (code == 2)
                    {
                        freshAir = double.NaN;
                    }

                    dictionary[spacesNames[i]] = new Tuple<double?, double?>(airflow, freshAir);
                }

                spaceNames_Updated = Analytical.Systems.Modify.UpdateSpaceAirflows(systemEnergyCentre, dictionary);
            }

            if(spaceNames_Updated != null && spaceNames_Updated.Count != 0)
            {
                analyticalModel.SetValue(Analytical.Systems.AnalyticalModelParameter.SystemEnergyCentre, systemEnergyCentre);
            }

            index = Params.IndexOfOutputParam("AnalyticalModel");
            if (index != -1)
            {
                dataAccess.SetData(index, analyticalModel);
            }

            index = Params.IndexOfOutputParam("SystemEnergyCentre");
            if (index != -1)
            {
                dataAccess.SetData(index, systemEnergyCentre);
            }

            index = Params.IndexOfOutputParam("SpaceNames");
            if (index != -1)
            {
                dataAccess.SetDataList(index, spaceNames_Updated);
            }

            index = Params.IndexOfOutputParam("Successful");
            if (index != -1)
            {
                dataAccess.SetData(index, spaceNames_Updated != null && spaceNames_Updated.Count != 0);
            }
        }
    }
}