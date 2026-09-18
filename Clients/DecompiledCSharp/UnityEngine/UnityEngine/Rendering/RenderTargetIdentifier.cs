namespace UnityEngine.Rendering;

/// <summary>
///   <para>Identifies a RenderTexture for a Rendering.CommandBuffer.</para>
/// </summary>
public struct RenderTargetIdentifier
{
	private BuiltinRenderTextureType m_Type;

	private int m_NameID;

	private int m_InstanceID;

	/// <summary>
	///   <para>Creates a render target identifier.</para>
	/// </summary>
	/// <param name="rt">RenderTexture object to use.</param>
	/// <param name="type">Built-in temporary render texture type.</param>
	/// <param name="name">Temporary render texture name.</param>
	/// <param name="nameID">Temporary render texture name (as integer, see Shader.PropertyToID).</param>
	public RenderTargetIdentifier(BuiltinRenderTextureType type)
	{
		m_Type = type;
		m_NameID = -1;
		m_InstanceID = 0;
	}

	/// <summary>
	///   <para>Creates a render target identifier.</para>
	/// </summary>
	/// <param name="rt">RenderTexture object to use.</param>
	/// <param name="type">Built-in temporary render texture type.</param>
	/// <param name="name">Temporary render texture name.</param>
	/// <param name="nameID">Temporary render texture name (as integer, see Shader.PropertyToID).</param>
	public RenderTargetIdentifier(string name)
	{
		m_Type = BuiltinRenderTextureType.None;
		m_NameID = Shader.PropertyToID(name);
		m_InstanceID = 0;
	}

	/// <summary>
	///   <para>Creates a render target identifier.</para>
	/// </summary>
	/// <param name="rt">RenderTexture object to use.</param>
	/// <param name="type">Built-in temporary render texture type.</param>
	/// <param name="name">Temporary render texture name.</param>
	/// <param name="nameID">Temporary render texture name (as integer, see Shader.PropertyToID).</param>
	public RenderTargetIdentifier(int nameID)
	{
		m_Type = BuiltinRenderTextureType.None;
		m_NameID = nameID;
		m_InstanceID = 0;
	}

	/// <summary>
	///   <para>Creates a render target identifier.</para>
	/// </summary>
	/// <param name="rt">RenderTexture object to use.</param>
	/// <param name="type">Built-in temporary render texture type.</param>
	/// <param name="name">Temporary render texture name.</param>
	/// <param name="nameID">Temporary render texture name (as integer, see Shader.PropertyToID).</param>
	public RenderTargetIdentifier(RenderTexture rt)
	{
		m_Type = BuiltinRenderTextureType.None;
		m_NameID = -1;
		m_InstanceID = (rt ? rt.GetInstanceID() : 0);
	}

	public static implicit operator RenderTargetIdentifier(BuiltinRenderTextureType type)
	{
		return new RenderTargetIdentifier(type);
	}

	public static implicit operator RenderTargetIdentifier(string name)
	{
		return new RenderTargetIdentifier(name);
	}

	public static implicit operator RenderTargetIdentifier(int nameID)
	{
		return new RenderTargetIdentifier(nameID);
	}

	public static implicit operator RenderTargetIdentifier(RenderTexture rt)
	{
		return new RenderTargetIdentifier(rt);
	}
}
