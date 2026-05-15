// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemMultiChillerItem : SystemObject
    {
        public ModifiableValue Efficiency { get; set; }
        public ModifiableValue CondenserFanLoad { get; set; }
        public double Percentage { get; set; }
        public double Threshold { get; set; }

        public SystemMultiChillerItem()
            : base((string)null)
        {

        }

        public SystemMultiChillerItem(SystemMultiChillerItem systemMultiChillerItem)
            : base(systemMultiChillerItem)
        {
            if(systemMultiChillerItem != null)
            {
                Efficiency = systemMultiChillerItem.Efficiency?.Clone();
                CondenserFanLoad = systemMultiChillerItem.CondenserFanLoad?.Clone();
                Percentage = systemMultiChillerItem.Percentage;
                Threshold = systemMultiChillerItem.Threshold;
            }
        }

        public SystemMultiChillerItem(System.Guid guid, SystemMultiChillerItem systemMultiChillerItem)
            : base(guid, systemMultiChillerItem)
        {
            if (systemMultiChillerItem != null)
            {
                Efficiency = systemMultiChillerItem.Efficiency?.Clone();
                CondenserFanLoad = systemMultiChillerItem.CondenserFanLoad?.Clone();
                Percentage = systemMultiChillerItem.Percentage;
                Threshold = systemMultiChillerItem.Threshold;
            }
        }

        public SystemMultiChillerItem(JsonObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Efficiency"))
            {
                Efficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["Efficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("CondenserFanLoad"))
            {
                CondenserFanLoad = Core.Query.IJSAMObject<ModifiableValue>(jObject["CondenserFanLoad"] as JsonObject);
            }

            if (jObject.ContainsKey("Percentage"))
            {
                Percentage = jObject["Percentage"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Threshold"))
            {
                Threshold = jObject["Threshold"]?.GetValue<double>() ?? default(double);
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

            if (Efficiency != null)
            {
                result.Add("Efficiency", Efficiency.ToJsonObject());
            }

            if (CondenserFanLoad != null)
            {
                result.Add("CondenserFanLoad", CondenserFanLoad.ToJsonObject());
            }

            if (!double.IsNaN(Percentage))
            {
                result.Add("Percentage", Percentage);
            }

            if (!double.IsNaN(Threshold))
            {
                result.Add("Threshold", Threshold);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemMultiChillerItem(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}


