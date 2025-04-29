namespace SAM.Core.Systems
{
    public interface ISystemSensorController : ISystemController
    {
        string SensorReference { get; set; }
    }
}
