using System;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("NGUI/Interaction/Button Scale Touch")]
public class UIButtonScaleTouch : MonoBehaviour
{
	[FormerlySerializedAs("BMBJCHCEEHI")]
	public Transform NIHOBEAHEKJ;

	[FormerlySerializedAs("EDHAFFICJNP")]
	public Vector3 AGFDBMMHFDP = new Vector3(1.1f, 1.1f, 1.1f);

	[FormerlySerializedAs("KEPGBOAAEON")]
	public Vector3 HCAJFFJBCOJ = new Vector3(1.05f, 1.05f, 1.05f);

	[FormerlySerializedAs("GHPPCNBBHDK")]
	public float DNDHIFENDPJ = 0.2f;

	private Vector3 GIELOCNNOMA;

	private bool JAOOMCLDJFD;

	private bool MKCDLIHODBA;

	private bool CFFHPFLGEMP;

	private bool MFPCAKGJCAI;

	private void LCHGOPCPPIB()
	{
		if (JAOOMCLDJFD && MKCDLIHODBA)
		{
			ALMFLLPPEAP(UICamera.IsHighlighted(base.gameObject));
		}
	}

	private void ENNFAAHDFFA()
	{
		if (JAOOMCLDJFD && MKCDLIHODBA)
		{
			ALMFLLPPEAP(UICamera.IsHighlighted(base.gameObject));
		}
	}

	private void Start()
	{
		if (!JAOOMCLDJFD)
		{
			JAOOMCLDJFD = true;
			if (NIHOBEAHEKJ == null)
			{
				NIHOBEAHEKJ = base.transform;
			}
			GIELOCNNOMA = NIHOBEAHEKJ.localScale;
		}
	}

	private void ALMFLLPPEAP(bool HPKGAFMDMLD)
	{
		if (base.enabled)
		{
			if (!JAOOMCLDJFD)
			{
				LFGAFALKANI();
			}
			MKCDLIHODBA = HPKGAFMDMLD;
		}
	}

	private void OEIKEEBDLFF()
	{
		if (NIHOBEAHEKJ == null)
		{
			NIHOBEAHEKJ = base.transform;
		}
		GIELOCNNOMA = NIHOBEAHEKJ.localScale;
	}

