# Project Context

## Project

- Unity project located in `D:\Unity Projects\Graffiti`.
- Unity Editor version: `6000.6.7f1`.
- The project uses URP: a Universal Render Pipeline asset is assigned in Graphics Settings, and pipeline assets are also assigned to the quality levels. It includes packages such as Cinemachine, Input System, TextMeshPro/UI, Timeline, AI Navigation, and Unity Test Framework.
- A Unity MCP package (`com.ivanmurzak.unity.mcp`) is installed.
- Project assets include `Assets\ZonaShow`, `Assets\Malbers Animations`, `Assets\Multiplayer-Chat-using-Netcode-for-Gameobjects-with-Unity-main`, `Assets\Plugins`, and `Assets\Scenes`.
- The CW plugins include `PaintCore`, intended as a reusable engine for painting on arbitrary surfaces, plus `PaintIn3D` and `CW.Common`.

## Third-party tools and plugins

- Document source or asset changes to third-party tools in this context, noting the affected tool/file, what changed, and why. Keep a separate summary for larger plugin overviews.
- PaintCore change: `Assets\Plugins\CW\PaintCore\Required\Scripts\CwColor.cs` — replaced `[SerializeField]` on the nested `Contribution` class with `[System.Serializable]`, because the original attribute caused compiler error CS0592. The PaintCore assembly builds after this correction.
- See `Resumo PaintCore.md` for the plugin overview and license notes.

## Current conversation context

- The user wants this file to preserve project context and be updated as we learn or make meaningful changes across the project.
- Although the project is configured to use URP, the user expected it to be using Unity's Built-in Render Pipeline. Whether that expectation is a desired change or just a mistaken assumption is not yet confirmed.
- The project has a `ChatManager` script at `Assets\ZonaShow\Scripts\ChatManager.cs`. It creates chat messages from a prefab, displays them under a `CanvasGroup`, and sends the input text when Return is pressed.
- `ChatManager` uses TextMeshPro and Unity's legacy `Input.GetKeyDown(KeyCode.Return)` API, while the Input System package is also installed.
- The ZonaShow scripts currently include `ChatManager.cs`, `ChatMessage.cs`, and `ZsAnimal\ZsAnimal.cs`. This is not a complete inventory of the project.

## Markdown documents

- Project planning and context documents are in `Context\`:
  - `Context.md` — project context.
  - `Resumo PaintCore.md` — overview of PaintCore, its role in the CW painting plugins, project integration, and license notes.
  - `Backlog.md` — project backlog.
  - `GDD_Craft Again.md` — game design document.
  - `gdd_zona_show.md` — Zona Show GDD.
- Unity MCP skill documentation is in `.claude\skills\` (`SKILL.md` files).
- The multiplayer chat example has its README at `Assets\Multiplayer-Chat-using-Netcode-for-Gameobjects-with-Unity-main\README.md`.

## Maintenance

Update this document when the user shares durable project decisions, when implementation work meaningfully changes the architecture, workflows, or important behavior, and whenever a third-party tool or plugin is modified. Keep confirmed facts separate from assumptions, and avoid recording transient debugging details.
