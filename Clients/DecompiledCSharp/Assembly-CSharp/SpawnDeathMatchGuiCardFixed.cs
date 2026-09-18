using UnityEngine;

public class SpawnDeathMatchGuiCardFixed : DeathMatchGuiCard
{
	public override void Show(SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition, bool instant = false)
	{
		base.Show(armyUnitDefinition);
		if (armyUnitDefinition != null)
		{
			HidePowerProgress(hide: false);
			TweenAlpha.Begin(selectedOverlay.gameObject, 0.3f, 0f).style = UITweener.Style.Once;
			TweenPosition.Begin(base.gameObject, (!instant) ? 0.3f : 0f, initPosition);
		}
		else
		{
			HidePowerProgress(hide: false);
			TweenPosition.Begin(base.gameObject, 0.3f, initPosition);
		}
	}

	protected override void AnimateSpawn()
	{
		TweenPosition.Begin(base.gameObject, 0.3f, initPosition - new Vector3(0f, 350f, 0f));
	}

	protected override void MoveCard()
	{
		selectedOverlay.transform.localScale = selectedOverlay.transform.localScale.ReplaceY(198f);
		TweenAlpha.Begin(selectedOverlay.gameObject, 0.3f, 0.3f).style = UITweener.Style.Once;
		HidePowerProgress(hide: true);
	}

	public override void DisableCard()
	{
		TweenAlpha.Begin(blueOverlay.gameObject, 0.5f, 0f);
		selectedOverlay.transform.localScale = selectedOverlay.transform.localScale.ReplaceY(250f);
		TweenAlpha.Begin(selectedOverlay.gameObject, 0.3f, 0.3f).style = UITweener.Style.Once;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(count.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.onFinished = delegate
		{
			mEnabled = false;
		};
		SetEnabled(mEnabled);
		GetComponent<UIButtonScale>().enabled = false;
	}

	public override void Hide()
	{
	}
}
