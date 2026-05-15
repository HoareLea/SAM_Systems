using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemIceStorageChiller : SystemChiller, ILiquidSystemComponent
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public ModifiableValue IceMakingEfficiency { get; set; }
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public double DesignTemperatureDifference { get; set; }
        public ISizableValue IceCapacity { get; set; }
        public double InitialIceReserve { get; set; }
        public ModifiableValue CondenserFanLoad { get; set; }
        public ModifiableValue MotorEfficiency { get; set; }
        public double IceMeltChillerFraction { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public bool LossesInSizing { get; set; }

        public string ScheduleName { get; set; }

        public SystemIceStorageChiller(string name)
            : base(name)
        {

        }

        public SystemIceStorageChiller(SystemIceStorageChiller iceStorageSystemChiller)
            : base(iceStorageSystemChiller)
        {
            if (iceStorageSystemChiller != null)
            {
                Setpoint = iceStorageSystemChiller.Setpoint?.Clone();
                Efficiency = iceStorageSystemChiller.Efficiency?.Clone();
                IceMakingEfficiency = iceStorageSystemChiller.IceMakingEfficiency?.Clone();
                Capacity = iceStorageSystemChiller.Capacity;
                DesignPressureDrop = iceStorageSystemChiller.DesignPressureDrop;
                DesignTemperatureDifference = iceStorageSystemChiller.DesignTemperatureDifference;
                IceCapacity = iceStorageSystemChiller.IceCapacity?.Clone();
                InitialIceReserve = iceStorageSystemChiller.InitialIceReserve;
                CondenserFanLoad = iceStorageSystemChiller.CondenserFanLoad?.Clone();
                MotorEfficiency = iceStorageSystemChiller.MotorEfficiency?.Clone();
                IceMeltChillerFraction = iceStorageSystemChiller.IceMeltChillerFraction;
                AncillaryLoad = iceStorageSystemChiller.AncillaryLoad?.Clone();
                LossesInSizing = iceStorageSystemChiller.LossesInSizing;
                ScheduleName = iceStorageSystemChiller.ScheduleName;
            }
        }

        public SystemIceStorageChiller(System.Guid guid, SystemIceStorageChiller iceStorageSystemChiller)
            : base(guid, iceStorageSystemChiller)
        {
            if (iceStorageSystemChiller != null)
            {
                Setpoint = iceStorageSystemChiller.Setpoint?.Clone();
                Efficiency = iceStorageSystemChiller.Efficiency?.Clone();
                IceMakingEfficiency = iceStorageSystemChiller.IceMakingEfficiency?.Clone();
                Capacity = iceStorageSystemChiller.Capacity;
                DesignPressureDrop = iceStorageSystemChiller.DesignPressureDrop;
                DesignTemperatureDifference = iceStorageSystemChiller.DesignTemperatureDifference;
                IceCapacity = iceStorageSystemChiller.IceCapacity?.Clone();
                InitialIceReserve = iceStorageSystemChiller.InitialIceReserve;
                CondenserFanLoad = iceStorageSystemChiller.CondenserFanLoad?.Clone();
                MotorEfficiency = iceStorageSystemChiller.MotorEfficiency?.Clone();
                IceMeltChillerFraction = iceStorageSystemChiller.IceMeltChillerFraction;
                AncillaryLoad = iceStorageSystemChiller.AncillaryLoad?.Clone();
                LossesInSizing = iceStorageSystemChiller.LossesInSizing;
                ScheduleName = iceStorageSystemChiller.ScheduleName;
            }
        }

        public SystemIceStorageChiller(JsonObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("IceMakingEfficiency"))
            {
                IceMakingEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["IceMakingEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject["DesignTemperatureDifference"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("IceCapacity"))
            {
                IceCapacity = Core.Query.IJSAMObject<SizableValue>(jObject["IceCapacity"] as JsonObject);
            }

            if (jObject.ContainsKey("InitialIceReserve"))
            {
                InitialIceReserve = jObject["InitialIceReserve"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("CondenserFanLoad"))
            {
                CondenserFanLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["CondenserFanLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("MotorEfficiency"))
            {
                MotorEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["MotorEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("IceMeltChillerFraction"))
            {
                IceMeltChillerFraction = jObject["IceMeltChillerFraction"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["AncillaryLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject["LossesInSizing"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return result;
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
            }

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (IceMakingEfficiency != null)
            {
                result.Add("IceMakingEfficiency", IceMakingEfficiency.ToJsonObject());
            }

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            if (IceCapacity != null)
            {
                result.Add("IceCapacity", IceCapacity.ToJsonObject());
            }

            if (!double.IsNaN(InitialIceReserve))
            {
                result.Add("InitialIceReserve", InitialIceReserve);
            }

            if (CondenserFanLoad != null)
            {
                result.Add("CondenserFanLoad", CondenserFanLoad.ToJsonObject());
            }

            if (MotorEfficiency != null)
            {
                result.Add("MotorEfficiency", MotorEfficiency.ToJsonObject());
            }

            if (!double.IsNaN(IceMeltChillerFraction))
            {
                result.Add("IceMeltChillerFraction", IceMeltChillerFraction);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
            }

            result.Add("LossesInSizing", LossesInSizing);

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemIceStorageChiller(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}



