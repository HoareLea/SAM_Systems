using GH_IO.Serialization;
using Rhino;
using Rhino.DocObjects;
using Rhino.UI;
using System.Linq;

namespace SAM.Analytical.Grasshopper.Systems
{
    public static partial class Modify
    {
        /// <summary>
        /// Updates or creates a line type in the Rhino document based on the specified line category.
        /// If the line type already exists, its index is returned. Otherwise, a new line type is created
        /// with a pattern corresponding to the line category, scaled to the document's unit system.
        /// </summary>
        /// <param name="rhinoDoc">The Rhino document where the line type will be updated or added.</param>
        /// <param name="lineCategory">The category of the line type to update or create.</param>
        /// <returns>
        /// The index of the line type in the document if successful, or -1 if the operation fails.
        /// </returns>
        public static int UpdateLineType(this RhinoDoc rhinoDoc, LineCategory lineCategory)
        {
            if (rhinoDoc == null || lineCategory == LineCategory.Undefined)
            {
                return -1;
            }

            string name = Query.Name(lineCategory);
            if (string.IsNullOrWhiteSpace(name))
            {
                return -1;
            }

            int result = rhinoDoc.Linetypes.Find(name);
            if (result >= 0)
            {
                return result;
            }

            double[] pattern = null;
            switch (lineCategory)
            {
                case LineCategory.Sensor:
                    pattern = [500, -250, 500, -250];
                    break;

                case LineCategory.Control:
                    pattern = [200, -200];
                    break;
            }

            if (pattern == null)
            {
                return -1;
            }

            double scale = RhinoMath.UnitScale(UnitSystem.Millimeters, rhinoDoc.ModelUnitSystem);

            double[] world = pattern.Select(x => x * scale).ToArray();

            Linetype linetype = new Linetype
            {
                Name = name,
                AlwaysModelDistances = true,
                Width = 1,
                WidthUnits = UnitSystem.Millimeters,
            };

            linetype.SetSegments(world);

            int index = rhinoDoc.Linetypes.Add(linetype);

            linetype = rhinoDoc.Linetypes[index];              // get the stored copy
            linetype.AlwaysModelDistances = true;       // ≙ “Use model units” ✔
            rhinoDoc.Linetypes.Modify(linetype, index, true);

            return index;
        }
    }
}