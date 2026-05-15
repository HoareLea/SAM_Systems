using System.Text.Json.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemEnergySource : SystemObject
    {
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

        public SystemEnergySource(Guid guid, SystemEnergySource systemEnergySource)
            :base(guid, systemEnergySource)
        {
            if (systemEnergySource != null)
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

        public SystemEnergySource(JsonObject jObject)
            : base(jObject)
        {

        }

        public SystemEnergySource(string name)
            : base(name)
        {

        }

        public SystemEnergySource(Guid guid, string name)
            : base(guid, name)
        {

        }

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("CO2Factor"))
            {
                CO2Factor = Core.Query.IJSAMObject<IndexedDoubles>(jObject["CO2Factor"] as JsonObject);
            }

            if (jObject.ContainsKey("PeakCost"))
            {
                PeakCost = Core.Query.IJSAMObject<IndexedDoubles>(jObject["PeakCost"] as JsonObject);
            }

            if (jObject.ContainsKey("PrimaryEnergyFactor"))
            {
                PrimaryEnergyFactor = Core.Query.IJSAMObject<IndexedDoubles>(jObject["PrimaryEnergyFactor"] as JsonObject);
            }

            if (jObject.ContainsKey("OffPeakCost"))
            {
                OffPeakCost = jObject["OffPeakCost"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("ScheduleName"))
            {
                ScheduleName = jObject["ScheduleName"]?.GetValue<string>() ?? null;
            }

            if (jObject.ContainsKey("CustomerMonthlyCharge"))
            {
                CustomerMonthlyCharge = jObject["CustomerMonthlyCharge"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("FuelCostAdjustment"))
            {
                FuelCostAdjustment = jObject["FuelCostAdjustment"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("Discount"))
            {
                Discount = jObject["Discount"]?.GetValue<double>() ?? default(double);
            }

            if (jObject.ContainsKey("DemandTariffProfiles"))
            {
                DemandTariffProfiles = new List<TariffProfile>();
                foreach(JsonNode jsonNode in jObject["DemandTariffProfiles"] as JsonArray)
                {
                    if (!(jsonNode is JsonObject jObject_Temp))
                    {
                        continue;
                    }

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
                foreach (JsonNode jsonNode in jObject["ConsumptionTariffProfiles"] as JsonArray)
                {
                    if (!(jsonNode is JsonObject jObject_Temp))
                    {
                        continue;
                    }

                    TariffProfile tariffProfile = Core.Query.IJSAMObject<TariffProfile>(jObject_Temp);
                    if (tariffProfile != null)
                    {
                        ConsumptionTariffProfiles.Add(tariffProfile);
                    }
                }
            }

            return result;
        }

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
            if(result == null)
            {
                return result;
            }

            if(CO2Factor != null)
            {
                result.Add("CO2Factor", CO2Factor.ToJsonObject());
            }

            if (PeakCost != null)
            {
                result.Add("PeakCost", PeakCost.ToJsonObject());
            }

            if (PrimaryEnergyFactor != null)
            {
                result.Add("PrimaryEnergyFactor", PrimaryEnergyFactor.ToJsonObject());
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
                JsonArray jArray = new JsonArray();
                foreach(TariffProfile tariffProfile in DemandTariffProfiles)
                {
                    jArray.Add(tariffProfile.ToJsonObject());
                }

                result.Add("DemandTariffProfiles", jArray);
            }

            if (ConsumptionTariffProfiles != null)
            {
                JsonArray jArray = new JsonArray();
                foreach (TariffProfile tariffProfile in ConsumptionTariffProfiles)
                {
                    jArray.Add(tariffProfile.ToJsonObject());
                }

                result.Add("ConsumptionTariffProfiles", jArray);
            }

            return result;
        }

        public override SystemObject Duplicate(Guid? guid = null)
        {
            return new SystemEnergySource(guid == null ? Guid.NewGuid() : guid.Value, this);
        }
    }
}
