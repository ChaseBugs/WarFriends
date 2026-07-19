using UnityEngine;

[RequireComponent(typeof(QuickRope2))]
[ExecuteInEditMode]
public class QuickRope2Prefab : MonoBehaviour
{
	public GameObject prefab;

	public float jointScale = 1f;

	public bool alternateJoints = true;

	public bool firstJointAlternated;

	private QuickRope2 rope;

	private void OnEnable()
	{
		rope = GetComponent<QuickRope2>();
		if (prefab == null)
		{
			prefab = (GameObject)Resources.Load("Link", typeof(GameObject));
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
		if ((bool)prefab)
		{
			rope.JointPrefab = prefab;
			rope.JointScale = jointScale;
			rope.GenerateJointObjects();
		}
	}
}
