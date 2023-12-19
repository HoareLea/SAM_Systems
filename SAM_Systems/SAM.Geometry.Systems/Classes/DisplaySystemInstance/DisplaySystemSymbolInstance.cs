using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemSymbolInstance : DisplaySystemInstance
    {
        private DisplaySystemSymbol displaySystemSymbol;
        private CoordinateSystem2D coordinateSystem2D;

        private DisplaySystemSymbolInstance(PathReference pathReference, DisplaySystemSymbol displaySystemSymbol, Point2D loaction)
            : base(pathReference)
        {
            this.displaySystemSymbol = displaySystemSymbol.Clone();
            coordinateSystem2D = new CoordinateSystem2D();
        }

        private DisplaySystemSymbolInstance(DisplaySystemSymbolInstance displaySystemSymbolInstance)
            : base(displaySystemSymbolInstance)
        {
            if(displaySystemSymbolInstance != null)
            {
                displaySystemSymbol = displaySystemSymbolInstance.displaySystemSymbol == null ? null : new DisplaySystemSymbol(displaySystemSymbolInstance.displaySystemSymbol);
                coordinateSystem2D = displaySystemSymbolInstance.coordinateSystem2D == null ? null : new CoordinateSystem2D(displaySystemSymbolInstance.coordinateSystem2D);
            }
        }

        private DisplaySystemSymbolInstance(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("DisplaySystemSymbol"))
            {
                displaySystemSymbol = Core.Query.IJSAMObject<DisplaySystemSymbol>(jObject.Value<JObject>("DisplaySystemSymbol"));
            }

            if (jObject.ContainsKey("CoordinateSystem2D"))
            {
                coordinateSystem2D = Core.Query.IJSAMObject<CoordinateSystem2D>(jObject.Value<JObject>("CoordinateSystem2D"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(coordinateSystem2D != null)
            {
                result.Add("CoordinateSystem2D", coordinateSystem2D.ToJObject());
            }

            if (displaySystemSymbol != null)
            {
                result.Add("DisplaySystemSymbol", displaySystemSymbol.ToJObject());
            }

            return result;
        }


    }
}
