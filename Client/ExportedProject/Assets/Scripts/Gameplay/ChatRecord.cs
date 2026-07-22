using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ChatRecord : PoolableObject
{
	[FormerlySerializedAs("KDNFDFNBJHI")]
	[Header("Time Info")]
	public GameObject OOJLGEIEFHM;

	[FormerlySerializedAs("FPLPFGIFEKA")]
	public WinStreakCounter MPKHGPHLMDB;

	[Header("Chat Message")]
	[FormerlySerializedAs("IBFCFHDNBIH")]
	public GameObject FDDNPECPBEE;

	[FormerlySerializedAs("ONIHPKHLGNH")]
	public UISprite MBMIOELEAND;

	[FormerlySerializedAs("IMNNPCMJHMP")]
	[Header("-Header Left")]
	public UISprite GFKNLLCKJOG;

	[FormerlySerializedAs("LJNGLIOELNE")]
	public UILabel BMNNHJGHFNJ;

	[FormerlySerializedAs("CMKGOKNCLOJ")]
	public UILabel PKHHKJLGHFM;

	[FormerlySerializedAs("EOAJFFLFNHH")]
	public UISprite DIDEFBEIFJD;

	[FormerlySerializedAs("DFFPMOHPNGH")]
	public UISprite KEEEAKBKLAF;

	[FormerlySerializedAs("JKMFPJNPLGN")]
	public GameObject CPLIMCNBDBP;

	[Header("-Header Right Message")]
	[FormerlySerializedAs("AKBAFOLLJAP")]
	public GameObject CIFLFDMACKG;

	[FormerlySerializedAs("JDGMJFPEHOO")]
	public UITexture MNNMIAAEBAF;

	[FormerlySerializedAs("OFOMNJAPIBJ")]
	public UILabel CGIFEHPDBAL;

	public UIButton KDABKEGLDEE;

	[FormerlySerializedAs("KNIHAEEIFLJ")]
	public UISprite NNMCKEECNFK;

	[FormerlySerializedAs("HHHILPLHEPP")]
	public UISprite KLGIFDAJCJD;

	[FormerlySerializedAs("DEEMBMPKEOK")]
	[Header("-Header Right SquadAction")]
	public GameObject FNDAHHEOEFF;

	[FormerlySerializedAs("HJIMPBNAGPP")]
	public UITable DLFDGNMAMGD;

	[FormerlySerializedAs("EHEHLEGPNGJ")]
	public UISprite PLEFAGHKKJA;

	[FormerlySerializedAs("JNNMPCKOGBK")]
	public UILabel BMIFLAPKPJD;

	[FormerlySerializedAs("HBGDHFMDNGK")]
	[Header("-Right SquadAction ByPlayer")]
	public UITable OFKKIBAPAJP;

	[FormerlySerializedAs("EFPHADIMGHE")]
	public UISprite NNLBJEEOODB;

	[FormerlySerializedAs("IOKKMMIMKOB")]
	public UILabel JEJBMEHECPD;

	[FormerlySerializedAs("CJBJCBGCLEC")]
	public UILabel OIGHLKPFPJN;

	[FormerlySerializedAs("CCEMHKALNHB")]
	public BoxCollider GNHNLLOIGJB;

	[FormerlySerializedAs("KFKJGEEPKGC")]
	[Header("-Content")]
	public GameObject NLMJJFKDHCM;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("HHHDFOOEHOC")]
	public UILabel HFGGJAMNONM;

	public UIButton MGFHDOBIGDL;

	private float IOODGADNFEN = 116f;

	private Chat.PBGFEDGFOPG FEIEGFFHJOG;

	private static Dictionary<Chat.EJLACNPLIDA, Tuple<string, Color, float, string>> LDOMEAMIHBK = new Dictionary<Chat.EJLACNPLIDA, Tuple<string, Color, float, string>>
	{
		{
			Chat.EJLACNPLIDA.Promotion,
			new Tuple<string, Color, float, string>("menu-button-promote-ico", Colours.cyan, 0f, "ID_GUI_CHAT_SQUAD_PROMOTED")
		},
		{
			Chat.EJLACNPLIDA.Demotion,
			new Tuple<string, Color, float, string>("menu-button-promote-ico", Color.red, 180f, "ID_GUI_CHAT_SQUAD_DEMOTED")
		},
		{
			Chat.EJLACNPLIDA.Kick,
			new Tuple<string, Color, float, string>("menu-close", Color.red, 0f, "ID_GUI_CHAT_SQUAD_KICK")
		},
		{
			Chat.EJLACNPLIDA.JoinedSquad,
			new Tuple<string, Color, float, string>("menu-addsoldier-ico", Color.white, 0f, "ID_GUI_CHAT_SQUAD_JOINED")
		},
		{
			Chat.EJLACNPLIDA.Left,
			new Tuple<string, Color, float, string>("menu-close", Color.red, 0f, "ID_GUI_CHAT_SQUAD_LEFT")
		}
	};

	public float Height => IOODGADNFEN;

	private void IMOMOJHBDCL(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: false);
		NLMJJFKDHCM.SetActive(value: false);
		FNDAHHEOEFF.SetActive(value: false);
		CGIFEHPDBAL.transform.localPosition = new Vector3(1833f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 757f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 721f, 1097f, -156);
		bool flag = string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 1408f : 1967f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_ARENAMODE" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(264f);
		}
		bool active = ILFPEILKAPF || BMNDININJCE != League.Bronze3;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		FLPDHCHEEFC(GNNLFNKNMEF: true);
	}

	public void OFEJGDMGGBJ()
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: true);
		IOODGADNFEN = 1047f;
	}

	private void AOGPLIDPLIH()
	{
		UITable dLFDGNMAMGD = DLFDGNMAMGD;
		dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(AOGPLIDPLIH));
		if (OFKKIBAPAJP.gameObject.activeSelf)
		{
			UITable oFKKIBAPAJP = OFKKIBAPAJP;
			oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(EPKNKIDFPPJ));
			UITable oFKKIBAPAJP2 = OFKKIBAPAJP;
			oFKKIBAPAJP2.onReposition = (UITable.OnReposition)Delegate.Combine(oFKKIBAPAJP2.onReposition, new UITable.OnReposition(KAENKGEJKIG));
			OFKKIBAPAJP.repositionNow = true;
		}
	}

	public void PPMPHKKHLNB(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		FEIEGFFHJOG = NDPMDKGJAFH;
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HHNNIBKKBMN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HMIAGBLEHIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CBKMPHKGECH));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FLIKKJFNKAB));
		UIEventListener uIEventListener5 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EAFOOPIHFIH));
		UIEventListener uIEventListener6 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(HGEGKGHNDFA));
		UIEventListener uIEventListener7 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener7.onClick, new UIEventListener.VoidDelegate(DIJKOOHDIHI));
		UIEventListener uIEventListener8 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(MBCNGICFDED));
		KDABKEGLDEE.gameObject.SetActive(!string.IsNullOrEmpty(NDPMDKGJAFH.CGIFEHPDBAL) && !NDPMDKGJAFH.KBGHBHFOHFD);
		bool flag = NDPMDKGJAFH.EJBEDLHIKDG == GameLoginManager.currentPlayer.id;
		MGFHDOBIGDL.gameObject.SetActive(!flag && NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer)
		{
			AMAMBJNNNCI(NDPMDKGJAFH.KBJEOEEOEFG);
			return;
		}
		GEKNDKFFGHC(NDPMDKGJAFH.MHPNDNJDPGE, NDPMDKGJAFH.BCCDDJMPBLL, NDPMDKGJAFH.FHCMFHABMLE, NDPMDKGJAFH.EGHOKPEJMGD);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			if (NDPMDKGJAFH.KBGHBHFOHFD)
			{
				GHOGGLIMLOC(NDPMDKGJAFH.MNGGEHIAAEC, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
			else
			{
				GKAPAJJEAFM(NDPMDKGJAFH.CGIFEHPDBAL, NDPMDKGJAFH.GEAGOKJMJFD, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
		}
		else
		{
			IJDKENMPLIM(NDPMDKGJAFH.NBKCKIELMLK, NDPMDKGJAFH.EHLJCGEFAOL, NDPMDKGJAFH.LIAFEPFJAKM);
			NDPMDKGJAFH.OJIANBAINDD.KINBBAFNJPG(IDEBKDPMPGM: true);
		}
	}

	private void HBNDMLACBCJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG, BNNKPKDPLPP: false);
		}
	}

	private void NKCGGCINPPL()
	{
		UITable oFKKIBAPAJP = OFKKIBAPAJP;
		oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(ANCFLFAGKNH));
		float num = 92f + OFKKIBAPAJP.transform.localPosition.x + OIGHLKPFPJN.transform.parent.transform.localPosition.x;
		int cEHFMMJHCKC = 123 - (int)num;
		MEJMLNDFDBP.COCBCFKJOJE(OIGHLKPFPJN, 360f, 966f, cEHFMMJHCKC);
		float x = OIGHLKPFPJN.relativeSize.x;
		GNHNLLOIGJB.center = new Vector3(x / 1775f, 1813f, 1788f);
		GNHNLLOIGJB.size = new Vector3(x + 1285f, 1073f, 553f);
	}

	private void DBANMAMHIPO(GameObject KHAHPAKDIKE)
	{
		ChatAbuseDialog.FKNOGHKJGNK(FEIEGFFHJOG.EJBEDLHIKDG, FEIEGFFHJOG.PNAKMCNGGHE);
	}

	private void AMAMBJNNNCI(int NOLELDEJDDC)
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: true);
		IOODGADNFEN = 622f;
		MPKHGPHLMDB.ONLMEDMBBBE(NOLELDEJDDC);
	}

	private void LPFCAGKAFLI(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: false);
		NLMJJFKDHCM.SetActive(value: false);
		FNDAHHEOEFF.SetActive(value: true);
		CGIFEHPDBAL.transform.localPosition = new Vector3(1650f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 1474f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 850f, 789f, 21);
		bool flag = string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 1462f : 1272f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Beanstalk: On Change Name" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(957f);
		}
		bool active = !ILFPEILKAPF && BMNDININJCE != League.NoLeague;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		FLPDHCHEEFC(GNNLFNKNMEF: true, KMIGLGHPFCC: false);
	}

	private void PCBLKDOPBJG(Chat.EJLACNPLIDA FJLBLLLEELD, int EHLJCGEFAOL, DatabasePlayer LIAFEPFJAKM)
	{
		CIFLFDMACKG.SetActive(value: false);
		NLMJJFKDHCM.SetActive(value: false);
		FNDAHHEOEFF.SetActive(value: false);
		OFKKIBAPAJP.gameObject.SetActive(LIAFEPFJAKM != null);
		PLEFAGHKKJA.gameObject.SetActive(!string.IsNullOrEmpty(LDOMEAMIHBK[FJLBLLLEELD].Value1));
		if (PLEFAGHKKJA.gameObject.activeSelf)
		{
			PLEFAGHKKJA.spriteName = LDOMEAMIHBK[FJLBLLLEELD].Value1;
			PLEFAGHKKJA.MakePixelPerfect();
			PLEFAGHKKJA.color = LDOMEAMIHBK[FJLBLLLEELD].Value2;
			PLEFAGHKKJA.transform.localRotation = Quaternion.Euler(477f, 819f, LDOMEAMIHBK[FJLBLLLEELD].Value3);
			float multiplier = 1010f / PLEFAGHKKJA.transform.localScale.y;
			PLEFAGHKKJA.transform.localScale = PLEFAGHKKJA.transform.localScale.MultiplyXY(multiplier);
		}
		switch (FJLBLLLEELD)
		{
		case Chat.EJLACNPLIDA.Demotion:
		{
			string text2 = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD2 = BMIFLAPKPJD;
			string value2 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array2 = new object[2];
			array2[0] = Colours.stringRed;
			array2[0] = text2;
			bMIFLAPKPJD2.text = Localization.LocalizeFormat(value2, array2);
			break;
		}
		case Chat.EJLACNPLIDA.Kick:
		{
			UILabel bMIFLAPKPJD = BMIFLAPKPJD;
			string value = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array = new object[0];
			array[0] = Colours.stringRed;
			bMIFLAPKPJD.text = Localization.LocalizeFormat(value, array);
			break;
		}
		case Chat.EJLACNPLIDA.Promotion:
		{
			string text = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			BMIFLAPKPJD.text = Localization.LocalizeFormat(LDOMEAMIHBK[FJLBLLLEELD].Value4, Colours.stringCyan, text, null);
			break;
		}
		case Chat.EJLACNPLIDA.JoinedSquad:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		case Chat.EJLACNPLIDA.Left:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		default:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		}
		NBAKFPJHNPB();
		float num = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
		float num2 = PKHHKJLGHFM.transform.localPosition.x + num + 654f;
		if (DIDEFBEIFJD.gameObject.activeSelf)
		{
			num2 += 1638f + DIDEFBEIFJD.transform.localScale.x;
		}
		DLFDGNMAMGD.transform.localPosition = DLFDGNMAMGD.transform.localPosition.ReplaceX(num2);
		if (LIAFEPFJAKM != null)
		{
			OIGHLKPFPJN.text = LIAFEPFJAKM.name;
			TweenColor.Begin(OIGHLKPFPJN.gameObject, 1916f, Colours.blue);
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(LIAFEPFJAKM.level);
			NNLBJEEOODB.spriteName = levelDefinition.CDLBEKECJNK();
			NNLBJEEOODB.MakePixelPerfect();
			JEJBMEHECPD.text = levelDefinition.KAKFPJPKHHB();
			OFKKIBAPAJP.transform.localPosition = OFKKIBAPAJP.transform.localPosition.ReplaceX(num2);
			UITable dLFDGNMAMGD = DLFDGNMAMGD;
			dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(GMPCCNDMIID));
			UITable dLFDGNMAMGD2 = DLFDGNMAMGD;
			dLFDGNMAMGD2.onReposition = (UITable.OnReposition)Delegate.Combine(dLFDGNMAMGD2.onReposition, new UITable.OnReposition(HECEDDEEPCI));
		}
		DLFDGNMAMGD.repositionNow = false;
		MHKKGFOEDOE(GNNLFNKNMEF: true);
	}

	private void NEEPBGKJACK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG, BNNKPKDPLPP: false);
		}
	}

	private void HHNNIBKKBMN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG, BNNKPKDPLPP: false);
		}
	}

	public void InitializeForHeightOnly(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer)
		{
			IOODGADNFEN = 60f;
			return;
		}
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: false);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			HFGGJAMNONM.text = NDPMDKGJAFH.PNAKMCNGGHE;
		}
		else
		{
			OFKKIBAPAJP.gameObject.SetActive(NDPMDKGJAFH.LIAFEPFJAKM != null);
		}
		MHKKGFOEDOE(NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message, KMIGLGHPFCC: false);
	}

	private void FLIKKJFNKAB(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 2;
		tweenColor.style = UITweener.Style.PingPong;
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(FEIEGFFHJOG.CGIFEHPDBAL);
	}

	private void MICFHBECAOM()
	{
		UITable dLFDGNMAMGD = DLFDGNMAMGD;
		dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(GMPCCNDMIID));
		if (OFKKIBAPAJP.gameObject.activeSelf)
		{
			UITable oFKKIBAPAJP = OFKKIBAPAJP;
			oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(ANCFLFAGKNH));
			UITable oFKKIBAPAJP2 = OFKKIBAPAJP;
			oFKKIBAPAJP2.onReposition = (UITable.OnReposition)Delegate.Combine(oFKKIBAPAJP2.onReposition, new UITable.OnReposition(KAENKGEJKIG));
			OFKKIBAPAJP.repositionNow = true;
		}
	}

	private void NEAOJNGOJBB()
	{
		int num = ((!DIDEFBEIFJD.gameObject.activeSelf) ? (-90) : 44);
		int num2 = 109;
		int num3 = num + num2;
		float x = PKHHKJLGHFM.relativeSize.x;
		float x2 = BMIFLAPKPJD.relativeSize.x;
		float gLIDDLHPAKL = Mathf.Clamp((float)num3 / (x + x2), 1547f, 1771f);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, gLIDDLHPAKL, 887f, num3);
		MEJMLNDFDBP.COCBCFKJOJE(BMIFLAPKPJD, gLIDDLHPAKL, 1596f, num3);
	}

	private void HLFMHNIFEFP()
	{
		UITable dLFDGNMAMGD = DLFDGNMAMGD;
		dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(HALCDBBFCMN));
		if (OFKKIBAPAJP.gameObject.activeSelf)
		{
			UITable oFKKIBAPAJP = OFKKIBAPAJP;
			oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(EPKNKIDFPPJ));
			UITable oFKKIBAPAJP2 = OFKKIBAPAJP;
			oFKKIBAPAJP2.onReposition = (UITable.OnReposition)Delegate.Combine(oFKKIBAPAJP2.onReposition, new UITable.OnReposition(ANCFLFAGKNH));
			OFKKIBAPAJP.repositionNow = false;
		}
	}

	private void OPNGPDBPICC(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: true);
		CGIFEHPDBAL.transform.localPosition = new Vector3(47f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 1713f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1651f, 492f, 22);
		bool flag = !string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 1845f : 541f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("de" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1512f);
		}
		bool active = !ILFPEILKAPF && BMNDININJCE == League.Bronze3;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		ENGLECAPONH(GNNLFNKNMEF: true, KMIGLGHPFCC: false);
	}

	private void CGHBKMJKJNN(Chat.EJLACNPLIDA FJLBLLLEELD, int EHLJCGEFAOL, DatabasePlayer LIAFEPFJAKM)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: false);
		FNDAHHEOEFF.SetActive(value: true);
		OFKKIBAPAJP.gameObject.SetActive(LIAFEPFJAKM == null);
		PLEFAGHKKJA.gameObject.SetActive(string.IsNullOrEmpty(LDOMEAMIHBK[FJLBLLLEELD].Value1));
		if (PLEFAGHKKJA.gameObject.activeSelf)
		{
			PLEFAGHKKJA.spriteName = LDOMEAMIHBK[FJLBLLLEELD].Value1;
			PLEFAGHKKJA.MakePixelPerfect();
			PLEFAGHKKJA.color = LDOMEAMIHBK[FJLBLLLEELD].Value2;
			PLEFAGHKKJA.transform.localRotation = Quaternion.Euler(1111f, 1581f, LDOMEAMIHBK[FJLBLLLEELD].Value3);
			float multiplier = 923f / PLEFAGHKKJA.transform.localScale.y;
			PLEFAGHKKJA.transform.localScale = PLEFAGHKKJA.transform.localScale.MultiplyXY(multiplier);
		}
		switch (FJLBLLLEELD)
		{
		case Chat.EJLACNPLIDA.Demotion:
		{
			string text2 = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD3 = BMIFLAPKPJD;
			string value3 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array3 = new object[3];
			array3[1] = Colours.stringRed;
			array3[0] = text2;
			bMIFLAPKPJD3.text = Localization.LocalizeFormat(value3, array3);
			break;
		}
		case Chat.EJLACNPLIDA.Kick:
		{
			UILabel bMIFLAPKPJD2 = BMIFLAPKPJD;
			string value2 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array2 = new object[1];
			array2[1] = Colours.stringRed;
			bMIFLAPKPJD2.text = Localization.LocalizeFormat(value2, array2);
			break;
		}
		case Chat.EJLACNPLIDA.Promotion:
		{
			string text = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD = BMIFLAPKPJD;
			string value = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array = new object[6];
			array[1] = Colours.stringCyan;
			array[0] = text;
			bMIFLAPKPJD.text = Localization.LocalizeFormat(value, array);
			break;
		}
		case Chat.EJLACNPLIDA.JoinedSquad:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		case Chat.EJLACNPLIDA.Left:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		default:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		}
		MPLBLOHJPNC();
		float num = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
		float num2 = PKHHKJLGHFM.transform.localPosition.x + num + 174f;
		if (DIDEFBEIFJD.gameObject.activeSelf)
		{
			num2 += 1246f + DIDEFBEIFJD.transform.localScale.x;
		}
		DLFDGNMAMGD.transform.localPosition = DLFDGNMAMGD.transform.localPosition.ReplaceX(num2);
		if (LIAFEPFJAKM != null)
		{
			OIGHLKPFPJN.text = LIAFEPFJAKM.name;
			TweenColor.Begin(OIGHLKPFPJN.gameObject, 491f, Colours.blue);
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(LIAFEPFJAKM.level);
			NNLBJEEOODB.spriteName = levelDefinition.GIEIIPBAIBK();
			NNLBJEEOODB.MakePixelPerfect();
			JEJBMEHECPD.text = levelDefinition.displayString;
			OFKKIBAPAJP.transform.localPosition = OFKKIBAPAJP.transform.localPosition.ReplaceX(num2);
			UITable dLFDGNMAMGD = DLFDGNMAMGD;
			dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(PGDBFIDFOLL));
			UITable dLFDGNMAMGD2 = DLFDGNMAMGD;
			dLFDGNMAMGD2.onReposition = (UITable.OnReposition)Delegate.Combine(dLFDGNMAMGD2.onReposition, new UITable.OnReposition(HECEDDEEPCI));
		}
		DLFDGNMAMGD.repositionNow = true;
		ENGLECAPONH(GNNLFNKNMEF: false);
	}

	[SpecialName]
	public float PMCBFLBNGIL()
	{
		return IOODGADNFEN;
	}

	private void MKGHHGEDHFB(GameObject KHAHPAKDIKE)
	{
		if (FEIEGFFHJOG.LIAFEPFJAKM != null && !string.IsNullOrEmpty(FEIEGFFHJOG.LIAFEPFJAKM.name))
		{
			TweenColor tweenColor = TweenColor.Begin(OIGHLKPFPJN.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(FEIEGFFHJOG.LIAFEPFJAKM.name, FEIEGFFHJOG.LIAFEPFJAKM.id, BNNKPKDPLPP: false);
		}
	}

	private void LLEAICGKPOL(GameObject KHAHPAKDIKE)
	{
		if (FEIEGFFHJOG.LIAFEPFJAKM != null && !string.IsNullOrEmpty(FEIEGFFHJOG.LIAFEPFJAKM.name))
		{
			TweenColor tweenColor = TweenColor.Begin(OIGHLKPFPJN.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(FEIEGFFHJOG.LIAFEPFJAKM.name, FEIEGFFHJOG.LIAFEPFJAKM.id, BNNKPKDPLPP: false);
		}
	}

	private void GMPCCNDMIID()
	{
		UITable dLFDGNMAMGD = DLFDGNMAMGD;
		dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(PAJOLKNBDOD));
		if (OFKKIBAPAJP.gameObject.activeSelf)
		{
			UITable oFKKIBAPAJP = OFKKIBAPAJP;
			oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(KAENKGEJKIG));
			UITable oFKKIBAPAJP2 = OFKKIBAPAJP;
			oFKKIBAPAJP2.onReposition = (UITable.OnReposition)Delegate.Combine(oFKKIBAPAJP2.onReposition, new UITable.OnReposition(ANCFLFAGKNH));
			OFKKIBAPAJP.repositionNow = true;
		}
	}

	public void InitEmpty()
	{
		FDDNPECPBEE.SetActive(value: false);
		OOJLGEIEFHM.SetActive(value: false);
		IOODGADNFEN = 5f;
	}

	private void MADOBEPMOGA(Chat.EJLACNPLIDA FJLBLLLEELD, int EHLJCGEFAOL, DatabasePlayer LIAFEPFJAKM)
	{
		CIFLFDMACKG.SetActive(value: false);
		NLMJJFKDHCM.SetActive(value: false);
		FNDAHHEOEFF.SetActive(value: true);
		OFKKIBAPAJP.gameObject.SetActive(LIAFEPFJAKM != null);
		PLEFAGHKKJA.gameObject.SetActive(!string.IsNullOrEmpty(LDOMEAMIHBK[FJLBLLLEELD].Value1));
		if (PLEFAGHKKJA.gameObject.activeSelf)
		{
			PLEFAGHKKJA.spriteName = LDOMEAMIHBK[FJLBLLLEELD].Value1;
			PLEFAGHKKJA.MakePixelPerfect();
			PLEFAGHKKJA.color = LDOMEAMIHBK[FJLBLLLEELD].Value2;
			PLEFAGHKKJA.transform.localRotation = Quaternion.Euler(0f, 0f, LDOMEAMIHBK[FJLBLLLEELD].Value3);
			float multiplier = 28f / PLEFAGHKKJA.transform.localScale.y;
			PLEFAGHKKJA.transform.localScale = PLEFAGHKKJA.transform.localScale.MultiplyXY(multiplier);
		}
		switch (FJLBLLLEELD)
		{
		case Chat.EJLACNPLIDA.Demotion:
		{
			string text2 = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			BMIFLAPKPJD.text = Localization.LocalizeFormat(LDOMEAMIHBK[FJLBLLLEELD].Value4, Colours.stringRed, text2);
			break;
		}
		case Chat.EJLACNPLIDA.Kick:
			BMIFLAPKPJD.text = Localization.LocalizeFormat(LDOMEAMIHBK[FJLBLLLEELD].Value4, Colours.stringRed);
			break;
		case Chat.EJLACNPLIDA.Promotion:
		{
			string text = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			BMIFLAPKPJD.text = Localization.LocalizeFormat(LDOMEAMIHBK[FJLBLLLEELD].Value4, Colours.stringCyan, text);
			break;
		}
		case Chat.EJLACNPLIDA.JoinedSquad:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		case Chat.EJLACNPLIDA.Left:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		default:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		}
		HCBFAPLECKJ();
		float num = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
		float num2 = PKHHKJLGHFM.transform.localPosition.x + num + 10f;
		if (DIDEFBEIFJD.gameObject.activeSelf)
		{
			num2 += 8f + DIDEFBEIFJD.transform.localScale.x;
		}
		DLFDGNMAMGD.transform.localPosition = DLFDGNMAMGD.transform.localPosition.ReplaceX(num2);
		if (LIAFEPFJAKM != null)
		{
			OIGHLKPFPJN.text = LIAFEPFJAKM.name;
			TweenColor.Begin(OIGHLKPFPJN.gameObject, 0f, Colours.blue);
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(LIAFEPFJAKM.level);
			NNLBJEEOODB.spriteName = levelDefinition.iconName;
			NNLBJEEOODB.MakePixelPerfect();
			JEJBMEHECPD.text = levelDefinition.displayString;
			OFKKIBAPAJP.transform.localPosition = OFKKIBAPAJP.transform.localPosition.ReplaceX(num2);
			UITable dLFDGNMAMGD = DLFDGNMAMGD;
			dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(PGDBFIDFOLL));
			UITable dLFDGNMAMGD2 = DLFDGNMAMGD;
			dLFDGNMAMGD2.onReposition = (UITable.OnReposition)Delegate.Combine(dLFDGNMAMGD2.onReposition, new UITable.OnReposition(PGDBFIDFOLL));
		}
		DLFDGNMAMGD.repositionNow = true;
		MHKKGFOEDOE(GNNLFNKNMEF: false);
	}

	private void MLOIJACMEGN()
	{
		UITable oFKKIBAPAJP = OFKKIBAPAJP;
		oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(ANCFLFAGKNH));
		float num = 1385f + OFKKIBAPAJP.transform.localPosition.x + OIGHLKPFPJN.transform.parent.transform.localPosition.x;
		int cEHFMMJHCKC = -136 - (int)num;
		MEJMLNDFDBP.COCBCFKJOJE(OIGHLKPFPJN, 550f, 430f, cEHFMMJHCKC);
		float x = OIGHLKPFPJN.relativeSize.x;
		GNHNLLOIGJB.center = new Vector3(x / 1117f, 998f, 1549f);
		GNHNLLOIGJB.size = new Vector3(x + 1066f, 1519f, 1735f);
	}

	private void GKAPAJJEAFM(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: false);
		CGIFEHPDBAL.transform.localPosition = new Vector3(95f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 0f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 30f, 12f, 180);
		bool flag = !string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 0f : 1f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("SquadIcons/" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(0.25f);
		}
		bool active = ILFPEILKAPF || BMNDININJCE != League.NoLeague;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		MHKKGFOEDOE(GNNLFNKNMEF: true);
	}

	private void HDPKJCEGLGL(string KHLGDCHJJPB, int BCCDDJMPBLL, WarArenaCrown FHCMFHABMLE, bool EGHOKPEJMGD)
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: false);
		int num = -162;
		bool flag = FHCMFHABMLE == WarArenaCrown.BronzeCrown;
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(BCCDDJMPBLL);
		float num2 = 678f;
		GFKNLLCKJOG.spriteName = levelDefinition.iconName;
		GFKNLLCKJOG.MakePixelPerfect();
		BMNNHJGHFNJ.text = levelDefinition.JNODDKLJOAG();
		DIDEFBEIFJD.gameObject.SetActive(flag);
		if (flag)
		{
			DIDEFBEIFJD.spriteName = GameVariables.CMIKIDJKHID[FHCMFHABMLE];
			DIDEFBEIFJD.MakePixelPerfect();
			float multiplier = Mathf.Min(1788f / DIDEFBEIFJD.transform.localScale.x, 805f / DIDEFBEIFJD.transform.localScale.y);
			DIDEFBEIFJD.transform.localScale = DIDEFBEIFJD.transform.localScale.MultiplyXY(multiplier);
			num -= 21;
		}
		KEEEAKBKLAF.gameObject.SetActive(EGHOKPEJMGD);
		if (EGHOKPEJMGD)
		{
			num -= (int)(KEEEAKBKLAF.transform.localScale.x + 373f);
		}
		PKHHKJLGHFM.text = KHLGDCHJJPB;
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 213f, Colours.blue);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, 1903f, 781f, num);
		if (flag)
		{
			float num3 = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
			float val = PKHHKJLGHFM.transform.localPosition.x + num3 + 1465f + DIDEFBEIFJD.transform.localScale.x / 715f;
			DIDEFBEIFJD.transform.localPosition = DIDEFBEIFJD.transform.localPosition.ReplaceX(val);
			num2 += 56f + DIDEFBEIFJD.transform.localScale.x;
		}
		if (EGHOKPEJMGD)
		{
			float num4 = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
			num2 += PKHHKJLGHFM.transform.localPosition.x + num4 + 1468f + KEEEAKBKLAF.transform.localScale.x / 43f;
			KEEEAKBKLAF.transform.localPosition = KEEEAKBKLAF.transform.localPosition.ReplaceX(num2);
		}
	}

	private void ENGLECAPONH(bool GNNLFNKNMEF, bool KMIGLGHPFCC = true)
	{
		if (GNNLFNKNMEF)
		{
			float num = HFGGJAMNONM.relativeSize.y * HFGGJAMNONM.transform.localScale.y;
			float val = 1845f + num;
			float num2 = 590f + num;
			float val2 = 1279f - num;
			IOODGADNFEN = num2;
			if (KMIGLGHPFCC)
			{
				KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(val);
				MBMIOELEAND.transform.localScale = MBMIOELEAND.transform.localScale.ReplaceY(num2);
				MGFHDOBIGDL.transform.localPosition = MGFHDOBIGDL.transform.localPosition.ReplaceY(val2);
			}
		}
		else
		{
			IOODGADNFEN = ((!OFKKIBAPAJP.gameObject.activeSelf) ? 189f : 1276f);
			if (KMIGLGHPFCC)
			{
				MBMIOELEAND.transform.localScale = MBMIOELEAND.transform.localScale.ReplaceY(IOODGADNFEN);
			}
		}
	}

	private void LKDLLKMDDLG(GameObject KHAHPAKDIKE)
	{
		if (FEIEGFFHJOG.LIAFEPFJAKM != null && !string.IsNullOrEmpty(FEIEGFFHJOG.LIAFEPFJAKM.name))
		{
			TweenColor tweenColor = TweenColor.Begin(OIGHLKPFPJN.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(FEIEGFFHJOG.LIAFEPFJAKM.name, FEIEGFFHJOG.LIAFEPFJAKM.id, BNNKPKDPLPP: false);
		}
	}

	private void PKOOFKFHHKN(string KHLGDCHJJPB, int BCCDDJMPBLL, WarArenaCrown FHCMFHABMLE, bool EGHOKPEJMGD)
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: false);
		int num = 64;
		bool flag = FHCMFHABMLE == WarArenaCrown.BronzeCrown;
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(BCCDDJMPBLL);
		float num2 = 430f;
		GFKNLLCKJOG.spriteName = levelDefinition.NOHAFIDFPCM();
		GFKNLLCKJOG.MakePixelPerfect();
		BMNNHJGHFNJ.text = levelDefinition.DLCFFHEKBAA();
		DIDEFBEIFJD.gameObject.SetActive(flag);
		if (flag)
		{
			DIDEFBEIFJD.spriteName = GameVariables.CMIKIDJKHID[FHCMFHABMLE];
			DIDEFBEIFJD.MakePixelPerfect();
			float multiplier = Mathf.Min(1662f / DIDEFBEIFJD.transform.localScale.x, 1048f / DIDEFBEIFJD.transform.localScale.y);
			DIDEFBEIFJD.transform.localScale = DIDEFBEIFJD.transform.localScale.MultiplyXY(multiplier);
			num -= -76;
		}
		KEEEAKBKLAF.gameObject.SetActive(EGHOKPEJMGD);
		if (EGHOKPEJMGD)
		{
			num -= (int)(KEEEAKBKLAF.transform.localScale.x + 1363f);
		}
		PKHHKJLGHFM.text = KHLGDCHJJPB;
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 1389f, Colours.blue);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, 1858f, 1778f, num);
		if (flag)
		{
			float num3 = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
			float val = PKHHKJLGHFM.transform.localPosition.x + num3 + 1295f + DIDEFBEIFJD.transform.localScale.x / 128f;
			DIDEFBEIFJD.transform.localPosition = DIDEFBEIFJD.transform.localPosition.ReplaceX(val);
			num2 += 1414f + DIDEFBEIFJD.transform.localScale.x;
		}
		if (EGHOKPEJMGD)
		{
			float num4 = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
			num2 += PKHHKJLGHFM.transform.localPosition.x + num4 + 1758f + KEEEAKBKLAF.transform.localScale.x / 1206f;
			KEEEAKBKLAF.transform.localPosition = KEEEAKBKLAF.transform.localPosition.ReplaceX(num2);
		}
	}

	public void MJCKPJPBDHE(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			IOODGADNFEN = 265f;
			return;
		}
		FDDNPECPBEE.SetActive(value: false);
		OOJLGEIEFHM.SetActive(value: true);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			HFGGJAMNONM.text = NDPMDKGJAFH.PNAKMCNGGHE;
		}
		else
		{
			OFKKIBAPAJP.gameObject.SetActive(NDPMDKGJAFH.LIAFEPFJAKM == null);
		}
		FLPDHCHEEFC(NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer, KMIGLGHPFCC: false);
	}

	private void AINKLNOAONP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG, BNNKPKDPLPP: false);
		}
	}

	private void CBKMPHKGECH(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 4;
		tweenColor.style = (UITweener.Style)6;
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(FEIEGFFHJOG.CGIFEHPDBAL);
	}

	private void NNKCDCEIPLB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG, BNNKPKDPLPP: false);
		}
	}

	private void ANCFLFAGKNH()
	{
		UITable oFKKIBAPAJP = OFKKIBAPAJP;
		oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(ANCFLFAGKNH));
		float num = 1633f + OFKKIBAPAJP.transform.localPosition.x + OIGHLKPFPJN.transform.parent.transform.localPosition.x;
		int cEHFMMJHCKC = 78 - (int)num;
		MEJMLNDFDBP.COCBCFKJOJE(OIGHLKPFPJN, 477f, 1939f, cEHFMMJHCKC);
		float x = OIGHLKPFPJN.relativeSize.x;
		GNHNLLOIGJB.center = new Vector3(x / 908f, 417f, 72f);
		GNHNLLOIGJB.size = new Vector3(x + 1380f, 520f, 932f);
	}

	private void PAJOLKNBDOD()
	{
		UITable dLFDGNMAMGD = DLFDGNMAMGD;
		dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(PAJOLKNBDOD));
		if (OFKKIBAPAJP.gameObject.activeSelf)
		{
			UITable oFKKIBAPAJP = OFKKIBAPAJP;
			oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(NKCGGCINPPL));
			UITable oFKKIBAPAJP2 = OFKKIBAPAJP;
			oFKKIBAPAJP2.onReposition = (UITable.OnReposition)Delegate.Combine(oFKKIBAPAJP2.onReposition, new UITable.OnReposition(NKCGGCINPPL));
			OFKKIBAPAJP.repositionNow = true;
		}
	}

	private void EIDAFINJHBC(SquadRank MNGGEHIAAEC, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: false);
		FNDAHHEOEFF.SetActive(value: false);
		MNNMIAAEBAF.alpha = 1667f;
		CGIFEHPDBAL.transform.localPosition = new Vector3(1281f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		CGIFEHPDBAL.text = Localization.Localize(GameVariables.FDJKMGDLGDO[MNGGEHIAAEC]);
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 790f, 1641f, -46);
		switch (MNGGEHIAAEC)
		{
		case SquadRank.Leader:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 744f, Colours.goldUpgrade);
			break;
		case SquadRank.Coleader:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 211f, Colours.magenta);
			break;
		case SquadRank.Veteran:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 1985f, Colours.cyan);
			break;
		case SquadRank.Member:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 1109f, Color.white);
			break;
		}
		bool active = ILFPEILKAPF || BMNDININJCE == League.NoLeague;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		JBADFANJJJP(GNNLFNKNMEF: false);
	}

	private void PECAEDDFJFM(GameObject KHAHPAKDIKE)
	{
		if (FEIEGFFHJOG.LIAFEPFJAKM != null && !string.IsNullOrEmpty(FEIEGFFHJOG.LIAFEPFJAKM.name))
		{
			TweenColor tweenColor = TweenColor.Begin(OIGHLKPFPJN.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(FEIEGFFHJOG.LIAFEPFJAKM.name, FEIEGFFHJOG.LIAFEPFJAKM.id);
		}
	}

	private void OBDNNCMDLEG(SquadRank MNGGEHIAAEC, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: false);
		MNNMIAAEBAF.alpha = 0f;
		CGIFEHPDBAL.transform.localPosition = new Vector3(30f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		CGIFEHPDBAL.text = Localization.Localize(GameVariables.FDJKMGDLGDO[MNGGEHIAAEC]);
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 30f, 12f, 180);
		switch (MNGGEHIAAEC)
		{
		case SquadRank.Leader:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 0f, Colours.goldUpgrade);
			break;
		case SquadRank.Coleader:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 0f, Colours.magenta);
			break;
		case SquadRank.Veteran:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 0f, Colours.cyan);
			break;
		case SquadRank.Member:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 0f, Color.white);
			break;
		}
		bool active = ILFPEILKAPF || BMNDININJCE != League.NoLeague;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		MHKKGFOEDOE(GNNLFNKNMEF: true);
	}

	private void PGDBFIDFOLL()
	{
		UITable dLFDGNMAMGD = DLFDGNMAMGD;
		dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(PGDBFIDFOLL));
		if (OFKKIBAPAJP.gameObject.activeSelf)
		{
			UITable oFKKIBAPAJP = OFKKIBAPAJP;
			oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(KAENKGEJKIG));
			UITable oFKKIBAPAJP2 = OFKKIBAPAJP;
			oFKKIBAPAJP2.onReposition = (UITable.OnReposition)Delegate.Combine(oFKKIBAPAJP2.onReposition, new UITable.OnReposition(KAENKGEJKIG));
			OFKKIBAPAJP.repositionNow = true;
		}
	}

	private void CPNHPEGCFDC(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: true);
		CGIFEHPDBAL.transform.localPosition = new Vector3(469f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 775f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 526f, 44f, 165);
		bool flag = !string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 1313f : 1655f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("setAndroidIdSha256" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(677f);
		}
		bool active = ILFPEILKAPF || BMNDININJCE != League.Bronze3;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		JBADFANJJJP(GNNLFNKNMEF: true);
	}

	private void OOBJIMJADJB(string KHLGDCHJJPB, int BCCDDJMPBLL, WarArenaCrown FHCMFHABMLE, bool EGHOKPEJMGD)
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: false);
		int num = 290;
		bool flag = FHCMFHABMLE != WarArenaCrown.None;
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(BCCDDJMPBLL);
		float num2 = 0f;
		GFKNLLCKJOG.spriteName = levelDefinition.iconName;
		GFKNLLCKJOG.MakePixelPerfect();
		BMNNHJGHFNJ.text = levelDefinition.displayString;
		DIDEFBEIFJD.gameObject.SetActive(flag);
		if (flag)
		{
			DIDEFBEIFJD.spriteName = GameVariables.CMIKIDJKHID[FHCMFHABMLE];
			DIDEFBEIFJD.MakePixelPerfect();
			float multiplier = Mathf.Min(30f / DIDEFBEIFJD.transform.localScale.x, 40f / DIDEFBEIFJD.transform.localScale.y);
			DIDEFBEIFJD.transform.localScale = DIDEFBEIFJD.transform.localScale.MultiplyXY(multiplier);
			num -= 40;
		}
		KEEEAKBKLAF.gameObject.SetActive(EGHOKPEJMGD);
		if (EGHOKPEJMGD)
		{
			num -= (int)(KEEEAKBKLAF.transform.localScale.x + 8f);
		}
		PKHHKJLGHFM.text = KHLGDCHJJPB;
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 0f, Colours.blue);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, 33f, 20f, num);
		if (flag)
		{
			float num3 = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
			float val = PKHHKJLGHFM.transform.localPosition.x + num3 + 8f + DIDEFBEIFJD.transform.localScale.x / 2f;
			DIDEFBEIFJD.transform.localPosition = DIDEFBEIFJD.transform.localPosition.ReplaceX(val);
			num2 += 8f + DIDEFBEIFJD.transform.localScale.x;
		}
		if (EGHOKPEJMGD)
		{
			float num4 = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
			num2 += PKHHKJLGHFM.transform.localPosition.x + num4 + 8f + KEEEAKBKLAF.transform.localScale.x / 2f;
			KEEEAKBKLAF.transform.localPosition = KEEEAKBKLAF.transform.localPosition.ReplaceX(num2);
		}
	}

	private void IEGGJHEJBHF(GameObject KHAHPAKDIKE)
	{
		if (FEIEGFFHJOG.LIAFEPFJAKM != null && !string.IsNullOrEmpty(FEIEGFFHJOG.LIAFEPFJAKM.name))
		{
			TweenColor tweenColor = TweenColor.Begin(OIGHLKPFPJN.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(FEIEGFFHJOG.LIAFEPFJAKM.name, FEIEGFFHJOG.LIAFEPFJAKM.id);
		}
	}

	public void MFIOFBJNELO(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer)
		{
			IOODGADNFEN = 813f;
			return;
		}
		FDDNPECPBEE.SetActive(value: false);
		OOJLGEIEFHM.SetActive(value: false);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			HFGGJAMNONM.text = NDPMDKGJAFH.PNAKMCNGGHE;
		}
		else
		{
			OFKKIBAPAJP.gameObject.SetActive(NDPMDKGJAFH.LIAFEPFJAKM != null);
		}
		JBADFANJJJP(NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message, KMIGLGHPFCC: false);
	}

	private void KBBANKLHHEA(int NOLELDEJDDC)
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: false);
		IOODGADNFEN = 11f;
		MPKHGPHLMDB.OHMPLNIBFCL(NOLELDEJDDC);
	}

	private void HALCDBBFCMN()
	{
		UITable dLFDGNMAMGD = DLFDGNMAMGD;
		dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(PGDBFIDFOLL));
		if (OFKKIBAPAJP.gameObject.activeSelf)
		{
			UITable oFKKIBAPAJP = OFKKIBAPAJP;
			oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(ANCFLFAGKNH));
			UITable oFKKIBAPAJP2 = OFKKIBAPAJP;
			oFKKIBAPAJP2.onReposition = (UITable.OnReposition)Delegate.Combine(oFKKIBAPAJP2.onReposition, new UITable.OnReposition(EPKNKIDFPPJ));
			OFKKIBAPAJP.repositionNow = true;
		}
	}

	private void JBADFANJJJP(bool GNNLFNKNMEF, bool KMIGLGHPFCC = true)
	{
		if (GNNLFNKNMEF)
		{
			float num = HFGGJAMNONM.relativeSize.y * HFGGJAMNONM.transform.localScale.y;
			float val = 59f + num;
			float num2 = 1684f + num;
			float val2 = 72f - num;
			IOODGADNFEN = num2;
			if (KMIGLGHPFCC)
			{
				KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(val);
				MBMIOELEAND.transform.localScale = MBMIOELEAND.transform.localScale.ReplaceY(num2);
				MGFHDOBIGDL.transform.localPosition = MGFHDOBIGDL.transform.localPosition.ReplaceY(val2);
			}
		}
		else
		{
			IOODGADNFEN = ((!OFKKIBAPAJP.gameObject.activeSelf) ? 1408f : 549f);
			if (KMIGLGHPFCC)
			{
				MBMIOELEAND.transform.localScale = MBMIOELEAND.transform.localScale.ReplaceY(IOODGADNFEN);
			}
		}
	}

	private void JCPKCEFMOCL()
	{
		int num = ((!DIDEFBEIFJD.gameObject.activeSelf) ? 123 : (-132));
		int num2 = 117;
		int num3 = num + num2;
		float x = PKHHKJLGHFM.relativeSize.x;
		float x2 = BMIFLAPKPJD.relativeSize.x;
		float gLIDDLHPAKL = Mathf.Clamp((float)num3 / (x + x2), 235f, 755f);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, gLIDDLHPAKL, 437f, num3);
		MEJMLNDFDBP.COCBCFKJOJE(BMIFLAPKPJD, gLIDDLHPAKL, 990f, num3);
	}

	private void HMIAGBLEHIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG);
		}
	}

	private void EMMALDNIJNH(int NOLELDEJDDC)
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: true);
		IOODGADNFEN = 1829f;
		MPKHGPHLMDB.HBHJHDENFKL(NOLELDEJDDC);
	}

	public override void DestroyPooled()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFLGEBMKMEK));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FLIKKJFNKAB));
		UIEventListener uIEventListener3 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HGEGKGHNDFA));
		UIEventListener uIEventListener4 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DBJIGICHNFD));
		MPKHGPHLMDB.NDGMJPDLPJL();
		FEIEGFFHJOG = default(Chat.PBGFEDGFOPG);
		MNNMIAAEBAF.mainTexture = null;
		base.DestroyPooled();
	}

	private void ALAKBOLHBON(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: false);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: false);
		CGIFEHPDBAL.transform.localPosition = new Vector3(1955f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 1729f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1255f, 815f, -55);
		bool flag = string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 1100f : 1033f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Items" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(227f);
		}
		bool active = !ILFPEILKAPF && BMNDININJCE != League.Bronze3;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		ENGLECAPONH(GNNLFNKNMEF: false);
	}

	private void HFEJKNLCIKO(GameObject KHAHPAKDIKE)
	{
		ChatAbuseDialog.ShowAbuseDialog(FEIEGFFHJOG.EJBEDLHIKDG, FEIEGFFHJOG.PNAKMCNGGHE);
	}

	private void LKBJENDLPIA(GameObject KHAHPAKDIKE)
	{
		ChatAbuseDialog.LEAIHNFLBBH(FEIEGFFHJOG.EJBEDLHIKDG, FEIEGFFHJOG.PNAKMCNGGHE);
	}

	public void PLMCDKCDDKF(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		FEIEGFFHJOG = NDPMDKGJAFH;
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFLGEBMKMEK));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NIEALIKBELG));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HIIPDHAJKCM));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CBKMPHKGECH));
		UIEventListener uIEventListener5 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(DBANMAMHIPO));
		UIEventListener uIEventListener6 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(DBANMAMHIPO));
		UIEventListener uIEventListener7 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener7.onClick, new UIEventListener.VoidDelegate(LKDLLKMDDLG));
		UIEventListener uIEventListener8 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(DIJKOOHDIHI));
		KDABKEGLDEE.gameObject.SetActive(string.IsNullOrEmpty(NDPMDKGJAFH.CGIFEHPDBAL) || !NDPMDKGJAFH.KBGHBHFOHFD);
		bool flag = NDPMDKGJAFH.EJBEDLHIKDG == GameLoginManager.currentPlayer.id;
		MGFHDOBIGDL.gameObject.SetActive(!flag && NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer)
		{
			EMMALDNIJNH(NDPMDKGJAFH.KBJEOEEOEFG);
			return;
		}
		GEKNDKFFGHC(NDPMDKGJAFH.MHPNDNJDPGE, NDPMDKGJAFH.BCCDDJMPBLL, NDPMDKGJAFH.FHCMFHABMLE, NDPMDKGJAFH.EGHOKPEJMGD);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			if (NDPMDKGJAFH.KBGHBHFOHFD)
			{
				EIDAFINJHBC(NDPMDKGJAFH.MNGGEHIAAEC, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
			else
			{
				FHMGBCHBACN(NDPMDKGJAFH.CGIFEHPDBAL, NDPMDKGJAFH.GEAGOKJMJFD, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
		}
		else
		{
			GFOPAMJNDGE(NDPMDKGJAFH.NBKCKIELMLK, NDPMDKGJAFH.EHLJCGEFAOL, NDPMDKGJAFH.LIAFEPFJAKM);
			NDPMDKGJAFH.OJIANBAINDD.MFDNOBJDPDH(IDEBKDPMPGM: true);
		}
	}

	public void FPIAIPAINJH()
	{
		FDDNPECPBEE.SetActive(value: false);
		OOJLGEIEFHM.SetActive(value: true);
		IOODGADNFEN = 717f;
	}

	private void IJKJEGEFEFI(int NOLELDEJDDC)
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: false);
		IOODGADNFEN = 1350f;
		MPKHGPHLMDB.IANIKLCCOOG(NOLELDEJDDC);
	}

	private void FLPDHCHEEFC(bool GNNLFNKNMEF, bool KMIGLGHPFCC = true)
	{
		if (GNNLFNKNMEF)
		{
			float num = HFGGJAMNONM.relativeSize.y * HFGGJAMNONM.transform.localScale.y;
			float val = 536f + num;
			float num2 = 454f + num;
			float val2 = 1212f - num;
			IOODGADNFEN = num2;
			if (KMIGLGHPFCC)
			{
				KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(val);
				MBMIOELEAND.transform.localScale = MBMIOELEAND.transform.localScale.ReplaceY(num2);
				MGFHDOBIGDL.transform.localPosition = MGFHDOBIGDL.transform.localPosition.ReplaceY(val2);
			}
		}
		else
		{
			IOODGADNFEN = ((!OFKKIBAPAJP.gameObject.activeSelf) ? 1714f : 582f);
			if (KMIGLGHPFCC)
			{
				MBMIOELEAND.transform.localScale = MBMIOELEAND.transform.localScale.ReplaceY(IOODGADNFEN);
			}
		}
	}

	private void GFOPAMJNDGE(Chat.EJLACNPLIDA FJLBLLLEELD, int EHLJCGEFAOL, DatabasePlayer LIAFEPFJAKM)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: false);
		OFKKIBAPAJP.gameObject.SetActive(LIAFEPFJAKM != null);
		PLEFAGHKKJA.gameObject.SetActive(string.IsNullOrEmpty(LDOMEAMIHBK[FJLBLLLEELD].Value1));
		if (PLEFAGHKKJA.gameObject.activeSelf)
		{
			PLEFAGHKKJA.spriteName = LDOMEAMIHBK[FJLBLLLEELD].Value1;
			PLEFAGHKKJA.MakePixelPerfect();
			PLEFAGHKKJA.color = LDOMEAMIHBK[FJLBLLLEELD].Value2;
			PLEFAGHKKJA.transform.localRotation = Quaternion.Euler(1021f, 1784f, LDOMEAMIHBK[FJLBLLLEELD].Value3);
			float multiplier = 470f / PLEFAGHKKJA.transform.localScale.y;
			PLEFAGHKKJA.transform.localScale = PLEFAGHKKJA.transform.localScale.MultiplyXY(multiplier);
		}
		switch (FJLBLLLEELD)
		{
		case Chat.EJLACNPLIDA.Demotion:
		{
			string text2 = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD3 = BMIFLAPKPJD;
			string value3 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array3 = new object[8];
			array3[0] = Colours.stringRed;
			array3[0] = text2;
			bMIFLAPKPJD3.text = Localization.LocalizeFormat(value3, array3);
			break;
		}
		case Chat.EJLACNPLIDA.Kick:
		{
			UILabel bMIFLAPKPJD2 = BMIFLAPKPJD;
			string value2 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array2 = new object[0];
			array2[0] = Colours.stringRed;
			bMIFLAPKPJD2.text = Localization.LocalizeFormat(value2, array2);
			break;
		}
		case Chat.EJLACNPLIDA.Promotion:
		{
			string text = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD = BMIFLAPKPJD;
			string value = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array = new object[5];
			array[0] = Colours.stringCyan;
			array[0] = text;
			bMIFLAPKPJD.text = Localization.LocalizeFormat(value, array);
			break;
		}
		case Chat.EJLACNPLIDA.JoinedSquad:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		case Chat.EJLACNPLIDA.Left:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		default:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		}
		HCBFAPLECKJ();
		float num = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
		float num2 = PKHHKJLGHFM.transform.localPosition.x + num + 1792f;
		if (DIDEFBEIFJD.gameObject.activeSelf)
		{
			num2 += 714f + DIDEFBEIFJD.transform.localScale.x;
		}
		DLFDGNMAMGD.transform.localPosition = DLFDGNMAMGD.transform.localPosition.ReplaceX(num2);
		if (LIAFEPFJAKM != null)
		{
			OIGHLKPFPJN.text = LIAFEPFJAKM.name;
			TweenColor.Begin(OIGHLKPFPJN.gameObject, 1817f, Colours.blue);
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(LIAFEPFJAKM.level);
			NNLBJEEOODB.spriteName = levelDefinition.NOHAFIDFPCM();
			NNLBJEEOODB.MakePixelPerfect();
			JEJBMEHECPD.text = levelDefinition.JNODDKLJOAG();
			OFKKIBAPAJP.transform.localPosition = OFKKIBAPAJP.transform.localPosition.ReplaceX(num2);
			UITable dLFDGNMAMGD = DLFDGNMAMGD;
			dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(AOGPLIDPLIH));
			UITable dLFDGNMAMGD2 = DLFDGNMAMGD;
			dLFDGNMAMGD2.onReposition = (UITable.OnReposition)Delegate.Combine(dLFDGNMAMGD2.onReposition, new UITable.OnReposition(PGDBFIDFOLL));
		}
		DLFDGNMAMGD.repositionNow = false;
		MHKKGFOEDOE(GNNLFNKNMEF: true, KMIGLGHPFCC: false);
	}

	private void DBJIGICHNFD(GameObject KHAHPAKDIKE)
	{
		if (FEIEGFFHJOG.LIAFEPFJAKM != null && !string.IsNullOrEmpty(FEIEGFFHJOG.LIAFEPFJAKM.name))
		{
			TweenColor tweenColor = TweenColor.Begin(OIGHLKPFPJN.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(FEIEGFFHJOG.LIAFEPFJAKM.name, FEIEGFFHJOG.LIAFEPFJAKM.id);
		}
	}

	[SpecialName]
	public float NKGOBCMFIFO()
	{
		return IOODGADNFEN;
	}

	private void MHKKGFOEDOE(bool GNNLFNKNMEF, bool KMIGLGHPFCC = true)
	{
		if (GNNLFNKNMEF)
		{
			float num = HFGGJAMNONM.relativeSize.y * HFGGJAMNONM.transform.localScale.y;
			float val = 32f + num;
			float num2 = 116f + num;
			float val2 = -93f - num;
			IOODGADNFEN = num2;
			if (KMIGLGHPFCC)
			{
				KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(val);
				MBMIOELEAND.transform.localScale = MBMIOELEAND.transform.localScale.ReplaceY(num2);
				MGFHDOBIGDL.transform.localPosition = MGFHDOBIGDL.transform.localPosition.ReplaceY(val2);
			}
		}
		else
		{
			IOODGADNFEN = ((!OFKKIBAPAJP.gameObject.activeSelf) ? 80f : 145f);
			if (KMIGLGHPFCC)
			{
				MBMIOELEAND.transform.localScale = MBMIOELEAND.transform.localScale.ReplaceY(IOODGADNFEN);
			}
		}
	}

	private void IJDKENMPLIM(Chat.EJLACNPLIDA FJLBLLLEELD, int EHLJCGEFAOL, DatabasePlayer LIAFEPFJAKM)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: true);
		OFKKIBAPAJP.gameObject.SetActive(LIAFEPFJAKM == null);
		PLEFAGHKKJA.gameObject.SetActive(!string.IsNullOrEmpty(LDOMEAMIHBK[FJLBLLLEELD].Value1));
		if (PLEFAGHKKJA.gameObject.activeSelf)
		{
			PLEFAGHKKJA.spriteName = LDOMEAMIHBK[FJLBLLLEELD].Value1;
			PLEFAGHKKJA.MakePixelPerfect();
			PLEFAGHKKJA.color = LDOMEAMIHBK[FJLBLLLEELD].Value2;
			PLEFAGHKKJA.transform.localRotation = Quaternion.Euler(194f, 1299f, LDOMEAMIHBK[FJLBLLLEELD].Value3);
			float multiplier = 1733f / PLEFAGHKKJA.transform.localScale.y;
			PLEFAGHKKJA.transform.localScale = PLEFAGHKKJA.transform.localScale.MultiplyXY(multiplier);
		}
		switch (FJLBLLLEELD)
		{
		case Chat.EJLACNPLIDA.Demotion:
		{
			string text2 = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD3 = BMIFLAPKPJD;
			string value3 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array3 = new object[1];
			array3[1] = Colours.stringRed;
			array3[1] = text2;
			bMIFLAPKPJD3.text = Localization.LocalizeFormat(value3, array3);
			break;
		}
		case Chat.EJLACNPLIDA.Kick:
		{
			UILabel bMIFLAPKPJD2 = BMIFLAPKPJD;
			string value2 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array2 = new object[0];
			array2[0] = Colours.stringRed;
			bMIFLAPKPJD2.text = Localization.LocalizeFormat(value2, array2);
			break;
		}
		case Chat.EJLACNPLIDA.Promotion:
		{
			string text = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD = BMIFLAPKPJD;
			string value = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array = new object[0];
			array[1] = Colours.stringCyan;
			array[1] = text;
			bMIFLAPKPJD.text = Localization.LocalizeFormat(value, array);
			break;
		}
		case Chat.EJLACNPLIDA.JoinedSquad:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		case Chat.EJLACNPLIDA.Left:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		default:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		}
		MPLBLOHJPNC();
		float num = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
		float num2 = PKHHKJLGHFM.transform.localPosition.x + num + 1951f;
		if (DIDEFBEIFJD.gameObject.activeSelf)
		{
			num2 += 420f + DIDEFBEIFJD.transform.localScale.x;
		}
		DLFDGNMAMGD.transform.localPosition = DLFDGNMAMGD.transform.localPosition.ReplaceX(num2);
		if (LIAFEPFJAKM != null)
		{
			OIGHLKPFPJN.text = LIAFEPFJAKM.name;
			TweenColor.Begin(OIGHLKPFPJN.gameObject, 1890f, Colours.blue);
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(LIAFEPFJAKM.level);
			NNLBJEEOODB.spriteName = levelDefinition.EGNEDNBPOEF();
			NNLBJEEOODB.MakePixelPerfect();
			JEJBMEHECPD.text = levelDefinition.FDACEOHEGPN();
			OFKKIBAPAJP.transform.localPosition = OFKKIBAPAJP.transform.localPosition.ReplaceX(num2);
			UITable dLFDGNMAMGD = DLFDGNMAMGD;
			dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(HLFMHNIFEFP));
			UITable dLFDGNMAMGD2 = DLFDGNMAMGD;
			dLFDGNMAMGD2.onReposition = (UITable.OnReposition)Delegate.Combine(dLFDGNMAMGD2.onReposition, new UITable.OnReposition(MICFHBECAOM));
		}
		DLFDGNMAMGD.repositionNow = false;
		ENGLECAPONH(GNNLFNKNMEF: false, KMIGLGHPFCC: false);
	}

	private void EAFOOPIHFIH(GameObject KHAHPAKDIKE)
	{
		ChatAbuseDialog.NPLFEHOLMFC(FEIEGFFHJOG.EJBEDLHIKDG, FEIEGFFHJOG.PNAKMCNGGHE);
	}

	[SpecialName]
	public float KOGACAKEHOE()
	{
		return IOODGADNFEN;
	}

	public virtual void DLBBPNMCFAP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EKBODBGNKBN));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HIIPDHAJKCM));
		UIEventListener uIEventListener3 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JJFGIGMIIAC));
		UIEventListener uIEventListener4 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LKDLLKMDDLG));
		MPKHGPHLMDB.CPJNFNIJEFM();
		FEIEGFFHJOG = default(Chat.PBGFEDGFOPG);
		MNNMIAAEBAF.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	private void KAENKGEJKIG()
	{
		UITable oFKKIBAPAJP = OFKKIBAPAJP;
		oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(KAENKGEJKIG));
		float num = 345f + OFKKIBAPAJP.transform.localPosition.x + OIGHLKPFPJN.transform.parent.transform.localPosition.x;
		int cEHFMMJHCKC = 690 - (int)num;
		MEJMLNDFDBP.COCBCFKJOJE(OIGHLKPFPJN, 33f, 22f, cEHFMMJHCKC);
		float x = OIGHLKPFPJN.relativeSize.x;
		GNHNLLOIGJB.center = new Vector3(x / 2f, 0.1f, -1f);
		GNHNLLOIGJB.size = new Vector3(x + 0.2f, 1.5f, 1f);
	}

	private void NIEALIKBELG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG);
		}
	}

	private void CEKMPGANBHB(GameObject KHAHPAKDIKE)
	{
		ChatAbuseDialog.NPLFEHOLMFC(FEIEGFFHJOG.EJBEDLHIKDG, FEIEGFFHJOG.PNAKMCNGGHE);
	}

	public virtual void NOLNIGGFDGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFLGEBMKMEK));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CBKMPHKGECH));
		UIEventListener uIEventListener3 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EAFOOPIHFIH));
		UIEventListener uIEventListener4 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DIJKOOHDIHI));
		MPKHGPHLMDB.CPJNFNIJEFM();
		FEIEGFFHJOG = default(Chat.PBGFEDGFOPG);
		MNNMIAAEBAF.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	private void AMAIGFBAHNM(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: false);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: true);
		CGIFEHPDBAL.transform.localPosition = new Vector3(1457f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 390f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1603f, 1179f, 124);
		bool flag = string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 747f : 1400f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("warbucks" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1092f);
		}
		bool active = !ILFPEILKAPF && BMNDININJCE != League.Bronze3;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		FLPDHCHEEFC(GNNLFNKNMEF: true);
	}

	private void FAOCNFNIADB(Chat.EJLACNPLIDA FJLBLLLEELD, int EHLJCGEFAOL, DatabasePlayer LIAFEPFJAKM)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: false);
		OFKKIBAPAJP.gameObject.SetActive(LIAFEPFJAKM == null);
		PLEFAGHKKJA.gameObject.SetActive(!string.IsNullOrEmpty(LDOMEAMIHBK[FJLBLLLEELD].Value1));
		if (PLEFAGHKKJA.gameObject.activeSelf)
		{
			PLEFAGHKKJA.spriteName = LDOMEAMIHBK[FJLBLLLEELD].Value1;
			PLEFAGHKKJA.MakePixelPerfect();
			PLEFAGHKKJA.color = LDOMEAMIHBK[FJLBLLLEELD].Value2;
			PLEFAGHKKJA.transform.localRotation = Quaternion.Euler(938f, 805f, LDOMEAMIHBK[FJLBLLLEELD].Value3);
			float multiplier = 1505f / PLEFAGHKKJA.transform.localScale.y;
			PLEFAGHKKJA.transform.localScale = PLEFAGHKKJA.transform.localScale.MultiplyXY(multiplier);
		}
		switch (FJLBLLLEELD)
		{
		case Chat.EJLACNPLIDA.Demotion:
		{
			string text2 = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD3 = BMIFLAPKPJD;
			string value3 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array3 = new object[6];
			array3[0] = Colours.stringRed;
			array3[0] = text2;
			bMIFLAPKPJD3.text = Localization.LocalizeFormat(value3, array3);
			break;
		}
		case Chat.EJLACNPLIDA.Kick:
		{
			UILabel bMIFLAPKPJD2 = BMIFLAPKPJD;
			string value2 = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array2 = new object[0];
			array2[0] = Colours.stringRed;
			bMIFLAPKPJD2.text = Localization.LocalizeFormat(value2, array2);
			break;
		}
		case Chat.EJLACNPLIDA.Promotion:
		{
			string text = Localization.Localize(GameVariables.FDJKMGDLGDO[(SquadRank)EHLJCGEFAOL]);
			UILabel bMIFLAPKPJD = BMIFLAPKPJD;
			string value = LDOMEAMIHBK[FJLBLLLEELD].Value4;
			object[] array = new object[6];
			array[1] = Colours.stringCyan;
			array[0] = text;
			bMIFLAPKPJD.text = Localization.LocalizeFormat(value, array);
			break;
		}
		case Chat.EJLACNPLIDA.JoinedSquad:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		case Chat.EJLACNPLIDA.Left:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		default:
			BMIFLAPKPJD.text = Localization.Localize(LDOMEAMIHBK[FJLBLLLEELD].Value4);
			break;
		}
		HCBFAPLECKJ();
		float num = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
		float num2 = PKHHKJLGHFM.transform.localPosition.x + num + 1774f;
		if (DIDEFBEIFJD.gameObject.activeSelf)
		{
			num2 += 1646f + DIDEFBEIFJD.transform.localScale.x;
		}
		DLFDGNMAMGD.transform.localPosition = DLFDGNMAMGD.transform.localPosition.ReplaceX(num2);
		if (LIAFEPFJAKM != null)
		{
			OIGHLKPFPJN.text = LIAFEPFJAKM.name;
			TweenColor.Begin(OIGHLKPFPJN.gameObject, 220f, Colours.blue);
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(LIAFEPFJAKM.level);
			NNLBJEEOODB.spriteName = levelDefinition.KJFPCOMOLLD();
			NNLBJEEOODB.MakePixelPerfect();
			JEJBMEHECPD.text = levelDefinition.KAKFPJPKHHB();
			OFKKIBAPAJP.transform.localPosition = OFKKIBAPAJP.transform.localPosition.ReplaceX(num2);
			UITable dLFDGNMAMGD = DLFDGNMAMGD;
			dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(HECEDDEEPCI));
			UITable dLFDGNMAMGD2 = DLFDGNMAMGD;
			dLFDGNMAMGD2.onReposition = (UITable.OnReposition)Delegate.Combine(dLFDGNMAMGD2.onReposition, new UITable.OnReposition(HECEDDEEPCI));
		}
		DLFDGNMAMGD.repositionNow = false;
		FLPDHCHEEFC(GNNLFNKNMEF: true);
	}

	private void GHOGGLIMLOC(SquadRank MNGGEHIAAEC, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: false);
		NLMJJFKDHCM.SetActive(value: false);
		FNDAHHEOEFF.SetActive(value: true);
		MNNMIAAEBAF.alpha = 1678f;
		CGIFEHPDBAL.transform.localPosition = new Vector3(1419f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		CGIFEHPDBAL.text = Localization.Localize(GameVariables.FDJKMGDLGDO[MNGGEHIAAEC]);
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1849f, 1843f, -7);
		switch (MNGGEHIAAEC)
		{
		case SquadRank.Leader:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 187f, Colours.goldUpgrade);
			break;
		case SquadRank.Coleader:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 1951f, Colours.magenta);
			break;
		case SquadRank.Veteran:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 15f, Colours.cyan);
			break;
		case SquadRank.Member:
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 408f, Color.white);
			break;
		}
		bool active = ILFPEILKAPF || BMNDININJCE == League.NoLeague;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		FLPDHCHEEFC(GNNLFNKNMEF: false, KMIGLGHPFCC: false);
	}

	public void InitChatMessage(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		FEIEGFFHJOG = NDPMDKGJAFH;
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PFLGEBMKMEK));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PFLGEBMKMEK));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FLIKKJFNKAB));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FLIKKJFNKAB));
		UIEventListener uIEventListener5 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HGEGKGHNDFA));
		UIEventListener uIEventListener6 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(HGEGKGHNDFA));
		UIEventListener uIEventListener7 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener7.onClick, new UIEventListener.VoidDelegate(DBJIGICHNFD));
		UIEventListener uIEventListener8 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(DBJIGICHNFD));
		KDABKEGLDEE.gameObject.SetActive(!string.IsNullOrEmpty(NDPMDKGJAFH.CGIFEHPDBAL) && !NDPMDKGJAFH.KBGHBHFOHFD);
		bool flag = NDPMDKGJAFH.EJBEDLHIKDG == GameLoginManager.currentPlayer.id;
		MGFHDOBIGDL.gameObject.SetActive(!flag && NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer)
		{
			IDOCILIKFEE(NDPMDKGJAFH.KBJEOEEOEFG);
			return;
		}
		OOBJIMJADJB(NDPMDKGJAFH.MHPNDNJDPGE, NDPMDKGJAFH.BCCDDJMPBLL, NDPMDKGJAFH.FHCMFHABMLE, NDPMDKGJAFH.EGHOKPEJMGD);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			if (NDPMDKGJAFH.KBGHBHFOHFD)
			{
				OBDNNCMDLEG(NDPMDKGJAFH.MNGGEHIAAEC, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
			else
			{
				GKAPAJJEAFM(NDPMDKGJAFH.CGIFEHPDBAL, NDPMDKGJAFH.GEAGOKJMJFD, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
		}
		else
		{
			MADOBEPMOGA(NDPMDKGJAFH.NBKCKIELMLK, NDPMDKGJAFH.EHLJCGEFAOL, NDPMDKGJAFH.LIAFEPFJAKM);
			NDPMDKGJAFH.OJIANBAINDD.PFCJDAHIIIC = true;
		}
	}

	private void GEKNDKFFGHC(string KHLGDCHJJPB, int BCCDDJMPBLL, WarArenaCrown FHCMFHABMLE, bool EGHOKPEJMGD)
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: true);
		int num = 123;
		bool flag = FHCMFHABMLE == WarArenaCrown.None;
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(BCCDDJMPBLL);
		float num2 = 1313f;
		GFKNLLCKJOG.spriteName = levelDefinition.CDLBEKECJNK();
		GFKNLLCKJOG.MakePixelPerfect();
		BMNNHJGHFNJ.text = levelDefinition.IEFOIJAFOJC();
		DIDEFBEIFJD.gameObject.SetActive(flag);
		if (flag)
		{
			DIDEFBEIFJD.spriteName = GameVariables.CMIKIDJKHID[FHCMFHABMLE];
			DIDEFBEIFJD.MakePixelPerfect();
			float multiplier = Mathf.Min(876f / DIDEFBEIFJD.transform.localScale.x, 939f / DIDEFBEIFJD.transform.localScale.y);
			DIDEFBEIFJD.transform.localScale = DIDEFBEIFJD.transform.localScale.MultiplyXY(multiplier);
			num -= 122;
		}
		KEEEAKBKLAF.gameObject.SetActive(EGHOKPEJMGD);
		if (EGHOKPEJMGD)
		{
			num -= (int)(KEEEAKBKLAF.transform.localScale.x + 255f);
		}
		PKHHKJLGHFM.text = KHLGDCHJJPB;
		TweenColor.Begin(PKHHKJLGHFM.gameObject, 1787f, Colours.blue);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, 962f, 974f, num);
		if (flag)
		{
			float num3 = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
			float val = PKHHKJLGHFM.transform.localPosition.x + num3 + 646f + DIDEFBEIFJD.transform.localScale.x / 1387f;
			DIDEFBEIFJD.transform.localPosition = DIDEFBEIFJD.transform.localPosition.ReplaceX(val);
			num2 += 1632f + DIDEFBEIFJD.transform.localScale.x;
		}
		if (EGHOKPEJMGD)
		{
			float num4 = PKHHKJLGHFM.relativeSize.x * PKHHKJLGHFM.transform.localScale.x;
			num2 += PKHHKJLGHFM.transform.localPosition.x + num4 + 1338f + KEEEAKBKLAF.transform.localScale.x / 801f;
			KEEEAKBKLAF.transform.localPosition = KEEEAKBKLAF.transform.localPosition.ReplaceX(num2);
		}
	}

	private void HGEGKGHNDFA(GameObject KHAHPAKDIKE)
	{
		ChatAbuseDialog.ShowAbuseDialog(FEIEGFFHJOG.EJBEDLHIKDG, FEIEGFFHJOG.PNAKMCNGGHE);
	}

	private void NBAKFPJHNPB()
	{
		int num = ((!DIDEFBEIFJD.gameObject.activeSelf) ? (-172) : 65);
		int num2 = 186;
		int num3 = num + num2;
		float x = PKHHKJLGHFM.relativeSize.x;
		float x2 = BMIFLAPKPJD.relativeSize.x;
		float gLIDDLHPAKL = Mathf.Clamp((float)num3 / (x + x2), 79f, 1628f);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, gLIDDLHPAKL, 382f, num3);
		MEJMLNDFDBP.COCBCFKJOJE(BMIFLAPKPJD, gLIDDLHPAKL, 1147f, num3);
	}

	private void HCBFAPLECKJ()
	{
		int num = ((!DIDEFBEIFJD.gameObject.activeSelf) ? 290 : 250);
		int num2 = 320;
		int num3 = num + num2;
		float x = PKHHKJLGHFM.relativeSize.x;
		float x2 = BMIFLAPKPJD.relativeSize.x;
		float gLIDDLHPAKL = Mathf.Clamp((float)num3 / (x + x2), 20f, 33f);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, gLIDDLHPAKL, 20f, num3);
		MEJMLNDFDBP.COCBCFKJOJE(BMIFLAPKPJD, gLIDDLHPAKL, 20f, num3);
	}

	private void EPKNKIDFPPJ()
	{
		UITable oFKKIBAPAJP = OFKKIBAPAJP;
		oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(EPKNKIDFPPJ));
		float num = 1670f + OFKKIBAPAJP.transform.localPosition.x + OIGHLKPFPJN.transform.parent.transform.localPosition.x;
		int cEHFMMJHCKC = 124 - (int)num;
		MEJMLNDFDBP.COCBCFKJOJE(OIGHLKPFPJN, 1812f, 1162f, cEHFMMJHCKC);
		float x = OIGHLKPFPJN.relativeSize.x;
		GNHNLLOIGJB.center = new Vector3(x / 341f, 371f, 167f);
		GNHNLLOIGJB.size = new Vector3(x + 508f, 1235f, 602f);
	}

	private void IDOCILIKFEE(int NOLELDEJDDC)
	{
		FDDNPECPBEE.SetActive(value: false);
		OOJLGEIEFHM.SetActive(value: true);
		IOODGADNFEN = 60f;
		MPKHGPHLMDB.IANIKLCCOOG(NOLELDEJDDC);
	}

	public void CBLAPPHFDLB(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		FEIEGFFHJOG = NDPMDKGJAFH;
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HHNNIBKKBMN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HMIAGBLEHIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FLIKKJFNKAB));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FLIKKJFNKAB));
		UIEventListener uIEventListener5 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CEKMPGANBHB));
		UIEventListener uIEventListener6 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(LKBJENDLPIA));
		UIEventListener uIEventListener7 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener7.onClick, new UIEventListener.VoidDelegate(DBJIGICHNFD));
		UIEventListener uIEventListener8 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(DBJIGICHNFD));
		KDABKEGLDEE.gameObject.SetActive(!string.IsNullOrEmpty(NDPMDKGJAFH.CGIFEHPDBAL) && !NDPMDKGJAFH.KBGHBHFOHFD);
		bool flag = NDPMDKGJAFH.EJBEDLHIKDG == GameLoginManager.currentPlayer.id;
		MGFHDOBIGDL.gameObject.SetActive(!flag && NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			KBBANKLHHEA(NDPMDKGJAFH.KBJEOEEOEFG);
			return;
		}
		HDPKJCEGLGL(NDPMDKGJAFH.MHPNDNJDPGE, NDPMDKGJAFH.BCCDDJMPBLL, NDPMDKGJAFH.FHCMFHABMLE, NDPMDKGJAFH.EGHOKPEJMGD);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			if (NDPMDKGJAFH.KBGHBHFOHFD)
			{
				EIDAFINJHBC(NDPMDKGJAFH.MNGGEHIAAEC, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
			else
			{
				GKAPAJJEAFM(NDPMDKGJAFH.CGIFEHPDBAL, NDPMDKGJAFH.GEAGOKJMJFD, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
		}
		else
		{
			IJDKENMPLIM(NDPMDKGJAFH.NBKCKIELMLK, NDPMDKGJAFH.EHLJCGEFAOL, NDPMDKGJAFH.LIAFEPFJAKM);
			NDPMDKGJAFH.OJIANBAINDD.HDMCKAMIMGM(IDEBKDPMPGM: false);
		}
	}

	public void PLJJDOGILDG(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		FEIEGFFHJOG = NDPMDKGJAFH;
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HHNNIBKKBMN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HMIAGBLEHIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HIIPDHAJKCM));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FLIKKJFNKAB));
		UIEventListener uIEventListener5 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HFEJKNLCIKO));
		UIEventListener uIEventListener6 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(DBANMAMHIPO));
		UIEventListener uIEventListener7 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener7.onClick, new UIEventListener.VoidDelegate(LLEAICGKPOL));
		UIEventListener uIEventListener8 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(DIJKOOHDIHI));
		KDABKEGLDEE.gameObject.SetActive(string.IsNullOrEmpty(NDPMDKGJAFH.CGIFEHPDBAL) || NDPMDKGJAFH.KBGHBHFOHFD);
		bool flag = NDPMDKGJAFH.EJBEDLHIKDG == GameLoginManager.currentPlayer.id;
		MGFHDOBIGDL.gameObject.SetActive(flag || NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			EMMALDNIJNH(NDPMDKGJAFH.KBJEOEEOEFG);
			return;
		}
		OOBJIMJADJB(NDPMDKGJAFH.MHPNDNJDPGE, NDPMDKGJAFH.BCCDDJMPBLL, NDPMDKGJAFH.FHCMFHABMLE, NDPMDKGJAFH.EGHOKPEJMGD);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			if (NDPMDKGJAFH.KBGHBHFOHFD)
			{
				GHOGGLIMLOC(NDPMDKGJAFH.MNGGEHIAAEC, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
			else
			{
				OPNGPDBPICC(NDPMDKGJAFH.CGIFEHPDBAL, NDPMDKGJAFH.GEAGOKJMJFD, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
		}
		else
		{
			FAOCNFNIADB(NDPMDKGJAFH.NBKCKIELMLK, NDPMDKGJAFH.EHLJCGEFAOL, NDPMDKGJAFH.LIAFEPFJAKM);
			NDPMDKGJAFH.OJIANBAINDD.ACCCCDEAFPP(IDEBKDPMPGM: false);
		}
	}

	private void ABNJOICKKDI(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: false);
		NLMJJFKDHCM.SetActive(value: false);
		FNDAHHEOEFF.SetActive(value: false);
		CGIFEHPDBAL.transform.localPosition = new Vector3(636f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 1449f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 716f, 43f, -30);
		bool flag = string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 1656f : 1961f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_INMASTER1" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1910f);
		}
		bool active = !ILFPEILKAPF && BMNDININJCE == League.NoLeague;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		JBADFANJJJP(GNNLFNKNMEF: true, KMIGLGHPFCC: false);
	}

	private void FHMGBCHBACN(string MIDDFOCJJOP, string LOKHAAIPCDD, bool ILFPEILKAPF, int HNEFOLPHMHK, League BMNDININJCE, string PNAKMCNGGHE, bool PLEGONBAPBA)
	{
		CIFLFDMACKG.SetActive(value: true);
		NLMJJFKDHCM.SetActive(value: true);
		FNDAHHEOEFF.SetActive(value: true);
		CGIFEHPDBAL.transform.localPosition = new Vector3(103f, CGIFEHPDBAL.transform.localPosition.y, CGIFEHPDBAL.transform.localPosition.z);
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 761f, Color.white);
		CGIFEHPDBAL.text = MIDDFOCJJOP;
		MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1788f, 336f, 84);
		bool flag = string.IsNullOrEmpty(LOKHAAIPCDD);
		MNNMIAAEBAF.alpha = ((!flag) ? 593f : 653f);
		if (flag)
		{
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Mission Event card not found! ({0})" + LOKHAAIPCDD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(145f);
		}
		bool active = !ILFPEILKAPF && BMNDININJCE != League.Bronze3;
		NNMCKEECNFK.gameObject.SetActive(active);
		if (ILFPEILKAPF)
		{
			NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(HNEFOLPHMHK);
			NNMCKEECNFK.MakePixelPerfect();
		}
		else if (BMNDININJCE != League.NoLeague)
		{
			NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
			NNMCKEECNFK.MakePixelPerfect();
		}
		HFGGJAMNONM.text = PNAKMCNGGHE;
		KMFGCJEGJJK.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		KLGIFDAJCJD.color = ((!PLEGONBAPBA) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		ENGLECAPONH(GNNLFNKNMEF: false, KMIGLGHPFCC: false);
	}

	public void DAEHLLDNGLF()
	{
		FDDNPECPBEE.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: false);
		IOODGADNFEN = 263f;
	}

	private void PFLGEBMKMEK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG);
		}
	}

	private void JJFGIGMIIAC(GameObject KHAHPAKDIKE)
	{
		ChatAbuseDialog.LEAIHNFLBBH(FEIEGFFHJOG.EJBEDLHIKDG, FEIEGFFHJOG.PNAKMCNGGHE);
	}

	private void MPLBLOHJPNC()
	{
		int num = ((!DIDEFBEIFJD.gameObject.activeSelf) ? 112 : (-93));
		int num2 = 75;
		int num3 = num + num2;
		float x = PKHHKJLGHFM.relativeSize.x;
		float x2 = BMIFLAPKPJD.relativeSize.x;
		float gLIDDLHPAKL = Mathf.Clamp((float)num3 / (x + x2), 1840f, 1405f);
		MEJMLNDFDBP.COCBCFKJOJE(PKHHKJLGHFM, gLIDDLHPAKL, 883f, num3);
		MEJMLNDFDBP.COCBCFKJOJE(BMIFLAPKPJD, gLIDDLHPAKL, 442f, num3);
	}

	public void FGJKNGHNLEN(Chat.PBGFEDGFOPG NDPMDKGJAFH)
	{
		FEIEGFFHJOG = NDPMDKGJAFH;
		UIEventListener uIEventListener = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NIEALIKBELG));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NEEPBGKJACK));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FLIKKJFNKAB));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDABKEGLDEE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HIIPDHAJKCM));
		UIEventListener uIEventListener5 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LKBJENDLPIA));
		UIEventListener uIEventListener6 = UIEventListener.Get(MGFHDOBIGDL.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(HGEGKGHNDFA));
		UIEventListener uIEventListener7 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener7.onClick, new UIEventListener.VoidDelegate(DIJKOOHDIHI));
		UIEventListener uIEventListener8 = UIEventListener.Get(GNHNLLOIGJB.gameObject);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(IEGGJHEJBHF));
		KDABKEGLDEE.gameObject.SetActive(!string.IsNullOrEmpty(NDPMDKGJAFH.CGIFEHPDBAL) && NDPMDKGJAFH.KBGHBHFOHFD);
		bool flag = NDPMDKGJAFH.EJBEDLHIKDG == GameLoginManager.currentPlayer.id;
		MGFHDOBIGDL.gameObject.SetActive(!flag && NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Timer)
		{
			KBBANKLHHEA(NDPMDKGJAFH.KBJEOEEOEFG);
			return;
		}
		PKOOFKFHHKN(NDPMDKGJAFH.MHPNDNJDPGE, NDPMDKGJAFH.BCCDDJMPBLL, NDPMDKGJAFH.FHCMFHABMLE, NDPMDKGJAFH.EGHOKPEJMGD);
		if (NDPMDKGJAFH.FOJAKFBCBPI == Chat.JMMPILGNALE.Message)
		{
			if (NDPMDKGJAFH.KBGHBHFOHFD)
			{
				OBDNNCMDLEG(NDPMDKGJAFH.MNGGEHIAAEC, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
			else
			{
				IMOMOJHBDCL(NDPMDKGJAFH.CGIFEHPDBAL, NDPMDKGJAFH.GEAGOKJMJFD, NDPMDKGJAFH.DHPLNAIKHOC, NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.PNAKMCNGGHE, flag);
			}
		}
		else
		{
			CGHBKMJKJNN(NDPMDKGJAFH.NBKCKIELMLK, NDPMDKGJAFH.EHLJCGEFAOL, NDPMDKGJAFH.LIAFEPFJAKM);
			NDPMDKGJAFH.OJIANBAINDD.KINBBAFNJPG(IDEBKDPMPGM: true);
		}
	}

	private void HECEDDEEPCI()
	{
		UITable dLFDGNMAMGD = DLFDGNMAMGD;
		dLFDGNMAMGD.onReposition = (UITable.OnReposition)Delegate.Remove(dLFDGNMAMGD.onReposition, new UITable.OnReposition(PAJOLKNBDOD));
		if (OFKKIBAPAJP.gameObject.activeSelf)
		{
			UITable oFKKIBAPAJP = OFKKIBAPAJP;
			oFKKIBAPAJP.onReposition = (UITable.OnReposition)Delegate.Remove(oFKKIBAPAJP.onReposition, new UITable.OnReposition(NKCGGCINPPL));
			UITable oFKKIBAPAJP2 = OFKKIBAPAJP;
			oFKKIBAPAJP2.onReposition = (UITable.OnReposition)Delegate.Combine(oFKKIBAPAJP2.onReposition, new UITable.OnReposition(EPKNKIDFPPJ));
			OFKKIBAPAJP.repositionNow = true;
		}
	}

	private void EKBODBGNKBN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(FEIEGFFHJOG.MHPNDNJDPGE))
		{
			TweenColor tweenColor = TweenColor.Begin(PKHHKJLGHFM.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(FEIEGFFHJOG.MHPNDNJDPGE, FEIEGFFHJOG.EJBEDLHIKDG, BNNKPKDPLPP: false);
		}
	}

	private void DIJKOOHDIHI(GameObject KHAHPAKDIKE)
	{
		if (FEIEGFFHJOG.LIAFEPFJAKM != null && !string.IsNullOrEmpty(FEIEGFFHJOG.LIAFEPFJAKM.name))
		{
			TweenColor tweenColor = TweenColor.Begin(OIGHLKPFPJN.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(FEIEGFFHJOG.LIAFEPFJAKM.name, FEIEGFFHJOG.LIAFEPFJAKM.id);
		}
	}

	private void MBCNGICFDED(GameObject KHAHPAKDIKE)
	{
		if (FEIEGFFHJOG.LIAFEPFJAKM != null && !string.IsNullOrEmpty(FEIEGFFHJOG.LIAFEPFJAKM.name))
		{
			TweenColor tweenColor = TweenColor.Begin(OIGHLKPFPJN.gameObject, GameVariables.KDELCJIAIHM, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(FEIEGFFHJOG.LIAFEPFJAKM.name, FEIEGFFHJOG.LIAFEPFJAKM.id);
		}
	}

	private void HIIPDHAJKCM(GameObject KHAHPAKDIKE)
	{
		TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 8;
		tweenColor.style = (UITweener.Style)8;
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(FEIEGFFHJOG.CGIFEHPDBAL);
	}
}
