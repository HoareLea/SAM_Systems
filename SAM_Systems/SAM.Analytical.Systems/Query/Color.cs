using SAM.Core;
using System.Drawing;

namespace SAM.Analytical.Systems
{
    public static partial class Query
    {
        public static System.Drawing.Color Color(this System.Type type)
        {
            if (type == null)
            {
                return System.Drawing.Color.Empty;
            }

            switch (type.Name)
            {
                case nameof(DisplayAirSystemGroup):
                    return System.Drawing.Color.FromArgb(255, 0, 0); // Red

                case nameof(DisplayCoolingSystemCollection):
                    return System.Drawing.Color.FromArgb(0, 0, 255); // Blue

                case nameof(DisplayDomesticHotWaterSystemCollection):
                    return System.Drawing.Color.FromArgb(255, 165, 0); // Orange

                case nameof(DisplayElectricalSystemCollection):
                    return System.Drawing.Color.FromArgb(255, 255, 0); // Yellow

                case nameof(DisplayFuelSystemCollection):
                    return System.Drawing.Color.FromArgb(139, 69, 19); // SaddleBrown

                case nameof(DisplayHeatingSystemCollection):
                    return System.Drawing.Color.FromArgb(255, 69, 0); // Red-Orange

                case nameof(DisplayRefrigerantSystemCollection):
                    return System.Drawing.Color.FromArgb(0, 255, 255); // Cyan

                case nameof(DisplaySystemAbsorptionChiller):
                    return System.Drawing.Color.FromArgb(70, 130, 180); // SteelBlue

                case nameof(DisplaySystemAirJunction):
                    return System.Drawing.Color.FromArgb(0, 128, 128); // Teal

                case nameof(DisplaySystemAirSourceChiller):
                    return System.Drawing.Color.FromArgb(100, 149, 237); // CornflowerBlue

                case nameof(DisplaySystemAirSourceDirectAbsorptionChiller):
                    return System.Drawing.Color.FromArgb(72, 61, 139); // DarkSlateBlue

                case nameof(DisplaySystemAirSourceHeatPump):
                    return System.Drawing.Color.FromArgb(123, 104, 238); // MediumSlateBlue

                case nameof(DisplaySystemBoiler):
                    return System.Drawing.Color.FromArgb(178, 34, 34); // Firebrick

                case nameof(DisplaySystemCHP):
                    return System.Drawing.Color.FromArgb(85, 107, 47); // DarkOliveGreen

                case nameof(DisplaySystemCoolingCoil):
                    return System.Drawing.Color.FromArgb(135, 206, 250); // LightSkyBlue

                case nameof(DisplaySystemCoolingTower):
                    return System.Drawing.Color.FromArgb(0, 191, 255); // DeepSkyBlue

                case nameof(DisplaySystemDXCoil):
                    return System.Drawing.Color.FromArgb(30, 144, 255); // DodgerBlue

                case nameof(DisplaySystemDamper):
                    return System.Drawing.Color.FromArgb(169, 169, 169); // DarkGray

                case nameof(DisplaySystemDesiccantWheel):
                    return System.Drawing.Color.FromArgb(186, 85, 211); // MediumOrchid

                case nameof(DisplaySystemDirectEvaporativeCooler):
                    return System.Drawing.Color.FromArgb(175, 238, 238); // PaleTurquoise

                case nameof(DisplaySystemDryCooler):
                    return System.Drawing.Color.FromArgb(95, 158, 160); // CadetBlue

                case nameof(DisplaySystemEconomiser):
                    return System.Drawing.Color.FromArgb(144, 238, 144); // LightGreen

                case nameof(DisplaySystemExchanger):
                    return System.Drawing.Color.FromArgb(255, 215, 0); // Gold

                case nameof(DisplaySystemFan):
                    return System.Drawing.Color.FromArgb(112, 128, 144); // SlateGray

                case nameof(DisplaySystemHeatingCoil):
                    return System.Drawing.Color.FromArgb(255, 99, 71); // Tomato

                case nameof(DisplaySystemHorizontalExchanger):
                    return System.Drawing.Color.FromArgb(210, 180, 140); // Tan

                case nameof(DisplaySystemIceStorageChiller):
                    return System.Drawing.Color.FromArgb(176, 224, 230); // PowderBlue

                case nameof(DisplaySystemLiquidExchanger):
                    return System.Drawing.Color.FromArgb(175, 238, 238); // PaleTurquoise

                case nameof(DisplaySystemLiquidJunction):
                    return System.Drawing.Color.FromArgb(32, 178, 170); // LightSeaGreen

                case nameof(DisplaySystemLoadComponent):
                    return System.Drawing.Color.FromArgb(205, 133, 63); // Peru

                case nameof(DisplaySystemMixingBox):
                    return System.Drawing.Color.FromArgb(255, 160, 122); // LightSalmon

                case nameof(DisplaySystemMultiBoiler):
                    return System.Drawing.Color.FromArgb(178, 34, 34); // Firebrick

                case nameof(DisplaySystemMultiChiller):
                    return System.Drawing.Color.FromArgb(0, 191, 255); // DeepSkyBlue

                case nameof(DisplaySystemPhotovoltaicPanel):
                    return System.Drawing.Color.FromArgb(154, 205, 50); // YellowGreen

                case nameof(DisplaySystemPipeLossComponent):
                    return System.Drawing.Color.FromArgb(105, 105, 105); // DimGray

                case nameof(DisplaySystemPump):
                    return System.Drawing.Color.FromArgb(47, 79, 79); // DarkSlateGray

                case nameof(DisplaySystemSensor):
                    return System.Drawing.Color.FromArgb(240, 230, 140); // Khaki

                case nameof(DisplaySystemSlinkyCoil):
                    return System.Drawing.Color.FromArgb(102, 205, 170); // MediumAquamarine

                case nameof(DisplaySystemSolarPanel):
                    return System.Drawing.Color.FromArgb(255, 223, 0); // Gold

                case nameof(DisplaySystemSpace):
                    return System.Drawing.Color.FromArgb(200, 200, 200); // Light Gray

                case nameof(DisplaySystemSprayHumidifier):
                    return System.Drawing.Color.FromArgb(160, 82, 45); // Sienna

                case nameof(DisplaySystemSteamHumidifier):
                    return System.Drawing.Color.FromArgb(255, 182, 193); // LightPink

                case nameof(DisplaySystemSurfaceWaterExchanger):
                    return System.Drawing.Color.FromArgb(100, 149, 237); // CornflowerBlue

                case nameof(DisplaySystemTank):
                    return System.Drawing.Color.FromArgb(244, 164, 96); // SandyBrown

                case nameof(DisplaySystemValve):
                    return System.Drawing.Color.FromArgb(119, 136, 153); // LightSlateGray

                case nameof(DisplaySystemVerticalBorehole):
                    return System.Drawing.Color.FromArgb(112, 128, 144); // SlateGray

                case nameof(DisplaySystemWaterSourceAbsorptionChiller):
                    return System.Drawing.Color.FromArgb(95, 158, 160); // CadetBlue

                case nameof(DisplaySystemWaterSourceChiller):
                    return System.Drawing.Color.FromArgb(72, 209, 204); // MediumTurquoise

                case nameof(DisplaySystemWaterSourceDirectAbsorptionChiller):
                    return System.Drawing.Color.FromArgb(176, 196, 222); // LightSteelBlue

                case nameof(DisplaySystemWaterSourceHeatPump):
                    return System.Drawing.Color.FromArgb(60, 179, 113); // MediumSeaGreen

                case nameof(DisplaySystemWaterSourceIceStorageChiller):
                    return System.Drawing.Color.FromArgb(175, 238, 238); // PaleTurquoise

                case nameof(DisplaySystemWaterToWaterHeatPump):
                    return System.Drawing.Color.FromArgb(106, 90, 205); // SlateBlue

                case nameof(DisplaySystemWindTurbine):
                    return System.Drawing.Color.FromArgb(106, 90, 205); // SlateBlue

                default:
                    throw new System.NotImplementedException($"Color for {type.Name} is not implemented.");
            }
        }
    }
}
