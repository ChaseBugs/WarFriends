using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerTexturePool : Singleton<PlayerTexturePool>
{
	public enum RenderType
	{
		Small,
		Card,
		Classic
	}

	protected class PlayerTexturePoolItem
	{
		public DatabasePlayer databasePlayer;

		public bool useBackground;

		public Texture2D texture;

		public RenderType type;

		public int referenceCount;

		public bool processing;

		public string visuals = string.Empty;

		public PlayerTexturePoolItem(Texture2D texture)
		{
			this.texture = texture;
			useBackground = true;
		}
	}

	public int capacity;

	private List<PlayerTexturePoolItem> mPlayerTextures;

	private List<PlayerTexturePoolItem> mQueue;

	private List<PlayerTexturePoolItem> mPool;

	private bool mQueueActive;

	private StringBuilder mVisuals = new StringBuilder();

	public event Action<string, Texture2D, bool> OnPlayerTextureCreated;

	protected override void Awake()
	{
		base.Awake();
		mPlayerTextures = new List<PlayerTexturePoolItem>(capacity);
		mQueue = new List<PlayerTexturePoolItem>();
		mPool = new List<PlayerTexturePoolItem>(capacity);
		if (Singleton<PerformanceManager>.instance.performance != Performance.Shitty && Singleton<PerformanceManager>.instance.isHD)
		{
			Singleton<ArmyPreviewCamera>.instance.playerTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
		}
		for (int i = 0; i < capacity; i++)
		{
			Texture2D texture2D = new Texture2D(Singleton<ArmyPreviewCamera>.instance.playerTexture.width, Singleton<ArmyPreviewCamera>.instance.playerTexture.height, TextureFormat.ARGB32, mipChain: true);
			texture2D.wrapMode = TextureWrapMode.Clamp;
			mPool.Add(new PlayerTexturePoolItem(texture2D));
		}
	}

	private IEnumerator PlayerTextureRenderQueue()
	{
		mQueueActive = true;
		while (mQueue.Count > 0)
		{
			PlayerTexturePoolItem queueItem = mQueue[0];
			queueItem.processing = true;
			yield return StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CreatePlayerTexture(queueItem.databasePlayer, queueItem.texture, queueItem.useBackground, queueItem.type));
			queueItem.processing = false;
			mQueue.Remove(queueItem);
			if (queueItem.referenceCount <= 0)
			{
				mPool.Add(queueItem);
				continue;
			}
			mPlayerTextures.Add(queueItem);
			if (this.OnPlayerTextureCreated != null)
			{
				this.OnPlayerTextureCreated(queueItem.databasePlayer.id, queueItem.texture, queueItem.useBackground);
			}
		}
		mQueueActive = false;
	}

	private PlayerTexturePoolItem GetPoolItem()
	{
		PlayerTexturePoolItem playerTexturePoolItem = null;
		if (mPool.Count > 0)
		{
			playerTexturePoolItem = mPool[0];
			mPool.RemoveAt(0);
		}
		else
		{
			Debug.LogWarning("Increasing texture count in player texture pool!");
			playerTexturePoolItem = new PlayerTexturePoolItem(new Texture2D(Singleton<ArmyPreviewCamera>.instance.playerTexture.width, Singleton<ArmyPreviewCamera>.instance.playerTexture.height));
		}
		return playerTexturePoolItem;
	}

	private string GetVisualsString(DatabasePlayer player)
	{
		mVisuals.Length = 0;
		if (player != null && player.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in player.playerVisuals)
			{
				mVisuals.Append(playerVisual.Value.equippedID);
			}
		}
		return mVisuals.ToString();
	}

	private bool TryGetPlayerTexture(DatabasePlayer player, bool useBackground, out PlayerTexturePoolItem playerTexture)
	{
		string visualsString = GetVisualsString(player);
		foreach (PlayerTexturePoolItem mPlayerTexture in mPlayerTextures)
		{
			if (mPlayerTexture.databasePlayer.id == player.id && mPlayerTexture.useBackground == useBackground && visualsString == mPlayerTexture.visuals)
			{
				playerTexture = mPlayerTexture;
				if (mPlayerTexture.referenceCount == 0)
				{
					mPool.Remove(mPlayerTexture);
				}
				return true;
			}
		}
		playerTexture = null;
		return false;
	}

	public int RequestPlayerTexture(DatabasePlayer player, bool useBackground = true, RenderType type = RenderType.Small)
	{
		int result = -1;
		if (!TryGetPlayerTexture(player, useBackground, out var playerTexture))
		{
			bool flag = false;
			foreach (PlayerTexturePoolItem item in mQueue)
			{
				if (item.databasePlayer.id == player.id && item.useBackground == useBackground)
				{
					flag = true;
					result = ++item.referenceCount;
					break;
				}
			}
			if (!flag)
			{
				PlayerTexturePoolItem poolItem = GetPoolItem();
				mPlayerTextures.Remove(poolItem);
				poolItem.databasePlayer = player;
				poolItem.visuals = GetVisualsString(player);
				poolItem.useBackground = useBackground;
				poolItem.type = type;
				mQueue.Add(poolItem);
				result = ++poolItem.referenceCount;
				if (!mQueueActive)
				{
					StartCoroutine(PlayerTextureRenderQueue());
				}
			}
		}
		else
		{
			result = ++playerTexture.referenceCount;
			if (this.OnPlayerTextureCreated != null)
			{
				this.OnPlayerTextureCreated(player.id, playerTexture.texture, useBackground);
			}
		}
		return result;
	}

	public int FreePlayerTexture(string playerID, bool useBackground = true, bool ignoreWarnings = false, bool deleteFromPool = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = playerID;
		DatabasePlayer player = databasePlayer;
		return FreePlayerTexture(player, useBackground, ignoreWarnings, deleteFromPool);
	}

	public int FreePlayerTexture(DatabasePlayer player, bool useBackground = true, bool ignoreWarnings = false, bool deleteFromPool = false)
	{
		int result = 1234;
		if (TryGetPlayerTexture(player, useBackground, out var playerTexture))
		{
			result = playerTexture.referenceCount - 1;
			if (--playerTexture.referenceCount <= 0)
			{
				if (deleteFromPool)
				{
					mPlayerTextures.Remove(playerTexture);
				}
				else
				{
					playerTexture.referenceCount = 0;
				}
				mPool.Add(playerTexture);
			}
		}
		else
		{
			bool flag = false;
			foreach (PlayerTexturePoolItem item in mQueue)
			{
				if (item.databasePlayer.id == player.id && item.useBackground == useBackground)
				{
					result = --item.referenceCount;
					if (item.referenceCount < 0 && !ignoreWarnings)
					{
						Debug.LogError("Texture reference count is less than zero!");
					}
					if (item.referenceCount <= 0 && !item.processing)
					{
						mQueue.Remove(item);
						mPool.Add(item);
					}
					flag = true;
					break;
				}
			}
			if (!flag && !ignoreWarnings)
			{
				result = 0;
			}
		}
		return result;
	}
}
