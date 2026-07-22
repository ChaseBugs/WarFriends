using System;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadDetailsMemberGridElement : PoolableObject
{
	[Header("Left")]
	[FormerlySerializedAs("FIDILIADIEL")]
	public UISprite LCPBNBLGFIA;

	[FormerlySerializedAs("MPHCJEIMBEB")]
	public UILabel MPHCNMDIPAI;

	[FormerlySerializedAs("JEPIOBIHINA")]
	public PlayerIcon DCKFGIKPPGH;

	[FormerlySerializedAs("OPAIBCEMCPH")]
	public GameObject OANICEALFGM;

	[FormerlySerializedAs("PILKNDHIBFL")]
	public UISprite ALFOJMLJFGD;

	[FormerlySerializedAs("FMECKCHDKIJ")]
	public UISprite GFKNLLCKJOG;

	[FormerlySerializedAs("OMIHOMEBHMF")]
	public UILabel DLAMMHGPADA;

	[FormerlySerializedAs("FMJAHEEAAHH")]
	public UITable KHHLLNJAKAL;

	[FormerlySerializedAs("MPDKINLBKHI")]
	public UILabel MEPFCGAAEEF;

	[FormerlySerializedAs("MDBAJODDCGF")]
	public UISprite NPECJCIKCBI;

	[FormerlySerializedAs("NPJHKDBDGAG")]
	public GameObject BJCMNMGCGNN;

	[FormerlySerializedAs("JKMFPJNPLGN")]
	public GameObject CPLIMCNBDBP;

	[FormerlySerializedAs("KHJANIBLGEE")]
	public UILabel IGNNPMHKICA;

	[FormerlySerializedAs("NAFEHLAPHBC")]
	[Header("Right")]
	public UILabel DDMKCNOOCGL;

	[FormerlySerializedAs("HPKODGCNKCG")]
	public UILabel LKCHKLPFEKM;

	[FormerlySerializedAs("MLFLNKIPOHL")]
	public UILabel NBGJFPBGGIO;

	[FormerlySerializedAs("KNIHAEEIFLJ")]
	public UISprite NNMCKEECNFK;

	[FormerlySerializedAs("IKBFKACLHCM")]
	public UILabel PCGLEBCNECN;

	private DatabasePlayer EHHDLLGPNBG;

	public void KPLGGFBJIGG(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.HEOPOOMLPJF();
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(IHIILICAFGF);
		Singleton<PlayerTexturePool>.instance.LHOOOIOGOFM(MKFCFLAGGOD);
		Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.EGNEDNBPOEF();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1737f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.IEFOIJAFOJC();
		int num = -116;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -76;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(928f / NPECJCIKCBI.transform.localScale.x, 1325f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= 120;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1280f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1834f, 1681f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.BFGCBNLOIMN(ALAJGOPHOAN.country);
		bool flag3 = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 32f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 177f : 1784f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1406f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CAOBDLOBLAF));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CODNBIDNPPI));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AHFHGIMNCCA));
	}

	public virtual void BFHOMBFFAJH()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NIKOAOPMNFC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PFCJDKFPIBN));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= KJJDIMJGFJC;
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(EHHDLLGPNBG.id);
		}
		EHHDLLGPNBG = null;
	}

	private void FIMAPCNJNAI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void NBAIMPNKMPP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.FBGDPCPIKMI(FCEIGDLFOMH);
			DCKFGIKPPGH.GEPDJCOHDNH();
		}
	}

	private void EEAFOIIKONM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	public void BEEFBNHPBKM(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.KLIEOBHDFCG();
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(NAEFOLMDNOP);
		Singleton<PlayerTexturePool>.instance.GENOIIGKOIK(DFHJCGPNFLE);
		Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.CDLBEKECJNK();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1643f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.DLCFFHEKBAA();
		int num = -76;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -59;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(563f / NPECJCIKCBI.transform.localScale.x, 118f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -47;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 143f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 827f, 1639f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.BFGCBNLOIMN(ALAJGOPHOAN.country);
		bool flag3 = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 65f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 652f : 262f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1115f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GFHENJLAHID));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KOMIBCNMEFO));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DAGDGEJCDFP));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
	}

	private void OPIAOAGOMNM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void EAFAMBKMLDJ()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GFHENJLAHID));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LCLBMLBKOFO));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(ANPEPPGFENN);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	private void NDKDIBBOEFC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.OLJPGNNKCKI(FCEIGDLFOMH);
			DCKFGIKPPGH.OKHFOOHNBDF();
		}
	}

	public virtual void IMBKPHGHFNI()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BDMCLOCBDOH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEHDACDMLCH));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= POLOPBEOOCB;
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
		}
		EHHDLLGPNBG = null;
	}

	private void MKFCFLAGGOD(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.DHDPJLAPAPO(FCEIGDLFOMH);
			DCKFGIKPPGH.GEPDJCOHDNH();
		}
	}

	private void HLJPLBOBDLN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void BFHAFBOBHMD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void DBLCPGLJHLB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void NAEFOLMDNOP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.KHIPFLOFKMC(FCEIGDLFOMH);
			DCKFGIKPPGH.OKHFOOHNBDF();
		}
	}

	public virtual void KKMGMEKEPOD()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LALDCFHJFDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EGJLBJHJGFM));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= KJKGJLBGEEL;
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	private void KJJDIMJGFJC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.ECKBKNCJLOC(FCEIGDLFOMH);
			DCKFGIKPPGH.HCACKHAKDNC();
		}
	}

	private void OBFHMEAEAHC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void CPKAHGCGLKI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public void GNLEOMDCMJL(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.EGAONBPLDAG();
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(BAJFMDBAKKM);
		Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(IHIILICAFGF);
		Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(ALAJGOPHOAN, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.KJFPCOMOLLD();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 855f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.JNODDKLJOAG();
		int num = -185;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= 47;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(816f / NPECJCIKCBI.transform.localScale.x, 1951f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= 43;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1224f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1555f, 87f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.CountryCodeSpriteName(ALAJGOPHOAN.country);
		bool flag3 = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 965f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 983f : 1817f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1200f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NOCAIHEJNFK));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KODINMKGOJC));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GOOMCGDNIGH));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DCELLKPDLDI));
	}

	public virtual void LMMKHPNFJKK()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MAHOLKEABOM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FPDEBCFJJHD));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(NBAIMPNKMPP);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	private void FCJCCABKOGC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void KOMIBCNMEFO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void KIFFEEEDFPD()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KOMIBCNMEFO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(ECKJKFBMBFO);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	private void EGJLBJHJGFM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void NIKOAOPMNFC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	public void CMAMBFEFLFJ(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.PDKPELBIAON();
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(MKHBLGNPKOH);
		Singleton<PlayerTexturePool>.instance.GENOIIGKOIK(FKBDHIJGMMM);
		Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(ALAJGOPHOAN);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.KJFPCOMOLLD();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 109f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.LPANGEJPPOE();
		int num = 100;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown == WarArenaCrown.None;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -21;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(876f / NPECJCIKCBI.transform.localScale.x, 1729f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -75;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 51f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 368f, 445f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.IDOFIHFGOKD(ALAJGOPHOAN.country);
		bool flag3 = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 1202f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 1340f : 1414f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1176f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CAOBDLOBLAF));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FMLIMHPLKHJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MLONGAILKJC));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LHHEFCNLPEC));
	}

	private void KEHDACDMLCH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void BJEGDOPLCJN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void FKBDHIJGMMM(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.avatar = FCEIGDLFOMH;
			DCKFGIKPPGH.GPHGDAKLAJK();
		}
	}

	private void GKGNJAPFLIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void HKOIFINLBLL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void DBLEPOJNJME(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void KODINMKGOJC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void GICLKACEHJH()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LALDCFHJFDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CODNBIDNPPI));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(IHIILICAFGF);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	private void KJKGJLBGEEL(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.JJGFMKCHIPE(FCEIGDLFOMH);
			DCKFGIKPPGH.GGLBLHKGCAO();
		}
	}

	private void NBOIAMBPPFM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void PFCJDKFPIBN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void DFHJCGPNFLE(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.EIKJEGHELNK(FCEIGDLFOMH);
			DCKFGIKPPGH.BFKPPMIKNAA();
		}
	}

	private void FMLIMHPLKHJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void ECKJKFBMBFO(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.EIKJEGHELNK(FCEIGDLFOMH);
			DCKFGIKPPGH.GEPDJCOHDNH();
		}
	}

	private void MNFOEHIIMIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void GCAKFFHMAJO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void LJFBIDBACDI()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LALDCFHJFDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EKBECFABEMP));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(KJKGJLBGEEL);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	public void MCBEOIJJCEB(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.NCHGDJDAHGC();
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(NDKDIBBOEFC);
		Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(NBAIMPNKMPP);
		Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.CDLBEKECJNK();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 593f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.DLCFFHEKBAA();
		int num = 155;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= 75;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(1114f / NPECJCIKCBI.transform.localScale.x, 1661f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -91;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1323f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1911f, 1986f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.IDOFIHFGOKD(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 436f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 1512f : 421f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1727f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KODINMKGOJC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GCAKFFHMAJO));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GOOMCGDNIGH));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MLONGAILKJC));
	}

	private void IHIILICAFGF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.JJGFMKCHIPE(FCEIGDLFOMH);
			DCKFGIKPPGH.GPHGDAKLAJK();
		}
	}

	private void BDMCLOCBDOH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void OEMOOAENMHN()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NMNLBIKPBND));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FCJCCABKOGC));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(HIHCBOMMEON);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	private void MAHOLKEABOM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void PBICPGAPNNH()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NIKOAOPMNFC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(FCNKIEPEAAG);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	private void NHIEGEGDHAE(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void LCLBMLBKOFO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void ICCCGGEEFJF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void LJJJICJDHHL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void HCHNJCDNEPO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void LALDCFHJFDN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public void OCFFAINJBHL(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.OMDFNFHKFBK();
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(BAJFMDBAKKM);
		Singleton<PlayerTexturePool>.instance.IANAHBGPJLN(MKFCFLAGGOD);
		Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(ALAJGOPHOAN, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.NOHAFIDFPCM();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1756f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.KAKFPJPKHHB();
		int num = 149;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= 26;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(909f / NPECJCIKCBI.transform.localScale.x, 404f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -51;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 197f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 473f, 1533f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.IDOFIHFGOKD(ALAJGOPHOAN.country);
		bool flag3 = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 656f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 1506f : 1070f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1825f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KODINMKGOJC));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LCLBMLBKOFO));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EGJLBJHJGFM));
	}

	private void MLONGAILKJC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void LHHEFCNLPEC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void HHGPAMKLJFJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void NOCAIHEJNFK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	public override void OBCAIFMOPPA()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GFHENJLAHID));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AHFHGIMNCCA));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(KJJDIMJGFJC);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	public void MOHGCGPHANE(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.NCHGDJDAHGC();
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(HIHCBOMMEON);
		Singleton<PlayerTexturePool>.instance.MMAGKGAKHAD(MKHBLGNPKOH);
		Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(ALAJGOPHOAN, PNDNEMDPFHC: false);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.GIEIIPBAIBK();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1561f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.DLCFFHEKBAA();
		int num = -28;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -97;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(1369f / NPECJCIKCBI.transform.localScale.x, 1290f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -99;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1680f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1738f, 1010f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.IEDGPHEPJEK(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 351f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 307f : 317f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(502f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DEBKFLAJGFD));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BFHAFBOBHMD));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DBLCPGLJHLB));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DCELLKPDLDI));
	}

	private void PNPLPOJHPPB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void HIHCBOMMEON(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.EIKJEGHELNK(FCEIGDLFOMH);
			DCKFGIKPPGH.ECAFLDEFKKB();
		}
	}

	private void DEBKFLAJGFD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	public virtual void IFHBPEAKGDN()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OBFHMEAEAHC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ANKJLHLECKE));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(IFPAIAELCGP);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	public void JLEKOOCEDPC(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.OOOLABBEKDF();
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(KJKGJLBGEEL);
		Singleton<PlayerTexturePool>.instance.EPPEDDFMHIB(MKHBLGNPKOH);
		Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.EGNEDNBPOEF();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1551f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.displayString;
		int num = 21;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= 34;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(1555f / NPECJCIKCBI.transform.localScale.x, 1587f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -10;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1456f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1766f, 1604f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.BFGCBNLOIMN(ALAJGOPHOAN.country);
		bool flag3 = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 1403f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 1231f : 1071f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(968f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICCCGGEEFJF));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LALDCFHJFDN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NHIEGEGDHAE));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HFDMIFNDEIG));
	}

	private void DCELLKPDLDI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void HFDMIFNDEIG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	public virtual void GGDPJCEDGAA()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NIKOAOPMNFC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHHEFCNLPEC));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(ANPEPPGFENN);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.MDANAEPCCHK(EHHDLLGPNBG.id, PNDNEMDPFHC: false);
		}
		EHHDLLGPNBG = null;
	}

	private void AHFHGIMNCCA(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void MMJLEFLHLLK(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.EIKJEGHELNK(FCEIGDLFOMH);
			DCKFGIKPPGH.GGLBLHKGCAO();
		}
	}

	public virtual void DKMEHOEOADL()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LALDCFHJFDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHHEFCNLPEC));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(NDKDIBBOEFC);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
		}
		EHHDLLGPNBG = null;
	}

	public virtual void AMPACMLGJEB()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HLJPLBOBDLN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FCJCCABKOGC));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(NDKDIBBOEFC);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
		}
		EHHDLLGPNBG = null;
	}

	public void HFNDCJNMPIA(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.HJOCCDLNFLN();
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(MKFCFLAGGOD);
		Singleton<PlayerTexturePool>.instance.EPPEDDFMHIB(KJJDIMJGFJC);
		Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(ALAJGOPHOAN);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.EGNEDNBPOEF();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1410f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.IEFOIJAFOJC();
		int num = -154;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -72;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(182f / NPECJCIKCBI.transform.localScale.x, 861f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= 23;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 38f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 999f, 618f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.CountryCodeSpriteName(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 169f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 547f : 57f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(668f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BFHAFBOBHMD));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GFHENJLAHID));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PNPLPOJHPPB));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(PFCJDKFPIBN));
	}

	private void ANKJLHLECKE(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void POLOPBEOOCB(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.GJHFCKMAMIE(FCEIGDLFOMH);
			DCKFGIKPPGH.BFKPPMIKNAA();
		}
	}

	public void KKIECDOFBEO(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.Reset();
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(MKFCFLAGGOD);
		Singleton<PlayerTexturePool>.instance.MDFAHMDJFDB(BAJFMDBAKKM);
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(ALAJGOPHOAN, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.EGNEDNBPOEF();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1921f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.JNODDKLJOAG();
		int num = 28;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -92;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(1191f / NPECJCIKCBI.transform.localScale.x, 1963f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -73;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1517f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1795f, 875f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.CountryCodeSpriteName(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 1787f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 92f : 434f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(839f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CAOBDLOBLAF));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GCAKFFHMAJO));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LHHEFCNLPEC));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DCELLKPDLDI));
	}

	private void MKHBLGNPKOH(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.BIEIDBBDNIF(FCEIGDLFOMH);
			DCKFGIKPPGH.AILNJNAGPGO();
		}
	}

	private void FCNKIEPEAAG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.avatar = FCEIGDLFOMH;
			DCKFGIKPPGH.UpdateIcon();
		}
	}

	private void GFHENJLAHID(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	public virtual void LHCKICBJALK()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PNPLPOJHPPB));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(NDKDIBBOEFC);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	public void DKFBDPBIABB(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= KJJDIMJGFJC;
		Singleton<PlayerTexturePool>.instance.HGBBFFJLDJI(DFHJCGPNFLE);
		Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(ALAJGOPHOAN, PNDNEMDPFHC: false);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.KJFPCOMOLLD();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 530f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.displayString;
		int num = -113;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -95;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(1961f / NPECJCIKCBI.transform.localScale.x, 91f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -93;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 429f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1125f, 1080f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.BFGCBNLOIMN(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 805f;
		}
		else
		{
			bool flag4 = EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 1236f : 274f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(429f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CPKAHGCGLKI));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CODNBIDNPPI));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AHFHGIMNCCA));
	}

	public void NPLNGMLILNH(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.HEOPOOMLPJF();
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(ECKJKFBMBFO);
		Singleton<PlayerTexturePool>.instance.BCGAIKBHILI(IFPAIAELCGP);
		Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(ALAJGOPHOAN);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.LMNDFNIKIFI();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1913f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.GIIHOHGFHBO();
		int num = 158;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -27;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(971f / NPECJCIKCBI.transform.localScale.x, 8f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -109;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 57f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1035f, 1668f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.CountryCodeSpriteName(ALAJGOPHOAN.country);
		bool flag3 = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 171f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 619f : 518f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1754f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DEBKFLAJGFD));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NOCAIHEJNFK));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AHFHGIMNCCA));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ANKJLHLECKE));
	}

	public void InitializeMember(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(ALAJGOPHOAN);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.iconName;
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 50f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.displayString;
		int num = 311;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= 40;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(30f / NPECJCIKCBI.transform.localScale.x, 30f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= 41;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 0f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 33f, 20f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.CountryCodeSpriteName(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 1f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 1f : 0.5f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(0.5f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
	}

	private void FFAFDDGCPKF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public void MEEJGPJJABO(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.NMEJKACLHKJ();
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(IFPAIAELCGP);
		Singleton<PlayerTexturePool>.instance.GENOIIGKOIK(MKHBLGNPKOH);
		Singleton<PlayerTexturePool>.instance.MFKFEHJBEPA(ALAJGOPHOAN);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.NOHAFIDFPCM();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 711f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.DLCFFHEKBAA();
		int num = -7;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -98;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(470f / NPECJCIKCBI.transform.localScale.x, 1358f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= 120;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 6f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 284f, 1584f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.CountryCodeSpriteName(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 424f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 998f : 1440f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(289f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NMNLBIKPBND));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HLJPLBOBDLN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NHIEGEGDHAE));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EEBDNDMJGIG));
	}

	private void EKBECFABEMP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void ILBLPGBCEKH()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HLJPLBOBDLN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EEAFOIIKONM));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(KJJDIMJGFJC);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	public void IMDBFKDHCAM(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.OMDFNFHKFBK();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= KJKGJLBGEEL;
		Singleton<PlayerTexturePool>.instance.MMAGKGAKHAD(NAEFOLMDNOP);
		Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.KJFPCOMOLLD();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1164f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.GIIHOHGFHBO();
		int num = -160;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown == WarArenaCrown.None;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= 22;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(403f / NPECJCIKCBI.transform.localScale.x, 1713f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -50;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 565f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 941f, 468f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.IEDGPHEPJEK(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 1742f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 1112f : 570f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(540f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CAOBDLOBLAF));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HHGPAMKLJFJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LCLBMLBKOFO));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FIMAPCNJNAI));
	}

	public virtual void HOCPBJGFEON()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(APIBEKDDDKB));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PFCJDKFPIBN));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(NBAIMPNKMPP);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true);
		}
		EHHDLLGPNBG = null;
	}

	public void DDLCKFECGNI(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.Reset();
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(MKFCFLAGGOD);
		Singleton<PlayerTexturePool>.instance.BMNHPDMPMLG(MMJLEFLHLLK);
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.GIEIIPBAIBK();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1570f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.JNODDKLJOAG();
		int num = -14;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown == WarArenaCrown.None;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -100;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(888f / NPECJCIKCBI.transform.localScale.x, 974f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= 121;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1286f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 527f, 578f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.BFGCBNLOIMN(ALAJGOPHOAN.country);
		bool flag3 = string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 206f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 1083f : 456f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1890f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NMNLBIKPBND));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CAOBDLOBLAF));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EGJLBJHJGFM));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GOOMCGDNIGH));
	}

	private void APIBEKDDDKB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void CODNBIDNPPI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void GLGEJMMPGIF()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HHGPAMKLJFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AHFHGIMNCCA));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(MMJLEFLHLLK);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	public void PNAFAEAAINI(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.OOOLABBEKDF();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= IHIILICAFGF;
		Singleton<PlayerTexturePool>.instance.ACEFBBGOINN(MKHBLGNPKOH);
		Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.EGNEDNBPOEF();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1537f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.displayString;
		int num = -132;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown == WarArenaCrown.None;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= 22;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(399f / NPECJCIKCBI.transform.localScale.x, 1397f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() == PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -5;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1085f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1187f, 1339f, num);
		KHHLLNJAKAL.repositionNow = true;
		string text = GameVariables.IDOFIHFGOKD(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 737f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 307f : 279f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(945f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GCAKFFHMAJO));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HHGPAMKLJFJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ANKJLHLECKE));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DCELLKPDLDI));
	}

	private void FPDEBCFJJHD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void EEBDNDMJGIG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public virtual void PCDBEEACOKN()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MAHOLKEABOM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FCJCCABKOGC));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(ANPEPPGFENN);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}

	private void IFPAIAELCGP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.KHIPFLOFKMC(FCEIGDLFOMH);
			DCKFGIKPPGH.OKHFOOHNBDF();
		}
	}

	private void NMNLBIKPBND(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void CGOCPANEADO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	private void BAJFMDBAKKM(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.ECKBKNCJLOC(FCEIGDLFOMH);
			DCKFGIKPPGH.IFPLAMJKIKH();
		}
	}

	public void DNGADMNKFAI(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.NMEJKACLHKJ();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= HIHCBOMMEON;
		Singleton<PlayerTexturePool>.instance.EPPEDDFMHIB(DFHJCGPNFLE);
		Singleton<PlayerTexturePool>.instance.MFKFEHJBEPA(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.GIEIIPBAIBK();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1403f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.LPANGEJPPOE();
		int num = -188;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -65;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(1682f / NPECJCIKCBI.transform.localScale.x, 585f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Offline;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -29;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 1187f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 1799f, 1435f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.CountryCodeSpriteName(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 1713f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 645f : 494f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1690f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BFHAFBOBHMD));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAHOLKEABOM));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FPDEBCFJJHD));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EEBDNDMJGIG));
	}

	private void OGGLONHKDIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	public virtual void PDFILOJGOMM()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICCCGGEEFJF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LJJJICJDHHL));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(NBAIMPNKMPP);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(EHHDLLGPNBG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true);
		}
		EHHDLLGPNBG = null;
	}

	private void CAOBDLOBLAF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	private void ANPEPPGFENN(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (EHHDLLGPNBG != null && EHHDLLGPNBG.id == ALIIBMLMNKA)
		{
			DCKFGIKPPGH.OLJPGNNKCKI(FCEIGDLFOMH);
			DCKFGIKPPGH.GPHGDAKLAJK();
		}
	}

	private void GOOMCGDNIGH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(EHHDLLGPNBG.name, EHHDLLGPNBG.id, BNNKPKDPLPP: false);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(EHHDLLGPNBG.id);
		}
		EHHDLLGPNBG = null;
	}

	private void DAGDGEJCDFP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(EHHDLLGPNBG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(MEPFCGAAEEF.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(EHHDLLGPNBG.name, EHHDLLGPNBG.id);
		}
	}

	public void MDPDCDANKOH(DatabasePlayer ALAJGOPHOAN, int MDOPFNNFLFB)
	{
		EHHDLLGPNBG = ALAJGOPHOAN;
		LCPBNBLGFIA.gameObject.SetActive(ALAJGOPHOAN.id == GameLoginManager.currentPlayer.id);
		DCKFGIKPPGH.LFOLGBNBBAG();
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(POLOPBEOOCB);
		Singleton<PlayerTexturePool>.instance.HGBBFFJLDJI(POLOPBEOOCB);
		Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(ALAJGOPHOAN, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(ALAJGOPHOAN.level);
		GFKNLLCKJOG.spriteName = levelDefinition.EGNEDNBPOEF();
		GFKNLLCKJOG.MakePixelPerfect();
		float multiplier = 1427f / GFKNLLCKJOG.transform.localScale.x;
		GFKNLLCKJOG.transform.localScale = GFKNLLCKJOG.transform.localScale.MultiplyXY(multiplier);
		DLAMMHGPADA.text = levelDefinition.IEFOIJAFOJC();
		int num = -160;
		WarArenaCrown warArenaCrown = ALAJGOPHOAN.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= -6;
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			multiplier = Math.Min(1849f / NPECJCIKCBI.transform.localScale.x, 1988f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = ALAJGOPHOAN.GetRealStatus() != PlayerStatus.Online;
		BJCMNMGCGNN.SetActive(flag2);
		if (flag2)
		{
			num -= -67;
		}
		MEPFCGAAEEF.text = ALAJGOPHOAN.name;
		TweenColor.Begin(MEPFCGAAEEF.gameObject, 54f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(MEPFCGAAEEF, 292f, 683f, num);
		KHHLLNJAKAL.repositionNow = false;
		string text = GameVariables.IEDGPHEPJEK(ALAJGOPHOAN.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		ALFOJMLJFGD.gameObject.SetActive(flag3);
		if (flag3)
		{
			ALFOJMLJFGD.spriteName = text;
		}
		IGNNPMHKICA.text = Localization.Localize(GameVariables.FDJKMGDLGDO[ALAJGOPHOAN.squadRank]);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.reputation);
		LKCHKLPFEKM.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.squadPoints);
		NBGJFPBGGIO.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.armyPowerX10);
		if (EHHDLLGPNBG.isInBeginnersLeague)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(EHHDLLGPNBG.beginnersLeague);
			NNMCKEECNFK.alpha = 878f;
		}
		else
		{
			bool flag4 = !EHHDLLGPNBG.isInLeague;
			League leagueTier = EHHDLLGPNBG.leagueTier;
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			NNMCKEECNFK.alpha = ((!flag4) ? 985f : 1680f);
		}
		NNMCKEECNFK.MakePixelPerfect();
		NNMCKEECNFK.transform.localScale = NNMCKEECNFK.transform.localScale.MultiplyXY(1440f);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(EHHDLLGPNBG.skill);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NMNLBIKPBND));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OPIAOAGOMNM));
	}

	public virtual void NBOMCFHBLOF()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICCCGGEEFJF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LJJJICJDHHL));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(POLOPBEOOCB);
		if (EHHDLLGPNBG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(EHHDLLGPNBG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		EHHDLLGPNBG = null;
	}
}
