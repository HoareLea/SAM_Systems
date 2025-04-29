using Newtonsoft.Json.Linq;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public abstract class SystemSensorController : SystemController, ISystemSensorController
    {
        private string sensorReference;

        public SystemSensorController(string name)
            :base(name)
        {

        }

        public SystemSensorController(string name, string sensorReference)
            : base(name)
        {
            this.sensorReference = sensorReference;
        }

        public SystemSensorController(SystemSensorController systemSensorController)
            : base(systemSensorController)
        {
            if(systemSensorController != null)
            {
                sensorReference = systemSensorController.sensorReference;
            }
        }

        public SystemSensorController(System.Guid guid, SystemSensorController systemSensorController)
            : base(guid, systemSensorController)
        {
            if (systemSensorController != null)
            {
                sensorReference = systemSensorController.sensorReference;
            }
        }

        public SystemSensorController(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.Out)
                );
            }
        }

        public string SensorReference
        {
            get
            {
                return sensorReference;
            }

            set
            {
                sensorReference = value;
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SensorReference"))
            {
                sensorReference = jObject.Value<string>("SensorReference");
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

            if(sensorReference != null)
            {
                result.Add("SensorReference", sensorReference);
            }

            return result;
        }
    }
}
