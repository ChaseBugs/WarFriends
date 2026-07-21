import { ApiError, ApiErrorCode } from "../apiErrors";
import type { PlayerProgressionState, TutorialBattleState } from "../db";

export interface TutorialCompletionAuthority {
  tutorialFinished: boolean;
  warcardsTutorialFinished: boolean;
}

export interface TutorialLifecycleAuthority extends TutorialCompletionAuthority {
  tutorialBattle?: TutorialBattleState;
  warcardsTutorialBattle?: TutorialBattleState;
}

const TUTORIAL_BATTLE_KEYS = new Set(["battleId", "startedAt"]);

/** Validate one server-authored battle ID without accepting control characters or coercion. */
export function validatedTutorialBattleId(
  value: unknown,
  errorCode: number = ApiErrorCode.UnknownAction,
): string {
  if (
    typeof value !== "string"
    || value.length < 1
    || value.length > 128
    || /[\u0000-\u001f\u007f]/.test(value)
  ) {
    throw new ApiError(errorCode, "Tutorial battle ID is invalid.");
  }
  return value;
}

function validatedTutorialTime(value: number, label: string): number {
  if (!Number.isSafeInteger(value) || value < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} is invalid.`);
  }
  return value;
}

function validatedTutorialBattleShape(
  value: TutorialBattleState | undefined,
  label: string,
): TutorialBattleState | undefined {
  if (value === undefined) return undefined;
  if (typeof value !== "object" || value === null || Array.isArray(value)) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} is invalid.`);
  }
  const keys = Object.keys(value);
  if (keys.length !== TUTORIAL_BATTLE_KEYS.size || keys.some((key) => !TUTORIAL_BATTLE_KEYS.has(key))) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} is invalid.`);
  }
  validatedTutorialBattleId(value.battleId, ApiErrorCode.InternalServerError);
  if (!Number.isSafeInteger(value.startedAt) || value.startedAt < 0) {
    throw new ApiError(ApiErrorCode.InternalServerError, `${label} is invalid.`);
  }
  return value;
}

/**
 * Validate the two ordered tutorial completion markers shared by boot and gameplay gates.
 *
 * Both fields are server-written Booleans. JavaScript truthiness is unsafe here because a damaged
 * string such as `"false"` would expose `TutorialData` and rentals while the exact Play Warcards
 * check still treats bootcamp as unfinished. The later Warcards tutorial cannot be terminal before
 * bootcamp, so that impossible ordering is rejected rather than projected as `cardTutState = 2`.
 * Only absent legacy fields retain their original false default.
 */
export function validatedTutorialCompletion(
  state: Pick<PlayerProgressionState, "tutorialFinished" | "warcardsTutorialFinished">,
): TutorialCompletionAuthority {
  const tutorialFinished = state.tutorialFinished ?? false;
  const warcardsTutorialFinished = state.warcardsTutorialFinished ?? false;
  if (typeof tutorialFinished !== "boolean" || typeof warcardsTutorialFinished !== "boolean") {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored tutorial completion state is invalid.");
  }
  if (warcardsTutorialFinished && !tutorialFinished) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored tutorial completion order is invalid.");
  }
  return { tutorialFinished, warcardsTutorialFinished };
}

/** Validate the shared progression cursor immediately before a tutorial lifecycle write. */
export function validatedTutorialRevision(revision: number): number {
  if (!Number.isSafeInteger(revision) || revision < 0 || revision === Number.MAX_SAFE_INTEGER) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Tutorial progression revision is invalid.");
  }
  return revision;
}

/**
 * Validate completion markers and both private receipts as one ordered lifecycle snapshot.
 * Terminal markers consume their corresponding receipt, and Play Warcards cannot start before
 * bootcamp. Rejecting impossible combinations prevents a stale or malformed receipt from being
 * replayed as server proof after the account has moved to a different onboarding phase.
 */
export function validatedTutorialLifecycleShape(
  state: Pick<
    PlayerProgressionState,
    "tutorialFinished" | "warcardsTutorialFinished" | "tutorialBattle" | "warcardsTutorialBattle"
  >,
): TutorialLifecycleAuthority {
  const completion = validatedTutorialCompletion(state);
  const tutorialBattle = validatedTutorialBattleShape(state.tutorialBattle, "Stored tutorial battle");
  const warcardsTutorialBattle = validatedTutorialBattleShape(
    state.warcardsTutorialBattle,
    "Stored Play Warcards battle",
  );
  if (
    (completion.tutorialFinished && tutorialBattle)
    || (!completion.tutorialFinished && warcardsTutorialBattle)
    || (completion.warcardsTutorialFinished && warcardsTutorialBattle)
  ) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored tutorial lifecycle order is invalid.");
  }
  return { ...completion, tutorialBattle, warcardsTutorialBattle };
}

/**
 * Validate the complete tutorial lifecycle against the authoritative request time.
 *
 * Shared read/publication validation intentionally uses `validatedTutorialLifecycleShape`
 * instead: a transaction successor must be deterministic and must not become invalid merely
 * because a different application node evaluates it one second later. Gameplay and boot paths
 * have an authoritative `now`, so they additionally reject future-issued private receipts here.
 */
export function validatedTutorialLifecycle(
  state: Pick<
    PlayerProgressionState,
    "tutorialFinished" | "warcardsTutorialFinished" | "tutorialBattle" | "warcardsTutorialBattle"
  >,
  now: number,
): TutorialLifecycleAuthority {
  const currentTime = validatedTutorialTime(now, "Tutorial lifecycle server time");
  const lifecycle = validatedTutorialLifecycleShape(state);
  if (lifecycle.tutorialBattle && lifecycle.tutorialBattle.startedAt > currentTime) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored tutorial battle is invalid.");
  }
  if (lifecycle.warcardsTutorialBattle && lifecycle.warcardsTutorialBattle.startedAt > currentTime) {
    throw new ApiError(ApiErrorCode.InternalServerError, "Stored Play Warcards battle is invalid.");
  }
  return lifecycle;
}
