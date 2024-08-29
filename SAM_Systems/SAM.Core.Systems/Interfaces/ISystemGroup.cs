namespace SAM.Core.Systems
{
    public interface ISystemGroup : ISystemJSAMObject
    {
        bool IsValid(ISystemComponent systemComponent);

        SystemType SystemType { get; }
    }
}
