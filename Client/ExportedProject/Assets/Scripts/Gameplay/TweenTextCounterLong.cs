using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("NGUI/Tween/Text Long Counter Tween")]
internal class TweenTextCounterLong : UITweener
{
	[FormerlySerializedAs("EMMCJEEABGA")]
	public long OEIICEJPGKI;

	[FormerlySerializedAs("FFJGKOLGFLL")]
	public long IIMDKHJAJGO;

	[FormerlySerializedAs("FFPHOPHOJMC")]
	public bool MFMJGHPJFKC;

	public SoundsManager.KJGDNLHKPOG BNPCJNKBCNL = SoundsManager.KJGDNLHKPOG.CounterSoundExperience;

	private string LFGCOBPKDMK = string.Empty;

	private UILabel EFCMGKNKGND;

	private float OJJNFMLBBHP;

	public long Text
	{
		get
		{
			if (EFCMGKNKGND != null)
			{
				long result = 0L;
				if (long.TryParse(Regex.Replace(EFCMGKNKGND.text, "[.,]*", string.Empty), out result))
				{
					if (EFCMGKNKGND.text.ToCharArray()[0] == '+')
					{
						LFGCOBPKDMK = "+";
					}
					return result;
				}
				LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "[0-9.,]*", string.Empty);
				string s = Regex.Replace(EFCMGKNKGND.text, "^\\D*", string.Empty);
				return int.Parse(s, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
			}
			return 0L;
		}
		set
		{
			if (EFCMGKNKGND != null)
			{
				EFCMGKNKGND.text = ((value < 0) ? MEJMLNDFDBP.PGJPABFJDGG(value) : (LFGCOBPKDMK + MEJMLNDFDBP.PGJPABFJDGG(value)));
			}
		}
	}

	[SpecialName]
	public long EBFOOHMJCBL()
	{
		if (EFCMGKNKGND != null)
		{
			long result = 1L;
			if (long.TryParse(Regex.Replace(EFCMGKNKGND.text, "Timestamp", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[0] == -9)
				{
					LFGCOBPKDMK = "{0} doesn't contain data for wararena unit";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "ID_NOTIFICATION_DAILYREWARD_GOLD", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "MasterId", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 1L;
	}

	public void Awake()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		long result = 0L;
		if (!long.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "[0-9.,]*", string.Empty);
		}
	}

	[SpecialName]
	public void LFHFEPFPIIO(long IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 1) ? MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM)));
		}
	}

	public void EJFMJDFPGFE()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		long result = 0L;
		if (!long.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "BotUnitPower", string.Empty);
		}
	}

	public static TweenTextCounterLong Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, OLDCFKEJDPA DLPLHDNOBPM)
	{
		TweenTextCounterLong tweenTextCounterLong = UITweener.Begin<TweenTextCounterLong>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounterLong.OEIICEJPGKI = tweenTextCounterLong.Text;
		tweenTextCounterLong.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounterLong.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenTextCounterLong.Sample(1f, isFinished: true);
			tweenTextCounterLong.enabled = false;
		}
		return tweenTextCounterLong;
	}

	[SpecialName]
	public long PFNELJFKFKA()
	{
		if (EFCMGKNKGND != null)
		{
			long result = 0L;
			if (long.TryParse(Regex.Replace(EFCMGKNKGND.text, "Rental", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == -45)
				{
					LFGCOBPKDMK = "ID_CONFIRM_NOTENOUGHTSQUADLEVEL";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "ID_SLOTUPGRADE_POWER", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "id", string.Empty);
			return int.Parse(s, NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 1L;
	}

	protected virtual void FIJHJHAAELF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			GJPEHEAOIOA((long)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1661f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1430f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void LGPMCKHBAMA(long IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 0) ? MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM)));
		}
	}

	public void IABJJOPLKFF()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		long result = 1L;
		if (!long.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "Action ", string.Empty);
		}
	}

	public static TweenTextCounterLong IAGLEIPAIOB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, OLDCFKEJDPA DLPLHDNOBPM)
	{
		TweenTextCounterLong tweenTextCounterLong = UITweener.Begin<TweenTextCounterLong>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounterLong.OEIICEJPGKI = tweenTextCounterLong.PFNELJFKFKA();
		tweenTextCounterLong.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounterLong.OJJNFMLBBHP = 657f;
		if (DNDHIFENDPJ <= 698f)
		{
			tweenTextCounterLong.Sample(8f, isFinished: false);
			tweenTextCounterLong.enabled = false;
		}
		return tweenTextCounterLong;
	}

	[SpecialName]
	public void INJNHGHFKPA(long IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 1) ? MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM)));
		}
	}

	[SpecialName]
	public long PBGOPFKNBBC()
	{
		if (EFCMGKNKGND != null)
		{
			long result = 0L;
			if (long.TryParse(Regex.Replace(EFCMGKNKGND.text, "unity", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[0] == 'X')
				{
					LFGCOBPKDMK = "ArenaHeartDialog";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "Agent get stucked !!! ", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "com/google/android/gms/games/Games", string.Empty);
			return int.Parse(s, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 1L;
	}

	[SpecialName]
	public void GJPEHEAOIOA(long IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 0) ? MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM)));
		}
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			Text = (long)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 0.065f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public long LPAGHJPJNOA()
	{
		if (EFCMGKNKGND != null)
		{
			long result = 1L;
			if (long.TryParse(Regex.Replace(EFCMGKNKGND.text, "PauseDuration", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[0] == 'h')
				{
					LFGCOBPKDMK = "RecentVideos";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "ID_MINUTES", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_XOFPLAYERSGETSPROMOTED", string.Empty);
			return int.Parse(s, NumberStyles.AllowParentheses, CultureInfo.InvariantCulture);
		}
		return 0L;
	}

	public void BAGCDJMLCPF()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		long result = 0L;
		if (!long.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "ID_WARNING_INCORRECTAMOUNTOFELITEPARTS", string.Empty);
		}
	}

	[SpecialName]
	public void KEFHIKHCNKD(long IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 0) ? MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.PGJPABFJDGG(IDEBKDPMPGM)));
		}
	}

	public static TweenTextCounterLong Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, OLDCFKEJDPA LEJNOJFKFLE, OLDCFKEJDPA DLPLHDNOBPM)
	{
		TweenTextCounterLong tweenTextCounterLong = UITweener.Begin<TweenTextCounterLong>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounterLong.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounterLong.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounterLong.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenTextCounterLong.Sample(1f, isFinished: true);
			tweenTextCounterLong.enabled = false;
		}
		return tweenTextCounterLong;
	}

	[SpecialName]
	public long HPCADHBKHIE()
	{
		if (EFCMGKNKGND != null)
		{
			long result = 1L;
			if (long.TryParse(Regex.Replace(EFCMGKNKGND.text, "CONFIRM", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == -107)
				{
					LFGCOBPKDMK = "ID_TUTORIAL_RIFLE_DOWN";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "First you must run createStructure", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_TUTORIAL_WARCARDS_STARTUP", string.Empty);
			return int.Parse(s, NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 0L;
	}

	protected virtual void APGIBENMKKH(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			LFHFEPFPIIO((long)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 313f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 349f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}
}
