using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyAssignmentsDialog : GuiElementSingle<DailyAssignmentsDialog>, IGuiDialog
{
	[Header("Core")]
	public AssignmentRecord[] records;

	public GameObject okButton;

	public override void InitControls()
	{
		records[0].InitControls();
		records[1].InitControls();
		records[2].InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += delegate
		{
			if (isShowed)
			{
				UpdateAssignments();
			}
		};
		UIEventListener uIEventListener = UIEventListener.Get(okButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OkClick));
	}

	private void UpdateAssignments()
	{
		AssignmentRecord[] array = records;
		foreach (AssignmentRecord assignmentRecord in array)
		{
			assignmentRecord.UpdateAssignmentLook(firstShow: false);
		}
	}

	private void OkClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		List<Assignment> assignments = AssignmentsManager.instance.GetAssignments(update: false);
		for (int i = 0; i < records.Length; i++)
		{
			bool flag = assignments != null && assignments.Count > i && assignments[i] != null;
			records[i].gameObject.SetActive(flag);
			if (flag)
			{
				records[i].Initialize(assignments[i]);
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		OkClick(okButton);
	}
}
