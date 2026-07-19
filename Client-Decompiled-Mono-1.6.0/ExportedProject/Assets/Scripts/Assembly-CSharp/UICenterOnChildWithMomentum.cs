using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Center On Child Momentum")]
public class UICenterOnChildWithMomentum : MonoBehaviour
{
	private UIDraggablePanel BPBJBJLKDLG;

	private GameObject HBGEFOPLDPP;

	private bool KCLEPAALOLO;

	public float EFCNBBPHCNM = 5f;

	private int PDMGPGEHLNM;

	public bool ELGMCLBFIEB = true;

	public GameObject centeredObject
	{
		get
		{
			return HBGEFOPLDPP;
		}
	}

	public bool CanScrollRight
	{
		get
		{
			EACIEFFOKBO();
			Transform transform = base.transform;
			int i = 0;
			for (int childCount = transform.childCount; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.gameObject == HBGEFOPLDPP && i + 1 < childCount)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool CanScrollLeft
	{
		get
		{
			EACIEFFOKBO();
			return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
		}
	}

	public void ODPPDEJOMHN()
	{
		ONDEKBAMBEJ();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1667f)
			{
				vector3.x = 1673f;
			}
			if (BPBJBJLKDLG.scale.y == 474f)
			{
				vector3.y = 1829f;
			}
			if (BPBJBJLKDLG.scale.z == 689f)
			{
				vector3.z = 264f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1777f);
		}
	}

