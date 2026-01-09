[![Build (Windows)](https://github.com/SAM-BIM/SAM_Systems/actions/workflows/build.yml/badge.svg?branch=master)](https://github.com/SAM-BIM/SAM_Systems/actions/workflows/build.yml)
[![Installer (latest)](https://img.shields.io/github/v/release/SAM-BIM/SAM_Deploy?label=installer)](https://github.com/SAM-BIM/SAM_Deploy/releases/latest)

# SAM_Systems

<a href="https://github.com/SAM-BIM/SAM">
  <img src="https://github.com/SAM-BIM/SAM/blob/master/Grasshopper/SAM.Core.Grasshopper/Resources/SAM_Small.png"
       align="left" hspace="10" vspace="6">
</a>

**SAM_Systems** is part of the **SAM (Sustainable Analytical Model) Toolkit** —  
an open-source collection of tools designed to help engineers create, manage,
and process analytical building models for energy and environmental analysis.

This repository provides **definitions and data models for building systems**
with an initial focus on **HVAC systems**.
It enables system concepts to be defined, configured, and associated with SAM analytical models
in a simulation-agnostic manner.

The system definitions can be connected to external simulation engines,
such as Tas via **SAM_Tas**, to support detailed building performance analysis workflows.

Welcome — and let’s keep the open-source journey going. 🤝

---

## Resources
- 📘 **SAM Wiki:** https://github.com/SAM-BIM/SAM/wiki  
- 🧠 **SAM Core:** https://github.com/SAM-BIM/SAM  
- 🧮 **SAM_Tas:** https://github.com/SAM-BIM/SAM_Tas  
- 🧰 **Installers:** https://github.com/SAM-BIM/SAM_Deploy  

---

## Installing

To install **SAM** using the Windows installer, download and run the  
[latest installer](https://github.com/SAM-BIM/SAM_Deploy/releases/latest).

Alternatively, you can build the toolkit from source using Visual Studio.  
See the main repository for details:  
👉 https://github.com/SAM-BIM/SAM

---

## Development notes

- Target framework: **.NET / C#**
- System models follow SAM-BIM analytical and data-modelling conventions
- New or modified `.cs` files must include the SPDX header from `COPYRIGHT_HEADER.txt`

---

## Licence

This repository is free software licensed under the  
**GNU Lesser General Public License v3.0 or later (LGPL-3.0-or-later)**.

Each contributor retains copyright to their respective contributions.  
The project history (Git) records authorship and provenance of all changes.

See:
- `LICENSE`
- `NOTICE`
- `COPYRIGHT_HEADER.txt`
