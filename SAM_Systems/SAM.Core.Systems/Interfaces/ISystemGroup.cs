namespace SAM.Core.Systems
{
    public interface ISystemGroup : ISystemComponent
    {
        bool IsValid(ISystemComponent systemComponent);
    }
}
