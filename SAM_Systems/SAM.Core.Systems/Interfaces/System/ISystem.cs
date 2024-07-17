namespace SAM.Core.Systems
{
    public interface ISystem : ISystemJSAMObject
    {
        System.Guid Guid { get; }
    }
}
