using System.Runtime.CompilerServices;

namespace UnityEngine;

/// <summary>
///   <para>Struct used to describe meshes to be combined using Mesh.CombineMeshes.</para>
/// </summary>
public struct CombineInstance
{
	private int m_MeshInstanceID;

	private int m_SubMeshIndex;

	private Matrix4x4 m_Transform;

	/// <summary>
	///   <para>Mesh to combine.</para>
	/// </summary>
	public Mesh mesh
	{
		get
		{
			return InternalGetMesh(m_MeshInstanceID);
		}
		set
		{
			m_MeshInstanceID = ((value != null) ? value.GetInstanceID() : 0);
		}
	}

	/// <summary>
	///   <para>Submesh index of the mesh.</para>
	/// </summary>
	public int subMeshIndex
	{
		get
		{
			return m_SubMeshIndex;
		}
		set
		{
			m_SubMeshIndex = value;
		}
	}

	/// <summary>
	///   <para>Matrix to transform the mesh with before combining.</para>
	/// </summary>
	public Matrix4x4 transform
	{
		get
		{
			return m_Transform;
		}
		set
		{
			m_Transform = value;
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern Mesh InternalGetMesh(int instanceID);
}
