using System.ComponentModel;

namespace SAM.Analytical.Systems
{
    [Description("Curve Modifier Type")]
    public enum CurveModifierType
    {
        [Description("Linear")] Linear,
        [Description("Bi-Linear")] BiLinear,
        [Description("Tri-Linear")] TriLinear,
        [Description("Quadratic")] Quadratic,
        [Description("Bi-Quadratic")] BiQuadratic,
        [Description("Tri-Quadratic")] TriQuadratic,
        [Description("Cubic")] Cubic,
        [Description("Bi-Cubic")] BiCubic,
    }
}
