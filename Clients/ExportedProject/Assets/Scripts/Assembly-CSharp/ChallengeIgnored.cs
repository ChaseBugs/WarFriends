using Newtonsoft.Json.Linq;

internal class ChallengeIgnored : DatabaseMessage
{
	public override bool processNextMessage => true;

	public ChallengeIgnored(JToken dict)
		: base(dict)
	{
		MatchManager.invitationState = InvitationState.Denied;
		Ignore();
	}

	public override void Show()
	{
		base.Show();
	}
}
