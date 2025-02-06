using Newtonsoft.Json.Linq;
using SAM.Core;

namespace SAM.Analytical.Systems
{
    public class FluidType : SAMObject, Core.Systems.ISystemObject
    {
        public string Description { get; set; }
        public double SpecificHeatCapacity { get; set; }
        public double Density { get; set; }
        public double FreezingPoint { get; set; }

        public FluidType(string name)
            :base(name)
        {

        }

        public FluidType(FluidType fluidType)
            : base(fluidType)
        {
            if(fluidType != null)
            {
                Description = fluidType.Description;
                SpecificHeatCapacity = fluidType.SpecificHeatCapacity;
                Density = fluidType.Density;
                FreezingPoint = fluidType.FreezingPoint;
            }
        }

        public FluidType(JObject jObject)
            :base(jObject)
        {
            
        }

        public virtual bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return false;
            }

            if (jObject.ContainsKey("Description"))
            {
                Description = jObject.Value<string>("Description");
            }

            if (jObject.ContainsKey("SpecificHeatCapacity"))
            {
                SpecificHeatCapacity = jObject.Value<double>("SpecificHeatCapacity");
            }

            if (jObject.ContainsKey("Density"))
            {
                Density = jObject.Value<double>("Density");
            }

            if (jObject.ContainsKey("FreezingPoint"))
            {
                FreezingPoint = jObject.Value<double>("FreezingPoint");
            }

            return result;
        }

        public virtual JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if(result == null)
            {
                return result;
            }

            if (Description != null)
            {
                result.Add("Description", Description);
            }

            if (double.IsNaN(SpecificHeatCapacity))
            {
                result.Add("SpecificHeatCapacity", SpecificHeatCapacity);
            }

            if (double.IsNaN(Density))
            {
                result.Add("Density", Density);
            }

            if (double.IsNaN(FreezingPoint))
            {
                result.Add("FreezingPoint", FreezingPoint);
            }

            return result;
        }
    }
}