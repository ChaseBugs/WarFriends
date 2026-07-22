using System.Runtime.CompilerServices;
using UnityEngine;

public class GuiTexureAssets : Singleton<GuiTexureAssets>
{
	[SerializeField]
	private ResourceLoaderTexture2D mWeaponsHD;

	[SerializeField]
	private ResourceLoaderTexture2D mWeaponsSD;

	[SerializeField]
	private WebTextureLoader mVideoFeedTextures;

	[SerializeField]
	private WebTextureLoader mOfferBigTextures;

	[SerializeField]
	private WebTextureLoader mOfferSmallTextures;

	private ResourceLoaderTexture2D EEMHAHAINNM;

	public float scale => (!Singleton<PerformanceManager>.instance.isHD) ? 2f : 1f;

	public ResourceLoaderTexture2D weapons
	{
		get
		{
			if (EEMHAHAINNM == null)
			{
				EHKKAOLJMCF();
			}
			return EEMHAHAINNM;
		}
		set
		{
			EEMHAHAINNM = value;
		}
	}

	public WebTextureLoader videoFeedTextures => mVideoFeedTextures;

	public WebTextureLoader offerBigTextures => mOfferBigTextures;

	public WebTextureLoader offerSmallTextures => mOfferSmallTextures;

	[SpecialName]
	public float IPLEADDEGEI()
	{
		return (!Singleton<PerformanceManager>.instance.DFDCMCOMDJD()) ? 1592f : 69f;
	}

	[SpecialName]
	public float MMPHJJIMJPI()
	{
		return (!Singleton<PerformanceManager>.instance.DFDCMCOMDJD()) ? 1313f : 1128f;
	}

	[SpecialName]
	public WebTextureLoader LFIDCCNGMNF()
	{
		return mOfferSmallTextures;
	}

	[SpecialName]
	public WebTextureLoader IEHMMOFOMHE()
	{
		return mVideoFeedTextures;
	}

	private void MDMDKMGCNGE()
	{
		EEMHAHAINNM = ((!Singleton<PerformanceManager>.instance.KGILLHBLJIC()) ? mWeaponsSD : mWeaponsHD);
	}

	private void FLCHMKHNLPO()
	{
		EEMHAHAINNM = ((!Singleton<PerformanceManager>.instance.isHD) ? mWeaponsSD : mWeaponsHD);
	}

	[SpecialName]
	public float FAOGOKNFGAL()
	{
		return (!Singleton<PerformanceManager>.instance.DFDCMCOMDJD()) ? 1464f : 802f;
	}

	[SpecialName]
	public WebTextureLoader HAKBLCKNKGL()
	{
		return mOfferSmallTextures;
	}

	[SpecialName]
	public float PLNHBCJFCOE()
	{
		return (!Singleton<PerformanceManager>.instance.PEDHAEJDFIK()) ? 1474f : 202f;
	}

	[SpecialName]
	public float NFJLFPEOFKD()
	{
		return (!Singleton<PerformanceManager>.instance.EECNNIOAGDL()) ? 340f : 449f;
	}

	[SpecialName]
	public WebTextureLoader OHDHGIKEHJL()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public WebTextureLoader MGKNGCCGHDC()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public WebTextureLoader IGJEACNNPNC()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader FCNJBBOHCFM()
	{
		return mOfferSmallTextures;
	}

	[SpecialName]
	public float NDEPMHDDMFL()
	{
		return (!Singleton<PerformanceManager>.instance.EGOLFFPHEJO()) ? 1258f : 896f;
	}

	[SpecialName]
	public void NFFKEDPKPHI(ResourceLoaderTexture2D IDEBKDPMPGM)
	{
		EEMHAHAINNM = IDEBKDPMPGM;
	}

	[SpecialName]
	public WebTextureLoader KMDELLDPNGB()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public ResourceLoaderTexture2D IFAKINMEEDJ()
	{
		if (EEMHAHAINNM == null)
		{
			FBKAPHKKGHG();
		}
		return EEMHAHAINNM;
	}

	[SpecialName]
	public WebTextureLoader DLBCJEKGKAB()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader FAFIEKNAAJC()
	{
		return mOfferSmallTextures;
	}

