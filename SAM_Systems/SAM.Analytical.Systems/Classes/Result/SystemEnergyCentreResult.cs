using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemEnergyCentreResult : Result, ISystemResult
    {
        private List<SystemEnergyCentreGroup> systemEnergyCentreGroups = new List<SystemEnergyCentreGroup>();
        
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
                systemEnergyCentreGroups = systemEnergyCentreResult.systemEnergyCentreGroups?.ConvertAll(x => new SystemEnergyCentreGroup(x));
            }
        }

        public SystemEnergyCentreResult(string uniqueId, string name, string source, SystemEnergyCentreDataType systemEnergyCentreDataType, IEnumerable<SystemEnergyCentreGroup> systemEnergyCentreGroups)
            : base(name, source, uniqueId)
        {
            SystemEnergyCentreDataType = systemEnergyCentreDataType;
            this.systemEnergyCentreGroups = systemEnergyCentreGroups.ToList().ConvertAll(x => new SystemEnergyCentreGroup(x));
        }

        public List<SystemEnergyCentreGroup> SystemEnergyCentreGroups
        {
            get
            {
                return systemEnergyCentreGroups?.ConvertAll(x => new SystemEnergyCentreGroup(x));
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

            if (jObject.ContainsKey("SystemEnergyCentreGroups"))
            {
                JArray jArray = jObject.Value<JArray>("SystemEnergyCentreGroups");
                if(jArray != null)
                {
                    systemEnergyCentreGroups = new List<SystemEnergyCentreGroup>();
                    foreach(JObject jObject_SystemEnergyCentreGroupResult in jArray)
                    {
                        systemEnergyCentreGroups.Add(new SystemEnergyCentreGroup(jObject_SystemEnergyCentreGroupResult));
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

            if(systemEnergyCentreGroups != null)
            {
                JArray jArray = new JArray();
                foreach(SystemEnergyCentreGroup systemEnergyCentreGroup in systemEnergyCentreGroups)
                {
                    jArray.Add(systemEnergyCentreGroup.ToJObject());
                }

                jObject.Add("SystemEnergyCentreGroups", jArray);
            }

            return jObject;
        }
    }
}
