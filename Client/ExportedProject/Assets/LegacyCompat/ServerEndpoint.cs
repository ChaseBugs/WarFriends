namespace WarFriends.Legacy
{
    // Single global source of truth for the recovered client's backend base URL.
    //
    // Change this ONE value (then rebuild WarFriends.LegacyCompat.dll and drop it into the project's
    // Plugins) to point the whole client at a different server. The client's URL builders
    // (DJOJPKGADMP.NPDIBOLPACA / BGMBGEOAKPP) are patched to return this field, so every request and the
    // derived check.php connectivity URL all come from here instead of the scattered hardcoded strings.
    //
    // Requirements: must end with '/'; the client appends "<action>/<version>" (e.g. "118/4-9-5"). Use a
    // plain http:// base so BestHTTP never runs the client's pinned-certificate validator.
    public static class ServerEndpoint
    {
        public static readonly string BaseUrl = "http://localhost:8081/api/";
    }
}
