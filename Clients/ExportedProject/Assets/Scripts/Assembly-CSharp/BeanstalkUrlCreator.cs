using UnityEngine;

public class BeanstalkUrlCreator
{
    public bool isLocalhost => false;

    public static DatabaseEnvironment environment => DatabaseEnvironment.Production;

    public string CreateUrl()
    {
        return SelfHostedBackendEndpoint.GetLegacyActionUrl();
    }

    public string CreateAppLink()
    {
        Debug.Log("FB hosted app link: https://fb.me/1157647734253183");
        return "https://fb.me/1157647734253183";
    }
}
