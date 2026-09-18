using System.Collections.Generic;
using UnityEngine;

public class InappOffers : Core_BaseScript
{
	[Header("Core")]
	public SpecialPackRecord specialPackRecordPrefab;

	public UIPooledGrid packsGrid;

	public UIPanel offersPanel;

	public UIDraggablePanel draggablePanel;

	private List<SpecialPackContent> mSpecialPacks = new List<SpecialPackContent>();

	public int numberOfOffers => mNumberOfSpecialPacks + mNumberOfElitePacks;

	private int mNumberOfSpecialPacks
	{
		get
		{
			List<SpecialPackContent> specialPackOffer = Singleton<OfferManager>.instance.GetSpecialPackOffer();
			int num = 0;
			if (specialPackOffer != null)
			{
				for (int i = 0; i < specialPackOffer.Count; i++)
				{
					if (specialPackOffer[i].finishAt > Singleton<BeanstalkServerManager>.instance.currentTimestamp && !PlayerAnalytics.instance.IsPackBought(specialPackOffer[i].packId))
					{
						num++;
					}
				}
			}
			return num;
		}
	}

	private int mNumberOfElitePacks
	{
		get
		{
			int num = (PlayerAnalytics.instance.showMoneyPack ? 1 : 0);
			for (int i = 1; i < 7; i++)
			{
				if (PlayerAnalytics.instance.ShowPack(i.ToString("'elitepack'0")))
				{
					num++;
				}
			}
			for (int j = 1; j < 6; j++)
			{
				if (PlayerAnalytics.instance.ShowPack(j.ToString("'veteranpack'0")))
				{
					num++;
				}
			}
			return num;
		}
	}

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
			TweenAlpha.Begin(offersPanel.gameObject, (!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
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
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += HandleAfterPlayerDataLoaded;
		Singleton<BeanstalkServerManager>.instance.inAppHandler.ProductsLoaded += OnProductsLoaded;
	}

	private void HandleAfterPlayerDataLoaded()
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
				if (mSpecialPacks[i].packId == Singleton<GameVariables>.instance.PackId(CardPack.Money))
				{
					component.InitializeMoneyPack();
				}
				else
				{
					component.Initialize(mSpecialPacks[i]);
				}
			}
		}
	}

	public void InitGUIValues()
	{
		mSpecialPacks.Clear();
		if (PlayerAnalytics.instance.showMoneyPack)
		{
			mSpecialPacks.Add(Singleton<GameVariables>.instance.moneyPack);
		}
		List<SpecialPackContent> specialPackOffer = Singleton<OfferManager>.instance.GetSpecialPackOffer();
		if (specialPackOffer != null)
		{
			mSpecialPacks.AddRange(specialPackOffer);
		}
		for (int i = 1; i < 7; i++)
		{
			string packId = i.ToString("'elitepack'0");
			if (PlayerAnalytics.instance.ShowPack(packId))
			{
				mSpecialPacks.Add(SpecialPackContent.CreatePackFromId(packId));
			}
		}
		for (int j = 1; j < 6; j++)
		{
			string packId2 = j.ToString("'veteranpack'0");
			if (PlayerAnalytics.instance.ShowPack(packId2))
			{
				mSpecialPacks.Add(SpecialPackContent.CreatePackFromId(packId2));
			}
		}
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
				if (mSpecialPacks[index].packId == Singleton<GameVariables>.instance.PackId(CardPack.Money))
				{
					specialPackRecord.InitializeMoneyPack();
				}
				else
				{
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
		TweenAlpha component = offersPanel.GetComponent<TweenAlpha>();
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
