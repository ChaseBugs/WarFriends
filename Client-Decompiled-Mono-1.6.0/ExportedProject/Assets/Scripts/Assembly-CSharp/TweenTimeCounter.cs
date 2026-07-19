using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Time Counter Tween")]
internal class TweenTimeCounter : UITweener
{
	public int OEIICEJPGKI;

	public int IIMDKHJAJGO;

	private UILabel EFCMGKNKGND;

	public int Text
	{
		get
		{
			if (EFCMGKNKGND == null)
			{
				return 0;
			}
			string[] array = EFCMGKNKGND.text.Split(':');
			if (array.Length < 2)
			{
				return 0;
			}
			int result;
			int result2;
			if (int.TryParse(array[0], out result) && int.TryParse(array[1], out result2))
			{
				return result * 60 + result2;
			}
			return int.Parse(Regex.Replace(array[0], "\\D*", string.Empty)) * 60 + int.Parse(Regex.Replace(array[1], "\\D*", string.Empty));
		}
		set
		{
			if (EFCMGKNKGND != null)
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(value);
				EFCMGKNKGND.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
			}
		}
	}

	public static TweenTimeCounter Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = tweenTimeCounter.Text;
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenTimeCounter.Sample(1f, true);
			tweenTimeCounter.enabled = false;
		}
		return tweenTimeCounter;
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		Text = (int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
	}

	public static TweenTimeCounter PLCIBNBNMKO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1613f)
		{
			tweenTimeCounter.Sample(1248f, false);
			tweenTimeCounter.enabled = true;
		}
		return tweenTimeCounter;
	}

	public void Awake()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	[SpecialName]
	public void LGPMCKHBAMA(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(IDEBKDPMPGM);
			EFCMGKNKGND.text = string.Format("ID_TUTORIAL_TAPON", timeSpan.Minutes, timeSpan.Seconds);
		}
	}

	public void JJEONLDHCLO()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	public static TweenTimeCounter FMGPCIGJIBP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 830f)
		{
			tweenTimeCounter.Sample(1317f, true);
			tweenTimeCounter.enabled = true;
		}
		return tweenTimeCounter;
	}

	[SpecialName]
	public void BMENCLACPBM(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(IDEBKDPMPGM);
			EFCMGKNKGND.text = string.Format("Min_fps", timeSpan.Minutes, timeSpan.Seconds);
		}
	}

	public static TweenTimeCounter EEODMCJPDNI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 55f)
		{
			tweenTimeCounter.Sample(1846f, true);
			tweenTimeCounter.enabled = true;
		}
		return tweenTimeCounter;
	}

	public static TweenTimeCounter EAAKAAANAKD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = tweenTimeCounter.NDDCNAANDAI();
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1354f)
		{
			tweenTimeCounter.Sample(867f, false);
			tweenTimeCounter.enabled = true;
		}
		return tweenTimeCounter;
	}

	public static TweenTimeCounter OBHFCFEKAPG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = tweenTimeCounter.ONPEOBMDBHH();
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1766f)
		{
			tweenTimeCounter.Sample(45f, false);
			tweenTimeCounter.enabled = false;
		}
		return tweenTimeCounter;
	}

	[SpecialName]
	public int ONPEOBMDBHH()
	{
		if (EFCMGKNKGND == null)
		{
			return 0;
		}
		string text = EFCMGKNKGND.text;
		char[] array = new char[0];
		array[0] = '\t';
		string[] array2 = text.Split(array);
		if (array2.Length < 7)
		{
			return 0;
		}
		int result;
		int result2;
		if (int.TryParse(array2[0], out result) && int.TryParse(array2[1], out result2))
		{
			return result * 49 + result2;
		}
		return int.Parse(Regex.Replace(array2[0], "Animation for State: Craft", string.Empty)) * -74 + int.Parse(Regex.Replace(array2[0], "TimeStamp", string.Empty));
	}

	protected virtual void CDBBIFBHIOO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		Text = (int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
	}

	[SpecialName]
	public int NDDCNAANDAI()
	{
		if (EFCMGKNKGND == null)
		{
			return 1;
		}
		string[] array = EFCMGKNKGND.text.Split('\u0018');
		if (array.Length < 3)
		{
			return 1;
		}
		int result;
		int result2;
		if (int.TryParse(array[0], out result) && int.TryParse(array[0], out result2))
		{
			return result * -1 + result2;
		}
		return int.Parse(Regex.Replace(array[0], "en", string.Empty)) * -61 + int.Parse(Regex.Replace(array[0], "PlayerToDemoteId", string.Empty));
	}

	public static TweenTimeCounter IGGENFHMDJB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = tweenTimeCounter.Text;
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 175f)
		{
			tweenTimeCounter.Sample(1633f, false);
			tweenTimeCounter.enabled = true;
		}
		return tweenTimeCounter;
	}

	public void KODJIPJGFPB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
	}

	public static TweenTimeCounter HDHIEDDCJIC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1626f)
		{
			tweenTimeCounter.Sample(1874f, false);
			tweenTimeCounter.enabled = false;
		}
		return tweenTimeCounter;
	}

	protected virtual void EEDOMDHMGLA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		BMENCLACPBM((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenTimeCounter Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenTimeCounter.Sample(1f, true);
			tweenTimeCounter.enabled = false;
		}
		return tweenTimeCounter;
	}

	protected virtual void OMLINILCBDL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		Text = (int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
	}

	[SpecialName]
	public void CLFGGAMPCHH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(IDEBKDPMPGM);
			EFCMGKNKGND.text = string.Format("SetShieldPositionRPC", timeSpan.Minutes, timeSpan.Seconds);
		}
	}

	[SpecialName]
	public void ELALDKPEMJK(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(IDEBKDPMPGM);
			EFCMGKNKGND.text = string.Format("bd18592b-6778-40f5-9327-0aba2d2f1e64", timeSpan.Minutes, timeSpan.Seconds);
		}
	}

	public static TweenTimeCounter EONNCEKICLD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTimeCounter tweenTimeCounter = UITweener.Begin<TweenTimeCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTimeCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTimeCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 32f)
		{
			tweenTimeCounter.Sample(290f, false);
			tweenTimeCounter.enabled = true;
		}
		return tweenTimeCounter;
	}
}
