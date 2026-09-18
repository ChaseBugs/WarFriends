using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadInviteMessage : DatabaseMessage
{
	public DatabaseSquad squad;

	public DatabasePlayer playerThatSendInvite;

	public int totalSize => squad.size + squad.GetPlacesLeft();

	public override bool canBeClickedInLobby => false;

	public override bool processNextMessage => true;

	public override bool canSquadTypeMessageBeRemovedWhenLeftSquad => false;

	public SquadInviteMessage(string squadName)
		: base("testingidsquadinvite", Type.SquadInvitation)
	{
		messageId += squadName;
		squad = new DatabaseSquad
		{
			name = squadName,
			skill = 1000,
			size = 5,
			message = "Testing squad invite MC",
			icon = "menu-squad-10",
			skillRequirement = 100,
			rank = 3
		};
		playerThatSendInvite = new DatabasePlayer
		{
			accountName = "Testing Player",
			level = 6,
			squadName = "Squad"
		};
	}

	public SquadInviteMessage(JToken dict)
		: base(dict)
	{
		if (dict["Squad"] != null)
		{
			JToken item = JsonConvert.DeserializeObject<JToken>(dict["Squad"]["S"].ToString());
			squad = DatabaseSquad.CreateFromDatabase(item);
		}
		else
		{
			squad = new DatabaseSquad();
		}
		if (dict["OtherPlayer"] != null)
		{
			JToken item2 = JsonConvert.DeserializeObject<JToken>(dict["OtherPlayer"]["S"].ToString());
			playerThatSendInvite = DatabasePlayer.CreateFromDatabase(item2);
		}
		else
		{
			playerThatSendInvite = new DatabasePlayer();
		}
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
	}

	public override void Confirm()
	{
		Singleton<BeanstalkServerManager>.instance.JoinSquad(squad.name, messageId);
		Debug.Log("Squad Invitation Accept!");
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadInvitation(messageType, messageTime, playerThatSendInvite);
		return delegate
		{
			FightDialog.ShowFightDialog(this, 0.2f);
		};
	}

	public override void UpdatePlayer(DatabasePlayerInfo player)
	{
		if (playerThatSendInvite.id == player.id)
		{
			playerThatSendInvite.level = player.level;
		}
	}
}
