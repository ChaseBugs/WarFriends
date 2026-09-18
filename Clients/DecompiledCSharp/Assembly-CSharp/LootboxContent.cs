using System.Collections.Generic;

public class LootboxContent
{
	public string visualId;

	public int parts;

	public bool isVip;

	public PlayerVisual playerVisual => (!string.IsNullOrEmpty(visualId)) ? CamosManager.instance.GetVisual(visualId) : null;

	public string debugString => string.Format("{0} : {1} - {2}", visualId, parts, (!isVip) ? "isNormal" : "isVip");

	public LootboxContent(string id, int number, bool vip = false)
	{
		visualId = id;
		parts = number;
		isVip = vip;
	}

	public static List<LootboxContent> getLootboxes(Dictionary<string, string> visualsList)
	{
		List<LootboxContent> list = new List<LootboxContent>();
		foreach (KeyValuePair<string, string> visuals in visualsList)
		{
			string text = visuals.Key;
			bool vip = text.EndsWith("-VIP");
			if (text.IndexOf("_#") != -1)
			{
				text = text.Substring(0, text.IndexOf("_#"));
			}
			if (text.EndsWith("-VIP"))
			{
				text = text.Substring(0, text.IndexOf("-VIP"));
			}
			list.Add(new LootboxContent(text, int.Parse(visuals.Value), vip));
			if (!list[list.Count - 1].playerVisual.isBought)
			{
				list[list.Count - 1].playerVisual.notificate = true;
			}
		}
		return list;
	}
}
