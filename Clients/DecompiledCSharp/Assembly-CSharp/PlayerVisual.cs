using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

[Serializable]
public class PlayerVisual
{
	public enum State
	{
		Locked,
		NotBuyed,
		Ready,
		Active
	}

	public enum Purchasable
	{
		Shop,
		ValuePack,
		StarterPack,
		StarterAssignment,
		Arena
	}

	public enum Rarity
	{
		Common,
		Uncommon,
		Rare,
		Epic,
		Legendary
	}

	public string visualName;

	public string icon;

	[HideInInspector]
	public PlayerVisualsRow row;

	private static Dictionary<Rarity, string> mRarityNames = new Dictionary<Rarity, string>
	{
		{
			Rarity.Common,
			"ID_VISUALRARITY1"
		},
		{
			Rarity.Uncommon,
			"ID_VISUALRARITY2"
		},
		{
			Rarity.Rare,
			"ID_VISUALRARITY3"
		},
		{
			Rarity.Epic,
			"ID_VISUALRARITY4"
		},
		{
			Rarity.Legendary,
			"ID_VISUALRARITY5"
		}
	};

	[HideInInspector]
	public bool tryOutVisual
	{
		get
		{
			return CamosManager.instance.data.visuals.ContainsKey(id) && CamosManager.instance.data.visuals[id].borrowed;
		}
		set
		{
			if (!CamosManager.instance.data.visuals.ContainsKey(id))
			{
				Debug.LogError("no visual found");
			}
			else
			{
				CamosManager.instance.data.visuals[id].borrowed = value;
			}
		}
	}

	public State camoState
	{
		get
		{
			if (!isUnlocked)
			{
				return State.Locked;
			}
			if (!isBought)
			{
				return State.NotBuyed;
			}
			if (isActive)
			{
				return State.Active;
			}
			return State.Ready;
		}
	}

	public PlayerVisualCategory owner { get; set; }

	public string id { get; set; }

	public string name => Localization.Localize(id + "_N");

	public virtual string description => Localization.Localize(id + "_D");

	public virtual int endPromotion => GetSavedPlayerVisual().expiresOn;

	public bool isActive => owner as PlayerVisualCategoryPowerBands != null && isEquipped;

	public bool isDefault => numberOfPartsMax == 0 && duplicateWarbucks == 0 && purchasableInShop;

	public virtual bool isBought => CamosManager.instance.data.visuals.ContainsKey(id) && ((CamosManager.instance.data.visuals[id].bought && (!purchasableInArena || remainingTime > 0.0)) || (numberOfPartsMax > 0 && numberOfParts >= numberOfPartsMax) || (priceGold == 0 && priceWarbucks == 0 && purchasable == Purchasable.Shop) || isDefault || tryOutVisual);

	public bool isEquipped => owner.equippedVisual == this;

	public bool isUnlocked => LevelManager.instance.currentLevel.index >= unlockLevelIndex || isBought;

	public bool isVipOnly => row.ONLYFORVIP;

	public int priceGold => row.PRICEGOLD;

	public int priceWarbucks => row.PRICEWARBUCKS;

	public Rarity rarity => (Rarity)row.CATEGORY;

	public string rarityName => Localization.Localize(mRarityNames[rarity]);

	public int numberOfParts => GetSavedPlayerVisual().parts;

	public int numberOfPartsMax => row.PARTS;

	public int duplicateWarbucks => row.DUPLICATEWARBUCKS;

	public float progress => Mathf.Clamp01((float)(remainingTime / (double)timeActive));

	public virtual int decalType => row.DECALTYPE;

	public int timeActive => row.TIME;

	public float decalValue => row.DECALVALUE * 100f;

	public string decalValueString => $"+{MiscTools.FormatFloatNumberRoundZeroOrOne(decalValue)}%";

	public virtual string decalMiniIcon => "menu-powerband-health-ico";

	public virtual Color decalMiniIconColor => Color.white;

	public virtual string decalShortName => Localization.Localize("BAND_EMPTY");

