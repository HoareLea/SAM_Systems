using Newtonsoft.Json.Linq;

namespace SAM.Analytical.Systems
{
    public class UnlimitedDuty : Duty
    {
        public override double Value 
        { 
            get
            {
                return double.NaN;
            }
            
            set
            {
                return;
            }
        }

        public UnlimitedDuty()
        {
        }

        public UnlimitedDuty(UnlimitedDuty unlimitedDuty)
            :base(unlimitedDuty)
        {
        }

        public UnlimitedDuty(JObject jObject)
            :base(jObject)
        {

        }
    }
}
