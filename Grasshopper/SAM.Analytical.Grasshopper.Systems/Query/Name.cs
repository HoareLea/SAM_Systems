namespace SAM.Analytical.Grasshopper.Systems
{
    public static partial class Query
    {

        public static string Name(LineCategory lineCategory)
        {
            switch(lineCategory)
            {
                case LineCategory.Control:
                    return "Tas-Control";

                case LineCategory.Sensor:
                    return "Tas-Signal";
            }

            return null;
        }
    }
}
