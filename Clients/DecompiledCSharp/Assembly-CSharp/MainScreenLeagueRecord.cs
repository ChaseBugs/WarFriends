using UnityEngine;

public class MainScreenLeagueRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite highlight;

	[Header("Left side")]
	public UILabel positionNumber;

	public UILabel playerName;

	public UISprite crownIcon;

	[Header("Right side")]
	public UILabel medalsNumber;

	public void InitalizePlayer(int position, DatabasePlayer player, LeagueType type)
	{
		positionNumber.text = MiscTools.FormatNumberToOrdinalPoint(position);
		playerName.text = player.name;
		MiscTools.SetUILabelRescale(playerName, 30f, 20f, 280);
		medalsNumber.text = MiscTools.FormatBigNumber(player.medalsBalance);
		bool flag = player.warArenaCrown != WarArenaCrown.None;
		crownIcon.gameObject.SetActive(flag);
		if (flag)
		{
			crownIcon.spriteName = GameVariables.crownSprites[player.warArenaCrown];
			crownIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(30f / crownIcon.transform.localScale.x, 40f / crownIcon.transform.localScale.y);
			crownIcon.transform.localScale = crownIcon.transform.localScale.MultiplyXY(multiplier);
			float num = playerName.relativeSize.x * playerName.transform.localScale.x;
			float val = playerName.transform.localPosition.x + num + 10f + crownIcon.transform.localScale.x / 2f;
			crownIcon.transform.localPosition = crownIcon.transform.localPosition.ReplaceX(val);
		}
		highlight.color = Singleton<GameVariables>.instance.LeagueColorHighlight(type);
		positionNumber.color = Singleton<GameVariables>.instance.LeagueColorPosition(type);
		medalsNumber.color = Singleton<GameVariables>.instance.LeagueColorMedals(type);
		highlight.gameObject.SetActive(player.id == GameLoginManager.currentPlayer.id);
	}
}
