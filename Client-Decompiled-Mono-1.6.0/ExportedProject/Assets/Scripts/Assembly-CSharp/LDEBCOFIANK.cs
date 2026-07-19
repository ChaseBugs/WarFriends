using Newtonsoft.Json.Linq;
using UnityEngine;

public class LDEBCOFIANK : HHFHFANGCEJ
{
	private PHOOCBJEKDA MNGPKKKJKDD;

	private int ONKHFFGNNOE;

	private bool JGEBGFAPJKN;

	public virtual void AAHJOEILKNG()
	{
		base.JPGMEFJGNNA();
		CALACCCGMGD();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.ChatBan:
			GuiElementSingle<SystemMaintenanceDialog>.instance.JABOKGPNMKN(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			break;
		case (PHOOCBJEKDA)6:
			GameLoginManager.Relog();
			break;
		}
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		OJFJOJONNJK();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.ChatBan:
			GuiElementSingle<SystemMaintenanceDialog>.instance.ShowBannedFromChat(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			break;
		case PHOOCBJEKDA.GameBan:
			GameLoginManager.Relog();
			break;
		}
	}

	public LDEBCOFIANK(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		Debug.Log("Ban Chat Message received");
		MNGPKKKJKDD = OGNGMBLDAOP["BanType"]["N"].ToObject<PHOOCBJEKDA>();
		PHOOCBJEKDA mNGPKKKJKDD = MNGPKKKJKDD;
		if (mNGPKKKJKDD == PHOOCBJEKDA.ChatBan)
		{
			if (OGNGMBLDAOP["Timestamp"] != null)
			{
				ONKHFFGNNOE = OGNGMBLDAOP["Timestamp"]["N"].ToObject<int>();
				JGEBGFAPJKN = false;
				ChatBanManager.instance.BanPlayerFromChat(ONKHFFGNNOE);
			}
			else
			{
				ONKHFFGNNOE = 0;
				JGEBGFAPJKN = true;
				ChatBanManager.instance.BanPlayerFromChat();
			}
		}
	}

	public virtual void PCJHCBIHFNF()
	{
		base.OLECKGKLHCE();
		IFFBCOLBDOP();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.None:
			GuiElementSingle<SystemMaintenanceDialog>.instance.LMFICLELOOP(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			break;
		case PHOOCBJEKDA.ChatBan:
			GameLoginManager.Relog();
			break;
		}
	}

	public virtual void GBEBFIDEOHH()
	{
		base.LOFMDBHAFAO();
		OJFJOJONNJK();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.None:
			GuiElementSingle<SystemMaintenanceDialog>.instance.KNJPFBAMBAA(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
			break;
		case (PHOOCBJEKDA)3:
			GameLoginManager.Relog(false);
			break;
		}
	}

	public virtual void BHGDOHCBGEC()
	{
		base.LEJEDFACEGP();
		JFDENNGOGJC();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.None:
			GuiElementSingle<SystemMaintenanceDialog>.instance.CHNNKIKOKFC(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
			break;
		case (PHOOCBJEKDA)6:
			GameLoginManager.Relog(false);
			break;
		}
	}

	public virtual void IJPAEHAGPFK()
	{
		base.MGKMBCBBOHK();
		CALACCCGMGD();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.ChatBan:
			GuiElementSingle<SystemMaintenanceDialog>.instance.HAHCFLIPHAC(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
			break;
		case (PHOOCBJEKDA)8:
			GameLoginManager.Relog();
			break;
		}
	}

	public override void LOFMDBHAFAO()
	{
		base.OLECKGKLHCE();
		IFFBCOLBDOP();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.ChatBan:
			GuiElementSingle<SystemMaintenanceDialog>.instance.GIIHMPAMBOE(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
			break;
		case (PHOOCBJEKDA)5:
			GameLoginManager.Relog();
			break;
		}
	}

	public virtual void JBMCFEMBPKE()
	{
		base.GEKIMGFKNHC();
		OJFJOJONNJK();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.ChatBan:
			GuiElementSingle<SystemMaintenanceDialog>.instance.ONJNADPMDGK(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
			break;
		case (PHOOCBJEKDA)5:
			GameLoginManager.Relog();
			break;
		}
	}

	public virtual void FJILILFMPIF()
	{
		base.GEKIMGFKNHC();
		JFDENNGOGJC();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.ChatBan:
			GuiElementSingle<SystemMaintenanceDialog>.instance.MFGJPCGEHCD(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			break;
		case (PHOOCBJEKDA)4:
			GameLoginManager.Relog(false);
			break;
		}
	}

	public virtual void PEBHGOMEKME()
	{
		base.OBJEMJHBJFO();
		JFDENNGOGJC();
		switch (MNGPKKKJKDD)
		{
		case PHOOCBJEKDA.None:
			GuiElementSingle<SystemMaintenanceDialog>.instance.MFGJPCGEHCD(JGEBGFAPJKN, ChatBanManager.instance.RemainingBanTime());
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			break;
		case PHOOCBJEKDA.GameBan:
			GameLoginManager.Relog(false);
			break;
		}
	}
}
