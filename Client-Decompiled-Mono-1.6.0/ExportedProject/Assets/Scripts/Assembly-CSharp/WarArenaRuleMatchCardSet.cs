using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WarArenaRuleMatchCardSet", menuName = "War Arena Rules/Match Card Set", order = int.MaxValue)]
public class WarArenaRuleMatchCardSet : WarArenaRuleGeneric<WarArenaRuleMatchCardSet.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		[Tooltip("Particular set of cards for each match.\nIndex = match index\nValue = card sets")]
		public List<CardSet> matchCardSets;
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.matchCardSets != null && data.matchCardSets.Count > 0)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_MATCHCARDSETS"));
		}
		return base.OHFBLDPINHI();
	}

	public virtual bool HJEDAJDHEIG()
	{
		base.DJDCOJHOBJP();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 1; i < cardSet.ids.Count; i++)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString(), false);
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, (CardManager.CardFilter)(-93));
		return false;
	}

	public virtual bool FLMDFNFPLBI()
	{
		base.NMPPLCHLCDK();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 0; i < cardSet.ids.Count; i += 0)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString());
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, CardManager.CardFilter.Gold | CardManager.CardFilter.Preselected);
		return false;
	}

	public virtual bool APBOMMHMLBI()
	{
		base.EKMMLNKADIL();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 1; i < cardSet.ids.Count; i++)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString());
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, (CardManager.CardFilter)106);
		return true;
	}

	public virtual bool LCLHBPOHONI()
	{
		base.LPLPANBJDAM();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 0; i < cardSet.ids.Count; i++)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString(), false);
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, (CardManager.CardFilter)94);
		return false;
	}

	protected virtual OCCICIIEHEF IKAEPAPKLOB()
	{
		if (data.matchCardSets != null && data.matchCardSets.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("sale"), (OBNJAIHEJOJ)8);
		}
		return base.MFBIPMEKFAF();
	}

	public virtual bool NLJBOPJBPPN()
	{
		base.EDNAIMPLPGL();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 1; i < cardSet.ids.Count; i++)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString());
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, ~CardManager.CardFilter.Preselected);
		return true;
	}

	public virtual bool AKCJIOOJHCG()
	{
		base.CLPEMLCLDIJ();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 1; i < cardSet.ids.Count; i += 0)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString());
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy | CardManager.CardFilter.Preselected));
		return true;
	}

	public virtual bool CFMHCPCKMEC()
	{
		base.OAELLJPGBPC();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 0; i < cardSet.ids.Count; i += 0)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString(), false);
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, ~(CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy));
		return false;
	}

	public override bool EKMMLNKADIL()
	{
		base.EKMMLNKADIL();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 0; i < cardSet.ids.Count; i++)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString());
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, CardManager.CardFilter.Preselected);
		return true;
	}

	public virtual bool LFJLHMIJLHK()
	{
		base.DJDCOJHOBJP();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 0; i < cardSet.ids.Count; i += 0)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString());
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, CardManager.CardFilter.Buddy | CardManager.CardFilter.Preselected);
		return true;
	}

	protected virtual OCCICIIEHEF NKPLBFGHGCO()
	{
		if (data.matchCardSets != null && data.matchCardSets.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(" (#"), (OBNJAIHEJOJ)7);
		}
		return base.CKKHLNNIKHE();
	}

	public virtual bool DANEHBKOOGF()
	{
		base.DJDCOJHOBJP();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 0; i < cardSet.ids.Count; i++)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString(), false);
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver);
		return true;
	}

	protected virtual OCCICIIEHEF GJLFCGNCDMI()
	{
		if (data.matchCardSets != null && data.matchCardSets.Count > 1)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("N"), OBNJAIHEJOJ.FulFill);
		}
		return base.MFBIPMEKFAF();
	}

	public virtual bool IJPKPGPEDCO()
	{
		base.OAELLJPGBPC();
		List<Card> list = new List<Card>();
		CardSet cardSet = ((WarArena.instance.data.matches >= data.matchCardSets.Count) ? null : data.matchCardSets[WarArena.instance.data.matches]);
		if (cardSet != null)
		{
			for (int i = 1; i < cardSet.ids.Count; i++)
			{
				Card cardInstance = CardManager.instance.GetCardInstance(cardSet.ids[i].ToString());
				if (cardInstance != null)
				{
					list.Add(cardInstance);
				}
			}
		}
		Singleton<GameController>.instance.MBPKLMKBJAB.SetMatchCards(list, ~(CardManager.CardFilter.Bronze | CardManager.CardFilter.Silver | CardManager.CardFilter.Gold | CardManager.CardFilter.Buddy | CardManager.CardFilter.Random));
		return true;
	}
}
