using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

namespace UnityEngine;

/// <summary>
///   <para>The Terrain component renders the terrain.</para>
/// </summary>
public sealed class Terrain : Behaviour
{
	/// <summary>
	///   <para>The type of the material used to render a terrain object. Could be one of the built-in types or custom.</para>
	/// </summary>
	public enum MaterialType
	{
		/// <summary>
		///   <para>A built-in material that uses the standard physically-based lighting model. Inputs supported: smoothness, metallic / specular, normal.</para>
		/// </summary>
		BuiltInStandard,
		/// <summary>
		///   <para>A built-in material that uses the legacy Lambert (diffuse) lighting model and has optional normal map support.</para>
		/// </summary>
		BuiltInLegacyDiffuse,
		/// <summary>
		///   <para>A built-in material that uses the legacy BlinnPhong (specular) lighting model and has optional normal map support.</para>
		/// </summary>
		BuiltInLegacySpecular,
		/// <summary>
		///   <para>Use a custom material given by Terrain.materialTemplate.</para>
		/// </summary>
		Custom
	}

	public extern TerrainRenderFlags editorRenderFlags
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The Terrain Data that stores heightmaps, terrain textures, detail meshes and trees.</para>
	/// </summary>
	public extern TerrainData terrainData
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The maximum distance at which trees are rendered.</para>
	/// </summary>
	public extern float treeDistance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Distance from the camera where trees will be rendered as billboards only.</para>
	/// </summary>
	public extern float treeBillboardDistance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Total distance delta that trees will use to transition from billboard orientation to mesh orientation.</para>
	/// </summary>
	public extern float treeCrossFadeLength
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Maximum number of trees rendered at full LOD.</para>
	/// </summary>
	public extern int treeMaximumFullLODCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Detail objects will be displayed up to this distance.</para>
	/// </summary>
	public extern float detailObjectDistance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Density of detail objects.</para>
	/// </summary>
	public extern float detailObjectDensity
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Collect Detail patches from memory.</para>
	/// </summary>
	public extern bool collectDetailPatches
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>An approximation of how many pixels the terrain will pop in the worst case when switching lod.</para>
	/// </summary>
	public extern float heightmapPixelError
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Lets you essentially lower the heightmap resolution used for rendering.</para>
	/// </summary>
	public extern int heightmapMaximumLOD
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Heightmap patches beyond basemap distance will use a precomputed low res basemap.</para>
	/// </summary>
	public extern float basemapDistance
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("use basemapDistance", true)]
	public float splatmapDistance
	{
		get
		{
			return basemapDistance;
		}
		set
		{
			basemapDistance = value;
		}
	}

	/// <summary>
	///   <para>The index of the baked lightmap applied to this terrain.</para>
	/// </summary>
	public extern int lightmapIndex
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The index of the realtime lightmap applied to this terrain.</para>
	/// </summary>
	public extern int realtimeLightmapIndex
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The UV scale &amp; offset used for a baked lightmap.</para>
	/// </summary>
	public Vector4 lightmapScaleOffset
	{
		get
		{
			INTERNAL_get_lightmapScaleOffset(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_lightmapScaleOffset(ref value);
		}
	}

	/// <summary>
	///   <para>The UV scale &amp; offset used for a realtime lightmap.</para>
	/// </summary>
	public Vector4 realtimeLightmapScaleOffset
	{
		get
		{
			INTERNAL_get_realtimeLightmapScaleOffset(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_realtimeLightmapScaleOffset(ref value);
		}
	}

	/// <summary>
	///   <para>Should terrain cast shadows?.</para>
	/// </summary>
	public extern bool castShadows
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>How reflection probes are used for terrain. See Rendering.ReflectionProbeUsage.</para>
	/// </summary>
	public extern ReflectionProbeUsage reflectionProbeUsage
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The type of the material used to render the terrain. Could be one of the built-in types or custom. See Terrain.MaterialType.</para>
	/// </summary>
	public extern MaterialType materialType
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The custom material used to render the terrain.</para>
	/// </summary>
	public extern Material materialTemplate
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The specular color of the terrain.</para>
	/// </summary>
	public Color legacySpecular
	{
		get
		{
			INTERNAL_get_legacySpecular(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_legacySpecular(ref value);
		}
	}

	/// <summary>
	///   <para>The shininess value of the terrain.</para>
	/// </summary>
	public extern float legacyShininess
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Specify if terrain heightmap should be drawn.</para>
	/// </summary>
	public extern bool drawHeightmap
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Specify if terrain trees and details should be drawn.</para>
	/// </summary>
	public extern bool drawTreesAndFoliage
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The active terrain. This is a convenience function to get to the main terrain in the scene.</para>
	/// </summary>
	public static extern Terrain activeTerrain
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The active terrains in the scene.</para>
	/// </summary>
	public static extern Terrain[] activeTerrains
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_lightmapScaleOffset(out Vector4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_lightmapScaleOffset(ref Vector4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_realtimeLightmapScaleOffset(out Vector4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_realtimeLightmapScaleOffset(ref Vector4 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void GetClosestReflectionProbesInternal(object result);

	public void GetClosestReflectionProbes(List<ReflectionProbeBlendInfo> result)
	{
		GetClosestReflectionProbesInternal(result);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_legacySpecular(out Color value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_legacySpecular(ref Color value);

	/// <summary>
	///   <para>Samples the height at the given position defined in world space, relative to the terrain space.</para>
	/// </summary>
	/// <param name="worldPosition"></param>
	public float SampleHeight(Vector3 worldPosition)
	{
		return INTERNAL_CALL_SampleHeight(this, ref worldPosition);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern float INTERNAL_CALL_SampleHeight(Terrain self, ref Vector3 worldPosition);

	/// <summary>
	///   <para>Update the terrain's LOD and vegetation information after making changes with TerrainData.SetHeightsDelayLOD.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void ApplyDelayedHeightmapModification();

	/// <summary>
	///   <para>Adds a tree instance to the terrain.</para>
	/// </summary>
	/// <param name="instance"></param>
	public void AddTreeInstance(TreeInstance instance)
	{
		INTERNAL_CALL_AddTreeInstance(this, ref instance);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_AddTreeInstance(Terrain self, ref TreeInstance instance);

	/// <summary>
	///   <para>Lets you setup the connection between neighboring Terrains.</para>
	/// </summary>
	/// <param name="left"></param>
	/// <param name="top"></param>
	/// <param name="right"></param>
	/// <param name="bottom"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetNeighbors(Terrain left, Terrain top, Terrain right, Terrain bottom);

	/// <summary>
	///   <para>Get the position of the terrain.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern Vector3 GetPosition();

	/// <summary>
	///   <para>Flushes any change done in the terrain so it takes effect.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Flush();

	internal void RemoveTrees(Vector2 position, float radius, int prototypeIndex)
	{
		INTERNAL_CALL_RemoveTrees(this, ref position, radius, prototypeIndex);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_RemoveTrees(Terrain self, ref Vector2 position, float radius, int prototypeIndex);

	/// <summary>
	///   <para>Creates a Terrain including collider from TerrainData.</para>
	/// </summary>
	/// <param name="assignTerrain"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern GameObject CreateTerrainGameObject(TerrainData assignTerrain);
}
