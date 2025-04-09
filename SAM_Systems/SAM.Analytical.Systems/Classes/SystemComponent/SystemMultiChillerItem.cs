using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemMultiChillerItem : SystemObject
    {
        public ModifiableValue Efficiency { get; set; }
        public ModifiableValue CondenserFanLoad { get; set; }
        public double Percentage { get; set; }
        public double Threshold { get; set; }

        public SystemMultiChillerItem()
            : base((string)null)
        {

        }

        public SystemMultiChillerItem(SystemMultiChillerItem systemMultiChillerItem)
            : base(systemMultiChillerItem)
        {
            if(systemMultiChillerItem != null)
            {
                Efficiency = systemMultiChillerItem.Efficiency?.Clone();
                CondenserFanLoad = systemMultiChillerItem.CondenserFanLoad?.Clone();
                Percentage = systemMultiChillerItem.Percentage;
                Threshold = systemMultiChillerItem.Threshold;
            }
        }

        public SystemMultiChillerItem(System.Guid guid, SystemMultiChillerItem systemMultiChillerItem)
            : base(guid, systemMultiChillerItem)
        {
            if (systemMultiChillerItem != null)
            {
                Efficiency = systemMultiChillerItem.Efficiency?.Clone();
                CondenserFanLoad = systemMultiChillerItem.CondenserFanLoad?.Clone();
                Percentage = systemMultiChillerItem.Percentage;
                Threshold = systemMultiChillerItem.Threshold;
            }
        }

        public SystemMultiChillerItem(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Efficiency"));
            }

            if (jObject.ContainsKey("CondenserFanLoad"))
            {
                CondenserFanLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("CondenserFanLoad"));
            }

            if (jObject.ContainsKey("Percentage"))
            {
                Percentage = jObject.Value<double>("Percentage");
            }

            if (jObject.ContainsKey("Threshold"))
            {
                Threshold = jObject.Value<double>("Threshold");
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

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJObject());
            }

            if (CondenserFanLoad != null)
            {
                result.Add("CondenserFanLoad", CondenserFanLoad.ToJObject());
            }

            if (!double.IsNaN(Percentage))
            {
                result.Add("Percentage", Percentage);
            }

            if (!double.IsNaN(Threshold))
            {
                result.Add("Threshold", Threshold);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemMultiChillerItem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}


