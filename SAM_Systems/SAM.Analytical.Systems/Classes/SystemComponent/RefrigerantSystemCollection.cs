// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class RefrigerantSystemCollection : SystemCollection<LiquidSystem>
    {
        public ModifiableValue PipeLength { get; set; }

        public RefrigerantSystemCollection()
            : base()
        {
        }

        public RefrigerantSystemCollection(string name)
            : base(name)
        {
        }

        public RefrigerantSystemCollection(JsonObject jObject)
            : base(jObject)
        {

        }

        public RefrigerantSystemCollection(RefrigerantSystemCollection refrigerantSystemCollection)
            : base(refrigerantSystemCollection)
        {
            if(refrigerantSystemCollection != null)
            {
                PipeLength = refrigerantSystemCollection.PipeLength?.Clone();
            }
        }

        public RefrigerantSystemCollection(System.Guid guid, RefrigerantSystemCollection refrigerantSystemCollection)
            : base(guid, refrigerantSystemCollection)
        {
            if (refrigerantSystemCollection != null)
            {
                PipeLength = refrigerantSystemCollection.PipeLength?.Clone();
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if(jObject.ContainsKey("PipeLength"))
            {
                PipeLength = Core.Query.IJSAMObject<ModifiableValue>(jObject["PipeLength"] as JsonObject);
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

            if(PipeLength != null)
            {
                result.Add("PipeLength", PipeLength.ToJsonObject());
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new RefrigerantSystemCollection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
