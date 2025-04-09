using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemMultiBoilerItem : SystemObject
    {
        public ModifiableValue Efficiency { get; set; }

        public double Percentage { get; set; }

        public double Threshold { get; set; }

        public ModifiableValue AncillaryLoad { get; set; }

        public SystemMultiBoilerItem()
            : base((string)null)
        {

        }

        public SystemMultiBoilerItem(SystemMultiBoilerItem systemMultiBoilerItem)
            : base(systemMultiBoilerItem)
        {
            if(systemMultiBoilerItem != null)
            {
                Efficiency = systemMultiBoilerItem.Efficiency?.Clone();
                Percentage = systemMultiBoilerItem.Percentage;
                Threshold = systemMultiBoilerItem.Threshold;
                AncillaryLoad = systemMultiBoilerItem.AncillaryLoad?.Clone();
            }
        }

        public SystemMultiBoilerItem(System.Guid guid, SystemMultiBoilerItem systemMultiBoilerItem)
            : base(guid, systemMultiBoilerItem)
        {
            if (systemMultiBoilerItem != null)
            {
                Efficiency = systemMultiBoilerItem.Efficiency?.Clone();
                Percentage = systemMultiBoilerItem.Percentage;
                Threshold = systemMultiBoilerItem.Threshold;
                AncillaryLoad = systemMultiBoilerItem.AncillaryLoad?.Clone();
            }
        }

        public SystemMultiBoilerItem(JObject jObject)
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

            if (jObject.ContainsKey("Percentage"))
            {
                Percentage = jObject.Value<double>("Percentage");
            }

            if (jObject.ContainsKey("Threshold"))
            {
                Threshold = jObject.Value<double>("Threshold");
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("AncillaryLoad"));
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

            if (!double.IsNaN(Percentage))
            {
                result.Add("Percentage", Percentage);
            }

            if (!double.IsNaN(Threshold))
            {
                result.Add("Threshold", Threshold);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJObject());
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemMultiBoilerItem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}


