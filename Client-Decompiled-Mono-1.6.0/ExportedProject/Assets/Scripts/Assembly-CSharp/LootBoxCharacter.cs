using System.Runtime.CompilerServices;
using UnityEngine;

public class LootBoxCharacter : Core_BaseScript, KMNCIJPDFPJ
{
	[SerializeField]
	private SoldierMeshChanger mMeshChanger;

	public Animation LAIFICFFFBB;

	public Material CJIPGGDKHAP;

	public Material FGKPAMLMMJJ;

	public SoldierMeshChanger meshChanger
	{
		get
		{
			return mMeshChanger;
		}
	}

	public string[] playerVisuals { get; set; }

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo { get; set; }

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet { get; set; }

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory { get; set; }

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand { get; set; }

	[SpecialName]
	public void HFBMNEMEMEL(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void IONNPKDDMPF(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo OMAPMFMHDFE()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	public void OFFLEJGEKLG()
	{
		meshChanger.ODLMHIBKLDP.material = CJIPGGDKHAP;
	}

	public void JAGPEBOMFLP(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			AMIALELNAHK(true, false, true);
			break;
		case 1:
			JKLKFLOJKPP(true, true, true);
			break;
		case 2:
			JOCJNJCKMPJ(false, true, false);
			break;
		}
	}

	public void AJJJCKDJMNG()
	{
		meshChanger.ODLMHIBKLDP.material = CJIPGGDKHAP;
	}

	public void FHFCBDPGKMO(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			JOCJNJCKMPJ(false, false, false);
			break;
		case 1:
			JKLKFLOJKPP(false, true, true);
			break;
		case 2:
			JOCJNJCKMPJ(false, false, true);
			break;
		}
	}

	public void ENAHJAEGBKA()
	{
		GLNEINCAHIP().ODLMHIBKLDP.material = CJIPGGDKHAP;
	}

	public void DHMBNFFONEI()
	{
		NPGGBJHIGED(new string[6]);
		OJBBCNLMEGH("ID_OFFERACTIVE", 1153f);
	}