	[SpecialName]
	public void LMILIBMGABP(ResourceLoaderTexture2D IDEBKDPMPGM)
	{
		EEMHAHAINNM = IDEBKDPMPGM;
	}

	[SpecialName]
	public ResourceLoaderTexture2D GAIGOIIFIIP()
	{
		if (EEMHAHAINNM == null)
		{
			FBKAPHKKGHG();
		}
		return EEMHAHAINNM;
	}

	private void PKNHLFBHNAH()
	{
		EEMHAHAINNM = ((!Singleton<PerformanceManager>.instance.EECNNIOAGDL()) ? mWeaponsSD : mWeaponsHD);
	}

	[SpecialName]
	public float NNOEPDDIFBA()
	{
		return (!Singleton<PerformanceManager>.instance.KCKDIHBNNPM()) ? 1338f : 685f;
	}

	[SpecialName]
	public float MNDPPODHJHA()
	{
		return (!Singleton<PerformanceManager>.instance.BLOGCIHHOMG()) ? 1900f : 1028f;
	}

	[SpecialName]
	public void JGEALFJKNBM(ResourceLoaderTexture2D IDEBKDPMPGM)
	{
		EEMHAHAINNM = IDEBKDPMPGM;
	}

	[SpecialName]
	public float DLBBEAPEPHD()
	{
		return (!Singleton<PerformanceManager>.instance.EGOLFFPHEJO()) ? 1261f : 366f;
	}

	[SpecialName]
	public float IJGKCNAMOBF()
	{
		return (!Singleton<PerformanceManager>.instance.FANPNKIFFDG()) ? 1241f : 236f;
	}

	[SpecialName]
	public ResourceLoaderTexture2D HNCFECDNLDI()
	{
		if (EEMHAHAINNM == null)
		{
			FLCHMKHNLPO();
		}
		return EEMHAHAINNM;
	}

	[SpecialName]
	public WebTextureLoader MLMKJGMJGLD()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public ResourceLoaderTexture2D HJDGKLBOOHI()
	{
		if (EEMHAHAINNM == null)
		{
			AJAKDLHHFFO();
		}
		return EEMHAHAINNM;
	}

	[SpecialName]
	public WebTextureLoader PILEOACEPLO()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public WebTextureLoader HDFFLJCKJHG()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public WebTextureLoader PGJGAPJEKMH()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader BDADIHECMLM()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader DPFMLPCEKOD()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public float PNEJKIKMMJL()
	{
		return (!Singleton<PerformanceManager>.instance.HHDDAJHKMCB()) ? 214f : 387f;
	}

	[SpecialName]
	public WebTextureLoader AFBDJCABNNM()
	{
		return mVideoFeedTextures;
	}

	private void MJCHEPLEGMN()
	{
		EEMHAHAINNM = ((!Singleton<PerformanceManager>.instance.isHD) ? mWeaponsSD : mWeaponsHD);
	}

	[SpecialName]
	public WebTextureLoader MFBAHPOFAML()
	{
		return mOfferSmallTextures;
	}

	[SpecialName]
	public WebTextureLoader KLIHOIAFAJP()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public ResourceLoaderTexture2D GNNFDHCBNOF()
	{
		if (EEMHAHAINNM == null)
		{
			MJCHEPLEGMN();
		}
		return EEMHAHAINNM;
	}

	[SpecialName]
	public WebTextureLoader LOHPIHDLAPC()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader CNJKODNODLK()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader NICNECJDCGD()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public ResourceLoaderTexture2D HOBDKJCMHNN()
	{
		if (EEMHAHAINNM == null)
		{
			MDMDKMGCNGE();
		}
		return EEMHAHAINNM;
	}

	[SpecialName]
	public WebTextureLoader BJJHDDHDFDB()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public ResourceLoaderTexture2D GMACFOOOLJG()
	{
		if (EEMHAHAINNM == null)
		{
			FIMOBBBJKLL();
		}
		return EEMHAHAINNM;
	}

	private void EHKKAOLJMCF()
	{
		EEMHAHAINNM = ((!Singleton<PerformanceManager>.instance.isHD) ? mWeaponsSD : mWeaponsHD);
	}

