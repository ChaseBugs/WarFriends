using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

[Serializable]
public abstract class GameReward
{
	public enum GEPEKLMNNHC
	{
		None,
		VIP,
		Facebook
	}

	private sealed class DCFLCFNNCOI
	{
		public Action<bool> NGEGENLCNLH;

		public List<GameReward> ABOEGDGLNLK;

		public int BONKONCCPFB;

		public Action<bool> KEMNDKHBAFO;

		internal void ECKKLGEKOMI(bool PNEJLHLMEPK)
		{
		}
	}

	public int amount;

	public GEPEKLMNNHC doubleFor;

	public bool DoubleForTransition;

	private static Dictionary<int, Type> mRewardTypes;

	public abstract int id { get; }

	protected int mClaimAmount => 0;

	public virtual bool RequiresConfirmationBeforeClaiming => false;

	public static GameReward OMNEIDMLPON(int NKHNGJIAFIK, int CNGKNKOKOID, JToken HAHCDAPFIGJ, bool GICCAKMCBAB = false, bool JKPHNKBOCMM = false)
	{
		return null;
	}

	public static GameReward OMNEIDMLPON(GameRewardData HAHCDAPFIGJ, bool GICCAKMCBAB = false, bool JKPHNKBOCMM = false)
	{
		return null;
	}

	protected virtual void MCPNPNIMGHI()
	{
	}

	public abstract void EABADGGFAJH();

	public virtual void KPPOKHBNOIK(Action<bool> NGEGENLCNLH)
	{
	}

	public static void MHGCBFPEALC(IEnumerable<GameReward> HIGCJPDLNGE, Action<bool> NGEGENLCNLH)
	{
	}
}
