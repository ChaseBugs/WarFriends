using System.Collections.Generic;
using UnityEngine;

public class SetInstantBattleRewards : Core_BaseScript
{
	[Header("XP Reward")]
	public GameObject xpReward;

	public UILabel xpRewardValue;

	public UILabel xpRewardValueComposed;

	[Header("Warbucks Reward")]
	public GameObject warbucksReward;

	public UISprite warbucksIcon;

	public UILabel warbucksRewardValue;

	public UILabel warbucksRewardValueComposed;

	[Header("Gold Reward")]
	public GameObject goldReward;

	public UISprite goldIcon;

	public UILabel goldRewardValue;

	[Header("Warcards")]
	public GameObject warcardReward;

	[Header("Warcard1")]
	public GameObject warcardReward1;

	public UISprite warcardRewardBackground1;

	public UISprite warcardRewardIcon1;

	public UITexture warcardRewardTexture1;

	public UISprite warcardRewardSmallIcon1;

	public UILabel warcardRewardBonusName1;

	[Header("Warcard2")]
	public GameObject warcardReward2;

	public UISprite warcardRewardBackground2;

	public UISprite warcardRewardIcon2;

	public UITexture warcardRewardTexture2;

	public UISprite warcardRewardSmallIcon2;

	public UILabel warcardRewardBonusName2;

	[Header("Warcard3")]
	public GameObject warcardReward3;

	public UISprite warcardRewardBackground3;

	public UISprite warcardRewardIcon3;

	public UITexture warcardRewardTexture3;

	public UISprite warcardRewardSmallIcon3;

	public UILabel warcardRewardBonusName3;

	[Header("Warcard4")]
	public GameObject warcardReward4;

	public UISprite warcardRewardBackground4;

	public UISprite warcardRewardIcon4;

	public UITexture warcardRewardTexture4;

	public UISprite warcardRewardSmallIcon4;

	public UILabel warcardRewardBonusName4;

	[Header("Warcard5")]
	public GameObject warcardReward5;

	public UISprite warcardRewardBackground5;

	public UISprite warcardRewardIcon5;

	public UITexture warcardRewardTexture5;

	public UISprite warcardRewardSmallIcon5;

	public UILabel warcardRewardBonusName5;

	[Header("No Reward")]
	public GameObject noReward;

	[Header("Box")]
	public UISprite border;

	public UISprite background;

	public UISprite glow;

	public UIPanel reflexion;

	public UISprite waiting;

	public GameObject particles;

	private bool mInitializing;

	private void ActivateReward(bool xp, bool warbucks, bool gold, bool warcard, bool none, bool efx, bool wait)
	{
		xpReward.gameObject.SetActive(xp);
		warbucksReward.gameObject.SetActive(warbucks);
		goldReward.gameObject.SetActive(gold);
		warcardReward.gameObject.SetActive(warcard);
		noReward.gameObject.SetActive(none);
		glow.gameObject.SetActive(efx);
		reflexion.gameObject.SetActive(efx);
		particles.gameObject.SetActive(efx);
		waiting.gameObject.SetActive(wait);
	}

