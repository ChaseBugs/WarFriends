using System.Collections.Generic;
using Google2u;

public abstract class UpgradeSlotsGeneric<T> : UpgradeSlots where T : Google2uComponentBase
{
	private T LMHLKPKKJBP;

	public T databaseObject
	{
		get
		{
			if (LMHLKPKKJBP == null)
			{
				LMHLKPKKJBP = GetComponent<T>();
			}
			return LMHLKPKKJBP;
		}
	}

	public override UnitUpgrades LoadData(LevelBehaviour ACLDFHJKBLI, UnitUpgrades? PPNBMKCHBKA = null, FCLADBGKCIA IGKDFJKEELP = null)
	{
		UnitUpgrades result = new UnitUpgrades(1f);
		if (ACLDFHJKBLI != null)
		{
			BehaviourDefinititon behaviourDefinititon = ACLDFHJKBLI.baseBehaviourDefinititon.HIGKMHJIFJF();
			behaviourDefinititon.shotSpeed = base.bulletSpeed;
			behaviourDefinititon.speed = base.movementSpeed;
			behaviourDefinititon.KFLADKOLPCM();
			if (PPNBMKCHBKA.HasValue)
			{
				result = PPNBMKCHBKA.Value;
			}
			else
			{
				result.slotUpgradeindex = upgradeSlot.boughtIndexAbsolute;
				result.slotUpgradeIndexSpecial = upgradeSlotSpecial.boughtIndexAbsolute;
				result.slotUpgradeIndexElite = upgradeSlotElite.boughtIndexAbsolute;
				result.isSpecial = upgradeSlotSpecial.isBought;
				result.isElite = upgradeSlotElite.isBought;
			}
			List<int> list = new List<int>();
			list.Add(result.slotUpgradeindex);
			List<int> list2 = list;
			if (result.isSpecial)
			{
				list2.Add(result.slotUpgradeIndexSpecial);
			}
			if (result.isElite)
			{
				list2.Add(result.slotUpgradeIndexElite);
			}
			foreach (int item in list2)
			{
				IPGEHGPGGKL(behaviourDefinititon, item);
			}
			if (IGKDFJKEELP != null)
			{
				behaviourDefinititon.KJOPPNIAKIN(IGKDFJKEELP);
			}
			ACLDFHJKBLI.behaviourDefinition = behaviourDefinititon;
		}
		return result;
	}

	protected virtual void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
	}
}
