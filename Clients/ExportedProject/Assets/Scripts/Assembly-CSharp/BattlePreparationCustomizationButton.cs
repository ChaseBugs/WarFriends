using System;
using System.Collections;
using UnityEngine;

public class BattlePreparationCustomizationButton : Core_BaseScript
{
	[Header("Core")]
	public GameObject camoButton;

	public UITexture actualLook;

	[Header("-New Unlock")]
	public GameObject unlockedCamoPart;

	public UITable unlockedCamoTable;

	public UILabel unlockedCamoNewLabel;

	public UISprite unlockedCamoNewBackground;

	public UILabel unlockedCamo;

	[Header("-Power Band Equipped")]
	public GameObject powerBandPart;

	public UISprite powerBandIcon;

	public UILabel powerBandType;

	public UISprite powerBandProgressBar;

	public UITable powerBandTable;

	public UILabel powerBandBonus;

	public UISprite powerBandBonusIcon;

	public UILabel powerBandTime;

	[Header("-Notification")]
	public UILabel notificationCamosNumber;

	public GameObject notificationCamosGO;

	private RadicalRoutine mUpdatingPowerBand;

	private PlayerVisual mPowerBand;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(camoButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		});
		unlockedCamoTable.onReposition = delegate
		{
			float val = 0f - unlockedCamoTable.padding.x - (unlockedCamo.transform.parent.localPosition.x - unlockedCamoTable.padding.x) / 2f;
			unlockedCamoTable.transform.localPosition = unlockedCamoTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void InitGUIValues()
	{
		SetCustomizationButton();
		NotificationCamos(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	public void DoAfterHide()
	{
		StopPowerBandUpdate();
	}

	public void InitBlank()
	{
		unlockedCamoPart.SetActive(value: false);
		powerBandPart.SetActive(value: false);
		NotificationCamos(0);
	}

	private void StartPowerBandUpdate()
	{
		StopPowerBandUpdate();
		mUpdatingPowerBand = RadicalRoutine.Create(UpdatePowerBandRoutine());
		StartCoroutine(RadicalRoutine.Run(mUpdatingPowerBand.enumerator));
	}

	private void StopPowerBandUpdate()
	{
		if (mUpdatingPowerBand != null)
		{
			mUpdatingPowerBand.Cancel();
			mUpdatingPowerBand = null;
		}
	}

	private IEnumerator UpdatePowerBandRoutine()
	{
		while (true)
		{
			if (!mPowerBand.isBought)
			{
				CamosManager.instance.CheckEquippedPowerBand();
				CamosManager.instance.CheckEquippedHelmet();
				SetCustomizationButton();
			}
			else
			{
				powerBandTime.text = MiscTools.PrintableTime((float)mPowerBand.remainingTime, "ID_GUI_POWERBANDOFF", string.Empty).ToUpperInvariant();
				powerBandProgressBar.fillAmount = mPowerBand.progress;
			}
			yield return new WaitForRealSeconds(0.333f);
		}
	}

	private void NotificationCamos(int number)
	{
		notificationCamosGO.SetActive(number > 0);
		notificationCamosNumber.text = MiscTools.FormatBigNumber(number);
	}

	private void SetCustomizationButton()
	{
		StopPowerBandUpdate();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(3);
		if (!playerVisual.isEmptyPowerBand)
		{
			unlockedCamoPart.SetActive(value: false);
			powerBandPart.SetActive(value: true);
			powerBandIcon.spriteName = playerVisual.icon;
			powerBandType.text = playerVisual.decalTypeName;
			powerBandBonus.text = playerVisual.decalValueString;
			powerBandBonusIcon.spriteName = playerVisual.decalMiniIcon;
			powerBandBonusIcon.color = playerVisual.decalMiniIconColor;
			powerBandBonusIcon.MakePixelPerfect();
			powerBandTable.repositionNow = true;
			mPowerBand = playerVisual;
			if (mPowerBand.tryOutVisual)
			{
				powerBandTime.text = Localization.Localize("ID_RENTED");
				powerBandProgressBar.fillAmount = 0f;
			}
			else
			{
				powerBandTime.text = MiscTools.PrintableTime((float)mPowerBand.remainingTime, "ID_GUI_POWERBANDOFF", string.Empty).ToUpperInvariant();
				powerBandProgressBar.fillAmount = mPowerBand.progress;
				StartPowerBandUpdate();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				unlockedCamoPart.SetActive(value: true);
				powerBandPart.SetActive(value: false);
				unlockedCamo.text = unlockedVisualWithNotification.name.ToUpper();
				MiscTools.SetUILabelRescale(unlockedCamo, 30f, 20f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 88);
				float val = 16f + unlockedCamoNewLabel.relativeSize.x * unlockedCamoNewLabel.transform.localScale.x;
				unlockedCamoNewBackground.transform.localScale = unlockedCamoNewBackground.transform.localScale.ReplaceX(val);
				unlockedCamoTable.repositionNow = true;
			}
			else
			{
				unlockedCamoPart.SetActive(value: false);
				powerBandPart.SetActive(value: false);
			}
		}
	}

	public void RenderMainPlayer()
	{
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(PlayerController.currentPlayer, useBackground: false, PlayerTexturePool.RenderType.Classic);
		actualLook.mainTexture = Singleton<ArmyPreviewCamera>.instance.player1Texture;
	}
}
