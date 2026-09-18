using UnityEngine;

[ExecuteInEditMode]
public class FontSizeForDynamicFont : MonoBehaviour
{
	[Header("Settings")]
	public float breakPoint = 50f;

	[Header("Test")]
	public bool printSetSizeForDynamicFont;

	public bool checkLabelDynamic;

	[Header("Repair")]
	public bool setLabelDynamic;

	[Header("Game Object Layers")]
	public int layerNumber = 11;

	public bool checkGOLayers;

	private void Update()
	{
		if (printSetSizeForDynamicFont)
		{
			printSetSizeForDynamicFont = false;
			PrintSetSizeForDynamicFont();
		}
		if (checkLabelDynamic)
		{
			checkLabelDynamic = false;
			CheckLabelDynamic();
		}
		if (setLabelDynamic)
		{
			setLabelDynamic = false;
			SetLabelDynamic();
		}
		if (checkGOLayers)
		{
			checkGOLayers = false;
			CheckGOLayers();
		}
	}

	private void PrintSetSizeForDynamicFont()
	{
		string text = "PrintSetSizeForDynamicFont: \n";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(includeInactive: true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			if (uILabel.font.isDynamic)
			{
				int dynamicFontSize = uILabel.dynamicFontSize;
				if (dynamicFontSize > 0)
				{
					text += $"WRONG dynamic font size: {dynamicFontSize} for label: {ScenePath(uILabel.gameObject)}\n";
				}
			}
		}
		Debug.Log(text);
	}

	private void CheckLabelDynamic()
	{
		LabelsDynamic();
	}

	private void SetLabelDynamic()
	{
		LabelsDynamic(debugTry: false);
	}

	private void LabelsDynamic(bool debugTry = true)
	{
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(includeInactive: true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			if (uILabel.font.isDynamic)
			{
				float x = uILabel.transform.localScale.x;
				int dynamicFontSize = uILabel.dynamicFontSize;
				if (x < breakPoint)
				{
					if (dynamicFontSize > 0)
					{
						Debug.LogFormat("WRONG dynamic font size: {0} for scale: {1} for label: {2}", dynamicFontSize, x, ScenePath(uILabel.gameObject));
						if (!debugTry)
						{
							uILabel.dynamicFontSize = 0;
						}
					}
				}
				else if (dynamicFontSize != 80)
				{
					Debug.LogFormat("WRONG dynamic font size: {0} for scale: {1} for label: {2}", dynamicFontSize, x, ScenePath(uILabel.gameObject));
					if (!debugTry)
					{
						uILabel.dynamicFontSize = 80;
					}
				}
			}
			else
			{
				Debug.LogErrorFormat("NOT DYNAMIC FONT: {0}", ScenePath(uILabel.gameObject));
			}
		}
		Debug.Log((!debugTry) ? "SetLabelDynamic - Done" : "CheckLabelDynamic - Done");
	}

	private void CheckGOLayers()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			if (!(transform == null) && !(transform.gameObject == null) && transform.gameObject.layer != layerNumber)
			{
				Debug.LogErrorFormat("WRONG GAMEOBJECT LAYER ({0}) FOR: {1} LAYER:{2}", transform.gameObject.layer, ScenePath(transform.gameObject), transform.gameObject.layer);
			}
		}
		Debug.Log("CheckGOLayers - Done");
	}

	private string ScenePath(GameObject go)
	{
		if (go == null)
		{
			return string.Empty;
		}
		string text = go.name;
		Transform parent = go.transform;
		while (parent.parent != null)
		{
			parent = parent.parent;
			text = $"{parent.gameObject.name} -> {text}";
		}
		return text;
	}
}
