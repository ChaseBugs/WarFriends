using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

namespace UnityEngine;

/// <summary>
///   <para>ShaderVariantCollection records which shader variants are actually used in each shader.</para>
/// </summary>
public sealed class ShaderVariantCollection : Object
{
	/// <summary>
	///   <para>Identifies a specific variant of a shader.</para>
	/// </summary>
	public struct ShaderVariant
	{
		/// <summary>
		///   <para>Shader to use in this variant.</para>
		/// </summary>
		public Shader shader;

		/// <summary>
		///   <para>Pass type to use in this variant.</para>
		/// </summary>
		public PassType passType;

		/// <summary>
		///   <para>Array of shader keywords to use in this variant.</para>
		/// </summary>
		public string[] keywords;

		/// <summary>
		///   <para>Creates a ShaderVariant structure.</para>
		/// </summary>
		/// <param name="shader"></param>
		/// <param name="passType"></param>
		/// <param name="keywords"></param>
		public ShaderVariant(Shader shader, PassType passType, params string[] keywords)
		{
			this.shader = shader;
			this.passType = passType;
			this.keywords = keywords;
			Internal_CheckVariant(shader, passType, keywords);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		private static extern void Internal_CheckVariant(Shader shader, PassType passType, string[] keywords);
	}

	/// <summary>
	///   <para>Number of shaders in this collection (Read Only).</para>
	/// </summary>
	public extern int shaderCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Number of total varians in this collection (Read Only).</para>
	/// </summary>
	public extern int variantCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Is this ShaderVariantCollection already warmed up? (Read Only)</para>
	/// </summary>
	public extern bool isWarmedUp
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Create a new empty shader variant collection.</para>
	/// </summary>
	public ShaderVariantCollection()
	{
		Internal_Create(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_Create([Writable] ShaderVariantCollection mono);

	public bool Add(ShaderVariant variant)
	{
		return AddInternal(variant.shader, variant.passType, variant.keywords);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern bool AddInternal(Shader shader, PassType passType, string[] keywords);

	public bool Remove(ShaderVariant variant)
	{
		return RemoveInternal(variant.shader, variant.passType, variant.keywords);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern bool RemoveInternal(Shader shader, PassType passType, string[] keywords);

	public bool Contains(ShaderVariant variant)
	{
		return ContainsInternal(variant.shader, variant.passType, variant.keywords);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern bool ContainsInternal(Shader shader, PassType passType, string[] keywords);

	/// <summary>
	///   <para>Remove all shader variants from the collection.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Clear();

	/// <summary>
	///   <para>Fully load shaders in ShaderVariantCollection.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void WarmUp();
}
