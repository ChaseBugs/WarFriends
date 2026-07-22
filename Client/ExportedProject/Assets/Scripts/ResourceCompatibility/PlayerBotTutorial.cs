using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerBotTutorial : Core_BaseScript
{
	public enum GJJMGIDJMKC
	{
		Wait,
		ShootEnemies,
		ShootEnemyPlayer,
		ShootEnemyPlayerAndMoveALot
	}

	private sealed class NLCHLDNNCHM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public PlayerBotTutorial HNNCIECPFEJ;

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
		public NLCHLDNNCHM(int HEIHBBOBLGF)
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

	private sealed class AADDEGEOLOM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public PlayerBotTutorial HNNCIECPFEJ;

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
		public AADDEGEOLOM(int HEIHBBOBLGF)
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

	private GJJMGIDJMKC NBPLJAMOCNA;

	private List<DestroyableObject> EOKGGPHEEOD;

	private EnemyController HKJBGAMPBHG;

	private bool FGMOBKBKIGD;

	private bool NHOIFCIOGEL;

	private float CCJPNPOLJDH;

	private PlayerController CLIIKILEGOE;

	private PlayerController.NJHAKCPJBFD EHOBLKNEDHD;

	private PlayerController DHMBJIFPHPE;

	private float OFKPAFPDDDG;

	private GameShootableEntity.ShotTarget PANBJBCFEJB;

	private float FKOOEIDJJHH;

	private float OLMDADDKFMG;

	private float EJJBNDIMOPH;

	public PlayerController playerController => null;

	private bool EHLOGPEJJFI => false;

	private float NGKPFCDKNON => 0f;

	private bool PECFAFJBMBB => false;

	public GJJMGIDJMKC botState
	{
		get
		{
			return default(GJJMGIDJMKC);
		}
		set
		{
		}
	}

	private void GJODOJKHOOK()
	{
	}

	protected override void Awake()
	{
	}

	public void Init()
	{
	}

	private void DOLCIIEMHLB()
	{
	}

	protected void Update()
	{
	}

	private Vector3 JBPIMPHKKEM()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	private void CFOLOKHPJHE(float EIJEEEMEBIK = 0f)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected override void Start()
	{
	}

	public PlayerWeapon GetRiffle()
	{
		return null;
	}

	private PlayerWeapon BMFBAIGHMEP()
	{
		return null;
	}

	private IEnumerator CMOFPMLBPBN()
	{
		return null;
	}

	private MapDefinition.DefendPosition MLKACLCIPKL(MapDefinition.DefendPosition FLLFDLEMLJP, bool NAJPBJGMCCN)
	{
		return null;
	}

	private MapDefinition.DefendPosition OILPKAKBKME(MapDefinition.DefendPosition OEKEOADHEOB, MapDefinition.DefendPosition EGMJAECMHBP)
	{
		return null;
	}

	private void FBMAJBIFKHJ()
	{
	}

	private IEnumerator FGBKPIICDLN()
	{
		return null;
	}

	public void TryShootNow()
	{
	}

	private void GKNJMOGJKAI()
	{
	}

	private bool CMKFACFEHIE(Vector3 PNOJBGAFKLA)
	{
		return false;
	}

	private PlayerWeapon NADOOFPPIPC(GameShootableEntity PNDFOICMADO)
	{
		return null;
	}

	private GameShootableEntity AAKCBKFGNME()
	{
		return null;
	}

	private bool HMKPDGJFMPH(GameShootableEntity PNDFOICMADO)
	{
		return false;
	}

	private void HKCIPDNCLNB()
	{
	}
}
