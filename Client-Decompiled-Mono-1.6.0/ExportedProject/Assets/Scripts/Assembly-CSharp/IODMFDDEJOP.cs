using UnityEngine;

internal class IODMFDDEJOP : HHFHFANGCEJ
{
	private string DNEBFDALAFH;

	private int AIBAGMICGAE;

	private bool MKPKIPHBNOL;

	private bool BLBKJJGOCDA;

	private JPMLOCNCEGO[] KAEFHCKBMGM;

	public virtual void BIIHCAEKCOD()
	{
		base.OEAJBFLGJCA();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.JKMEOJOHLPN(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool FPKBGONCOAM()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public virtual bool FPHHJBMHGDD()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.KGPPDBFOGOK();
	}

	public virtual bool IBDAFAANAIG()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.COGGIIALJOP();
	}

	public virtual void FPLCMPHNNHK()
	{
		base.GEKIMGFKNHC();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.OHJEIGCJCLL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ONHPOAIKLAO(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void AEHBKBBILPB()
	{
		base.OEAJBFLGJCA();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.OHJEIGCJCLL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ONHPOAIKLAO(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public override void LOFMDBHAFAO()
	{
		base.GEKIMGFKNHC();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.OHJEIGCJCLL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ShowDialog(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool OFNLMAJMCBB()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return false;
			}
		}
		return base.COGGIIALJOP();
	}

	public IODMFDDEJOP(string DDLOAFGAEAC, int GAFOMGDLAFD, AKDLEDNDIEO FJLBLLLEELD)
		: base(string.Format("SpecialOfferMessage {0} {1} {2}", DDLOAFGAEAC, GAFOMGDLAFD, FJLBLLLEELD), NKHJBLBAAEB.SpecialOfferMessage)
	{
		DNEBFDALAFH = DDLOAFGAEAC;
		AIBAGMICGAE = GAFOMGDLAFD;
		MKPKIPHBNOL = (FJLBLLLEELD & AKDLEDNDIEO.Upgrade) == AKDLEDNDIEO.Upgrade;
		Debug.Log(string.Format("ADD special offer to show {0} {1} {2}", DDLOAFGAEAC, GAFOMGDLAFD, FJLBLLLEELD.ToString()));
	}

	public virtual bool NGBNNJCHNNL()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.NIJOCMMLCGG();
	}

	public virtual bool FIPBIMFFCMB()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return true;
			}
		}
		return base.KGPPDBFOGOK();
	}

	public virtual void LEOMLFCGIHK()
	{
		base.LOFMDBHAFAO();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.FCCJJKBPNCH(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.FCCJJKBPNCH(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ShowDialog(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool KGIBBDBIMNI()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.NIJOCMMLCGG();
	}

	public virtual bool FLOJLIEDBPB()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return true;
			}
		}
		return base.NIJOCMMLCGG();
	}

	public virtual bool IJIEHGGEHGF()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.LMMGABHMGLK();
	}

	public virtual void GKAOMCGCDGE()
	{
		base.LEJEDFACEGP();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ACAEMEEFCAH(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.DOLLPOPCANC(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public IODMFDDEJOP(JPMLOCNCEGO[] LDKNOAADOPA)
		: base(string.Format("SpecialOfferMessage"), NKHJBLBAAEB.SpecialOfferMessage)
	{
		BLBKJJGOCDA = true;
		string text = string.Empty;
		for (int i = 0; i < LDKNOAADOPA.Length; i++)
		{
			text = text + " " + LDKNOAADOPA[i].INFLHPGMEOB + LDKNOAADOPA[i].CJJHPGFOHCH;
		}
		NHHGDIDEIMM += text;
		KAEFHCKBMGM = LDKNOAADOPA;
	}

	public virtual bool PGGEHPCEGKE()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return false;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public virtual bool KGPFNNLNMID()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return false;
			}
		}
		return base.LMMGABHMGLK();
	}

	public virtual bool HBLGLFPJGBA()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return false;
			}
		}
		return base.NIJOCMMLCGG();
	}

	public virtual void LDCLHGEEOFO()
	{
		base.LEJEDFACEGP();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.OHJEIGCJCLL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.JKMEOJOHLPN(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void GOLIFONLLPC()
	{
		base.LOFMDBHAFAO();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.DBHIAKAOBDL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.FCCJJKBPNCH(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool PBLFAEMOEMG()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return false;
			}
		}
		return base.COGGIIALJOP();
	}

	public virtual void DONHNAIKMCB()
	{
		base.MGKMBCBBOHK();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.JOJEKLMOJOI(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void FJILILFMPIF()
	{
		base.OBJEMJHBJFO();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.FCCJJKBPNCH(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ONHPOAIKLAO(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void JLJMIOLJPNL()
	{
		base.KPANLOMNEIG();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.BGBBCFIBIMF(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool EELDCCKKLPA()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.KGPPDBFOGOK();
	}

	public virtual bool KPENDPGFBIG()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return true;
			}
		}
		return base.NIJOCMMLCGG();
	}

	public virtual bool FHPLCNFLHDP()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public virtual bool LMEEHJJFNBA()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return false;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public virtual void MIGAJINCHAH()
	{
		base.MGKMBCBBOHK();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.BGBBCFIBIMF(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void GBEBFIDEOHH()
	{
		base.MGKMBCBBOHK();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.FCCJJKBPNCH(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.FCCJJKBPNCH(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool PEAGALHFDMA()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.KGPPDBFOGOK();
	}

	public virtual bool KOEAFOEPJOO()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i += 0)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public override bool HFDGKLFCBLE()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return false;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public virtual void EMHGOECGAFL()
	{
		base.KPANLOMNEIG();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.OHJEIGCJCLL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ShowDialog(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool EGAPPBJGHCM()
	{
		for (int i = 0; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return true;
			}
		}
		return base.LMMGABHMGLK();
	}

	public virtual bool OJGAGBFNONM()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return true;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public virtual bool MMHIBIGJHCA()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return true;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public virtual void OCHDOJMAGHA()
	{
		base.OLECKGKLHCE();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ACAEMEEFCAH(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ShowDialog(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool AEPBHLFPGDF()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(false, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].FLFMHFIGNKE()))
			{
				return false;
			}
		}
		return base.COGGIIALJOP();
	}

	public virtual void IFDIKMKGDPG()
	{
		base.OEAJBFLGJCA();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ONHPOAIKLAO(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void ONCKKJFAMKF()
	{
		base.LOFMDBHAFAO();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.FCCJJKBPNCH(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void DCJICMIMPJE()
	{
		base.OLECKGKLHCE();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.DBHIAKAOBDL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.BGBBCFIBIMF(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public override void OBJEMJHBJFO()
	{
		base.OLECKGKLHCE();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ShowDialog(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.FCCJJKBPNCH(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public override void JPGMEFJGNNA()
	{
		base.OLECKGKLHCE();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.DBHIAKAOBDL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ShowDialog(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void DJNMPLKPENF()
	{
		base.OEAJBFLGJCA();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.DBHIAKAOBDL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.BGBBCFIBIMF(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public IODMFDDEJOP(JPMLOCNCEGO DCEBGDJMFKM)
		: base(string.Format("SpecialOfferMessage"), NKHJBLBAAEB.SpecialOfferMessage)
	{
		BLBKJJGOCDA = true;
		NHHGDIDEIMM = NHHGDIDEIMM + " " + DCEBGDJMFKM.INFLHPGMEOB;
		KAEFHCKBMGM = new JPMLOCNCEGO[1];
		KAEFHCKBMGM[0] = DCEBGDJMFKM;
	}

	public virtual void ILFJPOOMFDO()
	{
		base.KPANLOMNEIG();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ACAEMEEFCAH(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.DOLLPOPCANC(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual bool ECOIOFPKJKN()
	{
		for (int i = 1; i < KAEFHCKBMGM.Length; i++)
		{
			if (!Singleton<OfferManager>.instance.IsTextureDownloaded(true, KAEFHCKBMGM[i].MODHHKHPHOJ, KAEFHCKBMGM[i].GDIAEJILINE))
			{
				return false;
			}
		}
		return base.HFDGKLFCBLE();
	}

	public virtual void KHCMODPGHNI()
	{
		base.LEJEDFACEGP();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.DBHIAKAOBDL(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.DOLLPOPCANC(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}

	public virtual void ODDNDGAAOCH()
	{
		base.JPGMEFJGNNA();
		Singleton<BeanstalkServerManager>.instance.SendSpecialOfferShowed(KAEFHCKBMGM);
		if (BLBKJJGOCDA)
		{
			GuiElementSingle<SpecialOfferDialog>.instance.ACAEMEEFCAH(KAEFHCKBMGM);
		}
		else
		{
			GuiElementSingle<OneTimeOfferDialog>.instance.ShowDialog(DNEBFDALAFH, AIBAGMICGAE, MKPKIPHBNOL);
		}
	}
}
