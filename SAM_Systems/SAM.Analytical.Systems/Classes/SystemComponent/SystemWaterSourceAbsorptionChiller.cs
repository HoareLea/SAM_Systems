using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class SystemWaterSourceAbsorptionChiller : SystemChiller
    {
        public double DesignPressureDrop1 { get; set; }
        public double DesignPressureDrop2 { get; set; }
        public double DesignPressureDrop3 { get; set; }

        public SystemWaterSourceAbsorptionChiller(string name)
            : base(name)
        {

        }

        public SystemWaterSourceAbsorptionChiller(SystemWaterSourceAbsorptionChiller waterSourceAbsorptionSystemChiller)
            : base(waterSourceAbsorptionSystemChiller)
        {
            if (waterSourceAbsorptionSystemChiller != null)
            {
                DesignPressureDrop1 = waterSourceAbsorptionSystemChiller.DesignPressureDrop1;
                DesignPressureDrop2 = waterSourceAbsorptionSystemChiller.DesignPressureDrop2;
                DesignPressureDrop3 = waterSourceAbsorptionSystemChiller.DesignPressureDrop3;
            }
        }

        public SystemWaterSourceAbsorptionChiller(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 2),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 2),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 3),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 3),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
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

            if (jObject.ContainsKey("DesignPressureDrop1"))
            {
                DesignPressureDrop1 = jObject.Value<double>("DesignPressureDrop1");
            }

            if (jObject.ContainsKey("DesignPressureDrop2"))
            {
                DesignPressureDrop2 = jObject.Value<double>("DesignPressureDrop2");
            }

            if (jObject.ContainsKey("DesignPressureDrop3"))
            {
                DesignPressureDrop3 = jObject.Value<double>("DesignPressureDrop3");
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

            return result;
        }
    }
}



