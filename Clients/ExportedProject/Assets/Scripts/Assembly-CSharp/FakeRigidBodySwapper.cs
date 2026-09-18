using System;
using System.Collections.Generic;
using UnityEngine;

public class FakeRigidBodySwapper : Core_BaseScript
{
	[Serializable]
	public class MeshFliterAndRenderer
	{
		public MeshFilter meshFilter;

		public Renderer meshRenderer;
	}

	public GameObject NoRigidBodyObject;

	public GameObject RigidBodyObject;

	public MeshFliterAndRenderer noRigidBody;

	public MeshFliterAndRenderer rigidBody;

	public GameObject snapPoint;

	private Vector3 mStartPos;

	private Quaternion mStartRot;

	private Transform mRigidBodyTransformParent;

	private bool mHidden;

	protected override void Awake()
	{
		base.Awake();
		Init();
	}

	public void Init()
	{
		mStartPos = RigidBodyObject.transform.localPosition;
		mStartRot = RigidBodyObject.transform.localRotation;
		mRigidBodyTransformParent = RigidBodyObject.transform.parent;
		if (noRigidBody.meshFilter == null)
		{
			noRigidBody.meshFilter = NoRigidBodyObject.GetComponent<MeshFilter>();
			noRigidBody.meshRenderer = NoRigidBodyObject.GetComponent<Renderer>();
		}
		if (rigidBody.meshFilter == null)
		{
			rigidBody.meshFilter = RigidBodyObject.GetComponent<MeshFilter>();
			rigidBody.meshRenderer = RigidBodyObject.GetComponent<Renderer>();
		}
	}

	public void SetMesh(Mesh mesh)
	{
		Reset();
		noRigidBody.meshFilter.sharedMesh = mesh;
		rigidBody.meshFilter.sharedMesh = mesh;
	}

	public void SetMesh(Mesh mesh, List<Material> materials)
	{
		Reset();
		noRigidBody.meshFilter.sharedMesh = mesh;
		noRigidBody.meshRenderer.sharedMaterials = materials.ToArray();
		rigidBody.meshFilter.sharedMesh = mesh;
		rigidBody.meshRenderer.sharedMaterials = materials.ToArray();
	}

	public void SetMaterials(Material[] materials)
	{
		noRigidBody.meshRenderer.sharedMaterials = materials;
		rigidBody.meshRenderer.sharedMaterials = materials;
	}

	public void Swap(bool toRigidBody)
	{
		if (!base.gameObject.activeInHierarchy || mHidden)
		{
			return;
		}
		if (toRigidBody)
		{
			RigidBodyObject.SetActive(value: true);
			NoRigidBodyObject.SetActive(value: false);
			RigidBodyObject.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
			RigidBodyObject.transform.localScale = Vector3.one;
			if (snapPoint != null)
			{
				snapPoint.transform.parent = RigidBodyObject.transform;
				snapPoint.transform.localRotation = default(Quaternion);
				snapPoint.transform.localPosition = default(Vector3);
				snapPoint.transform.localScale = Vector3.one;
			}
		}
		else
		{
			RigidBodyObject.SetActive(value: false);
			NoRigidBodyObject.SetActive(value: true);
			if (snapPoint != null)
			{
				snapPoint.transform.parent = NoRigidBodyObject.transform;
				snapPoint.transform.localRotation = default(Quaternion);
				snapPoint.transform.localPosition = default(Vector3);
				snapPoint.transform.localScale = Vector3.one;
			}
		}
	}

	public void SnapTo(Transform to)
	{
		snapPoint.transform.parent = to;
		snapPoint.transform.localRotation = default(Quaternion);
		snapPoint.transform.localPosition = default(Vector3);
		snapPoint.transform.localScale = Vector3.one;
	}

	public void SetParent(Transform to)
	{
		snapPoint.transform.parent = to;
	}

	public void SetTexture(Texture2D texture)
	{
		noRigidBody.meshRenderer.material.mainTexture = texture;
		rigidBody.meshRenderer.material.mainTexture = texture;
	}

	public void SetMatCapTexture(Texture2D texture)
	{
		noRigidBody.meshRenderer.material.SetTexture("_MatCap", texture);
		rigidBody.meshRenderer.material.SetTexture("_MatCap", texture);
	}

	public void Reset()
	{
		mHidden = false;
		NoRigidBodyObject.SetActive(value: true);
		RigidBodyObject.SetActive(value: false);
		RigidBodyObject.transform.localPosition = mStartPos;
		RigidBodyObject.transform.localRotation = mStartRot;
		RigidBodyObject.transform.parent = mRigidBodyTransformParent;
		RigidBodyObject.transform.localScale = Vector3.one;
	}

	private void OnDisable()
	{
		if (RigidBodyObject != null)
		{
			RigidBodyObject.SetActive(value: false);
		}
	}

	public void Hide()
	{
		mHidden = true;
		RigidBodyObject.SetActive(value: false);
		NoRigidBodyObject.SetActive(value: false);
	}

	public void Reposition()
	{
		snapPoint.transform.localPosition = -NoRigidBodyObject.transform.localPosition;
		snapPoint.transform.localRotation = Quaternion.Inverse(NoRigidBodyObject.transform.localRotation);
		Vector3 localScale = NoRigidBodyObject.transform.localScale;
		snapPoint.transform.localScale = new Vector3(1f / localScale.x, 1f / localScale.y, 1f / localScale.z);
	}
}
