// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemNormalController : SystemSetpointController
    {
        private NormalControllerDataType normalControllerDataType;
        private NormalControllerLimit normalControllerLimit;

        public SystemNormalController(string name, NormalControllerDataType normalControllerDataType, ISetpoint setpoint, ISetback setback, NormalControllerLimit normalControllerLimit)
            : base(name, setpoint, setback)
        {
            this.normalControllerDataType = normalControllerDataType;
            this.normalControllerLimit = normalControllerLimit; 
        }

        public SystemNormalController(string name, string sensorReference, NormalControllerDataType normalControllerDataType, ISetpoint setpoint, ISetback setback, NormalControllerLimit normalControllerLimit)
            : base(name, sensorReference, setpoint, setback)
        {
            this.normalControllerDataType = normalControllerDataType;
            this.normalControllerLimit = normalControllerLimit;
        }

        public SystemNormalController(string name)
            :base(name)
        {

        }

        public SystemNormalController(SystemNormalController systemNormalController)
            : base(systemNormalController)
        {
            if(systemNormalController != null)
            {
                normalControllerDataType = systemNormalController.normalControllerDataType;
                normalControllerLimit = systemNormalController.normalControllerLimit;
            }
        }

        public SystemNormalController(System.Guid guid, SystemNormalController systemNormalController)
            : base(guid, systemNormalController)
        {
            if (systemNormalController != null)
            {
                normalControllerDataType = systemNormalController.normalControllerDataType;
                normalControllerLimit = systemNormalController.normalControllerLimit;
            }
        }

        public SystemNormalController(JsonObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.In),
                    Core.Systems.Create.SystemConnector<IControlSystem>(Core.Direction.Out)
                );
            }
        }

        public NormalControllerDataType NormalControllerDataType
        {
            get
            {
                return normalControllerDataType;
            }
        }

        public NormalControllerLimit NormalControllerLimit
        {
            get
            {
                return normalControllerLimit;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("NormalControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject["NormalControllerDataType"]?.GetValue<string>() ?? null, out normalControllerDataType);
            }

            if (jObject.ContainsKey("NormalControllerLimit"))
            {
                Core.Query.TryGetEnum(jObject["NormalControllerLimit"]?.GetValue<string>() ?? null, out normalControllerLimit);
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

            result.Add("NormalControllerDataType", normalControllerDataType.ToString());

            result.Add("NormalControllerLimit", normalControllerLimit.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemNormalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
