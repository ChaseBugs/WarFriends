# Code Style

This guide defines how new code is written in this repository: C# for the Unity client and the .NET
server, and TypeScript for backend tooling and the Admin UI. It only governs style. It does not
change behavior, and it never justifies rewriting recovered code.

## Scope

| Code | Rules that apply |
|------|------------------|
| New hand-written Unity client scripts | Common principles, all C# rules, including "Unity specifics" |
| `Server/` and `Tools/` C# | Common principles, C# rules except "Unity specifics" |
| TypeScript (backend tooling, Admin UI) | Common principles, all TypeScript rules |
| Recovered or decompiled code (`Clients/`, Unity `Assets/Scripts/Gameplay*`, `Assets/Scripts/ResourceCompatibility*`, patched plugins) | **Exempt.** It is recovery evidence. Do not reformat or rename it. |
| Generated data (`Server/content/`, `Server/artifacts/`, Unity `.unity`/`.prefab`/`.asset`/`.meta`) | **Exempt.** Its format is owned by the tool that produces it. |

Most existing server C# predates this guide and is written in a dense style. Apply the guide as
follows:

- New files follow this guide completely.
- Small edits to an existing file match the code around them so the diff stays reviewable.
- When a file is substantially rewritten, reformat it to this guide in a **separate commit** that
  contains no behavior change.
- Never run a whole-solution `dotnet format` or `prettier --write .`. Format only the files you own
  in the change.

## Common principles

- **Names come before comments.** A reader should understand what something does from its name alone.
- **One file has one responsibility, and one function does one thing.**
- **Consistency beats personal taste.** Even if you dislike a rule, do not apply it differently file by file.
- **Tools format code, not people.** Run the formatter on save instead of aligning code by hand.
- **English only** for code, comments, file names and commit messages.
- **Maximum line length is 120 characters.** Break longer lines at meaningful boundaries.
- **File hygiene:** UTF-8, LF line endings, no trailing whitespace, exactly one final newline.
  `.gitattributes` entries take precedence where they pin a file's line endings.
- **No magic numbers.** Values such as `5` or `86400` get a named constant.
- **No dead code.** Delete commented-out code and unused variables, imports and functions.
- **Use blank lines to form paragraphs.** Put one blank line between setup, work and result. Never
  use two or more consecutive blank lines.

## C# rules

### 1. Formatting

| Item | Rule |
|------|------|
| Indentation | 4 spaces, no tabs |
| Braces | Allman style: `{` always on its own line |
| Single-line `if` | Not allowed. Always use `{ }`, even for a one-line body |
| Spacing | One space after keywords (`if (x)`, `for (...)`), around binary operators (`a + b`) and after commas |
| Blank lines | One between members (methods, properties) and one after the `using` block |
| Wrapping | When arguments do not fit, put one argument per line and close the parenthesis at the end of the last argument line |
| `var` | Only when the type is obvious from the right-hand side (`var heroes = new List<Hero>();`). Otherwise write the type |
| Namespaces | Unity: block-scoped namespaces compatible with the verified compiler. .NET server: file-scoped namespaces |

### 2. Naming

| Target | Rule | Example |
|--------|------|---------|
| File | Same as the class, PascalCase, one public type per file | `HeroUpgradePanel.cs` |
| Class, struct, enum | PascalCase noun | `PaperHeroShowcase` |
| Interface | `I` + PascalCase | `IRewardSource` |
| Method | PascalCase, starts with a verb | `LoadInventory()`, `ApplyReward()` |
| Public property | PascalCase | `CurrentLevel` |
| Private field | `_camelCase` | `_heroCards` |
| `[SerializeField]` field | `private` + `_camelCase` | `[SerializeField] private Button _closeButton;` |
| Local variable, parameter | camelCase | `rewardCoins` |
| Constant, `static readonly` | PascalCase | `MaxRoomPlayers` |
| Enum value | PascalCase; the enum name is singular | `MatchState.Running` |
| Boolean | Starts with `is`, `has`, `can` or `should` | `isLoaded`, `HasPendingReward` |
| Event, delegate | Past tense, or `On` + verb for handlers | `RewardClaimed`, `OnCloseClicked()` |
| Coroutine | Ends with `Routine` | `FadeInRoutine()` |
| Async method | Ends with `Async` | `FetchProfileAsync()` |
| Acronyms | Up to two letters stay uppercase (`UI`); longer ones capitalize only the first letter (`Http`, `Json`) | `HttpClient`, `UIRoot` |
| Forbidden | `temp`, `data2`, `mgr`, `obj`, single-letter names (except loop index `i`) | |

