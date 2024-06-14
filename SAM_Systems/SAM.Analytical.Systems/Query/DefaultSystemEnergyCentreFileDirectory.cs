namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static string DefaultSystemEnergyCentreFileDirectory()
        {
            return ActiveSetting.Setting.GetValue<string>(AnalyticalSystemSettingParameter.DefaultSystemEnergyCentreFileDirectory);
        }
    }
}
