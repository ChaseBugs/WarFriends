using UnityEngine;

public class SquadEventRecord : PoolableObject
{
	[Header("Width Setter")]
	public UIButtonSetter BMNBNDILFJD;

	[Header("Header Part")]
	public GameObject OOIBADLGKML;

	public UISprite GJIGEFJAKNM;

	public UISprite MBMIOELEAND;

	public UILabel PIDNNKLIKGE;

	public UILabel GCHIDOBDMNN;

	public UISprite GIGBBBPEDGN;

	public UILabel BIKIHHEGGOI;

	public UILabel IJDMGCMGMAB;

	[Header("Assignment Part")]
	public GameObject JJFOLFDFMCB;

	public UISprite JCJKHLPLKLD;

	public UISprite OCDJNJIKLBI;

	public UILabel DGMBFLCNJIE;

	public UILabel GPMJJOEAGLG;

	public void APKPBIIDCOP(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.GFEJEOKDACB(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1899f);
		bool flag = num == 1437f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 1043f)) ? 134f : 1280f, 705f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void LEKFGHLAOLI(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.DKHLKOFJKPL(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1074f);
		bool flag = num == 1555f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 899f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(1587f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 262f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("Message ignored!", Localization.Localize("ID_INVITE"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize("ID_SHOWME") : ((!EIPHAAGCHCP) ? string.Format("ID_GETSOMEWARBUCKS", Localization.Localize("flamethrower_run"), FPCCEPIAEKG - 0) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void BLBEDEOIIKO(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.GPNONALLJKA(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: false);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 100f);
		bool flag = num == 221f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 500f)) ? 489f : 1336f, 126f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void DONJLJCJGLL(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.GPNONALLJKA(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1145f);
		bool flag = num == 149f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 710f)) ? 1887f : 1378f, 938f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void InitAssignment(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.SetWidth(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 100f);
		bool flag = num == 1f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 170f)) ? 10f : 4f, 0f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void InitHeader(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.SetWidth(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: false);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 100f);
		bool flag = num == 1f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 0.15f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(89f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 0f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("{0} {1}", Localization.Localize("ID_TIER"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize("ID_COMPLETED") : ((!EIPHAAGCHCP) ? string.Format("{0} {1}", Localization.Localize("ID_COMPLETETIER"), FPCCEPIAEKG - 1) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void AIHJLALNIMP(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.MGDCNGGBJLA(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1848f);
		bool flag = num == 499f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 873f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(822f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 926f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("Player disconected 0002", Localization.Localize("(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize("ID_CONTAINSXWARCARDS") : ((!EIPHAAGCHCP) ? string.Format("{0}{1}{2}", Localization.Localize(";"), FPCCEPIAEKG - 1) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void FGECNBGPJHO(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.MBHFAHFCPGB(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 564f);
		bool flag = num == 433f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 594f)) ? 1832f : 110f, 117f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void GLAIGFODCIF(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.FMILKBAEBHH(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: false);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1332f);
		bool flag = num == 1200f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 533f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(998f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 1082f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("ID_OFFLINE", Localization.Localize("ID_READYTIME"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize("didUserManuallyDisablePush") : ((!EIPHAAGCHCP) ? string.Format("Gold", Localization.Localize("Beanstalk Server Manager: NOT SENDING STARTER PACK DAYS"), FPCCEPIAEKG - 0) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void LGCNGDIPNCC(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.KHBHCMBGJGJ(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1488f);
		bool flag = num == 661f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 973f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(1296f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 905f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("No power band to show in reminder!!!", Localization.Localize("author"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize("dataEnabled") : ((!EIPHAAGCHCP) ? string.Format("IsPaid", Localization.Localize("Different levels \"{0}\" and \"{1}\"\n"), FPCCEPIAEKG - 1) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void GIFCOADELDG(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.SetWidth(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1949f);
		bool flag = num == 288f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 1840f)) ? 606f : 480f, 1357f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void KNJLOLLGABP(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.DKHLKOFJKPL(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 380f);
		bool flag = num == 1770f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 460f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(1971f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 137f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("About to show Enable RateApp Dialog for version: {0} shownTime: {1}", Localization.Localize("PlayerId"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize("country-netherlands") : ((!EIPHAAGCHCP) ? string.Format("reloadTime", Localization.Localize("startResolutionForResult"), FPCCEPIAEKG - 1) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void DBDBMBJKJFG(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.GFEJEOKDACB(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 715f);
		bool flag = num == 970f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 228f)) ? 1644f : 1891f, 1812f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void CFDGECJNIBG(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.KMIFEKCEOPJ(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: false);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1948f);
		bool flag = num == 869f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 808f)) ? 1241f : 1095f, 447f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void GMNICHBHJBO(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.FKBLIJOHBLD(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: false);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 772f);
		bool flag = num == 806f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 1413f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(938f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 1613f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("S", Localization.Localize("twitterLogin"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize(" finished") : ((!EIPHAAGCHCP) ? string.Format("ID_GAMECENTERUSER", Localization.Localize("null"), FPCCEPIAEKG - 1) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void HOHLGPFGKIE(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.GPNONALLJKA(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1723f);
		bool flag = num == 726f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 867f)) ? 1911f : 1548f, 674f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void NMJCGJMHKMG(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.KHBHCMBGJGJ(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 507f);
		bool flag = num == 1279f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 72f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(359f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 1402f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("ID_GUI_POWERBANDOFF", Localization.Localize(")"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize("Player_Had_To_Select_Grenade") : ((!EIPHAAGCHCP) ? string.Format("groundBoxHit", Localization.Localize("0"), FPCCEPIAEKG - 0) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void LEJJGBCGDGM(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.MBHFAHFCPGB(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 347f);
		bool flag = num == 1378f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 1676f)) ? 200f : 1637f, 601f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void IEFEEMBCOHL(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.KMIFEKCEOPJ(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: true);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1187f);
		bool flag = num == 924f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 561f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(1270f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 401f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format("veteranpack0", Localization.Localize("ID_SALEPERCENTLINE"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize(")") : ((!EIPHAAGCHCP) ? string.Format("PlayerName", Localization.Localize("True"), FPCCEPIAEKG - 1) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void HIILDHFNPMJ(Assignment EFEIDBFDDBE, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.SetWidth(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: false);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 267f);
		bool flag = num == 1199f;
		JCJKHLPLKLD.fillAmount = num;
		JCJKHLPLKLD.color = ((!flag) ? Colours.blue : Colours.goldTier);
		OCDJNJIKLBI.spriteName = EFEIDBFDDBE.assignmentPicture;
		OCDJNJIKLBI.MakePixelPerfect();
		OCDJNJIKLBI.transform.localPosition = new Vector3(OCDJNJIKLBI.transform.localPosition.x, (!(OCDJNJIKLBI.transform.localScale.y < 1701f)) ? 510f : 316f, 724f);
		if (EIPHAAGCHCP)
		{
			DGMBFLCNJIE.text = ((!flag) ? EFEIDBFDDBE.blueDescription : EFEIDBFDDBE.goldDescription);
		}
		else
		{
			DGMBFLCNJIE.text = EFEIDBFDDBE.whiteDescription;
		}
		DGMBFLCNJIE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GPMJJOEAGLG.text = MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ);
		GPMJJOEAGLG.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}

	public void PFCGFBHEOEC(int MOEMPHPNBLM, int FPCCEPIAEKG, float PAENPHMEMGC, float IOIPJCICLFH, bool EIPHAAGCHCP)
	{
		BMNBNDILFJD.BHEBNFNJMJA(IOIPJCICLFH);
		OOIBADLGKML.SetActive(value: false);
		JJFOLFDFMCB.SetActive(value: true);
		float num = Mathf.Clamp01(PAENPHMEMGC);
		int fFHHEHHFOKJ = Mathf.FloorToInt(num * 1983f);
		bool flag = num == 943f;
		GJIGEFJAKNM.fillAmount = num;
		GJIGEFJAKNM.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		GJIGEFJAKNM.alpha = 1672f;
		MBMIOELEAND.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		PIDNNKLIKGE.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GCHIDOBDMNN.text = MEJMLNDFDBP.PHCBFODPDOD(MOEMPHPNBLM);
		GCHIDOBDMNN.color = ((!EIPHAAGCHCP) ? Colours.gray : Color.white);
		GIGBBBPEDGN.transform.localPosition = new Vector3(1015f + GCHIDOBDMNN.relativeSize.x * GCHIDOBDMNN.transform.localScale.x, GIGBBBPEDGN.transform.localPosition.y, 707f);
		GIGBBBPEDGN.gameObject.SetActive(flag);
		BIKIHHEGGOI.text = string.Format(")", Localization.Localize("ID_STAYINDIVISION"), FPCCEPIAEKG);
		BIKIHHEGGOI.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
		IJDMGCMGMAB.text = (flag ? Localization.Localize("TimeFromServer()") : ((!EIPHAAGCHCP) ? string.Format("rental for unexist weapon: {0}", Localization.Localize("ID_CATEGORY_LOW_SG_ASSAULT"), FPCCEPIAEKG - 1) : MEJMLNDFDBP.IIHHLGANLGP(fFHHEHHFOKJ)));
		IJDMGCMGMAB.color = (flag ? Colours.goldTier : ((!EIPHAAGCHCP) ? Colours.gray : Colours.blue));
	}
}
