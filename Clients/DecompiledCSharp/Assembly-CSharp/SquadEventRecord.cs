using UnityEngine;

public class SquadEventRecord : PoolableObject
{
	[Header("Width Setter")]
	public UIButtonSetter widthSetter;

	[Header("Header Part")]
	public GameObject headerPart;

	public UISprite headerBackground;

	public UISprite border;

	public UILabel labelReward;

	public UILabel tierReward;

	public UISprite checkSprite;

	public UILabel tierLabel;

	public UILabel tierProgress;

	[Header("Assignment Part")]
	public GameObject assignmentPart;

	public UISprite progressBar;

	public UISprite assignmentIcon;

	public UILabel assignmentDescription;

	public UILabel assignmentProgress;

	public void InitHeader(int reward, int tierNumber, float progress, float length, bool active)
	{
		widthSetter.SetWidth(length);
		headerPart.SetActive(value: true);
		assignmentPart.SetActive(value: false);
		float num = Mathf.Clamp01(progress);
		int num2 = Mathf.FloorToInt(num * 100f);
		bool flag = num == 1f;
		headerBackground.fillAmount = num;
		headerBackground.color = (flag ? Colours.goldTier : ((!active) ? Colours.gray : Colours.blue));
		headerBackground.alpha = 0.15f;
		border.color = (flag ? Colours.goldTier : ((!active) ? Colours.gray : Colours.blue));
		labelReward.color = ((!active) ? Colours.gray : Color.white);
		tierReward.text = MiscTools.FormatAssignmentNumber(reward);
		tierReward.color = ((!active) ? Colours.gray : Color.white);
		checkSprite.transform.localPosition = new Vector3(89f + tierReward.relativeSize.x * tierReward.transform.localScale.x, checkSprite.transform.localPosition.y, 0f);
		checkSprite.gameObject.SetActive(flag);
		tierLabel.text = string.Format("{0} {1}", Localization.Localize("ID_TIER"), tierNumber);
		tierLabel.color = (flag ? Colours.goldTier : ((!active) ? Colours.gray : Colours.blue));
		tierProgress.text = (flag ? Localization.Localize("ID_COMPLETED") : ((!active) ? string.Format("{0} {1}", Localization.Localize("ID_COMPLETETIER"), tierNumber - 1) : MiscTools.FormatNumberAsPercent(num2)));
		tierProgress.color = (flag ? Colours.goldTier : ((!active) ? Colours.gray : Colours.blue));
	}

	public void InitAssignment(Assignment assignment, float progress, float length, bool active)
	{
		widthSetter.SetWidth(length);
		headerPart.SetActive(value: false);
		assignmentPart.SetActive(value: true);
		float num = Mathf.Clamp01(progress);
		int num2 = Mathf.FloorToInt(num * 100f);
		bool flag = num == 1f;
		progressBar.fillAmount = num;
		progressBar.color = ((!flag) ? Colours.blue : Colours.goldTier);
		assignmentIcon.spriteName = assignment.assignmentPicture;
		assignmentIcon.MakePixelPerfect();
		assignmentIcon.transform.localPosition = new Vector3(assignmentIcon.transform.localPosition.x, (!(assignmentIcon.transform.localScale.y < 170f)) ? 10f : 4f, 0f);
		if (active)
		{
			assignmentDescription.text = ((!flag) ? assignment.blueDescription : assignment.goldDescription);
		}
		else
		{
			assignmentDescription.text = assignment.whiteDescription;
		}
		assignmentDescription.color = ((!active) ? Colours.gray : Color.white);
		assignmentProgress.text = MiscTools.FormatNumberAsPercent(num2);
		assignmentProgress.color = (flag ? Colours.goldTier : ((!active) ? Colours.gray : Colours.blue));
	}
}
