// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using Grasshopper.Kernel;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Core.Grasshopper;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class SAMAnalyticalSystemCreateSystemEnergyCentre : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("980a8d42-ad72-49fa-b6fc-1ad98fa234bc");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.1";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM_Small;

        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Initializes a new instance of the SAM_point3D class.
        /// </summary>
        public SAMAnalyticalSystemCreateSystemEnergyCentre()
          : base(
                  "SAMAnalytical.CreateSystemEnergyCentre",
                  "SAMAnalytical.CreateSystemEnergyCentre",
                  "Creates a SystemEnergyCentre.\n" +
                  "\n" +
                  "Each SystemEnergyCentre represents an air system together with its associated plantroom.\n" +
                  "\n" +
                  "Legacy workflow:\n" +
                  "• System definitions are taken from MechanicalSystemTypes.\n" +
                  "\n" +
                  "Library workflow:\n" +
                  "• System definitions are loaded from the local JSON library:\n" +
                  "  %AppData%\\SAM\\resources\\Analytical\\Systems\\SystemEnergyCentre\n" +
                  "• Each JSON entry is stored as a complete energy centre (air system + plantroom).\n" +
                  "\n" +
                  "If multiple energy centres are created with the same name,\n" +
                  "duplicate names are automatically renamed by appending 1, 2, 3, etc.\n" +
                  "\n" +
                  "To run a simulation, connect the created SystemEnergyCentre to\n" +
                  "the SAMSystems.CreateTPDByTSDAndSystemEnergyCentre component.",
                  "SAM",
                  "Systems")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override GH_SAMParam[] Inputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new GooAnalyticalModelParam() { Name = "_analyticalModel", NickName = "_analyticalModel", Description = "SAM AnalyticalModel", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                return result.ToArray();
            }
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override GH_SAMParam[] Outputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new GooAnalyticalModelParam() { Name = "analyticalModel", NickName = "analyticalModel", Description = "SAM AnalyticalModel", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooSystemEnergyCentreParam() { Name = "systemEnergyCentre", NickName = "systemEnergyCentre", Description = "SAM SystemEnergyCentre \n to simulate connect the SAMSystems.CreateTPDByTSDAndSystemEnergyCentre component.", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                return result.ToArray();
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
            int index = -1;

            AnalyticalModel analyticalModel = null;
            index = Params.IndexOfInputParam("_analyticalModel");
            if (index == -1 || !dataAccess.GetData(index, ref analyticalModel) || analyticalModel == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            analyticalModel = new AnalyticalModel(analyticalModel);

            SystemEnergyCentre systemEnergyCentre = Analytical.Systems.Create.SystemEnergyCentre(analyticalModel, out HashSet<string> unavailableSystemTypeNames);
            if (unavailableSystemTypeNames != null && unavailableSystemTypeNames.Count != 0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Warning, string.Format("Following system types not defined: {0}", string.Join(", ", unavailableSystemTypeNames)));
            }

            if (systemEnergyCentre != null)
            {
                analyticalModel.SetValue(Analytical.Systems.AnalyticalModelParameter.SystemEnergyCentre, systemEnergyCentre);
            }

            index = Params.IndexOfOutputParam("analyticalModel");
            if (index != -1)
            {
                dataAccess.SetData(index, analyticalModel);
            }

            index = Params.IndexOfOutputParam("systemEnergyCentre");
            if (index != -1)
            {
                dataAccess.SetData(index, systemEnergyCentre);
            }
        }
    }
}