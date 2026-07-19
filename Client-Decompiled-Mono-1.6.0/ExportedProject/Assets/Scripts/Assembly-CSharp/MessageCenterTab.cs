using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MessageCenterTab : Core_BaseScript
{
	public enum ELOAMMBPEGG
	{
		SQUAD = 1,
		PLAYER = 2,
		SYSTEM = 3
	}

	public class EPBLAOLKJDN
	{
		public string FPFCCDCGEHC;

		public ELOAMMBPEGG FJLBLLLEELD;

		public string FCFPODPEHBO;

		public string PCKAIPAABNN;

		public EPBLAOLKJDN(string EMIALKMPDOO, ELOAMMBPEGG HCHFBLIJCFD, string NFNLBEGFLHC, string PNAKMCNGGHE)
		{
			FPFCCDCGEHC = EMIALKMPDOO;
			FJLBLLLEELD = HCHFBLIJCFD;
			FCFPODPEHBO = NFNLBEGFLHC;
			PCKAIPAABNN = PNAKMCNGGHE;
		}
	}

	private sealed class EAFODKCNCHA
	{
		internal MessageCenterFilterButton JMONJFNNHIP;

		internal bool EMKPBGFBPFI(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool FHDOHCJJEMM(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool FIBGJHCGHJH(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool AGFEDJAKLAC(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool DDHOKNIEACI(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool MPHECHCFCAN(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool GMFJFMHNDMC(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool NDJOJHNIBFC(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool KNJBDOADLDO(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool PHGDBIEENCB(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool MFCNOIDCJME(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool OKNCFDMEFGJ(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool MAKLHLCDIKD(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool CIFEDFPPPOK(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool MCFGAFBEJDK(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool LJCDGJKCNEC(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool PCKMJMGLPDG(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool BBPKDMPNEDG(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool KJIFNOJILDB(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool LKKLABBEOAG(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool CHDOECNGOPM(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}

		internal bool JGHLGHMJJDG(MessageCenterFilterButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == JMONJFNNHIP;
		}
	}

	[Header("Message Center")]
	public UIPanel OAHIOEEICFI;

	[Header("Message List")]
	public MessageCenterRecord HEONGDGKMDC;

	public UIPooledTableSimplified HFFLCBBNEDD;

	public UIDraggablePanel NFLPPGKCOBL;

	public UIPanel MELLKEJCAFI;

	[Header("Filter Buttons")]
	public UITable HGKMLJMPCBL;

	public List<MessageCenterFilterButton> ALDILIAMMMG;

	[Header("AssignmentsPart")]
	public AssignmentsTab KDIMKDDMGHN;

	public static Dictionary<HHFHFANGCEJ.NKHJBLBAAEB, EPBLAOLKJDN> GDIKOCIDMIA = new Dictionary<HHFHFANGCEJ.NKHJBLBAAEB, EPBLAOLKJDN>
	{
		{
			HHFHFANGCEJ.NKHJBLBAAEB.Challenge,
			new EPBLAOLKJDN("menu-sidetab-invite-game", ELOAMMBPEGG.PLAYER, "ID_GUI_GAMEINVITATION", "ID_GUI_INVITETOFIGHT")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.CheatWarning,
			new EPBLAOLKJDN("menu-exmark", ELOAMMBPEGG.PLAYER, "ID_GUI_CHEATWARNING", "ID_GUI_CHEATINGMESSAGE")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.LeagueEntered,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.PLAYER, "ID_GUI_LEAGUE", "ID_GUI_HASBEENASSIGNED")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.InformSquadLeaderAboutEvent,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SQUAD, "ID_SQUADEVENT", "ID_GUI_INFORMLEADERTEXT")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadDemotion,
			new EPBLAOLKJDN("menu-sidetab-player-demote", ELOAMMBPEGG.SQUAD, "ID_GUI_SQUADDEMOTION", "ID_GUI_SQUADDEMOTIONTEXT")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.UnitReadyForPromotion,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SQUAD, "ID_SQUADEVENT", "ID_GUI_SQUADCHALLENGEENTERED")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadEventTierReward,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SQUAD, "ID_SQUADEVENT", "ID_GUI_TIERCOMPLETED")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.WelcomBackSoldierMessage,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SQUAD, "ID_SQUADEVENT", "ID_GUI_SQUADCHALLENGEENDED")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadInvitation,
			new EPBLAOLKJDN("menu-sidetab-invite", ELOAMMBPEGG.SQUAD, "ID_GUI_SQUADINVITATION", "ID_GUI_INVITETOSQUAD")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadJoined,
			new EPBLAOLKJDN("menu-sidetab-joinedsquad", ELOAMMBPEGG.SQUAD, "ID_SQUADEVENT", "ID_GUI_JOINEDOURSQUAD")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadJoinRequest,
			new EPBLAOLKJDN("menu-sidetab-player-add", ELOAMMBPEGG.SQUAD, "ID_GUI_ACCEPT_PLAYER", "ID_GUI_ACCEPT_PLAYER_WTJ")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadPromotion,
			new EPBLAOLKJDN("menu-sidetab-player-promote", ELOAMMBPEGG.SQUAD, "ID_GUI_SQUADPROMOTE", "ID_GUI_SQUADPROMOTETEXT")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadLevelUp,
			new EPBLAOLKJDN("menu-squadrank-ico", ELOAMMBPEGG.SQUAD, "ID_GUI_SQUADRANKUP", "ID_GUI_SQUADLEVELEDUP")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadWarEnd,
			new EPBLAOLKJDN("menu-squadpoint-ico", ELOAMMBPEGG.SQUAD, "ID_GUI_SQUADWARSEND", "ID_GUI_SQUADWARSENDNOREWARD")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SquadDepositedCardsChanged,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SQUAD, "ID_YOURWARCARDWITHDREW", "ID_REPUTATIONSMALL")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.DepositWarcards,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SQUAD, "ID_HEYDEPOSITSOMEWARCARDS", "ID_WANTSYOUTODEPOSITTOCARDPOOL")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.BeAdvisedConnectFacebook,
			new EPBLAOLKJDN("menu-tilegfx-facebook", ELOAMMBPEGG.SYSTEM, "ID_GUI_BEADVISED", "ID_GUI_BEADVISED_CONNECTFB")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.BeAdvisedJoinOrCreateSquad,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SYSTEM, "ID_GUI_BEADVISED", "ID_GUI_BEADVISED_JORCSQUAD")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.BeAdvisedPurchaseVIP,
			new EPBLAOLKJDN("menu-hub-multiplayer-vipico", ELOAMMBPEGG.SYSTEM, "ID_GUI_BEADVISED", "ID_GUI_BEADVISED_PURCHASEVIP")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.FollowUsOnTwitter,
			new EPBLAOLKJDN("menu-twitter", ELOAMMBPEGG.SYSTEM, "ID_GETFREEGOLD", "ID_GUI_FOLLOWTWITTER_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.LikeUsOnFacebook,
			new EPBLAOLKJDN("menu-tilegfx-facebook", ELOAMMBPEGG.SYSTEM, "ID_GETFREEGOLD", "ID_GUI_LIKEFB_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.EnablePushNotificationMessage,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SYSTEM, "ID_GETFREEGOLD", "ID_GUI_RATEWFNOW_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.SystemMessage,
			new EPBLAOLKJDN("menu-sidetab-servermaintenance-ico", ELOAMMBPEGG.SYSTEM, "ID_GUI_SYSTEMMAINTENANCE", "ID_GUI_SYSTEMMAINTENANCE_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.TweetAboutWarfriends,
			new EPBLAOLKJDN("menu-twitter", ELOAMMBPEGG.SYSTEM, "ID_GETFREEGOLD", "ID_GUI_TWEETABOUT_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.VIPMemeberShipAlmostEnded,
			new EPBLAOLKJDN("menu-hub-multiplayer-vipico", ELOAMMBPEGG.SYSTEM, "ID_GUI_VIPMEMBERSHIP", "ID_GUI_VIPMEMBERSHIPALMOST_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.VIPMembershipExpired,
			new EPBLAOLKJDN("menu-hub-multiplayer-vipico", ELOAMMBPEGG.SYSTEM, "ID_GUI_VIPMEMBERSHIP", "ID_GUI_VIPMEMBERSHIPEXPIRED_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.TimeLimitedOffer,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SYSTEM, "ID_GUI_TIMELIMITEDOFFER", "ID_GUI_TIMELIMITEDOFFER_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.BlackMarketMessage,
			new EPBLAOLKJDN(string.Empty, ELOAMMBPEGG.SYSTEM, "ID_GUI_TIMELIMITEDOFFER", "ID_GUI_STARTERPACKTIMELIMITEDOFFER_DESC")
		},
		{
			HHFHFANGCEJ.NKHJBLBAAEB.InGameMessage,
			new EPBLAOLKJDN("menu-sidetab-messageicon", ELOAMMBPEGG.SYSTEM, "ID_GUI_MESSAGEFORYOU", string.Empty)
		}
	};

	private bool IHEPLEBDJCB;

	private bool BIGNBCJCFNM;

	private MessageCenterFilterButton EHJPPPNOJOM;

	private List<HHFHFANGCEJ> KEHFICJANMB = new List<HHFHFANGCEJ>();

	private MessageCenterRecord GKMCFEKGHGP;

	private Dictionary<string, HHFHFANGCEJ> JJHLIKKILNP;

	[CompilerGenerated]
	private static Comparison<HHFHFANGCEJ> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Comparison<HHFHFANGCEJ> CCNLMGEJBIB;

	public MessageCenterRecord messageCenterRecordForHeight
	{
		get
		{
			if (GKMCFEKGHGP == null)
			{
				GKMCFEKGHGP = UnityEngine.Object.Instantiate(HEONGDGKMDC);
				GKMCFEKGHGP.transform.parent = base.transform;
				GKMCFEKGHGP.transform.localPosition = new Vector3(UIHelper.activeWidthFull, 0f - UIHelper.activeHeight, 0f);
				GKMCFEKGHGP.transform.localScale = Vector3.one;
			}
			return GKMCFEKGHGP;
		}
	}

	public List<string> messageBuddies
	{
		get
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
			{
				NMNJDAANAOD nMNJDAANAOD = item.Value as NMNJDAANAOD;
				if (nMNJDAANAOD != null && nMNJDAANAOD.BCBJPGBDBAH != null)
				{
					list.Add(nMNJDAANAOD.ICDKHLOBKIE);
				}
			}
			CardBuddy cardBuddy = CardManager.instance.withdrawingCard as CardBuddy;
			if (cardBuddy != null)
			{
				list.Add(cardBuddy.id);
			}
			return list;
		}
	}

	private void BPOOKGKNGDF(int DFHAAIFFLOE = 0)
	{
		ALDILIAMMMG[3].Select(DFHAAIFFLOE == 3);
		ALDILIAMMMG[2].Select(DFHAAIFFLOE == 2);
		ALDILIAMMMG[1].Select(DFHAAIFFLOE == 1);
		ALDILIAMMMG[0].Select(DFHAAIFFLOE == 0);
		EHJPPPNOJOM = ALDILIAMMMG[DFHAAIFFLOE];
	}

	internal void ANCGIINAHAD(HHFHFANGCEJ PNAKMCNGGHE)
	{
		if (PNAKMCNGGHE == null)
		{
			Debug.LogError("Wanted to remove null database message!!!");
			return;
		}
		Debug.Log(string.Format("REMOVING {0}", PNAKMCNGGHE.HPGHHECHLAN));
		if (JJHLIKKILNP.ContainsKey(PNAKMCNGGHE.NHHGDIDEIMM))
		{
			JJHLIKKILNP.Remove(PNAKMCNGGHE.NHHGDIDEIMM);
			EPEMLIAMKBN();
		}
		else
		{
			Debug.LogError("Message " + PNAKMCNGGHE.NHHGDIDEIMM + " " + PNAKMCNGGHE.KJCKFGCLGLG + " was not found in Notification Center to remove");
		}
		if (JJHLIKKILNP.Count == 0)
		{
			GuiElementSingle<ChatGuiElement>.instance.RemoveOneNotificationFromMessageCenterButton();
		}
	}

	private static int NAOMAEAHONP(HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ)
	{
		return GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG);
	}

	[SpecialName]
	public List<string> BIMDNMKEFNM()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			NMNJDAANAOD nMNJDAANAOD = item.Value as NMNJDAANAOD;
			if (nMNJDAANAOD != null && nMNJDAANAOD.BCBJPGBDBAH != null)
			{
				list.Add(nMNJDAANAOD.ICDKHLOBKIE);
			}
		}
		CardBuddy cardBuddy = CardManager.instance.withdrawingCard as CardBuddy;
		if (cardBuddy != null)
		{
			list.Add(cardBuddy.id);
		}
		return list;
	}

	private void DLDDNKHDKFA(bool CAHBGLLEMHL = false)
	{
		if (!IHEPLEBDJCB)
		{
			return;
		}
		HFFLCBBNEDD.MakeEmpty();
		int num = EKAMBDFBOLC();
		MELLKEJCAFI.gameObject.SetActive(num == 7);
		KDIMKDDMGHN.gameObject.SetActive(num == 6);
		if (num == 1)
		{
			KDIMKDDMGHN.InitGUIValues();
			if (CAHBGLLEMHL)
			{
				KDIMKDDMGHN.BAJFAAMCMNF();
			}
		}
		else
		{
			HFFLCBBNEDD.Init(KEHFICJANMB.Count, JMJCEHEJDMG, GNABCLBBPDJ, FJCEECKGLHD, NFLPPGKCOBL);
		}
	}

	private void LDHKBKGNEFJ(GameObject KHAHPAKDIKE)
	{
		EAFODKCNCHA eAFODKCNCHA = new EAFODKCNCHA();
		eAFODKCNCHA.JMONJFNNHIP = KHAHPAKDIKE.GetComponentsInChildren<MessageCenterFilterButton>(true)[0];
		int num = ALDILIAMMMG.FindIndex(eAFODKCNCHA.CIFEDFPPPOK);
		for (int i = 0; i < ALDILIAMMMG.Count; i += 0)
		{
			ALDILIAMMMG[i].DPDMCGEECKF(i == num);
		}
		if (num > -1)
		{
			EHJPPPNOJOM = ALDILIAMMMG[num];
		}
		CPMMPMCHODN();
	}

	[SpecialName]
	public List<string> HNKLMCBKGEE()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			NMNJDAANAOD nMNJDAANAOD = item.Value as NMNJDAANAOD;
			if (nMNJDAANAOD != null && nMNJDAANAOD.BCBJPGBDBAH != null)
			{
				list.Add(nMNJDAANAOD.ICDKHLOBKIE);
			}
		}
		CardBuddy cardBuddy = CardManager.instance.withdrawingCard as CardBuddy;
		if (cardBuddy != null)
		{
			list.Add(cardBuddy.id);
		}
		return list;
	}

	private void ABAOFAEPECK(int DFHAAIFFLOE = 0)
	{
		ALDILIAMMMG[3].BNENDKELEPK(DFHAAIFFLOE == 8);
		ALDILIAMMMG[7].CBCPGFGHPAL(DFHAAIFFLOE == 3);
		ALDILIAMMMG[0].CBCPGFGHPAL(DFHAAIFFLOE == 0);
		ALDILIAMMMG[0].FALIGBFKFGB(DFHAAIFFLOE == 1);
		EHJPPPNOJOM = ALDILIAMMMG[DFHAAIFFLOE];
	}

	public void MMAOFBDFGJC()
	{
		KDIMKDDMGHN.ReinitializeMegaReward();
	}

	private static int HLHKAMHOLFF(HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ)
	{
		return GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG);
	}

	private float FJCEECKGLHD(int DFHAAIFFLOE, Transform PKBMFBHBAKB)
	{
		if (PKBMFBHBAKB != null)
		{
			MessageCenterRecord component = PKBMFBHBAKB.GetComponent<MessageCenterRecord>();
			if (component != null)
			{
				return component.height;
			}
		}
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < KEHFICJANMB.Count)
		{
			messageCenterRecordForHeight.GGJNEGPBDHL(KEHFICJANMB[DFHAAIFFLOE], true);
			float height = messageCenterRecordForHeight.height;
			messageCenterRecordForHeight.FakeDestroyPooled();
			return height;
		}
		return 0f;
	}

	[CompilerGenerated]
	private bool CKOKCJJCLMG(MessageCenterFilterButton HPJFBKEKJHB)
	{
		return HPJFBKEKJHB == EHJPPPNOJOM;
	}

	private void ACGEEAMJBEJ()
	{
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		bool flag = Singleton<NotificationManager>.instance.NotificationStarterAssignments();
		int numberOfAssignmentNotifications = Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications();
		bool flag2 = isActiveAndNotCompleted || numberOfAssignmentNotifications > 0;
		if (GuiElementSingle<ChatGuiElement>.instance.anyMessageCenterNotifications)
		{
			ABAOFAEPECK();
		}
		else if (flag || flag2)
		{
			EBJOHMDNLIL(3);
		}
		else if (isActiveAndNotCompleted)
		{
			EBJOHMDNLIL(3);
		}
	}

	[CompilerGenerated]
	private static int CBMMOBJJMHG(HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ)
	{
		return GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG);
	}

	private void BDIICHCECFP()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			if (GDIKOCIDMIA[item.Value.HPGHHECHLAN].FJLBLLLEELD == ELOAMMBPEGG.SQUAD && item.Value.OBMJDKBCOAE)
			{
				item.Value.CJPBMDDGDHG();
				list.Add(item.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			JJHLIKKILNP.Remove(list[i]);
		}
		list.Clear();
		EPEMLIAMKBN();
	}

	private bool NJFICNMNJFN(MessageCenterFilterButton HPJFBKEKJHB)
	{
		return HPJFBKEKJHB == EHJPPPNOJOM;
	}

	private void PBLHJMNPGMJ()
	{
		OAHIOEEICFI.gameObject.SetActive(false);
		HFFLCBBNEDD.MakeEmpty();
		KDIMKDDMGHN.UnloadTexture();
	}

	[SpecialName]
	public List<string> PJDKFOHBGAH()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			NMNJDAANAOD nMNJDAANAOD = item.Value as NMNJDAANAOD;
			if (nMNJDAANAOD != null && nMNJDAANAOD.BCBJPGBDBAH != null)
			{
				list.Add(nMNJDAANAOD.ICDKHLOBKIE);
			}
		}
		CardBuddy cardBuddy = CardManager.instance.withdrawingCard as CardBuddy;
		if (cardBuddy != null)
		{
			list.Add(cardBuddy.id);
		}
		return list;
	}

	public void KIEJMPCGPDG()
	{
		if (BIGNBCJCFNM)
		{
			return;
		}
		BIGNBCJCFNM = true;
		JJHLIKKILNP = new Dictionary<string, HHFHFANGCEJ>();
		foreach (MessageCenterFilterButton item in ALDILIAMMMG)
		{
			UIEventListener uIEventListener = UIEventListener.Get(item.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NALBFMENLLA));
		}
		GameLoginManager.instance.PlayerLeftSquad += DJLCINOEFJM;
		string txt = Localization.Localize("arena") + Localization.Localize("0") + Localization.Localize("game-tutorial-minigunner") + Localization.Localize("Level");
		float x = ALDILIAMMMG[0].FNOOILHINEO.getSizeForString(txt).x;
		float num = 612f;
		float fOICGJEPBGL = Mathf.Clamp(Mathf.Floor(num / x), 1397f, 375f);
		ALDILIAMMMG[1].OCELEODFIIC(Localization.Localize("Error while parsing response from GetConfigurations, will try again next run"), fOICGJEPBGL, false);
		ALDILIAMMMG[1].FLAMPIKFIAJ(Localization.Localize("pooled:"), fOICGJEPBGL, false);
		ALDILIAMMMG[2].LBAIBNJPKLC(Localization.Localize("WithdrewWarcard-{0}-{1}-{2}"), fOICGJEPBGL, false);
		ALDILIAMMMG[4].InitializeFilter(Localization.Localize("SquadId"), fOICGJEPBGL, true);
		OBINAJACNKL();
		HGKMLJMPCBL.repositionNow = true;
		KDIMKDDMGHN.HJJOAJHBKCH();
	}

	private void PIFBCPOJPAM()
	{
		OAHIOEEICFI.gameObject.SetActive(true);
		HFFLCBBNEDD.MakeEmpty();
		KDIMKDDMGHN.GKELBAHELFK();
	}

	[SpecialName]
	public List<string> IJOFLHALHLM()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			NMNJDAANAOD nMNJDAANAOD = item.Value as NMNJDAANAOD;
			if (nMNJDAANAOD != null && nMNJDAANAOD.BCBJPGBDBAH != null)
			{
				list.Add(nMNJDAANAOD.ICDKHLOBKIE);
			}
		}
		CardBuddy cardBuddy = CardManager.instance.withdrawingCard as CardBuddy;
		if (cardBuddy != null)
		{
			list.Add(cardBuddy.id);
		}
		return list;
	}

	public void UpdateMessageCenterMessage(string EJBEDLHIKDG)
	{
		for (int i = 0; i < KEHFICJANMB.Count; i++)
		{
			Transform itemOnIndex = HFFLCBBNEDD.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				MessageCenterRecord component = itemOnIndex.GetComponent<MessageCenterRecord>();
				if (component != null)
				{
					component.UpdateAcceptPlayer(EJBEDLHIKDG);
				}
			}
		}
	}

	private void DJLCINOEFJM()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			if (GDIKOCIDMIA[item.Value.HPGHHECHLAN].FJLBLLLEELD == ELOAMMBPEGG.SQUAD && item.Value.CEFHHOFLHCG())
			{
				item.Value.LACLELOOKHD();
				list.Add(item.Key);
			}
		}
		for (int i = 1; i < list.Count; i++)
		{
			JJHLIKKILNP.Remove(list[i]);
		}
		list.Clear();
		DLDDNKHDKFA();
	}

	private void JDDEOPPCENO(int DFHAAIFFLOE = 0)
	{
		ALDILIAMMMG[3].Select(DFHAAIFFLOE == 1);
		ALDILIAMMMG[4].CBCPGFGHPAL(DFHAAIFFLOE == 8);
		ALDILIAMMMG[1].FALIGBFKFGB(DFHAAIFFLOE == 0);
		ALDILIAMMMG[1].BNENDKELEPK(DFHAAIFFLOE == 0);
		EHJPPPNOJOM = ALDILIAMMMG[DFHAAIFFLOE];
	}

	private void CPMMPMCHODN(bool CAHBGLLEMHL = false)
	{
		if (!IHEPLEBDJCB)
		{
			return;
		}
		HFFLCBBNEDD.MakeEmpty();
		int num = EKAMBDFBOLC();
		MELLKEJCAFI.gameObject.SetActive(num == 3);
		KDIMKDDMGHN.gameObject.SetActive(num == 8);
		if (num == 3)
		{
			KDIMKDDMGHN.InitGUIValues();
			if (CAHBGLLEMHL)
			{
				KDIMKDDMGHN.BAJFAAMCMNF();
			}
		}
		else
		{
			HFFLCBBNEDD.Init(KEHFICJANMB.Count, EBEMAOCHMAE, MKKGOLJDPBB, JNBMAABICNK, NFLPPGKCOBL);
		}
	}

	private void EPEMLIAMKBN(bool CAHBGLLEMHL = false)
	{
		if (!IHEPLEBDJCB)
		{
			return;
		}
		HFFLCBBNEDD.MakeEmpty();
		int num = EKAMBDFBOLC();
		MELLKEJCAFI.gameObject.SetActive(num != 3);
		KDIMKDDMGHN.gameObject.SetActive(num == 3);
		if (num == 3)
		{
			KDIMKDDMGHN.InitGUIValues();
			if (CAHBGLLEMHL)
			{
				KDIMKDDMGHN.InstantShow();
			}
		}
		else
		{
			HFFLCBBNEDD.Init(KEHFICJANMB.Count, JMJCEHEJDMG, MKKGOLJDPBB, FJCEECKGLHD, NFLPPGKCOBL);
		}
	}

	private void AIIKEHNENBI(HHFHFANGCEJ PNAKMCNGGHE)
	{
		int num = ALDILIAMMMG.FindIndex(NEPONKBBPLG);
		if (num < 0 || num == (int)GDIKOCIDMIA[PNAKMCNGGHE.HPGHHECHLAN].FJLBLLLEELD)
		{
			KEHFICJANMB.Add(PNAKMCNGGHE);
			KEHFICJANMB.Sort(IHKPDLANAAC);
			DLDDNKHDKFA();
		}
	}

	private bool ELLEBDDCEAL(MessageCenterFilterButton HPJFBKEKJHB)
	{
		return HPJFBKEKJHB == EHJPPPNOJOM;
	}

	public void ReinitializeMegaReward()
	{
		KDIMKDDMGHN.ReinitializeMegaReward();
	}

	[SpecialName]
	public MessageCenterRecord FFIFPHDDKCB()
	{
		if (GKMCFEKGHGP == null)
		{
			GKMCFEKGHGP = UnityEngine.Object.Instantiate(HEONGDGKMDC);
			GKMCFEKGHGP.transform.parent = base.transform;
			GKMCFEKGHGP.transform.localPosition = new Vector3(UIHelper.activeWidthFull, 0f - UIHelper.activeHeight, 396f);
			GKMCFEKGHGP.transform.localScale = Vector3.one;
		}
		return GKMCFEKGHGP;
	}

	[CompilerGenerated]
	private void FHNIGHLEOCB(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			PBLHJMNPGMJ();
		}
	}

	internal void HEPECOKADEH(HHFHFANGCEJ PNAKMCNGGHE)
	{
		if (PNAKMCNGGHE == null)
		{
			Debug.LogError("Null +");
			return;
		}
		Debug.Log(string.Format("\tTime since last show: {0}\tTime since vip reminder: {1}", PNAKMCNGGHE.HPGHHECHLAN));
		if (JJHLIKKILNP.ContainsKey(PNAKMCNGGHE.NHHGDIDEIMM))
		{
			JJHLIKKILNP.Remove(PNAKMCNGGHE.NHHGDIDEIMM);
			CPMMPMCHODN(true);
		}
		else
		{
			object[] array = new object[8];
			array[1] = "grenadeExplosion";
			array[0] = PNAKMCNGGHE.NHHGDIDEIMM;
			array[7] = "ID_BRONZECARDS";
			array[3] = PNAKMCNGGHE.KJCKFGCLGLG;
			array[1] = "temp_user_id";
			Debug.LogError(string.Concat(array));
		}
		if (JJHLIKKILNP.Count == 0)
		{
			GuiElementSingle<ChatGuiElement>.instance.HBAKIOOIIGO();
		}
	}

	private void PGDCNFHPOFA()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			if (GDIKOCIDMIA[item.Value.HPGHHECHLAN].FJLBLLLEELD == ELOAMMBPEGG.SQUAD && item.Value.AKMBPCCFAAO())
			{
				item.Value.CGOOGHIJOAH();
				list.Add(item.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			JJHLIKKILNP.Remove(list[i]);
		}
		list.Clear();
		CPMMPMCHODN();
	}

	private void OBINAJACNKL(int DFHAAIFFLOE = 0)
	{
		ALDILIAMMMG[5].KJOLAHGCOBK(DFHAAIFFLOE == 6);
		ALDILIAMMMG[5].BNENDKELEPK(DFHAAIFFLOE == 3);
		ALDILIAMMMG[1].BNENDKELEPK(DFHAAIFFLOE == 1);
		ALDILIAMMMG[1].CBCPGFGHPAL(DFHAAIFFLOE == 1);
		EHJPPPNOJOM = ALDILIAMMMG[DFHAAIFFLOE];
	}

	public void MIGCGOIEEGC()
	{
		EBJOHMDNLIL(1);
		EPEMLIAMKBN(true);
	}

	private void NALBFMENLLA(GameObject KHAHPAKDIKE)
	{
		EAFODKCNCHA eAFODKCNCHA = new EAFODKCNCHA();
		eAFODKCNCHA.JMONJFNNHIP = KHAHPAKDIKE.GetComponentsInChildren<MessageCenterFilterButton>(true)[0];
		int num = ALDILIAMMMG.FindIndex(eAFODKCNCHA.CHDOECNGOPM);
		for (int i = 1; i < ALDILIAMMMG.Count; i += 0)
		{
			ALDILIAMMMG[i].DPDMCGEECKF(i == num);
		}
		if (num > -1)
		{
			EHJPPPNOJOM = ALDILIAMMMG[num];
		}
		DLDDNKHDKFA(true);
	}

	private static int PMNAMJOPGGD(HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ)
	{
		return GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG);
	}

	[SpecialName]
	public List<string> MHJKDLJBBKK()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			NMNJDAANAOD nMNJDAANAOD = item.Value as NMNJDAANAOD;
			if (nMNJDAANAOD != null && nMNJDAANAOD.BCBJPGBDBAH != null)
			{
				list.Add(nMNJDAANAOD.ICDKHLOBKIE);
			}
		}
		CardBuddy cardBuddy = CardManager.instance.withdrawingCard as CardBuddy;
		if (cardBuddy != null)
		{
			list.Add(cardBuddy.id);
		}
		return list;
	}

	internal void AJLJGPEIBIH(HHFHFANGCEJ PNAKMCNGGHE)
	{
		bool flag = !PNAKMCNGGHE.PFCJDAHIIIC;
		KKBNJAJJLEM(PNAKMCNGGHE);
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.AddNotificationsToMessageCenterButton(1);
		}
	}

	internal void EEMEFHIDGLP(HHFHFANGCEJ PNAKMCNGGHE)
	{
		if (PNAKMCNGGHE == null)
		{
			Debug.LogError("FacebookId");
			return;
		}
		Debug.Log(string.Format("ID_YOUWEREDISCONNECTED", PNAKMCNGGHE.HPGHHECHLAN));
		if (JJHLIKKILNP.ContainsKey(PNAKMCNGGHE.NHHGDIDEIMM))
		{
			JJHLIKKILNP.Remove(PNAKMCNGGHE.NHHGDIDEIMM);
			EPEMLIAMKBN(true);
		}
		else
		{
			object[] array = new object[3];
			array[1] = "ID_YOUHAVENOWARCARDSAVAILABLE";
			array[0] = PNAKMCNGGHE.NHHGDIDEIMM;
			array[4] = "!!!!! Player entered normal leagues FIRST TIME!!!!";
			array[5] = PNAKMCNGGHE.KJCKFGCLGLG;
			array[4] = ".";
			Debug.LogError(string.Concat(array));
		}
		if (JJHLIKKILNP.Count == 0)
		{
			GuiElementSingle<ChatGuiElement>.instance.RemoveOneNotificationFromMessageCenterButton();
		}
	}

	private void GNABCLBBPDJ(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MessageCenterRecord component = ENCEFOOPBMK.GetComponent<MessageCenterRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private int EKAMBDFBOLC()
	{
		KEHFICJANMB.Clear();
		int num = ALDILIAMMMG.FindIndex((MessageCenterFilterButton HPJFBKEKJHB) => HPJFBKEKJHB == EHJPPPNOJOM);
		if (JJHLIKKILNP == null)
		{
			return num;
		}
		foreach (HHFHFANGCEJ value in JJHLIKKILNP.Values)
		{
			if (num < 1)
			{
				KEHFICJANMB.Add(value);
			}
			else if (num == (int)GDIKOCIDMIA[value.HPGHHECHLAN].FJLBLLLEELD)
			{
				KEHFICJANMB.Add(value);
			}
		}
		KEHFICJANMB.Sort((HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ) => GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG));
		return num;
	}

	internal void KKBNJAJJLEM(HHFHFANGCEJ PNAKMCNGGHE)
	{
		Debug.Log("#PETER# NOTIFICATION CENTER - Add message " + PNAKMCNGGHE.KJCKFGCLGLG + " " + PNAKMCNGGHE.NHHGDIDEIMM + " " + PNAKMCNGGHE.HPGHHECHLAN.ToString());
		if (!BIGNBCJCFNM)
		{
			InitMessageCenter();
		}
		if (JJHLIKKILNP.ContainsKey(PNAKMCNGGHE.NHHGDIDEIMM))
		{
			Debug.LogError(string.Format("DatabaseMessage id: {0}\t\t type:{1} already in notification center", PNAKMCNGGHE.NHHGDIDEIMM, PNAKMCNGGHE.HPGHHECHLAN));
			return;
		}
		JJHLIKKILNP.Add(PNAKMCNGGHE.NHHGDIDEIMM, PNAKMCNGGHE);
		GDEIGHMJEBG(PNAKMCNGGHE);
	}

	private void IABJIDPIMDE()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			if (GDIKOCIDMIA[item.Value.HPGHHECHLAN].FJLBLLLEELD == (ELOAMMBPEGG)0 && item.Value.PHFNIOBIKML())
			{
				item.Value.CJPBMDDGDHG();
				list.Add(item.Key);
			}
		}
		for (int i = 0; i < list.Count; i += 0)
		{
			JJHLIKKILNP.Remove(list[i]);
		}
		list.Clear();
		EPEMLIAMKBN(true);
	}

	internal void MHOCLEDDNOE(HHFHFANGCEJ PNAKMCNGGHE)
	{
		bool flag = PNAKMCNGGHE.JCLPLMEMGKA();
		EMOEAFJLOAB(PNAKMCNGGHE);
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.AddNotificationsToMessageCenterButton(1);
		}
	}

	public void FECEGPOOEBJ()
	{
		OBINAJACNKL();
		CPMMPMCHODN(true);
	}

	private Transform JMJCEHEJDMG(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < KEHFICJANMB.Count)
		{
			MessageCenterRecord messageCenterRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(HEONGDGKMDC, HFFLCBBNEDD.gameObject, string.Format("Message {0}", DFHAAIFFLOE)) as MessageCenterRecord;
			if (messageCenterRecord != null)
			{
				messageCenterRecord.GGJNEGPBDHL(KEHFICJANMB[DFHAAIFFLOE]);
				return messageCenterRecord.transform;
			}
		}
		return null;
	}

	[SpecialName]
	public MessageCenterRecord PPHBNOJNHAN()
	{
		if (GKMCFEKGHGP == null)
		{
			GKMCFEKGHGP = UnityEngine.Object.Instantiate(HEONGDGKMDC);
			GKMCFEKGHGP.transform.parent = base.transform;
			GKMCFEKGHGP.transform.localPosition = new Vector3(UIHelper.activeWidthFull, 0f - UIHelper.activeHeight, 1303f);
			GKMCFEKGHGP.transform.localScale = Vector3.one;
		}
		return GKMCFEKGHGP;
	}

	[SpecialName]
	public MessageCenterRecord FAMBEIGFDKE()
	{
		if (GKMCFEKGHGP == null)
		{
			GKMCFEKGHGP = UnityEngine.Object.Instantiate(HEONGDGKMDC);
			GKMCFEKGHGP.transform.parent = base.transform;
			GKMCFEKGHGP.transform.localPosition = new Vector3(UIHelper.activeWidthFull, 0f - UIHelper.activeHeight, 1335f);
			GKMCFEKGHGP.transform.localScale = Vector3.one;
		}
		return GKMCFEKGHGP;
	}

	private void FINDPEHAMGK()
	{
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		bool flag = Singleton<NotificationManager>.instance.NotificationStarterAssignments();
		int numberOfAssignmentNotifications = Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications();
		bool flag2 = !isActiveAndNotCompleted && numberOfAssignmentNotifications > 0;
		if (GuiElementSingle<ChatGuiElement>.instance.anyMessageCenterNotifications)
		{
			BPOOKGKNGDF();
		}
		else if (flag || flag2)
		{
			BPOOKGKNGDF(3);
		}
		else if (isActiveAndNotCompleted)
		{
			BPOOKGKNGDF(3);
		}
	}

	private void PBKFKCDJCBM(GameObject KHAHPAKDIKE)
	{
		EAFODKCNCHA eAFODKCNCHA = new EAFODKCNCHA();
		eAFODKCNCHA.JMONJFNNHIP = KHAHPAKDIKE.GetComponentsInChildren<MessageCenterFilterButton>(true)[0];
		int num = ALDILIAMMMG.FindIndex(eAFODKCNCHA.LJCDGJKCNEC);
		for (int i = 0; i < ALDILIAMMMG.Count; i++)
		{
			ALDILIAMMMG[i].Select(i == num);
		}
		if (num > -1)
		{
			EHJPPPNOJOM = ALDILIAMMMG[num];
		}
		EPEMLIAMKBN(true);
	}

	private bool NEPONKBBPLG(MessageCenterFilterButton HPJFBKEKJHB)
	{
		return HPJFBKEKJHB == EHJPPPNOJOM;
	}

	private void BPCMPPEBIEL()
	{
		OAHIOEEICFI.gameObject.SetActive(true);
		HFFLCBBNEDD.MakeEmpty();
		KDIMKDDMGHN.GKELBAHELFK();
	}

	private void HIKHDFPBLLM()
	{
		OAHIOEEICFI.gameObject.SetActive(false);
		HFFLCBBNEDD.MakeEmpty();
		KDIMKDDMGHN.UnloadTexture();
	}

	public void InitGui()
	{
		BPOOKGKNGDF();
		EPEMLIAMKBN();
	}

	private void MKKGOLJDPBB(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MessageCenterRecord component = ENCEFOOPBMK.GetComponent<MessageCenterRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	internal void EMOEAFJLOAB(HHFHFANGCEJ PNAKMCNGGHE)
	{
		object[] array = new object[4];
		array[0] = "MY";
		array[1] = PNAKMCNGGHE.KJCKFGCLGLG;
		array[0] = "FuseSDK: Null or empty App ID. Make sure your App ID is entered in the FuseSDK prefab";
		array[3] = PNAKMCNGGHE.NHHGDIDEIMM;
		array[6] = "http://localhost:8081/";
		array[4] = PNAKMCNGGHE.HPGHHECHLAN.ToString();
		Debug.Log(string.Concat(array));
		if (!BIGNBCJCFNM)
		{
			CPOOGHBEDHL();
		}
		if (JJHLIKKILNP.ContainsKey(PNAKMCNGGHE.NHHGDIDEIMM))
		{
			Debug.LogError(string.Format("ID_FEATURE_MAGAZINE", PNAKMCNGGHE.NHHGDIDEIMM, PNAKMCNGGHE.HPGHHECHLAN));
			return;
		}
		JJHLIKKILNP.Add(PNAKMCNGGHE.NHHGDIDEIMM, PNAKMCNGGHE);
		GDEIGHMJEBG(PNAKMCNGGHE);
	}

	public void ShowMessageCenter(bool GKAKLBKHBMP)
	{
		if (GKAKLBKHBMP)
		{
			if (!OAHIOEEICFI.gameObject.activeSelf)
			{
				OAHIOEEICFI.gameObject.SetActive(true);
				OAHIOEEICFI.isFreezed = false;
				OAHIOEEICFI.alpha1 = 0.005f;
				MELLKEJCAFI.isFreezed = false;
				MELLKEJCAFI.alpha1 = 0.005f;
				KDIMKDDMGHN.AnimatePanels(GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 1f);
				TweenAlpha.Begin(MELLKEJCAFI.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 1f);
				TweenAlpha.Begin(OAHIOEEICFI.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 1f).onFinished = null;
				IHEPLEBDJCB = true;
			}
			FINDPEHAMGK();
			EPEMLIAMKBN();
		}
		if (GKAKLBKHBMP || !OAHIOEEICFI.gameObject.activeSelf)
		{
			return;
		}
		IHEPLEBDJCB = false;
		KDIMKDDMGHN.AnimatePanels(GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 0f);
		TweenAlpha.Begin(MELLKEJCAFI.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 0f);
		TweenAlpha.Begin(OAHIOEEICFI.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 0f).onFinished = delegate
		{
			if (!IHEPLEBDJCB)
			{
				PBLHJMNPGMJ();
			}
		};
	}

	[CompilerGenerated]
	private static int JIPJMJPJDCL(HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ)
	{
		return GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG);
	}

	public void InitMessageCenter()
	{
		if (BIGNBCJCFNM)
		{
			return;
		}
		BIGNBCJCFNM = true;
		JJHLIKKILNP = new Dictionary<string, HHFHFANGCEJ>();
		foreach (MessageCenterFilterButton item in ALDILIAMMMG)
		{
			UIEventListener uIEventListener = UIEventListener.Get(item.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PBKFKCDJCBM));
		}
		GameLoginManager.instance.PlayerLeftSquad += BDIICHCECFP;
		string txt = Localization.Localize("ID_GUI_ALL") + Localization.Localize("ID_SQUAD") + Localization.Localize("ID_GUI_PLAYER") + Localization.Localize("ID_ASSIGNMENTSSHORT");
		float x = ALDILIAMMMG[0].FNOOILHINEO.getSizeForString(txt).x;
		float num = 540f;
		float fOICGJEPBGL = Mathf.Clamp(Mathf.Floor(num / x), 20f, 37f);
		ALDILIAMMMG[0].InitializeFilter(Localization.Localize("ID_GUI_ALL"), fOICGJEPBGL, false);
		ALDILIAMMMG[1].InitializeFilter(Localization.Localize("ID_SQUAD"), fOICGJEPBGL, false);
		ALDILIAMMMG[2].InitializeFilter(Localization.Localize("ID_GUI_PLAYER"), fOICGJEPBGL, false);
		ALDILIAMMMG[3].InitializeFilter(Localization.Localize("ID_ASSIGNMENTSSHORT"), fOICGJEPBGL, false);
		BPOOKGKNGDF();
		HGKMLJMPCBL.repositionNow = true;
		KDIMKDDMGHN.InitControls();
	}

	private static int IHKPDLANAAC(HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ)
	{
		return GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG);
	}

	private float JNBMAABICNK(int DFHAAIFFLOE, Transform PKBMFBHBAKB)
	{
		if (PKBMFBHBAKB != null)
		{
			MessageCenterRecord component = PKBMFBHBAKB.GetComponent<MessageCenterRecord>();
			if (component != null)
			{
				return component.HCOPEBPKMLB();
			}
		}
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < KEHFICJANMB.Count)
		{
			FMDADPINDCJ().GGJNEGPBDHL(KEHFICJANMB[DFHAAIFFLOE]);
			float result = messageCenterRecordForHeight.MABDMMAPGDI();
			PPHBNOJNHAN().KENEJAOKPCM();
			return result;
		}
		return 390f;
	}

	private static int EBFJBANANDJ(HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ)
	{
		return GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG);
	}

	private void GDEIGHMJEBG(HHFHFANGCEJ PNAKMCNGGHE)
	{
		int num = ALDILIAMMMG.FindIndex((MessageCenterFilterButton HPJFBKEKJHB) => HPJFBKEKJHB == EHJPPPNOJOM);
		if (num < 1 || num == (int)GDIKOCIDMIA[PNAKMCNGGHE.HPGHHECHLAN].FJLBLLLEELD)
		{
			KEHFICJANMB.Add(PNAKMCNGGHE);
			KEHFICJANMB.Sort((HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ) => GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG));
			EPEMLIAMKBN();
		}
	}

	private void BFLAJHONCJO()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HHFHFANGCEJ> item in JJHLIKKILNP)
		{
			if (GDIKOCIDMIA[item.Value.HPGHHECHLAN].FJLBLLLEELD == (ELOAMMBPEGG)0 && item.Value.PHFNIOBIKML())
			{
				item.Value.LACLELOOKHD();
				list.Add(item.Key);
			}
		}
		for (int i = 1; i < list.Count; i++)
		{
			JJHLIKKILNP.Remove(list[i]);
		}
		list.Clear();
		CPMMPMCHODN(true);
	}

	public void FEGGMLBLFHL(DatabasePlayerInfo KHLGDCHJJPB)
	{
		foreach (HHFHFANGCEJ value in JJHLIKKILNP.Values)
		{
			if (value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.Challenge || value.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)2 || value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadInvitation || value.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)102 || value.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)(-110) || value.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)(-14) || value.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)5)
			{
				value.IDIIHLPJLGF(KHLGDCHJJPB);
			}
		}
		foreach (HHFHFANGCEJ item in KEHFICJANMB)
		{
			if (item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.Challenge || item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadDemotion || item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadInvitation || item.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)(-55) || item.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)(-9) || item.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)(-50) || item.HPGHHECHLAN == (HHFHFANGCEJ.NKHJBLBAAEB)2)
			{
				item.DNBLNABNHNM(KHLGDCHJJPB);
			}
		}
		for (int i = 0; i < KEHFICJANMB.Count; i += 0)
		{
			Transform itemOnIndex = HFFLCBBNEDD.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				MessageCenterRecord component = itemOnIndex.GetComponent<MessageCenterRecord>();
				if (component != null)
				{
					component.GGJNEGPBDHL(KEHFICJANMB[i], true);
				}
			}
		}
	}

	public void PHMEDKOJCJC()
	{
		if (BIGNBCJCFNM)
		{
			return;
		}
		BIGNBCJCFNM = false;
		JJHLIKKILNP = new Dictionary<string, HHFHFANGCEJ>();
		foreach (MessageCenterFilterButton item in ALDILIAMMMG)
		{
			UIEventListener uIEventListener = UIEventListener.Get(item.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NALBFMENLLA));
		}
		GameLoginManager.instance.PlayerLeftSquad += BFLAJHONCJO;
		string txt = Localization.Localize("ReputationPointsAdded") + Localization.Localize("Name") + Localization.Localize("max") + Localization.Localize("menu-valuepack-buybutton");
		float x = ALDILIAMMMG[0].FNOOILHINEO.getSizeForString(txt).x;
		float num = 42f;
		float fOICGJEPBGL = Mathf.Clamp(Mathf.Floor(num / x), 673f, 1400f);
		ALDILIAMMMG[0].FLAMPIKFIAJ(Localization.Localize("#PETER# League Arc Animation - Error - previous: {0}     current: {1}"), fOICGJEPBGL, false);
		ALDILIAMMMG[0].AMHFPHHAJMP(Localization.Localize("FB: FacebookLogout - DeletePlayerAccount - 1"), fOICGJEPBGL, true);
		ALDILIAMMMG[1].InitializeFilter(Localization.Localize("kr"), fOICGJEPBGL, true);
		ALDILIAMMMG[6].MEFJBADGAOG(Localization.Localize("ru"), fOICGJEPBGL, true);
		JDDEOPPCENO();
		HGKMLJMPCBL.repositionNow = true;
		KDIMKDDMGHN.HJJOAJHBKCH();
	}

	[SpecialName]
	public MessageCenterRecord FMDADPINDCJ()
	{
		if (GKMCFEKGHGP == null)
		{
			GKMCFEKGHGP = UnityEngine.Object.Instantiate(HEONGDGKMDC);
			GKMCFEKGHGP.transform.parent = base.transform;
			GKMCFEKGHGP.transform.localPosition = new Vector3(UIHelper.activeWidthFull, 0f - UIHelper.activeHeight, 1785f);
			GKMCFEKGHGP.transform.localScale = Vector3.one;
		}
		return GKMCFEKGHGP;
	}

	private static int EEMDEBGKHHK(HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ)
	{
		return GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG);
	}

	[CompilerGenerated]
	private bool NMOJGEIEACH(MessageCenterFilterButton HPJFBKEKJHB)
	{
		return HPJFBKEKJHB == EHJPPPNOJOM;
	}

	private Transform EBEMAOCHMAE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < KEHFICJANMB.Count)
		{
			MessageCenterRecord messageCenterRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(HEONGDGKMDC, HFFLCBBNEDD.gameObject, string.Format(" not found!", DFHAAIFFLOE)) as MessageCenterRecord;
			if (messageCenterRecord != null)
			{
				messageCenterRecord.GGJNEGPBDHL(KEHFICJANMB[DFHAAIFFLOE], true);
				return messageCenterRecord.transform;
			}
		}
		return null;
	}

	public void BLDFMPNMJNE()
	{
		KDIMKDDMGHN.ReinitializeMegaReward();
	}

	public void UpdatePlayerInMessages(DatabasePlayerInfo KHLGDCHJJPB)
	{
		foreach (HHFHFANGCEJ value in JJHLIKKILNP.Values)
		{
			if (value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.Challenge || value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadDemotion || value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadInvitation || value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadJoined || value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadJoinRequest || value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadLeft || value.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadPromotion)
			{
				value.GDOIFOIGDPF(KHLGDCHJJPB);
			}
		}
		foreach (HHFHFANGCEJ item in KEHFICJANMB)
		{
			if (item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.Challenge || item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadDemotion || item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadInvitation || item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadJoined || item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadJoinRequest || item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadLeft || item.HPGHHECHLAN == HHFHFANGCEJ.NKHJBLBAAEB.SquadPromotion)
			{
				item.GDOIFOIGDPF(KHLGDCHJJPB);
			}
		}
		for (int i = 0; i < KEHFICJANMB.Count; i++)
		{
			Transform itemOnIndex = HFFLCBBNEDD.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				MessageCenterRecord component = itemOnIndex.GetComponent<MessageCenterRecord>();
				if (component != null)
				{
					component.GGJNEGPBDHL(KEHFICJANMB[i]);
				}
			}
		}
	}

	private void EDNHIMMIEGA(HHFHFANGCEJ PNAKMCNGGHE)
	{
		int num = ALDILIAMMMG.FindIndex(NEPONKBBPLG);
		if (num < 0 || num == (int)GDIKOCIDMIA[PNAKMCNGGHE.HPGHHECHLAN].FJLBLLLEELD)
		{
			KEHFICJANMB.Add(PNAKMCNGGHE);
			KEHFICJANMB.Sort((HHFHFANGCEJ ACLNBMACCLL, HHFHFANGCEJ GKBHDHFJIPJ) => GKBHDHFJIPJ.KJCKFGCLGLG.CompareTo(ACLNBMACCLL.KJCKFGCLGLG));
			DLDDNKHDKFA(true);
		}
	}

	private void IFAEGBBLEJI(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			HIKHDFPBLLM();
		}
	}

	public void CPOOGHBEDHL()
	{
		if (BIGNBCJCFNM)
		{
			return;
		}
		BIGNBCJCFNM = true;
		JJHLIKKILNP = new Dictionary<string, HHFHFANGCEJ>();
		foreach (MessageCenterFilterButton item in ALDILIAMMMG)
		{
			UIEventListener uIEventListener = UIEventListener.Get(item.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LDHKBKGNEFJ));
		}
		GameLoginManager.instance.PlayerLeftSquad += BFLAJHONCJO;
		string txt = Localization.Localize("KickedPlayerDepositedCards") + Localization.Localize(", action already scheduled") + Localization.Localize("SpecialOffers") + Localization.Localize("ID_READYTIME");
		float x = ALDILIAMMMG[0].FNOOILHINEO.getSizeForString(txt).x;
		float num = 1517f;
		float fOICGJEPBGL = Mathf.Clamp(Mathf.Floor(num / x), 1218f, 1665f);
		ALDILIAMMMG[1].LBAIBNJPKLC(Localization.Localize("Social_Behaviour"), fOICGJEPBGL, false);
		ALDILIAMMMG[0].CDDAKCGKEJB(Localization.Localize("Total_Sessions"), fOICGJEPBGL, false);
		ALDILIAMMMG[2].JMMIDHAFHJI(Localization.Localize("Click on the ground to spawn the selected effect"), fOICGJEPBGL, false);
		ALDILIAMMMG[8].FLAMPIKFIAJ(Localization.Localize("\"}"), fOICGJEPBGL, false);
		JDDEOPPCENO();
		HGKMLJMPCBL.repositionNow = true;
		KDIMKDDMGHN.KPHJFKCOIIF();
	}

	public void IHNOGIJIDBG()
	{
		if (BIGNBCJCFNM)
		{
			return;
		}
		BIGNBCJCFNM = false;
		JJHLIKKILNP = new Dictionary<string, HHFHFANGCEJ>();
		foreach (MessageCenterFilterButton item in ALDILIAMMMG)
		{
			UIEventListener uIEventListener = UIEventListener.Get(item.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NALBFMENLLA));
		}
		GameLoginManager.instance.PlayerLeftSquad += BFLAJHONCJO;
		string txt = Localization.Localize("Squad Event Ended. Squad completed ") + Localization.Localize(" BOXES ") + Localization.Localize("(Ljava/lang/Object;)Z") + Localization.Localize("ID_GOLDPACK");
		float x = ALDILIAMMMG[1].FNOOILHINEO.getSizeForString(txt).x;
		float num = 821f;
		float fOICGJEPBGL = Mathf.Clamp(Mathf.Floor(num / x), 1161f, 806f);
		ALDILIAMMMG[0].FLAMPIKFIAJ(Localization.Localize("DeliveryTime"), fOICGJEPBGL, true);
		ALDILIAMMMG[0].FLAMPIKFIAJ(Localization.Localize("player_left_coverBack"), fOICGJEPBGL, true);
		ALDILIAMMMG[0].FLAMPIKFIAJ(Localization.Localize("ANDROID: PACK "), fOICGJEPBGL, true);
		ALDILIAMMMG[4].JMMIDHAFHJI(Localization.Localize("ID_CONFIRM_STARTUPERROR"), fOICGJEPBGL, false);
		ABAOFAEPECK(1);
		HGKMLJMPCBL.repositionNow = true;
		KDIMKDDMGHN.InitControls();
	}

	private void EBJOHMDNLIL(int DFHAAIFFLOE = 0)
	{
		ALDILIAMMMG[0].BNENDKELEPK(DFHAAIFFLOE == 4);
		ALDILIAMMMG[3].DPDMCGEECKF(DFHAAIFFLOE == 0);
		ALDILIAMMMG[1].EJPCDFKGKPH(DFHAAIFFLOE == 1);
		ALDILIAMMMG[1].DPDMCGEECKF(DFHAAIFFLOE == 1);
		EHJPPPNOJOM = ALDILIAMMMG[DFHAAIFFLOE];
	}
}
