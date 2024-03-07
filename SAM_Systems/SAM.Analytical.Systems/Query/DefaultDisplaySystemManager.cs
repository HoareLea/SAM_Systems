using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static DisplaySystemManager DefaultDisplaySystemManager()
        {
            return ActiveSetting.Setting.GetValue<DisplaySystemManager>(AnalyticalSystemSettingParameter.DefaultDisplaySystemManager);
        }
    }
}
