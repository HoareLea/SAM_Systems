// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemSpaceResult : SystemIndexedDoublesResult, ISystemSpaceResult
    {
        private double area;
        private double volume;

        public SystemSpaceResult(JsonObject jObject)
            : base(jObject)
        {
            FromJsonObject(jObject);
        }

        public SystemSpaceResult(SystemSpaceResult spaceSystemResult)
            : base(spaceSystemResult)
        {
            if (spaceSystemResult != null)
            {
                area = spaceSystemResult.area;
                volume = spaceSystemResult.volume;
            }
        }

        public SystemSpaceResult(string uniqueId, string name, string source, double area, double volume, Dictionary<SpaceDataType, IndexedDoubles> dictionary)
            : base(uniqueId, name, source, Core.Systems.Query.Dictionary(dictionary))
        {
            this.area = area;
            this.volume = volume;
        }

        public double Area
        {
            get
            {
                return area;
            }
        }

        public double Volume
        {
            get
            {
                return volume;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Area"))
            {
                area = jObject["Area"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Volume"))
            {
                volume = jObject["Volume"]?.GetValue<double>() ?? default(double);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject jObject = base.ToJsonObject();
            if (jObject == null)
            {
                return null;
            }

            if (double.IsNaN(area))
            {
                jObject.Add("Area", area);
            }

            if (double.IsNaN(volume))
            {
                jObject.Add("Volume", volume);
            }

            return jObject;
        }
    }
}
