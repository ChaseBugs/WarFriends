using System;
using System.Collections.Generic;
using UnityEngine;

public class MapDefinition : MonoBehaviour
{
	[Serializable]
	public class DefendPosition
	{
		public PlayerPoint point;

		public Fractions fraction;

		public CameraPathAnimator cameraPath;

		public bool mainPosition;

		public int index;
	}

	public Texture2D mineMatCapTexture;

	public Texture2D opponentsMatCapTexture;

	public SpawnPointsCollection spawnPointsCollection;

	public EnemyPointsCollection enemyPointsCollection;

	public string levelName;

	public SpawnPointsCollection spawnPointsCollectionDrones;

	public SpawnPointsCollection spawnPointsCollectionAssaultHelis;

	public SpawnPointsCollection spawnPointsCollectionCars;

	public SpawnPointsCollection spawnPointsCollectionHelicopters;

	public Transform floorTransform;

	public List<DefendPosition> playersPositions;

	public List<BoxCollider> spawnAreas;

	public BoxCollider fieldArea;

	public bool useWater;

	public Plane floorPlane;

	public bool moveElectricTraps;

	public List<DefendPosition> availablePoints => playersPositions;

	private void Awake()
	{
		base.gameObject.tag = TagsAndLayers.mapDefinition;
		floorPlane = new Plane(Vector3.up, floorTransform.position);
	}

	public void Init()
	{
		for (int i = 0; i < playersPositions.Count; i++)
		{
			DefendPosition defendPosition = playersPositions[i];
			defendPosition.index = i;
			defendPosition.point.shield.fraction = defendPosition.fraction;
		}
	}

	public void InitShields()
	{
		for (int i = 0; i < playersPositions.Count; i++)
		{
			DefendPosition defendPosition = playersPositions[i];
			defendPosition.point.shield.Init();
		}
	}
}
