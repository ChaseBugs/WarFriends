import { connectMongo, disconnectMongo, gameCatalogReleases } from "../db";
import { GAME_CATALOG_CLIENT_VERSION } from "../services/gameCatalogService";

/**
 * Operational entry point for explicitly refreshing the MongoDB material database after a
 * client extraction changes. Normal server startup performs the same idempotent sync; this
 * command exists for deployments that prepare shared database state before rolling servers.
 */
async function main(): Promise<void> {
  try {
    await connectMongo();
    const release = await gameCatalogReleases().findOne({
      clientVersion: GAME_CATALOG_CLIENT_VERSION,
    });
    if (!release) throw new Error("Catalog synchronization completed without a release pointer.");

    process.stdout.write(
      `Published WarFriends ${release.clientVersion} catalog ${release.catalogRevision} `
      + `with ${release.entryCount} entries.\n`,
    );
  } finally {
    await disconnectMongo();
  }
}

void main().catch((error: unknown) => {
  const message = error instanceof Error ? error.stack ?? error.message : String(error);
  process.stderr.write(`${message}\n`);
  process.exitCode = 1;
});
