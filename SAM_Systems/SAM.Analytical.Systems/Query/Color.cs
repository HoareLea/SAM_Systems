using SAM.Core;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static System.Drawing.Color Color(this System.Type type)
        {
            if(type == null)
            {
                return System.Drawing.Color.Empty;
            }

            return Core.Create.Color();
        }
    }
}
