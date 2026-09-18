using UnityEngine;

public class ChatPosition : Core_BaseScript
{
	public UIPanel chatPanel;

	public GameObject underTheHeaderOfChatPosition;

	private void OnEnable()
	{
		RepositChatScrollview();
	}

	public void RepositChatScrollview()
	{
		float num = Mathf.Abs(underTheHeaderOfChatPosition.transform.localPosition.y);
		float num2 = (float)UIRoot.list[0].activeHeight - num;
		chatPanel.clipRange = new Vector4(chatPanel.clipRange.x, (0f - num2) / 2f, chatPanel.clipRange.z, num2);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0f - num, base.transform.localPosition.z);
	}

	public void SetTopOfChat(bool shownSquadMessage)
	{
		underTheHeaderOfChatPosition.transform.localPosition = new Vector3(underTheHeaderOfChatPosition.transform.localPosition.x, (!shownSquadMessage) ? (-260f) : (-380f), underTheHeaderOfChatPosition.transform.localPosition.z);
		RepositChatScrollview();
	}
}
