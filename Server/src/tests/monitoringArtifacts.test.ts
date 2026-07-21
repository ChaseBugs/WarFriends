import assert from "node:assert/strict";
import { readFile } from "node:fs/promises";
import { resolve } from "node:path";
import test from "node:test";
import { ServerMetrics } from "../services/metricsService";

const serverRoot = resolve(__dirname, "../..");

function assertMetricIsExported(exposition: string, name: string): void {
  // Counters with labels have no sample until their first event, but their HELP/TYPE declaration
  // is always present and is the stable contract Prometheus queries rely on.
  assert.match(exposition, new RegExp(`^(?:# (?:HELP|TYPE) )?${name}(?:[ {]|$)`, "m"));
}

test("Grafana dashboard is valid JSON and references only exported WarFriends metrics", async () => {
  const source = await readFile(resolve(serverRoot, "ops/grafana/warfriends-overview.json"), "utf8");
  const dashboard = JSON.parse(source) as { panels?: Array<{ targets?: Array<{ expr?: string }> }> };
  assert.ok(Array.isArray(dashboard.panels));
  assert.ok(dashboard.panels.length >= 6);

  const expressions = dashboard.panels.flatMap((panel) => panel.targets ?? []).map((target) => target.expr ?? "");
  const names = new Set(expressions.flatMap((expression) => expression.match(/warfriends_[a-z0-9_]+/g) ?? []));
  const exposition = new ServerMetrics().render(true);
  for (const name of names) assertMetricIsExported(exposition, name);
});

test("Prometheus example authenticates metrics and alert rules use exported bounded metrics", async () => {
  const configuration = await readFile(resolve(serverRoot, "ops/prometheus/prometheus.example.yml"), "utf8");
  const alerts = await readFile(resolve(serverRoot, "ops/prometheus/warfriends-alerts.yml"), "utf8");
  assert.match(configuration, /rule_files:\s*\n\s*- warfriends-alerts\.yml/);
  assert.match(configuration, /credentials_file:/);
  assert.match(configuration, /redis_required: "true"/);
  assert.match(alerts, /^groups:/);

  const names = new Set(alerts.match(/warfriends_[a-z0-9_]+/g) ?? []);
  const exposition = new ServerMetrics().render(false);
  for (const name of names) assertMetricIsExported(exposition, name);
});
