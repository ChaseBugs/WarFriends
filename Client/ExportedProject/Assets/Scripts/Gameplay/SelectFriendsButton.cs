using UnityEngine;
using UnityEngine.Serialization;

public class SelectFriendsButton : Core_BaseScript
{
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("mBackground")]
	public UISprite LCPBNBLGFIA;

	[FormerlySerializedAs("mHighlight")]
	public UISprite CBFOGHLMPFE;

	[FormerlySerializedAs("mNameLabel")]
	public UILabel PKHHKJLGHFM;

	private bool JNOGOANMFIB;

	internal void DJBNDOLCLDF(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1560f : 814f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 907f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 1518f : 237f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 944f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 1274f - 484f) * 770f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void CMINFBPPLBP(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1376f : 1239f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 189f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 1552f : 1930f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 1784f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 175f - 1454f) * 647f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void KLJEEKCAFPD(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1645f, 114f, 1740f) : Quaternion.Euler(982f, 1158f, 1078f));
		}
	}

	internal void MCEIGNHNCML(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1503f : 1861f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((localPosition.x < 1869f) ? (-1) : 0);
		localPosition.x = ((!CCDJAGPJBLE) ? 1512f : 199f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 1841f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 1071f - 250f) * 899f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void DOJIMFFIAJN(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(500f, 1812f, 71f) : Quaternion.Euler(1830f, 1353f, 1703f));
		}
	}

	internal void NALKGJGJECL(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(41f, 245f, 1067f);
	}

	internal void HFOFJLLPMOO(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 466f : 672f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 0f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 483f : 380f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 30f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 2f - 60f) * -1f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void MHBIAIIFPIO(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(1449f, 1961f, 1994f);
	}

	internal void HFDMLDKIFPG(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1316f : 1477f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 1403f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 918f : 1876f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 688f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 1973f - 313f) * 33f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void APHECPIPBPK(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1286f, 75f, 159f) : Quaternion.Euler(1502f, 1612f, 1561f));
		}
	}

	internal void AHMFMEDODJH(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(126f, 1567f, 1492f) : Quaternion.Euler(357f, 532f, 1589f));
		}
	}

	internal void AOCKANKFIBO(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(1076f, 1359f, 32f);
	}

	internal void BCLKDHNBJOM(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1886f : 461f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 504f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 273f : 205f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 298f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 1329f - 1006f) * 1524f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void JPCDKDCMOKO(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: true);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(909f, 707f, 1420f);
	}

	internal void APPMFPCDGNO(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: true);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(342f, 1360f, 1857f);
	}

	internal void PJNCJKKBBPN(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1425f : 1356f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((localPosition.x < 1034f) ? (-1) : 0);
		localPosition.x = ((!CCDJAGPJBLE) ? 1591f : 440f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 1317f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 1161f - 158f) * 911f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void DPLMLOKKIBK(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(260f, 848f, 1189f);
	}

	internal void MEBGEPPFDJB(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1773f, 1343f, 912f) : Quaternion.Euler(443f, 1600f, 1476f));
		}
	}

	internal void CEAFJINMJPF(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 550f : 759f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 1402f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 1386f : 1206f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 1722f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 430f - 471f) * 954f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void ECICACMAMFK(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: true);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(718f, 1932f, 431f);
	}

	internal void JDDLBPMJGND(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1159f, 783f, 1531f) : Quaternion.Euler(1272f, 1995f, 1228f));
		}
	}

	internal void JNBMNELHDEJ(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1562f, 634f, 1403f) : Quaternion.Euler(1926f, 2f, 544f));
		}
	}

	internal void COMONIBIHOB(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1042f : 1386f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 1573f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 1041f : 1605f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 1810f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 602f - 329f) * 1119f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void JDIGFLEADNH(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(1607f, 1797f, 86f);
	}

	internal void LCKLHIPHFGJ(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(393f, 940f, 600f);
	}

	internal void IHOOKOIBFGG(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1503f : 811f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((localPosition.x < 487f) ? (-1) : 0);
		localPosition.x = ((!CCDJAGPJBLE) ? 116f : 1635f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 6f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 320f - 1097f) * 1404f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void JCPNPOLKBHJ(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(0f, 0f, 270f) : Quaternion.Euler(0f, 0f, 180f));
		}
	}

	internal void NBPBFLEEJMI(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: true);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(1748f, 1599f, 803f);
	}

	internal void OMIINNKHNHB(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1234f, 1493f, 982f) : Quaternion.Euler(1777f, 1317f, 1940f));
		}
	}

	internal void CIMBILALHBJ(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: true);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(970f, 1336f, 1385f);
	}

	internal void CLBGHCDOKFK(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1879f : 287f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 1651f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 137f : 1572f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 158f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 964f - 1430f) * 1245f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void OAGKEFACMFM(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1743f, 148f, 331f) : Quaternion.Euler(957f, 870f, 555f));
		}
	}

	internal void JLFHNIOJOAE(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(305f, 1739f, 1130f) : Quaternion.Euler(1137f, 1892f, 1281f));
		}
	}

	internal void IIHKNLGHDEJ(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1280f, 439f, 43f) : Quaternion.Euler(691f, 108f, 1073f));
		}
	}

	internal void BBDACLJKMFH(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(28f, 1916f, 1502f);
	}

	internal void BHKJNEEGNAP(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1000f, 1368f, 1466f) : Quaternion.Euler(901f, 63f, 1134f));
		}
	}

	internal void DINJCFNOENO(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1675f, 563f, 1182f) : Quaternion.Euler(701f, 38f, 459f));
		}
	}

	internal void PAMFOABINII(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
	}

	internal void JPAJCPMDGBG(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 731f : 399f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 1438f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 1813f : 1615f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 1533f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 947f - 1677f) * 1406f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void HMFFICHJPCH(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 334f : 1133f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 965f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 1546f : 1328f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 1603f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 1604f - 87f) * 681f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void NFNIPFFMFDB(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1985f, 1329f, 1557f) : Quaternion.Euler(932f, 189f, 1900f));
		}
	}

	internal void AIFLJIJPIKN(bool APAMHGHGEPL)
	{
		JNOGOANMFIB = APAMHGHGEPL;
		LCPBNBLGFIA.gameObject.SetActive(value: false);
		PKHHKJLGHFM.color = ((!APAMHGHGEPL) ? Color.white : Colours.gray);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(351f, 557f, 1132f);
	}

	internal void BGCBCFJEKEH(bool LIJGDCFAKAI)
	{
		if (!JNOGOANMFIB)
		{
			LCPBNBLGFIA.gameObject.SetActive(LIJGDCFAKAI);
			PKHHKJLGHFM.color = ((!LIJGDCFAKAI) ? Color.white : Colours.blue);
			CBFOGHLMPFE.transform.localRotation = ((!LIJGDCFAKAI) ? Quaternion.Euler(1494f, 397f, 1235f) : Quaternion.Euler(1003f, 1567f, 1704f));
		}
	}

	internal void JJBPIMHCGAC(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 502f : 1933f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((!(localPosition.x < 832f)) ? 1 : (-1));
		localPosition.x = ((!CCDJAGPJBLE) ? 561f : 595f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 793f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 92f - 1513f) * 381f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}

	internal void BGJBNMIHBIP(bool CCDJAGPJBLE)
	{
		float num = ((!CCDJAGPJBLE) ? 1711f : 1499f);
		Vector3 localPosition = base.transform.localPosition;
		int num2 = ((localPosition.x < 392f) ? (-1) : 0);
		localPosition.x = ((!CCDJAGPJBLE) ? 422f : 842f) * (float)num2;
		base.transform.localPosition = localPosition;
		Vector3 localScale = KMFGCJEGJJK.transform.localScale;
		localScale.x = num;
		KMFGCJEGJJK.transform.localScale = localScale;
		Vector3 localScale2 = LCPBNBLGFIA.transform.localScale;
		localScale2.x = num + 1426f;
		LCPBNBLGFIA.transform.localScale = localScale2;
		Vector3 localPosition2 = CBFOGHLMPFE.transform.localPosition;
		localPosition2.x = (num / 828f - 978f) * 1022f;
		CBFOGHLMPFE.transform.localPosition = localPosition2;
	}
}
