using UnityEngine;

public class HeaderTicketsButton : GuiElementSingle<HeaderTicketsButton>
{
	[SerializeField]
	[Header("Core")]
	private UILabel mTicketsLabel;

	private void GFKBDAPDKHI(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (NPFFMLLLDAF())
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1757f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1961f, 1832f, 93);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 116f, 535f, -50);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 104f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void BGPAHPGDDJB()
	{
	}

	public virtual void BMMNJICILHJ()
	{
	}

	private void PHGFBJFFFPH()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public virtual void IODCFNOOAKM()
	{
	}

	public virtual void OJADEGHEHJK()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.JPFBDMKDDLM(IAACBIIPADK);
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(HDAKEFLCIID);
	}

	private void FDPALILOBOF()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void KOOHNLNDKBG()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	public virtual void LNGCPPINMJJ()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += CCHJIEIPGAM;
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(PHGFBJFFFPH);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += AMLGFLDAMMM;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
	}

	public virtual void ODCHCNCMJGC()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1138f, 1347f, 109);
		}
	}

	private void AMLGFLDAMMM(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 0f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 59f, 20f, 110);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 59f, 20f, 110);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 2f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void AAJLGPIGDED()
	{
	}

	public virtual void IMEOAPEABLG()
	{
	}

	public virtual void NDBAEHKKJMH()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 419f, 1038f, -109);
		}
	}

	private void MIBDMBCMIGP(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (NPFFMLLLDAF())
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1642f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 165f, 1574f, -26);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 324f, 1255f, -116);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 528f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	private void HBMHMPEIPFK(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (NPFFMLLLDAF())
		{
			if (ODNAADFONLC == 1)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1606f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1664f, 886f, 116);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 718f, 1811f, 120);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1050f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void KPHJFKCOIIF()
	{
	}

	public virtual void GFLLEMCAJGN()
	{
	}

	private void COBFFPOMHJD()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	private void FEHFKDLPOMN()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public virtual void KPEJMMBDODD()
	{
	}

	private void LOOAHMJOGNF(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 1)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1423f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1051f, 679f, 114);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1025f, 15f, 117);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 621f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void KNOKOJKOCEB()
	{
	}

	private void DNFBOCMLFLH(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 962f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1643f, 7f, 92);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 555f, 825f, -112);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1760f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void HAGEKBKIKIE()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += CCHJIEIPGAM;
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(CMJDENBPPNN);
	}

	public virtual void PJENKEKOCAE()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1644f, 229f, -1);
		}
	}

	public virtual void NHLBCFPFHED()
	{
	}

	public virtual void BCLAFFCPCEH()
	{
	}

	private void AKGHCBMNEGC()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	public virtual void MLNCPPECLPH()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += HBMHMPEIPFK;
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(PHGFBJFFFPH);
	}

	public virtual void IEHJMLIMNEP()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1655f, 879f, -79);
		}
	}

	private void FNGBANPFIBK(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 886f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 703f, 1893f, 40);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 484f, 92f, 67);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1346f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void NGHAPNEFBED()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 38f, 1277f, 123);
		}
	}

	public virtual void HGKNCKIKBDC()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 679f, 522f, 72);
		}
	}

	private void IAACBIIPADK(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 1)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1494f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1121f, 155f, -66);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1837f, 183f, -8);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1599f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	private void GKGNBPNDAKK()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void OJAOBGEGLNC()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void FLCNKGHFPHN()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	private void ONKBFKGNPFI()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public virtual void NFNMLPPDPAP()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1989f, 1349f, -50);
		}
	}

	public virtual void BLCMDJNIJCK()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += CCHJIEIPGAM;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += ONKBFKGNPFI;
	}

	public virtual void KPDFFFHEPOO()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += CDOFIOMKPDF;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += KOOHNLNDKBG;
	}

	private void PPDFNCIBPPK()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public virtual void AFICHGGNMJB()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.JPFBDMKDDLM(HBMHMPEIPFK);
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += CMJDENBPPNN;
	}

	public override void InitControls()
	{
	}

	private void IMPAGDJAOFJ(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (NPFFMLLLDAF())
		{
			if (ODNAADFONLC == 1)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1069f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1096f, 1143f, 94);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 32f, 1178f, -1);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 535f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void INBJGJOFJMK()
	{
	}

	public virtual void HEEANEFGCCJ()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 419f, 1535f, 117);
		}
	}

	public virtual void PLDAPLOGJPA()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += DNFBOCMLFLH;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PPDFNCIBPPK;
	}

	private void HDAKEFLCIID()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	private void KDIHIHAOJKO(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 1)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 335f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 256f, 576f, -104);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 429f, 41f, 93);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1205f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void JJDJKPGLHGD()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1462f, 118f, -79);
		}
	}

	public override void InitGUIValues()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 59f, 20f, 110);
		}
	}

	public virtual void FCIANKCBLKM()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.JPFBDMKDDLM(IAACBIIPADK);
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += GKGNBPNDAKK;
	}

	public virtual void HHJDKKFKKIL()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1362f, 1940f, -111);
		}
	}

	private void CDOFIOMKPDF(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 1)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1234f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 192f, 895f, 39);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1689f, 1334f, -39);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 498f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	public virtual void IKHPOKNAGGN()
	{
		base.InitEvents();
		Singleton<Wallet>.instance.TicketsChanged += CCHJIEIPGAM;
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(KOOHNLNDKBG);
	}

	public virtual void EIPIEOCIGKL()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<Wallet>.instance.tickets);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 430f, 1963f, -30);
		}
	}

	private void CCHJIEIPGAM(long IEALLELGOBM, long ODNAADFONLC)
	{
		if (isShowed)
		{
			if (ODNAADFONLC == 0)
			{
				TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1617f, new OLDCFKEJDPA(IEALLELGOBM), new OLDCFKEJDPA(IEALLELGOBM));
				MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1296f, 1989f, 61);
				return;
			}
			long num = IEALLELGOBM - ODNAADFONLC;
			long fFHHEHHFOKJ = ((num >= IEALLELGOBM) ? num : IEALLELGOBM);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			MEJMLNDFDBP.COCBCFKJOJE(mTicketsLabel, 1553f, 701f, -9);
			mTicketsLabel.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
			TweenTextCounterLong.Begin(mTicketsLabel.gameObject, 1855f, new OLDCFKEJDPA(num), new OLDCFKEJDPA(IEALLELGOBM));
		}
	}

	private void CMJDENBPPNN()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}
}
