namespace WarFriends.Legacy
{
    // Single global source of truth for the recovered client's backend base URL.
    //
    // The client's two recovered URL builders (DJOJPKGADMP.NPDIBOLPACA / BGMBGEOAKPP) return this
    // value. BeanstalkServerManager then appends "<action>/<version>" for gameplay requests and
    // appends "check.php" for its connection probe. Keeping both paths on one base prevents boot
    // from probing one backend and sending the account/configuration request to another.
    //
    // The local Server listens on port 8080 and mounts the recovered dispatcher under /api. On a
    // physical Android device, run `adb reverse tcp:8080 tcp:8080` before launching the game so the
    // device's loopback address reaches the development machine. A remote/LAN deployment should
    // replace this constant with its reviewed HTTP base and rebuild the editable Unity project.
    //
    // Requirements: the value must end with '/'. Plain HTTP intentionally avoids the retired
    // production certificate-pinning callback; do not point a production build at an untrusted LAN.
    public static class ServerEndpoint
    {
        public const string BaseUrl = "http://127.0.0.1:8080/api/";
    }
}