	public virtual string decalTypeName => Localization.Localize("BAND_TYPE_EMPTY");

	public virtual bool isEmptyPowerBand => false;

	public Purchasable purchasable
	{
		get
		{
			if (row.PURCHASABLE == "value")
			{
				return Purchasable.ValuePack;
			}
			if (row.PURCHASABLE == "starter")
			{
				return Purchasable.StarterPack;
			}
			if (row.PURCHASABLE == "assignment")
			{
				return Purchasable.StarterAssignment;
			}
			if (row.PURCHASABLE == "arena")
			{
				return Purchasable.Arena;
			}
			return Purchasable.Shop;
		}
	}

	public bool purchasableInShop => purchasable == Purchasable.Shop;

	public bool purchasableInArena => purchasable == Purchasable.Arena;

	public bool isFromArena => purchasable == Purchasable.Arena;

	public double remainingTime
	{
		get
		{
			double num = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			double num2 = GetSavedPlayerVisual().expiresOn;
			if (num2 < num)
			{
				return 0.0;
			}
			return num2 - num;
		}
	}

	public bool showed
	{
		get
		{
			return GetSavedPlayerVisual().showed || unlockLevelIndex < 3;
		}
		set
		{
			GetSavedPlayerVisual().showed = true;
		}
	}

	public bool notificate
	{
		get
		{
			return GetSavedPlayerVisual().notificate;
		}
		set
		{
			GetSavedPlayerVisual().notificate = value;
		}
	}

	public virtual int startPromotion => GetSavedPlayerVisual().expiresOn - timeActive;

	public int unlockLevelIndex => row.UNLOCKLEVEL - 1;

	public LevelManager.GameLevel unlockLevel => LevelManager.instance.GetLevelDefinition(unlockLevelIndex);

	public virtual void LoadPathsForEditor()
	{
	}

	public virtual void setExpiresOn(int expiresOn)
	{
		GetSavedPlayerVisual().expiresOn = expiresOn;
		if (expiresOn > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			GetSavedPlayerVisual().bought = true;
		}
	}

	public virtual void Initialize()
	{
	}

	public virtual void ApplyVisual(ICharacter character, bool useHighRes = false)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		PlayerController playerController = character as PlayerController;
		if (playerController != null)
		{
			if (playerController.playerProperties.playerVisuals == null)
			{
				playerController.playerProperties.playerVisuals = new string[CamosManager.instance.playerVisualCategories.Count];
			}
			playerController.playerProperties.playerVisuals[owner.categoryNumber] = id;
		}
	}

	public virtual void Buy()
	{
		CamosManager.instance.data.visuals[id].bought = true;
	}

	public void Equip()
	{
		CamosManager.instance.data.slots[owner.categoryNumber].equippedID = id;
		ApplyVisual(CamosManager.instance.mainPlayer, useHighRes: true);
	}

	public int AddParts(int count)
	{
		int parts = CamosManager.instance.data.visuals[id].parts;
		if (parts == numberOfPartsMax)
		{
			Singleton<EventTrackingManager>.instance.RegisterDuplicateLootbox(count * duplicateWarbucks);
		}
		else if (parts + count >= numberOfPartsMax)
		{
			Singleton<EventTrackingManager>.instance.RegisterVisualGained((int)rarity);
		}
		else
		{
			Singleton<EventTrackingManager>.instance.RegisterOpenLootbox((int)rarity);
		}
		if (isBought)
		{
			return count;
		}
		CamosManager.instance.data.visuals[id].parts = Mathf.Min(parts + count, numberOfPartsMax);
		return 0;
	}

	internal string GetSheetName()
	{
		return row.GetType().ToString();
	}

	private CamosManager.SavedPlayerVisual GetSavedPlayerVisual()
	{
		if (CamosManager.instance.data.visuals.TryGetValue(id, out var value))
		{
			return value;
		}
		return new CamosManager.SavedPlayerVisual();
	}

	public virtual void Null()
	{
	}

	public virtual void Load()
	{
	}
}
