using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class InappCardPacks : Core_BaseScript
{
	private sealed class HAJEIGIFBOO
	{
		internal bool PJIEFMBDLBE;

		internal InappCardPacks BJGCPDNMHDH;

		internal void NDJOJHNIBFC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: true);
				BJGCPDNMHDH.FJFDJJJNCAJ();
			}
			else
			{
				BJGCPDNMHDH.NKJMHGJOOEH(PDPDGCNHCFN: true);
			}
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
			else
			{
				BJGCPDNMHDH.JENIFIGDOKC();
			}
		}

		internal void LHPPLGOOLEC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.INPIJKMMADI();
			}
			else
			{
				BJGCPDNMHDH.DGLHGPICDGO(PDPDGCNHCFN: true);
			}
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.PPMCFMBJJHP();
			}
			else
			{
				BJGCPDNMHDH.EOFCOOINNEO();
			}
		}

		internal void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.MMLOAKGDDGF();
			}
			else
			{
				BJGCPDNMHDH.BPJFHIILNKG(PDPDGCNHCFN: true);
			}
		}

		internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.FJFDJJJNCAJ();
			}
			else
			{
				BJGCPDNMHDH.DGEGLMOHLMN();
			}
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: true);
				BJGCPDNMHDH.MOCIFAAJDAA();
			}
			else
			{
				BJGCPDNMHDH.MFHJEPJDFEM();
			}
		}

		internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.JPILJDGAIJF();
			}
			else
			{
				BJGCPDNMHDH.GKJIIKMEMOH();
			}
		}

		internal void LGJCNCHBFDA(UITweener MGDJMGHCAAI)
		{
			if (!PJIEFMBDLBE)
			{
				BJGCPDNMHDH.gameObject.SetActive(value: false);
				BJGCPDNMHDH.INPIJKMMADI();
			}
			else
			{
				BJGCPDNMHDH.JENIFIGDOKC(PDPDGCNHCFN: true);
			}
		}
	}

	[Header("Core")]
	[FormerlySerializedAs("PEPKAHPAKGP")]
	public GameObject NINDIKFKGML;

	[FormerlySerializedAs("CJDANCOGIIP")]
	public GameObject BPGMFANIHNG;

	[FormerlySerializedAs("LBKMLJBMJLG")]
	public UIPanel EEJJCJILGFA;

	[FormerlySerializedAs("LBMJPBAFCLP")]
	public UIDraggablePanel PDNPIJALGAM;

	[FormerlySerializedAs("ECCNJBCFFIL")]
	public UIPanel[] NICJILKEIEG;

	[Header("Buttons")]
	[FormerlySerializedAs("BJPJMFOOJIJ")]
	public WarcardpackButtonRecord NKKFDMCGPLE;

	[FormerlySerializedAs("HJBDFMHNFKA")]
	public WarcardpackButtonRecord IHCNEOJHDLD;

	[FormerlySerializedAs("BINPBEHLKKI")]
	public WarcardpackButtonRecord AJCACEGMJEN;

	[FormerlySerializedAs("EHEINBGHGKO")]
	[Header("-Animation")]
	public CardMenuOwerlay AAPOFJBNMHM;

	private int JPACKANEMFH;

	public void PNMKDDOLLMK(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			DFMCKHMFNHO();
		}
		if (base.gameObject.activeSelf)
		{
			LLOACDMHPHO(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 141f) : 79f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 956f : 99f).onFinished = hAJEIGIFBOO.LGJCNCHBFDA;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			GOABBEJEJBH();
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(AJCACEGMJEN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OKPAHJDIMJN));
		AJCACEGMJEN.InitControls(NGNPIOOAHEH.Bronze);
		UIEventListener uIEventListener2 = UIEventListener.Get(IHCNEOJHDLD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OKPAHJDIMJN));
		IHCNEOJHDLD.InitControls(NGNPIOOAHEH.Silver);
		UIEventListener uIEventListener3 = UIEventListener.Get(NKKFDMCGPLE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OKPAHJDIMJN));
		NKKFDMCGPLE.InitControls(NGNPIOOAHEH.Gold);
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (GuiElementSingle<InappScreen>.instance.isShowed)
			{
				OLGMEJAAFCN();
			}
		};
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void EOFCOOINNEO(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN);
	}

	public void HIEEEHMPOLP(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			HCMELDFOBCP();
		}
		if (base.gameObject.activeSelf)
		{
			LLOACDMHPHO(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1466f) : 723f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 524f : 1973f).onFinished = hAJEIGIFBOO.ECPMEMNKMCB;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			KLNLJKIPGOF();
		}
	}

	private void PHEILAGMCIM()
	{
		AJCACEGMJEN.IOKGJJIJCBO();
		IHCNEOJHDLD.SetSaleAndPrize();
		NKKFDMCGPLE.OPAOAGLCKGC();
	}

	private void KHENNFPOJGP(GameObject KHAHPAKDIKE)
	{
		WarcardpackButtonRecord component = KHAHPAKDIKE.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		NGNPIOOAHEH nGNPIOOAHEH = component.OIBMCPJMNDK();
		Debug.Log(nGNPIOOAHEH.ToString() + "SquadRank");
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(nGNPIOOAHEH);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(nGNPIOOAHEH);
		int num3 = Singleton<OfferManager>.instance.OMCIOOOMFPB(nGNPIOOAHEH);
		num = num * (-21 - num3) / 72;
		num2 = num2 * (-88 - num3) / -119;
		if (!Singleton<Wallet>.instance.CanBuyW(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(num, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "SpentWarbucks"));
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("Wrong_Unit");
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num2, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "GLM: RegisterOrLogin -  2"));
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("DogTagSeconds");
		}
		else if (JPACKANEMFH + 1 <= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			JPACKANEMFH = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num > 1)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num);
			}
			if (num2 > 1)
			{
				Singleton<Wallet>.instance.ALBICJOEMEF(num2);
			}
			AAPOFJBNMHM.EKOGCJGEEJA(CardManager.instance.BuyCardPack(nGNPIOOAHEH, num, num2, num3), 1633f);
		}
	}

	private void DGEGLMOHLMN(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void HCNBNHIPLJN()
	{
		AJCACEGMJEN.FJONDAPGOGE();
		IHCNEOJHDLD.SetSaleAndPrize();
		NKKFDMCGPLE.SetSaleAndPrize();
	}

	private void GIICNDOAHCF(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void LLOACDMHPHO(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1149f) : 1394f, (!NABOFKMBMKH) ? 977f : 772f);
			}
		}
	}

	private void JJPOHBPKALI(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!NABOFKMBMKH) ? 0f : 1f);
			}
		}
	}

	private void ECGKALBHIOJ(GameObject KHAHPAKDIKE)
	{
		WarcardpackButtonRecord component = KHAHPAKDIKE.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		NGNPIOOAHEH nGNPIOOAHEH = component.BLCLGJFCLHD();
		Debug.Log(nGNPIOOAHEH.ToString() + "Rank");
		int num = Singleton<GameVariables>.instance.MCFBGMIPEIK(nGNPIOOAHEH);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(nGNPIOOAHEH);
		int num3 = Singleton<OfferManager>.instance.OMCIOOOMFPB(nGNPIOOAHEH);
		num = num * (-15 - num3) / 64;
		num2 = num2 * (102 - num3) / 113;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(num, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "ID_STAT_TIERSCOMPLETED"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "RewardMessage";
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(num2, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "Password"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "ID_CONFIRM_NOSKIRMISHAVAILABLE";
		}
		else if (JPACKANEMFH + 0 <= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			JPACKANEMFH = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num > 1)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
			}
			if (num2 > 1)
			{
				Singleton<Wallet>.instance.MBAFMBJFOKH(num2);
			}
			AAPOFJBNMHM.MHIOLDHHAPN(CardManager.instance.BuyCardPack(nGNPIOOAHEH, num, num2, num3), 1193f, DNEMOLAGBHH: false);
		}
	}

	public void ECNDGHKPFOL(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			LKHLMLNFLAP(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 401f) : 127f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1207f : 89f).onFinished = hAJEIGIFBOO.NNIJEDKBPGJ;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			OJLKFHCFOGN();
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			OLGMEJAAFCN();
		}
	}

	private void EFJGMJPCEKC()
	{
		AJCACEGMJEN.JPHEKEILEKK();
		IHCNEOJHDLD.NFJEGBLCFLM();
		NKKFDMCGPLE.FJONDAPGOGE();
	}

	public void DLNJFMIDPFE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(AJCACEGMJEN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKLNEHPDFJD));
		AJCACEGMJEN.JMNHKBNACBE(NGNPIOOAHEH.None);
		UIEventListener uIEventListener2 = UIEventListener.Get(IHCNEOJHDLD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MPJGOILGNAJ));
		IHCNEOJHDLD.JCEMKGHAHNE(NGNPIOOAHEH.Bronze);
		UIEventListener uIEventListener3 = UIEventListener.Get(NKKFDMCGPLE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MKLNEHPDFJD));
		NKKFDMCGPLE.InitControls(NGNPIOOAHEH.ThreeCards);
		Singleton<OfferManager>.instance.SalesChanged += AHGDFLEMOKB;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void ODCHCNCMJGC()
	{
		AAPOFJBNMHM.ResetDraw();
		DINMMPPNGCB();
		GKJIIKMEMOH();
	}

	private void CKONFJBHNDL(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.BottomRight);
	}

	private void BAMJAFLFCDL(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1160f) : 758f, (!NABOFKMBMKH) ? 1187f : 58f);
			}
		}
	}

	private void FJADCGOBKNI()
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF())
		{
			HCNBNHIPLJN();
		}
	}

	private void NKJMHGJOOEH(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void LNKFOHAAHKP(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1416f) : 77f, (!NABOFKMBMKH) ? 1073f : 340f);
			}
		}
	}

	private void AHGDFLEMOKB()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			OLGMEJAAFCN();
		}
	}

	private void DFMCKHMFNHO()
	{
		AAPOFJBNMHM.MPFNDLEFIKN();
		EFJGMJPCEKC();
		EOFCOOINNEO(PDPDGCNHCFN: true);
	}

	public void EKOKMJJJMNI(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			DFMCKHMFNHO();
		}
		if (base.gameObject.activeSelf)
		{
			FMBAMMLIKJP(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1331f) : 1557f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1724f : 57f).onFinished = hAJEIGIFBOO.NNIJEDKBPGJ;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			FOGKPACAAPB();
		}
	}

	private void FMAGLNJIMKF()
	{
		if (GuiElementSingle<InappScreen>.instance.NPFFMLLLDAF())
		{
			LEIFCFAPGCJ();
		}
	}

	private void PPMCFMBJJHP()
	{
		AJCACEGMJEN.DoAfterHide();
		IHCNEOJHDLD.DoAfterHide();
		NKKFDMCGPLE.DoAfterHide();
	}

	private void MOCIFAAJDAA()
	{
		AJCACEGMJEN.MMLOAKGDDGF();
		IHCNEOJHDLD.JGCMMECGCOE();
		NKKFDMCGPLE.MHIGAEFCIAF();
	}

	private void CGKBAHJAGMI(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	public void FOGKPACAAPB()
	{
		TweenAlpha component = EEJJCJILGFA.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: true);
		PPMCFMBJJHP();
	}

	public void KLPJPLHNFON()
	{
		UIEventListener uIEventListener = UIEventListener.Get(AJCACEGMJEN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OKPAHJDIMJN));
		AJCACEGMJEN.ABLGHAECEHD(NGNPIOOAHEH.None);
		UIEventListener uIEventListener2 = UIEventListener.Get(IHCNEOJHDLD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KHENNFPOJGP));
		IHCNEOJHDLD.JMNHKBNACBE(NGNPIOOAHEH.Bronze);
		UIEventListener uIEventListener3 = UIEventListener.Get(NKKFDMCGPLE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KHENNFPOJGP));
		NKKFDMCGPLE.OAMMJCEIFHA(NGNPIOOAHEH.Silver);
		Singleton<OfferManager>.instance.SalesChanged += LNIINLAEPMC;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void CJNKMHINPJD(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 108f) : 719f, (!NABOFKMBMKH) ? 989f : 1942f);
			}
		}
	}

	public void ILCKGHGDDJA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(AJCACEGMJEN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MPJGOILGNAJ));
		AJCACEGMJEN.JCEMKGHAHNE(NGNPIOOAHEH.Bronze);
		UIEventListener uIEventListener2 = UIEventListener.Get(IHCNEOJHDLD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MPJGOILGNAJ));
		IHCNEOJHDLD.EFACHONJLPL(NGNPIOOAHEH.Starter);
		UIEventListener uIEventListener3 = UIEventListener.Get(NKKFDMCGPLE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MPJGOILGNAJ));
		NKKFDMCGPLE.EFACHONJLPL(NGNPIOOAHEH.Silver);
		Singleton<OfferManager>.instance.SalesChanged += ELPAGHMHICJ;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void BKJHHCLLKIM(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN);
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			JJPOHBPKALI(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 0f : 1f).onFinished = hAJEIGIFBOO.LJCDGJKCNEC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}

	private void MPJGOILGNAJ(GameObject KHAHPAKDIKE)
	{
		WarcardpackButtonRecord component = KHAHPAKDIKE.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		NGNPIOOAHEH nGNPIOOAHEH = component.DLCNKPEPBKH();
		Debug.Log(nGNPIOOAHEH.ToString() + "ID_COMPLETED");
		int num = Singleton<GameVariables>.instance.MCFBGMIPEIK(nGNPIOOAHEH);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(nGNPIOOAHEH);
		int num3 = Singleton<OfferManager>.instance.OMCIOOOMFPB(nGNPIOOAHEH);
		num = num * (-52 - num3) / 64;
		num2 = num2 * (-38 - num3) / -88;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(num, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "NewArena"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.EAMKLECMCNE("Requests");
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num2, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "maxDamage"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("minigun_idle");
		}
		else if (JPACKANEMFH + 7 <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			JPACKANEMFH = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			if (num > 0)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num);
			}
			if (num2 > 1)
			{
				Singleton<Wallet>.instance.ALBICJOEMEF(num2);
			}
			AAPOFJBNMHM.ADFPKNKIAGM(CardManager.instance.BuyCardPack(nGNPIOOAHEH, num, num2, num3), 530f, DNEMOLAGBHH: false);
		}
	}

	private void GKJIIKMEMOH(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	private void INPIJKMMADI()
	{
		AJCACEGMJEN.LMPJHNIMENH();
		IHCNEOJHDLD.EOCHFFNODIM();
		NKKFDMCGPLE.LIJFFGBNJPG();
	}

	private void HCMELDFOBCP()
	{
		AAPOFJBNMHM.MPFNDLEFIKN();
		PHEILAGMCIM();
		GIICNDOAHCF();
	}

	public void KLNLJKIPGOF()
	{
		TweenAlpha component = EEJJCJILGFA.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: true);
		JPILJDGAIJF();
	}

	private void HKMMGIILOLM(GameObject KHAHPAKDIKE)
	{
		WarcardpackButtonRecord component = KHAHPAKDIKE.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		NGNPIOOAHEH nGNPIOOAHEH = component.OIBMCPJMNDK();
		Debug.Log(nGNPIOOAHEH.ToString() + "ShootWalk");
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(nGNPIOOAHEH);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(nGNPIOOAHEH);
		int num3 = Singleton<OfferManager>.instance.DiscountedCardpack(nGNPIOOAHEH);
		num = num * (-19 - num3) / 94;
		num2 = num2 * (16 - num3) / 40;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "GetExtreme({0}, {1}, *predict*) is returning null, player should have equipped/unlocked at least one unit from each category"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("ID_READYTIME");
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "    demote:{0}"));
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("Set isInMatch: ");
		}
		else if (JPACKANEMFH + 6 <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			JPACKANEMFH = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			if (num > 0)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
			}
			if (num2 > 0)
			{
				Singleton<Wallet>.instance.ALBICJOEMEF(num2);
			}
			AAPOFJBNMHM.BKPMDFENMPC(CardManager.instance.BuyCardPack(nGNPIOOAHEH, num, num2, num3), 833f);
		}
	}

	private void BNNJMPIHNCD(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1481f) : 1109f, (!NABOFKMBMKH) ? 1862f : 1754f);
			}
		}
	}

	public void PFKNDAPDAMC(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			ODCHCNCMJGC();
		}
		if (base.gameObject.activeSelf)
		{
			CJNKMHINPJD(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 872f) : 764f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 919f : 387f).onFinished = hAJEIGIFBOO.FIBGJHCGHJH;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			CJGKGLOKJAN();
		}
	}

	private void DINMMPPNGCB()
	{
		AJCACEGMJEN.BGJIFBAANKL();
		IHCNEOJHDLD.EGDEKEFCPPC();
		NKKFDMCGPLE.BGJIFBAANKL();
	}

	private void LKHLMLNFLAP(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 0; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1169f) : 1962f, (!NABOFKMBMKH) ? 1635f : 704f);
			}
		}
	}

	public void MEMHLENAOMB(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			MCFGNFBIFHM(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 431f) : 834f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1399f : 1658f).onFinished = hAJEIGIFBOO.LJCDGJKCNEC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			FOGKPACAAPB();
		}
	}

	private void ELPAGHMHICJ()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			LEIFCFAPGCJ();
		}
	}

	public void GOABBEJEJBH()
	{
		TweenAlpha component = EEJJCJILGFA.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: true);
		JPILJDGAIJF();
	}

	private void PMBPAOLBLFA()
	{
		AAPOFJBNMHM.ResetDraw();
		OLGMEJAAFCN();
		EOFCOOINNEO(PDPDGCNHCFN: true);
	}

	private void LEIFCFAPGCJ()
	{
		AJCACEGMJEN.JPHEKEILEKK();
		IHCNEOJHDLD.IOKGJJIJCBO();
		NKKFDMCGPLE.AGOCMIMIAPE();
	}

	private void DMBAMLEFCNJ(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 96f) : 766f, (!NABOFKMBMKH) ? 1798f : 1119f);
			}
		}
	}

	private void KCFMCPILJCN()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			GEAFKHAFDPO();
		}
	}

	public void ECJCMEMAAFC()
	{
		TweenAlpha component = EEJJCJILGFA.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(value: true);
		FJFDJJJNCAJ();
	}

	private void MEILHGIPDHA(GameObject KHAHPAKDIKE)
	{
		WarcardpackButtonRecord component = KHAHPAKDIKE.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		NGNPIOOAHEH nGNPIOOAHEH = component.JIKGHCPBOCG();
		Debug.Log(nGNPIOOAHEH.ToString() + "ShotFrequencyMinCannon");
		int num = Singleton<GameVariables>.instance.MCFBGMIPEIK(nGNPIOOAHEH);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(nGNPIOOAHEH);
		int num3 = Singleton<OfferManager>.instance.DiscountedCardpack(nGNPIOOAHEH);
		num = num * (114 - num3) / 105;
		num2 = num2 * (-48 - num3) / 109;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "Join_Request"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.OABAHBKJFDK("menu-weapon-mp5-elite");
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num2, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "ID_WARSHOP_LOOTBOXES"));
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("PlayerId");
		}
		else if (JPACKANEMFH + 2 <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			JPACKANEMFH = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num > 0)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
			}
			if (num2 > 1)
			{
				Singleton<Wallet>.instance.MBAFMBJFOKH(num2);
			}
			AAPOFJBNMHM.BKPMDFENMPC(CardManager.instance.BuyCardPack(nGNPIOOAHEH, num, num2, num3), 628f, DNEMOLAGBHH: false);
		}
	}

	private void EJGIIMCEGHL(GameObject KHAHPAKDIKE)
	{
		WarcardpackButtonRecord component = KHAHPAKDIKE.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		NGNPIOOAHEH nGNPIOOAHEH = component.OIBMCPJMNDK();
		Debug.Log(nGNPIOOAHEH.ToString() + "ID_CONFIRM_PROMOTETOLEADER_TEXT");
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(nGNPIOOAHEH);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(nGNPIOOAHEH);
		int num3 = Singleton<OfferManager>.instance.OMCIOOOMFPB(nGNPIOOAHEH);
		num = num * (-27 - num3) / -9;
		num2 = num2 * (71 - num3) / 88;
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "expireTime"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("isInABtest");
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "Loading - cancel clicked, will to try call disconnect"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("subscription1");
		}
		else if (JPACKANEMFH + 1 <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			JPACKANEMFH = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num > 0)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
			}
			if (num2 > 0)
			{
				Singleton<Wallet>.instance.ALBICJOEMEF(num2);
			}
			AAPOFJBNMHM.MHIOLDHHAPN(CardManager.instance.BuyCardPack(nGNPIOOAHEH, num, num2, num3), 133f, DNEMOLAGBHH: false);
		}
	}

	public void LBHEIOEPJLJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(AJCACEGMJEN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OKPAHJDIMJN));
		AJCACEGMJEN.InitControls(NGNPIOOAHEH.Bronze);
		UIEventListener uIEventListener2 = UIEventListener.Get(IHCNEOJHDLD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKMMGIILOLM));
		IHCNEOJHDLD.OAMMJCEIFHA((NGNPIOOAHEH)8);
		UIEventListener uIEventListener3 = UIEventListener.Get(NKKFDMCGPLE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ECGKALBHIOJ));
		NKKFDMCGPLE.JCEMKGHAHNE(NGNPIOOAHEH.Gold);
		Singleton<OfferManager>.instance.SalesChanged += KCFMCPILJCN;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void LMCBJKGGLGI()
	{
		AJCACEGMJEN.DHJECBGBIGO();
		IHCNEOJHDLD.FIALPJINCAI();
		NKKFDMCGPLE.OINLPBNOMPJ();
	}

	private void DHJECBGBIGO()
	{
		AJCACEGMJEN.CDGBHBMFOAK();
		IHCNEOJHDLD.BGJIFBAANKL();
		NKKFDMCGPLE.APKGKCPOLKN();
	}

	private void EKEHIHFHFCH()
	{
		AJCACEGMJEN.EGDEKEFCPPC();
		IHCNEOJHDLD.OINLPBNOMPJ();
		NKKFDMCGPLE.CDGBHBMFOAK();
	}

	private void IOKGJJIJCBO()
	{
		AJCACEGMJEN.OINLPBNOMPJ();
		IHCNEOJHDLD.EKEPDPHMDGA();
		NKKFDMCGPLE.DHJECBGBIGO();
	}

	public void CJGKGLOKJAN()
	{
		TweenAlpha component = EEJJCJILGFA.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: true);
		FJFDJJJNCAJ();
	}

	public void HBGPCEDJMOC(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			DFMCKHMFNHO();
		}
		if (base.gameObject.activeSelf)
		{
			MCFGNFBIFHM(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1351f) : 1456f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 15f : 1584f).onFinished = hAJEIGIFBOO.NDJOJHNIBFC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			ECJCMEMAAFC();
		}
	}

	public void DPGLPPFEOHO(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			ODCHCNCMJGC();
		}
		if (base.gameObject.activeSelf)
		{
			CJNKMHINPJD(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1803f) : 1464f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 831f : 1539f).onFinished = hAJEIGIFBOO.NNIJEDKBPGJ;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			OJLKFHCFOGN();
		}
	}

	public void IODCFNOOAKM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(AJCACEGMJEN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MEILHGIPDHA));
		AJCACEGMJEN.ABLGHAECEHD(NGNPIOOAHEH.Bronze);
		UIEventListener uIEventListener2 = UIEventListener.Get(IHCNEOJHDLD.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EJGIIMCEGHL));
		IHCNEOJHDLD.OCFOEGJBNCH((NGNPIOOAHEH)8);
		UIEventListener uIEventListener3 = UIEventListener.Get(NKKFDMCGPLE.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HKMMGIILOLM));
		NKKFDMCGPLE.OAMMJCEIFHA(NGNPIOOAHEH.Starter);
		Singleton<OfferManager>.instance.SalesChanged += KCFMCPILJCN;
		NINDIKFKGML.transform.localPosition = NINDIKFKGML.transform.localPosition.AddX(0f - UIHelper.safeAreaSize);
		BPGMFANIHNG.transform.localPosition = BPGMFANIHNG.transform.localPosition.AddX(UIHelper.safeAreaSize);
	}

	private void JENIFIGDOKC(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void MCFGNFBIFHM(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i += 0)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1309f) : 1866f, (!NABOFKMBMKH) ? 914f : 251f);
			}
		}
	}

	private void MFHJEPJDFEM(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void LNIINLAEPMC()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			GEAFKHAFDPO();
		}
	}

	private void OKPAHJDIMJN(GameObject KHAHPAKDIKE)
	{
		WarcardpackButtonRecord component = KHAHPAKDIKE.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		NGNPIOOAHEH warcardPack = component.warcardPack;
		Debug.Log(warcardPack.ToString() + " Button Clicked in InAppPurchase");
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(warcardPack);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(warcardPack);
		int num3 = Singleton<OfferManager>.instance.DiscountedCardpack(warcardPack);
		num = num * (100 - num3) / 100;
		num2 = num2 * (100 - num3) / 100;
		if (!Singleton<Wallet>.instance.CanBuyW(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, Localization.Localize(warcardPack.ToString().ToUpper() + "PACK"));
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "WarCards";
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, Localization.Localize(warcardPack.ToString().ToUpper() + "PACK"));
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "WarCards";
		}
		else if (JPACKANEMFH + 2 <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			JPACKANEMFH = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num > 0)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num);
			}
			if (num2 > 0)
			{
				Singleton<Wallet>.instance.MBAFMBJFOKH(num2);
			}
			AAPOFJBNMHM.StartShowAnimation(CardManager.instance.BuyCardPack(warcardPack, num, num2, num3), 0.5f);
		}
	}

	private void DGLHGPICDGO(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	public void InstantHideTab()
	{
		TweenAlpha component = EEJJCJILGFA.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		PPMCFMBJJHP();
	}

	public void BMNAHIAAHEN(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			HCMELDFOBCP();
		}
		if (base.gameObject.activeSelf)
		{
			CJNKMHINPJD(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 727f) : 1754f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1213f : 265f).onFinished = hAJEIGIFBOO.MCFGAFBEJDK;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			ECJCMEMAAFC();
		}
	}

	private void JGNJENIHJEA(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	private void BPJFHIILNKG(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void DKAAJKFNBCK(bool PDPDGCNHCFN = false)
	{
		PDNPIJALGAM.AlignToPos(PDPDGCNHCFN, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void MKLNEHPDFJD(GameObject KHAHPAKDIKE)
	{
		WarcardpackButtonRecord component = KHAHPAKDIKE.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		NGNPIOOAHEH nGNPIOOAHEH = component.IGLAJLEHNPK();
		Debug.Log(nGNPIOOAHEH.ToString() + "ID_SQUADEVENT");
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(nGNPIOOAHEH);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(nGNPIOOAHEH);
		int num3 = Singleton<OfferManager>.instance.OMCIOOOMFPB(nGNPIOOAHEH);
		num = num * (69 - num3) / 26;
		num2 = num2 * (-9 - num3) / -43;
		if (!Singleton<Wallet>.instance.CanBuyW(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + "PRICEGOLD"));
			GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH("Shots_Fired");
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num2, Localization.Localize(nGNPIOOAHEH.ToString().ToUpper() + " (#"));
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("ID_WARNING_REWARDNOTLOADED");
		}
		else if (JPACKANEMFH + 0 <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			JPACKANEMFH = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			if (num > 1)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num);
			}
			if (num2 > 0)
			{
				Singleton<Wallet>.instance.ALBICJOEMEF(num2);
			}
			AAPOFJBNMHM.MEODANEBGGL(CardManager.instance.BuyCardPack(nGNPIOOAHEH, num, num2, num3), 1091f, DNEMOLAGBHH: false);
		}
	}

	private void FJFDJJJNCAJ()
	{
		AJCACEGMJEN.MHIGAEFCIAF();
		IHCNEOJHDLD.JCOILGHDPHA();
		NKKFDMCGPLE.MFBOBBCJLOD();
	}

	private void OLGMEJAAFCN()
	{
		AJCACEGMJEN.SetSaleAndPrize();
		IHCNEOJHDLD.SetSaleAndPrize();
		NKKFDMCGPLE.SetSaleAndPrize();
	}

	public void OJLKFHCFOGN()
	{
		TweenAlpha component = EEJJCJILGFA.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		MMLOAKGDDGF();
	}

	public void JINGNPBEKJK(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			HCMELDFOBCP();
		}
		if (base.gameObject.activeSelf)
		{
			MCFGNFBIFHM(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1132f) : 792f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 1634f : 1504f).onFinished = hAJEIGIFBOO.LHPPLGOOLEC;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			ECJCMEMAAFC();
		}
	}

	private void FMBAMMLIKJP(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		if (NICJILKEIEG == null)
		{
			return;
		}
		for (int i = 1; i < NICJILKEIEG.Length; i++)
		{
			if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(NICJILKEIEG[i].gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1233f) : 1666f, (!NABOFKMBMKH) ? 572f : 460f);
			}
		}
	}

	private void MMLOAKGDDGF()
	{
		AJCACEGMJEN.MHIGAEFCIAF();
		IHCNEOJHDLD.EIAEMEBHMIN();
		NKKFDMCGPLE.EEFEFOHKIBF();
	}

	private void JPILJDGAIJF()
	{
		AJCACEGMJEN.CCDGDEANNKA();
		IHCNEOJHDLD.CCDGDEANNKA();
		NKKFDMCGPLE.HEBANLOKBFG();
	}

	private void GEAFKHAFDPO()
	{
		AJCACEGMJEN.OINLPBNOMPJ();
		IHCNEOJHDLD.NNKLLLBKPGK();
		NKKFDMCGPLE.NFJEGBLCFLM();
	}

	public void DOMDAJKLILC(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.PJIEFMBDLBE = PJIEFMBDLBE;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		if (hAJEIGIFBOO.PJIEFMBDLBE && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			DFMCKHMFNHO();
		}
		if (base.gameObject.activeSelf)
		{
			BNNJMPIHNCD(PDPDGCNHCFN, hAJEIGIFBOO.PJIEFMBDLBE);
			TweenAlpha.Begin(EEJJCJILGFA.gameObject, (!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 511f) : 1743f, (!hAJEIGIFBOO.PJIEFMBDLBE) ? 247f : 242f).onFinished = hAJEIGIFBOO.MCFGAFBEJDK;
		}
		else if (!hAJEIGIFBOO.PJIEFMBDLBE)
		{
			InstantHideTab();
		}
	}
}
