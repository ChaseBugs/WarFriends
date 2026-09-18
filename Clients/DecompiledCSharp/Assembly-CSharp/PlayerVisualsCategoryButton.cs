using UnityEngine;

public class PlayerVisualsCategoryButton : PoolableObject
{
	[Header("Core")]
	public UISprite background;

	public UISprite icon;

	public UILabel label;

	[Header("Notification")]
	public UILabel notificationNumber;

	public GameObject notificationGO;

	[Header("Sale")]
	public GameObject salePart;

	private string mSelectedBackgroundButton = "menu-weapons-tab-active";

	private string mNormalBackgroundButton = "menu-weapons-tab";

	private PlayerVisualCategory mCategory;

	private bool mIsDecal;

	public PlayerVisualCategory category => mCategory;

	public void Highlight(bool setOn)
	{
		if (mIsDecal)
		{
			icon.color = ((!setOn) ? Colours.yellowDecal : Colours.blue);
			label.color = ((!setOn) ? Colours.yellowDecal : Colours.blue);
		}
		else
		{
			icon.color = ((!setOn) ? Color.white : Colours.blue);
			label.color = ((!setOn) ? Color.white : Colours.blue);
		}
		background.spriteName = ((!setOn) ? mNormalBackgroundButton : mSelectedBackgroundButton);
	}

	public void Notification()
	{
		int numberOfVisualCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfVisualCategoryNotifications(mCategory);
		notificationGO.SetActive(numberOfVisualCategoryNotifications > 0);
		notificationNumber.text = numberOfVisualCategoryNotifications.ToString();
	}

	public void Sale()
	{
		salePart.SetActive(value: false);
	}

	public void Initialize(PlayerVisualCategory category, int count)
	{
		mCategory = category;
		mIsDecal = mCategory as PlayerVisualCategoryPowerBands != null;
		label.text = Localization.Localize(category.buttonName);
		Notification();
		Sale();
		icon.spriteName = category.icon;
		icon.MakePixelPerfect();
		Highlight(setOn: false);
		float num = UIRoot.list[0].activeWidth / (float)count - 5f;
		Vector3 localScale = background.transform.localScale;
		localScale.x = num;
		background.transform.localScale = localScale;
		Vector3 localPosition = notificationGO.transform.localPosition;
		localPosition.x = num - 50f;
		notificationGO.transform.localPosition = localPosition;
		BoxCollider component = GetComponent<BoxCollider>();
		Vector3 center = component.center;
		center.x = num / 2f;
		component.center = center;
		Vector3 size = component.size;
		size.x = num + 20f;
		component.size = size;
	}

	private void OnClick()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectCategory(this);
	}
}
