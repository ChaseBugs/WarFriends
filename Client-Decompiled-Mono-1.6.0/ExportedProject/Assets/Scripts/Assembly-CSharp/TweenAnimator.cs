using System;
using System.Collections.Generic;
using UnityEngine;

public class TweenAnimator : Core_BaseScript
{
	public enum MNAIKKJDPLK
	{
		Position = 0,
		Rotation = 1,
		AlphaTk2d = 2,
		Color = 3,
		Scale = 4,
		Alpha = 5,
		TextCounter = 6,
		SufixTextCounter = 7,
		TextCounterSpecial = 8,
		TimeCounter = 9,
		ProgressBar = 10,
		AlphaHider = 11,
		Sound = 12,
		TextCounterLong = 13
	}

	[Serializable]
	public class TweenRecord
	{
		[SerializeField]
		public int id;

		[SerializeField]
		public MNAIKKJDPLK type;

		[SerializeField]
		public float time;

		[SerializeField]
		public float delay;

		[SerializeField]
		public object to;

		[SerializeField]
		public object from;

		[SerializeField]
		public UITweener.Method method = UITweener.Method.EaseInOut;

		[SerializeField]
		public UITweener.Style style;

		[SerializeField]
		public int playAfterId = -1;

		[SerializeField]
		public GameObject tweenTarget;

		[SerializeField]
		public int numOfRepetitions;

		[SerializeField]
		public SoundsManager.KJGDNLHKPOG soundEnum;
	}

	private sealed class NHBFIOEDDBI
	{
		internal TweenRecord ENIENNAKPIL;

