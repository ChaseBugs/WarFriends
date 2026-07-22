using System;
using UnityEngine;
using tk2dRuntime;

[ExecuteInEditMode]
public class tk2dTextMesh : MonoBehaviour, ISpriteCollectionForceBuild
{
	[Flags]
	private enum UpdateFlags
	{
		UpdateNone = 0,
		UpdateText = 1,
		UpdateColors = 2,
		UpdateBuffers = 4
	}

	private tk2dFontData _fontInst;

	private string _formattedText;

	[SerializeField]
	private tk2dFontData _font;

	[SerializeField]
	private string _text;

	[SerializeField]
	private Color _color;

	[SerializeField]
	private Color _color2;

	[SerializeField]
	private bool _useGradient;

	[SerializeField]
	private int _textureGradient;

	[SerializeField]
	private TextAnchor _anchor;

	[SerializeField]
	private Vector3 _scale;

	[SerializeField]
	private bool _kerning;

	[SerializeField]
	private int _maxChars;

	[SerializeField]
	private bool _inlineStyling;

	[SerializeField]
	private bool _formatting;

	[SerializeField]
	private int _wordWrapWidth;

	[SerializeField]
	private float spacing;

	[SerializeField]
	private float lineSpacing;

	[SerializeField]
	private tk2dTextMeshData data;

	private Vector3[] vertices;

	private Vector2[] uvs;

	private Vector2[] uv2;

	private Color32[] colors;

	private Color32[] untintedColors;

	private UpdateFlags updateFlags;

	private Mesh mesh;

	private MeshFilter meshFilter;

	public string FormattedText => null;

	public tk2dFontData font
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool formatting
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int wordWrapWidth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

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

	public Color color2
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

	public bool useGradient
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public TextAnchor anchor
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(TextAnchor);
		}
		set
		{
		}
	}

	public Vector3 scale
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public bool kerning
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int maxChars
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int textureGradient
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool inlineStyling
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float Spacing
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float LineSpacing
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public int SortingOrder
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private bool useInlineStyling => false;

	private void UpgradeData()
	{
	}

	private static int GetInlineStyleCommandLength(int cmdSymbol)
	{
		return 0;
	}

	public string FormatText(string unformattedString)
	{
		return null;
	}

	private void FormatText()
	{
	}

	private void FormatText(ref string _targetString, string _source)
	{
	}

	private void SetNeedUpdate(UpdateFlags uf)
	{
	}

	private void InitInstance()
	{
	}

	private void Awake()
	{
	}

	protected void OnDestroy()
	{
	}

	public int NumDrawnCharacters()
	{
		return 0;
	}

	public int NumTotalCharacters()
	{
		return 0;
	}

	[Obsolete]
	public Vector2 GetMeshDimensionsForString(string str)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector2);
	}

	public Bounds GetEstimatedMeshBoundsForString(string str)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Bounds);
	}

	public void Init(bool force)
	{
	}

	public void Init()
	{
	}

	public void Commit()
	{
	}

	public void DoNotUse__CommitInternal()
	{
	}

	public void MakePixelPerfect()
	{
	}

	public bool UsesSpriteCollection(tk2dSpriteCollectionData spriteCollection)
	{
		return false;
	}

	private void UpdateMaterial()
	{
	}

	public void ForceBuild()
	{
	}
}