### 3. File layout

1. `using` directives: `System`, then `UnityEngine`, then third-party, then project namespaces,
   alphabetical within each group. The IDE can only enforce "System first, then alphabetical", so
   keep the remaining grouping by hand.
2. `namespace` matching the folder structure.
3. Member order inside a class:
   constants → static fields → `[SerializeField]` fields → private fields → public properties → events →
   Unity messages (`Awake` → `OnEnable` → `Start` → `Update` → `LateUpdate` → `OnDisable` → `OnDestroy`) →
   public methods → private methods → coroutines → nested types.

Within a group, order members by call sequence: a caller goes above the method it calls.

Do not use `#region`. If a class is big enough to need regions, split the class.

### 4. Functions

- Aim for 40 lines or fewer. A function over 80 lines must be split.
- At most 4 parameters. With more, group them into a settings struct or class.
- Use early returns to reduce nesting. Indentation depth is at most 3 levels.
- Do not mix UI updates and data calculation in the same function.
- Split a function whose behavior depends on a single `bool` argument into two functions
  (`Show()` and `Hide()` instead of `Show(true)`).

### 5. Unity specifics

- No public fields. Expose fields to the Inspector with `[SerializeField] private`.
- No `Find`, `GetComponent`, `new`, LINQ or string concatenation inside `Update`. Cache in `Awake`.
- Define tag strings and Animator parameters once, as constants or `Animator.StringToHash` values.
- A `MonoBehaviour` only wires the scene. Put game rules and calculations in plain C# classes.
- Subscribe to events in `OnEnable` and always unsubscribe in the matching `OnDisable`.
- `Debug.Log` is for local development only. Remove it before committing, or log through a wrapper.
- Organize new folders by feature, not by type: `Assets/_Game/<Feature>/{Runtime, Editor, Tests}`
  rather than `Scripts/Managers`. Recovered folders keep their original layout.

### 6. Comments

- Explain **why**, not what. Only record reasons, constraints and server contracts that the code
  cannot express.
- Give public APIs a one- or two-sentence XML `/// <summary>`.
- Format: `//`, one space, a full sentence ending with a period.
- TODO format: `// TODO(name): what and why`. TODOs without an owner are not allowed.
- Put comments on the line above the code, not at the end of the line.

## TypeScript rules

### 1. Formatting (Prettier)

| Item | Rule |
|------|------|
| Indentation | 2 spaces |
| Quotes | Double quotes `"`, including JSX |
| Semicolons | Always |
| Commas | Trailing comma in multi-line objects, arrays and argument lists |
| Braces | K&R: `{` on the same line. Single-line `if` still uses `{ }` |
| Line length | 120 characters |
| Arrow functions | Parentheses even for one parameter: `(x) => ...` |
| One statement per line | Never write `if(a)return b;const c=...` on one line |

### 2. Naming