	[SpecialName]
	public void FMOOLDMOEOI(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public string[] OGMGIMMMBCG()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	[SpecialName]
	public void NPGGBJHIGED(string[] IDEBKDPMPGM)
	{
		_003CPBHGHHPEJAB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand HPLMFHENLCP()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	public void JNAAANKFKEG()
	{
		KILENEDPIIH(new string[5]);
		CPEDPCEBELC("StatisticsData", 880f);
	}

	private void JKLKFLOJKPP(bool CGCKDIBIFFI, bool LJBKNMJBPEG, bool PIMEOLOOMML)
	{
		meshChanger.ODLMHIBKLDP.enabled = false;
		if (!CGCKDIBIFFI)
		{
			FGKPAMLMMJJ.mainTexture = GLNEINCAHIP().ODLMHIBKLDP.material.mainTexture;
			GLNEINCAHIP().ODLMHIBKLDP.material = FGKPAMLMMJJ;
			NBGJNMJIKJH().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = FGKPAMLMMJJ;
		}
		else
		{
			GKMHABANNIO().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = NBGJNMJIKJH().ODLMHIBKLDP.material;
		}
		BFGPAFIIBML().LJBKNMJBPEG.gameObject.SetActive(LJBKNMJBPEG);
		GLNEINCAHIP().AKPKJMNGFIE.BLHMGOMCDFG[0].parent.gameObject.SetActive(PIMEOLOOMML);
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory JLGHHDFFMEB()
	{
		return _003CJOGJPJHPAJA_003Ek__BackingField;
	}

	[SpecialName]
	public void DDOHNKDAOGO(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public string[] DGLHGNAJDLJ()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	[SpecialName]
	public void LMMEGGAKJFG(PlayerVisualCategoryCamos.PlayerVisualCamo IDEBKDPMPGM)
	{
		_003CKJPCMEIGMCE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void SetAccesory(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			JOCJNJCKMPJ(true, false, false);
			break;
		case 1:
			JOCJNJCKMPJ(false, true, false);
			break;
		case 2:
			JOCJNJCKMPJ(false, false, true);
			break;
		}
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory JIPMJIBFHNH()
	{
		return _003CJOGJPJHPAJA_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet DMIIFACKIJI()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	public void ACLEONDAJFB()
	{
		NPGGBJHIGED(new string[8]);
		DHLHKCMMNAJ("ID_TUTORIAL_TAPON", 887f);
	}

	[SpecialName]
	public string[] PODDEMGINGD()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	[SpecialName]
	public void LAJNNGLAAGO(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void OJBBCNLMEGH(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = false;
		animationState.weight = 682f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = true;
	}

	[SpecialName]
	public SoldierMeshChanger GLNEINCAHIP()
	{
		return mMeshChanger;
	}

	public void NPLBHBGFGGM(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			JEGNGJGBIBO(false, false, false);
			break;
		case 1:
			BBKLOKCIGMJ(false, false, true);
			break;
		case 2:
			AMIALELNAHK(false, true, true);
			break;
		}
	}

	private void HDDBNNCHNOP(bool CGCKDIBIFFI, bool LJBKNMJBPEG, bool PIMEOLOOMML)
	{
		BFGPAFIIBML().ODLMHIBKLDP.enabled = true;
		if (!CGCKDIBIFFI)
		{
			FGKPAMLMMJJ.mainTexture = meshChanger.ODLMHIBKLDP.material.mainTexture;
			LKBKOCGLGCF().ODLMHIBKLDP.material = FGKPAMLMMJJ;
			GLNEINCAHIP().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = FGKPAMLMMJJ;
		}
		else
		{
			LKBKOCGLGCF().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = GKMHABANNIO().ODLMHIBKLDP.material;
		}
		GLNEINCAHIP().LJBKNMJBPEG.gameObject.SetActive(LJBKNMJBPEG);
		meshChanger.AKPKJMNGFIE.BLHMGOMCDFG[1].parent.gameObject.SetActive(PIMEOLOOMML);
	}

	public void DBAIKAIBIMP()
	{
		NBGJNMJIKJH().ODLMHIBKLDP.material = CJIPGGDKHAP;
	}

	[SpecialName]
	public void LKOIMDAPNHG(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void PGHMLKHDEHJ(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void LABGHEIBMIP(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = true;
		animationState.weight = 1847f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = false;
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo LDLOPIBCNFI()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet OHGBFAFNLBL()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	[SpecialName]
	public void NDCEIKBFEFK(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void JEGNGJGBIBO(bool CGCKDIBIFFI, bool LJBKNMJBPEG, bool PIMEOLOOMML)
	{
		NBGJNMJIKJH().ODLMHIBKLDP.enabled = false;
		if (!CGCKDIBIFFI)
		{
			FGKPAMLMMJJ.mainTexture = LKBKOCGLGCF().ODLMHIBKLDP.material.mainTexture;
			LKBKOCGLGCF().ODLMHIBKLDP.material = FGKPAMLMMJJ;
			GKMHABANNIO().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = FGKPAMLMMJJ;
		}
		else
		{
			LKBKOCGLGCF().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = GLNEINCAHIP().ODLMHIBKLDP.material;
		}
		GLNEINCAHIP().LJBKNMJBPEG.gameObject.SetActive(LJBKNMJBPEG);
		NBGJNMJIKJH().AKPKJMNGFIE.BLHMGOMCDFG[0].parent.gameObject.SetActive(PIMEOLOOMML);
	}

	private void LCGKFDEOJBP(bool CGCKDIBIFFI, bool LJBKNMJBPEG, bool PIMEOLOOMML)
	{
		GKMHABANNIO().ODLMHIBKLDP.enabled = false;
		if (!CGCKDIBIFFI)
		{
			FGKPAMLMMJJ.mainTexture = LKBKOCGLGCF().ODLMHIBKLDP.material.mainTexture;
			NBGJNMJIKJH().ODLMHIBKLDP.material = FGKPAMLMMJJ;
			LKBKOCGLGCF().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = FGKPAMLMMJJ;
		}
		else
		{
			LKBKOCGLGCF().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = GLNEINCAHIP().ODLMHIBKLDP.material;
		}
		LKBKOCGLGCF().LJBKNMJBPEG.gameObject.SetActive(LJBKNMJBPEG);
		GKMHABANNIO().AKPKJMNGFIE.BLHMGOMCDFG[1].parent.gameObject.SetActive(PIMEOLOOMML);
	}

	public void MNBICJPLJDE()
	{
		NPGGBJHIGED(new string[1]);
		DHLHKCMMNAJ("ID_SKILLSHOTHINT_ENVIROMENTALKILL", 1945f);
	}

	[SpecialName]
	public void BEOJIAIJOKK(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void CBINHLDEKIE(string[] IDEBKDPMPGM)
	{
		_003CPBHGHHPEJAB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void DBHCFNILGKI(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			HDDBNNCHNOP(true, true, true);
			break;
		case 1:
			AMIALELNAHK(false, true, false);
			break;
		case 2:
			BBKLOKCIGMJ(true, true, false);
			break;
		}
	}

	[SpecialName]
	public void KGAKFIOLAAJ(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void KKKNHLOJBMC(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			JEGNGJGBIBO(true, true, false);
			break;
		case 1:
			JEGNGJGBIBO(true, true, true);
			break;
		case 2:
			JEGNGJGBIBO(false, false, true);
			break;
		}
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand DGMHHHOFDEM()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo HIBOOIHGLPN()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	public void OBMDLGBJKHF(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			AMIALELNAHK(false, true, false);
			break;
		case 1:
			HDDBNNCHNOP(false, true, true);
			break;
		case 2:
			JOCJNJCKMPJ(false, true, false);
			break;
		}
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet HNGPLGLGPJD()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	[SpecialName]
	public void PNAFJIFJJBD(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory AIOKOHDALEC()
	{
		return _003CJOGJPJHPAJA_003Ek__BackingField;
	}

	public void BKGCJBFMDMA(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			JKLKFLOJKPP(false, false, true);
			break;
		case 1:
			LCGKFDEOJBP(false, true, true);
			break;
		case 2:
			BBKLOKCIGMJ(false, false, false);
			break;
		}
	}

	private void KDOCCKIDICI(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = false;
		animationState.weight = 1302f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = false;
	}

	[SpecialName]
	public SoldierMeshChanger GKMHABANNIO()
	{
		return mMeshChanger;
	}

	private void CPEDPCEBELC(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = false;
		animationState.weight = 396f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = false;
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo OKMEDIAALGC()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	[SpecialName]
	public void KILENEDPIIH(string[] IDEBKDPMPGM)
	{
		_003CPBHGHHPEJAB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo DBOLCPFNFKN()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	[SpecialName]
	public void HADPNLBDLOG(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		_003CLOCJJMDKKAL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand LIFKHBIJACI()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet NPNNFFNDEFB()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	public void CGGNOJJEFKE(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			JKLKFLOJKPP(false, true, false);
			break;
		case 1:
			HDDBNNCHNOP(false, true, false);
			break;
		case 2:
			GJPBPNKIFDH(false, false, false);
			break;
		}
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand CEJJKIAEDIH()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	[SpecialName]
	public SoldierMeshChanger BFGPAFIIBML()
	{
		return mMeshChanger;
	}

	[SpecialName]
	public void LPPPJFJECCH(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void CINHDIGJFBC(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BFDHPKDLIJN(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void PGKCNBMAJJM(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			BBKLOKCIGMJ(false, false, false);
			break;
		case 1:
			JOCJNJCKMPJ(true, false, true);
			break;
		case 2:
			JOCJNJCKMPJ(true, false, true);
			break;
		}
	}

	public void SetSolidMaterial()
	{
		meshChanger.ODLMHIBKLDP.material = CJIPGGDKHAP;
	}

	private void DHLHKCMMNAJ(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = false;
		animationState.weight = 411f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = true;
	}

	public void LKNKNCGJJDA()
	{
		playerVisuals = new string[4];
		DFCFJEJFLCF("DailyMissionsCompletionRewardScraps", 1145f);
	}

	public void JFPPPGJGFJN(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			AMIALELNAHK(true, true, true);
			break;
		case 1:
			JEGNGJGBIBO(true, true, false);
			break;
		case 2:
			JEGNGJGBIBO(true, true, false);
			break;
		}
	}

	private void BOGHOAOEMBF(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = false;
		animationState.weight = 186f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = true;
	}

	[SpecialName]
	public string[] LHAOHPIMJCJ()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand FDPNHIDGMFP()
	{
		return _003CLOCJJMDKKAL_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo NCHBHNEMKIM()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	private void EANAKNOJCFJ(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = false;
		animationState.weight = 622f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = false;
	}

	[SpecialName]
	public string[] BOIHPNPIPAE()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	private void GJPBPNKIFDH(bool CGCKDIBIFFI, bool LJBKNMJBPEG, bool PIMEOLOOMML)
	{
		BFGPAFIIBML().ODLMHIBKLDP.enabled = true;
		if (!CGCKDIBIFFI)
		{
			FGKPAMLMMJJ.mainTexture = NBGJNMJIKJH().ODLMHIBKLDP.material.mainTexture;
			LKBKOCGLGCF().ODLMHIBKLDP.material = FGKPAMLMMJJ;
			GKMHABANNIO().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = FGKPAMLMMJJ;
		}
		else
		{
			BFGPAFIIBML().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = NBGJNMJIKJH().ODLMHIBKLDP.material;
		}
		meshChanger.LJBKNMJBPEG.gameObject.SetActive(LJBKNMJBPEG);
		LKBKOCGLGCF().AKPKJMNGFIE.BLHMGOMCDFG[0].parent.gameObject.SetActive(PIMEOLOOMML);
	}

	[SpecialName]
	public void EPAAKOHCMHB(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void JJEAOHOLHGE(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			HDDBNNCHNOP(false, false, false);
			break;
		case 1:
			AMIALELNAHK(false, false, true);
			break;
		case 2:
			JKLKFLOJKPP(false, true, false);
			break;
		}
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet AHBCAMMOEIH()
	{
		return _003CJHJFIJPNBIM_003Ek__BackingField;
	}

	public void KFJLPOLHFKO()
	{
		BFGPAFIIBML().ODLMHIBKLDP.material = CJIPGGDKHAP;
	}

	public void EMAJCCPMNMK()
	{
		NPGGBJHIGED(new string[0]);
		KDOCCKIDICI("[{0}] {1}", 1585f);
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo MGLKLNADFIC()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory POBABOJGOBO()
	{
		return _003CJOGJPJHPAJA_003Ek__BackingField;
	}

	[SpecialName]
	public string[] BBPBJFIAHGN()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	public void CGLKAMCIAPL(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			JEGNGJGBIBO(false, false, true);
			break;
		case 1:
			AMIALELNAHK(false, false, true);
			break;
		case 2:
			JOCJNJCKMPJ(false, true, true);
			break;
		}
	}

	public void DFAPDKEDBCE(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			LCGKFDEOJBP(false, false, false);
			break;
		case 1:
			AMIALELNAHK(true, false, true);
			break;
		case 2:
			AMIALELNAHK(false, true, true);
			break;
		}
	}

	[SpecialName]
	public void EIBAMFDFNGL(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void EHBIFDCCFLP()
	{
		KILENEDPIIH(new string[2]);
		DHLHKCMMNAJ("no data", 825f);
	}

	private void BBKLOKCIGMJ(bool CGCKDIBIFFI, bool LJBKNMJBPEG, bool PIMEOLOOMML)
	{
		meshChanger.ODLMHIBKLDP.enabled = false;
		if (!CGCKDIBIFFI)
		{
			FGKPAMLMMJJ.mainTexture = meshChanger.ODLMHIBKLDP.material.mainTexture;
			LKBKOCGLGCF().ODLMHIBKLDP.material = FGKPAMLMMJJ;
			BFGPAFIIBML().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = FGKPAMLMMJJ;
		}
		else
		{
			GKMHABANNIO().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = NBGJNMJIKJH().ODLMHIBKLDP.material;
		}
		GLNEINCAHIP().LJBKNMJBPEG.gameObject.SetActive(LJBKNMJBPEG);
		BFGPAFIIBML().AKPKJMNGFIE.BLHMGOMCDFG[0].parent.gameObject.SetActive(PIMEOLOOMML);
	}

	private void DFCFJEJFLCF(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = true;
		animationState.weight = 674f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = false;
	}

	[SpecialName]
	public void BLFMOLPEENP(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void FEFOHLOPMBI(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = true;
		animationState.weight = 1466f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = false;
	}

	public void AINKDEBOBEI()
	{
		BFGPAFIIBML().ODLMHIBKLDP.material = CJIPGGDKHAP;
	}

	[SpecialName]
	public void AKLJBMPLEPO(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		_003CJHJFIJPNBIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryCamos.PlayerVisualCamo HLJNONOPPJP()
	{
		return _003CKJPCMEIGMCE_003Ek__BackingField;
	}

	private void MCOABOBEPFC(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = true;
		animationState.weight = 672f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = false;
	}

	public void LKCEPPEHBHM(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			JEGNGJGBIBO(false, false, false);
			break;
		case 1:
			BBKLOKCIGMJ(true, false, true);
			break;
		case 2:
			LCGKFDEOJBP(false, true, true);
			break;
		}
	}

	[SpecialName]
	public string[] DAKHBJMODHK()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	[SpecialName]
	public string[] CJHBOBMBIOE()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	[SpecialName]
	public SoldierMeshChanger NBGJNMJIKJH()
	{
		return mMeshChanger;
	}

	public void KJMNAGDLDHO(int INFLHPGMEOB)
	{
		switch (INFLHPGMEOB)
		{
		case 0:
			BBKLOKCIGMJ(false, true, true);
			break;
		case 1:
			GJPBPNKIFDH(true, false, true);
			break;
		case 2:
			JKLKFLOJKPP(false, false, true);
			break;
		}
	}

	[SpecialName]
	public string[] AJKGHOEJILP()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	[SpecialName]
	public void DIBJGMFCMME(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		_003CJOGJPJHPAJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory GAEMHAJKNJL()
	{
		return _003CJOGJPJHPAJA_003Ek__BackingField;
	}

	private void AGDGIOGPBCK(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LAIFICFFFBB.Stop();
		AnimationState animationState = LAIFICFFFBB[BIHAIAKHHNI];
		animationState.enabled = true;
		animationState.weight = 1f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LAIFICFFFBB.Sample();
		animationState.enabled = false;
	}

	public void MNKMPJMBOLF()
	{
		meshChanger.ODLMHIBKLDP.material = CJIPGGDKHAP;
	}

	[SpecialName]
	public SoldierMeshChanger LKBKOCGLGCF()
	{
		return mMeshChanger;
	}

	private void JOCJNJCKMPJ(bool CGCKDIBIFFI, bool LJBKNMJBPEG, bool PIMEOLOOMML)
	{
		meshChanger.ODLMHIBKLDP.enabled = true;
		if (!CGCKDIBIFFI)
		{
			FGKPAMLMMJJ.mainTexture = meshChanger.ODLMHIBKLDP.material.mainTexture;
			meshChanger.ODLMHIBKLDP.material = FGKPAMLMMJJ;
			meshChanger.DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = FGKPAMLMMJJ;
		}
		else
		{
			meshChanger.DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = meshChanger.ODLMHIBKLDP.material;
		}
		meshChanger.LJBKNMJBPEG.gameObject.SetActive(LJBKNMJBPEG);
		meshChanger.AKPKJMNGFIE.BLHMGOMCDFG[0].parent.gameObject.SetActive(PIMEOLOOMML);
	}

	private void AMIALELNAHK(bool CGCKDIBIFFI, bool LJBKNMJBPEG, bool PIMEOLOOMML)
	{
		meshChanger.ODLMHIBKLDP.enabled = false;
		if (!CGCKDIBIFFI)
		{
			FGKPAMLMMJJ.mainTexture = meshChanger.ODLMHIBKLDP.material.mainTexture;
			GLNEINCAHIP().ODLMHIBKLDP.material = FGKPAMLMMJJ;
			NBGJNMJIKJH().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = FGKPAMLMMJJ;
		}
		else
		{
			NBGJNMJIKJH().DONGKPEBGFC.GetComponent<MeshRenderer>().sharedMaterial = BFGPAFIIBML().ODLMHIBKLDP.material;
		}
		LKBKOCGLGCF().LJBKNMJBPEG.gameObject.SetActive(LJBKNMJBPEG);
		GKMHABANNIO().AKPKJMNGFIE.BLHMGOMCDFG[0].parent.gameObject.SetActive(PIMEOLOOMML);
	}

	[SpecialName]
	public string[] KENGJAJNHBM()
	{
		return _003CPBHGHHPEJAB_003Ek__BackingField;
	}

	public void Prepare()
	{
		playerVisuals = new string[4];
		AGDGIOGPBCK("engineer_idle", 0f);
	}
}
