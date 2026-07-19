using System;
using Com.Google.Android.Gms.Common.Api;
using Google.Developers;

namespace GooglePlayGames.Android
{
	internal class TokenResult : JavaObjWrapper, HNEKGBNOABJ
	{
		public TokenResult(IntPtr ptr)
			: base(ptr)
		{
		}

		public CKCLCKALDBH getStatus()
		{
			IntPtr pAFLGKBLAIJ = InvokeCall<IntPtr>("getStatus", "()Lcom/google/android/gms/common/api/Status;", new object[0]);
			return new CKCLCKALDBH(pAFLGKBLAIJ);
		}

		public int getStatusCode()
		{
			return InvokeCall<int>("getStatusCode", "()I", new object[0]);
		}

		public string getAuthCode()
		{
			return InvokeCall<string>("getAuthCode", "()Ljava/lang/String;", new object[0]);
		}

		public string getEmail()
		{
			return InvokeCall<string>("getEmail", "()Ljava/lang/String;", new object[0]);
		}

		public string getIdToken()
		{
			return InvokeCall<string>("getIdToken", "()Ljava/lang/String;", new object[0]);
		}
	}
}
