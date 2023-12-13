using Newtonsoft.Json.Linq;

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
    }
}
