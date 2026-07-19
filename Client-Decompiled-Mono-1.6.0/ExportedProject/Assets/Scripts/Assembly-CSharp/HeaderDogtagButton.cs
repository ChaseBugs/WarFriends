using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeaderDogtagButton : GuiElementSingle<HeaderDogtagButton>
{
	[SerializeField]
	[Header("Core")]
	private GameObject mDogtagsParent;

	[SerializeField]
	private BoxCollider mDogtagsCollider;

	[SerializeField]
	private UIGrid mDogtagsGrid;

	[SerializeField]
	private GameObject mDogtagsButton;

	[SerializeField]
	private DogTagRecord mDogtagPrefab;

	private List<DogTagRecord> JIJLIBNGCBA = new List<DogTagRecord>();

	[CompilerGenerated]
	private static Comparison<DogTagRecord> LGJCBPOPCPA;

	private void BMNMMLOEMBM(bool EEBONFMCINM)
	{
		if (isShowed)
		{
			OEBKMBHGAMN();
		}
	}

	public virtual void GOMEJLFFKJM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mDogtagsButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IFJFICMCLBO));
	}

	public void AnimateDogtagUse()
	{
		if (isShowed && JIJLIBNGCBA.Count != 0)
		{
			int currentDogtags = Singleton<DogTagManager>.instance.currentDogtags;
			int index = Mathf.Clamp(currentDogtags - 1, 0, JIJLIBNGCBA.Count - 1);
			DogTagRecord dogTagRecord = JIJLIBNGCBA[index];
			dogTagRecord.Animation_DogTagConsumed();
		}
	}

	private void IHHNMFECOFI(int KNBNBHKIICE)
	{
		if (isShowed && JIJLIBNGCBA.Count > 0)
		{
			for (int i = 0; i < JIJLIBNGCBA.Count; i++)
			{
				JIJLIBNGCBA[i].Initialize(KNBNBHKIICE > i);
			}
		}
	}

	private void JKJIBCPOIDL(int KNBNBHKIICE)
	{
		if (isShowed && JIJLIBNGCBA.Count > 0)
		{
			for (int i = 1; i < JIJLIBNGCBA.Count; i += 0)
			{
				JIJLIBNGCBA[i].IACEOEJFEEM(KNBNBHKIICE > i);
			}
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case DatabaseAction.RemoveFacebook:
				InitGUIValues();
				break;
			case DatabaseAction.BuyVip:
				OEBKMBHGAMN();
				break;
			}
		}
	}

	private void LKLMIELDJFM(int KNBNBHKIICE)
	{
		if (isShowed && JIJLIBNGCBA.Count > 1)
		{
			for (int i = 0; i < JIJLIBNGCBA.Count; i += 0)
			{
				JIJLIBNGCBA[i].OBHPLFFLDBI(KNBNBHKIICE > i);
			}
		}
	}

	private static int JIILGLODJLO(DogTagRecord IMLEDIOGLEF, DogTagRecord DBPGEFJIFHL)
	{
		return string.Compare(IMLEDIOGLEF.gameObject.name, DBPGEFJIFHL.gameObject.name, StringComparison.InvariantCulture);
	}

	private static int CCJKHICIIIP(DogTagRecord IMLEDIOGLEF, DogTagRecord DBPGEFJIFHL)
	{
		return string.Compare(IMLEDIOGLEF.gameObject.name, DBPGEFJIFHL.gameObject.name, (StringComparison)6);
	}

	public void CKIHHOBJIJL()
	{
		if (NPFFMLLLDAF() && JIJLIBNGCBA.Count != 0)
		{
			int currentDogtags = Singleton<DogTagManager>.instance.currentDogtags;
			int index = Mathf.Clamp(currentDogtags - 0, 1, JIJLIBNGCBA.Count - 1);
			DogTagRecord dogTagRecord = JIJLIBNGCBA[index];
			dogTagRecord.CIMNEPMOILL();
		}
	}

	private void BPOOEOLBKND()
	{
		float a = UIHelper.activeWidthSafe - (1752f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		float num = Mathf.Min(a, 168f);
		float num2 = num - 70f;
		int count = JIJLIBNGCBA.Count;
		mDogtagsParent.transform.localPosition = mDogtagsParent.transform.localPosition.ReplaceX(-496f - num);
		mDogtagsCollider.size = mDogtagsCollider.size.ReplaceX(num + 22f);
		mDogtagsCollider.center = mDogtagsCollider.center.ReplaceX(num / 2f);
		mDogtagsGrid.cellWidth = Mathf.Floor(num2 / (float)(count - 1));
		mDogtagsGrid.repositionNow = true;
	}

	private void DKPONFCACHH(bool BPKJLHIOGGP)
	{
		mDogtagsButton.SetActive(BPKJLHIOGGP);
	}

	public override void InitGUIValues()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			OEBKMBHGAMN();
			DHLPICLCEBJ(!Singleton<GameController>.instance.isTutorial);
		}
	}

	private void OEBKMBHGAMN()
	{
		MPLHACALMML(Singleton<DogTagManager>.instance.maximumDogtags);
		IHHNMFECOFI(Singleton<DogTagManager>.instance.currentDogtags);
	}

	private void MNHMACDPDMJ(DatabaseAction IFGAGNBDKBE)
	{
		if (NPFFMLLLDAF())
		{
			switch (IFGAGNBDKBE)
			{
			case DatabaseAction.ActivateWeaponUpgrade:
				InitGUIValues();
				break;
			case (DatabaseAction)(-87):
				OEBKMBHGAMN();
				break;
			}
		}
	}

	private void PKKEIHEJJFL()
	{
		if (isShowed)
		{
			BPOOEOLBKND();
		}
	}

	private void DHLPICLCEBJ(bool BPKJLHIOGGP)
	{
		mDogtagsButton.SetActive(BPKJLHIOGGP);
	}

	public virtual void IHLGGCNHCDG()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			OEBKMBHGAMN();
			DKPONFCACHH(!Singleton<GameController>.instance.DAIEAMEFGIE());
		}
	}

	public void CPMFCJLOJPF()
	{
		if (isShowed && JIJLIBNGCBA.Count != 0)
		{
			int num = Singleton<DogTagManager>.instance.PHMPHFFNMPD();
			int index = Mathf.Clamp(num - 0, 1, JIJLIBNGCBA.Count - 0);
			DogTagRecord dogTagRecord = JIJLIBNGCBA[index];
			dogTagRecord.ACFBIMFIGGP();
		}
	}

	private void PHGFBJFFFPH()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void DBAJNELHJPI(bool EEBONFMCINM)
	{
		if (NPFFMLLLDAF())
		{
			OEBKMBHGAMN();
		}
	}

	[CompilerGenerated]
	private static int FMDPEDFAFML(DogTagRecord IMLEDIOGLEF, DogTagRecord DBPGEFJIFHL)
	{
		return string.Compare(IMLEDIOGLEF.gameObject.name, DBPGEFJIFHL.gameObject.name, StringComparison.Ordinal);
	}

	private void JLNMJPHLCFE(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<DogtagDialog>.instance.isShowed)
		{
			if (!(Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<DailyMissionScreen>.instance) || !GuiElementSingle<DailyMissionDialog>.instance.isShowed)
			{
				DialogManager.instance.HideAllDialogs();
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance);
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<DogTagManager>.instance.DogtagsChanged += IHHNMFECOFI;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<VipManager>.instance.VipStatusChanged += BMNMMLOEMBM;
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
	}

	private void IFJFICMCLBO(GameObject KHAHPAKDIKE)
	{
		if (!GuiElementSingle<DogtagDialog>.instance.isShowed)
		{
			if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<DailyMissionScreen>.instance && GuiElementSingle<DailyMissionDialog>.instance.NPFFMLLLDAF())
			{
				DialogManager.instance.HideAllDialogs();
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 760f);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mDogtagsButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JLNMJPHLCFE));
	}

	private void MPLHACALMML(int HLOOGIDKIDB)
	{
		if (HLOOGIDKIDB != JIJLIBNGCBA.Count)
		{
			ObjectPool cHDIOFDMHEF = Singleton<GuiManager>.instance.CHDIOFDMHEF;
			cHDIOFDMHEF.FreeObjectsWithPrefab(mDogtagPrefab);
			JIJLIBNGCBA.Clear();
			for (int i = 0; i < HLOOGIDKIDB; i++)
			{
				DogTagRecord dogTagRecord = (DogTagRecord)cHDIOFDMHEF.InstantiateAsChild(mDogtagPrefab, mDogtagsGrid.gameObject, string.Format("Dogtag {0}", i.ToString("D2")));
				if (dogTagRecord != null)
				{
					dogTagRecord.SetSpritesOrder(i, HLOOGIDKIDB);
					JIJLIBNGCBA.Add(dogTagRecord);
				}
			}
			BPOOEOLBKND();
			JIJLIBNGCBA.Sort((DogTagRecord IMLEDIOGLEF, DogTagRecord DBPGEFJIFHL) => string.Compare(IMLEDIOGLEF.gameObject.name, DBPGEFJIFHL.gameObject.name, StringComparison.Ordinal));
		}
		else
		{
			for (int num = 0; num < JIJLIBNGCBA.Count; num++)
			{
				JIJLIBNGCBA[num].StopAnimation();
			}
		}
	}

	private void IDKODPBOPBD(bool EEBONFMCINM)
	{
		if (isShowed)
		{
			OEBKMBHGAMN();
		}
	}

	private void MCJACEILFIM(bool EEBONFMCINM)
	{
		if (isShowed)
		{
			OEBKMBHGAMN();
		}
	}

	public virtual void HHLOGFGGHHD()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			OEBKMBHGAMN();
			DHLPICLCEBJ(Singleton<GameController>.instance.BAKCODKBCPJ());
		}
	}
}
