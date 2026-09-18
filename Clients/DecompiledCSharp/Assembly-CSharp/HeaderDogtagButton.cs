using System;
using System.Collections.Generic;
using UnityEngine;

public class HeaderDogtagButton : GuiElementSingle<HeaderDogtagButton>
{
	[Header("Core")]
	[SerializeField]
	private UIGrid mDogtagsGrid;

	[SerializeField]
	private GameObject mDogtagsButton;

	[SerializeField]
	private DogTagRecord mDogtagPrefab;

	private List<DogTagRecord> mDogTagRecords = new List<DogTagRecord>();

	public void AnimateDogtagUse()
	{
		if (isShowed && mDogTagRecords.Count != 0)
		{
			int currentDogtags = Singleton<DogTagManager>.instance.currentDogtags;
			int index = Mathf.Clamp(currentDogtags - 1, 0, mDogTagRecords.Count - 1);
			DogTagRecord dogTagRecord = mDogTagRecords[index];
			dogTagRecord.Animation_DogTagConsumed();
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<DogTagManager>.instance.DogtagsChanged += OnDogtagsChanged;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<VipManager>.instance.VipStatusChanged += OnVipStatusChanged;
	}

	private void OnDogtagsChanged(int dogtags)
	{
		if (isShowed && mDogTagRecords.Count > 0)
		{
			for (int i = 0; i < mDogTagRecords.Count; i++)
			{
				mDogTagRecords[i].Initialize(dogtags > i);
			}
		}
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (isShowed)
		{
			switch (action)
			{
			case DatabaseAction.RemoveFacebook:
				InitGUIValues();
				break;
			case DatabaseAction.BuyVip:
				InitializeDogtags();
				break;
			}
		}
	}

	private void OnVipStatusChanged(bool isVIP)
	{
		if (isShowed)
		{
			InitializeDogtags();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mDogtagsButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DogTagButtonClicked));
	}

	private void DogTagButtonClicked(GameObject go)
	{
		if (!GuiElementSingle<DogtagDialog>.instance.isShowed)
		{
			if (!(Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<MissionScreen>.instance) || !GuiElementSingle<MissionDialog>.instance.isShowed)
			{
				DialogManager.instance.HideAllDialogs();
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 0f);
		}
	}

	public override void InitGUIValues()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			InitializeDogtags(initGuiValues: true);
			ShowDogtagButton(!Singleton<GameController>.instance.isTutorial);
		}
	}

	private void InitializeDogtags(bool initGuiValues = false)
	{
		InitDogtagRecords(Singleton<DogTagManager>.instance.maximumDogtags, initGuiValues);
		OnDogtagsChanged(Singleton<DogTagManager>.instance.currentDogtags);
	}

	private void InitDogtagRecords(int dogtagsCount, bool initGuiValues)
	{
		if (dogtagsCount != mDogTagRecords.Count)
		{
			Debug.Log("MenuHeader - Initializing menu dogtags in count: " + dogtagsCount);
			ObjectPool objectPool = Singleton<GuiManager>.instance.objectPool;
			objectPool.FreeObjectsWithPrefab(mDogtagPrefab);
			mDogTagRecords.Clear();
			for (int i = 0; i < dogtagsCount; i++)
			{
				DogTagRecord dogTagRecord = (DogTagRecord)objectPool.InstantiateAsChild(mDogtagPrefab, mDogtagsGrid.gameObject, string.Format("Dogtag {0}", i.ToString("D2")));
				if (dogTagRecord != null)
				{
					dogTagRecord.SetSpritesOrder(i, dogtagsCount);
					mDogTagRecords.Add(dogTagRecord);
				}
			}
			float num = 98f;
			mDogtagsGrid.cellWidth = Mathf.Floor(num / (float)(dogtagsCount - 1));
			mDogtagsGrid.repositionNow = true;
			mDogTagRecords.Sort((DogTagRecord dogtag1, DogTagRecord dogtag2) => string.Compare(dogtag1.gameObject.name, dogtag2.gameObject.name, StringComparison.Ordinal));
		}
		else
		{
			Debug.Log("MenuHeader - Already initialized dogtags in menu");
			for (int num2 = 0; num2 < mDogTagRecords.Count; num2++)
			{
				mDogTagRecords[num2].StopAnimation();
			}
		}
	}

	private void ShowDogtagButton(bool showActive)
	{
		mDogtagsButton.SetActive(showActive);
	}
}
