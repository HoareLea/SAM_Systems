using SAM.Core.Systems;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static IndexedDoubles IndexedDoubles(this ISystemComponentResult systemComponentResult, SystemSpaceDataType systemSpaceDataType)
        {
            if (systemComponentResult == null)
            {
                return null;
            }

            SystemIndexedDoublesResult systemIndexedDoublesResult = systemComponentResult as SystemIndexedDoublesResult;
            if (systemIndexedDoublesResult == null)
            {
                return null;
            }

            if (systemComponentResult is SystemChilledBeamResult)
            {
                switch (systemSpaceDataType)
                {
                    case SystemSpaceDataType.Condensation:
                        return systemIndexedDoublesResult[ChilledBeamDataType.Condensation.ToString()];

                    case SystemSpaceDataType.CoolingSensibleLoad:
                        return systemIndexedDoublesResult[ChilledBeamDataType.CoolingSensibleLoad.ToString()];

                    case SystemSpaceDataType.CoolingLatentLoad:
                        return systemIndexedDoublesResult[ChilledBeamDataType.CoolingLatentLoad.ToString()];

                    default:
                        return null;
                }
            }

            if (systemComponentResult is SystemDXCoilUnitResult)
            {
                switch (systemSpaceDataType)
                {
                    case SystemSpaceDataType.Condensation:
                        return systemIndexedDoublesResult[DXCoilUnitDataType.Condensation.ToString()];

                    case SystemSpaceDataType.CoolingSensibleLoad:
                        return systemIndexedDoublesResult[DXCoilUnitDataType.CoolingSensibleLoad.ToString()];

                    case SystemSpaceDataType.CoolingLatentLoad:
                        return systemIndexedDoublesResult[DXCoilUnitDataType.CoolingLatentLoad.ToString()];

                    case SystemSpaceDataType.HeatingLoad:
                        return systemIndexedDoublesResult[DXCoilUnitDataType.HeatingLoad.ToString()];

                    case SystemSpaceDataType.ElectricalLoad:
                        return systemIndexedDoublesResult[DXCoilUnitDataType.ElectricalLoad.ToString()];

                    default:
                        return null;
                }
            }

            if (systemComponentResult is SystemFanCoilUnitResult)
            {
                switch (systemSpaceDataType)
                {
                    case SystemSpaceDataType.Condensation:
                        return systemIndexedDoublesResult[FanCoilUnitDataType.Condensation.ToString()];

                    case SystemSpaceDataType.CoolingSensibleLoad:
                        return systemIndexedDoublesResult[FanCoilUnitDataType.CoolingSensibleLoad.ToString()];

                    case SystemSpaceDataType.CoolingLatentLoad:
                        return systemIndexedDoublesResult[FanCoilUnitDataType.CoolingLatentLoad.ToString()];

                    case SystemSpaceDataType.HeatingLoad:
                        return systemIndexedDoublesResult[FanCoilUnitDataType.HeatingLoad.ToString()];

                    case SystemSpaceDataType.ElectricalLoad:
                        return systemIndexedDoublesResult[FanCoilUnitDataType.ElectricalLoad.ToString()];

                    default:
                        return null;
                }
            }

            if (systemComponentResult is SystemRadiatorResult)
            {
                switch (systemSpaceDataType)
                {
                    case SystemSpaceDataType.HeatingLoad:
                        return systemIndexedDoublesResult[RadiatorDataType.HeatingLoad.ToString()];

                    default:
                        return null;
                }
            }

            return null;
        }
    }
}
