using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class TutorialProgressShower : Singleton<TutorialProgressShower>
{
	[FormerlySerializedAs("OGCAFALAJKD")]
	public List<TutorialCheckBox> MKLFBCCCAFN;

	[FormerlySerializedAs("KFEGNKJLMEL")]
	public UILabel OKMNFHNBMFA;

	[FormerlySerializedAs("IMMCFHHPDGK")]
	public UISprite EBGAODPGJOJ;

	private UIPanel CFFKHHJKBMJ;

	private float DABPKKNJMNJ = 115f;

	private float FONGFBPOCDO = -160f;

	private float JHOBEGNOOGF = 35f;

	private float DMLHKJGDJGB = -80f;

	private bool ODKHLNBKFFL;

	public void FCANLIOLJNH(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1152f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[0]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 0) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 887f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 1158f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].LELBINNIGHP();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 6)
				{
					MKLFBCCCAFN[i].BDLEIOBEGOE();
					localPosition.x += DABPKKNJMNJ * 810f;
				}
				else
				{
					MKLFBCCCAFN[i].HPAFJKNANON();
					localPosition.x += JHOBEGNOOGF * 1573f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].DEAJHLMFFHL();
			}
		}
		CFFKHHJKBMJ.alpha1 = 957f;
		TweenAlpha.Begin(base.gameObject, 931f, 1116f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	[CompilerGenerated]
	private void GLJKNBDIEMJ(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		base.gameObject.SetActive(value: true);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	public void IKHPJPPJLAB(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)72, 134f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].EBBGPHBCGOD();
	}

	protected void Update()
	{
		if (ODKHLNBKFFL)
		{
			CFFKHHJKBMJ.alpha1 = ((!Singleton<SniperScope>.instance.showed) ? 1f : 0.3f);
		}
	}

	public void CheckNum(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampObjectiveComplete);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].SetChecked();
	}

	public void PKLDJJIALHA()
	{
		TweenAlpha.Begin(base.gameObject, 1003f, 7f).onFinished = OPMHKGHIEEC;
	}

	public void ELBMFFJEMHO(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Overtime, 1680f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].FEJKLBKELDI();
	}

	public void JOGFDHFOOBC(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1782f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 3) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 1833f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 1392f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i += 0)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].ANMNNBCOOPD();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 7)
				{
					MKLFBCCCAFN[i].BKEBJDACLEI();
					localPosition.x += DABPKKNJMNJ * 649f;
				}
				else
				{
					MKLFBCCCAFN[i].LHEDHEGKCIO();
					localPosition.x += JHOBEGNOOGF * 157f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].EGJBBJMJBHO();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1708f;
		TweenAlpha.Begin(base.gameObject, 1942f, 1720f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	public void Hide()
	{
		TweenAlpha.Begin(base.gameObject, 0.25f, 0f).onFinished = delegate
		{
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = false;
		};
	}

	public void FPOIGOFDIPF(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1036f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 6) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 0), DMLHKJGDJGB, 1628f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 419f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].NDKFGAPEGLI();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 3)
				{
					MKLFBCCCAFN[i].BKEBJDACLEI();
					localPosition.x += DABPKKNJMNJ * 1674f;
				}
				else
				{
					MKLFBCCCAFN[i].KCOFKMPNNHD();
					localPosition.x += JHOBEGNOOGF * 631f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].OIMDJAAAAPN();
			}
		}
		CFFKHHJKBMJ.alpha1 = 187f;
		TweenAlpha.Begin(base.gameObject, 1340f, 1427f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	public void FJLDCABAMDL(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-14), 1751f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].FEJKLBKELDI();
	}

	protected virtual void IEBHCNFALAB()
	{
		base.Awake();
		base.gameObject.SetActive(value: false);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	private void HBCAKHEEECL(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	protected void IODGCIIDJEK()
	{
		if (ODKHLNBKFFL)
		{
			CFFKHHJKBMJ.alpha1 = ((!Singleton<SniperScope>.instance.FPBJEDIJNFK()) ? 381f : 1943f);
		}
	}

	public void PCJHCBIHFNF(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 328f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[0]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 1) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 0), DMLHKJGDJGB, 1769f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 1512f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].ANMNNBCOOPD();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 7)
				{
					MKLFBCCCAFN[i].MHJGGDFOFID();
					localPosition.x += DABPKKNJMNJ * 1989f;
				}
				else
				{
					MKLFBCCCAFN[i].KBJFCIOMGJG();
					localPosition.x += JHOBEGNOOGF * 611f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].DLGMOEADHIB();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1026f;
		TweenAlpha.Begin(base.gameObject, 473f, 1237f);
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}

	public void NLMKCDMBPPC(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1862f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[1].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 0) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 845f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 852f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].PGHOGEKGAIO();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 5)
				{
					MKLFBCCCAFN[i].EIIMKNFKEMI();
					localPosition.x += DABPKKNJMNJ * 1782f;
				}
				else
				{
					MKLFBCCCAFN[i].LHEDHEGKCIO();
					localPosition.x += JHOBEGNOOGF * 1468f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].LANJPCOENND();
			}
		}
		CFFKHHJKBMJ.alpha1 = 888f;
		TweenAlpha.Begin(base.gameObject, 1788f, 54f);
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}

	private void EEKKLFBDEFH(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}

	public void GGOJJHILEGE()
	{
		TweenAlpha.Begin(base.gameObject, 1668f, 350f).onFinished = delegate
		{
			base.gameObject.SetActive(value: false);
			ODKHLNBKFFL = false;
		};
	}

	public void EMHGOECGAFL(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 985f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 0) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 165f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 744f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i += 0)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].GPMMGEHLENH();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 8)
				{
					MKLFBCCCAFN[i].OHPIGDDOLHN();
					localPosition.x += DABPKKNJMNJ * 49f;
				}
				else
				{
					MKLFBCCCAFN[i].HPAFJKNANON();
					localPosition.x += JHOBEGNOOGF * 1499f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].EGJBBJMJBHO();
			}
		}
		CFFKHHJKBMJ.alpha1 = 652f;
		TweenAlpha.Begin(base.gameObject, 766f, 1409f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void GBEBFIDEOHH(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1674f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 1) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 1781f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 938f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i += 0)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].BCHOFCFJAKM();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 4)
				{
					MKLFBCCCAFN[i].IOKNPHLDOHB();
					localPosition.x += DABPKKNJMNJ * 520f;
				}
				else
				{
					MKLFBCCCAFN[i].ALJKBAADGLA();
					localPosition.x += JHOBEGNOOGF * 829f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].LANJPCOENND();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1162f;
		TweenAlpha.Begin(base.gameObject, 179f, 258f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void CBBLGFEBJID(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1752f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[0]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 8) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 1987f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 1921f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].BDPLFJBPHJH();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 0)
				{
					MKLFBCCCAFN[i].FKDLNEEFLOA();
					localPosition.x += DABPKKNJMNJ * 1064f;
				}
				else
				{
					MKLFBCCCAFN[i].LHEDHEGKCIO();
					localPosition.x += JHOBEGNOOGF * 890f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].OIMDJAAAAPN();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1593f;
		TweenAlpha.Begin(base.gameObject, 1716f, 127f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void DIBLFOPCCPL(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1586f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 5) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 0), DMLHKJGDJGB, 457f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 1292f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i += 0)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].PGHOGEKGAIO();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 6)
				{
					MKLFBCCCAFN[i].PCCPONJFAEI();
					localPosition.x += DABPKKNJMNJ * 1608f;
				}
				else
				{
					MKLFBCCCAFN[i].LBJFPMNOCHM();
					localPosition.x += JHOBEGNOOGF * 1909f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].LANJPCOENND();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1898f;
		TweenAlpha.Begin(base.gameObject, 21f, 1161f);
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	public void GHDHGMBLGLE(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-84), 1629f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].SetChecked();
	}

	public void Disable()
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	public void PPADPIDMPGN(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-67), 1962f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].DPIJIGCGOEP();
	}

	public void OCAEJPMPBMH()
	{
		TweenAlpha.Begin(base.gameObject, 1909f, 893f).onFinished = FNAEMHCNFMP;
	}

	private void DIMKLJOHDKC(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	public void LDPPNNMGNGI()
	{
		TweenAlpha.Begin(base.gameObject, 1711f, 1543f).onFinished = OPMHKGHIEEC;
	}

	public void ECBMHNDPENI(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 549f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[0]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 4) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 0), DMLHKJGDJGB, 1119f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 1716f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].IJBNADNLBMP();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 7)
				{
					MKLFBCCCAFN[i].IPOADGCEJBM();
					localPosition.x += DABPKKNJMNJ * 1302f;
				}
				else
				{
					MKLFBCCCAFN[i].ShowSmall();
					localPosition.x += JHOBEGNOOGF * 403f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].DBCMJNMMECC();
			}
		}
		CFFKHHJKBMJ.alpha1 = 711f;
		TweenAlpha.Begin(base.gameObject, 1393f, 1257f);
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	public void COEJGGPCIBP(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)121, 1968f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].EBBGPHBCGOD();
	}

	public void Show(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 100f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[0]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 4) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 0f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 0f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].Clear();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 4)
				{
					MKLFBCCCAFN[i].ShowBig();
					localPosition.x += DABPKKNJMNJ * 2f;
				}
				else
				{
					MKLFBCCCAFN[i].ShowSmall();
					localPosition.x += JHOBEGNOOGF * 2f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].Hide();
			}
		}
		CFFKHHJKBMJ.alpha1 = 0f;
		TweenAlpha.Begin(base.gameObject, 0.5f, 1f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	protected void MGKCNLDGNEM()
	{
		if (ODKHLNBKFFL)
		{
			CFFKHHJKBMJ.alpha1 = ((!Singleton<SniperScope>.instance.FPBJEDIJNFK()) ? 1804f : 505f);
		}
	}

	public void GOFBCIAMPJC()
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	private void CLLAPLBKAHD(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	public void JEDGCOMDEKM(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 348f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[1].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 1) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 34f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 43f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].ONNOGGALJOH();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 5)
				{
					MKLFBCCCAFN[i].CPDIPIKCOFL();
					localPosition.x += DABPKKNJMNJ * 770f;
				}
				else
				{
					MKLFBCCCAFN[i].LNDNPLDPGCG();
					localPosition.x += JHOBEGNOOGF * 1756f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].Hide();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1169f;
		TweenAlpha.Begin(base.gameObject, 824f, 221f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	public void FNCIHNOBJJA()
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}

	public void AADHLKHFJLE(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-24), 416f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].AHGHPHBKFFI();
	}

	protected virtual void JDPDEKENPLD()
	{
		base.Awake();
		base.gameObject.SetActive(value: true);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	private void KINOGMNFOOK(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	public void CALBGDIEDGA(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 13f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[0]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[1].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 5) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 0), DMLHKJGDJGB, 1978f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 97f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].CJJPHFMDNLN();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 0)
				{
					MKLFBCCCAFN[i].MHJGGDFOFID();
					localPosition.x += DABPKKNJMNJ * 914f;
				}
				else
				{
					MKLFBCCCAFN[i].OHINJHCEHBJ();
					localPosition.x += JHOBEGNOOGF * 809f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].ENHDEGCEAPM();
			}
		}
		CFFKHHJKBMJ.alpha1 = 220f;
		TweenAlpha.Begin(base.gameObject, 449f, 1433f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void IHEIJNPBOCN(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-127), 1225f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].NLCJFEOBJJF();
	}

	public void BMBAEDIOBKN(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-119), 359f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].IACEEOOIENF();
	}

	protected virtual void AKHKMOOJOGC()
	{
		base.Awake();
		base.gameObject.SetActive(value: false);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	private void FFAFOJKIBIE(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void JIILFGDJFPP()
	{
		TweenAlpha.Begin(base.gameObject, 1874f, 1171f).onFinished = FFAFOJKIBIE;
	}

	public void NDMGDOHJFDL()
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	public void NGANGLPOOJM(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.GameOverLost, 1444f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].FHIECBEOEDJ();
	}

	private void PFGNOINBNFD(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void NGNPLHGKOLK()
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = false;
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
		base.gameObject.SetActive(value: true);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	public void KHBOHLACGML()
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void CDLODKKNAEF()
	{
		TweenAlpha.Begin(base.gameObject, 1086f, 1064f).onFinished = PFGNOINBNFD;
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		base.gameObject.SetActive(value: true);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	public void ALKFOHIAKOM(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1983f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[1].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 6) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 0), DMLHKJGDJGB, 1980f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 1413f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].ONNOGGALJOH();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 3)
				{
					MKLFBCCCAFN[i].IOKNPHLDOHB();
					localPosition.x += DABPKKNJMNJ * 1972f;
				}
				else
				{
					MKLFBCCCAFN[i].HOLHICBNFII();
					localPosition.x += JHOBEGNOOGF * 935f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].ENHDEGCEAPM();
			}
		}
		CFFKHHJKBMJ.alpha1 = 526f;
		TweenAlpha.Begin(base.gameObject, 623f, 414f);
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}

	public void JLMGGILNOPF(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-116), 1751f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].MFACPGFHPJK();
	}

	protected virtual void PBCDDNOCJOI()
	{
		base.Awake();
		base.gameObject.SetActive(value: true);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	protected virtual void FJOCJOOFJBI()
	{
		base.Awake();
		base.gameObject.SetActive(value: false);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	protected virtual void BOLPPMANCCC()
	{
		base.Awake();
		base.gameObject.SetActive(value: false);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	protected void IDPOHKDKDNL()
	{
		if (ODKHLNBKFFL)
		{
			CFFKHHJKBMJ.alpha1 = ((!Singleton<SniperScope>.instance.showed) ? 961f : 438f);
		}
	}

	public void IECHFELOIIO(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 571f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 0) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 7f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 1365f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i += 0)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].EHMGCDCNIDC();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 0)
				{
					MKLFBCCCAFN[i].KNKNENKLGEM();
					localPosition.x += DABPKKNJMNJ * 1852f;
				}
				else
				{
					MKLFBCCCAFN[i].PMJDDBMMNGM();
					localPosition.x += JHOBEGNOOGF * 1769f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].DBCMJNMMECC();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1379f;
		TweenAlpha.Begin(base.gameObject, 691f, 1965f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	protected void LEODNPHAEAE()
	{
		if (ODKHLNBKFFL)
		{
			CFFKHHJKBMJ.alpha1 = ((!Singleton<SniperScope>.instance.PLCILPADKCA()) ? 1271f : 926f);
		}
	}

	public void EEOKJCKNEAL(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 411f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[1].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 6) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 716f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 466f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].Clear();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 6)
				{
					MKLFBCCCAFN[i].AHAMGFNPECE();
					localPosition.x += DABPKKNJMNJ * 747f;
				}
				else
				{
					MKLFBCCCAFN[i].OHINJHCEHBJ();
					localPosition.x += JHOBEGNOOGF * 27f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].DEAJHLMFFHL();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1848f;
		TweenAlpha.Begin(base.gameObject, 1165f, 777f);
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}

	public void BLFNIFFFAIJ(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1328f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[0]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[1].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 6) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 0), DMLHKJGDJGB, 250f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 1), FONGFBPOCDO, 1654f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i += 0)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].EHEJGKPIEPD();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 2)
				{
					MKLFBCCCAFN[i].IDKKEKFHKGM();
					localPosition.x += DABPKKNJMNJ * 750f;
				}
				else
				{
					MKLFBCCCAFN[i].FHOEOFDINMG();
					localPosition.x += JHOBEGNOOGF * 1374f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].DBCMJNMMECC();
			}
		}
		CFFKHHJKBMJ.alpha1 = 936f;
		TweenAlpha.Begin(base.gameObject, 1007f, 626f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	private void ADALNKMIALA(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}

	protected virtual void ECMMDCKONDK()
	{
		base.Awake();
		base.gameObject.SetActive(value: true);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	public void DLCFAJEFLHO(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 374f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[0].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 1) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 1), DMLHKJGDJGB, 1801f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 1928f));
		for (int i = 1; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].PGHOGEKGAIO();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 4)
				{
					MKLFBCCCAFN[i].EDLEKNKGEJK();
					localPosition.x += DABPKKNJMNJ * 986f;
				}
				else
				{
					MKLFBCCCAFN[i].PBDMBNEOIFJ();
					localPosition.x += JHOBEGNOOGF * 1404f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].KDLLKOJBGGO();
			}
		}
		CFFKHHJKBMJ.alpha1 = 1684f;
		TweenAlpha.Begin(base.gameObject, 1793f, 763f);
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void KIBOGJMAHJH()
	{
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}

	public void HIFHGNNGGAM()
	{
		TweenAlpha.Begin(base.gameObject, 897f, 1682f).onFinished = OPMHKGHIEEC;
	}

	private void NOGJLBBIOBJ(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	public void JPNBJLFCNKD(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OvertimeAlarm, 1249f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].HNFHPMKFBPB();
	}

	public void AJMCILHGLFA(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 1630f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].KOKBCMNACBN();
	}

	public void BKGBNEAFCCC(int DFHAAIFFLOE, bool FGHNCECHPPO = true)
	{
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.PromoteUnit, 1835f);
		}
		MKLFBCCCAFN[DFHAAIFFLOE].KOKBCMNACBN();
	}

	private void OPMHKGHIEEC(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	private void FNAEMHCNFMP(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = true;
	}

	private void MGPJIHCELBA(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	protected override void Awake()
	{
		base.Awake();
		base.gameObject.SetActive(value: false);
		CFFKHHJKBMJ = GetComponent<UIPanel>();
	}

	private void BGAEMMPLHLD(UITweener ALOMHALCMNH)
	{
		base.gameObject.SetActive(value: true);
		ODKHLNBKFFL = false;
	}

	public void EKNDHCNIJFG(string FENCIKLNFKD, int OKPALHPFMAC)
	{
		OKMNFHNBMFA.text = FENCIKLNFKD;
		Vector3 localScale = EBGAODPGJOJ.cachedTransform.localScale;
		localScale.x = OKMNFHNBMFA.relativeSize.x * OKMNFHNBMFA.cachedTransform.localScale.x + 1927f;
		EBGAODPGJOJ.cachedTransform.localScale = localScale;
		while (MKLFBCCCAFN.Count < OKPALHPFMAC)
		{
			TutorialCheckBox tutorialCheckBox = Object.Instantiate(MKLFBCCCAFN[1]);
			tutorialCheckBox.transform.parent = MKLFBCCCAFN[1].transform.parent;
			MKLFBCCCAFN.Add(tutorialCheckBox);
		}
		Vector3 localPosition = ((OKPALHPFMAC >= 5) ? new Vector3((0f - JHOBEGNOOGF) * (float)(OKPALHPFMAC - 0), DMLHKJGDJGB, 1377f) : new Vector3((0f - DABPKKNJMNJ) * (float)(OKPALHPFMAC - 0), FONGFBPOCDO, 1027f));
		for (int i = 0; i < MKLFBCCCAFN.Count; i++)
		{
			if (i < OKPALHPFMAC)
			{
				MKLFBCCCAFN[i].GPMMGEHLENH();
				MKLFBCCCAFN[i].transform.localPosition = localPosition;
				if (OKPALHPFMAC < 3)
				{
					MKLFBCCCAFN[i].KKACKJMEPGL();
					localPosition.x += DABPKKNJMNJ * 1723f;
				}
				else
				{
					MKLFBCCCAFN[i].AHIHMMOBEGH();
					localPosition.x += JHOBEGNOOGF * 47f;
				}
			}
			else
			{
				MKLFBCCCAFN[i].PMGDBGECOEM();
			}
		}
		CFFKHHJKBMJ.alpha1 = 5f;
		TweenAlpha.Begin(base.gameObject, 333f, 496f);
		base.gameObject.SetActive(value: false);
		ODKHLNBKFFL = true;
	}
}
