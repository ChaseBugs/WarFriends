using UnityEngine;

[ExecuteInEditMode]
public class myFilledSprite : tk2dSprite
{
	public enum Direction
	{
		Vertical,
		Horizontal
	}

	private float actualFract;

	protected Vector2[] meshUVS;

	[SerializeField]
	private bool mInverse;

	[SerializeField]
	private Direction mDirection;

	public float fillFract
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool inverse
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Direction direction
	{
		get
		{
			return default(Direction);
		}
		set
		{
		}
	}

	public override void Build()
	{
	}

	protected override void UpdateGeometry()
	{
	}

	protected override void UpdateVertices()
	{
	}

	protected void SetPositions()
	{
	}

	protected void UpdateVerticesImpl_()
	{
	}

	protected void UpdateGeometryImpl_()
	{
	}
}
