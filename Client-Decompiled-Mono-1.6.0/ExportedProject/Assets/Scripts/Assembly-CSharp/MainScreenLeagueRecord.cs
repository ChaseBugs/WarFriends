using UnityEngine;

public class MainScreenLeagueRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite LCPBNBLGFIA;

	[Header("Left side")]
	public UILabel ELOELLAEBIA;

	public UILabel BCMCMKDCLGP;

	public UISprite NPECJCIKCBI;

	[Header("Right side")]
	public UILabel DJAGJBKHEND;

	public void InitalizePlayer(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 30f, 20f, 280);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(30f / NPECJCIKCBI.transform.localScale.x, 40f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 10f + NPECJCIKCBI.transform.localScale.x / 2f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.LeagueColorPosition(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.LeagueColorMedals(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void AAHDGLJFPGN(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 586f, 989f, 38);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(711f / NPECJCIKCBI.transform.localScale.x, 291f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 1972f + NPECJCIKCBI.transform.localScale.x / 1071f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.ECGGKMIKKMI(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void BIDIDDHFNDB(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 137f, 962f, -91);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(994f / NPECJCIKCBI.transform.localScale.x, 1144f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 919f + NPECJCIKCBI.transform.localScale.x / 1527f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.ECGGKMIKKMI(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void JDJMCKEFFPF(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 23f, 922f, -200);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(1328f / NPECJCIKCBI.transform.localScale.x, 1469f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 1123f + NPECJCIKCBI.transform.localScale.x / 521f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.LeagueColorPosition(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.LeagueColorMedals(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void LIFBNBFDBEI(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 728f, 600f, 39);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(38f / NPECJCIKCBI.transform.localScale.x, 495f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 832f + NPECJCIKCBI.transform.localScale.x / 1052f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.LeagueColorPosition(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void DLKFLMFMOJB(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 740f, 622f, 53);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(1934f / NPECJCIKCBI.transform.localScale.x, 1689f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 202f + NPECJCIKCBI.transform.localScale.x / 50f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.ABAKFENMJLH(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.LeagueColorMedals(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void MMMHNNFKCGB(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 102f, 712f, -98);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(1734f / NPECJCIKCBI.transform.localScale.x, 65f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 1267f + NPECJCIKCBI.transform.localScale.x / 1504f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.LeagueColorPosition(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.LeagueColorMedals(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void OAOMFBIGDEA(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 959f, 940f, -16);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown == WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(20f / NPECJCIKCBI.transform.localScale.x, 398f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 1856f + NPECJCIKCBI.transform.localScale.x / 1354f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.LeagueColorPosition(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.PPCEOIOKFGK(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void JOBPHNIADFL(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 823f, 206f, 10);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(656f / NPECJCIKCBI.transform.localScale.x, 1518f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 678f + NPECJCIKCBI.transform.localScale.x / 357f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.LeagueColorPosition(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.LeagueColorMedals(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}

	public void ABCOKMAFNBD(int MPHCNMDIPAI, DatabasePlayer KHLGDCHJJPB, JBAGAHBOICJ FJLBLLLEELD)
	{
		ELOELLAEBIA.text = MEJMLNDFDBP.ACCGOIGJIAA(MPHCNMDIPAI);
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 838f, 413f, -111);
		DJAGJBKHEND.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.medalsBalance);
		bool flag = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag);
		if (flag)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float multiplier = Mathf.Min(781f / NPECJCIKCBI.transform.localScale.x, 347f / NPECJCIKCBI.transform.localScale.y);
			NPECJCIKCBI.transform.localScale = NPECJCIKCBI.transform.localScale.MultiplyXY(multiplier);
			float num = BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			float val = BCMCMKDCLGP.transform.localPosition.x + num + 1019f + NPECJCIKCBI.transform.localScale.x / 1640f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(val);
		}
		LCPBNBLGFIA.color = Singleton<GameVariables>.instance.LeagueColorHighlight(FJLBLLLEELD);
		ELOELLAEBIA.color = Singleton<GameVariables>.instance.ABAKFENMJLH(FJLBLLLEELD);
		DJAGJBKHEND.color = Singleton<GameVariables>.instance.LeagueColorMedals(FJLBLLLEELD);
		LCPBNBLGFIA.gameObject.SetActive(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id);
	}
}