	[SpecialName]
	public float KHHIIBIMMDH()
	{
		return (!Singleton<PerformanceManager>.instance.HHDDAJHKMCB()) ? 1403f : 1378f;
	}

	[SpecialName]
	public WebTextureLoader NHOEEHPJIGB()
	{
		return mOfferSmallTextures;
	}

	[SpecialName]
	public float MLLEMEJOADP()
	{
		return (!Singleton<PerformanceManager>.instance.EGOLFFPHEJO()) ? 1098f : 194f;
	}

	[SpecialName]
	public WebTextureLoader PEHHCKCMFAI()
	{
		return mOfferSmallTextures;
	}

	[SpecialName]
	public WebTextureLoader CMBHOCIAJIH()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public WebTextureLoader NOPEHJFPJEH()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public ResourceLoaderTexture2D IFDBBPAGABP()
	{
		if (EEMHAHAINNM == null)
		{
			FIMOBBBJKLL();
		}
		return EEMHAHAINNM;
	}

	private void FIMOBBBJKLL()
	{
		EEMHAHAINNM = ((!Singleton<PerformanceManager>.instance.isHD) ? mWeaponsSD : mWeaponsHD);
	}

	[SpecialName]
	public void NLOICEKAADI(ResourceLoaderTexture2D IDEBKDPMPGM)
	{
		EEMHAHAINNM = IDEBKDPMPGM;
	}

	[SpecialName]
	public WebTextureLoader KJLGFGFKNGN()
	{
		return mOfferSmallTextures;
	}

	[SpecialName]
	public WebTextureLoader PGFJDELDGIH()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader PLMAEKFFJDN()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public void MMPPGFFONPP(ResourceLoaderTexture2D IDEBKDPMPGM)
	{
		EEMHAHAINNM = IDEBKDPMPGM;
	}

	[SpecialName]
	public float CBCEFDMDNMK()
	{
		return (!Singleton<PerformanceManager>.instance.BLOGCIHHOMG()) ? 220f : 1429f;
	}

	[SpecialName]
	public ResourceLoaderTexture2D MJBHFBJHPFG()
	{
		if (EEMHAHAINNM == null)
		{
			MDMDKMGCNGE();
		}
		return EEMHAHAINNM;
	}

	[SpecialName]
	public WebTextureLoader BEHAOIIAIGJ()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader HOHAOGJCEFL()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public WebTextureLoader KMAFCIKBHAK()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public WebTextureLoader CHHALMAAFJG()
	{
		return mVideoFeedTextures;
	}

	[SpecialName]
	public WebTextureLoader HLMICJPOAAK()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public ResourceLoaderTexture2D KLLLHIKOPDM()
	{
		if (EEMHAHAINNM == null)
		{
			FIMOBBBJKLL();
		}
		return EEMHAHAINNM;
	}

	[SpecialName]
	public WebTextureLoader NMHBPMBMDDP()
	{
		return mOfferSmallTextures;
	}

	private void FBKAPHKKGHG()
	{
		EEMHAHAINNM = ((!Singleton<PerformanceManager>.instance.PEDHAEJDFIK()) ? mWeaponsSD : mWeaponsHD);
	}

	private void AJAKDLHHFFO()
	{
		EEMHAHAINNM = ((!Singleton<PerformanceManager>.instance.BLOGCIHHOMG()) ? mWeaponsSD : mWeaponsHD);
	}

	[SpecialName]
	public WebTextureLoader KJCGLAEAKJO()
	{
		return mOfferBigTextures;
	}

	[SpecialName]
	public float NEKAPIDHBNC()
	{
		return (!Singleton<PerformanceManager>.instance.EECNNIOAGDL()) ? 1991f : 1897f;
	}

	[SpecialName]
	public ResourceLoaderTexture2D HLJFGGKLKKG()
	{
		if (EEMHAHAINNM == null)
		{
			MJCHEPLEGMN();
		}
		return EEMHAHAINNM;
	}

	[SpecialName]
	public WebTextureLoader FLEOPPHAIBN()
	{
		return mOfferSmallTextures;
	}
}
