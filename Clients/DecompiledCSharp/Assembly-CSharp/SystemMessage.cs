using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SystemMessage : DatabaseMessage
{
	public DateTime fromTime;

	private string date;

	private string fromString;

	private int utcTimeOfMaintenance;

	public SystemMessage(JToken dict)
		: base(dict)
	{
		utcTimeOfMaintenance = dict["Time"]["N"].ToObject<int>();
		fromTime = MiscTools.GetDateTime(utcTimeOfMaintenance).ToLocalTime();
		date = fromTime.ToString("D");
		fromString = fromTime.ToString("HH:mm");
	}

	public SystemMessage(DateTime time1)
		: base("SystemMessage", Type.SystemMessage)
	{
		fromTime = time1;
		date = fromTime.ToString("D");
		fromString = fromTime.ToString("HH:mm");
		messageId += date.ToString();
	}

	public override void Show()
	{
		base.Show();
		if (utcTimeOfMaintenance > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowSystemMaintenance(date, fromString);
		}
		else
		{
			Debug.Log("NOT SHOWING MAINTENANCE BECAUSE IT IS TOO LATE");
		}
		Ignore();
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_SystemMessage(messageType, messageTime, date);
		return delegate
		{
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowSystemMaintenance(date, fromString);
		};
	}
}
