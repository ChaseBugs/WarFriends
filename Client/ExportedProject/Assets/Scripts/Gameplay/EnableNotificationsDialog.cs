using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class EnableNotificationsDialog : GuiElementSingle<EnableNotificationsDialog>, PAIIOKBBHBC
{
	[Header("Table")]
	[FormerlySerializedAs("FIPPNDNGHHA")]
	public UITable KMOCHMFECOA;

	[Header("Buttons")]
	[FormerlySerializedAs("NJPBAJCIHHE")]
	public UIButton APCMHDINKEI;

	[FormerlySerializedAs("JLKCLLMACPF")]
	public UIButton MINGMKDDOHO;

	[FormerlySerializedAs("IBLJKIGKAEN")]
	public UILabel ICGOIEBBAAB;

	[FormerlySerializedAs("MMAJFIHDPLN")]
	public UITable AMNIABHAMDN;

	[FormerlySerializedAs("FCJPHKNHEHC")]
	public UILabel LGJIPJFLMMG;

	private void HAFDOJGCBMP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("Action ", LNFHFHCDENM: false);
			Debug.Log("left");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public GuiElement LBDMFPOEOLA()
	{
		return this;
	}

	public virtual void GMDAPGAECEI()
	{
		NPNHOMHBNDB(APCMHDINKEI.gameObject);
	}

	public GuiElement AAMCALKKHEL()
	{
		return this;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public override void InitGUIValues()
	{
		KMOCHMFECOA.repositionNow = true;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.NotificationAllowReward);
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowReward).FLOATVALUE;
		bool flag2 = !flag && num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	private void FJADCGOBKNI()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 1802f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void NLBAPEADKNJ()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	private void NPPHLECAKHB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("WALLET - fake spent WB {0}", LNFHFHCDENM: true);
			Debug.Log("EXCEPTION = ");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	private void CCLHGIFDEMC()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 1941f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GBNFENDDNAE));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHAIALDGMGH));
		AMNIABHAMDN.onReposition = KCJPCIGFBMD;
	}

	public virtual void EOFOMCBDBJN()
	{
		KMOCHMFECOA.repositionNow = true;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.NotificationAllowHoursBetween);
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-113)).FLOATVALUE;
		bool flag2 = flag || num > 1;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	public virtual void EOLLHJKMKKG()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public virtual void JCOILGHDPHA()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	private void LJNAACMGCED()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 1125f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void JDNNJCHMFHF()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public virtual void OFCCACPEBHD()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-110));
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SilverCardRarityEarly).FLOATVALUE;
		bool flag2 = !flag && num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	public GuiElement BPBDMKNKLMN()
	{
		return this;
	}

	private void LHAIALDGMGH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("313 MENU ENABLE PUSH", LNFHFHCDENM: false);
			Debug.Log("Going to enable notifications");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public GuiElement JJBEFGHBHCL()
	{
		return this;
	}

	public virtual void KJLDIJPMPAM()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public virtual void PFCKKOBABEL()
	{
		GBNFENDDNAE(APCMHDINKEI.gameObject);
	}

	public virtual void OIGFBFFNNHH()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-19));
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LapsedPlayerInterval1).FLOATVALUE;
		bool flag2 = flag || num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = false;
		}
	}

	public virtual void PDHNLAMPOBN()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-99));
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
		bool flag2 = flag || num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = false;
		}
	}

	public virtual void DFKLIKFAKGA()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-41));
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldPackGoldCards).FLOATVALUE;
		bool flag2 = !flag && num > 1;
		ICGOIEBBAAB.gameObject.SetActive(flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = false;
		}
	}

	private void LCEAIEBGBBA()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 1364f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void MHFIIKEFGKG()
	{
		FOPMLFDDOII(APCMHDINKEI.gameObject);
	}

	private void GGNGBHPPNLL()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 776f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void NMHMFDOFDBC()
	{
		base.DoAfterHide();
		if (GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	private void AJNFCLPCFCL()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 529f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void FAGMMFKPKHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPNHOMHBNDB));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HBENMKEELAA));
		AMNIABHAMDN.onReposition = NIMHOKBIAMM;
	}

	private void MIEHKHDCHBO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("506 MENU ARMY SCREEN UPGRADE ACTIVATED", LNFHFHCDENM: false);
			Debug.Log(" tutorial running: ");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public GuiElement JPJLCBBIHFE()
	{
		return this;
	}

	public virtual void IOLNONPHCMM()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.DeathMatchTime);
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseAdCount).FLOATVALUE;
		bool flag2 = !flag && num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	public virtual void OJFGFKCDCAM()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public virtual void NMMEDNEGDNI()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	private void NKDHGKAOFKF()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 24f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void LGIPBIFJFPD()
	{
		base.DoAfterHide();
		if (GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public override void OnBack()
	{
		NPNHOMHBNDB(APCMHDINKEI.gameObject);
	}

	public virtual void ELLOMLNAFJK()
	{
		NPNHOMHBNDB(APCMHDINKEI.gameObject);
	}

	private void BAHNCABHECN()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 788f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void GBPEJMFMBJM()
	{
		base.DoAfterHide();
		if (GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPNHOMHBNDB));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHAIALDGMGH));
		AMNIABHAMDN.onReposition = delegate
		{
			float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 2f;
			AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
		};
	}

	public GuiElement PHBEAIBFIHH()
	{
		return this;
	}

	private void GBHAJAMMKKO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("monthLenght", LNFHFHCDENM: true);
			Debug.Log("ID_GC_LOGOUT_TITLE");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	private void MHNLNAHBGHH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("Claiming reward ", LNFHFHCDENM: false);
			Debug.Log("Shots_Fired");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public virtual void OMOJHCOKAHP()
	{
		NPNHOMHBNDB(APCMHDINKEI.gameObject);
	}

	private void HIOBLMOKLGF()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 464f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void HEMPLECIOMI()
	{
		NPNHOMHBNDB(APCMHDINKEI.gameObject);
	}

	private void NPNHOMHBNDB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("313 MENU ENABLE PUSH", LNFHFHCDENM: false);
			HideDialog();
		}
	}

	private void DKOGFLOOJCN()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 340f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void LMNNNHJKMFP()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-13));
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward3).FLOATVALUE;
		bool flag2 = flag || num > 0;
		ICGOIEBBAAB.gameObject.SetActive(flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	private void HBENMKEELAA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("Failed to join room during or after match and MatchManager.isReconnect = FALSE", LNFHFHCDENM: false);
			Debug.Log("Prefabs");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public virtual void BGDPJGNKPKB()
	{
		base.DoAfterHide();
		if (GuiElementSingle<SettingsDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	private void KCJPCIGFBMD()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 1281f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	private void HIJDAAJNJLI()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 1702f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void MOPAOJFCOGP()
	{
		base.DoAfterHide();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public virtual void BNPDALDLFFM()
	{
		KMOCHMFECOA.repositionNow = true;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.MinTimeSinceLastUnitUpgrade);
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldRespawnRatePerSec).FLOATVALUE;
		bool flag2 = !flag && num > 1;
		ICGOIEBBAAB.gameObject.SetActive(flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	private void PKOFLJHMNBD(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("-[^-]*$", LNFHFHCDENM: false);
			Debug.Log("ID_MISSION_WAVE");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public virtual void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GBNFENDDNAE));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KKKNLKADOLJ));
		AMNIABHAMDN.onReposition = LCEAIEBGBBA;
	}

	public GuiElement PDOCMLPCMMO()
	{
		return this;
	}

	public GuiElement JEAMNJAPFJK()
	{
		return this;
	}

	private void KKKNLKADOLJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("null", LNFHFHCDENM: true);
			Debug.Log("Total_Sessions");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	private void ECDOKHBEKAH()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 1469f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void NIHDCNNMBIK()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	private void DBGIHIDGGAA()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 1104f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void HHJDKKFKKIL()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.TimeBetweenVIPreminderShown);
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-125)).FLOATVALUE;
		bool flag2 = !flag && num > 0;
		ICGOIEBBAAB.gameObject.SetActive(flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	public GuiElement CPONDDGFBIH()
	{
		return this;
	}

	private void PHKCMCLNPEG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("menu-gold", LNFHFHCDENM: true);
			Debug.Log("Wood");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public virtual void OEDLHCLCKEO()
	{
		KMOCHMFECOA.repositionNow = true;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.BronzePackGuaranteedCardsType);
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		bool flag2 = flag || num > 1;
		ICGOIEBBAAB.gameObject.SetActive(flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = false;
		}
	}

	private void FOPMLFDDOII(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("N", LNFHFHCDENM: false);
			HideDialog();
		}
	}

	public virtual void DEFCMABOJGD()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-64));
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-102)).FLOATVALUE;
		bool flag2 = !flag && num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	private void GBNFENDDNAE(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("Special pack content: type: {0} id: {1}{2}", LNFHFHCDENM: true);
			HideDialog();
		}
	}

	private void FKCALGEPEMD()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 510f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void PPLBJDJIIPN()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.StartingWarbucks);
		int num = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-14)).FLOATVALUE;
		bool flag2 = flag || num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = false;
		}
	}

	public virtual void NEINEPJDKCL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GBNFENDDNAE));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKOFLJHMNBD));
		AMNIABHAMDN.onReposition = DBGIHIDGGAA;
	}

	public virtual void NFABHLHCNGJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FOPMLFDDOII));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MIEHKHDCHBO));
		AMNIABHAMDN.onReposition = CLMDBKKAHNP;
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 2f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void JCGPELEDCJL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NPNHOMHBNDB));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HBENMKEELAA));
		AMNIABHAMDN.onReposition = DBGIHIDGGAA;
	}

	public virtual void CNOLAKPOBIF()
	{
		GBNFENDDNAE(APCMHDINKEI.gameObject);
	}

	public virtual void KPLOCMGDDAB()
	{
		KMOCHMFECOA.repositionNow = true;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-22));
		int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-89)).FLOATVALUE;
		bool flag2 = !flag && num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = true;
		}
	}

	private void HDCJJGEJKGL(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("menu-assignments-bg", LNFHFHCDENM: true);
			Debug.Log("ID_CONFIRM_KICKPLAYER_TEXT");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public virtual void GCGPANMGOPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GBNFENDDNAE));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HDCJJGEJKGL));
		AMNIABHAMDN.onReposition = delegate
		{
			float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 2f;
			AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
		};
	}

	public GuiElement NKAJOPFDFEI()
	{
		return this;
	}

	public virtual void COBDHBOCGAP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FOPMLFDDOII));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HAFDOJGCBMP));
		AMNIABHAMDN.onReposition = BAHNCABHECN;
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GBNFENDDNAE));
		UIEventListener uIEventListener2 = UIEventListener.Get(MINGMKDDOHO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GBHAJAMMKKO));
		AMNIABHAMDN.onReposition = AJNFCLPCFCL;
	}

	public virtual void DILDDAGFIEO()
	{
		NPNHOMHBNDB(APCMHDINKEI.gameObject);
	}

	private void NIMHOKBIAMM()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 438f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void NIHENNDPJFB()
	{
		NPNHOMHBNDB(APCMHDINKEI.gameObject);
	}

	public virtual void MOKAPOJLCPJ()
	{
		base.OIMKKAHOEKO();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public virtual void LDBLJDJNJJN()
	{
		base.DoAfterHide();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public GuiElement IDJAIBECBDG()
	{
		return this;
	}

	private void DGPMPJMACLP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("ID_FIGHT", LNFHFHCDENM: false);
			Debug.Log("ServerErrorHandler: renameCount = ");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public GuiElement JMNCLNNCGGF()
	{
		return this;
	}

	private void LMGBCIFHGFL()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 633f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	public virtual void BIOHPAMGEAL()
	{
		GBNFENDDNAE(APCMHDINKEI.gameObject);
	}

	public virtual void LKBEJGHEANA()
	{
		KMOCHMFECOA.repositionNow = false;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldExpCoefficient);
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-116)).FLOATVALUE;
		bool flag2 = !flag && num > 0;
		ICGOIEBBAAB.gameObject.SetActive(!flag2);
		AMNIABHAMDN.gameObject.SetActive(flag2);
		if (flag2)
		{
			LGJIPJFLMMG.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			AMNIABHAMDN.repositionNow = false;
		}
	}

	private void KGJLMADNBDI()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 906f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}

	private void CLMDBKKAHNP()
	{
		float val = 0f - AMNIABHAMDN.padding.x - (LGJIPJFLMMG.transform.parent.transform.localPosition.x - AMNIABHAMDN.padding.x) / 671f;
		AMNIABHAMDN.transform.localPosition = AMNIABHAMDN.transform.localPosition.ReplaceX(val);
	}
}
