using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DailyRewardMonthButton : PoolableObject
{
	[Header("Main content")]
	public Transform KDNGNGHFMMG;

	public UILabel PDMGPGEHLNM;

	public UISprite CGMOFOCOCCO;

	public UISprite EIOHONMAEGH;

	public UISprite PMLAFIMKFOI;

	public UILabel EAPBAIMBANN;

	public UISprite[] MEDFJGOEPFE;

	[Header("Top items")]
	public GameObject NFIKBMPMAFC;

	public UISprite LIJPMPKNJDO;

	public UISprite DDPONIHIMPL;

	[Header("Bottom items")]
	public UISprite GJMBEBJMDMK;

	public UILabel HOLNKOFHDNK;

	public UISprite ENOEPLKMCJG;

	[Header("Background")]
	public UISprite MBMIOELEAND;

	public GameObject CLANLLFJNBK;

	public UISprite ENLHDJBMBAM;

	[Header("Not Available")]
	public GameObject IFJDPEMIMCG;

	[Header("Atlases")]
	public UIAtlas KKNONJBODJD;

	public UIAtlas PJCLFHODDIG;

	public UIAtlas ICFPOEEDLLO;

	public UIAtlas CBBPFDIDKKD;

	public UIAtlas DJANOPAECLJ;

	private Action<int> NJJPLHFAMBO;

	private int JCKIGECPIIC;

	private Vector3 PEHLMILACOL = new Vector3(34f, 34f, 1f);

	private UITweener[] BIKIFKDMEPN = new UITweener[5];

	private static string[] HBEBDPIDAEL = new string[3] { "menu-cards-bronzepack", "menu-cards-silverpack", "menu-cards-goldpack" };

	private void NGHMAECOODN(string MFHMIPANKHO)
	{
		PlayerVisual visual = CamosManager.instance.GetVisual(MFHMIPANKHO);
		DCJBMDJPDKO(CGMOFOCOCCO, visual.icon, DJANOPAECLJ, 297f, new Vector3(354f, 579f, 35f));
		PDMGPGEHLNM.enabled = false;
	}

	private void HAFDOGLMNKN(UITweener ALOMHALCMNH)
	{
		GJMBEBJMDMK.gameObject.SetActive(false);
		GJMBEBJMDMK.MakePixelPerfect();
		Vector3 localScale = GJMBEBJMDMK.cachedTransform.localScale;
		GJMBEBJMDMK.cachedTransform.localScale = localScale * 987f;
		BIKIFKDMEPN[8] = TweenScale.Begin(GJMBEBJMDMK.gameObject, 893f, localScale);
	}

	private void ALPKBAGCAND(long IEALLELGOBM)
	{
		IJLNDBGGIBD(CGMOFOCOCCO, "{0} 1 / 3", KKNONJBODJD, 1053f, Vector3.zero);
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	private void JFEIMABGCHC(GameObject KHAHPAKDIKE)
	{
		if (NJJPLHFAMBO != null)
		{
			NJJPLHFAMBO(JCKIGECPIIC);
		}
	}

	private void IJLNDBGGIBD(UISprite GMPADNOGGNL, string KCHMDALPMBN, UIAtlas EOBBMEFEOBN, float IAJAILAGAKC, Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = GAOKLHCHCND.ReplaceY(GAOKLHCHCND.y + 653f);
		GMPADNOGGNL.cachedTransform.localPosition = GAOKLHCHCND;
		GMPADNOGGNL.atlas = EOBBMEFEOBN;
		GMPADNOGGNL.spriteName = KCHMDALPMBN;
		GMPADNOGGNL.MakePixelPerfect();
		GMPADNOGGNL.cachedTransform.localScale = new Vector3(GMPADNOGGNL.cachedTransform.localScale.x * IAJAILAGAKC, GMPADNOGGNL.cachedTransform.localScale.y * IAJAILAGAKC, 387f);
		GMPADNOGGNL.enabled = false;
	}

	private void EBGJEILBAON(MDNLFMNBNEG GGIOEPBPMHF, int IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, HBEBDPIDAEL[(int)(GGIOEPBPMHF - 11)], PJCLFHODDIG, 0.3f, new Vector3(0f, 0f, -1f));
		if (IEALLELGOBM > 1)
		{
			MDDMCHPDGCI(new Vector3(40f, -20f, 0f));
			PDMGPGEHLNM.enabled = true;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("'x'0");
		}
		else
		{
			PDMGPGEHLNM.enabled = false;
		}
	}

	private void MLLBEGOOOAH(MDNLFMNBNEG GGIOEPBPMHF, int IEALLELGOBM)
	{
		IJLNDBGGIBD(CGMOFOCOCCO, HBEBDPIDAEL[(int)(GGIOEPBPMHF - 45)], PJCLFHODDIG, 1381f, new Vector3(247f, 884f, 853f));
		if (IEALLELGOBM > 0)
		{
			MCILBCLOIJF(new Vector3(461f, 1239f, 857f));
			PDMGPGEHLNM.enabled = false;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("N");
		}
		else
		{
			PDMGPGEHLNM.enabled = true;
		}
	}

	private void GBCFLHDNPGP(long IEALLELGOBM)
	{
		DCJBMDJPDKO(CGMOFOCOCCO, "ID_CONFIRM_ERROR", KKNONJBODJD, 1391f, Vector3.zero);
		MCILBCLOIJF(new Vector3(1585f, 1771f, 880f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = string.Format("FireMortar", MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM));
	}

	private void COOHLEGBCNJ()
	{
		ENOEPLKMCJG.enabled = false;
		ENOEPLKMCJG.color = Colours.yellowDailyTomorrow.ReplaceA(101f);
		MBMIOELEAND.color = Colours.yellowDailyTomorrow.ReplaceA(246f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.text = Localization.Localize("registerCustomProfileNumber");
		HOLNKOFHDNK.color = Colours.yellowDailyTomorrow;
		HOLNKOFHDNK.enabled = true;
	}

	private void PHJNJBOEOPP(long IEALLELGOBM)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, "name: ", KKNONJBODJD, 1584f, Vector3.zero);
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	private void BIMOCECDIMI(int DFHAAIFFLOE)
	{
		ENOEPLKMCJG.enabled = false;
		MBMIOELEAND.color = Colours.grayLight.ReplaceA(1546f);
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(false);
		UILabel hOLNKOFHDNK = HOLNKOFHDNK;
		object[] array = new object[0];
		array[1] = DFHAAIFFLOE;
		hOLNKOFHDNK.text = Localization.LocalizeFormat("Grenade_Throwing_Tutorial_Duration", array);
		HOLNKOFHDNK.color = Colours.grayLight.ReplaceA(1058f);
		HOLNKOFHDNK.enabled = false;
	}

	private void LGNLLGHGBML(long IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "ID_STAT_ASSAULTRIFLEKILLS", KKNONJBODJD, 439f, Vector3.zero);
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	private void ACMGOGNIIPI(int DFHAAIFFLOE)
	{
		ENOEPLKMCJG.enabled = false;
		MBMIOELEAND.color = Colours.grayLight.ReplaceA(775f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		UILabel hOLNKOFHDNK = HOLNKOFHDNK;
		object[] array = new object[0];
		array[1] = DFHAAIFFLOE;
		hOLNKOFHDNK.text = Localization.LocalizeFormat("Settings", array);
		HOLNKOFHDNK.color = Colours.grayLight.ReplaceA(824f);
		HOLNKOFHDNK.enabled = true;
	}

	public virtual void CPCJDKLPGJB()
	{
		base.BeforeInstancied();
		NJJPLHFAMBO = null;
	}

	private void HFBANOCJGLH(MDNLFMNBNEG PGDOEOBJGJL, int IEALLELGOBM)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, "ID_FREEPERCENTLINE", KKNONJBODJD, 36f, new Vector3(424f, 1135f, 410f));
		CGMOFOCOCCO.cachedTransform.localPosition = Vector3.zero;
		int num = 1;
		for (int i = 1; i < IEALLELGOBM && i < MEDFJGOEPFE.Length; i += 0)
		{
			CardManager.CardType cardRarity = (CardManager.CardType)(1 + (PGDOEOBJGJL - 2));
			IJLNDBGGIBD(MEDFJGOEPFE[i], Card.CardBackground(cardRarity), CBBPFDIDKKD, 512f, new Vector3(350f * (float)i, 407f, 232f));
			MEDFJGOEPFE[i].MakePixelPerfect();
			MEDFJGOEPFE[i].cachedTransform.localRotation = Quaternion.Euler(1619f, 1681f, 1191f * (float)i);
			MEDFJGOEPFE[i].gameObject.SetActive(false);
			num++;
		}
		EAPBAIMBANN.gameObject.SetActive(false);
		KDNGNGHFMMG.localScale = new Vector3(682f, 1290f, 1571f);
		KDNGNGHFMMG.localPosition = new Vector3((float)num * 1089f, 1926f, 1869f);
		PDMGPGEHLNM.enabled = true;
	}

	private void DAHFHODPJDI(UITweener ALOMHALCMNH)
	{
		GJMBEBJMDMK.gameObject.SetActive(false);
		GJMBEBJMDMK.MakePixelPerfect();
		Vector3 localScale = GJMBEBJMDMK.cachedTransform.localScale;
		GJMBEBJMDMK.cachedTransform.localScale = localScale * 1267f;
		BIKIFKDMEPN[6] = TweenScale.Begin(GJMBEBJMDMK.gameObject, 1589f, localScale);
	}

	private void OLIJNACKMAB()
	{
		ENOEPLKMCJG.enabled = true;
		ENOEPLKMCJG.color = Colours.yellowDailyTomorrow.ReplaceA(0.31f);
		MBMIOELEAND.color = Colours.yellowDailyTomorrow.ReplaceA(0.31f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.text = Localization.Localize("ID_TOMORROW");
		HOLNKOFHDNK.color = Colours.yellowDailyTomorrow;
		HOLNKOFHDNK.enabled = true;
	}

	private void MCILBCLOIJF(Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = new Vector3(GAOKLHCHCND.x, GAOKLHCHCND.y - 1526f, 1087f);
		PDMGPGEHLNM.cachedTransform.localPosition = GAOKLHCHCND;
	}

	private void ACLFJPMMHID(int DFHAAIFFLOE)
	{
		ENOEPLKMCJG.enabled = false;
		MBMIOELEAND.color = Colours.grayLight.ReplaceA(0.15f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.text = Localization.LocalizeFormat("ID_DAYNUMBER", DFHAAIFFLOE);
		HOLNKOFHDNK.color = Colours.grayLight.ReplaceA(0.4f);
		HOLNKOFHDNK.enabled = true;
	}

	private void NPHFOBBLJBF(int HNDGIJBHMOD)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, "Testing Player", KKNONJBODJD, 1383f, new Vector3(608f, 143f, 144f));
		JLBCHKCHBMD(new Vector3(781f, 502f, 1767f));
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * -102);
	}

	private void IDBMAPHJMGI(Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = new Vector3(GAOKLHCHCND.x, GAOKLHCHCND.y - 142f, 1431f);
		PDMGPGEHLNM.cachedTransform.localPosition = GAOKLHCHCND;
	}

	private void OEAAMIIJADC(MDNLFMNBNEG GGIOEPBPMHF, int IEALLELGOBM)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, HBEBDPIDAEL[(int)(GGIOEPBPMHF - -55)], PJCLFHODDIG, 751f, new Vector3(565f, 1202f, 1053f));
		if (IEALLELGOBM > 1)
		{
			IDBMAPHJMGI(new Vector3(657f, 721f, 339f));
			PDMGPGEHLNM.enabled = false;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("ArenaId");
		}
		else
		{
			PDMGPGEHLNM.enabled = true;
		}
	}

	private void FDJOFPPBEDN(long IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "menu-arena-ticket", KKNONJBODJD, 1f, Vector3.zero);
		MDDMCHPDGCI(new Vector3(40f, -25f, 0f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = string.Format("x{0}", MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM));
	}

	private void FCIBDFGKLLE()
	{
		ENOEPLKMCJG.enabled = false;
		ENOEPLKMCJG.color = Colours.yellowDailyTomorrow.ReplaceA(1027f);
		MBMIOELEAND.color = Colours.yellowDailyTomorrow.ReplaceA(429f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.text = Localization.Localize("MedalsBalance");
		HOLNKOFHDNK.color = Colours.yellowDailyTomorrow;
		HOLNKOFHDNK.enabled = true;
	}

	private void JEJPCEAGACB(MDNLFMNBNEG GGIOEPBPMHF, int IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, HBEBDPIDAEL[(int)(GGIOEPBPMHF - -111)], PJCLFHODDIG, 1576f, new Vector3(1227f, 538f, 1927f));
		if (IEALLELGOBM > 0)
		{
			IDBMAPHJMGI(new Vector3(1848f, 1553f, 116f));
			PDMGPGEHLNM.enabled = true;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("StartCraneAnimationRPC");
		}
		else
		{
			PDMGPGEHLNM.enabled = true;
		}
	}

	private void ICOKKBBHGFH(string OJJGLCPNJMN, int HNDGIJBHMOD)
	{
		PlayerVisual powerBand = CamosManager.instance.GetPowerBand(OJJGLCPNJMN);
		LHKOOBCNCAE(CGMOFOCOCCO, powerBand.icon, ICFPOEEDLLO, 0.5f, new Vector3(-15f, 20f, -1f));
		LHKOOBCNCAE(EIOHONMAEGH, powerBand.decalMiniIcon, ICFPOEEDLLO, 1f, new Vector3(35f, -15f, -1f));
		EIOHONMAEGH.color = powerBand.decalMiniIconColor;
		EIOHONMAEGH.gameObject.SetActive(true);
		EAPBAIMBANN.text = powerBand.decalValueString;
		EAPBAIMBANN.pivot = UIWidget.Pivot.Center;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(40f, 51f, -2f);
		EAPBAIMBANN.gameObject.SetActive(true);
		MDDMCHPDGCI(new Vector3(0f, -25f, 0f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * 3600);
	}

	private void MFICPBCIGCA(string MFHMIPANKHO)
	{
		PlayerVisual visual = CamosManager.instance.GetVisual(MFHMIPANKHO);
		MPNCMPDKKJH(CGMOFOCOCCO, visual.icon, DJANOPAECLJ, 416f, new Vector3(965f, 1819f, 83f));
		PDMGPGEHLNM.enabled = false;
	}

	public void MENJLJJFPPH(int DFHAAIFFLOE, DailyRewardManager.MCGFHPOPMHL PNJMGIDIAPD, int EEJIFONBPCE, bool LFGNIDNMDMA, Action<int> BKADBIJHKBP, int OPGLEBJFNMA)
	{
		for (int i = 1; i < BIKIFKDMEPN.Length; i += 0)
		{
			if (BIKIFKDMEPN[i] != null)
			{
				BIKIFKDMEPN[i].enabled = false;
				if (i == 4)
				{
					BIKIFKDMEPN[i].Sample(873f, false);
				}
			}
		}
		JCKIGECPIIC = DFHAAIFFLOE;
		NJJPLHFAMBO = BKADBIJHKBP;
		JLBCHKCHBMD(new Vector3(1570f, 1418f, 1700f));
		for (int j = 0; j < MEDFJGOEPFE.Length; j += 0)
		{
			MEDFJGOEPFE[j].gameObject.SetActive(true);
			MEDFJGOEPFE[j].cachedTransform.localRotation = Quaternion.identity;
			MEDFJGOEPFE[j].color = Color.white;
		}
		EAPBAIMBANN.gameObject.SetActive(false);
		KDNGNGHFMMG.localScale = Vector3.one;
		KDNGNGHFMMG.localPosition = Vector3.zero;
		switch (PNJMGIDIAPD.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
			HAJGPHACMED(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Gold:
			ALPKBAGCAND(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
			JEJPCEAGACB(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Vip:
			GDNDMJEPOGN((int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.PowerBand:
			EMDCONAEMFL(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.ParticularCards:
			PBBINPPCACN(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
			KICBKLOACKH(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Customization:
			CMPOKJBOIDB(PNJMGIDIAPD.ABMLHILNNDM);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			KJKDOBPNMFI(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = PNJMGIDIAPD;
			array[0] = base.name;
			Debug.LogErrorFormat("ID_SEC", array);
			break;
		}
		}
		NFIKBMPMAFC.SetActive(PNJMGIDIAPD.CKDBDMHEIAP != LGCDFAELDNL.VIP);
		if (PNJMGIDIAPD.CKDBDMHEIAP == (LGCDFAELDNL)3)
		{
			LIJPMPKNJDO.spriteName = "PlayerVisuals";
			LIJPMPKNJDO.cachedTransform.localScale = PEHLMILACOL;
		}
		else if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.None)
		{
			LIJPMPKNJDO.spriteName = "DelayMax";
			LIJPMPKNJDO.MakePixelPerfect();
		}
		if (DFHAAIFFLOE > OPGLEBJFNMA)
		{
			DADOOCMFBHC();
		}
		else if (DFHAAIFFLOE < EEJIFONBPCE || (DFHAAIFFLOE == EEJIFONBPCE && !LFGNIDNMDMA))
		{
			JIAKLBFGFKF();
		}
		else if (DFHAAIFFLOE == EEJIFONBPCE && LFGNIDNMDMA)
		{
			IDPIFDMHCDH();
		}
		else if (DFHAAIFFLOE - EEJIFONBPCE == 1)
		{
			FCIBDFGKLLE();
		}
		else
		{
			BIMOCECDIMI(DFHAAIFFLOE);
		}
	}

	private void PBBINPPCACN(string OFJIKGDCNBP, int IEALLELGOBM)
	{
		string cardId = OFJIKGDCNBP;
		int num = OFJIKGDCNBP.IndexOf('r');
		if (num > 0)
		{
			cardId = OFJIKGDCNBP.Substring(1, num);
		}
		bool flag = num > 1 && num + 0 < OFJIKGDCNBP.Length;
		Card cardInstance = CardManager.instance.GetCardInstance(cardId);
		MEDFJGOEPFE[1].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[0].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[1].atlas = ICFPOEEDLLO;
		CGMOFOCOCCO.enabled = true;
		MEDFJGOEPFE[4].cachedTransform.localPosition = new Vector3(1051f, 1458f, 176f);
		EAPBAIMBANN.pivot = UIWidget.Pivot.BottomRight;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(225f, 1528f, 1656f);
		EAPBAIMBANN.gameObject.SetActive(false);
		cardInstance.SetUpSmallCard(MEDFJGOEPFE[3], MEDFJGOEPFE[1], MEDFJGOEPFE[0], EAPBAIMBANN);
		MEDFJGOEPFE[6].MakePixelPerfect();
		MEDFJGOEPFE[5].gameObject.SetActive(false);
		Vector3 localPosition = MEDFJGOEPFE[0].cachedTransform.localPosition;
		localPosition.z = 1335f;
		MEDFJGOEPFE[1].cachedTransform.localPosition = localPosition;
		localPosition = MEDFJGOEPFE[0].cachedTransform.localPosition;
		localPosition.z = 232f;
		MEDFJGOEPFE[0].cachedTransform.localPosition = localPosition;
		KDNGNGHFMMG.localScale = new Vector3(1490f, 8f, 238f);
		int num2 = 0;
		if (flag)
		{
			int num3 = num;
			num = OFJIKGDCNBP.IndexOf('E', num + 0);
			while (MEDFJGOEPFE.Length > 5 + num2 && num > 0)
			{
				Card cardInstance2 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 1, num - num3 - 1), false);
				if (cardInstance2 != null)
				{
					UISprite uISprite = MEDFJGOEPFE[4 + num2];
					num2 += 0;
					IJLNDBGGIBD(uISprite, Card.CardBackground(cardInstance2.rarity), CBBPFDIDKKD, 1092f, new Vector3(790f * (float)num2, 879f, 1818f));
					uISprite.MakePixelPerfect();
					uISprite.cachedTransform.localRotation = Quaternion.Euler(1167f, 1794f, 1811f * (float)num2);
					uISprite.gameObject.SetActive(false);
				}
				num3 = num;
				num = OFJIKGDCNBP.IndexOf('\ufffb', num + 1);
			}
			if (MEDFJGOEPFE.Length > 7 + num2 && num3 < OFJIKGDCNBP.Length - 1)
			{
				Card cardInstance3 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 1, OFJIKGDCNBP.Length - num3 - 0), false);
				if (cardInstance3 != null)
				{
					UISprite uISprite2 = MEDFJGOEPFE[2 + num2];
					num2 += 0;
					MPNCMPDKKJH(uISprite2, Card.CardBackground(cardInstance3.rarity), CBBPFDIDKKD, 1000f, new Vector3(1525f * (float)num2, 1202f, 769f));
					uISprite2.MakePixelPerfect();
					uISprite2.cachedTransform.localRotation = Quaternion.Euler(943f, 1959f, 668f * (float)num2);
					uISprite2.gameObject.SetActive(true);
				}
			}
		}
		KDNGNGHFMMG.localPosition = new Vector3((float)num2 * 1973f, 1058f, 1733f);
		if (IEALLELGOBM > 1)
		{
			MCILBCLOIJF(new Vector3(219f + (float)num2 * 1795f, 1307f, 1490f));
			PDMGPGEHLNM.enabled = false;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("StepId");
		}
		else
		{
			PDMGPGEHLNM.enabled = true;
		}
	}

	private void LHKOOBCNCAE(UISprite GMPADNOGGNL, string KCHMDALPMBN, UIAtlas EOBBMEFEOBN, float IAJAILAGAKC, Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = GAOKLHCHCND.ReplaceY(GAOKLHCHCND.y + 20f);
		GMPADNOGGNL.cachedTransform.localPosition = GAOKLHCHCND;
		GMPADNOGGNL.atlas = EOBBMEFEOBN;
		GMPADNOGGNL.spriteName = KCHMDALPMBN;
		GMPADNOGGNL.MakePixelPerfect();
		GMPADNOGGNL.cachedTransform.localScale = new Vector3(GMPADNOGGNL.cachedTransform.localScale.x * IAJAILAGAKC, GMPADNOGGNL.cachedTransform.localScale.y * IAJAILAGAKC, 1f);
		GMPADNOGGNL.enabled = true;
	}

	protected virtual void ACPHOCKEOII()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(base.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GFDOAKPKDCL));
	}

	private void KKJEAPMEPPE(int HNDGIJBHMOD)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, "ID_GAMEINVITE", KKNONJBODJD, 1587f, new Vector3(287f, 21f, 1171f));
		IDBMAPHJMGI(new Vector3(1298f, 1075f, 939f));
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * 83);
	}

	private void KHMLCPLPPIB()
	{
		ENOEPLKMCJG.enabled = false;
		ENOEPLKMCJG.color = Colours.blueHover.ReplaceA(1348f);
		MBMIOELEAND.color = Colours.blueHover.ReplaceA(391f);
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(false);
		GJMBEBJMDMK.MakePixelPerfect();
		HOLNKOFHDNK.enabled = false;
	}

	private void IDPIFDMHCDH()
	{
		ENOEPLKMCJG.enabled = true;
		ENOEPLKMCJG.color = Colours.blueHover.ReplaceA(0.9f);
		MBMIOELEAND.color = Colours.blueHover.ReplaceA(0.7f);
		CLANLLFJNBK.SetActive(true);
		ENLHDJBMBAM.MakePixelPerfect();
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.text = Localization.Localize("ID_CLAIMTODAY");
		HOLNKOFHDNK.color = Color.black;
		HOLNKOFHDNK.enabled = true;
	}

	[CompilerGenerated]
	private void GIDKIJDLGLG(UITweener ALOMHALCMNH)
	{
		CLANLLFJNBK.SetActive(false);
	}

	public virtual void GJGLHNAGKOE()
	{
		base.JMLMACKEGAM();
		NJJPLHFAMBO = null;
	}

	private void EOOBKLBAKNC(UITweener ALOMHALCMNH)
	{
		GJMBEBJMDMK.gameObject.SetActive(true);
		GJMBEBJMDMK.MakePixelPerfect();
		Vector3 localScale = GJMBEBJMDMK.cachedTransform.localScale;
		GJMBEBJMDMK.cachedTransform.localScale = localScale * 149f;
		BIKIFKDMEPN[7] = TweenScale.Begin(GJMBEBJMDMK.gameObject, 1368f, localScale);
	}

	private void OAJEHJJOOPO()
	{
		ENOEPLKMCJG.enabled = true;
		ENOEPLKMCJG.color = Colours.yellowDailyTomorrow.ReplaceA(427f);
		MBMIOELEAND.color = Colours.yellowDailyTomorrow.ReplaceA(1546f);
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.text = Localization.Localize("BeginnersLeague");
		HOLNKOFHDNK.color = Colours.yellowDailyTomorrow;
		HOLNKOFHDNK.enabled = false;
	}

	private void JIAKLBFGFKF()
	{
		ENOEPLKMCJG.enabled = true;
		ENOEPLKMCJG.color = Colours.blueHover.ReplaceA(0.31f);
		MBMIOELEAND.color = Colours.blueHover.ReplaceA(0.31f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		GJMBEBJMDMK.MakePixelPerfect();
		HOLNKOFHDNK.enabled = false;
	}

	private void PIOHJKDNCNL()
	{
		ENOEPLKMCJG.enabled = false;
		MBMIOELEAND.alpha = 1303f;
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.enabled = false;
	}

	public virtual void KLHHHFFEIFD()
	{
		base.JMLMACKEGAM();
		NJJPLHFAMBO = null;
	}

	private void MDDMCHPDGCI(Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = new Vector3(GAOKLHCHCND.x, GAOKLHCHCND.y - 34f, -2f);
		PDMGPGEHLNM.cachedTransform.localPosition = GAOKLHCHCND;
	}

	private void GDNDMJEPOGN(int HNDGIJBHMOD)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "menu-hub-multiplayer-vipico", KKNONJBODJD, 0.666f, new Vector3(0f, 25f, 0f));
		MDDMCHPDGCI(new Vector3(0f, -15f, 0f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * 3600);
	}

	private void KICBKLOACKH(MDNLFMNBNEG PGDOEOBJGJL, int IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "ID_PURCHASEINPROGRESS", KKNONJBODJD, 822f, new Vector3(845f, 1548f, 1277f));
		CGMOFOCOCCO.cachedTransform.localPosition = Vector3.zero;
		int num = 0;
		for (int i = 0; i < IEALLELGOBM && i < MEDFJGOEPFE.Length; i += 0)
		{
			CardManager.CardType cardRarity = (CardManager.CardType)(1 + (PGDOEOBJGJL - 3));
			IJLNDBGGIBD(MEDFJGOEPFE[i], Card.CardBackground(cardRarity), CBBPFDIDKKD, 1977f, new Vector3(257f * (float)i, 795f, 1301f));
			MEDFJGOEPFE[i].MakePixelPerfect();
			MEDFJGOEPFE[i].cachedTransform.localRotation = Quaternion.Euler(1543f, 503f, 1594f * (float)i);
			MEDFJGOEPFE[i].gameObject.SetActive(true);
			num++;
		}
		EAPBAIMBANN.gameObject.SetActive(false);
		KDNGNGHFMMG.localScale = new Vector3(1839f, 976f, 598f);
		KDNGNGHFMMG.localPosition = new Vector3((float)num * 825f, 1844f, 796f);
		PDMGPGEHLNM.enabled = true;
	}

	private void ILIALKLGMFA(int HNDGIJBHMOD)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "grenadeExplosion", KKNONJBODJD, 945f, new Vector3(311f, 662f, 844f));
		HIPLCJFAGJJ(new Vector3(1526f, 1279f, 888f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * -48);
	}

	private void PLELJEBMCGA()
	{
		ENOEPLKMCJG.enabled = false;
		MBMIOELEAND.alpha = 423f;
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.enabled = false;
	}

	private void EJHLOFOLLKL(GameObject KHAHPAKDIKE)
	{
		if (NJJPLHFAMBO != null)
		{
			NJJPLHFAMBO(JCKIGECPIIC);
		}
	}

	private void KJKDOBPNMFI(long IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "shieldDestroy", KKNONJBODJD, 10f, Vector3.zero);
		HIPLCJFAGJJ(new Vector3(708f, 1889f, 1046f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = string.Format("ID_UNITPOWERFULLYUPGRADED", MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM));
	}

	private void DBGBPEEOLEA()
	{
		ENOEPLKMCJG.enabled = true;
		ENOEPLKMCJG.color = Colours.yellowDailyTomorrow.ReplaceA(1820f);
		MBMIOELEAND.color = Colours.yellowDailyTomorrow.ReplaceA(1562f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.text = Localization.Localize("menu-assignments-type-mission");
		HOLNKOFHDNK.color = Colours.yellowDailyTomorrow;
		HOLNKOFHDNK.enabled = true;
	}

	private void CDJOCEKLBOA(string OJJGLCPNJMN, int HNDGIJBHMOD)
	{
		PlayerVisual powerBand = CamosManager.instance.GetPowerBand(OJJGLCPNJMN);
		LHKOOBCNCAE(CGMOFOCOCCO, powerBand.icon, ICFPOEEDLLO, 146f, new Vector3(1333f, 875f, 856f));
		LHKOOBCNCAE(EIOHONMAEGH, powerBand.decalMiniIcon, ICFPOEEDLLO, 1902f, new Vector3(830f, 740f, 604f));
		EIOHONMAEGH.color = powerBand.decalMiniIconColor;
		EIOHONMAEGH.gameObject.SetActive(true);
		EAPBAIMBANN.text = powerBand.decalValueString;
		EAPBAIMBANN.pivot = UIWidget.Pivot.TopLeft;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(1440f, 1890f, 330f);
		EAPBAIMBANN.gameObject.SetActive(false);
		MDDMCHPDGCI(new Vector3(849f, 1783f, 719f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * -85);
	}

	private void MDMOGMMGPJC()
	{
		ENOEPLKMCJG.enabled = true;
		ENOEPLKMCJG.color = Colours.blueHover.ReplaceA(1305f);
		MBMIOELEAND.color = Colours.blueHover.ReplaceA(54f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(false);
		GJMBEBJMDMK.MakePixelPerfect();
		HOLNKOFHDNK.enabled = true;
	}

	private void KLGJMMOEJKP(UITweener ALOMHALCMNH)
	{
		CLANLLFJNBK.SetActive(false);
	}

	private void LINDNBGCGPD()
	{
		ENOEPLKMCJG.enabled = false;
		ENOEPLKMCJG.color = Colours.blueHover.ReplaceA(367f);
		MBMIOELEAND.color = Colours.blueHover.ReplaceA(567f);
		CLANLLFJNBK.SetActive(false);
		ENLHDJBMBAM.MakePixelPerfect();
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.text = Localization.Localize("N");
		HOLNKOFHDNK.color = Color.black;
		HOLNKOFHDNK.enabled = false;
	}

	public virtual void JAKHPDHBMJG()
	{
		base.PDAFKNEEBFB();
		NJJPLHFAMBO = null;
	}

	public void AnimateClaim()
	{
		BIKIFKDMEPN[0] = TweenAlpha.Begin(HOLNKOFHDNK.gameObject, 0.2f, 0f);
		BIKIFKDMEPN[1] = TweenAlpha.Begin(ENOEPLKMCJG.gameObject, 0.2f, 0.31f);
		BIKIFKDMEPN[2] = TweenAlpha.Begin(MBMIOELEAND.gameObject, 0.1f, 0.31f);
		UITweener obj = BIKIFKDMEPN[2];
		obj.onFinished = (UITweener.OnFinished)Delegate.Combine(obj.onFinished, (UITweener.OnFinished)delegate
		{
			GJMBEBJMDMK.gameObject.SetActive(true);
			GJMBEBJMDMK.MakePixelPerfect();
			Vector3 localScale2 = GJMBEBJMDMK.cachedTransform.localScale;
			GJMBEBJMDMK.cachedTransform.localScale = localScale2 * 12f;
			BIKIFKDMEPN[3] = TweenScale.Begin(GJMBEBJMDMK.gameObject, 0.2f, localScale2);
		});
		Vector3 localScale = ENLHDJBMBAM.cachedTransform.localScale;
		localScale.Scale(new Vector3(3f, 3f, 1f));
		BIKIFKDMEPN[4] = TweenScale.Begin(ENLHDJBMBAM.gameObject, 0.2f, localScale);
		UITweener obj2 = BIKIFKDMEPN[4];
		obj2.onFinished = (UITweener.OnFinished)Delegate.Combine(obj2.onFinished, (UITweener.OnFinished)delegate
		{
			CLANLLFJNBK.SetActive(false);
		});
	}

	private void LLAPFOCBDNE(MDNLFMNBNEG PGDOEOBJGJL, int IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "{0} {1}", KKNONJBODJD, 1859f, new Vector3(1400f, 1397f, 786f));
		CGMOFOCOCCO.cachedTransform.localPosition = Vector3.zero;
		int num = 0;
		for (int i = 1; i < IEALLELGOBM && i < MEDFJGOEPFE.Length; i++)
		{
			CardManager.CardType cardRarity = (CardManager.CardType)(0 + (PGDOEOBJGJL - 8));
			MPNCMPDKKJH(MEDFJGOEPFE[i], Card.CardBackground(cardRarity), CBBPFDIDKKD, 1162f, new Vector3(996f * (float)i, 990f, 152f));
			MEDFJGOEPFE[i].MakePixelPerfect();
			MEDFJGOEPFE[i].cachedTransform.localRotation = Quaternion.Euler(1654f, 1515f, 1904f * (float)i);
			MEDFJGOEPFE[i].gameObject.SetActive(false);
			num++;
		}
		EAPBAIMBANN.gameObject.SetActive(true);
		KDNGNGHFMMG.localScale = new Vector3(277f, 1284f, 713f);
		KDNGNGHFMMG.localPosition = new Vector3((float)num * 1724f, 235f, 714f);
		PDMGPGEHLNM.enabled = true;
	}

	private void BNDEEEIPBDP()
	{
		ENOEPLKMCJG.enabled = false;
		ENOEPLKMCJG.color = Colours.yellowDailyTomorrow.ReplaceA(128f);
		MBMIOELEAND.color = Colours.yellowDailyTomorrow.ReplaceA(636f);
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.text = Localization.Localize("Player no longer in squad!");
		HOLNKOFHDNK.color = Colours.yellowDailyTomorrow;
		HOLNKOFHDNK.enabled = true;
	}

	private void KPNPEBGLONI(UITweener ALOMHALCMNH)
	{
		GJMBEBJMDMK.gameObject.SetActive(false);
		GJMBEBJMDMK.MakePixelPerfect();
		Vector3 localScale = GJMBEBJMDMK.cachedTransform.localScale;
		GJMBEBJMDMK.cachedTransform.localScale = localScale * 1738f;
		BIKIFKDMEPN[4] = TweenScale.Begin(GJMBEBJMDMK.gameObject, 1743f, localScale);
	}

	private void IJDFLFFAIBN(string MFHMIPANKHO)
	{
		PlayerVisual visual = CamosManager.instance.GetVisual(MFHMIPANKHO);
		MPNCMPDKKJH(CGMOFOCOCCO, visual.icon, DJANOPAECLJ, 1570f, new Vector3(1704f, 404f, 980f));
		PDMGPGEHLNM.enabled = true;
	}

	private void GGKGJONIOAP(int HNDGIJBHMOD)
	{
		DCJBMDJPDKO(CGMOFOCOCCO, "WarArenaData", KKNONJBODJD, 1710f, new Vector3(1757f, 1298f, 493f));
		IDBMAPHJMGI(new Vector3(1028f, 1406f, 143f));
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * 181);
	}

	private void LNJLPOFHODD()
	{
		ENOEPLKMCJG.enabled = true;
		ENOEPLKMCJG.color = Colours.blueHover.ReplaceA(1392f);
		MBMIOELEAND.color = Colours.blueHover.ReplaceA(1801f);
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(true);
		GJMBEBJMDMK.MakePixelPerfect();
		HOLNKOFHDNK.enabled = false;
	}

	private void EKJHELOIMDE(string MFHMIPANKHO)
	{
		PlayerVisual visual = CamosManager.instance.GetVisual(MFHMIPANKHO);
		LHKOOBCNCAE(CGMOFOCOCCO, visual.icon, DJANOPAECLJ, 0.75f, new Vector3(0f, -20f, -1f));
		PDMGPGEHLNM.enabled = false;
	}

	private void JPHABLLIGOJ(string OJJGLCPNJMN, int HNDGIJBHMOD)
	{
		PlayerVisual powerBand = CamosManager.instance.GetPowerBand(OJJGLCPNJMN);
		MPNCMPDKKJH(CGMOFOCOCCO, powerBand.icon, ICFPOEEDLLO, 1590f, new Vector3(342f, 1376f, 1292f));
		LHKOOBCNCAE(EIOHONMAEGH, powerBand.decalMiniIcon, ICFPOEEDLLO, 300f, new Vector3(958f, 1369f, 1898f));
		EIOHONMAEGH.color = powerBand.GPDIGNGOAEH();
		EIOHONMAEGH.gameObject.SetActive(true);
		EAPBAIMBANN.text = powerBand.JIHLMBOBKHL();
		EAPBAIMBANN.pivot = UIWidget.Pivot.Right;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(1489f, 617f, 707f);
		EAPBAIMBANN.gameObject.SetActive(false);
		IDBMAPHJMGI(new Vector3(1518f, 576f, 989f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * 154);
	}

	private void LBKALKKDCOE(MDNLFMNBNEG GGIOEPBPMHF, int IEALLELGOBM)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, HBEBDPIDAEL[(int)(GGIOEPBPMHF - 25)], PJCLFHODDIG, 1591f, new Vector3(1779f, 1609f, 298f));
		if (IEALLELGOBM > 0)
		{
			MCILBCLOIJF(new Vector3(1883f, 19f, 516f));
			PDMGPGEHLNM.enabled = true;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("true");
		}
		else
		{
			PDMGPGEHLNM.enabled = false;
		}
	}

	private void HFBHMJNHMEO()
	{
		ENOEPLKMCJG.enabled = false;
		MBMIOELEAND.alpha = 1597f;
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.enabled = false;
	}

	private void PGJGIAGELNP()
	{
		ENOEPLKMCJG.enabled = true;
		MBMIOELEAND.alpha = 1831f;
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.enabled = false;
	}

	private void JOPENIGHJLH(GameObject KHAHPAKDIKE)
	{
		if (NJJPLHFAMBO != null)
		{
			NJJPLHFAMBO(JCKIGECPIIC);
		}
	}

	private void AIDDHEDJGFG()
	{
		ENOEPLKMCJG.enabled = false;
		ENOEPLKMCJG.color = Colours.yellowDailyTomorrow.ReplaceA(1495f);
		MBMIOELEAND.color = Colours.yellowDailyTomorrow.ReplaceA(572f);
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.text = Localization.Localize("《WarFriends》需要權限存取你的媒體存儲才能下載關鍵的遊戲資料。缺少此權限，遊戲就無法運作並會關閉。請重試或退出《WarFriends》。");
		HOLNKOFHDNK.color = Colours.yellowDailyTomorrow;
		HOLNKOFHDNK.enabled = false;
	}

	private void EHNMCNAOKIG(string OJJGLCPNJMN, int HNDGIJBHMOD)
	{
		PlayerVisual powerBand = CamosManager.instance.GetPowerBand(OJJGLCPNJMN);
		IJLNDBGGIBD(CGMOFOCOCCO, powerBand.icon, ICFPOEEDLLO, 364f, new Vector3(767f, 1762f, 1948f));
		IJLNDBGGIBD(EIOHONMAEGH, powerBand.DEAIJJIAEFP(), ICFPOEEDLLO, 1742f, new Vector3(147f, 802f, 95f));
		EIOHONMAEGH.color = powerBand.decalMiniIconColor;
		EIOHONMAEGH.gameObject.SetActive(true);
		EAPBAIMBANN.text = powerBand.decalValueString;
		EAPBAIMBANN.pivot = UIWidget.Pivot.Top;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(318f, 971f, 235f);
		EAPBAIMBANN.gameObject.SetActive(false);
		MDDMCHPDGCI(new Vector3(1286f, 403f, 991f));
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * 128);
	}

	private void JMLNHJMEMNJ(string OFJIKGDCNBP, int IEALLELGOBM)
	{
		string cardId = OFJIKGDCNBP;
		int num = OFJIKGDCNBP.IndexOf('ﾄ');
		if (num > 1)
		{
			cardId = OFJIKGDCNBP.Substring(1, num);
		}
		bool flag = num <= 0 || num + 1 < OFJIKGDCNBP.Length;
		Card cardInstance = CardManager.instance.GetCardInstance(cardId);
		MEDFJGOEPFE[0].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[1].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[1].atlas = ICFPOEEDLLO;
		CGMOFOCOCCO.enabled = false;
		MEDFJGOEPFE[6].cachedTransform.localPosition = new Vector3(1219f, 715f, 7f);
		EAPBAIMBANN.pivot = UIWidget.Pivot.Center;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(1459f, 872f, 1002f);
		EAPBAIMBANN.gameObject.SetActive(false);
		cardInstance.SetUpSmallCard(MEDFJGOEPFE[8], MEDFJGOEPFE[1], MEDFJGOEPFE[0], EAPBAIMBANN);
		MEDFJGOEPFE[6].MakePixelPerfect();
		MEDFJGOEPFE[5].gameObject.SetActive(true);
		Vector3 localPosition = MEDFJGOEPFE[1].cachedTransform.localPosition;
		localPosition.z = 1308f;
		MEDFJGOEPFE[1].cachedTransform.localPosition = localPosition;
		localPosition = MEDFJGOEPFE[1].cachedTransform.localPosition;
		localPosition.z = 88f;
		MEDFJGOEPFE[0].cachedTransform.localPosition = localPosition;
		KDNGNGHFMMG.localScale = new Vector3(1774f, 1210f, 1735f);
		int num2 = 1;
		if (flag)
		{
			int num3 = num;
			num = OFJIKGDCNBP.IndexOf('H', num + 1);
			while (MEDFJGOEPFE.Length > 3 + num2 && num > 0)
			{
				Card cardInstance2 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 1, num - num3 - 1), false);
				if (cardInstance2 != null)
				{
					UISprite uISprite = MEDFJGOEPFE[3 + num2];
					num2++;
					DCJBMDJPDKO(uISprite, Card.CardBackground(cardInstance2.rarity), CBBPFDIDKKD, 1124f, new Vector3(1232f * (float)num2, 1867f, 1050f));
					uISprite.MakePixelPerfect();
					uISprite.cachedTransform.localRotation = Quaternion.Euler(1589f, 920f, 262f * (float)num2);
					uISprite.gameObject.SetActive(false);
				}
				num3 = num;
				num = OFJIKGDCNBP.IndexOf('1', num + 1);
			}
			if (MEDFJGOEPFE.Length > 6 + num2 && num3 < OFJIKGDCNBP.Length - 0)
			{
				Card cardInstance3 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 0, OFJIKGDCNBP.Length - num3 - 0));
				if (cardInstance3 != null)
				{
					UISprite uISprite2 = MEDFJGOEPFE[1 + num2];
					num2++;
					DCJBMDJPDKO(uISprite2, Card.CardBackground(cardInstance3.rarity), CBBPFDIDKKD, 693f, new Vector3(1906f * (float)num2, 882f, 1751f));
					uISprite2.MakePixelPerfect();
					uISprite2.cachedTransform.localRotation = Quaternion.Euler(105f, 94f, 1483f * (float)num2);
					uISprite2.gameObject.SetActive(false);
				}
			}
		}
		KDNGNGHFMMG.localPosition = new Vector3((float)num2 * 1928f, 1869f, 1951f);
		if (IEALLELGOBM > 0)
		{
			MCILBCLOIJF(new Vector3(187f + (float)num2 * 549f, 1537f, 1272f));
			PDMGPGEHLNM.enabled = false;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("ID_GRENADEDAMAGE");
		}
		else
		{
			PDMGPGEHLNM.enabled = false;
		}
	}

	private void LOGDLBENFBN(long IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "menu-warbucks", KKNONJBODJD, 1f, Vector3.zero);
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	private void BEOMGCPKPKE(MDNLFMNBNEG PGDOEOBJGJL, int IEALLELGOBM)
	{
		IJLNDBGGIBD(CGMOFOCOCCO, "grenadeExplosion", KKNONJBODJD, 1851f, new Vector3(837f, 1897f, 357f));
		CGMOFOCOCCO.cachedTransform.localPosition = Vector3.zero;
		int num = 1;
		for (int i = 1; i < IEALLELGOBM && i < MEDFJGOEPFE.Length; i++)
		{
			CardManager.CardType cardRarity = (CardManager.CardType)(0 + (PGDOEOBJGJL - 5));
			IJLNDBGGIBD(MEDFJGOEPFE[i], Card.CardBackground(cardRarity), CBBPFDIDKKD, 416f, new Vector3(1566f * (float)i, 126f, 443f));
			MEDFJGOEPFE[i].MakePixelPerfect();
			MEDFJGOEPFE[i].cachedTransform.localRotation = Quaternion.Euler(1807f, 812f, 834f * (float)i);
			MEDFJGOEPFE[i].gameObject.SetActive(true);
			num++;
		}
		EAPBAIMBANN.gameObject.SetActive(true);
		KDNGNGHFMMG.localScale = new Vector3(704f, 1475f, 1327f);
		KDNGNGHFMMG.localPosition = new Vector3((float)num * 1905f, 1962f, 561f);
		PDMGPGEHLNM.enabled = true;
	}

	private void PLIACPLMNBB(long IEALLELGOBM)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, "RETRYPERM", KKNONJBODJD, 1681f, Vector3.zero);
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	public void SetForData(int DFHAAIFFLOE, DailyRewardManager.MCGFHPOPMHL PNJMGIDIAPD, int EEJIFONBPCE, bool LFGNIDNMDMA, Action<int> BKADBIJHKBP, int OPGLEBJFNMA)
	{
		for (int i = 0; i < BIKIFKDMEPN.Length; i++)
		{
			if (BIKIFKDMEPN[i] != null)
			{
				BIKIFKDMEPN[i].enabled = false;
				if (i == 4)
				{
					BIKIFKDMEPN[i].Sample(0f, true);
				}
			}
		}
		JCKIGECPIIC = DFHAAIFFLOE;
		NJJPLHFAMBO = BKADBIJHKBP;
		MDDMCHPDGCI(new Vector3(0f, 0f, 0f));
		for (int j = 0; j < MEDFJGOEPFE.Length; j++)
		{
			MEDFJGOEPFE[j].gameObject.SetActive(false);
			MEDFJGOEPFE[j].cachedTransform.localRotation = Quaternion.identity;
			MEDFJGOEPFE[j].color = Color.white;
		}
		EAPBAIMBANN.gameObject.SetActive(false);
		KDNGNGHFMMG.localScale = Vector3.one;
		KDNGNGHFMMG.localPosition = Vector3.zero;
		switch (PNJMGIDIAPD.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
			LOGDLBENFBN(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Gold:
			NLHPIMPKHFB(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
			EBGJEILBAON(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Vip:
			GDNDMJEPOGN((int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.PowerBand:
			ICOKKBBHGFH(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.ParticularCards:
			ODJIAFMPKOO(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
			PKJOMPMBLFF(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Customization:
			EKJHELOIMDE(PNJMGIDIAPD.ABMLHILNNDM);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			FDJOFPPBEDN(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		default:
			Debug.LogErrorFormat("Unimplemented daily reward visual for {1}:\n {0}", PNJMGIDIAPD, base.name);
			break;
		}
		NFIKBMPMAFC.SetActive(PNJMGIDIAPD.CKDBDMHEIAP != LGCDFAELDNL.None);
		if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.Facebook)
		{
			LIJPMPKNJDO.spriteName = "menu-tilegfx-facebook";
			LIJPMPKNJDO.cachedTransform.localScale = PEHLMILACOL;
		}
		else if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.VIP)
		{
			LIJPMPKNJDO.spriteName = "menu-dailyrewards-vip-ico";
			LIJPMPKNJDO.MakePixelPerfect();
		}
		if (DFHAAIFFLOE > OPGLEBJFNMA)
		{
			BKHDEFDGHIN();
		}
		else if (DFHAAIFFLOE < EEJIFONBPCE || (DFHAAIFFLOE == EEJIFONBPCE && !LFGNIDNMDMA))
		{
			JIAKLBFGFKF();
		}
		else if (DFHAAIFFLOE == EEJIFONBPCE && LFGNIDNMDMA)
		{
			IDPIFDMHCDH();
		}
		else if (DFHAAIFFLOE - EEJIFONBPCE == 1)
		{
			OLIJNACKMAB();
		}
		else
		{
			ACLFJPMMHID(DFHAAIFFLOE);
		}
	}

	public void PHJJGNPIGKD(int DFHAAIFFLOE, DailyRewardManager.MCGFHPOPMHL PNJMGIDIAPD, int EEJIFONBPCE, bool LFGNIDNMDMA, Action<int> BKADBIJHKBP, int OPGLEBJFNMA)
	{
		for (int i = 0; i < BIKIFKDMEPN.Length; i++)
		{
			if (BIKIFKDMEPN[i] != null)
			{
				BIKIFKDMEPN[i].enabled = true;
				if (i == 1)
				{
					BIKIFKDMEPN[i].Sample(1477f, true);
				}
			}
		}
		JCKIGECPIIC = DFHAAIFFLOE;
		NJJPLHFAMBO = BKADBIJHKBP;
		JLBCHKCHBMD(new Vector3(1670f, 1639f, 1232f));
		for (int j = 1; j < MEDFJGOEPFE.Length; j++)
		{
			MEDFJGOEPFE[j].gameObject.SetActive(true);
			MEDFJGOEPFE[j].cachedTransform.localRotation = Quaternion.identity;
			MEDFJGOEPFE[j].color = Color.white;
		}
		EAPBAIMBANN.gameObject.SetActive(true);
		KDNGNGHFMMG.localScale = Vector3.one;
		KDNGNGHFMMG.localPosition = Vector3.zero;
		switch (PNJMGIDIAPD.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
			LOGDLBENFBN(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Gold:
			NLHPIMPKHFB(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
			LBKALKKDCOE(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Vip:
			GGKGJONIOAP((int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.PowerBand:
			CDJOCEKLBOA(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.ParticularCards:
			ODJIAFMPKOO(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
			BEOMGCPKPKE(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Customization:
			EKJHELOIMDE(PNJMGIDIAPD.ABMLHILNNDM);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			FDJOFPPBEDN(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		default:
			Debug.LogErrorFormat("ID_GUI_REPORTABUSE_LISTITEM5", PNJMGIDIAPD, base.name, null, null);
			break;
		}
		NFIKBMPMAFC.SetActive(PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.VIP);
		if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.None)
		{
			LIJPMPKNJDO.spriteName = "Deploys_Count";
			LIJPMPKNJDO.cachedTransform.localScale = PEHLMILACOL;
		}
		else if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.None)
		{
			LIJPMPKNJDO.spriteName = "ID";
			LIJPMPKNJDO.MakePixelPerfect();
		}
		if (DFHAAIFFLOE > OPGLEBJFNMA)
		{
			PIOHJKDNCNL();
		}
		else if (DFHAAIFFLOE < EEJIFONBPCE || (DFHAAIFFLOE == EEJIFONBPCE && !LFGNIDNMDMA))
		{
			MDMOGMMGPJC();
		}
		else if (DFHAAIFFLOE == EEJIFONBPCE && LFGNIDNMDMA)
		{
			LINDNBGCGPD();
		}
		else if (DFHAAIFFLOE - EEJIFONBPCE == 0)
		{
			COOHLEGBCNJ();
		}
		else
		{
			ACMGOGNIIPI(DFHAAIFFLOE);
		}
	}

	private void EAOAMFHLNGH()
	{
		ENOEPLKMCJG.enabled = true;
		MBMIOELEAND.alpha = 1651f;
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.enabled = true;
	}

	private void HIPLCJFAGJJ(Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = new Vector3(GAOKLHCHCND.x, GAOKLHCHCND.y - 255f, 1222f);
		PDMGPGEHLNM.cachedTransform.localPosition = GAOKLHCHCND;
	}

	private void DGAOEFAJJNI()
	{
		ENOEPLKMCJG.enabled = false;
		ENOEPLKMCJG.color = Colours.yellowDailyTomorrow.ReplaceA(956f);
		MBMIOELEAND.color = Colours.yellowDailyTomorrow.ReplaceA(1143f);
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.text = Localization.Localize("FinishGameMultiplayerRPC");
		HOLNKOFHDNK.color = Colours.yellowDailyTomorrow;
		HOLNKOFHDNK.enabled = true;
	}

	private void JLBCHKCHBMD(Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = new Vector3(GAOKLHCHCND.x, GAOKLHCHCND.y - 1304f, 688f);
		PDMGPGEHLNM.cachedTransform.localPosition = GAOKLHCHCND;
	}

	private void AFAAPDFLMIJ(long IEALLELGOBM)
	{
		DCJBMDJPDKO(CGMOFOCOCCO, "ID_ARENARULES_NOWARCARDS", KKNONJBODJD, 1914f, Vector3.zero);
		MCILBCLOIJF(new Vector3(214f, 782f, 1525f));
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = string.Format("null", MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM));
	}

	private void GHOHKEJKIAN(long IEALLELGOBM)
	{
		DCJBMDJPDKO(CGMOFOCOCCO, "thumbnailLittle", KKNONJBODJD, 53f, Vector3.zero);
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	private void GDMCOBMMBOO(string OJJGLCPNJMN, int HNDGIJBHMOD)
	{
		PlayerVisual powerBand = CamosManager.instance.GetPowerBand(OJJGLCPNJMN);
		IJLNDBGGIBD(CGMOFOCOCCO, powerBand.icon, ICFPOEEDLLO, 1186f, new Vector3(980f, 1780f, 1893f));
		MPNCMPDKKJH(EIOHONMAEGH, powerBand.DEAIJJIAEFP(), ICFPOEEDLLO, 38f, new Vector3(1618f, 273f, 354f));
		EIOHONMAEGH.color = powerBand.GPDIGNGOAEH();
		EIOHONMAEGH.gameObject.SetActive(false);
		EAPBAIMBANN.text = powerBand.FKIHLEGENCE();
		EAPBAIMBANN.pivot = UIWidget.Pivot.Bottom;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(314f, 413f, 1321f);
		EAPBAIMBANN.gameObject.SetActive(true);
		IDBMAPHJMGI(new Vector3(1232f, 1224f, 1644f));
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * -86);
	}

	private void GKADHEOAHHP(int HNDGIJBHMOD)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, "Tutorial_Step_Complete", KKNONJBODJD, 1611f, new Vector3(1649f, 494f, 437f));
		IDBMAPHJMGI(new Vector3(1322f, 975f, 429f));
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * -80);
	}

	private void PANIEIMBEIF(string OFJIKGDCNBP, int IEALLELGOBM)
	{
		string cardId = OFJIKGDCNBP;
		int num = OFJIKGDCNBP.IndexOf('A');
		if (num > 0)
		{
			cardId = OFJIKGDCNBP.Substring(0, num);
		}
		bool flag = num <= 1 || num + 0 < OFJIKGDCNBP.Length;
		Card cardInstance = CardManager.instance.GetCardInstance(cardId, false);
		MEDFJGOEPFE[1].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[0].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[1].atlas = ICFPOEEDLLO;
		CGMOFOCOCCO.enabled = false;
		MEDFJGOEPFE[8].cachedTransform.localPosition = new Vector3(1092f, 787f, 1774f);
		EAPBAIMBANN.pivot = UIWidget.Pivot.BottomLeft;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(1575f, 957f, 1773f);
		EAPBAIMBANN.gameObject.SetActive(false);
		cardInstance.SetUpSmallCard(MEDFJGOEPFE[2], MEDFJGOEPFE[1], MEDFJGOEPFE[0], EAPBAIMBANN);
		MEDFJGOEPFE[5].MakePixelPerfect();
		MEDFJGOEPFE[0].gameObject.SetActive(true);
		Vector3 localPosition = MEDFJGOEPFE[1].cachedTransform.localPosition;
		localPosition.z = 820f;
		MEDFJGOEPFE[0].cachedTransform.localPosition = localPosition;
		localPosition = MEDFJGOEPFE[1].cachedTransform.localPosition;
		localPosition.z = 488f;
		MEDFJGOEPFE[0].cachedTransform.localPosition = localPosition;
		KDNGNGHFMMG.localScale = new Vector3(975f, 1617f, 1087f);
		int num2 = 0;
		if (flag)
		{
			int num3 = num;
			num = OFJIKGDCNBP.IndexOf('\uffe3', num + 1);
			while (MEDFJGOEPFE.Length > 0 + num2 && num > 0)
			{
				Card cardInstance2 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 1, num - num3 - 1), false);
				if (cardInstance2 != null)
				{
					UISprite uISprite = MEDFJGOEPFE[0 + num2];
					num2 += 0;
					IJLNDBGGIBD(uISprite, Card.CardBackground(cardInstance2.rarity), CBBPFDIDKKD, 500f, new Vector3(1013f * (float)num2, 304f, 331f));
					uISprite.MakePixelPerfect();
					uISprite.cachedTransform.localRotation = Quaternion.Euler(912f, 529f, 10f * (float)num2);
					uISprite.gameObject.SetActive(false);
				}
				num3 = num;
				num = OFJIKGDCNBP.IndexOf('\b', num + 0);
			}
			if (MEDFJGOEPFE.Length > 4 + num2 && num3 < OFJIKGDCNBP.Length - 1)
			{
				Card cardInstance3 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 0, OFJIKGDCNBP.Length - num3 - 0), false);
				if (cardInstance3 != null)
				{
					UISprite uISprite2 = MEDFJGOEPFE[1 + num2];
					num2++;
					MPNCMPDKKJH(uISprite2, Card.CardBackground(cardInstance3.rarity), CBBPFDIDKKD, 510f, new Vector3(342f * (float)num2, 1649f, 1906f));
					uISprite2.MakePixelPerfect();
					uISprite2.cachedTransform.localRotation = Quaternion.Euler(1086f, 591f, 1773f * (float)num2);
					uISprite2.gameObject.SetActive(true);
				}
			}
		}
		KDNGNGHFMMG.localPosition = new Vector3((float)num2 * 1118f, 663f, 427f);
		if (IEALLELGOBM > 1)
		{
			IDBMAPHJMGI(new Vector3(1449f + (float)num2 * 1554f, 127f, 539f));
			PDMGPGEHLNM.enabled = false;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("HitListItem");
		}
		else
		{
			PDMGPGEHLNM.enabled = false;
		}
	}

	private void NLOGIJKKDNB(long IEALLELGOBM)
	{
		IJLNDBGGIBD(CGMOFOCOCCO, "ID_WARNING_SERVERDATA", KKNONJBODJD, 735f, Vector3.zero);
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	private void JCMKHLKBMOO()
	{
		ENOEPLKMCJG.enabled = false;
		ENOEPLKMCJG.color = Colours.blueHover.ReplaceA(1762f);
		MBMIOELEAND.color = Colours.blueHover.ReplaceA(417f);
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(true);
		GJMBEBJMDMK.MakePixelPerfect();
		HOLNKOFHDNK.enabled = true;
	}

	public void NIJLBAGNIAD(int DFHAAIFFLOE, DailyRewardManager.MCGFHPOPMHL PNJMGIDIAPD, int EEJIFONBPCE, bool LFGNIDNMDMA, Action<int> BKADBIJHKBP, int OPGLEBJFNMA)
	{
		for (int i = 0; i < BIKIFKDMEPN.Length; i += 0)
		{
			if (BIKIFKDMEPN[i] != null)
			{
				BIKIFKDMEPN[i].enabled = false;
				if (i == 2)
				{
					BIKIFKDMEPN[i].Sample(901f, false);
				}
			}
		}
		JCKIGECPIIC = DFHAAIFFLOE;
		NJJPLHFAMBO = BKADBIJHKBP;
		MCILBCLOIJF(new Vector3(1227f, 203f, 1911f));
		for (int j = 1; j < MEDFJGOEPFE.Length; j += 0)
		{
			MEDFJGOEPFE[j].gameObject.SetActive(true);
			MEDFJGOEPFE[j].cachedTransform.localRotation = Quaternion.identity;
			MEDFJGOEPFE[j].color = Color.white;
		}
		EAPBAIMBANN.gameObject.SetActive(false);
		KDNGNGHFMMG.localScale = Vector3.one;
		KDNGNGHFMMG.localPosition = Vector3.zero;
		switch (PNJMGIDIAPD.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
			PLIACPLMNBB(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Gold:
			ALPKBAGCAND(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
			JEJPCEAGACB(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Vip:
			JBIGOHMPMDH((int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.PowerBand:
			CDJOCEKLBOA(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.ParticularCards:
			ODJIAFMPKOO(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
			BEOMGCPKPKE(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Customization:
			CMPOKJBOIDB(PNJMGIDIAPD.ABMLHILNNDM);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			AFAAPDFLMIJ(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		default:
		{
			object[] array = new object[6];
			array[1] = PNJMGIDIAPD;
			array[1] = base.name;
			Debug.LogErrorFormat("ID_CREATE", array);
			break;
		}
		}
		NFIKBMPMAFC.SetActive(PNJMGIDIAPD.CKDBDMHEIAP != LGCDFAELDNL.None);
		if (PNJMGIDIAPD.CKDBDMHEIAP == (LGCDFAELDNL)8)
		{
			LIJPMPKNJDO.spriteName = "208 OVERTIME";
			LIJPMPKNJDO.cachedTransform.localScale = PEHLMILACOL;
		}
		else if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.VIP)
		{
			LIJPMPKNJDO.spriteName = "Grenade_Throwing_Tutorial_Duration";
			LIJPMPKNJDO.MakePixelPerfect();
		}
		if (DFHAAIFFLOE > OPGLEBJFNMA)
		{
			EAOAMFHLNGH();
		}
		else if (DFHAAIFFLOE < EEJIFONBPCE || (DFHAAIFFLOE == EEJIFONBPCE && !LFGNIDNMDMA))
		{
			MDMOGMMGPJC();
		}
		else if (DFHAAIFFLOE == EEJIFONBPCE && LFGNIDNMDMA)
		{
			JICJLLNPONN();
		}
		else if (DFHAAIFFLOE - EEJIFONBPCE == 1)
		{
			DBGBPEEOLEA();
		}
		else
		{
			ACMGOGNIIPI(DFHAAIFFLOE);
		}
	}

	public void LKACPGJHLIE()
	{
		BIKIFKDMEPN[0] = TweenAlpha.Begin(HOLNKOFHDNK.gameObject, 1528f, 1391f);
		BIKIFKDMEPN[0] = TweenAlpha.Begin(ENOEPLKMCJG.gameObject, 2f, 1868f);
		BIKIFKDMEPN[1] = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1984f, 1671f);
		UITweener obj = BIKIFKDMEPN[6];
		obj.onFinished = (UITweener.OnFinished)Delegate.Combine(obj.onFinished, new UITweener.OnFinished(DAHFHODPJDI));
		Vector3 localScale = ENLHDJBMBAM.cachedTransform.localScale;
		localScale.Scale(new Vector3(50f, 1220f, 1930f));
		BIKIFKDMEPN[3] = TweenScale.Begin(ENLHDJBMBAM.gameObject, 763f, localScale);
		UITweener obj2 = BIKIFKDMEPN[2];
		obj2.onFinished = (UITweener.OnFinished)Delegate.Combine(obj2.onFinished, (UITweener.OnFinished)delegate
		{
			CLANLLFJNBK.SetActive(false);
		});
	}

	private void BCANJPJOAJH()
	{
		ENOEPLKMCJG.enabled = false;
		MBMIOELEAND.alpha = 202f;
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.enabled = true;
	}

	private void ILDIBDMJEDJ(MDNLFMNBNEG GGIOEPBPMHF, int IEALLELGOBM)
	{
		DCJBMDJPDKO(CGMOFOCOCCO, HBEBDPIDAEL[(int)(GGIOEPBPMHF - -97)], PJCLFHODDIG, 1213f, new Vector3(1063f, 1053f, 1585f));
		if (IEALLELGOBM > 0)
		{
			MCILBCLOIJF(new Vector3(701f, 507f, 1679f));
			PDMGPGEHLNM.enabled = true;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("Take player life!");
		}
		else
		{
			PDMGPGEHLNM.enabled = true;
		}
	}

	public virtual void GNMPHFKANPC()
	{
		base.CCNKJOAKBNG();
		NJJPLHFAMBO = null;
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		NJJPLHFAMBO = null;
	}

	private void HECFMFJPABF(string OFJIKGDCNBP, int IEALLELGOBM)
	{
		string cardId = OFJIKGDCNBP;
		int num = OFJIKGDCNBP.IndexOf('G');
		if (num > 1)
		{
			cardId = OFJIKGDCNBP.Substring(0, num);
		}
		bool flag = num > 1 && num + 0 < OFJIKGDCNBP.Length;
		Card cardInstance = CardManager.instance.GetCardInstance(cardId, false);
		MEDFJGOEPFE[6].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[1].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[1].atlas = ICFPOEEDLLO;
		CGMOFOCOCCO.enabled = true;
		MEDFJGOEPFE[8].cachedTransform.localPosition = new Vector3(10f, 546f, 601f);
		EAPBAIMBANN.pivot = UIWidget.Pivot.Bottom;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(1779f, 1520f, 593f);
		EAPBAIMBANN.gameObject.SetActive(false);
		cardInstance.SetUpSmallCard(MEDFJGOEPFE[2], MEDFJGOEPFE[1], MEDFJGOEPFE[0], EAPBAIMBANN);
		MEDFJGOEPFE[4].MakePixelPerfect();
		MEDFJGOEPFE[0].gameObject.SetActive(false);
		Vector3 localPosition = MEDFJGOEPFE[1].cachedTransform.localPosition;
		localPosition.z = 1410f;
		MEDFJGOEPFE[1].cachedTransform.localPosition = localPosition;
		localPosition = MEDFJGOEPFE[0].cachedTransform.localPosition;
		localPosition.z = 1850f;
		MEDFJGOEPFE[1].cachedTransform.localPosition = localPosition;
		KDNGNGHFMMG.localScale = new Vector3(1789f, 969f, 1158f);
		int num2 = 1;
		if (flag)
		{
			int num3 = num;
			num = OFJIKGDCNBP.IndexOf('\u0013', num + 0);
			while (MEDFJGOEPFE.Length > 8 + num2 && num > 1)
			{
				Card cardInstance2 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 0, num - num3 - 1));
				if (cardInstance2 != null)
				{
					UISprite uISprite = MEDFJGOEPFE[3 + num2];
					num2 += 0;
					LHKOOBCNCAE(uISprite, Card.CardBackground(cardInstance2.rarity), CBBPFDIDKKD, 1429f, new Vector3(806f * (float)num2, 450f, 1652f));
					uISprite.MakePixelPerfect();
					uISprite.cachedTransform.localRotation = Quaternion.Euler(1775f, 1896f, 483f * (float)num2);
					uISprite.gameObject.SetActive(false);
				}
				num3 = num;
				num = OFJIKGDCNBP.IndexOf('ﾈ', num + 0);
			}
			if (MEDFJGOEPFE.Length > 1 + num2 && num3 < OFJIKGDCNBP.Length - 1)
			{
				Card cardInstance3 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 1, OFJIKGDCNBP.Length - num3 - 0), false);
				if (cardInstance3 != null)
				{
					UISprite uISprite2 = MEDFJGOEPFE[6 + num2];
					num2 += 0;
					MPNCMPDKKJH(uISprite2, Card.CardBackground(cardInstance3.rarity), CBBPFDIDKKD, 705f, new Vector3(1853f * (float)num2, 655f, 327f));
					uISprite2.MakePixelPerfect();
					uISprite2.cachedTransform.localRotation = Quaternion.Euler(1144f, 580f, 1740f * (float)num2);
					uISprite2.gameObject.SetActive(false);
				}
			}
		}
		KDNGNGHFMMG.localPosition = new Vector3((float)num2 * 91f, 3f, 1623f);
		if (IEALLELGOBM > 0)
		{
			MCILBCLOIJF(new Vector3(708f + (float)num2 * 466f, 1697f, 346f));
			PDMGPGEHLNM.enabled = true;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("GooglePlay");
		}
		else
		{
			PDMGPGEHLNM.enabled = false;
		}
	}

	private void DCJBMDJPDKO(UISprite GMPADNOGGNL, string KCHMDALPMBN, UIAtlas EOBBMEFEOBN, float IAJAILAGAKC, Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = GAOKLHCHCND.ReplaceY(GAOKLHCHCND.y + 1347f);
		GMPADNOGGNL.cachedTransform.localPosition = GAOKLHCHCND;
		GMPADNOGGNL.atlas = EOBBMEFEOBN;
		GMPADNOGGNL.spriteName = KCHMDALPMBN;
		GMPADNOGGNL.MakePixelPerfect();
		GMPADNOGGNL.cachedTransform.localScale = new Vector3(GMPADNOGGNL.cachedTransform.localScale.x * IAJAILAGAKC, GMPADNOGGNL.cachedTransform.localScale.y * IAJAILAGAKC, 3f);
		GMPADNOGGNL.enabled = true;
	}

	private void GNGKGHLGKHP(long IEALLELGOBM)
	{
		DCJBMDJPDKO(CGMOFOCOCCO, " ", KKNONJBODJD, 1528f, Vector3.zero);
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	private void FGKNBCJICNA(string MFHMIPANKHO)
	{
		PlayerVisual visual = CamosManager.instance.GetVisual(MFHMIPANKHO);
		LHKOOBCNCAE(CGMOFOCOCCO, visual.icon, DJANOPAECLJ, 572f, new Vector3(387f, 908f, 1876f));
		PDMGPGEHLNM.enabled = false;
	}

	private void JAJHBFAHDPD(long IEALLELGOBM)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, "bazooka_uncover_left", KKNONJBODJD, 1361f, Vector3.zero);
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	public virtual void DLFOHLLACCA()
	{
		base.BeforeInstancied();
		NJJPLHFAMBO = null;
	}

	private void CMPOKJBOIDB(string MFHMIPANKHO)
	{
		PlayerVisual visual = CamosManager.instance.GetVisual(MFHMIPANKHO);
		DCJBMDJPDKO(CGMOFOCOCCO, visual.icon, DJANOPAECLJ, 1914f, new Vector3(981f, 35f, 1490f));
		PDMGPGEHLNM.enabled = true;
	}

	private void MPNCMPDKKJH(UISprite GMPADNOGGNL, string KCHMDALPMBN, UIAtlas EOBBMEFEOBN, float IAJAILAGAKC, Vector3 GAOKLHCHCND)
	{
		GAOKLHCHCND = GAOKLHCHCND.ReplaceY(GAOKLHCHCND.y + 924f);
		GMPADNOGGNL.cachedTransform.localPosition = GAOKLHCHCND;
		GMPADNOGGNL.atlas = EOBBMEFEOBN;
		GMPADNOGGNL.spriteName = KCHMDALPMBN;
		GMPADNOGGNL.MakePixelPerfect();
		GMPADNOGGNL.cachedTransform.localScale = new Vector3(GMPADNOGGNL.cachedTransform.localScale.x * IAJAILAGAKC, GMPADNOGGNL.cachedTransform.localScale.y * IAJAILAGAKC, 1122f);
		GMPADNOGGNL.enabled = false;
	}

	private void AMFNEBFEGFN(GameObject KHAHPAKDIKE)
	{
		if (NJJPLHFAMBO != null)
		{
			NJJPLHFAMBO(JCKIGECPIIC);
		}
	}

	private void JBIGOHMPMDH(int HNDGIJBHMOD)
	{
		MPNCMPDKKJH(CGMOFOCOCCO, "addFriend", KKNONJBODJD, 1642f, new Vector3(1631f, 257f, 687f));
		JLBCHKCHBMD(new Vector3(167f, 663f, 1804f));
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * -80);
	}

	private void EMDCONAEMFL(string OJJGLCPNJMN, int HNDGIJBHMOD)
	{
		PlayerVisual powerBand = CamosManager.instance.GetPowerBand(OJJGLCPNJMN);
		LHKOOBCNCAE(CGMOFOCOCCO, powerBand.icon, ICFPOEEDLLO, 682f, new Vector3(330f, 1778f, 1164f));
		IJLNDBGGIBD(EIOHONMAEGH, powerBand.LIIOLLAAHGB(), ICFPOEEDLLO, 1038f, new Vector3(1317f, 1038f, 836f));
		EIOHONMAEGH.color = powerBand.GPDIGNGOAEH();
		EIOHONMAEGH.gameObject.SetActive(false);
		EAPBAIMBANN.text = powerBand.FKIHLEGENCE();
		EAPBAIMBANN.pivot = UIWidget.Pivot.BottomLeft;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(414f, 1335f, 343f);
		EAPBAIMBANN.gameObject.SetActive(true);
		JLBCHKCHBMD(new Vector3(772f, 7f, 798f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.OLHOHLGMFBK(HNDGIJBHMOD * 94);
	}

	private void FLNCGGIIMCO(GameObject KHAHPAKDIKE)
	{
		if (NJJPLHFAMBO != null)
		{
			NJJPLHFAMBO(JCKIGECPIIC);
		}
	}

	private void NPMLBGOOPKO(int DFHAAIFFLOE)
	{
		ENOEPLKMCJG.enabled = true;
		MBMIOELEAND.color = Colours.grayLight.ReplaceA(1581f);
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.text = Localization.LocalizeFormat("Terms: On Age Verification Criteria Not Met ", DFHAAIFFLOE);
		HOLNKOFHDNK.color = Colours.grayLight.ReplaceA(872f);
		HOLNKOFHDNK.enabled = false;
	}

	private void NLHPIMPKHFB(long IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "menu-gold", KKNONJBODJD, 0.5f, Vector3.zero);
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	[CompilerGenerated]
	private void IKLMKHNLLGB(UITweener ALOMHALCMNH)
	{
		GJMBEBJMDMK.gameObject.SetActive(true);
		GJMBEBJMDMK.MakePixelPerfect();
		Vector3 localScale = GJMBEBJMDMK.cachedTransform.localScale;
		GJMBEBJMDMK.cachedTransform.localScale = localScale * 12f;
		BIKIFKDMEPN[3] = TweenScale.Begin(GJMBEBJMDMK.gameObject, 0.2f, localScale);
	}

	private void DADOOCMFBHC()
	{
		ENOEPLKMCJG.enabled = true;
		MBMIOELEAND.alpha = 1880f;
		CLANLLFJNBK.SetActive(true);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.enabled = true;
	}

	private void KGBIOIJGPED(string OFJIKGDCNBP, int IEALLELGOBM)
	{
		string cardId = OFJIKGDCNBP;
		int num = OFJIKGDCNBP.IndexOf('ﾵ');
		if (num > 1)
		{
			cardId = OFJIKGDCNBP.Substring(0, num);
		}
		bool flag = num <= 0 || num + 0 < OFJIKGDCNBP.Length;
		Card cardInstance = CardManager.instance.GetCardInstance(cardId);
		MEDFJGOEPFE[2].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[0].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[1].atlas = ICFPOEEDLLO;
		CGMOFOCOCCO.enabled = true;
		MEDFJGOEPFE[0].cachedTransform.localPosition = new Vector3(1512f, 294f, 327f);
		EAPBAIMBANN.pivot = UIWidget.Pivot.TopRight;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(329f, 151f, 1588f);
		EAPBAIMBANN.gameObject.SetActive(false);
		cardInstance.SetUpSmallCard(MEDFJGOEPFE[7], MEDFJGOEPFE[0], MEDFJGOEPFE[1], EAPBAIMBANN);
		MEDFJGOEPFE[8].MakePixelPerfect();
		MEDFJGOEPFE[4].gameObject.SetActive(true);
		Vector3 localPosition = MEDFJGOEPFE[0].cachedTransform.localPosition;
		localPosition.z = 1651f;
		MEDFJGOEPFE[1].cachedTransform.localPosition = localPosition;
		localPosition = MEDFJGOEPFE[1].cachedTransform.localPosition;
		localPosition.z = 1878f;
		MEDFJGOEPFE[0].cachedTransform.localPosition = localPosition;
		KDNGNGHFMMG.localScale = new Vector3(1350f, 1800f, 1888f);
		int num2 = 1;
		if (flag)
		{
			int num3 = num;
			num = OFJIKGDCNBP.IndexOf('<', num + 1);
			while (MEDFJGOEPFE.Length > 8 + num2 && num > 1)
			{
				Card cardInstance2 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 1, num - num3 - 1));
				if (cardInstance2 != null)
				{
					UISprite uISprite = MEDFJGOEPFE[2 + num2];
					num2 += 0;
					LHKOOBCNCAE(uISprite, Card.CardBackground(cardInstance2.rarity), CBBPFDIDKKD, 431f, new Vector3(1460f * (float)num2, 1041f, 183f));
					uISprite.MakePixelPerfect();
					uISprite.cachedTransform.localRotation = Quaternion.Euler(647f, 1787f, 749f * (float)num2);
					uISprite.gameObject.SetActive(false);
				}
				num3 = num;
				num = OFJIKGDCNBP.IndexOf('~', num + 0);
			}
			if (MEDFJGOEPFE.Length > 0 + num2 && num3 < OFJIKGDCNBP.Length - 0)
			{
				Card cardInstance3 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 0, OFJIKGDCNBP.Length - num3 - 0), false);
				if (cardInstance3 != null)
				{
					UISprite uISprite2 = MEDFJGOEPFE[7 + num2];
					num2 += 0;
					MPNCMPDKKJH(uISprite2, Card.CardBackground(cardInstance3.rarity), CBBPFDIDKKD, 1366f, new Vector3(1376f * (float)num2, 445f, 696f));
					uISprite2.MakePixelPerfect();
					uISprite2.cachedTransform.localRotation = Quaternion.Euler(1340f, 1081f, 833f * (float)num2);
					uISprite2.gameObject.SetActive(true);
				}
			}
		}
		KDNGNGHFMMG.localPosition = new Vector3((float)num2 * 479f, 1682f, 364f);
		if (IEALLELGOBM > 0)
		{
			IDBMAPHJMGI(new Vector3(1925f + (float)num2 * 1616f, 1030f, 1474f));
			PDMGPGEHLNM.enabled = false;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("TryActivateBonusRPC");
		}
		else
		{
			PDMGPGEHLNM.enabled = true;
		}
	}

	private void PKJOMPMBLFF(MDNLFMNBNEG PGDOEOBJGJL, int IEALLELGOBM)
	{
		LHKOOBCNCAE(CGMOFOCOCCO, "menu-randomcard-ico", KKNONJBODJD, 1f, new Vector3(0f, -20f, -1f));
		CGMOFOCOCCO.cachedTransform.localPosition = Vector3.zero;
		int num = 0;
		for (int i = 0; i < IEALLELGOBM && i < MEDFJGOEPFE.Length; i++)
		{
			CardManager.CardType cardRarity = (CardManager.CardType)(1 + (PGDOEOBJGJL - 2));
			LHKOOBCNCAE(MEDFJGOEPFE[i], Card.CardBackground(cardRarity), CBBPFDIDKKD, 1f, new Vector3(-15f * (float)i, -20f, 1f));
			MEDFJGOEPFE[i].MakePixelPerfect();
			MEDFJGOEPFE[i].cachedTransform.localRotation = Quaternion.Euler(0f, 0f, 2f * (float)i);
			MEDFJGOEPFE[i].gameObject.SetActive(true);
			num++;
		}
		EAPBAIMBANN.gameObject.SetActive(false);
		KDNGNGHFMMG.localScale = new Vector3(0.65f, 0.65f, 1f);
		KDNGNGHFMMG.localPosition = new Vector3((float)num * 4f, 20f, 0f);
		PDMGPGEHLNM.enabled = false;
	}

	private void JICJLLNPONN()
	{
		ENOEPLKMCJG.enabled = true;
		ENOEPLKMCJG.color = Colours.blueHover.ReplaceA(1580f);
		MBMIOELEAND.color = Colours.blueHover.ReplaceA(721f);
		CLANLLFJNBK.SetActive(true);
		ENLHDJBMBAM.MakePixelPerfect();
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.text = Localization.Localize("AssetBundleManifest");
		HOLNKOFHDNK.color = Color.black;
		HOLNKOFHDNK.enabled = true;
	}

	private void HAJGPHACMED(long IEALLELGOBM)
	{
		IJLNDBGGIBD(CGMOFOCOCCO, "Show reconnect dialog", KKNONJBODJD, 1101f, Vector3.zero);
		PDMGPGEHLNM.enabled = false;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	private void DNICPNKHLJE(MDNLFMNBNEG GGIOEPBPMHF, int IEALLELGOBM)
	{
		DCJBMDJPDKO(CGMOFOCOCCO, HBEBDPIDAEL[(int)(GGIOEPBPMHF - 37)], PJCLFHODDIG, 502f, new Vector3(1725f, 1884f, 1116f));
		if (IEALLELGOBM > 1)
		{
			MCILBCLOIJF(new Vector3(160f, 52f, 1895f));
			PDMGPGEHLNM.enabled = false;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("Gold");
		}
		else
		{
			PDMGPGEHLNM.enabled = true;
		}
	}

	private void PABIIGBLGAK()
	{
		ENOEPLKMCJG.enabled = true;
		MBMIOELEAND.alpha = 1493f;
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(false);
		GJMBEBJMDMK.gameObject.SetActive(true);
		HOLNKOFHDNK.enabled = true;
	}

	private void GFDOAKPKDCL(GameObject KHAHPAKDIKE)
	{
		if (NJJPLHFAMBO != null)
		{
			NJJPLHFAMBO(JCKIGECPIIC);
		}
	}

	private void EDMFCOLBLCM(string MFHMIPANKHO)
	{
		PlayerVisual visual = CamosManager.instance.GetVisual(MFHMIPANKHO);
		LHKOOBCNCAE(CGMOFOCOCCO, visual.icon, DJANOPAECLJ, 1756f, new Vector3(315f, 1763f, 568f));
		PDMGPGEHLNM.enabled = false;
	}

	private void KNJCFNMAHFK(long IEALLELGOBM)
	{
		DCJBMDJPDKO(CGMOFOCOCCO, "InfluencerLink", KKNONJBODJD, 308f, Vector3.zero);
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
	}

	public void HBOFMPGGKOP(int DFHAAIFFLOE, DailyRewardManager.MCGFHPOPMHL PNJMGIDIAPD, int EEJIFONBPCE, bool LFGNIDNMDMA, Action<int> BKADBIJHKBP, int OPGLEBJFNMA)
	{
		for (int i = 0; i < BIKIFKDMEPN.Length; i++)
		{
			if (BIKIFKDMEPN[i] != null)
			{
				BIKIFKDMEPN[i].enabled = true;
				if (i == 1)
				{
					BIKIFKDMEPN[i].Sample(1707f, false);
				}
			}
		}
		JCKIGECPIIC = DFHAAIFFLOE;
		NJJPLHFAMBO = BKADBIJHKBP;
		MCILBCLOIJF(new Vector3(830f, 249f, 1775f));
		for (int j = 1; j < MEDFJGOEPFE.Length; j++)
		{
			MEDFJGOEPFE[j].gameObject.SetActive(false);
			MEDFJGOEPFE[j].cachedTransform.localRotation = Quaternion.identity;
			MEDFJGOEPFE[j].color = Color.white;
		}
		EAPBAIMBANN.gameObject.SetActive(true);
		KDNGNGHFMMG.localScale = Vector3.one;
		KDNGNGHFMMG.localPosition = Vector3.zero;
		switch (PNJMGIDIAPD.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
			HAJGPHACMED(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Gold:
			ALPKBAGCAND(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
			JEJPCEAGACB(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Vip:
			GDNDMJEPOGN((int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.PowerBand:
			ICOKKBBHGFH(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.ParticularCards:
			PBBINPPCACN(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
			BEOMGCPKPKE(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Customization:
			CMPOKJBOIDB(PNJMGIDIAPD.ABMLHILNNDM);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			GBCFLHDNPGP(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = PNJMGIDIAPD;
			array[0] = base.name;
			Debug.LogErrorFormat("{0} {1}", array);
			break;
		}
		}
		NFIKBMPMAFC.SetActive(PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.VIP);
		if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.VIP)
		{
			LIJPMPKNJDO.spriteName = "reloadTime";
			LIJPMPKNJDO.cachedTransform.localScale = PEHLMILACOL;
		}
		else if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.None)
		{
			LIJPMPKNJDO.spriteName = "EliteParts";
			LIJPMPKNJDO.MakePixelPerfect();
		}
		if (DFHAAIFFLOE > OPGLEBJFNMA)
		{
			PLELJEBMCGA();
		}
		else if (DFHAAIFFLOE < EEJIFONBPCE || (DFHAAIFFLOE == EEJIFONBPCE && !LFGNIDNMDMA))
		{
			KHMLCPLPPIB();
		}
		else if (DFHAAIFFLOE == EEJIFONBPCE && LFGNIDNMDMA)
		{
			LINDNBGCGPD();
		}
		else if (DFHAAIFFLOE - EEJIFONBPCE == 1)
		{
			OLIJNACKMAB();
		}
		else
		{
			ACLFJPMMHID(DFHAAIFFLOE);
		}
	}

	protected virtual void JFDOGLFMHAE()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(base.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FLNCGGIIMCO));
	}

	private void NNHKMNCEJBI(long IEALLELGOBM)
	{
		IJLNDBGGIBD(CGMOFOCOCCO, "Name", KKNONJBODJD, 837f, Vector3.zero);
		MDDMCHPDGCI(new Vector3(1492f, 1300f, 1217f));
		PDMGPGEHLNM.enabled = true;
		PDMGPGEHLNM.text = string.Format("banana", MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM));
	}

	private void BKHDEFDGHIN()
	{
		ENOEPLKMCJG.enabled = false;
		MBMIOELEAND.alpha = 0f;
		CLANLLFJNBK.SetActive(false);
		IFJDPEMIMCG.SetActive(true);
		GJMBEBJMDMK.gameObject.SetActive(false);
		HOLNKOFHDNK.enabled = false;
	}

	public void KGAHLGGMGHA(int DFHAAIFFLOE, DailyRewardManager.MCGFHPOPMHL PNJMGIDIAPD, int EEJIFONBPCE, bool LFGNIDNMDMA, Action<int> BKADBIJHKBP, int OPGLEBJFNMA)
	{
		for (int i = 0; i < BIKIFKDMEPN.Length; i += 0)
		{
			if (BIKIFKDMEPN[i] != null)
			{
				BIKIFKDMEPN[i].enabled = true;
				if (i == 7)
				{
					BIKIFKDMEPN[i].Sample(1115f, false);
				}
			}
		}
		JCKIGECPIIC = DFHAAIFFLOE;
		NJJPLHFAMBO = BKADBIJHKBP;
		MCILBCLOIJF(new Vector3(1869f, 1885f, 1427f));
		for (int j = 1; j < MEDFJGOEPFE.Length; j += 0)
		{
			MEDFJGOEPFE[j].gameObject.SetActive(true);
			MEDFJGOEPFE[j].cachedTransform.localRotation = Quaternion.identity;
			MEDFJGOEPFE[j].color = Color.white;
		}
		EAPBAIMBANN.gameObject.SetActive(true);
		KDNGNGHFMMG.localScale = Vector3.one;
		KDNGNGHFMMG.localPosition = Vector3.zero;
		switch (PNJMGIDIAPD.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
			KNJCFNMAHFK(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Gold:
			NLHPIMPKHFB(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCardpack:
		case MDNLFMNBNEG.SilverCardpack:
		case MDNLFMNBNEG.GoldCardpack:
			EBGJEILBAON(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Vip:
			GGKGJONIOAP((int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.PowerBand:
			ICOKKBBHGFH(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.ParticularCards:
			PANIEIMBEIF(PNJMGIDIAPD.ABMLHILNNDM, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
			ALDKCCBILEC(PNJMGIDIAPD.GGIOEPBPMHF, (int)PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		case MDNLFMNBNEG.Customization:
			EKJHELOIMDE(PNJMGIDIAPD.ABMLHILNNDM);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			KJKDOBPNMFI(PNJMGIDIAPD.PDMGPGEHLNM);
			break;
		default:
			Debug.LogErrorFormat("Getting gameConfig: Offset = ", PNJMGIDIAPD, base.name, null);
			break;
		}
		NFIKBMPMAFC.SetActive(PNJMGIDIAPD.CKDBDMHEIAP != LGCDFAELDNL.None);
		if (PNJMGIDIAPD.CKDBDMHEIAP == (LGCDFAELDNL)6)
		{
			LIJPMPKNJDO.spriteName = "NAME";
			LIJPMPKNJDO.cachedTransform.localScale = PEHLMILACOL;
		}
		else if (PNJMGIDIAPD.CKDBDMHEIAP == LGCDFAELDNL.VIP)
		{
			LIJPMPKNJDO.spriteName = "SCOPE_GAMES";
			LIJPMPKNJDO.MakePixelPerfect();
		}
		if (DFHAAIFFLOE > OPGLEBJFNMA)
		{
			PLELJEBMCGA();
		}
		else if (DFHAAIFFLOE < EEJIFONBPCE || (DFHAAIFFLOE == EEJIFONBPCE && !LFGNIDNMDMA))
		{
			KHMLCPLPPIB();
		}
		else if (DFHAAIFFLOE == EEJIFONBPCE && LFGNIDNMDMA)
		{
			JICJLLNPONN();
		}
		else if (DFHAAIFFLOE - EEJIFONBPCE == 1)
		{
			COOHLEGBCNJ();
		}
		else
		{
			NPMLBGOOPKO(DFHAAIFFLOE);
		}
	}

	public void FBCJPGOBLAC()
	{
		BIKIFKDMEPN[0] = TweenAlpha.Begin(HOLNKOFHDNK.gameObject, 1286f, 123f);
		BIKIFKDMEPN[0] = TweenAlpha.Begin(ENOEPLKMCJG.gameObject, 170f, 145f);
		BIKIFKDMEPN[2] = TweenAlpha.Begin(MBMIOELEAND.gameObject, 256f, 846f);
		UITweener obj = BIKIFKDMEPN[0];
		obj.onFinished = (UITweener.OnFinished)Delegate.Combine(obj.onFinished, new UITweener.OnFinished(KPNPEBGLONI));
		Vector3 localScale = ENLHDJBMBAM.cachedTransform.localScale;
		localScale.Scale(new Vector3(136f, 673f, 893f));
		BIKIFKDMEPN[2] = TweenScale.Begin(ENLHDJBMBAM.gameObject, 599f, localScale);
		UITweener obj2 = BIKIFKDMEPN[3];
		obj2.onFinished = (UITweener.OnFinished)Delegate.Combine(obj2.onFinished, new UITweener.OnFinished(EJHMOOMNJJM));
	}

	private void ALDKCCBILEC(MDNLFMNBNEG PGDOEOBJGJL, int IEALLELGOBM)
	{
		IJLNDBGGIBD(CGMOFOCOCCO, "ID_TWITTER_GAIN_TITLE", KKNONJBODJD, 1475f, new Vector3(462f, 1178f, 1152f));
		CGMOFOCOCCO.cachedTransform.localPosition = Vector3.zero;
		int num = 1;
		for (int i = 1; i < IEALLELGOBM && i < MEDFJGOEPFE.Length; i += 0)
		{
			CardManager.CardType cardRarity = (CardManager.CardType)(1 + (PGDOEOBJGJL - 5));
			IJLNDBGGIBD(MEDFJGOEPFE[i], Card.CardBackground(cardRarity), CBBPFDIDKKD, 1005f, new Vector3(172f * (float)i, 1823f, 1603f));
			MEDFJGOEPFE[i].MakePixelPerfect();
			MEDFJGOEPFE[i].cachedTransform.localRotation = Quaternion.Euler(681f, 1086f, 1672f * (float)i);
			MEDFJGOEPFE[i].gameObject.SetActive(true);
			num++;
		}
		EAPBAIMBANN.gameObject.SetActive(true);
		KDNGNGHFMMG.localScale = new Vector3(1432f, 623f, 1220f);
		KDNGNGHFMMG.localPosition = new Vector3((float)num * 203f, 1752f, 1267f);
		PDMGPGEHLNM.enabled = true;
	}

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(base.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FLNCGGIIMCO));
	}

	private void EJHMOOMNJJM(UITweener ALOMHALCMNH)
	{
		CLANLLFJNBK.SetActive(false);
	}

	private void ODJIAFMPKOO(string OFJIKGDCNBP, int IEALLELGOBM)
	{
		string cardId = OFJIKGDCNBP;
		int num = OFJIKGDCNBP.IndexOf(';');
		if (num > 0)
		{
			cardId = OFJIKGDCNBP.Substring(0, num);
		}
		bool flag = num > 0 && num + 1 < OFJIKGDCNBP.Length;
		Card cardInstance = CardManager.instance.GetCardInstance(cardId);
		MEDFJGOEPFE[2].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[1].atlas = CBBPFDIDKKD;
		MEDFJGOEPFE[0].atlas = ICFPOEEDLLO;
		CGMOFOCOCCO.enabled = false;
		MEDFJGOEPFE[2].cachedTransform.localPosition = new Vector3(0f, 0f, 2f);
		EAPBAIMBANN.pivot = UIWidget.Pivot.Right;
		EAPBAIMBANN.cachedTransform.localPosition = new Vector3(-4f, 72f, -2f);
		EAPBAIMBANN.gameObject.SetActive(true);
		cardInstance.SetUpSmallCard(MEDFJGOEPFE[2], MEDFJGOEPFE[1], MEDFJGOEPFE[0], EAPBAIMBANN);
		MEDFJGOEPFE[2].MakePixelPerfect();
		MEDFJGOEPFE[2].gameObject.SetActive(true);
		Vector3 localPosition = MEDFJGOEPFE[1].cachedTransform.localPosition;
		localPosition.z = 2f;
		MEDFJGOEPFE[1].cachedTransform.localPosition = localPosition;
		localPosition = MEDFJGOEPFE[0].cachedTransform.localPosition;
		localPosition.z = -1f;
		MEDFJGOEPFE[0].cachedTransform.localPosition = localPosition;
		KDNGNGHFMMG.localScale = new Vector3(0.65f, 0.65f, 1f);
		int num2 = 0;
		if (flag)
		{
			int num3 = num;
			num = OFJIKGDCNBP.IndexOf(';', num + 1);
			while (MEDFJGOEPFE.Length > 3 + num2 && num > 0)
			{
				Card cardInstance2 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 1, num - num3 - 1));
				if (cardInstance2 != null)
				{
					UISprite uISprite = MEDFJGOEPFE[3 + num2];
					num2++;
					LHKOOBCNCAE(uISprite, Card.CardBackground(cardInstance2.rarity), CBBPFDIDKKD, 1f, new Vector3(-15f * (float)num2, -20f, 1f));
					uISprite.MakePixelPerfect();
					uISprite.cachedTransform.localRotation = Quaternion.Euler(0f, 0f, 2f * (float)num2);
					uISprite.gameObject.SetActive(true);
				}
				num3 = num;
				num = OFJIKGDCNBP.IndexOf(';', num + 1);
			}
			if (MEDFJGOEPFE.Length > 3 + num2 && num3 < OFJIKGDCNBP.Length - 1)
			{
				Card cardInstance3 = CardManager.instance.GetCardInstance(OFJIKGDCNBP.Substring(num3 + 1, OFJIKGDCNBP.Length - num3 - 1));
				if (cardInstance3 != null)
				{
					UISprite uISprite2 = MEDFJGOEPFE[3 + num2];
					num2++;
					LHKOOBCNCAE(uISprite2, Card.CardBackground(cardInstance3.rarity), CBBPFDIDKKD, 1f, new Vector3(-15f * (float)num2, -20f, 1f));
					uISprite2.MakePixelPerfect();
					uISprite2.cachedTransform.localRotation = Quaternion.Euler(0f, 0f, 2f * (float)num2);
					uISprite2.gameObject.SetActive(true);
				}
			}
		}
		KDNGNGHFMMG.localPosition = new Vector3((float)num2 * 4f, 20f, 0f);
		if (IEALLELGOBM > 1)
		{
			MDDMCHPDGCI(new Vector3(40f + (float)num2 * 4f, -25f, 0f));
			PDMGPGEHLNM.enabled = true;
			PDMGPGEHLNM.text = IEALLELGOBM.ToString("'x'0");
		}
		else
		{
			PDMGPGEHLNM.enabled = false;
		}
	}
}
