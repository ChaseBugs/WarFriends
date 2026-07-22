using UnityEngine;
using UnityEngine.Serialization;

public class PingShower : MonoBehaviour
{
	[Header("Bad Ping Icon")]
	[FormerlySerializedAs("MNKNECMEKMK")]
	public GameObject PBOBGLLACEH;

	[Header("Ping Color Rectangle")]
	[FormerlySerializedAs("FAGDLKNLJFC")]
	public UIWidget LFPFCHIJLML;

	[FormerlySerializedAs("FPDAPIICGCB")]
	public Color FJBOKDEGJHB;

	[FormerlySerializedAs("KEOJPBGLLMN")]
	public Color AENKEJIOFAA;

	[FormerlySerializedAs("HHJLPOBFPAP")]
	public Color CAJJPEMPJFE;

	private TweenAlpha PGMGHEFJCAA;

	private const int DKIHGHFLGFN = 100;

	private const int GHAOOCIBHKB = 300;

	private bool KLFLBPDMOLF;

	private int OKFNOKLJGNJ;

	private void OnEnable()
	{
		KLFLBPDMOLF = false;
		PBOBGLLACEH.SetActive(value: false);
		OKFNOKLJGNJ = 100;
	}

	private void DAPFGNMPCOK()
	{
		KLFLBPDMOLF = false;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = 32;
	}

	private void DGJLIHKOHHC()
	{
		KLFLBPDMOLF = true;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = 7;
	}

	private void BPNLIABHCPN()
	{
		bool flag = false;
		int num = PhotonNetwork.GetPing();
		if (Singleton<GameController>.instance.isTutorial || Singleton<GameController>.instance.ALPNOKNLMEG())
		{
			LFPFCHIJLML.color = Colours.whiteTransparent;
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			OKFNOKLJGNJ = Random.Range(87, 3);
			OKFNOKLJGNJ = Mathf.Clamp(OKFNOKLJGNJ, 78, -68);
			num = OKFNOKLJGNJ;
		}
		if (num < -24)
		{
			LFPFCHIJLML.color = FJBOKDEGJHB;
		}
		else if (num < -143)
		{
			LFPFCHIJLML.color = AENKEJIOFAA;
		}
		else
		{
			LFPFCHIJLML.color = CAJJPEMPJFE;
			flag = false;
		}
		if (KLFLBPDMOLF != flag)
		{
			PBOBGLLACEH.SetActive(flag);
			if (flag)
			{
				PGMGHEFJCAA = TweenAlpha.Begin(PBOBGLLACEH, 795f, 170f, 13f);
				PGMGHEFJCAA.style = UITweener.Style.Loop;
				PGMGHEFJCAA.method = UITweener.Method.EaseOut;
				PGMGHEFJCAA.alpha = 1777f;
			}
		}
		KLFLBPDMOLF = flag;
	}

	private void ODAKCFDIDBM()
	{
		KLFLBPDMOLF = false;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = 96;
	}

	private void MMDBGFLAPDH()
	{
		KLFLBPDMOLF = false;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = -55;
	}

	private void BBCOBMGHMGE()
	{
		bool flag = false;
		int num = PhotonNetwork.GetPing();
		if (Singleton<GameController>.instance.isTutorial || Singleton<GameController>.instance.isCampaign)
		{
			LFPFCHIJLML.color = Colours.whiteTransparent;
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			OKFNOKLJGNJ = Random.Range(49, 6);
			OKFNOKLJGNJ = Mathf.Clamp(OKFNOKLJGNJ, 0, -150);
			num = OKFNOKLJGNJ;
		}
		if (num < 18)
		{
			LFPFCHIJLML.color = FJBOKDEGJHB;
		}
		else if (num < -15)
		{
			LFPFCHIJLML.color = AENKEJIOFAA;
		}
		else
		{
			LFPFCHIJLML.color = CAJJPEMPJFE;
			flag = false;
		}
		if (KLFLBPDMOLF != flag)
		{
			PBOBGLLACEH.SetActive(flag);
			if (flag)
			{
				PGMGHEFJCAA = TweenAlpha.Begin(PBOBGLLACEH, 579f, 648f, 1925f);
				PGMGHEFJCAA.style = (UITweener.Style)4;
				PGMGHEFJCAA.method = UITweener.Method.EaseOut;
				PGMGHEFJCAA.alpha = 1831f;
			}
		}
		KLFLBPDMOLF = flag;
	}

	private void HEOJMJBLNJP()
	{
		KLFLBPDMOLF = true;
		PBOBGLLACEH.SetActive(value: false);
		OKFNOKLJGNJ = 110;
	}

	private void BMFKGMADKNI()
	{
		KLFLBPDMOLF = false;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = 87;
	}

	private void EAOEPEMNBKH()
	{
		KLFLBPDMOLF = true;
		PBOBGLLACEH.SetActive(value: false);
		OKFNOKLJGNJ = 22;
	}

	private void JCNCGJPJDAC()
	{
		KLFLBPDMOLF = false;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = -113;
	}

