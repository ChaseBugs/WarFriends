using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Text Counter Tween")]
internal class TweenTextCounter : UITweener
{
	public int OEIICEJPGKI;

	public int IIMDKHJAJGO;

	public bool MFMJGHPJFKC;

	public SoundsManager.KJGDNLHKPOG BNPCJNKBCNL = SoundsManager.KJGDNLHKPOG.CounterSoundExperience;

	private string LFGCOBPKDMK = string.Empty;

	private UILabel EFCMGKNKGND;

	private float OJJNFMLBBHP;

	public int Text
	{
		get
		{
			if (EFCMGKNKGND != null)
			{
				int result = 0;
				if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "[.,]*", string.Empty), out result))
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
			return 0;
		}
		set
		{
			if (EFCMGKNKGND != null)
			{
				EFCMGKNKGND.text = ((value < 0) ? MEJMLNDFDBP.GMIPFLIEOHD(value) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(value)));
			}
		}
	}

	[SpecialName]
	public int EAMNHLLEOLD()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 1;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_PLAYRANKEDBATTLETOENTERLEAGUE", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == 'l')
				{
					LFGCOBPKDMK = "{0}{1} / {2}";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "BotUnitPower", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "rental for unexist weapon: {0}", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowTrailingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public void KDMECDLHNMC()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result = 1;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "RATE APP REMINDER\tVersion: {0}\tShown Times in this version: {1}/{2}", string.Empty);
		}
	}

	[SpecialName]
	public int PDOIAFDOHJM()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 1;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_WAITINGFORFRIEND", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == 'h')
				{
					LFGCOBPKDMK = "Buy_Lootboxes";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "ID_LOOTBOXREWARDED", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "Wrong_Category", string.Empty);
			return int.Parse(s, NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public void LEBKCBABPOH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 1) ? MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM)));
		}
	}

	public void IOAEHDJGBJC()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result = 1;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "game-card-ico-bulletsponge-full", string.Empty);
		}
	}

	[SpecialName]
	public int BJMHEJDDOBI()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 1;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_GUI_BRONZE", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == -57)
				{
					LFGCOBPKDMK = "ID_CONFIRM_RESTORE";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "FuseId", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_CLOSE", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public static TweenTextCounter ONCDIOBFHME(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = tweenTextCounter.PMKBBCCIOFH();
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 912f;
		if (DNDHIFENDPJ <= 1520f)
		{
			tweenTextCounter.Sample(1057f, true);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	public static TweenTextCounter JPOJDFCHEGB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 571f;
		if (DNDHIFENDPJ <= 1131f)
		{
			tweenTextCounter.Sample(1489f, true);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	protected virtual void CBMLPPKMNEN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			HEAOHDOFMPC((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1519f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 947f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenTextCounter LMNBPJEACEA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 709f;
		if (DNDHIFENDPJ <= 638f)
		{
			tweenTextCounter.Sample(1800f, false);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	public static TweenTextCounter LPGNGJBPAKH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 1847f;
		if (DNDHIFENDPJ <= 1527f)
		{
			tweenTextCounter.Sample(918f, true);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	[SpecialName]
	public void HABFKEOGFAC(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 1) ? MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM)));
		}
	}

	public static TweenTextCounter IECHDKECJAB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 1025f;
		if (DNDHIFENDPJ <= 755f)
		{
			tweenTextCounter.Sample(1279f, true);
			tweenTextCounter.enabled = true;
		}
		return tweenTextCounter;
	}

	[SpecialName]
	public void IOKOBBGBCOP(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 1) ? MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM)));
		}
	}

	public void GBGDKNIMGMB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result = 1;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "ID_WARNING_WRONGINDEXTOACTIVATEELITE", string.Empty);
		}
	}

	[SpecialName]
	public int ONPEOBMDBHH()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 1;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "null", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == 'L')
				{
					LFGCOBPKDMK = "GLM: RegisterOrLogin - 6.5: no GC response, use stored values";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "special", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "WarCards", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowTrailingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public void JDAJKEGDCBK(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 0) ? MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM)));
		}
	}

	public void Awake()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result = 0;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "[0-9.,]*", string.Empty);
		}
	}

	[SpecialName]
	public void NGENMHHKCLL(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 1) ? MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM)));
		}
	}

	public void ECCECGGCMHG()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result = 1;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "DecalExpiresOn", string.Empty);
		}
	}

	[SpecialName]
	public int KKMGDKHOJNE()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 0;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "unit", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == 'n')
				{
					LFGCOBPKDMK = "ID_COLLECTONECHRISTMASCRATE";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "shotgunner_idle", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "{0}{1}{2} {3}{4} {5}{6} {7}{8}", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public void HEJKGFPPIDC()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result = 1;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "DogTagRefillTime", string.Empty);
		}
	}

	[SpecialName]
	public int ILIJHIAJLIK()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 1;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ProgressId", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[0] == '~')
				{
					LFGCOBPKDMK = "Buy_Rental_Weapon_Gold";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "ID_READYTIME", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "menu-weaponstats-burstsize", string.Empty);
			return int.Parse(s, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	public static TweenTextCounter KFNKIMBNAIK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = tweenTextCounter.PMKBBCCIOFH();
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 11f;
		if (DNDHIFENDPJ <= 171f)
		{
			tweenTextCounter.Sample(1022f, false);
			tweenTextCounter.enabled = true;
		}
		return tweenTextCounter;
	}

	protected virtual void LCAEELACCEJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			IOKOBBGBCOP((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1208f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 506f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
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

	protected virtual void LMNINFNNGKL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			IOKOBBGBCOP((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1442f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1495f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenTextCounter Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenTextCounter.Sample(1f, true);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	public static TweenTextCounter IAGLEIPAIOB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 695f;
		if (DNDHIFENDPJ <= 745f)
		{
			tweenTextCounter.Sample(1871f, false);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	[SpecialName]
	public int HPCADHBKHIE()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 1;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "    ", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[0] == -86)
				{
					LFGCOBPKDMK = "registerCustomProfileNumber";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "id", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "{0} {1}", string.Empty);
			return int.Parse(s, NumberStyles.Integer | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
		}
		return 1;
	}

	[SpecialName]
	public int PMKBBCCIOFH()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 1;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_ARENARULES_SHIELDSBREAKSLOWER", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == '\u001c')
				{
					LFGCOBPKDMK = "ID_CONFIRM_JOINSQUADEVENT";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "Sniper_Tutorial_Played", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "0", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public static TweenTextCounter HDHIEDDCJIC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = tweenTextCounter.EAMNHLLEOLD();
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 198f;
		if (DNDHIFENDPJ <= 1476f)
		{
			tweenTextCounter.Sample(830f, false);
			tweenTextCounter.enabled = true;
		}
		return tweenTextCounter;
	}

	[SpecialName]
	public int DKCKPAPCKFN()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 1;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_COLLECTXELITEPARTSANDUPGRADETOELITE", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[0] == -34)
				{
					LFGCOBPKDMK = "menu-gold";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "Test Getter Methods", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "B", string.Empty);
			return int.Parse(s, NumberStyles.AllowLeadingWhite, CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public void KECNIEGEDBP()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result = 0;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "ID_CONFIRM_NOTFORQUESTACCOUNTS", string.Empty);
		}
	}

	protected virtual void EMOJCHAFNPN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			INJNHGHFKPA((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1349f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1323f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void HEAOHDOFMPC(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 1) ? MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM)));
		}
	}

	public static TweenTextCounter PGAHIMIGILO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = tweenTextCounter.PMKBBCCIOFH();
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 67f;
		if (DNDHIFENDPJ <= 1566f)
		{
			tweenTextCounter.Sample(1092f, true);
			tweenTextCounter.enabled = true;
		}
		return tweenTextCounter;
	}

	public static TweenTextCounter MDBMAINKPKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 1378f;
		if (DNDHIFENDPJ <= 140f)
		{
			tweenTextCounter.Sample(1027f, false);
			tweenTextCounter.enabled = true;
		}
		return tweenTextCounter;
	}

	[SpecialName]
	public int DLFMDPADHAC()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 0;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "Gold", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[1] == 'C')
				{
					LFGCOBPKDMK = ">$500";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "master1", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_LOADING", string.Empty);
			return int.Parse(s, ~(NumberStyles.Integer | NumberStyles.AllowParentheses), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public static TweenTextCounter GBNIAKJEIMN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = tweenTextCounter.PMKBBCCIOFH();
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 181f;
		if (DNDHIFENDPJ <= 1745f)
		{
			tweenTextCounter.Sample(1338f, true);
			tweenTextCounter.enabled = true;
		}
		return tweenTextCounter;
	}

	[SpecialName]
	public void KJLAALCHCIM(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 0) ? MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM)));
		}
	}

	public static TweenTextCounter DANKMJCJOIN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 1850f;
		if (DNDHIFENDPJ <= 90f)
		{
			tweenTextCounter.Sample(1248f, false);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	public void MFKNMALEKKB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		int result = 0;
		if (!int.TryParse(EFCMGKNKGND.text, out result))
		{
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "Unit {0} does not exists on client.", string.Empty);
		}
	}

	[SpecialName]
	public int LPAGHJPJNOA()
	{
		if (EFCMGKNKGND != null)
		{
			int result = 0;
			if (int.TryParse(Regex.Replace(EFCMGKNKGND.text, "ID_TRAININGINPROGRESS", string.Empty), out result))
			{
				if (EFCMGKNKGND.text.ToCharArray()[0] == 'X')
				{
					LFGCOBPKDMK = "ID_CONFIRM_DELETESQUAD_TEXT";
				}
				return result;
			}
			LFGCOBPKDMK = Regex.Replace(EFCMGKNKGND.text, "visual", string.Empty);
			string s = Regex.Replace(EFCMGKNKGND.text, "describeContents", string.Empty);
			return int.Parse(s, NumberStyles.Integer | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	public static TweenTextCounter IJIDNJACAMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 213f;
		if (DNDHIFENDPJ <= 972f)
		{
			tweenTextCounter.Sample(146f, true);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	protected virtual void CMJLPFKEEIJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			LEBKCBABPOH((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1504f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1763f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void NCHOKGCGGBO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			KJLAALCHCIM((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 516f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1113f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenTextCounter Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenTextCounter tweenTextCounter = UITweener.Begin<TweenTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenTextCounter.OEIICEJPGKI = tweenTextCounter.Text;
		tweenTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenTextCounter.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenTextCounter.Sample(1f, true);
			tweenTextCounter.enabled = false;
		}
		return tweenTextCounter;
	}

	[SpecialName]
	public void INJNHGHFKPA(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = ((IDEBKDPMPGM < 0) ? MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM) : (LFGCOBPKDMK + MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM)));
		}
	}
}
