# Project Context

## Project

- Unity project located in `D:\Unity Projects\Graffiti`.
- Unity Editor version: `6000.6.7f1`.
- The project uses URP: a Universal Render Pipeline asset is assigned in Graphics Settings, and pipeline assets are also assigned to the quality levels. It includes packages such as Cinemachine, Input System, TextMeshPro/UI, Timeline, AI Navigation, and Unity Test Framework.
- A Unity MCP package (`com.ivanmurzak.unity.mcp`) is installed.
- Project assets include `Assets\ZonaShow`, `Assets\Malbers Animations`, `Assets\Multiplayer-Chat-using-Netcode-for-Gameobjects-with-Unity-main`, `Assets\Plugins`, and `Assets\Scenes`.
- The CW plugins include `PaintCore`, intended as a reusable engine for painting on arbitrary surfaces, plus `PaintIn3D` and `CW.Common`.

## Third-party tools and plugins

- Document source or asset changes to third-party tools in this context, noting the affected tool/file, what changed, and why. Prefer project-specific prefab variants over editing vendor originals. Keep a separate summary for larger plugin overviews.

### Vendor source changes

- PaintCore: `Assets\Plugins\CW\PaintCore\Required\Scripts\CwColor.cs` replaces `[SerializeField]` on the nested `Contribution` class with `[System.Serializable]`; the original attribute caused compiler error CS0592.
- Malbers Animations: `Assets\Malbers Animations\Common\Scripts\Animal Controller\ComboManager.cs` makes `ActiveComboSequence` return `null` if there is no active combo. `OnModeEnd` checks for a missing sequence, but its former property accessed `ActiveCombo.CurrentSequence` before that check and threw when a combo was not selected. This guard was exercised during an attack-release test without reproducing the exception.

### PaintBall prototype

- Scene: `Assets\ZonaShow\Scenes\1 - PlayGround Empty Controller.unity` equips `Steve Player` with `Assets\ZonaShow\Prefabs\Bow PaintBall.prefab`. The variant fires `Assets\ZonaShow\Prefabs\Paint Ball Projectile.prefab`, adapted from PaintIn3D's “Paint Ball Throwing” demo with Malbers `MProjectile` and PaintIn3D `CwPaintDecal`/`CwHitCollisions`. It uses no projectile pool because the projectile is destroyed on impact. `Assets\ZonaShow\Prefabs\Paint Surface.prefab` is the demo paintable mesh, positioned at `(3, 0, 5)` with scale `(0.6, 0.6, 0.6)`.
- Startup and hit bridge: `Assets\ZonaShow\Scripts\PaintBallBowStartup.cs` initializes/equips the configured bow without duplicating the manager's scheduled reset; immediately before firing it re-enables `MProjectile`, `CwPaintDecal`, and `PaintBallProjectilePainter`. `Assets\ZonaShow\Scripts\PaintBallProjectilePainter.cs` forwards `MProjectile.OnRayCastHit` into PaintIn3D's hit cache. The physical `CwHitCollisions` listener stays disabled to prevent duplicate painting.
- Spaceship target: `Space Ship Surface` uses the Spaceship mesh and project copy `Assets\ZonaShow\Spaceship Paint.mat` of the Bricks material. `_UseUV2 = 0` makes `_MainTex` use UV0, matching the paintable mesh's Primary UV channel. Its paint group is 90, matching the projectile decal; it is positioned at `(0.5, 0.9, 7)` in front of the player's runtime spawn `(0, 0, 0)`. UV2 generation remains enabled on the source model but is not used for this setup. The working `01 Basic Setup` scene was the reference for painting `_MainTex` with Primary UV.
- Controls: the player's Malbers weapon inputs are `Action2` to aim and `Action1` to attack.
- Validation limits: a controlled `FireProjectile` test previously changed 260 of 16,384 sampled texture pixels, including 235 yellow paint pixels. A later check confirmed the pre-fire callback restores disabled projectile components and a test raycast hit queues PaintIn3D commands. A complete physical-input shot and a final texture readback after that activation fix have not been verified.

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

- Never delete files or folders inside `Context\`. Their contents may be updated, but the files themselves must be preserved; if a document seems obsolete, keep it rather than deleting it.

Update this document when the user shares durable project decisions, when implementation work meaningfully changes the architecture, workflows, or important behavior, and whenever a third-party tool or plugin is modified. Keep confirmed facts separate from assumptions, and avoid recording transient debugging details.
