using UnityEngine;

public class CardPackRecord : Core_BaseScript
{
	private const float mMiddleMove = 150f;

	[Header("Content")]
	public UISprite background;

	public GameObject content;

	public BoxCollider boxCollider;

	[Header("Sale")]
	public GameObject salePart;

	public UILabel salePercentLabel;

	[Header("Watch Video")]
	public UITable watchVideoTable;

	public UILabel topText;

	public UISprite topBackground;

	public UILabel middleText;

	public UISprite middleSpacer;

	public UILabel bottomText;

	public UISprite bottomSpacer;

	[Header("Special Packs")]
	public UITable specialPacksTable;

	public UILabel packName;

	public UISprite packNameSpacer;

	public GameObject middlePart;

	public UISprite underline;

	public UISprite leftWing;

	public UILabel packText;

	public UISprite packTextSpacer;

	public UISprite rightWing;

	[Header("Bottom Button")]
	public GameObject bottomButton;

	public UISprite bottomButtonBackground;

	public UILabel bottomButtonName;

	[Header("Atlases")]
	public UIAtlas bigMenuAtlas;

	public UIAtlas cardAtlas;

	[HideInInspector]
	public CardPack typePack;

	private Vector3 mBasePosition;

	private bool mAnimating;

	public bool isAnimating => mAnimating;

	protected override void Awake()
	{
		base.Awake();
		watchVideoTable.onReposition = delegate
		{
			float y = Mathf.Clamp(Mathf.Abs(bottomText.transform.parent.transform.localPosition.y) - 38f, watchVideoTable.transform.localPosition.y, 180f);
			watchVideoTable.transform.localPosition = new Vector3(watchVideoTable.transform.localPosition.x, y, 0f);
		};
		specialPacksTable.onReposition = delegate
		{
			float val = Mathf.Min(98f, -55f + packNameSpacer.transform.localScale.y + packTextSpacer.transform.localScale.y);
			specialPacksTable.transform.localPosition = specialPacksTable.transform.localPosition.ReplaceY(val);
		};
	}

	public void SetBasePosition()
	{
		mBasePosition = base.transform.localPosition;
	}

