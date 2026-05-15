// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemDifferenceController : SystemNormalController, ISystemDifferenceController
    {
        private string secondarySensorReference;

        public SystemDifferenceController(string name, NormalControllerDataType normalControllerDataType, ISetpoint setpoint, ISetback setback, NormalControllerLimit normalControllerLimit)
            : base(name, normalControllerDataType, setpoint, setback, normalControllerLimit)
        {

        }

        public SystemDifferenceController(string name, string sensorReference, string secondarySensorReference, NormalControllerDataType normalControllerDataType, ISetpoint setpoint, ISetback setback, NormalControllerLimit normalControllerLimit)
            : base(name, sensorReference, normalControllerDataType, setpoint, setback, normalControllerLimit)
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

        public SystemDifferenceController(Guid guid, SystemDifferenceController systemDifferenceController)
            : base(guid, systemDifferenceController)
        {
            if (systemDifferenceController != null)
            {
                secondarySensorReference = systemDifferenceController.secondarySensorReference;
            }
        }

        public SystemDifferenceController(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("SecondarySensorReference"))
            {
                secondarySensorReference = jObject["SecondarySensorReference"]?.GetValue<string>() ?? null;
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

            if (secondarySensorReference != null)
            {
                result.Add("SecondarySensorReference", secondarySensorReference);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemDifferenceController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
