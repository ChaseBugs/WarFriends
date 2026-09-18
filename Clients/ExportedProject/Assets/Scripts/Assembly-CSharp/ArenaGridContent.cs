using System.Collections.Generic;
using UnityEngine;

public class ArenaGridContent : Core_BaseScript
{
	public ArenaNode[] nodes;

	public UISprite[] innerNodeSprites;

	public UISprite glow;

	private float mGridWidth => UIRoot.list[0].activeWidth - leftPadding - rightPadding;

	private float mGridXPositionCore => 0f - UIRoot.list[0].activeWidth * 0.5f + leftPadding;

	public static float leftPadding => (!((double)ratio > 1.7)) ? 60 : 100;

	public static float rightPadding => 150f;

	public static float ratio => (float)Screen.width / (float)Screen.height;

	public void ResizeNodes(int battles)
	{
		UIGrid component = GetComponent<UIGrid>();
		float num = mGridWidth / (float)(battles * 2 + 1);
		float val = num * 2f - 92f;
		for (int i = battles; i < nodes.Length; i++)
		{
			innerNodeSprites[i].gameObject.SetActive(value: false);
			nodes[i].gameObject.SetActive(value: false);
		}
		component.cellWidth = num;
		base.transform.localPosition = component.transform.localPosition.ReplaceXY(mGridXPositionCore + num * 0.5f, (!(ratio > 1.7f)) ? (-52f) : 0f);
		glow.transform.localPosition = glow.transform.localPosition.ReplaceY((!(ratio > 1.7f)) ? (-52f) : 0f);
		UISprite[] array = innerNodeSprites;
		foreach (UISprite uISprite in array)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(val);
		}
		component.repositionNow = true;
	}

	public void SetNodes(bool completed, List<WarArenaConfig.Node> arenaNodes = null)
	{
		if (completed && arenaNodes != null)
		{
			int num = WarArena.instance.data.wins;
			for (int i = 0; i < ((!GuiScreenSingle<ArenaScreen>.instance.haveWon) ? num : (num - 1)); i++)
			{
				nodes[i].SetCompletedOrReward(win: true, arenaNodes[i].lootBoxType, arenaNodes[i].visualType);
			}
			return;
		}
		ArenaNode[] array = nodes;
		foreach (ArenaNode arenaNode in array)
		{
			arenaNode.SetEmpty();
		}
	}

	public void SetRewards(List<WarArenaConfig.Node> arenaNodes)
	{
		int num = 0;
		for (int i = 0; i < arenaNodes.Count; i++)
		{
			if (arenaNodes[i].lootBoxType != WarArenaConfig.LootBoxType.None)
			{
				nodes[i].SetCompletedOrReward(win: false, arenaNodes[i].lootBoxType, arenaNodes[i].visualType, num);
				num++;
			}
		}
	}

	public void Clear()
	{
		ArenaNode[] array = nodes;
		foreach (ArenaNode arenaNode in array)
		{
			arenaNode.gameObject.SetActive(value: true);
		}
		UISprite[] array2 = innerNodeSprites;
		foreach (UISprite uISprite in array2)
		{
			uISprite.gameObject.SetActive(value: true);
		}
		SetNodes(completed: false);
	}
}
