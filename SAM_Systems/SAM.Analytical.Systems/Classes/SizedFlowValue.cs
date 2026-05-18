// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SizedFlowValue : ISystemJSAMObject
    {
        private double value;
        private double sizeFranction;

        public SizedFlowValue()
        {
        }

        public SizedFlowValue(double value, double sizeFranction)
        {
            this.value = value;
            this.sizeFranction = sizeFranction;
        }

        public SizedFlowValue(SizedFlowValue sizedFlowValue)
        {
            if(sizedFlowValue != null)
            {
                value = sizedFlowValue.value;
                sizeFranction = sizedFlowValue.sizeFranction;
            }
        }

        public SizedFlowValue(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        public double SizeFranction
        {
            get
            {
                return sizeFranction;
            }
        }

        public virtual bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("Value"))
            {
                value = jObject["Value"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("SizeFranction"))
            {
                sizeFranction = jObject["SizeFranction"]?.GetValue<double>() ?? default(double);
            }

            return true;
        }

        public virtual JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(!double.IsNaN(value))
            {
                result.Add("Value", value);
            }

            if (!double.IsNaN(sizeFranction))
            {
                result.Add("SizeFranction", sizeFranction);
            }

            return result;
        }
    }
}
