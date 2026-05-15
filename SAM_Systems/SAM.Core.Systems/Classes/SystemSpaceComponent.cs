using System.Text.Json.Nodes;
namespace SAM.Core.Systems
{
    public abstract class SystemSpaceComponent : SystemComponent, ISystemSpaceComponent
    {
        public SystemSpaceComponent(string name)
            : base(name)
        {
        }

        public SystemSpaceComponent(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemSpaceComponent(SystemSpaceComponent systemSpaceComponent)
            : base(systemSpaceComponent)
        {

        }

        public SystemSpaceComponent(System.Guid guid, SystemSpaceComponent systemSpaceComponent)
            : base(guid, systemSpaceComponent)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            return base.FromJsonObject(jObject);
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            return result;
        }
    }
}
