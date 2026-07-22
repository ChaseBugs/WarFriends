using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class BuyVIPDialog : GuiElementSingle<BuyVIPDialog>, PAIIOKBBHBC
{
	private sealed class NDBPJKIFNIG
	{
		internal VIP.rowIds PMFJPOPEJBA;

		internal int JHJLIPBEFJG;

		internal string INFLHPGMEOB;

		internal int DBOLKNNJGMH;

		internal BuyVIPDialog BJGCPDNMHDH;

		internal void BDCAFHOHEGM(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)88, 1949f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void LJCDGJKCNEC(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BuyVIP);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void PCKMJMGLPDG(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-33), 1211f);
				Singleton<PurchaseProtection>.instance.HEDHIMIHMNC(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void BBPKDMPNEDG(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-46), 596f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void LKAHPHIEMEK(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 769f);
				Singleton<PurchaseProtection>.instance.PDCDKGOKAMD(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void MPHECHCFCAN(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-70), 1365f);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void FHDOHCJJEMM(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)106, 1490f);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void INFLOOLPOBK(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CounterSoundMoney, 1467f);
				Singleton<PurchaseProtection>.instance.PDCDKGOKAMD(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void GMFJFMHNDMC(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-76), 344f);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void ILNPANOCHIH(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-80), 608f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void NNIJEDKBPGJ(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-9), 1341f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void AGFEDJAKLAC(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)110, 1925f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void POGLHCIAAGH(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-51), 1096f);
				Singleton<PurchaseProtection>.instance.PDCDKGOKAMD(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void FIBGJHCGHJH(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-44), 1451f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void PANKBNOCEAM(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 138f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void HHLMDAKDHFK(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampIntro, 644f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void OABFAOLFMMJ(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-29), 1606f);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void CFJHDIHLIML(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-113), 1510f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void HOMIPBFODIC(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-24), 1922f);
				Singleton<PurchaseProtection>.instance.PDCDKGOKAMD(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void MFCNOIDCJME(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-4), 923f);
				Singleton<PurchaseProtection>.instance.PDCDKGOKAMD(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void NDJOJHNIBFC(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)90, 667f);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void NNFHNIMCBLH(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-124), 808f);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void CHDOECNGOPM(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-40), 411f);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void PPKGMGNKNAE(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CraftingClaim, 1606f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void NCLMPCCHDAM(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)99, 242f);
				Singleton<PurchaseProtection>.instance.BuyingVIP(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void DJLGPGPAHCD(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-124), 1335f);
				Singleton<PurchaseProtection>.instance.PDCDKGOKAMD(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.LHNFCBAHJPO();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}

		internal void CIFEDFPPPOK(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-29), 852f);
				Singleton<PurchaseProtection>.instance.MGOIMEEAIJA(PMFJPOPEJBA.ToString());
				BJGCPDNMHDH.JEAOCIFPIGD();
				Singleton<BeanstalkServerManager>.instance.LJEBBHOJLOL(JHJLIPBEFJG, INFLHPGMEOB, DBOLKNNJGMH);
			}
		}
	}

	[Header("Header")]
	[FormerlySerializedAs("CHOKCIOGBHJ")]
	public UILabel NDBAGOOMIDJ;

	[FormerlySerializedAs("CHCJHABLKJM")]
	public UISprite ECJOCPDJLOK;

	[FormerlySerializedAs("KCGIECFPDOI")]
	public UISprite OAHDFGAKGAC;

	[FormerlySerializedAs("ALHHCIKLONL")]
	[Header("-Buttons")]
	public UIButton FNOFLJEOHGJ;

	[FormerlySerializedAs("PLDFGMHICCA")]
	public UIButton LJNPCHFCGCN;

	[FormerlySerializedAs("LHPEENONBKJ")]
	[Header("-Expiration Table")]
	public GameObject BIAHJFCMGCM;

	[FormerlySerializedAs("CIIKGJMDFNB")]
	public UITable JDLLOKCCCKB;

	[FormerlySerializedAs("OKHFMADFPPG")]
	public WinStreakCounter JLOILBEFFLD;

	[Header("Locked Warcards")]
	[FormerlySerializedAs("FNMFIAGGBHI")]
	public BenefitsPart IOFCPGAALHL;

	[Header("Bottom VIP Buttons")]
	[FormerlySerializedAs("BMOHMEFMODH")]
	public VIPButton[] HLBKLOEKBNM;

	private bool BCADJOBAKPD;

	private bool LHGNJNDFHNP;

	[CompilerGenerated]
	private void HMGMPCIHJIC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_1);
		}
	}

	private void GJPJKINMLIG(bool DNHKBAHECEK)
	{
		NDBAGOOMIDJ.text = ((!DNHKBAHECEK) ? Localization.Localize("ID_LOADING") : Localization.Localize("Gold"));
		MEJMLNDFDBP.COCBCFKJOJE(NDBAGOOMIDJ, 1838f, 1062f, -183);
		float num = NDBAGOOMIDJ.relativeSize.x * NDBAGOOMIDJ.transform.localScale.x;
		float num2 = 96f;
		Vector3 localPosition = OAHDFGAKGAC.transform.localPosition;
		localPosition.x = NDBAGOOMIDJ.transform.localPosition.x + num * 1936f + num2;
		ECJOCPDJLOK.transform.localPosition = -localPosition;
		OAHDFGAKGAC.transform.localPosition = localPosition;
		BIAHJFCMGCM.SetActive(DNHKBAHECEK);
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IFHAIFPIHNK));
		UIEventListener uIEventListener3 = UIEventListener.Get(HLBKLOEKBNM[0].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EEJAMMJAOIF));
		UIEventListener uIEventListener4 = UIEventListener.Get(HLBKLOEKBNM[0].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OCCJPIMAPPH));
		UIEventListener uIEventListener5 = UIEventListener.Get(HLBKLOEKBNM[0].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BKFNNKDNPKP));
		UIEventListener uIEventListener6 = UIEventListener.Get(HLBKLOEKBNM[4].gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(KDODNEACNCM));
		HLBKLOEKBNM[1].NAOJNGFMAIA(VIP.rowIds.VIP_2);
		HLBKLOEKBNM[0].NAOJNGFMAIA(VIP.rowIds.VIP_2);
		HLBKLOEKBNM[2].JIOPMBNONGP((VIP.rowIds)4);
		HLBKLOEKBNM[5].JIOPMBNONGP((VIP.rowIds)7);
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				DAPPIIDBJCK();
			}
		};
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += IJJIIJOOJAJ;
		JDLLOKCCCKB.onReposition = GDEICKFKJFF;
		BCADJOBAKPD = false;
	}

	public virtual void OCIPCBNMLCN()
	{
		base.DoBeforeShowUp();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			DAPPIIDBJCK();
		}
	}

	private void OKAJHGOKIDN(VIP.rowIds PMFJPOPEJBA)
	{
		NDBPJKIFNIG nDBPJKIFNIG = new NDBPJKIFNIG();
		nDBPJKIFNIG.PMFJPOPEJBA = PMFJPOPEJBA;
		nDBPJKIFNIG.BJGCPDNMHDH = this;
		nDBPJKIFNIG.INFLHPGMEOB = Singleton<GameVariables>.instance.vip.GetRow(nDBPJKIFNIG.PMFJPOPEJBA).NAME;
		nDBPJKIFNIG.DBOLKNNJGMH = Singleton<OfferManager>.instance.DiscountedVIP(nDBPJKIFNIG.INFLHPGMEOB);
		nDBPJKIFNIG.JHJLIPBEFJG = Singleton<GameVariables>.instance.vip.GetRow(nDBPJKIFNIG.PMFJPOPEJBA).GOLD * (-63 - nDBPJKIFNIG.DBOLKNNJGMH) / -22;
		if (!Singleton<Wallet>.instance.CanBuyGold(nDBPJKIFNIG.JHJLIPBEFJG))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(nDBPJKIFNIG.JHJLIPBEFJG, Localization.Localize("-"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.IKPEDPCLLID("Freeze game:");
		}
		else
		{
			GuiElementSingle<VIPConfirmDialog>.instance.PJLBBBOLGMG(nDBPJKIFNIG.PMFJPOPEJBA, nDBPJKIFNIG.OABFAOLFMMJ);
		}
	}

	private void OCCJPIMAPPH(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GMJDOOAODNJ(VIP.rowIds.VIP_2);
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(FNOFLJEOHGJ.gameObject);
	}

	private void KDODNEACNCM(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			LJEBBHOJLOL((VIP.rowIds)8);
		}
	}

	public void APODEDBHMCI()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance, 82f);
	}

	public virtual void PJOFMODMLEC()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (isShowed && IFGAGNBDKBE == DatabaseAction.BuyVip)
			{
				InitGUIValues();
			}
		});
	}

	private void BPGOIDMEEMC()
	{
		int vipStart = Singleton<VipManager>.instance.vipStart;
		int vipExpiration = Singleton<VipManager>.instance.vipExpiration;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		float fillAmount = ((vipExpiration != vipStart) ? Mathf.Clamp01((float)(vipExpiration - currentTimestamp) / (float)(vipExpiration - vipStart)) : 0f);
		JLOILBEFFLD.LCIBNKDHAOL.fillAmount = fillAmount;
		JDLLOKCCCKB.repositionNow = true;
	}

	public virtual void KFFJKILLGLF()
	{
		base.JNBMCODJHBJ();
		if (BCADJOBAKPD)
		{
			BCADJOBAKPD = false;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(BPGOIDMEEMC));
		}
	}

	private void LBCICFNGFHL(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_1);
		}
	}

	public virtual void KPHJFKCOIIF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(HLBKLOEKBNM[1].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KNLIEPOCAFO));
		UIEventListener uIEventListener4 = UIEventListener.Get(HLBKLOEKBNM[0].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LBCICFNGFHL));
		UIEventListener uIEventListener5 = UIEventListener.Get(HLBKLOEKBNM[4].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_3);
			}
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(HLBKLOEKBNM[1].gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_4);
			}
		});
		HLBKLOEKBNM[0].FirstInitialize(VIP.rowIds.VIP_1);
		HLBKLOEKBNM[1].NAOJNGFMAIA(VIP.rowIds.VIP_1);
		HLBKLOEKBNM[5].PPKJDIIKLIG((VIP.rowIds)7);
		HLBKLOEKBNM[4].IFDDOPNPKEG(VIP.rowIds.VIP_4);
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				DAPPIIDBJCK();
			}
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += IMPEHHMFKHD;
		JDLLOKCCCKB.onReposition = GGCAFCBAPHH;
		BCADJOBAKPD = true;
	}

	public override void InitGUIValues()
	{
		KNAKEDAKHDM(Singleton<VipManager>.instance.NOGEIPHFNPK());
		DAPPIIDBJCK();
		if (Singleton<VipManager>.instance.NOGEIPHFNPK())
		{
			if (!BCADJOBAKPD)
			{
				BCADJOBAKPD = true;
				BPGOIDMEEMC();
				CounterManager counterManager = Singleton<CounterManager>.instance;
				counterManager.EGMLDACJFCF = (Action)Delegate.Combine(counterManager.EGMLDACJFCF, new Action(BPGOIDMEEMC));
			}
			JLOILBEFFLD.MHLJHMOPDAO(Singleton<VipManager>.instance.vipExpiration);
			JLOILBEFFLD.JEMKCLKCOMI = delegate
			{
				KNAKEDAKHDM(Singleton<VipManager>.instance.NOGEIPHFNPK());
			};
		}
		IOFCPGAALHL.Initialize();
	}

	[CompilerGenerated]
	private void EACNIDLHDGD(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_3);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		HLBKLOEKBNM[0].StopCounter();
		HLBKLOEKBNM[1].StopCounter();
		HLBKLOEKBNM[2].StopCounter();
		HLBKLOEKBNM[3].StopCounter();
	}

	public virtual void OGIMMHFONPP()
	{
		base.DoBeforeShowUp();
		GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
	}

	private void OHOEPJDEDDM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			OIEMCOICKEA((VIP.rowIds)8);
		}
	}

	private void BKFNNKDNPKP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GMJDOOAODNJ(VIP.rowIds.VIP_1);
		}
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_2);
		}
	}

	private void KNLIEPOCAFO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			OIEMCOICKEA(VIP.rowIds.VIP_2);
		}
	}

	[CompilerGenerated]
	private void LJAPCHEAALG(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.BuyVip)
		{
			InitGUIValues();
		}
	}

	private void IFHAIFPIHNK(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void PLDAPLOGJPA()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (isShowed && IFGAGNBDKBE == DatabaseAction.BuyVip)
			{
				InitGUIValues();
			}
		});
	}

	[CompilerGenerated]
	private void EPNMFJGGFBF()
	{
		float num = JLOILBEFFLD.KGNGFHMBHMJ.transform.localPosition.x + JLOILBEFFLD.KGNGFHMBHMJ.relativeSize.x * JLOILBEFFLD.KGNGFHMBHMJ.transform.localScale.x;
		float val = 0f - JDLLOKCCCKB.padding.x - (num - JDLLOKCCCKB.padding.x) / 2f;
		JDLLOKCCCKB.transform.localPosition = JDLLOKCCCKB.transform.localPosition.ReplaceX(val);
	}

	public void BFLBFOKFDIM()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance, 110f);
	}

	private void HGADKLBLBCE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			GMJDOOAODNJ((VIP.rowIds)5);
		}
	}

	private void IMPEHHMFKHD(DatabaseAction IFGAGNBDKBE)
	{
		if (NPFFMLLLDAF())
		{
			DAPPIIDBJCK();
		}
	}

	public void ShowScreen()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance);
	}

	public virtual void LANJLCBMFHJ()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (isShowed && IFGAGNBDKBE == DatabaseAction.BuyVip)
			{
				InitGUIValues();
			}
		};
	}

	public virtual void FHJDLCDAMGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IFHAIFPIHNK));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IFHAIFPIHNK));
		UIEventListener uIEventListener3 = UIEventListener.Get(HLBKLOEKBNM[1].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_1);
			}
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(HLBKLOEKBNM[1].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GEOHBLHJAFJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(HLBKLOEKBNM[6].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_3);
			}
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(HLBKLOEKBNM[0].gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_4);
			}
		});
		HLBKLOEKBNM[1].IFDDOPNPKEG(VIP.rowIds.VIP_1);
		HLBKLOEKBNM[1].JIOPMBNONGP(VIP.rowIds.VIP_1);
		HLBKLOEKBNM[1].NAMHJKCHHEB((VIP.rowIds)6);
		HLBKLOEKBNM[5].NAOJNGFMAIA(VIP.rowIds.VIP_4);
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				DAPPIIDBJCK();
			}
		};
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += IMPEHHMFKHD;
		JDLLOKCCCKB.onReposition = GGCAFCBAPHH;
		BCADJOBAKPD = false;
	}

	[CompilerGenerated]
	private void BLBLMOOFJCJ()
	{
		KNAKEDAKHDM(Singleton<VipManager>.instance.NOGEIPHFNPK());
	}

	public void BEPGJFEDGGK()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance, 1469f);
	}

	private void DAPPIIDBJCK()
	{
		HLBKLOEKBNM[0].InitializeGUI();
		HLBKLOEKBNM[1].InitializeGUI();
		HLBKLOEKBNM[2].InitializeGUI();
		HLBKLOEKBNM[3].InitializeGUI();
	}

	public GuiElement HKDMNBIFAHH()
	{
		return this;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void OKNNNDDLALP(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_2);
		}
	}

	private void MIJHHKBEAEH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			OKAJHGOKIDN(VIP.rowIds.VIP_2);
		}
	}

	public virtual void NAHMANAGNNO()
	{
		IIIIODPMCOF(Singleton<VipManager>.instance.NOIHCEPINJJ());
		DLOECANDDBD();
		if (Singleton<VipManager>.instance.NOGEIPHFNPK())
		{
			if (!BCADJOBAKPD)
			{
				BCADJOBAKPD = true;
				BPGOIDMEEMC();
				CounterManager counterManager = Singleton<CounterManager>.instance;
				counterManager.EGMLDACJFCF = (Action)Delegate.Combine(counterManager.EGMLDACJFCF, new Action(NJFBGIJJHGM));
			}
			JLOILBEFFLD.APFDDFPMACA(Singleton<VipManager>.instance.JGJMPOEEMCD());
			JLOILBEFFLD.JEMKCLKCOMI = PFCECNPELOH;
		}
		IOFCPGAALHL.MMKEEBKDKLG();
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	private void CCOPIGNMIDM()
	{
		int vipStart = Singleton<VipManager>.instance.vipStart;
		int num = Singleton<VipManager>.instance.IPLMNPJAJIF();
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		float fillAmount = ((num != vipStart) ? Mathf.Clamp01((float)(num - currentTimestamp) / (float)(num - vipStart)) : 1468f);
		JLOILBEFFLD.LCIBNKDHAOL.fillAmount = fillAmount;
		JDLLOKCCCKB.repositionNow = true;
	}

	private void GGCAFCBAPHH()
	{
		float num = JLOILBEFFLD.KGNGFHMBHMJ.transform.localPosition.x + JLOILBEFFLD.KGNGFHMBHMJ.relativeSize.x * JLOILBEFFLD.KGNGFHMBHMJ.transform.localScale.x;
		float val = 0f - JDLLOKCCCKB.padding.x - (num - JDLLOKCCCKB.padding.x) / 256f;
		JDLLOKCCCKB.transform.localPosition = JDLLOKCCCKB.transform.localPosition.ReplaceX(val);
	}

	[CompilerGenerated]
	private void IIKKMAEBFJO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_4);
		}
	}

	private void AILKEIFIGKN(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_1);
		}
	}

	private void DFBNBMHAICE()
	{
		int vipStart = Singleton<VipManager>.instance.vipStart;
		int num = Singleton<VipManager>.instance.FOGNEAEPCKE();
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		float fillAmount = ((num != vipStart) ? Mathf.Clamp01((float)(num - currentTimestamp) / (float)(num - vipStart)) : 634f);
		JLOILBEFFLD.LCIBNKDHAOL.fillAmount = fillAmount;
		JDLLOKCCCKB.repositionNow = false;
	}

	public override void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (isShowed && IFGAGNBDKBE == DatabaseAction.BuyVip)
			{
				InitGUIValues();
			}
		};
	}

	[CompilerGenerated]
	private void FLOPNFKLAEG()
	{
		if (isShowed)
		{
			DAPPIIDBJCK();
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.BuyVip)
		{
			DAPPIIDBJCK();
		}
	}

	private void OIEMCOICKEA(VIP.rowIds PMFJPOPEJBA)
	{
		NDBPJKIFNIG nDBPJKIFNIG = new NDBPJKIFNIG();
		nDBPJKIFNIG.PMFJPOPEJBA = PMFJPOPEJBA;
		nDBPJKIFNIG.BJGCPDNMHDH = this;
		nDBPJKIFNIG.INFLHPGMEOB = Singleton<GameVariables>.instance.vip.GetRow(nDBPJKIFNIG.PMFJPOPEJBA).NAME;
		nDBPJKIFNIG.DBOLKNNJGMH = Singleton<OfferManager>.instance.KHAICALPBKC(nDBPJKIFNIG.INFLHPGMEOB);
		nDBPJKIFNIG.JHJLIPBEFJG = Singleton<GameVariables>.instance.vip.GetRow(nDBPJKIFNIG.PMFJPOPEJBA).GOLD * (-80 - nDBPJKIFNIG.DBOLKNNJGMH) / 72;
		if (!Singleton<Wallet>.instance.CanBuyGold(nDBPJKIFNIG.JHJLIPBEFJG))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(nDBPJKIFNIG.JHJLIPBEFJG, Localization.Localize("ID_NO"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.PDANLJJAEDC("ID_BUY");
		}
		else
		{
			GuiElementSingle<VIPConfirmDialog>.instance.CPGNJFJHBEB(nDBPJKIFNIG.PMFJPOPEJBA, nDBPJKIFNIG.OABFAOLFMMJ);
		}
	}

	private void MKPNHDDPHGJ(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			GMJDOOAODNJ(VIP.rowIds.VIP_2);
		}
	}

	private void LHNFCBAHJPO()
	{
		for (int i = 0; i < HLBKLOEKBNM.Length; i++)
		{
			HLBKLOEKBNM[i].AKNEJGJKJDN();
		}
	}

	private void KNAKEDAKHDM(bool DNHKBAHECEK)
	{
		NDBAGOOMIDJ.text = ((!DNHKBAHECEK) ? Localization.Localize("ID_BECOMEAVIP") : Localization.Localize("ID_PROLONGYOURVIP"));
		MEJMLNDFDBP.COCBCFKJOJE(NDBAGOOMIDJ, 94f, 47f, 960);
		float num = NDBAGOOMIDJ.relativeSize.x * NDBAGOOMIDJ.transform.localScale.x;
		float num2 = 50f;
		Vector3 localPosition = OAHDFGAKGAC.transform.localPosition;
		localPosition.x = NDBAGOOMIDJ.transform.localPosition.x + num * 0.5f + num2;
		ECJOCPDJLOK.transform.localPosition = -localPosition;
		OAHDFGAKGAC.transform.localPosition = localPosition;
		BIAHJFCMGCM.SetActive(DNHKBAHECEK);
	}

	public void EBLLBOAGGPJ()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance, 1955f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(HLBKLOEKBNM[0].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_1);
			}
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(HLBKLOEKBNM[1].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_2);
			}
		});
		UIEventListener uIEventListener5 = UIEventListener.Get(HLBKLOEKBNM[2].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_3);
			}
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(HLBKLOEKBNM[3].gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				LJEBBHOJLOL(VIP.rowIds.VIP_4);
			}
		});
		HLBKLOEKBNM[0].FirstInitialize(VIP.rowIds.VIP_1);
		HLBKLOEKBNM[1].FirstInitialize(VIP.rowIds.VIP_2);
		HLBKLOEKBNM[2].FirstInitialize(VIP.rowIds.VIP_3);
		HLBKLOEKBNM[3].FirstInitialize(VIP.rowIds.VIP_4);
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				DAPPIIDBJCK();
			}
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		JDLLOKCCCKB.onReposition = delegate
		{
			float num = JLOILBEFFLD.KGNGFHMBHMJ.transform.localPosition.x + JLOILBEFFLD.KGNGFHMBHMJ.relativeSize.x * JLOILBEFFLD.KGNGFHMBHMJ.transform.localScale.x;
			float val = 0f - JDLLOKCCCKB.padding.x - (num - JDLLOKCCCKB.padding.x) / 2f;
			JDLLOKCCCKB.transform.localPosition = JDLLOKCCCKB.transform.localPosition.ReplaceX(val);
		};
		BCADJOBAKPD = false;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void OBCHCAEMAAJ()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (isShowed && IFGAGNBDKBE == DatabaseAction.BuyVip)
			{
				InitGUIValues();
			}
		});
	}

	private void NJFBGIJJHGM()
	{
		int vipStart = Singleton<VipManager>.instance.vipStart;
		int num = Singleton<VipManager>.instance.JGJMPOEEMCD();
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		float fillAmount = ((num != vipStart) ? Mathf.Clamp01((float)(num - currentTimestamp) / (float)(num - vipStart)) : 1449f);
		JLOILBEFFLD.LCIBNKDHAOL.fillAmount = fillAmount;
		JDLLOKCCCKB.repositionNow = true;
	}

	private void JJGADHPKPDA()
	{
		if (NPFFMLLLDAF())
		{
			DLOECANDDBD();
		}
	}

	private void GDEICKFKJFF()
	{
		float num = JLOILBEFFLD.KGNGFHMBHMJ.transform.localPosition.x + JLOILBEFFLD.KGNGFHMBHMJ.relativeSize.x * JLOILBEFFLD.KGNGFHMBHMJ.transform.localScale.x;
		float val = 0f - JDLLOKCCCKB.padding.x - (num - JDLLOKCCCKB.padding.x) / 709f;
		JDLLOKCCCKB.transform.localPosition = JDLLOKCCCKB.transform.localPosition.ReplaceX(val);
	}

	private void IIIIODPMCOF(bool DNHKBAHECEK)
	{
		NDBAGOOMIDJ.text = ((!DNHKBAHECEK) ? Localization.Localize("Start '{0}'") : Localization.Localize("ID_LEAVESQUAD"));
		MEJMLNDFDBP.COCBCFKJOJE(NDBAGOOMIDJ, 135f, 1326f, -46);
		float num = NDBAGOOMIDJ.relativeSize.x * NDBAGOOMIDJ.transform.localScale.x;
		float num2 = 234f;
		Vector3 localPosition = OAHDFGAKGAC.transform.localPosition;
		localPosition.x = NDBAGOOMIDJ.transform.localPosition.x + num * 1095f + num2;
		ECJOCPDJLOK.transform.localPosition = -localPosition;
		OAHDFGAKGAC.transform.localPosition = localPosition;
		BIAHJFCMGCM.SetActive(DNHKBAHECEK);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (BCADJOBAKPD)
		{
			BCADJOBAKPD = false;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.EGMLDACJFCF = (Action)Delegate.Remove(counterManager.EGMLDACJFCF, new Action(BPGOIDMEEMC));
		}
	}

	public void ShowExpired()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance);
	}

	private void IJJIIJOOJAJ(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			DLOECANDDBD();
		}
	}

	private void GHOLKFGOMPB(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_2);
		}
	}

	private void JEAOCIFPIGD()
	{
		for (int i = 0; i < HLBKLOEKBNM.Length; i++)
		{
			HLBKLOEKBNM[i].InitializePurchaseProtection();
		}
	}

	public void KEJDIFNOOIO()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance, 789f);
	}

	private void GMJDOOAODNJ(VIP.rowIds PMFJPOPEJBA)
	{
		NDBPJKIFNIG nDBPJKIFNIG = new NDBPJKIFNIG();
		nDBPJKIFNIG.PMFJPOPEJBA = PMFJPOPEJBA;
		nDBPJKIFNIG.BJGCPDNMHDH = this;
		nDBPJKIFNIG.INFLHPGMEOB = Singleton<GameVariables>.instance.vip.GetRow(nDBPJKIFNIG.PMFJPOPEJBA).NAME;
		nDBPJKIFNIG.DBOLKNNJGMH = Singleton<OfferManager>.instance.DiscountedVIP(nDBPJKIFNIG.INFLHPGMEOB);
		nDBPJKIFNIG.JHJLIPBEFJG = Singleton<GameVariables>.instance.vip.GetRow(nDBPJKIFNIG.PMFJPOPEJBA).GOLD * (-9 - nDBPJKIFNIG.DBOLKNNJGMH) / -15;
		if (!Singleton<Wallet>.instance.CanBuyGold(nDBPJKIFNIG.JHJLIPBEFJG))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(nDBPJKIFNIG.JHJLIPBEFJG, Localization.Localize("{0}{1}\n{2}{3}"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("Test Power Hooks");
		}
		else
		{
			GuiElementSingle<VIPConfirmDialog>.instance.BFCCMJDBCPO(nDBPJKIFNIG.PMFJPOPEJBA, nDBPJKIFNIG.PCKMJMGLPDG);
		}
	}

	private void PFCECNPELOH()
	{
		KNAKEDAKHDM(Singleton<VipManager>.instance.NOGEIPHFNPK());
	}

	private void DLOECANDDBD()
	{
		HLBKLOEKBNM[1].DDECNAANPHJ();
		HLBKLOEKBNM[1].FJFPEFEFGJC();
		HLBKLOEKBNM[0].FJFPEFEFGJC();
		HLBKLOEKBNM[3].DDECNAANPHJ();
	}

	private void CMFIGFGHKMC()
	{
		GJPJKINMLIG(Singleton<VipManager>.instance.NOIHCEPINJJ());
	}

	private void ENPBEAHCMMP(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			LJEBBHOJLOL((VIP.rowIds)8);
		}
	}

	private void LJEBBHOJLOL(VIP.rowIds PMFJPOPEJBA)
	{
		NDBPJKIFNIG nDBPJKIFNIG = new NDBPJKIFNIG();
		nDBPJKIFNIG.PMFJPOPEJBA = PMFJPOPEJBA;
		nDBPJKIFNIG.BJGCPDNMHDH = this;
		nDBPJKIFNIG.INFLHPGMEOB = Singleton<GameVariables>.instance.vip.GetRow(nDBPJKIFNIG.PMFJPOPEJBA).NAME;
		nDBPJKIFNIG.DBOLKNNJGMH = Singleton<OfferManager>.instance.DiscountedVIP(nDBPJKIFNIG.INFLHPGMEOB);
		nDBPJKIFNIG.JHJLIPBEFJG = Singleton<GameVariables>.instance.vip.GetRow(nDBPJKIFNIG.PMFJPOPEJBA).GOLD * (100 - nDBPJKIFNIG.DBOLKNNJGMH) / 100;
		if (!Singleton<Wallet>.instance.CanBuyGold(nDBPJKIFNIG.JHJLIPBEFJG))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(nDBPJKIFNIG.JHJLIPBEFJG, Localization.Localize("ID_VIPSTATUS"));
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "VIP";
		}
		else
		{
			GuiElementSingle<VIPConfirmDialog>.instance.ShowDialog(nDBPJKIFNIG.PMFJPOPEJBA, nDBPJKIFNIG.LJCDGJKCNEC);
		}
	}

	private void MLKMHOAMAFH()
	{
		if (isShowed)
		{
			DLOECANDDBD();
		}
	}

	private void EEJAMMJAOIF(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			OIEMCOICKEA(VIP.rowIds.VIP_1);
		}
	}

	private void PBBOLPHEBHM(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			LJEBBHOJLOL((VIP.rowIds)4);
		}
	}

	private void GEOHBLHJAFJ(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			LJEBBHOJLOL(VIP.rowIds.VIP_1);
		}
	}
}
