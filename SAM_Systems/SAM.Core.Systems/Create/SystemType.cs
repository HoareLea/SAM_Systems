namespace SAM.Core.Systems
{
    public static partial class Create
    {
        public static SystemType SystemType<T>() where T : ISystem
        {
            return new SystemType(typeof(T));
        }
    }
}