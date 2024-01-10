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

        public static SystemConnector SystemConnector<T>(Direction direction, int connectionIndex)
        {
            return new SystemConnector(new SystemType(typeof(T)), direction, connectionIndex);
        }

        public static SystemConnector SystemConnector(System.Type type)
        {
            if(type == null || !type.IsAssignableFrom(typeof(ISystem)))
            {
                return null;
            }

            return SystemConnector(Direction.Undefined, type);
        }

        public static SystemConnector SystemConnector(Direction direction, System.Type type)
        {
            if (type == null || !type.IsAssignableFrom(typeof(ISystem)))
            {
                return null;
            }

            return new SystemConnector(new SystemType(type), direction);
        }
    }
}