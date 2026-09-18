using System.Runtime.InteropServices;

namespace UnityEngine;

/// <summary>
///   <para>Detail prototype used by the Terrain GameObject.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public sealed class DetailPrototype
{
	private GameObject m_Prototype;

	private Texture2D m_PrototypeTexture;

	private Color m_HealthyColor = new Color(0.2627451f, 83f / 85f, 14f / 85f, 1f);

	private Color m_DryColor = new Color(41f / 51f, 0.7372549f, 0.101960786f, 1f);

	private float m_MinWidth = 1f;

	private float m_MaxWidth = 2f;

	private float m_MinHeight = 1f;

	private float m_MaxHeight = 2f;

	private float m_NoiseSpread = 0.1f;

	private float m_BendFactor = 0.1f;

	private int m_RenderMode = 2;

	private int m_UsePrototypeMesh;

	/// <summary>
	///   <para>GameObject used by the DetailPrototype.</para>
	/// </summary>
	public GameObject prototype
	{
		get
		{
			return m_Prototype;
		}
		set
		{
			m_Prototype = value;
		}
	}

	/// <summary>
	///   <para>Texture used by the DetailPrototype.</para>
	/// </summary>
	public Texture2D prototypeTexture
	{
		get
		{
			return m_PrototypeTexture;
		}
		set
		{
			m_PrototypeTexture = value;
		}
	}

	/// <summary>
	///   <para>Minimum width of the grass billboards (if render mode is GrassBillboard).</para>
	/// </summary>
	public float minWidth
	{
		get
		{
			return m_MinWidth;
		}
		set
		{
			m_MinWidth = value;
		}
	}

	/// <summary>
	///   <para>Maximum width of the grass billboards (if render mode is GrassBillboard).</para>
	/// </summary>
	public float maxWidth
	{
		get
		{
			return m_MaxWidth;
		}
		set
		{
			m_MaxWidth = value;
		}
	}

	/// <summary>
	///   <para>Minimum height of the grass billboards (if render mode is GrassBillboard).</para>
	/// </summary>
	public float minHeight
	{
		get
		{
			return m_MinHeight;
		}
		set
		{
			m_MinHeight = value;
		}
	}

	/// <summary>
	///   <para>Maximum height of the grass billboards (if render mode is GrassBillboard).</para>
	/// </summary>
	public float maxHeight
	{
		get
		{
			return m_MaxHeight;
		}
		set
		{
			m_MaxHeight = value;
		}
	}

	/// <summary>
	///   <para>How spread out is the noise for the DetailPrototype.</para>
	/// </summary>
	public float noiseSpread
	{
		get
		{
			return m_NoiseSpread;
		}
		set
		{
			m_NoiseSpread = value;
		}
	}

	/// <summary>
	///   <para>Bend factor of the detailPrototype.</para>
	/// </summary>
	public float bendFactor
	{
		get
		{
			return m_BendFactor;
		}
		set
		{
			m_BendFactor = value;
		}
	}

	/// <summary>
	///   <para>Color when the DetailPrototypes are "healthy".</para>
	/// </summary>
	public Color healthyColor
	{
		get
		{
			return m_HealthyColor;
		}
		set
		{
			m_HealthyColor = value;
		}
	}

	/// <summary>
	///   <para>Color when the DetailPrototypes are "dry".</para>
	/// </summary>
	public Color dryColor
	{
		get
		{
			return m_DryColor;
		}
		set
		{
			m_DryColor = value;
		}
	}

	/// <summary>
	///   <para>Render mode for the DetailPrototype.</para>
	/// </summary>
	public DetailRenderMode renderMode
	{
		get
		{
			return (DetailRenderMode)m_RenderMode;
		}
		set
		{
			m_RenderMode = (int)value;
		}
	}

	public bool usePrototypeMesh
	{
		get
		{
			return m_UsePrototypeMesh != 0;
		}
		set
		{
			m_UsePrototypeMesh = (value ? 1 : 0);
		}
	}
}
