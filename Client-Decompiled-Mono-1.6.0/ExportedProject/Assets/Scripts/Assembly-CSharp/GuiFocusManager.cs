using UnityEngine;

public class GuiFocusManager : MonoBehaviour
{
	private void DIOAOBFDPMH()
	{
		if (Input.GetKeyDown((KeyCode)(-52)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-33)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void BJGOJDGMIBI()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.DAIEAMEFGIE() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-78)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void IODGCIIDJEK()
	{
		if (Input.GetKeyDown((KeyCode)(-62)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-166)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void GCOJHEDPIKL()
	{
		if (Input.GetKeyDown((KeyCode)(-93)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-80)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void CJPFLJAAODD()
	{
		if (Input.GetKeyDown(KeyCode.W))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed)
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.isTutorial || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.AIKPJGLHLLO();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-13)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void INHEEMEAIDJ()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)135) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void PHABEKGALCE()
	{
		if (Input.GetKeyDown((KeyCode)65))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-150)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void NHEOMLPEBLC()
	{
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-76)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void NBFMDCFFBIJ()
	{
		if (Input.GetKeyDown((KeyCode)75))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed)
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.AIKPJGLHLLO();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-1)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void LPFGBKIINMP()
	{
		if (Input.GetKeyDown((KeyCode)(-79)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.DAIEAMEFGIE() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.RightBracket) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void LEODNPHAEAE()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.U) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void FAHGDKLEKMN()
	{
		if (Input.GetKeyDown((KeyCode)(-81)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.BAKCODKBCPJ() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)137) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void GBEDFIAHCDH()
	{
		if (Input.GetKeyDown(KeyCode.Colon))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-67)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void OFNEGNKMKKG()
	{
		if (Input.GetKeyDown(KeyCode.Asterisk))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.isTutorial || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.Space) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void MNJPIOEHBEM()
	{
		if (Input.GetKeyDown(KeyCode.U))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.DAIEAMEFGIE() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-147)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void CHHKMBGOMJJ()
	{
		if (Input.GetKeyDown((KeyCode)(-9)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.RightBracket) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void NIGOADNHHFC()
	{
		if (Input.GetKeyDown((KeyCode)(-70)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed)
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-95)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed)
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
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
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.Menu) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void IDPOHKDKDNL()
	{
		if (Input.GetKeyDown((KeyCode)(-113)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-7)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void MGAIKDBOPKI()
	{
		if (Input.GetKeyDown((KeyCode)(-80)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)73) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void BLOBBBLIJPI()
	{
		if (Input.GetKeyDown((KeyCode)(-66)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed)
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-69)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void GFPPJNOENLE()
	{
		if (Input.GetKeyDown((KeyCode)(-26)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.BAKCODKBCPJ() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.AIKPJGLHLLO();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.At) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void CDJBEAIDHKH()
	{
		if (Input.GetKeyDown((KeyCode)(-10)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.At) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void LNHOPPAFMPH()
	{
		if (Input.GetKeyDown((KeyCode)(-67)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.isTutorial || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)30) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void KNIAAECLFFK()
	{
		if (Input.GetKeyDown((KeyCode)(-95)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)4) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void CBOIHLDFKPI()
	{
		if (Input.GetKeyDown((KeyCode)(-30)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.DAIEAMEFGIE() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-46)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void MGKCNLDGNEM()
	{
		if (Input.GetKeyDown((KeyCode)(-30)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)138) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void JAFBNNAACCL()
	{
		if (Input.GetKeyDown((KeyCode)80))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed)
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.AIKPJGLHLLO();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-47)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void ADLJAKCCELG()
	{
		if (Input.GetKeyDown((KeyCode)(-73)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)197) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void OOCJOBIIKAH()
	{
		if (Input.GetKeyDown((KeyCode)(-108)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)129) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void ANLFCJJCGMG()
	{
		if (Input.GetKeyDown((KeyCode)(-2)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.isTutorial || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.AIKPJGLHLLO();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-132)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void EKPBOMOMMFB()
	{
		if (Input.GetKeyDown((KeyCode)1))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-60)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void JOCHCGHAIGH()
	{
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.BAKCODKBCPJ() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-159)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void HKPIHGBKAHO()
	{
		if (Input.GetKeyDown((KeyCode)(-51)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OIEPFDKMCNC();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-85)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void DLJAGKBLJNC()
	{
		if (Input.GetKeyDown((KeyCode)(-116)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.X) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void BPNLIABHCPN()
	{
		if (Input.GetKeyDown((KeyCode)81))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.AIKPJGLHLLO();
				return;
			}
		}
		if (Input.GetKeyDown(KeyCode.Space) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}

	private void HDLDMGEFCEJ()
	{
		if (Input.GetKeyDown((KeyCode)(-128)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)5) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void BAHDLPDOCDO()
	{
		if (Input.GetKeyDown((KeyCode)6))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.GENKPBNDOCB();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.DAIEAMEFGIE() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)193) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void LIMHNKKJODK()
	{
		if (Input.GetKeyDown((KeyCode)(-106)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OnBack();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.AIKPJGLHLLO();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-132)) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BJNBLINDAED() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void JBGDAOIDBGF()
	{
		if (Input.GetKeyDown((KeyCode)79))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.AIKPJGLHLLO();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)169) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void DFBPBGDJKOG()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.HideRightContent())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)10) && !GuiElementSingle<LoadingDialog>.instance.isShowed && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.LHDGJFHPJNM() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.OnMenu();
		}
	}

	private void BOPGJFGMNJM()
	{
		if (Input.GetKeyDown((KeyCode)(-71)))
		{
			if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
			{
				GuiElementSingle<LoadingDialog>.instance.OIEPFDKMCNC();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = !Singleton<GameController>.instance.BAKCODKBCPJ() && !TutorialManagerStage4.instance.isTutorialRunning && TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.GENKPBNDOCB();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-170)) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.AFOFDNJOJHG() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.KHICCPENMAM();
		}
	}

	private void CKFENMDKKPE()
	{
		if (Input.GetKeyDown((KeyCode)81))
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				GuiElementSingle<LoadingDialog>.instance.AIKPJGLHLLO();
				return;
			}
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == null || !Singleton<GuiManager>.instance.AODFEHKBJIN.MHAIBHBGBOO())
			{
				return;
			}
			PAIIOKBBHBC topMostDialog = DialogManager.instance.GetTopMostDialog();
			if (topMostDialog != null)
			{
				topMostDialog.OnBack();
				return;
			}
			if (GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE())
			{
				return;
			}
			bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning;
			if (Singleton<GuiManager>.instance.AODFEHKBJIN != null && !flag)
			{
				Singleton<GuiManager>.instance.AODFEHKBJIN.OnBack();
				return;
			}
		}
		if (Input.GetKeyDown((KeyCode)132) && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !(Singleton<GuiManager>.instance.AODFEHKBJIN == null) && Singleton<GuiManager>.instance.AODFEHKBJIN.BKIGLABDGCP() && DialogManager.instance.GetTopMostDialog() == null && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed && Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.AODFEHKBJIN.EOLMLJELEAK();
		}
	}
}
