using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FacebookDialog : GuiElementSingle<FacebookDialog>, PAIIOKBBHBC
{
	[FormerlySerializedAs("KBBHFLOCIIO")]
	[Header("Texts")]
	public UILabel FENCIKLNFKD;

	[FormerlySerializedAs("FHGPGLKCOFA")]
	public UILabel GBPHFDDKOGO;

	[Header("Buttons")]
	[FormerlySerializedAs("GGHCPHAOKGE")]
	public UIButton CNHGMFMHKIK;

	[FormerlySerializedAs("ALFFKFMEMDF")]
	public UILabel AGFAPMGFFPC;

	[FormerlySerializedAs("PHPONADFDKI")]
	public UIButton CFKJJJAOKHE;

	private Action<bool> CLEOCMPJPON;

	private void HJCGEPOGGCC(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	private void PDIKGHHCPDJ(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void PGPFDLFAIBN()
	{
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public void CIHDKPIFMAG(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("grenadeExplosion");
		GBPHFDDKOGO.text = Localization.Localize("isGameCenter");
		AGFAPMGFFPC.text = Localization.Localize("country-estonia");
		Singleton<GuiManager>.instance.ShowDialog(this, 445f);
	}

	private void IJHIHLOANAJ(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void MHFIIKEFGKG()
	{
		GNLKHPLJFHG(CFKJJJAOKHE.gameObject);
	}

	private void DMNMBKPDJKN(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void OAMMJCEIFHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CKDEHFHFIKK));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AAEIGIPNHLJ));
	}

	public virtual void CCLAJHMFLDF()
	{
		GMMPDGAOEIO(CFKJJJAOKHE.gameObject);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LAFMFGGDJGK));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OOMGIAKJKLM));
	}

	public GuiElement NEDDABHBCLE()
	{
		return this;
	}

	public void KAGJKGCIOBI(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("Decline_Rental");
		GBPHFDDKOGO.text = Localization.Localize("Dron could not be spawned");
		AGFAPMGFFPC.text = Localization.Localize("ID_COLLECTXCHRISTMASCRATES");
		Singleton<GuiManager>.instance.ShowDialog(this, 73f);
	}

	public override void InitGUIValues()
	{
	}

	public override void GENKPBNDOCB()
	{
		NONGMLKEDHK(CFKJJJAOKHE.gameObject);
	}

	public virtual void PFCKKOBABEL()
	{
		PDIKGHHCPDJ(CFKJJJAOKHE.gameObject);
	}

	private void HJGNJDJFACD(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public void BLFIDDDMDPN(bool FHLOIEFEIME, Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		string text = "minDamage";
		text = "ID_ACCEPT";
		FENCIKLNFKD.text = Localization.Localize("}");
		GBPHFDDKOGO.text = Localization.Localize((!FHLOIEFEIME) ? text : "nonEliteUnits");
		AGFAPMGFFPC.text = Localization.Localize("ID_RATEAPPTEXT");
		Singleton<GuiManager>.instance.ShowDialog(this, 234f);
	}

	public virtual void BNCDFKGNPII()
	{
		OOMGIAKJKLM(CFKJJJAOKHE.gameObject);
	}

	public virtual void KBDBBNCMDAK()
	{
		JJEBAJDNGKO(CFKJJJAOKHE.gameObject);
	}

	public void KLMIMINLJEA(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("Error Handler: Player si vybral zruseni GC uctu a pridani udaju k tomuto uctu");
		GBPHFDDKOGO.text = Localization.Localize("PlayerProgressRate");
		AGFAPMGFFPC.text = Localization.Localize("ID_SALEPERCENT");
		Singleton<GuiManager>.instance.ShowDialog(this, 251f);
	}

	private void ILCLKLMOAFG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public void MBDJOHOHMMA(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。許可がないとゲームが機能できず、閉じてしまいます。再試行するか、WarFriendsをやめてください。");
		GBPHFDDKOGO.text = Localization.Localize("country-egypt");
		AGFAPMGFFPC.text = Localization.Localize("ID_WARNING_MAINTENANCE");
		Singleton<GuiManager>.instance.ShowDialog(this, 1283f);
	}

	public void JJHMNGMPDCH(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("game-ico-speed");
		GBPHFDDKOGO.text = Localization.Localize("DeviceToken");
		AGFAPMGFFPC.text = Localization.Localize("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhOR82yQJKu6ymLcFyTQEFkgs7PfSVXPSWcLC1JtdbMTNUmNfoM0up/7/8nRGzquPkZKF0KwVzJZJepHRzRXJiZwhGgMvDNAjwilqKAWcVGbIZPbDBZCJWxqQDgs+Ma4Pr7cPV48tDSHFPzcDxGUvfjl+sOdb1GTBZLDr3XvzBwjOwrQ5wbiY7/YdZYiv0I3UfQzmxOL9a1XfzAI1M5TcAS4vE32dPRYTM72+pt+Vr2kPuY8rF9E5RcGBWLQHuyPg9vPBre2hJPAKWJUUKrLJmxwS+mS/yv/ROkpQgKslIRHzJBmuLaLwBJyU4ZR1UAYlnzafHj/CJv96Y+7TUiY/ZwIDAQAB");
		Singleton<GuiManager>.instance.ShowDialog(this, 1104f);
	}

	public void CAMMABDPOIH(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("These IDs are not in dictionary XLS:\n");
		GBPHFDDKOGO.text = Localization.Localize("groundBoxHit");
		AGFAPMGFFPC.text = Localization.Localize("PreloadAdForZoneID");
		Singleton<GuiManager>.instance.ShowDialog(this, 714f);
	}

	public void ShowLoginDialog(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("ID_FACEBOOKCONNECT");
		GBPHFDDKOGO.text = Localization.Localize("ID_FACEBOOKLOGINLEGALTEXT");
		AGFAPMGFFPC.text = Localization.Localize("ID_SIGNIN");
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void JNLAEKOOMMH()
	{
	}

	public virtual void JNPMCOCIICG()
	{
		ILCLKLMOAFG(CFKJJJAOKHE.gameObject);
	}

	public void DHBNFKGBKND(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("ID_TUTORIAL_RIFLE_UP");
		GBPHFDDKOGO.text = Localization.Localize("Yes_Clicked");
		AGFAPMGFFPC.text = Localization.Localize(")");
		Singleton<GuiManager>.instance.ShowDialog(this, 1382f);
	}

	public void ShowLogoutDialog(bool FHLOIEFEIME, Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		string text = "ID_FACEBOOKLOGOUTLEGALTEXT";
		text = "ID_FACEBOOKLOGOUTLEGALTEXTA";
		FENCIKLNFKD.text = Localization.Localize("ID_FACEBOOKLOGOUT");
		GBPHFDDKOGO.text = Localization.Localize((!FHLOIEFEIME) ? text : "ID_FACEBOOKLOGOUTLEGALTEXT2");
		AGFAPMGFFPC.text = Localization.Localize("ID_SIGNOUT");
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void FNBEDNKDCII(bool FHLOIEFEIME, Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		string text = "{0} {1} {2}/ {3}[-]";
		text = "Weapon model not found! weaponprefab = '{0}' assetBundleName = '{1}'";
		FENCIKLNFKD.text = Localization.Localize("On Level Squad Up");
		GBPHFDDKOGO.text = Localization.Localize((!FHLOIEFEIME) ? text : "IsLocal");
		AGFAPMGFFPC.text = Localization.Localize("Squad Member record does not have DatabasePlayer");
		Singleton<GuiManager>.instance.ShowDialog(this, 520f);
	}

	private void JGIFHDEAGCB(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public GuiElement KBCHMKHIADB()
	{
		return this;
	}

	private void FMIOBEIBMLP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void HEMPLECIOMI()
	{
		OOMGIAKJKLM(CFKJJJAOKHE.gameObject);
	}

	public void AOAAMLLILAD(bool FHLOIEFEIME, Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		string text = "!!!UNDER TABLE!!! ";
		text = "Arena Lost - Scraps received = ";
		FENCIKLNFKD.text = Localization.Localize("Emblem updated!");
		GBPHFDDKOGO.text = Localization.Localize((!FHLOIEFEIME) ? text : "AtlasPreparer.LoadTutorialCoroutine");
		AGFAPMGFFPC.text = Localization.Localize("game-card-ico-bg-silver");
		Singleton<GuiManager>.instance.ShowDialog(this, 272f);
	}

	public virtual void OOBJHJLMEED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CKDEHFHFIKK));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LCCGMMMDINI));
	}

	public void MKJANDGAPFF(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("{0} / [FECA21]{1}");
		GBPHFDDKOGO.text = Localization.Localize("ID_STARTERASSIGNMENT");
		AGFAPMGFFPC.text = Localization.Localize("ID_BRONZEPACK");
		Singleton<GuiManager>.instance.ShowDialog(this, 1532f);
	}

	private void FENDHAEIPOA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	private void MBBIHGIPINA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	private void AAEIGIPNHLJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void OCACKBJDEHI()
	{
	}

	private void DJDIAMGLBHP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	private void JNLOCOOOFLE(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	private void NONGMLKEDHK(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void IDKBKFNPAPD()
	{
		DJDIAMGLBHP(CFKJJJAOKHE.gameObject);
	}

	private void ACBAOHAMHLD(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public void ELJDPDKBBNP(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE");
		GBPHFDDKOGO.text = Localization.Localize("CONFIRM");
		AGFAPMGFFPC.text = Localization.Localize("DepositedCards");
		Singleton<GuiManager>.instance.ShowDialog(this, 28f);
	}

	private void CKDEHFHFIKK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public void ODBIAGNMGFN(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("-");
		GBPHFDDKOGO.text = Localization.Localize("Days_Since_Install");
		AGFAPMGFFPC.text = Localization.Localize("FacebookId");
		Singleton<GuiManager>.instance.ShowDialog(this, 404f);
	}

	public void AGNKAJJBNAJ(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("    ");
		GBPHFDDKOGO.text = Localization.Localize("{0}{1}{2} {3}{4} {5}{6} {7}{8}");
		AGFAPMGFFPC.text = Localization.Localize("S");
		Singleton<GuiManager>.instance.ShowDialog(this, 1212f);
	}

	public void OCEJNPCCIJF(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("Arena Lost - you gain scraps. You have {0} lives.");
		GBPHFDDKOGO.text = Localization.Localize("FuseBox Event DuplicateLootbox for {0}");
		AGFAPMGFFPC.text = Localization.Localize("PlayerId");
		Singleton<GuiManager>.instance.ShowDialog(this, 1072f);
	}

	public GuiElement LHIPJNFMBHL()
	{
		return this;
	}

	public void HIHKDLPNOPG(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("country-noflag");
		GBPHFDDKOGO.text = Localization.Localize("T");
		AGFAPMGFFPC.text = Localization.Localize("ID_VALUEPACKINFORMATIONS");
		Singleton<GuiManager>.instance.ShowDialog(this, 1771f);
	}

	public virtual void PLDBDGJLOFP()
	{
	}

	public GuiElement ANDPIIIFIAA()
	{
		return this;
	}

	public void KIHAGABOCOP(bool FHLOIEFEIME, Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		string text = "FEMALE";
		text = "added";
		FENCIKLNFKD.text = Localization.Localize(" : ");
		GBPHFDDKOGO.text = Localization.Localize((!FHLOIEFEIME) ? text : "Evaluation is old! ");
		AGFAPMGFFPC.text = Localization.Localize("game-elite-debuff1");
		Singleton<GuiManager>.instance.ShowDialog(this, 1130f);
	}

	public void KMAAOPFCECL(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("Card_3_Played");
		GBPHFDDKOGO.text = Localization.Localize("TransactionId123");
		AGFAPMGFFPC.text = Localization.Localize("T");
		Singleton<GuiManager>.instance.ShowDialog(this, 1444f);
	}

	private void JAGILPLALJO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void CJCAGMPFPFD()
	{
	}

	public virtual void HCGDNLHIOBL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMIOBEIBMLP));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MBBIHGIPINA));
	}

	public virtual void LBLEJMFCBIC()
	{
	}

	private void CLIEHBPOGGM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void CHFHCBLGINB()
	{
	}

	public virtual void IJHNPCPFEKF()
	{
	}

	private void GNLKHPLJFHG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void KPEJMMBDODD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMIOBEIBMLP));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PDIKGHHCPDJ));
	}

	private void JJEBAJDNGKO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public void FGJNHKGPFEL(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("{0} {1}");
		GBPHFDDKOGO.text = Localization.Localize("withAdvertiserSubSite");
		AGFAPMGFFPC.text = Localization.Localize("golds");
		Singleton<GuiManager>.instance.ShowDialog(this, 829f);
	}

	private void GMMPDGAOEIO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	private void ABJKAEAANPD(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	private void DGKFOCNOEIH(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void IMKECOIFJFK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MLBKEDJDBBO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMMPDGAOEIO));
	}

	private void NBKHIPMLCNC(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public void ShowGooglePlayLogoutDialog(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("ID_GOOGLEPLAYLOGOUT");
		GBPHFDDKOGO.text = Localization.Localize("ID_GOOGLEPLAYLOGOUTTEXT");
		AGFAPMGFFPC.text = Localization.Localize("ID_SIGNOUT");
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void NHJEMFLFKEB(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("Chat: Trying to get messages from null or empty channelName");
		GBPHFDDKOGO.text = Localization.Localize("Get player data: I SHOULD SEND PN DEVICET TOKEN");
		AGFAPMGFFPC.text = Localization.Localize("Particle with name: ");
		Singleton<GuiManager>.instance.ShowDialog(this, 1909f);
	}

	public virtual void PAIKCHDABEJ()
	{
		KHGAJDECFOO(CFKJJJAOKHE.gameObject);
	}

	private void ABAJOGAILJE(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void BNEPKGCDIFH()
	{
	}

	public GuiElement CBANDKHPNBD()
	{
		return this;
	}

	public virtual void OIGFBFFNNHH()
	{
	}

	public void BFGODALHLOD(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("Shots_Fired");
		GBPHFDDKOGO.text = Localization.Localize("Player_Had_To_Select_Grenade");
		AGFAPMGFFPC.text = Localization.Localize("-");
		Singleton<GuiManager>.instance.ShowDialog(this, 1134f);
	}

	public virtual void AIIJHNNODDM()
	{
		HJGNJDJFACD(CFKJJJAOKHE.gameObject);
	}

	private void JEIBDAAMFGE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void CKGGNJACIGL()
	{
		NONGMLKEDHK(CFKJJJAOKHE.gameObject);
	}

	public virtual void NHKGKDBAKLH()
	{
	}

	public GuiElement FJECJLFIIKB()
	{
		return this;
	}

	public override void OnBack()
	{
		OOMGIAKJKLM(CFKJJJAOKHE.gameObject);
	}

	public virtual void KPHJFKCOIIF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EPOGHJJHCHG));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LCCGMMMDINI));
	}

	private void LAFMFGGDJGK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LAFMFGGDJGK));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CFMKAJEAFGF));
	}

	public GuiElement OGIAJOCDPMF()
	{
		return this;
	}

	private void GMEHPNHCOEL(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public void NONEOAOFPCC(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("Custom string = ");
		GBPHFDDKOGO.text = Localization.Localize("Have discount {0} to upgrade {1}");
		AGFAPMGFFPC.text = Localization.Localize("Grenade_Throwing_Tutorial_Duration");
		Singleton<GuiManager>.instance.ShowDialog(this, 410f);
	}

	private void OOMGIAKJKLM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	private void JHNGNCBLDAO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public void PEJACJKFLMH(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("menu-info-ico");
		GBPHFDDKOGO.text = Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_4");
		AGFAPMGFFPC.text = Localization.Localize("Directory \"{0}\" does not exists");
		Singleton<GuiManager>.instance.ShowDialog(this, 1130f);
	}

	public virtual void MMFBOMDHGPL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EPOGHJJHCHG));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JJEBAJDNGKO));
	}

	public void GJMMPJGEMBC(bool FHLOIEFEIME, Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		string text = "Cards_Owned_Bronze";
		text = "Yes_Clicked";
		FENCIKLNFKD.text = Localization.Localize("http://tos.ea.com/legalapp/WEBTERMS/US/");
		GBPHFDDKOGO.text = Localization.Localize((!FHLOIEFEIME) ? text : "withSearchString");
		AGFAPMGFFPC.text = Localization.Localize(" ");
		Singleton<GuiManager>.instance.ShowDialog(this, 1045f);
	}

	private void CFMKAJEAFGF(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public void OJKEGEEFDHP(bool FHLOIEFEIME, Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		string text = "ID_SQUADPLACE";
		text = "TÉLÉCHARGER";
		FENCIKLNFKD.text = Localization.Localize("SpecialPackFromServer");
		GBPHFDDKOGO.text = Localization.Localize((!FHLOIEFEIME) ? text : "ja");
		AGFAPMGFFPC.text = Localization.Localize("_Wind");
		Singleton<GuiManager>.instance.ShowDialog(this, 1802f);
	}

	private void AFLIHKOFOPK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}

	private void EPOGHJJHCHG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	private void MJFAMINDBOM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public void EDIBHMJKFIC(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("S");
		GBPHFDDKOGO.text = Localization.Localize("Disconnect, clicked on dialog !!!");
		AGFAPMGFFPC.text = Localization.Localize("Bad player visuals, data= ");
		Singleton<GuiManager>.instance.ShowDialog(this, 83f);
	}

	public void NNMBENNACOA(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("PromotedPlayerId");
		GBPHFDDKOGO.text = Localization.Localize("DatabaseMessage - SquadDemoteMessage:\nPlayer to be demoted/kicked: {0}\nNewRank: {1}\nBy Player: {2}");
		AGFAPMGFFPC.text = Localization.Localize("Loading - cancel clicked, will to try call disconnect");
		Singleton<GuiManager>.instance.ShowDialog(this, 1957f);
	}

	public void CNCLONDCHLO(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("ActivateBonusResultRPC");
		GBPHFDDKOGO.text = Localization.Localize("SquadPoints");
		AGFAPMGFFPC.text = Localization.Localize("Sniper_Tutorial_Played");
		Singleton<GuiManager>.instance.ShowDialog(this, 884f);
	}

	public virtual void EEFCNPGAODO()
	{
		CFMKAJEAFGF(CFKJJJAOKHE.gameObject);
	}

	public GuiElement IDJAIBECBDG()
	{
		return this;
	}

	private void GBHPLHPHEMN(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	private void KHGAJDECFOO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: true);
				CLEOCMPJPON = null;
			}
		}
	}

	public GuiElement FKCNDEANKNA()
	{
		return this;
	}

	private void LCCGMMMDINI(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public void OBNBIIIECEO(Action<bool> AAPECJCHKKM)
	{
		CLEOCMPJPON = AAPECJCHKKM;
		FENCIKLNFKD.text = Localization.Localize("SquadEventProgress");
		GBPHFDDKOGO.text = Localization.Localize("ID_GUI_EQUIP");
		AGFAPMGFFPC.text = Localization.Localize("_CameraWS");
		Singleton<GuiManager>.instance.ShowDialog(this, 107f);
	}

	public GuiElement HJFNBHHEGIF()
	{
		return this;
	}

	public virtual void DLNJFMIDPFE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CNHGMFMHKIK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JHNGNCBLDAO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CFKJJJAOKHE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PDIKGHHCPDJ));
	}

	private void MLBKEDJDBBO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			if (CLEOCMPJPON != null)
			{
				CLEOCMPJPON(obj: false);
				CLEOCMPJPON = null;
			}
		}
	}

	public GuiElement FIJIHPBMBHK()
	{
		return this;
	}
}
