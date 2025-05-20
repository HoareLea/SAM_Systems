using Rhino.DocObjects;
using Rhino;
using SAM.Core.Systems;
using System;
using System.Collections.Generic;
using SAM.Geometry.Systems;
using SAM.Geometry.Object.Planar;
using System.Linq;
using SAM.Analytical.Systems;


namespace SAM.Analytical.Grasshopper.Systems
{
    public static partial class Modify
    {
        public static bool BakeGeometry(this ISystemJSAMObject systemJSAMObject, RhinoDoc doc, ObjectAttributes att, out Guid guid)
        {
            guid = Guid.Empty;
            if (systemJSAMObject == null)
            {
                return false;
            }
            ISAMGeometry2DObject sAMGeometry2DObject = null;

            if (systemJSAMObject is IDisplaySystemObject)
            {
                sAMGeometry2DObject = Analytical.Systems.Query.SAMGeometry2Dobject((IDisplaySystemObject)systemJSAMObject);
            }

            if (sAMGeometry2DObject == null)
            {
                return false;
            }

            bool result = Geometry.Rhino.Modify.BakeGeometry(sAMGeometry2DObject, doc, att, out List<Guid> guids);
            if (!result)
            {
                return false;
            }

            if (guids == null || guids.Count == 0)
            {
                return false;
            }

            if (systemJSAMObject is SystemObject)
            {
                int linetypeIndex = -1;
                double linetypePatternScale = 1;

                if (systemJSAMObject is SystemConnection)
                {
                    SystemConnection systemConnection = (SystemConnection)systemJSAMObject;

                    List<Core.ObjectReference> objectReferences = systemConnection.ObjectReferences;
                    if(objectReferences != null)
                    {
                        foreach(Core.ObjectReference objectReference in objectReferences)
                        {
                            Type type = Core.Query.Type(objectReference.TypeName, true);
                            if(type != null && typeof(SystemController).IsAssignableFrom(type))
                            {
                                linetypeIndex = RhinoDoc.ActiveDoc.Linetypes.Find("Hidden");
                                linetypePatternScale = 0.5;
                            }
                        }
                    }
                }
                else if(systemJSAMObject is SystemSensor)
                {
                    linetypeIndex = RhinoDoc.ActiveDoc.Linetypes.Find("Dots");
                    linetypePatternScale = 0.1;
                }

                SystemObject systemObject = (SystemObject)systemJSAMObject;
                foreach(Guid guid_Temp in guids)
                {
                    RhinoObject rhinoObject = doc?.Objects?.FindId(guid_Temp);
                    if(rhinoObject != null)
                    {
                        ObjectAttributes objectAttributes = rhinoObject.Attributes;

                        if (linetypeIndex != -1)
                        {
                            objectAttributes.LinetypeSource = ObjectLinetypeSource.LinetypeFromObject;
                            objectAttributes.LinetypeIndex = linetypeIndex;
                            objectAttributes.LinetypePatternScale = linetypePatternScale;
                        }

                        objectAttributes.Name = systemObject.Name;
                        objectAttributes.SetUserString("Description", systemObject.Description);
                        rhinoObject.CommitChanges();
                    }
                }
            }

            if (guids.Count == 1)
            {
                guid = guids[0];
                return result;
            }

            int index = doc.Groups.Add(Guid.NewGuid().ToString());

            Group group = doc.Groups.ElementAt(index);

            foreach (Guid guid_Temp in guids)
            {
                if(doc.Groups.AddToGroup(index, guid_Temp))
                {
                }
            }

            guid = group.Id;
            return result;
        }
    }
}