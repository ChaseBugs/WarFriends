using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JEJHNAPPOFN : HHFHFANGCEJ
{
	public DatabasePlayer BMIPPPIDGOG;

	public override bool JLCLGAKDIMG
	{
		get
		{
			return true;
		}
	}

	[SpecialName]
	public virtual bool PJJAHFFKBOJ()
	{
		return false;
	}

	public virtual void ILFJPOOMFDO()
	{
		base.MGKMBCBBOHK();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 93 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, false);
			}
			if (flag2)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName);
			}
		}
		CGOOGHIJOAH();
	}

	public override void LACLELOOKHD()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 170 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (!flag || flag2)
		{
			object[] array = new object[5];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_CONFIRM_EXITINGCOOP_TEXT", string.Empty, false);
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "ArenaVisualMessage", string.Empty, false);
			array[5] = flag;
			Debug.LogFormat("ID_INVITATION_VALID_FOR", array);
			IFFBCOLBDOP();
		}
	}

	public virtual void OCPIKHHMHAN(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (BMIPPPIDGOG.id == KHLGDCHJJPB.id)
		{
			BMIPPPIDGOG.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void JOCFHKJPEPO()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 20 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (!flag || flag2)
		{
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "-", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "ID_TUTORIAL_SWIPE_UP2", string.Empty, false);
			array[8] = flag;
			Debug.LogFormat("AttackCoef", array);
			IFFBCOLBDOP();
		}
	}

	public virtual void IEEENGDDELF()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -105 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (!flag || flag2)
		{
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_WARNING_CANNOTCREATESQUAD", string.Empty, false);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "s", string.Empty, false);
			array[7] = flag;
			Debug.LogFormat("league", array);
			JFDENNGOGJC();
		}
	}

	public virtual void MNOANMDLAMC()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 168 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (!flag || flag2)
		{
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_WARNING_FAILDOWNLOADINGASSET", string.Empty);
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "ID_READYTIME", string.Empty);
			array[1] = flag;
			Debug.LogFormat("Pause Camera", array);
			CALACCCGMGD();
		}
	}

	public virtual void OBOCAJKJMPC()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -120 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "hashCode", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "Hole", string.Empty);
			array[0] = flag;
			Debug.LogFormat("AutoRotate Weapon", array);
			BCIOBLLBLLC();
		}
	}

	[SpecialName]
	public virtual bool PFDFPBJAAJD()
	{
		return false;
	}

	public virtual void KHCIMEFCJFC()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 15 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (flag)
		{
			if (Singleton<Chat>.instance.ONIBJDJIAMO())
			{
				GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this);
			}
			if (flag2)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
			}
		}
		AKICNBAOGOL();
	}

	public virtual void GMCDMOFNEFC(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (BMIPPPIDGOG.id == KHLGDCHJJPB.id)
		{
			BMIPPPIDGOG.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void DIHHMNFOMPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (BMIPPPIDGOG.id == KHLGDCHJJPB.id)
		{
			BMIPPPIDGOG.level = KHLGDCHJJPB.level;
		}
	}

	public override void CJPBMDDGDHG()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 172800 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogFormat("#PETER# Removing squad left message - message time:{0}, server time:{1}, isInSquad:{2}", MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), flag);
			OJFJOJONNJK();
		}
	}

	public virtual void LCCEEAMLHDD()
	{
		base.LEJEDFACEGP();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -4 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, false);
			}
			if (flag2)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, true);
			}
		}
		LACLELOOKHD();
	}

	public virtual void ONCKKJFAMKF()
	{
		base.OBJEMJHBJFO();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + -91 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.BGOHKEGGHMH(this, false);
			}
			if (flag2)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, true);
			}
		}
		OIDDCBBFBHJ();
	}

	public override void GDOIFOIGDPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (BMIPPPIDGOG.id == KHLGDCHJJPB.id)
		{
			BMIPPPIDGOG.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void NJFKGGIBOOA(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (BMIPPPIDGOG.id == KHLGDCHJJPB.id)
		{
			BMIPPPIDGOG.level = KHLGDCHJJPB.level;
		}
	}

	public JEJHNAPPOFN()
		: base("SquadLeft", NKHJBLBAAEB.SquadLeft)
	{
		BMIPPPIDGOG = GameLoginManager.currentPlayer;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (flag)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AddDatabaseMessageToSquadChat(this);
			}
			if (flag2)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
			}
		}
		CJPBMDDGDHG();
	}

	public virtual void PFNBDPFAKBN()
	{
		base.GEKIMGFKNHC();
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = KJCKFGCLGLG + 34 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (flag)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HKGAPGAKFHA(this, false);
			}
			if (flag2)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName);
			}
		}
		CGOOGHIJOAH();
	}

	public JEJHNAPPOFN(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		BMIPPPIDGOG = new DatabasePlayer();
		if (OGNGMBLDAOP["PlayerName"] != null)
		{
			BMIPPPIDGOG.accountName = KHJJFPPACBP.BKFCLMMJNHK("PlayerName", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["Level"] != null)
		{
			BMIPPPIDGOG.level = KHJJFPPACBP.PELILBMKGHE("Level", "N", OGNGMBLDAOP);
		}
		if (OGNGMBLDAOP["playerId"] != null)
		{
			BMIPPPIDGOG.id = KHJJFPPACBP.BKFCLMMJNHK("playerId", "S", OGNGMBLDAOP, string.Empty);
		}
	}

	[SpecialName]
	public virtual bool IIPHFOBEANP()
	{
		return false;
	}
}
