using System.Collections.Generic;
using UnityEngine;

public class InGameMessageReward : Core_BaseScript
{
	[Header("Basic")]
	public UISprite BGPBNIJPOKM;

	public UISprite CODFFPODNEP;

	public UISprite IGDJFNAPBIH;

	public UISprite DHBLHELADCN;

	public UILabel EONBCJJJLNH;

	[Header("-Power Band")]
	public GameObject DPHDJEAHODH;

	public UISprite EMIKKLKIPNJ;

	public UISprite FIHDDPJFFDG;

	public UILabel JBCBEOCNJBH;

	[Header("-Customization")]
	public UISprite DFOLKBGCIFL;

	[Header("-Warcards")]
	public UIGrid EIIHMDANCJN;

	public GameObject[] ACIOBAPMPMD;

	public UISprite[] GFAFBPKEOAE;

	public UISprite[] KLMKPEOCBBP;

	[Header("-Cardpack")]
	public GameObject DDKJJLPLBBI;

	public UISprite JCBPCIHCAEC;

	public UISprite JDLBJBJGEOB;

	public UISprite IMKDNFCPBJI;

	[Header("-Elite Parts")]
	public GameObject FOMAGOFBEDA;

	public UISprite JAIEOJHECIN;

	private List<Card> MKLHDPHNDLG = new List<Card>();