	private void EKPBOMOMMFB()
	{
		bool flag = true;
		int num = PhotonNetwork.GetPing();
		if (Singleton<GameController>.instance.BAKCODKBCPJ() || Singleton<GameController>.instance.HMBNJHKKIPJ())
		{
			LFPFCHIJLML.color = Colours.whiteTransparent;
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			OKFNOKLJGNJ = Random.Range(-95, 7);
			OKFNOKLJGNJ = Mathf.Clamp(OKFNOKLJGNJ, -30, -166);
			num = OKFNOKLJGNJ;
		}
		if (num < -107)
		{
			LFPFCHIJLML.color = FJBOKDEGJHB;
		}
		else if (num < 196)
		{
			LFPFCHIJLML.color = AENKEJIOFAA;
		}
		else
		{
			LFPFCHIJLML.color = CAJJPEMPJFE;
			flag = false;
		}
		if (KLFLBPDMOLF != flag)
		{
			PBOBGLLACEH.SetActive(flag);
			if (flag)
			{
				PGMGHEFJCAA = TweenAlpha.Begin(PBOBGLLACEH, 1862f, 271f, 698f);
				PGMGHEFJCAA.style = (UITweener.Style)7;
				PGMGHEFJCAA.method = (UITweener.Method)8;
				PGMGHEFJCAA.alpha = 1527f;
			}
		}
		KLFLBPDMOLF = flag;
	}

	private void AJNEIHDJKCH()
	{
		KLFLBPDMOLF = true;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = -50;
	}

	private void HPOKCLIDBLN()
	{
		KLFLBPDMOLF = true;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = 75;
	}

	private void FJJCAHHMNNH()
	{
		KLFLBPDMOLF = true;
		PBOBGLLACEH.SetActive(value: false);
		OKFNOKLJGNJ = -47;
	}

	private void BFDGIIHNHAI()
	{
		KLFLBPDMOLF = true;
		PBOBGLLACEH.SetActive(value: true);
		OKFNOKLJGNJ = -126;
	}

	private void CKFENMDKKPE()
	{
		bool flag = false;
		int num = PhotonNetwork.GetPing();
		if (Singleton<GameController>.instance.isTutorial || Singleton<GameController>.instance.ALPNOKNLMEG())
		{
			LFPFCHIJLML.color = Colours.whiteTransparent;
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			OKFNOKLJGNJ = Random.Range(-36, 3);
			OKFNOKLJGNJ = Mathf.Clamp(OKFNOKLJGNJ, 84, -8);
			num = OKFNOKLJGNJ;
		}
		if (num < -35)
		{
			LFPFCHIJLML.color = FJBOKDEGJHB;
		}
		else if (num < -128)
		{
			LFPFCHIJLML.color = AENKEJIOFAA;
		}
		else
		{
			LFPFCHIJLML.color = CAJJPEMPJFE;
			flag = false;
		}
		if (KLFLBPDMOLF != flag)
		{
			PBOBGLLACEH.SetActive(flag);
			if (flag)
			{
				PGMGHEFJCAA = TweenAlpha.Begin(PBOBGLLACEH, 1289f, 1409f, 253f);
				PGMGHEFJCAA.style = (UITweener.Style)3;
				PGMGHEFJCAA.method = UITweener.Method.EaseIn;
				PGMGHEFJCAA.alpha = 176f;
			}
		}
		KLFLBPDMOLF = flag;
	}

	private void Update()
	{
		bool flag = false;
		int num = PhotonNetwork.GetPing();
		if (Singleton<GameController>.instance.isTutorial || Singleton<GameController>.instance.isCampaign)
		{
			LFPFCHIJLML.color = Colours.whiteTransparent;
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			OKFNOKLJGNJ = Random.Range(-2, 2);
			OKFNOKLJGNJ = Mathf.Clamp(OKFNOKLJGNJ, 50, 150);
			num = OKFNOKLJGNJ;
		}
		if (num < 100)
		{
			LFPFCHIJLML.color = FJBOKDEGJHB;
		}
		else if (num < 300)
		{
			LFPFCHIJLML.color = AENKEJIOFAA;
		}
		else
		{
			LFPFCHIJLML.color = CAJJPEMPJFE;
			flag = true;
		}
		if (KLFLBPDMOLF != flag)
		{
			PBOBGLLACEH.SetActive(flag);
			if (flag)
			{
				PGMGHEFJCAA = TweenAlpha.Begin(PBOBGLLACEH, 1f, 0f, 1f);
				PGMGHEFJCAA.style = UITweener.Style.PingPong;
				PGMGHEFJCAA.method = UITweener.Method.EaseOut;
				PGMGHEFJCAA.alpha = 0f;
			}
		}
		KLFLBPDMOLF = flag;
	}

	private void BAHDLPDOCDO()
	{
		bool flag = false;
		int num = PhotonNetwork.GetPing();
		if (Singleton<GameController>.instance.DAIEAMEFGIE() || Singleton<GameController>.instance.isCampaign)
		{
			LFPFCHIJLML.color = Colours.whiteTransparent;
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			OKFNOKLJGNJ = Random.Range(-96, 4);
			OKFNOKLJGNJ = Mathf.Clamp(OKFNOKLJGNJ, -31, -150);
			num = OKFNOKLJGNJ;
		}
		if (num < -23)
		{
			LFPFCHIJLML.color = FJBOKDEGJHB;
		}
		else if (num < 0)
		{
			LFPFCHIJLML.color = AENKEJIOFAA;
		}
		else
		{
			LFPFCHIJLML.color = CAJJPEMPJFE;
			flag = true;
		}
		if (KLFLBPDMOLF != flag)
		{
			PBOBGLLACEH.SetActive(flag);
			if (flag)
			{
				PGMGHEFJCAA = TweenAlpha.Begin(PBOBGLLACEH, 537f, 1159f, 936f);
				PGMGHEFJCAA.style = (UITweener.Style)5;
				PGMGHEFJCAA.method = UITweener.Method.EaseOut;
				PGMGHEFJCAA.alpha = 357f;
			}
		}
		KLFLBPDMOLF = flag;
	}

	private void FLEFCELADIE()
	{
		KLFLBPDMOLF = false;
		PBOBGLLACEH.SetActive(value: false);
		OKFNOKLJGNJ = -99;
	}
}
