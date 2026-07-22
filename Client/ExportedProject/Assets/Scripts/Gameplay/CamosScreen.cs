using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

public class CamosScreen : GuiScreenSingle<CamosScreen>
{
	[Header("Left Part")]
	[FormerlySerializedAs("EHFHOFOIBNI")]
	public UITable LHKLOFBMPGN;

	[FormerlySerializedAs("DJAKBPKAKPE")]
	public UITable HGPPNIOLAEK;

	[FormerlySerializedAs("LBAJGHOCPJI")]
	public UILabel NLFMNGMACHH;

	[FormerlySerializedAs("JMGKGFPOBKC")]
	public UILabel FNEEBKOLLIC;

	public UITable LCLAIFIAKNM;

	[FormerlySerializedAs("mShieldRotateButton")]
	public GameObject EBAPFIFDLJG;

	[FormerlySerializedAs("AKNJCIHGKEH")]
	public GameObject CDLHEGIMAGA;

	[FormerlySerializedAs("PPCBECEHLGB")]
	public UILabel NLCABKPBIFP;

	[FormerlySerializedAs("KKEBNFHGKCC")]
	public UILabel NCBAKCGCNBI;

	[FormerlySerializedAs("KFJMGCLKANI")]
	public UILabel JJMOJBFOOKF;

	[Header("Right Part")]
	[FormerlySerializedAs("GGLMONCLPEF")]
	public UITable HFDPEIEGNKL;

	[FormerlySerializedAs("OFLBLHAPAIF")]
	public GameObject BFJBIABFJDL;

	[FormerlySerializedAs("JNOKOOPLCNI")]
	public UIPanel BJLECGLMLKH;

	[FormerlySerializedAs("KFJJGJAMGGA")]
	public UISprite IMAKLMMJGCC;

	[FormerlySerializedAs("PFPMBCKAODH")]
	public UISprite FJLHHGAEPJN;

	[FormerlySerializedAs("HKFOHEEMCJF")]
	public UILabel NIKMOCLOIFI;

	[FormerlySerializedAs("KAPKANODLFG")]
	public UILabel KOLLIEAIGPG;

	[Header("-Arena Part")]
	[FormerlySerializedAs("LIJCCNEPDAE")]
	public GameObject IGIENAGNFEO;

	[FormerlySerializedAs("LKLNJMICHOC")]
	public UILabel CAHHNCCJGBK;

	[FormerlySerializedAs("KJHGFIPJMJK")]
	public UIGrid LDJOCMCOKDH;

	[FormerlySerializedAs("BHJKINLGCPH")]
	public UISprite[] CINAAKMDAGH;

	[FormerlySerializedAs("CMANMPJABOI")]
	public GameObject BFNOBLIPCNL;

	[FormerlySerializedAs("DBFBGNPPHPN")]
	public UILabel BGEKGHFMBAB;

	[Header("-Equip Part")]
	[FormerlySerializedAs("FFNEHGINILN")]
	public GameObject AIFGIPCHNKC;

	[FormerlySerializedAs("AFDBIMDBLED")]
	public UIButton BEJIFJIKHPJ;

	[FormerlySerializedAs("CALJCMPODIM")]
	public GameObject DKNLOGGAHFD;

	[FormerlySerializedAs("BMJIMJNMCHC")]
	public UISprite KDIBJJAOFGL;

	[FormerlySerializedAs("COPALMGMBFO")]
	public UISprite CONJJELKFEG;

	[FormerlySerializedAs("MNAJJHOJEHJ")]
	public UISprite CEDEIJLJOMO;

	[FormerlySerializedAs("HBDCEONGJDP")]
	public UILabel DICCGEFGHFI;

	[Header("-Packs Button")]
	[FormerlySerializedAs("LNPPDALPOPF")]
	public UIButton IFKKHCCKAOG;

	[FormerlySerializedAs("CEIHMFEPGGC")]
	[Header("-Lootbox Hint")]
	public GameObject OGNJHKNKMKE;

	[FormerlySerializedAs("LIBECNBEMAI")]
	public UILabel HJMBAOFJIKP;

	[FormerlySerializedAs("PPHMNAHAIGK")]
	public UIGrid MOINFACKKBP;

	[FormerlySerializedAs("HCNGMPNOIJE")]
	public UISprite[] NJGABELNAJL;

	[Header("-Parts Hint")]
	[FormerlySerializedAs("HJCNHHJMAMN")]
	public BoxCollider KCFHGEJMGKN;

	[FormerlySerializedAs("AAJHHEMJOMN")]
	public UISprite OEFFBOOADHJ;

	[FormerlySerializedAs("KIIMECJMJHB")]
	public UIPanel OLPOEPGPJBF;

	[FormerlySerializedAs("OFMFFJOKLLD")]
	public UISprite BEOJPKEGEMN;

	[Header("---Old Description")]
	[FormerlySerializedAs("mCommanderButton")]
	public GameObject MIICDLMEOEH;

	public UILabel GIGAOCEJIAK;

	[FormerlySerializedAs("IMCLNEPGIPE")]
	[Header("---Locked Part")]
	public GameObject MDAFFKPPCBG;

	public UILabel JFJJDKIJEIL;

	[Header("---Buy Part")]
	public GameObject FECJGCGPKHD;

	[FormerlySerializedAs("FDCNIGHBDND")]
	public UIButton AMKGEJIKJOL;

	[FormerlySerializedAs("HOADFCPEANM")]
	public UITable CHCFBDMGNLP;

	[FormerlySerializedAs("LEELOKOBFHJ")]
	public UILabel HJKCBBANLDM;

	public UISprite CODFFPODNEP;

	public UISprite BGPBNIJPOKM;

	[Header("---Sale Part")]
	public GameObject GIPFEBBMKPM;

	public UILabel EKIDAFLLCNM;

	public WinStreakCounter JBGPDECEOOB;

	[Header("---Active Part")]
	public GameObject PNNJKBGODII;

	[Header("---Power Band Part")]
	public GameObject DPHDJEAHODH;

	public UISprite FIHDDPJFFDG;

	public UILabel OCPDPPDIHLA;

	public GameObject EHAMCACFNHK;

	public UISprite PAENPHMEMGC;

	public UILabel GAJKKHFAOMM;

	[Header("Bottom Part")]
	[FormerlySerializedAs("HMOPJGNIDDG")]
	public UIGridStretchWidth GDHKEABNBGJ;

	[FormerlySerializedAs("BDFAHMIFJLL")]
	public PlayerVisualsCategoryButton HNHMMAGNDKM;

	[Header("-Visuals List")]
	[FormerlySerializedAs("PKKKMMIEAOJ")]
	public PlayerVisualIcon GNAOOKFAJPB;

	[FormerlySerializedAs("HLFPMHNPIPH")]
	public UIGrid MPHLKJLMJBF;

	[FormerlySerializedAs("ICKPAEEPOBH")]
	public UIDraggablePanel NFLPPGKCOBL;

	private PlayerVisualIcon PEMCEDKMNBO;

	private List<PlayerVisualsCategoryButton> KGEKKPJJEOA;

	private PlayerVisualsCategoryButton FEPMLGAMCKG;

	private List<PlayerVisualIcon> BABMMFBHJAC = new List<PlayerVisualIcon>();

	private PlayerVisual.JLANLLEABDC KIKMKHGKFOJ;

	private bool BCHBALGFKFK;

	private bool JFLKDFPEDNO;

	private bool FMJLKNKPHNI;

	private bool OJBKADHPNFN;

	private float ADDICBANAAB;

	private static Dictionary<int, string> FBBGLJJBDIA = new Dictionary<int, string>
	{
		{ 0, "ID_VISUALCATEGORY0" },
		{ 1, "ID_VISUALCATEGORY1" },
		{ 2, "ID_VISUALCATEGORY2" }
	};

