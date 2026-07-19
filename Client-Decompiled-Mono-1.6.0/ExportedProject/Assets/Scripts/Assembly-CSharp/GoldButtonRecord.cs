using UnityEngine;

public class GoldButtonRecord : Core_BaseScript
{
	[Header("Settings")]
	public bool LHDCEDLGPPJ;

	[Header("Sale Part")]
	public GameObject GIPFEBBMKPM;

	public UILabel HIDNIJJEBFJ;

	[Header("Icons")]
	public GameObject[] CACJKMDOFCJ;

	[Header("Labels")]
	public UILabel DAMGNCHFPMK;

	[Header("Bottom Part")]
	public UILabel DMDFANNPMGO;

	protected InAppDataManager.InappDefinition LJKOPCPDPFL;

	public virtual void PNCJCHPOMOJ(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "RewardItemId" : "ID_GUI_LIKEFB_DESC");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 561f, 1451f, 37);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 681f, 1132f, -47);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 783f, 492f, 100);
		GDNOJDOLEDK(amount);
	}

	public virtual void AJHDELPNMFF(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Player_Level" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void BMNHEMLGGMO(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? ")" : "qbz_run", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 759f, 557f, 72);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 37f, 168f, 80);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1080f, 1565f, 92);
		DIFHALCCMDO(amount);
	}

	private void AEELLOHEJLF(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 56)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -22)
			{
				num = 6;
			}
			else if (IEALLELGOBM > 73)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -97)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void PBEFOOADBPG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Sessions" : "Error Handler: Player si vybral starsi account!");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 683f, 1661f, 54);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1916f, 910f, -135);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1087f, 399f, -92);
		FGLHJIFMHHN(amount);
	}

	public virtual void BACLEBDCIPN(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("+0" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void JMPLLJLLPHK(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "null" : " ");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1132f, 1116f, -147);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 842f, 238f, -162);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1776f, 172f, 159);
		KBGNFKMJFBF(amount);
	}

	public virtual void LFDBAEIDAGH(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Area" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void KBGNFKMJFBF(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -2)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -125)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 102)
			{
				num = 3;
			}
			else if (IEALLELGOBM > -83)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void OOHELHKDAGE(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -12)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 64)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 24)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 57)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void PDNHBIKJPMF(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Deploys_Count" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void FANFNOPNGBL(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_YOUAREPREMIUMMEMBERWITHBENEFITS" : "attrValue13");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1234f, 1753f, 147);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 940f, 63f, -124);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 651f, 1371f, -128);
		FGLDNBLMMDP(amount);
	}

	public virtual void EHLDPJCDCFD(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("call check CG autentication" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void ALENMBOCNCM(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("RegisterCustomEvent()" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void MFFEFILOKMG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_WARNING_OFFEREXPIRED" : "Arena Expired - you gain scraps. You have {0} lives.");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 900f, 214f, -165);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1917f, 318f, 52);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 664f, 1227f, -164);
		GLBCHDCAFHE(amount);
	}

	public virtual void OBMLGDLCMPL(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("ID_CONFIRM_TEMPORARBAN" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void EDNLMBAFCKF(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("http://localhost:3000/socket.io/" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void OMNEGAAKOCF(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "expireTime" : "Tutorial_Step_Complete");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 254f, 668f, 149);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1292f, 1431f, 87);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1835f, 1074f, 136);
		BMBIAINDIBP(amount);
	}

	public virtual void KGOODMOOCLC(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_ARENAWINSREWARDS" : "Processing the request Timed Out!");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1936f, 47f, -179);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 666f, 1814f, 183);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1185f, 1715f, -42);
		FDJEJFHAJPO(amount);
	}

	private void BBHEEDLLCBK(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -96)
			{
				num = 0;
			}
			else if (IEALLELGOBM > -83)
			{
				num = 2;
			}
			else if (IEALLELGOBM > -181)
			{
				num = 0;
			}
			else if (IEALLELGOBM > 2)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void CKLPPPDCEHG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_JOINSQUADDESCRIPTION2" : "ID_CONFIRM_SUBSCRIPTION_TEXT");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 279f, 1618f, 20);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 420f, 1955f, -83);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1833f, 1079f, -173);
		POAOOKBIMMH(amount);
	}

	public virtual void Initialize(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "ID_FREEPERCENTLINE" : "ID_FREEPERCENT", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 47f, 24f, 250);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 25f, 20f, 150);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 42f, 22f, 230);
		ACOJFIJADEM(amount);
	}

	public virtual void NOONOBOELCG(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("+{0}" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void PHLPILEKIOP(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Different levels \"{0}\" and \"{1}\"\n" : "LootboxType");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 460f, 1975f, 52);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 147f, 1012f, 162);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1504f, 1882f, -52);
		FGLDNBLMMDP(amount);
	}

	public virtual void DPFKOFFMNPC(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Wrong_Unit" : "NO WAR ARENA CONFIG!!!");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1297f, 446f, 3);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1786f, 1786f, 152);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1654f, 1154f, 55);
		MGFDNGDLGIN(amount);
	}

	public virtual void DKDLFFBNPLJ(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("UpgradeWeaponReminder {0} {1}" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void ODPHBJADJHH(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("currentMode: " + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void NGCPBGOBMLE(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "game-card-ico-streakboost-full" : "_BumpMap");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1261f, 1814f, -125);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 443f, 1863f, -89);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1781f, 542f, -149);
		BIHDJICGENE(amount);
	}

	public virtual void NPECNIFJJEG(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Mode" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void DIFHALCCMDO(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 178)
			{
				num = 5;
			}
			else if (IEALLELGOBM > -84)
			{
				num = 5;
			}
			else if (IEALLELGOBM > -10)
			{
				num = 2;
			}
			else if (IEALLELGOBM > -116)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void OMNHEHADLKD(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("jp" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void PIDMNHKOHAG(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -94)
			{
				num = 0;
			}
			else if (IEALLELGOBM > -165)
			{
				num = 2;
			}
			else if (IEALLELGOBM > -168)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -11)
			{
				num = 1;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void GLBCHDCAFHE(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -32)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -118)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -168)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 56)
			{
				num = 0;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void IMFLIICBNGM(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("No Offer Available (has all already)" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void PALKDIAONDP(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "damage" : "ID_LEAGUESTAYHINT2", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 836f, 65f, -133);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1796f, 1451f, 22);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1186f, 1881f, 192);
		DIDAMPLBKHC(amount);
	}

	public virtual void CKOIIPAGCNO(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "game-engi-progress-fill" : "OK");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 641f, 1072f, 189);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 328f, 964f, 185);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1670f, 362f, 29);
		NLMAJJEAGLG(amount);
	}

	public virtual void OLOPLBDKBLA(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_DEBUG_GUIERROR" : "minDamage");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 915f, 1384f, -137);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1858f, 1600f, 141);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1161f, 1875f, -199);
		PFNJCEAFOOE(amount);
	}

	public virtual void EPAHIKLPNNB(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_STAT_ASSIGNMENTSDONE" : "ID_ARENATICKETSSMALL");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1621f, 47f, 28);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1414f, 951f, 15);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 431f, 157f, 176);
		BBHEEDLLCBK(amount);
	}

	private void FDJEJFHAJPO(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -103)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 124)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 181)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -31)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void POAOOKBIMMH(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 23)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 33)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 63)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -2)
			{
				num = 0;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void INMPNAOAKJI(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Player" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void BMBIAINDIBP(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 84)
			{
				num = 4;
			}
			else if (IEALLELGOBM > -38)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -47)
			{
				num = 7;
			}
			else if (IEALLELGOBM > -118)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void DIDAMPLBKHC(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 7)
			{
				num = 6;
			}
			else if (IEALLELGOBM > 184)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 189)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 112)
			{
				num = 0;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void IEHBCAHMLPL(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -94)
			{
				num = 5;
			}
			else if (IEALLELGOBM > -51)
			{
				num = 3;
			}
			else if (IEALLELGOBM > -24)
			{
				num = 3;
			}
			else if (IEALLELGOBM > 104)
			{
				num = 0;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void MPFPHNBAIKD(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "ID_GUI_REPORTABUSE_LISTITEM7" : "ID_TUTORIAL_GO_TO_ARMORY_4", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 577f, 1999f, 91);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1016f, 662f, 52);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 187f, 864f, 168);
		BBHEEDLLCBK(amount);
	}

	public virtual void MOPPOCMNIAH(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("menu-cards-bronzepack" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void MGFDNGDLGIN(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -199)
			{
				num = 5;
			}
			else if (IEALLELGOBM > -115)
			{
				num = 8;
			}
			else if (IEALLELGOBM > 109)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 61)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void DGJAHLFHADD(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -34)
			{
				num = 8;
			}
			else if (IEALLELGOBM > 16)
			{
				num = 6;
			}
			else if (IEALLELGOBM > 77)
			{
				num = 4;
			}
			else if (IEALLELGOBM > -58)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void FGLDNBLMMDP(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 80)
			{
				num = 0;
			}
			else if (IEALLELGOBM > 42)
			{
				num = 4;
			}
			else if (IEALLELGOBM > -157)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 22)
			{
				num = 1;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void NDIJBPIDGOF(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Total_Battles" : "gameCenterId");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1080f, 1039f, 157);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 166f, 452f, -189);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1678f, 1702f, -21);
		POAOOKBIMMH(amount);
	}

	public virtual void BBJAHBPEDOH(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Show money pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void GBCFOFKPPJP(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Wrong_Category" : "S");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 277f, 978f, 151);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1196f, 1643f, 185);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 365f, 77f, 33);
		IMPDOELKDGM(amount);
	}

	public virtual void JBBODGONNEL(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("ID_TUTORIAL_GO_BUY_ARMY_2_DOWN" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void HAGFEJHOJCK(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("https://www.facebook.com/warfriendsgame/" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void LBLLKGFJOCA(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("()I" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void OJJPLHKLLDB(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -171)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -93)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -195)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -23)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void EHKNIAMDHJN(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("NewSquadId" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void JPBOGGKMAON(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "{0}-{1:D6}" : "ID_CONFIRM_ERROR", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 388f, 1315f, -89);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1385f, 1614f, -148);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1354f, 925f, 68);
		NLMAJJEAGLG(amount);
	}

	private void GFAHBDICODI(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -144)
			{
				num = 7;
			}
			else if (IEALLELGOBM > -108)
			{
				num = 0;
			}
			else if (IEALLELGOBM > -131)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 102)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void PEIPCPICOIK(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "{0} {1}" : "Buy_Unit");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1581f, 1516f, 3);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1105f, 1826f, 42);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 783f, 149f, -198);
		DIDAMPLBKHC(amount);
	}

	private void PFNJCEAFOOE(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 51)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 34)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -68)
			{
				num = 8;
			}
			else if (IEALLELGOBM > 4)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void KJKHBFFDNLD(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -85)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -14)
			{
				num = 3;
			}
			else if (IEALLELGOBM > -116)
			{
				num = 3;
			}
			else if (IEALLELGOBM > -106)
			{
				num = 1;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void OMGCKCFKDJM(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? " iconName:" : "Days_Since_Install");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1701f, 1849f, 164);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 668f, 821f, 20);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 434f, 746f, 165);
		PGOMPOGNAPA(amount);
	}

	public virtual void IHMEAAIKGAP(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "{0} {1}" : "game-ico-poison");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1913f, 519f, -69);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1329f, 1955f, 108);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 36f, 1490f, -106);
		KNNGMCMFOIO(amount);
	}

	public virtual void AJEGOKKKLOL(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "warp_movement" : "medals");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 599f, 254f, -31);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 487f, 1561f, -38);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1402f, 1512f, -193);
		DKGJNLPJLBH(amount);
	}

	public virtual void KJKJHJOMNHL(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("setAge" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void BDMNPDBOCGN(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "ID_CONFIRM_NOTENOUGHDOGTAGS" : "RealTimeMultiplayer", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 853f, 1034f, -96);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1742f, 1111f, -119);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 990f, 1742f, -182);
		KJKHBFFDNLD(amount);
	}

	private void KNNGMCMFOIO(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 196)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -16)
			{
				num = 6;
			}
			else if (IEALLELGOBM > 181)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 5)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void LMPNFLGMNBG(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ShotFrequencyMin" : "#VOJTA# action success ");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1878f, 1330f, -25);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 554f, 356f, -128);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 563f, 1164f, -98);
		LMMMJLJFLPK(amount);
	}

	public virtual void LOJPGLBLJDF(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "http://www.about-fun.com/img/game-war-third-bg.jpg" : "ID_LOADING", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1798f, 1362f, -106);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1817f, 734f, -162);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1064f, 1593f, -105);
		KLBCIIMLFJL(amount);
	}

	public virtual void GGAHNKIKJKD(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "HeartPrice" : "IsVip");
			object[] array = new object[0];
			array[0] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1235f, 1532f, 183);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1727f, 1485f, 189);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.IKALHPLMNDD();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1548f, 1000f, -57);
		DIFHALCCMDO(amount);
	}

	private void BIHDJICGENE(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -69)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -40)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -191)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 33)
			{
				num = 1;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void IFLDAKKOGHN(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log(" iconName:" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void NAKAFGAFEPH(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "ID_CONFIRM_WRONGPLAYERDATA" : "unregisterConnectionFailedListener");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1556f, 1622f, 136);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 491f, 1320f, 155);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 887f, 861f, -100);
		PIDMNHKOHAG(amount);
	}

	public virtual void CONKDIBIPBH(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 0);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? " ID_" : "REMOVING WARCARD: \"{0}\" FROM DEPOSITED WARCARDS");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 853f, 461f, -52);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1986f, 1371f, 60);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.MHBLNNEOGFN();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1918f, 1108f, 167);
		IEHBCAHMLPL(amount);
	}

	private void GDKPEDJPHOK(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -66)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -179)
			{
				num = 6;
			}
			else if (IEALLELGOBM > 127)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 91)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void OICEFJEMBAP(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Tutorial for unit upgraded shown: {0}\tAny unit delivering/delivered: {1}\tAny unit can be upgraded: {2}\tTime since last update: {3}\tChosen Unit: {4}" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void KCJFKOKGAMO(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 0)
		{
			HIDNIJJEBFJ.text = Localization.LocalizeFormat((!LHDCEDLGPPJ) ? "ID_CONFIRM_SQUADISNOTPUBLIC_TEXT" : "customGeo", sale);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1642f, 1228f, -72);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1854f, 1832f, -97);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.OAJCGMBBFFF();
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 569f, 802f, 136);
		FGLDNBLMMDP(amount);
	}

	public virtual void GJOHPCMGEOG(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log(")" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void IMPDOELKDGM(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 58)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -63)
			{
				num = 0;
			}
			else if (IEALLELGOBM > 69)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 58)
			{
				num = 0;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void IOCNPPCMCMM(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "Description!!!!!!! Motherfuckers :-)" : "N");
			object[] array = new object[0];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 118f, 1380f, 161);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1456f, 435f, -56);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1799f, 847f, -181);
		PBCHKAABAJE(amount);
	}

	public virtual void MNHJEANPGJN(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Squad Members not in client cache!" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	public virtual void OAIOCCMJDDI(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("\t\"TRUE\"" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void DKGJNLPJLBH(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -86)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 33)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -152)
			{
				num = 7;
			}
			else if (IEALLELGOBM > -72)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void PBCHKAABAJE(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -66)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 59)
			{
				num = 1;
			}
			else if (IEALLELGOBM > 84)
			{
				num = 0;
			}
			else if (IEALLELGOBM > 114)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void ODGINKAHGJF(InAppDataManager.InappDefinition COCLIJKECEK)
	{
		LJKOPCPDPFL = COCLIJKECEK;
		int amount = COCLIJKECEK.amount;
		int sale = COCLIJKECEK.sale;
		GIPFEBBMKPM.SetActive(sale > 1);
		if (sale > 1)
		{
			UILabel hIDNIJJEBFJ = HIDNIJJEBFJ;
			string keyFormat = ((!LHDCEDLGPPJ) ? "BESTÄTIGEN" : "shield_idle");
			object[] array = new object[1];
			array[1] = sale;
			hIDNIJJEBFJ.text = Localization.LocalizeFormat(keyFormat, array);
			if (LHDCEDLGPPJ)
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1237f, 1613f, -83);
			}
			else
			{
				MEJMLNDFDBP.COCBCFKJOJE(HIDNIJJEBFJ, 1493f, 722f, 172);
			}
		}
		DAMGNCHFPMK.text = MEJMLNDFDBP.GMIPFLIEOHD(amount);
		DMDFANNPMGO.text = COCLIJKECEK.formatedPrice;
		MEJMLNDFDBP.COCBCFKJOJE(DMDFANNPMGO, 1398f, 107f, -142);
		DGJAHLFHADD(amount);
	}

	public virtual void MCNGNGDNBEF(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("Experience" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void LDJNGEFBEOG(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 92)
			{
				num = 0;
			}
			else if (IEALLELGOBM > -36)
			{
				num = 8;
			}
			else if (IEALLELGOBM > 104)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 96)
			{
				num = 0;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void NFEMGPOCBIG(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 63)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -156)
			{
				num = 0;
			}
			else if (IEALLELGOBM > -96)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 105)
			{
				num = 1;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void DGNPILIOIKP(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > -168)
			{
				num = 4;
			}
			else if (IEALLELGOBM > -107)
			{
				num = 1;
			}
			else if (IEALLELGOBM > -78)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 94)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void FGLHJIFMHHN(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 93)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 47)
			{
				num = 7;
			}
			else if (IEALLELGOBM > -128)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 48)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void GCEHKBCJEEJ(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("REGISTER BUY PACK EVENT with " + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void NLMAJJEAGLG(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -120)
			{
				num = 7;
			}
			else if (IEALLELGOBM > 120)
			{
				num = 8;
			}
			else if (IEALLELGOBM > 161)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -43)
			{
				num = 1;
			}
			for (int i = 1; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void KLBCIIMLFJL(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > -75)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -186)
			{
				num = 5;
			}
			else if (IEALLELGOBM > 23)
			{
				num = 3;
			}
			else if (IEALLELGOBM > -15)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void ACOJFIJADEM(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 1300)
			{
				num = 4;
			}
			else if (IEALLELGOBM > 600)
			{
				num = 3;
			}
			else if (IEALLELGOBM > 300)
			{
				num = 2;
			}
			else if (IEALLELGOBM > 100)
			{
				num = 1;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void MIJHEIKFAAK(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("PlayerWeapons" + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}

	private void LMMMJLJFLPK(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 76)
			{
				num = 6;
			}
			else if (IEALLELGOBM > -41)
			{
				num = 6;
			}
			else if (IEALLELGOBM > 146)
			{
				num = 0;
			}
			else if (IEALLELGOBM > -33)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i += 0)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void PGOMPOGNAPA(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 0;
			if (IEALLELGOBM > 95)
			{
				num = 2;
			}
			else if (IEALLELGOBM > 140)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -1)
			{
				num = 8;
			}
			else if (IEALLELGOBM > -108)
			{
				num = 1;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	private void GDNOJDOLEDK(int IEALLELGOBM)
	{
		if (!LHDCEDLGPPJ)
		{
			int num = 1;
			if (IEALLELGOBM > 86)
			{
				num = 7;
			}
			else if (IEALLELGOBM > -190)
			{
				num = 3;
			}
			else if (IEALLELGOBM > -3)
			{
				num = 5;
			}
			else if (IEALLELGOBM > -97)
			{
				num = 0;
			}
			for (int i = 0; i < CACJKMDOFCJ.Length; i++)
			{
				CACJKMDOFCJ[i].SetActive(num == i);
			}
		}
	}

	public virtual void ButtonClicked(GameObject KHAHPAKDIKE)
	{
		if (LJKOPCPDPFL != null)
		{
			Debug.Log("BUY: " + LJKOPCPDPFL.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(LJKOPCPDPFL.id);
		}
	}
}
