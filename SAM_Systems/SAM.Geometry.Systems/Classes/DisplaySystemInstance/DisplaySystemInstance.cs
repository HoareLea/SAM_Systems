using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Geometry.Systems
{
    public abstract class DisplaySystemInstance : IDisplaySystemInstance
    {
        public PathReference pathReference;

        public PathReference PathReference
        {
            get
            {
                return pathReference;
            }
        }

        public DisplaySystemInstance(PathReference pathReference)
        {
            this.pathReference = pathReference == null ? null : new PathReference(pathReference);
        }

        public DisplaySystemInstance(JObject jObject)
        {
            FromJObject(jObject);
        }

        public DisplaySystemInstance(DisplaySystemInstance displaySystemInstance)
        {
            if(displaySystemInstance != null)
            {
                pathReference = displaySystemInstance.pathReference == null ? null : new PathReference(displaySystemInstance.PathReference);
            }
        }

        public virtual bool FromJObject(JObject jObject)
        {
            if(jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("PathReference"))
            {
                pathReference = new PathReference(jObject.Value<JObject>("PathReference"));
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (pathReference != null)
            {
                result.Add("PathReference", pathReference.ToJObject());
            }

            return result;
        }
    }
}
