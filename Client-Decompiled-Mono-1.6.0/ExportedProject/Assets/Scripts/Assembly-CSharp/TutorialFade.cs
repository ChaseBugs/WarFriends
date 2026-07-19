using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialFade : GuiElementSingle<TutorialFade>
{
	public Transform HHMFINFGMGD;

	public Transform HIOHPOMALHE;

	public Transform DNDCODMGGEE;

	public Transform AOACBOGBJNM;

	public UIRoot IJMDOGNBGIL;

	private Transform NGCDDPCAGJB;

	private float LBOOHCONNAG;

	public Vector3 MPHCNMDIPAI;

	public Vector3 GAOKLHCHCND;

	public Vector3 FOICGJEPBGL;

	public bool NABOFKMBMKH;

	public bool FEGLHNIALBB;

	public virtual void BPPNPHGOBEA()
	{
	}

	public void DELBHPNLCOG(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1222f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1560f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 681f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 474f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1348f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 337f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1732f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 996f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 66f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 378f, 380f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 701f, 974f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1749f, 503f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1714f, 1983f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	public virtual void PNMEGHGABEP()
	{
	}

	private void GNLKPHFJBAC(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	private void DBBDIBHEPAG(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	public void AEPIPFOPLFD(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1163f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 311f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1127f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1446f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 260f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 680f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1592f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1064f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1401f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1363f, 415f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1535f, 547f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1290f, 234f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1304f, 1105f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public virtual void FPMIAIIFBBA()
	{
	}

	public void OIMDJAAAAPN()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 253f, 267f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 171f, 835f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 850f, 631f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1289f, 1211f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(MJHDMGOPLEO));
	}

	protected virtual void KNIAAECLFFK()
	{
		base.IIFBKHDMIAD();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = false;
			BPFJONPKCFI(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = true;
			KIDLDBKKJAD();
		}
	}

	protected virtual void JOCHCGHAIGH()
	{
		base.OGJGIMLMJBF();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = true;
			KFCCLPCKMLL(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = true;
			KIDLDBKKJAD();
		}
	}

	protected virtual void OEEJHKFLFAB()
	{
		base.IIFBKHDMIAD();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = true;
			GADBINHPJOJ(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = false;
			GDLOAPIHMOB();
		}
	}

	public void SetAndShow(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
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
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 0.45f, 0f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 0.45f, 0f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 0.45f, 0f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 0.45f, 0f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public void HFEHPCIBCJK()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1797f, 1419f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 865f, 1754f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1768f, 1897f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1254f, 222f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(GNLKPHFJBAC));
	}

	public virtual void EHNFJGINHDJ()
	{
	}

	[CompilerGenerated]
	private void GLJKNBDIEMJ(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(false);
	}

	public void MLMNHFLJFHP(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1920f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 847f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1943f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1659f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 15f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1180f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1948f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1203f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1880f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1004f, 1746f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1722f, 891f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1790f, 1439f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 755f, 1376f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public void DJCAEOEAPDN(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 875f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1638f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 200f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1177f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 125f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1959f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 156f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 767f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 445f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1862f, 136f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 380f, 1156f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 337f, 1007f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1373f, 358f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	public virtual void EGMFAHMCCBM()
	{
	}

	protected virtual void OOCJOBIIKAH()
	{
		base.BOEMHLPLOGA();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = true;
			JMKBEAPFEFG(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = false;
			MPLOCJMIAOG();
		}
	}

	public override void InitControls()
	{
	}

	public void FGIGICALLHJ()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1718f, 1073f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1560f, 302f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 473f, 580f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 428f, 689f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(DKLECNBEFKF));
	}

	private void MJHDMGOPLEO(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(false);
	}

	public virtual void HOBEPBFPFKG()
	{
	}

	public virtual void LBIJJNEOELO()
	{
	}

	public void BNMBJJLAMIE()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 794f, 1794f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 512f, 1370f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1504f, 1949f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 54f, 375f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(CLLAPLBKAHD));
	}

	private void CMHACPEHEMI(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	protected override void Update()
	{
		base.Update();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = false;
			SetAndShow(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = false;
			Hide();
		}
	}

	public virtual void NEECLAOCOKD()
	{
	}

	private void DIMKLJOHDKC(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(false);
	}

	public virtual void EMGHCAHOJNC()
	{
	}

	private void GDGJJFHHDHI(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	public void MLBCFLODGKF(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 286f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1029f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1099f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1618f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 838f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1477f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1231f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 215f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 946f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1039f, 1264f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 524f, 1476f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1474f, 1973f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1091f, 1857f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	public void KFCCLPCKMLL(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1874f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1976f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 785f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1318f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1324f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 590f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1540f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1951f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 398f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 416f, 894f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1872f, 406f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1192f, 1896f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 352f, 1034f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	public virtual void DJIJBPFLOMJ()
	{
	}

	protected virtual void CFLALBENGJN()
	{
		base.OGJGIMLMJBF();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = true;
			JPCKEHABGHD(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = true;
			DBCMJNMMECC();
		}
	}

	private void HBCAKHEEECL(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(false);
	}

	public void GADBINHPJOJ(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 988f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1249f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 970f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1626f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1876f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 506f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 256f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1224f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 874f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 80f, 578f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 883f, 1475f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1491f, 1977f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1285f, 106f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public void DKJBNOMDJIC()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 882f, 1363f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1500f, 709f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 285f, 778f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 530f, 1946f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(APNEHKOPPIP));
	}

	public void BPFJONPKCFI(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 742f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 722f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1983f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1503f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1247f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 735f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 86f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1067f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1500f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1848f, 1408f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 715f, 1517f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1431f, 600f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 669f, 1797f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	public virtual void KMCKIIFEKCA()
	{
	}

	public virtual void KFANFNCILJI()
	{
	}

	public virtual void EBOBKBJNNDK()
	{
	}

	public void KIDLDBKKJAD()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1423f, 28f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1466f, 1561f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 705f, 197f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1001f, 1526f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(GNLKPHFJBAC));
	}

	public virtual void BCLAFFCPCEH()
	{
	}

	private void DKLECNBEFKF(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(false);
	}

	public virtual void HHLOGFGGHHD()
	{
	}

	public virtual void BAAOGDMJCLK()
	{
	}

	private void APNEHKOPPIP(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(false);
	}

	public void PLJIDGNBILL(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 505f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1431f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 15f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1313f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1866f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1450f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 932f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 909f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 986f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 807f, 1825f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1710f, 136f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 229f, 620f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1803f, 1469f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	public void MPLOCJMIAOG()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1451f, 874f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 822f, 180f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 962f, 516f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1557f, 1049f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(ABBHJOLINJA));
	}

	public void ALLANJAFHBL(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 602f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 64f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1246f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 647f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1154f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1348f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1554f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1221f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1684f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1338f, 1080f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 784f, 1058f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 20f, 1298f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1603f, 458f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public virtual void OJKCMCPJPGO()
	{
	}

	protected virtual void NCLHOHNKMOJ()
	{
		base.OGJGIMLMJBF();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = false;
			DELBHPNLCOG(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = true;
			OIMDJAAAAPN();
		}
	}

	public virtual void JDFDJPAAIAA()
	{
	}

	public void JMKBEAPFEFG(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1415f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1279f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1320f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1896f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1497f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 770f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1933f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1394f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 733f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 459f, 654f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 244f, 413f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 600f, 1969f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 721f, 478f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public virtual void KLPJPLHNFON()
	{
	}

	public virtual void CHPAFPBJAEM()
	{
	}

	public virtual void NDBAEHKKJMH()
	{
	}

	public virtual void GFLLEMCAJGN()
	{
	}

	private void PLIKECGJIPG(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	public virtual void HJJOAJHBKCH()
	{
	}

	public virtual void DFKLIKFAKGA()
	{
	}

	protected virtual void IAPBHPLNNNO()
	{
		base.BOEMHLPLOGA();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = true;
			MLMNHFLJFHP(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = false;
			BMINKIDMOGL();
		}
	}

	public void NOGIKDILBLG()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 699f, 1641f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 591f, 271f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1695f, 619f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 406f, 792f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(DKLECNBEFKF));
	}

	public virtual void IMPMPKNJICB()
	{
	}

	public virtual void FJJHFMBOFDO()
	{
	}

	public void NMBHFCGOKMK()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 527f, 1083f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 134f, 1907f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 966f, 887f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 72f, 65f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(CLLAPLBKAHD));
	}

	public virtual void IJHNPCPFEKF()
	{
	}

	public void HNNOLIDOGLP(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1005f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1506f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1906f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1809f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 394f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1359f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1467f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 896f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1750f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1037f, 105f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 230f, 1584f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1090f, 1944f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1455f, 154f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public void DBCMJNMMECC()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 61f, 726f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 601f, 1484f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1817f, 537f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1199f, 6f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(HBCAKHEEECL));
	}

	public virtual void KFLBEIPPMBF()
	{
	}

	private void ABBHJOLINJA(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	public virtual void COBDHBOCGAP()
	{
	}

	public void FODIGMGHBLH(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1757f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 260f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1815f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 442f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1281f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1984f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1909f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 900f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 226f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 282f, 1604f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1341f, 201f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1273f, 5f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 622f, 1034f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	public void OGLOMHGHBCA(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1156f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1030f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 34f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1501f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 485f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1119f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 385f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 567f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 723f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 337f, 146f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 960f, 1473f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 974f, 952f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 535f, 941f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	protected virtual void CBOIHLDFKPI()
	{
		base.Update();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = false;
			ALLANJAFHBL(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = true;
			DKJBNOMDJIC();
		}
	}

	private void OJEEMBIEDPL(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	private void HCKJGACBHHI(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(false);
	}

	public void GNCFLLFBLLO()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 450f, 899f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1256f, 253f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1017f, 1640f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 789f, 745f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(EEKKLFBDEFH));
	}

	public void BMINKIDMOGL()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 174f, 49f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 95f, 1992f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 812f, 508f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1659f, 365f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(PNIMDLGLACA));
	}

	public void NNOOPCFHDJK()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 247f, 1353f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 751f, 1471f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 222f, 1248f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 20f, 59f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(PLIKECGJIPG));
	}

	protected virtual void CJPFLJAAODD()
	{
		base.Update();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = false;
			BPFJONPKCFI(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = false;
			HOALJOIMHFA();
		}
	}

	protected virtual void AAABJNBFLEG()
	{
		base.IIFBKHDMIAD();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = true;
			ALLANJAFHBL(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = false;
			KIDLDBKKJAD();
		}
	}

	public override void InitGUIValues()
	{
	}

	protected virtual void CDJBEAIDHKH()
	{
		base.BOEMHLPLOGA();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = true;
			GADBINHPJOJ(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = false;
			BNMBJJLAMIE();
		}
	}

	public virtual void AIIIDDDAPGB()
	{
	}

	public void DGMBLHMCFBI(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1999f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1184f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1979f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1784f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 391f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1598f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 892f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1502f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1152f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 719f, 606f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 342f, 827f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1165f, 240f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1361f, 1727f, LBOOHCONNAG);
		base.gameObject.SetActive(false);
	}

	public void EIKAOALHAPO()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 690f, 398f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1652f, 1458f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 393f, 1967f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1237f, 1072f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(CLLAPLBKAHD));
	}

	public void GDLOAPIHMOB()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1236f, 1922f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1845f, 676f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1003f, 1767f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 110f, 544f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(GNLKPHFJBAC));
	}

	private void EEKKLFBDEFH(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	public virtual void PGPFDLFAIBN()
	{
	}

	public void PLKBAOEKDGB(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1961f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1474f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 1371f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 934f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 1008f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1024f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 801f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 843f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 528f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 113f, 872f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 103f, 1930f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1354f, 951f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 1497f, 1904f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public virtual void ICNGBKKANLB()
	{
	}

	protected virtual void IODGCIIDJEK()
	{
		base.BOEMHLPLOGA();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = true;
			JMKBEAPFEFG(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = true;
			OIMDJAAAAPN();
		}
	}

	public void HOALJOIMHFA()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 809f, 931f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1692f, 1336f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1164f, 979f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 80f, 147f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(CLLAPLBKAHD));
	}

	protected virtual void NFEDNDPFHFI()
	{
		base.IIFBKHDMIAD();
		if (NABOFKMBMKH)
		{
			NABOFKMBMKH = false;
			HNNOLIDOGLP(base.transform.position, FOICGJEPBGL, GAOKLHCHCND);
		}
		if (FEGLHNIALBB)
		{
			FEGLHNIALBB = false;
			DBCMJNMMECC();
		}
	}

	private void PNIMDLGLACA(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(false);
	}

	public void HMEBENJPJPB(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1761f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 605f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 575f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1450f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 851f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 625f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 698f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 498f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1213f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 608f, 465f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1902f, 974f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 68f, 585f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 699f, 1376f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	public virtual void NFABHLHCNGJ()
	{
	}

	public void JPCKEHABGHD(Vector3 HHPNMJDONPE, Vector3 FOICGJEPBGL, Vector3 ODKNONDCLMI)
	{
		if (NGCDDPCAGJB == null)
		{
			LBOOHCONNAG = HHMFINFGMGD.GetComponent<UIWidget>().alpha;
			NGCDDPCAGJB = base.transform;
		}
		NGCDDPCAGJB.position = HHPNMJDONPE;
		Vector3 localPosition = NGCDDPCAGJB.localPosition;
		localPosition.z = 1645f;
		localPosition.x += ODKNONDCLMI.x;
		localPosition.y += ODKNONDCLMI.y;
		NGCDDPCAGJB.localPosition = localPosition;
		Vector3 one = Vector3.one;
		Vector3 zero = Vector3.zero;
		one.x = FOICGJEPBGL.x;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 863f - localPosition.y;
		zero.y = (one.y + FOICGJEPBGL.y) * 410f;
		HHMFINFGMGD.localPosition = zero;
		HHMFINFGMGD.localScale = one;
		one.y = ((float)IJMDOGNBGIL.activeHeight - FOICGJEPBGL.y) * 1841f + localPosition.y;
		zero.y = (0f - (one.y + FOICGJEPBGL.y)) * 953f;
		AOACBOGBJNM.localPosition = zero;
		AOACBOGBJNM.localScale = one;
		one.y = IJMDOGNBGIL.activeHeight;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 924f + localPosition.x;
		zero.x = (0f - (one.x + FOICGJEPBGL.x)) * 1368f;
		zero.y = 0f - localPosition.y;
		HIOHPOMALHE.localPosition = zero;
		HIOHPOMALHE.localScale = one;
		one.x = (IJMDOGNBGIL.activeWidth - FOICGJEPBGL.x) * 1140f - localPosition.x;
		zero.x = (one.x + FOICGJEPBGL.x) * 1350f;
		DNDCODMGGEE.localPosition = zero;
		DNDCODMGGEE.localScale = one;
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 1918f, 1079f, LBOOHCONNAG);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 1345f, 689f, LBOOHCONNAG);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 1093f, 367f, LBOOHCONNAG);
		TweenAlpha.Begin(DNDCODMGGEE.gameObject, 255f, 644f, LBOOHCONNAG);
		base.gameObject.SetActive(true);
	}

	private void CLLAPLBKAHD(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(true);
	}

	public void Hide()
	{
		TweenAlpha.Begin(HHMFINFGMGD.gameObject, 0.1f, 0f);
		TweenAlpha.Begin(AOACBOGBJNM.gameObject, 0.1f, 0f);
		TweenAlpha.Begin(HIOHPOMALHE.gameObject, 0.1f, 0f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(DNDCODMGGEE.gameObject, 0.1f, 0f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			base.gameObject.SetActive(false);
		});
	}
}
