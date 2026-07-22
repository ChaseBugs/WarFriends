using UnityEngine;

[ExecuteInEditMode]
public class UITexture : UIWidget
{
	[HideInInspector]
	[SerializeField]
	private Rect mRect;

	[HideInInspector]
	[SerializeField]
	private Shader mShader;

	[HideInInspector]
	[SerializeField]
	private Texture mTexture;

	private Material mDynamicMat;

	private bool mCreatingMat;

	private int mPMA;

	public Rect uvRect
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Rect);
		}
		set
		{
		}
	}

	public Shader shader
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool hasDynamicMaterial => false;

	public override bool keepMaterial => false;

	public override Material material
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool premultipliedAlpha => false;

	public override Texture mainTexture
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void OnDestroy()
	{
	}

	public override void MakePixelPerfect()
	{
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, BetterList<Vector2> uvs2)
	{
	}
}
