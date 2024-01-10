using Newtonsoft.Json.Linq;
using SAM.Core;
using System.Collections.Generic;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemPlantRoom : SAMObject, IDisplaySystemObject
    {
        private ObjectReference objectReference;

        private List<IDisplaySystemInstance> displaySystemInstances;

        public DisplaySystemPlantRoom(ObjectReference objectReference, string name)
            : base(name)
        {
            this.objectReference = objectReference == null ? null : new ObjectReference(objectReference);
        }

        public DisplaySystemPlantRoom(DisplaySystemPlantRoom displaySystemPlantRoom)
            : base(displaySystemPlantRoom)
        {
            if(displaySystemPlantRoom != null)
            {
                objectReference = displaySystemPlantRoom.objectReference == null ? null : new ObjectReference(displaySystemPlantRoom.objectReference);
                displaySystemInstances = displaySystemPlantRoom.displaySystemInstances == null ? null : displaySystemPlantRoom.displaySystemInstances.ConvertAll(x => x.Clone());
            }
        }

        public DisplaySystemPlantRoom(JObject jObject)
            : base(jObject)
        {

        }

        public List<T> GetDisplaySystemInstances<T>(PathReference pathReference) where T : IDisplaySystemInstance
        {
            if(objectReference == null || displaySystemInstances == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            for (int i = 0; i < displaySystemInstances.Count; i++)
            {
                if (!(displaySystemInstances[i] is T))
                {
                    continue;
                }

                T t = (T)(object)displaySystemInstances[i];
                if(t.PathReference == pathReference)
                {
                    result.Add(t.Clone());
                }
            }

            return result;
        }

        public List<T> GetDisplaySystemInstances<T>() where T : IDisplaySystemInstance
        {
            if (objectReference == null || displaySystemInstances == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            for (int i = 0; i < displaySystemInstances.Count; i++)
            {
                if (!(displaySystemInstances[i] is T))
                {
                    continue;
                }

                T t = (T)(object)displaySystemInstances[i];
                result.Add(t.Clone());
            }

            return result;
        }

        public ObjectReference ObjectReference
        {
            get
            {
                return objectReference == null ? null : new ObjectReference(objectReference);
            }
        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if(!result)
            {
                return result;
            }

            if(jObject.ContainsKey("ObjectReference"))
            {
                objectReference = new ObjectReference(jObject.Value<JObject>("ObjectReference"));
            }

            if(jObject.ContainsKey("DisplaySystemInstances"))
            {
                JArray jArray = jObject.Value<JArray>("DisplaySystemInstances");
                if(jArray != null)
                {
                    displaySystemInstances = new List<IDisplaySystemInstance>();
                    foreach(JObject jObject_Temp in jArray)
                    {
                        if(jObject_Temp == null)
                        {
                            continue;
                        }

                        IDisplaySystemInstance displaySystemInstance = Core.Query.IJSAMObject<IDisplaySystemInstance>(jObject_Temp);
                        if(displaySystemInstance == null)
                        {
                            continue;
                        }

                        displaySystemInstances.Add(displaySystemInstance);
                    }
                }
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

            if(objectReference != null)
            {
                result.Add("ObjectReference", objectReference.ToJObject());
            }

            if(displaySystemInstances != null)
            {
                JArray jArray = new JArray();
                foreach(IDisplaySystemInstance displaySystemInstance in displaySystemInstances)
                {
                    if(displaySystemInstance == null)
                    {
                        continue;
                    }

                    jArray.Add(displaySystemInstance.ToJObject());
                }


                result.Add("DisplaySystemInstances", jArray);
            }

            return result;
        }
    }
}
