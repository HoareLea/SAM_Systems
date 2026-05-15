using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemAbsorptionChiller : SystemChiller
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public double Capacity1 { get; set; }
        public double DesignPressureDrop1 { get; set; }
        public double Capacity2 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        //public double Capacity3 { get; set; }
        //public double DesignPressureDrop3 { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public ModifiableValue MinimalOutSourceTemperature { get; set; }
        public bool LossesInSizing { get; set; }

        public string ScheduleName { get; set; }

        public SystemAbsorptionChiller(string name)
            : base(name)
        {

        }

        public SystemAbsorptionChiller(SystemAbsorptionChiller absorptionSystemChiller)
            : base(absorptionSystemChiller)
        {
            if (absorptionSystemChiller != null)
            {
                Setpoint = absorptionSystemChiller.Setpoint?.Clone();
                Efficiency = absorptionSystemChiller.Efficiency?.Clone();
                Capacity1 = absorptionSystemChiller.Capacity1;
                Capacity2 = absorptionSystemChiller.Capacity2;
                //Capacity3 = absorptionSystemChiller.Capacity3;
                DesignPressureDrop1 = absorptionSystemChiller.DesignPressureDrop1;
                DesignPressureDrop2 = absorptionSystemChiller.DesignPressureDrop2;
                //DesignPressureDrop3 = absorptionSystemChiller.DesignPressureDrop3;
                AncillaryLoad = absorptionSystemChiller.AncillaryLoad?.Clone();
                MinimalOutSourceTemperature = absorptionSystemChiller.MinimalOutSourceTemperature?.Clone();
                LossesInSizing = absorptionSystemChiller.LossesInSizing;
                ScheduleName = absorptionSystemChiller.ScheduleName;
            }
        }

        public SystemAbsorptionChiller(System.Guid guid, SystemAbsorptionChiller absorptionSystemChiller)
        : base(guid, absorptionSystemChiller)
        {
            if (absorptionSystemChiller != null)
            {
                Setpoint = absorptionSystemChiller.Setpoint?.Clone();
                Efficiency = absorptionSystemChiller.Efficiency?.Clone();
                Capacity1 = absorptionSystemChiller.Capacity1;
                Capacity2 = absorptionSystemChiller.Capacity2;
                //Capacity3 = absorptionSystemChiller.Capacity3;
                DesignPressureDrop1 = absorptionSystemChiller.DesignPressureDrop1;
                DesignPressureDrop2 = absorptionSystemChiller.DesignPressureDrop2;
                //DesignPressureDrop3 = absorptionSystemChiller.DesignPressureDrop3;
                AncillaryLoad = absorptionSystemChiller.AncillaryLoad?.Clone();
                MinimalOutSourceTemperature = absorptionSystemChiller.MinimalOutSourceTemperature?.Clone();
                LossesInSizing = absorptionSystemChiller.LossesInSizing;
                ScheduleName = absorptionSystemChiller.ScheduleName;
            }
        }

        public SystemAbsorptionChiller(JsonObject jObject)
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 2),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 2),
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

            if (jObject.ContainsKey("Capacity1"))
            {
                Capacity1 = jObject["Capacity1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Capacity2"))
            {
                Capacity2 = jObject["Capacity2"]?.GetValue<double>() ?? default(double);
            }

            //if (jObject.ContainsKey("Capacity3"))
            //{
            //    Capacity3 = jObject["Capacity3"]?.GetValue<double>() ?? default(double);
            //}

            if (jObject.ContainsKey("DesignPressureDrop1"))
            {
                DesignPressureDrop1 = jObject["DesignPressureDrop1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop2"))
            {
                DesignPressureDrop2 = jObject["DesignPressureDrop2"]?.GetValue<double>() ?? default(double);
            }

            //if (jObject.ContainsKey("DesignPressureDrop3"))
            //{
            //    DesignPressureDrop3 = jObject["DesignPressureDrop3"]?.GetValue<double>() ?? default(double);
            //}

            if (jObject.ContainsKey("AncillaryLoad"))
            {
                AncillaryLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["AncillaryLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject["LossesInSizing"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("MinimalOutSourceTemperature"))
            {
                MinimalOutSourceTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject["MinimalOutSourceTemperature"] as JsonObject);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
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

            if (!double.IsNaN(Capacity1))
            {
                result.Add("Capacity1", Capacity1);
            }

            if (!double.IsNaN(Capacity2))
            {
                result.Add("Capacity2", Capacity2);
            }

            //if (!double.IsNaN(Capacity3))
            //{
            //    result.Add("Capacity3", Capacity3);
            //}

            if (!double.IsNaN(DesignPressureDrop1))
            {
                result.Add("DesignPressureDrop1", DesignPressureDrop1);
            }

            if (!double.IsNaN(DesignPressureDrop2))
            {
                result.Add("DesignPressureDrop2", DesignPressureDrop2);
            }

            //if (!double.IsNaN(DesignPressureDrop3))
            //{
            //    result.Add("DesignPressureDrop3", DesignPressureDrop3);
            //}

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
            }

            if (MinimalOutSourceTemperature != null)
            {
                result.Add("MinimalOutSourceTemperature", MinimalOutSourceTemperature.ToJsonObject());
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
            return new SystemAbsorptionChiller(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}

