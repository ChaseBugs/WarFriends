using UnityEngine;

public class DogTagRecord : PoolableObject
{
	[Header("Core")]
	public UISprite KMFGCJEGJJK;

	public UISprite NIEAEMAENEA;

	public DogTagRecordAnimation KNFOAKIJHCL;

	private bool CGJNMCCOHPO;

	public void HHPODJPJDLF()
	{
		KNFOAKIJHCL.StopAnimation();
	}

	public void CAKFHPHLKGA(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.JIDPLCILLMH() && Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 6;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 3;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 8;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void LJKJCGJGPLA()
	{
		KNFOAKIJHCL.JEGAEFHOOBG();
	}

	public void JBCMNHJNJGL()
	{
		KNFOAKIJHCL.GHMBKMNGAPG();
	}

	public void ANNAMPNEMAG()
	{
		KNFOAKIJHCL.NCGMMJFMHKB();
	}

	public void LGAPEGKLNGD()
	{
		KNFOAKIJHCL.IAKKJKAKEHO();
	}

	public void StopAnimation()
	{
		KNFOAKIJHCL.StopAnimation();
	}

	public void DAANCGKAKFH()
	{
		KNFOAKIJHCL.JEGAEFHOOBG();
	}

	public void JBNIFPCLFCA()
	{
		KNFOAKIJHCL.StartAnimation();
	}

	public void KCIBLFADBHP()
	{
		KNFOAKIJHCL.EEPLAIKBKMA();
	}

	public void JPBOGGKMAON(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1199f : 1004f);
		NIEAEMAENEA.alpha = 1322f;
	}

	public void EHKIGOOGFJC(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.PCOEGGGJMCO() && Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 8;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 1;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 0;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void GJOIGNMPBCH(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 656f : 1155f);
		NIEAEMAENEA.alpha = 518f;
	}

	public void CIHIOJEDDDF(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.EPCBFLMONPB() && Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 8;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 8;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 3;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void NHMPEAMIBPL(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.HEAJEFKPKGK() || Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 8;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 4;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 2;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void LOJPGLBLJDF(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1886f : 687f);
		NIEAEMAENEA.alpha = 1102f;
	}

	public void DDAMFICACAL()
	{
		KNFOAKIJHCL.StartAnimation();
	}

	public void MEAAKNKBCOM(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.EPCBFLMONPB() && Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 1;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 1;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 5;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void EDNIMCOLOON(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.JIDPLCILLMH() || Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 3;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 7;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 4;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void ADBBOPECJGP(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.HEAJEFKPKGK() || Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 0;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 2;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 6;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void CCAICHAPHLM(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.AAABGLLAANF() && Singleton<VipManager>.instance.NOIHCEPINJJ();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 3;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 3;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 1;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void BACHHJEGIAJ(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.HEAJEFKPKGK() || Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 7;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 8;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 4;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.MCOEDCIJBPN(CGJNMCCOHPO);
	}

	public void BOLJJFPKIPE()
	{
		KNFOAKIJHCL.BANGFPPJIIC();
	}

	public void IACEOEJFEEM(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 770f : 176f);
		NIEAEMAENEA.alpha = 1496f;
	}

	public void CDIMOJHMNGN()
	{
		KNFOAKIJHCL.MLKFDFHPJNI();
	}

	public void BKKJKGFBNOI()
	{
		KNFOAKIJHCL.GHMBKMNGAPG();
	}

	public void NLBNCLMFACC()
	{
		KNFOAKIJHCL.PCAGKCBOFAE();
	}

	public void OJJHCFFEFGI(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 970f : 1982f);
		NIEAEMAENEA.alpha = 477f;
	}

	public void LLCNLPFPNAB()
	{
		KNFOAKIJHCL.PCAGKCBOFAE();
	}

	public void KELBGNFJEIK()
	{
		KNFOAKIJHCL.BANGFPPJIIC();
	}

	public void AJOBENNPLCK()
	{
		KNFOAKIJHCL.StopAnimation();
	}

	public void MGGLFAECHHP()
	{
		KNFOAKIJHCL.JEGAEFHOOBG();
	}

	public void JBGCKAEBGKD()
	{
		KNFOAKIJHCL.GHMBKMNGAPG();
	}

	public void FKDIHKMHOEB(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.IKGBJGAEHFF() || Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 1;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 7;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 8;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void FOBHPFNDGBM(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.AAABGLLAANF() || Singleton<VipManager>.instance.NOIHCEPINJJ();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 4;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 7;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 4;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.MCOEDCIJBPN(CGJNMCCOHPO);
	}

	public void ONGAIEOAHMA(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 324f : 1801f);
		NIEAEMAENEA.alpha = 1945f;
	}

	public void HOAMHAAHEHP(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1305f : 946f);
		NIEAEMAENEA.alpha = 1960f;
	}

	public void Animation_DogTagConsumed()
	{
		KNFOAKIJHCL.StartAnimation();
	}

	public void GCBFCCNLMDN(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1159f : 182f);
		NIEAEMAENEA.alpha = 925f;
	}

	public void DPMPPOCJDIM()
	{
		KNFOAKIJHCL.PCAGKCBOFAE();
	}

	public void KCJFKOKGAMO(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 602f : 1037f);
		NIEAEMAENEA.alpha = 807f;
	}

