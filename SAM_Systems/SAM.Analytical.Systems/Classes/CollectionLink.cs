using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class CollectionLink : ISystemJSAMObject
    {
        private CollectionType collectionType;
        private string name;

        public CollectionLink()
        {
        }

        public CollectionLink(CollectionType collectionType, string name)
        {
            this.collectionType = collectionType;
            this.name = name;
        }

        public CollectionLink(CollectionLink collectionLink)
        {
            if(collectionLink != null)
            {
                collectionType = collectionLink.collectionType;
                name = collectionLink.name;
            }
        }

        public CollectionLink(JObject jObject)
        {
            FromJObject(jObject);
        }

        public CollectionType CollectionType
        {
            get
            {
                return collectionType;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        
        public virtual bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("CollectionType"))
            {
                collectionType = Core.Query.Enum<CollectionType>(jObject.Value<string>("CollectionType"));
            }

            if (jObject.ContainsKey("Name"))
            {
                name = jObject.Value<string>("Name");
            }

            return true;
        }

        public virtual JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(name != null)
            {
                result.Add("Name", name);
            }

            result.Add("CollectionType", collectionType.ToString());

            return result;
        }
    }
}
