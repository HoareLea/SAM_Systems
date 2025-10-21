using Newtonsoft.Json.Linq;
using System;

namespace SAM.Core.Systems
{
    public class SystemLabel : ISystemLabel
    {
        public SystemLabel(SystemLabel systemLabel)
        {
            if (systemLabel != null)
            {
                Text = systemLabel.Text;
                Guid = systemLabel.Guid;
                Name = systemLabel.Name;
            }
        }

        public SystemLabel(JObject jObject)
        {
            FromJObject(jObject);
        }

        public SystemLabel()
        {

        }

        public SystemLabel(string text)
            : base()
        {
            Text = text;
            Guid = Guid.NewGuid();
            Name = null;
        }

        public Guid Guid { get; private set; }
        
        public string Name { get; private set; }
        
        public string Text { get; set; }
        
        public bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Text"))
            {
                Text = jObject.Value<string>("Text");
            }

            Guid = Core.Query.Guid(jObject);

            if (jObject.ContainsKey("Name"))
            {
                Name = jObject.Value<string>("Name");
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject result = new JObject();
            result.Add("_type", Core.Query.FullTypeName(this));

            if (Text != null)
            {
                result.Add("Text", Text);
            }

            result.Add("Guid", Guid);
            
            if (Name != null)
            {
                result.Add("Name", Name);
            }

            return result;
        }
    }
}