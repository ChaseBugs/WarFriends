using UnityEngine;

[ExecuteInEditMode]
public class UILabel : UIWidget
{
	public enum Effect
	{
		None,
		Shadow,
		Outline
	}

	[HideInInspector]
	[SerializeField]
	private UIFont mFont;

	[HideInInspector]
	[SerializeField]
	private string mText;

	[HideInInspector]
	[SerializeField]
	private int mMaxLineWidth;

	[HideInInspector]
	[SerializeField]
	private bool mEncoding;

	[HideInInspector]
	[SerializeField]
	private int mMaxLineCount;

	[HideInInspector]
	[SerializeField]
	private bool mPassword;

	[HideInInspector]
	[SerializeField]
	private bool mShowLastChar;

	[HideInInspector]
	[SerializeField]
	private Effect mEffectStyle;

	[HideInInspector]
	[SerializeField]
	private Color mEffectColor;

	[HideInInspector]
	[SerializeField]
	private UIFont.SymbolStyle mSymbols;

	[HideInInspector]
	[SerializeField]
	private Vector2 mEffectDistance;

	[HideInInspector]
	[SerializeField]
	private bool mShrinkToFit;

	[HideInInspector]
	[SerializeField]
	private bool useLocalization;

	[HideInInspector]
	[SerializeField]
	private bool mRescaleLocalization;

	[HideInInspector]
	[SerializeField]
	private float mDefaultScale;

	[HideInInspector]
	[SerializeField]
	private float mMinimalScale;

	[HideInInspector]
	[SerializeField]
	private int mRescaleWidth;

	[HideInInspector]
	[SerializeField]
	private int mDynamicFontSize;

	[HideInInspector]
	[SerializeField]
	private float mLineWidth;

	[HideInInspector]
	[SerializeField]
	private bool mMultiline;

	private bool mShouldBeProcessed;

	private string mProcessedText;

	private Vector3 mLastScale;

	private string mLastText;

	private int mLastWidth;

	private bool mLastEncoding;

	private int mLastCount;

	private bool mLastPass;

	private bool mLastShow;

	private Effect mLastEffect;

	private Vector2 mSize;

	private bool mPremultiply;

	private bool hasChanged
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public UIFont font
	{
		get
		{
			return null;
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

	public bool supportEncoding
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public UIFont.SymbolStyle symbolStyle
	{
		get
		{
			return default(UIFont.SymbolStyle);
		}
		set
		{
		}
	}

	public int lineWidth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool multiLine
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int maxLineCount
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool password
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool showLastPasswordChar
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Effect effectStyle
	{
		get
		{
			return default(Effect);
		}
		set
		{
		}
	}

	public Color effectColor
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

	public Vector2 effectDistance
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

	public bool shrinkToFit
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool localizeText
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool rescaleAfterLocalization
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float defaultScale
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float minimalScale
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public int rescaleWidth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public string processedText => null;

	public override Material material => null;

	public override Vector2 relativeSize => default(Vector2);

	public int dynamicFontSize
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override bool isPremultiplied => false;

	protected override void OnStart()
	{
	}

	public override void MarkAsChanged()
	{
	}

	public Vector2 getSizeForString(string txt)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector2);
	}

	private void ProcessText()
	{
	}

	private void RescaleAfterTranslation()
	{
	}

	public override void MakePixelPerfect()
	{
	}

	private void ApplyShadow(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, int start, int end, float x, float y)
	{
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, BetterList<Vector2> uvs2)
	{
	}
}
