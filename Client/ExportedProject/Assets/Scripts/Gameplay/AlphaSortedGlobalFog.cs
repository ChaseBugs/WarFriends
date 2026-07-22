using System;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Image Effects/Fog/AlphaSortedGlobalFog")]
[ExecuteInEditMode]
public class AlphaSortedGlobalFog : MonoBehaviour
{
	public enum MBLAKELNIPM
	{
		AbsoluteYAndDistance,
		AbsoluteY,
		Distance,
		RelativeYAndDistance
	}

	private Camera GNICEGBOGOL;

	[FormerlySerializedAs("KFMBOJHBKKM")]
	public bool FCMBEKMPLEN = true;

	public MBLAKELNIPM HJINPFPEOEH;

	private float OKEEBGLDCPK = 0.5f;

	private float LGCDOGOPBIB = 50f;

	private float AMENODIBODI = 60f;

	private float BGKBAIIDEPA = 1.333333f;

	[FormerlySerializedAs("JLLMIDOLKAI")]
	public float LIJCAIJIDMD = 200f;

	[FormerlySerializedAs("CCAMOGNPGFD")]
	public float BKKALFIPJLK = 1f;

	[FormerlySerializedAs("FEKMLNJJDBG")]
	public float HAGCNJINHDP = 100f;

	[FormerlySerializedAs("KGAPMBEFFML")]
	public float FBMIFHHEOBO;

	[FormerlySerializedAs("IBKGIJLEHMM")]
	public Color HICENJLGBMJ = Color.grey;

	[FormerlySerializedAs("KBMOFKNBFBD")]
	public Shader CGCDJLKENGE;

	private Material MCNEGCBDJAJ;

