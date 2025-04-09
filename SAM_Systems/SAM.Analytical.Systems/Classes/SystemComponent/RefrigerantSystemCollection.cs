using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class RefrigerantSystemCollection : SystemCollection<LiquidSystem>
    {
        public ModifiableValue PipeLength { get; set; }

        public RefrigerantSystemCollection()
            : base()
        {
        }

        public RefrigerantSystemCollection(string name)
            : base(name)
        {
        }

        public RefrigerantSystemCollection(JObject jObject)
            : base(jObject)
        {

        }

        public RefrigerantSystemCollection(RefrigerantSystemCollection refrigerantSystemCollection)
            : base(refrigerantSystemCollection)
        {
            if(refrigerantSystemCollection != null)
            {
                PipeLength = refrigerantSystemCollection.PipeLength?.Clone();
            }
        }

        public RefrigerantSystemCollection(System.Guid guid, RefrigerantSystemCollection refrigerantSystemCollection)
            : base(guid, refrigerantSystemCollection)
        {
            if (refrigerantSystemCollection != null)
            {
                PipeLength = refrigerantSystemCollection.PipeLength?.Clone();
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("PipeLength"))
            {
                PipeLength = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PipeLength"));
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if(PipeLength != null)
            {
                result.Add("PipeLength", PipeLength.ToJObject());
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new RefrigerantSystemCollection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
