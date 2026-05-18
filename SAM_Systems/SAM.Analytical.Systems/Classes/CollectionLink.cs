// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public class CollectionLink : ISystemJSAMObject
    {
        private CollectionType collectionType;
        private string name;

        public CollectionLink()
        {
        }

        public CollectionLink(CollectionType collectionType, string name)
        {
            this.collectionType = collectionType;
            this.name = name;
        }

        public CollectionLink(CollectionLink collectionLink)
        {
            if(collectionLink != null)
            {
                collectionType = collectionLink.collectionType;
                name = collectionLink.name;
            }
        }

        public CollectionLink(JsonObject jObject)
        {
            FromJsonObject(jObject);
        }

        public CollectionType CollectionType
        {
            get
            {
                return collectionType;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
        
        public virtual bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("CollectionType"))
            {
                collectionType = Core.Query.Enum<CollectionType>(jObject["CollectionType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("Name"))
            {
                name = jObject["Name"]?.GetValue<string>() ?? null;
            }

            return true;
        }

        public virtual JsonObject ToJsonObject()
        {
            JsonObject result = new JsonObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if(name != null)
            {
                result.Add("Name", name);
            }

            result.Add("CollectionType", collectionType.ToString());

            return result;
        }
    }
}
