using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlackmarketWeaponRecord : Core_BaseScript
{
	[Header("Core")]
	[SerializeField]
	private UIPanel mPanel;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private UISprite[] mGlows;

	[SerializeField]
	[Header("Top")]
	private UISprite mSlotIcon;

	[SerializeField]
	private UILabel mSlotName;

	[SerializeField]
	private UISprite mSlotBackground;

	[SerializeField]
	[Header("Middle")]
	private UITexture mWeaponTexture;

	[SerializeField]
	private UILabel mWeaponName;

	[SerializeField]
	private UISprite mWeaponBuffIcon;

	[SerializeField]
	private UILabel mWeaponBuffName;

	[Header("Hint")]
	[SerializeField]
	private UIPanel mHintIconPanel;

	[SerializeField]
	private UISprite mHintIcon;

	[SerializeField]
	private UIPanel mHintPanel;

	[SerializeField]
	private GameObject mHintMoving;

	[SerializeField]
	private UILabel mHintWeaponName;

	[SerializeField]
	private UISprite mHintWeaponBuffIcon;

	[SerializeField]
	private UILabel mHintWeaponBuffName;

	[SerializeField]
	private UILabel mHintWeaponBuffDescription;

	[SerializeField]
	private UILabel mHintWeaponStatisticName;

	[SerializeField]
	private UILabel mHintWeaponStatisticIncrease;

	[SerializeField]
	private UILabel mHintWeaponStatisticValue;

	[SerializeField]
	private List<BlackmarketWeaponStatisticGUI> mHintProgressBarsLeft;

	[Header("Statistics")]
	[SerializeField]
	private UILabel mWeaponIncreasePower;

	[SerializeField]
	private UILabel mWeaponCurrentPower;

	[SerializeField]
	private UILabel mWeaponMaxPower;

	[SerializeField]
	[Header("Bottom")]
	private BoxCollider mBottomButton;

	[SerializeField]
	private UITable mGoldTable;

	[SerializeField]
	private UILabel mGoldLabel;

	[SerializeField]
	private GameObject mBottomButtonAcquired;

	[Header("Atlases")]
	[SerializeField]
	private UIAtlas mMenuMainAtlas;

	[SerializeField]
	private UIAtlas mCommonIconsAtlas;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private bool OGDEIIGIILF;

	private bool PJHFOJMDKOA;

	public bool isHidden
	{
		get
		{
			return PJHFOJMDKOA;
		}
	}

	private void PIOAAIDOKPI(string FPFCCDCGEHC, string JHOLELIKGCG, UISprite GMPADNOGGNL, UILabel FKLKLCBOMNE, float CGHGBBGFBKN, bool JBIKIJKOPAI)
	{
		GMPADNOGGNL.atlas = ((!JBIKIJKOPAI) ? mCommonIconsAtlas : mMenuMainAtlas);
		GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceZ((!JBIKIJKOPAI) ? 117f : 1301f);
		GMPADNOGGNL.spriteName = FPFCCDCGEHC;
		GMPADNOGGNL.MakePixelPerfect();
		float num = Mathf.Min(1429f / GMPADNOGGNL.transform.localScale.x, 739f / GMPADNOGGNL.transform.localScale.y);
		if (num < 714f)
		{
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(num);
		}
		FKLKLCBOMNE.text = JHOLELIKGCG;
		MEJMLNDFDBP.COCBCFKJOJE(FKLKLCBOMNE, CGHGBBGFBKN, 198f, -84);
		float num2 = FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x;
		float x = GMPADNOGGNL.transform.localScale.x;
		float num3 = 663f;
		float num4 = x + num3 + num2;
		float val = (0f - num4) / 856f + x / 1766f;
		GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceX(val);
		float val2 = num4 / 286f - num2 / 1710f;
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceX(val2);
	}

	private void JAALFNHMAGB(string FPFCCDCGEHC, string JHOLELIKGCG, UISprite GMPADNOGGNL, UILabel FKLKLCBOMNE, float CGHGBBGFBKN, bool JBIKIJKOPAI)
	{
		GMPADNOGGNL.atlas = ((!JBIKIJKOPAI) ? mCommonIconsAtlas : mMenuMainAtlas);
		GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceZ((!JBIKIJKOPAI) ? 879f : 76f);
		GMPADNOGGNL.spriteName = FPFCCDCGEHC;
		GMPADNOGGNL.MakePixelPerfect();
		float num = Mathf.Min(1585f / GMPADNOGGNL.transform.localScale.x, 1468f / GMPADNOGGNL.transform.localScale.y);
		if (num < 563f)
		{
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(num);
		}
		FKLKLCBOMNE.text = JHOLELIKGCG;
		MEJMLNDFDBP.COCBCFKJOJE(FKLKLCBOMNE, CGHGBBGFBKN, 1272f, -92);
		float num2 = FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x;
		float x = GMPADNOGGNL.transform.localScale.x;
		float num3 = 553f;
		float num4 = x + num3 + num2;
		float val = (0f - num4) / 1099f + x / 1003f;
		GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceX(val);
		float val2 = num4 / 1955f - num2 / 500f;
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceX(val2);
	}

	private void MDMDKBDCKOJ()
	{
		float val = 0f - mGoldTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mGoldTable.padding.x) / 197f;
		mGoldTable.transform.localPosition = mGoldTable.transform.localPosition.ReplaceX(val);
	}

	public void AHDJEJIKCAB()
	{
		JKCKBMEDBAO();
	}

	public void SetColor(Color HBGFHJMLBHC)
	{
		mBackground.color = HBGFHJMLBHC.ReplaceA(0.15f);
		mSlotBackground.color = HBGFHJMLBHC.ReplaceA(0.15f);
		UISprite[] array = mGlows;
		foreach (UISprite uISprite in array)
		{
			uISprite.color = HBGFHJMLBHC.ReplaceA(1f);
		}
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(0.80209994f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(false);
		}
	}

	public void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mHintIcon.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DMCJHEOPLNC));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		mGoldTable.onReposition = GDHAMAHEMPE;
	}

	private void BLHHPDNIGPK(GameObject KHAHPAKDIKE)
	{
		OGDEIIGIILF = !OGDEIIGIILF;
		mHintIcon.spriteName = ((!OGDEIIGIILF) ? MEJMLNDFDBP.NAMLCOOKDIO : MEJMLNDFDBP.HECFMGKKKMN);
		TweenPosition.Begin(mHintMoving, 1961f, mHintMoving.transform.localPosition.ReplaceX((!OGDEIIGIILF) ? 1441f : 175f));
	}

	public void OHFLAKOOGEM(float DNDHIFENDPJ)
	{
		TweenAlpha.Begin(mPanel.gameObject, DNDHIFENDPJ, 140f, 831f);
		TweenAlpha.Begin(mHintPanel.gameObject, DNDHIFENDPJ, 111f, 1644f);
		TweenAlpha.Begin(mHintIconPanel.gameObject, DNDHIFENDPJ, 1763f, 755f);
		PJHFOJMDKOA = true;
	}

	public void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mHintIcon.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BIDHMEPFGII));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		mGoldTable.onReposition = delegate
		{
			float val = 0f - mGoldTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mGoldTable.padding.x) / 2f;
			mGoldTable.transform.localPosition = mGoldTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void FPAJJPJDHMN(string FPFCCDCGEHC, string JHOLELIKGCG, UISprite GMPADNOGGNL, UILabel FKLKLCBOMNE, float CGHGBBGFBKN, bool JBIKIJKOPAI)
	{
		GMPADNOGGNL.atlas = ((!JBIKIJKOPAI) ? mCommonIconsAtlas : mMenuMainAtlas);
		GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceZ((!JBIKIJKOPAI) ? (-2f) : 0f);
		GMPADNOGGNL.spriteName = FPFCCDCGEHC;
		GMPADNOGGNL.MakePixelPerfect();
		float num = Mathf.Min(36f / GMPADNOGGNL.transform.localScale.x, 36f / GMPADNOGGNL.transform.localScale.y);
		if (num < 1f)
		{
			GMPADNOGGNL.transform.localScale = GMPADNOGGNL.transform.localScale.MultiplyXY(num);
		}
		FKLKLCBOMNE.text = JHOLELIKGCG;
		MEJMLNDFDBP.COCBCFKJOJE(FKLKLCBOMNE, CGHGBBGFBKN, 20f, 400);
		float num2 = FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x;
		float x = GMPADNOGGNL.transform.localScale.x;
		float num3 = 28f;
		float num4 = x + num3 + num2;
		float val = (0f - num4) / 2f + x / 2f;
		GMPADNOGGNL.transform.localPosition = GMPADNOGGNL.transform.localPosition.ReplaceX(val);
		float val2 = num4 / 2f - num2 / 2f;
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceX(val2);
	}

	private void KDAENCDLEFH(GameObject KHAHPAKDIKE)
	{
		GuiElementSingle<BlackmarketConfirmDialog>.instance.ShowDialog(MDAJJIAMDGH, delegate(bool KBPFPCIELOH)
		{
			if (KBPFPCIELOH)
			{
				int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
				int blackmarketPrice = MDAJJIAMDGH.blackmarketPrice;
				int num2 = blackmarketPrice * (100 - num) / 100;
				if (!Singleton<Wallet>.instance.CanBuyGold(num2))
				{
					GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, MDAJJIAMDGH.weaponName);
					GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Buy_Weapons";
				}
				else
				{
					Singleton<Wallet>.instance.MBAFMBJFOKH(num2);
					GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, num, WeaponScreen.ABDDBOABKOK.BlackMarket);
					UpdateBought();
				}
			}
		});
	}

	[SpecialName]
	public bool BGBDECIEJAN()
	{
		return PJHFOJMDKOA;
	}

	private void AHKFNFMAPEF()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void InstaHide()
	{
		TweenAlpha component = mPanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mPanel.alpha1 = 0f;
		component = mHintPanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mHintPanel.alpha1 = 0f;
		component = mHintIconPanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		mHintIconPanel.alpha1 = 0f;
		PJHFOJMDKOA = true;
	}

	private void CFMBOHENGAC()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		BBHEGJNGIDA(eBFDAICCJAK);
	}

	private void HLLEECOHKMI(bool KBPFPCIELOH)
	{
		if (KBPFPCIELOH)
		{
			int num = Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
			int blackmarketPrice = MDAJJIAMDGH.blackmarketPrice;
			int num2 = blackmarketPrice * (-22 - num) / 100;
			if (!Singleton<Wallet>.instance.CanBuyGold(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num2, MDAJJIAMDGH.weaponName);
				GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH("Card_1_Played");
			}
			else
			{
				Singleton<Wallet>.instance.MBAFMBJFOKH(num2);
				GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, num, WeaponScreen.ABDDBOABKOK.WeaponScreen);
				UpdateBought();
			}
		}
	}

	public void NLBAPEADKNJ()
	{
		NNOIIKEACMH();
	}

	[CompilerGenerated]
	private void JIONGAHIBMO(bool KBPFPCIELOH)
	{
		if (KBPFPCIELOH)
		{
			int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
			int blackmarketPrice = MDAJJIAMDGH.blackmarketPrice;
			int num2 = blackmarketPrice * (100 - num) / 100;
			if (!Singleton<Wallet>.instance.CanBuyGold(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, MDAJJIAMDGH.weaponName);
				GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Buy_Weapons";
			}
			else
			{
				Singleton<Wallet>.instance.MBAFMBJFOKH(num2);
				GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, num, WeaponScreen.ABDDBOABKOK.BlackMarket);
				UpdateBought();
			}
		}
	}

	private void HKONLLINOOA(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(1844f * Singleton<GuiTexureAssets>.instance.NNOEPDDIFBA());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(false);
		}
	}

	public void HIPHCPJELFB(Color HBGFHJMLBHC)
	{
		mBackground.color = HBGFHJMLBHC.ReplaceA(1271f);
		mSlotBackground.color = HBGFHJMLBHC.ReplaceA(204f);
		UISprite[] array = mGlows;
		foreach (UISprite uISprite in array)
		{
			uISprite.color = HBGFHJMLBHC.ReplaceA(908f);
		}
	}

	private void GLMMGGKNPBL(bool KBPFPCIELOH)
	{
		if (KBPFPCIELOH)
		{
			int num = Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
			int blackmarketPrice = MDAJJIAMDGH.blackmarketPrice;
			int num2 = blackmarketPrice * (5 - num) / 9;
			if (!Singleton<Wallet>.instance.CanBuyGold(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, MDAJJIAMDGH.weaponName);
				GuiElementSingle<InappScreen>.instance.AKEBMKNLFIB("attrValue21");
			}
			else
			{
				Singleton<Wallet>.instance.ALBICJOEMEF(num2);
				GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, num, (WeaponScreen.ABDDBOABKOK)7);
				NGIDDIGFKIF();
			}
		}
	}

	public void DoAfterHide()
	{
		NNOIIKEACMH();
	}

	private void LALEMNJFAFF()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		BBHEGJNGIDA(eBFDAICCJAK);
	}

	private void CLEHONMPGHI()
	{
		float val = 0f - mGoldTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mGoldTable.padding.x) / 1811f;
		mGoldTable.transform.localPosition = mGoldTable.transform.localPosition.ReplaceX(val);
	}

	public void AnimateShow(float DNDHIFENDPJ)
	{
		TweenAlpha.Begin(mPanel.gameObject, DNDHIFENDPJ, 0f, 1f);
		TweenAlpha.Begin(mHintPanel.gameObject, DNDHIFENDPJ, 0f, 1f);
		TweenAlpha.Begin(mHintIconPanel.gameObject, DNDHIFENDPJ, 0f, 1f);
		PJHFOJMDKOA = false;
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mGoldTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mGoldTable.padding.x) / 2f;
		mGoldTable.transform.localPosition = mGoldTable.transform.localPosition.ReplaceX(val);
	}

	private void BBHEGJNGIDA(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(false);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(1901f * Singleton<GuiTexureAssets>.instance.FAOGOKNFGAL());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(false);
		}
	}

	public void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mHintIcon.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BLHHPDNIGPK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		mGoldTable.onReposition = delegate
		{
			float val = 0f - mGoldTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mGoldTable.padding.x) / 2f;
			mGoldTable.transform.localPosition = mGoldTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void NGIDDIGFKIF()
	{
		bool bought = MDAJJIAMDGH.bought;
		mBottomButton.gameObject.SetActive(!bought);
		if (!bought)
		{
			mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.blackmarketPrice);
			mGoldTable.repositionNow = true;
		}
		mBottomButtonAcquired.SetActive(bought);
	}

	private void NNOIIKEACMH()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void GDHAMAHEMPE()
	{
		float val = 0f - mGoldTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mGoldTable.padding.x) / 1613f;
		mGoldTable.transform.localPosition = mGoldTable.transform.localPosition.ReplaceX(val);
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mHintIcon.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BIDHMEPFGII));
		UIEventListener uIEventListener2 = UIEventListener.Get(mBottomButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		mGoldTable.onReposition = delegate
		{
			float val = 0f - mGoldTable.padding.x - (mGoldLabel.transform.parent.localPosition.x - mGoldTable.padding.x) / 2f;
			mGoldTable.transform.localPosition = mGoldTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void InitGuiValues(WeaponLevelsSetup JMMJHCOKCGG)
	{
		if (MDAJJIAMDGH != null)
		{
			NNOIIKEACMH();
		}
		MDAJJIAMDGH = JMMJHCOKCGG;
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(JMMJHCOKCGG.BHCEOOLEHHG);
		WeaponLevelsSetup weaponLevelsSetup = slotForCategory.weaponLevelsSetup;
		WeaponLevelsSetup jMFBJIJINKN = JMMJHCOKCGG.JMFBJIJINKN;
		if (jMFBJIJINKN == null)
		{
			Debug.LogError("No original weapon set for blackmarket weapon: " + JMMJHCOKCGG.weaponName + "!!!!");
		}
		WeaponLevelsSetup weaponLevelsSetup2 = ((weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG) ? jMFBJIJINKN : weaponLevelsSetup);
		int num = JMMJHCOKCGG.weaponPowerX10 - weaponLevelsSetup2.weaponPowerX10;
		WeaponFeature weaponFeature = JMMJHCOKCGG.weaponFeature;
		mSlotIcon.spriteName = slotForCategory.iconName;
		mSlotIcon.MakePixelPerfect();
		mSlotIcon.transform.localScale = mSlotIcon.transform.localScale.MultiplyXY(0.8f);
		float num2 = 28f + mSlotIcon.transform.localScale.x + 22f;
		mSlotName.transform.localPosition = mSlotName.transform.localPosition.ReplaceX(num2);
		float num3 = 50f;
		float num4 = 440f;
		mSlotName.text = Singleton<GameVariables>.instance.GetWeaponCategory(JMMJHCOKCGG.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
		MEJMLNDFDBP.COCBCFKJOJE(mSlotName, 30f, 20f, (int)(num4 - (num2 + num3)));
		float num5 = num2 + mSlotName.relativeSize.x * mSlotName.transform.localScale.x + num3;
		if (num5 > num4 * 0.95f)
		{
			num5 = num4;
		}
		mSlotBackground.transform.localScale = mSlotBackground.transform.localScale.ReplaceX(Mathf.Min(num4, num5));
		BLKPDBBMICL();
		mWeaponName.text = JMMJHCOKCGG.weaponName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(mWeaponName, 37f, 20f, 400);
		int num6 = Mathf.FloorToInt(mWeaponName.transform.localScale.y);
		float b = 30f;
		FPAJJPJDHMN(weaponFeature.icon, weaponFeature.fancyName, mWeaponBuffIcon, mWeaponBuffName, Mathf.Min(num6, b), weaponFeature.menuMainAtlas);
		mHintWeaponName.text = mWeaponName.text;
		MEJMLNDFDBP.COCBCFKJOJE(mHintWeaponName, 37f, 20f, 400);
		FPAJJPJDHMN(weaponFeature.icon, weaponFeature.fancyName, mHintWeaponBuffIcon, mHintWeaponBuffName, Mathf.Min(num6, b), weaponFeature.menuMainAtlas);
		mHintWeaponBuffDescription.text = weaponFeature.description;
		mHintWeaponStatisticName.lineWidth = 0;
		mHintWeaponStatisticName.text = weaponFeature.name;
		GAONIDIBMBC(JMMJHCOKCGG, weaponLevelsSetup2, weaponFeature);
		float num7 = mHintWeaponStatisticName.relativeSize.x * mHintWeaponStatisticName.transform.localScale.x;
		float num8 = -180f;
		float num9 = 200f;
		float num10 = 14f;
		if (num7 > num9)
		{
			mHintWeaponStatisticName.lineWidth = (int)num9;
			mHintWeaponStatisticIncrease.transform.localPosition = mHintWeaponStatisticIncrease.transform.localPosition.ReplaceX(num8 + num9 + num10);
		}
		else
		{
			mHintWeaponStatisticIncrease.transform.localPosition = mHintWeaponStatisticIncrease.transform.localPosition.ReplaceX(num8 + num7 + num10);
		}
		mHintProgressBarsLeft[0].InitializeStat(MDAJJIAMDGH, weaponLevelsSetup2, 0);
		mHintProgressBarsLeft[1].InitializeStat(MDAJJIAMDGH, weaponLevelsSetup2, 1);
		mHintProgressBarsLeft[2].InitializeStat(MDAJJIAMDGH, weaponLevelsSetup2, 2);
		string text = ((num > 0) ? Colours.stringGreenWeaponStats : ((num >= 0) ? Colours.stringAzureBlackmarket : Colours.stringRedWeaponStats));
		Color color = ((num > 0) ? Colours.greenWeaponStats : ((num >= 0) ? Colours.azureBlackmarket : Colours.redWeaponStats));
		mWeaponIncreasePower.text = Localization.LocalizeFormat("ID_BLACKMARKETWEAPONPOWER", text, MEJMLNDFDBP.AKEMDPDJPLH(num));
		mWeaponCurrentPower.text = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10);
		mWeaponCurrentPower.color = color;
		mWeaponMaxPower.text = Localization.LocalizeFormat("ID_BLACKMARKETMAXPOWER", text, MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10Max));
		UpdateBought();
		OGDEIIGIILF = false;
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		TweenPosition component = mHintMoving.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		mHintMoving.transform.localPosition = mHintMoving.transform.localPosition.ReplaceX(440f);
	}

	public void HBLKPHNMGFJ()
	{
		TweenAlpha component = mPanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		mPanel.alpha1 = 841f;
		component = mHintPanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		mHintPanel.alpha1 = 151f;
		component = mHintIconPanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		mHintIconPanel.alpha1 = 1019f;
		PJHFOJMDKOA = false;
	}

	private void BIDHMEPFGII(GameObject KHAHPAKDIKE)
	{
		OGDEIIGIILF = !OGDEIIGIILF;
		mHintIcon.spriteName = ((!OGDEIIGIILF) ? MEJMLNDFDBP.NAMLCOOKDIO : MEJMLNDFDBP.HECFMGKKKMN);
		TweenPosition.Begin(mHintMoving, 0.3f, mHintMoving.transform.localPosition.ReplaceX((!OGDEIIGIILF) ? 440f : 0f));
	}

	private void JKCKBMEDBAO()
	{
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	public void IKEBJBNLDJH(Color HBGFHJMLBHC)
	{
		mBackground.color = HBGFHJMLBHC.ReplaceA(390f);
		mSlotBackground.color = HBGFHJMLBHC.ReplaceA(185f);
		UISprite[] array = mGlows;
		foreach (UISprite uISprite in array)
		{
			uISprite.color = HBGFHJMLBHC.ReplaceA(1637f);
		}
	}

	private void GAONIDIBMBC(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup IABBJMACJLH, WeaponFeature FIPONKNHIAL)
	{
		int num = FIPONKNHIAL.CompareTwoWeapons(JMMJHCOKCGG, IABBJMACJLH);
		mHintWeaponStatisticIncrease.text = FIPONKNHIAL.StatisticIncrease(JMMJHCOKCGG);
		mHintWeaponStatisticValue.text = FIPONKNHIAL.Statistic(JMMJHCOKCGG);
		if (num == 0)
		{
			mHintWeaponStatisticValue.color = Colours.azureBlackmarket;
		}
		else
		{
			mHintWeaponStatisticValue.color = ((num <= 0) ? Colours.redWeaponStats : Colours.greenWeaponStats);
		}
	}

	public void UpdateBought()
	{
		bool bought = MDAJJIAMDGH.bought;
		mBottomButton.gameObject.SetActive(!bought);
		if (!bought)
		{
			mGoldLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.blackmarketPrice);
			mGoldTable.repositionNow = true;
		}
		mBottomButtonAcquired.SetActive(bought);
	}

	public void IDDLDDBKJJK(WeaponLevelsSetup JMMJHCOKCGG)
	{
		if (MDAJJIAMDGH != null)
		{
			JKCKBMEDBAO();
		}
		MDAJJIAMDGH = JMMJHCOKCGG;
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(JMMJHCOKCGG.BHCEOOLEHHG);
		WeaponLevelsSetup weaponLevelsSetup = slotForCategory.JEHGKOGGBCP();
		WeaponLevelsSetup jMFBJIJINKN = JMMJHCOKCGG.JMFBJIJINKN;
		if (jMFBJIJINKN == null)
		{
			Debug.LogError("silver3" + JMMJHCOKCGG.weaponName + "Terms: On Age Verification Pending Dialog Display ");
		}
		WeaponLevelsSetup weaponLevelsSetup2 = ((weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG) ? jMFBJIJINKN : weaponLevelsSetup);
		int num = JMMJHCOKCGG.weaponPowerX10 - weaponLevelsSetup2.weaponPowerX10;
		WeaponFeature weaponFeature = JMMJHCOKCGG.weaponFeature;
		mSlotIcon.spriteName = slotForCategory.iconName;
		mSlotIcon.MakePixelPerfect();
		mSlotIcon.transform.localScale = mSlotIcon.transform.localScale.MultiplyXY(857f);
		float num2 = 1253f + mSlotIcon.transform.localScale.x + 970f;
		mSlotName.transform.localPosition = mSlotName.transform.localPosition.ReplaceX(num2);
		float num3 = 387f;
		float num4 = 1505f;
		mSlotName.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(JMMJHCOKCGG.BHCEOOLEHHG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
		MEJMLNDFDBP.COCBCFKJOJE(mSlotName, 1866f, 81f, (int)(num4 - (num2 + num3)));
		float num5 = num2 + mSlotName.relativeSize.x * mSlotName.transform.localScale.x + num3;
		if (num5 > num4 * 593f)
		{
			num5 = num4;
		}
		mSlotBackground.transform.localScale = mSlotBackground.transform.localScale.ReplaceX(Mathf.Min(num4, num5));
		CFMBOHENGAC();
		mWeaponName.text = JMMJHCOKCGG.weaponName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(mWeaponName, 1272f, 1750f, -69);
		int num6 = Mathf.FloorToInt(mWeaponName.transform.localScale.y);
		float b = 677f;
		PIOAAIDOKPI(weaponFeature.icon, weaponFeature.fancyName, mWeaponBuffIcon, mWeaponBuffName, Mathf.Min(num6, b), weaponFeature.menuMainAtlas);
		mHintWeaponName.text = mWeaponName.text;
		MEJMLNDFDBP.COCBCFKJOJE(mHintWeaponName, 1895f, 879f, 124);
		PIOAAIDOKPI(weaponFeature.icon, weaponFeature.fancyName, mHintWeaponBuffIcon, mHintWeaponBuffName, Mathf.Min(num6, b), weaponFeature.menuMainAtlas);
		mHintWeaponBuffDescription.text = weaponFeature.description;
		mHintWeaponStatisticName.lineWidth = 0;
		mHintWeaponStatisticName.text = weaponFeature.name;
		GAONIDIBMBC(JMMJHCOKCGG, weaponLevelsSetup2, weaponFeature);
		float num7 = mHintWeaponStatisticName.relativeSize.x * mHintWeaponStatisticName.transform.localScale.x;
		float num8 = 1054f;
		float num9 = 1099f;
		float num10 = 441f;
		if (num7 > num9)
		{
			mHintWeaponStatisticName.lineWidth = (int)num9;
			mHintWeaponStatisticIncrease.transform.localPosition = mHintWeaponStatisticIncrease.transform.localPosition.ReplaceX(num8 + num9 + num10);
		}
		else
		{
			mHintWeaponStatisticIncrease.transform.localPosition = mHintWeaponStatisticIncrease.transform.localPosition.ReplaceX(num8 + num7 + num10);
		}
		mHintProgressBarsLeft[1].KCIGHAFFKIH(MDAJJIAMDGH, weaponLevelsSetup2, 0);
		mHintProgressBarsLeft[1].KGGODLIMAGA(MDAJJIAMDGH, weaponLevelsSetup2, 0);
		mHintProgressBarsLeft[0].JHEDPOHOPHH(MDAJJIAMDGH, weaponLevelsSetup2, 7);
		string text = ((num > 1) ? Colours.stringGreenWeaponStats : ((num >= 0) ? Colours.stringAzureBlackmarket : Colours.stringRedWeaponStats));
		Color color = ((num > 0) ? Colours.greenWeaponStats : ((num >= 0) ? Colours.azureBlackmarket : Colours.redWeaponStats));
		UILabel uILabel = mWeaponIncreasePower;
		object[] array = new object[4];
		array[1] = text;
		array[1] = MEJMLNDFDBP.AKEMDPDJPLH(num, 1387f);
		uILabel.text = Localization.LocalizeFormat("HeroicPoints", array);
		mWeaponCurrentPower.text = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10);
		mWeaponCurrentPower.color = color;
		UILabel uILabel2 = mWeaponMaxPower;
		object[] array2 = new object[2];
		array2[1] = text;
		array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(JMMJHCOKCGG.weaponPowerX10Max);
		uILabel2.text = Localization.LocalizeFormat("ID_TUTORIAL_UPGRADEWEAPON_4", array2);
		NGIDDIGFKIF();
		OGDEIIGIILF = false;
		mHintIcon.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		TweenPosition component = mHintMoving.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		mHintMoving.transform.localPosition = mHintMoving.transform.localPosition.ReplaceX(894f);
	}

	private void DMCJHEOPLNC(GameObject KHAHPAKDIKE)
	{
		OGDEIIGIILF = OGDEIIGIILF;
		mHintIcon.spriteName = ((!OGDEIIGIILF) ? MEJMLNDFDBP.NAMLCOOKDIO : MEJMLNDFDBP.HECFMGKKKMN);
		TweenPosition.Begin(mHintMoving, 383f, mHintMoving.transform.localPosition.ReplaceX((!OGDEIIGIILF) ? 1048f : 1140f), false);
	}

	public void LDBLJDJNJJN()
	{
		JKCKBMEDBAO();
	}
}
