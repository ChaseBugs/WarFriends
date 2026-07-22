using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class LiveBroadcast : GuiElement
{
	[Header("Core")]
	[FormerlySerializedAs("ELBGLDNJMGG")]
	public UIPanel ALGEOJCCAAO;

	[FormerlySerializedAs("LNHCFODGFOB")]
	public UIButton BPNBIHABMLL;

	[FormerlySerializedAs("JANENKCDEGN")]
	public SettingsButton AMGBEJPNAJG;

	[FormerlySerializedAs("KJLMEGCMICB")]
	public GameObject BFMIILKHOJC;

	[FormerlySerializedAs("DJOEAKIHIII")]
	public GameObject LMFCMNAKDLN;

	[FormerlySerializedAs("MHFDMMBLOHM")]
	public GameObject BKPIJPKIPKN;

	[CompilerGenerated]
	private static UIEventListener.VoidDelegate LGJCBPOPCPA;

	[CompilerGenerated]
	private static UIEventListener.VoidDelegate CCNLMGEJBIB;

	[CompilerGenerated]
	private static void LJAPCHEAALG(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.launchApp();
	}

	private void BEANPHNGDDM(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1818f, 712f, 121f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	public virtual void GHHNNIKGJFG()
	{
	}

	public virtual void LIEGBJHHFIG()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: true);
		BFMIILKHOJC.gameObject.SetActive(Recording.LCMHHHCPDGO());
		EADJIIJINHH(NNOIPFBIENL: false);
	}

	private static void LKFBMICKGAB(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.GIGJIAILCEN("GooglePlay");
	}

	public virtual void NNGKAAGFGPA()
	{
	}

	public virtual void JJPILDGKAEK()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KMLDPKKBMPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LIMKGNADJNN));
	}

	private static void NNOAEBNPHNG(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.ADNHABBNKPO("SCARICA");
	}

	public virtual void GCPDEEPCBOF()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: true);
		BFMIILKHOJC.gameObject.SetActive(Recording.OJCEEFECMOD());
		EADJIIJINHH(NNOIPFBIENL: false);
	}

	private void FOFHJCENFAA(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 932f, 1667f, 245f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	private static void ACDBAMMKPGO(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.GIGJIAILCEN("game-neardeath-indicator");
	}

	private void DJEGBCECAFO(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 79f, 1396f, 1963f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	private static void GBDFNJPBJIG(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.OIBKMPDBGGJ("FacebookName");
	}

	private static void BHMAJOBMOMG(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.LODGDDFFHJL("ID_LEAGUE3");
	}

	public virtual void LAMBEOCPCBD()
	{
	}

	private static void GILALNFCAJL(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.MBHHLBBABPO("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT");
	}

	private static void CKCIHJFDKDO(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.launchApp("left");
	}

	private static void DAHIEHIIOLG(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.launchApp("PlayTrailRPC");
	}

	private static void AANFNAGKBOC(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.launchApp("Card_1_Played");
	}

	public virtual void KLABPENJAHJ()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: true);
		BFMIILKHOJC.gameObject.SetActive(Recording.OJCEEFECMOD());
		APPLLMMONEC(NNOIPFBIENL: true);
	}

	private static void LIMKGNADJNN(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.ANOOHNMMNIP("ID_PURCHASEINPROGRESS");
	}

	private static void GEDEDLMDEBL(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.ANOOHNMMNIP("ID_STAT_ASSAULTRIFLEKILLS");
	}

	public virtual void PLDBDGJLOFP()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.canBroadcast);
		EADJIIJINHH(NNOIPFBIENL: false);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			AndroidOpenBroadcastApp.launchApp();
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			AndroidOpenBroadcastApp.launchApp("com.mobcrush.mobcrush");
		});
	}

	public virtual void EFACHONJLPL()
	{
	}

	public virtual void KNBGAHKNBNN()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			AndroidOpenBroadcastApp.launchApp();
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CKCIHJFDKDO));
	}

	public virtual void OCACKBJDEHI()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.canBroadcast);
		AOCBMMGAMFL(NNOIPFBIENL: true);
	}

	public virtual void NGHAPNEFBED()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.OJCEEFECMOD());
		EADJIIJINHH(NNOIPFBIENL: false);
	}

	private static void ANOGOAEJHDI(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.NAPPGKJCKIA("Player chose to stay on his account");
	}

	[CompilerGenerated]
	private static void DAKDKMCEEGP(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.launchApp("com.mobcrush.mobcrush");
	}

	private void APPLLMMONEC(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1167f, 1843f, 50f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	private static void PMBJGIMLGMG(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.NAPPGKJCKIA("ADD special offer to show {0} {1} {2}");
	}

	public override void InitGUIValues()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.canBroadcast);
		NCAKEGECHOP(NNOIPFBIENL: false);
	}

	public virtual void PBKJDKFPILH()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNDFJGHMFPC));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJEINPMLDAC));
	}

	private void ACAGKBKJDJB(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1164f, 1999f, 1590f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	public virtual void KOJLOBAIPFP()
	{
		base.BEGCIOLGBLB();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNOAEBNPHNG));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMBJGIMLGMG));
	}

	private void MKGBILBJDPI(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 60f, 697f, 1215f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	private void AOCBMMGAMFL(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 691f, 293f, 470f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void KCJBNMDPBEA()
	{
		base.AMDCIHLNIHD();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNOAEBNPHNG));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMBJGIMLGMG));
	}

	private static void KMNHEFGCKFN(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.OIBKMPDBGGJ("country-norway");
	}

	public virtual void EHNFJGINHDJ()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.canBroadcast);
		APPLLMMONEC(NNOIPFBIENL: true);
	}

	private static void JNDFJGHMFPC(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.OIBKMPDBGGJ("Days_Since_Install");
	}

	public virtual void LLGOAIGJMJF()
	{
		base.AMDCIHLNIHD();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AANFNAGKBOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJEINPMLDAC));
	}

	private void FAPJEFEFAIN(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 515f, 1132f, 407f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	public virtual void HAOFBOPJBEI()
	{
		base.BEGCIOLGBLB();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KMLDPKKBMPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJEINPMLDAC));
	}

	public virtual void OBNCKIBJOGJ()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.OJCEEFECMOD());
		APPLLMMONEC(NNOIPFBIENL: true);
	}

	private void NCAKEGECHOP(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 0.5f, 0f, 1f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void OKMMGFMKJGG()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: true);
		BFMIILKHOJC.gameObject.SetActive(Recording.OJCEEFECMOD());
		HKBCKJMHCBN(NNOIPFBIENL: false);
	}

	private static void KJEINPMLDAC(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.GIGJIAILCEN("IsWarArena");
	}

	private static void LBCHADAIPDA(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.OIBKMPDBGGJ("finish");
	}

	public virtual void EGMFAHMCCBM()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.canBroadcast);
		NCAKEGECHOP(NNOIPFBIENL: true);
	}

	private static void BDNAAOOLPNP(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.NAPPGKJCKIA("ID_STAYINDIVISION");
	}

	public virtual void HPJDOALKOGF()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: true);
		BFMIILKHOJC.gameObject.SetActive(Recording.canBroadcast);
		FOFHJCENFAA(NNOIPFBIENL: true);
	}

	private static void LGEFJIPJMBN(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.OIBKMPDBGGJ(" ");
	}

	private void EADJIIJINHH(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 117f, 1659f, 749f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	public virtual void FPOJNMDAPOD()
	{
		base.BEGCIOLGBLB();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JFMCOGFCHCJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMBJGIMLGMG));
	}

	private static void KMLDPKKBMPN(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.NAPPGKJCKIA("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING");
	}

	public virtual void NEECLAOCOKD()
	{
	}

	private void FDJPBEKHHJH(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 132f, 1372f, 806f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
		}
	}

	public virtual void MAHBAJOCHGN()
	{
		base.AMDCIHLNIHD();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JFMCOGFCHCJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CKCIHJFDKDO));
	}

	private static void PPHPCDBOMCF(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.NAPPGKJCKIA("Difficulty");
	}

	private static void GHOKFNAJJMM(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.NAPPGKJCKIA("ID_ARMYPOWER");
	}

	public virtual void HHLOGFGGHHD()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: true);
		BFMIILKHOJC.gameObject.SetActive(Recording.OJCEEFECMOD());
		FOFHJCENFAA(NNOIPFBIENL: true);
	}

	private void NJNGOPCLJAP(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1849f, 284f, 1043f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void KLPJPLHNFON()
	{
	}

	public virtual void LBHEIOEPJLJ()
	{
	}

	public virtual void CDHLMEPGPNJ()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.canBroadcast);
		AOCBMMGAMFL(NNOIPFBIENL: false);
	}

	private void HKBCKJMHCBN(bool NNOIPFBIENL)
	{
		if (NNOIPFBIENL)
		{
			ALGEOJCCAAO.gameObject.SetActive(value: true);
			TweenAlpha.Begin(ALGEOJCCAAO.gameObject, 1806f, 1439f, 880f);
		}
		else
		{
			ALGEOJCCAAO.gameObject.SetActive(value: false);
		}
	}

	public virtual void AAPGEAEKKGF()
	{
	}

	private static void JFMCOGFCHCJ(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.MBHHLBBABPO("Start overtime RPC");
	}

	public override void InitControls()
	{
	}

	private static void BMLJJKABPGN(GameObject KHAHPAKDIKE)
	{
		AndroidOpenBroadcastApp.ADNHABBNKPO("ID_ARENAISOPEN");
	}

	public virtual void FLEBEIDLALJ()
	{
		base.AMDCIHLNIHD();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BMLJJKABPGN));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ACDBAMMKPGO));
	}

	public virtual void ILCKGHGDDJA()
	{
	}

	public virtual void GMOFOOGNOAH()
	{
		AMGBEJPNAJG.gameObject.transform.parent.gameObject.SetActive(value: false);
		BFMIILKHOJC.gameObject.SetActive(Recording.OJCEEFECMOD());
		BEANPHNGDDM(NNOIPFBIENL: false);
	}

	public virtual void HGFBALANKEE()
	{
		base.AMDCIHLNIHD();
		UIEventListener uIEventListener = UIEventListener.Get(LMFCMNAKDLN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHMAJOBMOMG));
		UIEventListener uIEventListener2 = UIEventListener.Get(BKPIJPKIPKN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ACDBAMMKPGO));
	}
}
