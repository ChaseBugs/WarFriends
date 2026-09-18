using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>The material class.</para>
/// </summary>
public class Material : Object
{
	/// <summary>
	///   <para>The shader used by the material.</para>
	/// </summary>
	public extern Shader shader
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The main material's color.</para>
	/// </summary>
	public Color color
	{
		get
		{
			return GetColor("_Color");
		}
		set
		{
			SetColor("_Color", value);
		}
	}

	/// <summary>
	///   <para>The material's texture.</para>
	/// </summary>
	public Texture mainTexture
	{
		get
		{
			return GetTexture("_MainTex");
		}
		set
		{
			SetTexture("_MainTex", value);
		}
	}

	/// <summary>
	///   <para>The texture offset of the main texture.</para>
	/// </summary>
	public Vector2 mainTextureOffset
	{
		get
		{
			return GetTextureOffset("_MainTex");
		}
		set
		{
			SetTextureOffset("_MainTex", value);
		}
	}

	/// <summary>
	///   <para>The texture scale of the main texture.</para>
	/// </summary>
	public Vector2 mainTextureScale
	{
		get
		{
			return GetTextureScale("_MainTex");
		}
		set
		{
			SetTextureScale("_MainTex", value);
		}
	}

	/// <summary>
	///   <para>How many passes are in this material (Read Only).</para>
	/// </summary>
	public extern int passCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Render queue of this material.</para>
	/// </summary>
	public extern int renderQueue
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Additional shader keywords set by this material.</para>
	/// </summary>
	public extern string[] shaderKeywords
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Defines how the material should interact with lightmaps and lightprobes.</para>
	/// </summary>
	public extern MaterialGlobalIlluminationFlags globalIlluminationFlags
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para></para>
	/// </summary>
	/// <param name="contents"></param>
	[Obsolete("Creating materials from shader source string will be removed in the future. Use Shader assets instead.")]
	public Material(string contents)
	{
		Internal_CreateWithString(this, contents);
	}

	/// <summary>
	///   <para>Create a temporary Material.</para>
	/// </summary>
	/// <param name="shader">Create a material with a given Shader.</param>
	/// <param name="source">Create a material by copying all properties from another material.</param>
	public Material(Shader shader)
	{
		Internal_CreateWithShader(this, shader);
	}

	/// <summary>
	///   <para>Create a temporary Material.</para>
	/// </summary>
	/// <param name="shader">Create a material with a given Shader.</param>
	/// <param name="source">Create a material by copying all properties from another material.</param>
	public Material(Material source)
	{
		Internal_CreateWithMaterial(this, source);
	}

	/// <summary>
	///   <para>Set a named color value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="color"></param>
	/// <param name="nameID"></param>
	public void SetColor(string propertyName, Color color)
	{
		SetColor(Shader.PropertyToID(propertyName), color);
	}

