using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("NGUI/Tween/XP Text Counter Tween")]
internal class TweenXPTextCounter : UITweener
{
	[FormerlySerializedAs("EMMCJEEABGA")]
	public int OEIICEJPGKI;

	[FormerlySerializedAs("FFJGKOLGFLL")]
	public int IIMDKHJAJGO;

	[FormerlySerializedAs("LOLIHBIJJJD")]
	public int BBOOLCCJKIB;

	[FormerlySerializedAs("FFPHOPHOJMC")]
	public bool MFMJGHPJFKC;

	public SoundsManager.KJGDNLHKPOG BNPCJNKBCNL = SoundsManager.KJGDNLHKPOG.CounterSoundExperience;

	private UILabel EFCMGKNKGND;

	private float OJJNFMLBBHP;

	private float AACNBBBEMLC;

	public int Text
	{
		get
		{
			if (EFCMGKNKGND != null)
			{
				int num = 0;
				string s = Regex.Replace(EFCMGKNKGND.text, "^\\D*", string.Empty);
				return int.Parse(s, NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
			}
			return 0;
		}
		set
		{
			if (EFCMGKNKGND != null)
			{
				EFCMGKNKGND.text = string.Format("{0} {1}{2}[-]", MEJMLNDFDBP.GMIPFLIEOHD(value), Colours.stringBlue, "XP");
				if (BBOOLCCJKIB > 0)
				{
					MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 20f, BBOOLCCJKIB);
				}
			}
		}
	}

