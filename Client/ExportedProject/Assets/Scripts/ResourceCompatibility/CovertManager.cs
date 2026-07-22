using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

public class CovertManager : DatabaseSerializedObjectGeneric<CovertManager.CovertSlotData>
{
	[Preserve]
	public class CovertSlotData
	{
		public string unit;
	}

	private static CovertManager mInstance;

	private LevelBehaviour mNewCovertUnit;

	public static CovertManager instance => null;

	public LevelBehaviour covertUnit
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public LevelBehaviour newCovertUnit
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void OnDestroy()
	{
	}

	protected override void Load(JToken dictionary)
	{
	}

	protected override void InitData()
	{
	}
}
