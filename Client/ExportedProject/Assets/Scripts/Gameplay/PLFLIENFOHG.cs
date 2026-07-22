using UnityEngine;

public class PLFLIENFOHG : HHFHFANGCEJ
{
	private LevelBehaviour IFFDIHCPKFE;

	public virtual bool EDAPBDMGLLB()
	{
		return !base.HFDGKLFCBLE() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void DAOFPMOAIPI()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual bool FBEIFCNCMHA()
	{
		return !base.HFDGKLFCBLE() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool LPPEBCNNKBB()
	{
		return base.LMMGABHMGLK() && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool KHEGOOGPFJG()
	{
		return !base.LMMGABHMGLK() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void GCJGIELEEML()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual bool ICOHAEDHGPJ()
	{
		return !base.KGPPDBFOGOK() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void NBBAANHAAKK()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual void EKNDHCNIJFG()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual bool NNMLIPBBNCG()
	{
		return !base.COGGIIALJOP() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public PLFLIENFOHG(LevelBehaviour IOIKKIIFOCB)
		: base($"UnitReadyForPromotion {IOIKKIIFOCB.unitName} {IOIKKIIFOCB.upgradeSlots.actualTier}", NKHJBLBAAEB.UnitReadyForPromotion)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		Debug.Log("About to show Unit Ready For Promotion - " + IFFDIHCPKFE.unitName);
	}

	public virtual void LIEAKPFPAJD()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void GBEBFIDEOHH()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual void GLMKGLKCDAL()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual void CALBGDIEDGA()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual bool AAHDLMKHFEJ()
	{
		return base.COGGIIALJOP() && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void FPGMPPJCIJJ()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual bool GOKGFOHGOPK()
	{
		return !base.COGGIIALJOP() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool IJIEHGGEHGF()
	{
		return base.NIJOCMMLCGG() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void FLMALOGGOBN()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void JOGFDHFOOBC()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual void BLFNIFFFAIJ()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual bool CGLPAKMEAKH()
	{
		return base.NIJOCMMLCGG() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool GGJPOBFBDGK()
	{
		return !base.COGGIIALJOP() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool PBFKNEGHJEP()
	{
		return !base.COGGIIALJOP() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void ECBMHNDPENI()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual bool PNHJDKDEFBB()
	{
		return base.COGGIIALJOP() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void DCJICMIMPJE()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual bool EPJKLKDIKLC()
	{
		return !base.NIJOCMMLCGG() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void EPHMECKBGAA()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void BBOHJOFMLDI()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual bool FEDGBAPLOMA()
	{
		return base.COGGIIALJOP() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool ECOIOFPKJKN()
	{
		return !base.COGGIIALJOP() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool OJGAGBFNONM()
	{
		return base.COGGIIALJOP() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool GPKIAHPDMNI()
	{
		return base.HFDGKLFCBLE() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void EFBEJJEIPEG()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual bool FKCJALELEMP()
	{
		return base.LMMGABHMGLK() && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool IGIJDJBDIKC()
	{
		return !base.NIJOCMMLCGG() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void MNLAIHAPJOA()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual void BJGDGMDOKLH()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void DLNGGGOEDLL()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual void ECCAFEHCIFM()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual bool AHOIBCIKMIO()
	{
		return base.HFDGKLFCBLE() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool CBFJKLANLKM()
	{
		return base.LMMGABHMGLK() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool KPENDPGFBIG()
	{
		return !base.HFDGKLFCBLE() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void HDKCFAMJBBO()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual bool JJOJIHADCCI()
	{
		return !base.COGGIIALJOP() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void JCJFMHGNIOF()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void NNPILDOKNJO()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual bool PMGCBBAJICD()
	{
		return !base.COGGIIALJOP() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void LBHAHNFALLB()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual bool EDLHGHFAJIK()
	{
		return base.LMMGABHMGLK() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool GGAINHLJBDJ()
	{
		return !base.NIJOCMMLCGG() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool FODAIHIACCC()
	{
		return base.COGGIIALJOP() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void KHJGCKMOFBE()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual void KHCMODPGHNI()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual void NBGFNLOCPAD()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual void GKKFPJHEEDG()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual bool BFLHKFNIBLP()
	{
		return base.KGPPDBFOGOK() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void DJNMPLKPENF()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void FHCAAHNLEDE()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual void EOEDEJKJKMN()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual bool HBLGLFPJGBA()
	{
		return !base.HFDGKLFCBLE() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void JEDGCOMDEKM()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void DPDNJFAKNCM()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public override bool LMMGABHMGLK()
	{
		return !base.HFDGKLFCBLE() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool BNCDEKCGALJ()
	{
		return base.NIJOCMMLCGG() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void KGEEDMONDMK()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual bool FOJKCHKMDII()
	{
		return !base.LMMGABHMGLK() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void PLCBOLBMJKA()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void EHPIMALJLPB()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual bool CLMODPJPIIL()
	{
		return base.HFDGKLFCBLE() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void HONPFADFFDP()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual void KHCIMEFCJFC()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.IOAICJBKOIP(IFFDIHCPKFE);
	}

	public virtual void NFFMGBDNDLG()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.OAAABGFLAFG(IFFDIHCPKFE);
	}

	public virtual bool IGNGLCHFKJJ()
	{
		return !base.KGPPDBFOGOK() || !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool APLCMGCHBDI()
	{
		return base.COGGIIALJOP() && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public override bool HFDGKLFCBLE()
	{
		return base.HFDGKLFCBLE() && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool KPCPODCDIFF()
	{
		return !base.LMMGABHMGLK() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual bool JFFCODGMPLO()
	{
		return !base.LMMGABHMGLK() || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void IECHFELOIIO()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}

	public virtual bool ELKIOMMLJHF()
	{
		return base.NIJOCMMLCGG() && GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}

	public virtual void GCLFBCIKNAH()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(IFFDIHCPKFE);
	}
}