		internal void ECPMEMNKMCB()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1977f);
		}

		internal void KJIFNOJILDB()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 394f);
		}

		internal void BEIGOGFHJIB()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1677f);
		}

		internal void MAKLHLCDIKD()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1567f);
		}

		internal void MCFGAFBEJDK()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 811f);
		}

		internal void BMCMDMKGHHO()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1329f);
		}

		internal void AGFEDJAKLAC()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1385f);
		}

		internal void NNFHNIMCBLH()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1115f);
		}

		internal void ADEFLNOHDAK()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1680f);
		}

		internal void CMCIGAFHIJL()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 574f);
		}

		internal void HOMIPBFODIC()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1328f);
		}

		internal void JDEJHLLIONG()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 775f);
		}

		internal void KNJBDOADLDO()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 11f);
		}

		internal void FDKMOFHAEFN()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 697f);
		}

		internal void GMFJFMHNDMC()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 850f);
		}

		internal void POGLHCIAAGH()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1131f);
		}

		internal void LJCDGJKCNEC()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum);
		}

		internal void JGHLGHMJJDG()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1395f);
		}

		internal void FHDOHCJJEMM()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 3f);
		}

		internal void ANAGFGHGPJA()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1787f);
		}

		internal void CIFEDFPPPOK()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 133f);
		}

		internal void FIBGJHCGHJH()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1785f);
		}

		internal void DJLGPGPAHCD()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1326f);
		}

		internal void LKAHPHIEMEK()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 77f);
		}

		internal void CJIBPJPJLNB()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 314f);
		}

		internal void NDJOJHNIBFC()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1462f);
		}

		internal void LGJCNCHBFDA()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 957f);
		}

		internal void CMDLGJKIBLL()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1939f);
		}

		internal void NAJNECOMDDN()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1364f);
		}

		internal void KLJNEGDLOMG()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 836f);
		}

		internal void DGELDDJAEEF()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 910f);
		}

		internal void OKNCFDMEFGJ()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 1654f);
		}

		internal void HHNEBNHCGMO()
		{
			SoundsManager.Instance.PlaySound(ENIENNAKPIL.soundEnum, 670f);
		}
	}

	public List<TweenRecord> BEOAHFDJEMD = new List<TweenRecord>();

	public Action<int> JHDBHGCKPDM;

	private bool BDKNNNCHILL = true;

	public bool HMFNIBOFGMB;

	private static Dictionary<MNAIKKJDPLK, Type> BAMMGANPNNM = new Dictionary<MNAIKKJDPLK, Type>
	{
		{
			MNAIKKJDPLK.Position,
			typeof(TweenPosition)
		},
		{
			MNAIKKJDPLK.Rotation,
			typeof(TweenRotation)
		},
		{
			MNAIKKJDPLK.AlphaTk2d,
			typeof(TweenAlphaTk2d)
		},
		{
			MNAIKKJDPLK.Color,
			typeof(TweenColor)
		},
		{
			MNAIKKJDPLK.Scale,
			typeof(TweenScale)
		},
		{
			MNAIKKJDPLK.Alpha,
			typeof(TweenAlpha)
		},
		{
			MNAIKKJDPLK.TextCounter,
			typeof(TweenTextCounter)
		},
		{
			MNAIKKJDPLK.SufixTextCounter,
			typeof(TweenSufixTextCounter)
		},
		{
			MNAIKKJDPLK.TextCounterSpecial,
			typeof(TweenCounterSpecial)
		},
		{
			MNAIKKJDPLK.TimeCounter,
			typeof(TweenTimeCounter)
		},
		{
			MNAIKKJDPLK.ProgressBar,
			typeof(TweenProgressBar)
		},
		{
			MNAIKKJDPLK.AlphaHider,
			typeof(TweenAlphaHider)
		},
		{
			MNAIKKJDPLK.Sound,
			typeof(AudioClip)
		},
		{
			MNAIKKJDPLK.TextCounterLong,
			typeof(TweenTextCounterLong)
		}
	};

	protected void CFLALBENGJN()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = true;
			AGFMCNDAEEC();
		}
	}

	public void HONNAONCPHA()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)22)
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = true;
				}
			}
		}
	}

	protected void OCBLKIFKJEG()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = true;
			AGFMCNDAEEC();
		}
	}

	public void LILKFFOOHMC()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 974f;
			FBMFPIJKAJH(item);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void IAKEAKDJJIA()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-118))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = false;
				}
			}
		}
	}

	private void LDGCMEMJJEP(TweenRecord ENIENNAKPIL, bool EJPBAOKEBFN = true)
	{
		NHBFIOEDDBI nHBFIOEDDBI = new NHBFIOEDDBI();
		nHBFIOEDDBI.ENIENNAKPIL = ENIENNAKPIL;
		UITweener uITweener = null;
		switch (nHBFIOEDDBI.ENIENNAKPIL.type)
		{
		case MNAIKKJDPLK.Position:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to, false));
			break;
		case MNAIKKJDPLK.Scale:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaTk2d:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Alpha:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaHider:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaHider.LBGHBCPDKAO(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaHider.DBPOCEIDEAE(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.ProgressBar:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenProgressBar.IAGLEIPAIOB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.from, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenProgressBar.DFNHCFNJCMC(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounter.DANKMJCJOIN(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounter.GBNIAKJEIMN(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterLong:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounterLong.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.from, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounterLong.IAGLEIPAIOB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.SufixTextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenSufixTextCounter.HGBKLMHAGBF(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenSufixTextCounter.GAOAJNGAOHH(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterSpecial:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenCounterSpecial.MLEAFANPCJB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenCounterSpecial.IPOEOHBLGMJ(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TimeCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTimeCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTimeCounter.OBHFCFEKAPG(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Color:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.from, (Color)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Rotation:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.from, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to, true));
			break;
		case MNAIKKJDPLK.Sound:
			if (EJPBAOKEBFN)
			{
				if (nHBFIOEDDBI.ENIENNAKPIL.delay > 1441f)
				{
					InvokeAfter(nHBFIOEDDBI.MAKLHLCDIKD, nHBFIOEDDBI.ENIENNAKPIL.delay);
				}
				else
				{
					SoundsManager.Instance.PlaySound(nHBFIOEDDBI.ENIENNAKPIL.soundEnum, 1549f);
				}
			}
			return;
		}
		nHBFIOEDDBI.ENIENNAKPIL.tweenTarget.gameObject.SetActive(true);
		if (uITweener != null)
		{
			uITweener.delay = nHBFIOEDDBI.ENIENNAKPIL.delay;
			uITweener.method = nHBFIOEDDBI.ENIENNAKPIL.method;
			uITweener.style = nHBFIOEDDBI.ENIENNAKPIL.style;
			uITweener.NumOfRepetitions = nHBFIOEDDBI.ENIENNAKPIL.numOfRepetitions;
			uITweener.id = nHBFIOEDDBI.ENIENNAKPIL.id;
			if (EJPBAOKEBFN)
			{
				UITweener uITweener2 = uITweener;
				uITweener2.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener2.onFinished, new UITweener.OnFinished(KJMCAOIHAMA));
			}
		}
	}

	public void ResetTweens()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != MNAIKKJDPLK.Sound)
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = false;
				}
			}
		}
	}

	public void NCKIJBBJAOG()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)115)
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = true;
				}
			}
		}
	}

	public void JIPFOMFJNPC()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)73)
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = true;
				}
			}
		}
	}

	private void ALDMDAONEOB(TweenRecord ENIENNAKPIL, bool EJPBAOKEBFN = true)
	{
		NHBFIOEDDBI nHBFIOEDDBI = new NHBFIOEDDBI();
		nHBFIOEDDBI.ENIENNAKPIL = ENIENNAKPIL;
		UITweener uITweener = null;
		switch (nHBFIOEDDBI.ENIENNAKPIL.type)
		{
		case MNAIKKJDPLK.Position:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Scale:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaTk2d:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Alpha:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaHider:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaHider.PDFHNDPEEMA(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaHider.PAJHHBLHAEI(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.ProgressBar:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenProgressBar.DKGIHJJKKBM(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.from, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenProgressBar.ONCDIOBFHME(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounter.MDBMAINKPKG(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounter.KFNKIMBNAIK(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterLong:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounterLong.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.from, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounterLong.IAGLEIPAIOB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.SufixTextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenSufixTextCounter.HBHMEFGMNNN(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenSufixTextCounter.BIMCIIOMBMB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterSpecial:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenCounterSpecial.MLEAFANPCJB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenCounterSpecial.ECHFMFFNJON(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TimeCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTimeCounter.EEODMCJPDNI(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTimeCounter.IGGENFHMDJB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Color:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.from, (Color)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Rotation:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.from, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to, true));
			break;
		case MNAIKKJDPLK.Sound:
			if (EJPBAOKEBFN)
			{
				if (nHBFIOEDDBI.ENIENNAKPIL.delay > 53f)
				{
					InvokeAfter(nHBFIOEDDBI.NDJOJHNIBFC, nHBFIOEDDBI.ENIENNAKPIL.delay);
				}
				else
				{
					SoundsManager.Instance.PlaySound(nHBFIOEDDBI.ENIENNAKPIL.soundEnum, 992f);
				}
			}
			return;
		}
		nHBFIOEDDBI.ENIENNAKPIL.tweenTarget.gameObject.SetActive(true);
		if (uITweener != null)
		{
			uITweener.delay = nHBFIOEDDBI.ENIENNAKPIL.delay;
			uITweener.method = nHBFIOEDDBI.ENIENNAKPIL.method;
			uITweener.style = nHBFIOEDDBI.ENIENNAKPIL.style;
			uITweener.NumOfRepetitions = nHBFIOEDDBI.ENIENNAKPIL.numOfRepetitions;
			uITweener.id = nHBFIOEDDBI.ENIENNAKPIL.id;
			if (EJPBAOKEBFN)
			{
				UITweener uITweener2 = uITweener;
				uITweener2.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener2.onFinished, new UITweener.OnFinished(NCPBONCFBLG));
			}
		}
	}

	private void KFOFLIMHKBK(UITweener MGDJMGHCAAI)
	{
		if (JHDBHGCKPDM != null)
		{
			JHDBHGCKPDM(MGDJMGHCAAI.id);
		}
		if (!BDKNNNCHILL)
		{
			return;
		}
		int id = MGDJMGHCAAI.id;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == id)
			{
				PDKBIPOJMPI(item);
			}
		}
	}

	private void NCPBONCFBLG(UITweener MGDJMGHCAAI)
	{
		if (JHDBHGCKPDM != null)
		{
			JHDBHGCKPDM(MGDJMGHCAAI.id);
		}
		if (!BDKNNNCHILL)
		{
			return;
		}
		int id = MGDJMGHCAAI.id;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == id)
			{
				MJHPNGNBIBK(item);
			}
		}
	}

	public void BBPNDINMNIJ()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)117)
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = false;
				}
			}
		}
	}

	public TweenRecord AddTween(int INFLHPGMEOB, MNAIKKJDPLK HADMLJODMKA, GameObject NIHOBEAHEKJ, float KBJEOEEOEFG, object IIMDKHJAJGO, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1, object OEIICEJPGKI = null, UITweener.Method JFFHMLFEMPP = UITweener.Method.EaseInOut, UITweener.Style AMJHPOFLPGC = UITweener.Style.Once, int HOLBAEHICEF = 1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = HADMLJODMKA;
		tweenRecord.time = KBJEOEEOEFG;
		tweenRecord.from = OEIICEJPGKI;
		tweenRecord.to = IIMDKHJAJGO;
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.method = JFFHMLFEMPP;
		tweenRecord.style = AMJHPOFLPGC;
		tweenRecord.tweenTarget = NIHOBEAHEKJ;
		tweenRecord.numOfRepetitions = HOLBAEHICEF;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	private void ONEAFDGBIJJ(TweenRecord ENIENNAKPIL, bool EJPBAOKEBFN = true)
	{
		NHBFIOEDDBI nHBFIOEDDBI = new NHBFIOEDDBI();
		nHBFIOEDDBI.ENIENNAKPIL = ENIENNAKPIL;
		UITweener uITweener = null;
		switch (nHBFIOEDDBI.ENIENNAKPIL.type)
		{
		case MNAIKKJDPLK.Position:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to, false));
			break;
		case MNAIKKJDPLK.Scale:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaTk2d:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Alpha:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaHider:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaHider.NPHFBDMKODP(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaHider.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.ProgressBar:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenProgressBar.NNJONILFKMD(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.from, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenProgressBar.ONCDIOBFHME(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterLong:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounterLong.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.from, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounterLong.IAGLEIPAIOB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.SufixTextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenSufixTextCounter.JPJPAJEBNPK(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenSufixTextCounter.MNBLBMJICDB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterSpecial:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenCounterSpecial.HGBKLMHAGBF(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenCounterSpecial.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TimeCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTimeCounter.FMGPCIGJIBP(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTimeCounter.IGGENFHMDJB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Color:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.from, (Color)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Rotation:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.from, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to, true));
			break;
		case MNAIKKJDPLK.Sound:
			if (EJPBAOKEBFN)
			{
				if (nHBFIOEDDBI.ENIENNAKPIL.delay > 1328f)
				{
					InvokeAfter(nHBFIOEDDBI.DJLGPGPAHCD, nHBFIOEDDBI.ENIENNAKPIL.delay);
				}
				else
				{
					SoundsManager.Instance.PlaySound(nHBFIOEDDBI.ENIENNAKPIL.soundEnum, 1491f);
				}
			}
			return;
		}
		nHBFIOEDDBI.ENIENNAKPIL.tweenTarget.gameObject.SetActive(false);
		if (uITweener != null)
		{
			uITweener.delay = nHBFIOEDDBI.ENIENNAKPIL.delay;
			uITweener.method = nHBFIOEDDBI.ENIENNAKPIL.method;
			uITweener.style = nHBFIOEDDBI.ENIENNAKPIL.style;
			uITweener.NumOfRepetitions = nHBFIOEDDBI.ENIENNAKPIL.numOfRepetitions;
			uITweener.id = nHBFIOEDDBI.ENIENNAKPIL.id;
			if (EJPBAOKEBFN)
			{
				UITweener uITweener2 = uITweener;
				uITweener2.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener2.onFinished, new UITweener.OnFinished(NCPBONCFBLG));
			}
		}
	}

	protected void HDLDMGEFCEJ()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = false;
			PlayTweens();
		}
	}

	public TweenRecord DMCFFJNACFB(int INFLHPGMEOB, SoundsManager.KJGDNLHKPOG EOOBBKDNCGM, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = (MNAIKKJDPLK)20;
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.soundEnum = EOOBBKDNCGM;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public TweenRecord IEFNOJGLGGB(int INFLHPGMEOB, SoundsManager.KJGDNLHKPOG EOOBBKDNCGM, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = (MNAIKKJDPLK)(-84);
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.soundEnum = EOOBBKDNCGM;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public void KHAFPAMIOAF()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-39))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = true;
				}
			}
		}
	}

	protected void IIFBKHDMIAD()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = true;
			HMPMBAGNJOJ();
		}
	}

	public TweenRecord NIMJAKLMIPI(int NOCEDALFEJM)
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.id == NOCEDALFEJM)
			{
				return item;
			}
		}
		return null;
	}

	public TweenRecord MNEFMODDFFK(int INFLHPGMEOB, MNAIKKJDPLK HADMLJODMKA, GameObject NIHOBEAHEKJ, float KBJEOEEOEFG, object IIMDKHJAJGO, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1, object OEIICEJPGKI = null, UITweener.Method JFFHMLFEMPP = UITweener.Method.EaseInOut, UITweener.Style AMJHPOFLPGC = UITweener.Style.Once, int HOLBAEHICEF = 1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = HADMLJODMKA;
		tweenRecord.time = KBJEOEEOEFG;
		tweenRecord.from = OEIICEJPGKI;
		tweenRecord.to = IIMDKHJAJGO;
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.method = JFFHMLFEMPP;
		tweenRecord.style = AMJHPOFLPGC;
		tweenRecord.tweenTarget = NIHOBEAHEKJ;
		tweenRecord.numOfRepetitions = HOLBAEHICEF;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	private void IJCGLEJFKGB(UITweener MGDJMGHCAAI)
	{
		if (JHDBHGCKPDM != null)
		{
			JHDBHGCKPDM(MGDJMGHCAAI.id);
		}
		if (!BDKNNNCHILL)
		{
			return;
		}
		int id = MGDJMGHCAAI.id;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == id)
			{
				PDKBIPOJMPI(item, false);
			}
		}
	}

	public TweenRecord BPEKAKFKCIG(int INFLHPGMEOB, MNAIKKJDPLK HADMLJODMKA, GameObject NIHOBEAHEKJ, float KBJEOEEOEFG, object IIMDKHJAJGO, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1, object OEIICEJPGKI = null, UITweener.Method JFFHMLFEMPP = UITweener.Method.EaseInOut, UITweener.Style AMJHPOFLPGC = UITweener.Style.Once, int HOLBAEHICEF = 1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = HADMLJODMKA;
		tweenRecord.time = KBJEOEEOEFG;
		tweenRecord.from = OEIICEJPGKI;
		tweenRecord.to = IIMDKHJAJGO;
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.method = JFFHMLFEMPP;
		tweenRecord.style = AMJHPOFLPGC;
		tweenRecord.tweenTarget = NIHOBEAHEKJ;
		tweenRecord.numOfRepetitions = HOLBAEHICEF;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public void DGFKMBDKEAP()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-33))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = true;
				}
			}
		}
	}

	public void ABFBKGCIJBB()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 1686f;
			ALDMDAONEOB(item, false);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void OHKEAEIFMPJ()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)59)
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = false;
				}
			}
		}
	}

	public void PDHDOANGIDB()
	{
		BDKNNNCHILL = false;
	}

	private void PDKBIPOJMPI(TweenRecord ENIENNAKPIL, bool EJPBAOKEBFN = true)
	{
		NHBFIOEDDBI nHBFIOEDDBI = new NHBFIOEDDBI();
		nHBFIOEDDBI.ENIENNAKPIL = ENIENNAKPIL;
		UITweener uITweener = null;
		switch (nHBFIOEDDBI.ENIENNAKPIL.type)
		{
		case MNAIKKJDPLK.Position:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Scale:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaTk2d:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Alpha:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaHider:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaHider.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaHider.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.ProgressBar:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenProgressBar.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.from, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenProgressBar.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterLong:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounterLong.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.from, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounterLong.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.SufixTextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenSufixTextCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenSufixTextCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterSpecial:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenCounterSpecial.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenCounterSpecial.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TimeCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTimeCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTimeCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Color:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.from, (Color)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Rotation:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.from, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Sound:
			if (EJPBAOKEBFN)
			{
				if (nHBFIOEDDBI.ENIENNAKPIL.delay > 0f)
				{
					InvokeAfter(nHBFIOEDDBI.LJCDGJKCNEC, nHBFIOEDDBI.ENIENNAKPIL.delay);
				}
				else
				{
					SoundsManager.Instance.PlaySound(nHBFIOEDDBI.ENIENNAKPIL.soundEnum);
				}
			}
			return;
		}
		nHBFIOEDDBI.ENIENNAKPIL.tweenTarget.gameObject.SetActive(true);
		if (uITweener != null)
		{
			uITweener.delay = nHBFIOEDDBI.ENIENNAKPIL.delay;
			uITweener.method = nHBFIOEDDBI.ENIENNAKPIL.method;
			uITweener.style = nHBFIOEDDBI.ENIENNAKPIL.style;
			uITweener.NumOfRepetitions = nHBFIOEDDBI.ENIENNAKPIL.numOfRepetitions;
			uITweener.id = nHBFIOEDDBI.ENIENNAKPIL.id;
			if (EJPBAOKEBFN)
			{
				UITweener uITweener2 = uITweener;
				uITweener2.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener2.onFinished, new UITweener.OnFinished(KFOFLIMHKBK));
			}
		}
	}

	public TweenRecord AddSoundTween(int INFLHPGMEOB, SoundsManager.KJGDNLHKPOG EOOBBKDNCGM, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = MNAIKKJDPLK.Sound;
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.soundEnum = EOOBBKDNCGM;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public void PlayTweens()
	{
		BDKNNNCHILL = true;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == -1)
			{
				PDKBIPOJMPI(item);
			}
		}
	}

	public TweenRecord NBAMMAIGPHL(int NOCEDALFEJM)
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.id == NOCEDALFEJM)
			{
				return item;
			}
		}
		return null;
	}

	public void OEPHIMGCKIJ()
	{
		BDKNNNCHILL = true;
	}

	public TweenRecord DDLJHBJMMMB(int INFLHPGMEOB, SoundsManager.KJGDNLHKPOG EOOBBKDNCGM, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = (MNAIKKJDPLK)(-126);
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.soundEnum = EOOBBKDNCGM;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public void Stop()
	{
		BDKNNNCHILL = false;
	}

	public TweenRecord GetTween(int NOCEDALFEJM)
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.id == NOCEDALFEJM)
			{
				return item;
			}
		}
		return null;
	}

	public void CPKDFIKMKLE()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 50f;
			MJHPNGNBIBK(item, false);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void FinishTweens()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 0f;
			PDKBIPOJMPI(item, false);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public TweenRecord BMBMIIBPDCG(int INFLHPGMEOB, SoundsManager.KJGDNLHKPOG EOOBBKDNCGM, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = (MNAIKKJDPLK)104;
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.soundEnum = EOOBBKDNCGM;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public TweenRecord GFAFLDJAKGD(int INFLHPGMEOB, SoundsManager.KJGDNLHKPOG EOOBBKDNCGM, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = (MNAIKKJDPLK)(-115);
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.soundEnum = EOOBBKDNCGM;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public void OOFBCPPFMPN()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-52))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = false;
				}
			}
		}
	}

	public TweenRecord PKHCMJDKKJL(int NOCEDALFEJM)
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.id == NOCEDALFEJM)
			{
				return item;
			}
		}
		return null;
	}

	public void PHCCOHJPLKE()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 1095f;
			ALDMDAONEOB(item, false);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void BCFMBKNMNBN()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 811f;
			FBMFPIJKAJH(item);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void IGBJIEBMEBF()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-24))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = true;
				}
			}
		}
	}

	public void CJGJOAKNIIL()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 922f;
			PDKBIPOJMPI(item, false);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void JHHKAMAPLNI()
	{
		BDKNNNCHILL = true;
	}

	public void JEEKNFJCAMJ()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 1524f;
			MJHPNGNBIBK(item);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void HLKNEKNIENJ()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 770f;
			LDGCMEMJJEP(item);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void FEPILCEBNCJ()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)43)
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = false;
				}
			}
		}
	}

	public void OAMANMKJMAP()
	{
		BDKNNNCHILL = false;
	}

	public void EFGHGIBPMGL()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-48))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = false;
				}
			}
		}
	}

	public void AGFMCNDAEEC()
	{
		BDKNNNCHILL = false;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == -1)
			{
				ALDMDAONEOB(item, false);
			}
		}
	}

	protected void NCLHOHNKMOJ()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = true;
			GDCCFEDJFAF();
		}
	}

	protected void NKGLGNEJIOA()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = false;
			HMPMBAGNJOJ();
		}
	}

	protected void CBOIHLDFKPI()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = false;
			HMPMBAGNJOJ();
		}
	}

	public void KIOKIAFPHPE()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 996f;
			FBMFPIJKAJH(item, false);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	protected void DFBPBGDJKOG()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = false;
			PlayTweens();
		}
	}

	public TweenRecord KMLEDGJJMNN(int INFLHPGMEOB, SoundsManager.KJGDNLHKPOG EOOBBKDNCGM, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = (MNAIKKJDPLK)(-84);
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.soundEnum = EOOBBKDNCGM;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public TweenRecord HHAOKJDOJJE(int NOCEDALFEJM)
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.id == NOCEDALFEJM)
			{
				return item;
			}
		}
		return null;
	}

	public void GenerateTweens()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != MNAIKKJDPLK.Sound)
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = false;
				}
			}
		}
	}

	public void OKEBGBENAJF()
	{
		BDKNNNCHILL = true;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == -1)
			{
				PDKBIPOJMPI(item);
			}
		}
	}

	public void BIAMGHLKGOK()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-58))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = false;
				}
			}
		}
	}

	public void PGGAAGLGKAL()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-101))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)item.tweenTarget.AddComponent(type);
					uITweener.enabled = false;
				}
			}
		}
	}

	public void DMAJACPHCGN()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 39f;
			FBMFPIJKAJH(item);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public TweenRecord NFLKPCIHOPJ(int INFLHPGMEOB, MNAIKKJDPLK HADMLJODMKA, GameObject NIHOBEAHEKJ, float KBJEOEEOEFG, object IIMDKHJAJGO, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1, object OEIICEJPGKI = null, UITweener.Method JFFHMLFEMPP = UITweener.Method.EaseInOut, UITweener.Style AMJHPOFLPGC = UITweener.Style.Once, int HOLBAEHICEF = 1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = HADMLJODMKA;
		tweenRecord.time = KBJEOEEOEFG;
		tweenRecord.from = OEIICEJPGKI;
		tweenRecord.to = IIMDKHJAJGO;
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.method = JFFHMLFEMPP;
		tweenRecord.style = AMJHPOFLPGC;
		tweenRecord.tweenTarget = NIHOBEAHEKJ;
		tweenRecord.numOfRepetitions = HOLBAEHICEF;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	private void KJMCAOIHAMA(UITweener MGDJMGHCAAI)
	{
		if (JHDBHGCKPDM != null)
		{
			JHDBHGCKPDM(MGDJMGHCAAI.id);
		}
		if (!BDKNNNCHILL)
		{
			return;
		}
		int id = MGDJMGHCAAI.id;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == id)
			{
				ALDMDAONEOB(item, false);
			}
		}
	}

	public void HGJHNOPHMMD()
	{
		BDKNNNCHILL = false;
	}

	public void ODIJFGCDJNH()
	{
		BDKNNNCHILL = false;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == -1)
			{
				LDGCMEMJJEP(item, false);
			}
		}
	}

	protected void Update()
	{
		if (HMFNIBOFGMB)
		{
			HMFNIBOFGMB = false;
			PlayTweens();
		}
	}

	public TweenRecord FEHALDPLGDB(int INFLHPGMEOB, MNAIKKJDPLK HADMLJODMKA, GameObject NIHOBEAHEKJ, float KBJEOEEOEFG, object IIMDKHJAJGO, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1, object OEIICEJPGKI = null, UITweener.Method JFFHMLFEMPP = UITweener.Method.EaseInOut, UITweener.Style AMJHPOFLPGC = UITweener.Style.Once, int HOLBAEHICEF = 1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = HADMLJODMKA;
		tweenRecord.time = KBJEOEEOEFG;
		tweenRecord.from = OEIICEJPGKI;
		tweenRecord.to = IIMDKHJAJGO;
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.method = JFFHMLFEMPP;
		tweenRecord.style = AMJHPOFLPGC;
		tweenRecord.tweenTarget = NIHOBEAHEKJ;
		tweenRecord.numOfRepetitions = HOLBAEHICEF;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public void LPHPLPGOGEM()
	{
		BDKNNNCHILL = true;
	}

	public void LFOKFAFLBLA()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.type != (MNAIKKJDPLK)(-28))
			{
				Type type = BAMMGANPNNM[item.type];
				Component component = item.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = false;
				}
			}
		}
	}

	public void NDGCGHLLPMC()
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			object obj = item.from;
			item.from = item.to;
			float time = item.time;
			int id = item.id;
			item.id = -1;
			item.time = 834f;
			PDKBIPOJMPI(item);
			item.from = obj;
			item.time = time;
			item.id = id;
		}
	}

	public void HMPMBAGNJOJ()
	{
		BDKNNNCHILL = false;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == -1)
			{
				MJHPNGNBIBK(item, false);
			}
		}
	}

	public TweenRecord PNBOJNAAHIK(int INFLHPGMEOB, SoundsManager.KJGDNLHKPOG EOOBBKDNCGM, float KALLNCAFIMP = 0f, int EBPMMNFLPMP = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = KALLNCAFIMP;
		tweenRecord.id = INFLHPGMEOB;
		tweenRecord.type = (MNAIKKJDPLK)(-33);
		tweenRecord.playAfterId = EBPMMNFLPMP;
		tweenRecord.soundEnum = EOOBBKDNCGM;
		TweenRecord tweenRecord2 = tweenRecord;
		BEOAHFDJEMD.Add(tweenRecord2);
		return tweenRecord2;
	}

	public TweenRecord IKIDBFKLHMN(int NOCEDALFEJM)
	{
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.id == NOCEDALFEJM)
			{
				return item;
			}
		}
		return null;
	}

	private void FBMFPIJKAJH(TweenRecord ENIENNAKPIL, bool EJPBAOKEBFN = true)
	{
		NHBFIOEDDBI nHBFIOEDDBI = new NHBFIOEDDBI();
		nHBFIOEDDBI.ENIENNAKPIL = ENIENNAKPIL;
		UITweener uITweener = null;
		switch (nHBFIOEDDBI.ENIENNAKPIL.type)
		{
		case MNAIKKJDPLK.Position:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to, false) : TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to, false));
			break;
		case MNAIKKJDPLK.Scale:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaTk2d:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Alpha:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaHider:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaHider.LPGNGJBPAKH(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaHider.PAJHHBLHAEI(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.ProgressBar:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenProgressBar.DHKJOACDBNK(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.from, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenProgressBar.JPJPAJEBNPK(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounter.LMNBPJEACEA(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounter.HDHIEDDCJIC(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterLong:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounterLong.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.from, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounterLong.IAGLEIPAIOB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.SufixTextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenSufixTextCounter.IECHDKECJAB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenSufixTextCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterSpecial:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenCounterSpecial.LMNBPJEACEA(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenCounterSpecial.KMDIDKBDCDM(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TimeCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTimeCounter.FMGPCIGJIBP(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTimeCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Color:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.from, (Color)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Rotation:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.from, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to, true));
			break;
		case MNAIKKJDPLK.Sound:
			if (EJPBAOKEBFN)
			{
				if (nHBFIOEDDBI.ENIENNAKPIL.delay > 1607f)
				{
					InvokeAfter(nHBFIOEDDBI.CMDLGJKIBLL, nHBFIOEDDBI.ENIENNAKPIL.delay);
				}
				else
				{
					SoundsManager.Instance.PlaySound(nHBFIOEDDBI.ENIENNAKPIL.soundEnum, 1967f);
				}
			}
			return;
		}
		nHBFIOEDDBI.ENIENNAKPIL.tweenTarget.gameObject.SetActive(true);
		if (uITweener != null)
		{
			uITweener.delay = nHBFIOEDDBI.ENIENNAKPIL.delay;
			uITweener.method = nHBFIOEDDBI.ENIENNAKPIL.method;
			uITweener.style = nHBFIOEDDBI.ENIENNAKPIL.style;
			uITweener.NumOfRepetitions = nHBFIOEDDBI.ENIENNAKPIL.numOfRepetitions;
			uITweener.id = nHBFIOEDDBI.ENIENNAKPIL.id;
			if (EJPBAOKEBFN)
			{
				UITweener uITweener2 = uITweener;
				uITweener2.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener2.onFinished, new UITweener.OnFinished(KJMCAOIHAMA));
			}
		}
	}

	public void GDCCFEDJFAF()
	{
		BDKNNNCHILL = false;
		foreach (TweenRecord item in BEOAHFDJEMD)
		{
			if (item.playAfterId == -1)
			{
				FBMFPIJKAJH(item);
			}
		}
	}

	private void MJHPNGNBIBK(TweenRecord ENIENNAKPIL, bool EJPBAOKEBFN = true)
	{
		NHBFIOEDDBI nHBFIOEDDBI = new NHBFIOEDDBI();
		nHBFIOEDDBI.ENIENNAKPIL = ENIENNAKPIL;
		UITweener uITweener = null;
		switch (nHBFIOEDDBI.ENIENNAKPIL.type)
		{
		case MNAIKKJDPLK.Position:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to, false) : TweenPosition.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to, false));
			break;
		case MNAIKKJDPLK.Scale:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.from, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenScale.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Vector3)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaTk2d:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaTk2d.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Alpha:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlpha.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.AlphaHider:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenAlphaHider.GEKPHELKFNB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.from, (float)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenAlphaHider.JBPMBAKMEOG(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (float)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.ProgressBar:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenProgressBar.FHKFBIPHJCG(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.from, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenProgressBar.ONCDIOBFHME(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (NHOGNBCNIEK)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounter.IECHDKECJAB(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounter.PGAHIMIGILO(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterLong:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTextCounterLong.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.from, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTextCounterLong.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (OLDCFKEJDPA)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.SufixTextCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenSufixTextCounter.LEMANGJFIPE(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenSufixTextCounter.MDEAIEJHIGE(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TextCounterSpecial:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenCounterSpecial.HGBKLMHAGBF(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenCounterSpecial.IPOEOHBLGMJ(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.TimeCounter:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenTimeCounter.HDHIEDDCJIC(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.from, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenTimeCounter.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (ONLHLPBMJOL)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Color:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.from, (Color)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenColor.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Color)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Rotation:
			uITweener = ((nHBFIOEDDBI.ENIENNAKPIL.from != null) ? TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.from, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to) : TweenRotation.Begin(nHBFIOEDDBI.ENIENNAKPIL.tweenTarget, nHBFIOEDDBI.ENIENNAKPIL.time, (Quaternion)nHBFIOEDDBI.ENIENNAKPIL.to));
			break;
		case MNAIKKJDPLK.Sound:
			if (EJPBAOKEBFN)
			{
				if (nHBFIOEDDBI.ENIENNAKPIL.delay > 629f)
				{
					InvokeAfter(nHBFIOEDDBI.BMCMDMKGHHO, nHBFIOEDDBI.ENIENNAKPIL.delay);
				}
				else
				{
					SoundsManager.Instance.PlaySound(nHBFIOEDDBI.ENIENNAKPIL.soundEnum, 1649f);
				}
			}
			return;
		}
		nHBFIOEDDBI.ENIENNAKPIL.tweenTarget.gameObject.SetActive(true);
		if (uITweener != null)
		{
			uITweener.delay = nHBFIOEDDBI.ENIENNAKPIL.delay;
			uITweener.method = nHBFIOEDDBI.ENIENNAKPIL.method;
			uITweener.style = nHBFIOEDDBI.ENIENNAKPIL.style;
			uITweener.NumOfRepetitions = nHBFIOEDDBI.ENIENNAKPIL.numOfRepetitions;
			uITweener.id = nHBFIOEDDBI.ENIENNAKPIL.id;
			if (EJPBAOKEBFN)
			{
				UITweener uITweener2 = uITweener;
				uITweener2.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener2.onFinished, new UITweener.OnFinished(KFOFLIMHKBK));
			}
		}
	}
}
