using SAM.Core.Systems;
using System.Collections.Generic;
using System.IO;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static List<SystemEnergyCentre> DefaultSystemEnergyCentres()
        {
            string directory = ActiveSetting.Setting.GetValue<string>(AnalyticalSystemSettingParameter.DefaultSystemEnergyCentreFileDirectory);
            if(!Directory.Exists(directory))
            {
                return null;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.json");

            List<SystemEnergyCentre> result = new List<SystemEnergyCentre>(); 
            foreach (FileInfo fileInfo in fileInfos)
            {
                List<SystemEnergyCentre> systemEnergyCentres = Core.Convert.ToSAM<SystemEnergyCentre>(fileInfo.FullName);
                if(systemEnergyCentres == null || systemEnergyCentres.Count == 0)
                {
                    continue;
                }

                result.AddRange(systemEnergyCentres);

            }

            return result;
        }
    }
}
