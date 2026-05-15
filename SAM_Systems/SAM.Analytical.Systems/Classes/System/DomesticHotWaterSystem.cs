// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class DomesticHotWaterSystem : LiquidSystem
    {
        public DomesticHotWaterSystem(Guid guid, DomesticHotWaterSystem domesticHotWaterSystem)
            : base(guid, domesticHotWaterSystem)
        {
        }

        public DomesticHotWaterSystem(DomesticHotWaterSystem domesticHotWaterSystem) 
            : base(domesticHotWaterSystem)
        {
        }

        public DomesticHotWaterSystem(string name)
            : base(name)
        {
        }

        public DomesticHotWaterSystem(JsonObject jObject)
            : base(jObject)
        {
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            return base.FromJsonObject(jObject);
        }

        public override JsonObject ToJsonObject()
        {
            return base.ToJsonObject();
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new DomesticHotWaterSystem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
