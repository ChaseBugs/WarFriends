using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class DeathMatchUnitsGuiElement : GuiElement
{
	private sealed class BLGLIAGMEDE
	{
		internal UISprite GMPADNOGGNL;

		internal TrailRenderer OBFCKJGONCE;

		internal Vector3 IMIJCJGPIAC;

		internal Vector3 NDOMCAEINKF;

		internal DeathMatchUnitsGuiElement BJGCPDNMHDH;

		internal void LHPPLGOOLEC(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1039f * BJGCPDNMHDH.HAMKIKMJHDP, 89f, 42f).onFinished = ENOBKGECBGB;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 1880f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF).onFinished = KOMGBNFDPEB;
		}

		internal void CDFAIFAHJLN(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1339f, 399f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void MMIFBGAHMHD(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(false);
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 3f * BJGCPDNMHDH.HAMKIKMJHDP, 1f, 1f).onFinished = EJLGBICBIFK;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 4f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF).onFinished = HONCMBHEKDP;
		}

		internal void FKBGKGFEEIB(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 140f, 1546f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void OMNNEIFECNE(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1998f, 825f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void DLODDIOIDME(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 562f, 1029f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = true;
			}
		}

		internal void HBJNMCDOHKK(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 312f, 1889f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = true;
			}
		}

		internal void GMHEAIHOBEL(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(true);
		}

		internal void HONCMBHEKDP(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(false);
		}

		internal void BLEMBJFNOGA(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(true);
		}

		internal void JHPEFFLPHCF(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 993f, 1084f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void KBBDIDNKLFN(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 214f, 1154f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = true;
			}
		}

		internal void LKKLABBEOAG(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 556f * BJGCPDNMHDH.HAMKIKMJHDP, 1264f, 1933f).onFinished = KILJJNKMNHO;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 1168f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF, false).onFinished = BLEMBJFNOGA;
		}

		internal void KCOGEFBNDKA(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1841f, 448f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = true;
			}
		}

		internal void EIGOHMKAMGI(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1894f, 1036f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void BFMHIICIHKL(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1181f, 1103f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = true;
			}
		}

		internal void KILJJNKMNHO(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1114f, 240f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void HADFFMNIJLN(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(true);
		}

		internal void BDCAFHOHEGM(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1377f * BJGCPDNMHDH.HAMKIKMJHDP, 1099f, 1206f).onFinished = DLODDIOIDME;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 666f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF, false).onFinished = HONCMBHEKDP;
		}

		internal void CFJHDIHLIML(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1538f * BJGCPDNMHDH.HAMKIKMJHDP, 1534f, 983f).onFinished = ENOBKGECBGB;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 1069f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF, false).onFinished = BLEMBJFNOGA;
		}

		internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1279f * BJGCPDNMHDH.HAMKIKMJHDP, 210f, 209f).onFinished = EIGOHMKAMGI;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 674f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF).onFinished = HONCMBHEKDP;
		}

		internal void MBMPBDEFNGE(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 778f, 1474f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void BACBENPDILB(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(true);
		}

		internal void JCFDEFFIHAM(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1132f, 734f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = true;
			}
		}

		internal void EPKHDMKOJND(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(false);
		}

		internal void JNGEDKMBDDP(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(true);
		}

		internal void GANNNCEMLPI(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1947f, 812f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void INFLOOLPOBK(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 965f * BJGCPDNMHDH.HAMKIKMJHDP, 279f, 1196f).onFinished = KCOGEFBNDKA;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 1961f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF, false).onFinished = BACBENPDILB;
		}

		internal void MMGEJAEDPOB(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(true);
		}

		internal void HPAFKBIJMEJ(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(false);
		}

		internal void BCEGPIKPFJF(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(true);
		}

		internal void NCLMPCCHDAM(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 168f * BJGCPDNMHDH.HAMKIKMJHDP, 1526f, 1295f).onFinished = HBJNMCDOHKK;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 1501f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF).onFinished = BCEGPIKPFJF;
		}

		internal void KOMGBNFDPEB(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(true);
		}

		internal void NNFHNIMCBLH(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1195f * BJGCPDNMHDH.HAMKIKMJHDP, 1810f, 1292f).onFinished = JCFDEFFIHAM;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 1959f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF, false).onFinished = HJACFCPOPME;
		}

		internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1508f * BJGCPDNMHDH.HAMKIKMJHDP, 734f, 1863f).onFinished = JCFDEFFIHAM;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 1653f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF).onFinished = HPAFKBIJMEJ;
		}

		internal void MJLPMDLMCLH(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(false);
		}

		internal void ENOBKGECBGB(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1865f, 828f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = true;
			}
		}

		internal void EJLGBICBIFK(UITweener MKAPOHKFIJH)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, 1f, 0f).onFinished = null;
			if (OBFCKJGONCE != null)
			{
				OBFCKJGONCE.enabled = false;
			}
		}

		internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1100f * BJGCPDNMHDH.HAMKIKMJHDP, 563f, 941f).onFinished = DLODDIOIDME;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 356f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF).onFinished = MMIFBGAHMHD;
		}

		internal void HJACFCPOPME(UITweener GCNILAHBDMJ)
		{
			GMPADNOGGNL.gameObject.SetActive(false);
		}

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1660f * BJGCPDNMHDH.HAMKIKMJHDP, 1287f, 1057f).onFinished = JCFDEFFIHAM;
			TweenPosition.Begin(GMPADNOGGNL.gameObject, 1326f * BJGCPDNMHDH.HAMKIKMJHDP, IMIJCJGPIAC, NDOMCAEINKF).onFinished = GMHEAIHOBEL;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action IINJILAFJLL;

	[Header("Deploy Energy")]
	public DeployEnergyElement MDBPINJMNKO;

	[Header("Deploy Energy animation")]
	public UISprite[] JNNCEEGPGJM;

	public float JMDHPGCOKIO = 0.7f;

	public float HAMKIKMJHDP = 0.1f;

	public float ENMDJLMGCDF = 0.02f;

	[Header("Core")]
	public List<DeathMatchGuiCard> INIKAAAIPCK;

	[Header("Tutorial")]
	public GameObject CNMDFMGELLH;

	public UILabel MPLFAOFAEDJ;

	[Header("Auto Deploy")]
	public GameObject FAJBFGGJEFJ;

	public GameObject EAIHOMFLPEJ;

	public UISprite AFOIMHFICOA;

	public UILabel IBKGLKFEPND;

	private bool LBKJNKIBNGI;

	private int FAJFLPLAMPN = -1;

	private float BEDPJJCLHKF;

	protected readonly List<SpawningManagerDeathMatch.ArmyUnitDefinition> DGELKCABCEC = new List<SpawningManagerDeathMatch.ArmyUnitDefinition>();

	private Vector3 JDDIPOLFBDD;

	private Vector3 BANNHIPBNDB;

	private bool OCNICHHIGGH;

	private bool BKHIJIBEHFF;

	[CompilerGenerated]
	private static Comparison<SpawningManagerDeathMatch.ArmyUnitDefinition> LGJCBPOPCPA;

	public static DeathMatchUnitsGuiElement instance { get; protected set; }

	protected virtual float PCPCPEFOOEJ
	{
		get
		{
			return 0.25f;
		}
	}

	protected virtual bool BDKNNNCHILL
	{
		get
		{
			return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
		}
	}

	public event Action onSendUnit
	{
		add
		{
			Action action = IINJILAFJLL;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref IINJILAFJLL, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = IINJILAFJLL;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref IINJILAFJLL, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public virtual void GCGPANMGOPN()
	{
	}

	private void IAJFGNBOCDA(UITweener MGDJMGHCAAI)
	{
		CNMDFMGELLH.SetActive(true);
	}

	protected virtual void EOENCMIBMGH()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		DGELKCABCEC.Clear();
		DGELKCABCEC.AddRange(dPDIFLKIFJC);
		DGELKCABCEC.Sort(MONHPACPNHK);
	}

	[CompilerGenerated]
	private void PCOKCOFAOJA(UITweener MGDJMGHCAAI)
	{
		CNMDFMGELLH.SetActive(false);
	}

	public void OFCAHFCAGJK(bool NABOFKMBMKH)
	{
		CNMDFMGELLH.SetActive(NABOFKMBMKH);
		if (NABOFKMBMKH)
		{
			TweenAlpha.Begin(CNMDFMGELLH, 1973f, 1890f);
			MPLFAOFAEDJ.text = Localization.Localize("ID_CONFIRM_ERROR");
			MEJMLNDFDBP.COCBCFKJOJE(MPLFAOFAEDJ, 349f, 1126f, 120);
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(CNMDFMGELLH, 1239f, 1326f);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(IAJFGNBOCDA));
		}
	}

	public void JADNIAFKNIF(bool NABOFKMBMKH, bool FMOIFJNOIKA = true)
	{
		CNMDFMGELLH.SetActive(NABOFKMBMKH);
		if (NABOFKMBMKH)
		{
			TweenAlpha.Begin(CNMDFMGELLH, 602f, 198f);
			MPLFAOFAEDJ.text = Localization.Localize("ID_TUTORIAL_FINISHHIM");
			MEJMLNDFDBP.COCBCFKJOJE(MPLFAOFAEDJ, 454f, 795f, -190);
		}
	}

	protected virtual void HELGKJIGBJJ()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		DGELKCABCEC.Clear();
		DGELKCABCEC.AddRange(dPDIFLKIFJC);
		DGELKCABCEC.Sort(delegate(SpawningManagerDeathMatch.ArmyUnitDefinition HPJFBKEKJHB, SpawningManagerDeathMatch.ArmyUnitDefinition NCMHGPNPEJM)
		{
			if (HPJFBKEKJHB == null)
			{
				return 1;
			}
			return (NCMHGPNPEJM == null) ? (-1) : HPJFBKEKJHB.power.CompareTo(NCMHGPNPEJM.power);
		});
	}

	public virtual void KPEJMMBDODD()
	{
	}

	public void AAMBELEDILP()
	{
		base.gameObject.SetActive(false);
		LBKJNKIBNGI = false;
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.LKMEEPPLMMJ();
		}
	}

	private void IHPACFLGHLB(UITweener MGDJMGHCAAI)
	{
		CNMDFMGELLH.SetActive(true);
	}

	protected void NOGLOKJINKN()
	{
		JADNIAFKNIF(true);
		ACPHOCKEOII();
		JDDIPOLFBDD = FAJBFGGJEFJ.transform.localPosition;
		BANNHIPBNDB = EAIHOMFLPEJ.transform.localPosition;
	}

	public override void InitControls()
	{
	}

	protected new void Awake()
	{
		ShowHintText(false);
		base.Awake();
		JDDIPOLFBDD = FAJBFGGJEFJ.transform.localPosition;
		BANNHIPBNDB = EAIHOMFLPEJ.transform.localPosition;
	}

	protected void ABMKKECEGIB()
	{
		ShowHintText(false, false);
		ACPHOCKEOII();
		JDDIPOLFBDD = FAJBFGGJEFJ.transform.localPosition;
		BANNHIPBNDB = EAIHOMFLPEJ.transform.localPosition;
	}

	[SpecialName]
	public void EFIPCGAKBIE(Action IDEBKDPMPGM)
	{
		Action action = IINJILAFJLL;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IINJILAFJLL, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static DeathMatchUnitsGuiElement BCDJJBAFLLG()
	{
		return _003CNLEFNAELOLN_003Ek__BackingField;
	}

	public void AnimateDeployEnergy(UISprite GMPADNOGGNL, Vector3 IMIJCJGPIAC, Vector3 NDOMCAEINKF, bool BEINCBHAGKC, float KALLNCAFIMP)
	{
		BLGLIAGMEDE bLGLIAGMEDE = new BLGLIAGMEDE();
		bLGLIAGMEDE.GMPADNOGGNL = GMPADNOGGNL;
		bLGLIAGMEDE.IMIJCJGPIAC = IMIJCJGPIAC;
		bLGLIAGMEDE.NDOMCAEINKF = NDOMCAEINKF;
		bLGLIAGMEDE.BJGCPDNMHDH = this;
		bLGLIAGMEDE.GMPADNOGGNL.gameObject.SetActive(true);
		bLGLIAGMEDE.GMPADNOGGNL.alpha = 0f;
		bLGLIAGMEDE.GMPADNOGGNL.transform.localPosition = bLGLIAGMEDE.IMIJCJGPIAC;
		bLGLIAGMEDE.OBFCKJGONCE = bLGLIAGMEDE.GMPADNOGGNL.gameObject.GetComponent<TrailRenderer>();
		if (bLGLIAGMEDE.OBFCKJGONCE != null && BEINCBHAGKC)
		{
			bLGLIAGMEDE.OBFCKJGONCE.enabled = true;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(bLGLIAGMEDE.GMPADNOGGNL.gameObject, JMDHPGCOKIO, 0f, 1f);
		tweenAlpha.delay = KALLNCAFIMP;
		tweenAlpha.onFinished = bLGLIAGMEDE.LJCDGJKCNEC;
	}

	protected virtual void EACCKDFLCMN()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> dPDIFLKIFJC = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC;
		DGELKCABCEC.Clear();
		DGELKCABCEC.AddRange(dPDIFLKIFJC);
		DGELKCABCEC.Sort(delegate(SpawningManagerDeathMatch.ArmyUnitDefinition HPJFBKEKJHB, SpawningManagerDeathMatch.ArmyUnitDefinition NCMHGPNPEJM)
		{
			if (HPJFBKEKJHB == null)
			{
				return 1;
			}
			return (NCMHGPNPEJM == null) ? (-1) : HPJFBKEKJHB.power.CompareTo(NCMHGPNPEJM.power);
		});
	}

	private void AFNJHEFNIOD(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC)
	{
		if (!BDKNNNCHILL)
		{
			return;
		}
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (item.OIJBDFANMCC == OIJBDFANMCC)
			{
				item.StartBlink();
				break;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(IBKGLKFEPND.gameObject, 0.3f, 0f, 1f);
			tweenAlpha.style = UITweener.Style.PingPong;
		}
	}

	private void FAAENMGPCKB(UITweener MGDJMGHCAAI)
	{
		CNMDFMGELLH.SetActive(true);
	}

	public void Enable()
	{
		MLDDKLFPFPF();
		base.gameObject.SetActive(true);
		AAMJFPKPFEP();
	}

	public virtual void AIIIDDDAPGB()
	{
	}

	private void CALLIDAEMID(UITweener MGDJMGHCAAI)
	{
		CNMDFMGELLH.SetActive(false);
	}

	[SpecialName]
	public void NMNMBJFHBPG(Action IDEBKDPMPGM)
	{
		Action action = IINJILAFJLL;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IINJILAFJLL, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void OFOGLOOHGNL(bool NABOFKMBMKH)
	{
		CNMDFMGELLH.SetActive(NABOFKMBMKH);
		if (NABOFKMBMKH)
		{
			TweenAlpha.Begin(CNMDFMGELLH, 429f, 1232f);
			MPLFAOFAEDJ.text = Localization.Localize("ID_RENTAL_ASSAULTRIFLE");
			MEJMLNDFDBP.COCBCFKJOJE(MPLFAOFAEDJ, 577f, 287f, 188);
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(CNMDFMGELLH, 176f, 1029f);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(IAJFGNBOCDA));
		}
	}

	public void ForceUpdatePower()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.PCKJMMKNDMJ.DoUpdate(true);
		}
	}

	private void FBMGOCJADHC(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC)
	{
		if (!BDKNNNCHILL)
		{
			return;
		}
		bool flag = false;
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (item.OIJBDFANMCC == OIJBDFANMCC && !flag)
			{
				item.StartProgress();
				flag = true;
			}
			else
			{
				item.DisableCard();
			}
		}
		PPKGFHAELEP();
		if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled || Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled)
		{
			TweenPosition.Begin(EAIHOMFLPEJ, 0.5f, BANNHIPBNDB - Vector3.up * 450f).delay = 0f;
			TweenAlpha.Begin(EAIHOMFLPEJ, 0.5f, 0f).delay = 0f;
		}
		BKHIJIBEHFF = false;
	}

	public void SendUnit(DeathMatchGuiCard CEKHIJECPNP, SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool GCGOGMDOBED = false)
	{
		if (LBKJNKIBNGI)
		{
			return;
		}
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (CEKHIJECPNP == item)
			{
				item.StartProgress();
			}
			else
			{
				item.DisableCard();
			}
		}
		if (IINJILAFJLL != null)
		{
			IINJILAFJLL();
		}
		Singleton<SpawningManagerDeathMatch>.instance.SendUnit(OIJBDFANMCC, PlayerController.OGMBJPKOPCB.fraction, true, GCGOGMDOBED);
		PPKGFHAELEP();
		if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled || Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled)
		{
			TweenPosition.Begin(EAIHOMFLPEJ, 0.5f, BANNHIPBNDB - Vector3.up * 450f).delay = 0f;
			TweenAlpha.Begin(EAIHOMFLPEJ, 0.5f, 0f).delay = 0f;
			BKHIJIBEHFF = false;
		}
	}

	public void CLLFHCFEMED()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.GDDNAKOHKLE();
		}
	}

	private void PDMBDKMINKF(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC)
	{
		if (!BDKNNNCHILL)
		{
			return;
		}
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (item.OIJBDFANMCC == OIJBDFANMCC)
			{
				item.OOPNAKIJOAP();
				break;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(IBKGLKFEPND.gameObject, 102f, 1441f, 1264f);
			tweenAlpha.style = (UITweener.Style)3;
		}
	}

	public void MJICKKCJBKI()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (item.HKBAOKEODAL())
			{
				item.Hide();
			}
		}
	}

	public void ShowKillHelp(bool NABOFKMBMKH)
	{
		CNMDFMGELLH.SetActive(NABOFKMBMKH);
		if (NABOFKMBMKH)
		{
			TweenAlpha.Begin(CNMDFMGELLH, 0.5f, 1f);
			MPLFAOFAEDJ.text = Localization.Localize("ID_TUTORIAL_KILLENEMYUNITS");
			MEJMLNDFDBP.COCBCFKJOJE(MPLFAOFAEDJ, 56f, 28f, 460);
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(CNMDFMGELLH, 0.5f, 0f);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
			{
				CNMDFMGELLH.SetActive(false);
			});
		}
	}

	public override void InitGUIValues()
	{
	}

	public void NAFFNLGHBCB()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (item.HKBAOKEODAL())
			{
				item.Hide();
			}
		}
	}

	public void ShowHintText(bool NABOFKMBMKH, bool FMOIFJNOIKA = true)
	{
		CNMDFMGELLH.SetActive(NABOFKMBMKH);
		if (NABOFKMBMKH)
		{
			TweenAlpha.Begin(CNMDFMGELLH, 0.5f, 1f);
			MPLFAOFAEDJ.text = Localization.Localize("ID_TUTORIAL_UNITSDEPLOYMENT");
			MEJMLNDFDBP.COCBCFKJOJE(MPLFAOFAEDJ, 60f, 30f, 460);
		}
	}

	protected virtual void PPKGFHAELEP()
	{
		TweenPosition.Begin(FAJBFGGJEFJ, 0.5f, JDDIPOLFBDD - Vector3.up * 450f).delay = 0f;
	}

	protected virtual void JOCHCGHAIGH()
	{
		base.IIFBKHDMIAD();
		if (DGELKCABCEC.Count == 0)
		{
			int num = 1;
			for (int i = 1; i < DGELKCABCEC.Count; i++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = DGELKCABCEC[i];
				if (armyUnitDefinition != null)
				{
					if (armyUnitDefinition.power > (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE && num != armyUnitDefinition.ECDLBDAIMLH())
					{
						float num2 = (float)((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE - num) / (float)(armyUnitDefinition.PAABCABFLIL() - num);
						break;
					}
					num = armyUnitDefinition.PAABCABFLIL();
				}
			}
			for (int j = 0; j < DGELKCABCEC.Count; j++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition2 = DGELKCABCEC[j];
				if (armyUnitDefinition2 != null)
				{
					num = armyUnitDefinition2.KDEFGKFJJBO();
				}
			}
		}
		if (LBKJNKIBNGI && Time.unscaledTime > BEDPJJCLHKF)
		{
			BEDPJJCLHKF = Time.unscaledTime + PCPCPEFOOEJ;
			FAJFLPLAMPN += 0;
			SpawningManagerDeathMatch.ArmyUnitDefinition oIJBDFANMCC = DGELKCABCEC[FAJFLPLAMPN];
			INIKAAAIPCK[FAJFLPLAMPN].LEJEDFACEGP(oIJBDFANMCC);
			if (FAJFLPLAMPN == 4)
			{
				LBKJNKIBNGI = true;
			}
		}
		if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployProgress > 1841f && !BKHIJIBEHFF && FAJFLPLAMPN > 0 && (Singleton<SpawningManagerDeathMatch>.instance.BNFMKEEHJKC() || Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled))
		{
			BKHIJIBEHFF = false;
			TweenPosition.Begin(EAIHOMFLPEJ, 653f, BANNHIPBNDB).delay = 759f;
			if (DebugSettings.instance.data.showHud)
			{
				TweenAlpha.Begin(EAIHOMFLPEJ, 1478f, 848f).delay = 245f;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(IBKGLKFEPND.gameObject, 32f, 871f);
			tweenAlpha.style = UITweener.Style.Loop;
		}
		AFOIMHFICOA.fillAmount = Singleton<SpawningManagerDeathMatch>.instance.FJLJBMIEOAI();
	}

	[SpecialName]
	protected virtual float DDDLCEEGCIN()
	{
		return 44f;
	}

	public void JJEJEAFBHKL()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.PCKJMMKNDMJ.OMLFAFFBECL();
		}
	}

	private static int JJHKNNLLHPG(SpawningManagerDeathMatch.ArmyUnitDefinition HPJFBKEKJHB, SpawningManagerDeathMatch.ArmyUnitDefinition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return 0;
		}
		if (NCMHGPNPEJM == null)
		{
			return -1;
		}
		return HPJFBKEKJHB.DGDHGPOCIAI().CompareTo(NCMHGPNPEJM.PINKLDPLHHN());
	}

	[SpecialName]
	protected virtual bool HKIIDANPPOP()
	{
		return Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic;
	}

	public void TutorialSetCards()
	{
		base.gameObject.SetActive(true);
		LBKJNKIBNGI = false;
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.HideOnGameStarted();
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += FLFLOMCEDKI;
		Singleton<SpawningManagerDeathMatch>.instance.RandomArmySent += FBMGOCJADHC;
		SpawningManagerDeathMatch spawningManagerDeathMatch = Singleton<SpawningManagerDeathMatch>.instance;
		spawningManagerDeathMatch.AFNJHEFNIOD = (Action<SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(spawningManagerDeathMatch.AFNJHEFNIOD, new Action<SpawningManagerDeathMatch.ArmyUnitDefinition>(AFNJHEFNIOD));
		Singleton<GameController>.instance.GameStarted += MLDDKLFPFPF;
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.Init(this);
		}
	}

	public void LPKIKIELBLK(bool NABOFKMBMKH)
	{
		CNMDFMGELLH.SetActive(NABOFKMBMKH);
		if (NABOFKMBMKH)
		{
			TweenAlpha.Begin(CNMDFMGELLH, 588f, 1366f);
			MPLFAOFAEDJ.text = Localization.Localize("ID_MISSIONANIMATION_BOSSWAVEIN");
			MEJMLNDFDBP.COCBCFKJOJE(MPLFAOFAEDJ, 1774f, 26f, 34);
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(CNMDFMGELLH, 1858f, 315f);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
			{
				CNMDFMGELLH.SetActive(false);
			});
		}
	}

	private void MLDDKLFPFPF()
	{
		base.gameObject.SetActive(Singleton<GameController>.instance.mainController.canDeployUnits);
		base.enabled = BDKNNNCHILL;
		if (BDKNNNCHILL)
		{
			instance = this;
			foreach (DeathMatchGuiCard item in INIKAAAIPCK)
			{
				item.enabled = true;
				item.HideOnGameStarted();
			}
			LBKJNKIBNGI = false;
			BKHIJIBEHFF = false;
			MDBPINJMNKO.shouldUpdate = Singleton<GameController>.instance.mainController.canDeployUnits;
			OCNICHHIGGH = true;
			ShowHintText(false);
			TweenPosition.Begin(FAJBFGGJEFJ, 0f, JDDIPOLFBDD - Vector3.up * 450f).delay = 0f;
			TweenPosition.Begin(EAIHOMFLPEJ, 0f, BANNHIPBNDB - Vector3.up * 450f).delay = 0f;
			if (DebugSettings.instance.data.showHud)
			{
				TweenAlpha.Begin(EAIHOMFLPEJ, 0f, 1f).delay = 0f;
			}
			return;
		}
		foreach (DeathMatchGuiCard item2 in INIKAAAIPCK)
		{
			item2.enabled = false;
		}
	}

	private void AAMJFPKPFEP()
	{
		EACCKDFLCMN();
		HideCards();
		if (OCNICHHIGGH)
		{
			for (int i = 0; i < DGELKCABCEC.Count; i++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition oIJBDFANMCC = DGELKCABCEC[i];
				INIKAAAIPCK[i].Show(oIJBDFANMCC, true);
			}
			OCNICHHIGGH = false;
			TweenPosition.Begin(FAJBFGGJEFJ, 0f, JDDIPOLFBDD).delay = 0f;
			if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled || (Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled && Singleton<SpawningManagerDeathMatch>.instance.powerForSemiDeploy))
			{
				TweenPosition.Begin(EAIHOMFLPEJ, 0f, BANNHIPBNDB).delay = 0f;
				if (DebugSettings.instance.data.showHud)
				{
					TweenAlpha.Begin(EAIHOMFLPEJ, 0f, 1f).delay = 0f;
				}
			}
			FAJFLPLAMPN = 2;
			return;
		}
		LBKJNKIBNGI = true;
		FAJFLPLAMPN = -1;
		BEDPJJCLHKF = Time.unscaledTime + 1f;
		TweenPosition.Begin(FAJBFGGJEFJ, 0.5f, JDDIPOLFBDD).delay = 0.8f;
		if (Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Classic)
		{
			for (int j = 0; j < DGELKCABCEC.Count; j++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition oIJBDFANMCC2 = DGELKCABCEC[j];
				INIKAAAIPCK[j].PreShowPowerProgress(oIJBDFANMCC2);
			}
		}
	}

	public void EPMGJBDPGJM()
	{
		base.gameObject.SetActive(true);
		LBKJNKIBNGI = false;
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.JGCOIPMPKLD();
		}
	}

	protected override void Update()
	{
		base.Update();
		if (DGELKCABCEC.Count == 3)
		{
			int num = 0;
			for (int i = 0; i < DGELKCABCEC.Count; i++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = DGELKCABCEC[i];
				if (armyUnitDefinition != null)
				{
					if (armyUnitDefinition.power > (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE && num != armyUnitDefinition.power)
					{
						float num2 = (float)((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE - num) / (float)(armyUnitDefinition.power - num);
						break;
					}
					num = armyUnitDefinition.power;
				}
			}
			for (int j = 0; j < DGELKCABCEC.Count; j++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition2 = DGELKCABCEC[j];
				if (armyUnitDefinition2 != null)
				{
					num = armyUnitDefinition2.power;
				}
			}
		}
		if (LBKJNKIBNGI && Time.unscaledTime > BEDPJJCLHKF)
		{
			BEDPJJCLHKF = Time.unscaledTime + PCPCPEFOOEJ;
			FAJFLPLAMPN++;
			SpawningManagerDeathMatch.ArmyUnitDefinition oIJBDFANMCC = DGELKCABCEC[FAJFLPLAMPN];
			INIKAAAIPCK[FAJFLPLAMPN].Show(oIJBDFANMCC);
			if (FAJFLPLAMPN == 2)
			{
				LBKJNKIBNGI = false;
			}
		}
		if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployProgress > 0.05f && !BKHIJIBEHFF && FAJFLPLAMPN > 1 && (Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled || Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled))
		{
			BKHIJIBEHFF = true;
			TweenPosition.Begin(EAIHOMFLPEJ, 0.5f, BANNHIPBNDB).delay = 0f;
			if (DebugSettings.instance.data.showHud)
			{
				TweenAlpha.Begin(EAIHOMFLPEJ, 0.5f, 1f).delay = 0f;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(IBKGLKFEPND.gameObject, 0f, 1f);
			tweenAlpha.style = UITweener.Style.Once;
		}
		AFOIMHFICOA.fillAmount = Singleton<SpawningManagerDeathMatch>.instance.autoDeployProgress;
	}

	private static int MONHPACPNHK(SpawningManagerDeathMatch.ArmyUnitDefinition HPJFBKEKJHB, SpawningManagerDeathMatch.ArmyUnitDefinition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return 0;
		}
		if (NCMHGPNPEJM == null)
		{
			return -1;
		}
		return HPJFBKEKJHB.ECDLBDAIMLH().CompareTo(NCMHGPNPEJM.CFCNFMLNKBF());
	}

	public void HideCards()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (item.isSelected)
			{
				item.Hide();
			}
		}
	}

	[SpecialName]
	public static DeathMatchUnitsGuiElement BKLDAAPMMDI()
	{
		return _003CNLEFNAELOLN_003Ek__BackingField;
	}

	private void OJNCKCEHPBK()
	{
		base.gameObject.SetActive(Singleton<GameController>.instance.mainController.canDeployUnits);
		base.enabled = HKIIDANPPOP();
		if (HKIIDANPPOP())
		{
			instance = this;
			foreach (DeathMatchGuiCard item in INIKAAAIPCK)
			{
				item.enabled = false;
				item.MGHBIFBLAMM();
			}
			LBKJNKIBNGI = false;
			BKHIJIBEHFF = true;
			MDBPINJMNKO.GAODJMFOOHM(Singleton<GameController>.instance.mainController.canDeployUnits);
			OCNICHHIGGH = false;
			JADNIAFKNIF(true, false);
			TweenPosition.Begin(FAJBFGGJEFJ, 1715f, JDDIPOLFBDD - Vector3.up * 1035f, false).delay = 965f;
			TweenPosition.Begin(EAIHOMFLPEJ, 30f, BANNHIPBNDB - Vector3.up * 1285f).delay = 1828f;
			if (DebugSettings.instance.data.showHud)
			{
				TweenAlpha.Begin(EAIHOMFLPEJ, 1462f, 1404f).delay = 1520f;
			}
			return;
		}
		foreach (DeathMatchGuiCard item2 in INIKAAAIPCK)
		{
			item2.enabled = true;
		}
	}

	public void GJDOHINBPPA(DeathMatchGuiCard CEKHIJECPNP, SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool GCGOGMDOBED = false)
	{
		if (LBKJNKIBNGI)
		{
			return;
		}
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (CEKHIJECPNP == item)
			{
				item.AIFMGJJDCGN();
			}
			else
			{
				item.MEEPBALNCOI();
			}
		}
		if (IINJILAFJLL != null)
		{
			IINJILAFJLL();
		}
		Singleton<SpawningManagerDeathMatch>.instance.KNFDNEMOOOC(OIJBDFANMCC, PlayerController.OGMBJPKOPCB.fraction, false, GCGOGMDOBED);
		PPKGFHAELEP();
		if (Singleton<SpawningManagerDeathMatch>.instance.BNFMKEEHJKC() || Singleton<SpawningManagerDeathMatch>.instance.LNOKMNNKMMI())
		{
			TweenPosition.Begin(EAIHOMFLPEJ, 568f, BANNHIPBNDB - Vector3.up * 1659f).delay = 1937f;
			TweenAlpha.Begin(EAIHOMFLPEJ, 1056f, 1923f).delay = 1018f;
			BKHIJIBEHFF = true;
		}
	}

	[SpecialName]
	public static DeathMatchUnitsGuiElement BLHCFKIELCA()
	{
		return _003CNLEFNAELOLN_003Ek__BackingField;
	}

	public void DeployEnergyIconAnimation(Vector3 GHECLGIFKNF, int OBLIPKDBBKL)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		List<UISprite> list = new List<UISprite>();
		for (int i = 0; i < JNNCEEGPGJM.Length; i++)
		{
			if (!JNNCEEGPGJM[i].gameObject.activeSelf)
			{
				list.Add(JNNCEEGPGJM[i]);
				if (list.Count == OBLIPKDBBKL)
				{
					break;
				}
			}
		}
		if (list.Count != 0)
		{
			list[0].transform.position = MDBPINJMNKO.NPJPLGDNLLB.transform.position;
			Vector3 nDOMCAEINKF = list[0].transform.localPosition.ReplaceZ(0f);
			Vector3 point = HealthBarManager.instance.KPDAPFBIPAI.WorldToViewportPoint(GHECLGIFKNF);
			point = Singleton<GuiManager>.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			list[0].transform.position = point;
			point = list[0].transform.localPosition.ReplaceZ(0f);
			list[0].transform.localPosition = point;
			for (int j = 0; j < list.Count; j++)
			{
				AnimateDeployEnergy(list[j], point, nDOMCAEINKF, j + 1 == list.Count, (float)j * ENMDJLMGCDF);
			}
		}
	}

	public void BKGPABJECKH()
	{
		base.gameObject.SetActive(true);
		LBKJNKIBNGI = true;
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.MGHBIFBLAMM();
		}
	}

	[CompilerGenerated]
	private static int FCEOJDOHFJO(SpawningManagerDeathMatch.ArmyUnitDefinition HPJFBKEKJHB, SpawningManagerDeathMatch.ArmyUnitDefinition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return 1;
		}
		if (NCMHGPNPEJM == null)
		{
			return -1;
		}
		return HPJFBKEKJHB.power.CompareTo(NCMHGPNPEJM.power);
	}

	public void IPOHNOBJOGA()
	{
		base.gameObject.SetActive(true);
		LBKJNKIBNGI = true;
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.MGHBIFBLAMM();
		}
	}

	private void MGBDLPEBGHJ(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC)
	{
		if (!HKIIDANPPOP())
		{
			return;
		}
		bool flag = false;
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (item.OIJBDFANMCC == OIJBDFANMCC && !flag)
			{
				item.GDACADEHBOC();
				flag = false;
			}
			else
			{
				item.MEEPBALNCOI();
			}
		}
		PPKGFHAELEP();
		if (Singleton<SpawningManagerDeathMatch>.instance.BNFMKEEHJKC() || Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled)
		{
			TweenPosition.Begin(EAIHOMFLPEJ, 666f, BANNHIPBNDB - Vector3.up * 1543f).delay = 384f;
			TweenAlpha.Begin(EAIHOMFLPEJ, 1303f, 1761f).delay = 1125f;
		}
		BKHIJIBEHFF = true;
	}

	public void NKANICHEFHL()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			if (item.HKBAOKEODAL())
			{
				item.DNNLAHACDCK();
			}
		}
	}

	[SpecialName]
	public void MEKNKHBOFMP(Action IDEBKDPMPGM)
	{
		Action action = IINJILAFJLL;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IINJILAFJLL, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private static int LNFBJKFIHFH(SpawningManagerDeathMatch.ArmyUnitDefinition HPJFBKEKJHB, SpawningManagerDeathMatch.ArmyUnitDefinition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return 0;
		}
		if (NCMHGPNPEJM == null)
		{
			return -1;
		}
		return HPJFBKEKJHB.EFJMMKHKLGA().CompareTo(NCMHGPNPEJM.IPHFBIGKNML());
	}

	public void EnableCardClick()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.EnableCardClick();
		}
	}

	[SpecialName]
	protected virtual float NLNEIHJIGHA()
	{
		return 1066f;
	}

	private static int IDPHNPHJBHD(SpawningManagerDeathMatch.ArmyUnitDefinition HPJFBKEKJHB, SpawningManagerDeathMatch.ArmyUnitDefinition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return 0;
		}
		if (NCMHGPNPEJM == null)
		{
			return -1;
		}
		return HPJFBKEKJHB.PAABCABFLIL().CompareTo(NCMHGPNPEJM.DCMOMJGELGJ());
	}

	public void DisableCardClick()
	{
		foreach (DeathMatchGuiCard item in INIKAAAIPCK)
		{
			item.DisableCardClick();
		}
	}

	private void FLFLOMCEDKI()
	{
		if (BDKNNNCHILL)
		{
			AAMJFPKPFEP();
		}
	}

	[SpecialName]
	public void FMMNEDCKCLE(Action IDEBKDPMPGM)
	{
		Action action = IINJILAFJLL;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IINJILAFJLL, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
