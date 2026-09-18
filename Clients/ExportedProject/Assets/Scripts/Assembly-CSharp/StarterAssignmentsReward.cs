using UnityEngine;

public class StarterAssignmentsReward : DatabaseMessage
{
	public Card[] cards;

	public StarterAssignmentsReward(Card[] gainedCards)
		: base("StarterAssignmentsReward", Type.HitlistLogedIn)
	{
		cards = gainedCards;
		Debug.Log("Starter Assignments Reward Dialog show");
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<StarterAssignmentRewardDialog>.instance.ShowDialog(cards);
	}
}
