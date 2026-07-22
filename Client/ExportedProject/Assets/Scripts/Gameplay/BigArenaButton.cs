using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BigArenaButton : Core_BaseScript
{
	private enum EDFOHCICHDB
	{
		Rule,
		Hero
	}

	[FormerlySerializedAs("AOAPJEBDIEO")]
	[Header("Core")]
	public BoxCollider HKKPCMGDEDC;

	[FormerlySerializedAs("GJEEDDOPGPH")]
	[Header("Left Part")]
	public UILabel DGHEANFMLFE;

	[FormerlySerializedAs("APBDJMFCEDE")]
	public UILabel FFENBFDCOOP;

	[Header("- Rewards Part")]
	[FormerlySerializedAs("GDDJFJDHBOE")]
	public GameObject DOCLOEBEGIL;

	[FormerlySerializedAs("AFCPBFENCLM")]
	public UISprite[] ACFIIFGNFFG;

	[FormerlySerializedAs("PJAOEPMMECJ")]
	public WarArenaSmallRewardRecord CCNKBJEPPHJ;

	[FormerlySerializedAs("GHKCPFELOFE")]
	public UIPanel OJLCHJOPDFE;

	[FormerlySerializedAs("IOMFIMGCHDD")]
	public UIDraggablePanel CIGPMELGPGB;

	[FormerlySerializedAs("DNNNDIEDMPA")]
	public UIPooledGrid KCCOKFDFHGI;

	[Header("Right Part")]
	[FormerlySerializedAs("EPDDFAEPNND")]
	public GameObject NJDAMDHNEOC;

	[FormerlySerializedAs("KMALALABKFJ")]
	public UISprite GPIMPCBEPDD;

	[FormerlySerializedAs("DMOGEDEPKCJ")]
	public UILabel EGFEKNGKMIN;

	[FormerlySerializedAs("NKCKNPGCLNB")]
	public GameObject JNPFODCGNJN;

	[FormerlySerializedAs("NBAPOGAIEHB")]
	public UISprite MLGMEDAFJKF;

	[FormerlySerializedAs("IGGCKGAAOKF")]
	public UILabel NACNIGNOIDE;

	[Header("- Rule Part")]
	[FormerlySerializedAs("GPDOMJDKDFL")]
	public GameObject OCPHONLANOH;

	[FormerlySerializedAs("KOJLCPCMJJL")]
	public ArenaRuleRecord KGCMIPLLOEK;

	[FormerlySerializedAs("JGKBCNDCEHH")]
	public UIPanel EDAOGEKDPDP;

	[FormerlySerializedAs("FKPIPGAAPPL")]
	public UIDraggablePanel BJMFENAFNFJ;

	[FormerlySerializedAs("PJEHNEEMNIH")]
	public UIPooledClassicTable GOPNFFACMJH;

	[Header("- Hero Part")]
	[FormerlySerializedAs("GEBCEEGEAIL")]
	public GameObject JMBNCCEOGLD;

	[FormerlySerializedAs("OBDFIKKJNLO")]
	public ArenaHeroRecord KAIMAOHHPEP;

	[FormerlySerializedAs("NANJGNCNAID")]
	public UIPanel DCNAKJJAFBJ;

	[FormerlySerializedAs("DMIFPOLKNGP")]
	public UIDraggablePanel LIKAPAMDGKA;

	[FormerlySerializedAs("MNLHEIIDHIN")]
	public UIPooledGrid KAEFBFKCPHJ;

	[FormerlySerializedAs("PBEAEIACHIO")]
	public GameObject GLNLMHGELLB;

	[FormerlySerializedAs("NMNLGHPACEN")]
	public UILabel DMLOHHIMOCN;

	[FormerlySerializedAs("LGJAJFFFJHF")]
	public UIPanel DCOADDCIHHP;

	[FormerlySerializedAs("MLJICGLPCGP")]
	[Header("Bottom Part")]
	public UISprite CIJEPNNIOOM;

	[Header("- Locked Part")]
	[FormerlySerializedAs("BALNNIIDCHF")]
	public GameObject MDAFFKPPCBG;

	[FormerlySerializedAs("CCFGLJELPEG")]
	public UILabel JFJJDKIJEIL;

	[FormerlySerializedAs("BLPHGCKEEKO")]
	[Header("- Opened Part")]
	public GameObject HBNELLPLPNM;

	[FormerlySerializedAs("ICCCFNFMIOC")]
	public UILabel GAJKKHFAOMM;

	[FormerlySerializedAs("OMLOPLHJOAK")]
	public GameObject EKOCDFGMLKG;

	private bool JDPOMFBEFOI;

	private float ADDICBANAAB;

	private List<WarArenaRule.OCCICIIEHEF> DONAJDGHBDP;

	private List<FHIPGDADNFG> BHJIMFDGCGE;

	private List<PHAMEDPLFLO> MLCJPKJBAHL;

	private EDFOHCICHDB OLBGMPEGLBP;

	private Color KMHGDNHDPAL = new Color(0f, 0f, 0f, 0.25f);

	private Color GBDGKAEOOON = new Color(1f, 1f, 1f, 0.05f);

	private ArenaRuleRecord CCCAMLIHHOE;

	private ArenaHeroRecord DNDBLHFDJDG;

	public ArenaRuleRecord ruleRecordForHeight
	{
		get
		{
			if (CCCAMLIHHOE == null)
			{
				CCCAMLIHHOE = UnityEngine.Object.Instantiate(KGCMIPLLOEK);
				CCCAMLIHHOE.transform.parent = base.transform;
				CCCAMLIHHOE.name = "Rule Record For Height";
				CCCAMLIHHOE.transform.localPosition = new Vector3(0f, -3f * UIHelper.activeHeight, 0f);
				CCCAMLIHHOE.transform.localScale = Vector3.one;
			}
			return CCCAMLIHHOE;
		}
	}

	private void CJCJDKHMBNB(UITweener MGDJMGHCAAI)
	{
		JMBNCCEOGLD.SetActive(value: true);
	}

	private void MNFDMKFLAKO()
	{
		if (!JDPOMFBEFOI)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1583f)
		{
			ADDICBANAAB -= 606f;
			bool flag = WarArena.instance.BALABLIGAHK();
			GAJKKHFAOMM.text = ((!flag) ? MIGCGPMDMAB.JONJEODEGMO(Colours.stringBlack) : string.Empty);
			if (WarArena.instance.isExpired)
			{
				WarArena.instance.MKHMKIKNAKP();
			}
		}
	}

	private void IKBPGLELKLB(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Rule)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Rule;
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 0.3f, Color.white, Colours.greenArena);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 0.3f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(NACNIGNOIDE.gameObject, 0.3f, Colours.greenArena, Color.white);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 0.3f, KMHGDNHDPAL, GBDGKAEOOON);
			OCPHONLANOH.SetActive(value: true);
			EDAOGEKDPDP.alpha1 = 0f;
			PMBBPCEGPFL();
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 0.3f, 0f, 1f).onFinished = null;
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 0.3f, 1f, 0f).onFinished = delegate
			{
				JMBNCCEOGLD.SetActive(value: false);
			};
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 0.3f, 1f, 0f);
		}
	}

	private Transform FHIDNOGLHBN(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WarArenaSmallRewardRecord warArenaSmallRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(CCNKBJEPPHJ, KCCOKFDFHGI.gameObject, string.Format("[FFFFFF]{0}[-]  {1}", DFHAAIFFLOE)) as WarArenaSmallRewardRecord;
			if (warArenaSmallRewardRecord != null)
			{
				warArenaSmallRewardRecord.PPLIBOAJOCA(MLCJPKJBAHL[DFHAAIFFLOE]);
				return warArenaSmallRewardRecord.transform;
			}
		}
		return null;
	}

	private Transform AHHAGCNANDK(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < BHJIMFDGCGE.Count)
		{
			ArenaHeroRecord arenaHeroRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(KAIMAOHHPEP, KAEFBFKCPHJ.gameObject, $"Hero {DFHAAIFFLOE:D2}") as ArenaHeroRecord;
			if (arenaHeroRecord != null)
			{
				arenaHeroRecord.Initialize(DFHAAIFFLOE + 1, BHJIMFDGCGE[DFHAAIFFLOE], 528);
				return arenaHeroRecord.transform;
			}
		}
		return null;
	}

	private void CCMPHFEHDAF(List<FHIPGDADNFG> JFGDAKMCJAM)
	{
		BHJIMFDGCGE = JFGDAKMCJAM;
		GLNLMHGELLB.SetActive(value: false);
		DMLOHHIMOCN.gameObject.SetActive(BHJIMFDGCGE.Count == 1);
		if (BHJIMFDGCGE.Count > 1)
		{
			KAEFBFKCPHJ.MakeEmpty();
			KAEFBFKCPHJ.init(BHJIMFDGCGE.Count, AHHAGCNANDK, JLNELDOPMCA, LIKAPAMDGKA);
			LIKAPAMDGKA.AlignToPos(instant: false, UIDraggablePanel.Alingment.BottomRight);
		}
	}

	[SpecialName]
	public ArenaRuleRecord NAAEDFBNFEI()
	{
		if (CCCAMLIHHOE == null)
		{
			CCCAMLIHHOE = UnityEngine.Object.Instantiate(KGCMIPLLOEK);
			CCCAMLIHHOE.transform.parent = base.transform;
			CCCAMLIHHOE.name = "{0}{1}[-] / {2}";
			CCCAMLIHHOE.transform.localPosition = new Vector3(280f, 192f * UIHelper.activeHeight, 1074f);
			CCCAMLIHHOE.transform.localScale = Vector3.one;
		}
		return CCCAMLIHHOE;
	}

	private void GBJLPBOAMLN(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.JOOFMNHIJPK();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.OCDINHEFBDG((!WarArena.instance.DANDNHJBJKB()) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.MainArena);
		}
	}

	private void CKFFGPAPOCN(List<FHIPGDADNFG> JFGDAKMCJAM)
	{
		BHJIMFDGCGE = JFGDAKMCJAM;
		GLNLMHGELLB.SetActive(value: false);
		DMLOHHIMOCN.gameObject.SetActive(BHJIMFDGCGE.Count == 0);
		if (BHJIMFDGCGE.Count > 0)
		{
			KAEFBFKCPHJ.MakeEmpty();
			KAEFBFKCPHJ.init(BHJIMFDGCGE.Count, AHHAGCNANDK, JLNELDOPMCA, LIKAPAMDGKA);
			LIKAPAMDGKA.AlignToPos(instant: true);
		}
	}

	private void OPAJBNLFOMG()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
		{
			InitGuiValues();
			if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
			{
				ShowArenaButton();
			}
		}
	}

	private void FBIMFPNNOMG(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.ShowDialog();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(WarArena.instance.isArenaTicketBought ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	private void LBEDCOMANCO()
	{
		KAEFBFKCPHJ.MakeEmpty();
		DMLOHHIMOCN.gameObject.SetActive(value: false);
		GLNLMHGELLB.SetActive(value: false);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(KAIMAOHHPEP, JMBNCCEOGLD, "ID_GUI_SQUADCHALLENGEENDED") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = new Vector3(1300f, 1271f, 634f);
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 1;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.JJFKFKBCKFL(flag, aGIANFGGNNA, 122);
		}
		GEKJKNLPJIL.DJIDACPPECH();
	}

	private void OFOAPJBJDNE()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
		{
			InitGuiValues();
			if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
			{
				ShowArenaButton();
			}
		}
	}

	private void KIBGOHNLBJK()
	{
		KAEFBFKCPHJ.MakeEmpty();
		DMLOHHIMOCN.gameObject.SetActive(value: false);
		GLNLMHGELLB.SetActive(value: true);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(KAIMAOHHPEP, JMBNCCEOGLD, "Your Best") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = new Vector3(0f, -406f, 0f);
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 0;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.InitializeYou(flag, aGIANFGGNNA, 528);
		}
		GEKJKNLPJIL.JBBJNFEHHFC();
	}

	private void HAHHDHNJAHJ(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Rule)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Rule;
			TweenColor.Begin(NACNIGNOIDE.gameObject, 1594f, Color.white, Colours.greenArena);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 99f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 149f, Colours.greenArena, Color.white);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 1593f, KMHGDNHDPAL, GBDGKAEOOON);
			JMBNCCEOGLD.SetActive(value: true);
			DCNAKJJAFBJ.alpha1 = 992f;
			KIBGOHNLBJK();
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 781f, 115f, 1103f).onFinished = null;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 122f, 688f, 1132f);
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 1525f, 52f, 1738f).onFinished = KCLOIMMANAO;
		}
	}

	private void HPOOKFEFCPO(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.KNBIBOINAKG();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.NEOPPEENNFN(WarArena.instance.DANDNHJBJKB() ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HKKPCMGDEDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBIMFPNNOMG));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJDAMDHNEOC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IKBPGLELKLB));
		UIEventListener uIEventListener3 = UIEventListener.Get(JNPFODCGNJN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NAJLNIHCALB));
		WarArena.instance.WarArenaDataChanged += OININCJHHOE;
		WarArena.instance.WarArenaExpired += OININCJHHOE;
		WarArena.instance.WarArenaStarter += OININCJHHOE;
		GEKJKNLPJIL.NKBJMLEBMBH = (Action)Delegate.Combine(GEKJKNLPJIL.NKBJMLEBMBH, new Action(FGJEBCDJAPI));
		int num = Mathf.FloorToInt(UIHelper.activeWidthSafe - 1336f);
		if (num % 2 == 1)
		{
			num--;
		}
		UISprite[] aCFIIFGNFFG = ACFIIFGNFFG;
		foreach (UISprite uISprite in aCFIIFGNFFG)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num);
		}
		OJLCHJOPDFE.clipRange = OJLCHJOPDFE.clipRange.ReplaceZ(num - 10);
		DOCLOEBEGIL.transform.localPosition = DOCLOEBEGIL.transform.localPosition.ReplaceX(50 + num / 2);
	}

	private float KFBMHNDKAMA(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			ruleRecordForHeight.PJICLEMEBID(DONAJDGHBDP[DFHAAIFFLOE], HIDGBKPDFKN: true, 50, 45);
			return NAAEDFBNFEI().KMFGCJEGJJK.transform.localScale.y;
		}
		return 680f;
	}

	private float DJNGFDODCDE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			ruleRecordForHeight.Initialize(DONAJDGHBDP[DFHAAIFFLOE], HIDGBKPDFKN: false, 560, 70);
			return ruleRecordForHeight.KMFGCJEGJJK.transform.localScale.y;
		}
		return 0f;
	}

	public void DKCOOAKKFKD()
	{
		DONAJDGHBDP = null;
		BHJIMFDGCGE = null;
		MLCJPKJBAHL = null;
		GOPNFFACMJH.MakeEmpty();
		KAEFBFKCPHJ.MakeEmpty();
		KCCOKFDFHGI.MakeEmpty();
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.BOHCNEDIJPE();
			DNDBLHFDJDG = null;
		}
	}

	[CompilerGenerated]
	private void HEBIAEJAHJJ(UITweener MGDJMGHCAAI)
	{
		OCPHONLANOH.SetActive(value: false);
	}

	public void EEFEFOHKIBF()
	{
		DONAJDGHBDP = null;
		BHJIMFDGCGE = null;
		MLCJPKJBAHL = null;
		GOPNFFACMJH.MakeEmpty();
		KAEFBFKCPHJ.MakeEmpty();
		KCCOKFDFHGI.MakeEmpty();
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.OBCAIFMOPPA();
			DNDBLHFDJDG = null;
		}
	}

	private Transform ODKCAHJFNHK(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WarArenaSmallRewardRecord warArenaSmallRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(CCNKBJEPPHJ, KCCOKFDFHGI.gameObject, string.Format("SÌ", DFHAAIFFLOE)) as WarArenaSmallRewardRecord;
			if (warArenaSmallRewardRecord != null)
			{
				warArenaSmallRewardRecord.NDIJBPIDGOF(MLCJPKJBAHL[DFHAAIFFLOE]);
				return warArenaSmallRewardRecord.transform;
			}
		}
		return null;
	}

	private void HLKLBEKHECE()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
		{
			InitGuiValues();
			if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
			{
				IFAICOBKCLA();
			}
		}
	}

	[SpecialName]
	public ArenaRuleRecord MILMKHLHOFC()
	{
		if (CCCAMLIHHOE == null)
		{
			CCCAMLIHHOE = UnityEngine.Object.Instantiate(KGCMIPLLOEK);
			CCCAMLIHHOE.transform.parent = base.transform;
			CCCAMLIHHOE.name = "bazooka_shot_barrier";
			CCCAMLIHHOE.transform.localPosition = new Vector3(1718f, 1998f * UIHelper.activeHeight, 1914f);
			CCCAMLIHHOE.transform.localScale = Vector3.one;
		}
		return CCCAMLIHHOE;
	}

	private void PCMKBDINBDF(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.OPPAFPHDKNL();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.OCDINHEFBDG(WarArena.instance.DANDNHJBJKB() ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	private void AIGOOOACNFN(UITweener MGDJMGHCAAI)
	{
		OCPHONLANOH.SetActive(value: false);
	}

	[CompilerGenerated]
	private void OOIFFIAEEED(UITweener MGDJMGHCAAI)
	{
		JMBNCCEOGLD.SetActive(value: false);
	}

	private void LBKGENPOAPH()
	{
		MLCJPKJBAHL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.EOIAFJNEOKL : new List<PHAMEDPLFLO>());
		KCCOKFDFHGI.MakeEmpty();
		KCCOKFDFHGI.init(MLCJPKJBAHL.Count, FHIDNOGLHBN, MBHDDJLBEEM, CIGPMELGPGB);
		CIGPMELGPGB.AlignToPos(instant: true);
	}

	private void MOJOEFCBHIJ(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.CBPJNPHOAFN();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.FIIIKMNODJA((!WarArena.instance.DANDNHJBJKB()) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.MainArena);
		}
	}

	private void HIMPKMKFEBF(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.AJCILBFBNMK();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowWarArena((!WarArena.instance.DANDNHJBJKB()) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	private void HCMLFNOKDDJ(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Rule)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Hero;
			TweenColor.Begin(NACNIGNOIDE.gameObject, 783f, Color.white, Colours.greenArena);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 1865f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 1397f, Colours.greenArena, Color.white);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 1805f, KMHGDNHDPAL, GBDGKAEOOON);
			JMBNCCEOGLD.SetActive(value: false);
			DCNAKJJAFBJ.alpha1 = 404f;
			JGLBEDGKCAN();
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 902f, 1992f, 975f).onFinished = null;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 1053f, 1445f, 801f);
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 1901f, 990f, 37f).onFinished = KCLOIMMANAO;
		}
	}

	private void JGLBEDGKCAN()
	{
		KAEFBFKCPHJ.MakeEmpty();
		DMLOHHIMOCN.gameObject.SetActive(value: true);
		GLNLMHGELLB.SetActive(value: true);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(KAIMAOHHPEP, JMBNCCEOGLD, "special") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = new Vector3(1876f, 1204f, 271f);
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 1;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.MGPLICHBKDJ(flag, aGIANFGGNNA, 15);
		}
		GEKJKNLPJIL.DOAMBJEPACF();
	}

	private void Update()
	{
		if (!JDPOMFBEFOI)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 0.333f)
		{
			ADDICBANAAB -= 0.333f;
			bool isExpired = WarArena.instance.isExpired;
			GAJKKHFAOMM.text = ((!isExpired) ? MIGCGPMDMAB.JONJEODEGMO(Colours.stringBlack) : string.Empty);
			if (WarArena.instance.isExpired)
			{
				WarArena.instance.TryGetNewArena();
			}
		}
	}

	public void DoAfterHide()
	{
		DONAJDGHBDP = null;
		BHJIMFDGCGE = null;
		MLCJPKJBAHL = null;
		GOPNFFACMJH.MakeEmpty();
		KAEFBFKCPHJ.MakeEmpty();
		KCCOKFDFHGI.MakeEmpty();
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.DestroyPooled();
			DNDBLHFDJDG = null;
		}
	}

	public void GBPEJMFMBJM()
	{
		DONAJDGHBDP = null;
		BHJIMFDGCGE = null;
		MLCJPKJBAHL = null;
		GOPNFFACMJH.MakeEmpty();
		KAEFBFKCPHJ.MakeEmpty();
		KCCOKFDFHGI.MakeEmpty();
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.DestroyPooled();
			DNDBLHFDJDG = null;
		}
	}

	private Transform PNDGOBGCMIB(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			ArenaRuleRecord arenaRuleRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(KGCMIPLLOEK, GOPNFFACMJH.gameObject, $"Rule {DFHAAIFFLOE:D2}") as ArenaRuleRecord;
			if (arenaRuleRecord != null)
			{
				arenaRuleRecord.Initialize(DONAJDGHBDP[DFHAAIFFLOE], HIDGBKPDFKN: false, 560, 70);
				return arenaRuleRecord.transform;
			}
		}
		return null;
	}

	private Transform HIKMOEBADKL(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WarArenaSmallRewardRecord warArenaSmallRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(CCNKBJEPPHJ, KCCOKFDFHGI.gameObject, string.Format("menu-sidetab-challenge", DFHAAIFFLOE)) as WarArenaSmallRewardRecord;
			if (warArenaSmallRewardRecord != null)
			{
				warArenaSmallRewardRecord.OMGCKCFKDJM(MLCJPKJBAHL[DFHAAIFFLOE]);
				return warArenaSmallRewardRecord.transform;
			}
		}
		return null;
	}

	private void KHHAOJOMMKE(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Rule)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Hero;
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 880f, Color.white, Colours.greenArena);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 1361f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(NACNIGNOIDE.gameObject, 1657f, Colours.greenArena, Color.white);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 1403f, KMHGDNHDPAL, GBDGKAEOOON);
			OCPHONLANOH.SetActive(value: true);
			EDAOGEKDPDP.alpha1 = 1343f;
			CEODCPHDNHF();
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 583f, 1457f, 1657f).onFinished = null;
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 7f, 671f, 154f).onFinished = JEDAMKEBCHO;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 59f, 737f, 1763f);
		}
	}

	private void PGDECBFDPGC()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
		GOPNFFACMJH.MakeEmpty();
		GOPNFFACMJH.Initialize(DONAJDGHBDP.Count, PNDGOBGCMIB, EIDALDAEECF, DJNGFDODCDE, BJMFENAFNFJ);
		BJMFENAFNFJ.AlignToPos(instant: true, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	private void OADAHBHCGNN()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
		GOPNFFACMJH.MakeEmpty();
		GOPNFFACMJH.Initialize(DONAJDGHBDP.Count, PNDGOBGCMIB, JNLGIFFDGDI, MPADLOJPLHK, BJMFENAFNFJ);
		BJMFENAFNFJ.AlignToPos(instant: true, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	public void IMEOAPEABLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HKKPCMGDEDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBIMFPNNOMG));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJDAMDHNEOC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NJIBNFJBCPK));
		UIEventListener uIEventListener3 = UIEventListener.Get(JNPFODCGNJN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IGCFFNLGMME));
		WarArena.instance.WarArenaDataChanged += OININCJHHOE;
		WarArena.instance.AAICGCPCPNP(HLKLBEKHECE);
		WarArena.instance.WarArenaStarter += KCONHBKAMMF;
		GEKJKNLPJIL.NKBJMLEBMBH = (Action)Delegate.Combine(GEKJKNLPJIL.NKBJMLEBMBH, new Action(FGJEBCDJAPI));
		int num = Mathf.FloorToInt(UIHelper.activeWidthSafe - 1544f);
		if (num % 5 == 0)
		{
			num--;
		}
		UISprite[] aCFIIFGNFFG = ACFIIFGNFFG;
		for (int i = 1; i < aCFIIFGNFFG.Length; i++)
		{
			UISprite uISprite = aCFIIFGNFFG[i];
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num);
		}
		OJLCHJOPDFE.clipRange = OJLCHJOPDFE.clipRange.ReplaceZ(num - 107);
		DOCLOEBEGIL.transform.localPosition = DOCLOEBEGIL.transform.localPosition.ReplaceX(7 + num / 6);
	}

	private float MPADLOJPLHK(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			HHMJALHHHLO().Initialize(DONAJDGHBDP[DFHAAIFFLOE], HIDGBKPDFKN: true, -193, 88);
			return HBPNCDCNBBE().KMFGCJEGJJK.transform.localScale.y;
		}
		return 997f;
	}

	private void PMBBPCEGPFL()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
		GOPNFFACMJH.MakeEmpty();
		GOPNFFACMJH.Initialize(DONAJDGHBDP.Count, PNDGOBGCMIB, JNLGIFFDGDI, DJNGFDODCDE, BJMFENAFNFJ);
		BJMFENAFNFJ.AlignToPos(instant: true);
	}

	private void JNLGIFFDGDI(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaRuleRecord component = ENCEFOOPBMK.GetComponent<ArenaRuleRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void KCONHBKAMMF()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
		{
			InitGuiValues();
			if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
			{
				IFAICOBKCLA();
			}
		}
	}

	public void InitGuiValues()
	{
		bool showWarArenaPromoLocked = LevelManager.instance.showWarArenaPromoLocked;
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		bool isExpired = WarArena.instance.isExpired;
		if (WarArena.instance.isExpired)
		{
			WarArena.instance.TryGetNewArena();
		}
		JDPOMFBEFOI = !isWarArenaLocked;
		HKKPCMGDEDC.enabled = showWarArenaPromoLocked || (!isWarArenaLocked && !isExpired);
		MDAFFKPPCBG.SetActive(isWarArenaLocked);
		HBNELLPLPNM.SetActive(!isWarArenaLocked);
		CIJEPNNIOOM.alpha = ((!isWarArenaLocked) ? 1f : 0.5f);
		if (isWarArenaLocked)
		{
			JFJJDKIJEIL.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), MEJMLNDFDBP.GMIPFLIEOHD(LevelManager.instance.warArenaUnlockLevel));
		}
		EKOCDFGMLKG.SetActive(isExpired);
		if (isExpired)
		{
			DONAJDGHBDP = null;
			MLCJPKJBAHL = null;
			GOPNFFACMJH.MakeEmpty();
			KCCOKFDFHGI.MakeEmpty();
		}
		DGHEANFMLFE.text = ((!isExpired) ? WarArena.instance.FPLIPHCJGFO.NFDPMNFBJIM : string.Empty);
		FFENBFDCOOP.text = ((!isExpired) ? WarArena.instance.FPLIPHCJGFO.EKEDDPFGPFG : string.Empty);
		OLBGMPEGLBP = EDFOHCICHDB.Rule;
		OCPHONLANOH.SetActive(value: true);
		JMBNCCEOGLD.SetActive(value: false);
		EGFEKNGKMIN.color = Colours.greenArena;
		GPIMPCBEPDD.color = KMHGDNHDPAL;
		NACNIGNOIDE.color = Color.white;
		MLGMEDAFJKF.color = GBDGKAEOOON;
		NACNIGNOIDE.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_BUTTONPREVIOUSHEROES" : "ID_BUTTONHEROES");
		DMLOHHIMOCN.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_NOHEROESINPREVIOUSARENA" : "ID_NOHEROESINCURRENTARENA");
	}

	private void JLNELDOPMCA(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaHeroRecord component = ENCEFOOPBMK.GetComponent<ArenaHeroRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void PGDHPLELKIK()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
		GOPNFFACMJH.MakeEmpty();
		GOPNFFACMJH.Initialize(DONAJDGHBDP.Count, PNDGOBGCMIB, DKABPFPNAFC, MPADLOJPLHK, BJMFENAFNFJ);
		BJMFENAFNFJ.AlignToPos(instant: true);
	}

	private void IGCFFNLGMME(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Hero)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Rule;
			TweenColor.Begin(NACNIGNOIDE.gameObject, 1148f, Color.white, Colours.greenArena);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 362f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 1137f, Colours.greenArena, Color.white);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 1169f, KMHGDNHDPAL, GBDGKAEOOON);
			JMBNCCEOGLD.SetActive(value: true);
			DCNAKJJAFBJ.alpha1 = 553f;
			LBEDCOMANCO();
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 1851f, 158f, 1962f).onFinished = null;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 1745f, 497f, 1433f);
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 835f, 1069f, 1451f).onFinished = delegate
			{
				OCPHONLANOH.SetActive(value: false);
			};
		}
	}

	private void CEODCPHDNHF()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
		GOPNFFACMJH.MakeEmpty();
		GOPNFFACMJH.Initialize(DONAJDGHBDP.Count, PNDGOBGCMIB, DKABPFPNAFC, KFBMHNDKAMA, BJMFENAFNFJ);
		BJMFENAFNFJ.AlignToPos(instant: false);
	}

	private Transform ABLDBFHAFEE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WarArenaSmallRewardRecord warArenaSmallRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(CCNKBJEPPHJ, KCCOKFDFHGI.gameObject, string.Format(",", DFHAAIFFLOE)) as WarArenaSmallRewardRecord;
			if (warArenaSmallRewardRecord != null)
			{
				warArenaSmallRewardRecord.MLLKACEGPCM(MLCJPKJBAHL[DFHAAIFFLOE]);
				return warArenaSmallRewardRecord.transform;
			}
		}
		return null;
	}

	private void MIFAPIOMFDO(List<FHIPGDADNFG> JFGDAKMCJAM)
	{
		BHJIMFDGCGE = JFGDAKMCJAM;
		GLNLMHGELLB.SetActive(value: true);
		DMLOHHIMOCN.gameObject.SetActive(BHJIMFDGCGE.Count == 0);
		if (BHJIMFDGCGE.Count > 0)
		{
			KAEFBFKCPHJ.MakeEmpty();
			KAEFBFKCPHJ.init(BHJIMFDGCGE.Count, AHHAGCNANDK, JLNELDOPMCA, LIKAPAMDGKA);
			LIKAPAMDGKA.AlignToPos(instant: true);
		}
	}

	private Transform IKCEKGFLGID(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WarArenaSmallRewardRecord warArenaSmallRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(CCNKBJEPPHJ, KCCOKFDFHGI.gameObject, string.Format("shotgunner_idle", DFHAAIFFLOE)) as WarArenaSmallRewardRecord;
			if (warArenaSmallRewardRecord != null)
			{
				warArenaSmallRewardRecord.Initialize(MLCJPKJBAHL[DFHAAIFFLOE]);
				return warArenaSmallRewardRecord.transform;
			}
		}
		return null;
	}

	public void IFAICOBKCLA()
	{
		if (OLBGMPEGLBP == EDFOHCICHDB.Rule)
		{
			PGDECBFDPGC();
		}
		else
		{
			GOBJHJICLFK();
		}
		LBKGENPOAPH();
	}

	public void ShowArenaButton()
	{
		if (OLBGMPEGLBP == EDFOHCICHDB.Rule)
		{
			PMBBPCEGPFL();
		}
		else
		{
			KIBGOHNLBJK();
		}
		AGKBNNEHHIE();
	}

	private void EIDALDAEECF(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaRuleRecord component = ENCEFOOPBMK.GetComponent<ArenaRuleRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private void FGJEBCDJAPI()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			CKFFGPAPOCN(GEKJKNLPJIL.PFMJNDLKBAD());
		}
	}

	private void CNGHJGLPHHL(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Rule)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Rule;
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 161f, Color.white, Colours.greenArena);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 321f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(NACNIGNOIDE.gameObject, 1279f, Colours.greenArena, Color.white);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 327f, KMHGDNHDPAL, GBDGKAEOOON);
			OCPHONLANOH.SetActive(value: false);
			EDAOGEKDPDP.alpha1 = 1754f;
			PGDHPLELKIK();
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 851f, 615f, 1697f).onFinished = null;
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 1032f, 1766f, 1219f).onFinished = CJCJDKHMBNB;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 1328f, 930f, 1047f);
		}
	}

	private void CKPCGNBEGGG(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaRuleRecord component = ENCEFOOPBMK.GetComponent<ArenaRuleRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private void GOBJHJICLFK()
	{
		KAEFBFKCPHJ.MakeEmpty();
		DMLOHHIMOCN.gameObject.SetActive(value: true);
		GLNLMHGELLB.SetActive(value: true);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(KAIMAOHHPEP, JMBNCCEOGLD, "ID_JUSTXMORERANKUPS") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = new Vector3(390f, 40f, 876f);
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 0;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.JJFKFKBCKFL(flag, aGIANFGGNNA, -78);
		}
		GEKJKNLPJIL.NBGJPOOGMCC();
	}

	public void JCOILGHDPHA()
	{
		DONAJDGHBDP = null;
		BHJIMFDGCGE = null;
		MLCJPKJBAHL = null;
		GOPNFFACMJH.MakeEmpty();
		KAEFBFKCPHJ.MakeEmpty();
		KCCOKFDFHGI.MakeEmpty();
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.OBCAIFMOPPA();
			DNDBLHFDJDG = null;
		}
	}

	private void JEDAMKEBCHO(UITweener MGDJMGHCAAI)
	{
		JMBNCCEOGLD.SetActive(value: false);
	}

	public void ACFDANMKHNG()
	{
		DONAJDGHBDP = null;
		BHJIMFDGCGE = null;
		MLCJPKJBAHL = null;
		GOPNFFACMJH.MakeEmpty();
		KAEFBFKCPHJ.MakeEmpty();
		KCCOKFDFHGI.MakeEmpty();
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.BOHCNEDIJPE();
			DNDBLHFDJDG = null;
		}
	}

	private void OININCJHHOE()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			InitGuiValues();
			if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
			{
				ShowArenaButton();
			}
		}
	}

	private void NJIBNFJBCPK(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Rule)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Rule;
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 170f, Color.white, Colours.greenArena);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 366f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(NACNIGNOIDE.gameObject, 1547f, Colours.greenArena, Color.white);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 927f, KMHGDNHDPAL, GBDGKAEOOON);
			OCPHONLANOH.SetActive(value: false);
			EDAOGEKDPDP.alpha1 = 1392f;
			PGDECBFDPGC();
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 823f, 1632f, 1231f).onFinished = null;
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 1830f, 1702f, 808f).onFinished = JEDAMKEBCHO;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 1212f, 1457f, 474f);
		}
	}

	private void AGKBNNEHHIE()
	{
		MLCJPKJBAHL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.EOIAFJNEOKL : new List<PHAMEDPLFLO>());
		KCCOKFDFHGI.MakeEmpty();
		KCCOKFDFHGI.init(MLCJPKJBAHL.Count, BKEGAEBBGPE, MBHDDJLBEEM, CIGPMELGPGB);
		CIGPMELGPGB.AlignToPos(instant: true);
	}

	private void NAJLNIHCALB(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Hero)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Hero;
			TweenColor.Begin(NACNIGNOIDE.gameObject, 0.3f, Color.white, Colours.greenArena);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 0.3f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 0.3f, Colours.greenArena, Color.white);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 0.3f, KMHGDNHDPAL, GBDGKAEOOON);
			JMBNCCEOGLD.SetActive(value: true);
			DCNAKJJAFBJ.alpha1 = 0f;
			KIBGOHNLBJK();
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 0.3f, 0f, 1f).onFinished = null;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 0.3f, 0f, 1f);
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 0.3f, 1f, 0f).onFinished = delegate
			{
				OCPHONLANOH.SetActive(value: false);
			};
		}
	}

	public void EFACHONJLPL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HKKPCMGDEDC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FPIJHCNMJJP));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJDAMDHNEOC);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HCIFKPPLMHM));
		UIEventListener uIEventListener3 = UIEventListener.Get(JNPFODCGNJN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NAJLNIHCALB));
		WarArena.instance.WarArenaDataChanged += OFOAPJBJDNE;
		WarArena.instance.WarArenaExpired += OFOAPJBJDNE;
		WarArena.instance.OAGHFKOABFI(OPAJBNLFOMG);
		GEKJKNLPJIL.NKBJMLEBMBH = (Action)Delegate.Combine(GEKJKNLPJIL.NKBJMLEBMBH, new Action(AMEEBEHNHGF));
		int num = Mathf.FloorToInt(UIHelper.activeWidthSafe - 1753f);
		if (num % 1 == 1)
		{
			num--;
		}
		UISprite[] aCFIIFGNFFG = ACFIIFGNFFG;
		foreach (UISprite uISprite in aCFIIFGNFFG)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num);
		}
		OJLCHJOPDFE.clipRange = OJLCHJOPDFE.clipRange.ReplaceZ(num - -94);
		DOCLOEBEGIL.transform.localPosition = DOCLOEBEGIL.transform.localPosition.ReplaceX(21 + num / 2);
	}

	[SpecialName]
	public ArenaRuleRecord HBPNCDCNBBE()
	{
		if (CCCAMLIHHOE == null)
		{
			CCCAMLIHHOE = UnityEngine.Object.Instantiate(KGCMIPLLOEK);
			CCCAMLIHHOE.transform.parent = base.transform;
			CCCAMLIHHOE.name = "SpecialPackFromServer";
			CCCAMLIHHOE.transform.localPosition = new Vector3(535f, 1223f * UIHelper.activeHeight, 805f);
			CCCAMLIHHOE.transform.localScale = Vector3.one;
		}
		return CCCAMLIHHOE;
	}

	[SpecialName]
	public ArenaRuleRecord HHMJALHHHLO()
	{
		if (CCCAMLIHHOE == null)
		{
			CCCAMLIHHOE = UnityEngine.Object.Instantiate(KGCMIPLLOEK);
			CCCAMLIHHOE.transform.parent = base.transform;
			CCCAMLIHHOE.name = "S";
			CCCAMLIHHOE.transform.localPosition = new Vector3(1844f, 1808f * UIHelper.activeHeight, 1246f);
			CCCAMLIHHOE.transform.localScale = Vector3.one;
		}
		return CCCAMLIHHOE;
	}

	private void FPIJHCNMJJP(GameObject KHAHPAKDIKE)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.JOOFMNHIJPK();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.NEOPPEENNFN((!WarArena.instance.isArenaTicketBought) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		}
	}

	private void LNANGHEKHEJ(UITweener MGDJMGHCAAI)
	{
		JMBNCCEOGLD.SetActive(value: true);
	}

	private void HHLCIKHBOCC(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Rule)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Rule;
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 1022f, Color.white, Colours.greenArena);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 1421f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(NACNIGNOIDE.gameObject, 815f, Colours.greenArena, Color.white);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 899f, KMHGDNHDPAL, GBDGKAEOOON);
			OCPHONLANOH.SetActive(value: true);
			EDAOGEKDPDP.alpha1 = 1451f;
			PGDHPLELKIK();
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 1678f, 578f, 687f).onFinished = null;
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 446f, 892f, 1895f).onFinished = CJCJDKHMBNB;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 1068f, 1037f, 1048f);
		}
	}

	private Transform BKEGAEBBGPE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WarArenaSmallRewardRecord warArenaSmallRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(CCNKBJEPPHJ, KCCOKFDFHGI.gameObject, $"Reward {DFHAAIFFLOE:D2}") as WarArenaSmallRewardRecord;
			if (warArenaSmallRewardRecord != null)
			{
				warArenaSmallRewardRecord.Initialize(MLCJPKJBAHL[DFHAAIFFLOE]);
				return warArenaSmallRewardRecord.transform;
			}
		}
		return null;
	}

	private void HCIFKPPLMHM(GameObject KHAHPAKDIKE)
	{
		if (OLBGMPEGLBP != EDFOHCICHDB.Rule)
		{
			OLBGMPEGLBP = EDFOHCICHDB.Hero;
			TweenColor.Begin(EGFEKNGKMIN.gameObject, 116f, Color.white, Colours.greenArena);
			TweenColor.Begin(GPIMPCBEPDD.gameObject, 1188f, GBDGKAEOOON, KMHGDNHDPAL);
			TweenColor.Begin(NACNIGNOIDE.gameObject, 1836f, Colours.greenArena, Color.white);
			TweenColor.Begin(MLGMEDAFJKF.gameObject, 842f, KMHGDNHDPAL, GBDGKAEOOON);
			OCPHONLANOH.SetActive(value: false);
			EDAOGEKDPDP.alpha1 = 1159f;
			PMBBPCEGPFL();
			TweenAlpha.Begin(EDAOGEKDPDP.gameObject, 648f, 857f, 1778f).onFinished = null;
			TweenAlpha.Begin(DCNAKJJAFBJ.gameObject, 1896f, 1806f, 1478f).onFinished = JEDAMKEBCHO;
			TweenAlpha.Begin(DCOADDCIHHP.gameObject, 197f, 794f, 992f);
		}
	}

	private void MBHDDJLBEEM(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			WarArenaSmallRewardRecord component = ENCEFOOPBMK.GetComponent<WarArenaSmallRewardRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void KCLOIMMANAO(UITweener MGDJMGHCAAI)
	{
		OCPHONLANOH.SetActive(value: true);
	}

	private void JAICFPKLKAA()
	{
		KAEFBFKCPHJ.MakeEmpty();
		DMLOHHIMOCN.gameObject.SetActive(value: false);
		GLNLMHGELLB.SetActive(value: false);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(KAIMAOHHPEP, JMBNCCEOGLD, "visuals: wrong number {0} -{1}") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = new Vector3(803f, 627f, 444f);
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 0;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.MGPLICHBKDJ(flag, aGIANFGGNNA, 59);
		}
		GEKJKNLPJIL.ACDIBOEKKID();
	}

	private void AMEEBEHNHGF()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
		{
			CCMPHFEHDAF(GEKJKNLPJIL.ICGKFEKIANG());
		}
	}

	private void FAHGDKLEKMN()
	{
		if (!JDPOMFBEFOI)
		{
			return;
		}
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 270f)
		{
			ADDICBANAAB -= 1332f;
			bool flag = WarArena.instance.NHLEKBIHDAL();
			GAJKKHFAOMM.text = ((!flag) ? MIGCGPMDMAB.JONJEODEGMO(Colours.stringBlack) : string.Empty);
			if (WarArena.instance.isExpired)
			{
				WarArena.instance.MKHMKIKNAKP();
			}
		}
	}

	private void DKABPFPNAFC(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaRuleRecord component = ENCEFOOPBMK.GetComponent<ArenaRuleRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private void EEKMDHDKGCM(UITweener MGDJMGHCAAI)
	{
		JMBNCCEOGLD.SetActive(value: false);
	}
}