	private static void FBCFGKLBOFB(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void DAOKPAFCFGA(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		if (!FCMBEKMPLEN)
		{
			Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
			return;
		}
		if (MCNEGCBDJAJ == null)
		{
			MCNEGCBDJAJ = new Material(CGCDJLKENGE);
		}
		OKEEBGLDCPK = GNICEGBOGOL.nearClipPlane;
		LGCDOGOPBIB = GNICEGBOGOL.farClipPlane;
		AMENODIBODI = GNICEGBOGOL.fieldOfView;
		BGKBAIIDEPA = GNICEGBOGOL.aspect;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = AMENODIBODI * 1930f;
		Vector3 vector = GNICEGBOGOL.transform.right * OKEEBGLDCPK * Mathf.Tan(num * 75f) * BGKBAIIDEPA;
		Vector3 vector2 = GNICEGBOGOL.transform.up * OKEEBGLDCPK * Mathf.Tan(num * 678f);
		Vector3 vector3 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector + vector2;
		float num2 = vector3.magnitude * LGCDOGOPBIB / OKEEBGLDCPK;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(0, vector3);
		identity.SetRow(0, vector4);
		identity.SetRow(1, vector6);
		identity.SetRow(0, vector5);
		MCNEGCBDJAJ.SetMatrix("-", identity);
		MCNEGCBDJAJ.SetVector("ID_NOTIFICATION_WARARENAPHASE{0}", GNICEGBOGOL.transform.position);
		MCNEGCBDJAJ.SetVector("LevelsManager.prefab", new Vector4(227f / LIJCAIJIDMD, num2 - LIJCAIJIDMD));
		MCNEGCBDJAJ.SetVector("\"", new Vector4(FBMIFHHEOBO, 73f / HAGCNJINHDP));
		MCNEGCBDJAJ.SetFloat(" ", BKKALFIPJLK * 715f);
		MCNEGCBDJAJ.SetColor("getRewardedInfoForZoneID", HICENJLGBMJ);
		JCJBPIKGDKO(AEJJCMHDFBA, DANDPMBGFJC, MCNEGCBDJAJ, (int)HJINPFPEOEH);
	}

	private void NPHCBOEAFCE(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		if (!FCMBEKMPLEN)
		{
			Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
			return;
		}
		if (MCNEGCBDJAJ == null)
		{
			MCNEGCBDJAJ = new Material(CGCDJLKENGE);
		}
		OKEEBGLDCPK = GNICEGBOGOL.nearClipPlane;
		LGCDOGOPBIB = GNICEGBOGOL.farClipPlane;
		AMENODIBODI = GNICEGBOGOL.fieldOfView;
		BGKBAIIDEPA = GNICEGBOGOL.aspect;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = AMENODIBODI * 437f;
		Vector3 vector = GNICEGBOGOL.transform.right * OKEEBGLDCPK * Mathf.Tan(num * 396f) * BGKBAIIDEPA;
		Vector3 vector2 = GNICEGBOGOL.transform.up * OKEEBGLDCPK * Mathf.Tan(num * 1269f);
		Vector3 vector3 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector + vector2;
		float num2 = vector3.magnitude * LGCDOGOPBIB / OKEEBGLDCPK;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(0, vector3);
		identity.SetRow(1, vector4);
		identity.SetRow(2, vector6);
		identity.SetRow(5, vector5);
		MCNEGCBDJAJ.SetMatrix("ID_RANDOMMAP", identity);
		MCNEGCBDJAJ.SetVector("ID_MAX", GNICEGBOGOL.transform.position);
		MCNEGCBDJAJ.SetVector("ID_CLAIMED", new Vector4(1038f / LIJCAIJIDMD, num2 - LIJCAIJIDMD));
		MCNEGCBDJAJ.SetVector("Fuseb oxx manager: TEsting stufff", new Vector4(FBMIFHHEOBO, 897f / HAGCNJINHDP));
		MCNEGCBDJAJ.SetFloat("DOWNLOAD", BKKALFIPJLK * 916f);
		MCNEGCBDJAJ.SetColor("Main_Menu_Offers_Bar", HICENJLGBMJ);
		GECNLCGNJJD(AEJJCMHDFBA, DANDPMBGFJC, MCNEGCBDJAJ, (int)HJINPFPEOEH);
	}

	private static void NCJNDDPFLNG(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void DODFLLEAMHK(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		if (!FCMBEKMPLEN)
		{
			Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
			return;
		}
		if (MCNEGCBDJAJ == null)
		{
			MCNEGCBDJAJ = new Material(CGCDJLKENGE);
		}
		OKEEBGLDCPK = GNICEGBOGOL.nearClipPlane;
		LGCDOGOPBIB = GNICEGBOGOL.farClipPlane;
		AMENODIBODI = GNICEGBOGOL.fieldOfView;
		BGKBAIIDEPA = GNICEGBOGOL.aspect;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = AMENODIBODI * 1267f;
		Vector3 vector = GNICEGBOGOL.transform.right * OKEEBGLDCPK * Mathf.Tan(num * 1195f) * BGKBAIIDEPA;
		Vector3 vector2 = GNICEGBOGOL.transform.up * OKEEBGLDCPK * Mathf.Tan(num * 56f);
		Vector3 vector3 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector + vector2;
		float num2 = vector3.magnitude * LGCDOGOPBIB / OKEEBGLDCPK;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(0, vector3);
		identity.SetRow(1, vector4);
		identity.SetRow(0, vector6);
		identity.SetRow(1, vector5);
		MCNEGCBDJAJ.SetMatrix("ID_CONFIRM_ERROR", identity);
		MCNEGCBDJAJ.SetVector("ADDING POWERBAND ON CLIENT ", GNICEGBOGOL.transform.position);
		MCNEGCBDJAJ.SetVector("dailyRewardData", new Vector4(1979f / LIJCAIJIDMD, num2 - LIJCAIJIDMD));
		MCNEGCBDJAJ.SetVector("QUIT", new Vector4(FBMIFHHEOBO, 259f / HAGCNJINHDP));
		MCNEGCBDJAJ.SetFloat("MessageType", BKKALFIPJLK * 1462f);
		MCNEGCBDJAJ.SetColor("Play_Card_Tutorial", HICENJLGBMJ);
		LMHDLNCBDPL(AEJJCMHDFBA, DANDPMBGFJC, MCNEGCBDJAJ, (int)HJINPFPEOEH);
	}

	private void PONMLKPPAPG()
	{
	}

	private void JDJMOEPKKCI(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		NPHCBOEAFCE(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void PMIDDDGGBPN()
	{
	}

	private void AFDHFMOGFMJ(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		DMEALCGPELG(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private static void LPNFEIOLGLO(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void NGGJHDCOLEC()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private void LFONBNCBNPK(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		if (!FCMBEKMPLEN)
		{
			Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
			return;
		}
		if (MCNEGCBDJAJ == null)
		{
			MCNEGCBDJAJ = new Material(CGCDJLKENGE);
		}
		OKEEBGLDCPK = GNICEGBOGOL.nearClipPlane;
		LGCDOGOPBIB = GNICEGBOGOL.farClipPlane;
		AMENODIBODI = GNICEGBOGOL.fieldOfView;
		BGKBAIIDEPA = GNICEGBOGOL.aspect;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = AMENODIBODI * 32f;
		Vector3 vector = GNICEGBOGOL.transform.right * OKEEBGLDCPK * Mathf.Tan(num * 873f) * BGKBAIIDEPA;
		Vector3 vector2 = GNICEGBOGOL.transform.up * OKEEBGLDCPK * Mathf.Tan(num * 777f);
		Vector3 vector3 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector + vector2;
		float num2 = vector3.magnitude * LGCDOGOPBIB / OKEEBGLDCPK;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(0, vector3);
		identity.SetRow(0, vector4);
		identity.SetRow(0, vector6);
		identity.SetRow(0, vector5);
		MCNEGCBDJAJ.SetMatrix("601 TUTORIAL STARTED", identity);
		MCNEGCBDJAJ.SetVector("81cb29735bbd4830b860f8d13ebeb48b", GNICEGBOGOL.transform.position);
		MCNEGCBDJAJ.SetVector("Claim_Reward", new Vector4(375f / LIJCAIJIDMD, num2 - LIJCAIJIDMD));
		MCNEGCBDJAJ.SetVector("GLM: RegisterOrLogin -  4", new Vector4(FBMIFHHEOBO, 1513f / HAGCNJINHDP));
		MCNEGCBDJAJ.SetFloat("Assignment Screen - Daily - Claim Clicked", BKKALFIPJLK * 1588f);
		MCNEGCBDJAJ.SetColor("ID_TUTORIAL", HICENJLGBMJ);
		NCJNDDPFLNG(AEJJCMHDFBA, DANDPMBGFJC, MCNEGCBDJAJ, (int)HJINPFPEOEH);
	}

	private void MFKNMALEKKB()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private void IGBCCGDMCDE()
	{
	}

	private static void LMHDLNCBDPL(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void HGALNPEEIHI(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		NPHCBOEAFCE(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void ENHEBPJNKBM()
	{
	}

	private void Start()
	{
	}

	private void HFKIAIEGNGI()
	{
	}

	private void DMEALCGPELG(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		if (!FCMBEKMPLEN)
		{
			Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
			return;
		}
		if (MCNEGCBDJAJ == null)
		{
			MCNEGCBDJAJ = new Material(CGCDJLKENGE);
		}
		OKEEBGLDCPK = GNICEGBOGOL.nearClipPlane;
		LGCDOGOPBIB = GNICEGBOGOL.farClipPlane;
		AMENODIBODI = GNICEGBOGOL.fieldOfView;
		BGKBAIIDEPA = GNICEGBOGOL.aspect;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = AMENODIBODI * 838f;
		Vector3 vector = GNICEGBOGOL.transform.right * OKEEBGLDCPK * Mathf.Tan(num * 1280f) * BGKBAIIDEPA;
		Vector3 vector2 = GNICEGBOGOL.transform.up * OKEEBGLDCPK * Mathf.Tan(num * 1065f);
		Vector3 vector3 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector + vector2;
		float num2 = vector3.magnitude * LGCDOGOPBIB / OKEEBGLDCPK;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(1, vector3);
		identity.SetRow(0, vector4);
		identity.SetRow(8, vector6);
		identity.SetRow(2, vector5);
		MCNEGCBDJAJ.SetMatrix("ID_CONFIRM_SERVERDIDNOTRESPOND", identity);
		MCNEGCBDJAJ.SetVector("ID_GC_LOGOUT_TEXT", GNICEGBOGOL.transform.position);
		MCNEGCBDJAJ.SetVector("Action ", new Vector4(619f / LIJCAIJIDMD, num2 - LIJCAIJIDMD));
		MCNEGCBDJAJ.SetVector("BotName", new Vector4(FBMIFHHEOBO, 627f / HAGCNJINHDP));
		MCNEGCBDJAJ.SetFloat("InstantBattleEnded: Paid Instant Battles = ", BKKALFIPJLK * 564f);
		MCNEGCBDJAJ.SetColor("ID_CONFIRM_SQUADEVENT_TEXT", HICENJLGBMJ);
		CNDGLPEECNJ(AEJJCMHDFBA, DANDPMBGFJC, MCNEGCBDJAJ, (int)HJINPFPEOEH);
	}

	private static void DOPBJCMCFJI(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void GAILIKMMPDF(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		GCPBGADAEPM(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void CLNAPGALPFP(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		if (!FCMBEKMPLEN)
		{
			Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
			return;
		}
		if (MCNEGCBDJAJ == null)
		{
			MCNEGCBDJAJ = new Material(CGCDJLKENGE);
		}
		OKEEBGLDCPK = GNICEGBOGOL.nearClipPlane;
		LGCDOGOPBIB = GNICEGBOGOL.farClipPlane;
		AMENODIBODI = GNICEGBOGOL.fieldOfView;
		BGKBAIIDEPA = GNICEGBOGOL.aspect;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = AMENODIBODI * 1389f;
		Vector3 vector = GNICEGBOGOL.transform.right * OKEEBGLDCPK * Mathf.Tan(num * 1197f) * BGKBAIIDEPA;
		Vector3 vector2 = GNICEGBOGOL.transform.up * OKEEBGLDCPK * Mathf.Tan(num * 842f);
		Vector3 vector3 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector + vector2;
		float num2 = vector3.magnitude * LGCDOGOPBIB / OKEEBGLDCPK;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(0, vector3);
		identity.SetRow(0, vector4);
		identity.SetRow(2, vector6);
		identity.SetRow(5, vector5);
		MCNEGCBDJAJ.SetMatrix("Shots_Fired", identity);
		MCNEGCBDJAJ.SetVector("GameCenterPassword", GNICEGBOGOL.transform.position);
		MCNEGCBDJAJ.SetVector("ID_CONFIRM_STARTUPERROR_TEXT", new Vector4(1096f / LIJCAIJIDMD, num2 - LIJCAIJIDMD));
		MCNEGCBDJAJ.SetVector(" was not in the list of products.", new Vector4(FBMIFHHEOBO, 1190f / HAGCNJINHDP));
		MCNEGCBDJAJ.SetFloat("103 STAGE 1 CONTINUE", BKKALFIPJLK * 85f);
		MCNEGCBDJAJ.SetColor("open", HICENJLGBMJ);
		DOPBJCMCFJI(AEJJCMHDFBA, DANDPMBGFJC, MCNEGCBDJAJ, (int)HJINPFPEOEH);
	}

	private static void CNDGLPEECNJ(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private static void NGINBFDMCMM(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private static void LEKPDCCKNAE(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void OOEILIJIGBE(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		NGGBPBIEGJB(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void DFOOBIDMLBG(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		NGGBPBIEGJB(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void DKKFHJHAEPG(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		NPHCBOEAFCE(AEJJCMHDFBA, DANDPMBGFJC);
	}

	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		NGGBPBIEGJB(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void LFGAFALKANI()
	{
	}

	private void CFHILPHMOOG()
	{
	}

	private void IABJJOPLKFF()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private void FDPPHDHEIGJ(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		NPHCBOEAFCE(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void HFIIIMPIGOB(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		NPHCBOEAFCE(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void DDCPJGKNHOC(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		DAOKPAFCFGA(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private static void AKNLJPNFHHK(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void OKKENJDPBOF(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		DODFLLEAMHK(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void NBDOFMHBKFG()
	{
	}

	private void PBCDDNOCJOI()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private void IGCCLCGDGIE()
	{
	}

	private void FPPLLLKNCIE()
	{
	}

	private void FJIDLPDMAFM()
	{
	}

	private void LPKEGOIAEJC()
	{
	}

	private void IOAEHDJGBJC()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private void MPEPLKEANKN(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		DMEALCGPELG(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private static void GECNLCGNJJD(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void BAGCDJMLCPF()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private void DAJOODMLNFK(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		CLNAPGALPFP(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void NGGBPBIEGJB(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		if (!FCMBEKMPLEN)
		{
			Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
			return;
		}
		if (MCNEGCBDJAJ == null)
		{
			MCNEGCBDJAJ = new Material(CGCDJLKENGE);
		}
		OKEEBGLDCPK = GNICEGBOGOL.nearClipPlane;
		LGCDOGOPBIB = GNICEGBOGOL.farClipPlane;
		AMENODIBODI = GNICEGBOGOL.fieldOfView;
		BGKBAIIDEPA = GNICEGBOGOL.aspect;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = AMENODIBODI * 0.5f;
		Vector3 vector = GNICEGBOGOL.transform.right * OKEEBGLDCPK * Mathf.Tan(num * ((float)Math.PI / 180f)) * BGKBAIIDEPA;
		Vector3 vector2 = GNICEGBOGOL.transform.up * OKEEBGLDCPK * Mathf.Tan(num * ((float)Math.PI / 180f));
		Vector3 vector3 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector + vector2;
		float num2 = vector3.magnitude * LGCDOGOPBIB / OKEEBGLDCPK;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(0, vector3);
		identity.SetRow(1, vector4);
		identity.SetRow(2, vector6);
		identity.SetRow(3, vector5);
		MCNEGCBDJAJ.SetMatrix("_FrustumCornersWS", identity);
		MCNEGCBDJAJ.SetVector("_CameraWS", GNICEGBOGOL.transform.position);
		MCNEGCBDJAJ.SetVector("_StartDistance", new Vector4(1f / LIJCAIJIDMD, num2 - LIJCAIJIDMD));
		MCNEGCBDJAJ.SetVector("_Y", new Vector4(FBMIFHHEOBO, 1f / HAGCNJINHDP));
		MCNEGCBDJAJ.SetFloat("_GlobalDensity", BKKALFIPJLK * 0.01f);
		MCNEGCBDJAJ.SetColor("_FogColor", HICENJLGBMJ);
		DOPBJCMCFJI(AEJJCMHDFBA, DANDPMBGFJC, MCNEGCBDJAJ, (int)HJINPFPEOEH);
	}

	private void KDMECDLHNMC()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private static void KMBPMNGNPJM(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void NHAEGCBBJNP()
	{
	}

	private void GCPBGADAEPM(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		if (!FCMBEKMPLEN)
		{
			Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
			return;
		}
		if (MCNEGCBDJAJ == null)
		{
			MCNEGCBDJAJ = new Material(CGCDJLKENGE);
		}
		OKEEBGLDCPK = GNICEGBOGOL.nearClipPlane;
		LGCDOGOPBIB = GNICEGBOGOL.farClipPlane;
		AMENODIBODI = GNICEGBOGOL.fieldOfView;
		BGKBAIIDEPA = GNICEGBOGOL.aspect;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = AMENODIBODI * 1898f;
		Vector3 vector = GNICEGBOGOL.transform.right * OKEEBGLDCPK * Mathf.Tan(num * 1381f) * BGKBAIIDEPA;
		Vector3 vector2 = GNICEGBOGOL.transform.up * OKEEBGLDCPK * Mathf.Tan(num * 734f);
		Vector3 vector3 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector + vector2;
		float num2 = vector3.magnitude * LGCDOGOPBIB / OKEEBGLDCPK;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = GNICEGBOGOL.transform.forward * OKEEBGLDCPK - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(0, vector3);
		identity.SetRow(0, vector4);
		identity.SetRow(7, vector6);
		identity.SetRow(6, vector5);
		MCNEGCBDJAJ.SetMatrix("ID_LOGOUT", identity);
		MCNEGCBDJAJ.SetVector("Show {0} invitation dialog id: {1}", GNICEGBOGOL.transform.position);
		MCNEGCBDJAJ.SetVector("0", new Vector4(1886f / LIJCAIJIDMD, num2 - LIJCAIJIDMD));
		MCNEGCBDJAJ.SetVector(" / ", new Vector4(FBMIFHHEOBO, 1771f / HAGCNJINHDP));
		MCNEGCBDJAJ.SetFloat("game-label-won", BKKALFIPJLK * 840f);
		MCNEGCBDJAJ.SetColor(", ", HICENJLGBMJ);
		NCJNDDPFLNG(AEJJCMHDFBA, DANDPMBGFJC, MCNEGCBDJAJ, (int)HJINPFPEOEH);
	}

	private void PNCPCHDFBOB()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private void Awake()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private static void NLIHHINAJGC(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void ONBDJLDJDCH()
	{
		GNICEGBOGOL = GetComponent<Camera>();
	}

	private void LIHIOMEMJFI()
	{
	}

	private void KCCGPMHIHNG()
	{
	}

	private static void JCJBPIKGDKO(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
	{
		Graphics.Blit(AEJJCMHDFBA, DFPNKDKELEE, BNNENCFGOKP, DNIDIBPDLII);
	}

	private void BJBEAKDMADM(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		DAOKPAFCFGA(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void EPLGEFBIDMA(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
	{
		LFONBNCBNPK(AEJJCMHDFBA, DANDPMBGFJC);
	}

	private void AFPIADMMBFB()
	{
	}
}
