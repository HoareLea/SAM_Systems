using Grasshopper.Kernel;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Analytical.Systems;
using SAM.Core.Grasshopper;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class SAMSystemsMergeEnergyCentreByECs : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("3e1534f7-3ff4-40a0-8b29-1633699eeab5");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.0";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM3_0;

        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Initializes a new instance of the SAM_point3D class.
        /// </summary>
        public SAMSystemsMergeEnergyCentreByECs()
          : base("SAMSystems.MergeEnergyCentreByECs", "SAMSystems.MergeEnergyCentreByECs",
              "Merges MergeEnergyCentreByECs",
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
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new GooSystemEnergyCentreParam() { Name = "_systemEnergyCentres", NickName = "_systemEnergyCentres", Description = "SAM SystemEnergyCentres", Access = GH_ParamAccess.list }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooSystemParam() { Name = "airSystems_", NickName = "airSystems_", Description = "SAM AirSystems", Access = GH_ParamAccess.list, Optional = true }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooSystemPlantRoomParam() { Name = "systemPlantRooms_", NickName = "systemPlantRooms_", Description = "SAM SystemPlantRooms", Access = GH_ParamAccess.list, Optional = true }, ParamVisibility.Binding));
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
                result.Add(new GH_SAMParam(new GooSystemEnergyCentreParam() { Name = "systemEnergyCentre", NickName = "systemEnergyCentre", Description = "SAM SystemEnergyCentre", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooSystemGroupParam() { Name = "airSystemGroups", NickName = "airSystemGroups", Description = "SAM AirSystemGroups", Access = GH_ParamAccess.list }, ParamVisibility.Binding));
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

            int index_SystemEnergyCentre = Params.IndexOfOutputParam("systemEnergyCentre");
            int index_SystemAirGroups = Params.IndexOfOutputParam("airSystemGroups");

            SystemEnergyCentre systemEnergyCentre = null;
            List<AirSystemGroup> airSystemGroups = null;

            if (index_SystemEnergyCentre != -1)
            {
                dataAccess.SetData(index_SystemEnergyCentre, systemEnergyCentre);
            }

            if (index_SystemAirGroups != -1)
            {
                dataAccess.SetData(index_SystemAirGroups, airSystemGroups);
            }

            index = Params.IndexOfInputParam("_systemEnergyCentres");
            List<SystemEnergyCentre> systemEnergyCentres = new List<SystemEnergyCentre>();
            if (index == -1 || !dataAccess.GetDataList(index, systemEnergyCentres) || systemEnergyCentres == null || systemEnergyCentres.Count == 0)
            {
                return;
            }

            systemEnergyCentre = new SystemEnergyCentre(systemEnergyCentres[0].Name);

            List<ISystem> systems = new List<ISystem>();
            index = Params.IndexOfInputParam("airSystems_");
            if (index == -1 || !dataAccess.GetDataList(index, systems) || systems == null)
            {
                systems = new List<ISystem>();
            }

            if (systems.Count != 0 && systems.Count != systemEnergyCentres.Count)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid number of inputs");
                return;
            }

            List<SystemPlantRoom> systemPlantRooms = new List<SystemPlantRoom>();
            index = Params.IndexOfInputParam("systemPlantRooms_");
            if (index == -1 || !dataAccess.GetDataList(index, systemPlantRooms) || systemPlantRooms == null)
            {
                systemPlantRooms = new List<SystemPlantRoom>();
            }

            if (systemPlantRooms.Count != 0 && systemPlantRooms.Count != systemEnergyCentres.Count)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid number of inputs");
                return;
            }

            for (int i = 0; i < systemEnergyCentres.Count; i++)
            {
                Analytical.Systems.Modify.Merge(systemEnergyCentre, systemEnergyCentres[i], systems.Count == 0 ? null : systems[i] as AirSystem, systemPlantRooms.Count == 0 ? null : systemPlantRooms[i]);
            }

            if (index_SystemEnergyCentre != -1)
            {
                dataAccess.SetData(index_SystemEnergyCentre, systemEnergyCentre);
            }

            List<SystemPlantRoom> systemPlantRooms_Temp = systemEnergyCentre?.GetSystemPlantRooms();
            if (systemPlantRooms_Temp != null)
            {
                airSystemGroups = new List<AirSystemGroup>();
                foreach (SystemPlantRoom systemPlantRoom_Temp in systemPlantRooms_Temp)
                {
                    List<AirSystemGroup> airSystemGroups_SystemPlantRoom = systemPlantRoom_Temp?.GetSystemObjects<AirSystemGroup>();
                    if (airSystemGroups_SystemPlantRoom != null)
                    {
                        airSystemGroups.AddRange(airSystemGroups_SystemPlantRoom);
                    }
                }
            }

            if (index_SystemAirGroups != -1)
            {
                dataAccess.SetDataList(index_SystemAirGroups, airSystemGroups?.ConvertAll(x => new GooSystemGroup(x)));
            }
        }
    }
}