using Grasshopper.Kernel;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Core;
using SAM.Core.Grasshopper;
using SAM.Core.Systems;
using SAM.Geometry;
using SAM.Geometry.Grasshopper;
using SAM.Geometry.Object.Planar;
using SAM.Geometry.Planar;
using SAM.Geometry.Spatial;
using SAM.Geometry.Systems;
using System;
using System.Collections.Generic;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class SAMAnalyticalSystemCreateSystemGeometrySymbol : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("9f1933d2-d443-4caf-9e7d-8d61023d7360");

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
        public SAMAnalyticalSystemCreateSystemGeometrySymbol()
          : base("SAMAnalytical.CreateSystemGeometrySymbol", "SAMAnalytical.CreateSystemGeometrySymbol",
              "Create SystemGeometrySymbol",
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
                result.Add(new GH_SAMParam(new GooSAMGeometryParam() { Name = "_geometries", NickName = "_geometries", Description = "SAM Geometries", Access = GH_ParamAccess.list }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooSystemObjectParam() { Name = "_displaySystemConnectors", NickName = "_displaySystemConnectors", Description = "SAM Systems DisplaySystemConnectors", Access = GH_ParamAccess.list }, ParamVisibility.Binding));

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
                result.Add(new GH_SAMParam(new GooSystemObjectParam() { Name = "systemGeometrySymbol", NickName = "systemGeometrySymbol", Description = "SystemGeometrySymbol", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
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


            List<ISystemObject> systemObjects = new List<ISystemObject>();
            index = Params.IndexOfInputParam("_displaySystemConnectors");
            if (index == -1 || !dataAccess.GetDataList(index, systemObjects) || systemObjects == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            List<DisplaySystemConnector> displaySystemConnectors = new List<DisplaySystemConnector>();
            foreach (ISystemObject systemObject in displaySystemConnectors)
            {
                if (systemObject is DisplaySystemConnector)
                {
                    displaySystemConnectors.Add((DisplaySystemConnector)systemObject);
                }
            }

            List<ISAMGeometry> sAMGeometries = new List<ISAMGeometry>();
            index = Params.IndexOfInputParam("_geometries");
            if (index == -1 || !dataAccess.GetDataList(index, sAMGeometries) || sAMGeometries == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }


            Plane plane = new Plane();

            List<ISAMGeometry2D> sAMGeometry2Ds = new List<ISAMGeometry2D>();
            foreach (ISAMGeometry sAMGeometry in sAMGeometries)
            {
                ISAMGeometry2D sAMGeometry2D = null;

                if (sAMGeometry is ISAMGeometry3D)
                {
                    sAMGeometry2D = Geometry.Spatial.Query.Convert(plane, (dynamic)sAMGeometry) as ISAMGeometry2D;
                }
                else if (sAMGeometry is ISAMGeometry2D)
                {
                    sAMGeometry2D = (ISAMGeometry2D)sAMGeometry;
                }
                else
                {
                    continue;
                }

                if (sAMGeometry2D == null)
                {
                    continue;
                }

                sAMGeometry2Ds.Add(sAMGeometry2D);
            }

            SAMGeometry2DObjectCollection sAMGeometry2DObjects = SAM.Geometry.Object.Planar.Create.SAMGeometry2DObjectCollection(sAMGeometry2Ds,
                new Geometry.Object.SurfaceAppearance(System.Drawing.Color.White, System.Drawing.Color.Black, 1),
                new Geometry.Object.CurveAppearance(System.Drawing.Color.Black, 1));

            index = Params.IndexOfOutputParam("systemGeometrySymbol");
            if (index != -1)
            {
                dataAccess.SetData(index, new SystemGeometrySymbol(sAMGeometry2DObjects, displaySystemConnectors));
            }

        }
    }
}