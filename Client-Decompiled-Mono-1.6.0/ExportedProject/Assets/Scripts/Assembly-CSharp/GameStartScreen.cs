using System.Runtime.CompilerServices;
using UnityEngine;

public class GameStartScreen : GuiScreenSingle<GameStartScreen>
{
	[Header("Player 1 Part (Left)")]
	public GameObject HIOHPOMALHE;

	public PlayerIcon IFCIHNCCADJ;

	public UISprite NEFBBJLKNKA;

	public UISprite GMKFMNAHAJH;

	public UILabel AHHABDEJPJL;

	public UITable BDADGLHAOBA;

	public UISprite LMFDBNECCGO;

	public UISprite PEKHKDCCMGN;

	public UISprite IFBNKNIGOKJ;

	[Header("-Power Band Part")]
	public GameObject KAOOPIHJPNG;

	public UISprite NIBAOAONCLA;

	public UILabel MHKIFHKBMOD;

	public UISprite JCFMFAOJHGK;

	[Header("Middle")]
	public GameObject IIHJFLPFIEF;

	[Header("Player 2 Part (Right)")]
	public GameObject DNDCODMGGEE;

	public PlayerIcon DEIGAMPPJPD;

	public UISprite AEKGHHGPFIN;

	public UISprite MGGGCGAOPHJ;

	public UILabel GBHDAKINMIL;

	public UITable GHICBPOOMEI;

	public UISprite PEJCGKACMCO;

	public UISprite DMACIGNEEJP;

	public UISprite LPOJICGIOPL;

	[Header("-Power Band Part")]
	public GameObject ANNIDFMIMAN;

	public UISprite PKMIIPLIGPO;

	public UILabel MBBNHBMPHKC;

	public UISprite LNMMJFGLCNP;

	private void CLIAOCAGHGN(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		LMFDBNECCGO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG != WarArenaCrown.None;
		IFBNKNIGOKJ.gameObject.SetActive(flag);
		if (flag)
		{
			IFBNKNIGOKJ.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			IFBNKNIGOKJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1157f / IFBNKNIGOKJ.transform.localScale.x, 1007f / IFBNKNIGOKJ.transform.localScale.y);
			IFBNKNIGOKJ.transform.localScale = IFBNKNIGOKJ.transform.localScale.MultiplyXY(multiplier);
		}
		IFCIHNCCADJ.GKIHHKCAEOG(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(IFCIHNCCADJ.PKHHKJLGHFM, 224f, 1711f, -125);
		BDADGLHAOBA.repositionNow = false;
	}

	private void HKIJOJOAEEP(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK == null || IIOKFKPMPPK.isEmptyPowerBand;
		KAOOPIHJPNG.SetActive(flag);
		if (flag)
		{
			NIBAOAONCLA.spriteName = IIOKFKPMPPK.icon;
			NIBAOAONCLA.MakePixelPerfect();
			MHKIFHKBMOD.text = IIOKFKPMPPK.JIHLMBOBKHL();
			JCFMFAOJHGK.spriteName = IIOKFKPMPPK.LIIOLLAAHGB();
			JCFMFAOJHGK.MakePixelPerfect();
			JCFMFAOJHGK.color = IIOKFKPMPPK.GPDIGNGOAEH();
			JCFMFAOJHGK.alpha = 1264f;
		}
	}

	private void FANIMIGCGLI()
	{
		Transform parent = IFCIHNCCADJ.PKHHKJLGHFM.transform.parent;
		if (IFBNKNIGOKJ.gameObject.activeSelf)
		{
			parent = IFBNKNIGOKJ.transform.parent;
		}
		float num = 0f - BDADGLHAOBA.padding.x - (parent.localPosition.x - BDADGLHAOBA.padding.x) / 1223f;
		float num2 = UIHelper.activeWidthSafe / 1270f - 634f - 1595f;
		if (num2 < Mathf.Abs(num))
		{
			num = 0f - num2;
		}
		BDADGLHAOBA.transform.localPosition = BDADGLHAOBA.transform.localPosition.ReplaceX(num);
	}

