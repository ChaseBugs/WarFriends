using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponAugFusion : Core_BaseScript
{
	[SerializeField]
	private UILabel mAugmentationTitle;

	[SerializeField]
	private GameObject mInfoPart;

	[SerializeField]
	private UIPanel mFusionPanel;

	[SerializeField]
	private UISprite[] mArrows;

	[SerializeField]
	private UISprite mWhiteFlashPanel;

	[SerializeField]
	private UISprite mLevelUpTitleBackground;

	[SerializeField]
	private UILabel mLevelUpLabel;

	[SerializeField]
	private UILabel mAugmentationTypeLabel;

	[SerializeField]
	private UISprite mAugmentationTypeIcon;

	[SerializeField]
	private UILabel mAugmentationRarityLabel;

	[SerializeField]
	private List<WeaponAugFusionSlot> mFuseSlots;

	[SerializeField]
	private UILabel mLevelLabel;

	[SerializeField]
	private UISprite mProgressSprite;

	[SerializeField]
	private UILabel mMaxLevelLabel;

	[SerializeField]
	private UILabel mProgressXpLabel;

	[SerializeField]
	private UILabel mDamageTitle;

	[SerializeField]
	private UILabel mDamageLabel;

	[SerializeField]
	private UILabel mStatNameLabel;

	[SerializeField]
	private UILabel mStatLabel;

	[SerializeField]
	private GameObject mEffectPart;

	[SerializeField]
	private UISprite mEffektBackground;

	[SerializeField]
	private UILabel mEffectNameLabel;

	[SerializeField]
	private GameObject mMaterialsPart;

	[SerializeField]
	private GameObject mNonMaterialsPart;

	[SerializeField]
	private UILabel mMaterialsAmountLabel;

	[SerializeField]
	private UILabel mMaterialsUsedLabel;

	[SerializeField]
	private UILabel mMaterialsInfoLabel;

	[SerializeField]
	private GameObject mButtonsPart;

	[SerializeField]
	private GameObject mRemoveButton;

	[SerializeField]
	private UILabel mWarbucksLabel;

	[SerializeField]
	private BoxCollider mFusionButtonCollider;

	[SerializeField]
	private BoxCollider mRemoveButtonCollider;

	[SerializeField]
	private GameObject mEmptyInfoPart;

	public List<JBEPBGJGPBN> IPMBLCHKOEI;

	public WeaponAugFusionSlot HMNAJFONABD;

	private List<int> MIALIPDBKMB;

	private List<int> CKCGPFMCDNP;

	private List<int> DIJGDFJNBAO;

	private int BFIAEJMFHKM;

	private int ILDENCJNJPG;

	private int OFJALAMFPNM;

	private const float AJNLEBENIKC = 1f / 15f;

	[CompilerGenerated]
	private Action<int> EGOHNKBKLGN;

	public bool isAllFuseSlotsFull => false;

	public event Action<int> AugmentationRemovedFromFuse
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void InitControls()
	{
	}

	public void InitGUIValues()
	{
	}

	public void AddAugForFuse(JBEPBGJGPBN HILNKGONIOM)
	{
	}

	public void ShowMaterialsScreen(int EPNGMAHENPA)
	{
	}

	public void AddMaterialsForFusion()
	{
	}

	public bool CanAddMaterialsForFusion()
	{
		return false;
	}

	private int MPAEENDFJOJ()
	{
		return 0;
	}

	private void BDENBNGCMIM()
	{
	}

	public void UpdateSelectedAugmentationInfo(JBEPBGJGPBN BNIJJEMJLEB)
	{
	}

	private void PEEGIINGGBG(GameObject LJFDGDIAGIN)
	{
	}

	private void GDINGLJIJBN()
	{
	}

	private void NGGHMAMIJKC(GameObject LJFDGDIAGIN)
	{
	}

	private void AKGGMOBONJB()
	{
	}

	private void LMHIAKAEEPI(bool NKJBHGGIIHP)
	{
	}

	private void DMNDCBLCAEO()
	{
	}

	private void NGEOFCCFBII()
	{
	}

	private void JFANBAHMKNL()
	{
	}

	private void HLGAEAEKPJP()
	{
	}

	public void ClearSlots()
	{
	}

	public void ClearSelected()
	{
	}

	public bool IsInFuseList(int ILHCOEHJJIB)
	{
		return false;
	}

	private void FEEIODHIEPJ()
	{
	}

	private void FPGKJGIKNAP()
	{
	}

	private int AMIBKGJJOAM(float IGPDMLPNJCH)
	{
		return 0;
	}

	private void LDIGDJOJFAC(DatabaseAction JMAECKMPPBI)
	{
	}

	[CompilerGenerated]
	private void ABMGFIBEOHN(bool EGMJAECMHBP)
	{
	}

	[CompilerGenerated]
	private void EIDNKCKAKJA(UITweener GDPAJADKOPD)
	{
	}

	[CompilerGenerated]
	private void IMEJLHJBJOA(UITweener GDPAJADKOPD)
	{
	}

	[CompilerGenerated]
	private void PDBCGNNAPID(UITweener OCHLHHNEIKM)
	{
	}

	[CompilerGenerated]
	private void OLLDOGNHOLE(UITweener BMCHOHICKEC)
	{
	}

	[CompilerGenerated]
	private void AEDCMGICEMG(UITweener PJBDIDOOCHN)
	{
	}
}
