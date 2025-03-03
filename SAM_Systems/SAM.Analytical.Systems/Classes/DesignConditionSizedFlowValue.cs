using Newtonsoft.Json.Linq;
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

        public DesignConditionSizedFlowValue(JObject jObject)
            : base(jObject)
        {

        }

        public HashSet<string> DesignConditionNames
        {
            get
            {
                return designConditionNames == null ? null : new HashSet<string>(designConditionNames);
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
        }
        
        public override bool FromJObject(JObject jObject)
        {
            if(!base.FromJObject(jObject))
            {
                return false;
            }

            if (jObject == null)
            {
                return false;
            }

            if(jObject.ContainsKey("SizingType"))
            {
                sizingType = Core.Query.Enum<SizingType>(jObject.Value<string>("SizingType"));
            }

            if (jObject.ContainsKey("SizeValue1"))
            {
                sizeValue1 = jObject.Value<double>("SizeValue1");
            }

            if (jObject.ContainsKey("SizeValue2"))
            {
                sizeValue2 = jObject.Value<double>("SizeValue2");
            }

            if (jObject.ContainsKey("SizedFlowMethod"))
            {
                sizedFlowMethod = Core.Query.Enum<SizedFlowMethod>(jObject.Value<string>("SizedFlowMethod"));
            }

            if (jObject.ContainsKey("DesignConditionNames"))
            {
                designConditionNames = new HashSet<string>();

                foreach(string designConditionName in jObject.Value<JArray>("DesignConditionNames"))
                {
                    if(designConditionName == null)
                    {
                        continue;
                    }

                    designConditionNames.Add(designConditionName);
                }
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
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
                JArray jArray = new JArray();
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
