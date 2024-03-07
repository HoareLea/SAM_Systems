//using Grasshopper.Kernel;
//using Grasshopper.Kernel.Types;
//using SAM.Core.Grasshopper.Systems.Properties;
//using SAM.Core.Systems;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;

//namespace SAM.Core.Grasshopper.Systems
//{
//    public class GooSystemObject : GooJSAMObject<ISystemJSAMObject>
//    {
//        public GooSystemObject()
//            : base()
//        {
//        }

//        public GooSystemObject(ISystemJSAMObject systemObject)
//            : base(systemObject)
//        {
//        }

//        public override IGH_Goo Duplicate()
//        {
//            return new GooSystemObject(Value);
//        }

//        public override bool CastFrom(object source)
//        {
//            return base.CastFrom(source);
//        }

//        public override bool CastTo<Y>(ref Y target)
//        {
//            return base.CastTo(ref target);
//        }

//        public override string TypeName
//        {
//            get
//            {
//                return Value == null ? typeof(ISystemObject).Name : Value.GetType().Name;
//            }
//        }
//    }

//    public class GooSystemObjectParam : GH_PersistentParam<GooSystemObject>
//    {
//        public override Guid ComponentGuid => new Guid("55d4a95d-124b-4e7d-b415-f77e12b6f2dc");

//        protected override System.Drawing.Bitmap Icon => Resources.SAM3_0;

//        public GooSystemObjectParam()
//            : base(typeof(ISystemObject).Name, typeof(ISystemObject).Name, typeof(ISystemObject).FullName.Replace(".", " "), "Params", "SAM")
//        {
//        }

//        protected override GH_GetterResult Prompt_Plural(ref List<GooSystemObject> values)
//        {
//            throw new NotImplementedException();
//        }

//        protected override GH_GetterResult Prompt_Singular(ref GooSystemObject value)
//        {
//            throw new NotImplementedException();
//        }

//        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
//        {
//            Menu_AppendItem(menu, "Save As...", Menu_SaveAs, VolatileData.AllData(true).Any());

//            //Menu_AppendSeparator(menu);

//            base.AppendAdditionalMenuItems(menu);
//        }

//        private void Menu_SaveAs(object sender, EventArgs e)
//        {
//            Query.SaveAs(VolatileData);
//        }
//    }
//}