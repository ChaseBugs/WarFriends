using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

[Skip]
public class Card : Core_BaseScript
{
	public const float baseShowCartIcoTimeInGame = 3f;

	[HideInInspector]
	public int playerId;

	[Header("GUI Translations")]
	[SerializeField]
	[FormerlySerializedAs("cardName")]
	private string mCardNameID;

	[SerializeField]
	[FormerlySerializedAs("description")]
	protected string mDescriptionID;

	[Header("GUI Big Card")]
	public string iconName = string.Empty;

	public float iconMultiplier = 1f;

	public Vector3 bigCardPosition = Vector3.zero;

	public Color bonusIconBackgroundColor = Color.white;

	public Color bonusIconColor = Color.white;

	[Header("GUI Small Card")]
	public float smallCardRotation;

	public Vector3 smallCardPosition = Vector3.zero;

	public Vector3 smallIconPosition = Vector3.zero;

	public string bonusIcon = string.Empty;

	public bool showBonusIconInSmallCard = true;

	public Color bonusIconSmallCardColor = Color.white;

	public string bonusName = string.Empty;

	[Header("Base Card Settings")]
	public string id;

	public float cooldown = 5f;

	public bool isEnemyPlayerBuff;

	private CardDefinitionsRow mCardDefinition;

	public virtual CardManager.CardType rarity
	{
		get
		{
			if (mCardDefinition != null)
			{
				return (CardManager.CardType)mCardDefinition.RARITY;
			}
			return CardManager.CardType.Bronze;
		}
	}

	public virtual int newFromMission
	{
		get
		{
			if (mCardDefinition != null)
			{
				return mCardDefinition.FROMMISSION;
			}
			return 99;
		}
	}

	public bool implemented
	{
		get
		{
			if (mCardDefinition != null)
			{
				return mCardDefinition.IMPLEMENTED;
			}
			return false;
		}
	}

	public int rarityNumber => (int)rarity;

	public bool isBuddyCard => rarity == CardManager.CardType.Buddy;

	public Texture2D iconTexture { get; protected set; }

	public virtual bool showInGame => true;

	protected bool isOnlineMaster => PhotonNetwork.isMasterClient && !PhotonNetwork.offlineMode;

	public virtual string cardName => Localization.Localize(mCardNameID);

	public virtual string description => Localization.Localize(mDescriptionID);

	public virtual string unitTypeSpriteName => string.Empty;

	protected virtual string mBonusName => string.Empty;

	public virtual int amount => CardManager.instance.data.cardData.ContainsKey(id) ? CardManager.instance.data.cardData[id].amount : 0;

	public virtual IEnumerator InitCard(bool isOpponentCard)
	{
		yield break;
	}

	public virtual void ReleaseCard(bool isOpponent)
	{
	}

	public void AddCard(int num = 1)
	{
		if (!CardManager.instance.data.cardData.ContainsKey(id))
		{
			CardManager.instance.data.cardData[id] = new CardManager.CardData
			{
				amount = num
			};
		}
		else
		{
			CardManager.instance.data.cardData[id].amount += num;
		}
	}

	public void AddTutorialCard()
	{
		if (!CardManager.instance.data.cardData.ContainsKey(id))
		{
			CardManager.instance.data.cardData[id] = new CardManager.CardData
			{
				amount = 1
			};
		}
		else
		{
			CardManager.instance.data.cardData[id].amount = 1;
		}
	}

	public virtual void RemoveCard()
	{
		if (CardManager.instance.data.cardData.ContainsKey(id))
		{
			if (CardManager.instance.data.cardData[id].amount == 0)
			{
				Debug.LogError($"Card {id} is being removed to minus values");
			}
			else
			{
				CardManager.instance.data.cardData[id].amount--;
			}
		}
	}

	public virtual void DisconnectEvents()
	{
	}

	public virtual void UseCard(ICardManager cardManager, Fractions fraction)
	{
	}

