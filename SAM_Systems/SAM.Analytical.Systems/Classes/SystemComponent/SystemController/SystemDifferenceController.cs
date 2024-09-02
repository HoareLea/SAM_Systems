using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class SystemDifferenceController : SystemIndoorController
    {
        private string secondarySensorReference;

        public SystemDifferenceController(string name, IndoorControllerDataType indoorControllerDataType, ISetpoint setpoint, IndoorControllerLimit indoorControllerLimit)
            : base(name, indoorControllerDataType, setpoint, indoorControllerLimit)
        {

        }

        public SystemDifferenceController(string name, string sensorReference, string secondarySensorReference, IndoorControllerDataType indoorControllerDataType, ISetpoint setpoint, IndoorControllerLimit indoorControllerLimit)
            : base(name, sensorReference, indoorControllerDataType, setpoint, indoorControllerLimit)
        {
            this.secondarySensorReference = secondarySensorReference;
        }

        public SystemDifferenceController(string name)
            :base(name)
        {
            
        }

        public SystemDifferenceController(SystemDifferenceController systemDifferenceController)
            : base(systemDifferenceController)
        {
            if(systemDifferenceController != null)
            {
                secondarySensorReference = systemDifferenceController.secondarySensorReference;
            }
        }

        public SystemDifferenceController(JObject jObject)
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
