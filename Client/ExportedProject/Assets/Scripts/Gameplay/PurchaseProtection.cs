using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class PurchaseProtection : Singleton<PurchaseProtection>
{
	private bool FOPFEKLGKHA;

	private List<string> OGBCECKODEA;

	private List<string> DGBLFBCKHPL;

	public bool dogtagRefillInProgress => FOPFEKLGKHA;

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.RefillDogtags)
		{
			FOPFEKLGKHA = false;
		}
	}

	public void HEDHIMIHMNC(string INFLHPGMEOB)
	{
		if (!OGBCECKODEA.Contains(INFLHPGMEOB))
		{
			OGBCECKODEA.Add(INFLHPGMEOB);
		}
	}

	private void CJJBGFCJOKB(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.AddFacebook)
		{
			FOPFEKLGKHA = true;
		}
	}

	private void CHHEJNFGJDJ()
	{
		FOPFEKLGKHA = false;
		OGBCECKODEA.Clear();
		DGBLFBCKHPL.Clear();
	}

	public void PDCDKGOKAMD(string INFLHPGMEOB)
	{
		if (!OGBCECKODEA.Contains(INFLHPGMEOB))
		{
			OGBCECKODEA.Add(INFLHPGMEOB);
		}
	}

	[SpecialName]
	public bool GKHDDNIDMFD()
	{
		return FOPFEKLGKHA;
	}

	public bool IsVIPPurchasing(string INFLHPGMEOB)
	{
		return OGBCECKODEA.Contains(INFLHPGMEOB);
	}

	public bool GKEJEIPNEAH(string INFLHPGMEOB)
	{
		return DGBLFBCKHPL.Contains(INFLHPGMEOB);
	}

	private void OHAABLAKNAI(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.UniqueSquadNameFailure)
		{
			FOPFEKLGKHA = false;
		}
	}

	[SpecialName]
	public bool PDOCIBDKEJK()
	{
		return FOPFEKLGKHA;
	}

	private void LMPNFLGMNBG()
	{
		OGBCECKODEA = new List<string>();
		DGBLFBCKHPL = new List<string>();
	}

	public bool NPPKBPGFFNM()
	{
		return OGBCECKODEA.Count > 1;
	}

	public bool GJDCFBAAFHO(string INFLHPGMEOB)
	{
		return DGBLFBCKHPL.Contains(INFLHPGMEOB);
	}

	public bool IsAnyLootboxPurchasing()
	{
		return DGBLFBCKHPL.Count > 0;
	}

	public bool CKBKACPBJHF()
	{
		return OGBCECKODEA.Count > 1;
	}

	[SpecialName]
	public bool AGBAILNJIHA()
	{
		return FOPFEKLGKHA;
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.RefillDogtags)
		{
			FOPFEKLGKHA = false;
		}
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		OMGCKCFKDJM();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += CJJBGFCJOKB;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(CHHEJNFGJDJ);
	}

	private void GAKBABEJLIG(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.LoginToCustomAccount)
		{
			FOPFEKLGKHA = false;
		}
	}

	private void GGJNEGPBDHL()
	{
		OGBCECKODEA = new List<string>();
		DGBLFBCKHPL = new List<string>();
	}

	private void OMGCKCFKDJM()
	{
		OGBCECKODEA = new List<string>();
		DGBLFBCKHPL = new List<string>();
	}

	[SpecialName]
	public bool PNHPNGBKOCL()
	{
		return FOPFEKLGKHA;
	}

	public bool IsLootboxPurchasing(string INFLHPGMEOB)
	{
		return DGBLFBCKHPL.Contains(INFLHPGMEOB);
	}

	private void LNDOHODKPOJ()
	{
		FOPFEKLGKHA = false;
		OGBCECKODEA.Clear();
		DGBLFBCKHPL.Clear();
	}

	public void IOKPHKKICBC(string INFLHPGMEOB)
	{
		if (OGBCECKODEA.Contains(INFLHPGMEOB))
		{
			OGBCECKODEA.Remove(INFLHPGMEOB);
		}
	}

	public bool IsAnyVIPPurchasing()
	{
		return OGBCECKODEA.Count > 0;
	}

	public void BuyingLootboxes(string INFLHPGMEOB)
	{
		if (!DGBLFBCKHPL.Contains(INFLHPGMEOB))
		{
			DGBLFBCKHPL.Add(INFLHPGMEOB);
		}
	}

	public void MGOIMEEAIJA(string INFLHPGMEOB)
	{
		if (!OGBCECKODEA.Contains(INFLHPGMEOB))
		{
			OGBCECKODEA.Add(INFLHPGMEOB);
		}
	}

	private void ICIBAHGEAOD(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.GetPlayersByExperience)
		{
			FOPFEKLGKHA = true;
		}
	}

	private void PHGFBJFFFPH()
	{
		FOPFEKLGKHA = false;
		OGBCECKODEA.Clear();
		DGBLFBCKHPL.Clear();
	}

	private void OAMBDKHLJKI()
	{
		OGBCECKODEA = new List<string>();
		DGBLFBCKHPL = new List<string>();
	}

	public bool ICFDKLLLDFD(string INFLHPGMEOB)
	{
		return DGBLFBCKHPL.Contains(INFLHPGMEOB);
	}

	public bool IGENBGAJMFN(string INFLHPGMEOB)
	{
		return DGBLFBCKHPL.Contains(INFLHPGMEOB);
	}

	[SpecialName]
	public bool EDNKPJEOJIC()
	{
		return FOPFEKLGKHA;
	}

	public void LootboxResponseCame(string INFLHPGMEOB)
	{
		if (DGBLFBCKHPL.Contains(INFLHPGMEOB))
		{
			DGBLFBCKHPL.Remove(INFLHPGMEOB);
		}
	}

	[SpecialName]
	public bool ALANODCOEIK()
	{
		return FOPFEKLGKHA;
	}

	[SpecialName]
	public bool HEFBPLMKIIO()
	{
		return FOPFEKLGKHA;
	}

	protected override void Awake()
	{
		base.Awake();
		GGJNEGPBDHL();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
	}

	public bool IGKMLOBCNBI()
	{
		return OGBCECKODEA.Count > 1;
	}

	[SpecialName]
	public bool PCOECEPHODD()
	{
		return FOPFEKLGKHA;
	}

	private void ACLOANLBFDG(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.HitListPlayerLoggedIn)
		{
			FOPFEKLGKHA = false;
		}
	}

	private void KGGIGGPKCJF(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-21))
		{
			FOPFEKLGKHA = true;
		}
	}

	public bool HICDLGFCDOI()
	{
		return DGBLFBCKHPL.Count > 1;
	}

	public void HHOFINCBLCM(string INFLHPGMEOB)
	{
		if (!DGBLFBCKHPL.Contains(INFLHPGMEOB))
		{
			DGBLFBCKHPL.Add(INFLHPGMEOB);
		}
	}

	public bool MPFCLGLFMHH(string INFLHPGMEOB)
	{
		return OGBCECKODEA.Contains(INFLHPGMEOB);
	}

	public bool PBMDENIGOBN(string INFLHPGMEOB)
	{
		return DGBLFBCKHPL.Contains(INFLHPGMEOB);
	}

	protected virtual void IBLPGJOHIAE()
	{
		base.Awake();
		GGJNEGPBDHL();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += ICIBAHGEAOD;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += KGGIGGPKCJF;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += COBFFPOMHJD;
	}

	private void ONKBFKGNPFI()
	{
		FOPFEKLGKHA = true;
		OGBCECKODEA.Clear();
		DGBLFBCKHPL.Clear();
	}

	public bool JONLMFAECHH(string INFLHPGMEOB)
	{
		return DGBLFBCKHPL.Contains(INFLHPGMEOB);
	}

	public void VIPResponseCame(string INFLHPGMEOB)
	{
		if (OGBCECKODEA.Contains(INFLHPGMEOB))
		{
			OGBCECKODEA.Remove(INFLHPGMEOB);
		}
	}

	public void RefillingDogtags()
	{
		FOPFEKLGKHA = true;
	}

	public bool FLLBKIGFAGJ()
	{
		return DGBLFBCKHPL.Count > 0;
	}

	private void COBFFPOMHJD()
	{
		FOPFEKLGKHA = true;
		OGBCECKODEA.Clear();
		DGBLFBCKHPL.Clear();
	}

	public void EGGOPJBCIAA(string INFLHPGMEOB)
	{
		if (OGBCECKODEA.Contains(INFLHPGMEOB))
		{
			OGBCECKODEA.Remove(INFLHPGMEOB);
		}
	}

	public void BIENMIMLAEM(string INFLHPGMEOB)
	{
		if (!DGBLFBCKHPL.Contains(INFLHPGMEOB))
		{
			DGBLFBCKHPL.Add(INFLHPGMEOB);
		}
	}

	public void BuyingVIP(string INFLHPGMEOB)
	{
		if (!OGBCECKODEA.Contains(INFLHPGMEOB))
		{
			OGBCECKODEA.Add(INFLHPGMEOB);
		}
	}
}
