using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SquadWarsEndedMessage : DatabaseMessage
{
	public int position;

	public string squadName;

	public string squadIcon;

	public int goldReward;

	public int previousSquadDivision;

	public int newSquadDivision;

	public int squadsInWar;

	public List<DatabasePlayer> squadMembers;

	public bool showDialog;

	public SquadWarsEndedMessage(int squadPosition, int yourReward, int squadDivision, int squadNewDivision, int squadsCount, List<DatabasePlayer> members)
		: base("testingidsquadwarsend", Type.SquadWarEnd)
	{
		messageId += squadPosition;
		position = squadPosition;
		squadName = GameLoginManager.currentPlayer.squadName;
		squadIcon = "menu-squad-8";
		goldReward = yourReward;
		previousSquadDivision = squadDivision;
		newSquadDivision = squadNewDivision;
		squadsInWar = squadsCount;
		squadMembers = members;
		showDialog = true;
	}

	public SquadWarsEndedMessage(JToken dict)
		: base(dict)
	{
		if (dict["Position"] != null)
		{
			position = dict["Position"]["N"].ToObject<int>();
		}
		if (dict["SquadId"] != null)
		{
			squadName = dict["SquadId"]["S"].ToObject<string>();
		}
		if (dict["SquadIcon"] != null)
		{
			squadIcon = dict["SquadIcon"]["S"].ToObject<string>();
		}
		if (dict["RewardGold"] != null)
		{
			float num = dict["RewardGold"]["N"].ToObject<float>();
			if (num != Mathf.Round(num))
			{
				Debug.LogError("Squad Wars reward gold is FLOAT not INT!!! : " + num);
				goldReward = Mathf.FloorToInt(num);
			}
			else
			{
				goldReward = dict["RewardGold"]["N"].ToObject<int>();
			}
		}
		if (dict["PrevLevelId"] != null)
		{
			previousSquadDivision = dict["PrevLevelId"]["N"].ToObject<int>();
		}
		if (dict["NewLevelId"] != null)
		{
			newSquadDivision = dict["NewLevelId"]["N"].ToObject<int>();
		}
		squadMembers = new List<DatabasePlayer>();
		if (dict["SquadMembers"] != null)
		{
			JArray jArray = JsonConvert.DeserializeObject<JArray>(dict["SquadMembers"]["S"].ToObject<string>());
			foreach (JToken item2 in jArray)
			{
				DatabasePlayer item = DatabasePlayer.CreateFromDatabase(item2);
				squadMembers.Add(item);
			}
		}
		squadsInWar = 50;
		showDialog = true;
	}

	public override void OnAdd()
	{
		if (Singleton<MessageManager>.instance.lastRewardMessage != null)
		{
			Singleton<MessageManager>.instance.lastRewardMessage.showDialog = false;
		}
		Singleton<MessageManager>.instance.lastRewardMessage = this;
	}

	public override void Show()
	{
		base.Show();
		Singleton<BeanstalkServerManager>.instance.GetSquadDetails(squadName, checkCache: false);
		if (showDialog)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.ShowDialog(squadName, squadIcon, position, squadsInWar, goldReward, previousSquadDivision, newSquadDivision, squadMembers, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SquadWarsEnded(Type.SquadWarEnd, messageTime, position, goldReward, squadName);
		return delegate
		{
			Confirm();
		};
	}

	public override void Confirm()
	{
		Debug.Log($"SquadWarsFinishedMessage: Claiming gold: {goldReward}");
		Singleton<BeanstalkServerManager>.instance.ClaimReward(this);
	}
}
