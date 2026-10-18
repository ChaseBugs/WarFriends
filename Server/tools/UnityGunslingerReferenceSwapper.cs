/// <summary>Defers editor construction hooks while retaining the original nonvirtual Swap and SnapTo methods.</summary>
public sealed class UnityGunslingerReferenceSwapper : FakeRigidBodySwapper
{
    protected override void Awake()
    {
        // The audit copies serialized inputs before explicitly calling the inherited Init method.
    }

    /// <summary>Prevents AddComponent's editor Reset message from reading not-yet-copied source fields.</summary>
    public new void Reset()
    {
        // Only the editor construction hook is suppressed; attachment methods remain inherited unchanged.
    }
}
