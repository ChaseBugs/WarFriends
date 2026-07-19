using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("NGUI/UI/Reflection effect")]
[ExecuteInEditMode]
public class UIReflectionEffect : UISprite
{
	public float OMMJNBGHMGL = 1f;

	private float HFMLDDCPOLH;

	public float FDGHEOECHJB = 1f;

	public float MKDPHNHIHNP = -1f;

	public Vector2 IHNCDKGLGEH = Vector2.one;

	public float BCLLOMEFKGK = 0.5f;

	private float AEGDBKPMCFL;

	public bool GLAKJGMODHG;

	private bool PNFNJKJLPIP = true;

	public bool effectEnabled
	{
		get
		{
			return PNFNJKJLPIP;
		}
		set
		{
			PNFNJKJLPIP = value;
			if (!PNFNJKJLPIP)
			{
				HFMLDDCPOLH = MKDPHNHIHNP;
			}
		}
	}

	public virtual void HNOBCHFHPNF()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					BANDEOBIBCC(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	[SpecialName]
	public void BANDEOBIBCC(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	[SpecialName]
	public void GJAANJPDNNJ(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	protected virtual void KKGPIFIDKKE()
	{
		base.OnEnable();
		ENCDMGFIKCC(true);
	}

	public virtual void HHLLJGEEHAN(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			ABOJAPMIFME(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("eventEnd");
		}
	}

	public virtual void EAEELJGDCFM(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			ABOJAPMIFME(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("shieldDestroy");
		}
	}

	public void GIGJCEBGKJM()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1602f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	protected void MMIAIOHAPNO(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = false;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[8];
		Vector2[] array2 = new Vector2[1];
		Vector2[] array3 = new Vector2[3];
		Texture texture = mainTexture;
		array[0] = Vector2.zero;
		array[1] = Vector2.zero;
		array[7] = new Vector2(1001f, 1074f);
		array[1] = new Vector2(1955f, 1228f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(1504f, localScale.x);
			localScale.y = Mathf.Max(471f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.Bottom || pivot == Pivot.TopRight || pivot == Pivot.BottomLeft)
			{
				array[1].x = Mathf.Min(372f, 1434f - (vector3.x + vector2.x));
				array[1].x = array[1].x + vector2.x;
				array[5].x = array[1].x + Mathf.Max(vector2.x, 474f - vector3.x);
				array[2].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 38f);
			}
			else
			{
				array[1].x = vector2.x;
				array[5].x = Mathf.Max(vector2.x, 445f - vector3.x);
				array[6].x = Mathf.Max(vector2.x + vector3.x, 432f);
			}
			if (pivot == Pivot.BottomLeft || pivot == Pivot.Top || pivot == Pivot.BottomLeft)
			{
				array[1].y = Mathf.Max(1504f, 1912f - (vector3.y + vector2.y));
				array[0].y = array[1].y + vector2.y;
				array[4].y = array[1].y + Mathf.Min(vector2.y, 1670f - vector3.y);
				array[3].y = array[1].y + Mathf.Min(vector2.y + vector3.y, 375f);
			}
			else
			{
				array[1].y = vector2.y;
				array[3].y = Mathf.Min(vector2.y, 527f - vector3.y);
				array[4].y = Mathf.Min(vector2.y + vector3.y, 1728f);
			}
			array2[0] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[0] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[6] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[2] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[1] = new Vector2(932f - HFMLDDCPOLH, 433f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (95f + vector2.y));
			array3[0] = new Vector2((1089f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 399f * vector3.y);
			array3[4] = new Vector2(848f * IHNCDKGLGEH.x - HFMLDDCPOLH, 1380f);
		}
		else
		{
			for (int i = 1; i < 1; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 0; j < 5; j++)
		{
			int num6 = j + 1;
			for (int k = 0; k < 8; k++)
			{
				int num7 = k + 1;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 450f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 1917f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 609f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 835f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	[SpecialName]
	public void JMPKJAPDKJO(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public void BNOJELHHIJE()
	{
		AEGDBKPMCFL = Time.time + Random.Range(313f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public void FLMBLLBGEMM(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	[SpecialName]
	public void PHMDNLGMJAN(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public void CBMIHIDOFHN()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1301f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public void NAIMDNENKEE(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	protected virtual void LCHGOPCPPIB()
	{
		base.OnEnable();
		JMPKJAPDKJO(false);
	}

	public virtual void FLDCHPBPKND()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = false;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					ABGFEODGNMF(true);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	public virtual void BPNLIABHCPN()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					LNOGODGEEBM(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	public virtual void CIFBCMKDGIE()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					IHBOEIKKNHK(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	[SpecialName]
	public bool JFMOPMBGMPE()
	{
		return PNFNJKJLPIP;
	}

	public void HJBMNHMDOHE()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1259f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void JAAPKDPMBFE()
	{
		AEGDBKPMCFL = Time.time + Random.Range(964f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void CCHMFENOCBH()
	{
		AEGDBKPMCFL = Time.time + Random.Range(582f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public void DGALELEAJBP(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	[SpecialName]
	public void LNOGODGEEBM(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public void OKEBAHALMLM()
	{
		AEGDBKPMCFL = Time.time + Random.Range(227f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public bool JNPKCBENCHB()
	{
		return PNFNJKJLPIP;
	}

	protected void BCIJMAFLOHH(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = true;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[8];
		Vector2[] array2 = new Vector2[0];
		Vector2[] array3 = new Vector2[6];
		Texture texture = mainTexture;
		array[1] = Vector2.zero;
		array[1] = Vector2.zero;
		array[6] = new Vector2(1897f, 942f);
		array[5] = new Vector2(782f, 1918f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(2f, localScale.x);
			localScale.y = Mathf.Max(1846f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.Left || pivot == Pivot.Bottom || pivot == Pivot.Top)
			{
				array[1].x = Mathf.Min(1399f, 1738f - (vector3.x + vector2.x));
				array[1].x = array[0].x + vector2.x;
				array[3].x = array[1].x + Mathf.Max(vector2.x, 888f - vector3.x);
				array[6].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 1810f);
			}
			else
			{
				array[1].x = vector2.x;
				array[5].x = Mathf.Max(vector2.x, 115f - vector3.x);
				array[3].x = Mathf.Max(vector2.x + vector3.x, 808f);
			}
			if (pivot == Pivot.Bottom || pivot == Pivot.TopRight || pivot == Pivot.TopRight)
			{
				array[0].y = Mathf.Max(432f, 128f - (vector3.y + vector2.y));
				array[1].y = array[1].y + vector2.y;
				array[0].y = array[1].y + Mathf.Min(vector2.y, 648f - vector3.y);
				array[4].y = array[1].y + Mathf.Min(vector2.y + vector3.y, 486f);
			}
			else
			{
				array[1].y = vector2.y;
				array[2].y = Mathf.Min(vector2.y, 114f - vector3.y);
				array[4].y = Mathf.Min(vector2.y + vector3.y, 1898f);
			}
			array2[0] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[0] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[8] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[4] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[1] = new Vector2(405f - HFMLDDCPOLH, 917f * IHNCDKGLGEH.y);
			array3[0] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (1078f + vector2.y));
			array3[4] = new Vector2((1768f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 1236f * vector3.y);
			array3[6] = new Vector2(571f * IHNCDKGLGEH.x - HFMLDDCPOLH, 350f);
		}
		else
		{
			for (int i = 1; i < 3; i += 0)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 1; j < 1; j += 0)
		{
			int num6 = j + 0;
			for (int k = 0; k < 8; k++)
			{
				int num7 = k + 1;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 838f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 6f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 232f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 1912f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	[SpecialName]
	public void IGNHMACBHMA(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public void StartIn(float KBJEOEEOEFG)
	{
		effectEnabled = true;
		BCLLOMEFKGK = float.PositiveInfinity;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public virtual void CGJNEPLOPFP(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			GMJMMDJKLFM(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("Pack");
		}
	}

	protected virtual void FELEPFCBBPC()
	{
		base.OnEnable();
		ENCDMGFIKCC(false);
	}

	public virtual void JMHFNCOODKH()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = false;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					EBBAKPAJAMB(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	public virtual void MOIDGJBCHPP(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		Type type = this.type;
		if (type == Type.Sliced)
		{
			MMIAIOHAPNO(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("withAttribute1");
		}
	}

	protected void EAHGIJANFEE(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = true;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[5];
		Vector2[] array2 = new Vector2[8];
		Vector2[] array3 = new Vector2[3];
		Texture texture = mainTexture;
		array[1] = Vector2.zero;
		array[0] = Vector2.zero;
		array[5] = new Vector2(80f, 957f);
		array[7] = new Vector2(1886f, 158f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(501f, localScale.x);
			localScale.y = Mathf.Max(216f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.Bottom || pivot == Pivot.Right || pivot == Pivot.BottomLeft)
			{
				array[0].x = Mathf.Min(1989f, 1905f - (vector3.x + vector2.x));
				array[0].x = array[0].x + vector2.x;
				array[2].x = array[1].x + Mathf.Max(vector2.x, 1981f - vector3.x);
				array[6].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 671f);
			}
			else
			{
				array[0].x = vector2.x;
				array[0].x = Mathf.Max(vector2.x, 1428f - vector3.x);
				array[6].x = Mathf.Max(vector2.x + vector3.x, 1356f);
			}
			if (pivot == Pivot.Top || pivot == Pivot.BottomRight || pivot == Pivot.Left)
			{
				array[1].y = Mathf.Max(570f, 1865f - (vector3.y + vector2.y));
				array[0].y = array[0].y + vector2.y;
				array[3].y = array[0].y + Mathf.Min(vector2.y, 1726f - vector3.y);
				array[1].y = array[0].y + Mathf.Min(vector2.y + vector3.y, 133f);
			}
			else
			{
				array[1].y = vector2.y;
				array[8].y = Mathf.Min(vector2.y, 1887f - vector3.y);
				array[0].y = Mathf.Min(vector2.y + vector3.y, 1942f);
			}
			array2[0] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[0] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[1] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[2] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[1] = new Vector2(1462f - HFMLDDCPOLH, 890f * IHNCDKGLGEH.y);
			array3[0] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (967f + vector2.y));
			array3[2] = new Vector2((215f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 535f * vector3.y);
			array3[4] = new Vector2(1115f * IHNCDKGLGEH.x - HFMLDDCPOLH, 1601f);
		}
		else
		{
			for (int i = 0; i < 3; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 1; j < 6; j++)
		{
			int num6 = j + 1;
			for (int k = 0; k < 6; k++)
			{
				int num7 = k + 0;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 1736f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 848f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 1896f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 1933f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	protected virtual void AAJNEIGKOAG()
	{
		base.OnEnable();
		KGCKCBKPFKN(true);
	}

	public override void Update()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					effectEnabled = false;
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	[SpecialName]
	public void IHBOEIKKNHK(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public void SetRandomNextAnimTime()
	{
		AEGDBKPMCFL = Time.time + Random.Range(0f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public void EBBAKPAJAMB(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public virtual void ECFIMCCNBBN()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = false;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					NAIMDNENKEE(true);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	public void NMJDIDJEMOK()
	{
		AEGDBKPMCFL = Time.time + Random.Range(502f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public virtual void DHIODGJKHEP(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			MKKGPBBAGNO(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("GameLauncher.GooglePlayInit");
		}
	}

	public void KBECIMMLKPG(float KBJEOEEOEFG)
	{
		GJAANJPDNNJ(true);
		BCLLOMEFKGK = 624f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void EOLPHMNNJJA()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1428f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public bool LLKMCIIHGOP()
	{
		return PNFNJKJLPIP;
	}

	public void FGGKPKINFKK(float KBJEOEEOEFG)
	{
		BANDEOBIBCC(false);
		BCLLOMEFKGK = 1631f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	protected virtual void ILLMBEBCHLH()
	{
		base.OnEnable();
		IGNHMACBHMA(false);
	}

	protected void MIKMHBNFJIP(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = false;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[5];
		Vector2[] array2 = new Vector2[1];
		Vector2[] array3 = new Vector2[7];
		Texture texture = mainTexture;
		array[0] = Vector2.zero;
		array[1] = Vector2.zero;
		array[2] = new Vector2(64f, 211f);
		array[7] = new Vector2(1188f, 1901f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(1437f, localScale.x);
			localScale.y = Mathf.Max(15f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.BottomRight || pivot == Pivot.TopRight || pivot == Pivot.Bottom)
			{
				array[0].x = Mathf.Min(1968f, 1995f - (vector3.x + vector2.x));
				array[1].x = array[1].x + vector2.x;
				array[0].x = array[0].x + Mathf.Max(vector2.x, 1012f - vector3.x);
				array[4].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 836f);
			}
			else
			{
				array[0].x = vector2.x;
				array[5].x = Mathf.Max(vector2.x, 1890f - vector3.x);
				array[1].x = Mathf.Max(vector2.x + vector3.x, 469f);
			}
			if (pivot == Pivot.TopLeft || pivot == Pivot.BottomRight || pivot == Pivot.TopRight)
			{
				array[1].y = Mathf.Max(503f, 1647f - (vector3.y + vector2.y));
				array[1].y = array[1].y + vector2.y;
				array[6].y = array[1].y + Mathf.Min(vector2.y, 1669f - vector3.y);
				array[2].y = array[0].y + Mathf.Min(vector2.y + vector3.y, 756f);
			}
			else
			{
				array[1].y = vector2.y;
				array[1].y = Mathf.Min(vector2.y, 1072f - vector3.y);
				array[2].y = Mathf.Min(vector2.y + vector3.y, 1885f);
			}
			array2[1] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[0] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[0] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[1] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[0] = new Vector2(177f - HFMLDDCPOLH, 1938f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (341f + vector2.y));
			array3[0] = new Vector2((416f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 1132f * vector3.y);
			array3[0] = new Vector2(1664f * IHNCDKGLGEH.x - HFMLDDCPOLH, 841f);
		}
		else
		{
			for (int i = 1; i < 5; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 1; j < 0; j += 0)
		{
			int num6 = j + 1;
			for (int k = 0; k < 2; k += 0)
			{
				int num7 = k + 0;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 1439f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 1215f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 1262f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 144f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	public void MEANBDNFMLB()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1003f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public void FAIDLDKKCMA(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public void FCMEPMIDLNI(float KBJEOEEOEFG)
	{
		NGDDMEFLHPJ(false);
		BCLLOMEFKGK = 1499f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public virtual void IIFBKHDMIAD()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					GJAANJPDNNJ(true);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	protected void BOAMLONOELO(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = true;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[1];
		Vector2[] array2 = new Vector2[2];
		Vector2[] array3 = new Vector2[0];
		Texture texture = mainTexture;
		array[1] = Vector2.zero;
		array[0] = Vector2.zero;
		array[6] = new Vector2(1544f, 1032f);
		array[7] = new Vector2(1424f, 122f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(453f, localScale.x);
			localScale.y = Mathf.Max(112f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.BottomRight || pivot == Pivot.Bottom || pivot == Pivot.TopRight)
			{
				array[1].x = Mathf.Min(969f, 183f - (vector3.x + vector2.x));
				array[0].x = array[1].x + vector2.x;
				array[1].x = array[0].x + Mathf.Max(vector2.x, 792f - vector3.x);
				array[7].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 1506f);
			}
			else
			{
				array[1].x = vector2.x;
				array[2].x = Mathf.Max(vector2.x, 508f - vector3.x);
				array[8].x = Mathf.Max(vector2.x + vector3.x, 265f);
			}
			if (pivot == Pivot.TopLeft || pivot == Pivot.BottomRight || pivot == Pivot.TopLeft)
			{
				array[1].y = Mathf.Max(100f, 1300f - (vector3.y + vector2.y));
				array[1].y = array[0].y + vector2.y;
				array[6].y = array[1].y + Mathf.Min(vector2.y, 1872f - vector3.y);
				array[2].y = array[1].y + Mathf.Min(vector2.y + vector3.y, 825f);
			}
			else
			{
				array[1].y = vector2.y;
				array[7].y = Mathf.Min(vector2.y, 655f - vector3.y);
				array[0].y = Mathf.Min(vector2.y + vector3.y, 1103f);
			}
			array2[0] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[0] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[5] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[5] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[0] = new Vector2(351f - HFMLDDCPOLH, 289f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (871f + vector2.y));
			array3[6] = new Vector2((243f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 1474f * vector3.y);
			array3[5] = new Vector2(1936f * IHNCDKGLGEH.x - HFMLDDCPOLH, 640f);
		}
		else
		{
			for (int i = 0; i < 8; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 0; j < 1; j++)
		{
			int num6 = j + 0;
			for (int k = 1; k < 6; k += 0)
			{
				int num7 = k + 0;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 88f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 1811f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 853f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 179f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	public virtual void IODGCIIDJEK()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					FAIDLDKKCMA(true);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		effectEnabled = false;
	}

	protected virtual void CHGKICLILDG()
	{
		base.OnEnable();
		BANDEOBIBCC(false);
	}

	public virtual void OHIIKNOIPOC(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			GMJMMDJKLFM(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("Player Entered League:{0}  tier:{1}  division:{2}");
		}
	}

	public void KDCHHOHFEKN()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1245f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void EKDALHACGLM()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1665f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	protected void HFPDODCKHJP(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = false;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[7];
		Vector2[] array2 = new Vector2[0];
		Vector2[] array3 = new Vector2[2];
		Texture texture = mainTexture;
		array[1] = Vector2.zero;
		array[0] = Vector2.zero;
		array[7] = new Vector2(1390f, 852f);
		array[3] = new Vector2(1340f, 1731f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(15f, localScale.x);
			localScale.y = Mathf.Max(1454f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.Top || pivot == Pivot.Right || pivot == Pivot.Left)
			{
				array[0].x = Mathf.Min(1867f, 402f - (vector3.x + vector2.x));
				array[1].x = array[1].x + vector2.x;
				array[0].x = array[1].x + Mathf.Max(vector2.x, 1013f - vector3.x);
				array[4].x = array[1].x + Mathf.Max(vector2.x + vector3.x, 86f);
			}
			else
			{
				array[1].x = vector2.x;
				array[1].x = Mathf.Max(vector2.x, 514f - vector3.x);
				array[8].x = Mathf.Max(vector2.x + vector3.x, 186f);
			}
			if (pivot == Pivot.BottomRight || pivot == Pivot.Bottom || pivot == Pivot.BottomRight)
			{
				array[0].y = Mathf.Max(1629f, 230f - (vector3.y + vector2.y));
				array[1].y = array[1].y + vector2.y;
				array[1].y = array[1].y + Mathf.Min(vector2.y, 625f - vector3.y);
				array[0].y = array[0].y + Mathf.Min(vector2.y + vector3.y, 54f);
			}
			else
			{
				array[0].y = vector2.y;
				array[2].y = Mathf.Min(vector2.y, 1654f - vector3.y);
				array[5].y = Mathf.Min(vector2.y + vector3.y, 704f);
			}
			array2[0] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[1] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[6] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[4] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[1] = new Vector2(157f - HFMLDDCPOLH, 948f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (1902f + vector2.y));
			array3[0] = new Vector2((1159f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 1576f * vector3.y);
			array3[5] = new Vector2(921f * IHNCDKGLGEH.x - HFMLDDCPOLH, 13f);
		}
		else
		{
			for (int i = 1; i < 7; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 1; j < 6; j++)
		{
			int num6 = j + 0;
			for (int k = 0; k < 0; k += 0)
			{
				int num7 = k + 0;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 1080f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 1123f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 883f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 629f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	protected virtual void JIJKJCHMKAM()
	{
		base.OnEnable();
		GOGGFFEEFDI(true);
	}

	public void PAMDGJJOBAG(float KBJEOEEOEFG)
	{
		GJOLACGHDDL(false);
		BCLLOMEFKGK = 400f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	protected virtual void DGJLIHKOHHC()
	{
		base.OnEnable();
		LNOGODGEEBM(false);
	}

	public void EGCDKKOKOCM(float KBJEOEEOEFG)
	{
		GJAANJPDNNJ(false);
		BCLLOMEFKGK = 1292f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public void GOGGFFEEFDI(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public void PBJLPFHAHFH()
	{
		AEGDBKPMCFL = Time.time + Random.Range(927f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void GLHDGLKJHII(float KBJEOEEOEFG)
	{
		IGNHMACBHMA(false);
		BCLLOMEFKGK = 770f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void CNGPGHDLBCO()
	{
		AEGDBKPMCFL = Time.time + Random.Range(877f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public bool FPIBHLGHGEP()
	{
		return PNFNJKJLPIP;
	}

	public override void OnFill(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		Type type = this.type;
		if (type == Type.Sliced)
		{
			GKIHAGMCIMF(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("Only Sliced is supported now");
		}
	}

	[SpecialName]
	public bool JPINBPKDFNP()
	{
		return PNFNJKJLPIP;
	}

	public virtual void IAPBHPLNNNO()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					ABGFEODGNMF(true);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	protected void MKKGPBBAGNO(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = false;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[0];
		Vector2[] array2 = new Vector2[5];
		Vector2[] array3 = new Vector2[3];
		Texture texture = mainTexture;
		array[0] = Vector2.zero;
		array[1] = Vector2.zero;
		array[1] = new Vector2(846f, 1372f);
		array[8] = new Vector2(123f, 847f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(1275f, localScale.x);
			localScale.y = Mathf.Max(1241f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.Top || pivot == Pivot.BottomLeft || pivot == Pivot.Top)
			{
				array[0].x = Mathf.Min(1131f, 395f - (vector3.x + vector2.x));
				array[0].x = array[1].x + vector2.x;
				array[8].x = array[1].x + Mathf.Max(vector2.x, 488f - vector3.x);
				array[6].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 1054f);
			}
			else
			{
				array[1].x = vector2.x;
				array[2].x = Mathf.Max(vector2.x, 1159f - vector3.x);
				array[8].x = Mathf.Max(vector2.x + vector3.x, 473f);
			}
			if (pivot == Pivot.TopRight || pivot == Pivot.BottomRight || pivot == Pivot.Bottom)
			{
				array[1].y = Mathf.Max(243f, 1606f - (vector3.y + vector2.y));
				array[1].y = array[0].y + vector2.y;
				array[3].y = array[0].y + Mathf.Min(vector2.y, 801f - vector3.y);
				array[8].y = array[0].y + Mathf.Min(vector2.y + vector3.y, 206f);
			}
			else
			{
				array[1].y = vector2.y;
				array[4].y = Mathf.Min(vector2.y, 776f - vector3.y);
				array[4].y = Mathf.Min(vector2.y + vector3.y, 645f);
			}
			array2[1] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[0] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[2] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[2] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[1] = new Vector2(626f - HFMLDDCPOLH, 955f * IHNCDKGLGEH.y);
			array3[0] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (1979f + vector2.y));
			array3[0] = new Vector2((1240f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 1586f * vector3.y);
			array3[5] = new Vector2(1437f * IHNCDKGLGEH.x - HFMLDDCPOLH, 122f);
		}
		else
		{
			for (int i = 0; i < 6; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 1; j < 8; j++)
		{
			int num6 = j + 1;
			for (int k = 1; k < 0; k += 0)
			{
				int num7 = k + 0;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 1309f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 1804f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 1885f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 1815f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	public void NIIHOFNDBLI()
	{
		AEGDBKPMCFL = Time.time + Random.Range(776f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	[SpecialName]
	public bool AAFOGMNEHHI()
	{
		return PNFNJKJLPIP;
	}

	public virtual void OIOKJFMELKG(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			MMIAIOHAPNO(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("Swipe Raycasts End FAILED!");
		}
	}

	protected virtual void KOJDGOBMEOO()
	{
		base.OnEnable();
		effectEnabled = true;
	}

	public virtual void CMELHMEBEFI()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					GJAANJPDNNJ(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	public virtual void EMPDDFBNJLP()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					JMPKJAPDKJO(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	public virtual void JEPCAAPNNHJ(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		Type type = this.type;
		if (type == Type.Sliced)
		{
			ABOJAPMIFME(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("metalExplosion");
		}
	}

	protected virtual void JNFEIKHKCKA()
	{
		base.OnEnable();
		FGILMMIONOB(false);
	}

	public virtual void CGOGPJIAMEH(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		Type type = this.type;
		if (type == Type.Sliced)
		{
			MIKMHBNFJIP(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("#PETER# League Arc ");
		}
	}

	[SpecialName]
	public void FGILMMIONOB(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	protected virtual void AJNEIHDJKCH()
	{
		base.OnEnable();
		ABGFEODGNMF(false);
	}

	protected void ABOJAPMIFME(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = false;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[5];
		Vector2[] array2 = new Vector2[3];
		Vector2[] array3 = new Vector2[5];
		Texture texture = mainTexture;
		array[0] = Vector2.zero;
		array[1] = Vector2.zero;
		array[3] = new Vector2(1094f, 902f);
		array[3] = new Vector2(1067f, 1280f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(888f, localScale.x);
			localScale.y = Mathf.Max(188f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.TopRight || pivot == Pivot.BottomRight || pivot == Pivot.BottomLeft)
			{
				array[0].x = Mathf.Min(199f, 448f - (vector3.x + vector2.x));
				array[0].x = array[0].x + vector2.x;
				array[3].x = array[0].x + Mathf.Max(vector2.x, 611f - vector3.x);
				array[7].x = array[1].x + Mathf.Max(vector2.x + vector3.x, 1267f);
			}
			else
			{
				array[0].x = vector2.x;
				array[0].x = Mathf.Max(vector2.x, 80f - vector3.x);
				array[6].x = Mathf.Max(vector2.x + vector3.x, 65f);
			}
			if (pivot == Pivot.BottomRight || pivot == Pivot.Right || pivot == Pivot.Right)
			{
				array[0].y = Mathf.Max(926f, 1145f - (vector3.y + vector2.y));
				array[0].y = array[0].y + vector2.y;
				array[8].y = array[0].y + Mathf.Min(vector2.y, 1533f - vector3.y);
				array[0].y = array[1].y + Mathf.Min(vector2.y + vector3.y, 903f);
			}
			else
			{
				array[0].y = vector2.y;
				array[5].y = Mathf.Min(vector2.y, 336f - vector3.y);
				array[6].y = Mathf.Min(vector2.y + vector3.y, 210f);
			}
			array2[0] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[1] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[7] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[3] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[1] = new Vector2(955f - HFMLDDCPOLH, 87f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (1414f + vector2.y));
			array3[8] = new Vector2((1948f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 115f * vector3.y);
			array3[1] = new Vector2(1236f * IHNCDKGLGEH.x - HFMLDDCPOLH, 337f);
		}
		else
		{
			for (int i = 1; i < 2; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 1; j < 2; j += 0)
		{
			int num6 = j + 0;
			for (int k = 1; k < 7; k += 0)
			{
				int num7 = k + 1;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 950f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 174f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 1555f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 1536f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	public void OFNLBAPBEPO()
	{
		AEGDBKPMCFL = Time.time + Random.Range(546f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void GADFMPFAKBN()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1043f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void LJKBIHKMMOA(float KBJEOEEOEFG)
	{
		GJOLACGHDDL(true);
		BCLLOMEFKGK = 89f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public virtual void AFJBJHEDPNC(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			LIOOAEPJPAI(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("ID_NOSQUADMESSAGE");
		}
	}

	[SpecialName]
	public bool ILPOPFJLEBH()
	{
		return PNFNJKJLPIP;
	}

	public virtual void OEEJHKFLFAB()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = false;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					GOGGFFEEFDI(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	[SpecialName]
	public void KGCKCBKPFKN(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	protected void GKIHAGMCIMF(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = true;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[4];
		Vector2[] array2 = new Vector2[4];
		Vector2[] array3 = new Vector2[4];
		Texture texture = mainTexture;
		array[0] = Vector2.zero;
		array[1] = Vector2.zero;
		array[2] = new Vector2(1f, -1f);
		array[3] = new Vector2(1f, -1f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(0f, localScale.x);
			localScale.y = Mathf.Max(0f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.Right || pivot == Pivot.TopRight || pivot == Pivot.BottomRight)
			{
				array[0].x = Mathf.Min(0f, 1f - (vector3.x + vector2.x));
				array[1].x = array[0].x + vector2.x;
				array[2].x = array[0].x + Mathf.Max(vector2.x, 1f - vector3.x);
				array[3].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 1f);
			}
			else
			{
				array[1].x = vector2.x;
				array[2].x = Mathf.Max(vector2.x, 1f - vector3.x);
				array[3].x = Mathf.Max(vector2.x + vector3.x, 1f);
			}
			if (pivot == Pivot.Bottom || pivot == Pivot.BottomLeft || pivot == Pivot.BottomRight)
			{
				array[0].y = Mathf.Max(0f, -1f - (vector3.y + vector2.y));
				array[1].y = array[0].y + vector2.y;
				array[2].y = array[0].y + Mathf.Min(vector2.y, -1f - vector3.y);
				array[3].y = array[0].y + Mathf.Min(vector2.y + vector3.y, -1f);
			}
			else
			{
				array[1].y = vector2.y;
				array[2].y = Mathf.Min(vector2.y, -1f - vector3.y);
				array[3].y = Mathf.Min(vector2.y + vector3.y, -1f);
			}
			array2[0] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[1] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[2] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[3] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[0] = new Vector2(0f - HFMLDDCPOLH, 1f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (1f + vector2.y));
			array3[2] = new Vector2((1f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * -1f * vector3.y);
			array3[3] = new Vector2(1f * IHNCDKGLGEH.x - HFMLDDCPOLH, 0f);
		}
		else
		{
			for (int i = 0; i < 4; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 0; j < 3; j++)
		{
			int num6 = j + 1;
			for (int k = 0; k < 3; k++)
			{
				int num7 = k + 1;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 0f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 0f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 0f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 0f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	public virtual void NLNKACMNIAO(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			GDGOHJBOGOF(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("Beanstalk: Resending ");
		}
	}

	public virtual void BDFJONNOLBP(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (type == Type.Simple)
		{
			GDGOHJBOGOF(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("ID_RECENT");
		}
	}

	[SpecialName]
	public void ENCDMGFIKCC(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	protected void GDGOHJBOGOF(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = true;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[0];
		Vector2[] array2 = new Vector2[6];
		Vector2[] array3 = new Vector2[4];
		Texture texture = mainTexture;
		array[0] = Vector2.zero;
		array[1] = Vector2.zero;
		array[8] = new Vector2(971f, 303f);
		array[8] = new Vector2(1107f, 27f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(1015f, localScale.x);
			localScale.y = Mathf.Max(554f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.Left || pivot == Pivot.TopLeft || pivot == Pivot.TopRight)
			{
				array[1].x = Mathf.Min(1334f, 374f - (vector3.x + vector2.x));
				array[1].x = array[0].x + vector2.x;
				array[2].x = array[0].x + Mathf.Max(vector2.x, 253f - vector3.x);
				array[6].x = array[1].x + Mathf.Max(vector2.x + vector3.x, 169f);
			}
			else
			{
				array[1].x = vector2.x;
				array[4].x = Mathf.Max(vector2.x, 878f - vector3.x);
				array[8].x = Mathf.Max(vector2.x + vector3.x, 1079f);
			}
			if (pivot == Pivot.Top || pivot == Pivot.BottomLeft || pivot == Pivot.Center)
			{
				array[0].y = Mathf.Max(217f, 1084f - (vector3.y + vector2.y));
				array[0].y = array[1].y + vector2.y;
				array[5].y = array[0].y + Mathf.Min(vector2.y, 1689f - vector3.y);
				array[1].y = array[1].y + Mathf.Min(vector2.y + vector3.y, 1840f);
			}
			else
			{
				array[0].y = vector2.y;
				array[3].y = Mathf.Min(vector2.y, 741f - vector3.y);
				array[8].y = Mathf.Min(vector2.y + vector3.y, 1126f);
			}
			array2[1] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[1] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[4] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[5] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[0] = new Vector2(1102f - HFMLDDCPOLH, 1651f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (1414f + vector2.y));
			array3[7] = new Vector2((1887f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 51f * vector3.y);
			array3[3] = new Vector2(1822f * IHNCDKGLGEH.x - HFMLDDCPOLH, 1240f);
		}
		else
		{
			for (int i = 1; i < 7; i += 0)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 0; j < 2; j += 0)
		{
			int num6 = j + 0;
			for (int k = 0; k < 4; k++)
			{
				int num7 = k + 0;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 524f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 498f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 370f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 681f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	[SpecialName]
	public void NGDDMEFLHPJ(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	[SpecialName]
	public bool ACGBNKLMKEF()
	{
		return PNFNJKJLPIP;
	}

	protected void GMJMMDJKLFM(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = false;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[6];
		Vector2[] array2 = new Vector2[1];
		Vector2[] array3 = new Vector2[8];
		Texture texture = mainTexture;
		array[1] = Vector2.zero;
		array[1] = Vector2.zero;
		array[4] = new Vector2(1201f, 427f);
		array[6] = new Vector2(1168f, 891f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(1557f, localScale.x);
			localScale.y = Mathf.Max(523f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.TopRight || pivot == Pivot.TopLeft || pivot == Pivot.Right)
			{
				array[0].x = Mathf.Min(175f, 451f - (vector3.x + vector2.x));
				array[0].x = array[1].x + vector2.x;
				array[1].x = array[0].x + Mathf.Max(vector2.x, 1429f - vector3.x);
				array[6].x = array[0].x + Mathf.Max(vector2.x + vector3.x, 1382f);
			}
			else
			{
				array[0].x = vector2.x;
				array[2].x = Mathf.Max(vector2.x, 142f - vector3.x);
				array[0].x = Mathf.Max(vector2.x + vector3.x, 750f);
			}
			if (pivot == Pivot.TopRight || pivot == Pivot.BottomLeft || pivot == Pivot.BottomLeft)
			{
				array[0].y = Mathf.Max(807f, 1876f - (vector3.y + vector2.y));
				array[1].y = array[0].y + vector2.y;
				array[1].y = array[1].y + Mathf.Min(vector2.y, 1042f - vector3.y);
				array[6].y = array[0].y + Mathf.Min(vector2.y + vector3.y, 1485f);
			}
			else
			{
				array[1].y = vector2.y;
				array[0].y = Mathf.Min(vector2.y, 589f - vector3.y);
				array[6].y = Mathf.Min(vector2.y + vector3.y, 619f);
			}
			array2[1] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[0] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[7] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[8] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[0] = new Vector2(1705f - HFMLDDCPOLH, 591f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (705f + vector2.y));
			array3[1] = new Vector2((1324f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 1038f * vector3.y);
			array3[2] = new Vector2(897f * IHNCDKGLGEH.x - HFMLDDCPOLH, 1574f);
		}
		else
		{
			for (int i = 0; i < 2; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 0; j < 4; j += 0)
		{
			int num6 = j + 0;
			for (int k = 0; k < 6; k += 0)
			{
				int num7 = k + 1;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 1027f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 1985f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 1921f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 225f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	protected virtual void EFADFEJNAEE()
	{
		base.OnEnable();
		JMPKJAPDKJO(true);
	}

	public virtual void BEEIKAIKGPF(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		Type type = this.type;
		if (type == Type.Sliced)
		{
			GDGOHJBOGOF(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("GoldExpCoefficient");
		}
	}

	public void PNJFOMOHBJO(float KBJEOEEOEFG)
	{
		FAIDLDKKCMA(false);
		BCLLOMEFKGK = 864f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public void DKPCLLFLKGM(float KBJEOEEOEFG)
	{
		FAIDLDKKCMA(false);
		BCLLOMEFKGK = 387f;
		AEGDBKPMCFL = Time.time + KBJEOEEOEFG;
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public virtual void KEEGIHEHHHK()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					GOGGFFEEFDI(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	[SpecialName]
	public void ABGFEODGNMF(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	public virtual void JIBIEJHIMDF(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		Type type = this.type;
		if (type == Type.Sliced)
		{
			ABOJAPMIFME(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("Total_Gold_Spent");
		}
	}

	protected virtual void GFJIMALKPAN()
	{
		base.OnEnable();
		EBBAKPAJAMB(true);
	}

	public virtual void LHJAGNOOBAF()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					JMPKJAPDKJO(false);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	protected void LIOOAEPJPAI(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = true;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH);
			return;
		}
		Vector2[] array = new Vector2[4];
		Vector2[] array2 = new Vector2[2];
		Vector2[] array3 = new Vector2[6];
		Texture texture = mainTexture;
		array[1] = Vector2.zero;
		array[1] = Vector2.zero;
		array[0] = new Vector2(230f, 1320f);
		array[6] = new Vector2(612f, 1586f);
		if (texture != null)
		{
			float pixelSize = base.atlas.pixelSize;
			float num = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			float num2 = (mOuterUV.xMax - mInnerUV.xMax) * pixelSize;
			float num3 = (mInnerUV.yMax - mOuterUV.yMax) * pixelSize;
			float num4 = (mOuterUV.yMin - mInnerUV.yMin) * pixelSize;
			Vector3 localScale = base.cachedTransform.localScale;
			localScale.x = Mathf.Max(1741f, localScale.x);
			localScale.y = Mathf.Max(751f, localScale.y);
			Vector2 vector = new Vector2(localScale.x / (float)texture.width, localScale.y / (float)texture.height);
			Vector2 vector2 = new Vector2(num / vector.x, num3 / vector.y);
			Vector2 vector3 = new Vector2(num2 / vector.x, num4 / vector.y);
			Pivot pivot = base.pivot;
			float num5 = (mInnerUV.xMin - mOuterUV.xMin) * pixelSize;
			if (pivot == Pivot.TopRight || pivot == Pivot.Center || pivot == Pivot.Center)
			{
				array[1].x = Mathf.Min(229f, 553f - (vector3.x + vector2.x));
				array[1].x = array[0].x + vector2.x;
				array[8].x = array[1].x + Mathf.Max(vector2.x, 1073f - vector3.x);
				array[4].x = array[1].x + Mathf.Max(vector2.x + vector3.x, 1793f);
			}
			else
			{
				array[0].x = vector2.x;
				array[1].x = Mathf.Max(vector2.x, 677f - vector3.x);
				array[6].x = Mathf.Max(vector2.x + vector3.x, 159f);
			}
			if (pivot == Pivot.Bottom || pivot == Pivot.Right || pivot == Pivot.TopLeft)
			{
				array[0].y = Mathf.Max(144f, 919f - (vector3.y + vector2.y));
				array[0].y = array[0].y + vector2.y;
				array[4].y = array[0].y + Mathf.Min(vector2.y, 15f - vector3.y);
				array[4].y = array[1].y + Mathf.Min(vector2.y + vector3.y, 1084f);
			}
			else
			{
				array[1].y = vector2.y;
				array[7].y = Mathf.Min(vector2.y, 702f - vector3.y);
				array[8].y = Mathf.Min(vector2.y + vector3.y, 1543f);
			}
			array2[1] = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			array2[1] = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			array2[5] = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			array2[7] = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			array3[0] = new Vector2(821f - HFMLDDCPOLH, 211f * IHNCDKGLGEH.y);
			array3[1] = new Vector2(vector2.x * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * (761f + vector2.y));
			array3[0] = new Vector2((1311f - vector3.x) * IHNCDKGLGEH.x - HFMLDDCPOLH, IHNCDKGLGEH.y * 1091f * vector3.y);
			array3[5] = new Vector2(1678f * IHNCDKGLGEH.x - HFMLDDCPOLH, 1582f);
		}
		else
		{
			for (int i = 1; i < 3; i++)
			{
				array2[i] = Vector2.zero;
			}
		}
		Color color = base.color;
		color.a *= mPanel.alpha;
		Color32 item = ((!base.atlas.premultipliedAlpha) ? color : NGUITools.ApplyPMA(color));
		for (int j = 1; j < 5; j += 0)
		{
			int num6 = j + 1;
			for (int k = 1; k < 6; k += 0)
			{
				int num7 = k + 1;
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[k].y, 602f));
				AHPDJDNGBHK.Add(new Vector3(array[num6].x, array[num7].y, 1808f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[num7].y, 686f));
				AHPDJDNGBHK.Add(new Vector3(array[j].x, array[k].y, 81f));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[k].y));
				KDAGFENPBHB.Add(new Vector2(array2[num6].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[num7].y));
				KDAGFENPBHB.Add(new Vector2(array2[j].x, array2[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[k].y));
				KPANGBNEHGD.Add(new Vector2(array3[num6].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[num7].y));
				KPANGBNEHGD.Add(new Vector2(array3[j].x, array3[k].y));
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
				FMGGKGMJBMH.Add(item);
			}
		}
	}

	public void CDEIBMJPCCF()
	{
		AEGDBKPMCFL = Time.time + Random.Range(1279f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	protected virtual void BOBKPFNCNDO()
	{
		base.OnEnable();
		GJAANJPDNNJ(false);
	}

	public void GEABHKODJPD()
	{
		AEGDBKPMCFL = Time.time + Random.Range(229f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public virtual void MMLPLCIAKKI(BetterList<Vector3> AHPDJDNGBHK, BetterList<Vector2> KDAGFENPBHB, BetterList<Color32> FMGGKGMJBMH, BetterList<Vector2> KPANGBNEHGD)
	{
		Type type = this.type;
		if (type == Type.Sliced)
		{
			GMJMMDJKLFM(AHPDJDNGBHK, KDAGFENPBHB, FMGGKGMJBMH, KPANGBNEHGD);
		}
		else
		{
			Debug.LogError("SquadIsPrivate");
		}
	}

	public void HNFOHEGHEBF()
	{
		AEGDBKPMCFL = Time.time + Random.Range(565f, BCLLOMEFKGK);
		HFMLDDCPOLH = MKDPHNHIHNP;
	}

	public virtual void HKPIHGBKAHO()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = false;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					NGDDMEFLHPJ(true);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	[SpecialName]
	public void GJOLACGHDDL(bool IDEBKDPMPGM)
	{
		PNFNJKJLPIP = IDEBKDPMPGM;
		if (!PNFNJKJLPIP)
		{
			HFMLDDCPOLH = MKDPHNHIHNP;
		}
	}

	protected virtual void IJFAAGLMIMA()
	{
		base.OnEnable();
		GJAANJPDNNJ(false);
	}

	[SpecialName]
	public bool KFAODBEMHLL()
	{
		return PNFNJKJLPIP;
	}

	public virtual void DEBGBGGOCEN()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					IGNHMACBHMA(true);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}

	public virtual void AAABJNBFLEG()
	{
		if (PNFNJKJLPIP)
		{
			mChanged = true;
			if (Time.time > AEGDBKPMCFL)
			{
				HFMLDDCPOLH += OMMJNBGHMGL * Time.deltaTime;
				if (HFMLDDCPOLH > FDGHEOECHJB)
				{
					AEGDBKPMCFL = Time.time + BCLLOMEFKGK;
					PHMDNLGMJAN(true);
					HFMLDDCPOLH = MKDPHNHIHNP;
				}
			}
		}
		base.Update();
	}
}
