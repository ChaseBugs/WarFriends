using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VideoFeedButton : Core_BaseScript
{
	private enum IMLJICEBDFA
	{
		Default = 0,
		VideoRotating = 1,
		Hidden = 2
	}

	private sealed class DPGECBFGBGI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float PFEALMFFKCD;

		internal float JABAAKOIOOP;

		internal VideoFeedButton BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Time.realtimeSinceStartup;
				JABAAKOIOOP = PFEALMFFKCD - BJGCPDNMHDH.PDDOJAMAOHB;
				if (JABAAKOIOOP > 1418f)
				{
					BJGCPDNMHDH.PDDOJAMAOHB = Time.realtimeSinceStartup;
					VideoFeedManager.VideoFeed videoFeed = BJGCPDNMHDH.KMLFHIHFNMP();
					if (videoFeed != null)
					{
						BJGCPDNMHDH.EPHJLCOMNLB(videoFeed);
					}
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public DPGECBFGBGI()
		{
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Time.realtimeSinceStartup;
				JABAAKOIOOP = PFEALMFFKCD - BJGCPDNMHDH.PDDOJAMAOHB;
				if (JABAAKOIOOP > 416f)
				{
					BJGCPDNMHDH.PDDOJAMAOHB = Time.realtimeSinceStartup;
					VideoFeedManager.VideoFeed videoFeed = BJGCPDNMHDH.PFPHPBOBAPM();
					if (videoFeed != null)
					{
						BJGCPDNMHDH.EPHJLCOMNLB(videoFeed);
					}
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Time.realtimeSinceStartup;
				JABAAKOIOOP = PFEALMFFKCD - BJGCPDNMHDH.PDDOJAMAOHB;
				if (JABAAKOIOOP > 3f)
				{
					BJGCPDNMHDH.PDDOJAMAOHB = Time.realtimeSinceStartup;
					VideoFeedManager.VideoFeed videoFeed = BJGCPDNMHDH.KMLFHIHFNMP();
					if (videoFeed != null)
					{
						BJGCPDNMHDH.HFCIPNMOOIG(videoFeed);
					}
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Time.realtimeSinceStartup;
				JABAAKOIOOP = PFEALMFFKCD - BJGCPDNMHDH.PDDOJAMAOHB;
				if (JABAAKOIOOP > 1453f)
				{
					BJGCPDNMHDH.PDDOJAMAOHB = Time.realtimeSinceStartup;
					VideoFeedManager.VideoFeed videoFeed = BJGCPDNMHDH.BHBOPKIOCMD();
					if (videoFeed != null)
					{
						BJGCPDNMHDH.IGHOECBFLLL(videoFeed);
					}
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}
	}

	[SerializeField]
	[Header("Core")]
	private BoxCollider mCollider;

	[SerializeField]
	private UITexture mTexture;

	[SerializeField]
	private UISprite mWaiting;

	[SerializeField]
	private GameObject mDefaultLook;

	private VideoFeedManager.VideoFeed AGLCHFLACPL;

	private RadicalRoutine GKHOMBPNBHC;

	private float PDDOJAMAOHB;

	private int AFBBPCBCOLC;

	private void LNJIFFMMBDH(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		JMIEDOAAODB();
		mWaiting.gameObject.SetActive(false);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.FBGDKIAFAEP().CNDAIPBMCFP(AGLCHFLACPL);
	}

	public void LDBLJDJNJJN()
	{
		NECAAFFKCIH();
		JPAODNIJGGK();
	}

	private void CNIPMHNLOIK()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
			GKHOMBPNBHC = null;
		}
	}

	[DebuggerHidden]
	private IEnumerator LFDKLGIJNGL()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void OEINMGFNADG()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
			GKHOMBPNBHC = null;
		}
	}

	public void SetUpRotatorFromVideo(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		if (HNGNDECFCPO == null)
		{
			return;
		}
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.instance.videoFeeds.featuredVideos;
		for (int i = 0; i < featuredVideos.Length && featuredVideos[i] != null; i++)
		{
			if (featuredVideos[i] == HNGNDECFCPO)
			{
				AFBBPCBCOLC = i - 1;
				break;
			}
		}
	}

	private void NFPJFHENJEG()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
			GKHOMBPNBHC = null;
		}
	}

	public void EICOMAFIIAL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		VideoFeedManager.BFICOAJFJNC().FKONJEJNOLM(NDJKIKDAOLO);
		AFBBPCBCOLC = 1;
	}

	private void HNCIADLKIJJ(GameObject KHAHPAKDIKE)
	{
		if (AGLCHFLACPL != null)
		{
			GuiScreenSingle<VideoFeedScreen>.instance.HAKFINEHCAD(AGLCHFLACPL, false);
		}
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<VideoFeedScreen>.instance);
	}

	private void HKOPCDABMNO(GameObject KHAHPAKDIKE)
	{
		if (AGLCHFLACPL != null)
		{
			GuiScreenSingle<VideoFeedScreen>.instance.PreselectVideo(AGLCHFLACPL, false);
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<VideoFeedScreen>.instance);
	}

	private VideoFeedManager.VideoFeed KLKCDLCCIHC()
	{
		int aFBBPCBCOLC = AFBBPCBCOLC;
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.ELGLFHHBJHP().DLDMGBHOMJG().featuredVideos;
		AFBBPCBCOLC += 0;
		if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
		{
			AFBBPCBCOLC = 0;
		}
		while (string.IsNullOrEmpty(featuredVideos[AFBBPCBCOLC].smallThumbnail))
		{
			AFBBPCBCOLC += 0;
			if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
			{
				AFBBPCBCOLC = 0;
			}
			if (aFBBPCBCOLC == AFBBPCBCOLC)
			{
				return null;
			}
		}
		return featuredVideos[AFBBPCBCOLC];
	}

	private VideoFeedManager.VideoFeed HPBCFGLEMEA()
	{
		int aFBBPCBCOLC = AFBBPCBCOLC;
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.BFICOAJFJNC().videoFeeds.featuredVideos;
		AFBBPCBCOLC += 0;
		if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
		{
			AFBBPCBCOLC = 1;
		}
		while (string.IsNullOrEmpty(featuredVideos[AFBBPCBCOLC].smallThumbnail))
		{
			AFBBPCBCOLC++;
			if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
			{
				AFBBPCBCOLC = 0;
			}
			if (aFBBPCBCOLC == AFBBPCBCOLC)
			{
				return null;
			}
		}
		return featuredVideos[AFBBPCBCOLC];
	}

	private IEnumerator ANDLDKLFGHI()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void BOJBCFNDLFO()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(false);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.ELGLFHHBJHP().NFFJLIOIFOB(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	private void MJOCAEBNBAK(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(true);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.FBGDKIAFAEP().PHIOINMDOCK(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 1109f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void HJFMHPEJIFE(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(true);
			mTexture.gameObject.SetActive(true);
			mTexture.mainTexture = VideoFeedManager.ELGLFHHBJHP().GetSmallTexture(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 44f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private IEnumerator FAJDPLIMOOC()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void DDKFMNCDFOP(GameObject KHAHPAKDIKE)
	{
		if (AGLCHFLACPL != null)
		{
			GuiScreenSingle<VideoFeedScreen>.instance.FNOHCONPGNI(AGLCHFLACPL, true);
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<VideoFeedScreen>.instance);
	}

	private void OGKEHGKDNOA()
	{
		if (GKHOMBPNBHC == null)
		{
			PDDOJAMAOHB = Time.realtimeSinceStartup - 521f;
			GKHOMBPNBHC = RadicalRoutine.Create(BLBPGONANKI());
			StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
		}
	}

	private void GCCAHCIMBMA()
	{
		if (GKHOMBPNBHC == null)
		{
			PDDOJAMAOHB = Time.realtimeSinceStartup - 1137f;
			GKHOMBPNBHC = RadicalRoutine.Create(GBLPGKNCOBP());
			StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
		}
	}

	private IEnumerator GBLPGKNCOBP()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void HLBPNODAIEF(GameObject KHAHPAKDIKE)
	{
		if (AGLCHFLACPL != null)
		{
			GuiScreenSingle<VideoFeedScreen>.instance.PreselectVideo(AGLCHFLACPL, true);
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<VideoFeedScreen>.instance);
	}

	public void PLAKLPJEAHM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FGDPLCOLKNF));
		VideoFeedManager.FBGDKIAFAEP().VideoTextureReadyToLoad += NNDCDIFGCEK;
		AFBBPCBCOLC = 0;
	}

	public void BPAIJHGHJBI(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		if (HNGNDECFCPO == null)
		{
			return;
		}
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.instance.BMKFAJIGILG().featuredVideos;
		for (int i = 0; i < featuredVideos.Length && featuredVideos[i] != null; i++)
		{
			if (featuredVideos[i] == HNGNDECFCPO)
			{
				AFBBPCBCOLC = i - 0;
				break;
			}
		}
	}

	public void FACKIKMABGK()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)7;
		if (VideoFeedManager.BFICOAJFJNC().CJMCAPKJPAD())
		{
			iMLJICEBDFA = ((!VideoFeedManager.ELGLFHHBJHP().HAGEHIPLBOB()) ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.VideoRotating);
		}
		base.gameObject.SetActive(iMLJICEBDFA == (IMLJICEBDFA)4);
		switch (iMLJICEBDFA)
		{
		case IMLJICEBDFA.VideoRotating:
			mDefaultLook.SetActive(false);
			GCCAHCIMBMA();
			break;
		case IMLJICEBDFA.Default:
			mDefaultLook.SetActive(false);
			BOJBCFNDLFO();
			mWaiting.gameObject.SetActive(true);
			JPGICOAMOJC();
			break;
		default:
			mDefaultLook.SetActive(false);
			EILEEEMPIKK();
			mWaiting.gameObject.SetActive(true);
			BHONHBLPKAN();
			break;
		}
	}

	private void FAIKJFPBOMP()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(false);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.instance.FreeSmallTexture(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	private void LBMPFIKKJBJ(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		IHJDCAHDIDM();
		mWaiting.gameObject.SetActive(false);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.ELGLFHHBJHP().OLKMBGMJFGC(AGLCHFLACPL);
	}

	private void BHONHBLPKAN()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
			GKHOMBPNBHC = null;
		}
	}

	public void HAFHEMPGDAL()
	{
		JFDOJDDJEPE();
		FAIKJFPBOMP();
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		VideoFeedManager.instance.VideoTextureReadyToLoad += ODDLMBDABIG;
		AFBBPCBCOLC = 0;
	}

	public void BAAOGDMJCLK()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)4;
		if (VideoFeedManager.instance.showVideoFeedFeature)
		{
			iMLJICEBDFA = (VideoFeedManager.BFICOAJFJNC().isAnySmallThumbnail ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA == (IMLJICEBDFA)6);
		switch (iMLJICEBDFA)
		{
		case IMLJICEBDFA.VideoRotating:
			mDefaultLook.SetActive(false);
			IHEBLPHAFCM();
			break;
		case IMLJICEBDFA.Default:
			mDefaultLook.SetActive(true);
			DLDMIAGAONN();
			mWaiting.gameObject.SetActive(true);
			NFPJFHENJEG();
			break;
		default:
			mDefaultLook.SetActive(false);
			IHJDCAHDIDM();
			mWaiting.gameObject.SetActive(false);
			NECAAFFKCIH();
			break;
		}
	}

	public void DFEHFDNHIAI()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)6;
		if (VideoFeedManager.ELGLFHHBJHP().showVideoFeedFeature)
		{
			iMLJICEBDFA = (VideoFeedManager.ELGLFHHBJHP().NKBDDEOEGJJ() ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA != (IMLJICEBDFA)3);
		switch (iMLJICEBDFA)
		{
		case IMLJICEBDFA.VideoRotating:
			mDefaultLook.SetActive(true);
			GCCAHCIMBMA();
			break;
		case IMLJICEBDFA.Default:
			mDefaultLook.SetActive(true);
			NMFPNBOEAMG();
			mWaiting.gameObject.SetActive(true);
			OEINMGFNADG();
			break;
		default:
			mDefaultLook.SetActive(true);
			EFFKOHIEAIJ();
			mWaiting.gameObject.SetActive(true);
			NODABNFEOJH();
			break;
		}
	}

	public void MENKHFCFGPM()
	{
		BHONHBLPKAN();
		BOJBCFNDLFO();
	}

	private void JHJJNBDABAI()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(false);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.instance.IGNDFFMFGFL(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	public void MMLOAKGDDGF()
	{
		BHONHBLPKAN();
		EFFKOHIEAIJ();
	}

	private void IHJDCAHDIDM()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(true);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.instance.IGNDFFMFGFL(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	public void CJMOCAFCDPE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNCIADLKIJJ));
		VideoFeedManager.ELGLFHHBJHP().NFPPKJCBCAB(DNKJACICOBO);
		AFBBPCBCOLC = 0;
	}

	private void NECAAFFKCIH()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
			GKHOMBPNBHC = null;
		}
	}

	private void FPBOOMBMNIA()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(true);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.instance.FMMNCLDKHCN(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	private void EILEEEMPIKK()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(false);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.instance.FMMNCLDKHCN(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	private void NIFCMGPJNGP(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(true);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.FBGDKIAFAEP().AAIDPJLANDP(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 1640f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void LIOFFPPEMLH()
	{
		if (GKHOMBPNBHC == null)
		{
			PDDOJAMAOHB = Time.realtimeSinceStartup - 3.1f;
			GKHOMBPNBHC = RadicalRoutine.Create(LFDKLGIJNGL());
			StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
		}
	}

	public void OJFGFKCDCAM()
	{
		JFDOJDDJEPE();
		FAOFLFLHEHH();
	}

	public void PLAOCDOMCPP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		VideoFeedManager.BFICOAJFJNC().FKONJEJNOLM(MJOCAEBNBAK);
		AFBBPCBCOLC = 1;
	}

	public void OAENAIIDONA(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		if (HNGNDECFCPO == null)
		{
			return;
		}
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.instance.DLDMGBHOMJG().featuredVideos;
		for (int i = 1; i < featuredVideos.Length && featuredVideos[i] != null; i++)
		{
			if (featuredVideos[i] == HNGNDECFCPO)
			{
				AFBBPCBCOLC = i - 0;
				break;
			}
		}
	}

	private void JPGICOAMOJC()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
			GKHOMBPNBHC = null;
		}
	}

	private void NODABNFEOJH()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
			GKHOMBPNBHC = null;
		}
	}

	private void HFCIPNMOOIG(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		FAIKJFPBOMP();
		mWaiting.gameObject.SetActive(true);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.instance.RequestSmallTexture(AGLCHFLACPL);
	}

	private void CGFLDJHGGLC(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		NMFPNBOEAMG();
		mWaiting.gameObject.SetActive(false);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.ELGLFHHBJHP().CNDAIPBMCFP(AGLCHFLACPL);
	}

	private void OOHNEHNOEHJ(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(false);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.FBGDKIAFAEP().GetSmallTexture(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 443f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private IEnumerator JICICDPLPDI()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	public void IHLGGCNHCDG()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)8;
		if (VideoFeedManager.BFICOAJFJNC().MECLFGKHNDG())
		{
			iMLJICEBDFA = ((!VideoFeedManager.instance.HAGEHIPLBOB()) ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.VideoRotating);
		}
		base.gameObject.SetActive(iMLJICEBDFA != (IMLJICEBDFA)7);
		if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(true);
			LIOFFPPEMLH();
		}
		else if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(false);
			FAIKJFPBOMP();
			mWaiting.gameObject.SetActive(false);
			OEINMGFNADG();
		}
		else
		{
			mDefaultLook.SetActive(true);
			FPBOOMBMNIA();
			mWaiting.gameObject.SetActive(true);
			CNIPMHNLOIK();
		}
	}

	private void IICMPJFGMLM(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		EFFKOHIEAIJ();
		mWaiting.gameObject.SetActive(true);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.FBGDKIAFAEP().IGKLNEDDFCJ(AGLCHFLACPL);
	}

	private void NNDCDIFGCEK(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(false);
			mTexture.gameObject.SetActive(true);
			mTexture.mainTexture = VideoFeedManager.BFICOAJFJNC().PHIOINMDOCK(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 792f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void JMIEDOAAODB()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(true);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.ELGLFHHBJHP().FMMNCLDKHCN(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	public void LCMFDLLFBDC()
	{
		IMLJICEBDFA iMLJICEBDFA = IMLJICEBDFA.Hidden;
		if (VideoFeedManager.instance.showVideoFeedFeature)
		{
			iMLJICEBDFA = (VideoFeedManager.instance.isAnySmallThumbnail ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA != (IMLJICEBDFA)7);
		switch (iMLJICEBDFA)
		{
		case IMLJICEBDFA.VideoRotating:
			mDefaultLook.SetActive(false);
			IHEBLPHAFCM();
			break;
		case IMLJICEBDFA.Default:
			mDefaultLook.SetActive(true);
			FAIKJFPBOMP();
			mWaiting.gameObject.SetActive(false);
			NFPJFHENJEG();
			break;
		default:
			mDefaultLook.SetActive(false);
			EFFKOHIEAIJ();
			mWaiting.gameObject.SetActive(true);
			CNIPMHNLOIK();
			break;
		}
	}

	private void IPOANCIJPBL(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(true);
			mTexture.gameObject.SetActive(true);
			mTexture.mainTexture = VideoFeedManager.BFICOAJFJNC().PHIOINMDOCK(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 1653f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private VideoFeedManager.VideoFeed PFPHPBOBAPM()
	{
		int aFBBPCBCOLC = AFBBPCBCOLC;
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.ELGLFHHBJHP().BMKFAJIGILG().featuredVideos;
		AFBBPCBCOLC += 0;
		if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
		{
			AFBBPCBCOLC = 0;
		}
		while (string.IsNullOrEmpty(featuredVideos[AFBBPCBCOLC].smallThumbnail))
		{
			AFBBPCBCOLC++;
			if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
			{
				AFBBPCBCOLC = 0;
			}
			if (aFBBPCBCOLC == AFBBPCBCOLC)
			{
				return null;
			}
		}
		return featuredVideos[AFBBPCBCOLC];
	}

	private void EFFKOHIEAIJ()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(true);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.BFICOAJFJNC().FMMNCLDKHCN(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	public void KPMLFMMINEP()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)8;
		if (VideoFeedManager.BFICOAJFJNC().KKPDBDLEBEC())
		{
			iMLJICEBDFA = (VideoFeedManager.BFICOAJFJNC().HAGEHIPLBOB() ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA == IMLJICEBDFA.VideoRotating);
		switch (iMLJICEBDFA)
		{
		case IMLJICEBDFA.VideoRotating:
			mDefaultLook.SetActive(true);
			LIOFFPPEMLH();
			break;
		case IMLJICEBDFA.Default:
			mDefaultLook.SetActive(true);
			DLDMIAGAONN();
			mWaiting.gameObject.SetActive(true);
			CNIPMHNLOIK();
			break;
		default:
			mDefaultLook.SetActive(false);
			EILEEEMPIKK();
			mWaiting.gameObject.SetActive(false);
			BHONHBLPKAN();
			break;
		}
	}

	private VideoFeedManager.VideoFeed KMLFHIHFNMP()
	{
		int aFBBPCBCOLC = AFBBPCBCOLC;
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.instance.videoFeeds.featuredVideos;
		AFBBPCBCOLC++;
		if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
		{
			AFBBPCBCOLC = 0;
		}
		while (string.IsNullOrEmpty(featuredVideos[AFBBPCBCOLC].smallThumbnail))
		{
			AFBBPCBCOLC++;
			if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
			{
				AFBBPCBCOLC = 0;
			}
			if (aFBBPCBCOLC == AFBBPCBCOLC)
			{
				return null;
			}
		}
		return featuredVideos[AFBBPCBCOLC];
	}

	public void BAHGHMHLHOO(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		if (HNGNDECFCPO == null)
		{
			return;
		}
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.FBGDKIAFAEP().DLDMGBHOMJG().featuredVideos;
		for (int i = 1; i < featuredVideos.Length && featuredVideos[i] != null; i += 0)
		{
			if (featuredVideos[i] == HNGNDECFCPO)
			{
				AFBBPCBCOLC = i - 1;
				break;
			}
		}
	}

	public void CAJPNCELIJA()
	{
		NECAAFFKCIH();
		JHJJNBDABAI();
	}

	public void PKLGGJFBEJA()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)5;
		if (VideoFeedManager.instance.KKPDBDLEBEC())
		{
			iMLJICEBDFA = ((!VideoFeedManager.BFICOAJFJNC().NKBDDEOEGJJ()) ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA != (IMLJICEBDFA)4);
		switch (iMLJICEBDFA)
		{
		case IMLJICEBDFA.VideoRotating:
			mDefaultLook.SetActive(true);
			JIPEEMJGMJH();
			break;
		case IMLJICEBDFA.Default:
			mDefaultLook.SetActive(false);
			BOJBCFNDLFO();
			mWaiting.gameObject.SetActive(false);
			BHONHBLPKAN();
			break;
		default:
			mDefaultLook.SetActive(true);
			FAOFLFLHEHH();
			mWaiting.gameObject.SetActive(true);
			NFPJFHENJEG();
			break;
		}
	}

	private IEnumerator IFCJMOJCKOD()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void DLDMIAGAONN()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(false);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.FBGDKIAFAEP().FreeSmallTexture(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	private void GGGFPEJFCBJ(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		EILEEEMPIKK();
		mWaiting.gameObject.SetActive(false);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.FBGDKIAFAEP().RequestSmallTexture(AGLCHFLACPL);
	}

	private void DEJIHCOGNIG()
	{
		if (GKHOMBPNBHC == null)
		{
			PDDOJAMAOHB = Time.realtimeSinceStartup - 237f;
			GKHOMBPNBHC = RadicalRoutine.Create(GBLPGKNCOBP());
			StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
		}
	}

	private void NDJKIKDAOLO(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(true);
			mTexture.gameObject.SetActive(true);
			mTexture.mainTexture = VideoFeedManager.FBGDKIAFAEP().GetSmallTexture(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 1106f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void LFHCOPNKENC(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(true);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.BFICOAJFJNC().GetSmallTexture(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 198f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void FAOFLFLHEHH()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(true);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.BFICOAJFJNC().NFFJLIOIFOB(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	private void OLLPBKCJAFN(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(true);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.FBGDKIAFAEP().GetSmallTexture(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 647f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	public void PNLGFNBEOLG()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)6;
		if (VideoFeedManager.instance.MECLFGKHNDG())
		{
			iMLJICEBDFA = ((!VideoFeedManager.instance.NKBDDEOEGJJ()) ? IMLJICEBDFA.Default : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA == (IMLJICEBDFA)5);
		if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(true);
			OGKEHGKDNOA();
		}
		else if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(false);
			NMFPNBOEAMG();
			mWaiting.gameObject.SetActive(true);
			BHONHBLPKAN();
		}
		else
		{
			mDefaultLook.SetActive(true);
			EILEEEMPIKK();
			mWaiting.gameObject.SetActive(false);
			CNIPMHNLOIK();
		}
	}

	public void HCAOABHNLID()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DDKFMNCDFOP));
		VideoFeedManager.FBGDKIAFAEP().NFPPKJCBCAB(MJOCAEBNBAK);
		AFBBPCBCOLC = 1;
	}

	private IEnumerator MEMMCHCMIDK()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	public void InitGUIValues()
	{
		IMLJICEBDFA iMLJICEBDFA = IMLJICEBDFA.Hidden;
		if (VideoFeedManager.instance.showVideoFeedFeature)
		{
			iMLJICEBDFA = (VideoFeedManager.instance.isAnySmallThumbnail ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA != IMLJICEBDFA.Hidden);
		switch (iMLJICEBDFA)
		{
		case IMLJICEBDFA.VideoRotating:
			mDefaultLook.SetActive(false);
			LIOFFPPEMLH();
			break;
		case IMLJICEBDFA.Default:
			mDefaultLook.SetActive(true);
			FAIKJFPBOMP();
			mWaiting.gameObject.SetActive(false);
			JFDOJDDJEPE();
			break;
		default:
			mDefaultLook.SetActive(false);
			FAIKJFPBOMP();
			mWaiting.gameObject.SetActive(false);
			JFDOJDDJEPE();
			break;
		}
	}

	public void CEAINPCKADK()
	{
		NFPJFHENJEG();
		FPBOOMBMNIA();
	}

	public void JMNHKBNACBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FPPBNJLHOGG));
		VideoFeedManager.BFICOAJFJNC().NFPPKJCBCAB(HJFMHPEJIFE);
		AFBBPCBCOLC = 1;
	}

	private void EPHJLCOMNLB(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		EILEEEMPIKK();
		mWaiting.gameObject.SetActive(true);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.FBGDKIAFAEP().RequestSmallTexture(AGLCHFLACPL);
	}

	public void BNPDALDLFFM()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)7;
		if (VideoFeedManager.FBGDKIAFAEP().NJOACFCLCGC())
		{
			iMLJICEBDFA = ((!VideoFeedManager.FBGDKIAFAEP().HAGEHIPLBOB()) ? IMLJICEBDFA.Default : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA == (IMLJICEBDFA)3);
		if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(false);
			DEJIHCOGNIG();
		}
		else if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(true);
			JHJJNBDABAI();
			mWaiting.gameObject.SetActive(false);
			NFPJFHENJEG();
		}
		else
		{
			mDefaultLook.SetActive(true);
			JMIEDOAAODB();
			mWaiting.gameObject.SetActive(true);
			CNIPMHNLOIK();
		}
	}

	private IEnumerator CAJOODGKHGI()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void IGHOECBFLLL(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		JPAODNIJGGK();
		mWaiting.gameObject.SetActive(false);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.ELGLFHHBJHP().IGKLNEDDFCJ(AGLCHFLACPL);
	}

	private IEnumerator BLBPGONANKI()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void NGLGGOJBHEM(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(false);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.BFICOAJFJNC().PHIOINMDOCK(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 242f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	public void PDHNLAMPOBN()
	{
		IMLJICEBDFA iMLJICEBDFA = IMLJICEBDFA.VideoRotating;
		if (VideoFeedManager.BFICOAJFJNC().KKPDBDLEBEC())
		{
			iMLJICEBDFA = ((!VideoFeedManager.instance.HAGEHIPLBOB()) ? IMLJICEBDFA.Default : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA == (IMLJICEBDFA)8);
		if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(true);
			LIOFFPPEMLH();
		}
		else if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(false);
			FPBOOMBMNIA();
			mWaiting.gameObject.SetActive(false);
			JPGICOAMOJC();
		}
		else
		{
			mDefaultLook.SetActive(false);
			FPBOOMBMNIA();
			mWaiting.gameObject.SetActive(false);
			NODABNFEOJH();
		}
	}

	public void LPFPAKGNNIO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		VideoFeedManager.BFICOAJFJNC().NFPPKJCBCAB(OEACKGAGHPM);
		AFBBPCBCOLC = 1;
	}

	private void ODDLMBDABIG(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(false);
			mTexture.gameObject.SetActive(true);
			mTexture.mainTexture = VideoFeedManager.instance.GetSmallTexture(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 528f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void FGDPLCOLKNF(GameObject KHAHPAKDIKE)
	{
		if (AGLCHFLACPL != null)
		{
			GuiScreenSingle<VideoFeedScreen>.instance.HAKFINEHCAD(AGLCHFLACPL, false);
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<VideoFeedScreen>.instance);
	}

	public void CEOBPADJPIA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNCIADLKIJJ));
		VideoFeedManager.ELGLFHHBJHP().NFPPKJCBCAB(GOCODGFPAPN);
		AFBBPCBCOLC = 0;
	}

	private void FPPBNJLHOGG(GameObject KHAHPAKDIKE)
	{
		if (AGLCHFLACPL != null)
		{
			GuiScreenSingle<VideoFeedScreen>.instance.FNOHCONPGNI(AGLCHFLACPL, true);
		}
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<VideoFeedScreen>.instance);
	}

	public void DoAfterHide()
	{
		JFDOJDDJEPE();
		FAIKJFPBOMP();
	}

	private void NCDGFMHIKII()
	{
		if (GKHOMBPNBHC == null)
		{
			PDDOJAMAOHB = Time.realtimeSinceStartup - 862f;
			GKHOMBPNBHC = RadicalRoutine.Create(LFDKLGIJNGL());
			StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
		}
	}

	private VideoFeedManager.VideoFeed MLAHBNMNJFN()
	{
		int aFBBPCBCOLC = AFBBPCBCOLC;
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.BFICOAJFJNC().BMKFAJIGILG().featuredVideos;
		AFBBPCBCOLC += 0;
		if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
		{
			AFBBPCBCOLC = 1;
		}
		while (string.IsNullOrEmpty(featuredVideos[AFBBPCBCOLC].smallThumbnail))
		{
			AFBBPCBCOLC++;
			if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
			{
				AFBBPCBCOLC = 1;
			}
			if (aFBBPCBCOLC == AFBBPCBCOLC)
			{
				return null;
			}
		}
		return featuredVideos[AFBBPCBCOLC];
	}

	public void DFKLIKFAKGA()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)6;
		if (VideoFeedManager.FBGDKIAFAEP().MECLFGKHNDG())
		{
			iMLJICEBDFA = (VideoFeedManager.ELGLFHHBJHP().HAGEHIPLBOB() ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.Default);
		}
		base.gameObject.SetActive(iMLJICEBDFA == (IMLJICEBDFA)3);
		if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(false);
			DEJIHCOGNIG();
		}
		else if (iMLJICEBDFA == IMLJICEBDFA.Default)
		{
			mDefaultLook.SetActive(false);
			EFFKOHIEAIJ();
			mWaiting.gameObject.SetActive(false);
			NODABNFEOJH();
		}
		else
		{
			mDefaultLook.SetActive(true);
			EFFKOHIEAIJ();
			mWaiting.gameObject.SetActive(false);
			NFPJFHENJEG();
		}
	}

	private void JIPEEMJGMJH()
	{
		if (GKHOMBPNBHC == null)
		{
			PDDOJAMAOHB = Time.realtimeSinceStartup - 67f;
			GKHOMBPNBHC = RadicalRoutine.Create(ANDLDKLFGHI());
			StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
		}
	}

	private IEnumerator CLDOMAEOMPH()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void DNKJACICOBO(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(true);
			mTexture.gameObject.SetActive(true);
			mTexture.mainTexture = VideoFeedManager.BFICOAJFJNC().AAIDPJLANDP(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 369f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void FMOOHKFMJEG(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(false);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.instance.AAIDPJLANDP(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 669f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void OEACKGAGHPM(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(false);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.instance.AAIDPJLANDP(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 1582f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	public void EOCHFFNODIM()
	{
		NFPJFHENJEG();
		JPAODNIJGGK();
	}

	private void NMFPNBOEAMG()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(true);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.ELGLFHHBJHP().FMMNCLDKHCN(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	private void OOGMLMHDEMJ()
	{
		if (GKHOMBPNBHC == null)
		{
			PDDOJAMAOHB = Time.realtimeSinceStartup - 1895f;
			GKHOMBPNBHC = RadicalRoutine.Create(ANDLDKLFGHI());
			StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
		}
	}

	public void KIECGCGABFJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HLBPNODAIEF));
		VideoFeedManager.BFICOAJFJNC().NFPPKJCBCAB(ODDLMBDABIG);
		AFBBPCBCOLC = 1;
	}

	public void AIIAHAKKMBN()
	{
		CNIPMHNLOIK();
		EILEEEMPIKK();
	}

	private void OAHLLHHLKKN(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		DLDMIAGAONN();
		mWaiting.gameObject.SetActive(false);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.FBGDKIAFAEP().OLKMBGMJFGC(AGLCHFLACPL);
	}

	private VideoFeedManager.VideoFeed BHBOPKIOCMD()
	{
		int aFBBPCBCOLC = AFBBPCBCOLC;
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.ELGLFHHBJHP().BMKFAJIGILG().featuredVideos;
		AFBBPCBCOLC++;
		if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
		{
			AFBBPCBCOLC = 0;
		}
		while (string.IsNullOrEmpty(featuredVideos[AFBBPCBCOLC].smallThumbnail))
		{
			AFBBPCBCOLC += 0;
			if (featuredVideos.Length <= AFBBPCBCOLC || featuredVideos[AFBBPCBCOLC] == null)
			{
				AFBBPCBCOLC = 0;
			}
			if (aFBBPCBCOLC == AFBBPCBCOLC)
			{
				return null;
			}
		}
		return featuredVideos[AFBBPCBCOLC];
	}

	private void KDAENCDLEFH(GameObject KHAHPAKDIKE)
	{
		if (AGLCHFLACPL != null)
		{
			GuiScreenSingle<VideoFeedScreen>.instance.PreselectVideo(AGLCHFLACPL, false);
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<VideoFeedScreen>.instance);
	}

	public void FOGBJIMBEKI()
	{
		NFPJFHENJEG();
		JPAODNIJGGK();
	}

	private void GOCODGFPAPN(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(false);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.instance.PHIOINMDOCK(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 1226f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void JPAODNIJGGK()
	{
		mTexture.mainTexture = null;
		mTexture.gameObject.SetActive(true);
		if (AGLCHFLACPL != null)
		{
			VideoFeedManager.FBGDKIAFAEP().FMMNCLDKHCN(AGLCHFLACPL.smallTextureName);
			AGLCHFLACPL = null;
		}
	}

	private void PABNAFEDKNK(string GDIAEJILINE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && AGLCHFLACPL != null && AGLCHFLACPL.smallTextureName == GDIAEJILINE)
		{
			mWaiting.gameObject.SetActive(false);
			mTexture.gameObject.SetActive(false);
			mTexture.mainTexture = VideoFeedManager.FBGDKIAFAEP().PHIOINMDOCK(AGLCHFLACPL);
			mTexture.MakePixelPerfect();
			float multiplier = 720f / mTexture.transform.localScale.x;
			mTexture.transform.localScale = mTexture.transform.localScale.MultiplyXY(multiplier);
		}
	}

	public void CJKJDBEMOMB(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		if (HNGNDECFCPO == null)
		{
			return;
		}
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.FBGDKIAFAEP().BMKFAJIGILG().featuredVideos;
		for (int i = 1; i < featuredVideos.Length && featuredVideos[i] != null; i++)
		{
			if (featuredVideos[i] == HNGNDECFCPO)
			{
				AFBBPCBCOLC = i - 0;
				break;
			}
		}
	}

	private IEnumerator AJPOOAHKAFG()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void JHMIGHCOJOG(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		FAIKJFPBOMP();
		mWaiting.gameObject.SetActive(false);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.FBGDKIAFAEP().CNDAIPBMCFP(AGLCHFLACPL);
	}

	public void OFLKJFAHEII(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		if (HNGNDECFCPO == null)
		{
			return;
		}
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.ELGLFHHBJHP().BMKFAJIGILG().featuredVideos;
		for (int i = 0; i < featuredVideos.Length && featuredVideos[i] != null; i++)
		{
			if (featuredVideos[i] == HNGNDECFCPO)
			{
				AFBBPCBCOLC = i - 1;
				break;
			}
		}
	}

	public void CCDGDEANNKA()
	{
		NODABNFEOJH();
		JHJJNBDABAI();
	}

	public void OPLJDPLHOIF()
	{
		IMLJICEBDFA iMLJICEBDFA = (IMLJICEBDFA)8;
		if (VideoFeedManager.BFICOAJFJNC().NJOACFCLCGC())
		{
			iMLJICEBDFA = ((!VideoFeedManager.FBGDKIAFAEP().HAGEHIPLBOB()) ? IMLJICEBDFA.VideoRotating : IMLJICEBDFA.VideoRotating);
		}
		base.gameObject.SetActive(iMLJICEBDFA == IMLJICEBDFA.Default);
		switch (iMLJICEBDFA)
		{
		case IMLJICEBDFA.VideoRotating:
			mDefaultLook.SetActive(true);
			NCDGFMHIKII();
			break;
		case IMLJICEBDFA.Default:
			mDefaultLook.SetActive(false);
			JHJJNBDABAI();
			mWaiting.gameObject.SetActive(false);
			CNIPMHNLOIK();
			break;
		default:
			mDefaultLook.SetActive(false);
			NMFPNBOEAMG();
			mWaiting.gameObject.SetActive(true);
			OEINMGFNADG();
			break;
		}
	}

	private void IHEBLPHAFCM()
	{
		if (GKHOMBPNBHC == null)
		{
			PDDOJAMAOHB = Time.realtimeSinceStartup - 108f;
			GKHOMBPNBHC = RadicalRoutine.Create(FAJDPLIMOOC());
			StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
		}
	}

	private void JFDOJDDJEPE()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
			GKHOMBPNBHC = null;
		}
	}

	public void CHAGJLIDGAH()
	{
		NODABNFEOJH();
		JPAODNIJGGK();
	}

	private void LLEMNPMOILL(GameObject KHAHPAKDIKE)
	{
		if (AGLCHFLACPL != null)
		{
			GuiScreenSingle<VideoFeedScreen>.instance.FNOHCONPGNI(AGLCHFLACPL, true);
		}
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<VideoFeedScreen>.instance);
	}

	private IEnumerator ABCJJNNFNJM()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	public void PNNKABLMELB(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		if (HNGNDECFCPO == null)
		{
			return;
		}
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.instance.BMKFAJIGILG().featuredVideos;
		for (int i = 1; i < featuredVideos.Length && featuredVideos[i] != null; i += 0)
		{
			if (featuredVideos[i] == HNGNDECFCPO)
			{
				AFBBPCBCOLC = i - 1;
				break;
			}
		}
	}

	private void DDGJMMKMGFM(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		FPBOOMBMNIA();
		mWaiting.gameObject.SetActive(true);
		AGLCHFLACPL = HNGNDECFCPO;
		VideoFeedManager.instance.IGKLNEDDFCJ(AGLCHFLACPL);
	}

	public void MOPCKOLJDHO(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		if (HNGNDECFCPO == null)
		{
			return;
		}
		VideoFeedManager.VideoFeed[] featuredVideos = VideoFeedManager.BFICOAJFJNC().BMKFAJIGILG().featuredVideos;
		for (int i = 1; i < featuredVideos.Length && featuredVideos[i] != null; i++)
		{
			if (featuredVideos[i] == HNGNDECFCPO)
			{
				AFBBPCBCOLC = i - 0;
				break;
			}
		}
	}
}