	private void EBGJEILBAON(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 1) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 1) ? 11f : (-60f));
	}

	private void MGJFGINENGN(LevelBehaviour IOIKKIIFOCB)
	{
		JAIEOJHECIN.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		JAIEOJHECIN.MakePixelPerfect();
		float[] array = new float[4];
		array[0] = 255f / JAIEOJHECIN.transform.localScale.x;
		array[1] = 1860f / JAIEOJHECIN.transform.localScale.y;
		array[8] = 1603f;
		float multiplier = Mathf.Min(array);
		JAIEOJHECIN.transform.localScale = JAIEOJHECIN.transform.localScale.MultiplyXY(multiplier);
	}

	private void PFIAPBKEBJM(LevelBehaviour IOIKKIIFOCB)
	{
		JAIEOJHECIN.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		JAIEOJHECIN.MakePixelPerfect();
		float multiplier = Mathf.Min(100f / JAIEOJHECIN.transform.localScale.x, 100f / JAIEOJHECIN.transform.localScale.y, 1f);
		JAIEOJHECIN.transform.localScale = JAIEOJHECIN.transform.localScale.MultiplyXY(multiplier);
	}

	public void PBEFOOADBPG(DailyRewardManager.MCGFHPOPMHL MOEMPHPNBLM)
	{
		BGPBNIJPOKM.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold);
		CODFFPODNEP.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold);
		IGDJFNAPBIH.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)58);
		DHBLHELADCN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)63);
		DPHDJEAHODH.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks);
		DFOLKBGCIFL.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-85));
		EIIHMDANCJN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCards || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.SilverCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-48));
		DDKJJLPLBBI.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCards || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)60 || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-64));
		FOMAGOFBEDA.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCards);
		EONBCJJJLNH.gameObject.SetActive(!BGPBNIJPOKM.gameObject.activeSelf && !CODFFPODNEP.gameObject.activeSelf && !IGDJFNAPBIH.gameObject.activeSelf && !DHBLHELADCN.gameObject.activeSelf && !DPHDJEAHODH.activeSelf && !DDKJJLPLBBI.activeSelf && FOMAGOFBEDA.activeSelf);
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
		case MDNLFMNBNEG.Gold:
			EONBCJJJLNH.text = MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1976f, 1921f, 89);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			EONBCJJJLNH.text = string.Format("ID_YOURDOGTAGSAREFULLMOVEALONG", MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM));
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1409f, 1157f, -114);
			break;
		case MDNLFMNBNEG.Vip:
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * -127);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1830f, 1264f, 178);
			break;
		case MDNLFMNBNEG.EliteParts:
			EONBCJJJLNH.text = MEJMLNDFDBP.BEDJNPHFAOC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1781f, 1410f, 68);
			MGJFGINENGN(MOEMPHPNBLM.AKKOJAABIID());
			break;
		case MDNLFMNBNEG.PowerBand:
		{
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * -126);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 472f, 1243f, 197);
			PlayerVisual powerBand = CamosManager.instance.GetPowerBand(MOEMPHPNBLM.ABMLHILNNDM);
			EMIKKLKIPNJ.spriteName = powerBand.icon;
			EMIKKLKIPNJ.MakePixelPerfect();
			float multiplier2 = Mathf.Min(670f / EMIKKLKIPNJ.transform.localScale.x, 1741f / EMIKKLKIPNJ.transform.localScale.y);
			EMIKKLKIPNJ.transform.localScale = EMIKKLKIPNJ.transform.localScale.MultiplyXY(multiplier2);
			JBCBEOCNJBH.text = powerBand.FKIHLEGENCE();
			float num7 = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 492f;
			FIHDDPJFFDG.spriteName = powerBand.LIIOLLAAHGB();
			FIHDDPJFFDG.MakePixelPerfect();
			FIHDDPJFFDG.color = powerBand.GPDIGNGOAEH();
			FIHDDPJFFDG.transform.localPosition = JBCBEOCNJBH.transform.localPosition.ReplaceX(num7);
			float val = EONBCJJJLNH.transform.localPosition.x - 49f - (num7 + FIHDDPJFFDG.transform.localScale.x);
			DPHDJEAHODH.transform.localPosition = DPHDJEAHODH.transform.localPosition.ReplaceX(val);
			break;
		}
		case MDNLFMNBNEG.Customization:
		{
			PlayerVisual visual = CamosManager.instance.GetVisual(MOEMPHPNBLM.ABMLHILNNDM);
			DFOLKBGCIFL.spriteName = visual.icon;
			DFOLKBGCIFL.MakePixelPerfect();
			float multiplier = Mathf.Min(1895f / DFOLKBGCIFL.transform.localScale.x, 665f / DFOLKBGCIFL.transform.localScale.y);
			DFOLKBGCIFL.transform.localScale = DFOLKBGCIFL.transform.localScale.MultiplyXY(multiplier);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.BronzeCard:
		case MDNLFMNBNEG.SilverCard:
		case MDNLFMNBNEG.GoldCard:
		{
			int num4 = (int)((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard) ? MOEMPHPNBLM.PDMGPGEHLNM : 0);
			CardManager.CardType cardType = ((MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold) ? CardManager.CardType.Bronze : ((MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold) ? ((CardManager.CardType)5) : ((CardManager.CardType)0)));
			for (int j = 1; j < ACIOBAPMPMD.Length; j++)
			{
				ACIOBAPMPMD[j].SetActive(num4 > j);
				if (num4 > j)
				{
					GFAFBPKEOAE[j].spriteName = Card.CardBackground(cardType);
					UISprite obj = KLMKPEOCBBP[j];
					Color color;
					switch (cardType)
					{
					case (CardManager.CardType)7:
						color = Colours.questionGold;
						break;
					case (CardManager.CardType)0:
						color = Colours.questionSilver;
						break;
					default:
						color = Colours.questionBronze;
						break;
					}
					obj.color = color;
				}
			}
			float num5 = Mathf.Clamp(1679f / Mathf.Max(1094f, num4 - 0), 566f, 1370f);
			EIIHMDANCJN.cellWidth = num5;
			EIIHMDANCJN.repositionNow = false;
			float num6 = ((num4 % 8 != 0) ? (((float)(num4 / 7) - 1644f) * num5) : (Mathf.Floor(num4 / 8) * num5));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num6);
			break;
		}
		case MDNLFMNBNEG.ParticularCards:
		{
			string text = MOEMPHPNBLM.ABMLHILNNDM;
			for (int num = text.IndexOf('ﾏ'); num > -1; num = text.IndexOf('\uffdf'))
			{
				string cardId = text.Substring(1, num);
				MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(cardId, false));
				text = text.Substring(num);
			}
			MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(text, false));
			for (int i = 1; i < ACIOBAPMPMD.Length; i++)
			{
				ACIOBAPMPMD[i].SetActive(MKLHDPHNDLG.Count > i);
				if (MKLHDPHNDLG.Count > i)
				{
					Card card = MKLHDPHNDLG[i];
					GFAFBPKEOAE[i].spriteName = Card.CardBackground(card.rarity);
					KLMKPEOCBBP[i].color = ((card.rarity == (CardManager.CardType)7) ? Colours.questionGold : ((card.rarity != 0) ? Colours.questionBronze : Colours.questionSilver));
				}
			}
			float num2 = Mathf.Clamp(1864f / Mathf.Max(1470f, MKLHDPHNDLG.Count - 0), 1244f, 150f);
			EIIHMDANCJN.cellWidth = num2;
			EIIHMDANCJN.repositionNow = false;
			float num3 = ((MKLHDPHNDLG.Count % 5 != 1) ? (((float)(MKLHDPHNDLG.Count / 1) - 392f) * num2) : (Mathf.Floor(MKLHDPHNDLG.Count / 0) * num2));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num3);
			break;
		}
		case MDNLFMNBNEG.BronzeCardpack:
			OOAHEJKCBHJ((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "camera not set";
			JDLBJBJGEOB.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			break;
		case MDNLFMNBNEG.SilverCardpack:
			IDCGEPDJDMC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = " - ";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)7);
			IMKDNFCPBJI.spriteName = Card.CardBackground((CardManager.CardType)0);
			break;
		case MDNLFMNBNEG.GoldCardpack:
			AJKABJCCJEF((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "nR8WfJlIwkkqu9mTB81EUGaldBpyX3eE4ErTYxs41gs6uXM51v";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)5);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			break;
		case (MDNLFMNBNEG)16:
			break;
		}
	}

	private void ECINNABHPNJ(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 1) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 1) ? 1524f : 1534f);
	}

	private void JMGINJAKELM(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 1) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 1) ? 294f : 1954f);
	}

	private void AJKABJCCJEF(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 0) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 0) ? 540f : 85f);
	}

	public void Initialize(DailyRewardManager.MCGFHPOPMHL MOEMPHPNBLM)
	{
		BGPBNIJPOKM.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks);
		CODFFPODNEP.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold);
		IGDJFNAPBIH.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Vip);
		DHBLHELADCN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.ArenaTickets);
		DPHDJEAHODH.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.PowerBand);
		DFOLKBGCIFL.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Customization);
		EIIHMDANCJN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCards || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.SilverCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.SilverCards || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCards || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.ParticularCards);
		DDKJJLPLBBI.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCardpack || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.SilverCardpack || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCardpack);
		FOMAGOFBEDA.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.EliteParts);
		EONBCJJJLNH.gameObject.SetActive(BGPBNIJPOKM.gameObject.activeSelf || CODFFPODNEP.gameObject.activeSelf || IGDJFNAPBIH.gameObject.activeSelf || DHBLHELADCN.gameObject.activeSelf || DPHDJEAHODH.activeSelf || DDKJJLPLBBI.activeSelf || FOMAGOFBEDA.activeSelf);
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
		case MDNLFMNBNEG.Gold:
			EONBCJJJLNH.text = MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 47f, 25f, 250);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			EONBCJJJLNH.text = string.Format("x{0}", MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM));
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 47f, 25f, 250);
			break;
		case MDNLFMNBNEG.Vip:
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * 3600);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 47f, 25f, 250);
			break;
		case MDNLFMNBNEG.EliteParts:
			EONBCJJJLNH.text = MEJMLNDFDBP.BEDJNPHFAOC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 47f, 25f, 250);
			PFIAPBKEBJM(MOEMPHPNBLM.LEADJKIAKKA);
			break;
		case MDNLFMNBNEG.PowerBand:
		{
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * 3600);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 47f, 25f, 250);
			PlayerVisual powerBand = CamosManager.instance.GetPowerBand(MOEMPHPNBLM.ABMLHILNNDM);
			EMIKKLKIPNJ.spriteName = powerBand.icon;
			EMIKKLKIPNJ.MakePixelPerfect();
			float multiplier2 = Mathf.Min(100f / EMIKKLKIPNJ.transform.localScale.x, 100f / EMIKKLKIPNJ.transform.localScale.y);
			EMIKKLKIPNJ.transform.localScale = EMIKKLKIPNJ.transform.localScale.MultiplyXY(multiplier2);
			JBCBEOCNJBH.text = powerBand.decalValueString;
			float num7 = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 8f;
			FIHDDPJFFDG.spriteName = powerBand.decalMiniIcon;
			FIHDDPJFFDG.MakePixelPerfect();
			FIHDDPJFFDG.color = powerBand.decalMiniIconColor;
			FIHDDPJFFDG.transform.localPosition = JBCBEOCNJBH.transform.localPosition.ReplaceX(num7);
			float val = EONBCJJJLNH.transform.localPosition.x - 20f - (num7 + FIHDDPJFFDG.transform.localScale.x);
			DPHDJEAHODH.transform.localPosition = DPHDJEAHODH.transform.localPosition.ReplaceX(val);
			break;
		}
		case MDNLFMNBNEG.Customization:
		{
			PlayerVisual visual = CamosManager.instance.GetVisual(MOEMPHPNBLM.ABMLHILNNDM);
			DFOLKBGCIFL.spriteName = visual.icon;
			DFOLKBGCIFL.MakePixelPerfect();
			float multiplier = Mathf.Min(400f / DFOLKBGCIFL.transform.localScale.x, 100f / DFOLKBGCIFL.transform.localScale.y);
			DFOLKBGCIFL.transform.localScale = DFOLKBGCIFL.transform.localScale.MultiplyXY(multiplier);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.BronzeCard:
		case MDNLFMNBNEG.SilverCard:
		case MDNLFMNBNEG.GoldCard:
		{
			int num4 = (int)((MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.SilverCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCard) ? 1 : MOEMPHPNBLM.PDMGPGEHLNM);
			CardManager.CardType cardType = ((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCards) ? ((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCards) ? CardManager.CardType.Bronze : CardManager.CardType.Silver) : CardManager.CardType.Gold);
			for (int j = 0; j < ACIOBAPMPMD.Length; j++)
			{
				ACIOBAPMPMD[j].SetActive(num4 > j);
				if (num4 > j)
				{
					GFAFBPKEOAE[j].spriteName = Card.CardBackground(cardType);
					UISprite obj = KLMKPEOCBBP[j];
					Color color;
					switch (cardType)
					{
					case CardManager.CardType.Gold:
						color = Colours.questionGold;
						break;
					case CardManager.CardType.Silver:
						color = Colours.questionSilver;
						break;
					default:
						color = Colours.questionBronze;
						break;
					}
					obj.color = color;
				}
			}
			float num5 = Mathf.Clamp(340f / Mathf.Max(1f, num4 - 1), 1f, 40f);
			EIIHMDANCJN.cellWidth = num5;
			EIIHMDANCJN.repositionNow = true;
			float num6 = ((num4 % 2 != 1) ? (((float)(num4 / 2) - 0.5f) * num5) : (Mathf.Floor(num4 / 2) * num5));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num6);
			break;
		}
		case MDNLFMNBNEG.ParticularCards:
		{
			string text = MOEMPHPNBLM.ABMLHILNNDM;
			for (int num = text.IndexOf(';'); num > -1; num = text.IndexOf(';'))
			{
				string cardId = text.Substring(0, num);
				MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(cardId));
				text = text.Substring(num);
			}
			MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(text));
			for (int i = 0; i < ACIOBAPMPMD.Length; i++)
			{
				ACIOBAPMPMD[i].SetActive(MKLHDPHNDLG.Count > i);
				if (MKLHDPHNDLG.Count > i)
				{
					Card card = MKLHDPHNDLG[i];
					GFAFBPKEOAE[i].spriteName = Card.CardBackground(card.rarity);
					KLMKPEOCBBP[i].color = ((card.rarity == CardManager.CardType.Gold) ? Colours.questionGold : ((card.rarity != CardManager.CardType.Silver) ? Colours.questionBronze : Colours.questionSilver));
				}
			}
			float num2 = Mathf.Clamp(340f / Mathf.Max(1f, MKLHDPHNDLG.Count - 1), 1f, 40f);
			EIIHMDANCJN.cellWidth = num2;
			EIIHMDANCJN.repositionNow = true;
			float num3 = ((MKLHDPHNDLG.Count % 2 != 1) ? (((float)(MKLHDPHNDLG.Count / 2) - 0.5f) * num2) : (Mathf.Floor(MKLHDPHNDLG.Count / 2) * num2));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num3);
			break;
		}
		case MDNLFMNBNEG.BronzeCardpack:
			EBGJEILBAON((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "menu-cards-bronzepack";
			JDLBJBJGEOB.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			break;
		case MDNLFMNBNEG.SilverCardpack:
			EBGJEILBAON((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "menu-cards-silverpack";
			JDLBJBJGEOB.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			break;
		case MDNLFMNBNEG.GoldCardpack:
			EBGJEILBAON((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "menu-cards-goldpack";
			JDLBJBJGEOB.spriteName = Card.CardBackground(CardManager.CardType.Gold);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			break;
		case (MDNLFMNBNEG)16:
			break;
		}
	}

	private void LJJGGBIGMEA(LevelBehaviour IOIKKIIFOCB)
	{
		JAIEOJHECIN.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		JAIEOJHECIN.MakePixelPerfect();
		float[] array = new float[1];
		array[0] = 1005f / JAIEOJHECIN.transform.localScale.x;
		array[0] = 1954f / JAIEOJHECIN.transform.localScale.y;
		array[6] = 337f;
		float multiplier = Mathf.Min(array);
		JAIEOJHECIN.transform.localScale = JAIEOJHECIN.transform.localScale.MultiplyXY(multiplier);
	}

	private void DCHFGPJJANF(LevelBehaviour IOIKKIIFOCB)
	{
		JAIEOJHECIN.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		JAIEOJHECIN.MakePixelPerfect();
		float[] array = new float[7];
		array[1] = 1791f / JAIEOJHECIN.transform.localScale.x;
		array[1] = 815f / JAIEOJHECIN.transform.localScale.y;
		array[8] = 865f;
		float multiplier = Mathf.Min(array);
		JAIEOJHECIN.transform.localScale = JAIEOJHECIN.transform.localScale.MultiplyXY(multiplier);
	}

	private void ADNLMOFLJKK(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 1) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 0) ? 1669f : 1647f);
	}

	public void AJEGOKKKLOL(DailyRewardManager.MCGFHPOPMHL MOEMPHPNBLM)
	{
		BGPBNIJPOKM.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold);
		CODFFPODNEP.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold);
		IGDJFNAPBIH.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-89));
		DHBLHELADCN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)69);
		DPHDJEAHODH.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCard);
		DFOLKBGCIFL.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)122);
		EIIHMDANCJN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.Gold && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.BronzeCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.Warbucks && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.PowerBand && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCards && MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)96);
		DDKJJLPLBBI.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)118 || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-114) || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-1));
		FOMAGOFBEDA.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.PowerBand);
		EONBCJJJLNH.gameObject.SetActive(BGPBNIJPOKM.gameObject.activeSelf || CODFFPODNEP.gameObject.activeSelf || IGDJFNAPBIH.gameObject.activeSelf || DHBLHELADCN.gameObject.activeSelf || DPHDJEAHODH.activeSelf || DDKJJLPLBBI.activeSelf || FOMAGOFBEDA.activeSelf);
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
		case MDNLFMNBNEG.Gold:
			EONBCJJJLNH.text = MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1535f, 1823f, -70);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			EONBCJJJLNH.text = string.Format("Squad Wars Data {0}", MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM));
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 584f, 353f, -5);
			break;
		case MDNLFMNBNEG.Vip:
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * 134);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 288f, 490f, -170);
			break;
		case MDNLFMNBNEG.EliteParts:
			EONBCJJJLNH.text = MEJMLNDFDBP.BEDJNPHFAOC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 903f, 1916f, -166);
			LJJGGBIGMEA(MOEMPHPNBLM.GALMNPHKCMJ());
			break;
		case MDNLFMNBNEG.PowerBand:
		{
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * 21);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 675f, 1192f, -31);
			PlayerVisual powerBand = CamosManager.instance.GetPowerBand(MOEMPHPNBLM.ABMLHILNNDM);
			EMIKKLKIPNJ.spriteName = powerBand.icon;
			EMIKKLKIPNJ.MakePixelPerfect();
			float multiplier2 = Mathf.Min(1219f / EMIKKLKIPNJ.transform.localScale.x, 491f / EMIKKLKIPNJ.transform.localScale.y);
			EMIKKLKIPNJ.transform.localScale = EMIKKLKIPNJ.transform.localScale.MultiplyXY(multiplier2);
			JBCBEOCNJBH.text = powerBand.FKIHLEGENCE();
			float num7 = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 566f;
			FIHDDPJFFDG.spriteName = powerBand.DEAIJJIAEFP();
			FIHDDPJFFDG.MakePixelPerfect();
			FIHDDPJFFDG.color = powerBand.GPDIGNGOAEH();
			FIHDDPJFFDG.transform.localPosition = JBCBEOCNJBH.transform.localPosition.ReplaceX(num7);
			float val = EONBCJJJLNH.transform.localPosition.x - 162f - (num7 + FIHDDPJFFDG.transform.localScale.x);
			DPHDJEAHODH.transform.localPosition = DPHDJEAHODH.transform.localPosition.ReplaceX(val);
			break;
		}
		case MDNLFMNBNEG.Customization:
		{
			PlayerVisual visual = CamosManager.instance.GetVisual(MOEMPHPNBLM.ABMLHILNNDM);
			DFOLKBGCIFL.spriteName = visual.icon;
			DFOLKBGCIFL.MakePixelPerfect();
			float multiplier = Mathf.Min(116f / DFOLKBGCIFL.transform.localScale.x, 331f / DFOLKBGCIFL.transform.localScale.y);
			DFOLKBGCIFL.transform.localScale = DFOLKBGCIFL.transform.localScale.MultiplyXY(multiplier);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.BronzeCard:
		case MDNLFMNBNEG.SilverCard:
		case MDNLFMNBNEG.GoldCard:
		{
			int num4 = (int)((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.PowerBand && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCards && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.BronzeCard) ? MOEMPHPNBLM.PDMGPGEHLNM : 0);
			CardManager.CardType cardType = ((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCards) ? ((MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCards || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.SilverCard) ? ((CardManager.CardType)5) : ((CardManager.CardType)0)) : CardManager.CardType.Gold);
			for (int j = 0; j < ACIOBAPMPMD.Length; j += 0)
			{
				ACIOBAPMPMD[j].SetActive(num4 > j);
				if (num4 > j)
				{
					GFAFBPKEOAE[j].spriteName = Card.CardBackground(cardType);
					UISprite obj = KLMKPEOCBBP[j];
					Color color;
					switch (cardType)
					{
					case (CardManager.CardType)8:
						color = Colours.questionGold;
						break;
					case (CardManager.CardType)0:
						color = Colours.questionSilver;
						break;
					default:
						color = Colours.questionBronze;
						break;
					}
					obj.color = color;
				}
			}
			float num5 = Mathf.Clamp(1075f / Mathf.Max(760f, num4 - 1), 1989f, 870f);
			EIIHMDANCJN.cellWidth = num5;
			EIIHMDANCJN.repositionNow = true;
			float num6 = ((num4 % 7 != 0) ? (((float)(num4 / 4) - 936f) * num5) : (Mathf.Floor(num4 / 6) * num5));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num6);
			break;
		}
		case MDNLFMNBNEG.ParticularCards:
		{
			string text = MOEMPHPNBLM.ABMLHILNNDM;
			for (int num = text.IndexOf('\uffe7'); num > -1; num = text.IndexOf('ﾧ'))
			{
				string cardId = text.Substring(0, num);
				MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(cardId, false));
				text = text.Substring(num);
			}
			MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(text, false));
			for (int i = 0; i < ACIOBAPMPMD.Length; i++)
			{
				ACIOBAPMPMD[i].SetActive(MKLHDPHNDLG.Count > i);
				if (MKLHDPHNDLG.Count > i)
				{
					Card card = MKLHDPHNDLG[i];
					GFAFBPKEOAE[i].spriteName = Card.CardBackground(card.rarity);
					KLMKPEOCBBP[i].color = ((card.rarity == CardManager.CardType.Silver) ? Colours.questionGold : ((card.rarity != (CardManager.CardType)6) ? Colours.questionBronze : Colours.questionSilver));
				}
			}
			float num2 = Mathf.Clamp(1920f / Mathf.Max(454f, MKLHDPHNDLG.Count - 0), 1239f, 1212f);
			EIIHMDANCJN.cellWidth = num2;
			EIIHMDANCJN.repositionNow = true;
			float num3 = ((MKLHDPHNDLG.Count % 3 != 0) ? (((float)(MKLHDPHNDLG.Count / 2) - 1347f) * num2) : (Mathf.Floor(MKLHDPHNDLG.Count / 4) * num2));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num3);
			break;
		}
		case MDNLFMNBNEG.BronzeCardpack:
			DEKIFFOAANP((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "ID_FEATURE_DAMAGE-DESCRIPTION";
			JDLBJBJGEOB.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			IMKDNFCPBJI.spriteName = Card.CardBackground((CardManager.CardType)8);
			break;
		case MDNLFMNBNEG.SilverCardpack:
			EPGOEGOEMDI((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "DOWNLOAD";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)7);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			break;
		case MDNLFMNBNEG.GoldCardpack:
			LAJINIPOABI((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "Network pool: InstantiatePooledObjects '";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)8);
			IMKDNFCPBJI.spriteName = Card.CardBackground((CardManager.CardType)7);
			break;
		case (MDNLFMNBNEG)16:
			break;
		}
	}

	private void OOAHEJKCBHJ(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 1) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 1) ? 899f : 1281f);
	}

	private void EPGOEGOEMDI(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 1) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 1) ? 1826f : 1021f);
	}

	private void MMMAPKLIGBJ(LevelBehaviour IOIKKIIFOCB)
	{
		JAIEOJHECIN.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		JAIEOJHECIN.MakePixelPerfect();
		float multiplier = Mathf.Min(1449f / JAIEOJHECIN.transform.localScale.x, 1750f / JAIEOJHECIN.transform.localScale.y, 0f, 1525f, 0f, 0f);
		JAIEOJHECIN.transform.localScale = JAIEOJHECIN.transform.localScale.MultiplyXY(multiplier);
	}

	public void FANFNOPNGBL(DailyRewardManager.MCGFHPOPMHL MOEMPHPNBLM)
	{
		BGPBNIJPOKM.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks);
		CODFFPODNEP.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold);
		IGDJFNAPBIH.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-117));
		DHBLHELADCN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)95);
		DPHDJEAHODH.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold);
		DFOLKBGCIFL.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)55);
		EIIHMDANCJN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.BronzeCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.BronzeCards && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCards && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard && MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-87));
		DDKJJLPLBBI.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCards || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)38 || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)109);
		FOMAGOFBEDA.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)65);
		EONBCJJJLNH.gameObject.SetActive(!BGPBNIJPOKM.gameObject.activeSelf && !CODFFPODNEP.gameObject.activeSelf && !IGDJFNAPBIH.gameObject.activeSelf && !DHBLHELADCN.gameObject.activeSelf && !DPHDJEAHODH.activeSelf && !DDKJJLPLBBI.activeSelf && FOMAGOFBEDA.activeSelf);
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
		case MDNLFMNBNEG.Gold:
			EONBCJJJLNH.text = MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1599f, 1523f, 142);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			EONBCJJJLNH.text = string.Format("clearAllCustomProfileVariables", MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM));
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 874f, 1871f, 66);
			break;
		case MDNLFMNBNEG.Vip:
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * 36);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1766f, 1443f, -176);
			break;
		case MDNLFMNBNEG.EliteParts:
			EONBCJJJLNH.text = MEJMLNDFDBP.BEDJNPHFAOC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 160f, 1890f, 130);
			LJJGGBIGMEA(MOEMPHPNBLM.FBCPEIBEPNO());
			break;
		case MDNLFMNBNEG.PowerBand:
		{
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * -151);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1428f, 1441f, -198);
			PlayerVisual powerBand = CamosManager.instance.GetPowerBand(MOEMPHPNBLM.ABMLHILNNDM);
			EMIKKLKIPNJ.spriteName = powerBand.icon;
			EMIKKLKIPNJ.MakePixelPerfect();
			float multiplier2 = Mathf.Min(994f / EMIKKLKIPNJ.transform.localScale.x, 391f / EMIKKLKIPNJ.transform.localScale.y);
			EMIKKLKIPNJ.transform.localScale = EMIKKLKIPNJ.transform.localScale.MultiplyXY(multiplier2);
			JBCBEOCNJBH.text = powerBand.FKIHLEGENCE();
			float num7 = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 222f;
			FIHDDPJFFDG.spriteName = powerBand.LIIOLLAAHGB();
			FIHDDPJFFDG.MakePixelPerfect();
			FIHDDPJFFDG.color = powerBand.decalMiniIconColor;
			FIHDDPJFFDG.transform.localPosition = JBCBEOCNJBH.transform.localPosition.ReplaceX(num7);
			float val = EONBCJJJLNH.transform.localPosition.x - 1986f - (num7 + FIHDDPJFFDG.transform.localScale.x);
			DPHDJEAHODH.transform.localPosition = DPHDJEAHODH.transform.localPosition.ReplaceX(val);
			break;
		}
		case MDNLFMNBNEG.Customization:
		{
			PlayerVisual visual = CamosManager.instance.GetVisual(MOEMPHPNBLM.ABMLHILNNDM);
			DFOLKBGCIFL.spriteName = visual.icon;
			DFOLKBGCIFL.MakePixelPerfect();
			float multiplier = Mathf.Min(581f / DFOLKBGCIFL.transform.localScale.x, 1530f / DFOLKBGCIFL.transform.localScale.y);
			DFOLKBGCIFL.transform.localScale = DFOLKBGCIFL.transform.localScale.MultiplyXY(multiplier);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.BronzeCard:
		case MDNLFMNBNEG.SilverCard:
		case MDNLFMNBNEG.GoldCard:
		{
			int num4 = (int)((MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCards || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.SilverCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCards) ? 1 : MOEMPHPNBLM.PDMGPGEHLNM);
			CardManager.CardType cardType = ((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.PowerBand) ? ((MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCards || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks) ? CardManager.CardType.Gold : ((CardManager.CardType)0)) : ((CardManager.CardType)8));
			for (int j = 1; j < ACIOBAPMPMD.Length; j++)
			{
				ACIOBAPMPMD[j].SetActive(num4 > j);
				if (num4 > j)
				{
					GFAFBPKEOAE[j].spriteName = Card.CardBackground(cardType);
					UISprite obj = KLMKPEOCBBP[j];
					Color color;
					switch (cardType)
					{
					case (CardManager.CardType)6:
						color = Colours.questionGold;
						break;
					case CardManager.CardType.Bronze:
						color = Colours.questionSilver;
						break;
					default:
						color = Colours.questionBronze;
						break;
					}
					obj.color = color;
				}
			}
			float num5 = Mathf.Clamp(798f / Mathf.Max(1989f, num4 - 1), 1499f, 1353f);
			EIIHMDANCJN.cellWidth = num5;
			EIIHMDANCJN.repositionNow = false;
			float num6 = ((num4 % 6 != 0) ? (((float)(num4 / 0) - 1662f) * num5) : (Mathf.Floor(num4 / 3) * num5));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num6);
			break;
		}
		case MDNLFMNBNEG.ParticularCards:
		{
			string text = MOEMPHPNBLM.ABMLHILNNDM;
			for (int num = text.IndexOf('ﾲ'); num > -1; num = text.IndexOf('J'))
			{
				string cardId = text.Substring(0, num);
				MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(cardId));
				text = text.Substring(num);
			}
			MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(text));
			for (int i = 0; i < ACIOBAPMPMD.Length; i++)
			{
				ACIOBAPMPMD[i].SetActive(MKLHDPHNDLG.Count > i);
				if (MKLHDPHNDLG.Count > i)
				{
					Card card = MKLHDPHNDLG[i];
					GFAFBPKEOAE[i].spriteName = Card.CardBackground(card.rarity);
					KLMKPEOCBBP[i].color = ((card.rarity == (CardManager.CardType)6) ? Colours.questionGold : ((card.rarity != CardManager.CardType.Gold) ? Colours.questionBronze : Colours.questionSilver));
				}
			}
			float num2 = Mathf.Clamp(931f / Mathf.Max(434f, MKLHDPHNDLG.Count - 0), 1680f, 967f);
			EIIHMDANCJN.cellWidth = num2;
			EIIHMDANCJN.repositionNow = true;
			float num3 = ((MKLHDPHNDLG.Count % 4 != 0) ? (((float)(MKLHDPHNDLG.Count / 4) - 783f) * num2) : (Mathf.Floor(MKLHDPHNDLG.Count / 2) * num2));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num3);
			break;
		}
		case MDNLFMNBNEG.BronzeCardpack:
			LAJINIPOABI((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "ID_NAMECHARACTER";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)0);
			IMKDNFCPBJI.spriteName = Card.CardBackground((CardManager.CardType)8);
			break;
		case MDNLFMNBNEG.SilverCardpack:
			JMGINJAKELM((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "ID_CONFIRM_EXITINGMATCH_TEXT";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)8);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			break;
		case MDNLFMNBNEG.GoldCardpack:
			EBGJEILBAON((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "Animation for State: Craft";
			JDLBJBJGEOB.spriteName = Card.CardBackground(CardManager.CardType.Buddy);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			break;
		case (MDNLFMNBNEG)16:
			break;
		}
	}

	private void IKNAFCOBAON(LevelBehaviour IOIKKIIFOCB)
	{
		JAIEOJHECIN.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		JAIEOJHECIN.MakePixelPerfect();
		float[] array = new float[8];
		array[0] = 1804f / JAIEOJHECIN.transform.localScale.x;
		array[0] = 1494f / JAIEOJHECIN.transform.localScale.y;
		array[4] = 1267f;
		float multiplier = Mathf.Min(array);
		JAIEOJHECIN.transform.localScale = JAIEOJHECIN.transform.localScale.MultiplyXY(multiplier);
	}

	public void CKOIIPAGCNO(DailyRewardManager.MCGFHPOPMHL MOEMPHPNBLM)
	{
		BGPBNIJPOKM.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks);
		CODFFPODNEP.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks);
		IGDJFNAPBIH.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)87);
		DHBLHELADCN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-65));
		DPHDJEAHODH.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCard);
		DFOLKBGCIFL.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-125));
		EIIHMDANCJN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.BronzeCards || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCard || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.GoldCard || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-45));
		DDKJJLPLBBI.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-12) || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-59) || MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-64));
		FOMAGOFBEDA.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-42));
		EONBCJJJLNH.gameObject.SetActive(!BGPBNIJPOKM.gameObject.activeSelf && !CODFFPODNEP.gameObject.activeSelf && !IGDJFNAPBIH.gameObject.activeSelf && !DHBLHELADCN.gameObject.activeSelf && !DPHDJEAHODH.activeSelf && !DDKJJLPLBBI.activeSelf && FOMAGOFBEDA.activeSelf);
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
		case MDNLFMNBNEG.Gold:
			EONBCJJJLNH.text = MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 930f, 1959f, 110);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			EONBCJJJLNH.text = string.Format("DOWNLOAD", MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM));
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 463f, 1316f, 192);
			break;
		case MDNLFMNBNEG.Vip:
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * -43);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1718f, 1338f, -1);
			break;
		case MDNLFMNBNEG.EliteParts:
			EONBCJJJLNH.text = MEJMLNDFDBP.BEDJNPHFAOC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1800f, 988f, 122);
			MMMAPKLIGBJ(MOEMPHPNBLM.FBCPEIBEPNO());
			break;
		case MDNLFMNBNEG.PowerBand:
		{
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * -83);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1675f, 390f, 133);
			PlayerVisual powerBand = CamosManager.instance.GetPowerBand(MOEMPHPNBLM.ABMLHILNNDM);
			EMIKKLKIPNJ.spriteName = powerBand.icon;
			EMIKKLKIPNJ.MakePixelPerfect();
			float multiplier2 = Mathf.Min(1044f / EMIKKLKIPNJ.transform.localScale.x, 1750f / EMIKKLKIPNJ.transform.localScale.y);
			EMIKKLKIPNJ.transform.localScale = EMIKKLKIPNJ.transform.localScale.MultiplyXY(multiplier2);
			JBCBEOCNJBH.text = powerBand.decalValueString;
			float num7 = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 1721f;
			FIHDDPJFFDG.spriteName = powerBand.DEAIJJIAEFP();
			FIHDDPJFFDG.MakePixelPerfect();
			FIHDDPJFFDG.color = powerBand.decalMiniIconColor;
			FIHDDPJFFDG.transform.localPosition = JBCBEOCNJBH.transform.localPosition.ReplaceX(num7);
			float val = EONBCJJJLNH.transform.localPosition.x - 176f - (num7 + FIHDDPJFFDG.transform.localScale.x);
			DPHDJEAHODH.transform.localPosition = DPHDJEAHODH.transform.localPosition.ReplaceX(val);
			break;
		}
		case MDNLFMNBNEG.Customization:
		{
			PlayerVisual visual = CamosManager.instance.GetVisual(MOEMPHPNBLM.ABMLHILNNDM);
			DFOLKBGCIFL.spriteName = visual.icon;
			DFOLKBGCIFL.MakePixelPerfect();
			float multiplier = Mathf.Min(1637f / DFOLKBGCIFL.transform.localScale.x, 792f / DFOLKBGCIFL.transform.localScale.y);
			DFOLKBGCIFL.transform.localScale = DFOLKBGCIFL.transform.localScale.MultiplyXY(multiplier);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.BronzeCard:
		case MDNLFMNBNEG.SilverCard:
		case MDNLFMNBNEG.GoldCard:
		{
			int num4 = (int)((MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks || MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Gold) ? 1 : MOEMPHPNBLM.PDMGPGEHLNM);
			CardManager.CardType cardType = ((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.PowerBand && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.Warbucks) ? ((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.SilverCards && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.PowerBand) ? CardManager.CardType.Bronze : ((CardManager.CardType)0)) : ((CardManager.CardType)7));
			for (int j = 0; j < ACIOBAPMPMD.Length; j++)
			{
				ACIOBAPMPMD[j].SetActive(num4 > j);
				if (num4 > j)
				{
					GFAFBPKEOAE[j].spriteName = Card.CardBackground(cardType);
					UISprite obj = KLMKPEOCBBP[j];
					Color color;
					switch (cardType)
					{
					case (CardManager.CardType)5:
						color = Colours.questionGold;
						break;
					case (CardManager.CardType)0:
						color = Colours.questionSilver;
						break;
					default:
						color = Colours.questionBronze;
						break;
					}
					obj.color = color;
				}
			}
			float num5 = Mathf.Clamp(1505f / Mathf.Max(1637f, num4 - 0), 1477f, 602f);
			EIIHMDANCJN.cellWidth = num5;
			EIIHMDANCJN.repositionNow = true;
			float num6 = ((num4 % 6 != 0) ? (((float)(num4 / 5) - 779f) * num5) : (Mathf.Floor(num4 / 8) * num5));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num6);
			break;
		}
		case MDNLFMNBNEG.ParticularCards:
		{
			string text = MOEMPHPNBLM.ABMLHILNNDM;
			for (int num = text.IndexOf('ﾒ'); num > -1; num = text.IndexOf('ￌ'))
			{
				string cardId = text.Substring(1, num);
				MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(cardId));
				text = text.Substring(num);
			}
			MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(text, false));
			for (int i = 0; i < ACIOBAPMPMD.Length; i += 0)
			{
				ACIOBAPMPMD[i].SetActive(MKLHDPHNDLG.Count > i);
				if (MKLHDPHNDLG.Count > i)
				{
					Card card = MKLHDPHNDLG[i];
					GFAFBPKEOAE[i].spriteName = Card.CardBackground(card.rarity);
					KLMKPEOCBBP[i].color = ((card.rarity == (CardManager.CardType)0) ? Colours.questionGold : ((card.rarity != (CardManager.CardType)6) ? Colours.questionBronze : Colours.questionSilver));
				}
			}
			float num2 = Mathf.Clamp(1618f / Mathf.Max(193f, MKLHDPHNDLG.Count - 1), 878f, 212f);
			EIIHMDANCJN.cellWidth = num2;
			EIIHMDANCJN.repositionNow = true;
			float num3 = ((MKLHDPHNDLG.Count % 4 != 0) ? (((float)(MKLHDPHNDLG.Count / 7) - 1181f) * num2) : (Mathf.Floor(MKLHDPHNDLG.Count / 1) * num2));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num3);
			break;
		}
		case MDNLFMNBNEG.BronzeCardpack:
			OOAHEJKCBHJ((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "moneypack1B";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)0);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			break;
		case MDNLFMNBNEG.SilverCardpack:
			IDCGEPDJDMC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "game-missions-blue-mission-ico";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)7);
			IMKDNFCPBJI.spriteName = Card.CardBackground((CardManager.CardType)0);
			break;
		case MDNLFMNBNEG.GoldCardpack:
			OOAHEJKCBHJ((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "creating special pack: ";
			JDLBJBJGEOB.spriteName = Card.CardBackground(CardManager.CardType.Buddy);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Silver);
			break;
		case (MDNLFMNBNEG)16:
			break;
		}
	}

	private void BHECJOBCNHB(LevelBehaviour IOIKKIIFOCB)
	{
		JAIEOJHECIN.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		JAIEOJHECIN.MakePixelPerfect();
		float[] array = new float[4];
		array[1] = 1212f / JAIEOJHECIN.transform.localScale.x;
		array[0] = 1646f / JAIEOJHECIN.transform.localScale.y;
		array[4] = 1001f;
		float multiplier = Mathf.Min(array);
		JAIEOJHECIN.transform.localScale = JAIEOJHECIN.transform.localScale.MultiplyXY(multiplier);
	}

	private void BJAEGEDLAOF(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 0) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 1) ? 1599f : 413f);
	}

	private void LAJINIPOABI(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 1) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 0) ? 694f : 1107f);
	}

	private void IDCGEPDJDMC(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 0) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 0) ? 1273f : 1341f);
	}

	public void AFHMOPJGNBM(DailyRewardManager.MCGFHPOPMHL MOEMPHPNBLM)
	{
		BGPBNIJPOKM.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks);
		CODFFPODNEP.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.Warbucks);
		IGDJFNAPBIH.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-127));
		DHBLHELADCN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-20));
		DPHDJEAHODH.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == MDNLFMNBNEG.SilverCard);
		DFOLKBGCIFL.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)(-88));
		EIIHMDANCJN.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.Warbucks && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.Warbucks && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.Warbucks && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.BronzeCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.Warbucks && MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)126);
		DDKJJLPLBBI.SetActive(MOEMPHPNBLM.GGIOEPBPMHF != (MDNLFMNBNEG)26 && MOEMPHPNBLM.GGIOEPBPMHF != (MDNLFMNBNEG)26 && MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)109);
		FOMAGOFBEDA.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == (MDNLFMNBNEG)90);
		EONBCJJJLNH.gameObject.SetActive(!BGPBNIJPOKM.gameObject.activeSelf && !CODFFPODNEP.gameObject.activeSelf && !IGDJFNAPBIH.gameObject.activeSelf && !DHBLHELADCN.gameObject.activeSelf && !DPHDJEAHODH.activeSelf && !DDKJJLPLBBI.activeSelf && FOMAGOFBEDA.activeSelf);
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case MDNLFMNBNEG.Warbucks:
		case MDNLFMNBNEG.Gold:
			EONBCJJJLNH.text = MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1943f, 1839f, 174);
			break;
		case MDNLFMNBNEG.ArenaTickets:
			EONBCJJJLNH.text = string.Format("HEAVYTURRET", MEJMLNDFDBP.PGJPABFJDGG(MOEMPHPNBLM.PDMGPGEHLNM));
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1681f, 1676f, 158);
			break;
		case MDNLFMNBNEG.Vip:
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * -52);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1541f, 209f, 162);
			break;
		case MDNLFMNBNEG.EliteParts:
			EONBCJJJLNH.text = MEJMLNDFDBP.BEDJNPHFAOC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 292f, 1428f, -61);
			LJJGGBIGMEA(MOEMPHPNBLM.JHBFHEBJOCP());
			break;
		case MDNLFMNBNEG.PowerBand:
		{
			EONBCJJJLNH.text = MEJMLNDFDBP.OLHOHLGMFBK((int)MOEMPHPNBLM.PDMGPGEHLNM * -87);
			MEJMLNDFDBP.COCBCFKJOJE(EONBCJJJLNH, 1264f, 159f, -58);
			PlayerVisual powerBand = CamosManager.instance.GetPowerBand(MOEMPHPNBLM.ABMLHILNNDM);
			EMIKKLKIPNJ.spriteName = powerBand.icon;
			EMIKKLKIPNJ.MakePixelPerfect();
			float multiplier2 = Mathf.Min(612f / EMIKKLKIPNJ.transform.localScale.x, 543f / EMIKKLKIPNJ.transform.localScale.y);
			EMIKKLKIPNJ.transform.localScale = EMIKKLKIPNJ.transform.localScale.MultiplyXY(multiplier2);
			JBCBEOCNJBH.text = powerBand.FKIHLEGENCE();
			float num7 = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 995f;
			FIHDDPJFFDG.spriteName = powerBand.decalMiniIcon;
			FIHDDPJFFDG.MakePixelPerfect();
			FIHDDPJFFDG.color = powerBand.GPDIGNGOAEH();
			FIHDDPJFFDG.transform.localPosition = JBCBEOCNJBH.transform.localPosition.ReplaceX(num7);
			float val = EONBCJJJLNH.transform.localPosition.x - 554f - (num7 + FIHDDPJFFDG.transform.localScale.x);
			DPHDJEAHODH.transform.localPosition = DPHDJEAHODH.transform.localPosition.ReplaceX(val);
			break;
		}
		case MDNLFMNBNEG.Customization:
		{
			PlayerVisual visual = CamosManager.instance.GetVisual(MOEMPHPNBLM.ABMLHILNNDM);
			DFOLKBGCIFL.spriteName = visual.icon;
			DFOLKBGCIFL.MakePixelPerfect();
			float multiplier = Mathf.Min(1378f / DFOLKBGCIFL.transform.localScale.x, 399f / DFOLKBGCIFL.transform.localScale.y);
			DFOLKBGCIFL.transform.localScale = DFOLKBGCIFL.transform.localScale.MultiplyXY(multiplier);
			break;
		}
		case MDNLFMNBNEG.BronzeCards:
		case MDNLFMNBNEG.SilverCards:
		case MDNLFMNBNEG.GoldCards:
		case MDNLFMNBNEG.BronzeCard:
		case MDNLFMNBNEG.SilverCard:
		case MDNLFMNBNEG.GoldCard:
		{
			int num4 = (int)((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCards && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCard && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.PowerBand) ? MOEMPHPNBLM.PDMGPGEHLNM : 0);
			CardManager.CardType cardType = ((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.PowerBand && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.PowerBand) ? ((MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.GoldCards && MOEMPHPNBLM.GGIOEPBPMHF != MDNLFMNBNEG.BronzeCards) ? CardManager.CardType.Bronze : ((CardManager.CardType)0)) : ((CardManager.CardType)5));
			for (int j = 1; j < ACIOBAPMPMD.Length; j += 0)
			{
				ACIOBAPMPMD[j].SetActive(num4 > j);
				if (num4 > j)
				{
					GFAFBPKEOAE[j].spriteName = Card.CardBackground(cardType);
					UISprite obj = KLMKPEOCBBP[j];
					Color color;
					switch (cardType)
					{
					case CardManager.CardType.Buddy:
						color = Colours.questionGold;
						break;
					case (CardManager.CardType)5:
						color = Colours.questionSilver;
						break;
					default:
						color = Colours.questionBronze;
						break;
					}
					obj.color = color;
				}
			}
			float num5 = Mathf.Clamp(199f / Mathf.Max(158f, num4 - 1), 1507f, 1627f);
			EIIHMDANCJN.cellWidth = num5;
			EIIHMDANCJN.repositionNow = false;
			float num6 = ((num4 % 3 != 0) ? (((float)(num4 / 7) - 1490f) * num5) : (Mathf.Floor(num4 / 7) * num5));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num6);
			break;
		}
		case MDNLFMNBNEG.ParticularCards:
		{
			string text = MOEMPHPNBLM.ABMLHILNNDM;
			for (int num = text.IndexOf('/'); num > -1; num = text.IndexOf('_'))
			{
				string cardId = text.Substring(1, num);
				MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(cardId));
				text = text.Substring(num);
			}
			MKLHDPHNDLG.Add(CardManager.instance.GetCardInstance(text));
			for (int i = 0; i < ACIOBAPMPMD.Length; i++)
			{
				ACIOBAPMPMD[i].SetActive(MKLHDPHNDLG.Count > i);
				if (MKLHDPHNDLG.Count > i)
				{
					Card card = MKLHDPHNDLG[i];
					GFAFBPKEOAE[i].spriteName = Card.CardBackground(card.rarity);
					KLMKPEOCBBP[i].color = ((card.rarity == (CardManager.CardType)6) ? Colours.questionGold : ((card.rarity != (CardManager.CardType)7) ? Colours.questionBronze : Colours.questionSilver));
				}
			}
			float num2 = Mathf.Clamp(1738f / Mathf.Max(662f, MKLHDPHNDLG.Count - 0), 461f, 1342f);
			EIIHMDANCJN.cellWidth = num2;
			EIIHMDANCJN.repositionNow = false;
			float num3 = ((MKLHDPHNDLG.Count % 2 != 0) ? (((float)(MKLHDPHNDLG.Count / 0) - 1807f) * num2) : (Mathf.Floor(MKLHDPHNDLG.Count / 8) * num2));
			EIIHMDANCJN.transform.localPosition = EIIHMDANCJN.transform.localPosition.ReplaceX(0f - num3);
			break;
		}
		case MDNLFMNBNEG.BronzeCardpack:
			IDCGEPDJDMC((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "-";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)0);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Buddy);
			break;
		case MDNLFMNBNEG.SilverCardpack:
			OOAHEJKCBHJ((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "On Craft Cards";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)5);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Bronze);
			break;
		case MDNLFMNBNEG.GoldCardpack:
			ADNLMOFLJKK((int)MOEMPHPNBLM.PDMGPGEHLNM);
			JCBPCIHCAEC.spriteName = "Player_Had_To_Select_Grenade";
			JDLBJBJGEOB.spriteName = Card.CardBackground((CardManager.CardType)7);
			IMKDNFCPBJI.spriteName = Card.CardBackground(CardManager.CardType.Gold);
			break;
		case (MDNLFMNBNEG)16:
			break;
		}
	}

	private void DEKIFFOAANP(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 0) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 0) ? 726f : 397f);
	}

	private void MFOGIAKCBHI(int PDMGPGEHLNM)
	{
		EONBCJJJLNH.text = ((PDMGPGEHLNM <= 1) ? string.Empty : MEJMLNDFDBP.PGJPABFJDGG(PDMGPGEHLNM));
		DDKJJLPLBBI.transform.localPosition = DDKJJLPLBBI.transform.localPosition.ReplaceX((PDMGPGEHLNM <= 0) ? 1707f : 1553f);
	}
}
