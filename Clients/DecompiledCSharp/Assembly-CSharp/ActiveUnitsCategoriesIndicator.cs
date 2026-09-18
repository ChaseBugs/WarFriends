using UnityEngine;

public class ActiveUnitsCategoriesIndicator : Core_BaseScript
{
	[Header("Left Side")]
	public UISprite leftBackground;

	public UISprite leftBorder;

	public UISprite leftMechanical;

	[Header("Center")]
	public UISprite categoryIcon;

	[Header("Right Side")]
	public UISprite rightBackground;

	public UISprite rightBorder;

	public UISprite rightMechanical;

	private LevelBehaviour.UnitType mCategory;

	public void Initialize(LevelBehaviour.UnitType categoryType)
	{
		mCategory = categoryType;
		categoryIcon.spriteName = GameVariables.unitCategory[categoryType].Value1;
		categoryIcon.MakePixelPerfect();
		categoryIcon.transform.localScale = new Vector3(categoryIcon.transform.localScale.x * 0.5f, categoryIcon.transform.localScale.y * 0.5f, 1f);
		SetEmpty(leftBackground, leftBorder, leftMechanical);
		SetEmpty(rightBackground, rightBorder, rightMechanical);
	}

	public void SetUnits(LevelBehaviour leftUnit, LevelBehaviour rightUnit)
	{
		if (leftUnit == null)
		{
			SetEmpty(leftBackground, leftBorder, leftMechanical);
		}
		else if (leftUnit.isSoldier)
		{
			SetSoldier(leftBackground, leftBorder, leftMechanical);
		}
		else
		{
			SetVehicle(leftBackground, leftBorder, leftMechanical);
		}
		if (rightUnit == null)
		{
			SetEmpty(rightBackground, rightBorder, rightMechanical);
		}
		else if (rightUnit.isSoldier)
		{
			SetSoldier(rightBackground, rightBorder, rightMechanical);
		}
		else
		{
			SetVehicle(rightBackground, rightBorder, rightMechanical);
		}
	}

	private void SetEmpty(UISprite background, UISprite border, UISprite mechanical)
	{
		background.color = Color.black;
		border.color = GameVariables.unitCategory[mCategory].Value2;
		mechanical.gameObject.SetActive(value: false);
	}

	private void SetSoldier(UISprite background, UISprite border, UISprite mechanical)
	{
		background.color = GameVariables.unitCategory[mCategory].Value2;
		border.color = Color.white;
		mechanical.gameObject.SetActive(value: false);
	}

	private void SetVehicle(UISprite background, UISprite border, UISprite mechanical)
	{
		background.color = GameVariables.unitCategory[mCategory].Value2;
		border.color = Color.white;
		mechanical.gameObject.SetActive(value: true);
	}
}
