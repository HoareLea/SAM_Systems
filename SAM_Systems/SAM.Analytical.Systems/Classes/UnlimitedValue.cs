using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class UnlimitedValue : SizableValue
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

        public UnlimitedValue()
        {
        }

        public UnlimitedValue(UnlimitedValue unlimitedValue)
            :base(unlimitedValue)
        {
        }

        public UnlimitedValue(JObject jObject)
            :base(jObject)
        {

        }

        public override double GetValue(int index)
        {
            return double.NaN;
        }
    }
}
