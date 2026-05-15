// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core;
using SAM.Core.Systems;
using System;

namespace SAM.Analytical.Systems
{
    public class SystemSolarPanel : SystemComponent
    {
        public double EtaZero { get; set; }
        public double AlphaOne { get; set; }
        public double AlphaTwo { get; set; }
        public int Multiplicity { get; set; }
        public double Capacity { get; set; }
        public double DesignPressureDrop { get; set; }
        public bool NoNegativeLoad { get; set; }
        public bool UseZoneSurface { get; set; }
        public double SweptArea { get; set; }
        public ModifiableValue Inclination { get; set; }
        public ModifiableValue Orientation { get; set; }
        public double Reflectance { get; set; }
        public double DesignFlowPerM2 { get; set; }

        public SystemSolarPanel(string name)
            : base(name)
        {

        }

        public SystemSolarPanel(SystemSolarPanel systemSolarPanel)
            : base(systemSolarPanel)
        {
            if(systemSolarPanel != null)
            {
                EtaZero = systemSolarPanel.EtaZero;
                AlphaOne = systemSolarPanel.AlphaOne;
                AlphaTwo = systemSolarPanel.AlphaTwo;
                Multiplicity = systemSolarPanel.Multiplicity;
                Capacity = systemSolarPanel.Capacity;
                DesignPressureDrop = systemSolarPanel.DesignPressureDrop;
                NoNegativeLoad = systemSolarPanel.NoNegativeLoad;
                UseZoneSurface = systemSolarPanel.UseZoneSurface;
                SweptArea = systemSolarPanel.SweptArea;
                Inclination = systemSolarPanel.Inclination?.Clone();
                Orientation = systemSolarPanel.Orientation?.Clone();
                Reflectance = systemSolarPanel.Reflectance;
                DesignFlowPerM2 = systemSolarPanel.DesignFlowPerM2;
            }
        }

        public SystemSolarPanel(System.Guid guid, SystemSolarPanel systemSolarPanel)
            : base(guid, systemSolarPanel)
        {
            if (systemSolarPanel != null)
            {
                EtaZero = systemSolarPanel.EtaZero;
                AlphaOne = systemSolarPanel.AlphaOne;
                AlphaTwo = systemSolarPanel.AlphaTwo;
                Multiplicity = systemSolarPanel.Multiplicity;
                Capacity = systemSolarPanel.Capacity;
                DesignPressureDrop = systemSolarPanel.DesignPressureDrop;
                NoNegativeLoad = systemSolarPanel.NoNegativeLoad;
                UseZoneSurface = systemSolarPanel.UseZoneSurface;
                SweptArea = systemSolarPanel.SweptArea;
                Inclination = systemSolarPanel.Inclination?.Clone();
                Orientation = systemSolarPanel.Orientation?.Clone();
                Reflectance = systemSolarPanel.Reflectance;
                DesignFlowPerM2 = systemSolarPanel.DesignFlowPerM2;
            }
        }

        public SystemSolarPanel(JsonObject jObject)
            : base(jObject)
        {

        }

        public override SystemConnectorManager SystemConnectorManager
        {
            get
            {
                return Core.Systems.Create.SystemConnectorManager
                (
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.In, 1),
                    Core.Systems.Create.SystemConnector<LiquidSystem>(Direction.Out, 1),
                    Core.Systems.Create.SystemConnector<IControlSystem>()
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

            if (jObject.ContainsKey("EtaZero"))
            {
                EtaZero = jObject["EtaZero"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AlphaOne"))
            {
                AlphaOne = jObject["AlphaOne"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("AlphaTwo"))
            {
                AlphaTwo = jObject["AlphaTwo"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Multiplicity"))
            {
                Multiplicity = jObject["Multiplicity"]?.GetValue<int>() ?? default(int);
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject["Capacity"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject["DesignPressureDrop"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("NoNegativeLoad"))
            {
                NoNegativeLoad = jObject["NoNegativeLoad"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("NoNegativeLoad"))
            {
                NoNegativeLoad = jObject["NoNegativeLoad"]?.GetValue<bool>() ?? default(bool);
            }

            if (jObject.ContainsKey("SweptArea"))
            {
                SweptArea = jObject["SweptArea"]?.GetValue<double>() ?? default(double);
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

            if (jObject.ContainsKey("DesignFlowPerM2"))
            {
                DesignFlowPerM2 = jObject["DesignFlowPerM2"]?.GetValue<double>() ?? default(double);
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

            if (!double.IsNaN(EtaZero))
            {
                result.Add("EtaZero", EtaZero);
            }

            if (!double.IsNaN(AlphaOne))
            {
                result.Add("AlphaOne", AlphaOne);
            }

            if (!double.IsNaN(AlphaTwo))
            {
                result.Add("AlphaTwo", AlphaTwo);
            }

            result.Add("Multiplicity", Multiplicity);

            if (!double.IsNaN(Capacity))
            {
                result.Add("Capacity", Capacity);
            }

            if (!double.IsNaN(DesignPressureDrop))
            {
                result.Add("DesignPressureDrop", DesignPressureDrop);
            }

            result.Add("NoNegativeLoad", NoNegativeLoad);

            result.Add("UseZoneSurface", UseZoneSurface);

            if (!double.IsNaN(SweptArea))
            {
                result.Add("SweptArea", SweptArea);
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

            if (!double.IsNaN(DesignFlowPerM2))
            {
                result.Add("DesignFlowPerM2", DesignFlowPerM2);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemSolarPanel(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}