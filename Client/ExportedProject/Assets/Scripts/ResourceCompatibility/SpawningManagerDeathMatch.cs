using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

[ExecuteInEditMode]
public class SpawningManagerDeathMatch : Singleton<SpawningManagerDeathMatch>
{
	[Serializable]
	public class ArmyUnit
	{
		public LevelBehaviour behaviour;

		public float fillAmount;

		public float fillAmountBack;

		public float height;

		public int index;

		public Vector3 localPosition;

		public string menuIcon;

		public UIWidget.Pivot pivot;

		public BBGEENNPNOA spawns;

		public List<ArmyUnitDefinition> unitsCounts;

		public override string ToString()
		{
			return null;
		}
	}

	[Serializable]
	public class ArmyUnitDefinition
	{
		[NonSerialized]
		[HideInInspector]
		public ArmyUnit armyUnit;

		[HideInInspector]
		public int index;

		public int numberOfEnemies;

		public int power => 0;

		public float coolDown => 0f;

		public override string ToString()
		{
			return null;
		}

		public bool EMGINELFFPN(HPHFGNJPDKN PNAJLHACGEO)
		{
			return false;
		}

		public bool JMFLICBKMFN(HPHFGNJPDKN PNAJLHACGEO, int IJFMHFCLKMN)
		{
			return false;
		}
	}

	private sealed class EOMOHFCPHON : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public SpawningManagerDeathMatch HNNCIECPFEJ;

		public HPHFGNJPDKN LBHJBBKENEO;

		public ArmyUnitDefinition GBOGLIGGINH;

		public bool HAOBFJDCOGM;

		private HPHFGNJPDKN PGDHFGEKMON;

		private int CMNODHACNOB;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public EOMOHFCPHON(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public List<ArmyUnit> MNCADFCCIGB;

	public float OKKNMAGJNCL;

	public List<ArmyUnitDefinition> CDDDHPNBAIE;

	public bool MNADNEEFDNG;

	public bool BBNDAJODFJJ;

	private ArmyUnitDefinition PADFFNHILMA;

	private bool FFOFDLCCMKB;

	private float IJOOHPDKDGK;

	private bool NBMCLLHOEJL;

	private bool JPHGFAKMCAF;

	private float LALONAAHIGD;

	private Dictionary<HPHFGNJPDKN, OBHPOHFIOHJ> EFAOAAEBBAG;

	private PhotonView IBBJLFJLAFA;

	private NetworkObjectPool MGIKOBMCJPL;

	private ArmyUnitDefinition EIKDPNIGHOD;

	private float? KIIDBOPMGOH;

	public Action<HPHFGNJPDKN, ArmyUnitDefinition> GMBBELKNHHL;

	public Action<HPHFGNJPDKN, ArmyUnitDefinition, bool> NJMKJBBJCAL;

	public ObscuredInt LHFICPOJFMF;

	public ObscuredInt LDKEHOMNJAM;

	public bool HCOBHJCDAJD;

	public HPHFGNJPDKN NBCFEPLOPMA;

	public int EJGGMEFBCMP;

	private Dictionary<LevelBehaviour.UnitType, List<ArmyUnitDefinition>> BGAKMJPNGKG;

	public Action<ArmyUnitDefinition> AHGEGAALMKO;

	[CompilerGenerated]
	private Action JGPLPHMIAJB;

	[CompilerGenerated]
	private Action<ArmyUnitDefinition> EFBAAACMHON;

	private Dictionary<HPHFGNJPDKN, List<ArmyUnitDefinition>> DNKBLIPACOC;

	[CompilerGenerated]
	private bool _003COLGPFLNCNAN_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CBENFHIPKBCL_003Ek__BackingField;

	private bool CALGEBLFLOD;

	private bool BEMOLKPGFMB;

	private float GNPDLGHMKKM;

	private bool FHOFGJOPOAD;

	public float progress => 0f;

	public bool autoDeployEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool semiAutoDeployEnabled
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public float autoDeployProgress
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool hasEnergyForAll => false;

	public bool hasEnergyForAtLeastOne => false;

	public bool canSendAllUnit => false;

	public bool powerForSemiDeploy => false;

	public int maxEnergy => 0;

	public event Action ArmyChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<ArmyUnitDefinition> RandomArmySent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void ResetAutoDeployProgress()
	{
	}

	protected override void Awake()
	{
	}

	protected void Update()
	{
	}

	public void SendRandomUnit()
	{
	}

	public bool PreGenerateRandomUnit(bool MOAPAAKJBML)
	{
		return false;
	}

	public void PreGenerateRandomUnit(ArmyUnitDefinition NGEDOMFLLKI)
	{
	}

	private void KLLMIABAAPC()
	{
	}

	private void EDOHFEOAHMJ()
	{
	}

	private void KMFNCCMFNKG(float GHMOCCOCDNO, float BBGNGLEDNCC)
	{
	}

	private void MHENPDPHCJK(GameController.ALOAMODMHMO DFEHIADKKNO)
	{
	}

	private void MHEOEODFIHB()
	{
	}

	protected override void Start()
	{
	}

	private void PMLDFKOPMND(AIObject FKJGHEFHPKE, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	private void FGIJKNGIDCJ(AIObject FKJGHEFHPKE)
	{
	}

	private ArmyUnit ILLBCGLHGLJ(AIObject FKJGHEFHPKE)
	{
		return null;
	}

	public List<ArmyUnitDefinition> GetTutorial(List<Tuple<int, int>> CDOAOACJOBO)
	{
		return null;
	}

	public void SetTutorialUnits(List<ArmyUnitDefinition> HEILPAPPHKJ)
	{
	}

	public List<ArmyUnitDefinition> GetThreeRandomUnits(HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	public List<ArmyUnitDefinition> GetCurrentlySpawnableUnits(HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	public void SendUnit(ArmyUnitDefinition GBOGLIGGINH, HPHFGNJPDKN LBHJBBKENEO, bool HAOBFJDCOGM = true, bool JDCJMMGEBBF = false)
	{
	}

	public void SendBotUnit(ArmyUnitDefinition GBOGLIGGINH, HPHFGNJPDKN LBHJBBKENEO)
	{
	}

	[PunRPC]
	private void SendUnitRPC(int EPNGMAHENPA, byte LBHJBBKENEO, bool HAOBFJDCOGM)
	{
	}

	private void NLFNDDANADL()
	{
	}

	[PunRPC]
	private void GetRandomUnitsForHost(byte LBHJBBKENEO, int MIFHPHNIMPF)
	{
	}

	[PunRPC]
	private void RecieveRandomUnitsForHost(byte[] NGFCEFFDEKK, int AOCDKEILCLP)
	{
	}

	private IEnumerator BDDJHCPPNJI(ArmyUnitDefinition GBOGLIGGINH, HPHFGNJPDKN LBHJBBKENEO, bool HAOBFJDCOGM = true)
	{
		return null;
	}

	private void OnDisable()
	{
	}

	public void Enable()
	{
	}

	public void ReSyncPower()
	{
	}

	[PunRPC]
	private void ReSyncPowerRPC(int EJDKHKCOBGI, int JFGOBLDOFNJ)
	{
	}
}
