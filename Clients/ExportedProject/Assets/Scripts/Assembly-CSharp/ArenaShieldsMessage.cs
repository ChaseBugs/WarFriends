using UnityEngine;

public class ArenaShieldsMessage : DatabaseMessage
{
	public ArenaShieldsMessage()
		: base("ArenaShieldsMessage", Type.ArenaShieldsMessage)
	{
		messageId += string.Format("-{0}", (WarArena.instance.data != null) ? WarArena.instance.data.arenaId : "null");
	}

	public override void Show()
	{
		base.Show();
		Debug.Log("Show arena golden shield tutorial - pop-up");
	}
}
