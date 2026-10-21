using System.Security.Cryptography;

namespace War.Persistence.Legacy.Accounts;

/// <summary>Keeps the existing password work factor fixed rather than accepting durable iteration authority.</summary>
internal static class LegacyPasswordAuthority
{
    internal const int Iterations = 600_000;
    internal const int SaltBytes = 16;
    internal const int HashBytes = 32;

    internal static byte[] Derive(string password, byte[] salt) =>
        Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, HashBytes);
}
