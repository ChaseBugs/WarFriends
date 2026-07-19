using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaOpenedDialog : GuiElementSingle<ArenaOpenedDialog>, PAIIOKBBHBC
{
	[Header("Top")]
	public GameObject FNOFLJEOHGJ;

	public UILabel OKMNFHNBMFA;

	public GameObject LJNPCHFCGCN;

	[Header("Left")]
	public UILabel OKLOKGPGJAG;

	[Header("Middle")]
	public UISprite DGCEIKBFIJD;

	public UILabel LLKBGEIICIB;

	[Header("Right")]
	public WararenaRewardRecord AAPOHEGHHAC;

	public UIDraggablePanel OPJKGIHKOJE;

	public UIPooledGrid KCCOKFDFHGI;

	[Header("Bottom")]
	public GameObject DMPBNBPBDFD;

	public UILabel HLPPHFIEGBL;

	private float ADDICBANAAB;

	private List<PHAMEDPLFLO> MLCJPKJBAHL;

	private LevelBehaviour IFFDIHCPKFE;

	private bool HHGIEIHGDJP;

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	private void PCDMCGJGBDP(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void EDOIPOGMEBB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (WarArena.instance.isArenaTicketBought)
			{
				GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(ArenaScreen.BGMNNKDJBEK.MainArena);
			}
			else
			{
				GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(ArenaScreen.BGMNNKDJBEK.EnterArena);
			}
			HideDialog();
		}
	}

	public virtual void GEGDLJIKIFE()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	private void MBHDDJLBEEM(Transform ENCEFOOPBMK)
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

	protected virtual void HDLDMGEFCEJ()
	{
		base.BOEMHLPLOGA();
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 775f)
		{
			ADDICBANAAB -= 1421f;
			OKLOKGPGJAG.text = MIGCGPMDMAB.NBMKJPGBCEC();
			if (HHGIEIHGDJP && !WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK)
			{
				HHGIEIHGDJP = true;
				OKMNFHNBMFA.text = Localization.Localize("game-card-ico-backstab");
				HLPPHFIEGBL.text = Localization.Localize("MaxBattles");
			}
		}
	}

	private void HJCMDNJEBCA(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			WararenaRewardRecord component = ENCEFOOPBMK.GetComponent<WararenaRewardRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void DCKLBBDOHAE()
	{
		if (NPFFMLLLDAF())
		{
			Singleton<LootBoxCameraArena>.instance.MAPKMCFDDJE(IFFDIHCPKFE, false);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener3 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EDOIPOGMEBB));
	}

	public override void InitGUIValues()
	{
		IFFDIHCPKFE = WarArena.instance.FPLIPHCJGFO.EJPOKHDDJBO;
		HHGIEIHGDJP = WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK;
		OKMNFHNBMFA.text = Localization.Localize((!HHGIEIHGDJP) ? "ID_ARENAISOPEN" : "ID_ARENAWILLOPENSOON");
		HLPPHFIEGBL.text = Localization.Localize((!HHGIEIHGDJP) ? "ID_TAKEMETHERE" : "ID_MOREINFO");
		EDEHEDADMFL();
		MLCJPKJBAHL = WarArena.instance.FPLIPHCJGFO.EOIAFJNEOKL;
		KCCOKFDFHGI.MakeEmpty();
		KCCOKFDFHGI.init(MLCJPKJBAHL.Count, BKEGAEBBGPE, MBHDDJLBEEM, OPJKGIHKOJE);
		OPJKGIHKOJE.AlignToPos(true);
		float seconds = DCIKANJJFIJ * 0.5f;
		InvokeAfter(delegate
		{
			if (isShowed)
			{
				Singleton<LootBoxCameraArena>.instance.DisplayModel(IFFDIHCPKFE, false);
			}
		}, seconds);
	}

	public virtual void EKBIKKJHGKB()
	{
		FCEDMOAEKOB(FNOFLJEOHGJ);
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCDMCGJGBDP));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FCEDMOAEKOB));
		UIEventListener uIEventListener3 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EDOIPOGMEBB));
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<LootBoxCameraArena>.instance.Hide();
	}

	[CompilerGenerated]
	private void DNCCGBGGHLH()
	{
		if (isShowed)
		{
			Singleton<LootBoxCameraArena>.instance.DisplayModel(IFFDIHCPKFE, false);
		}
	}

	public void IPCIJFBFLHP()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 75f);
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		Singleton<LootBoxCameraArena>.instance.Hide();
		KCCOKFDFHGI.MakeEmpty();
	}

	protected override void Update()
	{
		base.Update();
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 0.333f)
		{
			ADDICBANAAB -= 0.333f;
			OKLOKGPGJAG.text = MIGCGPMDMAB.NBMKJPGBCEC();
			if (HHGIEIHGDJP && !WarArena.instance.FPLIPHCJGFO.CGJJJOEMPLK)
			{
				HHGIEIHGDJP = false;
				OKMNFHNBMFA.text = Localization.Localize("ID_ARENAISOPEN");
				HLPPHFIEGBL.text = Localization.Localize("ID_TAKEMETHERE");
			}
		}
	}

	private Transform BKEGAEBBGPE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MLCJPKJBAHL.Count)
		{
			WararenaRewardRecord wararenaRewardRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(AAPOHEGHHAC, KCCOKFDFHGI.gameObject, string.Format("Reward {0:D2}", DFHAAIFFLOE)) as WararenaRewardRecord;
			if (wararenaRewardRecord != null)
			{
				wararenaRewardRecord.Initialize(MLCJPKJBAHL[DFHAAIFFLOE], WararenaRewardRecord.COLKIFOMJPF.ChangeUnit);
				return wararenaRewardRecord.transform;
			}
		}
		return null;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		HEBILNGCGDN(FNOFLJEOHGJ);
	}

	private void FCEDMOAEKOB(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void OFCCACPEBHD()
	{
		IFFDIHCPKFE = WarArena.instance.FPLIPHCJGFO.NEANBBHLPNB();
		HHGIEIHGDJP = WarArena.instance.FPLIPHCJGFO.DFEFCEHHMAC();
		OKMNFHNBMFA.text = Localization.Localize((!HHGIEIHGDJP) ? "game-missions-red-mission-ico" : "Days_Since_Install");
		HLPPHFIEGBL.text = Localization.Localize((!HHGIEIHGDJP) ? "N" : "game-label-you-blue");
		EDEHEDADMFL();
		MLCJPKJBAHL = WarArena.instance.FPLIPHCJGFO.EOIAFJNEOKL;
		KCCOKFDFHGI.MakeEmpty();
		KCCOKFDFHGI.init(MLCJPKJBAHL.Count, BKEGAEBBGPE, MBHDDJLBEEM, OPJKGIHKOJE);
		OPJKGIHKOJE.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight, true);
		float seconds = DCIKANJJFIJ * 972f;
		InvokeAfter(delegate
		{
			if (isShowed)
			{
				Singleton<LootBoxCameraArena>.instance.DisplayModel(IFFDIHCPKFE, false);
			}
		}, seconds);
	}

	private void GAHAMMDHAOF()
	{
		if (NPFFMLLLDAF())
		{
			Singleton<LootBoxCameraArena>.instance.PEPEFFINIMM(IFFDIHCPKFE, false);
		}
	}

	private void KBLELMNHBHO(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			WararenaRewardRecord component = ENCEFOOPBMK.GetComponent<WararenaRewardRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private void EDEHEDADMFL()
	{
		LLKBGEIICIB.text = ((!IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked) ? string.Empty : Localization.LocalizeFormat("ID_COLLECTXELITEPARTSANDUPGRADETOELITE", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePriceParts), IFFDIHCPKFE.unitElitePartsName.ToUpper(), IFFDIHCPKFE.unitName.ToUpper()));
		float val = (0f - LLKBGEIICIB.relativeSize.x * LLKBGEIICIB.transform.localScale.x) / 2f - 50f;
		DGCEIKBFIJD.transform.localPosition = DGCEIKBFIJD.transform.localPosition.ReplaceX(val);
	}

	public void GILDIKINMFE()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 759f);
	}

	public virtual void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCDMCGJGBDP));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener3 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EDOIPOGMEBB));
	}

	private void LINMMNJBPHB(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			if (WarArena.instance.isArenaTicketBought)
			{
				GuiScreenSingle<ArenaScreen>.instance.FIIIKMNODJA(ArenaScreen.BGMNNKDJBEK.MainArena);
			}
			else
			{
				GuiScreenSingle<ArenaScreen>.instance.OCDINHEFBDG(ArenaScreen.BGMNNKDJBEK.EnterArena);
			}
			HideDialog();
		}
	}

	public void AONPDBAPDOL(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		MOMDELGNKFN();
		if (isShowed)
		{
			Singleton<LootBoxCameraArena>.instance.MCJFOJJDAFC(IFFDIHCPKFE, false);
		}
	}

	private void MOMDELGNKFN()
	{
		UILabel lLKBGEIICIB = LLKBGEIICIB;
		string text;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			object[] array = new object[3];
			array[1] = Colours.stringGreenArena;
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.upgradePriceParts);
			array[2] = IFFDIHCPKFE.unitElitePartsName.ToUpper();
			array[4] = IFFDIHCPKFE.unitName.ToUpper();
			text = Localization.LocalizeFormat("ExtraWarBucks", array);
		}
		else
		{
			text = string.Empty;
		}
		lLKBGEIICIB.text = text;
		float val = (0f - LLKBGEIICIB.relativeSize.x * LLKBGEIICIB.transform.localScale.x) / 508f - 1172f;
		DGCEIKBFIJD.transform.localPosition = DGCEIKBFIJD.transform.localPosition.ReplaceX(val);
	}

	public virtual void FJKDDFEHNAL()
	{
		base.NEEAKMELPBJ();
		Singleton<LootBoxCameraArena>.instance.KFKEHJHBKLP();
	}

	public void ChangeUnit(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		EDEHEDADMFL();
		if (isShowed)
		{
			Singleton<LootBoxCameraArena>.instance.DisplayModel(IFFDIHCPKFE, false);
		}
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCDMCGJGBDP));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener3 = UIEventListener.Get(DMPBNBPBDFD);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EDOIPOGMEBB));
	}
}
