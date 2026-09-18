using System.Collections.Generic;
using UnityEngine;

public class InappPacks : Core_BaseScript
{
	[Header("Core")]
	public SpecialPackRecord specialPackRecordPrefab;

	public UIPooledGrid packsGrid;

	public UIDraggablePanel packsPanel;

	public UIDraggablePanel draggablePanel;

	private List<SpecialPackContent> mSpecialPacks = new List<SpecialPackContent>();

	public void Animate(bool showTab, bool instant)
	{
		if (showTab && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			AnimateOtherPanels(instant, showTab);
			TweenAlpha.Begin(packsPanel.gameObject, (!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
			{
				if (!showTab)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
				else
				{
					AlignPanel();
				}
			};
		}
		else if (!showTab)
		{
			InstantHideTab();
		}
	}

	public void InitControls()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += DataLoaded;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
		Singleton<BeanstalkServerManager>.instance.inAppHandler.ProductsLoaded += OnProductsLoaded;
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			ReinitializeShownRecords();
		}
	}

	private void DataLoaded(DatabaseAction action)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && action == DatabaseAction.BuyPack)
		{
			ReinitializeShownRecords();
		}
	}

	private void OnProductsLoaded()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			ReinitializeShownRecords();
		}
	}

	private void ReinitializeShownRecords()
	{
		for (int i = 0; i < packsGrid.containItems; i++)
		{
			Transform itemOnIndex = packsGrid.GetItemOnIndex(i);
			if (!(itemOnIndex != null))
			{
				continue;
			}
			SpecialPackRecord component = itemOnIndex.GetComponent<SpecialPackRecord>();
			if (component != null)
			{
				if (mSpecialPacks[i].packId == Singleton<GameVariables>.instance.PackId(CardPack.Starter))
				{
					component.InitializeStarterPack();
					continue;
				}
				if (mSpecialPacks[i].packId == Singleton<GameVariables>.instance.PackId(CardPack.Value))
				{
					component.InitializeValuePack();
					continue;
				}
				Debug.LogError("Should not get here - pack id:" + mSpecialPacks[i].packId);
				component.Initialize(mSpecialPacks[i]);
			}
		}
	}

	public void InitGUIValues()
	{
		mSpecialPacks.Clear();
		if (PlayerAnalytics.instance.showStarterPack)
		{
			mSpecialPacks.Add(Singleton<GameVariables>.instance.starterPack);
		}
		mSpecialPacks.Add(Singleton<GameVariables>.instance.valuePack);
		packsGrid.MakeEmpty();
		packsGrid.init(mSpecialPacks.Count, SpecialPackInstantiate, SpecialPackFree, draggablePanel);
		AlignPanel(instant: true);
	}

	private void AlignPanel(bool instant = false)
	{
		draggablePanel.AlignToPos(instant);
	}

	private Transform SpecialPackInstantiate(int index)
	{
		if (index >= 0 && index < mSpecialPacks.Count)
		{
			SpecialPackRecord specialPackRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(specialPackRecordPrefab, packsGrid.gameObject, mSpecialPacks[index].packId) as SpecialPackRecord;
			if (specialPackRecord != null)
			{
				if (mSpecialPacks[index].packId == Singleton<GameVariables>.instance.PackId(CardPack.Starter))
				{
					specialPackRecord.InitializeStarterPack();
				}
				else if (mSpecialPacks[index].packId == Singleton<GameVariables>.instance.PackId(CardPack.Value))
				{
					specialPackRecord.InitializeValuePack();
				}
				else
				{
					Debug.LogError("Should not get here - pack id:" + mSpecialPacks[index].packId);
					specialPackRecord.Initialize(mSpecialPacks[index]);
				}
				if (GuiElementSingle<InappScreen>.instance.isFullyShowed)
				{
					specialPackRecord.AnimatePanels(instant: true, show: true);
				}
				return specialPackRecord.transform;
			}
		}
		return null;
	}

	private void SpecialPackFree(Transform obj)
	{
		if (obj != null)
		{
			SpecialPackRecord component = obj.GetComponent<SpecialPackRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public void DoAfterHide()
	{
		packsGrid.MakeEmpty();
		mSpecialPacks.Clear();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = packsPanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void AnimateOtherPanels(bool instant, bool show)
	{
		for (int i = 0; i < packsGrid.containItems; i++)
		{
			Transform itemOnIndex = packsGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				SpecialPackRecord component = itemOnIndex.GetComponent<SpecialPackRecord>();
				if (component != null)
				{
					component.AnimatePanels(instant, show);
				}
			}
		}
	}
}
