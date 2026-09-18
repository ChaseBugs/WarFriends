using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class MessageManager : Singleton<MessageManager>
{
	[HideInInspector]
	public SquadWarsEndedMessage lastRewardMessage;

	[HideInInspector]
	public DepositWarcards lastDepositWarcardsMessage;

	private Dictionary<string, DatabaseMessage> mMessages = new Dictionary<string, DatabaseMessage>();

	private Dictionary<string, DatabaseMessage> mShownMessages = new Dictionary<string, DatabaseMessage>();

	private float mMessageTimeout = 0.5f;

	private RadicalRoutine mRoutine;

	public int unignoredMessages
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<string, DatabaseMessage> mShownMessage in mShownMessages)
			{
				if (!mShownMessage.Value.wasIgnored)
				{
					num++;
				}
			}
			return Mathf.Max(0, num);
		}
	}

	public void SentDatabaseMessageWasShown(string messageId, string playerId)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.MessageWasShown, JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "MessageId", messageId },
			{ "PlayerId", playerId }
		}), 0, 0, string.Empty);
	}

	public void SentDatabaseMessageIgnore(string messageId)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.IgnoreMessage, messageId, 0, 0, string.Empty);
	}

	public void StartMessageCoroutine()
	{
		if (mRoutine != null)
		{
			mRoutine.Cancel();
			mRoutine = null;
		}
		Singleton<OfferManager>.instance.CheckOffer();
		mRoutine = RadicalRoutine.Create(CheckForEventsRoutine());
		StartCoroutine(mRoutine.enumerator);
	}

	public void StopMessageCoroutine()
	{
		if (mRoutine != null)
		{
			mRoutine.Cancel();
			mRoutine = null;
		}
	}

	public void AddMessage(DatabaseMessage message, bool canBeRepeated = false)
	{
		if (!mMessages.ContainsKey(message.messageId))
		{
			string messageDatabaseKey = GetMessageDatabaseKey(message);
			if (mShownMessages.ContainsKey(messageDatabaseKey) && mShownMessages[messageDatabaseKey].wasIgnored)
			{
				Debug.Log("#VOJTA# Message Manager: Error previously ignored message arrived again from server! Id = " + mShownMessages[messageDatabaseKey].messageId);
				mShownMessages[messageDatabaseKey].Ignore();
			}
			if (canBeRepeated || !mShownMessages.ContainsKey(messageDatabaseKey))
			{
				message.OnAdd();
				mMessages.Add(message.messageId, message);
			}
		}
	}

	public void ClearAllMessages()
	{
		StopMessageCoroutine();
		mMessages.Clear();
		mShownMessages.Clear();
		lastRewardMessage = null;
		lastDepositWarcardsMessage = null;
	}

	public bool IsRateAppInQueue()
	{
		bool result = false;
		foreach (KeyValuePair<string, DatabaseMessage> mMessage in mMessages)
		{
			if (mMessage.Value is RateAppMessage && !mMessage.Value.WasShown())
			{
				result = true;
			}
		}
		return result;
	}

	private string GetMessageDatabaseKey(DatabaseMessage message)
	{
		return message.messageId + "-" + message.playerId;
	}

	private IEnumerator CheckForEventsRoutine()
	{
		while (true)
		{
			bool processNextMessage = false;
			if (Singleton<GuiManager>.instance.currentScreen.dialogsEnabled && Singleton<GameController>.instance.gameState == GameController.GameState.Menu && !GuiElementSingle<LoadingDialog>.instance.isShowed && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
			{
				if (mMessages != null && mMessages.Count != 0)
				{
					processNextMessage = ShowEvent();
				}
				if ((mMessages == null || mMessages.Count == 0 || DialogManager.instance.isSomeDialogShowed) && StatsManager.instance.dailyRewardData != null && !GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					StatsManager.instance.dailyRewardData.CheckDownloadNext();
				}
			}
			if (!processNextMessage)
			{
				yield return new WaitForSeconds(mMessageTimeout);
			}
		}
	}

	private bool ShowEvent()
	{
		bool result = false;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, DatabaseMessage> mMessage in mMessages)
		{
			DatabaseMessage value = mMessage.Value;
			if (value.WasShown())
			{
				Debug.Log("Message Manager: Removing message, id = " + value.messageId + ", type " + value.messageType);
				list.Add(value.messageId);
				mShownMessages[GetMessageDatabaseKey(value)] = value;
			}
			else if (value.CanShow())
			{
				result = value.processNextMessage;
				value.Show();
				break;
			}
		}
		foreach (string item in list)
		{
			mMessages.Remove(item);
		}
		return result;
	}
}
