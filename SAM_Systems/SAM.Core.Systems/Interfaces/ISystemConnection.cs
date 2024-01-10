namespace SAM.Core.Systems
{
    public interface ISystemConnection : ISystemComponent
    {
        SystemType SystemType { get; }

        bool TryGetIndex(ISystemComponent systemComponent, out int index);
    }
}
