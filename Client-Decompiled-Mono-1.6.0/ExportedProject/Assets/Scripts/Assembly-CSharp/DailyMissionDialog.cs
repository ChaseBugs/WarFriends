using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DailyMissionDialog : GuiElementSingle<DailyMissionDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Header")]
	private GameObject mCloseButton;

	[SerializeField]
	private UILabel mMissionTitle;

	[SerializeField]
	[Header("Middle")]
	private GameObject mSoloIcon;

	[SerializeField]
	private GameObject mCoopIcon;

	[SerializeField]
	private GameObject mHeroicIcon;

	[SerializeField]
	private UILabel mMissionTask;

	[SerializeField]
	[Header("- Mission Rewards")]
	private UILabel mMissionRewardsLabel;

	[SerializeField]
	private List<DailyMissionRewardRecord> mMissionRewards;

	[Header("- Mission Enemies")]
	[SerializeField]
	private MissionEnemyRecord mMissionEnemiesRecordPrefab;

	[SerializeField]
	private UIDraggablePanel mDraggableEnemies;

	[SerializeField]
	private UIPooledGrid mPooledEnemiesGrid;

	[Header("Bottom Buttons")]
	[SerializeField]
	private GameObject mPlayButton;

	[SerializeField]
	private GameObject mPlayCoop;

	[SerializeField]
	private GameObject mPlayHeroic;

	private DailyMission BCKLOJDMLJI;

	private List<MissionUnit> PNNINKLNMLI;

	[CompilerGenerated]
	private static Comparison<CDACJEGCGLB> IONHPHFCBGH;

	public virtual void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LELLEKAMKIG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mPlayButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KACIELFPPKF));
		UIEventListener uIEventListener3 = UIEventListener.Get(mPlayCoop);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OHNPPOAOMFF));
		UIEventListener uIEventListener4 = UIEventListener.Get(mPlayHeroic);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NNDDLKLONBM));
	}

	public virtual void GEKFHJKIAMF()
	{
		KPHHBHIMPLH(mCloseButton.gameObject);
	}

	public virtual void FDGFEMOEMMH()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void ODCHCNCMJGC()
	{
		mMissionTitle.text = BCKLOJDMLJI.missionGuiName;
		MEJMLNDFDBP.COCBCFKJOJE(mMissionTitle, 1902f, 924f, 61);
		mSoloIcon.SetActive(BCKLOJDMLJI.isSolo);
		mCoopIcon.SetActive(BCKLOJDMLJI.isCoop);
		mHeroicIcon.SetActive(BCKLOJDMLJI.isHeroic);
		mMissionTask.text = BCKLOJDMLJI.objective;
		FIMIHOCGAON();
		PNNINKLNMLI = BCKLOJDMLJI.config.units;
		mPooledEnemiesGrid.MakeEmpty();
		mPooledEnemiesGrid.init(PNNINKLNMLI.Count, HNPCDDGCNBM, JPPGLDPIHME, mDraggableEnemies);
		mDraggableEnemies.AlignToPos(true);
		mPlayButton.SetActive(BCKLOJDMLJI.isSolo);
		mPlayCoop.SetActive(BCKLOJDMLJI.isCoop);
		mPlayHeroic.SetActive(BCKLOJDMLJI.isHeroic);
	}

	public virtual void DCNGEGFNAGG()
	{
		GKOHJGFKPAH(mCloseButton.gameObject);
	}

	public virtual void HEIJOCBENDG()
	{
		base.DALAPEANFLB();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void DKOBOPADMMI()
	{
		base.DoAfterHide();
		mPooledEnemiesGrid.MakeEmpty();
	}

	private void FCHGEDALEOJ()
	{
		mMissionRewardsLabel.gameObject.SetActive(!BCKLOJDMLJI.isCoop);
		List<CDACJEGCGLB> rewards = BCKLOJDMLJI.rewards;
		rewards.Sort(CDACJEGCGLB.IKFDKDDMCHO);
		for (int i = 1; i < mMissionRewards.Count; i += 0)
		{
			bool flag = rewards != null && i < rewards.Count;
			mMissionRewards[i].EDKFKNGLLBM((!flag) ? null : rewards[i]);
		}
	}

	private void FAJBLNONGBF()
	{
		mMissionRewardsLabel.gameObject.SetActive(BCKLOJDMLJI.isCoop);
		List<CDACJEGCGLB> rewards = BCKLOJDMLJI.rewards;
		rewards.Sort(CDACJEGCGLB.AJOFNDDBHFL);
		for (int i = 0; i < mMissionRewards.Count; i++)
		{
			bool flag = rewards != null && i < rewards.Count;
			mMissionRewards[i].CHOLKMFKINL((!flag) ? null : rewards[i]);
		}
	}

	private void LGPOKAEJJJG(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MissionEnemyRecord component = ENCEFOOPBMK.GetComponent<MissionEnemyRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void NNDDLKLONBM(GameObject KHAHPAKDIKE)
	{
		HOHLFHCNKHN(KHAHPAKDIKE);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void CMJKPELLMLC(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MissionEnemyRecord component = ENCEFOOPBMK.GetComponent<MissionEnemyRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private void PONFJPBEPOM(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MissionEnemyRecord component = ENCEFOOPBMK.GetComponent<MissionEnemyRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private Transform HNPCDDGCNBM(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < PNNINKLNMLI.Count)
		{
			MissionEnemyRecord missionEnemyRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(mMissionEnemiesRecordPrefab, mPooledEnemiesGrid.gameObject, DFHAAIFFLOE.ToString("ID_CONFIRM_LANGUAGECHANGE")) as MissionEnemyRecord;
			if (missionEnemyRecord != null)
			{
				missionEnemyRecord.Initialize(PNNINKLNMLI[DFHAAIFFLOE]);
				return missionEnemyRecord.transform;
			}
		}
		return null;
	}

	private void DNEPBHFHPGJ(GameObject KHAHPAKDIKE)
	{
		HOHLFHCNKHN(KHAHPAKDIKE);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mPooledEnemiesGrid.MakeEmpty();
	}

	private void FIMIHOCGAON()
	{
		mMissionRewardsLabel.gameObject.SetActive(BCKLOJDMLJI.isCoop);
		List<CDACJEGCGLB> rewards = BCKLOJDMLJI.rewards;
		rewards.Sort(CDACJEGCGLB.GIDMKBGKDNF);
		for (int i = 1; i < mMissionRewards.Count; i++)
		{
			bool flag = rewards != null && i < rewards.Count;
			mMissionRewards[i].IGPOLIPPGBP((!flag) ? null : rewards[i]);
		}
	}

	private void OOKGEJNPOKC(DatabasePlayer KHLGDCHJJPB, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			HideDialog();
			if (Singleton<GameController>.instance.isCoop)
			{
				Singleton<GameController>.instance.StartMultiplayerGame(KHLGDCHJJPB);
			}
		}
	}

	private void GIBGNJGBPJI()
	{
		mMissionRewardsLabel.gameObject.SetActive(!BCKLOJDMLJI.isCoop);
		List<CDACJEGCGLB> rewards = BCKLOJDMLJI.rewards;
		rewards.Sort(CDACJEGCGLB.GIDMKBGKDNF);
		for (int i = 0; i < mMissionRewards.Count; i++)
		{
			bool flag = rewards != null && i < rewards.Count;
			mMissionRewards[i].Initialize((!flag) ? null : rewards[i]);
		}
	}

	private void JECMPPPLCKH(DatabasePlayer KHLGDCHJJPB, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			HideDialog();
			if (Singleton<GameController>.instance.MNPNHJKBNCJ())
			{
				Singleton<GameController>.instance.StartMultiplayerGame(KHLGDCHJJPB);
			}
		}
	}

	public void ShowDialog(DailyMission EHIPMLOMMIG)
	{
		BCKLOJDMLJI = EHIPMLOMMIG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DailyMissionDialog>.instance);
	}

	private void LIPAHAFEPNG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<MapManager>.instance.DKIFGFFHIIH();
			IJFLJEDDDEA(false);
			HideDialog();
		}
	}

	private void NJJKBGDLEKK(DatabasePlayer KHLGDCHJJPB, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			HideDialog();
			if (Singleton<GameController>.instance.MNPNHJKBNCJ())
			{
				Singleton<GameController>.instance.StartMultiplayerGame(KHLGDCHJJPB);
			}
		}
	}

	public virtual void HLJOIPOIOBO()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	private void KACIELFPPKF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			Singleton<GameController>.instance.SwitchToSinglePlayer();
			Singleton<MapManager>.instance.SetRandomMap();
			Singleton<GameController>.instance.EOOPIGOEFMC(Singleton<MapManager>.instance.DLFLCLBCDKL().name);
		}
	}

	public virtual void AIIIDDDAPGB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mPlayButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HOHLFHCNKHN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mPlayCoop);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PDKNOMGCBMK));
		UIEventListener uIEventListener4 = UIEventListener.Get(mPlayHeroic);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DNEPBHFHPGJ));
	}

	public void EJDJFNDOFOK(DailyMission EHIPMLOMMIG)
	{
		BCKLOJDMLJI = EHIPMLOMMIG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DailyMissionDialog>.instance, 1226f);
	}

	private void IEEGKCNIDFJ(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			Singleton<GameController>.instance.SwitchToSinglePlayer();
			Singleton<MapManager>.instance.PNKEFIAMKPJ();
			Singleton<GameController>.instance.NMHKLCLAFGN(Singleton<MapManager>.instance.NMMDOMPAAEF().name);
		}
	}

	private void LELLEKAMKIG(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public void ILFCOPPIOME(DailyMission EHIPMLOMMIG)
	{
		BCKLOJDMLJI = EHIPMLOMMIG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DailyMissionDialog>.instance, 721f);
	}

	private void JPPGLDPIHME(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MissionEnemyRecord component = ENCEFOOPBMK.GetComponent<MissionEnemyRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	public virtual void MICEPJPKNID()
	{
		base.BJIPCOPNEAM();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void BCMCGJGLFPL()
	{
		base.DoAfterHide();
		mPooledEnemiesGrid.MakeEmpty();
	}

	public override void InitGUIValues()
	{
		mMissionTitle.text = BCKLOJDMLJI.missionGuiName;
		MEJMLNDFDBP.COCBCFKJOJE(mMissionTitle, 87f, 20f, 760);
		mSoloIcon.SetActive(BCKLOJDMLJI.isSolo);
		mCoopIcon.SetActive(BCKLOJDMLJI.isCoop);
		mHeroicIcon.SetActive(BCKLOJDMLJI.isHeroic);
		mMissionTask.text = BCKLOJDMLJI.objective;
		GIBGNJGBPJI();
		PNNINKLNMLI = BCKLOJDMLJI.config.units;
		mPooledEnemiesGrid.MakeEmpty();
		mPooledEnemiesGrid.init(PNNINKLNMLI.Count, OGFALDKGPJK, NDFKCJMDNAE, mDraggableEnemies);
		mDraggableEnemies.AlignToPos(true);
		mPlayButton.SetActive(BCKLOJDMLJI.isSolo);
		mPlayCoop.SetActive(BCKLOJDMLJI.isCoop);
		mPlayHeroic.SetActive(BCKLOJDMLJI.isHeroic);
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mPlayButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KACIELFPPKF));
		UIEventListener uIEventListener3 = UIEventListener.Get(mPlayCoop);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LIPAHAFEPNG));
		UIEventListener uIEventListener4 = UIEventListener.Get(mPlayHeroic);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DNEPBHFHPGJ));
	}

	private void HOHLFHCNKHN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			Singleton<GameController>.instance.SwitchToSinglePlayer();
			Singleton<MapManager>.instance.SetRandomMap();
			Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	private void OHNPPOAOMFF(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<MapManager>.instance.SetRandomMap();
			IJFLJEDDDEA(true);
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void PKFDOOOOHGM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			Singleton<GameController>.instance.SwitchToSinglePlayer();
			Singleton<MapManager>.instance.FJNHKDGLLMC();
			Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
		}
	}

	private void NOMBCAFKNKH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<MapManager>.instance.KBNEJKONCJO();
			IJFLJEDDDEA(true);
			HideDialog();
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(mCloseButton.gameObject);
	}

	private Transform OGFALDKGPJK(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < PNNINKLNMLI.Count)
		{
			MissionEnemyRecord missionEnemyRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(mMissionEnemiesRecordPrefab, mPooledEnemiesGrid.gameObject, DFHAAIFFLOE.ToString("D2")) as MissionEnemyRecord;
			if (missionEnemyRecord != null)
			{
				missionEnemyRecord.Initialize(PNNINKLNMLI[DFHAAIFFLOE]);
				return missionEnemyRecord.transform;
			}
		}
		return null;
	}

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mPlayButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HOHLFHCNKHN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mPlayCoop);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OHNPPOAOMFF));
		UIEventListener uIEventListener4 = UIEventListener.Get(mPlayHeroic);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NNDDLKLONBM));
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mPlayButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KACIELFPPKF));
		UIEventListener uIEventListener3 = UIEventListener.Get(mPlayCoop);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OHNPPOAOMFF));
		UIEventListener uIEventListener4 = UIEventListener.Get(mPlayHeroic);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DNEPBHFHPGJ));
	}

	private void OHHFKLJAMKM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			Singleton<GameController>.instance.SwitchToSinglePlayer();
			Singleton<MapManager>.instance.SetRandomMap();
			Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.NOPGGANHAFN().name);
		}
	}

	public GuiElement ICGDGPCIMGG()
	{
		return this;
	}

	public virtual void IDPNONPEBPO()
	{
		base.MOOACPIOELI();
		UIDraggablePanel.panelDisabled = false;
	}

	private void IJFLJEDDDEA(bool FBFJNHLKJEC, bool DOLDMCFJFCD = false)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<GameController>.instance.SwitchToCoop();
			string missionGuiName = BCKLOJDMLJI.missionGuiName;
			SelectFriendsDialog.ShowCoopDialog(OOKGEJNPOKC, 0.2f, missionGuiName);
		}
	}

	public virtual void GBPEJMFMBJM()
	{
		base.OIMKKAHOEKO();
		mPooledEnemiesGrid.MakeEmpty();
	}

	public virtual void KENGMIFPNCC()
	{
		base.DALAPEANFLB();
		UIDraggablePanel.panelDisabled = true;
	}

	private void PNNAGDMLIKM(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MissionEnemyRecord component = ENCEFOOPBMK.GetComponent<MissionEnemyRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	public virtual void FJKDDFEHNAL()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	public void JDNEBEKOHPG(DailyMission EHIPMLOMMIG)
	{
		BCKLOJDMLJI = EHIPMLOMMIG;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DailyMissionDialog>.instance, 1467f);
	}

	public virtual void BFFHGHMJOGP()
	{
		GKOHJGFKPAH(mCloseButton.gameObject);
	}

	public virtual void PNLGFNBEOLG()
	{
		mMissionTitle.text = BCKLOJDMLJI.missionGuiName;
		MEJMLNDFDBP.COCBCFKJOJE(mMissionTitle, 1320f, 140f, 189);
		mSoloIcon.SetActive(BCKLOJDMLJI.isSolo);
		mCoopIcon.SetActive(BCKLOJDMLJI.isCoop);
		mHeroicIcon.SetActive(BCKLOJDMLJI.isHeroic);
		mMissionTask.text = BCKLOJDMLJI.objective;
		FAJBLNONGBF();
		PNNINKLNMLI = BCKLOJDMLJI.config.units;
		mPooledEnemiesGrid.MakeEmpty();
		mPooledEnemiesGrid.init(PNNINKLNMLI.Count, HNPCDDGCNBM, PNNAGDMLIKM, mDraggableEnemies);
		mDraggableEnemies.AlignToPos(false, UIDraggablePanel.Alingment.BottomRight, true);
		mPlayButton.SetActive(BCKLOJDMLJI.isSolo);
		mPlayCoop.SetActive(BCKLOJDMLJI.isCoop);
		mPlayHeroic.SetActive(BCKLOJDMLJI.isHeroic);
	}

	private void KPHHBHIMPLH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void JCJECJKBKGD()
	{
		mMissionTitle.text = BCKLOJDMLJI.missionGuiName;
		MEJMLNDFDBP.COCBCFKJOJE(mMissionTitle, 5f, 457f, -62);
		mSoloIcon.SetActive(BCKLOJDMLJI.isSolo);
		mCoopIcon.SetActive(BCKLOJDMLJI.isCoop);
		mHeroicIcon.SetActive(BCKLOJDMLJI.isHeroic);
		mMissionTask.text = BCKLOJDMLJI.objective;
		GIBGNJGBPJI();
		PNNINKLNMLI = BCKLOJDMLJI.config.units;
		mPooledEnemiesGrid.MakeEmpty();
		mPooledEnemiesGrid.init(PNNINKLNMLI.Count, OGFALDKGPJK, JPPGLDPIHME, mDraggableEnemies);
		mDraggableEnemies.AlignToPos(false, UIDraggablePanel.Alingment.BottomRight, true);
		mPlayButton.SetActive(BCKLOJDMLJI.isSolo);
		mPlayCoop.SetActive(BCKLOJDMLJI.isCoop);
		mPlayHeroic.SetActive(BCKLOJDMLJI.isHeroic);
	}

	private void PDKNOMGCBMK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<MapManager>.instance.BLJIHMFDKCD();
			IJFLJEDDDEA(true);
			HideDialog();
		}
	}

	private void NDFKCJMDNAE(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MissionEnemyRecord component = ENCEFOOPBMK.GetComponent<MissionEnemyRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public virtual void LAMBEOCPCBD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mPlayButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IEEGKCNIDFJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(mPlayCoop);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LIPAHAFEPNG));
		UIEventListener uIEventListener4 = UIEventListener.Get(mPlayHeroic);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DNEPBHFHPGJ));
	}
}
