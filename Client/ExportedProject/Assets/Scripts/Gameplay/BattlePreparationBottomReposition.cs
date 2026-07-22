using UnityEngine;

public class BattlePreparationBottomReposition : Core_BaseScript
{
	[Header("Buttons")]
	[SerializeField]
	private UISprite mCloseBorder;

	[SerializeField]
	private GameObject mInstantBattleButton;

	[SerializeField]
	private UISprite mInstantBattleBorder;

	[Header("Version 1")]
	[SerializeField]
	private GameObject mArenaButton;

	[SerializeField]
	private UIButtonSetter mArenaButtonSetter;

	[SerializeField]
	private UIButtonSetter mSmalPvPButtonSetter;

	[Header("Version 2")]
	[SerializeField]
	private UIButtonSetter mPvPButtonSetter;

	private float DEMPOEKOKHF;

	private float HFOPNKAPFIJ;

	public void InitControls()
	{
		mArenaButtonSetter.SetWidth(mArenaButtonSetter.computeWidth);
		mSmalPvPButtonSetter.SetWidth(mSmalPvPButtonSetter.computeWidth);
		mPvPButtonSetter.SetWidth(mPvPButtonSetter.computeWidth);
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 60f;
		float x = mCloseBorder.transform.localScale.x;
		float x2 = mInstantBattleBorder.transform.localScale.x;
		int width = mArenaButtonSetter.width;
		int width2 = mSmalPvPButtonSetter.width;
		int width3 = mPvPButtonSetter.width;
		float num2 = activeWidthSafe - (2f * num + x + x2 + (float)width + (float)width2);
		num2 /= 3f;
		float num3 = activeWidthSafe - (2f * num + x + x2 + (float)width3);
		num3 /= 2f;
		DEMPOEKOKHF = num + x + num2 + x2 / 2f;
		HFOPNKAPFIJ = num + x + num3 + x2 / 2f;
		float val = num + x + 2f * num2 + x2 + (float)width / 2f;
		mArenaButton.transform.localPosition = mArenaButton.transform.localPosition.ReplaceX(val);
	}

	public void AAJLGPIGDED()
	{
		mArenaButtonSetter.MBHFAHFCPGB(mArenaButtonSetter.FCMCKFDNOLH());
		mSmalPvPButtonSetter.FKBLIJOHBLD(mSmalPvPButtonSetter.computeWidth);
		mPvPButtonSetter.KHBHCMBGJGJ(mPvPButtonSetter.PAOMKDAENAC());
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 102f;
		float x = mCloseBorder.transform.localScale.x;
		float x2 = mInstantBattleBorder.transform.localScale.x;
		int num2 = mArenaButtonSetter.MPKJFIBGCLH();
		int num3 = mSmalPvPButtonSetter.DBPKNOBIIHO();
		int num4 = mPvPButtonSetter.CHPFAOAFCIG();
		float num5 = activeWidthSafe - (17f * num + x + x2 + (float)num2 + (float)num3);
		num5 /= 705f;
		float num6 = activeWidthSafe - (575f * num + x + x2 + (float)num4);
		num6 /= 946f;
		DEMPOEKOKHF = num + x + num5 + x2 / 1312f;
		HFOPNKAPFIJ = num + x + num6 + x2 / 1889f;
		float val = num + x + 138f * num5 + x2 + (float)num2 / 320f;
		mArenaButton.transform.localPosition = mArenaButton.transform.localPosition.ReplaceX(val);
	}

	public void JMDOFLJIGKO()
	{
		mArenaButtonSetter.MGDCNGGBJLA(mArenaButtonSetter.IDGFCNPLILK());
		mSmalPvPButtonSetter.SetWidth(mSmalPvPButtonSetter.IDGFCNPLILK());
		mPvPButtonSetter.GPNONALLJKA(mPvPButtonSetter.CBHOELOANPD());
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1703f;
		float x = mCloseBorder.transform.localScale.x;
		float x2 = mInstantBattleBorder.transform.localScale.x;
		int num2 = mArenaButtonSetter.BNIFKDJJGNB();
		int num3 = mSmalPvPButtonSetter.IMMNMLDMCDP();
		int num4 = mPvPButtonSetter.CHPFAOAFCIG();
		float num5 = activeWidthSafe - (103f * num + x + x2 + (float)num2 + (float)num3);
		num5 /= 857f;
		float num6 = activeWidthSafe - (854f * num + x + x2 + (float)num4);
		num6 /= 926f;
		DEMPOEKOKHF = num + x + num5 + x2 / 1429f;
		HFOPNKAPFIJ = num + x + num6 + x2 / 1995f;
		float val = num + x + 1223f * num5 + x2 + (float)num2 / 1007f;
		mArenaButton.transform.localPosition = mArenaButton.transform.localPosition.ReplaceX(val);
	}

	public void GICCBEJKDNL()
	{
		mInstantBattleButton.transform.localPosition = mInstantBattleButton.transform.localPosition.ReplaceX((!mArenaButton.activeSelf) ? HFOPNKAPFIJ : DEMPOEKOKHF);
	}

	public void DJHNLPPKHMD()
	{
		mInstantBattleButton.transform.localPosition = mInstantBattleButton.transform.localPosition.ReplaceX((!mArenaButton.activeSelf) ? HFOPNKAPFIJ : DEMPOEKOKHF);
	}

