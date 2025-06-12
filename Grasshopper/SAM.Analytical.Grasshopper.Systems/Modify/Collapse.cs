using Rhino.DocObjects;

namespace SAM.Analytical.Grasshopper.Systems
{
    public static partial class Modify
    {
        public static bool Collapse(this Layer layer)
        {
            if (layer == null)
            {
                return false;
            }

            Layer[] layers_1 = layer.GetChildren();
            if(layers_1 == null || layers_1.Length == 0)
            {
                return false;
            }

            bool result = false;
            foreach (Layer layer_1 in layers_1)
            {
                Layer[] layers_2 = layer_1.GetChildren();
                if (layers_2 == null || layers_2.Length == 0)
                {
                    continue;
                }

                foreach(Layer layer_2 in layers_2)
                {
                    layer_2.IsExpanded = false;
                    result = true;
                }
            }

            return result;
        }
    }
}