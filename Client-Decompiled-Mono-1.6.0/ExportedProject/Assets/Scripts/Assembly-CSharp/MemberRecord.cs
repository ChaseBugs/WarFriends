using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MemberRecord : PoolableObject
{
	private sealed class MFMMBNAODNM
	{
		internal string BFFNFDCGCGD;

		internal MemberRecord BJGCPDNMHDH;

		internal void CHDOECNGOPM(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-103), BFFNFDCGCGD);
				BJGCPDNMHDH.CPKHOPOJNFO();
				Singleton<BeanstalkServerManager>.instance.KGKEPBPJDDA(BFFNFDCGCGD);
				Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("SetNoDamageChanceRPC");
			}
		}

		internal void NAJNECOMDDN(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.CDFBHCPDGGG();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-76), BFFNFDCGCGD);
				BJGCPDNMHDH.CPKHOPOJNFO();
				Singleton<BeanstalkServerManager>.instance.KGKEPBPJDDA(BFFNFDCGCGD);
				Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_CONFIRM_SQUADFULL");
			}
		}

		internal void NNIJEDKBPGJ(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-34), BFFNFDCGCGD);
				BJGCPDNMHDH.NOGNELCFFJE();
				Singleton<BeanstalkServerManager>.instance.KPGJOGPFNHD(BFFNFDCGCGD);
				Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_CONFIRM_TEMPORARBAN");
			}
		}

		internal void KNJBDOADLDO(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-33), BFFNFDCGCGD);
				BJGCPDNMHDH.NOGNELCFFJE();
				Singleton<BeanstalkServerManager>.instance.KGKEPBPJDDA(BFFNFDCGCGD);
				Singleton<EventTrackingManager>.instance.RegisterSquadActivity("SquadWarsPosition");
			}
		}

		internal void LJCDGJKCNEC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.KickPlayer, BFFNFDCGCGD);
				BJGCPDNMHDH.CPKHOPOJNFO();
				Singleton<BeanstalkServerManager>.instance.KPGJOGPFNHD(BFFNFDCGCGD);
				Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Remove_Member");
			}
		}

		internal void FIBGJHCGHJH(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.CDFBHCPDGGG();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-186), BFFNFDCGCGD);
				BJGCPDNMHDH.NOGNELCFFJE();
				Singleton<BeanstalkServerManager>.instance.KPGJOGPFNHD(BFFNFDCGCGD);
				Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("DemotedPlayerId");
			}
		}

		internal void CIFEDFPPPOK(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.CDFBHCPDGGG();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-167), BFFNFDCGCGD);
				BJGCPDNMHDH.CPKHOPOJNFO();
				Singleton<BeanstalkServerManager>.instance.KGKEPBPJDDA(BFFNFDCGCGD);
				Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_ONETICKET");
			}
		}

		internal void KJIFNOJILDB(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.ReadMessage, BFFNFDCGCGD);
				BJGCPDNMHDH.NOGNELCFFJE();
				Singleton<BeanstalkServerManager>.instance.KGKEPBPJDDA(BFFNFDCGCGD);
				Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("0\u00a0");
			}
		}
	}

	private sealed class APAKIKECLNB
	{
		internal DatabasePlayer KHLGDCHJJPB;

		internal MemberRecord BJGCPDNMHDH;

		internal void NAJNECOMDDN(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)15, GameLoginManager.currentPlayer.id);
				BJGCPDNMHDH.CPKHOPOJNFO();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.ExpandHitList, KHLGDCHJJPB.id);
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.UpdateShownRecord(KHLGDCHJJPB.id);
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
			}
		}

		internal void MAKLHLCDIKD(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)25, GameLoginManager.currentPlayer.id);
				BJGCPDNMHDH.CPKHOPOJNFO();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.IgnoreMessage, KHLGDCHJJPB.id);
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.UpdateShownRecord(KHLGDCHJJPB.id);
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
			}
		}

		internal void ECPMEMNKMCB(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-5), GameLoginManager.currentPlayer.id);
				BJGCPDNMHDH.CPKHOPOJNFO();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-32), KHLGDCHJJPB.id);
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.UpdateShownRecord(KHLGDCHJJPB.id);
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
			}
		}

		internal void LJCDGJKCNEC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.PromotePlayerToFounder, GameLoginManager.currentPlayer.id);
				BJGCPDNMHDH.CPKHOPOJNFO();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.PromotePlayerToFounder, KHLGDCHJJPB.id);
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.UpdateShownRecord(KHLGDCHJJPB.id);
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
			}
		}

		internal void MMEEJDGGAID(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.SearchPlayers, GameLoginManager.currentPlayer.id);
				BJGCPDNMHDH.CPKHOPOJNFO();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-97), KHLGDCHJJPB.id);
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.UpdateShownRecord(KHLGDCHJJPB.id);
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
			}
		}

		internal void CIFEDFPPPOK(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-77), GameLoginManager.currentPlayer.id);
				BJGCPDNMHDH.NOGNELCFFJE();
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-53), KHLGDCHJJPB.id);
				GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.UpdateShownRecord(KHLGDCHJJPB.id);
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
			}
		}
	}

	[Header("Width Setter")]
	public UIButtonSetter AHECKDDDOOK;

	[Header("Member Record")]
	public GameObject JKKLBACFOJG;

	public UISprite LCPBNBLGFIA;

	[Header("-Info")]
	public UILabel MPHCNMDIPAI;

	public PlayerIcon DCKFGIKPPGH;

	public GameObject OANICEALFGM;

	public UISprite ALFOJMLJFGD;

	public UISprite GFKNLLCKJOG;

	public UILabel DLAMMHGPADA;

	public UILabel NMACFKPEKPE;

	[Header("--Name")]
	public UITable PJBNCLAPNEL;

	public UILabel MEPFCGAAEEF;

	public BoxCollider CPLIMCNBDBP;

	public GameObject JHKNOIJBDGA;

	public UISprite NPECJCIKCBI;

	public GameObject LDPHDEJABLD;

	public UISprite KKFGBOBIMBB;

	[Header("-Functions and Buttons")]
	public GameObject OMLKMCCKIHJ;

	public GameObject EOEAFOFHOEH;

	public GameObject EOKJEELHAJL;

	public GameObject APHCPLLGGPJ;

	public GameObject AKCCLEDIDOF;

	public GameObject AKIOMBAKDFJ;

	[Header("-Awaiting Part")]
	public GameObject JKOHLKOKBCF;

	public GameObject EKOCDFGMLKG;

	public GameObject IKLJPIOCOPE;

	public GameObject DIBBNCFOCKG;

	public GameObject MJDPLAIOJLP;

	[Header("-Reputation Points")]
	public GameObject PKNIFPDBDGK;

	public UILabel OIMGLJCOHNH;

	[Header("-Squad Points")]
	public GameObject BENNKLLKEPJ;

	public UILabel MFIDOJKMFIK;

	[Header("-Army Power")]
	public UILabel IMKCADNEFGK;

	[Header("-Medals")]
	public UISprite NNMCKEECNFK;

	public UILabel MKKADNBBGLD;

	[Header("-Kick")]
	public GameObject LMODAIJODMF;

	public GameObject CIONFMKEPII;

	public UILabel JPCGFPBGHNM;

	[Header("-Leave")]
	public GameObject MKJKKNCMAHN;

	public GameObject FONAMCEADBM;

	public UILabel OOHFDKDMJLE;

	[Header("Invite Record")]
	public GameObject BELLJDAFDNM;

	public GameObject AINNCGHAGCH;

	[Header("Summary Record")]
	public GameObject AAEMHABJEIO;

	public UITable JFHNMCLHMGN;

	public UILabel DDNJDODDLEA;

	public UILabel GIGJMJGBEGJ;

	public GameObject DMMKOLKELGP;

	private DatabasePlayer EHHDLLGPNBG;

	[CompilerGenerated]
	private static UIEventListener.VoidDelegate LGJCBPOPCPA;

	internal void FNHHNELJEPH(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		GFBLAKJHDJD();
		float num = UIHelper.activeWidthSafe - 120f;
		int num2 = (int)(num - 1470f) + 41;
		AHECKDDDOOK.SetWidth(num);
		JKKLBACFOJG.SetActive(true);
		BELLJDAFDNM.SetActive(false);
		AAEMHABJEIO.SetActive(false);
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(ALAJGOPHOAN);
		string text = GameVariables.CountryCodeSpriteName(ALAJGOPHOAN.country);
		bool flag = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.iconName;
		DLAMMHGPADA.text = levelDefinition.displayString;
		bool flag2 = ALAJGOPHOAN.warArenaCrown != WarArenaCrown.None;
		JHKNOIJBDGA.SetActive(flag2);
		if (flag2)
		{
			num2 -= 40;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[ALAJGOPHOAN.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(30f / NPECJCIKCBI.transform.localScale.x, 40f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag3 = true;
		if (flag3)
		{
			num2 -= 41;
		}
		LDPHDEJABLD.SetActive(flag3);
		KKFGBOBIMBB.color = GameVariables.CKCJBIIPEOG[ALAJGOPHOAN.GetRealStatus()].Value2;
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 0f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 37f, 20f, num2);
		PJBNCLAPNEL.repositionNow = true;
		CPLIMCNBDBP.center = new Vector3((float)num2 / 2f, CPLIMCNBDBP.center.y, CPLIMCNBDBP.center.z);
		CPLIMCNBDBP.size = new Vector3((float)num2 + 20f, CPLIMCNBDBP.size.y, CPLIMCNBDBP.size.z);
		if (ALAJGOPHOAN.awaitingSquadMember)
		{
			DAJOLELGJCD();
		}
		else
		{
			NKIJGOLDIBC(ALAJGOPHOAN);
			PKNIFPDBDGK.SetActive(true);
			OIMGLJCOHNH.text = MEJMLNDFDBP.GMIPFLIEOHD(ALAJGOPHOAN.reputation);
			BENNKLLKEPJ.SetActive(true);
			MFIDOJKMFIK.text = MEJMLNDFDBP.GMIPFLIEOHD(ALAJGOPHOAN.squadPoints);
		}
		IMKCADNEFGK.text = MEJMLNDFDBP.GMIPFLIEOHD(ALAJGOPHOAN.armyPowerX10);
		MEJMLNDFDBP.COCBCFKJOJE(IMKCADNEFGK, 42f, 28f, 113);
		LANNMNDLJEJ(ALAJGOPHOAN);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
	}

	private static void MOHJHOHPADB(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<SquadScreen>.instance.EIMIICGAJNI(KHAHPAKDIKE);
	}

	[CompilerGenerated]
	private void NJADOADFOFO()
	{
		float val = 0f - JFHNMCLHMGN.padding.x - (GIGJMJGBEGJ.transform.parent.transform.localPosition.x - JFHNMCLHMGN.padding.x) / 2f;
		JFHNMCLHMGN.transform.localPosition = JFHNMCLHMGN.transform.localPosition.ReplaceX(val);
	}

	public void KDKKOGBKOAP()
	{
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(EHHDLLGPNBG.id, false, false, true);
			EHHDLLGPNBG = null;
		}
	}

	private void DGPMLLNBHOJ(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("ID_TUTORIAL_WARCARDS_STARTDOWN");
			return;
		}
		if (EHHDLLGPNBG.squadRank == SquadRank.Veteran && !GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.canBePromotedToColeader)
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Army upgrade for "), Localization.Localize("eventEnd"), 859f, null, string.Empty, true, true);
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.CDFBHCPDGGG();
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.GetAllMessages, EHHDLLGPNBG.id);
		CPKHOPOJNFO();
		Singleton<BeanstalkServerManager>.instance.GHJMGKMMKGD(EHHDLLGPNBG);
	}

	private void MNFOEHIIMIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void CNEHPKLAAJL(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("menu-wftv-play-logo-small-black");
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (EHHDLLGPNBG.id != currentPlayer.id)
		{
			Debug.LogError("ID_CONFIRM_PLAYERNAMETAKEN");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
		GuiScreenSingle<SquadScreen>.instance.GBEIDJEFEEC(KHAHPAKDIKE);
	}

	private void FCNKIEPEAAG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.avatar = FCEIGDLFOMH;
			DCKFGIKPPGH.UpdateIcon();
		}
	}

	public virtual void EFBIFEOHMGI()
	{
		base.JMAFCGDIICK();
		UIEventListener uIEventListener = UIEventListener.Get(EOEAFOFHOEH);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KGPHPBODMAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(EOKJEELHAJL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKHALLFNGNB));
		UIEventListener uIEventListener3 = UIEventListener.Get(AKCCLEDIDOF);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DGPMLLNBHOJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(APHCPLLGGPJ);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HCPCFDLHKGJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(AKIOMBAKDFJ);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HCPCFDLHKGJ));
		UIEventListener uIEventListener6 = UIEventListener.Get(IKLJPIOCOPE);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(LJLPKDOAEOK));
		UIEventListener uIEventListener7 = UIEventListener.Get(DIBBNCFOCKG);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(EJIBCOGLDOL));
		UIEventListener uIEventListener8 = UIEventListener.Get(CIONFMKEPII);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(EGDJNBLJDEJ));
		UIEventListener uIEventListener9 = UIEventListener.Get(FONAMCEADBM);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(CNEHPKLAAJL));
		UIEventListener uIEventListener10 = UIEventListener.Get(AINNCGHAGCH);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(MOHJHOHPADB));
	}

	private void PMANFOPBNNN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	internal void MIBBFNNMFDE(int MNGGEHIAAEC, int FAIFMIDDJME)
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		AHECKDDDOOK.SetWidth(activeWidthSafe - 120f);
		JKKLBACFOJG.SetActive(false);
		BELLJDAFDNM.SetActive(false);
		AAEMHABJEIO.SetActive(true);
		EHHDLLGPNBG = null;
		JFHNMCLHMGN.gameObject.SetActive(FAIFMIDDJME > 0);
		DMMKOLKELGP.SetActive(FAIFMIDDJME < 1);
		if (FAIFMIDDJME > 0)
		{
			DDNJDODDLEA.text = Localization.Localize("ID_SQUADSIZEINCREASEATSQUADRANK");
			GIGJMJGBEGJ.text = Localization.LocalizeFormat("ID_CURRENTRANK", FAIFMIDDJME, Colours.stringGrayLight, MNGGEHIAAEC);
			float num = activeWidthSafe - 430f;
			float num2 = DDNJDODDLEA.relativeSize.x + GIGJMJGBEGJ.relativeSize.x;
			float num3 = Mathf.Clamp(num / num2, 20f, 37f);
			DDNJDODDLEA.transform.localScale = new Vector3(num3, num3, 1f);
			GIGJMJGBEGJ.transform.localScale = new Vector3(num3, num3, 1f);
			JFHNMCLHMGN.repositionNow = true;
			JFHNMCLHMGN.onReposition = delegate
			{
				float val = 0f - JFHNMCLHMGN.padding.x - (GIGJMJGBEGJ.transform.parent.transform.localPosition.x - JFHNMCLHMGN.padding.x) / 2f;
				JFHNMCLHMGN.transform.localPosition = JFHNMCLHMGN.transform.localPosition.ReplaceX(val);
			};
		}
	}

	private void KGPHPBODMAB(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
		SelectSquadLeaderDialog.ShowSelectNewSquadLeader(delegate(DatabasePlayer KHLGDCHJJPB, bool NILPBCGHEDG)
		{
			APAKIKECLNB aPAKIKECLNB = new APAKIKECLNB
			{
				KHLGDCHJJPB = KHLGDCHJJPB,
				BJGCPDNMHDH = this
			};
			if (NILPBCGHEDG)
			{
				ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_PROMOTETOLEADER"), Localization.LocalizeFormat("ID_CONFIRM_PROMOTETOLEADER_TEXT", aPAKIKECLNB.KHLGDCHJJPB.name), aPAKIKECLNB.LJCDGJKCNEC);
			}
		}, GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL);
	}

	private void FHCHCBKMCDC(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
		JKOHLKOKBCF.SetActive(false);
		EKOCDFGMLKG.SetActive(true);
		EKOCDFGMLKG.transform.localPosition = EKOCDFGMLKG.transform.localPosition.ReplaceX(0f);
		Singleton<AwaitingSquadMembersManager>.instance.YesClick(EHHDLLGPNBG.id);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Admit_Member");
	}

	private void EJBDEKGFLBE(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("menu-weaponstats-accuracy");
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (EHHDLLGPNBG.id != currentPlayer.id)
		{
			Debug.LogError("Terms: On Age Verification Pending Dialog Display ");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
		GuiScreenSingle<SquadScreen>.instance.LeaveSquadClick(KHAHPAKDIKE);
	}

	private void GFBLAKJHDJD()
	{
		JPCGFPBGHNM.text = Localization.Localize("ID_KICKPLAYER");
		int cEHFMMJHCKC = ((!JPCGFPBGHNM.text.Contains(" ")) ? 120 : 240);
		MEJMLNDFDBP.COCBCFKJOJE(JPCGFPBGHNM, 30f, 20f, cEHFMMJHCKC);
		OOHFDKDMJLE.text = Localization.Localize("ID_LEAVESQUAD");
		int cEHFMMJHCKC2 = ((!OOHFDKDMJLE.text.Contains(" ")) ? 120 : 240);
		MEJMLNDFDBP.COCBCFKJOJE(OOHFDKDMJLE, 30f, 20f, cEHFMMJHCKC2);
	}

	private void BKHALLFNGNB(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("ID_INSTANTBATTLE");
			return;
		}
		if (EHHDLLGPNBG.squadRank == SquadRank.Member && !GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.canBePromotedToColeader)
		{
			WarningDialog.ShowError(Localization.Localize("pistol"), Localization.Localize("user_friends"), 466f, null, string.Empty, true, true);
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-93), EHHDLLGPNBG.id);
		NOGNELCFFJE();
		Singleton<BeanstalkServerManager>.instance.GHJMGKMMKGD(EHHDLLGPNBG);
	}

	private void IJHMOFNMLIL(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (EHHDLLGPNBG.id != currentPlayer.id)
		{
			Debug.LogError("Wrong player id on squadMember, not leaving squad!");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
		GuiScreenSingle<SquadScreen>.instance.LeaveSquadClick(KHAHPAKDIKE);
	}

	[CompilerGenerated]
	private void IHMDBNNCOGI(DatabasePlayer KHLGDCHJJPB, bool NILPBCGHEDG)
	{
		APAKIKECLNB aPAKIKECLNB = new APAKIKECLNB
		{
			KHLGDCHJJPB = KHLGDCHJJPB,
			BJGCPDNMHDH = this
		};
		if (NILPBCGHEDG)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_PROMOTETOLEADER"), Localization.LocalizeFormat("ID_CONFIRM_PROMOTETOLEADER_TEXT", aPAKIKECLNB.KHLGDCHJJPB.name), aPAKIKECLNB.LJCDGJKCNEC);
		}
	}

	private void MGAEFOHCOPD(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = ");
			return;
		}
		if (EHHDLLGPNBG.squadRank == SquadRank.Veteran && !GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.canBePromotedToColeader)
		{
			WarningDialog.ShowError(Localization.Localize("reloadTime"), Localization.Localize("REGISTER BUY PACK EVENT with "), 45f, null, string.Empty, false, true);
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction((DatabaseAction)(-89), EHHDLLGPNBG.id);
		NOGNELCFFJE();
		Singleton<BeanstalkServerManager>.instance.HCEPBIBJLMD(EHHDLLGPNBG);
	}

	[CompilerGenerated]
	private static void MIMGJGDANLA(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<SquadScreen>.instance.InviteToSquadClick(KHAHPAKDIKE);
	}

	private void PFBJELDDLCO(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.GJHFCKMAMIE(FCEIGDLFOMH);
			DCKFGIKPPGH.GGLBLHKGCAO();
		}
	}

	private void AGCNHDNDFNA(DatabasePlayer ALAJGOPHOAN)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (ALAJGOPHOAN.id == currentPlayer.id && ALAJGOPHOAN.squadRank != currentPlayer.squadRank)
		{
			Debug.LogError(string.Format("VipRewardForDay", currentPlayer.squadRank, ALAJGOPHOAN.squadRank));
		}
		int num = 1;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, true);
		if (aANECPGDMGM != null)
		{
			num = aANECPGDMGM.FOICGJEPBGL;
		}
		NMACFKPEKPE.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		OMLKMCCKIHJ.SetActive(false);
		JKOHLKOKBCF.SetActive(false);
		EKOCDFGMLKG.SetActive(true);
		MJDPLAIOJLP.SetActive(true);
		bool flag = ALAJGOPHOAN.id == currentPlayer.id;
		bool flag2 = num > 1;
		int num2 = ((currentPlayer.squadRank == (SquadRank)4) ? 1 : 0);
		bool flag3 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < 1;
		bool flag4 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < num2;
		bool flag5 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, SquadRank.Veteran) > 1;
		bool flag6 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, (SquadRank)8) < 0;
		bool flag7 = !flag5 || flag6;
		bool flag8 = flag2 && currentPlayer.squadRank == SquadRank.Leader;
		EOEAFOFHOEH.SetActive(!flag || flag8);
		EOKJEELHAJL.SetActive(!flag && flag6 && flag3 && flag7);
		APHCPLLGGPJ.SetActive(!flag && flag5 && flag4 && !flag7);
		AKCCLEDIDOF.SetActive(flag || !flag6 || !flag3 || flag7);
		AKIOMBAKDFJ.SetActive(!flag && flag5 && flag4 && flag7);
		LMODAIJODMF.SetActive(flag || flag4);
		MKJKKNCMAHN.SetActive(flag);
		if (GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.IsPlayerWaitingForServerResponse(EHHDLLGPNBG.id))
		{
			CPKHOPOJNFO();
		}
	}

	private void PKCPJCOAFGM(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("ID_TRAINED");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
		JKOHLKOKBCF.SetActive(true);
		EKOCDFGMLKG.SetActive(true);
		EKOCDFGMLKG.transform.localPosition = EKOCDFGMLKG.transform.localPosition.ReplaceX(306f);
		Singleton<AwaitingSquadMembersManager>.instance.PBNHANFMKII(EHHDLLGPNBG.id);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("Sync match start time {0} photon time: {1}");
	}

	private void OBGKANDKHDG(DatabasePlayer ALAJGOPHOAN)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (ALAJGOPHOAN.id == currentPlayer.id && ALAJGOPHOAN.squadRank != currentPlayer.squadRank)
		{
			Debug.LogError(string.Format("?.", currentPlayer.squadRank, ALAJGOPHOAN.squadRank));
		}
		int num = 1;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, true);
		if (aANECPGDMGM != null)
		{
			num = aANECPGDMGM.FOICGJEPBGL;
		}
		NMACFKPEKPE.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		OMLKMCCKIHJ.SetActive(false);
		JKOHLKOKBCF.SetActive(true);
		EKOCDFGMLKG.SetActive(false);
		MJDPLAIOJLP.SetActive(false);
		bool flag = ALAJGOPHOAN.id == currentPlayer.id;
		bool flag2 = num > 0;
		int num2 = ((currentPlayer.squadRank != (SquadRank)6) ? 1 : 0);
		bool flag3 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < 0;
		bool flag4 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < num2;
		bool flag5 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, SquadRank.Veteran) > 0;
		bool flag6 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, (SquadRank)4) < 1;
		bool flag7 = !flag5 || flag6;
		bool flag8 = flag2 && currentPlayer.squadRank == SquadRank.Coleader;
		EOEAFOFHOEH.SetActive(flag && flag8);
		EOKJEELHAJL.SetActive(!flag && flag6 && flag3 && !flag7);
		APHCPLLGGPJ.SetActive(flag || !flag5 || !flag4 || flag7);
		AKCCLEDIDOF.SetActive(flag || !flag6 || !flag3 || flag7);
		AKIOMBAKDFJ.SetActive(flag || !flag5 || !flag4 || flag7);
		LMODAIJODMF.SetActive(flag || flag4);
		MKJKKNCMAHN.SetActive(flag);
		if (GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.IsPlayerWaitingForServerResponse(EHHDLLGPNBG.id))
		{
			CPKHOPOJNFO();
		}
	}

	private static void PNHAGLJAKIN(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<SquadScreen>.instance.EIMIICGAJNI(KHAHPAKDIKE);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener.Get(EOEAFOFHOEH).onClick = null;
		UIEventListener.Get(EOKJEELHAJL).onClick = null;
		UIEventListener.Get(AKCCLEDIDOF).onClick = null;
		UIEventListener.Get(APHCPLLGGPJ).onClick = null;
		UIEventListener.Get(AKIOMBAKDFJ).onClick = null;
		UIEventListener.Get(IKLJPIOCOPE).onClick = null;
		UIEventListener.Get(DIBBNCFOCKG).onClick = null;
		UIEventListener.Get(CIONFMKEPII).onClick = null;
		UIEventListener.Get(FONAMCEADBM).onClick = null;
		UIEventListener.Get(AINNCGHAGCH).onClick = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		FreeTexture();
	}

	private void EJIBCOGLDOL(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
		JKOHLKOKBCF.SetActive(false);
		EKOCDFGMLKG.SetActive(true);
		EKOCDFGMLKG.transform.localPosition = EKOCDFGMLKG.transform.localPosition.ReplaceX(0f);
		Singleton<AwaitingSquadMembersManager>.instance.NoClick(EHHDLLGPNBG.id);
	}

	public virtual void LDNNOAEHNII()
	{
		base.HPPIBGEJMNL();
		UIEventListener uIEventListener = UIEventListener.Get(EOEAFOFHOEH);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KGPHPBODMAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(EOKJEELHAJL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DGPMLLNBHOJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(AKCCLEDIDOF);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DGPMLLNBHOJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(APHCPLLGGPJ);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HCPCFDLHKGJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(AKIOMBAKDFJ);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HCPCFDLHKGJ));
		UIEventListener uIEventListener6 = UIEventListener.Get(IKLJPIOCOPE);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(FHCHCBKMCDC));
		UIEventListener uIEventListener7 = UIEventListener.Get(DIBBNCFOCKG);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(EJIBCOGLDOL));
		UIEventListener uIEventListener8 = UIEventListener.Get(CIONFMKEPII);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(EGDJNBLJDEJ));
		UIEventListener uIEventListener9 = UIEventListener.Get(FONAMCEADBM);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(CNEHPKLAAJL));
		UIEventListener uIEventListener10 = UIEventListener.Get(AINNCGHAGCH);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(PNHAGLJAKIN));
	}

	private void JHHFOKHDGJL()
	{
		NMACFKPEKPE.text = Localization.Localize("setAltitude");
		EFECGFGNLIE eFECGFGNLIE = Singleton<AwaitingSquadMembersManager>.instance.CBJAPGHKKLC(EHHDLLGPNBG.id);
		JKOHLKOKBCF.SetActive(eFECGFGNLIE == EFECGFGNLIE.Response);
		EKOCDFGMLKG.SetActive(eFECGFGNLIE == EFECGFGNLIE.Response);
		MJDPLAIOJLP.SetActive(eFECGFGNLIE == (EFECGFGNLIE)8);
		OMLKMCCKIHJ.SetActive(true);
		BENNKLLKEPJ.SetActive(true);
		PKNIFPDBDGK.SetActive(false);
		LMODAIJODMF.SetActive(true);
		MKJKKNCMAHN.SetActive(true);
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		UIEventListener uIEventListener = UIEventListener.Get(EOEAFOFHOEH);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KGPHPBODMAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(EOKJEELHAJL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BMCNAFNMCOI));
		UIEventListener uIEventListener3 = UIEventListener.Get(AKCCLEDIDOF);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BMCNAFNMCOI));
		UIEventListener uIEventListener4 = UIEventListener.Get(APHCPLLGGPJ);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HCPCFDLHKGJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(AKIOMBAKDFJ);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HCPCFDLHKGJ));
		UIEventListener uIEventListener6 = UIEventListener.Get(IKLJPIOCOPE);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(FHCHCBKMCDC));
		UIEventListener uIEventListener7 = UIEventListener.Get(DIBBNCFOCKG);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(EJIBCOGLDOL));
		UIEventListener uIEventListener8 = UIEventListener.Get(CIONFMKEPII);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(EGDJNBLJDEJ));
		UIEventListener uIEventListener9 = UIEventListener.Get(FONAMCEADBM);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(IJHMOFNMLIL));
		UIEventListener uIEventListener10 = UIEventListener.Get(AINNCGHAGCH);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, (UIEventListener.VoidDelegate)delegate(GameObject KHAHPAKDIKE)
		{
			GuiScreenSingle<SquadScreen>.instance.InviteToSquadClick(KHAHPAKDIKE);
		});
	}

	private void NOGNELCFFJE()
	{
		EOEAFOFHOEH.SetActive(false);
		EOKJEELHAJL.SetActive(false);
		APHCPLLGGPJ.SetActive(true);
		AKCCLEDIDOF.SetActive(false);
		AKIOMBAKDFJ.SetActive(true);
		MKJKKNCMAHN.SetActive(true);
		LMODAIJODMF.SetActive(false);
		EKOCDFGMLKG.gameObject.SetActive(false);
		EKOCDFGMLKG.transform.localPosition = EKOCDFGMLKG.transform.localPosition.ReplaceX(1081f);
	}

	private void DAJOLELGJCD()
	{
		NMACFKPEKPE.text = Localization.Localize("ID_PENDING");
		EFECGFGNLIE eFECGFGNLIE = Singleton<AwaitingSquadMembersManager>.instance.MemberState(EHHDLLGPNBG.id);
		JKOHLKOKBCF.SetActive(eFECGFGNLIE == EFECGFGNLIE.Response);
		EKOCDFGMLKG.SetActive(eFECGFGNLIE == EFECGFGNLIE.Waiting);
		MJDPLAIOJLP.SetActive(eFECGFGNLIE == EFECGFGNLIE.Error);
		OMLKMCCKIHJ.SetActive(false);
		BENNKLLKEPJ.SetActive(false);
		PKNIFPDBDGK.SetActive(false);
		LMODAIJODMF.SetActive(false);
		MKJKKNCMAHN.SetActive(false);
	}

	private void LJLPKDOAEOK(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Packs");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
		JKOHLKOKBCF.SetActive(false);
		EKOCDFGMLKG.SetActive(false);
		EKOCDFGMLKG.transform.localPosition = EKOCDFGMLKG.transform.localPosition.ReplaceX(445f);
		Singleton<AwaitingSquadMembersManager>.instance.EPHJICEFPJB(EHHDLLGPNBG.id);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_CUSTOMEVENTEND");
	}

	public void FreeTexture()
	{
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(EHHDLLGPNBG.id);
			EHHDLLGPNBG = null;
		}
	}

	private void LANNMNDLJEJ(DatabasePlayer ALAJGOPHOAN)
	{
		bool isInLeague = ALAJGOPHOAN.isInLeague;
		MKKADNBBGLD.text = MEJMLNDFDBP.GMIPFLIEOHD(ALAJGOPHOAN.skill);
		if (ALAJGOPHOAN.isInBeginnersLeague)
		{
			NNMCKEECNFK.alpha = 1f;
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(ALAJGOPHOAN.beginnersLeague);
			NNMCKEECNFK.MakePixelPerfect();
			NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(0.634f);
		}
		else if (ALAJGOPHOAN.leagueTier != League.NoLeague)
		{
			NNMCKEECNFK.alpha = ((!isInLeague) ? 0.5f : 1f);
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[ALAJGOPHOAN.leagueTier].Value2;
			NNMCKEECNFK.MakePixelPerfect();
			NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(0.634f);
		}
		else
		{
			NNMCKEECNFK.alpha = 0f;
		}
	}

	private void FPENCFIHMLJ(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("country-philippines");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.KOOIAAFBKDF();
		JKOHLKOKBCF.SetActive(false);
		EKOCDFGMLKG.SetActive(true);
		EKOCDFGMLKG.transform.localPosition = EKOCDFGMLKG.transform.localPosition.ReplaceX(1437f);
		Singleton<AwaitingSquadMembersManager>.instance.EOJPHCIEJJA(EHHDLLGPNBG.id);
	}

	private void BMCNAFNMCOI(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		if (EHHDLLGPNBG.squadRank == SquadRank.Veteran && !GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.canBePromotedToColeader)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_PROMOTEERROR_TEXT"), Localization.Localize("ID_WARNING_PROMOTEERROR"), 0f, null, string.Empty);
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.PromotePlayer, EHHDLLGPNBG.id);
		CPKHOPOJNFO();
		Singleton<BeanstalkServerManager>.instance.HCEPBIBJLMD(EHHDLLGPNBG);
	}

	internal void HFEIHFBIAHA()
	{
		AHECKDDDOOK.SetWidth(UIHelper.activeWidthSafe - 120f);
		JKKLBACFOJG.SetActive(false);
		BELLJDAFDNM.SetActive(true);
		AAEMHABJEIO.SetActive(false);
		EHHDLLGPNBG = null;
	}

	private void GKGNJAPFLIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void NKIJGOLDIBC(DatabasePlayer ALAJGOPHOAN)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (ALAJGOPHOAN.id == currentPlayer.id && ALAJGOPHOAN.squadRank != currentPlayer.squadRank)
		{
			Debug.LogError(string.Format("Current player squadRank:{0} and info in all members squadRank:{1}", currentPlayer.squadRank, ALAJGOPHOAN.squadRank));
		}
		int num = 0;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, true);
		if (aANECPGDMGM != null)
		{
			num = aANECPGDMGM.FOICGJEPBGL;
		}
		NMACFKPEKPE.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		OMLKMCCKIHJ.SetActive(true);
		JKOHLKOKBCF.SetActive(false);
		EKOCDFGMLKG.SetActive(false);
		MJDPLAIOJLP.SetActive(false);
		bool flag = ALAJGOPHOAN.id == currentPlayer.id;
		bool flag2 = num > 1;
		int num2 = ((currentPlayer.squadRank == SquadRank.Coleader) ? 1 : 0);
		bool flag3 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < 0;
		bool flag4 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < num2;
		bool flag5 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, SquadRank.Member) > 0;
		bool flag6 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, SquadRank.Coleader) < 0;
		bool flag7 = flag5 && flag6;
		bool flag8 = flag2 && currentPlayer.squadRank == SquadRank.Leader;
		EOEAFOFHOEH.SetActive(flag && flag8);
		EOKJEELHAJL.SetActive(!flag && flag6 && flag3 && !flag7);
		APHCPLLGGPJ.SetActive(!flag && flag5 && flag4 && !flag7);
		AKCCLEDIDOF.SetActive(!flag && flag6 && flag3 && flag7);
		AKIOMBAKDFJ.SetActive(!flag && flag5 && flag4 && flag7);
		LMODAIJODMF.SetActive(!flag && flag4);
		MKJKKNCMAHN.SetActive(flag);
		if (GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.IsPlayerWaitingForServerResponse(EHHDLLGPNBG.id))
		{
			CPKHOPOJNFO();
		}
	}

	public virtual void AEHFNIMENDJ()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener.Get(EOEAFOFHOEH).onClick = null;
		UIEventListener.Get(EOKJEELHAJL).onClick = null;
		UIEventListener.Get(AKCCLEDIDOF).onClick = null;
		UIEventListener.Get(APHCPLLGGPJ).onClick = null;
		UIEventListener.Get(AKIOMBAKDFJ).onClick = null;
		UIEventListener.Get(IKLJPIOCOPE).onClick = null;
		UIEventListener.Get(DIBBNCFOCKG).onClick = null;
		UIEventListener.Get(CIONFMKEPII).onClick = null;
		UIEventListener.Get(FONAMCEADBM).onClick = null;
		UIEventListener.Get(AINNCGHAGCH).onClick = null;
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(FCNKIEPEAAG);
		KDKKOGBKOAP();
	}

	private void HCPCFDLHKGJ(GameObject KHAHPAKDIKE)
	{
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.SkipListUpdate();
		GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.AddAction(DatabaseAction.DemotePlayer, EHHDLLGPNBG.id);
		CPKHOPOJNFO();
		Singleton<BeanstalkServerManager>.instance.HCEJLCBFDEO(EHHDLLGPNBG);
	}

	private void LENKPECBHNB(DatabasePlayer ALAJGOPHOAN)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (ALAJGOPHOAN.id == currentPlayer.id && ALAJGOPHOAN.squadRank != currentPlayer.squadRank)
		{
			Debug.LogError(string.Format("ID_BOSS", currentPlayer.squadRank, ALAJGOPHOAN.squadRank));
		}
		int num = 1;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, true);
		if (aANECPGDMGM != null)
		{
			num = aANECPGDMGM.FOICGJEPBGL;
		}
		NMACFKPEKPE.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		OMLKMCCKIHJ.SetActive(false);
		JKOHLKOKBCF.SetActive(false);
		EKOCDFGMLKG.SetActive(false);
		MJDPLAIOJLP.SetActive(false);
		bool flag = ALAJGOPHOAN.id == currentPlayer.id;
		bool flag2 = num > 0;
		int num2 = ((currentPlayer.squadRank == SquadRank.Member) ? 1 : 0);
		bool flag3 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < 0;
		bool flag4 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < num2;
		bool flag5 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, SquadRank.Veteran) > 0;
		bool flag6 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, SquadRank.Leader) < 1;
		bool flag7 = !flag5 || flag6;
		bool flag8 = !flag2 || currentPlayer.squadRank == (SquadRank)6;
		EOEAFOFHOEH.SetActive(!flag || flag8);
		EOKJEELHAJL.SetActive(!flag && flag6 && flag3 && flag7);
		APHCPLLGGPJ.SetActive(flag || !flag5 || !flag4 || flag7);
		AKCCLEDIDOF.SetActive(flag || !flag6 || !flag3 || flag7);
		AKIOMBAKDFJ.SetActive(flag || !flag5 || !flag4 || flag7);
		LMODAIJODMF.SetActive(!flag && flag4);
		MKJKKNCMAHN.SetActive(flag);
		if (GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.IsPlayerWaitingForServerResponse(EHHDLLGPNBG.id))
		{
			NOGNELCFFJE();
		}
	}

	private void JJKLEKKJKFF(DatabasePlayer ALAJGOPHOAN)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (ALAJGOPHOAN.id == currentPlayer.id && ALAJGOPHOAN.squadRank != currentPlayer.squadRank)
		{
			Debug.LogError(string.Format("[{0}] {1}", currentPlayer.squadRank, ALAJGOPHOAN.squadRank));
		}
		int num = 0;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, true);
		if (aANECPGDMGM != null)
		{
			num = aANECPGDMGM.FOICGJEPBGL;
		}
		NMACFKPEKPE.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		OMLKMCCKIHJ.SetActive(false);
		JKOHLKOKBCF.SetActive(true);
		EKOCDFGMLKG.SetActive(true);
		MJDPLAIOJLP.SetActive(true);
		bool flag = ALAJGOPHOAN.id == currentPlayer.id;
		bool flag2 = num > 0;
		int num2 = ((currentPlayer.squadRank != (SquadRank)7) ? 0 : 0);
		bool flag3 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < 1;
		bool flag4 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, currentPlayer.squadRank) < num2;
		bool flag5 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, SquadRank.Member) > 0;
		bool flag6 = MEJMLNDFDBP.DDBBFIGIGPA(ALAJGOPHOAN.squadRank, (SquadRank)7) < 0;
		bool flag7 = flag5 && flag6;
		bool flag8 = !flag2 || currentPlayer.squadRank == (SquadRank)7;
		EOEAFOFHOEH.SetActive(flag && flag8);
		EOKJEELHAJL.SetActive(!flag && flag6 && flag3 && flag7);
		APHCPLLGGPJ.SetActive(flag || !flag5 || !flag4 || !flag7);
		AKCCLEDIDOF.SetActive(!flag && flag6 && flag3 && flag7);
		AKIOMBAKDFJ.SetActive(!flag && flag5 && flag4 && flag7);
		LMODAIJODMF.SetActive(!flag && flag4);
		MKJKKNCMAHN.SetActive(flag);
		if (GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.IsPlayerWaitingForServerResponse(EHHDLLGPNBG.id))
		{
			NOGNELCFFJE();
		}
	}

	private void OPOHEGOIEDP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.KGJCNNANACM(FCEIGDLFOMH);
			DCKFGIKPPGH.BFKPPMIKNAA();
		}
	}

	private void CPKHOPOJNFO()
	{
		EOEAFOFHOEH.SetActive(false);
		EOKJEELHAJL.SetActive(false);
		APHCPLLGGPJ.SetActive(false);
		AKCCLEDIDOF.SetActive(false);
		AKIOMBAKDFJ.SetActive(false);
		MKJKKNCMAHN.SetActive(false);
		LMODAIJODMF.SetActive(false);
		EKOCDFGMLKG.gameObject.SetActive(true);
		EKOCDFGMLKG.transform.localPosition = EKOCDFGMLKG.transform.localPosition.ReplaceX(-120f);
	}

	private void EGDJNBLJDEJ(GameObject KHAHPAKDIKE)
	{
		MFMMBNAODNM mFMMBNAODNM = new MFMMBNAODNM();
		mFMMBNAODNM.BJGCPDNMHDH = this;
		if (EHHDLLGPNBG == null)
		{
			Debug.LogError("Squad Member record does not have DatabasePlayer");
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
			return;
		}
		mFMMBNAODNM.BFFNFDCGCGD = EHHDLLGPNBG.id;
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_KICKPLAYER"), Localization.LocalizeFormat("ID_CONFIRM_KICKPLAYER_TEXT", EHHDLLGPNBG.name), mFMMBNAODNM.LJCDGJKCNEC);
	}
}
