using Rhino.DocObjects;
using Rhino;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using Grasshopper.Kernel.Data;
using Rhino.DocObjects.Tables;
using SAM.Analytical.Systems;
using System.Linq;
using Grasshopper.Kernel.Types;

namespace SAM.Analytical.Grasshopper.Systems
{
    public static partial class Modify
    {
        public static void BakeGeometry_ByType(this RhinoDoc rhinoDoc, IGH_Structure gH_Structure)
        {
            if (rhinoDoc == null)
            {
                return;
            }

            List<ISystemJSAMObject> systemJSAMObjects = new List<ISystemJSAMObject>();
            List<SystemPlantRoom> systemPlantRooms = new List<SystemPlantRoom>();
            List<SystemEnergyCentre> systemEnergyCentres = new List<SystemEnergyCentre>();

            foreach (var variable in gH_Structure.AllData(true))
            {
                object @object = variable;
                if (variable is IGH_Goo)
                {
                    @object = ((dynamic)variable).Value;
                }

                if (@object is SystemEnergyCentre)
                {
                    systemEnergyCentres.Add((SystemEnergyCentre)@object);
                }
                else if (@object is SystemPlantRoom)
                {
                    systemPlantRooms.Add((SystemPlantRoom)@object);
                }
                else if (@object is ISystemJSAMObject)
                {
                    systemJSAMObjects.Add((ISystemJSAMObject)@object);
                }
            }

            if (systemJSAMObjects.Count != 0)
            {
                BakeGeometry_ByType(rhinoDoc, systemJSAMObjects);
            }

            if (systemEnergyCentres.Count != 0)
            {
                systemEnergyCentres.ForEach(x => BakeGeometry_ByType(rhinoDoc, x));
            }

            if (systemPlantRooms.Count != 0)
            {
                systemPlantRooms.ForEach(x => BakeGeometry_ByType(rhinoDoc, x));
            }

        }

        public static void BakeGeometry_ByType(this RhinoDoc rhinoDoc, SystemEnergyCentre systemEnergyCentre)
        {
            if (systemEnergyCentre == null)
            {
                return;
            }

            LayerTable layerTable = rhinoDoc?.Layers;
            if (layerTable == null)
            {
                return;
            }

            Layer layer = AddSystemEnergyCentreLayer(layerTable);

            foreach (SystemPlantRoom systemPlantRoom in systemEnergyCentre.GetSystemPlantRooms())
            {
                BakeGeometry_ByType(rhinoDoc, systemPlantRoom, layer);
            }
        }

        public static void BakeGeometry_ByType(this RhinoDoc rhinoDoc, SystemPlantRoom systemPlantRoom, Layer layer = null)
        {
            LayerTable layerTable = rhinoDoc?.Layers;
            if (layerTable == null)
            {
                return;
            }

            Layer layer_Parent = layer == null ? AddSystemEnergyCentreLayer(layerTable) : layer;
            if (layer_Parent == null)
            {
                return;
            }

            int index = -1;

            index = layerTable.Add();
            Layer layer_SystemPlantRoom = layerTable[index];
            layer_SystemPlantRoom.Name = systemPlantRoom.Name;
            layer_SystemPlantRoom.ParentLayerId = layer_Parent.Id;

            ObjectAttributes objectAttributes = rhinoDoc.CreateDefaultAttributes();

            List<ISystem> systems = systemPlantRoom.GetSystems();
            if (systems != null && systems.Count != 0)
            {
                systems.Sort((x, y) => (x as SystemObject).Name.CompareTo((y as SystemObject).Name));

                List<ISystem> systems_Temp = systems.FindAll(x => x is AirSystem);
                systems.RemoveAll(x => systems_Temp.Contains(x));
                systems.AddRange(systems_Temp);

                foreach (ISystem system in systems)
                {
                    if (!(system is AirSystem) && system.GetType() != typeof(LiquidSystem))
                    {
                        continue;
                    }

                    index = layerTable.Add();
                    Layer layer_System = layerTable[index];
                    layer_System.Name = (system as SystemObject).Name;
                    layer_System.ParentLayerId = layer_SystemPlantRoom.Id;

                    List<ISystemJSAMObject> systemJSAMObjects = systemPlantRoom.GetRelatedObjects<ISystemJSAMObject>(system);
                    if (systemJSAMObjects == null || systemJSAMObjects.Count == 0)
                    {
                        continue;
                    }

                    Dictionary<string, List<ISystemJSAMObject>> dictionary = new Dictionary<string, List<ISystemJSAMObject>>();
                    foreach (ISystemJSAMObject systemJSAMObject in systemJSAMObjects)
                    {
                        string groupName = systemPlantRoom.GetRelatedObjects<AirSystemGroup>(systemJSAMObject)?.FirstOrDefault()?.Name;
                        if (groupName == null)
                        {
                            groupName = string.Empty;
                        }

                        if (!dictionary.TryGetValue(groupName, out List<ISystemJSAMObject> systemJSAMObjects_Group) || systemJSAMObjects_Group == null)
                        {
                            systemJSAMObjects_Group = new List<ISystemJSAMObject>();
                            dictionary[groupName] = systemJSAMObjects_Group;
                        }

                        systemJSAMObjects_Group.Add(systemJSAMObject);
                    }

                    foreach (KeyValuePair<string, List<ISystemJSAMObject>> keyValuePair in dictionary)
                    {
                        layer_Parent = layer_System;
                        if (!string.IsNullOrWhiteSpace(keyValuePair.Key))
                        {
                            index = layerTable.Add();
                            layer_Parent = layerTable[index];
                            layer_Parent.Name = keyValuePair.Key;
                            layer_Parent.ParentLayerId = layer_System.Id;
                        }

                        BakeGeometry_ByType(rhinoDoc, keyValuePair.Value, layer_Parent);
                    }
                }
            }
        }

        public static void BakeGeometry_ByType(this RhinoDoc rhinoDoc, List<ISystemJSAMObject> systemJSAMObjects, Layer layer = null)
        {
            LayerTable layerTable = rhinoDoc?.Layers;
            if (layerTable == null)
            {
                return;
            }

            Layer layer_Parent = layer == null ? AddSystemEnergyCentreLayer(layerTable) : layer;
            if (layer_Parent == null)
            {
                return;
            }

            ObjectAttributes objectAttributes = rhinoDoc.CreateDefaultAttributes();


            List<Guid> guids = new List<Guid>();

            foreach (ISystemJSAMObject systemJSAMObject in systemJSAMObjects)
            {
                string name = systemJSAMObject?.GetType()?.Name;
                if (string.IsNullOrEmpty(name))
                {
                    return;
                }

                Layer layer_Temp = Core.Rhino.Modify.GetLayer(layerTable, layer_Parent.Id, name, Analytical.Systems.Query.Color(systemJSAMObject.GetType()));

                objectAttributes.LayerIndex = layer_Temp.Index;

                if (BakeGeometry(systemJSAMObject, rhinoDoc, objectAttributes, out Guid guid) && guid != Guid.Empty)
                {
                    guids.Add(guid);
                }
            }
        }
    }
}