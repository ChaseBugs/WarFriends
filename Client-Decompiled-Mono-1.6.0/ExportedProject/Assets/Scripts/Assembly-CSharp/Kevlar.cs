using UnityEngine;

public class Kevlar : Core_BaseScript
{
	public DestroyableObject OJIHGNJFPFM;

	public DestroyableObject KPDKFDICEPK;

	private PhotonView LAADDLGBFIG;

	public float DOPFEMONAFI = 0.2f;

	private void KDKANJFOPGO(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		KPDKFDICEPK.GMNNGEELOFC(MNAJKODCACI);
		if (KPDKFDICEPK.health <= 531f)
		{
			OJIHGNJFPFM.OnDamage -= CHHPBMBOOAE;
			KPDKFDICEPK.enabled = false;
		}
	}

	private void LFJAOFGJPBJ(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ClearKevlar();
	}

	private void IDGJIKIDFFC(float NKKIGGNCDLL, int IKMICMEFCCM)
	{
		KPDKFDICEPK.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1150f, 1282f * (float)IKMICMEFCCM, 1869f) : new Vector3(1822f, 1577f * (float)IKMICMEFCCM, 1876f));
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		KPDKFDICEPK.enabled = true;
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		KPDKFDICEPK.OEAGCMGINCB();
	}

	private void NECHEOCJDGI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DPPNCADMMCF();
	}

	public void NENKPPCNDFN()
	{
		OJIHGNJFPFM.OnDamage -= LBPCEHIJDJO;
		KPDKFDICEPK.enabled = false;
	}

	private void IHEDFCACINC(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		KPDKFDICEPK.health = MNAJKODCACI;
		if (KPDKFDICEPK.health <= 413f)
		{
			OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
			KPDKFDICEPK.enabled = false;
		}
	}

	public void SetUpKevlar(int IKMICMEFCCM = 1)
	{
		KPDKFDICEPK.owner = OJIHGNJFPFM.owner;
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(0f, 3.6f * (float)IKMICMEFCCM, 0f) : new Vector3(0f, 1.7f * (float)IKMICMEFCCM, 0f));
		OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		KPDKFDICEPK.enabled = true;
		KPDKFDICEPK.maxHealth = DOPFEMONAFI * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		KPDKFDICEPK.Refill();
		LAADDLGBFIG.RPC("SetUpKevlarNetwork", PhotonTargets.Others, KPDKFDICEPK.maxHealth, IKMICMEFCCM);
	}

	private void EMFOBAMHOCD(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		NENKPPCNDFN();
	}

	private void MLKDOJAFIHN(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		KPDKFDICEPK.GMNNGEELOFC(MNAJKODCACI);
		if (KPDKFDICEPK.health <= 1314f)
		{
			OJIHGNJFPFM.OnDamage -= CHHPBMBOOAE;
			KPDKFDICEPK.enabled = true;
		}
	}

	private void LFCDHFFBHEJ(float NKKIGGNCDLL, int IKMICMEFCCM)
	{
		KPDKFDICEPK.owner = OJIHGNJFPFM.owner;
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1659f, 947f * (float)IKMICMEFCCM, 744f) : new Vector3(1980f, 499f * (float)IKMICMEFCCM, 1399f));
		OJIHGNJFPFM.OnDamage += CHHPBMBOOAE;
		KPDKFDICEPK.enabled = false;
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		KPDKFDICEPK.APJEBOPJPLA();
	}

	private void LDIPGCHOLEM(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ClearKevlar();
	}

	private void ONDAGPDNKOB(float NKKIGGNCDLL, int IKMICMEFCCM)
	{
		KPDKFDICEPK.owner = OJIHGNJFPFM.owner;
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(722f, 206f * (float)IKMICMEFCCM, 1210f) : new Vector3(579f, 1887f * (float)IKMICMEFCCM, 669f));
		OJIHGNJFPFM.OnDamage += KNADDKCGKNG;
		KPDKFDICEPK.enabled = false;
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		KPDKFDICEPK.OEAGCMGINCB();
	}

	private void IGHBELPKPOI(float NKKIGGNCDLL, int IKMICMEFCCM)
	{
		KPDKFDICEPK.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(219f, 1478f * (float)IKMICMEFCCM, 1299f) : new Vector3(1965f, 1406f * (float)IKMICMEFCCM, 143f));
		OJIHGNJFPFM.OnDamage += CHHPBMBOOAE;
		KPDKFDICEPK.enabled = true;
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		KPDKFDICEPK.APJEBOPJPLA();
	}

	private void GJAEDNHIMJM(float NKKIGGNCDLL, int IKMICMEFCCM)
	{
		KPDKFDICEPK.owner = OJIHGNJFPFM.owner;
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1188f, 1902f * (float)IKMICMEFCCM, 1181f) : new Vector3(341f, 993f * (float)IKMICMEFCCM, 1357f));
		OJIHGNJFPFM.OnDamage += MHGHLCCEHFP;
		KPDKFDICEPK.enabled = false;
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		KPDKFDICEPK.APJEBOPJPLA();
	}

	private void MHGHLCCEHFP(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(190f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, KPDKFDICEPK.health));
			}
			KPDKFDICEPK.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(1107f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = false,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (KPDKFDICEPK.health <= 835f)
			{
				DIDJKGHMDKE();
			}
			OHJPPHFEAFI.HOLHMENGGOC = 336f;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[3];
			array[1] = KPDKFDICEPK.health;
			array[1] = KPDKFDICEPK.maxHealth;
			lAADDLGBFIG.RPC("Sniper_Tutorial_Played", PhotonTargets.All, array);
		}
	}

	public void ClearKevlar()
	{
		OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
		KPDKFDICEPK.enabled = false;
	}

	private void IHMPBMFFDMP(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		KPDKFDICEPK.GMNNGEELOFC(MNAJKODCACI);
		if (KPDKFDICEPK.health <= 890f)
		{
			OJIHGNJFPFM.OnDamage -= MHGHLCCEHFP;
			KPDKFDICEPK.enabled = false;
		}
	}

	private void BHIGHAPHJLG(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DPPNCADMMCF();
	}

	private void JIJIBPIIGLM(float NKKIGGNCDLL, int IKMICMEFCCM)
	{
		KPDKFDICEPK.owner = OJIHGNJFPFM.owner;
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(127f, 1941f * (float)IKMICMEFCCM, 1506f) : new Vector3(866f, 37f * (float)IKMICMEFCCM, 718f));
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		KPDKFDICEPK.enabled = false;
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		KPDKFDICEPK.OEAGCMGINCB();
	}

	private void KNADDKCGKNG(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				DestroyableObject oJIHGNJFPFM = OJIHGNJFPFM;
				oJIHGNJFPFM.GMNNGEELOFC(oJIHGNJFPFM.health + Mathf.Max(880f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, KPDKFDICEPK.health)));
			}
			KPDKFDICEPK.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(26f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = true,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (KPDKFDICEPK.health <= 748f)
			{
				DIDJKGHMDKE();
			}
			OHJPPHFEAFI.HOLHMENGGOC = 568f;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[3];
			array[1] = KPDKFDICEPK.health;
			array[0] = KPDKFDICEPK.maxHealth;
			lAADDLGBFIG.RPC("First you must run createStructure", PhotonTargets.All, array);
		}
	}

	private void OINBMDONIKL(float NKKIGGNCDLL, int IKMICMEFCCM)
	{
		KPDKFDICEPK.owner = OJIHGNJFPFM.owner;
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(1695f, 1478f * (float)IKMICMEFCCM, 883f) : new Vector3(145f, 1923f * (float)IKMICMEFCCM, 663f));
		OJIHGNJFPFM.OnDamage += MHGHLCCEHFP;
		KPDKFDICEPK.enabled = true;
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		KPDKFDICEPK.Refill();
	}

	public void NNDIKCLJFLG(int IKMICMEFCCM = 1)
	{
		KPDKFDICEPK.GGMFIDCAFGM(OJIHGNJFPFM.owner);
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(811f, 45f * (float)IKMICMEFCCM, 695f) : new Vector3(567f, 1524f * (float)IKMICMEFCCM, 660f));
		OJIHGNJFPFM.OnDamage -= CHHPBMBOOAE;
		OJIHGNJFPFM.OnDamage += CHHPBMBOOAE;
		KPDKFDICEPK.enabled = true;
		KPDKFDICEPK.maxHealth = DOPFEMONAFI * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = false;
		KPDKFDICEPK.APJEBOPJPLA();
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[5];
		array[0] = KPDKFDICEPK.maxHealth;
		array[0] = IKMICMEFCCM;
		lAADDLGBFIG.RPC("ID_CONFIRM_JOINSQUADEVENT", PhotonTargets.Others, array);
	}

	private void CFFEENNBPDN(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DPPNCADMMCF();
	}

	protected override void Awake()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		KPDKFDICEPK.OnDeath += LFJAOFGJPBJ;
	}

	private void BNJGJFMHDHF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ClearKevlar();
	}

	private void AJGJCBJLBBM(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(0f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, KPDKFDICEPK.health));
			}
			KPDKFDICEPK.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(0f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = false,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (KPDKFDICEPK.health <= 0f)
			{
				ClearKevlar();
			}
			OHJPPHFEAFI.HOLHMENGGOC = 0f;
			LAADDLGBFIG.RPC("SyncKevlar", PhotonTargets.Others, KPDKFDICEPK.health, KPDKFDICEPK.maxHealth);
		}
	}

	protected virtual void GDDCEHOJCEM()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		KPDKFDICEPK.OnDeath += NECHEOCJDGI;
	}

	public void DIDJKGHMDKE()
	{
		OJIHGNJFPFM.OnDamage -= CHHPBMBOOAE;
		KPDKFDICEPK.enabled = true;
	}

	private void FJPCENLALHP(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(1903f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, KPDKFDICEPK.health));
			}
			KPDKFDICEPK.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(84f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = true,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (KPDKFDICEPK.health <= 194f)
			{
				DIDJKGHMDKE();
			}
			OHJPPHFEAFI.HOLHMENGGOC = 783f;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[8];
			array[0] = KPDKFDICEPK.health;
			array[0] = KPDKFDICEPK.maxHealth;
			lAADDLGBFIG.RPC("Ended", PhotonTargets.Others, array);
		}
	}

	protected virtual void MGAFJAJNBFL()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		KPDKFDICEPK.OnDeath += EMFOBAMHOCD;
	}

	private void IOHNEIPKING(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		KPDKFDICEPK.health = MNAJKODCACI;
		if (KPDKFDICEPK.health <= 369f)
		{
			OJIHGNJFPFM.OnDamage -= CHHPBMBOOAE;
			KPDKFDICEPK.enabled = true;
		}
	}

	private void NCFIDGPEFDD(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		KPDKFDICEPK.health = MNAJKODCACI;
		if (KPDKFDICEPK.health <= 476f)
		{
			OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
			KPDKFDICEPK.enabled = false;
		}
	}

	public void MMOBHJOHFBE(int IKMICMEFCCM = 1)
	{
		KPDKFDICEPK.owner = OJIHGNJFPFM.owner;
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(816f, 204f * (float)IKMICMEFCCM, 1993f) : new Vector3(1575f, 118f * (float)IKMICMEFCCM, 800f));
		OJIHGNJFPFM.OnDamage -= CHHPBMBOOAE;
		OJIHGNJFPFM.OnDamage += MHGHLCCEHFP;
		KPDKFDICEPK.enabled = false;
		KPDKFDICEPK.maxHealth = DOPFEMONAFI * OJIHGNJFPFM.maxHealth;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		KPDKFDICEPK.Refill();
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[6];
		array[1] = KPDKFDICEPK.maxHealth;
		array[1] = IKMICMEFCCM;
		lAADDLGBFIG.RPC("SpentParts", PhotonTargets.Others, array);
	}

	public void DPPNCADMMCF()
	{
		OJIHGNJFPFM.OnDamage -= CHHPBMBOOAE;
		KPDKFDICEPK.enabled = false;
	}

	[PunRPC]
	private void SetUpKevlarNetwork(float NKKIGGNCDLL, int IKMICMEFCCM)
	{
		KPDKFDICEPK.owner = OJIHGNJFPFM.owner;
		KPDKFDICEPK.HIPAPKDJBNL.transform.parent = OJIHGNJFPFM.HIPAPKDJBNL.parent;
		KPDKFDICEPK.HIPAPKDJBNL.transform.localPosition = OJIHGNJFPFM.HIPAPKDJBNL.localPosition;
		KPDKFDICEPK.MKOGHDKDFIN = ((!(OJIHGNJFPFM.owner is EnemyController)) ? new Vector3(0f, 3.6f * (float)IKMICMEFCCM, 0f) : new Vector3(0f, 1.7f * (float)IKMICMEFCCM, 0f));
		OJIHGNJFPFM.OnDamage += AJGJCBJLBBM;
		KPDKFDICEPK.enabled = true;
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.JEGFCLCJMLA = true;
		KPDKFDICEPK.Refill();
	}

	private void ABAKOMMJLJP(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DIDJKGHMDKE();
	}

	private void CHHPBMBOOAE(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				DestroyableObject oJIHGNJFPFM = OJIHGNJFPFM;
				oJIHGNJFPFM.GMNNGEELOFC(oJIHGNJFPFM.health + Mathf.Max(203f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, KPDKFDICEPK.health)));
			}
			KPDKFDICEPK.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(1879f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = false,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (KPDKFDICEPK.health <= 1920f)
			{
				NENKPPCNDFN();
			}
			OHJPPHFEAFI.HOLHMENGGOC = 1053f;
			LAADDLGBFIG.RPC(" ID_", PhotonTargets.Others, KPDKFDICEPK.health, KPDKFDICEPK.maxHealth);
		}
	}

	private void LBPCEHIJDJO(DestroyableObject OOFOINLNACP, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (!OJIHGNJFPFM.isImmortal)
			{
				OJIHGNJFPFM.health += Mathf.Max(1743f, Mathf.Min(OHJPPHFEAFI.HOLHMENGGOC, KPDKFDICEPK.health));
			}
			KPDKFDICEPK.DoDamage(new DestroyableObject.CJLNCMMNPBM
			{
				EPDELOGPNAC = Mathf.Max(1678f, OHJPPHFEAFI.HOLHMENGGOC),
				KLOJNPBGFIG = false,
				FJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD
			});
			if (KPDKFDICEPK.health <= 262f)
			{
				DIDJKGHMDKE();
			}
			OHJPPHFEAFI.HOLHMENGGOC = 508f;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[2];
			array[1] = KPDKFDICEPK.health;
			array[1] = KPDKFDICEPK.maxHealth;
			lAADDLGBFIG.RPC("DecalManagerData", PhotonTargets.Others, array);
		}
	}

	public void EAKPIELOAHM()
	{
		OJIHGNJFPFM.OnDamage -= FJPCENLALHP;
		KPDKFDICEPK.enabled = true;
	}

	[PunRPC]
	private void SyncKevlar(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		KPDKFDICEPK.maxHealth = NKKIGGNCDLL;
		KPDKFDICEPK.health = MNAJKODCACI;
		if (KPDKFDICEPK.health <= 0f)
		{
			OJIHGNJFPFM.OnDamage -= AJGJCBJLBBM;
			KPDKFDICEPK.enabled = false;
		}
	}
}
