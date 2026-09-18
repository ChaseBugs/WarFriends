using System;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScreenMainContent : Core_BaseScript
{
	[SerializeField]
	[Header("Nodes")]
	private ArenaGridContent mNodeGrid;

	[Header("Lootboxes")]
	[SerializeField]
	private UIGrid mBoxGrid;

	[SerializeField]
	private ArenaBox mBoxPrefab;

	[SerializeField]
	[Header("Buttons")]
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

	[HideInInspector]
	public bool canBattle = true;

	public List<ArenaBox> boxes = new List<ArenaBox>();

	private ArenaBox mFlawlessBox;

	private bool mLivesChanged;

	public void InitControls()
	{
		for (int i = 0; i < 6; i++)
		{
			ArenaBox arenaBox = UnityEngine.Object.Instantiate(mBoxPrefab);
			arenaBox.transform.parent = mBoxGrid.transform;
			arenaBox.transform.localScale = Vector3.one;
			arenaBox.transform.localPosition = Vector3.zero;
			boxes.Add(arenaBox);
		}
		UIEventListener uIEventListener = UIEventListener.Get(mArenaBattleButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnArenaBattleClick));
		WarArena.instance.LivesChanged += ChangeLives;
	}

	public void InitGUIValues()
	{
		canBattle = true;
		for (int i = 0; i < 6; i++)
		{
			boxes[i].gameObject.SetActive((i <= WarArena.instance.warArenaConfig.lootBoxesCount) ? true : false);
		}
		mFlawlessBox = boxes[WarArena.instance.warArenaConfig.lootBoxesCount];
		SetBattleButton();
	}

	public void SetBattleButton()
	{
		bool flag = WarArena.instance.warArenaConfig.currentWindow != null && WarArena.instance.warArenaConfig.currentWindow.isActive;
		mArenaBattleButtonReflection.gameObject.SetActive(flag);
		if (flag)
		{
			mArenaBattleButtonLabel.text = Localization.Localize("ID_BATTLEINARENA");
			MiscTools.SetUILabelRescale(mArenaBattleButtonLabel, 62f, 20f, 700);
		}
		else if (WarArena.instance.warArenaConfig.isAfterArenaEnd)
		{
			mArenaBattleButtonLabel.text = Localization.Localize("ID_PHASECLOSED");
			MiscTools.SetUILabelRescale(mArenaBattleButtonLabel, 62f, 20f, 700);
		}
		mArenaBattleButton.GetComponent<UIButtonScale>().enabled = flag;
		mArenaBattleButtonBackground.color = ((!flag) ? Colours.gray135 : Colours.white);
	}

	public void UpdateBattleButtonTitle()
	{
		mArenaBattleButtonLabel.text = WarArenaGui.CreateArenaButtonTimeText();
		MiscTools.SetUILabelRescale(mArenaBattleButtonLabel, 62f, 20f, 700);
	}

	private void SetBoxes()
	{
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < WarArena.instance.warArenaConfig.nodes.Count; i++)
		{
			if (WarArena.instance.warArenaConfig.nodes[i].lootBoxType != WarArenaConfig.LootBoxType.None)
			{
				if (i < (int)WarArena.instance.data.wins - 1)
				{
					boxes[num].SetClaimed(isClaimed: true, WarArena.instance.warArenaConfig.nodes[i].lootBoxType);
					num2 = num;
				}
				else
				{
					boxes[num].SetLabels(WarArena.instance.warArenaConfig.nodes[i], i + 1);
				}
				num++;
			}
		}
		num2++;
		mFlawlessBox.SetLabelsFlawless();
		mBoxGrid.cellWidth = (UIRoot.list[0].activeWidth - 120f) / (float)(WarArena.instance.warArenaConfig.lootBoxesCount + 1);
		float val = (0f - UIRoot.list[0].activeWidth + mBoxGrid.cellWidth + 120f) * 0.5f;
		mBoxGrid.transform.localPosition = mBoxGrid.transform.localPosition.ReplaceX(val);
		foreach (ArenaBox box in boxes)
		{
			box.CenterWinCountGrid();
		}
		List<WarArenaConfig.Node> nodes = WarArena.instance.warArenaConfig.nodes;
		if (GuiScreenSingle<ArenaScreen>.instance.haveWon && nodes[(int)WarArena.instance.data.wins - 1].lootBoxType != WarArenaConfig.LootBoxType.None)
		{
			boxes[num2].SetAboutToOpen(nodes[(int)WarArena.instance.data.wins - 1].lootBoxType);
		}
		if (!GuiScreenSingle<ArenaScreen>.instance.haveWon && (int)WarArena.instance.data.wins > 0 && nodes[(int)WarArena.instance.data.wins - 1].lootBoxType != WarArenaConfig.LootBoxType.None)
		{
			boxes[num2].SetClaimed(isClaimed: true, nodes[(int)WarArena.instance.data.wins - 1].lootBoxType);
		}
	}

	public void HideBoxesHints()
	{
		foreach (ArenaBox box in boxes)
		{
			if (box.hintShowed)
			{
				box.ShowHint();
			}
		}
	}

	private void SetLives()
	{
		for (int i = 0; i < mLives.Length; i++)
		{
			bool flag = i < WarArena.instance.warArenaConfig.lifeCount;
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

	private void ChangeLives(int number)
	{
		if (number > 0)
		{
			canBattle = true;
			for (int i = 0; i < (int)WarArena.instance.data.lives; i++)
			{
				mLives[i].SetFull();
			}
			if (GuiScreenSingle<ArenaScreen>.instance.isFullyShowed && GuiScreenSingle<ArenaScreen>.instance.arenaMode == ArenaScreen.ArenaScreenMode.EnterArena)
			{
				GuiScreenSingle<ArenaScreen>.instance.ShowArena(transition: true);
			}
		}
		else if (GuiScreenSingle<ArenaScreen>.instance.isFullyShowed)
		{
			canBattle = false;
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 2)].AnimateHeart();
			mLivesChanged = false;
		}
		else
		{
			mLivesChanged = true;
		}
	}

	public void DoBeforeHide()
	{
		foreach (ArenaBox box in boxes)
		{
			box.arenaLootBox.Hide();
		}
	}

	public void DoAfterShowUp()
	{
		if (GuiScreenSingle<ArenaScreen>.instance.haveWon)
		{
			int max = WarArena.instance.warArenaConfig.battles - 1;
			mNodeGrid.nodes[Mathf.Clamp((int)WarArena.instance.data.wins - 1, 0, max)].AnimateNode();
			Singleton<Wallet>.instance.Init(Singleton<Wallet>.instance.goldAfterArena, Singleton<Wallet>.instance.warbucksAfterArena);
		}
		if (mLivesChanged || GuiScreenSingle<ArenaScreen>.instance.haveLost)
		{
			canBattle = false;
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 2)].AnimateHeart();
			mLivesChanged = false;
			Singleton<Wallet>.instance.Init(Singleton<Wallet>.instance.goldAfterArena, Singleton<Wallet>.instance.warbucksAfterArena);
		}
	}

	public void ClearData()
	{
		foreach (ArenaBox box in boxes)
		{
			box.SetClaimed(isClaimed: false);
		}
		mNodeGrid.Clear();
	}

	private void OnArenaBattleClick(GameObject go)
	{
		if (WarArena.instance.warArenaConfig.currentWindow != null && WarArena.instance.warArenaConfig.currentWindow.isActive && canBattle)
		{
			if (!WarArena.instance.isGoodPing)
			{
				WarningDialog.ShowBadConnection();
				Singleton<EventTrackingManager>.instance.ArenaPoorConnection();
			}
			else if (!WarArena.instance.SetupRules())
			{
				GuiElementSingle<CantEnterArenaDialog>.instance.ShowDialog(WarArenaGui.failSetupRules);
			}
			else
			{
				Debug.Log("Battle Start");
				Singleton<GameController>.instance.SwitchToWarArena();
				Singleton<GameController>.instance.gameControllerWarArena.StartRandomMatchMaking();
			}
		}
	}

	public void AfterAnimation()
	{
		if ((int)WarArena.instance.data.lives > 0)
		{
			canBattle = true;
		}
	}

	public void ShowMainArena()
	{
		SetLives();
		if (mLivesChanged || GuiScreenSingle<ArenaScreen>.instance.haveLost)
		{
			mLives[Mathf.Clamp(WarArena.instance.data.lives, 0, 2)].SetFull();
		}
		mNodeGrid.ResizeNodes(WarArena.instance.warArenaConfig.battles);
		List<WarArenaConfig.Node> nodes = WarArena.instance.warArenaConfig.nodes;
		SetBoxes();
		mNodeGrid.SetRewards(nodes);
		mNodeGrid.SetNodes(completed: true, nodes);
	}
}
