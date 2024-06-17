using SAM.Core;
using SAM.Geometry.Systems;
using System.Reflection;

namespace SAM.Analytical.Systems
{
    public static partial class ActiveSetting
    {
        public static class Name
        {
            //public const string ParameterMap = "Parameter Map";
        }

        private static Setting setting = Load();

        private static Setting Load()
        {
            Setting setting = ActiveManager.GetSetting(Assembly.GetExecutingAssembly());
            if (setting == null)
                setting = GetDefault();

            return setting;
        }

        public static Setting Setting
        {
            get
            {
                return setting;
            }
        }

        public static Setting GetDefault()
        {
            Setting result = new Setting(Assembly.GetExecutingAssembly());

            result.SetValue(AnalyticalSystemSettingParameter.DefaultDisplaySystemManagerFileName, "SAM_DisplaySystemManager.JSON");
            result.SetValue(AnalyticalSystemSettingParameter.DefaultDisplaySystemManagerFileName, "SAM_DisplaySystemManager.JSON");
            result.SetValue(AnalyticalSystemSettingParameter.DefaultSystemEnergyCentreDirectoryName, "SystemEnergyCentre");

            string path = null;

            path = Query.DefaultPath(result, AnalyticalSystemSettingParameter.DefaultDisplaySystemManagerFileName);
            if (System.IO.File.Exists(path))
            {
                result.SetValue(AnalyticalSystemSettingParameter.DefaultDisplaySystemManager, Core.Create.IJSAMObject<DisplaySystemManager>(System.IO.File.ReadAllText(path)));
            }

            string directory = null;

            directory = Query.DefaultPath(result, AnalyticalSystemSettingParameter.DefaultSystemEnergyCentreDirectoryName);
            if (System.IO.Directory.Exists(directory))
            {
                result.SetValue(AnalyticalSystemSettingParameter.DefaultSystemEnergyCentreFileDirectory, directory);
            }


            return result;
        }
    }
}
