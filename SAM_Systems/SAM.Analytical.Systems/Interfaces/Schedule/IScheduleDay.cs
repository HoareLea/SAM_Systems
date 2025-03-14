﻿using SAM.Core.Systems;

namespace SAM.Analytical.Systems
{
    public interface IScheduleDay : ISystemJSAMObject
    {
        string Name { get; }
        double[] Values { get; }
    }
}
