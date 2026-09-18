using UnityEngine;

public class CoopInfos : GuiElementSingle<CoopInfos>
{
	public GameObject coopPartnerEliminated;

	public GameObject coopPartnerLeft;

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		TweenPosition.Begin(coopPartnerEliminated, 0f, Vector3.zero);
		TweenPosition.Begin(coopPartnerLeft, 0f, Vector3.zero);
	}

	public void ShowCoopPartnerLeft()
	{
		TweenPosition.Begin(coopPartnerLeft, 0.5f, new Vector3(-690f, 0f, 0f));
		InvokeAfterRealTime(delegate
		{
			TweenPosition.Begin(coopPartnerLeft, 0.5f, Vector3.zero);
		}, 5f);
	}

	public void ShowCoopPartnerDied()
	{
		TweenPosition.Begin(coopPartnerEliminated, 0.5f, new Vector3(-690f, 0f, 0f));
		InvokeAfterRealTime(delegate
		{
			TweenPosition.Begin(coopPartnerEliminated, 0.5f, Vector3.zero);
		}, 5f);
	}
}
