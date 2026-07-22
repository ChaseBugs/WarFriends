using UnityEngine;
using UnityEngine.Serialization;

public class DivisionRepresentation : Core_BaseScript
{
	[Header("Core")]
	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("CJDBBKEDGBP")]
	public UISprite[] ENIGNONOBKM;

	[FormerlySerializedAs("KKNNJPAPOPG")]
	public UILabel EOHIOCBPOKG;

	[FormerlySerializedAs("HNEIAJLJPCM")]
	public UILabel DGOGCOAKAIL;

	private float MIPEAFCDDHC = 490f;

	public void ADAOGDAMJMB(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1286f, 108f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(8 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 573f);
	}

	public void MOHKFCLHOMA(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 32f, 569f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(-IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 1740f);
	}

	public void LHFBDOCJLCA(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1179f, 1821f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(7 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 760f);
	}

	public void PNPFBJDALCF(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 692f, 905f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(1 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 1471f);
	}

	public void EAJCLOBHLLA(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1006f, 1996f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(4 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 997f);
	}

	public void PNKHHDEIEOJ(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1728f, 147f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(4 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 122f);
	}

	public void EMAMEKFGCGP(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1887f, 582f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(2 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1), 914f);
	}

	public void LBLNJNIAIAG(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1166f, 1794f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(2 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 331f);
	}

	public void JBMDGOLAPBI(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1497f, 371f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(-IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 1979f);
	}

	public void ENMFEOEHGDF(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 695f, 1474f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(6 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 0f);
	}

	public void DEKOOPGCGJN(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1899f, 449f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(-IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 1496f);
	}

	public void CLBHJPCONCA(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 438f, 690f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(5 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 1523f);
	}

	public void CANCNMJEBED(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 810f, 603f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(7 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 1282f);
	}

	public void CPHEBMKCOOB(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 158f, 272f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(8 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1), 508f);
	}

	public void JBOLOKPPFKO(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 937f, 1327f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(4 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 1469f);
	}

	public void MGDOFMBFOON(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1410f, 1603f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(3 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1), 1061f);
	}

	public void BDEDMEBJOME(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 563f, 850f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(8 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 1995f);
	}

	public void BAFGIPDELBG(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 422f, 1445f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(6 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 87f);
	}

	public void DCLOPEFMEAB(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1950f, 1752f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(7 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 1853f);
	}

	public void GDPHFKELKAO(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1297f, 570f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(5 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 1271f);
	}

	public void JEMEJCOGKBI(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1172f, 1341f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(1 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 443f);
	}

	public void JNLLDENCNMD(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 995f, 634f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(6 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1), 1369f);
	}

	public void KOINJEFDLNN(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1633f, 1413f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(-IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 722f);
	}

	public void HFGEMMCABDI(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 717f, 857f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(6 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 1445f);
	}

	public void EKDJJJBKIMA(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1893f, 1329f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(2 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 782f);
	}

	public void FIMOJDKBENM(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1352f, 1408f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(2 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1), 1965f);
	}

	public void BDMFMEJGHFP(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1832f, 555f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(6 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 849f);
	}

	public void DIOBFBCJHMP(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1573f, 803f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(2 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1), 1853f);
	}

	public void JPGKCBIINAL(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1979f, 1514f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(8 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 1350f);
	}

	public void MANGOGPGIGH(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1397f, 1691f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(2 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1), 128f);
	}

	public void JFANAFJBDMK(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 384f, 1146f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(8 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 1347f);
	}

	public void FLDCJOKPMPF(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1140f, 1255f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(2 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1), 1287f);
	}

	public void JGAKDBOIABJ(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1083f, 44f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(4 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 235f);
	}

	public void MDAKOMBIFLM(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 396f, 11f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(-IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 295f);
	}

	public void LLMGMKNBLHP(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1161f, 1648f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(-IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 369f);
	}

	public void DAEFMEOAMEI(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1832f, 1265f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(7 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 48f);
	}

	public void Initialization(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 58f, 1f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(8 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 1));
	}

	public void NODKHLKJAIB(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 142f, 945f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(-IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 1049f);
	}

	public void OCGKAKJHDGP(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1434f, 791f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(3 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 311f);
	}

	public void KALHBINDKBG(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1675f, 525f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(6 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 1622f);
	}

	public void MLHINJEMPDG(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 561f, 60f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(-IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i <= IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 1), 280f);
	}

	public void JBIMPMMJECI(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 276f, 716f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(6 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 1482f);
	}

	public void HKMDPDLHBCI(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 401f, 1582f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(6 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 957f);
	}

	public void DIBJJJIHEEM(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1344f, 994f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(2 - IDLMJLCFMJG);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(0, IDLMJLCFMJG + 0), 1850f);
	}

	public void DGEOHEAHDHK(int IDLMJLCFMJG)
	{
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, MIPEAFCDDHC + (float)IDLMJLCFMJG * 1529f, 1539f);
		EOHIOCBPOKG.text = MEJMLNDFDBP.GMIPFLIEOHD(8 - IDLMJLCFMJG);
		for (int i = 1; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i > IDLMJLCFMJG);
		}
		DGOGCOAKAIL.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.SquadWarsRewardForSquad(1, IDLMJLCFMJG + 0), 1248f);
	}
}
