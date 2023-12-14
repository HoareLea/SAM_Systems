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
    public class GooSystemEnergyCentre : GooJSAMObject<SystemEnergyCentre>
    {
        public GooSystemEnergyCentre()
            : base()
        {
        }

        public GooSystemEnergyCentre(SystemEnergyCentre systemEnergyCentre)
            : base(systemEnergyCentre)
        {
        }

        public override IGH_Goo Duplicate()
        {
            return new GooSystemEnergyCentre(Value);
        }

        public override string TypeName
        {
            get
            {
                return Value == null ? typeof(SystemEnergyCentre).Name : Value.GetType().Name;
            }
        }
    }

    public class GooSystemEnergyCentreParam : GH_PersistentParam<GooSystemEnergyCentre>
    {
        public override Guid ComponentGuid => new Guid("49858433-6e52-493a-bea1-e2e76e4e9170");

        protected override System.Drawing.Bitmap Icon => Resources.SAM3_0;

        public GooSystemEnergyCentreParam()
            : base(typeof(SystemEnergyCentre).Name, typeof(SystemEnergyCentre).Name, typeof(SystemEnergyCentre).FullName.Replace(".", " "), "Params", "SAM")
        {
        }

        protected override GH_GetterResult Prompt_Plural(ref List<GooSystemEnergyCentre> values)
        {
            throw new NotImplementedException();
        }

        protected override GH_GetterResult Prompt_Singular(ref GooSystemEnergyCentre value)
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
            Core.Grasshopper.Query.SaveAs(VolatileData);
        }
    }
}