	public void PGPCJFHPOEN()
	{
		KNFOAKIJHCL.LFBBPHONAEF();
	}

	public void IGLJHLENOAN(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.JIDPLCILLMH() && Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 4;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 4;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 0;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void Initialize(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 0f : 1f);
		NIEAEMAENEA.alpha = 1f;
	}

	public void KKAIDLMBKOA(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.EPCBFLMONPB() || Singleton<VipManager>.instance.MBLIANMNDEH();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 7;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 6;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 8;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.MCOEDCIJBPN(CGJNMCCOHPO);
	}

	public void NAKAFGAFEPH(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 998f : 137f);
		NIEAEMAENEA.alpha = 1794f;
	}

	public void FCCLAFOPBMP()
	{
		KNFOAKIJHCL.PCAGKCBOFAE();
	}

	public void LLCLBKCLJGG()
	{
		KNFOAKIJHCL.BANGFPPJIIC();
	}

	public void OLNDLIDNMOB()
	{
		KNFOAKIJHCL.BANGFPPJIIC();
	}

	public void DDHHPBCBNMO()
	{
		KNFOAKIJHCL.StartAnimation();
	}

	public void AAIFNPPLPFN()
	{
		KNFOAKIJHCL.IAKKJKAKEHO();
	}

	public void CAFPIOFENJK()
	{
		KNFOAKIJHCL.LFBBPHONAEF();
	}

	public void HEMAHAAOINO()
	{
		KNFOAKIJHCL.StopAnimation();
	}

	public void OMNEGAAKOCF(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1784f : 1171f);
		NIEAEMAENEA.alpha = 298f;
	}

	public void COLACLLHPJE()
	{
		KNFOAKIJHCL.GHMBKMNGAPG();
	}

	public void MMKEEBKDKLG(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 865f : 1819f);
		NIEAEMAENEA.alpha = 1016f;
	}

	public void HLDPEBCJFAK(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.HEAJEFKPKGK() || Singleton<VipManager>.instance.NOIHCEPINJJ();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 5;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 5;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 7;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void ODGINKAHGJF(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 835f : 157f);
		NIEAEMAENEA.alpha = 14f;
	}

	public void IIPALDEPGLI()
	{
		KNFOAKIJHCL.StartAnimation();
	}

	public void MAEOELMNFCA(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.PCOEGGGJMCO() || Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 3;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 4;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 0;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void CFJFCGECLDI()
	{
		KNFOAKIJHCL.NCGMMJFMHKB();
	}

	public void IEOFBPMHLGB()
	{
		KNFOAKIJHCL.IAKKJKAKEHO();
	}

	public void OGIPEHAIFDA(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1699f : 302f);
		NIEAEMAENEA.alpha = 1622f;
	}

	public void IAKKJKAKEHO()
	{
		KNFOAKIJHCL.LFBBPHONAEF();
	}

	public void PKFNFBPEMNM()
	{
		KNFOAKIJHCL.GAAJGHNAHOA();
	}

	public void MHMAEACIAJI()
	{
		KNFOAKIJHCL.NCGMMJFMHKB();
	}

	public void HEGHDKMGFAB(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1336f : 1456f);
		NIEAEMAENEA.alpha = 1263f;
	}

	public void BMBAHONLLLM()
	{
		KNFOAKIJHCL.LFBBPHONAEF();
	}

	public void JENIKDDKENO(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.PCOEGGGJMCO() || Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 3;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 3;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 3;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.MCOEDCIJBPN(CGJNMCCOHPO);
	}

	public void NHEMKMCNGPL(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.EPCBFLMONPB() || Singleton<VipManager>.instance.MBLIANMNDEH();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 1;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 2;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 6;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void HMPGPAHKILI()
	{
		KNFOAKIJHCL.GHMBKMNGAPG();
	}

	public void HFODBBNKOGM(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.JIDPLCILLMH() && Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 7;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 5;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 2;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void FIDIINBHKDG(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1347f : 1997f);
		NIEAEMAENEA.alpha = 292f;
	}

	public void AEGJIIBJGFK()
	{
		KNFOAKIJHCL.JEGAEFHOOBG();
	}

	public void CPEAOFHOCFC(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.PCOEGGGJMCO() && Singleton<VipManager>.instance.NOIHCEPINJJ();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 5;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 8;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 0;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void MPFPHNBAIKD(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 630f : 518f);
		NIEAEMAENEA.alpha = 315f;
	}

	public void LGBOIJLIHCL()
	{
		KNFOAKIJHCL.LFBBPHONAEF();
	}

	public void PHDFOCIGBNO(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.EPCBFLMONPB() && Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 4;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 8;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 0;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void HAEOEIEJIIJ()
	{
		KNFOAKIJHCL.StartAnimation();
	}

	public void GDIODIBMHFE(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.numberOfVIPDogtags && Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 7;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 4;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 8;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void LDHDECIEBJA()
	{
		KNFOAKIJHCL.GAAJGHNAHOA();
	}

	public void OMHMMPOOOEJ(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.IKGBJGAEHFF() && Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 7;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 2;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 6;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.MCOEDCIJBPN(CGJNMCCOHPO);
	}

	public void AONJEMCPIMK()
	{
		KNFOAKIJHCL.GHMBKMNGAPG();
	}

	public void LICMBINDFOP(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1445f : 1915f);
		NIEAEMAENEA.alpha = 15f;
	}

	public void OMGKCBMIKIP(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 331f : 1197f);
		NIEAEMAENEA.alpha = 758f;
	}

	public void SetSpritesOrder(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.numberOfVIPDogtags && Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 2;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 7;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 8;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void INPJAGPDKDE()
	{
		KNFOAKIJHCL.EEPLAIKBKMA();
	}

	public void MKENDIKJPLJ(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1957f : 1241f);
		NIEAEMAENEA.alpha = 1218f;
	}

	public void ACFBIMFIGGP()
	{
		KNFOAKIJHCL.EEPLAIKBKMA();
	}

	public void GGAHNKIKJKD(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 689f : 1040f);
		NIEAEMAENEA.alpha = 175f;
	}

	public void OAEAPJNDNJL(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.IKGBJGAEHFF() && Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 0;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 0;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 7;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void LDNGPIBIMKI()
	{
		KNFOAKIJHCL.JEGAEFHOOBG();
	}

	public void HIOCPADNJHL(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 645f : 473f);
		NIEAEMAENEA.alpha = 99f;
	}

	public void KHPJJANKGHG(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.PCOEGGGJMCO() || Singleton<VipManager>.instance.NOIHCEPINJJ();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 2;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 7;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 7;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void HEGPFIGACED(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 700f : 674f);
		NIEAEMAENEA.alpha = 116f;
	}

	public void DHGHKMCNJBO()
	{
		KNFOAKIJHCL.BANGFPPJIIC();
	}

	public void CIMNEPMOILL()
	{
		KNFOAKIJHCL.EEPLAIKBKMA();
	}

	public void DMKACIFOMKA()
	{
		KNFOAKIJHCL.IAKKJKAKEHO();
	}

	public void PIDNHEMEHBJ()
	{
		KNFOAKIJHCL.GAAJGHNAHOA();
	}

	public void KAHIMBMJBEN(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.PCOEGGGJMCO() || Singleton<VipManager>.instance.FAKAOBDANNA();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 4;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 8;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 1;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void NFPPJFHAEHG(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 396f : 436f);
		NIEAEMAENEA.alpha = 274f;
	}

	public void IFCHBHGGKDJ(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 670f : 87f);
		NIEAEMAENEA.alpha = 1638f;
	}

	public void GLGKGFEABGA()
	{
		KNFOAKIJHCL.GAAJGHNAHOA();
	}

	public void LMPNFLGMNBG(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 961f : 1168f);
		NIEAEMAENEA.alpha = 246f;
	}

	public void DDHCMFLIABO(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1874f : 1822f);
		NIEAEMAENEA.alpha = 136f;
	}

	public void ALODEAALJAH(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1991f : 1477f);
		NIEAEMAENEA.alpha = 104f;
	}

	public void POJFIMOGINP(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.AAABGLLAANF() && Singleton<VipManager>.instance.NOIHCEPINJJ();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 4;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 5;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 1;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void PMBNENCOKGD(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1655f : 106f);
		NIEAEMAENEA.alpha = 1246f;
	}

	public void OBHPLFFLDBI(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 194f : 854f);
		NIEAEMAENEA.alpha = 1487f;
	}

	public void NIKEHNPJCGA(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI < EGDGMINHOIK - Singleton<VipManager>.instance.IKGBJGAEHFF() || Singleton<VipManager>.instance.NOIHCEPINJJ();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 7;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 7;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 2;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void DEFEBNFBMHO(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.HEAJEFKPKGK() && Singleton<VipManager>.instance.NOGEIPHFNPK();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 3;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 4;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 3;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.SetDepthsAndColor(CGJNMCCOHPO);
	}

	public void LBNBOGBCBBN(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1698f : 105f);
		NIEAEMAENEA.alpha = 1246f;
	}

	public void FIHJGMMGIFA()
	{
		KNFOAKIJHCL.BANGFPPJIIC();
	}

	public void AJLDIPJNJGG(int MPHCNMDIPAI, int EGDGMINHOIK)
	{
		CGJNMCCOHPO = MPHCNMDIPAI >= EGDGMINHOIK - Singleton<VipManager>.instance.EPCBFLMONPB() && Singleton<VipManager>.instance.MBLIANMNDEH();
		NIEAEMAENEA.color = ((!CGJNMCCOHPO) ? Color.white : Colours.goldDogtag);
		MPHCNMDIPAI *= 7;
		KMFGCJEGJJK.depth = MPHCNMDIPAI + 4;
		NIEAEMAENEA.depth = MPHCNMDIPAI + 4;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-MPHCNMDIPAI);
		KNFOAKIJHCL.CJKLHJNOMGH(CGJNMCCOHPO);
	}

	public void KFLIKDCDPAF()
	{
		KNFOAKIJHCL.StopAnimation();
	}

	public void KGFPFOCFKAM()
	{
		KNFOAKIJHCL.StopAnimation();
	}

	public void JMEOEACGHOM(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 265f : 578f);
		NIEAEMAENEA.alpha = 768f;
	}

	public void KGOODMOOCLC(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 1028f : 1256f);
		NIEAEMAENEA.alpha = 927f;
	}

	public void MHAKKDGDLBP()
	{
		KNFOAKIJHCL.JEGAEFHOOBG();
	}

	public void BGFKBPMPJIL(bool ILDMNHEFJKI)
	{
		NIEAEMAENEA.fillAmount = ((!ILDMNHEFJKI) ? 769f : 373f);
		NIEAEMAENEA.alpha = 1124f;
	}
}
