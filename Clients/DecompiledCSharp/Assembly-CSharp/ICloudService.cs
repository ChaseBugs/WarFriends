using System.Collections.Generic;
using UnityEngine;

public class ICloudService
{
	private void OnSync(List<object> dictionary)
	{
	}

	public void SavePlayer(GameLoginManager.PlayerAccount playerAccount)
	{
		Debug.Log("iCloud: Save Player!");
	}

	public GameLoginManager.PlayerAccount GetPlayer()
	{
		return null;
	}

	public void DeletePlayer()
	{
	}

	public void TestICloud()
	{
	}
}