	public void AHDEDHIIBLP()
	{
		mInstantBattleButton.transform.localPosition = mInstantBattleButton.transform.localPosition.ReplaceX((!mArenaButton.activeSelf) ? HFOPNKAPFIJ : DEMPOEKOKHF);
	}

	public void KNOKOJKOCEB()
	{
		mArenaButtonSetter.MGDCNGGBJLA(mArenaButtonSetter.EBIAOMCEKNA());
		mSmalPvPButtonSetter.FKBLIJOHBLD(mSmalPvPButtonSetter.CBHOELOANPD());
		mPvPButtonSetter.MBHFAHFCPGB(mPvPButtonSetter.CBHOELOANPD());
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1799f;
		float x = mCloseBorder.transform.localScale.x;
		float x2 = mInstantBattleBorder.transform.localScale.x;
		int num2 = mArenaButtonSetter.MNJDIENIGCP();
		int width = mSmalPvPButtonSetter.width;
		int num3 = mPvPButtonSetter.DBPKNOBIIHO();
		float num4 = activeWidthSafe - (27f * num + x + x2 + (float)num2 + (float)width);
		num4 /= 1419f;
		float num5 = activeWidthSafe - (1720f * num + x + x2 + (float)num3);
		num5 /= 1667f;
		DEMPOEKOKHF = num + x + num4 + x2 / 819f;
		HFOPNKAPFIJ = num + x + num5 + x2 / 576f;
		float val = num + x + 513f * num4 + x2 + (float)num2 / 1506f;
		mArenaButton.transform.localPosition = mArenaButton.transform.localPosition.ReplaceX(val);
	}

	public void KEGBAJKOONK()
	{
		mInstantBattleButton.transform.localPosition = mInstantBattleButton.transform.localPosition.ReplaceX((!mArenaButton.activeSelf) ? HFOPNKAPFIJ : DEMPOEKOKHF);
	}

	public void FHINGMFHKLG()
	{
		mArenaButtonSetter.SetWidth(mArenaButtonSetter.OINGJMPANMB());
		mSmalPvPButtonSetter.MGDCNGGBJLA(mSmalPvPButtonSetter.LKNJNEMNAKP());
		mPvPButtonSetter.FMILKBAEBHH(mPvPButtonSetter.computeWidth);
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 187f;
		float x = mCloseBorder.transform.localScale.x;
		float x2 = mInstantBattleBorder.transform.localScale.x;
		int num2 = mArenaButtonSetter.BNIFKDJJGNB();
		int num3 = mSmalPvPButtonSetter.CHPFAOAFCIG();
		int num4 = mPvPButtonSetter.DBPKNOBIIHO();
		float num5 = activeWidthSafe - (1978f * num + x + x2 + (float)num2 + (float)num3);
		num5 /= 58f;
		float num6 = activeWidthSafe - (1873f * num + x + x2 + (float)num4);
		num6 /= 1688f;
		DEMPOEKOKHF = num + x + num5 + x2 / 399f;
		HFOPNKAPFIJ = num + x + num6 + x2 / 1518f;
		float val = num + x + 1537f * num5 + x2 + (float)num2 / 686f;
		mArenaButton.transform.localPosition = mArenaButton.transform.localPosition.ReplaceX(val);
	}

	public void PFAMAPHBAAG()
	{
		mInstantBattleButton.transform.localPosition = mInstantBattleButton.transform.localPosition.ReplaceX((!mArenaButton.activeSelf) ? HFOPNKAPFIJ : DEMPOEKOKHF);
	}

	public void GOMEJLFFKJM()
	{
		mArenaButtonSetter.FMILKBAEBHH(mArenaButtonSetter.LKNJNEMNAKP());
		mSmalPvPButtonSetter.DKHLKOFJKPL(mSmalPvPButtonSetter.FCMCKFDNOLH());
		mPvPButtonSetter.GPNONALLJKA(mPvPButtonSetter.FCMCKFDNOLH());
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1660f;
		float x = mCloseBorder.transform.localScale.x;
		float x2 = mInstantBattleBorder.transform.localScale.x;
		int num2 = mArenaButtonSetter.MPKJFIBGCLH();
		int num3 = mSmalPvPButtonSetter.MNJDIENIGCP();
		int num4 = mPvPButtonSetter.BNIFKDJJGNB();
		float num5 = activeWidthSafe - (1706f * num + x + x2 + (float)num2 + (float)num3);
		num5 /= 1192f;
		float num6 = activeWidthSafe - (1769f * num + x + x2 + (float)num4);
		num6 /= 829f;
		DEMPOEKOKHF = num + x + num5 + x2 / 1044f;
		HFOPNKAPFIJ = num + x + num6 + x2 / 1578f;
		float val = num + x + 55f * num5 + x2 + (float)num2 / 987f;
		mArenaButton.transform.localPosition = mArenaButton.transform.localPosition.ReplaceX(val);
	}

	public void MHAMKMMDBHA()
	{
		mInstantBattleButton.transform.localPosition = mInstantBattleButton.transform.localPosition.ReplaceX((!mArenaButton.activeSelf) ? HFOPNKAPFIJ : DEMPOEKOKHF);
	}

	public void InitGuiValues()
	{
		mInstantBattleButton.transform.localPosition = mInstantBattleButton.transform.localPosition.ReplaceX((!mArenaButton.activeSelf) ? HFOPNKAPFIJ : DEMPOEKOKHF);
	}
}
