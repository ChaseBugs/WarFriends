using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class Card : Core_BaseScript
{
	public const float baseShowCartIcoTimeInGame = 3f;

	[HideInInspector]
	public int playerId;

	[SerializeField]
	private string mCardNameID;

	[SerializeField]
	protected string mDescriptionID;

	public string iconName;

	public float iconMultiplier;

	public Vector3 bigCardPosition;

	public Color bonusIconBackgroundColor;

	public Color bonusIconColor;

	public float smallCardRotation;

	public Vector3 smallCardPosition;

	public Vector3 smallIconPosition;

	public string bonusIcon;

	public bool showBonusIconInSmallCard;

	public Color bonusIconSmallCardColor;

	public string bonusName;

	public string id;

	public float cooldown;

	public bool isEnemyPlayerBuff;

	private CardDefinitionsRow mCardDefinition;

	public virtual CardManager.CardType rarity => default(CardManager.CardType);

	public virtual int newFromMission => 0;

	public bool implemented => false;

	public int rarityNumber => 0;

	public bool isBuddyCard => false;

	public Texture2D iconTexture { get; protected set; }

	public virtual bool isHealing => false;

	public virtual bool showInGame => false;

	protected bool isOnlineMaster => false;

	public virtual string cardName => null;

	public virtual string description => null;

	public virtual string unitTypeSpriteName => null;

	protected virtual string mBonusName => null;

	public virtual int amount => 0;

	public virtual IEnumerator InitCard(bool isOpponentCard)
	{
		return null;
	}

	public virtual void ReleaseCard(bool isOpponent)
	{
	}

	public void AddCard(int num = 1)
	{
	}

	public void AddTutorialCard()
	{
	}

	public virtual void RemoveCard()
	{
	}

	public virtual void DisconnectEvents()
	{
	}

	public virtual void UseCard(BNAICKJBHFH cardManager, HPHFGNJPDKN fraction)
	{
	}

	public virtual bool IsViableForBotNow(HPHFGNJPDKN botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		return false;
	}

	public virtual void UseCardOnline(BNAICKJBHFH cardManager, HPHFGNJPDKN fraction)
	{
	}

	public void SetUpSmallCard(UISprite background, UISprite cardIcon, UISprite cardBonusIcon, UILabel bonusLabel, UITexture cardTexture = null, bool skipBuddyColorization = false)
	{
	}

	private void PositionForBonusName(UILabel bonusLabel)
	{
	}

	public static string CardBigBackground(CardManager.CardType cardRarity)
	{
		return null;
	}

	public static string CardBackground(CardManager.CardType cardRarity)
	{
		return null;
	}

	public static Color CardBackgroundColor(CardManager.CardType cardRarity, float alpha = 1f, bool skipBuddyColorization = true)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Color);
	}

	public static string CardSmallIconBackground(CardManager.CardType cardRarity)
	{
		return null;
	}

	public virtual void ShowInMenu()
	{
	}

	public virtual void HideInMenu()
	{
	}

	public void Init(CardDefinitionsRow cardDefinition)
	{
	}
}
