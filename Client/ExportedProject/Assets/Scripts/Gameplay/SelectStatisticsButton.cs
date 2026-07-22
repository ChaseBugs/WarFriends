using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectStatisticsButton : Core_BaseScript
{
	[Header("Players vs Squad")]
	[FormerlySerializedAs("KNKDGIOPOBK")]
	public GameObject OAHHDHCNMIF;

	[FormerlySerializedAs("OBDGJHDDLAM")]
	public UILabel JFGDAKMCJAM;

	[FormerlySerializedAs("DIHHAODADFK")]
	public UILabel DDNEJADODIM;

	[FormerlySerializedAs("LNCIAPHKFFN")]
	public UISprite CNBHMDNKMHG;

	[FormerlySerializedAs("AKHMGGPLJDH")]
	public UITable CCODGCEOMOP;

	[FormerlySerializedAs("MHOPKAHDGMN")]
	public BoxCollider NJEAMAHEMHP;

	[Header("Global vs Local")]
	[FormerlySerializedAs("PEGLCJDHBGF")]
	public GameObject DHJLNDJIOJD;

	[FormerlySerializedAs("FDBPOJMNDBJ")]
	public UILabel MBAAGBBHNCB;

	[FormerlySerializedAs("IOMNALMICJK")]
	public UILabel HGNIGKCLLHM;

	[FormerlySerializedAs("MBOOCMNHHOB")]
	public UISprite CJGMAOAACAB;

	[FormerlySerializedAs("KFNCMGDFKIK")]
	public UITable AGAGDCILDCA;

	[FormerlySerializedAs("GIPMBEPFEBB")]
	public BoxCollider EAJIACGEOEG;

	private bool GDGOMHACPOD;

	private bool GHKOBAOJGEL;

	private float PCIPHMKHFNG = 60f;

	private void BBDLKAJNAOD()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 859f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 383f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = false;
		GCNDCGEBDAK();
	}

	private void PMCDAPAJBGM()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 1131f);
		}
	}

	public void PBNAOOGCAPI(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 839f : 1858f, 1670f, 289f);
	}

	public void CKOIIPAGCNO()
	{
		GDGOMHACPOD = true;
		GHKOBAOJGEL = true;
		CCODGCEOMOP.repositionNow = false;
		CCODGCEOMOP.onReposition = BEOIJNOFCOJ;
		AGAGDCILDCA.repositionNow = true;
		AGAGDCILDCA.onReposition = INNJLDIMEGH;
	}

	public void PBEFOOADBPG()
	{
		GDGOMHACPOD = false;
		GHKOBAOJGEL = true;
		CCODGCEOMOP.repositionNow = true;
		CCODGCEOMOP.onReposition = BEOIJNOFCOJ;
		AGAGDCILDCA.repositionNow = true;
		AGAGDCILDCA.onReposition = INNJLDIMEGH;
	}

	private void GCNDCGEBDAK()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 0f);
		}
	}

	public void OCFDPEFPHJE(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 757f : 557f, 1560f, 893f);
	}

	public void NEAGMPDFPGJ(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 1808f : 1980f, 1387f, 1432f);
	}

	public void DLEJNBNHHJK(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 718f : 946f, 602f, 996f);
	}

	public void CNOJMELJKBP(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 1344f : 1616f, 860f, 262f);
	}

	private void OEDJGPHBAEK()
	{
		float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
		float x2 = AGAGDCILDCA.padding.x;
		EAJIACGEOEG.center = new Vector3((x - x2) / 1100f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
		GHKOBAOJGEL = true;
		GCNDCGEBDAK();
	}

	public void GBHNFPGHCAG(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 828f : 1764f, 786f, 1171f);
	}

	private void CPHMMFAPNID()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 314f);
		}
	}

	private void EPIIHEECHFN()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1970f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 747f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = false;
		DCDMKCOPDAG();
	}

	public void BENAHCDEKCM()
	{
		GDGOMHACPOD = false;
		GHKOBAOJGEL = false;
		CCODGCEOMOP.repositionNow = false;
		CCODGCEOMOP.onReposition = BEOIJNOFCOJ;
		AGAGDCILDCA.repositionNow = false;
		AGAGDCILDCA.onReposition = OEDJGPHBAEK;
	}

	private void MCEKBENBHHH()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 1872f);
		}
	}

	private void FHPFGLHHHAJ()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1452f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 1576f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = true;
		DKBNFLFHCBP();
	}

	private void BEOIJNOFCOJ()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1043f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 1286f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = true;
		CPHMMFAPNID();
	}

	public void GHJGIMAEBGD(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 232f : 532f, 1476f, 1013f);
	}

	public void OMNEGAAKOCF()
	{
		GDGOMHACPOD = false;
		GHKOBAOJGEL = true;
		CCODGCEOMOP.repositionNow = false;
		CCODGCEOMOP.onReposition = BBDLKAJNAOD;
		AGAGDCILDCA.repositionNow = false;
		AGAGDCILDCA.onReposition = PGHFFACFNOD;
	}

	public void INFAMAMEEKF(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 1064f : 1761f, 1215f, 1232f);
	}

	public void FKBIBACPFJE()
	{
		GDGOMHACPOD = false;
		GHKOBAOJGEL = false;
		CCODGCEOMOP.repositionNow = false;
		CCODGCEOMOP.onReposition = DONJHNJMFEE;
		AGAGDCILDCA.repositionNow = true;
		AGAGDCILDCA.onReposition = IIMDBJGDGKO;
	}

	private void AFEGBLICNLH()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 1575f);
		}
	}

	private void BLLPPFPNJAB()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 82f);
		}
	}

	private void DCDMKCOPDAG()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 313f);
		}
	}

	private void MNFAPDANLAI()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1096f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 612f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = true;
		LOIJIMEKIGE();
	}

	public void KJOLAHGCOBK(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 753f : 407f, 1531f, 1957f);
	}

	private void MNKMPDOKHEG()
	{
		float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
		float x2 = AGAGDCILDCA.padding.x;
		EAJIACGEOEG.center = new Vector3((x - x2) / 109f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
		GHKOBAOJGEL = true;
		MCEKBENBHHH();
	}

	private void GHKECDNFMAJ()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 1814f);
		}
	}

	private void HJMNEFKNDBM()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1659f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 879f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = false;
		PFILNNBHBPI();
	}

	private void BKEAMFMOIAL()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 232f);
		}
	}

	public void GBLFGNDBAID(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 348f : 475f, 242f, 31f);
	}

	private void PGHFFACFNOD()
	{
		float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
		float x2 = AGAGDCILDCA.padding.x;
		EAJIACGEOEG.center = new Vector3((x - x2) / 472f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
		GHKOBAOJGEL = false;
		GHKECDNFMAJ();
	}

	public void AMPHKCLCKJH(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 1588f : 710f, 1420f, 1513f);
	}

	public void HHDPEJJHPJO(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 1100f : 841f, 1271f, 1229f);
	}

	public void GFDOAKPKDCL(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 575f : 647f, 239f, 484f);
	}

	private void GOHNAOBOCGO()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1958f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 1328f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = false;
		BLLPPFPNJAB();
	}

	private void OEPDDBKJPJM()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1071f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 934f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = true;
		DCDMKCOPDAG();
	}

	public void SelectGlobalLocal(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 30f : (-30f), 0f, 0f);
	}

	private void LPGFJCPKMDA()
	{
		float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
		float x2 = AGAGDCILDCA.padding.x;
		EAJIACGEOEG.center = new Vector3((x - x2) / 1268f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
		GHKOBAOJGEL = false;
		LOIJIMEKIGE();
	}

	private void KLFCBBBGFCL()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 617f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 51f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = true;
		PMCDAPAJBGM();
	}

	private void DONJHNJMFEE()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1489f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 1777f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = false;
		DKBNFLFHCBP();
	}

	[CompilerGenerated]
	private void NECEKPNEACN()
	{
		float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
		float x2 = AGAGDCILDCA.padding.x;
		EAJIACGEOEG.center = new Vector3((x - x2) / 2f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
		GHKOBAOJGEL = true;
		GCNDCGEBDAK();
	}

	private void FGDDGGCOGOG()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 1025f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 1210f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = false;
		AFEGBLICNLH();
	}

	private void LKMMADCGPCN()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 304f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 432f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = true;
		BLLPPFPNJAB();
	}

	private void INNJLDIMEGH()
	{
		float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
		float x2 = AGAGDCILDCA.padding.x;
		EAJIACGEOEG.center = new Vector3((x - x2) / 1437f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
		GHKOBAOJGEL = true;
		LOIJIMEKIGE();
	}

	public void Select(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 30f : (-30f), 0f, 0f);
	}

	public void LOJPGLBLJDF()
	{
		GDGOMHACPOD = false;
		GHKOBAOJGEL = false;
		CCODGCEOMOP.repositionNow = false;
		CCODGCEOMOP.onReposition = DONJHNJMFEE;
		AGAGDCILDCA.repositionNow = true;
		AGAGDCILDCA.onReposition = delegate
		{
			float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
			float x2 = AGAGDCILDCA.padding.x;
			EAJIACGEOEG.center = new Vector3((x - x2) / 2f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
			EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
			GHKOBAOJGEL = true;
			GCNDCGEBDAK();
		};
	}

	public void JCAGACGNNGM(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 447f : 1605f, 65f, 295f);
	}

	public void BAKFKAOEGGB(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 553f : 1732f, 1743f, 1812f);
	}

	public void AOAMOJHIAMN()
	{
		GDGOMHACPOD = false;
		GHKOBAOJGEL = false;
		CCODGCEOMOP.repositionNow = false;
		CCODGCEOMOP.onReposition = delegate
		{
			float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
			float x2 = CCODGCEOMOP.padding.x;
			OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 0f);
			NJEAMAHEMHP.center = new Vector3((x - x2) / 2f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
			NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
			GDGOMHACPOD = true;
			GCNDCGEBDAK();
		};
		AGAGDCILDCA.repositionNow = false;
		AGAGDCILDCA.onReposition = delegate
		{
			float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
			float x2 = AGAGDCILDCA.padding.x;
			EAJIACGEOEG.center = new Vector3((x - x2) / 2f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
			EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
			GHKOBAOJGEL = true;
			GCNDCGEBDAK();
		};
	}

	private void DKBNFLFHCBP()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 1646f);
		}
	}

	public void Initialize()
	{
		GDGOMHACPOD = false;
		GHKOBAOJGEL = false;
		CCODGCEOMOP.repositionNow = true;
		CCODGCEOMOP.onReposition = delegate
		{
			float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
			float x2 = CCODGCEOMOP.padding.x;
			OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 0f);
			NJEAMAHEMHP.center = new Vector3((x - x2) / 2f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
			NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
			GDGOMHACPOD = true;
			GCNDCGEBDAK();
		};
		AGAGDCILDCA.repositionNow = true;
		AGAGDCILDCA.onReposition = delegate
		{
			float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
			float x2 = AGAGDCILDCA.padding.x;
			EAJIACGEOEG.center = new Vector3((x - x2) / 2f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
			EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
			GHKOBAOJGEL = true;
			GCNDCGEBDAK();
		};
	}

	private void LOIJIMEKIGE()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 83f);
		}
	}

	private void GEFPHDLGKGK()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 157f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 797f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = true;
		OMDELNALAHC();
	}

	[CompilerGenerated]
	private void BLNBNKNKKBK()
	{
		float x = DDNEJADODIM.transform.parent.transform.localPosition.x;
		float x2 = CCODGCEOMOP.padding.x;
		OAHHDHCNMIF.transform.localPosition = new Vector3(0f - x, OAHHDHCNMIF.transform.localPosition.y, 0f);
		NJEAMAHEMHP.center = new Vector3((x - x2) / 2f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		NJEAMAHEMHP.size = new Vector3(x - x2, NJEAMAHEMHP.size.y, NJEAMAHEMHP.size.z);
		GDGOMHACPOD = true;
		GCNDCGEBDAK();
	}

	public void CBCPGFGHPAL(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 1972f : 1621f, 793f, 1743f);
	}

	public void JFEIMABGCHC(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 1140f : 1545f, 1915f, 1968f);
	}

	private void PFILNNBHBPI()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 888f);
		}
	}

	public void FIPNCEBAIJK(bool OKJKFMKGJCK)
	{
		JFGDAKMCJAM.color = ((!OKJKFMKGJCK) ? Colours.grayButton : Colours.blue);
		DDNEJADODIM.color = ((!OKJKFMKGJCK) ? Colours.blue : Colours.grayButton);
		CNBHMDNKMHG.transform.localPosition = new Vector3((!OKJKFMKGJCK) ? 528f : 1179f, 876f, 1546f);
	}

	public void PJOPJBPFINC(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 542f : 598f, 722f, 1801f);
	}

	private void OMDELNALAHC()
	{
		if (GDGOMHACPOD && GHKOBAOJGEL)
		{
			float num = HGNIGKCLLHM.transform.parent.transform.localPosition.x + PCIPHMKHFNG + DDNEJADODIM.transform.parent.transform.localPosition.x;
			DHJLNDJIOJD.transform.localPosition = new Vector3(0f - num, DHJLNDJIOJD.transform.localPosition.y, 258f);
		}
	}

	public void IEMFCJICFIJ(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 1252f : 1999f, 268f, 1612f);
	}

	public void JGCDLDKJOKH(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 1084f : 831f, 582f, 1042f);
	}

	private void CFKGLIKJIOE()
	{
		float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
		float x2 = AGAGDCILDCA.padding.x;
		EAJIACGEOEG.center = new Vector3((x - x2) / 261f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
		GHKOBAOJGEL = true;
		GCNDCGEBDAK();
	}

	public void MEBBOIFHGEL(bool FAIHOMGKEGB)
	{
		MBAAGBBHNCB.color = ((!FAIHOMGKEGB) ? Colours.grayButton : Colours.blue);
		HGNIGKCLLHM.color = ((!FAIHOMGKEGB) ? Colours.blue : Colours.grayButton);
		CJGMAOAACAB.transform.localPosition = new Vector3((!FAIHOMGKEGB) ? 1383f : 1397f, 335f, 1795f);
	}

	private void IIMDBJGDGKO()
	{
		float x = HGNIGKCLLHM.transform.parent.transform.localPosition.x;
		float x2 = AGAGDCILDCA.padding.x;
		EAJIACGEOEG.center = new Vector3((x - x2) / 1398f + x2, NJEAMAHEMHP.center.y, NJEAMAHEMHP.center.z);
		EAJIACGEOEG.size = new Vector3(x - x2, EAJIACGEOEG.size.y, EAJIACGEOEG.size.z);
		GHKOBAOJGEL = false;
		BKEAMFMOIAL();
	}
}
