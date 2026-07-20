# Squad Event configuration

The recovered APK contains the Squad Event wire parser but not the retired production season,
assignment, target, or reward schedule. The backend therefore keeps Squad Events disabled unless
`SQUAD_EVENT_CONFIG_PATH` points to an operator-reviewed JSON file. Copy
`squad-events.example.json` to a deployment-owned file; do not put guessed production rewards in
the repository.

Each season uses this strict shape:

```json
{
  "seasons": [
    {
      "id": "reviewed-season-id",
      "startTime": 1784505600,
      "endTime": 1785110400,
      "tiers": [
        {
          "reward": 100,
          "assignments": [
            { "id": 1, "target": 10, "param": 2 }
          ]
        }
      ]
    }
  ]
}
```

Times are UTC Unix seconds. Seasons may not overlap. Every tier must have the same assignment
count because the stock client definition contains one global `assignmentCount`. `reward`,
assignment `id`, target semantics, and optional numeric `param` must come from reviewed live-ops
data; the example above demonstrates syntax only and is not a recovered WarFriends season.

Configuration is loaded on first use and retained for the process lifetime. Restart the backend
after deploying a reviewed schedule. A malformed configured file fails the request instead of
silently selecting or granting guessed content.

Treat a season ID as immutable after the first squad joins. Each progress row stores a SHA-256 of
its normalized definition, and reads fail closed if an operator reuses that ID with changed tiers,
assignments, targets, or rewards. Publish corrections under a new season ID.
