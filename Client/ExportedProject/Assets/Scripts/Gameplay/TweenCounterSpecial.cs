using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("NGUI/Tween/Tween Counter Special")]
public class TweenCounterSpecial : UITweener
{
	[FormerlySerializedAs("EMMCJEEABGA")]
	public int OEIICEJPGKI;

	[FormerlySerializedAs("FFJGKOLGFLL")]
	public int IIMDKHJAJGO;

	[FormerlySerializedAs("FFPHOPHOJMC")]
	public bool MFMJGHPJFKC;

	public SoundsManager.KJGDNLHKPOG BNPCJNKBCNL = SoundsManager.KJGDNLHKPOG.CounterSoundExperience;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<UILabel, int> KHKAGBDGLHI;

	private UILabel EFCMGKNKGND;

	private float OJJNFMLBBHP;

	public int text
	{
		get
		{
			if (EFCMGKNKGND != null)
			{
				if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "[.,]*", string.Empty), out var result))
				{
					return result;
				}
				string s = Regex.Replace(EFCMGKNKGND.text, "^\\D*", string.Empty);
				return int.Parse(s, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
			}
			return 0;
		}
		set
		{
			if (EFCMGKNKGND != null)
			{
				if (KHKAGBDGLHI != null)
				{
					KHKAGBDGLHI(EFCMGKNKGND, value);
				}
				else
				{
					EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(value);
				}
			}
		}
	}

	public event Action<UILabel, int> SetText
	{
		add
		{
			Action<UILabel, int> action = KHKAGBDGLHI;
			Action<UILabel, int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<UILabel, int> action = KHKAGBDGLHI;
			Action<UILabel, int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void KODJIPJGFPB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	[SpecialName]
	public void OLKHLAPFDKC(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int BELENPBFBED()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "opponentState.willHide = true", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_READYTIME", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	protected virtual void FLAFCDGMJCP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NONFBFNPHFJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1025f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1691f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void BLFGIONFDKK(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void KHKAAPKJOIE(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	public static TweenCounterSpecial EHLGFPMLLOD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.DPDDLEIJONG();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 108f;
		if (DNDHIFENDPJ <= 890f)
		{
			tweenCounterSpecial.Sample(738f, isFinished: false);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void PIGELAHCNNN(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int AGMFLANEEHN()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_TUTORIAL_GO_BUY_ARMY_4", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "Sniper_Tutorial_Played", string.Empty);
			return int.Parse(s, (NumberStyles)(-1), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public void IDKKGMKICMF(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void KEPEHFLOBPN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NGICEPBDOFP((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1619f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 525f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void PBCDDNOCJOI()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	protected virtual void HODEHFHIBOO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			KJODICHJGKE((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1700f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1156f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenCounterSpecial DFNHCFNJCMC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.DPDDLEIJONG();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 448f;
		if (DNDHIFENDPJ <= 272f)
		{
			tweenCounterSpecial.Sample(303f, isFinished: true);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void OBCMKDGIDOP(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void IEBHCNFALAB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	[SpecialName]
	public void EFBMIPFMAPC(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	protected virtual void ADNEHMKIBOD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NONFBFNPHFJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1589f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1236f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenCounterSpecial Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.text;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenCounterSpecial.Sample(1f, isFinished: true);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void HKKLADILJFB(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public void OAPBOEGNJGM(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void PKAGOBFGJID(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void OKENHJJFCFF(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void Awake()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	[SpecialName]
	public void KOABONFAMLO(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			this.text = (int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 0.065f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenCounterSpecial ECHFMFFNJON(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.PFMGPFGMGFI();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 213f;
		if (DNDHIFENDPJ <= 1336f)
		{
			tweenCounterSpecial.Sample(332f, isFinished: true);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void EFCHJGJGKGC(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void BKNFCCGDKCN(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	public static TweenCounterSpecial EEODMCJPDNI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 688f;
		if (DNDHIFENDPJ <= 849f)
		{
			tweenCounterSpecial.Sample(1895f, isFinished: false);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void EFBDGJOGKFJ(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public static TweenCounterSpecial MLEAFANPCJB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 697f;
		if (DNDHIFENDPJ <= 171f)
		{
			tweenCounterSpecial.Sample(1971f, isFinished: false);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void NGICEPBDOFP(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public void DBAEFALMGBD(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void LIADBDHBKGL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			KOABONFAMLO((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1977f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1251f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void IFDCJBCOPCD(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	public static TweenCounterSpecial KMJOPOLHAJJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1036f;
		if (DNDHIFENDPJ <= 587f)
		{
			tweenCounterSpecial.Sample(1905f, isFinished: true);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	public static TweenCounterSpecial IPOEOHBLGMJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.FJBEAJMAANA();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1647f;
		if (DNDHIFENDPJ <= 1048f)
		{
			tweenCounterSpecial.Sample(990f, isFinished: false);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void DOIBAKKJMNF(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public void DIIIBPHGAGB(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MNAJGMAFJGL()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	[SpecialName]
	public int OIANBNBCNBM()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_CONFIRM_ERROR", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_INVITEDYOUTOFIGHT", string.Empty);
			return int.Parse(s, ~NumberStyles.Number, CultureInfo.InvariantCulture);
		}
		return 1;
	}

	[SpecialName]
	public void MILIAOGHFAE(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void KJODICHJGKE(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public void NONFBFNPHFJ(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public void AGEMKMJFGHE(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void KJDOPOPIGHG(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void NJFPJLFOMNI(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void CDDOABMCFPO(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public static TweenCounterSpecial IECHDKECJAB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.DPDDLEIJONG();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1387f;
		if (DNDHIFENDPJ <= 9f)
		{
			tweenCounterSpecial.Sample(772f, isFinished: false);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void LIBGCHHPJCN(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public void KIMDLFKMEMF(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void COBFNJPLCIM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			HKKLADILJFB((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 9f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 766f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenCounterSpecial KMDIDKBDCDM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.MJAODLJCKDA();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 789f;
		if (DNDHIFENDPJ <= 204f)
		{
			tweenCounterSpecial.Sample(1635f, isFinished: false);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void OHLMIKCEDOJ(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void EGMBELHFNMO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			HKKLADILJFB((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 643f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1573f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenCounterSpecial HGBKLMHAGBF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1671f;
		if (DNDHIFENDPJ <= 1446f)
		{
			tweenCounterSpecial.Sample(550f, isFinished: true);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	protected virtual void KEFFJEEJGLL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			DOIBAKKJMNF((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1437f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 639f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public int FJBEAJMAANA()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "Grenade_Throwing_Tutorial_Duration", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "totalMem", string.Empty);
			return int.Parse(s, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
		}
		return 1;
	}

	[SpecialName]
	public void PKDEIKFDCLE(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int OHDACMDAGDP()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "#DANIEL# Everyplay IsReadyForRecording: ", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "Beanstalk: Get Squad Details", string.Empty);
			return int.Parse(s, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses, CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public static TweenCounterSpecial LMNBPJEACEA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1467f;
		if (DNDHIFENDPJ <= 1619f)
		{
			tweenCounterSpecial.Sample(1321f, isFinished: true);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public void PJDIJCABPDJ(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void EOHIHKGPOJD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			EFBMIPFMAPC((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1163f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 460f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public int DPDDLEIJONG()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "CardWasUsedOnline", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "ThrowGrenadeFromCrawl", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	public static TweenCounterSpecial PGAHIMIGILO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.GAFPAEOJNKF();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1015f;
		if (DNDHIFENDPJ <= 262f)
		{
			tweenCounterSpecial.Sample(98f, isFinished: true);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	public static TweenCounterSpecial IOLBDLOPJGJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.PFMGPFGMGFI();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1249f;
		if (DNDHIFENDPJ <= 1869f)
		{
			tweenCounterSpecial.Sample(1913f, isFinished: true);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public int MJAODLJCKDA()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_SLOTUPGRADE_DAMAGE", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "menu-weapon-mp5-elite", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public static TweenCounterSpecial FFEEMJJIMOE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1976f;
		if (DNDHIFENDPJ <= 1021f)
		{
			tweenCounterSpecial.Sample(452f, isFinished: true);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	public static TweenCounterSpecial NPHFBDMKODP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = tweenCounterSpecial.BELENPBFBED();
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1139f;
		if (DNDHIFENDPJ <= 75f)
		{
			tweenCounterSpecial.Sample(1447f, isFinished: false);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	protected virtual void OMLINILCBDL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			BKNFCCGDKCN((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 134f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 240f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenCounterSpecial OBHFCFEKAPG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 1443f;
		if (DNDHIFENDPJ <= 85f)
		{
			tweenCounterSpecial.Sample(1578f, isFinished: true);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	protected virtual void FNGHCNPJDAJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			KOABONFAMLO((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1679f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1641f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void CMJLPFKEEIJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			DOIBAKKJMNF((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 12f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 846f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void APGJBICGIJG(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public void GHDKKNDKGPO(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void AMCMKKFNHCJ(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			if (KHKAGBDGLHI != null)
			{
				KHKAGBDGLHI(EFCMGKNKGND, IDEBKDPMPGM);
			}
			else
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public void JKHFHIIIMKO(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public static TweenCounterSpecial OLIIHGDGKKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 415f;
		if (DNDHIFENDPJ <= 1519f)
		{
			tweenCounterSpecial.Sample(1196f, isFinished: true);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	public static TweenCounterSpecial Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenCounterSpecial.Sample(1f, isFinished: true);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	public void BACJPKBJNIB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	public void FIGOGIMJIIN()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	[SpecialName]
	public int FPFHNOCHOBN()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "Card_1_Played", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "LifeCount", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	protected virtual void MMAFAFJEAHL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			HKKLADILJFB((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1377f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1233f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void FNAGOGFFMNH(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int GAFPAEOJNKF()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "REINTENTAR", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "Special pack \"{0}\" already in offer manager cache.", string.Empty);
			return int.Parse(s, NumberStyles.Integer | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	protected virtual void ICANGOPCADD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NGICEPBDOFP((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 56f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 138f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void HOINLOMCGFD()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	public static TweenCounterSpecial DDJHGKMBNDK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 187f;
		if (DNDHIFENDPJ <= 1346f)
		{
			tweenCounterSpecial.Sample(1109f, isFinished: false);
			tweenCounterSpecial.enabled = true;
		}
		return tweenCounterSpecial;
	}

	public static TweenCounterSpecial MDBMAINKPKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenCounterSpecial tweenCounterSpecial = UITweener.Begin<TweenCounterSpecial>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenCounterSpecial.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenCounterSpecial.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenCounterSpecial.OJJNFMLBBHP = 961f;
		if (DNDHIFENDPJ <= 759f)
		{
			tweenCounterSpecial.Sample(353f, isFinished: true);
			tweenCounterSpecial.enabled = false;
		}
		return tweenCounterSpecial;
	}

	[SpecialName]
	public int PFMGPFGMGFI()
	{
		if (EFCMGKNKGND != null)
		{
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "On Debug Add Scraps Request: ", string.Empty), out var result))
			{
				return result;
			}
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_ACTIVATEXMOREINSTANTBATTLES", string.Empty);
			return int.Parse(s, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public void BOEICIFMCON(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MNNOAEPDFCP(Action<UILabel, int> IDEBKDPMPGM)
	{
		Action<UILabel, int> action = KHKAGBDGLHI;
		Action<UILabel, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KHKAGBDGLHI, (Action<UILabel, int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