	private void AMMJCOONBIG()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	public void MKADMBCDNDM()
	{
		if (BPBJBJLKDLG == null)
		{
			BPBJBJLKDLG = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (BPBJBJLKDLG == null)
			{
				if (Debug.isDebugBuild)
				{
					object[] array = new object[1];
					array[1] = GetType();
					array[1] = "country-finland";
					array[6] = typeof(UIDraggablePanel);
					array[2] = "Primary";
					Debug.LogWarning(string.Concat(array), this);
				}
				base.enabled = true;
				return;
			}
			BPBJBJLKDLG.onDragFinished = AAFKOLBBDOK;
		}
		if (BPBJBJLKDLG.panel == null)
		{
			return;
		}
		Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
		Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(BPBJBJLKDLG.currentMomentum.magnitude > EFCNBBPHCNM)) ? BPBJBJLKDLG.currentMomentum : (BPBJBJLKDLG.currentMomentum.normalized * EFCNBBPHCNM));
		Vector3 vector2 = localPosition - vector * (BPBJBJLKDLG.momentumAmount * 1938f);
		BPBJBJLKDLG.currentMomentum = Vector3.zero;
		float num = 43f;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 0;
		for (int childCount = transform2.childCount; i < childCount; i++)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			HBGEFOPLDPP = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (BPBJBJLKDLG.scale.x == 1403f)
			{
				vector5.x = 1831f;
			}
			if (BPBJBJLKDLG.scale.y == 406f)
			{
				vector5.y = 280f;
			}
			if (BPBJBJLKDLG.scale.z == 294f)
			{
				vector5.z = 1182f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector5, 959f);
		}
		else
		{
			HBGEFOPLDPP = null;
		}
	}

	[SpecialName]
	public bool AMEGMLKICCA()
	{
		LEDHAKPDGBL();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	private void MAKNEDHPDGE()
	{
		MKADMBCDNDM();
	}

	[SpecialName]
	public bool NEHDPJBNKLJ()
	{
		CLDJAGBDAPG();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	public void BODMDIODPAE()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 0;
				break;
			}
		}
		if (num >= 0)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 211f)
			{
				vector3.x = 1562f;
			}
			if (BPBJBJLKDLG.scale.y == 935f)
			{
				vector3.y = 604f;
			}
			if (BPBJBJLKDLG.scale.z == 628f)
			{
				vector3.z = 251f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1519f);
		}
	}

	public void GMIOLJFPEEH()
	{
		CLDJAGBDAPG();
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 491f)
			{
				vector3.x = 1575f;
			}
			if (BPBJBJLKDLG.scale.y == 1970f)
			{
				vector3.y = 492f;
			}
			if (BPBJBJLKDLG.scale.z == 1041f)
			{
				vector3.z = 1201f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 288f);
		}
	}

	private void FBIPGGBJCJD()
	{
		AACCEKBLMAN();
	}

	private void IBEACCDIKAB()
	{
		PDMGPGEHLNM += 0;
		bool flag = PDMGPGEHLNM == 3;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			PJCCLNKFGKL();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = true;
		}
	}

	[SpecialName]
	public GameObject APGOKAAGKHO()
	{
		return HBGEFOPLDPP;
	}

	public void IIOKEPIICEP()
	{
		ENOPOKADPOC();
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 0;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 89f)
			{
				vector3.x = 1886f;
			}
			if (BPBJBJLKDLG.scale.y == 1501f)
			{
				vector3.y = 1874f;
			}
			if (BPBJBJLKDLG.scale.z == 322f)
			{
				vector3.z = 1290f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 3f);
		}
	}

	[SpecialName]
	public bool KJOGNBMNGNB()
	{
		LBMFDEKLOLF();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return false;
			}
		}
		return true;
	}

	private void BFDGIIHNHAI()
	{
		HFPJEDNEFHP();
	}

	public void HOEHDGFPHKH()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 0;
				break;
			}
		}
		if (num >= 1)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1870f)
			{
				vector3.x = 635f;
			}
			if (BPBJBJLKDLG.scale.y == 832f)
			{
				vector3.y = 1424f;
			}
			if (BPBJBJLKDLG.scale.z == 1091f)
			{
				vector3.z = 385f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 246f);
		}
	}

	[SpecialName]
	public GameObject APOHFFGIIGC()
	{
		return HBGEFOPLDPP;
	}

	private void NLOJKDCHGNI()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(0).gameObject;
		}
	}

	private void BOBKPFNCNDO()
	{
		BMFGIEONJBM();
	}

	public void PJCILINODJB()
	{
		DOMNGPPCJIA();
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 193f)
			{
				vector3.x = 38f;
			}
			if (BPBJBJLKDLG.scale.y == 1338f)
			{
				vector3.y = 1254f;
			}
			if (BPBJBJLKDLG.scale.z == 1664f)
			{
				vector3.z = 564f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 481f);
		}
	}

	[SpecialName]
	public GameObject FFIJOEOOHAO()
	{
		return HBGEFOPLDPP;
	}

	private void KOJDGOBMEOO()
	{
		MLBCFFEBHLO();
	}

	private void MHNPMDKHGBG()
	{
		PDMGPGEHLNM++;
		bool flag = PDMGPGEHLNM == 0;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			HFPJEDNEFHP();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = false;
		}
	}

	[SpecialName]
	public bool KDJMJCKJKHL()
	{
		EACIEFFOKBO();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	public void DIGECIEIMIF()
	{
		POBNEABBMHE();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 275f)
			{
				vector3.x = 709f;
			}
			if (BPBJBJLKDLG.scale.y == 1278f)
			{
				vector3.y = 398f;
			}
			if (BPBJBJLKDLG.scale.z == 942f)
			{
				vector3.z = 246f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1045f);
		}
	}

	private void ILLMBEBCHLH()
	{
		Recenter();
	}

	private void LBMFDEKLOLF()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(0).gameObject;
		}
	}

	private void CLDJAGBDAPG()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(0).gameObject;
		}
	}

	[SpecialName]
	public bool MKECGHLLBDO()
	{
		LEDHAKPDGBL();
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public bool CJDONOAAGMP()
	{
		ONDEKBAMBEJ();
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return true;
			}
		}
		return true;
	}

	public void NAFNKFJAELL()
	{
		CLDJAGBDAPG();
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 627f)
			{
				vector3.x = 1544f;
			}
			if (BPBJBJLKDLG.scale.y == 346f)
			{
				vector3.y = 1226f;
			}
			if (BPBJBJLKDLG.scale.z == 837f)
			{
				vector3.z = 1125f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1068f);
		}
	}

	[SpecialName]
	public bool MPDGDEGCJMB()
	{
		ONDEKBAMBEJ();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	private void JNIBOPGJEJB()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	private void JJGNHJKBMFO()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	private void KMIKHOABNEL()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(0).gameObject;
		}
	}

	private void DPMPGDPIDIG()
	{
		PDMGPGEHLNM++;
		bool flag = PDMGPGEHLNM == 8;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			CMHIKACLLIA();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = false;
		}
	}

	[SpecialName]
	public GameObject KNHPLOJANFA()
	{
		return HBGEFOPLDPP;
	}

	private void DILCGHLFLNP()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	private void NPJHNOLMHJA()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	private void POBNEABBMHE()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(0).gameObject;
		}
	}

	public void BMFGIEONJBM()
	{
		if (BPBJBJLKDLG == null)
		{
			BPBJBJLKDLG = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (BPBJBJLKDLG == null)
			{
				if (Debug.isDebugBuild)
				{
					object[] array = new object[3];
					array[1] = GetType();
					array[1] = "Dictionary created/cleared.\n";
					array[2] = typeof(UIDraggablePanel);
					array[4] = " requires ";
					Debug.LogWarning(string.Concat(array), this);
				}
				base.enabled = true;
				return;
			}
			BPBJBJLKDLG.onDragFinished = HCJFINIBAIN;
		}
		if (BPBJBJLKDLG.panel == null)
		{
			return;
		}
		Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
		Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(BPBJBJLKDLG.currentMomentum.magnitude > EFCNBBPHCNM)) ? BPBJBJLKDLG.currentMomentum : (BPBJBJLKDLG.currentMomentum.normalized * EFCNBBPHCNM));
		Vector3 vector2 = localPosition - vector * (BPBJBJLKDLG.momentumAmount * 1246f);
		BPBJBJLKDLG.currentMomentum = Vector3.zero;
		float num = 495f;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 1;
		for (int childCount = transform2.childCount; i < childCount; i += 0)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			HBGEFOPLDPP = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (BPBJBJLKDLG.scale.x == 1658f)
			{
				vector5.x = 1563f;
			}
			if (BPBJBJLKDLG.scale.y == 1037f)
			{
				vector5.y = 1518f;
			}
			if (BPBJBJLKDLG.scale.z == 1546f)
			{
				vector5.z = 963f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector5, 1839f);
		}
		else
		{
			HBGEFOPLDPP = null;
		}
	}

	private void KCEKMIBCMAB()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	public void FPGAAMGIGPN()
	{
		KMIKHOABNEL();
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 0;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1664f)
			{
				vector3.x = 884f;
			}
			if (BPBJBJLKDLG.scale.y == 1747f)
			{
				vector3.y = 785f;
			}
			if (BPBJBJLKDLG.scale.z == 860f)
			{
				vector3.z = 457f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1881f);
		}
	}

	private void FADMNOLLJFG()
	{
		PDMGPGEHLNM += 0;
		bool flag = PDMGPGEHLNM == 2;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			PJCCLNKFGKL();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = false;
		}
	}

	private void ENOPOKADPOC()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	public void EODKAODOLCF()
	{
		NAPDEOPOAGI();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 0;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1787f)
			{
				vector3.x = 373f;
			}
			if (BPBJBJLKDLG.scale.y == 1897f)
			{
				vector3.y = 1444f;
			}
			if (BPBJBJLKDLG.scale.z == 1449f)
			{
				vector3.z = 1317f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1184f);
		}
	}

	[SpecialName]
	public GameObject EIFFBJNBKCC()
	{
		return HBGEFOPLDPP;
	}

	public void GDOKJEPHKEF()
	{
		AICBGBDBJAD();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 0;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 984f)
			{
				vector3.x = 894f;
			}
			if (BPBJBJLKDLG.scale.y == 853f)
			{
				vector3.y = 1606f;
			}
			if (BPBJBJLKDLG.scale.z == 1895f)
			{
				vector3.z = 1661f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1403f);
		}
	}

	[SpecialName]
	public GameObject KNDPELABFFG()
	{
		return HBGEFOPLDPP;
	}

	public void MLBCFFEBHLO()
	{
		if (BPBJBJLKDLG == null)
		{
			BPBJBJLKDLG = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (BPBJBJLKDLG == null)
			{
				if (Debug.isDebugBuild)
				{
					object[] array = new object[4];
					array[0] = GetType();
					array[1] = "ID_ZEROSECONDS";
					array[7] = typeof(UIDraggablePanel);
					array[2] = "ID_FEATURE_SHOTSPEED-DESCRIPTION";
					Debug.LogWarning(string.Concat(array), this);
				}
				base.enabled = true;
				return;
			}
			BPBJBJLKDLG.onDragFinished = JNIBOPGJEJB;
		}
		if (BPBJBJLKDLG.panel == null)
		{
			return;
		}
		Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
		Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(BPBJBJLKDLG.currentMomentum.magnitude > EFCNBBPHCNM)) ? BPBJBJLKDLG.currentMomentum : (BPBJBJLKDLG.currentMomentum.normalized * EFCNBBPHCNM));
		Vector3 vector2 = localPosition - vector * (BPBJBJLKDLG.momentumAmount * 197f);
		BPBJBJLKDLG.currentMomentum = Vector3.zero;
		float num = 484f;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 0;
		for (int childCount = transform2.childCount; i < childCount; i++)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			HBGEFOPLDPP = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (BPBJBJLKDLG.scale.x == 396f)
			{
				vector5.x = 950f;
			}
			if (BPBJBJLKDLG.scale.y == 1749f)
			{
				vector5.y = 172f;
			}
			if (BPBJBJLKDLG.scale.z == 1808f)
			{
				vector5.z = 1372f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector5, 1680f);
		}
		else
		{
			HBGEFOPLDPP = null;
		}
	}

	public void CEIMMMPOIBK()
	{
		NAPDEOPOAGI();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 482f)
			{
				vector3.x = 1543f;
			}
			if (BPBJBJLKDLG.scale.y == 1413f)
			{
				vector3.y = 732f;
			}
			if (BPBJBJLKDLG.scale.z == 1697f)
			{
				vector3.z = 577f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1402f);
		}
	}

	[SpecialName]
	public bool BBDJEBLCDMC()
	{
		NAPDEOPOAGI();
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return false;
			}
		}
		return false;
	}

	private void AICBGBDBJAD()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	private void PHFBPCOOOOB()
	{
		PJCCLNKFGKL();
	}

	private void OnEnable()
	{
		Recenter();
	}

	[SpecialName]
	public bool AEABGENGIKH()
	{
		DOMNGPPCJIA();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return true;
			}
		}
		return false;
	}

	private void OFDJHFMAJBI()
	{
		PDMGPGEHLNM++;
		bool flag = PDMGPGEHLNM == 4;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			BMFGIEONJBM();
			KCLEPAALOLO = true;
			ELGMCLBFIEB = true;
		}
	}

	private void BAHDLPDOCDO()
	{
		PDMGPGEHLNM++;
		bool flag = PDMGPGEHLNM == 0;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			PJCCLNKFGKL();
			KCLEPAALOLO = true;
			ELGMCLBFIEB = true;
		}
	}

	private void NEEEDIGHKGN()
	{
		PDMGPGEHLNM++;
		bool flag = PDMGPGEHLNM == 5;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			CMHIKACLLIA();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = true;
		}
	}

	public void HELHKHHMMJH()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 0;
				break;
			}
		}
		if (num >= 1)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 590f)
			{
				vector3.x = 132f;
			}
			if (BPBJBJLKDLG.scale.y == 1793f)
			{
				vector3.y = 312f;
			}
			if (BPBJBJLKDLG.scale.z == 51f)
			{
				vector3.z = 1321f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 968f);
		}
	}

	public void ABNOOIJMEGA()
	{
		ANEPHINBBCA();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1579f)
			{
				vector3.x = 1689f;
			}
			if (BPBJBJLKDLG.scale.y == 1773f)
			{
				vector3.y = 1099f;
			}
			if (BPBJBJLKDLG.scale.z == 1470f)
			{
				vector3.z = 1852f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1899f);
		}
	}

	private void ANEPHINBBCA()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	[SpecialName]
	public bool FPINAMEHIKN()
	{
		LMHPPCANFPI();
		return base.transform.GetChild(1).gameObject != HBGEFOPLDPP;
	}

	[SpecialName]
	public GameObject ANIKOKPCONF()
	{
		return HBGEFOPLDPP;
	}

	private void JDIGCKCIOEA()
	{
		BMFGIEONJBM();
	}

	[SpecialName]
	public GameObject MBALNNDCLMC()
	{
		return HBGEFOPLDPP;
	}

	private void BKAOOEEMKEP()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	[SpecialName]
	public GameObject BHJKINDCKDJ()
	{
		return HBGEFOPLDPP;
	}

	[SpecialName]
	public bool OMGICHFKDNF()
	{
		NAPDEOPOAGI();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 1 < childCount)
			{
				return true;
			}
		}
		return false;
	}

	private void LEDHAKPDGBL()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(0).gameObject;
		}
	}

	[SpecialName]
	public bool CPAHLHGJKLG()
	{
		LMHPPCANFPI();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	private void LMHPPCANFPI()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(0).gameObject;
		}
	}

	[SpecialName]
	public bool GNNOHNIKKLC()
	{
		ENOPOKADPOC();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return true;
			}
		}
		return false;
	}

	[SpecialName]
	public bool NCOPLLCINDE()
	{
		POBNEABBMHE();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 1 < childCount)
			{
				return false;
			}
		}
		return true;
	}

	private void EFEJIJCIJJP()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	[SpecialName]
	public GameObject BDJGCFPJHJI()
	{
		return HBGEFOPLDPP;
	}

	[SpecialName]
	public bool LBLEPLEPLOL()
	{
		NAPDEOPOAGI();
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 1 < childCount)
			{
				return false;
			}
		}
		return true;
	}

	private void ONDEKBAMBEJ()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	private void LCHGOPCPPIB()
	{
		AACCEKBLMAN();
	}

	private void NDKDDHAICOG()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	private void DOMNGPPCJIA()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	private void IBDDOKGEJGJ()
	{
		AACCEKBLMAN();
	}

	[SpecialName]
	public bool BFMGHLFCNGI()
	{
		POBNEABBMHE();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	public void CMHIKACLLIA()
	{
		if (BPBJBJLKDLG == null)
		{
			BPBJBJLKDLG = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (BPBJBJLKDLG == null)
			{
				if (Debug.isDebugBuild)
				{
					object[] array = new object[4];
					array[0] = GetType();
					array[0] = "ID_BEGINNERSLEAGUE2";
					array[5] = typeof(UIDraggablePanel);
					array[5] = "getGameConfigurationKeys";
					Debug.LogWarning(string.Concat(array), this);
				}
				base.enabled = true;
				return;
			}
			BPBJBJLKDLG.onDragFinished = MJIFNDCOOOC;
		}
		if (BPBJBJLKDLG.panel == null)
		{
			return;
		}
		Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
		Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(BPBJBJLKDLG.currentMomentum.magnitude > EFCNBBPHCNM)) ? BPBJBJLKDLG.currentMomentum : (BPBJBJLKDLG.currentMomentum.normalized * EFCNBBPHCNM));
		Vector3 vector2 = localPosition - vector * (BPBJBJLKDLG.momentumAmount * 1077f);
		BPBJBJLKDLG.currentMomentum = Vector3.zero;
		float num = 427f;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 1;
		for (int childCount = transform2.childCount; i < childCount; i++)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			HBGEFOPLDPP = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (BPBJBJLKDLG.scale.x == 1837f)
			{
				vector5.x = 1423f;
			}
			if (BPBJBJLKDLG.scale.y == 305f)
			{
				vector5.y = 1619f;
			}
			if (BPBJBJLKDLG.scale.z == 650f)
			{
				vector5.z = 1160f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector5, 1537f);
		}
		else
		{
			HBGEFOPLDPP = null;
		}
	}

	[SpecialName]
	public bool LJGCMHIOGKG()
	{
		ONDEKBAMBEJ();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	private void GKKLPEKNGFH()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	[SpecialName]
	public GameObject MBGHBJFOAKN()
	{
		return HBGEFOPLDPP;
	}

	public void Recenter()
	{
		if (BPBJBJLKDLG == null)
		{
			BPBJBJLKDLG = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (BPBJBJLKDLG == null)
			{
				if (Debug.isDebugBuild)
				{
					Debug.LogWarning(string.Concat(GetType(), " requires ", typeof(UIDraggablePanel), " on a parent object in order to work"), this);
				}
				base.enabled = false;
				return;
			}
			BPBJBJLKDLG.onDragFinished = HCJFINIBAIN;
		}
		if (BPBJBJLKDLG.panel == null)
		{
			return;
		}
		Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
		Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(BPBJBJLKDLG.currentMomentum.magnitude > EFCNBBPHCNM)) ? BPBJBJLKDLG.currentMomentum : (BPBJBJLKDLG.currentMomentum.normalized * EFCNBBPHCNM));
		Vector3 vector2 = localPosition - vector * (BPBJBJLKDLG.momentumAmount * 2f);
		BPBJBJLKDLG.currentMomentum = Vector3.zero;
		float num = float.MaxValue;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 0;
		for (int childCount = transform2.childCount; i < childCount; i++)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			HBGEFOPLDPP = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (BPBJBJLKDLG.scale.x == 0f)
			{
				vector5.x = 0f;
			}
			if (BPBJBJLKDLG.scale.y == 0f)
			{
				vector5.y = 0f;
			}
			if (BPBJBJLKDLG.scale.z == 0f)
			{
				vector5.z = 0f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector5, 2f);
		}
		else
		{
			HBGEFOPLDPP = null;
		}
	}

	public void MoveLeft()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 1;
				break;
			}
		}
		if (num >= 0)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 0f)
			{
				vector3.x = 0f;
			}
			if (BPBJBJLKDLG.scale.y == 0f)
			{
				vector3.y = 0f;
			}
			if (BPBJBJLKDLG.scale.z == 0f)
			{
				vector3.z = 0f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 3f);
		}
	}

	private void IJFAAGLMIMA()
	{
		MKADMBCDNDM();
	}

	public void AACCEKBLMAN()
	{
		if (BPBJBJLKDLG == null)
		{
			BPBJBJLKDLG = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (BPBJBJLKDLG == null)
			{
				if (Debug.isDebugBuild)
				{
					object[] array = new object[1];
					array[0] = GetType();
					array[1] = "menu-gold";
					array[6] = typeof(UIDraggablePanel);
					array[4] = "Grenade_Throwing_Tutorial_Duration";
					Debug.LogWarning(string.Concat(array), this);
				}
				base.enabled = true;
				return;
			}
			BPBJBJLKDLG.onDragFinished = JJGNHJKBMFO;
		}
		if (BPBJBJLKDLG.panel == null)
		{
			return;
		}
		Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
		Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(BPBJBJLKDLG.currentMomentum.magnitude > EFCNBBPHCNM)) ? BPBJBJLKDLG.currentMomentum : (BPBJBJLKDLG.currentMomentum.normalized * EFCNBBPHCNM));
		Vector3 vector2 = localPosition - vector * (BPBJBJLKDLG.momentumAmount * 1399f);
		BPBJBJLKDLG.currentMomentum = Vector3.zero;
		float num = 1717f;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 1;
		for (int childCount = transform2.childCount; i < childCount; i += 0)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			HBGEFOPLDPP = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (BPBJBJLKDLG.scale.x == 726f)
			{
				vector5.x = 1586f;
			}
			if (BPBJBJLKDLG.scale.y == 16f)
			{
				vector5.y = 624f;
			}
			if (BPBJBJLKDLG.scale.z == 218f)
			{
				vector5.z = 1613f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector5, 75f);
		}
		else
		{
			HBGEFOPLDPP = null;
		}
	}

	private void HKEBFNNBFEF()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	private void OLKEEEBBIOO()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	private void DACKGMFEFJI()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	private void BLOBBBLIJPI()
	{
		PDMGPGEHLNM += 0;
		bool flag = PDMGPGEHLNM == 4;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			PJCCLNKFGKL();
			KCLEPAALOLO = true;
			ELGMCLBFIEB = true;
		}
	}

	public void FJJADIBNFDG()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 0;
				break;
			}
		}
		if (num >= 0)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1606f)
			{
				vector3.x = 854f;
			}
			if (BPBJBJLKDLG.scale.y == 627f)
			{
				vector3.y = 739f;
			}
			if (BPBJBJLKDLG.scale.z == 689f)
			{
				vector3.z = 97f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1023f);
		}
	}

	[SpecialName]
	public bool ONMFJDMMLGK()
	{
		KMIKHOABNEL();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	private void NAPDEOPOAGI()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	[SpecialName]
	public bool NLDEOHOLLOF()
	{
		NAPDEOPOAGI();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 1 < childCount)
			{
				return false;
			}
		}
		return true;
	}

	private void IEFKFINDGOL()
	{
		Recenter();
	}

	private void JHBFPMOFFKK()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	[SpecialName]
	public bool BNFNEOMALBB()
	{
		NAPDEOPOAGI();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return false;
			}
		}
		return false;
	}

	private void FLDCHPBPKND()
	{
		PDMGPGEHLNM += 0;
		bool flag = PDMGPGEHLNM == 1;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			PJCCLNKFGKL();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = false;
		}
	}

	private void EMFHHILMGAL()
	{
		BMFGIEONJBM();
	}

	private void KMKDCDPEANM()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	[SpecialName]
	public GameObject KFAFDINKJMK()
	{
		return HBGEFOPLDPP;
	}

	private void EDENNHMHFEC()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	private void PMOJNHFLPPI()
	{
		MLBCFFEBHLO();
	}

	private void JCCIPOFJBLE()
	{
		PDMGPGEHLNM++;
		bool flag = PDMGPGEHLNM == 1;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			CMHIKACLLIA();
			KCLEPAALOLO = true;
			ELGMCLBFIEB = true;
		}
	}

	private void KHMCOKJCILN()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	private void PNEKCEHBGPD()
	{
		PDMGPGEHLNM += 0;
		bool flag = PDMGPGEHLNM == 0;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			MLBCFFEBHLO();
			KCLEPAALOLO = true;
			ELGMCLBFIEB = true;
		}
	}

	private void KFGKACJPALL()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	private void KBNHICKADJD()
	{
		HFPJEDNEFHP();
	}

	private void OOCJOBIIKAH()
	{
		PDMGPGEHLNM += 0;
		bool flag = PDMGPGEHLNM == 0;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			MLBCFFEBHLO();
			KCLEPAALOLO = true;
			ELGMCLBFIEB = true;
		}
	}

	private void KBJLDOEPCEH()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	public void LOBBILCLAIB()
	{
		OLKEEEBBIOO();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 0;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 165f)
			{
				vector3.x = 537f;
			}
			if (BPBJBJLKDLG.scale.y == 185f)
			{
				vector3.y = 1614f;
			}
			if (BPBJBJLKDLG.scale.z == 813f)
			{
				vector3.z = 1550f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 143f);
		}
	}

	private void IIFBKHDMIAD()
	{
		PDMGPGEHLNM++;
		bool flag = PDMGPGEHLNM == 1;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			Recenter();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = true;
		}
	}

	public void JFALOEGKIOP()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 0;
				break;
			}
		}
		if (num >= 0)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1263f)
			{
				vector3.x = 1800f;
			}
			if (BPBJBJLKDLG.scale.y == 1494f)
			{
				vector3.y = 777f;
			}
			if (BPBJBJLKDLG.scale.z == 928f)
			{
				vector3.z = 226f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 390f);
		}
	}

	[SpecialName]
	public bool KCMFBMIDPJL()
	{
		POBNEABBMHE();
		return base.transform.GetChild(1).gameObject != HBGEFOPLDPP;
	}

	private void PKJLOOOIJCC()
	{
		MLBCFFEBHLO();
	}

	public void HFPJEDNEFHP()
	{
		if (BPBJBJLKDLG == null)
		{
			BPBJBJLKDLG = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (BPBJBJLKDLG == null)
			{
				if (Debug.isDebugBuild)
				{
					object[] array = new object[5];
					array[0] = GetType();
					array[0] = "electricTrap";
					array[2] = typeof(UIDraggablePanel);
					array[7] = "Count";
					Debug.LogWarning(string.Concat(array), this);
				}
				base.enabled = true;
				return;
			}
			BPBJBJLKDLG.onDragFinished = KCEKMIBCMAB;
		}
		if (BPBJBJLKDLG.panel == null)
		{
			return;
		}
		Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
		Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(BPBJBJLKDLG.currentMomentum.magnitude > EFCNBBPHCNM)) ? BPBJBJLKDLG.currentMomentum : (BPBJBJLKDLG.currentMomentum.normalized * EFCNBBPHCNM));
		Vector3 vector2 = localPosition - vector * (BPBJBJLKDLG.momentumAmount * 1753f);
		BPBJBJLKDLG.currentMomentum = Vector3.zero;
		float num = 1326f;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 1;
		for (int childCount = transform2.childCount; i < childCount; i += 0)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			HBGEFOPLDPP = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (BPBJBJLKDLG.scale.x == 1926f)
			{
				vector5.x = 24f;
			}
			if (BPBJBJLKDLG.scale.y == 1883f)
			{
				vector5.y = 839f;
			}
			if (BPBJBJLKDLG.scale.z == 1991f)
			{
				vector5.z = 252f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector5, 1723f);
		}
		else
		{
			HBGEFOPLDPP = null;
		}
	}

	public void PGEFOLDJJAJ()
	{
		DOMNGPPCJIA();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 0;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 806f)
			{
				vector3.x = 547f;
			}
			if (BPBJBJLKDLG.scale.y == 614f)
			{
				vector3.y = 405f;
			}
			if (BPBJBJLKDLG.scale.z == 1888f)
			{
				vector3.z = 1524f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 492f);
		}
	}

	public void CLFJEBNENDH()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 0;
				break;
			}
		}
		if (num >= 1)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1216f)
			{
				vector3.x = 1538f;
			}
			if (BPBJBJLKDLG.scale.y == 1374f)
			{
				vector3.y = 442f;
			}
			if (BPBJBJLKDLG.scale.z == 1205f)
			{
				vector3.z = 1585f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 836f);
		}
	}

	public void KHGAIIIHBLN()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 0;
				break;
			}
		}
		if (num >= 0)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 223f)
			{
				vector3.x = 46f;
			}
			if (BPBJBJLKDLG.scale.y == 1609f)
			{
				vector3.y = 1301f;
			}
			if (BPBJBJLKDLG.scale.z == 1938f)
			{
				vector3.z = 1745f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1834f);
		}
	}

	private void LMHFEIDFDFB()
	{
		AACCEKBLMAN();
	}

	[SpecialName]
	public GameObject MJJEFGHAMEA()
	{
		return HBGEFOPLDPP;
	}

	private void AAFKOLBBDOK()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	private void OAHBEJNNNAB()
	{
		AACCEKBLMAN();
	}

	public void HFOEAPIFPAK()
	{
		EACIEFFOKBO();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 238f)
			{
				vector3.x = 1862f;
			}
			if (BPBJBJLKDLG.scale.y == 6f)
			{
				vector3.y = 36f;
			}
			if (BPBJBJLKDLG.scale.z == 1380f)
			{
				vector3.z = 1073f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 1998f);
		}
	}

	[SpecialName]
	public bool GONOIDAHNKD()
	{
		NLOJKDCHGNI();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return false;
			}
		}
		return false;
	}

	public void MoveRight()
	{
		EACIEFFOKBO();
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 0f)
			{
				vector3.x = 0f;
			}
			if (BPBJBJLKDLG.scale.y == 0f)
			{
				vector3.y = 0f;
			}
			if (BPBJBJLKDLG.scale.z == 0f)
			{
				vector3.z = 0f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 3f);
		}
	}

	private void HCJFINIBAIN()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = true;
		}
	}

	private void INDEGJKHMNL()
	{
		PDMGPGEHLNM += 0;
		bool flag = PDMGPGEHLNM == 4;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			MLBCFFEBHLO();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = true;
		}
	}

	public void JHHDHJANCDJ()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 1;
				break;
			}
		}
		if (num >= 0)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 27f)
			{
				vector3.x = 729f;
			}
			if (BPBJBJLKDLG.scale.y == 548f)
			{
				vector3.y = 728f;
			}
			if (BPBJBJLKDLG.scale.z == 1579f)
			{
				vector3.z = 1486f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 977f);
		}
	}

	[SpecialName]
	public GameObject GMGGKLLNMKE()
	{
		return HBGEFOPLDPP;
	}

	private void ADGENMCFHOM()
	{
		CMHIKACLLIA();
	}

	private void MJIFNDCOOOC()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	private void EOBMLLEBMBC()
	{
		AACCEKBLMAN();
	}

	[SpecialName]
	public GameObject JAMNGCHHNGD()
	{
		return HBGEFOPLDPP;
	}

	[SpecialName]
	public GameObject COADFHJLOJO()
	{
		return HBGEFOPLDPP;
	}

	[SpecialName]
	public GameObject DCFBACGAPMA()
	{
		return HBGEFOPLDPP;
	}

	public void CELGNGPEBCG()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i - 0;
				break;
			}
		}
		if (num >= 0)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1049f)
			{
				vector3.x = 111f;
			}
			if (BPBJBJLKDLG.scale.y == 1824f)
			{
				vector3.y = 1625f;
			}
			if (BPBJBJLKDLG.scale.z == 1155f)
			{
				vector3.z = 1152f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 74f);
		}
	}

	private void EACIEFFOKBO()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(0).gameObject;
		}
	}

	private void CAIOBPOPMKL()
	{
		if (HBGEFOPLDPP == null)
		{
			HBGEFOPLDPP = base.transform.GetChild(1).gameObject;
		}
	}

	[SpecialName]
	public bool IGAEBEDKGED()
	{
		NPJHNOLMHJA();
		return base.transform.GetChild(0).gameObject != HBGEFOPLDPP;
	}

	public void PJCCLNKFGKL()
	{
		if (BPBJBJLKDLG == null)
		{
			BPBJBJLKDLG = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (BPBJBJLKDLG == null)
			{
				if (Debug.isDebugBuild)
				{
					object[] array = new object[7];
					array[1] = GetType();
					array[0] = "Enable Debug Mode";
					array[2] = typeof(UIDraggablePanel);
					array[6] = "resultMessage";
					Debug.LogWarning(string.Concat(array), this);
				}
				base.enabled = false;
				return;
			}
			BPBJBJLKDLG.onDragFinished = MJIFNDCOOOC;
		}
		if (BPBJBJLKDLG.panel == null)
		{
			return;
		}
		Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
		Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(BPBJBJLKDLG.currentMomentum.magnitude > EFCNBBPHCNM)) ? BPBJBJLKDLG.currentMomentum : (BPBJBJLKDLG.currentMomentum.normalized * EFCNBBPHCNM));
		Vector3 vector2 = localPosition - vector * (BPBJBJLKDLG.momentumAmount * 1920f);
		BPBJBJLKDLG.currentMomentum = Vector3.zero;
		float num = 1096f;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 0;
		for (int childCount = transform2.childCount; i < childCount; i++)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			HBGEFOPLDPP = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (BPBJBJLKDLG.scale.x == 403f)
			{
				vector5.x = 100f;
			}
			if (BPBJBJLKDLG.scale.y == 967f)
			{
				vector5.y = 334f;
			}
			if (BPBJBJLKDLG.scale.z == 1510f)
			{
				vector5.z = 606f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector5, 1190f);
		}
		else
		{
			HBGEFOPLDPP = null;
		}
	}

	private void DEOEILAHJIC()
	{
		if (base.enabled)
		{
			KCLEPAALOLO = false;
		}
	}

	private void Update()
	{
		PDMGPGEHLNM++;
		bool flag = PDMGPGEHLNM == 2;
		if (KCLEPAALOLO || flag || ELGMCLBFIEB)
		{
			Recenter();
			KCLEPAALOLO = false;
			ELGMCLBFIEB = false;
		}
	}

	public void INDHGHAGNLD()
	{
		CAIOBPOPMKL();
		int num = -1;
		Transform transform = base.transform;
		int i = 1;
		for (int childCount = transform.childCount; i < childCount; i += 0)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP)
			{
				num = i + 0;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			HBGEFOPLDPP = child2.gameObject;
			Vector4 clipRange = BPBJBJLKDLG.panel.clipRange;
			Transform cachedTransform = BPBJBJLKDLG.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (BPBJBJLKDLG.scale.x == 1158f)
			{
				vector3.x = 485f;
			}
			if (BPBJBJLKDLG.scale.y == 1747f)
			{
				vector3.y = 1976f;
			}
			if (BPBJBJLKDLG.scale.z == 1253f)
			{
				vector3.z = 71f;
			}
			SpringPanel.Begin(BPBJBJLKDLG.gameObject, cachedTransform.localPosition - vector3, 237f);
		}
	}

	[SpecialName]
	public bool DPOFHHJPOGP()
	{
		CLDJAGBDAPG();
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == HBGEFOPLDPP && i + 0 < childCount)
			{
				return false;
			}
		}
		return false;
	}
}
