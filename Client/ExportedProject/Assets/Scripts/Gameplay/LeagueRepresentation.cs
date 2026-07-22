using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LeagueRepresentation : Core_BaseScript
{
	[Header("Core")]
	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("LEEBPNGMFFM")]
	[Header("Top Part")]
	public GameObject JNKHCEGFPGE;

	[FormerlySerializedAs("KNIHAEEIFLJ")]
	public UITexture NNMCKEECNFK;

	[FormerlySerializedAs("ADGMEAIPEEE")]
	public GameObject PPGFAPEFFKI;

	[FormerlySerializedAs("MIDIHPEJPKK")]
	public UILabel LLFBCAOPOHJ;

	[FormerlySerializedAs("JJJMPHONDOA")]
	public UILabel KFKLIEOHNNK;

	[Header("Bottom Part")]
	[FormerlySerializedAs("ONIHPKHLGNH")]
	public UISprite MBMIOELEAND;

	[FormerlySerializedAs("HNPCIIIHKCE")]
	public UIGrid JMFANIKPBML;

	[FormerlySerializedAs("PMDGFMDGFID")]
	public GameObject DECKADNJBCK;

	[FormerlySerializedAs("JKGLDMICOJP")]
	public UILabel JIOMBOPMMKC;

	[FormerlySerializedAs("KHFGEHEEELK")]
	public GameObject HFPMFEOFLKF;

	[FormerlySerializedAs("EKNMKKJAMFA")]
	public UILabel BKLJLNJOKHC;

	private float MIPEAFCDDHC = 476f;

	public static Dictionary<League, Color> MJNAEEHPKOP = new Dictionary<League, Color>
	{
		{
			League.NoLeague,
			Colours.whiteTransparent
		},
		{
			League.Bronze3,
			Colours.bronzeLeague
		},
		{
			League.Bronze2,
			Colours.bronzeLeague
		},
		{
			League.Bronze1,
			Colours.bronzeLeague
		},
		{
			League.Silver3,
			Colours.silverLeague
		},
		{
			League.Silver2,
			Colours.silverLeague
		},
		{
			League.Silver1,
			Colours.silverLeague
		},
		{
			League.Gold3,
			Colours.goldLeague
		},
		{
			League.Gold2,
			Colours.goldLeague
		},
		{
			League.Gold1,
			Colours.goldLeague
		},
		{
			League.Elite3,
			Colours.eliteLeague
		},
		{
			League.Elite2,
			Colours.eliteLeague
		},
		{
			League.Elite1,
			Colours.eliteLeague
		},
		{
			League.Master3,
			Colours.masterLeague
		},
		{
			League.Master2,
			Colours.masterLeague
		},
		{
			League.Master1,
			Colours.masterLeague
		},
		{
			League.Champion,
			Colours.championLeague
		}
	};

	public static Dictionary<League, Tuple<Vector3, Vector3, float>> GMOIAHANAOJ = new Dictionary<League, Tuple<Vector3, Vector3, float>>
	{
		{
			League.NoLeague,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 0f)
		},
		{
			League.Bronze3,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 0f)
		},
		{
			League.Bronze2,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 0f)
		},
		{
			League.Bronze1,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 0f)
		},
		{
			League.Silver3,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 10f)
		},
		{
			League.Silver2,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 10f)
		},
		{
			League.Silver1,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 10f)
		},
		{
			League.Gold3,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 27f)
		},
		{
			League.Gold2,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 27f)
		},
		{
			League.Gold1,
			new Tuple<Vector3, Vector3, float>(new Vector3(340f, 340f, 1f), new Vector3(0f, -170f, 0f), 27f)
		},
		{
			League.Elite3,
			new Tuple<Vector3, Vector3, float>(new Vector3(320f, 320f, 1f), new Vector3(0f, -174f, 0f), 29f)
		},
		{
			League.Elite2,
			new Tuple<Vector3, Vector3, float>(new Vector3(320f, 320f, 1f), new Vector3(0f, -174f, 0f), 29f)
		},
		{
			League.Elite1,
			new Tuple<Vector3, Vector3, float>(new Vector3(320f, 320f, 1f), new Vector3(0f, -174f, 0f), 29f)
		},
		{
			League.Master3,
			new Tuple<Vector3, Vector3, float>(new Vector3(316f, 316f, 1f), new Vector3(0f, -178f, 0f), 35f)
		},
		{
			League.Master2,
			new Tuple<Vector3, Vector3, float>(new Vector3(316f, 316f, 1f), new Vector3(0f, -178f, 0f), 35f)
		},
		{
			League.Master1,
			new Tuple<Vector3, Vector3, float>(new Vector3(316f, 316f, 1f), new Vector3(0f, -178f, 0f), 35f)
		},
		{
			League.Champion,
			new Tuple<Vector3, Vector3, float>(new Vector3(361f, 361f, 1f), new Vector3(0f, -178f, 0f), 41f)
		}
	};

	public void IAABBPDAHCK(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1522f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("com/google/android/gms/common/api/Status" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OPAPBENHGMO(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 640f;
		float y = num5 + 476f;
		float y2 = num5 + 1328f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 73f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-83)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("Prefabs to go through: {0} + {1}", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = $"x{MEJMLNDFDBP.GMIPFLIEOHD(num3)}";
	}

	public void JFANAFJBDMK(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 648f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("Id" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OMLHMLGCOBD(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 816f;
		float y = num5 + 1704f;
		float y2 = num5 + 268f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 940f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-121)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("ID_STATE_WAITINGFOROPPONENT", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("ID_LEAGUE4", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void HFGEMMCABDI(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1709f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("ID_GUI_DRAGCARDHERE" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.FPBNDHGOINI(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OMLHMLGCOBD(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1832f;
		float y = num5 + 57f;
		float y2 = num5 + 9f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1422f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)79) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("1", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("ID_TUTORIAL_NEWDRAGCARD", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void HCGCONILDID(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1637f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("ID_DAILYGOLDBOOSTERHINT1" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 992f;
		float y = num5 + 1809f;
		float y2 = num5 + 1849f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1560f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-55)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = string.Format("NetworkReInstantiate", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("Total_Assignment_Completed", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void Initialization(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 60f;
		float y = num5 + 48f;
		float y2 = num5 + 78f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1f);
		MBMIOELEAND.color = ((BMNDININJCE != League.Champion) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = $"+{MEJMLNDFDBP.GMIPFLIEOHD(num2)}";
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = $"+{MEJMLNDFDBP.GMIPFLIEOHD(num3)}";
	}

	public void MONJIGJHAMM(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1934f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("Shots_Hits" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.HNGCHCCBCBC(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1557f;
		float y = num5 + 1278f;
		float y2 = num5 + 96f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 448f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-106)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("\"", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("PickMagneticObjectRPC", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void HIOADODFOFD(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 247f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("#Game Rewards# - Medals old:{0} new:{1} Balance old:{2} new:{3} Remaining fights:{4} - (offer mult {5})" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.FPBNDHGOINI(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OPAPBENHGMO(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 802f;
		float y = num5 + 139f;
		float y2 = num5 + 1298f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 988f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-38)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = string.Format("WarFriends precisa de permissão para aceder seus arquivos de mídia para baixar dados críticos do jogo.Sem essa permissão o jogo não poderá funcionar e será encerrado. Por favor, tente novamente ou saia de WarFriends.", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("Region", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void HKMDPDLHBCI(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 249f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("gold" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OPAPBENHGMO(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 119f;
		float y = num5 + 994f;
		float y2 = num5 + 113f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 778f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-31)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = string.Format("EliminateUnits", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("DailyRentalMessage{0}{1}{2}", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void JBOLOKPPFKO(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.MEEKFLDAFJC(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1299f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("GetExtreme({0}, {1}, *predict*) is returning null, player should have equipped/unlocked at least one unit from each category" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.FPBNDHGOINI(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OPAPBENHGMO(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1039f;
		float y = num5 + 787f;
		float y2 = num5 + 420f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 690f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)69) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = string.Format("game-neardeath-indicator", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("({0}\u00a0/\u00a0{1})", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void KIPHECHDNML(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 700f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("0\u00a0" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.FPBNDHGOINI(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 804f;
		float y = num5 + 350f;
		float y2 = num5 + 1490f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1230f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-48)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("menu-sidetab-bg-box-button-gold", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("Items", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void LBLNJNIAIAG(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.MEEKFLDAFJC(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1743f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("Something went wrong in updating players in league" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OMLHMLGCOBD(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 565f;
		float y = num5 + 130f;
		float y2 = num5 + 397f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 877f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)35) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("country-noflag", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("ID_SUBSCRIPTIODETAILS_HINT3TRAILGOOGLE", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void DMKLEMBILON(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 104f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("HEAD_SANTABEARD" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OPAPBENHGMO(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 196f;
		float y = num5 + 1448f;
		float y2 = num5 + 1226f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1369f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-18)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("(Landroid/app/Activity;I)V", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("GooglePlayId", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void KMJFOGMABGH(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.MEEKFLDAFJC(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 326f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("Mine Buddy Warcard" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.FPBNDHGOINI(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OPAPBENHGMO(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1516f;
		float y = num5 + 1749f;
		float y2 = num5 + 208f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1344f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-27)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("FacebookId", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("Tier", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void BNPGAEEKDPC(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1822f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("GoldenSuitcase" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OPAPBENHGMO(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 408f;
		float y = num5 + 1858f;
		float y2 = num5 + 327f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1045f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-111)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("Grenade_Throwing_Tutorial_Duration", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("On Login to Custom playerAccount", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void KHCLIKGLAHA(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 939f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("ArenaGoldenShieldMessage-{0}" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.FPBNDHGOINI(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1704f;
		float y = num5 + 1180f;
		float y2 = num5 + 1558f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 754f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-115)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = string.Format("game-card-ico-criticalinsurance", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("ID_CONFIRM_ERROR", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void KOINJEFDLNN(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.MEEKFLDAFJC(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 549f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("next" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OMLHMLGCOBD(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1111f;
		float y = num5 + 1043f;
		float y2 = num5 + 443f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 532f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-95)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("discount", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("GUI/2Dtoolkit/", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void DEKOOPGCGJN(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1698f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("N" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.HNGCHCCBCBC(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OMLHMLGCOBD(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1488f;
		float y = num5 + 1861f;
		float y2 = num5 + 1866f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 460f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-20)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("Text", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("TUTORIAL 3 OVERTIME CONTINUE", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void LHFBDOCJLCA(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 275f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("null" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.FPBNDHGOINI(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1912f;
		float y = num5 + 973f;
		float y2 = num5 + 1447f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 273f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-76)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = string.Format("ID_SALEPERCENTLINE", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("BestSkill", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void EKDJJJBKIMA(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1660f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("extraGold" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 389f;
		float y = num5 + 394f;
		float y2 = num5 + 1768f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1218f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)21) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = string.Format("PlayerLevel", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("Tier", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void MOHKFCLHOMA(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.LeagueProgress(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 464f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("ID_TOCOMPLETE" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.HNGCHCCBCBC(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1536f;
		float y = num5 + 1178f;
		float y2 = num5 + 5f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1446f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)34) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("(Ljava/lang/Object;)Z", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("RewardId", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void DGEOHEAHDHK(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 244f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("Take player life!" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.HNGCHCCBCBC(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.OMLHMLGCOBD(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 766f;
		float y = num5 + 1572f;
		float y2 = num5 + 1005f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 215f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)37) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("ID_STATE_READYFORBATTLE", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("Buy_Units", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void FOKIOHLOPAG(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.MEEKFLDAFJC(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 758f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("ID_CONFIRM_OPPONENTCANCELLED" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 1907f;
		float y = num5 + 973f;
		float y2 = num5 + 1552f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1523f);
		MBMIOELEAND.color = ((BMNDININJCE != League.Silver3) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = false;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("Generate army 3", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("N0", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void FIMOJDKBENM(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.MEEKFLDAFJC(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 981f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("^\\D*" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 501f;
		float y = num5 + 312f;
		float y2 = num5 + 238f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 1808f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)94) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 0);
		JIOMBOPMMKC.text = string.Format("RETRYPERM", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 1);
		BKLJLNJOKHC.text = string.Format("attack", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}

	public void BAFGIPDELBG(League BMNDININJCE, float JBGGMCDDKPJ)
	{
		if (JBGGMCDDKPJ < MIPEAFCDDHC)
		{
			JBGGMCDDKPJ = MIPEAFCDDHC;
		}
		float num = MIPEAFCDDHC + (JBGGMCDDKPJ - MIPEAFCDDHC) * Singleton<GameVariables>.instance.ANIGMIHAJCI(BMNDININJCE);
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, num, 1561f);
		JNKHCEGFPGE.transform.localPosition = new Vector3(JNKHCEGFPGE.transform.localScale.x, num - GMOIAHANAOJ[BMNDININJCE].Value3, JNKHCEGFPGE.transform.localScale.z);
		KMFGCJEGJJK.color = MJNAEEHPKOP[BMNDININJCE];
		PPGFAPEFFKI.transform.localPosition = GMOIAHANAOJ[BMNDININJCE].Value2;
		NNMCKEECNFK.mainTexture = Resources.Load<Texture>("SheetVersionVariant" + GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2);
		NNMCKEECNFK.transform.localScale = GMOIAHANAOJ[BMNDININJCE].Value1;
		LLFBCAOPOHJ.text = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value1;
		KFKLIEOHNNK.text = string.Empty;
		int num2 = Singleton<GameVariables>.instance.HNGCHCCBCBC(BMNDININJCE);
		int num3 = Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(BMNDININJCE);
		int num4 = MEJMLNDFDBP.CEMFPCJLMPF(num2) + MEJMLNDFDBP.CEMFPCJLMPF(num3);
		float num5 = (float)num4 * 872f;
		float y = num5 + 1796f;
		float y2 = num5 + 653f;
		MBMIOELEAND.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x, y2, 625f);
		MBMIOELEAND.color = ((BMNDININJCE != (League)(-106)) ? Colours.whiteGray : Colours.goldChampion);
		JMFANIKPBML.transform.localPosition = new Vector3(JMFANIKPBML.transform.localPosition.x, y, JMFANIKPBML.transform.localPosition.z);
		JMFANIKPBML.repositionNow = true;
		DECKADNJBCK.SetActive(num2 > 1);
		JIOMBOPMMKC.text = string.Format("RequestsResults", MEJMLNDFDBP.GMIPFLIEOHD(num2));
		HFPMFEOFLKF.SetActive(num3 > 0);
		BKLJLNJOKHC.text = string.Format("bazooka_idle", MEJMLNDFDBP.GMIPFLIEOHD(num3));
	}
}
