using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaNode : Core_BaseScript
{
	[SerializeField]
	private UISprite mCompleted;

	[SerializeField]
	private UISprite mReward;

	[SerializeField]
	private UISprite mCrown;

	[SerializeField]
	private UISprite mBorderAnimRight;

	[SerializeField]
	private UISprite mBorderAnimLeft;

	[SerializeField]
	private UISprite mOutline;

	[SerializeField]
	private UISprite mCompletedFill;

	[SerializeField]
	private BoxCollider mHint;

	private int KJPIMOPJMGB = -1;

	private bool CMGBGEJMKPJ;

	private Vector3 KGIEEOKCEBK = new Vector3(0f, 80f, -1f);

	private Vector3 PDOPIJMMIEE = new Vector3(64f, 59f, 1f);

	private Vector3 PBIPEIPANFL = new Vector3(77f, 90f, 1f);

	private Vector3 CAHEBEPHOAB = new Vector3(56f, 128f, 1f);

	[CompilerGenerated]
	private static UITweener.OnFinished LGJCBPOPCPA;

	private void OKOAMPAOEDP()
	{
		mCompleted.transform.localEulerAngles = new Vector3(1267f, 1269f, 576f);
		mCompleted.transform.localScale = PBIPEIPANFL;
		mCompleted.gameObject.SetActive(value: true);
		mCompletedFill.gameObject.SetActive(value: true);
		mCompletedFill.alpha = 1527f;
		TweenScale.Begin(mCompleted.gameObject, 1876f, mCompleted.transform.localScale.MultiplyXY(1177f));
		TweenScale.Begin(mCompletedFill.gameObject, 1387f, mCompleted.transform.localScale.MultiplyXY(1153f));
		TweenRotation.Begin(mCompleted.gameObject, 1990f, Quaternion.Euler(new Vector3(576f, 1169f, 1106f)), useAbsolute: true).onFinished = MKNPANADEOC;
	}

	private void MKGDPALNMPJ(UITweener BGIFAMFEKMH)
	{
		mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
		mBorderAnimRight.alpha = 1993f;
		mBorderAnimRight.gameObject.SetActive(value: false);
	}

	private void KIBJEGDLLGH(UITweener BDNLONKNPKM)
	{
		mCrown.alpha = 938f;
		mCompleted.transform.localEulerAngles = new Vector3(1557f, 1205f, 1987f);
		TweenScale.Begin(mCompletedFill.gameObject, 124f, PBIPEIPANFL);
		TweenScale.Begin(mCompleted.gameObject, 1733f, PBIPEIPANFL).onFinished = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
		};
		InvokeAfter(delegate
		{
			mBorderAnimLeft.gameObject.SetActive(value: true);
			mBorderAnimRight.gameObject.SetActive(value: true);
			mOutline.gameObject.SetActive(value: true);
			TweenAlpha.Begin(mBorderAnimLeft.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mBorderAnimRight.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mOutline.gameObject, 0.7f, 0.5f, 0f);
			TweenAlpha.Begin(mCompletedFill.gameObject, 0.25f, 0f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(mCompletedFill.gameObject, 0.4f, 0f).onFinished = delegate
				{
					mCompletedFill.gameObject.SetActive(value: false);
				};
			};
			TweenScale.Begin(mBorderAnimLeft.gameObject, 0.8f, mBorderAnimLeft.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
			{
				mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
				mBorderAnimLeft.alpha = 1f;
				mBorderAnimLeft.gameObject.SetActive(value: false);
			};
			TweenScale.Begin(mBorderAnimRight.gameObject, 0.8f, mBorderAnimRight.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
			{
				mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
				mBorderAnimRight.alpha = 1f;
				mBorderAnimRight.gameObject.SetActive(value: false);
			};
			TweenScale.Begin(mOutline.gameObject, 0.8f, mOutline.transform.localScale.MultiplyXY(6f)).onFinished = delegate
			{
				mOutline.transform.localScale = PBIPEIPANFL;
				mOutline.alpha = 0.5f;
				mOutline.gameObject.SetActive(value: false);
				mHint.gameObject.SetActive(value: false);
				if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM == IKPLPPFFDNI.CACDIELEJHK.None)
				{
					GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
				}
			};
		}, 602f);
	}

	public void SetEmpty()
	{
		mCrown.gameObject.SetActive(value: false);
		mCompleted.gameObject.SetActive(value: false);
		mReward.gameObject.SetActive(value: false);
		KJPIMOPJMGB = -1;
	}

	[CompilerGenerated]
	private void FJIFJJDJEFB()
	{
		mBorderAnimLeft.gameObject.SetActive(value: true);
		mBorderAnimRight.gameObject.SetActive(value: true);
		mOutline.gameObject.SetActive(value: true);
		TweenAlpha.Begin(mBorderAnimLeft.gameObject, 0.7f, 0f);
		TweenAlpha.Begin(mBorderAnimRight.gameObject, 0.7f, 0f);
		TweenAlpha.Begin(mOutline.gameObject, 0.7f, 0.5f, 0f);
		TweenAlpha.Begin(mCompletedFill.gameObject, 0.25f, 0f, 1f).onFinished = delegate
		{
			TweenAlpha.Begin(mCompletedFill.gameObject, 0.4f, 0f).onFinished = delegate
			{
				mCompletedFill.gameObject.SetActive(value: false);
			};
		};
		TweenScale.Begin(mBorderAnimLeft.gameObject, 0.8f, mBorderAnimLeft.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
		{
			mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
			mBorderAnimLeft.alpha = 1f;
			mBorderAnimLeft.gameObject.SetActive(value: false);
		};
		TweenScale.Begin(mBorderAnimRight.gameObject, 0.8f, mBorderAnimRight.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
		{
			mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
			mBorderAnimRight.alpha = 1f;
			mBorderAnimRight.gameObject.SetActive(value: false);
		};
		TweenScale.Begin(mOutline.gameObject, 0.8f, mOutline.transform.localScale.MultiplyXY(6f)).onFinished = delegate
		{
			mOutline.transform.localScale = PBIPEIPANFL;
			mOutline.alpha = 0.5f;
			mOutline.gameObject.SetActive(value: false);
			mHint.gameObject.SetActive(value: false);
			if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM == IKPLPPFFDNI.CACDIELEJHK.None)
			{
				GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
			}
		};
	}

	private static void LINOJFEADIE(UITweener GLBBEDEHFOP)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-108), 1992f);
	}

	[CompilerGenerated]
	private void HMGIBJMFPKM(UITweener POLCDJOBFKG)
	{
		FAFHEANBLDG();
	}

	private void MODPJIBHEDC(UITweener POLCDJOBFKG)
	{
		mCrown.transform.localPosition = KGIEEOKCEBK;
	}

	private void FLIGIKLICGE(GameObject KHAHPAKDIKE)
	{
		if (KJPIMOPJMGB >= 0)
		{
			GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.BKPNOABFMGN[KJPIMOPJMGB].HintClicked(base.gameObject);
		}
	}

	[CompilerGenerated]
	private void GLLIOOIJNAO(UITweener BGIFAMFEKMH)
	{
		mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
		mBorderAnimRight.alpha = 1f;
		mBorderAnimRight.gameObject.SetActive(value: false);
	}

	[CompilerGenerated]
	private void ECPPKJEEBDL(UITweener PGJNJADMJEH)
	{
		mReward.transform.localScale = PDOPIJMMIEE;
		mReward.gameObject.SetActive(value: false);
		TweenRotation.Begin(mCompleted.gameObject, 0.3f, Quaternion.Euler(new Vector3(0f, 360f, 0f))).onFinished = delegate
		{
			mCrown.alpha = 1f;
			mCompleted.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			TweenScale.Begin(mCompletedFill.gameObject, 0.3f, PBIPEIPANFL);
			TweenScale.Begin(mCompleted.gameObject, 0.3f, PBIPEIPANFL).onFinished = delegate
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
			};
			InvokeAfter(delegate
			{
				mBorderAnimLeft.gameObject.SetActive(value: true);
				mBorderAnimRight.gameObject.SetActive(value: true);
				mOutline.gameObject.SetActive(value: true);
				TweenAlpha.Begin(mBorderAnimLeft.gameObject, 0.7f, 0f);
				TweenAlpha.Begin(mBorderAnimRight.gameObject, 0.7f, 0f);
				TweenAlpha.Begin(mOutline.gameObject, 0.7f, 0.5f, 0f);
				TweenAlpha.Begin(mCompletedFill.gameObject, 0.25f, 0f, 1f).onFinished = delegate
				{
					TweenAlpha.Begin(mCompletedFill.gameObject, 0.4f, 0f).onFinished = delegate
					{
						mCompletedFill.gameObject.SetActive(value: false);
					};
				};
				TweenScale.Begin(mBorderAnimLeft.gameObject, 0.8f, mBorderAnimLeft.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
				{
					mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
					mBorderAnimLeft.alpha = 1f;
					mBorderAnimLeft.gameObject.SetActive(value: false);
				};
				TweenScale.Begin(mBorderAnimRight.gameObject, 0.8f, mBorderAnimRight.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
				{
					mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
					mBorderAnimRight.alpha = 1f;
					mBorderAnimRight.gameObject.SetActive(value: false);
				};
				TweenScale.Begin(mOutline.gameObject, 0.8f, mOutline.transform.localScale.MultiplyXY(6f)).onFinished = delegate
				{
					mOutline.transform.localScale = PBIPEIPANFL;
					mOutline.alpha = 0.5f;
					mOutline.gameObject.SetActive(value: false);
					mHint.gameObject.SetActive(value: false);
					if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM == IKPLPPFFDNI.CACDIELEJHK.None)
					{
						GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
					}
				};
			}, 0.2f);
		};
	}

	public void PKLEKPOKDAB()
	{
		if (CMGBGEJMKPJ)
		{
			TweenAlpha.Begin(mCrown.gameObject, 490f, 1797f);
			TweenPosition.Begin(mCrown.gameObject, 142f, mCrown.transform.localPosition.ReplaceY(KGIEEOKCEBK.y + 323f), useLocal: false).onFinished = BLONBMNCBCB;
			TweenScale tweenScale = TweenScale.Begin(mReward.gameObject, 1065f, mReward.transform.localScale.MultiplyXY(1875f));
			tweenScale.delay = 1711f;
			tweenScale.onFinished = delegate
			{
				FAFHEANBLDG();
			};
		}
		else
		{
			DPPMCOEONAP();
		}
	}

	private void FAFHEANBLDG()
	{
		mCompleted.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
		mCompleted.transform.localScale = PBIPEIPANFL;
		mCompleted.gameObject.SetActive(value: true);
		mCompletedFill.gameObject.SetActive(value: true);
		mCompletedFill.alpha = 0f;
		TweenScale.Begin(mCompleted.gameObject, 0.15f, mCompleted.transform.localScale.MultiplyXY(3f));
		TweenScale.Begin(mCompletedFill.gameObject, 0.15f, mCompleted.transform.localScale.MultiplyXY(3f));
		TweenRotation.Begin(mCompleted.gameObject, 0.15f, Quaternion.Euler(new Vector3(0f, 180f, 0f))).onFinished = delegate
		{
			mReward.transform.localScale = PDOPIJMMIEE;
			mReward.gameObject.SetActive(value: false);
			TweenRotation.Begin(mCompleted.gameObject, 0.3f, Quaternion.Euler(new Vector3(0f, 360f, 0f))).onFinished = delegate
			{
				mCrown.alpha = 1f;
				mCompleted.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				TweenScale.Begin(mCompletedFill.gameObject, 0.3f, PBIPEIPANFL);
				TweenScale.Begin(mCompleted.gameObject, 0.3f, PBIPEIPANFL).onFinished = delegate
				{
					SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
				};
				InvokeAfter(delegate
				{
					mBorderAnimLeft.gameObject.SetActive(value: true);
					mBorderAnimRight.gameObject.SetActive(value: true);
					mOutline.gameObject.SetActive(value: true);
					TweenAlpha.Begin(mBorderAnimLeft.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mBorderAnimRight.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mOutline.gameObject, 0.7f, 0.5f, 0f);
					TweenAlpha.Begin(mCompletedFill.gameObject, 0.25f, 0f, 1f).onFinished = delegate
					{
						TweenAlpha.Begin(mCompletedFill.gameObject, 0.4f, 0f).onFinished = delegate
						{
							mCompletedFill.gameObject.SetActive(value: false);
						};
					};
					TweenScale.Begin(mBorderAnimLeft.gameObject, 0.8f, mBorderAnimLeft.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
					{
						mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
						mBorderAnimLeft.alpha = 1f;
						mBorderAnimLeft.gameObject.SetActive(value: false);
					};
					TweenScale.Begin(mBorderAnimRight.gameObject, 0.8f, mBorderAnimRight.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
					{
						mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
						mBorderAnimRight.alpha = 1f;
						mBorderAnimRight.gameObject.SetActive(value: false);
					};
					TweenScale.Begin(mOutline.gameObject, 0.8f, mOutline.transform.localScale.MultiplyXY(6f)).onFinished = delegate
					{
						mOutline.transform.localScale = PBIPEIPANFL;
						mOutline.alpha = 0.5f;
						mOutline.gameObject.SetActive(value: false);
						mHint.gameObject.SetActive(value: false);
						if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM == IKPLPPFFDNI.CACDIELEJHK.None)
						{
							GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
						}
					};
				}, 0.2f);
			};
		};
	}

	[CompilerGenerated]
	private void KAKCHHBGBDC(UITweener BGIFAMFEKMH)
	{
		mOutline.transform.localScale = PBIPEIPANFL;
		mOutline.alpha = 0.5f;
		mOutline.gameObject.SetActive(value: false);
		mHint.gameObject.SetActive(value: false);
		if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM == IKPLPPFFDNI.CACDIELEJHK.None)
		{
			GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
		}
	}

	public void GMDCPIGMPDH()
	{
		if (CMGBGEJMKPJ)
		{
			TweenAlpha.Begin(mCrown.gameObject, 679f, 1299f);
			TweenPosition.Begin(mCrown.gameObject, 1910f, mCrown.transform.localPosition.ReplaceY(KGIEEOKCEBK.y + 577f), useLocal: false).onFinished = BLONBMNCBCB;
			TweenScale tweenScale = TweenScale.Begin(mReward.gameObject, 269f, mReward.transform.localScale.MultiplyXY(770f));
			tweenScale.delay = 1072f;
			tweenScale.onFinished = ACDEIJNJECC;
		}
		else
		{
			OKOAMPAOEDP();
		}
	}

	private void APNJKEBDACO(UITweener POLCDJOBFKG)
	{
		MOLJGHDOOHO();
	}

	private void EALEJPAFMFH(UITweener GPNIOOPDEFI)
	{
		TweenAlpha.Begin(mCompletedFill.gameObject, 1289f, 1929f).onFinished = delegate
		{
			mCompletedFill.gameObject.SetActive(value: false);
		};
	}

	private void FBEAHAHLHMK(UITweener POLCDJOBFKG)
	{
		mCrown.transform.localPosition = KGIEEOKCEBK;
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mHint.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FLIGIKLICGE));
	}

	protected virtual void NIAEEICNNHL()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mHint.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FLIGIKLICGE));
	}

	[CompilerGenerated]
	private void CLCEOAHINKA(UITweener POLCDJOBFKG)
	{
		mCrown.transform.localPosition = KGIEEOKCEBK;
	}

	private void HLFCNACPDNM(UITweener POLCDJOBFKG)
	{
		mCrown.transform.localPosition = KGIEEOKCEBK;
	}

	private void FFPFKAGNPOA(UITweener BDNLONKNPKM)
	{
		mCrown.alpha = 1804f;
		mCompleted.transform.localEulerAngles = new Vector3(1140f, 654f, 154f);
		TweenScale.Begin(mCompletedFill.gameObject, 1177f, PBIPEIPANFL);
		TweenScale.Begin(mCompleted.gameObject, 1160f, PBIPEIPANFL).onFinished = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
		};
		InvokeAfter(delegate
		{
			mBorderAnimLeft.gameObject.SetActive(value: true);
			mBorderAnimRight.gameObject.SetActive(value: true);
			mOutline.gameObject.SetActive(value: true);
			TweenAlpha.Begin(mBorderAnimLeft.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mBorderAnimRight.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mOutline.gameObject, 0.7f, 0.5f, 0f);
			TweenAlpha.Begin(mCompletedFill.gameObject, 0.25f, 0f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(mCompletedFill.gameObject, 0.4f, 0f).onFinished = delegate
				{
					mCompletedFill.gameObject.SetActive(value: false);
				};
			};
			TweenScale.Begin(mBorderAnimLeft.gameObject, 0.8f, mBorderAnimLeft.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
			{
				mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
				mBorderAnimLeft.alpha = 1f;
				mBorderAnimLeft.gameObject.SetActive(value: false);
			};
			TweenScale.Begin(mBorderAnimRight.gameObject, 0.8f, mBorderAnimRight.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
			{
				mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
				mBorderAnimRight.alpha = 1f;
				mBorderAnimRight.gameObject.SetActive(value: false);
			};
			TweenScale.Begin(mOutline.gameObject, 0.8f, mOutline.transform.localScale.MultiplyXY(6f)).onFinished = delegate
			{
				mOutline.transform.localScale = PBIPEIPANFL;
				mOutline.alpha = 0.5f;
				mOutline.gameObject.SetActive(value: false);
				mHint.gameObject.SetActive(value: false);
				if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM == IKPLPPFFDNI.CACDIELEJHK.None)
				{
					GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
				}
			};
		}, 48f);
	}

	public void FDLBGBADPDA()
	{
		mCrown.gameObject.SetActive(value: true);
		mCompleted.gameObject.SetActive(value: false);
		mReward.gameObject.SetActive(value: false);
		KJPIMOPJMGB = -1;
	}

	protected virtual void IOAEHDJGBJC()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mHint.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJGOGEJLCIA));
	}

	private void CENFGKKOHMG(UITweener BGIFAMFEKMH)
	{
		mOutline.transform.localScale = PBIPEIPANFL;
		mOutline.alpha = 603f;
		mOutline.gameObject.SetActive(value: true);
		mHint.gameObject.SetActive(value: false);
		if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM == IKPLPPFFDNI.CACDIELEJHK.None)
		{
			GuiScreenSingle<ArenaScreen>.instance.JEBEDIFMPEE();
		}
	}

	private void CKEPFBOCDEB(UITweener POLCDJOBFKG)
	{
		mCrown.transform.localPosition = KGIEEOKCEBK;
	}

	public void JBPEJJMHLMO()
	{
		if (CMGBGEJMKPJ)
		{
			TweenAlpha.Begin(mCrown.gameObject, 1982f, 691f);
			TweenPosition.Begin(mCrown.gameObject, 1520f, mCrown.transform.localPosition.ReplaceY(KGIEEOKCEBK.y + 1383f), useLocal: false).onFinished = delegate
			{
				mCrown.transform.localPosition = KGIEEOKCEBK;
			};
			TweenScale tweenScale = TweenScale.Begin(mReward.gameObject, 237f, mReward.transform.localScale.MultiplyXY(1951f));
			tweenScale.delay = 1667f;
			tweenScale.onFinished = APNJKEBDACO;
		}
		else
		{
			FAFHEANBLDG();
		}
	}

	[CompilerGenerated]
	private void HGGKLLHHPHN(UITweener GPNIOOPDEFI)
	{
		TweenAlpha.Begin(mCompletedFill.gameObject, 0.4f, 0f).onFinished = delegate
		{
			mCompletedFill.gameObject.SetActive(value: false);
		};
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mHint.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CLICGGMKOFO));
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mHint.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FLIGIKLICGE));
	}

	private void IPOLCKCMNNC(UITweener PGJNJADMJEH)
	{
		mReward.transform.localScale = PDOPIJMMIEE;
		mReward.gameObject.SetActive(value: false);
		TweenRotation.Begin(mCompleted.gameObject, 192f, Quaternion.Euler(new Vector3(961f, 183f, 1908f))).onFinished = KIBJEGDLLGH;
	}

	public void JDCDICOOBEH()
	{
		mCrown.gameObject.SetActive(value: false);
		mCompleted.gameObject.SetActive(value: false);
		mReward.gameObject.SetActive(value: true);
		KJPIMOPJMGB = -1;
	}

	[CompilerGenerated]
	private void JCKHKKPEANG(UITweener JLCPGEDKJGE)
	{
		mCompletedFill.gameObject.SetActive(value: false);
	}

	public void EBPDHNDHMAG()
	{
		mCrown.gameObject.SetActive(value: true);
		mCompleted.gameObject.SetActive(value: false);
		mReward.gameObject.SetActive(value: true);
		KJPIMOPJMGB = -1;
	}

	private void EDNBPALMLGO(UITweener POLCDJOBFKG)
	{
		FAFHEANBLDG();
	}

	private void CIHLGFDKHJK()
	{
		mBorderAnimLeft.gameObject.SetActive(value: true);
		mBorderAnimRight.gameObject.SetActive(value: false);
		mOutline.gameObject.SetActive(value: true);
		TweenAlpha.Begin(mBorderAnimLeft.gameObject, 962f, 420f);
		TweenAlpha.Begin(mBorderAnimRight.gameObject, 931f, 295f);
		TweenAlpha.Begin(mOutline.gameObject, 735f, 1253f, 1845f);
		TweenAlpha.Begin(mCompletedFill.gameObject, 273f, 1841f, 178f).onFinished = EALEJPAFMFH;
		TweenScale.Begin(mBorderAnimLeft.gameObject, 223f, mBorderAnimLeft.transform.localScale.MultiplyXY(625f)).onFinished = delegate
		{
			mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
			mBorderAnimLeft.alpha = 1f;
			mBorderAnimLeft.gameObject.SetActive(value: false);
		};
		TweenScale.Begin(mBorderAnimRight.gameObject, 1429f, mBorderAnimRight.transform.localScale.MultiplyXY(1245f)).onFinished = MKGDPALNMPJ;
		TweenScale.Begin(mOutline.gameObject, 1219f, mOutline.transform.localScale.MultiplyXY(981f)).onFinished = CENFGKKOHMG;
	}

	[CompilerGenerated]
	private void NHHIGADAMFN(UITweener IEFJAEBHEMB)
	{
		mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
		mBorderAnimLeft.alpha = 1f;
		mBorderAnimLeft.gameObject.SetActive(value: false);
	}

	private void CLICGGMKOFO(GameObject KHAHPAKDIKE)
	{
		if (KJPIMOPJMGB >= 1)
		{
			GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.BKPNOABFMGN[KJPIMOPJMGB].HintClicked(base.gameObject);
		}
	}

	private void JEALFKDBDNE()
	{
		mBorderAnimLeft.gameObject.SetActive(value: true);
		mBorderAnimRight.gameObject.SetActive(value: false);
		mOutline.gameObject.SetActive(value: false);
		TweenAlpha.Begin(mBorderAnimLeft.gameObject, 784f, 1586f);
		TweenAlpha.Begin(mBorderAnimRight.gameObject, 1678f, 1578f);
		TweenAlpha.Begin(mOutline.gameObject, 156f, 1021f, 62f);
		TweenAlpha.Begin(mCompletedFill.gameObject, 245f, 1828f, 972f).onFinished = NCDOEBKJLAF;
		TweenScale.Begin(mBorderAnimLeft.gameObject, 423f, mBorderAnimLeft.transform.localScale.MultiplyXY(1423f)).onFinished = delegate
		{
			mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
			mBorderAnimLeft.alpha = 1f;
			mBorderAnimLeft.gameObject.SetActive(value: false);
		};
		TweenScale.Begin(mBorderAnimRight.gameObject, 1240f, mBorderAnimRight.transform.localScale.MultiplyXY(1727f)).onFinished = MKGDPALNMPJ;
		TweenScale.Begin(mOutline.gameObject, 1200f, mOutline.transform.localScale.MultiplyXY(1378f)).onFinished = CENFGKKOHMG;
	}

	private void BLONBMNCBCB(UITweener POLCDJOBFKG)
	{
		mCrown.transform.localPosition = KGIEEOKCEBK;
	}

	private void DKFCBDGGACJ(GameObject KHAHPAKDIKE)
	{
		if (KJPIMOPJMGB >= 1)
		{
			GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.BKPNOABFMGN[KJPIMOPJMGB].HintClicked(base.gameObject);
		}
	}

	private void DALBNLEPKKH(UITweener IEFJAEBHEMB)
	{
		mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
		mBorderAnimLeft.alpha = 1264f;
		mBorderAnimLeft.gameObject.SetActive(value: true);
	}

	[CompilerGenerated]
	private static void PGAONLILDGI(UITweener GLBBEDEHFOP)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
	}

	[CompilerGenerated]
	private void IDOJEEMGKDM(UITweener BDNLONKNPKM)
	{
		mCrown.alpha = 1f;
		mCompleted.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		TweenScale.Begin(mCompletedFill.gameObject, 0.3f, PBIPEIPANFL);
		TweenScale.Begin(mCompleted.gameObject, 0.3f, PBIPEIPANFL).onFinished = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueRewardShowed);
		};
		InvokeAfter(delegate
		{
			mBorderAnimLeft.gameObject.SetActive(value: true);
			mBorderAnimRight.gameObject.SetActive(value: true);
			mOutline.gameObject.SetActive(value: true);
			TweenAlpha.Begin(mBorderAnimLeft.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mBorderAnimRight.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mOutline.gameObject, 0.7f, 0.5f, 0f);
			TweenAlpha.Begin(mCompletedFill.gameObject, 0.25f, 0f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(mCompletedFill.gameObject, 0.4f, 0f).onFinished = delegate
				{
					mCompletedFill.gameObject.SetActive(value: false);
				};
			};
			TweenScale.Begin(mBorderAnimLeft.gameObject, 0.8f, mBorderAnimLeft.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
			{
				mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
				mBorderAnimLeft.alpha = 1f;
				mBorderAnimLeft.gameObject.SetActive(value: false);
			};
			TweenScale.Begin(mBorderAnimRight.gameObject, 0.8f, mBorderAnimRight.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
			{
				mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
				mBorderAnimRight.alpha = 1f;
				mBorderAnimRight.gameObject.SetActive(value: false);
			};
			TweenScale.Begin(mOutline.gameObject, 0.8f, mOutline.transform.localScale.MultiplyXY(6f)).onFinished = delegate
			{
				mOutline.transform.localScale = PBIPEIPANFL;
				mOutline.alpha = 0.5f;
				mOutline.gameObject.SetActive(value: false);
				mHint.gameObject.SetActive(value: false);
				if (WarArena.instance.FPLIPHCJGFO.NFOELJINGGN[(int)WarArena.instance.data.wins - 1].OFMKJMAPHBM == IKPLPPFFDNI.CACDIELEJHK.None)
				{
					GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
				}
			};
		}, 0.2f);
	}

	private void MKNPANADEOC(UITweener PGJNJADMJEH)
	{
		mReward.transform.localScale = PDOPIJMMIEE;
		mReward.gameObject.SetActive(value: true);
		TweenRotation.Begin(mCompleted.gameObject, 210f, Quaternion.Euler(new Vector3(697f, 1271f, 840f)), useAbsolute: true).onFinished = KIBJEGDLLGH;
	}

	private void DPPMCOEONAP()
	{
		mCompleted.transform.localEulerAngles = new Vector3(876f, 133f, 1548f);
		mCompleted.transform.localScale = PBIPEIPANFL;
		mCompleted.gameObject.SetActive(value: true);
		mCompletedFill.gameObject.SetActive(value: false);
		mCompletedFill.alpha = 1089f;
		TweenScale.Begin(mCompleted.gameObject, 1567f, mCompleted.transform.localScale.MultiplyXY(663f));
		TweenScale.Begin(mCompletedFill.gameObject, 1927f, mCompleted.transform.localScale.MultiplyXY(1270f));
		TweenRotation.Begin(mCompleted.gameObject, 1633f, Quaternion.Euler(new Vector3(1716f, 1668f, 1487f)), useAbsolute: true).onFinished = MKNPANADEOC;
	}

	private void NCDOEBKJLAF(UITweener GPNIOOPDEFI)
	{
		TweenAlpha.Begin(mCompletedFill.gameObject, 1983f, 433f).onFinished = delegate
		{
			mCompletedFill.gameObject.SetActive(value: false);
		};
	}

	private void MOLJGHDOOHO()
	{
		mCompleted.transform.localEulerAngles = new Vector3(1712f, 961f, 738f);
		mCompleted.transform.localScale = PBIPEIPANFL;
		mCompleted.gameObject.SetActive(value: true);
		mCompletedFill.gameObject.SetActive(value: false);
		mCompletedFill.alpha = 1710f;
		TweenScale.Begin(mCompleted.gameObject, 544f, mCompleted.transform.localScale.MultiplyXY(741f));
		TweenScale.Begin(mCompletedFill.gameObject, 1986f, mCompleted.transform.localScale.MultiplyXY(90f));
		TweenRotation.Begin(mCompleted.gameObject, 615f, Quaternion.Euler(new Vector3(1465f, 229f, 1260f))).onFinished = MKNPANADEOC;
	}

	public void AnimateNode()
	{
		if (CMGBGEJMKPJ)
		{
			TweenAlpha.Begin(mCrown.gameObject, 0.3f, 0f);
			TweenPosition.Begin(mCrown.gameObject, 0.4f, mCrown.transform.localPosition.ReplaceY(KGIEEOKCEBK.y + 100f)).onFinished = delegate
			{
				mCrown.transform.localPosition = KGIEEOKCEBK;
			};
			TweenScale tweenScale = TweenScale.Begin(mReward.gameObject, 0.15f, mReward.transform.localScale.MultiplyXY(3f));
			tweenScale.delay = 0.1f;
			tweenScale.onFinished = delegate
			{
				FAFHEANBLDG();
			};
		}
		else
		{
			FAFHEANBLDG();
		}
	}

	public void SetCompletedOrReward(bool OJIAOCGNKOO, IKPLPPFFDNI.CACDIELEJHK FJLBLLLEELD = IKPLPPFFDNI.CACDIELEJHK.None, IKPLPPFFDNI.DNFADCEJOEH EBFDOPFOHAG = IKPLPPFFDNI.DNFADCEJOEH.None, int DFHAAIFFLOE = -1)
	{
		KJPIMOPJMGB = DFHAAIFFLOE;
		mBorderAnimLeft.gameObject.SetActive(value: false);
		mBorderAnimRight.gameObject.SetActive(value: false);
		mOutline.gameObject.SetActive(value: false);
		mCompletedFill.gameObject.SetActive(value: false);
		mCompleted.gameObject.SetActive(OJIAOCGNKOO);
		mReward.gameObject.SetActive(!OJIAOCGNKOO);
		mCrown.gameObject.SetActive(value: true);
		mCrown.alpha = 1f;
		mHint.gameObject.SetActive(!OJIAOCGNKOO);
		CMGBGEJMKPJ = !OJIAOCGNKOO;
		switch (FJLBLLLEELD)
		{
		case IKPLPPFFDNI.CACDIELEJHK.Bronze:
			mCrown.spriteName = "menu-crown-bronze";
			mReward.spriteName = "menu-arena-lootbox-bronze";
			break;
		case IKPLPPFFDNI.CACDIELEJHK.Silver:
			mCrown.spriteName = "menu-crown-silver";
			mReward.spriteName = "menu-arena-lootbox-silver";
			break;
		case IKPLPPFFDNI.CACDIELEJHK.Gold:
			mCrown.spriteName = "menu-crown-gold";
			mReward.spriteName = "menu-arena-lootbox-gold";
			break;
		}
		if (EBFDOPFOHAG == IKPLPPFFDNI.DNFADCEJOEH.None)
		{
			mCrown.gameObject.SetActive(value: false);
		}
	}

	private void HKCJNNGPFOI()
	{
		mBorderAnimLeft.gameObject.SetActive(value: true);
		mBorderAnimRight.gameObject.SetActive(value: true);
		mOutline.gameObject.SetActive(value: false);
		TweenAlpha.Begin(mBorderAnimLeft.gameObject, 1949f, 1936f);
		TweenAlpha.Begin(mBorderAnimRight.gameObject, 885f, 1716f);
		TweenAlpha.Begin(mOutline.gameObject, 879f, 979f, 282f);
		TweenAlpha.Begin(mCompletedFill.gameObject, 1409f, 1015f, 924f).onFinished = NCDOEBKJLAF;
		TweenScale.Begin(mBorderAnimLeft.gameObject, 798f, mBorderAnimLeft.transform.localScale.MultiplyXY(1138f)).onFinished = delegate
		{
			mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
			mBorderAnimLeft.alpha = 1f;
			mBorderAnimLeft.gameObject.SetActive(value: false);
		};
		TweenScale.Begin(mBorderAnimRight.gameObject, 735f, mBorderAnimRight.transform.localScale.MultiplyXY(56f)).onFinished = delegate
		{
			mBorderAnimRight.transform.localScale = CAHEBEPHOAB;
			mBorderAnimRight.alpha = 1f;
			mBorderAnimRight.gameObject.SetActive(value: false);
		};
		TweenScale.Begin(mOutline.gameObject, 475f, mOutline.transform.localScale.MultiplyXY(1441f)).onFinished = CENFGKKOHMG;
	}

	protected virtual void JJEONLDHCLO()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mHint.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DKFCBDGGACJ));
	}

	private void EFJEFPHHMDF(UITweener JLCPGEDKJGE)
	{
		mCompletedFill.gameObject.SetActive(value: true);
	}

	private void IIBMGDJKLPG(UITweener POLCDJOBFKG)
	{
		mCrown.transform.localPosition = KGIEEOKCEBK;
	}

	private void NHAJHOEMGEC(GameObject KHAHPAKDIKE)
	{
		if (KJPIMOPJMGB >= 1)
		{
			GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.BKPNOABFMGN[KJPIMOPJMGB].HintClicked(base.gameObject);
		}
	}

	private void OJGOGEJLCIA(GameObject KHAHPAKDIKE)
	{
		if (KJPIMOPJMGB >= 0)
		{
			GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.BKPNOABFMGN[KJPIMOPJMGB].HintClicked(base.gameObject);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mHint.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OJGOGEJLCIA));
	}

	private void JANDIEHHALK(UITweener POLCDJOBFKG)
	{
		MOLJGHDOOHO();
	}

	public void NIBEFILODGM(bool OJIAOCGNKOO, IKPLPPFFDNI.CACDIELEJHK FJLBLLLEELD = IKPLPPFFDNI.CACDIELEJHK.None, IKPLPPFFDNI.DNFADCEJOEH EBFDOPFOHAG = IKPLPPFFDNI.DNFADCEJOEH.None, int DFHAAIFFLOE = -1)
	{
		KJPIMOPJMGB = DFHAAIFFLOE;
		mBorderAnimLeft.gameObject.SetActive(value: true);
		mBorderAnimRight.gameObject.SetActive(value: true);
		mOutline.gameObject.SetActive(value: true);
		mCompletedFill.gameObject.SetActive(value: true);
		mCompleted.gameObject.SetActive(OJIAOCGNKOO);
		mReward.gameObject.SetActive(!OJIAOCGNKOO);
		mCrown.gameObject.SetActive(value: true);
		mCrown.alpha = 1345f;
		mHint.gameObject.SetActive(OJIAOCGNKOO);
		CMGBGEJMKPJ = OJIAOCGNKOO;
		switch (FJLBLLLEELD)
		{
		case IKPLPPFFDNI.CACDIELEJHK.None:
			mCrown.spriteName = "ID_YOURBEST";
			mReward.spriteName = "Wrong_Weapon";
			break;
		case (IKPLPPFFDNI.CACDIELEJHK)4:
			mCrown.spriteName = "FB: FacebookLogout GC connected";
			mReward.spriteName = "\t\"TRUE\"";
			break;
		case (IKPLPPFFDNI.CACDIELEJHK)7:
			mCrown.spriteName = "Medals/";
			mReward.spriteName = "CARD BUDDY - DESTROY CARD - Player: {0}";
			break;
		}
		if (EBFDOPFOHAG == IKPLPPFFDNI.DNFADCEJOEH.None)
		{
			mCrown.gameObject.SetActive(value: false);
		}
	}

	private void ACDEIJNJECC(UITweener POLCDJOBFKG)
	{
		MOLJGHDOOHO();
	}

	private void MIHEFFLLDJF()
	{
		mBorderAnimLeft.gameObject.SetActive(value: true);
		mBorderAnimRight.gameObject.SetActive(value: false);
		mOutline.gameObject.SetActive(value: true);
		TweenAlpha.Begin(mBorderAnimLeft.gameObject, 791f, 332f);
		TweenAlpha.Begin(mBorderAnimRight.gameObject, 75f, 511f);
		TweenAlpha.Begin(mOutline.gameObject, 1680f, 1363f, 94f);
		TweenAlpha.Begin(mCompletedFill.gameObject, 206f, 1655f, 789f).onFinished = EALEJPAFMFH;
		TweenScale.Begin(mBorderAnimLeft.gameObject, 1859f, mBorderAnimLeft.transform.localScale.MultiplyXY(1893f)).onFinished = delegate
		{
			mBorderAnimLeft.transform.localScale = CAHEBEPHOAB;
			mBorderAnimLeft.alpha = 1f;
			mBorderAnimLeft.gameObject.SetActive(value: false);
		};
		TweenScale.Begin(mBorderAnimRight.gameObject, 562f, mBorderAnimRight.transform.localScale.MultiplyXY(509f)).onFinished = MKGDPALNMPJ;
		TweenScale.Begin(mOutline.gameObject, 1885f, mOutline.transform.localScale.MultiplyXY(407f)).onFinished = CENFGKKOHMG;
	}
}
