public class GameTypeDependObject : Core_BaseScript
{
	[BitMask(typeof(GameController.ELDLECMNIME))]
	public GameController.ELDLECMNIME FJLBLLLEELD;

	protected virtual void PAPFKMJEMML()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += CKLJJHACIAJ;
	}

	private void AKBLKDEFNEE()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= CLJFBCIDJAE;
		}
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	private void PKEFNDAPFEJ()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= JCJMABLEPEK;
		}
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += OMLMLHNBHDE;
	}

	private void IKCLAJJGAIB()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= NLMHADNPKDO;
		}
	}

	private void JCJMABLEPEK()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += CLJFBCIDJAE;
	}

	protected virtual void BMLLLOBPGIB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += NLMHADNPKDO;
	}

	private void KCJGDLOGJNF()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= BLMANIIEGLK;
		}
	}

	private void JKMIFJFHGMJ()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	protected virtual void CFGDCEOLKJG()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += BLMANIIEGLK;
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += CLJFBCIDJAE;
	}

	private void OnDisable()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= ACLCPJHKHLL;
		}
	}

	protected virtual void IEBHCNFALAB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += NLMHADNPKDO;
	}

	protected virtual void FJOCJOOFJBI()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += BLMANIIEGLK;
	}

	private void OEABFGPAMKH()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= CKLJJHACIAJ;
		}
	}

	private void MBHBDEOMMOL()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= JELCJAGAMKP;
		}
	}

	private void BBDACDBLGHC()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= ACLCPJHKHLL;
		}
	}

	private void BBMALOMJLAG()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= ACLCPJHKHLL;
		}
	}

	private void BFLELDDGDPF()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= BLMANIIEGLK;
		}
	}

	private void MDKIMEGPHEN()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	private void EENMDBADJOD()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= OMLMLHNBHDE;
		}
	}

	private void MNPINAGALCO()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= BOAJMKAIHHA;
		}
	}

	private void GLMOJIBOION()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= CKLJJHACIAJ;
		}
	}

	private void NKFPADOCDMA()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= PBIOAIFPLMC;
		}
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += JELCJAGAMKP;
	}

	protected virtual void MEBEHLLPMPK()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += BOAJMKAIHHA;
	}

	protected virtual void OIKLJGMKMAE()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += HFCLCAHMAGN;
	}

	private void OMLMLHNBHDE()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	protected virtual void IOAEHDJGBJC()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += OMLMLHNBHDE;
	}

	private void AJLNLJCFOHL()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= HFCLCAHMAGN;
		}
	}

	private void EPDKBCNLLFC()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= JKMIFJFHGMJ;
		}
	}

	private void OGNMLLBAOBM()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= HFCLCAHMAGN;
		}
	}

	private void BDNOKBCACAD()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= OMLMLHNBHDE;
		}
	}

	protected virtual void IOKMAFLIJEG()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += PBIOAIFPLMC;
	}

	private void JCELFGKLJBH()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= BOAJMKAIHHA;
		}
	}

	private void CKLJJHACIAJ()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	protected virtual void GBGDKNIMGMB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += JKMIFJFHGMJ;
	}

	private void FLOBKJBGCON()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= CKLJJHACIAJ;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += BOAJMKAIHHA;
	}

	private void CCFIFGKEIJK()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= CLJFBCIDJAE;
		}
	}

	private void BOAJMKAIHHA()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	protected virtual void IBLPGJOHIAE()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += OMLMLHNBHDE;
	}

	private void MHPFHCGHINO()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= ACLCPJHKHLL;
		}
	}

	private void PBIOAIFPLMC()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	private void HFCLCAHMAGN()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	private void BLMANIIEGLK()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	private void OnDestroy()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= ACLCPJHKHLL;
		}
	}

	private void NLPFAKKGONC()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= BOAJMKAIHHA;
		}
	}

	private void ACLCPJHKHLL()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	private void JPPHEPCDIID()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= CLJFBCIDJAE;
		}
	}

	private void MCIJDPPBPNG()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= BOAJMKAIHHA;
		}
	}

	private void ICDMLNGPHKC()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= OMLMLHNBHDE;
		}
	}

	private void AJANHCDBAHJ()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= CLJFBCIDJAE;
		}
	}

	private void DNEMEMDNAEO()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= BLMANIIEGLK;
		}
	}

	private void JELCJAGAMKP()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	private void HPNEBKMFAIJ()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= OMLMLHNBHDE;
		}
	}

	protected virtual void MGAFJAJNBFL()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += BLMANIIEGLK;
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += JELCJAGAMKP;
	}

	private void FIEHPMCFCNO()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= JELCJAGAMKP;
		}
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += OMLMLHNBHDE;
	}

	private void PBDCPELCEKL()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= NLMHADNPKDO;
		}
	}

	private void OJAKOGMKLDC()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= JCJMABLEPEK;
		}
	}

	private void CLJFBCIDJAE()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	private void LCLBIGJBIOM()
	{
		if (Singleton<GameController>.instance != null)
		{
			Singleton<GameController>.instance.GameStarted -= CKLJJHACIAJ;
		}
	}

	private void NLMHADNPKDO()
	{
		GameController.ELDLECMNIME gameType = Singleton<GameController>.instance.gameType;
		if (base.gameObject != null)
		{
			base.gameObject.SetActive((FJLBLLLEELD & gameType) == gameType);
		}
	}

	protected virtual void PBCDDNOCJOI()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += HFCLCAHMAGN;
	}
}
