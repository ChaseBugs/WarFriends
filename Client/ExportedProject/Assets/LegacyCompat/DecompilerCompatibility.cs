namespace WarFriends.Legacy
{
    /// <summary>
    /// Preserves CLR behavior for constructs emitted by the obfuscator that cannot be
    /// represented directly in C# source. These helpers are intentionally small and
    /// deterministic so recovered code remains auditable instead of silently changing
    /// impossible branches into successful ones.
    /// </summary>
    public static class DecompilerCompatibility
    {
        /// <summary>
        /// Returns the original runtime array length. The recovered DLL contains junk
        /// branches with constant negative lengths; IL can encode them, but the C#
        /// compiler rejects a constant negative array size. Routing the value through a
        /// method keeps it non-constant at compile time and still makes array allocation
        /// throw if an allegedly unreachable obfuscation branch is ever executed.
        /// </summary>
        public static int RuntimeArrayLength(int length)
        {
            return length;
        }
    }
}
