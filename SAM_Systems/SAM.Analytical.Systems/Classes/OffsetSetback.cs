// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
namespace SAM.Analytical.Systems
{
    public abstract class OffsetSetback : Setback
    {
        private double offset;

        public OffsetSetback()
        {

        }

        public OffsetSetback(string scheduleName, double offset)
            :base(scheduleName)
        {
            this.offset = offset;
        }

        public OffsetSetback(OffsetSetback offsetSetback)
            :base(offsetSetback)
        {
            if(offsetSetback != null)
            {
                offset = offsetSetback.offset;
            }
        }

        public OffsetSetback(JsonObject jObject)
            : base(jObject)
        {

        }

        public double Offset
        {
            get
            {
                return offset;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Offset"))
            {
                offset = jObject["Offset"]?.GetValue<double>() ?? default(double);
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            if (!double.IsNaN(offset))
            {
                result.Add("Offset", offset);
            }

            return result;
        }
    }
}