	public void InitializeXP(int ammount, int multiplier, float animateTo)
	{
		if (!mInitializing)
		{
			mInitializing = true;
			ActivateReward(xp: true, warbucks: false, gold: false, warcard: false, none: false, efx: true, wait: false);
			xpReward.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
			xpRewardValue.text = string.Format("{0} {1}{2}[-]", "0", Colours.stringBlue, Localization.Localize("ID_XP"));
			xpRewardValueComposed.text = $"{MiscTools.FormatBigNumber(ammount / multiplier)} x {Colours.stringBlue}{MiscTools.FormatBigNumber(multiplier)}[-]";
			AnimateReward(xpReward);
			TweenXPTextCounter.Begin(xpRewardValue.gameObject, 0.6f, new IntObject(0), new IntObject(ammount)).maxWidth = 410;
			TweenProgressBar tweenProgressBar = TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.progressSpriteWhite.gameObject, 0.5f, new FloatObject(animateTo));
			tweenProgressBar.onFinished = delegate
			{
				TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.progressSprite.gameObject, 0.5f, new FloatObject(animateTo));
			};
		}
	}

	public void InitializeWarbucks(int ammount, int multiplier = 0)
	{
		if (!mInitializing)
		{
			mInitializing = true;
			ActivateReward(xp: false, warbucks: true, gold: false, warcard: false, none: false, efx: true, wait: false);
			warbucksReward.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
			warbucksRewardValue.text = MiscTools.FormatBigNumber(ammount);
			float num = warbucksRewardValue.transform.localScale.x * warbucksRewardValue.relativeSize.x;
			float num2 = (num - 158f) / 4f;
			warbucksIcon.transform.localPosition = warbucksIcon.transform.localPosition.AddX(0f - num2);
			warbucksRewardValue.transform.localPosition = warbucksRewardValue.transform.localPosition.AddX(num2);
			warbucksRewardValueComposed.text = ((multiplier != 0) ? $"{MiscTools.FormatBigNumber(ammount / multiplier)} x {Colours.stringBlue}{MiscTools.FormatBigNumber(multiplier)}[-]" : string.Empty);
			AnimateReward(warbucksReward);
			Debug.Log("warbucks initialized");
		}
	}

	public void InitializeGold(int ammount)
	{
		if (!mInitializing)
		{
			mInitializing = true;
			ActivateReward(xp: false, warbucks: false, gold: true, warcard: false, none: false, efx: true, wait: false);
			goldReward.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
			goldRewardValue.text = MiscTools.FormatBigNumber(ammount);
			float num = goldRewardValue.transform.localScale.x * goldRewardValue.relativeSize.x;
			float num2 = (num - 104f) / 4f;
			goldIcon.transform.localPosition = goldIcon.transform.localPosition.AddX(0f - num2);
			goldRewardValue.transform.localPosition = goldRewardValue.transform.localPosition.AddX(num2);
			AnimateReward(goldReward);
		}
	}

	public void InitializeWarcard(List<Card> warcards)
	{
		if (!mInitializing)
		{
			mInitializing = true;
			ActivateReward(xp: false, warbucks: false, gold: false, warcard: true, none: false, efx: true, wait: false);
			warcardReward.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
			warcardReward1.SetActive(value: false);
			warcardReward2.SetActive(value: false);
			warcardReward3.SetActive(value: false);
			warcardReward4.SetActive(value: false);
			warcardReward5.SetActive(value: false);
			switch (warcards.Count)
			{
			default:
				return;
			case 1:
				warcardReward3.SetActive(value: true);
				warcards[0].SetUpSmallCard(warcardRewardBackground3, warcardRewardIcon3, warcardRewardSmallIcon3, warcardRewardBonusName3);
				break;
			case 2:
				warcardReward2.SetActive(value: true);
				warcardReward4.SetActive(value: true);
				warcards[0].SetUpSmallCard(warcardRewardBackground2, warcardRewardIcon2, warcardRewardSmallIcon2, warcardRewardBonusName2);
				warcards[1].SetUpSmallCard(warcardRewardBackground4, warcardRewardIcon4, warcardRewardSmallIcon4, warcardRewardBonusName4);
				break;
			case 3:
				warcardReward1.SetActive(value: true);
				warcardReward3.SetActive(value: true);
				warcardReward5.SetActive(value: true);
				warcards[0].SetUpSmallCard(warcardRewardBackground1, warcardRewardIcon1, warcardRewardSmallIcon1, warcardRewardBonusName1);
				warcards[1].SetUpSmallCard(warcardRewardBackground3, warcardRewardIcon3, warcardRewardSmallIcon3, warcardRewardBonusName3);
				warcards[2].SetUpSmallCard(warcardRewardBackground5, warcardRewardIcon5, warcardRewardSmallIcon5, warcardRewardBonusName5);
				break;
			case 4:
				warcardReward1.SetActive(value: true);
				warcardReward2.SetActive(value: true);
				warcardReward4.SetActive(value: true);
				warcardReward5.SetActive(value: true);
				warcards[0].SetUpSmallCard(warcardRewardBackground1, warcardRewardIcon1, warcardRewardSmallIcon1, warcardRewardBonusName1);
				warcards[1].SetUpSmallCard(warcardRewardBackground2, warcardRewardIcon2, warcardRewardSmallIcon2, warcardRewardBonusName2);
				warcardReward2.transform.localPosition = warcardReward2.transform.localPosition.ReplaceX(-50f);
				warcards[2].SetUpSmallCard(warcardRewardBackground4, warcardRewardIcon4, warcardRewardSmallIcon4, warcardRewardBonusName4);
				warcardReward4.transform.localPosition = warcardReward4.transform.localPosition.ReplaceX(50f);
				warcards[3].SetUpSmallCard(warcardRewardBackground5, warcardRewardIcon5, warcardRewardSmallIcon5, warcardRewardBonusName5);
				break;
			case 5:
				warcardReward1.SetActive(value: true);
				warcardReward2.SetActive(value: true);
				warcardReward3.SetActive(value: true);
				warcardReward4.SetActive(value: true);
				warcardReward5.SetActive(value: true);
				warcards[0].SetUpSmallCard(warcardRewardBackground1, warcardRewardIcon1, warcardRewardSmallIcon1, warcardRewardBonusName1);
				warcards[1].SetUpSmallCard(warcardRewardBackground2, warcardRewardIcon2, warcardRewardSmallIcon2, warcardRewardBonusName2);
				warcards[2].SetUpSmallCard(warcardRewardBackground3, warcardRewardIcon3, warcardRewardSmallIcon3, warcardRewardBonusName3);
				warcards[3].SetUpSmallCard(warcardRewardBackground4, warcardRewardIcon4, warcardRewardSmallIcon4, warcardRewardBonusName4);
				warcards[4].SetUpSmallCard(warcardRewardBackground5, warcardRewardIcon5, warcardRewardSmallIcon5, warcardRewardBonusName5);
				break;
			}
			AnimateReward(warcardReward, 0.7f);
		}
	}

	public void InitializeNoReward()
	{
		if (!mInitializing)
		{
			mInitializing = true;
			ActivateReward(xp: false, warbucks: false, gold: false, warcard: false, none: true, efx: false, wait: false);
			noReward.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
			AnimateNoReward();
		}
	}

	public void InitializeWaiting()
	{
		ActivateReward(xp: false, warbucks: false, gold: false, warcard: false, none: false, efx: false, wait: true);
	}

	public void ResetValues()
	{
		mInitializing = false;
		warcardReward2.transform.localPosition = warcardReward2.transform.localPosition.ReplaceX(-75f);
		warcardReward4.transform.localPosition = warcardReward4.transform.localPosition.ReplaceX(75f);
		warbucksIcon.transform.localPosition = warbucksIcon.transform.localPosition.ReplaceX(-100f);
		warbucksRewardValue.transform.localPosition = warbucksRewardValue.transform.localPosition.ReplaceX(64f);
		goldIcon.transform.localPosition = goldIcon.transform.localPosition.ReplaceX(-70f);
		goldRewardValue.transform.localPosition = goldRewardValue.transform.localPosition.ReplaceX(70f);
	}

	private void AnimateReward(GameObject reward, float size = 1f)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampObjectiveComplete);
		TweenAlpha.Begin(glow.gameObject, 0.35f, 0f, 1f);
		ParticleSystem component = particles.GetComponent<ParticleSystem>();
		if (component != null)
		{
			component.Play();
		}
		Vector3 borderBackgroundScale = border.transform.localScale;
		TweenScale tweenScale = TweenScale.Begin(border.gameObject, 0.15f, borderBackgroundScale.MultiplyXY(1.4f));
		tweenScale.delay = 0f;
		tweenScale.onFinished = delegate
		{
			TweenScale.Begin(border.gameObject, 0.25f, borderBackgroundScale);
		};
		TweenColor.Begin(background.gameObject, 0.15f, Colours.blue.ReplaceA(0.2f));
		TweenScale tweenScale2 = TweenScale.Begin(background.gameObject, 0.15f, borderBackgroundScale.MultiplyXY(0.7f));
		tweenScale2.delay = 0f;
		tweenScale2.onFinished = delegate
		{
			TweenScale.Begin(background.gameObject, 0.25f, borderBackgroundScale.MultiplyXY(1.4f));
			TweenAlpha tweenAlpha = TweenAlpha.Begin(background.gameObject, 0.1f, 0f);
			tweenAlpha.from = 0.2f;
			tweenAlpha.delay = 0.15f;
			TweenScale tweenScale3 = TweenScale.Begin(reward.gameObject, 0.15f, new Vector3(1.3f, 1.3f, 1f).MultiplyXY(size));
			tweenScale3.delay = 0f;
			tweenScale3.onFinished = delegate
			{
				TweenScale.Begin(reward.gameObject, 0.15f, Vector3.one.MultiplyXY(size));
				mInitializing = false;
				GuiElementSingle<InstantBattleResultsDialog>.instance.animationFinished = true;
			};
		};
	}

	private void AnimateNoReward()
	{
		Vector3 borderBackgroundScale = border.transform.localScale;
		TweenScale tweenScale = TweenScale.Begin(border.gameObject, 0.15f, borderBackgroundScale.MultiplyXY(1.4f));
		tweenScale.delay = 0f;
		tweenScale.onFinished = delegate
		{
			TweenScale.Begin(border.gameObject, 0.25f, borderBackgroundScale);
		};
		TweenScale tweenScale2 = TweenScale.Begin(background.gameObject, 0.15f, borderBackgroundScale.MultiplyXY(0.7f));
		tweenScale2.delay = 0f;
		tweenScale2.onFinished = delegate
		{
			TweenScale.Begin(background.gameObject, 0.25f, borderBackgroundScale.MultiplyXY(1.4f));
			TweenScale tweenScale3 = TweenScale.Begin(noReward, 0.15f, new Vector3(1.3f, 1.3f, 1f));
			tweenScale3.delay = 0f;
			tweenScale3.onFinished = delegate
			{
				TweenScale.Begin(noReward, 0.15f, Vector3.one);
				mInitializing = false;
				GuiElementSingle<InstantBattleResultsDialog>.instance.animationFinished = true;
			};
		};
	}
}
