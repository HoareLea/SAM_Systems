using Newtonsoft.Json.Linq;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidDifferenceController : SystemLiquidNormalController, ISystemDifferenceController
    {
        private string secondarySensorReference;

        public SystemLiquidDifferenceController(string name, LiquidNormalControllerDataType liquidNormalControllerDataType, ISetpoint setpoint, ISetback setback)
            : base(name, liquidNormalControllerDataType, setpoint, setback)
        {

        }

        public SystemLiquidDifferenceController(string name, string sensorReference, string secondarySensorReference, LiquidNormalControllerDataType liquidNormalControllerDataType, ISetpoint setpoint, ISetback setback)
            : base(name, sensorReference, liquidNormalControllerDataType, setpoint, setback)
        {
            this.secondarySensorReference = secondarySensorReference;
        }

        public SystemLiquidDifferenceController(string name)
            :base(name)
        {
            
        }

        public SystemLiquidDifferenceController(SystemLiquidDifferenceController systemLiquidDifferenceController)
            : base(systemLiquidDifferenceController)
        {
            if(systemLiquidDifferenceController != null)
            {
                secondarySensorReference = systemLiquidDifferenceController.secondarySensorReference;
            }
        }

        public SystemLiquidDifferenceController(System.Guid guid, SystemLiquidDifferenceController systemLiquidDifferenceController)
            : base(guid, systemLiquidDifferenceController)
        {
            if (systemLiquidDifferenceController != null)
            {
                secondarySensorReference = systemLiquidDifferenceController.secondarySensorReference;
            }
        }

        public SystemLiquidDifferenceController(JObject jObject)
            : base(jObject)
        {

        }

        public string SecondarySensorReference
        {
            get
            {
                return secondarySensorReference;
            }

            set
            {
                secondarySensorReference = value;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SecondarySensorReference"))
            {
                secondarySensorReference = jObject.Value<string>("SecondarySensorReference");
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (secondarySensorReference != null)
            {
                result.Add("SecondarySensorReference", secondarySensorReference);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemLiquidDifferenceController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
