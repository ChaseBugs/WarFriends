using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Center On Child Momentum")]
public class UICenterOnChildWithMomentum : MonoBehaviour
{
	private UIDraggablePanel mDrag;

	private GameObject mCenteredObject;

	private bool _dragFinished;

	public float MaxMomentumMagnitude = 5f;

	private int count;

	public bool ShouldRecenter = true;

	public GameObject centeredObject => mCenteredObject;

	public bool CanScrollRight
	{
		get
		{
			CheckCenteredObject();
			Transform transform = base.transform;
			int i = 0;
			for (int childCount = transform.childCount; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.gameObject == mCenteredObject && i + 1 < childCount)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool CanScrollLeft
	{
		get
		{
			CheckCenteredObject();
			return base.transform.GetChild(0).gameObject != mCenteredObject;
		}
	}

	private void OnEnable()
	{
		Recenter();
	}

	private void OnDragFinished()
	{
		if (base.enabled)
		{
			_dragFinished = true;
		}
	}

	private void Update()
	{
		count++;
		bool flag = count == 2;
		if (_dragFinished || flag || ShouldRecenter)
		{
			Recenter();
			_dragFinished = false;
			ShouldRecenter = false;
		}
	}

	public void Recenter()
	{
		if (mDrag == null)
		{
			mDrag = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
			if (mDrag == null)
			{
				if (Debug.isDebugBuild)
				{
					Debug.LogWarning(string.Concat(GetType(), " requires ", typeof(UIDraggablePanel), " on a parent object in order to work"), this);
				}
				base.enabled = false;
				return;
			}
			mDrag.onDragFinished = OnDragFinished;
		}
		if (mDrag.panel == null)
		{
			return;
		}
		Vector4 clipRange = mDrag.panel.clipRange;
		Transform cachedTransform = mDrag.panel.cachedTransform;
		Vector3 localPosition = cachedTransform.localPosition;
		localPosition.x += clipRange.x;
		localPosition.y += clipRange.y;
		localPosition = cachedTransform.parent.TransformPoint(localPosition);
		Vector3 vector = ((!(mDrag.currentMomentum.magnitude > MaxMomentumMagnitude)) ? mDrag.currentMomentum : (mDrag.currentMomentum.normalized * MaxMomentumMagnitude));
		Vector3 vector2 = localPosition - vector * (mDrag.momentumAmount * 2f);
		mDrag.currentMomentum = Vector3.zero;
		float num = float.MaxValue;
		Transform transform = null;
		Transform transform2 = base.transform;
		int i = 0;
		for (int childCount = transform2.childCount; i < childCount; i++)
		{
			Transform child = transform2.GetChild(i);
			float num2 = Vector3.SqrMagnitude(child.position - vector2);
			if (num2 < num)
			{
				num = num2;
				transform = child;
			}
		}
		if (transform != null)
		{
			mCenteredObject = transform.gameObject;
			Vector3 vector3 = cachedTransform.InverseTransformPoint(transform.position);
			Vector3 vector4 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector5 = vector3 - vector4;
			if (mDrag.scale.x == 0f)
			{
				vector5.x = 0f;
			}
			if (mDrag.scale.y == 0f)
			{
				vector5.y = 0f;
			}
			if (mDrag.scale.z == 0f)
			{
				vector5.z = 0f;
			}
			SpringPanel.Begin(mDrag.gameObject, cachedTransform.localPosition - vector5, 2f);
		}
		else
		{
			mCenteredObject = null;
		}
	}

	public void MoveRight()
	{
		CheckCenteredObject();
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == mCenteredObject)
			{
				num = i + 1;
				break;
			}
		}
		if (num < transform.childCount)
		{
			Transform child2 = transform.GetChild(num);
			mCenteredObject = child2.gameObject;
			Vector4 clipRange = mDrag.panel.clipRange;
			Transform cachedTransform = mDrag.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (mDrag.scale.x == 0f)
			{
				vector3.x = 0f;
			}
			if (mDrag.scale.y == 0f)
			{
				vector3.y = 0f;
			}
			if (mDrag.scale.z == 0f)
			{
				vector3.z = 0f;
			}
			SpringPanel.Begin(mDrag.gameObject, cachedTransform.localPosition - vector3, 3f);
		}
	}

	public void MoveLeft()
	{
		int num = -1;
		Transform transform = base.transform;
		int i = 0;
		for (int childCount = transform.childCount; i < childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.gameObject == mCenteredObject)
			{
				num = i - 1;
				break;
			}
		}
		if (num >= 0)
		{
			Transform child2 = transform.GetChild(num);
			mCenteredObject = child2.gameObject;
			Vector4 clipRange = mDrag.panel.clipRange;
			Transform cachedTransform = mDrag.panel.cachedTransform;
			Vector3 localPosition = cachedTransform.localPosition;
			localPosition.x += clipRange.x;
			localPosition.y += clipRange.y;
			localPosition = cachedTransform.parent.TransformPoint(localPosition);
			Vector3 vector = cachedTransform.InverseTransformPoint(child2.position);
			Vector3 vector2 = cachedTransform.InverseTransformPoint(localPosition);
			Vector3 vector3 = vector - vector2;
			if (mDrag.scale.x == 0f)
			{
				vector3.x = 0f;
			}
			if (mDrag.scale.y == 0f)
			{
				vector3.y = 0f;
			}
			if (mDrag.scale.z == 0f)
			{
				vector3.z = 0f;
			}
			SpringPanel.Begin(mDrag.gameObject, cachedTransform.localPosition - vector3, 3f);
		}
	}

	private void CheckCenteredObject()
	{
		if (mCenteredObject == null)
		{
			mCenteredObject = base.transform.GetChild(0).gameObject;
		}
	}
}
