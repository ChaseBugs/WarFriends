using UnityEngine;

public class BonusTakeDisplayer : PoolableObject
{
	public TextMesh text;

	public tk2dSprite blueBg;

	public tk2dSprite whiteBorder;

	public tk2dSprite icon;

	public tk2dSprite textBg;

	[SerializeField]
	private TweenAnimator mAnimator;

	public Color color;

	public GameObject top;

	public GameObject bottom;

	public override void OnInstancied()
	{
		base.OnInstancied();
	}

	private void GenerateTweens()
	{
		mAnimator.allTweens.Clear();
		mAnimator.AddTween(from: Vector3.zero, id: 0, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: blueBg.gameObject, time: 0.2f, to: new Vector3(1.3f, 1.3f, 1.3f), delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(1, TweenAnimator.TweenType.Scale, blueBg.gameObject, 0.1f, Vector3.one, 0f, 0, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(from: Vector3.zero, id: 2, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: whiteBorder.gameObject, time: 0.2f, to: new Vector3(1.3f, 1.3f, 1.3f), delay: 0.1f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(3, TweenAnimator.TweenType.Scale, whiteBorder.gameObject, 0.1f, Vector3.one, 0f, 2, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(from: Vector3.zero, id: 4, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: icon.gameObject, time: 0.2f, to: new Vector3(1.6f, 1.6f, 1.6f), delay: 0.2f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(5, TweenAnimator.TweenType.Scale, icon.gameObject, 0.1f, Vector3.one, 0f, 4, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(from: new Vector3(0.001f, 1f, 1f), id: 6, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: textBg.gameObject, time: 0.3f, to: Vector3.one, delay: 0.2f);
		mAnimator.AddTween(7, TweenAnimator.TweenType.AlphaTk2d, text.gameObject, 0.08f, 1f, 0f, 6, 0f, UITweener.Method.EaseInOut, UITweener.Style.PingPong, 5);
		mAnimator.AddTween(8, TweenAnimator.TweenType.Scale, top, 0.4f, new Vector3(0f, 1f, 1f), 0.2f, 7);
		mAnimator.AddTween(9, TweenAnimator.TweenType.Scale, bottom, 0.4f, new Vector3(1f, 0f, 1f), 0.2f, 7);
	}

	protected override void Awake()
	{
		base.Awake();
		GenerateTweens();
	}

	public void Play(KillStreakBonus bonus)
	{
		text.text = bonus.fullName;
		text.color = color;
		blueBg.SetSprite("game-scorestreak-bg" + bonus.bgSuffix);
		icon.SetSprite(bonus.iconName);
		if (bonus.bgSuffix == string.Empty)
		{
			text.anchor = TextAnchor.MiddleLeft;
			text.transform.localPosition = default(Vector3);
			text.transform.localScale = Vector3.one;
		}
		else
		{
			text.anchor = TextAnchor.MiddleCenter;
			text.transform.localPosition = new Vector3(32f, 0f, 0f);
			text.transform.localScale = Vector3.one.ReplaceXY(2.2f, 2.2f);
		}
		float x = text.GetComponent<MeshRenderer>().bounds.size.x;
		float num = 31f;
		if (x > num)
		{
			Debug.Log("BONUS: size: " + x + " name:" + bonus.fullName);
			float num2 = num / (x / text.transform.localScale.x);
			text.transform.localScale = new Vector3(num2, num2, 1f);
		}
		Play();
	}

	public void Play()
	{
		blueBg.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		whiteBorder.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		icon.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		text.color = Colours.blackTransparent;
		textBg.transform.localScale = new Vector3(0.001f, 1f, 1f);
		top.transform.localScale = Vector3.one;
		bottom.transform.localScale = Vector3.one;
		mAnimator.PlayTweens();
		DestroyPooled(2f);
	}
}
