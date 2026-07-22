using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLeagueIcon : PoolableObject
{
	[Header("Core")]
	[FormerlySerializedAs("BDCHBAOKMLM")]
	public UITexture BFLBNOPDOAE;

	[FormerlySerializedAs("CJDBBKEDGBP")]
	public UISprite[] ENIGNONOBKM;

	private bool BAKGJEGCNCI;

	private int ALGBCPEGLCO;

	private League KNNEGKLGBKO;

	public void FLDCMIGAINO(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Play_Card_Tutorial" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		KJBACHGBCNF();
		HLGIALNMCHE(LCPBNBLGFIA);
	}

	public void IBAEOLLIJMB(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ID_UPDATINGACCOUNT" + Singleton<GameVariables>.instance.CHOAELALEIC(OODMHGMHKGE));
		DIPIHPIEINJ();
		DJLFGMAMNEN(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public void BNJHHOJALJC(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Found starting gold currency = " + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		LFAACMKJDEA();
		EHHLNHOFOCO(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public void HIIKEKGBDDK(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 1881f : 1876f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 190f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(617f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 603f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(886f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	private void KJBACHGBCNF()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO == 2) ? 1 : 0) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 0 : 0) : ((KNNEGKLGBKO != (League)114) ? ((KNNEGKLGBKO != League.Bronze1 && KNNEGKLGBKO != League.Bronze2 && KNNEGKLGBKO != (League)(-44) && KNNEGKLGBKO != (League)41 && KNNEGKLGBKO != (League)92) ? 1 : 8) : 0)));
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 1) ? 1434f : 1680f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 0);
	}

	public void DMBOIANMPGO(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ItemRarity_2" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NFBICINPMPI();
		NPLKPDIOLHE(LCPBNBLGFIA);
	}

	public void BKEHCGECLML()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.EFLNBGDAHFK(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO);
		HIIKEKGBDDK(LCPBNBLGFIA: false, AJNINHIKAFC: true);
	}

	public virtual void HLBHDOFFDGN()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	private void NFOMCBLDGBG()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO == 0) ? 8 : 0) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 0) : ((KNNEGKLGBKO == (League)(-112)) ? 1 : ((KNNEGKLGBKO == League.Gold2 || KNNEGKLGBKO == League.Bronze3 || KNNEGKLGBKO == (League)(-64) || KNNEGKLGBKO == (League)(-69) || KNNEGKLGBKO == (League)(-45)) ? 7 : 0))));
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 0) ? 139f : 1144f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 0);
	}

	private void NFBICINPMPI()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 4) ? 1 : 3) : ((KNNEGKLGBKO == League.NoLeague) ? ((!GameLoginManager.currentPlayer.isInBeginnersLeague) ? 1 : 0) : ((KNNEGKLGBKO == (League)98) ? 1 : ((KNNEGKLGBKO != League.Bronze2 && KNNEGKLGBKO != League.Bronze3 && KNNEGKLGBKO != (League)103 && KNNEGKLGBKO != (League)(-2) && KNNEGKLGBKO != (League)20) ? 1 : 2))));
		ENIGNONOBKM[1].gameObject.SetActive(num > 0);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 0) ? 872f : 277f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	public void GFMGJIBHHIO(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 515f : 1227f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1260f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1163f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 741f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(182f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void NPLKPDIOLHE(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 149f : 1715f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1122f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(84f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1076f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(1214f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void OCOGAKIPKJK(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("grenadeExplosion" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		KEGJHFHDIFE();
		NPLKPDIOLHE(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public virtual void LHJBNMDHKGJ()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	public void IOHJAOKFHPE(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("flawless" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NOMLBIJAOFE();
		GFMGJIBHHIO(LCPBNBLGFIA);
	}

	public void NGAOIENEOOK(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("-placement" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		LGKOIEKKBDA();
		BANCDJNFHIC(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public void NDCFHKKJIAP()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.SelectIcon(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO);
		FDKLKJBPFKJ(LCPBNBLGFIA: false);
	}

	private void LCKKCCDKBEM()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO == 5) ? 4 : 0) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 1) : ((KNNEGKLGBKO != (League)(-24)) ? ((KNNEGKLGBKO != League.Silver3 && KNNEGKLGBKO != League.Silver3 && KNNEGKLGBKO != (League)116 && KNNEGKLGBKO != (League)47 && KNNEGKLGBKO != (League)(-17)) ? 1 : 3) : 0)));
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 1) ? 1092f : 293f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
	}

	public virtual void KJDECEJDGHF()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.BOHCNEDIJPE();
	}

	public void KHFGLMIBHED(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("LeagueId" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(OODMHGMHKGE));
		LFAACMKJDEA();
		HIIKEKGBDDK(LCPBNBLGFIA);
	}

	public void OnClick()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.SelectIcon(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO, OMAJBANJKMK: true);
		Highlight(LCPBNBLGFIA: true, AJNINHIKAFC: true);
	}

	public void GEKHNAGHNEP(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("game-card-ico-bulletsponge-full" + Singleton<GameVariables>.instance.CHOAELALEIC(OODMHGMHKGE));
		NFBICINPMPI();
		FDKLKJBPFKJ(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public virtual void EBPEFIHKEIN()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	public void DFHGFEOJFIG(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 529f : 441f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 182f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1606f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1956f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(454f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void BHJNNDGEOGH(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Beanstalk: On Update device token" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		CNGIFJAFNKL();
		EHHPDIBBPBJ(LCPBNBLGFIA);
	}

	public void EHHPDIBBPBJ(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 781f : 918f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1599f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(754f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1237f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(563f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	private void KEGJHFHDIFE()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 2) ? 1 : 2) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 1) : ((KNNEGKLGBKO != (League)40) ? ((KNNEGKLGBKO != League.Bronze1 && KNNEGKLGBKO != League.Bronze3 && KNNEGKLGBKO != (League)(-67) && KNNEGKLGBKO != (League)(-84) && KNNEGKLGBKO != (League)(-110)) ? 1 : 2) : 0)));
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 0) ? 1597f : 848f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	public virtual void DBGKLDLCFKA()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	public void MMCPPLLDOLO(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("BuddyCard" + Singleton<GameVariables>.instance.CHOAELALEIC(OODMHGMHKGE));
		LCKKCCDKBEM();
		GFMGJIBHHIO(LCPBNBLGFIA);
	}

	public void OIEEHBHIKFF(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("GameCenterPassword" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NFOMCBLDGBG();
		MEAICLPKMPO(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public void KNAFNIHKNOI(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("menu-army-cat-shooter" + Singleton<GameVariables>.instance.CHOAELALEIC(OODMHGMHKGE));
		LFAACMKJDEA();
		CNBPJBBIMAC(LCPBNBLGFIA);
	}

	public void MJDFIACNLEI(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("D4" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NOMLBIJAOFE();
		CNBPJBBIMAC(LCPBNBLGFIA);
	}

	public override void OBCAIFMOPPA()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	public void AGBKKILKDNL(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ID_TUTORIAL_PROGRES_THROW" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NFBICINPMPI();
		IGLMKKMKCGG(LCPBNBLGFIA);
	}

	private void FNANJOCPNIN()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO == 4) ? 2 : 0) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 1) : ((KNNEGKLGBKO != (League)83) ? ((KNNEGKLGBKO == League.NoLeague || KNNEGKLGBKO == League.Gold2 || KNNEGKLGBKO == (League)(-44) || KNNEGKLGBKO == (League)33 || KNNEGKLGBKO == (League)94) ? 5 : 0) : 0)));
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 1) ? 253f : 1146f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	private void CLPAFHOBLPO()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 2) ? 1 : 7) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 1) : ((KNNEGKLGBKO == (League)(-28)) ? 1 : ((KNNEGKLGBKO == League.Silver1 || KNNEGKLGBKO == League.Gold2 || KNNEGKLGBKO == (League)(-42) || KNNEGKLGBKO == (League)88 || KNNEGKLGBKO == (League)(-9)) ? 7 : 0))));
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 1) ? 989f : 1799f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	public void AOCHCPHLCDO(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("setMacAddress" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		OMMMLFOILJM();
		IGLMKKMKCGG(LCPBNBLGFIA);
	}

	public void FNANPFCINMK()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.SelectIcon(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO, OMAJBANJKMK: true);
		GFMGJIBHHIO(LCPBNBLGFIA: false);
	}

	public void PPIACNEINOC(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 219f : 117f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 881f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1309f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1962f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(109f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void PIDOJNBFCJN(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("PROCESSING" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		CLPAFHOBLPO();
		PPIACNEINOC(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	private void MDJGNALMDJL()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO == 5) ? 1 : 0) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 0 : 0) : ((KNNEGKLGBKO != League.Champion) ? ((KNNEGKLGBKO == League.Silver1 || KNNEGKLGBKO == League.Silver1 || KNNEGKLGBKO == (League)(-47) || KNNEGKLGBKO == (League)(-17) || KNNEGKLGBKO == (League)(-9)) ? 1 : 0) : 0)));
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 0) ? 1754f : 1481f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
	}

	private void NOMLBIJAOFE()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 2) ? 1 : 1) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 0 : 0) : ((KNNEGKLGBKO != League.Silver3) ? ((KNNEGKLGBKO == League.Bronze1 || KNNEGKLGBKO == League.NoLeague || KNNEGKLGBKO == (League)(-18) || KNNEGKLGBKO == (League)20 || KNNEGKLGBKO == (League)(-36)) ? 1 : 0) : 0)));
		ENIGNONOBKM[0].gameObject.SetActive(num > 0);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 0) ? 12f : 1154f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 0);
	}

	public virtual void DKMEHOEOADL()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.BOHCNEDIJPE();
	}

	public void HLGIALNMCHE(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 36f : 1418f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 671f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(743f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 993f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(1691f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public virtual void NOELEOGDGFC()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	public void MFHLIOOLMPC(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("id" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		IINHEHDFNNA();
		FDKLKJBPFKJ(LCPBNBLGFIA);
	}

	public virtual void JJFFOGIJHIH()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	public virtual void EANNHAPAAHO()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	public void JKKKAAMBDAN(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("D2" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		FNANJOCPNIN();
		DJLFGMAMNEN(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public virtual void NNMGFLHFDGJ()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.BOHCNEDIJPE();
	}

	private void OMMMLFOILJM()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 3) ? 1 : 3) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 0) : ((KNNEGKLGBKO == (League)43) ? 1 : ((KNNEGKLGBKO == League.NoLeague || KNNEGKLGBKO == League.Gold3 || KNNEGKLGBKO == League.Silver3 || KNNEGKLGBKO == (League)83 || KNNEGKLGBKO == (League)(-113)) ? 2 : 0))));
		ENIGNONOBKM[1].gameObject.SetActive(num > 0);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 0) ? 978f : 1181f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	public void DCMNJKEPDJO()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.PDAEDHHCPJE(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO);
		MNPILLLEGME(LCPBNBLGFIA: true, AJNINHIKAFC: true);
	}

	public void MNPILLLEGME(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 972f : 1165f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1108f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1600f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 655f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(1f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void JFKIOCNILOP(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ID_WAITINGFOROPPONENTCARDS" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		CLPAFHOBLPO();
		FPCMJEPFMNO(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	private void IPEJEJFGNPA()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 7) ? 1 : 1) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 1) : ((KNNEGKLGBKO != (League)34) ? ((KNNEGKLGBKO != League.NoLeague && KNNEGKLGBKO != League.Silver1 && KNNEGKLGBKO != (League)(-9) && KNNEGKLGBKO != (League)106 && KNNEGKLGBKO != (League)(-21)) ? 1 : 0) : 0)));
		ENIGNONOBKM[0].gameObject.SetActive(num > 0);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 1) ? 595f : 1343f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
	}

	private void KBPOALPNKOD()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 6) ? 0 : 0) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 0 : 0) : ((KNNEGKLGBKO == (League)(-112)) ? 1 : ((KNNEGKLGBKO != League.NoLeague && KNNEGKLGBKO != League.NoLeague && KNNEGKLGBKO != (League)(-119) && KNNEGKLGBKO != (League)56 && KNNEGKLGBKO != (League)75) ? 1 : 4))));
		ENIGNONOBKM[0].gameObject.SetActive(num > 0);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 0) ? 589f : 1390f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	public virtual void IJHJFMOAAOC()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	public void BOHEHNJJLAM(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ID_YOUVEENTEREDALEAGUE" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		KEGJHFHDIFE();
		IGLMKKMKCGG(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public void HNJONKKFIOO(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("-" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(OODMHGMHKGE));
		AHJHGLMCPLL();
		FPCMJEPFMNO(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public virtual void DJDFKKJLHIC()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	private void IINHEHDFNNA()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO == 2) ? 1 : 0) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 0 : 0) : ((KNNEGKLGBKO == (League)43) ? 1 : ((KNNEGKLGBKO != League.Gold2 && KNNEGKLGBKO != League.NoLeague && KNNEGKLGBKO != (League)(-16) && KNNEGKLGBKO != (League)(-116) && KNNEGKLGBKO != (League)46) ? 1 : 8))));
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 1) ? 1011f : 326f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
	}

	private void BOJJFACEODG()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 3) ? 1 : 5) : ((KNNEGKLGBKO == League.NoLeague) ? ((!GameLoginManager.currentPlayer.isInBeginnersLeague) ? 1 : 0) : ((KNNEGKLGBKO == (League)(-62)) ? 1 : ((KNNEGKLGBKO == League.Silver2 || KNNEGKLGBKO == League.Bronze3 || KNNEGKLGBKO == (League)25 || KNNEGKLGBKO == League.Silver3 || KNNEGKLGBKO == (League)(-111)) ? 6 : 0))));
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 1) ? 1834f : 644f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
	}

	private void DIPIHPIEINJ()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 4) ? 1 : 4) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 0) : ((KNNEGKLGBKO != (League)(-16)) ? ((KNNEGKLGBKO != League.Gold2 && KNNEGKLGBKO != League.Silver1 && KNNEGKLGBKO != (League)(-68) && KNNEGKLGBKO != League.Bronze1 && KNNEGKLGBKO != League.Master2) ? 1 : 8) : 0)));
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 0) ? 1796f : 1829f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	public void HFPICEMOEOG(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Show Terms" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(OODMHGMHKGE));
		CAALFNPOMGB();
		EHHPDIBBPBJ(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	private void BENEOFCKFFP()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO == 0) ? 4 : 0) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 0 : 0) : ((KNNEGKLGBKO == (League)(-32)) ? 1 : ((KNNEGKLGBKO != League.Silver1 && KNNEGKLGBKO != League.Bronze1 && KNNEGKLGBKO != (League)(-30) && KNNEGKLGBKO != (League)106 && KNNEGKLGBKO != (League)125) ? 1 : 4))));
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 0) ? 36f : 1748f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 0);
	}

	public void JILPDEPBJPG(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Pack: Gold " + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NFOMCBLDGBG();
		DJLFGMAMNEN(LCPBNBLGFIA);
	}

	public void KBFDJCEIHIB()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.PDAEDHHCPJE(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO, OMAJBANJKMK: true);
		FPCMJEPFMNO(LCPBNBLGFIA: true);
	}

	public void BANCDJNFHIC(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 295f : 1927f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1860f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(849f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 732f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(1461f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void FDKLKJBPFKJ(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 706f : 293f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1393f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1142f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1206f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(1168f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	private void HPLPDCFFPGD()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 3) ? 1 : 2) : ((KNNEGKLGBKO == League.Bronze3) ? ((!GameLoginManager.currentPlayer.isInBeginnersLeague) ? 1 : 0) : ((KNNEGKLGBKO != League.Champion) ? ((KNNEGKLGBKO != League.Bronze1 && KNNEGKLGBKO != League.Silver1 && KNNEGKLGBKO != League.Gold1 && KNNEGKLGBKO != League.Elite1 && KNNEGKLGBKO != League.Master1) ? 1 : 2) : 0)));
		ENIGNONOBKM[0].gameObject.SetActive(num > 0);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 1) ? 86f : 81f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
	}

	public void PEEDFICDIOH()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.DOBHNIFHDJA(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO);
		GFMGJIBHHIO(LCPBNBLGFIA: true, AJNINHIKAFC: true);
	}

	public void MCAKGLHGEIG(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("game-card-bronze" + Singleton<GameVariables>.instance.CHOAELALEIC(OODMHGMHKGE));
		CLPAFHOBLPO();
		MNPILLLEGME(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public override void DestroyPooled()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	public void JLOBKIJJAFG()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.SelectIcon(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO);
		IGLMKKMKCGG(LCPBNBLGFIA: true, AJNINHIKAFC: true);
	}

	public void EHHLNHOFOCO(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 1726f : 393f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 923f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(952f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1599f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(378f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void Highlight(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 156f : 196f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 0.2f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(0.7f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 0.2f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(0.7f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void FPCMJEPFMNO(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 1785f : 925f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 114f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1739f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 683f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(1822f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void BJFMLCDMKDM(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("SquadMembers" + Singleton<GameVariables>.instance.CHOAELALEIC(OODMHGMHKGE));
		AHJHGLMCPLL();
		HIIKEKGBDDK(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public virtual void PONDIDGALJM()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	public void MCDGFJECILH(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("1" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		LGKOIEKKBDA();
		FPCMJEPFMNO(LCPBNBLGFIA);
	}

	public void CNBPJBBIMAC(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 104f : 840f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 753f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1768f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 871f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(1766f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public virtual void KIFFEEEDFPD()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	public void NOFMBKCBNCB(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 642f : 1105f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 883f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1745f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1759f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(235f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	private void AHJHGLMCPLL()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 2) ? 1 : 6) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 1) : ((KNNEGKLGBKO == (League)(-102)) ? 1 : ((KNNEGKLGBKO != League.Gold3 && KNNEGKLGBKO != League.Silver1 && KNNEGKLGBKO != (League)118 && KNNEGKLGBKO != (League)119 && KNNEGKLGBKO != (League)63) ? 1 : 2))));
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 0) ? 66f : 1714f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
	}

	public void DIMBEKPBCND()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.EFLNBGDAHFK(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO, OMAJBANJKMK: true);
		DJLFGMAMNEN(LCPBNBLGFIA: false, AJNINHIKAFC: true);
	}

	public void FJCAJKHBCFO()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.PDAEDHHCPJE(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO);
		GFMGJIBHHIO(LCPBNBLGFIA: false);
	}

	public virtual void JKIDPHAGFJI()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	private void LFAACMKJDEA()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 0) ? 1 : 5) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 0) : ((KNNEGKLGBKO != (League)25) ? ((KNNEGKLGBKO == League.Silver3 || KNNEGKLGBKO == League.Bronze2 || KNNEGKLGBKO == (League)95 || KNNEGKLGBKO == (League)32 || KNNEGKLGBKO == (League)(-39)) ? 6 : 0) : 0)));
		ENIGNONOBKM[1].gameObject.SetActive(num > 0);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 0) ? 1263f : 1263f);
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
	}

	public void EGMNKBFNECF(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("dialog shown = {0}, lives = {1}" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(OODMHGMHKGE));
		KBPOALPNKOD();
		Highlight(LCPBNBLGFIA);
	}

	public void MEAICLPKMPO(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 1631f : 750f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1996f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(527f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1541f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(239f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void FKPLLHHKGPB(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ID_GUI_GAMEINVITATION" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(OODMHGMHKGE));
		KBPOALPNKOD();
		DFHGFEOJFIG(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public void BKKJHDIOOGL(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ID_LEAGUE7" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(OODMHGMHKGE));
		NOMLBIJAOFE();
		IGLMKKMKCGG(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	private void CAALFNPOMGB()
	{
		int num = 0;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 2) ? 1 : 0) : ((KNNEGKLGBKO == League.Bronze3) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 1) : ((KNNEGKLGBKO == (League)81) ? 1 : ((KNNEGKLGBKO == League.NoLeague || KNNEGKLGBKO == League.Gold2 || KNNEGKLGBKO == (League)26 || KNNEGKLGBKO == (League)119 || KNNEGKLGBKO == (League)(-70)) ? 8 : 0))));
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 0) ? 1735f : 1470f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 0);
	}

	public virtual void NOJLGJDAMMK()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.BOHCNEDIJPE();
	}

	public virtual void EIOMFNNGBAE()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	public void JPFKIFKMPBE(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Create player instance at " + Singleton<GameVariables>.instance.CHOAELALEIC(OODMHGMHKGE));
		NOMLBIJAOFE();
		CNBPJBBIMAC(LCPBNBLGFIA);
	}

	public void NNIDODODOCO(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("BR" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		BENEOFCKFFP();
		MEAICLPKMPO(LCPBNBLGFIA);
	}

	public void DJLFGMAMNEN(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 32f : 1101f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1517f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(578f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 1434f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(895f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public void InitializeLeague(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		HPLPDCFFPGD();
		Highlight(LCPBNBLGFIA);
	}

	public void FLMNFLFCGLF(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("{" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		LCKKCCDKBEM();
		BANCDJNFHIC(LCPBNBLGFIA);
	}

	public void IHEKIIPKIHJ()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.ILEKNDBLNFN(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO, OMAJBANJKMK: true);
		IGLMKKMKCGG(LCPBNBLGFIA: true);
	}

	public virtual void LHCKICBJALK()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.OBCAIFMOPPA();
	}

	public void JHCIEMMKPAA(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("{0} \"{1}\" for {2}" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		LGKOIEKKBDA();
		CNBPJBBIMAC(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public void JJGOBJKADCH(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("NULL unit" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		CAALFNPOMGB();
		MNPILLLEGME(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	private void CNGIFJAFNKL()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO == 2) ? 3 : 0) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 1 : 0) : ((KNNEGKLGBKO == (League)78) ? 1 : ((KNNEGKLGBKO != League.Silver1 && KNNEGKLGBKO != League.Gold2 && KNNEGKLGBKO != (League)(-95) && KNNEGKLGBKO != (League)(-71) && KNNEGKLGBKO != (League)(-96)) ? 1 : 6))));
		ENIGNONOBKM[0].gameObject.SetActive(num > 0);
		ENIGNONOBKM[1].transform.localPosition = ENIGNONOBKM[1].transform.localPosition.ReplaceX((num <= 0) ? 1731f : 1817f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	public void HCHANFFKFEN(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ID_PROLONGYOURVIP" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		IINHEHDFNNA();
		HIIKEKGBDDK(LCPBNBLGFIA, AJNINHIKAFC: true);
	}

	public void NOJMKJGIGAI()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.HPGFGMBMNPM(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO);
		MEAICLPKMPO(LCPBNBLGFIA: false, AJNINHIKAFC: true);
	}

	private void LGKOIEKKBDA()
	{
		int num = 1;
		num = (BAKGJEGCNCI ? ((ALGBCPEGLCO != 8) ? 1 : 4) : ((KNNEGKLGBKO == League.NoLeague) ? (GameLoginManager.currentPlayer.isInBeginnersLeague ? 0 : 0) : ((KNNEGKLGBKO != (League)(-27)) ? ((KNNEGKLGBKO == League.Bronze1 || KNNEGKLGBKO == League.Silver2 || KNNEGKLGBKO == (League)(-100) || KNNEGKLGBKO == League.Elite3 || KNNEGKLGBKO == (League)(-87)) ? 2 : 0) : 0)));
		ENIGNONOBKM[1].gameObject.SetActive(num > 1);
		ENIGNONOBKM[0].transform.localPosition = ENIGNONOBKM[0].transform.localPosition.ReplaceX((num <= 1) ? 733f : 1505f);
		ENIGNONOBKM[0].gameObject.SetActive(num > 1);
	}

	public void AAGGMCHDNAC()
	{
		GuiScreenSingle<LeaguesScreen>.instance.BMNDININJCE.EPNMOFNHJDB.FKCGLFHBCCN(BAKGJEGCNCI, ALGBCPEGLCO, KNNEGKLGBKO, OMAJBANJKMK: true);
		BANCDJNFHIC(LCPBNBLGFIA: true);
	}

	public virtual void IFHBPEAKGDN()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.BOHCNEDIJPE();
	}

	public void InitializeBeginners(int OODMHGMHKGE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = true;
		ALGBCPEGLCO = OODMHGMHKGE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("Medals/" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(OODMHGMHKGE));
		HPLPDCFFPGD();
		Highlight(LCPBNBLGFIA);
	}

	public virtual void ICCLFDKECEA()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.DestroyPooled();
	}

	public void ICCCFMPGPGG(League BMNDININJCE, bool LCPBNBLGFIA)
	{
		BAKGJEGCNCI = false;
		KNNEGKLGBKO = BMNDININJCE;
		BFLBNOPDOAE.mainTexture = Resources.Load<Texture>("ID_SALEPERCENTLINE" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		KJBACHGBCNF();
		MNPILLLEGME(LCPBNBLGFIA);
	}

	public void IGLMKKMKCGG(bool LCPBNBLGFIA, bool AJNINHIKAFC = false)
	{
		float x = BFLBNOPDOAE.transform.localScale.x;
		float num = ((!LCPBNBLGFIA) ? 608f : 381f);
		if (AJNINHIKAFC && x != num)
		{
			TweenColor.Begin(BFLBNOPDOAE.gameObject, 1316f, (!LCPBNBLGFIA) ? Color.white.ReplaceA(1253f) : Color.white);
			TweenScale.Begin(BFLBNOPDOAE.gameObject, 629f, BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num));
			return;
		}
		TweenColor component = BFLBNOPDOAE.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = BFLBNOPDOAE.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		BFLBNOPDOAE.color = ((!LCPBNBLGFIA) ? Color.white.ReplaceA(217f) : Color.white);
		BFLBNOPDOAE.transform.localScale = BFLBNOPDOAE.transform.localScale.ReplaceXY(num, num);
	}

	public virtual void GLAFLMBJAMF()
	{
		BFLBNOPDOAE.mainTexture = null;
		base.OBCAIFMOPPA();
	}
}
