"""Review tutorial dispatch and execute original mandatory-field/callback excerpts without gameplay."""

from pathlib import Path
from legacy_profile_oracle import member


def tutorial_sources(client: Path) -> dict[str, str]:
    builder = (client / "BeanstalkServerManager.cs").read_text(encoding="utf-8-sig")
    callback = (client / "ServerResponseHandler.cs").read_text(encoding="utf-8-sig")
    errors = (client / "ServerErrorHandler.cs").read_text(encoding="utf-8-sig")
    classic = member(callback, "\tprivate void OnClassicGameEnded(")
    start = classic.index('\t\tint num6 = StringParser.ParseInt(mResponse["LevelExperience"]);')
    end = classic.index("\n\t\telse if (databaseAction == DatabaseAction.GameEnded)", start)
    error_start = errors.index("\t\tcase DatabaseResult.GameAlreadyEnded:")
    error_end = errors.index("\n\t\tcase DatabaseResult.NotEnoughDogtags:", error_start)
    return {
        "Tutorial.StartBuilder": member(builder, "\tinternal void GameStartedTutorial()"),
        "Tutorial.EndBuilder": member(builder, "\tpublic void TutorialEnded()"),
        "Tutorial.StartCallback": member(callback, "\tprivate void OnTutorialStarted()"),
        "Tutorial.Dispatch": member(callback, "\tprivate void OnGameEnded("),
        "Tutorial.ClassicCallback": classic,
        "Tutorial.CompletionExcerpt": classic[start:end].strip(),
        "Tutorial.ErrorBranch": errors[error_start:error_end].strip(),
    }


def tutorial_oracle(recovered: dict[str, str]) -> str:
    template = """
internal static class RecoveredTutorialOracle
{
    private static class Singleton<T> where T : new() { internal static T instance = new T(); }
    private static class Debug
    {
        internal static void Log(object message) { }
        internal static void LogError(object message) { }
    }
    private sealed class GameController
    {
        internal enum ServerResponse { Success, Error }
        internal ServerResponse gameEndServerResponse;
        internal DatabaseResult errorReason;
        internal string battleId;
        internal int continuations;
        internal void ContinueTutorialImmediately() { continuations++; }
    }
    private sealed class CurrentPlayer { internal bool canPlayerSendLogs => false; }
    private static class GameLoginManager { internal static CurrentPlayer currentPlayer = new(); }
    private sealed class GameReward
    {
        internal string debugGameRewards => "instrumented";
        internal int GetXpTotal() => 0;
    }
    private sealed class ServerResultsCache
    {
        internal GameReward lastGameReward = null;
        internal object squadEventProgress;
    }
    private sealed class LevelManager
    {
        internal static LevelManager instance = new();
        internal int levelExperience;
        internal bool isLevelUp;
        internal void LoadData(int level, int xp) { levelExperience = xp; }
    }
    private sealed class EventTrackingManager
    {
        internal void RegisterGoldAndWBAfterMatch(bool isLevelUp) { }
        internal void RegisterAssignmentIssued(AssignmentsManager.DatabaseAssignment item, int issued) { }
    }
    private static class DatabaseSquadEventProgress
    {
        internal static object CreateFromDatabase(Newtonsoft.Json.Linq.JToken value) => new object();
    }
    private sealed class AssignmentsManager
    {
        internal sealed class DatabaseAssignment { }
        internal sealed class AssignmentData
        {
            internal List<DatabaseAssignment> assignments = new();
            internal int issued = 0;
        }
        internal static AssignmentsManager instance = new();
        internal AssignmentData data = new();
        internal void LoadData(string value) { }
    }
    private sealed class PlayerAnalytics
    {
        internal static PlayerAnalytics instance = new();
        internal bool tutorialFinished;
    }
    private sealed class RestoreBoundary
    {
        internal int calls;
        internal void HandleRestore() { calls++; }
    }
    private sealed class BeanstalkServerManager
    {
        internal int loaded;
        internal RestoreBoundary inAppHandler = new();
        internal void PlayerDataWasLoaded(bool executeRoutines) { loaded++; }
    }
    private sealed class Callback
    {
        internal Dictionary<string, object> mResponse;
        __START__
        __DISPATCH__
        private void OnArenaEnded() { throw new InvalidOperationException("Unexpected Arena branch."); }
        private void OnClassicGameEnded(DatabaseAction databaseAction)
        {
            __COMPLETION__
        }
        internal void Start() { OnTutorialStarted(); }
        internal void End() { OnGameEnded(DatabaseAction.TutorialEnded); }
        internal void Error(DatabaseResult resultCode)
        {
            switch (resultCode) { __ERROR__ }
        }
    }
    internal static (string Id, int Calls) Start(Dictionary<string, object> response)
    {
        Singleton<GameController>.instance = new();
        new Callback { mResponse = response }.Start();
        return (Singleton<GameController>.instance.battleId, Singleton<GameController>.instance.continuations);
    }
    internal static (int Xp, bool Completed, int Loaded, int Restore) End(Dictionary<string, object> response)
    {
        PlayerAnalytics.instance = new();
        Singleton<BeanstalkServerManager>.instance = new();
        LevelManager.instance = new();
        new Callback { mResponse = response }.End();
        return (LevelManager.instance.levelExperience, PlayerAnalytics.instance.tutorialFinished,
            Singleton<BeanstalkServerManager>.instance.loaded,
            Singleton<BeanstalkServerManager>.instance.inAppHandler.calls);
    }
    internal static bool RejectWrongBattle()
    {
        new Callback().Error(DatabaseResult.GameDidntExist);
        return Singleton<GameController>.instance.gameEndServerResponse == GameController.ServerResponse.Error;
    }
}
"""
    for token, key in (("START", "StartCallback"), ("DISPATCH", "Dispatch"),
                       ("COMPLETION", "CompletionExcerpt"), ("ERROR", "ErrorBranch")):
        template = template.replace(f"__{token}__", recovered[f"Tutorial.{key}"])
    return template
