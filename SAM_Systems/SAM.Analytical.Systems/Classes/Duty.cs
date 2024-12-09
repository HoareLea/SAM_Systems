using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class Duty : SizedValue
    {
        private HashSet<string> designConditionNames;

        public Duty(double value, double sizeFraction, IEnumerable<string> designConditionNames)
            : base(value, sizeFraction)
        {
            this.designConditionNames = designConditionNames == null ? null : new HashSet<string>(designConditionNames);

            SizeFraction = sizeFraction;
        }

        public Duty(Duty duty)
            :base(duty)
        {
            if(duty != null)
            {
                SizeFraction = duty.SizeFraction;
                designConditionNames = duty.designConditionNames == null ? null : new HashSet<string>(duty.designConditionNames);
            }
        }

        public Duty(JObject jObject)
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
