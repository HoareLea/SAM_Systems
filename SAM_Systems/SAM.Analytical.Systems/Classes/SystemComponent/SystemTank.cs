using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemTank : SystemComponent, ILiquidSystemComponent
    {
        public double InsulationConductivity { get; set; }
        public double InsulationThickness { get; set; }
        public double Volume { get; set; }
        public double HeatExchangeEfficiency1 { get; set; }
        public double HeatExchangeEfficiency2 { get; set; }
        public double Height { get; set; }
        public ModifiableValue AmbientTemperature { get; set; }
        public ModifiableValue Setpoint { get; set; }
        public double Capacity1 { get; set; }
        public double Capacity2 { get; set; }
        public double Capacity3 { get; set; }
        public double DesignPressureDrop1 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        public double DesignPressureDrop3 { get; set; }
        public bool UseDefinedHeatLoss { get; set; }
        public double DefinedHeatLossRate { get; set; }
        public SetpointMode SetpointMode { get; set; }

        public SystemTank(string name)
            : base(name)
        {

        }

        public SystemTank(SystemTank systemTank)
            : base(systemTank)
        {
            if(systemTank != null)
            {
                InsulationConductivity = systemTank.InsulationConductivity;
                InsulationThickness = systemTank.InsulationThickness;
                Volume = systemTank.Volume;
                HeatExchangeEfficiency1 = systemTank.HeatExchangeEfficiency1;
                HeatExchangeEfficiency2 = systemTank.HeatExchangeEfficiency2;
                Height = systemTank.Height;
                AmbientTemperature = systemTank.AmbientTemperature?.Clone();
                Setpoint = systemTank.Setpoint?.Clone();
                Capacity1 = systemTank.Capacity1;
                Capacity2 = systemTank.Capacity2;
                Capacity3 = systemTank.Capacity3;
                DesignPressureDrop1 = systemTank.DesignPressureDrop1;
                DesignPressureDrop2 = systemTank.DesignPressureDrop2;
                DesignPressureDrop3 = systemTank.DesignPressureDrop3;
                UseDefinedHeatLoss = systemTank.UseDefinedHeatLoss;
                DefinedHeatLossRate = systemTank.DefinedHeatLossRate;
                SetpointMode = systemTank.SetpointMode;
            }
        }

        public SystemTank(System.Guid guid, SystemTank systemTank)
            : base(guid, systemTank)
        {
            if (systemTank != null)
            {
                InsulationConductivity = systemTank.InsulationConductivity;
                InsulationThickness = systemTank.InsulationThickness;
                Volume = systemTank.Volume;
                HeatExchangeEfficiency1 = systemTank.HeatExchangeEfficiency1;
                HeatExchangeEfficiency2 = systemTank.HeatExchangeEfficiency2;
                Height = systemTank.Height;
                AmbientTemperature = systemTank.AmbientTemperature?.Clone();
                Setpoint = systemTank.Setpoint?.Clone();
                Capacity1 = systemTank.Capacity1;
                Capacity2 = systemTank.Capacity2;
                Capacity3 = systemTank.Capacity3;
                DesignPressureDrop1 = systemTank.DesignPressureDrop1;
                DesignPressureDrop2 = systemTank.DesignPressureDrop2;
                DesignPressureDrop3 = systemTank.DesignPressureDrop3;
                UseDefinedHeatLoss = systemTank.UseDefinedHeatLoss;
                DefinedHeatLossRate = systemTank.DefinedHeatLossRate;
                SetpointMode = systemTank.SetpointMode;
            }
        }

        public SystemTank(JsonObject jObject)
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

            if(jObject.ContainsKey("InsulationConductivity"))
            {
                InsulationConductivity = jObject["InsulationConductivity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("InsulationThickness"))
            {
                InsulationThickness = jObject["InsulationThickness"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Volume"))
            {
                Volume = jObject["Volume"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("HeatExchangeEfficiency1"))
            {
                HeatExchangeEfficiency1 = jObject["HeatExchangeEfficiency1"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("HeatExchangeEfficiency2"))
            {
                HeatExchangeEfficiency2 = jObject["HeatExchangeEfficiency2"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Height"))
            {
                Height = jObject["Height"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AmbientTemperature"))
            {
                AmbientTemperature = Core.Query.IJSAMObject<ModifiableValue>(jObject["AmbientTemperature"] as JsonObject);
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject["Setpoint"] as JsonObject);
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

            if (jObject.ContainsKey("DefinedHeatLossRate"))
            {
                DefinedHeatLossRate = jObject["DefinedHeatLossRate"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("UseDefinedHeatLoss"))
            {
                UseDefinedHeatLoss = jObject["UseDefinedHeatLoss"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("SetpointMode"))
            {
                SetpointMode = Core.Query.Enum<SetpointMode>(jObject["SetpointMode"]?.GetValue<string>() ?? null);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if(!double.IsNaN(InsulationConductivity))
            {
                result.Add("InsulationConductivity", InsulationConductivity);
            }

            if (!double.IsNaN(InsulationThickness))
            {
                result.Add("InsulationThickness", InsulationThickness);
            }

            if (!double.IsNaN(Volume))
            {
                result.Add("Volume", Volume);
            }

            if (!double.IsNaN(HeatExchangeEfficiency1))
            {
                result.Add("HeatExchangeEfficiency1", HeatExchangeEfficiency1);
            }

            if (!double.IsNaN(HeatExchangeEfficiency2))
            {
                result.Add("HeatExchangeEfficiency2", HeatExchangeEfficiency2);
            }

            if (!double.IsNaN(Height))
            {
                result.Add("Height", Height);
            }

            if(AmbientTemperature != null)
            {
                result.Add("AmbientTemperature", AmbientTemperature.ToJsonObject());
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJsonObject());
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

            if (!double.IsNaN(DefinedHeatLossRate))
            {
                result.Add("DefinedHeatLossRate", DefinedHeatLossRate);
            }

            result.Add("UseDefinedHeatLoss", UseDefinedHeatLoss);

            result.Add("SetpointMode", SetpointMode.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemTank(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}