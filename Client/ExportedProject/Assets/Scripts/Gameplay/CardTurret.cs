using UnityEngine;

public class CardTurret : Card
{
	private PlayerController MBIAKMPDOPG;

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.LDGAKJJINEO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void DFMALDFADAB()
	{
	}

	protected virtual void PCDHCIDJJOB()
	{
	}

	protected virtual void IOAEHDJGBJC()
	{
	}

	public virtual void NEPIKOKDBHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void POLFFIJKMNA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.LDGAKJJINEO().MGIDDHIPJBC(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void AOJALKEHFCK()
	{
	}

	protected virtual void JLOKAFKICIM()
	{
	}

	protected virtual void OHHLNKPIHBH()
	{
	}

	protected virtual void HOINLOMCGFD()
	{
	}

	public virtual void DCGABENHDBH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().MGIDDHIPJBC(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EMMADHCHLOH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void IOKMAFLIJEG()
	{
	}

	protected virtual void PBCDDNOCJOI()
	{
	}

	protected virtual void FOIKLCECNBL()
	{
	}

	protected virtual void HMMKNCDDDLH()
	{
	}

	protected virtual void IBLPGJOHIAE()
	{
	}

	public virtual void LLMMIFJBLBD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void GDKKBDKGAEK()
	{
	}

	protected virtual void PDLNCCFMDFG()
	{
	}

	public virtual void NPGNJOGAEMK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void MLEBPBFEOKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void OBPMHHGJFEL()
	{
	}

	public virtual void OFNENBNMMOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.OKBAIGKCPKA().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void AGMKIMGHPAL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void NLLLLJGKNIC()
	{
	}

	public virtual void GGBPLMCEGML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.OKBAIGKCPKA().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void MEMDELDKFJI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.GGBPHPOPCAM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DGCEELPOEHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.MGIDDHIPJBC(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JGNBFCJFAHM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.LDGAKJJINEO().EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EKFKAICCHLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.OKBAIGKCPKA().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void FIGOGIMJIIN()
	{
	}

	public virtual void EEJJPCKLAMB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void IDLKDDEEALI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PDAEAPEDIJC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.OKBAIGKCPKA().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void ABMOHFELOFN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JMPKKCCHAJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.OKBAIGKCPKA().GGBPHPOPCAM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KEDMNJPECDO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void LKCMKAELBFO()
	{
	}

	public virtual void PFOLMAKLAFO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void GBGDKNIMGMB()
	{
	}

	public virtual void BKMGMNGKBMB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().GGBPHPOPCAM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LEEFEJHDLGM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void BLFKABLENCH()
	{
	}

	public virtual void JONIGCEPKLO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void IGOMLJOMFGA()
	{
	}

	protected virtual void FJJAEHJDKNL()
	{
	}

	public virtual void GDHGFMCBDJI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void AKHKMOOJOGC()
	{
	}

	public virtual void BHBDBJNOCMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.OKBAIGKCPKA().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DPCBCEAMGNK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void IODPOHKAKNN()
	{
	}

	protected virtual void AKBKAKINING()
	{
	}

	public virtual void NLPMJPNEEOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void NOGLOKJINKN()
	{
	}

	protected virtual void DKMHPLCCLKI()
	{
	}

	public virtual void JIHLMCGMAMO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LOLJCEGGPMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.LDGAKJJINEO().EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DEAKMOJEFEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().GGBPHPOPCAM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected override void Awake()
	{
	}

	protected virtual void DCKJHAILENK()
	{
	}

	protected virtual void KNLKFOHBCKI()
	{
	}

	protected virtual void FGOAPPLNMKL()
	{
	}

	protected virtual void NIAEEICNNHL()
	{
	}

	protected virtual void EALPHOPMAMP()
	{
	}

	public virtual void PFLGKCELNOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void GEKMPGMEAGF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.LDGAKJJINEO().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void CFPFCPGPOCP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PNAGDNEPGHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.LDGAKJJINEO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void LCHBPLMPGJP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().GGBPHPOPCAM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void FEJKPDNPNOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected virtual void MGAFJAJNBFL()
	{
	}

	protected virtual void JJBODEPAMBI()
	{
	}

	protected virtual void KDMECDLHNMC()
	{
	}

	public virtual void NPODFBNDOAK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.OKBAIGKCPKA().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void GDEHLDBGNHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.BMNEPICFHNO().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero, KKAIPHCKJHO: false);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void OJLEHLGEMLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.LDGAKJJINEO().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, MBIAKMPDOPG.fraction, Vector3.zero);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}
}
