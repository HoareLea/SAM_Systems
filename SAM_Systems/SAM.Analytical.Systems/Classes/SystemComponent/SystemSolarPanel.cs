using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;

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
        public double Area { get; set; }
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
                Area = systemSolarPanel.Area;
                Inclination = systemSolarPanel.Inclination?.Clone();
                Orientation = systemSolarPanel.Orientation?.Clone();
                Reflectance = systemSolarPanel.Reflectance;
                DesignFlowPerM2 = systemSolarPanel.DesignFlowPerM2;
            }
        }

        public SystemSolarPanel(JObject jObject)
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

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("EtaZero"))
            {
                EtaZero = jObject.Value<double>("EtaZero");
            }

            if (jObject.ContainsKey("AlphaOne"))
            {
                AlphaOne = jObject.Value<double>("AlphaOne");
            }

            if (jObject.ContainsKey("AlphaTwo"))
            {
                AlphaTwo = jObject.Value<double>("AlphaTwo");
            }

            if (jObject.ContainsKey("Multiplicity"))
            {
                Multiplicity = jObject.Value<int>("Multiplicity");
            }

            if (jObject.ContainsKey("Capacity"))
            {
                Capacity = jObject.Value<double>("Capacity");
            }

            if (jObject.ContainsKey("DesignPressureDrop"))
            {
                DesignPressureDrop = jObject.Value<double>("DesignPressureDrop");
            }

            if (jObject.ContainsKey("NoNegativeLoad"))
            {
                NoNegativeLoad = jObject.Value<bool>("NoNegativeLoad");
            }

            if (jObject.ContainsKey("NoNegativeLoad"))
            {
                NoNegativeLoad = jObject.Value<bool>("NoNegativeLoad");
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

            if (jObject.ContainsKey("DesignFlowPerM2"))
            {
                DesignFlowPerM2 = jObject.Value<double>("DesignFlowPerM2");
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

            if (!double.IsNaN(DesignFlowPerM2))
            {
                result.Add("DesignFlowPerM2", DesignFlowPerM2);
            }

            return result;
        }
    }
}