using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public static partial class Create
    {
        public static SystemType SystemType(this AnalyticalSystemType analyticalSystemType)
        {
            if(analyticalSystemType == AnalyticalSystemType.Undefined)
            {
                return null;
            }

            switch(analyticalSystemType)
            {
                case AnalyticalSystemType.AirSystem:
                    return new SystemType(typeof(AirSystem));

                case AnalyticalSystemType.ControlSystem:
                    return new SystemType(typeof(ControlSystem));

                case AnalyticalSystemType.CoolingSystem:
                    return new SystemType(typeof(CoolingSystem));

                case AnalyticalSystemType.ElectricalSystem:
                    return new SystemType(typeof(ElectricalSystem));

                case AnalyticalSystemType.HeatingSystem:
                    return new SystemType(typeof(HeatingSystem));

                case AnalyticalSystemType.RefrigerantSystem:
                    return new SystemType(typeof(RefrigerantSystem));

                case AnalyticalSystemType.LiquidSystem:
                    return new SystemType(typeof(LiquidSystem));
            }

            return null;
        }
    }
}