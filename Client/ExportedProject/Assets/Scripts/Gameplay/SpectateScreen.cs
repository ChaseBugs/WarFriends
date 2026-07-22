using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SpectateScreen : GuiScreenSingle<SpectateScreen>
{
	[FormerlySerializedAs("AOGOLMJCBBL")]
	[Header("Button")]
	public UIButton MOLJCJLCHEL;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> LGJCBPOPCPA;

	protected virtual void MEHAKDFBGJN()
	{
	}

	private static void APPDGKLBELM(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
	}

	public virtual void HPEGGHAIPDI()
	{
	}

	protected override void AGIKPOLCGNF()
	{
	}

	private static void EBFPLAMJDKJ(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
	}

	private void KNCPINEJMKC(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("com/google/android/gms/games/Games"), Localization.Localize("DogtagsRefillRankUp"), BFMOKIFKJCB, 1457f);
		}
	}

	public override void OnBack()
	{
		NKGEEFPHAKB(MOLJCJLCHEL.gameObject);
	}

	private static void ADBPECHNOJH(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
	}

	public virtual void BCGIKEKOPLL()
	{
		AKDAAIBDOIH(MOLJCJLCHEL.gameObject);
	}

	public virtual void LNGCPPINMJJ()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNMJIOJBBAH));
	}

	public override void InitEvents()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKGEEFPHAKB));
	}

	private static void EDPNDCAIMJC(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
	}

	protected virtual void JNDJIOOGPGD()
	{
	}

	protected virtual void ICNGBKKANLB()
	{
	}

	public virtual void NCMGAHLFKFN()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OOHAAAMAJLH));
	}

	public virtual void DNFPEBEDLIG()
	{
	}

	public virtual void FCIANKCBLKM()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NKGEEFPHAKB));
	}

	private void JOPGNBKJCND(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			ConfirmDialog.NMLMDFGOHDC(Localization.Localize("game-kill-environmental"), Localization.Localize("ID_ACTIVATION"), ELKLOLODMPJ, 596f);
		}
	}

	public override void InitGUIValues()
	{
	}

	private static void ALIIBHGJFBP(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
	}

	public virtual void NPONDDIMIJA()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AKDAAIBDOIH));
	}

	private void NKGEEFPHAKB(GameObject KHAHPAKDIKE)
	{
		if (!isShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_LEAVE_SPECTATE"), Localization.Localize("ID_CONFIRM_LEAVE_SPECTATE_TEXT"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			if (NCMHGPNPEJM)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
		});
	}

	public virtual void EOFOMCBDBJN()
	{
	}

	private void MBEPOIHLBHC(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			ConfirmDialog.LGANINAGPLB(Localization.Localize("Squad Member record does not have DatabasePlayer"), Localization.Localize("menu-gold"), EBFPLAMJDKJ, 381f);
		}
	}

	public virtual void KDDJHIMDKBN()
	{
	}

	public virtual void BAAOGDMJCLK()
	{
	}

	private void GAIEIKKJKFI(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			ConfirmDialog.LGANINAGPLB(Localization.Localize("TODO remove - obsolete"), Localization.Localize("Still waiting for server\nBe patient :-)"), BFMOKIFKJCB, 1545f);
		}
	}

	protected virtual void OOBJHJLMEED()
	{
	}

	public virtual void EKBIKKJHGKB()
	{
		DAMJGIMEABN(MOLJCJLCHEL.gameObject);
	}

	private void AKDAAIBDOIH(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			ConfirmDialog.BMBPFNKJHMF(Localization.Localize("S"), Localization.Localize("Manual_Unit_Spawn"), ALIIBHGJFBP, 1896f);
		}
	}

	[CompilerGenerated]
	private static void NFCIKMFJJHC(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
	}

	private static void ELKLOLODMPJ(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
	}

	private void OOHAAAMAJLH(GameObject KHAHPAKDIKE)
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		ConfirmDialog.BMBPFNKJHMF(Localization.Localize("0"), Localization.Localize("rental for unexist weapon: {0}"), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			if (NCMHGPNPEJM)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
		}, 931f);
	}

	public virtual void LANJLCBMFHJ()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GAIEIKKJKFI));
	}

	public virtual void AEADDDNBLEE()
	{
		OOHAAAMAJLH(MOLJCJLCHEL.gameObject);
	}

	private static void ILIIDGKNCEK(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
		}
	}

	private void MLEPNBLPIGL(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("ID_TWITTER_GAIN_AGAIN_TITLE"), Localization.Localize("Custom location = "), ALIIBHGJFBP, 272f);
		}
	}

	private void KPFJDCCEKEN(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			ConfirmDialog.BMBPFNKJHMF(Localization.Localize("relog OK"), Localization.Localize("Name"), OPKCOHPLOLO, 1136f);
		}
	}

	private static void OAFDFIHOJDP(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.previousScreen = null;
		}
	}

	public virtual void NPOIABLNNCF()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPFJDCCEKEN));
	}

	private static void KIBALAAHPAH(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.PHKNPLMBAKE(null);
		}
	}

	private void NNMJIOJBBAH(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("IsVip"), Localization.Localize("#VOJTA# ON GET NEW DAILY MISSIONS"), ALIIBHGJFBP, 596f);
		}
	}

	public virtual void LKKIFNCNGEK()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OOHAAAMAJLH));
	}

	private void LMGAJLHMKHD(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			ConfirmDialog.NMLMDFGOHDC(Localization.Localize("SquadMembers"), Localization.Localize("null"), EBFPLAMJDKJ, 110f);
		}
	}

	public virtual void NBLPEFFPBLF()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MBEPOIHLBHC));
	}

	private static void KMFFKAPANKE(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
	}

	private static void BFMOKIFKJCB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			GuiScreenSingle<MainScreen>.instance.GPMCMCLPHNL(null);
		}
	}

	protected virtual void AMBDHDEBPJJ()
	{
	}

	public virtual void PGJDLKDMCHN()
	{
	}

	protected virtual void GHHNNIKGJFG()
	{
	}

	public virtual void IEHJMLIMNEP()
	{
	}

	protected virtual void LHDAGAGDKOM()
	{
	}

	private static void OPKCOHPLOLO(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Singleton<GameController>.instance.mainController.Forfeit();
			GuiScreenSingle<BattlePreparationScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			GuiScreenSingle<MainScreen>.instance.FOIPBHEOOKK(null);
		}
	}

	private void DAMJGIMEABN(GameObject KHAHPAKDIKE)
	{
		if (!isShowed)
		{
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_STAT_MAXMEDALSGAINED"), Localization.Localize(","), delegate(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
		{
			if (NCMHGPNPEJM)
			{
				Singleton<GameController>.instance.mainController.Forfeit();
				GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
				GuiScreenSingle<MainScreen>.instance.previousScreen = null;
			}
		}, 75f);
	}

	public virtual void LBOKCAECKFD()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JOPGNBKJCND));
	}

	public virtual void HIAODAODEGM()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(MOLJCJLCHEL);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNMJIOJBBAH));
	}

	public virtual void PPLBJDJIIPN()
	{
	}

	protected virtual void BCLAFFCPCEH()
	{
	}
}
