using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Suffix Text Counter Tween")]
internal class TweenSufixTextCounter : UITweener
{
	public int OEIICEJPGKI;

	public int IIMDKHJAJGO;

	public bool MFMJGHPJFKC;

	public SoundsManager.KJGDNLHKPOG BNPCJNKBCNL = SoundsManager.KJGDNLHKPOG.CounterSoundExperience;

	private string OIFGDECEHCF = string.Empty;

	private UILabel EFCMGKNKGND;

	private float OJJNFMLBBHP;

	public int Text
	{
		get
		{
			if (EFCMGKNKGND != null)
			{
				int result;
				if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "[.,]*", string.Empty), out result))
				{
					return result;
				}
				OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "[0-9.,]*", string.Empty);
				string s = Regex.Replace(EFCMGKNKGND.text, "\\D*$", string.Empty);
				return int.Parse(s);
			}
			return 0;
		}
		set
		{
			if (EFCMGKNKGND != null)
			{
				EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(value) + OIFGDECEHCF;
			}
		}
	}

	public void FGOGGLDAKHL()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "\"", string.Empty);
		}
	}

	protected virtual void OOAPALCAABD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			HBBGEAAJOPN((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1061f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 890f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter JPJPAJEBNPK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 533f;
		if (DNDHIFENDPJ <= 819f)
		{
			tweenSufixTextCounter.Sample(1867f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter MNBLBMJICDB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.GJDLFDPMKFH();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1539f;
		if (DNDHIFENDPJ <= 844f)
		{
			tweenSufixTextCounter.Sample(184f, true);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter IOLBDLOPJGJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.CHKCKICPBPK();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 29f;
		if (DNDHIFENDPJ <= 1131f)
		{
			tweenSufixTextCounter.Sample(560f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public void NFOGAECOFMD(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public static TweenSufixTextCounter MDEAIEJHIGE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.CHKCKICPBPK();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 161f;
		if (DNDHIFENDPJ <= 1843f)
		{
			tweenSufixTextCounter.Sample(129f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter LMNBPJEACEA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1604f;
		if (DNDHIFENDPJ <= 785f)
		{
			tweenSufixTextCounter.Sample(1695f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	public void CFGDCEOLKJG()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "ID_WARNING_NOTENOUGHGOLDARENA", string.Empty);
		}
	}

	[SpecialName]
	public int KJDGHKOFMAP()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "BattleId", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Play_Card_Tutorial", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_SLOTUPGRADE_DAMAGE", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	public void MEBEHLLPMPK()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Manual_Unit_Spawn", string.Empty);
		}
	}

	protected virtual void CMJLPFKEEIJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			OPHEHFFBHHA((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 286f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 906f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter GEKPHELKFNB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 355f;
		if (DNDHIFENDPJ <= 1743f)
		{
			tweenSufixTextCounter.Sample(1262f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int GJDLFDPMKFH()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "On Get PLayer Info", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "DailyMissionsCompletionRewardTickets", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "Getting matcap texture for player with null player point", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	[SpecialName]
	public int ECEPGEPJJEA()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "no player Id found", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "#AccoutCheck# check gpgs, but Id is not same {0} != {1}", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "game-card-ico-headsup", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	public static TweenSufixTextCounter CPHOAGPKAMB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.HBHNJNCAHMF();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 539f;
		if (DNDHIFENDPJ <= 1322f)
		{
			tweenSufixTextCounter.Sample(986f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	protected virtual void IKLMKNFGAOI(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			GJPEHEAOIOA((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1566f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1877f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void NGGJHDCOLEC()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "{0} {1}", string.Empty);
		}
	}

	[SpecialName]
	public int KOEBFEOJHMC()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "menu-assignments-type-win", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "file://", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "On server", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	[SpecialName]
	public int LHDJLCKKKDE()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "Fetching OBB", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "special", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "VN", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	[SpecialName]
	public void LONBHOFNPCE(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	protected virtual void LODPHEAJDDD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			HBBGEAAJOPN((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1756f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1691f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void OOBGBOJJPDH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	[SpecialName]
	public void OPHEHFFBHHA(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	[SpecialName]
	public void HBBGEAAJOPN(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	[SpecialName]
	public void OHOJKJBELIH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public static TweenSufixTextCounter DFOPNNAAPHK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.GNEHDPPMLHG();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1320f;
		if (DNDHIFENDPJ <= 952f)
		{
			tweenSufixTextCounter.Sample(1627f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			Text = (int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 0.065f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter OBHFCFEKAPG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1189f;
		if (DNDHIFENDPJ <= 989f)
		{
			tweenSufixTextCounter.Sample(1392f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public void NFLLHPBNCMI(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	[SpecialName]
	public void AFIJIFFCPGJ(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public static TweenSufixTextCounter HBHMEFGMNNN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 9f;
		if (DNDHIFENDPJ <= 790f)
		{
			tweenSufixTextCounter.Sample(1468f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int ILIJHIAJLIK()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "CardManagerData", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "HEAVYTURRET", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_YOUHAVENOBRONZEWARCARDSAVAILABLE", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	public static TweenSufixTextCounter Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.Text;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenSufixTextCounter.Sample(1f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public void NCEEHADNDIH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	protected virtual void FJCCEPMIHJP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			LONBHOFNPCE((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 454f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1579f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public int OHCMEFIGIMN()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "country-chile", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "TestingName", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "WarFriends require to download approximately 190MB of extra data to run.\nDownload time may vary based on your network and location.\n\nDo you wish to proceed?", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	protected virtual void KJFBODMJCMO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			HBBGEAAJOPN((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 341f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1658f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter BPBNEOOGIKF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1437f;
		if (DNDHIFENDPJ <= 1225f)
		{
			tweenSufixTextCounter.Sample(564f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public void IGFNMIMOEJO(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public void KINHAJCDKGN()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Player not in squad and should be in squad ", string.Empty);
		}
	}

	public static TweenSufixTextCounter CPEIKKAAAIL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.GNEHDPPMLHG();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1808f;
		if (DNDHIFENDPJ <= 708f)
		{
			tweenSufixTextCounter.Sample(144f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter IPJJKFNPEEC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 147f;
		if (DNDHIFENDPJ <= 1993f)
		{
			tweenSufixTextCounter.Sample(1406f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter PMLCBMLFOAF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.Text;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 822f;
		if (DNDHIFENDPJ <= 1476f)
		{
			tweenSufixTextCounter.Sample(962f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter PMOPHLCJGNI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.OMLOBCOIOOL();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1176f;
		if (DNDHIFENDPJ <= 484f)
		{
			tweenSufixTextCounter.Sample(121f, true);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	public void HIGCNIEAMBN()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "BlackMarketOffer", string.Empty);
		}
	}

	[SpecialName]
	public void JECPDLIGJMD(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public static TweenSufixTextCounter LKINEOAFENE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.GJDLFDPMKFH();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1450f;
		if (DNDHIFENDPJ <= 248f)
		{
			tweenSufixTextCounter.Sample(703f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter IJIDNJACAMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 953f;
		if (DNDHIFENDPJ <= 1694f)
		{
			tweenSufixTextCounter.Sample(1267f, true);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public void DOOEHJMEPKO(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public static TweenSufixTextCounter AFHNENMGEMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.HBHNJNCAHMF();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 118f;
		if (DNDHIFENDPJ <= 1290f)
		{
			tweenSufixTextCounter.Sample(24f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int KKMGDKHOJNE()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "_Alpha", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "CONTENTS_FILE_DESCRIPTOR", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "Awaiting players - Removing player ", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	public void HILDKBOJOGK()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Pack_Id", string.Empty);
		}
	}

	public static TweenSufixTextCounter GMNFMNAPAGL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 367f;
		if (DNDHIFENDPJ <= 1691f)
		{
			tweenSufixTextCounter.Sample(1029f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	public void BAMNBAABJEK()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Squad Request Sent!", string.Empty);
		}
	}

	public void AKKKDIBLICM()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "isGameCenter", string.Empty);
		}
	}

	public static TweenSufixTextCounter FLLGEEKOJOG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1566f;
		if (DNDHIFENDPJ <= 364f)
		{
			tweenSufixTextCounter.Sample(1203f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int OEKKCKPLBBF()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "+", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "ID_WARNING_CRAFTINGCLAIMNOTREADY", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "IsSpecial", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	[SpecialName]
	public void NNLHDKIJDFJ(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public static TweenSufixTextCounter ELICMAOEGKD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.CMKHGLDHILG();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1634f;
		if (DNDHIFENDPJ <= 1665f)
		{
			tweenSufixTextCounter.Sample(242f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int CHKCKICPBPK()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "Player_Avoided_Grenade_On_First_Try", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "SquadId", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_SQUADREWARDGET", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	public static TweenSufixTextCounter OLIIHGDGKKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.FNMIAFFILOL();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 401f;
		if (DNDHIFENDPJ <= 679f)
		{
			tweenSufixTextCounter.Sample(1340f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int FNMIAFFILOL()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "Google2u.AssaultRifle_AK47", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Error: Buddy card not ready! ", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_WARNING_PROMOTEERROR_TEXT", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	[SpecialName]
	public int HFFJNPHFMNM()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "old_version", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Setting unit delivery in ", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "Clicked on category ", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	public static TweenSufixTextCounter IECHDKECJAB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 841f;
		if (DNDHIFENDPJ <= 174f)
		{
			tweenSufixTextCounter.Sample(784f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	protected virtual void FGJENFGGGJP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			LONBHOFNPCE((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1286f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 973f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter IFKJMIKHKAN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.KJDGHKOFMAP();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 295f;
		if (DNDHIFENDPJ <= 1583f)
		{
			tweenSufixTextCounter.Sample(414f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public void IHDOFJPPAOF(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public static TweenSufixTextCounter DDJHGKMBNDK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.DCMEHNCIBPP();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1615f;
		if (DNDHIFENDPJ <= 1803f)
		{
			tweenSufixTextCounter.Sample(29f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	protected virtual void KHFPHOMLELJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			OECHJMMHHMJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 783f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1932f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public int HLCGKBGPCFH()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "OBB: Read Test - No data to read!", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "ID_PACK", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "special", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	[SpecialName]
	public int MEENHFKLNJL()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "Level", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "getExtrasPayload", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_USEREXISTSFACEBOOKTEXT", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	public static TweenSufixTextCounter NFCEEJODFMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 387f;
		if (DNDHIFENDPJ <= 1743f)
		{
			tweenSufixTextCounter.Sample(1183f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int PLMNFNNKHED()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "http://", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "ID_FEATURE_ACCURACY-FANCY", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ticketsSpent", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	[SpecialName]
	public int HBHNJNCAHMF()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, " K:", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Battle_length", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "SquadMessages", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	public static TweenSufixTextCounter GALIIPLCGAP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.GNEHDPPMLHG();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 602f;
		if (DNDHIFENDPJ <= 1917f)
		{
			tweenSufixTextCounter.Sample(1395f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public void EIPLFPJNCIB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "-", string.Empty);
		}
	}

	[SpecialName]
	public int OMLOBCOIOOL()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_CONFIRM_NOTACTIVEEVENT", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Text", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "DepositWarcards-{0}-{1}", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	protected virtual void CKKDPBFOAOK(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NFLLHPBNCMI((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 469f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 986f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter HGBKLMHAGBF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 460f;
		if (DNDHIFENDPJ <= 6f)
		{
			tweenSufixTextCounter.Sample(1419f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter PGAHIMIGILO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1098f;
		if (DNDHIFENDPJ <= 1541f)
		{
			tweenSufixTextCounter.Sample(171f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	protected virtual void LFJGEEDJGME(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NCNHBCNBPCK((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1726f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1427f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void FNHJHHIKKBM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			OOBGBOJJPDH((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 669f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 542f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void PJJKLDFBMDA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			HBBGEAAJOPN((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1425f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 866f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void FNABAIKEPBH(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			JECPDLIGJMD((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 25f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 147f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void OECHJMMHHMJ(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public void HCIEHAOEMDI()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "ID_FEATURE_BURSTSIZE-WEAPONPREFIX", string.Empty);
		}
	}

	[SpecialName]
	public int DCMEHNCIBPP()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "Shots_Hits", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_TWITTER_GAIN_AGAIN_TEXT", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	public void FANDCCNILLD()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "106 STAGE 2 STARTED", string.Empty);
		}
	}

	public void IOAEHDJGBJC()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "ID_DAY_SMALL", string.Empty);
		}
	}

	protected virtual void FNGHCNPJDAJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			DOOEHJMEPKO((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 320f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1562f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void EFBLGIHDKCL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NCNHBCNBPCK((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 609f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1447f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void BACJPKBJNIB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "S", string.Empty);
		}
	}

	[SpecialName]
	public void GJPEHEAOIOA(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	[SpecialName]
	public int CMKHGLDHILG()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "DogTagSeconds", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "S", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "qbz2_run", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	public static TweenSufixTextCounter LNLMLDOPMJP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 882f;
		if (DNDHIFENDPJ <= 1188f)
		{
			tweenSufixTextCounter.Sample(1233f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter DANKMJCJOIN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.FNMIAFFILOL();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1229f;
		if (DNDHIFENDPJ <= 1926f)
		{
			tweenSufixTextCounter.Sample(368f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public void Awake()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "[0-9.,]*", string.Empty);
		}
	}

	public static TweenSufixTextCounter PKJIGJAELJE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.KOEBFEOJHMC();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1346f;
		if (DNDHIFENDPJ <= 1345f)
		{
			tweenSufixTextCounter.Sample(548f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter EHLGFPMLLOD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.ILIJHIAJLIK();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 768f;
		if (DNDHIFENDPJ <= 348f)
		{
			tweenSufixTextCounter.Sample(885f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	protected virtual void MHICJOKBOPA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NFOGAECOFMD((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 738f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 394f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void COBFNJPLCIM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			OECHJMMHHMJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1372f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1913f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void GBGDKNIMGMB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "SoldierHP", string.Empty);
		}
	}

	protected virtual void BPCLGKJEFEK(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			AFIJIFFCPGJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 798f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1949f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void NDBFCPLLFPH(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			OOBGBOJJPDH((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1421f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 377f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter LEMANGJFIPE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 169f;
		if (DNDHIFENDPJ <= 331f)
		{
			tweenSufixTextCounter.Sample(472f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenSufixTextCounter.Sample(1f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public void NCNHBCNBPCK(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	[SpecialName]
	public void KJLAALCHCIM(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	public static TweenSufixTextCounter LJBDCPDBOMM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.OEKKCKPLBBF();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1545f;
		if (DNDHIFENDPJ <= 337f)
		{
			tweenSufixTextCounter.Sample(400f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	public static TweenSufixTextCounter OGHELDLHAMK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1800f;
		if (DNDHIFENDPJ <= 215f)
		{
			tweenSufixTextCounter.Sample(1994f, true);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public void KPAENEIKCBJ(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	[SpecialName]
	public int PMKBBCCIOFH()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_DELIVERNOW", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "TryRecconnectToPhotonCoroutine started", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "-VIP", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	protected virtual void FHHGGBAMBGB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			Text = (int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1839f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1429f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void FJJAEHJDKNL()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "BUYING CARD PACK ", string.Empty);
		}
	}

	[SpecialName]
	public void LCINECBGPEL(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) + OIFGDECEHCF;
		}
	}

	protected virtual void EGGHBFOHIHL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NFOGAECOFMD((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1292f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 502f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter GAOAJNGAOHH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.GNEHDPPMLHG();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 524f;
		if (DNDHIFENDPJ <= 1869f)
		{
			tweenSufixTextCounter.Sample(1585f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int ICMIABPMPLO()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "relog OK", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "$50-$100", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "Buy_Weapon_Gold", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	public static TweenSufixTextCounter GINFBGAIDCP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1007f;
		if (DNDHIFENDPJ <= 678f)
		{
			tweenSufixTextCounter.Sample(893f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int GNEHDPPMLHG()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "THANK YOU", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "OK", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, ". ", string.Empty);
			return int.Parse(s);
		}
		return 0;
	}

	[SpecialName]
	public int DLFMDPADHAC()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_CONFIRM_ERROR", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "ID_ARENASTARTSENTERTIMER", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_ERRORSHORTNICK", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	protected virtual void FLAFCDGMJCP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			NCEEHADNDIH((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 313f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 472f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter HEOAOMCHOJG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1254f;
		if (DNDHIFENDPJ <= 193f)
		{
			tweenSufixTextCounter.Sample(42f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}

	protected virtual void ICANGOPCADD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			AFIJIFFCPGJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1797f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1540f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenSufixTextCounter EMGFPLOHOLG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.FNMIAFFILOL();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1035f;
		if (DNDHIFENDPJ <= 1383f)
		{
			tweenSufixTextCounter.Sample(220f, false);
			tweenSufixTextCounter.enabled = true;
		}
		return tweenSufixTextCounter;
	}

	[SpecialName]
	public int FMPGGEFNGHD()
	{
		if (EFCMGKNKGND != null)
		{
			int result;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "Chillingo: On Offers Released", string.Empty), out result))
			{
				return result;
			}
			OIFGDECEHCF = Regex.Replace(EFCMGKNKGND.text, "SyncShieldRPC", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "\t", string.Empty);
			return int.Parse(s);
		}
		return 1;
	}

	public static TweenSufixTextCounter BIMCIIOMBMB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenSufixTextCounter tweenSufixTextCounter = UITweener.Begin<TweenSufixTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenSufixTextCounter.OEIICEJPGKI = tweenSufixTextCounter.HBHNJNCAHMF();
		tweenSufixTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenSufixTextCounter.OJJNFMLBBHP = 1080f;
		if (DNDHIFENDPJ <= 985f)
		{
			tweenSufixTextCounter.Sample(667f, false);
			tweenSufixTextCounter.enabled = false;
		}
		return tweenSufixTextCounter;
	}
}
