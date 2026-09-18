using System.Collections.Generic;

public class PistolLevelsSetup : WeaponLevelsSetup<PistolLevelDefinition>
{
	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(statsFor(slot, "attack", "ID_SLOTUPGRADE_DAMAGE"));
		list.Add(statsFor(slot, "clipSize", "ID_SLOTUPGRADE_CLIP_SIZE"));
		list.Add(statsFor(slot, "reloadTime", "ID_SLOTUPGRADE_ROF"));
		return list;
	}
}
