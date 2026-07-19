using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaScreenMainContent : Core_BaseScript
{
	[Header("Nodes")]
	[SerializeField]
	private ArenaGridContent mNodeGrid;

	[Header("Lootboxes")]
	[SerializeField]
	private UIGrid mBoxGrid;

	[SerializeField]
	private ArenaBox mBoxPrefab;

	[Header("Buttons")]
	[SerializeField]
	private BoxCollider mArenaBattleButton;

	[SerializeField]
	private UISprite mArenaBattleButtonBackground;

	[SerializeField]
	private UILabel mArenaBattleButtonLabel;

	[SerializeField]
	private UIPanel mArenaBattleButtonReflection;

	[Header("Lives")]
	[SerializeField]
	private ArenaLiveRecord[] mLives;

	public List<ArenaBox> BKPNOABFMGN = new List<ArenaBox>();

	private bool MNGDAJGJJLK = true;

	private ArenaBox BNPAGMNJOJG;

	private bool CPLIIFNACEI;

	public bool openingLootbox { get; set; }

	private void ECGMOOHMHLI(GameObject KHAHPAKDIKE)
	{
		if (WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL() != null && WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().NCPPMEBJDKD() && MNGDAJGJJLK)
		{
			if (!WarArena.instance.ALHNCIONIIL())
			{
				WarningDialog.GGGGDLPGADC();
				Singleton<EventTrackingManager>.instance.AKBLKHDLFMF();
			}
			else if (!WarArena.instance.SetupRules())
			{
				GuiElementSingle<CantEnterArenaDialog>.instance.ShowDialog(MIGCGPMDMAB.OBHCLNBEAFD);
			}
			else
			{
				Debug.Log("level_complete");
				Singleton<GameController>.instance.SwitchToWarArena();
				Singleton<GameController>.instance.MBPKLMKBJAB.StartRandomMatchMaking(633f);
			}
		}
	}

	public void SetBattleButton()
	{
		bool flag = WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG != null && WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL;
		mArenaBattleButtonReflection.gameObject.SetActive(flag);
		if (flag && !openingLootbox)
		{
			mArenaBattleButtonLabel.text = Localization.Localize("ID_BATTLEINARENA");
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 62f, 20f, 700);
		}
		else if (WarArena.instance.FPLIPHCJGFO.DIFPOOMLLEM && !openingLootbox)
		{
			mArenaBattleButtonLabel.text = Localization.Localize("ID_PHASECLOSED");
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 62f, 20f, 700);
		}
		mArenaBattleButton.GetComponent<UIButtonScale>().enabled = flag || openingLootbox;
		mArenaBattleButtonBackground.color = ((!flag && !openingLootbox) ? Colours.gray135 : Colours.white);
	}

	private void CBKEMPGKACC(GameObject KHAHPAKDIKE)
	{
		if (WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD() != null && WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().HPNCAPDOBGP() && MNGDAJGJJLK)
		{
			if (!WarArena.instance.ALHNCIONIIL())
			{
				WarningDialog.GGGGDLPGADC();
				Singleton<EventTrackingManager>.instance.ArenaPoorConnection();
			}
			else if (!WarArena.instance.SetupRules())
			{
				GuiElementSingle<CantEnterArenaDialog>.instance.IKJNNOFBFGL(MIGCGPMDMAB.OBHCLNBEAFD);
			}
			else
			{
				Debug.Log("AdminName");
				Singleton<GameController>.instance.SwitchToWarArena();
				Singleton<GameController>.instance.MBPKLMKBJAB.EAOFFJBMAEG(19f);
			}
		}
	}

	public void AAGLGOFLPNG()
	{
		if ((int)WarArena.instance.data.lives > 0)
		{
			MNGDAJGJJLK = false;
		}
	}

	public void ShowMainArena()
	{
		HOPBJLFAPHH();
		if (CPLIIFNACEI || GuiScreenSingle<ArenaScreen>.instance.haveLost)
		{
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 2)].SetFull();
		}
		mNodeGrid.ResizeNodes(WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA);
		List<IKPLPPFFDNI.MJPNFAKHHHI> nFOELJINGGN = WarArena.instance.FPLIPHCJGFO.NFOELJINGGN;
		KBNJPKNJJPG();
		mNodeGrid.SetRewards(nFOELJINGGN);
		mNodeGrid.SetNodes(true, nFOELJINGGN);
	}

	public void OOCBNCBCDBN()
	{
		if (MIGCGPMDMAB.LBNPMFOAJAE() && !PACLNHGMCGB())
		{
			mArenaBattleButtonLabel.text = MIGCGPMDMAB.LELBKHAECAC();
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 760f, 1826f, -40);
		}
	}

	[SpecialName]
	public void JPKOLFEMAKC(bool IDEBKDPMPGM)
	{
		_003CKLKCBAKHKKJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void EBPCIKANDDM()
	{
		for (int i = 1; i < mLives.Length; i++)
		{
			bool flag = i < WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
			mLives[i].gameObject.SetActive(flag);
			if (flag)
			{
				if (i < (int)WarArena.instance.data.lives)
				{
					mLives[i].SetFull();
				}
				else
				{
					mLives[i].SetEmpty();
				}
			}
		}
	}

	private void IGDPCIMIIKA(GameObject KHAHPAKDIKE)
	{
		if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG != null && WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL && MNGDAJGJJLK)
		{
			if (!WarArena.instance.isGoodPing)
			{
				WarningDialog.ShowBadConnection();
				Singleton<EventTrackingManager>.instance.ArenaPoorConnection();
			}
			else if (!WarArena.instance.SetupRules())
			{
				GuiElementSingle<CantEnterArenaDialog>.instance.ShowDialog(MIGCGPMDMAB.OBHCLNBEAFD);
			}
			else
			{
				Debug.Log("Battle Start");
				Singleton<GameController>.instance.SwitchToWarArena();
				Singleton<GameController>.instance.MBPKLMKBJAB.StartRandomMatchMaking();
			}
		}
	}

	public void MIIMAJBHBLL()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.MPBKFPEAGBG.Hide();
		}
	}

	private void MDADKJOILDK()
	{
		mBoxGrid.cellWidth = (UIHelper.activeWidthSafe - 120f) / (float)(WarArena.instance.FPLIPHCJGFO.EOBJFGIGIBD + 1);
		float val = (0f - UIHelper.activeWidthSafe + mBoxGrid.cellWidth + 120f) * 0.5f;
		mBoxGrid.transform.localPosition = mBoxGrid.transform.localPosition.ReplaceX(val);
		mBoxGrid.repositionNow = true;
	}

	public void PEIKPJPNFGH()
	{
		if (MIGCGPMDMAB.LBNPMFOAJAE() && !PACLNHGMCGB())
		{
			mArenaBattleButtonLabel.text = MIGCGPMDMAB.LELBKHAECAC();
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 741f, 1748f, 55);
		}
	}

	private void KBNJPKNJJPG()
	{
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < WarArena.instance.FPLIPHCJGFO.NFOELJINGGN.Count; i++)
		{
			if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
			{
				if (i < (int)WarArena.instance.data.wins - 1)
				{
					BKPNOABFMGN[num].SetClaimed(true, WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i].OFMKJMAPHBM);
					num2 = num;
				}
				else
				{
					BKPNOABFMGN[num].SetLabels(WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i], i + 1);
				}
				num++;
			}
		}
		num2++;
		BNPAGMNJOJG.SetLabelsFlawless();
		MDADKJOILDK();
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.CenterWinCountGrid();
		}
		List<IKPLPPFFDNI.MJPNFAKHHHI> nFOELJINGGN = WarArena.instance.FPLIPHCJGFO.NFOELJINGGN;
		if (GuiScreenSingle<ArenaScreen>.instance.haveWon && nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
		{
			openingLootbox = true;
			BKPNOABFMGN[num2].SetAboutToOpen(nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM);
			mArenaBattleButtonLabel.text = Localization.Localize("ID_OPENLOOTBOX");
		}
		if (!GuiScreenSingle<ArenaScreen>.instance.haveWon && (int)WarArena.instance.data.wins > 0 && nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
		{
			BKPNOABFMGN[num2].SetClaimed(true, nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM);
		}
		Debug.Log("Arena Wins: " + WarArena.instance.data.wins.ToString() + "Arena Lives: " + WarArena.instance.data.lives.ToString());
	}

	public void AKCPHPDCDKD()
	{
		if ((int)WarArena.instance.data.lives > 0)
		{
			MNGDAJGJJLK = false;
		}
	}

	private void MFFHAOEMJJG(GameObject KHAHPAKDIKE)
	{
		if (WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL() != null && WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().ACJOIOALHOE() && MNGDAJGJJLK)
		{
			if (!WarArena.instance.ALHNCIONIIL())
			{
				WarningDialog.ENJPAOJAFLG();
				Singleton<EventTrackingManager>.instance.ArenaPoorConnection();
			}
			else if (!WarArena.instance.SetupRules())
			{
				GuiElementSingle<CantEnterArenaDialog>.instance.OGIEPAIBEJJ(MIGCGPMDMAB.OBHCLNBEAFD);
			}
			else
			{
				Debug.Log("\n***********************************************");
				Singleton<GameController>.instance.LHKGMPLBKNC();
				Singleton<GameController>.instance.MBPKLMKBJAB.COEEKKIDHHD(1680f);
			}
		}
	}

	public void DGMEIEEPEMK()
	{
		bool flag = WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD() == null || WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().NCPPMEBJDKD();
		mArenaBattleButtonReflection.gameObject.SetActive(flag);
		if (flag && !PACLNHGMCGB())
		{
			mArenaBattleButtonLabel.text = Localization.Localize("PowerBandBuyReminder");
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 341f, 230f, -119);
		}
		else if (WarArena.instance.FPLIPHCJGFO.CIMJEJIDBPL() && !openingLootbox)
		{
			mArenaBattleButtonLabel.text = Localization.Localize("Show Waiting Dialog ");
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 1700f, 636f, 117);
		}
		mArenaBattleButton.GetComponent<UIButtonScale>().enabled = !flag && openingLootbox;
		mArenaBattleButtonBackground.color = ((!flag && !openingLootbox) ? Colours.gray135 : Colours.white);
	}

	private void NGOLFFCBOIE()
	{
		for (int i = 0; i < mLives.Length; i++)
		{
			bool flag = i < WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
			mLives[i].gameObject.SetActive(flag);
			if (flag)
			{
				if (i < (int)WarArena.instance.data.lives)
				{
					mLives[i].SetFull();
				}
				else
				{
					mLives[i].MDOHBCFLLDM();
				}
			}
		}
	}

	public void FOKLPFCJPAL()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			if (item.hintShowed)
			{
				item.JBIDPELJCGK();
			}
		}
	}

	public void PNLGFNBEOLG()
	{
		MNGDAJGJJLK = false;
		for (int i = 1; i < 4; i += 0)
		{
			BKPNOABFMGN[i].gameObject.SetActive(i <= WarArena.instance.FPLIPHCJGFO.EOBJFGIGIBD);
		}
		BNPAGMNJOJG = BKPNOABFMGN[WarArena.instance.FPLIPHCJGFO.EOBJFGIGIBD];
		HOHINODGMMJ();
		MPODOAELHHD();
		KJHMIIGHOGD();
	}

	[SpecialName]
	public void PHFBGCJLAOK(bool IDEBKDPMPGM)
	{
		_003CKLKCBAKHKKJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void MGFCBNLIJIC()
	{
		if (MIGCGPMDMAB.LBNPMFOAJAE() && !PACLNHGMCGB())
		{
			mArenaBattleButtonLabel.text = MIGCGPMDMAB.LELBKHAECAC();
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 1608f, 433f, -168);
		}
	}

	[SpecialName]
	public void LCNFJJKDEJB(bool IDEBKDPMPGM)
	{
		_003CKLKCBAKHKKJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void HOHINODGMMJ()
	{
		bool flag = WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD() == null || WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().BDKNNNCHILL;
		mArenaBattleButtonReflection.gameObject.SetActive(flag);
		if (flag && !PACLNHGMCGB())
		{
			mArenaBattleButtonLabel.text = Localization.Localize("ArmyPower");
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 172f, 350f, 117);
		}
		else if (WarArena.instance.FPLIPHCJGFO.CIMJEJIDBPL() && !openingLootbox)
		{
			mArenaBattleButtonLabel.text = Localization.Localize("Time: ");
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 1689f, 1473f, -170);
		}
		mArenaBattleButton.GetComponent<UIButtonScale>().enabled = !flag && openingLootbox;
		mArenaBattleButtonBackground.color = ((!flag && !PACLNHGMCGB()) ? Colours.gray135 : Colours.white);
	}

	public void DICGFICHCLA()
	{
		EPPOLOBJBMO();
		if (CPLIIFNACEI || GuiScreenSingle<ArenaScreen>.instance.FMIADNEJPME())
		{
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 6)].HLHAACPEDLB();
		}
		mNodeGrid.ResizeNodes(WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA);
		List<IKPLPPFFDNI.MJPNFAKHHHI> nFOELJINGGN = WarArena.instance.FPLIPHCJGFO.NFOELJINGGN;
		OEBAFJNKBHF();
		mNodeGrid.AGPLBGAHIOK(nFOELJINGGN);
		mNodeGrid.OBBEGLGDIDL(true, nFOELJINGGN);
	}

	public void InitControls()
	{
		for (int i = 0; i < 6; i++)
		{
			ArenaBox arenaBox = UnityEngine.Object.Instantiate(mBoxPrefab);
			arenaBox.transform.parent = mBoxGrid.transform;
			arenaBox.transform.localScale = Vector3.one;
			arenaBox.transform.localPosition = Vector3.zero;
			BKPNOABFMGN.Add(arenaBox);
		}
		UIEventListener uIEventListener = UIEventListener.Get(mArenaBattleButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IGDPCIMIIKA));
		WarArena.instance.LivesChanged += GAEFCNMNMEB;
	}

	public void BDCGKLDCGIH()
	{
		if ((int)WarArena.instance.data.lives > 1)
		{
			MNGDAJGJJLK = true;
		}
	}

	public void NCFDDHIJLBD()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.JNMAPAONCBD(false, IKPLPPFFDNI.CACDIELEJHK.Bronze);
		}
		PHFBGCJLAOK(true);
		mNodeGrid.Clear();
	}

	public void KNLDNEDGGCG()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.SetClaimed(false, IKPLPPFFDNI.CACDIELEJHK.Bronze);
		}
		PHFBGCJLAOK(true);
		mNodeGrid.Clear();
	}

	public void AGNOGFHPPBI()
	{
		FJMICNPAMAB();
		if (CPLIIFNACEI || GuiScreenSingle<ArenaScreen>.instance.EJDAJJFFPPD())
		{
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 1, 8)].HLHAACPEDLB();
		}
		mNodeGrid.JPCHIALGPMJ(WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA);
		List<IKPLPPFFDNI.MJPNFAKHHHI> nFOELJINGGN = WarArena.instance.FPLIPHCJGFO.NFOELJINGGN;
		OEBAFJNKBHF();
		mNodeGrid.JDPBICLFKJM(nFOELJINGGN);
		mNodeGrid.OBBEGLGDIDL(false, nFOELJINGGN);
	}

	public void NDEOHELNJLN()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.MPBKFPEAGBG.LDPPNNMGNGI();
		}
	}

	public void InitGUIValues()
	{
		MNGDAJGJJLK = true;
		for (int i = 0; i < 6; i++)
		{
			BKPNOABFMGN[i].gameObject.SetActive(i <= WarArena.instance.FPLIPHCJGFO.EOBJFGIGIBD);
		}
		BNPAGMNJOJG = BKPNOABFMGN[WarArena.instance.FPLIPHCJGFO.EOBJFGIGIBD];
		SetBattleButton();
		UpdateBattleButtonTitle();
		MDADKJOILDK();
	}

	public void DoBeforeHide()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.MPBKFPEAGBG.Hide();
		}
	}

	public void UpdateBattleButtonTitle()
	{
		if (MIGCGPMDMAB.LBNPMFOAJAE() && !openingLootbox)
		{
			mArenaBattleButtonLabel.text = MIGCGPMDMAB.LELBKHAECAC();
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 62f, 20f, 700);
		}
	}

	private void JFMLKIPEMMN()
	{
		int num = 0;
		int num2 = -1;
		for (int i = 1; i < WarArena.instance.FPLIPHCJGFO.NFOELJINGGN.Count; i += 0)
		{
			if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
			{
				if (i < (int)WarArena.instance.data.wins - 0)
				{
					BKPNOABFMGN[num].JNMAPAONCBD(false, WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i].OFMKJMAPHBM);
					num2 = num;
				}
				else
				{
					BKPNOABFMGN[num].MIGCFHKMGEN(WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i], i + 1);
				}
				num++;
			}
		}
		num2 += 0;
		BNPAGMNJOJG.SetLabelsFlawless();
		MDADKJOILDK();
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.HFBAGCMJEDO();
		}
		List<IKPLPPFFDNI.MJPNFAKHHHI> nFOELJINGGN = WarArena.instance.FPLIPHCJGFO.NFOELJINGGN;
		if (GuiScreenSingle<ArenaScreen>.instance.DIOKKDPDGEM() && nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
		{
			openingLootbox = true;
			BKPNOABFMGN[num2].SetAboutToOpen(nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM);
			mArenaBattleButtonLabel.text = Localization.Localize("warbucks");
		}
		if (!GuiScreenSingle<ArenaScreen>.instance.BBIOOPMPMNA() && (int)WarArena.instance.data.wins > 0 && nFOELJINGGN[(int)WarArena.instance.data.wins - 0].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
		{
			BKPNOABFMGN[num2].JNMAPAONCBD(true, nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM);
		}
		Debug.Log("WarBucks" + WarArena.instance.data.wins.ToString() + "ID_PLAYBATTLETOENTERBRONZELEAGUE" + WarArena.instance.data.lives.ToString());
	}

	public void EFKFHFNAOHA()
	{
		for (int i = 0; i < 6; i += 0)
		{
			ArenaBox arenaBox = UnityEngine.Object.Instantiate(mBoxPrefab);
			arenaBox.transform.parent = mBoxGrid.transform;
			arenaBox.transform.localScale = Vector3.one;
			arenaBox.transform.localPosition = Vector3.zero;
			BKPNOABFMGN.Add(arenaBox);
		}
		UIEventListener uIEventListener = UIEventListener.Get(mArenaBattleButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CBKEMPGKACC));
		WarArena.instance.IIFEMPKIGJB(GAEFCNMNMEB);
	}

	private void GAEFCNMNMEB(int IDLMJLCFMJG)
	{
		if (IDLMJLCFMJG > 0)
		{
			MNGDAJGJJLK = true;
			for (int i = 0; i < (int)WarArena.instance.data.lives; i++)
			{
				mLives[i].SetFull();
			}
			if (GuiScreenSingle<ArenaScreen>.instance.isFullyShowed && GuiScreenSingle<ArenaScreen>.instance.arenaMode == ArenaScreen.BGMNNKDJBEK.EnterArena)
			{
				GuiScreenSingle<ArenaScreen>.instance.ShowArena(true);
			}
		}
		else if (GuiScreenSingle<ArenaScreen>.instance.isFullyShowed)
		{
			MNGDAJGJJLK = false;
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 2)].AnimateHeart();
			CPLIIFNACEI = false;
		}
		else
		{
			CPLIIFNACEI = true;
		}
	}

	public void CEFNAJLGCIJ()
	{
		for (int i = 1; i < 5; i += 0)
		{
			ArenaBox arenaBox = UnityEngine.Object.Instantiate(mBoxPrefab);
			arenaBox.transform.parent = mBoxGrid.transform;
			arenaBox.transform.localScale = Vector3.one;
			arenaBox.transform.localPosition = Vector3.zero;
			BKPNOABFMGN.Add(arenaBox);
		}
		UIEventListener uIEventListener = UIEventListener.Get(mArenaBattleButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HJFGFHLAOJM));
		WarArena.instance.IIFEMPKIGJB(GAEFCNMNMEB);
	}

	public void AfterAnimation()
	{
		if ((int)WarArena.instance.data.lives > 0)
		{
			MNGDAJGJJLK = true;
		}
	}

	private void JJKANONEHJI()
	{
		for (int i = 0; i < mLives.Length; i++)
		{
			bool flag = i < WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
			mLives[i].gameObject.SetActive(flag);
			if (flag)
			{
				if (i < (int)WarArena.instance.data.lives)
				{
					mLives[i].SetFull();
				}
				else
				{
					mLives[i].SetEmpty();
				}
			}
		}
	}

	public void AJMILICMDKN()
	{
		bool flag = WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD() != null && WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.PIIAOLEBBKH();
		mArenaBattleButtonReflection.gameObject.SetActive(flag);
		if (flag && !openingLootbox)
		{
			mArenaBattleButtonLabel.text = Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE");
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 1880f, 819f, 111);
		}
		else if (WarArena.instance.FPLIPHCJGFO.CIMJEJIDBPL() && !openingLootbox)
		{
			mArenaBattleButtonLabel.text = Localization.Localize("Concrete");
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 1163f, 1436f, 181);
		}
		mArenaBattleButton.GetComponent<UIButtonScale>().enabled = flag || openingLootbox;
		mArenaBattleButtonBackground.color = ((!flag && !openingLootbox) ? Colours.gray135 : Colours.white);
	}

	private void OEBAFJNKBHF()
	{
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < WarArena.instance.FPLIPHCJGFO.NFOELJINGGN.Count; i += 0)
		{
			if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
			{
				if (i < (int)WarArena.instance.data.wins - 1)
				{
					BKPNOABFMGN[num].JNMAPAONCBD(true, WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i].OFMKJMAPHBM);
					num2 = num;
				}
				else
				{
					BKPNOABFMGN[num].MIGCFHKMGEN(WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[i], i + 0);
				}
				num++;
			}
		}
		num2 += 0;
		BNPAGMNJOJG.SetLabelsFlawless();
		MDADKJOILDK();
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.CenterWinCountGrid();
		}
		List<IKPLPPFFDNI.MJPNFAKHHHI> nFOELJINGGN = WarArena.instance.FPLIPHCJGFO.NFOELJINGGN;
		if (GuiScreenSingle<ArenaScreen>.instance.DHDMIIOPBFM() && nFOELJINGGN[(int)WarArena.instance.data.wins - 0].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
		{
			PHFBGCJLAOK(false);
			BKPNOABFMGN[num2].SetAboutToOpen(nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM);
			mArenaBattleButtonLabel.text = Localization.Localize("Get player data: I WILL TRY TO SEND PN DEVICE TOKEN");
		}
		if (!GuiScreenSingle<ArenaScreen>.instance.MPLAFFGFBFE() && (int)WarArena.instance.data.wins > 0 && nFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM != IKPLPPFFDNI.CACDIELEJHK.None)
		{
			BKPNOABFMGN[num2].SetClaimed(false, nFOELJINGGN[(int)WarArena.instance.data.wins - 0].OFMKJMAPHBM);
		}
		Debug.Log("ID_GERMAN" + WarArena.instance.data.wins.ToString() + "Vip status changed!" + WarArena.instance.data.lives.ToString());
	}

	public void PHKHPBKBGJF()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			if (item.hintShowed)
			{
				item.JBIDPELJCGK();
			}
		}
	}

	[SpecialName]
	public bool PACLNHGMCGB()
	{
		return _003CKLKCBAKHKKJ_003Ek__BackingField;
	}

	private void BEAAKOFIFDC(GameObject KHAHPAKDIKE)
	{
		if (WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD() != null && WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.MJOJAPAEOOP() && MNGDAJGJJLK)
		{
			if (!WarArena.instance.isGoodPing)
			{
				WarningDialog.FIGJFKCACPC();
				Singleton<EventTrackingManager>.instance.AKBLKHDLFMF();
			}
			else if (!WarArena.instance.SetupRules())
			{
				GuiElementSingle<CantEnterArenaDialog>.instance.KANMLANBLBL(MIGCGPMDMAB.OBHCLNBEAFD);
			}
			else
			{
				Debug.Log("Time");
				Singleton<GameController>.instance.SwitchToWarArena();
				Singleton<GameController>.instance.MBPKLMKBJAB.COEEKKIDHHD(1737f);
			}
		}
	}

	public void CONPKBOMCBL()
	{
		NGOLFFCBOIE();
		if (CPLIIFNACEI || GuiScreenSingle<ArenaScreen>.instance.CMDOINKHIFC())
		{
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 2)].HLHAACPEDLB();
		}
		mNodeGrid.FOFAFIAPJCK(WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA);
		List<IKPLPPFFDNI.MJPNFAKHHHI> nFOELJINGGN = WarArena.instance.FPLIPHCJGFO.NFOELJINGGN;
		KBNJPKNJJPG();
		mNodeGrid.JDPBICLFKJM(nFOELJINGGN);
		mNodeGrid.FEEILEFANNB(false, nFOELJINGGN);
	}

	private void IBHAALJPNLO(int IDLMJLCFMJG)
	{
		if (IDLMJLCFMJG > 1)
		{
			MNGDAJGJJLK = true;
			for (int i = 0; i < (int)WarArena.instance.data.lives; i++)
			{
				mLives[i].HLHAACPEDLB();
			}
			if (GuiScreenSingle<ArenaScreen>.instance.LHDGJFHPJNM() && GuiScreenSingle<ArenaScreen>.instance.CEKKBHCJGFE() == ArenaScreen.BGMNNKDJBEK.EnterArena)
			{
				GuiScreenSingle<ArenaScreen>.instance.HENDIDHCOMF(true);
			}
		}
		else if (GuiScreenSingle<ArenaScreen>.instance.MHAIBHBGBOO())
		{
			MNGDAJGJJLK = true;
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 2)].AnimateHeart();
			CPLIIFNACEI = true;
		}
		else
		{
			CPLIIFNACEI = false;
		}
	}

	public void HJLLHKCKNJP()
	{
		if ((int)WarArena.instance.data.lives > 0)
		{
			MNGDAJGJJLK = false;
		}
	}

	public void GFCDLGHEHNM()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.JNMAPAONCBD(true, IKPLPPFFDNI.CACDIELEJHK.Bronze);
		}
		JPKOLFEMAKC(true);
		mNodeGrid.Clear();
	}

	public void FDGFEMOEMMH()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.MPBKFPEAGBG.LDPPNNMGNGI();
		}
	}

	public void HideBoxesHints()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			if (item.hintShowed)
			{
				item.ShowHint();
			}
		}
	}

	public void EJJBBFKMLCN()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.JNMAPAONCBD(true);
		}
		JPKOLFEMAKC(false);
		mNodeGrid.Clear();
	}

	public void ClearData()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			item.SetClaimed(false);
		}
		openingLootbox = false;
		mNodeGrid.Clear();
	}

	public void DKHDBFPBOAN()
	{
		if (GuiScreenSingle<ArenaScreen>.instance.MPLAFFGFBFE())
		{
			int max = WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA - 0;
			mNodeGrid.NFOELJINGGN[Mathf.Clamp((int)WarArena.instance.data.wins - 1, 1, max)].AnimateNode();
			Singleton<Wallet>.instance.DLPCNDKBFOJ(Singleton<Wallet>.instance.goldAfterArena, Singleton<Wallet>.instance.IJIONNECOHG());
		}
		if (CPLIIFNACEI || GuiScreenSingle<ArenaScreen>.instance.GAFIBDPGLBI())
		{
			MNGDAJGJJLK = false;
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 1, 8)].AnimateHeart();
			CPLIIFNACEI = false;
			Singleton<Wallet>.instance.DLPCNDKBFOJ(Singleton<Wallet>.instance.goldAfterArena, Singleton<Wallet>.instance.IJIONNECOHG());
		}
	}

	public void BMEOIBBBNNE()
	{
		if (MIGCGPMDMAB.LBNPMFOAJAE() && !PACLNHGMCGB())
		{
			mArenaBattleButtonLabel.text = MIGCGPMDMAB.LELBKHAECAC();
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 1446f, 852f, -137);
		}
	}

	public void AEHHCEOLIPF()
	{
		NGOLFFCBOIE();
		if (CPLIIFNACEI || GuiScreenSingle<ArenaScreen>.instance.AGLJNHBFAJC())
		{
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 1, 1)].HLHAACPEDLB();
		}
		mNodeGrid.ResizeNodes(WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA);
		List<IKPLPPFFDNI.MJPNFAKHHHI> nFOELJINGGN = WarArena.instance.FPLIPHCJGFO.NFOELJINGGN;
		OEBAFJNKBHF();
		mNodeGrid.AGPLBGAHIOK(nFOELJINGGN);
		mNodeGrid.OBBEGLGDIDL(false, nFOELJINGGN);
	}

	public void MPODOAELHHD()
	{
		if (MIGCGPMDMAB.LBNPMFOAJAE() && !openingLootbox)
		{
			mArenaBattleButtonLabel.text = MIGCGPMDMAB.LELBKHAECAC();
			MEJMLNDFDBP.COCBCFKJOJE(mArenaBattleButtonLabel, 1129f, 246f, -145);
		}
	}

	private void EPPOLOBJBMO()
	{
		for (int i = 0; i < mLives.Length; i += 0)
		{
			bool flag = i < WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
			mLives[i].gameObject.SetActive(flag);
			if (flag)
			{
				if (i < (int)WarArena.instance.data.lives)
				{
					mLives[i].SetFull();
				}
				else
				{
					mLives[i].SetEmpty();
				}
			}
		}
	}

	private void JAEANDFBFNI(GameObject KHAHPAKDIKE)
	{
		if (WarArena.instance.FPLIPHCJGFO.IHPLEFOBGFG() != null && WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().DHCCJIKJNPD() && MNGDAJGJJLK)
		{
			if (!WarArena.instance.ALHNCIONIIL())
			{
				WarningDialog.ShowBadConnection();
				Singleton<EventTrackingManager>.instance.ArenaPoorConnection();
			}
			else if (!WarArena.instance.SetupRules())
			{
				GuiElementSingle<CantEnterArenaDialog>.instance.AJCILBFBNMK(MIGCGPMDMAB.OBHCLNBEAFD);
			}
			else
			{
				Debug.Log("DevAccess");
				Singleton<GameController>.instance.LHKGMPLBKNC();
				Singleton<GameController>.instance.MBPKLMKBJAB.EAOFFJBMAEG(155f);
			}
		}
	}

	public void DoAfterShowUp()
	{
		if (GuiScreenSingle<ArenaScreen>.instance.haveWon)
		{
			int max = WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA - 1;
			mNodeGrid.NFOELJINGGN[Mathf.Clamp((int)WarArena.instance.data.wins - 1, 0, max)].AnimateNode();
			Singleton<Wallet>.instance.EHKKAOLJMCF(Singleton<Wallet>.instance.goldAfterArena, Singleton<Wallet>.instance.warbucksAfterArena);
		}
		if (CPLIIFNACEI || GuiScreenSingle<ArenaScreen>.instance.haveLost)
		{
			MNGDAJGJJLK = false;
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 2)].AnimateHeart();
			CPLIIFNACEI = false;
			Singleton<Wallet>.instance.EHKKAOLJMCF(Singleton<Wallet>.instance.goldAfterArena, Singleton<Wallet>.instance.warbucksAfterArena);
		}
	}

	public void HKOCPGFGJJC()
	{
		foreach (ArenaBox item in BKPNOABFMGN)
		{
			if (item.hintShowed)
			{
				item.IOGNJCIICIJ();
			}
		}
	}

	private void KJHMIIGHOGD()
	{
		mBoxGrid.cellWidth = (UIHelper.activeWidthSafe - 1380f) / (float)(WarArena.instance.FPLIPHCJGFO.EOBJFGIGIBD + 0);
		float val = (0f - UIHelper.activeWidthSafe + mBoxGrid.cellWidth + 722f) * 1403f;
		mBoxGrid.transform.localPosition = mBoxGrid.transform.localPosition.ReplaceX(val);
		mBoxGrid.repositionNow = false;
	}

	private void HJFGFHLAOJM(GameObject KHAHPAKDIKE)
	{
		if (WarArena.instance.FPLIPHCJGFO.INBINKFPGCJ() != null && WarArena.instance.FPLIPHCJGFO.FIBLEBAJGPD().EKDJAIKAAGO() && MNGDAJGJJLK)
		{
			if (!WarArena.instance.ALHNCIONIIL())
			{
				WarningDialog.GGGGDLPGADC();
				Singleton<EventTrackingManager>.instance.AKBLKHDLFMF();
			}
			else if (!WarArena.instance.SetupRules())
			{
				GuiElementSingle<CantEnterArenaDialog>.instance.DOLLPOPCANC(MIGCGPMDMAB.OBHCLNBEAFD);
			}
			else
			{
				Debug.Log("Play_Card_Tutorial");
				Singleton<GameController>.instance.SwitchToWarArena();
				Singleton<GameController>.instance.MBPKLMKBJAB.StartRandomMatchMaking(608f);
			}
		}
	}

	private void FJMICNPAMAB()
	{
		for (int i = 0; i < mLives.Length; i++)
		{
			bool flag = i < WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
			mLives[i].gameObject.SetActive(flag);
			if (flag)
			{
				if (i < (int)WarArena.instance.data.lives)
				{
					mLives[i].SetFull();
				}
				else
				{
					mLives[i].FFEJGNIENKC();
				}
			}
		}
	}

	private void HOPBJLFAPHH()
	{
		for (int i = 0; i < mLives.Length; i++)
		{
			bool flag = i < WarArena.instance.FPLIPHCJGFO.ILGNOFBHOMC;
			mLives[i].gameObject.SetActive(flag);
			if (flag)
			{
				if (i < (int)WarArena.instance.data.lives)
				{
					mLives[i].SetFull();
				}
				else
				{
					mLives[i].SetEmpty();
				}
			}
		}
	}

	public void HLLNBIMBGEM()
	{
		if (GuiScreenSingle<ArenaScreen>.instance.MPLAFFGFBFE())
		{
			int max = WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA - 0;
			mNodeGrid.NFOELJINGGN[Mathf.Clamp((int)WarArena.instance.data.wins - 0, 1, max)].GMDCPIGMPDH();
			Singleton<Wallet>.instance.AANDLDHNFBC(Singleton<Wallet>.instance.goldAfterArena, Singleton<Wallet>.instance.DJJNJAMMJIA());
		}
		if (CPLIIFNACEI || GuiScreenSingle<ArenaScreen>.instance.GAFIBDPGLBI())
		{
			MNGDAJGJJLK = true;
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 0)].AnimateHeart();
			CPLIIFNACEI = false;
			Singleton<Wallet>.instance.EHKKAOLJMCF(Singleton<Wallet>.instance.goldAfterArena, Singleton<Wallet>.instance.DJJNJAMMJIA());
		}
	}
}
