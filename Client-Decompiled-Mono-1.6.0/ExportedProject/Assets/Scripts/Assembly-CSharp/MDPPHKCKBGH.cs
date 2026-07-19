using System.Collections;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.MobileAnalytics.MobileAnalyticsManager;
using Amazon.Runtime.Internal;
using UnityEngine;

public class MDPPHKCKBGH
{
	private MobileAnalyticsManager HCLLNMJMLBF;

	private UnityMainThreadDispatcher KBIINNGDBCM;

	public void OLLKANJHKGO()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void NFNGKOLFINE()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void IKCLPOECBLC()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void IFDMDOPPAJB(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void APCMBECOBKD()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void NGDMAKEHKBC(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void OENGBDACDDL(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute(" {0}{1}", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhOR82yQJKu6ymLcFyTQEFkgs7PfSVXPSWcLC1JtdbMTNUmNfoM0up/7/8nRGzquPkZKF0KwVzJZJepHRzRXJiZwhGgMvDNAjwilqKAWcVGbIZPbDBZCJWxqQDgs+Ma4Pr7cPV48tDSHFPzcDxGUvfjl+sOdb1GTBZLDr3XvzBwjOwrQ5wbiY7/YdZYiv0I3UfQzmxOL9a1XfzAI1M5TcAS4vE32dPRYTM72+pt+Vr2kPuY8rF9E5RcGBWLQHuyPg9vPBre2hJPAKWJUUKrLJmxwS+mS/yv/ROkpQgKslIRHzJBmuLaLwBJyU4ZR1UAYlnzafHj/CJv96Y+7TUiY/ZwIDAQAB", Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH());
		customEvent.AddAttribute("DOWNLOAD", string.Format("ID_SILVERPACK", Singleton<BeanstalkServerManager>.instance.currentTimestamp, Random.Range(0, -189)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void LHJPDCHIGKL()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void IHMANGFDPNB()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void KDKGLGGLGKB(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("Beanstalk: Skipping ", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("[.,']*", Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH());
		customEvent.AddAttribute("NextDailyRewardLocalnotification", string.Format("ID_TUTORIAL_START_PHASE2_DOWN", Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), Random.Range(0, -11)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void HCOJGGHBCEK()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void MLDKEHHIDNF()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void PLKEMIIJHKD()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void CGBLFFPCMNC(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void OEGLGDMFIGD(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1687.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = ".";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void ACGCAIDNKGL()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void ABNCEPGGNPD(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1768.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "SquadId";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void PEDFLFIAMEH(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1506.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "ID_CHATCANNOTSENDMESSAGES";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void LGHHOJIEOFH()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void CKGIAPAFMBJ(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void KOEFPIKMAOJ(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("()Z", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("Rank", Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH());
		customEvent.AddAttribute("game-elite-buff", string.Format("Wrong_Category", Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), Random.Range(0, -79)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void EACGDICIKKP(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("a", GameLoginManager.instance.playerId);
		customEvent.AddAttribute(", action = ", Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH());
		customEvent.AddAttribute("ID_NOTINLEAGUEMOREMATCHESTEXT", string.Format("elitepack5", Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), Random.Range(1, -70)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void IGGNGOEBJJB(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("Card pool shown!!", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("\n", Singleton<BeanstalkServerManager>.instance.environmentName);
		customEvent.AddAttribute("D2", string.Format("{0} {1}", Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), Random.Range(0, 1)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void PDPJJEOBMKF(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void KLPIGLKCDDE(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1289.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "subscriber_since";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void FMMKACONONI(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void CNBBKJKBDBM(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void NGHNNLDGNBI()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void GOEPFIJFNNE(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1608.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "Squad name failure";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void FMMJJEHCEOI(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1360.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "CardsInCardPack";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void GBFLHCLANOO()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void ANAOGKGLGLL()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void GIACEBJECPL()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void PLOKAKJLPBM(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 778.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "ID_CONFIRM_NOTLEADEROFSQUAD_TEXT";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void DEDFJJJFFKL()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void IFFOLMKHJCB(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1792.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "Sheet ";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void LMCGFJDGEFI(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "Google";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void IILNMJDIHFM()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void EFIHEINEMHB(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void DJHFMOOMBJM(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void HIKHMDGHFBH(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 676.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void EOOMCJHPFCI(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("StartCameraAnimationFinishedRPC", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("rateAppShownCounter", Singleton<BeanstalkServerManager>.instance.environmentName);
		customEvent.AddAttribute("ID_SALEPERCENTLINE", string.Format("ID_DAY_SMALL", Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), Random.Range(0, 123)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void FLHKKEAHLEM()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void BOMBODCCCGA()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void DLNPMDJIPIP()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void JOLGBEMAAPH(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void BKELCKJEFOF()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void MBFOMEIDFBG(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void ABDHFGOCKKE()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void BPKLCKNHBGJ(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1982.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "Time";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void KMOKKELBFNJ()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = false;
		}
	}

	public void PHJFNNBBKGI(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 188.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "TH";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void EPDMPAIJPBP(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("PromotedPlayerId", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("WarArenaRuleConcreteMap", Singleton<BeanstalkServerManager>.instance.environmentName);
		customEvent.AddAttribute("Squad Points - {0}\n", string.Format("Position", Singleton<BeanstalkServerManager>.instance.currentTimestamp, Random.Range(0, -186)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void JHJMFHMAIKM()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void DFIKCCFIDHC()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void DBEJJPLFCBE(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1619.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "WarBucks";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public MDPPHKCKBGH(GameObject BIBPOPIDOGO)
	{
		UnityInitializer.AttachToGameObject(BIBPOPIDOGO);
		CognitoAWSCredentials credentials = new CognitoAWSCredentials("us-east-1:a951d2ae-0491-424d-8240-ae25baedf92a", RegionEndpoint.USEast1);
		HCLLNMJMLBF = MobileAnalyticsManager.GetOrCreateInstance("81cb29735bbd4830b860f8d13ebeb48b", credentials, RegionEndpoint.USEast1);
		KBIINNGDBCM = BIBPOPIDOGO.GetComponent<UnityMainThreadDispatcher>();
		Debug.Log("#VAVRO# mMainThreadDispatcher is null " + (KBIINNGDBCM == null));
	}

	public void JFNGNNCOKII(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("^.*-", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("Wrong_Unit", Singleton<BeanstalkServerManager>.instance.environmentName);
		customEvent.AddAttribute("{0} {1}", string.Format("registerBirthday", Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), Random.Range(0, 166)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void OEJOPNKBGKE()
	{
		if (KBIINNGDBCM != null)
		{
			KBIINNGDBCM.enabled = true;
		}
	}

	public void CPEMDAMMMBE(bool BIPHGJOBOGM)
	{
		if (BIPHGJOBOGM)
		{
			HCLLNMJMLBF.ResumeSession();
		}
		else
		{
			HCLLNMJMLBF.PauseSession();
		}
	}

	public void DAAFBKMOHFE(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		CustomEvent customEvent = new CustomEvent(DDLNDBANBHK);
		double result;
		if (double.TryParse(FKBHNLOAPAA, out result))
		{
			customEvent.AddMetric(ICCBMABGOCP, result);
		}
		else if (!string.IsNullOrEmpty(ICCBMABGOCP))
		{
			customEvent.AddAttribute(ICCBMABGOCP, FKBHNLOAPAA);
		}
		if (CCODGCEOMOP != null)
		{
			foreach (DictionaryEntry item in CCODGCEOMOP)
			{
				if (item.Value is int)
				{
					customEvent.AddMetric(item.Key.ToString(), (int)item.Value);
				}
				else if (item.Value is long)
				{
					customEvent.AddMetric(item.Key.ToString(), (long)item.Value);
				}
				else if (item.Value is float)
				{
					customEvent.AddMetric(item.Key.ToString(), (float)item.Value);
				}
				else if (item.Value is double)
				{
					customEvent.AddMetric(item.Key.ToString(), (double)item.Value);
				}
				else
				{
					customEvent.AddAttribute(item.Key.ToString(), item.Value.ToString());
				}
			}
		}
		customEvent.AddAttribute("Player_id", GameLoginManager.instance.playerId);
		customEvent.AddAttribute("DB_enviroment", Singleton<BeanstalkServerManager>.instance.environmentName);
		customEvent.AddAttribute("EUId", string.Format("{0}-{1:D6}", Singleton<BeanstalkServerManager>.instance.currentTimestamp, Random.Range(0, 1000000)));
		HCLLNMJMLBF.RecordEvent(customEvent);
	}

	public void DBGLFLABGKE(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1750.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "HU";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}

	public void CDHDKODJLKM(string DLCHBBJNBKP, double OPEICELHNLI, string GGKHBILEAGB, string DFHEDJIGLKD, string ADNDMABPHOH)
	{
		MonetizationEvent monetizationEvent = new MonetizationEvent();
		monetizationEvent.Quantity = 1545.0;
		monetizationEvent.ItemPrice = OPEICELHNLI;
		monetizationEvent.ProductId = DLCHBBJNBKP;
		monetizationEvent.ItemPriceFormatted = GGKHBILEAGB;
		monetizationEvent.Store = "Wanted to remove null database message!!!";
		monetizationEvent.TransactionId = DFHEDJIGLKD;
		monetizationEvent.Currency = ADNDMABPHOH;
		HCLLNMJMLBF.RecordEvent(monetizationEvent);
	}
}
