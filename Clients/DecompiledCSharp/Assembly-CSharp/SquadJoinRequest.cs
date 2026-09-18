using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadJoinRequest : DatabaseMessage
{
	public DatabasePlayer player;

	public override bool canBeClickedInLobby => false;

	public override bool processNextMessage => true;

	public SquadJoinRequest()
		: base("testingidsquadjoinrequest", Type.SquadJoinRequest)
	{
		player = new DatabasePlayer();
		player.accountName = "Testing Player";
		player.level = 6;
		player.squadName = string.Empty;
		player.skill = 678;
		player.armyPower = 555;
		player.id = "testingPlayerId";
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
	}

	public SquadJoinRequest(JToken dict)
		: base(dict)
	{
		JToken item = JsonConvert.DeserializeObject<JToken>(dict["Player"]["S"].ToString());
		player = DatabasePlayer.CreateFromDatabase(item);
		Debug.Log("Player wants to join squad, name =" + player.name + ", squadId = " + playerId);
		messageTime = dict["Time"]["N"].ToObject<int>();
	}

	public override void Show()
	{
		base.Show();
		Singleton<AwaitingSquadMembersManager>.instance.UpdateListOfAwaitingMembers();
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_AcceptPlayer(messageType, messageTime, player);
		return delegate
		{
			if (!record.yesButton.gameObject.activeInHierarchy && !record.noButton.gameObject.activeInHierarchy)
			{
				Singleton<AwaitingSquadMembersManager>.instance.RemovePlayer(player.id);
				if (GuiScreenSingle<SquadScreen>.instance.isShowed && GuiScreenSingle<SquadScreen>.instance.memberContent.gameObject.activeSelf)
				{
					GuiScreenSingle<SquadScreen>.instance.memberContent.InitGUIValues();
				}
			}
		};
	}

	public override void UpdatePlayer(DatabasePlayerInfo playerToUpdate)
	{
		if (player.id == playerToUpdate.id)
		{
			player.level = playerToUpdate.level;
			player.skill = playerToUpdate.skill;
			player.armyPower = playerToUpdate.armyPower;
			player.squadName = playerToUpdate.squadName;
			player.leagueTier = playerToUpdate.leagueTier;
			player.remainingMatches = playerToUpdate.remainingMatches;
		}
	}

	public override void Confirm()
	{
		Debug.Log("Hiding request to join private squad");
	}
}
