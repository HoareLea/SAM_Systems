// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class CoolingSystemCollection : SystemCollection<CoolingSystem>
    {
        public double MaximumReturnTemperature { get; set; }
        public bool VariableFlowCapacity { get; set; }
        public double PeakDemand { get; set; }
        public double SizeFraction { get; set; }
        public Distribution Distribution { get; set; }
        public double DesignPressureDrop { get; set; }
        public double DesignTemperatureDifference { get; set; }


        public CoolingSystemCollection()
            : base()
        {
        }

        public CoolingSystemCollection(string name)
            : base(name)
        {
        }

        public CoolingSystemCollection(JsonObject jObject)
            : base(jObject)
        {

        }

        public CoolingSystemCollection(CoolingSystemCollection coolingSystemCollection)
            : base(coolingSystemCollection)
        {
            if(coolingSystemCollection != null)
            {
                MaximumReturnTemperature = coolingSystemCollection.MaximumReturnTemperature;
                VariableFlowCapacity = coolingSystemCollection.VariableFlowCapacity;
                PeakDemand = coolingSystemCollection.PeakDemand;
                SizeFraction = coolingSystemCollection.SizeFraction;
                Distribution = coolingSystemCollection.Distribution?.Clone();
                DesignPressureDrop = coolingSystemCollection.DesignPressureDrop;
                DesignTemperatureDifference = coolingSystemCollection.DesignTemperatureDifference;
            }
        }

        public CoolingSystemCollection(System.Guid guid, CoolingSystemCollection coolingSystemCollection)
            : base(guid, coolingSystemCollection)
        {
            if (coolingSystemCollection != null)
            {
                MaximumReturnTemperature = coolingSystemCollection.MaximumReturnTemperature;
                VariableFlowCapacity = coolingSystemCollection.VariableFlowCapacity;
                PeakDemand = coolingSystemCollection.PeakDemand;
                SizeFraction = coolingSystemCollection.SizeFraction;
                Distribution = coolingSystemCollection.Distribution?.Clone();
                DesignPressureDrop = coolingSystemCollection.DesignPressureDrop;
                DesignTemperatureDifference = coolingSystemCollection.DesignTemperatureDifference;
            }
        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("MaximumReturnTemperature"))
            {
                MaximumReturnTemperature = jObject["MaximumReturnTemperature"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("VariableFlowCapacity"))
            {
                VariableFlowCapacity = jObject["VariableFlowCapacity"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("PeakDemand"))
            {
                PeakDemand = jObject["PeakDemand"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("SizeFraction"))
            {
                SizeFraction = jObject["SizeFraction"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Distribution"))
            {
                Distribution = Core.Query.IJSAMObject<Distribution>(jObject["Distribution"] as JsonObject);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject["DesignTemperatureDifference"]?.GetValue<double>() ?? default(double);
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

            if (!double.IsNaN(MaximumReturnTemperature))
            {
                result.Add("MaximumReturnTemperature", MaximumReturnTemperature);
            }

            result.Add("VariableFlowCapacity", VariableFlowCapacity);

            if (!double.IsNaN(PeakDemand))
            {
                result.Add("PeakDemand", PeakDemand);
            }

            if (!double.IsNaN(SizeFraction))
            {
                result.Add("SizeFraction", SizeFraction);
            }

            if (Distribution != null)
            {
                result.Add("Distribution", Distribution.ToJsonObject());
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new CoolingSystemCollection(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
