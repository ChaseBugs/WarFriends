using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PhotonCachedRPC : Core_BaseScript
{
	private struct AJPDOPBPEHE
	{
		public string FKEBENDDFPJ;

		public object[] ABMLHILNNDM;

		public PhotonTargets MKIPAEDAADL;

		public PhotonView BMNDKOMNION;

		public PhotonPlayer KHLGDCHJJPB;
	}

	private static List<PhotonCachedRPC> JGMOKFILMHN = new List<PhotonCachedRPC>();

	private readonly List<AJPDOPBPEHE> CMFKCGEBLBC = new List<AJPDOPBPEHE>();

	public static List<PhotonCachedRPC> photonCachedRpcs
	{
		get
		{
			return JGMOKFILMHN;
		}
	}

	public static void KLDIEKLCBKC(PhotonView BMNDKOMNION, string FKEBENDDFPJ, PhotonPlayer PJJMGBAKLPK, object[] ABMLHILNNDM)
	{
		if (PhotonConnectionManager.isInRoom)
		{
			BMNDKOMNION.RPC(FKEBENDDFPJ, PJJMGBAKLPK, ABMLHILNNDM);
			return;
		}
		PhotonCachedRPC photonCachedRPC = BMNDKOMNION.gameObject.GetComponent<PhotonCachedRPC>() ?? BMNDKOMNION.gameObject.AddComponent<PhotonCachedRPC>();
		photonCachedRPC.KFCAGHNBKCD(BMNDKOMNION, FKEBENDDFPJ, PhotonTargets.All, PJJMGBAKLPK, ABMLHILNNDM);
	}

	[SpecialName]
	public static List<PhotonCachedRPC> AIEEAOODFNM()
	{
		return JGMOKFILMHN;
	}

	private void FJDACAACLLI()
	{
		CMFKCGEBLBC.Clear();
	}

	private void OnEnable()
	{
		JGMOKFILMHN.Add(this);
	}

	public static void SendOfflineRPC(PhotonView BMNDKOMNION, string FKEBENDDFPJ, PhotonTargets MKIPAEDAADL, params object[] ABMLHILNNDM)
	{
		if (PhotonConnectionManager.isInRoom)
		{
			BMNDKOMNION.RPC(FKEBENDDFPJ, MKIPAEDAADL, ABMLHILNNDM);
			return;
		}
		PhotonCachedRPC photonCachedRPC = BMNDKOMNION.gameObject.GetComponent<PhotonCachedRPC>() ?? BMNDKOMNION.gameObject.AddComponent<PhotonCachedRPC>();
		photonCachedRPC.KFCAGHNBKCD(BMNDKOMNION, FKEBENDDFPJ, MKIPAEDAADL, null, ABMLHILNNDM);
	}

	protected void ECFIMCCNBBN()
	{
		if (!PhotonConnectionManager.isInRoom || CMFKCGEBLBC.Count <= 0)
		{
			return;
		}
		foreach (AJPDOPBPEHE item in CMFKCGEBLBC)
		{
			Debug.Log(string.Format("({0}\u00a0/\u00a0{1})", item.FKEBENDDFPJ, item.ABMLHILNNDM));
			if (item.KHLGDCHJJPB != null)
			{
				item.BMNDKOMNION.RPC(item.FKEBENDDFPJ, item.KHLGDCHJJPB, item.ABMLHILNNDM);
			}
			else
			{
				item.BMNDKOMNION.RPC(item.FKEBENDDFPJ, item.MKIPAEDAADL, item.ABMLHILNNDM);
			}
		}
		CMFKCGEBLBC.Clear();
	}

	private void EFADFEJNAEE()
	{
		JGMOKFILMHN.Add(this);
	}

	protected void DIOAOBFDPMH()
	{
		if (!PhotonConnectionManager.isInRoom || CMFKCGEBLBC.Count <= 0)
		{
			return;
		}
		foreach (AJPDOPBPEHE item in CMFKCGEBLBC)
		{
			Debug.Log(string.Format(" (#", item.FKEBENDDFPJ, item.ABMLHILNNDM));
			if (item.KHLGDCHJJPB != null)
			{
				item.BMNDKOMNION.RPC(item.FKEBENDDFPJ, item.KHLGDCHJJPB, item.ABMLHILNNDM);
			}
			else
			{
				item.BMNDKOMNION.RPC(item.FKEBENDDFPJ, item.MKIPAEDAADL, item.ABMLHILNNDM);
			}
		}
		CMFKCGEBLBC.Clear();
	}

	public static void GDKAAHEOHAM(PhotonView BMNDKOMNION, string FKEBENDDFPJ, PhotonPlayer PJJMGBAKLPK, object[] ABMLHILNNDM)
	{
		if (PhotonConnectionManager.LDBPFFGDKNE())
		{
			BMNDKOMNION.RPC(FKEBENDDFPJ, PJJMGBAKLPK, ABMLHILNNDM);
			return;
		}
		PhotonCachedRPC photonCachedRPC = BMNDKOMNION.gameObject.GetComponent<PhotonCachedRPC>() ?? BMNDKOMNION.gameObject.AddComponent<PhotonCachedRPC>();
		photonCachedRPC.KFCAGHNBKCD(BMNDKOMNION, FKEBENDDFPJ, PhotonTargets.All, PJJMGBAKLPK, ABMLHILNNDM);
	}

	[SpecialName]
	public static List<PhotonCachedRPC> KAEKBIAGPDA()
	{
		return JGMOKFILMHN;
	}

	protected void Update()
	{
		if (!PhotonConnectionManager.isInRoom || CMFKCGEBLBC.Count <= 0)
		{
			return;
		}
		foreach (AJPDOPBPEHE item in CMFKCGEBLBC)
		{
			Debug.Log(string.Format("Executing Oflline RPC {0} {1}", item.FKEBENDDFPJ, item.ABMLHILNNDM));
			if (item.KHLGDCHJJPB != null)
			{
				item.BMNDKOMNION.RPC(item.FKEBENDDFPJ, item.KHLGDCHJJPB, item.ABMLHILNNDM);
			}
			else
			{
				item.BMNDKOMNION.RPC(item.FKEBENDDFPJ, item.MKIPAEDAADL, item.ABMLHILNNDM);
			}
		}
		CMFKCGEBLBC.Clear();
	}

	public static void KNFFBADDJFO(PhotonView BMNDKOMNION, string FKEBENDDFPJ, PhotonTargets MKIPAEDAADL, object[] ABMLHILNNDM)
	{
		if (PhotonConnectionManager.LDBPFFGDKNE())
		{
			BMNDKOMNION.RPC(FKEBENDDFPJ, MKIPAEDAADL, ABMLHILNNDM);
			return;
		}
		PhotonCachedRPC photonCachedRPC = BMNDKOMNION.gameObject.GetComponent<PhotonCachedRPC>() ?? BMNDKOMNION.gameObject.AddComponent<PhotonCachedRPC>();
		photonCachedRPC.KFCAGHNBKCD(BMNDKOMNION, FKEBENDDFPJ, MKIPAEDAADL, null, ABMLHILNNDM);
	}

	public static void OKCAGFDJEMP(PhotonView BMNDKOMNION, string FKEBENDDFPJ, PhotonPlayer PJJMGBAKLPK, object[] ABMLHILNNDM)
	{
		if (PhotonConnectionManager.NEPIMEJCAMC())
		{
			BMNDKOMNION.RPC(FKEBENDDFPJ, PJJMGBAKLPK, ABMLHILNNDM);
			return;
		}
		PhotonCachedRPC photonCachedRPC = BMNDKOMNION.gameObject.GetComponent<PhotonCachedRPC>() ?? BMNDKOMNION.gameObject.AddComponent<PhotonCachedRPC>();
		photonCachedRPC.KFCAGHNBKCD(BMNDKOMNION, FKEBENDDFPJ, PhotonTargets.All, PJJMGBAKLPK, ABMLHILNNDM);
	}

	public static void SendOfflineRPC(PhotonView BMNDKOMNION, string FKEBENDDFPJ, PhotonPlayer PJJMGBAKLPK, params object[] ABMLHILNNDM)
	{
		if (PhotonConnectionManager.isInRoom)
		{
			BMNDKOMNION.RPC(FKEBENDDFPJ, PJJMGBAKLPK, ABMLHILNNDM);
			return;
		}
		PhotonCachedRPC photonCachedRPC = BMNDKOMNION.gameObject.GetComponent<PhotonCachedRPC>() ?? BMNDKOMNION.gameObject.AddComponent<PhotonCachedRPC>();
		photonCachedRPC.KFCAGHNBKCD(BMNDKOMNION, FKEBENDDFPJ, PhotonTargets.All, PJJMGBAKLPK, ABMLHILNNDM);
	}

	private void KFCAGHNBKCD(PhotonView BMNDKOMNION, string FKEBENDDFPJ, PhotonTargets MKIPAEDAADL, PhotonPlayer KHLGDCHJJPB, params object[] ABMLHILNNDM)
	{
		CMFKCGEBLBC.Add(new AJPDOPBPEHE
		{
			BMNDKOMNION = BMNDKOMNION,
			FKEBENDDFPJ = FKEBENDDFPJ,
			MKIPAEDAADL = MKIPAEDAADL,
			ABMLHILNNDM = ABMLHILNNDM
		});
	}

	private void NJNNGKJAKOL()
	{
		CMFKCGEBLBC.Clear();
	}
}
