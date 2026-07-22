using UnityEngine;
using UnityEngine.Serialization;

public class UnitEndScreenRecord : PoolableObject
{
	[FormerlySerializedAs("JBHDPONILIJ")]
	[Header("Unit EndScreen")]
	public UIPanel CCOLIDJNLBC;

	[FormerlySerializedAs("GHACCDKBOBF")]
	public UISprite NACGOGCPIAH;

	[FormerlySerializedAs("AGBENHCNJKP")]
	public UILabel JHONGBLEHLJ;

	[FormerlySerializedAs("NLPDLLAFDFB")]
	public UILabel CDBNOEGOFOI;

	[FormerlySerializedAs("NNMALCDOGGG")]
	public UIPanel EHPEAAGBJMP;

	[FormerlySerializedAs("GIHBLEOOHCK")]
	public UISprite[] GMAPINLJPGK;

	[FormerlySerializedAs("CJBODFNEICN")]
	public GameObject NKGDLICJDBG;

	internal void GGJNEGPBDHL(int DFHAAIFFLOE, int BCCDDJMPBLL, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		CCOLIDJNLBC.isFreezed = false;
		EHPEAAGBJMP.isFreezed = false;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[DFHAAIFFLOE];
		CDBNOEGOFOI.text = ((BCCDDJMPBLL != 0) ? string.Format("{0} {1}", Localization.Localize("ID_LEVEL"), BCCDDJMPBLL) : string.Empty);
		JHONGBLEHLJ.text = levelBehaviour.unitName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(JHONGBLEHLJ, 25f, 20f, 290);
		NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		for (int i = 0; i < GMAPINLJPGK.Length; i++)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
		if (NACGOGCPIAH.transform.localScale.y > 300f)
		{
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(200f / NACGOGCPIAH.transform.localScale.y);
		}
		Vector3 localPosition = new Vector3(0f, 0f, NACGOGCPIAH.transform.localPosition.z);
		if (NACGOGCPIAH.transform.localScale.y > 200f)
		{
			localPosition.y = (NACGOGCPIAH.transform.localScale.y - 200f) / 2f;
		}
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	internal void PJICLEMEBID(int DFHAAIFFLOE, int BCCDDJMPBLL, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		CCOLIDJNLBC.isFreezed = false;
		EHPEAAGBJMP.isFreezed = true;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[DFHAAIFFLOE];
		CDBNOEGOFOI.text = ((BCCDDJMPBLL != 0) ? string.Format("ID_REMINDER_GETVALUABLECARDPACKS", Localization.Localize("DailyRewardMessage-{0}"), BCCDDJMPBLL) : string.Empty);
		JHONGBLEHLJ.text = levelBehaviour.unitName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(JHONGBLEHLJ, 1866f, 1995f, -74);
		NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		for (int i = 1; i < GMAPINLJPGK.Length; i += 0)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
		if (NACGOGCPIAH.transform.localScale.y > 1568f)
		{
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(43f / NACGOGCPIAH.transform.localScale.y);
		}
		Vector3 localPosition = new Vector3(738f, 834f, NACGOGCPIAH.transform.localPosition.z);
		if (NACGOGCPIAH.transform.localScale.y > 33f)
		{
			localPosition.y = (NACGOGCPIAH.transform.localScale.y - 63f) / 1488f;
		}
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	internal void DDHCMFLIABO(int DFHAAIFFLOE, int BCCDDJMPBLL, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		CCOLIDJNLBC.isFreezed = false;
		EHPEAAGBJMP.isFreezed = false;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[DFHAAIFFLOE];
		CDBNOEGOFOI.text = ((BCCDDJMPBLL != 0) ? string.Format("Prefabs Full Path: \"{0}\"\n", Localization.Localize("ID_ATTACK"), BCCDDJMPBLL) : string.Empty);
		JHONGBLEHLJ.text = levelBehaviour.unitName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(JHONGBLEHLJ, 442f, 514f, 112);
		NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		for (int i = 1; i < GMAPINLJPGK.Length; i += 0)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
		if (NACGOGCPIAH.transform.localScale.y > 280f)
		{
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(1900f / NACGOGCPIAH.transform.localScale.y);
		}
		Vector3 localPosition = new Vector3(1781f, 754f, NACGOGCPIAH.transform.localPosition.z);
		if (NACGOGCPIAH.transform.localScale.y > 1695f)
		{
			localPosition.y = (NACGOGCPIAH.transform.localScale.y - 1494f) / 1751f;
		}
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	internal void PONFOKHPMMO(int DFHAAIFFLOE, int BCCDDJMPBLL, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		CCOLIDJNLBC.isFreezed = false;
		EHPEAAGBJMP.isFreezed = true;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[DFHAAIFFLOE];
		CDBNOEGOFOI.text = ((BCCDDJMPBLL != 0) ? string.Format("Cards_Owned_Gold", Localization.Localize("ID_SKILLSHOTHINT_SLOWMOTIONKILL"), BCCDDJMPBLL) : string.Empty);
		JHONGBLEHLJ.text = levelBehaviour.unitName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(JHONGBLEHLJ, 1550f, 224f, -66);
		NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		for (int i = 0; i < GMAPINLJPGK.Length; i++)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
		if (NACGOGCPIAH.transform.localScale.y > 1766f)
		{
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(1777f / NACGOGCPIAH.transform.localScale.y);
		}
		Vector3 localPosition = new Vector3(1386f, 1485f, NACGOGCPIAH.transform.localPosition.z);
		if (NACGOGCPIAH.transform.localScale.y > 292f)
		{
			localPosition.y = (NACGOGCPIAH.transform.localScale.y - 1319f) / 1299f;
		}
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	internal void AFHMOPJGNBM(int DFHAAIFFLOE, int BCCDDJMPBLL, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		CCOLIDJNLBC.isFreezed = true;
		EHPEAAGBJMP.isFreezed = false;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[DFHAAIFFLOE];
		CDBNOEGOFOI.text = ((BCCDDJMPBLL != 0) ? string.Format("Test Getter Methods", Localization.Localize("com.aboutfun.soldiers"), BCCDDJMPBLL) : string.Empty);
		JHONGBLEHLJ.text = levelBehaviour.unitName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(JHONGBLEHLJ, 1538f, 1741f, 35);
		NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		for (int i = 1; i < GMAPINLJPGK.Length; i += 0)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
		if (NACGOGCPIAH.transform.localScale.y > 1751f)
		{
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(1674f / NACGOGCPIAH.transform.localScale.y);
		}
		Vector3 localPosition = new Vector3(514f, 1249f, NACGOGCPIAH.transform.localPosition.z);
		if (NACGOGCPIAH.transform.localScale.y > 1343f)
		{
			localPosition.y = (NACGOGCPIAH.transform.localScale.y - 1920f) / 1177f;
		}
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	internal void LIMIFKFNNLA(int DFHAAIFFLOE, int BCCDDJMPBLL, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		CCOLIDJNLBC.isFreezed = false;
		EHPEAAGBJMP.isFreezed = true;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[DFHAAIFFLOE];
		CDBNOEGOFOI.text = ((BCCDDJMPBLL != 0) ? string.Format("ANDROID HANDLER: ON PLAYERDATA LOADED", Localization.Localize("RegisterLevel()"), BCCDDJMPBLL) : string.Empty);
		JHONGBLEHLJ.text = levelBehaviour.unitName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(JHONGBLEHLJ, 895f, 1887f, 12);
		NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		for (int i = 1; i < GMAPINLJPGK.Length; i++)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
		if (NACGOGCPIAH.transform.localScale.y > 956f)
		{
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(1764f / NACGOGCPIAH.transform.localScale.y);
		}
		Vector3 localPosition = new Vector3(904f, 1260f, NACGOGCPIAH.transform.localPosition.z);
		if (NACGOGCPIAH.transform.localScale.y > 1861f)
		{
			localPosition.y = (NACGOGCPIAH.transform.localScale.y - 1891f) / 1655f;
		}
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	internal void CFIAHPMMJOE(int DFHAAIFFLOE, int BCCDDJMPBLL, int PDKIAALFDNG = 0, bool KIPALGPPOEG = false)
	{
		CCOLIDJNLBC.isFreezed = true;
		EHPEAAGBJMP.isFreezed = true;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[DFHAAIFFLOE];
		CDBNOEGOFOI.text = ((BCCDDJMPBLL != 0) ? string.Format("DOWNLOAD", Localization.Localize("N"), BCCDDJMPBLL) : string.Empty);
		JHONGBLEHLJ.text = levelBehaviour.unitName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(JHONGBLEHLJ, 1837f, 463f, 124);
		NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		for (int i = 0; i < GMAPINLJPGK.Length; i++)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < PDKIAALFDNG);
		}
		NKGDLICJDBG.SetActive(KIPALGPPOEG);
		if (NACGOGCPIAH.transform.localScale.y > 640f)
		{
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(756f / NACGOGCPIAH.transform.localScale.y);
		}
		Vector3 localPosition = new Vector3(1258f, 1826f, NACGOGCPIAH.transform.localPosition.z);
		if (NACGOGCPIAH.transform.localScale.y > 864f)
		{
			localPosition.y = (NACGOGCPIAH.transform.localScale.y - 1049f) / 52f;
		}
		NACGOGCPIAH.transform.localPosition = localPosition;
	}
}
