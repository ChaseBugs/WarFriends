using System;
using Newtonsoft.Json.Linq;

public class CheatWarningMessage : DatabaseMessage
{
	public AntiCheatDetector.Cheat cheatType;

	public CheatWarningMessage(AntiCheatDetector.Cheat cheatTyp)
		: base("testingidcheat", Type.CheatWarning)
	{
		messageId += cheatTyp;
		cheatType = cheatTyp;
	}

	public CheatWarningMessage(JToken dict)
		: base(dict)
	{
		cheatType = dict["CheatType"]["N"].ToObject<AntiCheatDetector.Cheat>();
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		Ignore();
		switch (cheatType)
		{
		case AntiCheatDetector.Cheat.MemoryHack:
		case AntiCheatDetector.Cheat.PlayerPrefsHack:
			GameLoginManager.Relog();
			break;
		case AntiCheatDetector.Cheat.SpeedHack:
			break;
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_CheatWarning(messageType, messageTime, cheatType);
		return delegate
		{
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_GUI_CHEATINGMESSAGE", Colours.stringRed, Colours.stringWhite, cheatType), Localization.Localize("ID_GUI_CHEATWARNING"), 0f, null, string.Empty);
		};
	}
}
