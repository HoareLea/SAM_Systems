using Grasshopper.Kernel;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Core;
using SAM.Core.Grasshopper;
using SAM.Core.Grasshopper.Systems;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class SAMAnalyticalSystemConnectedSystemComponents : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("11f8fdbc-0270-44bf-a2d5-aca2e10a39f7");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.0";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM_Small;

        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Initializes a new instance of the SAM_point3D class.
        /// </summary>
        public SAMAnalyticalSystemConnectedSystemComponents()
          : base("SAMAnalytical.ConnectedSystemComponents", "SAMAnalytical.ConnectedSystemComponents",
              "Gets Connected System Components",
              "SAM WIP", "Systems")
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
                result.Add(new GH_SAMParam(new GooSystemPlantRoomParam() { Name = "_systemPlantRoom", NickName = "_systemPlantRoom", Description = "SystemPlantRoom", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new Core.Grasshopper.Systems.GooSystemParam() { Name = "_system", NickName = "_system", Description = "System", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooSystemComponentParam() { Name = "_systemComponent", NickName = "_systemComponent", Description = "System Component", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "direction_", NickName = "direction_", Description = "Flow Direction", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Binding));

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
                result.Add(new GH_SAMParam(new GooSystemComponentParam() { Name = "systemComponents", NickName = "systemComponents", Description = "System Components", Access = GH_ParamAccess.list }, ParamVisibility.Binding));
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

            string text = null;

            index = Params.IndexOfInputParam("_systemPlantRoom");
            SystemPlantRoom systemPlantRoom = null;
            if (index == -1 || !dataAccess.GetData(index, ref systemPlantRoom) || systemPlantRoom == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_system");
            Core.Systems.ISystem system = null;
            if (index == -1 || !dataAccess.GetData(index, ref system) || system == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_systemComponent");
            ISystemComponent systemComponent = null;
            if (index == -1 || !dataAccess.GetData(index, ref systemComponent) || systemComponent == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            Direction? direction = null;
            index = Params.IndexOfInputParam("direction_");
            if (index != -1)
            {
                string directionString = null;
                if (dataAccess.GetData(index, ref directionString) && directionString != null)
                {
                    direction = Core.Query.Enum<Direction>(directionString);
                }
            }

            List<ISystemComponent> systemComponents = new List<ISystemComponent>();

            if(direction == null || direction == Direction.Undefined)
            {
                systemPlantRoom.GetNextSystemComponents<ISystemComponent>(systemComponent, system, Direction.In)?.ForEach(x => systemComponents.Add(x));
                systemPlantRoom.GetNextSystemComponents<ISystemComponent>(systemComponent, system, Direction.Out)?.ForEach(x => systemComponents.Add(x));
            }
            else
            {
                systemPlantRoom.GetNextSystemComponents<ISystemComponent>(systemComponent, system, direction.Value)?.ForEach(x => systemComponents.Add(x));
            }

            index = Params.IndexOfOutputParam("systemComponents");
            if (index != -1)
            {
                dataAccess.SetDataList(index, systemComponents);
            }

        }
    }
}