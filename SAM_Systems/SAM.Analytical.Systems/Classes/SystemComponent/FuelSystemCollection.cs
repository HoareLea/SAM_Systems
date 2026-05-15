// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class FuelSystemCollection : SystemCollection<FuelSystem>
    {
        public FuelSystemCollection()
            : base()
        {
        }

        public FuelSystemCollection(string name)
            : base(name)
        {
        }

        public FuelSystemCollection(JsonObject jObject)
            : base(jObject)
        {

        }

        public FuelSystemCollection(FuelSystemCollection fuelSystemCollection)
            : base(fuelSystemCollection)
        {

        }

        public FuelSystemCollection(System.Guid guid, FuelSystemCollection fuelSystemCollection)
            : base(guid, fuelSystemCollection)
        {

        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new FuelSystemCollection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
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

            return result;
        }
    }
}
