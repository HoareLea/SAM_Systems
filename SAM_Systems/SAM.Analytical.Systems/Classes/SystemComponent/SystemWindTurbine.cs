using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

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

        public SystemWindTurbine(JObject jObject)
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("HubHeight"))
            {
                HubHeight = jObject.Value<double>("HubHeight");
            }

            if (jObject.ContainsKey("Area"))
            {
                Area = jObject.Value<double>("Area");
            }

            if (jObject.ContainsKey("MinSpeed"))
            {
                MinSpeed = jObject.Value<double>("MinSpeed");
            }

            if (jObject.ContainsKey("CutOffSpeed"))
            {
                CutOffSpeed = jObject.Value<double>("CutOffSpeed");
            }

            if (jObject.ContainsKey("Multiplicity"))
            {
                Multiplicity = jObject.Value<int>("Multiplicity");
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Efficiency"));
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
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
                result.Add("Efficiency", Efficiency.ToJObject());
            }

            return result;
        }
    }
}