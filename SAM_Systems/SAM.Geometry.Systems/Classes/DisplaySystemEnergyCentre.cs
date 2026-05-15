// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors
using System.Text.Json.Nodes;
using SAM.Core.Systems;

namespace SAM.Geometry.Systems
{
    public class DisplaySystemEnergyCentre : SystemEnergyCentre<DisplaySystemPlantRoom>
    {
        public DisplaySystemEnergyCentre(string name)
            : base(name)
        {

        }

        public DisplaySystemEnergyCentre(JsonObject jObject)
            : base(jObject)
        {

        }

        public DisplaySystemEnergyCentre(DisplaySystemEnergyCentre displaySystemEnergyCentre)
            : base(displaySystemEnergyCentre)
        {

        }
    }
}
