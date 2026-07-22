using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerVisualsCategoryButton : PoolableObject
{
	[Header("Core")]
	public BoxCollider NJEAMAHEMHP;

	public UISprite KMFGCJEGJJK;

	public UISprite DAANKCOLJGJ;

	public UILabel FKLKLCBOMNE;

	[Header("Notification")]
	public UILabel FEBNOLJLPBI;

	public GameObject AAOHNMDGEJJ;

	[Header("Sale")]
	public GameObject GIPFEBBMKPM;

	private string AEFCKLKAGEH = "menu-weapons-tab-active";

	private string GMFPGEGPJDO = "menu-weapons-tab";

	private PlayerVisualCategory BCBKHONHNJE;

	private bool MABJBLOIJLK;

	public PlayerVisualCategory category => BCBKHONHNJE;

	[SpecialName]
	public PlayerVisualCategory HMMHELHBNDH()
	{
		return BCBKHONHNJE;
	}

	public void Sale()
	{
		GIPFEBBMKPM.SetActive(value: false);
	}

	public void LIMIFKFNNLA(PlayerVisualCategory FABOAIMLLOI, int PDMGPGEHLNM)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		MABJBLOIJLK = BCBKHONHNJE as PlayerVisualCategoryPowerBands != null;
		FKLKLCBOMNE.text = Localization.Localize(FABOAIMLLOI.KLMFIBIIALC);
		APJEECCNCPH();
		Sale();
		DAANKCOLJGJ.spriteName = FABOAIMLLOI.DAANKCOLJGJ;
		DAANKCOLJGJ.MakePixelPerfect();
		BANCDJNFHIC(MJFJOPMJEAO: false);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 1330f;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 1955f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 1131f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 324f);
	}

	public void Highlight(bool MJFJOPMJEAO)
	{
		if (MABJBLOIJLK)
		{
			DAANKCOLJGJ.color = ((!MJFJOPMJEAO) ? Colours.yellowDecal : Colours.blue);
			FKLKLCBOMNE.color = ((!MJFJOPMJEAO) ? Colours.yellowDecal : Colours.blue);
		}
		else
		{
			DAANKCOLJGJ.color = ((!MJFJOPMJEAO) ? Color.white : Colours.blue);
			FKLKLCBOMNE.color = ((!MJFJOPMJEAO) ? Color.white : Colours.blue);
		}
		KMFGCJEGJJK.spriteName = ((!MJFJOPMJEAO) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	public void FCIBBIGOLGL()
	{
		GIPFEBBMKPM.SetActive(value: false);
	}

	public void HBDEPMJNLEK(PlayerVisualCategory FABOAIMLLOI, int PDMGPGEHLNM)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		MABJBLOIJLK = BCBKHONHNJE as PlayerVisualCategoryPowerBands != null;
		FKLKLCBOMNE.text = Localization.Localize(FABOAIMLLOI.KLMFIBIIALC);
		APJEECCNCPH();
		OIPNOIKCBMO();
		DAANKCOLJGJ.spriteName = FABOAIMLLOI.DAANKCOLJGJ;
		DAANKCOLJGJ.MakePixelPerfect();
		HDGBMNDOMCP(MJFJOPMJEAO: true);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 768f;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 596f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 1192f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 453f);
	}

	private void NBFGMJFDDLB()
	{
		GuiScreenSingle<CamosScreen>.instance.HJEIENACIOE(this);
	}

	public void Notification()
	{
		int numberOfVisualCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfVisualCategoryNotifications(BCBKHONHNJE);
		AAOHNMDGEJJ.SetActive(numberOfVisualCategoryNotifications > 0);
		FEBNOLJLPBI.text = numberOfVisualCategoryNotifications.ToString();
	}

	private void OnClick()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectCategory(this);
	}

	public void OBNKALJOCGB()
	{
		int numberOfVisualCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfVisualCategoryNotifications(BCBKHONHNJE);
		AAOHNMDGEJJ.SetActive(numberOfVisualCategoryNotifications > 0);
		FEBNOLJLPBI.text = numberOfVisualCategoryNotifications.ToString();
	}

	public void EGLJCBFPAKP(bool MJFJOPMJEAO)
	{
		if (MABJBLOIJLK)
		{
			DAANKCOLJGJ.color = ((!MJFJOPMJEAO) ? Colours.yellowDecal : Colours.blue);
			FKLKLCBOMNE.color = ((!MJFJOPMJEAO) ? Colours.yellowDecal : Colours.blue);
		}
		else
		{
			DAANKCOLJGJ.color = ((!MJFJOPMJEAO) ? Color.white : Colours.blue);
			FKLKLCBOMNE.color = ((!MJFJOPMJEAO) ? Color.white : Colours.blue);
		}
		KMFGCJEGJJK.spriteName = ((!MJFJOPMJEAO) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	public void HDGBMNDOMCP(bool MJFJOPMJEAO)
	{
		if (MABJBLOIJLK)
		{
			DAANKCOLJGJ.color = ((!MJFJOPMJEAO) ? Colours.yellowDecal : Colours.blue);
			FKLKLCBOMNE.color = ((!MJFJOPMJEAO) ? Colours.yellowDecal : Colours.blue);
		}
		else
		{
			DAANKCOLJGJ.color = ((!MJFJOPMJEAO) ? Color.white : Colours.blue);
			FKLKLCBOMNE.color = ((!MJFJOPMJEAO) ? Color.white : Colours.blue);
		}
		KMFGCJEGJJK.spriteName = ((!MJFJOPMJEAO) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	public void HIHAFDPJPKC(PlayerVisualCategory FABOAIMLLOI, int PDMGPGEHLNM)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		MABJBLOIJLK = BCBKHONHNJE as PlayerVisualCategoryPowerBands != null;
		FKLKLCBOMNE.text = Localization.Localize(FABOAIMLLOI.KLMFIBIIALC);
		APJEECCNCPH();
		KFIHKLHOAAC();
		DAANKCOLJGJ.spriteName = FABOAIMLLOI.DAANKCOLJGJ;
		DAANKCOLJGJ.MakePixelPerfect();
		EGLJCBFPAKP(MJFJOPMJEAO: true);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 519f;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 810f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 1851f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 1806f);
	}

	private void NMJJKMIOFHJ()
	{
		GuiScreenSingle<CamosScreen>.instance.HJEIENACIOE(this);
	}

	public void KFIHKLHOAAC()
	{
		GIPFEBBMKPM.SetActive(value: false);
	}

	public void HMDCCJBPHEK()
	{
		GIPFEBBMKPM.SetActive(value: true);
	}

	public void NAKAFGAFEPH(PlayerVisualCategory FABOAIMLLOI, int PDMGPGEHLNM)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		MABJBLOIJLK = BCBKHONHNJE as PlayerVisualCategoryPowerBands != null;
		FKLKLCBOMNE.text = Localization.Localize(FABOAIMLLOI.KLMFIBIIALC);
		HIPHENFGKBH();
		OIPNOIKCBMO();
		DAANKCOLJGJ.spriteName = FABOAIMLLOI.DAANKCOLJGJ;
		DAANKCOLJGJ.MakePixelPerfect();
		BANCDJNFHIC(MJFJOPMJEAO: true);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 1508f;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 198f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 1059f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 917f);
	}

	public void PJICLEMEBID(PlayerVisualCategory FABOAIMLLOI, int PDMGPGEHLNM)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		MABJBLOIJLK = BCBKHONHNJE as PlayerVisualCategoryPowerBands != null;
		FKLKLCBOMNE.text = Localization.Localize(FABOAIMLLOI.KLMFIBIIALC);
		Notification();
		JIJBALDFIDB();
		DAANKCOLJGJ.spriteName = FABOAIMLLOI.DAANKCOLJGJ;
		DAANKCOLJGJ.MakePixelPerfect();
		HDGBMNDOMCP(MJFJOPMJEAO: false);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 1983f;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 301f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 991f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 1567f);
	}

	public void BANCDJNFHIC(bool MJFJOPMJEAO)
	{
		if (MABJBLOIJLK)
		{
			DAANKCOLJGJ.color = ((!MJFJOPMJEAO) ? Colours.yellowDecal : Colours.blue);
			FKLKLCBOMNE.color = ((!MJFJOPMJEAO) ? Colours.yellowDecal : Colours.blue);
		}
		else
		{
			DAANKCOLJGJ.color = ((!MJFJOPMJEAO) ? Color.white : Colours.blue);
			FKLKLCBOMNE.color = ((!MJFJOPMJEAO) ? Color.white : Colours.blue);
		}
		KMFGCJEGJJK.spriteName = ((!MJFJOPMJEAO) ? GMFPGEGPJDO : AEFCKLKAGEH);
	}

	public void APJEECCNCPH()
	{
		int numberOfVisualCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfVisualCategoryNotifications(BCBKHONHNJE);
		AAOHNMDGEJJ.SetActive(numberOfVisualCategoryNotifications > 1);
		FEBNOLJLPBI.text = numberOfVisualCategoryNotifications.ToString();
	}

	private void OOLAJLCNCJJ()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectCategory(this);
	}

	public void JIJBALDFIDB()
	{
		GIPFEBBMKPM.SetActive(value: true);
	}

	[SpecialName]
	public PlayerVisualCategory BHOBAGJCNEF()
	{
		return BCBKHONHNJE;
	}

	public void OIPNOIKCBMO()
	{
		GIPFEBBMKPM.SetActive(value: true);
	}

	public void HIPHENFGKBH()
	{
		int numberOfVisualCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfVisualCategoryNotifications(BCBKHONHNJE);
		AAOHNMDGEJJ.SetActive(numberOfVisualCategoryNotifications > 0);
		FEBNOLJLPBI.text = numberOfVisualCategoryNotifications.ToString();
	}

	public void Initialize(PlayerVisualCategory FABOAIMLLOI, int PDMGPGEHLNM)
	{
		BCBKHONHNJE = FABOAIMLLOI;
		MABJBLOIJLK = BCBKHONHNJE as PlayerVisualCategoryPowerBands != null;
		FKLKLCBOMNE.text = Localization.Localize(FABOAIMLLOI.KLMFIBIIALC);
		Notification();
		Sale();
		DAANKCOLJGJ.spriteName = FABOAIMLLOI.DAANKCOLJGJ;
		DAANKCOLJGJ.MakePixelPerfect();
		Highlight(MJFJOPMJEAO: false);
		float num = UIHelper.activeWidthSafe / (float)PDMGPGEHLNM - 5f;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(num);
		AAOHNMDGEJJ.transform.localPosition = AAOHNMDGEJJ.transform.localPosition.ReplaceX(num - 50f);
		NJEAMAHEMHP.center = NJEAMAHEMHP.center.ReplaceX(num / 2f);
		NJEAMAHEMHP.size = NJEAMAHEMHP.size.ReplaceX(num + 20f);
	}
}
