// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class ScheduleModifier : IndexedSimpleModifier
    {
        public ISchedule Schedule { get; set; }
        public double Setback { get; set; }

        public ScheduleModifier(ArithmeticOperator arithmeticOperator, ISchedule schedule, double setback)
        {
            ArithmeticOperator = arithmeticOperator;
            Schedule = Core.Query.Clone(schedule);
            Setback = setback;
        }

        public ScheduleModifier(ScheduleModifier scheduleModifier)
            : base(scheduleModifier)
        {
            if (scheduleModifier != null)
            {
                Schedule = Core.Query.Clone(scheduleModifier.Schedule);
                Setback = scheduleModifier.Setback;
            }
        }

        public ScheduleModifier(JsonObject jObject)
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

            if (jObject.ContainsKey("Schedule"))
            {
                Schedule = Core.Query.IJSAMObject<ISchedule>(jObject["Schedule"] as JsonObject);
            }

            if (jObject.ContainsKey("Setback"))
            {
                Setback = jObject["Setback"]?.GetValue<double>() ?? default(double);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return null;
            }

            if (Schedule != null)
            {
                result.Add("Schedule", Schedule.ToJsonObject());
            }

            if (!double.IsNaN(Setback))
            {
                result.Add("Setback", Setback);
            }

            return result;
        }

        public override bool ContainsIndex(int index)
        {
            if (Schedule == null)
            {
                return false;
            }

            throw new System.NotImplementedException();
        }

        public override double GetCalculatedValue(int index, double value)
        {
            throw new System.NotImplementedException();
        }
    }
}