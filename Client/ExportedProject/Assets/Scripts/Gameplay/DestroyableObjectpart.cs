using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyableObjectpart : DestroyableObject
{
	[FormerlySerializedAs("MJGFPJDHDDK")]
	public DestroyableObjectMultipleParts JPPDEOKJBLO;

	[FormerlySerializedAs("LKCGCNADMKN")]
	public float CMFNOLDCGCL = 1f;

	[FormerlySerializedAs("EPNGMAHENPA")]
	public byte DFHAAIFFLOE;

	private float HHANBLEGPNN = 1f;

	public override bool destroyableByBonusBox => JPPDEOKJBLO.destroyableByBonusBox;

	public override KMHCMCBGFFC owner
	{
		get
		{
			return JPPDEOKJBLO.owner;
		}
		set
		{
			JPPDEOKJBLO.owner = value;
		}
	}

	public override float health
	{
		get
		{
			if (JPPDEOKJBLO == null)
			{
				return 0f;
			}
			return JPPDEOKJBLO.health;
		}
	}

	public override float healthRatio
	{
		get
		{
			if (JPPDEOKJBLO == null)
			{
				return 0f;
			}
			return JPPDEOKJBLO.healthRatio;
		}
		set
		{
			if (JPPDEOKJBLO != null)
			{
				JPPDEOKJBLO.healthRatio = value;
			}
		}
	}

	public override DestroyableObject mainDestroyableObject => JPPDEOKJBLO;

	[SpecialName]
	public virtual float ADDIEAAJJKI()
	{
		if (JPPDEOKJBLO == null)
		{
			return 141f;
		}
		return JPPDEOKJBLO.health;
	}

	[SpecialName]
	public virtual float OAEOLOAADJE()
	{
		if (JPPDEOKJBLO == null)
		{
			return 474f;
		}
		return JPPDEOKJBLO.health;
	}

	[SpecialName]
	public virtual float GLLIGGBAJJK()
	{
		if (JPPDEOKJBLO == null)
		{
			return 1817f;
		}
		return JPPDEOKJBLO.health;
	}

	public virtual void GOEFKFPEGHB(HINJJOAJAOA LJAMNPJAELB)
	{
		JPPDEOKJBLO.PlaySound(LJAMNPJAELB);
	}

	[SpecialName]
	public virtual DestroyableObject CHHGEIONIDE()
	{
		return JPPDEOKJBLO;
	}

	public void DKPMEPAPNFN()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	public virtual void AGLLMEDFAKM(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.JPBFBBMCFPI(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	[SpecialName]
	public virtual bool KDCJHIKBIPH()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	[SpecialName]
	public virtual DestroyableObject CJGOHFONOLH()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual float MHPEDDBEPNI()
	{
		if (JPPDEOKJBLO == null)
		{
			return 639f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	public virtual void ACNLKGCAFNA(HINJJOAJAOA LJAMNPJAELB)
	{
		JPPDEOKJBLO.PlaySound(LJAMNPJAELB);
	}

	public virtual bool DLBBFINHOPI(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		KMJKKNFDFMM.EPDELOGPNAC *= CMFNOLDCGCL;
		KMJKKNFDFMM.MEFOHLAIBFA = DFHAAIFFLOE;
		return JPPDEOKJBLO.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public virtual bool NIOIDGAJNLI()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	[SpecialName]
	public virtual float DNDIBNEFCGH()
	{
		if (JPPDEOKJBLO == null)
		{
			return 812f;
		}
		return JPPDEOKJBLO.health;
	}

	protected virtual void BKNKFFEHJOA()
	{
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		CDKBFIGEBOA = base.transform;
		HHANBLEGPNN = CMFNOLDCGCL;
	}

	[SpecialName]
	public virtual DestroyableObject BHEDMEIBDMI()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual float LDDBALDCBKA()
	{
		if (JPPDEOKJBLO == null)
		{
			return 792f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	[SpecialName]
	public virtual bool LJFOBGABEHM()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	public void EKKKAFEPBMP()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	public virtual void KMAOEMLILIG(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.Shoot(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	public void AKGNIIJIPCE()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	[SpecialName]
	public virtual KMHCMCBGFFC IEBLLBMGNLM()
	{
		return JPPDEOKJBLO.owner;
	}

	[SpecialName]
	public virtual void LIONCCBLFHK(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.healthRatio = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public virtual void HDLIPABHDLD(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.healthRatio = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public virtual DestroyableObject KCJHICDLJBK()
	{
		return JPPDEOKJBLO;
	}

	public virtual bool HGDGIONNEPF(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		KMJKKNFDFMM.EPDELOGPNAC *= CMFNOLDCGCL;
		KMJKKNFDFMM.MEFOHLAIBFA = DFHAAIFFLOE;
		return JPPDEOKJBLO.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public void IBIIKCGAAAH()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	[SpecialName]
	public virtual void BFGDIAMFOLM(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.healthRatio = IDEBKDPMPGM;
		}
	}

	public virtual bool PGEAFGMPNHM(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		KMJKKNFDFMM.EPDELOGPNAC *= CMFNOLDCGCL;
		KMJKKNFDFMM.MEFOHLAIBFA = DFHAAIFFLOE;
		return JPPDEOKJBLO.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public override bool DoDamage(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		KMJKKNFDFMM.EPDELOGPNAC *= CMFNOLDCGCL;
		KMJKKNFDFMM.MEFOHLAIBFA = DFHAAIFFLOE;
		return JPPDEOKJBLO.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public virtual float HBEPDFCMFFI()
	{
		if (JPPDEOKJBLO == null)
		{
			return 826f;
		}
		return JPPDEOKJBLO.health;
	}

	public virtual void DADBKIDCLAI(HINJJOAJAOA LJAMNPJAELB)
	{
		JPPDEOKJBLO.PlaySound(LJAMNPJAELB);
	}

	[SpecialName]
	public virtual bool NDFBFCEOFCE()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	[SpecialName]
	public virtual void BDCBMDJEOMD(KMHCMCBGFFC IDEBKDPMPGM)
	{
		JPPDEOKJBLO.GGMFIDCAFGM(IDEBKDPMPGM);
	}

	public virtual void JCLFDGECKJP(HINJJOAJAOA LJAMNPJAELB)
	{
		JPPDEOKJBLO.PlaySound(LJAMNPJAELB);
	}

	[SpecialName]
	public virtual bool FEMLKMENEND()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	public virtual void MDKGJBLNBIB(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.Shoot(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	[SpecialName]
	public virtual DestroyableObject CINHMCHOHGP()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual void OPCACAKEFBI(KMHCMCBGFFC IDEBKDPMPGM)
	{
		JPPDEOKJBLO.GGMFIDCAFGM(IDEBKDPMPGM);
	}

	[SpecialName]
	public virtual void KEANMHDFBHP(KMHCMCBGFFC IDEBKDPMPGM)
	{
		JPPDEOKJBLO.owner = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual KMHCMCBGFFC ICDODOFCNKM()
	{
		return JPPDEOKJBLO.owner;
	}

	protected virtual void CALILPEEAMB()
	{
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		CDKBFIGEBOA = base.transform;
		HHANBLEGPNN = CMFNOLDCGCL;
	}

	[SpecialName]
	public virtual void GBDLOLCOPDB(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.MNMCGGIINIF(IDEBKDPMPGM);
		}
	}

	[SpecialName]
	public virtual float NNDPIACGFLF()
	{
		if (JPPDEOKJBLO == null)
		{
			return 1746f;
		}
		return JPPDEOKJBLO.health;
	}

	[SpecialName]
	public virtual DestroyableObject GFGPFIMMBDH()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual float AHCOGKHGGAM()
	{
		if (JPPDEOKJBLO == null)
		{
			return 1697f;
		}
		return JPPDEOKJBLO.health;
	}

	public virtual void OJLJHOJEKJF(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.Shoot(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	[SpecialName]
	public virtual float JGDLPLBJGOI()
	{
		if (JPPDEOKJBLO == null)
		{
			return 710f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	[SpecialName]
	public virtual void LCPCCGHDEFF(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.healthRatio = IDEBKDPMPGM;
		}
	}

	public override void Shoot(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.Shoot(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	[SpecialName]
	public virtual DestroyableObject DILNBLCFBJA()
	{
		return JPPDEOKJBLO;
	}

	public virtual void OPGGKNCCHLL(HINJJOAJAOA LJAMNPJAELB)
	{
		JPPDEOKJBLO.PlaySound(LJAMNPJAELB);
	}

	[SpecialName]
	public virtual void OGIGIDKPGOO(KMHCMCBGFFC IDEBKDPMPGM)
	{
		JPPDEOKJBLO.owner = IDEBKDPMPGM;
	}

	protected virtual void PCDHCIDJJOB()
	{
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		CDKBFIGEBOA = base.transform;
		HHANBLEGPNN = CMFNOLDCGCL;
	}

	[SpecialName]
	public virtual bool OFHMCGHAPNE()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	[SpecialName]
	public virtual DestroyableObject DGEELBIKMFD()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual DestroyableObject COKLIJKKANB()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual void JAJLILKICHF(KMHCMCBGFFC IDEBKDPMPGM)
	{
		JPPDEOKJBLO.owner = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void JJFLJJCIMJG(KMHCMCBGFFC IDEBKDPMPGM)
	{
		JPPDEOKJBLO.GGMFIDCAFGM(IDEBKDPMPGM);
	}

	public void NDJKEMBCNOE()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	[SpecialName]
	public virtual bool JDBPGKPHJIG()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	public virtual void HMPDNBABBGN(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.Shoot(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		CDKBFIGEBOA = base.transform;
		HHANBLEGPNN = CMFNOLDCGCL;
	}

	[SpecialName]
	public virtual bool LBPBDOGICCF()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	[SpecialName]
	public virtual DestroyableObject DBHECCJLPGF()
	{
		return JPPDEOKJBLO;
	}

	public void PHEEMPOPIKJ()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	public void JABABMMPCEK()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	public virtual void AAEJHBGOJIF(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.Shoot(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	[SpecialName]
	public virtual void AIOFJHFOBAF(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.healthRatio = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public virtual DestroyableObject HAMJEAIMHKH()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual DestroyableObject PGMHIGJKECG()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual void KCNDMIHGHPA(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.MNMCGGIINIF(IDEBKDPMPGM);
		}
	}

	public void ICAJKMBHEEG()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	[SpecialName]
	public virtual void BLDMHENPCFP(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.MNMCGGIINIF(IDEBKDPMPGM);
		}
	}

	public void EMLDNFFLOMA()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	protected virtual void ECMMDCKONDK()
	{
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		CDKBFIGEBOA = base.transform;
		HHANBLEGPNN = CMFNOLDCGCL;
	}

	[SpecialName]
	public virtual KMHCMCBGFFC FAKEDIJAHCD()
	{
		return JPPDEOKJBLO.owner;
	}

	public void HDOMFGMCHFI()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	[SpecialName]
	public virtual void OCHDOHPLLJJ(float IDEBKDPMPGM)
	{
		if (JPPDEOKJBLO != null)
		{
			JPPDEOKJBLO.healthRatio = IDEBKDPMPGM;
		}
	}

	public virtual void DNDJGFFOLPJ(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.JPBFBBMCFPI(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	[SpecialName]
	public virtual void JNCPEIIPPJK(KMHCMCBGFFC IDEBKDPMPGM)
	{
		JPPDEOKJBLO.owner = IDEBKDPMPGM;
	}

	protected virtual void IEBHCNFALAB()
	{
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		CDKBFIGEBOA = base.transform;
		HHANBLEGPNN = CMFNOLDCGCL;
	}

	public void PMELIFLKFBA()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	public void AKPFNJGDOGC()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	[SpecialName]
	public virtual float JLGPJNJPGPI()
	{
		if (JPPDEOKJBLO == null)
		{
			return 789f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	[SpecialName]
	public virtual DestroyableObject EHIHFEACGOE()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual float PHCBNDNKPPB()
	{
		if (JPPDEOKJBLO == null)
		{
			return 932f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	[SpecialName]
	public virtual bool FBENBGELPDE()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	[SpecialName]
	public virtual float GCIAHDBOJIN()
	{
		if (JPPDEOKJBLO == null)
		{
			return 539f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	[SpecialName]
	public virtual float GKEBLMGODBH()
	{
		if (JPPDEOKJBLO == null)
		{
			return 1501f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	[SpecialName]
	public virtual bool CDGLAOOAHLO()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	[SpecialName]
	public virtual bool IKODJJPKJLK()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	public virtual void ENEGBMEAJDA(HINJJOAJAOA LJAMNPJAELB)
	{
		JPPDEOKJBLO.PlaySound(LJAMNPJAELB);
	}

	[SpecialName]
	public virtual bool JAHPJPBJFLH()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	public virtual void CDOENIPGBBP(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.Shoot(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	[SpecialName]
	public virtual KMHCMCBGFFC HBMHBLPGNBM()
	{
		return JPPDEOKJBLO.owner;
	}

	public virtual bool GLLICNPNBBJ(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		KMJKKNFDFMM.EPDELOGPNAC *= CMFNOLDCGCL;
		KMJKKNFDFMM.MEFOHLAIBFA = DFHAAIFFLOE;
		return JPPDEOKJBLO.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public virtual KMHCMCBGFFC JBNJOILANPJ()
	{
		return JPPDEOKJBLO.owner;
	}

	public virtual bool NOMAAGDOJCN(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		KMJKKNFDFMM.EPDELOGPNAC *= CMFNOLDCGCL;
		KMJKKNFDFMM.MEFOHLAIBFA = DFHAAIFFLOE;
		return JPPDEOKJBLO.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public virtual KMHCMCBGFFC JEENJFCADGI()
	{
		return JPPDEOKJBLO.owner;
	}

	[SpecialName]
	public virtual float MMJMCLHEMBM()
	{
		if (JPPDEOKJBLO == null)
		{
			return 1568f;
		}
		return JPPDEOKJBLO.health;
	}

	[SpecialName]
	public virtual void JJBPCPDKCMH(KMHCMCBGFFC IDEBKDPMPGM)
	{
		JPPDEOKJBLO.GGMFIDCAFGM(IDEBKDPMPGM);
	}

	public virtual void CPIAFFPHGCP(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.JPBFBBMCFPI(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	[SpecialName]
	public virtual float HGGCPPCNOKN()
	{
		if (JPPDEOKJBLO == null)
		{
			return 15f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	public virtual bool CGALOFAKFLP(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		KMJKKNFDFMM.EPDELOGPNAC *= CMFNOLDCGCL;
		KMJKKNFDFMM.MEFOHLAIBFA = DFHAAIFFLOE;
		return JPPDEOKJBLO.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	[SpecialName]
	public virtual bool HLOIKGNHLNJ()
	{
		return JPPDEOKJBLO.destroyableByBonusBox;
	}

	[SpecialName]
	public virtual KMHCMCBGFFC OHFDFGBDBLF()
	{
		return JPPDEOKJBLO.owner;
	}

	public override void PlaySound(HINJJOAJAOA LJAMNPJAELB)
	{
		JPPDEOKJBLO.PlaySound(LJAMNPJAELB);
	}

	protected virtual void IABJJOPLKFF()
	{
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		CDKBFIGEBOA = base.transform;
		HHANBLEGPNN = CMFNOLDCGCL;
	}

	[SpecialName]
	public virtual float BHOMIOLPPCG()
	{
		if (JPPDEOKJBLO == null)
		{
			return 31f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	public virtual void CLEFGKAJLFI(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		HHOCGCLBHKB = JPPDEOKJBLO.HHOCGCLBHKB;
		base.Shoot(CJDCGPMIHEA, DIAKDJLIJAN, LPGMLOCLBGP, AEJJCMHDFBA, ELOOOFODMNP, CAKABHIPCDF, NLJFIIEGHCK);
	}

	protected override void Awake()
	{
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		CDKBFIGEBOA = base.transform;
		HHANBLEGPNN = CMFNOLDCGCL;
	}

	public void ResetWeight()
	{
		CMFNOLDCGCL = HHANBLEGPNN;
	}

	[SpecialName]
	public virtual DestroyableObject FHLGAFLPCKJ()
	{
		return JPPDEOKJBLO;
	}

	[SpecialName]
	public virtual float EGOCHBMGHNN()
	{
		if (JPPDEOKJBLO == null)
		{
			return 253f;
		}
		return JPPDEOKJBLO.healthRatio;
	}

	[SpecialName]
	public virtual DestroyableObject LHOPDAAEMHI()
	{
		return JPPDEOKJBLO;
	}
}
