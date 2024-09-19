using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemEnergyCentreResult : Result, ISystemResult
    {
        private List<SystemEnergyCentreValues> systemEnergyCentreValues = new List<SystemEnergyCentreValues>();
        
        public SystemEnergyCentreDataType SystemEnergyCentreDataType { private set; get; }

        public SystemEnergyCentreResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
        }

        public SystemEnergyCentreResult(SystemEnergyCentreResult systemEnergyCentreResult)
            : base(systemEnergyCentreResult)
        {
            if (systemEnergyCentreResult != null)
            {
                SystemEnergyCentreDataType = systemEnergyCentreResult.SystemEnergyCentreDataType;
                systemEnergyCentreValues = systemEnergyCentreResult.systemEnergyCentreValues?.ConvertAll(x => new SystemEnergyCentreValues(x));
            }
        }

        public SystemEnergyCentreResult(string uniqueId, string name, string source, SystemEnergyCentreDataType systemEnergyCentreDataType, IEnumerable<SystemEnergyCentreValues> systemEnergyCentreValues)
            : base(name, source, uniqueId)
        {
            SystemEnergyCentreDataType = systemEnergyCentreDataType;
            this.systemEnergyCentreValues = systemEnergyCentreValues.ToList().ConvertAll(x => new SystemEnergyCentreValues(x));
        }

        public List<SystemEnergyCentreValues> SystemEnergyCentreValues
        {
            get
            {
                return systemEnergyCentreValues?.ConvertAll(x => new SystemEnergyCentreValues(x));
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemEnergyCentreDataType"))
            {
                SystemEnergyCentreDataType = Core.Query.Enum<SystemEnergyCentreDataType>(jObject.Value<string>("SystemEnergyCentreDataType"));
            }

            if (jObject.ContainsKey("SystemEnergyCentreValues"))
            {
                JArray jArray = jObject.Value<JArray>("SystemEnergyCentreValues");
                if(jArray != null)
                {
                    systemEnergyCentreValues = new List<SystemEnergyCentreValues>();
                    foreach(JObject jObject_SystemEnergyCentreValues in jArray)
                    {
                        systemEnergyCentreValues.Add(new SystemEnergyCentreValues(jObject_SystemEnergyCentreValues));
                    }

                }
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
            if (jObject == null)
            {
                return null;
            }

            jObject.Add("SystemEnergyCentreDataType", SystemEnergyCentreDataType.ToString());

            if(systemEnergyCentreValues != null)
            {
                JArray jArray = new JArray();
                foreach(SystemEnergyCentreValues systemEnergyCentreGroup in systemEnergyCentreValues)
                {
                    jArray.Add(systemEnergyCentreGroup.ToJObject());
                }

                jObject.Add("SystemEnergyCentreValues", jArray);
            }

            return jObject;
        }
    }
}
