using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class UnlimitedDuty : Duty
    {
        public override ModifiableValue ModifiableValue 
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

        public override double GetValue(int index)
        {
            return double.NaN;
        }
    }
}
