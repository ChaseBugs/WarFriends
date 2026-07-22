using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("NGUI/Tween/Rotation")]
public class TweenRotationSpecial : UITweener
{
	[FormerlySerializedAs("EMMCJEEABGA")]
	public float OEIICEJPGKI;

	[FormerlySerializedAs("FFJGKOLGFLL")]
	public float IIMDKHJAJGO;

	[FormerlySerializedAs("FCMBPEBAMMD")]
	public Vector3 IGCBPIDCKLC;

	private Transform GJNGACLKAOG;

	[FormerlySerializedAs("FGBNPKNLIPO")]
	public Vector3 CFPMPNBEJFK;

	public Transform cachedTransform
	{
		get
		{
			if (GJNGACLKAOG == null)
			{
				GJNGACLKAOG = base.transform;
			}
			return GJNGACLKAOG;
		}
	}

	public static TweenRotationSpecial OKCMGMMLEJP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1513f)
		{
			tweenRotationSpecial.Sample(1707f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void GPENDOJKGKL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1636f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		cachedTransform.localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform PBGKCELGAIL()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial EOOHBKFCBMC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1906f)
		{
			tweenRotationSpecial.Sample(219f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	[SpecialName]
	public Transform DFFCIJKKHMF()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	[SpecialName]
	public Transform LHMKECBCHGJ()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial PMKKKICHILI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 490f)
		{
			tweenRotationSpecial.Sample(1435f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	protected virtual void NNLLJHPJLKD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1986f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		PGJGGDIADAK().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform CIMBHKKPAHE()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial KAEBPEJBJCI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 747f)
		{
			tweenRotationSpecial.Sample(577f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	protected virtual void FNHJHHIKKBM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (183f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		GJFFHOFFHHB().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform FADCOIEEBEM()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		cachedTransform.localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial DBPOCEIDEAE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 892f)
		{
			tweenRotationSpecial.Sample(1648f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void MICBKNFHIEO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (320f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		CIMBHKKPAHE().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform DGKLBOLPLHK()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	protected virtual void BNJBFLPBONL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (201f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		GJFFHOFFHHB().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial BCKPMDBAMFL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1558f)
		{
			tweenRotationSpecial.Sample(285f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial IECHDKECJAB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1598f)
		{
			tweenRotationSpecial.Sample(1182f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial IHPAHOHIOPC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 809f)
		{
			tweenRotationSpecial.Sample(4f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial DHKJOACDBNK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1022f)
		{
			tweenRotationSpecial.Sample(572f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void NFMBLIGCMMG(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1397f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		LHMKECBCHGJ().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial FMGPCIGJIBP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 302f)
		{
			tweenRotationSpecial.Sample(697f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void CMJLPFKEEIJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (773f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		FDADPCCFNLB().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	protected virtual void FGJENFGGGJP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1884f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		HAJJDICHGKB().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform GIAGCOAILPB()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial KFNKIMBNAIK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 446f)
		{
			tweenRotationSpecial.Sample(155f, isFinished: true);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	protected virtual void NLHDACKEPGA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1604f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		DFFCIJKKHMF().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial IPJJKFNPEEC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1421f)
		{
			tweenRotationSpecial.Sample(761f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial PKJIGJAELJE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1181f)
		{
			tweenRotationSpecial.Sample(120f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial DKGIHJJKKBM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1969f)
		{
			tweenRotationSpecial.Sample(942f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	[SpecialName]
	public Transform FEMKJAFOJFE()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial DANKMJCJOIN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 380f)
		{
			tweenRotationSpecial.Sample(209f, isFinished: true);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial AMIDMCCIPJK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1932f)
		{
			tweenRotationSpecial.Sample(1354f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial NFCEEJODFMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 858f)
		{
			tweenRotationSpecial.Sample(1455f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial KMOAOMACBGJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 389f)
		{
			tweenRotationSpecial.Sample(911f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void CDOIOHAAPAC(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1288f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		JENFEGEDKNL().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial JPJPAJEBNPK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1848f)
		{
			tweenRotationSpecial.Sample(165f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial FHKFBIPHJCG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1382f)
		{
			tweenRotationSpecial.Sample(485f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial HDHIEDDCJIC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1473f)
		{
			tweenRotationSpecial.Sample(1101f, isFinished: true);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	protected virtual void DHDEEIEOECF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1421f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		ALLJELIIENE().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform JENFEGEDKNL()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	[SpecialName]
	public Transform OBNDCPDFPHI()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial DPNIOHKJONI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1274f)
		{
			tweenRotationSpecial.Sample(1976f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial GHMBHKEBADL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1535f)
		{
			tweenRotationSpecial.Sample(1618f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial HNEAGHHABGL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 607f)
		{
			tweenRotationSpecial.Sample(1948f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	[SpecialName]
	public Transform LOGAFKEDFDE()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	[SpecialName]
	public Transform KPNOCLBHOEP()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	protected virtual void COBFNJPLCIM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (780f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		LOBEKEIAOCE().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform MNPFKEKODCL()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial JCHCHLJBPKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1475f)
		{
			tweenRotationSpecial.Sample(970f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	[SpecialName]
	public Transform FDADPCCFNLB()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	[SpecialName]
	public Transform PGJGGDIADAK()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	protected virtual void KOAJHOMDJKF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1534f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		KPNOCLBHOEP().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform JLPCGMHJEPD()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial HBJKMDGLCMH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 940f)
		{
			tweenRotationSpecial.Sample(78f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void IKLMKNFGAOI(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (150f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		LOBEKEIAOCE().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	protected virtual void CHMAEOPLFFN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (50f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		PBGKCELGAIL().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial AEOAFNOCOGD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 37f)
		{
			tweenRotationSpecial.Sample(620f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial JKFEDBCGIKH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1760f)
		{
			tweenRotationSpecial.Sample(553f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	[SpecialName]
	public Transform LOBEKEIAOCE()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial IAGLEIPAIOB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1208f)
		{
			tweenRotationSpecial.Sample(270f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	protected virtual void MMDKDDNKAHF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1022f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		OBNDCPDFPHI().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform ONNPOBBGOGB()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	[SpecialName]
	public Transform GJFFHOFFHHB()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	protected virtual void BIAMFGJEEKJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (101f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		KKANDLAMFHN().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	protected virtual void HAFPIEANDHE(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (639f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		LOGAFKEDFDE().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	protected virtual void CLLONILEBNF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1123f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		KPNOCLBHOEP().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform ONKGBDHCIHI()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	[SpecialName]
	public Transform AHKMDGKPFDG()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenRotationSpecial.Sample(1f, isFinished: true);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void EEDOMDHMGLA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (961f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		LOBEKEIAOCE().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial OGHELDLHAMK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1951f)
		{
			tweenRotationSpecial.Sample(1882f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	protected virtual void FHHHBLCNGKE(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1917f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		HAJJDICHGKB().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial EGACIBHAMAF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1765f)
		{
			tweenRotationSpecial.Sample(726f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void JFNAAAFJDOF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (507f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		JLPCGMHJEPD().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform HAJJDICHGKB()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	protected virtual void IEOCAOCKMGB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (740f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		JENFEGEDKNL().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	protected virtual void JJDJNEJFEMD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (1588f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		EICNEHENONH().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	public static TweenRotationSpecial PAJHHBLHAEI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1208f)
		{
			tweenRotationSpecial.Sample(1014f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	public static TweenRotationSpecial KMJOPOLHAJJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1307f)
		{
			tweenRotationSpecial.Sample(1304f, isFinished: false);
			tweenRotationSpecial.enabled = false;
		}
		return tweenRotationSpecial;
	}

	protected virtual void HBAGGBIEDOG(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (634f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		cachedTransform.localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform LKNABFDDAMJ()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	protected virtual void KCHFFBKGHHK(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (34f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		LKNABFDDAMJ().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform ALLJELIIENE()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	[SpecialName]
	public Transform IODHFIKBFFG()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial MDKDEJJDHKM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 1759f)
		{
			tweenRotationSpecial.Sample(1288f, isFinished: false);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}

	[SpecialName]
	public Transform LNBCPLHNPFO()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	protected virtual void AJIGPEGLLLF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		float angle = OEIICEJPGKI * (141f - KDJCCDGMEJL) + IIMDKHJAJGO * KDJCCDGMEJL;
		HAJJDICHGKB().localRotation = Quaternion.AngleAxis(angle, IGCBPIDCKLC) * Quaternion.Euler(CFPMPNBEJFK);
	}

	[SpecialName]
	public Transform KKANDLAMFHN()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	[SpecialName]
	public Transform EICNEHENONH()
	{
		if (GJNGACLKAOG == null)
		{
			GJNGACLKAOG = base.transform;
		}
		return GJNGACLKAOG;
	}

	public static TweenRotationSpecial IPOEOHBLGMJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Vector3 IBMKNPPALKB, float LMLNCJJMINC, float DDHKANDHKDI)
	{
		TweenRotationSpecial tweenRotationSpecial = UITweener.Begin<TweenRotationSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenRotationSpecial.OEIICEJPGKI = LMLNCJJMINC;
		tweenRotationSpecial.IIMDKHJAJGO = DDHKANDHKDI;
		tweenRotationSpecial.IGCBPIDCKLC = IBMKNPPALKB;
		if (DNDHIFENDPJ <= 710f)
		{
			tweenRotationSpecial.Sample(1854f, isFinished: true);
			tweenRotationSpecial.enabled = true;
		}
		return tweenRotationSpecial;
	}
}
