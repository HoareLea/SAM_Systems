namespace SAM.Core.Systems
{
    public interface ISystemDifferenceController : ISystemSensorController
    {
        string SecondarySensorReference { get; set; }
    }
}
