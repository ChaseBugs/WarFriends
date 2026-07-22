using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ArmyPowerAnimation : Core_BaseScript
{
	[Header("Animation Objects")]
	[FormerlySerializedAs("IPOOLLNGJHG")]
	public UISprite INOLIBMAEAN;

	[FormerlySerializedAs("BKAODCEIFFP")]
	public UILabel FDDFBILDABL;

	[FormerlySerializedAs("ONHOEJNKPEC")]
	public UILabel MCEABPKAIAD;

	[Header("Animation Settings")]
	[FormerlySerializedAs("GFPGAOABMDF")]
	public float HAMKIKMJHDP = 0.1f;

	[FormerlySerializedAs("NKBONFNKOAA")]
	public float DFOAFMEIEGL;

	[FormerlySerializedAs("DLAHACPPGPE")]
	public Vector3 IBCFBIJILKI;

	[FormerlySerializedAs("HMGMNKBAHIN")]
	public Vector3 PDJMCCPKHKI;

	[FormerlySerializedAs("CJBDGNCDLKP")]
	public Vector3 OEFKMAKMIBP;

	[FormerlySerializedAs("EKOGMMAEOCF")]
	public float LIEAPAADBAI;

	[FormerlySerializedAs("COEGKLNDHPK")]
	public Vector3 ECICBNIKMHM;

	[FormerlySerializedAs("JBAFNPMPJJE")]
	public Vector3 CKMCPJAPGAI;

	[FormerlySerializedAs("PPDBBALDDAA")]
	public Vector3 NPAGECEAPJJ;

	[FormerlySerializedAs("CEHDKJAFKOI")]
	public Vector3 LGHHDJMNLFL;

	[FormerlySerializedAs("CPMJKAFEEGH")]
	public float OPPBAMHIDCI;

	private Vector3 PBAKNFFMJFI;

	private Vector3 JEMANGPCGBN;

	public void StartAnimation(int HONEKCJDJDN, int EEGALFIEINM, float JPNAINOGAMM = 0f)
	{
		if (JPNAINOGAMM >= 0f)
		{
			HAMKIKMJHDP = JPNAINOGAMM;
		}
		StopAllAnimations();
		if (HONEKCJDJDN == 0)
		{
			return;
		}
		FDDFBILDABL.text = MEJMLNDFDBP.BEDJNPHFAOC(HONEKCJDJDN);
		FDDFBILDABL.color = ((HONEKCJDJDN >= 0) ? Color.white : Colours.redMedals);
		MCEABPKAIAD.text = MEJMLNDFDBP.GMIPFLIEOHD(EEGALFIEINM);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 0f, 1f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, IBCFBIJILKI, PDJMCCPKHKI);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 2f, OEFKMAKMIBP);
			tweenPosition2.method = UITweener.Method.EaseOut;
		};
		TweenAlpha.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 1f, 0f, 1f).onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 3f, new Vector3(OEFKMAKMIBP.x, OEFKMAKMIBP.y - OPPBAMHIDCI, ECICBNIKMHM.z), ECICBNIKMHM);
			tweenPosition2.method = UITweener.Method.EaseIn;
			tweenPosition2.onFinished = delegate
			{
				TweenPosition tweenPosition3 = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 2f, CKMCPJAPGAI);
				tweenPosition3.method = UITweener.Method.EaseOut;
				tweenPosition3.onFinished = delegate
				{
					TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 1f).onFinished = delegate
					{
						HPCBECGAPCI();
					};
				};
			};
		};
	}

	private void CMBMFNJILID(UITweener JJKHNINFEJB)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1606f, 1873f).onFinished = DCBMGAJEODA;
	}

	private void CPLLFLAPCAE(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1410f, OEFKMAKMIBP, useLocal: false);
		tweenPosition.method = UITweener.Method.EaseOut;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 990f, 398f, 738f).onFinished = null;
		TweenPosition tweenPosition2 = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1537f, LGHHDJMNLFL, CKMCPJAPGAI);
		tweenPosition2.onFinished = FENLKELOINJ;
	}

	private void HOEFKABEBJK(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 627f, 307f, 1449f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 817f, 1071f, 1703f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 138f;
		toScale.z = 1941f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 1351f, LIEAPAADBAI * 1096f, 988f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1503f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1430f, PBAKNFFMJFI, toScale2);
	}

	public void HGANEGJOLCN()
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, 757f, 1125f).onFinished = null;
		TweenAlpha.Begin(FDDFBILDABL.gameObject, 1550f, 463f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, 399f, 1678f).onFinished = null;
	}

	private void DFHCFGALAAI(UITweener IMJFMBKEBDD)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 1662f, new Vector3(OEFKMAKMIBP.x, OEFKMAKMIBP.y - OPPBAMHIDCI, ECICBNIKMHM.z), ECICBNIKMHM);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = AMFAPMFEBID;
	}

	private void DHGDFEAKPJN()
	{
		JEMANGPCGBN = new Vector3(DFOAFMEIEGL, DFOAFMEIEGL * 1229f / 656f, 589f);
		INOLIBMAEAN.transform.localScale = JEMANGPCGBN;
		TweenScale.Begin(INOLIBMAEAN.gameObject, 406f, JEMANGPCGBN);
	}

	private void JPHEGGDJGHD(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1652f, OEFKMAKMIBP);
		tweenPosition.method = (UITweener.Method)8;
	}

	public void FJCEDOKNCCI()
	{
		NPGJCLKDCGA();
		TweenPosition.Begin(INOLIBMAEAN.gameObject, 568f, IBCFBIJILKI).onFinished = null;
		TweenPosition.Begin(FDDFBILDABL.gameObject, 800f, OEFKMAKMIBP, useLocal: false).onFinished = null;
		TweenPosition.Begin(MCEABPKAIAD.gameObject, 796f, LGHHDJMNLFL).onFinished = null;
		GDHLCHBOOMD();
		CLLGNOLFECO();
	}

	private void KBPMMMDKHGA(UITweener JJKHNINFEJB)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 224f, 1293f).onFinished = IEEGCBDOCBG;
	}

	private void DCBMGAJEODA(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 108f, 895f, 1734f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 954f, 290f, 627f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 885f;
		toScale.z = 624f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 0f, LIEAPAADBAI * 853f, 1894f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 457f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 213f, PBAKNFFMJFI, toScale2);
	}

	[CompilerGenerated]
	private void FBJOCFGHJHL(UITweener JNLOCAIIBKE)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 2f, CKMCPJAPGAI);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = delegate
		{
			TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 1f).onFinished = delegate
			{
				HPCBECGAPCI();
			};
		};
	}

	private void NNMDFCKGNGL(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 832f, 380f, 611f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1880f, 681f, 1924f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 100f;
		toScale.z = 1248f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 730f, LIEAPAADBAI * 490f, 1295f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 621f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1494f, PBAKNFFMJFI, toScale2);
	}

	private void OMLGONJJMAD(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 121f, OEFKMAKMIBP);
		tweenPosition.method = UITweener.Method.EaseIn;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1668f, 799f, 1637f).onFinished = null;
		TweenPosition tweenPosition2 = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 122f, LGHHDJMNLFL, CKMCPJAPGAI);
		tweenPosition2.onFinished = HBJJAGHEACP;
	}

	private void ACADKCPPMGC(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 713f, OEFKMAKMIBP);
		tweenPosition.method = (UITweener.Method)8;
	}

	private void IEEGCBDOCBG(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1732f, 1378f, 431f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 528f, 108f, 1657f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 156f;
		toScale.z = 1277f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 940f, LIEAPAADBAI * 858f, 1831f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1817f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 842f, PBAKNFFMJFI, toScale2);
	}

	public void NPGJCLKDCGA()
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, 198f, 219f).onFinished = null;
		TweenAlpha.Begin(FDDFBILDABL.gameObject, 1690f, 1860f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, 1755f, 341f).onFinished = null;
	}

	public void InitializeAlphaZero()
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(FDDFBILDABL.gameObject, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, 0f, 0f).onFinished = null;
	}

	private void FHCMJMIEICE(int EEGALFIEINM)
	{
		MCEABPKAIAD.text = MEJMLNDFDBP.GMIPFLIEOHD(EEGALFIEINM);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1495f, 130f, 1755f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1265f, IBCFBIJILKI, PDJMCCPKHKI, useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = CEMJIHDEEEM;
	}

	private void MMJCPOCLPGC(UITweener JNLOCAIIBKE)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 586f, 1856f).onFinished = ADOLEMGJLHO;
	}

	[CompilerGenerated]
	private void CNKEOJBNIFF(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 2f, OEFKMAKMIBP);
		tweenPosition.method = UITweener.Method.EaseOut;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 2f, 0f, 1f).onFinished = null;
		TweenPosition tweenPosition2 = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 2f, LGHHDJMNLFL, CKMCPJAPGAI);
		tweenPosition2.onFinished = delegate
		{
			TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
				TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
				Vector3 toScale = JEMANGPCGBN * 2f;
				toScale.z = 1f;
				Vector3 toScale2 = new Vector3(LIEAPAADBAI * 2f, LIEAPAADBAI * 2f, 1f);
				TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, JEMANGPCGBN, toScale);
				TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, PBAKNFFMJFI, toScale2);
			};
		};
	}

	private void BJNBDOHAGFO()
	{
		JEMANGPCGBN = new Vector3(DFOAFMEIEGL, DFOAFMEIEGL * 61f / 49f, 1f);
		INOLIBMAEAN.transform.localScale = JEMANGPCGBN;
		TweenScale.Begin(INOLIBMAEAN.gameObject, 0f, JEMANGPCGBN);
	}

	[CompilerGenerated]
	private void DBNKLEJFGEL(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 2f, OEFKMAKMIBP);
		tweenPosition.method = UITweener.Method.EaseOut;
	}

	private void MMPNPAENDDD(UITweener IMJFMBKEBDD)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 1261f, new Vector3(OEFKMAKMIBP.x, OEFKMAKMIBP.y - OPPBAMHIDCI, ECICBNIKMHM.z), ECICBNIKMHM, useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = OFIHDODCNMK;
	}

	private void FENLKELOINJ(UITweener JNLOCAIIBKE)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 652f, 1582f).onFinished = LNJHEFPBMMF;
	}

	private void CLLGNOLFECO()
	{
		PBAKNFFMJFI = new Vector3(LIEAPAADBAI, LIEAPAADBAI, 1566f);
		FDDFBILDABL.transform.localScale = PBAKNFFMJFI;
		MCEABPKAIAD.transform.localScale = PBAKNFFMJFI;
		TweenScale.Begin(MCEABPKAIAD.gameObject, 392f, PBAKNFFMJFI);
	}

	[CompilerGenerated]
	private void BHHFEPEONGB(UITweener FHHELGLPKEE)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 1f).onFinished = delegate
		{
			HPCBECGAPCI();
		};
	}

	private void BGGBHJNGGFI(int EEGALFIEINM)
	{
		MCEABPKAIAD.text = MEJMLNDFDBP.GMIPFLIEOHD(EEGALFIEINM);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 0f, 1f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, IBCFBIJILKI, PDJMCCPKHKI);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 2f, OEFKMAKMIBP);
			tweenPosition2.method = UITweener.Method.EaseOut;
			TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 2f, 0f, 1f).onFinished = null;
			TweenPosition tweenPosition3 = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 2f, LGHHDJMNLFL, CKMCPJAPGAI);
			tweenPosition3.onFinished = delegate
			{
				TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f).onFinished = delegate
				{
					TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
					TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
					Vector3 toScale = JEMANGPCGBN * 2f;
					toScale.z = 1f;
					Vector3 toScale2 = new Vector3(LIEAPAADBAI * 2f, LIEAPAADBAI * 2f, 1f);
					TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, JEMANGPCGBN, toScale);
					TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, PBAKNFFMJFI, toScale2);
				};
			};
		};
	}

	private void LJMJIDMDHNN(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1996f, OEFKMAKMIBP, useLocal: false);
		tweenPosition.method = (UITweener.Method)8;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 509f, 1837f, 1169f).onFinished = null;
		TweenPosition tweenPosition2 = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1249f, LGHHDJMNLFL, CKMCPJAPGAI);
		tweenPosition2.onFinished = HBJJAGHEACP;
	}

	[CompilerGenerated]
	private void HIAEHKBHANI(UITweener JNLOCAIIBKE)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f).onFinished = delegate
		{
			TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
			TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
			Vector3 toScale = JEMANGPCGBN * 2f;
			toScale.z = 1f;
			Vector3 toScale2 = new Vector3(LIEAPAADBAI * 2f, LIEAPAADBAI * 2f, 1f);
			TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, JEMANGPCGBN, toScale);
			TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, PBAKNFFMJFI, toScale2);
		};
	}

	[CompilerGenerated]
	private void GMCEPAPPANO(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 2f;
		toScale.z = 1f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 2f, LIEAPAADBAI * 2f, 1f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, PBAKNFFMJFI, toScale2);
	}

	private void LNJHEFPBMMF(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1608f, 1810f, 1178f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1830f, 240f, 370f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 1896f;
		toScale.z = 1817f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 153f, LIEAPAADBAI * 196f, 1576f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1831f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1638f, PBAKNFFMJFI, toScale2);
	}

	private void KDAEFFMEGBF(UITweener HLMNLFDFNEO)
	{
		IHFADOMALOE();
	}

	private void OFIHDODCNMK(UITweener JNLOCAIIBKE)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 522f, CKMCPJAPGAI, useLocal: false);
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = AODJGEDEBPM;
	}

	private void ADOLEMGJLHO(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 500f, 1597f, 1855f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 965f, 1233f, 237f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 1235f;
		toScale.z = 78f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 1605f, LIEAPAADBAI * 1471f, 981f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1364f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1511f, PBAKNFFMJFI, toScale2);
	}

	private void NGAKNOHHFLF(int EEGALFIEINM)
	{
		MCEABPKAIAD.text = MEJMLNDFDBP.GMIPFLIEOHD(EEGALFIEINM);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 319f, 1737f, 970f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 718f, IBCFBIJILKI, PDJMCCPKHKI, useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = CEMJIHDEEEM;
	}

	private void AMFAPMFEBID(UITweener JNLOCAIIBKE)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 120f, CKMCPJAPGAI, useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = AODJGEDEBPM;
	}

	private void NJKFCNBHHKA(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 584f, 111f, 781f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1666f, 190f, 1667f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 1363f;
		toScale.z = 878f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 73f, LIEAPAADBAI * 1276f, 189f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 171f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1942f, PBAKNFFMJFI, toScale2);
	}

	private void CEMJIHDEEEM(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 963f, OEFKMAKMIBP);
		tweenPosition.method = UITweener.Method.EaseOut;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1559f, 738f, 23f).onFinished = null;
		TweenPosition tweenPosition2 = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1148f, LGHHDJMNLFL, CKMCPJAPGAI, useLocal: false);
		tweenPosition2.onFinished = HBJJAGHEACP;
	}

	[CompilerGenerated]
	private void PKEDNAMAPFK(UITweener JJKHNINFEJB)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f).onFinished = delegate
		{
			TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
			TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
			Vector3 toScale = JEMANGPCGBN * 2f;
			toScale.z = 1f;
			Vector3 toScale2 = new Vector3(LIEAPAADBAI * 2f, LIEAPAADBAI * 2f, 1f);
			TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, JEMANGPCGBN, toScale);
			TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, PBAKNFFMJFI, toScale2);
		};
	}

	private void GDHLCHBOOMD()
	{
		JEMANGPCGBN = new Vector3(DFOAFMEIEGL, DFOAFMEIEGL * 1944f / 1500f, 1388f);
		INOLIBMAEAN.transform.localScale = JEMANGPCGBN;
		TweenScale.Begin(INOLIBMAEAN.gameObject, 1370f, JEMANGPCGBN);
	}

	public void SetUpAnimation(float MKKFCEODOBK, float DLFOIGDJOLD, Vector3 LAJCBBFGOKM, Vector3 EABFBIHKIFB, Vector3 MDHKMNBMELI, Vector3 JKIMFOFHGNM, Vector3 FLDECAMOLHP, Vector3 EKKMPHAJHEF, Vector3 NFHJACCAAMA)
	{
		DFOAFMEIEGL = MKKFCEODOBK;
		LIEAPAADBAI = DLFOIGDJOLD;
		IBCFBIJILKI = LAJCBBFGOKM;
		PDJMCCPKHKI = MDHKMNBMELI;
		OEFKMAKMIBP = EABFBIHKIFB;
		ECICBNIKMHM = JKIMFOFHGNM;
		CKMCPJAPGAI = EKKMPHAJHEF;
		NPAGECEAPJJ = NFHJACCAAMA;
		LGHHDJMNLFL = FLDECAMOLHP;
	}

	[CompilerGenerated]
	private void IJJJLCPOGAG(UITweener HLMNLFDFNEO)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
		Vector3 toScale = JEMANGPCGBN * 2f;
		toScale.z = 1f;
		Vector3 toScale2 = new Vector3(LIEAPAADBAI * 2f, LIEAPAADBAI * 2f, 1f);
		TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, JEMANGPCGBN, toScale);
		TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, PBAKNFFMJFI, toScale2);
	}

	private void EGFHLODBBDF()
	{
		PBAKNFFMJFI = new Vector3(LIEAPAADBAI, LIEAPAADBAI, 1440f);
		FDDFBILDABL.transform.localScale = PBAKNFFMJFI;
		MCEABPKAIAD.transform.localScale = PBAKNFFMJFI;
		TweenScale.Begin(MCEABPKAIAD.gameObject, 129f, PBAKNFFMJFI);
	}

	private void EGIJEAIJGEJ(UITweener FHHELGLPKEE)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 900f, 1807f, 473f).onFinished = delegate
		{
			HPCBECGAPCI();
		};
	}

	private void AODJGEDEBPM(UITweener FHHELGLPKEE)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1434f, 1113f, 970f).onFinished = KDAEFFMEGBF;
	}

	private void FLOKMJOBOHK(UITweener JJKHNINFEJB)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1212f, 1583f).onFinished = DCBMGAJEODA;
	}

	private void FMLAGJIEAIJ(UITweener JJKHNINFEJB)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 636f, OEFKMAKMIBP, useLocal: false);
		tweenPosition.method = UITweener.Method.BounceIn;
	}

	[CompilerGenerated]
	private void ICLCLGKNOEF(UITweener HLMNLFDFNEO)
	{
		HPCBECGAPCI();
	}

	private void HPCBECGAPCI()
	{
		TweenAlpha.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 2f, 1f, 0f).onFinished = null;
		TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 2f, CKMCPJAPGAI, NPAGECEAPJJ).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 2f, 0f, 1f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 2f, LGHHDJMNLFL, CKMCPJAPGAI);
		tweenPosition.onFinished = delegate
		{
			TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
				TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, 1f, 0f).onFinished = null;
				Vector3 toScale = JEMANGPCGBN * 2f;
				toScale.z = 1f;
				Vector3 toScale2 = new Vector3(LIEAPAADBAI * 2f, LIEAPAADBAI * 2f, 1f);
				TweenScale.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, JEMANGPCGBN, toScale);
				TweenScale.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 3f, PBAKNFFMJFI, toScale2);
			};
		};
	}

	private void JNILEFMGFEP(UITweener FHHELGLPKEE)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 122f, 1175f, 1893f).onFinished = delegate
		{
			HPCBECGAPCI();
		};
	}

	private void AOCJEJCBLGD()
	{
		PBAKNFFMJFI = new Vector3(LIEAPAADBAI, LIEAPAADBAI, 1f);
		FDDFBILDABL.transform.localScale = PBAKNFFMJFI;
		MCEABPKAIAD.transform.localScale = PBAKNFFMJFI;
		TweenScale.Begin(MCEABPKAIAD.gameObject, 0f, PBAKNFFMJFI);
	}

	private void AOEHOMGMCEF()
	{
		TweenAlpha.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 335f, 271f, 1131f).onFinished = null;
		TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 150f, CKMCPJAPGAI, NPAGECEAPJJ, useLocal: false).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 71f, 17f, 1929f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 1088f, LGHHDJMNLFL, CKMCPJAPGAI);
		tweenPosition.onFinished = CMBMFNJILID;
	}

	private void HBJJAGHEACP(UITweener JNLOCAIIBKE)
	{
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 1365f, 123f).onFinished = NNMDFCKGNGL;
	}

	private void AJFEEHBOHPM()
	{
		PBAKNFFMJFI = new Vector3(LIEAPAADBAI, LIEAPAADBAI, 179f);
		FDDFBILDABL.transform.localScale = PBAKNFFMJFI;
		MCEABPKAIAD.transform.localScale = PBAKNFFMJFI;
		TweenScale.Begin(MCEABPKAIAD.gameObject, 1090f, PBAKNFFMJFI);
	}

	[CompilerGenerated]
	private void FDGJGBFMGCA(UITweener IMJFMBKEBDD)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 3f, new Vector3(OEFKMAKMIBP.x, OEFKMAKMIBP.y - OPPBAMHIDCI, ECICBNIKMHM.z), ECICBNIKMHM);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 2f, CKMCPJAPGAI);
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = delegate
			{
				TweenAlpha.Begin(INOLIBMAEAN.gameObject, HAMKIKMJHDP * 3f, 1f, 1f).onFinished = delegate
				{
					HPCBECGAPCI();
				};
			};
		};
	}

	public void StopAllAnimations()
	{
		InitializeAlphaZero();
		TweenPosition.Begin(INOLIBMAEAN.gameObject, 0f, IBCFBIJILKI).onFinished = null;
		TweenPosition.Begin(FDDFBILDABL.gameObject, 0f, OEFKMAKMIBP).onFinished = null;
		TweenPosition.Begin(MCEABPKAIAD.gameObject, 0f, LGHHDJMNLFL).onFinished = null;
		BJNBDOHAGFO();
		AOCJEJCBLGD();
	}

	private void IHFADOMALOE()
	{
		TweenAlpha.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 607f, 1087f, 1117f).onFinished = null;
		TweenPosition.Begin(FDDFBILDABL.gameObject, HAMKIKMJHDP * 514f, CKMCPJAPGAI, NPAGECEAPJJ, useLocal: false).onFinished = null;
		TweenAlpha.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 335f, 368f, 1870f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(MCEABPKAIAD.gameObject, HAMKIKMJHDP * 299f, LGHHDJMNLFL, CKMCPJAPGAI);
		tweenPosition.onFinished = KBPMMMDKHGA;
	}
}
