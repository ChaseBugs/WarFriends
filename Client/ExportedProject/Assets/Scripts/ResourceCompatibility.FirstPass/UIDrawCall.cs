using UnityEngine;

[ExecuteInEditMode]
public class UIDrawCall : MonoBehaviour
{
	public enum Clipping
	{
		None,
		HardClip,
		AlphaClip,
		SoftClip
	}

	private Transform mTrans;

	private Material mSharedMat;

	private Mesh mMesh0;

	private Mesh mMesh1;

	private MeshFilter mFilter;

	private MeshRenderer mRen;

	private Clipping mClipping;

	private Vector4 mClipRange;

	private Vector2 mClipSoft;

	private Material mClippedMat;

	private Material mDepthMat;

	private int[] mIndices;

	private bool mUseDepth;

	private bool mReset;

	private bool mEven;

	public bool isPremultiplied;

	private BetterList<Color32> mCachedColors;

	private BetterList<Color32> mCachedColorsResult;

	private Mesh mLastmesh;

	private static float f;

	public bool depthPass
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Transform cachedTransform => null;

	public Material material
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int triangles => 0;

	public bool isClipped => false;

	public Clipping clipping
	{
		get
		{
			return default(Clipping);
		}
		set
		{
		}
	}

	public Vector4 clipRange
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector4);
		}
		set
		{
		}
	}

	public Vector2 clipSoftness
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector2);
		}
		set
		{
		}
	}

	private Mesh GetMesh(ref bool rebuildIndices, int vertexCount)
	{
		return null;
	}

	private void UpdateMaterials()
	{
	}

	public void UpdateAlpha(float alpha)
	{
	}

	public void Set(BetterList<Vector3> verts, BetterList<Vector3> norms, BetterList<Vector4> tans, BetterList<Vector2> uvs, BetterList<Color32> cols, float alpha, BetterList<Vector2> uvs2, bool isPremultiplied)
	{
	}

	private void OnWillRenderObject()
	{
	}

	private void OnDestroy()
	{
	}
}
