using UnityEngine;

public class GuiFocusManager : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.currentScreen == null || !Singleton<GuiManager>.instance.currentScreen.isFullyShowed)
			{
				return;
			}
			IGuiDialog topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.isTutorial || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.currentScreen != null && !flag)
			{
				Singleton<GuiManager>.instance.currentScreen.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.Menu) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.currentScreen == null) && Singleton<GuiManager>.instance.currentScreen.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.currentScreen != null)
		{
			Singleton<GuiManager>.instance.currentScreen.OnMenu();
		}
	}
}
