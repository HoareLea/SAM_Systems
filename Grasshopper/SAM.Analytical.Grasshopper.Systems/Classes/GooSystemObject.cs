using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino;
using Rhino.DocObjects;
using Rhino.Geometry;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Core.Grasshopper;
using SAM.Core.Systems;
using SAM.Geometry.Object.Planar;
using SAM.Geometry.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class GooSystemObject : GooJSAMObject<ISystemJSAMObject>, IGH_PreviewData, IGH_BakeAwareData
    {
        public GooSystemObject()
            : base()
        {
        }

        public GooSystemObject(ISystemJSAMObject systemObject)
            : base(systemObject)
        {
        }

        public override IGH_Goo Duplicate()
        {
            return new GooSystemObject(Value);
        }

        public override bool CastFrom(object source)
        {
            return base.CastFrom(source);
        }

        public override bool CastTo<Y>(ref Y target)
        {
            return base.CastTo(ref target);
        }

        public void DrawViewportWires(GH_PreviewWireArgs args)
        {
            ISAMGeometry2DObject sAMGeometry2DObject = null;

            if(Value is IDisplaySystemObject)
            {
                sAMGeometry2DObject = Analytical.Systems.Query.SAMGeometry2Dobject((IDisplaySystemObject)Value);
            }

            if(sAMGeometry2DObject != null)
            {
                Geometry.Grasshopper.Modify.DrawViewportWires(sAMGeometry2DObject, args, args.Color);
            }
        }

        public void DrawViewportMeshes(GH_PreviewMeshArgs args)
        {

        }

        public bool BakeGeometry(RhinoDoc doc, ObjectAttributes att, out Guid obj_guid)
        {
            obj_guid = Guid.Empty;
            if (Value == null)
            {
                return false;
            }
            ISAMGeometry2DObject sAMGeometry2DObject = null;

            if (Value is IDisplaySystemObject)
            {
                sAMGeometry2DObject = Analytical.Systems.Query.SAMGeometry2Dobject((IDisplaySystemObject)Value);
            }

            if(sAMGeometry2DObject == null)
            {
                return false;
            }

            bool result = Geometry.Rhino.Modify.BakeGeometry(sAMGeometry2DObject, doc, att, out List<Guid> obj_guids);
            if (!result)
            {
                return false;
            }

            if (obj_guids == null || obj_guids.Count == 0)
            {
                return false;
            }

            if (obj_guids.Count == 1)
            {
                obj_guid = obj_guids[0];
                return result;
            }

            int index = doc.Groups.Add(Guid.NewGuid().ToString());

            Group group = doc.Groups.ElementAt(index);
            foreach (Guid guid in obj_guids)
            {
                doc.Groups.AddToGroup(index, guid);
            }

            obj_guid = group.Id;
            return result;
        }

        public override string TypeName
        {
            get
            {
                return Value == null ? typeof(ISystemObject).Name : Value.GetType().Name;
            }
        }

        public BoundingBox ClippingBox => BoundingBox.Unset;
    }

    public class GooSystemObjectParam : GH_PersistentParam<GooSystemObject>, IGH_PreviewObject, IGH_BakeAwareObject
    {
        public override Guid ComponentGuid => new Guid("55d4a95d-124b-4e7d-b415-f77e12b6f2dc");

        protected override System.Drawing.Bitmap Icon => Resources.SAM_Small;

        public bool Hidden { get; set; }

        //public override GH_Exposure Exposure => GH_Exposure.hidden;

        public bool IsPreviewCapable => !VolatileData.IsEmpty;

        public BoundingBox ClippingBox => Preview_ComputeClippingBox();

        public bool IsBakeCapable => throw new NotImplementedException();

        public GooSystemObjectParam()
            : base(typeof(ISystemObject).Name, typeof(ISystemObject).Name, typeof(ISystemObject).FullName.Replace(".", " "), "Params", "SAM")
        {
        }

        protected override GH_GetterResult Prompt_Plural(ref List<GooSystemObject> values)
        {
            throw new NotImplementedException();
        }

        protected override GH_GetterResult Prompt_Singular(ref GooSystemObject value)
        {
            throw new NotImplementedException();
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            Menu_AppendItem(menu, "Save As...", Menu_SaveAs, VolatileData.AllData(true).Any());

            //Menu_AppendSeparator(menu);

            base.AppendAdditionalMenuItems(menu);
        }

        private void Menu_SaveAs(object sender, EventArgs e)
        {
            Core.Grasshopper.Query.SaveAs(VolatileData);
        }

        public void DrawViewportWires(IGH_PreviewArgs args)
        {
            Preview_DrawWires(args);
        }

        public void DrawViewportMeshes(IGH_PreviewArgs args)
        {
            Preview_DrawMeshes(args);
        }

        public void BakeGeometry(RhinoDoc doc, List<Guid> obj_ids)
        {
            BakeGeometry(doc, doc.CreateDefaultAttributes(), obj_ids);
        }

        public void BakeGeometry(RhinoDoc doc, ObjectAttributes att, List<Guid> obj_ids)
        {
            foreach (var value in VolatileData.AllData(true))
            {
                Guid uuid = default;
                (value as IGH_BakeAwareData)?.BakeGeometry(doc, att, out uuid);
                obj_ids.Add(uuid);
            }
        }
    }
}