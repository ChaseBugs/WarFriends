using System.Collections;
using UnityEngine;

public class DamageDisplayer : PoolableObject
{
	public TextMeshWithStroke text;

	[SerializeField]
	private TweenAnimator mAnimator;

	private void GenerateTweens()
	{
		mAnimator.allTweens.Clear();
		mAnimator.AddTween(0, TweenAnimator.TweenType.AlphaTk2d, text.gameObject, 0.3f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(from: new Vector3(0f, 0f, -1f), id: 1, tweenType: TweenAnimator.TweenType.Position, tweenTarget: text.gameObject, time: 0.7f, to: new Vector3(4f, 5f, 0f), delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(from: Vector3.zero, id: 2, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: base.gameObject, time: 0.3f, to: new Vector3(1.3f, 1.3f, 1.3f), delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(3, TweenAnimator.TweenType.Scale, base.gameObject, 0.2f, Vector3.one, 0f, 2, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(4, TweenAnimator.TweenType.AlphaTk2d, text.gameObject, 0.3f, 0f, 0.1f, 1);
		mAnimator.GenerateTweens();
	}

	protected override void Awake()
	{
		base.Awake();
		GenerateTweens();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
	}

	public void Show(float damage, bool isCritical, bool immortal)
	{
		text.text = ((!immortal) ? ((int)damage).ToString() : ((!Singleton<GameController>.instance.isTutorial) ? Localization.Localize("ID_IMMUNE") : string.Empty));
		text.color = ((!isCritical || immortal) ? Color.white : Color.yellow);
		if (Random.value > 0.5f)
		{
			mAnimator.allTweens[1].to = new Vector3(8f, 5f, -1f);
		}
		else
		{
			mAnimator.allTweens[1].to = new Vector3(-8f, 5f, -1f);
		}
		mAnimator.allTweens[2].to = ((!isCritical) ? new Vector3(1.3f, 1.3f, 1.3f) : new Vector3(1.5f, 1.5f, 1.5f));
		mAnimator.allTweens[3].to = ((!isCritical) ? Vector3.one : new Vector3(1.2f, 1.2f, 1.2f));
		StartCoroutine(ShowWorker());
	}

	private IEnumerator ShowWorker()
	{
		mAnimator.PlayTweens();
		yield return new WaitForSeconds(1f);
		DestroyPooled();
	}
}