	public virtual void GJCDBCMNJEJ(bool DGOOLMFNBFB)
	{
		if (base.enabled)
		{
			if (!JAOOMCLDJFD)
			{
				LFGAFALKANI();
			}
			CFFHPFLGEMP = DGOOLMFNBFB;
			if (DGOOLMFNBFB)
			{
				TweenScale tweenScale = TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, Vector3.Scale(GIELOCNNOMA, HCAJFFJBCOJ));
				tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, new UITweener.OnFinished(KNOEOMOBPGM));
				tweenScale.method = UITweener.Method.Linear;
				MFPCAKGJCAI = true;
			}
			else if (!MFPCAKGJCAI)
			{
				TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, GIELOCNNOMA).method = (UITweener.Method)7;
			}
		}
	}

	private void OnHover(bool HPKGAFMDMLD)
	{
		if (base.enabled)
		{
			if (!JAOOMCLDJFD)
			{
				Start();
			}
			MKCDLIHODBA = HPKGAFMDMLD;
		}
	}

	public virtual void MFGCPPPDLFK(bool DGOOLMFNBFB)
	{
		if (base.enabled)
		{
			if (!JAOOMCLDJFD)
			{
				LFGAFALKANI();
			}
			CFFHPFLGEMP = DGOOLMFNBFB;
			if (DGOOLMFNBFB)
			{
				TweenScale tweenScale = TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, Vector3.Scale(GIELOCNNOMA, HCAJFFJBCOJ));
				tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, new UITweener.OnFinished(KNOEOMOBPGM));
				tweenScale.method = (UITweener.Method)8;
				MFPCAKGJCAI = true;
			}
			else if (!MFPCAKGJCAI)
			{
				TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, GIELOCNNOMA).method = UITweener.Method.EaseOut;
			}
		}
	}

	private void LPKEGOIAEJC()
	{
		if (!JAOOMCLDJFD)
		{
			JAOOMCLDJFD = true;
			if (NIHOBEAHEKJ == null)
			{
				NIHOBEAHEKJ = base.transform;
			}
			GIELOCNNOMA = NIHOBEAHEKJ.localScale;
		}
	}

	private void LFGAFALKANI()
	{
		if (!JAOOMCLDJFD)
		{
			JAOOMCLDJFD = false;
			if (NIHOBEAHEKJ == null)
			{
				NIHOBEAHEKJ = base.transform;
			}
			GIELOCNNOMA = NIHOBEAHEKJ.localScale;
		}
	}

	private void EHKKAOLJMCF()
	{
		if (NIHOBEAHEKJ == null)
		{
			NIHOBEAHEKJ = base.transform;
		}
		GIELOCNNOMA = NIHOBEAHEKJ.localScale;
	}

	public virtual void OnPress(bool DGOOLMFNBFB)
	{
		if (base.enabled)
		{
			if (!JAOOMCLDJFD)
			{
				Start();
			}
			CFFHPFLGEMP = DGOOLMFNBFB;
			if (DGOOLMFNBFB)
			{
				TweenScale tweenScale = TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, Vector3.Scale(GIELOCNNOMA, HCAJFFJBCOJ));
				tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, new UITweener.OnFinished(KNOEOMOBPGM));
				tweenScale.method = UITweener.Method.EaseInOut;
				MFPCAKGJCAI = true;
			}
			else if (!MFPCAKGJCAI)
			{
				TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, GIELOCNNOMA).method = UITweener.Method.EaseInOut;
			}
		}
	}

	private void KNOEOMOBPGM(UITweener MGDJMGHCAAI)
	{
		if (MFPCAKGJCAI && !CFFHPFLGEMP)
		{
			TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, GIELOCNNOMA).method = UITweener.Method.EaseInOut;
		}
		MFPCAKGJCAI = false;
	}

	public virtual void KEBBKGBHFAF(bool DGOOLMFNBFB)
	{
		if (base.enabled)
		{
			if (!JAOOMCLDJFD)
			{
				LPKEGOIAEJC();
			}
			CFFHPFLGEMP = DGOOLMFNBFB;
			if (DGOOLMFNBFB)
			{
				TweenScale tweenScale = TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, Vector3.Scale(GIELOCNNOMA, HCAJFFJBCOJ));
				tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, new UITweener.OnFinished(KNOEOMOBPGM));
				tweenScale.method = UITweener.Method.EaseOut;
				MFPCAKGJCAI = true;
			}
			else if (!MFPCAKGJCAI)
			{
				TweenScale.Begin(NIHOBEAHEKJ.gameObject, DNDHIFENDPJ, GIELOCNNOMA).method = (UITweener.Method)8;
			}
		}
	}

	private void KIKEGJKJDJM()
	{
		if (JAOOMCLDJFD && MKCDLIHODBA)
		{
			OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	private void OnDisable()
	{
		if (NIHOBEAHEKJ != null)
		{
			TweenScale component = NIHOBEAHEKJ.GetComponent<TweenScale>();
			if (component != null)
			{
				component.scale = GIELOCNNOMA;
				component.enabled = false;
			}
		}
	}

	private void NDAJNMAOHHA()
	{
		if (NIHOBEAHEKJ == null)
		{
			NIHOBEAHEKJ = base.transform;
		}
		GIELOCNNOMA = NIHOBEAHEKJ.localScale;
	}

	private void HPNEBKMFAIJ()
	{
		if (NIHOBEAHEKJ != null)
		{
			TweenScale component = NIHOBEAHEKJ.GetComponent<TweenScale>();
			if (component != null)
			{
				component.scale = GIELOCNNOMA;
				component.enabled = true;
			}
		}
	}

	private void OnEnable()
	{
		if (JAOOMCLDJFD && MKCDLIHODBA)
		{
			OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}
}
