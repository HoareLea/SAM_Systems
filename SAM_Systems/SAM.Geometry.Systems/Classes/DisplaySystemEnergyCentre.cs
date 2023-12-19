using Newtonsoft.Json.Linq;
using SAM.Core;
using SAM.Core.Systems;
using SAM.Geometry.Planar;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemEnergyCentre : SAMObject, IDisplaySystemObject
    {
        private SystemEnergyCentre systemEnergyCentre;

        private List<DisplaySystemPlantRoom> displaySystemPlantRooms;

        public DisplaySystemEnergyCentre()
            :base()
        {

        }

        public DisplaySystemEnergyCentre(SystemEnergyCentre systemEnergyCentre)
            : base(systemEnergyCentre?.Name)
        {
            this.systemEnergyCentre = systemEnergyCentre;
            displaySystemPlantRooms = new List<DisplaySystemPlantRoom>();
        }

        public DisplaySystemEnergyCentre(DisplaySystemEnergyCentre displaySystemEnergyCentre)
            :base(displaySystemEnergyCentre)
        {
            if(displaySystemEnergyCentre != null)
            {
                systemEnergyCentre = displaySystemEnergyCentre.systemEnergyCentre == null ? null : new SystemEnergyCentre(displaySystemEnergyCentre.systemEnergyCentre);
                displaySystemPlantRooms = displaySystemEnergyCentre.displaySystemPlantRooms == null ? null : displaySystemEnergyCentre.displaySystemPlantRooms.ConvertAll(x => x.Clone());
            }
        }

        public DisplaySystemEnergyCentre(JObject jObject)
            :base(jObject)
        {

        }

        public List<T> GetDisplaySystemInstances<T>(PathReference pathReference) where T : IDisplaySystemInstance
        {
            if(pathReference == null)
            {
                return null;
            }

            int count = pathReference.Count();
            if(count < 1)
            {
                return null;
            }

            List<T> result = new List<T>();
            if(count == 1)
            {
                List<DisplaySystemPlantRoom> displaySystemPlantRooms = GetDisplaySystemPlantRooms(pathReference.ElementAt(0));
                if(displaySystemPlantRooms != null)
                {
                    foreach(DisplaySystemPlantRoom displaySystemPlantRoom in displaySystemPlantRooms)
                    {
                        List<T> displaySystemInstances = displaySystemPlantRoom.GetDisplaySystemInstances<T>();
                        if(displaySystemInstances != null)
                        {
                            result.AddRange(displaySystemInstances);
                        }
                    }
                }

                return result;
            }
            else
            {
                List<DisplaySystemPlantRoom> displaySystemPlantRooms = GetDisplaySystemPlantRooms(pathReference.ElementAt(0));
                if (displaySystemPlantRooms != null)
                {
                    foreach (DisplaySystemPlantRoom displaySystemPlantRoom in displaySystemPlantRooms)
                    {
                        List<T> displaySystemInstances = displaySystemPlantRoom.GetDisplaySystemInstances<T>(pathReference);
                        if (displaySystemInstances != null)
                        {
                            result.AddRange(displaySystemInstances);
                        }
                    }
                }

                return result;
            }
        }

        public List<DisplaySystemPlantRoom> GetDisplaySystemPlantRooms(ObjectReference objectReference)
        {
            if(objectReference == null || displaySystemPlantRooms == null)
            {
                return null;
            }

            List<DisplaySystemPlantRoom> result = new List<DisplaySystemPlantRoom>();
            foreach (DisplaySystemPlantRoom displaySystemPlantRoom in displaySystemPlantRooms)
            {
                if(displaySystemPlantRoom?.ObjectReference == objectReference)
                {
                    result.Add(displaySystemPlantRoom.Clone());
                }
            }

            return result;
        }

        public DisplaySystemPlantRoom GetDisplaySystemPlantRoom(System.Guid guid)
        {
            DisplaySystemPlantRoom result = displaySystemPlantRooms?.Find(x => x.Guid == guid);

            return result?.Clone();
        }

        public DisplaySystemPlantRoom Add(string name)
        {
            return Add(new SystemPlantRoom(name), name);
        }

        public DisplaySystemPlantRoom Add(SystemPlantRoom systemPlantRoom, string name)
        {
            if(systemPlantRoom == null)
            {
                return null;
            }

            if(displaySystemPlantRooms == null)
            {
                displaySystemPlantRooms = new List<DisplaySystemPlantRoom>();
            }

            if(systemEnergyCentre == null)
            {
                systemEnergyCentre = new SystemEnergyCentre(Name);
            }

            systemEnergyCentre.Add(systemPlantRoom);

            DisplaySystemPlantRoom result = new DisplaySystemPlantRoom(new ObjectReference(systemPlantRoom), name);

            displaySystemPlantRooms.Add(result);

            return result.Clone();
        }

        public DisplaySystemInstance Add(ISystemSpace systemSpace, DisplaySystemPlantRoom displaySystemPlantRoom, Point2D location)
        {
            if(systemSpace == null || displaySystemPlantRoom == null || location == null)
            {
                return null;
            }

            DisplaySystemPlantRoom displaySystemPlantRoom_Temp = displaySystemPlantRooms?.Find(x => x.Guid == displaySystemPlantRoom.Guid);
            if (displaySystemPlantRoom_Temp == null)
            {
                return null;
            }

            SystemPlantRoom systemPlantRoom = systemEnergyCentre?.GetSystemPlantRoom(displaySystemPlantRoom.ObjectReference);
            if(systemPlantRoom == null)
            {
                return null;
            }

            systemPlantRoom.Add(systemSpace);


        }

        public override bool FromJObject(JObject jObject)
        {
            bool result = base.FromJObject(jObject);
            if (!result)
            {
                return result;
            }

            if (jObject.ContainsKey("SystemEnergyCentre"))
            {
                systemEnergyCentre = new SystemEnergyCentre(jObject.Value<JObject>("SystemEnergyCentre"));
            }

            if (jObject.ContainsKey("DisplaySystemPlantRooms"))
            {
                JArray jArray = jObject.Value<JArray>("DisplaySystemPlantRooms");
                if (jArray != null)
                {
                    displaySystemPlantRooms = new List<DisplaySystemPlantRoom>();
                    foreach (JObject jObject_Temp in jArray)
                    {
                        DisplaySystemPlantRoom displaySystemPlantRoom = Core.Query.IJSAMObject<DisplaySystemPlantRoom>(jObject_Temp);
                        if (displaySystemPlantRoom == null)
                        {
                            continue;
                        }

                        displaySystemPlantRooms.Add(displaySystemPlantRoom);
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

            if(displaySystemPlantRooms != null)
            {
                JArray jArray = new JArray();
                foreach(DisplaySystemPlantRoom displaySystemPlantRoom in displaySystemPlantRooms)
                {
                    if(displaySystemPlantRoom == null)
                    {
                        continue;
                    }

                    jArray.Add(displaySystemPlantRoom.ToJObject());
                }

                result.Add("DisplaySystemPlantRooms", jArray);
            }

            return result;
        }
    }
}
