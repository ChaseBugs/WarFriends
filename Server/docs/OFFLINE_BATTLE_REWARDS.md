# Offline ordinary PvP settlement policy

The owner authorized configurable offline rules where the original server rules are absent.
These values are reconstruction policy, not recovered production balance.

| Setting | Default | Meaning |
| --- | ---: | --- |
| `Battle:Rewards:WinWarBucks` | 800 | Base winner reward |
| `Battle:Rewards:LoseWarBucks` | 400 | Base loser reward |
| `Battle:Rewards:WinMedals` | 20 | Addition to skill and division medal balance |
| `Battle:Rewards:LoseMedals` | 10 | Subtraction, with a zero floor |
| `Battle:Rewards:TimeXpPerSecond` | 0 | Winner-only remaining-time XP rate |

Environment variables replace colons with double underscores. Configuration is validated at
startup. Each eligible ordinary PvP allocation freezes the complete policy, recovered rank rows,
streak rewards and VIP multipliers with a SHA-256 revision. Changing deployment settings cannot
change an already allocated battle's reward amounts. The operator template must explicitly select
`PvpBonusMode: "ordinary"` with its source-valid scene-master/player-level/bonus fields; templates
without that selection remain non-rewarding. Historical allocations without a policy,
prototype, friendly and co-op outcomes are not made reward-bearing by this implementation.

Recovered rules: 43 zero-based ranks, rank XP thresholds, rank rewards, Army Power deltas,
600-second streak window, ten streak rewards and binary32 VIP multipliers. Offline decisions:
the first win uses the first streak reward, the tenth and later active wins use the last reward;
the stored counter caps at nine for Client compatibility. Maximum-rank XP remains bounded and
does not repeatedly award the final rank reward. Time XP uses remaining whole seconds, capped
at 999, and defaults to zero. The winner is supplied by the authoritative Worker result.

Action 62 authenticates the participant and looks up the accepted host result. Client prices,
XP, winner assertions and reward amounts never select the payout. Both accounts, exact per-player
response receipts and the settlement marker are published in one MongoDB transaction. Rank and
wallet overflow reject the transition before publication. Replays return the stored response.
MongoDB must run as a replica set.

Focused policy/rank checks:

```powershell
dotnet build Server/tests/War.Battle.Tests -c Release
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --battle-rank-content-path Server/content
```

Native transaction checks use `Server/scripts/BattleSettlementSmoke.ps1 -MongoExecutable <mongod-path>`.
Its managed run owns and stops its Mongo process, removes successful disposable data and retains
bounded failure evidence. No Unity project copy is required.

Native transaction checks passed concurrent requests, recreated-store replay, wallet-overflow rollback
and invalid-session rejection on 2026-10-22. This is server-side evidence, not normal Unity gameplay proof.

Remaining release work includes broader settlement corruption/crash coverage, rank-up dog tags,
achievement and mission updates, league admission/season payouts, receipt retention guarantees,
and normal Client result-screen/rematch verification. This policy does not complete those features.
