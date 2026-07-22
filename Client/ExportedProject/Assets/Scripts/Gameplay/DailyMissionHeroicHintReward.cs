using System;
using UnityEngine;

public class DailyMissionHeroicHintReward : Core_BaseScript
{
	[SerializeField]
	[Header("Core")]
	private UITable mTable;

	[SerializeField]
	private UISprite mIcon;

	[SerializeField]
	private UISprite mElitePartsIcon;

	[SerializeField]
	private UILabel mValue;

	[Header("Atlases")]
	[SerializeField]
	private UIAtlas mMenuAtlas;

	[SerializeField]
	private UIAtlas mBigAtlas;

	[SerializeField]
	private UIAtlas mUnitAtlas;

	public void GGAHNKIKJKD(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "D5";
			mIcon.MakePixelPerfect();
			multiplier = 1380f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1504f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "equals";
			mIcon.MakePixelPerfect();
			multiplier = 771f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(80f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_NOTIFICATION_DOGTAGFULL";
			mIcon.MakePixelPerfect();
			multiplier = 1709f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(712f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 347f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1411f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 864f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(818f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 563f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(888f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1822f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1541f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "subscriber_since";
			mIcon.MakePixelPerfect();
			multiplier = 1787f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(299f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("3", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "No power band to show in reminder!!!";
			mIcon.MakePixelPerfect();
			multiplier = 1001f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(922f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "112 STAGE 4 CONTINUE";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(BDMDPOIGGPP));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(FJIDOHAJGIA));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(BDMDPOIGGPP));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(LGJOBDJODBE));
	}

	public void BGFKBPMPJIL(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Army_Unit_ID";
			mIcon.MakePixelPerfect();
			multiplier = 1079f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1295f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Enable Push Notifications - devicetoken is different!";
			mIcon.MakePixelPerfect();
			multiplier = 220f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1443f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_TUTORIAL_GO_BUY_ARMY_6";
			mIcon.MakePixelPerfect();
			multiplier = 1125f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1563f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 319f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(676f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 198f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1111f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 131f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(37f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 100f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1609f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Player_Waited_Till_Delivery_Ends";
			mIcon.MakePixelPerfect();
			multiplier = 882f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1396f);
			break;
		default:
		{
			object[] array = new object[1];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("SquadMessages", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Total_Sessions";
			mIcon.MakePixelPerfect();
			multiplier = 504f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(181f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "\n";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(BPLMCCHCIMB));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(HPGGNBJIKOH));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(GDHHJJGKDMN));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
	}

	public void PONFOKHPMMO(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_LOADING";
			mIcon.MakePixelPerfect();
			multiplier = 954f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1965f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_SERVERERROR";
			mIcon.MakePixelPerfect();
			multiplier = 1053f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1969f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONTAINSXWARCARDS";
			mIcon.MakePixelPerfect();
			multiplier = 1398f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(643f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 645f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1281f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 579f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(180f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1702f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(321f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1398f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1861f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Mission Event card not found! ({0})";
			mIcon.MakePixelPerfect();
			multiplier = 1829f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(597f);
			break;
		default:
		{
			object[] array = new object[1];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("helicopter_jump_pose", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "setting special offer discount add: ";
			mIcon.MakePixelPerfect();
			multiplier = 72f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1939f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "ID_REPORTUSER_ITEM1";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GHEFLNBKDME));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(IOCAIBDJGLJ));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(AGACHHFGGEA));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(AJALBOPMANJ));
	}

	private void LGJOBDJODBE()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(PEIJBADFEBO));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1516f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1187f : 148f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 778f;
		float[] array = new float[4];
		array[0] = num;
		array[1] = num2;
		array[1] = y;
		float y2 = Mathf.Max(array) / 1681f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void GHFHNLNHCFC(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "height";
			mIcon.MakePixelPerfect();
			multiplier = 390f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(46f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ВЫХОД";
			mIcon.MakePixelPerfect();
			multiplier = 576f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(527f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-arena-winico";
			mIcon.MakePixelPerfect();
			multiplier = 1110f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1892f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 361f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(923f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 543f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1279f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1126f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(267f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1865f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1828f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_SECONDS";
			mIcon.MakePixelPerfect();
			multiplier = 646f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(357f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat(" OK!", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "\n";
			mIcon.MakePixelPerfect();
			multiplier = 707f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(541f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "NextWithdraw";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(PEIJBADFEBO));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(IPEPODKPPMG));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(MNDDMEIIBFE));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(DNOOMBKHCAH));
	}

	private void BPLMCCHCIMB()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1270f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1539f : 1605f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1728f;
		float y2 = Mathf.Max(num, num2, 0f, 0f, 0f, 0f, y, 0f) / 828f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void NKMFIJIODAG()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(CAFFPGNJBEP));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1216f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 358f : 302f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1882f;
		float[] array = new float[3];
		array[0] = num;
		array[1] = num2;
		array[3] = y;
		float y2 = Mathf.Max(array) / 1903f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void NHGDGKGLBMI()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(CAFFPGNJBEP));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1379f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 716f : 1042f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 900f;
		float[] array = new float[2];
		array[0] = num;
		array[1] = num2;
		array[7] = y;
		float y2 = Mathf.Max(array) / 371f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void CKLPPPDCEHG(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_NOTIFICATION_GOLDCRAFT";
			mIcon.MakePixelPerfect();
			multiplier = 145f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(549f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Scenes to go through: {0}\n";
			mIcon.MakePixelPerfect();
			multiplier = 501f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1308f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-gold";
			mIcon.MakePixelPerfect();
			multiplier = 650f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(624f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 342f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1264f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 401f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(112f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1491f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(832f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 958f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1394f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "D2";
			mIcon.MakePixelPerfect();
			multiplier = 1713f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(40f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("{0} {1}{2}[-]", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "StartFlying";
			mIcon.MakePixelPerfect();
			multiplier = 1603f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(223f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "OK";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(ELPGJCDDCOH));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(HPGGNBJIKOH));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(LGJOBDJODBE));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(CAFFPGNJBEP));
	}

	public void LKIFJLHOBAG(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "damage";
			mIcon.MakePixelPerfect();
			multiplier = 1919f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1990f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "#VAVRO# Daily Mission Screen - NO MISSIONS!";
			mIcon.MakePixelPerfect();
			multiplier = 1266f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(452f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "QUIT";
			mIcon.MakePixelPerfect();
			multiplier = 711f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1230f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 283f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(296f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1868f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(447f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1413f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(971f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 280f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1978f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "S";
			mIcon.MakePixelPerfect();
			multiplier = 422f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1284f);
			break;
		default:
		{
			Debug.LogErrorFormat("Weapon state changed from \"{0}\" to \"{1}\"", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT ACTIVE\t\tbutton type: UPGRADE/MAX";
			mIcon.MakePixelPerfect();
			multiplier = 1784f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(209f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "BS: On Claim Assignment MegaReward";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(DNOOMBKHCAH));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(MCACODNCLEC));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(MNDDMEIIBFE));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(PPKOMPHKPCL));
	}

	public void JIMBEDOMAFD(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "S";
			mIcon.MakePixelPerfect();
			multiplier = 1918f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1816f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Choose icon in bottom before calling Display model.";
			mIcon.MakePixelPerfect();
			multiplier = 1243f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(144f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Wrong_Weapon";
			mIcon.MakePixelPerfect();
			multiplier = 1788f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(852f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 480f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1915f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 347f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(264f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1598f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(155f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 17f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(496f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Thanks you for the following. Here are those well deserved {0} gold bars.";
			mIcon.MakePixelPerfect();
			multiplier = 651f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1428f);
			break;
		default:
		{
			object[] array = new object[1];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("-ABILITYMAXDESC", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Can not find boss";
			mIcon.MakePixelPerfect();
			multiplier = 901f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1351f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "0";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(NHGDGKGLBMI));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(EHJEMHAEPNJ));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(EHJEMHAEPNJ));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
	}

	public void KEJJLABDILG(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "CannonDamage";
			mIcon.MakePixelPerfect();
			multiplier = 1239f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1219f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "http://www.imgawards.com/wp-content/uploads/2015/12/Cover-Winter_WarFriends.png";
			mIcon.MakePixelPerfect();
			multiplier = 714f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(831f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Name";
			mIcon.MakePixelPerfect();
			multiplier = 619f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(449f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1752f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(889f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1192f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(712f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1237f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(491f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 901f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(720f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Not sending error to database!!";
			mIcon.MakePixelPerfect();
			multiplier = 343f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1744f);
			break;
		default:
		{
			object[] array = new object[1];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("Card_1_Played", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "weapon doesnt have ammo setup";
			mIcon.MakePixelPerfect();
			multiplier = 1605f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1074f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "120 MENU LEVEL UP SHOWN";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GDHHJJGKDMN));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(HPGGNBJIKOH));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(AJALBOPMANJ));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(PEIJBADFEBO));
	}

	public void IEJDJLALKGA(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_UNIT";
			mIcon.MakePixelPerfect();
			multiplier = 1160f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1688f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "_SceneFogParams";
			mIcon.MakePixelPerfect();
			multiplier = 6f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1457f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Unknow assignment type: {0}";
			mIcon.MakePixelPerfect();
			multiplier = 495f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1222f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 988f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(75f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 945f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(274f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 228f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1730f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1212f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1122f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_PLAYERNOTEXISTS_TEXT";
			mIcon.MakePixelPerfect();
			multiplier = 680f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(633f);
			break;
		default:
		{
			object[] array = new object[1];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("101 LOADING MAP", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Done: {0} players";
			mIcon.MakePixelPerfect();
			multiplier = 1525f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1905f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "we dont have best regions for player";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(PEIJBADFEBO));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(PBHAJOFLAHJ));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(NHGDGKGLBMI));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IGCJLDMLBOO));
	}

	private void FJDAGOACCBI()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GFEBGJKALKG));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1603f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 687f : 641f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1667f;
		float[] array = new float[6];
		array[1] = num;
		array[0] = num2;
		array[1] = y;
		float y2 = Mathf.Max(array) / 1064f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void DPFKOFFMNPC(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "#DEBUG_50# ";
			mIcon.MakePixelPerfect();
			multiplier = 302f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1025f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "LeagueEvaluation";
			mIcon.MakePixelPerfect();
			multiplier = 1599f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(915f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Position";
			mIcon.MakePixelPerfect();
			multiplier = 1992f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(108f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 748f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1103f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1362f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(39f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1247f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1048f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 310f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1313f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "https://play.google.com/store/apps/details?id=";
			mIcon.MakePixelPerfect();
			multiplier = 1772f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(819f);
			break;
		default:
		{
			Debug.LogErrorFormat("onPause", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "SETTING FullRes2xMS";
			mIcon.MakePixelPerfect();
			multiplier = 1567f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(743f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "Card ";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(EHJEMHAEPNJ));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(LGJOBDJODBE));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(NKMFIJIODAG));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(DJHLMOBEDJD));
	}

	public void MKENDIKJPLJ(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "us-east-1:a951d2ae-0491-424d-8240-ae25baedf92a";
			mIcon.MakePixelPerfect();
			multiplier = 1064f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(842f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_VISUALCATEGORY1";
			mIcon.MakePixelPerfect();
			multiplier = 1594f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(994f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_ERROR";
			mIcon.MakePixelPerfect();
			multiplier = 1593f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1626f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 673f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1597f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 533f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1663f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1723f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1457f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1171f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1223f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Windows";
			mIcon.MakePixelPerfect();
			multiplier = 148f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(582f);
			break;
		default:
		{
			Debug.LogErrorFormat("ID_ACTIVATION", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "WarCards";
			mIcon.MakePixelPerfect();
			multiplier = 1193f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(805f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "ID_REWARD";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(MNDDMEIIBFE));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(MNDDMEIIBFE));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(PPKOMPHKPCL));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IOCAIBDJGLJ));
	}

	private void DNOOMBKHCAH()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IPEPODKPPMG));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 730f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 740f : 1155f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1280f;
		float[] array = new float[4];
		array[0] = num;
		array[0] = num2;
		array[8] = y;
		float y2 = Mathf.Max(array) / 1109f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void GDHHJJGKDMN()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(HJPDMNDAMOM));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 584f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 28f : 573f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 895f;
		float[] array = new float[1];
		array[1] = num;
		array[0] = num2;
		array[7] = y;
		float y2 = Mathf.Max(array) / 178f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void LAKOBEMOLJI()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 45f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 0f : 66f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 2f;
		float y2 = Mathf.Max(num, num2, y) / 2f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void AJEGOKKKLOL(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_TUTORIAL_GO_BUY_ARMY_6_DOWN";
			mIcon.MakePixelPerfect();
			multiplier = 63f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1432f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Rank_Up";
			mIcon.MakePixelPerfect();
			multiplier = 1278f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(786f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "WBTransactionAmount";
			mIcon.MakePixelPerfect();
			multiplier = 751f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(993f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 706f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1896f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 918f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1839f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1465f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1649f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1099f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1100f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "setPreloadedApp";
			mIcon.MakePixelPerfect();
			multiplier = 38f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(902f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("FLOATVALUE", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "source_id";
			mIcon.MakePixelPerfect();
			multiplier = 1645f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(172f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "PlacementMatchesRequired";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(CFMBAHBKBNK));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(PBHAJOFLAHJ));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(LGJOBDJODBE));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(EHJEMHAEPNJ));
	}

	public void CHOLKMFKINL(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Message {0}";
			mIcon.MakePixelPerfect();
			multiplier = 71f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(91f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-army-upgradebar-gray";
			mIcon.MakePixelPerfect();
			multiplier = 1140f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1485f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_READYTIME";
			mIcon.MakePixelPerfect();
			multiplier = 1607f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1815f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1515f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1019f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 798f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(81f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 558f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1477f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1776f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(265f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "game-label-you-blue";
			mIcon.MakePixelPerfect();
			multiplier = 928f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(366f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("PlayerToInviteId", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "HK";
			mIcon.MakePixelPerfect();
			multiplier = 808f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(833f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "game-card-ico-shielddestroyer";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(NHGDGKGLBMI));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(PPKOMPHKPCL));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(FJDAGOACCBI));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IGCJLDMLBOO));
	}

	private void HJPDMNDAMOM()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(CAFFPGNJBEP));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 73f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 375f : 1558f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 819f;
		float[] array = new float[4];
		array[1] = num;
		array[1] = num2;
		array[6] = y;
		float y2 = Mathf.Max(array) / 1828f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void BMNBEACDAGJ()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GHEFLNBKDME));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1629f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1614f : 780f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 728f;
		float[] array = new float[4];
		array[1] = num;
		array[1] = num2;
		array[7] = y;
		float y2 = Mathf.Max(array) / 735f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void IHMEAAIKGAP(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "()Lcom/google/android/gms/common/api/Status;";
			mIcon.MakePixelPerfect();
			multiplier = 1813f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1672f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "registerLevel";
			mIcon.MakePixelPerfect();
			multiplier = 1285f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(625f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_TUTORIAL_UPGRADEWEAPON_6";
			mIcon.MakePixelPerfect();
			multiplier = 464f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(308f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 352f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(939f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 39f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1787f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 700f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(844f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 267f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(340f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Buy_Weapon_At_Rank";
			mIcon.MakePixelPerfect();
			multiplier = 1418f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(443f);
			break;
		default:
		{
			Debug.LogErrorFormat("ID_STAT_ACCURACY", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "D3";
			mIcon.MakePixelPerfect();
			multiplier = 1453f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(13f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "There is null unit in mission {0} {1} configuration";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IPEPODKPPMG));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(PMIPKEIMCCH));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(PEIJBADFEBO));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(GDHHJJGKDMN));
	}

	public void Initialize(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-gold";
			mIcon.MakePixelPerfect();
			multiplier = 76f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(0f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-arena-ticket";
			mIcon.MakePixelPerfect();
			multiplier = 64f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(0f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-arena-scrap-ico";
			mIcon.MakePixelPerfect();
			multiplier = 58f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(0f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 76f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(-1f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 76f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(-1f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 76f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(-1f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 66f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(-1f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-warbucks";
			mIcon.MakePixelPerfect();
			multiplier = 78f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(0f);
			break;
		default:
		{
			Debug.LogErrorFormat("Daily Mission Screen : daily completition reward is not DEFINED: {0}", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-warbucks";
			mIcon.MakePixelPerfect();
			multiplier = 78f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(0f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "-1";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
	}

	private void EHJEMHAEPNJ()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IPEPODKPPMG));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1200f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 933f : 87f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 885f;
		float[] array = new float[4];
		array[1] = num;
		array[0] = num2;
		array[1] = y;
		float y2 = Mathf.Max(array) / 326f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void EDKFKNGLLBM(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "AFTER CreateFromDatabase";
			mIcon.MakePixelPerfect();
			multiplier = 1385f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1927f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ERROR WRONG DAILY REWARDS: ";
			mIcon.MakePixelPerfect();
			multiplier = 259f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(57f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "PNManager: Scheduling Crafting Finished Notification in ";
			mIcon.MakePixelPerfect();
			multiplier = 1904f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(377f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 763f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(413f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 413f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1827f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1627f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(813f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 220f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(274f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "0";
			mIcon.MakePixelPerfect();
			multiplier = 147f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(741f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("warbucks", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Time";
			mIcon.MakePixelPerfect();
			multiplier = 84f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1011f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "Video_feed_upload";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(CAFFPGNJBEP));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(PBHAJOFLAHJ));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(OFNJPMLNJOM));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(PBHAJOFLAHJ));
	}

	private void BDMDPOIGGPP()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IGCJLDMLBOO));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1439f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 834f : 1859f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1993f;
		float[] array = new float[6];
		array[0] = num;
		array[0] = num2;
		array[1] = y;
		float y2 = Mathf.Max(array) / 1222f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void IOCNPPCMCMM(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Has Gc Name!";
			mIcon.MakePixelPerfect();
			multiplier = 413f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1833f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "FB: FacebookLogout - DeletePlayerAccount - 1";
			mIcon.MakePixelPerfect();
			multiplier = 134f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1308f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "0";
			mIcon.MakePixelPerfect();
			multiplier = 1758f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(769f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1025f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(627f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1662f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1914f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 226f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(883f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1569f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(401f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "^[0-9]*-";
			mIcon.MakePixelPerfect();
			multiplier = 200f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1925f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("SetAutoRepairRPC", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "special";
			mIcon.MakePixelPerfect();
			multiplier = 1041f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1583f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "ID_UNIT-BUDDY";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(PMIPKEIMCCH));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(GHEFLNBKDME));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(ELPGJCDDCOH));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(DJHLMOBEDJD));
	}

	private void DJHLMOBEDJD()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(AJALBOPMANJ));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 684f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 160f : 183f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 582f;
		float y2 = Mathf.Max(num, num2, y, 0f, 0f, 0f, 0f) / 760f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void OAMBDKHLJKI(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "com.tune.unityutils.TuneUnityFirstPlaylistListener";
			mIcon.MakePixelPerfect();
			multiplier = 1902f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(342f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "matchMadeGames";
			mIcon.MakePixelPerfect();
			multiplier = 270f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(243f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "PowerBandExpiresOn";
			mIcon.MakePixelPerfect();
			multiplier = 1300f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(256f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 806f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(769f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1442f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1978f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1369f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(196f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1235f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(815f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_ELITEPACKDESCRIPTION";
			mIcon.MakePixelPerfect();
			multiplier = 544f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1316f);
			break;
		default:
		{
			object[] array = new object[1];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("D2", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "RemoveOld";
			mIcon.MakePixelPerfect();
			multiplier = 150f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1837f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "Result";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(DNOOMBKHCAH));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
	}

	public void NAKAFGAFEPH(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "matchMadeGames";
			mIcon.MakePixelPerfect();
			multiplier = 1333f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(680f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "#PETER# Removing squad joined message - message time:{0}, server time:{1}, isInSquad:{2}";
			mIcon.MakePixelPerfect();
			multiplier = 208f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(747f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Rules";
			mIcon.MakePixelPerfect();
			multiplier = 1713f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(827f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 467f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1208f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1774f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1769f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1100f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(612f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 195f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(595f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "AdminId";
			mIcon.MakePixelPerfect();
			multiplier = 836f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(698f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("DogTagRefillTime", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Player_Avoided_Grenade_On_First_Try";
			mIcon.MakePixelPerfect();
			multiplier = 298f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(364f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "Directory \"{0}\" does not exists";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(AGACHHFGGEA));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(GFEBGJKALKG));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(DJHLMOBEDJD));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(MCACODNCLEC));
	}

	private void PMIPKEIMCCH()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(MCACODNCLEC));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 196f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1626f : 160f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 732f;
		float[] array = new float[7];
		array[1] = num;
		array[1] = num2;
		array[8] = y;
		float y2 = Mathf.Max(array) / 265f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void KFJJPGNGOCK(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_PARSING_CONFIGURATIONS";
			mIcon.MakePixelPerfect();
			multiplier = 255f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1135f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Buy_InstantBattle";
			mIcon.MakePixelPerfect();
			multiplier = 1419f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1865f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "N";
			mIcon.MakePixelPerfect();
			multiplier = 1133f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(548f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1859f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1683f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1102f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1115f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 775f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1829f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 427f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1907f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = " S:";
			mIcon.MakePixelPerfect();
			multiplier = 1761f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1310f);
			break;
		default:
		{
			Debug.LogErrorFormat(" is needed in the scene, so '", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "CONFIRM";
			mIcon.MakePixelPerfect();
			multiplier = 948f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(42f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "OK";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(NHGDGKGLBMI));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(LGJOBDJODBE));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(BDMDPOIGGPP));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(PPKOMPHKPCL));
	}

	public void HGGFDJOFNMM(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "rotateColliderName";
			mIcon.MakePixelPerfect();
			multiplier = 1208f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1955f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_ERROR";
			mIcon.MakePixelPerfect();
			multiplier = 1833f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1652f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "OnBuyArenaHeart!";
			mIcon.MakePixelPerfect();
			multiplier = 780f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1972f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 680f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(372f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1111f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1868f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 682f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(334f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1510f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1037f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "isUserInSegmentId";
			mIcon.MakePixelPerfect();
			multiplier = 1083f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1689f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("REGISTERING PACK LOCATION ", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Assignment ID: {0}\nERROR: {1}\nSTACKTRACE: {2}";
			mIcon.MakePixelPerfect();
			multiplier = 1182f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(144f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "Beanstalk: New Message sent succesfully";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GDHHJJGKDMN));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(GFEBGJKALKG));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(IPEPODKPPMG));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(MCACODNCLEC));
	}

	public void PNDFAOIDMHL(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Password";
			mIcon.MakePixelPerfect();
			multiplier = 606f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(782f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Saving GC Player Account change!";
			mIcon.MakePixelPerfect();
			multiplier = 325f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(889f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "no pack name";
			mIcon.MakePixelPerfect();
			multiplier = 312f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(343f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1029f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1284f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1649f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(81f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 900f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1087f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 456f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1244f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "helicopter_jump_pose";
			mIcon.MakePixelPerfect();
			multiplier = 1654f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(417f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_ERROR";
			mIcon.MakePixelPerfect();
			multiplier = 1572f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(750f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "PNManager: Scheduling Crafting Finished Notification in ";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(DJHLMOBEDJD));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(FJIDOHAJGIA));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(CFMBAHBKBNK));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(NHGDGKGLBMI));
	}

	public void GJOIGNMPBCH(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = ")";
			mIcon.MakePixelPerfect();
			multiplier = 1848f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(801f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "   {0}";
			mIcon.MakePixelPerfect();
			multiplier = 106f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1519f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_VISUALRARITY5";
			mIcon.MakePixelPerfect();
			multiplier = 1769f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(820f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1157f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(366f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1931f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(309f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 863f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1288f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 627f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(219f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Snapshots";
			mIcon.MakePixelPerfect();
			multiplier = 1214f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(743f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("ID_DEPLOYEDSOLDIERS", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Beanstalk: New Message sent succesfully";
			mIcon.MakePixelPerfect();
			multiplier = 926f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(172f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "HEAVYTURRET";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(PPKOMPHKPCL));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(FJIDOHAJGIA));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(MCACODNCLEC));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(NKMFIJIODAG));
	}

	public void DDHCMFLIABO(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Texture {0} is no longer loaded";
			mIcon.MakePixelPerfect();
			multiplier = 804f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(17f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "KickedPlayerId";
			mIcon.MakePixelPerfect();
			multiplier = 958f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(264f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Warbucks";
			mIcon.MakePixelPerfect();
			multiplier = 213f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1730f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 726f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1570f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1634f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1268f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 27f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1717f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1096f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1010f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "clipSize";
			mIcon.MakePixelPerfect();
			multiplier = 872f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(295f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("rental for unexist unit: {0}", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Request Finished with Error! ";
			mIcon.MakePixelPerfect();
			multiplier = 838f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(199f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "ID_CONFIRM_KICKPLAYER_TEXT";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GFEBGJKALKG));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(FJDAGOACCBI));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(AIFGKOJBHEG));
	}

	private void OFNJPMLNJOM()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(FJDAGOACCBI));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1098f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1413f : 179f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1856f;
		float[] array = new float[4];
		array[0] = num;
		array[0] = num2;
		array[0] = y;
		float y2 = Mathf.Max(array) / 1501f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void MNDDMEIIBFE()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(FJIDOHAJGIA));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 658f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1943f : 719f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1889f;
		float[] array = new float[2];
		array[1] = num;
		array[1] = num2;
		array[4] = y;
		float y2 = Mathf.Max(array) / 1371f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void OMGCKCFKDJM(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = " name:";
			mIcon.MakePixelPerfect();
			multiplier = 948f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1070f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "PlayerName";
			mIcon.MakePixelPerfect();
			multiplier = 342f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(262f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "201 LOADING MAP";
			mIcon.MakePixelPerfect();
			multiplier = 1503f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1781f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1564f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1141f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 191f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1529f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 883f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(293f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1173f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(721f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "1";
			mIcon.MakePixelPerfect();
			multiplier = 1746f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1158f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("ID_READYTIME", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "country-canada";
			mIcon.MakePixelPerfect();
			multiplier = 480f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(300f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "AdminId";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(AGACHHFGGEA));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(PMIPKEIMCCH));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(MNDDMEIIBFE));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
	}

	private void IIDJJOIGJBA()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(BMNBEACDAGJ));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 130f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 513f : 1869f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1880f;
		float[] array = new float[6];
		array[1] = num;
		array[1] = num2;
		array[5] = y;
		float y2 = Mathf.Max(array) / 86f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void IOCAIBDJGLJ()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GDHHJJGKDMN));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 618f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 156f : 484f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 545f;
		float y2 = Mathf.Max(num, num2, y, 0f, 0f, 0f, 0f) / 697f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void ELPGJCDDCOH()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(LGJOBDJODBE));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 262f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1325f : 1448f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1265f;
		float[] array = new float[4];
		array[0] = num;
		array[0] = num2;
		array[7] = y;
		float y2 = Mathf.Max(array) / 1149f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void HCLFEHHJHIK()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(DJHLMOBEDJD));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 166f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1418f : 1081f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1215f;
		float y2 = Mathf.Max(num, num2, 0f, 0f, y) / 1460f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void IPEPODKPPMG()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(PEIJBADFEBO));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1636f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1588f : 579f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1063f;
		float[] array = new float[3];
		array[0] = num;
		array[1] = num2;
		array[4] = y;
		float y2 = Mathf.Max(array) / 940f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void MCACODNCLEC()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(HJPDMNDAMOM));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1022f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 339f : 511f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1812f;
		float[] array = new float[5];
		array[0] = num;
		array[0] = num2;
		array[3] = y;
		float y2 = Mathf.Max(array) / 196f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void GOMJAFCDKDD(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Action ";
			mIcon.MakePixelPerfect();
			multiplier = 1516f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(501f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "N";
			mIcon.MakePixelPerfect();
			multiplier = 322f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(954f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_TUTORIAL_GO_BUY_ARMY_2_DOWN";
			mIcon.MakePixelPerfect();
			multiplier = 748f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(953f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 136f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(134f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1812f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(113f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1646f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(678f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 312f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(228f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_NOTIFICATION_DAILYREWARD_TICKET";
			mIcon.MakePixelPerfect();
			multiplier = 500f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1405f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("Gold", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = " {0}{1}";
			mIcon.MakePixelPerfect();
			multiplier = 451f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1297f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "NULL";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GHEFLNBKDME));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(IPEPODKPPMG));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(FJDAGOACCBI));
	}

	private void PBHAJOFLAHJ()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(NKMFIJIODAG));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 439f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1820f : 1185f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 785f;
		float[] array = new float[3];
		array[0] = num;
		array[1] = num2;
		array[5] = y;
		float y2 = Mathf.Max(array) / 679f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void AGACHHFGGEA()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(NHGDGKGLBMI));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1328f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1124f : 500f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 389f;
		float[] array = new float[6];
		array[0] = num;
		array[1] = num2;
		array[7] = y;
		float y2 = Mathf.Max(array) / 724f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void IGCJLDMLBOO()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(ELPGJCDDCOH));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 260f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1159f : 455f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1903f;
		float[] array = new float[8];
		array[0] = num;
		array[0] = num2;
		array[7] = y;
		float y2 = Mathf.Max(array) / 399f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void FJIDOHAJGIA()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1934f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1951f : 1398f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1464f;
		float[] array = new float[8];
		array[1] = num;
		array[0] = num2;
		array[4] = y;
		float y2 = Mathf.Max(array) / 1779f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void HPGGNBJIKOH()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(FJDAGOACCBI));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 494f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1982f : 165f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1732f;
		float[] array = new float[6];
		array[1] = num;
		array[0] = num2;
		array[7] = y;
		float y2 = Mathf.Max(array) / 1701f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void OBHPLFFLDBI(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CATEGORY_LOW_SG_SMG";
			mIcon.MakePixelPerfect();
			multiplier = 12f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1580f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "CONTENTS_FILE_DESCRIPTOR";
			mIcon.MakePixelPerfect();
			multiplier = 1780f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1287f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "withPublisherSubAdgroup";
			mIcon.MakePixelPerfect();
			multiplier = 1009f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1118f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1693f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(805f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1103f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(167f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1439f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1055f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1619f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1263f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_GUI_BUDDY";
			mIcon.MakePixelPerfect();
			multiplier = 919f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(76f);
			break;
		default:
		{
			Debug.LogErrorFormat("ID_CONFIRM_FORFEITARENA", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "L";
			mIcon.MakePixelPerfect();
			multiplier = 1515f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(385f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "Take arena life!";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IPEPODKPPMG));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(CAFFPGNJBEP));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(DNOOMBKHCAH));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(MCACODNCLEC));
	}

	public void GCBFCCNLMDN(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "NO Fuseboxx Config Value during GETPLAYERDATA!";
			mIcon.MakePixelPerfect();
			multiplier = 547f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(612f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "QUIT";
			mIcon.MakePixelPerfect();
			multiplier = 108f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1398f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Fuseboxx: No Dictionary with configuration found!";
			mIcon.MakePixelPerfect();
			multiplier = 1251f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(594f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 370f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1632f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 283f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(863f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1738f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(720f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1311f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(389f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_READYTIME";
			mIcon.MakePixelPerfect();
			multiplier = 1692f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1402f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("ProductId", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Region";
			mIcon.MakePixelPerfect();
			multiplier = 874f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(258f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "DOWNLOAD";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(HJPDMNDAMOM));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(ELPGJCDDCOH));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(BMNBEACDAGJ));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(GFEBGJKALKG));
	}

	private void PPKOMPHKPCL()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IOCAIBDJGLJ));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 372f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1571f : 1047f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 164f;
		float[] array = new float[6];
		array[1] = num;
		array[0] = num2;
		array[5] = y;
		float y2 = Mathf.Max(array) / 1621f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void GFEBGJKALKG()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(BDMDPOIGGPP));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 258f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1996f : 891f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 398f;
		float[] array = new float[5];
		array[0] = num;
		array[1] = num2;
		array[1] = y;
		float y2 = Mathf.Max(array) / 1834f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void FPPLMOLHGFD(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_WARNING_SERVERTIMEDOUT";
			mIcon.MakePixelPerfect();
			multiplier = 1830f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1087f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "PlayerData";
			mIcon.MakePixelPerfect();
			multiplier = 107f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1612f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_FRIENDINSQUAD";
			mIcon.MakePixelPerfect();
			multiplier = 1349f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1881f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1442f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(2f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1492f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1530f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 894f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1968f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 428f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1781f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Sessions";
			mIcon.MakePixelPerfect();
			multiplier = 1162f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(412f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("Rental", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "\n\nDEBUG STATE: ";
			mIcon.MakePixelPerfect();
			multiplier = 1549f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(91f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "ID_CONFIRM_SQUADLEAVEERROR";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(EHNDPJJHBHN));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(MCACODNCLEC));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(IGCJLDMLBOO));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(CFMBAHBKBNK));
	}

	public void PPLIBOAJOCA(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_WARSHOP_GOLD";
			mIcon.MakePixelPerfect();
			multiplier = 1919f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(75f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_STARTUPERROR";
			mIcon.MakePixelPerfect();
			multiplier = 603f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(10f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_WAITINGFORFRIEND";
			mIcon.MakePixelPerfect();
			multiplier = 1442f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1927f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1068f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1727f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1194f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(250f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 439f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1739f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 941f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(299f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "game-ico-poison";
			mIcon.MakePixelPerfect();
			multiplier = 1620f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1396f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat(" - {0}", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Testing Player";
			mIcon.MakePixelPerfect();
			multiplier = 739f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1743f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "21haWwuY29tMB4XDTE1MDIyNDE1MDI0MFoXDTE3MTEyMTE1MDI0MFowgaExCzAJBgNVBAYTAkNaMQ8wDQYDVQQIDAZQcmFndWUxDzANBgNVBAcMBlByYWd1ZTESMBAGA1UECgwJQWJvdXQgRnVuMQswCQYDVQQLDAJJVDErMCkGA1UEAwwid2FyZnJpZW5kcy1ldS5lbGFzdGljYmVhbnN0YWxrLmNvbTEiMCAGCSqGSIb3DQEJARYTdm9qdGFzaXZyQGdtYWlsLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALOLAdUTdkvp5QjE0h0/EXuHUzDjgTk1L9B6Qe/qTgh3sDcEmOacC7vZoyhLzSMTucVYGnTda8wRZP2Qh5UE3SmKXhA5axywLJbI0AeL5VeJsquIQMJ3dy8FNNGiILMqfSnYGfF/ND6xDIKfBq9oZFolOjeYxujhU2Enk08H4gak8cWJNpxzTmUBrHIzQhPabw8hNOA5SwB2xe0jaZQErIJu6A/LgnoStRcddvGfZzCHxkVmEWte6QR00KtZ0lm4p/BR2N8qVYb/LKBLMMflTEa+4HJ508OT6IibgcmDniXON1Rwt608VAZHcGQ71twMx8HlUbHpNtYmLABGHoI3NY0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAADNahERiLW4qa8vK1C7Wljax86yb8KX5+gX6DmS5XTkrz736MiF6Wo2ttV4hgw1HzGNitwDZl/3YGIxxQhI6Dpg+ChuHKZsaoCGOPBTSCrw02MGnASLMw9laTUPdip5oHT9PAef8JsuGjJ4t5yBcpzE1FD/Hd6c4BnCNfIiMKLeNoVishmUU/UIv+9RekCJ0gQUzCovyksIy5VVM9q9/tDfmKpONaxnnBDzaLPIA7DE2ZFPEBRGJMno6Zo2JfN/fyl2xj7LWVCzLwr8S3nHa4L6XHtu29LUSzcSrVhUb+31bDdq48ZItbj2w+uK5n2Wgnv/sRkyrxCBC3j0qIz2kTQ==-----END CERTIFICATE-----";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(ELPGJCDDCOH));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(NHGDGKGLBMI));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(DNOOMBKHCAH));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(PEIJBADFEBO));
	}

	public void OLOPLBDKBLA(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Before CreateFromDatabase";
			mIcon.MakePixelPerfect();
			multiplier = 671f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(376f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "1-placement";
			mIcon.MakePixelPerfect();
			multiplier = 158f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1583f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "{0}/{1} ({2})\n";
			mIcon.MakePixelPerfect();
			multiplier = 723f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(364f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 402f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1483f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1434f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1006f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1531f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1767f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1801f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1241f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Rank";
			mIcon.MakePixelPerfect();
			multiplier = 790f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(94f);
			break;
		default:
		{
			Debug.LogErrorFormat("game-card-ico-mineyourstep-full", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "null";
			mIcon.MakePixelPerfect();
			multiplier = 1656f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(465f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "offerMult";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(FJIDOHAJGIA));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(NKMFIJIODAG));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(BMNBEACDAGJ));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(CAFFPGNJBEP));
	}

	public void ODGINKAHGJF(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_STARTERASSIGNMENTSEXPIRED";
			mIcon.MakePixelPerfect();
			multiplier = 1029f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1768f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "SheetConfiguraton";
			mIcon.MakePixelPerfect();
			multiplier = 1769f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1250f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "/";
			mIcon.MakePixelPerfect();
			multiplier = 1252f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1477f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1743f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1534f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1273f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(784f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1349f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1029f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 688f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(204f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "{0} {1}";
			mIcon.MakePixelPerfect();
			multiplier = 1332f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(666f);
			break;
		default:
		{
			object[] array = new object[1];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("grenade_reload", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "), ";
			mIcon.MakePixelPerfect();
			multiplier = 1531f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(573f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "game-card-ico-triggerhappy";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(LGJOBDJODBE));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(DNOOMBKHCAH));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(LAKOBEMOLJI));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(DNOOMBKHCAH));
	}

	private void EHNDPJJHBHN()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IOCAIBDJGLJ));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 297f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 725f : 1137f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 724f;
		float[] array = new float[1];
		array[0] = num;
		array[1] = num2;
		array[1] = y;
		float y2 = Mathf.Max(array) / 1834f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void LOJPGLBLJDF(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Squad";
			mIcon.MakePixelPerfect();
			multiplier = 1613f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1017f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "0";
			mIcon.MakePixelPerfect();
			multiplier = 411f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(893f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "LootboxesCost";
			mIcon.MakePixelPerfect();
			multiplier = 655f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(649f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1995f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(704f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1580f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1802f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 500f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(648f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 829f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1292f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "menu-hub-multiplayer-vipico";
			mIcon.MakePixelPerfect();
			multiplier = 301f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1195f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("Hidding ", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "BattleId";
			mIcon.MakePixelPerfect();
			multiplier = 1809f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(780f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "ID_SQUADMEMBERSLOWER";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(PPKOMPHKPCL));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(IPEPODKPPMG));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(NKMFIJIODAG));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(PMIPKEIMCCH));
	}

	public void EPAHIKLPNNB(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CLAIMED";
			mIcon.MakePixelPerfect();
			multiplier = 1922f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1740f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "PNManager: Received event: ";
			mIcon.MakePixelPerfect();
			multiplier = 976f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(682f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Manual_Unit_Spawn";
			mIcon.MakePixelPerfect();
			multiplier = 491f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1588f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1878f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1041f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1060f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(367f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1340f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1389f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1218f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1846f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_ASSIGNMENTHINTCRATES";
			mIcon.MakePixelPerfect();
			multiplier = 305f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1031f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat(". Correcting...", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "AdminName";
			mIcon.MakePixelPerfect();
			multiplier = 1426f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1428f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "strafing_left";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(DJHLMOBEDJD));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(FJDAGOACCBI));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(BDMDPOIGGPP));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(PMIPKEIMCCH));
	}

	public void IGPOLIPPGBP(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "batchSizeMax";
			mIcon.MakePixelPerfect();
			multiplier = 344f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(300f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "CraftData";
			mIcon.MakePixelPerfect();
			multiplier = 1480f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1897f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "next";
			mIcon.MakePixelPerfect();
			multiplier = 1269f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1925f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1742f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1003f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 532f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(412f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 416f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(996f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 869f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(211f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "WALLET - fake spent WB {0}";
			mIcon.MakePixelPerfect();
			multiplier = 1288f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1166f);
			break;
		default:
		{
			Debug.LogErrorFormat("Problem for max! in weapon stats", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_RELOG_TO_FB_DIALOG_TEXT";
			mIcon.MakePixelPerfect();
			multiplier = 1338f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(301f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "WinCount";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(FJDAGOACCBI));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(DNOOMBKHCAH));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IOCAIBDJGLJ));
	}

	public void PNCJCHPOMOJ(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_LEADER";
			mIcon.MakePixelPerfect();
			multiplier = 481f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1627f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "getCampaignId";
			mIcon.MakePixelPerfect();
			multiplier = 1102f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(421f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "204 AUTOSPAWN CONTINUE";
			mIcon.MakePixelPerfect();
			multiplier = 223f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(769f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 941f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(753f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1587f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(207f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 494f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(707f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1491f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(729f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "visuals: {0} {1} {2} {3}";
			mIcon.MakePixelPerfect();
			multiplier = 818f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1041f);
			break;
		default:
		{
			object[] array = new object[1];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("weapon1", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "PlacementMatchesRequired";
			mIcon.MakePixelPerfect();
			multiplier = 1224f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1427f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "8b004c04-6921-4613-9815-e63b42db4a7c";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IPEPODKPPMG));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(DJHLMOBEDJD));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(IOCAIBDJGLJ));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IGCJLDMLBOO));
	}

	public void FKGIBDEAKGJ(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_GUI_ALLCARDS";
			mIcon.MakePixelPerfect();
			multiplier = 232f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(648f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_GUI_CHAT_SQUAD_PROMOTED";
			mIcon.MakePixelPerfect();
			multiplier = 1462f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(631f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Player visual Error: id not find: ";
			mIcon.MakePixelPerfect();
			multiplier = 364f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1612f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1851f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1087f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 124f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(324f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Silver].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 504f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(336f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1219f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1432f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "to ";
			mIcon.MakePixelPerfect();
			multiplier = 848f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(717f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("Beanstalk: That account already exists! Player will choose how to proceed, provider = ", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Spend_Gold_On_Card_Packs";
			mIcon.MakePixelPerfect();
			multiplier = 47f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(846f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "ReconnectDialog Show";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(MCACODNCLEC));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(HCLFEHHJHIK));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(BDMDPOIGGPP));
	}

	private void CFMBAHBKBNK()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(EHJEMHAEPNJ));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 613f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 369f : 948f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1563f;
		float[] array = new float[4];
		array[1] = num;
		array[0] = num2;
		array[0] = y;
		float y2 = Mathf.Max(array) / 741f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void AMFDNBJBPLB(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_KICKPLAYER";
			mIcon.MakePixelPerfect();
			multiplier = 261f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(783f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Level_Number";
			mIcon.MakePixelPerfect();
			multiplier = 1334f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(904f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "testingidcheat";
			mIcon.MakePixelPerfect();
			multiplier = 606f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1274f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 419f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(560f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.ThreeCards].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1778f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(736f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1868f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(650f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 493f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(404f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "setPushNotificationRegistrationId";
			mIcon.MakePixelPerfect();
			multiplier = 1426f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1716f);
			break;
		default:
		{
			Debug.LogErrorFormat("\"NaN\"", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "DOWNLOAD";
			mIcon.MakePixelPerfect();
			multiplier = 1512f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(125f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "Wrong_Category";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(EHNDPJJHBHN));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(PPKOMPHKPCL));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.EliteParts);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(LGJOBDJODBE));
	}

	private void GHEFLNBKDME()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IOCAIBDJGLJ));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 1342f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1466f : 142f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1981f;
		float[] array = new float[2];
		array[1] = num;
		array[1] = num2;
		array[5] = y;
		float y2 = Mathf.Max(array) / 426f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void AIFGKOJBHEG()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(GFEBGJKALKG));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 116f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1720f : 1524f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 289f;
		float[] array = new float[1];
		array[1] = num;
		array[1] = num2;
		array[8] = y;
		float y2 = Mathf.Max(array) / 1220f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void JPBOGGKMAON(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "hashCode";
			mIcon.MakePixelPerfect();
			multiplier = 198f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1605f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "UnlockLevel";
			mIcon.MakePixelPerfect();
			multiplier = 1245f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(885f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Area";
			mIcon.MakePixelPerfect();
			multiplier = 1583f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1198f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 54f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(378f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1115f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1816f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 876f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1919f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 223f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1355f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_SQUADMEMBERSLOWER";
			mIcon.MakePixelPerfect();
			multiplier = 897f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(361f);
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("menu-info-ico", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = ", val = ";
			mIcon.MakePixelPerfect();
			multiplier = 968f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1011f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "Finished";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(HPGGNBJIKOH));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(MNDDMEIIBFE));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(ELPGJCDDCOH));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(DJHLMOBEDJD));
	}

	private void PEIJBADFEBO()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(ELPGJCDDCOH));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 968f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 171f : 1532f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1093f;
		float[] array = new float[6];
		array[1] = num;
		array[1] = num2;
		array[0] = y;
		float y2 = Mathf.Max(array) / 286f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	private void AJALBOPMANJ()
	{
		mTable.repositionNow = true;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(BPLMCCHCIMB));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 465f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1563f : 1338f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 618f;
		float[] array = new float[3];
		array[1] = num;
		array[1] = num2;
		array[4] = y;
		float y2 = Mathf.Max(array) / 818f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void IFCHBHGGKDJ(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "GameLoginManager - Global Medals update: ";
			mIcon.MakePixelPerfect();
			multiplier = 88f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1170f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "{0} {1}";
			mIcon.MakePixelPerfect();
			multiplier = 76f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1094f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Tutorial_Step_Complete";
			mIcon.MakePixelPerfect();
			multiplier = 1628f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1742f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Bronze].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 954f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1091f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Starter].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 362f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(89f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[(NGNPIOOAHEH)8].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 714f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(138f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 49f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(516f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "()V";
			mIcon.MakePixelPerfect();
			multiplier = 1324f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1254f);
			break;
		default:
		{
			Debug.LogErrorFormat("batchSizeMax", MOEMPHPNBLM.GGIOEPBPMHF);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "InstantBattleEnded: 3RD REWARD WARBUCKS: ";
			mIcon.MakePixelPerfect();
			multiplier = 303f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1600f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "ArmyPower";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(NKMFIJIODAG));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(HCLFEHHJHIK));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = true;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(EHJEMHAEPNJ));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(GDHHJJGKDMN));
	}

	public void IACEOEJFEEM(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "215 MENU ARMY SCREEN TUTORIAL UNIT BUY CLICKED";
			mIcon.MakePixelPerfect();
			multiplier = 988f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1686f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_DAY";
			mIcon.MakePixelPerfect();
			multiplier = 994f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1255f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_EMPTYSQUADMESSAGE";
			mIcon.MakePixelPerfect();
			multiplier = 993f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1410f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1441f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1763f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 893f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(145f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Money].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 195f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(136f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 61f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1578f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "qbz2_reload";
			mIcon.MakePixelPerfect();
			multiplier = 1563f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(129f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("LevelName", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "BonusDamage";
			mIcon.MakePixelPerfect();
			multiplier = 121f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1382f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: false);
			mValue.text = "LootBoxRotation";
			mTable.repositionNow = true;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(IGCJLDMLBOO));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(AIFGKOJBHEG));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(GFEBGJKALKG));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(PPKOMPHKPCL));
	}

	private void CAFFPGNJBEP()
	{
		mTable.repositionNow = false;
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(LGJOBDJODBE));
		float x = mValue.transform.parent.localPosition.x;
		float x2 = mTable.padding.x;
		float num = 536f;
		float num2 = ((!mElitePartsIcon.gameObject.activeSelf) ? 1265f : 1705f);
		float y = mIcon.transform.localScale.y;
		float x3 = 0f - x2 - (x - x2) / 1885f;
		float[] array = new float[2];
		array[0] = num;
		array[1] = num2;
		array[5] = y;
		float y2 = Mathf.Max(array) / 746f;
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceXY(x3, y2);
	}

	public void CONKDIBIPBH(CDACJEGCGLB MOEMPHPNBLM)
	{
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "C3";
			mIcon.MakePixelPerfect();
			multiplier = 976f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1224f);
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_CONFIRM_SUBSCRIPTION_TEXT";
			mIcon.MakePixelPerfect();
			multiplier = 447f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1911f);
			break;
		case PNFCNJHKBBN.Scraps:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "Metal";
			mIcon.MakePixelPerfect();
			multiplier = 554f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(716f);
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.None].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 399f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1911f);
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Gold].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1969f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1873f);
			break;
		case PNFCNJHKBBN.GoldCardpack:
			mIcon.atlas = mBigAtlas;
			mIcon.spriteName = GameVariables.DGIMAKIAGNJ[NGNPIOOAHEH.Value].Value2;
			mIcon.MakePixelPerfect();
			multiplier = 1577f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(787f);
			break;
		case PNFCNJHKBBN.EliteParts:
			mIcon.atlas = mUnitAtlas;
			mIcon.spriteName = MOEMPHPNBLM.IKILOKMAGJJ.upgradeSlots.iconNameElite;
			mIcon.MakePixelPerfect();
			multiplier = 1580f / mIcon.transform.localScale.y;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(463f);
			break;
		case PNFCNJHKBBN.WarBucks:
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_TUTORIAL";
			mIcon.MakePixelPerfect();
			multiplier = 1814f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1198f);
			break;
		default:
		{
			object[] array = new object[0];
			array[1] = MOEMPHPNBLM.GGIOEPBPMHF;
			Debug.LogErrorFormat("ID_WARNING_OPPONENTDISCONNECTED", array);
			mIcon.atlas = mMenuAtlas;
			mIcon.spriteName = "ID_GUI_POWERBANDOFF";
			mIcon.MakePixelPerfect();
			multiplier = 296f / mIcon.transform.localScale.x;
			mIcon.transform.localPosition = mIcon.transform.localPosition.ReplaceZ(1544f);
			mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
			mElitePartsIcon.gameObject.SetActive(value: true);
			mValue.text = "いいえ";
			mTable.repositionNow = false;
			UITable uITable = mTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(BDMDPOIGGPP));
			UITable uITable2 = mTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(MNDDMEIIBFE));
			return;
		}
		}
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mElitePartsIcon.gameObject.SetActive(MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.Gold);
		mValue.text = MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM);
		mTable.repositionNow = false;
		UITable uITable3 = mTable;
		uITable3.onReposition = (UITable.OnReposition)Delegate.Remove(uITable3.onReposition, new UITable.OnReposition(GFEBGJKALKG));
		UITable uITable4 = mTable;
		uITable4.onReposition = (UITable.OnReposition)Delegate.Combine(uITable4.onReposition, new UITable.OnReposition(IIDJJOIGJBA));
	}
}
