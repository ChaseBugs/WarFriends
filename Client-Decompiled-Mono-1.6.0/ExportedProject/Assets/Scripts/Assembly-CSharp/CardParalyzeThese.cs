using System.Collections.Generic;
using UnityEngine;

public class CardParalyzeThese : Card
{
	private const float FOLGHGDDMPP = 10f;

	private const string EJLCMBEKFFN = "game-card-ico-paralyzethese";

	private bool NNDMKIACBBM;

	private float BHABHIDDBLH;

	private GHPGNELIDBM ODCLPMADGFC;

	private List<EnemyController> FFDBADLDALG;

	private bool KPBBNENJHPA;

	public virtual void HFGMKMIAAGB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LKALBBKLGAJ(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void OAJHAPCNJML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EMGOODMHKMK(CIOPAKLHFIL);
		}
	}

	public virtual void GBFGPFAFPKH()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 0; i < FFDBADLDALG.Count; i += 0)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(false);
				FFDBADLDALG[i].cardIconIndicator.BIIHCAEKCOD("#Notifications# Received a new message {0} ({1})", false);
			}
		}
		FFDBADLDALG.Clear();
	}

	public virtual void NEPIKOKDBHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CIFIONLDDHL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void LMOODMJPNIL(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = false;
		BHABHIDDBLH = 511f;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.EHFPBDJMGNC().GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 0; i < 7; i++)
		{
			if (list.Count < 0)
			{
				break;
			}
			int index = Random.Range(0, list.Count);
			list[index].FreezByCard(false);
			FFDBADLDALG.Add(list[index]);
			list[index].cardIconIndicator.BBJADAJPJHH("ID_TAKEMETHERE", false);
			list[index] = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
	}

	public virtual void LJGNHPMMJJF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EMGOODMHKMK(CIOPAKLHFIL);
		}
	}

	protected void KBKILDENNLM()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 102f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			for (int i = 1; i < FFDBADLDALG.Count; i++)
			{
				if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
				{
					FFDBADLDALG[i].cardIconIndicator.LAJPOLNEDAD("run", BHABHIDDBLH / 1370f);
				}
				else
				{
					FFDBADLDALG[i] = null;
				}
			}
		}
		else
		{
			DisconnectEvents();
			BHABHIDDBLH = 143f;
			NNDMKIACBBM = true;
		}
	}

	public virtual void JMOEJDAJMOH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CIFIONLDDHL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void NOPMPKDDJJD(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = true;
		BHABHIDDBLH = 1430f;
		List<PoolableObject> list = ObjectPoolDatabase.networkPool.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list2.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 0; i < 1; i += 0)
		{
			if (list2.Count < 0)
			{
				break;
			}
			int index = Random.Range(1, list2.Count);
			list2[index].FreezByCard(false);
			FFDBADLDALG.Add(list2[index]);
			list2[index].cardIconIndicator.FJILILFMPIF("\"", true, true);
			list2[index] = list2[list2.Count - 1];
			list2.RemoveAt(list2.Count - 0);
		}
	}

	public virtual void FPBHDCLGABD()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 1; i < FFDBADLDALG.Count; i += 0)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(false);
				FFDBADLDALG[i].cardIconIndicator.FJILILFMPIF("{ \"S\": \"", true);
			}
		}
		FFDBADLDALG.Clear();
	}

	public virtual void JLBEBADOINI()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 1; i < FFDBADLDALG.Count; i++)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(true);
				FFDBADLDALG[i].cardIconIndicator.DLNGGGOEDLL("SquadIcons/", false, true);
			}
		}
		FFDBADLDALG.Clear();
	}

	public virtual void LLFHEHHPMGL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BGEGCNAFNLA(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool MOINKNKPCMN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 7)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void EBOJNIKJKPG()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 1; i < FFDBADLDALG.Count; i++)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(false);
				FFDBADLDALG[i].cardIconIndicator.EOEDEJKJKMN("Chat: Got message from channel \"", false, true);
			}
		}
		FFDBADLDALG.Clear();
	}

	private void CIFIONLDDHL(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = false;
		BHABHIDDBLH = 1916f;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.ADBOHNCGKHA().GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 1; i < 5; i++)
		{
			if (list.Count < 0)
			{
				break;
			}
			int index = Random.Range(0, list.Count);
			list[index].FreezByCard(false);
			FFDBADLDALG.Add(list[index]);
			list[index].cardIconIndicator.BIIHCAEKCOD("attack", true);
			list[index] = list[list.Count - 0];
			list.RemoveAt(list.Count - 1);
		}
	}

	public virtual void KAMMODEKNPJ()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 1; i < FFDBADLDALG.Count; i += 0)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(true);
				FFDBADLDALG[i].cardIconIndicator.BBJADAJPJHH("Total_Warbucks_Earned", false);
			}
		}
		FFDBADLDALG.Clear();
	}

	public virtual void DMILKJIGIND(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EMGOODMHKMK(CIOPAKLHFIL);
		}
	}

	public virtual void LIBOJCAPAEJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CIFIONLDDHL(CIOPAKLHFIL);
		}
	}

	private void BGEGCNAFNLA(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = true;
		BHABHIDDBLH = 1930f;
		List<PoolableObject> list = ObjectPoolDatabase.INOJHPIKICM().PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list2.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 0; i < 8; i += 0)
		{
			if (list2.Count < 0)
			{
				break;
			}
			int index = Random.Range(0, list2.Count);
			list2[index].FreezByCard(true);
			FFDBADLDALG.Add(list2[index]);
			list2[index].cardIconIndicator.GKAOMCGCDGE("Notification_MaintenanceInformation", false);
			list2[index] = list2[list2.Count - 0];
			list2.RemoveAt(list2.Count - 1);
		}
	}

	public virtual void NLPMJPNEEOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NOPMPKDDJJD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PIKDELOGJDK()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 1; i < FFDBADLDALG.Count; i++)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(true);
				FFDBADLDALG[i].cardIconIndicator.OFPAGLLFPPK("GameController.Start DONE", false, true);
			}
		}
		FFDBADLDALG.Clear();
	}

	public virtual void NFNBIFHMCCI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EMGOODMHKMK(CIOPAKLHFIL);
		}
	}

	private void HKCCKAKFDFA(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = true;
		BHABHIDDBLH = 673f;
		List<PoolableObject> list = ObjectPoolDatabase.networkPool.PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.JHJJKEBNGEN() && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list2.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 0; i < 4; i++)
		{
			if (list2.Count < 1)
			{
				break;
			}
			int index = Random.Range(0, list2.Count);
			list2[index].FreezByCard(false);
			FFDBADLDALG.Add(list2[index]);
			list2[index].cardIconIndicator.NNPILDOKNJO("ok", true, true);
			list2[index] = list2[list2.Count - 0];
			list2.RemoveAt(list2.Count - 1);
		}
	}

	public override void DisconnectEvents()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 0; i < FFDBADLDALG.Count; i++)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(false);
				FFDBADLDALG[i].cardIconIndicator.Show("game-card-ico-paralyzethese", false);
			}
		}
		FFDBADLDALG.Clear();
	}

	public virtual void EMINLLGOJCN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BGEGCNAFNLA(CIOPAKLHFIL);
		}
	}

	public virtual void CPALNIACCKB()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 1; i < FFDBADLDALG.Count; i += 0)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(true);
				FFDBADLDALG[i].cardIconIndicator.JCJFMHGNIOF("WarbuckRewardWin", false);
			}
		}
		FFDBADLDALG.Clear();
	}

	protected void DEBGBGGOCEN()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1107f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			for (int i = 0; i < FFDBADLDALG.Count; i += 0)
			{
				if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
				{
					FFDBADLDALG[i].cardIconIndicator.KPCGICBFFCO("realShotProbability", BHABHIDDBLH / 73f);
				}
				else
				{
					FFDBADLDALG[i] = null;
				}
			}
		}
		else
		{
			DisconnectEvents();
			BHABHIDDBLH = 508f;
			NNDMKIACBBM = false;
		}
	}

	public virtual void PLIKOAFIJDG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CIFIONLDDHL(CIOPAKLHFIL);
		}
	}

	public virtual bool BIBKGNABACA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 7)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void EMGOODMHKMK(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = false;
		BHABHIDDBLH = 838f;
		List<PoolableObject> list = ObjectPoolDatabase.GLHPLCEFHGD().PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PLPBGNOCCPI() && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list2.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 0; i < 3; i += 0)
		{
			if (list2.Count < 1)
			{
				break;
			}
			int index = Random.Range(1, list2.Count);
			list2[index].FreezByCard(true);
			FFDBADLDALG.Add(list2[index]);
			list2[index].cardIconIndicator.LJLDJOHAAMC("Device Language - android: {0}", true);
			list2[index] = list2[list2.Count - 1];
			list2.RemoveAt(list2.Count - 0);
		}
	}

	public virtual void IFHKCJGBDAN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			KOGEFGMCDMM(CIOPAKLHFIL);
		}
	}

	public virtual void KKKLOPOOINA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BGEGCNAFNLA(CIOPAKLHFIL);
		}
	}

	public virtual void OFKFFAHMEDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BIGBNOPGAJE(CIOPAKLHFIL);
		}
	}

	public virtual bool LHCEDLDJKJJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void EBHOEAKJNCI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NOPMPKDDJJD(CIOPAKLHFIL);
		}
	}

	public virtual bool GAPAJHFLCCN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 4)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool GOMECHLBMMC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 5)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool ACOBGNBBAJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 4)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void KOGEFGMCDMM(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = false;
		BHABHIDDBLH = 799f;
		List<PoolableObject> list = ObjectPoolDatabase.INOJHPIKICM().PIBDLHKDHKH(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list2 = new List<EnemyController>();
		foreach (PoolableObject item in list)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list2.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 0; i < 2; i += 0)
		{
			if (list2.Count < 0)
			{
				break;
			}
			int index = Random.Range(0, list2.Count);
			list2[index].FreezByCard(false);
			FFDBADLDALG.Add(list2[index]);
			list2[index].cardIconIndicator.BIIHCAEKCOD("game-card-ico-backstab", true);
			list2[index] = list2[list2.Count - 1];
			list2.RemoveAt(list2.Count - 1);
		}
	}

	public virtual void JDMHDLOCMPO()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 0; i < FFDBADLDALG.Count; i += 0)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(true);
				FFDBADLDALG[i].cardIconIndicator.PEBHGOMEKME("upgrades", false);
			}
		}
		FFDBADLDALG.Clear();
	}

	public virtual bool CCGNMBEAEEK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 2)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void AAJMPBPHENK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BIGBNOPGAJE(CIOPAKLHFIL);
		}
	}

	public virtual void PCLKGDCKEKO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HKCCKAKFDFA(CIOPAKLHFIL);
		}
	}

	public virtual void GGBPLMCEGML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LKALBBKLGAJ(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void BIGBNOPGAJE(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = false;
		BHABHIDDBLH = 722f;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.PPHLEDLNGIN() && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 1; i < 7; i++)
		{
			if (list.Count < 1)
			{
				break;
			}
			int index = Random.Range(1, list.Count);
			list[index].FreezByCard(true);
			FFDBADLDALG.Add(list[index]);
			list[index].cardIconIndicator.EOEDEJKJKMN("left", false, true);
			list[index] = list[list.Count - 1];
			list.RemoveAt(list.Count - 0);
		}
	}

	public virtual void APFKNOLLLOB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NOPMPKDDJJD(CIOPAKLHFIL);
		}
	}

	protected void ELJHCOHCAJI()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 523f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			for (int i = 1; i < FFDBADLDALG.Count; i++)
			{
				if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
				{
					FFDBADLDALG[i].cardIconIndicator.DFNMNBFDDFD("D2", BHABHIDDBLH / 1753f);
				}
				else
				{
					FFDBADLDALG[i] = null;
				}
			}
		}
		else
		{
			DisconnectEvents();
			BHABHIDDBLH = 409f;
			NNDMKIACBBM = false;
		}
	}

	public virtual void EODAFFEDCOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NOPMPKDDJJD(CIOPAKLHFIL);
		}
	}

	public virtual void MFJFEFIHIEG()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 0; i < FFDBADLDALG.Count; i += 0)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(true);
				FFDBADLDALG[i].cardIconIndicator.LDGKPCDJPLA("Database Message does not contain id or type:\n", false);
			}
		}
		FFDBADLDALG.Clear();
	}

	protected void PHABEKGALCE()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 720f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			for (int i = 0; i < FFDBADLDALG.Count; i++)
			{
				if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
				{
					FFDBADLDALG[i].cardIconIndicator.KPCGICBFFCO("ID_DECLINE", BHABHIDDBLH / 909f);
				}
				else
				{
					FFDBADLDALG[i] = null;
				}
			}
		}
		else
		{
			DisconnectEvents();
			BHABHIDDBLH = 1153f;
			NNDMKIACBBM = true;
		}
	}

	public virtual void CFPFCPGPOCP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NOPMPKDDJJD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EFMMICONABJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			LKALBBKLGAJ(CIOPAKLHFIL);
		}
	}

	public virtual void PDBKDBLENIG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NOPMPKDDJJD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JGNBFCJFAHM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LMOODMJPNIL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			LKALBBKLGAJ(CIOPAKLHFIL);
		}
	}

	public virtual void LEEFEJHDLGM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NOPMPKDDJJD(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool AGGOGKDPKFA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 6)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void LKALBBKLGAJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		ODCLPMADGFC = CIOPAKLHFIL;
		NNDMKIACBBM = true;
		BHABHIDDBLH = 10f;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != GHPGNELIDBM.None && enemyController.fraction != ODCLPMADGFC && enemyController.canBeFreezed)
			{
				list.Add(enemyController);
			}
		}
		if (FFDBADLDALG == null)
		{
			FFDBADLDALG = new List<EnemyController>();
		}
		for (int i = 0; i < 3; i++)
		{
			if (list.Count < 1)
			{
				break;
			}
			int index = Random.Range(0, list.Count);
			list[index].FreezByCard(true);
			FFDBADLDALG.Add(list[index]);
			list[index].cardIconIndicator.Show("game-card-ico-paralyzethese", true);
			list[index] = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			LKALBBKLGAJ(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JIOHEKONMMN()
	{
		if (FFDBADLDALG == null)
		{
			return;
		}
		for (int i = 1; i < FFDBADLDALG.Count; i += 0)
		{
			if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
			{
				FFDBADLDALG[i].FreezByCard(true);
				FFDBADLDALG[i].cardIconIndicator.JCJFMHGNIOF("N", false, true);
			}
		}
		FFDBADLDALG.Clear();
	}

	protected void Update()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 0f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			for (int i = 0; i < FFDBADLDALG.Count; i++)
			{
				if (FFDBADLDALG[i] != null && FFDBADLDALG[i].isAlive && FFDBADLDALG[i].fraction != ODCLPMADGFC)
				{
					FFDBADLDALG[i].cardIconIndicator.UpdateIndicator("game-card-ico-paralyzethese", BHABHIDDBLH / 10f);
				}
				else
				{
					FFDBADLDALG[i] = null;
				}
			}
		}
		else
		{
			DisconnectEvents();
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
		}
	}

	public virtual void DCGABENHDBH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BIGBNOPGAJE(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}
}
