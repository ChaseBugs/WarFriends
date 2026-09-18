using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WithdrewWarcard : DatabaseMessage
{
	public DatabasePlayer player;

	public Card withdrewCard;

	public int addedPoints;

	public string cardId;

	public CardManager.BuddyCardData buddyData;

	public string idOfPlayer;

	public override bool actionLeavesLobby => true;

	public override bool processNextMessage => true;

	public WithdrewWarcard(Card card, DatabasePlayer playerData, int reputationPointsAdded)
		: base($"WithdrewWarcard-{card.id}-{playerData.name}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.SquadDepositedCardsChanged)
	{
		player = playerData;
		withdrewCard = card;
		cardId = card.id;
		if (card.isBuddyCard)
		{
			buddyData = (card as CardBuddy).buddyCardData;
		}
		addedPoints = reputationPointsAdded;
	}

	public WithdrewWarcard(JToken dict)
		: base(dict)
	{
		player = new DatabasePlayer();
		if (dict["PlayerName"] != null)
		{
			player.accountName = StringParser.ParseString("PlayerName", "S", dict, string.Empty);
		}
		if (dict["Level"] != null)
		{
			player.level = StringParser.ParseIntToken(dict["Level"]["N"]);
		}
		if (dict["SquadId"] != null)
		{
			player.squadName = StringParser.ParseString("SquadId", "S", dict, string.Empty);
		}
		if (dict["SquadRank"] != null)
		{
			player.squadRank = (SquadRank)StringParser.ParseIntToken(dict["SquadRank"]["N"]);
		}
		if (dict["WithdrawerId"] != null)
		{
			player.id = StringParser.ParseString("WithdrawerId", "S", dict, string.Empty);
		}
		if (dict["OtherPlayerId"] != null)
		{
			idOfPlayer = StringParser.ParseString("OtherPlayerId", "S", dict, string.Empty);
		}
		if (dict["CardId"] != null)
		{
			cardId = StringParser.ParseString("CardId", "S", dict, string.Empty);
			if (dict["BuddyCardData"] != null)
			{
				buddyData = JsonConvert.DeserializeObject<CardManager.BuddyCardData>(StringParser.ParseString("BuddyCardData", "S", dict, string.Empty));
				withdrewCard = CardManager.instance.GetSquadCardInstance(cardId, buddyData);
			}
			else
			{
				withdrewCard = CardManager.instance.GetCardInstance(cardId);
			}
		}
		if (dict["ReputationPointsAdded"] != null)
		{
			addedPoints = StringParser.ParseIntToken(dict["ReputationPointsAdded"]["N"]);
		}
	}

	public override void Show()
	{
		base.Show();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log($"Withdrew Warcard message - Showing for player:{idOfPlayer} and current player id is:{GameLoginManager.currentPlayer.id}");
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = idOfPlayer == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = 60 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - messageTime);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > messageTime;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(squadName, forceUpdate: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(cardId);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			Confirm();
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_WarcardWithdrew(messageType, messageTime, player, withdrewCard, addedPoints);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			Confirm();
		};
	}

	public override void Confirm()
	{
		Ignore();
	}
}
