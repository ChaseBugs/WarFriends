using UnityEngine;

[ExecuteInEditMode]
public class TextMeshWithStroke : Core_BaseScript
{
	[SerializeField]
	private TextMesh[] stroke;

	public float strokeSize;

	public TextMesh mainText;

	[SerializeField]
	private Color mColor = Color.white;

	public Color strokeColor = Color.black;

	[SerializeField]
	private string mText;

	private bool mIsHiding;

	public string text
	{
		get
		{
			return mainText.text;
		}
		set
		{
			mText = value;
			if (mainText != null)
			{
				mainText.text = mText;
			}
			for (int i = 0; i < stroke.Length; i++)
			{
				TextMesh textMesh = stroke[i];
				if (textMesh != null)
				{
					textMesh.text = mText;
				}
			}
		}
	}

	public Color color
	{
		get
		{
			return mainText.color;
		}
		set
		{
			mColor = value;
			mainText.color = mColor;
		}
	}

	public float alpha
	{
		get
		{
			return mainText.color.a;
		}
		set
		{
			Color color = mainText.color;
			color.a = value;
			mainText.color = color;
			for (int i = 0; i < stroke.Length; i++)
			{
				TextMesh textMesh = stroke[i];
				Color color2 = textMesh.color;
				color2.a = color.a;
				textMesh.color = color2;
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (Application.isPlaying)
		{
			GenerateOutline();
		}
	}

	protected void Update()
	{
		if (!Application.isPlaying)
		{
			GenerateOutline();
			text = mText;
			color = mColor;
		}
	}

	private void GenerateOutline()
	{
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 2 != 0) ? 1f : (-1f));
			float num2 = ((i % 2 != 0) ? 1f : (-1f));
			num *= strokeSize;
			num2 *= strokeSize;
			textMesh.color = Color.black;
			textMesh.text = mainText.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 0.01f);
		}
	}
}
