using UnityEngine;

public class DogTagRecord : PoolableObject
{
	[Header("Core")]
	public UISprite background;

	public UISprite foreground;

	public DogTagRecordAnimation animationObject;

	private bool mIsVIPDogTag;

	public void Initialize(bool filled)
	{
		foreground.fillAmount = ((!filled) ? 0f : 1f);
		foreground.alpha = 1f;
	}

	public void SetSpritesOrder(int position, int maximumDogtags)
	{
		mIsVIPDogTag = position >= maximumDogtags - Singleton<VipManager>.instance.numberOfVIPDogtags && Singleton<VipManager>.instance.IsVipActive();
		foreground.color = ((!mIsVIPDogTag) ? Color.white : Colours.goldDogtag);
		position *= 2;
		background.depth = position + 7;
		foreground.depth = position + 8;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(-position);
		animationObject.SetDepthsAndColor(mIsVIPDogTag);
	}

	public void Animation_DogTagConsumed()
	{
		animationObject.StartAnimation();
	}

	public void StopAnimation()
	{
		animationObject.StopAnimation();
	}
}
