// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class DesignConditionSizableValue : SizableValue
    {
        private HashSet<string> designConditionNames;

        public DesignConditionSizableValue(double value, double sizeFraction, IEnumerable<string> designConditionNames)
            : base(value, sizeFraction)
        {
            this.designConditionNames = designConditionNames == null ? null : new HashSet<string>(designConditionNames);
        }

        public DesignConditionSizableValue(DesignConditionSizableValue designConditionSizableValue)
            :base(designConditionSizableValue)
        {
            if(designConditionSizableValue != null)
            {
                designConditionNames = designConditionSizableValue.designConditionNames == null ? null : new HashSet<string>(designConditionSizableValue.designConditionNames);
            }
        }

        public DesignConditionSizableValue(JsonObject jObject)
            : base(jObject)
        {

        }

        public HashSet<string> DesignConditionNames
        {
            get
            {
                return designConditionNames == null ? null : new HashSet<string>(designConditionNames);
            }

            set
            {
                designConditionNames = value is null ? null : new HashSet<string>(value);
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            if(!base.FromJsonObject(jObject))
            {
                return false;
            }

            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("DesignConditionNames"))
            {
                designConditionNames = new HashSet<string>();

                foreach(JsonNode jsonNode in jObject["DesignConditionNames"] as JsonArray)
                {
                    string designConditionName = jsonNode?.GetValue<string>();
                    if(designConditionName == null)
                    {
                        continue;
                    }

                    designConditionNames.Add(designConditionName);
                }
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if (designConditionNames != null)
            {
                JsonArray jArray = new JsonArray();
                foreach (string designConditionName in designConditionNames)
                {
                    jArray.Add(designConditionName);
                }

                result.Add("DesignConditionNames", jArray);
            }

            return result;
        }
    }
}
