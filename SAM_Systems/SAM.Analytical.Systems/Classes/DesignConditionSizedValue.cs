using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class DesignConditionSizedValue : SizedValue
    {
        private HashSet<string> designConditionNames;

        public DesignConditionSizedValue(double value, double sizeFraction, IEnumerable<string> designConditionNames)
            : base(value, sizeFraction)
        {
            this.designConditionNames = designConditionNames == null ? null : new HashSet<string>(designConditionNames);

            SizeFraction = sizeFraction;
        }

        public DesignConditionSizedValue(DesignConditionSizedValue designConditionSizedValue)
            :base(designConditionSizedValue)
        {
            if(designConditionSizedValue != null)
            {
                SizeFraction = designConditionSizedValue.SizeFraction;
                designConditionNames = designConditionSizedValue.designConditionNames == null ? null : new HashSet<string>(designConditionSizedValue.designConditionNames);
            }
        }

        public DesignConditionSizedValue(JObject jObject)
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
