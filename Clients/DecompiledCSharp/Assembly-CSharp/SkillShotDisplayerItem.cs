using System;
using UnityEngine;

public class SkillShotDisplayerItem : PoolableObject
{
	public tk2dSprite iconSprite;

	public tk2dSprite bgSprite;

	public tk2dSprite powerSprite;

	public TextMesh text;

	public TextMesh score;

	public Color priceColor;

	private Vector3 scale;

	[SerializeField]
	private TweenAnimator mAnimator;

	public override void OnInstancied()
	{
		base.OnInstancied();
		text.transform.localScale = scale;
		iconSprite.gameObject.SetActive(value: true);
		iconSprite.GetComponent<MeshRenderer>().enabled = true;
	}

	private void GenerateTweens()
	{
		mAnimator.allTweens.Clear();
		mAnimator.AddTween(from: Vector3.zero, id: 0, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: base.gameObject, time: 0.5f, to: new Vector3(1.3f, 1.3f, 1.3f), delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(1, TweenAnimator.TweenType.AlphaTk2d, iconSprite.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(2, TweenAnimator.TweenType.AlphaTk2d, bgSprite.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(3, TweenAnimator.TweenType.AlphaTk2d, text.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(4, TweenAnimator.TweenType.AlphaTk2d, score.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(5, TweenAnimator.TweenType.Scale, base.gameObject, 0.2f, Vector3.one, 0f, 0, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(6, TweenAnimator.TweenType.AlphaTk2d, iconSprite.gameObject, 0.3f, 0f, 0.5f, 5);
		mAnimator.AddTween(7, TweenAnimator.TweenType.AlphaTk2d, bgSprite.gameObject, 0.3f, 0f, 0.5f, 5);
		mAnimator.AddTween(8, TweenAnimator.TweenType.AlphaTk2d, text.gameObject, 0.3f, 0f, 0.5f, 5);
		mAnimator.AddTween(9, TweenAnimator.TweenType.AlphaTk2d, score.gameObject, 0.3f, 0f, 0.5f, 5);
		TweenAnimator tweenAnimator = mAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(TweenFinished));
	}

	protected override void Awake()
	{
		base.Awake();
		scale = text.transform.localScale;
		GenerateTweens();
	}

	private void TweenFinished(int i)
	{
		if (i == 8)
		{
			DestroyPooled();
		}
	}

	public void Play(SkillShotManager.SkillShotItemDefinition type)
	{
		score.gameObject.SetActive(value: true);
		string menuName = type.menuName;
		string text = type.points.ToString("+#;-#");
		bgSprite.color = ((type.points <= 0) ? Color.red : Color.black);
		this.text.text = menuName;
		score.text = text;
		this.text.color = Color.white;
		Vector3 size = this.text.GetComponent<MeshRenderer>().bounds.size;
		Vector3 size2 = score.GetComponent<MeshRenderer>().bounds.size;
		size2.x += 1f;
		size.x += size2.x;
		this.text.transform.localPosition = this.text.transform.localPosition.ReplaceX(0f - size2.x);
		Vector3 localPosition = new Vector3(0f - size.x - 0.5f, 0f, 0f);
		iconSprite.SetSprite(type.iconName);
		iconSprite.gameObject.transform.localPosition = localPosition;
		Vector3 localScale = bgSprite.transform.localScale;
		localScale.x = (size.x + 8f) / bgSprite.GetBounds().size.x;
		localScale.y = (size.y + 0.15f) / bgSprite.GetBounds().size.y;
		bgSprite.transform.localScale = localScale;
		powerSprite.gameObject.SetActive(value: false);
		mAnimator.PlayTweens();
	}

	public void PlayCritical()
	{
		score.text = string.Empty;
		text.transform.localPosition = score.transform.localPosition;
		text.text = Localization.Localize("ID_CRITICAL");
		text.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
		text.color = Color.black;
		bgSprite.color = Color.yellow;
		Vector3 size = text.GetComponent<MeshRenderer>().bounds.size;
		iconSprite.GetComponent<MeshRenderer>().enabled = false;
		Vector3 localScale = bgSprite.transform.localScale;
		localScale.x = (size.x + 2f) / bgSprite.GetBounds().size.x;
		localScale.y = size.y / bgSprite.GetBounds().size.y;
		bgSprite.transform.localScale = localScale;
		powerSprite.gameObject.SetActive(value: false);
		mAnimator.PlayTweens();
	}

	public void PlayBoxStolen(bool wasStolen)
	{
		score.text = string.Empty;
		text.transform.localPosition = score.transform.localPosition;
		text.text = Localization.Localize((!wasStolen) ? "ID_CRATESTOLEN" : "ID_CRATEWASSTOLEN");
		text.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
		text.color = Color.black;
		bgSprite.color = ((!wasStolen) ? Color.white : Color.red);
		Vector3 size = text.GetComponent<MeshRenderer>().bounds.size;
		iconSprite.GetComponent<MeshRenderer>().enabled = false;
		Vector3 localScale = bgSprite.transform.localScale;
		localScale.x = (size.x + 2f) / bgSprite.GetBounds().size.x;
		localScale.y = size.y / bgSprite.GetBounds().size.y;
		bgSprite.transform.localScale = localScale;
		powerSprite.gameObject.SetActive(value: false);
		mAnimator.PlayTweens();
	}
}
