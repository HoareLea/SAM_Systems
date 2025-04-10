using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SAM.Core.Systems
{
    public class SystemRelationCluster : SAMObjectRelationCluster<ISystemJSAMObject>
    {
        public SystemRelationCluster(JObject jObject) 
            : base(jObject)
        {
        }

        public SystemRelationCluster(SystemRelationCluster systemRelationCluster)
            : base(systemRelationCluster)
        {
        }

        public SystemRelationCluster(SystemRelationCluster systemRelationCluster, bool deepClone)
            : base(systemRelationCluster, deepClone)
        {
        }

        public SystemRelationCluster()
            : base()
        {
        }

        public SystemRelationCluster Duplicate()
        {
            SystemRelationCluster result = new SystemRelationCluster();

            List<ISystemJSAMObject> systemJSAMObjects = GetObjects();
            if (systemJSAMObjects != null)
            {
                Dictionary<System.Guid, ISystemJSAMObject> dictionary = new Dictionary<System.Guid, ISystemJSAMObject>();

                for (int i = 0; i < systemJSAMObjects.Count; i++)
                {
                    ISystemJSAMObject systemJSAMObject = systemJSAMObjects[i];
                    System.Guid guid = GetGuid(systemJSAMObject);

                    if (systemJSAMObject is SystemObject)
                    {
                        systemJSAMObject = ((SystemObject)systemJSAMObject).Duplicate();
                    }
                    else
                    {
                        systemJSAMObject = systemJSAMObject.Clone();
                    }

                    dictionary[Guid] = systemJSAMObject;
                }

                foreach (ISystemJSAMObject systemJSAMObject in systemJSAMObjects)
                {
                    if (systemJSAMObject is SystemObject)
                    {

                    }
                }
            }

            return result;
        }
    }
}
