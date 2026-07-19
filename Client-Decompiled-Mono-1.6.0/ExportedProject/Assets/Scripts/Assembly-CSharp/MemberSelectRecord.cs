using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MemberSelectRecord : PoolableObject
{
	[Header("Player Info")]
	public PlayerIcon DAANKCOLJGJ;

	public GameObject OANICEALFGM;

	public UISprite ALFOJMLJFGD;

	public UILabel PKHHKJLGHFM;

	public GameObject CPLIMCNBDBP;

	public UILabel BMNNHJGHFNJ;

	public UILabel CGIFEHPDBAL;

	public UISprite GFKNLLCKJOG;

	[Header("Buttons")]
	public UIButton PJENPMBGFKD;

	private DatabasePlayer MBIAKMPDOPG;

	public void PJICLEMEBID(DatabasePlayer KHLGDCHJJPB)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		PKHHKJLGHFM.text = (string.IsNullOrEmpty(KHLGDCHJJPB.name) ? Localization.Localize("ID_WARSHOP_CARDPACKS") : KHLGDCHJJPB.name);
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 573f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		BMNNHJGHFNJ.text = levelDefinition.LPANGEJPPOE();
		GFKNLLCKJOG.spriteName = levelDefinition.NOHAFIDFPCM();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		string text = GameVariables.IEDGPHEPJEK(KHLGDCHJJPB.country);
		bool flag = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		DAANKCOLJGJ.Reset();
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(FCNKIEPEAAG);
		Singleton<PlayerTexturePool>.instance.JLOKOBIENPP(MNGIBBKJPAC);
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(KHLGDCHJJPB);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMAHLBMODNC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EMEENKELMOF));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
	}

	private void FCNKIEPEAAG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.avatar = FCEIGDLFOMH;
			DAANKCOLJGJ.UpdateIcon();
		}
	}

	private void AOIOMAGDIIN(GameObject KHAHPAKDIKE)
	{
		if (MBIAKMPDOPG != null)
		{
			GuiElementSingle<SelectSquadLeaderDialog>.instance.OMPPOBCIHGL(MBIAKMPDOPG);
		}
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

	private void IFPAIAELCGP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.FBGDPCPIKMI(FCEIGDLFOMH);
			DAANKCOLJGJ.GPHGDAKLAJK();
		}
	}

	public virtual void HMIGDPBGEIG()
	{
		base.OnInstancied();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = OHHNMFLAGOD;
	}

	private void GODELBHGJJF(GameObject KHAHPAKDIKE)
	{
		if (MBIAKMPDOPG != null)
		{
			GuiElementSingle<SelectSquadLeaderDialog>.instance.JHPJGFNNBOD(MBIAKMPDOPG);
		}
	}

	public virtual void KALNJKOBCAN()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMAHLBMODNC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(IFPAIAELCGP);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void DNMMADBDOLM()
	{
		base.JMAFCGDIICK();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = delegate
		{
			if (MBIAKMPDOPG != null)
			{
				GuiElementSingle<SelectSquadLeaderDialog>.instance.Select(MBIAKMPDOPG);
			}
		};
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = delegate
		{
			if (MBIAKMPDOPG != null)
			{
				GuiElementSingle<SelectSquadLeaderDialog>.instance.Select(MBIAKMPDOPG);
			}
		};
	}

	public void NDIJBPIDGOF(DatabasePlayer KHLGDCHJJPB)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		PKHHKJLGHFM.text = (string.IsNullOrEmpty(KHLGDCHJJPB.name) ? Localization.Localize("mUsedDogtagsLocaly") : KHLGDCHJJPB.name);
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 1444f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		BMNNHJGHFNJ.text = levelDefinition.FDACEOHEGPN();
		GFKNLLCKJOG.spriteName = levelDefinition.CDLBEKECJNK();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		string text = GameVariables.BFGCBNLOIMN(KHLGDCHJJPB.country);
		bool flag = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		DAANKCOLJGJ.Reset();
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(PAJLCAPIMGM);
		Singleton<PlayerTexturePool>.instance.BMNHPDMPMLG(OPOHEGOIEDP);
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(KHLGDCHJJPB, true, PlayerTexturePool.DFJJOANIJID.Card);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMAHLBMODNC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMAHLBMODNC));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GPKOFLNDFBL));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
	}

	public virtual void IPMPKNLCHEG()
	{
		base.HPPIBGEJMNL();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = GODELBHGJJF;
	}

	private void EMEENKELMOF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = UITweener.Style.Loop;
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void GGDPJCEDGAA()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMAHLBMODNC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GPKOFLNDFBL));
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= MNGIBBKJPAC;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(MBIAKMPDOPG.id, true, true, true);
		}
		MBIAKMPDOPG = null;
	}

	private void PAJLCAPIMGM(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.GJHFCKMAMIE(FCEIGDLFOMH);
			DAANKCOLJGJ.GGLBLHKGCAO();
		}
	}

	public virtual void JLHMFBILMCF()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ENFCNAPNMCI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= IFPAIAELCGP;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void GMAHLBMODNC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void MNFOEHIIMIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void MNGIBBKJPAC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.avatar = FCEIGDLFOMH;
			DAANKCOLJGJ.OKHFOOHNBDF();
		}
	}

	private void ENFCNAPNMCI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void JFIPECBDDDL(GameObject KHAHPAKDIKE)
	{
		if (MBIAKMPDOPG != null)
		{
			GuiElementSingle<SelectSquadLeaderDialog>.instance.EJPCDFKGKPH(MBIAKMPDOPG);
		}
	}

	public virtual void HBCALMGGFHP()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HFDMIFNDEIG));
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(IFPAIAELCGP);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, false, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public void CKOIIPAGCNO(DatabasePlayer KHLGDCHJJPB)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		PKHHKJLGHFM.text = (string.IsNullOrEmpty(KHLGDCHJJPB.name) ? Localization.Localize("ID_CREATE") : KHLGDCHJJPB.name);
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 464f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		BMNNHJGHFNJ.text = levelDefinition.KAKFPJPKHHB();
		GFKNLLCKJOG.spriteName = levelDefinition.NOHAFIDFPCM();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		string text = GameVariables.CountryCodeSpriteName(KHLGDCHJJPB.country);
		bool flag = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		DAANKCOLJGJ.HJOCCDLNFLN();
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(MNGIBBKJPAC);
		Singleton<PlayerTexturePool>.instance.HGBBFFJLDJI(OPOHEGOIEDP);
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(KHLGDCHJJPB, false);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ENFCNAPNMCI));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HFDMIFNDEIG));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
	}

	public virtual void PONDIDGALJM()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EMEENKELMOF));
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(IFPAIAELCGP);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id, true, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void HFDMIFNDEIG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = UITweener.Style.Loop;
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void OEMOOAENMHN()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ENFCNAPNMCI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(FCNKIEPEAAG);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id, true, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void ONNHHKBGDOP(GameObject KHAHPAKDIKE)
	{
		if (MBIAKMPDOPG != null)
		{
			GuiElementSingle<SelectSquadLeaderDialog>.instance.OMPPOBCIHGL(MBIAKMPDOPG);
		}
	}

	[CompilerGenerated]
	private void BHGDBAOKGAE(GameObject KHAHPAKDIKE)
	{
		if (MBIAKMPDOPG != null)
		{
			GuiElementSingle<SelectSquadLeaderDialog>.instance.Select(MBIAKMPDOPG);
		}
	}

	private void EHPNDLLKHME(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)7;
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void Initialize(DatabasePlayer KHLGDCHJJPB)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		PKHHKJLGHFM.text = (string.IsNullOrEmpty(KHLGDCHJJPB.name) ? Localization.Localize("ID_ERRORNAME") : KHLGDCHJJPB.name);
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 0f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		BMNNHJGHFNJ.text = levelDefinition.displayString;
		GFKNLLCKJOG.spriteName = levelDefinition.iconName;
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		string text = GameVariables.CountryCodeSpriteName(KHLGDCHJJPB.country);
		bool flag = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		DAANKCOLJGJ.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(KHLGDCHJJPB);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
	}

	public virtual void OOFECCBHOOK()
	{
		base.HPPIBGEJMNL();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = ONNHHKBGDOP;
	}

	private void JLPEPPMDFNH(GameObject KHAHPAKDIKE)
	{
		if (MBIAKMPDOPG != null)
		{
			GuiElementSingle<SelectSquadLeaderDialog>.instance.Select(MBIAKMPDOPG);
		}
	}

	public virtual void FNKNLEMGNBC()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ENFCNAPNMCI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= MNGIBBKJPAC;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void HBFGEHIMBHD()
	{
		base.HPPIBGEJMNL();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = OHHNMFLAGOD;
	}

	public virtual void GACJFNEBJID()
	{
		base.JMAFCGDIICK();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = OHHNMFLAGOD;
	}

	private void OPOHEGOIEDP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.BIEIDBBDNIF(FCEIGDLFOMH);
			DAANKCOLJGJ.HJHOBLMEJEH();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	private void OHHNMFLAGOD(GameObject KHAHPAKDIKE)
	{
		if (MBIAKMPDOPG != null)
		{
			GuiElementSingle<SelectSquadLeaderDialog>.instance.EJPCDFKGKPH(MBIAKMPDOPG);
		}
	}

	public void AMFDNBJBPLB(DatabasePlayer KHLGDCHJJPB)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		PKHHKJLGHFM.text = (string.IsNullOrEmpty(KHLGDCHJJPB.name) ? Localization.Localize("WasAdded") : KHLGDCHJJPB.name);
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 464f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		BMNNHJGHFNJ.text = levelDefinition.GIIHOHGFHBO();
		GFKNLLCKJOG.spriteName = levelDefinition.KJFPCOMOLLD();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		string text = GameVariables.IEDGPHEPJEK(KHLGDCHJJPB.country);
		bool flag = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		DAANKCOLJGJ.EGAONBPLDAG();
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(IFPAIAELCGP);
		Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(FCNKIEPEAAG);
		Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(KHLGDCHJJPB, true, PlayerTexturePool.DFJJOANIJID.Card);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ENFCNAPNMCI));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HFDMIFNDEIG));
	}

	private void IDFMDCIFBEF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void GEINAEKMOOP()
	{
		base.JMAFCGDIICK();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = JLPEPPMDFNH;
	}

	public void AJEGOKKKLOL(DatabasePlayer KHLGDCHJJPB)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		PKHHKJLGHFM.text = (string.IsNullOrEmpty(KHLGDCHJJPB.name) ? Localization.Localize("Total_Battles") : KHLGDCHJJPB.name);
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 614f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		BMNNHJGHFNJ.text = levelDefinition.DLCFFHEKBAA();
		GFKNLLCKJOG.spriteName = levelDefinition.NOHAFIDFPCM();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		string text = GameVariables.IEDGPHEPJEK(KHLGDCHJJPB.country);
		bool flag = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		DAANKCOLJGJ.NMEJKACLHKJ();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= MHPNIGDALMJ;
		Singleton<PlayerTexturePool>.instance.EPPEDDFMHIB(PAJLCAPIMGM);
		Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(KHLGDCHJJPB, true, PlayerTexturePool.DFJJOANIJID.Card);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EMEENKELMOF));
	}

	private void GPKOFLNDFBL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)7;
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void HEGPFIGACED(DatabasePlayer KHLGDCHJJPB)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		PKHHKJLGHFM.text = (string.IsNullOrEmpty(KHLGDCHJJPB.name) ? Localization.Localize("Experience") : KHLGDCHJJPB.name);
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 909f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		BMNNHJGHFNJ.text = levelDefinition.GIIHOHGFHBO();
		GFKNLLCKJOG.spriteName = levelDefinition.KJFPCOMOLLD();
		CGIFEHPDBAL.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		string text = GameVariables.BFGCBNLOIMN(KHLGDCHJJPB.country);
		bool flag = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag);
		if (flag)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		DAANKCOLJGJ.PDKPELBIAON();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= PAJLCAPIMGM;
		Singleton<PlayerTexturePool>.instance.ACEFBBGOINN(MHPNIGDALMJ);
		Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(KHLGDCHJJPB, false, PlayerTexturePool.DFJJOANIJID.Card);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMAHLBMODNC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GPKOFLNDFBL));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
	}

	private void MHPNIGDALMJ(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			DAANKCOLJGJ.DJPNDAICDPN(FCEIGDLFOMH);
			DAANKCOLJGJ.DGPJIJBHBJC();
		}
	}

	public virtual void JNFGOFBEPIH()
	{
		base.OnInstancied();
		UIEventListener.Get(PJENPMBGFKD.gameObject).onClick = OHHNMFLAGOD;
	}
}
