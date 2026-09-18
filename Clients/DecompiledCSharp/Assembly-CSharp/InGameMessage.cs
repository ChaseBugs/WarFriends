using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class InGameMessage : DatabaseMessage
{
	public string translatedTitle;

	public string translatedSubtitle;

	public string translatedText;

	public float textSize;

	public DailyRewardMonthScreen.DailyRewardDataForDay[] rewards;

	public int deadline;

	public int creationTime;

	public bool isNew;

	public bool shouldShowAsDialog;

	public DateTime timeCreated => MiscTools.GetDateTime(creationTime).ToLocalTime();

	public InGameMessage(string title, string subtitle, string text, float size, DailyRewardMonthScreen.DailyRewardDataForDay[] rew)
		: base($"InGameMessage-{subtitle}", Type.InGameMessage)
	{
		translatedTitle = title;
		translatedSubtitle = subtitle;
		translatedText = text;
		textSize = size;
		rewards = rew;
		deadline = Singleton<BeanstalkServerManager>.instance.currentTimestamp + 604800;
		creationTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		isNew = true;
		shouldShowAsDialog = true;
	}

	public InGameMessage(JToken dict)
		: base(dict)
	{
		if (dict["Title"] != null)
		{
			translatedTitle = StringParser.ParseString("Title", "S", dict, string.Empty);
		}
		if (dict["FontSize"] != null)
		{
			textSize = StringParser.ParseFloatToken(dict["FontSize"]["N"], 0f);
		}
		if (dict["Subtitle"] != null)
		{
			translatedSubtitle = StringParser.ParseString("Subtitle", "S", dict, string.Empty);
		}
		if (dict["Text"] != null)
		{
			translatedText = StringParser.ParseString("Text", "S", dict, string.Empty);
		}
		List<DailyRewardMonthScreen.DailyRewardDataForDay> list = new List<DailyRewardMonthScreen.DailyRewardDataForDay>();
		if (dict["Rewards"] != null)
		{
			List<JToken> list2 = JsonConvert.DeserializeObject<List<JToken>>(StringParser.ParseString("Rewards", "S", dict, string.Empty));
			foreach (JToken item in list2)
			{
				list.Add(new DailyRewardMonthScreen.DailyRewardDataForDay(item));
			}
		}
		rewards = list.ToArray();
		if (dict["Deadline"] != null)
		{
			deadline = StringParser.ParseIntToken(dict["Deadline"]["N"]);
		}
		if (dict["CreationTime"] != null)
		{
			creationTime = StringParser.ParseIntToken(dict["CreationTime"]["N"]);
		}
		isNew = dict["ShowNew"] != null;
		shouldShowAsDialog = true;
	}

	public override void Show()
	{
		base.Show();
		if (CanBeShown())
		{
			if (shouldShowAsDialog && isNew)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			}
			else if (isNew)
			{
				GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessageWithoutNotification(this);
			}
			isNew = false;
		}
	}

	private bool CanBeShown()
	{
		if (rewards.Length > 0 && Singleton<BeanstalkServerManager>.instance.currentTimestamp > deadline)
		{
			Confirm();
			return false;
		}
		if (rewards.Length == 0 && creationTime + 2592000 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			Confirm();
			return false;
		}
		return true;
	}

	public override void Confirm()
	{
		Debug.Log(string.Format("InGameMessage: {0} Rewards - Claiming", (rewards.Length <= 0) ? "No" : "With"));
		Singleton<BeanstalkServerManager>.instance.ClaimReward(this);
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_InGameMessage(messageType, messageTime, isNew, translatedTitle, timeCreated);
		return delegate
		{
			if (CanBeShown())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			}
		};
	}
}
