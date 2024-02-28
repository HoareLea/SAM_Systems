using SAM.Analytical.Grasshopper.Systems.Properties;
using SAM.Analytical.Systems;
using SAM.Core.Grasshopper;
using System;

namespace SAM.Analytical.Grasshopper.Systems
{
    public class SAMAnalyticalSystemComponentType : GH_SAMEnumComponent<AnalyticalSystemComponentType>
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("75997483-9ed7-4404-afd8-627144405160");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.1";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM_Small;

        /// <summary>
        /// About SAM Enum Component
        /// </summary>
        public SAMAnalyticalSystemComponentType()
          : base("SAM.AnalyticalSystemComponentType", "SAM.AnalyticalSystemComponentType",
              "AnalyticalSystemComponentType",
              "SAM WIP", "Systems")
        {
        }
    }
}