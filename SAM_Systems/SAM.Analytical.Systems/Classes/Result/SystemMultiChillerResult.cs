// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemMultiChillerResult : SystemIndexedDoublesResult, ISystemComponentResult
    {
        public SystemMultiChillerResult(string uniqueId, string name, string source, Dictionary<MultiChillerDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
        }

        public SystemMultiChillerResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemMultiChillerResult(SystemMultiChillerResult systemMultiChillerResult)
            : base(systemMultiChillerResult)
        {

        }
    }
}
