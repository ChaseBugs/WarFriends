# Co-op HUD scene and frame verification

## MainScene output

`UnityCoopHudSceneAudit.Run` opens the recovered MainScene in the disposable
Unity 2018.3 project. It uses the scene's actual
`TimeAndProgressHudGuiElement`, serialized NGUI labels/sprite, mission manager
and co-op controller. The MainScene bytes match both the active Client and the
reviewed mission catalog source SHA-256.

The audit loads the recovered English asset into an in-memory Localization
dictionary without writing PlayerPrefs. It selects the first source catalog
row for each objective type, uses owned co-op adapter snapshots, and invokes
the production HUD Show/Update methods. It saves neither the source scene nor
modified Client assets.

At twenty elapsed host seconds, the observed component values are:

| Mission | Actual objective label | Actual time label | Progress area |
| --- | --- | --- | --- |
| Kill, source index 0 | `KILL 4 / 10` | `01:40` | Visible, fill 0.4. |
| Survive, source index 1 | `SURVIVE FOR 60s` | `00:40` | Visible, fill approximately 1/3. |
| Score, source index 3 | `SCORE 15 / 280` | `01:40` | Visible, fill approximately 15/280. |
| Boss, source index 4 | Not displayed. | `02:40` | Hidden by the recovered Boss rule. |

The hidden Boss part retains its preceding label/fill internally; those values
are not a displayed Boss objective. Fourteen assertions verify the serialized
bindings and actual component outputs. The generated
`coop-hud-scene-audit.json` records the observed strings, fill and visibility.

## Automatic Unity frame updates

`UnityCoopHudPlayAudit.Run` copies the recovered HUD object into an isolated
empty scene, disables unrelated scripts, and enters real Play Mode. Minimal
inactive dependencies supply the existing manager/adapter/formatter path.
Normal scene-wide InitControls/layout is deliberately outside this audit;
the source HUD's Update itself remains enabled and scheduled by Unity.

The audit never invokes Update manually. It checks a host state showing
`KILL 4 / 10`, `01:40`, fill 0.4; then publishes a later host state and observes
`KILL 6 / 10`, `01:30`, fill 0.6 on subsequent frames. Finally, it holds the
host tick unchanged for at least ten frames and one real-time second and
requires the same display. Local time therefore cannot independently reduce
the confirmed mission countdown. Eight assertions cover the bindings, enabled
source behaviour and three output observations. A startup/Play Mode watchdog
fails rather than waiting indefinitely.

The Play report records frame count, the real frozen observation duration and
the final actual objective/time strings. The isolated connection uses no
Photon room, gameplay commands, Backend rewards or normal Worker admission.

## Reproduction and remaining scope

In a disposable recovered project with the current networking SDK and source
scripts, copy both audit tools into Assets/Editor. Copy
`Server/content/recovered-mission-catalog.json` to the project root as
`coop-hud-mission-catalog.json`. Run the two execute methods sequentially with
Unity batch mode. Do not run them against the owner's active Editor project.
Reports are written in that disposable project's root.

These prove scene component formatting and isolated automatic frame scheduling.
They do not prove rendered pixels, normal layout/bootstrap, all 75 missions,
Android, two normal gameplay Clients, complete combat or durable settlement.
The full BattleServer checklist remains partial.

Windows verification: the final MainScene run passes fourteen checks. The
final Play Mode run passes eight checks over 164 Unity frames, including a
1.007-second frozen-host observation. Both processes complete shutdown. The
protocol executable remains at 1,092 passing checks; no Server runtime, active
Client asset/code or installed SDK is changed in this verification checkpoint.
The initial tool compile encountered the recovered duplicate SceneManager
type; scene transfer now resolves the native type from the Editor-returned
Scene assembly without altering the owner's compatibility library.
