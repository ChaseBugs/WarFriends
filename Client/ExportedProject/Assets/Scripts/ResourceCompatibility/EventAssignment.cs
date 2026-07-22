using System;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public abstract class EventAssignment
{
	private EventAssignmentConfig mConfig;

	public GameReward reward { get; private set; }

	public int eventPointsReward => 0;

	public int currentValue => 0;

	public int totalValue => 0;

	public string param => null;

	public string localizedString => null;

	public int day => 0;

	public int indexInList { get; set; }

	public virtual string title => null;

	public virtual string text => null;

	public virtual Color assignmentColor => default(Color);

	public virtual string assignmentColorString => null;

	public virtual string dayBackground => null;

	public float progress => 0f;

	public string progressString => null;

	public bool completed => false;

	public bool claimed => false;

	private EventAssignmentManager.EventAssignmentProgress mData => null;

	public bool RequiresConfirmationBeforeClaiming => false;

	~EventAssignment()
	{
	}

	public void Init(EventAssignmentConfig config)
	{
	}

	protected virtual void OnInitialized()
	{
	}

	public virtual void OnBeforeGameStarted()
	{
	}

	protected virtual void OnGameEnded(GameController.ALOAMODMHMO gameEndReason)
	{
	}

	public void Claim()
	{
	}

	public virtual void Update()
	{
	}

	public virtual int RevertMatch()
	{
		return 0;
	}

	public abstract int Evaluate();

	public void RequestRewardConfirmation(Action<bool> onComplete)
	{
	}
}
