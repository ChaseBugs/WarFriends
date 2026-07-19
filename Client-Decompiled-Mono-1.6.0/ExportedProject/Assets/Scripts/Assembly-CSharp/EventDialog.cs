using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EventDialog : GuiElementSingle<EventDialog>, PAIIOKBBHBC
{
	private sealed class FLCNNIBJNDM : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal DatabasePlayer HAGGALMAHKP;

		internal EventDialog BJGCPDNMHDH;

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

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.BOKMFOEFHAP(HAGGALMAHKP, false, PlayerTexturePool.DFJJOANIJID.Card));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(false);
				BJGCPDNMHDH.mPlayerVisual.DJPNDAICDPN(Singleton<ArmyPreviewCamera>.instance.GFLEFLJCFBA());
				BJGCPDNMHDH.mPlayerVisual.UpdateIcon();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.BOKMFOEFHAP(HAGGALMAHKP, true, PlayerTexturePool.DFJJOANIJID.Card));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(true);
				BJGCPDNMHDH.mPlayerVisual.EIKJEGHELNK(Singleton<ArmyPreviewCamera>.instance.NNHNDJLBFMH());
				BJGCPDNMHDH.mPlayerVisual.GEPDJCOHDNH();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CAEHLCHOPMO(HAGGALMAHKP, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(false);
				BJGCPDNMHDH.mPlayerVisual.ECKBKNCJLOC(Singleton<ArmyPreviewCamera>.instance.LPNCCMCJJEK());
				BJGCPDNMHDH.mPlayerVisual.GPHGDAKLAJK();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CreateHiresPlayerTexture(HAGGALMAHKP, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(true);
				BJGCPDNMHDH.mPlayerVisual.GJHFCKMAMIE(Singleton<ArmyPreviewCamera>.instance.LPNCCMCJJEK());
				BJGCPDNMHDH.mPlayerVisual.GPHGDAKLAJK();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.BOKMFOEFHAP(HAGGALMAHKP));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(true);
				BJGCPDNMHDH.mPlayerVisual.DHDPJLAPAPO(Singleton<ArmyPreviewCamera>.instance.NNHNDJLBFMH());
				BJGCPDNMHDH.mPlayerVisual.BFKPPMIKNAA();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.NNDKLFKGDEK(HAGGALMAHKP));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(false);
				BJGCPDNMHDH.mPlayerVisual.FBGDPCPIKMI(Singleton<ArmyPreviewCamera>.instance.GetHiresPlayerTexture());
				BJGCPDNMHDH.mPlayerVisual.ECAFLDEFKKB();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CAEHLCHOPMO(HAGGALMAHKP, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(false);
				BJGCPDNMHDH.mPlayerVisual.OLJPGNNKCKI(Singleton<ArmyPreviewCamera>.instance.NNHNDJLBFMH());
				BJGCPDNMHDH.mPlayerVisual.IFPLAMJKIKH();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CAEHLCHOPMO(HAGGALMAHKP, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(false);
				BJGCPDNMHDH.mPlayerVisual.FBGDPCPIKMI(Singleton<ArmyPreviewCamera>.instance.GetHiresPlayerTexture());
				BJGCPDNMHDH.mPlayerVisual.IFPLAMJKIKH();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.BOKMFOEFHAP(HAGGALMAHKP, false, PlayerTexturePool.DFJJOANIJID.Card));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(false);
				BJGCPDNMHDH.mPlayerVisual.JIBFCGECCFI(Singleton<ArmyPreviewCamera>.instance.NNHNDJLBFMH());
				BJGCPDNMHDH.mPlayerVisual.HJHOBLMEJEH();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public FLCNNIBJNDM()
		{
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CAEHLCHOPMO(HAGGALMAHKP, true, PlayerTexturePool.DFJJOANIJID.Card));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(true);
				BJGCPDNMHDH.mPlayerVisual.EIKJEGHELNK(Singleton<ArmyPreviewCamera>.instance.NNHNDJLBFMH());
				BJGCPDNMHDH.mPlayerVisual.HJHOBLMEJEH();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CreateHiresPlayerTexture(HAGGALMAHKP, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(true);
				BJGCPDNMHDH.mPlayerVisual.avatar = Singleton<ArmyPreviewCamera>.instance.GetHiresPlayerTexture();
				BJGCPDNMHDH.mPlayerVisual.UpdateIcon();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.BOKMFOEFHAP(HAGGALMAHKP));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(true);
				BJGCPDNMHDH.mPlayerVisual.KHIPFLOFKMC(Singleton<ArmyPreviewCamera>.instance.NNHNDJLBFMH());
				BJGCPDNMHDH.mPlayerVisual.GPHGDAKLAJK();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CAEHLCHOPMO(HAGGALMAHKP, false, PlayerTexturePool.DFJJOANIJID.Card));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(true);
				BJGCPDNMHDH.mPlayerVisual.GJHFCKMAMIE(Singleton<ArmyPreviewCamera>.instance.LPNCCMCJJEK());
				BJGCPDNMHDH.mPlayerVisual.GGLBLHKGCAO();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HAGGALMAHKP = new DatabasePlayer();
				HAGGALMAHKP.playerVisuals = NNOFPAGLFMM.BHGDDCDEJJA;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.BOKMFOEFHAP(HAGGALMAHKP, false, PlayerTexturePool.DFJJOANIJID.Card));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.mPlayerVisual.gameObject.SetActive(false);
				BJGCPDNMHDH.mPlayerVisual.KHIPFLOFKMC(Singleton<ArmyPreviewCamera>.instance.GFLEFLJCFBA());
				BJGCPDNMHDH.mPlayerVisual.GPHGDAKLAJK();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}
	}

	[Header("Header")]
	[SerializeField]
	private UISprite[] mBackgroundGlows;

	[SerializeField]
	private UILabel mHeaderLabel;

	[SerializeField]
	private UILabel mHeaderTimer;

	[Header("Particles")]
	[SerializeField]
	private ParticleSystem mParticleFallingSnow;

	[Header("Content")]
	[SerializeField]
	private PlayerIcon mPlayerVisual;

	[SerializeField]
	private ProgressEventPart mProgressEvent;

	[SerializeField]
	private DailyEventPart mDailyEvent;

	[Header("Bottom")]
	[SerializeField]
	private GameObject mOkButton;

	private float JDPOMFBEFOI;

	public GameObject endEventPointsAnimationObject
	{
		get
		{
			return mProgressEvent.FGLAMAFNPFO.gameObject;
		}
	}

	public override void OnBack()
	{
		HEBILNGCGDN(base.gameObject);
	}

	private void IOFENCEKGHA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void MJDFJJNDMCB()
	{
		base.DoBeforeShowUp();
		mDailyEvent.OALKHLOOGFA();
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement NNDACKCPNGN()
	{
		return this;
	}

	[SpecialName]
	public GameObject FEOOBCMAPBH()
	{
		return mProgressEvent.FGLAMAFNPFO.gameObject;
	}

	public virtual void LHAGLPJNLFB()
	{
		base.DoBeforeShowUp();
		mDailyEvent.IPPKAIBNJJP();
	}

	private void LKDAOKDEDPN(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void BMMNJICILHJ()
	{
		mDailyEvent.NHLBCFPFHED();
		mProgressEvent.InitControls();
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LGHBBNPBHLH));
	}

	public virtual void NINGMLNMLLP()
	{
		mDailyEvent.NHLBCFPFHED();
		mProgressEvent.HOBEPBFPFKG();
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKDAOKDEDPN));
	}

	public GuiElement DDIIHKEFFNA()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		for (int i = 0; i < mBackgroundGlows.Length; i++)
		{
			mBackgroundGlows[i].color = NNOFPAGLFMM.KOOOIBMPADB;
		}
		mHeaderLabel.text = NNOFPAGLFMM.DDLNDBANBHK;
		MEJMLNDFDBP.COCBCFKJOJE(mHeaderLabel, 90f, 20f, 1000);
		mHeaderLabel.color = NNOFPAGLFMM.KOOOIBMPADB;
		mPlayerVisual.Reset();
		mPlayerVisual.gameObject.SetActive(false);
		StartCoroutine(GHDHBPDGONH());
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mParticleFallingSnow.Play();
		}
		mProgressEvent.InitGUIValues();
		mDailyEvent.InitGUIValues();
		JDPOMFBEFOI = 0.333f;
	}

	private void NKFFHNPCOIM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void MHIFDHGPDCK()
	{
		for (int i = 1; i < mBackgroundGlows.Length; i += 0)
		{
			mBackgroundGlows[i].color = NNOFPAGLFMM.KOOOIBMPADB;
		}
		mHeaderLabel.text = NNOFPAGLFMM.DDLNDBANBHK;
		MEJMLNDFDBP.COCBCFKJOJE(mHeaderLabel, 628f, 1175f, 149);
		mHeaderLabel.color = NNOFPAGLFMM.KOOOIBMPADB;
		mPlayerVisual.PDKPELBIAON();
		mPlayerVisual.gameObject.SetActive(false);
		StartCoroutine(GHDHBPDGONH());
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mParticleFallingSnow.Play();
		}
		mProgressEvent.InitGUIValues();
		mDailyEvent.BNPDALDLFFM();
		JDPOMFBEFOI = 933f;
	}

	public override void InitControls()
	{
		mDailyEvent.InitControls();
		mProgressEvent.InitControls();
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public GuiElement FEJMHFBCGDO()
	{
		return this;
	}

	[DebuggerHidden]
	private IEnumerator GHDHBPDGONH()
	{
		FLCNNIBJNDM fLCNNIBJNDM = new FLCNNIBJNDM();
		fLCNNIBJNDM.BJGCPDNMHDH = this;
		return fLCNNIBJNDM;
	}

	public virtual void FNNHJPMKDOM()
	{
		HEBILNGCGDN(base.gameObject);
	}

	private void DENOGDBNCAE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public GuiElement HLEIFPAMOON()
	{
		return this;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private IEnumerator HLEPEDADPIG()
	{
		FLCNNIBJNDM fLCNNIBJNDM = new FLCNNIBJNDM();
		fLCNNIBJNDM.BJGCPDNMHDH = this;
		return fLCNNIBJNDM;
	}

	public virtual void OALKHLOOGFA()
	{
		base.DoBeforeShowUp();
		mDailyEvent.IPPKAIBNJJP();
	}

	protected override void Update()
	{
		base.Update();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 0.333f)
		{
			JDPOMFBEFOI = 0f;
			if (EventAssignmentManager.instance.isEventActive)
			{
				mHeaderTimer.text = Localization.LocalizeFormat("ID_CUSTOMEVENTEND", NNOFPAGLFMM.MPLPGMMEGIB, MEJMLNDFDBP.CJCFPDLDMEK(EventAssignmentManager.instance.remainigTimeTillEnd, "ID_READYTIME", string.Empty));
			}
			else
			{
				mHeaderTimer.text = Localization.Localize("ID_ENDED");
			}
		}
	}

	private void LJADGDDPCHF(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void KLABPENJAHJ()
	{
		for (int i = 1; i < mBackgroundGlows.Length; i += 0)
		{
			mBackgroundGlows[i].color = NNOFPAGLFMM.KOOOIBMPADB;
		}
		mHeaderLabel.text = NNOFPAGLFMM.DDLNDBANBHK;
		MEJMLNDFDBP.COCBCFKJOJE(mHeaderLabel, 1766f, 503f, 159);
		mHeaderLabel.color = NNOFPAGLFMM.KOOOIBMPADB;
		mPlayerVisual.HJOCCDLNFLN();
		mPlayerVisual.gameObject.SetActive(true);
		StartCoroutine(GHDHBPDGONH());
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mParticleFallingSnow.Play();
		}
		mProgressEvent.OFCCACPEBHD();
		mDailyEvent.InitGUIValues();
		JDPOMFBEFOI = 1384f;
	}

	private void LGHBBNPBHLH(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		mDailyEvent.DoBeforeShowUp();
	}
}
