using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class SkillShotManager : Singleton<SkillShotManager>, NKMKCCDCHCL, KMHCMCBGFFC
{
	[Serializable]
	public class SkillShotItemDefinition
	{
		[SerializeField]
		public string dictionaryId;

		[SerializeField]
		public string menuName;

		[SerializeField]
		public SkillShot.SkillShotType skillShotType;

		[SerializeField]
		public string iconName;

		public SkillshotsRow row;

		public int points
		{
			get
			{
				if (Singleton<GameController>.instance.isMission)
				{
					return row.SCORESINGLE;
				}
				return row.SCOREMP;
			}
		}

		[SpecialName]
		public int DHHLAHJDGKD()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int IDBONODEICC()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int GGFPPMCMEIE()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int EIMIDJGJIDB()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int OAJMJBNADEN()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int BFHBANKELNE()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int OPHFMAKOBAD()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int GLFAMGMCCBE()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int EMNPMFNOAKG()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int CFIIHCFCHON()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int HODDAMGCBLK()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int EOLNFINPGKE()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int NBIAILCFPFK()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int LAFKCHDBKCA()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int PJCDHCAGMAN()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int BPMOMFLMCFO()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int JIPHAOIGJEC()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int CLGCIOKMOIF()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int MOEJFHMCINA()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int AODKIAHPFHP()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int EGBAKFPIJGA()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int BHBEHCKIKDF()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int JODAFIGMJAA()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int EMNHFFCLNBI()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int CGMBBONDNDI()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int KMMENELFEMG()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int PIOFGEJPOGO()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int DMPKCHABPGN()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int MJLNOLAMOPA()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int BECALLGAMPP()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int HFNEGHCDDLI()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int DBAFKGONCKF()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int MHLHGMFLLHH()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int ACLGMIBFBJN()
		{
			if (Singleton<GameController>.instance.ECHCLJJJPML())
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}

		[SpecialName]
		public int PDIPOFEMCJH()
		{
			if (Singleton<GameController>.instance.isMission)
			{
				return row.SCORESINGLE;
			}
			return row.SCOREMP;
		}
	}

	[FormerlySerializedAs("LKFIHLLBGPD")]
	public float NAHGKFBBLGI = 4f;

	[FormerlySerializedAs("FDNODMODKDK")]
	public float OGGMFFEMJPL = 1f;

	[FormerlySerializedAs("IECPBPNFDJB")]
	public bool CIKAHGKAGNG;

	private float GJOICECBKOK;

	private int AFDKNJDJMEM;

	[FormerlySerializedAs("MAKKAMIIGOK")]
	public List<SkillShotItemDefinition> CILELMJLFGK;

	[FormerlySerializedAs("JLMIJDLAEIN")]
	public ObjectPool CHDIOFDMHEF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action BDEDOFGECNH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> FJHBCIAKBPF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> FIDJIJFEEIH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int _003CCDNMFDJOELD_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _003CFCIBDHGKAGG_003Ek__BackingField;

	public int power
	{
		[CompilerGenerated]
		get
		{
			return _003CCDNMFDJOELD_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CCDNMFDJOELD_003Ek__BackingField = value;
		}
	}

	public bool isAlive
	{
		[CompilerGenerated]
		get
		{
			return _003CFCIBDHGKAGG_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CFCIBDHGKAGG_003Ek__BackingField = value;
		}
	}

	public GHPGNELIDBM fraction
	{
		get
		{
			return GHPGNELIDBM.Allies;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public KMHCMCBGFFC owner => this;

	public event Action SkillshotsChanged
	{
		add
		{
			Action action = BDEDOFGECNH;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BDEDOFGECNH, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = BDEDOFGECNH;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BDEDOFGECNH, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> Killed
	{
		add
		{
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> FractionChanged
	{
		add
		{
			Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action = FIDJIJFEEIH;
			Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FIDJIJFEEIH, (Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action = FIDJIJFEEIH;
			Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FIDJIJFEEIH, (Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public bool BPOHFOHJDPB()
	{
		return _003CFCIBDHGKAGG_003Ek__BackingField;
	}

	public void AddSkillshot(SkillShot IFDBMJEAGND, PlayerController NPHCOBMHFND)
	{
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			if ((IFDBMJEAGND.type & item.skillShotType) == item.skillShotType)
			{
				Singleton<ScoreManager>.instance.AddSkillshot(item, NPHCOBMHFND);
			}
		}
		if (BDEDOFGECNH != null)
		{
			BDEDOFGECNH();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		CHDIOFDMHEF = ObjectPool.GetPool("ObjectPool");
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			item.menuName = Localization.Localize(item.dictionaryId);
			item.iconName = "game-skillshot-" + item.skillShotType.ToString().ToLower();
		}
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MMEKFOHGAKK;
	}

	public SkillShotItemDefinition KCIMGPEIGJH(SkillShot.SkillShotType IFDBMJEAGND)
	{
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			if (item.skillShotType == IFDBMJEAGND)
			{
				return item;
			}
		}
		return null;
	}

	public SkillShot.SkillShotType GetSkillshot(string MHPNDNJDPGE)
	{
		return (SkillShot.SkillShotType)Enum.Parse(typeof(SkillShot.SkillShotType), MHPNDNJDPGE);
	}

	public SkillShotItemDefinition GetSkillshotDefinition(SkillShot.SkillShotType PNIJJIPEFJL)
	{
		for (int i = 0; i < CILELMJLFGK.Count; i++)
		{
			if (CILELMJLFGK[i].skillShotType == PNIJJIPEFJL)
			{
				return CILELMJLFGK[i];
			}
		}
		return CILELMJLFGK[0];
	}

	[SpecialName]
	public GHPGNELIDBM POCNJLHELJB()
	{
		return (GHPGNELIDBM)4;
	}

	private void MMEKFOHGAKK()
	{
		Skillshots component = GetComponent<Skillshots>();
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			SkillshotsRow row = component.GetRow(item.skillShotType.ToString());
			if (row != null)
			{
				item.row = row;
			}
			else
			{
				UnityEngine.Debug.LogError("Dont have excel row for skillshot: " + item.skillShotType);
			}
		}
	}

	public SkillShotItemDefinition GetItemDefinition(SkillShot.SkillShotType IFDBMJEAGND)
	{
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			if (item.skillShotType == IFDBMJEAGND)
			{
				return item;
			}
		}
		return null;
	}

	public void IFAECFKOIMJ(SkillShot IFDBMJEAGND, ref List<SkillShotItemDefinition> EDNLBEDPMCM)
	{
		EDNLBEDPMCM.Clear();
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			if ((IFDBMJEAGND.type & item.skillShotType) == item.skillShotType)
			{
				EDNLBEDPMCM.Add(item);
			}
		}
	}

	public void RecieveKill(ref SkillShot IFDBMJEAGND)
	{
		if (Time.time < GJOICECBKOK + OGGMFFEMJPL)
		{
			AFDKNJDJMEM++;
		}
		else
		{
			AFDKNJDJMEM = 1;
		}
		GJOICECBKOK = Time.time;
		if (AFDKNJDJMEM == 2)
		{
			IFDBMJEAGND.type |= SkillShot.SkillShotType.DoubleKill;
		}
		if (AFDKNJDJMEM == 3)
		{
			IFDBMJEAGND.type |= SkillShot.SkillShotType.TrippleKill;
		}
		if (AFDKNJDJMEM > 3)
		{
			IFDBMJEAGND.type |= SkillShot.SkillShotType.MultiKill;
		}
	}

	public void JJDAONGANCB(SkillShot IFDBMJEAGND, ref List<SkillShotItemDefinition> EDNLBEDPMCM)
	{
		EDNLBEDPMCM.Clear();
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			if ((IFDBMJEAGND.type & item.skillShotType) == item.skillShotType)
			{
				EDNLBEDPMCM.Add(item);
			}
		}
	}

	public SkillShotItemDefinition CLDHDLHMABL(SkillShot.SkillShotType PNIJJIPEFJL)
	{
		for (int i = 0; i < CILELMJLFGK.Count; i++)
		{
			if (CILELMJLFGK[i].skillShotType == PNIJJIPEFJL)
			{
				return CILELMJLFGK[i];
			}
		}
		return CILELMJLFGK[0];
	}

	[SpecialName]
	public void LGDCBDNGELM(Action IDEBKDPMPGM)
	{
		Action action = BDEDOFGECNH;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BDEDOFGECNH, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void ODJLFAEGFHG(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public GHPGNELIDBM EMIIJMBDCAB()
	{
		return GHPGNELIDBM.None;
	}

	public void GetItemDefinitions(SkillShot IFDBMJEAGND, ref List<SkillShotItemDefinition> EDNLBEDPMCM)
	{
		EDNLBEDPMCM.Clear();
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			if ((IFDBMJEAGND.type & item.skillShotType) == item.skillShotType)
			{
				EDNLBEDPMCM.Add(item);
			}
		}
	}

	private void KHLHJGFDGMK()
	{
		Skillshots component = GetComponent<Skillshots>();
		foreach (SkillShotItemDefinition item in CILELMJLFGK)
		{
			SkillshotsRow row = component.GetRow(item.skillShotType.ToString());
			if (row != null)
			{
				item.row = row;
			}
			else
			{
				UnityEngine.Debug.LogError("These IDs have different translations:\n" + item.skillShotType);
			}
		}
	}

	[SpecialName]
	public void GMIBBKCKPAD(Action IDEBKDPMPGM)
	{
		Action action = BDEDOFGECNH;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BDEDOFGECNH, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public SkillShot.SkillShotType HLDMCOLCDBN(string MHPNDNJDPGE)
	{
		return (SkillShot.SkillShotType)Enum.Parse(typeof(SkillShot.SkillShotType), MHPNDNJDPGE);
	}
}