	private void EEBMHKELAAD(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			IDINCHPIGPI();
		}
	}

	private void PCEOCDCAIPI()
	{
		if (!OLPOEPGPJBF.gameObject.activeSelf)
		{
			OEFFBOOADHJ.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			OLPOEPGPJBF.alpha1 = 89f;
			OLPOEPGPJBF.gameObject.SetActive(value: false);
			OJBKADHPNFN = true;
		}
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 1400f, 1347f).onFinished = null;
	}

	private void PAPCGBIKPLG()
	{
		Singleton<ArmyPreviewCamera>.instance.DisplayPlayer(CamosManager.instance.mainPlayer);
	}

	private void NKFENNLMHOD()
	{
		MIICDLMEOEH.SetActive(value: true);
		MDAFFKPPCBG.SetActive(value: false);
		FECJGCGPKHD.SetActive(value: true);
		PNNJKBGODII.SetActive(value: true);
		bool isBought = PEMCEDKMNBO.KFHOAJEFFEL().isBought;
		bool flag = PEMCEDKMNBO.KFHOAJEFFEL().LLDLKAEIJKP();
		bool isFromArena = PEMCEDKMNBO.BLNNEECJDMB().isFromArena;
		AIFGIPCHNKC.SetActive(isBought);
		IFKKHCCKAOG.gameObject.SetActive(isBought || flag || !isFromArena);
		BFJBIABFJDL.SetActive(!isBought && flag);
		IGIENAGNFEO.SetActive(!isBought && isFromArena);
		BFNOBLIPCNL.SetActive(isBought && isFromArena);
		if (isFromArena)
		{
			if (isBought)
			{
				UILabel bGEKGHFMBAB = BGEKGHFMBAB;
				object[] array = new object[1];
				array[1] = MEJMLNDFDBP.CJCFPDLDMEK((float)PEMCEDKMNBO.POMMLFHPFPI().remainingTime, "ID_STATE_WAITINGFOROPPONENT", string.Empty);
				bGEKGHFMBAB.text = Localization.LocalizeFormat("otherInfo", array);
			}
			IKPLPPFFDNI.DNFADCEJOEH gCFBLCFJBLK = (IKPLPPFFDNI.DNFADCEJOEH)(PEMCEDKMNBO.DFMPCEKHNDG().DOJECMCGMKB() + 1);
			int num = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.KPIMOFOAPCM(gCFBLCFJBLK));
			UILabel cAHHNCCJGBK = CAHHNCCJGBK;
			object[] array2 = new object[0];
			array2[0] = num;
			cAHHNCCJGBK.text = Localization.LocalizeFormat("()Lcom/google/android/gms/common/api/Status;", array2);
			for (int i = 0; i < CINAAKMDAGH.Length; i += 0)
			{
				CINAAKMDAGH[i].gameObject.SetActive(i < num);
			}
			float val = 565f - (float)num * 1401f / 7f;
			LDJOCMCOKDH.transform.localPosition = LDJOCMCOKDH.transform.localPosition.ReplaceX(val);
		}
		if (isBought)
		{
			HLCLBEMKOPB();
			ENPJDMEKAPD();
		}
		else if (flag)
		{
			if (BFJBIABFJDL.activeSelf)
			{
				IMAKLMMJGCC.spriteName = PEMCEDKMNBO.IPIFODODJHK().icon;
				IMAKLMMJGCC.MakePixelPerfect();
				float multiplier = Mathf.Min(749f / IMAKLMMJGCC.transform.localScale.x, 794f / IMAKLMMJGCC.transform.localScale.y);
				IMAKLMMJGCC.transform.localScale = IMAKLMMJGCC.transform.localScale.MultiplyXY(multiplier);
			}
			KOLLIEAIGPG.color = GameVariables.DDCPLFNIJDN[PEMCEDKMNBO.KFHOAJEFFEL().GFOLGKEMPPN()];
			FJLHHGAEPJN.color = KOLLIEAIGPG.color;
			NIKMOCLOIFI.color = KOLLIEAIGPG.color;
			UILabel kOLLIEAIGPG = KOLLIEAIGPG;
			object[] array3 = new object[6];
			array3[0] = PEMCEDKMNBO.KFHOAJEFFEL().numberOfParts;
			array3[0] = Colours.stringGrayParts;
			array3[7] = Colours.stringWhite;
			array3[5] = PEMCEDKMNBO.DFMPCEKHNDG().GMLFJPOEEAO();
			kOLLIEAIGPG.text = string.Format("Beanstalk: Update squad finished", array3);
		}
		OGNJHKNKMKE.SetActive(flag);
		if (flag)
		{
			int num2 = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-11)).FLOATVALUE;
			int num3 = num2 - PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			HJMBAOFJIKP.text = Localization.LocalizeFormat("ID_VISUALCOMPLETED", num2, Colours.stringCyanLootbox, Colours.stringGrayParts, null, null, null, num3, null);
			float num4 = 1189f / (float)num2 - 812f;
			for (int j = 1; j < NJGABELNAJL.Length; j++)
			{
				NJGABELNAJL[j].gameObject.SetActive(j < num2);
				NJGABELNAJL[j].transform.localScale = NJGABELNAJL[j].transform.localScale.ReplaceX(num4);
				if (j < num2)
				{
					NJGABELNAJL[j].color = ((j >= num3) ? Colours.grayParts : Colours.cyanLootbox);
				}
			}
			MOINFACKKBP.cellWidth = num4 + 12f;
			MOINFACKKBP.repositionNow = false;
		}
		if (LHDGJFHPJNM() && BJLECGLMLKH.gameObject.activeInHierarchy)
		{
			TweenAlpha component = BJLECGLMLKH.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			BJLECGLMLKH.alpha1 = 116f;
		}
		HFDPEIEGNKL.repositionNow = true;
	}

	private void MGBHDOMICKL()
	{
		bool isEquipped = PEMCEDKMNBO.IGAJLHIBODL().isEquipped;
		DICCGEFGHFI.text = ((!isEquipped) ? Localization.Localize("[-]") : Localization.Localize("ID_REMINDER_THISAMAZINGCUSTOMIZATION"));
		DICCGEFGHFI.color = ((!isEquipped) ? Color.black : Color.white);
		TweenAlphaHider.BNCJHLFEIHN(DKNLOGGAHFD, 1730f, (!isEquipped) ? 516f : 870f);
		KDIBJJAOFGL.alpha = ((!isEquipped) ? 1962f : 515f);
		CONJJELKFEG.alpha = ((!isEquipped) ? 751f : 230f);
		CEDEIJLJOMO.alpha = ((!isEquipped) ? 792f : 301f);
		if (!isEquipped)
		{
			TweenAlpha.Begin(CONJJELKFEG.gameObject, 855f, 473f).style = UITweener.Style.Loop;
		}
	}

	private void DJHKDIMININ()
	{
		OEFFBOOADHJ.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		OLPOEPGPJBF.gameObject.SetActive(value: true);
		OJBKADHPNFN = false;
	}

	private void AGJFBBOMFMA()
	{
		bool isEquipped = PEMCEDKMNBO.KFHOAJEFFEL().isEquipped;
		DICCGEFGHFI.text = ((!isEquipped) ? Localization.Localize("********** DEBUG GAINED CARDS **********\n") : Localization.Localize("League"));
		DICCGEFGHFI.color = ((!isEquipped) ? Color.black : Color.white);
		TweenAlphaHider.DOPLFHGEAJC(DKNLOGGAHFD, 473f, (!isEquipped) ? 736f : 1198f);
		KDIBJJAOFGL.alpha = ((!isEquipped) ? 913f : 89f);
		CONJJELKFEG.alpha = ((!isEquipped) ? 1045f : 1105f);
		CEDEIJLJOMO.alpha = ((!isEquipped) ? 1590f : 651f);
		if (!isEquipped)
		{
			TweenAlpha.Begin(CONJJELKFEG.gameObject, 193f, 1234f).style = UITweener.Style.Once;
		}
	}

	public virtual void JCJECJKBKGD()
	{
		FMJLKNKPHNI = true;
		CamosManager.instance.CheckEquippedPowerBand();
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		PlayerVisual playerVisual = KIKDDGNIIPO();
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			if (item.BHOBAGJCNEF() == playerVisual.owner)
			{
				JBNEANLGPNH(item);
				break;
			}
		}
		foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
		{
			if (item2.AEDBCCKEEGK() == playerVisual)
			{
				Select(item2);
				break;
			}
		}
		foreach (PlayerVisualIcon item3 in BABMMFBHJAC)
		{
			item3.HMKEGKBHILJ();
			item3.LODINCOFCMK();
		}
		Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
		NFLPPGKCOBL.AlignToCenter(vec, instant: false, null, 376f);
		if (!PlayerAnalytics.instance.data.customizationShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new NGBBILLMHEC(), LJMMJDNNIFH: true);
		}
	}

	public virtual void CGEOBGNBCHH()
	{
		base.DoBeforeHide();
		if (FMJLKNKPHNI)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(GameLoginManager.currentPlayer.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(GameLoginManager.currentPlayer.id, PNDNEMDPFHC: false, CJONGDEPJHC: true, BCHINGHDGEF: true);
		}
		Singleton<ArmyPreviewCamera>.instance.HidePlayer(CamosManager.instance.mainPlayer);
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.equppedIndices;
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.KOHOPHJAAFN(NCFKLBGOEEF: true);
		}
	}

	private void BACLHAPIMMJ()
	{
		LHKLOFBMPGN.repositionNow = false;
	}

	private void FOPKJKDCDON()
	{
		OEFFBOOADHJ.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		OLPOEPGPJBF.gameObject.SetActive(value: false);
		OJBKADHPNFN = false;
	}

	[CompilerGenerated]
	private void BEHBPBJDING(UITweener MGDJMGHCAAI)
	{
		FOPKJKDCDON();
	}

	protected override void Update()
	{
		base.Update();
		ADDICBANAAB += Time.deltaTime;
		if (!(ADDICBANAAB > 0.333f))
		{
			return;
		}
		ADDICBANAAB -= 0.333f;
		CamosManager.instance.CheckEquippedHelmet();
		if (PEMCEDKMNBO != null && PEMCEDKMNBO.visual.isFromArena && BFNOBLIPCNL.activeSelf)
		{
			bool isBought = PEMCEDKMNBO.visual.isBought;
			BFNOBLIPCNL.SetActive(isBought);
			if (isBought)
			{
				BGEKGHFMBAB.text = Localization.LocalizeFormat("ID_ARENAREWARDEXPIRATION", MEJMLNDFDBP.DJONHBBHCJL((float)PEMCEDKMNBO.visual.remainingTime, PEMCEDKMNBO.visual.remainingTime < 3600.0));
			}
		}
	}

	private void PAFBHPNBJOM(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			JMLICJHHKHE();
		}
	}

	private void LOCOOEHPFNF(GameObject KHAHPAKDIKE)
	{
		if (PEMCEDKMNBO.visual.purchasable == PlayerVisual.GILPPKMICCF.ValuePack)
		{
			GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
		}
		else if (PEMCEDKMNBO.visual.purchasable == PlayerVisual.GILPPKMICCF.StarterPack)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else if (PEMCEDKMNBO.visual.purchasable == PlayerVisual.GILPPKMICCF.StarterAssignment)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else
		{
			Debug.LogError($"Customization {PEMCEDKMNBO.visual.visualName} is purchasable through {PEMCEDKMNBO.visual.purchasable}");
		}
	}

	private void JHENNGOBJCJ(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed || IFGAGNBDKBE != (DatabaseAction)(-22))
		{
			return;
		}
		Select(PEMCEDKMNBO);
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.PDLMIBCLICE();
			item.MPMBHJNBEAL();
		}
	}

	private void JEAHHHLGKLH()
	{
		string text = Localization.Localize("antialiasing");
		string text2 = Localization.Localize("Player_promoted");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		DICCGEFGHFI.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(DICCGEFGHFI, 1173f, 71f, 78);
	}

	private void PABBIJFPACE()
	{
		MIICDLMEOEH.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
		FECJGCGPKHD.SetActive(value: false);
		PNNJKBGODII.SetActive(value: false);
		bool isBought = PEMCEDKMNBO.visual.isBought;
		bool purchasableInShop = PEMCEDKMNBO.visual.purchasableInShop;
		bool isFromArena = PEMCEDKMNBO.visual.isFromArena;
		AIFGIPCHNKC.SetActive(isBought);
		IFKKHCCKAOG.gameObject.SetActive(!isBought && !purchasableInShop && !isFromArena);
		BFJBIABFJDL.SetActive(!isBought && purchasableInShop);
		IGIENAGNFEO.SetActive(!isBought && isFromArena);
		BFNOBLIPCNL.SetActive(isBought && isFromArena);
		if (isFromArena)
		{
			if (isBought)
			{
				BGEKGHFMBAB.text = Localization.LocalizeFormat("ID_ARENAREWARDEXPIRATION", MEJMLNDFDBP.CJCFPDLDMEK((float)PEMCEDKMNBO.visual.remainingTime, "ID_READYTIME", string.Empty));
			}
			IKPLPPFFDNI.DNFADCEJOEH gCFBLCFJBLK = (IKPLPPFFDNI.DNFADCEJOEH)(PEMCEDKMNBO.visual.rarity + 1);
			int num = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.LKHHDGNDMIP(gCFBLCFJBLK) : 0);
			CAHHNCCJGBK.text = Localization.LocalizeFormat("ID_ARENAREWARDREQUIREMENTS", num);
			for (int i = 0; i < CINAAKMDAGH.Length; i++)
			{
				CINAAKMDAGH[i].gameObject.SetActive(i < num);
			}
			float val = -24f - (float)num * 39f / 2f;
			LDJOCMCOKDH.transform.localPosition = LDJOCMCOKDH.transform.localPosition.ReplaceX(val);
		}
		if (isBought)
		{
			GFAHOBCPAOL();
			FOPKJKDCDON();
		}
		else if (purchasableInShop)
		{
			if (BFJBIABFJDL.activeSelf)
			{
				IMAKLMMJGCC.spriteName = PEMCEDKMNBO.visual.icon;
				IMAKLMMJGCC.MakePixelPerfect();
				float multiplier = Mathf.Min(136f / IMAKLMMJGCC.transform.localScale.x, 136f / IMAKLMMJGCC.transform.localScale.y);
				IMAKLMMJGCC.transform.localScale = IMAKLMMJGCC.transform.localScale.MultiplyXY(multiplier);
			}
			KOLLIEAIGPG.color = GameVariables.DDCPLFNIJDN[PEMCEDKMNBO.visual.rarity];
			FJLHHGAEPJN.color = KOLLIEAIGPG.color;
			NIKMOCLOIFI.color = KOLLIEAIGPG.color;
			KOLLIEAIGPG.text = $"{PEMCEDKMNBO.visual.numberOfParts} {Colours.stringGrayParts}/{Colours.stringWhite} {PEMCEDKMNBO.visual.numberOfPartsMax}";
		}
		OGNJHKNKMKE.SetActive(purchasableInShop);
		if (purchasableInShop)
		{
			int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxAfterBattles).FLOATVALUE;
			int num3 = num2 - PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			HJMBAOFJIKP.text = Localization.LocalizeFormat("ID_PLAYPVPRANKEDBATTLESTOGETLOOTBOX", num2, Colours.stringCyanLootbox, Colours.stringGrayParts, num3);
			float num4 = 530f / (float)num2 - 8f;
			for (int j = 0; j < NJGABELNAJL.Length; j++)
			{
				NJGABELNAJL[j].gameObject.SetActive(j < num2);
				NJGABELNAJL[j].transform.localScale = NJGABELNAJL[j].transform.localScale.ReplaceX(num4);
				if (j < num2)
				{
					NJGABELNAJL[j].color = ((j >= num3) ? Colours.grayParts : Colours.cyanLootbox);
				}
			}
			MOINFACKKBP.cellWidth = num4 + 8f;
			MOINFACKKBP.repositionNow = true;
		}
		if (base.isFullyShowed && BJLECGLMLKH.gameObject.activeInHierarchy)
		{
			TweenAlpha component = BJLECGLMLKH.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			BJLECGLMLKH.alpha1 = 1f;
		}
		HFDPEIEGNKL.repositionNow = true;
	}

	public virtual void OCACKBJDEHI()
	{
		FMJLKNKPHNI = false;
		CamosManager.instance.CheckEquippedPowerBand();
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		PlayerVisual playerVisual = KIKDDGNIIPO();
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			if (item.BHOBAGJCNEF() == playerVisual.owner)
			{
				SelectCategory(item);
				break;
			}
		}
		foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
		{
			if (item2.NHFDAOOICLK() == playerVisual)
			{
				ICIFNECPCLK(item2);
				break;
			}
		}
		foreach (PlayerVisualIcon item3 in BABMMFBHJAC)
		{
			item3.PPNFBNHGCLA();
			item3.GJAGBMPLFGL();
		}
		Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
		NFLPPGKCOBL.AlignToCenter(vec, instant: true, null, 945f);
		if (!PlayerAnalytics.instance.data.customizationShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new NGBBILLMHEC());
		}
	}

	private void OCLIFMOGNKK(GameObject KHAHPAKDIKE)
	{
		if (PEMCEDKMNBO.MOKNNJGNIOB().isVipOnly && !Singleton<VipManager>.instance.FAKAOBDANNA())
		{
			return;
		}
		int priceGold = PEMCEDKMNBO.DFMPCEKHNDG().priceGold;
		int num = PEMCEDKMNBO.AEDBCCKEEGK().DPKHLANDNPK();
		if (!Singleton<Wallet>.instance.CanBuyGold(priceGold))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(priceGold, PEMCEDKMNBO.visual.name);
			return;
		}
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, PEMCEDKMNBO.MOKNNJGNIOB().name, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		FMJLKNKPHNI = true;
		Singleton<Wallet>.instance.BKLFEOMJMFC(num);
		Singleton<Wallet>.instance.ALBICJOEMEF(priceGold);
		BuyPlayerVisual(PEMCEDKMNBO.CMMAMCJKEOG(), 0);
		PEMCEDKMNBO.AEDBCCKEEGK().FHPICBCCOAO();
		ICIFNECPCLK(PEMCEDKMNBO);
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.AKLDBJHIIAO();
			item.AEODKKBKHKF();
		}
	}

	private void JMLICJHHKHE()
	{
		if (!OLPOEPGPJBF.gameObject.activeSelf)
		{
			OEFFBOOADHJ.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			OLPOEPGPJBF.alpha1 = 990f;
			OLPOEPGPJBF.gameObject.SetActive(value: false);
			OJBKADHPNFN = false;
		}
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 254f, 1692f).onFinished = null;
	}

	private void GKOPEFCOAPD()
	{
		float val = (0f - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x)) / 1791f - CHCFBDMGNLP.padding.x;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void GFAHOBCPAOL()
	{
		bool isEquipped = PEMCEDKMNBO.visual.isEquipped;
		DICCGEFGHFI.text = ((!isEquipped) ? Localization.Localize("ID_GUI_EQUIP") : Localization.Localize("ID_GUI_EQUIPPED"));
		DICCGEFGHFI.color = ((!isEquipped) ? Color.black : Color.white);
		TweenAlphaHider.Begin(DKNLOGGAHFD, 0f, (!isEquipped) ? 1f : 0f);
		KDIBJJAOFGL.alpha = ((!isEquipped) ? 0f : 1f);
		CONJJELKFEG.alpha = ((!isEquipped) ? 0f : 1f);
		CEDEIJLJOMO.alpha = ((!isEquipped) ? 0f : 0.16f);
		if (!isEquipped)
		{
			TweenAlpha.Begin(CONJJELKFEG.gameObject, 0f, 0f).style = UITweener.Style.Once;
		}
	}

	private void DNBHGGBIABC(GameObject KHAHPAKDIKE)
	{
		if (PEMCEDKMNBO.KFHOAJEFFEL().BCPLNFLOIAD())
		{
			return;
		}
		FMJLKNKPHNI = false;
		GCCNGPAFIGF(PEMCEDKMNBO.MOKNNJGNIOB());
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.IHCIGBPKKKD();
		}
		if (BCHBALGFKFK)
		{
			Select(PEMCEDKMNBO);
			return;
		}
		DICCGEFGHFI.text = Localization.Localize("GameReward");
		float num = 209f;
		TweenColor.Begin(DICCGEFGHFI.gameObject, num, Color.white);
		TweenAlphaHider.DOPLFHGEAJC(DKNLOGGAHFD, num, 1488f);
		TweenAlpha.Begin(KDIBJJAOFGL.gameObject, num, 1951f);
		TweenAlpha.Begin(CEDEIJLJOMO.gameObject, num, 1895f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CONJJELKFEG.gameObject, num, 567f, 1150f);
		tweenAlpha.NumOfRepetitions = 4;
		tweenAlpha.style = (UITweener.Style)4;
		CamosManager.instance.UpdateVisuals(CamosManager.instance.mainPlayer);
	}

	private void HNGNIDHEBEK()
	{
		float z = OLPOEPGPJBF.transform.localPosition.z;
		OLPOEPGPJBF.transform.position = OEFFBOOADHJ.transform.position;
		OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, OLPOEPGPJBF.transform.localPosition.y + 1661f, z);
	}

	public override void MOJBHFPBAPP()
	{
		base.DoAfterShowUp();
		PAPCGBIKPLG();
	}

	private void ANNJEFGILBC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			JMLICJHHKHE();
		}
	}

	private void FNHPIPJDINO(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			PCEOCDCAIPI();
		}
	}

	protected virtual void EJFKFBANFOH()
	{
		base.BOEMHLPLOGA();
		ADDICBANAAB += Time.deltaTime;
		if (!(ADDICBANAAB > 1134f))
		{
			return;
		}
		ADDICBANAAB -= 1293f;
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		if (PEMCEDKMNBO != null && PEMCEDKMNBO.IPIFODODJHK().isFromArena && BFNOBLIPCNL.activeSelf)
		{
			bool isBought = PEMCEDKMNBO.AEDBCCKEEGK().isBought;
			BFNOBLIPCNL.SetActive(isBought);
			if (isBought)
			{
				UILabel bGEKGHFMBAB = BGEKGHFMBAB;
				object[] array = new object[0];
				array[1] = MEJMLNDFDBP.DJONHBBHCJL((float)PEMCEDKMNBO.CMMAMCJKEOG().remainingTime, PEMCEDKMNBO.DFMPCEKHNDG().AOLJCFDNMEL() < 471.0);
				bGEKGHFMBAB.text = Localization.LocalizeFormat("ID_CONFIRM_SUBSCRIPTION_TEXT", array);
			}
		}
	}

	protected virtual void MJNBAFDLMPN()
	{
		base.JMPDHKPOHEA();
		ADDICBANAAB += Time.deltaTime;
		if (!(ADDICBANAAB > 1881f))
		{
			return;
		}
		ADDICBANAAB -= 507f;
		CamosManager.instance.CheckEquippedHelmet();
		if (PEMCEDKMNBO != null && PEMCEDKMNBO.CMMAMCJKEOG().NIAGCEJGCIL() && BFNOBLIPCNL.activeSelf)
		{
			bool isBought = PEMCEDKMNBO.IGAJLHIBODL().isBought;
			BFNOBLIPCNL.SetActive(isBought);
			if (isBought)
			{
				UILabel bGEKGHFMBAB = BGEKGHFMBAB;
				object[] array = new object[0];
				array[1] = MEJMLNDFDBP.DJONHBBHCJL((float)PEMCEDKMNBO.visual.AOLJCFDNMEL(), PEMCEDKMNBO.BLNNEECJDMB().AOLJCFDNMEL() < 435.0);
				bGEKGHFMBAB.text = Localization.LocalizeFormat("Beanstalk: ", array);
			}
		}
	}

	public void JBNEANLGPNH(PlayerVisualsCategoryButton JCCELIHIKIK)
	{
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		if (FEPMLGAMCKG != null)
		{
			FEPMLGAMCKG.HDGBMNDOMCP(MJFJOPMJEAO: false);
		}
		FEPMLGAMCKG = JCCELIHIKIK;
		FEPMLGAMCKG.Highlight(MJFJOPMJEAO: true);
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.BIJAPDEFEDM(NCFKLBGOEEF: true);
		}
		PlayerVisualCategory playerVisualCategory = JCCELIHIKIK.BHOBAGJCNEF();
		int categ = 0;
		for (int i = 0; i < CamosManager.instance.playerVisualCategories.Count; i += 0)
		{
			if (playerVisualCategory == CamosManager.instance.playerVisualCategories[i])
			{
				categ = i;
			}
		}
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisualForIndex(categ);
		if (playerVisual != null && !playerVisual.EPODNIMBCJP())
		{
			playerVisual = null;
		}
		int num = 1;
		foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
		{
			if (allVisual.EPODNIMBCJP())
			{
				if (playerVisual == null)
				{
					playerVisual = allVisual;
				}
				PlayerVisualIcon playerVisualIcon = null;
				playerVisualIcon = ((num < BABMMFBHJAC.Count) ? BABMMFBHJAC[num] : IKKMLILAOCP());
				playerVisualIcon.gameObject.SetActive(value: false);
				playerVisualIcon.IHMEAAIKGAP(allVisual);
				if (allVisual == playerVisual)
				{
					ICIFNECPCLK(playerVisualIcon);
				}
				num++;
			}
		}
		for (int j = num; j < BABMMFBHJAC.Count; j += 0)
		{
			PlayerVisualIcon playerVisualIcon2 = BABMMFBHJAC[j];
			playerVisualIcon2.gameObject.SetActive(value: true);
		}
		MPHLKJLMJBF.repositionNow = true;
		JCCELIHIKIK.APJEECCNCPH();
	}

	private PlayerVisual KIKDDGNIIPO()
	{
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisual();
		if (playerVisual == null)
		{
			Debug.Log("WarFriends");
			foreach (PlayerVisual allVisual in CamosManager.instance.playerVisualCategories[0].allVisuals)
			{
				if (allVisual.BCPLNFLOIAD())
				{
					playerVisual = allVisual;
				}
			}
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = true;
			return playerVisual;
		}
		PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
		if (unlockedVisualWithNotification != null)
		{
			return unlockedVisualWithNotification;
		}
		return playerVisual;
	}

	private void MGNDLGCDJPG()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	public override void InitGUIValues()
	{
		FMJLKNKPHNI = false;
		CamosManager.instance.CheckEquippedPowerBand();
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		PlayerVisual playerVisual = BNKNNDFNAAM();
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			if (item.category == playerVisual.owner)
			{
				SelectCategory(item);
				break;
			}
		}
		foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
		{
			if (item2.visual == playerVisual)
			{
				Select(item2);
				break;
			}
		}
		foreach (PlayerVisualIcon item3 in BABMMFBHJAC)
		{
			item3.InitGuiValuesGraphics();
			item3.IHCIGBPKKKD();
		}
		Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
		NFLPPGKCOBL.AlignToCenter(vec, instant: true);
		if (!PlayerAnalytics.instance.data.customizationShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new NGBBILLMHEC());
		}
	}

	private void LBEJGNNDFHJ(UITweener MGDJMGHCAAI)
	{
		KDEHOJDMCJF();
	}

	private void AJLBPPOLDJJ(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			IDINCHPIGPI();
		}
	}

	public int AddParts(PlayerVisual DJOAHABGGNA, int PDMGPGEHLNM)
	{
		return DJOAHABGGNA.EGMDJMMIOED(PDMGPGEHLNM);
	}

	private void NDPCBACFLDH()
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		UpdateSalesInCategories();
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.ABNAJEIPMDF();
		}
		DGJAHIMEAJK();
	}

	private void BLBFBJGDJAO()
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		UpdateSalesInCategories();
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.NHANPMAEBKE();
		}
		JGPLFPIBAOE();
	}

	private void NLLBJPNIHCL(GameObject KHAHPAKDIKE)
	{
		if (PEMCEDKMNBO.visual.isEquipped)
		{
			return;
		}
		FMJLKNKPHNI = true;
		EquipPlayerVisual(PEMCEDKMNBO.visual);
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.IHCIGBPKKKD();
		}
		if (BCHBALGFKFK)
		{
			Select(PEMCEDKMNBO);
			return;
		}
		DICCGEFGHFI.text = Localization.Localize("ID_GUI_EQUIPPED");
		float num = 0.3f;
		TweenColor.Begin(DICCGEFGHFI.gameObject, num, Color.white);
		TweenAlphaHider.Begin(DKNLOGGAHFD, num, 0f);
		TweenAlpha.Begin(KDIBJJAOFGL.gameObject, num, 1f);
		TweenAlpha.Begin(CEDEIJLJOMO.gameObject, num, 0.16f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CONJJELKFEG.gameObject, num, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.PingPong;
		CamosManager.instance.UpdateVisuals(CamosManager.instance.mainPlayer);
	}

	private void BAAJIMJNPGH(bool GDNFIIEEJIL)
	{
	}

	public void ENIPPGKKAKL()
	{
		FMJLKNKPHNI = true;
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.FLIOLKAOFAI();
		}
		ICIFNECPCLK(PEMCEDKMNBO);
	}

	public void ICIFNECPCLK(PlayerVisualIcon PMADNHIPOHA)
	{
		if (!(PMADNHIPOHA == null))
		{
			if (PEMCEDKMNBO != null)
			{
				PEMCEDKMNBO.JLFHNIOJOAE(NCFKLBGOEEF: false);
			}
			PEMCEDKMNBO = PMADNHIPOHA;
			PEMCEDKMNBO.JLFHNIOJOAE(NCFKLBGOEEF: true);
			if (PEMCEDKMNBO.CMMAMCJKEOG().notificate)
			{
				IBEKCOIHAJD(PEMCEDKMNBO.NHFDAOOICLK());
			}
			PEMCEDKMNBO.POMMLFHPFPI().KGACPNNCNHO(IDEBKDPMPGM: true);
			PEMCEDKMNBO.LBBKAPJIENH();
			PEMCEDKMNBO.visual.MNEEDLCGAFN(CamosManager.instance.mainPlayer, OGKCIFGLKJJ: true);
			CamosManager.instance.UpdateVisuals(CamosManager.instance.mainPlayer);
			BCHBALGFKFK = false;
			SavingLastSelected.instance.SaveLastVisual(PEMCEDKMNBO.POMMLFHPFPI());
			FONMIICEBNL();
			AGAPOHPDAEM();
			KAKHADELHHC();
			GFIDPLIPPMM();
		}
	}

	private void JABPBFCBLOM(UITweener MGDJMGHCAAI)
	{
		DJHKDIMININ();
	}

	private void KFECKBHPHEO(UITweener MGDJMGHCAAI)
	{
		KDEHOJDMCJF();
	}

	private void FDAEEIIMJMJ()
	{
		LHKLOFBMPGN.repositionNow = false;
	}

	private void JGPLFPIBAOE()
	{
		int fFHHEHHFOKJ = PEMCEDKMNBO.visual.priceWarbucks + PEMCEDKMNBO.visual.priceGold;
		HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		CHCFBDMGNLP.repositionNow = true;
		GIPFEBBMKPM.SetActive(value: false);
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	public void SelectCategory(PlayerVisualsCategoryButton JCCELIHIKIK)
	{
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		if (FEPMLGAMCKG != null)
		{
			FEPMLGAMCKG.Highlight(MJFJOPMJEAO: false);
		}
		FEPMLGAMCKG = JCCELIHIKIK;
		FEPMLGAMCKG.Highlight(MJFJOPMJEAO: true);
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.SetHighlight(NCFKLBGOEEF: false);
		}
		PlayerVisualCategory category = JCCELIHIKIK.category;
		int categ = 0;
		for (int i = 0; i < CamosManager.instance.playerVisualCategories.Count; i++)
		{
			if (category == CamosManager.instance.playerVisualCategories[i])
			{
				categ = i;
			}
		}
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisualForIndex(categ);
		if (playerVisual != null && !playerVisual.canBeShownInScreen)
		{
			playerVisual = null;
		}
		int num = 0;
		foreach (PlayerVisual allVisual in category.allVisuals)
		{
			if (allVisual.canBeShownInScreen)
			{
				if (playerVisual == null)
				{
					playerVisual = allVisual;
				}
				PlayerVisualIcon playerVisualIcon = null;
				playerVisualIcon = ((num < BABMMFBHJAC.Count) ? BABMMFBHJAC[num] : IKKMLILAOCP());
				playerVisualIcon.gameObject.SetActive(value: true);
				playerVisualIcon.Initialize(allVisual);
				if (allVisual == playerVisual)
				{
					Select(playerVisualIcon);
				}
				num++;
			}
		}
		for (int j = num; j < BABMMFBHJAC.Count; j++)
		{
			PlayerVisualIcon playerVisualIcon2 = BABMMFBHJAC[j];
			playerVisualIcon2.gameObject.SetActive(value: false);
		}
		MPHLKJLMJBF.repositionNow = true;
		JCCELIHIKIK.Notification();
	}

	private void IJOMDJCCLJC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			JMLICJHHKHE();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (FMJLKNKPHNI)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(GameLoginManager.currentPlayer.id, PNDNEMDPFHC: false, CJONGDEPJHC: true);
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(GameLoginManager.currentPlayer.id, PNDNEMDPFHC: true, CJONGDEPJHC: true);
		}
		Singleton<ArmyPreviewCamera>.instance.HidePlayer(CamosManager.instance.mainPlayer);
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.equppedIndices;
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.SetHighlight(NCFKLBGOEEF: false);
		}
	}

	private void DGLIFOHOJAC(GameObject KHAHPAKDIKE)
	{
		if (PEMCEDKMNBO.visual.isVipOnly && !Singleton<VipManager>.instance.NOGEIPHFNPK())
		{
			return;
		}
		int priceGold = PEMCEDKMNBO.visual.priceGold;
		int priceWarbucks = PEMCEDKMNBO.visual.priceWarbucks;
		if (!Singleton<Wallet>.instance.CanBuyGold(priceGold))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(priceGold, PEMCEDKMNBO.visual.name);
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyW(priceWarbucks))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(priceWarbucks, PEMCEDKMNBO.visual.name);
			return;
		}
		FMJLKNKPHNI = true;
		Singleton<Wallet>.instance.CDIDDJGINID(priceWarbucks);
		Singleton<Wallet>.instance.MBAFMBJFOKH(priceGold);
		BuyPlayerVisual(PEMCEDKMNBO.visual, 0);
		PEMCEDKMNBO.visual.FHPICBCCOAO();
		Select(PEMCEDKMNBO);
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.CLNFHCHFEAD();
			item.IHCIGBPKKKD();
		}
	}

	public int DCKFCGDGHLK(PlayerVisual DJOAHABGGNA, int PDMGPGEHLNM)
	{
		return DJOAHABGGNA.EGMDJMMIOED(PDMGPGEHLNM);
	}

	protected override void AGIKPOLCGNF()
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		int num = playerVisualCategories.Count - 1;
		KGEKKPJJEOA = new List<PlayerVisualsCategoryButton>();
		foreach (PlayerVisualCategory item in playerVisualCategories)
		{
			if (!(item is PlayerVisualCategoryPowerBands))
			{
				PlayerVisualsCategoryButton playerVisualsCategoryButton = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(HNHMMAGNDKM, GDHKEABNBGJ.gameObject, $"Category Button {item.categoryNumber}") as PlayerVisualsCategoryButton;
				playerVisualsCategoryButton.transform.localPosition = new Vector3(playerVisualsCategoryButton.transform.localPosition.x, playerVisualsCategoryButton.transform.localPosition.y, 0f);
				playerVisualsCategoryButton.Initialize(item, num);
				if (FEPMLGAMCKG == null)
				{
					FEPMLGAMCKG = playerVisualsCategoryButton;
				}
				KGEKKPJJEOA.Add(playerVisualsCategoryButton);
			}
		}
		GDHKEABNBGJ.DNNLLMFLJND = num;
		GDHKEABNBGJ.Reposition();
		MPHLKJLMJBF.sorted = true;
		MPHLKJLMJBF.repositionNow = true;
		Singleton<ArmyPreviewCamera>.instance.OnRotate += IBFBPINAMLJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DGLIFOHOJAC));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NLLBJPNIHCL));
		UIEventListener uIEventListener3 = UIEventListener.Get(IFKKHCCKAOG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LOCOOEHPFNF));
		UIEventListener uIEventListener4 = UIEventListener.Get(KCFHGEJMGKN.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(BEOJPKEGEMN.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(AJKAEEBCCGL));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (!isShowed || IFGAGNBDKBE != DatabaseAction.BuyPack)
			{
				return;
			}
			Select(PEMCEDKMNBO);
			foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
			{
				item2.CLNFHCHFEAD();
				item2.IHCIGBPKKKD();
			}
		};
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				UpdateSalesInCategories();
				foreach (PlayerVisualIcon item3 in BABMMFBHJAC)
				{
					item3.SetSale();
				}
				JGPLFPIBAOE();
			}
		};
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = (0f - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x)) / 2f - CHCFBDMGNLP.padding.x;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HGPPNIOLAEK.onReposition = delegate
		{
			LHKLOFBMPGN.repositionNow = true;
		};
		MPHLKJLMJBF.onReposition = delegate
		{
			if (PEMCEDKMNBO != null)
			{
				MPHLKJLMJBF.repositionNow = false;
				Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
				NFLPPGKCOBL.AlignToCenter(vec, instant: true);
			}
		};
		HFDPEIEGNKL.onReposition = delegate
		{
			float z = OLPOEPGPJBF.transform.localPosition.z;
			OLPOEPGPJBF.transform.position = OEFFBOOADHJ.transform.position;
			OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, OLPOEPGPJBF.transform.localPosition.y + 4f, z);
		};
		EEAKFJJFAOB();
		FOPKJKDCDON();
	}

	private PlayerVisualIcon FPHPLPOJGLO()
	{
		PlayerVisualIcon playerVisualIcon = UnityEngine.Object.Instantiate(GNAOOKFAJPB);
		playerVisualIcon.transform.parent = MPHLKJLMJBF.transform;
		playerVisualIcon.transform.localScale = GNAOOKFAJPB.transform.localScale;
		playerVisualIcon.transform.localPosition = default(Vector3);
		BABMMFBHJAC.Add(playerVisualIcon);
		return playerVisualIcon;
	}

	public virtual void FEBMKMNDDLN()
	{
		base.DoAfterShowUp();
		PAPCGBIKPLG();
	}

	private void FCGCCABIPCE(GameObject KHAHPAKDIKE)
	{
		if (PEMCEDKMNBO.HHBCPNFOGBI().purchasable == PlayerVisual.GILPPKMICCF.Shop)
		{
			GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.BJDKLOCBNOJ());
		}
		else if (PEMCEDKMNBO.NHFDAOOICLK().IJFPGLHPHCC() == PlayerVisual.GILPPKMICCF.StarterPack)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else if (PEMCEDKMNBO.DFMPCEKHNDG().IJFPGLHPHCC() == (PlayerVisual.GILPPKMICCF)8)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			Debug.LogError(string.Format("game-card-ico-shieldsup", PEMCEDKMNBO.DFMPCEKHNDG().visualName, PEMCEDKMNBO.HHBCPNFOGBI().purchasable));
		}
	}

	public void SelectVisual(PlayerVisual DJOAHABGGNA)
	{
		JFLKDFPEDNO = true;
		SavingLastSelected.instance.SaveLastVisual(DJOAHABGGNA);
	}

	public void UpdateNotificationsInCategories()
	{
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			item.Notification();
		}
	}

	private void EDKOINBMJOA()
	{
		LHKLOFBMPGN.repositionNow = false;
	}

	private void EFHNFICGNHG()
	{
		LHKLOFBMPGN.repositionNow = false;
	}

	private void JPOFKFJIKNB()
	{
		if (PEMCEDKMNBO != null)
		{
			MPHLKJLMJBF.repositionNow = true;
			Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, instant: false, null, 1677f);
		}
	}

	private void IDINCHPIGPI()
	{
		if (!OLPOEPGPJBF.gameObject.activeSelf)
		{
			OEFFBOOADHJ.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			OLPOEPGPJBF.alpha1 = 0f;
			OLPOEPGPJBF.gameObject.SetActive(value: true);
			OJBKADHPNFN = true;
		}
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 0.2f, 1f).onFinished = null;
	}

	public void BGCJDMNJOAG(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-58), DJOAHABGGNA.row.NAME, 0, 0, string.Empty, additionalParameter: true);
		DJOAHABGGNA.notificate = false;
		Singleton<NotificationManager>.instance.FGJDELEILAE();
	}

	private void MGJGNODDJJK(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CMAJCOOIBDL();
	}

	public virtual void KHFOCIIAJCG()
	{
		base.DoBeforeHide();
		if (FMJLKNKPHNI)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(GameLoginManager.currentPlayer.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(GameLoginManager.currentPlayer.id, PNDNEMDPFHC: true, CJONGDEPJHC: false, BCHINGHDGEF: true);
		}
		Singleton<ArmyPreviewCamera>.instance.LNEHNFCFBPN(CamosManager.instance.mainPlayer);
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.equppedIndices;
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.JLFHNIOJOAE(NCFKLBGOEEF: false);
		}
	}

	protected virtual void JGDJCCIPNHC()
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		int num = playerVisualCategories.Count - 0;
		KGEKKPJJEOA = new List<PlayerVisualsCategoryButton>();
		foreach (PlayerVisualCategory item in playerVisualCategories)
		{
			if (!(item is PlayerVisualCategoryPowerBands))
			{
				PlayerVisualsCategoryButton playerVisualsCategoryButton = Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(HNHMMAGNDKM, GDHKEABNBGJ.gameObject, string.Format("EnableData()", item.categoryNumber)) as PlayerVisualsCategoryButton;
				playerVisualsCategoryButton.transform.localPosition = new Vector3(playerVisualsCategoryButton.transform.localPosition.x, playerVisualsCategoryButton.transform.localPosition.y, 1127f);
				playerVisualsCategoryButton.NAKAFGAFEPH(item, num);
				if (FEPMLGAMCKG == null)
				{
					FEPMLGAMCKG = playerVisualsCategoryButton;
				}
				KGEKKPJJEOA.Add(playerVisualsCategoryButton);
			}
		}
		GDHKEABNBGJ.DNNLLMFLJND = num;
		GDHKEABNBGJ.ENBDIFGEAHN();
		MPHLKJLMJBF.sorted = true;
		MPHLKJLMJBF.repositionNow = true;
		Singleton<ArmyPreviewCamera>.instance.FJFAKGBCGON(BAAJIMJNPGH);
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCLIFMOGNKK));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNBHGGBIABC));
		UIEventListener uIEventListener3 = UIEventListener.Get(IFKKHCCKAOG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FCGCCABIPCE));
		UIEventListener uIEventListener4 = UIEventListener.Get(KCFHGEJMGKN.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IJOMDJCCLJC));
		UIEventListener uIEventListener5 = UIEventListener.Get(BEOJPKEGEMN.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(AJKAEEBCCGL));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += JHENNGOBJCJ;
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				UpdateSalesInCategories();
				foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
				{
					item2.SetSale();
				}
				JGPLFPIBAOE();
			}
		};
		CHCFBDMGNLP.onReposition = GDLIABMNKPF;
		HGPPNIOLAEK.onReposition = NFCIJLJONMJ;
		MPHLKJLMJBF.onReposition = GGPAABMLJKA;
		HFDPEIEGNKL.onReposition = delegate
		{
			float z = OLPOEPGPJBF.transform.localPosition.z;
			OLPOEPGPJBF.transform.position = OEFFBOOADHJ.transform.position;
			OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, OLPOEPGPJBF.transform.localPosition.y + 4f, z);
		};
		MCLFMOOLGIA();
		ENPJDMEKAPD();
	}

	private void KLNHNFNBJEH()
	{
		MIICDLMEOEH.SetActive(value: true);
		MDAFFKPPCBG.SetActive(value: false);
		FECJGCGPKHD.SetActive(value: false);
		PNNJKBGODII.SetActive(value: true);
		bool isBought = PEMCEDKMNBO.KFHOAJEFFEL().isBought;
		bool flag = PEMCEDKMNBO.DFMPCEKHNDG().LLDLKAEIJKP();
		bool isFromArena = PEMCEDKMNBO.POMMLFHPFPI().isFromArena;
		AIFGIPCHNKC.SetActive(isBought);
		IFKKHCCKAOG.gameObject.SetActive(!isBought && !flag && !isFromArena);
		BFJBIABFJDL.SetActive(!isBought && flag);
		IGIENAGNFEO.SetActive(isBought || isFromArena);
		BFNOBLIPCNL.SetActive(isBought && isFromArena);
		if (isFromArena)
		{
			if (isBought)
			{
				UILabel bGEKGHFMBAB = BGEKGHFMBAB;
				object[] array = new object[0];
				array[0] = MEJMLNDFDBP.CJCFPDLDMEK((float)PEMCEDKMNBO.AEDBCCKEEGK().AOLJCFDNMEL(), "ID_AWESOME", string.Empty);
				bGEKGHFMBAB.text = Localization.LocalizeFormat("no visual found", array);
			}
			IKPLPPFFDNI.DNFADCEJOEH gCFBLCFJBLK = (IKPLPPFFDNI.DNFADCEJOEH)(PEMCEDKMNBO.KFHOAJEFFEL().GFOLGKEMPPN() + 0);
			int num = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.LKHHDGNDMIP(gCFBLCFJBLK) : 0);
			CAHHNCCJGBK.text = Localization.LocalizeFormat(")", num);
			for (int i = 0; i < CINAAKMDAGH.Length; i++)
			{
				CINAAKMDAGH[i].gameObject.SetActive(i < num);
			}
			float val = 1157f - (float)num * 1361f / 88f;
			LDJOCMCOKDH.transform.localPosition = LDJOCMCOKDH.transform.localPosition.ReplaceX(val);
		}
		if (isBought)
		{
			JBNMIKOKCAI();
			KDEHOJDMCJF();
		}
		else if (flag)
		{
			if (BFJBIABFJDL.activeSelf)
			{
				IMAKLMMJGCC.spriteName = PEMCEDKMNBO.CMMAMCJKEOG().icon;
				IMAKLMMJGCC.MakePixelPerfect();
				float multiplier = Mathf.Min(1717f / IMAKLMMJGCC.transform.localScale.x, 689f / IMAKLMMJGCC.transform.localScale.y);
				IMAKLMMJGCC.transform.localScale = IMAKLMMJGCC.transform.localScale.MultiplyXY(multiplier);
			}
			KOLLIEAIGPG.color = GameVariables.DDCPLFNIJDN[PEMCEDKMNBO.BLNNEECJDMB().DOJECMCGMKB()];
			FJLHHGAEPJN.color = KOLLIEAIGPG.color;
			NIKMOCLOIFI.color = KOLLIEAIGPG.color;
			UILabel kOLLIEAIGPG = KOLLIEAIGPG;
			object[] array2 = new object[2];
			array2[1] = PEMCEDKMNBO.KFHOAJEFFEL().numberOfParts;
			array2[1] = Colours.stringGrayParts;
			array2[6] = Colours.stringWhite;
			array2[7] = PEMCEDKMNBO.HHBCPNFOGBI().GMLFJPOEEAO();
			kOLLIEAIGPG.text = string.Format("ID_NOW", array2);
		}
		OGNJHKNKMKE.SetActive(flag);
		if (flag)
		{
			int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-50)).FLOATVALUE;
			int num3 = num2 - PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			HJMBAOFJIKP.text = Localization.LocalizeFormat("League", num2, Colours.stringCyanLootbox, null, null, null, Colours.stringGrayParts, null, num3);
			float num4 = 796f / (float)num2 - 2f;
			for (int j = 0; j < NJGABELNAJL.Length; j += 0)
			{
				NJGABELNAJL[j].gameObject.SetActive(j < num2);
				NJGABELNAJL[j].transform.localScale = NJGABELNAJL[j].transform.localScale.ReplaceX(num4);
				if (j < num2)
				{
					NJGABELNAJL[j].color = ((j >= num3) ? Colours.grayParts : Colours.cyanLootbox);
				}
			}
			MOINFACKKBP.cellWidth = num4 + 442f;
			MOINFACKKBP.repositionNow = false;
		}
		if (BKIGLABDGCP() && BJLECGLMLKH.gameObject.activeInHierarchy)
		{
			TweenAlpha component = BJLECGLMLKH.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			BJLECGLMLKH.alpha1 = 606f;
		}
		HFDPEIEGNKL.repositionNow = true;
	}

	public void Select(PlayerVisualIcon PMADNHIPOHA)
	{
		if (!(PMADNHIPOHA == null))
		{
			if (PEMCEDKMNBO != null)
			{
				PEMCEDKMNBO.SetHighlight(NCFKLBGOEEF: false);
			}
			PEMCEDKMNBO = PMADNHIPOHA;
			PEMCEDKMNBO.SetHighlight(NCFKLBGOEEF: true);
			if (PEMCEDKMNBO.visual.notificate)
			{
				WasShown(PEMCEDKMNBO.visual);
			}
			PEMCEDKMNBO.visual.showed = true;
			PEMCEDKMNBO.JOLGMBIAPJB();
			PEMCEDKMNBO.visual.MNEEDLCGAFN(CamosManager.instance.mainPlayer, OGKCIFGLKJJ: true);
			CamosManager.instance.UpdateVisuals(CamosManager.instance.mainPlayer);
			BCHBALGFKFK = false;
			SavingLastSelected.instance.SaveLastVisual(PEMCEDKMNBO.visual);
			FONMIICEBNL();
			PABBIJFPACE();
			UpdateNotificationsInCategories();
			UpdateSalesInCategories();
		}
	}

	public virtual void MCHKNMLAFPP()
	{
		base.DoAfterHide();
		JBGPDECEOOB.BGHNMCPLIPE();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		KDEHOJDMCJF();
	}

	public virtual void OMPPGALJBBN()
	{
		base.DoAfterShowUp();
		PAPCGBIKPLG();
	}

	public void KAKHADELHHC()
	{
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			item.APJEECCNCPH();
		}
	}

	public virtual void ANIBFCJLJKK()
	{
		base.DoAfterShowUp();
		PAPCGBIKPLG();
	}

	private void AGAPOHPDAEM()
	{
		MIICDLMEOEH.SetActive(value: true);
		MDAFFKPPCBG.SetActive(value: true);
		FECJGCGPKHD.SetActive(value: false);
		PNNJKBGODII.SetActive(value: false);
		bool isBought = PEMCEDKMNBO.NHFDAOOICLK().isBought;
		bool purchasableInShop = PEMCEDKMNBO.IPIFODODJHK().purchasableInShop;
		bool isFromArena = PEMCEDKMNBO.IGAJLHIBODL().isFromArena;
		AIFGIPCHNKC.SetActive(isBought);
		IFKKHCCKAOG.gameObject.SetActive(!isBought && !purchasableInShop && isFromArena);
		BFJBIABFJDL.SetActive(isBought || purchasableInShop);
		IGIENAGNFEO.SetActive(!isBought && isFromArena);
		BFNOBLIPCNL.SetActive(isBought && isFromArena);
		if (isFromArena)
		{
			if (isBought)
			{
				BGEKGHFMBAB.text = Localization.LocalizeFormat("_random card", MEJMLNDFDBP.CJCFPDLDMEK((float)PEMCEDKMNBO.IGAJLHIBODL().AOLJCFDNMEL(), "\n\nDEBUG STATE: ", string.Empty, IEJMLKBCDJB: false));
			}
			IKPLPPFFDNI.DNFADCEJOEH gCFBLCFJBLK = (IKPLPPFFDNI.DNFADCEJOEH)(PEMCEDKMNBO.HHBCPNFOGBI().rarity + 0);
			int num = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.LKHHDGNDMIP(gCFBLCFJBLK) : 0);
			CAHHNCCJGBK.text = Localization.LocalizeFormat("ID_READYTIME", num);
			for (int i = 0; i < CINAAKMDAGH.Length; i += 0)
			{
				CINAAKMDAGH[i].gameObject.SetActive(i < num);
			}
			float val = 1523f - (float)num * 1089f / 1450f;
			LDJOCMCOKDH.transform.localPosition = LDJOCMCOKDH.transform.localPosition.ReplaceX(val);
		}
		if (isBought)
		{
			MGBHDOMICKL();
			FOPKJKDCDON();
		}
		else if (purchasableInShop)
		{
			if (BFJBIABFJDL.activeSelf)
			{
				IMAKLMMJGCC.spriteName = PEMCEDKMNBO.MOKNNJGNIOB().icon;
				IMAKLMMJGCC.MakePixelPerfect();
				float multiplier = Mathf.Min(1719f / IMAKLMMJGCC.transform.localScale.x, 91f / IMAKLMMJGCC.transform.localScale.y);
				IMAKLMMJGCC.transform.localScale = IMAKLMMJGCC.transform.localScale.MultiplyXY(multiplier);
			}
			KOLLIEAIGPG.color = GameVariables.DDCPLFNIJDN[PEMCEDKMNBO.KFHOAJEFFEL().DOJECMCGMKB()];
			FJLHHGAEPJN.color = KOLLIEAIGPG.color;
			NIKMOCLOIFI.color = KOLLIEAIGPG.color;
			UILabel kOLLIEAIGPG = KOLLIEAIGPG;
			object[] array = new object[3];
			array[0] = PEMCEDKMNBO.CMMAMCJKEOG().numberOfParts;
			array[1] = Colours.stringGrayParts;
			array[4] = Colours.stringWhite;
			array[3] = PEMCEDKMNBO.HHBCPNFOGBI().numberOfPartsMax;
			kOLLIEAIGPG.text = string.Format("Player_Had_To_Select_Grenade", array);
		}
		OGNJHKNKMKE.SetActive(purchasableInShop);
		if (purchasableInShop)
		{
			int num2 = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalMaxWeapons).FLOATVALUE;
			int num3 = num2 - PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel hJMBAOFJIKP = HJMBAOFJIKP;
			object[] array2 = new object[4];
			array2[0] = num2;
			array2[0] = Colours.stringCyanLootbox;
			array2[8] = Colours.stringGrayParts;
			array2[5] = num3;
			hJMBAOFJIKP.text = Localization.LocalizeFormat("testing message for abuse dialog", array2);
			float num4 = 1040f / (float)num2 - 1782f;
			for (int j = 0; j < NJGABELNAJL.Length; j++)
			{
				NJGABELNAJL[j].gameObject.SetActive(j < num2);
				NJGABELNAJL[j].transform.localScale = NJGABELNAJL[j].transform.localScale.ReplaceX(num4);
				if (j < num2)
				{
					NJGABELNAJL[j].color = ((j >= num3) ? Colours.grayParts : Colours.cyanLootbox);
				}
			}
			MOINFACKKBP.cellWidth = num4 + 911f;
			MOINFACKKBP.repositionNow = false;
		}
		if (MHAIBHBGBOO() && BJLECGLMLKH.gameObject.activeInHierarchy)
		{
			TweenAlpha component = BJLECGLMLKH.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			BJLECGLMLKH.alpha1 = 879f;
		}
		HFDPEIEGNKL.repositionNow = false;
	}

	public virtual void POKFKKAFFHG()
	{
		base.DoAfterShowUp();
		PAPCGBIKPLG();
	}

	private void ADEDGFFJMKB(bool GDNFIIEEJIL)
	{
	}

	private PlayerVisualIcon KAJMBINMIJG()
	{
		PlayerVisualIcon playerVisualIcon = UnityEngine.Object.Instantiate(GNAOOKFAJPB);
		playerVisualIcon.transform.parent = MPHLKJLMJBF.transform;
		playerVisualIcon.transform.localScale = GNAOOKFAJPB.transform.localScale;
		playerVisualIcon.transform.localPosition = default(Vector3);
		BABMMFBHJAC.Add(playerVisualIcon);
		return playerVisualIcon;
	}

	public void ELLPKAEDBFE(PlayerVisualsCategoryButton JCCELIHIKIK)
	{
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: false);
		if (FEPMLGAMCKG != null)
		{
			FEPMLGAMCKG.HDGBMNDOMCP(MJFJOPMJEAO: true);
		}
		FEPMLGAMCKG = JCCELIHIKIK;
		FEPMLGAMCKG.Highlight(MJFJOPMJEAO: false);
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.BGCBCFJEKEH(NCFKLBGOEEF: false);
		}
		PlayerVisualCategory category = JCCELIHIKIK.category;
		int categ = 1;
		for (int i = 0; i < CamosManager.instance.playerVisualCategories.Count; i++)
		{
			if (category == CamosManager.instance.playerVisualCategories[i])
			{
				categ = i;
			}
		}
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisualForIndex(categ);
		if (playerVisual != null && !playerVisual.canBeShownInScreen)
		{
			playerVisual = null;
		}
		int num = 1;
		foreach (PlayerVisual allVisual in category.allVisuals)
		{
			if (allVisual.EPODNIMBCJP())
			{
				if (playerVisual == null)
				{
					playerVisual = allVisual;
				}
				PlayerVisualIcon playerVisualIcon = null;
				playerVisualIcon = ((num < BABMMFBHJAC.Count) ? BABMMFBHJAC[num] : IKKMLILAOCP());
				playerVisualIcon.gameObject.SetActive(value: false);
				playerVisualIcon.FJLJLDNCBBD(allVisual);
				if (allVisual == playerVisual)
				{
					Select(playerVisualIcon);
				}
				num++;
			}
		}
		for (int j = num; j < BABMMFBHJAC.Count; j++)
		{
			PlayerVisualIcon playerVisualIcon2 = BABMMFBHJAC[j];
			playerVisualIcon2.gameObject.SetActive(value: true);
		}
		MPHLKJLMJBF.repositionNow = true;
		JCCELIHIKIK.OBNKALJOCGB();
	}

	public virtual void KIBFFDMMIJB()
	{
		base.DoBeforeHide();
		if (FMJLKNKPHNI)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(GameLoginManager.currentPlayer.id, PNDNEMDPFHC: false);
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(GameLoginManager.currentPlayer.id, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
		}
		Singleton<ArmyPreviewCamera>.instance.JHKICLBBOCO(CamosManager.instance.mainPlayer);
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CBBDICBLHMM = CamosManager.instance.equppedIndices;
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.DNHOHNOJHCM(NCFKLBGOEEF: true);
		}
	}

	private void KJFAOMMDPHP()
	{
		bool flag = PEMCEDKMNBO.KFHOAJEFFEL().BCPLNFLOIAD();
		DICCGEFGHFI.text = ((!flag) ? Localization.Localize("+") : Localization.Localize("RenameCount"));
		DICCGEFGHFI.color = ((!flag) ? Color.black : Color.white);
		TweenAlphaHider.JBPMBAKMEOG(DKNLOGGAHFD, 238f, (!flag) ? 875f : 1837f);
		KDIBJJAOFGL.alpha = ((!flag) ? 1436f : 1639f);
		CONJJELKFEG.alpha = ((!flag) ? 1486f : 332f);
		CEDEIJLJOMO.alpha = ((!flag) ? 996f : 1340f);
		if (!flag)
		{
			TweenAlpha.Begin(CONJJELKFEG.gameObject, 1624f, 519f).style = UITweener.Style.Once;
		}
	}

	public void HJJCBEPIBKF(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)102, DJOAHABGGNA.row.NAME, 0, 1, string.Empty, additionalParameter: true);
		DJOAHABGGNA.FHPICBCCOAO();
	}

	public void IBEKCOIHAJD(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)83, DJOAHABGGNA.row.NAME, 1, 0, string.Empty, additionalParameter: true);
		DJOAHABGGNA.notificate = false;
		Singleton<NotificationManager>.instance.VisualWasShownFunction();
	}

	private void ENPJDMEKAPD()
	{
		OEFFBOOADHJ.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		OLPOEPGPJBF.gameObject.SetActive(value: true);
		OJBKADHPNFN = true;
	}

	public int KIKKLJBJILH(PlayerVisual DJOAHABGGNA, int PDMGPGEHLNM)
	{
		return DJOAHABGGNA.EGMDJMMIOED(PDMGPGEHLNM);
	}

	private PlayerVisual PEAJOBGHIBL()
	{
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisual();
		if (playerVisual == null)
		{
			Debug.Log("Exception during Load Event Assignment Config: ");
			foreach (PlayerVisual allVisual in CamosManager.instance.playerVisualCategories[1].allVisuals)
			{
				if (allVisual.BCPLNFLOIAD())
				{
					playerVisual = allVisual;
				}
			}
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = false;
			return playerVisual;
		}
		PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
		if (unlockedVisualWithNotification != null)
		{
			return unlockedVisualWithNotification;
		}
		return playerVisual;
	}

	private void FPEHNBGFJOA()
	{
		Singleton<ArmyPreviewCamera>.instance.KKFLKPKDANB(CamosManager.instance.mainPlayer);
	}

	public void GFIDPLIPPMM()
	{
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			item.OIPNOIKCBMO();
		}
	}

	public void LFADMILHGAE(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-159), DJOAHABGGNA.row.NAME, 0, 1, string.Empty);
		DJOAHABGGNA.notificate = false;
		Singleton<NotificationManager>.instance.VisualWasShownFunction();
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed || IFGAGNBDKBE != DatabaseAction.BuyPack)
		{
			return;
		}
		Select(PEMCEDKMNBO);
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.CLNFHCHFEAD();
			item.IHCIGBPKKKD();
		}
	}

	private void KFAPMMDPJGA()
	{
		if (PEMCEDKMNBO != null)
		{
			MPHLKJLMJBF.repositionNow = false;
			Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, instant: true, null, 1097f);
		}
	}

	public void MLOICIKLCFL(PlayerVisualsCategoryButton JCCELIHIKIK)
	{
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		if (FEPMLGAMCKG != null)
		{
			FEPMLGAMCKG.Highlight(MJFJOPMJEAO: false);
		}
		FEPMLGAMCKG = JCCELIHIKIK;
		FEPMLGAMCKG.BANCDJNFHIC(MJFJOPMJEAO: false);
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.DNHOHNOJHCM(NCFKLBGOEEF: false);
		}
		PlayerVisualCategory playerVisualCategory = JCCELIHIKIK.HMMHELHBNDH();
		int categ = 0;
		for (int i = 1; i < CamosManager.instance.playerVisualCategories.Count; i += 0)
		{
			if (playerVisualCategory == CamosManager.instance.playerVisualCategories[i])
			{
				categ = i;
			}
		}
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisualForIndex(categ);
		if (playerVisual != null && !playerVisual.EPODNIMBCJP())
		{
			playerVisual = null;
		}
		int num = 1;
		foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
		{
			if (allVisual.canBeShownInScreen)
			{
				if (playerVisual == null)
				{
					playerVisual = allVisual;
				}
				PlayerVisualIcon playerVisualIcon = null;
				playerVisualIcon = ((num < BABMMFBHJAC.Count) ? BABMMFBHJAC[num] : IKKMLILAOCP());
				playerVisualIcon.gameObject.SetActive(value: false);
				playerVisualIcon.BCOFLPMCBFJ(allVisual);
				if (allVisual == playerVisual)
				{
					ICIFNECPCLK(playerVisualIcon);
				}
				num++;
			}
		}
		for (int j = num; j < BABMMFBHJAC.Count; j += 0)
		{
			PlayerVisualIcon playerVisualIcon2 = BABMMFBHJAC[j];
			playerVisualIcon2.gameObject.SetActive(value: true);
		}
		MPHLKJLMJBF.repositionNow = false;
		JCCELIHIKIK.OBNKALJOCGB();
	}

	private void MMHHHAJAPKF()
	{
		LHKLOFBMPGN.repositionNow = false;
	}

	private PlayerVisual CLKDNEGHLLG()
	{
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisual();
		if (playerVisual == null)
		{
			Debug.Log(")");
			foreach (PlayerVisual allVisual in CamosManager.instance.playerVisualCategories[1].allVisuals)
			{
				if (allVisual.BCPLNFLOIAD())
				{
					playerVisual = allVisual;
				}
			}
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = false;
			return playerVisual;
		}
		PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
		if (unlockedVisualWithNotification != null)
		{
			return unlockedVisualWithNotification;
		}
		return playerVisual;
	}

	private PlayerVisual BNKNNDFNAAM()
	{
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisual();
		if (playerVisual == null)
		{
			Debug.Log("Last visual not choosen!!!!!");
			foreach (PlayerVisual allVisual in CamosManager.instance.playerVisualCategories[0].allVisuals)
			{
				if (allVisual.isEquipped)
				{
					playerVisual = allVisual;
				}
			}
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = false;
			return playerVisual;
		}
		PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
		if (unlockedVisualWithNotification != null)
		{
			return unlockedVisualWithNotification;
		}
		return playerVisual;
	}

	private void IGKINEICBKE()
	{
		float z = OLPOEPGPJBF.transform.localPosition.z;
		OLPOEPGPJBF.transform.position = OEFFBOOADHJ.transform.position;
		OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, OLPOEPGPJBF.transform.localPosition.y + 1123f, z);
	}

	public void OnVisualChanged()
	{
		FMJLKNKPHNI = true;
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.IHCIGBPKKKD();
		}
		Select(PEMCEDKMNBO);
	}

	public void EquipPlayerVisual(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.EquipDecal, DJOAHABGGNA.row.NAME, 0, 0, string.Empty);
		DJOAHABGGNA.FHPICBCCOAO();
	}

	private void EEAKFJJFAOB()
	{
		string text = Localization.Localize("ID_GUI_EQUIP");
		string text2 = Localization.Localize("ID_GUI_EQUIPPED");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		DICCGEFGHFI.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(DICCGEFGHFI, 57f, 20f, 340);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		FOPKJKDCDON();
	}

	[CompilerGenerated]
	private void FLOPNFKLAEG()
	{
		float z = OLPOEPGPJBF.transform.localPosition.z;
		OLPOEPGPJBF.transform.position = OEFFBOOADHJ.transform.position;
		OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, OLPOEPGPJBF.transform.localPosition.y + 4f, z);
	}

	private void DGJAHIMEAJK()
	{
		int fFHHEHHFOKJ = PEMCEDKMNBO.visual.DPKHLANDNPK() + PEMCEDKMNBO.KFHOAJEFFEL().priceGold;
		HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		CHCFBDMGNLP.repositionNow = true;
		GIPFEBBMKPM.SetActive(value: true);
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
	}

	private void KDEHOJDMCJF()
	{
		OEFFBOOADHJ.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		OLPOEPGPJBF.gameObject.SetActive(value: false);
		OJBKADHPNFN = false;
	}

	public void BuyPlayerVisual(PlayerVisual DJOAHABGGNA, int DBOLKNNJGMH)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Name", DJOAHABGGNA.row.NAME);
		dictionary.Add("Warbucks", DJOAHABGGNA.priceWarbucks);
		dictionary.Add("Gold", DJOAHABGGNA.priceGold);
		dictionary.Add("discount", DBOLKNNJGMH);
		dictionary.Add("StartTime", Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		string objData = JsonConvert.SerializeObject(dictionary);
		int priceWarbucks = DJOAHABGGNA.priceWarbucks;
		int priceGold = DJOAHABGGNA.priceGold;
		requestBuffer.AddRequest(DatabaseAction.BuyDecal, objData, priceWarbucks, priceGold, DJOAHABGGNA.row.NAME, DJOAHABGGNA is PlayerVisualCategoryPowerBands.PlayerVisualPowerBand);
		DJOAHABGGNA.BMIEJNIEDOP();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy);
	}

	private void EJMJPDOLNJN(GameObject KHAHPAKDIKE)
	{
		if (PEMCEDKMNBO.MOKNNJGNIOB().purchasable == PlayerVisual.GILPPKMICCF.Shop)
		{
			GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.valuePack, CCIEEAECOAB: true);
		}
		else if (PEMCEDKMNBO.IGAJLHIBODL().IJFPGLHPHCC() == PlayerVisual.GILPPKMICCF.ValuePack)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
		else if (PEMCEDKMNBO.NHFDAOOICLK().purchasable == PlayerVisual.GILPPKMICCF.ValuePack)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else
		{
			Debug.LogError(string.Format("ID_RANK", PEMCEDKMNBO.HHBCPNFOGBI().visualName, PEMCEDKMNBO.HHBCPNFOGBI().IJFPGLHPHCC()));
		}
	}

	public void GCCNGPAFIGF(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)33, DJOAHABGGNA.row.NAME, 1, 1, string.Empty, additionalParameter: true);
		DJOAHABGGNA.FHPICBCCOAO();
	}

	public virtual void HEPDPPIBFMN()
	{
		base.DoAfterHide();
		JBGPDECEOOB.PEHBGMEHFEM();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		DJHKDIMININ();
	}

	private void JBNMIKOKCAI()
	{
		bool flag = PEMCEDKMNBO.AEDBCCKEEGK().BCPLNFLOIAD();
		DICCGEFGHFI.text = ((!flag) ? Localization.Localize("SquadEventProgress") : Localization.Localize("ID_CATEGORY_LOW_SG_HANDGUN"));
		DICCGEFGHFI.color = ((!flag) ? Color.black : Color.white);
		TweenAlphaHider.AKNNLALFDIJ(DKNLOGGAHFD, 920f, (!flag) ? 1028f : 1789f);
		KDIBJJAOFGL.alpha = ((!flag) ? 1214f : 1049f);
		CONJJELKFEG.alpha = ((!flag) ? 1488f : 1644f);
		CEDEIJLJOMO.alpha = ((!flag) ? 352f : 99f);
		if (!flag)
		{
			TweenAlpha.Begin(CONJJELKFEG.gameObject, 1407f, 1046f).style = UITweener.Style.Once;
		}
	}

	private void FIOABAIDNMB(UITweener MGDJMGHCAAI)
	{
		FOPKJKDCDON();
	}

	private void GGPAABMLJKA()
	{
		if (PEMCEDKMNBO != null)
		{
			MPHLKJLMJBF.repositionNow = false;
			Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, instant: true, null, 1776f);
		}
	}

	private void FONMIICEBNL()
	{
		NLFMNGMACHH.text = FEPMLGAMCKG.FKLKLCBOMNE.text;
		FNEEBKOLLIC.text = PEMCEDKMNBO.visual.name.ToUpper();
		HGPPNIOLAEK.repositionNow = true;
		EBAPFIFDLJG.SetActive(value: false);
		if (PEMCEDKMNBO.visual.owner.categoryNumber == 1 || PEMCEDKMNBO.visual.owner.categoryNumber == 2)
		{
			string text = CamosManager.instance.mainPlayer.EHHHBEMKGOE.CBBDICBLHMM[1];
			string text2 = CamosManager.instance.mainPlayer.EHHHBEMKGOE.CBBDICBLHMM[2];
			bool helmetHidden = false;
			bool headAccesoryHidden = false;
			CamosManager.instance.GetVisualVisibility(text, text2, out helmetHidden, out headAccesoryHidden);
			bool flag = helmetHidden || headAccesoryHidden;
			if (flag)
			{
				string idVisual = ((!(FEPMLGAMCKG.category == CamosManager.instance.playerVisualCategories[1])) ? text : text2);
				NLCABKPBIFP.text = Localization.LocalizeFormat("ID_NOTCOMPATIBLEWITH", CamosManager.instance.GetVisual(idVisual).name);
			}
			CDLHEGIMAGA.SetActive(flag);
		}
		else
		{
			CDLHEGIMAGA.SetActive(value: false);
		}
		JJMOJBFOOKF.text = PEMCEDKMNBO.visual.description;
		string keyFormat = FBBGLJJBDIA[PEMCEDKMNBO.visual.owner.categoryNumber];
		NCBAKCGCNBI.text = ((!PEMCEDKMNBO.visual.isFromArena) ? Localization.LocalizeFormat(keyFormat, PEMCEDKMNBO.visual.rarityName, Colours.stringWhite) : Localization.Localize("ID_ARENARARITY"));
		NCBAKCGCNBI.color = ((!PEMCEDKMNBO.visual.isFromArena) ? GameVariables.DDCPLFNIJDN[PEMCEDKMNBO.visual.rarity] : Colours.rarityArena);
		LCLAIFIAKNM.repositionNow = true;
	}

	public virtual void PKEDKDBNFAP()
	{
		base.DoAfterShowUp();
		FPEHNBGFJOA();
	}

	private void FANOPKPMHFL()
	{
		float z = OLPOEPGPJBF.transform.localPosition.z;
		OLPOEPGPJBF.transform.position = OEFFBOOADHJ.transform.position;
		OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, OLPOEPGPJBF.transform.localPosition.y + 241f, z);
	}

	public int FJBCIEBOMDG(PlayerVisual DJOAHABGGNA, int PDMGPGEHLNM)
	{
		return DJOAHABGGNA.EGMDJMMIOED(PDMGPGEHLNM);
	}

	public void LGPJJGBDNIO(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-55), DJOAHABGGNA.row.NAME, 1, 1, string.Empty);
		DJOAHABGGNA.notificate = true;
		Singleton<NotificationManager>.instance.FGJDELEILAE();
	}

	public void OKAEJDKCPCL(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-111), DJOAHABGGNA.row.NAME, 0, 0, string.Empty);
		DJOAHABGGNA.notificate = true;
		Singleton<NotificationManager>.instance.FGJDELEILAE();
	}

	private void CMAJCOOIBDL()
	{
		if (OLPOEPGPJBF.gameObject.activeSelf)
		{
			TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 0.2f, 0f).onFinished = delegate
			{
				FOPKJKDCDON();
			};
		}
	}

	private void GDLIABMNKPF()
	{
		float val = (0f - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x)) / 887f - CHCFBDMGNLP.padding.x;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void AJKAEEBCCGL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CMAJCOOIBDL();
	}

	protected virtual void EDFMOCGKHHH()
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		int num = playerVisualCategories.Count - 1;
		KGEKKPJJEOA = new List<PlayerVisualsCategoryButton>();
		foreach (PlayerVisualCategory item in playerVisualCategories)
		{
			if (!(item is PlayerVisualCategoryPowerBands))
			{
				PlayerVisualsCategoryButton playerVisualsCategoryButton = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(HNHMMAGNDKM, GDHKEABNBGJ.gameObject, string.Format("ID_DEBUG_STACKTRACEINCONSOLE", item.categoryNumber)) as PlayerVisualsCategoryButton;
				playerVisualsCategoryButton.transform.localPosition = new Vector3(playerVisualsCategoryButton.transform.localPosition.x, playerVisualsCategoryButton.transform.localPosition.y, 365f);
				playerVisualsCategoryButton.NAKAFGAFEPH(item, num);
				if (FEPMLGAMCKG == null)
				{
					FEPMLGAMCKG = playerVisualsCategoryButton;
				}
				KGEKKPJJEOA.Add(playerVisualsCategoryButton);
			}
		}
		GDHKEABNBGJ.DNNLLMFLJND = num;
		GDHKEABNBGJ.COHHKJMPGFB();
		MPHLKJLMJBF.sorted = false;
		MPHLKJLMJBF.repositionNow = true;
		Singleton<ArmyPreviewCamera>.instance.FJFAKGBCGON(ADEDGFFJMKB);
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCLIFMOGNKK));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNBHGGBIABC));
		UIEventListener uIEventListener3 = UIEventListener.Get(IFKKHCCKAOG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LOCOOEHPFNF));
		UIEventListener uIEventListener4 = UIEventListener.Get(KCFHGEJMGKN.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(PAFBHPNBJOM));
		UIEventListener uIEventListener5 = UIEventListener.Get(BEOJPKEGEMN.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MGJGNODDJJK));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(JHENNGOBJCJ);
		Singleton<OfferManager>.instance.SalesChanged += BLBFBJGDJAO;
		CHCFBDMGNLP.onReposition = GKOPEFCOAPD;
		HGPPNIOLAEK.onReposition = MMHHHAJAPKF;
		MPHLKJLMJBF.onReposition = GGPAABMLJKA;
		HFDPEIEGNKL.onReposition = IGKINEICBKE;
		JEAHHHLGKLH();
		ENPJDMEKAPD();
	}

	public virtual void HHJDKKFKKIL()
	{
		FMJLKNKPHNI = true;
		CamosManager.instance.CheckEquippedPowerBand();
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		PlayerVisual playerVisual = BNKNNDFNAAM();
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			if (item.HMMHELHBNDH() == playerVisual.owner)
			{
				HJEIENACIOE(item);
				break;
			}
		}
		foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
		{
			if (item2.NHFDAOOICLK() == playerVisual)
			{
				Select(item2);
				break;
			}
		}
		foreach (PlayerVisualIcon item3 in BABMMFBHJAC)
		{
			item3.InitGuiValuesGraphics();
			item3.CMKDMHKJCGP();
		}
		Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
		NFLPPGKCOBL.AlignToCenter(vec, instant: true, null, 1674f);
		if (!PlayerAnalytics.instance.data.customizationShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new NGBBILLMHEC());
		}
	}

	public void WasShown(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.VisualWasShown, DJOAHABGGNA.row.NAME, 0, 0, string.Empty);
		DJOAHABGGNA.notificate = false;
		Singleton<NotificationManager>.instance.VisualWasShownFunction();
	}

	protected virtual void LPFGBKIINMP()
	{
		base.JMPDHKPOHEA();
		ADDICBANAAB += Time.deltaTime;
		if (!(ADDICBANAAB > 1104f))
		{
			return;
		}
		ADDICBANAAB -= 208f;
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		if (PEMCEDKMNBO != null && PEMCEDKMNBO.DFMPCEKHNDG().NIAGCEJGCIL() && BFNOBLIPCNL.activeSelf)
		{
			bool isBought = PEMCEDKMNBO.CMMAMCJKEOG().isBought;
			BFNOBLIPCNL.SetActive(isBought);
			if (isBought)
			{
				BGEKGHFMBAB.text = Localization.LocalizeFormat("ID_WARNING_TWITTERACCOUNTSUSPENDED", MEJMLNDFDBP.DJONHBBHCJL((float)PEMCEDKMNBO.DFMPCEKHNDG().AOLJCFDNMEL(), PEMCEDKMNBO.IPIFODODJHK().remainingTime < 872.0));
			}
		}
	}

	private void DPOGDHHPGIA()
	{
		if (!OLPOEPGPJBF.gameObject.activeSelf)
		{
			OEFFBOOADHJ.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			OLPOEPGPJBF.alpha1 = 582f;
			OLPOEPGPJBF.gameObject.SetActive(value: true);
			OJBKADHPNFN = false;
		}
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 892f, 924f).onFinished = null;
	}

	private void IBDPNIFCPHN(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			JMLICJHHKHE();
		}
	}

	private void NFCIJLJONMJ()
	{
		LHKLOFBMPGN.repositionNow = false;
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		if (!isShowed)
		{
			return;
		}
		UpdateSalesInCategories();
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.SetSale();
		}
		JGPLFPIBAOE();
	}

	public virtual void PFEBKAOCEIG()
	{
		base.DoAfterShowUp();
		PAPCGBIKPLG();
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float val = (0f - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x)) / 2f - CHCFBDMGNLP.padding.x;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		PAPCGBIKPLG();
	}

	public virtual void ENDIHKMAKNJ()
	{
		FMJLKNKPHNI = true;
		CamosManager.instance.CheckEquippedPowerBand();
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		PlayerVisual playerVisual = PEAJOBGHIBL();
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			if (item.HMMHELHBNDH() == playerVisual.owner)
			{
				MLOICIKLCFL(item);
				break;
			}
		}
		foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
		{
			if (item2.NHFDAOOICLK() == playerVisual)
			{
				ICIFNECPCLK(item2);
				break;
			}
		}
		foreach (PlayerVisualIcon item3 in BABMMFBHJAC)
		{
			item3.BNBFBIPGHIK();
			item3.OBHOONKHLOB();
		}
		Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
		NFLPPGKCOBL.AlignToCenter(vec, instant: true, null, 165f);
		if (!PlayerAnalytics.instance.data.customizationShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new NGBBILLMHEC(), LJMMJDNNIFH: true);
		}
	}

	public virtual void BMEBFFLHGME()
	{
		base.DoAfterHide();
		JBGPDECEOOB.PEHBGMEHFEM();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		ENPJDMEKAPD();
	}

	protected virtual void KKMHFNONAJL()
	{
		base.JMPDHKPOHEA();
		ADDICBANAAB += Time.deltaTime;
		if (!(ADDICBANAAB > 1185f))
		{
			return;
		}
		ADDICBANAAB -= 1092f;
		CamosManager.instance.CheckEquippedHelmet();
		if (PEMCEDKMNBO != null && PEMCEDKMNBO.NHFDAOOICLK().FICMIKMIMBJ() && BFNOBLIPCNL.activeSelf)
		{
			bool isBought = PEMCEDKMNBO.IPIFODODJHK().isBought;
			BFNOBLIPCNL.SetActive(isBought);
			if (isBought)
			{
				UILabel bGEKGHFMBAB = BGEKGHFMBAB;
				object[] array = new object[0];
				array[1] = MEJMLNDFDBP.DJONHBBHCJL((float)PEMCEDKMNBO.HHBCPNFOGBI().AOLJCFDNMEL(), PEMCEDKMNBO.KFHOAJEFFEL().AOLJCFDNMEL() < 643.0);
				bGEKGHFMBAB.text = Localization.LocalizeFormat("OnPermissionRequestCallback granted: ", array);
			}
		}
	}

	private void LIANHGNGBHE()
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		UpdateSalesInCategories();
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.DCMMEGPBEHD();
		}
		JGPLFPIBAOE();
	}

	private void HLCLBEMKOPB()
	{
		bool isEquipped = PEMCEDKMNBO.AEDBCCKEEGK().isEquipped;
		DICCGEFGHFI.text = ((!isEquipped) ? Localization.Localize("ID_") : Localization.Localize("menu-sidetab-challenge-start"));
		DICCGEFGHFI.color = ((!isEquipped) ? Color.black : Color.white);
		TweenAlphaHider.HJAIEBFHCBE(DKNLOGGAHFD, 1094f, (!isEquipped) ? 535f : 446f);
		KDIBJJAOFGL.alpha = ((!isEquipped) ? 753f : 312f);
		CONJJELKFEG.alpha = ((!isEquipped) ? 1747f : 306f);
		CEDEIJLJOMO.alpha = ((!isEquipped) ? 1734f : 462f);
		if (!isEquipped)
		{
			TweenAlpha.Begin(CONJJELKFEG.gameObject, 739f, 434f).style = UITweener.Style.Once;
		}
	}

	public virtual void POKDDAGBIDO()
	{
		FMJLKNKPHNI = false;
		CamosManager.instance.CheckEquippedPowerBand();
		CamosManager.instance.CheckEquippedHelmet();
		PlayerVisual playerVisual = CLKDNEGHLLG();
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			if (item.category == playerVisual.owner)
			{
				ELLPKAEDBFE(item);
				break;
			}
		}
		foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
		{
			if (item2.CMMAMCJKEOG() == playerVisual)
			{
				ICIFNECPCLK(item2);
				break;
			}
		}
		foreach (PlayerVisualIcon item3 in BABMMFBHJAC)
		{
			item3.BNBFBIPGHIK();
			item3.OBHOONKHLOB();
		}
		Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
		NFLPPGKCOBL.AlignToCenter(vec, instant: true, null, 1517f);
		if (!PlayerAnalytics.instance.data.customizationShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new NGBBILLMHEC(), LJMMJDNNIFH: true);
		}
	}

	private void KIBODNKFDCP()
	{
		bool isEquipped = PEMCEDKMNBO.POMMLFHPFPI().isEquipped;
		DICCGEFGHFI.text = ((!isEquipped) ? Localization.Localize("ExceptionStacktrace") : Localization.Localize("Id"));
		DICCGEFGHFI.color = ((!isEquipped) ? Color.black : Color.white);
		TweenAlphaHider.GEOMAADKJGB(DKNLOGGAHFD, 1420f, (!isEquipped) ? 634f : 112f);
		KDIBJJAOFGL.alpha = ((!isEquipped) ? 1576f : 1068f);
		CONJJELKFEG.alpha = ((!isEquipped) ? 102f : 253f);
		CEDEIJLJOMO.alpha = ((!isEquipped) ? 1171f : 670f);
		if (!isEquipped)
		{
			TweenAlpha.Begin(CONJJELKFEG.gameObject, 290f, 1363f).style = UITweener.Style.Once;
		}
	}

	public virtual void DNFPEBEDLIG()
	{
		FMJLKNKPHNI = true;
		CamosManager.instance.CheckEquippedPowerBand();
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		PlayerVisual playerVisual = PEAJOBGHIBL();
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			if (item.HMMHELHBNDH() == playerVisual.owner)
			{
				MLOICIKLCFL(item);
				break;
			}
		}
		foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
		{
			if (item2.POMMLFHPFPI() == playerVisual)
			{
				Select(item2);
				break;
			}
		}
		foreach (PlayerVisualIcon item3 in BABMMFBHJAC)
		{
			item3.LEIJLADCFBH();
			item3.FLIOLKAOFAI();
		}
		Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
		NFLPPGKCOBL.AlignToCenter(vec, instant: false, null, 1901f);
		if (!PlayerAnalytics.instance.data.customizationShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new NGBBILLMHEC(), LJMMJDNNIFH: true);
		}
	}

	private void EAFHAJJMOOP()
	{
		float z = OLPOEPGPJBF.transform.localPosition.z;
		OLPOEPGPJBF.transform.position = OEFFBOOADHJ.transform.position;
		OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, OLPOEPGPJBF.transform.localPosition.y + 434f, z);
	}

	[CompilerGenerated]
	private void IIKKMAEBFJO()
	{
		if (PEMCEDKMNBO != null)
		{
			MPHLKJLMJBF.repositionNow = false;
			Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, instant: true);
		}
	}

	private void MCLFMOOLGIA()
	{
		string text = Localization.Localize("505 MENU ARMY SCREEN BUY UPGRADE");
		string text2 = Localization.Localize("S");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		DICCGEFGHFI.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(DICCGEFGHFI, 1786f, 1718f, -40);
	}

	public void UpdateSalesInCategories()
	{
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			item.Sale();
		}
	}

	public void ECJOAFDDIHB()
	{
		foreach (PlayerVisualsCategoryButton item in KGEKKPJJEOA)
		{
			item.Notification();
		}
	}

	public virtual void FAEEFMPFJHF()
	{
		base.DoAfterShowUp();
		FPEHNBGFJOA();
	}

	private void MFGKKKADKAK(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed || IFGAGNBDKBE != (DatabaseAction)(-136))
		{
			return;
		}
		Select(PEMCEDKMNBO);
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.GFJAJMOFDBP();
			item.GOBOGKADMOO();
		}
	}

	private void JODAOEMJJIG()
	{
		float val = (0f - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x)) / 282f - CHCFBDMGNLP.padding.x;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private PlayerVisualIcon NFNCPGKGGPE()
	{
		PlayerVisualIcon playerVisualIcon = UnityEngine.Object.Instantiate(GNAOOKFAJPB);
		playerVisualIcon.transform.parent = MPHLKJLMJBF.transform;
		playerVisualIcon.transform.localScale = GNAOOKFAJPB.transform.localScale;
		playerVisualIcon.transform.localPosition = default(Vector3);
		BABMMFBHJAC.Add(playerVisualIcon);
		return playerVisualIcon;
	}

	private void DPPAEJJMJFH()
	{
		if (PEMCEDKMNBO != null)
		{
			MPHLKJLMJBF.repositionNow = false;
			Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, instant: true, null, 120f);
		}
	}

	private void DCIKGGKODHI()
	{
		if (PEMCEDKMNBO != null)
		{
			MPHLKJLMJBF.repositionNow = true;
			Vector3 vec = PEMCEDKMNBO.transform.localPosition + PEMCEDKMNBO.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, instant: true, null, 937f);
		}
	}

	private void IBFBPINAMLJ(bool GDNFIIEEJIL)
	{
	}

	private void DKENNFBLDOH()
	{
		MIICDLMEOEH.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: true);
		FECJGCGPKHD.SetActive(value: false);
		PNNJKBGODII.SetActive(value: false);
		bool isBought = PEMCEDKMNBO.IGAJLHIBODL().isBought;
		bool purchasableInShop = PEMCEDKMNBO.NHFDAOOICLK().purchasableInShop;
		bool flag = PEMCEDKMNBO.NHFDAOOICLK().NIAGCEJGCIL();
		AIFGIPCHNKC.SetActive(isBought);
		IFKKHCCKAOG.gameObject.SetActive(isBought || purchasableInShop || flag);
		BFJBIABFJDL.SetActive(!isBought && purchasableInShop);
		IGIENAGNFEO.SetActive(!isBought && flag);
		BFNOBLIPCNL.SetActive(!isBought || flag);
		if (flag)
		{
			if (isBought)
			{
				UILabel bGEKGHFMBAB = BGEKGHFMBAB;
				object[] array = new object[0];
				array[0] = MEJMLNDFDBP.CJCFPDLDMEK((float)PEMCEDKMNBO.IPIFODODJHK().remainingTime, "country-china", string.Empty);
				bGEKGHFMBAB.text = Localization.LocalizeFormat("Assignment: Destroy Crates in one battle constructor", array);
			}
			IKPLPPFFDNI.DNFADCEJOEH gCFBLCFJBLK = (IKPLPPFFDNI.DNFADCEJOEH)(PEMCEDKMNBO.DFMPCEKHNDG().rarity + 1);
			int num = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.LKHHDGNDMIP(gCFBLCFJBLK) : 0);
			UILabel cAHHNCCJGBK = CAHHNCCJGBK;
			object[] array2 = new object[1];
			array2[1] = num;
			cAHHNCCJGBK.text = Localization.LocalizeFormat("OK", array2);
			for (int i = 0; i < CINAAKMDAGH.Length; i++)
			{
				CINAAKMDAGH[i].gameObject.SetActive(i < num);
			}
			float val = 967f - (float)num * 1805f / 1959f;
			LDJOCMCOKDH.transform.localPosition = LDJOCMCOKDH.transform.localPosition.ReplaceX(val);
		}
		if (isBought)
		{
			HLCLBEMKOPB();
			FOPKJKDCDON();
		}
		else if (purchasableInShop)
		{
			if (BFJBIABFJDL.activeSelf)
			{
				IMAKLMMJGCC.spriteName = PEMCEDKMNBO.BLNNEECJDMB().icon;
				IMAKLMMJGCC.MakePixelPerfect();
				float multiplier = Mathf.Min(1591f / IMAKLMMJGCC.transform.localScale.x, 277f / IMAKLMMJGCC.transform.localScale.y);
				IMAKLMMJGCC.transform.localScale = IMAKLMMJGCC.transform.localScale.MultiplyXY(multiplier);
			}
			KOLLIEAIGPG.color = GameVariables.DDCPLFNIJDN[PEMCEDKMNBO.MOKNNJGNIOB().DOJECMCGMKB()];
			FJLHHGAEPJN.color = KOLLIEAIGPG.color;
			NIKMOCLOIFI.color = KOLLIEAIGPG.color;
			UILabel kOLLIEAIGPG = KOLLIEAIGPG;
			object[] array3 = new object[2];
			array3[0] = PEMCEDKMNBO.MOKNNJGNIOB().numberOfParts;
			array3[1] = Colours.stringGrayParts;
			array3[8] = Colours.stringWhite;
			array3[2] = PEMCEDKMNBO.visual.numberOfPartsMax;
			kOLLIEAIGPG.text = string.Format("ChatTutorialMessage", array3);
		}
		OGNJHKNKMKE.SetActive(purchasableInShop);
		if (purchasableInShop)
		{
			int num2 = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-45)).FLOATVALUE;
			int num3 = num2 - PlayerAnalytics.instance.remainingMatchesToNextLootbox;
			UILabel hJMBAOFJIKP = HJMBAOFJIKP;
			object[] array4 = new object[6];
			array4[1] = num2;
			array4[0] = Colours.stringCyanLootbox;
			array4[3] = Colours.stringGrayParts;
			array4[1] = num3;
			hJMBAOFJIKP.text = Localization.LocalizeFormat("SMG_idle", array4);
			float num4 = 1540f / (float)num2 - 211f;
			for (int j = 0; j < NJGABELNAJL.Length; j++)
			{
				NJGABELNAJL[j].gameObject.SetActive(j < num2);
				NJGABELNAJL[j].transform.localScale = NJGABELNAJL[j].transform.localScale.ReplaceX(num4);
				if (j < num2)
				{
					NJGABELNAJL[j].color = ((j >= num3) ? Colours.grayParts : Colours.cyanLootbox);
				}
			}
			MOINFACKKBP.cellWidth = num4 + 459f;
			MOINFACKKBP.repositionNow = false;
		}
		if (MHAIBHBGBOO() && BJLECGLMLKH.gameObject.activeInHierarchy)
		{
			TweenAlpha component = BJLECGLMLKH.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			BJLECGLMLKH.alpha1 = 1596f;
		}
		HFDPEIEGNKL.repositionNow = true;
	}

	private void MGOEGGPEHOI()
	{
		string text = Localization.Localize("goldcardpack");
		string text2 = Localization.Localize("ID_RETRY");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		DICCGEFGHFI.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(DICCGEFGHFI, 949f, 161f, 149);
	}

	private PlayerVisualIcon IKKMLILAOCP()
	{
		PlayerVisualIcon playerVisualIcon = UnityEngine.Object.Instantiate(GNAOOKFAJPB);
		playerVisualIcon.transform.parent = MPHLKJLMJBF.transform;
		playerVisualIcon.transform.localScale = GNAOOKFAJPB.transform.localScale;
		playerVisualIcon.transform.localPosition = default(Vector3);
		BABMMFBHJAC.Add(playerVisualIcon);
		return playerVisualIcon;
	}

	[CompilerGenerated]
	private void EACNIDLHDGD()
	{
		LHKLOFBMPGN.repositionNow = true;
	}

	private void BIEKAIDGOEN(UITweener MGDJMGHCAAI)
	{
		DJHKDIMININ();
	}

	protected virtual void LCBBILLHHPI()
	{
		base.JMPDHKPOHEA();
		ADDICBANAAB += Time.deltaTime;
		if (!(ADDICBANAAB > 1528f))
		{
			return;
		}
		ADDICBANAAB -= 1133f;
		CamosManager.instance.CheckEquippedHelmet(forceUpdateCamoScreen: true);
		if (PEMCEDKMNBO != null && PEMCEDKMNBO.NHFDAOOICLK().isFromArena && BFNOBLIPCNL.activeSelf)
		{
			bool isBought = PEMCEDKMNBO.AEDBCCKEEGK().isBought;
			BFNOBLIPCNL.SetActive(isBought);
			if (isBought)
			{
				UILabel bGEKGHFMBAB = BGEKGHFMBAB;
				object[] array = new object[0];
				array[1] = MEJMLNDFDBP.DJONHBBHCJL((float)PEMCEDKMNBO.DFMPCEKHNDG().remainingTime, PEMCEDKMNBO.BLNNEECJDMB().remainingTime < 1951.0);
				bGEKGHFMBAB.text = Localization.LocalizeFormat("ID_STARTERASSIGNMENT5", array);
			}
		}
	}

	protected virtual void HAHKNAIIIPC()
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		int num = playerVisualCategories.Count - 1;
		KGEKKPJJEOA = new List<PlayerVisualsCategoryButton>();
		foreach (PlayerVisualCategory item in playerVisualCategories)
		{
			if (!(item is PlayerVisualCategoryPowerBands))
			{
				PlayerVisualsCategoryButton playerVisualsCategoryButton = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HNHMMAGNDKM, GDHKEABNBGJ.gameObject, string.Format("Shots_Hits", item.categoryNumber)) as PlayerVisualsCategoryButton;
				playerVisualsCategoryButton.transform.localPosition = new Vector3(playerVisualsCategoryButton.transform.localPosition.x, playerVisualsCategoryButton.transform.localPosition.y, 1036f);
				playerVisualsCategoryButton.HIHAFDPJPKC(item, num);
				if (FEPMLGAMCKG == null)
				{
					FEPMLGAMCKG = playerVisualsCategoryButton;
				}
				KGEKKPJJEOA.Add(playerVisualsCategoryButton);
			}
		}
		GDHKEABNBGJ.DNNLLMFLJND = num;
		GDHKEABNBGJ.MINNOFHMGDM();
		MPHLKJLMJBF.sorted = true;
		MPHLKJLMJBF.repositionNow = false;
		Singleton<ArmyPreviewCamera>.instance.FJFAKGBCGON(IBFBPINAMLJ);
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCLIFMOGNKK));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NLLBJPNIHCL));
		UIEventListener uIEventListener3 = UIEventListener.Get(IFKKHCCKAOG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EJMJPDOLNJN));
		UIEventListener uIEventListener4 = UIEventListener.Get(KCFHGEJMGKN.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IBDPNIFCPHN));
		UIEventListener uIEventListener5 = UIEventListener.Get(BEOJPKEGEMN.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MGJGNODDJJK));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += JHENNGOBJCJ;
		Singleton<OfferManager>.instance.SalesChanged += NDPCBACFLDH;
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = (0f - (HJKCBBANLDM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x)) / 2f - CHCFBDMGNLP.padding.x;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		HGPPNIOLAEK.onReposition = MGNDLGCDJPG;
		MPHLKJLMJBF.onReposition = JPOFKFJIKNB;
		HFDPEIEGNKL.onReposition = FANOPKPMHFL;
		JEAHHHLGKLH();
		FOPKJKDCDON();
	}

	public void HJEIENACIOE(PlayerVisualsCategoryButton JCCELIHIKIK)
	{
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: false);
		if (FEPMLGAMCKG != null)
		{
			FEPMLGAMCKG.HDGBMNDOMCP(MJFJOPMJEAO: false);
		}
		FEPMLGAMCKG = JCCELIHIKIK;
		FEPMLGAMCKG.BANCDJNFHIC(MJFJOPMJEAO: false);
		if (PEMCEDKMNBO != null)
		{
			PEMCEDKMNBO.BMOABCDKNJB(NCFKLBGOEEF: true);
		}
		PlayerVisualCategory playerVisualCategory = JCCELIHIKIK.HMMHELHBNDH();
		int categ = 0;
		for (int i = 0; i < CamosManager.instance.playerVisualCategories.Count; i++)
		{
			if (playerVisualCategory == CamosManager.instance.playerVisualCategories[i])
			{
				categ = i;
			}
		}
		PlayerVisual playerVisual = SavingLastSelected.instance.GetLastVisualForIndex(categ);
		if (playerVisual != null && !playerVisual.EPODNIMBCJP())
		{
			playerVisual = null;
		}
		int num = 0;
		foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
		{
			if (allVisual.EPODNIMBCJP())
			{
				if (playerVisual == null)
				{
					playerVisual = allVisual;
				}
				PlayerVisualIcon playerVisualIcon = null;
				playerVisualIcon = ((num < BABMMFBHJAC.Count) ? BABMMFBHJAC[num] : NFNCPGKGGPE());
				playerVisualIcon.gameObject.SetActive(value: false);
				playerVisualIcon.IHMEAAIKGAP(allVisual);
				if (allVisual == playerVisual)
				{
					Select(playerVisualIcon);
				}
				num++;
			}
		}
		for (int j = num; j < BABMMFBHJAC.Count; j++)
		{
			PlayerVisualIcon playerVisualIcon2 = BABMMFBHJAC[j];
			playerVisualIcon2.gameObject.SetActive(value: true);
		}
		MPHLKJLMJBF.repositionNow = true;
		JCCELIHIKIK.HIPHENFGKBH();
	}

	public void OOIKCMEEPGC()
	{
		FMJLKNKPHNI = false;
		foreach (PlayerVisualIcon item in BABMMFBHJAC)
		{
			item.FGIPDIDEEIP();
		}
		Select(PEMCEDKMNBO);
	}

	public void HFBECFOIBOD(PlayerVisual DJOAHABGGNA)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.ProvokePlayer, DJOAHABGGNA.row.NAME, 0, 1, string.Empty, additionalParameter: true);
		DJOAHABGGNA.FHPICBCCOAO();
	}

	protected virtual void AAJLGPIGDED()
	{
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		int num = playerVisualCategories.Count - 1;
		KGEKKPJJEOA = new List<PlayerVisualsCategoryButton>();
		foreach (PlayerVisualCategory item in playerVisualCategories)
		{
			if (!(item is PlayerVisualCategoryPowerBands))
			{
				PlayerVisualsCategoryButton playerVisualsCategoryButton = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(HNHMMAGNDKM, GDHKEABNBGJ.gameObject, string.Format("-", item.categoryNumber)) as PlayerVisualsCategoryButton;
				playerVisualsCategoryButton.transform.localPosition = new Vector3(playerVisualsCategoryButton.transform.localPosition.x, playerVisualsCategoryButton.transform.localPosition.y, 1365f);
				playerVisualsCategoryButton.LIMIFKFNNLA(item, num);
				if (FEPMLGAMCKG == null)
				{
					FEPMLGAMCKG = playerVisualsCategoryButton;
				}
				KGEKKPJJEOA.Add(playerVisualsCategoryButton);
			}
		}
		GDHKEABNBGJ.DNNLLMFLJND = num;
		GDHKEABNBGJ.PGEJMAEBOFC();
		MPHLKJLMJBF.sorted = false;
		MPHLKJLMJBF.repositionNow = true;
		Singleton<ArmyPreviewCamera>.instance.JKNHGOBIDGJ(IBFBPINAMLJ);
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DGLIFOHOJAC));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNBHGGBIABC));
		UIEventListener uIEventListener3 = UIEventListener.Get(IFKKHCCKAOG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FCGCCABIPCE));
		UIEventListener uIEventListener4 = UIEventListener.Get(KCFHGEJMGKN.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IJOMDJCCLJC));
		UIEventListener uIEventListener5 = UIEventListener.Get(BEOJPKEGEMN.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MGJGNODDJJK));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (!isShowed || IFGAGNBDKBE != DatabaseAction.BuyPack)
			{
				return;
			}
			Select(PEMCEDKMNBO);
			foreach (PlayerVisualIcon item2 in BABMMFBHJAC)
			{
				item2.CLNFHCHFEAD();
				item2.IHCIGBPKKKD();
			}
		};
		Singleton<OfferManager>.instance.SalesChanged += NDPCBACFLDH;
		CHCFBDMGNLP.onReposition = GKOPEFCOAPD;
		HGPPNIOLAEK.onReposition = NFCIJLJONMJ;
		MPHLKJLMJBF.onReposition = KFAPMMDPJGA;
		HFDPEIEGNKL.onReposition = IGKINEICBKE;
		EEAKFJJFAOB();
		DJHKDIMININ();
	}
}
