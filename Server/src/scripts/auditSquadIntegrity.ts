import { connectMongo, disconnectMongo, players, squads } from "../db";
import { applySquadIntegrityRepairs, inspectSquadIntegrity } from "../services/squadIntegrityService";

const repair = process.argv.includes("--repair");
const json = process.argv.includes("--json");

async function scan() {
  const [squadDocuments, playerDocuments] = await Promise.all([
    squads().find().toArray(),
    players().find().toArray(),
  ]);
  return inspectSquadIntegrity(squadDocuments, playerDocuments);
}

async function main(): Promise<void> {
  try {
    await connectMongo();
    const before = await scan();
    let repairResult: { applied: number; conflicts: string[] } | undefined;
    if (repair && before.repairs.length > 0) repairResult = await applySquadIntegrityRepairs(before.repairs);
    const after = repair ? await scan() : before;

    if (json) {
      process.stdout.write(`${JSON.stringify({ repair, repairResult, report: after }, null, 2)}\n`);
    } else {
      process.stdout.write(
        `Squad integrity: ${after.issues.length} issue(s), ${after.repairs.length} safe repair(s) pending.\n`,
      );
      if (repairResult) {
        process.stdout.write(
          `Applied ${repairResult.applied} repair(s); ${repairResult.conflicts.length} concurrent conflict(s).\n`,
        );
      }
      for (const issue of after.issues) {
        process.stdout.write(
          `[${issue.repairable ? "repairable" : "manual"}] ${issue.code} ${issue.subject}: ${issue.message}\n`,
        );
      }
    }
    if (after.issues.length > 0 || (repairResult?.conflicts.length ?? 0) > 0) process.exitCode = 2;
  } finally {
    await disconnectMongo();
  }
}

void main().catch((error: unknown) => {
  const message = error instanceof Error ? error.stack ?? error.message : String(error);
  process.stderr.write(`${message}\n`);
  process.exitCode = 1;
});
