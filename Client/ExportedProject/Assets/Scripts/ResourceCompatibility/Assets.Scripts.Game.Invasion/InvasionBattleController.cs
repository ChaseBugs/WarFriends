using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.Game.Invasion
{
	public class InvasionBattleController : Core_BaseScript
	{
		[CompilerGenerated]
		private static InvasionBattleController _003CEGBGIGFPPGL_003Ek__BackingField;

		[SerializeField]
		private GameControllerInvasion gameController;

		[SerializeField]
		private InvasionSpawnController spawnController;

		[SerializeField]
		private InvaderShield shieldGuiPrefab;

		[SerializeField]
		private AudioClip shieldReplenishedAudio;

		[SerializeField]
		private AudioClip shieldDestroyedAudio;

		private Camera FALBFANKDOF;

		[CompilerGenerated]
		private float _003CPMJCBNADNFK_003Ek__BackingField;

		[CompilerGenerated]
		private Action OFBECJFOBCP;

		[CompilerGenerated]
		private EKILCCBNCPN _003CAONLNBPEJPF_003Ek__BackingField;

		[CompilerGenerated]
		private float _003CEPBPCDJGGFJ_003Ek__BackingField;

		[CompilerGenerated]
		private float _003COHCKJDPNHMN_003Ek__BackingField;

		private float ILIJBFCLAIC;

		private bool NNOCGKIDFPA;

		private int KIDMKLMFLBJ;

		private float OAJJJNKGJKL;

		public static InvasionBattleController instance
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public float invaderSpawnTime
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

		public float timeToInvaderSpawn => 0f;

		public float invaderWaitProgress => 0f;

		public EKILCCBNCPN invaderEnemy
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public float damageDoneToInvader
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

		public float healthBeforeBattle
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

		public virtual float healthRatio => 0f;

		public virtual float healthDuringBattle => 0f;

		public virtual float healthAfterBattle => 0f;

		public event Action onInvaderSpawned
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

		protected override void Awake()
		{
		}

		private void DJIKBALBFCM()
		{
		}

		private void LOHMGGPFOLL()
		{
		}

		private void HCOCHDHHLPC(GameController.ALOAMODMHMO DFEHIADKKNO)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void BOFIMFGKHIH()
		{
		}

		private void FKBJJBPKCJF()
		{
		}

		private void CEOIKJGMPJC()
		{
		}

		private void LKPLEFJDKCK(DestroyableObject AGECANAKJOL, DestroyableObject.LDOKCBNNLCH IEDOEMFMGCP)
		{
		}

		private void EBPEEMNGGEK(AIObject FKJGHEFHPKE, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
		{
		}

		private void NFFPKPBBKHL()
		{
		}
	}
}
