// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class ElectricalSystemCollection : SystemCollection<ElectricalSystem>
    {
        private ElectricalSystemCollectionType electricalSystemCollectionType = ElectricalSystemCollectionType.None;

        public ElectricalSystemCollection()
            : base()
        {
        }

        public ElectricalSystemCollection(string name, ElectricalSystemCollectionType electricalSystemCollectionType)
            : base(name)
        {
            this.electricalSystemCollectionType = electricalSystemCollectionType;
        }

        public ElectricalSystemCollection(JsonObject jObject)
            : base(jObject)
        {

        }

        public ElectricalSystemCollection(ElectricalSystemCollection electricalSystemCollection)
            : base(electricalSystemCollection)
        {
            if(electricalSystemCollection != null)
            {
                electricalSystemCollectionType = electricalSystemCollection.electricalSystemCollectionType;
            }
        }

        public ElectricalSystemCollection(System.Guid guid, ElectricalSystemCollection electricalSystemCollection)
            : base(guid, electricalSystemCollection)
        {
            if (electricalSystemCollection != null)
            {
                electricalSystemCollectionType = electricalSystemCollection.electricalSystemCollectionType;
            }
        }

        public ElectricalSystemCollectionType ElectricalSystemCollectionType
        {
            get
            {
                return electricalSystemCollectionType;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("ElectricalSystemCollectionType"))
            {
                electricalSystemCollectionType = Core.Query.Enum<ElectricalSystemCollectionType>(jObject["ElectricalSystemCollectionType"]?.GetValue<string>() ?? null);
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

            result.Add("ElectricalSystemCollectionType", electricalSystemCollectionType.ToString());

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new ElectricalSystemCollection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}

