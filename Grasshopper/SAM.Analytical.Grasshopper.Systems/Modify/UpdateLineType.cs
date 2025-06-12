using Rhino;
using Rhino.DocObjects;
using System.Linq;

namespace SAM.Analytical.Grasshopper.Systems
{
    public static partial class Modify
    {
        public static int UpdateLineType(this RhinoDoc rhinoDoc, LineCategory lineCategory)
        {
            if (rhinoDoc == null || lineCategory == LineCategory.Undefined)
            {
                return -1;
            }

            string name = Query.Name(lineCategory);
            if(string.IsNullOrWhiteSpace(name))
            {
                return -1;
            }

            int result = rhinoDoc.Linetypes.Find(name);
            if(result >= 0)
            {
                return result;
            }

            double[] pattern = null;
            switch (lineCategory)
            {
                case LineCategory.Sensor:
                    pattern = [500, -250, 50, -250];
                    break;

                case LineCategory.Control:
                    pattern = [200, 0, 200, 0];
                    break;
            }

            if(pattern == null)
            {
                return -1;
            }

            double scale = RhinoMath.UnitScale(UnitSystem.Millimeters, rhinoDoc.ModelUnitSystem);

            double[] world = pattern.Select(x => x * scale).ToArray();

            Linetype linetype = new Linetype();
            linetype.Name = name;
            linetype.AlwaysModelDistances = true;
            linetype.SetSegments(world);
            linetype.Width = 1;
            linetype.WidthUnits = UnitSystem.Millimeters;


            return rhinoDoc.Linetypes.Add(linetype);
        }
    }
}