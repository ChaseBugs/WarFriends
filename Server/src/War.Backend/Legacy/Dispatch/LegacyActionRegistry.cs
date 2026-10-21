using System.Collections.Frozen;

namespace War.Backend.Legacy.Dispatch;

/// <summary>Rejects ambiguous or incomplete wire-action ownership before accepting traffic.</summary>
public sealed class LegacyActionRegistry
{
    private static readonly FrozenSet<DatabaseAction> AnonymousActions = new[]
    {
        DatabaseAction.GetConfigurations,
        DatabaseAction.CreateAccount,
        DatabaseAction.CreateGcAccount,
        DatabaseAction.LoginToCustomAccount
    }.ToFrozenSet();

    private readonly FrozenDictionary<DatabaseAction, LegacyActionRegistration> _actions;

    public LegacyActionRegistry(IEnumerable<LegacyActionRegistration> registrations)
    {
        LegacyActionRegistration[] entries = registrations.ToArray();
        ValidateEntries(entries);
        _actions = entries.ToFrozenDictionary(entry => entry.Action);
        ValidateCoverage();
    }

    public IReadOnlyDictionary<DatabaseAction, LegacyActionRegistration> Actions => _actions;

    public LegacyActionRegistration Get(DatabaseAction action)
    {
        return _actions[action];
    }

    private static void ValidateEntries(LegacyActionRegistration[] entries)
    {
        var seen = new HashSet<DatabaseAction>();
        foreach (LegacyActionRegistration entry in entries)
        {
            if (!Enum.IsDefined(entry.Action) || !Enum.IsDefined(entry.Feature) || !seen.Add(entry.Action))
            {
                throw new InvalidOperationException("Legacy action registration is unknown or duplicated.");
            }

            bool anonymous = entry.Disposition == LegacyActionDisposition.Anonymous;
            if (anonymous != AnonymousActions.Contains(entry.Action))
            {
                throw new InvalidOperationException("Legacy action registration changes the anonymous boundary.");
            }

            bool closed = entry.Disposition == LegacyActionDisposition.Closed;
            if (closed != (entry.Feature == LegacyActionFeature.Unavailable))
            {
                throw new InvalidOperationException("Legacy action registration has no executable feature owner.");
            }
        }
    }

    private void ValidateCoverage()
    {
        if (!_actions.Keys.ToHashSet().SetEquals(Enum.GetValues<DatabaseAction>()))
        {
            throw new InvalidOperationException("Every legacy wire action needs one explicit disposition.");
        }

        IEnumerable<DatabaseAction> buffered = _actions.Values
            .Where(entry => entry.Disposition == LegacyActionDisposition.BufferedOnly)
            .Select(entry => entry.Action);
        if (!buffered.ToHashSet().SetEquals(LegacyBufferProcessor.SupportedActions))
        {
            throw new InvalidOperationException("Legacy HTTP and buffered action ownership disagree.");
        }
    }
}
