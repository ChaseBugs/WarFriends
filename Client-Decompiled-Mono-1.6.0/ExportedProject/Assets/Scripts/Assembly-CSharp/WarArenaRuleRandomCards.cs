using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WarArenaRandomCards", menuName = "War Arena Rules/WarArena RandomCards", order = int.MaxValue)]
public class WarArenaRuleRandomCards : WarArenaRuleGeneric<WarArenaRuleRandomCards.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		[Tooltip("Defines how many cards there will be and their rarities")]
		public List<CardManager.CardType> cards;
	}

	private List<Card> mCardsForGame;

	private int mLastMatches = -1;

	protected virtual OCCICIIEHEF DMJPIAALNJK()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}{1}"));
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF CCCGIFMLEKF()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), OBNJAIHEJOJ.InfoText);
		}
		return base.PEAIJAFJCBA();
	}

	protected virtual OCCICIIEHEF FMELBPGCGCA()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}"), (OBNJAIHEJOJ)5);
		}
		return base.NNNAKBICOHM();
	}

	protected virtual OCCICIIEHEF MHFONBFBNJL()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-gold"), (OBNJAIHEJOJ)5);
		}
		return base.IEKDLDACNDI();
	}

	protected virtual OCCICIIEHEF HADBACCEMBP()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("()Z"), (OBNJAIHEJOJ)6);
		}
		return base.BEDAAOOPNLB();
	}

	public virtual bool ILGFAGLOPGH()
	{
		base.AIMGMMCHEIO();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Preselected | CardManager.CardFilter.Random));
		return false;
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_RANDOMWARCARDS"));
		}
		return base.OHFBLDPINHI();
	}

	protected virtual OCCICIIEHEF BNLBBIAKFJB()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_5SKIRMISHES"), (OBNJAIHEJOJ)4);
		}
		return base.CKKHLNNIKHE();
	}

	public virtual bool KEHNMKJNNLG()
	{
		base.AIMGMMCHEIO();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.Bronze | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy | CardManager.CardFilter.Random);
		return false;
	}

	public virtual bool JFEDDBNNDNJ()
	{
		base.CLPEMLCLDIJ();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)109);
		return true;
	}

	public override bool FGHKBLLKOBL()
	{
		base.AKIJBMEBNNC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)115);
		return true;
	}

	protected virtual OCCICIIEHEF AMOCDNPPEHN()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Camo load error: {0}"), OBNJAIHEJOJ.InfoText);
		}
		return base.IEKDLDACNDI();
	}

	public override bool EKMMLNKADIL()
	{
		base.EKMMLNKADIL();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.Random);
		return true;
	}

	protected virtual OCCICIIEHEF OPBDMHMAOKC()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("_GlobalDensity"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual bool ABFCMKAKMED()
	{
		base.DJDCOJHOBJP();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Buddy | CardManager.CardFilter.Preselected | CardManager.CardFilter.Random));
		return true;
	}

	public virtual bool HJEDAJDHEIG()
	{
		base.DDFGIDBHJIK();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Preselected));
		return true;
	}

	protected virtual OCCICIIEHEF LLAMMNLFPGC()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SquadIcons/"), OBNJAIHEJOJ.FulFill);
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF GDAGBPNIJCD()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Assignment {0}"), (OBNJAIHEJOJ)6);
		}
		return base.OHFBLDPINHI();
	}

	public virtual bool AONAAGJDHOD()
	{
		base.EDNAIMPLPGL();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)(-80));
		return true;
	}

	protected virtual OCCICIIEHEF JHCOGMDEHJI()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("damage"), OBNJAIHEJOJ.FulFill);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF KMFIBOJMODM()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Decal_Type"), (OBNJAIHEJOJ)6);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF DJHPDCMGPOO()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("offerMult"), (OBNJAIHEJOJ)5);
		}
		return base.NELJBJBMOLH();
	}

	public virtual bool AKCJIOOJHCG()
	{
		base.OEAODGFDMGC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)(-69));
		return true;
	}

	public override bool DJDCOJHOBJP()
	{
		base.KFJLPGPAAAN();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)76);
		return false;
	}

	public virtual bool DLOLNAIPFHF()
	{
		base.AKIJBMEBNNC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)(-98));
		return true;
	}

	protected virtual OCCICIIEHEF PIMHAILAAEI()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("AssignmentId"), (OBNJAIHEJOJ)7);
		}
		return base.OOBCHHAGFIO();
	}

	protected virtual OCCICIIEHEF PLAHOBIKBOO()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("count: 0"));
		}
		return base.NELJBJBMOLH();
	}

	public virtual bool DMKIPBEAMBI()
	{
		base.DJDCOJHOBJP();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)89);
		return false;
	}

	protected virtual OCCICIIEHEF NJBKGEHKDLG()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Parts"), OBNJAIHEJOJ.FulFill);
		}
		return base.CKKHLNNIKHE();
	}

	public virtual bool CICCFGCHCMB()
	{
		base.MPNDBIBDOCD();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy));
		return true;
	}

	public override bool NMPPLCHLCDK()
	{
		base.EDNAIMPLPGL();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)122);
		return false;
	}

	public virtual bool NCIAEBEEDGJ()
	{
		base.KFJLPGPAAAN();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)(-96));
		return false;
	}

	public override bool LPLPANBJDAM()
	{
		base.KJDMOCMBFLJ();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)118);
		return true;
	}

	protected virtual OCCICIIEHEF IJIPGJEODNI()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}{2}"), OBNJAIHEJOJ.FulFill);
		}
		return base.IBOOCJPKFLG();
	}

	public virtual bool JEBKAPDIKAM()
	{
		base.DDFGIDBHJIK();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Preselected | CardManager.CardFilter.Random));
		return false;
	}

	protected virtual OCCICIIEHEF GKDKMHOHIFB()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Different squad points \"{0}\" and \"{1}\"\n"), (OBNJAIHEJOJ)5);
		}
		return base.EPEIMHECJHK();
	}

	public virtual bool ILIJFMJCBGP()
	{
		base.OAELLJPGBPC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Preselected);
		return true;
	}

	protected virtual OCCICIIEHEF EPOLOANGNOI()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Special pack content: type: {0} id: {1}{2}"), OBNJAIHEJOJ.FulFill);
		}
		return base.BEDAAOOPNLB();
	}

	public virtual bool DHFOKAIJMDN()
	{
		base.DJDCOJHOBJP();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Preselected));
		return true;
	}

	public virtual bool KABMAAKKFML()
	{
		base.OAELLJPGBPC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.Silver | CardManager.CardFilter.Random);
		return true;
	}

	protected virtual OCCICIIEHEF GDFMGBDHEMD()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("reloadTime"), (OBNJAIHEJOJ)8);
		}
		return base.BEDAAOOPNLB();
	}

	protected virtual OCCICIIEHEF DHPHFLPNOGC()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ammo"), (OBNJAIHEJOJ)7);
		}
		return base.EPEIMHECJHK();
	}

	protected override OCCICIIEHEF OMDJEDGCGOM()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("-BUFFMAXDESC"), OBNJAIHEJOJ.FulFill);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF KAPJOIBLJOL()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TIERX"), (OBNJAIHEJOJ)5);
		}
		return base.LMOHCGEPLAH();
	}

	protected virtual OCCICIIEHEF BONNBPPGHKO()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_KICKPLAYER"), OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.IBOOCJPKFLG();
	}

	public virtual bool AOEGGNCJPFG()
	{
		base.DAHIFNEGKAD();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)(-84));
		return false;
	}

	protected virtual OCCICIIEHEF KNLNGNJEBMP()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SWITCH TO Coop"), OBNJAIHEJOJ.FulFill);
		}
		return base.NELJBJBMOLH();
	}

	public virtual bool LFJLHMIJLHK()
	{
		base.OEAODGFDMGC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Silver | CardManager.CardFilter.Buddy | CardManager.CardFilter.Preselected | CardManager.CardFilter.Random));
		return true;
	}

	protected override OCCICIIEHEF MFBIPMEKFAF()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ERRORSHORTNICK"), (OBNJAIHEJOJ)5);
		}
		return base.NNNAKBICOHM();
	}

	protected virtual OCCICIIEHEF IBFBBFCOOMP()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("extraGold"), (OBNJAIHEJOJ)5);
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Assignment: Error, task definition not found for id = "), (OBNJAIHEJOJ)7);
		}
		return base.NELJBJBMOLH();
	}

	protected virtual OCCICIIEHEF PBNCCMPCFPE()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("fr"), (OBNJAIHEJOJ)6);
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF MMCKBEIOEAO()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("#PETER# League Arc - stop ignore on "), OBNJAIHEJOJ.FulFill);
		}
		return base.NELJBJBMOLH();
	}

	protected virtual OCCICIIEHEF DEKPLKOFMFM()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_NA"), (OBNJAIHEJOJ)6);
		}
		return base.MNMEAAEKAMH();
	}

	public virtual bool ENFDGBOGOIC()
	{
		base.KJDMOCMBFLJ();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.Bronze | CardManager.CardFilter.Random);
		return false;
	}

	public virtual bool FLMDFNFPLBI()
	{
		base.LPLPANBJDAM();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)119);
		return false;
	}

	public virtual bool DOLNPMMBCLF()
	{
		base.KJDMOCMBFLJ();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)106);
		return false;
	}

	public virtual bool HLAEFDLJGLD()
	{
		base.OAELLJPGBPC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.Buddy);
		return true;
	}

	protected virtual OCCICIIEHEF MHONCCANCOG()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("discount"), OBNJAIHEJOJ.InfoText);
		}
		return base.IEKDLDACNDI();
	}

	public virtual bool JIBFELAHJDE()
	{
		base.OEAODGFDMGC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Buddy | CardManager.CardFilter.Preselected | CardManager.CardFilter.Random));
		return false;
	}

	protected virtual OCCICIIEHEF IGEPGGBBBGB()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_WRONGPLAYERDATA"), OBNJAIHEJOJ.FulFill);
		}
		return base.OHFBLDPINHI();
	}

	public virtual bool HCGMAHBEIMB()
	{
		base.LPLPANBJDAM();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~CardManager.CardFilter.Bronze);
		return true;
	}

	public virtual bool IBBDAKDEHAB()
	{
		base.DAHIFNEGKAD();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)117);
		return false;
	}

	public virtual bool MDINCFAKJPM()
	{
		base.DJDCOJHOBJP();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.None);
		return true;
	}

	protected virtual OCCICIIEHEF KMLOHPNKIDO()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Sniper_Tutorial_Duration"), (OBNJAIHEJOJ)8);
		}
		return base.IBOOCJPKFLG();
	}

	protected virtual OCCICIIEHEF DKBNNKANPLC()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\tPush notification shown counter: {0}/{1}"), OBNJAIHEJOJ.InfoText);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF EFAOEMFMBHI()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("PlayerGold"), OBNJAIHEJOJ.InfoText);
		}
		return base.OHFBLDPINHI();
	}

	public virtual bool NNJFECMPDCI()
	{
		base.OAELLJPGBPC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~CardManager.CardFilter.Bronze);
		return true;
	}

	protected virtual OCCICIIEHEF OIJBDMDPHGD()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WarBucks"));
		}
		return base.OOBCHHAGFIO();
	}

	public virtual bool DFIMOMOIHCD()
	{
		base.EKMMLNKADIL();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)109);
		return false;
	}

	protected virtual OCCICIIEHEF PCCCPHOEGBH()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WarBucks"));
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF PAJJOHEGNKJ()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("0"), OBNJAIHEJOJ.InfoText);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF CNCKNEMOHJL()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_INBRONZE1"));
		}
		return base.OOBCHHAGFIO();
	}

	protected override OCCICIIEHEF NELJBJBMOLH()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("VisualTimestamp"), (OBNJAIHEJOJ)6);
		}
		return base.NELJBJBMOLH();
	}

	public virtual bool IDCLHHDLCPJ()
	{
		base.DAHIFNEGKAD();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.Silver | CardManager.CardFilter.Random);
		return false;
	}

	public virtual bool JDOHJEEMAKO()
	{
		base.KFJLPGPAAAN();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(0, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Buddy | CardManager.CardFilter.Preselected));
		return true;
	}

	protected virtual OCCICIIEHEF FNOGDBMIBHM()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("measureEvent"), (OBNJAIHEJOJ)4);
		}
		return base.OOBCHHAGFIO();
	}

	protected virtual OCCICIIEHEF JGADEDPFGEN()
	{
		if (data.cards != null && data.cards.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("game-card-ico-streakboost-full"), (OBNJAIHEJOJ)6);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF IKAEPAPKLOB()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("EnableData()"), (OBNJAIHEJOJ)8);
		}
		return base.EPEIMHECJHK();
	}

	protected virtual OCCICIIEHEF OCHABKJJLKP()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Different league \"{0}\" and \"{1}\"\n"), OBNJAIHEJOJ.InfoText);
		}
		return base.EPEIMHECJHK();
	}

	protected virtual OCCICIIEHEF OPLHOAENDAE()
	{
		if (data.cards != null && data.cards.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Attempts"), (OBNJAIHEJOJ)8);
		}
		return base.EPEIMHECJHK();
	}

	public virtual bool KOHMDOHKMIH()
	{
		base.OEAODGFDMGC();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, CardManager.CardFilter.Bronze | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy);
		return true;
	}

	public virtual bool IGIMHDBBFJI()
	{
		base.FGHKBLLKOBL();
		if (WarArena.instance.data.matches != mLastMatches || mCardsForGame == null || mCardsForGame.Count == 0)
		{
			mCardsForGame = new List<Card>();
			mLastMatches = WarArena.instance.data.matches;
			foreach (CardManager.CardType card in data.cards)
			{
				List<Card> list = CardManager.instance.cardsByQuality[card];
				mCardsForGame.Add(list[UnityEngine.Random.Range(1, list.Count)]);
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(mCardsForGame, (CardManager.CardFilter)119);
		return false;
	}
}
