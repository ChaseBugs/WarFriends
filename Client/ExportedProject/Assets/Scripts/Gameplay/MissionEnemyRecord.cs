using UnityEngine;

public class MissionEnemyRecord : PoolableObject
{
	[Header("Core")]
	[SerializeField]
	private UISprite mArmyIcon;

	[SerializeField]
	private UILabel mUnitLevel;

	[SerializeField]
	[Header("Bottom")]
	private GameObject mBottomPart;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private UILabel mNameLabel;

	public void CONKDIBIPBH(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize(".");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1520f / mArmyIcon.transform.localScale.x, 0f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void CKOIIPAGCNO(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("updating GC to: ");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(519f / mArmyIcon.transform.localScale.x, 1826f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void NDIJBPIDGOF(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("doubleValue");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1505f / mArmyIcon.transform.localScale.x, 205f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void FIDIINBHKDG(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("-ABILITYMAXDESC");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(831f / mArmyIcon.transform.localScale.x, 709f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void OAMBDKHLJKI(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("Different army power \"{0}\" and \"{1}\"\n");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1458f / mArmyIcon.transform.localScale.x, 368f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void JPBOGGKMAON(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("ID_PLAYERLEAGUEPROCESSINGHINT");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(57f / mArmyIcon.transform.localScale.x, 207f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void Initialize(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("ID_BOSS");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(162f / mArmyIcon.transform.localScale.x, 118f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void MFMJPBCIHEH(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("N0");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(852f / mArmyIcon.transform.localScale.x, 113f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void HOAMHAAHEHP(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("null");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1086f / mArmyIcon.transform.localScale.x, 1167f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void EPAHIKLPNNB(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("PlayeScifiParticles");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(191f / mArmyIcon.transform.localScale.x, 993f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void DDHCMFLIABO(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("Friend {0} {1}");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(910f / mArmyIcon.transform.localScale.x, 828f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void IGPOLIPPGBP(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("FB: Calling On SessionOpenedEvent Manually");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1690f / mArmyIcon.transform.localScale.x, 450f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void HBDEPMJNLEK(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("Midnight");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1278f / mArmyIcon.transform.localScale.x, 1171f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void OMNEGAAKOCF(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("ID_INVITEWILLBEACTIVEFOR");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(89f / mArmyIcon.transform.localScale.x, 187f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void HEGPFIGACED(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("Warbucks");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1468f / mArmyIcon.transform.localScale.x, 1931f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void MKENDIKJPLJ(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("Spend_Gold_On_Army");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1348f / mArmyIcon.transform.localScale.x, 955f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void CFIAHPMMJOE(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("DebugLog");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1484f / mArmyIcon.transform.localScale.x, 1786f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void PBEFOOADBPG(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("Gold");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(731f / mArmyIcon.transform.localScale.x, 652f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void FPPLMOLHGFD(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("Gold - League:{0} Battle:{1} Extra:{2} Winstreak:{3} (offer mult {4})\n");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1148f / mArmyIcon.transform.localScale.x, 1235f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void ACJCGDPGNAN(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("id");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(587f / mArmyIcon.transform.localScale.x, 1162f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void PONFOKHPMMO(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("AccountLoginComplete(");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(65f / mArmyIcon.transform.localScale.x, 1028f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void AMFDNBJBPLB(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("GameLoginManager: Logout from facebook");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(207f / mArmyIcon.transform.localScale.x, 980f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void AFHMOPJGNBM(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("com/google/android/gms/games/Games");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1470f / mArmyIcon.transform.localScale.x, 1669f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void AJEGOKKKLOL(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("Wrong_Category");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1497f / mArmyIcon.transform.localScale.x, 1767f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void KOABMGAPCKP(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = !HJFBPIODDGH.isVeteran && HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("09_25_2015");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1724f / mArmyIcon.transform.localScale.x, 726f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}

	public void ACBHGJCMCPG(MissionUnit HJFBPIODDGH)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HJFBPIODDGH.behaviourIndex];
		bool flag = HJFBPIODDGH.isVeteran || HJFBPIODDGH.isElite;
		mBottomPart.SetActive(flag);
		mUnitLevel.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HJFBPIODDGH.level) : string.Empty);
		if (flag)
		{
			mArmyIcon.spriteName = ((!HJFBPIODDGH.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
			mBackground.color = Colours.blueElite;
			mNameLabel.text = Localization.Localize("reloadTime");
		}
		else
		{
			mArmyIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		}
		mArmyIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1038f / mArmyIcon.transform.localScale.x, 908f / mArmyIcon.transform.localScale.y);
		mArmyIcon.transform.localScale = mArmyIcon.transform.localScale.MultiplyXY(multiplier);
	}
}
