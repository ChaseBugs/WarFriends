using System;
using Com.Google.Android.Gms.Common.Api;
using Com.Google.Android.Gms.Games;
using Com.Google.Android.Gms.Games.Stats;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using UnityEngine;

namespace GooglePlayGames.Android
{
	internal class AndroidClient : IClientImpl
	{
		private class StatsResultCallback : Com.Google.Android.Gms.Common.Api.HBHAGEHGEED<CKOMHHKHDEB>
		{
			private Action<int, JOCGMGPOMMK> callback;

			public StatsResultCallback(Action<int, JOCGMGPOMMK> callback)
			{
				this.callback = callback;
			}

			public override void OnResult(CKOMHHKHDEB arg_Result_1)
			{
				callback(arg_Result_1.getStatus().GCINBMOGMDP(), arg_Result_1.DNEGFNEHOAC());
			}
		}

		internal const string BridgeActivityClass = "com.google.games.bridge.NativeBridgeActivity";

		private const string LaunchBridgeMethod = "launchBridgeIntent";

		private const string LaunchBridgeSignature = "(Landroid/app/Activity;Landroid/content/Intent;)V";

		private TokenClient tokenClient;

		private static AndroidJavaObject invisible;

		public PlatformConfiguration CreatePlatformConfiguration(PlayGamesClientConfiguration clientConfig)
		{
			AndroidPlatformConfiguration androidPlatformConfiguration = AndroidPlatformConfiguration.Create();
			using (AndroidJavaObject androidJavaObject = AndroidTokenClient.GetActivity())
			{
				androidPlatformConfiguration.SetActivity(androidJavaObject.GetRawObject());
				androidPlatformConfiguration.SetOptionalIntentHandlerForUI(delegate(IntPtr intent)
				{
					IntPtr intentRef = AndroidJNI.NewGlobalRef(intent);
					PlayGamesHelperObject.RunOnGameThread(delegate
					{
						try
						{
							LaunchBridgeIntent(intentRef);
						}
						finally
						{
							AndroidJNI.DeleteGlobalRef(intentRef);
						}
					});
				});
				if (clientConfig.IsHidingPopups)
				{
					androidPlatformConfiguration.SetOptionalViewForPopups(CreateHiddenView(androidJavaObject.GetRawObject()));
				}
			}
			return androidPlatformConfiguration;
		}

		public TokenClient CreateTokenClient(bool reset)
		{
			if (tokenClient == null)
			{
				tokenClient = new AndroidTokenClient();
			}
			else if (reset)
			{
				tokenClient.Signout();
			}
			return tokenClient;
		}

		private IntPtr CreateHiddenView(IntPtr activity)
		{
			if (invisible == null || invisible.GetRawObject() == IntPtr.Zero)
			{
				invisible = new AndroidJavaObject("android.view.View", activity);
				invisible.Call("setVisibility", 4);
				invisible.Call("setClickable", false);
			}
			return invisible.GetRawObject();
		}

		private static void LaunchBridgeIntent(IntPtr bridgedIntent)
		{
			object[] args = new object[2];
			jvalue[] array = AndroidJNIHelper.CreateJNIArgArray(args);
			try
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.games.bridge.NativeBridgeActivity"))
				{
					using (AndroidJavaObject androidJavaObject = AndroidTokenClient.GetActivity())
					{
						IntPtr staticMethodID = AndroidJNI.GetStaticMethodID(androidJavaClass.GetRawClass(), "launchBridgeIntent", "(Landroid/app/Activity;Landroid/content/Intent;)V");
						array[0].l = androidJavaObject.GetRawObject();
						array[1].l = bridgedIntent;
						AndroidJNI.CallStaticVoidMethod(androidJavaClass.GetRawClass(), staticMethodID, array);
					}
				}
			}
			catch (Exception ex)
			{
				GooglePlayGames.OurUtils.Logger.e("Exception launching bridge intent: " + ex.Message);
				GooglePlayGames.OurUtils.Logger.e(ex.ToString());
			}
			finally
			{
				AndroidJNIHelper.DeleteJNIArgArray(args, array);
			}
		}

		public void Signout()
		{
			if (tokenClient != null)
			{
				tokenClient.Signout();
			}
		}

		public void GetPlayerStats(IntPtr apiClient, Action<CommonStatusCodes, PlayerStats> callback)
		{
			CPHCDFPIGCN dEBLAIKMMOE = new CPHCDFPIGCN(apiClient);
			StatsResultCallback mLGDANELJKB;
			try
			{
				mLGDANELJKB = new StatsResultCallback(delegate(int result, JOCGMGPOMMK stats)
				{
					Debug.Log("Result for getStats: " + result);
					PlayerStats arg = null;
					if (stats != null)
					{
						arg = new PlayerStats
						{
							AvgSessonLength = stats.BEELNGHKNEJ(),
							DaysSinceLastPlayed = stats.EPOAOIGAOBM(),
							NumberOfPurchases = stats.EMIPOCPDOIB(),
							NumberOfSessions = stats.MMBGGCLHKIH(),
							SessPercentile = stats.JCPOAHBDKPB(),
							SpendPercentile = stats.JCKFDCLINOP(),
							ChurnProbability = stats.BEAAIBCJPKM(),
							SpendProbability = stats.PILOGFIIGPI(),
							HighSpenderProbability = stats.BCMBDNAAPHM(),
							TotalSpendNext28Days = stats.FDOGNIGJCPH()
						};
					}
					callback((CommonStatusCodes)result, arg);
				});
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				callback(CommonStatusCodes.DeveloperError, null);
				return;
			}
			Com.Google.Android.Gms.Common.Api.DOLFCNGMKNA<CKOMHHKHDEB> dOLFCNGMKNA = GCDFMKFPBKK.JNIPJOLMCFC.OIKFOAICICM(dEBLAIKMMOE, KEJDDPKDJCC: true);
			dOLFCNGMKNA.JGOKHECBPGH(mLGDANELJKB);
		}

		public void SetGravityForPopups(IntPtr apiClient, Gravity gravity)
		{
			CPHCDFPIGCN dEBLAIKMMOE = new CPHCDFPIGCN(apiClient);
			GCDFMKFPBKK.CHDEIFBOICO(dEBLAIKMMOE, (int)(gravity | Gravity.CENTER_HORIZONTAL));
		}
	}
}
