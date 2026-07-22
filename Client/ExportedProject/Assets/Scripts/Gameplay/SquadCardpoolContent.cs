using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadCardpoolContent : Core_BaseScript
{
	[FormerlySerializedAs("KMCGNICKPHL")]
	[Header("Core")]
	public UIPanel JAEJGOEPOKM;

	[FormerlySerializedAs("JLKKODDOHEF")]
	public GameObject LEIDAILJEGN;

	[FormerlySerializedAs("INPLBODFFAE")]
	public GameObject MBGGKACGDPA;

	[Header("Header")]
	[FormerlySerializedAs("LIONOKMPIGJ")]
	public GameObject FPLKJLJIJCE;

	[FormerlySerializedAs("IMAPELBLMMA")]
	public UITable JJEPOPCDAAP;

	[FormerlySerializedAs("NAFEHLAPHBC")]
	public UILabel DDMKCNOOCGL;

	[FormerlySerializedAs("BKBEELNJBLG")]
	public UITable MHPMOMADKDJ;

	[FormerlySerializedAs("PKOHEPHIIMD")]
	public UILabel ENHECADHEJM;

	[FormerlySerializedAs("FNEFCCDJFEE")]
	public UIPanel JOBNEIFNGJO;

	[FormerlySerializedAs("PJNPGACOLKI")]
	public WinStreakCounter IJIBLFFMKMJ;

	[FormerlySerializedAs("EHKJJOBAGIL")]
	public GameObject AFJIPAFJFJF;

	[FormerlySerializedAs("PMAEEIJCAIA")]
	[Header("List")]
	public UIPanel CFFKHHJKBMJ;

	[FormerlySerializedAs("ICKPAEEPOBH")]
	public UIDraggablePanel NFLPPGKCOBL;

	[FormerlySerializedAs("KBICFDLIFEJ")]
	public UIPooledGrid KJMFACNGKCE;

	[FormerlySerializedAs("AONFHIECADC")]
	public CardpoolRecord AFCEFKPJGDE;

	[FormerlySerializedAs("FELIFNDLKGH")]
	[Header("Waiting for server")]
	public UISprite NLAJOOOJNPL;

	private bool IHEPLEBDJCB;

	private List<DatabasePlayer> IOJCHMMEJKN = new List<DatabasePlayer>();

	private Dictionary<string, int> LFEGLEFNPJJ = new Dictionary<string, int>();

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> CCNLMGEJBIB;

	private void PPMCFMBJJHP()
	{
		KJMFACNGKCE.MakeEmpty();
		IJIBLFFMKMJ.JCMHGOGNMFO();
	}

	private void KOGKOMPPIDH(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			CardpoolRecord component = ENCEFOOPBMK.GetComponent<CardpoolRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (!GuiScreenSingle<SquadScreen>.instance.isShowed || !IHEPLEBDJCB)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.GetAllSquadMembers:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list == null)
			{
				list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			}
			if (list != null)
			{
				DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
				int num = list.FindIndex((DatabasePlayer NGKBOFPJNAG) => NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id);
				if (num > -1)
				{
					list[num].playerVisuals = generatedCurrentPlayer.playerVisuals;
					list[num].country = generatedCurrentPlayer.country;
					list[num].level = generatedCurrentPlayer.level;
					list[num].squadRank = generatedCurrentPlayer.squadRank;
					list[num].armyPower = generatedCurrentPlayer.armyPower;
					list[num].leagueTier = generatedCurrentPlayer.leagueTier;
					list[num].beginnersLeague = generatedCurrentPlayer.beginnersLeague;
					list[num].remainingMatches = generatedCurrentPlayer.remainingMatches;
					list[num].skill = generatedCurrentPlayer.skill;
					list[num].depositedCardsDic = generatedCurrentPlayer.depositedCardsDic;
					list[num].reputation = generatedCurrentPlayer.reputation;
				}
				else
				{
					list.Add(generatedCurrentPlayer);
				}
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					if (string.IsNullOrEmpty(list[num2].name))
					{
						list.RemoveAt(num2);
					}
				}
				list.Sort(NHBNNDKDGKM);
			}
			else
			{
				list = new List<DatabasePlayer>();
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			HACHCDIDAMG(list);
			break;
		}
		case DatabaseAction.GetSquadDetails:
			if (NLAJOOOJNPL.gameObject.activeSelf)
			{
				PMBPAOLBLFA();
			}
			break;
		}
	}

	public void OnWithdrawTimeChanged()
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && IHEPLEBDJCB)
		{
			HPLIAAANBJK();
		}
	}

	private void AOIJMHBDOMO()
	{
		int num = IOJCHMMEJKN.FindIndex((DatabasePlayer NGKBOFPJNAG) => NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id);
		int fFHHEHHFOKJ = ((num >= 0) ? IOJCHMMEJKN[num].reputation : 0);
		DDMKCNOOCGL.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
	}

	[CompilerGenerated]
	private static bool FHKAIOIGBFJ(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private void HPLIAAANBJK()
	{
		if (CardManager.instance.isWithdrawAvailable)
		{
			BBOHACILKPG();
		}
		else
		{
			MJOAHLPOAHN(CardManager.instance.nextWithdraw);
		}
	}

	private bool LNJJOMOIOIC(string INFLHPGMEOB)
	{
		if (LFEGLEFNPJJ.ContainsKey(INFLHPGMEOB))
		{
			return Singleton<BeanstalkServerManager>.instance.currentTimestamp > LFEGLEFNPJJ[INFLHPGMEOB];
		}
		return true;
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && IHEPLEBDJCB && (IFGAGNBDKBE == DatabaseAction.DepositCards || IFGAGNBDKBE == DatabaseAction.WithdrawCard))
		{
			Debug.LogError("Cardpool: Deposit or Withdraw Failed");
			PMBPAOLBLFA();
		}
	}

	public void Notified(string INFLHPGMEOB)
	{
		LFEGLEFNPJJ[INFLHPGMEOB] = Singleton<BeanstalkServerManager>.instance.currentTimestamp + 86400;
	}

	public void HKDCHMLHKEB(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && base.gameObject.activeSelf)
		{
			PMBPAOLBLFA();
		}
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(JAEJGOEPOKM.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 1730f) : 318f, (!IHEPLEBDJCB) ? 1351f : 1286f);
			TweenAlpha.Begin(JOBNEIFNGJO.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 855f) : 1246f, (!IHEPLEBDJCB) ? 298f : 1166f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 1049f) : 1210f, (!IHEPLEBDJCB) ? 516f : 1646f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					base.gameObject.SetActive(value: false);
					PPMCFMBJJHP();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	[CompilerGenerated]
	private void GNABEEFAGEG(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			PPMCFMBJJHP();
		}
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		float num = AFJIPAFJFJF.transform.localPosition.x - 2f * JJEPOPCDAAP.padding.x;
		JJEPOPCDAAP.transform.localPosition = JJEPOPCDAAP.transform.localPosition.ReplaceX(0f - num);
	}

	private void ICPPLLIADND(int KNGALBMMGNG)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		WinStreakCounter iJIBLFFMKMJ = IJIBLFFMKMJ;
		iJIBLFFMKMJ.JEMKCLKCOMI = (Action)Delegate.Remove(iJIBLFFMKMJ.JEMKCLKCOMI, new Action(HPLIAAANBJK));
		WinStreakCounter iJIBLFFMKMJ2 = IJIBLFFMKMJ;
		iJIBLFFMKMJ2.JEMKCLKCOMI = (Action)Delegate.Combine(iJIBLFFMKMJ2.JEMKCLKCOMI, new Action(HPLIAAANBJK));
		IJIBLFFMKMJ.MIOOAOFMLIE(KNGALBMMGNG);
		ENHECADHEJM.gameObject.SetActive(value: true);
		MHPMOMADKDJ.repositionNow = false;
		for (int i = 0; i < IOJCHMMEJKN.Count; i += 0)
		{
			Transform itemOnIndex = KJMFACNGKCE.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null)
				{
					component.SetWithdraw(CardManager.instance.isWithdrawAvailable);
				}
			}
		}
	}

	private void NGGMBPIBDAE(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			CardpoolRecord component = ENCEFOOPBMK.GetComponent<CardpoolRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	public void CHEPPAMDIKK(DatabasePlayer KHLGDCHJJPB, Card CEKHIJECPNP, int HHDEHMMBOHD)
	{
		for (int i = 1; i < IOJCHMMEJKN.Count; i++)
		{
			Transform itemOnIndex = KJMFACNGKCE.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null && IOJCHMMEJKN[i].id == KHLGDCHJJPB.id)
				{
					component.RemoveCardFromPool(CEKHIJECPNP, HHDEHMMBOHD);
				}
			}
		}
		HPLIAAANBJK();
	}

	private Transform LMKHBDELHEF(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < IOJCHMMEJKN.Count)
		{
			CardpoolRecord cardpoolRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(AFCEFKPJGDE, KJMFACNGKCE.gameObject, DFHAAIFFLOE.ToString("D2")) as CardpoolRecord;
			if (cardpoolRecord != null)
			{
				cardpoolRecord.Initialize(IOJCHMMEJKN[DFHAAIFFLOE], DFHAAIFFLOE + 1, CardManager.instance.isWithdrawAvailable, LNJJOMOIOIC(IOJCHMMEJKN[DFHAAIFFLOE].id));
				return cardpoolRecord.transform;
			}
		}
		return null;
	}

	public void CFFIDJKNAGN()
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && IHEPLEBDJCB)
		{
			HPLIAAANBJK();
		}
	}

	private void AKPHBJHGBKF()
	{
		KJMFACNGKCE.MakeEmpty();
		IJIBLFFMKMJ.GGKCMHOGFPF();
	}

	public void UpdateScreenCache(string EJBEDLHIKDG, Dictionary<string, string> HCMIOPBHDIC, int DGGENCBMAPB = -1)
	{
		for (int i = 0; i < IOJCHMMEJKN.Count; i++)
		{
			if (IOJCHMMEJKN[i].id == EJBEDLHIKDG)
			{
				IOJCHMMEJKN[i].depositedCardsDic = HCMIOPBHDIC;
				if (DGGENCBMAPB >= 0)
				{
					IOJCHMMEJKN[i].reputation = DGGENCBMAPB;
				}
			}
		}
	}

	private void HACHCDIDAMG(List<DatabasePlayer> FHBAEAOCCDE)
	{
		if (FHBAEAOCCDE == null)
		{
			return;
		}
		bool flag = !NLAJOOOJNPL.gameObject.activeSelf;
		List<string> list = new List<string>();
		foreach (DatabasePlayer item in FHBAEAOCCDE)
		{
			Card[] depositedCards = item.GetDepositedCards();
			foreach (Card card in depositedCards)
			{
				if (card.isBuddyCard)
				{
					list.Add(card.id);
				}
			}
		}
		list.AddRange(GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.messageBuddies);
		CardManager.instance.ResetSquadCards(list);
		if (flag)
		{
			PHGOLEBEAPD(FHBAEAOCCDE);
			return;
		}
		IOJCHMMEJKN = FHBAEAOCCDE;
		AOIJMHBDOMO();
		HPLIAAANBJK();
		NLAJOOOJNPL.gameObject.SetActive(value: false);
		KJMFACNGKCE.MakeEmpty();
		KJMFACNGKCE.init(IOJCHMMEJKN.Count, LMKHBDELHEF, KOGKOMPPIDH, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false);
	}

	private void PHGOLEBEAPD(List<DatabasePlayer> FHBAEAOCCDE)
	{
		if (FHBAEAOCCDE.Count != IOJCHMMEJKN.Count)
		{
			KJMFACNGKCE.MakeEmpty();
			NLAJOOOJNPL.gameObject.SetActive(value: true);
			HACHCDIDAMG(FHBAEAOCCDE);
			return;
		}
		IOJCHMMEJKN = FHBAEAOCCDE;
		AOIJMHBDOMO();
		for (int i = 0; i < KJMFACNGKCE.containItems; i++)
		{
			Transform itemOnIndex = KJMFACNGKCE.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null)
				{
					component.FreeTextures();
					component.Initialize(IOJCHMMEJKN[i], i + 1, CardManager.instance.isWithdrawAvailable, LNJJOMOIOIC(IOJCHMMEJKN[i].id));
				}
			}
		}
	}

	private void BBOHACILKPG()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		IJIBLFFMKMJ.JCMHGOGNMFO();
		WinStreakCounter iJIBLFFMKMJ = IJIBLFFMKMJ;
		iJIBLFFMKMJ.JEMKCLKCOMI = (Action)Delegate.Remove(iJIBLFFMKMJ.JEMKCLKCOMI, new Action(HPLIAAANBJK));
		IJIBLFFMKMJ.KGNGFHMBHMJ.text = Colours.stringPink + Localization.Localize("ID_ISAVAILABLENOW");
		ENHECADHEJM.gameObject.SetActive(value: false);
		MHPMOMADKDJ.repositionNow = true;
		for (int i = 0; i < IOJCHMMEJKN.Count; i++)
		{
			Transform itemOnIndex = KJMFACNGKCE.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null)
				{
					component.SetWithdraw(CardManager.instance.isWithdrawAvailable);
				}
			}
		}
	}

	private void JHNCOBMOLND(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && IHEPLEBDJCB && (IFGAGNBDKBE == (DatabaseAction)(-187) || IFGAGNBDKBE == (DatabaseAction)22))
		{
			Debug.LogError("Game_type");
			PMBPAOLBLFA();
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		JJEPOPCDAAP.repositionNow = true;
	}

	private void MJOAHLPOAHN(int KNGALBMMGNG)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		WinStreakCounter iJIBLFFMKMJ = IJIBLFFMKMJ;
		iJIBLFFMKMJ.JEMKCLKCOMI = (Action)Delegate.Remove(iJIBLFFMKMJ.JEMKCLKCOMI, new Action(HPLIAAANBJK));
		WinStreakCounter iJIBLFFMKMJ2 = IJIBLFFMKMJ;
		iJIBLFFMKMJ2.JEMKCLKCOMI = (Action)Delegate.Combine(iJIBLFFMKMJ2.JEMKCLKCOMI, new Action(HPLIAAANBJK));
		IJIBLFFMKMJ.MHLJHMOPDAO(KNGALBMMGNG);
		ENHECADHEJM.gameObject.SetActive(value: true);
		MHPMOMADKDJ.repositionNow = true;
		for (int i = 0; i < IOJCHMMEJKN.Count; i++)
		{
			Transform itemOnIndex = KJMFACNGKCE.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null)
				{
					component.SetWithdraw(CardManager.instance.isWithdrawAvailable);
				}
			}
		}
	}

	[CompilerGenerated]
	private static bool PPJFOICJAFI(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private bool KMOAFIMCCPN(string INFLHPGMEOB)
	{
		if (LFEGLEFNPJJ.ContainsKey(INFLHPGMEOB))
		{
			return Singleton<BeanstalkServerManager>.instance.currentTimestamp > LFEGLEFNPJJ[INFLHPGMEOB];
		}
		return false;
	}

	private void NFNCAIAPJNH(DatabaseAction IFGAGNBDKBE)
	{
		if (!GuiScreenSingle<SquadScreen>.instance.isShowed || !IHEPLEBDJCB)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)20:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list == null)
			{
				list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			}
			if (list != null)
			{
				DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
				int num = list.FindIndex((DatabasePlayer NGKBOFPJNAG) => NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id);
				if (num > -1)
				{
					list[num].playerVisuals = generatedCurrentPlayer.playerVisuals;
					list[num].country = generatedCurrentPlayer.country;
					list[num].level = generatedCurrentPlayer.level;
					list[num].squadRank = generatedCurrentPlayer.squadRank;
					list[num].armyPower = generatedCurrentPlayer.armyPower;
					list[num].leagueTier = generatedCurrentPlayer.leagueTier;
					list[num].beginnersLeague = generatedCurrentPlayer.beginnersLeague;
					list[num].remainingMatches = generatedCurrentPlayer.remainingMatches;
					list[num].skill = generatedCurrentPlayer.skill;
					list[num].depositedCardsDic = generatedCurrentPlayer.depositedCardsDic;
					list[num].reputation = generatedCurrentPlayer.reputation;
				}
				else
				{
					list.Add(generatedCurrentPlayer);
				}
				for (int num2 = list.Count - 1; num2 >= 1; num2--)
				{
					if (string.IsNullOrEmpty(list[num2].name))
					{
						list.RemoveAt(num2);
					}
				}
				list.Sort(NHBNNDKDGKM);
			}
			else
			{
				list = new List<DatabasePlayer>();
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			HACHCDIDAMG(list);
			break;
		}
		case (DatabaseAction)(-88):
			if (NLAJOOOJNPL.gameObject.activeSelf)
			{
				PMBPAOLBLFA();
			}
			break;
		}
	}

	private void FMDFHNGIALE(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<CardpoolDialog>.instance.ShowDeposit(GameLoginManager.currentPlayer.GetDepositedCards());
	}

	public void WithdrewCard(DatabasePlayer KHLGDCHJJPB, Card CEKHIJECPNP, int HHDEHMMBOHD)
	{
		for (int i = 0; i < IOJCHMMEJKN.Count; i++)
		{
			Transform itemOnIndex = KJMFACNGKCE.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null && IOJCHMMEJKN[i].id == KHLGDCHJJPB.id)
				{
					component.RemoveCardFromPool(CEKHIJECPNP, HHDEHMMBOHD);
				}
			}
		}
		HPLIAAANBJK();
	}

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		IHEPLEBDJCB = false;
		UIEventListener uIEventListener = UIEventListener.Get(FPLKJLJIJCE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMDFHNGIALE));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		CardManager.instance.WithdrawTimeChanged += OnWithdrawTimeChanged;
		int num = 134;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		int num2 = (int)UIHelper.activeHeight - (470 + num);
		LEIDAILJEGN.transform.localPosition = LEIDAILJEGN.transform.localPosition.ReplaceX(activeWidthSafe / 2f - 60f);
		MBGGKACGDPA.transform.localPosition = MBGGKACGDPA.transform.localPosition.ReplaceX(activeWidthSafe - 120f);
		CFFKHHJKBMJ.clipRange = CFFKHHJKBMJ.clipRange.ReplaceYW((float)(-num2) / 2f, num2);
		NFLPPGKCOBL.transform.localPosition = NFLPPGKCOBL.transform.localPosition.ReplaceY(0f);
		MHPMOMADKDJ.onReposition = delegate
		{
			JJEPOPCDAAP.repositionNow = true;
		};
		JJEPOPCDAAP.onReposition = delegate
		{
			float num3 = AFJIPAFJFJF.transform.localPosition.x - 2f * JJEPOPCDAAP.padding.x;
			JJEPOPCDAAP.transform.localPosition = JJEPOPCDAAP.transform.localPosition.ReplaceX(0f - num3);
		};
	}

	public void InstantHideTab()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = JAEJGOEPOKM.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		PPMCFMBJJHP();
	}

	public void DepositedWarcards(List<Card> OEGDJJNFBHL, List<Card> HLHEOEDLFHP)
	{
		Card[] array = new Card[OEGDJJNFBHL.Count];
		for (int i = 0; i < OEGDJJNFBHL.Count; i++)
		{
			array[i] = OEGDJJNFBHL[i];
		}
		for (int j = 0; j < IOJCHMMEJKN.Count; j++)
		{
			Transform itemOnIndex = KJMFACNGKCE.GetItemOnIndex(j);
			if (itemOnIndex != null)
			{
				CardpoolRecord component = itemOnIndex.GetComponent<CardpoolRecord>();
				if (component != null && IOJCHMMEJKN[j].id == GameLoginManager.currentPlayer.id)
				{
					component.InitializeWarcards(array);
					component.AnimateWarcards(HLHEOEDLFHP);
				}
			}
		}
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && base.gameObject.activeSelf)
		{
			PMBPAOLBLFA();
		}
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(JAEJGOEPOKM.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f);
			TweenAlpha.Begin(JOBNEIFNGJO.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					base.gameObject.SetActive(value: false);
					PPMCFMBJJHP();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	private void NAFFFDLJNNN(DatabaseAction IFGAGNBDKBE)
	{
		if (!GuiScreenSingle<SquadScreen>.instance.isShowed || !IHEPLEBDJCB)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.IgnoreMessage:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list == null)
			{
				list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			}
			if (list != null)
			{
				DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
				int num = list.FindIndex((DatabasePlayer NGKBOFPJNAG) => NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id);
				if (num > -1)
				{
					list[num].playerVisuals = generatedCurrentPlayer.playerVisuals;
					list[num].country = generatedCurrentPlayer.country;
					list[num].level = generatedCurrentPlayer.level;
					list[num].squadRank = generatedCurrentPlayer.squadRank;
					list[num].armyPower = generatedCurrentPlayer.armyPower;
					list[num].leagueTier = generatedCurrentPlayer.leagueTier;
					list[num].beginnersLeague = generatedCurrentPlayer.beginnersLeague;
					list[num].remainingMatches = generatedCurrentPlayer.remainingMatches;
					list[num].skill = generatedCurrentPlayer.skill;
					list[num].depositedCardsDic = generatedCurrentPlayer.depositedCardsDic;
					list[num].reputation = generatedCurrentPlayer.reputation;
				}
				else
				{
					list.Add(generatedCurrentPlayer);
				}
				for (int num2 = list.Count - 1; num2 >= 1; num2--)
				{
					if (string.IsNullOrEmpty(list[num2].name))
					{
						list.RemoveAt(num2);
					}
				}
				list.Sort(NHBNNDKDGKM);
			}
			else
			{
				list = new List<DatabasePlayer>();
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			HACHCDIDAMG(list);
			break;
		}
		case (DatabaseAction)0:
			if (NLAJOOOJNPL.gameObject.activeSelf)
			{
				PMBPAOLBLFA();
			}
			break;
		}
	}

	private void PMBPAOLBLFA()
	{
		KJMFACNGKCE.MakeEmpty();
		NLAJOOOJNPL.gameObject.SetActive(value: true);
		GuiScreenSingle<SquadScreen>.instance.CardpoolNotifications();
		CardManager.instance.InitializeBuddyWarcard();
		Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName);
		if (!PlayerAnalytics.instance.data.cardpoolShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new IKNDOFHPKBC());
		}
	}

	private bool CBPHMNBCAFD(string INFLHPGMEOB)
	{
		if (LFEGLEFNPJJ.ContainsKey(INFLHPGMEOB))
		{
			return Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > LFEGLEFNPJJ[INFLHPGMEOB];
		}
		return false;
	}

	private int NHBNNDKDGKM(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.reputation != NCMHGPNPEJM.reputation)
		{
			return NCMHGPNPEJM.reputation.CompareTo(HPJFBKEKJHB.reputation);
		}
		if (HPJFBKEKJHB.level != NCMHGPNPEJM.level)
		{
			return NCMHGPNPEJM.level.CompareTo(HPJFBKEKJHB.level);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
	}
}
