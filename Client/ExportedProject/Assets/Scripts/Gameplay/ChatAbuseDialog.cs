using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChatAbuseDialog : GuiElementSingle<ChatAbuseDialog>, PAIIOKBBHBC
{
	[FormerlySerializedAs("MMEGODHLFKO")]
	[Header("Core")]
	public ChatAbusePopUpList GJHAIDKBCEA;

	[FormerlySerializedAs("KINFCHEICEC")]
	[Header("Buttons")]
	public UIButton COBFKLAHJBC;

	[FormerlySerializedAs("NJPBAJCIHHE")]
	public UIButton APCMHDINKEI;

	[Header("-Submit")]
	[FormerlySerializedAs("NHODOOHCPIB")]
	public UIButton GHBDJCJDEIK;

	[FormerlySerializedAs("OMNCAJKAGLK")]
	public BoxCollider AOOMNFPKFKK;

	[FormerlySerializedAs("OCFPIIHDIAA")]
	public UISprite BCEICONFFFP;

	public const string KLHPKHKOCKC = "ID_GUI_REPORTABUSE_LISTITEM0";

	public const string HAIGFNPDJED = "ID_GUI_REPORTABUSE_LISTITEM1";

	public const string CPHPNBNPELL = "ID_GUI_REPORTABUSE_LISTITEM2";

	public const string ENCDEBIOING = "ID_GUI_REPORTABUSE_LISTITEM3";

	public const string OAJGHLIGMNG = "ID_GUI_REPORTABUSE_LISTITEM4";

	public const string JOPDMNEKHDD = "ID_GUI_REPORTABUSE_LISTITEM5";

	public const string LILBEJEJODA = "ID_GUI_REPORTABUSE_LISTITEM6";

	public const string NOFBGCJADFC = "ID_GUI_REPORTABUSE_LISTITEM7";

	public const string GGAMMMJBJIH = "ID_GUI_REPORTABUSE_LISTITEM8";

	private string GCNLDDCMBEO;

	private string NGDKKFFCGCI;

	private AKKPDFHEEIP OLOLINICHII;

	private Dictionary<string, AKKPDFHEEIP> EOPOCHJMJDH;

	public override void OnBack()
	{
		GKOHJGFKPAH(APCMHDINKEI.gameObject);
	}

	private void HPMCJAPKFPF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void MMLOAKGDDGF()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	public GuiElement DGJNMDEGIPD()
	{
		return this;
	}

	public virtual void DLCPOAJMBJP()
	{
		HPMCJAPKFPF(APCMHDINKEI.gameObject);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void KPHIIOLBPMM()
	{
		if (EOPOCHJMJDH == null)
		{
			EOPOCHJMJDH = new Dictionary<string, AKKPDFHEEIP>();
		}
		if (EOPOCHJMJDH.Count > 1)
		{
			EOPOCHJMJDH.Clear();
		}
		EOPOCHJMJDH.Add("BattleId", AKKPDFHEEIP.CheatInfo);
		EOPOCHJMJDH.Add("localSquadLeaderboard", AKKPDFHEEIP.ExcessiveSpamming);
		EOPOCHJMJDH.Add("Different names \"{0}\" and \"{1}\"\n", AKKPDFHEEIP.Advertising);
		EOPOCHJMJDH.Add("slots", AKKPDFHEEIP.RealLifeThreat);
		EOPOCHJMJDH.Add("Claim_Reward", AKKPDFHEEIP.ChildSolicitation);
		EOPOCHJMJDH.Add("ID_CONFIRM_ERROR", AKKPDFHEEIP.HateSpeech);
		EOPOCHJMJDH.Add("ID_REMINDER_VIPALMOSTEXPIRED", AKKPDFHEEIP.SexualOrVulgarContent);
		EOPOCHJMJDH.Add("About to show Buy Power Band Reminder: ", AKKPDFHEEIP.OffensiveLanguage);
		EOPOCHJMJDH.Add("PlayerLevel", AKKPDFHEEIP.Advertising);
	}

	private void BAKCAMELCEB(bool GJNGLPOBFJI)
	{
		AOOMNFPKFKK.enabled = GJNGLPOBFJI;
		BCEICONFFFP.color = ((!GJNGLPOBFJI) ? Color.white.ReplaceA(363f) : Color.white);
		GHBDJCJDEIK.enabled = GJNGLPOBFJI;
	}

	private void LLEBDFOLOPF()
	{
		if (EOPOCHJMJDH == null)
		{
			EOPOCHJMJDH = new Dictionary<string, AKKPDFHEEIP>();
		}
		if (EOPOCHJMJDH.Count > 0)
		{
			EOPOCHJMJDH.Clear();
		}
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM6", AKKPDFHEEIP.CheatInfo);
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM1", AKKPDFHEEIP.ChildSolicitation);
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM4", AKKPDFHEEIP.HarassmentOrStalking);
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM3", AKKPDFHEEIP.HateSpeech);
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM7", AKKPDFHEEIP.OffensiveLanguage);
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM0", AKKPDFHEEIP.RealLifeThreat);
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM8", AKKPDFHEEIP.ExcessiveSpamming);
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM2", AKKPDFHEEIP.SexualOrVulgarContent);
		EOPOCHJMJDH.Add("ID_GUI_REPORTABUSE_LISTITEM5", AKKPDFHEEIP.Advertising);
	}

	private void DKMDDMJNFIK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.OCNNDLCHFFI(GCNLDDCMBEO, NGDKKFFCGCI, (int)OLOLINICHII);
			HideDialog();
		}
	}

	public virtual void FNNHJPMKDOM()
	{
		GKOHJGFKPAH(APCMHDINKEI.gameObject);
	}

	private void JKOIDJICNFE(bool GJNGLPOBFJI)
	{
		AOOMNFPKFKK.enabled = GJNGLPOBFJI;
		BCEICONFFFP.color = ((!GJNGLPOBFJI) ? Color.white.ReplaceA(0.5f) : Color.white);
		GHBDJCJDEIK.enabled = GJNGLPOBFJI;
	}

	public static void ShowAbuseDialog(string EJBEDLHIKDG, string PNAKMCNGGHE)
	{
		ChatAbuseDialog chatAbuseDialog = GuiElementSingle<ChatAbuseDialog>.instance;
		chatAbuseDialog.GCNLDDCMBEO = EJBEDLHIKDG;
		chatAbuseDialog.NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(chatAbuseDialog);
	}

	private void HINCGMPNNLP(bool GJNGLPOBFJI)
	{
		AOOMNFPKFKK.enabled = GJNGLPOBFJI;
		BCEICONFFFP.color = ((!GJNGLPOBFJI) ? Color.white.ReplaceA(1586f) : Color.white);
		GHBDJCJDEIK.enabled = GJNGLPOBFJI;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	public virtual void PAKCFABJKAG()
	{
		GJHAIDKBCEA.HNNCHPPGJBI();
		HINCGMPNNLP(GJNGLPOBFJI: false);
	}

	public GuiElement EEAHKOCLJHB()
	{
		return this;
	}

	public virtual void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HPMCJAPKFPF));
		UIEventListener uIEventListener2 = UIEventListener.Get(COBFKLAHJBC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HCOMBPLJLNL));
		UIEventListener uIEventListener3 = UIEventListener.Get(GHBDJCJDEIK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OFKAFCNDNDA));
		LLEBDFOLOPF();
		GJHAIDKBCEA.GJHAIDKBCEA.HGJOJDPJEAB();
		GJHAIDKBCEA.BKEHEAILAOC(EOMJPIIDPDA);
	}

	private void OnSelect(string IFNHPCMPNHF, UILabel FKLKLCBOMNE)
	{
		if (base.isFullyShowed)
		{
			JKOIDJICNFE(GJNGLPOBFJI: true);
			FKLKLCBOMNE.color = Colours.grayDark;
			if (!EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				LLEBDFOLOPF();
			}
			if (EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OLOLINICHII = EOPOCHJMJDH[IFNHPCMPNHF];
			}
			else
			{
				OLOLINICHII = AKKPDFHEEIP.Advertising;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		GJHAIDKBCEA.ResetToDefault();
		JKOIDJICNFE(GJNGLPOBFJI: false);
	}

	public virtual void JCGDALOBGHO()
	{
		GJHAIDKBCEA.ResetToDefault();
		JKOIDJICNFE(GJNGLPOBFJI: false);
	}

	private void OFKAFCNDNDA(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			Singleton<BeanstalkServerManager>.instance.OCNNDLCHFFI(GCNLDDCMBEO, NGDKKFFCGCI, (int)OLOLINICHII);
			HideDialog();
		}
	}

	private void LIBOLNKBEAG(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<BeanstalkServerManager>.instance.OCNNDLCHFFI(GCNLDDCMBEO, NGDKKFFCGCI, (int)OLOLINICHII);
			HideDialog();
		}
	}

	public virtual void LHMMLMPFHOH()
	{
		GKOHJGFKPAH(APCMHDINKEI.gameObject);
	}

	private void HCOMBPLJLNL(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void AKDILOGFMHM(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			Singleton<BeanstalkServerManager>.instance.OCNNDLCHFFI(GCNLDDCMBEO, NGDKKFFCGCI, (int)OLOLINICHII);
			HideDialog();
		}
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	public GuiElement KBCHMKHIADB()
	{
		return this;
	}

	public GuiElement HJFNBHHEGIF()
	{
		return this;
	}

	public static void NPLFEHOLMFC(string EJBEDLHIKDG, string PNAKMCNGGHE)
	{
		ChatAbuseDialog chatAbuseDialog = GuiElementSingle<ChatAbuseDialog>.instance;
		chatAbuseDialog.GCNLDDCMBEO = EJBEDLHIKDG;
		chatAbuseDialog.NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(chatAbuseDialog, 1570f);
	}

	public static void LEAIHNFLBBH(string EJBEDLHIKDG, string PNAKMCNGGHE)
	{
		ChatAbuseDialog chatAbuseDialog = GuiElementSingle<ChatAbuseDialog>.instance;
		chatAbuseDialog.GCNLDDCMBEO = EJBEDLHIKDG;
		chatAbuseDialog.NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(chatAbuseDialog, 1698f);
	}

	private void FMIOFHDDJBL(string IFNHPCMPNHF, UILabel FKLKLCBOMNE)
	{
		if (BKIGLABDGCP())
		{
			JKOIDJICNFE(GJNGLPOBFJI: false);
			FKLKLCBOMNE.color = Colours.grayDark;
			if (!EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				KPHIIOLBPMM();
			}
			if (EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OLOLINICHII = EOPOCHJMJDH[IFNHPCMPNHF];
			}
			else
			{
				OLOLINICHII = AKKPDFHEEIP.CheatInfo;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	public virtual void NGHAPNEFBED()
	{
		GJHAIDKBCEA.PDKLGKEPAOB();
		HINCGMPNNLP(GJNGLPOBFJI: true);
	}

	public virtual void POFPIJKJFBP()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = true;
	}

	public GuiElement KBCELKIEAAM()
	{
		return this;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void LEBHABIBHCC(string IFNHPCMPNHF, UILabel FKLKLCBOMNE)
	{
		if (base.isFullyShowed)
		{
			JKOIDJICNFE(GJNGLPOBFJI: false);
			FKLKLCBOMNE.color = Colours.grayDark;
			if (!EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OIBHKCKGDHD();
			}
			if (EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OLOLINICHII = EOPOCHJMJDH[IFNHPCMPNHF];
			}
			else
			{
				OLOLINICHII = AKKPDFHEEIP.CheatInfo;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	private void PILIPDAFILP(string IFNHPCMPNHF, UILabel FKLKLCBOMNE)
	{
		if (BKIGLABDGCP())
		{
			HINCGMPNNLP(GJNGLPOBFJI: false);
			FKLKLCBOMNE.color = Colours.grayDark;
			if (!EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OIBHKCKGDHD();
			}
			if (EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OLOLINICHII = EOPOCHJMJDH[IFNHPCMPNHF];
			}
			else
			{
				OLOLINICHII = AKKPDFHEEIP.Advertising;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	private void EOMJPIIDPDA(string IFNHPCMPNHF, UILabel FKLKLCBOMNE)
	{
		if (MHAIBHBGBOO())
		{
			HINCGMPNNLP(GJNGLPOBFJI: false);
			FKLKLCBOMNE.color = Colours.grayDark;
			if (!EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				LLEBDFOLOPF();
			}
			if (EOPOCHJMJDH.ContainsKey(IFNHPCMPNHF))
			{
				OLOLINICHII = EOPOCHJMJDH[IFNHPCMPNHF];
			}
			else
			{
				OLOLINICHII = AKKPDFHEEIP.Advertising;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	public virtual void NAOJCFMFLLA()
	{
		GJHAIDKBCEA.CIECFDGFGEJ();
		JKOIDJICNFE(GJNGLPOBFJI: true);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public virtual void LAALCOMHIPK()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.NFLPPGKCOBL.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.NFLPPGKCOBL.forceDrag = false;
	}

	public static void FKNOGHKJGNK(string EJBEDLHIKDG, string PNAKMCNGGHE)
	{
		ChatAbuseDialog chatAbuseDialog = GuiElementSingle<ChatAbuseDialog>.instance;
		chatAbuseDialog.GCNLDDCMBEO = EJBEDLHIKDG;
		chatAbuseDialog.NGDKKFFCGCI = PNAKMCNGGHE;
		Singleton<GuiManager>.instance.ShowDialog(chatAbuseDialog, 574f);
	}

	private void OIBHKCKGDHD()
	{
		if (EOPOCHJMJDH == null)
		{
			EOPOCHJMJDH = new Dictionary<string, AKKPDFHEEIP>();
		}
		if (EOPOCHJMJDH.Count > 1)
		{
			EOPOCHJMJDH.Clear();
		}
		EOPOCHJMJDH.Add("Pending", AKKPDFHEEIP.CheatInfo);
		EOPOCHJMJDH.Add("setTwitterUserId", AKKPDFHEEIP.ChildSolicitation);
		EOPOCHJMJDH.Add("Gold", AKKPDFHEEIP.OffensiveLanguage);
		EOPOCHJMJDH.Add("{0} {1}", AKKPDFHEEIP.HarassmentOrStalking);
		EOPOCHJMJDH.Add("OnPhotonJoinRoomFailed: {0}, message {1}", AKKPDFHEEIP.ChildSolicitation);
		EOPOCHJMJDH.Add("Time", AKKPDFHEEIP.HateSpeech);
		EOPOCHJMJDH.Add(". Loading default...", AKKPDFHEEIP.HarassmentOrStalking);
		EOPOCHJMJDH.Add("Sniper", AKKPDFHEEIP.SexualOrVulgarContent);
		EOPOCHJMJDH.Add("PlayerInfo", AKKPDFHEEIP.CheatInfo);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(APCMHDINKEI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(COBFKLAHJBC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(GHBDJCJDEIK.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DKMDDMJNFIK));
		LLEBDFOLOPF();
		GJHAIDKBCEA.GJHAIDKBCEA.SetDefaultValue();
		GJHAIDKBCEA.OnSelect += OnSelect;
	}
}