	private void JDJNDFHMHIB(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.decalValueString;
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.decalMiniIcon;
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.GPDIGNGOAEH();
			LNMMJFGLCNP.alpha = 456f;
		}
	}

	public override void FABCFPJHOBH(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		TweenAlpha.Begin(HIOHPOMALHE, 1826f, 1648f);
		TweenAlpha.Begin(IIHJFLPFIEF, 739f, 788f);
		TweenAlpha.Begin(DNDCODMGGEE, 1805f, 1475f);
	}

	private void OBBDANOPLHJ(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(0);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 236f;
		}
		else if (HNEFOLPHMHK > 0)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 1049f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = ((!GKEOILLNCHG) ? 1605f : 70f);
		}
		else
		{
			DMACIGNEEJP.gameObject.SetActive(false);
		}
	}

	private void HMNKKPEDPDI()
	{
		Transform parent = DEIGAMPPJPD.PKHHKJLGHFM.transform.parent;
		if (LPOJICGIOPL.gameObject.activeSelf)
		{
			parent = LPOJICGIOPL.transform.parent;
		}
		float num = (parent.localPosition.x - GHICBPOOMEI.padding.x) / 172f;
		float num2 = 0f - GHICBPOOMEI.padding.x - num;
		float num3 = UIHelper.activeWidthSafe / 473f - 286f - 53f;
		if (num3 < Mathf.Abs(num))
		{
			num2 = num2 - num + num3;
		}
		GHICBPOOMEI.transform.localPosition = GHICBPOOMEI.transform.localPosition.ReplaceX(num2);
	}

	private void BJPIDPBPNPG(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK == null || IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.decalValueString;
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.LIIOLLAAHGB();
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.GPDIGNGOAEH();
			LNMMJFGLCNP.alpha = 1689f;
		}
	}

	protected virtual void NHLBCFPFHED()
	{
		Singleton<GameCamera>.instance.AnimationFinished += KDLHCNCMOCJ;
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += FJDNHMAEKAE;
		BDADGLHAOBA.onReposition = OJEFEOLBEJK;
		GHICBPOOMEI.onReposition = MBGBPFDDDAG;
	}

	private void GDCBEMJCMMF(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 0.7f;
		}
		else if (HNEFOLPHMHK > 0)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 1f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = ((!GKEOILLNCHG) ? 0.7f : 1f);
		}
		else
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
		}
	}

	private void IGNNKCHLNOD()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 1460f, 734f);
		TweenAlpha.Begin(IIHJFLPFIEF, 610f, 653f);
		TweenAlpha.Begin(HIOHPOMALHE, 772f, 247f);
	}

	private void ANIDBHGOHNN()
	{
		IFCIHNCCADJ.avatar = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK;
		PHBMAGNODMP(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL);
		FEOJFCABOEM(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		NLODHENBGEJ(null);
		GDCBEMJCMMF(1, League.NoLeague, 0, false);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[3];
		BHGDABMNHBL(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB]);
		DEIGAMPPJPD.avatar = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK;
		JJHAGBKENJA(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL);
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		HDNOGLKPCAL(1, League.NoLeague, 0, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[3];
		PEDOCOMPJBG(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB2]);
	}

	private void BPFILAMIKKJ()
	{
		TweenAlpha.Begin(HIOHPOMALHE, 579f, 1887f);
		TweenScale.Begin(HIOHPOMALHE, 175f, new Vector3(1865f, 520f, 1144f), Vector3.one);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-55), 512f);
		InvokeAfterRealTime(IOIPIDPHHMI, 525f);
	}

	private void GMGLBALMHAP()
	{
		IFCIHNCCADJ.KGJCNNANACM(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		PHBMAGNODMP(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO());
		CLIAOCAGHGN(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		NGKMIIGKIKK(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		EAAMHKFCEBK(1, League.Bronze3, 1, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[6];
		HLFJNGOKOAB(CamosManager.instance.playerVisualCategories[6][iNFLHPGMEOB]);
		DEIGAMPPJPD.DHDPJLAPAPO(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		AEAMIHEMOHD(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BPNPPKPCFGN());
		INNNCOLBMCH(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		HDNOGLKPCAL(0, League.Bronze3, 1, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[0];
		JMNLBEKFFFG(CamosManager.instance.playerVisualCategories[8][iNFLHPGMEOB2]);
	}

	private void ILNCNLHDEPH(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && !IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.FKIHLEGENCE();
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.LIIOLLAAHGB();
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.decalMiniIconColor;
			LNMMJFGLCNP.alpha = 1016f;
		}
	}

	private void GHOBJCFONAD()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 496f, 1443f);
		TweenScale.Begin(DNDCODMGGEE, 134f, new Vector3(1746f, 145f, 208f), Vector3.one);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)122, 897f);
		InvokeAfterRealTime(ALGGJINEJEK, 421f);
	}

	private void OJONCBCPDND()
	{
		TweenAlpha.Begin(HIOHPOMALHE, 1210f, 1071f);
		TweenScale.Begin(HIOHPOMALHE, 925f, new Vector3(1912f, 1632f, 1025f), Vector3.one);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-79), 410f);
		InvokeAfterRealTime(KMKMHPHNMFO, 642f);
	}

	private void GFGHNBKIPOB(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 1;
		GMKFMNAHAJH.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 0;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			AHHABDEJPJL.text = levelDefinition.FDACEOHEGPN();
			GMKFMNAHAJH.spriteName = levelDefinition.CDLBEKECJNK();
		}
		else
		{
			AHHABDEJPJL.text = string.Empty;
		}
	}

	private void OHJLMDMCBCK(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		PEJCGKACMCO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG == WarArenaCrown.BronzeCrown;
		LPOJICGIOPL.gameObject.SetActive(flag);
		if (flag)
		{
			LPOJICGIOPL.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			LPOJICGIOPL.MakePixelPerfect();
			float multiplier = Mathf.Min(852f / LPOJICGIOPL.transform.localScale.x, 32f / LPOJICGIOPL.transform.localScale.y);
			LPOJICGIOPL.transform.localScale = LPOJICGIOPL.transform.localScale.MultiplyXY(multiplier);
		}
		DEIGAMPPJPD.BMOMBHEJACH(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(DEIGAMPPJPD.PKHHKJLGHFM, 286f, 598f, 83);
		GHICBPOOMEI.repositionNow = true;
	}

	private void FLBFNPNNJGN(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 0)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 959f;
		}
		else if (HNEFOLPHMHK > 0)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 546f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = ((!GKEOILLNCHG) ? 350f : 369f);
		}
		else
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
		}
	}

	private void FNHPOKNBJPB()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 383f, 1405f);
		TweenScale.Begin(DNDCODMGGEE, 1272f, new Vector3(1320f, 36f, 1103f), Vector3.one);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-41), 1837f);
		InvokeAfterRealTime(IGNNKCHLNOD, 1450f);
	}

	private void DJOEMHFGEIP(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		NEFBBJLKNKA.gameObject.SetActive(flag);
		if (flag)
		{
			NEFBBJLKNKA.spriteName = GameVariables.IEDGPHEPJEK(CAAKEPHMPHI);
		}
	}

	public override void AnimateShow(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		TweenAlpha.Begin(HIOHPOMALHE, 0f, 0f);
		TweenAlpha.Begin(IIHJFLPFIEF, 0f, 0f);
		TweenAlpha.Begin(DNDCODMGGEE, 0f, 0f);
	}

	private void AEAMIHEMOHD(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 0;
		MGGGCGAOPHJ.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 0;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			GBHDAKINMIL.text = levelDefinition.displayString;
			MGGGCGAOPHJ.spriteName = levelDefinition.NOHAFIDFPCM();
		}
		else
		{
			GBHDAKINMIL.text = string.Empty;
		}
	}

	private void IFAKJFAOCDL()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 1932f, 1902f);
		TweenAlpha.Begin(IIHJFLPFIEF, 1208f, 94f);
		TweenAlpha.Begin(HIOHPOMALHE, 1482f, 1054f);
	}

	private void KMKMHPHNMFO()
	{
		TweenAlpha.Begin(IIHJFLPFIEF, 609f, 1127f);
		TweenScale.Begin(IIHJFLPFIEF, 1829f, new Vector3(932f, 1560f, 178f), Vector3.one);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DogTagUsed, 747f);
	}

	public virtual void DCNGEGFNAGG()
	{
	}

	private void HGOPFKCDGEB(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK == null || !IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.decalValueString;
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.decalMiniIcon;
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.decalMiniIconColor;
			LNMMJFGLCNP.alpha = 90f;
		}
	}

	public virtual void BBFODOOJBBA(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		TweenAlpha.Begin(HIOHPOMALHE, 54f, 322f);
		TweenAlpha.Begin(IIHJFLPFIEF, 994f, 1825f);
		TweenAlpha.Begin(DNDCODMGGEE, 1380f, 710f);
	}

	private void AIPIMEPMDDN()
	{
		IFCIHNCCADJ.avatar = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK;
		PHBMAGNODMP(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL);
		FEOJFCABOEM(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		NLODHENBGEJ(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		GDCBEMJCMMF(1, League.NoLeague, 0, false);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[3];
		BHGDABMNHBL(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB]);
		DEIGAMPPJPD.avatar = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK;
		JJHAGBKENJA(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL);
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		HDNOGLKPCAL(1, League.NoLeague, 0, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[3];
		PEDOCOMPJBG(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB2]);
	}

	private void EAIGEAALAMB()
	{
		IFCIHNCCADJ.BIEIDBBDNIF(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		DLBJODBNPHA(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OCPEHLIIGML());
		FEOJFCABOEM(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		NGKMIIGKIKK(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		FLBFNPNNJGN(1, League.Bronze3, 1, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[3];
		JIHEPDNKKIO(CamosManager.instance.playerVisualCategories[4][iNFLHPGMEOB]);
		DEIGAMPPJPD.OLJPGNNKCKI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OEJKKJJFDFL());
		ENCGLEIDDFO(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		CALFDOJBEKP(0, League.NoLeague, 1, true);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[3];
		HGOPFKCDGEB(CamosManager.instance.playerVisualCategories[0][iNFLHPGMEOB2]);
	}

	private void JJHAGBKENJA(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 0;
		MGGGCGAOPHJ.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			GBHDAKINMIL.text = levelDefinition.displayString;
			MGGGCGAOPHJ.spriteName = levelDefinition.iconName;
		}
		else
		{
			GBHDAKINMIL.text = string.Empty;
		}
	}

	private void HGIMJOJPHGL()
	{
		IFCIHNCCADJ.LOCLNGEMNCC(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		GFGHNBKIPOB(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO());
		GBFIOODGMOH(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HMGOHGOLMJB, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		NIFAJADOBPF(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		FNPODLBCFNF(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.IOFBJPJPEMK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BMNDININJCE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HNEFOLPHMHK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.GKEOILLNCHG);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[8];
		HKIJOJOAEEP(CamosManager.instance.playerVisualCategories[4][iNFLHPGMEOB]);
		DEIGAMPPJPD.KHIPFLOFKMC(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		CKDAIGFHKCJ(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO());
		INNNCOLBMCH(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		GCFNHMGDALG(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.IOFBJPJPEMK, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BMNDININJCE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HNEFOLPHMHK, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.GKEOILLNCHG);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[6];
		HCAAGIAADDP(CamosManager.instance.playerVisualCategories[6][iNFLHPGMEOB2]);
	}

	public virtual void ADHKCLPIPGL()
	{
		base.DoBeforeShowUp();
		Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
	}

	public virtual void OEJFBEOJNFO(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		TweenAlpha.Begin(HIOHPOMALHE, 152f, 1104f);
		TweenAlpha.Begin(IIHJFLPFIEF, 221f, 951f);
		TweenAlpha.Begin(DNDCODMGGEE, 455f, 275f);
	}

	private void HCAAGIAADDP(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && !IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.decalValueString;
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.DEAIJJIAEFP();
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.decalMiniIconColor;
			LNMMJFGLCNP.alpha = 326f;
		}
	}

	private void DNIJMJEAHGD()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 841f, 685f);
		TweenAlpha.Begin(IIHJFLPFIEF, 1357f, 1700f);
		TweenAlpha.Begin(HIOHPOMALHE, 1916f, 413f);
	}

	private void IOIPIDPHHMI()
	{
		TweenAlpha.Begin(IIHJFLPFIEF, 1713f, 1507f);
		TweenScale.Begin(IIHJFLPFIEF, 414f, new Vector3(1806f, 59f, 576f), Vector3.one);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-87), 717f);
	}

	private void BBPDAJLJOOK()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 843f, 1324f);
		TweenAlpha.Begin(IIHJFLPFIEF, 1403f, 197f);
		TweenAlpha.Begin(HIOHPOMALHE, 566f, 932f);
	}

	public virtual void PDHNLAMPOBN()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			PNBINDCAPNB();
		}
		else if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			JHKCCNINGBL();
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			IBKABGMLNNJ();
		}
		else
		{
			GFEKMJAGCNI();
		}
	}

	public virtual void JOMODNPNMOD(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		TweenAlpha.Begin(HIOHPOMALHE, 1740f, 1405f);
		TweenAlpha.Begin(IIHJFLPFIEF, 1743f, 1256f);
		TweenAlpha.Begin(DNDCODMGGEE, 519f, 221f);
	}

	private void CALFDOJBEKP(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(0);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 734f;
		}
		else if (HNEFOLPHMHK > 0)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 1394f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = ((!GKEOILLNCHG) ? 61f : 649f);
		}
		else
		{
			DMACIGNEEJP.gameObject.SetActive(true);
		}
	}

	private void IPCCICNFAFA(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 0;
		GMKFMNAHAJH.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			AHHABDEJPJL.text = levelDefinition.GIIHOHGFHBO();
			GMKFMNAHAJH.spriteName = levelDefinition.KJFPCOMOLLD();
		}
		else
		{
			AHHABDEJPJL.text = string.Empty;
		}
	}

	private void NLODHENBGEJ(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		NEFBBJLKNKA.gameObject.SetActive(flag);
		if (flag)
		{
			NEFBBJLKNKA.spriteName = GameVariables.CountryCodeSpriteName(CAAKEPHMPHI);
		}
	}

	public override void InitGUIValues()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			AIPIMEPMDDN();
		}
		else if (Singleton<GameController>.instance.isMission)
		{
			ANIDBHGOHNN();
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			NBODLACOHEC();
		}
		else
		{
			GFEKMJAGCNI();
		}
	}

	public virtual void DFNABAFOPLE()
	{
		base.DoBeforeShowUp();
		Singleton<GuiManager>.instance.JPLLGFNECAG(GuiElementSingle<PlayerHealthBars>.instance);
	}

	private void OCNBKEJBANH()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 1656f, 743f);
		TweenAlpha.Begin(IIHJFLPFIEF, 1979f, 766f);
		TweenAlpha.Begin(HIOHPOMALHE, 691f, 401f);
	}

	private void GCFNHMGDALG(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 0)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(0);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 1508f;
		}
		else if (HNEFOLPHMHK > 0)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 1994f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = ((!GKEOILLNCHG) ? 1708f : 1997f);
		}
		else
		{
			DMACIGNEEJP.gameObject.SetActive(true);
		}
	}

	private void PBHMAFFHOGM(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(1);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 808f;
		}
		else if (HNEFOLPHMHK > 1)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 387f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = ((!GKEOILLNCHG) ? 1527f : 23f);
		}
		else
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
		}
	}

	public virtual void AIIJHNNODDM()
	{
	}

	private void DLBJODBNPHA(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 1;
		GMKFMNAHAJH.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			AHHABDEJPJL.text = levelDefinition.FDACEOHEGPN();
			GMKFMNAHAJH.spriteName = levelDefinition.KJFPCOMOLLD();
		}
		else
		{
			AHHABDEJPJL.text = string.Empty;
		}
	}

	private void JGIMALFEHCP(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		AEKGHHGPFIN.gameObject.SetActive(flag);
		if (flag)
		{
			AEKGHHGPFIN.spriteName = GameVariables.CountryCodeSpriteName(CAAKEPHMPHI);
		}
	}

	private void LABKOGAGEKE(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		LMFDBNECCGO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG != WarArenaCrown.BronzeCrown;
		IFBNKNIGOKJ.gameObject.SetActive(flag);
		if (flag)
		{
			IFBNKNIGOKJ.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			IFBNKNIGOKJ.MakePixelPerfect();
			float multiplier = Mathf.Min(545f / IFBNKNIGOKJ.transform.localScale.x, 1561f / IFBNKNIGOKJ.transform.localScale.y);
			IFBNKNIGOKJ.transform.localScale = IFBNKNIGOKJ.transform.localScale.MultiplyXY(multiplier);
		}
		IFCIHNCCADJ.MPOJAMOIBBF(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(IFCIHNCCADJ.PKHHKJLGHFM, 1331f, 617f, -60);
		BDADGLHAOBA.repositionNow = true;
	}

	public virtual void LFJGHLNJPHL()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			GKKAPGGLOCL();
		}
		else if (Singleton<GameController>.instance.isMission)
		{
			OGLPDOMPDPL();
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			BDAPDKOODNI();
		}
		else
		{
			GFEKMJAGCNI();
		}
	}

	public override void OnBack()
	{
	}

	private void AFDNODFKKNG(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(1);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 919f;
		}
		else if (HNEFOLPHMHK > 1)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 501f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = ((!GKEOILLNCHG) ? 460f : 473f);
		}
		else
		{
			DMACIGNEEJP.gameObject.SetActive(false);
		}
	}

	private void HBPGEDLEBKC(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 0;
		GMKFMNAHAJH.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			AHHABDEJPJL.text = levelDefinition.DLCFFHEKBAA();
			GMKFMNAHAJH.spriteName = levelDefinition.GIEIIPBAIBK();
		}
		else
		{
			AHHABDEJPJL.text = string.Empty;
		}
	}

	private void KILNOHANDEP()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 1701f, 78f);
		TweenAlpha.Begin(IIHJFLPFIEF, 19f, 648f);
		TweenAlpha.Begin(HIOHPOMALHE, 647f, 1926f);
	}

	private void GFEKMJAGCNI()
	{
		IFCIHNCCADJ.avatar = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK;
		PHBMAGNODMP(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL);
		FEOJFCABOEM(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HMGOHGOLMJB, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		NLODHENBGEJ(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		GDCBEMJCMMF(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.IOFBJPJPEMK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BMNDININJCE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HNEFOLPHMHK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.GKEOILLNCHG);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[3];
		BHGDABMNHBL(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB]);
		DEIGAMPPJPD.avatar = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK;
		JJHAGBKENJA(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL);
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		HDNOGLKPCAL(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.IOFBJPJPEMK, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BMNDININJCE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HNEFOLPHMHK, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.GKEOILLNCHG);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[3];
		PEDOCOMPJBG(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB2]);
	}

	private void BHGDABMNHBL(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && !IIOKFKPMPPK.isEmptyPowerBand;
		KAOOPIHJPNG.SetActive(flag);
		if (flag)
		{
			NIBAOAONCLA.spriteName = IIOKFKPMPPK.icon;
			NIBAOAONCLA.MakePixelPerfect();
			MHKIFHKBMOD.text = IIOKFKPMPPK.decalValueString;
			JCFMFAOJHGK.spriteName = IIOKFKPMPPK.decalMiniIcon;
			JCFMFAOJHGK.MakePixelPerfect();
			JCFMFAOJHGK.color = IIOKFKPMPPK.decalMiniIconColor;
			JCFMFAOJHGK.alpha = 0f;
		}
	}

	private void CAFICDAANNO()
	{
		IFCIHNCCADJ.DJPNDAICDPN(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		HBPGEDLEBKC(1);
		FEOJFCABOEM(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		NLODHENBGEJ(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		MLGPJNPHJAH(0, League.NoLeague, 1, false);
		JIHEPDNKKIO(null);
		DEIGAMPPJPD.DHDPJLAPAPO(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		CKDAIGFHKCJ(1);
		FIKFLIKDCFB(false, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BIPHPDCMLDB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		AFDNODFKKNG(1, League.NoLeague, 0, false);
		JMNLBEKFFFG(null);
	}

	private void LHOIONMEGBE(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.JIHLMBOBKHL();
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.DEAIJJIAEFP();
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.decalMiniIconColor;
			LNMMJFGLCNP.alpha = 88f;
		}
	}

	private void FNPODLBCFNF(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(0);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 1347f;
		}
		else if (HNEFOLPHMHK > 1)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 176f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = ((!GKEOILLNCHG) ? 1235f : 407f);
		}
		else
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
	}

	private void JHKCCNINGBL()
	{
		IFCIHNCCADJ.JJGFMKCHIPE(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		DLBJODBNPHA(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OCPEHLIIGML());
		GBFIOODGMOH(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		NGKMIIGKIKK(null);
		PBHMAFFHOGM(1, League.Bronze3, 0, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[2];
		BHGDABMNHBL(CamosManager.instance.playerVisualCategories[6][iNFLHPGMEOB]);
		DEIGAMPPJPD.LOCLNGEMNCC(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO());
		INNNCOLBMCH(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		CPIMHMKNGPG(1, League.Bronze3, 1, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[8];
		HGOPFKCDGEB(CamosManager.instance.playerVisualCategories[7][iNFLHPGMEOB2]);
	}

	[CompilerGenerated]
	private void KKBCFGBHFOA()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 0.2f, 0f);
		TweenAlpha.Begin(IIHJFLPFIEF, 0.2f, 0f);
		TweenAlpha.Begin(HIOHPOMALHE, 0.2f, 0f);
	}

	public virtual void KCAFCPAFBMC()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			PNBINDCAPNB();
		}
		else if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			MNPPKEPEDJN();
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			NBODLACOHEC();
		}
		else
		{
			GFEKMJAGCNI();
		}
	}

	public virtual void FOAALJKPPPC()
	{
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			GMGLBALMHAP();
		}
		else if (Singleton<GameController>.instance.isMission)
		{
			ANIDBHGOHNN();
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			CAFICDAANNO();
		}
		else
		{
			KPNCDJOFDFH();
		}
	}

	private void HDNOGLKPCAL(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 0.7f;
		}
		else if (HNEFOLPHMHK > 0)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 1f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = ((!GKEOILLNCHG) ? 0.7f : 1f);
		}
		else
		{
			DMACIGNEEJP.gameObject.SetActive(false);
		}
	}

	private void LAEPNOMDPFA()
	{
		TweenAlpha.Begin(HIOHPOMALHE, 617f, 1828f);
		TweenScale.Begin(HIOHPOMALHE, 1851f, new Vector3(1700f, 1391f, 1795f), Vector3.one);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-63), 125f);
		InvokeAfterRealTime(IOIPIDPHHMI, 176f);
	}

	private void JIHEPDNKKIO(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK == null || IIOKFKPMPPK.isEmptyPowerBand;
		KAOOPIHJPNG.SetActive(flag);
		if (flag)
		{
			NIBAOAONCLA.spriteName = IIOKFKPMPPK.icon;
			NIBAOAONCLA.MakePixelPerfect();
			MHKIFHKBMOD.text = IIOKFKPMPPK.FKIHLEGENCE();
			JCFMFAOJHGK.spriteName = IIOKFKPMPPK.decalMiniIcon;
			JCFMFAOJHGK.MakePixelPerfect();
			JCFMFAOJHGK.color = IIOKFKPMPPK.decalMiniIconColor;
			JCFMFAOJHGK.alpha = 1101f;
		}
	}

	private void PNBINDCAPNB()
	{
		IFCIHNCCADJ.JIBFCGECCFI(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		IPCCICNFAFA(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL);
		FEOJFCABOEM(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		HEIJPDIOMID(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		PBHMAFFHOGM(1, League.Bronze3, 0, false);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[2];
		HLFJNGOKOAB(CamosManager.instance.playerVisualCategories[7][iNFLHPGMEOB]);
		DEIGAMPPJPD.KGJCNNANACM(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		CKDAIGFHKCJ(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL);
		CDJIIBLJHHM(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		HDNOGLKPCAL(1, League.NoLeague, 1, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[4];
		ENNADDNFCFE(CamosManager.instance.playerVisualCategories[7][iNFLHPGMEOB2]);
	}

	private void GBFIOODGMOH(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		LMFDBNECCGO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG == WarArenaCrown.None;
		IFBNKNIGOKJ.gameObject.SetActive(flag);
		if (flag)
		{
			IFBNKNIGOKJ.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			IFBNKNIGOKJ.MakePixelPerfect();
			float multiplier = Mathf.Min(135f / IFBNKNIGOKJ.transform.localScale.x, 1129f / IFBNKNIGOKJ.transform.localScale.y);
			IFBNKNIGOKJ.transform.localScale = IFBNKNIGOKJ.transform.localScale.MultiplyXY(multiplier);
		}
		IFCIHNCCADJ.AJLMACKOEPF(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(IFCIHNCCADJ.PKHHKJLGHFM, 1678f, 1123f, 121);
		BDADGLHAOBA.repositionNow = false;
	}

	public virtual void JOPPNGGBMCE()
	{
	}

	private void BIMFIBHNPCD()
	{
		Transform parent = DEIGAMPPJPD.PKHHKJLGHFM.transform.parent;
		if (LPOJICGIOPL.gameObject.activeSelf)
		{
			parent = LPOJICGIOPL.transform.parent;
		}
		float num = (parent.localPosition.x - GHICBPOOMEI.padding.x) / 659f;
		float num2 = 0f - GHICBPOOMEI.padding.x - num;
		float num3 = UIHelper.activeWidthSafe / 73f - 1422f - 968f;
		if (num3 < Mathf.Abs(num))
		{
			num2 = num2 - num + num3;
		}
		GHICBPOOMEI.transform.localPosition = GHICBPOOMEI.transform.localPosition.ReplaceX(num2);
	}

	private void OGLPDOMPDPL()
	{
		IFCIHNCCADJ.JIBFCGECCFI(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		IAGMNPHBPNE(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OEJKKJJFDFL());
		GBFIOODGMOH(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.BronzeCrown);
		HEIJPDIOMID(null);
		GDCBEMJCMMF(1, League.Bronze3, 0, false);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[3];
		BHGDABMNHBL(CamosManager.instance.playerVisualCategories[2][iNFLHPGMEOB]);
		DEIGAMPPJPD.JIBFCGECCFI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL);
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		FGGJPHOJPGA(1, League.NoLeague, 0, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[3];
		JMNLBEKFFFG(CamosManager.instance.playerVisualCategories[1][iNFLHPGMEOB2]);
	}

	private void FIKFLIKDCFB(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		PEJCGKACMCO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG != WarArenaCrown.None;
		LPOJICGIOPL.gameObject.SetActive(flag);
		if (flag)
		{
			LPOJICGIOPL.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			LPOJICGIOPL.MakePixelPerfect();
			float multiplier = Mathf.Min(60f / LPOJICGIOPL.transform.localScale.x, 60f / LPOJICGIOPL.transform.localScale.y);
			LPOJICGIOPL.transform.localScale = LPOJICGIOPL.transform.localScale.MultiplyXY(multiplier);
		}
		DEIGAMPPJPD.SetName(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(DEIGAMPPJPD.PKHHKJLGHFM, 66f, 50f, 720);
		GHICBPOOMEI.repositionNow = true;
	}

	protected virtual void CHPAFPBJAEM()
	{
		Singleton<GameCamera>.instance.AnimationFinished += NFPLEPGHGIN;
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += OJONCBCPDND;
		BDADGLHAOBA.onReposition = FANIMIGCGLI;
		GHICBPOOMEI.onReposition = BIMFIBHNPCD;
	}

	private void LEDDJFAJGHB()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 1824f, 1339f);
		TweenAlpha.Begin(IIHJFLPFIEF, 501f, 87f);
		TweenAlpha.Begin(HIOHPOMALHE, 1425f, 1949f);
	}

	private void OJEFEOLBEJK()
	{
		Transform parent = IFCIHNCCADJ.PKHHKJLGHFM.transform.parent;
		if (IFBNKNIGOKJ.gameObject.activeSelf)
		{
			parent = IFBNKNIGOKJ.transform.parent;
		}
		float num = 0f - BDADGLHAOBA.padding.x - (parent.localPosition.x - BDADGLHAOBA.padding.x) / 349f;
		float num2 = UIHelper.activeWidthSafe / 343f - 204f - 815f;
		if (num2 < Mathf.Abs(num))
		{
			num = 0f - num2;
		}
		BDADGLHAOBA.transform.localPosition = BDADGLHAOBA.transform.localPosition.ReplaceX(num);
	}

	private void ELCMENMFABN()
	{
		IFCIHNCCADJ.DHDPJLAPAPO(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		HBPGEDLEBKC(0);
		LABKOGAGEKE(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		NGKMIIGKIKK(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		MLGPJNPHJAH(0, League.NoLeague, 0, false);
		HKIJOJOAEEP(null);
		DEIGAMPPJPD.JIBFCGECCFI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(0);
		INNNCOLBMCH(false, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BIPHPDCMLDB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		GCFNHMGDALG(0, League.NoLeague, 0, false);
		BJPIDPBPNPG(null);
	}

	private void KPAHCHEJADL(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		NEFBBJLKNKA.gameObject.SetActive(flag);
		if (flag)
		{
			NEFBBJLKNKA.spriteName = GameVariables.IEDGPHEPJEK(CAAKEPHMPHI);
		}
	}

	private void NKGMLCONLJE(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && !IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.FKIHLEGENCE();
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.decalMiniIcon;
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.GPDIGNGOAEH();
			LNMMJFGLCNP.alpha = 299f;
		}
	}

	private void PCGAIHIJOGG()
	{
		IFCIHNCCADJ.KHIPFLOFKMC(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		GAOEHOFNBKL(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OEJKKJJFDFL());
		LABKOGAGEKE(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.BronzeCrown);
		KPAHCHEJADL(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		FLBFNPNNJGN(1, League.Bronze3, 0, false);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[2];
		JIHEPDNKKIO(CamosManager.instance.playerVisualCategories[2][iNFLHPGMEOB]);
		DEIGAMPPJPD.avatar = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK;
		CKDAIGFHKCJ(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OCPEHLIIGML());
		MIMOKCBDMII(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		OBBDANOPLHJ(0, League.NoLeague, 1, true);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[8];
		JDJNDFHMHIB(CamosManager.instance.playerVisualCategories[7][iNFLHPGMEOB2]);
	}

	private void KMJPOBKPOPI(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		NEFBBJLKNKA.gameObject.SetActive(flag);
		if (flag)
		{
			NEFBBJLKNKA.spriteName = GameVariables.BFGCBNLOIMN(CAAKEPHMPHI);
		}
	}

	private void NFPLEPGHGIN()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 0.25f, 1f);
		TweenScale.Begin(DNDCODMGGEE, 0.25f, new Vector3(3.5f, 3.5f, 1f), Vector3.one);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGamePhotoSound);
		InvokeAfterRealTime(delegate
		{
			TweenAlpha.Begin(DNDCODMGGEE, 0.2f, 0f);
			TweenAlpha.Begin(IIHJFLPFIEF, 0.2f, 0f);
			TweenAlpha.Begin(HIOHPOMALHE, 0.2f, 0f);
		}, 1.5f);
	}

	private void MIMOKCBDMII(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		PEJCGKACMCO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG == WarArenaCrown.BronzeCrown;
		LPOJICGIOPL.gameObject.SetActive(flag);
		if (flag)
		{
			LPOJICGIOPL.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			LPOJICGIOPL.MakePixelPerfect();
			float multiplier = Mathf.Min(1897f / LPOJICGIOPL.transform.localScale.x, 166f / LPOJICGIOPL.transform.localScale.y);
			LPOJICGIOPL.transform.localScale = LPOJICGIOPL.transform.localScale.MultiplyXY(multiplier);
		}
		DEIGAMPPJPD.GKIHHKCAEOG(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(DEIGAMPPJPD.PKHHKJLGHFM, 53f, 1642f, 163);
		GHICBPOOMEI.repositionNow = false;
	}

	private void MLGPJNPHJAH(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(0);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 1551f;
		}
		else if (HNEFOLPHMHK > 1)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 1383f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = ((!GKEOILLNCHG) ? 1646f : 915f);
		}
		else
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
		}
	}

	private void JBKEIKCGCHH(string CAAKEPHMPHI)
	{
		bool flag = string.IsNullOrEmpty(CAAKEPHMPHI);
		AEKGHHGPFIN.gameObject.SetActive(flag);
		if (flag)
		{
			AEKGHHGPFIN.spriteName = GameVariables.CountryCodeSpriteName(CAAKEPHMPHI);
		}
	}

	private void BBNHKONOGCF()
	{
		Transform parent = IFCIHNCCADJ.PKHHKJLGHFM.transform.parent;
		if (IFBNKNIGOKJ.gameObject.activeSelf)
		{
			parent = IFBNKNIGOKJ.transform.parent;
		}
		float num = 0f - BDADGLHAOBA.padding.x - (parent.localPosition.x - BDADGLHAOBA.padding.x) / 1578f;
		float num2 = UIHelper.activeWidthSafe / 1240f - 1400f - 1844f;
		if (num2 < Mathf.Abs(num))
		{
			num = 0f - num2;
		}
		BDADGLHAOBA.transform.localPosition = BDADGLHAOBA.transform.localPosition.ReplaceX(num);
	}

	private void NBODLACOHEC()
	{
		IFCIHNCCADJ.avatar = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK;
		PHBMAGNODMP(0);
		FEOJFCABOEM(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		NLODHENBGEJ(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		GDCBEMJCMMF(1, League.NoLeague, 0, false);
		BHGDABMNHBL(null);
		DEIGAMPPJPD.avatar = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK;
		JJHAGBKENJA(0);
		FIKFLIKDCFB(false, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		HDNOGLKPCAL(1, League.NoLeague, 0, false);
		PEDOCOMPJBG(null);
	}

	private void AOKLDFAJIGJ()
	{
		IFCIHNCCADJ.KHIPFLOFKMC(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		IPCCICNFAFA(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OCPEHLIIGML());
		FEOJFCABOEM(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.BronzeCrown);
		KPAHCHEJADL(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		PBHMAFFHOGM(0, League.NoLeague, 0, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[2];
		HLFJNGOKOAB(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB]);
		DEIGAMPPJPD.avatar = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK;
		JJHAGBKENJA(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OCPEHLIIGML());
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		CALFDOJBEKP(0, League.NoLeague, 1, true);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[3];
		ILNCNLHDEPH(CamosManager.instance.playerVisualCategories[1][iNFLHPGMEOB2]);
	}

	protected virtual void PGHAMCBHBOD()
	{
		Singleton<GameCamera>.instance.BFMNLCJDPNG(FNHPOKNBJPB);
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += GJNPPGEFBCN;
		BDADGLHAOBA.onReposition = BOICHOKDFPE;
		GHICBPOOMEI.onReposition = HMNKKPEDPDI;
	}

	private void ENNADDNFCFE(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && !IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.decalValueString;
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.LIIOLLAAHGB();
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.decalMiniIconColor;
			LNMMJFGLCNP.alpha = 1549f;
		}
	}

	private void HKIAAOFGHPH()
	{
		IFCIHNCCADJ.JIBFCGECCFI(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		GAOEHOFNBKL(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BPNPPKPCFGN());
		CLIAOCAGHGN(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.BronzeCrown);
		NGKMIIGKIKK(null);
		GDCBEMJCMMF(1, League.NoLeague, 0, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[1];
		HKIJOJOAEEP(CamosManager.instance.playerVisualCategories[5][iNFLHPGMEOB]);
		DEIGAMPPJPD.DJPNDAICDPN(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		DJBBKADFDGM(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BPNPPKPCFGN());
		ENCGLEIDDFO(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		JGIMALFEHCP(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		AFDNODFKKNG(1, League.Bronze3, 0, true);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[8];
		ENNADDNFCFE(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB2]);
	}

	private void GCEFMLIMIOB()
	{
		IFCIHNCCADJ.GJHFCKMAMIE(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		HBPGEDLEBKC(0);
		GBFIOODGMOH(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		NGKMIIGKIKK(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		GDCBEMJCMMF(0, League.NoLeague, 1, false);
		BHGDABMNHBL(null);
		DEIGAMPPJPD.ECKBKNCJLOC(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(1);
		MIMOKCBDMII(true, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		JGIMALFEHCP(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		CALFDOJBEKP(0, League.NoLeague, 0, true);
		JDJNDFHMHIB(null);
	}

	private void CHANANMEANF()
	{
		IFCIHNCCADJ.FBGDPCPIKMI(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		IPCCICNFAFA(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO());
		CLIAOCAGHGN(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.BronzeCrown);
		NGKMIIGKIKK(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		GDCBEMJCMMF(1, League.Bronze3, 0, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[5];
		HKIJOJOAEEP(CamosManager.instance.playerVisualCategories[0][iNFLHPGMEOB]);
		DEIGAMPPJPD.OLJPGNNKCKI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		JJHAGBKENJA(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BPNPPKPCFGN());
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		AFDNODFKKNG(1, League.Bronze3, 1, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[7];
		ILNCNLHDEPH(CamosManager.instance.playerVisualCategories[2][iNFLHPGMEOB2]);
	}

	private void BDAPDKOODNI()
	{
		IFCIHNCCADJ.BIEIDBBDNIF(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		HBPGEDLEBKC(1);
		FEOJFCABOEM(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		DJOEMHFGEIP(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		GDCBEMJCMMF(1, League.NoLeague, 1, false);
		HLFJNGOKOAB(null);
		DEIGAMPPJPD.DJPNDAICDPN(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(1);
		ENCGLEIDDFO(true, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		FGGJPHOJPGA(0, League.Bronze3, 0, true);
		LHOIONMEGBE(null);
	}

	private void HLKPGGIKPMA()
	{
		IFCIHNCCADJ.avatar = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK;
		GFGHNBKIPOB(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO());
		CLIAOCAGHGN(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		DJOEMHFGEIP(null);
		FNPODLBCFNF(0, League.Bronze3, 1, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[4];
		BHGDABMNHBL(CamosManager.instance.playerVisualCategories[3][iNFLHPGMEOB]);
		DEIGAMPPJPD.KGJCNNANACM(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL);
		OHJLMDMCBCK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		JGIMALFEHCP(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		AFDNODFKKNG(0, League.Bronze3, 1, true);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[5];
		PEDOCOMPJBG(CamosManager.instance.playerVisualCategories[8][iNFLHPGMEOB2]);
	}

	private void GKKAPGGLOCL()
	{
		IFCIHNCCADJ.BIEIDBBDNIF(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		IAGMNPHBPNE(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BPNPPKPCFGN());
		GBFIOODGMOH(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.BronzeCrown);
		DJOEMHFGEIP(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		GDCBEMJCMMF(1, League.Bronze3, 1, false);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[5];
		HLFJNGOKOAB(CamosManager.instance.playerVisualCategories[0][iNFLHPGMEOB]);
		DEIGAMPPJPD.avatar = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK;
		AEAMIHEMOHD(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL);
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		CALFDOJBEKP(0, League.NoLeague, 0, true);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[3];
		PEDOCOMPJBG(CamosManager.instance.playerVisualCategories[0][iNFLHPGMEOB2]);
	}

	protected virtual void AGPINBAMJHF()
	{
		Singleton<GameCamera>.instance.BFMNLCJDPNG(KDLHCNCMOCJ);
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += BPFILAMIKKJ;
		BDADGLHAOBA.onReposition = FANIMIGCGLI;
		GHICBPOOMEI.onReposition = DJPECOPPJEI;
	}

	private void JMNLBEKFFFG(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK == null || !IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.FKIHLEGENCE();
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.decalMiniIcon;
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.GPDIGNGOAEH();
			LNMMJFGLCNP.alpha = 997f;
		}
	}

	private void EOHKBJJOMCL()
	{
		IFCIHNCCADJ.FBGDPCPIKMI(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		HBPGEDLEBKC(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO());
		FEOJFCABOEM(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		NLODHENBGEJ(null);
		GDCBEMJCMMF(1, League.NoLeague, 0, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[5];
		HLFJNGOKOAB(CamosManager.instance.playerVisualCategories[1][iNFLHPGMEOB]);
		DEIGAMPPJPD.JIBFCGECCFI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BPNPPKPCFGN());
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BIPHPDCMLDB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		CPIMHMKNGPG(1, League.NoLeague, 1, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[1];
		BJPIDPBPNPG(CamosManager.instance.playerVisualCategories[1][iNFLHPGMEOB2]);
	}

	private void DPNAFEKIJCE(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.FKIHLEGENCE();
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.decalMiniIcon;
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.decalMiniIconColor;
			LNMMJFGLCNP.alpha = 1587f;
		}
	}

	private void GAOEHOFNBKL(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 1;
		GMKFMNAHAJH.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			AHHABDEJPJL.text = levelDefinition.KAKFPJPKHHB();
			GMKFMNAHAJH.spriteName = levelDefinition.LMNDFNIKIFI();
		}
		else
		{
			AHHABDEJPJL.text = string.Empty;
		}
	}

	private void DAEDBIBHCCB()
	{
		Transform parent = DEIGAMPPJPD.PKHHKJLGHFM.transform.parent;
		if (LPOJICGIOPL.gameObject.activeSelf)
		{
			parent = LPOJICGIOPL.transform.parent;
		}
		float num = (parent.localPosition.x - GHICBPOOMEI.padding.x) / 850f;
		float num2 = 0f - GHICBPOOMEI.padding.x - num;
		float num3 = UIHelper.activeWidthSafe / 1939f - 242f - 41f;
		if (num3 < Mathf.Abs(num))
		{
			num2 = num2 - num + num3;
		}
		GHICBPOOMEI.transform.localPosition = GHICBPOOMEI.transform.localPosition.ReplaceX(num2);
	}

	private void MNPPKEPEDJN()
	{
		IFCIHNCCADJ.OLJPGNNKCKI(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		GAOEHOFNBKL(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OEJKKJJFDFL());
		FEOJFCABOEM(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		NGKMIIGKIKK(null);
		EAAMHKFCEBK(1, League.NoLeague, 0, false);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[1];
		HKIJOJOAEEP(CamosManager.instance.playerVisualCategories[0][iNFLHPGMEOB]);
		DEIGAMPPJPD.ECKBKNCJLOC(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		IENGAFLIJED(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BPNPPKPCFGN());
		OHJLMDMCBCK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		JGIMALFEHCP(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		AFDNODFKKNG(1, League.Bronze3, 1, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[4];
		JDJNDFHMHIB(CamosManager.instance.playerVisualCategories[6][iNFLHPGMEOB2]);
	}

	public virtual void NIHENNDPJFB()
	{
	}

	private void PEDOCOMPJBG(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && !IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.decalValueString;
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.decalMiniIcon;
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.decalMiniIconColor;
			LNMMJFGLCNP.alpha = 0f;
		}
	}

	private void PHBMAGNODMP(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 0;
		GMKFMNAHAJH.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			AHHABDEJPJL.text = levelDefinition.displayString;
			GMKFMNAHAJH.spriteName = levelDefinition.iconName;
		}
		else
		{
			AHHABDEJPJL.text = string.Empty;
		}
	}

	private void DJPECOPPJEI()
	{
		Transform parent = DEIGAMPPJPD.PKHHKJLGHFM.transform.parent;
		if (LPOJICGIOPL.gameObject.activeSelf)
		{
			parent = LPOJICGIOPL.transform.parent;
		}
		float num = (parent.localPosition.x - GHICBPOOMEI.padding.x) / 1966f;
		float num2 = 0f - GHICBPOOMEI.padding.x - num;
		float num3 = UIHelper.activeWidthSafe / 1774f - 842f - 1182f;
		if (num3 < Mathf.Abs(num))
		{
			num2 = num2 - num + num3;
		}
		GHICBPOOMEI.transform.localPosition = GHICBPOOMEI.transform.localPosition.ReplaceX(num2);
	}

	private void HEIJPDIOMID(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		NEFBBJLKNKA.gameObject.SetActive(flag);
		if (flag)
		{
			NEFBBJLKNKA.spriteName = GameVariables.IDOFIHFGOKD(CAAKEPHMPHI);
		}
	}

	private void KDLHCNCMOCJ()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 869f, 1455f);
		TweenScale.Begin(DNDCODMGGEE, 373f, new Vector3(1520f, 1381f, 845f), Vector3.one);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)122, 1278f);
		InvokeAfterRealTime(BBPDAJLJOOK, 317f);
	}

	private void EAAMHKFCEBK(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 0)
		{
			PEKHKDCCMGN.gameObject.SetActive(true);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(1);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 1832f;
		}
		else if (HNEFOLPHMHK > 1)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = 1261f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
			PEKHKDCCMGN.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			PEKHKDCCMGN.MakePixelPerfect();
			PEKHKDCCMGN.alpha = ((!GKEOILLNCHG) ? 1494f : 1097f);
		}
		else
		{
			PEKHKDCCMGN.gameObject.SetActive(false);
		}
	}

	[CompilerGenerated]
	private void LGPKODMDCOH()
	{
		TweenAlpha.Begin(IIHJFLPFIEF, 0.2f, 1f);
		TweenScale.Begin(IIHJFLPFIEF, 0.2f, new Vector3(3.5f, 3.5f, 1f), Vector3.one);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGameVsSound);
	}

	private void IBKABGMLNNJ()
	{
		IFCIHNCCADJ.JJGFMKCHIPE(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		DLBJODBNPHA(1);
		CLIAOCAGHGN(true, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		NLODHENBGEJ(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		MLGPJNPHJAH(0, League.Bronze3, 1, false);
		HKIJOJOAEEP(null);
		DEIGAMPPJPD.KHIPFLOFKMC(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		AEAMIHEMOHD(0);
		CDJIIBLJHHM(true, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BIPHPDCMLDB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		FGGJPHOJPGA(0, League.Bronze3, 1, true);
		HGOPFKCDGEB(null);
	}

	private void INNNCOLBMCH(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		PEJCGKACMCO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG == WarArenaCrown.None;
		LPOJICGIOPL.gameObject.SetActive(flag);
		if (flag)
		{
			LPOJICGIOPL.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			LPOJICGIOPL.MakePixelPerfect();
			float multiplier = Mathf.Min(57f / LPOJICGIOPL.transform.localScale.x, 1670f / LPOJICGIOPL.transform.localScale.y);
			LPOJICGIOPL.transform.localScale = LPOJICGIOPL.transform.localScale.MultiplyXY(multiplier);
		}
		DEIGAMPPJPD.AJLMACKOEPF(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(DEIGAMPPJPD.PKHHKJLGHFM, 930f, 477f, 71);
		GHICBPOOMEI.repositionNow = false;
	}

	private void ENCGLEIDDFO(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		PEJCGKACMCO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG != WarArenaCrown.BronzeCrown;
		LPOJICGIOPL.gameObject.SetActive(flag);
		if (flag)
		{
			LPOJICGIOPL.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			LPOJICGIOPL.MakePixelPerfect();
			float multiplier = Mathf.Min(50f / LPOJICGIOPL.transform.localScale.x, 1698f / LPOJICGIOPL.transform.localScale.y);
			LPOJICGIOPL.transform.localScale = LPOJICGIOPL.transform.localScale.MultiplyXY(multiplier);
		}
		DEIGAMPPJPD.EAFNPDOOGBE(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(DEIGAMPPJPD.PKHHKJLGHFM, 1636f, 1026f, 103);
		GHICBPOOMEI.repositionNow = false;
	}

	private void CDJIIBLJHHM(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		PEJCGKACMCO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG != WarArenaCrown.None;
		LPOJICGIOPL.gameObject.SetActive(flag);
		if (flag)
		{
			LPOJICGIOPL.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			LPOJICGIOPL.MakePixelPerfect();
			float multiplier = Mathf.Min(439f / LPOJICGIOPL.transform.localScale.x, 580f / LPOJICGIOPL.transform.localScale.y);
			LPOJICGIOPL.transform.localScale = LPOJICGIOPL.transform.localScale.MultiplyXY(multiplier);
		}
		DEIGAMPPJPD.MLOCBNGHCLL(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(DEIGAMPPJPD.PKHHKJLGHFM, 901f, 1081f, 179);
		GHICBPOOMEI.repositionNow = true;
	}

	private void HLFJNGOKOAB(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK == null || !IIOKFKPMPPK.isEmptyPowerBand;
		KAOOPIHJPNG.SetActive(flag);
		if (flag)
		{
			NIBAOAONCLA.spriteName = IIOKFKPMPPK.icon;
			NIBAOAONCLA.MakePixelPerfect();
			MHKIFHKBMOD.text = IIOKFKPMPPK.JIHLMBOBKHL();
			JCFMFAOJHGK.spriteName = IIOKFKPMPPK.DEAIJJIAEFP();
			JCFMFAOJHGK.MakePixelPerfect();
			JCFMFAOJHGK.color = IIOKFKPMPPK.GPDIGNGOAEH();
			JCFMFAOJHGK.alpha = 621f;
		}
	}

	protected override void AGIKPOLCGNF()
	{
		Singleton<GameCamera>.instance.AnimationFinished += NFPLEPGHGIN;
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += GJNPPGEFBCN;
		BDADGLHAOBA.onReposition = BOICHOKDFPE;
		GHICBPOOMEI.onReposition = MBGBPFDDDAG;
	}

	private void CBLPDJDNDCM()
	{
		TweenAlpha.Begin(HIOHPOMALHE, 1798f, 1320f);
		TweenScale.Begin(HIOHPOMALHE, 847f, new Vector3(1887f, 1226f, 1179f), Vector3.one);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LevelUpUnlockedItem, 1540f);
		InvokeAfterRealTime(KMKMHPHNMFO, 831f);
	}

	private void DEOOKENCAFH()
	{
		IFCIHNCCADJ.avatar = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK;
		GAOEHOFNBKL(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BPNPPKPCFGN());
		GBFIOODGMOH(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.None);
		KMJPOBKPOPI(null);
		MLGPJNPHJAH(0, League.Bronze3, 1, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[2];
		HKIJOJOAEEP(CamosManager.instance.playerVisualCategories[2][iNFLHPGMEOB]);
		DEIGAMPPJPD.JIBFCGECCFI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		CKDAIGFHKCJ(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO());
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		FJKCONFDFLK(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		HDNOGLKPCAL(0, League.Bronze3, 0, false);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[0];
		LHOIONMEGBE(CamosManager.instance.playerVisualCategories[5][iNFLHPGMEOB2]);
	}

	private void NHOMGBINGHG()
	{
		IFCIHNCCADJ.DJPNDAICDPN(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		IPCCICNFAFA(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.OEJKKJJFDFL());
		LABKOGAGEKE(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HMGOHGOLMJB, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		NIFAJADOBPF(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		EAAMHKFCEBK(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.IOFBJPJPEMK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BMNDININJCE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HNEFOLPHMHK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.GKEOILLNCHG);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[1];
		HKIJOJOAEEP(CamosManager.instance.playerVisualCategories[5][iNFLHPGMEOB]);
		DEIGAMPPJPD.GJHFCKMAMIE(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		CKDAIGFHKCJ(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OEJKKJJFDFL());
		MIMOKCBDMII(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		HDNOGLKPCAL(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.IOFBJPJPEMK, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BMNDININJCE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HNEFOLPHMHK, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.GKEOILLNCHG);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[1];
		HGOPFKCDGEB(CamosManager.instance.playerVisualCategories[5][iNFLHPGMEOB2]);
	}

	public virtual void OCACKBJDEHI()
	{
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			GMGLBALMHAP();
		}
		else if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			ANIDBHGOHNN();
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			IBKABGMLNNJ();
		}
		else
		{
			GFEKMJAGCNI();
		}
	}

	private void KPNCDJOFDFH()
	{
		IFCIHNCCADJ.FBGDPCPIKMI(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		PHBMAGNODMP(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BPNPPKPCFGN());
		CLIAOCAGHGN(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HMGOHGOLMJB, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.FHCMFHABMLE);
		HEIJPDIOMID(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CAAKEPHMPHI);
		FLBFNPNNJGN(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.IOFBJPJPEMK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BMNDININJCE, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HNEFOLPHMHK, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.GKEOILLNCHG);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[5];
		HKIJOJOAEEP(CamosManager.instance.playerVisualCategories[8][iNFLHPGMEOB]);
		DEIGAMPPJPD.KGJCNNANACM(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK);
		CKDAIGFHKCJ(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BPNPPKPCFGN());
		FIKFLIKDCFB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BFEDNGGPACI(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		OBBDANOPLHJ(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.IOFBJPJPEMK, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BMNDININJCE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HNEFOLPHMHK, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.GKEOILLNCHG);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[7];
		HCAAGIAADDP(CamosManager.instance.playerVisualCategories[6][iNFLHPGMEOB2]);
	}

	public virtual void NCCGNDMMIAH()
	{
		base.DoBeforeShowUp();
		Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
	}

	private void CPIMHMKNGPG(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 194f;
		}
		else if (HNEFOLPHMHK > 1)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 1418f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			DMACIGNEEJP.gameObject.SetActive(true);
			DMACIGNEEJP.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = ((!GKEOILLNCHG) ? 460f : 202f);
		}
		else
		{
			DMACIGNEEJP.gameObject.SetActive(true);
		}
	}

	private void KPCBNFHBPNB()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 497f, 1685f);
		TweenAlpha.Begin(IIHJFLPFIEF, 1073f, 1512f);
		TweenAlpha.Begin(HIOHPOMALHE, 178f, 1857f);
	}

	public virtual void JCJECJKBKGD()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			AOKLDFAJIGJ();
		}
		else if (Singleton<GameController>.instance.isMission)
		{
			ANIDBHGOHNN();
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			ELCMENMFABN();
		}
		else
		{
			HGIMJOJPHGL();
		}
	}

	private void DJBBKADFDGM(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 1;
		MGGGCGAOPHJ.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			GBHDAKINMIL.text = levelDefinition.JNODDKLJOAG();
			MGGGCGAOPHJ.spriteName = levelDefinition.EGNEDNBPOEF();
		}
		else
		{
			GBHDAKINMIL.text = string.Empty;
		}
	}

	private void MBGBPFDDDAG()
	{
		Transform parent = DEIGAMPPJPD.PKHHKJLGHFM.transform.parent;
		if (LPOJICGIOPL.gameObject.activeSelf)
		{
			parent = LPOJICGIOPL.transform.parent;
		}
		float num = (parent.localPosition.x - GHICBPOOMEI.padding.x) / 2f;
		float num2 = 0f - GHICBPOOMEI.padding.x - num;
		float num3 = UIHelper.activeWidthSafe / 2f - 600f - 20f;
		if (num3 < Mathf.Abs(num))
		{
			num2 = num2 - num + num3;
		}
		GHICBPOOMEI.transform.localPosition = GHICBPOOMEI.transform.localPosition.ReplaceX(num2);
	}

	private void FEOJFCABOEM(bool HMGOHGOLMJB, string BCMCMKDCLGP, WarArenaCrown EBFDOPFOHAG)
	{
		LMFDBNECCGO.gameObject.SetActive(HMGOHGOLMJB);
		bool flag = EBFDOPFOHAG != WarArenaCrown.None;
		IFBNKNIGOKJ.gameObject.SetActive(flag);
		if (flag)
		{
			IFBNKNIGOKJ.spriteName = GameVariables.CMIKIDJKHID[EBFDOPFOHAG];
			IFBNKNIGOKJ.MakePixelPerfect();
			float multiplier = Mathf.Min(60f / IFBNKNIGOKJ.transform.localScale.x, 60f / IFBNKNIGOKJ.transform.localScale.y);
			IFBNKNIGOKJ.transform.localScale = IFBNKNIGOKJ.transform.localScale.MultiplyXY(multiplier);
		}
		IFCIHNCCADJ.SetName(BCMCMKDCLGP);
		MEJMLNDFDBP.COCBCFKJOJE(IFCIHNCCADJ.PKHHKJLGHFM, 66f, 50f, 720);
		BDADGLHAOBA.repositionNow = true;
	}

	private void IENGAFLIJED(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 1;
		MGGGCGAOPHJ.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			GBHDAKINMIL.text = levelDefinition.FDACEOHEGPN();
			MGGGCGAOPHJ.spriteName = levelDefinition.CDLBEKECJNK();
		}
		else
		{
			GBHDAKINMIL.text = string.Empty;
		}
	}

	protected virtual void JCEMKGHAHNE()
	{
		Singleton<GameCamera>.instance.NHAGLMBNNJM(GHOBJCFONAD);
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += CBLPDJDNDCM;
		BDADGLHAOBA.onReposition = HCFOBOOJNLF;
		GHICBPOOMEI.onReposition = MBGBPFDDDAG;
	}

	private void IAGMNPHBPNE(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 0;
		GMKFMNAHAJH.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 0;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			AHHABDEJPJL.text = levelDefinition.DLCFFHEKBAA();
			GMKFMNAHAJH.spriteName = levelDefinition.iconName;
		}
		else
		{
			AHHABDEJPJL.text = string.Empty;
		}
	}

	private void BOICHOKDFPE()
	{
		Transform parent = IFCIHNCCADJ.PKHHKJLGHFM.transform.parent;
		if (IFBNKNIGOKJ.gameObject.activeSelf)
		{
			parent = IFBNKNIGOKJ.transform.parent;
		}
		float num = 0f - BDADGLHAOBA.padding.x - (parent.localPosition.x - BDADGLHAOBA.padding.x) / 2f;
		float num2 = UIHelper.activeWidthSafe / 2f - 600f - 20f;
		if (num2 < Mathf.Abs(num))
		{
			num = 0f - num2;
		}
		BDADGLHAOBA.transform.localPosition = BDADGLHAOBA.transform.localPosition.ReplaceX(num);
	}

	private void FMHLFBAELLP(PlayerVisual IIOKFKPMPPK)
	{
		bool flag = IIOKFKPMPPK != null && !IIOKFKPMPPK.isEmptyPowerBand;
		ANNIDFMIMAN.SetActive(flag);
		if (flag)
		{
			PKMIIPLIGPO.spriteName = IIOKFKPMPPK.icon;
			PKMIIPLIGPO.MakePixelPerfect();
			MBBNHBMPHKC.text = IIOKFKPMPPK.decalValueString;
			LNMMJFGLCNP.spriteName = IIOKFKPMPPK.LIIOLLAAHGB();
			LNMMJFGLCNP.MakePixelPerfect();
			LNMMJFGLCNP.color = IIOKFKPMPPK.GPDIGNGOAEH();
			LNMMJFGLCNP.alpha = 1017f;
		}
	}

	private void ALGGJINEJEK()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 292f, 1439f);
		TweenAlpha.Begin(IIHJFLPFIEF, 1807f, 921f);
		TweenAlpha.Begin(HIOHPOMALHE, 802f, 373f);
	}

	private void BIPHPDCMLDB(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		AEKGHHGPFIN.gameObject.SetActive(flag);
		if (flag)
		{
			AEKGHHGPFIN.spriteName = GameVariables.IDOFIHFGOKD(CAAKEPHMPHI);
		}
	}

	private void HCFOBOOJNLF()
	{
		Transform parent = IFCIHNCCADJ.PKHHKJLGHFM.transform.parent;
		if (IFBNKNIGOKJ.gameObject.activeSelf)
		{
			parent = IFBNKNIGOKJ.transform.parent;
		}
		float num = 0f - BDADGLHAOBA.padding.x - (parent.localPosition.x - BDADGLHAOBA.padding.x) / 523f;
		float num2 = UIHelper.activeWidthSafe / 896f - 886f - 143f;
		if (num2 < Mathf.Abs(num))
		{
			num = 0f - num2;
		}
		BDADGLHAOBA.transform.localPosition = BDADGLHAOBA.transform.localPosition.ReplaceX(num);
	}

	private void CKDAIGFHKCJ(int BCCDDJMPBLL)
	{
		bool flag = BCCDDJMPBLL > 1;
		MGGGCGAOPHJ.gameObject.SetActive(flag);
		if (flag)
		{
			int level = BCCDDJMPBLL - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
			GBHDAKINMIL.text = levelDefinition.FDACEOHEGPN();
			MGGGCGAOPHJ.spriteName = levelDefinition.KJFPCOMOLLD();
		}
		else
		{
			GBHDAKINMIL.text = string.Empty;
		}
	}

	protected virtual void DLNJFMIDPFE()
	{
		Singleton<GameCamera>.instance.AnimationFinished += KDLHCNCMOCJ;
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += CBLPDJDNDCM;
		BDADGLHAOBA.onReposition = HCFOBOOJNLF;
		GHICBPOOMEI.onReposition = DAEDBIBHCCB;
	}

	private void OPINIJHHJCK()
	{
		IFCIHNCCADJ.OLJPGNNKCKI(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.EBFDAICCJAK);
		IAGMNPHBPNE(Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ALJJMKANFNO());
		FEOJFCABOEM(false, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE, WarArenaCrown.BronzeCrown);
		HEIJPDIOMID(null);
		FNPODLBCFNF(0, League.Bronze3, 0, true);
		string iNFLHPGMEOB = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CBBDICBLHMM[3];
		JIHEPDNKKIO(CamosManager.instance.playerVisualCategories[8][iNFLHPGMEOB]);
		DEIGAMPPJPD.avatar = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.EBFDAICCJAK;
		IENGAFLIJED(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OCPEHLIIGML());
		INNNCOLBMCH(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HMGOHGOLMJB, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.MHPNDNJDPGE, PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.FHCMFHABMLE);
		BIPHPDCMLDB(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CAAKEPHMPHI);
		OBBDANOPLHJ(1, League.Bronze3, 0, true);
		string iNFLHPGMEOB2 = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM[6];
		ENNADDNFCFE(CamosManager.instance.playerVisualCategories[1][iNFLHPGMEOB2]);
	}

	private void GJNPPGEFBCN()
	{
		TweenAlpha.Begin(HIOHPOMALHE, 0.2f, 1f);
		TweenScale.Begin(HIOHPOMALHE, 0.2f, new Vector3(3.5f, 3.5f, 1f), Vector3.one);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGamePhotoSound);
		InvokeAfterRealTime(delegate
		{
			TweenAlpha.Begin(IIHJFLPFIEF, 0.2f, 1f);
			TweenScale.Begin(IIHJFLPFIEF, 0.2f, new Vector3(3.5f, 3.5f, 1f), Vector3.one);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGameVsSound);
		}, 1f);
	}

	private void FJKCONFDFLK(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		AEKGHHGPFIN.gameObject.SetActive(flag);
		if (flag)
		{
			AEKGHHGPFIN.spriteName = GameVariables.CountryCodeSpriteName(CAAKEPHMPHI);
		}
	}

	public virtual void BHMEOLBNLKF()
	{
	}

	private void PDEJLILBHOH()
	{
		Transform parent = DEIGAMPPJPD.PKHHKJLGHFM.transform.parent;
		if (LPOJICGIOPL.gameObject.activeSelf)
		{
			parent = LPOJICGIOPL.transform.parent;
		}
		float num = (parent.localPosition.x - GHICBPOOMEI.padding.x) / 624f;
		float num2 = 0f - GHICBPOOMEI.padding.x - num;
		float num3 = UIHelper.activeWidthSafe / 846f - 16f - 539f;
		if (num3 < Mathf.Abs(num))
		{
			num2 = num2 - num + num3;
		}
		GHICBPOOMEI.transform.localPosition = GHICBPOOMEI.transform.localPosition.ReplaceX(num2);
	}

	private void PFCEMFBMGCE()
	{
		Transform parent = DEIGAMPPJPD.PKHHKJLGHFM.transform.parent;
		if (LPOJICGIOPL.gameObject.activeSelf)
		{
			parent = LPOJICGIOPL.transform.parent;
		}
		float num = (parent.localPosition.x - GHICBPOOMEI.padding.x) / 1134f;
		float num2 = 0f - GHICBPOOMEI.padding.x - num;
		float num3 = UIHelper.activeWidthSafe / 1640f - 1636f - 1166f;
		if (num3 < Mathf.Abs(num))
		{
			num2 = num2 - num + num3;
		}
		GHICBPOOMEI.transform.localPosition = GHICBPOOMEI.transform.localPosition.ReplaceX(num2);
	}

	private void FJDNHMAEKAE()
	{
		TweenAlpha.Begin(HIOHPOMALHE, 696f, 153f);
		TweenScale.Begin(HIOHPOMALHE, 1644f, new Vector3(1534f, 1592f, 465f), Vector3.one);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-28), 649f);
		InvokeAfterRealTime(delegate
		{
			TweenAlpha.Begin(IIHJFLPFIEF, 0.2f, 1f);
			TweenScale.Begin(IIHJFLPFIEF, 0.2f, new Vector3(3.5f, 3.5f, 1f), Vector3.one);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGameVsSound);
		}, 799f);
	}

	private void IFJCDOLNHHE()
	{
		TweenAlpha.Begin(DNDCODMGGEE, 1620f, 1140f);
		TweenAlpha.Begin(IIHJFLPFIEF, 1027f, 1815f);
		TweenAlpha.Begin(HIOHPOMALHE, 1102f, 995f);
	}

	private void BFEDNGGPACI(string CAAKEPHMPHI)
	{
		bool flag = string.IsNullOrEmpty(CAAKEPHMPHI);
		AEKGHHGPFIN.gameObject.SetActive(flag);
		if (flag)
		{
			AEKGHHGPFIN.spriteName = GameVariables.CountryCodeSpriteName(CAAKEPHMPHI);
		}
	}

	private void NGKMIIGKIKK(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		NEFBBJLKNKA.gameObject.SetActive(flag);
		if (flag)
		{
			NEFBBJLKNKA.spriteName = GameVariables.IDOFIHFGOKD(CAAKEPHMPHI);
		}
	}

	private void NIFAJADOBPF(string CAAKEPHMPHI)
	{
		bool flag = !string.IsNullOrEmpty(CAAKEPHMPHI);
		NEFBBJLKNKA.gameObject.SetActive(flag);
		if (flag)
		{
			NEFBBJLKNKA.spriteName = GameVariables.CountryCodeSpriteName(CAAKEPHMPHI);
		}
	}

	private void FGGJPHOJPGA(int BPGIPOKANNI, League BMNDININJCE, int HNEFOLPHMHK, bool GKEOILLNCHG)
	{
		if (BPGIPOKANNI < 1)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(0);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 1286f;
		}
		else if (HNEFOLPHMHK > 1)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = 310f;
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			DMACIGNEEJP.gameObject.SetActive(false);
			DMACIGNEEJP.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			DMACIGNEEJP.MakePixelPerfect();
			DMACIGNEEJP.alpha = ((!GKEOILLNCHG) ? 1464f : 1854f);
		}
		else
		{
			DMACIGNEEJP.gameObject.SetActive(true);
		}
	}

	protected virtual void IMPMPKNJICB()
	{
		Singleton<GameCamera>.instance.NHAGLMBNNJM(KDLHCNCMOCJ);
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += OJONCBCPDND;
		BDADGLHAOBA.onReposition = BBNHKONOGCF;
		GHICBPOOMEI.onReposition = DAEDBIBHCCB;
	}
}
