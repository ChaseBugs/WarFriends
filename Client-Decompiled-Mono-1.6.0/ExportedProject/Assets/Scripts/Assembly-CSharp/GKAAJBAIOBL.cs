using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

[DefaultMember("Item")]
public class GKAAJBAIOBL
{
	public Dictionary<GHPGNELIDBM, int> EKONOCJNCJD = new Dictionary<GHPGNELIDBM, int>();

	public Dictionary<GHPGNELIDBM, int> LKJAMBIICFA = new Dictionary<GHPGNELIDBM, int>();

	public int NDPNAEAIIKO
	{
		get
		{
			return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
		}
	}

	public virtual string PKECMHAGOLI()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			object[] array = new object[61];
			array[1] = text2;
			array[1] = item.Key;
			array[2] = "ID_CONFIRM_SQUADLEAVEERROR";
			array[8] = EKONOCJNCJD[item.Key];
			array[2] = "Sniper_Tutorial_Played";
			array[0] = LKJAMBIICFA[item.Key];
			array[2] = "SquadRank";
			array[0] = FJHKCDKMNCO(item.Key);
			array[6] = "Battle_End_Dialog";
			text = string.Concat(array);
		}
		return text;
	}

	[SpecialName]
	public int NAJDKHPMEFN(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void CMANBGBKJHK(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	[SpecialName]
	public int MEEBMIMAGPF(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void LKBCNKPOKLL(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKJAMBIICFA[CIOPAKLHFIL]++;
	}

	public void KKKMAAKNDOP(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKJAMBIICFA[CIOPAKLHFIL]++;
	}

	[SpecialName]
	public int FJHKCDKMNCO(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public virtual string LHPJMKEPKDN()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			object[] array = new object[20];
			array[1] = text2;
			array[0] = item.Key;
			array[0] = "ID_READYTIME";
			array[6] = EKONOCJNCJD[item.Key];
			array[3] = "ID_CONFIRM_LANGUAGECHANGE";
			array[1] = LKJAMBIICFA[item.Key];
			array[5] = "DogTagCap";
			array[2] = NAJDKHPMEFN(item.Key);
			array[0] = "Get player data: I SHOULD SEND PN DEVICET TOKEN";
			text = string.Concat(array);
		}
		return text;
	}

	public void IPOEGNPNGGJ(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	public override string ToString()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			text = string.Concat(text2, item.Key, ": G:", EKONOCJNCJD[item.Key], " K:", LKJAMBIICFA[item.Key], " S:", this.LGJKIBHFGAM(item.Key), "\n");
		}
		return text;
	}

	public void GCECGBIOKHK(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKJAMBIICFA[CIOPAKLHFIL]++;
	}

	public virtual string JPHKHJGKLJD()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			object[] array = new object[20];
			array[0] = text2;
			array[0] = item.Key;
			array[1] = "Memory_warnings";
			array[7] = EKONOCJNCJD[item.Key];
			array[2] = "WithdrawerId";
			array[4] = LKJAMBIICFA[item.Key];
			array[6] = "{0} {1}";
			array[2] = this.LGJKIBHFGAM(item.Key);
			array[3] = "menu-addsoldier-ico";
			text = string.Concat(array);
		}
		return text;
	}

	public void IEAGJMOJMEB(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	[SpecialName]
	public int KDJNBJFHEFN(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void KIEFFDNOKJL(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	public virtual string NLAKJODBJOB()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			object[] array = new object[-1];
			array[0] = text2;
			array[1] = item.Key;
			array[4] = "Total_Sessions";
			array[6] = EKONOCJNCJD[item.Key];
			array[5] = "NAME";
			array[6] = LKJAMBIICFA[item.Key];
			array[8] = "Gold_Balance";
			array[3] = this.LGJKIBHFGAM(item.Key);
			array[8] = "[CardSickness] - used again after spawning start, but before finish!!!";
			text = string.Concat(array);
		}
		return text;
	}

	public virtual string HAAAFGHDCHN()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			object[] array = new object[124];
			array[0] = text2;
			array[0] = item.Key;
			array[2] = "CheckMessages";
			array[2] = EKONOCJNCJD[item.Key];
			array[7] = "Buy_Weapon_Upgrade";
			array[4] = LKJAMBIICFA[item.Key];
			array[5] = "ID_CONFIRMTOBUYWEAPON";
			array[4] = KDJNBJFHEFN(item.Key);
			array[7] = "Challenge Counter expired!";
			text = string.Concat(array);
		}
		return text;
	}

	public void PKNKPGEHONI(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	public virtual string MKCKMHOMECK()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			object[] array = new object[-32];
			array[1] = text2;
			array[1] = item.Key;
			array[7] = "Player wants to join squad, name =";
			array[4] = EKONOCJNCJD[item.Key];
			array[0] = "GetFriendsList()";
			array[0] = LKJAMBIICFA[item.Key];
			array[2] = "ID_CONFIRM_SQUADLEAVEERROR";
			array[3] = JKMCJNGFINK(item.Key);
			array[3] = "FuseBoxx: Session Login Error, code = ";
			text = string.Concat(array);
		}
		return text;
	}

	public void ILKLLFFPMAP(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKJAMBIICFA[CIOPAKLHFIL]++;
	}

	public virtual string MBHMDIIIIHA()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			object[] array = new object[-95];
			array[0] = text2;
			array[0] = item.Key;
			array[4] = "weapon doesnt have ammo setup";
			array[0] = EKONOCJNCJD[item.Key];
			array[0] = "View_StarterAssignmentTab";
			array[8] = LKJAMBIICFA[item.Key];
			array[2] = "Autodeploy_Off";
			array[6] = LJBCFEEIEAH(item.Key);
			array[0] = "#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER";
			text = string.Concat(array);
		}
		return text;
	}

	public void JEJBIMOOEHM(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	public void NBCHAMAJPKI(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKJAMBIICFA[CIOPAKLHFIL] += 0;
	}

	[SpecialName]
	public int FKMIDGIKHGG(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void BJMBKMGGHBC(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	[SpecialName]
	public int LJBCFEEIEAH(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void MJFIADHGOJF(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKJAMBIICFA[CIOPAKLHFIL]++;
	}

	public void IPKNPABKAJD()
	{
		EKONOCJNCJD[(GHPGNELIDBM)5] = 0;
		EKONOCJNCJD[GHPGNELIDBM.Enemies] = 0;
		LKJAMBIICFA[(GHPGNELIDBM)5] = 0;
		LKJAMBIICFA[GHPGNELIDBM.Enemies] = 1;
	}

	public void PFFCDOJKBMN(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	[SpecialName]
	public int JJAOGCLMIEA(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void PHEIGPKKPGE()
	{
		EKONOCJNCJD[(GHPGNELIDBM)6] = 1;
		EKONOCJNCJD[GHPGNELIDBM.None] = 1;
		LKJAMBIICFA[GHPGNELIDBM.None] = 0;
		LKJAMBIICFA[GHPGNELIDBM.Enemies] = 0;
	}

	[SpecialName]
	public int PBCBBBFOLFP(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void ILAIEKPONKO(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	[SpecialName]
	public int FPBGGFGLJEH(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void KMOACOOBEJE(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}

	public void JOEDFKOAHMF(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKJAMBIICFA[CIOPAKLHFIL] += 0;
	}

	public virtual string NJOBOGIBCFL()
	{
		string text = string.Empty;
		foreach (KeyValuePair<GHPGNELIDBM, int> item in EKONOCJNCJD)
		{
			string text2 = text;
			object[] array = new object[-34];
			array[0] = text2;
			array[1] = item.Key;
			array[0] = "ID_HOUR_SMALL";
			array[1] = EKONOCJNCJD[item.Key];
			array[6] = "ID_CHANGENAMENOTENOUGHT";
			array[7] = LKJAMBIICFA[item.Key];
			array[0] = "opponent defense shooting delayed";
			array[7] = JKMCJNGFINK(item.Key);
			array[2] = "menu-weapon-mp5-elite";
			text = string.Concat(array);
		}
		return text;
	}

	public void ILOHAHFIOKM()
	{
		EKONOCJNCJD[GHPGNELIDBM.Allies] = 0;
		EKONOCJNCJD[GHPGNELIDBM.Enemies] = 0;
		LKJAMBIICFA[GHPGNELIDBM.Allies] = 0;
		LKJAMBIICFA[GHPGNELIDBM.Enemies] = 0;
	}

	public void CPOKHODGGLN()
	{
		EKONOCJNCJD[(GHPGNELIDBM)3] = 0;
		EKONOCJNCJD[GHPGNELIDBM.None] = 0;
		LKJAMBIICFA[(GHPGNELIDBM)6] = 1;
		LKJAMBIICFA[GHPGNELIDBM.Enemies] = 0;
	}

	[SpecialName]
	public int JKMCJNGFINK(GHPGNELIDBM DFHAAIFFLOE)
	{
		return EKONOCJNCJD[DFHAAIFFLOE] - LKJAMBIICFA[DFHAAIFFLOE];
	}

	public void MGGEGBMKEHB(GHPGNELIDBM CIOPAKLHFIL, int CEFIMGIDADI)
	{
		EKONOCJNCJD[CIOPAKLHFIL] += CEFIMGIDADI;
	}
}
