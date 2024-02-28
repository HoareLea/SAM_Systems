namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static System.Type Type(this AnalyticalSystemComponentType analyticalSystemComponentType)
        {
            if(analyticalSystemComponentType == AnalyticalSystemComponentType.Undefined)
            {
                return null;
            }

            switch(analyticalSystemComponentType)
            {
                case AnalyticalSystemComponentType.SystemFan:
                    return typeof(SystemFan);

                case AnalyticalSystemComponentType.SystemCoolingCoil:
                    return typeof(SystemCoolingCoil);

                case AnalyticalSystemComponentType.SystemHeatingCoil:
                    return typeof(SystemHeatingCoil);
            }

            return null;
        }
    }
}
