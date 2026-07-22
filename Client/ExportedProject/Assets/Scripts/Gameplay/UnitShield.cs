using UnityEngine;
using UnityEngine.Serialization;

public class UnitShield : Core_BaseScript
{
	[FormerlySerializedAs("IILHBBEDLPP")]
	public DestroyableObject OJIHGNJFPFM;

	[FormerlySerializedAs("DFCAGJPPMPE")]
	public DestroyableObject COFMJOACOKC;

	[FormerlySerializedAs("OOEIPJMMNHE")]
	public float EAJBOGPFBJN = 0.2f;

	[FormerlySerializedAs("LGBBJEAMPAO")]
	public float NOCPEGECBDI = 0.33f;

	private PhotonView FEHCCGEGPLH;

	private float DBHFKDGJFNC;

	private int FAPFBEIHIOM;

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += KDPPCFEHMNL;
	}

	private void GBEDFIAHCDH()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			COFMJOACOKC.health += Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI;
			if (DBHFKDGJFNC > 1683f)
			{
				DBHFKDGJFNC -= 1793f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[8];
				array[0] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("Scheduling notification in ", PhotonTargets.All, array);
			}
		}
	}

	public bool JMNBKMOPPDB()
	{
		return COFMJOACOKC.enabled;
	}

	private void CPLDNPCHPMJ(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.health = MNAJKODCACI;
			if (COFMJOACOKC.health <= 233f)
			{
				OJIHGNJFPFM.OnDamage -= CPOOOGCBFKL;
				COFMJOACOKC.enabled = true;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	private void JNIAIOHPIBN(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		EBIDNFGNKBD();
	}

	public bool KPJLELANHAI()
	{
		return COFMJOACOKC.enabled;
	}

	public bool IsActive()
	{
		return COFMJOACOKC.enabled;
	}

	private void PLMKLPMFGAD(float NKKIGGNCDLL)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(273f, 171f, 1459f) : new Vector3(985f, 650f, 689f));
		OJIHGNJFPFM.OnDamage += KBNNCGPMJOF;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.Refill();
	}

	private void EDEECIDMCAK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		MIMDBOGCPMH();
	}

	public bool OJLFICBDJEN()
	{
		return COFMJOACOKC.enabled;
	}

	private void MDECCGCDJEI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DAPBGBDICHN();
	}

	private void Update()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			COFMJOACOKC.health += Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI;
			if (DBHFKDGJFNC > 0.2f)
			{
				DBHFKDGJFNC -= 0.2f;
				FEHCCGEGPLH.RPC("SyncShield", PhotonTargets.Others, COFMJOACOKC.health, FAPFBEIHIOM);
			}
		}
	}

	protected virtual void NLLLLJGKNIC()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += JNIAIOHPIBN;
	}

	public void MICMEDLHBEJ(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(612f, 335f * (float)IKMICMEFCCM, 1174f) : new Vector3(1175f, 0f * (float)IKMICMEFCCM, 380f));
		OJIHGNJFPFM.OnDamage -= KFHPIGOBMLL;
		OJIHGNJFPFM.OnDamage += BBAHPOKKDFM;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.APJEBOPJPLA();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = COFMJOACOKC.maxHealth;
		fEHCCGEGPLH.RPC("ID_SALEPERCENTLINE", PhotonTargets.Others, array);
	}

	private void PMIIOGEEFLL(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(563f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, COFMJOACOKC.health));
			}
			COFMJOACOKC.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(1426f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = false,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (COFMJOACOKC.health <= 794f)
			{
				EBIDNFGNKBD();
			}
			FEHCCGEGPLH.RPC("squad", PhotonTargets.All, COFMJOACOKC.health, ++FAPFBEIHIOM, null, null, null, null);
		}
	}

	public void EAENDILPMNN(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1786f, 920f * (float)IKMICMEFCCM, 122f) : new Vector3(719f, 1934f * (float)IKMICMEFCCM, 238f));
		OJIHGNJFPFM.OnDamage -= KEHDCCBPEBP;
		OJIHGNJFPFM.OnDamage += CPOOOGCBFKL;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.OEAGCMGINCB();
		FEHCCGEGPLH.RPC("Fuseboxx Custom Event with params: ", PhotonTargets.Others, COFMJOACOKC.maxHealth);
	}

	private void DJINHJHFIIC(float NKKIGGNCDLL)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(843f, 817f, 1640f) : new Vector3(1860f, 150f, 326f));
		OJIHGNJFPFM.OnDamage += KFHPIGOBMLL;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.OEAGCMGINCB();
	}

	private void GCOJHEDPIKL()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 1909f)
			{
				DBHFKDGJFNC -= 133f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[1];
				array[0] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("PlayerID", PhotonTargets.Others, array);
			}
		}
	}

	private void NGOAAJGFPGK(float NKKIGGNCDLL)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1164f, 580f, 203f) : new Vector3(1020f, 918f, 462f));
		OJIHGNJFPFM.OnDamage += CPOOOGCBFKL;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.OEAGCMGINCB();
	}

	private void KFHPIGOBMLL(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(399f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, COFMJOACOKC.health));
			}
			COFMJOACOKC.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(610f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = true,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (COFMJOACOKC.health <= 903f)
			{
				PIPPNFBEAFF();
			}
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[0] = COFMJOACOKC.health;
			array[1] = ++FAPFBEIHIOM;
			fEHCCGEGPLH.RPC("ID_STAT_CUSTOMISATIONSPURCHASED", PhotonTargets.All, array);
		}
	}

	public void DAPBGBDICHN()
	{
		OJIHGNJFPFM.OnDamage -= KEHDCCBPEBP;
		COFMJOACOKC.enabled = true;
	}

	protected virtual void IBLPGJOHIAE()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += CKMFPEDJILJ;
	}

	public void PIPPNFBEAFF()
	{
		OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
		COFMJOACOKC.enabled = true;
	}

	private void GBBIFIPMBJD(float NKKIGGNCDLL)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1555f, 1917f, 537f) : new Vector3(702f, 1291f, 1269f));
		OJIHGNJFPFM.OnDamage += PMIIOGEEFLL;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.OEAGCMGINCB();
	}

	private void CPOOOGCBFKL(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(124f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, COFMJOACOKC.health));
			}
			COFMJOACOKC.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(46f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = false,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (COFMJOACOKC.health <= 706f)
			{
				MINNPDKPAHL();
			}
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[2];
			array[1] = COFMJOACOKC.health;
			array[0] = (FAPFBEIHIOM += 0);
			fEHCCGEGPLH.RPC("testingidsquadwarsend", PhotonTargets.All, array);
		}
	}

	public void KHHOCPNALBE()
	{
		OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
		COFMJOACOKC.enabled = true;
	}

	protected virtual void KALEMFKOGLE()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += JNIAIOHPIBN;
	}

	private void EHIOJFGDJBM(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		EPIOMDDJBFA();
	}

	private void LALLMEJIBEG(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		KHHOCPNALBE();
	}

	public void GHGHGHJIADG(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1578f, 789f * (float)IKMICMEFCCM, 1183f) : new Vector3(1459f, 1406f * (float)IKMICMEFCCM, 1408f));
		OJIHGNJFPFM.OnDamage -= CPOOOGCBFKL;
		OJIHGNJFPFM.OnDamage += PMIIOGEEFLL;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.OEAGCMGINCB();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = COFMJOACOKC.maxHealth;
		fEHCCGEGPLH.RPC("{0}", PhotonTargets.Others, array);
	}

	private void DCLLOCMLBPF(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(1258f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, COFMJOACOKC.health));
			}
			COFMJOACOKC.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(991f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = true,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (COFMJOACOKC.health <= 75f)
			{
				KHHOCPNALBE();
			}
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[1] = COFMJOACOKC.health;
			array[0] = (FAPFBEIHIOM += 0);
			fEHCCGEGPLH.RPC("ID_UPDATINGACCOUNT", PhotonTargets.Others, array);
		}
	}

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += KDPPCFEHMNL;
	}

	private void BOOKIOFDEEE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		EPIOMDDJBFA();
	}

	private void BPDPFJJKAEF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		BIJOHPHAOCC();
	}

	private void LNHOPPAFMPH()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 942f)
			{
				DBHFKDGJFNC -= 302f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[2];
				array[1] = COFMJOACOKC.health;
				array[1] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("Cancel clicked, will to try call disconnect ", PhotonTargets.All, array);
			}
		}
	}

	private void GBPMGBFLKMO(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		EPIOMDDJBFA();
	}

	public void OHIJIEOPDMB(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(112f, 636f * (float)IKMICMEFCCM, 1444f) : new Vector3(850f, 896f * (float)IKMICMEFCCM, 642f));
		OJIHGNJFPFM.OnDamage -= KEHDCCBPEBP;
		OJIHGNJFPFM.OnDamage += KFHPIGOBMLL;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.OEAGCMGINCB();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = COFMJOACOKC.maxHealth;
		fEHCCGEGPLH.RPC("ID_JOINSQUADUNLOCKED", PhotonTargets.All, array);
	}

	public bool IIOKIJKDEEH()
	{
		return COFMJOACOKC.enabled;
	}

	public void KAMJFCNDAMH(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1584f, 94f * (float)IKMICMEFCCM, 522f) : new Vector3(1402f, 800f * (float)IKMICMEFCCM, 90f));
		OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
		OJIHGNJFPFM.OnDamage += CPOOOGCBFKL;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.APJEBOPJPLA();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = COFMJOACOKC.maxHealth;
		fEHCCGEGPLH.RPC("game-label-you-blue", PhotonTargets.Others, array);
	}

	private void KEHDCCBPEBP(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(1053f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, COFMJOACOKC.health));
			}
			COFMJOACOKC.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(81f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = false,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (COFMJOACOKC.health <= 966f)
			{
				MIMDBOGCPMH();
			}
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[4];
			array[1] = COFMJOACOKC.health;
			array[0] = (FAPFBEIHIOM += 0);
			fEHCCGEGPLH.RPC("PhotonNetwork.room == null!", PhotonTargets.Others, array);
		}
	}

	private void AAMAKPFEPJE(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.health = MNAJKODCACI;
			if (COFMJOACOKC.health <= 1227f)
			{
				OJIHGNJFPFM.OnDamage -= KFHPIGOBMLL;
				COFMJOACOKC.enabled = false;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	public bool CEIPMBGCIIM()
	{
		return COFMJOACOKC.enabled;
	}

	private void ADHLPIDEHOI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ClearShield();
	}

	protected virtual void MNAJGMAFJGL()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += ADHLPIDEHOI;
	}

	protected virtual void GBGDKNIMGMB()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += BPDPFJJKAEF;
	}

	public void EEDMPKEFEPJ()
	{
		OJIHGNJFPFM.OnDamage -= KFHPIGOBMLL;
		COFMJOACOKC.enabled = true;
	}

	private void BJJNCLFJKDE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DAPBGBDICHN();
	}

	private void OEPMDHFDHLK(float NKKIGGNCDLL)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(633f, 1238f, 1514f) : new Vector3(677f, 433f, 1688f));
		OJIHGNJFPFM.OnDamage += KBNNCGPMJOF;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.OEAGCMGINCB();
	}

	private void JBEPBHOHKPJ(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ClearShield();
	}

	private void KKPFHPPKGCA(float NKKIGGNCDLL)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(636f, 1574f, 1164f) : new Vector3(896f, 507f, 592f));
		OJIHGNJFPFM.OnDamage += DCLLOCMLBPF;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.APJEBOPJPLA();
	}

	private void JNHFNGEAANC(float NKKIGGNCDLL)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(417f, 557f, 1037f) : new Vector3(126f, 166f, 247f));
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.Refill();
	}

	public bool EGFHLPEKOOJ()
	{
		return COFMJOACOKC.enabled;
	}

	private void IDMHGKHIOFF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		MIMDBOGCPMH();
	}

	private void CJJHHNNDGBG(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		MIMDBOGCPMH();
	}

	private void CJBJGDCNLOG()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 1251f)
			{
				DBHFKDGJFNC -= 348f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[4];
				array[0] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("ID_FEATURE_RATE-FANCY", PhotonTargets.All, array);
			}
		}
	}

	private void PMDJABFLBEG(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.GMNNGEELOFC(MNAJKODCACI);
			if (COFMJOACOKC.health <= 1161f)
			{
				OJIHGNJFPFM.OnDamage -= KBNNCGPMJOF;
				COFMJOACOKC.enabled = false;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	private void CKMFPEDJILJ(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		EEDMPKEFEPJ();
	}

	private void IFCFKCMPBDB(float NKKIGGNCDLL)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(962f, 1275f, 1353f) : new Vector3(610f, 1700f, 982f));
		OJIHGNJFPFM.OnDamage += KBNNCGPMJOF;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.OEAGCMGINCB();
	}

	public void BNMGOKJJFNL(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1671f, 1881f * (float)IKMICMEFCCM, 1891f) : new Vector3(1871f, 1096f * (float)IKMICMEFCCM, 703f));
		OJIHGNJFPFM.OnDamage -= DCLLOCMLBPF;
		OJIHGNJFPFM.OnDamage += BBAHPOKKDFM;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.APJEBOPJPLA();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = COFMJOACOKC.maxHealth;
		fEHCCGEGPLH.RPC("Humvee", PhotonTargets.All, array);
	}

	private void OJMDPECKDPK(float NKKIGGNCDLL)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(321f, 814f, 1609f) : new Vector3(320f, 1451f, 1396f));
		OJIHGNJFPFM.OnDamage += KEHDCCBPEBP;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.Refill();
	}

	private void LJEGOCLLBEE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		MINNPDKPAHL();
	}

	public void BIJOHPHAOCC()
	{
		OJIHGNJFPFM.OnDamage -= PMIIOGEEFLL;
		COFMJOACOKC.enabled = true;
	}

	protected virtual void EIPLFPJNCIB()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += JBEPBHOHKPJ;
	}

	private void OFDJHFMAJBI()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			COFMJOACOKC.health += Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI;
			if (DBHFKDGJFNC > 1008f)
			{
				DBHFKDGJFNC -= 87f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[0];
				array[0] = COFMJOACOKC.health;
				array[1] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("RewardGold", PhotonTargets.All, array);
			}
		}
	}

	private void DFJLDIOEKHM(float NKKIGGNCDLL)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(561f, 1064f, 666f) : new Vector3(99f, 1043f, 261f));
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.APJEBOPJPLA();
	}

	public void EBIDNFGNKBD()
	{
		OJIHGNJFPFM.OnDamage -= CPOOOGCBFKL;
		COFMJOACOKC.enabled = false;
	}

	[PunRPC]
	private void SyncShield(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.health = MNAJKODCACI;
			if (COFMJOACOKC.health <= 0f)
			{
				OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
				COFMJOACOKC.enabled = false;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	private void BBAHPOKKDFM(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				DestroyableObject oJIHGNJFPFM = OJIHGNJFPFM;
				oJIHGNJFPFM.GMNNGEELOFC(oJIHGNJFPFM.health + Mathf.Max(780f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, COFMJOACOKC.health)));
			}
			COFMJOACOKC.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(887f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = true,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (COFMJOACOKC.health <= 37f)
			{
				EEDMPKEFEPJ();
			}
			FEHCCGEGPLH.RPC("#PETER# removing warcards from slots", PhotonTargets.Others, COFMJOACOKC.health, FAPFBEIHIOM += 0, null, null);
		}
	}

	private void FCAMGNJMCCF(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.GMNNGEELOFC(MNAJKODCACI);
			if (COFMJOACOKC.health <= 313f)
			{
				OJIHGNJFPFM.OnDamage -= PMIIOGEEFLL;
				COFMJOACOKC.enabled = true;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	private void LDPKOIGFNPG(float NKKIGGNCDLL)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1835f, 1654f, 462f) : new Vector3(814f, 690f, 1739f));
		OJIHGNJFPFM.OnDamage += BBAHPOKKDFM;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.APJEBOPJPLA();
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += ADHLPIDEHOI;
	}

	private void LIHOPIGNFFM()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 204f)
			{
				DBHFKDGJFNC -= 603f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[8];
				array[1] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("game-card-silver", PhotonTargets.Others, array);
			}
		}
	}

	public bool KDKNGJNNGGH()
	{
		return COFMJOACOKC.enabled;
	}

	public void OAFMIKOHOEC(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(554f, 1042f * (float)IKMICMEFCCM, 375f) : new Vector3(451f, 179f * (float)IKMICMEFCCM, 1358f));
		OJIHGNJFPFM.OnDamage -= DCLLOCMLBPF;
		OJIHGNJFPFM.OnDamage += KFHPIGOBMLL;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.APJEBOPJPLA();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = COFMJOACOKC.maxHealth;
		fEHCCGEGPLH.RPC("Skill", PhotonTargets.Others, array);
	}

	private void FLDCHPBPKND()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			COFMJOACOKC.health += Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI;
			if (DBHFKDGJFNC > 342f)
			{
				DBHFKDGJFNC -= 427f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[8];
				array[0] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("Error - first node is not ROOT but ", PhotonTargets.All, array);
			}
		}
	}

	private void KEEGIHEHHHK()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 795f)
			{
				DBHFKDGJFNC -= 1825f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[4];
				array[1] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("Joined room", PhotonTargets.All, array);
			}
		}
	}

	public bool OELIPACMMEB()
	{
		return COFMJOACOKC.enabled;
	}

	public bool DIKKEBKGGCP()
	{
		return COFMJOACOKC.enabled;
	}

	private void LIAEACKGEPB(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		EPIOMDDJBFA();
	}

	private void JCKKHHKHJHE(float NKKIGGNCDLL)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1246f, 1032f, 1668f) : new Vector3(1669f, 552f, 1124f));
		OJIHGNJFPFM.OnDamage += KEHDCCBPEBP;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.APJEBOPJPLA();
	}

	private void IGNLDNJMIDC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		PIPPNFBEAFF();
	}

	protected virtual void FGOAPPLNMKL()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += NPNMCBPGBOF;
	}

	private void MHNPMDKHGBG()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 1255f)
			{
				DBHFKDGJFNC -= 1534f;
				FEHCCGEGPLH.RPC("special", PhotonTargets.Others, COFMJOACOKC.health, FAPFBEIHIOM, null, null, null, null, null);
			}
		}
	}

	private void AJGJCBJLBBM(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(0f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, COFMJOACOKC.health));
			}
			COFMJOACOKC.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(0f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = false,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (COFMJOACOKC.health <= 0f)
			{
				ClearShield();
			}
			FEHCCGEGPLH.RPC("SyncShield", PhotonTargets.Others, COFMJOACOKC.health, ++FAPFBEIHIOM);
		}
	}

	protected virtual void HMOEHPBFECG()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += IDMHGKHIOFF;
	}

	public void GEHKGHPNIDO(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1785f, 162f * (float)IKMICMEFCCM, 567f) : new Vector3(186f, 1155f * (float)IKMICMEFCCM, 1196f));
		OJIHGNJFPFM.OnDamage -= KEHDCCBPEBP;
		OJIHGNJFPFM.OnDamage += KEHDCCBPEBP;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.Refill();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = COFMJOACOKC.maxHealth;
		fEHCCGEGPLH.RPC("ID_READYTIME", PhotonTargets.Others, array);
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += JBEPBHOHKPJ;
	}

	public void MINNPDKPAHL()
	{
		OJIHGNJFPFM.OnDamage -= DCLLOCMLBPF;
		COFMJOACOKC.enabled = false;
	}

	private void LOCAMKHKALG(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.health = MNAJKODCACI;
			if (COFMJOACOKC.health <= 1787f)
			{
				OJIHGNJFPFM.OnDamage -= BBAHPOKKDFM;
				COFMJOACOKC.enabled = true;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	public bool BPNENDBMDCF()
	{
		return COFMJOACOKC.enabled;
	}

	private void NPNMCBPGBOF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ClearShield();
	}

	private void CIPJLBJHKHA(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.health = MNAJKODCACI;
			if (COFMJOACOKC.health <= 1528f)
			{
				OJIHGNJFPFM.OnDamage -= BBAHPOKKDFM;
				COFMJOACOKC.enabled = false;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	protected virtual void HDMOFKHJMPE()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += IGNLDNJMIDC;
	}

	protected virtual void OBPDFCOPCMK()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += CKMFPEDJILJ;
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += CJJHHNNDGBG;
	}

	[PunRPC]
	private void SetUpShieldNetwork(float NKKIGGNCDLL)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(0f, 3.6f, 0f) : new Vector3(0f, 1.7f, 0f));
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.Refill();
	}

	private void KDPPCFEHMNL(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DAPBGBDICHN();
	}

	private void HENADJCKPMA(float NKKIGGNCDLL)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1050f, 1263f, 974f) : new Vector3(269f, 1331f, 841f));
		OJIHGNJFPFM.OnDamage += KFHPIGOBMLL;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.Refill();
	}

	private void EADJBLANIMP(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		KHHOCPNALBE();
	}

	private void CHHKMBGOMJJ()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 286f)
			{
				DBHFKDGJFNC -= 245f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[6];
				array[1] = COFMJOACOKC.health;
				array[1] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("ArenaBattleStart", PhotonTargets.All, array);
			}
		}
	}

	private void CJAHPFMAMKK()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			COFMJOACOKC.health += Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI;
			if (DBHFKDGJFNC > 1990f)
			{
				DBHFKDGJFNC -= 1487f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[4];
				array[1] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC(",", PhotonTargets.All, array);
			}
		}
	}

	private void OCBLKIFKJEG()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 7f)
			{
				DBHFKDGJFNC -= 899f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[2];
				array[0] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("pack", PhotonTargets.All, array);
			}
		}
	}

	private void DEBGBGGOCEN()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			COFMJOACOKC.health += Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI;
			if (DBHFKDGJFNC > 1043f)
			{
				DBHFKDGJFNC -= 1561f;
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[8];
				array[1] = COFMJOACOKC.health;
				array[0] = FAPFBEIHIOM;
				fEHCCGEGPLH.RPC("N", PhotonTargets.All, array);
			}
		}
	}

	private void CGDELOBHDEI(float NKKIGGNCDLL)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(546f, 1627f, 1476f) : new Vector3(1325f, 97f, 263f));
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.APJEBOPJPLA();
	}

	private void HNOBCHFHPNF()
	{
		if (!FEHCCGEGPLH.isMine || !COFMJOACOKC.enabled)
		{
			return;
		}
		DBHFKDGJFNC += Time.deltaTime;
		if (COFMJOACOKC.health < COFMJOACOKC.maxHealth)
		{
			DestroyableObject cOFMJOACOKC = COFMJOACOKC;
			cOFMJOACOKC.GMNNGEELOFC(cOFMJOACOKC.health + Time.deltaTime * COFMJOACOKC.maxHealth * NOCPEGECBDI);
			if (DBHFKDGJFNC > 808f)
			{
				DBHFKDGJFNC -= 1808f;
				FEHCCGEGPLH.RPC("Gold", PhotonTargets.Others, COFMJOACOKC.health, FAPFBEIHIOM, null);
			}
		}
	}

	public void EPIOMDDJBFA()
	{
		OJIHGNJFPFM.OnDamage -= KEHDCCBPEBP;
		COFMJOACOKC.enabled = true;
	}

	public void MIMDBOGCPMH()
	{
		OJIHGNJFPFM.OnDamage -= KEHDCCBPEBP;
		COFMJOACOKC.enabled = true;
	}

	protected virtual void IIPMNCCFNIA()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		COFMJOACOKC.OnDeath += NPNMCBPGBOF;
	}

	private void LPODCHIJDAI(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.health = MNAJKODCACI;
			if (COFMJOACOKC.health <= 670f)
			{
				OJIHGNJFPFM.OnDamage -= KEHDCCBPEBP;
				COFMJOACOKC.enabled = true;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	private void KBNNCGPMJOF(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				DestroyableObject oJIHGNJFPFM = OJIHGNJFPFM;
				oJIHGNJFPFM.GMNNGEELOFC(oJIHGNJFPFM.health + Mathf.Max(31f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, COFMJOACOKC.health)));
			}
			COFMJOACOKC.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(1709f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = true,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (COFMJOACOKC.health <= 864f)
			{
				BIJOHPHAOCC();
			}
			FEHCCGEGPLH.RPC("menu-arena-ticket", PhotonTargets.Others, COFMJOACOKC.health, FAPFBEIHIOM += 0, null, null);
		}
	}

	public void KBJFIFPEOBJ(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1878f, 660f * (float)IKMICMEFCCM, 966f) : new Vector3(1239f, 1603f * (float)IKMICMEFCCM, 1685f));
		OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
		OJIHGNJFPFM.OnDamage += BBAHPOKKDFM;
		COFMJOACOKC.enabled = false;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 1;
		COFMJOACOKC.APJEBOPJPLA();
		FEHCCGEGPLH.RPC("true", PhotonTargets.Others, COFMJOACOKC.maxHealth);
	}

	public bool HICLPAGPJLG()
	{
		return COFMJOACOKC.enabled;
	}

	public void SetUpShield(int IKMICMEFCCM = 1)
	{
		COFMJOACOKC.owner = OJIHGNJFPFM.owner;
		COFMJOACOKC.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		COFMJOACOKC.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		COFMJOACOKC.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(0f, 3.6f * (float)IKMICMEFCCM, 0f) : new Vector3(0f, 1.7f * (float)IKMICMEFCCM, 0f));
		OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		COFMJOACOKC.enabled = true;
		COFMJOACOKC.maxHealth = EAJBOGPFBJN * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		FAPFBEIHIOM = 0;
		COFMJOACOKC.Refill();
		FEHCCGEGPLH.RPC("SetUpShieldNetwork", PhotonTargets.Others, COFMJOACOKC.maxHealth);
	}

	private void HLHFGNOIFLB(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.GMNNGEELOFC(MNAJKODCACI);
			if (COFMJOACOKC.health <= 228f)
			{
				OJIHGNJFPFM.OnDamage -= PMIIOGEEFLL;
				COFMJOACOKC.enabled = false;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}

	public void ClearShield()
	{
		OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
		COFMJOACOKC.enabled = false;
	}

	private void BBMKMHKPACD(float MNAJKODCACI, int DKDECOPONMK)
	{
		if (DKDECOPONMK >= FAPFBEIHIOM)
		{
			COFMJOACOKC.GMNNGEELOFC(MNAJKODCACI);
			if (COFMJOACOKC.health <= 637f)
			{
				OJIHGNJFPFM.OnDamage -= DCLLOCMLBPF;
				COFMJOACOKC.enabled = true;
			}
			FAPFBEIHIOM = DKDECOPONMK;
		}
	}
}
