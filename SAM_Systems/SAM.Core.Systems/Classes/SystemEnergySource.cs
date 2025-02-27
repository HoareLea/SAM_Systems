using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemEnergySource : SystemObject
    {
        public string Description { get; set; }
        public IndexedDoubles CO2Factor { get; set; }
        public IndexedDoubles PeakCost { get; set; }
        public IndexedDoubles PrimaryEnergyFactor { get; set; }
        public double OffPeakCost { get; set; }
        public string ScheduleName { get; set; }
        public double CustomerMonthlyCharge { get; set; }
        public double FuelCostAdjustment { get; set; }
        public double Discount { get; set; }
        public List<TariffProfile> DemandTariffProfiles { get; set; }
        public List<TariffProfile> ConsumptionTariffProfiles { get; set; }

        public SystemEnergySource(SystemEnergySource systemEnergySource)
            : base(systemEnergySource)
        {
            if(systemEnergySource != null)
            {
                Description = systemEnergySource.Description;
                CO2Factor = systemEnergySource.CO2Factor?.Clone();
                PeakCost = systemEnergySource.PeakCost?.Clone();
                PrimaryEnergyFactor = systemEnergySource.PrimaryEnergyFactor?.Clone();
                OffPeakCost = systemEnergySource.OffPeakCost;
                ScheduleName = systemEnergySource.ScheduleName;
                CustomerMonthlyCharge = systemEnergySource.CustomerMonthlyCharge;
                FuelCostAdjustment = systemEnergySource.FuelCostAdjustment;
                Discount = systemEnergySource.Discount;
                DemandTariffProfiles = systemEnergySource.DemandTariffProfiles?.ToList();
                ConsumptionTariffProfiles = systemEnergySource.ConsumptionTariffProfiles?.ToList();
            }
        }

        public SystemEnergySource(JObject jObject)
            : base(jObject)
        {

        }

        public SystemEnergySource(string name)
            : base(name)
        {

        }

        public SystemEnergySource(System.Guid guid, string name)
            : base(guid, name)
        {

        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Description"))
            {
                Description = jObject.Value<string>("Description");
            }

            if(jObject.ContainsKey("CO2Factor"))
            {
                CO2Factor = Core.Query.IJSAMObject<IndexedDoubles>(jObject.Value<JObject>("CO2Factor"));
            }

            if (jObject.ContainsKey("PeakCost"))
            {
                PeakCost = Core.Query.IJSAMObject<IndexedDoubles>(jObject.Value<JObject>("PeakCost"));
            }

            if (jObject.ContainsKey("PrimaryEnergyFactor"))
            {
                PrimaryEnergyFactor = Core.Query.IJSAMObject<IndexedDoubles>(jObject.Value<JObject>("PrimaryEnergyFactor"));
            }

            if (jObject.ContainsKey("OffPeakCost"))
            {
                OffPeakCost = jObject.Value<double>("OffPeakCost");
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject.Value<string>("ScheduleName");
            }

            if (jObject.ContainsKey("CustomerMonthlyCharge"))
            {
                CustomerMonthlyCharge = jObject.Value<double>("CustomerMonthlyCharge");
            }

            if (jObject.ContainsKey("FuelCostAdjustment"))
            {
                FuelCostAdjustment = jObject.Value<double>("FuelCostAdjustment");
            }

            if (jObject.ContainsKey("Discount"))
            {
                Discount = jObject.Value<double>("Discount");
            }

            if (jObject.ContainsKey("DemandTariffProfiles"))
            {
                DemandTariffProfiles = new List<TariffProfile>();
                foreach(JObject jObject_Temp in jObject.Value<JArray>("DemandTariffProfiles"))
                {
                    TariffProfile tariffProfile = Core.Query.IJSAMObject<TariffProfile>(jObject_Temp);
                    if(tariffProfile != null)
                    {
                        DemandTariffProfiles.Add(tariffProfile);
                    }
                }
            }

            if (jObject.ContainsKey("ConsumptionTariffProfiles"))
            {
                ConsumptionTariffProfiles = new List<TariffProfile>();
                foreach (JObject jObject_Temp in jObject.Value<JArray>("ConsumptionTariffProfiles"))
                {
                    TariffProfile tariffProfile = Core.Query.IJSAMObject<TariffProfile>(jObject_Temp);
                    if (tariffProfile != null)
                    {
                        ConsumptionTariffProfiles.Add(tariffProfile);
                    }
                }
            }

            return result;
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if(Description != null)
            {
                result.Add("Description", Description);
            }

            if(CO2Factor != null)
            {
                result.Add("CO2Factor", CO2Factor.ToJObject());
            }

            if (PeakCost != null)
            {
                result.Add("PeakCost", PeakCost.ToJObject());
            }

            if (PrimaryEnergyFactor != null)
            {
                result.Add("PrimaryEnergyFactor", PrimaryEnergyFactor.ToJObject());
            }

            if(!double.IsNaN(OffPeakCost))
            {
                result.Add("OffPeakCost", OffPeakCost);
            }

            if (ScheduleName != null)
            {
                result.Add("ScheduleName", ScheduleName);
            }

            if (!double.IsNaN(CustomerMonthlyCharge))
            {
                result.Add("CustomerMonthlyCharge", CustomerMonthlyCharge);
            }

            if (!double.IsNaN(FuelCostAdjustment))
            {
                result.Add("FuelCostAdjustment", FuelCostAdjustment);
            }

            if (!double.IsNaN(Discount))
            {
                result.Add("Discount", Discount);
            }

            if(DemandTariffProfiles != null)
            {
                JArray jArray = new JArray();
                foreach(TariffProfile tariffProfile in DemandTariffProfiles)
                {
                    jArray.Add(tariffProfile.ToJObject());
                }

                result.Add("DemandTariffProfiles", jArray);
            }

            if (ConsumptionTariffProfiles != null)
            {
                JArray jArray = new JArray();
                foreach (TariffProfile tariffProfile in ConsumptionTariffProfiles)
                {
                    jArray.Add(tariffProfile.ToJObject());
                }

                result.Add("ConsumptionTariffProfiles", jArray);
            }

            return result;
        }
    }
}
