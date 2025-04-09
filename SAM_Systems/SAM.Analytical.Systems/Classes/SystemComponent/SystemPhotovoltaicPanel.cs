using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemPhotovoltaicPanel : SystemComponent
    {
        public ModifiableValue PanelEfficiency { get; set; }
        public ISizableValue InverterSize { get; set; }
        public int Multiplicity { get; set; }
        public ModifiableValue InverterEfficiency { get; set; }
        public bool UseZoneSurface { get; set; }
        public double Area { get; set; }
        public ModifiableValue Inclination { get; set; }
        public ModifiableValue Orientation { get; set; }
        public double Reflectance { get; set; }
        public double MinIrradiance { get; set; }
        public double NOCT { get; set; }
        public double PowerTemperatureCoefficient { get; set; }
        public bool UseSTC { get; set; }
        public double OutputAtSTC { get; set; }
        public double DeratingFactor { get; set; }

        public SystemPhotovoltaicPanel(string name)
            : base(name)
        {

        }

        public SystemPhotovoltaicPanel(SystemPhotovoltaicPanel systemPhotovoltaicPanel)
            : base(systemPhotovoltaicPanel)
        {
            if(systemPhotovoltaicPanel != null)
            {
                PanelEfficiency = systemPhotovoltaicPanel.PanelEfficiency?.Clone();
                InverterSize = systemPhotovoltaicPanel.InverterSize?.Clone();
                Multiplicity = systemPhotovoltaicPanel.Multiplicity;
                InverterEfficiency = systemPhotovoltaicPanel?.InverterEfficiency?.Clone();
                UseZoneSurface = systemPhotovoltaicPanel.UseZoneSurface;
                Area = systemPhotovoltaicPanel.Area;
                Inclination = systemPhotovoltaicPanel.Inclination?.Clone();
                Orientation = systemPhotovoltaicPanel.Orientation?.Clone();
                Reflectance = systemPhotovoltaicPanel.Reflectance;
                MinIrradiance = systemPhotovoltaicPanel.MinIrradiance;
                NOCT = systemPhotovoltaicPanel.NOCT;
                PowerTemperatureCoefficient = systemPhotovoltaicPanel.PowerTemperatureCoefficient;
                UseSTC = systemPhotovoltaicPanel.UseSTC;
                OutputAtSTC = systemPhotovoltaicPanel.OutputAtSTC;
                DeratingFactor = systemPhotovoltaicPanel.DeratingFactor;
            }
        }

        public SystemPhotovoltaicPanel(System.Guid guid, SystemPhotovoltaicPanel systemPhotovoltaicPanel)
            : base(guid, systemPhotovoltaicPanel)
        {
            if (systemPhotovoltaicPanel != null)
            {
                PanelEfficiency = systemPhotovoltaicPanel.PanelEfficiency?.Clone();
                InverterSize = systemPhotovoltaicPanel.InverterSize?.Clone();
                Multiplicity = systemPhotovoltaicPanel.Multiplicity;
                InverterEfficiency = systemPhotovoltaicPanel?.InverterEfficiency?.Clone();
                UseZoneSurface = systemPhotovoltaicPanel.UseZoneSurface;
                Area = systemPhotovoltaicPanel.Area;
                Inclination = systemPhotovoltaicPanel.Inclination?.Clone();
                Orientation = systemPhotovoltaicPanel.Orientation?.Clone();
                Reflectance = systemPhotovoltaicPanel.Reflectance;
                MinIrradiance = systemPhotovoltaicPanel.MinIrradiance;
                NOCT = systemPhotovoltaicPanel.NOCT;
                PowerTemperatureCoefficient = systemPhotovoltaicPanel.PowerTemperatureCoefficient;
                UseSTC = systemPhotovoltaicPanel.UseSTC;
                OutputAtSTC = systemPhotovoltaicPanel.OutputAtSTC;
                DeratingFactor = systemPhotovoltaicPanel.DeratingFactor;
            }
        }

        public SystemPhotovoltaicPanel(JObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    //Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.In, 1),
                    //Core.Systems.Create.SystemConnector<LiquidSystem>(Core.Direction.Out, 1),
                    //Core.Systems.Create.SystemConnector<IControlSystem>()
                );
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("PanelEfficiency"))
            {
                PanelEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("PanelEfficiency"));
            }

            if (jObject.ContainsKey("InverterSize"))
            {
                InverterSize = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("InverterSize"));
            }

            if (jObject.ContainsKey("Multiplicity"))
            {
                Multiplicity = jObject.Value<int>("Multiplicity");
            }

            if (jObject.ContainsKey("InverterEfficiency"))
            {
                InverterEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("InverterEfficiency"));
            }

            if (jObject.ContainsKey("UseZoneSurface"))
            {
                UseZoneSurface = jObject.Value<bool>("UseZoneSurface");
            }

            if (jObject.ContainsKey("Area"))
            {
                Area = jObject.Value<double>("Area");
            }

            if (jObject.ContainsKey("Inclination"))
            {
                Inclination = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Inclination"));
            }

            if (jObject.ContainsKey("Orientation"))
            {
                Orientation = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Orientation"));
            }

            if (jObject.ContainsKey("Reflectance"))
            {
                Reflectance = jObject.Value<double>("Reflectance");
            }

            if (jObject.ContainsKey("MinIrradiance"))
            {
                MinIrradiance = jObject.Value<double>("MinIrradiance");
            }

            if (jObject.ContainsKey("NOCT"))
            {
                NOCT = jObject.Value<double>("NOCT");
            }

            if (jObject.ContainsKey("PowerTemperatureCoefficient"))
            {
                PowerTemperatureCoefficient = jObject.Value<double>("PowerTemperatureCoefficient");
            }

            if (jObject.ContainsKey("UseSTC"))
            {
                UseSTC = jObject.Value<bool>("UseSTC");
            }

            if (jObject.ContainsKey("OutputAtSTC"))
            {
                OutputAtSTC = jObject.Value<double>("OutputAtSTC");
            }

            if (jObject.ContainsKey("DeratingFactor"))
            {
                DeratingFactor = jObject.Value<double>("DeratingFactor");
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return result;
            }

            if (PanelEfficiency != null)
            {
                result.Add("PanelEfficiency", PanelEfficiency.ToJObject());
            }

            if (InverterSize != null)
            {
                result.Add("InverterSize", InverterSize.ToJObject());
            }

            result.Add("Multiplicity", Multiplicity);

            if (InverterEfficiency != null)
            {
                result.Add("InverterEfficiency", InverterEfficiency.ToJObject());
            }

            result.Add("UseZoneSurface", UseZoneSurface);

            if (!double.IsNaN(Area))
            {
                result.Add("Area", Area);
            }

            if (Inclination != null)
            {
                result.Add("Inclination", Inclination.ToJObject());
            }

            if (Orientation != null)
            {
                result.Add("Orientation", Orientation.ToJObject());
            }

            if (!double.IsNaN(Reflectance))
            {
                result.Add("Reflectance", Reflectance);
            }

            if (!double.IsNaN(MinIrradiance))
            {
                result.Add("MinIrradiance", MinIrradiance);
            }

            if (!double.IsNaN(NOCT))
            {
                result.Add("NOCT", NOCT);
            }

            if (!double.IsNaN(PowerTemperatureCoefficient))
            {
                result.Add("PowerTemperatureCoefficient", PowerTemperatureCoefficient);
            }

            result.Add("UseSTC", UseSTC);

            if (!double.IsNaN(OutputAtSTC))
            {
                result.Add("OutputAtSTC", OutputAtSTC);
            }

            if (!double.IsNaN(DeratingFactor))
            {
                result.Add("DeratingFactor", DeratingFactor);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemPhotovoltaicPanel(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}