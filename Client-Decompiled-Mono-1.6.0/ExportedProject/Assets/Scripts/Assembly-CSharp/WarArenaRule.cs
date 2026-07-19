using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WarArenaRule : ScriptableObject
{
	public enum OBNJAIHEJOJ
	{
		FulFill = 0,
		DoesNotMeet = 1,
		InfoRule = 2,
		InfoText = 3
	}

	public class OCCICIIEHEF
	{
		public OBNJAIHEJOJ FJLBLLLEELD;

		public string HOLNKOFHDNK;

		public string PGCLKJNCKOF;

		public string AJKHGPLHIHK;

		public string MJADIIIJPEA
		{
			get
			{
				return string.Format("[{0}] {1}", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
			}
		}

		[SpecialName]
		public string DDELFOLBMJD()
		{
			return string.Format("ID_CATEGORY_MINIGUN", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
		}

		[SpecialName]
		public string ENDPEJCGJAN()
		{
			return string.Format("ID_CONFIRM_ERROR", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
		}

		public OCCICIIEHEF()
		{
			FJLBLLLEELD = OBNJAIHEJOJ.InfoRule;
			HOLNKOFHDNK = string.Empty;
		}

		public OCCICIIEHEF(string LHFDEOPIFNE, OBNJAIHEJOJ DPGAJJALFLP = OBNJAIHEJOJ.InfoRule)
		{
			FJLBLLLEELD = DPGAJJALFLP;
			HOLNKOFHDNK = LHFDEOPIFNE;
		}

		[SpecialName]
		public string KMJBCKNCGJD()
		{
			return string.Format("ArmyPower", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
		}

		[SpecialName]
		public string HBCKIGKDCPM()
		{
			return string.Format("hide", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
		}

		[SpecialName]
		public string OEEDCEEKFNP()
		{
			return string.Format("game-label-you-blue", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
		}

		[SpecialName]
		public string PEPGOCCBKGG()
		{
			return string.Format("ID_GUI_REPORTABUSE_LISTITEM1", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
		}

		public OCCICIIEHEF(string LHFDEOPIFNE, string CNMDFMGELLH, string CKGFJMDGGNL, OBNJAIHEJOJ DPGAJJALFLP)
		{
			FJLBLLLEELD = DPGAJJALFLP;
			AJKHGPLHIHK = CNMDFMGELLH;
			HOLNKOFHDNK = LHFDEOPIFNE;
			PGCLKJNCKOF = CKGFJMDGGNL;
		}

		[SpecialName]
		public string MNEPNNBKLNG()
		{
			return string.Format("menu-squad-1", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
		}

		[SpecialName]
		public string JINCHJCJLDP()
		{
			return string.Format("ID", FJLBLLLEELD.ToString().ToUpper(), HOLNKOFHDNK);
		}
	}

	public OCCICIIEHEF guiRule
	{
		get
		{
			OCCICIIEHEF oCCICIIEHEF = OHFBLDPINHI();
			if (oCCICIIEHEF == null)
			{
				return null;
			}
			IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
			Tuple<string, string> value;
			if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
			{
				oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
				oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
			}
			return oCCICIIEHEF;
		}
	}

	protected virtual OCCICIIEHEF IEKDLDACNDI()
	{
		return new OCCICIIEHEF();
	}

	public virtual string MHCJMJFPOGF()
	{
		return string.Empty;
	}

	protected virtual OCCICIIEHEF NNNAKBICOHM()
	{
		return new OCCICIIEHEF();
	}

	public virtual string HKAKMABFPAN()
	{
		return string.Empty;
	}

	public virtual void DGCKIICNPKM(JToken IDEBKDPMPGM)
	{
	}

	public virtual string ANNCEDBEAGO()
	{
		return string.Empty;
	}

	public virtual bool DJDCOJHOBJP()
	{
		return false;
	}

	[SpecialName]
	public OCCICIIEHEF GHKIACBOHCK()
	{
		OCCICIIEHEF oCCICIIEHEF = MFBIPMEKFAF();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual string FDNKIIJBMCP()
	{
		return string.Empty;
	}

	public virtual void JMLIBCJJOIA()
	{
	}

	[SpecialName]
	public OCCICIIEHEF GDDNNEPHLBM()
	{
		OCCICIIEHEF oCCICIIEHEF = LMOHCGEPLAH();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual RuleData INJMLCDOGPJ()
	{
		return null;
	}

	protected virtual OCCICIIEHEF OOBCHHAGFIO()
	{
		return new OCCICIIEHEF();
	}

	public virtual void GFJMJLMFPKO()
	{
	}

	public virtual string BABHDKKCOFJ()
	{
		return string.Empty;
	}

	protected virtual OCCICIIEHEF LMOHCGEPLAH()
	{
		return new OCCICIIEHEF();
	}

	public virtual RuleData ANFIGCGEBNN()
	{
		return null;
	}

	public virtual void AJFMLBKNLOH(JToken IDEBKDPMPGM)
	{
	}

	public virtual bool AIMGMMCHEIO()
	{
		return true;
	}

	public virtual bool DDFGIDBHJIK()
	{
		return false;
	}

	public virtual bool EKMMLNKADIL()
	{
		return true;
	}

	public virtual RuleData JBLCBKLHJCJ()
	{
		return null;
	}

	[SpecialName]
	public OCCICIIEHEF DGIDBLCLOOA()
	{
		OCCICIIEHEF oCCICIIEHEF = MNMEAAEKAMH();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual string FPGAPKILKJL()
	{
		return string.Empty;
	}

	public virtual void GJFHGPMMDEM()
	{
	}

	[SpecialName]
	public OCCICIIEHEF MIPKJEMKKJB()
	{
		OCCICIIEHEF oCCICIIEHEF = MNMEAAEKAMH();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual string DKIIFHAHOOJ()
	{
		return string.Empty;
	}

	public virtual RuleData PNCHCMEJEMI()
	{
		return null;
	}

	public virtual string BIBNGFAPIAN()
	{
		return string.Empty;
	}

	[SpecialName]
	public OCCICIIEHEF IOONMANCLMJ()
	{
		OCCICIIEHEF oCCICIIEHEF = OOBCHHAGFIO();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual bool CLPEMLCLDIJ()
	{
		return true;
	}

	public virtual RuleData FHPIAGEDCGJ()
	{
		return null;
	}

	public virtual void BAOCMJEMOIH(JToken IDEBKDPMPGM)
	{
	}

	public virtual RuleData FGFJCBDIELA()
	{
		return null;
	}

	public virtual void CCOKAPMFLPM(JToken IDEBKDPMPGM)
	{
	}

	public virtual string HMKEBDFDJCN()
	{
		return string.Empty;
	}

	public virtual bool OEAODGFDMGC()
	{
		return false;
	}

	public virtual RuleData GCLKOEPKBNE()
	{
		return null;
	}

	public virtual RuleData DNHDABNKGNG()
	{
		return null;
	}

	public virtual string HOFAFECGNOL()
	{
		return string.Empty;
	}

	public virtual RuleData IHCKONOMGJM()
	{
		return null;
	}

	public virtual void BJPBCGFHDLP(JToken IDEBKDPMPGM)
	{
	}

	public virtual void DNFMIJGCLFK(JToken IDEBKDPMPGM)
	{
	}

	public virtual RuleData OJKAPHBPHPB()
	{
		return null;
	}

	public virtual bool DAHIFNEGKAD()
	{
		return false;
	}

	public virtual void PDHNEJJPKIF(JToken IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public OCCICIIEHEF NAOPEBBOFIK()
	{
		OCCICIIEHEF oCCICIIEHEF = EPEIMHECJHK();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual RuleData IJDBNIEDNHH()
	{
		return null;
	}

	[SpecialName]
	public OCCICIIEHEF GLJHPLONLHB()
	{
		OCCICIIEHEF oCCICIIEHEF = OHFBLDPINHI();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual void IONJNJKPMHK()
	{
	}

	public virtual RuleData FHJPMJGFJKB()
	{
		return null;
	}

	public virtual RuleData ECGFIEEHDMO()
	{
		return null;
	}

	public virtual RuleData HGJBAAKAJIF()
	{
		return null;
	}

	[SpecialName]
	public OCCICIIEHEF BONMMKILCOK()
	{
		OCCICIIEHEF oCCICIIEHEF = IBOOCJPKFLG();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	protected virtual OCCICIIEHEF NELJBJBMOLH()
	{
		return new OCCICIIEHEF();
	}

	[SpecialName]
	public OCCICIIEHEF FIOMCMLNEEN()
	{
		OCCICIIEHEF oCCICIIEHEF = PEAIJAFJCBA();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual RuleData JFICCNLNLLK()
	{
		return null;
	}

	public virtual void LFFGKLJMMGF()
	{
	}

	public virtual string LIBBKPLKHAJ()
	{
		return string.Empty;
	}

	public virtual void ALJKKBMBBFM()
	{
	}

	protected virtual OCCICIIEHEF PEAIJAFJCBA()
	{
		return new OCCICIIEHEF();
	}

	public virtual void FBDFHHKIICO()
	{
	}

	public virtual bool OAELLJPGBPC()
	{
		return true;
	}

	[SpecialName]
	public OCCICIIEHEF AMBHKHABKNM()
	{
		OCCICIIEHEF oCCICIIEHEF = PEAIJAFJCBA();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	protected virtual OCCICIIEHEF OHFBLDPINHI()
	{
		return new OCCICIIEHEF();
	}

	protected virtual OCCICIIEHEF CKKHLNNIKHE()
	{
		return new OCCICIIEHEF();
	}

	public virtual void HBPJJCDCPLG()
	{
	}

	public virtual RuleData BEBODFPOILN()
	{
		return null;
	}

	[SpecialName]
	public OCCICIIEHEF AMOBBMGKCJC()
	{
		OCCICIIEHEF oCCICIIEHEF = CKKHLNNIKHE();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	protected virtual OCCICIIEHEF EPEIMHECJHK()
	{
		return new OCCICIIEHEF();
	}

	public virtual RuleData NHFBAHKDADF()
	{
		return null;
	}

	[SpecialName]
	public OCCICIIEHEF BPNKFMKDFMP()
	{
		OCCICIIEHEF oCCICIIEHEF = LOJHLDGDLIP();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual string OGGLBKOAMAE()
	{
		return string.Empty;
	}

	protected virtual OCCICIIEHEF MFBIPMEKFAF()
	{
		return new OCCICIIEHEF();
	}

	[SpecialName]
	public OCCICIIEHEF AKNIOFDMKCB()
	{
		OCCICIIEHEF oCCICIIEHEF = EPEIMHECJHK();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	[SpecialName]
	public OCCICIIEHEF EEKIBOEPNHB()
	{
		OCCICIIEHEF oCCICIIEHEF = OMDJEDGCGOM();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual bool AKIJBMEBNNC()
	{
		return false;
	}

	public virtual string KLBNHNNKPAE()
	{
		return string.Empty;
	}

	public virtual string JKCOBINAHDA()
	{
		return string.Empty;
	}

	public virtual void JNEGPCHLGKD()
	{
	}

	public virtual RuleData KBAFHFJFDNO()
	{
		return null;
	}

	public virtual bool KJDMOCMBFLJ()
	{
		return true;
	}

	public virtual void JLMPEEALGIC(JToken IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public OCCICIIEHEF IJDFDPNLCOB()
	{
		OCCICIIEHEF oCCICIIEHEF = BEDAAOOPNLB();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual bool LPLPANBJDAM()
	{
		return true;
	}

	public virtual string NFLBPFNHBDI()
	{
		return string.Empty;
	}

	public virtual void NFCOGJJIHEO(JToken IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public OCCICIIEHEF ELHAOALCGLJ()
	{
		OCCICIIEHEF oCCICIIEHEF = EPEIMHECJHK();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual bool MPNDBIBDOCD()
	{
		return false;
	}

	protected virtual OCCICIIEHEF OMDJEDGCGOM()
	{
		return new OCCICIIEHEF();
	}

	protected virtual OCCICIIEHEF LOJHLDGDLIP()
	{
		return new OCCICIIEHEF();
	}

	public virtual void AHMLJEFAAJG(JToken IDEBKDPMPGM)
	{
	}

	protected virtual OCCICIIEHEF MNMEAAEKAMH()
	{
		return new OCCICIIEHEF();
	}

	public virtual void IBEGGCHBJGC()
	{
	}

	public virtual void APIJFIPABAO()
	{
	}

	public virtual RuleData EILNHJFFAOP()
	{
		return null;
	}

	protected virtual OCCICIIEHEF BEDAAOOPNLB()
	{
		return new OCCICIIEHEF();
	}

	public virtual bool NMPPLCHLCDK()
	{
		return false;
	}

	public virtual void BNICHJLICKI(JToken IDEBKDPMPGM)
	{
	}

	public virtual string HDFKENKPJNJ()
	{
		return string.Empty;
	}

	public virtual void MPEICOLLNAB(JToken IDEBKDPMPGM)
	{
	}

	public virtual void LFLOCINGIHO(JToken IDEBKDPMPGM)
	{
	}

	public virtual void ANCJEMCFEID()
	{
	}

	public virtual void EPDLHJFDJBE()
	{
	}

	public virtual void EMPOAAPKIIH(JToken IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public OCCICIIEHEF DMJPOCAGAAP()
	{
		OCCICIIEHEF oCCICIIEHEF = OOBCHHAGFIO();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual void HIHFCANHINM()
	{
	}

	public virtual RuleData GGPAFMAPJOG()
	{
		return null;
	}

	public virtual void MKBJLCNGMOD(JToken IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public OCCICIIEHEF OFBOHALGLCB()
	{
		OCCICIIEHEF oCCICIIEHEF = MFBIPMEKFAF();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual RuleData GMGEDDEOPAE()
	{
		return null;
	}

	public virtual bool EDNAIMPLPGL()
	{
		return true;
	}

	public virtual RuleData NKGIBDACFHH()
	{
		return null;
	}

	public virtual string NGCBHCBLBLK()
	{
		return string.Empty;
	}

	public virtual RuleData FDKMEKJADLM()
	{
		return null;
	}

	protected virtual OCCICIIEHEF IBOOCJPKFLG()
	{
		return new OCCICIIEHEF();
	}

	public virtual string ALOICMAOEPL()
	{
		return string.Empty;
	}

	public virtual RuleData LKPOBOCGALM()
	{
		return null;
	}

	public virtual bool FGHKBLLKOBL()
	{
		return true;
	}

	[SpecialName]
	public OCCICIIEHEF GGPOHOEGOHG()
	{
		OCCICIIEHEF oCCICIIEHEF = LOJHLDGDLIP();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	[SpecialName]
	public OCCICIIEHEF IEBFCGIFODL()
	{
		OCCICIIEHEF oCCICIIEHEF = OMDJEDGCGOM();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual bool KFJLPGPAAAN()
	{
		return true;
	}

	public virtual void JOJJAMCJMKJ(JToken IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public OCCICIIEHEF KIFGECJLAMK()
	{
		OCCICIIEHEF oCCICIIEHEF = IBOOCJPKFLG();
		if (oCCICIIEHEF == null)
		{
			return null;
		}
		IKPLPPFFDNI fPLIPHCJGFO = WarArena.instance.FPLIPHCJGFO;
		Tuple<string, string> value;
		if (fPLIPHCJGFO.BLDMMJGBCIJ.TryGetValue(GetType().ToString(), out value))
		{
			oCCICIIEHEF.HOLNKOFHDNK = value.Value1;
			oCCICIIEHEF.AJKHGPLHIHK = value.Value2;
		}
		return oCCICIIEHEF;
	}

	public virtual string AAFMGNODLAE()
	{
		return string.Empty;
	}
}
