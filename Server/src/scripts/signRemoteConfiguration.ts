import { readFileSync, writeFileSync } from "fs";
import { resolve } from "path";
import { config } from "../config";
import {
  remoteConfigurationSignature,
  validateRemoteConfigurationManifest,
} from "../services/remoteConfigurationService";

const pathArgument = process.argv[2];
if (!pathArgument) throw new Error("Usage: npm run sign:remote-config -- <manifest.json>");
if (config.remoteConfigurationSigningSecret.length < 32) {
  throw new Error("REMOTE_CONFIGURATION_SIGNING_SECRET must contain at least 32 characters.");
}
const path = resolve(pathArgument);
const parsed = JSON.parse(readFileSync(path, "utf8")) as Record<string, unknown>;
parsed.signature = remoteConfigurationSignature(parsed, config.remoteConfigurationSigningSecret);
validateRemoteConfigurationManifest(parsed, config.remoteConfigurationSigningSecret);
writeFileSync(path, `${JSON.stringify(parsed, null, 2)}\n`, "utf8");
process.stdout.write(`Signed remote configuration manifest: ${path}\n`);
