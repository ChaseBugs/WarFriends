using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletModels : Singleton<BulletModels>
{
	[Serializable]
	public class BulletMesh
	{
		public string name;

		public Mesh mesh;
	}

	public List<BulletMesh> bulletmeshes;

	private Dictionary<string, Mesh> mMeshes = new Dictionary<string, Mesh>();

	protected override void Awake()
	{
		base.Awake();
		foreach (BulletMesh bulletmesh in bulletmeshes)
		{
			mMeshes[bulletmesh.name] = bulletmesh.mesh;
		}
	}

	public Mesh GetMesh(string meshName)
	{
		mMeshes.TryGetValue(meshName, out var value);
		return value;
	}
}
