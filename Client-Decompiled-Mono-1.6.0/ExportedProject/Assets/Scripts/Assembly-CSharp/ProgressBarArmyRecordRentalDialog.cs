using System.Collections.Generic;
using UnityEngine;

public class ProgressBarArmyRecordRentalDialog : Core_BaseScript
{
	[Header("Left")]
	public UISprite HMMKJFFOEFN;

	[Header("Middle")]
	public UILabel CKBELNDIMJG;

	[Header("-Ability Locked Tier")]
	public UITable CFABIJLGDEN;

	public UILabel JKKDKNOOBCE;

	public List<UISprite> KBCDCFBPJKB;

	[Header("-Progress Bar")]
	public GameObject AJIBIAPCLIN;

	public UISprite KCDCGGKKMOM;

	public UILabel CGNKNENMLPB;

	public UILabel PNBGMFFKJIP;

	public void KKINHEJBJHF(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(76f, HMMKJFFOEFN.transform.localPosition.y, 861f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		JKKDKNOOBCE.text = Localization.LocalizeFormat("SquadWarEndDialog - Database message not set.", num);
		for (int i = 1; i < KBCDCFBPJKB.Count; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		NKBLGMJAJAA(string.Empty);
	}

	public void MLDAOCHIHKG(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(278f, HMMKJFFOEFN.transform.localPosition.y, 1900f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("Gold", array);
		for (int i = 0; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		APIDLEIFPGI(string.Empty);
	}

	private void DGIBGGKKJMK(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 332f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 262f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1128f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("Play_Card_Tutorial_Duration", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "DEV SVK" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(396f / x);
		if (num2 < 678f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "PA: transactions NULL" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(604f / x);
		}
		if (num2 < 638f)
		{
			Debug.LogError("shield_shot");
		}
		float num3 = Mathf.Clamp(num2, 1414f, 1252f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1576f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1984f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void FMKICOJKNDJ(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.guiStatistics[(!JFPCEOFJKIG) ? 1 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 1938f)
		{
			num2 = 1582f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(304f, HMMKJFFOEFN.transform.localPosition.y, 1115f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "No main position was set in map definition" : "CAMOS_DEFAULT");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("Scraps") : Localization.Localize("menu-weapon-benelli-starterpack"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		KAIFMOMDEOO(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	private void ONPPHCIGGAH(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1636f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1855f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 192f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("reloadTime", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "Id" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(327f / x);
		if (num2 < 1137f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "#PETER# Animating league arc {0}    from:\"{1}\"  to:\"{2}\"" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1643f / x);
		}
		if (num2 < 714f)
		{
			Debug.LogError("Register Assignment Issued ");
		}
		float num3 = Mathf.Clamp(num2, 1758f, 426f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 98f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 382f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void INJLFHPNBOH(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 0 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 832f)
		{
			num2 = 281f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1565f, HMMKJFFOEFN.transform.localPosition.y, 103f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "FuseBox Event DuplicateLootbox for {0}" : " ");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("grenadeExplosion") : Localization.Localize("resultMessage"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		NKBLGMJAJAA(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void HCINKMDCPLN(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 1 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (num2 == 518f)
		{
			num2 = 700f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1532f, HMMKJFFOEFN.transform.localPosition.y, 1979f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "Still waiting for server\nBe patient :-)" : "HeroicMissionsCompletionRewardTickets");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("InAppRow '") : Localization.Localize("ID_CONFIRM_ACCOUNTBANNED"));
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		PBKLJAHGMCA(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void GHNACNMLGLF(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(327f, HMMKJFFOEFN.transform.localPosition.y, 872f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		JKKDKNOOBCE.text = Localization.LocalizeFormat("REGISTER VIEW STARTER ASSIGNMENT ", num);
		for (int i = 1; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		AGOPACFNKHL(string.Empty);
	}

	private void CINNCLELIJH(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 694f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1571f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 347f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("Create player instance at ", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "Name" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(226f / x);
		if (num2 < 712f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "Automatic_Equip" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(969f / x);
		}
		if (num2 < 1809f)
		{
			Debug.LogError("ArmyPower");
		}
		float num3 = Mathf.Clamp(num2, 1877f, 579f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1445f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1225f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void PFPEAGPIBPE(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 0 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (num2 == 427f)
		{
			num2 = 1380f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1669f, HMMKJFFOEFN.transform.localPosition.y, 603f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "PlayerId" : "0");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("ShadowSetActive") : Localization.Localize("#VAVRO# OnLeftRoom"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		KAIFMOMDEOO(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	private void PBKLJAHGMCA(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1609f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1519f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1949f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("QUIT", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "GetCurrentMapDefinition" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1822f / x);
		if (num2 < 1485f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "visuals: null" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1731f / x);
		}
		if (num2 < 301f)
		{
			Debug.LogError("Leaderboards - Squad Wars - is in squad:{0},\t\tsquad wars procesing:{1}");
		}
		float num3 = Mathf.Clamp(num2, 1737f, 1093f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 901f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 644f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void GIJAPDACHKD(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(553f, HMMKJFFOEFN.transform.localPosition.y, 1553f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[1];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("WarFriends muss circa 190 MB zusätzliche Daten herunterladen.\nDie Dauer des Downloads hängt von deinem Netzwerk und Standort ab.\n\nMöchtest du fortfahren?", array);
		for (int i = 1; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		KAIFMOMDEOO(string.Empty);
	}

	private void JBLBLJMDDFG(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1868f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1780f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1032f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("#PETER# League Arc ", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_GAMECENTERUSER" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(513f / x);
		if (num2 < 10f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "tuneId     = " + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1784f / x);
		}
		if (num2 < 635f)
		{
			Debug.LogError("ID_CONFIRM_CONNECTTOGOOGLENAMETEXT");
		}
		float num3 = Mathf.Clamp(num2, 7f, 1743f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1737f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 8f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void IHFCGHLGPCP(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 389f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 258f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1297f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("\tTime since last show: {0}\tFb login counter: {1}/3", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_EXPIRESIN" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(33f / x);
		if (num2 < 1306f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_WARNING_ACHIEVEMENTALREADYCLAIMED" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(618f / x);
		}
		if (num2 < 1265f)
		{
			Debug.LogError("()Landroid/app/PendingIntent;");
		}
		float num3 = Mathf.Clamp(num2, 1854f, 184f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 434f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1587f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void NJCAFMINBBN(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1294f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 252f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 408f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("country-switzerland", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "End Of Try Out: Equipping visual before \"{0}\"" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1401f / x);
		if (num2 < 69f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ERROR WRONG DAILY REWARDS: " + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1012f / x);
		}
		if (num2 < 1779f)
		{
			Debug.LogError("silver1");
		}
		float num3 = Mathf.Clamp(num2, 697f, 596f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1302f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 142f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void APIDLEIFPGI(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1572f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1847f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1927f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("Total_Gold_Spent", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_ARENALOOTBOXWARBUCKS" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(678f / x);
		if (num2 < 683f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "menu-cards-goldpack" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(183f / x);
		}
		if (num2 < 771f)
		{
			Debug.LogError("Tier");
		}
		float num3 = Mathf.Clamp(num2, 1357f, 330f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 648f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1690f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void HIAKJJICAAL(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 0 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 719f)
		{
			num2 = 720f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1245f, HMMKJFFOEFN.transform.localPosition.y, 1833f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "x{0}" : "getValueForHookById");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("weaponDelivery") : Localization.Localize("Xp"));
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		ONPPHCIGGAH(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	private void APCDGOBPPEP(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1331f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1047f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 715f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("IsGlobal", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "), " + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(346f / x);
		if (num2 < 548f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "withAttribute3" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1297f / x);
		}
		if (num2 < 1085f)
		{
			Debug.LogError("Deposited warcards DID NOT change");
		}
		float num3 = Mathf.Clamp(num2, 135f, 842f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 437f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 980f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void KAIFMOMDEOO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1134f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1764f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 986f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot decline player", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "discount" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(221f / x);
		if (num2 < 1458f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "NotEnoughPlayers" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(884f / x);
		}
		if (num2 < 340f)
		{
			Debug.LogError("{0}\u00a0{1}");
		}
		float num3 = Mathf.Clamp(num2, 699f, 998f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1100f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 15f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void JABGIELFLPH(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(1419f, HMMKJFFOEFN.transform.localPosition.y, 1396f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[0] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("PurchaseVerification(", array);
		for (int i = 1; i < KBCDCFBPJKB.Count; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		PBKLJAHGMCA(string.Empty);
	}

	private void NKBLGMJAJAA(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 82f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1938f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1542f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("ID_GUI_BUYRANDOMCARDS", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "108B STAGE 2 KILLED SOLDIER SCOPE" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(375f / x);
		if (num2 < 1446f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "country-latvia" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1116f / x);
		}
		if (num2 < 1878f)
		{
			Debug.LogError("StartMovementAtTimeRPC");
		}
		float num3 = Mathf.Clamp(num2, 418f, 1994f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1856f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1074f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void JHLPKMIGCCI(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(1701f, HMMKJFFOEFN.transform.localPosition.y, 85f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		JKKDKNOOBCE.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", num);
		for (int i = 1; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		KAIFMOMDEOO(string.Empty);
	}

	public void HAJKBGELPKD(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(963f, HMMKJFFOEFN.transform.localPosition.y, 414f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[1];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("ID_WARNING_CONNECTIONERROR", array);
		for (int i = 0; i < KBCDCFBPJKB.Count; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		PBKLJAHGMCA(string.Empty);
	}

	private void LPJPDEGCABB(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 342f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1390f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 343f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("ID_ARENACROWN_DURATION", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_CONFIRM_NOSQUADACTIONS_TEXT" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(711f / x);
		if (num2 < 1670f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_GETFORNUMBERONE2" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(1072f / x);
		}
		if (num2 < 1157f)
		{
			Debug.LogError("ID_CONFIRM_DELETESQUAD");
		}
		float num3 = Mathf.Clamp(num2, 1926f, 1458f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1188f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 972f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void GEJLLEPAOGP(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(360f, HMMKJFFOEFN.transform.localPosition.y, 1886f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[0] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("AtlasPreparer.LoadTutorialCoroutine", array);
		for (int i = 0; i < KBCDCFBPJKB.Count; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		CINNCLELIJH(string.Empty);
	}

	public void LNDBIIODAEB(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 0 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 244f)
		{
			num2 = 1113f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1605f, HMMKJFFOEFN.transform.localPosition.y, 1959f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "WarCards_Screen" : "Shields");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("Chat: Channels ") : Localization.Localize("Play_Card_Tutorial_Duration"));
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		CINNCLELIJH(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void APKJPJFDEEG(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 1 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (num2 == 329f)
		{
			num2 = 738f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1127f, HMMKJFFOEFN.transform.localPosition.y, 1564f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "idle" : "ID_YOUHAVENOBUDDYWARCARDSAVAILABLE");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("S") : Localization.Localize("Lcom/google/android/gms/games/request/Requests;"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		CINNCLELIJH(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void InitializeAbility(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(27f, HMMKJFFOEFN.transform.localPosition.y, 0f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		JKKDKNOOBCE.text = Localization.LocalizeFormat("ID_UNLOCKEDATTIER", num);
		for (int i = 0; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		GMCBBBAAGJO(string.Empty);
	}

	private void AGOPACFNKHL(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 911f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 303f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1828f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("Standard", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "CONTENTS_FILE_DESCRIPTOR" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(52f / x);
		if (num2 < 1670f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_TUTORIAL_RIFLE_DOWN" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(92f / x);
		}
		if (num2 < 186f)
		{
			Debug.LogError("DelayMin");
		}
		float num3 = Mathf.Clamp(num2, 370f, 1205f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1710f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1591f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void JGDCOMKIAHI(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 1 : 1];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 1411f)
		{
			num2 = 1579f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(448f, HMMKJFFOEFN.transform.localPosition.y, 721f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "ID_CREATE" : "Chillingo: On Offers Released");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("NO") : Localization.Localize("ID_GUI_CHAT_BANNED_DESCBOX_PERMANENT"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		AGOPACFNKHL(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void FHDEPEMMKGJ(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(1234f, HMMKJFFOEFN.transform.localPosition.y, 236f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("country-south-africa", array);
		for (int i = 1; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		GMCBBBAAGJO(string.Empty);
	}

	public void AKMGNNHKJJB(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(1228f, HMMKJFFOEFN.transform.localPosition.y, 51f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("POWER BAND = NULL", array);
		for (int i = 1; i < KBCDCFBPJKB.Count; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		CINNCLELIJH(string.Empty);
	}

	public void NCLDABJGBLH(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 0 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 1513f)
		{
			num2 = 353f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(668f, HMMKJFFOEFN.transform.localPosition.y, 280f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "You probably assigned bad type of AmmoSetup to gun" : "Cards_Owned_Gold");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("Warfriend{0}") : Localization.Localize("Arena Expired - you gain scraps. You have {0} lives."));
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		DGIBGGKKJMK(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void KEEPLDGEMJF(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[JFPCEOFJKIG ? 1 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 1854f)
		{
			num2 = 444f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1465f, HMMKJFFOEFN.transform.localPosition.y, 1239f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "09" : "ID_UNITTYPE4-DESCRIPTION");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("ID_MINIGUNTUTORIALTEXT") : Localization.Localize("VisualTimestamp"));
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		APCDGOBPPEP(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void InitializeStat(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.guiStatistics[(!JFPCEOFJKIG) ? 1 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 0f)
		{
			num2 = 1f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(22f, HMMKJFFOEFN.transform.localPosition.y, 0f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "menu-health-ico" : "menu-attack-ico");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("ID_HEALTH") : Localization.Localize("ID_ATTACK"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		GMCBBBAAGJO(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void BCDDLMBFEAB(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 0 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 1619f)
		{
			num2 = 989f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(286f, HMMKJFFOEFN.transform.localPosition.y, 475f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "PlacementMatchesRequired" : "Sessions");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("HeroicReward") : Localization.Localize("Sniper_Tutorial_Duration"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		DGIBGGKKJMK(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	private void GMCBBBAAGJO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 25f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("ID_MAXSTAT", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + " " + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(224f / x);
		if (num2 < 20f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + " " + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(224f / x);
		}
		if (num2 < 20f)
		{
			Debug.LogError("Problem for max! in army/weapon stats");
		}
		float num3 = Mathf.Clamp(num2, 20f, 25f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void MEEHJGDDMLP(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 1 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (num2 == 83f)
		{
			num2 = 1673f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(253f, HMMKJFFOEFN.transform.localPosition.y, 846f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "game-elite-debuff1" : "ID_SLOTUPGRADE_ROF");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("Received FB Friends from server: ") : Localization.Localize("BANDS_WEAPON_DAMAGE"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		NJCAFMINBBN(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void OIDAOIKEMDN(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(1383f, HMMKJFFOEFN.transform.localPosition.y, 632f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[0] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("ID_READYTIME", array);
		for (int i = 0; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		CINNCLELIJH(string.Empty);
	}

	public void GKGKMAHPDCI(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(1168f, HMMKJFFOEFN.transform.localPosition.y, 400f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(false);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[0] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("{0} {1}", array);
		for (int i = 0; i < KBCDCFBPJKB.Count; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		APIDLEIFPGI(string.Empty);
	}

	public void MABJMMCPIIH(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 1 : 0];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 544f)
		{
			num2 = 102f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(589f, HMMKJFFOEFN.transform.localPosition.y, 387f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "S" : "opponentState.willHide = true");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("ID_CHANGINGLANGUAGE") : Localization.Localize("ID_ERRORNAME"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		IHFCGHLGPCP(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void EDNPABOGKNA(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(306f, HMMKJFFOEFN.transform.localPosition.y, 778f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("Wrong_Weapon", array);
		for (int i = 0; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		CINNCLELIJH(string.Empty);
	}

	public void ENNCDPPJGAF(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(192f, HMMKJFFOEFN.transform.localPosition.y, 100f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("RweardModifierWB", array);
		for (int i = 1; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		ONPPHCIGGAH(string.Empty);
	}

	public void NAJMCCMCIMA(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 0;
		HMMKJFFOEFN.transform.localPosition = new Vector3(2f, HMMKJFFOEFN.transform.localPosition.y, 471f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[0];
		array[0] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("Local", array);
		for (int i = 1; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		CINNCLELIJH(string.Empty);
	}

	public void HHMJOKAFENM(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.NEJNMDNOAKD()[(!JFPCEOFJKIG) ? 1 : 1];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		if (num2 == 331f)
		{
			num2 = 823f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1778f, HMMKJFFOEFN.transform.localPosition.y, 1363f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "Region" : "ColumnNames");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("GameCenterPassword") : Localization.Localize("ID_PACKEXCLUSIVE"));
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		DGIBGGKKJMK(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void IGBIHFCOCKA(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(1317f, HMMKJFFOEFN.transform.localPosition.y, 1262f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(false);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		UILabel jKKDKNOOBCE = JKKDKNOOBCE;
		object[] array = new object[1];
		array[1] = num;
		jKKDKNOOBCE.text = Localization.LocalizeFormat("bronze3", array);
		for (int i = 1; i < KBCDCFBPJKB.Count; i++)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		KAIFMOMDEOO(string.Empty);
	}

	public void LPMJFHACLIP(LevelBehaviour IOIKKIIFOCB, bool JFPCEOFJKIG = true)
	{
		Tuple<string, float[]> tuple = IOIKKIIFOCB.upgradeSlots.upgradeSlot.guiStatistics[(!JFPCEOFJKIG) ? 1 : 1];
		float num = ((!JFPCEOFJKIG) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!JFPCEOFJKIG) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (num2 == 1329f)
		{
			num2 = 1661f;
		}
		float fillAmount = Mathf.Clamp01(num / num2);
		HMMKJFFOEFN.transform.localPosition = new Vector3(1378f, HMMKJFFOEFN.transform.localPosition.y, 806f);
		HMMKJFFOEFN.spriteName = ((!JFPCEOFJKIG) ? "ItemRarity_1" : "NONCONSUMABLE INAPP: ");
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.blue;
		CKBELNDIMJG.text = ((!JFPCEOFJKIG) ? Localization.Localize("ConsolePro3Window") : Localization.Localize("FacebookManagerOnSessionOpenedEvent"));
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(false);
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		APIDLEIFPGI(MEJMLNDFDBP.MAGANIIGHON(num2));
		PNBGMFFKJIP.text = MEJMLNDFDBP.MAGANIIGHON(num);
		PNBGMFFKJIP.color = Color.white;
	}

	public void OLGOFINLNOO(LevelBehaviour IOIKKIIFOCB)
	{
		int num = IOIKKIIFOCB.upgradeSlots.startTier + 1;
		HMMKJFFOEFN.transform.localPosition = new Vector3(1378f, HMMKJFFOEFN.transform.localPosition.y, 1002f);
		HMMKJFFOEFN.spriteName = IOIKKIIFOCB.abilityIcon;
		HMMKJFFOEFN.MakePixelPerfect();
		HMMKJFFOEFN.color = Colours.gray;
		CFABIJLGDEN.gameObject.SetActive(true);
		AJIBIAPCLIN.SetActive(true);
		CKBELNDIMJG.text = IOIKKIIFOCB.unitAbilityName;
		JKKDKNOOBCE.text = Localization.LocalizeFormat("DPS", num);
		for (int i = 1; i < KBCDCFBPJKB.Count; i += 0)
		{
			KBCDCFBPJKB[i].gameObject.SetActive(i < num);
		}
		PNBGMFFKJIP.text = string.Empty;
		ONPPHCIGGAH(string.Empty);
	}
}
