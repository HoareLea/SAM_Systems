using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAM.Core.Systems
{
    public class SystemPlantRoom : SAMObject, ISystemSpatialObject
    {
        private SystemRelationCluster systemRelationCluster;

        public SystemPlantRoom(SystemPlantRoom systemPlantRoom)
            :base(systemPlantRoom)
        {
            if(systemPlantRoom != null)
            {
                systemRelationCluster = systemPlantRoom?.systemRelationCluster == null ? null : new SystemRelationCluster(systemPlantRoom.systemRelationCluster, true);
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

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            return systemRelationCluster.AddObject(new SystemSpace(systemSpace));
        }

        public bool Add(ISystemComponent systemComponent)
        {
            ISystemComponent systemComponent_Temp = systemComponent?.Clone();
            if (systemComponent_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            return systemRelationCluster.AddObject(systemComponent_Temp);
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

            if (!systemRelationCluster.Contains(systemSpace))
            {
                Add(systemSpace);
            }

            systemRelationCluster.AddRelation(systemSpace, systemSpaceComponent);
            return true;
        }

        public bool Add(ISystemComponentResult systemEquipmentResult, ISystemComponent systemComponent = null)
        {
            ISystemComponentResult systemComponentResult_Temp = systemEquipmentResult?.Clone();
            if (systemComponentResult_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            bool result = systemRelationCluster.AddObject(systemComponentResult_Temp);
            if (!result)
            {
                return result;
            }

            if (!systemRelationCluster.Contains(systemComponent))
            {
                Add(systemComponent);
            }

            systemRelationCluster.AddRelation(systemComponent, systemComponentResult_Temp);
            return true;
        }

        public bool Add(ISystemSpaceResult systemSpaceResult, SystemSpace systemSpace = null)
        {
            ISystemSpaceResult systemSpaceResult_Temp = systemSpaceResult?.Clone();
            if (systemSpaceResult_Temp == null)
            {
                return false;
            }

            if (systemRelationCluster == null)
            {
                systemRelationCluster = new SystemRelationCluster();
            }

            bool result = systemRelationCluster.AddObject(systemSpaceResult_Temp);
            if (!result)
            {
                return result;
            }

            if (systemSpace == null)
            {
                return result;
            }

            if (!systemRelationCluster.Contains(systemSpace))
            {
                Add(systemSpace);
            }

            systemRelationCluster.AddRelation(systemSpace, systemSpaceResult_Temp);
            return true;
        }

        public List<SystemSpace> GetSystemSpaces()
        {
            return systemRelationCluster?.GetObjects<SystemSpace>()?.ConvertAll(x => new SystemSpace(x));
        }

        public List<T> GetSystemComponents<T>() where T : ISystemComponent
        {
            return systemRelationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x)).ConvertAll(x => (T)(object)x);
        }

        public List<ISystemComponent> GetSystemComponents()
        {
            return GetSystemComponents<ISystemComponent>();
        }

        public List<T> GetSystemSpaceComponents<T>(SystemSpace systemSpace) where T : ISystemSpaceComponent
        {
            return systemRelationCluster?.GetRelatedObjects<T>(systemSpace).ConvertAll(x => x.Clone());
        }

        public SystemSpace GetSystemSpace(ISystemSpaceComponent systemSpaceComponent)
        {
            if(systemSpaceComponent == null)
            {
                return null;
            }

            return systemRelationCluster?.GetRelatedObjects<SystemSpace>(systemSpaceComponent)?.FirstOrDefault();
        }

        public List<ISystemResult> GetSystemResults(ISystemJSAMObject systemJSAMObject)
        {
            return GetSystemResults<ISystemResult>(systemJSAMObject);
        }

        public List<T> GetSystemResults<T>(ISystemJSAMObject systemJSAMObject) where T : ISystemResult
        {
            if (systemRelationCluster == null || systemJSAMObject == null)
            {
                return null;
            }

            return systemRelationCluster.GetRelatedObjects<T>(systemJSAMObject)?.ConvertAll(x => Core.Query.Clone(x));
        }

        public List<T> GetSystemResults<T>() where T : ISystemResult
        {
            return systemRelationCluster?.GetObjects<T>()?.ConvertAll(x => Core.Query.Clone(x));
        }

        public List<ISystemResult> GetSystemResults()
        {
            return GetSystemResults<ISystemResult>();
        }

        public T Find<T>(Func<T, bool> func) where T : ISystemJSAMObject
        {
            T t = systemRelationCluster.GetObjects<T>(func).FirstOrDefault();
            if (t == null)
            {
                return t;
            }

            return t.Clone();
        }

        public List<T> FindAll<T>(Func<T, bool> func) where T : ISystemJSAMObject
        {
            List<T> ts = systemRelationCluster.GetObjects<T>(func);
            if (ts == null)
            {
                return ts;
            }

            return ts.ConvertAll(x => x.Clone());
        }

        public List<ISystemJSAMObject> GetRelatedObjects(ISystemJSAMObject systemJSAMObject, Type type = null)
        {
            if (systemJSAMObject == null)
            {
                return null;
            }

            List<ISystemJSAMObject> objects = type == null ? systemRelationCluster?.GetRelatedObjects(systemJSAMObject, typeof(ISystemJSAMObject)) : systemRelationCluster.GetRelatedObjects(systemJSAMObject, type);
            if (objects == null)
            {
                return null;
            }

            List<ISystemJSAMObject> result = new List<ISystemJSAMObject>();
            foreach (ISystemJSAMObject @object in objects)
            {
                ISystemJSAMObject systemObject_Temp = @object?.Clone() as ISystemJSAMObject;
                if (systemObject_Temp == null)
                {
                    continue;
                }

                result.Add(systemObject_Temp);
            }

            return result;
        }

        public List<T> GetRelatedObjects<T>(ISystemJSAMObject systemJSAMObject) where T : ISystemJSAMObject
        {
            if (systemJSAMObject == null)
            {
                return null;
            }

            List<ISystemJSAMObject> systemObjects = GetRelatedObjects(systemJSAMObject, typeof(T));
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
