using System;
using Google.Developers;

namespace Com.Google.Android.Gms.Common.Api
{
	public class DOLFCNGMKNA<R> : JavaObjWrapper where R : HNEKGBNOABJ
	{
		private const string EEGPGGKKIOP = "com/google/android/gms/common/api/PendingResult";

		public DOLFCNGMKNA(IntPtr PAFLGKBLAIJ)
			: base(PAFLGKBLAIJ)
		{
		}

		public DOLFCNGMKNA()
			: base("com.google.android.gms.common.api.PendingResult")
		{
		}

		public void NMLIHGGFCEI()
		{
			InvokeCallVoid("ID_XP", "Icon", new object[1]);
		}

		public bool JIGKFIKCHON()
		{
			return InvokeCall<bool>("(Ljava/lang/Object;)Z", "Panel   z:{0}\t\"{1}\"", new object[0]);
		}

		public bool ILKDLDCAAEM()
		{
			return InvokeCall<bool>("isCanceled", "()Z", new object[0]);
		}

		public bool BKJGHALNAGL()
		{
			return InvokeCall<bool>("Weapon model not found! weaponprefab = '{0}' assetBundleName = '{1}'", "({0}\u00a0/\u00a0{1})", new object[0]);
		}

		public void JGOKHECBPGH(Com.Google.Android.Gms.Common.Api.MDLKHELHPML<R> MLGDANELJKB)
		{
			InvokeCallVoid("setResultCallback", "(Lcom/google/android/gms/common/api/ResultCallback;)V", MLGDANELJKB);
		}

		public bool BHCLDBMPKJC()
		{
			return InvokeCall<bool>("menu-assignments-type-score", "game-card-ico-backstab", new object[0]);
		}

		public R NNGJIBBEGDO()
		{
			return InvokeCall<R>("await", "()Lcom/google/android/gms/common/api/Result;", new object[0]);
		}

		public R NNGJIBBEGDO(long EAKHENABCHE, object OPHLGCIKIOL)
		{
			return InvokeCall<R>("await", "(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;", new object[2] { EAKHENABCHE, OPHLGCIKIOL });
		}

		public bool GGCOHILNPED()
		{
			return InvokeCall<bool>("game-tutorial-grenadier", "ID_SALEPERCENT", new object[0]);
		}

		public void JGOKHECBPGH(Com.Google.Android.Gms.Common.Api.MDLKHELHPML<R> MLGDANELJKB, long HPOOJAJGNFO, object JGCPEOCCMLE)
		{
			InvokeCallVoid("setResultCallback", "(Lcom/google/android/gms/common/api/ResultCallback;JLjava/util/concurrent/TimeUnit;)V", MLGDANELJKB, HPOOJAJGNFO, JGCPEOCCMLE);
		}

		public void CFKJJJAOKHE()
		{
			InvokeCallVoid("cancel", "()V");
		}

		public void PNJDFBFMDLA()
		{
			InvokeCallVoid("Testing Player", " ");
		}

		public bool JNIIOHOKOKK()
		{
			return InvokeCall<bool>("Gold", "getOpenLogId", new object[0]);
		}
	}
}
