using Grasshopper.Kernel;
using SAM.Analytical.Grasshopper.Properties;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Analytical.Systems;
using SAM.Core;
using SAM.Core.Grasshopper;
using SAM.Core.Grasshopper.Systems;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class SAMAnalyticalSystemModifyAirSystem : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("6f57c6d7-8669-45a0-8af6-9595572921c2");

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
        public SAMAnalyticalSystemModifyAirSystem()
          : base("SAMAnalytical.ModifyAirSystem", "SAMAnalytical.ModifyAirSystem",
              "Modify VentilationSystem",
              "SAM", "Analytical")
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
                result.Add(new GH_SAMParam(new GooSpaceParam() { Name = "_spaces", NickName = "_spaces", Description = "SAM Analytical Spaces", Access = GH_ParamAccess.list }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooSystemEnergyCentreParam() { Name = "systemEnergyCentre_", NickName = "systemEnergyCentre_", Description = "SAM SystemEnergyCentre", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Voluntary));
                result.Add(new GH_SAMParam(new GooSystemObjectParam() { Name = "_airSystem", NickName = "_airSystem", Description = "SAM AirSystem", Access = GH_ParamAccess.item, Optional = false }, ParamVisibility.Binding));

                global::Grasshopper.Kernel.Parameters.Param_Boolean param_Boolean;

                param_Boolean = new global::Grasshopper.Kernel.Parameters.Param_Boolean() { Name = "_cleanUnusedSystems_", NickName = "_cleanUnusedSystems_", Description = "Clean Unused Systems", Access = GH_ParamAccess.item, Optional = true };
                param_Boolean.SetPersistentData(false);
                result.Add(new GH_SAMParam(param_Boolean, ParamVisibility.Binding));

                param_Boolean = new global::Grasshopper.Kernel.Parameters.Param_Boolean() { Name = "_removeSpacesFormExistingAirSystem_", NickName = "_removeSpacesFormExistingAirSystem_", Description = "Remove Spaces Form Existing AirSystem", Access = GH_ParamAccess.item, Optional = true };
                param_Boolean.SetPersistentData(false);
                result.Add(new GH_SAMParam(param_Boolean, ParamVisibility.Binding));

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
                result.Add(new GH_SAMParam(new GooAnalyticalModelParam { Name = "analyticalModel", NickName = "analyticalModel", Description = "SAM AnalyticalModel", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooAnalyticalModelParam { Name = "airSystem", NickName = "airSystem", Description = "SAM AirSystem", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
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
            int index;

            index = Params.IndexOfInputParam("_analyticalModel");
            AnalyticalModel analyticalModel = null;
            if (!dataAccess.GetData(index, ref analyticalModel) || analyticalModel == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            analyticalModel = new AnalyticalModel(analyticalModel);

            if(!analyticalModel.TryGetValue(Analytical.Systems.AnalyticalModelParameter.SystemEnergyCentre, out SystemEnergyCentre systemEnergyCentre) || systemEnergyCentre == null)
            {
                systemEnergyCentre = analyticalModel.SystemEnergyCentre();
            }

            if (systemEnergyCentre == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Could not get and create SystemEnergyCentre");
                return;
            }

            index = Params.IndexOfInputParam("_airSystem");
            ISystemObject systemObject = null;
            if (!dataAccess.GetData(index, ref systemObject) || systemObject == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            AirSystem airSystem = systemObject as AirSystem;
            if (airSystem == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_spaces");
            List<Space> spaces = new List<Space>();
            if (index == -1 || !dataAccess.GetDataList(index, spaces))
            {
                spaces = null;
            }

            if(spaces == null)
            {
                spaces = analyticalModel.GetSpaces();
            }

            index = Params.IndexOfInputParam("systemEnergyCentre_");
            SystemEnergyCentre systemEnergyCentre_Source = null;
            if(index != -1)
            {
                dataAccess.GetData(index, ref systemEnergyCentre_Source);
            }

            SystemPlantRoom systemPlantRoom = null;

            if (systemEnergyCentre_Source == null)
            {
                airSystem = Analytical.Systems.Modify.UpdateAirSystem(systemEnergyCentre, airSystem, spaces);
            }
            else if (systemEnergyCentre_Source.TryGetSystem(airSystem.Guid, out systemPlantRoom, out airSystem) && systemPlantRoom != null && airSystem != null)
            {
                SystemPlantRoom systemPlantRoom_Destionation = systemEnergyCentre.GetSystemPlantRooms()?.FirstOrDefault();
                if(systemPlantRoom_Destionation == null)
                {
                    systemPlantRoom_Destionation = new SystemPlantRoom(systemPlantRoom.Name);
                    systemEnergyCentre.Add(systemPlantRoom_Destionation);
                }

                airSystem = Analytical.Systems.Modify.UpdateAirSystem(systemPlantRoom_Destionation, systemPlantRoom, airSystem, spaces);
                if(airSystem != null)
                {
                    systemEnergyCentre.Add(systemPlantRoom_Destionation);
                }
            }

            if(airSystem != null)
            {
                systemEnergyCentre.TryGetSystem(airSystem.Guid, out systemPlantRoom, out airSystem);
            }

            if(systemPlantRoom != null)
            {
                index = Params.IndexOfInputParam("_cleanUnusedSystems_");
                bool cleanUnusedSystems = false;
                if (index != -1 && dataAccess.GetData(index, ref cleanUnusedSystems) && cleanUnusedSystems)
                {
                    systemPlantRoom.CleanSystems<AirSystem>();
                    systemEnergyCentre.Add(systemPlantRoom);
                }
            }

            index = Params.IndexOfOutputParam("analyticalModel");
            if (index != -1)
            {
                dataAccess.SetData(index, analyticalModel);
            }

            index = Params.IndexOfOutputParam("airSystem");
            if (index != -1)
            {
                dataAccess.SetData(index, airSystem);
            }
        }
    }
}