using Newtonsoft.Json.Linq;
using SAM.Core;
using System.Linq;

namespace SAM.Analytical.Systems
{
    public class CurveModifier : IndexedSimpleModifier
    {
        public CurveModifier(ArithmeticOperator arithmeticOperator, string name, CurveModifierType curveModifierType, CurveModifierVariableType[] curveModifierVariableTypes, double[] parameters)
        {
            ArithmeticOperator = arithmeticOperator;
            Name = name;
            CurveModifierType = curveModifierType;
            CurveModifierVariableTypes = curveModifierVariableTypes?.ToArray();
            Parameters = parameters?.ToArray();
        }

        public CurveModifier(CurveModifier curveModifier)
            : base(curveModifier)
        {
            if (curveModifier != null)
            {
                ArithmeticOperator = curveModifier.ArithmeticOperator;
                Name = curveModifier.Name;
                CurveModifierType = curveModifier.CurveModifierType;
                CurveModifierVariableTypes = curveModifier.CurveModifierVariableTypes?.ToArray();
                Parameters = curveModifier.Parameters?.ToArray();
            }
        }

        public CurveModifier(JObject jObject)
            : base(jObject)
        {

        }

        public CurveModifierType CurveModifierType { get; set; }
        
        public CurveModifierVariableType[] CurveModifierVariableTypes { get; set; }
        
        public string Name { get; set; }
        
        public double[] Parameters { get; set; }
        
        public override bool ContainsIndex(int index)
        {
            throw new System.NotImplementedException();
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("CurveModifierType"))
            {
                CurveModifierType = Core.Query.Enum<CurveModifierType>(jObject.Value<string>("CurveModifierType"));
            }

            if (jObject.ContainsKey("Name"))
            {
                Name = jObject.Value<string>("Name");
            }

            if (jObject.ContainsKey("CurveModifierVariableTypes"))
            {
                JArray jArray = jObject.Value<JArray>("CurveModifierVariableTypes");

                CurveModifierVariableTypes = new CurveModifierVariableType[jArray.Count];

                int index = 0;
                foreach (string value in jArray)
                {
                    CurveModifierVariableTypes[index] = Core.Query.Enum<CurveModifierVariableType>(value);
                    index++;
                }
            }

            if (jObject.ContainsKey("Parameters"))
            {
                JArray jArray = jObject.Value<JArray>("Parameters");

                Parameters = new double[jArray.Count];

                int index = 0;
                foreach (double value in jArray)
                {
                    Parameters[index] = value;
                    index++;
                }
            }

            return result;
        }

        public override double GetCalculatedValue(int index, double value)
        {
            throw new System.NotImplementedException();
        }

        public override JObject ToJObject()
        {
            JObject result = base.ToJObject();
            if (result == null)
            {
                return null;
            }

            result.Add("CurveModifierType", CurveModifierType.ToString());

            if(Name != null)
            {
                result.Add("Name", Name);
            }

            if(CurveModifierVariableTypes != null)
            {
                JArray jArray = new JArray();
                foreach(CurveModifierVariableType curveModifierVariableType in CurveModifierVariableTypes)
                {
                    jArray.Add(curveModifierVariableType.ToString());
                }

                result.Add("CurveModifierVariableTypes", jArray);
            }

            if(Parameters != null)
            {
                JArray jArray = new JArray();
                foreach (double value in Parameters)
                {
                    jArray.Add(value);
                }

                result.Add("Parameters", jArray);
            }

            return result;
        }
    }
}