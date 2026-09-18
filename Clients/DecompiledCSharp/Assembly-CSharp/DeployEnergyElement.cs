using Google2u;
using UnityEngine;

public class DeployEnergyElement : Core_BaseScript
{
	[Header("Core")]
	public UISprite myEnergyBar;

	public UILabel myEnergyLabel;

	public UISprite opponentEnergyBar;

	public UILabel opponentEnergyLabel;

	public UISprite opponentEnergyIcon;

	private int mMyEnergy;

	private FloatObject mMyActualEnergy = new FloatObject(0f);

	private int mOpponentEnergy;

	private FloatObject mOpponentActualEnergy = new FloatObject(0f);

	private float mTimer;

	public bool shouldUpdate
	{
		set
		{
			if (!value)
			{
				StopAnimations();
			}
			base.gameObject.SetActive(value);
			if (value)
			{
				StopAnimations();
			}
		}
	}

	private int mMaxEnergy => 2 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;

	private void Update()
	{
		mTimer += Time.deltaTime;
		if (mTimer >= 0.333f)
		{
			mTimer -= 0.333f;
			UpdateValues();
			UpdateGui();
		}
	}

	public void InstantUpdate()
	{
		UpdateValues();
		StopAnimations();
	}

	private void UpdateValues()
	{
		mMyEnergy = Singleton<SpawningManagerDeathMatch>.instance.powerLeft;
		mOpponentEnergy = Singleton<SpawningManagerDeathMatch>.instance.powerLeftEnemy;
	}

	private void UpdateGui()
	{
		string text = MiscTools.FormatBigNumber(mMyEnergy);
		if (!myEnergyLabel.text.Equals(text))
		{
			myEnergyLabel.text = text;
			TweenScale tweenScale = TweenScale.Begin(myEnergyLabel.gameObject, 0.2f, new Vector3(35f, 35f, 1f), new Vector3(45f, 45f, 1f));
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = UITweener.Style.PingPong;
		}
		if (mMyEnergy != Mathf.RoundToInt(mMyActualEnergy.val * (float)mMaxEnergy))
		{
			mMyActualEnergy.val = (float)mMyEnergy / (float)mMaxEnergy;
			TweenProgressBar.Begin(myEnergyBar.gameObject, 0.25f, mMyActualEnergy).method = UITweener.Method.Linear;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			opponentEnergyLabel.text = string.Empty;
			TweenProgressBar component = opponentEnergyBar.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = false;
			}
			opponentEnergyBar.fillAmount = 0f;
			opponentEnergyIcon.gameObject.SetActive(value: false);
			return;
		}
		opponentEnergyIcon.gameObject.SetActive(value: true);
		string text2 = MiscTools.FormatBigNumber(mOpponentEnergy);
		if (!opponentEnergyLabel.text.Equals(text2))
		{
			opponentEnergyLabel.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(opponentEnergyLabel.gameObject, 0.2f, new Vector3(35f, 35f, 1f), new Vector3(45f, 45f, 1f));
			tweenScale2.NumOfRepetitions = 2;
			tweenScale2.style = UITweener.Style.PingPong;
		}
		if (mOpponentEnergy != Mathf.RoundToInt(mOpponentActualEnergy.val * (float)mMaxEnergy))
		{
			mOpponentActualEnergy.val = (float)mOpponentEnergy / (float)mMaxEnergy;
			TweenProgressBar.Begin(opponentEnergyBar.gameObject, 0.25f, mOpponentActualEnergy).method = UITweener.Method.Linear;
		}
	}

	private void StopAnimations()
	{
		TweenProgressBar component = myEnergyBar.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = false;
		}
		myEnergyBar.fillAmount = (float)mMyEnergy / (float)mMaxEnergy;
		TweenScale component2 = myEnergyLabel.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		myEnergyLabel.text = MiscTools.FormatBigNumber(mMyEnergy);
		component = opponentEnergyBar.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = false;
		}
		opponentEnergyBar.fillAmount = (float)mOpponentEnergy / (float)mMaxEnergy;
		component2 = opponentEnergyLabel.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		opponentEnergyLabel.text = MiscTools.FormatBigNumber(mOpponentEnergy);
	}
}