	/// <summary>
	///   <para>Set a named color value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="color"></param>
	/// <param name="nameID"></param>
	public void SetColor(int nameID, Color color)
	{
		INTERNAL_CALL_SetColor(this, nameID, ref color);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetColor(Material self, int nameID, ref Color color);

	/// <summary>
	///   <para>Get a named color value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public Color GetColor(string propertyName)
	{
		return GetColor(Shader.PropertyToID(propertyName));
	}

	/// <summary>
	///   <para>Get a named color value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Color GetColor(int nameID);

	/// <summary>
	///   <para>Set a named vector value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="vector"></param>
	/// <param name="nameID"></param>
	public void SetVector(string propertyName, Vector4 vector)
	{
		SetColor(propertyName, new Color(vector.x, vector.y, vector.z, vector.w));
	}

	/// <summary>
	///   <para>Set a named vector value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="vector"></param>
	/// <param name="nameID"></param>
	public void SetVector(int nameID, Vector4 vector)
	{
		SetColor(nameID, new Color(vector.x, vector.y, vector.z, vector.w));
	}

	/// <summary>
	///   <para>Get a named vector value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public Vector4 GetVector(string propertyName)
	{
		Color color = GetColor(propertyName);
		return new Vector4(color.r, color.g, color.b, color.a);
	}

	/// <summary>
	///   <para>Get a named vector value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public Vector4 GetVector(int nameID)
	{
		Color color = GetColor(nameID);
		return new Vector4(color.r, color.g, color.b, color.a);
	}

	/// <summary>
	///   <para>Set a named texture.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="texture"></param>
	/// <param name="nameID"></param>
	public void SetTexture(string propertyName, Texture texture)
	{
		SetTexture(Shader.PropertyToID(propertyName), texture);
	}

	/// <summary>
	///   <para>Set a named texture.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="texture"></param>
	/// <param name="nameID"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetTexture(int nameID, Texture texture);

	/// <summary>
	///   <para>Get a named texture.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public Texture GetTexture(string propertyName)
	{
		return GetTexture(Shader.PropertyToID(propertyName));
	}

	/// <summary>
	///   <para>Get a named texture.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Texture GetTexture(int nameID);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_GetTextureOffset(Material mat, string name, out Vector2 output);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_GetTextureScale(Material mat, string name, out Vector2 output);

	/// <summary>
	///   <para>Sets the placement offset of texture propertyName.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="offset"></param>
	public void SetTextureOffset(string propertyName, Vector2 offset)
	{
		INTERNAL_CALL_SetTextureOffset(this, propertyName, ref offset);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetTextureOffset(Material self, string propertyName, ref Vector2 offset);

	/// <summary>
	///   <para>Gets the placement offset of texture propertyName.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	public Vector2 GetTextureOffset(string propertyName)
	{
		Internal_GetTextureOffset(this, propertyName, out var output);
		return output;
	}

	/// <summary>
	///   <para>Sets the placement scale of texture propertyName.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="scale"></param>
	public void SetTextureScale(string propertyName, Vector2 scale)
	{
		INTERNAL_CALL_SetTextureScale(this, propertyName, ref scale);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetTextureScale(Material self, string propertyName, ref Vector2 scale);

	/// <summary>
	///   <para>Gets the placement scale of texture propertyName.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	public Vector2 GetTextureScale(string propertyName)
	{
		Internal_GetTextureScale(this, propertyName, out var output);
		return output;
	}

	/// <summary>
	///   <para>Set a named matrix for the shader.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="matrix"></param>
	/// <param name="nameID"></param>
	public void SetMatrix(string propertyName, Matrix4x4 matrix)
	{
		SetMatrix(Shader.PropertyToID(propertyName), matrix);
	}

	/// <summary>
	///   <para>Set a named matrix for the shader.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="matrix"></param>
	/// <param name="nameID"></param>
	public void SetMatrix(int nameID, Matrix4x4 matrix)
	{
		INTERNAL_CALL_SetMatrix(this, nameID, ref matrix);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetMatrix(Material self, int nameID, ref Matrix4x4 matrix);

	/// <summary>
	///   <para>Get a named matrix value from the shader.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public Matrix4x4 GetMatrix(string propertyName)
	{
		return GetMatrix(Shader.PropertyToID(propertyName));
	}

	/// <summary>
	///   <para>Get a named matrix value from the shader.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Matrix4x4 GetMatrix(int nameID);

	/// <summary>
	///   <para>Set a named float value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="value"></param>
	/// <param name="nameID"></param>
	public void SetFloat(string propertyName, float value)
	{
		SetFloat(Shader.PropertyToID(propertyName), value);
	}

	/// <summary>
	///   <para>Set a named float value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="value"></param>
	/// <param name="nameID"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetFloat(int nameID, float value);

	/// <summary>
	///   <para>Get a named float value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public float GetFloat(string propertyName)
	{
		return GetFloat(Shader.PropertyToID(propertyName));
	}

	/// <summary>
	///   <para>Get a named float value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern float GetFloat(int nameID);

	/// <summary>
	///   <para>Set a named integer value.
	///
	/// When setting values on materials using the Standard Shader, you should be aware that you may need to use EnableKeyword to enable features of the shader that were not previously in use. For more detail, read wiki:
	/// MaterialsAccessingViaScript|Accessing Materials via Script.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="value"></param>
	/// <param name="nameID"></param>
	public void SetInt(string propertyName, int value)
	{
		SetFloat(propertyName, value);
	}

	/// <summary>
	///   <para>Set a named integer value.
	///
	/// When setting values on materials using the Standard Shader, you should be aware that you may need to use EnableKeyword to enable features of the shader that were not previously in use. For more detail, read wiki:
	/// MaterialsAccessingViaScript|Accessing Materials via Script.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="value"></param>
	/// <param name="nameID"></param>
	public void SetInt(int nameID, int value)
	{
		SetFloat(nameID, value);
	}

	/// <summary>
	///   <para>Get a named integer value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public int GetInt(string propertyName)
	{
		return (int)GetFloat(propertyName);
	}

	/// <summary>
	///   <para>Get a named integer value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public int GetInt(int nameID)
	{
		return (int)GetFloat(nameID);
	}

	/// <summary>
	///   <para>Set a ComputeBuffer value.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="buffer"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetBuffer(string propertyName, ComputeBuffer buffer);

	/// <summary>
	///   <para>Checks if material's shader has a property of a given name.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	public bool HasProperty(string propertyName)
	{
		return HasProperty(Shader.PropertyToID(propertyName));
	}

	/// <summary>
	///   <para>Checks if material's shader has a property of a given name.</para>
	/// </summary>
	/// <param name="propertyName"></param>
	/// <param name="nameID"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool HasProperty(int nameID);

	/// <summary>
	///   <para>Get the value of material's shader tag.</para>
	/// </summary>
	/// <param name="tag"></param>
	/// <param name="searchFallbacks"></param>
	/// <param name="defaultValue"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern string GetTag(string tag, bool searchFallbacks, [DefaultValue("\"\"")] string defaultValue);

	/// <summary>
	///   <para>Get the value of material's shader tag.</para>
	/// </summary>
	/// <param name="tag"></param>
	/// <param name="searchFallbacks"></param>
	/// <param name="defaultValue"></param>
	[ExcludeFromDocs]
	public string GetTag(string tag, bool searchFallbacks)
	{
		string empty = string.Empty;
		return GetTag(tag, searchFallbacks, empty);
	}

	/// <summary>
	///   <para>Sets an override tag/value on the material.</para>
	/// </summary>
	/// <param name="tag">Name of the tag to set.</param>
	/// <param name="val">Name of the value to set. Empty string to clear the override flag.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetOverrideTag(string tag, string val);

	/// <summary>
	///   <para>Interpolate properties between two materials.</para>
	/// </summary>
	/// <param name="start"></param>
	/// <param name="end"></param>
	/// <param name="t"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Lerp(Material start, Material end, float t);

	/// <summary>
	///   <para>Activate the given pass for rendering.</para>
	/// </summary>
	/// <param name="pass">Shader pass number to setup.</param>
	/// <returns>
	///   <para>If false is returned, no rendering should be done.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool SetPass(int pass);

	[Obsolete("Creating materials from shader source string will be removed in the future. Use Shader assets instead.")]
	public static Material Create(string scriptContents)
	{
		return new Material(scriptContents);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_CreateWithString([Writable] Material mono, string contents);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_CreateWithShader([Writable] Material mono, Shader shader);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_CreateWithMaterial([Writable] Material mono, Material source);

	/// <summary>
	///   <para>Copy properties from other material into this material.</para>
	/// </summary>
	/// <param name="mat"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void CopyPropertiesFromMaterial(Material mat);

	/// <summary>
	///   <para>Set a shader keyword that is enabled by this material.</para>
	/// </summary>
	/// <param name="keyword"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void EnableKeyword(string keyword);

	/// <summary>
	///   <para>Unset a shader keyword.</para>
	/// </summary>
	/// <param name="keyword"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void DisableKeyword(string keyword);

	/// <summary>
	///   <para>Is the shader keyword enabled on this material?</para>
	/// </summary>
	/// <param name="keyword"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern bool IsKeywordEnabled(string keyword);
}
