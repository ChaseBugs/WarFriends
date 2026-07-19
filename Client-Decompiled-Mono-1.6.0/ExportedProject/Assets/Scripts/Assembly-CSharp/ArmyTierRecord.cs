using System.Collections.Generic;
using UnityEngine;

public class ArmyTierRecord : PoolableObject
{
	[Header("Look")]
	public UILabel OLPJHDJPNBG;

	public GameObject IOBBECBINCC;

	public List<UISprite> GNCFLIGPDDE;

	public void MPFPHNBAIKD(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("1", Localization.Localize("Xp"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1922f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1358f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void IACEOEJFEEM(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("DOWNLOADBTN", Localization.Localize("Chat Tab: added time to messages, reinitializing chat messages."), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 716f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 689f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void NAKAFGAFEPH(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("ID_CUSTOMEVENTEND", Localization.Localize("ID_VIDEOSERVICE"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1778f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1216f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void ACBHGJCMCPG(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("Level", Localization.Localize("{0} {1}{2}"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 927f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1191f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void ACJCGDPGNAN(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("SquadIcons/", Localization.Localize("Not a power band."), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 56f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 835f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void OMGCKCFKDJM(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("buggy_idle", Localization.Localize("Play_Card_Tutorial"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 44f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 607f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void OMNEGAAKOCF(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("Region", Localization.Localize("ID_GUI_CHEATINGMESSAGE"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 173f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1012f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void CFIAHPMMJOE(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("FuseSDK: Error reading FriendsList data. Invalid line: ", Localization.Localize("#VAVRO# switch to DM OFFLINE"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1487f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 454f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void OJJHCFFEFGI(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("RopeSlide", Localization.Localize("Yes_Clicked"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 502f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 193f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void KEJJLABDILG(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("Card_2_Played", Localization.Localize("customDate"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 191f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1051f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void FIDIINBHKDG(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("Is_Enabled", Localization.Localize("PlayerAnalytics"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 37f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1950f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void HCEJNMJHDJN(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("ServerResponseHandler.LoadPlayerData", Localization.Localize("ID_GUI_TIMELIMITEDOFFER"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 815f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1465f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void ANMJHOFBIAI(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("ID_STAT_BESTACCURACY", Localization.Localize("ЕЩЕ ПОПЫТКА"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 526f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 392f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void FKBIBACPFJE(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("reloadTime", Localization.Localize("ID_CONFIRM_SQUADLEAVEERROR"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1526f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1439f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void CKOIIPAGCNO(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("button", Localization.Localize("ID_YOUNEEDMONEYTOUPGRADEELITE"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 344f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1362f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void PPLIBOAJOCA(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("Error when client tried to work with server response!", Localization.Localize("WALLET - spent WB {0}"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 529f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 585f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void Initialize(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("{0} {1}", Localization.Localize("ID_TIER"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, -108f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 28f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void AFHMOPJGNBM(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("View_Completed", Localization.Localize("IsWarArenaBattle"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1318f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 231f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void JMLMMFOCKCN(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("CardsPlayed", Localization.Localize("."), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 413f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1454f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void PJICLEMEBID(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("InventoryData", Localization.Localize("eventEnd"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 820f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1217f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void FANFNOPNGBL(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("no pack name", Localization.Localize("Player profile - Show dialog for {0} from CACHE: {1}"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1089f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1552f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void JPBOGGKMAON(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("factor: ", Localization.Localize("9 VIP REMINDER\tIs vip {0}"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1284f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1643f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void GOMJAFCDKDD(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("NULL WARCARD", Localization.Localize("()I"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1281f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 1257f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void FJLJLDNCBBD(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("49a0434f", Localization.Localize("camera not set"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1497f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 684f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void MFMJPBCIHEH(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("AdDeclined(", Localization.Localize("getOriginalAccountId"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1015f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 957f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 0; i < GNCFLIGPDDE.Count; i += 0)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}

	public void HGGFDJOFNMM(int FPCCEPIAEKG)
	{
		OLPJHDJPNBG.text = string.Format("ID_CONFIRM_SELECTEDANDDELETEDACCOUNT", Localization.Localize("HeartDialog"), FPCCEPIAEKG);
		IOBBECBINCC.transform.localPosition = new Vector3(IOBBECBINCC.transform.localPosition.x, 1992f + OLPJHDJPNBG.relativeSize.x * OLPJHDJPNBG.transform.localScale.x + 590f, IOBBECBINCC.transform.localPosition.z);
		for (int i = 1; i < GNCFLIGPDDE.Count; i++)
		{
			GNCFLIGPDDE[i].gameObject.SetActive(i < FPCCEPIAEKG);
		}
	}
}
