using UnityEngine;

public class TagsAndLayers : Singleton<TagsAndLayers>
{
	public static string mapDefinition = "MapDefinition";

	public static int destroyableEntitiesLayerNumber = 8;

	public static int aimingHelpLayerNumber = 10;

	public static int staticlayerNum = 13;

	public static int t4mObj = 30;

	public static int bulletsIgnoreLayer = 14;

	public static int collideOnlyEnviroment = 15;

	public static int dontCollideLayer = 16;

	public static int destroyableEntitiesAlliesLayerNumber = 22;

	public static int destroyableEntitiesEnemiesLayerNumber = 23;

	public static int destroyableEntitiesShieldLayerNumber = 24;

	public static int destroyableEntitiesAlliesMechLayerNumber = 26;

	public static int destroyableEntitiesEnemiesMechLayerNumber = 27;

	public static int destroyableObjectsMask = (1 << destroyableEntitiesLayerNumber) | (1 << destroyableEntitiesAlliesLayerNumber) | (1 << destroyableEntitiesEnemiesLayerNumber) | (1 << destroyableEntitiesShieldLayerNumber) | (1 << destroyableEntitiesEnemiesMechLayerNumber) | (1 << destroyableEntitiesAlliesMechLayerNumber);

	public static int staticLayerMask = (1 << staticlayerNum) | (1 << t4mObj);

	public LayerMask bulletMask;

	public LayerMask alliesBulletMask;

	public LayerMask enemiesBulletMask;

	public static bool IsStatic(GameObject o)
	{
		return o.layer == staticlayerNum || o.layer == t4mObj;
	}

	public static bool IsDestroyableObject(GameObject o)
	{
		int layer = o.layer;
		return layer == destroyableEntitiesLayerNumber || layer == destroyableEntitiesAlliesLayerNumber || layer == destroyableEntitiesEnemiesLayerNumber || layer == destroyableEntitiesShieldLayerNumber || layer == destroyableEntitiesEnemiesMechLayerNumber || layer == destroyableEntitiesAlliesMechLayerNumber;
	}

	public LayerMask GetBulletMask(Fractions fraction, int ignoreLayersMask)
	{
		return fraction switch
		{
			Fractions.Enemies => (int)enemiesBulletMask & ~ignoreLayersMask, 
			Fractions.Allies => (int)alliesBulletMask & ~ignoreLayersMask, 
			_ => (int)bulletMask & ~ignoreLayersMask, 
		};
	}

	public int GetFractionBulletLayer(Fractions fraction, bool isFlying)
	{
		return fraction switch
		{
			Fractions.Enemies => (!isFlying) ? destroyableEntitiesEnemiesLayerNumber : destroyableEntitiesEnemiesMechLayerNumber, 
			Fractions.Allies => (!isFlying) ? destroyableEntitiesAlliesLayerNumber : destroyableEntitiesAlliesMechLayerNumber, 
			_ => destroyableEntitiesLayerNumber, 
		};
	}
}
