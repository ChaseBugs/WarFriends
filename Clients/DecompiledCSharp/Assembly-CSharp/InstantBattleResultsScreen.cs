using System;
using Google2u;
using UnityEngine;

public class InstantBattleResultsScreen : GuiScreenSingle<InstantBattleResultsScreen>
{
	[Header("Core")]
	public InstantBattleAnimation backgroundAnimation;

	public UIButton skipButton;

	[Header("Animation Objects")]
	public UISprite flash;

	public GameObject[] xpLabels;

	public GameObject[] wbLabels;

	[Header("Additional Info")]
	public int instantBattles;

	protected override void InitControls()
	{
		backgroundAnimation.Showed += delegate
		{
			backgroundAnimation.StartAnimation();
			TweenAlpha.Begin(flash.gameObject, 0.5f, 1f, 0f);
			skipButton.gameObject.SetActive(value: true);
		};
		backgroundAnimation.FInished += delegate
		{
			ShowDialog(base.gameObject);
		};
		UIEventListener uIEventListener = UIEventListener.Get(skipButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowDialog));
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
	}

	private void ShowDialog(GameObject go)
	{
		if (!GuiElementSingle<InstantBattleResultsDialog>.instance.isShowed)
		{
			backgroundAnimation.StopAllCoroutines();
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.GameOverWin);
			FlashScreen(delegate
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleResultsDialog>.instance, 0f);
			});
			skipButton.gameObject.SetActive(value: false);
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (isShowed && action == DatabaseAction.InstantBattle && !GuiElementSingle<InstantBattleResultsDialog>.instance.isShowed)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			GuiScreenSingle<BattlePreparationScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	public override void InitGUIValues()
	{
		TweenAlpha.Begin(flash.gameObject, 0.05f, 0f, 1f);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Fight);
		skipButton.gameObject.SetActive(value: false);
		backgroundAnimation.Show();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		BeforeHideReset();
		backgroundAnimation.Hide();
		if (Singleton<GuiManager>.instance.toBeShowedUp != null)
		{
			Singleton<GuiManager>.instance.toBeShowedUp.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	public void BeforeHideReset()
	{
		LevelManager.instance.isLevelUp = false;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
		if (GuiElementSingle<InstantBattleResultsDialog>.instance.isShowed)
		{
			GuiElementSingle<InstantBattleResultsDialog>.instance.HideDialog();
		}
		Singleton<MessageManager>.instance.StopMessageCoroutine();
	}

	public void FlashScreen(Action Action)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(flash.gameObject, 0.05f, 0f, 1f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(flash.gameObject, 1f, 1f, 0f);
			if (Action != null)
			{
				InvokeAfterRealTime(delegate
				{
					Action();
				}, 0.2f);
			}
		};
	}

	public void ShowAgain()
	{
		instantBattles = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		backgroundAnimation.DestroyEnemies();
		BeforeHideReset();
		FlashScreenUp();
		InitGUIValues();
	}

	public void AfterDialogExit()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public void FlashScreenUp()
	{
		TweenAlpha.Begin(flash.gameObject, 0.05f, 0f, 1f);
	}

	public void ShowLabels(Vector3 worldPosition, int index)
	{
		for (int i = 0; i < 4; i++)
		{
			GameObject gameObject = ((!(UnityEngine.Random.Range(0f, 1f) > 0.75f)) ? xpLabels[i + index * 4] : wbLabels[i + index * 4]);
			Vector3 point = backgroundAnimation.GetCamera().WorldToViewportPoint(worldPosition);
			point = Singleton<GuiManager>.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			gameObject.transform.position = point;
			point = gameObject.transform.localPosition.ReplaceZ(0f).AddY((float)(index + 1) * 10f + 50f + (float)i * 55f);
			gameObject.transform.localPosition = point;
			AnimateLabel(gameObject, (float)i * 0.07f);
		}
	}

	private void AnimateLabel(GameObject label, float delay)
	{
		for (int i = 0; i < label.transform.childCount; i++)
		{
			if (i == 2)
			{
				TweenAlpha.Begin(label.transform.GetChild(i).gameObject, 0.7f, 0.8f, 0f).delay = delay;
			}
			else
			{
				TweenAlpha.Begin(label.transform.GetChild(i).gameObject, 0.25f, 0f, 0.8f).delay = delay;
			}
		}
		TweenScale tweenScale = TweenScale.Begin(label, 0.25f, Vector3.one);
		tweenScale.delay = delay;
		tweenScale.onFinished = delegate
		{
			TweenScale.Begin(label, 0.7f, new Vector3(0f, 0f, 1f));
			for (int j = 0; j < label.transform.childCount; j++)
			{
				if (j != 2)
				{
					TweenAlpha.Begin(label.transform.GetChild(j).gameObject, 0.7f, 0.8f, 0f);
				}
			}
		};
	}

	public override void OnBack()
	{
		if (skipButton.gameObject.activeInHierarchy)
		{
			ShowDialog(base.gameObject);
		}
	}
}
