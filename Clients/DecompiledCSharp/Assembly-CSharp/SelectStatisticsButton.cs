using UnityEngine;

public class SelectStatisticsButton : Core_BaseScript
{
	[Header("Players vs Squad")]
	public GameObject playerSquadGO;

	public UILabel players;

	public UILabel squads;

	public UISprite selectBox;

	public UITable table;

	public BoxCollider boxCollider;

	[Header("Global vs Local")]
	public GameObject globalLocalGO;

	public UILabel global;

	public UILabel local;

	public UISprite globalLocalSprite;

	public UITable globalLocalTable;

	public BoxCollider globalLocalCollider;

	private bool mPlayerSquadInitialized;

	private bool mGlobalLocalInitialized;

	private float mSpaceBetween = 60f;

	public void Initialize()
	{
		mPlayerSquadInitialized = false;
		mGlobalLocalInitialized = false;
		table.repositionNow = true;
		table.onReposition = delegate
		{
			float x = squads.transform.parent.transform.localPosition.x;
			float x2 = table.padding.x;
			playerSquadGO.transform.localPosition = new Vector3(0f - x, playerSquadGO.transform.localPosition.y, 0f);
			boxCollider.center = new Vector3((x - x2) / 2f + x2, boxCollider.center.y, boxCollider.center.z);
			boxCollider.size = new Vector3(x - x2, boxCollider.size.y, boxCollider.size.z);
			mPlayerSquadInitialized = true;
			InitializeSpace();
		};
		globalLocalTable.repositionNow = true;
		globalLocalTable.onReposition = delegate
		{
			float x = local.transform.parent.transform.localPosition.x;
			float x2 = globalLocalTable.padding.x;
			globalLocalCollider.center = new Vector3((x - x2) / 2f + x2, boxCollider.center.y, boxCollider.center.z);
			globalLocalCollider.size = new Vector3(x - x2, globalLocalCollider.size.y, globalLocalCollider.size.z);
			mGlobalLocalInitialized = true;
			InitializeSpace();
		};
	}

	private void InitializeSpace()
	{
		if (mPlayerSquadInitialized && mGlobalLocalInitialized)
		{
			float num = local.transform.parent.transform.localPosition.x + mSpaceBetween + squads.transform.parent.transform.localPosition.x;
			globalLocalGO.transform.localPosition = new Vector3(0f - num, globalLocalGO.transform.localPosition.y, 0f);
		}
	}

	public void Select(bool playerSelected)
	{
		players.color = ((!playerSelected) ? Colours.grayButton : Colours.blue);
		squads.color = ((!playerSelected) ? Colours.blue : Colours.grayButton);
		selectBox.transform.localPosition = new Vector3((!playerSelected) ? 30f : (-30f), 0f, 0f);
	}

	public void SelectGlobalLocal(bool globalSelected)
	{
		global.color = ((!globalSelected) ? Colours.grayButton : Colours.blue);
		local.color = ((!globalSelected) ? Colours.blue : Colours.grayButton);
		globalLocalSprite.transform.localPosition = new Vector3((!globalSelected) ? 30f : (-30f), 0f, 0f);
	}
}
