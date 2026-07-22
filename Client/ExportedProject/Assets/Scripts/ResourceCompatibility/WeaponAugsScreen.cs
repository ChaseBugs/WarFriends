using System.Collections.Generic;
using UnityEngine;

public class WeaponAugsScreen : GuiScreenSingle<WeaponAugsScreen>
{
	private sealed class LPNPCAOAHKM
	{
		public WeaponAugIcon DGOOGJJHOKB;

		internal bool HLEMAMMNCFH(JBEPBGJGPBN CLMNCBPINKO)
		{
			return false;
		}
	}

	[SerializeField]
	private UITable mHeaderTable;

	[SerializeField]
	private UITable mScreenTable;

	[SerializeField]
	private UILabel mCategoryName;

	[SerializeField]
	private UILabel mWeaponName;

	[SerializeField]
	private UILabel mWeaponGrade;

	[SerializeField]
	private UILabel mVisualName;

	[SerializeField]
	private UILabel mAugCountLabel;

	[SerializeField]
	private GameObject mAugmentationSlotsPart;

	[SerializeField]
	private GameObject mStartAugmentingPart;

	public GameObject PLDFGMHICCA;

	[SerializeField]
	private GameObject mMinigunAugsPart;

	[SerializeField]
	private UIPooledGrid mAugsTable;

	[SerializeField]
	private UIDraggablePanel mDraggablePanel;

	[SerializeField]
	private GameObject mAugShopButton;

	[SerializeField]
	private GameObject mMaterialsButton;

	[SerializeField]
	private UISprite mMaterialsHighlight;

	[SerializeField]
	private UILabel mMaterialCountLabel;

	[SerializeField]
	private WeaponAugIcon mAugIconPrefab;

	[SerializeField]
	private GameObject mAugButtonSpacer;

	public WeaponAugDetails BFMJBJGEOEE;

	public WeaponAugFusion APKGJMIOHJM;

	public MaterialsDetails DKOELMPFBKN;

	[SerializeField]
	private GameObject mDebugPart;

	[SerializeField]
	private BoxCollider mDebugAddAllAugsButton;

	[SerializeField]
	private BoxCollider mDebugChangeLevelButton;

	[SerializeField]
	private UIInput mDebugChangeLevelInput;

	public WeaponAugSlot PHNCKJBKFJP;

	public bool GKNBIOJFFAM;

	public JBEPBGJGPBN LFBPDABEDAA;

	public List<WeaponAugSlot> JAAJPPNAKIA;

	public List<WeaponAugSlot> FPGGMPFFNDK;

	private List<JBEPBGJGPBN> EKDNBLIMJBL;

	private List<WeaponAugIcon> AEHOPMIHLJF;

	private bool AMJHIJDDNMJ;

	protected override void LKNLBIMDMAD()
	{
	}

	private void LFFACMNEKIB(GameObject LJFDGDIAGIN)
	{
	}

	private void BAPKLFHBIDO(GameObject LJFDGDIAGIN)
	{
	}

	private void MIHHLNMIBON(DatabaseAction JMAECKMPPBI)
	{
	}

	private void LKPBNKJAACI(GameObject LJFDGDIAGIN)
	{
	}

	public void SetMaterialsHighlight(bool AKJIHJFBJLE)
	{
	}

	public override void InitGUIValues()
	{
	}

	public void SelectFirstAug()
	{
	}

	public void Select(WeaponAugIcon DGOOGJJHOKB)
	{
	}

	public void ClearSlotSelections()
	{
	}

	public void ClearAugSelections()
	{
	}

	public void DimAllPulses()
	{
	}

	public void AugEquipUpdateForInstall()
	{
	}

	public void ClearAugSelectionAndUpdateOverlay()
	{
	}

	public void InitializeLeftPart()
	{
	}

	public void InstallInitialAugs()
	{
	}

	private void NBHKGDHIKPD()
	{
	}

	private Transform OKFIPKBJPIN(int EPNGMAHENPA)
	{
		return null;
	}

	private void HOJLFJCNPJK(Transform KIHIFIBOOIM)
	{
	}

	private WeaponAugIcon OIOCFKNBFEM()
	{
		return null;
	}

	private void IGENBEIPHLG(int PKELBCEPGLI, int ILHCOEHJJIB, WeaponLevelsSetup AEBEOCBIBFI)
	{
	}

	private void EGNAENBJEEG(int ILHCOEHJJIB)
	{
	}

	private void BGAEBNNIJLO(WeaponLevelsSetup AEBEOCBIBFI)
	{
	}

	private void GEHAGOGPLGL(int ILHCOEHJJIB)
	{
	}

	public void FusionHighlightIcons()
	{
	}

	public void UpdateSelectedAug(JBEPBGJGPBN KHNDMJEPKPB)
	{
	}

	public int GetNumOfAvailableSlots(AugmentationManager.GAEKEDEFBBG BDHJHAFLKKC)
	{
		return 0;
	}

	public void HighlightIconsOfType(bool DJKFGMOHPMF)
	{
	}

	public void SetSlotsVisible(bool CJNCFODAPCC)
	{
	}

	public override void DoAfterShowUp()
	{
	}

	public override void DoAfterHide()
	{
	}

	public override void DoBeforeShowUp()
	{
	}

	public override void OnBack()
	{
	}
}
