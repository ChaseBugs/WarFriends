using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(QuickRope2))]
[ExecuteInEditMode]
public class QuickRope2Mesh : MonoBehaviour
{
	public bool meshStatic;

	public int maxRadius = 5;

	public float textureTiling = 1f;

	[SerializeField]
	public AnimationCurve curve = new AnimationCurve(new Keyframe(0f, 0.3f), new Keyframe(1f, 0.3f));

	public Color[] grad;

	public int crossSegments = 6;

	[SerializeField]
	public RopeTubeRenderer tube;

	[SerializeField]
	private QuickRope2 rope;

	[SerializeField]
	private MeshFilter mFilter;

	private void Awake()
	{
		rope = GetComponent<QuickRope2>();
		rope.OnInitializeMesh += OnInitializeMesh;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
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
		if (tube == null)
		{
			tube = new RopeTubeRenderer(base.gameObject, useMeshOnly: false);
		}
		tube.calculateTangents = true;
		UpdateMesh();
	}

	public void UpdateMesh()
	{
		tube.SetPointsAndRotations(rope.JointPositions, rope.GetRotations(rope.JointPositions));
		tube.SetEdgeCount(crossSegments);
		float[] array = new float[rope.JointPositions.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = curve.Evaluate((float)i * (1f / (float)array.Length));
		}
		tube.SetRadiuses(array);
		tube.Update();
		base.gameObject.GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2((float)rope.Joints.Count * textureTiling, 1f);
	}

	private void Update()
	{
		if (!meshStatic && Application.isPlaying)
		{
			float[] array = new float[rope.JointPositions.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = curve.Evaluate((float)i * (1f / (float)array.Length));
			}
			tube.SetPointsAndRotations(rope.JointPositions, rope.GetRotations(rope.JointPositions));
			tube.SetRadiuses(array);
			tube.Update();
			base.gameObject.GetComponent<Renderer>().material.mainTextureScale = new Vector2((float)rope.Joints.Count * textureTiling, 1f);
		}
	}
}
