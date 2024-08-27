using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using SAM.Core.Grasshopper.Systems.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SAM.Core.Systems;

namespace SAM.Core.Grasshopper.Systems
{
    public class GooSystemComponent : GooJSAMObject<ISystemComponent>
    {
        public GooSystemComponent()
            : base()
        {
        }

        public GooSystemComponent(ISystemComponent systemComponent)
            : base(systemComponent)
        {
        }

        public override IGH_Goo Duplicate()
        {
            return new GooSystemComponent(Value);
        }

        public override string TypeName
        {
            get
            {
                return Value == null ? typeof(ISystemComponent).Name : Value.GetType().Name;
            }
        }
    }

    public class GooSystemComponentParam : GH_PersistentParam<GooSystemComponent>
    {
        public override Guid ComponentGuid => new Guid("8874b0c1-da97-466c-b51a-f4a0f89dcaf3");

        protected override System.Drawing.Bitmap Icon => Resources.SAM3_0;

        public GooSystemComponentParam()
            : base(typeof(ISystemComponent).Name, typeof(ISystemComponent).Name, typeof(ISystemComponent).FullName.Replace(".", " "), "Params", "SAM")
        {
        }

        protected override GH_GetterResult Prompt_Plural(ref List<GooSystemComponent> values)
        {
            throw new NotImplementedException();
        }

        protected override GH_GetterResult Prompt_Singular(ref GooSystemComponent value)
        {
            throw new NotImplementedException();
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            Menu_AppendItem(menu, "Save As...", Menu_SaveAs, VolatileData.AllData(true).Any());

            Menu_AppendSeparator(menu);

            base.AppendAdditionalMenuItems(menu);
        }

        private void Menu_SaveAs(object sender, EventArgs e)
        {
            Query.SaveAs(VolatileData);
        }
    }
}