using UnityEngine;

public class AssignmentsDialog : GuiElementSingle<AssignmentsDialog>, PAIIOKBBHBC
{
	private enum MOAPKNEGFAN
	{
		Starter = 0,
		Daily = 1
	}

	[Header("Contents")]
	[SerializeField]
	private DailyAssignmentsContent mDailyContent;

	[SerializeField]
	private StarterAssignmentsContent mStarterContent;

	[SerializeField]
	[Header("Other")]
	private UISprite mBackground;

	[SerializeField]
	private GameObject mDaily;

	[SerializeField]
	private GameObject mStarter;

	private bool BELEDBMKJGB = true;

	private float JDPOMFBEFOI;

	private MOAPKNEGFAN JGMLALPJHIC = MOAPKNEGFAN.Daily;

	private void EDMKELCMMCB()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 0)
			{
				JGPMJIMJOBC();
			}
			else
			{
				mDailyContent.JKGLFGICHJG(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	protected virtual void JOCHCGHAIGH()
	{
		base.JMPDHKPOHEA();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1848f)
		{
			JDPOMFBEFOI = 151f;
			BJFBANIOMFL();
		}
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	protected override void Update()
	{
		base.Update();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 0.333f)
		{
			JDPOMFBEFOI = 0f;
			LOFIFAHLPJP();
		}
	}

	public virtual void ILHPNHECBJG()
	{
		HIDMHMCLEOP(base.gameObject);
	}

	public virtual void OJFGFKCDCAM()
	{
		base.OIMKKAHOEKO();
		mStarterContent.BKNJHLKMFKE();
		mStarter.SetActive(false);
		mDaily.SetActive(false);
	}

	private void IGJMJEKIBLB()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				JJPMJCPJKIO();
			}
			else
			{
				mDailyContent.CMCKCKKLKDG(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	public void EELOJAINBLK()
	{
		mDailyContent.ReinitializeMegaReward();
	}

	public virtual void JCGDALOBGHO()
	{
		if (JGMLALPJHIC == MOAPKNEGFAN.Daily)
		{
			mBackground.transform.localScale = new Vector3(1873f, 452f, 917f);
			mDaily.SetActive(false);
			mDailyContent.LLHGHHABLDC();
		}
		else
		{
			mBackground.transform.localScale = new Vector3(578f, 1405f, 976f);
			mStarter.SetActive(false);
			mStarterContent.LMNNNHJKMFP();
		}
		MABPPMAPBDK();
	}

	private void JCLCNKAMHPI()
	{
		BELEDBMKJGB = true;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	private void FINNFHEFGCF()
	{
		BELEDBMKJGB = true;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public virtual void CCLAJHMFLDF()
	{
		OkClick(base.gameObject);
	}

	public virtual void GKPGHCLMCDK()
	{
		DJOCGHINNJA(base.gameObject);
	}

	public virtual void JKPBJPFBAFJ()
	{
		HIDMHMCLEOP(base.gameObject);
	}

	public virtual void MGHNHDOBJFN()
	{
		mDailyContent.KPBDJELONKH();
		mStarterContent.JCGPELEDCJL();
	}

	private void CKHAHOEFKBK()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 0)
			{
				JJPMJCPJKIO();
			}
			else
			{
				mDailyContent.KCFKCFHGIPE(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	public virtual void MOKAPOJLCPJ()
	{
		base.DoAfterHide();
		mStarterContent.CHAGJLIDGAH();
		mStarter.SetActive(false);
		mDaily.SetActive(false);
	}

	public GuiElement KBCELKIEAAM()
	{
		return this;
	}

	public void IGPBIBLOMFD()
	{
		mDailyContent.EBHPAIIHCCK();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void BNCDFKGNPII()
	{
		LMINDENMDEH(base.gameObject);
	}

	public void ShowDaily()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Daily;
		if (base.isFullyHidden)
		{
			Singleton<GuiManager>.instance.ShowDialog(this);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mStarterContent.DoAfterHide();
		mStarter.SetActive(false);
		mDaily.SetActive(false);
	}

	public GuiElement AAMCALKKHEL()
	{
		return this;
	}

	private void HNGGKDIOLKF()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public void ShowStarter()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Starter;
		if (base.isFullyHidden)
		{
			Singleton<GuiManager>.instance.ShowDialog(this);
		}
	}

	private void PJLAKPBPFHA()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				PFODPIDAIEC();
			}
			else
			{
				mDailyContent.EKDGDAHOGMA(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	public virtual void LEMNDNDGIOE()
	{
		if (JGMLALPJHIC == MOAPKNEGFAN.Daily)
		{
			mBackground.transform.localScale = new Vector3(767f, 1039f, 1132f);
			mDaily.SetActive(true);
			mDailyContent.OBNCKIBJOGJ();
		}
		else
		{
			mBackground.transform.localScale = new Vector3(1449f, 1246f, 127f);
			mStarter.SetActive(false);
			mStarterContent.DFMCKHMFNHO();
		}
		PJLAKPBPFHA();
	}

	private void AKMOLILGOIJ()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 0)
			{
				JGPMJIMJOBC();
			}
			else
			{
				mDailyContent.BKKHGPEMIAO(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	public void LKNNPBOGFCI()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Daily;
		if (KHMJNJBPGMK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 19f);
		}
	}

	public virtual void JAEMPMDIACE()
	{
		base.OIMKKAHOEKO();
		mStarterContent.ACFDANMKHNG();
		mStarter.SetActive(false);
		mDaily.SetActive(false);
	}

	private void LOFIFAHLPJP()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 0)
			{
				JGPMJIMJOBC();
			}
			else
			{
				mDailyContent.UpdateTime(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	private void NMLGPNMMIMK()
	{
		BELEDBMKJGB = true;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	private void JIEEANAJFPE()
	{
		BELEDBMKJGB = true;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public void ReinitializeMegaReward()
	{
		mDailyContent.ReinitializeMegaReward();
	}

	public virtual void GOMEJLFFKJM()
	{
		mDailyContent.JCEMKGHAHNE();
		mStarterContent.GHHNNIKGJFG();
	}

	public void HBNIJIIMCOO()
	{
		mDailyContent.PGNEBFCEFNM();
	}

	public virtual void LPHPIMMGNPI()
	{
		GHANNHGHEIP(base.gameObject);
	}

	public void BJCKNPHAKPO()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Daily;
		if (DJHKIDICMPK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1202f);
		}
	}

	public void FOKFDABALJD()
	{
		mDailyContent.FOKFDABALJD();
	}

	public void ENINOFOHMPH()
	{
		mDailyContent.IGPBIBLOMFD();
	}

	private void IFDPABBACGH()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				HNGGKDIOLKF();
			}
			else
			{
				mDailyContent.EKDGDAHOGMA(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	private void LODIOJPPLOO()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 0)
			{
				GMOLCMHEFOG();
			}
			else
			{
				mDailyContent.AJCFBGNEMFE(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	public virtual void PANHEDPIJHD()
	{
		GHANNHGHEIP(base.gameObject);
	}

	public override void OnBack()
	{
		OkClick(base.gameObject);
	}

	public GuiElement NDOMPDOOJND()
	{
		return this;
	}

	public virtual void GHNIJJKDAJH()
	{
		base.DoAfterHide();
		mStarterContent.BKNJHLKMFKE();
		mStarter.SetActive(true);
		mDaily.SetActive(false);
	}

	public virtual void LKBEJGHEANA()
	{
		if (JGMLALPJHIC == MOAPKNEGFAN.Daily)
		{
			mBackground.transform.localScale = new Vector3(1956f, 504f, 1566f);
			mDaily.SetActive(true);
			mDailyContent.LEMNDNDGIOE();
		}
		else
		{
			mBackground.transform.localScale = new Vector3(399f, 734f, 1843f);
			mStarter.SetActive(true);
			mStarterContent.LFJGHLNJPHL();
		}
		OFGCIMFECOH();
	}

	private void NCGMLLHDPNL()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				HNGGKDIOLKF();
			}
			else
			{
				mDailyContent.IMEGMCPNMFB(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	public void BDNMAMCIGAE()
	{
		mDailyContent.DOLBCFNPIBA();
	}

	public void HCBNJOLCKDM()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Daily;
		if (KHMJNJBPGMK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 846f);
		}
	}

	public void KCDCLMGOOGF()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Starter;
		if (KHMJNJBPGMK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1926f);
		}
	}

	public virtual void ICNGBKKANLB()
	{
		mDailyContent.OGPKLKIEBHM();
		mStarterContent.AMBDHDEBPJJ();
	}

	public GuiElement BEOCBHEIKKO()
	{
		return this;
	}

	public virtual void EEFEFOHKIBF()
	{
		base.DoAfterHide();
		mStarterContent.BKNJHLKMFKE();
		mStarter.SetActive(true);
		mDaily.SetActive(false);
	}

	private void DINANGJJIOK()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				NGKHPNLHJLN();
			}
			else
			{
				mDailyContent.LAKPCHLKCJK(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	public void GCBHICOKLIO()
	{
		mDailyContent.ICKIHECNLII();
	}

	public virtual void COBDHBOCGAP()
	{
		mDailyContent.OCFOEGJBNCH();
		mStarterContent.AMBDHDEBPJJ();
	}

	public override void InitControls()
	{
		mDailyContent.InitControls();
		mStarterContent.InitControls();
	}

	public virtual void ACFDANMKHNG()
	{
		base.OIMKKAHOEKO();
		mStarterContent.DoAfterHide();
		mStarter.SetActive(false);
		mDaily.SetActive(false);
	}

	public void BKENOMAGHJK()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Starter;
		if (DJHKIDICMPK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 203f);
		}
	}

	public virtual void EKBIKKJHGKB()
	{
		LMINDENMDEH(base.gameObject);
	}

	public void HIDMHMCLEOP(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public GuiElement JEAMNJAPFJK()
	{
		return this;
	}

	public void KEAAAMPGPGD(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void OFFMLIFJFGB()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Starter;
		if (base.isFullyHidden)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1583f);
		}
	}

	protected virtual void BLOBBBLIJPI()
	{
		base.IIFBKHDMIAD();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1115f)
		{
			JDPOMFBEFOI = 1365f;
			CKHAHOEFKBK();
		}
	}

	public void EBNAAOOHAIH()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Daily;
		if (KHMJNJBPGMK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1629f);
		}
	}

	private void MABPPMAPBDK()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				JJPMJCPJKIO();
			}
			else
			{
				mDailyContent.HFHNKPHEGCD(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	public virtual void MFHJALPPCKI()
	{
		mDailyContent.JCEMKGHAHNE();
		mStarterContent.GHHNNIKGJFG();
	}

	private void JJPMJCPJKIO()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public virtual void KMCKIIFEKCA()
	{
		if (JGMLALPJHIC == MOAPKNEGFAN.Daily)
		{
			mBackground.transform.localScale = new Vector3(50f, 1445f, 847f);
			mDaily.SetActive(true);
			mDailyContent.DBFHCLPIOKH();
		}
		else
		{
			mBackground.transform.localScale = new Vector3(455f, 390f, 265f);
			mStarter.SetActive(true);
			mStarterContent.InitGUIValues();
		}
		OFGCIMFECOH();
	}

	private void GMOLCMHEFOG()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public virtual void JMKHMIDNDHH()
	{
		HIDMHMCLEOP(base.gameObject);
	}

	public virtual void EAAIKMDDNJN()
	{
		KEAAAMPGPGD(base.gameObject);
	}

	public void DJOCGHINNJA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public void MOGLCDKNIJG()
	{
		mDailyContent.DLPEBGPLCJA();
	}

	private void NKAKDHJHIJF()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				GMOLCMHEFOG();
			}
			else
			{
				mDailyContent.JKGLFGICHJG(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	private void OFGCIMFECOH()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				NGKHPNLHJLN();
			}
			else
			{
				mDailyContent.IMEGMCPNMFB(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	private void NGKHPNLHJLN()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public virtual void BKDELMODAHM()
	{
		LMINDENMDEH(base.gameObject);
	}

	public GuiElement EJHNJALEFHJ()
	{
		return this;
	}

	public void DBCGFAFJKHE()
	{
		mDailyContent.IGPBIBLOMFD();
	}

	public virtual void EKECENANOBE()
	{
		base.DoAfterHide();
		mStarterContent.MOPAOJFCOGP();
		mStarter.SetActive(true);
		mDaily.SetActive(true);
	}

	protected virtual void GEICOLPLFDL()
	{
		base.OGJGIMLMJBF();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 297f)
		{
			JDPOMFBEFOI = 1521f;
			EDMKELCMMCB();
		}
	}

	protected virtual void ADLJAKCCELG()
	{
		base.BOEMHLPLOGA();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 870f)
		{
			JDPOMFBEFOI = 1531f;
			HGNJGIDDMGE();
		}
	}

	public virtual void LHMMLMPFHOH()
	{
		LMINDENMDEH(base.gameObject);
	}

	public void OkClick(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void KIFFMLHFMEE()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Starter;
		if (DJHKIDICMPK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1728f);
		}
	}

	public GuiElement JPBIPBMAHBO()
	{
		return this;
	}

	public void GHANNHGHEIP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public void DOMHIPCOOCC()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Starter;
		if (DJHKIDICMPK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1086f);
		}
	}

	public override void InitGUIValues()
	{
		if (JGMLALPJHIC == MOAPKNEGFAN.Daily)
		{
			mBackground.transform.localScale = new Vector3(1520f, 1186f, 1f);
			mDaily.SetActive(true);
			mDailyContent.InitGUIValues();
		}
		else
		{
			mBackground.transform.localScale = new Vector3(1800f, 1172f, 1f);
			mStarter.SetActive(true);
			mStarterContent.InitGUIValues();
		}
		LOFIFAHLPJP();
	}

	public void LMINDENMDEH(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public void BALGBNGMDBF()
	{
		JGMLALPJHIC = MOAPKNEGFAN.Daily;
		if (DJHKIDICMPK())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1122f);
		}
	}

	private void PFODPIDAIEC()
	{
		BELEDBMKJGB = true;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public virtual void DHMNIOHKIGC()
	{
		if (JGMLALPJHIC == MOAPKNEGFAN.Daily)
		{
			mBackground.transform.localScale = new Vector3(1501f, 1001f, 858f);
			mDaily.SetActive(false);
			mDailyContent.CDHLMEPGPNJ();
		}
		else
		{
			mBackground.transform.localScale = new Vector3(726f, 245f, 146f);
			mStarter.SetActive(false);
			mStarterContent.LFJGHLNJPHL();
		}
		DINANGJJIOK();
	}

	private void HGNJGIDDMGE()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				JJPMJCPJKIO();
			}
			else
			{
				mDailyContent.CAKEPACMPBN(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	private void CCHHIBEFPON()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 0)
			{
				JCLCNKAMHPI();
			}
			else
			{
				mDailyContent.KCFKCFHGIPE(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	private void JDKOJEOCCJD()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	public virtual void ACLOLICAKGL()
	{
		if (JGMLALPJHIC == MOAPKNEGFAN.Starter)
		{
			mBackground.transform.localScale = new Vector3(1266f, 1968f, 673f);
			mDaily.SetActive(true);
			mDailyContent.LLHGHHABLDC();
		}
		else
		{
			mBackground.transform.localScale = new Vector3(1542f, 1765f, 618f);
			mStarter.SetActive(true);
			mStarterContent.DFMCKHMFNHO();
		}
		OFGCIMFECOH();
	}

	private void BJFBANIOMFL()
	{
		if (AssignmentsManager.instance.data != null)
		{
			if (AssignmentsManager.instance.timeUntilMidnight <= 1)
			{
				JDKOJEOCCJD();
			}
			else
			{
				mDailyContent.IMEGMCPNMFB(AssignmentsManager.instance.timeUntilMidnight);
			}
		}
	}

	private void JGPMJIMJOBC()
	{
		BELEDBMKJGB = false;
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}
}
