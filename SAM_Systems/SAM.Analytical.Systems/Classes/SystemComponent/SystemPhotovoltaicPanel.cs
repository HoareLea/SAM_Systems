// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
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

        public SystemPhotovoltaicPanel(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("PanelEfficiency"))
            {
                PanelEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["PanelEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("InverterSize"))
            {
                InverterSize = Core.Query.IJSAMObject<SizableValue>(jObject["InverterSize"] as JsonObject);
            }

            if (jObject.ContainsKey("Multiplicity"))
            {
                Multiplicity = jObject["Multiplicity"]?.GetValue<int>() ?? default(int);
            }

            if (jObject.ContainsKey("InverterEfficiency"))
            {
                InverterEfficiency = Core.Query.IJSAMObject<ModifiableValue>(jObject["InverterEfficiency"] as JsonObject);
            }

            if (jObject.ContainsKey("UseZoneSurface"))
            {
                UseZoneSurface = jObject["UseZoneSurface"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("Area"))
            {
                Area = jObject["Area"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Inclination"))
            {
                Inclination = Core.Query.IJSAMObject<ModifiableValue>(jObject["Inclination"] as JsonObject);
            }

            if (jObject.ContainsKey("Orientation"))
            {
                Orientation = Core.Query.IJSAMObject<ModifiableValue>(jObject["Orientation"] as JsonObject);
            }

            if (jObject.ContainsKey("Reflectance"))
            {
                Reflectance = jObject["Reflectance"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("MinIrradiance"))
            {
                MinIrradiance = jObject["MinIrradiance"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("NOCT"))
            {
                NOCT = jObject["NOCT"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("PowerTemperatureCoefficient"))
            {
                PowerTemperatureCoefficient = jObject["PowerTemperatureCoefficient"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("UseSTC"))
            {
                UseSTC = jObject["UseSTC"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("OutputAtSTC"))
            {
                OutputAtSTC = jObject["OutputAtSTC"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DeratingFactor"))
            {
                DeratingFactor = jObject["DeratingFactor"]?.GetValue<double>() ?? default(double);
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if (result == null)
            {
                return result;
            }

            if (PanelEfficiency != null)
            {
                result.Add("PanelEfficiency", PanelEfficiency.ToJsonObject());
            }

            if (InverterSize != null)
            {
                result.Add("InverterSize", InverterSize.ToJsonObject());
            }

            result.Add("Multiplicity", Multiplicity);

            if (InverterEfficiency != null)
            {
                result.Add("InverterEfficiency", InverterEfficiency.ToJsonObject());
            }

            result.Add("UseZoneSurface", UseZoneSurface);

            if (!double.IsNaN(Area))
            {
                result.Add("Area", Area);
            }

            if (Inclination != null)
            {
                result.Add("Inclination", Inclination.ToJsonObject());
            }

            if (Orientation != null)
            {
                result.Add("Orientation", Orientation.ToJsonObject());
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