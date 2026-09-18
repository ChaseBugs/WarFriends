using System;

public class DebugDialogs : Core_BaseScript
{
	public static int maxConfirmIndex = 106;

	public static int maxDialogIndex = 58;

	public static int TestConfirmDialogs(int index)
	{
		switch (index)
		{
		case 0:
			WarningDialog.ShowError(Localization.Localize("ID_PLAYERCANTJOINSQUAD"), Localization.LocalizeFormat("ID_ISALREADYMEMBEROFANOTHERSQUAD", "TestingName"), 0f, null, string.Empty);
			break;
		case 1:
			WarningDialog.ShowError(Localization.Localize("ID_COOPCANCELED"), Localization.Localize("ID_FRIENDREFUSEDREMATCHCOOP"), 0f, null, string.Empty);
			break;
		case 2:
			WarningDialog.ShowError(Localization.Localize("ID_BATTLECANCELED"), Localization.Localize("ID_OPPONENTREFUSEDTHEREMATCH"), 0f, null, string.Empty);
			break;
		case 3:
			WarningDialog.ShowChoice(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_INAPP_VALIDATION"), Localization.Localize("ID_CONFIRM_RESTORE"), Localization.Localize("ID_CANCEL"), null);
			break;
		case 4:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
			break;
		case 5:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
			break;
		case 6:
			WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, useDialogBackground: true);
			break;
		case 7:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTCREATESQUAD_TEXT"), Localization.Localize("ID_WARNING_CANNOTCREATESQUAD"), 0f, null, string.Empty);
			break;
		case 8:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ALREADYLEADER"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 9:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_SERVERDATA"), Localization.Localize("ID_SQUADEVENT"), 0f, null, string.Empty);
			break;
		case 10:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
			break;
		case 11:
			WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_ASSIGNMENTUPDATE"), 0f, null, string.Empty, useDialogBackground: true);
			break;
		case 12:
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_CONFIRM_STARTUPERROR_TEXT", "exception message"), Localization.Localize("ID_CONFIRM_STARTUPERROR"), 0f, null, string.Empty);
			break;
		case 13:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SERVERERROR_TEXT"), Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, null, string.Empty);
			break;
		case 14:
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_WARNING_BADVERSIONERROR_TEXT", "old_version", Singleton<CurrentBundleVersion>.instance.photonVersion), Localization.Localize("ID_WARNING_BADVERSIONERROR"), 0f, null, string.Empty);
			break;
		case 15:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_UNKNOWNREASON"), Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, null, string.Empty);
			break;
		case 16:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SERVERDIDNTRESPONDAFTER"), Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, null, string.Empty);
			break;
		case 17:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_GAMEDIDNTEXIST"), Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, null, string.Empty);
			break;
		case 18:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_GAMELAREADYENDED"), Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, null, string.Empty);
			break;
		case 19:
			WarningDialog.ShowError(string.Format("{0} {1}.", Localization.Localize("ID_CONFIRM_OTHERSERVERRESPONDERROR"), 404), Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, null, string.Empty);
			break;
		case 20:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_OPPONENTCANCELLED"), Localization.Localize("ID_WARNING_OPPONENTDISCONNECTED"), 0f, null, string.Empty);
			break;
		case 21:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_GAMEDOESNOTEXIST"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 22:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_INAPP_FAILED"), Localization.Localize("ID_CONFIRM_PURCHASEFAILED"), 0f, null, string.Empty);
			break;
		case 23:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CLICKOKTORESEND"), Localization.Localize("ID_WARNING_SERVERTIMEDOUT"), 0f, null, string.Empty);
			break;
		case 24:
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_GUI_CHEATINGMESSAGE", Colours.stringRed, Colours.stringWhite, AntiCheatDetector.Cheat.JailBreak), Localization.Localize("ID_GUI_CHEATWARNING"), 0f, null, string.Empty);
			break;
		case 25:
			WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_EVENTASSIGNMENTUPDATE"), 0f, null, string.Empty);
			break;
		case 26:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_FAILTORESTORE"), Localization.Localize("ID_WARNING_RESTOREERROR"), 0f, null, string.Empty, useDialogBackground: true);
			break;
		case 27:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CONNECTIONERROR_TEXT"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, null, Localization.Localize("ID_RETRY"), useDialogBackground: true);
			break;
		case 28:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_MAINTENANCE_TEXT"), Localization.Localize("ID_WARNING_MAINTENANCE"), 0f, null, Localization.Localize("ID_RETRY"), useDialogBackground: true);
			break;
		case 29:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADNAMETAKEN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 30:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WARCARDNOTFOUNDINCOLLECTION"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 31:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ALREADYCRAFTING"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 32:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_BUDDYCARDNOTREADY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 33:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CRAFTINGCLAIMNOTREADY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 34:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 35:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADALREADYEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 36:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTASSIGNMENTS_TEXT"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 37:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADJOINREQUESTNOTEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 38:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTENOUGHMEDALSTOJOIN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 39:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTFORQUESTACCOUNTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 40:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADISFULL"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 41:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_JOININGSAMESQUAD"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 42:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADNOTEMPTY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 43:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADLEAVEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 44:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PLAYERNAMETAKEN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 45:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PLAYERALREADYEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 46:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 47:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ONLYLEADERSCANINVITE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 48:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOSUCHPACK"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 49:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SERVERDIDNOTRESPOND"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 50:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTENOUGHDOGTAGS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 51:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ERRORCLAIMREWARD_TEXT"), Localization.Localize("ID_CONFIRM_ERRORCLAIMREWARD"), 0f, null, string.Empty);
			break;
		case 52:
		{
			string id2 = GameLoginManager.currentPlayer.id;
			string text3 = GameLoginManager.currentPlayer.name;
			string text4 = Localization.LocalizeFormat("ID_CONFIRM_TEMPORARBAN", id2, text3, MiscTools.PrintableTimeLongForm(89120f));
			WarningDialog.ShowError(text4, Localization.Localize("ID_CONFIRM_ACCOUNTBANNED"), 0f, null, Localization.Localize("ID_RETRY"), useDialogBackground: true);
			break;
		}
		case 53:
		{
			string id = GameLoginManager.currentPlayer.id;
			string text = GameLoginManager.currentPlayer.name;
			string text2 = Localization.LocalizeFormat("ID_CONFIRM_PERMANENTBAN", id, text);
			WarningDialog.ShowError(text2, Localization.Localize("ID_CONFIRM_ACCOUNTBANNED"), 0f, null, Localization.Localize("ID_RETRY"), useDialogBackground: true);
			break;
		}
		case 54:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CLICKOKTORESEND"), Localization.Localize("ID_WARNING_SERVERTIMEDOUT"), 0f, null, string.Empty);
			break;
		case 55:
			WarningDialog.ShowError(string.Format("{0} {1}", Localization.Localize("ID_CONFIRM_SERVERCOULDNOTCOMPLETED"), "reguest buffer error message"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 56:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT"), Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT"), 0f, null, string.Empty, useDialogBackground: true);
			break;
		case 57:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT"), Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT"), 0f, null, string.Empty, useDialogBackground: true);
			break;
		case 58:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ACCOUNTALREADYCREATED"), Localization.Localize("ID_WARNING_LOGINERROR"), 0f, null, string.Empty);
			break;
		case 59:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTLEVEL"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case 60:
			ConfirmDialog.ShowChoice(Localization.Localize("ID_CONFIRM_STARTTUTORIAL"), string.Empty, null, Localization.Localize("ID_CONFIRM_RESUME"), Localization.Localize("ID_CONFIRM_STARTOVER"));
			break;
		case 61:
			ConfirmDialog.ShowChoice(Localization.Localize("ID_CONFIRM_EXIT"), Localization.Localize("ID_CONFIRM_EXITWARFRIENDS"), null, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
			break;
		case 62:
			ConfirmDialog.ShowChoice(Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TITLE"), Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT1"), null, Localization.Localize("ID_CREATE"), Localization.Localize("ID_LOGOUT"));
			break;
		case 63:
			ConfirmDialog.ShowChoice(Localization.Localize("ID_CONFIRM_GAMECENTER"), Localization.Localize("ID_CONFIRM_GAMECENTERNAMETEXT"), null, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
			break;
		case 64:
			ConfirmDialog.ShowChoice(Localization.Localize("ID_CONFIRM_CONNECTTOGOOGLENAME"), Localization.Localize("ID_CONFIRM_CONNECTTOGOOGLENAMETEXT"), null, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
			break;
		case 65:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LANGUAGECHANGE"), Localization.LocalizeFormat("ID_CONFIRM_LANGUAGECHANGE_TEXT", Localization.Localize("ID_ENGLISH"), Localization.Localize("ID_GERMAN")), null, 0f);
			break;
		case 66:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_JOININGSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_JOININGSQUAD_TEXT", Colours.stringBlue, "squad name", Colours.stringWhite), null, 0f);
			break;
		case 67:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_EXITINGMATCH"), Localization.Localize("ID_CONFIRM_EXITINGMATCH_TEXT"), null, 0.2f);
			break;
		case 68:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_EXITINGMATCH"), Localization.Localize("ID_CONFIRM_EXITINGMATCHNODOGTAG_TEXT"), null, 0.2f);
			break;
		case 69:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_EXITINGCOOP"), Localization.Localize("ID_CONFIRM_EXITINGCOOP_TEXT"), null, 0.2f);
			break;
		case 70:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_EXITINGCOOP"), Localization.Localize("ID_CONFIRM_EXITINGCOOPNODOGTAG_TEXT"), null, 0.2f);
			break;
		case 71:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_LEAVE_SPECTATE"), Localization.Localize("ID_CONFIRM_LEAVE_SPECTATE_TEXT"), null, 0f);
			break;
		case 72:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_FORFEIT"), Localization.Localize("ID_CONFIRM_FORFEIT_TEXT"), null, 0f);
			break;
		case 73:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_RESTART"), Localization.Localize("ID_CONFIRM_RESTART_TEXT"), null, 0f);
			break;
		case 74:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_JOININGSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_JOININGSQUAD_TEXT", Colours.stringBlue, "squad name", Colours.stringWhite), null, 0f);
			break;
		case 75:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_PROMOTETOLEADER"), Localization.LocalizeFormat("ID_CONFIRM_PROMOTETOLEADER_TEXT", "player name"), null, 0f);
			break;
		case 76:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_KICKPLAYER"), Localization.LocalizeFormat("ID_CONFIRM_KICKPLAYER_TEXT", "squad member name"), null, 0f);
			break;
		case 77:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_DELETESQUAD"), Localization.Localize("ID_CONFIRM_DELETESQUAD_TEXT"), null, 0f);
			break;
		case 78:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.LocalizeFormat("ID_CONFIRM_LEAVESQUADLEADER_TEXT", "player name"), null, 0f);
			break;
		case 79:
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.Localize("ID_CONFIRM_LEAVESQUAD_TEXT"), null, 0f);
			break;
		case 80:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERTOOSHORTNAME"), 0f);
			break;
		case 81:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERTOOSHORTDURATION"), 0f);
			break;
		case 82:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERWRONGDISCOUNT"), 0f);
			break;
		case 83:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL"), Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL_TEXT"), 0.4f);
			break;
		case 84:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADFULL"), Localization.LocalizeFormat("ID_CONFIRM_SQUADFULL_TEXT", Colours.stringBlue, "squad name", Colours.stringWhite), 0f);
			break;
		case 85:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_FRIENDINSQUAD_TEXT", "friend name"), 0f);
			break;
		case 86:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADFULL"), Localization.Localize("ID_CONFIRM_SQUADISALREADYFULL"), 0f);
			break;
		case 87:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_SQUADEVENT"), Localization.Localize("ID_CONFIRM_SQUADEVENT_TEXT"), 0f);
			break;
		case 88:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_FRIENDINSQUAD_TEXT", "friend name"), 0f);
			break;
		case 89:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_RESTORE"), Localization.Localize("ID_CONFIRM_TRANSACTIONSRESTORED"), 0f);
			break;
		case 90:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_WARCARDNOTAVAILABLE"), Localization.Localize("ID_CONFIRM_SELECTEDWARCARDWASALREADY"), 0f);
			break;
		case 91:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC"), Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC_TEXT"), 0f);
			break;
		case 92:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_NOTLEADEROFSQUAD"), Localization.Localize("ID_CONFIRM_NOTLEADEROFSQUAD_TEXT"), 0f);
			break;
		case 93:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL"), Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT"), 0f);
			break;
		case 94:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_JOINSQUADEVENT"), Localization.Localize("ID_CONFIRM_NOTACTIVEEVENT"), 0f);
			break;
		case 95:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_THANKYOU"), Localization.Localize("ID_CONFIRM_THANKYOUPURCHASE"), 0f);
			break;
		case 96:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_CONFIRM_OPPONENTCANCELLED"));
			break;
		case 97:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_CONFIRM_MAXCCUREACHED"));
			break;
		case 98:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_YOUWEREDISCONNECTED"));
			break;
		case 99:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_JOINSQUADEVENT"), Localization.Localize("ID_CONFIRM_WRONGPLAYERDATA"));
			break;
		case 100:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_LOGINFAILURE"), Localization.Localize("ID_CONFIRM_LOGINFAILURE_TEXT"));
			break;
		case 101:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_LOGGEDOUT"), Localization.Localize("ID_CONFIRM_LOGGEDOUT_TEXT"));
			break;
		case 102:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_PLAYERNOTEXISTS"), Localization.Localize("ID_CONFIRM_PLAYERNOTEXISTS_TEXT"));
			break;
		case 103:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_FBLOGINCANCELLED"), Localization.Localize("ID_CONFIRM_FBLOGINCANCELLED_TEXT"));
			break;
		case 104:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_RELOG_TO_FB_DIALOG_TITLE"), Localization.LocalizeFormat("ID_RELOG_TO_FB_DIALOG_TEXT", "facebook name"));
			break;
		case 105:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_GC_LOGIN_TUTORIAL_TITLE"), Localization.Localize("ID_GC_LOGIN_TUTORIAL_TEXT"));
			break;
		case 106:
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_GC_LOGOUT_TITLE"), Localization.Localize("ID_GC_LOGOUT_TEXT"));
			break;
		}
		return (index < maxConfirmIndex) ? (index + 1) : 0;
	}

	public static int TestAllVariantDialogs(int index)
	{
		switch (index)
		{
		case 0:
			Singleton<MessageManager>.instance.AddMessage(new UnitCategoriesReminder());
			break;
		case 1:
			Singleton<MessageManager>.instance.AddMessage(new DailyAssignmentsReminder(2));
			break;
		case 2:
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 0f);
			break;
		case 3:
			ChatAbuseDialog.ShowAbuseDialog(GameLoginManager.currentPlayer.id, "testing message for abuse dialog");
			break;
		case 4:
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(AccountType.GameCenter, null, "GameCenterName", 16, 1234, string.Empty);
			break;
		case 5:
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(AccountType.Facebook, null, "FacebookName", 22, 789, string.Empty);
			break;
		case 6:
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(AccountType.GooglePlay, null, "GooglePlayName", 11, 678, string.Empty);
			break;
		case 7:
			Singleton<MessageManager>.instance.AddMessage(new DailyRentalMessage(LevelManager.instance.weaponLevelsSetups[6].GetSheetName(), 1, GameItem.Weapon, isOnSale: false, "weapon0"));
			Singleton<MessageManager>.instance.AddMessage(new DailyRentalMessage(LevelManager.instance.behaviours[8].upgradeSlots.GetSheetName(), 1, GameItem.ArmyUnit, isOnSale: false, "unit0"));
			Singleton<MessageManager>.instance.AddMessage(new DailyRentalMessage(LevelManager.instance.weaponLevelsSetups[32].GetSheetName(), 14, GameItem.Weapon, isOnSale: true, "weapon1"));
			Singleton<MessageManager>.instance.AddMessage(new DailyRentalMessage(LevelManager.instance.behaviours[12].upgradeSlots.GetSheetName(), 10, GameItem.ArmyUnit, isOnSale: true, "unit1"));
			break;
		case 8:
			GuiElementSingle<DailyVIPCardsScreen>.instance.ShowDialogWithCards("ROCKETTURRET", "AIRSTRIKE");
			break;
		case 9:
			Singleton<MessageManager>.instance.AddMessage(new EnablePushNotificationMessage());
			break;
		case 10:
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsInSystemDialog>.instance, 0.2f);
			break;
		case 11:
			GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(null);
			break;
		case 12:
			GuiElementSingle<FacebookDialog>.instance.ShowLogoutDialog(newAccount: false, null);
			break;
		case 13:
			Singleton<MessageManager>.instance.AddMessage(new BeAdvisedConnectFacebook());
			break;
		case 14:
			Singleton<MessageManager>.instance.AddMessage(new ChallengeMessage(fakeFight: true, isHeroicCoop: false));
			Singleton<MessageManager>.instance.AddMessage(new ChallengeMessage(fakeFight: false, isHeroicCoop: false));
			Singleton<MessageManager>.instance.AddMessage(new ChallengeMessage(fakeFight: false, isHeroicCoop: true));
			Singleton<MessageManager>.instance.AddMessage(new SquadInviteMessage("SquadName"));
			break;
		case 15:
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance, 0f);
			break;
		case 16:
		{
			DailyRewardMonthScreen.DailyRewardDataForDay[] rew = new DailyRewardMonthScreen.DailyRewardDataForDay[0];
			Singleton<MessageManager>.instance.AddMessage(new InGameMessage("TEST", "subtitle", "main text - unimportatnt", 65f, rew));
			break;
		}
		case 17:
			GuiElementSingle<InvitationFailedDialog>.instance.ShowDialog(InvitationState.Denied);
			break;
		case 18:
			Singleton<MessageManager>.instance.AddMessage(new BeAdvisedJoinOrCreateSquad());
			break;
		case 19:
			GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog("squadName");
			break;
		case 20:
			Singleton<MessageManager>.instance.AddMessage(new LeagueEnterMessage(GameLoginManager.currentPlayer.leagueTier, firstTimeInLeagues: false));
			Singleton<MessageManager>.instance.AddMessage(new LeagueEnterMessage(League.Bronze2, firstTimeInLeagues: true));
			Singleton<MessageManager>.instance.AddMessage(new LeagueEnterMessage(2));
			Singleton<MessageManager>.instance.AddMessage(new LeagueEnterMessage(League.Silver3));
			break;
		case 21:
			GuiElementSingle<LeagueResultDialog>.instance.ShowDialog(League.Bronze1, League.Silver3, 92);
			break;
		case 22:
			GuiElementSingle<LeagueResultDialog>.instance.ShowDialog(League.Gold3, League.Silver1, 4);
			break;
		case 23:
			GuiElementSingle<LeagueResultDialog>.instance.ShowDialog(League.Master1, League.Master1, 45);
			break;
		case 24:
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 0f);
			break;
		case 25:
			Singleton<MessageManager>.instance.AddMessage(new NameChangeReminder());
			break;
		case 26:
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(15, "Test");
			break;
		case 27:
			GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog("squadName", 2222, GameLoginManager.currentPlayer.skill);
			break;
		case 28:
			Singleton<MessageManager>.instance.AddMessage(new SpecialOfferMessage(LevelManager.instance.behaviours[4].upgradeSlots.GetSheetName(), 50, OfferBuyType.Buy));
			Singleton<MessageManager>.instance.AddMessage(new SpecialOfferMessage(LevelManager.instance.weaponLevelsSetups[6].GetSheetName(), 60, OfferBuyType.Buy));
			break;
		case 29:
			Singleton<MessageManager>.instance.AddMessage(new RateAppMessage(Singleton<CurrentBundleVersion>.instance.version, 0, updated: false));
			break;
		case 30:
			Singleton<MessageManager>.instance.AddMessage(new BuyCardsReminder());
			Singleton<MessageManager>.instance.AddMessage(new UpgradeUnitReminder(LevelManager.instance.behaviours[3]));
			Singleton<MessageManager>.instance.AddMessage(new UpgradeWeaponReminder(LevelManager.instance.weaponLevelsSetups[5]));
			Singleton<MessageManager>.instance.AddMessage(new VIPMemeberShipAlmostEnded());
			break;
		case 31:
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.CardPack, CardPack.Gold, new Card[1] { CardManager.instance.GetCardInstance("HEAVYTURRET") }));
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.WarCard, "HEAVYTURRET"));
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Dogtag));
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Warbucks, 10000L));
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Gold, 10L));
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Tickets, 1000L));
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.VIP, 1440L));
			Singleton<MessageManager>.instance.AddMessage(new DailyGoldBoosterMessage(654L, 0, "gold7daily1" + (Singleton<BeanstalkServerManager>.instance.currentTimestamp + 7)));
			break;
		case 32:
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, 0f);
			break;
		case 33:
			Singleton<MessageManager>.instance.AddMessage(new SquadWarsEndedMessage(2, 277, 4, 5, 50, Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName, ommitTime: true)));
			break;
		case 34:
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadWarHintDialog>.instance, 0f);
			break;
		case 35:
			Singleton<MessageManager>.instance.AddMessage(new DailyAssignmentsReminder(1));
			break;
		case 36:
			Singleton<MessageManager>.instance.AddMessage(new StarterAssignmentsReward(new Card[1] { CardManager.instance.GetCardInstance("HEAVYTURRET") }));
			break;
		case 37:
			Singleton<MessageManager>.instance.AddMessage(new SystemMessage(DateTime.Now));
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowBannedFromChat(permanent: false, 97202);
			break;
		case 38:
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowBannedFromChat(permanent: true, 10000);
			break;
		case 39:
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<CustomizationsTutorial>.instance, 0f);
			break;
		case 40:
			Singleton<MessageManager>.instance.AddMessage(new WeaponTutorialDialogMessage(LevelManager.instance.weaponLevelsSetups[4]));
			break;
		case 41:
			GuiElementSingle<CardpoolTutorialDialog>.instance.ShowDialog();
			break;
		case 42:
			Singleton<MessageManager>.instance.AddMessage(new ChatTutorialMessage());
			break;
		case 43:
			GuiElementSingle<UnitPromotedDialog>.instance.ShowDialog(LevelManager.instance.behaviours[5]);
			break;
		case 44:
			Singleton<MessageManager>.instance.AddMessage(new UnitReadyForPromotion(LevelManager.instance.behaviours[12]));
			break;
		case 45:
			Singleton<MessageManager>.instance.AddMessage(new WelcomeBackSoldierMessage("lapsed_player_2"));
			break;
		case 46:
		{
			PlayerVisual visual = CamosManager.instance.GetVisual("HELMETS_CROWNSILVER");
			Singleton<MessageManager>.instance.AddMessage(new ArenaVisualMessage(visual, 8));
			break;
		}
		case 47:
			Singleton<MessageManager>.instance.AddMessage(new ArenaGoldenShieldMessage(259200, 9));
			break;
		case 48:
			Singleton<MessageManager>.instance.AddMessage(new ArenaLostMessage(74, arenaExpired: false));
			Singleton<MessageManager>.instance.AddMessage(new ArenaLostMessage(86, arenaExpired: true));
			break;
		case 49:
			GuiElementSingle<ArenaOpenedDialog>.instance.ShowDialog();
			break;
		case 50:
			Singleton<MessageManager>.instance.AddMessage(new ArenaUnlockedMessage());
			break;
		case 51:
			Singleton<MessageManager>.instance.AddMessage(new ArenaWonMessage(7, isFlawless: true));
			break;
		case 52:
			Singleton<MessageManager>.instance.AddMessage(new ArenaWonMessage(7, isFlawless: false));
			break;
		case 53:
			GuiElementSingle<BuyTicketsDialog>.instance.ShowDialog(33L, BuyTicketType.BuyHearth);
			break;
		case 54:
			GuiElementSingle<BuyTicketsDialog>.instance.ShowDialog(11L, BuyTicketType.EnterArena);
			break;
		case 55:
			GuiElementSingle<ConvertToScrapsDialog>.instance.ShowDialog(LevelManager.instance.Unit("Google2u.DBUpgradeSlotsShotgunner"), null);
			break;
		case 56:
			GuiElementSingle<EliteUnitPreviewDialog>.instance.ShowDialog(LevelManager.instance.Unit("Google2u.DBUpgradeSlotsShotgunner"));
			break;
		case 57:
			Singleton<MessageManager>.instance.AddMessage(new InstantBattleUnlockedMessage());
			break;
		case 58:
			Singleton<MessageManager>.instance.AddMessage(new ElitePerkTutorialMessage());
			break;
		}
		return (index < maxDialogIndex) ? (index + 1) : 0;
	}
}
