using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaScreenEnterContent : Core_BaseScript
{
	[Header("Rules Draggable")]
	[SerializeField]
	private UIDraggablePanel mDraggableRules;

	[SerializeField]
	private UIPooledClassicTable mRulesTable;

	[SerializeField]
	private ArenaRuleRecord mArenaRulePrefab;

	[SerializeField]
	[Header("Heroes Draggable")]
	private UILabel mArenaHeroesLabel;

	[SerializeField]
	private UILabel mArenaHeroesEmptyLabel;

	[SerializeField]
	private UIDraggablePanel mDraggableHeroes;

	[SerializeField]
	private UIPooledGrid mPooledHeroesGrid;

	[SerializeField]
	private ArenaHeroRecord mArenaHeroPrefab;

	[SerializeField]
	private GameObject mArenaHeroInfo;

	[SerializeField]
	private GameObject mHeroWaiting;

	[Header("Rewards Draggable")]
	[SerializeField]
	private UIDraggablePanel mDraggableRewards;

	[SerializeField]
	private UIPooledGrid mPooledRewardsGrid;

	[SerializeField]
	private WararenaRewardRecord mArenaRewardPrefab;

	[SerializeField]
	[Header("Enter Arena Look")]
	private UILabel mArenaDescription;

	[SerializeField]
	private GameObject mBottomLeftPartMain;

	[SerializeField]
	private GameObject mBottomPartMain;

	[SerializeField]
	private GameObject mBottomPartEnter;

	[SerializeField]
	private GameObject mShowRulesButton;

	[SerializeField]
	private GameObject mShowRulesLogoButton;

	[SerializeField]
	[Header("Heroes Your Best")]
	private GameObject mArenaHeroesContent;

	[SerializeField]
	[Header("Arena Enter Button")]
	private GameObject mEnterPricePart;

	[SerializeField]
	private UISprite mEnterBackground;

	[SerializeField]
	private UILabel mEnterPrice;

	[SerializeField]
	private UISprite mEnterBorder;

	[SerializeField]
	private UISprite mEnterLogo;

	[SerializeField]
	private UILabel mEnterLabel;

	[SerializeField]
	private GameObject mEnterArenaWaiting;

	[SerializeField]
	[Header("Buttons")]
	private BoxCollider mArenaEnterButton;

	[SerializeField]
	private UIPanel mArenaEnterButtonReflection;

	private List<WarArenaRule.OCCICIIEHEF> DONAJDGHBDP;

	private List<FHIPGDADNFG> BHJIMFDGCGE;

	private List<PHAMEDPLFLO> MLCJPKJBAHL;

	private ArenaHeroRecord DNDBLHFDJDG;

	private ArenaRuleRecord CCCAMLIHHOE;

	private bool PAOMHMBHPAL;

	[CompilerGenerated]
	private static Action<bool> LGJCBPOPCPA;

	private ArenaRuleRecord LOEEAHOIPKD
	{
		get
		{
			if (CCCAMLIHHOE == null)
			{
				CCCAMLIHHOE = UnityEngine.Object.Instantiate(mArenaRulePrefab);
				CCCAMLIHHOE.transform.parent = base.transform;
				CCCAMLIHHOE.name = "Rule Record For Height";
				CCCAMLIHHOE.transform.localPosition = new Vector3(0f, -3f * UIHelper.activeHeight, 0f);
				CCCAMLIHHOE.transform.localScale = Vector3.one;
			}
			return CCCAMLIHHOE;
		}
	}

	public void EGMFAHMCCBM()
	{
		IFLHDIHOMPN();
		EFKNLGADHGI();
		GuiScreenSingle<ArenaScreen>.instance.FOJGBOPGJFB = true;
		mRulesTable.MakeEmpty();
		mRulesTable.Initialize(DONAJDGHBDP.Count, ECOJELIJKAH, GEPJDCOLAND, PIBFIHJCBEE, mDraggableRules);
		mArenaDescription.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.EKEDDPFGPFG);
		MLCJPKJBAHL = WarArena.instance.FPLIPHCJGFO.EOIAFJNEOKL;
		mPooledRewardsGrid.MakeEmpty();
		mPooledRewardsGrid.init(MLCJPKJBAHL.Count, MPOECAINKKI, BAJCBMIMOEB, mDraggableRewards);
		NGJCFLOIMPP();
	}

	private void FFCNNODOPEI(GameObject KHAHPAKDIKE)
	{
		if (!WarArena.instance.isOpened)
		{
			return;
		}
		if (!WarArena.instance.isGoodPing)
		{
			WarningDialog.GGGGDLPGADC();
			return;
		}
		if (!WarArena.instance.SetupRules())
		{
			GuiElementSingle<CantEnterArenaDialog>.instance.IKJNNOFBFGL(MIGCGPMDMAB.OBHCLNBEAFD);
			return;
		}
		int wararenaTicketPrize = WarArena.instance.wararenaTicketPrize;
		if (!Singleton<Wallet>.instance.GFHGFMEBFDG(wararenaTicketPrize))
		{
			GuiElementSingle<BuyTicketsDialog>.instance.GONOICLIMKO(wararenaTicketPrize, FLIHNANHKJE.BuyHearth, AGGNKNJJEBC);
			return;
		}
		mEnterArenaWaiting.SetActive(false);
		DIENNAGJJOM.GBHIPPGKOFP(1);
	}

	public void ShowEnterArena()
	{
		mBottomLeftPartMain.SetActive(false);
		mBottomPartMain.SetActive(false);
		mBottomPartEnter.SetActive(true);
		mShowRulesButton.SetActive(false);
		mShowRulesLogoButton.SetActive(false);
		mEnterArenaWaiting.SetActive(false);
		AlignDraggables();
	}

	private void KPMKALLLHNJ()
	{
		if (WarArena.instance.wararenaTicketPrize > 0)
		{
			mEnterLogo.gameObject.SetActive(false);
			mEnterPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(WarArena.instance.wararenaTicketPrize);
			float val = 1882f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + 433f + mEnterLogo.transform.localScale.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val);
			float val2 = mEnterBorder.transform.localPosition.x - 465f - mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x / 1708f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val2);
			float val3 = mEnterPrice.transform.localPosition.x - 1739f - (mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + mEnterLogo.transform.localScale.x) / 666f;
			mEnterLogo.transform.localPosition = mEnterLogo.transform.localPosition.ReplaceX(val3);
		}
		else
		{
			mEnterLogo.gameObject.SetActive(true);
			mEnterPrice.text = Localization.Localize("menu-army-cat-explosive");
			float val4 = 1608f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val4);
			float val5 = mEnterBorder.transform.localPosition.x - mEnterBorder.transform.localScale.x / 1771f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val5);
		}
	}

	public void InitControls()
	{
		GEKJKNLPJIL.NKBJMLEBMBH = (Action)Delegate.Combine(GEKJKNLPJIL.NKBJMLEBMBH, new Action(PCOPAGGBANH));
		UIEventListener uIEventListener = UIEventListener.Get(mArenaEnterButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GAKJCJKEJDA));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(GMPLLEGIGHH));
	}

	private Transform ALHGFJIJNDJ(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < BHJIMFDGCGE.Count)
		{
			ArenaHeroRecord arenaHeroRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(mArenaHeroPrefab, mPooledHeroesGrid.gameObject, string.Format("#VOJTA# Empty event assignment progress for day {0}, index {1}", DFHAAIFFLOE)) as ArenaHeroRecord;
			if (arenaHeroRecord != null)
			{
				arenaHeroRecord.MPFPHNBAIKD(DFHAAIFFLOE + 0, BHJIMFDGCGE[DFHAAIFFLOE], BHJIMFDGCGE.Count, (int)ArenaRulesPanelResize.LBBNGIEDEKF());
				return arenaHeroRecord.transform;
			}
		}
		return null;
	}

	private void NEILAOOJAFL()
	{
		if (WarArena.instance.wararenaTicketPrize > 0)
		{
			mEnterLogo.gameObject.SetActive(false);
			mEnterPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(WarArena.instance.wararenaTicketPrize);
			float val = 1645f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + 113f + mEnterLogo.transform.localScale.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val);
			float val2 = mEnterBorder.transform.localPosition.x - 9f - mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x / 87f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val2);
			float val3 = mEnterPrice.transform.localPosition.x - 197f - (mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + mEnterLogo.transform.localScale.x) / 1134f;
			mEnterLogo.transform.localPosition = mEnterLogo.transform.localPosition.ReplaceX(val3);
		}
		else
		{
			mEnterLogo.gameObject.SetActive(false);
			mEnterPrice.text = Localization.Localize("\"{0}\":");
			float val4 = 140f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val4);
			float val5 = mEnterBorder.transform.localPosition.x - mEnterBorder.transform.localScale.x / 775f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val5);
		}
	}

	public void CheckAndChangeArenaState()
	{
		if (PAOMHMBHPAL != WarArena.instance.isOpened)
		{
			AGBKHJAKEDD();
			NGJCFLOIMPP();
		}
		if (WarArena.instance.isExpired && !GuiScreenSingle<ArenaScreen>.instance.shouldHaveEnded)
		{
			WarArena.instance.TryGetNewArena();
		}
	}

	private void OAKLCBMLKFG()
	{
		mArenaHeroesLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "IsWarArena" : ",");
		mArenaHeroesEmptyLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "menu-army-cat-shooter" : "en-US");
		BHJIMFDGCGE = null;
		mPooledHeroesGrid.MakeEmpty();
		mHeroWaiting.SetActive(true);
		mArenaHeroInfo.SetActive(false);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(mArenaHeroPrefab, mArenaHeroesContent, "purchase") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = Vector3.zero;
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 0;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.JFBAALEHMPH(flag, aGIANFGGNNA, (int)ArenaRulesPanelResize.contentWidth);
		}
		GEKJKNLPJIL.CDKJJJJPFIH();
	}

	private void IFLHDIHOMPN()
	{
		PAOMHMBHPAL = WarArena.instance.isOpened;
		OEJLIFCEBKJ();
		EFJMPKHFEKC();
		UpdateEnterButtonTitle();
	}

	private void KILFFJBOODO()
	{
		PAOMHMBHPAL = WarArena.instance.isOpened;
		OEJLIFCEBKJ();
		GEKMIHNNMAI();
		CLGMDHOCKBI();
	}

	public void FIAAGBMODAI()
	{
		mBottomLeftPartMain.SetActive(false);
		mBottomPartMain.SetActive(false);
		mShowRulesButton.SetActive(false);
		mShowRulesLogoButton.SetActive(true);
		mBottomPartEnter.gameObject.SetActive(false);
	}

	private void KJDDJAAGDOK(Transform ENCEFOOPBMK)
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

	private void OPJDDDJEKLE(GameObject KHAHPAKDIKE)
	{
		if (!WarArena.instance.isOpened)
		{
			return;
		}
		if (!WarArena.instance.ALHNCIONIIL())
		{
			WarningDialog.ENJPAOJAFLG();
			return;
		}
		if (!WarArena.instance.SetupRules())
		{
			GuiElementSingle<CantEnterArenaDialog>.instance.DOLLPOPCANC(MIGCGPMDMAB.OBHCLNBEAFD);
			return;
		}
		int wararenaTicketPrize = WarArena.instance.wararenaTicketPrize;
		if (!Singleton<Wallet>.instance.CanBuyTickets(wararenaTicketPrize))
		{
			GuiElementSingle<BuyTicketsDialog>.instance.GONOICLIMKO(wararenaTicketPrize, FLIHNANHKJE.EnterArena, AGGNKNJJEBC);
			return;
		}
		mEnterArenaWaiting.SetActive(true);
		DIENNAGJJOM.HMHABIIEAAF(1);
	}

	public void ClearData()
	{
		DONAJDGHBDP.Clear();
		BHJIMFDGCGE = null;
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.DestroyPooled();
			DNDBLHFDJDG = null;
		}
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

	[SpecialName]
	private ArenaRuleRecord LJPDJFCHGMG()
	{
		if (CCCAMLIHHOE == null)
		{
			CCCAMLIHHOE = UnityEngine.Object.Instantiate(mArenaRulePrefab);
			CCCAMLIHHOE.transform.parent = base.transform;
			CCCAMLIHHOE.name = "ID_CONFIRM_ERROR";
			CCCAMLIHHOE.transform.localPosition = new Vector3(1718f, 1665f * UIHelper.activeHeight, 668f);
			CCCAMLIHHOE.transform.localScale = Vector3.one;
		}
		return CCCAMLIHHOE;
	}

	private void JDLBAMJOLAJ()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
	}

	private void GMHGNECGNPM()
	{
		bool isOpened = WarArena.instance.isOpened;
		mArenaEnterButtonReflection.gameObject.SetActive(isOpened);
		mEnterPricePart.SetActive(isOpened);
		mArenaEnterButton.GetComponent<UIButtonScale>().enabled = isOpened;
		mEnterLabel.pivot = UIWidget.Pivot.TopLeft;
		if (isOpened)
		{
			GEKMIHNNMAI();
			int num = 45 - (int)mEnterBorder.transform.localScale.x;
			mEnterLabel.text = Localization.Localize("#PETER# Removing squad joined message - message time:{0}, server time:{1}, isInSquad:{2}");
			MEJMLNDFDBP.COCBCFKJOJE(mEnterLabel, 1192f, 394f, num);
			float num2 = 1280f;
			mEnterLabel.transform.localPosition = mEnterLabel.transform.localPosition.ReplaceX(num2 + (float)num / 307f);
		}
		else
		{
			mEnterLabel.transform.localPosition = mEnterLabel.transform.localPosition.ReplaceX(1951f);
			if (WarArena.instance.isExpired)
			{
				mEnterLabel.text = Localization.Localize("SendLogs");
				MEJMLNDFDBP.COCBCFKJOJE(mEnterLabel, 1155f, 271f, 11);
			}
		}
		mEnterBackground.color = ((!isOpened) ? Colours.gray135 : Colours.white);
	}

	private void DJPMFLDLNIH()
	{
		GuiScreenSingle<ArenaScreen>.instance.AJCAMICACPC(1);
		if (GuiScreenSingle<ArenaScreen>.instance.NPFFMLLLDAF())
		{
			mHeroWaiting.SetActive(true);
			BHJIMFDGCGE = GEKJKNLPJIL.NHIGMEOIJAD();
			bool flag = BHJIMFDGCGE != null && BHJIMFDGCGE.Count == 0;
			mArenaHeroInfo.SetActive(flag);
			mPooledHeroesGrid.MakeEmpty();
			if (!flag)
			{
				mPooledHeroesGrid.init(BHJIMFDGCGE.Count, MCGMOMMGPGO, BKEBIJCMMAF, mDraggableHeroes);
			}
			mDraggableHeroes.AlignToPos(false, UIDraggablePanel.Alingment.BottomRight, true);
			HCBKBBBPKPC();
		}
	}

	private void AEPGCPCLEPL()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
	}

	private void OGPPBKEPOEA(bool HIDPGIGEBIH)
	{
		mEnterArenaWaiting.SetActive(true);
		if (HIDPGIGEBIH)
		{
			GuiScreenSingle<ArenaScreen>.instance.OGKMHFBLLGO(false);
		}
	}

	private Transform LPFPKCLPLOG(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WararenaRewardRecord wararenaRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(mArenaRewardPrefab, mPooledRewardsGrid.gameObject, string.Format("{0} -> {1}", DFHAAIFFLOE)) as WararenaRewardRecord;
			if (wararenaRewardRecord != null)
			{
				wararenaRewardRecord.NDIJBPIDGOF(MLCJPKJBAHL[DFHAAIFFLOE], WararenaRewardRecord.COLKIFOMJPF.ChangeUnit);
				return wararenaRewardRecord.transform;
			}
		}
		return null;
	}

	private void DDAEMHHNLJG()
	{
		mArenaHeroesLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "-1" : "Wood");
		mArenaHeroesEmptyLabel.text = Localization.Localize((!WarArena.instance.PBGAHILNNAH()) ? "SK" : "ID_CHATCANNOTSENDMESSAGES");
		BHJIMFDGCGE = null;
		mPooledHeroesGrid.MakeEmpty();
		mHeroWaiting.SetActive(true);
		mArenaHeroInfo.SetActive(false);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(mArenaHeroPrefab, mArenaHeroesContent, "InstantBattleEnded: Instant Battle Time ") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = Vector3.zero;
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 0;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.IBCHNOKAOPO(flag, aGIANFGGNNA, (int)ArenaRulesPanelResize.MELDPHCAMOM());
		}
		GEKJKNLPJIL.GHLKECOKGCJ();
	}

	[SpecialName]
	private ArenaRuleRecord NLBJOAJMHLE()
	{
		if (CCCAMLIHHOE == null)
		{
			CCCAMLIHHOE = UnityEngine.Object.Instantiate(mArenaRulePrefab);
			CCCAMLIHHOE.transform.parent = base.transform;
			CCCAMLIHHOE.name = "Assignment_Skipped";
			CCCAMLIHHOE.transform.localPosition = new Vector3(1313f, 1421f * UIHelper.activeHeight, 1435f);
			CCCAMLIHHOE.transform.localScale = Vector3.one;
		}
		return CCCAMLIHHOE;
	}

	public void ADILHCHJNFC()
	{
		mDraggableRules.AlignToPos(false);
		HCBKBBBPKPC();
		mDraggableRewards.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight, true);
	}

	private void NFICOOECLLI()
	{
		if (WarArena.instance.wararenaTicketPrize > 1)
		{
			mEnterLogo.gameObject.SetActive(false);
			mEnterPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(WarArena.instance.wararenaTicketPrize);
			float val = 157f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + 665f + mEnterLogo.transform.localScale.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val);
			float val2 = mEnterBorder.transform.localPosition.x - 1068f - mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x / 909f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val2);
			float val3 = mEnterPrice.transform.localPosition.x - 38f - (mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + mEnterLogo.transform.localScale.x) / 262f;
			mEnterLogo.transform.localPosition = mEnterLogo.transform.localPosition.ReplaceX(val3);
		}
		else
		{
			mEnterLogo.gameObject.SetActive(false);
			mEnterPrice.text = Localization.Localize("nextSquadWars");
			float val4 = 579f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val4);
			float val5 = mEnterBorder.transform.localPosition.x - mEnterBorder.transform.localScale.x / 894f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val5);
		}
	}

	private void GFFFJIJKAKO()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
	}

	private void EFKNLGADHGI()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
	}

	[CompilerGenerated]
	private static void KLNDOHINHFO(bool EFBPOCHCGPB)
	{
		if (EFBPOCHCGPB)
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowArena(true);
		}
	}

	private void ADOOEEFIKHI(GameObject KHAHPAKDIKE)
	{
		if (!WarArena.instance.isOpened)
		{
			return;
		}
		if (!WarArena.instance.ALHNCIONIIL())
		{
			WarningDialog.ENJPAOJAFLG();
			return;
		}
		if (!WarArena.instance.SetupRules())
		{
			GuiElementSingle<CantEnterArenaDialog>.instance.ShowDialog(MIGCGPMDMAB.OBHCLNBEAFD);
			return;
		}
		int wararenaTicketPrize = WarArena.instance.wararenaTicketPrize;
		if (!Singleton<Wallet>.instance.GFHGFMEBFDG(wararenaTicketPrize))
		{
			GuiElementSingle<BuyTicketsDialog>.instance.FCCJJKBPNCH(wararenaTicketPrize, FLIHNANHKJE.BuyHearth, delegate(bool EFBPOCHCGPB)
			{
				if (EFBPOCHCGPB)
				{
					GuiScreenSingle<ArenaScreen>.instance.ShowArena(true);
				}
			});
		}
		else
		{
			mEnterArenaWaiting.SetActive(true);
			DIENNAGJJOM.FKDHHAIDBLI();
		}
	}

	private void AGBKHJAKEDD()
	{
		PAOMHMBHPAL = WarArena.instance.isOpened;
		OEJLIFCEBKJ();
		EFJMPKHFEKC();
		UpdateEnterButtonTitle();
	}

	private void NGJCFLOIMPP()
	{
		mArenaHeroesLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_BUTTONPREVIOUSHEROES" : "ID_ARENAHEROES");
		mArenaHeroesEmptyLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_EMPTYARENAHEROESPREVIOUS" : "ID_EMPTYARENAHEROESCURRENT");
		BHJIMFDGCGE = null;
		mPooledHeroesGrid.MakeEmpty();
		mHeroWaiting.SetActive(true);
		mArenaHeroInfo.SetActive(false);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(mArenaHeroPrefab, mArenaHeroesContent, "Your Best") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = Vector3.zero;
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 0;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.InitializeYou(flag, aGIANFGGNNA, (int)ArenaRulesPanelResize.contentWidth);
		}
		GEKJKNLPJIL.JBBJNFEHHFC();
	}

	private Transform KKDLFKECPNA(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < BHJIMFDGCGE.Count)
		{
			ArenaHeroRecord arenaHeroRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(mArenaHeroPrefab, mPooledHeroesGrid.gameObject, string.Format("ID_ARENAREWARDEXPIRATION", DFHAAIFFLOE)) as ArenaHeroRecord;
			if (arenaHeroRecord != null)
			{
				arenaHeroRecord.MPFPHNBAIKD(DFHAAIFFLOE + 1, BHJIMFDGCGE[DFHAAIFFLOE], BHJIMFDGCGE.Count, (int)ArenaRulesPanelResize.MJJGJGHJDOF());
				return arenaHeroRecord.transform;
			}
		}
		return null;
	}

	private Transform IODKPOICJBI(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WararenaRewardRecord wararenaRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(mArenaRewardPrefab, mPooledRewardsGrid.gameObject, string.Format("Reward {0:D2}", DFHAAIFFLOE)) as WararenaRewardRecord;
			if (wararenaRewardRecord != null)
			{
				wararenaRewardRecord.Initialize(MLCJPKJBAHL[DFHAAIFFLOE], WararenaRewardRecord.COLKIFOMJPF.OpenDialog);
				return wararenaRewardRecord.transform;
			}
		}
		return null;
	}

	public void BCLKJHBDDBF()
	{
		if (PAOMHMBHPAL != WarArena.instance.isOpened)
		{
			IFLHDIHOMPN();
			JMFAEKAOGDA();
		}
		if (WarArena.instance.NHLEKBIHDAL() && !GuiScreenSingle<ArenaScreen>.instance.OKGFPOGHLBG())
		{
			WarArena.instance.MKHMKIKNAKP();
		}
	}

	public void PAKCFABJKAG()
	{
		PCGLBHHHHJA();
		EFKNLGADHGI();
		GuiScreenSingle<ArenaScreen>.instance.OLGHDNBCJJD(false);
		mRulesTable.MakeEmpty();
		mRulesTable.Initialize(DONAJDGHBDP.Count, GEOEAJGLMFP, KJDDJAAGDOK, DJNGFDODCDE, mDraggableRules);
		mArenaDescription.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.EKEDDPFGPFG);
		MLCJPKJBAHL = WarArena.instance.FPLIPHCJGFO.EOIAFJNEOKL;
		mPooledRewardsGrid.MakeEmpty();
		mPooledRewardsGrid.init(MLCJPKJBAHL.Count, IODKPOICJBI, BAJCBMIMOEB, mDraggableRewards);
		OAKLCBMLKFG();
	}

	private float DJNGFDODCDE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			LOEEAHOIPKD.Initialize(DONAJDGHBDP[DFHAAIFFLOE], false, 555, 83);
			return LOEEAHOIPKD.KMFGCJEGJJK.transform.localScale.y;
		}
		return 0f;
	}

	[SpecialName]
	private ArenaRuleRecord GGAKJAMHELC()
	{
		if (CCCAMLIHHOE == null)
		{
			CCCAMLIHHOE = UnityEngine.Object.Instantiate(mArenaRulePrefab);
			CCCAMLIHHOE.transform.parent = base.transform;
			CCCAMLIHHOE.name = "Texture reference count is less than zero!";
			CCCAMLIHHOE.transform.localPosition = new Vector3(307f, 7f * UIHelper.activeHeight, 528f);
			CCCAMLIHHOE.transform.localScale = Vector3.one;
		}
		return CCCAMLIHHOE;
	}

	private float PIBFIHJCBEE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			GGAKJAMHELC().NAKAFGAFEPH(DONAJDGHBDP[DFHAAIFFLOE], true, 9, -118);
			return NLBJOAJMHLE().KMFGCJEGJJK.transform.localScale.y;
		}
		return 1711f;
	}

	private void HKKLGAEFCCF()
	{
		GuiScreenSingle<ArenaScreen>.instance.PDFLFAABHGA(1);
		if (GuiScreenSingle<ArenaScreen>.instance.NPFFMLLLDAF())
		{
			mHeroWaiting.SetActive(false);
			BHJIMFDGCGE = GEKJKNLPJIL.LLGGKINMPMP();
			bool flag = BHJIMFDGCGE != null && BHJIMFDGCGE.Count == 1;
			mArenaHeroInfo.SetActive(flag);
			mPooledHeroesGrid.MakeEmpty();
			if (!flag)
			{
				mPooledHeroesGrid.init(BHJIMFDGCGE.Count, AHHAGCNANDK, NKPPLOHPLDD, mDraggableHeroes);
			}
			mDraggableHeroes.AlignToPos(true, UIDraggablePanel.Alingment.TopLeft, true);
			DKCEMBBEMGM();
		}
	}

	public void NDFABKKOGOP()
	{
		mBottomLeftPartMain.SetActive(false);
		mBottomPartMain.SetActive(true);
		mShowRulesButton.SetActive(true);
		mShowRulesLogoButton.SetActive(false);
		mBottomPartEnter.gameObject.SetActive(true);
	}

	public void MFENDEBMKIP()
	{
		mRulesTable.MakeEmpty();
		mPooledHeroesGrid.MakeEmpty();
		mPooledRewardsGrid.MakeEmpty();
		mArenaHeroInfo.SetActive(true);
	}

	private void GAKJCJKEJDA(GameObject KHAHPAKDIKE)
	{
		if (!WarArena.instance.isOpened)
		{
			return;
		}
		if (!WarArena.instance.isGoodPing)
		{
			WarningDialog.ShowBadConnection();
			return;
		}
		if (!WarArena.instance.SetupRules())
		{
			GuiElementSingle<CantEnterArenaDialog>.instance.ShowDialog(MIGCGPMDMAB.OBHCLNBEAFD);
			return;
		}
		int wararenaTicketPrize = WarArena.instance.wararenaTicketPrize;
		if (!Singleton<Wallet>.instance.CanBuyTickets(wararenaTicketPrize))
		{
			GuiElementSingle<BuyTicketsDialog>.instance.ShowDialog(wararenaTicketPrize, FLIHNANHKJE.EnterArena, delegate(bool EFBPOCHCGPB)
			{
				if (EFBPOCHCGPB)
				{
					GuiScreenSingle<ArenaScreen>.instance.ShowArena(true);
				}
			});
		}
		else
		{
			mEnterArenaWaiting.SetActive(true);
			DIENNAGJJOM.PNHDGLHLNIE();
		}
	}

	public void ODCHCNCMJGC()
	{
		IFLHDIHOMPN();
		AEPGCPCLEPL();
		GuiScreenSingle<ArenaScreen>.instance.OLGHDNBCJJD(false);
		mRulesTable.MakeEmpty();
		mRulesTable.Initialize(DONAJDGHBDP.Count, GEOEAJGLMFP, FBOJBPACBDC, GPKIBEJOLJE, mDraggableRules);
		mArenaDescription.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.EKEDDPFGPFG);
		MLCJPKJBAHL = WarArena.instance.FPLIPHCJGFO.EOIAFJNEOKL;
		mPooledRewardsGrid.MakeEmpty();
		mPooledRewardsGrid.init(MLCJPKJBAHL.Count, IODKPOICJBI, BAJCBMIMOEB, mDraggableRewards);
		OAKLCBMLKFG();
	}

	private void DKCEMBBEMGM()
	{
		Vector3 positionForIndex = mPooledHeroesGrid.getPositionForIndex(GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition);
		mDraggableHeroes.AlignToCenter(positionForIndex + mPooledHeroesGrid.transform.localPosition, true, null, 814f);
		mPooledHeroesGrid.PositionChanged();
	}

	public void GFJLAFHLFCL()
	{
		mBottomLeftPartMain.SetActive(true);
		mBottomPartMain.SetActive(true);
		mBottomPartEnter.SetActive(true);
		mShowRulesButton.SetActive(true);
		mShowRulesLogoButton.SetActive(true);
		mEnterArenaWaiting.SetActive(true);
		APNODDLOIPD();
	}

	private void OCLKEPAJPAM()
	{
		PAOMHMBHPAL = WarArena.instance.PBGAHILNNAH();
		OEJLIFCEBKJ();
		EFJMPKHFEKC();
		UpdateEnterButtonTitle();
	}

	private static void KGJEEJJJEKA(bool EFBPOCHCGPB)
	{
		if (EFBPOCHCGPB)
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowArena(true);
		}
	}

	private Transform MADMLGBLHFH(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WararenaRewardRecord wararenaRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(mArenaRewardPrefab, mPooledRewardsGrid.gameObject, string.Format("duplicate WB ", DFHAAIFFLOE)) as WararenaRewardRecord;
			if (wararenaRewardRecord != null)
			{
				wararenaRewardRecord.FANFNOPNGBL(MLCJPKJBAHL[DFHAAIFFLOE], WararenaRewardRecord.COLKIFOMJPF.OpenDialog);
				return wararenaRewardRecord.transform;
			}
		}
		return null;
	}

	private void OBFBIDJHJIO()
	{
		Vector3 positionForIndex = mPooledHeroesGrid.getPositionForIndex(GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition);
		mDraggableHeroes.AlignToCenter(positionForIndex + mPooledHeroesGrid.transform.localPosition, true);
		mPooledHeroesGrid.PositionChanged();
	}

	private Transform AHHAGCNANDK(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < BHJIMFDGCGE.Count)
		{
			ArenaHeroRecord arenaHeroRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(mArenaHeroPrefab, mPooledHeroesGrid.gameObject, string.Format("Hero {0:D2}", DFHAAIFFLOE)) as ArenaHeroRecord;
			if (arenaHeroRecord != null)
			{
				arenaHeroRecord.Initialize(DFHAAIFFLOE + 1, BHJIMFDGCGE[DFHAAIFFLOE], BHJIMFDGCGE.Count, (int)ArenaRulesPanelResize.contentWidth);
				return arenaHeroRecord.transform;
			}
		}
		return null;
	}

	public void MPCJHAAACKN()
	{
		mDraggableRules.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight);
		BJALFNBBDDB();
		mDraggableRewards.AlignToPos(true);
	}

	private void PNLMGMLPAMA()
	{
		PAOMHMBHPAL = WarArena.instance.PBGAHILNNAH();
		GMHGNECGNPM();
		BAGJIOHKBJH();
		CLGMDHOCKBI();
	}

	private void FGCCKIKMIIJ(bool HIDPGIGEBIH)
	{
		mEnterArenaWaiting.SetActive(false);
		if (HIDPGIGEBIH)
		{
			GuiScreenSingle<ArenaScreen>.instance.POJGACABEAI(true);
		}
	}

	private Transform MCGMOMMGPGO(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < BHJIMFDGCGE.Count)
		{
			ArenaHeroRecord arenaHeroRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(mArenaHeroPrefab, mPooledHeroesGrid.gameObject, string.Format(" AND ", DFHAAIFFLOE)) as ArenaHeroRecord;
			if (arenaHeroRecord != null)
			{
				arenaHeroRecord.PALKDIAONDP(DFHAAIFFLOE + 0, BHJIMFDGCGE[DFHAAIFFLOE], BHJIMFDGCGE.Count, (int)ArenaRulesPanelResize.LPFBNABOKFP());
				return arenaHeroRecord.transform;
			}
		}
		return null;
	}

	private void GEKMIHNNMAI()
	{
		if (WarArena.instance.wararenaTicketPrize > 0)
		{
			mEnterLogo.gameObject.SetActive(true);
			mEnterPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(WarArena.instance.wararenaTicketPrize);
			float val = 495f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + 424f + mEnterLogo.transform.localScale.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val);
			float val2 = mEnterBorder.transform.localPosition.x - 773f - mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x / 906f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val2);
			float val3 = mEnterPrice.transform.localPosition.x - 224f - (mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + mEnterLogo.transform.localScale.x) / 639f;
			mEnterLogo.transform.localPosition = mEnterLogo.transform.localPosition.ReplaceX(val3);
		}
		else
		{
			mEnterLogo.gameObject.SetActive(false);
			mEnterPrice.text = Localization.Localize("Time_Range");
			float val4 = 1330f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val4);
			float val5 = mEnterBorder.transform.localPosition.x - mEnterBorder.transform.localScale.x / 1433f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val5);
		}
	}

	public void AlignDraggables()
	{
		mDraggableRules.AlignToPos(true);
		OBFBIDJHJIO();
		mDraggableRewards.AlignToPos(true);
	}

	public void OPKJKJPPEDL()
	{
		mDraggableRules.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight);
		GCCKNLIPMJC();
		mDraggableRewards.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight);
	}

	public void UpdateEnterButtonTitle()
	{
		if (MIGCGPMDMAB.PACOBAAJCOK())
		{
			bool isOpened = WarArena.instance.isOpened;
			mEnterLabel.text = MIGCGPMDMAB.LELBKHAECAC();
			MEJMLNDFDBP.COCBCFKJOJE(mEnterLabel, 62f, 20f, (!isOpened) ? 700 : 540);
		}
	}

	private void LDKLHIIGIDI()
	{
		GuiScreenSingle<ArenaScreen>.instance.DFDHCGPMJKN(0);
		if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
		{
			mHeroWaiting.SetActive(true);
			BHJIMFDGCGE = GEKJKNLPJIL.GCOBJEAGAML();
			bool flag = BHJIMFDGCGE != null && BHJIMFDGCGE.Count == 1;
			mArenaHeroInfo.SetActive(flag);
			mPooledHeroesGrid.MakeEmpty();
			if (!flag)
			{
				mPooledHeroesGrid.init(BHJIMFDGCGE.Count, KKDLFKECPNA, EBKEKKDEHCA, mDraggableHeroes);
			}
			mDraggableHeroes.AlignToPos(false, UIDraggablePanel.Alingment.BottomRight, true);
			CKLMBNHDONO();
		}
	}

	private Transform OAIONBPNIGC(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			ArenaRuleRecord arenaRuleRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(mArenaRulePrefab, mRulesTable.gameObject, string.Format("Rule {0:D2}", DFHAAIFFLOE)) as ArenaRuleRecord;
			if (arenaRuleRecord != null)
			{
				arenaRuleRecord.Initialize(DONAJDGHBDP[DFHAAIFFLOE], true, 555, 83);
				return arenaRuleRecord.transform;
			}
		}
		return null;
	}

	public void CLGMDHOCKBI()
	{
		if (MIGCGPMDMAB.PACOBAAJCOK())
		{
			bool isOpened = WarArena.instance.isOpened;
			mEnterLabel.text = MIGCGPMDMAB.LELBKHAECAC();
			MEJMLNDFDBP.COCBCFKJOJE(mEnterLabel, 334f, 150f, (!isOpened) ? 78 : 178);
		}
	}

	public void OCJKOGNLDPI()
	{
		DONAJDGHBDP.Clear();
		BHJIMFDGCGE = null;
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.BOHCNEDIJPE();
			DNDBLHFDJDG = null;
		}
	}

	private Transform MPOECAINKKI(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WararenaRewardRecord wararenaRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(mArenaRewardPrefab, mPooledRewardsGrid.gameObject, string.Format("ID_TOMORROW", DFHAAIFFLOE)) as WararenaRewardRecord;
			if (wararenaRewardRecord != null)
			{
				wararenaRewardRecord.BGFKBPMPJIL(MLCJPKJBAHL[DFHAAIFFLOE], WararenaRewardRecord.COLKIFOMJPF.ChangeUnit);
				return wararenaRewardRecord.transform;
			}
		}
		return null;
	}

	private Transform GEOEAJGLMFP(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			ArenaRuleRecord arenaRuleRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(mArenaRulePrefab, mRulesTable.gameObject, string.Format("ID_ALLTIME", DFHAAIFFLOE)) as ArenaRuleRecord;
			if (arenaRuleRecord != null)
			{
				arenaRuleRecord.Initialize(DONAJDGHBDP[DFHAAIFFLOE], true, 124, 4);
				return arenaRuleRecord.transform;
			}
		}
		return null;
	}

	public void NEINEPJDKCL()
	{
		GEKJKNLPJIL.NKBJMLEBMBH = (Action)Delegate.Combine(GEKJKNLPJIL.NKBJMLEBMBH, new Action(LDKLHIIGIDI));
		UIEventListener uIEventListener = UIEventListener.Get(mArenaEnterButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFCNNODOPEI));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(FGCCKIKMIIJ));
	}

	public void HBCGLCPCEHP()
	{
		if (PAOMHMBHPAL != WarArena.instance.isOpened)
		{
			PNLMGMLPAMA();
			PDBMOFGIKBC();
		}
		if (WarArena.instance.BALABLIGAHK() && !GuiScreenSingle<ArenaScreen>.instance.shouldHaveEnded)
		{
			WarArena.instance.LEGGHEEMAHI();
		}
	}

	private void GMPLLEGIGHH(bool HIDPGIGEBIH)
	{
		mEnterArenaWaiting.SetActive(false);
		if (HIDPGIGEBIH)
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowArena(true);
		}
	}

	private static void OEJJINJCMIN(bool EFBPOCHCGPB)
	{
		if (EFBPOCHCGPB)
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowArena(false);
		}
	}

	public void ResetGUI()
	{
		mRulesTable.MakeEmpty();
		mPooledHeroesGrid.MakeEmpty();
		mPooledRewardsGrid.MakeEmpty();
		mArenaHeroInfo.SetActive(false);
	}

	private static void AGGNKNJJEBC(bool EFBPOCHCGPB)
	{
		if (EFBPOCHCGPB)
		{
			GuiScreenSingle<ArenaScreen>.instance.HENDIDHCOMF(false);
		}
	}

	private void GEPJDCOLAND(Transform ENCEFOOPBMK)
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

	private void GCCKNLIPMJC()
	{
		Vector3 positionForIndex = mPooledHeroesGrid.getPositionForIndex(GuiScreenSingle<ArenaScreen>.instance.FNEBBDBDBLE());
		mDraggableHeroes.AlignToCenter(positionForIndex + mPooledHeroesGrid.transform.localPosition, true, null, 221f);
		mPooledHeroesGrid.PositionChanged();
	}

	private void BKEBIJCMMAF(Transform ENCEFOOPBMK)
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

	private void PCOPAGGBANH()
	{
		GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition = 0;
		if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
		{
			mHeroWaiting.SetActive(false);
			BHJIMFDGCGE = GEKJKNLPJIL.PFMJNDLKBAD();
			bool flag = BHJIMFDGCGE == null || BHJIMFDGCGE.Count == 0;
			mArenaHeroInfo.SetActive(flag);
			mPooledHeroesGrid.MakeEmpty();
			if (!flag)
			{
				mPooledHeroesGrid.init(BHJIMFDGCGE.Count, AHHAGCNANDK, JLNELDOPMCA, mDraggableHeroes);
			}
			mDraggableHeroes.AlignToPos(true);
			OBFBIDJHJIO();
		}
	}

	private void NKPPLOHPLDD(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaHeroRecord component = ENCEFOOPBMK.GetComponent<ArenaHeroRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private void CIOMEGKLFJD()
	{
		GuiScreenSingle<ArenaScreen>.instance.PDFLFAABHGA(0);
		if (GuiScreenSingle<ArenaScreen>.instance.NPFFMLLLDAF())
		{
			mHeroWaiting.SetActive(true);
			BHJIMFDGCGE = GEKJKNLPJIL.PBBHIODHALH();
			bool flag = BHJIMFDGCGE != null && BHJIMFDGCGE.Count == 1;
			mArenaHeroInfo.SetActive(flag);
			mPooledHeroesGrid.MakeEmpty();
			if (!flag)
			{
				mPooledHeroesGrid.init(BHJIMFDGCGE.Count, MCGMOMMGPGO, MDDEDPIFEPM, mDraggableHeroes);
			}
			mDraggableHeroes.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight);
			GCCKNLIPMJC();
		}
	}

	private void LOFCPENNCFA(bool HIDPGIGEBIH)
	{
		mEnterArenaWaiting.SetActive(true);
		if (HIDPGIGEBIH)
		{
			GuiScreenSingle<ArenaScreen>.instance.HENDIDHCOMF(false);
		}
	}

	private void GBLKGPABLOK(GameObject KHAHPAKDIKE)
	{
		if (!WarArena.instance.PBGAHILNNAH())
		{
			return;
		}
		if (!WarArena.instance.ALHNCIONIIL())
		{
			WarningDialog.GGGGDLPGADC();
			return;
		}
		if (!WarArena.instance.SetupRules())
		{
			GuiElementSingle<CantEnterArenaDialog>.instance.KANMLANBLBL(MIGCGPMDMAB.OBHCLNBEAFD);
			return;
		}
		int wararenaTicketPrize = WarArena.instance.wararenaTicketPrize;
		if (!Singleton<Wallet>.instance.CanBuyTickets(wararenaTicketPrize))
		{
			GuiElementSingle<BuyTicketsDialog>.instance.EMBNLMGLNFN(wararenaTicketPrize, FLIHNANHKJE.EnterArena, delegate(bool EFBPOCHCGPB)
			{
				if (EFBPOCHCGPB)
				{
					GuiScreenSingle<ArenaScreen>.instance.ShowArena(true);
				}
			});
		}
		else
		{
			mEnterArenaWaiting.SetActive(true);
			DIENNAGJJOM.NJEFAAOKJHK(1);
		}
	}

	private void BJALFNBBDDB()
	{
		Vector3 positionForIndex = mPooledHeroesGrid.getPositionForIndex(GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition);
		mDraggableHeroes.AlignToCenter(positionForIndex + mPooledHeroesGrid.transform.localPosition, false, null, 1292f);
		mPooledHeroesGrid.PositionChanged();
	}

	private void IHHGHGKGIKM(Transform ENCEFOOPBMK)
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

	private void JBJFNEIMNFN()
	{
		GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition = 1;
		if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
		{
			mHeroWaiting.SetActive(false);
			BHJIMFDGCGE = GEKJKNLPJIL.DOMPEJCGIIF();
			bool flag = BHJIMFDGCGE == null || BHJIMFDGCGE.Count == 1;
			mArenaHeroInfo.SetActive(flag);
			mPooledHeroesGrid.MakeEmpty();
			if (!flag)
			{
				mPooledHeroesGrid.init(BHJIMFDGCGE.Count, AHHAGCNANDK, EBKEKKDEHCA, mDraggableHeroes);
			}
			mDraggableHeroes.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight);
			CKLMBNHDONO();
		}
	}

	private void EBKEKKDEHCA(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaHeroRecord component = ENCEFOOPBMK.GetComponent<ArenaHeroRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private void PCGLBHHHHJA()
	{
		PAOMHMBHPAL = WarArena.instance.PBGAHILNNAH();
		GMHGNECGNPM();
		EFJMPKHFEKC();
		CLGMDHOCKBI();
	}

	private void NLEAEFIMBJO()
	{
		bool isOpened = WarArena.instance.isOpened;
		mArenaEnterButtonReflection.gameObject.SetActive(isOpened);
		mEnterPricePart.SetActive(isOpened);
		mArenaEnterButton.GetComponent<UIButtonScale>().enabled = isOpened;
		mEnterLabel.pivot = UIWidget.Pivot.BottomLeft;
		if (isOpened)
		{
			NEILAOOJAFL();
			int num = 148 - (int)mEnterBorder.transform.localScale.x;
			mEnterLabel.text = Localization.Localize("Reload");
			MEJMLNDFDBP.COCBCFKJOJE(mEnterLabel, 407f, 1300f, num);
			float num2 = 1984f;
			mEnterLabel.transform.localPosition = mEnterLabel.transform.localPosition.ReplaceX(num2 + (float)num / 230f);
		}
		else
		{
			mEnterLabel.transform.localPosition = mEnterLabel.transform.localPosition.ReplaceX(500f);
			if (WarArena.instance.isExpired)
			{
				mEnterLabel.text = Localization.Localize("WENEEDTO");
				MEJMLNDFDBP.COCBCFKJOJE(mEnterLabel, 1056f, 695f, 169);
			}
		}
		mEnterBackground.color = ((!isOpened) ? Colours.gray135 : Colours.white);
	}

	private void BAGJIOHKBJH()
	{
		if (WarArena.instance.wararenaTicketPrize > 0)
		{
			mEnterLogo.gameObject.SetActive(true);
			mEnterPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(WarArena.instance.wararenaTicketPrize);
			float val = 847f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + 1251f + mEnterLogo.transform.localScale.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val);
			float val2 = mEnterBorder.transform.localPosition.x - 952f - mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x / 372f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val2);
			float val3 = mEnterPrice.transform.localPosition.x - 280f - (mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + mEnterLogo.transform.localScale.x) / 700f;
			mEnterLogo.transform.localPosition = mEnterLogo.transform.localPosition.ReplaceX(val3);
		}
		else
		{
			mEnterLogo.gameObject.SetActive(true);
			mEnterPrice.text = Localization.Localize(" ENTRIES: ");
			float val4 = 1348f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val4);
			float val5 = mEnterBorder.transform.localPosition.x - mEnterBorder.transform.localScale.x / 1919f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val5);
		}
	}

	private void PDBMOFGIKBC()
	{
		mArenaHeroesLabel.text = Localization.Localize((!WarArena.instance.PBGAHILNNAH()) ? "key is " : "XP");
		mArenaHeroesEmptyLabel.text = Localization.Localize((!WarArena.instance.PBGAHILNNAH()) ? "ShotFrequencyMaxCannon" : "menu-dailyrewards-vip-ico");
		BHJIMFDGCGE = null;
		mPooledHeroesGrid.MakeEmpty();
		mHeroWaiting.SetActive(true);
		mArenaHeroInfo.SetActive(false);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(mArenaHeroPrefab, mArenaHeroesContent, "Data") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = Vector3.zero;
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 1;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.JJFKFKBCKFL(flag, aGIANFGGNNA, (int)ArenaRulesPanelResize.HCIEHANMAFJ());
		}
		GEKJKNLPJIL.NBGJPOOGMCC();
	}

	private float GPKIBEJOLJE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			LOEEAHOIPKD.Initialize(DONAJDGHBDP[DFHAAIFFLOE], false, -26, 87);
			return NLBJOAJMHLE().KMFGCJEGJJK.transform.localScale.y;
		}
		return 1680f;
	}

	public void APNODDLOIPD()
	{
		mDraggableRules.AlignToPos(false);
		DKCEMBBEMGM();
		mDraggableRewards.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight, true);
	}

	private Transform MMFKBLNGHCP(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			ArenaRuleRecord arenaRuleRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(mArenaRulePrefab, mRulesTable.gameObject, string.Format("Medals", DFHAAIFFLOE)) as ArenaRuleRecord;
			if (arenaRuleRecord != null)
			{
				arenaRuleRecord.LMPNFLGMNBG(DONAJDGHBDP[DFHAAIFFLOE], true, 128, -55);
				return arenaRuleRecord.transform;
			}
		}
		return null;
	}

	private void OEJLIFCEBKJ()
	{
		bool isOpened = WarArena.instance.isOpened;
		mArenaEnterButtonReflection.gameObject.SetActive(isOpened);
		mEnterPricePart.SetActive(isOpened);
		mArenaEnterButton.GetComponent<UIButtonScale>().enabled = isOpened;
		mEnterLabel.pivot = UIWidget.Pivot.Center;
		if (isOpened)
		{
			EFJMPKHFEKC();
			int num = 885 - (int)mEnterBorder.transform.localScale.x;
			mEnterLabel.text = Localization.Localize("ID_ENTERARENA");
			MEJMLNDFDBP.COCBCFKJOJE(mEnterLabel, 62f, 20f, num);
			float num2 = -415f;
			mEnterLabel.transform.localPosition = mEnterLabel.transform.localPosition.ReplaceX(num2 + (float)num / 2f);
		}
		else
		{
			mEnterLabel.transform.localPosition = mEnterLabel.transform.localPosition.ReplaceX(0f);
			if (WarArena.instance.isExpired)
			{
				mEnterLabel.text = Localization.Localize("ID_ARENACLOSED");
				MEJMLNDFDBP.COCBCFKJOJE(mEnterLabel, 62f, 20f, 700);
			}
		}
		mEnterBackground.color = ((!isOpened) ? Colours.gray135 : Colours.white);
	}

	private void FBOJBPACBDC(Transform ENCEFOOPBMK)
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

	private Transform IMIAKJPCEEI(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < BHJIMFDGCGE.Count)
		{
			ArenaHeroRecord arenaHeroRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(mArenaHeroPrefab, mPooledHeroesGrid.gameObject, string.Format("RETRY", DFHAAIFFLOE)) as ArenaHeroRecord;
			if (arenaHeroRecord != null)
			{
				arenaHeroRecord.PALKDIAONDP(DFHAAIFFLOE + 1, BHJIMFDGCGE[DFHAAIFFLOE], BHJIMFDGCGE.Count, (int)ArenaRulesPanelResize.MICFAAKBOKO());
				return arenaHeroRecord.transform;
			}
		}
		return null;
	}

	public void GOENOHDIJOK()
	{
		mBottomLeftPartMain.SetActive(true);
		mBottomPartMain.SetActive(false);
		mShowRulesButton.SetActive(true);
		mShowRulesLogoButton.SetActive(false);
		mBottomPartEnter.gameObject.SetActive(true);
	}

	private void HIHBEGINFLD()
	{
		Vector3 positionForIndex = mPooledHeroesGrid.getPositionForIndex(GuiScreenSingle<ArenaScreen>.instance.FNEBBDBDBLE());
		mDraggableHeroes.AlignToCenter(positionForIndex + mPooledHeroesGrid.transform.localPosition, true, null, 1892f);
		mPooledHeroesGrid.PositionChanged();
	}

	public void InitGUIValues()
	{
		AGBKHJAKEDD();
		GFFFJIJKAKO();
		GuiScreenSingle<ArenaScreen>.instance.FOJGBOPGJFB = false;
		mRulesTable.MakeEmpty();
		mRulesTable.Initialize(DONAJDGHBDP.Count, OAIONBPNIGC, LNDBBOMMNCJ, DJNGFDODCDE, mDraggableRules);
		mArenaDescription.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.EKEDDPFGPFG);
		MLCJPKJBAHL = WarArena.instance.FPLIPHCJGFO.EOIAFJNEOKL;
		mPooledRewardsGrid.MakeEmpty();
		mPooledRewardsGrid.init(MLCJPKJBAHL.Count, IODKPOICJBI, BAJCBMIMOEB, mDraggableRewards);
		NGJCFLOIMPP();
	}

	private float DJMCIJCDMCA(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			EPNDIKKCJFF().Initialize(DONAJDGHBDP[DFHAAIFFLOE], false, 20, 62);
			return EPNDIKKCJFF().KMFGCJEGJJK.transform.localScale.y;
		}
		return 1272f;
	}

	public void PMGHCLOJCFC()
	{
		DONAJDGHBDP.Clear();
		BHJIMFDGCGE = null;
		if (DNDBLHFDJDG != null)
		{
			DNDBLHFDJDG.OBCAIFMOPPA();
			DNDBLHFDJDG = null;
		}
	}

	private Transform ECOJELIJKAH(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < DONAJDGHBDP.Count)
		{
			ArenaRuleRecord arenaRuleRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(mArenaRulePrefab, mRulesTable.gameObject, string.Format("ZA", DFHAAIFFLOE)) as ArenaRuleRecord;
			if (arenaRuleRecord != null)
			{
				arenaRuleRecord.NAKAFGAFEPH(DONAJDGHBDP[DFHAAIFFLOE], true, 46, 5);
				return arenaRuleRecord.transform;
			}
		}
		return null;
	}

	private void EFJMPKHFEKC()
	{
		if (WarArena.instance.wararenaTicketPrize > 0)
		{
			mEnterLogo.gameObject.SetActive(true);
			mEnterPrice.text = MEJMLNDFDBP.GMIPFLIEOHD(WarArena.instance.wararenaTicketPrize);
			float val = 140f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + 15f + mEnterLogo.transform.localScale.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val);
			float val2 = mEnterBorder.transform.localPosition.x - 70f - mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x / 2f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val2);
			float val3 = mEnterPrice.transform.localPosition.x - 15f - (mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + mEnterLogo.transform.localScale.x) / 2f;
			mEnterLogo.transform.localPosition = mEnterLogo.transform.localPosition.ReplaceX(val3);
		}
		else
		{
			mEnterLogo.gameObject.SetActive(false);
			mEnterPrice.text = Localization.Localize("ID_FREE");
			float val4 = 140f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val4);
			float val5 = mEnterBorder.transform.localPosition.x - mEnterBorder.transform.localScale.x / 2f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val5);
		}
	}

	public void AAJLGPIGDED()
	{
		GEKJKNLPJIL.NKBJMLEBMBH = (Action)Delegate.Combine(GEKJKNLPJIL.NKBJMLEBMBH, new Action(LDKLHIIGIDI));
		UIEventListener uIEventListener = UIEventListener.Get(mArenaEnterButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ADOOEEFIKHI));
		DIENNAGJJOM.NKBJMLEBMBH = (Action<bool>)Delegate.Combine(DIENNAGJJOM.NKBJMLEBMBH, new Action<bool>(OGPPBKEPOEA));
	}

	public void HideEnterArena()
	{
		mBottomLeftPartMain.SetActive(true);
		mBottomPartMain.SetActive(true);
		mShowRulesButton.SetActive(true);
		mShowRulesLogoButton.SetActive(true);
		mBottomPartEnter.gameObject.SetActive(false);
	}

	private static void OJNGOMOPDPO(bool EFBPOCHCGPB)
	{
		if (EFBPOCHCGPB)
		{
			GuiScreenSingle<ArenaScreen>.instance.POJGACABEAI(true);
		}
	}

	private void MDDEDPIFEPM(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaHeroRecord component = ENCEFOOPBMK.GetComponent<ArenaHeroRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private void JMFAEKAOGDA()
	{
		mArenaHeroesLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "BS: On add video reward success!" : "reload_grenadelauncher");
		mArenaHeroesEmptyLabel.text = Localization.Localize((!WarArena.instance.PBGAHILNNAH()) ? "Chillingo: On Offers Closed " : "{0} {1}");
		BHJIMFDGCGE = null;
		mPooledHeroesGrid.MakeEmpty();
		mHeroWaiting.SetActive(true);
		mArenaHeroInfo.SetActive(false);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(mArenaHeroPrefab, mArenaHeroesContent, "ID_SQUADEVENT") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = Vector3.zero;
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 1;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.JBIGDBLKNKO(flag, aGIANFGGNNA, (int)ArenaRulesPanelResize.MICFAAKBOKO());
		}
		GEKJKNLPJIL.IIOMKHNPLCG();
	}

	private void JEEBBGOMCMB()
	{
		DONAJDGHBDP = MIGCGPMDMAB.FLNLPCPAAEE;
	}

	public void AIIDBLPOGHN()
	{
		if (PAOMHMBHPAL != WarArena.instance.PBGAHILNNAH())
		{
			OCLKEPAJPAM();
			DDAEMHHNLJG();
		}
		if (WarArena.instance.NHLEKBIHDAL() && !GuiScreenSingle<ArenaScreen>.instance.shouldHaveEnded)
		{
			WarArena.instance.LEGGHEEMAHI();
		}
	}

	private void HCBKBBBPKPC()
	{
		Vector3 positionForIndex = mPooledHeroesGrid.getPositionForIndex(GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition);
		mDraggableHeroes.AlignToCenter(positionForIndex + mPooledHeroesGrid.transform.localPosition, false, null, 1352f);
		mPooledHeroesGrid.PositionChanged();
	}

	private void BLCLPFPJNOB(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			ArenaHeroRecord component = ENCEFOOPBMK.GetComponent<ArenaHeroRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private void CKLMBNHDONO()
	{
		Vector3 positionForIndex = mPooledHeroesGrid.getPositionForIndex(GuiScreenSingle<ArenaScreen>.instance.FNEBBDBDBLE());
		mDraggableHeroes.AlignToCenter(positionForIndex + mPooledHeroesGrid.transform.localPosition, false, null, 779f);
		mPooledHeroesGrid.PositionChanged();
	}

	private void FOANBPKAJAA()
	{
		mArenaHeroesLabel.text = Localization.Localize((!WarArena.instance.PBGAHILNNAH()) ? "1" : "About to show Buy Cards Reminder");
		mArenaHeroesEmptyLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_CONFIRM_SQUADISALREADYFULL" : "ID_GUI_ALLCARDS");
		BHJIMFDGCGE = null;
		mPooledHeroesGrid.MakeEmpty();
		mHeroWaiting.SetActive(true);
		mArenaHeroInfo.SetActive(true);
		if (DNDBLHFDJDG == null)
		{
			DNDBLHFDJDG = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(mArenaHeroPrefab, mArenaHeroesContent, "menu-weaponstats-totalammo") as ArenaHeroRecord;
			DNDBLHFDJDG.transform.localPosition = Vector3.zero;
		}
		if (DNDBLHFDJDG != null)
		{
			bool flag = WarArena.instance.data.flawless > 1;
			int aGIANFGGNNA = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			DNDBLHFDJDG.MGANBMJIDMD(flag, aGIANFGGNNA, (int)ArenaRulesPanelResize.MICFAAKBOKO());
		}
		GEKJKNLPJIL.ACDIBOEKKID();
	}

	private Transform LDPLEDMGBJM(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WararenaRewardRecord wararenaRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(mArenaRewardPrefab, mPooledRewardsGrid.gameObject, string.Format("Wrong player id on squadMember, not leaving squad!", DFHAAIFFLOE)) as WararenaRewardRecord;
			if (wararenaRewardRecord != null)
			{
				wararenaRewardRecord.EPAHIKLPNNB(MLCJPKJBAHL[DFHAAIFFLOE], WararenaRewardRecord.COLKIFOMJPF.OpenDialog);
				return wararenaRewardRecord.transform;
			}
		}
		return null;
	}

	private void BAJCBMIMOEB(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			WararenaRewardRecord component = ENCEFOOPBMK.GetComponent<WararenaRewardRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void LNDBBOMMNCJ(Transform ENCEFOOPBMK)
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

	private static void FHCEMDIGFHC(bool EFBPOCHCGPB)
	{
		if (EFBPOCHCGPB)
		{
			GuiScreenSingle<ArenaScreen>.instance.GBCFGNMLMBE(false);
		}
	}

	[SpecialName]
	private ArenaRuleRecord EPNDIKKCJFF()
	{
		if (CCCAMLIHHOE == null)
		{
			CCCAMLIHHOE = UnityEngine.Object.Instantiate(mArenaRulePrefab);
			CCCAMLIHHOE.transform.parent = base.transform;
			CCCAMLIHHOE.name = "BoughtIndex";
			CCCAMLIHHOE.transform.localPosition = new Vector3(559f, 321f * UIHelper.activeHeight, 730f);
			CCCAMLIHHOE.transform.localScale = Vector3.one;
		}
		return CCCAMLIHHOE;
	}
}
