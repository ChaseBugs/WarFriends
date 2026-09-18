using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>A class that allows creating or modifying meshes from scripts.</para>
/// </summary>
public sealed class Mesh : Object
{
	/// <summary>
	///   <para>Returns state of the Read/Write Enabled checkbox when model was imported.</para>
	/// </summary>
	public extern bool isReadable
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal extern bool canAccess
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns a copy of the vertex positions or assigns a new vertex positions array.</para>
	/// </summary>
	public extern Vector3[] vertices
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The normals of the mesh.</para>
	/// </summary>
	public extern Vector3[] normals
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The tangents of the mesh.</para>
	/// </summary>
	public extern Vector4[] tangents
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The base texture coordinates of the mesh.</para>
	/// </summary>
	public extern Vector2[] uv
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The second texture coordinate set of the mesh, if present.</para>
	/// </summary>
	public extern Vector2[] uv2
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The third texture coordinate set of the mesh, if present.</para>
	/// </summary>
	public extern Vector2[] uv3
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The fourth texture coordinate set of the mesh, if present.</para>
	/// </summary>
	public extern Vector2[] uv4
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The bounding volume of the mesh.</para>
	/// </summary>
	public Bounds bounds
	{
		get
		{
			INTERNAL_get_bounds(out var value);
			return value;
		}
		set
		{
			INTERNAL_set_bounds(ref value);
		}
	}

	/// <summary>
	///   <para>Vertex colors of the mesh.</para>
	/// </summary>
	public extern Color[] colors
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Vertex colors of the mesh.</para>
	/// </summary>
	public extern Color32[] colors32
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>An array containing all triangles in the mesh.</para>
	/// </summary>
	public extern int[] triangles
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns the number of vertices in the mesh (Read Only).</para>
	/// </summary>
	public extern int vertexCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The number of submeshes. Every material has a separate triangle list.</para>
	/// </summary>
	public extern int subMeshCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The bone weights of each vertex.</para>
	/// </summary>
	public extern BoneWeight[] boneWeights
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The bind poses. The bind pose at each index refers to the bone with the same index.</para>
	/// </summary>
	public extern Matrix4x4[] bindposes
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns BlendShape count on this mesh.</para>
	/// </summary>
	public extern int blendShapeCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Creates an empty mesh.</para>
	/// </summary>
	public Mesh()
	{
		Internal_Create(this);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_Create([Writable] Mesh mono);

	/// <summary>
	///   <para>Clears all vertex data and all triangle indices.</para>
	/// </summary>
	/// <param name="keepVertexLayout"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Clear([DefaultValue("true")] bool keepVertexLayout);

	[ExcludeFromDocs]
	public void Clear()
	{
		bool keepVertexLayout = true;
		Clear(keepVertexLayout);
	}

	public void SetVertices(List<Vector3> inVertices)
	{
		SetVerticesInternal(inVertices);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetVerticesInternal(object vertices);

	public void SetNormals(List<Vector3> inNormals)
	{
		SetNormalsInternal(inNormals);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetNormalsInternal(object normals);

	public void SetTangents(List<Vector4> inTangents)
	{
		SetTangentsInternal(inTangents);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetTangentsInternal(object tangents);

	public void SetUVs(int channel, List<Vector2> uvs)
	{
		SetUVInternal(uvs, channel, 2);
	}

	public void SetUVs(int channel, List<Vector3> uvs)
	{
		SetUVInternal(uvs, channel, 3);
	}

	public void SetUVs(int channel, List<Vector4> uvs)
	{
		SetUVInternal(uvs, channel, 4);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetUVInternal(object uvs, int channel, int dim);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_get_bounds(out Bounds value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void INTERNAL_set_bounds(ref Bounds value);

	public void SetColors(List<Color> inColors)
	{
		SetColorsInternal(inColors);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetColorsInternal(object colors);

	public void SetColors(List<Color32> inColors)
	{
		SetColors32Internal(inColors);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetColors32Internal(object colors);

	/// <summary>
	///   <para>Recalculate the bounding volume of the mesh from the vertices.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void RecalculateBounds();

	/// <summary>
	///   <para>Recalculates the normals of the mesh from the triangles and vertices.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void RecalculateNormals();

	/// <summary>
	///   <para>Optimizes the mesh for display.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Optimize();

	/// <summary>
	///   <para>Returns the triangle list for the submesh.</para>
	/// </summary>
	/// <param name="submesh"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern int[] GetTriangles(int submesh);

	/// <summary>
	///   <para>Sets the triangle list for the submesh.</para>
	/// </summary>
	/// <param name="inTriangles"></param>
	/// <param name="submesh"></param>
	/// <param name="triangles"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetTriangles(int[] triangles, int submesh);

	public void SetTriangles(List<int> inTriangles, int submesh)
	{
		SetTrianglesInternal(inTriangles, submesh);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void SetTrianglesInternal(object triangles, int submesh);

	/// <summary>
	///   <para>Returns the index buffer for the submesh.</para>
	/// </summary>
	/// <param name="submesh"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern int[] GetIndices(int submesh);

	/// <summary>
	///   <para>Sets the index buffer for the submesh.</para>
	/// </summary>
	/// <param name="indices"></param>
	/// <param name="topology"></param>
	/// <param name="submesh"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void SetIndices(int[] indices, MeshTopology topology, int submesh);

	/// <summary>
	///   <para>Gets the topology of a submesh.</para>
	/// </summary>
	/// <param name="submesh"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern MeshTopology GetTopology(int submesh);

	/// <summary>
	///   <para>Combines several meshes into this mesh.</para>
	/// </summary>
	/// <param name="combine">Descriptions of the meshes to combine.</param>
	/// <param name="mergeSubMeshes">Should all meshes be combined into a single submesh?</param>
	/// <param name="useMatrices">Should the transforms supplied in the CombineInstance array be used or ignored?</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void CombineMeshes(CombineInstance[] combine, [DefaultValue("true")] bool mergeSubMeshes, [DefaultValue("true")] bool useMatrices);

	[ExcludeFromDocs]
	public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes)
	{
		bool useMatrices = true;
		CombineMeshes(combine, mergeSubMeshes, useMatrices);
	}

	[ExcludeFromDocs]
	public void CombineMeshes(CombineInstance[] combine)
	{
		bool useMatrices = true;
		bool mergeSubMeshes = true;
		CombineMeshes(combine, mergeSubMeshes, useMatrices);
	}

	/// <summary>
	///   <para>Optimize mesh for frequent updates.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void MarkDynamic();

	/// <summary>
	///   <para>Upload previously done mesh modifications to the graphics API.</para>
	/// </summary>
	/// <param name="markNoLogerReadable">Frees up system memory copy of mesh data when set to true.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void UploadMeshData(bool markNoLogerReadable);

	/// <summary>
	///   <para>Returns name of BlendShape by given index.</para>
	/// </summary>
	/// <param name="index"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern string GetBlendShapeName(int index);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern int GetBlendShapeIndex(string blendShapeName);
}
