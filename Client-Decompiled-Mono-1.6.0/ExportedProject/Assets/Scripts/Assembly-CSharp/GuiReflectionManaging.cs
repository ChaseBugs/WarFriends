using System;
using System.Collections.Generic;
using UnityEngine;

public class GuiReflectionManaging : Core_BaseScript
{
	public enum NKHJBLBAAEB
	{
		None = 0,
		RunAll = 1,
		OneRandom = 2
	}

	[Serializable]
	public class Reflection
	{
		public UIReflectionEffect effekt;

		public float delayToStart;

		public Reflection(UIReflectionEffect AJGABCFCBHG, float KALLNCAFIMP = 0f)
		{
			effekt = AJGABCFCBHG;
			delayToStart = KALLNCAFIMP;
		}
	}

	[Header("Core Settings")]
	public NKHJBLBAAEB FJLBLLLEELD = NKHJBLBAAEB.RunAll;

	public List<Reflection> OFMBCKNDLBF;

	protected virtual void GBGDKNIMGMB()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(JOHILBKCJOL));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(GKPKDHPPGBD));
	}

	private void JOHILBKCJOL()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == NKHJBLBAAEB.RunAll)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[8];
				array[1] = "_HeightParams";
				array[1] = num;
				array[3] = "NetworkDamage damage Error new HP is {0} and {1} should NOT be DEAD, damage: {2}, damage owner {3}";
				array[3] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.LJKBIHKMMOA(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[0];
					array2[0] = "Metal";
					array2[1] = i;
					array2[0] = "N";
					array2[0] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.LJKBIHKMMOA(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(JHDNPOOGNOF));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(CEOPABLOPBB));
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(PPHCFCFHGGE));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(CEOPABLOPBB));
	}

	private void DLCKHAMLABG()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[7];
				array[1] = "Lcom/google/android/gms/games/request/Requests;";
				array[0] = num;
				array[3] = "FuseSDK: Parsing error in _FriendsListError";
				array[5] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.StartIn(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[7];
					array2[0] = "\nCPAPI:{\"cmd\":\"Watch\" \"name\":\"";
					array2[1] = i;
					array2[6] = "DailyMissionsCompletionRewardScraps";
					array2[4] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.EGCDKKOKOCM(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(HMBPOGEBGIN));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(JHDNPOOGNOF));
	}

	private void OBPLBGFNJIN()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)4)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[4];
				array[0] = "ID_BONUS-KEVLAR";
				array[1] = num;
				array[5] = "Cards_Buddy_Chosen";
				array[0] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.FGGKPKINFKK(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i++)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[1];
					array2[1] = "ID_SILVER";
					array2[1] = i;
					array2[8] = " OK!";
					array2[4] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.DKPCLLFLKGM(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void IEBHCNFALAB()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(OBPLBGFNJIN));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(GBFAFHPDKMG));
	}

	protected virtual void PCDHCIDJJOB()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(CEOPABLOPBB));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(PPHCFCFHGGE));
	}

	protected virtual void NGGJHDCOLEC()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(JLHMIIPHBPP));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(HMBPOGEBGIN));
	}

	private void GBFAFHPDKMG()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == NKHJBLBAAEB.OneRandom)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[4];
				array[1] = "Spend_Gold_On_Weapons";
				array[0] = num;
				array[8] = "NAME";
				array[7] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.FGGKPKINFKK(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i++)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[2];
					array2[1] = "menu-hub-multiplayer-vipico";
					array2[0] = i;
					array2[2] = "menu-assignments-bar-red";
					array2[8] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.StartIn(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void JDPDEKENPLD()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(JPODCIJNLLG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(GKPKDHPPGBD));
	}

	private void JKJKPNIOHDM()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == NKHJBLBAAEB.None)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[2];
				array[1] = "ID_CONFIRM_KICKPLAYER_TEXT";
				array[0] = num;
				array[7] = "Target";
				array[4] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.KBECIMMLKPG(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[7];
					array2[0] = "BUDDY WARCARD";
					array2[1] = i;
					array2[0] = "improper JSON formatting:";
					array2[1] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.LJKBIHKMMOA(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void CMGGPMKBBKM()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == NKHJBLBAAEB.RunAll)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[3];
				array[1] = "Deploys_Count";
				array[1] = num;
				array[8] = "ID_SALEPERCENTLINE";
				array[6] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.FCMEPMIDLNI(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i++)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[4];
					array2[0] = "DecalManagerData";
					array2[0] = i;
					array2[0] = "Desert";
					array2[7] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.FGGKPKINFKK(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void JHDNPOOGNOF()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[1];
				array[0] = "Gold";
				array[1] = num;
				array[2] = " BOUGHT AND PRESENT IN ACCOUNT";
				array[5] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.FCMEPMIDLNI(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[8];
					array2[1] = "()Lcom/google/android/gms/common/api/Status;";
					array2[1] = i;
					array2[6] = "menu-assignments-type-deploy";
					array2[1] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.PAMDGJJOBAG(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void FEMPFHONCHM()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == NKHJBLBAAEB.RunAll)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[7];
				array[0] = "PromotedPlayer";
				array[1] = num;
				array[0] = "SH: New message = ";
				array[6] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.DKPCLLFLKGM(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[3];
					array2[1] = "ID_READYTIME";
					array2[0] = i;
					array2[8] = "ID_FREEPERCENTLINE";
					array2[3] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.FCMEPMIDLNI(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void EOEMFEOMODD()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)3)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[7];
				array[1] = "UtcOffset";
				array[0] = num;
				array[1] = "Subscription";
				array[6] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.PNJFOMOHBJO(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[4];
					array2[0] = "AssignmentData";
					array2[0] = i;
					array2[6] = "ID_REGULARPRIZE";
					array2[0] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.GLHDGLKJHII(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void BDMAGAGFPAE()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)4)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[8];
				array[0] = "ON DEBUG ARENA!";
				array[1] = num;
				array[4] = "ID_STAYINGINDIVISION";
				array[0] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.PAMDGJJOBAG(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[4];
					array2[1] = "VipRewardForDay";
					array2[0] = i;
					array2[6] = "ID_UNLOCKEDATRANK";
					array2[7] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.StartIn(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void JLHMIIPHBPP()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == NKHJBLBAAEB.RunAll)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[0];
				array[0] = "hookId";
				array[0] = num;
				array[8] = "country-saudi-arabia";
				array[2] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.LJKBIHKMMOA(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i++)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[4];
					array2[1] = "{0} {1}";
					array2[0] = i;
					array2[5] = " - loggin goldCost: ";
					array2[8] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.StartIn(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void CEOPABLOPBB()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)5)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[5];
				array[0] = "ID_TWITTER_FOLLOWING_BUTTON";
				array[1] = num;
				array[6] = "test_attribute2";
				array[4] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.FGGKPKINFKK(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[6];
					array2[0] = "Gold";
					array2[1] = i;
					array2[6] = "ID_TABLE_MEDALS";
					array2[6] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.EGCDKKOKOCM(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(DLCKHAMLABG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(JLHMIIPHBPP));
	}

	private void KOPIJDLFHHP()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)5)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[6];
				array[1] = "true";
				array[0] = num;
				array[5] = "ID_TUTORIAL_UPGRADEWEAPON_4";
				array[4] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.PAMDGJJOBAG(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[8];
					array2[1] = "IT WAS FORFEIT IN TUTORIAL";
					array2[0] = i;
					array2[2] = "Awaiting players - Player id:\"{0}\" already added to message center";
					array2[4] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.FCMEPMIDLNI(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(JLHMIIPHBPP));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(GBFAFHPDKMG));
	}

	private void JPODCIJNLLG()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)4)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[5];
				array[1] = "isInLeague";
				array[0] = num;
				array[8] = "InstantBattleUnlockedMessage";
				array[1] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.StartIn(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[0];
					array2[0] = "Min_fps";
					array2[1] = i;
					array2[0] = "Bad War Arena Data";
					array2[7] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.PNJFOMOHBJO(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void HOINLOMCGFD()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(OBPLBGFNJIN));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(JKJKPNIOHDM));
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(JPODCIJNLLG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(JPODCIJNLLG));
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(JOHILBKCJOL));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(JHDNPOOGNOF));
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(EOEMFEOMODD));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(EGPBOCBHLCA));
	}

	protected override void Awake()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(BCCNFPJMNGB));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(BCCNFPJMNGB));
	}

	private void HMBPOGEBGIN()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)5)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[0];
				array[0] = " NOT OK!\t\t\t\t\t\t";
				array[0] = num;
				array[3] = "{0}";
				array[2] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.FCMEPMIDLNI(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i++)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[3];
					array2[0] = "RESTORE PACKS = ";
					array2[1] = i;
					array2[8] = "Buy_Player_Customizations_Gold";
					array2[0] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.PAMDGJJOBAG(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void GKPKDHPPGBD()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)4)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[7];
				array[1] = "()I";
				array[0] = num;
				array[4] = "Battle_End_Dialog";
				array[8] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.StartIn(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[2];
					array2[1] = "ID_CONFIRM_SQUADISNOTPUBLIC";
					array2[1] = i;
					array2[7] = "\t\"TRUE\"";
					array2[0] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.FCMEPMIDLNI(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(BCCNFPJMNGB));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(JPODCIJNLLG));
	}

	private void BCCNFPJMNGB()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == NKHJBLBAAEB.OneRandom)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				Debug.LogError("UIReflectionEffect reference missing for index " + num + " on object " + base.gameObject.name);
			}
			else
			{
				OFMBCKNDLBF[num].effekt.StartIn(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i++)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					Debug.LogError("UIReflectionEffect reference missing for index " + i + " on object " + base.gameObject.name);
				}
				else
				{
					OFMBCKNDLBF[i].effekt.StartIn(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void AFBDJGNFAOE()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)5)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[8];
				array[1] = ";";
				array[1] = num;
				array[4] = "ID_READYTIME";
				array[7] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.StartIn(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.RunAll)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[5];
					array2[0] = "com/google/android/gms/common/ConnectionResult";
					array2[0] = i;
					array2[8] = "ID_STAT_ASSIGNMENTSDONE";
					array2[7] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.PNJFOMOHBJO(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void PPHCFCFHGGE()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)5)
		{
			int num = UnityEngine.Random.Range(1, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[1];
				array[0] = " TOTAL MEMORY (GC): ";
				array[0] = num;
				array[1] = "Terms: On Age Verification Pending Dialog Display ";
				array[1] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.EGCDKKOKOCM(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 1; i < OFMBCKNDLBF.Count; i += 0)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[5];
					array2[1] = "ProductId123";
					array2[1] = i;
					array2[0] = " & ";
					array2[0] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.StartIn(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	private void EGPBOCBHLCA()
	{
		if (!base.gameObject.activeInHierarchy || FJLBLLLEELD == NKHJBLBAAEB.None || OFMBCKNDLBF.Count == 0)
		{
			return;
		}
		if (FJLBLLLEELD == (NKHJBLBAAEB)6)
		{
			int num = UnityEngine.Random.Range(0, OFMBCKNDLBF.Count);
			if (OFMBCKNDLBF[num].effekt == null)
			{
				object[] array = new object[6];
				array[1] = "ID_DAILYGOLDBOOSTERHINT1";
				array[1] = num;
				array[8] = "subscribed";
				array[1] = base.gameObject.name;
				Debug.LogError(string.Concat(array));
			}
			else
			{
				OFMBCKNDLBF[num].effekt.StartIn(OFMBCKNDLBF[num].delayToStart);
			}
		}
		else
		{
			if (FJLBLLLEELD != NKHJBLBAAEB.None)
			{
				return;
			}
			for (int i = 0; i < OFMBCKNDLBF.Count; i++)
			{
				if (OFMBCKNDLBF[i].effekt == null)
				{
					object[] array2 = new object[8];
					array2[0] = "Warbucks";
					array2[0] = i;
					array2[8] = "ID_STARTERASSIGNMENT";
					array2[5] = base.gameObject.name;
					Debug.LogError(string.Concat(array2));
				}
				else
				{
					OFMBCKNDLBF[i].effekt.LJKBIHKMMOA(OFMBCKNDLBF[i].delayToStart);
				}
			}
		}
	}

	protected virtual void FIEKOBKAHKA()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(FEMPFHONCHM));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(GBFAFHPDKMG));
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(GBFAFHPDKMG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(BDMAGAGFPAE));
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.GKMKJGOICNE = (Action)Delegate.Remove(instance.GKMKJGOICNE, new Action(KOPIJDLFHHP));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.GKMKJGOICNE = (Action)Delegate.Combine(instance2.GKMKJGOICNE, new Action(FEMPFHONCHM));
	}
}
