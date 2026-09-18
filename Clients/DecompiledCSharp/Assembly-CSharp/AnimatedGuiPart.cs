using UnityEngine;

[RequireComponent(typeof(UISimpleHider))]
public class AnimatedGuiPart : MonoBehaviour
{
	private Vector3 startPosition;

	private void OnEnable()
	{
		startPosition = base.transform.localPosition;
		base.transform.localPosition += new Vector3(0f, 1000f, 0f);
	}

	public void Animate()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 0.7f, startPosition + new Vector3(0f, 500f, 0f), startPosition);
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.steeperCurves = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(base.gameObject, 0.7f, 0f, 1f);
		tweenAlphaHider.method = UITweener.Method.EaseInOut;
		GetComponent<UISimpleHider>().alpha = 0f;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