	internal void Initialize(CardPack namePack)
	{
		typePack = namePack;
		mAnimating = false;
		if (typePack == CardPack.None)
		{
			SetVideoRewardPack(Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.RandomCard));
			return;
		}
		bool flag = typePack == CardPack.Starter || typePack == CardPack.Value;
		background.atlas = bigMenuAtlas;
		background.spriteName = GameVariables.cardpackLook[typePack].Value2;
		background.MakePixelPerfect();
		background.transform.localPosition = new Vector3(0f, -54f, 1f);
		background.color = Color.white;
		SetSale();
		watchVideoTable.gameObject.SetActive(value: false);
		specialPacksTable.gameObject.SetActive(flag);
		if (flag)
		{
			SetSpecialPackText(typePack);
		}
		bottomButton.SetActive(value: true);
		bottomButton.transform.localPosition = bottomButton.transform.localPosition.ReplaceX((!flag) ? (-1f) : 25f);
		bottomButtonBackground.transform.localScale = bottomButtonBackground.transform.localScale.ReplaceX(326f);
		bottomButtonName.text = Localization.Localize("ID_PACKDETAILS");
		MiscTools.SetUILabelRescale(bottomButtonName, 40f, 20f, 300);
	}

	public void SetVideoRewardPack(bool isVideoReady)
	{
		background.atlas = cardAtlas;
		background.spriteName = GameVariables.cardpackLook[CardPack.None].Value2;
		background.MakePixelPerfect();
		background.transform.localPosition = new Vector3(0f, 0f, 1f);
		background.transform.localScale = new Vector3(background.transform.localScale.x * 1.74f, background.transform.localScale.y * 1.74f, 1f);
		background.color = Colours.grayButton;
		background.alpha = ((!isVideoReady) ? 0.375f : 1f);
		boxCollider.enabled = isVideoReady;
		salePart.SetActive(value: false);
		float num = ((!isVideoReady) ? 250f : 220f);
		specialPacksTable.gameObject.SetActive(value: false);
		watchVideoTable.gameObject.SetActive(value: true);
		watchVideoTable.repositionNow = true;
		topText.text = ((!isVideoReady) ? Localization.Localize("ID_WAITVIDEO1") : Localization.Localize("ID_VIDEOREADY1"));
		middleText.text = ((!isVideoReady) ? Localization.Localize("ID_WAITVIDEO2") : Localization.Localize("ID_VIDEOREADY2"));
		bottomText.text = ((!isVideoReady) ? Localization.Localize("ID_WAITVIDEO3") : Localization.Localize("ID_VIDEOREADY3"));
		float num2 = Mathf.Clamp(num / bottomText.relativeSize.x, 20f, 80f);
		float y = Mathf.Round(num2 / 0.826f);
		MiscTools.SetUILabelRescale(bottomText, num2, 20f, (int)num);
		bottomSpacer.transform.localScale = new Vector3(num, y, 1f);
		float num3 = Mathf.Clamp(num / middleText.relativeSize.x, 20f, 50f);
		float y2 = Mathf.Round(num3 / 0.826f);
		MiscTools.SetUILabelRescale(middleText, num3, 20f, (int)num);
		middleSpacer.transform.localScale = new Vector3(num, y2, 1f);
		float max = 180f - (num2 + num3);
		float num4 = Mathf.Clamp(num / topText.relativeSize.x, 20f, max);
		float num5 = num4 / 5f;
		float num6 = Mathf.Max(0f, num5 / 2f - (num - topText.relativeSize.x * num4));
		float x = Mathf.Max(topText.relativeSize.x * topText.transform.localScale.x + num5, num);
		MiscTools.SetUILabelRescale(topText, num4, 20f, (int)num);
		topBackground.gameObject.SetActive(isVideoReady);
		if (isVideoReady)
		{
			float y3 = Mathf.Round(num4 / 0.826f);
			topBackground.transform.localScale = new Vector3(x, y3, 1f);
		}
		watchVideoTable.transform.localPosition = new Vector3(-125f - num6, (!isVideoReady) ? 144f : 164f, 0f);
		bottomButton.SetActive(isVideoReady);
		if (isVideoReady)
		{
			bottomButton.transform.localPosition = bottomButton.transform.localPosition.ReplaceX(6f);
			bottomButtonBackground.transform.localScale = bottomButtonBackground.transform.localScale.ReplaceX(333f);
			bottomButtonName.text = Localization.Localize("ID_WATCHVIDEO");
			MiscTools.SetUILabelRescale(bottomButtonName, 40f, 20f, 300);
		}
	}

	private void SetSpecialPackText(CardPack namePack)
	{
		string value = GameVariables.cardpackLook[typePack].Value1;
		packName.text = ((!string.IsNullOrEmpty(value)) ? Localization.Localize(value) : string.Empty);
		MiscTools.SetUILabelRescale(packName, 70f, 20f, 250);
		float val = Mathf.Round(packName.transform.localScale.y / 0.826f);
		packNameSpacer.transform.localScale = packNameSpacer.transform.localScale.ReplaceY(val);
		packText.text = Localization.Localize("ID_PACK");
		MiscTools.SetUILabelRescale(packText, 70f, 20f, 158);
		float val2 = Mathf.Max(45f, Mathf.Round(packText.transform.localScale.y / 0.826f));
		packTextSpacer.transform.localScale = packTextSpacer.transform.localScale.ReplaceY(val2);
		underline.color = ((namePack != CardPack.Starter) ? Colours.valuePack : Colours.starterPack);
		underline.alpha = 0.5f;
		leftWing.color = ((namePack != CardPack.Starter) ? Colours.valuePack : Colours.starterPack);
		leftWing.alpha = 0.5f;
		rightWing.color = ((namePack != CardPack.Starter) ? Colours.valuePack : Colours.starterPack);
		rightWing.alpha = 0.5f;
		specialPacksTable.repositionNow = true;
	}

	public void SetSale()
	{
		if (typePack != CardPack.Bronze && typePack != CardPack.Silver && typePack != CardPack.Gold)
		{
			salePart.SetActive(value: false);
			return;
		}
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(typePack);
		bool flag = num > 0;
		salePart.SetActive(flag);
		if (flag)
		{
			salePercentLabel.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
		}
	}

	public void InitGuiValues()
	{
		boxCollider.enabled = true;
		background.alpha = 1f;
		watchVideoTable.gameObject.SetActive(typePack == CardPack.None);
		specialPacksTable.gameObject.SetActive(typePack == CardPack.Starter || typePack == CardPack.Value);
		bottomButton.SetActive(value: true);
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotationSpecial component2 = content.GetComponent<TweenRotationSpecial>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		TweenScale component3 = GetComponent<TweenScale>();
		if (component3 != null)
		{
			component3.enabled = false;
		}
		base.transform.localPosition = mBasePosition;
		content.transform.localRotation = Quaternion.identity;
		base.transform.localScale = Vector3.one;
		SetSale();
		StopAllCoroutines();
		base.gameObject.SetActive(value: true);
	}

	public void PlayBuyAnimation(Transform owerlayTransform)
	{
		mAnimating = true;
		Vector3 middlePos = mBasePosition;
		middlePos.z = -24450f;
		base.transform.localPosition = middlePos;
		Vector3 vector = owerlayTransform.localPosition - base.transform.parent.parent.localPosition - base.transform.parent.localPosition;
		middlePos.y = 150f + vector.y;
		middlePos.x = vector.x;
		boxCollider.enabled = false;
		salePart.SetActive(value: false);
		specialPacksTable.gameObject.SetActive(value: false);
		bottomButton.SetActive(value: false);
		watchVideoTable.gameObject.SetActive(value: false);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 0.6f, middlePos);
		tweenPosition.delay = 0.2f;
		middlePos.y -= 150f;
		tweenPosition.onFinished = delegate
		{
			TweenPosition.Begin(base.gameObject, 0.2f, middlePos).delay = 0f;
			TweenScale ts = TweenScale.Begin(base.gameObject, 0.2f, Vector3.one * 1.2f);
			ts.delay = 0f;
			ts.onFinished = delegate
			{
				ts = TweenScale.Begin(base.gameObject, 0.2f, Vector3.one * 1.3f);
				ts.onFinished = delegate
				{
					InvokeAfter(delegate
					{
						HideCardPack();
					}, 0.1f);
				};
			};
		};
		TweenRotationSpecial.Begin(content, 0.6f, new Vector3(0f, 1f, 0f), 0f, 360f).delay = 0.2f;
	}

	private void HideCardPack()
	{
		mAnimating = false;
		base.gameObject.SetActive(value: false);
	}

	public void StopAnimationAndHide()
	{
		TweenPosition.Begin(base.gameObject, 0f, base.transform.localPosition).onFinished = null;
		TweenScale.Begin(base.gameObject, 0f, Vector3.one).onFinished = null;
		TweenRotationSpecial.Begin(content, 0f, new Vector3(0f, 1f, 0f), 0f, 0f).delay = 0f;
		HideCardPack();
	}
}
