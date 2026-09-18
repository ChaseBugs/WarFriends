using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AwaitingSquadMembersManager : Singleton<AwaitingSquadMembersManager>
{
	public class AwaitingMember
	{
		public DatabasePlayer player;

		public AwaitingState state;

		public DatabaseMessage messageCenterMessage;
	}

	[HideInInspector]
	public Dictionary<string, AwaitingMember> listOfMembers = new Dictionary<string, AwaitingMember>();

	protected override void Awake()
	{
		base.Awake();
		GameLoginManager.instance.PlayerLeftSquad += OnPlayerLeftSquad;
	}

	public void OnPlayerAcceptedOrDeclined(string id, bool updateGUI)
	{
		if (listOfMembers.ContainsKey(id))
		{
			RemovePlayer(id);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in listOfMembers.Keys)
			{
				stringBuilder.AppendLine(key);
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (updateGUI)
		{
			UpdateGUI(id);
			UpdateListOfAwaitingMembers(force: false);
		}
	}

	private void OnPlayerLeftSquad()
	{
		if (listOfMembers != null)
		{
			listOfMembers.Clear();
		}
	}

	private void UpdateGUI(string playerId = null)
	{
		if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<SquadScreen>.instance)
		{
			GuiScreenSingle<SquadScreen>.instance.InitGUIValues();
		}
		GuiElementSingle<ChatGuiElement>.instance.messageContent.UpdateMessageCenterMessage(playerId);
	}

	public void YesClick(string playerId)
	{
		if (!listOfMembers.ContainsKey(playerId))
		{
			Debug.Log($"Awaiting players - Player id:\"{playerId}\" is not in list of awaiting members - cannot accept player");
			return;
		}
		listOfMembers[playerId].state = AwaitingState.Waiting;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.AcceptSquadJoinRequest(playerId, currentPlayer.squadName);
	}

	public void NoClick(string playerId)
	{
		if (!listOfMembers.ContainsKey(playerId))
		{
			Debug.Log($"Awaiting players - Player id:\"{playerId}\" is not in list of awaiting members - cannot decline player");
			return;
		}
		listOfMembers[playerId].state = AwaitingState.Waiting;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.DeclineSquadJoinRequest(playerId, currentPlayer.squadName);
	}

	public void UpdateListOfAwaitingMembers(bool force = true)
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(squadName, force);
		}
	}

	public AwaitingState MemberState(string playerId)
	{
		if (string.IsNullOrEmpty(playerId) || !listOfMembers.ContainsKey(playerId))
		{
			return AwaitingState.Error;
		}
		return listOfMembers[playerId].state;
	}

	public void AddAwaitingMember(DatabasePlayer player)
	{
		if (listOfMembers.ContainsKey(player.id))
		{
			Debug.Log($"Awaiting players - Player \"{player.name}\" is already in list of awaiting members with state {listOfMembers[player.id].state.ToString().ToUpper()}");
			return;
		}
		AwaitingMember awaitingMember = new AwaitingMember();
		awaitingMember.player = player;
		awaitingMember.player.awaitingSquadMember = true;
		awaitingMember.state = AwaitingState.Response;
		awaitingMember.messageCenterMessage = null;
		Debug.Log("Awaiting players - Adding player " + player.id);
		listOfMembers.Add(player.id, awaitingMember);
	}

	public void AddToMC(SquadJoinRequest databaseMessage)
	{
		string id = databaseMessage.player.id;
		if (!listOfMembers.ContainsKey(id))
		{
			Debug.Log($"Awaiting players - Player id:\"{id}\" is not in list of awaiting members");
			return;
		}
		if (listOfMembers[id].messageCenterMessage != null)
		{
			Debug.Log($"Awaiting players - Player id:\"{id}\" already added to message center");
			return;
		}
		listOfMembers[id].messageCenterMessage = databaseMessage;
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(databaseMessage);
	}

	public void RemoveErrorPlayers()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, AwaitingMember> listOfMember in listOfMembers)
		{
			if (listOfMember.Value.state == AwaitingState.Error)
			{
				string text = RemovePlayer(listOfMember.Key, removeNow: false);
				if (text != null)
				{
					list.Add(text);
				}
			}
		}
		bool force = list.Count > 1;
		foreach (string item in list)
		{
			Debug.Log("Awaiting players - Removing player " + item);
			listOfMembers.Remove(item);
		}
		UpdateListOfAwaitingMembers(force);
	}

	public string RemovePlayer(string playerId, bool removeNow = true)
	{
		if (!listOfMembers.ContainsKey(playerId))
		{
			Debug.Log($"Awaiting players - Player id:\"{playerId}\" is not in list of awaiting members - cannot remove it");
			return null;
		}
		RemoveFromMCAndChat(playerId);
		if (removeNow)
		{
			Debug.Log("Awaiting players - Removing player " + playerId);
			listOfMembers.Remove(playerId);
		}
		Debug.Log("Awaiting players - Player was removed from awaiting members.");
		return playerId;
	}

	private void RemoveFromMCAndChat(string playerId)
	{
		if (!listOfMembers.ContainsKey(playerId))
		{
			Debug.Log($"Awaiting players - Player id:\"{playerId}\" is not in list of awaiting members - cannot remove it from MC");
			return;
		}
		if (listOfMembers[playerId].messageCenterMessage == null)
		{
			Debug.Log($"Awaiting players - Player id:\"{playerId}\" was not added to message center - cannot remove it from MC");
			return;
		}
		GuiElementSingle<ChatGuiElement>.instance.messageContent.RemoveMessage(listOfMembers[playerId].messageCenterMessage);
		listOfMembers[playerId].messageCenterMessage = null;
	}
}
