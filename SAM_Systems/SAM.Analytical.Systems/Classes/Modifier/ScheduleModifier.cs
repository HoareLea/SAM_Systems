using Newtonsoft.Json.Linq;
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

        public ScheduleModifier(JObject jObject)
            : base(jObject)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("Schedule"))
            {
                Schedule = Core.Query.IJSAMObject<ISchedule>(jObject.Value<JObject>("Schedule"));
            }

            if (jObject.ContainsKey("Setback"))
            {
                Setback = jObject.Value<double>("Setback");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (Schedule != null)
            {
                result.Add("Schedule", Schedule.ToJObject());
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