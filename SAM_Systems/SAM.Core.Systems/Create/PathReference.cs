namespace SAM.Core.Systems
{
    public static partial class Create
    {
        public static PathReference PathReference(SystemPlantRoom systemPlantRoom, SystemComponent systemComponent) 
        {
            if(systemPlantRoom == null || systemComponent == null)
            {
                return null;
            }

            ObjectReference objectReference_SystemPlantRoom = new ObjectReference(systemPlantRoom);
            if(objectReference_SystemPlantRoom == null)
            {
                return null;
            }

            ObjectReference objectReference_SystemComponent = new ObjectReference(systemComponent);
            if(objectReference_SystemComponent == null)
            {
                return null;
            }

            return new PathReference(new ObjectReference[] { objectReference_SystemPlantRoom, objectReference_SystemComponent });
        }
    }
}