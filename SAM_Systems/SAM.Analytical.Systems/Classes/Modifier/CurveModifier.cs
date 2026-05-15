using System.Text.Json.Nodes;
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

        public CurveModifier(JsonObject jObject)
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

        public override bool FromJsonObject(JsonObject jObject)
        {
            bool result = base.FromJsonObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("CurveModifierType"))
            {
                CurveModifierType = Core.Query.Enum<CurveModifierType>(jObject["CurveModifierType"]?.GetValue<string>() ?? null);
            }

            if (jObject.ContainsKey("Name"))
            {
                Name = jObject["Name"]?.GetValue<string>() ?? null;
            }

            if (jObject.ContainsKey("CurveModifierVariableTypes"))
            {
                JsonArray jArray = jObject["CurveModifierVariableTypes"] as JsonArray;

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
                JsonArray jArray = jObject["Parameters"] as JsonArray;

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

        public override JsonObject ToJsonObject()
        {
            JsonObject result = base.ToJsonObject();
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
                JsonArray jArray = new JsonArray();
                foreach(CurveModifierVariableType curveModifierVariableType in CurveModifierVariableTypes)
                {
                    jArray.Add(curveModifierVariableType.ToString());
                }

                result.Add("CurveModifierVariableTypes", jArray);
            }

            if(Parameters != null)
            {
                JsonArray jArray = new JsonArray();
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