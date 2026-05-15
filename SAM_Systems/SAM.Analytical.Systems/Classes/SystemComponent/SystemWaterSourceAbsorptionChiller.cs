// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceAbsorptionChiller : SystemChiller
    {
        public ModifiableValue Setpoint { get; set; }
        public ModifiableValue Efficiency { get; set; }
        public double Capacity1 { get; set; }
        public double DesignPressureDrop1 { get; set; }
        public double Capacity2 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        public double Capacity3 { get; set; }
        public double DesignPressureDrop3 { get; set; }
        public ModifiableValue AncillaryLoad { get; set; }
        public ModifiableValue MinimalOutSourceTemperature { get; set; }
        public bool LossesInSizing { get; set; }

        public SystemWaterSourceAbsorptionChiller(string name)
            : base(name)
        {

        }

        public SystemWaterSourceAbsorptionChiller(SystemWaterSourceAbsorptionChiller waterSourceAbsorptionSystemChiller)
            : base(waterSourceAbsorptionSystemChiller)
        {
            if (waterSourceAbsorptionSystemChiller != null)
            {
                Setpoint = waterSourceAbsorptionSystemChiller.Setpoint?.Clone();
                Efficiency = waterSourceAbsorptionSystemChiller.Efficiency?.Clone();
                Capacity1 = waterSourceAbsorptionSystemChiller.Capacity1;
                Capacity2 = waterSourceAbsorptionSystemChiller.Capacity2;
                Capacity3 = waterSourceAbsorptionSystemChiller.Capacity3;
                DesignPressureDrop1 = waterSourceAbsorptionSystemChiller.DesignPressureDrop1;
                DesignPressureDrop2 = waterSourceAbsorptionSystemChiller.DesignPressureDrop2;
                DesignPressureDrop3 = waterSourceAbsorptionSystemChiller.DesignPressureDrop3;
                AncillaryLoad = waterSourceAbsorptionSystemChiller.AncillaryLoad?.Clone();
                MinimalOutSourceTemperature = waterSourceAbsorptionSystemChiller.MinimalOutSourceTemperature?.Clone();
                LossesInSizing = waterSourceAbsorptionSystemChiller.LossesInSizing;
            }
        }

        public SystemWaterSourceAbsorptionChiller(System.Guid guid, SystemWaterSourceAbsorptionChiller waterSourceAbsorptionSystemChiller)
            : base(guid, waterSourceAbsorptionSystemChiller)
        {
            if (waterSourceAbsorptionSystemChiller != null)
            {
                Setpoint = waterSourceAbsorptionSystemChiller.Setpoint?.Clone();
                Efficiency = waterSourceAbsorptionSystemChiller.Efficiency?.Clone();
                Capacity1 = waterSourceAbsorptionSystemChiller.Capacity1;
                Capacity2 = waterSourceAbsorptionSystemChiller.Capacity2;
                Capacity3 = waterSourceAbsorptionSystemChiller.Capacity3;
                DesignPressureDrop1 = waterSourceAbsorptionSystemChiller.DesignPressureDrop1;
                DesignPressureDrop2 = waterSourceAbsorptionSystemChiller.DesignPressureDrop2;
                DesignPressureDrop3 = waterSourceAbsorptionSystemChiller.DesignPressureDrop3;
                AncillaryLoad = waterSourceAbsorptionSystemChiller.AncillaryLoad?.Clone();
                MinimalOutSourceTemperature = waterSourceAbsorptionSystemChiller.MinimalOutSourceTemperature?.Clone();
                LossesInSizing = waterSourceAbsorptionSystemChiller.LossesInSizing;
            }
        }

        public SystemWaterSourceAbsorptionChiller(JsonObject jObject)
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
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 3),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 3),
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

            if (jObject.ContainsKey("Capacity3"))
            {
                Capacity3 = jObject["Capacity3"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop1"))
            {
                DesignPressureDrop1 = jObject["DesignPressureDrop1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop2"))
            {
                DesignPressureDrop2 = jObject["DesignPressureDrop2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop3"))
            {
                DesignPressureDrop3 = jObject["DesignPressureDrop3"]?.GetValue<double>() ?? default(double);
            }

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

            if (!double.IsNaN(Capacity3))
            {
                result.Add("Capacity3", Capacity3);
            }

            if (!double.IsNaN(DesignPressureDrop1))
            {
                result.Add("DesignPressureDrop1", DesignPressureDrop1);
            }

            if (!double.IsNaN(DesignPressureDrop2))
            {
                result.Add("DesignPressureDrop2", DesignPressureDrop2);
            }

            if (!double.IsNaN(DesignPressureDrop3))
            {
                result.Add("DesignPressureDrop3", DesignPressureDrop3);
            }

            if (AncillaryLoad != null)
            {
                result.Add("AncillaryLoad", AncillaryLoad.ToJsonObject());
            }

            if (MinimalOutSourceTemperature != null)
            {
                result.Add("MinimalOutSourceTemperature", MinimalOutSourceTemperature.ToJsonObject());
            }

            result.Add("LossesInSizing", LossesInSizing);

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemWaterSourceAbsorptionChiller(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}



