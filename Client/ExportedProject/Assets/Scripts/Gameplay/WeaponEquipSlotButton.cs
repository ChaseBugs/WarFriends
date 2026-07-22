using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponEquipSlotButton : Core_BaseScript
{
	[Header("Core")]
	[FormerlySerializedAs("MHOPKAHDGMN")]
	public BoxCollider NJEAMAHEMHP;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("HPOCJBBBPOC")]
	public UISprite DAANKCOLJGJ;

	[FormerlySerializedAs("AIEDFPCAJJB")]
	public UILabel FKLKLCBOMNE;

	[FormerlySerializedAs("FFLPEBGOAEJ")]
	[Header("Notification")]
	public UILabel FEBNOLJLPBI;

	[FormerlySerializedAs("CELKKNNGIMN")]
	public GameObject AAOHNMDGEJJ;

	[Header("Sale")]
	[FormerlySerializedAs("IAOPIEBKBJJ")]
	public GameObject GIPFEBBMKPM;

	private string AEFCKLKAGEH = "menu-weapons-tab-active";

	private string GMFPGEGPJDO = "menu-weapons-tab";

	private PlayerInventory.InventorySlot FJPOKMGJCKF;

	public WeaponCategory weaponCategory => FJPOKMGJCKF.category;

	private void PBLMKGCBONK(bool NABOFKMBMKH)
	{
		DAANKCOLJGJ.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		FKLKLCBOMNE.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		KMFGCJEGJJK.spriteName = ((!NABOFKMBMKH) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	public void IIGOGILLPCJ(WeaponCategory FABOAIMLLOI)
	{
		ENKBKLCBKED(FABOAIMLLOI == (FABOAIMLLOI & FJPOKMGJCKF.category));
	}

	public void PPFGIHIODHP(WeaponCategory FABOAIMLLOI)
	{
		CJLDDEDDIPJ(FABOAIMLLOI == (FABOAIMLLOI & FJPOKMGJCKF.category));
	}

	public void JDNDNKPPAIE()
	{
		int numberOfWeaponCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfWeaponCategoryNotifications(FJPOKMGJCKF.category);
		AAOHNMDGEJJ.SetActive(numberOfWeaponCategoryNotifications > 0);
		FEBNOLJLPBI.text = numberOfWeaponCategoryNotifications.ToString();
	}

	public void OOGJJGIPDKB()
	{
		int num = Singleton<NotificationManager>.instance.PHNPEBKCPEO(FJPOKMGJCKF.category);
		AAOHNMDGEJJ.SetActive(num > 0);
		FEBNOLJLPBI.text = num.ToString();
	}

	public void OHMIGANDELN()
	{
		int num = Singleton<NotificationManager>.instance.PHNPEBKCPEO(FJPOKMGJCKF.category);
		AAOHNMDGEJJ.SetActive(num > 0);
		FEBNOLJLPBI.text = num.ToString();
	}

	public void EOHLHMGJADL(WeaponCategory FABOAIMLLOI)
	{
		NPLKPDIOLHE(FABOAIMLLOI == (FABOAIMLLOI & FJPOKMGJCKF.category));
	}

	private void BIKMNMLENGN()
	{
		GuiScreenSingle<WeaponScreen>.instance.NMJPGMLMCAD(FJPOKMGJCKF.category);
	}

	private void OnClick()
	{
		GuiScreenSingle<WeaponScreen>.instance.WeaponCategoryButtonClick(FJPOKMGJCKF.category);
	}

	public void OLACMPFNMLH(WeaponCategory FABOAIMLLOI)
	{
		PBLMKGCBONK(FABOAIMLLOI == (FABOAIMLLOI & FJPOKMGJCKF.category));
	}

	private void PECHFIBKEJO(bool NABOFKMBMKH)
	{
		DAANKCOLJGJ.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		FKLKLCBOMNE.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		KMFGCJEGJJK.spriteName = ((!NABOFKMBMKH) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	public void Notification()
	{
		int numberOfWeaponCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfWeaponCategoryNotifications(FJPOKMGJCKF.category);
		AAOHNMDGEJJ.SetActive(numberOfWeaponCategoryNotifications > 0);
		FEBNOLJLPBI.text = numberOfWeaponCategoryNotifications.ToString();
	}

	public void FOPDJBDDFLP(WeaponCategory FABOAIMLLOI)
	{
		CBJALAENKFE(FABOAIMLLOI == (FABOAIMLLOI & FJPOKMGJCKF.category));
	}

	private void ENKBKLCBKED(bool NABOFKMBMKH)
	{
		DAANKCOLJGJ.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		FKLKLCBOMNE.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		KMFGCJEGJJK.spriteName = ((!NABOFKMBMKH) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	private void ADALENIJNHD()
	{
		GuiScreenSingle<WeaponScreen>.instance.WeaponCategoryButtonClick(FJPOKMGJCKF.category);
	}

	private void CJLDDEDDIPJ(bool NABOFKMBMKH)
	{
		DAANKCOLJGJ.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		FKLKLCBOMNE.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		KMFGCJEGJJK.spriteName = ((!NABOFKMBMKH) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	public void Highlight(WeaponCategory FABOAIMLLOI)
	{
		DPPIKPAIEHD(FABOAIMLLOI == (FABOAIMLLOI & FJPOKMGJCKF.category));
	}

	public void OONPLEAJJMP()
	{
		int numberOfWeaponCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfWeaponCategoryNotifications(FJPOKMGJCKF.category);
		AAOHNMDGEJJ.SetActive(numberOfWeaponCategoryNotifications > 1);
		FEBNOLJLPBI.text = numberOfWeaponCategoryNotifications.ToString();
	}

	public void IEEAKDJHHBH()
	{
		bool flag = Singleton<OfferManager>.instance.FOILGIALCLF(FJPOKMGJCKF.category, (AKDLEDNDIEO)5) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(FJPOKMGJCKF.category, (AKDLEDNDIEO)4) > 0;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.BHCEOOLEHHG == (FJPOKMGJCKF.category & weaponLevelsSetup.BHCEOOLEHHG) && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == (FJPOKMGJCKF.category & weaponLevelsSetup.BHCEOOLEHHG) && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || !flag2 || flag4);
	}

	public void IOLIFHONNOP(WeaponCategory FABOAIMLLOI)
	{
		PBLMKGCBONK(FABOAIMLLOI == (FABOAIMLLOI & FJPOKMGJCKF.category));
	}

	private void BANCDJNFHIC(bool NABOFKMBMKH)
	{
		DAANKCOLJGJ.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		FKLKLCBOMNE.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		KMFGCJEGJJK.spriteName = ((!NABOFKMBMKH) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	private void DCMNJKEPDJO()
	{
		GuiScreenSingle<WeaponScreen>.instance.NMJPGMLMCAD(FJPOKMGJCKF.category);
	}

	private void MMCNCJPBOCH()
	{
		GuiScreenSingle<WeaponScreen>.instance.WeaponCategoryButtonClick(FJPOKMGJCKF.category);
	}

	public void ACCNFEPGPJA(WeaponCategory FABOAIMLLOI)
	{
		CJLDDEDDIPJ(FABOAIMLLOI == (FABOAIMLLOI & FJPOKMGJCKF.category));
	}

	public void JPBOGGKMAON(PlayerInventory.InventorySlot GAJILAIDNHM, int PDMGPGEHLNM)
	{
		FJPOKMGJCKF = GAJILAIDNHM;
		FKLKLCBOMNE.text = FJPOKMGJCKF.LAGBFMEGECF();
		OONPLEAJJMP();
		IEEAKDJHHBH();
		DAANKCOLJGJ.spriteName = FJPOKMGJCKF.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		CBJALAENKFE(NABOFKMBMKH: false);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 827f;
		MEJMLNDFDBP.COCBCFKJOJE(FKLKLCBOMNE, 1335f, 795f, (int)num - 126);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 485f);
		GIPFEBBMKPM.transform.localPosition = GIPFEBBMKPM.transform.localPosition.ReplaceX(num - 1413f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 1012f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 28f);
	}

	[SpecialName]
	public WeaponCategory MKMKJHGJCEA()
	{
		return FJPOKMGJCKF.category;
	}

	private void CBJALAENKFE(bool NABOFKMBMKH)
	{
		DAANKCOLJGJ.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		FKLKLCBOMNE.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		KMFGCJEGJJK.spriteName = ((!NABOFKMBMKH) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	[SpecialName]
	public WeaponCategory HHKICCEJBJI()
	{
		return FJPOKMGJCKF.category;
	}

	private void AHPBNNEKNBE()
	{
		GuiScreenSingle<WeaponScreen>.instance.WeaponCategoryButtonClick(FJPOKMGJCKF.category);
	}

	private void DPPIKPAIEHD(bool NABOFKMBMKH)
	{
		DAANKCOLJGJ.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		FKLKLCBOMNE.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		KMFGCJEGJJK.spriteName = ((!NABOFKMBMKH) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	[SpecialName]
	public WeaponCategory EKPMLOPODJB()
	{
		return FJPOKMGJCKF.category;
	}

	public void MJNMLOBOLNB()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(FJPOKMGJCKF.category, (AKDLEDNDIEO)5) > 1;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(FJPOKMGJCKF.category, (AKDLEDNDIEO)8) > 0;
		bool flag3 = false;
		bool flag4 = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.BHCEOOLEHHG == (FJPOKMGJCKF.category & weaponLevelsSetup.BHCEOOLEHHG) && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == (FJPOKMGJCKF.category & weaponLevelsSetup.BHCEOOLEHHG) && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((!flag || !flag3) && flag2 && flag4);
	}

	[SpecialName]
	public WeaponCategory DEKJFPPCCOK()
	{
		return FJPOKMGJCKF.category;
	}

	[SpecialName]
	public WeaponCategory CKNGDFJPKIA()
	{
		return FJPOKMGJCKF.category;
	}

	[SpecialName]
	public WeaponCategory PIKKOIHNPDK()
	{
		return FJPOKMGJCKF.category;
	}

	public void MFMJPBCIHEH(PlayerInventory.InventorySlot GAJILAIDNHM, int PDMGPGEHLNM)
	{
		FJPOKMGJCKF = GAJILAIDNHM;
		FKLKLCBOMNE.text = FJPOKMGJCKF.NCFECNEKBPG();
		OONPLEAJJMP();
		IEEAKDJHHBH();
		DAANKCOLJGJ.spriteName = FJPOKMGJCKF.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		DPPIKPAIEHD(NABOFKMBMKH: false);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 1747f;
		MEJMLNDFDBP.COCBCFKJOJE(FKLKLCBOMNE, 55f, 210f, (int)num - 128);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 303f);
		GIPFEBBMKPM.transform.localPosition = GIPFEBBMKPM.transform.localPosition.ReplaceX(num - 543f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 1140f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 390f);
	}

	public void PONFOKHPMMO(PlayerInventory.InventorySlot GAJILAIDNHM, int PDMGPGEHLNM)
	{
		FJPOKMGJCKF = GAJILAIDNHM;
		FKLKLCBOMNE.text = FJPOKMGJCKF.GMBBMIKOODB();
		OONPLEAJJMP();
		IEEAKDJHHBH();
		DAANKCOLJGJ.spriteName = FJPOKMGJCKF.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		CBJALAENKFE(NABOFKMBMKH: false);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 1497f;
		MEJMLNDFDBP.COCBCFKJOJE(FKLKLCBOMNE, 624f, 990f, (int)num - 188);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 1940f);
		GIPFEBBMKPM.transform.localPosition = GIPFEBBMKPM.transform.localPosition.ReplaceX(num - 1098f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 1069f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 148f);
	}

	private void NPLKPDIOLHE(bool NABOFKMBMKH)
	{
		DAANKCOLJGJ.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		FKLKLCBOMNE.color = ((!NABOFKMBMKH) ? Color.white : Colours.blue);
		KMFGCJEGJJK.spriteName = ((!NABOFKMBMKH) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	private void JLOBKIJJAFG()
	{
		GuiScreenSingle<WeaponScreen>.instance.WeaponCategoryButtonClick(FJPOKMGJCKF.category);
	}

	private void ONOJEGPPJOI()
	{
		GuiScreenSingle<WeaponScreen>.instance.WeaponCategoryButtonClick(FJPOKMGJCKF.category);
	}

	public void Sale()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(FJPOKMGJCKF.category, AKDLEDNDIEO.Both) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(FJPOKMGJCKF.category, AKDLEDNDIEO.Both) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.BHCEOOLEHHG == (FJPOKMGJCKF.category & weaponLevelsSetup.BHCEOOLEHHG) && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			flag4 |= weaponLevelsSetup.BHCEOOLEHHG == (FJPOKMGJCKF.category & weaponLevelsSetup.BHCEOOLEHHG) && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		GIPFEBBMKPM.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void MHLBGIPCBFA()
	{
		int numberOfWeaponCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfWeaponCategoryNotifications(FJPOKMGJCKF.category);
		AAOHNMDGEJJ.SetActive(numberOfWeaponCategoryNotifications > 1);
		FEBNOLJLPBI.text = numberOfWeaponCategoryNotifications.ToString();
	}

	public void Initialize(PlayerInventory.InventorySlot GAJILAIDNHM, int PDMGPGEHLNM)
	{
		FJPOKMGJCKF = GAJILAIDNHM;
		FKLKLCBOMNE.text = FJPOKMGJCKF.name;
		Notification();
		Sale();
		DAANKCOLJGJ.spriteName = FJPOKMGJCKF.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		DPPIKPAIEHD(NABOFKMBMKH: false);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 5f;
		MEJMLNDFDBP.COCBCFKJOJE(FKLKLCBOMNE, 35f, 24f, (int)num - 240);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 52f);
		GIPFEBBMKPM.transform.localPosition = GIPFEBBMKPM.transform.localPosition.ReplaceX(num - 65f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 2f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 20f);
	}

	public void IGAIPHNGKFD()
	{
		int numberOfWeaponCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfWeaponCategoryNotifications(FJPOKMGJCKF.category);
		AAOHNMDGEJJ.SetActive(numberOfWeaponCategoryNotifications > 1);
		FEBNOLJLPBI.text = numberOfWeaponCategoryNotifications.ToString();
	}

	public void OBNKALJOCGB()
	{
		int num = Singleton<NotificationManager>.instance.PHNPEBKCPEO(FJPOKMGJCKF.category);
		AAOHNMDGEJJ.SetActive(num > 0);
		FEBNOLJLPBI.text = num.ToString();
	}
}
