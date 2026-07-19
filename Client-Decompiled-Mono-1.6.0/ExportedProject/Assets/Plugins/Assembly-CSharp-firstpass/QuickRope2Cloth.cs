using UnityEngine;

[RequireComponent(typeof(QuickRope2))]
[ExecuteInEditMode]
public class QuickRope2Cloth : MonoBehaviour
{
	public int maxRadius = 5;

	public AnimationCurve curve = new AnimationCurve(new Keyframe(0f, 0.3f), new Keyframe(1f, 0.3f));

	public int crossSegments = 6;

	[SerializeField]
	private RopeTubeRenderer tube;

	private QuickRope2 rope;

	private void OnEnable()
	{
		rope = GetComponent<QuickRope2>();
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
	}

	public void GenerateMesh()
	{
	}
}
