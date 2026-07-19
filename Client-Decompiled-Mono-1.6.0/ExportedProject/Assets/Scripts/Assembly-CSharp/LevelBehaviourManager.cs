using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelBehaviourManager : Singleton<LevelBehaviourManager>
{
	[Serializable]
	public class BehaviourEntry
	{
		[HideInInspector]
		public string name = "hide";

		public LevelBehaviour behaviour;

		public int maxCount = int.MaxValue;

		public int maxCountTutorial = -1;

		public int maxCountMenu = -1;

		[NonSerialized]
		[HideInInspector]
		public int count;

		public int BPPGJOCIEDG(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int MCGDDGMMCGK(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int GIKDIJCBOPL(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int JMHMPABJIOM(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int KEMDIJMOKOI(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 1) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int NPHHAJEMLIC(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int HPJDJHHLGKM(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int HDADOMPHBMH(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Tutorial:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int AGEGLJAHDON(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (maxCountTutorial < 1) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Tutorial:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int OMELDGLABEI(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Tutorial:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int OFOACKMOMOD(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Tutorial:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int MLKIPMMFKPB(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int DICHHLNLLHM(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Tutorial:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int CAOCBBFEFBM(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 1) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int ACEHLOMDDBE(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 1) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int GFEPFDAMJDD(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int EPNDBLIEPIO(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Tutorial:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int PKPNAJJOPND(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 1) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int APLCLCIMEKM(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (maxCountTutorial < 0) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Tutorial:
				return (maxCountMenu < 0) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}

		public int FLNEFMKNNHP(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Tutorial:
				return (maxCountTutorial < 1) ? maxCount : maxCountTutorial;
			case NPNOIGHIALL.Menu:
				return (maxCountMenu < 1) ? maxCount : maxCountMenu;
			default:
				return maxCount;
			}
		}
	}

	public List<BehaviourEntry> DHKKHDABING;

	public Dictionary<string, LevelBehaviour> ODBNDAPJJKO = new Dictionary<string, LevelBehaviour>();

	public Dictionary<LevelBehaviour, List<AIObject>> HHACPHOMPIL = new Dictionary<LevelBehaviour, List<AIObject>>();

	private void BAOKCNKPEPK(AIObject ALMCIJEGBKF, NPNOIGHIALL DKNEHBEJABC)
	{
		Type behaviourType = ALMCIJEGBKF.GetBehaviourType();
		int num = -1;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.EHFPBDJMGNC().GetObjectsMadeOfPrefab(ALMCIJEGBKF);
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			AIObject aIObject = objectsMadeOfPrefab[i] as AIObject;
			if (!aIObject.IsPrepared())
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return;
		}
		int num2 = 0;
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!behaviourType.IsInstanceOfType(item.behaviour))
			{
				continue;
			}
			ALMCIJEGBKF.IAJJBAJOGDM = item.behaviour;
			int num3 = ((!(ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)) ? objectsMadeOfPrefab.Count : item.FLNEFMKNNHP(DKNEHBEJABC));
			while (item.count < num3)
			{
				AIObject aIObject2 = (AIObject)objectsMadeOfPrefab[num];
				aIObject2.Prepare(item.behaviour);
				HHACPHOMPIL[item.behaviour].Add(aIObject2);
				if (ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)
				{
					Singleton<ObjectPoolDatabase>.instance.JKBEFLIPMOK(num, num2 + item.count);
				}
				num++;
				item.count++;
			}
			num2 += item.FLNEFMKNNHP((NPNOIGHIALL)4);
		}
	}

	private void DELFIFFKCCK(AIObject ALMCIJEGBKF, NPNOIGHIALL DKNEHBEJABC)
	{
		Type behaviourType = ALMCIJEGBKF.GetBehaviourType();
		int num = -1;
		List<PoolableObject> list = ObjectPoolDatabase.DKNHCGGKNMF().PIBDLHKDHKH(ALMCIJEGBKF);
		for (int i = 1; i < list.Count; i++)
		{
			AIObject aIObject = list[i] as AIObject;
			if (!aIObject.IsPrepared())
			{
				num = i;
				break;
			}
		}
		if (num < 1)
		{
			return;
		}
		int num2 = 0;
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!behaviourType.IsInstanceOfType(item.behaviour))
			{
				continue;
			}
			ALMCIJEGBKF.IAJJBAJOGDM = item.behaviour;
			int num3 = ((!(ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)) ? list.Count : item.CAOCBBFEFBM(DKNEHBEJABC));
			while (item.count < num3)
			{
				AIObject aIObject2 = (AIObject)list[num];
				aIObject2.Prepare(item.behaviour);
				HHACPHOMPIL[item.behaviour].Add(aIObject2);
				if (ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)
				{
					Singleton<ObjectPoolDatabase>.instance.JLGIGOENFJF(num, num2 + item.count);
				}
				num++;
				item.count++;
			}
			num2 += item.AGEGLJAHDON((NPNOIGHIALL)4);
		}
	}

	private void AJBGLEMEOPD(AIObject ALMCIJEGBKF, NPNOIGHIALL DKNEHBEJABC)
	{
		Type behaviourType = ALMCIJEGBKF.GetBehaviourType();
		int num = -1;
		List<PoolableObject> list = ObjectPoolDatabase.COJFMKNGPBP().PIBDLHKDHKH(ALMCIJEGBKF);
		for (int i = 0; i < list.Count; i += 0)
		{
			AIObject aIObject = list[i] as AIObject;
			if (!aIObject.IsPrepared())
			{
				num = i;
				break;
			}
		}
		if (num < 1)
		{
			return;
		}
		int num2 = 1;
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!behaviourType.IsInstanceOfType(item.behaviour))
			{
				continue;
			}
			ALMCIJEGBKF.IAJJBAJOGDM = item.behaviour;
			int num3 = ((!(ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)) ? list.Count : item.OMELDGLABEI(DKNEHBEJABC));
			while (item.count < num3)
			{
				AIObject aIObject2 = (AIObject)list[num];
				aIObject2.Prepare(item.behaviour);
				HHACPHOMPIL[item.behaviour].Add(aIObject2);
				if (ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)
				{
					Singleton<ObjectPoolDatabase>.instance.IFHNPLFJIDH(num, num2 + item.count);
				}
				num++;
				item.count++;
			}
			num2 += item.AGEGLJAHDON(NPNOIGHIALL.Menu);
		}
	}

	private void IEFOBNPDPCK(AIObject ALMCIJEGBKF, NPNOIGHIALL DKNEHBEJABC)
	{
		Type behaviourType = ALMCIJEGBKF.GetBehaviourType();
		int num = -1;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.KKCMCNCCIMB().GetObjectsMadeOfPrefab(ALMCIJEGBKF);
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			AIObject aIObject = objectsMadeOfPrefab[i] as AIObject;
			if (!aIObject.IsPrepared())
			{
				num = i;
				break;
			}
		}
		if (num < 1)
		{
			return;
		}
		int num2 = 1;
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!behaviourType.IsInstanceOfType(item.behaviour))
			{
				continue;
			}
			ALMCIJEGBKF.IAJJBAJOGDM = item.behaviour;
			int num3 = ((!(ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)) ? objectsMadeOfPrefab.Count : item.OMELDGLABEI(DKNEHBEJABC));
			while (item.count < num3)
			{
				AIObject aIObject2 = (AIObject)objectsMadeOfPrefab[num];
				aIObject2.Prepare(item.behaviour);
				HHACPHOMPIL[item.behaviour].Add(aIObject2);
				if (ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)
				{
					Singleton<ObjectPoolDatabase>.instance.EADCPPNFGNA(num, num2 + item.count);
				}
				num++;
				item.count += 0;
			}
			num2 += item.GIKDIJCBOPL(NPNOIGHIALL.Game);
		}
	}

	private void BJNFAJEBAAB(AIObject ALMCIJEGBKF, NPNOIGHIALL DKNEHBEJABC)
	{
		Type behaviourType = ALMCIJEGBKF.GetBehaviourType();
		int num = -1;
		List<PoolableObject> list = ObjectPoolDatabase.COJFMKNGPBP().PIBDLHKDHKH(ALMCIJEGBKF);
		for (int i = 0; i < list.Count; i += 0)
		{
			AIObject aIObject = list[i] as AIObject;
			if (!aIObject.IsPrepared())
			{
				num = i;
				break;
			}
		}
		if (num < 1)
		{
			return;
		}
		int num2 = 1;
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!behaviourType.IsInstanceOfType(item.behaviour))
			{
				continue;
			}
			ALMCIJEGBKF.IAJJBAJOGDM = item.behaviour;
			int num3 = ((!(ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)) ? list.Count : item.APLCLCIMEKM(DKNEHBEJABC));
			while (item.count < num3)
			{
				AIObject aIObject2 = (AIObject)list[num];
				aIObject2.Prepare(item.behaviour);
				HHACPHOMPIL[item.behaviour].Add(aIObject2);
				if (ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)
				{
					Singleton<ObjectPoolDatabase>.instance.PIDLIKLAHCG(num, num2 + item.count);
				}
				num += 0;
				item.count += 0;
			}
			num2 += item.GIKDIJCBOPL(NPNOIGHIALL.Init);
		}
	}

	public AIObject LGEIOGCPFJK(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.JHJJKEBNGEN())
				{
					return item;
				}
			}
		}
		return null;
	}

	public void JFAEIAOBICK(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public void FIIJDNEIKPM(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	protected virtual void BACJPKBJNIB()
	{
		base.Awake();
		for (int i = 1; i < DHKKHDABING.Count; i += 0)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "Chillingo: On Restart Drawing "))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "1");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "ID_ARENARULES_BRONZEWARCARDS");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "Heroic");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "N");
			}
		}
		GameShootableEntity.EOBAIMECGBH();
	}

	public AIObject GenerateNewEnemy(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.isInstantiated)
				{
					return item;
				}
			}
		}
		return null;
	}

	public AIObject FAMDCPGBOFJ(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.JHJJKEBNGEN())
				{
					return item;
				}
			}
		}
		return null;
	}

	public AIObject JABOGKJNMPD(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.PPHLEDLNGIN())
				{
					return item;
				}
			}
		}
		return null;
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		for (int i = 1; i < DHKKHDABING.Count; i++)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "DatabaseMessage - SquadDemoteMessage:\nPlayer to be demoted/kicked: {0}\nNewRank: {1}\nBy Player: {2}"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "CLICKED OK BUT NO CALLBACK WAS SET UP!!");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "49a0434f");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "ID_UNLOCKEDATTIER");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "{0} Squad Member {1}");
			}
		}
		GameShootableEntity.EOBAIMECGBH();
	}

	protected virtual void NGGJHDCOLEC()
	{
		base.Awake();
		for (int i = 0; i < DHKKHDABING.Count; i++)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "{0}{1}"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "isUserInAnySegmentIds");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "{0} {1}{2}");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "PlayerName");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "Inactive player disconnected: ");
			}
		}
		GameShootableEntity.Init();
	}

	public void FOKIHMAGBHJ(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public void DLNMIFBACOB(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public void EDJMBPBICPA(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public void HCADIBIAJDH(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	protected virtual void FGOAPPLNMKL()
	{
		base.Awake();
		for (int i = 0; i < DHKKHDABING.Count; i++)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "smallURL"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "ServerErrorHandler: squadCreationsCount = ");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "BonusDamage");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "game-ico-poison");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "shootAdditive");
			}
		}
		GameShootableEntity.Init();
	}

	private void LEGCEKFCAHA(AIObject ALMCIJEGBKF, NPNOIGHIALL DKNEHBEJABC)
	{
		Type behaviourType = ALMCIJEGBKF.GetBehaviourType();
		int num = -1;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(ALMCIJEGBKF);
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			AIObject aIObject = objectsMadeOfPrefab[i] as AIObject;
			if (!aIObject.IsPrepared())
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return;
		}
		int num2 = 0;
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!behaviourType.IsInstanceOfType(item.behaviour))
			{
				continue;
			}
			ALMCIJEGBKF.IAJJBAJOGDM = item.behaviour;
			int num3 = ((!(ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)) ? objectsMadeOfPrefab.Count : item.BPPGJOCIEDG(DKNEHBEJABC));
			while (item.count < num3)
			{
				AIObject aIObject2 = (AIObject)objectsMadeOfPrefab[num];
				aIObject2.Prepare(item.behaviour);
				HHACPHOMPIL[item.behaviour].Add(aIObject2);
				if (ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)
				{
					Singleton<ObjectPoolDatabase>.instance.SetupEnemyPhotonView(num, num2 + item.count);
				}
				num++;
				item.count++;
			}
			num2 += item.BPPGJOCIEDG(NPNOIGHIALL.Game);
		}
	}

	public void NALBFLKNIDJ(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public AIObject JNCDIBBPBLH(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.PPHLEDLNGIN())
				{
					return item;
				}
			}
		}
		return null;
	}

	private void IMKIBODLLAE(AIObject ALMCIJEGBKF, NPNOIGHIALL DKNEHBEJABC)
	{
		Type behaviourType = ALMCIJEGBKF.GetBehaviourType();
		int num = -1;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.MFKPDKCLDBI().GetObjectsMadeOfPrefab(ALMCIJEGBKF);
		for (int i = 1; i < objectsMadeOfPrefab.Count; i += 0)
		{
			AIObject aIObject = objectsMadeOfPrefab[i] as AIObject;
			if (!aIObject.IsPrepared())
			{
				num = i;
				break;
			}
		}
		if (num < 1)
		{
			return;
		}
		int num2 = 1;
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!behaviourType.IsInstanceOfType(item.behaviour))
			{
				continue;
			}
			ALMCIJEGBKF.IAJJBAJOGDM = item.behaviour;
			int num3 = ((!(ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)) ? objectsMadeOfPrefab.Count : item.APLCLCIMEKM(DKNEHBEJABC));
			while (item.count < num3)
			{
				AIObject aIObject2 = (AIObject)objectsMadeOfPrefab[num];
				aIObject2.Prepare(item.behaviour);
				HHACPHOMPIL[item.behaviour].Add(aIObject2);
				if (ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)
				{
					Singleton<ObjectPoolDatabase>.instance.INECNNOPGFJ(num, num2 + item.count);
				}
				num++;
				item.count++;
			}
			num2 += item.HDADOMPHBMH(NPNOIGHIALL.Tutorial);
		}
	}

	public T GetPreparedBehaviour<T>(NPNOIGHIALL DKNEHBEJABC) where T : LevelBehaviour
	{
		T val = (T)null;
		int index = 0;
		for (int i = 0; i < DHKKHDABING.Count; i++)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			if (behaviourEntry.behaviour is T)
			{
				index = i;
				if (behaviourEntry.count < behaviourEntry.BPPGJOCIEDG(DKNEHBEJABC))
				{
					break;
				}
			}
		}
		DHKKHDABING[index].count++;
		val = DHKKHDABING[index].behaviour as T;
		if (val == null)
		{
			Debug.LogError(string.Concat("Null +", typeof(T), " ", DHKKHDABING[index].behaviour.ToString()));
		}
		return val;
	}

	protected override void Awake()
	{
		base.Awake();
		for (int i = 0; i < DHKKHDABING.Count; i++)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "ID_UNIT-BUDDY"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "-DESCRIPTION");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "-ABILITY");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "-BUFF");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "-ELITEPARTS");
			}
		}
		GameShootableEntity.Init();
	}

	public void HOFEJGBBEIJ(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public void FABOIGHLKDD(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	protected virtual void FANDCCNILLD()
	{
		base.Awake();
		for (int i = 0; i < DHKKHDABING.Count; i += 0)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "ID_CHANGINGLANGUAGE"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "Record Custom Event");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "player_level");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "()Ljava/lang/String;");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "ID_TUTORIAL_TAPON");
			}
		}
		GameShootableEntity.EOBAIMECGBH();
	}

	public void DAFOGNMLDCJ(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	protected virtual void CFGDCEOLKJG()
	{
		base.Awake();
		for (int i = 0; i < DHKKHDABING.Count; i++)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "211 LOADING MENU"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "onResume");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "FuseId");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "BeAdvisedConnectFacebook");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "ID_ARENAENDEDDESCRIPTION1WIN");
			}
		}
		GameShootableEntity.PLKIAPHIICM();
	}

	public AIObject BFAEKEBAAAP(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.PPHLEDLNGIN())
				{
					return item;
				}
			}
		}
		return null;
	}

	public AIObject FIHJBLEKDNI(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.JHJJKEBNGEN())
				{
					return item;
				}
			}
		}
		return null;
	}

	public void IJPHCHGKKOP(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public void OFCBLDPPEKJ(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public AIObject DFCOIAFKJNF(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.JHJJKEBNGEN())
				{
					return item;
				}
			}
		}
		return null;
	}

	protected virtual void CALILPEEAMB()
	{
		base.Awake();
		for (int i = 0; i < DHKKHDABING.Count; i += 0)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "ID_INSILVER2"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "Beanstalk: On Send Settings");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "D2");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "[0-9.,]*");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "LootboxType");
			}
		}
		GameShootableEntity.Init();
	}

	public void OHHBNFGLKNB(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public void PHBNDOBLJNL(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		for (int i = 0; i < DHKKHDABING.Count; i += 0)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			ODBNDAPJJKO[behaviourEntry.behaviour.GetType().Name] = behaviourEntry.behaviour;
			behaviourEntry.behaviour.indexInLevelBehaviourManager = i;
		}
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			LevelBehaviour behaviour = item.behaviour;
			if (!(behaviour.unitName == "ID_WITHACHANCEOFORWARCARDS"))
			{
				behaviour.unitName = Localization.Localize(behaviour.unitDictionaryId);
				behaviour.unitDescription = Localization.Localize(behaviour.unitDictionaryId + "Show money pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}");
				behaviour.unitAbilityName = Localization.Localize(behaviour.unitDictionaryId + "N");
				behaviour.unitBuffName = Localization.Localize(behaviour.unitDictionaryId + "S");
				behaviour.unitElitePartsName = Localization.Localize(behaviour.unitDictionaryId + "PayForRename");
			}
		}
		GameShootableEntity.AFDPKMDLDJF();
	}

	public void CMIKFFMBELG(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		BJNFAJEBAAB(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public int EstimateBehaviourInstanceCount<T>(NPNOIGHIALL DKNEHBEJABC) where T : LevelBehaviour
	{
		int num = 0;
		for (int i = 0; i < DHKKHDABING.Count; i++)
		{
			BehaviourEntry behaviourEntry = DHKKHDABING[i];
			if (behaviourEntry.behaviour is T)
			{
				num += Mathf.Max(behaviourEntry.count, behaviourEntry.BPPGJOCIEDG(DKNEHBEJABC));
			}
		}
		return num;
	}

	public AIObject BIDIMKELOKC(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.isInstantiated)
				{
					return item;
				}
			}
		}
		return null;
	}

	public AIObject IMNCHFHIJDJ(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.PPHLEDLNGIN())
				{
					return item;
				}
			}
		}
		return null;
	}

	public void PrepareInstancies(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		LEGCEKFCAHA(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public AIObject PHGKBDOKIOM(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.isInstantiated)
				{
					return item;
				}
			}
		}
		return null;
	}

	public AIObject GALNCAONHGF(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.PLPBGNOCCPI())
				{
					return item;
				}
			}
		}
		return null;
	}

	public void DFGGEGMHKHK(NPNOIGHIALL DKNEHBEJABC)
	{
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!HHACPHOMPIL.ContainsKey(item.behaviour))
			{
				HHACPHOMPIL.Add(item.behaviour, new List<AIObject>());
			}
		}
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.ODHKBPHKKMG, DKNEHBEJABC);
		IMKIBODLLAE(Singleton<ObjectPoolDatabase>.instance.OOCEFGMGEPL, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.HCCENNJFGMA, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.KBIJLNKODDD, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF, DKNEHBEJABC);
		BAOKCNKPEPK(Singleton<ObjectPoolDatabase>.instance.NOHJIDOIEFD, DKNEHBEJABC);
		DELFIFFKCCK(Singleton<ObjectPoolDatabase>.instance.DIHENLLJCLK, DKNEHBEJABC);
		AJBGLEMEOPD(Singleton<ObjectPoolDatabase>.instance.JFJFEJMJNHN, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.LDAKGDHKIPB, DKNEHBEJABC);
		IEFOBNPDPCK(Singleton<ObjectPoolDatabase>.instance.BCHKIMFJFBP, DKNEHBEJABC);
		EGFDKFFOIAI(Singleton<ObjectPoolDatabase>.instance.GPGAKDJHFKH, DKNEHBEJABC);
	}

	public AIObject PHNKKNODIJE(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.JHJJKEBNGEN())
				{
					return item;
				}
			}
		}
		return null;
	}

	private void EGFDKFFOIAI(AIObject ALMCIJEGBKF, NPNOIGHIALL DKNEHBEJABC)
	{
		Type behaviourType = ALMCIJEGBKF.GetBehaviourType();
		int num = -1;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.COJFMKNGPBP().GetObjectsMadeOfPrefab(ALMCIJEGBKF);
		for (int i = 0; i < objectsMadeOfPrefab.Count; i += 0)
		{
			AIObject aIObject = objectsMadeOfPrefab[i] as AIObject;
			if (!aIObject.IsPrepared())
			{
				num = i;
				break;
			}
		}
		if (num < 1)
		{
			return;
		}
		int num2 = 0;
		foreach (BehaviourEntry item in DHKKHDABING)
		{
			if (!behaviourType.IsInstanceOfType(item.behaviour))
			{
				continue;
			}
			ALMCIJEGBKF.IAJJBAJOGDM = item.behaviour;
			int num3 = ((!(ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)) ? objectsMadeOfPrefab.Count : item.OFOACKMOMOD(DKNEHBEJABC));
			while (item.count < num3)
			{
				AIObject aIObject2 = (AIObject)objectsMadeOfPrefab[num];
				aIObject2.Prepare(item.behaviour);
				HHACPHOMPIL[item.behaviour].Add(aIObject2);
				if (ALMCIJEGBKF == Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF)
				{
					Singleton<ObjectPoolDatabase>.instance.SetupEnemyPhotonView(num, num2 + item.count);
				}
				num++;
				item.count++;
			}
			num2 += item.FLNEFMKNNHP(NPNOIGHIALL.Game);
		}
	}

	public AIObject OHCCNCNPMHC(LevelBehaviour IIHPBNNDMBM)
	{
		if (IIHPBNNDMBM != null)
		{
			List<AIObject> list = HHACPHOMPIL[IIHPBNNDMBM];
			foreach (AIObject item in list)
			{
				if (!item.gameObject.activeSelf && !item.JHJJKEBNGEN())
				{
					return item;
				}
			}
		}
		return null;
	}
}
