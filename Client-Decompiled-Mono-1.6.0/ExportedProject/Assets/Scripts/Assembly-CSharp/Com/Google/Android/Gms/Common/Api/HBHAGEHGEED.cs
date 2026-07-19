using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Google.Developers;
using UnityEngine;

namespace Com.Google.Android.Gms.Common.Api
{
	public abstract class HBHAGEHGEED<R> : JavaInterfaceProxy, Com.Google.Android.Gms.Common.Api.MDLKHELHPML<R> where R : HNEKGBNOABJ
	{
		private const string EEGPGGKKIOP = "com/google/android/gms/common/api/ResultCallback";

		public HBHAGEHGEED()
			: base("com/google/android/gms/common/api/ResultCallback")
		{
		}

		public abstract void OnResult(R JEKMPACBICA);

		public void GPLGOBANGNA(R JEKMPACBICA)
		{
			OnResult(JEKMPACBICA);
		}

		public void GPLGOBANGNA(AndroidJavaObject JEKMPACBICA)
		{
			IntPtr rawObject = JEKMPACBICA.GetRawObject();
			ConstructorInfo constructor = typeof(R).GetConstructor(new Type[1] { rawObject.GetType() });
			R val;
			if (constructor != null)
			{
				val = (R)constructor.Invoke(new object[1] { rawObject });
			}
			else
			{
				ConstructorInfo constructor2 = typeof(R).GetConstructor(new Type[0]);
				val = (R)constructor2.Invoke(new object[0]);
				Marshal.PtrToStructure(rawObject, val);
			}
			OnResult(val);
		}
	}
}
