using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidJunction : SystemJunction<LiquidSystem>, ILiquidSystemComponent
    {
        public double MainsPressure { get; set; }
        
        public SystemLiquidJunction()
            : base()
        {

        }

        public SystemLiquidJunction(SystemLiquidJunction systemLiquidJunction)
            : base(systemLiquidJunction)
        {
            if(systemLiquidJunction != null)
            {
                MainsPressure = systemLiquidJunction.MainsPressure;
            }
        }

        public SystemLiquidJunction(System.Guid guid, SystemLiquidJunction systemLiquidJunction)
            : base(guid, systemLiquidJunction)
        {
            if (systemLiquidJunction != null)
            {
                MainsPressure = systemLiquidJunction.MainsPressure;
            }
        }

        public SystemLiquidJunction(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemLiquidJunction(string name)
            : base(name)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("MainsPressure"))
            {
                MainsPressure = jObject["MainsPressure"]?.GetValue<double>() ?? default(double);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            if(!double.IsNaN(MainsPressure))
            {
                result.Add("MainsPressure", MainsPressure);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemLiquidJunction(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
