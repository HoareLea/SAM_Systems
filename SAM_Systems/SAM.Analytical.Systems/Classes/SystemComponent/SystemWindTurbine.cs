using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemWindTurbine : SystemComponent
    {
        public double HubHeight { get; set; }
        public double Area { get; set; }
        public double MinSpeed { get; set; }
        public double CutOffSpeed { get; set; }
        public int Multiplicity { get; set; }
        public ModifiableValue Efficiency { get; set; }


        public SystemWindTurbine(string name)
            : base(name)
        {

        }

        public SystemWindTurbine(SystemWindTurbine systemWindTurbine)
            : base(systemWindTurbine)
        {
            if(systemWindTurbine != null)
            {
                HubHeight = systemWindTurbine.HubHeight;
                Area = systemWindTurbine.Area;
                MinSpeed = systemWindTurbine.MinSpeed;
                CutOffSpeed = systemWindTurbine.CutOffSpeed;
                Multiplicity = systemWindTurbine.Multiplicity;
                Efficiency = systemWindTurbine.Efficiency?.Clone();
            }
        }

        public SystemWindTurbine(System.Guid guid, SystemWindTurbine systemWindTurbine)
            : base(guid, systemWindTurbine)
        {
            if (systemWindTurbine != null)
            {
                HubHeight = systemWindTurbine.HubHeight;
                Area = systemWindTurbine.Area;
                MinSpeed = systemWindTurbine.MinSpeed;
                CutOffSpeed = systemWindTurbine.CutOffSpeed;
                Multiplicity = systemWindTurbine.Multiplicity;
                Efficiency = systemWindTurbine.Efficiency?.Clone();
            }
        }

        public SystemWindTurbine(JsonObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    //Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    //Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    //Core.Systems.Create.SystemConnector<IControlSystem>()
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

            if (jObject.ContainsKey("HubHeight"))
            {
                HubHeight = jObject["HubHeight"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Area"))
            {
                Area = jObject["Area"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("MinSpeed"))
            {
                MinSpeed = jObject["MinSpeed"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("CutOffSpeed"))
            {
                CutOffSpeed = jObject["CutOffSpeed"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Multiplicity"))
            {
                Multiplicity = jObject["Multiplicity"]?.GetValue<int>() ?? default(int);
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
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

            if (!double.IsNaN(HubHeight))
            {
                result.Add("HubHeight", HubHeight);
            }

            if (!double.IsNaN(Area))
            {
                result.Add("Area", Area);
            }

            if (!double.IsNaN(MinSpeed))
            {
                result.Add("MinSpeed", MinSpeed);
            }

            if (!double.IsNaN(CutOffSpeed))
            {
                result.Add("CutOffSpeed", CutOffSpeed);
            }

            result.Add("Multiplicity", Multiplicity);
            
            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemWindTurbine(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}