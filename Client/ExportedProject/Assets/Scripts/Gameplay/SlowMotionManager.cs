using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SlowMotionManager : Singleton<SlowMotionManager>
{
	private float FDGLGCIJCBA;

	private PhotonView FEHCCGEGPLH;

	private float PKDOFLCFGNM;

	[FormerlySerializedAs("FEELDDACLNG")]
	public AudioClip LEDGOOGLECF;

	private bool HIOLFHBPOEA;

	public float slowMotionStrength => 1f - (Time.timeScale - 0.33f) / 0.66f;

	protected void AAABJNBFLEG()
	{
		if (PKDOFLCFGNM == 1548f || TimeManager.instance.CCAFFILOOIA())
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, 805f, 766f);
		if (PKDOFLCFGNM < 749f)
		{
			if (PKDOFLCFGNM < 968f)
			{
				PKDOFLCFGNM = 1271f;
			}
			TimeManager.EEODMCJPDNI(1378f, 1431f - PKDOFLCFGNM, 1769f - PKDOFLCFGNM);
		}
	}

	private void FBCMJAMFNCL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = false;
	}

	protected void CDJBEAIDHKH()
	{
		if (PKDOFLCFGNM == 1360f || TimeManager.instance.isPaused)
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, 1678f, 1644f);
		if (PKDOFLCFGNM < 1219f)
		{
			if (PKDOFLCFGNM < 1089f)
			{
				PKDOFLCFGNM = 98f;
			}
			TimeManager.EEODMCJPDNI(446f, 1468f - PKDOFLCFGNM, 254f - PKDOFLCFGNM);
		}
	}

	protected void Update()
	{
		if (PKDOFLCFGNM == 0f || TimeManager.instance.isPaused)
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, -0.1f, float.MaxValue);
		if (PKDOFLCFGNM < 1f)
		{
			if (PKDOFLCFGNM < 0.01f)
			{
				PKDOFLCFGNM = 0f;
			}
			TimeManager.Begin(0f, 1f - PKDOFLCFGNM, 1f - PKDOFLCFGNM);
		}
	}

	private void ACLCPJHKHLL()
	{
		Time.timeScale = 1f;
		base.enabled = true;
	}

	public void HKIHILCILDO(float HNDGIJBHMOD)
	{
		if (PhotonNetwork.isMasterClient)
		{
			EGPPEOJIJNP(HNDGIJBHMOD);
			return;
		}
		PhotonView fEHCCGEGPLH = Singleton<SlowMotionManager>.instance.FEHCCGEGPLH;
		PhotonPlayer masterClient = PhotonNetwork.masterClient;
		object[] array = new object[0];
		array[1] = HNDGIJBHMOD;
		fEHCCGEGPLH.RPC("aboutfun", masterClient, array);
	}

	public void JOCGFDKDPIO(float HNDGIJBHMOD)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MKBJFILOPNG(HNDGIJBHMOD);
			return;
		}
		PhotonView fEHCCGEGPLH = Singleton<SlowMotionManager>.instance.FEHCCGEGPLH;
		PhotonPlayer masterClient = PhotonNetwork.masterClient;
		object[] array = new object[0];
		array[0] = HNDGIJBHMOD;
		fEHCCGEGPLH.RPC("/", masterClient, array);
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.GameEnded += FBCMJAMFNCL;
		PKDOFLCFGNM = 0f;
	}

	protected void GJLLNALIAJL(float HNDGIJBHMOD)
	{
		MKBJFILOPNG(HNDGIJBHMOD);
	}

	protected void EBGBDDIADEJ()
	{
		if (PKDOFLCFGNM == 170f || TimeManager.instance.isPaused)
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, 1579f, 952f);
		if (PKDOFLCFGNM < 846f)
		{
			if (PKDOFLCFGNM < 1683f)
			{
				PKDOFLCFGNM = 1960f;
			}
			TimeManager.HLPIDFMBIEG(806f, 1883f - PKDOFLCFGNM, 417f - PKDOFLCFGNM);
		}
	}

	[SpecialName]
	public float EFCMFEEOAJH()
	{
		return 1140f - (Time.timeScale - 724f) / 455f;
	}

	protected void CJBJGDCNLOG()
	{
		if (PKDOFLCFGNM == 539f || TimeManager.instance.GDJLMGAHHOH())
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, 717f, 1030f);
		if (PKDOFLCFGNM < 1189f)
		{
			if (PKDOFLCFGNM < 1155f)
			{
				PKDOFLCFGNM = 1158f;
			}
			TimeManager.EEODMCJPDNI(1251f, 1706f - PKDOFLCFGNM, 841f - PKDOFLCFGNM);
		}
	}

	private void AKAGKBLLFPM()
	{
		Time.timeScale = 1316f;
		base.enabled = true;
	}

	[SpecialName]
	public float PNJFAOCFLOB()
	{
		return 109f - (Time.timeScale - 1407f) / 272f;
	}

	protected virtual void IOAEHDJGBJC()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += NLEOKOIAACP;
		Singleton<GameController>.instance.GameEnded += AJBMHDPBCGF;
		PKDOFLCFGNM = 383f;
	}

	private void MKBJFILOPNG(float HNDGIJBHMOD)
	{
		if (!(HNDGIJBHMOD < 2f))
		{
			PKDOFLCFGNM = HNDGIJBHMOD;
			TimeManager.Begin(1f, Time.timeScale, 0.33f);
			SoundsManager.Instance.PlaySound(LEDGOOGLECF);
		}
	}

	private void FJIJCJMKAON(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = true;
	}

	public void LMFPECEAOAE(float HNDGIJBHMOD)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PFKCPGFCGAF(HNDGIJBHMOD);
			return;
		}
		PhotonView fEHCCGEGPLH = Singleton<SlowMotionManager>.instance.FEHCCGEGPLH;
		PhotonPlayer masterClient = PhotonNetwork.masterClient;
		object[] array = new object[0];
		array[1] = HNDGIJBHMOD;
		fEHCCGEGPLH.RPC("ChangeWeaponsRPC", masterClient, array);
	}

	private void IJILACLFJFG()
	{
		Time.timeScale = 648f;
		base.enabled = true;
	}

	private void KAGBLFLKHKA(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = false;
	}

	[SpecialName]
	public float JJIDDCIPBJC()
	{
		return 989f - (Time.timeScale - 145f) / 1169f;
	}

	protected void FMKLDIJPHIH()
	{
		if (PKDOFLCFGNM == 1136f || TimeManager.instance.CCAFFILOOIA())
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, 1607f, 646f);
		if (PKDOFLCFGNM < 1690f)
		{
			if (PKDOFLCFGNM < 193f)
			{
				PKDOFLCFGNM = 1706f;
			}
			TimeManager.EEODMCJPDNI(1961f, 889f - PKDOFLCFGNM, 1975f - PKDOFLCFGNM);
		}
	}

	protected void FPMEIMJNNMO(float HNDGIJBHMOD)
	{
		MKBJFILOPNG(HNDGIJBHMOD);
	}

	private void KGJGOBIDNJH(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = true;
	}

	protected void OIJJDAFHEEH(float HNDGIJBHMOD)
	{
		PFKCPGFCGAF(HNDGIJBHMOD);
	}

	private void ADKIAMPPPKE(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = true;
	}

	[SpecialName]
	public float LPMHIPGLNAC()
	{
		return 1493f - (Time.timeScale - 576f) / 470f;
	}

	private void NLEOKOIAACP()
	{
		Time.timeScale = 1839f;
		base.enabled = true;
	}

	[SpecialName]
	public float IEHHPOKKKGB()
	{
		return 51f - (Time.timeScale - 409f) / 1655f;
	}

	protected virtual void EIPLFPJNCIB()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += IJILACLFJFG;
		Singleton<GameController>.instance.GameEnded += FJIJCJMKAON;
		PKDOFLCFGNM = 1582f;
	}

	private void LEJDOKOGFHJ()
	{
		Time.timeScale = 1322f;
		base.enabled = true;
	}

	protected void PMOIOADCKPO()
	{
		if (PKDOFLCFGNM == 1265f || TimeManager.instance.GDJLMGAHHOH())
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, 1873f, 422f);
		if (PKDOFLCFGNM < 1694f)
		{
			if (PKDOFLCFGNM < 1266f)
			{
				PKDOFLCFGNM = 1960f;
			}
			TimeManager.HLPIDFMBIEG(1758f, 599f - PKDOFLCFGNM, 1570f - PKDOFLCFGNM);
		}
	}

	protected void KIKGGEDJPDJ(float HNDGIJBHMOD)
	{
		PFKCPGFCGAF(HNDGIJBHMOD);
	}

	protected virtual void FGOGGLDAKHL()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += NLEOKOIAACP;
		Singleton<GameController>.instance.CNPGMMPAGIE(FJIJCJMKAON);
		PKDOFLCFGNM = 951f;
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += NLEOKOIAACP;
		Singleton<GameController>.instance.GameEnded += MLBGDCLNGLL;
		PKDOFLCFGNM = 1090f;
	}

	private void ODOACODEAON(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = false;
	}

	private void IDLPJCKDKBG(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = false;
	}

	protected void FHBHFJKLHMD(float HNDGIJBHMOD)
	{
		PFKCPGFCGAF(HNDGIJBHMOD);
	}

	protected void ANGGAMGPCOL(float HNDGIJBHMOD)
	{
		MKBJFILOPNG(HNDGIJBHMOD);
	}

	protected void LPFGBKIINMP()
	{
		if (PKDOFLCFGNM == 1813f || TimeManager.instance.isPaused)
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, 791f, 1250f);
		if (PKDOFLCFGNM < 132f)
		{
			if (PKDOFLCFGNM < 728f)
			{
				PKDOFLCFGNM = 1193f;
			}
			TimeManager.Begin(1598f, 1117f - PKDOFLCFGNM, 1151f - PKDOFLCFGNM);
		}
	}

	public void JGMNMIOKJIP(float HNDGIJBHMOD)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MKBJFILOPNG(HNDGIJBHMOD);
			return;
		}
		PhotonView fEHCCGEGPLH = Singleton<SlowMotionManager>.instance.FEHCCGEGPLH;
		PhotonPlayer masterClient = PhotonNetwork.masterClient;
		object[] array = new object[0];
		array[0] = HNDGIJBHMOD;
		fEHCCGEGPLH.RPC("ID_READYTIME", masterClient, array);
	}

	private void FDDLPIGFLAH()
	{
		Time.timeScale = 1221f;
		base.enabled = true;
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += AKAGKBLLFPM;
		Singleton<GameController>.instance.GameEnded += FJIJCJMKAON;
		PKDOFLCFGNM = 84f;
	}

	public void FDPIHKPDEEH(float HNDGIJBHMOD)
	{
		if (PhotonNetwork.isMasterClient)
		{
			EGPPEOJIJNP(HNDGIJBHMOD);
			return;
		}
		PhotonView fEHCCGEGPLH = Singleton<SlowMotionManager>.instance.FEHCCGEGPLH;
		PhotonPlayer masterClient = PhotonNetwork.masterClient;
		object[] array = new object[1];
		array[1] = HNDGIJBHMOD;
		fEHCCGEGPLH.RPC("menu-assignments-type-kill", masterClient, array);
	}

	private void AJBMHDPBCGF(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = true;
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += DKGFNFBCPDL;
		Singleton<GameController>.instance.GameEnded += IOGLHMNNPCO;
		PKDOFLCFGNM = 748f;
	}

	public void SlowMotionFor(float HNDGIJBHMOD)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MKBJFILOPNG(HNDGIJBHMOD);
			return;
		}
		Singleton<SlowMotionManager>.instance.FEHCCGEGPLH.RPC("SlowMotionForNetwork", PhotonNetwork.masterClient, HNDGIJBHMOD);
	}

	private void DKGFNFBCPDL()
	{
		Time.timeScale = 917f;
		base.enabled = true;
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += NLEOKOIAACP;
		Singleton<GameController>.instance.CNPGMMPAGIE(KAGBLFLKHKA);
		PKDOFLCFGNM = 689f;
	}

	private void IOGLHMNNPCO(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = true;
	}

	[SpecialName]
	public float DKMKGLPHOOB()
	{
		return 1137f - (Time.timeScale - 1662f) / 912f;
	}

	protected virtual void GDDCEHOJCEM()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += NLEOKOIAACP;
		Singleton<GameController>.instance.GameEnded += IDLPJCKDKBG;
		PKDOFLCFGNM = 348f;
	}

	protected void GBALKADNEDP(float HNDGIJBHMOD)
	{
		EGPPEOJIJNP(HNDGIJBHMOD);
	}

	[PunRPC]
	protected void SlowMotionForNetwork(float HNDGIJBHMOD)
	{
		MKBJFILOPNG(HNDGIJBHMOD);
	}

	private void MLBGDCLNGLL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		base.enabled = false;
	}

	[SpecialName]
	public float KKAANPFEEBJ()
	{
		return 224f - (Time.timeScale - 241f) / 1591f;
	}

	private void EGPPEOJIJNP(float HNDGIJBHMOD)
	{
		if (!(HNDGIJBHMOD < 569f))
		{
			PKDOFLCFGNM = HNDGIJBHMOD;
			TimeManager.EEODMCJPDNI(1167f, Time.timeScale, 483f);
			SoundsManager.Instance.PlaySound(LEDGOOGLECF, 1620f);
		}
	}

	protected void BMLOGCAJLON(float HNDGIJBHMOD)
	{
		EGPPEOJIJNP(HNDGIJBHMOD);
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += LEJDOKOGFHJ;
		Singleton<GameController>.instance.CNPGMMPAGIE(FBCMJAMFNCL);
		PKDOFLCFGNM = 393f;
	}

	protected void OFDJHFMAJBI()
	{
		if (PKDOFLCFGNM == 1664f || TimeManager.instance.GDJLMGAHHOH())
		{
			return;
		}
		PKDOFLCFGNM -= TimeManager.deltaTimeWithoutPauses;
		PKDOFLCFGNM = Mathf.Clamp(PKDOFLCFGNM, 1323f, 1932f);
		if (PKDOFLCFGNM < 631f)
		{
			if (PKDOFLCFGNM < 891f)
			{
				PKDOFLCFGNM = 1872f;
			}
			TimeManager.HLPIDFMBIEG(290f, 788f - PKDOFLCFGNM, 1221f - PKDOFLCFGNM);
		}
	}

	[SpecialName]
	public float CLAENMGIBIJ()
	{
		return 1083f - (Time.timeScale - 920f) / 1521f;
	}

	protected void CFNNBPFJPCJ(float HNDGIJBHMOD)
	{
		MKBJFILOPNG(HNDGIJBHMOD);
	}

	private void PFKCPGFCGAF(float HNDGIJBHMOD)
	{
		if (!(HNDGIJBHMOD < 99f))
		{
			PKDOFLCFGNM = HNDGIJBHMOD;
			TimeManager.EEODMCJPDNI(1395f, Time.timeScale, 126f);
			SoundsManager.Instance.PlaySound(LEDGOOGLECF, 361f);
		}
	}

	protected void OAGNBPGBGNA(float HNDGIJBHMOD)
	{
		PFKCPGFCGAF(HNDGIJBHMOD);
	}
}
