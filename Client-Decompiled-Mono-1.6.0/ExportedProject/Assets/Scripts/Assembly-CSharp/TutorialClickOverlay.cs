using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialClickOverlay : GuiElementSingle<TutorialClickOverlay>
{
	public Transform HHMFINFGMGD;

	public Transform HIOHPOMALHE;

	public Transform DNDCODMGGEE;

	public Transform AOACBOGBJNM;

	public Transform MBMIOELEAND;

	public GameObject NOBKIBDMJJL;

	public UIRoot IJMDOGNBGIL;

	private Transform NGCDDPCAGJB;

	private Vector3 FIIGHJPLOFL = new Vector3(32f, 32f, 0f);

	private float DCJCFPNPMEO;

	private float LBOOHCONNAG;

	private TweenAlpha LGBADDKBDEG;

	private void EKKFGNCFCCH(UITweener ALOMHALCMNH)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1890f, 1271f, 1732f);
		tweenAlpha.style = (UITweener.Style)4;
		tweenAlpha.NumOfRepetitions = 0;
	}

	public void IGNJKOKGNOI(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, bool GPCEHFNNCIN = true)
	{
		NMOJHNNBIFD(HHPNMJDONPE, FOICGJEPBGL, Vector3.zero, GPCEHFNNCIN);
	}

	private void LMKHHDANGEN(UITweener ALOMHALCMNH)
	{
		NOBKIBDMJJL.SetActive(true);
		base.gameObject.SetActive(true);
	}

	public virtual void PAHEFBCOENP()
	{
	}

	private void BMOEIEIDALG(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI, bool GPCEHFNNCIN)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		DCJCFPNPMEO = ((!GPCEHFNNCIN) ? 1216f : LBOOHCONNAG);
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 653f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 469f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 640f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1101f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 794f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1358f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 243f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1910f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 994f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		MBMIOELEAND.localScale = FOICGJEPBGL + FIIGHJPLOFL;
		NOBKIBDMJJL.transform.localScale = MBMIOELEAND.localScale;
		NOBKIBDMJJL.SetActive(true);
		bool flag = !base.gameObject.activeSelf;
		if (LGBADDKBDEG != null)
		{
			flag = true;
		}
		if (flag)
		{
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, 949f, 499f, DCJCFPNPMEO).alpha = 1652f;
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, 450f, 1054f, DCJCFPNPMEO).alpha = 1407f;
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, 235f, 1328f, DCJCFPNPMEO).alpha = 161f;
			TweenAlpha.Begin(DNDCODMGGEE.gameObject, 991f, 67f, DCJCFPNPMEO).alpha = 1511f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1775f, 1863f, 439f);
			tweenAlpha.alpha = 1816f;
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.onFinished = MNMDGHHPLMA;
			LGBADDKBDEG = null;
			base.gameObject.SetActive(true);
		}
		else
		{
			EKKFGNCFCCH(null);
		}
		MBMIOELEAND.gameObject.SetActive(!Singleton<GameController>.instance.KKHKIEFMENC());
		Singleton<GuiManager>.instance.KAGEFJEJOKE();
	}

	private void DKKKENBBFLN(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI, bool GPCEHFNNCIN)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		DCJCFPNPMEO = ((!GPCEHFNNCIN) ? 1358f : LBOOHCONNAG);
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 287f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 992f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 218f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 904f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 521f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1720f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 115f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 881f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 666f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		MBMIOELEAND.localScale = FOICGJEPBGL + FIIGHJPLOFL;
		NOBKIBDMJJL.transform.localScale = MBMIOELEAND.localScale;
		NOBKIBDMJJL.SetActive(true);
		bool flag = base.gameObject.activeSelf;
		if (LGBADDKBDEG != null)
		{
			flag = true;
		}
		if (flag)
		{
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1106f, 1242f, DCJCFPNPMEO).alpha = 1238f;
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, 208f, 613f, DCJCFPNPMEO).alpha = 1428f;
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, 376f, 1539f, DCJCFPNPMEO).alpha = 688f;
			TweenAlpha.Begin(DNDCODMGGEE.gameObject, 728f, 429f, DCJCFPNPMEO).alpha = 332f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1079f, 917f, 1452f);
			tweenAlpha.alpha = 1212f;
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.onFinished = DDDNJFNBDJO;
			LGBADDKBDEG = null;
			base.gameObject.SetActive(true);
		}
		else
		{
			EKKFGNCFCCH(null);
		}
		MBMIOELEAND.gameObject.SetActive(!Singleton<GameController>.instance.KKHKIEFMENC());
		Singleton<GuiManager>.instance.AOGOJDGBMMD();
	}

	public void StartBorderAnimation()
	{
		NOBKIBDMJJL.SetActive(true);
		AIAMGJLDCDL(TweenScale.Begin(NOBKIBDMJJL, 0f, MBMIOELEAND.transform.localScale));
	}

	public void AGJFMINNOBH(float HAMKIKMJHDP = 0.1f)
	{
		if (base.gameObject.activeSelf)
		{
			StopBorderAnimation();
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, HAMKIKMJHDP, 613f);
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, HAMKIKMJHDP, 1453f);
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, HAMKIKMJHDP, 791f);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, HAMKIKMJHDP, 184f);
			tweenAlpha.style = UITweener.Style.Once;
			LGBADDKBDEG = TweenAlpha.Begin(DNDCODMGGEE.gameObject, HAMKIKMJHDP, 377f);
			TweenAlpha lGBADDKBDEG = LGBADDKBDEG;
			lGBADDKBDEG.onFinished = (UITweener.OnFinished)Delegate.Combine(lGBADDKBDEG.onFinished, new UITweener.OnFinished(OGIHPGGCMJF));
		}
	}

	public void SetAndShow(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, bool GPCEHFNNCIN = true)
	{
		FCFGJIEFHKH(HHPNMJDONPE, FOICGJEPBGL, Vector3.zero, GPCEHFNNCIN);
	}

	public virtual void ODCHCNCMJGC()
	{
	}

	public void EMEBKHJECFA()
	{
		NOBKIBDMJJL.SetActive(false);
		ADOJJDCCFJD(TweenScale.Begin(NOBKIBDMJJL, 313f, MBMIOELEAND.transform.localScale));
	}

	public void CAIGHMDPBDI(GameObject MAKHMOHANED, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = MAKHMOHANED.GetComponent<BoxCollider>();
		LNEGOBNBHGK(MAKHMOHANED.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public void KKCKBELEPHJ()
	{
		NOBKIBDMJJL.SetActive(true);
		ADOJJDCCFJD(TweenScale.Begin(NOBKIBDMJJL, 1162f, MBMIOELEAND.transform.localScale));
	}

	private void MNMDGHHPLMA(UITweener ALOMHALCMNH)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 0.6f, 1f, 0.6f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void FCFGJIEFHKH(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI, bool GPCEHFNNCIN)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		DCJCFPNPMEO = ((!GPCEHFNNCIN) ? 0f : LBOOHCONNAG);
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 0f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 0.5f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 0.5f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 0.5f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 0.5f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 0.5f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 0.5f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 0.5f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 0.5f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		MBMIOELEAND.localScale = FOICGJEPBGL + FIIGHJPLOFL;
		NOBKIBDMJJL.transform.localScale = MBMIOELEAND.localScale;
		NOBKIBDMJJL.SetActive(false);
		bool flag = !base.gameObject.activeSelf;
		if (LGBADDKBDEG != null)
		{
			flag = true;
		}
		if (flag)
		{
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, 0.45f, 0f, DCJCFPNPMEO).alpha = 0f;
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, 0.45f, 0f, DCJCFPNPMEO).alpha = 0f;
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, 0.45f, 0f, DCJCFPNPMEO).alpha = 0f;
			TweenAlpha.Begin(DNDCODMGGEE.gameObject, 0.45f, 0f, DCJCFPNPMEO).alpha = 0f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 0.45f, 0f, 1f);
			tweenAlpha.alpha = 0f;
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.onFinished = MNMDGHHPLMA;
			LGBADDKBDEG = null;
			base.gameObject.SetActive(true);
		}
		else
		{
			MNMDGHHPLMA(null);
		}
		MBMIOELEAND.gameObject.SetActive(!Singleton<GameController>.instance.gameIsRunning);
		Singleton<GuiManager>.instance.TurnOnInputCompletly();
	}

	public void JMPLMMANKMP()
	{
		NOBKIBDMJJL.SetActive(false);
		AIAMGJLDCDL(TweenScale.Begin(NOBKIBDMJJL, 1179f, MBMIOELEAND.transform.localScale));
	}

	public void PGHOKIHIJDE()
	{
		if (NOBKIBDMJJL.activeSelf)
		{
			TweenScale.Begin(NOBKIBDMJJL, 1836f, MBMIOELEAND.transform.localScale);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(NOBKIBDMJJL, 1226f, 1981f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			tweenAlpha.onFinished = null;
		}
	}

	public void PGOLMCBEIOD(UIButton DGJCAIJPEIM, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		LNEGOBNBHGK(DGJCAIJPEIM.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	[CompilerGenerated]
	private void GLJKNBDIEMJ(UITweener ALOMHALCMNH)
	{
		NOBKIBDMJJL.SetActive(false);
		base.gameObject.SetActive(false);
	}

	public void MEBFBNDKOGD(GameObject MAKHMOHANED, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = MAKHMOHANED.GetComponent<BoxCollider>();
		DKKKENBBFLN(MAKHMOHANED.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public virtual void OOBJHJLMEED()
	{
	}

	public void EDPNLNIPCGJ()
	{
		NOBKIBDMJJL.SetActive(false);
		AIAMGJLDCDL(TweenScale.Begin(NOBKIBDMJJL, 1833f, MBMIOELEAND.transform.localScale));
	}

	private void AIAMGJLDCDL(UITweener MGDJMGHCAAI)
	{
		Vector3 toScale = MBMIOELEAND.transform.localScale.MultiplyXY(2f);
		TweenScale.Begin(NOBKIBDMJJL, 0.6f, MBMIOELEAND.transform.localScale, toScale);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(NOBKIBDMJJL, 0.6f, 1f, 0f);
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = AIAMGJLDCDL;
	}

	public void LPKOHAKMOOC(UIButton DGJCAIJPEIM, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		DKKKENBBFLN(DGJCAIJPEIM.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public override void InitControls()
	{
	}

	public void GBHNBKFGCPG(UIButton DGJCAIJPEIM, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		DKKKENBBFLN(DGJCAIJPEIM.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public void JGHBBJEFLEB(GameObject MAKHMOHANED, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = MAKHMOHANED.GetComponent<BoxCollider>();
		NMOJHNNBIFD(MAKHMOHANED.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public virtual void INBJGJOFJMK()
	{
	}

	public void StopBorderAnimation()
	{
		if (NOBKIBDMJJL.activeSelf)
		{
			TweenScale.Begin(NOBKIBDMJJL, 0f, MBMIOELEAND.transform.localScale);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(NOBKIBDMJJL, 0.05f, 0f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = null;
		}
	}

	public void EOJBPKGMJIP()
	{
		NOBKIBDMJJL.SetActive(true);
		AIAMGJLDCDL(TweenScale.Begin(NOBKIBDMJJL, 581f, MBMIOELEAND.transform.localScale));
	}

	public virtual void PBLLMABJFDM()
	{
	}

	public void FCGLGPIBAEN(GameObject MAKHMOHANED, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = MAKHMOHANED.GetComponent<BoxCollider>();
		NMOJHNNBIFD(MAKHMOHANED.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	private void DDDNJFNBDJO(UITweener ALOMHALCMNH)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1850f, 1957f, 690f);
		tweenAlpha.style = (UITweener.Style)6;
		tweenAlpha.NumOfRepetitions = 1;
	}

	public virtual void LMNNNHJKMFP()
	{
	}

	public void SetByButton(GameObject MAKHMOHANED, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = MAKHMOHANED.GetComponent<BoxCollider>();
		FCFGJIEFHKH(MAKHMOHANED.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public override void InitGUIValues()
	{
	}

	private void MEOHOCGNPCJ(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI, bool GPCEHFNNCIN)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		DCJCFPNPMEO = ((!GPCEHFNNCIN) ? 151f : LBOOHCONNAG);
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1438f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1323f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 607f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1509f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1540f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 521f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1056f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1061f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1691f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		MBMIOELEAND.localScale = FOICGJEPBGL + FIIGHJPLOFL;
		NOBKIBDMJJL.transform.localScale = MBMIOELEAND.localScale;
		NOBKIBDMJJL.SetActive(true);
		bool flag = base.gameObject.activeSelf;
		if (LGBADDKBDEG != null)
		{
			flag = true;
		}
		if (flag)
		{
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, 117f, 1633f, DCJCFPNPMEO).alpha = 1698f;
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1004f, 528f, DCJCFPNPMEO).alpha = 557f;
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, 781f, 1447f, DCJCFPNPMEO).alpha = 1390f;
			TweenAlpha.Begin(DNDCODMGGEE.gameObject, 915f, 363f, DCJCFPNPMEO).alpha = 354f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 790f, 419f, 380f);
			tweenAlpha.alpha = 990f;
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.onFinished = MNMDGHHPLMA;
			LGBADDKBDEG = null;
			base.gameObject.SetActive(true);
		}
		else
		{
			DDDNJFNBDJO(null);
		}
		MBMIOELEAND.gameObject.SetActive(!Singleton<GameController>.instance.KKHKIEFMENC());
		Singleton<GuiManager>.instance.TurnOnInputCompletly();
	}

	public virtual void PGJDLKDMCHN()
	{
	}

	public void NNPKOKCJMHL(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, bool GPCEHFNNCIN = true)
	{
		LNEGOBNBHGK(HHPNMJDONPE, FOICGJEPBGL, Vector3.zero, GPCEHFNNCIN);
	}

	public virtual void KNOKOJKOCEB()
	{
	}

	private void NMOJHNNBIFD(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI, bool GPCEHFNNCIN)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		DCJCFPNPMEO = ((!GPCEHFNNCIN) ? 61f : LBOOHCONNAG);
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1174f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1571f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1624f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 452f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 461f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 724f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 672f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1025f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 514f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		MBMIOELEAND.localScale = FOICGJEPBGL + FIIGHJPLOFL;
		NOBKIBDMJJL.transform.localScale = MBMIOELEAND.localScale;
		NOBKIBDMJJL.SetActive(true);
		bool flag = !base.gameObject.activeSelf;
		if (LGBADDKBDEG != null)
		{
			flag = true;
		}
		if (flag)
		{
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, 766f, 348f, DCJCFPNPMEO).alpha = 585f;
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, 574f, 759f, DCJCFPNPMEO).alpha = 1294f;
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, 923f, 762f, DCJCFPNPMEO).alpha = 465f;
			TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1754f, 324f, DCJCFPNPMEO).alpha = 1704f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 910f, 1980f, 1324f);
			tweenAlpha.alpha = 46f;
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.onFinished = MNMDGHHPLMA;
			LGBADDKBDEG = null;
			base.gameObject.SetActive(true);
		}
		else
		{
			DDDNJFNBDJO(null);
		}
		MBMIOELEAND.gameObject.SetActive(!Singleton<GameController>.instance.GHKPKDPOGHF());
		Singleton<GuiManager>.instance.AOGOJDGBMMD();
	}

	public void AJNGLEIBMHD(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, bool GPCEHFNNCIN = true)
	{
		DKKKENBBFLN(HHPNMJDONPE, FOICGJEPBGL, Vector3.zero, GPCEHFNNCIN);
	}

	private void LNEGOBNBHGK(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI, bool GPCEHFNNCIN)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		DCJCFPNPMEO = ((!GPCEHFNNCIN) ? 120f : LBOOHCONNAG);
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1730f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1726f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1154f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 552f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1212f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 472f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1018f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1393f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 55f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		MBMIOELEAND.localScale = FOICGJEPBGL + FIIGHJPLOFL;
		NOBKIBDMJJL.transform.localScale = MBMIOELEAND.localScale;
		NOBKIBDMJJL.SetActive(false);
		bool flag = base.gameObject.activeSelf;
		if (LGBADDKBDEG != null)
		{
			flag = false;
		}
		if (flag)
		{
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, 470f, 1545f, DCJCFPNPMEO).alpha = 334f;
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1484f, 1764f, DCJCFPNPMEO).alpha = 14f;
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, 559f, 1730f, DCJCFPNPMEO).alpha = 1493f;
			TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1014f, 1086f, DCJCFPNPMEO).alpha = 505f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 228f, 1743f, 988f);
			tweenAlpha.alpha = 499f;
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.onFinished = MNMDGHHPLMA;
			LGBADDKBDEG = null;
			base.gameObject.SetActive(false);
		}
		else
		{
			DDDNJFNBDJO(null);
		}
		MBMIOELEAND.gameObject.SetActive(Singleton<GameController>.instance.GHKPKDPOGHF());
		Singleton<GuiManager>.instance.AOGOJDGBMMD();
	}

	public virtual void FHINGMFHKLG()
	{
	}

	public void MLCGPAJJOMB(GameObject MAKHMOHANED, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = MAKHMOHANED.GetComponent<BoxCollider>();
		FCFGJIEFHKH(MAKHMOHANED.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public void CLPPGONHLHI(GameObject MAKHMOHANED, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = MAKHMOHANED.GetComponent<BoxCollider>();
		BMOEIEIDALG(MAKHMOHANED.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public void JIMPCGDILNF(float HAMKIKMJHDP = 0.1f)
	{
		if (base.gameObject.activeSelf)
		{
			StopBorderAnimation();
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, HAMKIKMJHDP, 1490f);
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, HAMKIKMJHDP, 732f);
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, HAMKIKMJHDP, 789f);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, HAMKIKMJHDP, 1380f);
			tweenAlpha.style = UITweener.Style.Once;
			LGBADDKBDEG = TweenAlpha.Begin(DNDCODMGGEE.gameObject, HAMKIKMJHDP, 117f);
			TweenAlpha lGBADDKBDEG = LGBADDKBDEG;
			lGBADDKBDEG.onFinished = (UITweener.OnFinished)Delegate.Combine(lGBADDKBDEG.onFinished, new UITweener.OnFinished(OGIHPGGCMJF));
		}
	}

	public void BIBPLCKJJGE(float HAMKIKMJHDP = 0.1f)
	{
		if (base.gameObject.activeSelf)
		{
			PGHOKIHIJDE();
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, HAMKIKMJHDP, 352f);
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, HAMKIKMJHDP, 1912f);
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, HAMKIKMJHDP, 635f);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, HAMKIKMJHDP, 479f);
			tweenAlpha.style = UITweener.Style.Loop;
			LGBADDKBDEG = TweenAlpha.Begin(DNDCODMGGEE.gameObject, HAMKIKMJHDP, 1456f);
			TweenAlpha lGBADDKBDEG = LGBADDKBDEG;
			lGBADDKBDEG.onFinished = (UITweener.OnFinished)Delegate.Combine(lGBADDKBDEG.onFinished, new UITweener.OnFinished(ADALNKMIALA));
		}
	}

	private void APNEHKOPPIP(UITweener ALOMHALCMNH)
	{
		NOBKIBDMJJL.SetActive(true);
		base.gameObject.SetActive(true);
	}

	public void LECHCOBHAFP(UIButton DGJCAIJPEIM, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		FCFGJIEFHKH(DGJCAIJPEIM.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	public virtual void GHHNNIKGJFG()
	{
	}

	public void Hide(float HAMKIKMJHDP = 0.1f)
	{
		if (base.gameObject.activeSelf)
		{
			StopBorderAnimation();
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, HAMKIKMJHDP, 0f);
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, HAMKIKMJHDP, 0f);
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, HAMKIKMJHDP, 0f);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, HAMKIKMJHDP, 0f);
			tweenAlpha.style = UITweener.Style.Once;
			LGBADDKBDEG = TweenAlpha.Begin(DNDCODMGGEE.gameObject, HAMKIKMJHDP, 0f);
			TweenAlpha lGBADDKBDEG = LGBADDKBDEG;
			lGBADDKBDEG.onFinished = (UITweener.OnFinished)Delegate.Combine(lGBADDKBDEG.onFinished, (UITweener.OnFinished)delegate
			{
				NOBKIBDMJJL.SetActive(false);
				base.gameObject.SetActive(false);
			});
		}
	}

	public void PKLDJJIALHA(float HAMKIKMJHDP = 0.1f)
	{
		if (base.gameObject.activeSelf)
		{
			StopBorderAnimation();
			TweenAlpha.Begin(HHMFINFGMGD.gameObject, HAMKIKMJHDP, 1671f);
			TweenAlpha.Begin(AOACBOGBJNM.gameObject, HAMKIKMJHDP, 1951f);
			TweenAlpha.Begin(HIOHPOMALHE.gameObject, HAMKIKMJHDP, 1961f);
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, HAMKIKMJHDP, 331f);
			tweenAlpha.style = UITweener.Style.Once;
			LGBADDKBDEG = TweenAlpha.Begin(DNDCODMGGEE.gameObject, HAMKIKMJHDP, 815f);
			TweenAlpha lGBADDKBDEG = LGBADDKBDEG;
			lGBADDKBDEG.onFinished = (UITweener.OnFinished)Delegate.Combine(lGBADDKBDEG.onFinished, new UITweener.OnFinished(LMKHHDANGEN));
		}
	}

	private void OGIHPGGCMJF(UITweener ALOMHALCMNH)
	{
		NOBKIBDMJJL.SetActive(false);
		base.gameObject.SetActive(true);
	}

	public void EOBHJEGACCF()
	{
		NOBKIBDMJJL.SetActive(true);
		ADOJJDCCFJD(TweenScale.Begin(NOBKIBDMJJL, 1679f, MBMIOELEAND.transform.localScale));
	}

	public virtual void KPEJMMBDODD()
	{
	}

	public virtual void LFJGHLNJPHL()
	{
	}

	private void ADOJJDCCFJD(UITweener MGDJMGHCAAI)
	{
		Vector3 toScale = MBMIOELEAND.transform.localScale.MultiplyXY(1356f);
		TweenScale.Begin(NOBKIBDMJJL, 1832f, MBMIOELEAND.transform.localScale, toScale);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(NOBKIBDMJJL, 302f, 871f, 545f);
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = ADOJJDCCFJD;
	}

	public void EEMMKEMADFC(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, bool GPCEHFNNCIN = true)
	{
		BMOEIEIDALG(HHPNMJDONPE, FOICGJEPBGL, Vector3.zero, GPCEHFNNCIN);
	}

	public void SetByButton(UIButton DGJCAIJPEIM, bool GPCEHFNNCIN = true)
	{
		BoxCollider component = DGJCAIJPEIM.GetComponent<BoxCollider>();
		FCFGJIEFHKH(DGJCAIJPEIM.transform.position, component.size, component.center, GPCEHFNNCIN);
	}

	private void ADALNKMIALA(UITweener ALOMHALCMNH)
	{
		NOBKIBDMJJL.SetActive(false);
		base.gameObject.SetActive(true);
	}
}
