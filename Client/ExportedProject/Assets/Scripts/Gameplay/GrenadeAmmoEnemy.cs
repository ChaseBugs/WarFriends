using System.Runtime.CompilerServices;
using UnityEngine;

public class GrenadeAmmoEnemy : GrenadeAmmo
{
	private DestroyableObject FFOAABONJNO;

	private HudObjectIndicator ALGDKMOMNML;

	private bool BFKBHKPKJCP;

	private bool IGLJFDHFLEG;

	public bool CanThrowAway
	{
		get
		{
			return BFKBHKPKJCP;
		}
		set
		{
			if (value != BFKBHKPKJCP)
			{
				BFKBHKPKJCP = value;
				ALGDKMOMNML.Show(BFKBHKPKJCP);
			}
		}
	}

	protected void HNOBCHFHPNF()
	{
		if (IFDEKAFNIIF() != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(KECCEOEBJNM().fraction);
			LIDKCFEJMDF(!(Vector3.Distance(base.transform.position, enemyOf.transform.position) < 646f) || !(enemyOf == PlayerController.OGMBJPKOPCB) || !IGLJFDHFLEG || !(EFGNPJONPCN().KFEBGOKJGGH > 1424f) || !GBJKONGOBBO.exploded);
		}
	}

	private void PFIEEHDKOIK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.enabled && GBJKONGOBBO != null && GBJKONGOBBO.LAADDLGBFIG.isMine)
		{
			GBJKONGOBBO.Explode();
		}
	}

	protected virtual void GDDCEHOJCEM()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += EFMEDNFKLKH;
		FFOAABONJNO.AEJBIHBEOCP = true;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	public override void AFPAPHKGPOB()
	{
		FFOAABONJNO.NGNPMPGIAGP();
		KDFAMFJJPHF(IDEBKDPMPGM: true);
		StopAllCoroutines();
		IGLJFDHFLEG = false;
	}

	private void LNPDCGLGKJC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.enabled && GBJKONGOBBO != null && GBJKONGOBBO.LAADDLGBFIG.isMine)
		{
			GBJKONGOBBO.Explode();
		}
	}

	private void HAIHAKAEDAG(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.enabled && GBJKONGOBBO != null && GBJKONGOBBO.LAADDLGBFIG.isMine)
		{
			GBJKONGOBBO.Explode();
		}
	}

	protected void JAFBNNAACCL()
	{
		if (HINMGJGCOJC() != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(KECCEOEBJNM().fraction);
			CanThrowAway = Vector3.Distance(base.transform.position, enemyOf.transform.position) < 1163f && enemyOf == PlayerController.OGMBJPKOPCB && IGLJFDHFLEG && JGAEFCIINCA().KFEBGOKJGGH > 555f && !GBJKONGOBBO.JOHACOGBOIC();
		}
	}

	public virtual void HDOFLBINJNE()
	{
		base.MBEBBBINODD();
		IGLJFDHFLEG = true;
	}

	public override void Init()
	{
		FFOAABONJNO.RefillOffline();
		CanThrowAway = false;
		StopAllCoroutines();
		IGLJFDHFLEG = false;
	}

	public override void ExplodeImplementation(Vector3 MPHCNMDIPAI)
	{
		CanThrowAway = false;
		FFOAABONJNO.Disable();
		base.ExplodeImplementation(MPHCNMDIPAI);
	}

	public virtual void MIKPMMAIJEC(Vector3 MPHCNMDIPAI)
	{
		MHAPMINFIJG(IDEBKDPMPGM: false);
		FFOAABONJNO.JHNIBNBEGFJ();
		CBKAFECJMDJ(MPHCNMDIPAI);
	}

	public virtual void AGEBGCEEABL(Vector3 MPHCNMDIPAI)
	{
		LIDKCFEJMDF(IDEBKDPMPGM: true);
		FFOAABONJNO.JHNIBNBEGFJ();
		IDIKOOOGBJG(MPHCNMDIPAI);
	}

	public virtual void KJOLOGIKDFD()
	{
		base.EHCCKIKLGFL();
		IGLJFDHFLEG = true;
	}

	protected virtual void ECCECGGCMHG()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += LFODFFCDKDC;
		FFOAABONJNO.AEJBIHBEOCP = false;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	public override void ExplodeRPCImplementation(Vector3 MPHCNMDIPAI)
	{
		CanThrowAway = false;
		FFOAABONJNO.Disable();
		base.ExplodeRPCImplementation(MPHCNMDIPAI);
	}

	private void EFMEDNFKLKH(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.enabled && GBJKONGOBBO != null && GBJKONGOBBO.LAADDLGBFIG.isMine)
		{
			GBJKONGOBBO.Explode();
		}
	}

	public virtual void BNNAJCEBPBP(Vector3 MPHCNMDIPAI)
	{
		LIDKCFEJMDF(IDEBKDPMPGM: false);
		FFOAABONJNO.Disable();
		GHHILKKNHIM(MPHCNMDIPAI);
	}

	public virtual void IGMPMILOAFB()
	{
		FFOAABONJNO.NGNPMPGIAGP();
		KDFAMFJJPHF(IDEBKDPMPGM: false);
		StopAllCoroutines();
		IGLJFDHFLEG = true;
	}

	private void LFODFFCDKDC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.enabled && GBJKONGOBBO != null && GBJKONGOBBO.LAADDLGBFIG.isMine)
		{
			GBJKONGOBBO.Explode();
		}
	}

	[SpecialName]
	public bool BIGGFCMHHJN()
	{
		return BFKBHKPKJCP;
	}

	[SpecialName]
	public void HKJJDCNDBEJ(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BFKBHKPKJCP)
		{
			BFKBHKPKJCP = IDEBKDPMPGM;
			ALGDKMOMNML.DJNMPLKPENF(BFKBHKPKJCP);
		}
	}

	private void BDJHMGCFJBA(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.enabled && GBJKONGOBBO != null && GBJKONGOBBO.LAADDLGBFIG.isMine)
		{
			GBJKONGOBBO.Explode();
		}
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		FFOAABONJNO.AEJBIHBEOCP = true;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	public virtual void ADBJFOPLKOA(Vector3 MPHCNMDIPAI)
	{
		HKJJDCNDBEJ(IDEBKDPMPGM: false);
		FFOAABONJNO.JHNIBNBEGFJ();
		GAMPHKBAFJH(MPHCNMDIPAI);
	}

	public virtual void BNMNKIPAOJL()
	{
		base.ICJCKAJCKIN();
		IGLJFDHFLEG = true;
	}

	[SpecialName]
	public void MHAPMINFIJG(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BFKBHKPKJCP)
		{
			BFKBHKPKJCP = IDEBKDPMPGM;
			ALGDKMOMNML.Show(BFKBHKPKJCP);
		}
	}

	[SpecialName]
	public bool OGMLMJNPAEJ()
	{
		return BFKBHKPKJCP;
	}

	public virtual void LHDDGJDEDIO()
	{
		base.AJNDAIPBBDC();
		IGLJFDHFLEG = true;
	}

	[SpecialName]
	public void HAKOJCFMCPF(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BFKBHKPKJCP)
		{
			BFKBHKPKJCP = IDEBKDPMPGM;
			ALGDKMOMNML.Show(BFKBHKPKJCP);
		}
	}

	private void BFHJDJCFBAI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.enabled && GBJKONGOBBO != null && GBJKONGOBBO.LAADDLGBFIG.isMine)
		{
			GBJKONGOBBO.Explode();
		}
	}

	public override void EHCCKIKLGFL()
	{
		base.MBEBBBINODD();
		IGLJFDHFLEG = true;
	}

	public override void CGPOEALBEFD()
	{
		base.AJNDAIPBBDC();
		IGLJFDHFLEG = false;
	}

	public override void PLIJJCHDIGM(Vector3 MPHCNMDIPAI)
	{
		CanThrowAway = true;
		FFOAABONJNO.Disable();
		base.PLIJJCHDIGM(MPHCNMDIPAI);
	}

	protected virtual void HCNOHLLOGBO()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += EFMEDNFKLKH;
		FFOAABONJNO.AEJBIHBEOCP = false;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	public virtual void IBEMPELBPLG()
	{
		base.MBEBBBINODD();
		IGLJFDHFLEG = true;
	}

	public override void GroundHitted()
	{
		base.GroundHitted();
		IGLJFDHFLEG = true;
	}

	public virtual void HJLEMLFPJCG(Vector3 MPHCNMDIPAI)
	{
		HKJJDCNDBEJ(IDEBKDPMPGM: true);
		FFOAABONJNO.Disable();
		GHHILKKNHIM(MPHCNMDIPAI);
	}

	[SpecialName]
	public bool JHNGCNPJCGG()
	{
		return BFKBHKPKJCP;
	}

	public virtual void BDOAKNIHNLJ()
	{
		FFOAABONJNO.NGNPMPGIAGP();
		CanThrowAway = true;
		StopAllCoroutines();
		IGLJFDHFLEG = true;
	}

	[SpecialName]
	public void ACCEONBPDDB(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BFKBHKPKJCP)
		{
			BFKBHKPKJCP = IDEBKDPMPGM;
			ALGDKMOMNML.Show(BFKBHKPKJCP);
		}
	}

	public virtual void MGFLEBJNIHA()
	{
		base.EHCCKIKLGFL();
		IGLJFDHFLEG = true;
	}

	public virtual void NBMIAEFGFOL(Vector3 MPHCNMDIPAI)
	{
		LIDKCFEJMDF(IDEBKDPMPGM: true);
		FFOAABONJNO.Disable();
		CCHINPKCNFN(MPHCNMDIPAI);
	}

	public virtual void EOGNPNBEKED()
	{
		base.ICJCKAJCKIN();
		IGLJFDHFLEG = false;
	}

	protected override void Awake()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		FFOAABONJNO.AEJBIHBEOCP = true;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	[SpecialName]
	public bool MDLELJPOBMA()
	{
		return BFKBHKPKJCP;
	}

	protected void JBGDAOIDBGF()
	{
		if (FKMMDFBHHIA() != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(HINMGJGCOJC().fraction);
			HKJJDCNDBEJ(Vector3.Distance(base.transform.position, enemyOf.transform.position) < 974f && enemyOf == PlayerController.OGMBJPKOPCB && IGLJFDHFLEG && EBJGPMCLNAI().KFEBGOKJGGH > 1135f && GBJKONGOBBO.exploded);
		}
	}

	public virtual void NCHGDGBHDKA(Vector3 MPHCNMDIPAI)
	{
		ACCEONBPDDB(IDEBKDPMPGM: false);
		FFOAABONJNO.JHNIBNBEGFJ();
		base.PLIJJCHDIGM(MPHCNMDIPAI);
	}

	[SpecialName]
	public void LIDKCFEJMDF(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BFKBHKPKJCP)
		{
			BFKBHKPKJCP = IDEBKDPMPGM;
			ALGDKMOMNML.Show(BFKBHKPKJCP);
		}
	}

	[SpecialName]
	public bool IJAJAJDPNNM()
	{
		return BFKBHKPKJCP;
	}

	public virtual void MFDFHMBJALJ()
	{
		base.ICJCKAJCKIN();
		IGLJFDHFLEG = false;
	}

	public virtual void DGEPGLMKHHN()
	{
		base.GroundHitted();
		IGLJFDHFLEG = false;
	}

	public virtual void ABPDKPKJDIA()
	{
		FFOAABONJNO.RefillOffline();
		KDFAMFJJPHF(IDEBKDPMPGM: true);
		StopAllCoroutines();
		IGLJFDHFLEG = true;
	}

	protected void LHJAGNOOBAF()
	{
		if (KECCEOEBJNM() != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(FKMMDFBHHIA().fraction);
			HKJJDCNDBEJ(Vector3.Distance(base.transform.position, enemyOf.transform.position) < 1625f && enemyOf == PlayerController.OGMBJPKOPCB && IGLJFDHFLEG && PEDNMLDCPNL().KFEBGOKJGGH > 1572f && GBJKONGOBBO.exploded);
		}
	}

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += BDJHMGCFJBA;
		FFOAABONJNO.AEJBIHBEOCP = false;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	[SpecialName]
	public void KDFAMFJJPHF(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BFKBHKPKJCP)
		{
			BFKBHKPKJCP = IDEBKDPMPGM;
			ALGDKMOMNML.GLMKGLKCDAL(BFKBHKPKJCP);
		}
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		FFOAABONJNO.AEJBIHBEOCP = false;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	public override void AJNDAIPBBDC()
	{
		base.MBEBBBINODD();
		IGLJFDHFLEG = true;
	}

	protected virtual void EJNJCILPBEC()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += LJMBADNBMEA;
		FFOAABONJNO.AEJBIHBEOCP = false;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	public override void BGJHLMOBFPP(Vector3 MPHCNMDIPAI)
	{
		HAKOJCFMCPF(IDEBKDPMPGM: true);
		FFOAABONJNO.Disable();
		IFIOMKFEKJM(MPHCNMDIPAI);
	}

	protected void Update()
	{
		if (base.MHAMIMGNJND != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(base.MHAMIMGNJND.fraction);
			CanThrowAway = Vector3.Distance(base.transform.position, enemyOf.transform.position) < 2f && enemyOf == PlayerController.OGMBJPKOPCB && IGLJFDHFLEG && base.EIIMIEGIOPN.KFEBGOKJGGH > 0.1f && !GBJKONGOBBO.exploded;
		}
	}

	[SpecialName]
	public void KBPPKIFCDKN(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BFKBHKPKJCP)
		{
			BFKBHKPKJCP = IDEBKDPMPGM;
			ALGDKMOMNML.Show(BFKBHKPKJCP);
		}
	}

	[SpecialName]
	public bool JHMNIAHPOLB()
	{
		return BFKBHKPKJCP;
	}

	public virtual void CHDKNGLHLJN()
	{
		base.MBEBBBINODD();
		IGLJFDHFLEG = false;
	}

	public virtual void KOMNFNDHNAN()
	{
		base.CGPOEALBEFD();
		IGLJFDHFLEG = true;
	}

	public virtual void GCDKIFFLHGG()
	{
		base.AJNDAIPBBDC();
		IGLJFDHFLEG = false;
	}

	public override void ACFKLINFPHB(Vector3 MPHCNMDIPAI)
	{
		CanThrowAway = false;
		FFOAABONJNO.JHNIBNBEGFJ();
		CKOMABNMJPE(MPHCNMDIPAI);
	}

	protected virtual void ONBDJLDJDCH()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += PFIEEHDKOIK;
		FFOAABONJNO.AEJBIHBEOCP = true;
		ALGDKMOMNML = GetComponent<HudObjectIndicator>();
	}

	public virtual void AOCEDKCANFP()
	{
		FFOAABONJNO.NGNPMPGIAGP();
		ACCEONBPDDB(IDEBKDPMPGM: true);
		StopAllCoroutines();
		IGLJFDHFLEG = false;
	}

	protected void GEICOLPLFDL()
	{
		if (HINMGJGCOJC() != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(KECCEOEBJNM().fraction);
			LIDKCFEJMDF(!(Vector3.Distance(base.transform.position, enemyOf.transform.position) < 530f) || !(enemyOf == PlayerController.OGMBJPKOPCB) || !IGLJFDHFLEG || !(JEFLHHOPLFH().KFEBGOKJGGH > 1049f) || GBJKONGOBBO.exploded);
		}
	}

	public virtual void KGBPCEIFGGP()
	{
		base.EHCCKIKLGFL();
		IGLJFDHFLEG = false;
	}

	public virtual void EKAHDEBEBEG(Vector3 MPHCNMDIPAI)
	{
		LIDKCFEJMDF(IDEBKDPMPGM: false);
		FFOAABONJNO.Disable();
		NEHPAOKBAAE(MPHCNMDIPAI);
	}

	public virtual void DBJKLHGNDPJ(Vector3 MPHCNMDIPAI)
	{
		KDFAMFJJPHF(IDEBKDPMPGM: false);
		FFOAABONJNO.Disable();
		IFIOMKFEKJM(MPHCNMDIPAI);
	}

	private void LJMBADNBMEA(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.enabled && GBJKONGOBBO != null && GBJKONGOBBO.LAADDLGBFIG.isMine)
		{
			GBJKONGOBBO.Explode();
		}
	}

	public virtual void JLDLGFNLKDK(Vector3 MPHCNMDIPAI)
	{
		KDFAMFJJPHF(IDEBKDPMPGM: false);
		FFOAABONJNO.JHNIBNBEGFJ();
		BBOHBMPDEFJ(MPHCNMDIPAI);
	}

	protected void BOPGJFGMNJM()
	{
		if (FKMMDFBHHIA() != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(KECCEOEBJNM().fraction);
			HAKOJCFMCPF(!(Vector3.Distance(base.transform.position, enemyOf.transform.position) < 1508f) || !(enemyOf == PlayerController.OGMBJPKOPCB) || !IGLJFDHFLEG || !(base.EIIMIEGIOPN.KFEBGOKJGGH > 836f) || !GBJKONGOBBO.exploded);
		}
	}

	public virtual void JJHOHGIHEFN(Vector3 MPHCNMDIPAI)
	{
		KDFAMFJJPHF(IDEBKDPMPGM: true);
		FFOAABONJNO.JHNIBNBEGFJ();
		FKCNPCOFNEG(MPHCNMDIPAI);
	}

	protected void OCBLKIFKJEG()
	{
		if (base.MHAMIMGNJND != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(base.MHAMIMGNJND.fraction);
			KBPPKIFCDKN(Vector3.Distance(base.transform.position, enemyOf.transform.position) < 341f && enemyOf == PlayerController.OGMBJPKOPCB && IGLJFDHFLEG && base.EIIMIEGIOPN.KFEBGOKJGGH > 12f && !GBJKONGOBBO.JOHACOGBOIC());
		}
	}

	[SpecialName]
	public bool LEBEFKJLMFI()
	{
		return BFKBHKPKJCP;
	}
}
