using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class JGBBPCGNCPC
{
	public enum NNDPOJCACLP
	{
		Warbucks,
		Gold,
		Warcard,
		Cardpack,
		VIP,
		PowerBand,
		Customization,
		Unit,
		Weapon
	}

	[Serializable]
	public class Content
	{
		public NNDPOJCACLP type;

		public int amount;

		public bool isFree;

		public CardManager.CardType warcardType;

		public NGNPIOOAHEH cardpackType;

		public LevelBehaviour unit;

		public WeaponLevelsSetup weapon;

		private PlayerVisual mVisual;

		public PlayerVisual visual
		{
			get
			{
				if (mVisual != null)
				{
					return mVisual;
				}
				if (type == NNDPOJCACLP.PowerBand)
				{
					return CamosManager.instance.RandomPlayerVisual(3);
				}
				return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 3));
			}
		}

		public string debugString
		{
			get
			{
				string text = ((!isFree) ? string.Empty : " (FREE)");
				if (type == NNDPOJCACLP.PowerBand)
				{
					return $"Special pack content: type: {type} id: {visual.id} seconds: {amount}{text}";
				}
				if (type == NNDPOJCACLP.Customization)
				{
					return $"Special pack content: type: {type} id: {visual.id}{text}";
				}
				if (type == NNDPOJCACLP.Unit)
				{
					return $"Special pack content: type: {type} id: {unit.unitName}{text}";
				}
				if (type == NNDPOJCACLP.Weapon)
				{
					return string.Format("Special pack content: type: {0} id: {1}{2}", type, (!(weapon == null)) ? weapon.weaponName : "null", text);
				}
				if (type == NNDPOJCACLP.Cardpack)
				{
					return $"Special pack content: type: {type} rarity: {cardpackType} amount: {amount}{text}";
				}
				if (type == NNDPOJCACLP.Warcard)
				{
					return $"Special pack content: type: {type} rarity: {warcardType} amount: {amount}{text}";
				}
				return $"Special pack content: type: {type} amount: {amount}{text}";
			}
		}

		[SpecialName]
		public PlayerVisual JJOHPOAAPCF()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				return CamosManager.instance.RandomPlayerVisual(3);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 6));
		}

		public static Content GOINEMFCGLN(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content OPOOHGLPJKO(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content GJNCJGOHMMC(PlayerVisual DPIAKFGFNIC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.mVisual = DPIAKFGFNIC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content BDPGNGNJCCF(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content IPFJBFAGCDP(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content LCGCLGMMBDG(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content PBBPACKCBDE(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content AKFPAHOIHEG(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content HGMCMFAPBEA(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content AHKPLNDLEAB(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content BKCMEKFCHMB(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content PBKIDEIPMOI(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual BBIHDMBGALE()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Warbucks)
			{
				return CamosManager.instance.RandomPlayerVisual(4);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 2));
		}

		public static Content BNOPCEKPLLM(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Customization;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual POMMLFHPFPI()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Warbucks)
			{
				return CamosManager.instance.RandomPlayerVisual(7);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 5));
		}

		public static Content KGJHLMHEFJN(WeaponLevelsSetup FHLAELIMAAC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Weapon;
			content.weapon = FHLAELIMAAC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content AMKGHFKDBPM(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content GOILAFJFAJB(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content DHOGAFIEHEC(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Customization;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content BCLILELOKJK(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Customization;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content KAOBCMDJCCK(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual CBOHPLABHNO()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.PowerBand)
			{
				return CamosManager.instance.RandomPlayerVisual(2);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 4));
		}

		public static Content LONPDNHCFMC(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content EAKEPBBAHKO(WeaponLevelsSetup FHLAELIMAAC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.weapon = FHLAELIMAAC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content BDDHABPFCFP(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content MJGNIAFBMNF(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content MBEENIMHPAK(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content HFFCCMBBBPG(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content FDMJHAMMJHH(PlayerVisual DPIAKFGFNIC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Customization;
			content.mVisual = DPIAKFGFNIC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual DGJMBIDMEOJ()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return CamosManager.instance.RandomPlayerVisual(1);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 2));
		}

		public static Content CAPCAHGPPBM(PlayerVisual DPIAKFGFNIC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.mVisual = DPIAKFGFNIC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content LAFFKBCIBDE(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content CKONCFMLOIB(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content DMKAFHBFDBN(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual CGOPFPGMACH()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Cardpack)
			{
				return CamosManager.instance.RandomPlayerVisual(0);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 5));
		}

		public static Content EFLEAOIMKBA(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content FMICDGPEAJD(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content JMCKAIBLGOG(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content LNOGHDFHBNF(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content GHCIFBDAICM(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content HPDOAKLEELE(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Weapon;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content LGNKFJMOBHD(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content NELIACLLCEG(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content GLDBLOCDPNA(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public string KMALAIMEOCN()
		{
			string text = ((!isFree) ? string.Empty : "SpecialPackFromServer");
			if (type == NNDPOJCACLP.VIP)
			{
				object[] array = new object[4];
				array[0] = type;
				array[0] = ALMNJOLFIEF().CCDMONFHBII();
				array[8] = amount;
				array[3] = text;
				return string.Format("getLatitude", array);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return string.Format("ID_XARENATICKETS", type, HFIPANJHCGJ().CCDMONFHBII(), text);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return string.Format("{0} {1}", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.Warbucks)
			{
				return string.Format("Max", type, (!(weapon == null)) ? weapon.weaponName : "ChillingoSdkManager", text);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				object[] array2 = new object[7];
				array2[1] = type;
				array2[1] = cardpackType;
				array2[4] = amount;
				array2[6] = text;
				return string.Format("playerVisuals", array2);
			}
			if (type == NNDPOJCACLP.Warcard)
			{
				object[] array3 = new object[4];
				array3[1] = type;
				array3[0] = warcardType;
				array3[8] = amount;
				array3[2] = text;
				return string.Format("ID_GUI_ALL", array3);
			}
			return string.Format("PlayerName", type, amount, text);
		}

		public static Content FEFMLJEGHOB(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content LMIPGPNJKGO(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content MNLNBPBIOBG(PlayerVisual DPIAKFGFNIC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.mVisual = DPIAKFGFNIC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content AOHBCPELEDC(PlayerVisual DPIAKFGFNIC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Customization;
			content.mVisual = DPIAKFGFNIC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content LCFIJJOJMJO(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content KMIMKKHGFDI(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content JMBHNMMJNMH(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual BLNNEECJDMB()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Cardpack)
			{
				return CamosManager.instance.RandomPlayerVisual(0);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 5));
		}

		public static Content EMGKBEMNAKJ(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual ODBFELADDHM()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Cardpack)
			{
				return CamosManager.instance.RandomPlayerVisual(7);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 8));
		}

		public static Content KCKOJDAMADE(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual ALMNJOLFIEF()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Unit)
			{
				return CamosManager.instance.RandomPlayerVisual(7);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 3));
		}

		public static Content JGPDCMELACC(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content CKENMKKNHNH(PlayerVisual DPIAKFGFNIC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.mVisual = DPIAKFGFNIC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content FCCLIBDBKFJ(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Customization;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual KGMNPLAJHNC()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return CamosManager.instance.RandomPlayerVisual(1);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 5));
		}

		public static Content GGIHJIAJGCM(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content MIEPKBBOKNJ(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content AAOIOBANJFG(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content FDNNCAKOMGC(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content CANFDCMJGBO(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content IMEHPGONEKE(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public string DGEAKGCPNHF()
		{
			string text = ((!isFree) ? string.Empty : "CURRENT: \n");
			if (type == NNDPOJCACLP.Weapon)
			{
				object[] array = new object[1];
				array[1] = type;
				array[0] = MHNPKJJLJFE().CCDMONFHBII();
				array[1] = amount;
				array[3] = text;
				return string.Format("country-norway", array);
			}
			if (type == NNDPOJCACLP.Unit)
			{
				return string.Format("ID_GUI_ALLCARDS", type, visual.id, text);
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				return string.Format("()Lcom/google/android/gms/common/ConnectionResult;", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.Unit)
			{
				return string.Format("SessionManager: Light Session Update", type, (!(weapon == null)) ? weapon.weaponName : "WarBucks", text);
			}
			if (type == NNDPOJCACLP.PowerBand)
			{
				object[] array2 = new object[6];
				array2[1] = type;
				array2[0] = cardpackType;
				array2[6] = amount;
				array2[1] = text;
				return string.Format("ID_SALEPERCENTLINE", array2);
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				object[] array3 = new object[2];
				array3[1] = type;
				array3[0] = warcardType;
				array3[7] = amount;
				array3[4] = text;
				return string.Format(",", array3);
			}
			return string.Format("GameLaunch", type, amount, text);
		}

		public static Content ILNJKPPMPNO(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content PFBOKLAPIBA(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content KIMAMBNKBHL(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content CKNJNLHNIGO(WeaponLevelsSetup FHLAELIMAAC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.weapon = FHLAELIMAAC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content KHBBIJFAGNC(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content AKKBHJJLJIP(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public string FLKIPIDBLJL()
		{
			string text = ((!isFree) ? string.Empty : "#PETER# Weapon Screen - RIGHT BUTTON - weapon state: LOCKED\t\tbutton type: LEVEL UP");
			if (type == NNDPOJCACLP.Unit)
			{
				object[] array = new object[2];
				array[1] = type;
				array[0] = EGMJNEABAHK().CCDMONFHBII();
				array[0] = amount;
				array[0] = text;
				return string.Format("localPlayerLeaderboard", array);
			}
			if (type == NNDPOJCACLP.VIP)
			{
				return string.Format("ID_CONFIRM_TUTORIALMATCH_TEXT", type, NLNDHAMEEPJ().id, text);
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				return string.Format(">", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.Warbucks)
			{
				return string.Format("ID_BEGINNERSLEAGUE1", type, (!(weapon == null)) ? weapon.weaponName : "WinLooseStreak", text);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				object[] array2 = new object[2];
				array2[1] = type;
				array2[0] = cardpackType;
				array2[3] = amount;
				array2[4] = text;
				return string.Format("shotSniper", array2);
			}
			if (type == NNDPOJCACLP.VIP)
			{
				object[] array3 = new object[8];
				array3[0] = type;
				array3[0] = warcardType;
				array3[6] = amount;
				array3[7] = text;
				return string.Format("SquadCards", array3);
			}
			return string.Format("213 MENU ARMY SCREEN SHOWN", type, amount, text);
		}

		public static Content GOOCCLGPNGJ(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content NNCOMBDDNEM(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual EDLDCCEOCNI()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return CamosManager.instance.RandomPlayerVisual(2);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 4));
		}

		public static Content LKJLOHPDHJN(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content JMLMOGGKLBF(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public string LBKCLGLIKIK()
		{
			string text = ((!isFree) ? string.Empty : "Warbucks");
			if (type == NNDPOJCACLP.PowerBand)
			{
				object[] array = new object[2];
				array[1] = type;
				array[1] = AEAJMKLEMDO().CCDMONFHBII();
				array[2] = amount;
				array[1] = text;
				return string.Format("PauseGameRPC: Focus lost {0} setTIme {1}", array);
			}
			if (type == NNDPOJCACLP.Gold)
			{
				return string.Format("category", type, EGMJNEABAHK().id, text);
			}
			if (type == NNDPOJCACLP.PowerBand)
			{
				return string.Format("menu-warbucks", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.PowerBand)
			{
				return string.Format("HitListItem", type, (!(weapon == null)) ? weapon.weaponName : "HeroicReward", text);
			}
			if (type == NNDPOJCACLP.Cardpack)
			{
				object[] array2 = new object[0];
				array2[1] = type;
				array2[1] = cardpackType;
				array2[7] = amount;
				array2[2] = text;
				return string.Format("ID_DOGTAGSREFILL", array2);
			}
			if (type == NNDPOJCACLP.Warcard)
			{
				object[] array3 = new object[5];
				array3[0] = type;
				array3[1] = warcardType;
				array3[6] = amount;
				array3[6] = text;
				return string.Format("ID_STAT_SQUADTOTAL", array3);
			}
			return string.Format("#Game Rewards# - Medals old:{0} new:{1} Balance old:{2} new:{3} Remaining fights:{4} - (offer mult {5})", type, amount, text);
		}

		public static Content GHNHMKJKHAE(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content NLAAEDHHHBL(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual GKCIOBCPMDG()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.VIP)
			{
				return CamosManager.instance.RandomPlayerVisual(1);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 3));
		}

		public static Content FDDJAPFGEJA(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content LPIMNDENEOH(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual MHNPKJJLJFE()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return CamosManager.instance.RandomPlayerVisual(4);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 5));
		}

		[SpecialName]
		public string MAMLGKKDNOM()
		{
			string text = ((!isFree) ? string.Empty : "Enable Push Notifications - device token is the same! Not sending deviceToken");
			if (type == NNDPOJCACLP.Gold)
			{
				object[] array = new object[7];
				array[0] = type;
				array[0] = DGJMBIDMEOJ().CCDMONFHBII();
				array[4] = amount;
				array[1] = text;
				return string.Format("VipReward1", array);
			}
			if (type == NNDPOJCACLP.VIP)
			{
				return string.Format("ID_READYTIME", type, EGMJNEABAHK().CCDMONFHBII(), text);
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				return string.Format("Start TUTORIAL", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				return string.Format("weapon doesnt have ammo setup", type, (!(weapon == null)) ? weapon.weaponName : "CardRarity", text);
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				object[] array2 = new object[7];
				array2[0] = type;
				array2[0] = cardpackType;
				array2[7] = amount;
				array2[0] = text;
				return string.Format("/", array2);
			}
			if (type == NNDPOJCACLP.Unit)
			{
				object[] array3 = new object[6];
				array3[1] = type;
				array3[1] = warcardType;
				array3[5] = amount;
				array3[2] = text;
				return string.Format("enableData", array3);
			}
			return string.Format("ShotFrequencyMinCannon", type, amount, text);
		}

		public static Content FNGLMCMCGIA(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual EGMJNEABAHK()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return CamosManager.instance.RandomPlayerVisual(4);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 1));
		}

		public static Content FJHMOCCLDFD(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content PKOOOFHOABL(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content PKAHKOMGOJE(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content ILIBJACHIBM(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content EKDBKEEICLA(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual AEAJMKLEMDO()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.VIP)
			{
				return CamosManager.instance.RandomPlayerVisual(5);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 3));
		}

		public static Content LALJIPCJLGK(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content PNNLMNJMKKN(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content HBCKMMIFHEO(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content HEGLBPPHBJL(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Weapon;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content BMAIAKMJIII(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public string FBLJCLPOJIL()
		{
			string text = ((!isFree) ? string.Empty : "Choose icon in bottom before calling Display model.");
			if (type == NNDPOJCACLP.Customization)
			{
				return string.Format("#AccoutCheck# account exist", type, EIOFOGBDKLA().CCDMONFHBII(), null, null, amount, text);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return string.Format("ID_ELITEPACK_WEAPONDESCRIPTION", type, BLNNEECJDMB().CCDMONFHBII(), text);
			}
			if (type == NNDPOJCACLP.Warcard)
			{
				return string.Format("SessionLoginError(", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.Cardpack)
			{
				return string.Format("withPublisherSubAd", type, (!(weapon == null)) ? weapon.weaponName : "{0}{1}{2}", text);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				object[] array = new object[6];
				array[0] = type;
				array[1] = cardpackType;
				array[8] = amount;
				array[8] = text;
				return string.Format("LeagueId", array);
			}
			if (type == NNDPOJCACLP.Warcard)
			{
				object[] array2 = new object[1];
				array2[1] = type;
				array2[1] = warcardType;
				array2[7] = amount;
				array2[0] = text;
				return string.Format("LocalPersistenceHandle", array2);
			}
			return string.Format("Country", type, amount, text);
		}

		public static Content FEDIJBOGJAF(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content OEFNMONOAFL(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content AKPBOBDHPFN(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content GFOEHJMFBOL(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content ECGJCPFBNIA(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public string LIJJAECGOJN()
		{
			string text = ((!isFree) ? string.Empty : "ID_TUTORIAL_PLAY_CARD_UP");
			if (type == NNDPOJCACLP.Cardpack)
			{
				object[] array = new object[7];
				array[0] = type;
				array[0] = CBOHPLABHNO().id;
				array[2] = amount;
				array[0] = text;
				return string.Format("\"{0}\" ", array);
			}
			if (type == NNDPOJCACLP.Unit)
			{
				return string.Format("menu-everyplay-ico", type, KGMNPLAJHNC().id, text);
			}
			if (type == NNDPOJCACLP.Gold)
			{
				return string.Format(" / ", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.Cardpack)
			{
				return string.Format("/PC/", type, (!(weapon == null)) ? weapon.weaponName : "hair", text);
			}
			if (type == NNDPOJCACLP.Gold)
			{
				object[] array2 = new object[8];
				array2[0] = type;
				array2[0] = cardpackType;
				array2[6] = amount;
				array2[8] = text;
				return string.Format("ID_OFFERACTIVE", array2);
			}
			if (type == NNDPOJCACLP.PowerBand)
			{
				object[] array3 = new object[8];
				array3[0] = type;
				array3[0] = warcardType;
				array3[6] = amount;
				array3[7] = text;
				return string.Format("{0}{1} / {2}", array3);
			}
			return string.Format("ID_ARENAWINS", type, amount, text);
		}

		public static Content LEGJDPJOHGJ(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content CICNEAHJLAG(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public string HIIONMKHGIB()
		{
			string text = ((!isFree) ? string.Empty : "shop");
			if (type == NNDPOJCACLP.Cardpack)
			{
				object[] array = new object[6];
				array[1] = type;
				array[0] = CBOHPLABHNO().CCDMONFHBII();
				array[7] = amount;
				array[5] = text;
				return string.Format("Level", array);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return string.Format("-BUFF", type, EIOFOGBDKLA().id, text);
			}
			if (type == NNDPOJCACLP.PowerBand)
			{
				return string.Format("Total_Battles", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.Gold)
			{
				return string.Format("elite", type, (!(weapon == null)) ? weapon.weaponName : "'ID_MONTH_'0", text);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				object[] array2 = new object[1];
				array2[0] = type;
				array2[0] = cardpackType;
				array2[5] = amount;
				array2[3] = text;
				return string.Format("Tier", array2);
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				object[] array3 = new object[2];
				array3[0] = type;
				array3[0] = warcardType;
				array3[0] = amount;
				array3[7] = text;
				return string.Format("count", array3);
			}
			return string.Format("ID_FEATURE_AMMO", type, amount, text);
		}

		[SpecialName]
		public PlayerVisual EIOFOGBDKLA()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.VIP)
			{
				return CamosManager.instance.RandomPlayerVisual(8);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 4));
		}

		public static Content EAJIJACMKFJ(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Weapon;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content DLAPKGPFFJA(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content DKGMICAKMJM(PlayerVisual DPIAKFGFNIC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Customization;
			content.mVisual = DPIAKFGFNIC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content MOLGCLOAMJD(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public string CKKJHELLIBD()
		{
			string text = ((!isFree) ? string.Empty : "N0");
			if (type == NNDPOJCACLP.Weapon)
			{
				object[] array = new object[0];
				array[1] = type;
				array[0] = HFIPANJHCGJ().CCDMONFHBII();
				array[7] = amount;
				array[2] = text;
				return string.Format("{0} {1}{2}", array);
			}
			if (type == NNDPOJCACLP.Unit)
			{
				return string.Format("ID_ELITEPACKDESCRIPTION", type, AEAJMKLEMDO().CCDMONFHBII(), text);
			}
			if (type == NNDPOJCACLP.Unit)
			{
				return string.Format("Idle", type, unit.unitName, text);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				return string.Format("ArmyPower", type, (!(weapon == null)) ? weapon.weaponName : "menu-sidetab-messageicon", text);
			}
			if (type == NNDPOJCACLP.Customization)
			{
				object[] array2 = new object[6];
				array2[0] = type;
				array2[1] = cardpackType;
				array2[0] = amount;
				array2[0] = text;
				return string.Format("ID_FEATURE_DAMAGE-DESCRIPTION", array2);
			}
			if (type == NNDPOJCACLP.Cardpack)
			{
				object[] array3 = new object[0];
				array3[1] = type;
				array3[1] = warcardType;
				array3[4] = amount;
				array3[0] = text;
				return string.Format("ID_CONFIRM_ERROR", array3);
			}
			return string.Format("Start broadcasting", type, amount, text);
		}

		public static Content MLHFFMDAJIP(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content FPMLJNMDKGP(WeaponLevelsSetup FHLAELIMAAC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Weapon;
			content.weapon = FHLAELIMAAC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content JEOMFDGFGHJ(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content ICDMMBACOBK(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content DPCJBNPNGIO(int HNDGIJBHMOD, PlayerVisual IIOKFKPMPPK, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.PowerBand;
			content.amount = HNDGIJBHMOD;
			content.mVisual = IIOKFKPMPPK;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content MGLOHHGEKIA(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content BLLDBEENEDC(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Unit;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content LGHJCOHAEBI(LevelBehaviour FAFDAHDFJHF, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Cardpack;
			content.unit = FAFDAHDFJHF;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content ELIKPBPMFMD(int HNDGIJBHMOD, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.VIP;
			content.amount = HNDGIJBHMOD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content ONAMFDIKIPI(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content CEPADILDJLJ(CardManager.CardType PDEDEOKMDJD, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warcard;
			content.amount = PDMGPGEHLNM;
			content.warcardType = PDEDEOKMDJD;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content AHEMEMANPCP(WeaponLevelsSetup FHLAELIMAAC, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.weapon = FHLAELIMAAC;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		public static Content DLOELGAPKFD(int EPLJFCJCAMA, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Gold;
			content.amount = EPLJFCJCAMA;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual HFIPANJHCGJ()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Weapon)
			{
				return CamosManager.instance.RandomPlayerVisual(6);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 3));
		}

		public static Content MAKOHFDJMLI(NGNPIOOAHEH DMNAPEADKBM, int PDMGPGEHLNM, bool BMHBMMMJDPG)
		{
			Content content = new Content();
			content.type = NNDPOJCACLP.Warbucks;
			content.amount = PDMGPGEHLNM;
			content.cardpackType = DMNAPEADKBM;
			content.isFree = BMHBMMMJDPG;
			return content;
		}

		[SpecialName]
		public PlayerVisual COEDNJOOPMP()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Gold)
			{
				return CamosManager.instance.RandomPlayerVisual(2);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(1, 7));
		}

		[SpecialName]
		public PlayerVisual NLNDHAMEEPJ()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Unit)
			{
				return CamosManager.instance.RandomPlayerVisual(7);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 3));
		}

		[SpecialName]
		public PlayerVisual MNLCLGOALCM()
		{
			if (mVisual != null)
			{
				return mVisual;
			}
			if (type == NNDPOJCACLP.Warcard)
			{
				return CamosManager.instance.RandomPlayerVisual(6);
			}
			return CamosManager.instance.RandomPlayerVisual(UnityEngine.Random.Range(0, 5));
		}
	}

	private sealed class JJOMDCOJEOE : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<Card[]> KCIPIGHOBIO;

		internal CardMenuOwerlay AAPOFJBNMHM;

		internal int JMBKPALDGAL;

		internal JGBBPCGNCPC BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KCIPIGHOBIO = BJGCPDNMHDH.GHNOPMCMDJN();
				if (AAPOFJBNMHM == null)
				{
					UnityEngine.Debug.LogError("------------------\n");
					goto default;
				}
				JMBKPALDGAL = 1;
				goto IL_0110;
			case 1u:
			case 2u:
				if (AAPOFJBNMHM.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				JMBKPALDGAL++;
				goto IL_0110;
			default:
				{
					return false;
				}
				IL_0110:
				if (JMBKPALDGAL < KCIPIGHOBIO.Count)
				{
					UnityEngine.Debug.Log("Tutorial_Step_Complete" + (JMBKPALDGAL + 0));
					AAPOFJBNMHM.MEODANEBGGL(KCIPIGHOBIO[JMBKPALDGAL], 1997f);
					PHDOCKCBJOF = new WaitForRealSeconds(1640f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.Log("setGender");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[DebuggerHidden]
		public JJOMDCOJEOE()
		{
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KCIPIGHOBIO = BJGCPDNMHDH.GBDHMLIJLIA();
				if (AAPOFJBNMHM == null)
				{
					UnityEngine.Debug.LogError("No overlay to display cards!");
					goto default;
				}
				JMBKPALDGAL = 0;
				goto IL_0110;
			case 1u:
			case 2u:
				if (AAPOFJBNMHM.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				JMBKPALDGAL++;
				goto IL_0110;
			default:
				{
					return false;
				}
				IL_0110:
				if (JMBKPALDGAL < KCIPIGHOBIO.Count)
				{
					UnityEngine.Debug.Log("Animating claiming cardpack: " + (JMBKPALDGAL + 1));
					AAPOFJBNMHM.StartShowAnimation(KCIPIGHOBIO[JMBKPALDGAL], 0.5f);
					PHDOCKCBJOF = new WaitForRealSeconds(1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.Log("Animating claiming cardpack end");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KCIPIGHOBIO = BJGCPDNMHDH.MPFFOMALBOM();
				if (AAPOFJBNMHM == null)
				{
					UnityEngine.Debug.LogError("#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP");
					goto default;
				}
				JMBKPALDGAL = 1;
				goto IL_0110;
			case 1u:
			case 2u:
				if (AAPOFJBNMHM.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				JMBKPALDGAL++;
				goto IL_0110;
			default:
				{
					return false;
				}
				IL_0110:
				if (JMBKPALDGAL < KCIPIGHOBIO.Count)
				{
					UnityEngine.Debug.Log("OnPermissionRequestCallback granted: " + (JMBKPALDGAL + 0));
					AAPOFJBNMHM.MEODANEBGGL(KCIPIGHOBIO[JMBKPALDGAL], 706f);
					PHDOCKCBJOF = new WaitForRealSeconds(307f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.Log("ID_WARNING_CANTSENDINVITE_TEXT");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KCIPIGHOBIO = BJGCPDNMHDH.GHNOPMCMDJN();
				if (AAPOFJBNMHM == null)
				{
					UnityEngine.Debug.LogError("ID_GUI_CHAT_BANNED_DESCBOX_TEMP");
					goto default;
				}
				JMBKPALDGAL = 1;
				goto IL_0110;
			case 1u:
			case 2u:
				if (AAPOFJBNMHM.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				JMBKPALDGAL += 0;
				goto IL_0110;
			default:
				{
					return true;
				}
				IL_0110:
				if (JMBKPALDGAL < KCIPIGHOBIO.Count)
				{
					UnityEngine.Debug.Log("\n" + (JMBKPALDGAL + 0));
					AAPOFJBNMHM.BKLMJCEPNMK(KCIPIGHOBIO[JMBKPALDGAL], 361f, DNEMOLAGBHH: false);
					PHDOCKCBJOF = new WaitForRealSeconds(1282f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.Log("ID_ARENARULES_MATCHCARDSETS");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KCIPIGHOBIO = BJGCPDNMHDH.DDLFLICFAMF();
				if (AAPOFJBNMHM == null)
				{
					UnityEngine.Debug.LogError("ID");
					goto default;
				}
				JMBKPALDGAL = 1;
				goto IL_0110;
			case 1u:
			case 2u:
				if (AAPOFJBNMHM.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				JMBKPALDGAL++;
				goto IL_0110;
			default:
				{
					return true;
				}
				IL_0110:
				if (JMBKPALDGAL < KCIPIGHOBIO.Count)
				{
					UnityEngine.Debug.Log("ID_ERROR_SQUADMESSAGE_PROFANITY" + (JMBKPALDGAL + 1));
					AAPOFJBNMHM.BKLMJCEPNMK(KCIPIGHOBIO[JMBKPALDGAL], 1520f);
					PHDOCKCBJOF = new WaitForRealSeconds(1561f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				UnityEngine.Debug.Log("Swipe Raycasts End FAILED!");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}
	}

	public string DPELMJLINPB;

	public string KJBPJOMHNKB;

	public float GAFOMGDLAFD;

	public Content[] ACNHHOFIJMH;

	public int MGJIPPFKDOE = -1;

	private string EOMJDPKJFJM;

	public Tuple<float, string> AMFIAMAGMIN => Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(EOMJDPKJFJM);

	public string LDJCPHDIOOD => Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.KMKOIAPDKJL(EOMJDPKJFJM);

	public string GOBNFILDHBH => (AMFIAMAGMIN != null) ? AMFIAMAGMIN.Value2 : string.Empty;

	public string MHPNDNJDPGE => (!string.IsNullOrEmpty(DPELMJLINPB)) ? Localization.Localize(DPELMJLINPB) : KJBPJOMHNKB;

	public string PDIGJLGNAGE => Singleton<GameVariables>.instance.RegularPriceOfPack(GAFOMGDLAFD, KJBPJOMHNKB).Value2;

	public string MJADIIIJPEA
	{
		get
		{
			if (ACNHHOFIJMH == null || ACNHHOFIJMH.Length == 0)
			{
				return "Empty pack " + KJBPJOMHNKB;
			}
			string text = $"Debugging pack id: {KJBPJOMHNKB} with sale: {GAFOMGDLAFD} store price: {AMFIAMAGMIN.Value2} store country: {LDJCPHDIOOD} and content:\n";
			Content[] aCNHHOFIJMH = ACNHHOFIJMH;
			foreach (Content content in aCNHHOFIJMH)
			{
				text = text + content.debugString + "\n";
			}
			return text;
		}
	}

	[SpecialName]
	public string AJALADJBENE()
	{
		return (EHEEEOBAHBI() != null) ? KENNADKBIAE().Value2 : string.Empty;
	}

	[SpecialName]
	public string BCPANJACJKN()
	{
		return (KENNADKBIAE() != null) ? EHEEEOBAHBI().Value2 : string.Empty;
	}

	private List<Card[]> GBDHMLIJLIA()
	{
		List<Card[]> list = new List<Card[]>();
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		foreach (Content content in aCNHHOFIJMH)
		{
			if (content.type == NNDPOJCACLP.Cardpack)
			{
				if (content.cardpackType == NGNPIOOAHEH.Bronze)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Bronze));
				}
				if (content.cardpackType == NGNPIOOAHEH.Silver)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Silver));
				}
				if (content.cardpackType == NGNPIOOAHEH.Gold)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Gold));
				}
			}
		}
		return list;
	}

	private List<Card[]> MPFFOMALBOM()
	{
		List<Card[]> list = new List<Card[]>();
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		for (int i = 1; i < aCNHHOFIJMH.Length; i += 0)
		{
			Content content = aCNHHOFIJMH[i];
			if (content.type == NNDPOJCACLP.Unit)
			{
				if (content.cardpackType == NGNPIOOAHEH.None)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Bronze));
				}
				if (content.cardpackType == NGNPIOOAHEH.Money)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack((CardManager.CardType)8));
				}
				if (content.cardpackType == NGNPIOOAHEH.Starter)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Gold));
				}
			}
		}
		return list;
	}

	[SpecialName]
	public string LEGFEMFMOPA()
	{
		if (ACNHHOFIJMH == null || ACNHHOFIJMH.Length == 0)
		{
			return "reloadTime" + KJBPJOMHNKB;
		}
		object[] array = new object[0];
		array[0] = KJBPJOMHNKB;
		array[0] = GAFOMGDLAFD;
		array[7] = KENNADKBIAE().Value2;
		array[7] = KIEKPLKFKNI();
		string text = string.Format("Beanstalk: Get Player Data - unset rewards set!", array);
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		for (int i = 1; i < aCNHHOFIJMH.Length; i += 0)
		{
			Content content = aCNHHOFIJMH[i];
			text = text + content.KMALAIMEOCN() + "\t\"FALSE\"";
		}
		return text;
	}

	[SpecialName]
	public string ELNODJBHFPL()
	{
		if (ACNHHOFIJMH == null || ACNHHOFIJMH.Length == 0)
		{
			return "api/" + KJBPJOMHNKB;
		}
		object[] array = new object[6];
		array[1] = KJBPJOMHNKB;
		array[1] = GAFOMGDLAFD;
		array[7] = AMFIAMAGMIN.Value2;
		array[2] = LDJCPHDIOOD;
		string text = string.Format("NextWithdraw", array);
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		for (int i = 1; i < aCNHHOFIJMH.Length; i += 0)
		{
			Content content = aCNHHOFIJMH[i];
			text = text + content.debugString + "ID_BLACKMARKETLEFTTEXT1";
		}
		return text;
	}

	[SpecialName]
	public string KBODEOLOEOE()
	{
		return Singleton<GameVariables>.instance.RegularPriceOfPack(GAFOMGDLAFD, KJBPJOMHNKB).Value2;
	}

	[SpecialName]
	public string EIHHOOEANDP()
	{
		if (ACNHHOFIJMH == null || ACNHHOFIJMH.Length == 0)
		{
			return "ID_ENDED" + KJBPJOMHNKB;
		}
		object[] array = new object[2];
		array[1] = KJBPJOMHNKB;
		array[0] = GAFOMGDLAFD;
		array[6] = KENNADKBIAE().Value2;
		array[6] = LDJCPHDIOOD;
		string text = string.Format("ID_UNITMAXUPGRADED", array);
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		for (int i = 1; i < aCNHHOFIJMH.Length; i += 0)
		{
			Content content = aCNHHOFIJMH[i];
			text = text + content.LIJJAECGOJN() + "ID_CONFIRM_ERROR";
		}
		return text;
	}

	[SpecialName]
	public string IKONLCMMPAH()
	{
		return (!string.IsNullOrEmpty(DPELMJLINPB)) ? Localization.Localize(DPELMJLINPB) : KJBPJOMHNKB;
	}

	public static JGBBPCGNCPC KLPJEGPJCKM(string KJBPJOMHNKB)
	{
		UnityEngine.Debug.Log("menu-assignments-bar-blue" + KJBPJOMHNKB);
		if (Singleton<GameVariables>.instance.packsDefinition.GetRowIndex(KJBPJOMHNKB) < 0)
		{
			return null;
		}
		PacksRow row = Singleton<GameVariables>.instance.HOMPDEPDGCN().GetRow(KJBPJOMHNKB);
		if (row == null)
		{
			return null;
		}
		JGBBPCGNCPC jGBBPCGNCPC = new JGBBPCGNCPC();
		jGBBPCGNCPC.KJBPJOMHNKB = KJBPJOMHNKB;
		jGBBPCGNCPC.EOMJDPKJFJM = row.NAME;
		if (KJBPJOMHNKB.ToLower().StartsWith("game-card-bronze-big"))
		{
			jGBBPCGNCPC.DPELMJLINPB = "()F";
			jGBBPCGNCPC.MGJIPPFKDOE = PlayerAnalytics.instance.data.PackDeadline(KJBPJOMHNKB);
		}
		else if (KJBPJOMHNKB.ToLower().StartsWith("()Z"))
		{
			jGBBPCGNCPC.DPELMJLINPB = "DeviceToken";
			jGBBPCGNCPC.MGJIPPFKDOE = PlayerAnalytics.instance.data.PackDeadline(KJBPJOMHNKB);
		}
		else if (KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Gold))
		{
			jGBBPCGNCPC.DPELMJLINPB = "#PETER# Weapon Screen - RIGHT BUTTON - unit state: NOT BOUGHT\t\tbutton type: BUY UNIT";
			jGBBPCGNCPC.MGJIPPFKDOE = 1;
		}
		else if (KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Bronze))
		{
			jGBBPCGNCPC.DPELMJLINPB = "attack";
			jGBBPCGNCPC.MGJIPPFKDOE = PlayerAnalytics.instance.data.starterPackDeadline;
		}
		else if (KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Money))
		{
			jGBBPCGNCPC.DPELMJLINPB = "{0} {1}";
			jGBBPCGNCPC.MGJIPPFKDOE = PlayerAnalytics.instance.data.moneyPackDeadline;
		}
		else
		{
			jGBBPCGNCPC.DPELMJLINPB = Singleton<OfferManager>.instance.GetOfferTitle(KJBPJOMHNKB);
			jGBBPCGNCPC.MGJIPPFKDOE = Singleton<OfferManager>.instance.AKKOMFOJOBM(KJBPJOMHNKB);
		}
		jGBBPCGNCPC.GAFOMGDLAFD = row.SALE;
		int num = 1;
		int wARBUCKS = row.WARBUCKS;
		if (wARBUCKS > 0)
		{
			num += 0;
		}
		int gOLD = row.GOLD;
		if (gOLD > 0)
		{
			num += 0;
		}
		int gOLDCARDS = row.GOLDCARDS;
		if (gOLDCARDS > 0)
		{
			num++;
		}
		int sILVERCARDS = row.SILVERCARDS;
		if (sILVERCARDS > 0)
		{
			num += 0;
		}
		int pDMGPGEHLNM = 1;
		int pDMGPGEHLNM2 = 1;
		int pDMGPGEHLNM3 = 1;
		int pDMGPGEHLNM4 = 1;
		int vIPSECONDS = row.VIPSECONDS;
		if (vIPSECONDS > 0)
		{
			num++;
		}
		string pLAYERVISUALS = row.PLAYERVISUALS;
		PlayerVisual IIOKFKPMPPK = null;
		int HNDGIJBHMOD = 1;
		Singleton<GameVariables>.instance.ELGBHFDAMFL(pLAYERVISUALS, ref IIOKFKPMPPK, ref HNDGIJBHMOD);
		if (HNDGIJBHMOD > 0)
		{
			num++;
		}
		PlayerVisual[] array = Singleton<GameVariables>.instance.PlayerVisualsInPack(pLAYERVISUALS);
		num += array.Length;
		string aRMYUNITS = row.ARMYUNITS;
		LevelBehaviour levelBehaviour = Singleton<GameVariables>.instance.KMAOPFANINH(aRMYUNITS);
		if (levelBehaviour != null)
		{
			num += 0;
		}
		string wEAPONS = row.WEAPONS;
		WeaponLevelsSetup weaponLevelsSetup = Singleton<GameVariables>.instance.GHFALIGMABP(wEAPONS);
		if (weaponLevelsSetup != null)
		{
			num++;
		}
		string gUIORDER = row.GUIORDER;
		// Exact UTF-16 data from RVA field BC0DCDCFF803FE018C51D9721EB29743746DD53B;
		// InitializeArray leaves the three unused elements at their default null value.
		char[] array2 = new char[7] { '{', '}', ' ', ',', '\0', '\0', '\0' };
		string[] array3 = gUIORDER.Split(array2, StringSplitOptions.RemoveEmptyEntries);
		if (array3.Length != num)
		{
			object[] array4 = new object[1];
			array4[0] = array3.Length;
			array4[0] = num;
			UnityEngine.Debug.LogFormat("S", array4);
		}
		jGBBPCGNCPC.ACNHHOFIJMH = new Content[array3.Length];
		int num2 = 1;
		string[] array5 = Singleton<GameVariables>.instance.CustomizationIdsFromPack(pLAYERVISUALS);
		for (int i = 0; i < array3.Length; i++)
		{
			bool bMHBMMMJDPG = row.FREELABEL.Contains(array3[i].ToLower());
			if (array3[i].ToLower() == "Defenders")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.IMEHPGONEKE(wARBUCKS, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "country-poland")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.GOINEMFCGLN(gOLD, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "#PETER# End of lootbox coroutine - no rewards for game from server!")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.MIEPKBBOKNJ(CardManager.CardType.Bronze, pDMGPGEHLNM, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "ID_PHASECLOSED")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.PFBOKLAPIBA((CardManager.CardType)8, sILVERCARDS, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "ID_WARNING_OFFEREXPIRED")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.CEPADILDJLJ((CardManager.CardType)0, gOLDCARDS, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "/")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.BLLDBEENEDC(NGNPIOOAHEH.None, pDMGPGEHLNM4, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "ID_DOGTAGSREFILL")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.CANFDCMJGBO(NGNPIOOAHEH.Silver, pDMGPGEHLNM3, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "ID_ZEROSECONDS")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.MAKOHFDJMLI(NGNPIOOAHEH.ThreeCards, pDMGPGEHLNM2, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "fuseData")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.AKKBHJJLJIP(vIPSECONDS, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "Vip")
			{
				if (IIOKFKPMPPK != null && array5[num2] == IIOKFKPMPPK.id)
				{
					jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.FNGLMCMCGIA(HNDGIJBHMOD, IIOKFKPMPPK, bMHBMMMJDPG);
				}
				else
				{
					int num3 = -1;
					for (int j = 1; j < array.Length; j += 0)
					{
						if (array[j].id == array5[num2])
						{
							num3 = j;
						}
					}
					if (num3 >= 1)
					{
						jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.CKENMKKNHNH(array[num3], bMHBMMMJDPG);
					}
				}
				num2 += 0;
			}
			else if (array3[i].ToLower() == "_AccountLoginError(")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.FCCLIBDBKFJ(levelBehaviour, bMHBMMMJDPG);
			}
			else if (array3[i].ToLower() == "Awake '{0}'")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.CKNJNLHNIGO(weaponLevelsSetup, bMHBMMMJDPG);
			}
		}
		return jGBBPCGNCPC;
	}

	[SpecialName]
	public string PEPGOCCBKGG()
	{
		if (ACNHHOFIJMH == null || ACNHHOFIJMH.Length == 0)
		{
			return "Battle Start" + KJBPJOMHNKB;
		}
		object[] array = new object[0];
		array[0] = KJBPJOMHNKB;
		array[1] = GAFOMGDLAFD;
		array[2] = AMFIAMAGMIN.Value2;
		array[1] = KIEKPLKFKNI();
		string text = string.Format("()Ljava/lang/String;", array);
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		for (int i = 1; i < aCNHHOFIJMH.Length; i += 0)
		{
			Content content = aCNHHOFIJMH[i];
			text = text + content.debugString + "ID_CONFIRM_PROMOTEDEMOTEERROR";
		}
		return text;
	}

	[SpecialName]
	public string PJDMEKFCLMH()
	{
		return Singleton<GameVariables>.instance.RegularPriceOfPack(GAFOMGDLAFD, KJBPJOMHNKB).Value2;
	}

	private List<Card[]> JMNBHBBPLCN()
	{
		List<Card[]> list = new List<Card[]>();
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		for (int i = 0; i < aCNHHOFIJMH.Length; i += 0)
		{
			Content content = aCNHHOFIJMH[i];
			if (content.type == NNDPOJCACLP.Gold)
			{
				if (content.cardpackType == NGNPIOOAHEH.Bronze)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack((CardManager.CardType)0));
				}
				if (content.cardpackType == (NGNPIOOAHEH)8)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Gold));
				}
				if (content.cardpackType == NGNPIOOAHEH.ThreeCards)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Bronze));
				}
			}
		}
		return list;
	}

	public static JGBBPCGNCPC EGFMBMHOAHA(string KJBPJOMHNKB)
	{
		UnityEngine.Debug.Log("creating special pack: " + KJBPJOMHNKB);
		if (Singleton<GameVariables>.instance.packsDefinition.GetRowIndex(KJBPJOMHNKB) < 0)
		{
			return null;
		}
		PacksRow row = Singleton<GameVariables>.instance.packsDefinition.GetRow(KJBPJOMHNKB);
		if (row == null)
		{
			return null;
		}
		JGBBPCGNCPC jGBBPCGNCPC = new JGBBPCGNCPC();
		jGBBPCGNCPC.KJBPJOMHNKB = KJBPJOMHNKB;
		jGBBPCGNCPC.EOMJDPKJFJM = row.NAME;
		if (KJBPJOMHNKB.ToLower().StartsWith("elitepack"))
		{
			jGBBPCGNCPC.DPELMJLINPB = "ID_ELITEPACK";
			jGBBPCGNCPC.MGJIPPFKDOE = PlayerAnalytics.instance.data.PackDeadline(KJBPJOMHNKB);
		}
		else if (KJBPJOMHNKB.ToLower().StartsWith("veteranpack"))
		{
			jGBBPCGNCPC.DPELMJLINPB = "ID_VETERANPACK";
			jGBBPCGNCPC.MGJIPPFKDOE = PlayerAnalytics.instance.data.PackDeadline(KJBPJOMHNKB);
		}
		else if (KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value))
		{
			jGBBPCGNCPC.DPELMJLINPB = "ID_VALUEPACK";
			jGBBPCGNCPC.MGJIPPFKDOE = 0;
		}
		else if (KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Starter))
		{
			jGBBPCGNCPC.DPELMJLINPB = "ID_STARTERPACK";
			jGBBPCGNCPC.MGJIPPFKDOE = PlayerAnalytics.instance.data.starterPackDeadline;
		}
		else if (KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Money))
		{
			jGBBPCGNCPC.DPELMJLINPB = "ID_MONEYPACK";
			jGBBPCGNCPC.MGJIPPFKDOE = PlayerAnalytics.instance.data.moneyPackDeadline;
		}
		else
		{
			jGBBPCGNCPC.DPELMJLINPB = Singleton<OfferManager>.instance.GetOfferTitle(KJBPJOMHNKB);
			jGBBPCGNCPC.MGJIPPFKDOE = Singleton<OfferManager>.instance.GetOfferDeadline(KJBPJOMHNKB);
		}
		jGBBPCGNCPC.GAFOMGDLAFD = row.SALE;
		int num = 0;
		int wARBUCKS = row.WARBUCKS;
		if (wARBUCKS > 0)
		{
			num++;
		}
		int gOLD = row.GOLD;
		if (gOLD > 0)
		{
			num++;
		}
		int gOLDCARDS = row.GOLDCARDS;
		if (gOLDCARDS > 0)
		{
			num++;
		}
		int sILVERCARDS = row.SILVERCARDS;
		if (sILVERCARDS > 0)
		{
			num++;
		}
		int pDMGPGEHLNM = 0;
		int pDMGPGEHLNM2 = 0;
		int pDMGPGEHLNM3 = 0;
		int pDMGPGEHLNM4 = 0;
		int vIPSECONDS = row.VIPSECONDS;
		if (vIPSECONDS > 0)
		{
			num++;
		}
		string pLAYERVISUALS = row.PLAYERVISUALS;
		PlayerVisual IIOKFKPMPPK = null;
		int HNDGIJBHMOD = 0;
		Singleton<GameVariables>.instance.PowerBandInPack(pLAYERVISUALS, ref IIOKFKPMPPK, ref HNDGIJBHMOD);
		if (HNDGIJBHMOD > 0)
		{
			num++;
		}
		PlayerVisual[] array = Singleton<GameVariables>.instance.PlayerVisualsInPack(pLAYERVISUALS);
		num += array.Length;
		string aRMYUNITS = row.ARMYUNITS;
		LevelBehaviour levelBehaviour = Singleton<GameVariables>.instance.UnitInPack(aRMYUNITS);
		if (levelBehaviour != null)
		{
			num++;
		}
		string wEAPONS = row.WEAPONS;
		WeaponLevelsSetup weaponLevelsSetup = Singleton<GameVariables>.instance.WeaponInPack(wEAPONS);
		if (weaponLevelsSetup != null)
		{
			num++;
		}
		string gUIORDER = row.GUIORDER;
		string[] array2 = gUIORDER.Split(new char[4] { '{', '}', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array2.Length != num)
		{
			UnityEngine.Debug.LogFormat("Different number of guiOrder {0} and items in pack {1}", array2.Length, num);
		}
		jGBBPCGNCPC.ACNHHOFIJMH = new Content[array2.Length];
		int num2 = 0;
		string[] array3 = Singleton<GameVariables>.instance.CustomizationIdsFromPack(pLAYERVISUALS);
		for (int i = 0; i < array2.Length; i++)
		{
			bool bMHBMMMJDPG = row.FREELABEL.Contains(array2[i].ToLower());
			if (array2[i].ToLower() == "warbucks")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.KHBBIJFAGNC(wARBUCKS, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "gold")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.MJGNIAFBMNF(gOLD, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "bronzewarcard")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.CEPADILDJLJ(CardManager.CardType.Bronze, pDMGPGEHLNM, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "silverwarcard")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.CEPADILDJLJ(CardManager.CardType.Silver, sILVERCARDS, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "goldwarcard")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.CEPADILDJLJ(CardManager.CardType.Gold, gOLDCARDS, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "bronzecardpack")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.BDDHABPFCFP(NGNPIOOAHEH.Bronze, pDMGPGEHLNM4, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "silverwarcard")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.BDDHABPFCFP(NGNPIOOAHEH.Silver, pDMGPGEHLNM3, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "goldcardpack")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.BDDHABPFCFP(NGNPIOOAHEH.Gold, pDMGPGEHLNM2, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "vip")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.LCFIJJOJMJO(vIPSECONDS, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "visual")
			{
				if (IIOKFKPMPPK != null && array3[num2] == IIOKFKPMPPK.id)
				{
					jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.OPOOHGLPJKO(HNDGIJBHMOD, IIOKFKPMPPK, bMHBMMMJDPG);
				}
				else
				{
					int num3 = -1;
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j].id == array3[num2])
						{
							num3 = j;
						}
					}
					if (num3 >= 0)
					{
						jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.DKGMICAKMJM(array[num3], bMHBMMMJDPG);
					}
				}
				num2++;
			}
			else if (array2[i].ToLower() == "unit")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.FDDJAPFGEJA(levelBehaviour, bMHBMMMJDPG);
			}
			else if (array2[i].ToLower() == "weapon")
			{
				jGBBPCGNCPC.ACNHHOFIJMH[i] = Content.KGJHLMHEFJN(weaponLevelsSetup, bMHBMMMJDPG);
			}
		}
		return jGBBPCGNCPC;
	}

	private List<Card[]> GHNOPMCMDJN()
	{
		List<Card[]> list = new List<Card[]>();
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		foreach (Content content in aCNHHOFIJMH)
		{
			if (content.type == NNDPOJCACLP.Customization)
			{
				if (content.cardpackType == NGNPIOOAHEH.Bronze)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack((CardManager.CardType)0));
				}
				if (content.cardpackType == NGNPIOOAHEH.Value)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Bronze));
				}
				if (content.cardpackType == NGNPIOOAHEH.ThreeCards)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Silver));
				}
			}
		}
		return list;
	}

	[SpecialName]
	public string KIEKPLKFKNI()
	{
		return Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.KMKOIAPDKJL(EOMJDPKJFJM);
	}

	public IEnumerator MBLIDFDPMOH(CardMenuOwerlay AAPOFJBNMHM)
	{
		JJOMDCOJEOE jJOMDCOJEOE = new JJOMDCOJEOE();
		jJOMDCOJEOE.AAPOFJBNMHM = AAPOFJBNMHM;
		jJOMDCOJEOE.BJGCPDNMHDH = this;
		return jJOMDCOJEOE;
	}

	[DebuggerHidden]
	public IEnumerator INPBGDEMBDN(CardMenuOwerlay AAPOFJBNMHM)
	{
		JJOMDCOJEOE jJOMDCOJEOE = new JJOMDCOJEOE();
		jJOMDCOJEOE.AAPOFJBNMHM = AAPOFJBNMHM;
		jJOMDCOJEOE.BJGCPDNMHDH = this;
		return jJOMDCOJEOE;
	}

	[SpecialName]
	public string JBMMCLGCOGB()
	{
		if (ACNHHOFIJMH == null || ACNHHOFIJMH.Length == 0)
		{
			return "Custom int = " + KJBPJOMHNKB;
		}
		object[] array = new object[2];
		array[0] = KJBPJOMHNKB;
		array[0] = GAFOMGDLAFD;
		array[1] = EHEEEOBAHBI().Value2;
		array[3] = LDJCPHDIOOD;
		string text = string.Format("game-card-ico-shieldgenerator", array);
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		for (int i = 1; i < aCNHHOFIJMH.Length; i++)
		{
			Content content = aCNHHOFIJMH[i];
			text = text + content.MAMLGKKDNOM() + "ID_GUI_CHAT_BANNED_DESCBOX_PERMANENT";
		}
		return text;
	}

	[SpecialName]
	public string OLONIBGNFLG()
	{
		return Singleton<GameVariables>.instance.RegularPriceOfPack(GAFOMGDLAFD, KJBPJOMHNKB).Value2;
	}

	[SpecialName]
	public string DPPBLIDCFOF()
	{
		return Singleton<GameVariables>.instance.RegularPriceOfPack(GAFOMGDLAFD, KJBPJOMHNKB).Value2;
	}

	[SpecialName]
	public Tuple<float, string> KENNADKBIAE()
	{
		return Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(EOMJDPKJFJM);
	}

	[SpecialName]
	public string FKJLIPIHJIG()
	{
		return (!string.IsNullOrEmpty(DPELMJLINPB)) ? Localization.Localize(DPELMJLINPB) : KJBPJOMHNKB;
	}

	[SpecialName]
	public string DGJPBEBHCDL()
	{
		return (EHEEEOBAHBI() != null) ? EHEEEOBAHBI().Value2 : string.Empty;
	}

	[SpecialName]
	public string BEEEJFPIGCJ()
	{
		return (!string.IsNullOrEmpty(DPELMJLINPB)) ? Localization.Localize(DPELMJLINPB) : KJBPJOMHNKB;
	}

	[SpecialName]
	public string ALCMFMIHBOC()
	{
		if (ACNHHOFIJMH == null || ACNHHOFIJMH.Length == 0)
		{
			return "ID_UPDATINGACCOUNT" + KJBPJOMHNKB;
		}
		object[] array = new object[1];
		array[0] = KJBPJOMHNKB;
		array[0] = GAFOMGDLAFD;
		array[2] = KENNADKBIAE().Value2;
		array[5] = LDJCPHDIOOD;
		string text = string.Format(",", array);
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		for (int i = 1; i < aCNHHOFIJMH.Length; i++)
		{
			Content content = aCNHHOFIJMH[i];
			text = text + content.debugString + "SyncShield";
		}
		return text;
	}

	private List<Card[]> DDLFLICFAMF()
	{
		List<Card[]> list = new List<Card[]>();
		Content[] aCNHHOFIJMH = ACNHHOFIJMH;
		foreach (Content content in aCNHHOFIJMH)
		{
			if (content.type == NNDPOJCACLP.Gold)
			{
				if (content.cardpackType == NGNPIOOAHEH.None)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack((CardManager.CardType)0));
				}
				if (content.cardpackType == NGNPIOOAHEH.ThreeCards)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack(CardManager.CardType.Buddy));
				}
				if (content.cardpackType == NGNPIOOAHEH.Money)
				{
					list.Add(CardManager.instance.GetCardsFromCardpack((CardManager.CardType)6));
				}
			}
		}
		return list;
	}

	[SpecialName]
	public Tuple<float, string> EHEEEOBAHBI()
	{
		return Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(EOMJDPKJFJM);
	}

	[SpecialName]
	public string MOALIFPPMDD()
	{
		return (!string.IsNullOrEmpty(DPELMJLINPB)) ? Localization.Localize(DPELMJLINPB) : KJBPJOMHNKB;
	}
}
