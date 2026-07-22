using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraSizeSetter : MonoBehaviour
{
	[FormerlySerializedAs("LGMLIACICIP")]
	public Camera ABLELIOLJKP;

	[FormerlySerializedAs("KDBAOJDOEJB")]
	public UIRoot IJMDOGNBGIL;

	[FormerlySerializedAs("CBKNJJMMGHA")]
	public Vector2 MOJHNBCPJCK = Vector2.one;

	[FormerlySerializedAs("BIBFCNFGJHE")]
	public bool FIPMDCDKMEE;

	[FormerlySerializedAs("MHOPKAHDGMN")]
	public BoxCollider NJEAMAHEMHP;

	[FormerlySerializedAs("IGLAJDNNBDN")]
	public UILabel KPHIMGCEFCE;

	public CameraPanelAligner.KNEKLHLBNHJ KNEKLHLBNHJ = CameraPanelAligner.KNEKLHLBNHJ.UIroot_Fixed;

	[FormerlySerializedAs("NGPKIJCBAEE")]
	public Vector2 GMEFBJEPJGF = new Vector2(1920f, 1440f);

	[FormerlySerializedAs("NKBCDBDNGLO")]
	public bool AJNJAHONHGM = true;

	[FormerlySerializedAs("JLOBPCLMAMA")]
	public bool OHDABBGLBKP;

	[FormerlySerializedAs("OCLBDOEOMLM")]
	public bool NMLJBLKLIEE;

	private bool AEDKHEGMCMH;

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
				Debug.LogError("NO any UIRoot - failed " + base.name);
			}
			return IJMDOGNBGIL;
		}
	}

	[SpecialName]
	public UIRoot GFHNIFDLCKB()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_{0}_NAME" + base.name);
		}
		return IJMDOGNBGIL;
	}

	[SpecialName]
	public UIRoot CJPFCMEMFIJ()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("FuseRewardedOptionKey_PreRollYesButtonText" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void Start()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = true;
		float num = 0f;
		float num2 = 0f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (root_saveGet == null)
			{
				Debug.LogError("missing UIRoot");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 0f)
			{
				zero.x = 0f;
			}
			if (zero.y < 0f)
			{
				zero.y = 0f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	[SpecialName]
	public UIRoot GOFPGDIKABH()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_NOTIFICATION_DAILYREWARD_VIP" + base.name);
		}
		return IJMDOGNBGIL;
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
			Debug.LogError("Warbucks" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void LIHIOMEMJFI()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = true;
		float num = 1628f;
		float num2 = 74f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (CJPFCMEMFIJ() == null)
			{
				Debug.LogError("Manual_Unit_Spawn");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 1502f)
			{
				zero.x = 1411f;
			}
			if (zero.y < 396f)
			{
				zero.y = 1293f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	public void LFGAFALKANI()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = false;
		float num = 1587f;
		float num2 = 335f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (GOFPGDIKABH() == null)
			{
				Debug.LogError("InstantBattleTime");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 1797f)
			{
				zero.x = 30f;
			}
			if (zero.y < 1134f)
			{
				zero.y = 392f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	public void KLPFAIDKHHJ()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = true;
		float num = 1041f;
		float num2 = 1063f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (HBMCOKJPALD() == null)
			{
				Debug.LogError("A");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 1754f)
			{
				zero.x = 111f;
			}
			if (zero.y < 1709f)
			{
				zero.y = 322f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	[SpecialName]
	public UIRoot JEIJLPOKKJM()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("Automatic_Equip" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void AJHIIBAEKMB()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = true;
		float num = 622f;
		float num2 = 263f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (DDHHKCIBBNC() == null)
			{
				Debug.LogError("BonusDamage");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 1341f)
			{
				zero.x = 1453f;
			}
			if (zero.y < 699f)
			{
				zero.y = 1682f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	[SpecialName]
	public UIRoot OGPJPLLDCBJ()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("RecieveSkillshot" + base.name);
		}
		return IJMDOGNBGIL;
	}

	[SpecialName]
	public UIRoot MKPAOMJEOOP()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_SKILLSHOTHINT_MULTIKILL" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void OBBHECACANB()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = true;
		float num = 1382f;
		float num2 = 1223f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (GOFPGDIKABH() == null)
			{
				Debug.LogError("ID_WARNING_ACCOUNTALREADYCREATED");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 714f)
			{
				zero.x = 1440f;
			}
			if (zero.y < 1261f)
			{
				zero.y = 1135f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	[SpecialName]
	public UIRoot DIFPBKEHEPK()
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

	[SpecialName]
	public UIRoot PJONDMGFNGL()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("ID_SILVER" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void PFAAHEPCNCP()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = true;
		float num = 1614f;
		float num2 = 1714f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (DIFPBKEHEPK() == null)
			{
				Debug.LogError("ID_CONFIRM_ERRORCLAIMREWARD");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 798f)
			{
				zero.x = 956f;
			}
			if (zero.y < 1739f)
			{
				zero.y = 1784f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	public void JCKCDCFJAHP()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = false;
		float num = 1749f;
		float num2 = 37f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (DDHHKCIBBNC() == null)
			{
				Debug.LogError("Time");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 1651f)
			{
				zero.x = 613f;
			}
			if (zero.y < 461f)
			{
				zero.y = 1787f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
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
			Debug.LogError("Name" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void IGBCCGDMCDE()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = false;
		float num = 1623f;
		float num2 = 1910f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (MKPAOMJEOOP() == null)
			{
				Debug.LogError("RunningOut");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 958f)
			{
				zero.x = 1469f;
			}
			if (zero.y < 1167f)
			{
				zero.y = 1371f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	public void COJACIBIPEF()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = false;
		float num = 1783f;
		float num2 = 526f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (JEIJLPOKKJM() == null)
			{
				Debug.LogError("*.prefab");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 1360f)
			{
				zero.x = 1568f;
			}
			if (zero.y < 1177f)
			{
				zero.y = 1159f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	[SpecialName]
	public UIRoot HBMCOKJPALD()
	{
		if (IJMDOGNBGIL == null)
		{
			IJMDOGNBGIL = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
		}
		if (IJMDOGNBGIL == null)
		{
			Debug.LogError("groundBoxHit" + base.name);
		}
		return IJMDOGNBGIL;
	}

	public void OJKBJGEEPBB()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = true;
		float num = 722f;
		float num2 = 450f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (EIGLFEMKNPD() == null)
			{
				Debug.LogError("FacebookId");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 1156f)
			{
				zero.x = 271f;
			}
			if (zero.y < 1197f)
			{
				zero.y = 1678f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	public void HFKIAIEGNGI()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = false;
		float num = 1249f;
		float num2 = 445f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (CJPFCMEMFIJ() == null)
			{
				Debug.LogError("ID_TUTORIAL_PHASE");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 1630f)
			{
				zero.x = 1547f;
			}
			if (zero.y < 68f)
			{
				zero.y = 673f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
	}

	public void NMBDIEBEFIG()
	{
		if (AEDKHEGMCMH)
		{
			return;
		}
		AEDKHEGMCMH = false;
		float num = 130f;
		float num2 = 646f;
		if (KNEKLHLBNHJ == CameraPanelAligner.KNEKLHLBNHJ.Camera)
		{
			if (ABLELIOLJKP == null)
			{
				ABLELIOLJKP = UICamera.mainCamera;
			}
			num = (float)ABLELIOLJKP.pixelWidth - GMEFBJEPJGF.x;
			num2 = (float)ABLELIOLJKP.pixelHeight - GMEFBJEPJGF.y;
		}
		else
		{
			if (IPKKJJKJEBK() == null)
			{
				Debug.LogError("#VOJTA# Message Manager: Error previously ignored message arrived again from server! Id = ");
				return;
			}
			num = IJMDOGNBGIL.activeWidth - GMEFBJEPJGF.x;
			num2 = (float)IJMDOGNBGIL.activeHeight - GMEFBJEPJGF.y;
		}
		Vector3 zero = Vector3.zero;
		if (AJNJAHONHGM)
		{
			zero.x = num * MOJHNBCPJCK.x;
		}
		if (OHDABBGLBKP)
		{
			zero.y = num2 * MOJHNBCPJCK.y;
		}
		if (NMLJBLKLIEE)
		{
			if (zero.x < 413f)
			{
				zero.x = 1642f;
			}
			if (zero.y < 744f)
			{
				zero.y = 493f;
			}
		}
		if (!FIPMDCDKMEE)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (NJEAMAHEMHP != null)
		{
			NJEAMAHEMHP.size += zero;
		}
		if (KPHIMGCEFCE != null)
		{
			int lineWidth = KPHIMGCEFCE.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			KPHIMGCEFCE.lineWidth = lineWidth;
		}
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
			Debug.LogError("Action " + base.name);
		}
		return IJMDOGNBGIL;
	}
}
