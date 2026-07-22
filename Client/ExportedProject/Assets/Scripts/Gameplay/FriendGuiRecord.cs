using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FriendGuiRecord : PoolableObject
{
	[FormerlySerializedAs("MHOPKAHDGMN")]
	public BoxCollider NJEAMAHEMHP;

	[FormerlySerializedAs("LBLAKCIFILA")]
	[Header("Member Content")]
	public GameObject BBNLILBDOEC;

	[FormerlySerializedAs("HPOCJBBBPOC")]
	[Header("-Player Info")]
	public PlayerIcon DAANKCOLJGJ;

	[FormerlySerializedAs("OPAIBCEMCPH")]
	public GameObject OANICEALFGM;

	[FormerlySerializedAs("PILKNDHIBFL")]
	public UISprite ALFOJMLJFGD;

	[FormerlySerializedAs("CMKGOKNCLOJ")]
	public UILabel PKHHKJLGHFM;

	[FormerlySerializedAs("FPBGHOAGEPD")]
	public GameObject CPLIMCNBDBP;

	[FormerlySerializedAs("MDKDHDFAFPH")]
	public UILabel BMNNHJGHFNJ;

	[FormerlySerializedAs("LJNGLIOELNE")]
	public UILabel CGIFEHPDBAL;

	[FormerlySerializedAs("GIOBECHOAAE")]
	public GameObject KDABKEGLDEE;

	[FormerlySerializedAs("IMNNPCMJHMP")]
	public UISprite GFKNLLCKJOG;

	[FormerlySerializedAs("MDBAJODDCGF")]
	public UISprite NPECJCIKCBI;

	[Header("-Online Status")]
	[FormerlySerializedAs("EOIGIFPNELC")]
	public UILabel FKDOJKMEPHC;

	[FormerlySerializedAs("JKPHCCJCMPE")]
	public UISprite AJPCPDNJOEL;

	[FormerlySerializedAs("IPDOCDDJKCP")]
	[Header("-Button")]
	public GameObject OGPKHNKKDAN;

	[FormerlySerializedAs("HOOOBCGEAPC")]
	public UILabel NFBECFIIEDK;

	[FormerlySerializedAs("ODIPBOPEKDP")]
	public UISprite CKECPGHGOKE;

	[FormerlySerializedAs("CLHDBOKDDHE")]
	public UISprite LAKNFALLGMJ;

	[Header("Invite Content")]
	[FormerlySerializedAs("HKCILEIAFKD")]
	public GameObject HFKMIHPIBAM;

	private bool ECMCHJBOIKB;

	private DatabasePlayer MBIAKMPDOPG;

	public void EIGEICNCJAN()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(MBIAKMPDOPG.id);
			MBIAKMPDOPG = null;
		}
	}

	private void JNLOEBEHDMK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(CGIFEHPDBAL.text))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(CGIFEHPDBAL.text);
		}
	}

	public void InitializeInvite()
	{
		JMDOHCHMBDP();
	}

	private void FKHDLBEJDGP(PlayerStatus GDAELIBCLPP)
	{
		bool active = false;
		if (GuiElementSingle<SelectFriendsDialog>.instance.BMONAKDOFKJ() == SelectFriendsDialog.NKHJBLBAAEB.COOP)
		{
			active = !GuiElementSingle<SelectFriendsDialog>.instance.WasPlayerInvited(MBIAKMPDOPG);
		}
		FKDOJKMEPHC.text = Localization.Localize(GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value1);
		FKDOJKMEPHC.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		AJPCPDNJOEL.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		OGPKHNKKDAN.SetActive(active);
	}

	public void BMJJNBNPMCF()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
			MBIAKMPDOPG = null;
		}
	}

	private void FCNKIEPEAAG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.avatar = FCEIGDLFOMH;
			DAANKCOLJGJ.UpdateIcon();
		}
	}

	public void Initialize(DatabasePlayer KHLGDCHJJPB)
	{
		HILGHEFIOFP();
		MBIAKMPDOPG = KHLGDCHJJPB;
		PKHHKJLGHFM.text = (string.IsNullOrEmpty(KHLGDCHJJPB.name) ? Localization.Localize("ID_ERRORNAME") : KHLGDCHJJPB.name);
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 0f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		BMNNHJGHFNJ.text = levelDefinition.displayString;
		GFKNLLCKJOG.spriteName = levelDefinition.iconName;
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 0f, Color.white);
		string text = GameVariables.CountryCodeSpriteName(KHLGDCHJJPB.country);
		bool flag = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		bool flag2 = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag2);
		if (flag2)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float val = PKHHKJLGHFM.transform.localPosition.x + PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x + 10f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		DAANKCOLJGJ.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(KHLGDCHJJPB);
		AKICFJAMHJJ(KHLGDCHJJPB.GetRealStatus());
		ChangeLook(GuiElementSingle<SelectFriendsDialog>.instance.currentType);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
		UIEventListener uIEventListener6 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
	}

	private void MNFOEHIIMIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void AKICFJAMHJJ(PlayerStatus GDAELIBCLPP)
	{
		bool active = true;
		if (GuiElementSingle<SelectFriendsDialog>.instance.currentType == SelectFriendsDialog.NKHJBLBAAEB.INVITE)
		{
			active = !GuiElementSingle<SelectFriendsDialog>.instance.WasPlayerInvited(MBIAKMPDOPG);
		}
		FKDOJKMEPHC.text = Localization.Localize(GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value1);
		FKDOJKMEPHC.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		AJPCPDNJOEL.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		OGPKHNKKDAN.SetActive(active);
	}

	public virtual void EGEAFDFNEAP()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= HIHCBOMMEON;
		KNBBDNMJLIP();
	}

	public virtual void ONHFNIJNMGE()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ENFCNAPNMCI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MDNDAFCKBFG));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KKFHJCJOJAA));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(MNGIBBKJPAC);
		FreeTexture();
	}

	private void CGJNOJJCCNA(PlayerStatus GDAELIBCLPP)
	{
		bool active = true;
		if (GuiElementSingle<SelectFriendsDialog>.instance.currentType == SelectFriendsDialog.NKHJBLBAAEB.INVITE)
		{
			active = GuiElementSingle<SelectFriendsDialog>.instance.WasPlayerInvited(MBIAKMPDOPG);
		}
		FKDOJKMEPHC.text = Localization.Localize(GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value1);
		FKDOJKMEPHC.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		AJPCPDNJOEL.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		OGPKHNKKDAN.SetActive(active);
	}

	private void ENFCNAPNMCI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void AHHDLELECFG(PlayerStatus GDAELIBCLPP)
	{
		bool active = true;
		if (GuiElementSingle<SelectFriendsDialog>.instance.BMONAKDOFKJ() == SelectFriendsDialog.NKHJBLBAAEB.INVITE)
		{
			active = !GuiElementSingle<SelectFriendsDialog>.instance.WasPlayerInvited(MBIAKMPDOPG);
		}
		FKDOJKMEPHC.text = Localization.Localize(GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value1);
		FKDOJKMEPHC.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		AJPCPDNJOEL.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		OGPKHNKKDAN.SetActive(active);
	}

	private void MNGIBBKJPAC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.KHIPFLOFKMC(FCEIGDLFOMH);
			DAANKCOLJGJ.GGLBLHKGCAO();
		}
	}

	private void HCGLELHGFIO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(CGIFEHPDBAL.text))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)6;
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(CGIFEHPDBAL.text);
		}
	}

	private void GDPGAPOAAGN()
	{
		ECMCHJBOIKB = false;
		BBNLILBDOEC.SetActive(ECMCHJBOIKB);
		HFKMIHPIBAM.SetActive(ECMCHJBOIKB);
		NJEAMAHEMHP.center = new Vector3(1150f, 98f, 679f);
		NJEAMAHEMHP.size = new Vector3(1874f, 1911f, 1441f);
	}

	private void HIHCBOMMEON(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.FBGDPCPIKMI(FCEIGDLFOMH);
			DAANKCOLJGJ.ECAFLDEFKKB();
		}
	}

	private void GLOCAFOMBCA(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(CGIFEHPDBAL.text))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = UITweener.Style.Loop;
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(CGIFEHPDBAL.text);
		}
	}

	public void FreeTexture()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id);
			MBIAKMPDOPG = null;
		}
	}

	private void NEHEMGBINPF(PlayerStatus GDAELIBCLPP)
	{
		bool active = false;
		if (GuiElementSingle<SelectFriendsDialog>.instance.currentType == SelectFriendsDialog.NKHJBLBAAEB.INVITE)
		{
			active = GuiElementSingle<SelectFriendsDialog>.instance.WasPlayerInvited(MBIAKMPDOPG);
		}
		FKDOJKMEPHC.text = Localization.Localize(GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value1);
		FKDOJKMEPHC.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		AJPCPDNJOEL.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		OGPKHNKKDAN.SetActive(active);
	}

	private void IKGFFMLLNJH()
	{
		if (ECMCHJBOIKB)
		{
			GameLoginManager.instance.InviteFacebookFriends();
		}
		else if (MBIAKMPDOPG != null)
		{
			if (GuiElementSingle<SelectFriendsDialog>.instance.currentType == SelectFriendsDialog.NKHJBLBAAEB.COOP)
			{
				bool activeSelf = OGPKHNKKDAN.activeSelf;
				OGPKHNKKDAN.SetActive(value: true);
				if (activeSelf)
				{
					GuiElementSingle<SelectFriendsDialog>.instance.Select(MBIAKMPDOPG);
				}
				else
				{
					Debug.Log("GameLauncher.Awake InitTerms");
				}
			}
			else
			{
				GuiElementSingle<SelectFriendsDialog>.instance.Select(MBIAKMPDOPG);
			}
		}
		else
		{
			Debug.LogError("GooglePlay");
		}
	}

	private void PFBJELDDLCO(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.LOCLNGEMNCC(FCEIGDLFOMH);
			DAANKCOLJGJ.HJHOBLMEJEH();
		}
	}

	public void ChangeLook(SelectFriendsDialog.NKHJBLBAAEB LGMALHPGKOK)
	{
		NFBECFIIEDK.text = Localization.Localize((LGMALHPGKOK != SelectFriendsDialog.NKHJBLBAAEB.INVITE) ? "ID_PLAY" : "ID_INVITE");
		NFBECFIIEDK.pivot = ((LGMALHPGKOK != SelectFriendsDialog.NKHJBLBAAEB.FIGHT) ? UIWidget.Pivot.Left : UIWidget.Pivot.Center);
		NFBECFIIEDK.transform.localPosition = NFBECFIIEDK.transform.localPosition.ReplaceX((LGMALHPGKOK != SelectFriendsDialog.NKHJBLBAAEB.FIGHT) ? (-129f) : 0f);
		MEJMLNDFDBP.COCBCFKJOJE(NFBECFIIEDK, 47f, 20f, 200);
		CKECPGHGOKE.gameObject.SetActive(LGMALHPGKOK == SelectFriendsDialog.NKHJBLBAAEB.INVITE);
		LAKNFALLGMJ.gameObject.SetActive(LGMALHPGKOK == SelectFriendsDialog.NKHJBLBAAEB.INVITE);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		FreeTexture();
	}

	private void APCCJIJCOJE()
	{
		ECMCHJBOIKB = true;
		BBNLILBDOEC.SetActive(ECMCHJBOIKB);
		HFKMIHPIBAM.SetActive(ECMCHJBOIKB);
		NJEAMAHEMHP.center = new Vector3(1370f, 442f, 1856f);
		NJEAMAHEMHP.size = new Vector3(1007f, 971f, 185f);
	}

	private void OnClick()
	{
		if (ECMCHJBOIKB)
		{
			GameLoginManager.instance.InviteFacebookFriends();
		}
		else if (MBIAKMPDOPG != null)
		{
			if (GuiElementSingle<SelectFriendsDialog>.instance.currentType == SelectFriendsDialog.NKHJBLBAAEB.INVITE)
			{
				bool activeSelf = OGPKHNKKDAN.activeSelf;
				OGPKHNKKDAN.SetActive(value: false);
				if (activeSelf)
				{
					GuiElementSingle<SelectFriendsDialog>.instance.Select(MBIAKMPDOPG);
				}
				else
				{
					Debug.Log("Invite was already send, ignoring click.");
				}
			}
			else
			{
				GuiElementSingle<SelectFriendsDialog>.instance.Select(MBIAKMPDOPG);
			}
		}
		else
		{
			Debug.LogError("FriendGuiRecord: Player is null!");
		}
	}

	private void HILGHEFIOFP()
	{
		ECMCHJBOIKB = false;
		BBNLILBDOEC.SetActive(!ECMCHJBOIKB);
		HFKMIHPIBAM.SetActive(ECMCHJBOIKB);
		NJEAMAHEMHP.center = new Vector3(548f, 0f, -0.5f);
		NJEAMAHEMHP.size = new Vector3(360f, 130f, 1f);
	}

	private void GKGNJAPFLIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void JPKFJPGFKCC()
	{
		if (ECMCHJBOIKB)
		{
			GameLoginManager.instance.InviteFacebookFriends();
		}
		else if (MBIAKMPDOPG != null)
		{
			if (GuiElementSingle<SelectFriendsDialog>.instance.currentType == SelectFriendsDialog.NKHJBLBAAEB.COOP)
			{
				bool activeSelf = OGPKHNKKDAN.activeSelf;
				OGPKHNKKDAN.SetActive(value: false);
				if (activeSelf)
				{
					GuiElementSingle<SelectFriendsDialog>.instance.OMPPOBCIHGL(MBIAKMPDOPG);
				}
				else
				{
					Debug.Log("ID_REMINDER_YOURVIPMEMBERSHIP");
				}
			}
			else
			{
				GuiElementSingle<SelectFriendsDialog>.instance.OMPPOBCIHGL(MBIAKMPDOPG);
			}
		}
		else
		{
			Debug.LogError(" ");
		}
	}

	private void GAKDGIGDNEI()
	{
		ECMCHJBOIKB = true;
		BBNLILBDOEC.SetActive(!ECMCHJBOIKB);
		HFKMIHPIBAM.SetActive(ECMCHJBOIKB);
		NJEAMAHEMHP.center = new Vector3(1534f, 486f, 1070f);
		NJEAMAHEMHP.size = new Vector3(1748f, 328f, 1799f);
	}

	private void KKFHJCJOJAA(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(CGIFEHPDBAL.text))
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)4;
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(CGIFEHPDBAL.text);
		}
	}

	private void LONNJAPDOAJ(PlayerStatus GDAELIBCLPP)
	{
		bool active = false;
		if (GuiElementSingle<SelectFriendsDialog>.instance.BMONAKDOFKJ() == SelectFriendsDialog.NKHJBLBAAEB.COOP)
		{
			active = !GuiElementSingle<SelectFriendsDialog>.instance.WasPlayerInvited(MBIAKMPDOPG);
		}
		FKDOJKMEPHC.text = Localization.Localize(GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value1);
		FKDOJKMEPHC.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		AJPCPDNJOEL.color = GameVariables.CKCJBIIPEOG[GDAELIBCLPP].Value2;
		OGPKHNKKDAN.SetActive(active);
	}

	private void LIFFMCCLDGK()
	{
		if (ECMCHJBOIKB)
		{
			GameLoginManager.instance.InviteFacebookFriends();
		}
		else if (MBIAKMPDOPG != null)
		{
			if (GuiElementSingle<SelectFriendsDialog>.instance.BMONAKDOFKJ() == SelectFriendsDialog.NKHJBLBAAEB.COOP)
			{
				bool activeSelf = OGPKHNKKDAN.activeSelf;
				OGPKHNKKDAN.SetActive(value: false);
				if (activeSelf)
				{
					GuiElementSingle<SelectFriendsDialog>.instance.Select(MBIAKMPDOPG);
				}
				else
				{
					Debug.Log("FacebookId");
				}
			}
			else
			{
				GuiElementSingle<SelectFriendsDialog>.instance.Select(MBIAKMPDOPG);
			}
		}
		else
		{
			Debug.LogError("clearDefaultAccountAndReconnect");
		}
	}

	public void KNBBDNMJLIP()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.MDANAEPCCHK(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
			MBIAKMPDOPG = null;
		}
	}

	private void MDNDAFCKBFG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)8;
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
		}
	}

	private void JMDOHCHMBDP()
	{
		ECMCHJBOIKB = true;
		BBNLILBDOEC.SetActive(!ECMCHJBOIKB);
		HFKMIHPIBAM.SetActive(ECMCHJBOIKB);
		NJEAMAHEMHP.center = new Vector3(0f, 0f, -0.5f);
		NJEAMAHEMHP.size = new Vector3(1440f, 130f, 1f);
	}
}
