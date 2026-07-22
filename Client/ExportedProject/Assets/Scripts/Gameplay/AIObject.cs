using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class AIObject : MainGameEntity, NKMKCCDCHCL, KMHCMCBGFFC
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Action<AIObject, DestroyableObject.CJLNCMMNPBM> JGGMGHNEJCJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> FJHBCIAKBPF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static Action<AIObject> AHGNBGPMJFO;

	[FormerlySerializedAs("FFBFBMDMEGB")]
	public LevelBehaviour IAJJBAJOGDM;

	[FormerlySerializedAs("DJDKOBKAJEO")]
	public LevelBehaviour ACLDFHJKBLI;

	[FormerlySerializedAs("BOCCHNDLCOJ")]
	public UpgradeSlots.UnitUpgrades PFGLIAHPMCK;

	public FCLADBGKCIA IGKDFJKEELP = new FCLADBGKCIA();

	public GHPGNELIDBM ODCLPMADGFC = GHPGNELIDBM.Enemies;

	[FormerlySerializedAs("DONHPIMOLAA")]
	public bool LCDBACDIODH;

	protected int IAICPGNGCJI;

	protected bool DIPLDDHLMME = true;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _003CCPAAPMCEIOL_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CAEGCDODHGKL_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CCODGFCNCDOA_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string _003CMALPPPFOAOC_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private float _003CEANDEJBKHFH_003Ek__BackingField;

	private AimTarget[] DHBMIGAMNDK;

	private bool BIMAIJLKENC;

	public float spawnTime
	{
		[CompilerGenerated]
		get
		{
			return _003CCPAAPMCEIOL_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			_003CCPAAPMCEIOL_003Ek__BackingField = value;
		}
	}

	public bool spawnedByCard
	{
		[CompilerGenerated]
		get
		{
			return _003CAEGCDODHGKL_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CAEGCDODHGKL_003Ek__BackingField = value;
		}
	}

	public int spawnedCardLevel
	{
		[CompilerGenerated]
		get
		{
			return _003CCODGFCNCDOA_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCODGFCNCDOA_003Ek__BackingField = value;
		}
	}

	public string cardId
	{
		[CompilerGenerated]
		get
		{
			return _003CMALPPPFOAOC_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CMALPPPFOAOC_003Ek__BackingField = value;
		}
	}

	public float cardProgress
	{
		[CompilerGenerated]
		get
		{
			return _003CEANDEJBKHFH_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CEANDEJBKHFH_003Ek__BackingField = value;
		}
	}

	public bool hasSpecial => PFGLIAHPMCK.isSpecial;

	public override int power
	{
		get
		{
			return IAICPGNGCJI;
		}
		set
		{
			if (LAADDLGBFIG != null && Singleton<PhotonConnectionManager>.instance.isMasterClient)
			{
				IAICPGNGCJI = value;
				LAADDLGBFIG.RPC("SetPower", PhotonTargets.Others, (byte)value);
			}
		}
	}

	public override GHPGNELIDBM fraction
	{
		get
		{
			return ODCLPMADGFC;
		}
		set
		{
			if (ODCLPMADGFC != value)
			{
				ODCLPMADGFC = value;
			}
		}
	}

	public override KMHCMCBGFFC owner
	{
		get
		{
			return this;
		}
		set
		{
		}
	}

	public static event Action<AIObject, DestroyableObject.CJLNCMMNPBM> AIObjectKilled
	{
		add
		{
			Action<AIObject, DestroyableObject.CJLNCMMNPBM> action = JGGMGHNEJCJ;
			Action<AIObject, DestroyableObject.CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref JGGMGHNEJCJ, (Action<AIObject, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<AIObject, DestroyableObject.CJLNCMMNPBM> action = JGGMGHNEJCJ;
			Action<AIObject, DestroyableObject.CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref JGGMGHNEJCJ, (Action<AIObject, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public override event Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> Killed
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

	public static event Action<AIObject> AfterSpawned
	{
		add
		{
			Action<AIObject> action = AHGNBGPMJFO;
			Action<AIObject> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AHGNBGPMJFO, (Action<AIObject>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<AIObject> action = AHGNBGPMJFO;
			Action<AIObject> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AHGNBGPMJFO, (Action<AIObject>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[PunRPC]
	public virtual void ReSyncDisabledRPC()
	{
		if (base.isInstantiated)
		{
			DestroyPooled();
		}
	}

	[PunRPC]
	protected void SpawnByCardRPC(float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		PFGLIAHPMCK = new UpgradeSlots.UnitUpgrades(1f);
		cardProgress = PAENPHMEMGC;
		cardId = ICDKHLOBKIE;
		spawnedByCard = true;
		UnityEngine.Debug.Log($"Spawned by card:  progress:{cardProgress}, obj: {base.gameObject.name},uu: {PFGLIAHPMCK} ");
	}

	public virtual void UpgradesLoaded()
	{
		spawnTime = Time.realtimeSinceStartup;
		if (destroyableObj != null)
		{
			destroyableObj.JEGFCLCJMLA = false;
			destroyableObj.healthbarColor = ((PlayerController.OGMBJPKOPCB.fraction == fraction) ? Color.green : Color.red);
			if (fraction != GHPGNELIDBM.None)
			{
				if (PlayerController.OGMBJPKOPCB.fraction != fraction && DebugSettings.instance.data.forceOpponentHB)
				{
					destroyableObj.JEGFCLCJMLA = true;
				}
				if (PlayerController.OGMBJPKOPCB.fraction == fraction && DebugSettings.instance.data.forceMyHB)
				{
					destroyableObj.JEGFCLCJMLA = true;
				}
			}
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			spawnedCardLevel = (int)(cardProgress * (float)LevelManager.instance.maxDisplayLevel);
			string text = ((actualLevelForIndex <= 0 || Singleton<GameController>.instance.isTutorial) ? string.Empty : actualLevelForIndex.ToString());
			if (spawnedByCard)
			{
				text = ((spawnedCardLevel <= 0 || Singleton<GameController>.instance.isTutorial) ? string.Empty : spawnedCardLevel.ToString());
			}
			if (Singleton<GameController>.instance.isWarArena)
			{
				text = string.Empty;
			}
			destroyableObj.SetText(text);
			destroyableObj.SetBuffs(IGKDFJKEELP);
		}
		AimTarget[] dHBMIGAMNDK = DHBMIGAMNDK;
		foreach (AimTarget aimTarget in dHBMIGAMNDK)
		{
			aimTarget.gameObject.SetActive(PlayerController.OGMBJPKOPCB.fraction != fraction);
		}
		ODDDGIALOPM(fraction);
	}

	[PunRPC]
	protected void SyncUpgradesRPC(byte KFBOCCACLLK, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ)
	{
		fraction = (GHPGNELIDBM)KFBOCCACLLK;
		if (!spawnedByCard)
		{
			PFGLIAHPMCK = KBBDGCLPOCJ;
			if (ACLDFHJKBLI != null)
			{
				IGKDFJKEELP = Singleton<GameController>.instance.mainController.CheckForPerks(ACLDFHJKBLI, fraction);
				ACLDFHJKBLI.upgradeSlots.LoadData(ACLDFHJKBLI, PFGLIAHPMCK, IGKDFJKEELP);
			}
		}
		else
		{
			PFGLIAHPMCK = KBBDGCLPOCJ;
			IAJJBAJOGDM.upgradeSlots.LoadDataForCard(ACLDFHJKBLI, cardProgress);
			IGKDFJKEELP = new FCLADBGKCIA();
		}
		ACLDFHJKBLI.behaviourDefinition.MIKOLPDBCLK(PFGLIAHPMCK.scaleDamage, PFGLIAHPMCK.scaleHp);
		UpgradesLoaded();
	}

	[SpecialName]
	public string NFJMLOKBEON()
	{
		return _003CMALPPPFOAOC_003Ek__BackingField;
	}

	public virtual void MAGNFBCGDDI()
	{
		if (base.isAlive && PPHLEDLNGIN())
		{
			float mNAJKODCACI = ((!(destroyableObj != null)) ? 961f : destroyableObj.health);
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[5];
			array[0] = (byte)fraction;
			array[0] = base.transform.position;
			array[2] = base.transform.rotation;
			array[7] = PFGLIAHPMCK;
			array[0] = spawnedByCard;
			array[6] = cardProgress;
			array[7] = NFJMLOKBEON();
			lAADDLGBFIG.RPC("GoldBalance", PhotonTargets.All, array);
			ACLDFHJKBLI.ReSync();
			if (destroyableObj != null && !destroyableObj.HNOMJIALPMM())
			{
				destroyableObj.RefillTo(mNAJKODCACI);
			}
		}
		else
		{
			LAADDLGBFIG.RPC("GameControllerCoop.StartGame DONE", PhotonTargets.All, new object[1]);
		}
	}

	protected void ILOBGDOCKFH(byte JNMJLBOECLB)
	{
		fraction = (GHPGNELIDBM)JNMJLBOECLB;
		INDACALKMFI();
	}

	public virtual void NJHLFLIBBCL()
	{
		if (base.isAlive && PLPBGNOCCPI())
		{
			float mNAJKODCACI = ((!(destroyableObj != null)) ? 1518f : destroyableObj.health);
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[3];
			array[0] = (byte)fraction;
			array[0] = base.transform.position;
			array[8] = base.transform.rotation;
			array[0] = PFGLIAHPMCK;
			array[4] = spawnedByCard;
			array[7] = cardProgress;
			array[3] = cardId;
			lAADDLGBFIG.RPC(")", PhotonTargets.All, array);
			ACLDFHJKBLI.ReSync();
			if (destroyableObj != null && !destroyableObj.HNOMJIALPMM())
			{
				destroyableObj.RefillTo(mNAJKODCACI);
			}
		}
		else
		{
			LAADDLGBFIG.RPC("ID_DEBUG_GUIERROR", PhotonTargets.Others, new object[1]);
		}
	}

	public virtual void DisableSpawn()
	{
		DIPLDDHLMME = false;
	}

	[PunRPC]
	public virtual void ReSyncRPC(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ, bool LGKBHPBDNFE, float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		if (!Singleton<PhotonConnectionManager>.instance.isMasterClient && LAADDLGBFIG.isMine)
		{
			UnityEngine.Debug.LogError($"Error in Resync OwnerId: {LAADDLGBFIG.ownerId}, My Id: {PhotonNetwork.player.ID}, isOwnerActive: {LAADDLGBFIG.isOwnerActive}, isMasterClient:{PhotonNetwork.isMasterClient}");
		}
		if (!base.isInstantiated || !base.isAlive)
		{
			if (base.isInstantiated && !base.isAlive)
			{
				DestroyPooled();
			}
			if (LGKBHPBDNFE)
			{
				SpawnByCardRPC(PAENPHMEMGC, ICDKHLOBKIE);
			}
			base.pool.ReInstantiate(this, FLJHPFJFJIN, OOMCGGAFJNH);
			SyncUpgradesRPC(KFBOCCACLLK, KBBDGCLPOCJ);
		}
	}

	public bool CanSeeTarget(Vector3 JGBFNKBFCKM, Vector3 OEDJOFINBMI)
	{
		Vector3 vector = JGBFNKBFCKM;
		Vector3 normalized = (OEDJOFINBMI - vector).normalized;
		vector += 0.18f * normalized;
		Ray ray = new Ray(vector, normalized);
		float maxDistance = Mathf.Clamp(Vector3.Distance(vector, OEDJOFINBMI) - 0.5f, 0.1f, float.MaxValue);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, maxDistance, (1 << TagsAndLayers.GIDHAMNOIHG) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
		}
		return !flag;
	}

	protected bool BIBOEDCOKAA(Vector3 OEDJOFINBMI)
	{
		Vector3 vector = base.transform.position + Vector3.up * 0.5f;
		Vector3 normalized = (OEDJOFINBMI - vector).normalized;
		vector += 0.5f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, OEDJOFINBMI) - 0.5f, 0.1f, float.MaxValue), (1 << TagsAndLayers.GIDHAMNOIHG) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
		}
		return !flag;
	}

	public static bool CanSeeTargetStatic(Vector3 JGBFNKBFCKM, Vector3 OEDJOFINBMI, float MKOGHDKDFIN = 0.25f)
	{
		Vector3 vector = JGBFNKBFCKM;
		Vector3 normalized = (OEDJOFINBMI - vector).normalized;
		vector += MKOGHDKDFIN * normalized;
		Ray ray = new Ray(vector, normalized);
		float maxDistance = Mathf.Clamp(Vector3.Distance(vector, OEDJOFINBMI) - 0.5f, 0.1f, float.MaxValue);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, maxDistance, (1 << TagsAndLayers.GIDHAMNOIHG) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
		}
		return !flag;
	}

	protected void ILNJMLDKNLE(float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		PFGLIAHPMCK = new UpgradeSlots.UnitUpgrades(1678f);
		cardProgress = PAENPHMEMGC;
		cardId = ICDKHLOBKIE;
		spawnedByCard = false;
		UnityEngine.Debug.Log(string.Format("special", cardProgress, base.gameObject.name, PFGLIAHPMCK));
	}

	protected virtual void INDACALKMFI()
	{
		if (AHGNBGPMJFO != null)
		{
			AHGNBGPMJFO(this);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		DHBMIGAMNDK = GetComponentsInChildren<AimTarget>();
	}

	public virtual void EnableSpawn()
	{
		DIPLDDHLMME = true;
	}

	[SpecialName]
	public virtual void AIDHEEBHIPO(GHPGNELIDBM IDEBKDPMPGM)
	{
		if (ODCLPMADGFC != IDEBKDPMPGM)
		{
			ODCLPMADGFC = IDEBKDPMPGM;
		}
	}

	public void PickUpgrades()
	{
		PFGLIAHPMCK = Singleton<GameController>.instance.mainController.PickUpgradesForUnit(LCDBACDIODH, this);
		if (!LCDBACDIODH)
		{
			HENLAGGDLNL();
		}
		UpgradesLoaded();
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		if (LCDBACDIODH)
		{
			PickUpgrades();
			return;
		}
		if (ACLDFHJKBLI != null)
		{
			ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef;
		}
		if (LAADDLGBFIG != null && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			PickUpgrades();
		}
		if (LAADDLGBFIG == null || Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Spawn();
		}
	}

	public virtual Type GetBehaviourType()
	{
		return typeof(LevelBehaviour);
	}

	public void Prepare(LevelBehaviour ACLDFHJKBLI)
	{
		BIMAIJLKENC = true;
		IAJJBAJOGDM = ACLDFHJKBLI;
		if (IAJJBAJOGDM != null)
		{
			IAJJBAJOGDM.Copy(this);
			this.ACLDFHJKBLI.Init(this);
		}
	}

	public void SpawnByCard(float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		PFGLIAHPMCK = new UpgradeSlots.UnitUpgrades(1f);
		cardProgress = PAENPHMEMGC;
		cardId = ICDKHLOBKIE;
		spawnedByCard = true;
		LAADDLGBFIG.RPC("SpawnByCardRPC", PhotonTargets.Others, PAENPHMEMGC, ICDKHLOBKIE);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		LCDBACDIODH = false;
		spawnedByCard = false;
	}

	[SpecialName]
	protected void MDCBDOEKCFE(float IDEBKDPMPGM)
	{
		_003CCPAAPMCEIOL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void Spawn()
	{
	}

	[SpecialName]
	public virtual void KJJCKCNMJFK(int IDEBKDPMPGM)
	{
		if (LAADDLGBFIG != null && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			IAICPGNGCJI = IDEBKDPMPGM;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[0];
			array[1] = (byte)IDEBKDPMPGM;
			lAADDLGBFIG.RPC("fuseLogin", PhotonTargets.All, array);
		}
	}

	public virtual void HMMMOADPNIK()
	{
		if (PLPBGNOCCPI())
		{
			DestroyPooled();
		}
	}

	public virtual void ReSync()
	{
		if (base.isAlive && base.isInstantiated)
		{
			float mNAJKODCACI = ((!(destroyableObj != null)) ? 0f : destroyableObj.health);
			LAADDLGBFIG.RPC("ReSyncRPC", PhotonTargets.Others, (byte)fraction, base.transform.position, base.transform.rotation, PFGLIAHPMCK, spawnedByCard, cardProgress, cardId);
			ACLDFHJKBLI.ReSync();
			if (destroyableObj != null && !destroyableObj.isDead)
			{
				destroyableObj.RefillTo(mNAJKODCACI);
			}
		}
		else
		{
			LAADDLGBFIG.RPC("ReSyncDisabledRPC", PhotonTargets.Others);
		}
	}

	protected void HENLAGGDLNL()
	{
		LAADDLGBFIG.RPC("SyncUpgradesRPC", PhotonTargets.Others, (byte)fraction, PFGLIAHPMCK);
	}

	public bool IsPrepared()
	{
		return BIMAIJLKENC;
	}

	protected virtual void ODDDGIALOPM(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF: false);
		}
	}

	public virtual void UpdatePreview(bool OPGMAEDPFML)
	{
		PickUpgrades();
		if (destroyableObj.GPLNJOPPKIM != null)
		{
			destroyableObj.GPLNJOPPKIM.Disable();
		}
	}

	public virtual void StartEnemyBehaviour()
	{
		INDACALKMFI();
		if (LAADDLGBFIG != null && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			LAADDLGBFIG.RPC("StartEnemyBehaviourNetwork", PhotonTargets.Others, (byte)fraction);
		}
	}

	protected virtual void DPFHODDILIF(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		if (base.isAlive)
		{
			if (FJHBCIAKBPF != null)
			{
				FJHBCIAKBPF(this, LLAOOPMGBAG);
			}
			if (JGGMGHNEJCJ != null)
			{
				JGGMGHNEJCJ(this, LLAOOPMGBAG);
			}
			base.isAlive = false;
		}
	}

	public virtual void GetAudioSources(List<AudioSource> FJGIGBNDCFE)
	{
	}

	[PunRPC]
	protected void SetPower(byte APLODBKLDEG)
	{
		IAICPGNGCJI = APLODBKLDEG;
	}

	[SpecialName]
	public static void HGNDFDFGIGG(Action<AIObject, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<AIObject, DestroyableObject.CJLNCMMNPBM> action = JGGMGHNEJCJ;
		Action<AIObject, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JGGMGHNEJCJ, (Action<AIObject, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[PunRPC]
	protected void StartEnemyBehaviourNetwork(byte JNMJLBOECLB)
	{
		fraction = (GHPGNELIDBM)JNMJLBOECLB;
		INDACALKMFI();
	}
}
