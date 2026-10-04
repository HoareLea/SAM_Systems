# SAM_Systems Part O PR1 progress

Base: `sow/2026-Q3`. PR1 merged as SAM-BIM/SAM_Systems#35 at `301d0fa9a8b2e8b4a6c40f81c8cf45cfa253cddf` on 2026-10-04. Local base updated.

## Completed
Removed largest-supply room heuristic; guidance settings carry explicit CoolingStatSpaceGuid and reject missing, unserved or unsupplied rooms before graph creation. No airflow or equipment physics changed.

## Files changed
MechanicalVentilationGuidanceSettings, Create.MechanicalVentilationGuidanceCooling, MechanicalVentilationGuidanceCooling, guidance/mixed cooling/system scope tests; this progress file.

## Validation
Focused guidance tests: 11 passed; mixed cooling/scope: 46 passed; broader mechanical ventilation/unit suite: 260 passed; PR Windows build and SPDX passed.

## Next step
No unresolved PR1 issues. Stop after PR1; do not start PR2 without a new request.
