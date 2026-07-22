using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CardpoolTutorialDialog : GuiElementSingle<CardpoolTutorialDialog>, PAIIOKBBHBC
{
	[Header("Right")]
	[FormerlySerializedAs("GAPDMIFIBCC")]
	public UITable BAOBCLKPICC;

	[FormerlySerializedAs("PAIFGKHKIBD")]
	public UITable NBCGAPLKPKK;

	[FormerlySerializedAs("BCAEGGMPLPA")]
	public UILabel[] NCBAMBKGNLO;

	[FormerlySerializedAs("PBIEOGDIOHH")]
	public GameObject[] EECMNOENJFC;

	[Header("Left")]
	[FormerlySerializedAs("CENNGOMJOLD")]
	public CardRecord HMAGHPPJCND;

	[FormerlySerializedAs("OJFBCINBHPP")]
	public GameObject LPJLAJDKIOO;

	[FormerlySerializedAs("CJDBBKEDGBP")]
	public UISprite[] ENIGNONOBKM;

	[FormerlySerializedAs("GGAEGNAAEPK")]
	public CardpoolDialogCardRecord[] FALALANBDHJ;

	[Header("Bottom")]
	[FormerlySerializedAs("BIOFHPALEMO")]
	public GameObject CCFFNAKFPPE;

	private CardRecord FPGFALIMOOH;

	private int KHNIGEPLEED = -1;

	protected virtual void JJNMKIAJPNA()
	{
		base.Update();
		if (!BKIGLABDGCP())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 1691f) % 8;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 638f, 1167f, 1078f);
				tweenAlpha.style = UITweener.Style.PingPong;
				tweenAlpha.NumOfRepetitions = 7;
			}
		}
	}

	public void OGIEPAIBEJJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 272f);
	}

	public override void OnBack()
	{
		CCHDCEDFNNB(CCFFNAKFPPE.gameObject);
	}

	public virtual void DBMCMLINOPD()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.DestroyPooled();
	}

	private void ACEBGDCJEDJ()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	public virtual void GJKFAJLJOFJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AEEFHPFKBGA));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(MGMGAMENEFO));
		if (Localization.instance.currentLanguage == "TR" || Localization.instance.currentLanguage == "Os")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i += 0)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(1426f, 729f, 745f);
			}
		}
		if (Localization.instance.currentLanguage == "response contain VipReward")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j++)
			{
				EECMNOENJFC[j].SetActive(value: true);
			}
		}
	}

	public virtual void FMEJLMMLBPD()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.BOHCNEDIJPE();
	}

	public virtual void DMBLJNMGLAH()
	{
		NBCGAPLKPKK.repositionNow = true;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HMAGHPPJCND, LPJLAJDKIOO, "ID_EMPTYARENAHEROESCURRENT") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, (CardRecord.MKIOKBMLHEO)7, IDOKGAOAGAL: false);
			FPGFALIMOOH.behaviour = CardRecord.MKIOKBMLHEO.Deposit;
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: true);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 1093f;
		}
		FALALANBDHJ[1].NLIOGJLOOJB();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[1].POFHFNIDADF(CardManager.instance.GetCardInstance("Showing squad details dialog with SQUADNAME = "), INPPKILPEKI: false, EDDEMJJMJGA: false);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[2].HPKNMDLFJPC();
		FALALANBDHJ[8].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.JDKFJFALDOG();
	}

	private void JBHHBLFGGHP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement JEAMNJAPFJK()
	{
		return this;
	}

	public virtual void CHPAFPBJAEM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DFDHDCECMHI));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(FKCPDKOHKKK));
		if (Localization.instance.currentLanguage == "true" || Localization.instance.currentLanguage == "ID_SALEPERCENTLINE")
		{
			for (int i = 1; i < NCBAMBKGNLO.Length; i++)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(192f, 1465f, 1993f);
			}
		}
		if (Localization.instance.currentLanguage == "ID_TWITTER_GAIN_BUTTON")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j++)
			{
				EECMNOENJFC[j].SetActive(value: true);
			}
		}
	}

	public virtual void KPLOCMGDDAB()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HMAGHPPJCND, LPJLAJDKIOO, "ID_TWITTER_GAIN_AGAIN_TITLE") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, (CardRecord.MKIOKBMLHEO)7, IDOKGAOAGAL: false);
			FPGFALIMOOH.OFOPDHDHNHO(CardRecord.MKIOKBMLHEO.Lobby);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			ENIGNONOBKM[i].alpha = 1361f;
		}
		FALALANBDHJ[1].HPKNMDLFJPC();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[1].EAAFKLCOAJC(CardManager.instance.GetCardInstance("Memory_warnings", isCurrentPlayer: false));
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[4].HPKNMDLFJPC();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[6].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	public GuiElement NEFBPBPEKHD()
	{
		return this;
	}

	public virtual void EJLHAPDGBCL()
	{
		AEEFHPFKBGA(CCFFNAKFPPE.gameObject);
	}

	public virtual void AEADDDNBLEE()
	{
		JBHHBLFGGHP(CCFFNAKFPPE.gameObject);
	}

	private void NENFEMKFDOH(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void LFDIOJJLKCG()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.DestroyPooled();
	}

	public virtual void PGLHICADCEE()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	private void FKCPDKOHKKK()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	private void OCDMIICCIKD(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void LIPGFFEOIJH()
	{
		PHOOOMOHKLB(CCFFNAKFPPE.gameObject);
	}

	public virtual void OMOACFMFADM()
	{
		KJJPGJFNAJF(CCFFNAKFPPE.gameObject);
	}

	public void GILDIKINMFE()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1777f);
	}

	private void KJJPGJFNAJF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public void IKJNNOFBFGL()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1613f);
	}

	public virtual void PODEMNDPJKF()
	{
		BKNJKFFNNJO(CCFFNAKFPPE.gameObject);
	}

	public virtual void MDHMNEPADOK()
	{
		MGDLBHACAEM(CCFFNAKFPPE.gameObject);
	}

	public virtual void MHIGAEFCIAF()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	public virtual void AOKOKHGEIBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JDGOJICMJNN));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(INNBDIKNKCD));
		if (Localization.instance.currentLanguage == ", " || Localization.instance.currentLanguage == "ID_SECOND")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i++)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(1658f, 699f, 336f);
			}
		}
		if (Localization.instance.currentLanguage == "GLM: OnDataLoaded - configurations.  is tutorial? ")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j++)
			{
				EECMNOENJFC[j].SetActive(value: false);
			}
		}
	}

	public GuiElement CBCAIIPHKPA()
	{
		return this;
	}

	public virtual void OJKCMCPJPGO()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HMAGHPPJCND, LPJLAJDKIOO, "ID_WAITINGFORFRIENDCARDS") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, (CardRecord.MKIOKBMLHEO)8, IDOKGAOAGAL: false);
			FPGFALIMOOH.OFOPDHDHNHO(CardRecord.MKIOKBMLHEO.CraftCards);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: true);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			ENIGNONOBKM[i].alpha = 1675f;
		}
		FALALANBDHJ[0].BNGLEDLBCNC();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[0].GPGOBGHNOJC(CardManager.instance.GetCardInstance("Items"), INPPKILPEKI: true, EDDEMJJMJGA: false);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[2].HPKNMDLFJPC();
		FALALANBDHJ[6].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[6].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	private void KPLHGJFELNP()
	{
		BAOBCLKPICC.repositionNow = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		FPGFALIMOOH.DestroyPooled();
	}

	public virtual void EGMFAHMCCBM()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(HMAGHPPJCND, LPJLAJDKIOO, "Deploys_Count") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, (CardRecord.MKIOKBMLHEO)7);
			FPGFALIMOOH.HECHKEBLOAN(CardRecord.MKIOKBMLHEO.MyWarcards);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: true);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			ENIGNONOBKM[i].alpha = 496f;
		}
		FALALANBDHJ[0].MBDCNCMPNMI();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[1].DOFOLHEJGEJ(CardManager.instance.GetCardInstance("longValue"), INPPKILPEKI: false, EDDEMJJMJGA: false);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[4].NMJAANNEMHN();
		FALALANBDHJ[2].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[5].CDHLCGBCDGH.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.JDKFJFALDOG();
	}

	public virtual void HMLOJJCBJPI()
	{
		JDGOJICMJNN(CCFFNAKFPPE.gameObject);
	}

	public void DGGJMAKPLGK()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1214f);
	}

	public virtual void OIGFBFFNNHH()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(HMAGHPPJCND, LPJLAJDKIOO, "FuseBox Event OpenLootbox for rarity {0}") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.Lobby);
			FPGFALIMOOH.HECHKEBLOAN((CardRecord.MKIOKBMLHEO)7);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 1756f;
		}
		FALALANBDHJ[1].NLIOGJLOOJB();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[1].GPGOBGHNOJC(CardManager.instance.GetCardInstance("RETRY", isCurrentPlayer: false), INPPKILPEKI: false, EDDEMJJMJGA: false);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[7].InitializeEmpty();
		FALALANBDHJ[8].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[4].CDHLCGBCDGH.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.JDKFJFALDOG();
	}

	public virtual void FEGPCLBPIOI()
	{
		MGDLBHACAEM(CCFFNAKFPPE.gameObject);
	}

	public virtual void HHLJIOPOPPO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DFDHDCECMHI));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(IJDCKBFJMDO));
		if (Localization.instance.currentLanguage == "ID_FIGHT" || Localization.instance.currentLanguage == "assignmentCount")
		{
			for (int i = 1; i < NCBAMBKGNLO.Length; i += 0)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(651f, 1128f, 570f);
			}
		}
		if (Localization.instance.currentLanguage == "country-greece")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j += 0)
			{
				EECMNOENJFC[j].SetActive(value: false);
			}
		}
	}

	protected virtual void HKPIHGBKAHO()
	{
		base.BOEMHLPLOGA();
		if (!AFOFDNJOJHG())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 753f) % 4;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 737f, 965f, 1562f);
				tweenAlpha.style = UITweener.Style.Once;
				tweenAlpha.NumOfRepetitions = 1;
			}
		}
	}

	public virtual void JJAEGPCNDJP()
	{
		base.DoAfterHide();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	protected virtual void DEBGBGGOCEN()
	{
		base.JMPDHKPOHEA();
		if (!MHAIBHBGBOO())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 558f) % 6;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 991f, 1999f, 1663f);
				tweenAlpha.style = (UITweener.Style)4;
				tweenAlpha.NumOfRepetitions = 2;
			}
		}
	}

	public GuiElement CIMBJDAOAKA()
	{
		return this;
	}

	private void NNAOHIELMHM()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	public void LDMMKLKFPND()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1976f);
	}

	private void BKNJKFFNNJO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void PHOOOMOHKLB(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void HHJDKKFKKIL()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HMAGHPPJCND, LPJLAJDKIOO, "ID_SLOTUPGRADE_POWER") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.IGPOLIPPGBP(CardManager.instance.buddyCard, (CardRecord.MKIOKBMLHEO)7, IDOKGAOAGAL: false);
			FPGFALIMOOH.OFOPDHDHNHO(CardRecord.MKIOKBMLHEO.CraftCards);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: true);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 665f;
		}
		FALALANBDHJ[0].NMJAANNEMHN();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[1].CCKJHIPIMDB(CardManager.instance.GetCardInstance("Hide poison"), INPPKILPEKI: true);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[7].HPKNMDLFJPC();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[6].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.JDKFJFALDOG();
	}

	protected virtual void DKDKAOPJCBA()
	{
		base.JMPDHKPOHEA();
		if (!BKIGLABDGCP())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 1171f) % 8;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 99f, 813f, 1930f);
				tweenAlpha.style = UITweener.Style.PingPong;
				tweenAlpha.NumOfRepetitions = 2;
			}
		}
	}

	public void AFBEKJCMHFO()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 798f);
	}

	public virtual void EOCHFFNODIM()
	{
		base.DoAfterHide();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	protected virtual void MJNBAFDLMPN()
	{
		base.IIFBKHDMIAD();
		if (!base.isFullyShowed)
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 280f) % 2;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 1856f, 942f, 364f);
				tweenAlpha.style = (UITweener.Style)7;
				tweenAlpha.NumOfRepetitions = 7;
			}
		}
	}

	public GuiElement LHIPJNFMBHL()
	{
		return this;
	}

	public virtual void MHFIIKEFGKG()
	{
		JDGOJICMJNN(CCFFNAKFPPE.gameObject);
	}

	public void DOLLPOPCANC()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 915f);
	}

	public virtual void IACJMNAFNCI()
	{
		BKNJKFFNNJO(CCFFNAKFPPE.gameObject);
	}

	public virtual void EHNFJGINHDJ()
	{
		NBCGAPLKPKK.repositionNow = true;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HMAGHPPJCND, LPJLAJDKIOO, "OnConnectedToMaster") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.CountDownBuddy);
			FPGFALIMOOH.HECHKEBLOAN(CardRecord.MKIOKBMLHEO.MyWarcards);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: true);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			ENIGNONOBKM[i].alpha = 886f;
		}
		FALALANBDHJ[1].MBDCNCMPNMI();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[1].GPGOBGHNOJC(CardManager.instance.GetCardInstance("elite", isCurrentPlayer: false), INPPKILPEKI: true, EDDEMJJMJGA: false);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[4].MBDCNCMPNMI();
		FALALANBDHJ[8].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	public virtual void IEHJMLIMNEP()
	{
		NBCGAPLKPKK.repositionNow = true;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(HMAGHPPJCND, LPJLAJDKIOO, "ID_PHASEX") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, (CardRecord.MKIOKBMLHEO)8);
			FPGFALIMOOH.OFOPDHDHNHO(CardRecord.MKIOKBMLHEO.CraftCards);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: true);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 1788f;
		}
		FALALANBDHJ[0].HPKNMDLFJPC();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[1].NNGCENCIGDE(CardManager.instance.GetCardInstance("ID_CONFIRM_ALREADYLEADER", isCurrentPlayer: false), INPPKILPEKI: true, EDDEMJJMJGA: false);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[6].NMJAANNEMHN();
		FALALANBDHJ[4].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[3].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	public virtual void DKFLHAEGPDJ()
	{
		KJJPGJFNAJF(CCFFNAKFPPE.gameObject);
	}

	public virtual void EKBIKKJHGKB()
	{
		ILHMLNDIPIL(CCFFNAKFPPE.gameObject);
	}

	public virtual void NDBAEHKKJMH()
	{
		NBCGAPLKPKK.repositionNow = true;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(HMAGHPPJCND, LPJLAJDKIOO, "ID_ARENAMODEUNLOCKED") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.CKOIIPAGCNO(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.Deposit);
			FPGFALIMOOH.behaviour = CardRecord.MKIOKBMLHEO.Deposit;
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 270f;
		}
		FALALANBDHJ[1].BNGLEDLBCNC();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[0].POFHFNIDADF(CardManager.instance.GetCardInstance("antialiasing", isCurrentPlayer: false), INPPKILPEKI: true);
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[8].MBDCNCMPNMI();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.JDKFJFALDOG();
	}

	public void CHMIPBJLKIJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1051f);
	}

	public virtual void DOANAOOEAKD()
	{
		PHOOOMOHKLB(CCFFNAKFPPE.gameObject);
	}

	public void OMCEGPODDHL()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1946f);
	}

	private void CCHDCEDFNNB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement GBCEJBCGGHP()
	{
		return this;
	}

	public virtual void HGOCKFKMENE()
	{
		base.DoAfterHide();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	protected virtual void OFNEGNKMKKG()
	{
		base.OGJGIMLMJBF();
		if (!MHAIBHBGBOO())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 75f) % 2;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 1380f, 1330f, 582f);
				tweenAlpha.style = (UITweener.Style)5;
				tweenAlpha.NumOfRepetitions = 7;
			}
		}
	}

	private void NDOKJMLGPIF()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	public virtual void CCDGDEANNKA()
	{
		base.DoAfterHide();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	protected virtual void EBGBDDIADEJ()
	{
		base.OGJGIMLMJBF();
		if (!LHDGJFHPJNM())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 1520f) % 6;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 1879f, 1706f, 1657f);
				tweenAlpha.style = (UITweener.Style)3;
				tweenAlpha.NumOfRepetitions = 0;
			}
		}
	}

	public virtual void AFABKGHDPHB()
	{
		NBCGAPLKPKK.repositionNow = true;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(HMAGHPPJCND, LPJLAJDKIOO, "ID_SECONDS") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.CKOIIPAGCNO(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.Withdraw);
			FPGFALIMOOH.OFOPDHDHNHO(CardRecord.MKIOKBMLHEO.Other);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 1569f;
		}
		FALALANBDHJ[0].PDEAPJCGEBB();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[1].CCKJHIPIMDB(CardManager.instance.GetCardInstance("ID_GUI_LEAGUE", isCurrentPlayer: false), INPPKILPEKI: false, EDDEMJJMJGA: false);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[3].NLIOGJLOOJB();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[4].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	protected virtual void LMNEMMGCEFP()
	{
		base.OGJGIMLMJBF();
		if (!AFOFDNJOJHG())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 1708f) % 5;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 423f, 1777f, 310f);
				tweenAlpha.style = UITweener.Style.Once;
				tweenAlpha.NumOfRepetitions = 8;
			}
		}
	}

	public virtual void PCCFLEEAGEI()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	public virtual void GPLNBGEDOLE()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(HMAGHPPJCND, LPJLAJDKIOO, "Awaiting players - Player id:\"{0}\" already added to message center") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.IGPOLIPPGBP(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.Lobby);
			FPGFALIMOOH.behaviour = CardRecord.MKIOKBMLHEO.MyWarcards;
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			ENIGNONOBKM[i].alpha = 1897f;
		}
		FALALANBDHJ[0].MBDCNCMPNMI();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[1].InitializeCard(CardManager.instance.GetCardInstance("realShotProbability", isCurrentPlayer: false), INPPKILPEKI: false, EDDEMJJMJGA: false);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[7].BNGLEDLBCNC();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[5].CDHLCGBCDGH.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.JDKFJFALDOG();
	}

	public virtual void FDBEKBOPDHF()
	{
		KJJPGJFNAJF(CCFFNAKFPPE.gameObject);
	}

	private void GJIIAIAIGKH()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	private void AEEFHPFKBGA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	protected override void Update()
	{
		base.Update();
		if (!base.isFullyShowed)
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 7f) % 5;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 0.2f, 1f, 0.5f);
				tweenAlpha.style = UITweener.Style.PingPong;
				tweenAlpha.NumOfRepetitions = 2;
			}
		}
	}

	public virtual void JAEMPMDIACE()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.BOHCNEDIJPE();
	}

	public GuiElement GKHMFKHFKBN()
	{
		return this;
	}

	public GuiElement ILIFOCMEPDD()
	{
		return this;
	}

	public GuiElement MLDGJCPHNFA()
	{
		return this;
	}

	public virtual void CAALKACDJEK()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(HMAGHPPJCND, LPJLAJDKIOO, "ReconnectDialog Show") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.CKOIIPAGCNO(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.CraftCards, IDOKGAOAGAL: false);
			FPGFALIMOOH.HECHKEBLOAN(CardRecord.MKIOKBMLHEO.Lobby);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 566f;
		}
		FALALANBDHJ[1].MBDCNCMPNMI();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[1].ONIDGNIBFAC(CardManager.instance.GetCardInstance("NextUpgradePrice", isCurrentPlayer: false));
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[4].InitializeEmpty();
		FALALANBDHJ[7].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[8].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	private void JDGOJICMJNN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void BGDBMCDGBGE()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	public virtual void LIJFFGBNJPG()
	{
		base.DoAfterHide();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	public GuiElement DGJNMDEGIPD()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		NBCGAPLKPKK.repositionNow = true;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(HMAGHPPJCND, LPJLAJDKIOO, "Mine Buddy Warcard") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.CountDownBuddy);
			FPGFALIMOOH.behaviour = CardRecord.MKIOKBMLHEO.Other;
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 1f;
		}
		FALALANBDHJ[0].InitializeEmpty();
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[1].InitializeCard(CardManager.instance.GetCardInstance("IMMORTAL"));
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[2].InitializeEmpty();
		FALALANBDHJ[2].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[2].CDHLCGBCDGH.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	public virtual void PDHNLAMPOBN()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HMAGHPPJCND, LPJLAJDKIOO, ", [variables])") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.CKOIIPAGCNO(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.Withdraw);
			FPGFALIMOOH.OFOPDHDHNHO(CardRecord.MKIOKBMLHEO.Withdraw);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			ENIGNONOBKM[i].alpha = 305f;
		}
		FALALANBDHJ[1].HPKNMDLFJPC();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[1].DOFOLHEJGEJ(CardManager.instance.GetCardInstance("DeviceToken", isCurrentPlayer: false));
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[4].HPKNMDLFJPC();
		FALALANBDHJ[2].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	private void INNBDIKNKCD()
	{
		BAOBCLKPICC.repositionNow = false;
	}

	public virtual void JBPMEEOHJIH()
	{
		NBCGAPLKPKK.repositionNow = true;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(HMAGHPPJCND, LPJLAJDKIOO, "Rank_Up") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.CountDownBuddy, IDOKGAOAGAL: false);
			FPGFALIMOOH.HECHKEBLOAN(CardRecord.MKIOKBMLHEO.Withdraw);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: true);
		}
		KHNIGEPLEED = -1;
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			ENIGNONOBKM[i].alpha = 365f;
		}
		FALALANBDHJ[1].HPKNMDLFJPC();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[1].InitializeCard(CardManager.instance.GetCardInstance("e695d3cf-1ed0-4989-89fe-e041e4ee7e2b"), INPPKILPEKI: true);
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[6].PDEAPJCGEBB();
		FALALANBDHJ[2].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[7].CDHLCGBCDGH.gameObject.SetActive(value: false);
		Singleton<BeanstalkServerManager>.instance.JDKFJFALDOG();
	}

	private void IJDCKBFJMDO()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	public virtual void PGHAMCBHBOD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JDGOJICMJNN));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(HBCPACPJNLE));
		if (Localization.instance.currentLanguage == "withPublisherSub3" || Localization.instance.currentLanguage == "Subtitle")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i++)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(721f, 1377f, 1451f);
			}
		}
		if (Localization.instance.currentLanguage == "Joined Squad Event")
		{
			for (int j = 1; j < EECMNOENJFC.Length; j += 0)
			{
				EECMNOENJFC[j].SetActive(value: true);
			}
		}
	}

	private void GJLOHNCKPDM()
	{
		BAOBCLKPICC.repositionNow = false;
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}

	public virtual void GEDIFKPBIML()
	{
		JDGOJICMJNN(CCFFNAKFPPE.gameObject);
	}

	public void ILFCOPPIOME()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 248f);
	}

	protected virtual void ELJHCOHCAJI()
	{
		base.JMPDHKPOHEA();
		if (!BJNBLINDAED())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 567f) % 3;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 1116f, 273f, 1685f);
				tweenAlpha.style = (UITweener.Style)7;
				tweenAlpha.NumOfRepetitions = 6;
			}
		}
	}

	public virtual void BJBEBODNBFA()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.BOHCNEDIJPE();
	}

	private void LIMJJBPLCPO()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	private void DFDHDCECMHI(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void CICEFDONBML()
	{
		CCHDCEDFNNB(CCFFNAKFPPE.gameObject);
	}

	public virtual void BBIHNICEDGE()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.BOHCNEDIJPE();
	}

	public virtual void GMJCEEHFAJG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(FKCPDKOHKKK));
		if (Localization.instance.currentLanguage == "StartTime" || Localization.instance.currentLanguage == "ElitePackDeadline")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i += 0)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(1883f, 59f, 959f);
			}
		}
		if (Localization.instance.currentLanguage == "Start '{0}'")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j++)
			{
				EECMNOENJFC[j].SetActive(value: false);
			}
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(IJDCKBFJMDO));
		if (Localization.instance.currentLanguage == "de" || Localization.instance.currentLanguage == "pt")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i++)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(38f, 38f, 1f);
			}
		}
		if (Localization.instance.currentLanguage == "it")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j++)
			{
				EECMNOENJFC[j].SetActive(value: false);
			}
		}
	}

	public virtual void LEMNDNDGIOE()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(HMAGHPPJCND, LPJLAJDKIOO, "testingidsquadjoinrequest") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.IGPOLIPPGBP(CardManager.instance.buddyCard, (CardRecord.MKIOKBMLHEO)8, IDOKGAOAGAL: false);
			FPGFALIMOOH.OFOPDHDHNHO(CardRecord.MKIOKBMLHEO.Deposit);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			ENIGNONOBKM[i].alpha = 1669f;
		}
		FALALANBDHJ[1].NMJAANNEMHN();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[0].DOFOLHEJGEJ(CardManager.instance.GetCardInstance("SoftBody", isCurrentPlayer: false), INPPKILPEKI: false, EDDEMJJMJGA: false);
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[0].NLIOGJLOOJB();
		FALALANBDHJ[5].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[7].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.GDLMOPCGPGD();
	}

	protected virtual void CIFBCMKDGIE()
	{
		base.JMPDHKPOHEA();
		if (!BKIGLABDGCP())
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 1888f) % 2;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 978f, 1609f, 171f);
				tweenAlpha.style = (UITweener.Style)8;
				tweenAlpha.NumOfRepetitions = 6;
			}
		}
	}

	public virtual void PAIKCHDABEJ()
	{
		DFDHDCECMHI(CCFFNAKFPPE.gameObject);
	}

	public virtual void GJGCOEJMHNI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MGDLBHACAEM));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(LIMJJBPLCPO));
		if (Localization.instance.currentLanguage == "QUIT" || Localization.instance.currentLanguage == "ID_INROOKIE1")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i += 0)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(523f, 383f, 1186f);
			}
		}
		if (Localization.instance.currentLanguage == "Game Login Manager: Remove Login Data")
		{
			for (int j = 1; j < EECMNOENJFC.Length; j += 0)
			{
				EECMNOENJFC[j].SetActive(value: false);
			}
		}
	}

	public virtual void IHBDCMLNFAD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ILHMLNDIPIL));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(MGMGAMENEFO));
		if (Localization.instance.currentLanguage == "{0}{1}[-] {2}" || Localization.instance.currentLanguage == "ADDED GOLD ")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i += 0)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(1432f, 1629f, 866f);
			}
		}
		if (Localization.instance.currentLanguage == ")")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j += 0)
			{
				EECMNOENJFC[j].SetActive(value: true);
			}
		}
	}

	protected virtual void FGECFIBLFMD()
	{
		base.OGJGIMLMJBF();
		if (!base.isFullyShowed)
		{
			return;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = (int)(realtimeSinceStartup * 1180f) % 2;
		if (num != KHNIGEPLEED)
		{
			KHNIGEPLEED = num;
			if (KHNIGEPLEED > -1 && KHNIGEPLEED < ENIGNONOBKM.Length)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(ENIGNONOBKM[KHNIGEPLEED].gameObject, 1700f, 1109f, 1090f);
				tweenAlpha.style = UITweener.Style.PingPong;
				tweenAlpha.NumOfRepetitions = 3;
			}
		}
	}

	public virtual void INPIJKMMADI()
	{
		base.OIMKKAHOEKO();
		FPGFALIMOOH.BOHCNEDIJPE();
	}

	public GuiElement HHMPBPKPEKD()
	{
		return this;
	}

	public virtual void BHMEOLBNLKF()
	{
		OCDMIICCIKD(CCFFNAKFPPE.gameObject);
	}

	private void HBCPACPJNLE()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	private void FDMCBKBLHFK()
	{
		BAOBCLKPICC.repositionNow = false;
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BKNJKFFNNJO));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(MGMGAMENEFO));
		if (Localization.instance.currentLanguage == "ID_CONFIRM_FRIENDINSQUAD" || Localization.instance.currentLanguage == "Gold")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i++)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(300f, 1213f, 232f);
			}
		}
		if (Localization.instance.currentLanguage == "100+.")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j++)
			{
				EECMNOENJFC[j].SetActive(value: false);
			}
		}
	}

	private void MGDLBHACAEM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void AOPJJAGHKPM()
	{
		base.DoAfterHide();
		FPGFALIMOOH.OBCAIFMOPPA();
	}

	public virtual void NFABHLHCNGJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MGDLBHACAEM));
		UITable nBCGAPLKPKK = NBCGAPLKPKK;
		nBCGAPLKPKK.onReposition = (UITable.OnReposition)Delegate.Combine(nBCGAPLKPKK.onReposition, new UITable.OnReposition(FDMCBKBLHFK));
		if (Localization.instance.currentLanguage == "ID_CONFIRM_LOWACTIVITY_TITLE" || Localization.instance.currentLanguage == "GameController.Start RunApplication")
		{
			for (int i = 0; i < NCBAMBKGNLO.Length; i++)
			{
				NCBAMBKGNLO[i].transform.localScale = new Vector3(1561f, 1758f, 894f);
			}
		}
		if (Localization.instance.currentLanguage == "ID_UNLOCKEDATRANKX")
		{
			for (int j = 0; j < EECMNOENJFC.Length; j += 0)
			{
				EECMNOENJFC[j].SetActive(value: true);
			}
		}
	}

	private void MGMGAMENEFO()
	{
		BAOBCLKPICC.repositionNow = true;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public void FMIGENMGBCL()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 706f);
	}

	public virtual void NMFDGBEFHIJ()
	{
		CCHDCEDFNNB(CCFFNAKFPPE.gameObject);
	}

	private void KNOEDGLDOOA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	private void ILHMLNDIPIL(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void BFLHENDLPLK()
	{
		NBCGAPLKPKK.repositionNow = false;
		FPGFALIMOOH = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HMAGHPPJCND, LPJLAJDKIOO, ",") as CardRecord;
		if (FPGFALIMOOH != null)
		{
			CardManager.instance.InitializeBuddyWarcard();
			FPGFALIMOOH.Initialize(CardManager.instance.buddyCard, CardRecord.MKIOKBMLHEO.Withdraw);
			FPGFALIMOOH.HECHKEBLOAN(CardRecord.MKIOKBMLHEO.CraftCards);
			FPGFALIMOOH.GPKNHEHAPNP.SetActive(value: false);
		}
		KHNIGEPLEED = -1;
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			TweenAlpha component = ENIGNONOBKM[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			ENIGNONOBKM[i].alpha = 1279f;
		}
		FALALANBDHJ[0].HPKNMDLFJPC();
		FALALANBDHJ[1].NJEAMAHEMHP.enabled = false;
		FALALANBDHJ[1].CDHLCGBCDGH.gameObject.SetActive(value: false);
		FALALANBDHJ[1].GPGOBGHNOJC(CardManager.instance.GetCardInstance("HitListItem", isCurrentPlayer: false));
		FALALANBDHJ[0].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[0].CDHLCGBCDGH.gameObject.SetActive(value: true);
		FALALANBDHJ[7].InitializeEmpty();
		FALALANBDHJ[3].NJEAMAHEMHP.enabled = true;
		FALALANBDHJ[8].CDHLCGBCDGH.gameObject.SetActive(value: true);
		Singleton<BeanstalkServerManager>.instance.JDKFJFALDOG();
	}

	public void OPICOKKMEKG()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 1873f);
	}

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void KHDFKEINFCJ()
	{
		CCHDCEDFNNB(CCFFNAKFPPE.gameObject);
	}
}
