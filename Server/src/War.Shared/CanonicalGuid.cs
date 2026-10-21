namespace War.Shared
{
    /// <summary>Checks exact lower-case N-format identities without trimming, casing or allocating.</summary>
    public static class CanonicalGuid
    {
        private const int IdentityCharacters = 32;

        public static bool IsCanonical(string value)
        {
            if (value == null || value.Length != IdentityCharacters)
            {
                return false;
            }

            for (int index = 0; index < value.Length; index++)
            {
                char character = value[index];
                bool isDigit = character >= '0' && character <= '9';
                bool isLowerHexLetter = character >= 'a' && character <= 'f';
                if (!isDigit && !isLowerHexLetter)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
