# Project Context

## Project

- Unity project located in `D:\Unity Projects\Graffiti`.
- Unity Editor version: `6000.6.7f1`.
- The project uses URP: a Universal Render Pipeline asset is assigned in Graphics Settings, and pipeline assets are also assigned to the quality levels. It includes packages such as Cinemachine, Input System, TextMeshPro/UI, Timeline, AI Navigation, and Unity Test Framework.
- A Unity MCP package (`com.ivanmurzak.unity.mcp`) is installed.
- Project assets include `Assets\ZonaShow`, `Assets\Malbers Animations`, `Assets\Multiplayer-Chat-using-Netcode-for-Gameobjects-with-Unity-main`, `Assets\Plugins`, and `Assets\Scenes`.
- The CW plugins include `PaintCore`, intended as a reusable engine for painting on arbitrary surfaces, plus `PaintIn3D` and `CW.Common`.

## Asset naming

- Use the following general structure: `<type>_<project>_<category>_<name>[_variant][_number]`.
- Use PascalCase for descriptive segments and keep prefixes and channel abbreviations in uppercase.
- Separate logical segments with `_`; do not combine variant, channel or version information into one unstructured segment.
- Primary asset prefixes:
  - `SM` — Static Mesh.
  - `SK` — Skeletal Mesh.
  - `M` — Material.
  - `T` — Texture.
  - `P` — Prefab.
  - `S` — Scene.
  - `A` — Audio.
- Project and category abbreviations:
  - `ZS` — Zona Show.
  - `BLK` — Blockout.
  - `ENV` — Environment.
  - `CHAR` — Character.
  - `VFX` — Visual effects.
- Materials use `M_<project>_<category>_<name>[_variant][_number]`.
  - Examples: `M_ZS_BLK_Atlas`, `M_ZS_BLK_Atlas_Red`, `M_ZS_BLK_Atlas_Red_01`, `M_ZS_ENV_FloorConcrete`, `M_ZS_CHAR_Player`.
- Prefer the material's function or visual family over implementation details. `Atlas` is appropriate when the material represents a reusable color atlas; it is not a replacement for the variant or the category.
- Static Meshes use `SM_<project>_<category>_<name>[_variant][_number].fbx`.
  - Examples: `SM_ZS_ENV_WallBrick_01.fbx`, `SM_ZS_BLK_Cube_01.fbx`, `SM_ZS_PROPS_Bench_Wood_01.fbx`.
- Skeletal Meshes use `SK_<project>_<category>_<name>[_variant][_number].fbx`.
  - Examples: `SK_ZS_CHAR_Player_01.fbx`, `SK_ZS_CHAR_DogFila_01.fbx`.
- Distinguish generated Unity assets from source files by folder and type, not only by name. Imported Unity meshes may retain or receive the mesh prefix automatically, while source `.fbx` files keep the same prefix and remain grouped by exporter/origin folders.
- Use an additional type prefix for special mesh categories when needed:
  - `COL` — Collision mesh or simplified collision geometry.
  - `LOD` — Explicit level-of-detail mesh.
  - `RIG` — Rig/skeleton-only source file.
- For an environment kit, use semantic names instead of generic names:
  - `SM_ZS_ENV_WallConcrete_Corner_01.fbx`
  - `SM_ZS_PROP_BenchPark_Wood_01.fbx`
- Avoid broad names such as `SM_ZS_OBJ_Thing.fbx` and never use `Final`, `New`, `Copy` or `Fixed` as versions. Use numbered variants or explicit descriptive variants.
- Prefabs use `P_<project>_<category>_<name>[_variant][_number].prefab`.
  - Examples: `P_ZS_ENV_BenchWood_01.prefab`, `P_ZS_CHAR_Player_01.prefab`, `P_ZS_VFX_Fire_Bonfire_01.prefab`.
- A prefab name should describe the reusable object or actor, not its placement or implementation state.
- Use descriptive variants for intentionally different visual or gameplay configurations:
  - `P_ZS_PROP_BenchPark_Wood_01.prefab`
  - `P_ZS_PROP_BenchPark_Metal_01.prefab`
- Reserve `_01`, `_02` and subsequent numbers for concrete variants or repeated asset configurations. Do not use `_Copy`, `_Backup`, `_New` or `_Final`.
- Texture names use `T_<project>_<category>_<name>[_variant]_CH[_number]`, where `CH` identifies the texture channel or purpose.
  - Examples: `T_ZS_BLK_Atlas_01_C`, `T_ZS_BLK_Atlas_01_N`, `T_ZS_BLK_Atlas_01_ORM`.
  - Common channels: `C` — Base Color; `N` — Normal; `ORM` — Occlusion/Roughness/Metallic packed texture; `M` — Metallic; `R` — Roughness; `AO` — Ambient Occlusion; `H` — Height; `D` — Displacement.
- When the asset is already scoped inside a project or category folder, project/category prefixes may be omitted. They should be retained when assets need to be searched or reused outside those folders.

## Gameplay tags

- Objects that provide uneven walking surfaces must use the Unity tag `Stair` exactly; Unity tag names are case-sensitive.
- Apply `Stair` to stairs and irregular walkable surfaces, including debris, small rocks and similar geometry used to improve Malbers movement on uneven terrain.
- The tag should describe movement behavior, not visual category. A staircase made of rock remains `Stair` if it is intended to be traversed as uneven terrain.

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
