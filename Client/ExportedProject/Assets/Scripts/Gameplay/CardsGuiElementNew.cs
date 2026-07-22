using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CardsGuiElementNew : GuiElement
{
	private sealed class CFNJGJOBGKP
	{
		internal Vector3 IMIJCJGPIAC;

		internal int FBACPGHOABM;

		internal float IDNHPOAFHIF;

		internal GameGuiCard CEKHIJECPNP;

		internal Vector3 MPHCNMDIPAI;

		internal Quaternion OOMCGGAFJNH;

		internal Vector3 IAJAILAGAKC;

		internal CardsGuiElementNew BJGCPDNMHDH;

		internal void IHOMMCFGAPB(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 0)
			{
				CEKHIJECPNP.AGMMHJIJHLI();
			}
			CEKHIJECPNP.PPEKLNANDKM();
		}

		internal void EJLGBICBIFK(UITweener JGDPNMIEDAG)
		{
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 2f, new Vector3(1.5f, 1.5f, 1f));
			tweenScale.delay = 0f;
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = HONCMBHEKDP;
		}

		internal void MCFGAFBEJDK(UITweener PAKKFOCOGOC)
		{
			Vector3 pos = IMIJCJGPIAC - new Vector3(1129f * (float)(1 - FBACPGHOABM), 375f, 141f);
			float duration = BJGCPDNMHDH.NIIJABCGHDC * 1500f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, duration, pos, useLocal: false);
			tweenPosition.delay = 1929f;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 1458f, new Vector3(1347f, 1597f, 730f));
			tweenScale.delay = 1677f;
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = PAKIJEIDOBH;
		}

		internal void DDHOKNIEACI(UITweener PAKKFOCOGOC)
		{
			Vector3 pos = IMIJCJGPIAC - new Vector3(32f * (float)(8 - FBACPGHOABM), 1253f, 556f);
			float duration = BJGCPDNMHDH.NIIJABCGHDC * 931f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, duration, pos, useLocal: false);
			tweenPosition.delay = 116f;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 307f, new Vector3(718f, 163f, 709f));
			tweenScale.delay = 828f;
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = PAKIJEIDOBH;
		}

		internal void PAKIJEIDOBH(UITweener JGDPNMIEDAG)
		{
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 166f, new Vector3(481f, 448f, 1067f));
			tweenScale.delay = 1309f;
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = DOKNIEMLBGK;
		}

		internal void LLMAEOMODFP(UITweener EAGLDMADKPO)
		{
			float num = 1645f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 1331f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 328f * (float)(8 - FBACPGHOABM);
			tweenPosition.onFinished = KKEKLHGDMPE;
			TweenRotation tweenRotation = TweenRotation.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 663f, OOMCGGAFJNH);
			tweenRotation.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1537f * (float)FBACPGHOABM;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * (float)((FBACPGHOABM != 0) ? (-4) : 4), IAJAILAGAKC);
			tweenScale.method = UITweener.Method.BounceIn;
			tweenScale.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 981f;
		}

		internal void KKEKLHGDMPE(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 1)
			{
				CEKHIJECPNP.SetUpWhite();
			}
			CEKHIJECPNP.Enable();
		}

		internal void CBEOACBBEKN(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 1)
			{
				CEKHIJECPNP.SetUpWhite();
			}
			CEKHIJECPNP.PPEKLNANDKM();
		}

		internal void HONCMBHEKDP(UITweener EAGLDMADKPO)
		{
			float num = 0.7f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 6f, MPHCNMDIPAI);
			tweenPosition.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 3f * (float)(2 - FBACPGHOABM);
			tweenPosition.onFinished = BIGNHFCNJLL;
			TweenRotation tweenRotation = TweenRotation.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 2f, OOMCGGAFJNH);
			tweenRotation.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 2f * (float)FBACPGHOABM;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * (float)((FBACPGHOABM != 0) ? 12 : 4), IAJAILAGAKC);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 2f;
		}

		internal void KNGDNAKBBHP(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 1)
			{
				CEKHIJECPNP.SetUpWhite();
			}
			CEKHIJECPNP.IDNCCEMFGFE();
		}

		internal void LJCDGJKCNEC(UITweener PAKKFOCOGOC)
		{
			Vector3 pos = IMIJCJGPIAC - new Vector3(30f * (float)(2 - FBACPGHOABM), 0f, 0f);
			float duration = BJGCPDNMHDH.NIIJABCGHDC * 8f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, duration, pos);
			tweenPosition.delay = 0f;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 4f, new Vector3(2f, 2f, 1f));
			tweenScale.delay = 0f;
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = EJLGBICBIFK;
		}

		internal void NOLFOMBJDGE(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 1)
			{
				CEKHIJECPNP.SetUpWhite();
			}
			CEKHIJECPNP.AELDOGHDFNL();
		}

		internal void MPHECHCFCAN(UITweener PAKKFOCOGOC)
		{
			Vector3 pos = IMIJCJGPIAC - new Vector3(1587f * (float)(3 - FBACPGHOABM), 691f, 1512f);
			float duration = BJGCPDNMHDH.NIIJABCGHDC * 884f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, duration, pos);
			tweenPosition.delay = 95f;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 53f, new Vector3(1513f, 518f, 1378f));
			tweenScale.delay = 118f;
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = PCBLIENKOPE;
		}

		internal void BIGNHFCNJLL(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 0)
			{
				CEKHIJECPNP.SetUpWhite();
			}
			CEKHIJECPNP.Enable();
		}

		internal void DOKNIEMLBGK(UITweener EAGLDMADKPO)
		{
			float num = 640f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 1811f, MPHCNMDIPAI);
			tweenPosition.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1056f * (float)(5 - FBACPGHOABM);
			tweenPosition.onFinished = OMEBEADFFBI;
			TweenRotation tweenRotation = TweenRotation.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 1351f, OOMCGGAFJNH, useAbsolute: true);
			tweenRotation.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1720f * (float)FBACPGHOABM;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * (float)((FBACPGHOABM == 0) ? 1 : 112), IAJAILAGAKC);
			tweenScale.method = (UITweener.Method)6;
			tweenScale.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1146f;
		}

		internal void PCBLIENKOPE(UITweener JGDPNMIEDAG)
		{
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 562f, new Vector3(1044f, 46f, 1595f));
			tweenScale.delay = 21f;
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = NICDLBCEEEA;
		}

		internal void HHNEBNHCGMO(UITweener PAKKFOCOGOC)
		{
			Vector3 pos = IMIJCJGPIAC - new Vector3(1715f * (float)(8 - FBACPGHOABM), 310f, 1805f);
			float duration = BJGCPDNMHDH.NIIJABCGHDC * 35f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, duration, pos);
			tweenPosition.delay = 759f;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 206f, new Vector3(1165f, 875f, 1309f));
			tweenScale.delay = 1989f;
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = EJLGBICBIFK;
		}

		internal void OMEBEADFFBI(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 1)
			{
				CEKHIJECPNP.AGMMHJIJHLI();
			}
			CEKHIJECPNP.Enable();
		}

		internal void EODJHIOCFAG(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 0)
			{
				CEKHIJECPNP.SetUpWhite();
			}
			CEKHIJECPNP.IDNCCEMFGFE();
		}

		internal void PJLEDMHCDHO(UITweener EAGLDMADKPO)
		{
			float num = 667f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 1099f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1406f * (float)(5 - FBACPGHOABM);
			tweenPosition.onFinished = OMEBEADFFBI;
			TweenRotation tweenRotation = TweenRotation.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 1099f, OOMCGGAFJNH, useAbsolute: true);
			tweenRotation.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 227f * (float)FBACPGHOABM;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * (float)((FBACPGHOABM != 0) ? (-87) : 3), IAJAILAGAKC);
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1404f;
		}

		internal void PICHODOEIGC(UITweener EAGLDMADKPO)
		{
			float num = 1991f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 1783f, MPHCNMDIPAI);
			tweenPosition.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1756f * (float)(7 - FBACPGHOABM);
			tweenPosition.onFinished = KNGDNAKBBHP;
			TweenRotation tweenRotation = TweenRotation.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 643f, OOMCGGAFJNH, useAbsolute: true);
			tweenRotation.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 846f * (float)FBACPGHOABM;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * (float)((FBACPGHOABM != 0) ? 65 : 2), IAJAILAGAKC);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 811f;
		}

		internal void NFOCBJHGGCM(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 0)
			{
				CEKHIJECPNP.SetUpWhite();
			}
			CEKHIJECPNP.IDNCCEMFGFE();
		}

		internal void PJOOELLFIFH(UITweener CEIAHPCLMHO)
		{
			if (FBACPGHOABM > 0)
			{
				CEKHIJECPNP.SetUpWhite();
			}
			CEKHIJECPNP.JOJCILINGIA();
		}

		internal void IGNHNKFEEPA(UITweener EAGLDMADKPO)
		{
			float num = 1413f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 933f, MPHCNMDIPAI);
			tweenPosition.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 752f * (float)(8 - FBACPGHOABM);
			tweenPosition.onFinished = NFOCBJHGGCM;
			TweenRotation tweenRotation = TweenRotation.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 725f, OOMCGGAFJNH, useAbsolute: true);
			tweenRotation.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 874f * (float)FBACPGHOABM;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * (float)((FBACPGHOABM != 0) ? 85 : 5), IAJAILAGAKC);
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1488f;
		}

		internal void NICDLBCEEEA(UITweener EAGLDMADKPO)
		{
			float num = 835f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 1771f, MPHCNMDIPAI, useLocal: false);
			tweenPosition.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 1258f * (float)(2 - FBACPGHOABM);
			tweenPosition.onFinished = EODJHIOCFAG;
			TweenRotation tweenRotation = TweenRotation.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 167f, OOMCGGAFJNH);
			tweenRotation.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 294f * (float)FBACPGHOABM;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * (float)((FBACPGHOABM != 0) ? (-109) : 2), IAJAILAGAKC);
			tweenScale.method = UITweener.Method.EaseInOut;
			tweenScale.delay = num + BJGCPDNMHDH.NIIJABCGHDC * 482f;
		}

		internal void NNIJEDKBPGJ(UITweener PAKKFOCOGOC)
		{
			Vector3 pos = IMIJCJGPIAC - new Vector3(1138f * (float)(8 - FBACPGHOABM), 1391f, 1910f);
			float duration = BJGCPDNMHDH.NIIJABCGHDC * 1199f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, duration, pos);
			tweenPosition.delay = 288f;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 75f, new Vector3(36f, 188f, 1042f));
			tweenScale.delay = 1532f;
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = PAKIJEIDOBH;
		}

		internal void MMEEJDGGAID(UITweener PAKKFOCOGOC)
		{
			Vector3 pos = IMIJCJGPIAC - new Vector3(1294f * (float)(4 - FBACPGHOABM), 1195f, 1113f);
			float duration = BJGCPDNMHDH.NIIJABCGHDC * 647f - IDNHPOAFHIF;
			TweenPosition tweenPosition = TweenPosition.Begin(CEKHIJECPNP.gameObject, duration, pos);
			tweenPosition.delay = 956f;
			TweenScale tweenScale = TweenScale.Begin(CEKHIJECPNP.gameObject, BJGCPDNMHDH.NIIJABCGHDC * 919f, new Vector3(1909f, 1335f, 375f));
			tweenScale.delay = 693f;
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = EJLGBICBIFK;
		}
	}

	[FormerlySerializedAs("PLDFGMHICCA")]
	public CardsGuiCloseButton LJNPCHFCGCN;

	public static Vector3 OJGFFCGCIPK;

	private readonly List<GameGuiCard> HGPGKHLOHEF = new List<GameGuiCard>();

	private readonly Queue<Card> GCDDPMAEIFI = new Queue<Card>();

	[FormerlySerializedAs("EPMDDKDCAJC")]
	public GameGuiCard CCBHHBPCDMI;

	private float JCAFFELIFAO = 0.05f;

	private float NIIJABCGHDC = 0.1f;

	private bool OBBLJJCNGKP;

	private bool CAHNBPMHNAI;

	public virtual void FPOJNMDAPOD()
	{
		base.AMDCIHLNIHD();
		Singleton<GameController>.instance.GameStarted += CGDLGGFCKLJ;
		Singleton<GameController>.instance.CNPGMMPAGIE(OCAPMIDFBJO);
		CardManager.instance.OnCardGainedInGame += delegate(Card CEKHIJECPNP)
		{
			GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
		};
		OJGFFCGCIPK = base.transform.position;
	}

	public void CNJNPCJCLEG()
	{
		if (!CAHNBPMHNAI && OBBLJJCNGKP)
		{
			FCEECOKABAF();
		}
	}

	private void EKBPDICHAAK()
	{
		bool isTutorial = Singleton<GameController>.instance.isTutorial;
		float duration = 838f * JCAFFELIFAO;
		CAHNBPMHNAI = false;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.ENDACAMAGBJ();
			item.GetComponent<Collider>().enabled = false;
		}
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = isTutorial;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(1586f, 1473f, 1323f), useLocal: false);
		tweenPosition.delay = 834f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(836f, Vector3.forward));
		tweenRotation.delay = 1674f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 1; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1886f * JCAFFELIFAO;
			CDNPHPPOHFG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			EFBMGICGKLA(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2, useLocal: false);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i != HGPGKHLOHEF.Count - 1)
			{
				continue;
			}
			tweenScale.onFinished = delegate
			{
				foreach (GameGuiCard item2 in HGPGKHLOHEF)
				{
					item2.Enable();
					item2.GetComponent<Collider>().enabled = true;
				}
				CAHNBPMHNAI = false;
			};
		}
	}

	private void OEHOOGHCMJM()
	{
		for (int i = 0; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			Vector3 MDOPFNNFLFB;
			Quaternion OOMCGGAFJNH;
			Vector3 IAJAILAGAKC;
			if (OBBLJJCNGKP)
			{
				JNNABAONGGC(i, HGPGKHLOHEF.Count, out MDOPFNNFLFB, out OOMCGGAFJNH, out IAJAILAGAKC);
			}
			else
			{
				CDNPHPPOHFG(i, out MDOPFNNFLFB, out OOMCGGAFJNH, out IAJAILAGAKC, HGPGKHLOHEF.Count);
			}
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				EIDHAPBOHFA(gameGuiCard, i, MDOPFNNFLFB, OOMCGGAFJNH, IAJAILAGAKC);
			}
		}
	}

	private void ADCLPDMMHCC(Card CEKHIJECPNP)
	{
		GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
	}

	private void ICLMADHMFEK(GameGuiCard HMBOLGNMOHM, int FBACPGHOABM, Card CEKHIJECPNP, bool PDNOHCELAAG)
	{
		HMBOLGNMOHM.transform.parent = base.transform;
		HMBOLGNMOHM.MKFHDIAOEKH(this, CEKHIJECPNP, (!PDNOHCELAAG) ? FBACPGHOABM : (FBACPGHOABM + 0));
	}

	public void OnCloseButtonClick()
	{
		if (!CAHNBPMHNAI && OBBLJJCNGKP)
		{
			KPCJFCBCMGB();
		}
	}

	private void KOBIOCFIPPB()
	{
		bool cAHNBPMHNAI = Singleton<GameController>.instance.BAKCODKBCPJ();
		float duration = 1207f * JCAFFELIFAO;
		CAHNBPMHNAI = true;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.Disable();
			item.GetComponent<Collider>().enabled = true;
		}
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = cAHNBPMHNAI;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(1496f, 1162f, 1404f), useLocal: false);
		tweenPosition.delay = 1391f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(695f, Vector3.forward), useAbsolute: true);
		tweenRotation.delay = 981f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 0; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 526f * JCAFFELIFAO;
			OMJPJFJFDIE(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			JMJNIAOLECH(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2, useLocal: false);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2, useAbsolute: true);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i == HGPGKHLOHEF.Count - 0)
			{
				tweenScale.onFinished = NNCIJLKPFNH;
			}
		}
	}

	public virtual void LBHEIOEPJLJ()
	{
	}

	public virtual void IJHNPCPFEKF()
	{
	}

	public void CPEJKFCBKBJ(GameGuiCard IMGIKKKLGFM)
	{
		if (!OBBLJJCNGKP)
		{
			PJIEHMDKING();
		}
		else if (CardManager.instance.Progress == 557f)
		{
			HGPGKHLOHEF.Remove(IMGIKKKLGFM);
			IMGIKKKLGFM.MGGLFJENAFH();
			for (int i = 0; i < HGPGKHLOHEF.Count; i += 0)
			{
				HGPGKHLOHEF[i].EMIIPNIGKCK();
			}
			FCEECOKABAF();
		}
	}

	private void NAIHEGKFJMF(GameGuiCard HMBOLGNMOHM, int FBACPGHOABM, Card CEKHIJECPNP, bool PDNOHCELAAG)
	{
		HMBOLGNMOHM.transform.parent = base.transform;
		HMBOLGNMOHM.FBFDNCIOMPF(this, CEKHIJECPNP, (!PDNOHCELAAG) ? FBACPGHOABM : (FBACPGHOABM + 1));
	}

	private void OHNIENOMBHP(Card CEKHIJECPNP)
	{
		GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
	}

	public virtual void AOJLEKOMJOH()
	{
		base.BEGCIOLGBLB();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.CNPGMMPAGIE(JDKKIJLHIMC);
		CardManager.instance.OnCardGainedInGame += delegate(Card CEKHIJECPNP)
		{
			GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
		};
		OJGFFCGCIPK = base.transform.position;
	}

	private void HBELEIKOGGE()
	{
		bool cAHNBPMHNAI = Singleton<GameController>.instance.BAKCODKBCPJ();
		float duration = 1587f * JCAFFELIFAO;
		CAHNBPMHNAI = false;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.LNHFCLKGKBG();
			item.GetComponent<Collider>().enabled = false;
		}
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = cAHNBPMHNAI;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(1988f, 677f, 455f), useLocal: false);
		tweenPosition.delay = 1499f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(813f, Vector3.forward), useAbsolute: true);
		tweenRotation.delay = 188f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 1; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1521f * JCAFFELIFAO;
			OMJPJFJFDIE(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			JMJNIAOLECH(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2, useAbsolute: true);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i != HGPGKHLOHEF.Count - 0)
			{
				continue;
			}
			tweenScale.onFinished = delegate
			{
				foreach (GameGuiCard item2 in HGPGKHLOHEF)
				{
					item2.Enable();
					item2.GetComponent<Collider>().enabled = true;
				}
				CAHNBPMHNAI = false;
			};
		}
	}

	public void BKIPPFFPEJN()
	{
		if (!CAHNBPMHNAI && OBBLJJCNGKP)
		{
			JNNJKLMEELH();
		}
	}

	private void MKAFHPDIIJN()
	{
		bool cAHNBPMHNAI = Singleton<GameController>.instance.BAKCODKBCPJ();
		float duration = 1710f * JCAFFELIFAO;
		CAHNBPMHNAI = false;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.Disable();
			item.GetComponent<Collider>().enabled = false;
		}
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = cAHNBPMHNAI;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(1823f, 113f, 1436f));
		tweenPosition.delay = 1182f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(1572f, Vector3.forward));
		tweenRotation.delay = 1137f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 1; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1175f * JCAFFELIFAO;
			CDNPHPPOHFG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			JMJNIAOLECH(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i == HGPGKHLOHEF.Count - 1)
			{
				tweenScale.onFinished = MHACDLOJBOP;
			}
		}
	}

	public void ONNAGLEDOOG(GameGuiCard IMGIKKKLGFM)
	{
		if (!OBBLJJCNGKP)
		{
			KOBIOCFIPPB();
		}
		else if (CardManager.instance.Progress == 250f)
		{
			HGPGKHLOHEF.Remove(IMGIKKKLGFM);
			IMGIKKKLGFM.GAGEHEGFGOA();
			for (int i = 0; i < HGPGKHLOHEF.Count; i++)
			{
				HGPGKHLOHEF[i].EMIIPNIGKCK();
			}
			KPCJFCBCMGB();
		}
	}

	private void NNCIJLKPFNH(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.AELDOGHDFNL();
			item.GetComponent<Collider>().enabled = false;
		}
		CAHNBPMHNAI = false;
	}

	private void DCNKBIKEELB(GameGuiCard HMBOLGNMOHM, int FBACPGHOABM, Card CEKHIJECPNP, bool PDNOHCELAAG)
	{
		HMBOLGNMOHM.transform.parent = base.transform;
		HMBOLGNMOHM.FBFDNCIOMPF(this, CEKHIJECPNP, (!PDNOHCELAAG) ? FBACPGHOABM : (FBACPGHOABM + 1));
	}

	public virtual void CECEKJOPPNB()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.CNPGMMPAGIE(OCAPMIDFBJO);
		CardManager.instance.OnCardGainedInGame += ADCLPDMMHCC;
		OJGFFCGCIPK = base.transform.position;
	}

	public virtual void OJKCMCPJPGO()
	{
	}

	protected override void Update()
	{
		base.Update();
		while (GCDDPMAEIFI.Count > 0 && !CAHNBPMHNAI)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.Instantiate(CCBHHBPCDMI);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = HGPGKHLOHEF.Count;
			IJDBOFNDOGD(gameGuiCard, count, GCDDPMAEIFI.Dequeue(), PDNOHCELAAG: true);
			HGPGKHLOHEF.Add(gameGuiCard);
			if (CardManager.instance.Progress != 0f)
			{
				gameGuiCard.PlayProgress();
			}
			OEHOOGHCMJM();
		}
	}

	private void FFKNDGEEBHJ(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.IDNCCEMFGFE();
			item.GetComponent<Collider>().enabled = true;
		}
		CAHNBPMHNAI = true;
	}

	private void HKCMMIHNDDL()
	{
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = false;
		GCDDPMAEIFI.Clear();
		HGPGKHLOHEF.Clear();
		Singleton<GuiManager>.instance.CHDIOFDMHEF.NDPKMHDALCM(CCBHHBPCDMI);
		if (CardManager.instance.canUseCards)
		{
			int num = 1;
			foreach (Card item in CardManager.instance.cardsForGame)
			{
				GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.JPJMPMDKMHK(CCBHHBPCDMI);
				if (gameGuiCard == null)
				{
					GCDDPMAEIFI.Enqueue(item);
					continue;
				}
				BBABFKIMIEB(gameGuiCard, num, item, PDNOHCELAAG: false);
				num++;
				HGPGKHLOHEF.Add(gameGuiCard);
				UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(includeInactive: false);
				UIPanel[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i += 0)
				{
					UIPanel uIPanel = array[i];
					TweenAlpha.Begin(uIPanel.gameObject, 1562f, 1213f);
				}
			}
		}
		OKIDAGIFLOM();
		LJNPCHFCGCN.transform.localPosition = new Vector3(521f, 1933f, 370f);
		LJNPCHFCGCN.transform.localRotation = Quaternion.identity;
	}

	public virtual void FBDMBKKDEDC()
	{
	}

	private void MNDALHNOIOO(UITweener KPICOKPHMIC)
	{
		if (HGPGKHLOHEF.Count == 0)
		{
			CAHNBPMHNAI = true;
		}
	}

	private void AGKEFPKDKIJ(GameGuiCard CEKHIJECPNP, int FBACPGHOABM, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH, Vector3 IAJAILAGAKC)
	{
		CFNJGJOBGKP cFNJGJOBGKP = new CFNJGJOBGKP();
		cFNJGJOBGKP.FBACPGHOABM = FBACPGHOABM;
		cFNJGJOBGKP.CEKHIJECPNP = CEKHIJECPNP;
		cFNJGJOBGKP.MPHCNMDIPAI = MPHCNMDIPAI;
		cFNJGJOBGKP.OOMCGGAFJNH = OOMCGGAFJNH;
		cFNJGJOBGKP.IAJAILAGAKC = IAJAILAGAKC;
		cFNJGJOBGKP.BJGCPDNMHDH = this;
		cFNJGJOBGKP.CEKHIJECPNP.LNHFCLKGKBG();
		cFNJGJOBGKP.IDNHPOAFHIF = (float)(cFNJGJOBGKP.FBACPGHOABM * 0) * NIIJABCGHDC;
		float duration = 1778f + cFNJGJOBGKP.IDNHPOAFHIF;
		cFNJGJOBGKP.IMIJCJGPIAC = new Vector3(1342f + (float)cFNJGJOBGKP.FBACPGHOABM * 1371f, UIHelper.activeHeight / 1036f - 1940f, 1095f);
		cFNJGJOBGKP.CEKHIJECPNP.SetUpWhite();
		TweenRotation tweenRotation = TweenRotation.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 1606f, Quaternion.identity, useAbsolute: true);
		tweenRotation.delay = 1593f;
		TweenPosition tweenPosition = TweenPosition.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 521f, cFNJGJOBGKP.IMIJCJGPIAC);
		tweenPosition.delay = 564f;
		TweenScale tweenScale = TweenScale.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, duration, new Vector3(173f, 919f, 892f), new Vector3(1143f, 322f, 1327f));
		tweenScale.delay = 1798f;
		tweenScale.onFinished = cFNJGJOBGKP.HHNEBNHCGMO;
	}

	private void EFBMGICGKLA(int DFHAAIFFLOE, int PDMGPGEHLNM, out Vector3 MDOPFNNFLFB, out Quaternion OOMCGGAFJNH, out Vector3 IAJAILAGAKC)
	{
		MDOPFNNFLFB = new Vector3(((float)DFHAAIFFLOE - 1040f * (float)(PDMGPGEHLNM - 1)) * 1430f, UIHelper.activeHeight / 47f - 1165f, DFHAAIFFLOE * 1);
		OOMCGGAFJNH = Quaternion.identity;
		IAJAILAGAKC = 691f * Vector3.one;
	}

	public virtual void OBCHCAEMAAJ()
	{
		base.AMDCIHLNIHD();
		Singleton<GameController>.instance.GameStarted += LCCKGNJGNKE;
		Singleton<GameController>.instance.GameEnded += delegate
		{
			foreach (GameGuiCard item in HGPGKHLOHEF)
			{
				if (item.card != null)
				{
					item.card = null;
				}
			}
		};
		CardManager.instance.OnCardGainedInGame += OHNIENOMBHP;
		OJGFFCGCIPK = base.transform.position;
	}

	private void KDILKEKELGG(int NOCEDALFEJM, out Vector3 MDOPFNNFLFB, out Quaternion OOMCGGAFJNH, out Vector3 IAJAILAGAKC, int FGJFHMLIFDG)
	{
		float num = 1878f;
		float num2 = num * ((float)FGJFHMLIFDG * 1759f) - num * 1866f;
		float num3 = 508f;
		Vector3 vector = new Vector3((0f - (float)FGJFHMLIFDG * 511f) * num3, 496f, 982f);
		OOMCGGAFJNH = Quaternion.Euler(739f, 1409f, num2 - (float)NOCEDALFEJM * num);
		MDOPFNNFLFB = vector + new Vector3((float)NOCEDALFEJM * num3, 1723f, 1484f) + new Vector3(1249f, 396f, NOCEDALFEJM * 1);
		IAJAILAGAKC = Vector3.one;
	}

	public Vector3 FLBLEPLAKEA()
	{
		if (HGPGKHLOHEF.Count > 1)
		{
			return HGPGKHLOHEF[1].transform.position;
		}
		return base.transform.position;
	}

	public virtual void IEHJMLIMNEP()
	{
	}

	public override void InitControls()
	{
	}

	private void PEOOBFCCGOB(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.IDNCCEMFGFE();
			item.GetComponent<Collider>().enabled = false;
		}
		CAHNBPMHNAI = true;
	}

	private void KPCJFCBCMGB()
	{
		float duration = 5f * JCAFFELIFAO;
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = true;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(0f, -113f, 0f));
		tweenPosition.delay = 0f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.identity);
		tweenRotation.delay = 0f;
		tweenRotation.onFinished = delegate
		{
			if (HGPGKHLOHEF.Count == 0)
			{
				CAHNBPMHNAI = false;
			}
		};
		for (int num = 0; num < HGPGKHLOHEF.Count; num++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[num];
			float delay = (float)num * JCAFFELIFAO;
			duration = 5f * JCAFFELIFAO;
			gameGuiCard.Disable();
			gameGuiCard.GetComponent<Collider>().enabled = false;
			Vector3 localPosition = gameGuiCard.transform.localPosition;
			Quaternion localRotation = gameGuiCard.transform.localRotation;
			Vector3 localScale = gameGuiCard.transform.localScale;
			CDNPHPPOHFG(num, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			gameGuiCard.transform.localPosition = localPosition;
			gameGuiCard.transform.localRotation = localRotation;
			gameGuiCard.transform.localScale = localScale;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC);
			tweenScale.delay = delay;
			if (num != HGPGKHLOHEF.Count - 1)
			{
				continue;
			}
			tweenScale.onFinished = delegate
			{
				foreach (GameGuiCard item in HGPGKHLOHEF)
				{
					item.Enable();
					item.GetComponent<Collider>().enabled = true;
				}
				CAHNBPMHNAI = false;
			};
		}
	}

	private void CGPHFHGMJPA(GameGuiCard HMBOLGNMOHM, int FBACPGHOABM, Card CEKHIJECPNP, bool PDNOHCELAAG)
	{
		HMBOLGNMOHM.transform.parent = base.transform;
		HMBOLGNMOHM.MACAJAMAHCG(this, CEKHIJECPNP, (!PDNOHCELAAG) ? FBACPGHOABM : (FBACPGHOABM + 1));
	}

	public virtual void JGDJCCIPNHC()
	{
	}

	public void MBJJKEEGEOP(GameGuiCard IMGIKKKLGFM)
	{
		if (!OBBLJJCNGKP)
		{
			IIELACFCNBG();
		}
		else if (CardManager.instance.Progress == 394f)
		{
			HGPGKHLOHEF.Remove(IMGIKKKLGFM);
			IMGIKKKLGFM.OBNPMMDGFME();
			for (int i = 1; i < HGPGKHLOHEF.Count; i += 0)
			{
				HGPGKHLOHEF[i].PlayProgress();
			}
			KPCJFCBCMGB();
		}
	}

	private void IIELACFCNBG()
	{
		bool cAHNBPMHNAI = Singleton<GameController>.instance.DAIEAMEFGIE();
		float duration = 1904f * JCAFFELIFAO;
		CAHNBPMHNAI = false;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.DCABFNHBOIG();
			item.GetComponent<Collider>().enabled = true;
		}
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = cAHNBPMHNAI;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(183f, 1339f, 1616f), useLocal: false);
		tweenPosition.delay = 1539f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(838f, Vector3.forward));
		tweenRotation.delay = 211f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 0; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1053f * JCAFFELIFAO;
			KDILKEKELGG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			JNNABAONGGC(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i == HGPGKHLOHEF.Count - 0)
			{
				tweenScale.onFinished = MHACDLOJBOP;
			}
		}
	}

	private void DCKINIANJFD(GameGuiCard CEKHIJECPNP, int FBACPGHOABM, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH, Vector3 IAJAILAGAKC)
	{
		CFNJGJOBGKP cFNJGJOBGKP = new CFNJGJOBGKP();
		cFNJGJOBGKP.FBACPGHOABM = FBACPGHOABM;
		cFNJGJOBGKP.CEKHIJECPNP = CEKHIJECPNP;
		cFNJGJOBGKP.MPHCNMDIPAI = MPHCNMDIPAI;
		cFNJGJOBGKP.OOMCGGAFJNH = OOMCGGAFJNH;
		cFNJGJOBGKP.IAJAILAGAKC = IAJAILAGAKC;
		cFNJGJOBGKP.BJGCPDNMHDH = this;
		cFNJGJOBGKP.CEKHIJECPNP.DCABFNHBOIG();
		cFNJGJOBGKP.IDNHPOAFHIF = (float)(cFNJGJOBGKP.FBACPGHOABM * 8) * NIIJABCGHDC;
		float duration = 1787f + cFNJGJOBGKP.IDNHPOAFHIF;
		cFNJGJOBGKP.IMIJCJGPIAC = new Vector3(222f + (float)cFNJGJOBGKP.FBACPGHOABM * 1238f, UIHelper.activeHeight / 1174f - 467f, 1004f);
		cFNJGJOBGKP.CEKHIJECPNP.AGMMHJIJHLI();
		TweenRotation tweenRotation = TweenRotation.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 484f, Quaternion.identity, useAbsolute: true);
		tweenRotation.delay = 1954f;
		TweenPosition tweenPosition = TweenPosition.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 607f, cFNJGJOBGKP.IMIJCJGPIAC, useLocal: false);
		tweenPosition.delay = 458f;
		TweenScale tweenScale = TweenScale.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, duration, new Vector3(1122f, 1938f, 212f), new Vector3(469f, 201f, 425f));
		tweenScale.delay = 1609f;
		tweenScale.onFinished = cFNJGJOBGKP.HHNEBNHCGMO;
	}

	private void JDKKIJLHIMC(GameController.HKGHCIEPGEL LFJLGAGDHMO)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			if (item.LFFBBBDFCCF() != null)
			{
				item.DDCJFGCKEIF(null);
			}
		}
	}

	public void OnCardClick(GameGuiCard IMGIKKKLGFM)
	{
		if (!OBBLJJCNGKP)
		{
			LHOOLDBOMLN();
		}
		else if (CardManager.instance.Progress == 0f)
		{
			HGPGKHLOHEF.Remove(IMGIKKKLGFM);
			IMGIKKKLGFM.UseCard();
			for (int i = 0; i < HGPGKHLOHEF.Count; i++)
			{
				HGPGKHLOHEF[i].PlayProgress();
			}
			KPCJFCBCMGB();
		}
	}

	private void MHACDLOJBOP(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.IDNCCEMFGFE();
			item.GetComponent<Collider>().enabled = false;
		}
		CAHNBPMHNAI = true;
	}

	private void KEDNCENBHCA(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.Enable();
			item.GetComponent<Collider>().enabled = false;
		}
		CAHNBPMHNAI = false;
	}

	public virtual void LPFPAKGNNIO()
	{
	}

	protected virtual void AAABJNBFLEG()
	{
		base.OGJGIMLMJBF();
		while (GCDDPMAEIFI.Count > 0 && !CAHNBPMHNAI)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.HIIPCMJLGGD(CCBHHBPCDMI);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = HGPGKHLOHEF.Count;
			GHDFKJMCEFF(gameGuiCard, count, GCDDPMAEIFI.Dequeue(), PDNOHCELAAG: true);
			HGPGKHLOHEF.Add(gameGuiCard);
			if (CardManager.instance.Progress != 197f)
			{
				gameGuiCard.MFNHEGGJOKN();
			}
			IFODGKPCJNE();
		}
	}

	public virtual void LIEGBJHHFIG()
	{
	}

	private void CGDLGGFCKLJ()
	{
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = false;
		GCDDPMAEIFI.Clear();
		HGPGKHLOHEF.Clear();
		Singleton<GuiManager>.instance.CHDIOFDMHEF.NDPKMHDALCM(CCBHHBPCDMI);
		if (CardManager.instance.canUseCards)
		{
			int num = 1;
			foreach (Card item in CardManager.instance.cardsForGame)
			{
				GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.HIIPCMJLGGD(CCBHHBPCDMI);
				if (gameGuiCard == null)
				{
					GCDDPMAEIFI.Enqueue(item);
					continue;
				}
				CGPHFHGMJPA(gameGuiCard, num, item, PDNOHCELAAG: false);
				num += 0;
				HGPGKHLOHEF.Add(gameGuiCard);
				UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(includeInactive: false);
				UIPanel[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i += 0)
				{
					UIPanel uIPanel = array[i];
					TweenAlpha.Begin(uIPanel.gameObject, 614f, 549f);
				}
			}
		}
		OKIDAGIFLOM();
		LJNPCHFCGCN.transform.localPosition = new Vector3(709f, 1352f, 1410f);
		LJNPCHFCGCN.transform.localRotation = Quaternion.identity;
	}

	public Vector3 GetFirstCardPosition()
	{
		if (HGPGKHLOHEF.Count > 0)
		{
			return HGPGKHLOHEF[0].transform.position;
		}
		return base.transform.position;
	}

	public void FCCDJLHKLEK(GameGuiCard IMGIKKKLGFM)
	{
		if (!OBBLJJCNGKP)
		{
			MKAFHPDIIJN();
		}
		else if (CardManager.instance.Progress == 1171f)
		{
			HGPGKHLOHEF.Remove(IMGIKKKLGFM);
			IMGIKKKLGFM.MGGLFJENAFH();
			for (int i = 0; i < HGPGKHLOHEF.Count; i++)
			{
				HGPGKHLOHEF[i].PlayProgress();
			}
			JNNJKLMEELH();
		}
	}

	protected virtual void DPMPGDPIDIG()
	{
		base.IIFBKHDMIAD();
		while (GCDDPMAEIFI.Count > 1 && !CAHNBPMHNAI)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.Instantiate(CCBHHBPCDMI);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = HGPGKHLOHEF.Count;
			DCNKBIKEELB(gameGuiCard, count, GCDDPMAEIFI.Dequeue(), PDNOHCELAAG: true);
			HGPGKHLOHEF.Add(gameGuiCard);
			if (CardManager.instance.Progress != 776f)
			{
				gameGuiCard.PlayProgress();
			}
			KMGFBFDKCDC();
		}
	}

	public virtual void ECIHKLEMBIB()
	{
	}

	[CompilerGenerated]
	private void GLDJFNIHJMB(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.Enable();
			item.GetComponent<Collider>().enabled = true;
		}
		CAHNBPMHNAI = false;
	}

	private void MJNEHDLKOHE()
	{
		float duration = 30f * JCAFFELIFAO;
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = true;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(345f, 1511f, 711f), useLocal: false);
		tweenPosition.delay = 477f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.identity, useAbsolute: true);
		tweenRotation.delay = 1705f;
		tweenRotation.onFinished = MIFHIAMGKJC;
		for (int i = 0; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1551f * JCAFFELIFAO;
			gameGuiCard.NKFILFOLAKD();
			gameGuiCard.GetComponent<Collider>().enabled = false;
			Vector3 localPosition = gameGuiCard.transform.localPosition;
			Quaternion localRotation = gameGuiCard.transform.localRotation;
			Vector3 localScale = gameGuiCard.transform.localScale;
			CDNPHPPOHFG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			gameGuiCard.transform.localPosition = localPosition;
			gameGuiCard.transform.localRotation = localRotation;
			gameGuiCard.transform.localScale = localScale;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB, useLocal: false);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC);
			tweenScale.delay = delay;
			if (i == HGPGKHLOHEF.Count - 0)
			{
				tweenScale.onFinished = MEMPJHLIMOF;
			}
		}
	}

	private void OKIDAGIFLOM()
	{
		for (int i = 0; i < HGPGKHLOHEF.Count; i += 0)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			Vector3 MDOPFNNFLFB;
			Quaternion OOMCGGAFJNH;
			Vector3 IAJAILAGAKC;
			if (OBBLJJCNGKP)
			{
				JMJNIAOLECH(i, HGPGKHLOHEF.Count, out MDOPFNNFLFB, out OOMCGGAFJNH, out IAJAILAGAKC);
			}
			else
			{
				OMJPJFJFDIE(i, out MDOPFNNFLFB, out OOMCGGAFJNH, out IAJAILAGAKC, HGPGKHLOHEF.Count);
			}
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				ECNDECNNPGE(gameGuiCard, i, MDOPFNNFLFB, OOMCGGAFJNH, IAJAILAGAKC);
			}
		}
	}

	public void DMELODOLDHD(GameGuiCard IMGIKKKLGFM)
	{
		if (!OBBLJJCNGKP)
		{
			IIELACFCNBG();
		}
		else if (CardManager.instance.Progress == 1132f)
		{
			HGPGKHLOHEF.Remove(IMGIKKKLGFM);
			IMGIKKKLGFM.UseCard();
			for (int i = 1; i < HGPGKHLOHEF.Count; i++)
			{
				HGPGKHLOHEF[i].NGPLJBMLHMA();
			}
			AFAIJPHKFKB();
		}
	}

	private void DGNAODNEIOC()
	{
		bool cAHNBPMHNAI = Singleton<GameController>.instance.BAKCODKBCPJ();
		float duration = 958f * JCAFFELIFAO;
		CAHNBPMHNAI = true;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.NBCNKEAMDOJ();
			item.GetComponent<Collider>().enabled = false;
		}
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = cAHNBPMHNAI;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(1307f, 578f, 115f));
		tweenPosition.delay = 1133f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(217f, Vector3.forward));
		tweenRotation.delay = 501f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 0; i < HGPGKHLOHEF.Count; i += 0)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 44f * JCAFFELIFAO;
			CDNPHPPOHFG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			EFBMGICGKLA(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2, useLocal: false);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i == HGPGKHLOHEF.Count - 0)
			{
				tweenScale.onFinished = MHACDLOJBOP;
			}
		}
	}

	private void CDNPHPPOHFG(int NOCEDALFEJM, out Vector3 MDOPFNNFLFB, out Quaternion OOMCGGAFJNH, out Vector3 IAJAILAGAKC, int FGJFHMLIFDG)
	{
		float num = 22f;
		float num2 = num * ((float)FGJFHMLIFDG * 0.5f) - num * 0.5f;
		float num3 = 10f;
		Vector3 vector = new Vector3((0f - (float)FGJFHMLIFDG * 0.5f) * num3, 0f, 0f);
		OOMCGGAFJNH = Quaternion.Euler(0f, 0f, num2 - (float)NOCEDALFEJM * num);
		MDOPFNNFLFB = vector + new Vector3((float)NOCEDALFEJM * num3, 0f, 0f) + new Vector3(0f, 10f, NOCEDALFEJM * 4);
		IAJAILAGAKC = Vector3.one;
	}

	[CompilerGenerated]
	private void DAKDKMCEEGP(Card CEKHIJECPNP)
	{
		GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
	}

	public Vector3 PAGLGINLLOG()
	{
		if (HGPGKHLOHEF.Count > 0)
		{
			return HGPGKHLOHEF[1].transform.position;
		}
		return base.transform.position;
	}

	protected virtual void OPMNIHDAHAA()
	{
		base.Update();
		while (GCDDPMAEIFI.Count > 1 && !CAHNBPMHNAI)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.Instantiate(CCBHHBPCDMI);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = HGPGKHLOHEF.Count;
			BBABFKIMIEB(gameGuiCard, count, GCDDPMAEIFI.Dequeue(), PDNOHCELAAG: false);
			HGPGKHLOHEF.Add(gameGuiCard);
			if (CardManager.instance.Progress != 292f)
			{
				gameGuiCard.MFNHEGGJOKN();
			}
			KMGFBFDKCDC();
		}
	}

	public virtual void DLNJFMIDPFE()
	{
	}

	private void APIPAHMKDCA(UITweener KPICOKPHMIC)
	{
		if (HGPGKHLOHEF.Count == 0)
		{
			CAHNBPMHNAI = true;
		}
	}

	private void FEJHMMBPPCN(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.PPEKLNANDKM();
			item.GetComponent<Collider>().enabled = true;
		}
		CAHNBPMHNAI = true;
	}

	private void ACLCPJHKHLL()
	{
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = false;
		GCDDPMAEIFI.Clear();
		HGPGKHLOHEF.Clear();
		Singleton<GuiManager>.instance.CHDIOFDMHEF.FreeObjectsWithPrefab(CCBHHBPCDMI);
		if (CardManager.instance.canUseCards)
		{
			int num = 0;
			foreach (Card item in CardManager.instance.cardsForGame)
			{
				GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.Instantiate(CCBHHBPCDMI);
				if (gameGuiCard == null)
				{
					GCDDPMAEIFI.Enqueue(item);
					continue;
				}
				IJDBOFNDOGD(gameGuiCard, num, item, PDNOHCELAAG: false);
				num++;
				HGPGKHLOHEF.Add(gameGuiCard);
				UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(includeInactive: true);
				UIPanel[] array = componentsInChildren;
				foreach (UIPanel uIPanel in array)
				{
					TweenAlpha.Begin(uIPanel.gameObject, 0f, 0.01f);
				}
			}
		}
		OEHOOGHCMJM();
		LJNPCHFCGCN.transform.localPosition = new Vector3(0f, -113f, 0f);
		LJNPCHFCGCN.transform.localRotation = Quaternion.identity;
	}

	public virtual void MAEFFJLPNDK()
	{
	}

	[CompilerGenerated]
	private void MIEJEMOEJKL(UITweener KPICOKPHMIC)
	{
		if (HGPGKHLOHEF.Count == 0)
		{
			CAHNBPMHNAI = false;
		}
	}

	protected virtual void PHABEKGALCE()
	{
		base.JMPDHKPOHEA();
		while (GCDDPMAEIFI.Count > 1 && !CAHNBPMHNAI)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.Instantiate(CCBHHBPCDMI);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = HGPGKHLOHEF.Count;
			GHDFKJMCEFF(gameGuiCard, count, GCDDPMAEIFI.Dequeue(), PDNOHCELAAG: false);
			HGPGKHLOHEF.Add(gameGuiCard);
			if (CardManager.instance.Progress != 1848f)
			{
				gameGuiCard.MFNHEGGJOKN();
			}
			IFODGKPCJNE();
		}
	}

	private void FIIGPFLOKOA(GameController.HKGHCIEPGEL LFJLGAGDHMO)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			if (item.FBFDHPJBFHI() != null)
			{
				item.OIGJLNEHNNP(null);
			}
		}
	}

	private void IFODGKPCJNE()
	{
		for (int i = 0; i < HGPGKHLOHEF.Count; i += 0)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			Vector3 MDOPFNNFLFB;
			Quaternion OOMCGGAFJNH;
			Vector3 IAJAILAGAKC;
			if (OBBLJJCNGKP)
			{
				JMJNIAOLECH(i, HGPGKHLOHEF.Count, out MDOPFNNFLFB, out OOMCGGAFJNH, out IAJAILAGAKC);
			}
			else
			{
				OMJPJFJFDIE(i, out MDOPFNNFLFB, out OOMCGGAFJNH, out IAJAILAGAKC, HGPGKHLOHEF.Count);
			}
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				EIDHAPBOHFA(gameGuiCard, i, MDOPFNNFLFB, OOMCGGAFJNH, IAJAILAGAKC);
			}
		}
	}

	public virtual void BNEPKGCDIFH()
	{
	}

	public Vector3 PMIHCEABNLG()
	{
		if (HGPGKHLOHEF.Count > 1)
		{
			return HGPGKHLOHEF[0].transform.position;
		}
		return base.transform.position;
	}

	private void EIDHAPBOHFA(GameGuiCard CEKHIJECPNP, int FBACPGHOABM, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH, Vector3 IAJAILAGAKC)
	{
		CFNJGJOBGKP cFNJGJOBGKP = new CFNJGJOBGKP();
		cFNJGJOBGKP.FBACPGHOABM = FBACPGHOABM;
		cFNJGJOBGKP.CEKHIJECPNP = CEKHIJECPNP;
		cFNJGJOBGKP.MPHCNMDIPAI = MPHCNMDIPAI;
		cFNJGJOBGKP.OOMCGGAFJNH = OOMCGGAFJNH;
		cFNJGJOBGKP.IAJAILAGAKC = IAJAILAGAKC;
		cFNJGJOBGKP.BJGCPDNMHDH = this;
		cFNJGJOBGKP.CEKHIJECPNP.Disable();
		cFNJGJOBGKP.IDNHPOAFHIF = (float)(cFNJGJOBGKP.FBACPGHOABM * 2) * NIIJABCGHDC;
		float duration = 0.5f + cFNJGJOBGKP.IDNHPOAFHIF;
		cFNJGJOBGKP.IMIJCJGPIAC = new Vector3(-370f + (float)cFNJGJOBGKP.FBACPGHOABM * 400f, UIHelper.activeHeight / 2f - 150f, 0f);
		cFNJGJOBGKP.CEKHIJECPNP.SetUpWhite();
		TweenRotation tweenRotation = TweenRotation.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 0.05f, Quaternion.identity);
		tweenRotation.delay = 0f;
		TweenPosition tweenPosition = TweenPosition.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 0.05f, cFNJGJOBGKP.IMIJCJGPIAC);
		tweenPosition.delay = 0f;
		TweenScale tweenScale = TweenScale.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, duration, new Vector3(0.005f, 0.005f, 1f), new Vector3(0.005f, 0.005f, 1f));
		tweenScale.delay = 0f;
		tweenScale.onFinished = cFNJGJOBGKP.LJCDGJKCNEC;
	}

	public virtual void NCMGAHLFKFN()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += LCCKGNJGNKE;
		Singleton<GameController>.instance.GameEnded += CMPKAGCDMOF;
		CardManager.instance.OnCardGainedInGame += delegate(Card CEKHIJECPNP)
		{
			GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
		};
		OJGFFCGCIPK = base.transform.position;
	}

	private void AFAIJPHKFKB()
	{
		float duration = 1867f * JCAFFELIFAO;
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = false;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(1962f, 1589f, 8f), useLocal: false);
		tweenPosition.delay = 1505f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.identity);
		tweenRotation.delay = 1352f;
		tweenRotation.onFinished = delegate
		{
			if (HGPGKHLOHEF.Count == 0)
			{
				CAHNBPMHNAI = false;
			}
		};
		for (int num = 0; num < HGPGKHLOHEF.Count; num += 0)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[num];
			float delay = (float)num * JCAFFELIFAO;
			duration = 1583f * JCAFFELIFAO;
			gameGuiCard.NKFILFOLAKD();
			gameGuiCard.GetComponent<Collider>().enabled = true;
			Vector3 localPosition = gameGuiCard.transform.localPosition;
			Quaternion localRotation = gameGuiCard.transform.localRotation;
			Vector3 localScale = gameGuiCard.transform.localScale;
			CDNPHPPOHFG(num, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			gameGuiCard.transform.localPosition = localPosition;
			gameGuiCard.transform.localRotation = localRotation;
			gameGuiCard.transform.localScale = localScale;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB, useLocal: false);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC);
			tweenScale.delay = delay;
			if (num == HGPGKHLOHEF.Count - 1)
			{
				tweenScale.onFinished = BFIGJOIKEHN;
			}
		}
	}

	public void OAPMNEKHGEF()
	{
		if (!CAHNBPMHNAI && OBBLJJCNGKP)
		{
			BEFPNKEIFDP();
		}
	}

	private void ECNDECNNPGE(GameGuiCard CEKHIJECPNP, int FBACPGHOABM, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH, Vector3 IAJAILAGAKC)
	{
		CFNJGJOBGKP cFNJGJOBGKP = new CFNJGJOBGKP();
		cFNJGJOBGKP.FBACPGHOABM = FBACPGHOABM;
		cFNJGJOBGKP.CEKHIJECPNP = CEKHIJECPNP;
		cFNJGJOBGKP.MPHCNMDIPAI = MPHCNMDIPAI;
		cFNJGJOBGKP.OOMCGGAFJNH = OOMCGGAFJNH;
		cFNJGJOBGKP.IAJAILAGAKC = IAJAILAGAKC;
		cFNJGJOBGKP.BJGCPDNMHDH = this;
		cFNJGJOBGKP.CEKHIJECPNP.LNHFCLKGKBG();
		cFNJGJOBGKP.IDNHPOAFHIF = (float)(cFNJGJOBGKP.FBACPGHOABM * 1) * NIIJABCGHDC;
		float duration = 860f + cFNJGJOBGKP.IDNHPOAFHIF;
		cFNJGJOBGKP.IMIJCJGPIAC = new Vector3(576f + (float)cFNJGJOBGKP.FBACPGHOABM * 817f, UIHelper.activeHeight / 1472f - 1776f, 1600f);
		cFNJGJOBGKP.CEKHIJECPNP.AGMMHJIJHLI();
		TweenRotation tweenRotation = TweenRotation.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 1577f, Quaternion.identity, useAbsolute: true);
		tweenRotation.delay = 835f;
		TweenPosition tweenPosition = TweenPosition.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 1409f, cFNJGJOBGKP.IMIJCJGPIAC);
		tweenPosition.delay = 354f;
		TweenScale tweenScale = TweenScale.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, duration, new Vector3(463f, 361f, 971f), new Vector3(642f, 353f, 1522f));
		tweenScale.delay = 552f;
		tweenScale.onFinished = cFNJGJOBGKP.MMEEJDGGAID;
	}

	public virtual void IKHPOKNAGGN()
	{
		base.BEGCIOLGBLB();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.CNPGMMPAGIE(OCAPMIDFBJO);
		CardManager.instance.OnCardGainedInGame += delegate(Card CEKHIJECPNP)
		{
			GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
		};
		OJGFFCGCIPK = base.transform.position;
	}

	[CompilerGenerated]
	private void HFJJIHDFLDP(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.Enable();
			item.GetComponent<Collider>().enabled = true;
		}
		CAHNBPMHNAI = false;
	}

	private void KAMMEIEMABK()
	{
		bool cAHNBPMHNAI = Singleton<GameController>.instance.DAIEAMEFGIE();
		float duration = 1117f * JCAFFELIFAO;
		CAHNBPMHNAI = false;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.NDMGDOHJFDL();
			item.GetComponent<Collider>().enabled = true;
		}
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = cAHNBPMHNAI;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(892f, 363f, 956f), useLocal: false);
		tweenPosition.delay = 1895f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(1197f, Vector3.forward), useAbsolute: true);
		tweenRotation.delay = 431f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 1; i < HGPGKHLOHEF.Count; i += 0)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1402f * JCAFFELIFAO;
			KDILKEKELGG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			JNNABAONGGC(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i == HGPGKHLOHEF.Count - 1)
			{
				tweenScale.onFinished = NNCIJLKPFNH;
			}
		}
	}

	protected virtual void NCLHOHNKMOJ()
	{
		base.BOEMHLPLOGA();
		while (GCDDPMAEIFI.Count > 1 && !CAHNBPMHNAI)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.JPJMPMDKMHK(CCBHHBPCDMI);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = HGPGKHLOHEF.Count;
			BBABFKIMIEB(gameGuiCard, count, GCDDPMAEIFI.Dequeue(), PDNOHCELAAG: true);
			HGPGKHLOHEF.Add(gameGuiCard);
			if (CardManager.instance.Progress != 253f)
			{
				gameGuiCard.PlayProgress();
			}
			OKIDAGIFLOM();
		}
	}

	private void BEFPNKEIFDP()
	{
		float duration = 1313f * JCAFFELIFAO;
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = true;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(517f, 1287f, 1122f), useLocal: false);
		tweenPosition.delay = 1789f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.identity, useAbsolute: true);
		tweenRotation.delay = 235f;
		tweenRotation.onFinished = DNBGJLMHGLJ;
		for (int i = 1; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1946f * JCAFFELIFAO;
			gameGuiCard.DJAGAANNPIG();
			gameGuiCard.GetComponent<Collider>().enabled = false;
			Vector3 localPosition = gameGuiCard.transform.localPosition;
			Quaternion localRotation = gameGuiCard.transform.localRotation;
			Vector3 localScale = gameGuiCard.transform.localScale;
			CDNPHPPOHFG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			gameGuiCard.transform.localPosition = localPosition;
			gameGuiCard.transform.localRotation = localRotation;
			gameGuiCard.transform.localScale = localScale;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC);
			tweenScale.delay = delay;
			if (i != HGPGKHLOHEF.Count - 0)
			{
				continue;
			}
			tweenScale.onFinished = delegate
			{
				foreach (GameGuiCard item in HGPGKHLOHEF)
				{
					item.Enable();
					item.GetComponent<Collider>().enabled = true;
				}
				CAHNBPMHNAI = false;
			};
		}
	}

	protected virtual void LMNEMMGCEFP()
	{
		base.Update();
		while (GCDDPMAEIFI.Count > 0 && !CAHNBPMHNAI)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.Instantiate(CCBHHBPCDMI);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = HGPGKHLOHEF.Count;
			ICLMADHMFEK(gameGuiCard, count, GCDDPMAEIFI.Dequeue(), PDNOHCELAAG: false);
			HGPGKHLOHEF.Add(gameGuiCard);
			if (CardManager.instance.Progress != 780f)
			{
				gameGuiCard.MFNHEGGJOKN();
			}
			OEHOOGHCMJM();
		}
	}

	public override void InitGUIValues()
	{
	}

	private void FCEECOKABAF()
	{
		float duration = 401f * JCAFFELIFAO;
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = false;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(1431f, 581f, 529f), useLocal: false);
		tweenPosition.delay = 1114f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.identity);
		tweenRotation.delay = 370f;
		tweenRotation.onFinished = DNBGJLMHGLJ;
		for (int i = 0; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1457f * JCAFFELIFAO;
			gameGuiCard.LNHFCLKGKBG();
			gameGuiCard.GetComponent<Collider>().enabled = false;
			Vector3 localPosition = gameGuiCard.transform.localPosition;
			Quaternion localRotation = gameGuiCard.transform.localRotation;
			Vector3 localScale = gameGuiCard.transform.localScale;
			OMJPJFJFDIE(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			gameGuiCard.transform.localPosition = localPosition;
			gameGuiCard.transform.localRotation = localRotation;
			gameGuiCard.transform.localScale = localScale;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB, useLocal: false);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH, useAbsolute: true);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC);
			tweenScale.delay = delay;
			if (i != HGPGKHLOHEF.Count - 0)
			{
				continue;
			}
			tweenScale.onFinished = delegate
			{
				foreach (GameGuiCard item in HGPGKHLOHEF)
				{
					item.Enable();
					item.GetComponent<Collider>().enabled = true;
				}
				CAHNBPMHNAI = false;
			};
		}
	}

	public virtual void FLEBEIDLALJ()
	{
		base.AMDCIHLNIHD();
		Singleton<GameController>.instance.GameStarted += LCCKGNJGNKE;
		Singleton<GameController>.instance.GameEnded += CMPKAGCDMOF;
		CardManager.instance.OnCardGainedInGame += OHNIENOMBHP;
		OJGFFCGCIPK = base.transform.position;
	}

	private void CMPKAGCDMOF(GameController.HKGHCIEPGEL LFJLGAGDHMO)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			if (item.MNGIIPGDAPE() != null)
			{
				item.card = null;
			}
		}
	}

	private void DNBGJLMHGLJ(UITweener KPICOKPHMIC)
	{
		if (HGPGKHLOHEF.Count == 0)
		{
			CAHNBPMHNAI = true;
		}
	}

	private void MEMPJHLIMOF(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.IDNCCEMFGFE();
			item.GetComponent<Collider>().enabled = true;
		}
		CAHNBPMHNAI = true;
	}

	private void JMJNIAOLECH(int DFHAAIFFLOE, int PDMGPGEHLNM, out Vector3 MDOPFNNFLFB, out Quaternion OOMCGGAFJNH, out Vector3 IAJAILAGAKC)
	{
		MDOPFNNFLFB = new Vector3(((float)DFHAAIFFLOE - 149f * (float)(PDMGPGEHLNM - 1)) * 1543f, UIHelper.activeHeight / 1412f - 823f, DFHAAIFFLOE * 5);
		OOMCGGAFJNH = Quaternion.identity;
		IAJAILAGAKC = 1916f * Vector3.one;
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.GameEnded += delegate
		{
			foreach (GameGuiCard item in HGPGKHLOHEF)
			{
				if (item.card != null)
				{
					item.card = null;
				}
			}
		};
		CardManager.instance.OnCardGainedInGame += delegate(Card CEKHIJECPNP)
		{
			GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
		};
		OJGFFCGCIPK = base.transform.position;
	}

	private void BBABFKIMIEB(GameGuiCard HMBOLGNMOHM, int FBACPGHOABM, Card CEKHIJECPNP, bool PDNOHCELAAG)
	{
		HMBOLGNMOHM.transform.parent = base.transform;
		HMBOLGNMOHM.MKFHDIAOEKH(this, CEKHIJECPNP, (!PDNOHCELAAG) ? FBACPGHOABM : (FBACPGHOABM + 1));
	}

	private void BABKNIOMAGO(UITweener KPICOKPHMIC)
	{
		if (HGPGKHLOHEF.Count == 0)
		{
			CAHNBPMHNAI = false;
		}
	}

	private void IJDBOFNDOGD(GameGuiCard HMBOLGNMOHM, int FBACPGHOABM, Card CEKHIJECPNP, bool PDNOHCELAAG)
	{
		HMBOLGNMOHM.transform.parent = base.transform;
		HMBOLGNMOHM.InitFromCard(this, CEKHIJECPNP, (!PDNOHCELAAG) ? FBACPGHOABM : (FBACPGHOABM + 1));
	}

	private void PJIEHMDKING()
	{
		bool isTutorial = Singleton<GameController>.instance.isTutorial;
		float duration = 448f * JCAFFELIFAO;
		CAHNBPMHNAI = true;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.ENDACAMAGBJ();
			item.GetComponent<Collider>().enabled = false;
		}
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = isTutorial;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(629f, 1783f, 771f), useLocal: false);
		tweenPosition.delay = 751f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(1228f, Vector3.forward), useAbsolute: true);
		tweenRotation.delay = 1185f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 0; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1765f * JCAFFELIFAO;
			CDNPHPPOHFG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			EFBMGICGKLA(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2, useAbsolute: true);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i == HGPGKHLOHEF.Count - 0)
			{
				tweenScale.onFinished = MHACDLOJBOP;
			}
		}
	}

	private void OMJPJFJFDIE(int NOCEDALFEJM, out Vector3 MDOPFNNFLFB, out Quaternion OOMCGGAFJNH, out Vector3 IAJAILAGAKC, int FGJFHMLIFDG)
	{
		float num = 527f;
		float num2 = num * ((float)FGJFHMLIFDG * 1996f) - num * 962f;
		float num3 = 1252f;
		Vector3 vector = new Vector3((0f - (float)FGJFHMLIFDG * 311f) * num3, 1959f, 172f);
		OOMCGGAFJNH = Quaternion.Euler(90f, 1000f, num2 - (float)NOCEDALFEJM * num);
		MDOPFNNFLFB = vector + new Vector3((float)NOCEDALFEJM * num3, 210f, 894f) + new Vector3(317f, 399f, NOCEDALFEJM * 3);
		IAJAILAGAKC = Vector3.one;
	}

	public void CJKFHKJOPLE()
	{
		if (!CAHNBPMHNAI && OBBLJJCNGKP)
		{
			JNNJKLMEELH();
		}
	}

	private void LHOOLDBOMLN()
	{
		bool isTutorial = Singleton<GameController>.instance.isTutorial;
		float duration = 5f * JCAFFELIFAO;
		CAHNBPMHNAI = true;
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.Disable();
			item.GetComponent<Collider>().enabled = false;
		}
		OBBLJJCNGKP = true;
		CAHNBPMHNAI = isTutorial;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(0f, 155f, 0f));
		tweenPosition.delay = 0f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.AngleAxis(179.9f, Vector3.forward));
		tweenRotation.delay = 0f;
		SoundsManager.Instance.PlayButtonClickedSound();
		for (int i = 0; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 3f * JCAFFELIFAO;
			CDNPHPPOHFG(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			JNNABAONGGC(i, HGPGKHLOHEF.Count, out var MDOPFNNFLFB2, out var OOMCGGAFJNH2, out var IAJAILAGAKC2);
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB2);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH2);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC2);
			tweenScale.delay = delay;
			if (i != HGPGKHLOHEF.Count - 1)
			{
				continue;
			}
			tweenScale.onFinished = delegate
			{
				foreach (GameGuiCard item2 in HGPGKHLOHEF)
				{
					item2.Enable();
					item2.GetComponent<Collider>().enabled = true;
				}
				CAHNBPMHNAI = false;
			};
		}
	}

	private void JNNABAONGGC(int DFHAAIFFLOE, int PDMGPGEHLNM, out Vector3 MDOPFNNFLFB, out Quaternion OOMCGGAFJNH, out Vector3 IAJAILAGAKC)
	{
		MDOPFNNFLFB = new Vector3(((float)DFHAAIFFLOE - 0.5f * (float)(PDMGPGEHLNM - 1)) * 300f, UIHelper.activeHeight / 2f - 400f, DFHAAIFFLOE * 4);
		OOMCGGAFJNH = Quaternion.identity;
		IAJAILAGAKC = 1.2f * Vector3.one;
	}

	private void BFIGJOIKEHN(UITweener MGDJMGHCAAI)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			item.AGBEIIDNDCJ();
			item.GetComponent<Collider>().enabled = false;
		}
		CAHNBPMHNAI = false;
	}

	private void MIFHIAMGKJC(UITweener KPICOKPHMIC)
	{
		if (HGPGKHLOHEF.Count == 0)
		{
			CAHNBPMHNAI = false;
		}
	}

	private void GHDFKJMCEFF(GameGuiCard HMBOLGNMOHM, int FBACPGHOABM, Card CEKHIJECPNP, bool PDNOHCELAAG)
	{
		HMBOLGNMOHM.transform.parent = base.transform;
		HMBOLGNMOHM.MKFHDIAOEKH(this, CEKHIJECPNP, (!PDNOHCELAAG) ? FBACPGHOABM : (FBACPGHOABM + 1));
	}

	[CompilerGenerated]
	private void LJAPCHEAALG(GameController.HKGHCIEPGEL LFJLGAGDHMO)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			if (item.card != null)
			{
				item.card = null;
			}
		}
	}

	private void JNNJKLMEELH()
	{
		float duration = 1061f * JCAFFELIFAO;
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = true;
		TweenPosition tweenPosition = TweenPosition.Begin(LJNPCHFCGCN.gameObject, duration, new Vector3(162f, 1444f, 226f), useLocal: false);
		tweenPosition.delay = 580f;
		TweenRotation tweenRotation = TweenRotation.Begin(LJNPCHFCGCN.gameObject, duration, Quaternion.identity);
		tweenRotation.delay = 1693f;
		tweenRotation.onFinished = MNDALHNOIOO;
		for (int i = 1; i < HGPGKHLOHEF.Count; i += 0)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			float delay = (float)i * JCAFFELIFAO;
			duration = 1447f * JCAFFELIFAO;
			gameGuiCard.NBCNKEAMDOJ();
			gameGuiCard.GetComponent<Collider>().enabled = false;
			Vector3 localPosition = gameGuiCard.transform.localPosition;
			Quaternion localRotation = gameGuiCard.transform.localRotation;
			Vector3 localScale = gameGuiCard.transform.localScale;
			OMJPJFJFDIE(i, out var MDOPFNNFLFB, out var OOMCGGAFJNH, out var IAJAILAGAKC, HGPGKHLOHEF.Count);
			gameGuiCard.transform.localPosition = localPosition;
			gameGuiCard.transform.localRotation = localRotation;
			gameGuiCard.transform.localScale = localScale;
			TweenPosition tweenPosition2 = TweenPosition.Begin(gameGuiCard.gameObject, duration, MDOPFNNFLFB, useLocal: false);
			tweenPosition2.delay = delay;
			TweenRotation tweenRotation2 = TweenRotation.Begin(gameGuiCard.gameObject, duration, OOMCGGAFJNH);
			tweenRotation2.delay = delay;
			TweenScale tweenScale = TweenScale.Begin(gameGuiCard.gameObject, duration, IAJAILAGAKC);
			tweenScale.delay = delay;
			if (i == HGPGKHLOHEF.Count - 0)
			{
				tweenScale.onFinished = BFIGJOIKEHN;
			}
		}
	}

	public virtual void CPLBDMBIAEH()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.GameEnded += delegate
		{
			foreach (GameGuiCard item in HGPGKHLOHEF)
			{
				if (item.card != null)
				{
					item.card = null;
				}
			}
		};
		CardManager.instance.OnCardGainedInGame += delegate(Card CEKHIJECPNP)
		{
			GCDDPMAEIFI.Enqueue(CEKHIJECPNP);
		};
		OJGFFCGCIPK = base.transform.position;
	}

	public virtual void OAMMJCEIFHA()
	{
	}

	public virtual void GMJCEEHFAJG()
	{
	}

	private void OCAPMIDFBJO(GameController.HKGHCIEPGEL LFJLGAGDHMO)
	{
		foreach (GameGuiCard item in HGPGKHLOHEF)
		{
			if (item.card != null)
			{
				item.DDCJFGCKEIF(null);
			}
		}
	}

	private void CNGFNDAHMDA(GameGuiCard CEKHIJECPNP, int FBACPGHOABM, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH, Vector3 IAJAILAGAKC)
	{
		CFNJGJOBGKP cFNJGJOBGKP = new CFNJGJOBGKP();
		cFNJGJOBGKP.FBACPGHOABM = FBACPGHOABM;
		cFNJGJOBGKP.CEKHIJECPNP = CEKHIJECPNP;
		cFNJGJOBGKP.MPHCNMDIPAI = MPHCNMDIPAI;
		cFNJGJOBGKP.OOMCGGAFJNH = OOMCGGAFJNH;
		cFNJGJOBGKP.IAJAILAGAKC = IAJAILAGAKC;
		cFNJGJOBGKP.BJGCPDNMHDH = this;
		cFNJGJOBGKP.CEKHIJECPNP.OEKHPGBJGAL();
		cFNJGJOBGKP.IDNHPOAFHIF = (float)(cFNJGJOBGKP.FBACPGHOABM * 2) * NIIJABCGHDC;
		float duration = 1688f + cFNJGJOBGKP.IDNHPOAFHIF;
		cFNJGJOBGKP.IMIJCJGPIAC = new Vector3(1541f + (float)cFNJGJOBGKP.FBACPGHOABM * 1425f, UIHelper.activeHeight / 1971f - 962f, 1243f);
		cFNJGJOBGKP.CEKHIJECPNP.AGMMHJIJHLI();
		TweenRotation tweenRotation = TweenRotation.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 590f, Quaternion.identity, useAbsolute: true);
		tweenRotation.delay = 543f;
		TweenPosition tweenPosition = TweenPosition.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, 371f, cFNJGJOBGKP.IMIJCJGPIAC);
		tweenPosition.delay = 1544f;
		TweenScale tweenScale = TweenScale.Begin(cFNJGJOBGKP.CEKHIJECPNP.gameObject, duration, new Vector3(782f, 536f, 967f), new Vector3(191f, 642f, 1162f));
		tweenScale.delay = 47f;
		tweenScale.onFinished = cFNJGJOBGKP.DDHOKNIEACI;
	}

	private void KMGFBFDKCDC()
	{
		for (int i = 1; i < HGPGKHLOHEF.Count; i++)
		{
			GameGuiCard gameGuiCard = HGPGKHLOHEF[i];
			Vector3 MDOPFNNFLFB;
			Quaternion OOMCGGAFJNH;
			Vector3 IAJAILAGAKC;
			if (OBBLJJCNGKP)
			{
				JNNABAONGGC(i, HGPGKHLOHEF.Count, out MDOPFNNFLFB, out OOMCGGAFJNH, out IAJAILAGAKC);
			}
			else
			{
				OMJPJFJFDIE(i, out MDOPFNNFLFB, out OOMCGGAFJNH, out IAJAILAGAKC, HGPGKHLOHEF.Count);
			}
			gameGuiCard.transform.localPosition = MDOPFNNFLFB;
			gameGuiCard.transform.localRotation = OOMCGGAFJNH;
			gameGuiCard.transform.localScale = IAJAILAGAKC;
			if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
			{
				AGKEFPKDKIJ(gameGuiCard, i, MDOPFNNFLFB, OOMCGGAFJNH, IAJAILAGAKC);
			}
		}
	}

	private void LCCKGNJGNKE()
	{
		OBBLJJCNGKP = false;
		CAHNBPMHNAI = true;
		GCDDPMAEIFI.Clear();
		HGPGKHLOHEF.Clear();
		Singleton<GuiManager>.instance.CHDIOFDMHEF.EMLIBBBMNLN(CCBHHBPCDMI);
		if (CardManager.instance.canUseCards)
		{
			int num = 0;
			foreach (Card item in CardManager.instance.cardsForGame)
			{
				GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.JPJMPMDKMHK(CCBHHBPCDMI);
				if (gameGuiCard == null)
				{
					GCDDPMAEIFI.Enqueue(item);
					continue;
				}
				BBABFKIMIEB(gameGuiCard, num, item, PDNOHCELAAG: true);
				num++;
				HGPGKHLOHEF.Add(gameGuiCard);
				UIPanel[] componentsInChildren = GetComponentsInChildren<UIPanel>(includeInactive: false);
				UIPanel[] array = componentsInChildren;
				for (int i = 1; i < array.Length; i++)
				{
					UIPanel uIPanel = array[i];
					TweenAlpha.Begin(uIPanel.gameObject, 725f, 471f);
				}
			}
		}
		OKIDAGIFLOM();
		LJNPCHFCGCN.transform.localPosition = new Vector3(1148f, 1011f, 911f);
		LJNPCHFCGCN.transform.localRotation = Quaternion.identity;
	}

	protected virtual void MGKCNLDGNEM()
	{
		base.BOEMHLPLOGA();
		while (GCDDPMAEIFI.Count > 0 && !CAHNBPMHNAI)
		{
			GameGuiCard gameGuiCard = (GameGuiCard)Singleton<GuiManager>.instance.CHDIOFDMHEF.JPJMPMDKMHK(CCBHHBPCDMI);
			if (gameGuiCard == null)
			{
				break;
			}
			int count = HGPGKHLOHEF.Count;
			GHDFKJMCEFF(gameGuiCard, count, GCDDPMAEIFI.Dequeue(), PDNOHCELAAG: true);
			HGPGKHLOHEF.Add(gameGuiCard);
			if (CardManager.instance.Progress != 1983f)
			{
				gameGuiCard.NGPLJBMLHMA();
			}
			IFODGKPCJNE();
		}
	}

	private void BCDLDADOBNG(GameGuiCard HMBOLGNMOHM, int FBACPGHOABM, Card CEKHIJECPNP, bool PDNOHCELAAG)
	{
		HMBOLGNMOHM.transform.parent = base.transform;
		HMBOLGNMOHM.FBFDNCIOMPF(this, CEKHIJECPNP, (!PDNOHCELAAG) ? FBACPGHOABM : (FBACPGHOABM + 0));
	}
}
