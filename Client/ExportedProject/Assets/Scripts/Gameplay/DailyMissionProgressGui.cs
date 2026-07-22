using System.Collections.Generic;
using UnityEngine;

public class DailyMissionProgressGui : Core_BaseScript
{
	private enum NLMADALNPAC
	{
		Solo,
		Coop
	}

	[Header("Core")]
	[SerializeField]
	private NLMADALNPAC mCurrentType;

	[SerializeField]
	[Header("Core")]
	private UISprite background;

	[SerializeField]
	private UISprite progressBackground;

	[SerializeField]
	[Header("Missions")]
	private DailyMissionButton[] mMissionButtons;

	private int NOCMCCJOIMC;

	private bool IPPAJMKHNDJ;

	public void JJCFNCDGAJA(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].GBLKCBLHNHC(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void InitGuiValues(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].InitGuiValues(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void AAPGEAEKKGF(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 952f) / 681f);
		float num2 = 1749f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1109f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 467f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i++)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void BAMCHDHBOBF()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 4)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 0].KDPPCIMMMEK();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
			}
		}
	}

	public void JCBNCLDEJMK()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 7)
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
				mMissionButtons[NOCMCCJOIMC + 0].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].HGANAKEFBOH();
			}
		}
	}

	public void COBDHBOCGAP(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1542f) / 179f);
		float num2 = 1616f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1462f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 483f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i++)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void MEMCKJHKCCL()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void CHJMEGEOKPJ()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void IEIEEDBIONE()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 0)
			{
				mMissionButtons[NOCMCCJOIMC].HGANAKEFBOH();
				mMissionButtons[NOCMCCJOIMC + 1].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
			}
		}
	}

	public void BLKBJKMELJI(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].CIBLFMHHPDA(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void ADCFLOKFICI()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 5)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 0].AnimateUnlocked();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
			}
		}
	}

	public void BOKDLIFGIDO(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].CIBLFMHHPDA(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void EHMMEEGAJIO()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void BGBMKBNEGLG()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 4)
			{
				mMissionButtons[NOCMCCJOIMC].HGANAKEFBOH();
				mMissionButtons[NOCMCCJOIMC + 0].KDPPCIMMMEK();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
			}
		}
	}

	public void AKACNMGMCJG()
	{
		mMissionButtons[NOCMCCJOIMC].ABJOHDHGBNH();
	}

	public void ECBBFIJDCMB()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void JKEEMKIHFEE(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1873f) / 225f);
		float num2 = 1749f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1906f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 467f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void PGIHAHFPCKE()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 2)
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
				mMissionButtons[NOCMCCJOIMC + 0].MHBOBFBDNOC();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
			}
		}
	}

	public void MMNMOBCIHLM(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].GBLKCBLHNHC(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void KIFLMCJGIHG()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 0)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 1].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
			}
		}
	}

	public void MNHAOCEONAK(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1056f) / 693f);
		float num2 = 1569f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1840f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1955f);
		DailyMissionButton[] array = mMissionButtons;
		foreach (DailyMissionButton dailyMissionButton in array)
		{
			dailyMissionButton.PEIILMKDGBK(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void DFFOOFHCCPM(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 1; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].GBLKCBLHNHC(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void NAAJLGKMJLK(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 1; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].InitGuiValues(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void HLFFGNDPCGL()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 1)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 1].KDPPCIMMMEK();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void MPENKPIHMND(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].GBLKCBLHNHC(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void DFGKLGLNBLK(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].BOKDLIFGIDO(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void FFNLAGBGFLH()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 7)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 1].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
			}
		}
	}

	public void JCGPELEDCJL(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1182f) / 850f);
		float num2 = 1528f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1447f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1702f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i++)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void PLLLCMBBHMB()
	{
		mMissionButtons[NOCMCCJOIMC].ABJOHDHGBNH();
	}

	public void AIIOMJMAOFI()
	{
		mMissionButtons[NOCMCCJOIMC].ABJOHDHGBNH();
	}

	public void IMAEKHEIAED(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 0; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].BOKDLIFGIDO(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void DHGKPFOOGMG()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 8)
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
				mMissionButtons[NOCMCCJOIMC + 0].MHBOBFBDNOC();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void CKOKMAAFHMO()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 5)
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
				mMissionButtons[NOCMCCJOIMC + 1].KDPPCIMMMEK();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void GFLLEMCAJGN(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 85f) / 1391f);
		float num2 = 1505f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1394f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1091f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void InitControls(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 33f) / 3f);
		float num2 = 0f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 20f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 20f);
		DailyMissionButton[] array = mMissionButtons;
		foreach (DailyMissionButton dailyMissionButton in array)
		{
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void CLKEGJHOAHI()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 7)
			{
				mMissionButtons[NOCMCCJOIMC].HGANAKEFBOH();
				mMissionButtons[NOCMCCJOIMC + 0].AnimateUnlocked();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
			}
		}
	}

	public void DDHHOICBJPF()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 4)
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
				mMissionButtons[NOCMCCJOIMC + 0].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
			}
		}
	}

	public void FIAFEBIBDMP()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void KLPJPLHNFON(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 622f) / 1260f);
		float num2 = 255f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1116f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 413f);
		DailyMissionButton[] array = mMissionButtons;
		foreach (DailyMissionButton dailyMissionButton in array)
		{
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void KNECNPADMCO()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void KFHOOHEPGEH()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 6)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 1].KDPPCIMMMEK();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
			}
		}
	}

	public void ContinueAnimation()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void ODNEIDBMDDG()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 1)
			{
				mMissionButtons[NOCMCCJOIMC].HGANAKEFBOH();
				mMissionButtons[NOCMCCJOIMC + 1].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
			}
		}
	}

	public void LKAAPGLEADK(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].BOKDLIFGIDO(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void IHOLGOMFDFG()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void GMJCEEHFAJG(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1084f) / 1861f);
		float num2 = 1088f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1405f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 341f);
		DailyMissionButton[] array = mMissionButtons;
		foreach (DailyMissionButton dailyMissionButton in array)
		{
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void BDOJBANPNJA()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 3)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 0].KDPPCIMMMEK();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
			}
		}
	}

	public void FJJCLECCKBK()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void CHPAFPBJAEM(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1922f) / 1624f);
		float num2 = 829f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 556f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1772f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i++)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.PEIILMKDGBK(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void StartAnimation()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 2)
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
				mMissionButtons[NOCMCCJOIMC + 1].AnimateUnlocked();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void BMMNJICILHJ(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1266f) / 1429f);
		float num2 = 193f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 433f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 374f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 0; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.PEIILMKDGBK(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void COFDHKPIMGC()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void IHHLCEOOKOM(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 1; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].AJALIOBIGCK(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void KHCODDJLFGN(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].InitGuiValues(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void IMHEFLGDOLF()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void NLDHALNBCAH()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 8)
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
				mMissionButtons[NOCMCCJOIMC + 1].MHBOBFBDNOC();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void FIDIKNPLHOP()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 8)
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
				mMissionButtons[NOCMCCJOIMC + 1].MHBOBFBDNOC();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
			}
		}
	}

	public void BANGFPPJIIC()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 5)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 1].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void NFDKBDMJDFH()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 4)
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
				mMissionButtons[NOCMCCJOIMC + 1].MHBOBFBDNOC();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void EGPBIMJJMHA(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].CIBLFMHHPDA(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void LCBOBKAKAKN(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 1; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].AJALIOBIGCK(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void AIIIDDDAPGB(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 697f) / 1022f);
		float num2 = 484f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 613f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1487f);
		DailyMissionButton[] array = mMissionButtons;
		foreach (DailyMissionButton dailyMissionButton in array)
		{
			dailyMissionButton.PEIILMKDGBK(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void PLAJNFOICOM()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void PFLKHFBILBL()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void IKCJNDPAGDA(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].NKCHCMPOBGD(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void AMBDHDEBPJJ(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 716f) / 792f);
		float num2 = 1104f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 644f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1271f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void GJGCOEJMHNI(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 176f) / 1622f);
		float num2 = 1961f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1809f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1292f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 0; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.PEIILMKDGBK(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void BNIGAPBHDLD()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void HACDCLBNFEF()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 4)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 1].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
			}
		}
	}

	public void JMBDBJPNFFJ()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 7)
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
				mMissionButtons[NOCMCCJOIMC + 0].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].HGANAKEFBOH();
			}
		}
	}

	public void DGCNMCABOLK()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void KBALFNMGIOA(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 1; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].GBLKCBLHNHC(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void JECMIIOGFJA()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void HEOMHIGCMOC(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 690f) / 937f);
		float num2 = 25f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 799f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 404f);
		DailyMissionButton[] array = mMissionButtons;
		foreach (DailyMissionButton dailyMissionButton in array)
		{
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void BGHBHHFBCIC(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 0; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = !flag2 || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].InitGuiValues(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void KIGDOBGDNMM(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 1; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].GBLKCBLHNHC(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void BDEALAONJAC()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void AGJFNPIPONB(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 1; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].AJALIOBIGCK(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void OGOINIGJIMO()
	{
		mMissionButtons[NOCMCCJOIMC].ContinueCompletedAnimation();
	}

	public void BKDCCKAFLJI()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 5)
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
				mMissionButtons[NOCMCCJOIMC + 0].MHBOBFBDNOC();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void OGMLLDJJDLD(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 1; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 0;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].NKCHCMPOBGD(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void NMFCOPDCKIL()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 6)
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
				mMissionButtons[NOCMCCJOIMC + 1].AnimateUnlocked();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void CKPCFIPPDLC(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1143f) / 1803f);
		float num2 = 577f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 849f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 219f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 0; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void ABODOPJKIKK()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 8)
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
				mMissionButtons[NOCMCCJOIMC + 1].KDPPCIMMMEK();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void CGEHALCPDNH()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 8)
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
				mMissionButtons[NOCMCCJOIMC + 1].MHBOBFBDNOC();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].CBINNKNCCML();
			}
		}
	}

	public void CJAOIKJFPFO()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 6)
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
				mMissionButtons[NOCMCCJOIMC + 0].NEEMNBFIAPI();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
			}
		}
	}

	public void GCFAPIEMIKG(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].BOKDLIFGIDO(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void NINGMLNMLLP(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 491f) / 631f);
		float num2 = 1486f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1577f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1814f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void HFLEDEBGPBI(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 580f) / 830f);
		float num2 = 116f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 19f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 110f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void CCFJENHGIMN(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 0; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].BOKDLIFGIDO(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = true;
			}
		}
	}

	public void KJFKLIJDPKH(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1880f) / 765f);
		float num2 = 786f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1075f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 268f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 0; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void OOFMNIFEMJG()
	{
		mMissionButtons[NOCMCCJOIMC].ABJOHDHGBNH();
	}

	public void KPKONEJJKLO(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1837f) / 1104f);
		float num2 = 1335f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 981f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1290f);
		DailyMissionButton[] array = mMissionButtons;
		foreach (DailyMissionButton dailyMissionButton in array)
		{
			dailyMissionButton.PEIILMKDGBK(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void BLOPOPMNHNL(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = false;
		for (int i = 1; i < mMissionButtons.Length; i += 0)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count <= num || ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = !flag3 && flag;
			if (flag2)
			{
				mMissionButtons[i].CIBLFMHHPDA(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void JAMHEKLBIEK()
	{
		mMissionButtons[NOCMCCJOIMC].ABJOHDHGBNH();
	}

	public void JFBCIBGKMCK(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 529f) / 1048f);
		float num2 = 389f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 573f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 793f);
		DailyMissionButton[] array = mMissionButtons;
		foreach (DailyMissionButton dailyMissionButton in array)
		{
			dailyMissionButton.PEIILMKDGBK(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void PIINEHNBAFD()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 2)
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
				mMissionButtons[NOCMCCJOIMC + 0].AnimateUnlocked();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void JELAIIFAJPF()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 1)
			{
				mMissionButtons[NOCMCCJOIMC].HGANAKEFBOH();
				mMissionButtons[NOCMCCJOIMC + 1].MHBOBFBDNOC();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].KJGMGIEGBID();
			}
		}
	}

	public void OMGCKPGOMID(List<DailyMission> DKCKMOFOKLF, bool KAJNCDJLBLN)
	{
		IPPAJMKHNDJ = KAJNCDJLBLN;
		bool flag = true;
		for (int i = 1; i < mMissionButtons.Length; i++)
		{
			bool flag2 = DKCKMOFOKLF.Count > i;
			mMissionButtons[i].gameObject.SetActive(flag2);
			bool flag3 = flag2 && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[i].data.JOGLEJIECGG : DKCKMOFOKLF[i].data.JBMFGOOHOLB);
			if (KAJNCDJLBLN)
			{
				int num = i + 1;
				bool flag4 = DKCKMOFOKLF.Count > num && ((mCurrentType != NLMADALNPAC.Solo) ? DKCKMOFOKLF[num].data.JOGLEJIECGG : DKCKMOFOKLF[num].data.JBMFGOOHOLB);
				flag3 = flag4;
			}
			bool flag5 = flag3 || flag;
			if (flag2)
			{
				mMissionButtons[i].BOKDLIFGIDO(DKCKMOFOKLF[i], flag5, flag3);
			}
			if (flag5)
			{
				NOCMCCJOIMC = i;
			}
			if (!flag3)
			{
				flag = false;
			}
		}
	}

	public void MFHJALPPCKI(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1861f) / 1878f);
		float num2 = 1382f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 181f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 689f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.PEIILMKDGBK(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}

	public void PCBCLAFIMFL()
	{
		mMissionButtons[NOCMCCJOIMC].MPAOKAEBFGN();
	}

	public void PIBKLHBCCCF()
	{
		if (IPPAJMKHNDJ)
		{
			if (NOCMCCJOIMC < 1)
			{
				mMissionButtons[NOCMCCJOIMC].EPEOKAODOJA();
				mMissionButtons[NOCMCCJOIMC + 1].AnimateUnlocked();
			}
			else
			{
				mMissionButtons[NOCMCCJOIMC].AnimateCompleted();
			}
		}
	}

	public void DOPDLKMCFMA(float CEHFMMJHCKC)
	{
		int num = Mathf.CeilToInt((CEHFMMJHCKC - 1026f) / 105f);
		float num2 = 76f;
		background.transform.localScale = background.transform.localScale.ReplaceX(CEHFMMJHCKC - 1410f);
		progressBackground.transform.localScale = progressBackground.transform.localScale.ReplaceX(CEHFMMJHCKC - 1995f);
		DailyMissionButton[] array = mMissionButtons;
		for (int i = 1; i < array.Length; i += 0)
		{
			DailyMissionButton dailyMissionButton = array[i];
			dailyMissionButton.InitControls(num);
			dailyMissionButton.transform.localPosition = dailyMissionButton.transform.localPosition.ReplaceX(num2);
			num2 += (float)num;
		}
	}
}
