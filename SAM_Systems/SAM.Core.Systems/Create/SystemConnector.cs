namespace SAM.Core.Systems
{
    public static partial class Create
    {
        public static SystemConnector SystemConnector<T>() where T : ISystem
        {
            return SystemConnector<T>(Direction.Undefined);
        }

        public static SystemConnector SystemConnector<T>(Direction direction) where T : ISystem
        {
            return new SystemConnector(new SystemType(typeof(T)), direction);
        }
    }
}