	public virtual bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		return true;
	}

	public virtual void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
	}

	public void SetUpSmallCard(UISprite background, UISprite cardIcon, UISprite cardBonusIcon, UILabel bonusLabel, UITexture cardTexture = null)
	{
		background.spriteName = CardBackground(rarity);
		background.color = CardBackgroundColor(rarity, background.alpha);
		if (iconName == string.Empty)
		{
			cardIcon.gameObject.SetActive(value: false);
			cardBonusIcon.gameObject.SetActive(value: false);
			bonusLabel.text = string.Empty;
			Debug.LogError("Card " + mCardNameID.ToUpper() + " does not have small variant look!!!!!");
		}
		else
		{
			cardIcon.gameObject.SetActive(!isBuddyCard);
			if (cardIcon.gameObject.activeSelf)
			{
				cardIcon.spriteName = iconName;
				cardIcon.MakePixelPerfect();
				cardIcon.transform.localScale = cardIcon.transform.localScale.MultiplyXY(iconMultiplier);
				cardIcon.transform.localPosition = smallCardPosition;
				cardIcon.transform.localRotation = Quaternion.Euler(0f, 0f, smallCardRotation);
			}
			if (cardTexture != null)
			{
				cardTexture.gameObject.SetActive(value: false);
				cardTexture.transform.localScale = new Vector3(220f, 220f, 1f);
				cardTexture.transform.localPosition = smallCardPosition;
			}
			cardBonusIcon.gameObject.SetActive(showBonusIconInSmallCard);
			if (isBuddyCard)
			{
				cardBonusIcon.color = Color.white;
				cardBonusIcon.spriteName = unitTypeSpriteName;
				cardBonusIcon.MakePixelPerfect();
				cardBonusIcon.transform.localScale = cardBonusIcon.transform.localScale.MultiplyXY(0.5f);
				cardBonusIcon.transform.localPosition = smallIconPosition;
			}
			else if (showBonusIconInSmallCard)
			{
				cardBonusIcon.color = bonusIconSmallCardColor;
				cardBonusIcon.spriteName = bonusIcon;
				cardBonusIcon.MakePixelPerfect();
				cardBonusIcon.transform.localPosition = smallIconPosition;
			}
			bonusLabel.text = mBonusName;
		}
		PositionForBonusName(bonusLabel);
	}

	private void PositionForBonusName(UILabel bonusLabel)
	{
		float num = bonusLabel.relativeSize.x * bonusLabel.transform.localScale.x;
		bonusLabel.transform.localPosition = bonusLabel.transform.localPosition.ReplaceX(-4f + Mathf.Max(0f, num - 90f));
	}

	public static string CardBigBackground(CardManager.CardType cardRarity)
	{
		return cardRarity switch
		{
			CardManager.CardType.Gold => "game-card-gold-big", 
			CardManager.CardType.Silver => "game-card-silver-big", 
			CardManager.CardType.Buddy => "game-card-silver-big", 
			_ => "game-card-bronze-big", 
		};
	}

	public static string CardBackground(CardManager.CardType cardRarity)
	{
		return cardRarity switch
		{
			CardManager.CardType.Gold => "game-card-gold", 
			CardManager.CardType.Silver => "game-card-silver", 
			CardManager.CardType.Buddy => "game-card-silver", 
			_ => "game-card-bronze", 
		};
	}

	public static Color CardBackgroundColor(CardManager.CardType cardRarity, float alpha = 1f)
	{
		Color result = ((cardRarity != CardManager.CardType.Buddy) ? Color.white : Colours.pink);
		result.a = alpha;
		return result;
	}

	public static string CardSmallIconBackground(CardManager.CardType cardRarity)
	{
		return cardRarity switch
		{
			CardManager.CardType.Gold => "game-card-ico-bg-gold", 
			CardManager.CardType.Silver => "game-card-ico-bg-silver", 
			CardManager.CardType.Buddy => "game-card-ico-bg-silver", 
			_ => "game-card-ico-bg-bronze", 
		};
	}

	public virtual void ShowInMenu()
	{
	}

	public virtual void HideInMenu()
	{
	}

	public void Init(CardDefinitionsRow cardDefinition)
	{
		mCardDefinition = cardDefinition;
	}
}
