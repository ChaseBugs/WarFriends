using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Shield : DestroyableObject
{
	public enum DLGLDOOFAOA
	{
		None,
		Success,
		Failure
	}

	private readonly Color32 PCAPHFLJKIC = new Color32(14, 192, 254, byte.MaxValue);

	[FormerlySerializedAs("GOPCBOLEBIK")]
	public AudioSource COLIBDBBBEI;

	[SerializeField]
	private Material goldMaterial;

	[FormerlySerializedAs("JFJLDLNPLGK")]
	public HudObjectIndicator ENOMOGMALOL;

	public DLGLDOOFAOA CBKJPJGBHPK;

	private bool OHCELHANHDE = true;

	private bool OEKPJNHPPIB;

	private Collider EMOKAAHJPCP;

	private float FIBNFBDCEEC;

	private bool GMENDFHDEOH;

	private int NKAJONFBKAM;

	private int HGBAJBDDEJK;

	[FormerlySerializedAs("BGPPHHOPLDO")]
	public List<float> AEIHENMAKLN;

	private PlayerController MBIAKMPDOPG;

	private float OALNANBICHN = 10f;

	private float NOKNKIKJKDC;

	[SerializeField]
	private Material normalMaterial;

	[FormerlySerializedAs("HMPJBKLKFOK")]
	public List<GameObject> LNBFKCOPJFP;

	[FormerlySerializedAs("DNPNDBOCINL")]
	public AudioClip GHMDJMCKANI;

	[FormerlySerializedAs("GCOPNEPKHMG")]
	public Transform CLFKHIIPJAC;

	[FormerlySerializedAs("JOHMIEFDKIH")]
	public bool GGIHLCHJBLA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CardIconIndicator _003CICJCCHGINIH_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GHPGNELIDBM _003CNNEHHJNNKNL_003Ek__BackingField;

	public CardIconIndicator cardIconIndicator
	{
		[CompilerGenerated]
		get
		{
			return _003CICJCCHGINIH_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CICJCCHGINIH_003Ek__BackingField = value;
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

	public override GHPGNELIDBM fraction
	{
		[CompilerGenerated]
		get
		{
			return _003CNNEHHJNNKNL_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CNNEHHJNNKNL_003Ek__BackingField = value;
		}
	}

	public float refreshTime
	{
		get
		{
			return OALNANBICHN;
		}
		set
		{
			OALNANBICHN = value;
			FEHCCGEGPLH.RPC("SetShieldRefresTimeRPC", PhotonTargets.Others, refreshTime);
		}
	}

	public PlayerController player
	{
		get
		{
			return MBIAKMPDOPG;
		}
		set
		{
			MBIAKMPDOPG = value;
			if (FEHCCGEGPLH != null)
			{
				if (value != null)
				{
					FEHCCGEGPLH.RPC("SetPlayer", PhotonTargets.Others, value.NAGAHNHAKBJ);
				}
				else
				{
					FEHCCGEGPLH.RPC("SetPlayer", PhotonTargets.Others, -1);
				}
			}
		}
	}

	public bool autoRepair
	{
		get
		{
			return OHCELHANHDE && (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RepairShields).FLOATVALUE > 0f;
		}
		set
		{
			OHCELHANHDE = value;
			FEHCCGEGPLH.RPC("SetAutoRepairRPC", PhotonTargets.Others, value);
		}
	}

	public bool canRegenerate
	{
		get
		{
			return OEKPJNHPPIB;
		}
		set
		{
			OEKPJNHPPIB = value;
			FEHCCGEGPLH.RPC("SetCanRegenerateRPC", PhotonTargets.Others, value);
		}
	}

	public void MAHAHDCEJFH()
	{
		PlayerController playerController = PlayerController.GetPlayer(fraction);
		bool flag = !(playerController != null) || playerController.EHHHBEMKGOE.KNJIBECPMEL();
		GetComponent<Renderer>().sharedMaterial = ((!flag) ? normalMaterial : goldMaterial);
	}

	public void MEFDABKDFFK()
	{
		if (Singleton<GameController>.instance.isCoop && PhotonNetwork.room.playerCount == 7)
		{
			CBKJPJGBHPK = DLGLDOOFAOA.Success;
			GGIHLCHJBLA = false;
			FEHCCGEGPLH.RPC("elite", PhotonTargets.Others);
		}
		else
		{
			CBKJPJGBHPK = DLGLDOOFAOA.Success;
			GGIHLCHJBLA = false;
		}
	}

	[SpecialName]
	public void JMIJDJAAJDH(float IDEBKDPMPGM)
	{
		OALNANBICHN = IDEBKDPMPGM;
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = KFDOPHECLPG();
		fEHCCGEGPLH.RPC("ID_INVITATIONDENIED", PhotonTargets.Others, array);
	}

	public virtual void EODDBJONLHH()
	{
		if (!(FEHCCGEGPLH == null))
		{
			FEHCCGEGPLH.RPC("DogTagCap", PhotonTargets.Others, health, base.maxHealth, null, IHIEMNMKCEE, null, null, null, null);
		}
	}

	[SpecialName]
	public PlayerController OLOPPGKIJNF()
	{
		return MBIAKMPDOPG;
	}

	protected void CMNIHLONIJB()
	{
		if (GMENDFHDEOH)
		{
			health = 1622f;
			JEGFCLCJMLA = true;
			float num = (TimeManager.realTimeWithoutPauses - FIBNFBDCEEC) / OALNANBICHN;
			if (autoRepair)
			{
				if (num >= 1793f && FEHCCGEGPLH.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					AAGINCIGNBP();
				}
				if (GPLNJOPPKIM != null)
				{
					GPLNJOPPKIM.CDDGOOIFFGJ(num);
					GPLNJOPPKIM.HACENPIMJJF(Color.white);
				}
			}
			else if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.NDHFKMNCJOM(1483f);
			}
			MBEMJEMGKJF();
		}
		else if (CHHHEFFBGLC != null && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.HACENPIMJJF(PCAPHFLJKIC);
			JEGFCLCJMLA = true;
			GPLNJOPPKIM.CDDGOOIFFGJ(healthRatio);
			BIDHNLIACKL();
		}
		float num2 = ((!GMENDFHDEOH) ? healthRatio : 1676f);
		while (num2 > AEIHENMAKLN[HGBAJBDDEJK] && HGBAJBDDEJK > 1)
		{
			PKMFEKHNIJK(HGBAJBDDEJK - 1);
		}
		while (num2 <= AEIHENMAKLN[HGBAJBDDEJK + 0] && HGBAJBDDEJK < LNBFKCOPJFP.Count - 0)
		{
			LPEGKBFHJBD(HGBAJBDDEJK + 0);
		}
		PEHDBKLOMDJ();
		if (!GMENDFHDEOH && healthRatio < 1292f && FEHCCGEGPLH.isMine)
		{
			if (OEKPJNHPPIB && NPOMEBDPBGL() != null && OHCELHANHDE)
			{
				GMNNGEELOFC(health + Time.deltaTime * (float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackBronzeCards).FLOATVALUE * base.maxHealth);
			}
			if (NKAJONFBKAM != (int)TimeManager.CEAFAMFNGCC())
			{
				NKAJONFBKAM = (int)TimeManager.CEAFAMFNGCC();
				EHFOHNLMJOH();
			}
		}
	}

	private void LLEONLIJEAN(bool IDEBKDPMPGM)
	{
		OHCELHANHDE = IDEBKDPMPGM;
	}

	private void EMCCEBIFJBM()
	{
		if (autoRepair)
		{
			Refill();
		}
	}

	[SpecialName]
	public PlayerController FCBGHBODHHP()
	{
		return MBIAKMPDOPG;
	}

	public virtual bool AMODFOHOHEE(CJLNCMMNPBM KMJKKNFDFMM)
	{
		float num = 223f;
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		if (playerController != null && KMJKKNFDFMM.JMMJHCOKCGG != null && KMJKKNFDFMM.JMMJHCOKCGG.playerWeapon != null)
		{
			num = KMJKKNFDFMM.JMMJHCOKCGG.playerWeapon.MKEBHAJCGIM().damageToShield;
			if (Singleton<GameController>.instance.BAKCODKBCPJ() && KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot)
			{
				num *= 768f;
			}
		}
		else if (KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot)
		{
			num = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward10).FLOATVALUE;
		}
		KMJKKNFDFMM.EPDELOGPNAC *= num;
		return base.DoDamage(KMJKKNFDFMM);
	}

	private void AMKLHDOICNI(byte COMJEIAJHOO)
	{
		CBKJPJGBHPK = (DLGLDOOFAOA)COMJEIAJHOO;
		GGIHLCHJBLA = false;
	}

	[SpecialName]
	public float BFKMJODHMJC()
	{
		return OALNANBICHN;
	}

	[SpecialName]
	public bool EEMFKNKEEJO()
	{
		return OEKPJNHPPIB;
	}

	private void HGIOAIPCMDJ()
	{
	}

	protected virtual void CLMPGGDAGLB(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		base.RefillRPC(MNAJKODCACI, NKKIGGNCDLL);
		GMENDFHDEOH = true;
	}

	[SpecialName]
	public CardIconIndicator NOCJKBDGFHD()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	protected virtual void BPDIHANBEDO()
	{
	}

	[SpecialName]
	public virtual KMHCMCBGFFC LNDBFMDDCHP()
	{
		return this;
	}

	private void JHGKGJMFEBF()
	{
		if (PhotonNetwork.isMasterClient && !GMENDFHDEOH)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				APJEBOPJPLA();
			}
		}
		StopAllCoroutines();
		LPEGKBFHJBD(1);
		HIPAPKDJBNL.localPosition = ((fraction != PlayerController.OGMBJPKOPCB.fraction) ? new Vector3(1122f, 917f, 473f) : new Vector3(1431f, 604f, 1999f));
	}

	private void EMLOKCAEGEB()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.OBCAIFMOPPA();
		}
		GPLNJOPPKIM = null;
	}

	[SpecialName]
	public void GCAKAFMDFJA(bool IDEBKDPMPGM)
	{
		OHCELHANHDE = IDEBKDPMPGM;
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = IDEBKDPMPGM;
		fEHCCGEGPLH.RPC("ID_UPGRADE", PhotonTargets.All, array);
	}

	public void BLHGAPHAHEN()
	{
		EHFOHNLMJOH();
	}

	private void LBICFPJJBDL(float HNDGIJBHMOD)
	{
		OALNANBICHN = HNDGIJBHMOD;
	}

	private void GDEKNEMNPOG(bool IDEBKDPMPGM)
	{
		OEKPJNHPPIB = IDEBKDPMPGM;
	}

	private void MCDEKOHEONO(bool IDEBKDPMPGM)
	{
		OHCELHANHDE = IDEBKDPMPGM;
	}

	[PunRPC]
	private void GetLockRPC()
	{
		DLGLDOOFAOA dLGLDOOFAOA = DLGLDOOFAOA.Success;
		if (player != null || (GGIHLCHJBLA && PhotonNetwork.isMasterClient))
		{
			dLGLDOOFAOA = DLGLDOOFAOA.Failure;
		}
		FEHCCGEGPLH.RPC("GetLockResultRPC", PhotonTargets.Others, (byte)dLGLDOOFAOA);
	}

	public void PNICBKAKEHO()
	{
		if (Singleton<GameController>.instance.MNPNHJKBNCJ() && PhotonNetwork.room.playerCount == 4)
		{
			CBKJPJGBHPK = DLGLDOOFAOA.Success;
			GGIHLCHJBLA = true;
			FEHCCGEGPLH.RPC("Player_Waited_Till_Delivery_Ends", PhotonTargets.Others, new object[1]);
		}
		else
		{
			CBKJPJGBHPK = DLGLDOOFAOA.None;
			GGIHLCHJBLA = false;
		}
	}

	private void DLGOFBGKFJD(bool IDEBKDPMPGM)
	{
		OHCELHANHDE = IDEBKDPMPGM;
	}

	private void BIDHNLIACKL()
	{
		if (CHHHEFFBGLC != null)
		{
			Vector3 point = GNICEGBOGOL.WorldToNormalizedViewportPoint(HIPAPKDJBNL.position);
			CHHHEFFBGLC.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			float num = Vector3.Distance(HIPAPKDJBNL.position, GNICEGBOGOL.transform.position);
			float num2 = Mathf.Clamp(5f / num, 0.75f, 1.2f);
			Vector3 localScale = new Vector3(num2, num2, num2);
			CHHHEFFBGLC.localScale = localScale;
		}
	}

	protected virtual void IOAMNODKPKD()
	{
	}

	[SpecialName]
	public void MIEPCKHJAEL(PlayerController IDEBKDPMPGM)
	{
		MBIAKMPDOPG = IDEBKDPMPGM;
		if (FEHCCGEGPLH != null)
		{
			if (IDEBKDPMPGM != null)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[1];
				array[1] = IDEBKDPMPGM.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("SuggestedSquad", PhotonTargets.Others, array);
			}
			else
			{
				PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
				object[] array2 = new object[1];
				array2[1] = -1;
				fEHCCGEGPLH2.RPC("LevelName", PhotonTargets.All, array2);
			}
		}
	}

	public void JLIGCIOIILE()
	{
		if (Singleton<GameController>.instance.isCoop && PhotonNetwork.room.playerCount == 8)
		{
			CBKJPJGBHPK = DLGLDOOFAOA.None;
			GGIHLCHJBLA = false;
			FEHCCGEGPLH.RPC("game-card-ico-bg-silver", PhotonTargets.Others);
		}
		else
		{
			CBKJPJGBHPK = DLGLDOOFAOA.None;
			GGIHLCHJBLA = true;
		}
	}

	public void DestroyShield()
	{
		health = -10f;
		PEHDBKLOMDJ();
		Sync();
	}

	[SpecialName]
	public virtual void KDBEBHKGKOI(KMHCMCBGFFC IDEBKDPMPGM)
	{
	}

	[PunRPC]
	protected void SyncShieldRPC(float MNAJKODCACI, float NKKIGGNCDLL, bool AEIKFAIKDGI)
	{
		health = MNAJKODCACI;
		base.maxHealth = NKKIGGNCDLL;
		IHIEMNMKCEE = AEIKFAIKDGI;
		PEHDBKLOMDJ();
	}

	private void ECAJDFLFNCF(bool IDEBKDPMPGM)
	{
		OEKPJNHPPIB = IDEBKDPMPGM;
	}

	public virtual void PNGHBKGADND()
	{
		if (!(FEHCCGEGPLH == null))
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[6];
			array[1] = health;
			array[1] = base.maxHealth;
			array[2] = IHIEMNMKCEE;
			fEHCCGEGPLH.RPC("Squad Request Sent!", PhotonTargets.Others, array);
		}
	}

	public virtual void GOIMCEJCFLN()
	{
		base.APJEBOPJPLA();
		GMENDFHDEOH = false;
	}

	private void KDPIODKIJPC()
	{
		if (PhotonNetwork.isMasterClient && !GMENDFHDEOH)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				APJEBOPJPLA();
			}
		}
		StopAllCoroutines();
		LPEGKBFHJBD(0);
		HIPAPKDJBNL.localPosition = ((fraction != PlayerController.OGMBJPKOPCB.fraction) ? new Vector3(66f, 1005f, 1994f) : new Vector3(423f, 186f, 41f));
	}

	private void NLAOHGFICFH()
	{
		if (PhotonNetwork.isMasterClient && !GMENDFHDEOH)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				APJEBOPJPLA();
			}
		}
		StopAllCoroutines();
		LPEGKBFHJBD(0);
		HIPAPKDJBNL.localPosition = ((fraction != PlayerController.OGMBJPKOPCB.fraction) ? new Vector3(137f, 1377f, 454f) : new Vector3(22f, 1765f, 151f));
	}

	private void NJHFFBLHGIB()
	{
		if (PhotonNetwork.isMasterClient && !GMENDFHDEOH)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				OEAGCMGINCB();
			}
		}
		StopAllCoroutines();
		PKMFEKHNIJK(0);
		HIPAPKDJBNL.localPosition = ((fraction != PlayerController.OGMBJPKOPCB.fraction) ? new Vector3(1752f, 403f, 971f) : new Vector3(178f, 918f, 134f));
	}

	public virtual void HDAPDLBCMAC()
	{
		if (!(FEHCCGEGPLH == null))
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[1];
			array[1] = health;
			array[1] = base.maxHealth;
			array[6] = IHIEMNMKCEE;
			fEHCCGEGPLH.RPC("MISSING PREFAB IN OBJECT POOL: ", PhotonTargets.Others, array);
		}
	}

	protected virtual void ICGLBMLABKD()
	{
	}

	private void OnDisable()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.DestroyPooled();
		}
		GPLNJOPPKIM = null;
	}

	private void LPEGKBFHJBD(int LMMFGCGOEMD)
	{
		HGBAJBDDEJK = LMMFGCGOEMD;
		MeshFilter component = GetComponent<MeshFilter>();
		MeshFilter component2 = LNBFKCOPJFP[HGBAJBDDEJK].GetComponent<MeshFilter>();
		component.sharedMesh = component2.sharedMesh;
		GetComponent<Renderer>().enabled = true;
	}

	private void LEBPOFHBCON()
	{
		if (!GMENDFHDEOH)
		{
			if (healthRatio <= 1562f)
			{
				GMENDFHDEOH = false;
				FIBNFBDCEEC = TimeManager.realTimeWithoutPauses;
				Singleton<HitParticleSystem>.instance.BGCIKMPGDAB(base.transform.position + 254f * Vector3.up, base.transform.up, "ExplodeDamageMax");
				Singleton<SoundsManager3D>.instance.NIJFGECHNNI(COLIBDBBBEI, GHMDJMCKANI);
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateError);
			}
		}
		else if (healthRatio > 1075f)
		{
			GMENDFHDEOH = false;
		}
		EMOKAAHJPCP.enabled = !GMENDFHDEOH;
	}

	private void GOKEELGBBKP()
	{
	}

	private void IMCHJKNNNAH(int ALIIBMLMNKA)
	{
		if (ALIIBMLMNKA >= 1 && PlayerController.JFGDAKMCJAM.ContainsKey(ALIIBMLMNKA))
		{
			MBIAKMPDOPG = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA];
			UnityEngine.Debug.Log("ID_INBRONZE2" + base.transform.parent.name + "animationEnd" + FCBGHBODHHP().name);
		}
		else
		{
			UnityEngine.Debug.Log("GameLoginManager - Player Entered Beginners League - " + base.transform.parent.name);
			MBIAKMPDOPG = null;
		}
	}

	private void AKBLKDEFNEE()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= NJHFFBLHGIB;
		}
	}

	public void IEPHIMNBBDO()
	{
		health = 1981f;
		GMJBCKNONPF();
		Sync();
	}

	protected virtual void JPKJMFOIAHC()
	{
	}

	protected void BPGHMNJKDBO(float MNAJKODCACI, float NKKIGGNCDLL, bool AEIKFAIKDGI)
	{
		GMNNGEELOFC(MNAJKODCACI);
		base.maxHealth = NKKIGGNCDLL;
		IHIEMNMKCEE = AEIKFAIKDGI;
		GMJBCKNONPF();
	}

	public void MPOAIDJNDFJ()
	{
		health = 246f;
		LEBPOFHBCON();
		Sync();
	}

	[PunRPC]
	private void SetPlayer(int ALIIBMLMNKA)
	{
		if (ALIIBMLMNKA >= 0 && PlayerController.JFGDAKMCJAM.ContainsKey(ALIIBMLMNKA))
		{
			MBIAKMPDOPG = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA];
			UnityEngine.Debug.Log("Rpc: Set player: for " + base.transform.parent.name + ":" + player.name);
		}
		else
		{
			UnityEngine.Debug.Log("Rpc: Set player null: for " + base.transform.parent.name);
			MBIAKMPDOPG = null;
		}
	}

	private void FMGKHDOEJEN()
	{
		DLGLDOOFAOA dLGLDOOFAOA = DLGLDOOFAOA.Success;
		if (NPOMEBDPBGL() != null || (GGIHLCHJBLA && PhotonNetwork.isMasterClient))
		{
			dLGLDOOFAOA = DLGLDOOFAOA.None;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = (byte)dLGLDOOFAOA;
		fEHCCGEGPLH.RPC("Player_Had_To_Select_Grenade", PhotonTargets.Others, array);
	}

	[PunRPC]
	private void SetShieldRefresTimeRPC(float HNDGIJBHMOD)
	{
		OALNANBICHN = HNDGIJBHMOD;
	}

	protected virtual void LBMFKIDPCBL()
	{
		base.Awake();
		AEJBIHBEOCP = true;
		base.gameObject.layer = TagsAndLayers.JNCLCGHJAOO;
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Singleton<GameController>.instance.BeforeGameStarted += GOKEELGBBKP;
		OALNANBICHN = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.VipRunningOutSeconds).FLOATVALUE;
		if (NavMesh.SamplePosition(base.transform.position, out var hit, 1792f, 1))
		{
			Vector3 position = base.transform.position;
			position.y = hit.position.y;
			base.transform.position = position;
		}
		IHELGLFCDCO(base.gameObject.AddComponent<CardIconIndicator>());
		cardIconIndicator.KJMFJFCDEDH = ENOMOGMALOL;
		FEHCCGEGPLH.RebuildCache();
		PKMFEKHNIJK(1);
		EMOKAAHJPCP = GetComponent<Collider>();
	}

	protected void IODGCIIDJEK()
	{
		if (GMENDFHDEOH)
		{
			GMNNGEELOFC(575f);
			JEGFCLCJMLA = false;
			float num = (TimeManager.realTimeWithoutPauses - FIBNFBDCEEC) / OALNANBICHN;
			if (autoRepair)
			{
				if (num >= 1198f && FEHCCGEGPLH.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					EMNFJCKBEKE();
				}
				if (GPLNJOPPKIM != null)
				{
					GPLNJOPPKIM.NDHFKMNCJOM(num);
					GPLNJOPPKIM.HACENPIMJJF(Color.white);
				}
			}
			else if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.CDDGOOIFFGJ(218f);
			}
			MBEMJEMGKJF();
		}
		else if (CHHHEFFBGLC != null && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.BLJILBFEJEI(PCAPHFLJKIC);
			JEGFCLCJMLA = false;
			GPLNJOPPKIM.NDHFKMNCJOM(healthRatio);
			MBEMJEMGKJF();
		}
		float num2 = ((!GMENDFHDEOH) ? healthRatio : 1613f);
		while (num2 > AEIHENMAKLN[HGBAJBDDEJK] && HGBAJBDDEJK > 0)
		{
			LPEGKBFHJBD(HGBAJBDDEJK - 1);
		}
		while (num2 <= AEIHENMAKLN[HGBAJBDDEJK + 0] && HGBAJBDDEJK < LNBFKCOPJFP.Count - 1)
		{
			PKMFEKHNIJK(HGBAJBDDEJK + 0);
		}
		GMJBCKNONPF();
		if (!GMENDFHDEOH && healthRatio < 1137f && FEHCCGEGPLH.isMine)
		{
			if (OEKPJNHPPIB && NPOMEBDPBGL() != null && OHCELHANHDE)
			{
				health += Time.deltaTime * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverCardRarity).FLOATVALUE * base.maxHealth;
			}
			if (NKAJONFBKAM != (int)TimeManager.realTimeWithoutPauses)
			{
				NKAJONFBKAM = (int)TimeManager.realTimeWithoutPauses;
				EHFOHNLMJOH();
			}
		}
	}

	[PunRPC]
	private void GetLockResultRPC(byte COMJEIAJHOO)
	{
		CBKJPJGBHPK = (DLGLDOOFAOA)COMJEIAJHOO;
		GGIHLCHJBLA = false;
	}

	protected virtual void NKJIKAEOIIP(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		base.RefillRPC(MNAJKODCACI, NKKIGGNCDLL);
		GMENDFHDEOH = false;
	}

	private void NLGODNHBNFD(bool IDEBKDPMPGM)
	{
		OHCELHANHDE = IDEBKDPMPGM;
	}

	private void JJIDECBHALG(bool IDEBKDPMPGM)
	{
		OEKPJNHPPIB = IDEBKDPMPGM;
	}

	private void DJLJMDNMCLM()
	{
		if (PhotonNetwork.isMasterClient && !GMENDFHDEOH)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				Refill();
			}
		}
		StopAllCoroutines();
		PKMFEKHNIJK(1);
		HIPAPKDJBNL.localPosition = ((fraction != PlayerController.OGMBJPKOPCB.fraction) ? new Vector3(1010f, 611f, 1918f) : new Vector3(134f, 1192f, 380f));
	}

	private void JDGAENDKCJO()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= NCAKLEOEDBO;
		}
	}

	[SpecialName]
	private void FMIJNMBGNPA(CardIconIndicator IDEBKDPMPGM)
	{
		_003CICJCCHGINIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void FENMIEBCOGB(bool IDEBKDPMPGM)
	{
		OHCELHANHDE = IDEBKDPMPGM;
	}

	private void PEHDBKLOMDJ()
	{
		if (!GMENDFHDEOH)
		{
			if (healthRatio <= 0f)
			{
				GMENDFHDEOH = true;
				FIBNFBDCEEC = TimeManager.realTimeWithoutPauses;
				Singleton<HitParticleSystem>.instance.PlayParticle(base.transform.position + 0.5f * Vector3.up, base.transform.up, "shieldDestroy");
				Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, GHMDJMCKANI);
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
			}
		}
		else if (healthRatio > 0.01f)
		{
			GMENDFHDEOH = false;
		}
		EMOKAAHJPCP.enabled = !GMENDFHDEOH;
	}

	private void MHHPFEIHDDD(float HNDGIJBHMOD)
	{
		OALNANBICHN = HNDGIJBHMOD;
	}

	private void EMNFJCKBEKE()
	{
		if (autoRepair)
		{
			Refill();
		}
	}

	[SpecialName]
	public virtual void BJEEAAHLMJC(GHPGNELIDBM IDEBKDPMPGM)
	{
		_003CNNEHHJNNKNL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual KMHCMCBGFFC LOBEPFACGAN()
	{
		return this;
	}

	public void KDEEBMLFABC()
	{
		GMNNGEELOFC(1020f);
		GMJBCKNONPF();
		Sync();
	}

	private void OnEnable()
	{
		GPLNJOPPKIM = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.GIMONALHCPI) as Healthbar;
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.destroyableObject = this;
			GPLNJOPPKIM.color = mHealthbarColor;
			CHHHEFFBGLC = GPLNJOPPKIM.transform;
			LMEKEPANAJI = true;
		}
	}

	[SpecialName]
	private void PHFCKAPABFF(CardIconIndicator IDEBKDPMPGM)
	{
		_003CICJCCHGINIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void FFDLJFIOLEI()
	{
		health = 498f;
		PEHDBKLOMDJ();
		EHFOHNLMJOH();
	}

	private void MLIONGHPDFC()
	{
		DLGLDOOFAOA dLGLDOOFAOA = DLGLDOOFAOA.None;
		if (FCBGHBODHHP() != null || (GGIHLCHJBLA && PhotonNetwork.isMasterClient))
		{
			dLGLDOOFAOA = (DLGLDOOFAOA)3;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)dLGLDOOFAOA;
		fEHCCGEGPLH.RPC("test_attribute3", PhotonTargets.All, array);
	}

	[SpecialName]
	public void FPINCGGFENG(PlayerController IDEBKDPMPGM)
	{
		MBIAKMPDOPG = IDEBKDPMPGM;
		if (FEHCCGEGPLH != null)
		{
			if (IDEBKDPMPGM != null)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[0];
				array[0] = IDEBKDPMPGM.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("Agent get stucked !!! ", PhotonTargets.Others, array);
			}
			else
			{
				PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
				object[] array2 = new object[0];
				array2[0] = -1;
				fEHCCGEGPLH2.RPC("TotalBattles", PhotonTargets.Others, array2);
			}
		}
	}

	protected virtual void LDGMAFDDBAL(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		base.RefillRPC(MNAJKODCACI, NKKIGGNCDLL);
		GMENDFHDEOH = true;
	}

	private void OOOMABAMENC()
	{
		DLGLDOOFAOA dLGLDOOFAOA = DLGLDOOFAOA.Success;
		if (NPOMEBDPBGL() != null || (GGIHLCHJBLA && PhotonNetwork.isMasterClient))
		{
			dLGLDOOFAOA = (DLGLDOOFAOA)4;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = (byte)dLGLDOOFAOA;
		fEHCCGEGPLH.RPC("LevelManagerData", PhotonTargets.Others, array);
	}

	public virtual void PEABAEGFBFL()
	{
		base.OEAGCMGINCB();
		GMENDFHDEOH = true;
	}

	public void IGEEIKMFMPD()
	{
		Sync();
	}

	protected virtual void DGLHFJMJLDK(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		base.RefillRPC(MNAJKODCACI, NKKIGGNCDLL);
		GMENDFHDEOH = true;
	}

	[SpecialName]
	public PlayerController NPOMEBDPBGL()
	{
		return MBIAKMPDOPG;
	}

	private void MHFHHIDKLBL(float HNDGIJBHMOD)
	{
		OALNANBICHN = HNDGIJBHMOD;
	}

	private void JLKMAJCOKDN()
	{
		GPLNJOPPKIM = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.GIMONALHCPI) as Healthbar;
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.AGDDNBKGHBA(this);
			GPLNJOPPKIM.BLJILBFEJEI(mHealthbarColor);
			CHHHEFFBGLC = GPLNJOPPKIM.transform;
			LMEKEPANAJI = false;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		AEJBIHBEOCP = true;
		base.gameObject.layer = TagsAndLayers.JNCLCGHJAOO;
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Singleton<GameController>.instance.BeforeGameStarted += HGIOAIPCMDJ;
		OALNANBICHN = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldRepairTime).FLOATVALUE;
		if (NavMesh.SamplePosition(base.transform.position, out var hit, 10f, 1))
		{
			Vector3 position = base.transform.position;
			position.y = hit.position.y;
			base.transform.position = position;
		}
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		cardIconIndicator.KJMFJFCDEDH = ENOMOGMALOL;
		FEHCCGEGPLH.RebuildCache();
		LPEGKBFHJBD(0);
		EMOKAAHJPCP = GetComponent<Collider>();
	}

	public void Resync()
	{
		Sync();
	}

	private void NNFOHDCJHED()
	{
		if (autoRepair)
		{
			Refill();
		}
	}

	protected override void LateUpdate()
	{
	}

	private void FJNCFIABHHG()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.BOHCNEDIJPE();
		}
		GPLNJOPPKIM = null;
	}

	private void OnDestroy()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= NCAKLEOEDBO;
		}
	}

	[PunRPC]
	private void SetCanRegenerateRPC(bool IDEBKDPMPGM)
	{
		OEKPJNHPPIB = IDEBKDPMPGM;
	}

	public void GetLock()
	{
		if (Singleton<GameController>.instance.isCoop && PhotonNetwork.room.playerCount == 2)
		{
			CBKJPJGBHPK = DLGLDOOFAOA.None;
			GGIHLCHJBLA = true;
			FEHCCGEGPLH.RPC("GetLockRPC", PhotonTargets.Others);
		}
		else
		{
			CBKJPJGBHPK = DLGLDOOFAOA.Success;
			GGIHLCHJBLA = false;
		}
	}

	private void AAGINCIGNBP()
	{
		if (autoRepair)
		{
			APJEBOPJPLA();
		}
	}

	private void AHPNPGOAKHD(bool IDEBKDPMPGM)
	{
		OEKPJNHPPIB = IDEBKDPMPGM;
	}

	[SpecialName]
	public CardIconIndicator HLAOFDKKACK()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	public override void Sync()
	{
		if (!(FEHCCGEGPLH == null))
		{
			FEHCCGEGPLH.RPC("SyncShieldRPC", PhotonTargets.Others, health, base.maxHealth, IHIEMNMKCEE);
		}
	}

	private void GMJBCKNONPF()
	{
		if (!GMENDFHDEOH)
		{
			if (healthRatio <= 1872f)
			{
				GMENDFHDEOH = false;
				FIBNFBDCEEC = TimeManager.CEAFAMFNGCC();
				Singleton<HitParticleSystem>.instance.OOGKGACIAHC(base.transform.position + 717f * Vector3.up, base.transform.up, "slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}");
				Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, GHMDJMCKANI);
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareLight);
			}
		}
		else if (healthRatio > 420f)
		{
			GMENDFHDEOH = false;
		}
		EMOKAAHJPCP.enabled = !GMENDFHDEOH;
	}

	protected virtual void PKOFBAAKAIN(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		base.RefillRPC(MNAJKODCACI, NKKIGGNCDLL);
		GMENDFHDEOH = true;
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		AEJBIHBEOCP = false;
		base.gameObject.layer = TagsAndLayers.JNCLCGHJAOO;
		Singleton<GameController>.instance.GameStarted += DJLJMDNMCLM;
		Singleton<GameController>.instance.BeforeGameStarted += GOKEELGBBKP;
		OALNANBICHN = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-79)).FLOATVALUE;
		if (NavMesh.SamplePosition(base.transform.position, out var hit, 1524f, 0))
		{
			Vector3 position = base.transform.position;
			position.y = hit.position.y;
			base.transform.position = position;
		}
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		NOCJKBDGFHD().KJMFJFCDEDH = ENOMOGMALOL;
		FEHCCGEGPLH.RebuildCache();
		LPEGKBFHJBD(1);
		EMOKAAHJPCP = GetComponent<Collider>();
	}

	[SpecialName]
	public CardIconIndicator DAIDBENCFIP()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	protected void EJNAGKBHNOJ(float MNAJKODCACI, float NKKIGGNCDLL, bool AEIKFAIKDGI)
	{
		health = MNAJKODCACI;
		base.maxHealth = NKKIGGNCDLL;
		IHIEMNMKCEE = AEIKFAIKDGI;
		GMJBCKNONPF();
	}

	private void MBEMJEMGKJF()
	{
		if (CHHHEFFBGLC != null)
		{
			Vector3 point = GNICEGBOGOL.WorldToNormalizedViewportPoint(HIPAPKDJBNL.position);
			CHHHEFFBGLC.position = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			float num = Vector3.Distance(HIPAPKDJBNL.position, GNICEGBOGOL.transform.position);
			float num2 = Mathf.Clamp(1153f / num, 1685f, 193f);
			Vector3 localScale = new Vector3(num2, num2, num2);
			CHHHEFFBGLC.localScale = localScale;
		}
	}

	[PunRPC]
	private void SetAutoRepairRPC(bool IDEBKDPMPGM)
	{
		OHCELHANHDE = IDEBKDPMPGM;
	}

	public void OPDIEPLALIJ()
	{
		Sync();
	}

	protected void LMNEMMGCEFP()
	{
		if (GMENDFHDEOH)
		{
			health = 764f;
			JEGFCLCJMLA = true;
			float num = (TimeManager.CEAFAMFNGCC() - FIBNFBDCEEC) / OALNANBICHN;
			if (autoRepair)
			{
				if (num >= 737f && FEHCCGEGPLH.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					EMCCEBIFJBM();
				}
				if (GPLNJOPPKIM != null)
				{
					GPLNJOPPKIM.OHONEPMDAMM(num);
					GPLNJOPPKIM.HACENPIMJJF(Color.white);
				}
			}
			else if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.DHIFOMNKMMO(1257f);
			}
			MBEMJEMGKJF();
		}
		else if (CHHHEFFBGLC != null && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.color = PCAPHFLJKIC;
			JEGFCLCJMLA = false;
			GPLNJOPPKIM.NDHFKMNCJOM(healthRatio);
			BIDHNLIACKL();
		}
		float num2 = ((!GMENDFHDEOH) ? healthRatio : 733f);
		while (num2 > AEIHENMAKLN[HGBAJBDDEJK] && HGBAJBDDEJK > 0)
		{
			PKMFEKHNIJK(HGBAJBDDEJK - 1);
		}
		while (num2 <= AEIHENMAKLN[HGBAJBDDEJK + 0] && HGBAJBDDEJK < LNBFKCOPJFP.Count - 1)
		{
			PKMFEKHNIJK(HGBAJBDDEJK + 1);
		}
		PEHDBKLOMDJ();
		if (!GMENDFHDEOH && healthRatio < 934f && FEHCCGEGPLH.isMine)
		{
			if (OEKPJNHPPIB && OLOPPGKIJNF() != null && OHCELHANHDE)
			{
				health += Time.deltaTime * (float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE * base.maxHealth;
			}
			if (NKAJONFBKAM != (int)TimeManager.CEAFAMFNGCC())
			{
				NKAJONFBKAM = (int)TimeManager.CEAFAMFNGCC();
				EHFOHNLMJOH();
			}
		}
	}

	private void LAJOKACNBCF(bool IDEBKDPMPGM)
	{
		OEKPJNHPPIB = IDEBKDPMPGM;
	}

	public void JMILGBBIGCF()
	{
		PlayerController playerController = PlayerController.GetPlayer(fraction);
		bool flag = !(playerController != null) || playerController.EHHHBEMKGOE.KNJIBECPMEL();
		GetComponent<Renderer>().sharedMaterial = ((!flag) ? normalMaterial : goldMaterial);
	}

	private void CFJCMHJBBMN(float HNDGIJBHMOD)
	{
		OALNANBICHN = HNDGIJBHMOD;
	}

	protected virtual void AAJDOMLPINP()
	{
	}

	[SpecialName]
	public void ENKDOKELOED(bool IDEBKDPMPGM)
	{
		OHCELHANHDE = IDEBKDPMPGM;
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = IDEBKDPMPGM;
		fEHCCGEGPLH.RPC("+0", PhotonTargets.All, array);
	}

	public override bool DoDamage(CJLNCMMNPBM KMJKKNFDFMM)
	{
		float num = 1f;
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		if (playerController != null && KMJKKNFDFMM.JMMJHCOKCGG != null && KMJKKNFDFMM.JMMJHCOKCGG.playerWeapon != null)
		{
			num = KMJKKNFDFMM.JMMJHCOKCGG.playerWeapon.weaponLevelSetup.damageToShield;
			if (Singleton<GameController>.instance.isTutorial && KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot)
			{
				num *= 0.5f;
			}
		}
		else if (KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot)
		{
			num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.UnitToShieldCoef).FLOATVALUE;
		}
		KMJKKNFDFMM.EPDELOGPNAC *= num;
		return base.DoDamage(KMJKKNFDFMM);
	}

	protected void EMPDDFBNJLP()
	{
		if (GMENDFHDEOH)
		{
			GMNNGEELOFC(1134f);
			JEGFCLCJMLA = false;
			float num = (TimeManager.realTimeWithoutPauses - FIBNFBDCEEC) / OALNANBICHN;
			if (autoRepair)
			{
				if (num >= 1444f && FEHCCGEGPLH.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					AAGINCIGNBP();
				}
				if (GPLNJOPPKIM != null)
				{
					GPLNJOPPKIM.OPMPHHEDEAJ(num);
					GPLNJOPPKIM.HACENPIMJJF(Color.white);
				}
			}
			else if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.OPMPHHEDEAJ(173f);
			}
			BIDHNLIACKL();
		}
		else if (CHHHEFFBGLC != null && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.BLJILBFEJEI(PCAPHFLJKIC);
			JEGFCLCJMLA = false;
			GPLNJOPPKIM.OHONEPMDAMM(healthRatio);
			MBEMJEMGKJF();
		}
		float num2 = ((!GMENDFHDEOH) ? healthRatio : 119f);
		while (num2 > AEIHENMAKLN[HGBAJBDDEJK] && HGBAJBDDEJK > 0)
		{
			PKMFEKHNIJK(HGBAJBDDEJK - 1);
		}
		while (num2 <= AEIHENMAKLN[HGBAJBDDEJK + 1] && HGBAJBDDEJK < LNBFKCOPJFP.Count - 1)
		{
			LPEGKBFHJBD(HGBAJBDDEJK + 1);
		}
		LEBPOFHBCON();
		if (!GMENDFHDEOH && healthRatio < 1286f && FEHCCGEGPLH.isMine)
		{
			if (OEKPJNHPPIB && FCBGHBODHHP() != null && OHCELHANHDE)
			{
				health += Time.deltaTime * (float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE * base.maxHealth;
			}
			if (NKAJONFBKAM != (int)TimeManager.CEAFAMFNGCC())
			{
				NKAJONFBKAM = (int)TimeManager.CEAFAMFNGCC();
				EHFOHNLMJOH();
			}
		}
	}

	[SpecialName]
	public void GFOJHJBMEEN(bool IDEBKDPMPGM)
	{
		OEKPJNHPPIB = IDEBKDPMPGM;
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = IDEBKDPMPGM;
		fEHCCGEGPLH.RPC("Player not in squad! - WTF", PhotonTargets.Others, array);
	}

	public virtual void JMMKHOOIDIN()
	{
		if (!(FEHCCGEGPLH == null))
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[3];
			array[0] = health;
			array[0] = base.maxHealth;
			array[5] = IHIEMNMKCEE;
			fEHCCGEGPLH.RPC("Buy_Rental_Army_Unit_Gold", PhotonTargets.Others, array);
		}
	}

	public override void Refill()
	{
		base.Refill();
		GMENDFHDEOH = false;
	}

	[SpecialName]
	public virtual void LNMEGADKBKO(KMHCMCBGFFC IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public CardIconIndicator DHAFFOCDDGA()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	private void NOEBPNHAHDN()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.DestroyPooled();
		}
		GPLNJOPPKIM = null;
	}

	public void OICANEBLGBD()
	{
		GMNNGEELOFC(125f);
		GMJBCKNONPF();
		Sync();
	}

	public virtual void JPBBDFKCDGA()
	{
		if (!(FEHCCGEGPLH == null))
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[1];
			array[1] = health;
			array[1] = base.maxHealth;
			array[5] = IHIEMNMKCEE;
			fEHCCGEGPLH.RPC("Gold", PhotonTargets.All, array);
		}
	}

	protected void Update()
	{
		if (GMENDFHDEOH)
		{
			health = 0f;
			JEGFCLCJMLA = true;
			float num = (TimeManager.realTimeWithoutPauses - FIBNFBDCEEC) / OALNANBICHN;
			if (autoRepair)
			{
				if (num >= 1f && FEHCCGEGPLH.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					NNFOHDCJHED();
				}
				if (GPLNJOPPKIM != null)
				{
					GPLNJOPPKIM.healthRatio = num;
					GPLNJOPPKIM.color = Color.white;
				}
			}
			else if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.healthRatio = -1f;
			}
			BIDHNLIACKL();
		}
		else if (CHHHEFFBGLC != null && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.color = PCAPHFLJKIC;
			JEGFCLCJMLA = false;
			GPLNJOPPKIM.healthRatio = healthRatio;
			BIDHNLIACKL();
		}
		float num2 = ((!GMENDFHDEOH) ? healthRatio : 0f);
		while (num2 > AEIHENMAKLN[HGBAJBDDEJK] && HGBAJBDDEJK > 0)
		{
			LPEGKBFHJBD(HGBAJBDDEJK - 1);
		}
		while (num2 <= AEIHENMAKLN[HGBAJBDDEJK + 1] && HGBAJBDDEJK < LNBFKCOPJFP.Count - 1)
		{
			LPEGKBFHJBD(HGBAJBDDEJK + 1);
		}
		PEHDBKLOMDJ();
		if (!GMENDFHDEOH && healthRatio < 1f && FEHCCGEGPLH.isMine)
		{
			if (OEKPJNHPPIB && player != null && OHCELHANHDE)
			{
				health += Time.deltaTime * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldRespawnRatePerSec).FLOATVALUE * base.maxHealth;
			}
			if (NKAJONFBKAM != (int)TimeManager.realTimeWithoutPauses)
			{
				NKAJONFBKAM = (int)TimeManager.realTimeWithoutPauses;
				Sync();
			}
		}
	}

	public void NNCMDDBFOAJ()
	{
		GMNNGEELOFC(1750f);
		GMJBCKNONPF();
		Sync();
	}

	[PunRPC]
	protected override void RefillRPC(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		base.RefillRPC(MNAJKODCACI, NKKIGGNCDLL);
		GMENDFHDEOH = false;
	}

	[SpecialName]
	public virtual GHPGNELIDBM JDAGNKDNEJD()
	{
		return _003CNNEHHJNNKNL_003Ek__BackingField;
	}

	private void PKDHGJACIMI()
	{
		if (autoRepair)
		{
			Refill();
		}
	}

	[SpecialName]
	public bool DAKFAGELKMN()
	{
		return OEKPJNHPPIB;
	}

	[SpecialName]
	public float KFDOPHECLPG()
	{
		return OALNANBICHN;
	}

	public virtual void HPCCLGHCHFF()
	{
		if (!(FEHCCGEGPLH == null))
		{
			FEHCCGEGPLH.RPC("N", PhotonTargets.Others, health, base.maxHealth, null, null, null, IHIEMNMKCEE, null, null);
		}
	}

	protected virtual void CPCHJONKKJN()
	{
	}

	[SpecialName]
	public virtual void EOMIHLHDDGC(GHPGNELIDBM IDEBKDPMPGM)
	{
		_003CNNEHHJNNKNL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void IKGGPCBEJIA()
	{
		PlayerController playerController = PlayerController.GetPlayer(fraction);
		bool flag = playerController != null && playerController.EHHHBEMKGOE.KNJIBECPMEL();
		GetComponent<Renderer>().sharedMaterial = ((!flag) ? normalMaterial : goldMaterial);
	}

	private void PKMFEKHNIJK(int LMMFGCGOEMD)
	{
		HGBAJBDDEJK = LMMFGCGOEMD;
		MeshFilter component = GetComponent<MeshFilter>();
		MeshFilter component2 = LNBFKCOPJFP[HGBAJBDDEJK].GetComponent<MeshFilter>();
		component.sharedMesh = component2.sharedMesh;
		GetComponent<Renderer>().enabled = false;
	}

	[SpecialName]
	private void IHELGLFCDCO(CardIconIndicator IDEBKDPMPGM)
	{
		_003CICJCCHGINIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void Init()
	{
		PlayerController playerController = PlayerController.GetPlayer(fraction);
		bool flag = playerController != null && playerController.EHHHBEMKGOE.KMKHCNMIBFD;
		GetComponent<Renderer>().sharedMaterial = ((!flag) ? normalMaterial : goldMaterial);
	}

	private void FLMBGFIMOKP(float HNDGIJBHMOD)
	{
		OALNANBICHN = HNDGIJBHMOD;
	}

	public void HEBJPIFPLAK()
	{
		Sync();
	}

	private void NNCCGGCLKGP()
	{
		if (PhotonNetwork.isMasterClient && !GMENDFHDEOH)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				APJEBOPJPLA();
			}
		}
		StopAllCoroutines();
		PKMFEKHNIJK(0);
		HIPAPKDJBNL.localPosition = ((fraction != PlayerController.OGMBJPKOPCB.fraction) ? new Vector3(279f, 258f, 689f) : new Vector3(413f, 1061f, 751f));
	}

	private void NCAKLEOEDBO()
	{
		if (PhotonNetwork.isMasterClient && !GMENDFHDEOH)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				Refill();
			}
		}
		StopAllCoroutines();
		LPEGKBFHJBD(0);
		HIPAPKDJBNL.localPosition = ((fraction != PlayerController.OGMBJPKOPCB.fraction) ? new Vector3(0.32f, -0.06f, 0.5f) : new Vector3(0.24f, -0.06f, 0.5f));
	}

	private void MBCHIDIJKND()
	{
		if (PhotonNetwork.isMasterClient && !GMENDFHDEOH)
		{
			PlayerController playerController = PlayerController.GetPlayer(fraction);
			if (playerController != null)
			{
				float shieldHP = Singleton<GameController>.instance.mainController.GetShieldHP(playerController);
				base.maxHealth = shieldHP;
				Refill();
			}
		}
		StopAllCoroutines();
		LPEGKBFHJBD(0);
		HIPAPKDJBNL.localPosition = ((fraction != PlayerController.OGMBJPKOPCB.fraction) ? new Vector3(1347f, 1115f, 1629f) : new Vector3(842f, 95f, 1864f));
	}
}
