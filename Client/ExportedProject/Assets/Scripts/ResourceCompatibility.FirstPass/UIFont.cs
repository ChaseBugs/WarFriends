using System.Collections.Generic;
using System.Text;
using UnityEngine;

[ExecuteInEditMode]
public class UIFont : MonoBehaviour
{
	public enum Alignment
	{
		Left,
		Center,
		Right
	}

	public enum SymbolStyle
	{
		None,
		Uncolored,
		Colored
	}

	[HideInInspector]
	[SerializeField]
	private Material mMat;

	[HideInInspector]
	[SerializeField]
	private Rect mUVRect;

	[HideInInspector]
	[SerializeField]
	private BMFont mFont;

	[HideInInspector]
	[SerializeField]
	private int mSpacingX;

	[HideInInspector]
	[SerializeField]
	private int mSpacingY;

	[HideInInspector]
	[SerializeField]
	private float mLineSpacing;

	[HideInInspector]
	[SerializeField]
	private UIAtlas mAtlas;

	[HideInInspector]
	[SerializeField]
	private UIFont mReplacement;

	[HideInInspector]
	[SerializeField]
	private float mPixelSize;

	[HideInInspector]
	[SerializeField]
	private List<BMSymbol> mSymbols;

	[HideInInspector]
	[SerializeField]
	private Font mDynamicFont;

	[HideInInspector]
	[SerializeField]
	private int mDynamicFontSize;

	[HideInInspector]
	[SerializeField]
	private FontStyle mDynamicFontStyle;

	private float mDynamicFontOffset;

	private Dictionary<int, float> mDynamicFontOffsets;

	private UIAtlas.Sprite mSprite;

	private int mPMA;

	private bool mSpriteSet;

	private List<Color> mColors;

	private static CharacterInfo mChar;

	private bool mHooked;

	public BMFont bmFont => null;

	public int texWidth => 0;

	public int texHeight => 0;

	public bool hasSymbols => false;

	public List<BMSymbol> symbols => null;

	public UIAtlas atlas
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

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

	public float pixelSize
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool premultipliedAlpha => false;

	public Texture2D texture => null;

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

	public string spriteName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int horizontalSpacing
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public float lineSpacing
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public int verticalSpacing
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool isValid => false;

	public int size => 0;

	public UIAtlas.Sprite sprite => null;

	public UIFont replacement
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool isDynamic => false;

	public Font dynamicFont
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

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

	public FontStyle dynamicFontStyle
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(FontStyle);
		}
		set
		{
		}
	}

	private Texture dynamicTexture => null;

	private int mAlteredDynamicSize => 0;

	public int GetFontSize(int labelDynamicFontSize)
	{
		return 0;
	}

	private void Trim()
	{
	}

	private bool References(UIFont font)
	{
		return false;
	}

	public static bool CheckIfRelated(UIFont a, UIFont b)
	{
		return false;
	}

	public void MarkAsDirty()
	{
	}

	public bool RecalculateDynamicOffset()
	{
		return false;
	}

	public float RecalculateDynamicOffset(int fontSize)
	{
		return 0f;
	}

	public Vector2 CalculatePrintedSize(string text, bool encoding, SymbolStyle symbolStyle)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector2);
	}

	private static void EndLine(ref StringBuilder s)
	{
	}

	public string GetEndOfLineThatFits(string text, float maxWidth, bool encoding, SymbolStyle symbolStyle)
	{
		return null;
	}

	public string WrapText(string text, float maxWidth, int maxLineCount, bool encoding, SymbolStyle symbolStyle)
	{
		return null;
	}

	public string WrapText(string text, float maxWidth, int maxLineCount, bool encoding)
	{
		return null;
	}

	public string WrapText(string text, float maxWidth, int maxLineCount)
	{
		return null;
	}

	private void Align(BetterList<Vector3> verts, int indexOffset, Alignment alignment, int x, int lineWidth, int printDynamicFontSize)
	{
	}

	private int AlterFontHeight(int designHeight)
	{
		return 0;
	}

	private void HookRebuildEvent()
	{
	}

	public void RequestCharacters(string str, int size)
	{
	}

	public void Print(string text, Color32 color, BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, bool encoding, SymbolStyle symbolStyle, Alignment alignment, int lineWidth, bool premultiply, int printDynamicFontSize)
	{
	}

	private void FontOnTextureRebuilt(Font font)
	{
	}

	public void Clear()
	{
	}

	private BMSymbol GetSymbol(string sequence, bool createIfMissing)
	{
		return null;
	}

	private BMSymbol MatchSymbol(string text, int offset, int textLength)
	{
		return null;
	}

	public void AddSymbol(string sequence, string spriteName)
	{
	}

	public void RemoveSymbol(string sequence)
	{
	}

	public void RenameSymbol(string before, string after)
	{
	}

	public bool UsesSprite(string s)
	{
		return false;
	}

	private void SafeRequestCharactersInTexture(string text, int alteredDynamicSize, FontStyle dynamicFontStyle)
	{
	}

	private char RecodeNonUnicodeCharacters(char c)
	{
		return '\0';
	}
}
