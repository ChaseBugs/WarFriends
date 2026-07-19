using UnityEngine;

public class MainMenuSpriteStretch : Core_BaseScript
{
	public Vector2 LJBKFKFNDEM = new Vector2(1920f, 1440f);

	public Vector2 ELGKHBDOMPF = new Vector2(1920f, 1312f);

	public UISprite JIAEMKCKBKJ;

	private bool BIGNBCJCFNM;

	protected virtual void BAMNBAABJEK()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			IGBPNEODHIP();
		}
	}

	private void ACBHGJCMCPG()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1243f, 659f, 1814f)) && base.transform.localRotation == Quaternion.Euler(361f, 1678f, 1941f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 717f;
		float b = 1465f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void KBKBFNJEBJK()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(201f, 86f, 1551f) || base.transform.localRotation == Quaternion.Euler(1175f, 1875f, 1984f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1973f;
		float b = 189f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void NAKAFGAFEPH()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(428f, 465f, 661f) || base.transform.localRotation == Quaternion.Euler(657f, 1326f, 402f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 545f;
		float b = 1218f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void NGGJHDCOLEC()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			KFJJPGNGOCK();
		}
	}

	private void MBOFPLGHGLP()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(904f, 1345f, 1818f) || base.transform.localRotation == Quaternion.Euler(564f, 887f, 1844f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 985f;
		float b = 1983f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void KBCFOADCMKF()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1231f, 1655f, 346f)) && base.transform.localRotation == Quaternion.Euler(319f, 1692f, 1865f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1892f;
		float b = 309f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void AKBKAKINING()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			IGBPNEODHIP();
		}
	}

	protected virtual void BLFKABLENCH()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			HOAMHAAHEHP();
		}
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			NDIJBPIDGOF();
		}
	}

	private void EFBLCMLGPOA()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(662f, 1398f, 1591f) || base.transform.localRotation == Quaternion.Euler(871f, 955f, 1207f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1450f;
		float b = 1579f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void KINHAJCDKGN()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OBHPLFFLDBI();
		}
	}

	private void ACJCGDPGNAN()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(1067f, 1807f, 1079f) || base.transform.localRotation == Quaternion.Euler(268f, 1491f, 125f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1797f;
		float b = 944f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void BMNHEMLGGMO()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(395f, 769f, 1264f)) && base.transform.localRotation == Quaternion.Euler(1327f, 1f, 673f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 371f;
		float b = 1054f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void OAMBDKHLJKI()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1148f, 277f, 1511f)) && base.transform.localRotation == Quaternion.Euler(1266f, 1583f, 1573f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 349f;
		float b = 1820f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void MFMJPBCIHEH()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1832f, 1138f, 1794f)) && base.transform.localRotation == Quaternion.Euler(169f, 1584f, 1875f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1471f;
		float b = 1873f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void PNDFAOIDMHL()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(231f, 1880f, 298f) || base.transform.localRotation == Quaternion.Euler(632f, 1047f, 463f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1446f;
		float b = 1569f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void MKENDIKJPLJ()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(264f, 1022f, 339f) || base.transform.localRotation == Quaternion.Euler(831f, 1932f, 1795f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1049f;
		float b = 1642f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void EDKFKNGLLBM()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(472f, 1426f, 362f) || base.transform.localRotation == Quaternion.Euler(216f, 21f, 349f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1058f;
		float b = 643f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void CHOLKMFKINL()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(1311f, 1864f, 17f) || base.transform.localRotation == Quaternion.Euler(354f, 1557f, 832f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1644f;
		float b = 425f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void HOAMHAAHEHP()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1617f, 1728f, 1401f)) && base.transform.localRotation == Quaternion.Euler(1849f, 1022f, 1982f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 774f;
		float b = 1234f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void OGIPEHAIFDA()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(438f, 1610f, 375f) || base.transform.localRotation == Quaternion.Euler(1350f, 398f, 501f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1498f;
		float b = 1643f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void PNCJCHPOMOJ()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(335f, 1537f, 620f)) && base.transform.localRotation == Quaternion.Euler(220f, 523f, 1767f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1749f;
		float b = 1216f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void HBDEPMJNLEK()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1750f, 434f, 402f)) && base.transform.localRotation == Quaternion.Euler(180f, 236f, 31f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 190f;
		float b = 1682f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void ONGAIEOAHMA()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(302f, 1934f, 566f) || base.transform.localRotation == Quaternion.Euler(1275f, 37f, 1270f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 898f;
		float b = 1763f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void OBPDFCOPCMK()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			MBOFPLGHGLP();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			GGJNEGPBDHL();
		}
	}

	protected virtual void EKEHGBNPAFC()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			NDIJBPIDGOF();
		}
	}

	private void OBHPLFFLDBI()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1657f, 294f, 274f)) && base.transform.localRotation == Quaternion.Euler(1451f, 937f, 1102f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1903f;
		float b = 866f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			HGGFDJOFNMM();
		}
	}

	private void KFJJPGNGOCK()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(413f, 1316f, 245f) || base.transform.localRotation == Quaternion.Euler(190f, 616f, 952f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1423f;
		float b = 1783f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void NDIJBPIDGOF()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(1853f, 1556f, 541f) || base.transform.localRotation == Quaternion.Euler(1495f, 694f, 1294f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 151f;
		float b = 1890f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void DKMHPLCCLKI()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			JPBOGGKMAON();
		}
	}

	private void HPLKBFCFDIB()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1184f, 461f, 1024f)) && base.transform.localRotation == Quaternion.Euler(1123f, 616f, 1810f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 127f;
		float b = 1055f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void KOEBOGHPHIA()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(1923f, 1432f, 1637f) || base.transform.localRotation == Quaternion.Euler(91f, 1800f, 901f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1891f;
		float b = 777f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void IFCHBHGGKDJ()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1025f, 1773f, 1580f)) && base.transform.localRotation == Quaternion.Euler(1114f, 646f, 692f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1422f;
		float b = 1248f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void EPAHIKLPNNB()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(93f, 1942f, 1959f) || base.transform.localRotation == Quaternion.Euler(494f, 1181f, 1011f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 544f;
		float b = 1659f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void MDOGOLCLDIB()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			PNDFAOIDMHL();
		}
	}

	protected virtual void BKNKFFEHJOA()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			GJEEMJNIFFM();
		}
	}

	private void GBCFOFKPPJP()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(1162f, 1027f, 1675f) || base.transform.localRotation == Quaternion.Euler(251f, 1786f, 945f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1229f;
		float b = 1572f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void IHMEAAIKGAP()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(1766f, 1060f, 1180f) || base.transform.localRotation == Quaternion.Euler(253f, 308f, 382f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1712f;
		float b = 1015f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void BDMNPDBOCGN()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(441f, 1126f, 625f)) && base.transform.localRotation == Quaternion.Euler(342f, 1728f, 296f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1297f;
		float b = 386f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void JPBOGGKMAON()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(1662f, 1556f, 1500f) || base.transform.localRotation == Quaternion.Euler(1606f, 567f, 14f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 161f;
		float b = 49f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void OMGCKCFKDJM()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1090f, 734f, 1237f)) && base.transform.localRotation == Quaternion.Euler(1102f, 449f, 244f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 108f;
		float b = 978f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void HDMOFKHJMPE()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			IEJDJLALKGA();
		}
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			OMGCKCFKDJM();
		}
	}

	private void GJOIGNMPBCH()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(559f, 481f, 958f) || base.transform.localRotation == Quaternion.Euler(52f, 558f, 16f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 754f;
		float b = 1898f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void IOAEHDJGBJC()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			HGGFDJOFNMM();
		}
	}

	private void IGBPNEODHIP()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(1175f, 313f, 1970f) || base.transform.localRotation == Quaternion.Euler(61f, 1228f, 1291f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 551f;
		float b = 940f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void NGCPBGOBMLE()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(26f, 1082f, 679f) || base.transform.localRotation == Quaternion.Euler(811f, 1658f, 200f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 420f;
		float b = 1293f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void PDLNCCFMDFG()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			ONGAIEOAHMA();
		}
	}

	protected virtual void GILPNKCLMDI()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			PNCJCHPOMOJ();
		}
	}

	private void IOCNPPCMCMM()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(624f, 323f, 953f)) && base.transform.localRotation == Quaternion.Euler(1692f, 26f, 1976f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 48f;
		float b = 1432f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void OBPMHHGJFEL()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			ONGAIEOAHMA();
		}
	}

	private void KOBJDHJPDGD()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(47f, 1972f, 1854f) || base.transform.localRotation == Quaternion.Euler(1324f, 1855f, 1022f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 701f;
		float b = 1481f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void BGFKBPMPJIL()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(1384f, 1241f, 1575f) || base.transform.localRotation == Quaternion.Euler(1579f, 1913f, 1436f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1426f;
		float b = 1226f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void MFFEFILOKMG()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(369f, 1490f, 1932f)) && base.transform.localRotation == Quaternion.Euler(533f, 977f, 692f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 88f;
		float b = 1929f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void IEJDJLALKGA()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(274f, 1598f, 1392f) || base.transform.localRotation == Quaternion.Euler(1106f, 1373f, 1643f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 906f;
		float b = 1957f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void GDDCEHOJCEM()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			IHMEAAIKGAP();
		}
	}

	private void FJLJLDNCBBD()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(1719f, 1145f, 782f) || base.transform.localRotation == Quaternion.Euler(1501f, 1258f, 607f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 950f;
		float b = 1598f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void FKGIBDEAKGJ()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(954f, 122f, 49f)) && base.transform.localRotation == Quaternion.Euler(154f, 1201f, 1379f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 708f;
		float b = 238f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void BOLPPMANCCC()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			GJOIGNMPBCH();
		}
	}

	private void JMPLLJLLPHK()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(419f, 707f, 128f)) && base.transform.localRotation == Quaternion.Euler(641f, 1093f, 758f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 463f;
		float b = 1598f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void IIPMNCCFNIA()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			EDKFKNGLLBM();
		}
	}

	protected virtual void MMBMHLABBKN()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			GGJNEGPBDHL();
		}
	}

	private void GGJNEGPBDHL()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(0f, 0f, 90f) || base.transform.localRotation == Quaternion.Euler(0f, 0f, 270f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1f;
		float b = 1f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void HIHAFDPJPKC()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(627f, 1809f, 421f) || base.transform.localRotation == Quaternion.Euler(1263f, 1155f, 916f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 913f;
		float b = 1360f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void IACEOEJFEEM()
	{
		BIGNBCJCFNM = false;
		bool flag = base.transform.localRotation == Quaternion.Euler(854f, 744f, 1399f) || base.transform.localRotation == Quaternion.Euler(1518f, 1178f, 618f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 351f;
		float b = 126f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void CMOHGKPENIJ()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1280f, 552f, 490f)) && base.transform.localRotation == Quaternion.Euler(72f, 1199f, 1792f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 159f;
		float b = 1065f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void BMLLLOBPGIB()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			GGJNEGPBDHL();
		}
	}

	private void OJJHCFFEFGI()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(98f, 1965f, 1213f)) && base.transform.localRotation == Quaternion.Euler(990f, 1259f, 1712f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1530f;
		float b = 824f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void LCLEKFMLENA()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			PNCJCHPOMOJ();
		}
	}

	protected virtual void NLOODGLGPHE()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			NAKAFGAFEPH();
		}
	}

	private void JOAHALEPEAL()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(1884f, 1973f, 742f)) && base.transform.localRotation == Quaternion.Euler(1505f, 1874f, 1628f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 550f;
		float b = 1287f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void GJEEMJNIFFM()
	{
		BIGNBCJCFNM = false;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(923f, 588f, 1826f)) && base.transform.localRotation == Quaternion.Euler(1353f, 1485f, 791f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 227f;
		float b = 1019f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void MEBEHLLPMPK()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			GGJNEGPBDHL();
		}
	}

	private void KOABMGAPCKP()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(473f, 71f, 1500f)) && base.transform.localRotation == Quaternion.Euler(1667f, 868f, 795f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1073f;
		float b = 69f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void HGGFDJOFNMM()
	{
		BIGNBCJCFNM = true;
		bool flag = !(base.transform.localRotation == Quaternion.Euler(366f, 611f, 1960f)) && base.transform.localRotation == Quaternion.Euler(1661f, 1767f, 161f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 1601f;
		float b = 1056f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	private void CDEMNFDHFMC()
	{
		BIGNBCJCFNM = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(1325f, 1670f, 1528f) || base.transform.localRotation == Quaternion.Euler(1582f, 101f, 597f);
		JIAEMKCKBKJ.MakePixelPerfect();
		float x = JIAEMKCKBKJ.transform.localScale.x;
		float y = JIAEMKCKBKJ.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidthFull = UIHelper.activeWidthFull;
		float activeHeight = UIHelper.activeHeight;
		float a = 474f;
		float b = 832f;
		if (activeWidthFull > vector.x)
		{
			a = activeWidthFull * (ELGKHBDOMPF.x / LJBKFKFNDEM.x) / vector.x;
		}
		if (activeHeight > vector.y)
		{
			b = activeHeight * (ELGKHBDOMPF.y / LJBKFKFNDEM.y) / vector.y;
		}
		float num = Mathf.Max(a, b);
		Vector2 vector2 = vector * num;
		JIAEMKCKBKJ.transform.localScale = JIAEMKCKBKJ.transform.localScale.ReplaceXY((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x);
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
		if (!BIGNBCJCFNM)
		{
			KOEBOGHPHIA();
		}
	}
}
