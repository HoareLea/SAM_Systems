using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

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
                result.Add(PipeLength.ToJObject());
            }

            return result;
        }
    }
}
