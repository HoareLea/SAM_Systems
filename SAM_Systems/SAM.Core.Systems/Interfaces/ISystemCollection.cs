namespace SAM.Core.Systems
{
    public interface ISystemCollection : ISystemComponent
    {
        bool IsValid(ISystemComponent systemComponent);

        SystemType SystemType { get; }
    }
}
