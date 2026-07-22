using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLeagueRecord : PoolableObject
{
	[Header("Core")]
	[FormerlySerializedAs("JPFBMMCKKCO")]
	public UIButtonSetter BMNBNDILFJD;

	[Header("Header Part")]
	[FormerlySerializedAs("JMCDNFGEIEE")]
	public GameObject OOIBADLGKML;

	[FormerlySerializedAs("MADEDKKBOIH")]
	public UISprite GJIGEFJAKNM;

	[FormerlySerializedAs("DFILNCGPJBM")]
	public UISprite MIEEGOCCPGB;

	[FormerlySerializedAs("EHFHOFOIBNI")]
	public UITable LHKLOFBMPGN;

	[FormerlySerializedAs("OFKPAHMOCJO")]
	public UISprite EIDJHKHJBII;

	[FormerlySerializedAs("LANOCMFLKIO")]
	public UILabel FCFPODPEHBO;

	[FormerlySerializedAs("GDDJFJDHBOE")]
	[Header("Reward Part")]
	public GameObject DOCLOEBEGIL;

	[FormerlySerializedAs("HNEIAJLJPCM")]
	public UILabel DGOGCOAKAIL;

	[FormerlySerializedAs("OBEELIOMGFN")]
	[Header("No Reward Part")]
	public GameObject HDPDBOELPLF;

	[FormerlySerializedAs("CMAJKBAGHDN")]
	[Header("Player Part")]
	public GameObject IGJMJNHFCAI;

	[FormerlySerializedAs("IPPEOBDNMCE")]
	public UISprite JDOOPPMKEFO;

	[FormerlySerializedAs("FIDILIADIEL")]
	public UISprite LCPBNBLGFIA;

	[FormerlySerializedAs("MPHCJEIMBEB")]
	[Header("-Info Left")]
	public UILabel MPHCNMDIPAI;

	[FormerlySerializedAs("IEOFMGIJBCH")]
	public PlayerIcon CPGACIMMFEC;

	[FormerlySerializedAs("OPAIBCEMCPH")]
	public GameObject OANICEALFGM;

	[FormerlySerializedAs("PILKNDHIBFL")]
	public UISprite OOECKDBCHKL;

	[FormerlySerializedAs("FCJDJLCLFDL")]
	public UISprite PMIAEHHNNAD;

	[FormerlySerializedAs("AIJEHNJKFAE")]
	public UILabel IEJAOPGCIJC;

	[FormerlySerializedAs("EALPGIAENNM")]
	public UITable HKGAHCEJLIL;

	[FormerlySerializedAs("KBJPGNFNAAA")]
	public UILabel BCMCMKDCLGP;

	[FormerlySerializedAs("FPBGHOAGEPD")]
	public GameObject JHKNOIJBDGA;

	[FormerlySerializedAs("MDBAJODDCGF")]
	public UISprite NPECJCIKCBI;

	[FormerlySerializedAs("NPJHKDBDGAG")]
	public GameObject BJCMNMGCGNN;

	[FormerlySerializedAs("JKMFPJNPLGN")]
	public GameObject CPLIMCNBDBP;

	[FormerlySerializedAs("FMEOJDFFCHN")]
	public UILabel IJFCFCGIKHK;

	[FormerlySerializedAs("GIOBECHOAAE")]
	public GameObject KDABKEGLDEE;

	[Header("-Info Right")]
	[FormerlySerializedAs("MLAEAOBNLAO")]
	public UILabel AMFJHAPGIJN;

	[FormerlySerializedAs("PPOGMNOLMHE")]
	public UILabel KCMDAFLFAGB;

	private DatabasePlayer MBIAKMPDOPG;

	public void AFEDNJFMGEO(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.BHEBNFNJMJA(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Header) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - 84 + 115;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 42f : 1032f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ABAKFENMJLH(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.Reset();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(OPOHEGOIEDP);
			Singleton<PlayerTexturePool>.instance.BCGAIKBHILI(GKLDDBGAFHP);
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.IEDGPHEPJEK(MBIAKMPDOPG.country);
			bool flag2 = string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.CDLBEKECJNK();
			IEJAOPGCIJC.text = levelDefinition.DLCFFHEKBAA();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Online;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= -78;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown == WarArenaCrown.None;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num--;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(1376f / NPECJCIKCBI.transform.localScale.x, 1328f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1586f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 682f, 310f, num);
			HKGAHCEJLIL.repositionNow = false;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ALONJIBEEKJ));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EMGBNOMPAIC));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 788f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CPKAHGCGLKI));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OKILKCDNIAF));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(KHKMKPLKAEK));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderReward)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					FCFPODPEHBO.text = ((!flag5) ? (stringGreenLeague + Localization.Localize("ID_GUI_DELIVERING")) : Localization.LocalizeFormat("OtherCards", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), stringGreenLeague, null, null));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					object[] array = new object[8];
					array[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array[0] = Colours.stringGreenLeague;
					array[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO.text = Localization.LocalizeFormat("ID_ARENARULES_SHIELDSDONTRESPAWN", array);
				}
				else
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[3];
					array2[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array2[0] = Colours.stringGreenLeague;
					array2[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("FuseBox Event Level Up for level {0}", array2);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)5)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					FCFPODPEHBO.text = ((!flag6) ? (stringYellowLeague + Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT")) : Localization.LocalizeFormat("50", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), stringYellowLeague, null, null, null, null, null, null));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("mUsedDogtagsLocaly", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), Colours.stringGreenLeague, null, null, null, null, null);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("Card_2_Played", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1), Colours.stringGreenLeague, null, null, null, null);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[5];
					array3[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array3[0] = Colours.stringRedLeague;
					array3[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("VisualTimestamp", array3);
				}
				else
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[6];
					array4[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array4[0] = Colours.stringRedLeague;
					array4[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("VipReward1", array4);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[0];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array5[1] = Colours.stringYellowLeague;
					array5[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("Yes_Clicked", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[4];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array6[0] = Colours.stringYellowLeague;
					array6[3] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("ID_BRONZEPACKS", array6);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = delegate
			{
				float num2 = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
				LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num2 - 40f);
			};
		}
	}

	private void LFGJMGCDKNM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("ID_SIGNIN"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void POLOPBEOOCB(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.OLJPGNNKCKI(FCEIGDLFOMH);
			CPGACIMMFEC.ECAFLDEFKKB();
		}
	}

	public void PAKLIFNHMAI(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.EGNOJHEGNCC(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)4);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Header) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -83 + -81;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1703f : 230f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.LeagueColorPosition(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LCHKCBLMOND(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.OOOLABBEKDF();
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(BKLCDOHFKCG);
			Singleton<PlayerTexturePool>.instance.CNCEGIEPCIB(BKLCDOHFKCG);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, PNDNEMDPFHC: false);
			string text = GameVariables.CountryCodeSpriteName(MBIAKMPDOPG.country);
			bool flag2 = string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.LMNDFNIKIFI();
			IEJAOPGCIJC.text = levelDefinition.FDACEOHEGPN();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= -33;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.BronzeCrown;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= 67;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(999f / NPECJCIKCBI.transform.localScale.x, 742f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1797f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 513f, 1519f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FHOHNJICDNK));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 1408f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EOANAEAIIDI));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FPNPPGMMIOD));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)7)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[4];
						array[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array[0] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("OK", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("ID_TUTORIAL_GO_TO_ARMORY_6");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[6];
					array2[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array2[1] = Colours.stringGreenLeague;
					array2[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("grenadeExplosion", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[6];
					array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array3[0] = Colours.stringGreenLeague;
					array3[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("Beanstalk: Internet Offline while checking connection: ", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)6)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					FCFPODPEHBO.text = ((!flag6) ? (stringYellowLeague + Localization.Localize("{0}%")) : Localization.LocalizeFormat("-ELITEPARTS", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), stringYellowLeague, null, null, null, null));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[0];
					array4[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array4[1] = Colours.stringGreenLeague;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("ID_ERROR_SQUADSKILLNOTANUMBER", array4);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("end", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0), Colours.stringGreenLeague, null);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)8)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[1];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array5[1] = Colours.stringRedLeague;
					array5[8] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("height", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[5];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array6[1] = Colours.stringRedLeague;
					array6[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("WARBUCKS PREFIX = ", array6);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[1];
					array7[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array7[1] = Colours.stringYellowLeague;
					array7[0] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("Yes_Clicked", array7);
				}
				else
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[0];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array8[0] = Colours.stringYellowLeague;
					array8[3] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("In App Delivered", array8);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = PJJJGFDJCEC;
		}
	}

	public void BANIBDDJPCE()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	public void KJJNHHJNALE(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.EGNOJHEGNCC(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)7);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Header) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - 61 + 54;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1202f : 818f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ABAKFENMJLH(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.KOKJMKHECGK();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= BKLCDOHFKCG;
			Singleton<PlayerTexturePool>.instance.IANAHBGPJLN(ACNDHPFJAPF);
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG);
			string text = GameVariables.IDOFIHFGOKD(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.CDLBEKECJNK();
			IEJAOPGCIJC.text = levelDefinition.IEFOIJAFOJC();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() == PlayerStatus.Online;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= 7;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown == WarArenaCrown.BronzeCrown;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= -6;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(579f / NPECJCIKCBI.transform.localScale.x, 603f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1442f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 232f, 1728f, num);
			HKGAHCEJLIL.repositionNow = false;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHDMAFHOBGB));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ALONJIBEEKJ));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 401f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FDPODMEBAKC));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(BKAKMDBGPAP));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)4)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					FCFPODPEHBO.text = ((!flag5) ? (stringGreenLeague + Localization.Localize("ID_MINUTE")) : Localization.LocalizeFormat("ShootStand", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), stringGreenLeague, null, null, null, null, null));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					object[] array = new object[6];
					array[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array[1] = Colours.stringGreenLeague;
					array[3] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO.text = Localization.LocalizeFormat("201 LOADING MAP", array);
				}
				else
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[5];
					array2[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array2[0] = Colours.stringGreenLeague;
					array2[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("S", array2);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					FCFPODPEHBO.text = ((!flag6) ? (stringYellowLeague + Localization.Localize("menu-army-ammo-ico")) : Localization.LocalizeFormat("{0} {1}", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), stringYellowLeague, null, null));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[6];
					array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array3[0] = Colours.stringGreenLeague;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("Rank", array3);
				}
				else
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[8];
					array4[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array4[0] = Colours.stringGreenLeague;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("_Color", array4);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)5)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_MEMBERSHIP_PRICEPERMONTH", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), Colours.stringRedLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1, null, null, null, null, null);
				}
				else
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[7];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array5[0] = Colours.stringRedLeague;
					array5[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("blockingConnect", array5);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[5];
					array6[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array6[1] = Colours.stringYellowLeague;
					array6[8] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("#AccoutCheck# Facebook account found during account loading!!! - TODO!", array6);
				}
				else
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[3];
					array7[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array7[0] = Colours.stringYellowLeague;
					array7[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("PrepareBotForDeathMatch 5", array7);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.KFHAGEFAADA(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = GDMEGJADFJI;
		}
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

	private void BKAKMDBGPAP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("Mobile/Diffuse"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	public void NKNHOGOIBON()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	private void NAEFOLMDNOP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JIBFCGECCFI(FCEIGDLFOMH);
			CPGACIMMFEC.DGPJIJBHBJC();
		}
	}

	public void InitializeRecord(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.SetWidth(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderReward);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderNoReward);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Player) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - 812 + 41;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 0f : 1f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.LeagueColorPosition(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.Reset();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG);
			string text = GameVariables.CountryCodeSpriteName(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.iconName;
			IEJAOPGCIJC.text = levelDefinition.displayString;
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= 41;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.None;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= 40;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(30f / NPECJCIKCBI.transform.localScale.x, 40f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 0f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 37f, 20f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 0f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderReward)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderNoReward)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					FCFPODPEHBO.text = ((!flag5) ? (stringGreenLeague + Localization.Localize("ID_LEAGUETOPPOSITIONHINT")) : Localization.LocalizeFormat("ID_LEAGUEPROMOTEHINT", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), stringGreenLeague));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT1", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringGreenLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT2", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1), Colours.stringGreenLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Top)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					FCFPODPEHBO.text = ((!flag6) ? (stringYellowLeague + Localization.Localize("ID_LEAGUETOPPOSITIONHINT")) : Localization.LocalizeFormat("ID_LEAGUEPROMOTEHINT", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), stringYellowLeague));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_LEAGUEREWARDHINT1", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringGreenLeague);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_LEAGUEREWARDHINT2", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1), Colours.stringGreenLeague);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Demote)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_LEAGUEDEMOTEHINT1", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringRedLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_LEAGUEDEMOTEHINT2", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1), Colours.stringRedLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT1", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringYellowLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT2", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1), Colours.stringYellowLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = delegate
			{
				float num2 = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
				LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num2 - 40f);
			};
		}
	}

	private void DPOBELPOFEL(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.EIKJEGHELNK(FCEIGDLFOMH);
			CPGACIMMFEC.BFKPPMIKNAA();
		}
	}

	public virtual void EJDOMPDOCKD()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EOANAEAIIDI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NEGBHMIKNLL));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(AHLDPEGMIJI);
		BKEEMHGOOFH();
	}

	public void NILIFMDMJAF(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.EGNOJHEGNCC(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderNoReward);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Header) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -176 + 74;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 715f : 103f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ECGGKMIKKMI(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.OMDFNFHKFBK();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(IHIILICAFGF);
			Singleton<PlayerTexturePool>.instance.BCGAIKBHILI(FCNKIEPEAAG);
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.IEDGPHEPJEK(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.NOHAFIDFPCM();
			IEJAOPGCIJC.text = levelDefinition.IEFOIJAFOJC();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= 73;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.BronzeCrown;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= 25;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(1429f / NPECJCIKCBI.transform.localScale.x, 1231f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 283f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1417f, 1859f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHDMAFHOBGB));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AHJDKCHOGLH));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 738f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GJEIDAOPAPN));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BDMCLOCBDOH));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OMLDMNIGKCC));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(FDPODMEBAKC));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)4)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[2];
						array[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
						array[1] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("ID_ARENARULES_SLOWERDEPLOYMENT", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("getStatusCode");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("PlayerName", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringGreenLeague, null, null, null, null, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1, null);
				}
				else
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[3];
					array2[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array2[0] = Colours.stringGreenLeague;
					array2[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("MaintenanceMessage", array2);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Top)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					string text3;
					if (flag6)
					{
						object[] array3 = new object[1];
						array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
						array3[0] = stringYellowLeague;
						text3 = Localization.LocalizeFormat(", account type = ", array3);
					}
					else
					{
						text3 = stringYellowLeague + Localization.Localize("ID_ARENARARITY");
					}
					fCFPODPEHBO3.text = text3;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("videoAdRewardTimes", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), Colours.stringGreenLeague, null, null, null, null, null);
				}
				else
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[3];
					array4[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array4[0] = Colours.stringGreenLeague;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("[Crashlytics Init] CrashlyticsService->Ctor->Initialize->Before", array4);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)8)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[7];
					array5[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array5[1] = Colours.stringRedLeague;
					array5[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("WelcomeBackSoldierMessage {0} {1}", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[4];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array6[1] = Colours.stringRedLeague;
					array6[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("ID_CONFIRM_LEAVESQUADLEADER_TEXT", array6);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[8];
					array7[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array7[1] = Colours.stringYellowLeague;
					array7[8] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("country-italy", array7);
				}
				else
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[8];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array8[1] = Colours.stringYellowLeague;
					array8[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("RemovedCards", array8);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = KJLPFKPLKKI;
		}
	}

	public void GLLJAEOMMOH(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.GPNONALLJKA(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)6);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Player) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - 40 + -101;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1718f : 906f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.LeagueColorPosition(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LCHKCBLMOND(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= NDKDIBBOEFC;
			Singleton<PlayerTexturePool>.instance.AFAHCJBIHIP(BKLCDOHFKCG);
			Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(MBIAKMPDOPG, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.CountryCodeSpriteName(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.CDLBEKECJNK();
			IEJAOPGCIJC.text = levelDefinition.FDACEOHEGPN();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() == PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= -66;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.BronzeCrown;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= 19;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(358f / NPECJCIKCBI.transform.localScale.x, 1313f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1194f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1844f, 1863f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AHJDKCHOGLH));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ALONJIBEEKJ));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 1953f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CPKAHGCGLKI));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MJBDHNLJLJD));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OKILKCDNIAF));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(FEOLMIBGICF));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)4)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[5];
						array[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array[0] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("ID_TUTORIAL_BIG_REVEAL_UP", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("writeToParcel");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_REMINDER_THISAMAZINGCUSTOMIZATION", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), Colours.stringGreenLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1, null, null, null);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("rental for unexist weapon: {0}", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0), Colours.stringGreenLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1, null, null, null);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)8)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					string text3;
					if (flag6)
					{
						object[] array2 = new object[2];
						array2[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array2[0] = stringYellowLeague;
						text3 = Localization.LocalizeFormat("IsHitList", array2);
					}
					else
					{
						text3 = stringYellowLeague + Localization.Localize(" ");
					}
					fCFPODPEHBO2.text = text3;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("Gold", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringGreenLeague, null, null, null, null);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("{0}{1}", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1), Colours.stringGreenLeague, null, null, null, null, null, null);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[1];
					array3[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array3[0] = Colours.stringRedLeague;
					array3[0] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("{0}{1}{2} {3}{4}", array3);
				}
				else
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[3];
					array4[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array4[1] = Colours.stringRedLeague;
					array4[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("Shots_Hits", array4);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("Player_Avoided_Grenade_On_First_Try", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringYellowLeague, null, null, null, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1, null, null);
				}
				else
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[2];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array5[0] = Colours.stringYellowLeague;
					array5[7] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("{0}{1}", array5);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = false;
			LHKLOFBMPGN.onReposition = HEDJDLGGKLN;
		}
	}

	private void OKILKCDNIAF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("Medals"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void JDGFPLEHBOK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(IJFCFCGIKHK.text);
		}
	}

	private void KJLPFKPLKKI()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 406f);
	}

	private void FCNKIEPEAAG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.avatar = FCEIGDLFOMH;
			CPGACIMMFEC.UpdateIcon();
		}
	}

	public virtual void GICLKACEHJH()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GJEIDAOPAPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKAKMDBGPAP));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(AHLDPEGMIJI);
		KBDHEFHLAKN();
	}

	private void OPKFOOGDOGL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("registerPowerHook"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	public virtual void ONHFNIJNMGE()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FPNPPGMMIOD));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KHKMKPLKAEK));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HJKKFAOJLFA));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		KPANCIFIOFC();
	}

	private void IKLALPFPIFH()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 205f);
	}

	public void FGFKCHGHBCA(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.DKHLKOFJKPL(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Player) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - 123 + -16;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1236f : 825f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.LeagueColorPosition(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.OMDFNFHKFBK();
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(FKBDHIJGMMM);
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.BFGCBNLOIMN(MBIAKMPDOPG.country);
			bool flag2 = string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.EGNEDNBPOEF();
			IEJAOPGCIJC.text = levelDefinition.KAKFPJPKHHB();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= -68;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.BronzeCrown;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= -49;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(287f / NPECJCIKCBI.transform.localScale.x, 392f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1750f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 705f, 318f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HJKKFAOJLFA));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LDAFDHAGFHI));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 1543f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EPGJJBPBCFP));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OMLDMNIGKCC));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(OMLDMNIGKCC));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[4];
						array[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array[1] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("OK", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("\tTime since last show: {0}");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("RecieveSkillshot", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), Colours.stringGreenLeague, null, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1, null);
				}
				else
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[7];
					array2[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array2[1] = Colours.stringGreenLeague;
					array2[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat(", dictionary= ", array2);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)4)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					string text3;
					if (flag6)
					{
						object[] array3 = new object[1];
						array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array3[1] = stringYellowLeague;
						text3 = Localization.LocalizeFormat("ID_INBRONZE1", array3);
					}
					else
					{
						text3 = stringYellowLeague + Localization.Localize("Skipping note with message ");
					}
					fCFPODPEHBO3.text = text3;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[1];
					array4[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array4[0] = Colours.stringGreenLeague;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("ID_WATCHVIDEO", array4);
				}
				else
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[1];
					array5[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array5[1] = Colours.stringGreenLeague;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("ID_GUI_SQUADPROMOTETEXT", array5);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTION_GOLD", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), Colours.stringRedLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1, null, null, null);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[0];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array6[0] = Colours.stringRedLeague;
					array6[0] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("ID_MIN", array6);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("gold", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), Colours.stringYellowLeague, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1);
				}
				else
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[4];
					array7[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array7[1] = Colours.stringYellowLeague;
					array7[2] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("ID_WARNING_CONNECTIONERROR", array7);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = IPJODOKMDIB;
		}
	}

	private void EPGJJBPBCFP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("setCustomProfileNumber"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	public void DNLMHBKDMBF()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.MDANAEPCCHK(MBIAKMPDOPG.id, PNDNEMDPFHC: false);
			MBIAKMPDOPG = null;
		}
	}

	public void GKGEPBHCKML(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.SetWidth(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderNoReward);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)7);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Header) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - 48 + -98;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 378f : 570f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.LeagueColorPosition(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.KHMNEOBMJLN();
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(POLOPBEOOCB);
			Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(IKMENCFOELC);
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG, PNDNEMDPFHC: false);
			string text = GameVariables.BFGCBNLOIMN(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.LMNDFNIKIFI();
			IEJAOPGCIJC.text = levelDefinition.FDACEOHEGPN();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Online;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= -9;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.None;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= -91;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(755f / NPECJCIKCBI.transform.localScale.x, 704f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 571f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 115f, 424f, num);
			HKGAHCEJLIL.repositionNow = false;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHDMAFHOBGB));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EKGILINPPGE));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 539f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MJBDHNLJLJD));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BDMCLOCBDOH));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PPJEJBPNEDF));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(FEOLMIBGICF));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)4)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[7];
						array[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array[0] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("NEW RENTAL ", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("ID_CONFIRM_LOGGEDOUT_TEXT");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[2];
					array2[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array2[1] = Colours.stringGreenLeague;
					array2[7] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("Shown_Before_Times", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[6];
					array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array3[1] = Colours.stringGreenLeague;
					array3[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("ID_IMMUNE", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					string text3;
					if (flag6)
					{
						object[] array4 = new object[3];
						array4[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array4[1] = stringYellowLeague;
						text3 = Localization.LocalizeFormat("\t", array4);
					}
					else
					{
						text3 = stringYellowLeague + Localization.Localize("WENEEDTO");
					}
					fCFPODPEHBO4.text = text3;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[6];
					array5[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array5[0] = Colours.stringGreenLeague;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("{0} {1}", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[4];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array6[0] = Colours.stringGreenLeague;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("Assignment: Destroy Crates in one battle constructor", array6);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[7];
					array7[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array7[0] = Colours.stringRedLeague;
					array7[0] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("Look vector is small! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} rotatedLookVector: {5}", array7);
				}
				else
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[8];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array8[1] = Colours.stringRedLeague;
					array8[2] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("All players already connected", array8);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO9 = FCFPODPEHBO;
					object[] array9 = new object[4];
					array9[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array9[0] = Colours.stringYellowLeague;
					array9[2] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO9.text = Localization.LocalizeFormat("Win", array9);
				}
				else
				{
					UILabel fCFPODPEHBO10 = FCFPODPEHBO;
					object[] array10 = new object[4];
					array10[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array10[0] = Colours.stringYellowLeague;
					array10[8] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO10.text = Localization.LocalizeFormat("Animation for State: Craft", array10);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = IANHNNELACJ;
		}
	}

	public virtual void NOJLGJDAMMK()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FPNPPGMMIOD));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GOOMCGDNIGH));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HJKKFAOJLFA));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(NDKDIBBOEFC);
		DNLMHBKDMBF();
	}

	private void EMGBNOMPAIC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(IJFCFCGIKHK.text);
		}
	}

	private void FKBDHIJGMMM(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.BIEIDBBDNIF(FCEIGDLFOMH);
			CPGACIMMFEC.GPHGDAKLAJK();
		}
	}

	public void OGCLHPFHIFC(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.MGDCNGGBJLA(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)4);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Player) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -183 + 89;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1007f : 1658f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.LeagueColorPosition(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LCHKCBLMOND(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.KOKJMKHECGK();
			Singleton<PlayerTexturePool>.instance.FHEJPABPCML(IKMENCFOELC);
			Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(IKMENCFOELC);
			Singleton<PlayerTexturePool>.instance.MFKFEHJBEPA(MBIAKMPDOPG, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.CountryCodeSpriteName(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.iconName;
			IEJAOPGCIJC.text = levelDefinition.LPANGEJPPOE();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Online;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= 53;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown == WarArenaCrown.BronzeCrown;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= -37;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(1125f / NPECJCIKCBI.transform.localScale.x, 163f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 501f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1878f, 484f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HINLODPDDDP));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MHDMAFHOBGB));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 250f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JLMBIBBOMPA));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NHIEGEGDHAE));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)6)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[8];
						array[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
						array[0] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("Gold", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("若沒有下載這些額外資料，《WarFriends》就無法運作。確定想要退出，還是想要下載資料呢？");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[0];
					array2[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array2[0] = Colours.stringGreenLeague;
					array2[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("can not find currency for: ", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[3];
					array3[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array3[0] = Colours.stringGreenLeague;
					array3[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("FuseSDK: Error parsing hashtable in RegisterEvent. Operation failed.", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					FCFPODPEHBO.text = ((!flag6) ? (stringYellowLeague + Localization.Localize("getCurrentAccountName")) : Localization.LocalizeFormat("menu-warbucks", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), stringYellowLeague, null, null));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[5];
					array4[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array4[0] = Colours.stringGreenLeague;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("GoldExpCoefficient", array4);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("writeToParcel", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0), Colours.stringGreenLeague, null);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)8)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[1];
					array5[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array5[0] = Colours.stringRedLeague;
					array5[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("D5", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[5];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array6[1] = Colours.stringRedLeague;
					array6[7] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("StartCameraAnimationFinishedRPC", array6);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[1];
					array7[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array7[1] = Colours.stringYellowLeague;
					array7[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.", array7);
				}
				else
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[4];
					array8[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array8[1] = Colours.stringYellowLeague;
					array8[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("Tier", array8);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.KFHAGEFAADA(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = false;
			LHKLOFBMPGN.onReposition = delegate
			{
				float num2 = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
				LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num2 - 40f);
			};
		}
	}

	private void DPFAEAFIGDG()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 1307f);
	}

	private void NEGBHMIKNLL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(IJFCFCGIKHK.text);
		}
	}

	public void LPLLENADJFN(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.GPNONALLJKA(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)6);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Player) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - 113 + 99;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 4f : 395f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ABAKFENMJLH(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(FKBDHIJGMMM);
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OPOHEGOIEDP;
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.IDOFIHFGOKD(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.iconName;
			IEJAOPGCIJC.text = levelDefinition.displayString;
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Online;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= -7;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.None;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= -24;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(1006f / NPECJCIKCBI.transform.localScale.x, 1871f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 451f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 82f, 1743f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNFENDOHJLJ));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NNFENDOHJLJ));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 1619f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BDMCLOCBDOH));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JMDFFKNIIPH));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CODNBIDNPPI));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(BKAKMDBGPAP));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)6)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[2];
						array[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array[0] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("Player_Waited_Till_Delivery_Ends", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("Visual");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[0];
					array2[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array2[1] = Colours.stringGreenLeague;
					array2[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("+{0}", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[6];
					array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array3[0] = Colours.stringGreenLeague;
					array3[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("WarArenaConfig", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)7)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					string text3;
					if (flag6)
					{
						object[] array4 = new object[6];
						array4[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array4[0] = stringYellowLeague;
						text3 = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_VIP", array4);
					}
					else
					{
						text3 = stringYellowLeague + Localization.Localize("ID_ARENAWONXWINSTEXT");
					}
					fCFPODPEHBO4.text = text3;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[2];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array5[0] = Colours.stringGreenLeague;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("game-ico-poison", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[6];
					array6[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array6[0] = Colours.stringGreenLeague;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("shotReal", array6);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[3];
					array7[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array7[0] = Colours.stringRedLeague;
					array7[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("assignmentCount", array7);
				}
				else
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[1];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array8[0] = Colours.stringRedLeague;
					array8[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("Sessions", array8);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO9 = FCFPODPEHBO;
					object[] array9 = new object[7];
					array9[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array9[0] = Colours.stringYellowLeague;
					array9[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO9.text = Localization.LocalizeFormat("1", array9);
				}
				else
				{
					UILabel fCFPODPEHBO10 = FCFPODPEHBO;
					object[] array10 = new object[8];
					array10[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array10[0] = Colours.stringYellowLeague;
					array10[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO10.text = Localization.LocalizeFormat("reloadTime", array10);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.KFHAGEFAADA(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = delegate
			{
				float num2 = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
				LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num2 - 40f);
			};
		}
	}

	private void BDMCLOCBDOH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("CA"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	[CompilerGenerated]
	private void DOIOIDDFMIK()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 40f);
	}

	public void BAAKGEANIGG()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	public void BKEEMHGOOFH()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true);
			MBIAKMPDOPG = null;
		}
	}

	private void MNFOEHIIMIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("bot"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void BKLCDOHFKCG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.GJHFCKMAMIE(FCEIGDLFOMH);
			CPGACIMMFEC.HCACKHAKDNC();
		}
	}

	public void KPANCIFIOFC()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	public void PMKFODAHHAA()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	public virtual void MBJBGBFLJCM()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JMDFFKNIIPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKAKMDBGPAP));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LDAFDHAGFHI));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(NAEFOLMDNOP);
		PCIIJHHNBBD();
	}

	private void KHKMKPLKAEK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("Tickets"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void FEOLMIBGICF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("Beanstalk: Hashed id of fb friend "))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void IPCEBCAJCDE(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(IJFCFCGIKHK.text);
		}
	}

	private void OPOHEGOIEDP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.GJHFCKMAMIE(FCEIGDLFOMH);
			CPGACIMMFEC.ECAFLDEFKKB();
		}
	}

	private void MJBDHNLJLJD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("Time_Since_Delivery_Finished"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	public virtual void EBPEFIHKEIN()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JLMBIBBOMPA));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEHDACDMLCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NNFENDOHJLJ));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(GKLDDBGAFHP);
		NKBFDKBOOAK();
	}

	private void JNLOEBEHDMK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(IJFCFCGIKHK.text);
		}
	}

	private void FDPODMEBAKC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("data"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	public void PGHAKHBDGFH()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BJFCGMCKOPO(MBIAKMPDOPG.id);
			MBIAKMPDOPG = null;
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

	private void OGGLONHKDIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("BS: On add video reward success!"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void NDKDIBBOEFC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.OLJPGNNKCKI(FCEIGDLFOMH);
			CPGACIMMFEC.HCACKHAKDNC();
		}
	}

	public void NKBFDKBOOAK()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	public void IKLOOMDCCGJ(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.DKHLKOFJKPL(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)4);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderReward);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Player) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -64 + -82;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1033f : 842f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ABAKFENMJLH(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.KFHAGEFAADA(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(OPOHEGOIEDP);
			Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(FKBDHIJGMMM);
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.IEDGPHEPJEK(MBIAKMPDOPG.country);
			bool flag2 = string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.EGNEDNBPOEF();
			IEJAOPGCIJC.text = levelDefinition.JNODDKLJOAG();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= 54;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.None;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= -13;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(606f / NPECJCIKCBI.transform.localScale.x, 1708f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1251f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 706f, 250f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HINLODPDDDP));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IPCEBCAJCDE));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 282f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GJEIDAOPAPN));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JLMBIBBOMPA));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BKAKMDBGPAP));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(CODNBIDNPPI));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)4)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[5];
						array[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
						array[0] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("ID_INGOLD1", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("QUIT");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[1];
					array2[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array2[1] = Colours.stringGreenLeague;
					array2[0] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("accepted", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[4];
					array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array3[1] = Colours.stringGreenLeague;
					array3[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("create new account and add FB", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					FCFPODPEHBO.text = ((!flag6) ? (stringYellowLeague + Localization.Localize("{0}{1}[-] {2}")) : Localization.LocalizeFormat("ID_TUTORIAL_KILLING_SCOPE_DOWN", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), stringYellowLeague));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("GameLauncher.GooglePlayInit", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringGreenLeague);
				}
				else
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[6];
					array4[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array4[0] = Colours.stringGreenLeague;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("subscription1", array4);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Demote)
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[3];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array5[0] = Colours.stringRedLeague;
					array5[3] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("Attribution", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[4];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array6[0] = Colours.stringRedLeague;
					array6[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("N", array6);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[4];
					array7[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array7[0] = Colours.stringYellowLeague;
					array7[7] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("ID_FACEBOOKUSER", array7);
				}
				else
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[3];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array8[0] = Colours.stringYellowLeague;
					array8[3] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("Country", array8);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.GPBPIFNPOFJ(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = false;
			LHKLOFBMPGN.onReposition = GBOFIAHKPCM;
		}
	}

	private void CPKAHGCGLKI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("open"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void AIOBEOEGIDL()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 1572f);
	}

	private void NLEKOONKHMN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("N"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void PJOAKINEFIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("Purchase_Attempt"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void FHOHNJICDNK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(IJFCFCGIKHK.text);
		}
	}

	private void ACNDHPFJAPF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JJGFMKCHIPE(FCEIGDLFOMH);
			CPGACIMMFEC.BFKPPMIKNAA();
		}
	}

	public void DOJAAOLAIMG(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.MBHFAHFCPGB(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)7);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderReward);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Header) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -183 + -73;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1279f : 704f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ABAKFENMJLH(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LCHKCBLMOND(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.Reset();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(DPOBELPOFEL);
			Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(DPOBELPOFEL);
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, PNDNEMDPFHC: false);
			string text = GameVariables.IDOFIHFGOKD(MBIAKMPDOPG.country);
			bool flag2 = string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.LMNDFNIKIFI();
			IEJAOPGCIJC.text = levelDefinition.KAKFPJPKHHB();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() != PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= 22;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.None;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= -84;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(529f / NPECJCIKCBI.transform.localScale.x, 339f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 894f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 387f, 1762f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JGHIGFAFNLF));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FHOHNJICDNK));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 266f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(APHJEHENIPM));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BAEHPJJHPCM));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(CODNBIDNPPI));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderNoReward)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[1];
						array[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
						array[1] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("setCustomProfileStringValue", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("ID_HOURAGO");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[6];
					array2[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array2[0] = Colours.stringGreenLeague;
					array2[2] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("equippedID", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[4];
					array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array3[1] = Colours.stringGreenLeague;
					array3[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("Wrong_Unit", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)6)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					string text3;
					if (flag6)
					{
						object[] array4 = new object[6];
						array4[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array4[0] = stringYellowLeague;
						text3 = Localization.LocalizeFormat("menu-health-ico", array4);
					}
					else
					{
						text3 = stringYellowLeague + Localization.Localize("NumberOfMission");
					}
					fCFPODPEHBO4.text = text3;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[4];
					array5[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array5[0] = Colours.stringGreenLeague;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("shotSniper", array5);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_CONFIRM_GAMELAREADYENDED", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1), Colours.stringGreenLeague, null, null, null, null, null, null);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)5)
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[5];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array6[0] = Colours.stringRedLeague;
					array6[0] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("Missing references in Special Pack Record: ", array6);
				}
				else
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[4];
					array7[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array7[1] = Colours.stringRedLeague;
					array7[2] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("ID_TONORMALLEAGUEHINT3SILVER", array7);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[8];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array8[1] = Colours.stringYellowLeague;
					array8[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("warbucks", array8);
				}
				else
				{
					UILabel fCFPODPEHBO9 = FCFPODPEHBO;
					object[] array9 = new object[0];
					array9[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array9[0] = Colours.stringYellowLeague;
					array9[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO9.text = Localization.LocalizeFormat("ID_ARENARULES_NOOVERTIME", array9);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.LCHKCBLMOND(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = CCJGBALGDAD;
		}
	}

	private void HEDJDLGGKLN()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 951f);
	}

	private void GKGNJAPFLIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("bot"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void KEHDACDMLCH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("ID_WARCARDSUNLOCKED"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void EKGILINPPGE(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GLLHPDLKAFI(IJFCFCGIKHK.text);
		}
	}

	private void NHIEGEGDHAE(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("ID_PURCHASECARDPACK"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void GOOMCGDNIGH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("Selected new room MAP id is: "))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	public void JFLKHEPMEAG(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.GPNONALLJKA(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)7);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Player) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -181 + 44;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1114f : 864f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.LeagueColorPosition(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.PDKPELBIAON();
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(NAEFOLMDNOP);
			Singleton<PlayerTexturePool>.instance.OFCKAJHLBGJ(NAIFFLFKJLE);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.IEDGPHEPJEK(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.CDLBEKECJNK();
			IEJAOPGCIJC.text = levelDefinition.displayString;
			bool flag3 = MBIAKMPDOPG.GetRealStatus() == PlayerStatus.Online;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= 29;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown != WarArenaCrown.None;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= -67;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(402f / NPECJCIKCBI.transform.localScale.x, 490f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1464f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1584f, 236f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LDAFDHAGFHI));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NNFENDOHJLJ));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 380f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PJOAKINEFIN));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderNoReward)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					FCFPODPEHBO.text = ((!flag5) ? (stringGreenLeague + Localization.Localize("ID_CONNECTING")) : Localization.LocalizeFormat("Waiting for map set", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), stringGreenLeague, null, null));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					object[] array = new object[4];
					array[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array[1] = Colours.stringGreenLeague;
					array[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO.text = Localization.LocalizeFormat("ID_DAILYGOLDBOOSTER", array);
				}
				else
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[6];
					array2[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array2[0] = Colours.stringGreenLeague;
					array2[8] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("ID_GOLDCARDS", array2);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)4)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					string text2;
					if (flag6)
					{
						object[] array3 = new object[6];
						array3[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
						array3[1] = stringYellowLeague;
						text2 = Localization.LocalizeFormat("{0}", array3);
					}
					else
					{
						text2 = stringYellowLeague + Localization.Localize("ID_CREATESQUADNOTENOUGH");
					}
					fCFPODPEHBO3.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("Pack_Id", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1), Colours.stringGreenLeague, null, null, null, null);
				}
				else
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[7];
					array4[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array4[0] = Colours.stringGreenLeague;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("ID_CONFIRM_PROMOTEDEMOTEERROR", array4);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)4)
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[1];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array5[1] = Colours.stringRedLeague;
					array5[8] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("ID_VISUALCATEGORYPART2", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[4];
					array6[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array6[0] = Colours.stringRedLeague;
					array6[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("getGameData", array6);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[8];
					array7[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array7[1] = Colours.stringYellowLeague;
					array7[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("ID_WARNING_ACHIEVEMENTREWARDNOTFOUND", array7);
				}
				else
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[2];
					array8[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array8[0] = Colours.stringYellowLeague;
					array8[3] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("AdFailedToDisplay()", array8);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.LCHKCBLMOND(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = delegate
			{
				float num2 = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
				LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num2 - 40f);
			};
		}
	}

	private void AHJDKCHOGLH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(IJFCFCGIKHK.text);
		}
	}

	private void NNFENDOHJLJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.OMCEGPODDHL(IJFCFCGIKHK.text);
		}
	}

	public void HFGPHKFEIEN()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id);
			MBIAKMPDOPG = null;
		}
	}

	private void CCJGBALGDAD()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 1715f);
	}

	private void APHJEHENIPM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("TÉLÉCHARGER"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void CODNBIDNPPI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("FuseBox Event Level Up for level {0}"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	public virtual void JHDEIGOECKK()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EOANAEAIIDI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DEAEKGBOBEH));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EMGBNOMPAIC));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(FKBDHIJGMMM);
		LFAMFKAKGIG();
	}

	private void NAIFFLFKJLE(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.LOCLNGEMNCC(FCEIGDLFOMH);
			CPGACIMMFEC.OKHFOOHNBDF();
		}
	}

	private void MIGJPNDPAMI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.OMCEGPODDHL(IJFCFCGIKHK.text);
		}
	}

	public virtual void KOMJDNDMJDF()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BAEHPJJHPCM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FDPODMEBAKC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ANJJHJIFGGK));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= NDKDIBBOEFC;
		PCIIJHHNBBD();
	}

	private void HINLODPDDDP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(IJFCFCGIKHK.text);
		}
	}

	private void IANHNNELACJ()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 38f);
	}

	public void IHJICFANFDJ()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.MDANAEPCCHK(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
			MBIAKMPDOPG = null;
		}
	}

	public void BBJDJGLFMCL(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.KMIFEKCEOPJ(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderReward);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Header) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -67 + -5;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 468f : 998f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ECGGKMIKKMI(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LCHKCBLMOND(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.KLIEOBHDFCG();
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(DPOBELPOFEL);
			Singleton<PlayerTexturePool>.instance.AFAHCJBIHIP(FKBDHIJGMMM);
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.IEDGPHEPJEK(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.EGNEDNBPOEF();
			IEJAOPGCIJC.text = levelDefinition.displayString;
			bool flag3 = MBIAKMPDOPG.GetRealStatus() == PlayerStatus.Online;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= -47;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown == WarArenaCrown.BronzeCrown;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= 51;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(1286f / NPECJCIKCBI.transform.localScale.x, 1167f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 797f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1385f, 1636f, num);
			HKGAHCEJLIL.repositionNow = true;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LDAFDHAGFHI));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EKGILINPPGE));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 1700f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BDMCLOCBDOH));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PJOAKINEFIN));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NHIEGEGDHAE));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[7];
						array[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array[0] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("ID_CONFIRM_PROMOTETOLEADER_TEXT", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("ID_ZEROSECONDS");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[5];
					array2[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array2[1] = Colours.stringGreenLeague;
					array2[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("squadCreationsCnt", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[0];
					array3[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array3[1] = Colours.stringGreenLeague;
					array3[8] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("'ID_MONTH_'0", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)4)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					string text3;
					if (flag6)
					{
						object[] array4 = new object[6];
						array4[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array4[1] = stringYellowLeague;
						text3 = Localization.LocalizeFormat("pistol_idle", array4);
					}
					else
					{
						text3 = stringYellowLeague + Localization.Localize("ID_INBRONZE1");
					}
					fCFPODPEHBO4.text = text3;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[8];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array5[0] = Colours.stringGreenLeague;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("Average_Player_Level", array5);
				}
				else
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[8];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array6[0] = Colours.stringGreenLeague;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("\tTime since last show: {0}\tFb login counter: {1}/3", array6);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)4)
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[6];
					array7[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array7[0] = Colours.stringRedLeague;
					array7[2] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("Directory \"{0}\" does not exists", array7);
				}
				else
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[8];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array8[1] = Colours.stringRedLeague;
					array8[3] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("menu-assignments-type-kill", array8);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO9 = FCFPODPEHBO;
					object[] array9 = new object[2];
					array9[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array9[1] = Colours.stringYellowLeague;
					array9[7] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO9.text = Localization.LocalizeFormat("PowerBandId", array9);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1), Colours.stringYellowLeague, null, null, null, GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1, null);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.LCHKCBLMOND(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = MGMHKJAENBM;
		}
	}

	private void EOANAEAIIDI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("ID_WARNING_WARCARDNOTFOUNDINCOLLECTION"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void FFNEHMPBLAJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("game-elite-debuff1"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}

	private void OMLDMNIGKCC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("DOWNLOADBTN"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void PFNMKKKFGHA()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 1211f);
	}

	private void PJJJGFDJCEC()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 1371f);
	}

	private void IPJODOKMDIB()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 493f);
	}

	public void KBDHEFHLAKN()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	private void IKMENCFOELC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.GJHFCKMAMIE(FCEIGDLFOMH);
			CPGACIMMFEC.BFKPPMIKNAA();
		}
	}

	public void CNOEPDMAIEG()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
			MBIAKMPDOPG = null;
		}
	}

	public virtual void GICBOJPONMC()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GNBALDLNGJJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEHDACDMLCH));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IPCEBCAJCDE));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= IKMENCFOELC;
		NKNHOGOIBON();
	}

	public void NNFHBKCBADE()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	public void IHPPIMLGJOH()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
			MBIAKMPDOPG = null;
		}
	}

	public virtual void EMCFMPHKILC()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(APHJEHENIPM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GOOMCGDNIGH));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FHOHNJICDNK));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(DPOBELPOFEL);
		DNLMHBKDMBF();
	}

	private void AHLDPEGMIJI(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.BIEIDBBDNIF(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	private void MHDMAFHOBGB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(IJFCFCGIKHK.text);
		}
	}

	private void ANJJHJIFGGK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GLLHPDLKAFI(IJFCFCGIKHK.text);
		}
	}

	private void JMDFFKNIIPH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("ID_POWERBANDBOX"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void GJEIDAOPAPN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("FuseUnityPlugin "))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void LDAFDHAGFHI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(IJFCFCGIKHK.text);
		}
	}

	private void DEAEKGBOBEH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("null"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void MCAMADAPPHJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("WFX_Explosion"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	public void LFAMFKAKGIG()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, PNDNEMDPFHC: false, CJONGDEPJHC: false, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	public virtual void IFHBPEAKGDN()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OMLDMNIGKCC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MHDMAFHOBGB));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(IHIILICAFGF);
		PCIIJHHNBBD();
	}

	private void GDMEGJADFJI()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 791f);
	}

	private void FPNPPGMMIOD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith(" 3"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void GKNHJBDIHLC()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 1111f);
	}

	public void MJFAANAPMIE(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.FMILKBAEBHH(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)5);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Header) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -68 + 28;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1157f : 1793f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ABAKFENMJLH(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.KFHAGEFAADA(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.KOKJMKHECGK();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(IKMENCFOELC);
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FKBDHIJGMMM;
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
			string text = GameVariables.IEDGPHEPJEK(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.KJFPCOMOLLD();
			IEJAOPGCIJC.text = levelDefinition.GIIHOHGFHBO();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() == PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= 117;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown == WarArenaCrown.None;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= 67;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(1000f / NPECJCIKCBI.transform.localScale.x, 984f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1148f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1070f, 1433f, num);
			HKGAHCEJLIL.repositionNow = false;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ALONJIBEEKJ));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 957f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JMDFFKNIIPH));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NLEKOONKHMN));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FEOLMIBGICF));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(OPKFOOGDOGL));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderReward)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[0];
						array[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
						array[1] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("{0} \t\t", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("menu-sidetab-challenge-start");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[2];
					array2[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array2[1] = Colours.stringGreenLeague;
					array2[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("game-card-ico-disarmed", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[0];
					array3[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array3[0] = Colours.stringGreenLeague;
					array3[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("Level", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)4)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					FCFPODPEHBO.text = ((!flag6) ? (stringYellowLeague + Localization.Localize("Password")) : Localization.LocalizeFormat("leagueMedalsDiff", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0), stringYellowLeague, null, null, null, null, null));
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					object[] array4 = new object[4];
					array4[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array4[0] = Colours.stringGreenLeague;
					fCFPODPEHBO4.text = Localization.LocalizeFormat("Sniper_Tutorial_Played", array4);
				}
				else
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[1];
					array5[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array5[0] = Colours.stringGreenLeague;
					fCFPODPEHBO5.text = Localization.LocalizeFormat(" - {0}", array5);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Stay)
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[5];
					array6[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array6[0] = Colours.stringRedLeague;
					array6[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("country-portugal", array6);
				}
				else
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[5];
					array7[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array7[1] = Colours.stringRedLeague;
					array7[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("ID_UNITTYPE3-DESCRIPTION", array7);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: true);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[3];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array8[0] = Colours.stringYellowLeague;
					array8[8] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("GameLaunch", array8);
				}
				else
				{
					UILabel fCFPODPEHBO9 = FCFPODPEHBO;
					object[] array9 = new object[0];
					array9[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array9[1] = Colours.stringYellowLeague;
					array9[4] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO9.text = Localization.LocalizeFormat("Card_1_Played", array9);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.KFHAGEFAADA(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = true;
			LHKLOFBMPGN.onReposition = AIOBEOEGIDL;
		}
	}

	private void MGMHKJAENBM()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 345f);
	}

	public void PCIIJHHNBBD()
	{
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
			MBIAKMPDOPG = null;
		}
	}

	private void ALONJIBEEKJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GLLHPDLKAFI(IJFCFCGIKHK.text);
		}
	}

	private void PPJEJBPNEDF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("PlayerData"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	public virtual void DJDFKKJLHIC()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BAEHPJJHPCM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OPKFOOGDOGL));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JGHIGFAFNLF));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(POLOPBEOOCB);
		PGHAKHBDGFH();
	}

	public virtual void AMPACMLGJEB()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKAKMDBGPAP));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JDGFPLEHBOK));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(IKMENCFOELC);
		KBDHEFHLAKN();
	}

	public virtual void HGFPIMGFJBE()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NHIEGEGDHAE));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JDGFPLEHBOK));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(OPOHEGOIEDP);
		BANIBDDJPCE();
	}

	private void GKLDDBGAFHP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.ECKBKNCJLOC(FCEIGDLFOMH);
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	private void IHIILICAFGF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.DJPNDAICDPN(FCEIGDLFOMH);
			CPGACIMMFEC.BFKPPMIKNAA();
		}
	}

	private void GBOFIAHKPCM()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 961f);
	}

	private void HJKKFAOJLFA(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GLLHPDLKAFI(IJFCFCGIKHK.text);
		}
	}

	private void GNBALDLNGJJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("ID_WARNING_INVALIDLINK"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	public virtual void NHJKBCGFIAN()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NLEKOONKHMN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PJOAKINEFIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NNFENDOHJLJ));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(DPOBELPOFEL);
		NNFHBKCBADE();
	}

	public void LCLNACBBJKI(LeagueContent.KJNEDPOJJOC CHELCBJKLFK, float CEHFMMJHCKC)
	{
		BMNBNDILFJD.DKHLKOFJKPL(CEHFMMJHCKC);
		OOIBADLGKML.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		DOCLOEBEGIL.SetActive(CHELCBJKLFK.FJLBLLLEELD == (LeagueContent.NKHJBLBAAEB)8);
		HDPDBOELPLF.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player);
		IGJMJNHFCAI.SetActive(CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header);
		MBIAKMPDOPG = ((CHELCBJKLFK.FJLBLLLEELD != LeagueContent.NKHJBLBAAEB.Player) ? null : CHELCBJKLFK.KHLGDCHJJPB);
		if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Header)
		{
			bool flag = MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id;
			int num = (int)CEHFMMJHCKC - -131 + 72;
			LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(CHELCBJKLFK.AHHJKNHKCCI).ReplaceA((!flag) ? 1805f : 678f);
			MPHCNMDIPAI.color = Singleton<GameVariables>.instance.ECGGKMIKKMI(CHELCBJKLFK.AHHJKNHKCCI);
			JDOOPPMKEFO.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			KCMDAFLFAGB.color = Singleton<GameVariables>.instance.LeagueColorMedals(CHELCBJKLFK.AHHJKNHKCCI);
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(CHELCBJKLFK.MPHCNMDIPAI);
			CPGACIMMFEC.KHMNEOBMJLN();
			Singleton<PlayerTexturePool>.instance.FHEJPABPCML(AHLDPEGMIJI);
			Singleton<PlayerTexturePool>.instance.MMAGKGAKHAD(NAIFFLFKJLE);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG);
			string text = GameVariables.IDOFIHFGOKD(MBIAKMPDOPG.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			OOECKDBCHKL.gameObject.SetActive(flag2);
			if (flag2)
			{
				OOECKDBCHKL.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(MBIAKMPDOPG.level);
			PMIAEHHNNAD.spriteName = levelDefinition.CDLBEKECJNK();
			IEJAOPGCIJC.text = levelDefinition.JNODDKLJOAG();
			bool flag3 = MBIAKMPDOPG.GetRealStatus() == PlayerStatus.Offline;
			BJCMNMGCGNN.SetActive(flag3);
			if (flag3)
			{
				num -= -52;
			}
			bool flag4 = MBIAKMPDOPG.warArenaCrown == WarArenaCrown.BronzeCrown;
			JHKNOIJBDGA.SetActive(flag4);
			if (flag4)
			{
				num -= 103;
				NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[MBIAKMPDOPG.warArenaCrown];
				NPECJCIKCBI.MakePixelPerfect();
				float multiplier = Mathf.Min(180f / NPECJCIKCBI.transform.localScale.x, 1988f / NPECJCIKCBI.transform.localScale.y);
				NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			}
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1376f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 596f, 491f, num);
			HKGAHCEJLIL.repositionNow = false;
			if (string.IsNullOrEmpty(MBIAKMPDOPG.squadName))
			{
				IJFCFCGIKHK.text = string.Empty;
			}
			else
			{
				IJFCFCGIKHK.text = MBIAKMPDOPG.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IPCEBCAJCDE));
				UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IPCEBCAJCDE));
			}
			TweenColor.Begin(IJFCFCGIKHK.gameObject, 1509f, Color.white);
			AMFJHAPGIJN.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.armyPowerX10);
			KCMDAFLFAGB.text = MEJMLNDFDBP.BEDJNPHFAOC(MBIAKMPDOPG.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(APHJEHENIPM));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LFGJMGCDKNM));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(BKAKMDBGPAP));
		}
		else if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.HeaderNoReward)
		{
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(CHELCBJKLFK.EOHOJBOGNAO);
		}
		else
		{
			if (CHELCBJKLFK.FJLBLLLEELD == LeagueContent.NKHJBLBAAEB.Player)
			{
				return;
			}
			MIEEGOCCPGB.spriteName = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.NENPBAAELDJ].Value2;
			if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Promote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 0)
				{
					bool flag5 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringGreenLeague = Colours.stringGreenLeague;
					EIDJHKHJBII.gameObject.SetActive(flag5);
					UILabel fCFPODPEHBO = FCFPODPEHBO;
					string text2;
					if (flag5)
					{
						object[] array = new object[6];
						array[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
						array[0] = stringGreenLeague;
						text2 = Localization.LocalizeFormat("game-card-ico-backstab", array);
					}
					else
					{
						text2 = stringGreenLeague + Localization.Localize("reloadTime");
					}
					fCFPODPEHBO.text = text2;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO2 = FCFPODPEHBO;
					object[] array2 = new object[1];
					array2[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array2[1] = Colours.stringGreenLeague;
					array2[7] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO2.text = Localization.LocalizeFormat("[0-9.,]*", array2);
				}
				else
				{
					UILabel fCFPODPEHBO3 = FCFPODPEHBO;
					object[] array3 = new object[8];
					array3[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0);
					array3[1] = Colours.stringGreenLeague;
					array3[6] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO3.text = Localization.LocalizeFormat("ID_GUI_YAISN_DESC", array3);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == JBAGAHBOICJ.Demote)
			{
				if (CHELCBJKLFK.MPHCNMDIPAI == 1)
				{
					bool flag6 = CHELCBJKLFK.MPHCNMDIPAI < CHELCBJKLFK.OKHCCAIPHEG;
					string stringYellowLeague = Colours.stringYellowLeague;
					EIDJHKHJBII.gameObject.SetActive(flag6);
					UILabel fCFPODPEHBO4 = FCFPODPEHBO;
					string text3;
					if (flag6)
					{
						object[] array4 = new object[4];
						array4[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
						array4[0] = stringYellowLeague;
						text3 = Localization.LocalizeFormat("{0} {1}{2}", array4);
					}
					else
					{
						text3 = stringYellowLeague + Localization.Localize("Experience");
					}
					fCFPODPEHBO4.text = text3;
				}
				else if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO5 = FCFPODPEHBO;
					object[] array5 = new object[7];
					array5[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 1);
					array5[0] = Colours.stringGreenLeague;
					fCFPODPEHBO5.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array5);
				}
				else
				{
					FCFPODPEHBO.text = Localization.LocalizeFormat("SetShieldPositionRPC", MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 0), Colours.stringGreenLeague, null, null, null);
				}
			}
			else if (CHELCBJKLFK.AHHJKNHKCCI == (JBAGAHBOICJ)8)
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO6 = FCFPODPEHBO;
					object[] array6 = new object[8];
					array6[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array6[0] = Colours.stringRedLeague;
					array6[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO6.text = Localization.LocalizeFormat("{0}{1}", array6);
				}
				else
				{
					UILabel fCFPODPEHBO7 = FCFPODPEHBO;
					object[] array7 = new object[3];
					array7[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array7[0] = Colours.stringRedLeague;
					array7[5] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO7.text = Localization.LocalizeFormat("ID_ARENARULES_UNITCOST", array7);
				}
			}
			else
			{
				EIDJHKHJBII.gameObject.SetActive(value: false);
				if (CHELCBJKLFK.MPHCNMDIPAI <= CHELCBJKLFK.OKHCCAIPHEG)
				{
					UILabel fCFPODPEHBO8 = FCFPODPEHBO;
					object[] array8 = new object[2];
					array8[1] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM + 0);
					array8[0] = Colours.stringYellowLeague;
					array8[1] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO8.text = Localization.LocalizeFormat("ID_CONFIRM_JOININGSAMESQUAD", array8);
				}
				else
				{
					UILabel fCFPODPEHBO9 = FCFPODPEHBO;
					object[] array9 = new object[2];
					array9[0] = MEJMLNDFDBP.BEDJNPHFAOC(CHELCBJKLFK.KGONOPCNKLM - 1);
					array9[1] = Colours.stringYellowLeague;
					array9[2] = GameVariables.CAOGFCFGFPD[CHELCBJKLFK.DMHLCPCLECE].Value1;
					fCFPODPEHBO9.text = Localization.LocalizeFormat("ID_ARENASHORTCUTPHASEEND", array9);
				}
			}
			GJIGEFJAKNM.color = Singleton<GameVariables>.instance.LeagueColorBackground(CHELCBJKLFK.AHHJKNHKCCI);
			LHKLOFBMPGN.repositionNow = false;
			LHKLOFBMPGN.onReposition = GDMEGJADFJI;
		}
	}

	private void EJPDNIKEOFM()
	{
		float num = Mathf.Abs(FCFPODPEHBO.transform.parent.transform.localPosition.x);
		LHKLOFBMPGN.transform.localPosition = LHKLOFBMPGN.transform.localPosition.ReplaceX(0f - num - 394f);
	}

	private void BAEHPJJHPCM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("offers"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, BNNKPKDPLPP: false);
			}
		}
	}

	private void JGHIGFAFNLF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(IJFCFCGIKHK.text);
		}
	}

	private void JLMBIBBOMPA(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (MBIAKMPDOPG.id.StartsWith("squadMembers"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(MBIAKMPDOPG.name, DatabasePlayerInfo.CreateBot(MBIAKMPDOPG));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
			}
		}
	}
}
