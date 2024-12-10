using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using System.Collections.Generic;

namespace SAM.Analytical.Systems
{
    public class SystemMultiBoiler : SystemComponent
    {
        private List<SystemMultiBoilerItem> systemMultiBoilerItems;

        public ModifiableValue Setpoint { get; set; }

        public SizableValue Duty { get; set; }

        public double DesignTemperatureDifference { get; set; }

        public bool LossesInSizing { get; set; }

        public BoilerSequence BoilerSequence { get; set; }

        public SystemMultiBoiler(string name)
            : base(name)
        {

        }

        public SystemMultiBoiler(SystemMultiBoiler systemMultiBoiler)
            : base(systemMultiBoiler)
        {
            if(systemMultiBoiler != null)
            {
                systemMultiBoilerItems = systemMultiBoiler.systemMultiBoilerItems?.ConvertAll(x => x.Clone());
                Setpoint = systemMultiBoiler.Setpoint?.Clone();
                Duty = systemMultiBoiler.Duty.Clone();
                DesignTemperatureDifference = systemMultiBoiler.DesignTemperatureDifference;
                LossesInSizing = systemMultiBoiler.LossesInSizing;
                BoilerSequence = systemMultiBoiler.BoilerSequence;
            }
        }

        public SystemMultiBoiler(JObject jObject)
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

        public int Multiplicity
        {
            get
            {
                return systemMultiBoilerItems == null ? 0 : systemMultiBoilerItems.Count;
            }
        }

        public bool Add(SystemMultiBoilerItem systemMultiBoilerItem)
        {
            if(systemMultiBoilerItem == null)
            {
                return false;
            }

            if(systemMultiBoilerItems == null)
            {
                systemMultiBoilerItems = new List<SystemMultiBoilerItem>();
            }

            systemMultiBoilerItems.Add(systemMultiBoilerItem.Clone());
            return true;
        }

        public List<SystemMultiBoilerItem> SystemMultiBoilerItems
        {
            get
            {
                return systemMultiBoilerItems?.ConvertAll(x => x?.Clone());
            }

            set
            {
                systemMultiBoilerItems = value?.ConvertAll(x => x?.Clone());
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemMultiBoilerItems"))
            {
                JArray jArray = jObject.Value<JArray>("SystemMultiBoilerItems");
                if(jArray != null)
                {
                    systemMultiBoilerItems = new List<SystemMultiBoilerItem>();
                    foreach(JObject jObject_SystemMultiBoilerItem in jArray)
                    {
                        systemMultiBoilerItems.Add(Core.Query.IJSAMObject<SystemMultiBoilerItem>(jObject_SystemMultiBoilerItem));
                    }
                }
            }

            if (jObject.ContainsKey("Setpoint"))
            {
                Setpoint = Core.Query.IJSAMObject<ModifiableValue>(jObject.Value<JObject>("Setpoint"));
            }

            if (jObject.ContainsKey("Duty"))
            {
                Duty = Core.Query.IJSAMObject<SizableValue>(jObject.Value<JObject>("Duty"));
            }

            if (jObject.ContainsKey("DesignTemperatureDifference"))
            {
                DesignTemperatureDifference = jObject.Value<double>("DesignTemperatureDifference");
            }

            if (jObject.ContainsKey("LossesInSizing"))
            {
                LossesInSizing = jObject.Value<bool>("LossesInSizing");
            }

            if (jObject.ContainsKey("BoilerSequence"))
            {
                BoilerSequence = Core.Query.Enum<BoilerSequence>(jObject.Value<string>("BoilerSequence"));
            }

            return true;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            if (systemMultiBoilerItems != null)
            {
                JArray jArray = new JArray();

                foreach(SystemMultiBoilerItem systemMultiBoilerItem in systemMultiBoilerItems)
                {
                    jArray.Add(systemMultiBoilerItem.ToJObject());
                }

                result.Add("SystemMultiBoilerItems", jArray);
            }

            if (Setpoint != null)
            {
                result.Add("Setpoint", Setpoint.ToJObject());
            }

            if (Duty != null)
            {
                result.Add("Duty", Duty.ToJObject());
            }

            if (!double.IsNaN(DesignTemperatureDifference))
            {
                result.Add("DesignTemperatureDifference", DesignTemperatureDifference);
            }

            result.Add("LossesInSizing", LossesInSizing);

            result.Add("BoilerSequence", BoilerSequence.ToString());

            return result;
        }
    }
}


