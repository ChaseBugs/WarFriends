using UnityEngine;

public class MessageCenterPosition : Core_BaseScript
{
	public UIPanel messageCenterPanel;

	private void OnEnable()
	{
		float num = (float)UIRoot.list[0].activeHeight - 142f;
		messageCenterPanel.clipRange = new Vector4(messageCenterPanel.clipRange.x, (0f - num) / 2f, messageCenterPanel.clipRange.z, num);
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, -142f, base.transform.localPosition.z);
	}
}
