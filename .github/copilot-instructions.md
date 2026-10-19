# GitHub Copilot Instructions for "Show Detailed Dates" Mod

## Mod Overview and Purpose

The "Show Detailed Dates" mod enhances the vanilla RimWorld experience by allowing players to see the exact hour of in-game events in the history tab when the ALT key is pressed. This feature is particularly useful for players interested in tracking detailed event logs or analyzing the sequence of events in their game.

**Mod Details:**
- **Mod Name:** Show Detailed Dates
- **Display Name:** Show Detailed Dates
- **Author:** Mlie
- **PackageId:** Mlie.ShowDetailedDates
- **Dependencies:** brrainz.harmony

## Key Features and Systems

- **Detailed Date Display:** By pressing the ALT key, players can view the exact hour an event occurred in the history tab.
- **Integration with RimWorld's History Tab:** The mod directly modifies how events are displayed in the history tab without altering any core files.
  
## Coding Patterns and Conventions

### General Patterns

- **Naming Conventions:** Classes and methods follow CamelCase naming conventions, ensuring clarity and consistency.
- **Code Organization:** The code is organized into clear and concise methods that encapsulate specific functionality.

### C# Files

- **ShowDetailedDates.cs:** Contains the main class `ShowDetailedDates` which serves as an entry point or initializer for the mod functionalities.
- **MainTabWindow_History_DoArchivableRow.cs:** Modifies the display logic of the history tab and includes a transpiler method. Contains:
  - **Types:** `MainTabWindow_History_DoArchivableRow`
  - **Members:** `conditionalDateString`, `Transpiler`

## XML Integration

While this mod does not include any XML files, understanding XML mod integration in RimWorld is crucial for modders generally looking to add new definitions or modify existing ones. Ensure XML files are well-formed and adhere to RimWorld's expected schema when applicable.

## Harmony Patching

- **Transpiler Patching:** The method `Transpiler` in the `MainTabWindow_History_DoArchivableRow` class utilizes Harmony to patch the existing methods in RimWorld's codebase. 
- **Best Practices:** Always use Harmony patches carefully to avoid conflicts with other mods. They should be tested thoroughly to ensure stability and compatibility.

## Suggestions for Copilot

- **Code Suggestions:** When writing new methods or classes, you can prompt Copilot for suggestions by writing a clear comment about the desired functionality.
- **Patching Assistance:** Use comments to describe the target method and expected outcome when employing Harmony; this will guide Copilot in generating appropriate patching code.
- **Debugging Help:** Encourage Copilot to assist with debugging by prompting it to suggest ways to implement logging or error-checking mechanisms.
- **Refactoring Tips:** If restructuring your code for efficiency, ask Copilot to evaluate the existing code and suggest possible improvements in terms of performance and readability.

Use these Copilot instructions to efficiently modify and extend the functionality of the "Show Detailed Dates" mod. Happy Modding!

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

