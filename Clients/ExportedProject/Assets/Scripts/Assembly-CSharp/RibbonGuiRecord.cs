using UnityEngine;

public class RibbonGuiRecord : PoolableObject
{
	[Header("Header")]
	public UILabel ribbonName;

	public UISprite ribbonHeaderBackground;

	[Header("Background")]
	public UISprite background;

	[Header("Ribbon")]
	public UISprite ribbonIcon;

	public UISprite ribbonIconBg;

	[Header("Amount")]
	public GameObject countObject;

	public UILabel counText;

	[Header("Description")]
	public UILabel ribbonDescription;

	[Header("Bottom")]
	public GameObject bottomPart;

	public UISprite warbugsIco;

	public UILabel warbugsLabel;

	[Header("Spacers")]
	public GameObject endScreenSpacer;

	public GameObject playerStatsSpacer;

	public void Initialize(RibbonManager.RibbonItemDefinition ribbonDef, int count, bool showMoney = true)
	{
		ribbonName.text = string.Format("{0} {1}", ribbonDef.name, Localization.Localize("ID_RIBBON"));
		ribbonIcon.spriteName = ribbonDef.iconName;
		ribbonIcon.MakePixelPerfect();
		ribbonIconBg.spriteName = ribbonDef.iconBgName;
		countObject.SetActive(count > 1);
		counText.text = $"x{count}";
		ribbonDescription.text = ribbonDef.description;
		bottomPart.SetActive(showMoney);
		if (showMoney)
		{
			warbugsLabel.text = MiscTools.FormatBigNumber(count * ribbonDef.warbucks);
		}
		endScreenSpacer.SetActive(showMoney);
		playerStatsSpacer.SetActive(!showMoney);
		ribbonHeaderBackground.transform.localScale = ribbonHeaderBackground.transform.localScale.ReplaceX((!showMoney) ? 570f : 612f);
		background.transform.localScale = background.transform.localScale.ReplaceX((!showMoney) ? 570f : 612f);
	}
}
