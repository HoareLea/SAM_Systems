﻿using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemSpaceResult : SystemIndexedDoublesResult, ISystemSpaceResult
    {
        private double area;
        private double volume;

        public SystemSpaceResult(JObject jObject)
            : base(jObject)
        {
            FromJObject(jObject);
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Area"))
            {
                area = jObject.Value<double>("Area");
            }

            if (jObject.ContainsKey("Volume"))
            {
                volume = jObject.Value<double>("Volume");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject jObject = base.ToJObject();
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
