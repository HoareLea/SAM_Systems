// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemLiquidNormalController : SystemSetpointController
    {
        private LiquidNormalControllerDataType liquidNormalControllerDataType;

        public SystemLiquidNormalController(string name, LiquidNormalControllerDataType liquidNormalControllerDataType, ISetpoint setpoint, ISetback setback)
            : base(name, setpoint, setback)
        {
            this.liquidNormalControllerDataType = liquidNormalControllerDataType;
        }

        public SystemLiquidNormalController(string name, string sensorReference, LiquidNormalControllerDataType liquidNormalControllerDataType, ISetpoint setpoint, ISetback setback)
            : base(name, sensorReference, setpoint, setback)
        {
            this.liquidNormalControllerDataType = liquidNormalControllerDataType;
        }

        public SystemLiquidNormalController(string name)
            :base(name)
        {

        }

        public SystemLiquidNormalController(SystemLiquidNormalController systemLiquidNormalController)
            : base(systemLiquidNormalController)
        {
            if(systemLiquidNormalController != null)
            {
                liquidNormalControllerDataType = systemLiquidNormalController.liquidNormalControllerDataType;
            }
        }

        public SystemLiquidNormalController(System.Guid guid, SystemLiquidNormalController systemLiquidNormalController)
            : base(guid, systemLiquidNormalController)
        {
            if (systemLiquidNormalController != null)
            {
                liquidNormalControllerDataType = systemLiquidNormalController.liquidNormalControllerDataType;
            }
        }

        public SystemLiquidNormalController(JsonObject jObject)
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

        public LiquidNormalControllerDataType LiquidNormalControllerDataType
        {
            get
            {
                return liquidNormalControllerDataType;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("LiquidNormalControllerDataType"))
            {
                Core.Query.TryGetEnum(jObject["LiquidNormalControllerDataType"]?.GetValue<string>() ?? null, out liquidNormalControllerDataType);
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

            result.Add("LiquidNormalControllerDataType", liquidNormalControllerDataType.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemLiquidNormalController(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
