﻿using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemMultiChillerItem : SystemObject
    {
        public ModifiableValue Efficiency { get; set; }

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
    }
}

