using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemRadiator : SystemSpaceComponent
    {
        public ModifiableValue Efficiency { get; set; }
        public ISizableValue Duty { get; set; }

        public string ScheduleName { get; set; }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<ElectricalSystem>(Direction.In)
                );
            }
        }

        public SystemRadiator(string name)
            : base(name)
        {
        }

        public SystemRadiator(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemRadiator(SystemRadiator systemRadiator)
            : base(systemRadiator)
        {
            if (systemRadiator != null)
            {
                Efficiency = systemRadiator.Efficiency?.Clone();
                Duty = systemRadiator.Duty;
                ScheduleName = systemRadiator.ScheduleName;
            }
        }

        public SystemRadiator(Guid guid, SystemRadiator systemRadiator)
            : base(guid, systemRadiator)
        {
            if (systemRadiator != null)
            {
                Efficiency = systemRadiator.Efficiency?.Clone();
                Duty = systemRadiator.Duty;
                ScheduleName = systemRadiator.ScheduleName;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject["Duty"] as JsonObject);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJsonObject());
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemRadiator(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
