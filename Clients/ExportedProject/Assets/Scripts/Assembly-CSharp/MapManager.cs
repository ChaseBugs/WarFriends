using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
	[Serializable]
	public class MapEntry
	{
		public int id;

		public string name;

		public string levelSingleName;

		public string levelPVPName;

		public string guiName;

		public string iconName;

		public int unlockLevel;

		public bool local;

		public string bundleNameSingle;

		public string bundleNameMultiplayer;

		public bool unlocked => LevelManager.instance.currentLevel.displayNumber >= unlockLevel || DebugSettings.debugEnabled;

		public string sceneName
		{
			get
			{
				if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCampaign)
				{
					return levelSingleName;
				}
				return levelPVPName;
			}
		}
	}

	public MapDefinition currentMapDef;

	public bool levelIsChanging;

	public List<MapEntry> mapEntries;

	private AsyncOperation async;

	private MapEntry mCurrentMap;

	private bool mIsRandom;

	private List<Transform> transforms = new List<Transform>();

	public MapEntry currentMap
	{
		get
		{
			if (mCurrentMap == null)
			{
				mCurrentMap = mapEntries[0];
			}
			return mCurrentMap;
		}
		set
		{
			mCurrentMap = value;
			mIsRandom = false;
		}
	}

	public bool isRandomMap => mIsRandom;

	public int unlockedmaps
	{
		get
		{
			int num = 0;
			foreach (MapEntry mapEntry in mapEntries)
			{
				if (mapEntry.unlocked)
				{
					num++;
				}
			}
			return num;
		}
	}

	public float loadProgress => async.progress;

	public List<MapEntry> mapUnlocks
	{
		get
		{
			List<MapEntry> list = new List<MapEntry>();
			foreach (MapEntry mapEntry in mapEntries)
			{
				if (mapEntry.unlockLevel == LevelManager.instance.currentLevel.displayNumber)
				{
					list.Add(mapEntry);
				}
			}
			return list;
		}
	}

	public event Action NewLevelLoaded;

	public void SetRandomMap()
	{
		mIsRandom = true;
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry mapEntry in mapEntries)
		{
			if (mapEntry.unlocked)
			{
				list.Add(mapEntry);
			}
		}
		if (list.Count == 0)
		{
			list.Add(mapEntries[0]);
		}
		mCurrentMap = list[UnityEngine.Random.Range(0, list.Count)];
	}

	public void SelectCurrentMap(string mapName)
	{
		foreach (MapEntry mapEntry in mapEntries)
		{
			if (mapEntry.name == mapName)
			{
				currentMap = mapEntry;
				break;
			}
		}
	}

	public void SelectCurrentMap(int id)
	{
		currentMap = mapEntries[id];
	}

	protected override void Awake()
	{
		base.Awake();
		GetCurrentMapDefinition();
		currentMap = mapEntries[0];
		foreach (MapEntry mapEntry in mapEntries)
		{
			mapEntry.guiName = Localization.Localize(mapEntry.guiName);
		}
	}

	private void GetCurrentMapDefinition()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(TagsAndLayers.mapDefinition);
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			MapDefinition component = gameObject.GetComponent<MapDefinition>();
			if (component != null && component != currentMapDef)
			{
				currentMapDef = component;
				currentMapDef.Init();
			}
		}
	}

	public void LoadNewlevel(string levelName)
	{
		StartCoroutine(Load(levelName));
		levelIsChanging = true;
	}

	public MapEntry GetSceneName(string levelName)
	{
		foreach (MapEntry mapEntry in mapEntries)
		{
			if (mapEntry.name == levelName)
			{
				return mapEntry;
			}
		}
		Debug.LogError("Scene could not be find");
		return null;
	}

	private void FindChild(Transform tr)
	{
		foreach (Transform item in tr)
		{
			FindChild(item);
		}
		transforms.Add(tr);
	}

	public void DestroyCurrentScene()
	{
		if (currentMapDef != null)
		{
			UnityEngine.Object.Destroy(currentMapDef.gameObject);
			currentMapDef = null;
		}
	}

	public void DeactivateScene()
	{
		if (currentMapDef != null)
		{
			currentMapDef.gameObject.SetActive(value: false);
		}
	}

	public IEnumerator Load(string levelName)
	{
		MapEntry mapEntry = Singleton<MapManager>.instance.GetSceneName(levelName);
		if (currentMapDef == null || currentMapDef.levelName != mapEntry.sceneName)
		{
			Debug.Log("Load map");
			if (currentMapDef != null && currentMapDef.gameObject != null)
			{
				UnityEngine.Object.Destroy(currentMapDef.gameObject);
			}
			Application.backgroundLoadingPriority = ThreadPriority.High;
			AsyncOperation async = Application.LoadLevelAsync(mapEntry.sceneName);
			async.allowSceneActivation = true;
			yield return async;
			Debug.Log("GetCurrentMapDefinition");
			GetCurrentMapDefinition();
		}
		if (this.NewLevelLoaded != null)
		{
			this.NewLevelLoaded();
		}
		Debug.Log("Map Loaded");
		yield return null;
	}

	public void ResyncShields()
	{
		foreach (MapDefinition.DefendPosition playersPosition in currentMapDef.playersPositions)
		{
			playersPosition.point.shield.Resync();
		}
	}
}
