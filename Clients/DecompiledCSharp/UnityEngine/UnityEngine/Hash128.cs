using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Represent the hash value.</para>
/// </summary>
public struct Hash128
{
	private uint m_u32_0;

	private uint m_u32_1;

	private uint m_u32_2;

	private uint m_u32_3;

	/// <summary>
	///   <para>Get if the hash value is valid or not. (Read Only)</para>
	/// </summary>
	public bool isValid => m_u32_0 != 0 || m_u32_1 != 0 || m_u32_2 != 0 || m_u32_3 != 0;

	/// <summary>
	///   <para>Construct the Hash128.</para>
	/// </summary>
	/// <param name="u32_0"></param>
	/// <param name="u32_1"></param>
	/// <param name="u32_2"></param>
	/// <param name="u32_3"></param>
	public Hash128(uint u32_0, uint u32_1, uint u32_2, uint u32_3)
	{
		m_u32_0 = u32_0;
		m_u32_1 = u32_1;
		m_u32_2 = u32_2;
		m_u32_3 = u32_3;
	}

	/// <summary>
	///   <para>Convert Hash128 to string.</para>
	/// </summary>
	public override string ToString()
	{
		return Internal_Hash128ToString(m_u32_0, m_u32_1, m_u32_2, m_u32_3);
	}

	/// <summary>
	///   <para>Convert the input string to Hash128.</para>
	/// </summary>
	/// <param name="hashString"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern Hash128 Parse(string hashString);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern string Internal_Hash128ToString(uint d0, uint d1, uint d2, uint d3);
}
