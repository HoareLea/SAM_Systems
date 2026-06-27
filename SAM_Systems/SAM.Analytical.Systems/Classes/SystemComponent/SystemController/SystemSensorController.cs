// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
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

        public SystemSensorController(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SensorReference"))
            {
                sensorReference = jObject["SensorReference"]?.GetValue<string>() ?? null;
            }

            return true;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
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
