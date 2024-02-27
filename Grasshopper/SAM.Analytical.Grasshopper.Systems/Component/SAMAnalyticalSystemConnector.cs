using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Analytical.Systems;
using SAM.Core;
using SAM.Core.Grasshopper;
using SAM.Core.Grasshopper.Systems;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using SAM.Geometry.Rhino;
using SAM.Geometry.Spatial;
using SAM.Geometry.Systems;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class SAMAnalyticalSystemConnector : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("81ad840f-1382-4091-9f6e-7c15affc2384");

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
        public SAMAnalyticalSystemConnector()
          : base("SAMAnalytical.SystemConnector", "SAMAnalytical.SystemConnector",
              "Create System Connector",
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
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "_analyticalSystemType", NickName = "_analyticalSystemType", Description = "Analytical System Type", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Point() { Name = "_location", NickName = "_location", Description = "Location", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "direction_", NickName = "direction_", Description = "Direction", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Integer() { Name = "connectionIndex_", NickName = "connectionIndex_", Description = "Connection Index", Access = GH_ParamAccess.item, Optional = true }, ParamVisibility.Binding));

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
                result.Add(new GH_SAMParam(new GooSystemObjectParam() { Name = "systemConnector", NickName = "systemConnector", Description = "System Connector", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
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

            index = Params.IndexOfInputParam("_analyticalSystemType");
            if (index == -1 || !dataAccess.GetData(index, ref text) || text == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            SystemType systemType = Analytical.Systems.Create.SystemType(Core.Query.Enum<AnalyticalSystemType>(text));
            if (systemType == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_location");
            global::Rhino.Geometry.Point3d point3d = new Rhino.Geometry.Point3d();
            if (index == -1 || !dataAccess.GetData(index, ref point3d) || point3d == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            Point2D location = Plane.WorldXY.Convert(point3d.ToSAM());

            int connectionIndex = -1;
            index = Params.IndexOfInputParam("connectionIndex_");
            if (index != -1)
            {
                dataAccess.GetData(index, ref connectionIndex);
            }

            Direction direction = Direction.Undefined;
            index = Params.IndexOfInputParam("direction_");
            if (index != -1)
            {
                dataAccess.GetData(index, ref text);

                if (!Core.Query.TryGetEnum(text, out direction))
                {
                    direction = Direction.Undefined;
                }
            }

            DisplaySystemConnector displaySystemConnector = new DisplaySystemConnector(new SystemConnector(systemType, direction, connectionIndex), location);

            index = Params.IndexOfOutputParam("systemConnector");
            if (index != -1)
            {
                dataAccess.SetData(index, displaySystemConnector);
            }

        }
    }
}