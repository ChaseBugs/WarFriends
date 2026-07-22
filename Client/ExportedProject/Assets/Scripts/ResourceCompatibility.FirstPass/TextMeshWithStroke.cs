using UnityEngine;

[ExecuteInEditMode]
public class TextMeshWithStroke : Core_BaseScript
{
	[SerializeField]
	private TextMesh[] stroke;

	public float strokeSize;

	public TextMesh mainText;

	[SerializeField]
	private Color mColor;

	public Color strokeColor;

	[SerializeField]
	private string mText;

	private bool mIsHiding;

	public string text
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Color color
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Color);
		}
		set
		{
		}
	}

	public float alpha
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	protected override void Awake()
	{
	}

	protected void Update()
	{
	}

	private void GenerateOutline()
	{
	}
}
