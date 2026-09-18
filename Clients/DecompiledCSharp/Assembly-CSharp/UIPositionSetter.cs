using UnityEngine;

[AddComponentMenu("Position Setter")]
public class UIPositionSetter : MonoBehaviour
{
	[Header("Height Settings (+/- important)")]
	public float classicHeight;

	public float wideHeight;

	[HideInInspector]
	public bool initializationResizeDone;

	public float computeHeight
	{
		get
		{
			float num = 1.3333334f;
			float num2 = 1.7777778f;
			float num3 = Mathf.Clamp(UIRoot.list[0].activeWidth / (float)UIRoot.list[0].activeHeight, num, num2);
			float num4 = (num3 - num2) / (num - num2);
			return wideHeight + num4 * (classicHeight - wideHeight);
		}
	}

	private void Start()
	{
		if (!initializationResizeDone)
		{
			Initialize();
		}
	}

	private void OnEnable()
	{
		if (!initializationResizeDone)
		{
			Initialize();
		}
	}

	private void Awake()
	{
		if (!initializationResizeDone)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		initializationResizeDone = true;
		base.transform.localPosition = base.transform.localPosition.ReplaceY(computeHeight);
	}
}
