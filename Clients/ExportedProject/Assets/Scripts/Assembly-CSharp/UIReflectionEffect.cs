using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Reflection effect")]
public class UIReflectionEffect : UISprite
{
	public float animationSpeed = 1f;

	private float mOffset;

	public float maxOffset = 1f;

	public float minOffset = -1f;

	public Vector2 effectScale = Vector2.one;

	public float timeBetweeenAnimations = 0.5f;

	private float mNextAnimTime;

	public bool randomStart;

	private bool mEnabled = true;

	public bool effectEnabled
	{
		get
		{
			return mEnabled;
		}
		set
		{
			mEnabled = value;
			if (!mEnabled)
			{
				mOffset = minOffset;
			}
		}
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, BetterList<Vector2> uvs2)
	{
		Type type = this.type;
		if (type == Type.Sliced)
		{
			SlicedEffect(verts, uvs, cols, uvs2);
		}
		else
		{
			Debug.LogError("Only Sliced is supported now");
		}
	}

	public void SetRandomNextAnimTime()
	{
		mNextAnimTime = Time.time + Random.Range(0f, timeBetweeenAnimations);
		mOffset = minOffset;
	}

	public void StartIn(float time)
	{
		effectEnabled = true;
		timeBetweeenAnimations = float.PositiveInfinity;
		mNextAnimTime = Time.time + time;
		mOffset = minOffset;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		effectEnabled = false;
	}

	public override void Update()
	{
		if (mEnabled)
		{
			mChanged = true;
			if (Time.time > mNextAnimTime)
			{
				mOffset += animationSpeed * Time.deltaTime;
				if (mOffset > maxOffset)
				{
					mNextAnimTime = Time.time + timeBetweeenAnimations;
					effectEnabled = false;
					mOffset = minOffset;
				}
			}
		}
		base.Update();
	}

	protected void SlicedEffect(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, BetterList<Vector2> uvs2)
	{
		if (mPanel != null)
		{
			mPanel.generateUvs2 = true;
		}
		if (mOuterUV == mInnerUV)
		{
			SimpleFill(verts, uvs, cols);
			return;
		}
		Vector2[] array = new Vector2[4];
		Vector2[] array2 = new Vector2[4];
		Vector2[] array3 = new Vector2[4];
		Texture texture = mainTexture;
		ref Vector2 reference = ref array[0];
		reference = Vector2.zero;
		ref Vector2 reference2 = ref array[1];
		reference2 = Vector2.zero;
		ref Vector2 reference3 = ref array[2];
		reference3 = new Vector2(1f, -1f);
		ref Vector2 reference4 = ref array[3];
		reference4 = new Vector2(1f, -1f);
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
			ref Vector2 reference5 = ref array2[0];
			reference5 = new Vector2(mOuterUV.xMin, mOuterUV.yMax);
			ref Vector2 reference6 = ref array2[1];
			reference6 = new Vector2(mInnerUV.xMin, mInnerUV.yMax);
			ref Vector2 reference7 = ref array2[2];
			reference7 = new Vector2(mInnerUV.xMax, mInnerUV.yMin);
			ref Vector2 reference8 = ref array2[3];
			reference8 = new Vector2(mOuterUV.xMax, mOuterUV.yMin);
			ref Vector2 reference9 = ref array3[0];
			reference9 = new Vector2(0f - mOffset, 1f * effectScale.y);
			ref Vector2 reference10 = ref array3[1];
			reference10 = new Vector2(vector2.x * effectScale.x - mOffset, effectScale.y * (1f + vector2.y));
			ref Vector2 reference11 = ref array3[2];
			reference11 = new Vector2((1f - vector3.x) * effectScale.x - mOffset, effectScale.y * -1f * vector3.y);
			ref Vector2 reference12 = ref array3[3];
			reference12 = new Vector2(1f * effectScale.x - mOffset, 0f);
		}
		else
		{
			for (int i = 0; i < 4; i++)
			{
				ref Vector2 reference13 = ref array2[i];
				reference13 = Vector2.zero;
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
				verts.Add(new Vector3(array[num6].x, array[k].y, 0f));
				verts.Add(new Vector3(array[num6].x, array[num7].y, 0f));
				verts.Add(new Vector3(array[j].x, array[num7].y, 0f));
				verts.Add(new Vector3(array[j].x, array[k].y, 0f));
				uvs.Add(new Vector2(array2[num6].x, array2[k].y));
				uvs.Add(new Vector2(array2[num6].x, array2[num7].y));
				uvs.Add(new Vector2(array2[j].x, array2[num7].y));
				uvs.Add(new Vector2(array2[j].x, array2[k].y));
				uvs2.Add(new Vector2(array3[num6].x, array3[k].y));
				uvs2.Add(new Vector2(array3[num6].x, array3[num7].y));
				uvs2.Add(new Vector2(array3[j].x, array3[num7].y));
				uvs2.Add(new Vector2(array3[j].x, array3[k].y));
				cols.Add(item);
				cols.Add(item);
				cols.Add(item);
				cols.Add(item);
			}
		}
	}
}
