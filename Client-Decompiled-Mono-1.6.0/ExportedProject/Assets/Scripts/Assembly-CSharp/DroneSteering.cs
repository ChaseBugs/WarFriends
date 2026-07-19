using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class DroneSteering : Core_BaseScript
{
	public float DFGAOECAOBD = 1f;

	public float IJPFEKLCIDG = 0.4f;

	public bool IFBJNODDLJC = true;

	public bool LJMIDMAELAP;

	private int INDBNCLMMNC;

	private int ILEKLILGKAK;

	private Vector3 GPIIEAHGHEO;

	private float MMFCDIKPEHF;

	private WayPoint IMGHHHHHPKF;

	private bool KPBAJMBFKLF;

	private Vector3 DHFAONHFMCF;

	public float DAGMBMDCIIC = 1f;

	public float NEEBBLOFHEF = 1f;

	public WayPointPath MFHFIHIHBHA;

	public float JPNAINOGAMM = 0.8f;

	private readonly LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	private float NDOILFHEJHE;

	public float ECNBEOHNHCB = 0.1f;

	public float JEMGOPDEBLL = 100f;

	public Transform PBPNIONACKO;

	private float DDFHFKFOKAO;

	private DestroyableObject FFOAABONJNO;

	private Quaternion JILBNPBHBPN = Quaternion.identity;

	private PhotonView FEHCCGEGPLH;

	private float MNGLGGJJFOO;

	private Rigidbody KJPFENINCHJ;

	private Transform NGCDDPCAGJB;

	private Quaternion HFKCBAFCEAD = Quaternion.identity;

	private float NOLOFNKPIDB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<WayPoint> OBHIEBMADKD;

	public new bool enabled { get; set; }

	public event Action<WayPoint> ArrivedToWayPoint
	{
		add
		{
			Action<WayPoint> action = OBHIEBMADKD;
			Action<WayPoint> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<WayPoint> action = OBHIEBMADKD;
			Action<WayPoint> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void HBKJOFLHMCG()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + DHFAONHFMCF * JEMGOPDEBLL);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GPIIEAHGHEO * JEMGOPDEBLL);
	}

	[SpecialName]
	public void NIEBEKOMDKL(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool NPBAJCKNJKG()
	{
		return _003CNPKNFODAHDG_003Ek__BackingField;
	}

	private Vector3 HAKLACHNDBB(Vector3 MKIPAEDAADL, bool CCBIFGDBDDE = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < MNGLGGJJFOO + ECNBEOHNHCB)
		{
			return default(Vector3);
		}
		Vector3 vector = MKIPAEDAADL - NGCDDPCAGJB.position;
		Vector3 normalized = vector.normalized;
		if (CCBIFGDBDDE && vector.magnitude < DFGAOECAOBD)
		{
			float num = vector.magnitude / DFGAOECAOBD;
			normalized *= IJPFEKLCIDG * deltaTime * num;
		}
		else
		{
			normalized *= JPNAINOGAMM * deltaTime;
		}
		Vector3 vector2 = normalized - DHFAONHFMCF;
		return vector2 / DAGMBMDCIIC;
	}

	[SpecialName]
	public void KHGCBLEAFPA(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void LDNELDGECPB()
	{
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void Clear()
	{
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	public void PLKIAPHIICM()
	{
		KJPFENINCHJ.isKinematic = false;
		BKPPKEDIOGA(true);
		LADBLHGBOKJ.CHANLKFNCLA();
	}

	protected void GCOJHEDPIKL()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!enabled || !KPBAJMBFKLF || !(Time.timeScale > 1482f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = false;
				if (IMGHHHHHPKF.INPLNAMBFPG > 1727f)
				{
					if (NOLOFNKPIDB == 680f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = false;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 122f;
					if (UnityEngine.Random.value < 1431f)
					{
						IFBJNODDLJC = !IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 0 && IFBJNODDLJC)
					{
						INDBNCLMMNC++;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC -= 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = true;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = FPOLIHANKLO(IMGHHHHHPKF.transform.position, true);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 1118f);
				if ((NDOILFHEJHE > 1489f && NDOILFHEJHE < 75f) || (NDOILFHEJHE < 215f && NDOILFHEJHE > 484f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 489f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 496f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 77f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.gameIsRunning)
		{
			LADBLHGBOKJ.CJPFLJAAODD(NGCDDPCAGJB);
		}
	}

	protected Ammo.ILIOELBBLDM PBFFNNJBANH(GameShootableEntity.ShotTarget MKIPAEDAADL)
	{
		if (MKIPAEDAADL.type == GameShootableEntity.LAAAMBBNIJO.Shield)
		{
			return Ammo.ILIOELBBLDM.Shield;
		}
		return Ammo.ILIOELBBLDM.Real;
	}

	[SpecialName]
	public void LAEMCKIJCEJ(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void OMADJCKIAMD()
	{
		KJPFENINCHJ.isKinematic = false;
		JCGNCHCPLLG(false);
		LADBLHGBOKJ.EPIKLCFKOBJ();
	}

	protected virtual void FANDCCNILLD()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	protected virtual void KINHAJCDKGN()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	private void LFONMEPMNKN()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + DHFAONHFMCF * JEMGOPDEBLL);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GPIIEAHGHEO * JEMGOPDEBLL);
	}

	public void HGINBBBAAGL()
	{
		KJPFENINCHJ.isKinematic = true;
		GMGFBABPBEM(false);
	}

	private void FixedUpdate()
	{
		if (!KJPFENINCHJ.isKinematic)
		{
			KJPFENINCHJ.AddForce(Vector3.up * 8f + DHFAONHFMCF / Time.deltaTime * 2f, ForceMode.Force);
		}
	}

	[SpecialName]
	public bool NJLLPKDCMCD()
	{
		return _003CNPKNFODAHDG_003Ek__BackingField;
	}

	[SpecialName]
	public bool IPPIMKANIHI()
	{
		return _003CNPKNFODAHDG_003Ek__BackingField;
	}

	[SpecialName]
	public void JCGNCHCPLLG(bool IDEBKDPMPGM)
	{
		_003CNPKNFODAHDG_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void ANLFCJJCGMG()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!ECPOMBFINPB() || !KPBAJMBFKLF || !(Time.timeScale > 221f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = true;
				if (IMGHHHHHPKF.INPLNAMBFPG > 143f)
				{
					if (NOLOFNKPIDB == 293f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = true;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 1216f;
					if (UnityEngine.Random.value < 1152f)
					{
						IFBJNODDLJC = IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 0 && IFBJNODDLJC)
					{
						INDBNCLMMNC++;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC--;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = true;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = AEDEJDEANEC(IMGHHHHHPKF.transform.position, true);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 42f);
				if ((NDOILFHEJHE > 111f && NDOILFHEJHE < 293f) || (NDOILFHEJHE < 494f && NDOILFHEJHE > 582f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 358f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 1558f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 1162f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.KKHKIEFMENC())
		{
			LADBLHGBOKJ.OAENIGABMLO(NGCDDPCAGJB);
		}
	}

	private void GDNNAEFLBPM(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.HPAJDNGEAHP(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public void AOEICFAKIDM()
	{
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	private Vector3 JADAEPCNKIP(Vector3 MKIPAEDAADL, bool CCBIFGDBDDE = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < MNGLGGJJFOO + ECNBEOHNHCB)
		{
			return default(Vector3);
		}
		Vector3 vector = MKIPAEDAADL - NGCDDPCAGJB.position;
		Vector3 normalized = vector.normalized;
		if (CCBIFGDBDDE && vector.magnitude < DFGAOECAOBD)
		{
			float num = vector.magnitude / DFGAOECAOBD;
			normalized *= IJPFEKLCIDG * deltaTime * num;
		}
		else
		{
			normalized *= JPNAINOGAMM * deltaTime;
		}
		Vector3 vector2 = normalized - DHFAONHFMCF;
		return vector2 / DAGMBMDCIIC;
	}

	public void GGKBCJCLHEH()
	{
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	[SpecialName]
	public void JLHFJOOAOMJ(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected void FMKLDIJPHIH()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!BDBHOPNGBBG() || !KPBAJMBFKLF || !(Time.timeScale > 1982f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = true;
				if (IMGHHHHHPKF.INPLNAMBFPG > 1964f)
				{
					if (NOLOFNKPIDB == 1992f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = true;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 1835f;
					if (UnityEngine.Random.value < 920f)
					{
						IFBJNODDLJC = !IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
					{
						INDBNCLMMNC += 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC -= 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = true;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = JADAEPCNKIP(IMGHHHHHPKF.transform.position, true);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 621f);
				if ((NDOILFHEJHE > 348f && NDOILFHEJHE < 1017f) || (NDOILFHEJHE < 1284f && NDOILFHEJHE > 832f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 153f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 15f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 286f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.gameIsRunning)
		{
			LADBLHGBOKJ.GBEDFIAHCDH(NGCDDPCAGJB);
		}
	}

	[SpecialName]
	public void GMGFBABPBEM(bool IDEBKDPMPGM)
	{
		_003CNPKNFODAHDG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool HHHGDCFFHHB()
	{
		return _003CNPKNFODAHDG_003Ek__BackingField;
	}

	private void PLGDNELNGBG()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + DHFAONHFMCF * JEMGOPDEBLL);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GPIIEAHGHEO * JEMGOPDEBLL);
	}

	[SpecialName]
	public void DHMKIPKJAKK(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool BDBHOPNGBBG()
	{
		return _003CNPKNFODAHDG_003Ek__BackingField;
	}

	private void IEAJEJIAAMJ()
	{
		if (!KJPFENINCHJ.isKinematic)
		{
			KJPFENINCHJ.AddForce(Vector3.up * 1756f + DHFAONHFMCF / Time.deltaTime * 1584f, ForceMode.Impulse);
		}
	}

	[SpecialName]
	public bool ECPOMBFINPB()
	{
		return _003CNPKNFODAHDG_003Ek__BackingField;
	}

	public void MAEKNKHGEBN()
	{
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	public void PJFMFICLKEA()
	{
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	protected Ammo.ILIOELBBLDM FHMPICPJIGE(GameShootableEntity.ShotTarget MKIPAEDAADL)
	{
		if (MKIPAEDAADL.type == (GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out))
		{
			return (Ammo.ILIOELBBLDM)5;
		}
		return Ammo.ILIOELBBLDM.Fake;
	}

	protected void OOCJOBIIKAH()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!ECPOMBFINPB() || !KPBAJMBFKLF || !(Time.timeScale > 931f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = true;
				if (IMGHHHHHPKF.INPLNAMBFPG > 629f)
				{
					if (NOLOFNKPIDB == 1303f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = false;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 1929f;
					if (UnityEngine.Random.value < 1163f)
					{
						IFBJNODDLJC = IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
					{
						INDBNCLMMNC += 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC -= 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = false;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = AEDEJDEANEC(IMGHHHHHPKF.transform.position);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 510f);
				if ((NDOILFHEJHE > 1411f && NDOILFHEJHE < 903f) || (NDOILFHEJHE < 1597f && NDOILFHEJHE > 1576f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 615f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 987f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 1160f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.PMPDBJCPDHJ(NGCDDPCAGJB);
		}
	}

	public void FAJOBDLJOHF(WayPoint PLMMBKGLGAB, MainGameEntity HNFNINFCBEJ)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB;
		KPBAJMBFKLF = false;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = HNFNINFCBEJ;
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public void BEECMIMCIBK()
	{
		KJPFENINCHJ.isKinematic = true;
		BKPPKEDIOGA(false);
	}

	[SpecialName]
	public void DLFMGPLGGDO(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected void HAMDMFGNIKD()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!enabled || !KPBAJMBFKLF || !(Time.timeScale > 1695f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = false;
				if (IMGHHHHHPKF.INPLNAMBFPG > 1116f)
				{
					if (NOLOFNKPIDB == 236f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = true;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 680f;
					if (UnityEngine.Random.value < 1518f)
					{
						IFBJNODDLJC = !IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 0 && IFBJNODDLJC)
					{
						INDBNCLMMNC++;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC--;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = true;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = HAKLACHNDBB(IMGHHHHHPKF.transform.position, true);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 1731f);
				if ((NDOILFHEJHE > 37f && NDOILFHEJHE < 1034f) || (NDOILFHEJHE < 1862f && NDOILFHEJHE > 1967f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 1036f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 1186f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 627f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.JJNMKIAJPNA(NGCDDPCAGJB);
		}
	}

	[SpecialName]
	public void KILIHJAPCCH(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void FDDHOFAJOLM(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private Vector3 IKGKMDLPMGD(Vector3 MKIPAEDAADL, bool CCBIFGDBDDE = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < MNGLGGJJFOO + ECNBEOHNHCB)
		{
			return default(Vector3);
		}
		Vector3 vector = MKIPAEDAADL - NGCDDPCAGJB.position;
		Vector3 normalized = vector.normalized;
		if (CCBIFGDBDDE && vector.magnitude < DFGAOECAOBD)
		{
			float num = vector.magnitude / DFGAOECAOBD;
			normalized *= IJPFEKLCIDG * deltaTime * num;
		}
		else
		{
			normalized *= JPNAINOGAMM * deltaTime;
		}
		Vector3 vector2 = normalized - DHFAONHFMCF;
		return vector2 / DAGMBMDCIIC;
	}

	private void EIJKJBDKMIB()
	{
		if (!KJPFENINCHJ.isKinematic)
		{
			KJPFENINCHJ.AddForce(Vector3.up * 65f + DHFAONHFMCF / Time.deltaTime * 1694f, ForceMode.Force);
		}
	}

	[SpecialName]
	public void BKPPKEDIOGA(bool IDEBKDPMPGM)
	{
		_003CNPKNFODAHDG_003Ek__BackingField = IDEBKDPMPGM;
	}

	private Vector3 AEDEJDEANEC(Vector3 MKIPAEDAADL, bool CCBIFGDBDDE = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < MNGLGGJJFOO + ECNBEOHNHCB)
		{
			return default(Vector3);
		}
		Vector3 vector = MKIPAEDAADL - NGCDDPCAGJB.position;
		Vector3 normalized = vector.normalized;
		if (CCBIFGDBDDE && vector.magnitude < DFGAOECAOBD)
		{
			float num = vector.magnitude / DFGAOECAOBD;
			normalized *= IJPFEKLCIDG * deltaTime * num;
		}
		else
		{
			normalized *= JPNAINOGAMM * deltaTime;
		}
		Vector3 vector2 = normalized - DHFAONHFMCF;
		return vector2 / DAGMBMDCIIC;
	}

	public void JNMLDCJOAMK()
	{
		KJPFENINCHJ.isKinematic = false;
		BKPPKEDIOGA(false);
	}

	[SpecialName]
	public void BOFJNMOPFGP(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected void ADLJAKCCELG()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!ECPOMBFINPB() || !KPBAJMBFKLF || !(Time.timeScale > 111f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = false;
				if (IMGHHHHHPKF.INPLNAMBFPG > 287f)
				{
					if (NOLOFNKPIDB == 1970f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = true;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 338f;
					if (UnityEngine.Random.value < 1528f)
					{
						IFBJNODDLJC = !IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
					{
						INDBNCLMMNC++;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC--;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = true;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = JADAEPCNKIP(IMGHHHHHPKF.transform.position, true);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 347f);
				if ((NDOILFHEJHE > 825f && NDOILFHEJHE < 1917f) || (NDOILFHEJHE < 615f && NDOILFHEJHE > 64f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 435f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 542f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 1387f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.gameIsRunning)
		{
			LADBLHGBOKJ.JMHFNCOODKH(NGCDDPCAGJB);
		}
	}

	public void FallDown()
	{
		KJPFENINCHJ.isKinematic = false;
		enabled = false;
	}

	[SpecialName]
	public void KGCEAMGMBBJ(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void FDONEJOAMNG(Action<WayPoint> IDEBKDPMPGM)
	{
		Action<WayPoint> action = OBHIEBMADKD;
		Action<WayPoint> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref OBHIEBMADKD, (Action<WayPoint>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void MDGDJADEEML(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.DJJHBGCKAGA(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	protected void IAPBHPLNNNO()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!FAFBBMGELDN() || !KPBAJMBFKLF || !(Time.timeScale > 68f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = true;
				if (IMGHHHHHPKF.INPLNAMBFPG > 1094f)
				{
					if (NOLOFNKPIDB == 1107f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = false;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 1563f;
					if (UnityEngine.Random.value < 145f)
					{
						IFBJNODDLJC = IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 0 && IFBJNODDLJC)
					{
						INDBNCLMMNC++;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC--;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = true;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = AEDEJDEANEC(IMGHHHHHPKF.transform.position);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 232f);
				if ((NDOILFHEJHE > 1142f && NDOILFHEJHE < 90f) || (NDOILFHEJHE < 589f && NDOILFHEJHE > 1150f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 1317f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 361f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 740f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.OAENIGABMLO(NGCDDPCAGJB);
		}
	}

	protected void CMELHMEBEFI()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!NJLLPKDCMCD() || !KPBAJMBFKLF || !(Time.timeScale > 1893f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = false;
				if (IMGHHHHHPKF.INPLNAMBFPG > 1879f)
				{
					if (NOLOFNKPIDB == 863f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = true;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 1502f;
					if (UnityEngine.Random.value < 824f)
					{
						IFBJNODDLJC = !IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
					{
						INDBNCLMMNC++;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC -= 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = false;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = NADCOBPHNGM(IMGHHHHHPKF.transform.position, true);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 1761f);
				if ((NDOILFHEJHE > 1346f && NDOILFHEJHE < 30f) || (NDOILFHEJHE < 333f && NDOILFHEJHE > 730f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 668f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 1547f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 48f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.KKHKIEFMENC())
		{
			LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
		}
	}

	protected void MGAIKDBOPKI()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!ECPOMBFINPB() || !KPBAJMBFKLF || !(Time.timeScale > 1263f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = true;
				if (IMGHHHHHPKF.INPLNAMBFPG > 45f)
				{
					if (NOLOFNKPIDB == 328f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = true;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 264f;
					if (UnityEngine.Random.value < 1429f)
					{
						IFBJNODDLJC = !IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
					{
						INDBNCLMMNC += 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC -= 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = true;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = HAKLACHNDBB(IMGHHHHHPKF.transform.position);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 910f);
				if ((NDOILFHEJHE > 1767f && NDOILFHEJHE < 511f) || (NDOILFHEJHE < 280f && NDOILFHEJHE > 765f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 262f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 160f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 1852f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.EMPDDFBNJLP(NGCDDPCAGJB);
		}
	}

	private void FFCKLMENEKA(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.HGLALGJNHEM(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public void EDPLJGHIHAP()
	{
		KJPFENINCHJ.isKinematic = false;
		BKPPKEDIOGA(true);
		LADBLHGBOKJ.OGHELMDBPIL();
	}

	protected virtual void OLBEOPKDEBJ()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void NIBDIENPOJI()
	{
		KJPFENINCHJ.isKinematic = false;
		BBHGHPIBJOO(true);
		LADBLHGBOKJ.EPIKLCFKOBJ();
	}

	private void HLMMLHCMLAN()
	{
		if (!KJPFENINCHJ.isKinematic)
		{
			KJPFENINCHJ.AddForce(Vector3.up * 1083f + DHFAONHFMCF / Time.deltaTime * 1249f, ForceMode.Impulse);
		}
	}

	public void KELFBJEEPAL()
	{
		KJPFENINCHJ.isKinematic = true;
		JCGNCHCPLLG(false);
		LADBLHGBOKJ.PAODBOEOFNF();
	}

	private void MKKLBGNGODK(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.JGJPNAGMNIO(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private Vector3 FPOLIHANKLO(Vector3 MKIPAEDAADL, bool CCBIFGDBDDE = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < MNGLGGJJFOO + ECNBEOHNHCB)
		{
			return default(Vector3);
		}
		Vector3 vector = MKIPAEDAADL - NGCDDPCAGJB.position;
		Vector3 normalized = vector.normalized;
		if (CCBIFGDBDDE && vector.magnitude < DFGAOECAOBD)
		{
			float num = vector.magnitude / DFGAOECAOBD;
			normalized *= IJPFEKLCIDG * deltaTime * num;
		}
		else
		{
			normalized *= JPNAINOGAMM * deltaTime;
		}
		Vector3 vector2 = normalized - DHFAONHFMCF;
		return vector2 / DAGMBMDCIIC;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + DHFAONHFMCF * JEMGOPDEBLL);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GPIIEAHGHEO * JEMGOPDEBLL);
	}

	private void ABBGKOIPHJK()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + DHFAONHFMCF * JEMGOPDEBLL);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GPIIEAHGHEO * JEMGOPDEBLL);
	}

	public void IALMNKGNJKL(WayPoint PLMMBKGLGAB, MainGameEntity HNFNINFCBEJ)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB;
		KPBAJMBFKLF = false;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = HNFNINFCBEJ;
	}

	public void MKNKFNEMHLN()
	{
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	private Vector3 NADCOBPHNGM(Vector3 MKIPAEDAADL, bool CCBIFGDBDDE = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < MNGLGGJJFOO + ECNBEOHNHCB)
		{
			return default(Vector3);
		}
		Vector3 vector = MKIPAEDAADL - NGCDDPCAGJB.position;
		Vector3 normalized = vector.normalized;
		if (CCBIFGDBDDE && vector.magnitude < DFGAOECAOBD)
		{
			float num = vector.magnitude / DFGAOECAOBD;
			normalized *= IJPFEKLCIDG * deltaTime * num;
		}
		else
		{
			normalized *= JPNAINOGAMM * deltaTime;
		}
		Vector3 vector2 = normalized - DHFAONHFMCF;
		return vector2 / DAGMBMDCIIC;
	}

	public void NLKDPLDCOCD()
	{
		KJPFENINCHJ.isKinematic = false;
		BKPPKEDIOGA(false);
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
		KJPFENINCHJ = GetComponent<Rigidbody>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	[SpecialName]
	public void EJACMGLICLJ(bool IDEBKDPMPGM)
	{
		_003CNPKNFODAHDG_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void GADEJINLIDD()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + DHFAONHFMCF * JEMGOPDEBLL);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + GPIIEAHGHEO * JEMGOPDEBLL);
	}

	public void SetWayPoint(WayPoint PLMMBKGLGAB, MainGameEntity HNFNINFCBEJ)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB;
		KPBAJMBFKLF = true;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = HNFNINFCBEJ;
	}

	protected void LHJAGNOOBAF()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!FAFBBMGELDN() || !KPBAJMBFKLF || !(Time.timeScale > 259f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = true;
				if (IMGHHHHHPKF.INPLNAMBFPG > 1335f)
				{
					if (NOLOFNKPIDB == 560f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = false;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 731f;
					if (UnityEngine.Random.value < 197f)
					{
						IFBJNODDLJC = IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 0 && IFBJNODDLJC)
					{
						INDBNCLMMNC += 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC -= 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = true;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = AEDEJDEANEC(IMGHHHHHPKF.transform.position);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 114f);
				if ((NDOILFHEJHE > 1212f && NDOILFHEJHE < 222f) || (NDOILFHEJHE < 90f && NDOILFHEJHE > 925f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 1947f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 99f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 1725f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.OPMNIHDAHAA(NGCDDPCAGJB);
		}
	}

	protected void LPFGBKIINMP()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!NPBAJCKNJKG() || !KPBAJMBFKLF || !(Time.timeScale > 725f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = true;
				if (IMGHHHHHPKF.INPLNAMBFPG > 967f)
				{
					if (NOLOFNKPIDB == 1092f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = true;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 1468f;
					if (UnityEngine.Random.value < 1723f)
					{
						IFBJNODDLJC = IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
					{
						INDBNCLMMNC += 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC -= 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = false;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = AEDEJDEANEC(IMGHHHHHPKF.transform.position);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 1891f);
				if ((NDOILFHEJHE > 601f && NDOILFHEJHE < 1493f) || (NDOILFHEJHE < 126f && NDOILFHEJHE > 70f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 1443f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 1561f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 328f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.HGOPHIOCEOI(NGCDDPCAGJB);
		}
	}

	[SpecialName]
	public bool JAHIPJBHIFL()
	{
		return _003CNPKNFODAHDG_003Ek__BackingField;
	}

	protected void Update()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!enabled || !KPBAJMBFKLF || !(Time.timeScale > 0.1f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = true;
				if (IMGHHHHHPKF.INPLNAMBFPG > 0f)
				{
					if (NOLOFNKPIDB == 0f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = false;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 0f;
					if (UnityEngine.Random.value < 0.1f)
					{
						IFBJNODDLJC = !IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
					{
						INDBNCLMMNC++;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC--;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = false;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = NADCOBPHNGM(IMGHHHHHPKF.transform.position, true);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 5f);
				if ((NDOILFHEJHE > 0f && NDOILFHEJHE < 90f) || (NDOILFHEJHE < -270f && NDOILFHEJHE > -360f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 0f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 5f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 60f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.gameIsRunning)
		{
			LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
		}
	}

	protected void JOCHCGHAIGH()
	{
		if (FEHCCGEGPLH.isMine)
		{
			if (!FAFBBMGELDN() || !KPBAJMBFKLF || !(Time.timeScale > 1179f) || !(IMGHHHHHPKF != null) || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.transform.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				bool flag = false;
				if (IMGHHHHHPKF.INPLNAMBFPG > 1628f)
				{
					if (NOLOFNKPIDB == 28f)
					{
						MNGLGGJJFOO = Time.time;
						if (OBHIEBMADKD != null)
						{
							OBHIEBMADKD(IMGHHHHHPKF);
						}
					}
					NOLOFNKPIDB += Time.deltaTime;
					if (NOLOFNKPIDB < IMGHHHHHPKF.INPLNAMBFPG)
					{
						flag = false;
					}
				}
				else
				{
					MNGLGGJJFOO = Time.time;
					if (OBHIEBMADKD != null)
					{
						OBHIEBMADKD(IMGHHHHHPKF);
					}
				}
				if (flag)
				{
					NOLOFNKPIDB = 1747f;
					if (UnityEngine.Random.value < 1778f)
					{
						IFBJNODDLJC = !IFBJNODDLJC;
					}
					if (INDBNCLMMNC < ILEKLILGKAK - 1 && IFBJNODDLJC)
					{
						INDBNCLMMNC++;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (INDBNCLMMNC != 0 && !IFBJNODDLJC)
					{
						INDBNCLMMNC--;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else if (LJMIDMAELAP && IFBJNODDLJC)
					{
						INDBNCLMMNC = 1;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
					else
					{
						if (!LJMIDMAELAP || IFBJNODDLJC)
						{
							KPBAJMBFKLF = false;
							return;
						}
						INDBNCLMMNC = ILEKLILGKAK - 0;
						IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC];
					}
				}
			}
			if (INDBNCLMMNC < ILEKLILGKAK)
			{
				GPIIEAHGHEO = NADCOBPHNGM(IMGHHHHHPKF.transform.position);
				DHFAONHFMCF += GPIIEAHGHEO;
				NGCDDPCAGJB.position += DHFAONHFMCF;
				Vector3 axis = Vector3.Cross(Vector3.up, DHFAONHFMCF);
				NDOILFHEJHE = Mathf.Lerp(NDOILFHEJHE, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 1410f);
				if ((NDOILFHEJHE > 436f && NDOILFHEJHE < 596f) || (NDOILFHEJHE < 1802f && NDOILFHEJHE > 1403f))
				{
					MMFCDIKPEHF = GPIIEAHGHEO.magnitude / Time.deltaTime;
				}
				else
				{
					MMFCDIKPEHF = (0f - GPIIEAHGHEO.magnitude) / Time.deltaTime;
				}
				if (PBPNIONACKO != null)
				{
					Vector3 forward = NGCDDPCAGJB.position - PBPNIONACKO.position;
					forward.y = 1842f;
					HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), Time.deltaTime * 345f);
				}
				JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, Quaternion.AngleAxis(MMFCDIKPEHF * NEEBBLOFHEF / 1616f, axis), Time.deltaTime);
				NGCDDPCAGJB.rotation = HFKCBAFCEAD * JILBNPBHBPN;
			}
		}
		else if (KJPFENINCHJ.isKinematic && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.JAFBNNAACCL(NGCDDPCAGJB);
		}
	}

	[SpecialName]
	public bool FAFBBMGELDN()
	{
		return _003CNPKNFODAHDG_003Ek__BackingField;
	}

	public void IGCJCNFFALO()
	{
		KJPFENINCHJ.isKinematic = true;
		BKPPKEDIOGA(false);
	}

	[SpecialName]
	public void BBHGHPIBJOO(bool IDEBKDPMPGM)
	{
		_003CNPKNFODAHDG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void Init()
	{
		KJPFENINCHJ.isKinematic = true;
		enabled = true;
		LADBLHGBOKJ.ILOHAHFIOKM();
	}
}
