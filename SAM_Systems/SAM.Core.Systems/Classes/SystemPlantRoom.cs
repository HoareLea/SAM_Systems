using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemPlantRoom : SAMObject, ISystemSpatialObject
    {
        private RelationCluster relationCluster;

        public SystemPlantRoom(SystemPlantRoom systemPlantRoom)
            :base(systemPlantRoom)
        {
            if(systemPlantRoom != null)
            {
                relationCluster = systemPlantRoom?.relationCluster == null ? null : new RelationCluster(systemPlantRoom.relationCluster);
            }
        }

        public SystemPlantRoom(JObject jObject)
            : base(jObject)
        {

        }

        public SystemPlantRoom(string name)
            : base(name)
        {

        }

        public bool Add(SystemSpace systemSpace)
        {
            if (systemSpace == null)
            {
                return false;
            }

            if (relationCluster == null)
            {
                relationCluster = new RelationCluster();
            }

            return relationCluster.AddObject(new SystemSpace(systemSpace));
        }

        public bool Add(ISystemComponent systemComponent)
        {
            ISystemComponent systemComponent_Temp = systemComponent?.Clone();
            if (systemComponent_Temp == null)
            {
                return false;
            }

            if (relationCluster == null)
            {
                relationCluster = new RelationCluster();
            }

            return relationCluster.AddObject(systemComponent_Temp);
        }

        public bool Add(ISystemSpaceComponent systemSpaceComponent, SystemSpace systemSpace = null)
        {
            bool result = Add(systemSpaceComponent);
            if (!result)
            {
                return result;
            }

            if (systemSpace == null)
            {
                return result;
            }

            if (!relationCluster.Contains(systemSpace))
            {
                Add(systemSpace);
            }

            relationCluster.AddRelation(systemSpace, systemSpaceComponent);
            return true;
        }

        public bool Add(ISystemComponentResult systemEquipmentResult, ISystemComponent systemComponent = null)
        {
            ISystemComponentResult systemComponentResult_Temp = systemEquipmentResult?.Clone();
            if (systemComponentResult_Temp == null)
            {
                return false;
            }

            if (relationCluster == null)
            {
                relationCluster = new RelationCluster();
            }

            bool result = relationCluster.AddObject(systemComponentResult_Temp);
            if (!result)
            {
                return result;
            }

            if (!relationCluster.Contains(systemComponent))
            {
                Add(systemComponent);
            }

            relationCluster.AddRelation(systemComponent, systemComponentResult_Temp);
            return true;
        }

        public bool Add(SystemSpaceResult systemSpaceResult, SystemSpace systemSpace = null)
        {
            SystemSpaceResult systemSpaceResult_Temp = systemSpaceResult?.Clone();
            if (systemSpaceResult_Temp == null)
            {
                return false;
            }

            if (relationCluster == null)
            {
                relationCluster = new RelationCluster();
            }

            bool result = relationCluster.AddObject(systemSpaceResult_Temp);
            if (!result)
            {
                return result;
            }

            if (systemSpace == null)
            {
                return result;
            }

            if (!relationCluster.Contains(systemSpace))
            {
                Add(systemSpace);
            }

            relationCluster.AddRelation(systemSpace, systemSpaceResult_Temp);
            return true;
        }

        public List<SystemSpace> GetSystemSpaces()
        {
            return relationCluster?.GetObjects<SystemSpace>()?.ConvertAll(x => new SystemSpace(x));
        }

        public List<T> GetSystemComponents<T>() where T : ISystemComponent
        {
            return relationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x)).ConvertAll(x => (T)(object)x);
        }

        public List<ISystemComponent> GetSystemComponents()
        {
            return GetSystemComponents<ISystemComponent>();
        }

        public List<T> GetSystemSpaceComponents<T>(SystemSpace systemSpace) where T : ISystemSpaceComponent
        {
            return relationCluster?.GetRelatedObjects<T>(systemSpace).ConvertAll(x => x.Clone());
        }

        public SystemSpace GetSystemSpace(ISystemSpaceComponent systemSpaceComponent)
        {
            if(systemSpaceComponent == null)
            {
                return null;
            }

            return relationCluster?.GetRelatedObjects<SystemSpace>(systemSpaceComponent)?.FirstOrDefault();
        }

        public List<ISystemResult> GetSystemResults(ISystemObject systemObject)
        {
            return GetSystemResults<ISystemResult>(systemObject);
        }

        public List<T> GetSystemResults<T>(ISystemObject systemObject) where T : ISystemResult
        {
            if (relationCluster == null || systemObject == null)
            {
                return null;
            }

            return relationCluster.GetRelatedObjects<T>(systemObject)?.ConvertAll(x => Core.Query.Clone(x));
        }

        public List<T> GetSystemResults<T>() where T : ISystemResult
        {
            return relationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x));
        }

        public List<ISystemResult> GetSystemResults()
        {
            return GetSystemResults<ISystemResult>();
        }

        public T Find<T>(Func<T, bool> func) where T :ISystemObject, IJSAMObject
        {
            T t = relationCluster.GetObjects<T>(func).FirstOrDefault();
            if (t == null)
            {
                return t;
            }

            return t.Clone();
        }

        public List<T> FindAll<T>(Func<T, bool> func) where T : ISystemObject, IJSAMObject
        {
            List<T> ts = relationCluster.GetObjects<T>(func);
            if (ts == null)
            {
                return ts;
            }

            return ts.ConvertAll(x => x.Clone());
        }

        public List<ISystemObject> GetRelatedObjects(ISystemObject systemObject, Type type = null)
        {
            if (systemObject == null)
            {
                return null;
            }

            List<object> objects = type == null ? relationCluster?.GetRelatedObjects(systemObject, typeof(ISystemObject)) : relationCluster.GetRelatedObjects(systemObject, type);
            if (objects == null)
            {
                return null;
            }

            List<ISystemObject> result = new List<ISystemObject>();
            foreach (object @object in objects)
            {
                ISystemObject systemObject_Temp = (@object as IJSAMObject)?.Clone() as ISystemObject;
                if (systemObject_Temp == null)
                {
                    continue;
                }

                result.Add(systemObject_Temp);
            }

            return result;
        }

        public List<T> GetRelatedObjects<T>(ISystemObject systemObject) where T : ISystemObject, IJSAMObject
        {
            if (systemObject == null)
            {
                return null;
            }

            List<ISystemObject> systemObjects = GetRelatedObjects(systemObject, typeof(T));
            if (systemObjects == null)
            {
                return null;
            }

            List<T> result = new List<T>();
            foreach (T systemObject_Temp in systemObjects)
            {
                result.Add(systemObject_Temp);
            }

            return result;
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
