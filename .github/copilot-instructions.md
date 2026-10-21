# GitHub Copilot Instructions for [SYR] Prosthetic Table (Continued)

## Mod Overview and Purpose

The `[SYR] Prosthetic Table (Continued)` mod is a continuation of the original mod by Syrchalis, designed for `RimWorld`. The primary objective of this mod is to streamline the crafting process for prosthetics by introducing a dedicated workbench specifically for prosthetics. This not only reduces clutter from the existing machining and fabrication benches but also enhances the overall organization of crafting stations.

## Key Features and Systems

- **Dedicated Prosthetics Workbench**: A new workbench is introduced specifically for handling all prosthetic recipes, helping de-clutter the existing workstations.
- **Recipe Transfer**: All existing prosthetic recipes are migrated from the machining and fabrication benches to the new prosthetics table.
- **Compatibility and Support**: While primarily an enhancement to vanilla, this mod also supports other mods using the fabrication and machining tables. However, it is noted that `VFE Production` might reintroduce recipes to the old tables, partially negating the mod's purpose without causing errors.
- **Safe Savegame Integration**: Adding the mod to an existing game is safe, and removing it generates only harmless errors.

## Coding Patterns and Conventions

- The mod follows the standard practices of creating separate classes for different functionalities, such as `RecipeTransfer_Component` and `ProstheticsTableDefOf`.
- The usage of descriptive class and method names makes the code base easy to navigate and understand.
- Ensure methods fulfill single responsibility principles and are appropriately encapsulated.

## XML Integration

- **Defining Objects**: Utilize XML files to define new items, workbenches (`Building_ProstheticsTable.xml`), and work giver definitions (`WorkGiver.xml`).
- **Mod Metadata**: The `About.xml` file details package dependencies, including `Harmony`, which is crucial for mod integration.
- **Translation Support**: Localization is supported through XML definitions (`TranslationTemplate`), enabling future expansions or translations.

## Harmony Patching

- The mod makes use of `Harmony` for patching. This is crucial for altering existing game functions without directly modifying the core code, ensuring compatibility and ease of integration with other mods.
- Patches are set up to modify recipe assignments, ensuring prosthetics are only craftable at the new workbench.
  
## Suggestions for Copilot

- **Consistent Naming Conventions**: When generating code, adhere to the established naming conventions seen within this mod.
- **Harmony Patches**: Suggest patterns for creating prefixes and postfixes using `Harmony` to ensure smooth functionality integration.
- **XML Schema Awareness**: Assist in crafting XML definitions that are consistent with `RimWorld`'s schema requirements.

## Additional Information

- **Compatibility Considerations**: Be mindful of mods like `VFE Production` that might interfere with recipe management.
- **Error Reporting**: Encourage test-mod-only scenarios for bug identification, and utilize the provided Discord channel for support.
- **Documentation and Logs**: Include information on where stack traces or mod errors can be reported, ensuring access to complete logs for troubleshooting.

By adhering to these guidelines, contributors can create enhancements or provide support as needed, ensuring a consistent and high-quality experience for all users of the `[SYR] Prosthetic Table (Continued)` mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