	protected virtual void FGJENFGGGJP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			MPPNDLAGLCP((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1641f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1760f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void BNILEHKGBLL(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("ID_CONFIRM_LOGGEDOUT", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "WarFriends benötigt die Erlaubnis, auf deinen Medienspeicher zuzugreifen, um wichtige Spieldaten herunterladen zu können.Ohne diese Berechtigung läuft das Spiel nicht und wird geschlossen. Bitte versuche es erneut oder schließe WarFriends.");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 228f, BBOOLCCJKIB);
			}
		}
	}

	protected virtual void IHANNBAIDCA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			BJIMIIAGKDE((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1524f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 628f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenXPTextCounter KKIGNHJHLGD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.DMJAMGCCOHL();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 293f;
		if (DNDHIFENDPJ <= 378f)
		{
			tweenXPTextCounter.Sample(316f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public void NIAEEICNNHL()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	[SpecialName]
	public void AHCPOOBNKGH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("ID_CLAIMED", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "WENEEDTO");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1864f, BBOOLCCJKIB);
			}
		}
	}

	public void EEMLMJCHKLM()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public static TweenXPTextCounter JAFKKOIHIAA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 707f;
		if (DNDHIFENDPJ <= 1085f)
		{
			tweenXPTextCounter.Sample(421f, isFinished: false);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	protected virtual void KEPEHFLOBPN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			AFIJIFFCPGJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 663f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 201f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenXPTextCounter OGOADPAGHJH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.KJDGHKOFMAP();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 125f;
		if (DNDHIFENDPJ <= 992f)
		{
			tweenXPTextCounter.Sample(1287f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter JPOJDFCHEGB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.AKNNCLMHPKO();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 472f;
		if (DNDHIFENDPJ <= 1387f)
		{
			tweenXPTextCounter.Sample(574f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenXPTextCounter.Sample(1f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public int KHCKFICKNAJ()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 0;
			string s = Regex.Replace(EFCMGKNKGND.text, "weapon doesnt have ammo setup", string.Empty);
			return int.Parse(s, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	public static TweenXPTextCounter Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.Text;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 0f;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenXPTextCounter.Sample(1f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public void BJIMIIAGKDE(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("RETRYPERM", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "ID_GUI_SQUADWARSENDNOREWARD");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1050f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter LKINEOAFENE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 890f;
		if (DNDHIFENDPJ <= 335f)
		{
			tweenXPTextCounter.Sample(1578f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public void MLBAFICPECE()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public static TweenXPTextCounter GALIIPLCGAP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 716f;
		if (DNDHIFENDPJ <= 1460f)
		{
			tweenXPTextCounter.Sample(537f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter BPBNEOOGIKF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.Text;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 948f;
		if (DNDHIFENDPJ <= 1167f)
		{
			tweenXPTextCounter.Sample(476f, isFinished: false);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	protected virtual void KBHHHDANGPF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			MLHJAHAJMPF((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 819f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1780f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenXPTextCounter IJCMEKAIAJG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.FNMIAFFILOL();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 596f;
		if (DNDHIFENDPJ <= 794f)
		{
			tweenXPTextCounter.Sample(1112f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public int KKMGDKHOJNE()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 1;
			string s = Regex.Replace(EFCMGKNKGND.text, "Warfriend", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	public static TweenXPTextCounter DFOPNNAAPHK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.DALILPELLCF();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 36f;
		if (DNDHIFENDPJ <= 1332f)
		{
			tweenXPTextCounter.Sample(978f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter HLINIFHCFEF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.DMJAMGCCOHL();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1789f;
		if (DNDHIFENDPJ <= 1455f)
		{
			tweenXPTextCounter.Sample(1339f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter IECHDKECJAB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.EBOAMEFCAHP();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 194f;
		if (DNDHIFENDPJ <= 48f)
		{
			tweenXPTextCounter.Sample(57f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter DEPELDAKMAJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 400f;
		if (DNDHIFENDPJ <= 1534f)
		{
			tweenXPTextCounter.Sample(887f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter KAEBPEJBJCI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 336f;
		if (DNDHIFENDPJ <= 858f)
		{
			tweenXPTextCounter.Sample(421f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter JCLGAFGBMDC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1100f;
		if (DNDHIFENDPJ <= 1727f)
		{
			tweenXPTextCounter.Sample(1744f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter MHNNKFKMELH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1295f;
		if (DNDHIFENDPJ <= 1652f)
		{
			tweenXPTextCounter.Sample(544f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
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

	[SpecialName]
	public void DNKGPEMLFEF(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("ID_VIDEOSERVICE", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "videoAdRewardTimes");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1084f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter OKCMGMMLEJP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.DALILPELLCF();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1785f;
		if (DNDHIFENDPJ <= 951f)
		{
			tweenXPTextCounter.Sample(1486f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public int FNMIAFFILOL()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 0;
			string s = Regex.Replace(EFCMGKNKGND.text, "Request Aborted!", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingSign | NumberStyles.AllowTrailingSign), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	public static TweenXPTextCounter AMIDMCCIPJK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1802f;
		if (DNDHIFENDPJ <= 1889f)
		{
			tweenXPTextCounter.Sample(941f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public int DALILPELLCF()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 0;
			string s = Regex.Replace(EFCMGKNKGND.text, "N", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public int EBFOOHMJCBL()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 0;
			string s = Regex.Replace(EFCMGKNKGND.text, " tutorial running: ", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	public static TweenXPTextCounter IOLBDLOPJGJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.PNFAHEHIKJN();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 591f;
		if (DNDHIFENDPJ <= 1321f)
		{
			tweenXPTextCounter.Sample(1327f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter FHILMNNKFLD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.PNFAHEHIKJN();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1272f;
		if (DNDHIFENDPJ <= 112f)
		{
			tweenXPTextCounter.Sample(615f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	protected virtual void CBMLPPKMNEN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			ELAIEGBIIKJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1032f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 460f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenXPTextCounter GHMBHKEBADL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.AKNNCLMHPKO();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1842f;
		if (DNDHIFENDPJ <= 126f)
		{
			tweenXPTextCounter.Sample(14f, isFinished: false);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter PGAHIMIGILO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.DALILPELLCF();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 565f;
		if (DNDHIFENDPJ <= 1312f)
		{
			tweenXPTextCounter.Sample(1844f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	public void KECNIEGEDBP()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public static TweenXPTextCounter AFMNKJAMAGM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.KHCKFICKNAJ();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 742f;
		if (DNDHIFENDPJ <= 831f)
		{
			tweenXPTextCounter.Sample(568f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter HNEAGHHABGL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.EBOAMEFCAHP();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 742f;
		if (DNDHIFENDPJ <= 970f)
		{
			tweenXPTextCounter.Sample(1074f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public void ELALDKPEMJK(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("dailyRewardData", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, " {0}{1}");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1042f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public void HILPFDCPNNP(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("BlackMarketOffer", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "minigun");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 513f, BBOOLCCJKIB);
			}
		}
	}

	public void KALEMFKOGLE()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public static TweenXPTextCounter OLIIHGDGKKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 218f;
		if (DNDHIFENDPJ <= 691f)
		{
			tweenXPTextCounter.Sample(1190f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter ALCKOMNFIFH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1874f;
		if (DNDHIFENDPJ <= 1095f)
		{
			tweenXPTextCounter.Sample(1446f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter FFIHIGPINBB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 785f;
		if (DNDHIFENDPJ <= 1139f)
		{
			tweenXPTextCounter.Sample(1025f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	protected virtual void FEPCGPEOMAG(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			IHEABNLCABP((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1596f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 974f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenXPTextCounter GMLNHEIJHDE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.PNFAHEHIKJN();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1735f;
		if (DNDHIFENDPJ <= 326f)
		{
			tweenXPTextCounter.Sample(1357f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter GMNFMNAPAGL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.KKMGDKHOJNE();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1857f;
		if (DNDHIFENDPJ <= 195f)
		{
			tweenXPTextCounter.Sample(1153f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	protected virtual void LFKMEENODNN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			JCEIPCNPMOH((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1872f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1541f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void MPPNDLAGLCP(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} scraps", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "country-china");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1878f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public void AFFHJIMFFBH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("ID_SELECTONEUNIT", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "Skill");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1824f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter PLCIBNBNMKO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.KKMGDKHOJNE();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 306f;
		if (DNDHIFENDPJ <= 1829f)
		{
			tweenXPTextCounter.Sample(801f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public void MLHJAHAJMPF(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("ID_STAT_WINLOSSRATIO", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "special");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1816f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public void JCEIPCNPMOH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("ABOUT TO SHOW DAILY RENTAL", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "ID_SLOTUPGRADE_HEAT");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 401f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public void ELAIEGBIIKJ(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("unlockLevel", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "DOWNLOADBTN");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 436f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public int KJDGHKOFMAP()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 1;
			string s = Regex.Replace(EFCMGKNKGND.text, "StarterAssignmentsData", string.Empty);
			return int.Parse(s, ~NumberStyles.AllowParentheses, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public void MOCALJHNKBG(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("InApp", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "ID_WARNING");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1191f, BBOOLCCJKIB);
			}
		}
	}

	public void Awake()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	[SpecialName]
	public void CFJLHGNBLAN(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("unregisterConnectionCallbacks", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "LevelName");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1112f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public void EGDFEIKMEDG(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("explosive", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} warcards");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 780f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter NCPOKCLHEAK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 340f;
		if (DNDHIFENDPJ <= 299f)
		{
			tweenXPTextCounter.Sample(74f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter MLEAFANPCJB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.KHCKFICKNAJ();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1904f;
		if (DNDHIFENDPJ <= 320f)
		{
			tweenXPTextCounter.Sample(1894f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public void IGOMLJOMFGA()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public static TweenXPTextCounter KMJOPOLHAJJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.EBFOOHMJCBL();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 244f;
		if (DNDHIFENDPJ <= 1368f)
		{
			tweenXPTextCounter.Sample(1733f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	protected virtual void IFLMKBDLENF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			BJIMIIAGKDE((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 730f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1645f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void MGAFJAJNBFL()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public static TweenXPTextCounter FOPAOKJDKJP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.FNMIAFFILOL();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1352f;
		if (DNDHIFENDPJ <= 329f)
		{
			tweenXPTextCounter.Sample(112f, isFinished: false);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter PDFHNDPEEMA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1963f;
		if (DNDHIFENDPJ <= 324f)
		{
			tweenXPTextCounter.Sample(1601f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter HJAIEBFHCBE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 173f;
		if (DNDHIFENDPJ <= 732f)
		{
			tweenXPTextCounter.Sample(1006f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public int AKNNCLMHPKO()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 1;
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_WARNING_ALREADYCRAFTING", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowTrailingWhite | NumberStyles.AllowTrailingSign), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public void FODLENMBMPG(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("Prefabs", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "#PETER# Weapon Screen - RIGHT BUTTON - unit state: NOT BOUGHT\t\tbutton type: BUY UNIT");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1017f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter LJBDCPDBOMM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1722f;
		if (DNDHIFENDPJ <= 560f)
		{
			tweenXPTextCounter.Sample(1026f, isFinished: false);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public void LCINECBGPEL(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("Show buy hearth dialog", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "ID_LOADING");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1378f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter BIMCIIOMBMB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1552f;
		if (DNDHIFENDPJ <= 1588f)
		{
			tweenXPTextCounter.Sample(1331f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public void FEBBFBOCKMC()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public void OHHLNKPIHBH()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	protected virtual void BNJBFLPBONL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			BNILEHKGBLL((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 111f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1941f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void GBGDKNIMGMB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	protected virtual void JBEHPFKFIGD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			AFIJIFFCPGJ((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 503f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1638f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void OOBGBOJJPDH(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("BONUS: size: ", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "ID_DOWNLOADINGDATA");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1081f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public int DMJAMGCCOHL()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 0;
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_GUI_POWERBANDOFF", string.Empty);
			return int.Parse(s, NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public int EBOAMEFCAHP()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 0;
			string s = Regex.Replace(EFCMGKNKGND.text, "eventEnd", string.Empty);
			return int.Parse(s, NumberStyles.AllowLeadingWhite | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 1;
	}

	[SpecialName]
	public int ICMIABPMPLO()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 0;
			string s = Regex.Replace(EFCMGKNKGND.text, "DogTagRefillTime", string.Empty);
			return int.Parse(s, NumberStyles.AllowTrailingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 1;
	}

	protected virtual void LIADBDHBKGL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			IHEABNLCABP((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 69f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1434f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void CHMAEOPLFFN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			Text = (int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1927f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 208f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void DOOEHJMEPKO(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("HeroicMissionsCompletionRewardGold", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "D2");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 137f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter IKNJAHBMAFC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.ICICKGAKGMP();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 273f;
		if (DNDHIFENDPJ <= 1339f)
		{
			tweenXPTextCounter.Sample(945f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	protected virtual void EEDNGNLEMAO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			DNKGPEMLFEF((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 455f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1516f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenXPTextCounter HBHMEFGMNNN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1877f;
		if (DNDHIFENDPJ <= 831f)
		{
			tweenXPTextCounter.Sample(325f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public int EMIGBBKFLHC()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 1;
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_ACCEPT", string.Empty);
			return int.Parse(s, NumberStyles.AllowTrailingWhite | NumberStyles.AllowParentheses | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 0;
	}

	public static TweenXPTextCounter IPAMGPAPCMA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1127f;
		if (DNDHIFENDPJ <= 908f)
		{
			tweenXPTextCounter.Sample(33f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public void AOKADKMLCEL(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("game-card-ico-swiftimmortality", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "ShotFrequencyMin");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1451f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter CABGNGMLIEK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.KJDGHKOFMAP();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 988f;
		if (DNDHIFENDPJ <= 869f)
		{
			tweenXPTextCounter.Sample(684f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public void CALILPEEAMB()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public static TweenXPTextCounter DHKJOACDBNK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.AKNNCLMHPKO();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 978f;
		if (DNDHIFENDPJ <= 746f)
		{
			tweenXPTextCounter.Sample(1198f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter GEKPHELKFNB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.Text;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 1293f;
		if (DNDHIFENDPJ <= 503f)
		{
			tweenXPTextCounter.Sample(315f, isFinished: false);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	protected virtual void NLEIENHFFFF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			JCEIPCNPMOH((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 21f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 794f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public void KDMECDLHNMC()
	{
		EFCMGKNKGND = GetComponent<UILabel>();
		if (EFCMGKNKGND != null)
		{
			AACNBBBEMLC = EFCMGKNKGND.transform.localScale.y;
		}
	}

	public static TweenXPTextCounter DDJHGKMBNDK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.ICMIABPMPLO();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 369f;
		if (DNDHIFENDPJ <= 1140f)
		{
			tweenXPTextCounter.Sample(272f, isFinished: true);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	public static TweenXPTextCounter EHLGFPMLLOD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.KHCKFICKNAJ();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 104f;
		if (DNDHIFENDPJ <= 872f)
		{
			tweenXPTextCounter.Sample(176f, isFinished: false);
			tweenXPTextCounter.enabled = true;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public void IHEABNLCABP(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("menu-weapon-mp5-elite", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "Create_Squad");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1576f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public int ICICKGAKGMP()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 1;
			string s = Regex.Replace(EFCMGKNKGND.text, "#VOJTA# ON GET NEW DAILY MISSIONS", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowDecimalPoint), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	[SpecialName]
	public int PNFAHEHIKJN()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 1;
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_ENDSINTIME", string.Empty);
			return int.Parse(s, ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingSign | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint), CultureInfo.InvariantCulture);
		}
		return 1;
	}

	protected virtual void HAMFGDNHAPC(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			CFJLHGNBLAN((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 558f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1216f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	public static TweenXPTextCounter EEODMCJPDNI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL LEJNOJFKFLE, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = LEJNOJFKFLE.FKIIDCDCLHM;
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 973f;
		if (DNDHIFENDPJ <= 233f)
		{
			tweenXPTextCounter.Sample(1826f, isFinished: false);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public void AFIJIFFCPGJ(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("RewardItem", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "SkirmishCost");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 364f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public void HEAOHDOFMPC(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("ДА", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "ID_SKILLSHOTHINT_HEADSHOT");
			if (BBOOLCCJKIB > 0)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 445f, BBOOLCCJKIB);
			}
		}
	}

	public static TweenXPTextCounter HEOAOMCHOJG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, ONLHLPBMJOL DLPLHDNOBPM)
	{
		TweenXPTextCounter tweenXPTextCounter = UITweener.Begin<TweenXPTextCounter>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenXPTextCounter.OEIICEJPGKI = tweenXPTextCounter.EMIGBBKFLHC();
		tweenXPTextCounter.IIMDKHJAJGO = DLPLHDNOBPM.FKIIDCDCLHM;
		tweenXPTextCounter.OJJNFMLBBHP = 726f;
		if (DNDHIFENDPJ <= 1373f)
		{
			tweenXPTextCounter.Sample(1146f, isFinished: true);
			tweenXPTextCounter.enabled = false;
		}
		return tweenXPTextCounter;
	}

	[SpecialName]
	public int PDHHGFDBEEL()
	{
		if (EFCMGKNKGND != null)
		{
			int num = 0;
			string s = Regex.Replace(EFCMGKNKGND.text, "ID_SKILL", string.Empty);
			return int.Parse(s, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
		}
		return 1;
	}

	protected virtual void CMJLPFKEEIJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			EGDFEIKMEDG((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1281f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 1006f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	[SpecialName]
	public void AHDJPFBBAKM(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("ID_BUY", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "\tTime since last show: {0}");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 559f, BBOOLCCJKIB);
			}
		}
	}

	[SpecialName]
	public void CLBHLNMCMOF(int IDEBKDPMPGM)
	{
		if (EFCMGKNKGND != null)
		{
			EFCMGKNKGND.text = string.Format("NOT ENOUGH GOLD FOR ARENA", MEJMLNDFDBP.GMIPFLIEOHD(IDEBKDPMPGM), Colours.stringBlue, "ID_ARENACLOSED");
			if (BBOOLCCJKIB > 1)
			{
				MEJMLNDFDBP.COCBCFKJOJE(EFCMGKNKGND, AACNBBBEMLC, 1960f, BBOOLCCJKIB);
			}
		}
	}

	protected virtual void FHHGGBAMBGB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			LCINECBGPEL((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1540f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 401f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}

	protected virtual void JHKJADFJPOC(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		if (EFCMGKNKGND != null)
		{
			string text = EFCMGKNKGND.text;
			ELALDKPEMJK((int)Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
			if (MFMJGHPJFKC && duration * KDJCCDGMEJL > OJJNFMLBBHP + 1780f && text != EFCMGKNKGND.text)
			{
				SoundsManager.Instance.PlaySound(BNPCJNKBCNL, 572f);
				OJJNFMLBBHP = duration * KDJCCDGMEJL;
			}
		}
	}
}
