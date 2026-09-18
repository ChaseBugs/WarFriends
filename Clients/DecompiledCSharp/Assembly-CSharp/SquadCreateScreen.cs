using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SquadCreateScreen : GuiScreenSingle<SquadCreateScreen>
{
	[Header("Core")]
	public UIButtonSetter[] setters;

	[Header("Squad Name")]
	public UIInput squadNameInput;

	public UILabel nameMaxCharacters;

	public GameObject squadNameWaitingGameobject;

	[Header("Squad message")]
	public UIInput squadMessageInput;

	public UILabel messageMaxCharacters;

	[Header("Error")]
	public UILabel info;

	[Header("Emblem")]
	public UISprite emblemScrollBackground;

	public SquadCreateEmblemRecord squadCreateEmblemRecordPrefab;

	public UIPanel emblemShowPanel;

	public UIDraggablePanel emblemPanel;

	public UIPooledGrid emblemGrid;

	[Header("Required Medals")]
	public UIButtonSetter requiredButtonSetter;

	public UITable requiredMedalsTable;

	public UILabel reguiredMedalsLabel1;

	public UILabel reguiredMedalsLabel2;

	public UIInput squadSkillInput;

	[Header("-Public Private Squad")]
	public UISprite checkIcon;

	public UIButton checkboxPrivate;

	[Header("Bottom Button")]
	public UIButton createButton;

	public BoxCollider createButtonCollider;

	public UISprite createButtonBackground;

	public UISprite createButtonSoldier;

	public UISprite createButtonPriceBox;

	public UITable createPriceTable;

	public UISprite createWarbucksIcon;

	public UILabel createPriceWarbucks;

	public GameObject createSquadWaitingGameobject;

	private bool mCheckbox;

	private bool mIsUniqueSquadname;

	private bool mIsNameValid;

	private bool mIsMessageValid;

	private bool mIsSkillRequirementValid;

	private bool mCreateButtonEnable;

	private string mSquadName;

	private string mSelectedEmblem;

	private List<string> mBasicEmblems;

	private bool mInitializedGUI;

	private string squadMessageInInput => (!(squadMessageInput.text == Localization.Localize("ID_EMPTYSQUADMESSAGE"))) ? squadMessageInput.text : string.Empty;

	private bool isAllSet
	{
		get
		{
			if (setters == null || setters.Length == 0)
			{
				return true;
			}
			UIButtonSetter[] array = setters;
			foreach (UIButtonSetter uIButtonSetter in array)
			{
				if (!uIButtonSetter.initializationResizeDone)
				{
					return false;
				}
			}
			return true;
		}
	}

	protected override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(createButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CreateButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(checkboxPrivate);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CheckboxClick));
		UIInput uIInput = squadNameInput;
		uIInput.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(uIInput.onLostFocus, (UIInput.OnLostFocus)delegate(string inputString)
		{
			if (inputString.Length > 0)
			{
				UpdateCreateButton();
			}
		});
		UIInput uIInput2 = squadNameInput;
		uIInput2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(uIInput2.onSubmit, (UIInput.OnSubmit)delegate(string inputString)
		{
			if (inputString.Length > 0)
			{
				UpdateCreateButton();
			}
		});
		UIInput uIInput3 = squadMessageInput;
		uIInput3.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(uIInput3.onLostFocus, (UIInput.OnLostFocus)delegate(string inputString)
		{
			if (inputString.Length > 0)
			{
				UpdateCreateButton();
			}
		});
		UIInput uIInput4 = squadMessageInput;
		uIInput4.onSubmit = (UIInput.OnSubmit)Delegate.Combine(uIInput4.onSubmit, (UIInput.OnSubmit)delegate(string inputString)
		{
			if (inputString.Length > 0)
			{
				UpdateCreateButton();
			}
		});
		UIInput uIInput5 = squadSkillInput;
		uIInput5.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(uIInput5.onLostFocus, (UIInput.OnLostFocus)delegate(string inputString)
		{
			if (ShouldUpdate(inputString))
			{
				UpdateCreateButton();
			}
		});
		UIInput uIInput6 = squadSkillInput;
		uIInput6.onSubmit = (UIInput.OnSubmit)Delegate.Combine(uIInput6.onSubmit, (UIInput.OnSubmit)delegate(string inputString)
		{
			if (ShouldUpdate(inputString))
			{
				UpdateCreateButton();
			}
		});
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataReceived;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		nameMaxCharacters.text = Localization.LocalizeFormat("ID_HEADERMAXCHAR", DatabaseSquad.maxSquadName);
		squadNameInput.defaultText = Localization.Localize("ID_EMPTYSQUADNAME");
		squadNameInput.maxChars = DatabaseSquad.maxSquadName;
		messageMaxCharacters.text = Localization.LocalizeFormat("ID_HEADERMAXCHAR", DatabaseSquad.maxSquadMessage);
		squadMessageInput.defaultText = Localization.Localize("ID_EMPTYSQUADMESSAGE");
		squadMessageInput.maxChars = DatabaseSquad.maxSquadMessage;
		squadSkillInput.defaultText = "0";
		CreateEmblems();
		createPriceTable.onReposition = delegate
		{
			float val = 0f - createPriceTable.padding.x - (createPriceWarbucks.transform.parent.transform.localPosition.x - createPriceTable.padding.x) / 2f;
			createPriceTable.transform.localPosition = createPriceTable.transform.localPosition.ReplaceX(val);
		};
	}

	private bool ShouldUpdate(string inputString)
	{
		return !string.IsNullOrEmpty(inputString) && !inputString.Equals("0");
	}

	private void CreateButtonClick(GameObject go)
	{
		if (!mCreateButtonEnable)
		{
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTCREATESQUAD_TEXT"), Localization.Localize("ID_WARNING_CANNOTCREATESQUAD"), 0f, null, string.Empty);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.CanBuyW(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(createSquadWarBucksPrice, Localization.Localize("ID_CREATESQUADNOTENOUGH"));
			return;
		}
		createSquadWaitingGameobject.SetActive(value: true);
		UpdateCreateButton();
		Singleton<Wallet>.instance.WarBucksSpent(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CreateSquad(squadNameInput.text, squadMessageInInput, mCheckbox, (!string.IsNullOrEmpty(squadSkillInput.text)) ? squadSkillInput.text : "0", mSelectedEmblem);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Create_Squad");
	}

	private void CheckboxClick(GameObject go)
	{
		mCheckbox = !mCheckbox;
		checkIcon.alpha = ((!mCheckbox) ? 0f : 1f);
		UpdateCreateButton();
	}

	private void OnDataReceived(DatabaseAction action)
	{
		switch (action)
		{
		case DatabaseAction.CreateSquad:
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			UpdateCreateButton();
			createSquadWaitingGameobject.SetActive(value: false);
			break;
		case DatabaseAction.UniqueSquadNameSuccess:
			squadNameWaitingGameobject.SetActive(value: false);
			mIsUniqueSquadname = true;
			UpdateCreateButton();
			Debug.Log("Squad name success");
			break;
		case DatabaseAction.UniqueSquadNameFailure:
			squadNameWaitingGameobject.SetActive(value: false);
			UpdateCreateButton();
			info.text = Localization.Localize("ID_ERROR_SQUADNAMENOTUNIQUE");
			Debug.Log("Squad name failure");
			break;
		case DatabaseAction.JoinSquad:
			break;
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (action == DatabaseAction.CreateSquad)
		{
			createSquadWaitingGameobject.SetActive(value: false);
			createPriceWarbucks.text = MiscTools.FormatBigNumber(PlayerAnalytics.instance.createSquadWarBucksPrice);
			createPriceTable.repositionNow = true;
		}
	}

	private void CreateEmblems()
	{
		mBasicEmblems = new List<string>();
		foreach (SquadEmblemsRow row in Singleton<GameVariables>.instance.squadEmblems.Rows)
		{
			if (row.UNLOCKLEVEL <= 1)
			{
				mBasicEmblems.Add(row.ICONNAME);
			}
		}
	}

	private void InitEmblems()
	{
		mSelectedEmblem = "menu-squad-1";
		emblemGrid.MakeEmpty();
		emblemGrid.init(mBasicEmblems.Count, EmblemInstantiate, EmblemFree, emblemPanel);
		emblemPanel.AlignToPos(instant: true);
	}

	private Transform EmblemInstantiate(int index)
	{
		if (index >= 0 && index < mBasicEmblems.Count)
		{
			SquadCreateEmblemRecord squadCreateEmblemRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(squadCreateEmblemRecordPrefab, emblemGrid.gameObject, index.ToString("D2") + mBasicEmblems[index]) as SquadCreateEmblemRecord;
			if (squadCreateEmblemRecord != null)
			{
				squadCreateEmblemRecord.Initialize(mBasicEmblems[index]);
				squadCreateEmblemRecord.SetHighlight(mSelectedEmblem);
				return squadCreateEmblemRecord.transform;
			}
		}
		return null;
	}

	private void EmblemFree(Transform obj)
	{
		if (obj != null)
		{
			SquadCreateEmblemRecord component = obj.GetComponent<SquadCreateEmblemRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public override void InitGUIValues()
	{
		mInitializedGUI = false;
		squadNameInput.text = string.Empty;
		squadMessageInput.text = string.Empty;
		squadSkillInput.text = string.Empty;
		mSquadName = string.Empty;
		mIsUniqueSquadname = false;
		mIsNameValid = false;
		mIsMessageValid = true;
		mIsSkillRequirementValid = true;
		mCheckbox = false;
		checkIcon.alpha = ((!mCheckbox) ? 0f : 1f);
		UpdateCreateButton();
		info.text = string.Empty;
		squadNameWaitingGameobject.gameObject.SetActive(value: false);
		createSquadWaitingGameobject.gameObject.SetActive(value: false);
		int num = requiredButtonSetter.width - 145;
		reguiredMedalsLabel1.text = Localization.Localize("ID_REQUIREDMINBIG");
		reguiredMedalsLabel2.text = Localization.Localize("ID_MEDALSTOJOINBIG");
		float num2 = reguiredMedalsLabel1.relativeSize.x + reguiredMedalsLabel2.relativeSize.x;
		float num3 = (float)num / num2;
		MiscTools.SetUILabelRescale(reguiredMedalsLabel1, num3, 20f, (int)(reguiredMedalsLabel1.relativeSize.x * num3));
		MiscTools.SetUILabelRescale(reguiredMedalsLabel2, num3, 20f, (int)(reguiredMedalsLabel2.relativeSize.x * num3));
		requiredMedalsTable.repositionNow = true;
		createPriceWarbucks.text = MiscTools.FormatBigNumber(PlayerAnalytics.instance.createSquadWarBucksPrice);
		createPriceTable.repositionNow = true;
	}

	private void CheckName(string inputString)
	{
		mIsNameValid = false;
		if (inputString.Length < 4)
		{
			info.text = Localization.Localize("ID_ERROR_SQUADNAMESHORT");
			return;
		}
		if (inputString.Length > DatabaseSquad.maxSquadName)
		{
			info.text = Localization.Localize("ID_ERROR_SQUADNAMELONG");
			return;
		}
		if (Singleton<Chat>.instance.ContainsBadWord(inputString))
		{
			info.text = Localization.Localize("ID_ERROR_SQUADNAME_PROFANITY");
			return;
		}
		mIsNameValid = true;
		if (mSquadName != inputString)
		{
			mIsUniqueSquadname = false;
			mSquadName = inputString;
			Singleton<BeanstalkServerManager>.instance.CheckUniqueSquadName(inputString);
			squadNameWaitingGameobject.gameObject.SetActive(value: true);
			info.text = Localization.Localize("ID_ERROR_SQUADNAMENOTUNIQUE");
		}
		else if (!mIsUniqueSquadname && !squadNameWaitingGameobject.gameObject.activeSelf)
		{
			info.text = Localization.Localize("ID_ERROR_SQUADNAMENOTUNIQUE");
		}
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
	}

	private void CheckSkill(string inputString)
	{
		mIsSkillRequirementValid = false;
		int result = 0;
		if (string.IsNullOrEmpty(inputString))
		{
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
	}

	private void UpdateCreateButton()
	{
		CheckSkill(squadSkillInput.text);
		CheckMessage(squadMessageInput.text);
		CheckName(squadNameInput.text);
		mCreateButtonEnable = mIsUniqueSquadname && mIsNameValid && mIsMessageValid && mIsSkillRequirementValid && !createSquadWaitingGameobject.activeSelf;
		createButton.enabled = mCreateButtonEnable;
		createButtonCollider.enabled = mCreateButtonEnable;
		createButtonBackground.color = ((!mCreateButtonEnable) ? Color.gray : Color.white);
		createButtonSoldier.color = ((!mCreateButtonEnable) ? Color.gray : Color.white);
		createButtonPriceBox.color = ((!mCreateButtonEnable) ? Color.gray : Color.white);
		createWarbucksIcon.color = ((!mCreateButtonEnable) ? Color.gray : Color.white);
		if (mCreateButtonEnable)
		{
			info.text = string.Empty;
		}
	}

	public void SelectEmblem(string emblemName)
	{
		mSelectedEmblem = emblemName;
		for (int i = 0; i < emblemGrid.containItems; i++)
		{
			Transform itemOnIndex = emblemGrid.GetItemOnIndex(i);
			if (!(itemOnIndex == null))
			{
				SquadCreateEmblemRecord component = itemOnIndex.GetComponent<SquadCreateEmblemRecord>();
				if (component != null)
				{
					component.SetHighlight(mSelectedEmblem);
				}
			}
		}
	}

	protected override void Update()
	{
		base.Update();
		if (isAllSet && !mInitializedGUI)
		{
			Vector4 clipRange = emblemShowPanel.clipRange;
			clipRange.z = emblemScrollBackground.transform.localScale.x - 4f;
			emblemShowPanel.clipRange = clipRange;
			InitEmblems();
			mInitializedGUI = true;
		}
	}
}
