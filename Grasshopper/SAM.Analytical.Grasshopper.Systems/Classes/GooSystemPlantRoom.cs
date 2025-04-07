using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using SAM.Core.Grasshopper;
using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Rhino;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class GooSystemPlantRoom : GooJSAMObject<SystemPlantRoom>
    {
        public GooSystemPlantRoom()
            : base()
        {
        }

        public GooSystemPlantRoom(SystemPlantRoom systemPlantRoom)
            : base(systemPlantRoom)
        {
        }

        public override IGH_Goo Duplicate()
        {
            return new GooSystemPlantRoom(Value);
        }

        public override bool CastFrom(object source)
        {
            return base.CastFrom(source);
        }

        public override bool CastTo<Y>(ref Y target)
        {
            return base.CastTo(ref target);
        }

        public override string TypeName
        {
            get
            {
                return Value == null ? typeof(SystemPlantRoom).Name : Value.GetType().Name;
            }
        }
    }

    public class GooSystemPlantRoomParam : GH_PersistentParam<GooSystemPlantRoom>
    {
        public override Guid ComponentGuid => new Guid("fec532ae-cc6d-48ae-9765-939c109393c7");

        protected override System.Drawing.Bitmap Icon => Resources.SAM3_0;

        public GooSystemPlantRoomParam()
            : base(typeof(SystemPlantRoom).Name, typeof(SystemPlantRoom).Name, typeof(SystemPlantRoom).FullName.Replace(".", " "), "Params", "SAM")
        {
        }

        protected override GH_GetterResult Prompt_Plural(ref List<GooSystemPlantRoom> values)
        {
            throw new NotImplementedException();
        }

        protected override GH_GetterResult Prompt_Singular(ref GooSystemPlantRoom value)
        {
            throw new NotImplementedException();
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            Menu_AppendItem(menu, "Bake By Type", Menu_BakeByPanelType, VolatileData.AllData(true).Any());
            Menu_AppendItem(menu, "Save As...", Menu_SaveAs, VolatileData.AllData(true).Any());

            //Menu_AppendSeparator(menu);

            base.AppendAdditionalMenuItems(menu);
        }

        private void Menu_BakeByPanelType(object sender, EventArgs e)
        {
            BakeGeometry_ByType(RhinoDoc.ActiveDoc);
        }

        public void BakeGeometry_ByType(RhinoDoc doc)
        {
            Modify.BakeGeometry_ByType(doc, VolatileData);
        }

        private void Menu_SaveAs(object sender, EventArgs e)
        {
            Core.Grasshopper.Query.SaveAs(VolatileData);
        }
    }
}