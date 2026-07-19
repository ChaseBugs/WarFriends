using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPointEngineerTurret : EnemyPoint
{
	private Turret IBBCIFFPJAO;

	public override bool isFree
	{
		get
		{
			return base.isFree && turret == null;
		}
	}

	public override Vector3 position
	{
		get
		{
			return base.position - base.transform.forward * 0.2f;
		}
	}

	public Vector3 turretPosition
	{
		get
		{
			NavMeshHit hit;
			NavMesh.SamplePosition(position + base.transform.forward * 0.4f, out hit, 10f, 1);
			return hit.position;
		}
	}

	public Turret turret
	{
		get
		{
			return IBBCIFFPJAO;
		}
		set
		{
			IBBCIFFPJAO = value;
		}
	}

	protected virtual void DFMALDFADAB()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)88;
		IOIIEDDBIKD(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Tower);
	}

	private void DKNCMDDNBBA(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		FOJBCKOGLFC().Killed -= NPDPBNHBKLE;
		if (MAIPDGCABNL == OCGKHNOJBKH())
		{
			FCNADCPPIAB(null);
		}
	}

	private void OCBLINFNPLH(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
	}

	[SpecialName]
	public Turret PJCEMFLNDHJ()
	{
		return IBBCIFFPJAO;
	}

	private void NJMFHCNLLBL(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
	}

	[SpecialName]
	public virtual bool BLCFDEOELFL()
	{
		return base.PKKBHKIOOFN() && OCGKHNOJBKH() == null;
	}

	private void OJGBCJPAKKN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		BGMJGFBBHHB().Killed -= KLJPJMGCIAI;
		if (MAIPDGCABNL == JDPBNCDHOHB())
		{
			BDJHIEOAAAK(null);
		}
	}

	[SpecialName]
	public void ADLGMJJAKLM(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool LJKBPGOLBKK()
	{
		return base.PKKBHKIOOFN() && turret == null;
	}

	public void KCPBCPCDDIL(Turret KAEAMDOJMIF)
	{
		turret = KAEAMDOJMIF;
		JDPBNCDHOHB().Killed += OJGBCJPAKKN;
	}

	[SpecialName]
	public virtual Vector3 ALLAKIJEEAB()
	{
		return base.MOOGMFPMKEM() - base.transform.forward * 421f;
	}

	public void LGNJGAKCFFK(Turret KAEAMDOJMIF)
	{
		LIFGDBPMFFL(KAEAMDOJMIF);
		FOJBCKOGLFC().Killed += PLNPLCFLCME;
	}

	[SpecialName]
	public void HFBAFCIOPCO(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual Vector3 NCFKBBAELFB()
	{
		return base.MOOGMFPMKEM() - base.transform.forward * 359f;
	}

	protected virtual void EJNJCILPBEC()
	{
		CFGDCEOLKJG();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)30;
		HBBKGCJEDNO(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Tower | LJGGJMAFEBN.Minigunner);
	}

	[SpecialName]
	public Vector3 NBOHBJICGML()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(FBGFMDOHAEG() + base.transform.forward * 621f, out hit, 1647f, 1);
		return hit.position;
	}

	[SpecialName]
	public void IKPMDPNDAHH(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	public void FOHGJMPLGEP(Turret KAEAMDOJMIF)
	{
		BDJHIEOAAAK(KAEAMDOJMIF);
		BGMJGFBBHHB().Killed += EKEIOPPDMMA;
	}

	private void FICELEOKGNG()
	{
		if (KFMJHOMNDGG() != null)
		{
			JDPBNCDHOHB().Killed -= DKNCMDDNBBA;
			PHAEKHDENNL(null);
		}
	}

	[SpecialName]
	public virtual bool OCMJBFODDAP()
	{
		return !base.NNDGHFOLJIB() || KFMJHOMNDGG() == null;
	}

	[SpecialName]
	public virtual Vector3 ELAFOGBJLGP()
	{
		return base.PBFDGDPLFKN() - base.transform.forward * 592f;
	}

	protected virtual void HIGCNIEAMBN()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-12);
		EMKAJOADOIH(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Tower | LJGGJMAFEBN.Minigunner);
	}

	public void KMACPOKFAMJ(Turret KAEAMDOJMIF)
	{
		BDJHIEOAAAK(KAEAMDOJMIF);
		OCGKHNOJBKH().Killed += ELPONKHMLEB;
	}

	[SpecialName]
	public void FKFMBFDOFJI(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HCFOBMJHKAL(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public Turret JDPBNCDHOHB()
	{
		return IBBCIFFPJAO;
	}

	private void JAMIHGBCIHC(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		JDPBNCDHOHB().Killed -= NPDPBNHBKLE;
		if (MAIPDGCABNL == PJCEMFLNDHJ())
		{
			LGLNADBCAIE(null);
		}
	}

	[SpecialName]
	public virtual bool CLPLMEOABLL()
	{
		return base.JKJBGIGAKIN() && KFMJHOMNDGG() == null;
	}

	public void SetTurret(Turret KAEAMDOJMIF)
	{
		turret = KAEAMDOJMIF;
		turret.Killed += JOPEIBAGHPA;
	}

	[SpecialName]
	public virtual bool FCCBNBLBELF()
	{
		return base.PKKBHKIOOFN() && FOJBCKOGLFC() == null;
	}

	private void PLMLBGMDDKE(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
	}

	public void BDCGAPDBBMF(Turret KAEAMDOJMIF)
	{
		LPEIFMNDKMO(KAEAMDOJMIF);
		FOJBCKOGLFC().Killed += DKNCMDDNBBA;
	}

	private void PGEELGDLFEN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		JDPBNCDHOHB().Killed -= NOHFAHCNHJC;
		if (MAIPDGCABNL == BGMJGFBBHHB())
		{
			PJNJMALMNLI(null);
		}
	}

	private void PLNPLCFLCME(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		BGMJGFBBHHB().Killed -= NOHFAHCNHJC;
		if (MAIPDGCABNL == KFMJHOMNDGG())
		{
			BDJHIEOAAAK(null);
		}
	}

	[SpecialName]
	public Vector3 NHFPMIOIOKK()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(MGPNABOBKFP() + base.transform.forward * 712f, out hit, 1481f, 0);
		return hit.position;
	}

	[SpecialName]
	public override bool MMDCNGCOLEP()
	{
		return base.JKJBGIGAKIN() && KFMJHOMNDGG() == null;
	}

	[SpecialName]
	public Turret LLGKNOKJINJ()
	{
		return IBBCIFFPJAO;
	}

	private void OKBMOMIIFLF()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 359f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	private void OBGEOOCAJFN(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
	}

	public void GNGHFDLAJKP(Turret KAEAMDOJMIF)
	{
		ALAENENKGIO(KAEAMDOJMIF);
		PJCEMFLNDHJ().Killed += JAMIHGBCIHC;
	}

	public void HHBHFLLCJNL(Turret KAEAMDOJMIF)
	{
		AOFKHJOMEAG(KAEAMDOJMIF);
		FOJBCKOGLFC().Killed += OJGBCJPAKKN;
	}

	private void DMMNDFHGEJJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 945f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public Vector3 GICNKNNJIHC()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(PFOBADFGAKF() + base.transform.forward * 904f, out hit, 502f, 1);
		return hit.position;
	}

	[SpecialName]
	public virtual bool LEKDNKHPMHO()
	{
		return !base.MMDCNGCOLEP() || LLGKNOKJINJ() == null;
	}

	[SpecialName]
	public virtual bool KJBIGCNLFDE()
	{
		return base.OAPIGEDOKEO() && turret == null;
	}

	private void MJHIKNKFDOL(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		LLGKNOKJINJ().Killed -= MJHIKNKFDOL;
		if (MAIPDGCABNL == PJCEMFLNDHJ())
		{
			PHAEKHDENNL(null);
		}
	}

	private void EKEIOPPDMMA(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		JDPBNCDHOHB().Killed -= MJHIKNKFDOL;
		if (MAIPDGCABNL == JDPBNCDHOHB())
		{
			CCFHNLHHKEC(null);
		}
	}

	protected override void IODPOHKAKNN()
	{
		CADJAJCEFCF();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)105;
		KMPIAKMBIFL(~(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Minigunner));
	}

	private void JBCHDECFPJL()
	{
		if (KFMJHOMNDGG() != null)
		{
			BGMJGFBBHHB().Killed -= PGEELGDLFEN;
			ADLGMJJAKLM(null);
		}
	}

	[SpecialName]
	public Vector3 GJHBPMDNBPB()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(PBFDGDPLFKN() + base.transform.forward * 1408f, out hit, 482f, 0);
		return hit.position;
	}

	[SpecialName]
	public virtual Vector3 LFKGIDJKKKO()
	{
		return base.MOOGMFPMKEM() - base.transform.forward * 1202f;
	}

	[SpecialName]
	public virtual bool EFJPNJGDAAP()
	{
		return !base.OAPIGEDOKEO() || PJCEMFLNDHJ() == null;
	}

	private void OGNMLLBAOBM()
	{
		if (JDPBNCDHOHB() != null)
		{
			KFMJHOMNDGG().Killed -= DKNCMDDNBBA;
			FCNADCPPIAB(null);
		}
	}

	[SpecialName]
	public virtual Vector3 CAHJCMKIKPN()
	{
		return base.KOFFAHEAHEN() - base.transform.forward * 1019f;
	}

	[SpecialName]
	public void AOFKHJOMEAG(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	private void NOHFAHCNHJC(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		KFMJHOMNDGG().Killed -= ACGPFADICLF;
		if (MAIPDGCABNL == KFMJHOMNDGG())
		{
			HFBAFCIOPCO(null);
		}
	}

	public void CDHPJCCBCFM(Turret KAEAMDOJMIF)
	{
		LGLNADBCAIE(KAEAMDOJMIF);
		OCGKHNOJBKH().Killed += ELPONKHMLEB;
	}

	private void MGCGEMCAKLM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 589f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	private void ELOPJFNLPMG(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		turret.Killed -= PLNPLCFLCME;
		if (MAIPDGCABNL == PJCEMFLNDHJ())
		{
			CCFHNLHHKEC(null);
		}
	}

	private void EHOEGPBDNAL()
	{
		if (PJCEMFLNDHJ() != null)
		{
			PJCEMFLNDHJ().Killed -= KLJPJMGCIAI;
			LIFGDBPMFFL(null);
		}
	}

	[SpecialName]
	public void LPEIFMNDKMO(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public Turret OCGKHNOJBKH()
	{
		return IBBCIFFPJAO;
	}

	[SpecialName]
	public virtual bool BNHIICPIFDN()
	{
		return base.OAPIGEDOKEO() && BGMJGFBBHHB() == null;
	}

	[SpecialName]
	public void LGLNADBCAIE(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public void CCFHNLHHKEC(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public void ECCEPPHHEKM(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	private void PICNHMGNLIE(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
	}

	[SpecialName]
	public virtual Vector3 LCJNIGELGII()
	{
		return base.position - base.transform.forward * 1697f;
	}

	[SpecialName]
	public virtual bool FMHNNBOIDNH()
	{
		return !base.PKKBHKIOOFN() || OCGKHNOJBKH() == null;
	}

	private void CIFPKABLIAP(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
	}

	private void FPNFLFCGEGN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 1530f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public Turret KFMJHOMNDGG()
	{
		return IBBCIFFPJAO;
	}

	protected override void EALPHOPMAMP()
	{
		base.EALPHOPMAMP();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-59);
		EMKAJOADOIH(~(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Swat));
	}

	private void OCKJKHIDPMB()
	{
		if (FOJBCKOGLFC() != null)
		{
			FOJBCKOGLFC().Killed -= EMCPHLHIJAB;
			PJNJMALMNLI(null);
		}
	}

	private void NDDIGLCJGOE()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 75f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public Vector3 AFGKCPHEHHO()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(FGKJILDKPHC() + base.transform.forward * 1133f, out hit, 1719f, 0);
		return hit.position;
	}

	private void KLJPJMGCIAI(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		OCGKHNOJBKH().Killed -= PGEELGDLFEN;
		if (MAIPDGCABNL == BGMJGFBBHHB())
		{
			AOFKHJOMEAG(null);
		}
	}

	[SpecialName]
	public void FCNADCPPIAB(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	public void DKKEPMKNCDJ(Turret KAEAMDOJMIF)
	{
		EDPHNBFHPPD(KAEAMDOJMIF);
		BGMJGFBBHHB().Killed += EMCPHLHIJAB;
	}

	[SpecialName]
	public Vector3 MLNMDINJBNN()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(MOOGMFPMKEM() + base.transform.forward * 706f, out hit, 1093f, 1);
		return hit.position;
	}

	[SpecialName]
	public void LIFGDBPMFFL(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool EFBDPBMFMPM()
	{
		return !base.isFree || KFMJHOMNDGG() == null;
	}

	private void ELPONKHMLEB(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		JDPBNCDHOHB().Killed -= PLNPLCFLCME;
		if (MAIPDGCABNL == OCGKHNOJBKH())
		{
			LGLNADBCAIE(null);
		}
	}

	[SpecialName]
	public virtual bool PAHILLELBJO()
	{
		return !base.MMDCNGCOLEP() || FOJBCKOGLFC() == null;
	}

	private void GADEJINLIDD()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 678f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public virtual bool MAFMHNOCOPF()
	{
		return base.JCOPEJOIIIH() && PJCEMFLNDHJ() == null;
	}

	[SpecialName]
	public Vector3 MEGDGLGKDAK()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(MGPNABOBKFP() + base.transform.forward * 85f, out hit, 827f, 1);
		return hit.position;
	}

	[SpecialName]
	public Vector3 FNCPBPBPEEG()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(PBFDGDPLFKN() + base.transform.forward * 21f, out hit, 1710f, 1);
		return hit.position;
	}

	public void NOLBGMCKALF(Turret KAEAMDOJMIF)
	{
		EDPHNBFHPPD(KAEAMDOJMIF);
		FOJBCKOGLFC().Killed += OJGBCJPAKKN;
	}

	[SpecialName]
	public void ALAENENKGIO(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	private void JOPEIBAGHPA(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		turret.Killed -= JOPEIBAGHPA;
		if (MAIPDGCABNL == turret)
		{
			turret = null;
		}
	}

	[SpecialName]
	public Turret FOJBCKOGLFC()
	{
		return IBBCIFFPJAO;
	}

	[SpecialName]
	public override Vector3 FGKJILDKPHC()
	{
		return base.PFOBADFGAKF() - base.transform.forward * 1888f;
	}

	public void ECPFIBLDNCM(Turret KAEAMDOJMIF)
	{
		ADLGMJJAKLM(KAEAMDOJMIF);
		OCGKHNOJBKH().Killed += EMCPHLHIJAB;
	}

	[SpecialName]
	public void EDPHNBFHPPD(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	private void MAKPKDNNJKG()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 782f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	[SpecialName]
	public Turret BGMJGFBBHHB()
	{
		return IBBCIFFPJAO;
	}

	[SpecialName]
	public void BDJHIEOAAAK(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual Vector3 LNINNFNKEEM()
	{
		return base.KOFFAHEAHEN() - base.transform.forward * 1857f;
	}

	private void OnDisable()
	{
		if (turret != null)
		{
			turret.Killed -= JOPEIBAGHPA;
			turret = null;
		}
	}

	protected virtual void EEMLMJCHKLM()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = (EnemyController.AJGFGCHCAPA)(-41);
		NGCBJNCNCCM(~(LJGGJMAFEBN.Corner | LJGGJMAFEBN.Car | LJGGJMAFEBN.Helicopter | LJGGJMAFEBN.Swat | LJGGJMAFEBN.Minigunner));
	}

	[SpecialName]
	public void PJNJMALMNLI(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	[SpecialName]
	public void PHAEKHDENNL(Turret IDEBKDPMPGM)
	{
		IBBCIFFPJAO = IDEBKDPMPGM;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.15f);
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine(base.transform.position, base.transform.position);
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.EngineerTurret;
		base.enemyPointType = LJGGJMAFEBN.EngineerTurret;
	}

	private void ACGPFADICLF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		JDPBNCDHOHB().Killed -= EKEIOPPDMMA;
		if (MAIPDGCABNL == turret)
		{
			LIFGDBPMFFL(null);
		}
	}

	private void NPDPBNHBKLE(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		KFMJHOMNDGG().Killed -= DKNCMDDNBBA;
		if (MAIPDGCABNL == LLGKNOKJINJ())
		{
			AOFKHJOMEAG(null);
		}
	}

	public void MKJGIKMBIMK(Turret KAEAMDOJMIF)
	{
		LGLNADBCAIE(KAEAMDOJMIF);
		OCGKHNOJBKH().Killed += MJHIKNKFDOL;
	}

	[SpecialName]
	public virtual Vector3 OHHAFMPKOOA()
	{
		return base.KOFFAHEAHEN() - base.transform.forward * 1117f;
	}

	[SpecialName]
	public virtual Vector3 GMIDPNGNKNK()
	{
		return base.FGKJILDKPHC() - base.transform.forward * 293f;
	}

	private void EMCPHLHIJAB(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		JDPBNCDHOHB().Killed -= PLNPLCFLCME;
		if (MAIPDGCABNL == LLGKNOKJINJ())
		{
			ALAENENKGIO(null);
		}
	}

	public void APOACHELGPE(Turret KAEAMDOJMIF)
	{
		HFBAFCIOPCO(KAEAMDOJMIF);
		FOJBCKOGLFC().Killed += JAMIHGBCIHC;
	}

	[SpecialName]
	public Vector3 JJDAEPMBKEB()
	{
		NavMeshHit hit;
		NavMesh.SamplePosition(PBFDGDPLFKN() + base.transform.forward * 187f, out hit, 1513f, 1);
		return hit.position;
	}
}
