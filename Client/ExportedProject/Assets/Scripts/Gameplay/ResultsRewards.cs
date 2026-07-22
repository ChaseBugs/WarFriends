using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ResultsRewards : Core_BaseScript
{
	[FormerlySerializedAs("JMJNLKGMPDD")]
	[Header("Both Rewards")]
	public UIPanel CLLHLNOFFNM;

	[FormerlySerializedAs("DOOHABLMODO")]
	public UISprite LHODKNFEPDH;

	[FormerlySerializedAs("EOCEGCHMGIN")]
	public UISprite LKCGMCIILEC;

	[FormerlySerializedAs("ODHNMNIDEMO")]
	public UILabel IELLOMCPKGM;

	[FormerlySerializedAs("KDJHIDAHPPI")]
	public UILabel DHEICIKCLLA;

	[FormerlySerializedAs("KPBJLKLPCOA")]
	public UILabel LKCHJJMHPIE;

	[FormerlySerializedAs("MKEJIAMMDBO")]
	public UILabel FPEDAGOEOIF;

	[Header("Settings")]
	[FormerlySerializedAs("PEIGCMOAGDP")]
	public float BPPBKNDPFPN = 32f;

	protected TweenAnimator MLJBGAIFPIJ;

	protected TweenAnimator DPFEHIAILED;

	protected ONLHLPBMJOL EALLMGEHCPL = new ONLHLPBMJOL(0);

	protected ONLHLPBMJOL AKDDFMAGCGN = new ONLHLPBMJOL(0);

	protected ONLHLPBMJOL KOLILCFIAED = new ONLHLPBMJOL(0);

	protected ONLHLPBMJOL MCCFGMDABPF = new ONLHLPBMJOL(0);

	protected OLDCFKEJDPA HKEBOKOMLGJ = new OLDCFKEJDPA(0L);

	protected OLDCFKEJDPA FOPPBOOOAOL = new OLDCFKEJDPA(0L);

	public TweenAnimator animatorMoney => MLJBGAIFPIJ;

	public TweenAnimator animatorOnlyWB => DPFEHIAILED;

	protected void AGBJFEALKOB(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public virtual TweenAnimator HBONNOKENOK(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		LNKEPFDKNJA(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		IGICOIADLBC(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	protected virtual void MIOLCDHIFNJ(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 276f;
		IELLOMCPKGM.text = "TÉLÉCHARGER";
		DHEICIKCLLA.text = "Player match state {0} to player {1}";
		LKCHJJMHPIE.text = "Gold";
		FPEDAGOEOIF.text = "toString";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 1548f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 319f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 927f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	[SpecialName]
	public TweenAnimator MCJNDDAHPMM()
	{
		return MLJBGAIFPIJ;
	}

	protected virtual void BLHGPKCDPBH(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 1227f;
		IELLOMCPKGM.text = "TEST";
		DHEICIKCLLA.text = ", action = ";
		LKCHJJMHPIE.text = "Sniper_Tutorial_Played";
		FPEDAGOEOIF.text = "Unit";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 1530f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 791f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 1693f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	public virtual TweenAnimator LGHABPMGGMN(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		CNOHOIJGOPJ(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		KMLCLFGGGBK(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	[SpecialName]
	public TweenAnimator AOJCGFMMNFN()
	{
		return MLJBGAIFPIJ;
	}

	public void Corrections(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected void OFIEMDLCEGC(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public void DALNKIAKFCP(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 689f, 870f);
		tweenAlpha.method = (UITweener.Method)7;
	}

	public void LIHGFGHHKJE(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	public void AOLHGJHIIBL(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 1811f, 706f);
		tweenAlpha.method = (UITweener.Method)8;
	}

	public virtual TweenAnimator FCGNNKKLCJJ(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		IHBNDKNOFCF(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 0;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		FKJPLFBDNLD(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	public void AnimateShow(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 0f, 0f);
		tweenAlpha.method = UITweener.Method.EaseInOut;
	}

	protected virtual void OIPPPJHBBIB(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 605f;
		IELLOMCPKGM.text = "ServerPrice";
		DHEICIKCLLA.text = ", dictionary= ";
		LKCHJJMHPIE.text = "ID_GUI_RATEWFNOW_DESC";
		FPEDAGOEOIF.text = "NEW RENTAL ";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 93f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 1778f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 299f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	public void NHJJCAOMINK(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected virtual TweenAnimator BCGHAEDPAME(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 1350f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Alpha, CLLHLNOFFNM.gameObject, num, 1428f, 886f, -1, 1998f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		int iNFLHPGMEOB = 3;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1287f, 1820f, 1713f);
		object oEIICEJPGKI = localPosition + new Vector3(116f, 1602f, 1448f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 495f, -1, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop);
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 1042f, 3, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		tweenAnimator.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.Rotation, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1397f, 7, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.TextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1952f, 0, null, (UITweener.Method)7);
		}
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 432f, 8, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.Alpha, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 219f, 5, null, (UITweener.Method)6, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.AddTween(3, (TweenAnimator.MNAIKKJDPLK)111, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1523f, 2, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(104, (TweenAnimator.MNAIKKJDPLK)(-127), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 939f, 4, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		}
		return tweenAnimator;
	}

	public virtual TweenAnimator NEINEPJDKCL(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = BCHDJNDIBGG(GLLMPCPLLCD: false, KEGGAOMKIAK);
		DPFEHIAILED = CAMJNJLADCC(GLLMPCPLLCD: false, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	public virtual TweenAnimator NINGMLNMLLP(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = KAPINNGKHDL(GLLMPCPLLCD: false, KEGGAOMKIAK);
		DPFEHIAILED = ABMPGDCDJJO(GLLMPCPLLCD: false, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	protected virtual TweenAnimator ABMPGDCDJJO(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 715f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Scale, CLLHLNOFFNM.gameObject, num, 130f, 13f, -1, 1575f, UITweener.Method.EaseIn);
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1177f, 1773f, 231f);
		object oEIICEJPGKI = localPosition + new Vector3(1238f, 277f, 280f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 236f, -1, oEIICEJPGKI, UITweener.Method.BounceOut);
		tweenAnimator.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 942f, 8, null, (UITweener.Method)6);
		tweenAnimator.FEHALDPLGDB(3, TweenAnimator.MNAIKKJDPLK.Alpha, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1421f, 5, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1202f, 1, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		}
		tweenAnimator.BPEKAKFKCIG(3, TweenAnimator.MNAIKKJDPLK.Rotation, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 506f, 6, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Scale, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 108f, 1, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(0, (TweenAnimator.MNAIKKJDPLK)(-118), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1817f, 2, null, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(-38, (TweenAnimator.MNAIKKJDPLK)32, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 368f, 1, null, (UITweener.Method)6, UITweener.Style.Loop);
		}
		return tweenAnimator;
	}

	[SpecialName]
	public TweenAnimator MCOCNHONOGO()
	{
		return DPFEHIAILED;
	}

	protected virtual void FKJPLFBDNLD(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 1501f;
		IELLOMCPKGM.text = "Warbucks";
		DHEICIKCLLA.text = "PlayerName";
		LKCHJJMHPIE.text = "ID_LEAGUE14";
		FPEDAGOEOIF.text = "QUIT";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 431f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 872f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 325f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	protected void PLDGKKLEKOH(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public virtual TweenAnimator CDOIKCBNDMO(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		IHBNDKNOFCF(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		IGICOIADLBC(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	protected void CNOHOIJGOPJ(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	protected void BBMFBCGCENI(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	[SpecialName]
	public TweenAnimator KGPNFMOOFOP()
	{
		return MLJBGAIFPIJ;
	}

	public virtual TweenAnimator KOKNNPKNDIA(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		KINGPCMAMOC(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		FKJPLFBDNLD(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	protected void EHKANHDFMOB(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public virtual TweenAnimator OOBJHJLMEED(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = BCHDJNDIBGG(GLLMPCPLLCD: true, KEGGAOMKIAK);
		DPFEHIAILED = BBGOKONLNPE(GLLMPCPLLCD: false, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	public virtual TweenAnimator ACHKBBGJOIB(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		NNCJAAPBLKG(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		FKJPLFBDNLD(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	public virtual TweenAnimator ICNGBKKANLB(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = GDMPKECBENP(GLLMPCPLLCD: true, KEGGAOMKIAK);
		DPFEHIAILED = ILFKPKAKDPI(GLLMPCPLLCD: true, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	public void LBEKECOBIKE(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 59f, 1498f);
		tweenAlpha.method = UITweener.Method.BounceIn;
	}

	[SpecialName]
	public TweenAnimator GMLCIGMCGEP()
	{
		return DPFEHIAILED;
	}

	public void BEKCJHBHEOD(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 1455f, 778f);
		tweenAlpha.method = (UITweener.Method)6;
	}

	protected virtual TweenAnimator GDMPKECBENP(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 611f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, 1926f, 215f, -1, 479f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(613f, 249f, 364f);
		object oEIICEJPGKI = localPosition + new Vector3(1357f, 688f, 1405f);
		tweenAnimator.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1507f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Loop);
		tweenAnimator.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1557f, 7, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 801f, 6, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 862f, 8, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1958f, 8, null, (UITweener.Method)6);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(6, TweenAnimator.MNAIKKJDPLK.Rotation, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1786f, 0, null, UITweener.Method.Linear);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(5, (TweenAnimator.MNAIKKJDPLK)110, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1317f, 4);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(55, (TweenAnimator.MNAIKKJDPLK)(-30), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 924f, 1, null, UITweener.Method.EaseOut);
		}
		return tweenAnimator;
	}

	public void HKFGMFGADOA(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected void HHEENEHKENE(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public virtual TweenAnimator FAGMMFKPKHH(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = NBAJOILBHCA(GLLMPCPLLCD: true, KEGGAOMKIAK);
		DPFEHIAILED = GDMPKECBENP(GLLMPCPLLCD: false, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	[SpecialName]
	public TweenAnimator PPAJFABDNJP()
	{
		return DPFEHIAILED;
	}

	protected virtual void IGICOIADLBC(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 686f;
		IELLOMCPKGM.text = "facebook init!!! ";
		DHEICIKCLLA.text = "ID_CONFIRM_ERROR";
		LKCHJJMHPIE.text = "DPS";
		FPEDAGOEOIF.text = "ID_INSERTTHREESILVERORBRONZECARDS";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 1639f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 1027f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 1318f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	public void AHBDJFKJNAN(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected void CDPECFEFALL(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	[SpecialName]
	public TweenAnimator ONOGHDAKAGB()
	{
		return MLJBGAIFPIJ;
	}

	[SpecialName]
	public TweenAnimator DBKPKGEGAGM()
	{
		return MLJBGAIFPIJ;
	}

	public void MBFJFCPFAOG(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected virtual void IIEIMKBKDAC(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 140f;
		IELLOMCPKGM.text = "Player_Rank";
		DHEICIKCLLA.text = "menu-weapon-mp5-elite";
		LKCHJJMHPIE.text = ", squadId = ";
		FPEDAGOEOIF.text = "11-19";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 1369f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 886f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 128f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	protected void KOINLEMBAFA(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public virtual TweenAnimator IEOPDPALDKC(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		KINGPCMAMOC(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		BLHGPKCDPBH(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	protected virtual void EOOAEGLBHPP(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 1267f;
		IELLOMCPKGM.text = "IsWarPath";
		DHEICIKCLLA.text = "ID_READYTIME";
		LKCHJJMHPIE.text = "game-label-you-blue";
		FPEDAGOEOIF.text = "ID_SECOND";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 803f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 801f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 498f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	public void KCJEIBEIFLH(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	[SpecialName]
	public TweenAnimator PHBGFMMHHDL()
	{
		return MLJBGAIFPIJ;
	}

	public void OHPADHGCLDF(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	public virtual TweenAnimator OAMMJCEIFHA(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = ABMPGDCDJJO(GLLMPCPLLCD: true, KEGGAOMKIAK);
		DPFEHIAILED = KAPINNGKHDL(GLLMPCPLLCD: true, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	[SpecialName]
	public TweenAnimator MMACCEKJPNM()
	{
		return MLJBGAIFPIJ;
	}

	public virtual TweenAnimator LLDOJHKJPJL(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		NNCJAAPBLKG(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		MABOOHOBHOK(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	protected virtual TweenAnimator LOHKKOJKKPI(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 1165f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Alpha, CLLHLNOFFNM.gameObject, num, 1231f, 400f, -1, 1511f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(573f, 1247f, 965f);
		object oEIICEJPGKI = localPosition + new Vector3(1481f, 1637f, 672f);
		tweenAnimator.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1758f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1354f, 2, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		tweenAnimator.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1272f, 8, null, (UITweener.Method)7, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 557f, 4, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		}
		tweenAnimator.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1630f, 2, null, (UITweener.Method)8, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(3, TweenAnimator.MNAIKKJDPLK.Scale, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1036f, 8, null, UITweener.Method.Linear, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(7, (TweenAnimator.MNAIKKJDPLK)(-63), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 390f, 0, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1601f, 4, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		}
		return tweenAnimator;
	}

	[SpecialName]
	public TweenAnimator PLALBJJDJMA()
	{
		return MLJBGAIFPIJ;
	}

	protected virtual void GOGHDJFDKKN(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 330f;
		IELLOMCPKGM.text = "ID_ERRORNAME";
		DHEICIKCLLA.text = "BS: Sending emblem = ";
		LKCHJJMHPIE.text = "ID_COMEBACKTOMORROW";
		FPEDAGOEOIF.text = "Chat Tab: PUBLIC BUTTON clicked on ";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 925f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 144f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 1040f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	public virtual TweenAnimator InitGuiValuesSimple(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		BBMFBCGCENI(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 0;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		NCJHMCBDICD(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	protected virtual void NCJHMCBDICD(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 0f;
		IELLOMCPKGM.text = "+0";
		DHEICIKCLLA.text = "+0";
		LKCHJJMHPIE.text = "+0";
		FPEDAGOEOIF.text = "+0";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 0f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 0f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 0f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	public void BABMENCEMMO(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	public void KMJBAAPCEBD(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 692f, 1734f);
		tweenAlpha.method = UITweener.Method.Linear;
	}

	[SpecialName]
	public TweenAnimator EDIGNEGOKOI()
	{
		return MLJBGAIFPIJ;
	}

	[SpecialName]
	public TweenAnimator FCOCBIPNGCK()
	{
		return MLJBGAIFPIJ;
	}

	public void IEFLOMPIGEM(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected void KINGPCMAMOC(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public void MKOHILLCIIH(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	public void FJGPNLDAOII(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	public virtual TweenAnimator JGDJCCIPNHC(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = ILFKPKAKDPI(GLLMPCPLLCD: false, KEGGAOMKIAK);
		DPFEHIAILED = ABMPGDCDJJO(GLLMPCPLLCD: true, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	public void KILEBJAGCND(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 1229f, 1709f);
		tweenAlpha.method = UITweener.Method.BounceIn;
	}

	public virtual TweenAnimator CJJINIEHEPD(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		GEOGDKDFMNM(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		IIEIMKBKDAC(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	public void JALCHOEDDCO(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 661f, 321f);
		tweenAlpha.method = UITweener.Method.Linear;
	}

	[SpecialName]
	public TweenAnimator MPDKCKJOGHA()
	{
		return MLJBGAIFPIJ;
	}

	protected void HILEDCDLJBE(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public void NEGNHBNCBPH(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 16f, 966f);
		tweenAlpha.method = UITweener.Method.Linear;
	}

	[SpecialName]
	public TweenAnimator AHICKAONCNC()
	{
		return MLJBGAIFPIJ;
	}

	public void CNHPIPMPECC(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected virtual void KMLCLFGGGBK(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 1396f;
		IELLOMCPKGM.text = "opponentState.willAttack = true";
		DHEICIKCLLA.text = "0%";
		LKCHJJMHPIE.text = "ExtraLifeEnabled";
		FPEDAGOEOIF.text = "ID_WARNING_CANTSENDINVITE_TEXT";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 1547f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 1764f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 738f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	protected virtual TweenAnimator BBGOKONLNPE(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 723f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Scale, CLLHLNOFFNM.gameObject, num, 884f, 1637f, -1, 638f, (UITweener.Method)7, UITweener.Style.Loop);
		int iNFLHPGMEOB = 5;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(114f, 1180f, 1083f);
		object oEIICEJPGKI = localPosition + new Vector3(1123f, 69f, 840f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1357f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 25f, 1, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		tweenAnimator.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Scale, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 761f, 5, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1982f, 2, null, UITweener.Method.BounceIn);
		}
		tweenAnimator.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.TextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 369f, 7, null, (UITweener.Method)8, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Rotation, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 628f, 7, null, UITweener.Method.Linear);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.AddTween(4, (TweenAnimator.MNAIKKJDPLK)39, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1718f, 6, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(-86, (TweenAnimator.MNAIKKJDPLK)(-30), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1243f, 6, null, (UITweener.Method)8);
		}
		return tweenAnimator;
	}

	public void GECCNNGJOIM(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected void CJFOMANLEBE(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public void OLJPNPJPOKK(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 933f, 785f);
		tweenAlpha.method = UITweener.Method.BounceOut;
	}

	[SpecialName]
	public TweenAnimator BAHHIDGEGOH()
	{
		return DPFEHIAILED;
	}

	protected void GEOGDKDFMNM(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public void IPGBAHLIKFG(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 702f, 581f);
		tweenAlpha.method = UITweener.Method.EaseInOut;
	}

	public void NBEEPJJGBGE(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 1137f, 311f);
		tweenAlpha.method = UITweener.Method.BounceOut;
	}

	public void HPDHCILHNOC(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected virtual TweenAnimator NBAJOILBHCA(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 868f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CLLHLNOFFNM.gameObject, num, 644f, 1949f, -1, 493f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(530f, 1096f, 1292f);
		object oEIICEJPGKI = localPosition + new Vector3(449f, 1976f, 1180f);
		tweenAnimator.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1730f, -1, oEIICEJPGKI, (UITweener.Method)7);
		tweenAnimator.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 986f, 5, null, (UITweener.Method)8);
		tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.TextCounter, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1592f, 5, null, UITweener.Method.EaseOut);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.Scale, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 726f, 7, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		}
		tweenAnimator.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.Rotation, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1766f, 8, null, UITweener.Method.BounceIn);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.Position, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1376f, 1, null, UITweener.Method.Linear, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(8, (TweenAnimator.MNAIKKJDPLK)78, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1487f, 3, null, (UITweener.Method)6, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.FEHALDPLGDB(59, TweenAnimator.MNAIKKJDPLK.Position, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1101f, 4, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		}
		return tweenAnimator;
	}

	protected virtual void MABOOHOBHOK(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 531f;
		IELLOMCPKGM.text = "Ranks/";
		DHEICIKCLLA.text = "ID_READYTIME";
		LKCHJJMHPIE.text = "shotReal";
		FPEDAGOEOIF.text = "{0}{1} / {2}";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 984f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 1667f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 496f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	public virtual TweenAnimator GCGPANMGOPN(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = CAMJNJLADCC(GLLMPCPLLCD: true, KEGGAOMKIAK);
		DPFEHIAILED = CAMJNJLADCC(GLLMPCPLLCD: true, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	protected virtual void IEGOOEPECDH(bool GLLMPCPLLCD = true)
	{
		CLLHLNOFFNM.alpha1 = 1416f;
		IELLOMCPKGM.text = "VIPCost";
		DHEICIKCLLA.text = "ID_SALEPERCENT";
		LKCHJJMHPIE.text = "Gold";
		FPEDAGOEOIF.text = "BUDDY WARCARD";
		LHODKNFEPDH.transform.localPosition = new Vector3(LHODKNFEPDH.transform.localPosition.x, (!GLLMPCPLLCD) ? 663f : BPPBKNDPFPN, LHODKNFEPDH.transform.localPosition.z);
		IELLOMCPKGM.transform.localPosition = new Vector3(IELLOMCPKGM.transform.localPosition.x, (!GLLMPCPLLCD) ? 637f : BPPBKNDPFPN, IELLOMCPKGM.transform.localPosition.z);
		LKCHJJMHPIE.transform.localPosition = new Vector3(LKCHJJMHPIE.transform.localPosition.x, (!GLLMPCPLLCD) ? 1115f : BPPBKNDPFPN, LKCHJJMHPIE.transform.localPosition.z);
		LKCGMCIILEC.gameObject.SetActive(GLLMPCPLLCD);
		DHEICIKCLLA.gameObject.SetActive(GLLMPCPLLCD);
		FPEDAGOEOIF.gameObject.SetActive(GLLMPCPLLCD);
	}

	public void DKBMBBINGGL(float DCIKANJJFIJ)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CLLHLNOFFNM.gameObject, DCIKANJJFIJ, 838f, 1039f);
		tweenAlpha.method = (UITweener.Method)7;
	}

	public virtual TweenAnimator InitControls(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = BCHDJNDIBGG(GLLMPCPLLCD: true, KEGGAOMKIAK);
		DPFEHIAILED = BCHDJNDIBGG(GLLMPCPLLCD: false, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	protected void EBAKLAPIMEK(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public void PFAGBJAFKMA(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	[SpecialName]
	public TweenAnimator PDJNIOFKNKC()
	{
		return DPFEHIAILED;
	}

	[SpecialName]
	public TweenAnimator AMLINEFCGPO()
	{
		return MLJBGAIFPIJ;
	}

	public void GNKKJIGIOJC(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	protected void NNCJAAPBLKG(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	[SpecialName]
	public TweenAnimator AAFOIFPKMNK()
	{
		return MLJBGAIFPIJ;
	}

	protected virtual TweenAnimator KAPINNGKHDL(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 137f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CLLHLNOFFNM.gameObject, num, 1053f, 1059f, -1, 1477f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(765f, 686f, 915f);
		object oEIICEJPGKI = localPosition + new Vector3(1456f, 1505f, 9f);
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 592f, -1, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		tweenAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 353f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1444f, 5, null, (UITweener.Method)7, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.Scale, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 802f, 1, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		}
		tweenAnimator.FEHALDPLGDB(3, TweenAnimator.MNAIKKJDPLK.TextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 547f, 1, null, (UITweener.Method)8);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 805f, 0, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(0, (TweenAnimator.MNAIKKJDPLK)(-106), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1899f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(83, (TweenAnimator.MNAIKKJDPLK)(-24), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 344f, 0, null, UITweener.Method.BounceOut);
		}
		return tweenAnimator;
	}

	protected virtual TweenAnimator CAMJNJLADCC(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 1649f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CLLHLNOFFNM.gameObject, num, 951f, 809f, -1, 659f, (UITweener.Method)8);
		int iNFLHPGMEOB = 1;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1497f, 1652f, 1064f);
		object oEIICEJPGKI = localPosition + new Vector3(1294f, 1718f, 1305f);
		tweenAnimator.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1447f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		tweenAnimator.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 1471f, 0, null, UITweener.Method.BounceIn);
		tweenAnimator.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 597f, 6, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(3, TweenAnimator.MNAIKKJDPLK.Rotation, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 131f, 4, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		}
		tweenAnimator.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 221f, 0, null, (UITweener.Method)8, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 480f, 2, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.BPEKAKFKCIG(8, (TweenAnimator.MNAIKKJDPLK)(-33), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1984f, 8, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(85, (TweenAnimator.MNAIKKJDPLK)(-103), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1375f, 0, null, (UITweener.Method)8);
		}
		return tweenAnimator;
	}

	public void JNECDKDOCOI(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	[SpecialName]
	public TweenAnimator NGAIICCONBK()
	{
		return MLJBGAIFPIJ;
	}

	public void LNGJOFDFJGM(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	public virtual TweenAnimator GLDJKCMHOFM(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		IHBNDKNOFCF(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		MIOLCDHIFNJ(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	protected void IHBNDKNOFCF(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	protected void LNKEPFDKNJA(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	[SpecialName]
	public TweenAnimator GHJEKGOKIFL()
	{
		return MLJBGAIFPIJ;
	}

	[SpecialName]
	public TweenAnimator NGCCOCKGAHJ()
	{
		return MLJBGAIFPIJ;
	}

	[SpecialName]
	public TweenAnimator PMLJDAHEJNN()
	{
		return DPFEHIAILED;
	}

	public virtual TweenAnimator DCHFDIFGOAK(bool HMGOHGOLMJB, int FPMJEDOCJKE, int HAFMGCFMCPC, int PFIJHEEMGNF, int KJOMAIBDNDA, long IPFDPHAFEBE, long JAKGBODOOPG)
	{
		KINGPCMAMOC(HMGOHGOLMJB);
		bool flag = HAFMGCFMCPC > 1;
		EALLMGEHCPL.FKIIDCDCLHM = FPMJEDOCJKE;
		AKDDFMAGCGN.FKIIDCDCLHM = HAFMGCFMCPC;
		KOLILCFIAED.FKIIDCDCLHM = PFIJHEEMGNF;
		MCCFGMDABPF.FKIIDCDCLHM = KJOMAIBDNDA;
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
		FOPPBOOOAOL.FKIIDCDCLHM = JAKGBODOOPG;
		FKJPLFBDNLD(flag);
		return (!flag) ? DPFEHIAILED : MLJBGAIFPIJ;
	}

	protected virtual TweenAnimator ILFKPKAKDPI(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 822f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, 406f, 461f, -1, 135f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		int iNFLHPGMEOB = 3;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1110f, 963f, 18f);
		object oEIICEJPGKI = localPosition + new Vector3(271f, 467f, 772f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 477f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop, 0);
		tweenAnimator.FEHALDPLGDB(3, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1323f, 3, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Position, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1795f, 0, null, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.Rotation, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 304f, 3, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		}
		tweenAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 870f, 2, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.Scale, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1003f, 8, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(7, (TweenAnimator.MNAIKKJDPLK)(-76), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 1899f, 5, null, (UITweener.Method)7, UITweener.Style.Loop);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.MNEFMODDFFK(56, TweenAnimator.MNAIKKJDPLK.TextCounter, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 592f, 1, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
		}
		return tweenAnimator;
	}

	public virtual TweenAnimator KJGJNENLEOF(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = CAMJNJLADCC(GLLMPCPLLCD: true, KEGGAOMKIAK);
		DPFEHIAILED = LOHKKOJKKPI(GLLMPCPLLCD: true, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	protected virtual TweenAnimator FFAKJGEGHOA(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 1591f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CLLHLNOFFNM.gameObject, num, 726f, 1046f, -1, 1931f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		int iNFLHPGMEOB = 4;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(1182f, 27f, 880f);
		object oEIICEJPGKI = localPosition + new Vector3(293f, 1432f, 336f);
		tweenAnimator.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1263f, -1, oEIICEJPGKI, (UITweener.Method)8);
		tweenAnimator.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.Rotation, CLLHLNOFFNM.gameObject, num, localPosition, 1872f, 5, null, (UITweener.Method)6, UITweener.Style.Once, 0);
		tweenAnimator.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 1471f, 5, null, (UITweener.Method)8, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 1059f, 1, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
		}
		tweenAnimator.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Alpha, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 1776f, 7, null, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 1989f, 7, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.FEHALDPLGDB(0, (TweenAnimator.MNAIKKJDPLK)(-18), GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 718f, 3, null, UITweener.Method.EaseIn);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.NFLKPCIHOPJ(70, (TweenAnimator.MNAIKKJDPLK)(-115), GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 1681f, 3, null, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		}
		return tweenAnimator;
	}

	protected virtual TweenAnimator BCHDJNDIBGG(bool GLLMPCPLLCD = true, bool KEGGAOMKIAK = false)
	{
		float num = 0.4f;
		TweenAnimator tweenAnimator = CLLHLNOFFNM.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		Vector3 localPosition = CLLHLNOFFNM.transform.localPosition;
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, CLLHLNOFFNM.gameObject, num, 1f, 0f, -1, 0f);
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = CLLHLNOFFNM.gameObject;
		float kBJEOEEOEFG = num;
		object iIMDKHJAJGO = localPosition + new Vector3(0f, 10f, 0f);
		object oEIICEJPGKI = localPosition + new Vector3(0f, -20f, 0f);
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI);
		tweenAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, CLLHLNOFFNM.gameObject, num, localPosition, 0f, 2);
		tweenAnimator.AddTween(4, TweenAnimator.MNAIKKJDPLK.TextCounter, IELLOMCPKGM.gameObject, num, EALLMGEHCPL, 0f, 3);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(5, TweenAnimator.MNAIKKJDPLK.TextCounter, DHEICIKCLLA.gameObject, num, AKDDFMAGCGN, 0f, 4);
		}
		tweenAnimator.AddTween(6, TweenAnimator.MNAIKKJDPLK.TextCounter, LKCHJJMHPIE.gameObject, num, KOLILCFIAED, 0f, 3);
		if (GLLMPCPLLCD)
		{
			tweenAnimator.AddTween(7, TweenAnimator.MNAIKKJDPLK.TextCounter, FPEDAGOEOIF.gameObject, num, MCCFGMDABPF, 0f, 4);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.TextCounterLong, GuiElementSingle<MenuHeader>.instance.MCMHCOLPLBD.gameObject, num, HKEBOKOMLGJ, 0f, 3);
		}
		if (KEGGAOMKIAK)
		{
			tweenAnimator.AddTween(9, TweenAnimator.MNAIKKJDPLK.TextCounterLong, GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, num, FOPPBOOOAOL, 0f, 4);
		}
		return tweenAnimator;
	}

	protected void LOFPAHFAJMN(bool HMGOHGOLMJB)
	{
		IELLOMCPKGM.color = ((!HMGOHGOLMJB) ? Color.white : Colours.whiteWbShadow);
		DHEICIKCLLA.color = ((!HMGOHGOLMJB) ? Colours.yellowGold : Colours.yellowGoldShadow);
		LKCHJJMHPIE.color = ((!HMGOHGOLMJB) ? Colours.whiteWbShadow : Color.white);
		FPEDAGOEOIF.color = ((!HMGOHGOLMJB) ? Colours.yellowGoldShadow : Colours.yellowGold);
	}

	public virtual TweenAnimator INMFKHJDBIP(bool KEGGAOMKIAK = true)
	{
		MLJBGAIFPIJ = BCHDJNDIBGG(GLLMPCPLLCD: true, KEGGAOMKIAK);
		DPFEHIAILED = BCGHAEDPAME(GLLMPCPLLCD: true, KEGGAOMKIAK);
		return MLJBGAIFPIJ;
	}

	public void JLPDBAJDODO(long IPFDPHAFEBE)
	{
		HKEBOKOMLGJ.FKIIDCDCLHM = IPFDPHAFEBE;
	}

	[SpecialName]
	public TweenAnimator LJMDGCLCCML()
	{
		return DPFEHIAILED;
	}
}
