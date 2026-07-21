import assert from "node:assert/strict";
import test from "node:test";
import {
  exactMongoDatabaseName,
  runtimeInfrastructurePolicy,
} from "../services/runtimeInfrastructurePolicyService";

test("runtime infrastructure uses one immutable exact startup policy", () => {
  assert.equal(Object.isFrozen(runtimeInfrastructurePolicy()), true);
  assert.deepEqual(runtimeInfrastructurePolicy(), {
    listenPort: 8080,
    mongoPoolSize: 100,
    mongoDatabaseName: "warfriends",
  });
  assert.deepEqual(runtimeInfrastructurePolicy({
    listenPort: 443,
    mongoPoolSize: 250,
    mongoDatabaseName: "warfriends_prod",
  }), {
    listenPort: 443,
    mongoPoolSize: 250,
    mongoDatabaseName: "warfriends_prod",
  });
});

test("runtime infrastructure rejects late-failing listener and pool values", () => {
  const configured = runtimeInfrastructurePolicy();
  for (const listenPort of [Number.NaN, Number.POSITIVE_INFINITY, 0, 1.5, 65_536]) {
    assert.throws(
      () => runtimeInfrastructurePolicy({ ...configured, listenPort }),
      /Runtime listen-port policy is invalid/,
    );
  }
  for (const mongoPoolSize of [Number.NaN, Number.POSITIVE_INFINITY, 0, 1.5, 1_001]) {
    assert.throws(
      () => runtimeInfrastructurePolicy({ ...configured, mongoPoolSize }),
      /Runtime MongoDB pool-size policy is invalid/,
    );
  }
});

test("MongoDB database name rejects whitespace, reserved characters, and byte overflow", () => {
  assert.equal(exactMongoDatabaseName("warfriends_prod"), "warfriends_prod");
  for (const name of ["", " warfriends", "warfriends ", "war.friends", "war/friends", "war$friends", "a".repeat(64)]) {
    assert.throws(() => exactMongoDatabaseName(name), /database-name policy is invalid/);
  }
  assert.throws(() => exactMongoDatabaseName("界".repeat(22)), /database-name policy is invalid/);
});
