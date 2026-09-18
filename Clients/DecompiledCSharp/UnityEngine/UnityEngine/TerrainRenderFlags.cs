namespace UnityEngine;

/// <summary>
///   <para>Enum provding terrain rendering options.</para>
/// </summary>
public enum TerrainRenderFlags
{
	/// <summary>
	///   <para>Render heightmap.</para>
	/// </summary>
	heightmap = 1,
	/// <summary>
	///   <para>Render trees.</para>
	/// </summary>
	trees = 2,
	/// <summary>
	///   <para>Render terrain details.</para>
	/// </summary>
	details = 4,
	/// <summary>
	///   <para>Render all options.</para>
	/// </summary>
	all = 7
}
