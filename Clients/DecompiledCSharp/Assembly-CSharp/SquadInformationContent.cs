using System;
using UnityEngine;

public class SquadInformationContent : Core_BaseScript
{
	public UIPanel panel;

	[Header("Anchor")]
	public GameObject topRightAnchor;

	[Header("Content vs Loading")]
	public GameObject waiting;

	public GameObject content;

	[Header("Squad Message")]
	public UIInput squadMessageInput;

	[Header("Advanced settings")]
	public GameObject minMedalsInfoPart;

	[Header("-Input for Medals")]
	public GameObject minMedalsInputPart;

	public UIInput squadSkillInput;

	[Header("-Private Checkbox")]
	public UILabel privateSquadLabel;

	public UISprite checkIcon;

	public BoxCollider checkboxCollider;

	[Header("Bottom Button")]
	public BoxCollider saveChanges;

	public UISprite saveChangesBackground;

	public UILabel info;

	private bool mIsActive;

	private bool mCheckbox;

	private bool mIsMessageValid;

	private bool mIsSkillRequirementValid;

	private bool mSaveButtonEnabled;

	private string squadMessageInInput => (!(squadMessageInput.text == Localization.Localize("ID_EMPTYSQUADMESSAGE"))) ? squadMessageInput.text : string.Empty;

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		mIsActive = false;
		UIEventListener uIEventListener = UIEventListener.Get(saveChanges.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(SaveChangesClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(checkboxCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CheckboxPrivateClick));
		UIInput uIInput = squadMessageInput;
		uIInput.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(uIInput.onLostFocus, (UIInput.OnLostFocus)delegate(string inputString)
		{
			CheckMessage(inputString);
		});
		UIInput uIInput2 = squadMessageInput;
		uIInput2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(uIInput2.onSubmit, (UIInput.OnSubmit)delegate(string inputString)
		{
			CheckMessage(inputString);
		});
		UIInput uIInput3 = squadSkillInput;
		uIInput3.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(uIInput3.onLostFocus, (UIInput.OnLostFocus)delegate(string inputString)
		{
			CheckSkill(inputString);
		});
		UIInput uIInput4 = squadSkillInput;
		uIInput4.onSubmit = (UIInput.OnSubmit)Delegate.Combine(uIInput4.onSubmit, (UIInput.OnSubmit)delegate(string inputString)
		{
			CheckSkill(inputString);
		});
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		topRightAnchor.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth - 120f, topRightAnchor.transform.localPosition.y, topRightAnchor.transform.localPosition.z);
		squadMessageInput.defaultText = Localization.Localize("ID_EMPTYSQUADMESSAGE");
		squadSkillInput.defaultText = "0";
	}

	private void SaveChangesClick(GameObject go)
	{
		if (mSaveButtonEnabled)
		{
			UpdateSaveButton();
			int medalsRequirement = ((!string.IsNullOrEmpty(squadSkillInput.text)) ? Convert.ToInt32(squadSkillInput.text) : 0);
			Singleton<BeanstalkServerManager>.instance.UpdateSquadInfo(squadMessageInInput, !mCheckbox, medalsRequirement);
		}
	}

	private void CheckboxPrivateClick(GameObject go)
	{
		mCheckbox = !mCheckbox;
		checkIcon.alpha = ((!mCheckbox) ? 0f : 1f);
		if (mCheckbox)
		{
			squadSkillInput.text = "0";
			mIsSkillRequirementValid = true;
		}
		UpdateSaveButton();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!GuiScreenSingle<SquadScreen>.instance.isShowed || !mIsActive)
		{
			return;
		}
		if (action == DatabaseAction.GetSquadDetails && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
			if (squad != null)
			{
				ShowInfo(squad);
			}
		}
	}

	public void Animate(bool showTab, bool instant)
	{
		mIsActive = showTab;
		if (mIsActive && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(panel.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
			{
				if (!mIsActive)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!mIsActive)
		{
			InstantHideTab();
		}
	}

	public void InitGUIValues()
	{
		info.text = string.Empty;
		squadMessageInput.maxChars = DatabaseSquad.maxSquadMessage;
		squadSkillInput.text = "0";
		content.SetActive(value: false);
		waiting.SetActive(value: true);
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		if (squad == null)
		{
			Singleton<BeanstalkServerManager>.instance.GetSquadDetails(GameLoginManager.currentPlayer.squadName);
		}
		else
		{
			ShowInfo(squad);
		}
	}

	public void DoAfterHide()
	{
	}

	public void InstantHideTab()
	{
		TweenAlpha component = panel.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void ShowInfo(DatabaseSquad squad)
	{
		content.SetActive(value: true);
		waiting.SetActive(value: false);
		squadMessageInput.text = ((!string.IsNullOrEmpty(squad.message)) ? squad.message : string.Empty);
		squadSkillInput.text = squad.skillRequirement.ToString();
		mCheckbox = !squad.isPublic;
		checkIcon.alpha = ((!mCheckbox) ? 0f : 1f);
		mIsMessageValid = true;
		mIsSkillRequirementValid = true;
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		if (squad.size == 1 && !flag)
		{
			Debug.LogError("One man in squad and not a leader!!!");
			flag = true;
		}
		UpdateSaveButton();
		saveChanges.gameObject.SetActive(flag);
		BoxCollider component = squadMessageInput.gameObject.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = flag;
		}
		BoxCollider component2 = squadSkillInput.gameObject.GetComponent<BoxCollider>();
		if (component2 != null)
		{
			component2.enabled = flag;
		}
		checkboxCollider.enabled = flag;
	}

	private void CheckMessage(string inputString)
	{
		mIsMessageValid = false;
		if (inputString.Length > DatabaseSquad.maxSquadMessage)
		{
			info.text = Localization.Localize("ID_ERROR_SQUADMESSAGELONG");
		}
		else if (Singleton<Chat>.instance.ContainsBadWord(inputString))
		{
			info.text = Localization.Localize("ID_ERROR_SQUADMESSAGE_PROFANITY");
		}
		else
		{
			mIsMessageValid = true;
		}
		UpdateSaveButton();
	}

	private void CheckSkill(string inputString)
	{
		mIsSkillRequirementValid = false;
		int result = 0;
		if (string.IsNullOrEmpty(inputString))
		{
			squadSkillInput.text = "0";
			inputString = "0";
		}
		if (int.TryParse(inputString, out result))
		{
			if (result < 0 || result > DatabaseSquad.maxMedalsRequirement)
			{
				info.text = Localization.LocalizeFormat("ID_ERROR_SQUADSKILLCLAMP", DatabaseSquad.maxMedalsRequirement);
			}
			else
			{
				mIsSkillRequirementValid = true;
			}
		}
		else
		{
			info.text = Localization.LocalizeFormat("ID_ERROR_SQUADSKILLNOTANUMBER", DatabaseSquad.maxMedalsRequirement);
		}
		UpdateSaveButton();
	}

	private void UpdateSaveButton()
	{
		mSaveButtonEnabled = mIsMessageValid && mIsSkillRequirementValid;
		saveChanges.enabled = mSaveButtonEnabled;
		saveChangesBackground.color = ((!mSaveButtonEnabled) ? Color.gray : Color.white);
		if (mSaveButtonEnabled)
		{
			info.text = string.Empty;
		}
	}
}
