// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.Text.Json.Nodes;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class DesignConditionSizedFlowValue : SizedFlowValue, ISizableValue
    {
        private HashSet<string> designConditionNames;
        private SizedFlowMethod sizedFlowMethod;
        private double sizeValue1;
        private double sizeValue2;
        private SizingType sizingType;
        public DesignConditionSizedFlowValue(double value, double sizeFraction, SizingType sizingType, double sizeValue1, double sizeValue2, SizedFlowMethod sizedFlowMethod, IEnumerable<string> designConditionNames)
            : base(value, sizeFraction)
        {
            this.sizingType = sizingType;
            this.sizeValue1 = sizeValue1;
            this.sizeValue2 = sizeValue2;
            this.sizedFlowMethod = sizedFlowMethod;
            this.designConditionNames = designConditionNames == null ? null : new HashSet<string>(designConditionNames);
        }

        public DesignConditionSizedFlowValue(DesignConditionSizedFlowValue designConditionSizedFlowValue)
            :base(designConditionSizedFlowValue)
        {
            if(designConditionSizedFlowValue != null)
            {
                sizingType = designConditionSizedFlowValue.sizingType;
                sizeValue1 = designConditionSizedFlowValue.sizeValue1;
                sizeValue2 = designConditionSizedFlowValue.sizeValue2;
                sizedFlowMethod = designConditionSizedFlowValue.sizedFlowMethod;
                designConditionNames = designConditionSizedFlowValue.designConditionNames == null ? null : new HashSet<string>(designConditionSizedFlowValue.designConditionNames);
            }
        }

        public DesignConditionSizedFlowValue(JsonObject jObject)
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

        public SizedFlowMethod SizedFlowMethod
        {
            get
            {
                return sizedFlowMethod;
            }
        }

        public double SizeValue1
        {
            get
            {
                return sizeValue1;
            }
        }

        public double SizeValue2
        {
            get
            {
                return sizeValue2;
            }
        }

        public SizingType SizingType
        {
            get
            {
                return sizingType;
            }

            set
            {
                sizingType = value;
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

            if(jObject.ContainsKey("SizingType"))
            {
                sizingType = Core.Query.Enum<SizingType>(jObject["SizingType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("SizeValue1"))
            {
                sizeValue1 = jObject["SizeValue1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("SizeValue2"))
            {
                sizeValue2 = jObject["SizeValue2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("SizedFlowMethod"))
            {
                sizedFlowMethod = Core.Query.Enum<SizedFlowMethod>(jObject["SizedFlowMethod"]?.GetValue<string>() ?? null);
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

            result.Add("SizingType", sizingType.ToString());

            if(!double.IsNaN(sizeValue1))
            {
                result.Add("SizeValue1", sizeValue1);
            }

            if (!double.IsNaN(sizeValue2))
            {
                result.Add("SizeValue2", sizeValue2);
            }

            result.Add("SizedFlowMethod", sizedFlowMethod.ToString());

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
