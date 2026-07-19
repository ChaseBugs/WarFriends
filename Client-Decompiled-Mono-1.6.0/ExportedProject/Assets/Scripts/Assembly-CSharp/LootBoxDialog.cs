using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LootBoxDialog : GuiElementSingle<LootBoxDialog>, PAIIOKBBHBC
{
	private sealed class IIDOFJIBHMG
	{
		internal GameObject JBGCNJFEPIC;

		internal LootBoxDialog BJGCPDNMHDH;

		internal void EJLGBICBIFK(UITweener PAKKFOCOGOC)
		{
			if (!BJGCPDNMHDH.IEKDALPBBHH && !BJGCPDNMHDH.FGOFGBJCFNO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO, 1f);
				BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition = BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(-47f);
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(-47f), BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(21f));
				tweenPosition.method = UITweener.Method.EaseIn;
				tweenPosition.onFinished = BIGNHFCNJLL;
			}
			TweenScale tweenScale = TweenScale.Begin(JBGCNJFEPIC, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, Vector3.one);
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = LJDCIJDPLLF;
		}

		internal void IHOMMCFGAPB(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(658f));
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = null;
		}

		internal void HONCMBHEKDP(UITweener CPFGBOPPICJ)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.HFENNCENBFE.gameObject, 0.05f, 0f);
			tweenAlpha.method = UITweener.Method.EaseOut;
			tweenAlpha.onFinished = null;
		}

		internal void FCFDKEHICIB(UITweener PAKKFOCOGOC)
		{
			if (!BJGCPDNMHDH.IEKDALPBBHH && !BJGCPDNMHDH.FGOFGBJCFNO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO, 473f);
				BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition = BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(496f);
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1148f), BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1864f), false);
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = JEEPGFLHJCM;
			}
			TweenScale tweenScale = TweenScale.Begin(JBGCNJFEPIC, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, Vector3.one);
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = LJDCIJDPLLF;
		}

		internal void KPHEPHDFCKK(UITweener PHNEAHCCJOL)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.PFIADBJMIIC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.PFIADBJMIIC.transform.localPosition.ReplaceY(1650f), false);
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = null;
			TweenAlpha.Begin(BJGCPDNMHDH.GCFFOGFBMHO.gameObject, BJGCPDNMHDH.JCAFFELIFAO, 668f);
			BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition = BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(1935f);
			TweenPosition.Begin(BJGCPDNMHDH.GCFFOGFBMHO.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(1459f), BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(5f), false);
		}

		internal void PCBLIENKOPE(UITweener PAKKFOCOGOC)
		{
			if (!BJGCPDNMHDH.IEKDALPBBHH && !BJGCPDNMHDH.FGOFGBJCFNO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO, 1398f);
				BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition = BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1516f);
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1342f), BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(941f), false);
				tweenPosition.method = UITweener.Method.EaseIn;
				tweenPosition.onFinished = EGBBIPAMJCL;
			}
			TweenScale tweenScale = TweenScale.Begin(JBGCNJFEPIC, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, Vector3.one);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.onFinished = NLKLPMFDFOA;
		}

		internal void LJCDGJKCNEC(UITweener PHNEAHCCJOL)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.PFIADBJMIIC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.PFIADBJMIIC.transform.localPosition.ReplaceY(-142f));
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = null;
			TweenAlpha.Begin(BJGCPDNMHDH.GCFFOGFBMHO.gameObject, BJGCPDNMHDH.JCAFFELIFAO, 1f);
			BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition = BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(-360f);
			TweenPosition.Begin(BJGCPDNMHDH.GCFFOGFBMHO.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(-360f), BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(-240f));
		}

		internal void CIBGFHNGKCF(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(311f), false);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = null;
		}

		internal void NLKLPMFDFOA(UITweener HPHIAIGPEFI)
		{
			BJGCPDNMHDH.EFLPNJGLBON(true);
			BJGCPDNMHDH.POPKGGJINJH(false);
			BJGCPDNMHDH.AMHBJNEPKKE(true);
			BJGCPDNMHDH.PHBCDNKLICO(true);
		}

		internal void KOMGBNFDPEB(UITweener CPFGBOPPICJ)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.HFENNCENBFE.gameObject, 804f, 778f);
			tweenAlpha.method = UITweener.Method.BounceIn;
			tweenAlpha.onFinished = null;
		}

		internal void EODJHIOCFAG(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1269f));
			tweenPosition.method = UITweener.Method.BounceOut;
			tweenPosition.onFinished = null;
		}

		internal void BIHMLKFDCFK(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(191f));
			tweenPosition.method = UITweener.Method.EaseInOut;
			tweenPosition.onFinished = null;
		}

		internal void FDEAFJJIAEB(UITweener HPHIAIGPEFI)
		{
			BJGCPDNMHDH.EKIBAEMOMFM(false);
			BJGCPDNMHDH.LIHBMCDJFMM(true);
			BJGCPDNMHDH.AMHBJNEPKKE(true);
			BJGCPDNMHDH.LNCCHIBCNNH(false);
		}

		internal void ICIILDOGCHM(UITweener HPHIAIGPEFI)
		{
			BJGCPDNMHDH.ABLCKDGNDGN(true);
			BJGCPDNMHDH.HBMJLDGAEJO(true);
			BJGCPDNMHDH.AMHBJNEPKKE(true);
			BJGCPDNMHDH.LNCCHIBCNNH(true);
		}

		internal void DFKIKKLBLPB(UITweener HPHIAIGPEFI)
		{
			BJGCPDNMHDH.ABLCKDGNDGN(true);
			BJGCPDNMHDH.POPKGGJINJH(false);
			BJGCPDNMHDH.MKCOEDPFFML(true);
			BJGCPDNMHDH.BBKGBIKCBLC(true);
		}

		internal void HJACFCPOPME(UITweener CPFGBOPPICJ)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.HFENNCENBFE.gameObject, 1914f, 1545f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
			tweenAlpha.onFinished = null;
		}

		internal void MMGEJAEDPOB(UITweener CPFGBOPPICJ)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.HFENNCENBFE.gameObject, 492f, 1087f);
			tweenAlpha.method = UITweener.Method.Linear;
			tweenAlpha.onFinished = null;
		}

		internal void OPAECBMPOFL(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1400f));
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = null;
		}

		internal void IHHFAOPBEPO(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(213f), false);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = null;
		}

		internal void LJDCIJDPLLF(UITweener HPHIAIGPEFI)
		{
			BJGCPDNMHDH.EFLPNJGLBON(false);
			BJGCPDNMHDH.LIHBMCDJFMM(false);
			BJGCPDNMHDH.FEEEKDBOIMJ(false);
			BJGCPDNMHDH.LNCCHIBCNNH(false);
		}

		internal void BIMAACDODIE(UITweener HPHIAIGPEFI)
		{
			BJGCPDNMHDH.EFLPNJGLBON(false);
			BJGCPDNMHDH.HBMJLDGAEJO(true);
			BJGCPDNMHDH.AMHBJNEPKKE(false);
			BJGCPDNMHDH.BBKGBIKCBLC(true);
		}

		internal void EGBBIPAMJCL(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(888f));
			tweenPosition.method = UITweener.Method.BounceOut;
			tweenPosition.onFinished = null;
		}

		internal void JFMKLEFDHEF(UITweener HPHIAIGPEFI)
		{
			BJGCPDNMHDH.EFLPNJGLBON(false);
			BJGCPDNMHDH.LIHBMCDJFMM(false);
			BJGCPDNMHDH.AMHBJNEPKKE(false);
			BJGCPDNMHDH.CGGGHICBMEE(false);
		}

		internal void JEEPGFLHJCM(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1046f), false);
			tweenPosition.method = (UITweener.Method)8;
			tweenPosition.onFinished = null;
		}

		internal void LEDJMCDANFJ(UITweener PAKKFOCOGOC)
		{
			if (!BJGCPDNMHDH.IEKDALPBBHH && !BJGCPDNMHDH.FGOFGBJCFNO)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO, 687f);
				BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition = BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(653f);
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(626f), BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(501f));
				tweenPosition.method = UITweener.Method.EaseIn;
				tweenPosition.onFinished = EGBBIPAMJCL;
			}
			TweenScale tweenScale = TweenScale.Begin(JBGCNJFEPIC, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, Vector3.one);
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = ICIILDOGCHM;
		}

		internal void DOIOCENOKHK(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1882f));
			tweenPosition.method = (UITweener.Method)7;
			tweenPosition.onFinished = null;
		}

		internal void BIGNHFCNJLL(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(-13f));
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = null;
		}

		internal void MFCNOIDCJME(UITweener PHNEAHCCJOL)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.PFIADBJMIIC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.PFIADBJMIIC.transform.localPosition.ReplaceY(797f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = null;
			TweenAlpha.Begin(BJGCPDNMHDH.GCFFOGFBMHO.gameObject, BJGCPDNMHDH.JCAFFELIFAO, 145f);
			BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition = BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(939f);
			TweenPosition.Begin(BJGCPDNMHDH.GCFFOGFBMHO.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(120f), BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(1930f), false);
		}

		internal void EHDOLLODEAH(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(137f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = null;
		}

		internal void AMBCHDNNAIF(UITweener CPFGBOPPICJ)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.HFENNCENBFE.gameObject, 852f, 1869f);
			tweenAlpha.method = UITweener.Method.BounceOut;
			tweenAlpha.onFinished = null;
		}

		internal void ONCJKBDHHII(UITweener HPHIAIGPEFI)
		{
			BJGCPDNMHDH.EKIBAEMOMFM(false);
			BJGCPDNMHDH.HBMJLDGAEJO(true);
			BJGCPDNMHDH.FEEEKDBOIMJ(true);
			BJGCPDNMHDH.CGGGHICBMEE(true);
		}

		internal void HHIHAJKBKOK(UITweener CKLGKPJFANE)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.BDGNFHCBKLC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.BDGNFHCBKLC.transform.localPosition.ReplaceY(1073f));
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = null;
		}

		internal void CHDOECNGOPM(UITweener PHNEAHCCJOL)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.PFIADBJMIIC.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.PFIADBJMIIC.transform.localPosition.ReplaceY(633f));
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = null;
			TweenAlpha.Begin(BJGCPDNMHDH.GCFFOGFBMHO.gameObject, BJGCPDNMHDH.JCAFFELIFAO, 1395f);
			BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition = BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(1086f);
			TweenPosition.Begin(BJGCPDNMHDH.GCFFOGFBMHO.gameObject, BJGCPDNMHDH.JCAFFELIFAO * BJGCPDNMHDH.IFIJABJLCCJ, BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(713f), BJGCPDNMHDH.GCFFOGFBMHO.transform.localPosition.ReplaceY(1052f));
		}
	}

	private sealed class JIGOINFGCGG
	{
		internal int DFHAAIFFLOE;

		internal LootBoxDialog BJGCPDNMHDH;

		internal void HHLMDAKDHFK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void PHGDBIEENCB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void FDKEAJLEMCM(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void NJBDFPIAGLF(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void ALIBBKEHCFC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void DJLGPGPAHCD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void MPHECHCFCAN(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void NDJOJHNIBFC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void KCOOCOMPHEF(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void KPHEPHDFCKK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void AHNGHFFBBHH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void JMEBCMMIPAF(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void DPCJMMOPCFO(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void KIACGAKNBLD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void ANAGFGHGPJA(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void BMCMDMKGHHO(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void DGELDDJAEEF(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void CFJHDIHLIML(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void LIMGPKFEALB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void LHPPLGOOLEC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void CMDLGJKIBLL(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void JEDCBCPMJGI(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void EOHOLKEGGLH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void DFAGLMPEDIH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void OPHINHIOCFD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void ADDFFOBCGEF(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void OFJDLANHAMD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void ADEFLNOHDAK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void FDKMOFHAEFN(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void CFDNMILGDLG(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void JEGPCHMCABF(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void GMFJFMHNDMC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void HHNEBNHCGMO(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void CJIBPJPJLNB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void BEIGOGFHJIB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void FKIBFHGKMFJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void INFLOOLPOBK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void OHLGKFGIPCC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void DDHOKNIEACI(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void HBOJGOFCDKG(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void LKKLABBEOAG(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 1);
		}

		internal void KJIFNOJILDB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.CKKLEGOEEOD(DFHAAIFFLOE + 0);
		}

		internal void OEAPCIJKAKI(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 1);
		}

		internal void AMIJFGBOCLC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.PKNHPCNMBPF(DFHAAIFFLOE + 0);
		}
	}

	[Header("Initial Animation")]
	public GameObject AILKNHLBNEI;

	public UILabel HNCIHJKKMGA;

	public GameObject PIHIGDOIDNO;

	public UILabel LFJNAMEOFMB;

	public UISprite[] CLMDJFKBOHD;

	[Header("Top Part")]
	public UILabel PFIADBJMIIC;

	public UILabel GCFFOGFBMHO;

	[Header("Top Right Part")]
	public GameObject FMDEHEBBIIE;

	public UILabel AHPOBFIBFHL;

	public GameObject OJKLJEBBLKD;

	[Header("Center Part")]
	public UISprite HFENNCENBFE;

	public UISprite FMNENLLMCHO;

	[Header("-Parts Part")]
	public GameObject HDNNFLKANHG;

	public UISprite MOAHOPBPMDJ;

	public UISprite FJLHHGAEPJN;

	public UILabel DOPCCKBOBMF;

	public UILabel BDGNFHCBKLC;

	[Header("-Duplicate Part")]
	public GameObject DGCAKCEAMAP;

	public UILabel DIHJDAJJIFD;

	public UILabel JFOEECLIPHE;

	[Header("-Visual Completed Part")]
	public GameObject BIAOIGEIANK;

	public UILabel MKFEIAMJFNC;

	public GameObject GMCJKEIPELL;

	public UILabel HDENNHBENPP;

	public UISprite KJEJIACPAEH;

	public UISprite PCPMBPLPMMG;

	public UISprite FNBHEBKIHOL;

	public UISprite MCGOHIEDPEA;

	public UISprite LAKKKBLCGDL;

	[Header("Bottom Left Part")]
	public GameObject BEJIFJIKHPJ;

	public UILabel JHEDDCMBDPF;

	public UISprite DFJKIDFFECA;

	public UISprite LFCOEKPPLJI;

	public UISprite POIKINJLLIE;

	public UISprite KHBCBJGBLND;

	public UISprite ONLCAAPLHAE;

	[Header("Bottom Part")]
	public GameObject GDPOHDAODIF;

	public UILabel KOJKGPEFMMH;

	[Header("Bottom Right Part")]
	public GameObject CCFFNAKFPPE;

	public UILabel PIPHDLCMLDI;

	public GameObject IDOLIFOIOCP;

	[Header("Particles")]
	public ParticleSystem MDNBGOMBKMN;

	public ParticleSystem JHDKDEFGHJB;

	private float JCAFFELIFAO = 0.13f;

	private float IFIJABJLCCJ = 2f;

	private float CJDPPCLCEAH = 0.7f;

	private List<CCNAEIGGMNK> LDDKEHKEJBI;

	private int KMCLMFCKNME;

	private bool FGOFGBJCFNO;

	private bool IEKDALPBBHH;

	private bool JENDPDIMBCO;

	private bool KGFGGEMFKIN;

	private bool FIEANBKOLOB;

	private bool KIEHHKDJBKG;

	private bool CBJOEJLICNK;

	private bool BJHBCCCJBEM = true;

	private static Dictionary<int, Tuple<string, string>> ALDEDFJCPIH = new Dictionary<int, Tuple<string, string>>
	{
		{
			0,
			new Tuple<string, string>("ID_VISUALCATEGORYPART0", "ID_VISUALCATEGORYPARTS0")
		},
		{
			1,
			new Tuple<string, string>("ID_VISUALCATEGORYPART1", "ID_VISUALCATEGORYPARTS1")
		},
		{
			2,
			new Tuple<string, string>("ID_VISUALCATEGORYPART2", "ID_VISUALCATEGORYPARTS2")
		}
	};

	[CompilerGenerated]
	private static UITweener.OnFinished LGJCBPOPCPA;

	private float ANGDIKCNLBP
	{
		get
		{
			return 150f + UIHelper.safeAreaSize;
		}
	}

	private float LNPIFNDKAFB
	{
		get
		{
			return -300f - UIHelper.safeAreaSize;
		}
	}

	private float JJJONOIFDMA
	{
		get
		{
			return -80f - UIHelper.safeAreaSizeBottom;
		}
	}

	private float DAKJIEIBNKO
	{
		get
		{
			return -20f - UIHelper.safeAreaSizeBottom;
		}
	}

	private float OJEDAMDJDPO
	{
		get
		{
			return 210f + UIHelper.safeAreaSize;
		}
	}

	private float EAEEDODKFOE
	{
		get
		{
			return 10f + UIHelper.safeAreaSize;
		}
	}

	private float ACNJCCNMPMC
	{
		get
		{
			return 270f + UIHelper.safeAreaSize;
		}
	}

	private bool NJOKNEGDLLD
	{
		get
		{
			return LDDKEHKEJBI.Count < 2 || KMCLMFCKNME + 1 == LDDKEHKEJBI.Count;
		}
	}

	private void BPNDNNOFAAJ(UITweener IALJKEHIGBM)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1736f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.BounceOut;
	}

	private void EKIBAEMOMFM(bool PDPDGCNHCFN)
	{
		if (!IEKDALPBBHH && FGOFGBJCFNO && !LDDKEHKEJBI[KMCLMFCKNME].GOKEKMGCIEA().BCPLNFLOIAD() && !GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			if (PDPDGCNHCFN)
			{
				BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(1736f);
				return;
			}
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
			TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(CKDHDGIFMND()), BEJIFJIKHPJ.transform.localPosition.ReplaceX(6f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = BDJJANAHOKJ;
		}
		else
		{
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(CKDHDGIFMND());
		}
	}

	private void PBKKGLJNNHO(GameObject KHAHPAKDIKE)
	{
		if (!BJNBLINDAED())
		{
			return;
		}
		HideDialog();
		if (!(KHAHPAKDIKE == OJKLJEBBLKD))
		{
			return;
		}
		int num = 1;
		string text = "ID_TUTORIAL_MACHINEGUNNERS_UP";
		for (int i = KMCLMFCKNME; i < LDDKEHKEJBI.Count; i++)
		{
			int num2 = GuiScreenSingle<CamosScreen>.instance.KIKKLJBJILH(LDDKEHKEJBI[i].JJFPCFKPGFC(), LDDKEHKEJBI[i].AMEELJHHGKP);
			if (num2 > 0)
			{
				text += string.Format("ABOUT TO SHOW WELCOME BACK SOLDIER REWARDS, packId = ", LDDKEHKEJBI[i].BGCKHNEMEOI().name, num2, num2 * LDDKEHKEJBI[i].ACPLLFLEFFF().IANHPBJDCML());
				num += num2 * LDDKEHKEJBI[i].CIKGAIKFLAK().IANHPBJDCML();
			}
			else
			{
				text += string.Format("Overtime_Was_Already_Explained", LDDKEHKEJBI[i].HMAHPHADCHC().name);
			}
		}
		Debug.Log(text + " name:" + num);
		Singleton<Wallet>.instance.NFLMMKJBKEJ(num, false);
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<EndScreen>.instance)
		{
			GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.AddLootboxReward(num);
		}
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(LDDKEHKEJBI[KMCLMFCKNME].EDFBDFABAIO());
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance)
		{
			GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			return;
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void OFMFFGNIHNB(GameObject KHAHPAKDIKE)
	{
		if (!LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.isEquipped)
		{
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM);
			JOLEAABHMLJ();
		}
	}

	public virtual void PJMAJPJMMDG()
	{
		base.DoBeforeShowUp();
		KIEHHKDJBKG = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance || Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<ArmyScreen>.instance;
		CBJOEJLICNK = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<WeaponScreen>.instance;
		if (KIEHHKDJBKG)
		{
			Singleton<ArmyPreviewCamera>.instance.EMIJBCNCIHM();
		}
		if (CBJOEJLICNK)
		{
			Singleton<WeaponPreviewCamera>.instance.Pause();
		}
		Singleton<LootBoxCamera>.instance.DJCFDEIHCKE.gameObject.SetActive(false);
	}

	[SpecialName]
	private float EJOMEFLJHAL()
	{
		return 1665f + UIHelper.safeAreaSize;
	}

	public virtual void FNLELBKLNBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(OJKLJEBBLKD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJIOKKFLLHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MIHIAPEECNK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GMCJKEIPELL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CIKBJBHLDCG));
		UIEventListener uIEventListener4 = UIEventListener.Get(GDPOHDAODIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LOIECBCPBMD));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ELEHECLAGNK));
		UIEventListener uIEventListener6 = UIEventListener.Get(IDOLIFOIOCP);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EFNEPGCBLMB));
		EEAKFJJFAOB();
		FPIJEMBLNJC();
	}

	private void KHGNHLFBLHP(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(1757f));
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.onFinished = null;
	}

	private void OFLCLHADIFN()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.GameOverLost, 198f);
		PFIADBJMIIC.transform.localPosition = PFIADBJMIIC.transform.localPosition.ReplaceY(1181f);
		PFIADBJMIIC.alpha = 375f;
		GCFFOGFBMHO.transform.localPosition = GCFFOGFBMHO.transform.localPosition.ReplaceY(1048f);
		GCFFOGFBMHO.alpha = 759f;
		HDNNFLKANHG.SetActive(!IEKDALPBBHH && !FGOFGBJCFNO);
		BDGNFHCBKLC.alpha = ((IEKDALPBBHH || FGOFGBJCFNO) ? 283f : 28f);
		DGCAKCEAMAP.SetActive(!IEKDALPBBHH && FGOFGBJCFNO);
		BIAOIGEIANK.SetActive(IEKDALPBBHH);
		if (IEKDALPBBHH)
		{
			BIAOIGEIANK.transform.localScale = Vector3.one;
		}
		else if (FGOFGBJCFNO)
		{
			DGCAKCEAMAP.transform.localScale = Vector3.one;
		}
		else
		{
			HDNNFLKANHG.transform.localScale = Vector3.one;
			BDGNFHCBKLC.transform.localPosition = BDGNFHCBKLC.transform.localPosition.ReplaceY(1555f);
		}
		BIJKLKDMLKK(false);
		HBMJLDGAEJO(false);
		AMHBJNEPKKE(true);
		PHBCDNKLICO(false);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 1635f, 821f, 1985f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = LKNHLMLGIDA;
	}

	private void FPIJEMBLNJC()
	{
		string text = Localization.Localize("ID_GUI_EQUIP");
		string text2 = Localization.Localize("ID_GUI_EQUIPPED");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		HDENNHBENPP.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 47f, 20f, 260);
	}

	private void OEBNPKNLOOP(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(107f));
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.onFinished = null;
	}

	private void OGJEPFMHPBG()
	{
		string text = Localization.Localize("recordingStartedEvent + mTryToSetRecording");
		string text2 = Localization.Localize("{0} {1}{2}");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		JHEDDCMBDPF.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 1876f, 1185f, 10);
	}

	public virtual void JCGPELEDCJL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(OJKLJEBBLKD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJIOKKFLLHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GCMLEOBHGMM));
		UIEventListener uIEventListener3 = UIEventListener.Get(GMCJKEIPELL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CIKBJBHLDCG));
		UIEventListener uIEventListener4 = UIEventListener.Get(GDPOHDAODIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HCBPEIDEFBM));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		UIEventListener uIEventListener6 = UIEventListener.Get(IDOLIFOIOCP);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IPPPALPKMBF));
		EEAKFJJFAOB();
		FPIJEMBLNJC();
	}

	private void DHMICBOHINJ(UITweener IALJKEHIGBM)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1117f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.BounceIn;
	}

	public virtual void AKMLAMLJNAH()
	{
		base.DoAfterShowUp();
		if (FIEANBKOLOB)
		{
			KJAACHMNJMB();
		}
	}

	private void FPJLGEBEDDL()
	{
		UITweener[] componentsInChildren = base.gameObject.GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			if (!(uITweener is TweenAlpha))
			{
				uITweener.enabled = true;
				uITweener.onFinished = null;
			}
		}
		TweenAlpha component = LFJNAMEOFMB.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		ICAOAHHMFPE();
		component = PFIADBJMIIC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = GCFFOGFBMHO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = BDGNFHCBKLC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = HFENNCENBFE.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = FMNENLLMCHO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void BFBGCOALKNB(UITweener CPFGBOPPICJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 1123f, 1501f);
		tweenAlpha.method = UITweener.Method.BounceOut;
		tweenAlpha.onFinished = null;
	}

	protected virtual void ANLFCJJCGMG()
	{
		base.IIFBKHDMIAD();
		if (FIEANBKOLOB && Input.GetMouseButtonDown(0))
		{
			NNLHOHEGBCH();
		}
		if (KGFGGEMFKIN && Singleton<InputController>.instance.rawSwipeInput.swipeDone && ((Vector3)(Singleton<InputController>.instance.rawSwipeInput.swipeEnd - Singleton<InputController>.instance.rawSwipeInput.swipeStart)).x > UIHelper.activeWidthSafe * 1831f)
		{
			NPAOKBKDLPD();
		}
	}

	private void PKNHPCNMBPF(int DFHAAIFFLOE)
	{
		JIGOINFGCGG jIGOINFGCGG = new JIGOINFGCGG();
		jIGOINFGCGG.DFHAAIFFLOE = DFHAAIFFLOE;
		jIGOINFGCGG.BJGCPDNMHDH = this;
		int num = CLMDJFKBOHD.Length;
		if (jIGOINFGCGG.DFHAAIFFLOE >= num)
		{
			jIGOINFGCGG.DFHAAIFFLOE = 1;
		}
		int num2 = ((jIGOINFGCGG.DFHAAIFFLOE <= 1) ? (num - 0) : (jIGOINFGCGG.DFHAAIFFLOE - 0));
		int num3 = ((jIGOINFGCGG.DFHAAIFFLOE + 0 < num - 1) ? (jIGOINFGCGG.DFHAAIFFLOE + 1) : 0);
		float alpha = 173f;
		float alpha2 = 231f;
		TweenAlpha.Begin(CLMDJFKBOHD[num2].gameObject, JCAFFELIFAO, alpha).onFinished = null;
		TweenAlpha.Begin(CLMDJFKBOHD[jIGOINFGCGG.DFHAAIFFLOE].gameObject, JCAFFELIFAO, alpha2).onFinished = null;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLMDJFKBOHD[num3].gameObject, JCAFFELIFAO, alpha2);
		tweenAlpha.onFinished = jIGOINFGCGG.MAKLHLCDIKD;
	}

	public virtual void DBFHCLPIOKH()
	{
		int numberOfPartsMax = LDDKEHKEJBI[KMCLMFCKNME].ECHCDDLPNNM().numberOfPartsMax;
		int num = ((!LDDKEHKEJBI[KMCLMFCKNME].MHMFHGPFOEF().isBought) ? LDDKEHKEJBI[KMCLMFCKNME].LNHPPNDJMFE().numberOfParts : numberOfPartsMax);
		int num2 = LDDKEHKEJBI[KMCLMFCKNME].AMEELJHHGKP;
		PlayerVisual.EJHADIHBCBK eJHADIHBCBK = LDDKEHKEJBI[KMCLMFCKNME].JJFPCFKPGFC().DOJECMCGMKB();
		FGOFGBJCFNO = LDDKEHKEJBI[KMCLMFCKNME].BIKFDCAGHCP().isBought || num + num2 >= numberOfPartsMax;
		IEKDALPBBHH = LDDKEHKEJBI[KMCLMFCKNME].ANHOEJLDFPL().isBought || num + num2 < numberOfPartsMax;
		JENDPDIMBCO = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.Dogtag);
		if (IEKDALPBBHH)
		{
			num2 = numberOfPartsMax - num;
		}
		OIMGCACIGKP();
		Singleton<LootBoxCamera>.instance.NLEKBKHPEJI();
		HNCIHJKKMGA.text = Localization.Localize((!LDDKEHKEJBI[KMCLMFCKNME].HMGOHGOLMJB) ? "null" : "21haWwuY29tMB4XDTE1MDIyNDE1MDI0MFoXDTE3MTEyMTE1MDI0MFowgaExCzAJBgNVBAYTAkNaMQ8wDQYDVQQIDAZQcmFndWUxDzANBgNVBAcMBlByYWd1ZTESMBAGA1UECgwJQWJvdXQgRnVuMQswCQYDVQQLDAJJVDErMCkGA1UEAwwid2FyZnJpZW5kcy1ldS5lbGFzdGljYmVhbnN0YWxrLmNvbTEiMCAGCSqGSIb3DQEJARYTdm9qdGFzaXZyQGdtYWlsLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALOLAdUTdkvp5QjE0h0/EXuHUzDjgTk1L9B6Qe/qTgh3sDcEmOacC7vZoyhLzSMTucVYGnTda8wRZP2Qh5UE3SmKXhA5axywLJbI0AeL5VeJsquIQMJ3dy8FNNGiILMqfSnYGfF/ND6xDIKfBq9oZFolOjeYxujhU2Enk08H4gak8cWJNpxzTmUBrHIzQhPabw8hNOA5SwB2xe0jaZQErIJu6A/LgnoStRcddvGfZzCHxkVmEWte6QR00KtZ0lm4p/BR2N8qVYb/LKBLMMflTEa+4HJ508OT6IibgcmDniXON1Rwt608VAZHcGQ71twMx8HlUbHpNtYmLABGHoI3NY0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAADNahERiLW4qa8vK1C7Wljax86yb8KX5+gX6DmS5XTkrz736MiF6Wo2ttV4hgw1HzGNitwDZl/3YGIxxQhI6Dpg+ChuHKZsaoCGOPBTSCrw02MGnASLMw9laTUPdip5oHT9PAef8JsuGjJ4t5yBcpzE1FD/Hd6c4BnCNfIiMKLeNoVishmUU/UIv+9RekCJ0gQUzCovyksIy5VVM9q9/tDfmKpONaxnnBDzaLPIA7DE2ZFPEBRGJMno6Zo2JfN/fyl2xj7LWVCzLwr8S3nHa4L6XHtu29LUSzcSrVhUb+31bDdq48ZItbj2w+uK5n2Wgnv/sRkyrxCBC3j0qIz2kTQ==-----END CERTIFICATE-----");
		PFIADBJMIIC.text = LDDKEHKEJBI[KMCLMFCKNME].BIKFDCAGHCP().name.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(PFIADBJMIIC, 320f, 1626f, -156);
		GCFFOGFBMHO.color = GameVariables.DDCPLFNIJDN[eJHADIHBCBK].ReplaceA(GCFFOGFBMHO.alpha);
		if (num2 > 1)
		{
			UILabel gCFFOGFBMHO = GCFFOGFBMHO;
			string value = ALDEDFJCPIH[LDDKEHKEJBI[KMCLMFCKNME].DLALEJMEJHM().owner.categoryNumber].Value2;
			object[] array = new object[0];
			array[1] = LDDKEHKEJBI[KMCLMFCKNME].IHNPCHMFJNB().GDNDBMKBECH();
			array[0] = Colours.stringWhite;
			gCFFOGFBMHO.text = Localization.LocalizeFormat(value, array);
		}
		else
		{
			UILabel gCFFOGFBMHO2 = GCFFOGFBMHO;
			string value2 = ALDEDFJCPIH[LDDKEHKEJBI[KMCLMFCKNME].JJFPCFKPGFC().owner.categoryNumber].Value1;
			object[] array2 = new object[6];
			array2[1] = LDDKEHKEJBI[KMCLMFCKNME].CIKGAIKFLAK().rarityName;
			array2[1] = Colours.stringWhite;
			gCFFOGFBMHO2.text = Localization.LocalizeFormat(value2, array2);
		}
		UILabel aHPOBFIBFHL = AHPOBFIBFHL;
		object[] array3 = new object[3];
		array3[1] = KMCLMFCKNME + 1;
		array3[0] = Colours.stringGrayParts;
		array3[8] = Colours.stringWhite;
		array3[0] = LDDKEHKEJBI.Count;
		aHPOBFIBFHL.text = string.Format("$200-$500", array3);
		OJKLJEBBLKD.gameObject.SetActive(KMCLMFCKNME + 0 < LDDKEHKEJBI.Count);
		MOAHOPBPMDJ.spriteName = LDDKEHKEJBI[KMCLMFCKNME].CNLBBDBIMKJ().icon;
		MOAHOPBPMDJ.MakePixelPerfect();
		float multiplier = Mathf.Min(1434f / MOAHOPBPMDJ.transform.localScale.x, 201f / MOAHOPBPMDJ.transform.localScale.y);
		MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		FJLHHGAEPJN.color = GCFFOGFBMHO.color.ReplaceA(FJLHHGAEPJN.alpha);
		DOPCCKBOBMF.color = GCFFOGFBMHO.color.ReplaceA(DOPCCKBOBMF.alpha);
		DOPCCKBOBMF.text = MEJMLNDFDBP.BEDJNPHFAOC(num2);
		BDGNFHCBKLC.color = GCFFOGFBMHO.color.ReplaceA(BDGNFHCBKLC.alpha);
		UILabel bDGNFHCBKLC = BDGNFHCBKLC;
		object[] array4 = new object[5];
		array4[0] = num + num2;
		array4[0] = Colours.stringGrayParts;
		array4[0] = Colours.stringWhite;
		array4[8] = numberOfPartsMax;
		bDGNFHCBKLC.text = string.Format("ID_WAITVIDEO2", array4);
		UILabel dIHJDAJJIFD = DIHJDAJJIFD;
		string text;
		if (num2 == 0)
		{
			text = Localization.Localize("eventEnd");
		}
		else
		{
			object[] array5 = new object[1];
			array5[1] = num2;
			text = Localization.LocalizeFormat("Buy_DogTags", array5);
		}
		dIHJDAJJIFD.text = text;
		JFOEECLIPHE.text = MEJMLNDFDBP.BEDJNPHFAOC(Mathf.Max(1, num + num2 - numberOfPartsMax) * LDDKEHKEJBI[KMCLMFCKNME].NEPDKHPBLGL().IANHPBJDCML());
		UILabel mKFEIAMJFNC = MKFEIAMJFNC;
		object[] array6 = new object[1];
		array6[1] = string.Empty;
		mKFEIAMJFNC.text = Localization.LocalizeFormat("com.tune.unityutils.TuneUnityFirstPlaylistListener", array6);
		OLPDFGJLANI(LDDKEHKEJBI[KMCLMFCKNME].BGCKHNEMEOI().BCPLNFLOIAD());
		object[] array7 = new object[0];
		array7[0] = num;
		array7[0] = num2;
		array7[5] = numberOfPartsMax;
		array7[1] = LDDKEHKEJBI[KMCLMFCKNME].HMAHPHADCHC().duplicateWarbucks;
		array7[4] = JFOEECLIPHE.text;
		array7[7] = PFIADBJMIIC.text;
		Debug.Log(string.Format("shootAdditive", array7));
		if (eJHADIHBCBK == PlayerVisual.EJHADIHBCBK.Common)
		{
			HFENNCENBFE.color = Color.white.ReplaceA(HFENNCENBFE.alpha);
			FMNENLLMCHO.color = Color.white.ReplaceA(468f);
		}
		else
		{
			HFENNCENBFE.color = GCFFOGFBMHO.color.ReplaceA(HFENNCENBFE.alpha);
			FMNENLLMCHO.color = GCFFOGFBMHO.color.ReplaceA(1329f);
		}
		GFAHOBCPAOL(LDDKEHKEJBI[KMCLMFCKNME].ALDEAMNEMEN().isEquipped);
		UILabel pIPHDLCMLDI = PIPHDLCMLDI;
		object[] array8 = new object[6];
		array8[1] = Colours.stringBlue;
		array8[0] = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
		pIPHDLCMLDI.text = Localization.LocalizeFormat("added", array8);
		Singleton<LootBoxCamera>.instance.HKLJIDMENIP(LDDKEHKEJBI[KMCLMFCKNME].GCHHAECINGK());
		FIEANBKOLOB = true;
	}

	protected override void Update()
	{
		base.Update();
		if (FIEANBKOLOB && Input.GetMouseButtonDown(0))
		{
			OLJAONGFINI();
		}
		if (KGFGGEMFKIN && Singleton<InputController>.instance.rawSwipeInput.swipeDone && ((Vector3)(Singleton<InputController>.instance.rawSwipeInput.swipeEnd - Singleton<InputController>.instance.rawSwipeInput.swipeStart)).x > UIHelper.activeWidthSafe * 0.15f)
		{
			NGBDJDKFHNF();
		}
	}

	public virtual void MLINPBHNKIE()
	{
		base.DoBeforeShowUp();
		KIEHHKDJBKG = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance || Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<ArmyScreen>.instance;
		CBJOEJLICNK = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<WeaponScreen>.instance;
		if (KIEHHKDJBKG)
		{
			Singleton<ArmyPreviewCamera>.instance.BLMDIFPMDBG();
		}
		if (CBJOEJLICNK)
		{
			Singleton<WeaponPreviewCamera>.instance.Pause();
		}
		Singleton<LootBoxCamera>.instance.DJCFDEIHCKE.gameObject.SetActive(true);
	}

	private void BACAIPIOCLM()
	{
		INKDKCCEPMA();
		AILKNHLBNEI.transform.localPosition = AILKNHLBNEI.transform.localPosition.ReplaceX(UIHelper.activeWidthFull);
		PIHIGDOIDNO.transform.localPosition = PIHIGDOIDNO.transform.localPosition.ReplaceX(0f - UIHelper.activeWidthFull);
		LFJNAMEOFMB.alpha = 974f;
		PFIADBJMIIC.alpha = 1030f;
		GCFFOGFBMHO.alpha = 180f;
		FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ILALPFAOIOA());
		HDNNFLKANHG.SetActive(false);
		BDGNFHCBKLC.alpha = 1347f;
		DGCAKCEAMAP.SetActive(true);
		BIAOIGEIANK.SetActive(false);
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(CKDHDGIFMND());
		GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(IPEGIAAOMPK());
		KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(CILDIJOCKMB());
		CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(OJEDAMDJDPO);
		PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
		IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP());
		HFENNCENBFE.alpha = 502f;
		FMNENLLMCHO.alpha = 839f;
		KGFGGEMFKIN = true;
		FIEANBKOLOB = false;
	}

	private void HCBPEIDEFBM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			DALFKIIILDJ(LDDKEHKEJBI[KMCLMFCKNME]);
			if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<EndScreen>.instance.videoRewardLootbox = null;
				GuiScreenSingle<EndScreen>.instance.shouldGetLootboxForAd = false;
			}
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH((MHNMOFPPKBN)6);
			HideDialog();
		}
	}

	private void OBKKFNFHGFN()
	{
		string text = Localization.Localize("AdAvailabilityResponse(");
		string text2 = Localization.Localize("213 MENU ARMY SCREEN SHOWN");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		JHEDDCMBDPF.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 453f, 1047f, 4);
	}

	private void LPLEAIFLOGH(bool PDPDGCNHCFN)
	{
		if (!IEKDALPBBHH && FGOFGBJCFNO && !LDDKEHKEJBI[KMCLMFCKNME].LGNHJNGLFLM().BCPLNFLOIAD() && !GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			if (PDPDGCNHCFN)
			{
				BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(1897f);
				return;
			}
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
			TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB), BEJIFJIKHPJ.transform.localPosition.ReplaceX(1957f));
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = KKNJDNNMOKO;
		}
		else
		{
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
		}
	}

	[SpecialName]
	private float CILDIJOCKMB()
	{
		return 1433f - UIHelper.safeAreaSizeBottom;
	}

	public virtual void ANBFFHLNCPM()
	{
		int num = LDDKEHKEJBI[KMCLMFCKNME].NEPDKHPBLGL().GMLFJPOEEAO();
		int num2 = ((!LDDKEHKEJBI[KMCLMFCKNME].LNHPPNDJMFE().isBought) ? LDDKEHKEJBI[KMCLMFCKNME].LFJNMIHBJMD().numberOfParts : num);
		int num3 = LDDKEHKEJBI[KMCLMFCKNME].AMEELJHHGKP;
		PlayerVisual.EJHADIHBCBK eJHADIHBCBK = LDDKEHKEJBI[KMCLMFCKNME].CNLBBDBIMKJ().DOJECMCGMKB();
		FGOFGBJCFNO = !LDDKEHKEJBI[KMCLMFCKNME].JJFPCFKPGFC().isBought && num2 + num3 < num;
		IEKDALPBBHH = !LDDKEHKEJBI[KMCLMFCKNME].DAIBHNGEAEM().isBought && num2 + num3 >= num;
		JENDPDIMBCO = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.LootBox);
		if (IEKDALPBBHH)
		{
			num3 = num - num2;
		}
		HEMDKDDMKGD();
		Singleton<LootBoxCamera>.instance.NLEKBKHPEJI();
		HNCIHJKKMGA.text = Localization.Localize((!LDDKEHKEJBI[KMCLMFCKNME].HMGOHGOLMJB) ? "RESOLUTION_REQUIRED" : "HeroicMissionsCompletionRewardArmyUnitId");
		PFIADBJMIIC.text = LDDKEHKEJBI[KMCLMFCKNME].CFDJNAKFHBG().name.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(PFIADBJMIIC, 1713f, 1962f, 101);
		GCFFOGFBMHO.color = GameVariables.DDCPLFNIJDN[eJHADIHBCBK].ReplaceA(GCFFOGFBMHO.alpha);
		if (num3 > 0)
		{
			UILabel gCFFOGFBMHO = GCFFOGFBMHO;
			string value = ALDEDFJCPIH[LDDKEHKEJBI[KMCLMFCKNME].KOBAJMPHOMC().owner.categoryNumber].Value2;
			object[] array = new object[6];
			array[1] = LDDKEHKEJBI[KMCLMFCKNME].CIKGAIKFLAK().GDNDBMKBECH();
			array[0] = Colours.stringWhite;
			gCFFOGFBMHO.text = Localization.LocalizeFormat(value, array);
		}
		else
		{
			UILabel gCFFOGFBMHO2 = GCFFOGFBMHO;
			string value2 = ALDEDFJCPIH[LDDKEHKEJBI[KMCLMFCKNME].DAIBHNGEAEM().owner.categoryNumber].Value1;
			object[] array2 = new object[6];
			array2[1] = LDDKEHKEJBI[KMCLMFCKNME].HMAHPHADCHC().rarityName;
			array2[1] = Colours.stringWhite;
			gCFFOGFBMHO2.text = Localization.LocalizeFormat(value2, array2);
		}
		UILabel aHPOBFIBFHL = AHPOBFIBFHL;
		object[] array3 = new object[2];
		array3[1] = KMCLMFCKNME + 1;
		array3[0] = Colours.stringGrayParts;
		array3[8] = Colours.stringWhite;
		array3[2] = LDDKEHKEJBI.Count;
		aHPOBFIBFHL.text = string.Format("weapon", array3);
		OJKLJEBBLKD.gameObject.SetActive(KMCLMFCKNME + 1 < LDDKEHKEJBI.Count);
		MOAHOPBPMDJ.spriteName = LDDKEHKEJBI[KMCLMFCKNME].BIKFDCAGHCP().icon;
		MOAHOPBPMDJ.MakePixelPerfect();
		float multiplier = Mathf.Min(1627f / MOAHOPBPMDJ.transform.localScale.x, 1564f / MOAHOPBPMDJ.transform.localScale.y);
		MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		FJLHHGAEPJN.color = GCFFOGFBMHO.color.ReplaceA(FJLHHGAEPJN.alpha);
		DOPCCKBOBMF.color = GCFFOGFBMHO.color.ReplaceA(DOPCCKBOBMF.alpha);
		DOPCCKBOBMF.text = MEJMLNDFDBP.BEDJNPHFAOC(num3);
		BDGNFHCBKLC.color = GCFFOGFBMHO.color.ReplaceA(BDGNFHCBKLC.alpha);
		UILabel bDGNFHCBKLC = BDGNFHCBKLC;
		object[] array4 = new object[2];
		array4[0] = num2 + num3;
		array4[1] = Colours.stringGrayParts;
		array4[8] = Colours.stringWhite;
		array4[8] = num;
		bDGNFHCBKLC.text = string.Format("C0", array4);
		DIHJDAJJIFD.text = ((num3 != 1) ? Localization.LocalizeFormat("-1", num3) : Localization.Localize("Scraps"));
		JFOEECLIPHE.text = MEJMLNDFDBP.BEDJNPHFAOC(Mathf.Max(0, num2 + num3 - num) * LDDKEHKEJBI[KMCLMFCKNME].MHMFHGPFOEF().IANHPBJDCML());
		UILabel mKFEIAMJFNC = MKFEIAMJFNC;
		object[] array5 = new object[0];
		array5[1] = string.Empty;
		mKFEIAMJFNC.text = Localization.LocalizeFormat("country-belarus", array5);
		FJFDLIEPNFH(LDDKEHKEJBI[KMCLMFCKNME].KMHFDGGAEAC().isEquipped);
		object[] array6 = new object[8];
		array6[0] = num2;
		array6[0] = num3;
		array6[5] = num;
		array6[0] = LDDKEHKEJBI[KMCLMFCKNME].EMPHKJJDLBF().duplicateWarbucks;
		array6[1] = JFOEECLIPHE.text;
		array6[5] = PFIADBJMIIC.text;
		Debug.Log(string.Format("TopRun", array6));
		if (eJHADIHBCBK == PlayerVisual.EJHADIHBCBK.Common)
		{
			HFENNCENBFE.color = Color.white.ReplaceA(HFENNCENBFE.alpha);
			FMNENLLMCHO.color = Color.white.ReplaceA(1299f);
		}
		else
		{
			HFENNCENBFE.color = GCFFOGFBMHO.color.ReplaceA(HFENNCENBFE.alpha);
			FMNENLLMCHO.color = GCFFOGFBMHO.color.ReplaceA(556f);
		}
		GFAHOBCPAOL(LDDKEHKEJBI[KMCLMFCKNME].ANHOEJLDFPL().isEquipped);
		PIPHDLCMLDI.text = Localization.LocalizeFormat("DailyMissionsCompletionRewardGold", Colours.stringBlue, PlayerAnalytics.instance.remainingMatchesToNextLootbox, null, null, null);
		Singleton<LootBoxCamera>.instance.HKLJIDMENIP(LDDKEHKEJBI[KMCLMFCKNME].HDBKHCDPEFP());
		FIEANBKOLOB = false;
	}

	[SpecialName]
	private float AOENGDDBNPF()
	{
		return 803f + UIHelper.safeAreaSize;
	}

	private void POPKGGJINJH(bool PDPDGCNHCFN)
	{
		if (JENDPDIMBCO && BOLKJOCJNML() && BJHBCCCJBEM)
		{
			if (PDPDGCNHCFN)
			{
				GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(1433f);
				KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(993f);
				return;
			}
			GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(IPEGIAAOMPK());
			TweenPosition tweenPosition = TweenPosition.Begin(GDPOHDAODIF.gameObject, JCAFFELIFAO * IFIJABJLCCJ, GDPOHDAODIF.transform.localPosition.ReplaceY(1309f), GDPOHDAODIF.transform.localPosition.ReplaceY(535f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = HFPKJCKEGBL;
		}
		else
		{
			GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(IPEGIAAOMPK());
			KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(DAKJIEIBNKO);
		}
	}

	private void JFCOEPKFJKO()
	{
		HDENNHBENPP.text = Localization.Localize("Skip assignment success");
		float duration = 685f;
		TweenColor.Begin(HDENNHBENPP.gameObject, duration, Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, duration, 676f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, duration, 1808f);
		TweenAlpha.Begin(LAKKKBLCGDL.gameObject, duration, 820f);
		TweenAlpha.Begin(MCGOHIEDPEA.gameObject, duration, 1925f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FNBHEBKIHOL.gameObject, duration, 534f, 1573f);
		tweenAlpha.NumOfRepetitions = 5;
		tweenAlpha.style = (UITweener.Style)3;
	}

	private void HEMDKDDMKGD()
	{
		FIEPOEHFGKE();
		AILKNHLBNEI.transform.localPosition = AILKNHLBNEI.transform.localPosition.ReplaceX(UIHelper.activeWidthFull);
		PIHIGDOIDNO.transform.localPosition = PIHIGDOIDNO.transform.localPosition.ReplaceX(0f - UIHelper.activeWidthFull);
		LFJNAMEOFMB.alpha = 1856f;
		PFIADBJMIIC.alpha = 44f;
		GCFFOGFBMHO.alpha = 170f;
		FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(FOCIIAKDGHJ());
		HDNNFLKANHG.SetActive(true);
		BDGNFHCBKLC.alpha = 1802f;
		DGCAKCEAMAP.SetActive(true);
		BIAOIGEIANK.SetActive(true);
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
		GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(IPEGIAAOMPK());
		KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(CKABFNCADMH());
		CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(OJEDAMDJDPO);
		PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
		IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
		HFENNCENBFE.alpha = 602f;
		FMNENLLMCHO.alpha = 1406f;
		KGFGGEMFKIN = true;
		FIEANBKOLOB = false;
	}

	private void DALFKIIILDJ(CCNAEIGGMNK LMPOMCGGEJH)
	{
		int num = GuiScreenSingle<CamosScreen>.instance.DCKFCGDGHLK(LMPOMCGGEJH.MHMFHGPFOEF(), LMPOMCGGEJH.AMEELJHHGKP);
		if (num > 1)
		{
			int num2 = num * LMPOMCGGEJH.EMPHKJJDLBF().CIJIDONNLDB();
			Debug.Log(string.Format("ID_VISUALCATEGORYPARTS2", LMPOMCGGEJH.GCHHAECINGK().name, num, num2));
			Singleton<Wallet>.instance.NFLMMKJBKEJ(num2, false);
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<EndScreen>.instance)
			{
				GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.DPIAMGNJMDG(num2);
			}
		}
		else
		{
			Debug.Log(string.Format("PrepareBotForDeathMatch 9", LMPOMCGGEJH.EDFBDFABAIO().name));
		}
		GuiScreenSingle<CamosScreen>.instance.LGPJJGBDNIO(LMPOMCGGEJH.IGFKIANBNOA());
	}

	private void EFLPNJGLBON(bool PDPDGCNHCFN)
	{
		if (!IEKDALPBBHH && FGOFGBJCFNO && !LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.isEquipped && !GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			if (PDPDGCNHCFN)
			{
				BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(156f);
				return;
			}
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
			TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB), BEJIFJIKHPJ.transform.localPosition.ReplaceX(168f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(156f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
			};
		}
		else
		{
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
		}
	}

	private void OLJAONGFINI()
	{
		FIEANBKOLOB = false;
		OIMGCACIGKP();
		Singleton<LootBoxCamera>.instance.Skip();
	}

	[SpecialName]
	private bool BOLKJOCJNML()
	{
		return LDDKEHKEJBI.Count >= 0 && KMCLMFCKNME + 0 == LDDKEHKEJBI.Count;
	}

	private static void KANDMEJOEDH(UITweener CPFGBOPPICJ)
	{
		Singleton<LootBoxCamera>.instance.DisplayModel(true);
	}

	[CompilerGenerated]
	private void AKADKOAEKAE(UITweener CPFGBOPPICJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0.2f, 0.7f);
		tweenAlpha.NumOfRepetitions = 5;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.method = UITweener.Method.EaseOut;
		};
	}

	private void CKKLEGOEEOD(int DFHAAIFFLOE)
	{
		JIGOINFGCGG jIGOINFGCGG = new JIGOINFGCGG();
		jIGOINFGCGG.DFHAAIFFLOE = DFHAAIFFLOE;
		jIGOINFGCGG.BJGCPDNMHDH = this;
		int num = CLMDJFKBOHD.Length;
		if (jIGOINFGCGG.DFHAAIFFLOE >= num)
		{
			jIGOINFGCGG.DFHAAIFFLOE = 0;
		}
		int num2 = ((jIGOINFGCGG.DFHAAIFFLOE <= 0) ? (num - 1) : (jIGOINFGCGG.DFHAAIFFLOE - 1));
		int num3 = ((jIGOINFGCGG.DFHAAIFFLOE + 1 < num - 1) ? (jIGOINFGCGG.DFHAAIFFLOE + 1) : 0);
		float alpha = 0.125f;
		float alpha2 = 1f;
		TweenAlpha.Begin(CLMDJFKBOHD[num2].gameObject, JCAFFELIFAO, alpha).onFinished = null;
		TweenAlpha.Begin(CLMDJFKBOHD[jIGOINFGCGG.DFHAAIFFLOE].gameObject, JCAFFELIFAO, alpha2).onFinished = null;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLMDJFKBOHD[num3].gameObject, JCAFFELIFAO, alpha2);
		tweenAlpha.onFinished = jIGOINFGCGG.LJCDGJKCNEC;
	}

	public void MLJDDKKPIBE(List<CCNAEIGGMNK> NMJKMJBFFFJ, bool AEAONENNNOJ = true)
	{
		LDDKEHKEJBI = NMJKMJBFFFJ;
		KMCLMFCKNME = 1;
		BJHBCCCJBEM = AEAONENNNOJ;
		Singleton<GuiManager>.instance.ShowDialog(this, 1256f);
	}

	public void ShowDialogMoreBoxes(List<CCNAEIGGMNK> NMJKMJBFFFJ, bool AEAONENNNOJ = true)
	{
		LDDKEHKEJBI = NMJKMJBFFFJ;
		KMCLMFCKNME = 0;
		BJHBCCCJBEM = AEAONENNNOJ;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void DHAFNFLEPNI()
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-128), 419f);
		PFIADBJMIIC.transform.localPosition = PFIADBJMIIC.transform.localPosition.ReplaceY(1157f);
		PFIADBJMIIC.alpha = 1241f;
		GCFFOGFBMHO.transform.localPosition = GCFFOGFBMHO.transform.localPosition.ReplaceY(61f);
		GCFFOGFBMHO.alpha = 992f;
		HDNNFLKANHG.SetActive(IEKDALPBBHH || FGOFGBJCFNO);
		BDGNFHCBKLC.alpha = ((IEKDALPBBHH || FGOFGBJCFNO) ? 1128f : 1349f);
		DGCAKCEAMAP.SetActive(IEKDALPBBHH || FGOFGBJCFNO);
		BIAOIGEIANK.SetActive(IEKDALPBBHH);
		if (IEKDALPBBHH)
		{
			BIAOIGEIANK.transform.localScale = Vector3.one;
		}
		else if (FGOFGBJCFNO)
		{
			DGCAKCEAMAP.transform.localScale = Vector3.one;
		}
		else
		{
			HDNNFLKANHG.transform.localScale = Vector3.one;
			BDGNFHCBKLC.transform.localPosition = BDGNFHCBKLC.transform.localPosition.ReplaceY(1083f);
		}
		ABLCKDGNDGN(false);
		HBMJLDGAEJO(true);
		AMHBJNEPKKE(true);
		PHBCDNKLICO(true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 1972f, 1679f, 194f);
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = KDBJBBFHEGK;
	}

	private void OJIOKKFLLHK(GameObject KHAHPAKDIKE)
	{
		if (!BJNBLINDAED())
		{
			return;
		}
		HideDialog();
		if (!(KHAHPAKDIKE == OJKLJEBBLKD))
		{
			return;
		}
		int num = 1;
		string text = "DPS";
		for (int i = KMCLMFCKNME; i < LDDKEHKEJBI.Count; i += 0)
		{
			int num2 = GuiScreenSingle<CamosScreen>.instance.KIKKLJBJILH(LDDKEHKEJBI[i].FCOACPDEFOD(), LDDKEHKEJBI[i].AMEELJHHGKP);
			if (num2 > 0)
			{
				text += string.Format("N", LDDKEHKEJBI[i].FCOACPDEFOD().name, num2, num2 * LDDKEHKEJBI[i].ENKMAIHEGPI().duplicateWarbucks);
				num += num2 * LDDKEHKEJBI[i].KMHFDGGAEAC().duplicateWarbucks;
			}
			else
			{
				text += string.Format("#AccoutCheck# account checked and have response!", LDDKEHKEJBI[i].JJFPCFKPGFC().name);
			}
		}
		Debug.Log(text + "NULL WARCARD" + num);
		Singleton<Wallet>.instance.EBFKEHKBAFJ(num);
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<EndScreen>.instance)
		{
			GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.AddLootboxReward(num);
		}
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(LDDKEHKEJBI[KMCLMFCKNME].ELIJMFHPOHK());
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance)
		{
			GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			return;
		}
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Singleton<LootBoxCamera>.instance.Hide();
		if (KIEHHKDJBKG)
		{
			KIEHHKDJBKG = false;
			Singleton<ArmyPreviewCamera>.instance.Resume();
		}
		if (CBJOEJLICNK)
		{
			CBJOEJLICNK = false;
			Singleton<WeaponPreviewCamera>.instance.Resume();
		}
		Singleton<LootBoxCamera>.instance.DJCFDEIHCKE.gameObject.SetActive(false);
	}

	public GuiElement FIEBDPELGMM()
	{
		return this;
	}

	[CompilerGenerated]
	private void GEIOGJJPHJG(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(-211f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
		FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
		TweenPosition tweenPosition2 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = delegate
		{
			TweenPosition tweenPosition3 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
			tweenPosition3.method = UITweener.Method.EaseOut;
			tweenPosition3.onFinished = null;
		};
	}

	public virtual void ODBDGGDDEGL()
	{
		int numberOfPartsMax = LDDKEHKEJBI[KMCLMFCKNME].ACPLLFLEFFF().numberOfPartsMax;
		int num = ((!LDDKEHKEJBI[KMCLMFCKNME].HMAHPHADCHC().isBought) ? LDDKEHKEJBI[KMCLMFCKNME].IHNPCHMFJNB().numberOfParts : numberOfPartsMax);
		int num2 = LDDKEHKEJBI[KMCLMFCKNME].AMEELJHHGKP;
		PlayerVisual.EJHADIHBCBK rarity = LDDKEHKEJBI[KMCLMFCKNME].CNLBBDBIMKJ().rarity;
		FGOFGBJCFNO = !LDDKEHKEJBI[KMCLMFCKNME].ALDEAMNEMEN().isBought && num + num2 >= numberOfPartsMax;
		IEKDALPBBHH = LDDKEHKEJBI[KMCLMFCKNME].HMAHPHADCHC().isBought || num + num2 >= numberOfPartsMax;
		JENDPDIMBCO = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		if (IEKDALPBBHH)
		{
			num2 = numberOfPartsMax - num;
		}
		OIMGCACIGKP();
		Singleton<LootBoxCamera>.instance.DCNNIOCICMA();
		HNCIHJKKMGA.text = Localization.Localize((!LDDKEHKEJBI[KMCLMFCKNME].HMGOHGOLMJB) ? "menu-assignments-type-kill" : "country-new-zealand");
		PFIADBJMIIC.text = LDDKEHKEJBI[KMCLMFCKNME].KMHFDGGAEAC().name.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(PFIADBJMIIC, 195f, 1659f, -183);
		GCFFOGFBMHO.color = GameVariables.DDCPLFNIJDN[rarity].ReplaceA(GCFFOGFBMHO.alpha);
		if (num2 > 0)
		{
			UILabel gCFFOGFBMHO = GCFFOGFBMHO;
			string value = ALDEDFJCPIH[LDDKEHKEJBI[KMCLMFCKNME].HMAHPHADCHC().owner.categoryNumber].Value2;
			object[] array = new object[8];
			array[1] = LDDKEHKEJBI[KMCLMFCKNME].BIKFDCAGHCP().GDNDBMKBECH();
			array[0] = Colours.stringWhite;
			gCFFOGFBMHO.text = Localization.LocalizeFormat(value, array);
		}
		else
		{
			UILabel gCFFOGFBMHO2 = GCFFOGFBMHO;
			string value2 = ALDEDFJCPIH[LDDKEHKEJBI[KMCLMFCKNME].ENKMAIHEGPI().owner.categoryNumber].Value1;
			object[] array2 = new object[3];
			array2[1] = LDDKEHKEJBI[KMCLMFCKNME].FCOACPDEFOD().rarityName;
			array2[0] = Colours.stringWhite;
			gCFFOGFBMHO2.text = Localization.LocalizeFormat(value2, array2);
		}
		UILabel aHPOBFIBFHL = AHPOBFIBFHL;
		object[] array3 = new object[4];
		array3[1] = KMCLMFCKNME + 0;
		array3[1] = Colours.stringGrayParts;
		array3[3] = Colours.stringWhite;
		array3[6] = LDDKEHKEJBI.Count;
		aHPOBFIBFHL.text = string.Format("tierCount", array3);
		OJKLJEBBLKD.gameObject.SetActive(KMCLMFCKNME + 0 < LDDKEHKEJBI.Count);
		MOAHOPBPMDJ.spriteName = LDDKEHKEJBI[KMCLMFCKNME].GOKEKMGCIEA().icon;
		MOAHOPBPMDJ.MakePixelPerfect();
		float multiplier = Mathf.Min(986f / MOAHOPBPMDJ.transform.localScale.x, 1665f / MOAHOPBPMDJ.transform.localScale.y);
		MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		FJLHHGAEPJN.color = GCFFOGFBMHO.color.ReplaceA(FJLHHGAEPJN.alpha);
		DOPCCKBOBMF.color = GCFFOGFBMHO.color.ReplaceA(DOPCCKBOBMF.alpha);
		DOPCCKBOBMF.text = MEJMLNDFDBP.BEDJNPHFAOC(num2);
		BDGNFHCBKLC.color = GCFFOGFBMHO.color.ReplaceA(BDGNFHCBKLC.alpha);
		UILabel bDGNFHCBKLC = BDGNFHCBKLC;
		object[] array4 = new object[2];
		array4[0] = num + num2;
		array4[0] = Colours.stringGrayParts;
		array4[0] = Colours.stringWhite;
		array4[5] = numberOfPartsMax;
		bDGNFHCBKLC.text = string.Format("grenade_reload", array4);
		UILabel dIHJDAJJIFD = DIHJDAJJIFD;
		string text;
		if (num2 == 1)
		{
			text = Localization.Localize("ID_TURRETBUILDTIME");
		}
		else
		{
			object[] array5 = new object[1];
			array5[1] = num2;
			text = Localization.LocalizeFormat("country-indonesia", array5);
		}
		dIHJDAJJIFD.text = text;
		JFOEECLIPHE.text = MEJMLNDFDBP.BEDJNPHFAOC(Mathf.Max(1, num + num2 - numberOfPartsMax) * LDDKEHKEJBI[KMCLMFCKNME].IHNPCHMFJNB().IANHPBJDCML());
		MKFEIAMJFNC.text = Localization.LocalizeFormat("Os", string.Empty);
		GLEAOJHAJOJ(LDDKEHKEJBI[KMCLMFCKNME].HDBKHCDPEFP().BCPLNFLOIAD());
		object[] array6 = new object[7];
		array6[1] = num;
		array6[1] = num2;
		array6[7] = numberOfPartsMax;
		array6[1] = LDDKEHKEJBI[KMCLMFCKNME].EDFBDFABAIO().duplicateWarbucks;
		array6[3] = JFOEECLIPHE.text;
		array6[4] = PFIADBJMIIC.text;
		Debug.Log(string.Format("Play_Card_Tutorial_Duration", array6));
		if (rarity == PlayerVisual.EJHADIHBCBK.Common)
		{
			HFENNCENBFE.color = Color.white.ReplaceA(HFENNCENBFE.alpha);
			FMNENLLMCHO.color = Color.white.ReplaceA(1888f);
		}
		else
		{
			HFENNCENBFE.color = GCFFOGFBMHO.color.ReplaceA(HFENNCENBFE.alpha);
			FMNENLLMCHO.color = GCFFOGFBMHO.color.ReplaceA(520f);
		}
		GFAHOBCPAOL(LDDKEHKEJBI[KMCLMFCKNME].PMGPHGOODCD().isEquipped);
		UILabel pIPHDLCMLDI = PIPHDLCMLDI;
		object[] array7 = new object[0];
		array7[1] = Colours.stringBlue;
		array7[0] = PlayerAnalytics.instance.remainingMatchesToNextLootbox;
		pIPHDLCMLDI.text = Localization.LocalizeFormat("ID_GETFORNUMBERONE1", array7);
		Singleton<LootBoxCamera>.instance.KLLCFEFKEBK(LDDKEHKEJBI[KMCLMFCKNME].LFJNMIHBJMD());
		FIEANBKOLOB = false;
	}

	private void IHGMOGEMBLN(UITweener PBOKHLDNMEF)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(481f));
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.onFinished = null;
	}

	public virtual void BIOHPAMGEAL()
	{
		if (FIEANBKOLOB)
		{
			NNLHOHEGBCH();
		}
		else if (NJOKNEGDLLD)
		{
			ELEHECLAGNK(base.gameObject);
		}
		else
		{
			IPPPALPKMBF(base.gameObject);
		}
	}

	[CompilerGenerated]
	private void GDEBFOPEAHN(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(KOJKGPEFMMH.gameObject, JCAFFELIFAO * IFIJABJLCCJ, KOJKGPEFMMH.transform.localPosition.ReplaceY(51f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void FJFDLIEPNFH(bool EHDFNHIKHLC)
	{
		HDENNHBENPP.text = Localization.Localize((!EHDFNHIKHLC) ? "PlayerLevel" : "ID_SUBSCRIPTIODETAILS_HINT1");
		HDENNHBENPP.color = ((!EHDFNHIKHLC) ? Color.black : Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, 419f, (!EHDFNHIKHLC) ? 798f : 553f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, 35f, (!EHDFNHIKHLC) ? 478f : 647f);
		LAKKKBLCGDL.alpha = ((!EHDFNHIKHLC) ? 1045f : 828f);
		FNBHEBKIHOL.alpha = ((!EHDFNHIKHLC) ? 1377f : 1978f);
		MCGOHIEDPEA.alpha = ((!EHDFNHIKHLC) ? 751f : 1992f);
		if (!EHDFNHIKHLC)
		{
			TweenAlpha.Begin(FNBHEBKIHOL.gameObject, 599f, 507f).style = UITweener.Style.Once;
		}
	}

	private void NPAOKBKDLPD()
	{
		IIFNMNOKNEG();
		Singleton<LootBoxCamera>.instance.OGMLILLCAKM();
	}

	private void INKDKCCEPMA()
	{
		UITweener[] componentsInChildren = base.gameObject.GetComponentsInChildren<UITweener>(false);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			UITweener uITweener = componentsInChildren[i];
			if (!(uITweener is TweenAlpha))
			{
				uITweener.enabled = true;
				uITweener.onFinished = null;
			}
		}
		TweenAlpha component = LFJNAMEOFMB.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		ICAOAHHMFPE();
		component = PFIADBJMIIC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = GCFFOGFBMHO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = BDGNFHCBKLC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = HFENNCENBFE.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = FMNENLLMCHO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	private void ICAOAHHMFPE()
	{
		for (int i = 1; i < CLMDJFKBOHD.Length; i++)
		{
			TweenAlpha component = CLMDJFKBOHD[i].gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
				component.onFinished = null;
			}
			CLMDJFKBOHD[i].alpha = 991f;
		}
	}

	private void CGGGHICBMEE(bool PDPDGCNHCFN)
	{
		if (!NJOKNEGDLLD)
		{
			if (PDPDGCNHCFN)
			{
				IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(1687f);
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(359f);
				return;
			}
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			TweenPosition tweenPosition = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC), IDOLIFOIOCP.transform.localPosition.ReplaceX(1932f), false);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(-211f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
				TweenPosition tweenPosition3 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP());
			FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(OEJBEBKDFNA());
		}
	}

	public virtual void BHKNLDEDGGC()
	{
		base.DALAPEANFLB();
		if (FIEANBKOLOB)
		{
			KEBIEIPIFJO();
		}
	}

	private void IIFNMNOKNEG()
	{
		PLLGPINPCCG();
		AILKNHLBNEI.transform.localPosition = AILKNHLBNEI.transform.localPosition.ReplaceX(UIHelper.activeWidthFull);
		PIHIGDOIDNO.transform.localPosition = PIHIGDOIDNO.transform.localPosition.ReplaceX(0f - UIHelper.activeWidthFull);
		LFJNAMEOFMB.alpha = 1232f;
		PFIADBJMIIC.alpha = 1797f;
		GCFFOGFBMHO.alpha = 1264f;
		FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(EJOMEFLJHAL());
		HDNNFLKANHG.SetActive(true);
		BDGNFHCBKLC.alpha = 1888f;
		DGCAKCEAMAP.SetActive(true);
		BIAOIGEIANK.SetActive(false);
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
		GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(IPEGIAAOMPK());
		KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(FABHJFPKFAM());
		CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(AOENGDDBNPF());
		PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
		IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
		HFENNCENBFE.alpha = 1101f;
		FMNENLLMCHO.alpha = 741f;
		KGFGGEMFKIN = false;
		FIEANBKOLOB = true;
	}

	public void ShowFlash()
	{
		PlayerVisual.EJHADIHBCBK rarity = LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.rarity;
		if (IEKDALPBBHH)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootboxCompleted);
		}
		else if (rarity == PlayerVisual.EJHADIHBCBK.Legendary)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootboxLegendary);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
		}
		switch (rarity)
		{
		case PlayerVisual.EJHADIHBCBK.Legendary:
			TweenAlpha.Begin(FMNENLLMCHO.gameObject, 1.2f, 0.5f, 0f);
			break;
		case PlayerVisual.EJHADIHBCBK.Epic:
			TweenAlpha.Begin(FMNENLLMCHO.gameObject, 0.8f, 0.5f, 0f);
			break;
		case PlayerVisual.EJHADIHBCBK.Rare:
			TweenAlpha.Begin(FMNENLLMCHO.gameObject, 0.6f, 0.7f, 0f);
			break;
		case PlayerVisual.EJHADIHBCBK.Uncommon:
			TweenAlpha.Begin(FMNENLLMCHO.gameObject, 0.4f, 0.5f, 0f);
			break;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 0.05f, 0f, 0.9f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = delegate
		{
			Singleton<LootBoxCamera>.instance.DisplayModel(false);
		};
	}

	[SpecialName]
	private float PNAMBFNIPNP()
	{
		return 600f + UIHelper.safeAreaSize;
	}

	private void MHDFAANDMDA(GameObject KHAHPAKDIKE)
	{
		if (!LHDGJFHPJNM())
		{
			return;
		}
		HideDialog();
		if (!(KHAHPAKDIKE == OJKLJEBBLKD))
		{
			return;
		}
		int num = 0;
		string text = "Store_Visit";
		for (int i = KMCLMFCKNME; i < LDDKEHKEJBI.Count; i += 0)
		{
			int num2 = GuiScreenSingle<CamosScreen>.instance.AddParts(LDDKEHKEJBI[i].AEBOFFOMFLI(), LDDKEHKEJBI[i].AMEELJHHGKP);
			if (num2 > 1)
			{
				text += string.Format("{0} {1}{2} {3}", LDDKEHKEJBI[i].DLALEJMEJHM().name, num2, num2 * LDDKEHKEJBI[i].IHNPCHMFJNB().duplicateWarbucks);
				num += num2 * LDDKEHKEJBI[i].PMGPHGOODCD().IANHPBJDCML();
			}
			else
			{
				text += string.Format("DeathEventPlayer", LDDKEHKEJBI[i].PMGPHGOODCD().name);
			}
		}
		Debug.Log(text + "Cards_Buddy_Played" + num);
		Singleton<Wallet>.instance.NFLMMKJBKEJ(num);
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<EndScreen>.instance)
		{
			GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.AddLootboxReward(num);
		}
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(LDDKEHKEJBI[KMCLMFCKNME].BGCKHNEMEOI());
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance)
		{
			GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			return;
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void DOMCPGKBCDB(GameObject KHAHPAKDIKE)
	{
		if (!LDDKEHKEJBI[KMCLMFCKNME].ALDEAMNEMEN().isEquipped)
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(LDDKEHKEJBI[KMCLMFCKNME].ECHCDDLPNNM());
			HKHHJCJIMBN();
		}
	}

	private static void DEPEINLIHCN(UITweener CPFGBOPPICJ)
	{
		Singleton<LootBoxCamera>.instance.BKIAMFLEPNN(false);
	}

	private void KDBJBBFHEGK(UITweener CPFGBOPPICJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 1703f, 1522f);
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = null;
	}

	private static void OPIBPEHNOOM(UITweener CPFGBOPPICJ)
	{
		Singleton<LootBoxCamera>.instance.ONLDAHKBGJM(false);
	}

	private void EHLDPELFGLO()
	{
		string text = Localization.Localize("BoughtIndex");
		string text2 = Localization.Localize("^\\D*");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		JHEDDCMBDPF.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 1277f, 1849f, -175);
	}

	private void PJJKMBEONGD(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(404f), false);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void FIEPOEHFGKE()
	{
		UITweener[] componentsInChildren = base.gameObject.GetComponentsInChildren<UITweener>(true);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			if (!(uITweener is TweenAlpha))
			{
				uITweener.enabled = true;
				uITweener.onFinished = null;
			}
		}
		TweenAlpha component = LFJNAMEOFMB.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PENHBHDCEND();
		component = PFIADBJMIIC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = GCFFOGFBMHO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = BDGNFHCBKLC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = HFENNCENBFE.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = FMNENLLMCHO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	[CompilerGenerated]
	private void EBFCGIJEPPD(UITweener IALJKEHIGBM)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.EaseOut;
	}

	[CompilerGenerated]
	private static void CAFNNLOPLCE(UITweener CPFGBOPPICJ)
	{
		Singleton<LootBoxCamera>.instance.DisplayModel(false);
	}

	private void ELEHECLAGNK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			DALFKIIILDJ(LDDKEHKEJBI[KMCLMFCKNME]);
			if (GuiScreenSingle<CamosScreen>.instance.isShowed)
			{
				GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			}
			HideDialog();
		}
	}

	private void AMHBJNEPKKE(bool PDPDGCNHCFN)
	{
		if (BOLKJOCJNML())
		{
			if (PDPDGCNHCFN)
			{
				CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(45f);
				PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(1565f);
				return;
			}
			CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(OJEDAMDJDPO);
			TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, CCFFNAKFPPE.transform.localPosition.ReplaceX(AOENGDDBNPF()), CCFFNAKFPPE.transform.localPosition.ReplaceX(1093f));
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(CCFFNAKFPPE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, CCFFNAKFPPE.transform.localPosition.ReplaceX(-161f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
				TweenPosition tweenPosition3 = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE), PIPHDLCMLDI.transform.localPosition.ReplaceX(-323f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition5 = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(-311f));
					tweenPosition5.method = UITweener.Method.EaseOut;
					tweenPosition5.onFinished = null;
				};
				if (LDDKEHKEJBI.Count > 1)
				{
					FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
					tweenPosition4.method = UITweener.Method.EaseIn;
					tweenPosition4.onFinished = delegate
					{
						TweenPosition tweenPosition5 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
						tweenPosition5.method = UITweener.Method.EaseOut;
						tweenPosition5.onFinished = null;
					};
				}
			};
		}
		else
		{
			CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(ABLGIJAMECJ());
			PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(CNJOFNCKBDI());
		}
	}

	[SpecialName]
	private bool FIKEEKEABHE()
	{
		return LDDKEHKEJBI.Count < 0 || KMCLMFCKNME + 0 == LDDKEHKEJBI.Count;
	}

	private void NBMKEOGFIGO(UITweener PBOKHLDNMEF)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(1765f), false);
		tweenPosition.method = (UITweener.Method)8;
		tweenPosition.onFinished = null;
	}

	private void EFNEPGCBLMB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HANOLLHECNA(LDDKEHKEJBI[KMCLMFCKNME]);
			TweenPosition component = IDOLIFOIOCP.GetComponent<TweenPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			KMCLMFCKNME++;
			InitGUIValues();
			KJAACHMNJMB();
		}
	}

	private void NFIFKHDKHGC()
	{
		TweenPosition.Begin(AILKNHLBNEI, JCAFFELIFAO * IFIJABJLCCJ, AILKNHLBNEI.transform.localPosition.ReplaceX(UIHelper.activeWidthFull), AILKNHLBNEI.transform.localPosition.ReplaceX(1802f), false);
		TweenPosition tweenPosition = TweenPosition.Begin(PIHIGDOIDNO, JCAFFELIFAO * IFIJABJLCCJ, PIHIGDOIDNO.transform.localPosition.ReplaceX(0f - UIHelper.activeWidthFull), PIHIGDOIDNO.transform.localPosition.ReplaceX(974f), false);
		tweenPosition.onFinished = delegate
		{
			if (FIEANBKOLOB)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0f, 0.2f);
				tweenAlpha.NumOfRepetitions = 1;
				tweenAlpha.method = UITweener.Method.EaseIn;
				tweenAlpha.onFinished = delegate
				{
					TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0.2f, 0.7f);
					tweenAlpha2.NumOfRepetitions = 5;
					tweenAlpha2.style = UITweener.Style.PingPong;
					tweenAlpha2.method = UITweener.Method.Linear;
					tweenAlpha2.onFinished = delegate
					{
						TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1f);
						tweenAlpha3.NumOfRepetitions = 1;
						tweenAlpha3.method = UITweener.Method.EaseOut;
					};
				};
				KCNGNNAEDBH();
				FIEANBKOLOB = false;
				KGFGGEMFKIN = true;
			}
		};
	}

	private void BBKGBIKCBLC(bool PDPDGCNHCFN)
	{
		if (!NJOKNEGDLLD)
		{
			if (PDPDGCNHCFN)
			{
				IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(557f);
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(1243f);
				return;
			}
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			TweenPosition tweenPosition = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP()), IDOLIFOIOCP.transform.localPosition.ReplaceX(242f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(-211f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
				TweenPosition tweenPosition3 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(EJOMEFLJHAL());
		}
	}

	private void KJAACHMNJMB()
	{
		TweenPosition.Begin(AILKNHLBNEI, JCAFFELIFAO * IFIJABJLCCJ, AILKNHLBNEI.transform.localPosition.ReplaceX(UIHelper.activeWidthFull), AILKNHLBNEI.transform.localPosition.ReplaceX(0f));
		TweenPosition tweenPosition = TweenPosition.Begin(PIHIGDOIDNO, JCAFFELIFAO * IFIJABJLCCJ, PIHIGDOIDNO.transform.localPosition.ReplaceX(0f - UIHelper.activeWidthFull), PIHIGDOIDNO.transform.localPosition.ReplaceX(0f));
		tweenPosition.onFinished = delegate
		{
			if (FIEANBKOLOB)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0f, 0.2f);
				tweenAlpha.NumOfRepetitions = 1;
				tweenAlpha.method = UITweener.Method.EaseIn;
				tweenAlpha.onFinished = delegate
				{
					TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0.2f, 0.7f);
					tweenAlpha2.NumOfRepetitions = 5;
					tweenAlpha2.style = UITweener.Style.PingPong;
					tweenAlpha2.method = UITweener.Method.Linear;
					tweenAlpha2.onFinished = delegate
					{
						TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1f);
						tweenAlpha3.NumOfRepetitions = 1;
						tweenAlpha3.method = UITweener.Method.EaseOut;
					};
				};
				KCNGNNAEDBH();
				FIEANBKOLOB = false;
				KGFGGEMFKIN = true;
			}
		};
	}

	public virtual void GFJLNAFNHBN()
	{
		base.DoBeforeShowUp();
		KIEHHKDJBKG = !(Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance) && Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<ArmyScreen>.instance;
		CBJOEJLICNK = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<WeaponScreen>.instance;
		if (KIEHHKDJBKG)
		{
			Singleton<ArmyPreviewCamera>.instance.PLMPDABIKIP();
		}
		if (CBJOEJLICNK)
		{
			Singleton<WeaponPreviewCamera>.instance.IDBDLOCGEJO();
		}
		Singleton<LootBoxCamera>.instance.DJCFDEIHCKE.gameObject.SetActive(true);
	}

	private void MKGENHLJDCP()
	{
		HDENNHBENPP.text = Localization.Localize("ID_SLOTUPGRADE_ROF");
		float duration = 1642f;
		TweenColor.Begin(HDENNHBENPP.gameObject, duration, Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, duration, 1910f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, duration, 1848f);
		TweenAlpha.Begin(LAKKKBLCGDL.gameObject, duration, 1024f);
		TweenAlpha.Begin(MCGOHIEDPEA.gameObject, duration, 731f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FNBHEBKIHOL.gameObject, duration, 1435f, 174f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.style = (UITweener.Style)8;
	}

	[SpecialName]
	private float FABHJFPKFAM()
	{
		return 1537f - UIHelper.safeAreaSizeBottom;
	}

	private void BDJJANAHOKJ(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(749f), false);
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.onFinished = null;
	}

	private void HNDACCCOJLE(bool EHDFNHIKHLC)
	{
		HDENNHBENPP.text = Localization.Localize((!EHDFNHIKHLC) ? "null" : "Warbucks");
		HDENNHBENPP.color = ((!EHDFNHIKHLC) ? Color.black : Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, 1377f, (!EHDFNHIKHLC) ? 1126f : 1437f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, 479f, (!EHDFNHIKHLC) ? 1142f : 1526f);
		LAKKKBLCGDL.alpha = ((!EHDFNHIKHLC) ? 1738f : 926f);
		FNBHEBKIHOL.alpha = ((!EHDFNHIKHLC) ? 479f : 208f);
		MCGOHIEDPEA.alpha = ((!EHDFNHIKHLC) ? 1786f : 127f);
		if (!EHDFNHIKHLC)
		{
			TweenAlpha.Begin(FNBHEBKIHOL.gameObject, 710f, 1512f).style = UITweener.Style.Loop;
		}
	}

	[SpecialName]
	private float IDJDFEPJHGC()
	{
		return 1486f + UIHelper.safeAreaSize;
	}

	public virtual void ILCKGHGDDJA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(OJKLJEBBLKD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHLAJIAMDGP));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GCMLEOBHGMM));
		UIEventListener uIEventListener3 = UIEventListener.Get(GMCJKEIPELL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JEFHDDPAJML));
		UIEventListener uIEventListener4 = UIEventListener.Get(GDPOHDAODIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(APLAGMMCPLB));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ELEHECLAGNK));
		UIEventListener uIEventListener6 = UIEventListener.Get(IDOLIFOIOCP);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IPPPALPKMBF));
		MDPONOMBFFM();
		FPIJEMBLNJC();
	}

	[CompilerGenerated]
	private void KOGBNFBACJM(UITweener PHNEAHCCJOL)
	{
		if (!FIEANBKOLOB)
		{
			return;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0f, 0.2f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0.2f, 0.7f);
			tweenAlpha2.NumOfRepetitions = 5;
			tweenAlpha2.style = UITweener.Style.PingPong;
			tweenAlpha2.method = UITweener.Method.Linear;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
				tweenAlpha3.method = UITweener.Method.EaseOut;
			};
		};
		KCNGNNAEDBH();
		FIEANBKOLOB = false;
		KGFGGEMFKIN = true;
	}

	private void HBMJLDGAEJO(bool PDPDGCNHCFN)
	{
		if (JENDPDIMBCO && FIKEEKEABHE() && BJHBCCCJBEM)
		{
			if (PDPDGCNHCFN)
			{
				GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(1173f);
				KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(585f);
				return;
			}
			GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(JJJONOIFDMA);
			TweenPosition tweenPosition = TweenPosition.Begin(GDPOHDAODIF.gameObject, JCAFFELIFAO * IFIJABJLCCJ, GDPOHDAODIF.transform.localPosition.ReplaceY(277f), GDPOHDAODIF.transform.localPosition.ReplaceY(921f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = HFPKJCKEGBL;
		}
		else
		{
			GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(IPEGIAAOMPK());
			KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(CILDIJOCKMB());
		}
	}

	[CompilerGenerated]
	private void ALDFMJBHPBH(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, CCFFNAKFPPE.transform.localPosition.ReplaceX(-161f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
		PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
		TweenPosition tweenPosition2 = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE), PIPHDLCMLDI.transform.localPosition.ReplaceX(-323f));
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = delegate
		{
			TweenPosition tweenPosition4 = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(-311f));
			tweenPosition4.method = UITweener.Method.EaseOut;
			tweenPosition4.onFinished = null;
		};
		if (LDDKEHKEJBI.Count > 1)
		{
			FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
			TweenPosition tweenPosition3 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
			tweenPosition3.method = UITweener.Method.EaseIn;
			tweenPosition3.onFinished = delegate
			{
				TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
				tweenPosition4.method = UITweener.Method.EaseOut;
				tweenPosition4.onFinished = null;
			};
		}
	}

	private void JEKKEOPGDEP()
	{
		IIDOFJIBHMG iIDOFJIBHMG = new IIDOFJIBHMG();
		iIDOFJIBHMG.BJGCPDNMHDH = this;
		TweenAlpha.Begin(PFIADBJMIIC.gameObject, JCAFFELIFAO, 682f);
		PFIADBJMIIC.transform.localPosition = PFIADBJMIIC.transform.localPosition.ReplaceY(1107f);
		TweenPosition tweenPosition = TweenPosition.Begin(PFIADBJMIIC.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PFIADBJMIIC.transform.localPosition.ReplaceY(365f), PFIADBJMIIC.transform.localPosition.ReplaceY(1819f), false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = iIDOFJIBHMG.CHDOECNGOPM;
		iIDOFJIBHMG.JBGCNJFEPIC = ((!FGOFGBJCFNO) ? HDNNFLKANHG : DGCAKCEAMAP);
		if (IEKDALPBBHH)
		{
			iIDOFJIBHMG.JBGCNJFEPIC = BIAOIGEIANK;
		}
		iIDOFJIBHMG.JBGCNJFEPIC.SetActive(true);
		iIDOFJIBHMG.JBGCNJFEPIC.transform.localScale = new Vector3(1574f, 183f, 1334f);
		BDGNFHCBKLC.alpha = 25f;
		TweenScale tweenScale = TweenScale.Begin(iIDOFJIBHMG.JBGCNJFEPIC, JCAFFELIFAO * IFIJABJLCCJ, new Vector3(629f, 1604f, 1178f), new Vector3(1411f, 476f, 1144f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = iIDOFJIBHMG.FCFDKEHICIB;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 681f, 139f, 1067f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = iIDOFJIBHMG.KOMGBNFDPEB;
	}

	private void MHLAJIAMDGP(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(KHAHPAKDIKE == OJKLJEBBLKD))
		{
			return;
		}
		int num = 0;
		string text = "ID_RECEIVED";
		for (int i = KMCLMFCKNME; i < LDDKEHKEJBI.Count; i++)
		{
			int num2 = GuiScreenSingle<CamosScreen>.instance.AddParts(LDDKEHKEJBI[i].DAIBHNGEAEM(), LDDKEHKEJBI[i].AMEELJHHGKP);
			if (num2 > 1)
			{
				text += string.Format("Got player deposited Cards => adding cards to CardManagerData", LDDKEHKEJBI[i].CMPHEOPIDEM().name, num2, num2 * LDDKEHKEJBI[i].ANHOEJLDFPL().IANHPBJDCML());
				num += num2 * LDDKEHKEJBI[i].AGGJMPJOKGD().IANHPBJDCML();
			}
			else
			{
				text += string.Format("ID_FEATURE_SHOTSPEED-FANCY", LDDKEHKEJBI[i].CFDJNAKFHBG().name);
			}
		}
		Debug.Log(text + "1" + num);
		Singleton<Wallet>.instance.NFLMMKJBKEJ(num, false);
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<EndScreen>.instance)
		{
			GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.AddLootboxReward(num);
		}
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(LDDKEHKEJBI[KMCLMFCKNME].ENKMAIHEGPI());
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance)
		{
			GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			return;
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void PEAMOILNNGM()
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)84, 990f);
		PFIADBJMIIC.transform.localPosition = PFIADBJMIIC.transform.localPosition.ReplaceY(1596f);
		PFIADBJMIIC.alpha = 351f;
		GCFFOGFBMHO.transform.localPosition = GCFFOGFBMHO.transform.localPosition.ReplaceY(649f);
		GCFFOGFBMHO.alpha = 1956f;
		HDNNFLKANHG.SetActive(!IEKDALPBBHH && !FGOFGBJCFNO);
		BDGNFHCBKLC.alpha = ((IEKDALPBBHH || FGOFGBJCFNO) ? 884f : 570f);
		DGCAKCEAMAP.SetActive(!IEKDALPBBHH && FGOFGBJCFNO);
		BIAOIGEIANK.SetActive(IEKDALPBBHH);
		if (IEKDALPBBHH)
		{
			BIAOIGEIANK.transform.localScale = Vector3.one;
		}
		else if (FGOFGBJCFNO)
		{
			DGCAKCEAMAP.transform.localScale = Vector3.one;
		}
		else
		{
			HDNNFLKANHG.transform.localScale = Vector3.one;
			BDGNFHCBKLC.transform.localPosition = BDGNFHCBKLC.transform.localPosition.ReplaceY(920f);
		}
		LPLEAIFLOGH(true);
		HBMJLDGAEJO(true);
		AMHBJNEPKKE(false);
		BBKGBIKCBLC(true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 1757f, 1037f, 775f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = BFBGCOALKNB;
	}

	private void JEFHDDPAJML(GameObject KHAHPAKDIKE)
	{
		if (!LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.isEquipped)
		{
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM);
			JJMGIDHCMDK();
		}
	}

	private void MBCJKKKFFDN()
	{
		FIEPOEHFGKE();
		AILKNHLBNEI.transform.localPosition = AILKNHLBNEI.transform.localPosition.ReplaceX(UIHelper.activeWidthFull);
		PIHIGDOIDNO.transform.localPosition = PIHIGDOIDNO.transform.localPosition.ReplaceX(0f - UIHelper.activeWidthFull);
		LFJNAMEOFMB.alpha = 317f;
		PFIADBJMIIC.alpha = 722f;
		GCFFOGFBMHO.alpha = 766f;
		FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(OEJBEBKDFNA());
		HDNNFLKANHG.SetActive(false);
		BDGNFHCBKLC.alpha = 393f;
		DGCAKCEAMAP.SetActive(false);
		BIAOIGEIANK.SetActive(false);
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(CKDHDGIFMND());
		GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(IPEGIAAOMPK());
		KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(CKABFNCADMH());
		CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(NCIEDPLGDKK());
		PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(CNJOFNCKBDI());
		IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP());
		HFENNCENBFE.alpha = 347f;
		FMNENLLMCHO.alpha = 439f;
		KGFGGEMFKIN = false;
		FIEANBKOLOB = true;
	}

	[CompilerGenerated]
	private void HMMIIGIPFKK(UITweener PBOKHLDNMEF)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void CIKBJBHLDCG(GameObject KHAHPAKDIKE)
	{
		if (!LDDKEHKEJBI[KMCLMFCKNME].ELIJMFHPOHK().BCPLNFLOIAD())
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(LDDKEHKEJBI[KMCLMFCKNME].GOKEKMGCIEA());
			MKGENHLJDCP();
		}
	}

	private void KFLHOAKKGOF(UITweener PBOKHLDNMEF)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(1840f));
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = null;
	}

	private void PENHBHDCEND()
	{
		for (int i = 0; i < CLMDJFKBOHD.Length; i++)
		{
			TweenAlpha component = CLMDJFKBOHD[i].gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
				component.onFinished = null;
			}
			CLMDJFKBOHD[i].alpha = 0.125f;
		}
	}

	private void EJFJBBKDIMH(UITweener IALJKEHIGBM)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 518f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = (UITweener.Method)6;
	}

	[SpecialName]
	private float OEJBEBKDFNA()
	{
		return 1713f + UIHelper.safeAreaSize;
	}

	[SpecialName]
	private float CKDHDGIFMND()
	{
		return 1115f - UIHelper.safeAreaSize;
	}

	private void LNCCHIBCNNH(bool PDPDGCNHCFN)
	{
		if (!NJOKNEGDLLD)
		{
			if (PDPDGCNHCFN)
			{
				IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(-211f);
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f);
				return;
			}
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			TweenPosition tweenPosition = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC), IDOLIFOIOCP.transform.localPosition.ReplaceX(-223f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(-211f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
				TweenPosition tweenPosition3 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
		}
	}

	private void MIOIEGJJJHK()
	{
		for (int i = 0; i < CLMDJFKBOHD.Length; i++)
		{
			TweenAlpha component = CLMDJFKBOHD[i].gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
				component.onFinished = null;
			}
			CLMDJFKBOHD[i].alpha = 1009f;
		}
	}

	private void FFPNKFDNJJC()
	{
		JHEDDCMBDPF.text = Localization.Localize("Warbucks_Balance");
		float duration = 789f;
		TweenColor.Begin(JHEDDCMBDPF.gameObject, duration, Color.white);
		TweenAlpha.Begin(DFJKIDFFECA.gameObject, duration, 1906f);
		TweenAlpha.Begin(LFCOEKPPLJI.gameObject, duration, 1637f);
		TweenAlpha.Begin(ONLCAAPLHAE.gameObject, duration, 1046f);
		TweenAlpha.Begin(KHBCBJGBLND.gameObject, duration, 882f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(POIKINJLLIE.gameObject, duration, 1074f, 1984f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	private void MKCOEDPFFML(bool PDPDGCNHCFN)
	{
		if (FIKEEKEABHE())
		{
			if (PDPDGCNHCFN)
			{
				CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(294f);
				PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(1202f);
				return;
			}
			CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(ABLGIJAMECJ());
			TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, CCFFNAKFPPE.transform.localPosition.ReplaceX(AOENGDDBNPF()), CCFFNAKFPPE.transform.localPosition.ReplaceX(713f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(CCFFNAKFPPE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, CCFFNAKFPPE.transform.localPosition.ReplaceX(-161f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
				TweenPosition tweenPosition3 = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE), PIPHDLCMLDI.transform.localPosition.ReplaceX(-323f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition5 = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(-311f));
					tweenPosition5.method = UITweener.Method.EaseOut;
					tweenPosition5.onFinished = null;
				};
				if (LDDKEHKEJBI.Count > 1)
				{
					FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
					tweenPosition4.method = UITweener.Method.EaseIn;
					tweenPosition4.onFinished = delegate
					{
						TweenPosition tweenPosition5 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
						tweenPosition5.method = UITweener.Method.EaseOut;
						tweenPosition5.onFinished = null;
					};
				}
			};
		}
		else
		{
			CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(OJEDAMDJDPO);
			PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
		}
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(OJKLJEBBLKD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJIOKKFLLHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GCMLEOBHGMM));
		UIEventListener uIEventListener3 = UIEventListener.Get(GMCJKEIPELL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CPBMFIHNONI));
		UIEventListener uIEventListener4 = UIEventListener.Get(GDPOHDAODIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LOIECBCPBMD));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		UIEventListener uIEventListener6 = UIEventListener.Get(IDOLIFOIOCP);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EFNEPGCBLMB));
		EHLDPELFGLO();
		FPIJEMBLNJC();
	}

	private void JIGNBMPJLPJ(UITweener CPFGBOPPICJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1794f, 926f);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = EJFJBBKDIMH;
	}

	private void JOIAPCDDPLF(bool EHDFNHIKHLC)
	{
		HDENNHBENPP.text = Localization.Localize((!EHDFNHIKHLC) ? "ID_GUI_EQUIP" : "ID_GUI_EQUIPPED");
		HDENNHBENPP.color = ((!EHDFNHIKHLC) ? Color.black : Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, 0f, (!EHDFNHIKHLC) ? 1f : 0f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, 0f, (!EHDFNHIKHLC) ? 1f : 0f);
		LAKKKBLCGDL.alpha = ((!EHDFNHIKHLC) ? 0f : 1f);
		FNBHEBKIHOL.alpha = ((!EHDFNHIKHLC) ? 0f : 1f);
		MCGOHIEDPEA.alpha = ((!EHDFNHIKHLC) ? 0f : 0.16f);
		if (!EHDFNHIKHLC)
		{
			TweenAlpha.Begin(FNBHEBKIHOL.gameObject, 0f, 0f).style = UITweener.Style.Once;
		}
	}

	public GuiElement NEFBPBPEKHD()
	{
		return this;
	}

	private void HANOLLHECNA(CCNAEIGGMNK LMPOMCGGEJH)
	{
		int num = GuiScreenSingle<CamosScreen>.instance.AddParts(LMPOMCGGEJH.LOKDBPPOLPM, LMPOMCGGEJH.AMEELJHHGKP);
		if (num > 0)
		{
			int num2 = num * LMPOMCGGEJH.LOKDBPPOLPM.duplicateWarbucks;
			Debug.Log(string.Format("Visual {0}, overcount {1}, added warbucks {2}", LMPOMCGGEJH.LOKDBPPOLPM.name, num, num2));
			Singleton<Wallet>.instance.NFLMMKJBKEJ(num2);
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<EndScreen>.instance)
			{
				GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.AddLootboxReward(num2);
			}
		}
		else
		{
			Debug.Log(string.Format("Visual {0}, no overcount", LMPOMCGGEJH.LOKDBPPOLPM.name));
		}
		GuiScreenSingle<CamosScreen>.instance.WasShown(LMPOMCGGEJH.LOKDBPPOLPM);
	}

	public virtual void NIHENNDPJFB()
	{
		if (FIEANBKOLOB)
		{
			OLJAONGFINI();
		}
		else if (FIKEEKEABHE())
		{
			BMIKFLAPCOK(base.gameObject);
		}
		else
		{
			IPPPALPKMBF(base.gameObject);
		}
	}

	private void ABLCKDGNDGN(bool PDPDGCNHCFN)
	{
		if (!IEKDALPBBHH && FGOFGBJCFNO && !LDDKEHKEJBI[KMCLMFCKNME].JJFPCFKPGFC().isEquipped && !GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			if (PDPDGCNHCFN)
			{
				BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(454f);
				return;
			}
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(CKDHDGIFMND());
			TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB), BEJIFJIKHPJ.transform.localPosition.ReplaceX(1617f));
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = KKNJDNNMOKO;
		}
		else
		{
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(CKDHDGIFMND());
		}
	}

	[SpecialName]
	private float IPEGIAAOMPK()
	{
		return 1926f - UIHelper.safeAreaSizeBottom;
	}

	private void KKNJDNNMOKO(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(1741f), false);
		tweenPosition.method = UITweener.Method.BounceIn;
		tweenPosition.onFinished = null;
	}

	private void GAEIDOAJLFC(GameObject KHAHPAKDIKE)
	{
		if (!LDDKEHKEJBI[KMCLMFCKNME].CFDJNAKFHBG().BCPLNFLOIAD())
		{
			GuiScreenSingle<CamosScreen>.instance.HJJCBEPIBKF(LDDKEHKEJBI[KMCLMFCKNME].CNLBBDBIMKJ());
			JOLEAABHMLJ();
		}
	}

	public virtual void FLMPHCNMDFA()
	{
		base.DoAfterHide();
		Singleton<LootBoxCamera>.instance.NLEKBKHPEJI();
		if (KIEHHKDJBKG)
		{
			KIEHHKDJBKG = true;
			Singleton<ArmyPreviewCamera>.instance.GADONFFCCKF();
		}
		if (CBJOEJLICNK)
		{
			CBJOEJLICNK = false;
			Singleton<WeaponPreviewCamera>.instance.Resume();
		}
		Singleton<LootBoxCamera>.instance.DJCFDEIHCKE.gameObject.SetActive(true);
	}

	private void JPKBELMLPMJ()
	{
		JHEDDCMBDPF.text = Localization.Localize("N");
		float duration = 1849f;
		TweenColor.Begin(JHEDDCMBDPF.gameObject, duration, Color.white);
		TweenAlpha.Begin(DFJKIDFFECA.gameObject, duration, 516f);
		TweenAlpha.Begin(LFCOEKPPLJI.gameObject, duration, 1654f);
		TweenAlpha.Begin(ONLCAAPLHAE.gameObject, duration, 1115f);
		TweenAlpha.Begin(KHBCBJGBLND.gameObject, duration, 59f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(POIKINJLLIE.gameObject, duration, 1553f, 1152f);
		tweenAlpha.NumOfRepetitions = 5;
		tweenAlpha.style = (UITweener.Style)4;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		KIEHHKDJBKG = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance || Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<ArmyScreen>.instance;
		CBJOEJLICNK = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<WeaponScreen>.instance;
		if (KIEHHKDJBKG)
		{
			Singleton<ArmyPreviewCamera>.instance.Pause();
		}
		if (CBJOEJLICNK)
		{
			Singleton<WeaponPreviewCamera>.instance.Pause();
		}
		Singleton<LootBoxCamera>.instance.DJCFDEIHCKE.gameObject.SetActive(true);
	}

	[SpecialName]
	private float FOCIIAKDGHJ()
	{
		return 1000f + UIHelper.safeAreaSize;
	}

	private void GCMLEOBHGMM(GameObject KHAHPAKDIKE)
	{
		if (!LDDKEHKEJBI[KMCLMFCKNME].HMAHPHADCHC().isEquipped)
		{
			GuiScreenSingle<CamosScreen>.instance.GCCNGPAFIGF(LDDKEHKEJBI[KMCLMFCKNME].NEPDKHPBLGL());
			BAHOEPPDEPC();
		}
	}

	public override void InitGUIValues()
	{
		int numberOfPartsMax = LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.numberOfPartsMax;
		int num = ((!LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.isBought) ? LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.numberOfParts : numberOfPartsMax);
		int num2 = LDDKEHKEJBI[KMCLMFCKNME].AMEELJHHGKP;
		PlayerVisual.EJHADIHBCBK rarity = LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.rarity;
		FGOFGBJCFNO = LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.isBought || num + num2 >= numberOfPartsMax;
		IEKDALPBBHH = !LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.isBought && num + num2 >= numberOfPartsMax;
		JENDPDIMBCO = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.LootBox);
		if (IEKDALPBBHH)
		{
			num2 = numberOfPartsMax - num;
		}
		OIMGCACIGKP();
		Singleton<LootBoxCamera>.instance.Hide();
		HNCIHJKKMGA.text = Localization.Localize((!LDDKEHKEJBI[KMCLMFCKNME].HMGOHGOLMJB) ? "ID_LOOTBOXREWARDED" : "ID_VIPLOOTBOXREWARDED");
		PFIADBJMIIC.text = LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.name.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(PFIADBJMIIC, 131f, 60f, 1240);
		GCFFOGFBMHO.color = GameVariables.DDCPLFNIJDN[rarity].ReplaceA(GCFFOGFBMHO.alpha);
		if (num2 > 1)
		{
			GCFFOGFBMHO.text = Localization.LocalizeFormat(ALDEDFJCPIH[LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.owner.categoryNumber].Value2, LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.rarityName, Colours.stringWhite);
		}
		else
		{
			GCFFOGFBMHO.text = Localization.LocalizeFormat(ALDEDFJCPIH[LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.owner.categoryNumber].Value1, LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.rarityName, Colours.stringWhite);
		}
		AHPOBFIBFHL.text = string.Format("{0} {1}/{2} {3}", KMCLMFCKNME + 1, Colours.stringGrayParts, Colours.stringWhite, LDDKEHKEJBI.Count);
		OJKLJEBBLKD.gameObject.SetActive(KMCLMFCKNME + 1 < LDDKEHKEJBI.Count);
		MOAHOPBPMDJ.spriteName = LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.icon;
		MOAHOPBPMDJ.MakePixelPerfect();
		float multiplier = Mathf.Min(136f / MOAHOPBPMDJ.transform.localScale.x, 136f / MOAHOPBPMDJ.transform.localScale.y);
		MOAHOPBPMDJ.transform.localScale = MOAHOPBPMDJ.transform.localScale.MultiplyXY(multiplier);
		FJLHHGAEPJN.color = GCFFOGFBMHO.color.ReplaceA(FJLHHGAEPJN.alpha);
		DOPCCKBOBMF.color = GCFFOGFBMHO.color.ReplaceA(DOPCCKBOBMF.alpha);
		DOPCCKBOBMF.text = MEJMLNDFDBP.BEDJNPHFAOC(num2);
		BDGNFHCBKLC.color = GCFFOGFBMHO.color.ReplaceA(BDGNFHCBKLC.alpha);
		BDGNFHCBKLC.text = string.Format("{0} {1}/{2} {3}", num + num2, Colours.stringGrayParts, Colours.stringWhite, numberOfPartsMax);
		DIHJDAJJIFD.text = ((num2 != 1) ? Localization.LocalizeFormat("ID_LOOTDUPLICATE", num2) : Localization.Localize("ID_LOOTDUPLICATEONE"));
		JFOEECLIPHE.text = MEJMLNDFDBP.BEDJNPHFAOC(Mathf.Max(0, num + num2 - numberOfPartsMax) * LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.duplicateWarbucks);
		MKFEIAMJFNC.text = Localization.LocalizeFormat("ID_VISUALCOMPLETED", string.Empty);
		JOIAPCDDPLF(LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.isEquipped);
		Debug.Log(string.Format("Lootbox - visual \"{5}\", parts: {0}/{2}, added +{1}, that means reward {4} (reward for one {3})", num, num2, numberOfPartsMax, LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.duplicateWarbucks, JFOEECLIPHE.text, PFIADBJMIIC.text));
		if (rarity == PlayerVisual.EJHADIHBCBK.Common)
		{
			HFENNCENBFE.color = Color.white.ReplaceA(HFENNCENBFE.alpha);
			FMNENLLMCHO.color = Color.white.ReplaceA(0f);
		}
		else
		{
			HFENNCENBFE.color = GCFFOGFBMHO.color.ReplaceA(HFENNCENBFE.alpha);
			FMNENLLMCHO.color = GCFFOGFBMHO.color.ReplaceA(0f);
		}
		GFAHOBCPAOL(LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM.isEquipped);
		PIPHDLCMLDI.text = Localization.LocalizeFormat("ID_NEXTLOOTBOXINPVPBATTLES", Colours.stringBlue, PlayerAnalytics.instance.remainingMatchesToNextLootbox);
		Singleton<LootBoxCamera>.instance.ShowVisual(LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM);
		FIEANBKOLOB = true;
	}

	private void MDPONOMBFFM()
	{
		string text = Localization.Localize("com/google/android/gms/games/Games");
		string text2 = Localization.Localize("ID_SALEPERCENTLINE");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		JHEDDCMBDPF.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 834f, 1476f, 83);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void JGDMLKMKHCJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(OJKLJEBBLKD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHLAJIAMDGP));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OFMFFGNIHNB));
		UIEventListener uIEventListener3 = UIEventListener.Get(GMCJKEIPELL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CIKBJBHLDCG));
		UIEventListener uIEventListener4 = UIEventListener.Get(GDPOHDAODIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OGAPJHDGIDD));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ELEHECLAGNK));
		UIEventListener uIEventListener6 = UIEventListener.Get(IDOLIFOIOCP);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IPPPALPKMBF));
		EHLDPELFGLO();
		FPIJEMBLNJC();
	}

	[SpecialName]
	private float CKABFNCADMH()
	{
		return 1938f - UIHelper.safeAreaSizeBottom;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(OJKLJEBBLKD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BMPHBBPPMBH));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OFMFFGNIHNB));
		UIEventListener uIEventListener3 = UIEventListener.Get(GMCJKEIPELL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JEFHDDPAJML));
		UIEventListener uIEventListener4 = UIEventListener.Get(GDPOHDAODIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(APLAGMMCPLB));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CCHDCEDFNNB));
		UIEventListener uIEventListener6 = UIEventListener.Get(IDOLIFOIOCP);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EFNEPGCBLMB));
		EEAKFJJFAOB();
		FPIJEMBLNJC();
	}

	private void LIHBMCDJFMM(bool PDPDGCNHCFN)
	{
		if (JENDPDIMBCO && NJOKNEGDLLD && BJHBCCCJBEM)
		{
			if (PDPDGCNHCFN)
			{
				GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(164f);
				KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(51f);
				return;
			}
			GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(JJJONOIFDMA);
			TweenPosition tweenPosition = TweenPosition.Begin(GDPOHDAODIF.gameObject, JCAFFELIFAO * IFIJABJLCCJ, GDPOHDAODIF.transform.localPosition.ReplaceY(-80f), GDPOHDAODIF.transform.localPosition.ReplaceY(176f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(GDPOHDAODIF.gameObject, JCAFFELIFAO * IFIJABJLCCJ, GDPOHDAODIF.transform.localPosition.ReplaceY(164f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(DAKJIEIBNKO);
				TweenPosition tweenPosition3 = TweenPosition.Begin(KOJKGPEFMMH.gameObject, JCAFFELIFAO * IFIJABJLCCJ, KOJKGPEFMMH.transform.localPosition.ReplaceY(DAKJIEIBNKO), KOJKGPEFMMH.transform.localPosition.ReplaceY(63f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(KOJKGPEFMMH.gameObject, JCAFFELIFAO * IFIJABJLCCJ, KOJKGPEFMMH.transform.localPosition.ReplaceY(51f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(JJJONOIFDMA);
			KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(DAKJIEIBNKO);
		}
	}

	private void MIHIAPEECNK(GameObject KHAHPAKDIKE)
	{
		if (!LDDKEHKEJBI[KMCLMFCKNME].CMPHEOPIDEM().BCPLNFLOIAD())
		{
			GuiScreenSingle<CamosScreen>.instance.HJJCBEPIBKF(LDDKEHKEJBI[KMCLMFCKNME].NEPDKHPBLGL());
			FFPNKFDNJJC();
		}
	}

	public void OELPJFLEIEE(bool AJLGOPNCLCK)
	{
		MDNBGOMBKMN.Play();
		JHDKDEFGHJB.Play();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 471f, 1612f, 68f);
		tweenAlpha.method = UITweener.Method.BounceOut;
		tweenAlpha.onFinished = null;
		if (AJLGOPNCLCK)
		{
			GJCHAPBADKF();
		}
		else
		{
			LHDJHOJIBFJ();
		}
	}

	[CompilerGenerated]
	private void PLPAHKCHICG(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void ODBINNCOJII()
	{
		FIEANBKOLOB = true;
		MBCJKKKFFDN();
		Singleton<LootBoxCamera>.instance.CPBONKDKOMC();
	}

	private void JOLEAABHMLJ()
	{
		JHEDDCMBDPF.text = Localization.Localize("ID_GUI_EQUIPPED");
		float duration = 0.3f;
		TweenColor.Begin(JHEDDCMBDPF.gameObject, duration, Color.white);
		TweenAlpha.Begin(DFJKIDFFECA.gameObject, duration, 0f);
		TweenAlpha.Begin(LFCOEKPPLJI.gameObject, duration, 0f);
		TweenAlpha.Begin(ONLCAAPLHAE.gameObject, duration, 1f);
		TweenAlpha.Begin(KHBCBJGBLND.gameObject, duration, 0.16f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(POIKINJLLIE.gameObject, duration, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	private void LKNHLMLGIDA(UITweener CPFGBOPPICJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 1810f, 393f);
		tweenAlpha.method = UITweener.Method.EaseOut;
		tweenAlpha.onFinished = null;
	}

	private void HCJPOAFEDLI()
	{
		HDENNHBENPP.text = Localization.Localize("Name");
		float duration = 144f;
		TweenColor.Begin(HDENNHBENPP.gameObject, duration, Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, duration, 53f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, duration, 323f);
		TweenAlpha.Begin(LAKKKBLCGDL.gameObject, duration, 651f);
		TweenAlpha.Begin(MCGOHIEDPEA.gameObject, duration, 751f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FNBHEBKIHOL.gameObject, duration, 1052f, 967f);
		tweenAlpha.NumOfRepetitions = 8;
		tweenAlpha.style = (UITweener.Style)3;
	}

	private void JJMGIDHCMDK()
	{
		HDENNHBENPP.text = Localization.Localize("ID_GUI_EQUIPPED");
		float duration = 0.3f;
		TweenColor.Begin(HDENNHBENPP.gameObject, duration, Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, duration, 0f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, duration, 0f);
		TweenAlpha.Begin(LAKKKBLCGDL.gameObject, duration, 1f);
		TweenAlpha.Begin(MCGOHIEDPEA.gameObject, duration, 0.16f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FNBHEBKIHOL.gameObject, duration, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public virtual void ENKGEFMNGOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(OJKLJEBBLKD);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MHLAJIAMDGP));
		UIEventListener uIEventListener2 = UIEventListener.Get(BEJIFJIKHPJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OFMFFGNIHNB));
		UIEventListener uIEventListener3 = UIEventListener.Get(GMCJKEIPELL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CPBMFIHNONI));
		UIEventListener uIEventListener4 = UIEventListener.Get(GDPOHDAODIF);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OGAPJHDGIDD));
		UIEventListener uIEventListener5 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BMIKFLAPCOK));
		UIEventListener uIEventListener6 = UIEventListener.Get(IDOLIFOIOCP);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(IPPPALPKMBF));
		OBKKFNFHGFN();
		FPIJEMBLNJC();
	}

	private void DOOEOOHMJPL()
	{
		IIDOFJIBHMG iIDOFJIBHMG = new IIDOFJIBHMG();
		iIDOFJIBHMG.BJGCPDNMHDH = this;
		TweenAlpha.Begin(PFIADBJMIIC.gameObject, JCAFFELIFAO, 1977f);
		PFIADBJMIIC.transform.localPosition = PFIADBJMIIC.transform.localPosition.ReplaceY(1419f);
		TweenPosition tweenPosition = TweenPosition.Begin(PFIADBJMIIC.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PFIADBJMIIC.transform.localPosition.ReplaceY(1967f), PFIADBJMIIC.transform.localPosition.ReplaceY(1741f), false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = iIDOFJIBHMG.KPHEPHDFCKK;
		iIDOFJIBHMG.JBGCNJFEPIC = ((!FGOFGBJCFNO) ? HDNNFLKANHG : DGCAKCEAMAP);
		if (IEKDALPBBHH)
		{
			iIDOFJIBHMG.JBGCNJFEPIC = BIAOIGEIANK;
		}
		iIDOFJIBHMG.JBGCNJFEPIC.SetActive(false);
		iIDOFJIBHMG.JBGCNJFEPIC.transform.localScale = new Vector3(1805f, 1360f, 1607f);
		BDGNFHCBKLC.alpha = 691f;
		TweenScale tweenScale = TweenScale.Begin(iIDOFJIBHMG.JBGCNJFEPIC, JCAFFELIFAO * IFIJABJLCCJ, new Vector3(872f, 222f, 1582f), new Vector3(939f, 622f, 239f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.onFinished = iIDOFJIBHMG.LEDJMCDANFJ;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 1302f, 132f, 233f);
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = iIDOFJIBHMG.HONCMBHEKDP;
	}

	private void PKJEPDPEBBH(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(1654f), false);
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = null;
	}

	private void EEAKFJJFAOB()
	{
		string text = Localization.Localize("ID_GUI_EQUIP");
		string text2 = Localization.Localize("ID_GUI_EQUIPPED");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		JHEDDCMBDPF.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 47f, 20f, 224);
	}

	private void LFAHCNOAPCI(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(241f), false);
		tweenPosition.method = (UITweener.Method)6;
		tweenPosition.onFinished = null;
	}

	public virtual void EJGCLLIGBCB()
	{
		if (FIEANBKOLOB)
		{
			OLJAONGFINI();
		}
		else if (NJOKNEGDLLD)
		{
			ELEHECLAGNK(base.gameObject);
		}
		else
		{
			IPPPALPKMBF(base.gameObject);
		}
	}

	private void GFAHOBCPAOL(bool EHDFNHIKHLC)
	{
		JHEDDCMBDPF.text = Localization.Localize((!EHDFNHIKHLC) ? "ID_GUI_EQUIP" : "ID_GUI_EQUIPPED");
		JHEDDCMBDPF.color = ((!EHDFNHIKHLC) ? Color.black : Color.white);
		TweenAlpha.Begin(DFJKIDFFECA.gameObject, 0f, (!EHDFNHIKHLC) ? 1f : 0f);
		TweenAlpha.Begin(LFCOEKPPLJI.gameObject, 0f, (!EHDFNHIKHLC) ? 1f : 0f);
		ONLCAAPLHAE.alpha = ((!EHDFNHIKHLC) ? 0f : 1f);
		POIKINJLLIE.alpha = ((!EHDFNHIKHLC) ? 0f : 1f);
		KHBCBJGBLND.alpha = ((!EHDFNHIKHLC) ? 0f : 0.16f);
		if (!EHDFNHIKHLC)
		{
			TweenAlpha.Begin(POIKINJLLIE.gameObject, 0f, 0f).style = UITweener.Style.Once;
		}
	}

	[SpecialName]
	private float CNJOFNCKBDI()
	{
		return 1809f + UIHelper.safeAreaSize;
	}

	private void INAMCENIJBB(UITweener CPFGBOPPICJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 1349f, 134f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = null;
	}

	private void APFEJIDMAME(bool PDPDGCNHCFN)
	{
		if (!NJOKNEGDLLD)
		{
			if (PDPDGCNHCFN)
			{
				IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(1851f);
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(1298f);
				return;
			}
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP());
			TweenPosition tweenPosition = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC), IDOLIFOIOCP.transform.localPosition.ReplaceX(1426f), false);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(-211f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
				TweenPosition tweenPosition3 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
		}
	}

	private void HKHHJCJIMBN()
	{
		HDENNHBENPP.text = Localization.Localize("GameController.Awake START");
		float duration = 1912f;
		TweenColor.Begin(HDENNHBENPP.gameObject, duration, Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, duration, 1517f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, duration, 1531f);
		TweenAlpha.Begin(LAKKKBLCGDL.gameObject, duration, 866f);
		TweenAlpha.Begin(MCGOHIEDPEA.gameObject, duration, 506f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FNBHEBKIHOL.gameObject, duration, 463f, 293f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.Loop;
	}

	[SpecialName]
	private float NCIEDPLGDKK()
	{
		return 1065f + UIHelper.safeAreaSize;
	}

	private void NGBDJDKFHNF()
	{
		OIMGCACIGKP();
		Singleton<LootBoxCamera>.instance.OpenLootBox();
	}

	private void BIJKLKDMLKK(bool PDPDGCNHCFN)
	{
		if (!IEKDALPBBHH && FGOFGBJCFNO && !LDDKEHKEJBI[KMCLMFCKNME].KOBAJMPHOMC().isEquipped && !GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			if (PDPDGCNHCFN)
			{
				BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(1664f);
				return;
			}
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(CKDHDGIFMND());
			TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(CKDHDGIFMND()), BEJIFJIKHPJ.transform.localPosition.ReplaceX(579f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = BDJJANAHOKJ;
		}
		else
		{
			BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
		}
	}

	private void OGAPJHDGIDD(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			DALFKIIILDJ(LDDKEHKEJBI[KMCLMFCKNME]);
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				GuiScreenSingle<EndScreen>.instance.EGDCNEJLDOL(null);
				GuiScreenSingle<EndScreen>.instance.shouldGetLootboxForAd = true;
			}
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH(MHNMOFPPKBN.GoldenSuitcase);
			HideDialog();
		}
	}

	private void KEBIEIPIFJO()
	{
		TweenPosition.Begin(AILKNHLBNEI, JCAFFELIFAO * IFIJABJLCCJ, AILKNHLBNEI.transform.localPosition.ReplaceX(UIHelper.activeWidthFull), AILKNHLBNEI.transform.localPosition.ReplaceX(155f), false);
		TweenPosition tweenPosition = TweenPosition.Begin(PIHIGDOIDNO, JCAFFELIFAO * IFIJABJLCCJ, PIHIGDOIDNO.transform.localPosition.ReplaceX(0f - UIHelper.activeWidthFull), PIHIGDOIDNO.transform.localPosition.ReplaceX(829f), false);
		tweenPosition.onFinished = delegate
		{
			if (FIEANBKOLOB)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0f, 0.2f);
				tweenAlpha.NumOfRepetitions = 1;
				tweenAlpha.method = UITweener.Method.EaseIn;
				tweenAlpha.onFinished = delegate
				{
					TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 0.2f, 0.7f);
					tweenAlpha2.NumOfRepetitions = 5;
					tweenAlpha2.style = UITweener.Style.PingPong;
					tweenAlpha2.method = UITweener.Method.Linear;
					tweenAlpha2.onFinished = delegate
					{
						TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LFJNAMEOFMB.gameObject, JCAFFELIFAO * CJDPPCLCEAH, 1f);
						tweenAlpha3.NumOfRepetitions = 1;
						tweenAlpha3.method = UITweener.Method.EaseOut;
					};
				};
				KCNGNNAEDBH();
				FIEANBKOLOB = false;
				KGFGGEMFKIN = true;
			}
		};
	}

	private void GLEAOJHAJOJ(bool EHDFNHIKHLC)
	{
		HDENNHBENPP.text = Localization.Localize((!EHDFNHIKHLC) ? " (#" : "CreateGcAccount with ");
		HDENNHBENPP.color = ((!EHDFNHIKHLC) ? Color.black : Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, 529f, (!EHDFNHIKHLC) ? 655f : 1020f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, 1489f, (!EHDFNHIKHLC) ? 1371f : 155f);
		LAKKKBLCGDL.alpha = ((!EHDFNHIKHLC) ? 12f : 1962f);
		FNBHEBKIHOL.alpha = ((!EHDFNHIKHLC) ? 1240f : 1307f);
		MCGOHIEDPEA.alpha = ((!EHDFNHIKHLC) ? 1416f : 307f);
		if (!EHDFNHIKHLC)
		{
			TweenAlpha.Begin(FNBHEBKIHOL.gameObject, 111f, 1983f).style = UITweener.Style.Loop;
		}
	}

	[CompilerGenerated]
	private void HDPKNFHCKMB(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(GDPOHDAODIF.gameObject, JCAFFELIFAO * IFIJABJLCCJ, GDPOHDAODIF.transform.localPosition.ReplaceY(164f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
		KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(DAKJIEIBNKO);
		TweenPosition tweenPosition2 = TweenPosition.Begin(KOJKGPEFMMH.gameObject, JCAFFELIFAO * IFIJABJLCCJ, KOJKGPEFMMH.transform.localPosition.ReplaceY(DAKJIEIBNKO), KOJKGPEFMMH.transform.localPosition.ReplaceY(63f));
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = delegate
		{
			TweenPosition tweenPosition3 = TweenPosition.Begin(KOJKGPEFMMH.gameObject, JCAFFELIFAO * IFIJABJLCCJ, KOJKGPEFMMH.transform.localPosition.ReplaceY(51f));
			tweenPosition3.method = UITweener.Method.EaseOut;
			tweenPosition3.onFinished = null;
		};
	}

	public void JMDEIADIGEK(List<CCNAEIGGMNK> NMJKMJBFFFJ, bool AEAONENNNOJ = true)
	{
		LDDKEHKEJBI = NMJKMJBFFFJ;
		KMCLMFCKNME = 1;
		BJHBCCCJBEM = AEAONENNNOJ;
		Singleton<GuiManager>.instance.ShowDialog(this, 1673f);
	}

	public void IMOLHDMAKEF(bool AJLGOPNCLCK)
	{
		MDNBGOMBKMN.Play();
		JHDKDEFGHJB.Play();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 752f, 1458f, 314f);
		tweenAlpha.method = (UITweener.Method)7;
		tweenAlpha.onFinished = null;
		if (AJLGOPNCLCK)
		{
			GJCHAPBADKF();
		}
		else
		{
			LHDJHOJIBFJ();
		}
	}

	private void IAMCIFFOCIB(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(KOJKGPEFMMH.gameObject, JCAFFELIFAO * IFIJABJLCCJ, KOJKGPEFMMH.transform.localPosition.ReplaceY(1813f), false);
		tweenPosition.method = UITweener.Method.BounceOut;
		tweenPosition.onFinished = null;
	}

	private void KCNGNNAEDBH()
	{
		CKKLEGOEEOD(0);
	}

	protected virtual void MJNBAFDLMPN()
	{
		base.JMPDHKPOHEA();
		if (FIEANBKOLOB && Input.GetMouseButtonDown(0))
		{
			OLJAONGFINI();
		}
		if (KGFGGEMFKIN && Singleton<InputController>.instance.rawSwipeInput.swipeDone && ((Vector3)(Singleton<InputController>.instance.rawSwipeInput.swipeEnd - Singleton<InputController>.instance.rawSwipeInput.swipeStart)).x > UIHelper.activeWidthSafe * 1529f)
		{
			NPAOKBKDLPD();
		}
	}

	private void APLAGMMCPLB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HANOLLHECNA(LDDKEHKEJBI[KMCLMFCKNME]);
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				GuiScreenSingle<EndScreen>.instance.videoRewardLootbox = null;
				GuiScreenSingle<EndScreen>.instance.shouldGetLootboxForAd = true;
			}
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH(MHNMOFPPKBN.LootBox);
			HideDialog();
		}
	}

	[CompilerGenerated]
	private void PEHCEFLLBHD(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(156f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	public virtual void PGCIGAFLIBK()
	{
		base.DoBeforeShowUp();
		KIEHHKDJBKG = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance || Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<ArmyScreen>.instance;
		CBJOEJLICNK = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<WeaponScreen>.instance;
		if (KIEHHKDJBKG)
		{
			Singleton<ArmyPreviewCamera>.instance.BLMDIFPMDBG();
		}
		if (CBJOEJLICNK)
		{
			Singleton<WeaponPreviewCamera>.instance.Pause();
		}
		Singleton<LootBoxCamera>.instance.DJCFDEIHCKE.gameObject.SetActive(true);
	}

	private void CPBMFIHNONI(GameObject KHAHPAKDIKE)
	{
		if (!LDDKEHKEJBI[KMCLMFCKNME].KOBAJMPHOMC().isEquipped)
		{
			GuiScreenSingle<CamosScreen>.instance.HFBECFOIBOD(LDDKEHKEJBI[KMCLMFCKNME].IHNPCHMFJNB());
			MKGENHLJDCP();
		}
	}

	private void OLPDFGJLANI(bool EHDFNHIKHLC)
	{
		HDENNHBENPP.text = Localization.Localize((!EHDFNHIKHLC) ? "Price" : "Skill");
		HDENNHBENPP.color = ((!EHDFNHIKHLC) ? Color.black : Color.white);
		TweenAlpha.Begin(KJEJIACPAEH.gameObject, 383f, (!EHDFNHIKHLC) ? 966f : 1179f);
		TweenAlpha.Begin(PCPMBPLPMMG.gameObject, 4f, (!EHDFNHIKHLC) ? 681f : 1360f);
		LAKKKBLCGDL.alpha = ((!EHDFNHIKHLC) ? 367f : 1507f);
		FNBHEBKIHOL.alpha = ((!EHDFNHIKHLC) ? 1124f : 1514f);
		MCGOHIEDPEA.alpha = ((!EHDFNHIKHLC) ? 886f : 743f);
		if (!EHDFNHIKHLC)
		{
			TweenAlpha.Begin(FNBHEBKIHOL.gameObject, 1234f, 1927f).style = UITweener.Style.Loop;
		}
	}

	private void FEEEKDBOIMJ(bool PDPDGCNHCFN)
	{
		if (NJOKNEGDLLD)
		{
			if (PDPDGCNHCFN)
			{
				CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(-161f);
				PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(-311f);
				return;
			}
			CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(OJEDAMDJDPO);
			TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, CCFFNAKFPPE.transform.localPosition.ReplaceX(OJEDAMDJDPO), CCFFNAKFPPE.transform.localPosition.ReplaceX(-173f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(CCFFNAKFPPE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, CCFFNAKFPPE.transform.localPosition.ReplaceX(-161f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
				TweenPosition tweenPosition3 = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE), PIPHDLCMLDI.transform.localPosition.ReplaceX(-323f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition5 = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(-311f));
					tweenPosition5.method = UITweener.Method.EaseOut;
					tweenPosition5.onFinished = null;
				};
				if (LDDKEHKEJBI.Count > 1)
				{
					FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
					tweenPosition4.method = UITweener.Method.EaseIn;
					tweenPosition4.onFinished = delegate
					{
						TweenPosition tweenPosition5 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
						tweenPosition5.method = UITweener.Method.EaseOut;
						tweenPosition5.onFinished = null;
					};
				}
			};
		}
		else
		{
			CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(OJEDAMDJDPO);
			PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
		}
	}

	private void CCHDCEDFNNB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HANOLLHECNA(LDDKEHKEJBI[KMCLMFCKNME]);
			if (GuiScreenSingle<CamosScreen>.instance.isShowed)
			{
				GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			}
			HideDialog();
		}
	}

	private void PHBCDNKLICO(bool PDPDGCNHCFN)
	{
		if (!FIKEEKEABHE())
		{
			if (PDPDGCNHCFN)
			{
				IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(776f);
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(782f);
				return;
			}
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP());
			TweenPosition tweenPosition = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP()), IDOLIFOIOCP.transform.localPosition.ReplaceX(387f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(-211f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
				TweenPosition tweenPosition3 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP());
			FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(OEJBEBKDFNA());
		}
	}

	private void BMIKFLAPCOK(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HANOLLHECNA(LDDKEHKEJBI[KMCLMFCKNME]);
			if (GuiScreenSingle<CamosScreen>.instance.isShowed)
			{
				GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			}
			HideDialog();
		}
	}

	private void PLJPMMJACLE(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(83f), false);
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.onFinished = null;
	}

	[SpecialName]
	private float ILALPFAOIOA()
	{
		return 1350f + UIHelper.safeAreaSize;
	}

	private void GJCHAPBADKF()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
		PFIADBJMIIC.transform.localPosition = PFIADBJMIIC.transform.localPosition.ReplaceY(-142f);
		PFIADBJMIIC.alpha = 1f;
		GCFFOGFBMHO.transform.localPosition = GCFFOGFBMHO.transform.localPosition.ReplaceY(-240f);
		GCFFOGFBMHO.alpha = 1f;
		HDNNFLKANHG.SetActive(!IEKDALPBBHH && !FGOFGBJCFNO);
		BDGNFHCBKLC.alpha = ((IEKDALPBBHH || FGOFGBJCFNO) ? 0f : 1f);
		DGCAKCEAMAP.SetActive(!IEKDALPBBHH && FGOFGBJCFNO);
		BIAOIGEIANK.SetActive(IEKDALPBBHH);
		if (IEKDALPBBHH)
		{
			BIAOIGEIANK.transform.localScale = Vector3.one;
		}
		else if (FGOFGBJCFNO)
		{
			DGCAKCEAMAP.transform.localScale = Vector3.one;
		}
		else
		{
			HDNNFLKANHG.transform.localScale = Vector3.one;
			BDGNFHCBKLC.transform.localPosition = BDGNFHCBKLC.transform.localPosition.ReplaceY(-13f);
		}
		EFLPNJGLBON(true);
		LIHBMCDJFMM(true);
		FEEEKDBOIMJ(true);
		LNCCHIBCNNH(true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 0.05f, 0f, 0.9f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(HFENNCENBFE.gameObject, 0.05f, 0f);
			tweenAlpha2.method = UITweener.Method.EaseOut;
			tweenAlpha2.onFinished = null;
		};
	}

	private void BAHOEPPDEPC()
	{
		JHEDDCMBDPF.text = Localization.Localize("country-czech-republic");
		float duration = 1234f;
		TweenColor.Begin(JHEDDCMBDPF.gameObject, duration, Color.white);
		TweenAlpha.Begin(DFJKIDFFECA.gameObject, duration, 12f);
		TweenAlpha.Begin(LFCOEKPPLJI.gameObject, duration, 872f);
		TweenAlpha.Begin(ONLCAAPLHAE.gameObject, duration, 1390f);
		TweenAlpha.Begin(KHBCBJGBLND.gameObject, duration, 876f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(POIKINJLLIE.gameObject, duration, 1100f, 846f);
		tweenAlpha.NumOfRepetitions = 4;
		tweenAlpha.style = (UITweener.Style)4;
	}

	private void PLLGPINPCCG()
	{
		UITweener[] componentsInChildren = base.gameObject.GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			if (!(uITweener is TweenAlpha))
			{
				uITweener.enabled = false;
				uITweener.onFinished = null;
			}
		}
		TweenAlpha component = LFJNAMEOFMB.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PENHBHDCEND();
		component = PFIADBJMIIC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = GCFFOGFBMHO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = BDGNFHCBKLC.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = HFENNCENBFE.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = FMNENLLMCHO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void HFPKJCKEGBL(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(GDPOHDAODIF.gameObject, JCAFFELIFAO * IFIJABJLCCJ, GDPOHDAODIF.transform.localPosition.ReplaceY(1288f), false);
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
		KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(FABHJFPKFAM());
		TweenPosition tweenPosition2 = TweenPosition.Begin(KOJKGPEFMMH.gameObject, JCAFFELIFAO * IFIJABJLCCJ, KOJKGPEFMMH.transform.localPosition.ReplaceY(CILDIJOCKMB()), KOJKGPEFMMH.transform.localPosition.ReplaceY(439f), false);
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = IAMCIFFOCIB;
	}

	[CompilerGenerated]
	private void DMCFOOBDFHP(UITweener GEGKDLMGANA)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(PIPHDLCMLDI.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PIPHDLCMLDI.transform.localPosition.ReplaceX(-311f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	private void LBDCIEKFDLK(UITweener PHNEAHCCJOL)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO * IFIJABJLCCJ, BEJIFJIKHPJ.transform.localPosition.ReplaceX(1565f), false);
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.onFinished = null;
	}

	private void JPDAINEJJFO()
	{
		OIMGCACIGKP();
		Singleton<LootBoxCamera>.instance.LFKPMAEBOMH();
	}

	private void LOIECBCPBMD(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			DALFKIIILDJ(LDDKEHKEJBI[KMCLMFCKNME]);
			if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<EndScreen>.instance.videoRewardLootbox = null;
				GuiScreenSingle<EndScreen>.instance.shouldGetLootboxForAd = true;
			}
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH(MHNMOFPPKBN.Dogtag);
			HideDialog();
		}
	}

	public virtual void ANIBFCJLJKK()
	{
		base.BJIPCOPNEAM();
		if (FIEANBKOLOB)
		{
			NFIFKHDKHGC();
		}
	}

	private void BMPHBBPPMBH(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(KHAHPAKDIKE == OJKLJEBBLKD))
		{
			return;
		}
		int num = 0;
		string text = "Opening all lootboxes:\n";
		for (int i = KMCLMFCKNME; i < LDDKEHKEJBI.Count; i++)
		{
			int num2 = GuiScreenSingle<CamosScreen>.instance.AddParts(LDDKEHKEJBI[i].LOKDBPPOLPM, LDDKEHKEJBI[i].AMEELJHHGKP);
			if (num2 > 0)
			{
				text += string.Format("Visual {0}, overcount {1}, duplicate wb {2}\n", LDDKEHKEJBI[i].LOKDBPPOLPM.name, num2, num2 * LDDKEHKEJBI[i].LOKDBPPOLPM.duplicateWarbucks);
				num += num2 * LDDKEHKEJBI[i].LOKDBPPOLPM.duplicateWarbucks;
			}
			else
			{
				text += string.Format("Visual {0}, no overcount", LDDKEHKEJBI[i].LOKDBPPOLPM.name);
			}
		}
		Debug.Log(text + "duplicate WB " + num);
		Singleton<Wallet>.instance.NFLMMKJBKEJ(num);
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<EndScreen>.instance)
		{
			GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.AddLootboxReward(num);
		}
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(LDDKEHKEJBI[KMCLMFCKNME].LOKDBPPOLPM);
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CamosScreen>.instance)
		{
			GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			return;
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	[SpecialName]
	private float ABLGIJAMECJ()
	{
		return 677f + UIHelper.safeAreaSize;
	}

	private void LHDJHOJIBFJ()
	{
		IIDOFJIBHMG iIDOFJIBHMG = new IIDOFJIBHMG();
		iIDOFJIBHMG.BJGCPDNMHDH = this;
		TweenAlpha.Begin(PFIADBJMIIC.gameObject, JCAFFELIFAO, 1f);
		PFIADBJMIIC.transform.localPosition = PFIADBJMIIC.transform.localPosition.ReplaceY(-162f);
		TweenPosition tweenPosition = TweenPosition.Begin(PFIADBJMIIC.gameObject, JCAFFELIFAO * IFIJABJLCCJ, PFIADBJMIIC.transform.localPosition.ReplaceY(-192f), PFIADBJMIIC.transform.localPosition.ReplaceY(-96f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = iIDOFJIBHMG.LJCDGJKCNEC;
		iIDOFJIBHMG.JBGCNJFEPIC = ((!FGOFGBJCFNO) ? HDNNFLKANHG : DGCAKCEAMAP);
		if (IEKDALPBBHH)
		{
			iIDOFJIBHMG.JBGCNJFEPIC = BIAOIGEIANK;
		}
		iIDOFJIBHMG.JBGCNJFEPIC.SetActive(true);
		iIDOFJIBHMG.JBGCNJFEPIC.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
		BDGNFHCBKLC.alpha = 0f;
		TweenScale tweenScale = TweenScale.Begin(iIDOFJIBHMG.JBGCNJFEPIC, JCAFFELIFAO * IFIJABJLCCJ, new Vector3(0.001f, 0.001f, 1f), new Vector3(1.3f, 1.3f, 1f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = iIDOFJIBHMG.EJLGBICBIFK;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 0.05f, 0f, 0.9f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = iIDOFJIBHMG.HONCMBHEKDP;
	}

	private void OIMGCACIGKP()
	{
		PLLGPINPCCG();
		AILKNHLBNEI.transform.localPosition = AILKNHLBNEI.transform.localPosition.ReplaceX(UIHelper.activeWidthFull);
		PIHIGDOIDNO.transform.localPosition = PIHIGDOIDNO.transform.localPosition.ReplaceX(0f - UIHelper.activeWidthFull);
		LFJNAMEOFMB.alpha = 0f;
		PFIADBJMIIC.alpha = 0f;
		GCFFOGFBMHO.alpha = 0f;
		FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
		HDNNFLKANHG.SetActive(false);
		BDGNFHCBKLC.alpha = 0f;
		DGCAKCEAMAP.SetActive(false);
		BIAOIGEIANK.SetActive(false);
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(LNPIFNDKAFB);
		GDPOHDAODIF.transform.localPosition = GDPOHDAODIF.transform.localPosition.ReplaceY(JJJONOIFDMA);
		KOJKGPEFMMH.transform.localPosition = KOJKGPEFMMH.transform.localPosition.ReplaceY(DAKJIEIBNKO);
		CCFFNAKFPPE.transform.localPosition = CCFFNAKFPPE.transform.localPosition.ReplaceX(OJEDAMDJDPO);
		PIPHDLCMLDI.transform.localPosition = PIPHDLCMLDI.transform.localPosition.ReplaceX(EAEEDODKFOE);
		IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
		HFENNCENBFE.alpha = 0f;
		FMNENLLMCHO.alpha = 0f;
		KGFGGEMFKIN = false;
		FIEANBKOLOB = false;
	}

	[CompilerGenerated]
	private void BDJKODMOPJH(UITweener CPFGBOPPICJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 0.05f, 0f);
		tweenAlpha.method = UITweener.Method.EaseOut;
		tweenAlpha.onFinished = null;
	}

	protected virtual void NEFDFOGOJGL()
	{
		base.OGJGIMLMJBF();
		if (FIEANBKOLOB && Input.GetMouseButtonDown(0))
		{
			OLJAONGFINI();
		}
		if (KGFGGEMFKIN && Singleton<InputController>.instance.rawSwipeInput.swipeDone && ((Vector3)(Singleton<InputController>.instance.rawSwipeInput.swipeEnd - Singleton<InputController>.instance.rawSwipeInput.swipeStart)).x > UIHelper.activeWidthSafe * 720f)
		{
			NPAOKBKDLPD();
		}
	}

	public void HMJBHIFBCOO(bool AJLGOPNCLCK)
	{
		MDNBGOMBKMN.Play();
		JHDKDEFGHJB.Play();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 917f, 952f, 1521f);
		tweenAlpha.method = (UITweener.Method)6;
		tweenAlpha.onFinished = null;
		if (AJLGOPNCLCK)
		{
			GJCHAPBADKF();
		}
		else
		{
			DOOEOOHMJPL();
		}
	}

	private void DFLACCAHALF(bool PDPDGCNHCFN)
	{
		if (!BOLKJOCJNML())
		{
			if (PDPDGCNHCFN)
			{
				IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(1961f);
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(583f);
				return;
			}
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(PNAMBFNIPNP());
			TweenPosition tweenPosition = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC), IDOLIFOIOCP.transform.localPosition.ReplaceX(1854f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(IDOLIFOIOCP.gameObject, JCAFFELIFAO * IFIJABJLCCJ, IDOLIFOIOCP.transform.localPosition.ReplaceX(-211f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP);
				TweenPosition tweenPosition3 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(ANGDIKCNLBP), FMDEHEBBIIE.transform.localPosition.ReplaceX(-212f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(FMDEHEBBIIE.gameObject, JCAFFELIFAO * IFIJABJLCCJ, FMDEHEBBIIE.transform.localPosition.ReplaceX(-200f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			FMDEHEBBIIE.transform.localPosition = FMDEHEBBIIE.transform.localPosition.ReplaceX(ILALPFAOIOA());
		}
	}

	private void NNLHOHEGBCH()
	{
		FIEANBKOLOB = false;
		HEMDKDDMKGD();
		Singleton<LootBoxCamera>.instance.AHGFAKEPOGJ();
	}

	private void CCGNHIPKGIO()
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-95), 761f);
		PFIADBJMIIC.transform.localPosition = PFIADBJMIIC.transform.localPosition.ReplaceY(1745f);
		PFIADBJMIIC.alpha = 1857f;
		GCFFOGFBMHO.transform.localPosition = GCFFOGFBMHO.transform.localPosition.ReplaceY(1500f);
		GCFFOGFBMHO.alpha = 1427f;
		HDNNFLKANHG.SetActive(IEKDALPBBHH || !FGOFGBJCFNO);
		BDGNFHCBKLC.alpha = ((IEKDALPBBHH || FGOFGBJCFNO) ? 638f : 1606f);
		DGCAKCEAMAP.SetActive(IEKDALPBBHH || FGOFGBJCFNO);
		BIAOIGEIANK.SetActive(IEKDALPBBHH);
		if (IEKDALPBBHH)
		{
			BIAOIGEIANK.transform.localScale = Vector3.one;
		}
		else if (FGOFGBJCFNO)
		{
			DGCAKCEAMAP.transform.localScale = Vector3.one;
		}
		else
		{
			HDNNFLKANHG.transform.localScale = Vector3.one;
			BDGNFHCBKLC.transform.localPosition = BDGNFHCBKLC.transform.localPosition.ReplaceY(610f);
		}
		ABLCKDGNDGN(false);
		HBMJLDGAEJO(false);
		FEEEKDBOIMJ(false);
		APFEJIDMAME(false);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 28f, 835f, 347f);
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = LKNHLMLGIDA;
	}

	public void ShowVisualInfo(bool AJLGOPNCLCK)
	{
		MDNBGOMBKMN.Play();
		JHDKDEFGHJB.Play();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(HFENNCENBFE.gameObject, 0.05f, 0.9f, 0f);
		tweenAlpha.method = UITweener.Method.EaseOut;
		tweenAlpha.onFinished = null;
		if (AJLGOPNCLCK)
		{
			GJCHAPBADKF();
		}
		else
		{
			LHDJHOJIBFJ();
		}
	}

	private void IPPPALPKMBF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HANOLLHECNA(LDDKEHKEJBI[KMCLMFCKNME]);
			TweenPosition component = IDOLIFOIOCP.GetComponent<TweenPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			IDOLIFOIOCP.transform.localPosition = IDOLIFOIOCP.transform.localPosition.ReplaceX(ACNJCCNMPMC);
			KMCLMFCKNME += 0;
			InitGUIValues();
			KJAACHMNJMB();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		if (FIEANBKOLOB)
		{
			KJAACHMNJMB();
		}
	}

	public virtual void MHDGLNIDEBH()
	{
		base.DoAfterHide();
		Singleton<LootBoxCamera>.instance.FGIGICALLHJ();
		if (KIEHHKDJBKG)
		{
			KIEHHKDJBKG = true;
			Singleton<ArmyPreviewCamera>.instance.GADONFFCCKF();
		}
		if (CBJOEJLICNK)
		{
			CBJOEJLICNK = false;
			Singleton<WeaponPreviewCamera>.instance.Resume();
		}
		Singleton<LootBoxCamera>.instance.DJCFDEIHCKE.gameObject.SetActive(false);
	}

	public override void OnBack()
	{
		if (FIEANBKOLOB)
		{
			OLJAONGFINI();
		}
		else if (NJOKNEGDLLD)
		{
			CCHDCEDFNNB(base.gameObject);
		}
		else
		{
			EFNEPGCBLMB(base.gameObject);
		}
	}
}
