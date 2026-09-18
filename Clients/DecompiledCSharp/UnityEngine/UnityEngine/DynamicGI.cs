using System;
using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Allows to control the dynamic Global Illumination.</para>
/// </summary>
public sealed class DynamicGI
{
	/// <summary>
	///   <para>Allows for scaling the contribution coming from realtime &amp; static  lightmaps.</para>
	/// </summary>
	public static extern float indirectScale
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Threshold for limiting updates of realtime GI.</para>
	/// </summary>
	public static extern float updateThreshold
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>When enabled, new dynamic Global Illumination output is shown in each frame.</para>
	/// </summary>
	public static extern bool synchronousMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public static void SetEmissive(Renderer renderer, Color color)
	{
		INTERNAL_CALL_SetEmissive(renderer, ref color);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_SetEmissive(Renderer renderer, ref Color color);

	/// <summary>
	///   <para>Schedules an update of the albedo and emissive textures of a system that contains the renderer or the terrain.</para>
	/// </summary>
	/// <param name="renderer">The Renderer to use when searching for a system to update.</param>
	/// <param name="terrain">The Terrain to use when searching for systems to update.</param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="width"></param>
	/// <param name="height"></param>
	public static void UpdateMaterials(Renderer renderer)
	{
		UpdateMaterialsForRenderer(renderer);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern void UpdateMaterialsForRenderer(Renderer renderer);

	/// <summary>
	///   <para>Schedules an update of the albedo and emissive textures of a system that contains the renderer or the terrain.</para>
	/// </summary>
	/// <param name="renderer">The Renderer to use when searching for a system to update.</param>
	/// <param name="terrain">The Terrain to use when searching for systems to update.</param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="width"></param>
	/// <param name="height"></param>
	public static void UpdateMaterials(Terrain terrain)
	{
		if (terrain == null)
		{
			throw new ArgumentNullException("terrain");
		}
		if (terrain.terrainData == null)
		{
			throw new ArgumentException("Invalid terrainData.");
		}
		UpdateMaterialsForTerrain(terrain, new Rect(0f, 0f, 1f, 1f));
	}

	/// <summary>
	///   <para>Schedules an update of the albedo and emissive textures of a system that contains the renderer or the terrain.</para>
	/// </summary>
	/// <param name="renderer">The Renderer to use when searching for a system to update.</param>
	/// <param name="terrain">The Terrain to use when searching for systems to update.</param>
	/// <param name="x"></param>
	/// <param name="y"></param>
	/// <param name="width"></param>
	/// <param name="height"></param>
	public static void UpdateMaterials(Terrain terrain, int x, int y, int width, int height)
	{
		if (terrain == null)
		{
			throw new ArgumentNullException("terrain");
		}
		if (terrain.terrainData == null)
		{
			throw new ArgumentException("Invalid terrainData.");
		}
		float num = terrain.terrainData.alphamapWidth;
		float num2 = terrain.terrainData.alphamapHeight;
		UpdateMaterialsForTerrain(terrain, new Rect((float)x / num, (float)y / num2, (float)width / num, (float)height / num2));
	}

	internal static void UpdateMaterialsForTerrain(Terrain terrain, Rect uvBounds)
	{
		INTERNAL_CALL_UpdateMaterialsForTerrain(terrain, ref uvBounds);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_UpdateMaterialsForTerrain(Terrain terrain, ref Rect uvBounds);

	/// <summary>
	///   <para>Schedules an update of the environment texture.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void UpdateEnvironment();
}
