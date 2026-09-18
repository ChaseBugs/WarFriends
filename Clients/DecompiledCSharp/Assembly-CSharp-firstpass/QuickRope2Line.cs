using System;
using UnityEngine;

[Serializable]
[ExecuteInEditMode]
[RequireComponent(typeof(QuickRope2))]
public class QuickRope2Line : MonoBehaviour
{
	private QuickRope2 rope;

	private LineRenderer line;

	public bool useAutoTextureTiling = true;

	private void OnEnable()
	{
		rope = GetComponent<QuickRope2>();
		if (base.gameObject.GetComponent<LineRenderer>() == null)
		{
			line = base.gameObject.AddComponent<LineRenderer>();
		}
		else
		{
			line = base.gameObject.GetComponent<LineRenderer>();
		}
		if (line.sharedMaterial == null)
		{
			line.sharedMaterial = (Material)Resources.Load("Materials/RopeLineMaterial", typeof(Material));
		}
		rope.OnInitializeMesh += OnInitializeMesh;
	}

	private void OnDisable()
	{
		rope.OnInitializeMesh -= OnInitializeMesh;
		if (rope != null)
		{
			rope.ClearJointObjects();
		}
	}

	private void OnDestroy()
	{
		rope.OnInitializeMesh -= OnInitializeMesh;
		if (rope != null)
		{
			rope.ClearJointObjects();
		}
	}

	public void OnInitializeMesh()
	{
		if (!(rope == null))
		{
			rope.GenerateJointObjects();
			Update();
			if (useAutoTextureTiling)
			{
				base.gameObject.GetComponent<LineRenderer>().sharedMaterial.mainTextureScale = new Vector2((float)rope.Joints.Count / 2f, 1f);
			}
		}
	}

	private void Update()
	{
		if (line == null)
		{
			return;
		}
		if (useAutoTextureTiling && Application.isPlaying)
		{
			line.material.mainTextureScale = new Vector2((float)rope.Joints.Count / 2f, 1f);
		}
		int num = 0;
		line.SetVertexCount(rope.Joints.Count);
		foreach (GameObject joint in rope.Joints)
		{
			line.SetPosition(num++, joint.transform.position);
		}
	}
}
