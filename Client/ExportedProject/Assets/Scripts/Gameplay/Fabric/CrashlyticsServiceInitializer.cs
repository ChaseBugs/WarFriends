using UnityEngine;

namespace Fabric
{
	public static class CrashlyticsServiceInitializer
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Init()
		{
			Debug.Log("[Crashlytics Init] Init->Before");
			AnalyticsServiceBase.Initialize<DMPHDCGMGGE>();
			Debug.Log("[Crashlytics Init] Init->After");
		}
	}
}
