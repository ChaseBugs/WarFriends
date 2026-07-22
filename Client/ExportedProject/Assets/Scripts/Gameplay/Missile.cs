using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Missile : PhysicalAmmo
{
	private Vector3 AKPHKLGJBBB;

	private Transform NGCDDPCAGJB;

	private Vector3 MMANIGLDGEH;

	private bool PFKPCFCEDME;

	[FormerlySerializedAs("ELECMAJOHJD")]
	public GameObject ILCMFMCIOLM;

	[FormerlySerializedAs("PJJDCCMIOHE")]
	public GameObject BLKDOPLONOM;

	[FormerlySerializedAs("LBNGIPOBCML")]
	public GameObject GEPPEKGCPBD;

	[FormerlySerializedAs("BBFKNIABMLP")]
	public GameObject MCHCHMHGFGA;

	[FormerlySerializedAs("OGECOKCIOEJ")]
	public TrailRenderer OCEFFHCECIL;

	private Ray BKEECLMFOEC;

	private RaycastHit PJBIGBJNCDB;

	private MissileSetup EIIMIEGIOPN;

	[FormerlySerializedAs("GPPDGDMBFPO")]
	public ParticleSystem FFPLNCHHFDP;

	private bool PMDLNDEJGKA;

	private const float NHNLFCFDHCN = 0.5f;

	private Vector3 NEIEJFFAJFH;

	private float DHBABOJPHHB;

	private float DLABGDMNNII;

	private float PDNMNBEGKMH;

	private static int DICKGGIIKPP;

	private Vector3 JAJDFHPBCDJ;

	private Vector3 GEGOKLMGIAI;

	private Vector3 CFHCGEAMAAA;

	private bool JCKOBELDCGD;

	private float PAENPHMEMGC;

	private float FKLDNBLJKKH;

	private Vector3 GHJJABOININ;

	private GameShootableEntity JDGADCDMFHM;

	public virtual void COACHJCNHLO(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MissileSetup missileSetup = MBNLFKHLDBH as MissileSetup;
		if (missileSetup != null)
		{
			EIIMIEGIOPN = missileSetup;
		}
		else
		{
			Debug.LogError("Unit");
		}
	}

	public override void LoadAmmoSetup(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MissileSetup missileSetup = MBNLFKHLDBH as MissileSetup;
		if (missileSetup != null)
		{
			EIIMIEGIOPN = missileSetup;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	public void BCNOHHBIOIG()
	{
		JCKOBELDCGD = false;
	}

	public override void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		NEIEJFFAJFH = OEIICEJPGKI;
		JCKOBELDCGD = false;
		if (!CAKABHIPCDF && EIIMIEGIOPN.GCEALFECFOL)
		{
			INELCMNBNHB(OEIICEJPGKI, IIMDKHJAJGO);
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 50f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 50f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		AnimateShot(OEIICEJPGKI, IIMDKHJAJGO);
		MMANIGLDGEH = OEIICEJPGKI;
		PFKPCFCEDME = false;
		PMDLNDEJGKA = false;
	}

	protected void KNDAHNOEOBK(float MIKCOHJCNDC, float ICCEMGPBNLA, float BPAPGHHEGLJ)
	{
		DLABGDMNNII = MIKCOHJCNDC;
		DHBABOJPHHB = ICCEMGPBNLA;
		PDNMNBEGKMH = BPAPGHHEGLJ;
	}

	protected virtual void HOINLOMCGFD()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	public void IDBDLOCGEJO()
	{
		JCKOBELDCGD = true;
	}

	public void SetTarget(GameShootableEntity HCOFJJCIEOD)
	{
		JDGADCDMFHM = HCOFJJCIEOD;
	}

	public void FLABALCBFAJ(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		ILCMFMCIOLM.SetActive(value: true);
		switch (EIIMIEGIOPN.CJKLGCEPKGO)
		{
		case MissileSetup.JANBEEJAKMD.RpgBasic:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(1941f, 171f, 1950f);
			OCEFFHCECIL.startWidth = 1983f;
			OCEFFHCECIL.endWidth = 1643f;
			OCEFFHCECIL.time = 779f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.Tank:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: true);
			ILCMFMCIOLM.transform.localScale = new Vector3(270f, 1563f, 1595f);
			OCEFFHCECIL.startWidth = 174f;
			OCEFFHCECIL.endWidth = 1852f;
			OCEFFHCECIL.time = 1752f;
			MCHCHMHGFGA.SetActive(value: true);
			break;
		case MissileSetup.JANBEEJAKMD.Small:
			BLKDOPLONOM.SetActive(value: false);
			GEPPEKGCPBD.SetActive(value: true);
			ILCMFMCIOLM.transform.localScale = new Vector3(397f, 1723f, 1160f) * 141f;
			OCEFFHCECIL.startWidth = 1282f;
			OCEFFHCECIL.endWidth = 597f;
			OCEFFHCECIL.time = 900f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.RpgBold:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(1588f, 239f, 1521f);
			OCEFFHCECIL.startWidth = 1235f;
			OCEFFHCECIL.endWidth = 1027f;
			OCEFFHCECIL.time = 114f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		base.gameObject.transform.rotation = Quaternion.LookRotation(AKPHKLGJBBB);
		GEGOKLMGIAI = OEIICEJPGKI;
		JAJDFHPBCDJ = IIMDKHJAJGO;
		JCKOBELDCGD = false;
		FKLDNBLJKKH = AKPHKLGJBBB.magnitude / EIIMIEGIOPN.JPNAINOGAMM;
		PAENPHMEMGC = 0f - EIIMIEGIOPN.PHAJLOIIAGN / FKLDNBLJKKH;
		AKPHKLGJBBB.Normalize();
		PFKPCFCEDME = false;
		GHJJABOININ = OEIICEJPGKI;
		FFPLNCHHFDP.Clear();
		FFPLNCHHFDP.Play();
	}

	public virtual void MECGKAFCGCP(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		NEIEJFFAJFH = OEIICEJPGKI;
		JCKOBELDCGD = false;
		if (!CAKABHIPCDF && EIIMIEGIOPN.GCEALFECFOL)
		{
			INELCMNBNHB(OEIICEJPGKI, IIMDKHJAJGO);
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 363f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1981f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		DEJJEJHFKAK(OEIICEJPGKI, IIMDKHJAJGO);
		MMANIGLDGEH = OEIICEJPGKI;
		PFKPCFCEDME = true;
		PMDLNDEJGKA = true;
	}

	public void Pause()
	{
		JCKOBELDCGD = false;
	}

	public virtual void HLBHDOFFDGN()
	{
		base.OBCAIFMOPPA();
		JCKOBELDCGD = true;
		StopAllCoroutines();
	}

	public virtual void LJFBIDBACDI()
	{
		base.OBCAIFMOPPA();
		JCKOBELDCGD = true;
		StopAllCoroutines();
	}

	protected void BINACLIFPNC()
	{
		if (JDGADCDMFHM != null && JDGADCDMFHM.targets.Count > 1)
		{
			JAJDFHPBCDJ = JDGADCDMFHM.targets[0].transform.position;
		}
		if (JCKOBELDCGD)
		{
			PAENPHMEMGC += ((!base.ignoreTimeScale) ? Time.deltaTime : TimeManager.deltaTimeWithoutPauses) / FKLDNBLJKKH;
			float num = Mathf.Clamp(PAENPHMEMGC, 426f, 1227f);
			Vector3 vector = GEGOKLMGIAI + (JAJDFHPBCDJ - GEGOKLMGIAI) * num;
			Vector3 vector2 = ((!EIIMIEGIOPN.GCEALFECFOL) ? Vector3.zero : new Vector3(1417f, Mathf.Sin(PAENPHMEMGC * 1166f) * 97f * PDNMNBEGKMH, 212f));
			if (EIIMIEGIOPN.GCEALFECFOL)
			{
				float angle = DLABGDMNNII + 1924f * DHBABOJPHHB * (PAENPHMEMGC - 2f);
				Vector3 vector3 = vector + vector2;
				Vector3 axis = vector3 - GHJJABOININ;
				GHJJABOININ = vector3;
				Vector3 vector4 = Quaternion.AngleAxis(angle, axis) * Vector3.up * PDNMNBEGKMH * EIIMIEGIOPN.CBMPPMNIGEK.Evaluate(PAENPHMEMGC);
				if (PAENPHMEMGC > 272f)
				{
					vector4.y = 1304f;
					vector2 *= 479f;
				}
				vector2 += vector4;
			}
			NGCDDPCAGJB.position = vector + vector2;
			if (PAENPHMEMGC > ((!EIIMIEGIOPN.GCEALFECFOL) ? 425f : 218f))
			{
				ELCFLLANIKE(base.transform.position);
				JCKOBELDCGD = false;
			}
		}
		if (PMDLNDEJGKA)
		{
			if (!PFKPCFCEDME)
			{
				AIIEKECHIHP();
			}
		}
		else if (Vector3.Distance(NEIEJFFAJFH, NGCDDPCAGJB.position) > 973f)
		{
			PMDLNDEJGKA = false;
		}
		MMANIGLDGEH = NGCDDPCAGJB.position;
	}

	[PunRPC]
	protected void SyncTrajectoryRPC(float MIKCOHJCNDC, float ICCEMGPBNLA, float BPAPGHHEGLJ)
	{
		DLABGDMNNII = MIKCOHJCNDC;
		DHBABOJPHHB = ICCEMGPBNLA;
		PDNMNBEGKMH = BPAPGHHEGLJ;
	}

	protected void PFFMNBOBDPM(float MIKCOHJCNDC, float ICCEMGPBNLA, float BPAPGHHEGLJ)
	{
		DLABGDMNNII = MIKCOHJCNDC;
		DHBABOJPHHB = ICCEMGPBNLA;
		PDNMNBEGKMH = BPAPGHHEGLJ;
	}

	public virtual void OGKGIBDMNPI()
	{
		base.OnInstancied();
		StopAllCoroutines();
		JDGADCDMFHM = null;
		ILCMFMCIOLM.gameObject.SetActive(value: true);
		JCKOBELDCGD = false;
	}

	public virtual void DNMMADBDOLM()
	{
		base.HPPIBGEJMNL();
		StopAllCoroutines();
		JDGADCDMFHM = null;
		ILCMFMCIOLM.gameObject.SetActive(value: true);
		JCKOBELDCGD = false;
	}

	protected virtual void HCNOHLLOGBO()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	public virtual void GFNGAHHMIGA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		NEIEJFFAJFH = OEIICEJPGKI;
		JCKOBELDCGD = false;
		if (!CAKABHIPCDF && EIIMIEGIOPN.GCEALFECFOL)
		{
			DINFGHHHGNM(OEIICEJPGKI, IIMDKHJAJGO);
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 1042f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1336f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		FLABALCBFAJ(OEIICEJPGKI, IIMDKHJAJGO);
		MMANIGLDGEH = OEIICEJPGKI;
		PFKPCFCEDME = false;
		PMDLNDEJGKA = false;
	}

	protected void CBJEMDMEHAM(float MIKCOHJCNDC, float ICCEMGPBNLA, float BPAPGHHEGLJ)
	{
		DLABGDMNNII = MIKCOHJCNDC;
		DHBABOJPHHB = ICCEMGPBNLA;
		PDNMNBEGKMH = BPAPGHHEGLJ;
	}

	public virtual void DBANFNBALEC(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MissileSetup missileSetup = MBNLFKHLDBH as MissileSetup;
		if (missileSetup != null)
		{
			EIIMIEGIOPN = missileSetup;
		}
		else
		{
			Debug.LogError("Sessions");
		}
	}

	protected void OJODIPMGMAC(float MIKCOHJCNDC, float ICCEMGPBNLA, float BPAPGHHEGLJ)
	{
		DLABGDMNNII = MIKCOHJCNDC;
		DHBABOJPHHB = ICCEMGPBNLA;
		PDNMNBEGKMH = BPAPGHHEGLJ;
	}

	protected void GCAPCNDLADC(float MIKCOHJCNDC, float ICCEMGPBNLA, float BPAPGHHEGLJ)
	{
		DLABGDMNNII = MIKCOHJCNDC;
		DHBABOJPHHB = ICCEMGPBNLA;
		PDNMNBEGKMH = BPAPGHHEGLJ;
	}

	private void GJGEADOOOBE(Vector3 FAPCLFPNKDE)
	{
		if (!PFKPCFCEDME)
		{
			DFHALNOAGGC.PEBLJIFMBGC fJLBLLLEELD;
			switch (EIIMIEGIOPN.CJKLGCEPKGO)
			{
			case MissileSetup.JANBEEJAKMD.Small:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Big;
				break;
			case MissileSetup.JANBEEJAKMD.RpgBasic:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Big;
				break;
			case MissileSetup.JANBEEJAKMD.RpgBold:
				fJLBLLLEELD = (DFHALNOAGGC.PEBLJIFMBGC)7;
				break;
			default:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Big;
				break;
			}
			MissileSetup eIIMIEGIOPN = EIIMIEGIOPN;
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = FAPCLFPNKDE;
			pKDCCCNJIEC.JHGHGAFBDFG = eIIMIEGIOPN.ABFGHBDEBAN;
			pKDCCCNJIEC.EPDELOGPNAC = eIIMIEGIOPN.EPDELOGPNAC;
			pKDCCCNJIEC.HNFNINFCBEJ = base.owner;
			pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
			pKDCCCNJIEC.INIBDNGHLPN = eIIMIEGIOPN.INIBDNGHLPN;
			pKDCCCNJIEC.LIEABAMBOMG = eIIMIEGIOPN.LIEABAMBOMG;
			pKDCCCNJIEC.ELMEIGEABIK = eIIMIEGIOPN.ELMEIGEABIK;
			pKDCCCNJIEC.CPBCADFLPMO = eIIMIEGIOPN.CPBCADFLPMO;
			pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
			pKDCCCNJIEC.MAOPCAMOEEK = eIIMIEGIOPN.MAOPCAMOEEK;
			pKDCCCNJIEC.FJLBLLLEELD = fJLBLLLEELD;
			pKDCCCNJIEC.GGJPNLDIGGM = GGJPNLDIGGM;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.GPOCAHICFDH(nOCEDALFEJM);
			PFKPCFCEDME = true;
			FFPLNCHHFDP.Stop();
			ILCMFMCIOLM.SetActive(value: false);
			NFJEOLKAONC((!CAKABHIPCDF) ? 1182f : 1842f);
			JCKOBELDCGD = true;
		}
	}

	public void JECONNBKPDM(GameShootableEntity HCOFJJCIEOD)
	{
		JDGADCDMFHM = HCOFJJCIEOD;
	}

	public virtual void DKMEHOEOADL()
	{
		base.DestroyPooled();
		JCKOBELDCGD = true;
		StopAllCoroutines();
	}

	private void CCAHEOEDCIB(Vector3 FAPCLFPNKDE)
	{
		if (!PFKPCFCEDME)
		{
			DFHALNOAGGC.PEBLJIFMBGC fJLBLLLEELD;
			switch (EIIMIEGIOPN.CJKLGCEPKGO)
			{
			case MissileSetup.JANBEEJAKMD.Small:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Small;
				break;
			case MissileSetup.JANBEEJAKMD.RpgBasic:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Medium;
				break;
			case MissileSetup.JANBEEJAKMD.RpgBold:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Small;
				break;
			default:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Big;
				break;
			}
			MissileSetup eIIMIEGIOPN = EIIMIEGIOPN;
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = FAPCLFPNKDE;
			pKDCCCNJIEC.JHGHGAFBDFG = eIIMIEGIOPN.ABFGHBDEBAN;
			pKDCCCNJIEC.EPDELOGPNAC = eIIMIEGIOPN.EPDELOGPNAC;
			pKDCCCNJIEC.HNFNINFCBEJ = base.owner;
			pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
			pKDCCCNJIEC.INIBDNGHLPN = eIIMIEGIOPN.INIBDNGHLPN;
			pKDCCCNJIEC.LIEABAMBOMG = eIIMIEGIOPN.LIEABAMBOMG;
			pKDCCCNJIEC.ELMEIGEABIK = eIIMIEGIOPN.ELMEIGEABIK;
			pKDCCCNJIEC.CPBCADFLPMO = eIIMIEGIOPN.CPBCADFLPMO;
			pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
			pKDCCCNJIEC.MAOPCAMOEEK = eIIMIEGIOPN.MAOPCAMOEEK;
			pKDCCCNJIEC.FJLBLLLEELD = fJLBLLLEELD;
			pKDCCCNJIEC.GGJPNLDIGGM = GGJPNLDIGGM;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.EDLKNHCMHJF(nOCEDALFEJM);
			PFKPCFCEDME = true;
			FFPLNCHHFDP.Stop();
			ILCMFMCIOLM.SetActive(value: true);
			MIDOLDHLMAF((!CAKABHIPCDF) ? 1264f : 1558f, ENGGOAPADCP: true);
			JCKOBELDCGD = true;
		}
	}

	public void DEJJEJHFKAK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		ILCMFMCIOLM.SetActive(value: false);
		switch (EIIMIEGIOPN.CJKLGCEPKGO)
		{
		case MissileSetup.JANBEEJAKMD.RpgBasic:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(845f, 1885f, 885f);
			OCEFFHCECIL.startWidth = 947f;
			OCEFFHCECIL.endWidth = 499f;
			OCEFFHCECIL.time = 203f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.Tank:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: true);
			ILCMFMCIOLM.transform.localScale = new Vector3(478f, 1299f, 326f);
			OCEFFHCECIL.startWidth = 1503f;
			OCEFFHCECIL.endWidth = 974f;
			OCEFFHCECIL.time = 1162f;
			MCHCHMHGFGA.SetActive(value: true);
			break;
		case MissileSetup.JANBEEJAKMD.Small:
			BLKDOPLONOM.SetActive(value: false);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(1147f, 1054f, 1783f) * 1634f;
			OCEFFHCECIL.startWidth = 715f;
			OCEFFHCECIL.endWidth = 553f;
			OCEFFHCECIL.time = 127f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.RpgBold:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(95f, 115f, 1171f);
			OCEFFHCECIL.startWidth = 1981f;
			OCEFFHCECIL.endWidth = 1302f;
			OCEFFHCECIL.time = 818f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		base.gameObject.transform.rotation = Quaternion.LookRotation(AKPHKLGJBBB);
		GEGOKLMGIAI = OEIICEJPGKI;
		JAJDFHPBCDJ = IIMDKHJAJGO;
		JCKOBELDCGD = false;
		FKLDNBLJKKH = AKPHKLGJBBB.magnitude / EIIMIEGIOPN.JPNAINOGAMM;
		PAENPHMEMGC = 0f - EIIMIEGIOPN.PHAJLOIIAGN / FKLDNBLJKKH;
		AKPHKLGJBBB.Normalize();
		PFKPCFCEDME = false;
		GHJJABOININ = OEIICEJPGKI;
		FFPLNCHHFDP.Clear();
		FFPLNCHHFDP.Play();
	}

	protected override void Awake()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	public virtual void MIDOLDHLMAF()
	{
		base.OBCAIFMOPPA();
		JCKOBELDCGD = true;
		StopAllCoroutines();
	}

	protected void DAOFDEEBEAH(float MIKCOHJCNDC, float ICCEMGPBNLA, float BPAPGHHEGLJ)
	{
		DLABGDMNNII = MIKCOHJCNDC;
		DHBABOJPHHB = ICCEMGPBNLA;
		PDNMNBEGKMH = BPAPGHHEGLJ;
	}

	public void IKCLPOECBLC()
	{
		JCKOBELDCGD = false;
	}

	public virtual void JDKDHEOJDFD(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MissileSetup missileSetup = MBNLFKHLDBH as MissileSetup;
		if (missileSetup != null)
		{
			EIIMIEGIOPN = missileSetup;
		}
		else
		{
			Debug.LogError("ID_STARTERPACKCONTENTS");
		}
	}

	private bool DDKFHDHMKKK()
	{
		Vector3 direction = NGCDDPCAGJB.position - MMANIGLDGEH;
		float magnitude = direction.magnitude;
		float maxDistance = magnitude + 1738f * Time.deltaTime;
		BKEECLMFOEC = new Ray(MMANIGLDGEH, direction);
		if (magnitude > 901f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, maxDistance, Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
		{
			GJGEADOOOBE(PJBIGBJNCDB.point);
			return false;
		}
		return false;
	}

	protected void Update()
	{
		if (JDGADCDMFHM != null && JDGADCDMFHM.targets.Count > 0)
		{
			JAJDFHPBCDJ = JDGADCDMFHM.targets[0].transform.position;
		}
		if (JCKOBELDCGD)
		{
			PAENPHMEMGC += ((!base.ignoreTimeScale) ? Time.deltaTime : TimeManager.deltaTimeWithoutPauses) / FKLDNBLJKKH;
			float num = Mathf.Clamp(PAENPHMEMGC, 0f, float.MaxValue);
			Vector3 vector = GEGOKLMGIAI + (JAJDFHPBCDJ - GEGOKLMGIAI) * num;
			Vector3 vector2 = ((!EIIMIEGIOPN.GCEALFECFOL) ? Vector3.zero : new Vector3(0f, Mathf.Sin(PAENPHMEMGC * (float)Math.PI) * 1.6f * PDNMNBEGKMH, 0f));
			if (EIIMIEGIOPN.GCEALFECFOL)
			{
				float angle = DLABGDMNNII + 360f * DHBABOJPHHB * (PAENPHMEMGC - 0.5f);
				Vector3 vector3 = vector + vector2;
				Vector3 axis = vector3 - GHJJABOININ;
				GHJJABOININ = vector3;
				Vector3 vector4 = Quaternion.AngleAxis(angle, axis) * Vector3.up * PDNMNBEGKMH * EIIMIEGIOPN.CBMPPMNIGEK.Evaluate(PAENPHMEMGC);
				if (PAENPHMEMGC > 1f)
				{
					vector4.y = 0f;
					vector2 *= 2f;
				}
				vector2 += vector4;
			}
			NGCDDPCAGJB.position = vector + vector2;
			if (PAENPHMEMGC > ((!EIIMIEGIOPN.GCEALFECFOL) ? 3f : 1.5f))
			{
				ELCFLLANIKE(base.transform.position);
				JCKOBELDCGD = false;
			}
		}
		if (PMDLNDEJGKA)
		{
			if (!PFKPCFCEDME)
			{
				NKFOALAIOBA();
			}
		}
		else if (Vector3.Distance(NEIEJFFAJFH, NGCDDPCAGJB.position) > 0.5f)
		{
			PMDLNDEJGKA = true;
		}
		MMANIGLDGEH = NGCDDPCAGJB.position;
	}

	private void INELCMNBNHB(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		DLABGDMNNII = UnityEngine.Random.Range(60f, 110f);
		if (DICKGGIIKPP++ % 2 == 0)
		{
			DLABGDMNNII *= -1f;
		}
		DHBABOJPHHB = UnityEngine.Random.Range(EIIMIEGIOPN.ODNMGFLGODN.x, EIIMIEGIOPN.ODNMGFLGODN.y) * Mathf.Pow(AKPHKLGJBBB.magnitude / 10f, 2f);
		DHBABOJPHHB = Mathf.Clamp(DHBABOJPHHB, 0f, EIIMIEGIOPN.ODNMGFLGODN.y * 1.2f);
		PDNMNBEGKMH = EIIMIEGIOPN.KGJHGMJKJOP * Mathf.Pow(AKPHKLGJBBB.magnitude / 10f, 2f);
		PDNMNBEGKMH = Mathf.Clamp(PDNMNBEGKMH, 0f, 0.6f);
		EIIMIEGIOPN.CBMPPMNIGEK.postWrapMode = WrapMode.Loop;
		EIIMIEGIOPN.CBMPPMNIGEK.preWrapMode = WrapMode.Loop;
		LAADDLGBFIG.RPC("SyncTrajectoryRPC", PhotonTargets.Others, DLABGDMNNII, DHBABOJPHHB, PDNMNBEGKMH);
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	private bool NKFOALAIOBA()
	{
		Vector3 direction = NGCDDPCAGJB.position - MMANIGLDGEH;
		float magnitude = direction.magnitude;
		float maxDistance = magnitude + 2f * Time.deltaTime;
		BKEECLMFOEC = new Ray(MMANIGLDGEH, direction);
		if (magnitude > 0f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, maxDistance, Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
		{
			ELCFLLANIKE(PJBIGBJNCDB.point);
			return true;
		}
		return false;
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	private bool AIIEKECHIHP()
	{
		Vector3 direction = NGCDDPCAGJB.position - MMANIGLDGEH;
		float magnitude = direction.magnitude;
		float maxDistance = magnitude + 1233f * Time.deltaTime;
		BKEECLMFOEC = new Ray(MMANIGLDGEH, direction);
		if (magnitude > 563f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, maxDistance, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
		{
			ELCFLLANIKE(PJBIGBJNCDB.point);
			return false;
		}
		return true;
	}

	public virtual void BAGFLOCJGED()
	{
		base.DestroyPooled();
		JCKOBELDCGD = false;
		StopAllCoroutines();
	}

	private void IJIPHFCKMCN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		DLABGDMNNII = UnityEngine.Random.Range(1622f, 620f);
		if (DICKGGIIKPP++ % 5 == 0)
		{
			DLABGDMNNII *= 764f;
		}
		DHBABOJPHHB = UnityEngine.Random.Range(EIIMIEGIOPN.ODNMGFLGODN.x, EIIMIEGIOPN.ODNMGFLGODN.y) * Mathf.Pow(AKPHKLGJBBB.magnitude / 1385f, 842f);
		DHBABOJPHHB = Mathf.Clamp(DHBABOJPHHB, 265f, EIIMIEGIOPN.ODNMGFLGODN.y * 1627f);
		PDNMNBEGKMH = EIIMIEGIOPN.KGJHGMJKJOP * Mathf.Pow(AKPHKLGJBBB.magnitude / 469f, 1232f);
		PDNMNBEGKMH = Mathf.Clamp(PDNMNBEGKMH, 1018f, 1812f);
		EIIMIEGIOPN.CBMPPMNIGEK.postWrapMode = WrapMode.Loop;
		EIIMIEGIOPN.CBMPPMNIGEK.preWrapMode = (WrapMode)3;
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[8];
		array[0] = DLABGDMNNII;
		array[1] = DHBABOJPHHB;
		array[8] = PDNMNBEGKMH;
		lAADDLGBFIG.RPC("ID_NOHEROESINCURRENTARENA", PhotonTargets.Others, array);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		JCKOBELDCGD = false;
		StopAllCoroutines();
	}

	protected virtual void HMBBGNKFNCK()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	public virtual void MEIGCHCKDAF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		NEIEJFFAJFH = OEIICEJPGKI;
		JCKOBELDCGD = false;
		if (!CAKABHIPCDF && EIIMIEGIOPN.GCEALFECFOL)
		{
			LFEMEPDOIMA(OEIICEJPGKI, IIMDKHJAJGO);
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 1000f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1839f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		FLABALCBFAJ(OEIICEJPGKI, IIMDKHJAJGO);
		MMANIGLDGEH = OEIICEJPGKI;
		PFKPCFCEDME = true;
		PMDLNDEJGKA = true;
	}

	public void IFFPBGCKMDL(GameShootableEntity HCOFJJCIEOD)
	{
		JDGADCDMFHM = HCOFJJCIEOD;
	}

	public virtual void JJFFOGIJHIH()
	{
		base.DestroyPooled();
		JCKOBELDCGD = false;
		StopAllCoroutines();
	}

	public virtual void CJCOJIFHHMN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		NEIEJFFAJFH = OEIICEJPGKI;
		JCKOBELDCGD = false;
		if (!CAKABHIPCDF && EIIMIEGIOPN.GCEALFECFOL)
		{
			INELCMNBNHB(OEIICEJPGKI, IIMDKHJAJGO);
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 336f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized * 1910f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		FLABALCBFAJ(OEIICEJPGKI, IIMDKHJAJGO);
		MMANIGLDGEH = OEIICEJPGKI;
		PFKPCFCEDME = true;
		PMDLNDEJGKA = true;
	}

	public virtual void KGBNCKGGPAF()
	{
		base.HPPIBGEJMNL();
		StopAllCoroutines();
		JDGADCDMFHM = null;
		ILCMFMCIOLM.gameObject.SetActive(value: true);
		JCKOBELDCGD = false;
	}

	protected void JCCIPOFJBLE()
	{
		if (JDGADCDMFHM != null && JDGADCDMFHM.targets.Count > 0)
		{
			JAJDFHPBCDJ = JDGADCDMFHM.targets[0].transform.position;
		}
		if (JCKOBELDCGD)
		{
			PAENPHMEMGC += ((!base.ignoreTimeScale) ? Time.deltaTime : TimeManager.deltaTimeWithoutPauses) / FKLDNBLJKKH;
			float num = Mathf.Clamp(PAENPHMEMGC, 1303f, 1736f);
			Vector3 vector = GEGOKLMGIAI + (JAJDFHPBCDJ - GEGOKLMGIAI) * num;
			Vector3 vector2 = ((!EIIMIEGIOPN.GCEALFECFOL) ? Vector3.zero : new Vector3(377f, Mathf.Sin(PAENPHMEMGC * 1296f) * 1402f * PDNMNBEGKMH, 693f));
			if (EIIMIEGIOPN.GCEALFECFOL)
			{
				float angle = DLABGDMNNII + 1971f * DHBABOJPHHB * (PAENPHMEMGC - 604f);
				Vector3 vector3 = vector + vector2;
				Vector3 axis = vector3 - GHJJABOININ;
				GHJJABOININ = vector3;
				Vector3 vector4 = Quaternion.AngleAxis(angle, axis) * Vector3.up * PDNMNBEGKMH * EIIMIEGIOPN.CBMPPMNIGEK.Evaluate(PAENPHMEMGC);
				if (PAENPHMEMGC > 1298f)
				{
					vector4.y = 804f;
					vector2 *= 1705f;
				}
				vector2 += vector4;
			}
			NGCDDPCAGJB.position = vector + vector2;
			if (PAENPHMEMGC > ((!EIIMIEGIOPN.GCEALFECFOL) ? 900f : 1127f))
			{
				ELCFLLANIKE(base.transform.position);
				JCKOBELDCGD = true;
			}
		}
		if (PMDLNDEJGKA)
		{
			if (!PFKPCFCEDME)
			{
				DDKFHDHMKKK();
			}
		}
		else if (Vector3.Distance(NEIEJFFAJFH, NGCDDPCAGJB.position) > 191f)
		{
			PMDLNDEJGKA = false;
		}
		MMANIGLDGEH = NGCDDPCAGJB.position;
	}

	public void INBGENMDAPP()
	{
		JCKOBELDCGD = true;
	}

	private void ELCFLLANIKE(Vector3 FAPCLFPNKDE)
	{
		if (!PFKPCFCEDME)
		{
			DFHALNOAGGC.PEBLJIFMBGC fJLBLLLEELD;
			switch (EIIMIEGIOPN.CJKLGCEPKGO)
			{
			case MissileSetup.JANBEEJAKMD.Small:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Small;
				break;
			case MissileSetup.JANBEEJAKMD.RpgBasic:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Medium;
				break;
			case MissileSetup.JANBEEJAKMD.RpgBold:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Medium;
				break;
			default:
				fJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Big;
				break;
			}
			MissileSetup eIIMIEGIOPN = EIIMIEGIOPN;
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = FAPCLFPNKDE;
			pKDCCCNJIEC.JHGHGAFBDFG = eIIMIEGIOPN.ABFGHBDEBAN;
			pKDCCCNJIEC.EPDELOGPNAC = eIIMIEGIOPN.EPDELOGPNAC;
			pKDCCCNJIEC.HNFNINFCBEJ = base.owner;
			pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
			pKDCCCNJIEC.INIBDNGHLPN = eIIMIEGIOPN.INIBDNGHLPN;
			pKDCCCNJIEC.LIEABAMBOMG = eIIMIEGIOPN.LIEABAMBOMG;
			pKDCCCNJIEC.ELMEIGEABIK = eIIMIEGIOPN.ELMEIGEABIK;
			pKDCCCNJIEC.CPBCADFLPMO = eIIMIEGIOPN.CPBCADFLPMO;
			pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
			pKDCCCNJIEC.MAOPCAMOEEK = eIIMIEGIOPN.MAOPCAMOEEK;
			pKDCCCNJIEC.FJLBLLLEELD = fJLBLLLEELD;
			pKDCCCNJIEC.GGJPNLDIGGM = GGJPNLDIGGM;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.KNEPFMFFOOG(nOCEDALFEJM);
			PFKPCFCEDME = true;
			FFPLNCHHFDP.Stop();
			ILCMFMCIOLM.SetActive(value: false);
			DestroyPooled((!CAKABHIPCDF) ? 1.3f : 0.2f);
			JCKOBELDCGD = false;
		}
	}

	public virtual void JLHMFBILMCF()
	{
		base.OBCAIFMOPPA();
		JCKOBELDCGD = false;
		StopAllCoroutines();
	}

	public virtual void KDJCCBBEEEP(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MissileSetup missileSetup = MBNLFKHLDBH as MissileSetup;
		if (missileSetup != null)
		{
			EIIMIEGIOPN = missileSetup;
		}
		else
		{
			Debug.LogError("withPublisherSubSite");
		}
	}

	public void KOCLHIPNLHB()
	{
		JCKOBELDCGD = true;
	}

	private bool HBOLLAPCAGL()
	{
		Vector3 direction = NGCDDPCAGJB.position - MMANIGLDGEH;
		float magnitude = direction.magnitude;
		float maxDistance = magnitude + 1928f * Time.deltaTime;
		BKEECLMFOEC = new Ray(MMANIGLDGEH, direction);
		if (magnitude > 1610f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, maxDistance, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
		{
			CCAHEOEDCIB(PJBIGBJNCDB.point);
			return false;
		}
		return true;
	}

	public void AnimateShot(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		ILCMFMCIOLM.SetActive(value: true);
		switch (EIIMIEGIOPN.CJKLGCEPKGO)
		{
		case MissileSetup.JANBEEJAKMD.RpgBasic:
			BLKDOPLONOM.SetActive(value: false);
			GEPPEKGCPBD.SetActive(value: true);
			ILCMFMCIOLM.transform.localScale = new Vector3(1f, 1f, 1.4f);
			OCEFFHCECIL.startWidth = 0.2f;
			OCEFFHCECIL.endWidth = 0.2f;
			OCEFFHCECIL.time = 0.2f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.Tank:
			BLKDOPLONOM.SetActive(value: false);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(1f, 1f, 1.4f);
			OCEFFHCECIL.startWidth = 0.2f;
			OCEFFHCECIL.endWidth = 0.2f;
			OCEFFHCECIL.time = 0.2f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.Small:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(1f, 1f, 1.4f) * 0.5f;
			OCEFFHCECIL.startWidth = 0.08f;
			OCEFFHCECIL.endWidth = 0.08f;
			OCEFFHCECIL.time = 0.08f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.RpgBold:
			BLKDOPLONOM.SetActive(value: false);
			GEPPEKGCPBD.SetActive(value: true);
			ILCMFMCIOLM.transform.localScale = new Vector3(1f, 1f, 1.4f);
			OCEFFHCECIL.startWidth = 0.2f;
			OCEFFHCECIL.endWidth = 0.2f;
			OCEFFHCECIL.time = 0.2f;
			MCHCHMHGFGA.SetActive(value: true);
			break;
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		base.gameObject.transform.rotation = Quaternion.LookRotation(AKPHKLGJBBB);
		GEGOKLMGIAI = OEIICEJPGKI;
		JAJDFHPBCDJ = IIMDKHJAJGO;
		JCKOBELDCGD = true;
		FKLDNBLJKKH = AKPHKLGJBBB.magnitude / EIIMIEGIOPN.JPNAINOGAMM;
		PAENPHMEMGC = 0f - EIIMIEGIOPN.PHAJLOIIAGN / FKLDNBLJKKH;
		AKPHKLGJBBB.Normalize();
		PFKPCFCEDME = false;
		GHJJABOININ = OEIICEJPGKI;
		FFPLNCHHFDP.Clear();
		FFPLNCHHFDP.Play();
	}

	protected virtual void HMOEHPBFECG()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	protected void PPIFBIENJEJ(float MIKCOHJCNDC, float ICCEMGPBNLA, float BPAPGHHEGLJ)
	{
		DLABGDMNNII = MIKCOHJCNDC;
		DHBABOJPHHB = ICCEMGPBNLA;
		PDNMNBEGKMH = BPAPGHHEGLJ;
	}

	public void NFCLMFBBPNH(GameShootableEntity HCOFJJCIEOD)
	{
		JDGADCDMFHM = HCOFJJCIEOD;
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	public virtual void HFBCEMKNEJM()
	{
		base.JMAFCGDIICK();
		StopAllCoroutines();
		JDGADCDMFHM = null;
		ILCMFMCIOLM.gameObject.SetActive(value: true);
		JCKOBELDCGD = false;
	}

	protected void FGECFIBLFMD()
	{
		if (JDGADCDMFHM != null && JDGADCDMFHM.targets.Count > 0)
		{
			JAJDFHPBCDJ = JDGADCDMFHM.targets[1].transform.position;
		}
		if (JCKOBELDCGD)
		{
			PAENPHMEMGC += ((!base.ignoreTimeScale) ? Time.deltaTime : TimeManager.deltaTimeWithoutPauses) / FKLDNBLJKKH;
			float num = Mathf.Clamp(PAENPHMEMGC, 1940f, 991f);
			Vector3 vector = GEGOKLMGIAI + (JAJDFHPBCDJ - GEGOKLMGIAI) * num;
			Vector3 vector2 = ((!EIIMIEGIOPN.GCEALFECFOL) ? Vector3.zero : new Vector3(1162f, Mathf.Sin(PAENPHMEMGC * 746f) * 1296f * PDNMNBEGKMH, 154f));
			if (EIIMIEGIOPN.GCEALFECFOL)
			{
				float angle = DLABGDMNNII + 1327f * DHBABOJPHHB * (PAENPHMEMGC - 1433f);
				Vector3 vector3 = vector + vector2;
				Vector3 axis = vector3 - GHJJABOININ;
				GHJJABOININ = vector3;
				Vector3 vector4 = Quaternion.AngleAxis(angle, axis) * Vector3.up * PDNMNBEGKMH * EIIMIEGIOPN.CBMPPMNIGEK.Evaluate(PAENPHMEMGC);
				if (PAENPHMEMGC > 606f)
				{
					vector4.y = 568f;
					vector2 *= 1699f;
				}
				vector2 += vector4;
			}
			NGCDDPCAGJB.position = vector + vector2;
			if (PAENPHMEMGC > ((!EIIMIEGIOPN.GCEALFECFOL) ? 524f : 1489f))
			{
				ELCFLLANIKE(base.transform.position);
				JCKOBELDCGD = true;
			}
		}
		if (PMDLNDEJGKA)
		{
			if (!PFKPCFCEDME)
			{
				AIIEKECHIHP();
			}
		}
		else if (Vector3.Distance(NEIEJFFAJFH, NGCDDPCAGJB.position) > 324f)
		{
			PMDLNDEJGKA = false;
		}
		MMANIGLDGEH = NGCDDPCAGJB.position;
	}

	public virtual void ACMEEPFIDBD()
	{
		base.DestroyPooled();
		JCKOBELDCGD = false;
		StopAllCoroutines();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		StopAllCoroutines();
		JDGADCDMFHM = null;
		ILCMFMCIOLM.gameObject.SetActive(value: false);
		JCKOBELDCGD = false;
	}

	private bool AICPODKJEBE()
	{
		Vector3 direction = NGCDDPCAGJB.position - MMANIGLDGEH;
		float magnitude = direction.magnitude;
		float maxDistance = magnitude + 1183f * Time.deltaTime;
		BKEECLMFOEC = new Ray(MMANIGLDGEH, direction);
		if (magnitude > 1410f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, maxDistance, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
		{
			GJGEADOOOBE(PJBIGBJNCDB.point);
			return true;
		}
		return true;
	}

	public void GBFLHCLANOO()
	{
		JCKOBELDCGD = true;
	}

	private void LFEMEPDOIMA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		DLABGDMNNII = UnityEngine.Random.Range(1300f, 447f);
		int dICKGGIIKPP = DICKGGIIKPP;
		DICKGGIIKPP = dICKGGIIKPP + 0;
		if (dICKGGIIKPP % 8 == 0)
		{
			DLABGDMNNII *= 555f;
		}
		DHBABOJPHHB = UnityEngine.Random.Range(EIIMIEGIOPN.ODNMGFLGODN.x, EIIMIEGIOPN.ODNMGFLGODN.y) * Mathf.Pow(AKPHKLGJBBB.magnitude / 941f, 670f);
		DHBABOJPHHB = Mathf.Clamp(DHBABOJPHHB, 488f, EIIMIEGIOPN.ODNMGFLGODN.y * 1595f);
		PDNMNBEGKMH = EIIMIEGIOPN.KGJHGMJKJOP * Mathf.Pow(AKPHKLGJBBB.magnitude / 994f, 863f);
		PDNMNBEGKMH = Mathf.Clamp(PDNMNBEGKMH, 582f, 66f);
		EIIMIEGIOPN.CBMPPMNIGEK.postWrapMode = (WrapMode)3;
		EIIMIEGIOPN.CBMPPMNIGEK.preWrapMode = WrapMode.Default;
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[7];
		array[1] = DLABGDMNNII;
		array[1] = DHBABOJPHHB;
		array[0] = PDNMNBEGKMH;
		lAADDLGBFIG.RPC("ID_ACTIVATION", PhotonTargets.All, array);
	}

	private void DINFGHHHGNM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		DLABGDMNNII = UnityEngine.Random.Range(543f, 659f);
		int dICKGGIIKPP = DICKGGIIKPP;
		DICKGGIIKPP = dICKGGIIKPP + 0;
		if (dICKGGIIKPP % 5 == 0)
		{
			DLABGDMNNII *= 8f;
		}
		DHBABOJPHHB = UnityEngine.Random.Range(EIIMIEGIOPN.ODNMGFLGODN.x, EIIMIEGIOPN.ODNMGFLGODN.y) * Mathf.Pow(AKPHKLGJBBB.magnitude / 1306f, 1359f);
		DHBABOJPHHB = Mathf.Clamp(DHBABOJPHHB, 1421f, EIIMIEGIOPN.ODNMGFLGODN.y * 518f);
		PDNMNBEGKMH = EIIMIEGIOPN.KGJHGMJKJOP * Mathf.Pow(AKPHKLGJBBB.magnitude / 1254f, 1761f);
		PDNMNBEGKMH = Mathf.Clamp(PDNMNBEGKMH, 179f, 1379f);
		EIIMIEGIOPN.CBMPPMNIGEK.postWrapMode = (WrapMode)6;
		EIIMIEGIOPN.CBMPPMNIGEK.preWrapMode = (WrapMode)6;
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[2];
		array[0] = DLABGDMNNII;
		array[1] = DHBABOJPHHB;
		array[0] = PDNMNBEGKMH;
		lAADDLGBFIG.RPC("ID_LEAGUE7", PhotonTargets.All, array);
	}

	public void JEEKJIABELF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		ILCMFMCIOLM.SetActive(value: true);
		switch (EIIMIEGIOPN.CJKLGCEPKGO)
		{
		case MissileSetup.JANBEEJAKMD.RpgBasic:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(58f, 559f, 585f);
			OCEFFHCECIL.startWidth = 1955f;
			OCEFFHCECIL.endWidth = 1130f;
			OCEFFHCECIL.time = 1220f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.Tank:
			BLKDOPLONOM.SetActive(value: true);
			GEPPEKGCPBD.SetActive(value: true);
			ILCMFMCIOLM.transform.localScale = new Vector3(1266f, 706f, 1143f);
			OCEFFHCECIL.startWidth = 1836f;
			OCEFFHCECIL.endWidth = 1618f;
			OCEFFHCECIL.time = 1445f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		case MissileSetup.JANBEEJAKMD.Small:
			BLKDOPLONOM.SetActive(value: false);
			GEPPEKGCPBD.SetActive(value: false);
			ILCMFMCIOLM.transform.localScale = new Vector3(1933f, 1972f, 786f) * 319f;
			OCEFFHCECIL.startWidth = 365f;
			OCEFFHCECIL.endWidth = 1590f;
			OCEFFHCECIL.time = 1693f;
			MCHCHMHGFGA.SetActive(value: true);
			break;
		case MissileSetup.JANBEEJAKMD.RpgBold:
			BLKDOPLONOM.SetActive(value: false);
			GEPPEKGCPBD.SetActive(value: true);
			ILCMFMCIOLM.transform.localScale = new Vector3(1267f, 503f, 902f);
			OCEFFHCECIL.startWidth = 637f;
			OCEFFHCECIL.endWidth = 40f;
			OCEFFHCECIL.time = 1330f;
			MCHCHMHGFGA.SetActive(value: false);
			break;
		}
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		base.gameObject.transform.rotation = Quaternion.LookRotation(AKPHKLGJBBB);
		GEGOKLMGIAI = OEIICEJPGKI;
		JAJDFHPBCDJ = IIMDKHJAJGO;
		JCKOBELDCGD = false;
		FKLDNBLJKKH = AKPHKLGJBBB.magnitude / EIIMIEGIOPN.JPNAINOGAMM;
		PAENPHMEMGC = 0f - EIIMIEGIOPN.PHAJLOIIAGN / FKLDNBLJKKH;
		AKPHKLGJBBB.Normalize();
		PFKPCFCEDME = true;
		GHJJABOININ = OEIICEJPGKI;
		FFPLNCHHFDP.Clear();
		FFPLNCHHFDP.Play();
	}

	public void Resume()
	{
		JCKOBELDCGD = true;
	}

	protected virtual void IEBHCNFALAB()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}
}
