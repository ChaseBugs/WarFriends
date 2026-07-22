using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using WarFriends.Legacy;

public class DialogOverlayGuiElement : Core_BaseScript
{
	private sealed class FAMGMBGPMFH
	{
		internal float HAMKIKMJHDP;

		internal Vector3 IHPFHCOLJCL;

		internal Vector3 JOFJBFEPFJD;

		internal DialogOverlayGuiElement BJGCPDNMHDH;

		internal void IDEPAHOBFCP(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 215f, 936f).onFinished = null;
		}

		internal void AOBIIKGDPEH(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.MKJDEFFADPB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void DCIBONHCNOC(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.BFPOEICBPBF));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.OFFCOEOCHML));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void JHDEKOKOLPG(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1367f, 329f).onFinished = null;
		}

		internal void JHGBDMGHDMN(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 461f, 1404f).onFinished = null;
		}

		internal void IGNHEDDHHIA(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1544f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceOut;
			tweenScale.onFinished = DCIBONHCNOC;
		}

		internal void NANDBPFBFHN(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.ALLLIPGLAGK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.PCGOLNPACCK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void KNGDNAKBBHP(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.ALLLIPGLAGK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.MKJDEFFADPB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void BHIPEMMDNON(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.EFOHPCHBFLB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.CEBMIBDFHEK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void INMBGGLEHGN(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1908f, 547f).onFinished = null;
		}

		internal void EDGLIHCHHLI(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1473f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.onFinished = DAGOGGGKECG;
		}

		internal void CIFEDFPPPOK(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 132f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = IHOCLIODHMJ;
		}

		internal void EJLGBICBIFK(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 2f, 1f).onFinished = null;
		}

		internal void IHOCLIODHMJ(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 738f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = BHIPEMMDNON;
		}

		internal void IKPPDJNEELO(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.BFPOEICBPBF));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void MFCNOIDCJME(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1849f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = IGNHEDDHHIA;
		}

		internal void NOLHNDCILFC(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 907f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceIn;
			tweenScale.onFinished = CEMIIKBILOB;
		}

		internal void HFPEMDEMNLP(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1421f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceIn;
			tweenScale.onFinished = OFHGICHIEMK;
		}

		internal void LBPGIEANDDL(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.CEBMIBDFHEK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.AAIGDBBINID));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void LJCDGJKCNEC(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 2f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = HONCMBHEKDP;
		}

		internal void EODJHIOCFAG(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.MKJDEFFADPB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.MKJDEFFADPB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void PKPCLJGCEHB(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 966f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = FBCJMCBILAJ;
		}

		internal void BMCMDMKGHHO(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 281f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = DEPNDPGCFOH;
		}

		internal void AKCPOJMIBOG(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1001f, 588f).onFinished = null;
		}

		internal void PDNKLIKHGIL(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.PCGOLNPACCK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.OFFCOEOCHML));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void BDEGOKBJGFK(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1534f, JOFJBFEPFJD);
			tweenScale.method = (UITweener.Method)6;
			tweenScale.onFinished = FBCJMCBILAJ;
		}

		internal void CEMIIKBILOB(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.AAIGDBBINID));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void MCKKLDOPCAA(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.EFOHPCHBFLB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void MMGEJAEDPOB(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1424f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = BHIPEMMDNON;
		}

		internal void MGANKGKALFG(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1936f, 974f).onFinished = null;
		}

		internal void EBLGBNEJLEC(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1638f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceIn;
			tweenScale.onFinished = KOMNMELADLH;
		}

		internal void JDEJHLLIONG(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 842f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = HONCMBHEKDP;
		}

		internal void PEMLGGFPLDG(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.EFOHPCHBFLB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.ALLLIPGLAGK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void IBMEJCJCLOK(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 512f, 1405f).onFinished = null;
		}

		internal void KPHEPHDFCKK(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1150f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = GKCCIMLNGCF;
		}

		internal void JBDJIDBNKIO(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 588f, 1593f).onFinished = null;
		}

		internal void DAGOGGGKECG(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.MKJDEFFADPB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void AFCOGJKGMDI(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1141f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = BJLLLNAOOOB;
		}

		internal void PDKENGDPFNJ(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1426f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.onFinished = KNGDNAKBBHP;
		}

		internal void KNJBDOADLDO(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 138f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = EBLGBNEJLEC;
		}

		internal void BJLLLNAOOOB(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1692f, JOFJBFEPFJD);
			tweenScale.method = (UITweener.Method)7;
			tweenScale.onFinished = LINFPCHJDJM;
		}

		internal void IFOPOPPMCFG(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 544f, 757f).onFinished = null;
		}

		internal void PKCGGMPIPDL(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 185f, 962f).onFinished = null;
		}

		internal void CENOGMHAJNK(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 309f, 637f).onFinished = null;
		}

		internal void BMJAMNEDJIB(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 182f, 1528f).onFinished = null;
		}

		internal void EHDOLLODEAH(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.CEBMIBDFHEK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.AAIGDBBINID));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void EFOONDNINBC(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1699f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = AKIINDLIFNP;
		}

		internal void CLLDAFLGJJJ(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1985f, 489f).onFinished = null;
		}

		internal void AGFEDJAKLAC(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1876f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = OALBAAOBEBO;
		}

		internal void FLHAMECGGAA(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.ALLLIPGLAGK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.CEBMIBDFHEK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void MMMABPFLBEH(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1791f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceOut;
			tweenScale.onFinished = KEEAFCIIHIL;
		}

		internal void OEAPCIJKAKI(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1958f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = PAFHFHGFMBO;
		}

		internal void LHPPLGOOLEC(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 330f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = NCILMPKLLMG;
		}

		internal void CJIBPJPJLNB(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1723f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = PAFHFHGFMBO;
		}

		internal void BIGNHFCNJLL(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void KJIFNOJILDB(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 926f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = EBLGBNEJLEC;
		}

		internal void EBJJKGFOLOA(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1433f, 310f).onFinished = null;
		}

		internal void DKNJHLBJKKD(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1817f, 1398f).onFinished = null;
		}

		internal void ECPMEMNKMCB(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1880f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = OALBAAOBEBO;
		}

		internal void GDJIAOMKDHD(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 974f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.onFinished = AOBIIKGDPEH;
		}

		internal void BLMLPOEBKJN(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1775f, JOFJBFEPFJD);
			tweenScale.method = (UITweener.Method)7;
			tweenScale.onFinished = OFHGICHIEMK;
		}

		internal void BAOECFCJFNN(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.BFPOEICBPBF));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.PCGOLNPACCK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void OGGFOHJHLFM(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1415f, 1234f).onFinished = null;
		}

		internal void GKCCIMLNGCF(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 14f, JOFJBFEPFJD);
			tweenScale.method = (UITweener.Method)8;
			tweenScale.onFinished = OMIAPCFENDL;
		}

		internal void BLNOPKPLONB(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 957f, 1757f).onFinished = null;
		}

		internal void BDCAFHOHEGM(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1821f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = PDKENGDPFNJ;
		}

		internal void ANFPNINIKHI(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1119f, 430f).onFinished = null;
		}

		internal void LINFPCHJDJM(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.CEBMIBDFHEK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.EFOHPCHBFLB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void OGIFCPNDIKC(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1761f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceOut;
			tweenScale.onFinished = LBPGIEANDDL;
		}

		internal void JGHLGHMJJDG(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 164f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = PILIHNMCMBI;
		}

		internal void HPAFKBIJMEJ(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 600f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceIn;
			tweenScale.onFinished = OBDDLLILKLE;
		}

		internal void DEPNDPGCFOH(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 59f, JOFJBFEPFJD);
			tweenScale.method = (UITweener.Method)6;
			tweenScale.onFinished = KOMNMELADLH;
		}

		internal void AOEOEIBLMMF(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1783f, 1806f).onFinished = null;
		}

		internal void JCFDEFFIHAM(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 965f, 312f).onFinished = null;
		}

		internal void MAKLHLCDIKD(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 679f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = FCENGDPPIJH;
		}

		internal void HPICHILECJJ(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1963f, 1486f).onFinished = null;
		}

		internal void NFKKLDFJFMG(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.MKJDEFFADPB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.EFOHPCHBFLB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void DHELLAHDBDN(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 275f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = PILIHNMCMBI;
		}

		internal void FLHHIKGAEDM(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1175f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = MMGEJAEDPOB;
		}

		internal void PILIHNMCMBI(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 986f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.onFinished = MCKKLDOPCAA;
		}

		internal void OFHGICHIEMK(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.HNGCFIDBGPB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.OFFCOEOCHML));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void LGJCNCHBFDA(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1102f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = LJMPKFLPDNK;
		}

		internal void HLBPCGPPCMJ(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 969f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = IGNHEDDHHIA;
		}

		internal void EFNJFNKJOMB(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 311f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = GDJIAOMKDHD;
		}

		internal void PBFKJPANDKF(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 566f, 369f).onFinished = null;
		}

		internal void EOHOLKEGGLH(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 157f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = IGNHEDDHHIA;
		}

		internal void FNDBGFOGCBK(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1437f, 1057f).onFinished = null;
		}

		internal void KPNGMLMINJL(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 574f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.onFinished = DCIBONHCNOC;
		}

		internal void LKAHPHIEMEK(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1805f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = HFPEMDEMNLP;
		}

		internal void NCILMPKLLMG(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1782f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceOut;
			tweenScale.onFinished = FLHAMECGGAA;
		}

		internal void FCENGDPPIJH(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1832f, JOFJBFEPFJD);
			tweenScale.method = (UITweener.Method)6;
			tweenScale.onFinished = AOBIIKGDPEH;
		}

		internal void FCFDKEHICIB(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1615f, 1984f).onFinished = null;
		}

		internal void HONCMBHEKDP(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 2f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = BIGNHFCNJLL;
		}

		internal void DHHKKBLMIHB(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 31f, 1379f).onFinished = null;
		}

		internal void OALBAAOBEBO(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1738f, JOFJBFEPFJD);
			tweenScale.method = (UITweener.Method)7;
			tweenScale.onFinished = HNIOCGFEKKH;
		}

		internal void KEEAFCIIHIL(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.AAIGDBBINID));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.PCGOLNPACCK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void EMHFHNLEFGN(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 650f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.onFinished = OPAECBMPOFL;
		}

		internal void CKIDEOIKHJO(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1367f, 1776f).onFinished = null;
		}

		internal void HONHEKPPHEB(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 866f, JOFJBFEPFJD);
			tweenScale.method = (UITweener.Method)8;
			tweenScale.onFinished = PEMLGGFPLDG;
		}

		internal void LJMPKFLPDNK(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 544f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = EHDOLLODEAH;
		}

		internal void OMIAPCFENDL(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.HNGCFIDBGPB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void FIBGJHCGHJH(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1654f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = HPAFKBIJMEJ;
		}

		internal void EPEIPBKIFOF(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.EFOHPCHBFLB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void LGAPIDHOEKM(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1210f, 1445f).onFinished = null;
		}

		internal void PAFHFHGFMBO(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1710f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = FBCJMCBILAJ;
		}

		internal void OBDDLLILKLE(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.MKJDEFFADPB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void GHGLIDMAEAJ(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 399f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = PDKENGDPFNJ;
		}

		internal void MOCBGHDDOOG(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1284f, 1005f).onFinished = null;
		}

		internal void AKIINDLIFNP(UITweener LJHLGLCDPIL)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1836f, JOFJBFEPFJD);
			tweenScale.method = UITweener.Method.BounceOut;
			tweenScale.onFinished = KOMNMELADLH;
		}

		internal void FKIBFHGKMFJ(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1201f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = EBLGBNEJLEC;
		}

		internal void EGBBIPAMJCL(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.PCGOLNPACCK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.PCGOLNPACCK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void PAKIJEIDOBH(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 684f, 1905f).onFinished = null;
		}

		internal void GFAEFDPBHBI(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1191f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = PDKENGDPFNJ;
		}

		internal void HNIOCGFEKKH(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.OFFCOEOCHML));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.KIALHNGKAMB));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void FBCJMCBILAJ(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.MKJDEFFADPB));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.PCGOLNPACCK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void NKEDDGCDHNA(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 661f, 1768f).onFinished = null;
		}

		internal void HADLONLCLPM(UITweener BEIFOKLMLNG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 1892f, 1306f).onFinished = null;
		}

		internal void KOMNMELADLH(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.AAIGDBBINID));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.PCGOLNPACCK));
			MLPHKEEKMGP.onFinished = null;
		}

		internal void BNJLADLKPDG(UITweener ONHHOOFONOE)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.PEJFFMLEHFA.gameObject, HAMKIKMJHDP * 858f, Vector3.one, IHPFHCOLJCL);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = PILIHNMCMBI;
		}

		internal void OPAECBMPOFL(UITweener MLPHKEEKMGP)
		{
			UIEventListener uIEventListener = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.ALLLIPGLAGK));
			UIEventListener uIEventListener2 = UIEventListener.Get(BJGCPDNMHDH.KLODDNMDPAO.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJGCPDNMHDH.OFFCOEOCHML));
			MLPHKEEKMGP.onFinished = null;
		}
	}

	[FormerlySerializedAs("IJCEKJNOCKI")]
	public UIPanel PLNPMJCNMPG;

	[FormerlySerializedAs("EDHAOJBACCN")]
	public UISprite KLODDNMDPAO;

	public UISprite PEJFFMLEHFA;

	private Vector3 CDBLNJIMIMN = new Vector3(685f, 678f, 1f);

	private static DialogOverlayGuiElement BJHPKLAEFCI;

	public static DialogOverlayGuiElement instance
	{
		get
		{
			BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: true));
			if (BJHPKLAEFCI == null)
			{
				Debug.LogError("DialogOverlayGuiElement is not in scene -> add it.");
			}
			return BJHPKLAEFCI;
		}
	}

	private void EJPJHOCEKEN(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EFOHPCHBFLB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	private void CIHDBFKGGHC(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNGCFIDBGPB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public static DialogOverlayGuiElement OKBAIGKCPKA()
	{
		BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: false));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("menu-weapons-tab");
		}
		return BJHPKLAEFCI;
	}

	private void LIEKGMMCJHJ(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCGOLNPACCK));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	public void CFLPFCJJFBN(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 45f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 589f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 285f).onFinished = BAPEHMOKFOF;
	}

	public void PDGBNMEBCHA(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: true);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 137f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 1218f, 1400f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 393f, CDBLNJIMIMN.y * 1256f, 464f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 113f, CDBLNJIMIMN.y * 707f, 997f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1111f, 1591f, 1779f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1401f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.KPHEPHDFCKK;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1500f, 1264f, 1992f).onFinished = fAMGMBGPMFH.FCFDKEHICIB;
	}

	private void LKJLKABMLJJ(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKJDEFFADPB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	public void OHDOOANFDID(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: false);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 1166f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 24f, 232f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 230f, CDBLNJIMIMN.y * 1107f, 1710f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 1946f, CDBLNJIMIMN.y * 1116f, 1069f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 646f, 1766f, 1368f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1068f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.BMCMDMKGHHO;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1065f, 1911f, 327f).onFinished = fAMGMBGPMFH.FNDBGFOGCBK;
	}

	public void NDKBKJNPIMP(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: true);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 1848f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 13f, 673f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 915f, CDBLNJIMIMN.y * 1355f, 1609f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 1678f, CDBLNJIMIMN.y * 710f, 1516f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1708f, 258f, 44f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 360f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.KNJBDOADLDO;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1853f, 1168f, 383f).onFinished = fAMGMBGPMFH.AKCPOJMIBOG;
	}

	public void AIMAOIMHCPA(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 1435f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 65f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 623f).onFinished = AJPBNEJOCAB;
	}

	private void PCGOLNPACCK(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	public void EKNOHDGGBKN(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 1139f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 1770f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 562f).onFinished = OLMICOOOOAK;
	}

	public void LAOIKOHKHID(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: true);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 9f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 226f, 768f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 1585f, CDBLNJIMIMN.y * 1442f, 291f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 1554f, CDBLNJIMIMN.y * 1147f, 1155f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 706f, 389f, 1666f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 309f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.FKIBFHGKMFJ;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 200f, 389f, 211f).onFinished = fAMGMBGPMFH.FCFDKEHICIB;
	}

	public void HBDNDILGDJI(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 1f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 359f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 499f).onFinished = LIEKGMMCJHJ;
	}

	public void LOIMELLIFON(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: false);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 1586f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 979f, 994f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 1734f, CDBLNJIMIMN.y * 1088f, 371f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 29f, CDBLNJIMIMN.y * 447f, 1729f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 533f, 1856f, 586f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 241f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.EFNJFNKJOMB;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1458f, 1407f, 1593f).onFinished = fAMGMBGPMFH.HADLONLCLPM;
	}

	[SpecialName]
	public static DialogOverlayGuiElement PHOOFIAOFPE()
	{
		BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: false));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("VipReward2");
		}
		return BJHPKLAEFCI;
	}

	public void KBJHCIINNIO(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: true);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 408f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 4f, 1727f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 1638f, CDBLNJIMIMN.y * 126f, 439f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 49f, CDBLNJIMIMN.y * 1564f, 845f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 286f, 1819f, 1260f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 761f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.EFNJFNKJOMB;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 761f, 700f, 1223f).onFinished = fAMGMBGPMFH.PKCGGMPIPDL;
	}

	private void EFOHPCHBFLB(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	[SpecialName]
	public static DialogOverlayGuiElement GAFFKDOELMI()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: true)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("GameController.LoadAndStartNewMap - InstantiatePooledObjects");
		}
		return BJHPKLAEFCI;
	}

	public void OINAODPCBND(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 877f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 1622f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 353f).onFinished = EJPJHOCEKEN;
	}

	public void LKDHFDKDAKA(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: true);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 1880f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 182f, 1788f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 1101f, CDBLNJIMIMN.y * 895f, 121f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 1584f, CDBLNJIMIMN.y * 971f, 1521f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1074f, 716f, 418f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1134f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.AFCOGJKGMDI;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 785f, 225f, 161f).onFinished = fAMGMBGPMFH.PKCGGMPIPDL;
	}

	public void IKCCDNEBNFE(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: false);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 1513f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 916f, 759f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 1258f, CDBLNJIMIMN.y * 1878f, 176f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 612f, CDBLNJIMIMN.y * 1393f, 564f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 432f, 1357f, 1744f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 449f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.JDEJHLLIONG;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 23f, 460f, 189f).onFinished = fAMGMBGPMFH.PKCGGMPIPDL;
	}

	private void OFFCOEOCHML(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	private void PEOLDCKHJON(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CEBMIBDFHEK));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	private void CKIGIHKKNEF(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ALLLIPGLAGK));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	public void NHLINJFKJKI(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: false);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 1624f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 177f, 564f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 720f, CDBLNJIMIMN.y * 1172f, 1388f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 937f, CDBLNJIMIMN.y * 1497f, 1377f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 255f, 1316f, 1459f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 858f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.CJIBPJPJLNB;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1856f, 1377f, 948f).onFinished = fAMGMBGPMFH.IDEPAHOBFCP;
	}

	public void JFLHJJOOECB(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: true);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 218f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 80f, 1711f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 1819f, CDBLNJIMIMN.y * 1901f, 1671f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 1858f, CDBLNJIMIMN.y * 910f, 946f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 318f, 507f, 1923f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 409f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.GFAEFDPBHBI;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1984f, 677f, 1464f).onFinished = fAMGMBGPMFH.CLLDAFLGJJJ;
	}

	public void IHMIIFHOBNH(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 539f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 524f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 323f).onFinished = PEOLDCKHJON;
	}

	public void OPPEIPKLOAJ(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: true);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 277f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 409f, 1482f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 81f, CDBLNJIMIMN.y * 630f, 1101f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 1560f, CDBLNJIMIMN.y * 1003f, 1926f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 728f, 1947f, 1723f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1289f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.KNJBDOADLDO;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 86f, 1112f, 703f).onFinished = fAMGMBGPMFH.CENOGMHAJNK;
	}

	private void GPFIHDJCJMC(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKJDEFFADPB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public static DialogOverlayGuiElement FELKGDDMLJN()
	{
		BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: false));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("ID_FEATURE_CRITICAL");
		}
		return BJHPKLAEFCI;
	}

	private void ALLLIPGLAGK(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	private void AJPBNEJOCAB(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EFOHPCHBFLB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	public void HideDialogOverlay(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 0f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 0f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 0.005f).onFinished = delegate(UITweener MGDJMGHCAAI)
		{
			UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KIALHNGKAMB));
			MGDJMGHCAAI.onFinished = null;
			base.gameObject.SetActive(value: false);
		};
	}

	private void AAIGDBBINID(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	[SpecialName]
	public static DialogOverlayGuiElement NBHALGLMNJA()
	{
		BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: true));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("menu-hub-multiplayer-vipico");
		}
		return BJHPKLAEFCI;
	}

	private void CEBMIBDFHEK(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	private void FKABDJGPEOL(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AAIGDBBINID));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	[SpecialName]
	public static DialogOverlayGuiElement NCJKAODKPOL()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: false)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("ID_WARSHOP_LOOTBOXES");
		}
		return BJHPKLAEFCI;
	}

	public void ShowDialogOverlay(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: true);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 15f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 0.005f, 1f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 5f, CDBLNJIMIMN.y * 2f, 1f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 4f, CDBLNJIMIMN.y * 1.5f, 1f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 6f, 0f, 0.84f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 11f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.LJCDGJKCNEC;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 9f, 0f, 0f).onFinished = fAMGMBGPMFH.EJLGBICBIFK;
	}

	public void GBBKLLOFGNL(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: false);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 923f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 984f, 1940f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 910f, CDBLNJIMIMN.y * 889f, 1f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 1644f, CDBLNJIMIMN.y * 403f, 738f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1597f, 319f, 1597f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 371f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.DHELLAHDBDN;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 300f, 1103f, 1020f).onFinished = fAMGMBGPMFH.CLLDAFLGJJJ;
	}

	[SpecialName]
	public static DialogOverlayGuiElement ONEAEHMCMOI()
	{
		BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: true));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("T");
		}
		return BJHPKLAEFCI;
	}

	private void HNGCFIDBGPB(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	private void EEKCBLHGELK(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OFFCOEOCHML));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public static DialogOverlayGuiElement NPAFFJCBGLB()
	{
		BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: false));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("menu-info-close-ico");
		}
		return BJHPKLAEFCI;
	}

	private void OLMICOOOOAK(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNGCFIDBGPB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	private void BAPEHMOKFOF(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BFPOEICBPBF));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	public void OJOJNNONLJJ(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 391f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 619f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 1642f).onFinished = PEOLDCKHJON;
	}

	[CompilerGenerated]
	private void BIJFCBPFPJL(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KIALHNGKAMB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public static DialogOverlayGuiElement KJNIJCBJJDE()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: false)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("{0} Squad Best Stat");
		}
		return BJHPKLAEFCI;
	}

	private void HOLCFNAPPDP(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KIALHNGKAMB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	public void MPILHKGGALM(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: false);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 669f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 119f, 1480f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 817f, CDBLNJIMIMN.y * 329f, 1113f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 151f, CDBLNJIMIMN.y * 270f, 1117f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1139f, 1291f, 154f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 884f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.EOHOLKEGGLH;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1713f, 958f, 1569f).onFinished = fAMGMBGPMFH.PBFKJPANDKF;
	}

	private void MKJDEFFADPB(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	[SpecialName]
	public static DialogOverlayGuiElement KJEBPOBPMBD()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: false)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("ID_INBRONZE2");
		}
		return BJHPKLAEFCI;
	}

	private void MONFJPCIJDD(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OFFCOEOCHML));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	private void IHEOIBJKPGO(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKJDEFFADPB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	private void BFPOEICBPBF(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	[SpecialName]
	public static DialogOverlayGuiElement ECPMDFGJHCD()
	{
		BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: true));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("ID_TUTORIAL_UPGRADEWEAPON_4");
		}
		return BJHPKLAEFCI;
	}

	public void NCACNFJLMMH(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 101f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 936f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 1293f).onFinished = OLMICOOOOAK;
	}

	public void EFIHFBMJIKC(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 288f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 62f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 238f).onFinished = MONFJPCIJDD;
	}

	[SpecialName]
	public static DialogOverlayGuiElement GLBMFDGFBDA()
	{
		BJHPKLAEFCI = (DialogOverlayGuiElement)SingletonSupport.FirstOrDefault((UnityEngine.Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogOverlayGuiElement>(includeInactive: true));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("ID_WARNING_BUDDYCARDNOTREADY");
		}
		return BJHPKLAEFCI;
	}

	private void DLOOGEIMGHP(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNGCFIDBGPB));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: true);
	}

	public void INAJLHGNAEK(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: false);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 870f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 607f, 13f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 563f, CDBLNJIMIMN.y * 1767f, 614f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 676f, CDBLNJIMIMN.y * 1905f, 759f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1221f, 1854f, 441f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 953f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.CJIBPJPJLNB;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1303f, 153f, 541f).onFinished = fAMGMBGPMFH.IFOPOPPMCFG;
	}

	private void BCFBGPIIDLA(UITweener MGDJMGHCAAI)
	{
		UIEventListener uIEventListener = UIEventListener.Get(KLODDNMDPAO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OFFCOEOCHML));
		MGDJMGHCAAI.onFinished = null;
		base.gameObject.SetActive(value: false);
	}

	public void LPLOFEOOOIK(float KBJEOEEOEFG)
	{
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, KBJEOEEOEFG, 1663f);
		TweenScale.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, Vector3.one).onFinished = null;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, KBJEOEEOEFG, 1052f).onFinished = null;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, KBJEOEEOEFG, 493f).onFinished = OLMICOOOOAK;
	}

	private void KIALHNGKAMB(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
	}

	public void IFBOPIHAODP(float KBJEOEEOEFG)
	{
		FAMGMBGPMFH fAMGMBGPMFH = new FAMGMBGPMFH();
		fAMGMBGPMFH.BJGCPDNMHDH = this;
		base.gameObject.SetActive(value: false);
		fAMGMBGPMFH.HAMKIKMJHDP = KBJEOEEOEFG / 1806f;
		TweenAlpha.Begin(PLNPMJCNMPG.gameObject, fAMGMBGPMFH.HAMKIKMJHDP, 1417f, 206f).onFinished = null;
		fAMGMBGPMFH.IHPFHCOLJCL = new Vector3(CDBLNJIMIMN.x * 169f, CDBLNJIMIMN.y * 423f, 1351f);
		fAMGMBGPMFH.JOFJBFEPFJD = new Vector3(CDBLNJIMIMN.x * 1427f, CDBLNJIMIMN.y * 664f, 862f);
		TweenAlpha.Begin(KLODDNMDPAO.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1501f, 1471f, 355f);
		TweenScale tweenScale = TweenScale.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 1518f, Vector3.one, Vector3.one);
		tweenScale.onFinished = fAMGMBGPMFH.CJIBPJPJLNB;
		TweenAlpha.Begin(PEJFFMLEHFA.gameObject, fAMGMBGPMFH.HAMKIKMJHDP * 715f, 1461f, 1892f).onFinished = fAMGMBGPMFH.ANFPNINIKHI;
	}
}
