using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public abstract class SystemMultiComponent : SystemComponent
    {
        public SystemMultiComponent(System.Guid guid, SystemMultiComponent systemMultiComponent)
            : base(guid, systemMultiComponent)
        {

        }

        public SystemMultiComponent(SystemMultiComponent systemMultiComponent)
            : base(systemMultiComponent)
        {

        }

        public SystemMultiComponent(JObject jObject)
            : base(jObject)
        {

        }

        public SystemMultiComponent(string name)
            : base(name)
        {

        }

        public SystemMultiComponent(System.Guid guid, string name)
            : base(guid, name)
        {

        }

        public abstract int Multiplicity { get; }

        public abstract SystemObject GetItem(int index);

        public abstract bool Add(SystemObject item);
    }

    public abstract class SystemMultiComponent<TSystemObject> : SystemMultiComponent where TSystemObject : SystemObject
    {
        private Dictionary<System.Guid, TSystemObject> dictionary = new Dictionary<System.Guid, TSystemObject>();

        public SystemMultiComponent(System.Guid guid, SystemMultiComponent<TSystemObject> systemMultiComponent)
            : base(guid, systemMultiComponent)
        {
            if (systemMultiComponent != null)
            {
                foreach (TSystemObject systemObject in systemMultiComponent.dictionary.Values)
                {
                    Add(systemObject);
                }
            }
        }

        public SystemMultiComponent(SystemMultiComponent<TSystemObject> systemMultiComponent)
            : base(systemMultiComponent)
        {
            if(systemMultiComponent != null)
            {
                foreach(TSystemObject systemObject in systemMultiComponent.dictionary.Values)
                {
                    Add(systemObject);
                }
            }
        }

        public SystemMultiComponent(JObject jObject)
            : base(jObject)
        {

        }

        public SystemMultiComponent(string name)
            : base(name)
        {

        }

        public SystemMultiComponent(System.Guid guid, string name)
            : base(guid, name)
        {

        }

        public List<TSystemObject> Items
        {
            get
            {
                return dictionary.Values.ToList().ConvertAll(x => x.Clone());
            }
        }

        public override bool Add(SystemObject item)
        {
            TSystemObject item_Temp = (item as TSystemObject)?.Clone();
            if(item_Temp == null)
            {
                return true;
            }

            dictionary[item_Temp.Guid] = item_Temp;
            return true;
        }

        public override int Multiplicity
        {
            get
            {
                return dictionary == null ? 0 : dictionary.Count;
            }
        }

        public override SystemObject GetItem(int index)
        {
            if(index < 0 || dictionary.Count == 0)
            {
                return null;
            }

            IEnumerable<TSystemObject> items = dictionary.Values;
            if(index >= items.Count())
            {
                return null;
            }

            return items.ElementAt(index)?.Clone();
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("Items"))
            {
                JArray jArray = jObject.Value<JArray>("Items");
                if(jArray != null)
                {
                    foreach(JObject jObject_Item in jArray)
                    {
                        TSystemObject item = Core.Query.IJSAMObject<TSystemObject>(jObject_Item);
                        if(item == null)
                        {
                            continue;
                        }

                        Add(item);
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

            if(dictionary != null)
            {
                JArray jArray = new JArray();
                foreach(TSystemObject item in dictionary.Values)
                {
                    jArray.Add(item.ToJObject());
                }

                result.Add("Items", jArray);
            }

            return result;
        }
    }
}