| Target | Rule | Example |
|--------|------|---------|
| Regular `.ts` file | camelCase noun describing its contents | `adCampaigns.ts`, `walletExchange.ts` |
| React component file | kebab-case (Next.js convention); the component is PascalCase | `account-detail.tsx` → `AccountDetailPanel` |
| Next.js route | kebab-case folder + `page.tsx` | `app/dashboard/live-ops/page.tsx` |
| Test file | Target name + `.test.ts` | `adCampaigns.test.ts` |
| Type, interface, class | PascalCase, no `I` prefix | `CampaignSchedule` |
| Function, variable | camelCase; functions start with a verb | `parseCampaignInput`, `listCampaigns` |
| Module-level immutable constant | `UPPER_SNAKE_CASE` | `MAX_RANGE_DAYS` |
| Boolean | `is`, `has`, `can`, `should` | `isLive`, `hasWallet` |
| React hook | `use` + PascalCase | `useAdminData` |
| Event handler | `on` + action for props, `handle` + action for the implementation | `onSave`, `handleUpload` |
| Forbidden | `data`, `info`, `tmp`, `res2`, meaningless abbreviations | |

### 3. File structure

1. Imports: Node built-ins → external packages → project absolute paths (`@/`) → relative paths.
   One blank line between groups, alphabetical within a group, and `import type` for type-only imports.
2. A file header comment of 2–4 lines explaining why the file exists.
3. Constants → types → internal helpers → exported functions or components.

- Organize folders by domain (`domains/ads/`, `domains/analytics/`). Do not pile everything into
  `utils/` or `helpers/`.
- Aim for 300 lines or fewer per file. Route files handle HTTP only; business logic lives in a
  service file.
- Use `export default` only for Next.js pages. Everything else uses named exports.

### 4. Types

- `any` is forbidden under strict mode. Receive external input as `unknown` and validate it with a
  parse function.
- Use `interface` for object shapes and `type` for unions and compositions.
- Exported functions declare their return type.
- Define string states once, as a union type or an `as const` array.
- Response types live in one file (`lib/types.ts`). Pages do not redeclare them.
- Use `as` only immediately after validation. Avoid the `!` non-null assertion.

### 5. Functions

- Aim for 40 lines or fewer and at most 3 parameters. With more, take an object argument `{ a, b, c }`.
- Use `async`/`await`. Avoid `.then()` chains, except inside React effects.
- Use early returns to reduce nesting. Nested ternaries are forbidden.
- Throw meaningful `Error` subclasses. Never silently swallow an error in `catch`; if swallowing is
  correct, leave a comment explaining why.

### 6. React (Admin UI)

- One component is one piece of the screen. Split into child components past 150 lines.
- Load data through the shared hook (`useAdminData`). Pages do not call `fetch` directly.
- Turn repeated styling into CSS classes (`.btn`, `.card`). Do not copy inline styles.
- Consider grouping props into an object when a component takes more than 4.

### 7. Comments

- Give exported functions and types a one-line `/** JSDoc */` summary.
- Start each file with a short note on its role and boundaries.
- Everything else matches the C# comment rules: explain why, `//` with full sentences, TODOs with an
  owner, no commented-out code.

## Automation

| Language | Tool | Role |
|----------|------|------|
| All | [`.editorconfig`](../.editorconfig) | Indentation, line endings, final newline, C# formatting and naming rules |
| C# | `dotnet format` + `.editorconfig` | Formatting and naming checks |
| C# | Rider / Visual Studio "cleanup on save" | Automatic layout |
| TypeScript | Prettier ([`.prettierrc.json`](../.prettierrc.json)) | Formatting |
| TypeScript | ESLint ([`eslint.config.mjs`](../eslint.config.mjs)) | No `any`, import order, unused code, size limits |
| All | pre-commit hook or CI | Block commits that break the rules (not set up yet) |

C# style and naming rules are reported at `suggestion` severity. `Server/Directory.Build.props`
sets `TreatWarningsAsErrors`, so raising them to `warning` would fail the build on existing files.
Check only the files you changed, for example:

```powershell
dotnet format Server/WarFriendsServer.sln --verify-no-changes --include src/War.Backend/NewFile.cs
```

The repository has no TypeScript package yet. When one is added, install `eslint`,
`typescript-eslint`, `eslint-plugin-import`, `eslint-config-prettier` and `prettier` as dev
dependencies. The root configs then apply without changes.

[`AGENTS.md`](../AGENTS.md) carries a short summary of this guide so AI coding tools follow the same rules.
