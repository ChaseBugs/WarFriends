using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FontReplacementTool : MonoBehaviour
{
	[Header("Choose Task:")]
	public bool debug;

	public bool replace;

	public bool onlyPrint;

	public bool checkLabelZ;

	private UIFont mRegular;

	private UIFont mNgui;

	private UIFont mNguiShadow;

	private void Start()
	{
	}

	private void Update()
	{
		if (debug)
		{
			debug = false;
			Test();
		}
		if (replace)
		{
			replace = false;
			Replace();
		}
		if (onlyPrint)
		{
			onlyPrint = false;
			OnlyPrint();
		}
		if (checkLabelZ)
		{
			checkLabelZ = false;
			CheckLabelsZ();
		}
	}

	private void Test()
	{
		if (mRegular == null || mNguiShadow == null || mNgui == null)
		{
			Start();
		}
		string text = "Found labels with dynamic font in children:\n";
		string text2 = "Found labels with shadow font in children:\n";
		string text3 = "Found labels with original font in children:\n";
		string text4 = "------------------\n";
		bool flag = false;
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(includeInactive: true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(includeInactive: true);
			bool flag2 = componentsInParent.Length > 0;
			bool flag3 = LabelIsRotated(uILabel);
			if (uILabel.font == mRegular)
			{
				if (flag3)
				{
					text += "!!!ROTATED!!! ";
				}
				if (flag2)
				{
					text += "!!!UNDER TABLE!!! ";
				}
				text += $"{uILabel.gameObject.name}\t\tPivot: {uILabel.pivot}\n";
			}
			else if (uILabel.font == mNguiShadow)
			{
				if (flag3)
				{
					text2 += "!!!ROTATED!!! ";
				}
				if (flag2)
				{
					text2 += "!!!UNDER TABLE!!! ";
				}
				text2 += $"{uILabel.gameObject.name}\t\tPivot: {uILabel.pivot}\n";
			}
			else if (uILabel.font == mNgui)
			{
				if (flag3)
				{
					text3 += "!!!ROTATED!!! ";
				}
				if (flag2)
				{
					text3 += "!!!UNDER TABLE!!! ";
				}
				text3 += $"{uILabel.gameObject.name}\t\tPivot: {uILabel.pivot}\n";
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			Debug.LogError("Font problems with labels");
		}
		Debug.Log("TESTING LABELS ON CHILDREN OF OBJECT \"" + base.gameObject.name + "\":\n" + text4 + text + text4 + text2 + text4 + text3);
	}

	private void Replace()
	{
		if (mRegular == null || mNguiShadow == null || mNgui == null)
		{
			Start();
		}
		string text = "This labels must be done manualy (add sprite spacer arround):\n";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(includeInactive: true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(includeInactive: true);
			bool flag = componentsInParent.Length > 0;
			if (!(uILabel.font == mRegular))
			{
				if (flag)
				{
					text = text + PrintToUserHowToChangeLabel(uILabel) + "\n";
				}
				else
				{
					ChangeLabel(uILabel);
				}
			}
		}
		Debug.Log(text);
	}

	private string PrintToUserHowToChangeLabel(UILabel label)
	{
		int num = MiscTools.RoundToInt(label.transform.localScale.x);
		int num2 = MiscTools.RoundToInt(0.826f * (float)num);
		switch (label.pivot)
		{
		case UIWidget.Pivot.Left:
		case UIWidget.Pivot.Center:
		case UIWidget.Pivot.Right:
		{
			int num5 = MiscTools.RoundToInt(0.091f * (float)num);
			return $"Label \"{label.gameObject.name}\" with pivot \"{label.pivot}\" and old font is under table. New size {num2} and yDown {num5}.";
		}
		case UIWidget.Pivot.TopLeft:
		case UIWidget.Pivot.Top:
		case UIWidget.Pivot.TopRight:
		{
			int num4 = MiscTools.RoundToInt(0.182f * (float)num);
			return $"Label \"{label.gameObject.name}\" with pivot \"{label.pivot}\" and old font is under table. New size {num2} and yDown {num4}.";
		}
		case UIWidget.Pivot.BottomLeft:
		case UIWidget.Pivot.Bottom:
		case UIWidget.Pivot.BottomRight:
		{
			int num3 = ((label.relativeSize.y > 1f) ? MiscTools.RoundToInt(0.139f * (float)num) : 0);
			return $"Label \"{label.gameObject.name}\" with pivot \"{label.pivot}\" and old font is under table. New size {num2} and yDown {num3}.";
		}
		default:
			return null;
		}
	}

	private void ChangeLabel(UILabel label)
	{
		int num = MiscTools.RoundToInt(label.transform.localScale.x);
		int num2 = MiscTools.RoundToInt(0.826f * (float)num);
		int num3 = 0;
		UIWidget.Pivot pivot = label.pivot;
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.Right)
		{
			num3 = MiscTools.RoundToInt(0.091f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.TopRight)
		{
			num3 = MiscTools.RoundToInt(0.182f * (float)num);
		}
		if (pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.Bottom || pivot == UIWidget.Pivot.BottomRight)
		{
			num3 = ((label.relativeSize.y > 1f) ? MiscTools.RoundToInt(0.139f * (float)num) : 0);
		}
		label.font = mRegular;
		label.transform.localScale = new Vector3(num2, num2, 1f);
		if (LabelIsRotated(label))
		{
			if ((-315f <= label.transform.localRotation.eulerAngles.z && label.transform.localRotation.eulerAngles.z <= -225f) || (45f <= label.transform.localRotation.eulerAngles.z && label.transform.localRotation.eulerAngles.z <= 135f))
			{
				label.transform.localPosition = new Vector3(label.transform.localPosition.x + (float)num3, label.transform.localPosition.y, label.transform.localPosition.z);
			}
			else if ((-135f <= label.transform.localRotation.eulerAngles.z && label.transform.localRotation.eulerAngles.z <= -45f) || (225f <= label.transform.localRotation.eulerAngles.z && label.transform.localRotation.eulerAngles.z <= 315f))
			{
				label.transform.localPosition = new Vector3(label.transform.localPosition.x - (float)num3, label.transform.localPosition.y, label.transform.localPosition.z);
			}
			else
			{
				label.transform.localPosition = new Vector3(label.transform.localPosition.x, label.transform.localPosition.y + (float)num3, label.transform.localPosition.z);
			}
		}
		else
		{
			label.transform.localPosition = new Vector3(label.transform.localPosition.x, label.transform.localPosition.y - (float)num3, label.transform.localPosition.z);
		}
	}

	private void OnlyPrint()
	{
		if (mRegular == null || mNguiShadow == null || mNgui == null)
		{
			Start();
		}
		string text = "Labels under Table:\n";
		string text2 = "Labels that will be changed:\n";
		string text3 = "------------------\n";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(includeInactive: true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(includeInactive: true);
			bool flag = componentsInParent.Length > 0;
			if (uILabel.font == mRegular)
			{
				continue;
			}
			if (flag)
			{
				text = text + PrintToUserHowToChangeLabel(uILabel) + "\n";
				continue;
			}
			if (LabelIsRotated(uILabel))
			{
				text2 += "ROTATED!!! ";
			}
			text2 = text2 + PrintLabel(uILabel) + "\n";
		}
		Debug.Log("RUN ON CHILDREN OF OBJECT \"" + base.gameObject.name + "\":\n" + text3 + text + text3 + text2);
	}

	private string PrintLabel(UILabel label)
	{
		int num = MiscTools.RoundToInt(label.transform.localScale.x);
		int num2 = MiscTools.RoundToInt(0.826f * (float)num);
		int num3 = 0;
		UIWidget.Pivot pivot = label.pivot;
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.Right)
		{
			num3 = MiscTools.RoundToInt(0.091f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.TopRight)
		{
			num3 = MiscTools.RoundToInt(0.182f * (float)num);
		}
		if (pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.Bottom || pivot == UIWidget.Pivot.BottomRight)
		{
			num3 = ((label.relativeSize.y > 1f) ? MiscTools.RoundToInt(0.139f * (float)num) : 0);
		}
		return $"Changing label \"{label.gameObject.name}\" with pivot \"{label.pivot}\". New size {num2} and yDown {num3}.";
	}

	private bool LabelIsRotated(UILabel label)
	{
		return label.transform.localRotation.eulerAngles.z < -45f || 45f < label.transform.localRotation.eulerAngles.z;
	}

	private void CheckLabelsZ()
	{
		Dictionary<float, int> dictionary = new Dictionary<float, int>();
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(includeInactive: true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			float z = uILabel.transform.localPosition.z;
			if (dictionary.ContainsKey(z))
			{
				Dictionary<float, int> dictionary3;
				Dictionary<float, int> dictionary2 = (dictionary3 = dictionary);
				float key2;
				float key = (key2 = z);
				int num = dictionary3[key2];
				dictionary2[key] = num + 1;
			}
			else
			{
				dictionary.Add(z, 1);
			}
		}
		string text = "Labels Z used:\n";
		foreach (KeyValuePair<float, int> item in dictionary)
		{
			text += $"Z:{item.Key} count:{item.Value}\n";
		}
		Debug.Log(text);
	}
}
