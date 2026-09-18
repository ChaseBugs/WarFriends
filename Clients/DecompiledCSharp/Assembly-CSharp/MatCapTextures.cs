using UnityEngine;

public class MatCapTextures : Singleton<MatCapTextures>
{
	public Texture2D menuMatCapTexture;

	public Texture2D GetMatCap()
	{
		if (Singleton<GameController>.instance.gameState != GameController.GameState.Menu && Singleton<MapManager>.instance.currentMapDef != null)
		{
			MapDefinition.DefendPosition currentPlayerPoint = PlayerController.currentPlayer.currentPlayerPoint;
			bool flag = false;
			if (currentPlayerPoint != null)
			{
				if (currentPlayerPoint.index > 3)
				{
					flag = true;
				}
			}
			else
			{
				Debug.LogError("Getting matcap texture for player with null player point");
			}
			if (flag)
			{
				return Singleton<MapManager>.instance.currentMapDef.mineMatCapTexture;
			}
			return Singleton<MapManager>.instance.currentMapDef.opponentsMatCapTexture;
		}
		return menuMatCapTexture;
	}
}
