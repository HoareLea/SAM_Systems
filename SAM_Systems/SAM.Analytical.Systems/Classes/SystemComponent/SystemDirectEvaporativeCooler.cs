using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemDirectEvaporativeCooler : SystemHumidifier, IAirSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }

        public ModifiableValue Effectiveness { get; set; }

        public ISizableValue WaterFlowCapacity { get; set; }

        public ModifiableValue ElectricalLoad { get; set; }

        public ISizableValue TankVolume { get; set; }

        public double HoursBeforePurgingTank { get; set; }

        public string ScheduleName { get; set; }

        public SystemDirectEvaporativeCooler(string name)
            : base(name)
        {

        }

        public SystemDirectEvaporativeCooler(System.Guid guid, SystemDirectEvaporativeCooler systemDirectEvaporativeCooler)
            : base(guid, systemDirectEvaporativeCooler)
        {
            if (systemDirectEvaporativeCooler != null)
            {
                Setpoint = systemDirectEvaporativeCooler.Setpoint?.Clone();
                Effectiveness = systemDirectEvaporativeCooler.Effectiveness?.Clone();
                WaterFlowCapacity = systemDirectEvaporativeCooler.WaterFlowCapacity?.Clone();
                ElectricalLoad = systemDirectEvaporativeCooler.ElectricalLoad?.Clone();
                TankVolume = systemDirectEvaporativeCooler.TankVolume?.Clone();
                HoursBeforePurgingTank = systemDirectEvaporativeCooler.HoursBeforePurgingTank;
                ScheduleName = systemDirectEvaporativeCooler.ScheduleName;
            }
        }

        public SystemDirectEvaporativeCooler(SystemDirectEvaporativeCooler systemDirectEvaporativeCooler)
            : base(systemDirectEvaporativeCooler)
        {
            if(systemDirectEvaporativeCooler != null)
            {
                Setpoint = systemDirectEvaporativeCooler.Setpoint?.Clone();
                Effectiveness = systemDirectEvaporativeCooler.Effectiveness?.Clone();
                WaterFlowCapacity = systemDirectEvaporativeCooler.WaterFlowCapacity?.Clone();
                ElectricalLoad = systemDirectEvaporativeCooler.ElectricalLoad?.Clone();
                TankVolume = systemDirectEvaporativeCooler.TankVolume?.Clone();
                HoursBeforePurgingTank = systemDirectEvaporativeCooler.HoursBeforePurgingTank;
                ScheduleName = systemDirectEvaporativeCooler.ScheduleName;
            }
        }

        public SystemDirectEvaporativeCooler(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("Effectiveness"))
            {
                Effectiveness = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Effectiveness"));
            }

            if (jObject.ContainsKey("WaterFlowCapacity"))
            {
                WaterFlowCapacity = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("WaterFlowCapacity"));
            }

            if (jObject.ContainsKey("ElectricalLoad"))
            {
                ElectricalLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("ElectricalLoad"));
            }

            if (jObject.ContainsKey("TankVolume"))
            {
                TankVolume = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("TankVolume"));
            }

            if (jObject.ContainsKey("HoursBeforePurgingTank"))
            {
                HoursBeforePurgingTank = jObject.Value<double>("HoursBeforePurgingTank");
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (Effectiveness != null)
            {
                result.Add("Effectiveness", Effectiveness.ToJObject());
            }

            if (WaterFlowCapacity != null)
            {
                result.Add("WaterFlowCapacity", WaterFlowCapacity.ToJObject());
            }

            if (ElectricalLoad != null)
            {
                result.Add("ElectricalLoad", ElectricalLoad.ToJObject());
            }

            if (TankVolume != null)
            {
                result.Add("TankVolume", TankVolume.ToJObject());
            }

            if (!double.IsNaN(HoursBeforePurgingTank))
            {
                result.Add("HoursBeforePurgingTank", HoursBeforePurgingTank);
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemDirectEvaporativeCooler(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
