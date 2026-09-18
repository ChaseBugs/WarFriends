using UnityEngine;

public class ArmyLeftHint : Core_BaseScript
{
	private enum Type
	{
		SpecialAbility,
		ElitePerk
	}

	[SerializeField]
	[Header("Core")]
	private Type mCurrentType;

	[SerializeField]
	private BoxCollider mHintButton;

	[SerializeField]
	private UISprite mHintButtonBackground;

	[SerializeField]
	private UIPanel mHintDialog;

	[SerializeField]
	private BoxCollider mHintDialogCollider;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private UITable mTable;

	[SerializeField]
	private UISprite mIcon;

	[SerializeField]
	private UISprite mBuffIcon;

	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private UILabel mDescription;

	[SerializeField]
	private GameObject mBottomItem;

	[Header("Setting")]
	[SerializeField]
	private Vector3 mBasePosition = new Vector3(646f, 0f, -23000f);

	private LevelBehaviour mUnit;

	public void InitControls()
	{
		UIEventListener.Get(mHintButton.gameObject).onClick = OnHintButtonClick;
		UIEventListener.Get(mHintDialogCollider.gameObject).onClick = OnHintDialogClick;
		mTable.onReposition = OnRepositedTable;
	}

	public void InitGUIValues()
	{
		InstantHideHint();
	}

	public void DoAfterHide()
	{
		InstantHideHint();
	}

	public void Initialize(LevelBehaviour unit)
	{
		mUnit = unit;
		SetCorrectHintIcon();
		if (mCurrentType == Type.SpecialAbility)
		{
			mTitle.text = mUnit.unitAbilityName;
			mDescription.text = mUnit.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		}
		else
		{
			mTitle.text = mUnit.unitBuffName;
			mDescription.text = mUnit.GetBuffDescriptionWithColours(Colours.stringGrayAbi1);
		}
		mTable.repositionNow = true;
	}

	private void OnHintButtonClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mHintDialog.gameObject.activeSelf)
		{
			HideHint();
		}
		else
		{
			ShowHint();
		}
		if (mCurrentType == Type.ElitePerk && !PlayerAnalytics.instance.data.elitesShown)
		{
			Singleton<MessageManager>.instance.AddMessage(new ElitePerkTutorialMessage());
			ElitesFeatureShownRequest.Send();
		}
	}

	private void OnHintDialogClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HideHint();
	}

	private void OnRepositedTable()
	{
		float num = Mathf.Abs(mBottomItem.transform.localPosition.y);
		mTable.transform.localPosition = mTable.transform.localPosition.ReplaceY(num + 30f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY(num + 60f);
		mHintDialogCollider.center = mHintDialogCollider.center.ReplaceY(num / 2f + 30f);
		mHintDialogCollider.size = mHintDialogCollider.size.ReplaceY(num + 60f);
	}

	private void ShowHint()
	{
		mHintButtonBackground.spriteName = MiscTools.closeButtonSprite;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: true);
		mHintDialog.alpha1 = 0.005f;
		SetCorrectHintIcon();
		TweenAlpha.Begin(mHintDialog.gameObject, 0.4f, 1f).onFinished = null;
		mHintDialog.transform.localPosition = mBasePosition.AddY(-20f);
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 0.25f, mBasePosition.AddY(-20f), mBasePosition.AddY(10f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(mHintDialog.gameObject, 0.15f, mBasePosition);
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void HideHint()
	{
		mHintButtonBackground.spriteName = MiscTools.infoButtonSprite;
		mHintButtonBackground.MakePixelPerfect();
		TweenAlpha.Begin(mHintDialog.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(mHintDialog.gameObject, 0.4f, mBasePosition.AddY(20f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			InstantHideHint();
		};
	}

	private void InstantHideHint()
	{
		mHintButtonBackground.spriteName = MiscTools.infoButtonSprite;
		mHintButtonBackground.MakePixelPerfect();
		mHintDialog.gameObject.SetActive(value: false);
	}

	private void SetCorrectHintIcon()
	{
		if (mHintDialog.gameObject.activeSelf)
		{
			mBuffIcon.gameObject.SetActive(mCurrentType == Type.ElitePerk);
			if (mCurrentType == Type.SpecialAbility)
			{
				mIcon.spriteName = mUnit.abilityIcon;
			}
			else
			{
				mUnit.SetUpEliteIcon(mIcon, mBuffIcon);
			}
			mIcon.MakePixelPerfect();
		}
	}
}
