using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public abstract class SystemMultiComponent : SystemComponent
    {
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

        public SystemMultiComponent(SystemMultiComponent<TSystemObject> systemMultiComponent)
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
            return base.FromJObject(jObject);
        }

        public override JObject ToJObject()
        {
            return base.ToJObject();
        }
    }
}
