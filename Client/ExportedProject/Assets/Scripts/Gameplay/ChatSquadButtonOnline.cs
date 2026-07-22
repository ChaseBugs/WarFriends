using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChatSquadButtonOnline : Core_BaseScript
{
	[Header("Core")]
	[FormerlySerializedAs("AIJJKNICMJH")]
	public GameObject GLMONLKGCPO;

	[FormerlySerializedAs("LIFJFFNABGN")]
	public UILabel PGNJHACIOOH;

	[FormerlySerializedAs("AAFHNKGGLBI")]
	public ChatButtonUnderline KMHGGDFBBJP;

	[Header("Aditional")]
	[FormerlySerializedAs("ILFCGABGGJA")]
	public GameObject JNPNGJHPEPH;

	[FormerlySerializedAs("GFIENHEIJFF")]
	public UILabel IIEGMBACHLC;

	private void PIDDJHAFKKH(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 844f : 1352f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1638f, 493f, 34);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.PCJEOGBAEOF();
				AEBEGCDHIOJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 564f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1088f, 1253f, 187);
			LGNDPLNCCJP();
		}
	}

	public void CMLGDPOHKBF()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		GHMHGGLIMPO(num);
	}

	public void KPEJMMBDODD()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BMOMAMACMHM);
	}

	private void ADHFHFJJICC(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 437f : 991f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1206f, 714f, -38);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.APIHNFAABLB();
				GDNHJBMIFDL();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1541f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 169f, 24f, -173);
			AHKOOMKKEBJ();
		}
	}

	private void NAMAMFHNJMK(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 0f : (-60f));
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 40f, 20f, 210);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				AEBEGCDHIOJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 40f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 40f, 20f, 397);
			AEBEGCDHIOJ();
		}
	}

	public void MGIDNGCKLCF()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	public void LHLDIDDKOAD()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		ENBAJMBPHOJ(num);
	}

	private void JNPBINOKMHC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-77))
		{
			KIBHLENCGLG();
		}
	}

	public void IFANGKDFGEA()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		LHNBBNCOCJG(num);
	}

	public void POKOPFOIEIJ()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		NAMAMFHNJMK(num);
	}

	private void MNHMACDPDMJ(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-12))
		{
			GIICHGMJHIM();
		}
	}

	public void AOKOKHGEIBE()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMPKGNKEONO;
	}

	public void HDLFOJMKIPG()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		FEOGBAGIKME(num);
	}

	private void DCOJAILIGMC(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 721f : 1373f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 704f, 1346f, -81);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.BAIAKMKHBBP();
				PHGACHAOKFH();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1194f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 630f, 1151f, 129);
			OKPMAEMNBDP();
		}
	}

	public void EDFDIJCOMOI()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(KLPACNJJDIA);
	}

	public void FHINGMFHKLG()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LFPBBIIANLC;
	}

	private void PHGACHAOKFH()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void InitControls()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	public void KHGEHFNELDI()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(LGKFAMKBCIP);
	}

	private void KKABDDOBOCO(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.MessageSent)
		{
			HIMAIHEHDPB();
		}
	}

	public void HFPPNCJBIDK()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BMOMAMACMHM);
	}

	public void OOBJHJLMEED()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMPKGNKEONO;
	}

	private void PMPKGNKEONO(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-87))
		{
			HIMAIHEHDPB();
		}
	}

	public void CKPCFIPPDLC()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += BMOMAMACMHM;
	}

	private void IAAIHLNFMOK()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void IDMPJCAKOPN()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += BGPBOCDCGHC;
	}

	private void ENBAJMBPHOJ(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 1;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1100f : 460f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 383f, 269f, 42);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.APIHNFAABLB();
				OGPGKKFJNPN();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1979f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1771f, 1176f, 29);
			AEBEGCDHIOJ();
		}
	}

	public void BJOFKEGDPOM()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		PIDDJHAFKKH(num);
	}

	public void EBHOPNFHHNP()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		CGOJNJHPLKF(num);
	}

	public void ODLKCAGIKBE()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(JNPBINOKMHC);
	}

	private void LGKFAMKBCIP(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.SendRequestBuffer)
		{
			POKOPFOIEIJ();
		}
	}

	private void BNIJKNCILPN()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.GetAllSquadMembers)
		{
			InitGui();
		}
	}

	public void GIICHGMJHIM()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		LHNBBNCOCJG(num);
	}

	private void BGPBOCDCGHC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)21)
		{
			FHIFJAAMEGM();
		}
	}

	public void ECEDDLGIEFG()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		NAMAMFHNJMK(num);
	}

	public void INMDPGCHHPN()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BGPBOCDCGHC);
	}

	public void JGEKEPNPIMG()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		DDPGFPCFPNJ(num);
	}

	private void JNEFALIEBED(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 631f : 1612f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1088f, 1923f, 107);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.GCMDBPHCEGC();
				OGPGKKFJNPN();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 134f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 678f, 1809f, -99);
			PHGACHAOKFH();
		}
	}

	private void OKPMAEMNBDP()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void NINGMLNMLLP()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMPKGNKEONO);
	}

	public void MCKENMMKBLM()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		MECMGAFJLFP(num);
	}

	private void DDPGFPCFPNJ(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 1;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 185f : 402f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 585f, 714f, -79);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.BAIAKMKHBBP();
				LJPIFDHAALJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1580f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 810f, 849f, -74);
			LJPIFDHAALJ();
		}
	}

	public void JMDOFLJIGKO()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(LGKFAMKBCIP);
	}

	public void HIMAIHEHDPB()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		CBJMEPJILAD(num);
	}

	private void MOCBCPDKHGI(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 772f : 212f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1334f, 439f, -35);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.BAIAKMKHBBP();
				PNKCOMMLOGD();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1010f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1534f, 1821f, 131);
			BNIJKNCILPN();
		}
	}

	private void MECMGAFJLFP(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1095f : 133f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 942f, 771f, -92);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				LJPIFDHAALJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 134f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1674f, 685f, -11);
			AHKLACHONCP();
		}
	}

	private void PEOIJDLHNPB(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1846f : 1611f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1923f, 1774f, 31);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				IAAIHLNFMOK();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 631f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1808f, 1810f, -65);
			IAAIHLNFMOK();
		}
	}

	private void HHGGGPFLONJ(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 67f : 823f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 746f, 711f, -188);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.BAIAKMKHBBP();
				AEBEGCDHIOJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 618f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 916f, 136f, -74);
			LGNDPLNCCJP();
		}
	}

	public void HDAIGJNPLMP()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		MEOCKDBBFLB(num);
	}

	private void MLBDKECFLLN(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 1;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 923f : 1063f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 257f, 725f, -92);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				BNIJKNCILPN();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1205f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 691f, 292f, 83);
			PMFPONEKKKE();
		}
	}

	private void BMOMAMACMHM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-80))
		{
			MCKENMMKBLM();
		}
	}

	private void PHMNPNIMBKL()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void OFKBJMOKPEC()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void FDEIAEFNHGG()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void CCIJFOLIFAD(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)100)
		{
			HDLFOJMKIPG();
		}
	}

	private void JBIONFCICAO(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1104f : 928f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 771f, 1596f, 61);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.LLNCGPAANAF();
				IAAIHLNFMOK();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1253f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1867f, 1969f, -49);
			AKAAHBJIGFH();
		}
	}

	private void OJFDHLOOBGJ(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 58f : 375f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 127f, 763f, -7);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				PMFPONEKKKE();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 180f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1801f, 1264f, -146);
			AKAAHBJIGFH();
		}
	}

	private void BGJKNBJELAJ(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-14))
		{
			HOBJJMNPEHO();
		}
	}

	public void HAHKNAIIIPC()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BGJKNBJELAJ);
	}

	private void MMFKEKBFIJO(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 844f : 1373f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 356f, 189f, 91);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				FMCLMMGFIPE();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1845f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1395f, 1431f, -29);
			OFKBJMOKPEC();
		}
	}

	public void InitGui()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		NAMAMFHNJMK(num);
	}

	private void BDANGEOMGNJ(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 331f : 1125f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 862f, 618f, 153);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.BAIAKMKHBBP();
				GDNHJBMIFDL();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1617f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1504f, 1591f, -143);
			IHHFNBFGJDA();
		}
	}

	private void GHMHGGLIMPO(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 1;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 689f : 1463f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1804f, 993f, 20);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.GCMDBPHCEGC();
				LJPIFDHAALJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 61f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 794f, 1882f, -165);
			AHKLACHONCP();
		}
	}

	public void AJBKDDKHMMH()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		CBJMEPJILAD(num);
	}

	private void AHKOOMKKEBJ()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void IBOHNHAAPEB()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += GCBHPNGKOKN;
	}

	private void CGOJNJHPLKF(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 1;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1069f : 1493f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1075f, 1251f, -130);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.BAIAKMKHBBP();
				PMFPONEKKKE();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 170f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 739f, 962f, 146);
			AHKLACHONCP();
		}
	}

	private void AKAAHBJIGFH()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void IODMAGJAAFE()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		PEOIJDLHNPB(num);
	}

	private void MDFDJBMHKOF()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void LOKPJBMPDDN()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		MMFKEKBFIJO(num);
	}

	private void GDNHJBMIFDL()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void JHLIGGGCBIK(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.UniqueSquadNameFailure)
		{
			DPDCIMEKFJJ();
		}
	}

	private void LFPBBIIANLC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)51)
		{
			JGEKEPNPIMG();
		}
	}

	public void NMADELLJEPP()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += CCIJFOLIFAD;
	}

	public void DKOBODLPNPK()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		CGOJNJHPLKF(num);
	}

	private void MEOCKDBBFLB(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 1;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1871f : 1777f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 601f, 1197f, -33);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.GCMDBPHCEGC();
				MINAHBEAHFH();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 503f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1520f, 1333f, 93);
			OGPGKKFJNPN();
		}
	}

	private void LEFKFIEDJCB(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-77))
		{
			LOKPJBMPDDN();
		}
	}

	public void ENJOLLFPEDI()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LFPBBIIANLC;
	}

	private void LHNBBNCOCJG(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 1;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 450f : 645f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1287f, 659f, 53);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				PHMNPNIMBKL();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1571f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1120f, 214f, -191);
			FDEIAEFNHGG();
		}
	}

	private void CCOKEAGDAGP(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1368f : 413f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1094f, 1879f, -60);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.PCJEOGBAEOF();
				LGNDPLNCCJP();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1546f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1144f, 744f, -76);
			AHKOOMKKEBJ();
		}
	}

	private void PNKCOMMLOGD()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void JFMOGGFMHHA()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(LEFKFIEDJCB);
	}

	public void KIBHLENCGLG()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		MMFKEKBFIJO(num);
	}

	public void NJKKGPNDOPB()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		ENBAJMBPHOJ(num);
	}

	public void NJNEPMHCKFL()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		DJNIKOKKFKE(num);
	}

	private void MINAHBEAHFH()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void HOBJJMNPEHO()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		MLBDKECFLLN(num);
	}

	public void HEOMHIGCMOC()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void IHHFNBFGJDA()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void KLPACNJJDIA(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)43)
		{
			DPDCIMEKFJJ();
		}
	}

	public void PJHCHEHKHEN()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(KKABDDOBOCO);
	}

	public void GPPDLDKAOOC()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		MEOCKDBBFLB(num);
	}

	public void DMLPFCLAKGL()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		CGOJNJHPLKF(num);
	}

	public void GHHNNIKGJFG()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(JHLIGGGCBIK);
	}

	public void LBHEIOEPJLJ()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += KLPACNJJDIA;
	}

	public void FCOEPIEEMDB()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 0;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		MEOCKDBBFLB(num);
	}

	private void GCBHPNGKOKN(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-66))
		{
			MCKENMMKBLM();
		}
	}

	private void CBJMEPJILAD(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1920f : 1423f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1774f, 154f, -87);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				AHKOOMKKEBJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 712f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 718f, 1155f, 140);
			IAAIHLNFMOK();
		}
	}

	private void DJNIKOKKFKE(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1027f : 1852f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1443f, 502f, -182);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.Rescale();
				AHKOOMKKEBJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1801f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1019f, 1073f, 128);
			FDEIAEFNHGG();
		}
	}

	private void FMCLMMGFIPE()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void GIMDFBEKBFC(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 0;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1100f : 1736f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 936f, 1669f, 25);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.BAIAKMKHBBP();
				AHKOOMKKEBJ();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 393f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 867f, 361f, -93);
			BNIJKNCILPN();
		}
	}

	private void PMFPONEKKKE()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void LGNDPLNCCJP()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void LJPIFDHAALJ()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	public void EDFMOCGKHHH()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LEFKFIEDJCB;
	}

	public void EFKFHFNAOHA()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += BMOMAMACMHM;
	}

	private void AEBEGCDHIOJ()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void AHKLACHONCP()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void FEOGBAGIKME(int CIFCDKNDABO)
	{
		bool flag = CIFCDKNDABO > 1;
		JNPNGJHPEPH.SetActive(flag);
		GLMONLKGCPO.transform.localPosition = GLMONLKGCPO.transform.localPosition.ReplaceX((!flag) ? 1625f : 211f);
		if (flag)
		{
			IIEGMBACHLC.text = MEJMLNDFDBP.GMIPFLIEOHD(CIFCDKNDABO);
			float y = PGNJHACIOOH.transform.localScale.y;
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 881f, 736f, -125);
			if (y != PGNJHACIOOH.transform.localScale.y)
			{
				KMHGGDFBBJP.GCMDBPHCEGC();
				PHMNPNIMBKL();
			}
		}
		else if (PGNJHACIOOH.transform.localScale.y < 1516f)
		{
			MEJMLNDFDBP.COCBCFKJOJE(PGNJHACIOOH, 1589f, 1191f, 176);
			GDNHJBMIFDL();
		}
	}

	public void FHIFJAAMEGM()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		ADHFHFJJICC(num);
	}

	public void DPDCIMEKFJJ()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		NAMAMFHNJMK(num);
	}

	public void LNFFHCONPFG()
	{
		int num = 1;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		CGOJNJHPLKF(num);
	}

	private void OGPGKKFJNPN()
	{
		IIEGMBACHLC.transform.localPosition = IIEGMBACHLC.transform.localPosition.ReplaceY(PGNJHACIOOH.transform.localPosition.y);
		IIEGMBACHLC.transform.localScale = PGNJHACIOOH.transform.localScale;
	}

	private void OJJAJHLFNKK(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-48))
		{
			MCKENMMKBLM();
		}
	}

	public void BKMICKACLBK()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (list != null)
			{
				num = 1;
				foreach (DatabasePlayer item in list)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num += 0;
					}
				}
			}
		}
		CBJMEPJILAD(num);
	}
}
