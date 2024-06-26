﻿using SAM.Core.Attributes;
using SAM.Core;
using System.ComponentModel;
using SAM.Geometry.Systems;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(Setting)), Description("Analytical System Setting Parameter")]
    public enum AnalyticalSystemSettingParameter
    {
        [ParameterProperties("Default DisplaySystemManager File Name", "Default DisplaySystemManager File Name"), ParameterValue(ParameterType.String)] DefaultDisplaySystemManagerFileName,

        [ParameterProperties("Default DisplaySystemManager", "Default DisplaySystemManager"), SAMObjectParameterValue(typeof(DisplaySystemManager))] DefaultDisplaySystemManager,

        [ParameterProperties("Default SystemEnergyCentre File Directory", "Default SystemEnergyCentre File Directory"), ParameterValue(ParameterType.String)] DefaultSystemEnergyCentreFileDirectory,

        [ParameterProperties("Default SystemEnergyCentre Directory Name", "Default SystemEnergyCentre Directory Name"), ParameterValue(ParameterType.String)] DefaultSystemEnergyCentreDirectoryName,
    }
}
