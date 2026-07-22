using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraPanelAligner : MonoBehaviour
{
	public enum KNEKLHLBNHJ
	{
		Camera,
		UIroot_Fixed
	}

	public enum DIPHEEKPNOK
	{
		topLeft,
		topRight,
		downLeft,
		downRight,
		center,
		left,
		right,
		top,
		down
	}

	public KNEKLHLBNHJ HPHDFNEIEFN = KNEKLHLBNHJ.UIroot_Fixed;

	[FormerlySerializedAs("LGMLIACICIP")]
	public Camera ABLELIOLJKP;

	[FormerlySerializedAs("KDBAOJDOEJB")]
	public UIRoot IJMDOGNBGIL;

	[FormerlySerializedAs("PMAEEIJCAIA")]
	public UIPanel CFFKHHJKBMJ;

	[FormerlySerializedAs("MBFMKMAHPLM")]
	public Vector2 CMFONIKNOLN;

	[FormerlySerializedAs("GEPFNPPHMIH")]
	public Vector2 FOCCHODIACF;

	[FormerlySerializedAs("NGOEEEHNGMP")]
	public Vector3 FHMNGFGNFLL;

	[FormerlySerializedAs("ELDMHBHCIPC")]
	public Vector2 AHDPIAOECNK = new Vector2(1280f, 1920f);

	[FormerlySerializedAs("KFPCDIIPEHO")]
	public bool EDIHJOANNLJ = true;

	[FormerlySerializedAs("OONKDCNPBGG")]
	public bool LHNDMADKMFF;

	public DIPHEEKPNOK PODFPEBPOAD = DIPHEEKPNOK.top;

	[FormerlySerializedAs("DOEANADCJNM")]
	public float ICLDLACLBDB;

	[FormerlySerializedAs("ODLFBCGLDBO")]
	public float OKFPHJNNEPG;

	public UIRoot root_saveGet
	{
		get
		{
			if (IJMDOGNBGIL == null)
			{
				IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
			}
			if (IJMDOGNBGIL == null)
			{
				Debug.LogError("NO any UIroot - failed " + base.name);
			}
			return IJMDOGNBGIL;
		}
	}

	private void Awake()
	{
		Align();
	}

	public void IIKDNLADLPN()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 410f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1941f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (AKJNJKILKCN() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1258f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 334f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 122f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.right)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1059f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void NCANBJOPOAB()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 615f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1467f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (OBGCBLLJKAF() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1942f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1347f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 35f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 236f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	private void EIPLFPJNCIB()
	{
		HAOLEHKOCCL();
	}

	private void DLOLBFOOEBA()
	{
		HAOLEHKOCCL();
	}

	[SpecialName]
	public UIRoot OBGCBLLJKAF()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("Gold" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void ADICIFEKPAF()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 729f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1136f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (DDHHKCIBBNC() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1620f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1171f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 32f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 756f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	[SpecialName]
	public UIRoot NGFKNIICDKD()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_CONFIRM_AREYOUSURE" + base.name);
		}
		return IJMDOGNBGIL;
	}

	[SpecialName]
	public UIRoot DDHHKCIBBNC()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("HELMETS" + base.name);
		}
		return IJMDOGNBGIL;
	}

	private void BMLLLOBPGIB()
	{
		DLGHMAJCMNF();
	}

	[SpecialName]
	public UIRoot EMCBBLDOCHF()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("Seats" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void DMNFAEDAAOH()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 273f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1336f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (MJOPMHFHJLP() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 524f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 332f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 52f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.downLeft)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 528f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void OHPPLCKGGBP()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 1156f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1665f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (GHBLMKGJIBK() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1712f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1917f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 1578f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.right)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1663f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	[SpecialName]
	public UIRoot KCACKHKAMEO()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("InstantBattleEnded: REWARD EXPERIENCE: " + base.name);
		}
		return IJMDOGNBGIL;
	}

	[SpecialName]
	public UIRoot LLNMBEGEHBO()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("USD" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void CFICKIJAIFD()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 1491f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 996f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (OBGCBLLJKAF() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 715f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 776f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 374f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.down)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1863f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	private void LBMFKIDPCBL()
	{
		DMNFAEDAAOH();
	}

	public void FNPLJDJHGKL()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 1281f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 364f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (JFNBINOLADE() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1125f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 50f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 1266f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.left)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1447f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	private void FANDCCNILLD()
	{
		INGGAFKNMOB();
	}

	[SpecialName]
	public UIRoot EIGLFEMKNPD()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("BS: player succesfully accepted to squad" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void ANEEONKCDJC()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 220f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 107f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (root_saveGet == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1492f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1526f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 214f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.left)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 425f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void CDBGNEJKJKF()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 550f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 143f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (IIEOJKGGHPC() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1272f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 776f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 737f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.left)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 54f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	private void IOKMAFLIJEG()
	{
		MIAAFDPAOLG();
	}

	[SpecialName]
	public UIRoot JFNBINOLADE()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("{0}: {1}\n" + base.name);
		}
		return IJMDOGNBGIL;
	}

	private void NGGJHDCOLEC()
	{
		CDBGNEJKJKF();
	}

	public void BEMBELIENEC()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 1614f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1076f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (MNJKEABJAMH() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1095f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1286f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 859f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.down)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1949f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	[SpecialName]
	public UIRoot MBJKGFNKJME()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_SEC" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void GHDPHJBELNA()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 358f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1643f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (MJOPMHFHJLP() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1822f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1303f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 858f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.down)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1418f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	private void MLBAFICPECE()
	{
		IMHBFLFMJFA();
	}

	public void Align()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 2f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 2f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (root_saveGet == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 2f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 2f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 2f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.downRight)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 2f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	private void FFBBKELEEIF()
	{
		NCANBJOPOAB();
	}

	public void IMHBFLFMJFA()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 36f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1645f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (root_saveGet == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1704f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 566f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 1591f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1400f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void HAOLEHKOCCL()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 1689f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1058f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (NBAKEIMCNHH() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 188f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1899f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 1216f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.center)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1659f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	private void PBIJLBHDFOK()
	{
		DMNFAEDAAOH();
	}

	[SpecialName]
	public UIRoot IPKKJJKJEBK()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("{0} {1}" + base.name);
		}
		return IJMDOGNBGIL;
	}

	private void FNJKFDOMGOO()
	{
		BEMBELIENEC();
	}

	[SpecialName]
	public UIRoot JDODFOBGMJM()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("nextGenerate" + base.name);
		}
		return IJMDOGNBGIL;
	}

	[SpecialName]
	public UIRoot BPCIPJHEJNB()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_UPGRADESMALL" + base.name);
		}
		return IJMDOGNBGIL;
	}

	[SpecialName]
	public UIRoot IIEOJKGGHPC()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("GameReward" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void DLGHMAJCMNF()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 1281f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1589f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (NBAKEIMCNHH() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1298f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 477f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 1336f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.center)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 239f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void NBHNICBJMNF()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 875f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1227f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (NBAKEIMCNHH() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1298f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 776f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 172f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1065f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void MJGKHGCEOCC()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 253f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 850f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (GHBLMKGJIBK() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 104f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1553f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 1474f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.downRight)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1497f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	[SpecialName]
	public UIRoot AKJNJKILKCN()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("Processing the request Timed Out!" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void INGGAFKNMOB()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 499f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1076f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.UIroot_Fixed)
		{
			if (MJOPMHFHJLP() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1771f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1746f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 276f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 31f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	[SpecialName]
	public UIRoot KOHOPADHFAJ()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("game-ico-poison" + base.name);
		}
		return IJMDOGNBGIL;
	}

	[SpecialName]
	public UIRoot MJOPMHFHJLP()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_TUTORIAL_GO_BUY_ARMY_4" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void MIAAFDPAOLG()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 363f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1301f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (KOHOPADHFAJ() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1837f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1293f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 921f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.down)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 75f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	private void BKNKFFEHJOA()
	{
		OHPPLCKGGBP();
	}

	private void PBCDDNOCJOI()
	{
		LOCEPMIKHLF();
	}

	[SpecialName]
	public UIRoot MNJKEABJAMH()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("Evaluation is old! " + base.name);
		}
		return IJMDOGNBGIL;
	}

	[SpecialName]
	public UIRoot GHBLMKGJIBK()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_STARTSINX" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void LOCEPMIKHLF()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 737f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1002f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (MNJKEABJAMH() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1273f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 642f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 125f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.top)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 269f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void HPOMBMKPOFL()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 1489f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1086f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (MNJKEABJAMH() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 356f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1427f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 1048f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.downLeft || PODFPEBPOAD == DIPHEEKPNOK.down)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1240f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void IHMCCPEODJO()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 434f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 47f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (EMCBBLDOCHF() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.top || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 960f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1908f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 170f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.center || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 1209f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	public void HIDKAGNKMHH()
	{
		if (CFFKHHJKBMJ == null)
		{
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			float num = ABLELIOLJKP.pixelWidth;
			float num2 = ABLELIOLJKP.pixelHeight;
			float num3 = num - AHDPIAOECNK.x;
			float num4 = num2 - AHDPIAOECNK.y;
			Vector4 clipRange = CFFKHHJKBMJ.clipRange;
			if (LHNDMADKMFF)
			{
				clipRange.x = CMFONIKNOLN.x - num3 / 1607f;
				clipRange.z = FOCCHODIACF.x + num3;
			}
			if (EDIHJOANNLJ)
			{
				clipRange.y = CMFONIKNOLN.y - num4 / 1810f;
				clipRange.w = FOCCHODIACF.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * ICLDLACLBDB;
			zero.y = num4 * OKFPHJNNEPG;
			CFFKHHJKBMJ.clipRange = clipRange;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero;
			return;
		}
		if (HPHDFNEIEFN == KNEKLHLBNHJ.Camera)
		{
			if (EMCBBLDOCHF() == null)
			{
				return;
			}
			Vector4 clipRange2 = CFFKHHJKBMJ.clipRange;
			Vector2 vector = new Vector2(IJMDOGNBGIL.activeWidth, IJMDOGNBGIL.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (LHNDMADKMFF)
			{
				float num5 = vector.x - AHDPIAOECNK.x;
				clipRange2.z = FOCCHODIACF.x + num5;
				if (PODFPEBPOAD == DIPHEEKPNOK.right || PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.topLeft)
				{
					clipRange2.x = CMFONIKNOLN.x + num5 / 1278f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.downRight || PODFPEBPOAD == DIPHEEKPNOK.topRight || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.x = CMFONIKNOLN.x - num5 / 1191f;
				}
				else
				{
					clipRange2.x = CMFONIKNOLN.x;
				}
				zero2.x = num5 * ICLDLACLBDB;
			}
			if (EDIHJOANNLJ)
			{
				float num6 = vector.y - AHDPIAOECNK.y;
				clipRange2.w = FOCCHODIACF.y + num6;
				if (PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topLeft || PODFPEBPOAD == DIPHEEKPNOK.topRight)
				{
					clipRange2.y = CMFONIKNOLN.y - num6 / 39f;
				}
				else if (PODFPEBPOAD == DIPHEEKPNOK.left || PODFPEBPOAD == DIPHEEKPNOK.down || PODFPEBPOAD == DIPHEEKPNOK.center)
				{
					clipRange2.y = CMFONIKNOLN.y + num6 / 611f;
				}
				else
				{
					clipRange2.y = CMFONIKNOLN.y;
				}
				zero2.y = num6 * OKFPHJNNEPG;
			}
			CFFKHHJKBMJ.clipRange = clipRange2;
			CFFKHHJKBMJ.transform.localPosition = FHMNGFGNFLL + zero2;
		}
		CFFKHHJKBMJ = null;
	}

	[SpecialName]
	public UIRoot NBAKEIMCNHH()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("0" + base.name);
		}
		return IJMDOGNBGIL;
	}
}
