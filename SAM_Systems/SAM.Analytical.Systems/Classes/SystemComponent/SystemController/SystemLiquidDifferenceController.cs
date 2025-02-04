﻿using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidDifferenceController : SystemLiquidNormalController
    {
        private string secondarySensorReference;

        public SystemLiquidDifferenceController(string name, LiquidNormalControllerDataType liquidNormalControllerDataType, ISetpoint setpoint)
            : base(name, liquidNormalControllerDataType, setpoint)
        {

        }

        public SystemLiquidDifferenceController(string name, string sensorReference, string secondarySensorReference, LiquidNormalControllerDataType liquidNormalControllerDataType, ISetpoint setpoint)
            : base(name, sensorReference, liquidNormalControllerDataType, setpoint)
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
    }
}
