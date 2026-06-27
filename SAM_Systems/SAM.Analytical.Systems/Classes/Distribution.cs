// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class Distribution : ModifiableValue
    {
        private bool isEfficiency;

        public Distribution(IModifier modifier, double value, bool isEfficiency)
            : base(modifier, value)
        {
            this.isEfficiency = isEfficiency;
        }

        public Distribution(double value, bool isEfficiency)
            : base(value)
        {
            this.isEfficiency = isEfficiency;
        }

        public Distribution(Distribution distribution)
            : base(distribution)
        {
            if (distribution != null)
            {
                isEfficiency = distribution.isEfficiency;
            }
        }

        public Distribution(JsonObject jObject)
            : base(jObject)
        {

        }

        public bool IsEfficiency
        {
            get
            {
                return isEfficiency;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("IsEfficiency"))
            {
                isEfficiency = jObject["IsEfficiency"]?.GetValue<bool>() ?? default(bool);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return result;
            }

            result.Add("IsEfficiency", isEfficiency);

            return result;
        }
    }
}

