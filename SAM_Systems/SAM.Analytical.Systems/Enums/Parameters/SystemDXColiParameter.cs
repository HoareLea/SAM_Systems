// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

using System.ComponentModel;
using SAM.Core.Attributes;

namespace SAM.Analytical.Systems
{
    [AssociatedTypes(typeof(SystemDXCoil)), Description("System DX Coil Parameter")]
    public enum SystemDXCoilParameter
    {
        [ParameterProperties("Refrigerant Collection", "Refrigerant Collection"), SAMObjectParameterValue(typeof(CollectionLink))] RefrigerantCollection,
    }
}
