using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class TutorialDialog : GuiElementSingle<TutorialDialog>, PAIIOKBBHBC
{
	public enum DODBDLEJOAM
	{
		TopLeft,
		Top,
		TopRight,
		Left,
		Center,
		Right,
		BottomLeft,
		Bottom,
		BottomRight
	}

	public enum BKJIJOMNIPI
	{
		Game,
		Menu,
		Special,
		Reward
	}

	private sealed class ONBFMLMBMON
	{
		internal GameObject JAGBOPMGIAA;

		internal Vector3 MPHCNMDIPAI;

		internal GameObject HOGFHALKPAD;

		internal TutorialDialog BJGCPDNMHDH;

		internal void JDEJHLLIONG(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 1132f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = DOIOCENOKHK;
		}

		internal void IHOMMCFGAPB(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.DMJKJADAACL();
		}

		internal void AOEOEIBLMMF(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 575f, new Vector3(1086f, 31f, 533f), useLocal: false);
			tweenPosition.method = UITweener.Method.EaseInOut;
		}

		internal void JHGBDMGHDMN(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 560f, new Vector3(996f, 698f, 606f), useLocal: false);
			tweenPosition.method = UITweener.Method.Linear;
		}

		internal void JDNPOHKEELM(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 586f, Vector3.one);
			tweenScale.method = UITweener.Method.BounceIn;
		}

		internal void EBJJKGFOLOA(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1352f, new Vector3(124f, 1378f, 828f));
			tweenPosition.method = (UITweener.Method)6;
		}

		internal void JEEPGFLHJCM(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.DMJKJADAACL();
		}

		internal void JHPEFFLPHCF(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1206f, new Vector3(1308f, 1221f, 1546f), useLocal: false);
			tweenPosition.method = UITweener.Method.Linear;
		}

		internal void CKIDEOIKHJO(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 495f, new Vector3(315f, 1724f, 1402f), useLocal: false);
			tweenPosition.method = (UITweener.Method)6;
		}

		internal void ILGOBENABHC(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1375f, new Vector3(1544f, 1064f, 371f));
			tweenPosition.method = (UITweener.Method)6;
		}

		internal void FDKEAJLEMCM(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 1619f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = (UITweener.Method)6;
			tweenPosition.onFinished = IHOMMCFGAPB;
		}

		internal void GMHEAIHOBEL(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 976f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseOut;
		}

		internal void BEIGOGFHJIB(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 1436f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = UITweener.Method.BounceOut;
			tweenPosition.onFinished = NFKKLDFJFMG;
		}

		internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 1297f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = (UITweener.Method)7;
			tweenPosition.onFinished = JAJCAFGGLMP;
		}

		internal void HMLMCGLICPM(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 927f, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
		}

		internal void BCEGPIKPFJF(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1818f, Vector3.one);
			tweenScale.method = (UITweener.Method)8;
		}

		internal void MMGEJAEDPOB(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 166f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseIn;
		}

		internal void CENOGMHAJNK(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1086f, new Vector3(1699f, 571f, 571f), useLocal: false);
			tweenPosition.method = UITweener.Method.Linear;
		}

		internal void JCFDEFFIHAM(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 825f, new Vector3(56f, 1720f, 1709f));
			tweenPosition.method = UITweener.Method.BounceOut;
		}

		internal void EIGOHMKAMGI(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1841f, new Vector3(1622f, 1690f, 1268f), useLocal: false);
			tweenPosition.method = UITweener.Method.EaseInOut;
		}

		internal void PEOKGFIGIGH(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1484f, new Vector3(1607f, 204f, 1535f), useLocal: false);
			tweenPosition.method = UITweener.Method.BounceIn;
		}

		internal void BLNOPKPLONB(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1529f, new Vector3(1328f, 1447f, 76f), useLocal: false);
			tweenPosition.method = (UITweener.Method)7;
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 1974f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = CCPOHDNCDJC;
		}

		internal void HKNCGEMENDB(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.AICKLGDHBBA();
		}

		internal void IOPJAPNNOOK(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.AICKLGDHBBA();
		}

		internal void DOIOCENOKHK(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.JMEPBKKBGAE();
		}

		internal void OMNNEIFECNE(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1518f, new Vector3(184f, 1417f, 821f));
			tweenPosition.method = UITweener.Method.BounceIn;
		}

		internal void KPHEPHDFCKK(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 286f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = (UITweener.Method)6;
			tweenPosition.onFinished = ENOKCDNOLMB;
		}

		internal void GKCCIMLNGCF(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 77f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseInOut;
		}

		internal void PKCGGMPIPDL(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 736f, new Vector3(1972f, 1301f, 1273f));
			tweenPosition.method = UITweener.Method.BounceOut;
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 251f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = UITweener.Method.EaseInOut;
			tweenPosition.onFinished = NFKKLDFJFMG;
		}

		internal void CFDNMILGDLG(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 13f, MPHCNMDIPAI);
			tweenPosition.method = UITweener.Method.EaseInOut;
			tweenPosition.onFinished = JAJCAFGGLMP;
		}

		internal void MPHECHCFCAN(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 1539f, MPHCNMDIPAI);
			tweenPosition.method = UITweener.Method.BounceOut;
			tweenPosition.onFinished = IOPJAPNNOOK;
		}

		internal void CBIEBLNLGLB(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1502f, new Vector3(1352f, 98f, 1700f));
			tweenPosition.method = UITweener.Method.BounceIn;
		}

		internal void BJLLLNAOOOB(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1166f, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
		}

		internal void JMIKKGIOAML(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1981f, Vector3.one);
			tweenScale.method = UITweener.Method.BounceOut;
		}

		internal void HKMBHFENEIL(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 259f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseInOut;
		}

		internal void CJKNGIAMMKG(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1654f, new Vector3(1784f, 1045f, 572f), useLocal: false);
			tweenPosition.method = UITweener.Method.BounceIn;
		}

		internal void PJLEDMHCDHO(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1867f, Vector3.one);
			tweenScale.method = UITweener.Method.BounceIn;
		}

		internal void JMHNMEBOPHN(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 132f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseIn;
		}

		internal void ILNPANOCHIH(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 704f, MPHCNMDIPAI);
			tweenPosition.method = (UITweener.Method)6;
			tweenPosition.onFinished = NDGHMPKFDNA;
		}

		internal void NDGHMPKFDNA(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.AICKLGDHBBA();
		}

		internal void CFGDGGBELGD(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 945f, new Vector3(1506f, 1665f, 143f), useLocal: false);
			tweenPosition.method = UITweener.Method.BounceIn;
		}

		internal void BIKJIFFCHFH(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1271f, new Vector3(726f, 1783f, 416f));
			tweenPosition.method = UITweener.Method.BounceOut;
		}

		internal void GGJDILDIFPJ(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 337f, MPHCNMDIPAI);
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = BIGNHFCNJLL;
		}

		internal void CIAOICMCMAM(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 588f, new Vector3(320f, 427f, 1367f));
			tweenPosition.method = UITweener.Method.BounceIn;
		}

		internal void EBLGBNEJLEC(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1438f, Vector3.one);
			tweenScale.method = UITweener.Method.BounceIn;
		}

		internal void MBMPBDEFNGE(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1933f, new Vector3(1059f, 1665f, 780f), useLocal: false);
			tweenPosition.method = (UITweener.Method)6;
		}

		internal void BIGNHFCNJLL(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.JMEPBKKBGAE();
		}

		internal void HONCMBHEKDP(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 0.3f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseOut;
		}

		internal void CCPOHDNCDJC(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.AICKLGDHBBA();
		}

		internal void IGNHEDDHHIA(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 751f, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
		}

		internal void ENOKCDNOLMB(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.DMJKJADAACL();
		}

		internal void DPBLKLIMOJD(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1333f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseIn;
		}

		internal void ECBLMEAFOIH(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1751f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseInOut;
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 0.4f, MPHCNMDIPAI);
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = BIGNHFCNJLL;
		}

		internal void NFKKLDFJFMG(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.ADPLOOMEMID();
		}

		internal void FCENGDPPIJH(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 350f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseIn;
		}

		internal void OPPNIDPBBIM(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1634f, new Vector3(542f, 653f, 1873f), useLocal: false);
			tweenPosition.method = (UITweener.Method)8;
		}

		internal void LOPMGEDOGEP(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 122f, Vector3.one);
			tweenScale.method = (UITweener.Method)6;
		}

		internal void AMIJFGBOCLC(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 724f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = HKNCGEMENDB;
		}

		internal void DLODDIOIDME(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 347f, new Vector3(555f, 1452f, 1987f), useLocal: false);
			tweenPosition.method = UITweener.Method.EaseIn;
		}

		internal void BLEMBJFNOGA(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 583f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseInOut;
		}

		internal void DDHOKNIEACI(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 468f, MPHCNMDIPAI);
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = JEEPGFLHJCM;
		}

		internal void JNHMJLAGPDL(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1117f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseOut;
		}

		internal void OPHINHIOCFD(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 1667f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.method = (UITweener.Method)8;
			tweenPosition.onFinished = HKNCGEMENDB;
		}

		internal void PHGDBIEENCB(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(JAGBOPMGIAA, 334f, MPHCNMDIPAI);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = DOIOCENOKHK;
		}

		internal void LKPEKDEPNCB(UITweener MKAPOHKFIJH)
		{
			TweenScale tweenScale = TweenScale.Begin(HOGFHALKPAD, 1379f, Vector3.one);
			tweenScale.method = UITweener.Method.EaseIn;
		}

		internal void EJLGBICBIFK(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 0.4f, new Vector3(-360f, -250f, 0f));
			tweenPosition.method = UITweener.Method.EaseOut;
		}

		internal void JAJCAFGGLMP(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.ADPLOOMEMID();
		}

		internal void HADLONLCLPM(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1552f, new Vector3(1776f, 991f, 1166f));
			tweenPosition.method = UITweener.Method.EaseInOut;
		}

		internal void KHGFKFOBDBF(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1824f, new Vector3(36f, 177f, 1178f));
			tweenPosition.method = UITweener.Method.Linear;
		}

		internal void ENOBKGECBGB(UITweener CKOINALCMFJ)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(HOGFHALKPAD, 1647f, new Vector3(65f, 55f, 1813f));
			tweenPosition.method = UITweener.Method.Linear;
		}
	}

	[FormerlySerializedAs("INMOLFGDHPD")]
	[Header("Game Tutorial")]
	public GameObject FPEPOGNFCAA;

	[FormerlySerializedAs("JBKGIKBLALH")]
	public GameObject ICNABKMNEGA;

	[FormerlySerializedAs("NFILMHJGGHP")]
	public UISprite GIPEKIBEPEB;

	[FormerlySerializedAs("GEOOOFADGGP")]
	public GameObject ENNEJJLNCBH;

	[FormerlySerializedAs("ADNNBFGHMEC")]
	public UITable KCBKKFHKAKJ;

	[FormerlySerializedAs("PFLCMCMHOOA")]
	public GameObject FPKMBEHMPDP;

	[FormerlySerializedAs("MDFHJEIDDNJ")]
	public UILabel AFPOPMGPAIC;

	[FormerlySerializedAs("APJDPGDNNAM")]
	public GameObject JIDBIFPKJLJ;

	[FormerlySerializedAs("HCPDOIFEBNP")]
	public UILabel JHKBAJPHKOB;

	public GameObject CCFFNAKFPPE;

	[FormerlySerializedAs("BCKGFLKBFAH")]
	public BoxCollider AJPHIGNGEHJ;

	[FormerlySerializedAs("EGMJCEFAAMG")]
	public UISprite PKILEIDFIOK;

	[FormerlySerializedAs("EFBDAFHCIGN")]
	public UIPanel OCBEMJHHLBD;

	[FormerlySerializedAs("IGFKKKFCHOB")]
	public UISprite JLMKABJPDMK;

	[FormerlySerializedAs("HPIOBLCCLHG")]
	[Header("Menu Tutorial")]
	public GameObject MIJJJBGPGAF;

	[FormerlySerializedAs("OJGPHLFMJBO")]
	public BoxCollider DDEDPIELKHL;

	[FormerlySerializedAs("FPGKKCGBBEC")]
	public UISprite AMBNDOJBJCH;

	[FormerlySerializedAs("EAMFNOJMLGP")]
	public GameObject PDOEIJPBNKF;

	[FormerlySerializedAs("AINEBOLEEAO")]
	public UILabel GDLDEGCBIAD;

	[FormerlySerializedAs("JLEGLIHDCMF")]
	public UILabel GABDHEMOHHD;

	[FormerlySerializedAs("DMLKKNNLAGK")]
	[Header("Special Tutorial")]
	public GameObject CLOPPKKBHPF;

	[FormerlySerializedAs("CJEHNNLBDDB")]
	public UILabel OGINOJOKHDN;

	[Header("Reward Tutorial")]
	[FormerlySerializedAs("FMOGHHBDBFP")]
	public GameObject OIKAIHFHPKC;

	[FormerlySerializedAs("IJFNCFNNJJC")]
	public UISprite NMCJGGHCHIJ;

	[FormerlySerializedAs("NBHCIBPCKBP")]
	public GameObject EAJEEIOJPOK;

	[FormerlySerializedAs("BOLCBCLFGPI")]
	public GameObject APNKAABNMPP;

	[FormerlySerializedAs("LDHMKCPKOOM")]
	public UITable DOJMJFBPBIB;

	[FormerlySerializedAs("FELIFNDLKGH")]
	public GameObject NLAJOOOJNPL;

	[FormerlySerializedAs("JPHMKMAADDK")]
	public UITable OLBGGFNGMAK;

	[FormerlySerializedAs("GEFLDLBGOAE")]
	public UILabel CBMOLMEPDOK;

	[FormerlySerializedAs("PFMIAPGEHOP")]
	public UILabel EOHOJBOGNAO;

	[FormerlySerializedAs("AEFAOPPDBGP")]
	public UILabel KIMMDPELOEN;

	[FormerlySerializedAs("DPMEGAGALOO")]
	public UILabel KBPBNIKMKII;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CBNJCJODLOCN_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CEMJMEELEAGG_003Ek__BackingField;

	private BKJIJOMNIPI GPABKIOEGKM;

	private TweenAnimator ENIJMFPELID;

	private TweenAnimator.TweenRecord DOPEBJOKKAB;

	private TweenAnimator.TweenRecord LBLGNEGODHE;

	private float IBONOAHAHGC;

	private float OENJPMPLNPB;

	private bool PEJCELEFNCB;

	private bool DHBEFJHJKOA;

	private bool ICFGNENEBAE;

	private string MCHOKEMNACI;

	private string JBOLHKGPIPM;

	private float EBICKAEGFFE;

	private DODBDLEJOAM MCBJLODIFJD;

	private bool EGEHGKKJDGE;

	private bool NBGJKCANAFE;

	private bool BJCBKOHOLPB;

	public bool continueClicked
	{
		[CompilerGenerated]
		get
		{
			return _003CBNJCJODLOCN_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CBNJCJODLOCN_003Ek__BackingField = value;
		}
	}

	public bool blinkText
	{
		[CompilerGenerated]
		get
		{
			return _003CEMJMEELEAGG_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CEMJMEELEAGG_003Ek__BackingField = value;
		}
	}

	public float minimalShowTime => 1.5f;

	public bool setDebug
	{
		set
		{
			ICFGNENEBAE = value;
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampDialog);
		JLMKABJPDMK.gameObject.SetActive(value: false);
		ELMPAEGPCED();
		PEJCELEFNCB = false;
	}

	public virtual void OGOAOPJNNEF()
	{
		base.NEEAKMELPBJ();
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(FPEPOGNFCAA, 1642f, FPEPOGNFCAA.transform.localPosition.AddY(1681f), useLocal: false);
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Menu)
		{
			TweenPosition.Begin(MIJJJBGPGAF, 918f, MIJJJBGPGAF.transform.localPosition.AddY(1584f));
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(OIKAIHFHPKC, 663f, OIKAIHFHPKC.transform.localPosition.AddY(1597f), useLocal: false);
			TweenColor tweenColor = TweenColor.Begin(KBPBNIKMKII.gameObject, 75f, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
		}
	}

	public void BLHPAFCOPMD(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool NHEJDPIIOJG = true)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Menu;
		IEBNAEIAEEF();
		blinkText = true;
		ACABOGKLHFL(NEEBBLOFHEF, PBEHMGKDJMH);
		DDEDPIELKHL.enabled = NHEJDPIIOJG;
		GDLDEGCBIAD.text = AMKLKMJEMJM;
		GABDHEMOHHD.text = DIDDEFHOPGC;
		if (!NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1176f);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void FDECGFAKNFF()
	{
		FPEPOGNFCAA.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Menu);
		MIJJJBGPGAF.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Menu);
		CLOPPKKBHPF.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Reward);
		OIKAIHFHPKC.SetActive(GPABKIOEGKM == (BKJIJOMNIPI)5);
	}

	public void HNOHAMJNOKH(string IPOLFMBALCO, string NNCJEFEENGB, int GHOIOFCJKDO, int HAFMGCFMCPC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = (BKJIJOMNIPI)5;
		FFLDLPOHOEP();
		blinkText = false;
		OKFDLJIJPDF(NEEBBLOFHEF, PBEHMGKDJMH);
		bool flag = GHOIOFCJKDO + HAFMGCFMCPC == 1;
		NLAJOOOJNPL.gameObject.SetActive(flag);
		APNKAABNMPP.gameObject.SetActive(flag);
		OLBGGFNGMAK.gameObject.SetActive(!flag);
		if (!flag)
		{
			OLBGGFNGMAK.repositionNow = true;
			GuiElementSingle<MenuHeader>.instance.BCNJPFHIKIO();
		}
		CBMOLMEPDOK.text = MEJMLNDFDBP.GMIPFLIEOHD(GHOIOFCJKDO);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		KIMMDPELOEN.text = IPOLFMBALCO;
		KBPBNIKMKII.text = NNCJEFEENGB;
		DOJMJFBPBIB.repositionNow = true;
		if (!NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1258f);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void DMJKJADAACL()
	{
		DHBEFJHJKOA = false;
		AJPHIGNGEHJ.enabled = true;
	}

	[SpecialName]
	public void DEACFMCKNKM(bool IDEBKDPMPGM)
	{
		ICFGNENEBAE = IDEBKDPMPGM;
	}

	private void AICKLGDHBBA()
	{
		DHBEFJHJKOA = false;
		AJPHIGNGEHJ.enabled = true;
	}

	public override void InitEvents()
	{
		base.InitEvents();
		// Some recovered MainScene variants do not contain the optional tutorial close target.
		// The dialog remains usable through its scripted tutorial progression without it.
		if (CCFFNAKFPPE != null)
		{
			UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		}
	}

	public void ReshowTutorialDialogAfterError()
	{
		if (BJCBKOHOLPB)
		{
			ShowGameTutorialDirectly(MCHOKEMNACI, JBOLHKGPIPM, EBICKAEGFFE, MCBJLODIFJD, EGEHGKKJDGE, NBGJKCANAFE);
		}
	}

	public virtual void EGNPMLEJLMJ()
	{
		if (CCFFNAKFPPE != null && CCFFNAKFPPE.activeSelf)
		{
			GJMMMBECGKP(CCFFNAKFPPE);
		}
	}

	public void FJFFALBAFBD(string HOLNKOFHDNK, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Reward;
		FFLDLPOHOEP();
		CFNDJHPJDFG(IDEBKDPMPGM: false);
		OKFDLJIJPDF(NEEBBLOFHEF, PBEHMGKDJMH);
		OGINOJOKHDN.text = ((!(HOLNKOFHDNK == string.Empty) && HOLNKOFHDNK.StartsWith("Achievements")) ? Localization.Localize(HOLNKOFHDNK) : HOLNKOFHDNK);
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1914f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void FEPJCDADLJA()
	{
		BJCBKOHOLPB = true;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("ID_YOUAREPREMIUMMEMBERWITHBENEFITS");
		}
		PEJCELEFNCB = true;
	}

	private void CFKJOPNNGNM(float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH)
	{
		float num = 1892f;
		if (PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.Center || PBEHMGKDJMH == DODBDLEJOAM.TopLeft)
		{
			num = 6f - UIHelper.activeWidthSafe / 101f - 843f;
		}
		if (PBEHMGKDJMH == DODBDLEJOAM.Left || PBEHMGKDJMH == DODBDLEJOAM.Bottom || PBEHMGKDJMH == DODBDLEJOAM.Center)
		{
			num = UIHelper.activeWidthSafe / 758f - 1611f + 970f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.TopLeft) && NEEBBLOFHEF < 438f)
		{
			NEEBBLOFHEF *= 1931f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.Right || PBEHMGKDJMH == DODBDLEJOAM.BottomLeft || PBEHMGKDJMH == DODBDLEJOAM.TopRight) && NEEBBLOFHEF > 845f)
		{
			NEEBBLOFHEF *= 560f;
		}
		float y = NEEBBLOFHEF * (UIHelper.activeHeight / 911f);
		switch (GPABKIOEGKM)
		{
		case BKJIJOMNIPI.Special:
			CLOPPKKBHPF.transform.localPosition = new Vector3(num + 804f, y, 1498f);
			break;
		case BKJIJOMNIPI.Game:
			FPEPOGNFCAA.transform.localPosition = new Vector3(num, y, 1200f);
			break;
		case BKJIJOMNIPI.Menu:
			MIJJJBGPGAF.transform.localPosition = new Vector3(num, y, 376f);
			break;
		case BKJIJOMNIPI.Reward:
			OIKAIHFHPKC.transform.localPosition = new Vector3(num, y, 1235f);
			break;
		}
	}

	public void DDFADDKPPDI(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool BEBMEBEJIOB = false)
	{
		PKILEIDFIOK.gameObject.SetActive(BEBMEBEJIOB);
		AFPOPMGPAIC.lineWidth = ((!BEBMEBEJIOB) ? (-147) : (-75));
		HBNEPCEAGLH((!(AMKLKMJEMJM == string.Empty)) ? Localization.Localize(AMKLKMJEMJM) : AMKLKMJEMJM, (!(DIDDEFHOPGC == string.Empty)) ? Localization.Localize(DIDDEFHOPGC) : DIDDEFHOPGC, NEEBBLOFHEF, PBEHMGKDJMH, BBGAMLLOING, NHEJDPIIOJG: true);
		GIPEKIBEPEB.spriteName = "flight_forward_jetpack_elite";
		GIPEKIBEPEB.MakePixelPerfect();
	}

	[SpecialName]
	public void FFPLABLIIGH(bool IDEBKDPMPGM)
	{
		_003CEMJMEELEAGG_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void BCLBBLIMCKG()
	{
		bool flag = !string.IsNullOrEmpty(JHKBAJPHKOB.text);
		JIDBIFPKJLJ.SetActive(flag);
		if (CCFFNAKFPPE.activeSelf)
		{
			KCBKKFHKAKJ.enabled = false;
			KCBKKFHKAKJ.repositionNow = false;
			float num = AFPOPMGPAIC.relativeSize.y * AFPOPMGPAIC.transform.localScale.y;
			float num2 = ((!flag) ? 333f : (JHKBAJPHKOB.relativeSize.y * JHKBAJPHKOB.transform.localScale.y));
			float num3 = 1452f;
			float num4 = 690f;
			float num5 = 998f - (num3 + num4);
			float num6 = 1436f + num + num2 + 1159f;
			float num7 = ((!flag) ? 8 : 3);
			float num8 = Mathf.Clamp((num5 - num6) / num7, 1874f, 1227f);
			KCBKKFHKAKJ.transform.localPosition = KCBKKFHKAKJ.transform.localPosition.ReplaceY(1264f + num8 - num3);
			KCBKKFHKAKJ.padding = new Vector2(19f, num8);
		}
		else
		{
			KCBKKFHKAKJ.transform.localPosition = KCBKKFHKAKJ.transform.localPosition.ReplaceY(905f);
			KCBKKFHKAKJ.repositionNow = false;
			KCBKKFHKAKJ.enabled = true;
			FPKMBEHMPDP.transform.localPosition = new Vector3(1658f, 1887f, 1586f);
			JIDBIFPKJLJ.transform.localPosition = new Vector3(950f, 1738f, 669f);
		}
	}

	public void Hide()
	{
		BJCBKOHOLPB = false;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("#PETER# Tutorial Dialog - Hide was called");
		}
		PEJCELEFNCB = true;
	}

	public GuiElement JMNCLNNCGGF()
	{
		return this;
	}

	public void GFCPBIFKFIJ(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool NHEJDPIIOJG = false)
	{
		BJCBKOHOLPB = false;
		MCHOKEMNACI = AMKLKMJEMJM;
		JBOLHKGPIPM = DIDDEFHOPGC;
		EBICKAEGFFE = NEEBBLOFHEF;
		MCBJLODIFJD = PBEHMGKDJMH;
		EGEHGKKJDGE = BBGAMLLOING;
		NBGJKCANAFE = NHEJDPIIOJG;
		GPABKIOEGKM = BKJIJOMNIPI.Menu;
		IEBNAEIAEEF();
		LFFFBDFCHLD(IDEBKDPMPGM: false);
		CCFFNAKFPPE.SetActive(BBGAMLLOING);
		ICNABKMNEGA.SetActive(NHEJDPIIOJG);
		CFKJOPNNGNM(NEEBBLOFHEF, PBEHMGKDJMH);
		AFPOPMGPAIC.text = AMKLKMJEMJM;
		JHKBAJPHKOB.text = DIDDEFHOPGC;
		blinkText = false;
		AEOPECFGKKH();
		if (!NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1551f);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void ADPLOOMEMID()
	{
		DHBEFJHJKOA = false;
		AJPHIGNGEHJ.enabled = true;
	}

	private void IMOENHMBAFF(GameObject KHAHPAKDIKE)
	{
		if (DHBEFJHJKOA)
		{
			LFFFBDFCHLD(IDEBKDPMPGM: false);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-81), 1235f);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DogTagUsed, 1854f);
		}
		else
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-86), 1872f);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGameVsSound, 759f);
		}
	}

	public GuiElement EMILFFGPHGK()
	{
		return this;
	}

	[SpecialName]
	public float DLALEKFAFGD()
	{
		return 1571f;
	}

	public override void InitGUIValues()
	{
		IBONOAHAHGC = 0f;
		OENJPMPLNPB = Time.realtimeSinceStartup;
		PEJCELEFNCB = false;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("#PETER# Tutorial Dialog - showing and mHideDialog is set to false");
		}
		AJPHIGNGEHJ.enabled = DHBEFJHJKOA;
	}

	public virtual void OKMMGFMKJGG()
	{
		IBONOAHAHGC = 1566f;
		OENJPMPLNPB = Time.realtimeSinceStartup;
		PEJCELEFNCB = false;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("ID_LEAGUE6");
		}
		AJPHIGNGEHJ.enabled = DHBEFJHJKOA;
	}

	public virtual void NNGDAMJFDBG()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FCILJOFFNGN));
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(FPEPOGNFCAA, 0.5f, FPEPOGNFCAA.transform.localPosition.AddY(50f));
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Menu)
		{
			TweenPosition.Begin(MIJJJBGPGAF, 0.5f, MIJJJBGPGAF.transform.localPosition.AddY(50f));
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Reward)
		{
			TweenPosition.Begin(OIKAIHFHPKC, 0.5f, OIKAIHFHPKC.transform.localPosition.AddY(50f));
			TweenColor tweenColor = TweenColor.Begin(KBPBNIKMKII.gameObject, 0.2f, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
		}
	}

	public void GKODNFIOLPB(string HOLNKOFHDNK, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = (BKJIJOMNIPI)8;
		FFLDLPOHOEP();
		CFNDJHPJDFG(IDEBKDPMPGM: true);
		CFKJOPNNGNM(NEEBBLOFHEF, PBEHMGKDJMH);
		OGINOJOKHDN.text = ((!(HOLNKOFHDNK == string.Empty) && HOLNKOFHDNK.StartsWith("0")) ? Localization.Localize(HOLNKOFHDNK) : HOLNKOFHDNK);
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1373f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public virtual void KAGDCIPGJOD()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EDEAEDKOMOC));
	}

	public GuiElement AONBBPBMBMO()
	{
		return this;
	}

	private void EAFOIKCEFFE()
	{
		ONBFMLMBMON oNBFMLMBMON = new ONBFMLMBMON();
		oNBFMLMBMON.BJGCPDNMHDH = this;
		DHBEFJHJKOA = true;
		if (GPABKIOEGKM == (BKJIJOMNIPI)5)
		{
			DHBEFJHJKOA = true;
			return;
		}
		oNBFMLMBMON.JAGBOPMGIAA = MIJJJBGPGAF;
		oNBFMLMBMON.HOGFHALKPAD = PDOEIJPBNKF;
		UISprite uISprite = AMBNDOJBJCH;
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			oNBFMLMBMON.JAGBOPMGIAA = FPEPOGNFCAA;
			oNBFMLMBMON.HOGFHALKPAD = ENNEJJLNCBH;
			uISprite = GIPEKIBEPEB;
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			oNBFMLMBMON.JAGBOPMGIAA = OIKAIHFHPKC;
			oNBFMLMBMON.HOGFHALKPAD = EAJEEIOJPOK;
			uISprite = NMCJGGHCHIJ;
		}
		oNBFMLMBMON.MPHCNMDIPAI = oNBFMLMBMON.JAGBOPMGIAA.transform.localPosition;
		uISprite.alpha = 153f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 949f, 502f, 1727f);
		tweenAlpha.delay = 705f;
		TweenPosition tweenPosition = TweenPosition.Begin(oNBFMLMBMON.JAGBOPMGIAA, 49f, oNBFMLMBMON.MPHCNMDIPAI + new Vector3(672f, 651f, 1124f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = oNBFMLMBMON.KPHEPHDFCKK;
		TweenPosition tweenPosition2 = TweenPosition.Begin(oNBFMLMBMON.HOGFHALKPAD, 1443f, new Vector3(1999f, 637f, 1398f), new Vector3(528f, 1446f, 1539f), useLocal: false);
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = oNBFMLMBMON.HADLONLCLPM;
		TweenScale tweenScale = TweenScale.Begin(oNBFMLMBMON.HOGFHALKPAD, 289f, new Vector3(551f, 154f, 1085f), new Vector3(1866f, 1955f, 103f));
		tweenScale.delay = 1475f;
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.onFinished = oNBFMLMBMON.DPBLKLIMOJD;
		TweenAlpha.Begin(OCBEMJHHLBD.gameObject, 1837f, 913f, 298f);
	}

	public void BMINKIDMOGL()
	{
		BJCBKOHOLPB = true;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("Gold");
		}
		PEJCELEFNCB = true;
	}

	public virtual void EKEPDPPINBH()
	{
		base.MOJBHFPBAPP();
		if (GPABKIOEGKM != BKJIJOMNIPI.Game && GPABKIOEGKM != BKJIJOMNIPI.Game && GPABKIOEGKM == (BKJIJOMNIPI)5)
		{
			TweenColor tweenColor = TweenColor.Begin(KBPBNIKMKII.gameObject, 1514f, Colours.blue, Color.white);
			tweenColor.style = ((!EGAJDBGOMPP()) ? UITweener.Style.Loop : UITweener.Style.Once);
			if (blinkText)
			{
				tweenColor.NumOfRepetitions = 1;
			}
		}
	}

	public void IOEJCIDBAPL(string IPOLFMBALCO, string NNCJEFEENGB, int GHOIOFCJKDO, int HAFMGCFMCPC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Reward;
		IEBNAEIAEEF();
		blinkText = true;
		OKFDLJIJPDF(NEEBBLOFHEF, PBEHMGKDJMH);
		bool flag = GHOIOFCJKDO + HAFMGCFMCPC == 0;
		NLAJOOOJNPL.gameObject.SetActive(flag);
		APNKAABNMPP.gameObject.SetActive(flag);
		OLBGGFNGMAK.gameObject.SetActive(!flag);
		if (!flag)
		{
			OLBGGFNGMAK.repositionNow = false;
			GuiElementSingle<MenuHeader>.instance.BCNJPFHIKIO();
		}
		CBMOLMEPDOK.text = MEJMLNDFDBP.GMIPFLIEOHD(GHOIOFCJKDO);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		KIMMDPELOEN.text = IPOLFMBALCO;
		KBPBNIKMKII.text = NNCJEFEENGB;
		DOJMJFBPBIB.repositionNow = true;
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 175f);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void OKFDLJIJPDF(float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH)
	{
		float num = 1229f;
		if (PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.Center)
		{
			num = 816f - UIHelper.activeWidthSafe / 962f - 1923f;
		}
		if (PBEHMGKDJMH == DODBDLEJOAM.Center || PBEHMGKDJMH == DODBDLEJOAM.BottomRight || PBEHMGKDJMH == DODBDLEJOAM.Bottom)
		{
			num = UIHelper.activeWidthSafe / 1473f - 963f + 736f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.Top || PBEHMGKDJMH == DODBDLEJOAM.TopRight) && NEEBBLOFHEF < 532f)
		{
			NEEBBLOFHEF *= 303f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.Left || PBEHMGKDJMH == DODBDLEJOAM.Center || PBEHMGKDJMH == DODBDLEJOAM.TopRight) && NEEBBLOFHEF > 1441f)
		{
			NEEBBLOFHEF *= 254f;
		}
		float y = NEEBBLOFHEF * (UIHelper.activeHeight / 348f);
		switch (GPABKIOEGKM)
		{
		case BKJIJOMNIPI.Special:
			CLOPPKKBHPF.transform.localPosition = new Vector3(num + 1854f, y, 95f);
			break;
		case BKJIJOMNIPI.Game:
			FPEPOGNFCAA.transform.localPosition = new Vector3(num, y, 1839f);
			break;
		case BKJIJOMNIPI.Menu:
			MIJJJBGPGAF.transform.localPosition = new Vector3(num, y, 636f);
			break;
		case BKJIJOMNIPI.Reward:
			OIKAIHFHPKC.transform.localPosition = new Vector3(num, y, 533f);
			break;
		}
	}

	public virtual void KFLBEIPPMBF()
	{
	}

	[SpecialName]
	public float OFEHPDGGKPO()
	{
		return 1321f;
	}

	public virtual void IDKBKFNPAPD()
	{
		if (CCFFNAKFPPE.activeSelf)
		{
			IMOENHMBAFF(CCFFNAKFPPE);
		}
	}

	protected virtual void DEBGBGGOCEN()
	{
		base.Update();
		float num = Time.realtimeSinceStartup - OENJPMPLNPB;
		IBONOAHAHGC += num;
		OENJPMPLNPB = Time.realtimeSinceStartup;
		if (IBONOAHAHGC > MDNKHOALLKD())
		{
			JMEPBKKBGAE();
			if (LHDGJFHPJNM() && PEJCELEFNCB)
			{
				HideDialog();
			}
		}
	}

	[SpecialName]
	public void CFNDJHPJDFG(bool IDEBKDPMPGM)
	{
		_003CEMJMEELEAGG_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void GDNHKMFLEKB(GameObject KHAHPAKDIKE)
	{
		if (DHBEFJHJKOA)
		{
			GCCCEKGLKOE(IDEBKDPMPGM: true);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-46), 19f);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-40), 1082f);
		}
		else
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-112), 176f);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-24), 976f);
		}
	}

	private void GJMMMBECGKP(GameObject KHAHPAKDIKE)
	{
		if (DHBEFJHJKOA)
		{
			continueClicked = false;
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)125, 1392f);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)76, 1530f);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CounterSoundExperience, 1901f);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)121, 278f);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void EOLOKEEJOCN()
	{
		ONBFMLMBMON oNBFMLMBMON = new ONBFMLMBMON();
		oNBFMLMBMON.BJGCPDNMHDH = this;
		DHBEFJHJKOA = true;
		if (GPABKIOEGKM == (BKJIJOMNIPI)4)
		{
			DHBEFJHJKOA = false;
			return;
		}
		oNBFMLMBMON.JAGBOPMGIAA = MIJJJBGPGAF;
		oNBFMLMBMON.HOGFHALKPAD = PDOEIJPBNKF;
		UISprite uISprite = AMBNDOJBJCH;
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			oNBFMLMBMON.JAGBOPMGIAA = FPEPOGNFCAA;
			oNBFMLMBMON.HOGFHALKPAD = ENNEJJLNCBH;
			uISprite = GIPEKIBEPEB;
		}
		else if (GPABKIOEGKM == (BKJIJOMNIPI)5)
		{
			oNBFMLMBMON.JAGBOPMGIAA = OIKAIHFHPKC;
			oNBFMLMBMON.HOGFHALKPAD = EAJEEIOJPOK;
			uISprite = NMCJGGHCHIJ;
		}
		oNBFMLMBMON.MPHCNMDIPAI = oNBFMLMBMON.JAGBOPMGIAA.transform.localPosition;
		uISprite.alpha = 1322f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 553f, 823f, 1319f);
		tweenAlpha.delay = 925f;
		TweenPosition tweenPosition = TweenPosition.Begin(oNBFMLMBMON.JAGBOPMGIAA, 1081f, oNBFMLMBMON.MPHCNMDIPAI + new Vector3(1083f, 189f, 41f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = oNBFMLMBMON.BEIGOGFHJIB;
		TweenPosition tweenPosition2 = TweenPosition.Begin(oNBFMLMBMON.HOGFHALKPAD, 1560f, new Vector3(1970f, 303f, 187f), new Vector3(1588f, 1839f, 596f));
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = oNBFMLMBMON.CFGDGGBELGD;
		TweenScale tweenScale = TweenScale.Begin(oNBFMLMBMON.HOGFHALKPAD, 1110f, new Vector3(1695f, 926f, 1946f), new Vector3(292f, 1979f, 568f));
		tweenScale.delay = 1424f;
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = oNBFMLMBMON.ECBLMEAFOIH;
		TweenAlpha.Begin(OCBEMJHHLBD.gameObject, 1319f, 527f, 1450f);
	}

	public void MHEOKFFFOKI(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool NHEJDPIIOJG = false)
	{
		BJCBKOHOLPB = true;
		MCHOKEMNACI = AMKLKMJEMJM;
		JBOLHKGPIPM = DIDDEFHOPGC;
		EBICKAEGFFE = NEEBBLOFHEF;
		MCBJLODIFJD = PBEHMGKDJMH;
		EGEHGKKJDGE = BBGAMLLOING;
		NBGJKCANAFE = NHEJDPIIOJG;
		GPABKIOEGKM = BKJIJOMNIPI.Menu;
		IEBNAEIAEEF();
		GCCCEKGLKOE(IDEBKDPMPGM: false);
		CCFFNAKFPPE.SetActive(BBGAMLLOING);
		ICNABKMNEGA.SetActive(NHEJDPIIOJG);
		HHHIJJKAJBL(NEEBBLOFHEF, PBEHMGKDJMH);
		AFPOPMGPAIC.text = AMKLKMJEMJM;
		JHKBAJPHKOB.text = DIDDEFHOPGC;
		MPHPLAOCOPK(IDEBKDPMPGM: false);
		AEOPECFGKKH();
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 539f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void ShowMenuTutorial(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool NHEJDPIIOJG = true)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Menu;
		IEBNAEIAEEF();
		blinkText = true;
		KPPHMEMFGOO(NEEBBLOFHEF, PBEHMGKDJMH);
		DDEDPIELKHL.enabled = NHEJDPIIOJG;
		GDLDEGCBIAD.text = AMKLKMJEMJM;
		GABDHEMOHHD.text = DIDDEFHOPGC;
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void ELMPAEGPCED()
	{
		ONBFMLMBMON oNBFMLMBMON = new ONBFMLMBMON();
		oNBFMLMBMON.BJGCPDNMHDH = this;
		DHBEFJHJKOA = false;
		if (GPABKIOEGKM == BKJIJOMNIPI.Special)
		{
			DHBEFJHJKOA = true;
			return;
		}
		oNBFMLMBMON.JAGBOPMGIAA = MIJJJBGPGAF;
		oNBFMLMBMON.HOGFHALKPAD = PDOEIJPBNKF;
		UISprite uISprite = AMBNDOJBJCH;
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			oNBFMLMBMON.JAGBOPMGIAA = FPEPOGNFCAA;
			oNBFMLMBMON.HOGFHALKPAD = ENNEJJLNCBH;
			uISprite = GIPEKIBEPEB;
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Reward)
		{
			oNBFMLMBMON.JAGBOPMGIAA = OIKAIHFHPKC;
			oNBFMLMBMON.HOGFHALKPAD = EAJEEIOJPOK;
			uISprite = NMCJGGHCHIJ;
		}
		oNBFMLMBMON.MPHCNMDIPAI = oNBFMLMBMON.JAGBOPMGIAA.transform.localPosition;
		uISprite.alpha = 0f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.delay = 0.2f;
		TweenPosition tweenPosition = TweenPosition.Begin(oNBFMLMBMON.JAGBOPMGIAA, 0.4f, oNBFMLMBMON.MPHCNMDIPAI + new Vector3(0f, 50f, 0f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = oNBFMLMBMON.LJCDGJKCNEC;
		TweenPosition tweenPosition2 = TweenPosition.Begin(oNBFMLMBMON.HOGFHALKPAD, 0.4f, new Vector3(-360f, -250f, 0f), new Vector3(-360f, -300f, 0f));
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = oNBFMLMBMON.EJLGBICBIFK;
		TweenScale tweenScale = TweenScale.Begin(oNBFMLMBMON.HOGFHALKPAD, 0.3f, new Vector3(1f, 1f, 1f), new Vector3(1.1f, 1.1f, 1.1f));
		tweenScale.delay = 0.2f;
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = oNBFMLMBMON.HONCMBHEKDP;
		TweenAlpha.Begin(OCBEMJHHLBD.gameObject, 0.3f, 0f, 1f);
	}

	public void AJJDDGAGKEI(string MENKGDPFJCA, string LKPLILFLDCI)
	{
		GIPEKIBEPEB.spriteName = MENKGDPFJCA;
		GIPEKIBEPEB.MakePixelPerfect();
		JLMKABJPDMK.gameObject.SetActive(value: false);
		JLMKABJPDMK.spriteName = LKPLILFLDCI;
		JLMKABJPDMK.MakePixelPerfect();
	}

	public void PBEAOCBHFGD(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool NHEJDPIIOJG = true)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Game;
		FFLDLPOHOEP();
		CFNDJHPJDFG(IDEBKDPMPGM: false);
		KPPHMEMFGOO(NEEBBLOFHEF, PBEHMGKDJMH);
		DDEDPIELKHL.enabled = NHEJDPIIOJG;
		GDLDEGCBIAD.text = AMKLKMJEMJM;
		GABDHEMOHHD.text = DIDDEFHOPGC;
		if (!NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 530f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public override void FKCKIFKLBAP()
	{
		base.FKCKIFKLBAP();
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(FPEPOGNFCAA, 935f, FPEPOGNFCAA.transform.localPosition.AddY(1105f));
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Menu)
		{
			TweenPosition.Begin(MIJJJBGPGAF, 275f, MIJJJBGPGAF.transform.localPosition.AddY(1334f), useLocal: false);
		}
		else if (GPABKIOEGKM == (BKJIJOMNIPI)4)
		{
			TweenPosition.Begin(OIKAIHFHPKC, 1209f, OIKAIHFHPKC.transform.localPosition.AddY(193f));
			TweenColor tweenColor = TweenColor.Begin(KBPBNIKMKII.gameObject, 1556f, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
		}
	}

	public void BELJAOIJCOJ(string IPOLFMBALCO, string NNCJEFEENGB, int GHOIOFCJKDO, int HAFMGCFMCPC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Game;
		OIPFHBEIDHN();
		KAAHHGNLKDO(IDEBKDPMPGM: true);
		CFKJOPNNGNM(NEEBBLOFHEF, PBEHMGKDJMH);
		bool flag = GHOIOFCJKDO + HAFMGCFMCPC == 0;
		NLAJOOOJNPL.gameObject.SetActive(flag);
		APNKAABNMPP.gameObject.SetActive(flag);
		OLBGGFNGMAK.gameObject.SetActive(flag);
		if (!flag)
		{
			OLBGGFNGMAK.repositionNow = false;
			GuiElementSingle<MenuHeader>.instance.PFPGEMJALMK();
		}
		CBMOLMEPDOK.text = MEJMLNDFDBP.GMIPFLIEOHD(GHOIOFCJKDO);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		KIMMDPELOEN.text = IPOLFMBALCO;
		KBPBNIKMKII.text = NNCJEFEENGB;
		DOJMJFBPBIB.repositionNow = true;
		if (!NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1319f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public virtual void PAIKCHDABEJ()
	{
		if (CCFFNAKFPPE.activeSelf)
		{
			FCILJOFFNGN(CCFFNAKFPPE);
		}
	}

	public virtual void HJFOKEOEMFL()
	{
		base.DoBeforeShowUp();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DailyRewardClaim, 1407f);
		JLMKABJPDMK.gameObject.SetActive(value: true);
		NFNCGIFOBLJ();
		PEJCELEFNCB = false;
	}

	public virtual void DFLGLEJIPCO()
	{
		IBONOAHAHGC = 1914f;
		OENJPMPLNPB = Time.realtimeSinceStartup;
		PEJCELEFNCB = true;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("ПОДТВЕРДИТЬ");
		}
		AJPHIGNGEHJ.enabled = DHBEFJHJKOA;
	}

	public void CNLFPNFIBIO(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool NHEJDPIIOJG = false)
	{
		BJCBKOHOLPB = false;
		MCHOKEMNACI = AMKLKMJEMJM;
		JBOLHKGPIPM = DIDDEFHOPGC;
		EBICKAEGFFE = NEEBBLOFHEF;
		MCBJLODIFJD = PBEHMGKDJMH;
		EGEHGKKJDGE = BBGAMLLOING;
		NBGJKCANAFE = NHEJDPIIOJG;
		GPABKIOEGKM = BKJIJOMNIPI.Game;
		FDECGFAKNFF();
		LFFFBDFCHLD(IDEBKDPMPGM: true);
		CCFFNAKFPPE.SetActive(BBGAMLLOING);
		ICNABKMNEGA.SetActive(NHEJDPIIOJG);
		HHHIJJKAJBL(NEEBBLOFHEF, PBEHMGKDJMH);
		AFPOPMGPAIC.text = AMKLKMJEMJM;
		JHKBAJPHKOB.text = DIDDEFHOPGC;
		JILDLHPKIKP(IDEBKDPMPGM: true);
		AEOPECFGKKH();
		if (!NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 518f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void DOLDLDECPIO(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool NHEJDPIIOJG = true)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Game;
		FDECGFAKNFF();
		KAAHHGNLKDO(IDEBKDPMPGM: false);
		CFKJOPNNGNM(NEEBBLOFHEF, PBEHMGKDJMH);
		DDEDPIELKHL.enabled = NHEJDPIIOJG;
		GDLDEGCBIAD.text = AMKLKMJEMJM;
		GABDHEMOHHD.text = DIDDEFHOPGC;
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 206f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void KHPBNEBLEEF(string IPOLFMBALCO, string NNCJEFEENGB, int GHOIOFCJKDO, int HAFMGCFMCPC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = (BKJIJOMNIPI)4;
		FFLDLPOHOEP();
		FFPLABLIIGH(IDEBKDPMPGM: false);
		HHHIJJKAJBL(NEEBBLOFHEF, PBEHMGKDJMH);
		bool flag = GHOIOFCJKDO + HAFMGCFMCPC == 1;
		NLAJOOOJNPL.gameObject.SetActive(flag);
		APNKAABNMPP.gameObject.SetActive(flag);
		OLBGGFNGMAK.gameObject.SetActive(flag);
		if (!flag)
		{
			OLBGGFNGMAK.repositionNow = false;
			GuiElementSingle<MenuHeader>.instance.PFPGEMJALMK();
		}
		CBMOLMEPDOK.text = MEJMLNDFDBP.GMIPFLIEOHD(GHOIOFCJKDO);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		KIMMDPELOEN.text = IPOLFMBALCO;
		KBPBNIKMKII.text = NNCJEFEENGB;
		DOJMJFBPBIB.repositionNow = true;
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 334f);
		}
		else
		{
			InitGUIValues();
		}
	}

	[SpecialName]
	public bool GHOBFEONMKL()
	{
		return _003CEMJMEELEAGG_003Ek__BackingField;
	}

	public void ANEOFBJBCIK()
	{
		if (BJCBKOHOLPB)
		{
			ShowGameTutorialDirectly(MCHOKEMNACI, JBOLHKGPIPM, EBICKAEGFFE, MCBJLODIFJD, EGEHGKKJDGE, NBGJKCANAFE);
		}
	}

	public void ShowReward(string IPOLFMBALCO, string NNCJEFEENGB, int GHOIOFCJKDO, int HAFMGCFMCPC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Reward;
		IEBNAEIAEEF();
		blinkText = true;
		KPPHMEMFGOO(NEEBBLOFHEF, PBEHMGKDJMH);
		bool flag = GHOIOFCJKDO + HAFMGCFMCPC == 0;
		NLAJOOOJNPL.gameObject.SetActive(flag);
		APNKAABNMPP.gameObject.SetActive(flag);
		OLBGGFNGMAK.gameObject.SetActive(!flag);
		if (!flag)
		{
			OLBGGFNGMAK.repositionNow = true;
			GuiElementSingle<MenuHeader>.instance.AnimateToCurrentValues();
		}
		CBMOLMEPDOK.text = MEJMLNDFDBP.GMIPFLIEOHD(GHOIOFCJKDO);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		KIMMDPELOEN.text = IPOLFMBALCO;
		KBPBNIKMKII.text = NNCJEFEENGB;
		DOJMJFBPBIB.repositionNow = true;
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this);
		}
		else
		{
			InitGUIValues();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		if (GPABKIOEGKM != BKJIJOMNIPI.Game && GPABKIOEGKM != BKJIJOMNIPI.Menu && GPABKIOEGKM == BKJIJOMNIPI.Reward)
		{
			TweenColor tweenColor = TweenColor.Begin(KBPBNIKMKII.gameObject, 0.5f, Colours.blue, Color.white);
			tweenColor.style = (blinkText ? UITweener.Style.PingPong : UITweener.Style.Once);
			if (blinkText)
			{
				tweenColor.NumOfRepetitions = 0;
			}
		}
	}

	public virtual void LCIILFHEAEL()
	{
		base.DoBeforeShowUp();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-99), 13f);
		JLMKABJPDMK.gameObject.SetActive(value: false);
		EOLOKEEJOCN();
		PEJCELEFNCB = false;
	}

	[SpecialName]
	public void MPHPLAOCOPK(bool IDEBKDPMPGM)
	{
		_003CEMJMEELEAGG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void LFFFBDFCHLD(bool IDEBKDPMPGM)
	{
		_003CBNJCJODLOCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void MDJHKJDOLDI()
	{
		base.DoBeforeShowUp();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)127, 850f);
		JLMKABJPDMK.gameObject.SetActive(value: true);
		CONKIBMHOBG();
		PEJCELEFNCB = true;
	}

	public virtual void FLMPHCNMDFA()
	{
		base.DoAfterHide();
		DHBEFJHJKOA = true;
		PEJCELEFNCB = false;
	}

	public void JHIDOPOGNLO()
	{
		BJCBKOHOLPB = false;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("ExplodeDamage");
		}
		PEJCELEFNCB = false;
	}

	public void CLINGHOGNGM(string HOLNKOFHDNK, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = (BKJIJOMNIPI)4;
		IEBNAEIAEEF();
		CFNDJHPJDFG(IDEBKDPMPGM: true);
		OKFDLJIJPDF(NEEBBLOFHEF, PBEHMGKDJMH);
		OGINOJOKHDN.text = ((!(HOLNKOFHDNK == string.Empty) && HOLNKOFHDNK.StartsWith(":")) ? Localization.Localize(HOLNKOFHDNK) : HOLNKOFHDNK);
		if (!NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1064f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		DHBEFJHJKOA = false;
		PEJCELEFNCB = false;
	}

	public void ShowGameTutorialDirectly(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool NHEJDPIIOJG = false)
	{
		BJCBKOHOLPB = true;
		MCHOKEMNACI = AMKLKMJEMJM;
		JBOLHKGPIPM = DIDDEFHOPGC;
		EBICKAEGFFE = NEEBBLOFHEF;
		MCBJLODIFJD = PBEHMGKDJMH;
		EGEHGKKJDGE = BBGAMLLOING;
		NBGJKCANAFE = NHEJDPIIOJG;
		GPABKIOEGKM = BKJIJOMNIPI.Game;
		IEBNAEIAEEF();
		continueClicked = false;
		CCFFNAKFPPE.SetActive(BBGAMLLOING);
		ICNABKMNEGA.SetActive(NHEJDPIIOJG);
		KPPHMEMFGOO(NEEBBLOFHEF, PBEHMGKDJMH);
		AFPOPMGPAIC.text = AMKLKMJEMJM;
		JHKBAJPHKOB.text = DIDDEFHOPGC;
		blinkText = true;
		AEOPECFGKKH();
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void KOGOLIJLMDN(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool BEBMEBEJIOB = false)
	{
		PKILEIDFIOK.gameObject.SetActive(BEBMEBEJIOB);
		AFPOPMGPAIC.lineWidth = ((!BEBMEBEJIOB) ? 161 : 89);
		CNLFPNFIBIO((!(AMKLKMJEMJM == string.Empty)) ? Localization.Localize(AMKLKMJEMJM) : AMKLKMJEMJM, (!(DIDDEFHOPGC == string.Empty)) ? Localization.Localize(DIDDEFHOPGC) : DIDDEFHOPGC, NEEBBLOFHEF, PBEHMGKDJMH, BBGAMLLOING);
		GIPEKIBEPEB.spriteName = "Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.";
		GIPEKIBEPEB.MakePixelPerfect();
	}

	public void CAIFLLEIJAF(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool NHEJDPIIOJG = false)
	{
		BJCBKOHOLPB = true;
		MCHOKEMNACI = AMKLKMJEMJM;
		JBOLHKGPIPM = DIDDEFHOPGC;
		EBICKAEGFFE = NEEBBLOFHEF;
		MCBJLODIFJD = PBEHMGKDJMH;
		EGEHGKKJDGE = BBGAMLLOING;
		NBGJKCANAFE = NHEJDPIIOJG;
		GPABKIOEGKM = BKJIJOMNIPI.Menu;
		FDECGFAKNFF();
		continueClicked = false;
		CCFFNAKFPPE.SetActive(BBGAMLLOING);
		ICNABKMNEGA.SetActive(NHEJDPIIOJG);
		KPPHMEMFGOO(NEEBBLOFHEF, PBEHMGKDJMH);
		AFPOPMGPAIC.text = AMKLKMJEMJM;
		JHKBAJPHKOB.text = DIDDEFHOPGC;
		KAAHHGNLKDO(IDEBKDPMPGM: false);
		BCLBBLIMCKG();
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 457f);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void JMEPBKKBGAE()
	{
		DHBEFJHJKOA = true;
		AJPHIGNGEHJ.enabled = true;
	}

	private void FCILJOFFNGN(GameObject KHAHPAKDIKE)
	{
		if (DHBEFJHJKOA)
		{
			continueClicked = false;
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)102, 1184f);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 13f);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.FlashEndScreen, 564f);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)108, 494f);
		}
	}

	public void LLOKPDFKHDI()
	{
		BJCBKOHOLPB = false;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("deliveryReduce");
		}
		PEJCELEFNCB = true;
	}

	private void FFLDLPOHOEP()
	{
		FPEPOGNFCAA.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Menu);
		MIJJJBGPGAF.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Game);
		CLOPPKKBHPF.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Game);
		OIKAIHFHPKC.SetActive(GPABKIOEGKM == (BKJIJOMNIPI)6);
	}

	public virtual void NEOLLOMIKPK()
	{
		IBONOAHAHGC = 1985f;
		OENJPMPLNPB = Time.realtimeSinceStartup;
		PEJCELEFNCB = false;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("()Z");
		}
		AJPHIGNGEHJ.enabled = DHBEFJHJKOA;
	}

	public virtual void PHNEOPBPLDG()
	{
		base.JNBMCODJHBJ();
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(FPEPOGNFCAA, 658f, FPEPOGNFCAA.transform.localPosition.AddY(1230f));
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(MIJJJBGPGAF, 980f, MIJJJBGPGAF.transform.localPosition.AddY(1507f), useLocal: false);
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(OIKAIHFHPKC, 149f, OIKAIHFHPKC.transform.localPosition.AddY(182f), useLocal: false);
			TweenColor tweenColor = TweenColor.Begin(KBPBNIKMKII.gameObject, 1820f, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
		}
	}

	[SpecialName]
	public bool ELIPJBOBAPK()
	{
		return _003CEMJMEELEAGG_003Ek__BackingField;
	}

	public void ShowSpecial(string HOLNKOFHDNK, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Special;
		IEBNAEIAEEF();
		blinkText = true;
		KPPHMEMFGOO(NEEBBLOFHEF, PBEHMGKDJMH);
		OGINOJOKHDN.text = ((!(HOLNKOFHDNK == string.Empty) && HOLNKOFHDNK.StartsWith("ID_")) ? Localization.Localize(HOLNKOFHDNK) : HOLNKOFHDNK);
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void NFNCGIFOBLJ()
	{
		ONBFMLMBMON oNBFMLMBMON = new ONBFMLMBMON();
		oNBFMLMBMON.BJGCPDNMHDH = this;
		DHBEFJHJKOA = false;
		if (GPABKIOEGKM == (BKJIJOMNIPI)7)
		{
			DHBEFJHJKOA = true;
			return;
		}
		oNBFMLMBMON.JAGBOPMGIAA = MIJJJBGPGAF;
		oNBFMLMBMON.HOGFHALKPAD = PDOEIJPBNKF;
		UISprite uISprite = AMBNDOJBJCH;
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			oNBFMLMBMON.JAGBOPMGIAA = FPEPOGNFCAA;
			oNBFMLMBMON.HOGFHALKPAD = ENNEJJLNCBH;
			uISprite = GIPEKIBEPEB;
		}
		else if (GPABKIOEGKM == (BKJIJOMNIPI)8)
		{
			oNBFMLMBMON.JAGBOPMGIAA = OIKAIHFHPKC;
			oNBFMLMBMON.HOGFHALKPAD = EAJEEIOJPOK;
			uISprite = NMCJGGHCHIJ;
		}
		oNBFMLMBMON.MPHCNMDIPAI = oNBFMLMBMON.JAGBOPMGIAA.transform.localPosition;
		uISprite.alpha = 1669f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 512f, 1771f, 1717f);
		tweenAlpha.delay = 346f;
		TweenPosition tweenPosition = TweenPosition.Begin(oNBFMLMBMON.JAGBOPMGIAA, 1742f, oNBFMLMBMON.MPHCNMDIPAI + new Vector3(1838f, 773f, 1385f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = oNBFMLMBMON.NAJNECOMDDN;
		TweenPosition tweenPosition2 = TweenPosition.Begin(oNBFMLMBMON.HOGFHALKPAD, 1678f, new Vector3(1566f, 1501f, 1866f), new Vector3(290f, 1454f, 704f));
		tweenPosition2.method = UITweener.Method.Linear;
		tweenPosition2.onFinished = oNBFMLMBMON.JCFDEFFIHAM;
		TweenScale tweenScale = TweenScale.Begin(oNBFMLMBMON.HOGFHALKPAD, 1157f, new Vector3(1262f, 1307f, 1254f), new Vector3(1403f, 1930f, 479f));
		tweenScale.delay = 1122f;
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.onFinished = oNBFMLMBMON.GKCCIMLNGCF;
		TweenAlpha.Begin(OCBEMJHHLBD.gameObject, 1490f, 1293f, 1141f);
	}

	public void FMPPLLLJIML(string MENKGDPFJCA, string LKPLILFLDCI)
	{
		GIPEKIBEPEB.spriteName = MENKGDPFJCA;
		GIPEKIBEPEB.MakePixelPerfect();
		JLMKABJPDMK.gameObject.SetActive(value: false);
		JLMKABJPDMK.spriteName = LKPLILFLDCI;
		JLMKABJPDMK.MakePixelPerfect();
	}

	[SpecialName]
	public void KAAHHGNLKDO(bool IDEBKDPMPGM)
	{
		_003CEMJMEELEAGG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void NIGINCPEHFP(string HOLNKOFHDNK, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Game;
		FDECGFAKNFF();
		MPHPLAOCOPK(IDEBKDPMPGM: true);
		KPPHMEMFGOO(NEEBBLOFHEF, PBEHMGKDJMH);
		OGINOJOKHDN.text = ((!(HOLNKOFHDNK == string.Empty) && HOLNKOFHDNK.StartsWith("VipRewardForDay")) ? Localization.Localize(HOLNKOFHDNK) : HOLNKOFHDNK);
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 440f);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void AEOPECFGKKH()
	{
		bool flag = !string.IsNullOrEmpty(JHKBAJPHKOB.text);
		JIDBIFPKJLJ.SetActive(flag);
		if (CCFFNAKFPPE.activeSelf)
		{
			KCBKKFHKAKJ.enabled = true;
			KCBKKFHKAKJ.repositionNow = true;
			float num = AFPOPMGPAIC.relativeSize.y * AFPOPMGPAIC.transform.localScale.y;
			float num2 = ((!flag) ? 0f : (JHKBAJPHKOB.relativeSize.y * JHKBAJPHKOB.transform.localScale.y));
			float num3 = 35f;
			float num4 = 25f;
			float num5 = 500f - (num3 + num4);
			float num6 = 9f + num + num2 + 100f;
			float num7 = ((!flag) ? 2 : 4);
			float num8 = Mathf.Clamp((num5 - num6) / num7, 1f, 500f);
			KCBKKFHKAKJ.transform.localPosition = KCBKKFHKAKJ.transform.localPosition.ReplaceY(250f + num8 - num3);
			KCBKKFHKAKJ.padding = new Vector2(0f, num8);
		}
		else
		{
			KCBKKFHKAKJ.transform.localPosition = KCBKKFHKAKJ.transform.localPosition.ReplaceY(250f);
			KCBKKFHKAKJ.repositionNow = false;
			KCBKKFHKAKJ.enabled = false;
			FPKMBEHMPDP.transform.localPosition = new Vector3(0f, -35f, 0f);
			JIDBIFPKJLJ.transform.localPosition = new Vector3(0f, -465f, 0f);
		}
	}

	private void HHHIJJKAJBL(float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH)
	{
		float num = 271f;
		if (PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.BottomLeft || PBEHMGKDJMH == DODBDLEJOAM.BottomRight)
		{
			num = 1558f - UIHelper.activeWidthSafe / 31f - 1667f;
		}
		if (PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.Right || PBEHMGKDJMH == DODBDLEJOAM.TopRight)
		{
			num = UIHelper.activeWidthSafe / 272f - 1194f + 359f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.Top || PBEHMGKDJMH == DODBDLEJOAM.TopRight) && NEEBBLOFHEF < 1872f)
		{
			NEEBBLOFHEF *= 732f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.BottomLeft || PBEHMGKDJMH == DODBDLEJOAM.Right || PBEHMGKDJMH == DODBDLEJOAM.Center) && NEEBBLOFHEF > 173f)
		{
			NEEBBLOFHEF *= 731f;
		}
		float y = NEEBBLOFHEF * (UIHelper.activeHeight / 30f);
		switch (GPABKIOEGKM)
		{
		case BKJIJOMNIPI.Special:
			CLOPPKKBHPF.transform.localPosition = new Vector3(num + 1693f, y, 975f);
			break;
		case BKJIJOMNIPI.Game:
			FPEPOGNFCAA.transform.localPosition = new Vector3(num, y, 708f);
			break;
		case BKJIJOMNIPI.Menu:
			MIJJJBGPGAF.transform.localPosition = new Vector3(num, y, 110f);
			break;
		case BKJIJOMNIPI.Reward:
			OIKAIHFHPKC.transform.localPosition = new Vector3(num, y, 1271f);
			break;
		}
	}

	private void OIPFHBEIDHN()
	{
		FPEPOGNFCAA.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Menu);
		MIJJJBGPGAF.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Game);
		CLOPPKKBHPF.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Menu);
		OIKAIHFHPKC.SetActive(GPABKIOEGKM == (BKJIJOMNIPI)8);
	}

	[SpecialName]
	public bool EGAJDBGOMPP()
	{
		return _003CEMJMEELEAGG_003Ek__BackingField;
	}

	public virtual void NCDLCFFDJMA()
	{
		base.DoBeforeShowUp();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-40), 1922f);
		JLMKABJPDMK.gameObject.SetActive(value: true);
		EOLOKEEJOCN();
		PEJCELEFNCB = true;
	}

	[SpecialName]
	public float MDNKHOALLKD()
	{
		return 984f;
	}

	public void NECJPGELBIH()
	{
		BJCBKOHOLPB = true;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("MinDamage");
		}
		PEJCELEFNCB = false;
	}

	public virtual void IEHJMLIMNEP()
	{
		IBONOAHAHGC = 495f;
		OENJPMPLNPB = Time.realtimeSinceStartup;
		PEJCELEFNCB = false;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("Tutorial_Step_Complete");
		}
		AJPHIGNGEHJ.enabled = DHBEFJHJKOA;
	}

	public override void InitControls()
	{
	}

	public GuiElement FJECJLFIIKB()
	{
		return this;
	}

	public virtual void ACFDANMKHNG()
	{
		base.OIMKKAHOEKO();
		DHBEFJHJKOA = false;
		PEJCELEFNCB = false;
	}

	public void EOPPCIEONEG(string IPOLFMBALCO, string NNCJEFEENGB, int GHOIOFCJKDO, int HAFMGCFMCPC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = (BKJIJOMNIPI)6;
		FFLDLPOHOEP();
		KAAHHGNLKDO(IDEBKDPMPGM: false);
		OKFDLJIJPDF(NEEBBLOFHEF, PBEHMGKDJMH);
		bool flag = GHOIOFCJKDO + HAFMGCFMCPC == 0;
		NLAJOOOJNPL.gameObject.SetActive(flag);
		APNKAABNMPP.gameObject.SetActive(flag);
		OLBGGFNGMAK.gameObject.SetActive(!flag);
		if (!flag)
		{
			OLBGGFNGMAK.repositionNow = true;
			GuiElementSingle<MenuHeader>.instance.BCNJPFHIKIO();
		}
		CBMOLMEPDOK.text = MEJMLNDFDBP.GMIPFLIEOHD(GHOIOFCJKDO);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		KIMMDPELOEN.text = IPOLFMBALCO;
		KBPBNIKMKII.text = NNCJEFEENGB;
		DOJMJFBPBIB.repositionNow = true;
		if (!NPFFMLLLDAF())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 32f);
		}
		else
		{
			InitGUIValues();
		}
	}

	[SpecialName]
	public bool GDAIHLIGAKP()
	{
		return _003CBNJCJODLOCN_003Ek__BackingField;
	}

	[SpecialName]
	public void CINCGDJOIID(bool IDEBKDPMPGM)
	{
		_003CEMJMEELEAGG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public override void OnBack()
	{
		if (CCFFNAKFPPE.activeSelf)
		{
			CCHDCEDFNNB(CCFFNAKFPPE);
		}
	}

	private void EDEAEDKOMOC(GameObject KHAHPAKDIKE)
	{
		if (DHBEFJHJKOA)
		{
			continueClicked = false;
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-20), 1822f);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampClick, 1146f);
		}
		else
		{
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-98), 1013f);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Critical, 1210f);
		}
	}

	private void CJKBICEOBLK()
	{
		ONBFMLMBMON oNBFMLMBMON = new ONBFMLMBMON();
		oNBFMLMBMON.BJGCPDNMHDH = this;
		DHBEFJHJKOA = false;
		if (GPABKIOEGKM == (BKJIJOMNIPI)7)
		{
			DHBEFJHJKOA = true;
			return;
		}
		oNBFMLMBMON.JAGBOPMGIAA = MIJJJBGPGAF;
		oNBFMLMBMON.HOGFHALKPAD = PDOEIJPBNKF;
		UISprite uISprite = AMBNDOJBJCH;
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			oNBFMLMBMON.JAGBOPMGIAA = FPEPOGNFCAA;
			oNBFMLMBMON.HOGFHALKPAD = ENNEJJLNCBH;
			uISprite = GIPEKIBEPEB;
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Special)
		{
			oNBFMLMBMON.JAGBOPMGIAA = OIKAIHFHPKC;
			oNBFMLMBMON.HOGFHALKPAD = EAJEEIOJPOK;
			uISprite = NMCJGGHCHIJ;
		}
		oNBFMLMBMON.MPHCNMDIPAI = oNBFMLMBMON.JAGBOPMGIAA.transform.localPosition;
		uISprite.alpha = 493f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 528f, 572f, 1271f);
		tweenAlpha.delay = 1349f;
		TweenPosition tweenPosition = TweenPosition.Begin(oNBFMLMBMON.JAGBOPMGIAA, 775f, oNBFMLMBMON.MPHCNMDIPAI + new Vector3(961f, 1102f, 800f), useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = oNBFMLMBMON.FDKEAJLEMCM;
		TweenPosition tweenPosition2 = TweenPosition.Begin(oNBFMLMBMON.HOGFHALKPAD, 1615f, new Vector3(533f, 1391f, 743f), new Vector3(866f, 401f, 1610f));
		tweenPosition2.method = UITweener.Method.Linear;
		tweenPosition2.onFinished = oNBFMLMBMON.AOEOEIBLMMF;
		TweenScale tweenScale = TweenScale.Begin(oNBFMLMBMON.HOGFHALKPAD, 1352f, new Vector3(1438f, 75f, 808f), new Vector3(760f, 875f, 1357f));
		tweenScale.delay = 1207f;
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = oNBFMLMBMON.BLEMBJFNOGA;
		TweenAlpha.Begin(OCBEMJHHLBD.gameObject, 1626f, 528f, 190f);
	}

	private void CCHDCEDFNNB(GameObject KHAHPAKDIKE)
	{
		if (DHBEFJHJKOA)
		{
			continueClicked = true;
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampClick);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampDialogDissapear);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampClick);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampDialogDissapear);
		}
	}

	private void CONKIBMHOBG()
	{
		ONBFMLMBMON oNBFMLMBMON = new ONBFMLMBMON();
		oNBFMLMBMON.BJGCPDNMHDH = this;
		DHBEFJHJKOA = true;
		if (GPABKIOEGKM == BKJIJOMNIPI.Menu)
		{
			DHBEFJHJKOA = true;
			return;
		}
		oNBFMLMBMON.JAGBOPMGIAA = MIJJJBGPGAF;
		oNBFMLMBMON.HOGFHALKPAD = PDOEIJPBNKF;
		UISprite uISprite = AMBNDOJBJCH;
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			oNBFMLMBMON.JAGBOPMGIAA = FPEPOGNFCAA;
			oNBFMLMBMON.HOGFHALKPAD = ENNEJJLNCBH;
			uISprite = GIPEKIBEPEB;
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			oNBFMLMBMON.JAGBOPMGIAA = OIKAIHFHPKC;
			oNBFMLMBMON.HOGFHALKPAD = EAJEEIOJPOK;
			uISprite = NMCJGGHCHIJ;
		}
		oNBFMLMBMON.MPHCNMDIPAI = oNBFMLMBMON.JAGBOPMGIAA.transform.localPosition;
		uISprite.alpha = 200f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 54f, 1967f, 1185f);
		tweenAlpha.delay = 682f;
		TweenPosition tweenPosition = TweenPosition.Begin(oNBFMLMBMON.JAGBOPMGIAA, 544f, oNBFMLMBMON.MPHCNMDIPAI + new Vector3(125f, 110f, 1269f), useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = oNBFMLMBMON.PHGDBIEENCB;
		TweenPosition tweenPosition2 = TweenPosition.Begin(oNBFMLMBMON.HOGFHALKPAD, 1661f, new Vector3(443f, 1728f, 579f), new Vector3(315f, 728f, 1085f));
		tweenPosition2.method = UITweener.Method.Linear;
		tweenPosition2.onFinished = oNBFMLMBMON.JHGBDMGHDMN;
		TweenScale tweenScale = TweenScale.Begin(oNBFMLMBMON.HOGFHALKPAD, 1330f, new Vector3(1241f, 1984f, 691f), new Vector3(715f, 1092f, 1297f));
		tweenScale.delay = 1681f;
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = oNBFMLMBMON.MMGEJAEDPOB;
		TweenAlpha.Begin(OCBEMJHHLBD.gameObject, 520f, 1959f, 658f);
	}

	public virtual void IACJMNAFNCI()
	{
		if (CCFFNAKFPPE.activeSelf)
		{
			FCILJOFFNGN(CCFFNAKFPPE);
		}
	}

	public void NNOOPCFHDJK()
	{
		BJCBKOHOLPB = false;
		if (ICFGNENEBAE)
		{
			UnityEngine.Debug.Log("AssignmentsIds");
		}
		PEJCELEFNCB = false;
	}

	public virtual void GNKLDHIGMMC()
	{
		base.BJIPCOPNEAM();
		if (GPABKIOEGKM != BKJIJOMNIPI.Game && GPABKIOEGKM != BKJIJOMNIPI.Menu && GPABKIOEGKM == (BKJIJOMNIPI)7)
		{
			TweenColor tweenColor = TweenColor.Begin(KBPBNIKMKII.gameObject, 1928f, Colours.blue, Color.white);
			tweenColor.style = (GDGDJMCANPH() ? ((UITweener.Style)6) : UITweener.Style.Once);
			if (AGDLLJCAGKB())
			{
				tweenColor.NumOfRepetitions = 1;
			}
		}
	}

	public void ShowGameTutorial(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool BEBMEBEJIOB = false)
	{
		PKILEIDFIOK.gameObject.SetActive(BEBMEBEJIOB);
		AFPOPMGPAIC.lineWidth = ((!BEBMEBEJIOB) ? 675 : 470);
		ShowGameTutorialDirectly((!(AMKLKMJEMJM == string.Empty)) ? Localization.Localize(AMKLKMJEMJM) : AMKLKMJEMJM, (!(DIDDEFHOPGC == string.Empty)) ? Localization.Localize(DIDDEFHOPGC) : DIDDEFHOPGC, NEEBBLOFHEF, PBEHMGKDJMH, BBGAMLLOING);
		GIPEKIBEPEB.spriteName = "game-tilegfx-tutorial";
		GIPEKIBEPEB.MakePixelPerfect();
	}

	public void JEMBPDCBCEN()
	{
		if (BJCBKOHOLPB)
		{
			CAIFLLEIJAF(MCHOKEMNACI, JBOLHKGPIPM, EBICKAEGFFE, MCBJLODIFJD, EGEHGKKJDGE, NBGJKCANAFE);
		}
	}

	[SpecialName]
	public float CPMAHEGJFFN()
	{
		return 136f;
	}

	protected override void Update()
	{
		base.Update();
		float num = Time.realtimeSinceStartup - OENJPMPLNPB;
		IBONOAHAHGC += num;
		OENJPMPLNPB = Time.realtimeSinceStartup;
		if (IBONOAHAHGC > minimalShowTime)
		{
			JMEPBKKBGAE();
			if (base.isFullyShowed && PEJCELEFNCB)
			{
				HideDialog();
			}
		}
	}

	private void ACABOGKLHFL(float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH)
	{
		float num = 1003f;
		if (PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.TopRight || PBEHMGKDJMH == DODBDLEJOAM.Bottom)
		{
			num = 893f - UIHelper.activeWidthSafe / 255f - 1178f;
		}
		if (PBEHMGKDJMH == DODBDLEJOAM.Center || PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.BottomRight)
		{
			num = UIHelper.activeWidthSafe / 1910f - 751f + 1193f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.TopRight) && NEEBBLOFHEF < 695f)
		{
			NEEBBLOFHEF *= 658f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.TopRight || PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.TopLeft) && NEEBBLOFHEF > 183f)
		{
			NEEBBLOFHEF *= 969f;
		}
		float y = NEEBBLOFHEF * (UIHelper.activeHeight / 1606f);
		switch (GPABKIOEGKM)
		{
		case BKJIJOMNIPI.Special:
			CLOPPKKBHPF.transform.localPosition = new Vector3(num + 657f, y, 543f);
			break;
		case BKJIJOMNIPI.Game:
			FPEPOGNFCAA.transform.localPosition = new Vector3(num, y, 690f);
			break;
		case BKJIJOMNIPI.Menu:
			MIJJJBGPGAF.transform.localPosition = new Vector3(num, y, 309f);
			break;
		case BKJIJOMNIPI.Reward:
			OIKAIHFHPKC.transform.localPosition = new Vector3(num, y, 1060f);
			break;
		}
	}

	public void BLHEPOBPHPK(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool BEBMEBEJIOB = false)
	{
		PKILEIDFIOK.gameObject.SetActive(BEBMEBEJIOB);
		AFPOPMGPAIC.lineWidth = ((!BEBMEBEJIOB) ? (-146) : 100);
		ShowGameTutorialDirectly((!(AMKLKMJEMJM == string.Empty)) ? Localization.Localize(AMKLKMJEMJM) : AMKLKMJEMJM, (!(DIDDEFHOPGC == string.Empty)) ? Localization.Localize(DIDDEFHOPGC) : DIDDEFHOPGC, NEEBBLOFHEF, PBEHMGKDJMH, BBGAMLLOING);
		GIPEKIBEPEB.spriteName = "game-card-ico-shieldsup";
		GIPEKIBEPEB.MakePixelPerfect();
	}

	[SpecialName]
	public float JBLOIMDHKIM()
	{
		return 1503f;
	}

	[SpecialName]
	private void GCCCEKGLKOE(bool IDEBKDPMPGM)
	{
		_003CBNJCJODLOCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool GDGDJMCANPH()
	{
		return _003CEMJMEELEAGG_003Ek__BackingField;
	}

	public void GPIFEPGEHLF(string HOLNKOFHDNK, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = (BKJIJOMNIPI)6;
		FFLDLPOHOEP();
		CFNDJHPJDFG(IDEBKDPMPGM: false);
		ACABOGKLHFL(NEEBBLOFHEF, PBEHMGKDJMH);
		OGINOJOKHDN.text = ((!(HOLNKOFHDNK == string.Empty) && HOLNKOFHDNK.StartsWith("WeaponIgnoreLayer")) ? Localization.Localize(HOLNKOFHDNK) : HOLNKOFHDNK);
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 7f);
		}
		else
		{
			InitGUIValues();
		}
	}

	private void KPPHMEMFGOO(float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH)
	{
		float num = 0f;
		if (PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.Left || PBEHMGKDJMH == DODBDLEJOAM.BottomLeft)
		{
			num = 550f - UIHelper.activeWidthSafe / 2f - 20f;
		}
		if (PBEHMGKDJMH == DODBDLEJOAM.TopRight || PBEHMGKDJMH == DODBDLEJOAM.Right || PBEHMGKDJMH == DODBDLEJOAM.BottomRight)
		{
			num = UIHelper.activeWidthSafe / 2f - 550f + 20f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.TopLeft || PBEHMGKDJMH == DODBDLEJOAM.Top || PBEHMGKDJMH == DODBDLEJOAM.TopRight) && NEEBBLOFHEF < 0f)
		{
			NEEBBLOFHEF *= -1f;
		}
		if ((PBEHMGKDJMH == DODBDLEJOAM.BottomLeft || PBEHMGKDJMH == DODBDLEJOAM.Bottom || PBEHMGKDJMH == DODBDLEJOAM.BottomRight) && NEEBBLOFHEF > 0f)
		{
			NEEBBLOFHEF *= -1f;
		}
		float y = NEEBBLOFHEF * (UIHelper.activeHeight / 2f);
		switch (GPABKIOEGKM)
		{
		case BKJIJOMNIPI.Special:
			CLOPPKKBHPF.transform.localPosition = new Vector3(num + 90f, y, 0f);
			break;
		case BKJIJOMNIPI.Game:
			FPEPOGNFCAA.transform.localPosition = new Vector3(num, y, 0f);
			break;
		case BKJIJOMNIPI.Menu:
			MIJJJBGPGAF.transform.localPosition = new Vector3(num, y, 0f);
			break;
		case BKJIJOMNIPI.Reward:
			OIKAIHFHPKC.transform.localPosition = new Vector3(num, y, 0f);
			break;
		}
	}

	public virtual void MDHOJINHADJ()
	{
		base.DoBeforeShowUp();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 1223f);
		JLMKABJPDMK.gameObject.SetActive(value: true);
		EOLOKEEJOCN();
		PEJCELEFNCB = true;
	}

	public void HBNEPCEAGLH(string AMKLKMJEMJM, string DIDDEFHOPGC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center, bool BBGAMLLOING = false, bool NHEJDPIIOJG = false)
	{
		BJCBKOHOLPB = false;
		MCHOKEMNACI = AMKLKMJEMJM;
		JBOLHKGPIPM = DIDDEFHOPGC;
		EBICKAEGFFE = NEEBBLOFHEF;
		MCBJLODIFJD = PBEHMGKDJMH;
		EGEHGKKJDGE = BBGAMLLOING;
		NBGJKCANAFE = NHEJDPIIOJG;
		GPABKIOEGKM = BKJIJOMNIPI.Menu;
		FDECGFAKNFF();
		LFFFBDFCHLD(IDEBKDPMPGM: false);
		CCFFNAKFPPE.SetActive(BBGAMLLOING);
		ICNABKMNEGA.SetActive(NHEJDPIIOJG);
		CFKJOPNNGNM(NEEBBLOFHEF, PBEHMGKDJMH);
		AFPOPMGPAIC.text = AMKLKMJEMJM;
		JHKBAJPHKOB.text = DIDDEFHOPGC;
		FFPLABLIIGH(IDEBKDPMPGM: false);
		AEOPECFGKKH();
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1081f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public virtual void DLLIFNIPNON()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GJMMMBECGKP));
	}

	public void SetSoldierSprite(string MENKGDPFJCA, string LKPLILFLDCI)
	{
		GIPEKIBEPEB.spriteName = MENKGDPFJCA;
		GIPEKIBEPEB.MakePixelPerfect();
		JLMKABJPDMK.gameObject.SetActive(value: true);
		JLMKABJPDMK.spriteName = LKPLILFLDCI;
		JLMKABJPDMK.MakePixelPerfect();
	}

	[SpecialName]
	public bool AGDLLJCAGKB()
	{
		return _003CEMJMEELEAGG_003Ek__BackingField;
	}

	public void CHBGKEKMMDF()
	{
		if (BJCBKOHOLPB)
		{
			CNLFPNFIBIO(MCHOKEMNACI, JBOLHKGPIPM, EBICKAEGFFE, MCBJLODIFJD, EGEHGKKJDGE, NBGJKCANAFE);
		}
	}

	[SpecialName]
	public void JILDLHPKIKP(bool IDEBKDPMPGM)
	{
		_003CEMJMEELEAGG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void LJALACMIDCP()
	{
		base.DoBeforeHide();
		if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(FPEPOGNFCAA, 508f, FPEPOGNFCAA.transform.localPosition.AddY(159f), useLocal: false);
		}
		else if (GPABKIOEGKM == BKJIJOMNIPI.Game)
		{
			TweenPosition.Begin(MIJJJBGPGAF, 1496f, MIJJJBGPGAF.transform.localPosition.AddY(926f));
		}
		else if (GPABKIOEGKM == (BKJIJOMNIPI)4)
		{
			TweenPosition.Begin(OIKAIHFHPKC, 790f, OIKAIHFHPKC.transform.localPosition.AddY(916f));
			TweenColor tweenColor = TweenColor.Begin(KBPBNIKMKII.gameObject, 1265f, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
		}
	}

	public virtual void LPFPAKGNNIO()
	{
	}

	public void NHJEOINEAEO(string IPOLFMBALCO, string NNCJEFEENGB, int GHOIOFCJKDO, int HAFMGCFMCPC, float NEEBBLOFHEF, DODBDLEJOAM PBEHMGKDJMH = DODBDLEJOAM.Center)
	{
		GPABKIOEGKM = BKJIJOMNIPI.Special;
		OIPFHBEIDHN();
		CFNDJHPJDFG(IDEBKDPMPGM: true);
		KPPHMEMFGOO(NEEBBLOFHEF, PBEHMGKDJMH);
		bool flag = GHOIOFCJKDO + HAFMGCFMCPC == 0;
		NLAJOOOJNPL.gameObject.SetActive(flag);
		APNKAABNMPP.gameObject.SetActive(flag);
		OLBGGFNGMAK.gameObject.SetActive(!flag);
		if (!flag)
		{
			OLBGGFNGMAK.repositionNow = true;
			GuiElementSingle<MenuHeader>.instance.AnimateToCurrentValues();
		}
		CBMOLMEPDOK.text = MEJMLNDFDBP.GMIPFLIEOHD(GHOIOFCJKDO);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		KIMMDPELOEN.text = IPOLFMBALCO;
		KBPBNIKMKII.text = NNCJEFEENGB;
		DOJMJFBPBIB.repositionNow = false;
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1175f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public virtual void AFMPBPGLFMJ()
	{
	}

	public GuiElement MBELJEEONHN()
	{
		return this;
	}

	public void PCNKBANBCBO()
	{
		if (BJCBKOHOLPB)
		{
			MHEOKFFFOKI(MCHOKEMNACI, JBOLHKGPIPM, EBICKAEGFFE, MCBJLODIFJD, EGEHGKKJDGE, NBGJKCANAFE);
		}
	}

	public virtual void OLPGIOCEIGJ()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
	}

	private void IEBNAEIAEEF()
	{
		FPEPOGNFCAA.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Game);
		MIJJJBGPGAF.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Menu);
		CLOPPKKBHPF.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Special);
		OIKAIHFHPKC.SetActive(GPABKIOEGKM == BKJIJOMNIPI.Reward);
	}

	public void HBEKIOOJMPA(string MENKGDPFJCA, string LKPLILFLDCI)
	{
		GIPEKIBEPEB.spriteName = MENKGDPFJCA;
		GIPEKIBEPEB.MakePixelPerfect();
		JLMKABJPDMK.gameObject.SetActive(value: false);
		JLMKABJPDMK.spriteName = LKPLILFLDCI;
		JLMKABJPDMK.MakePixelPerfect();
	}
}
