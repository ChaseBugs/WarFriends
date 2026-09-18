using UnityEngine;

public class PackContentRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite background;

	public UISprite rightLine;

	public UISprite icon;

	public UILabel whiteLabel;

	public UILabel bigLabel;

	public GameObject freeSticker;

	public void InitializeSize(float width, bool isLast)
	{
		float num = width / 2f;
		float val = num + 2f - ((!isLast) ? 0f : 40f);
		background.transform.localScale = background.transform.localScale.ReplaceX(width * 2f);
		rightLine.transform.localPosition = rightLine.transform.localPosition.ReplaceX(num);
		freeSticker.transform.localPosition = freeSticker.transform.localPosition.ReplaceX(val);
		whiteLabel.lineWidth = (int)width - 40;
		bigLabel.lineWidth = (int)width - 40;
		rightLine.gameObject.SetActive(!isLast);
	}

	public void InitializeTexts(string whiteText, string bigText)
	{
		whiteLabel.text = whiteText;
		MiscTools.SetUILabelRescale(whiteLabel, 32f, 20f, (int)((float)whiteLabel.lineWidth * 1.6f));
		bigLabel.text = bigText;
		MiscTools.SetUILabelRescale(bigLabel, 43f, 20f, (int)((float)whiteLabel.lineWidth * 1.6f));
	}

	public void InitializeIcon(string spriteName, UIAtlas atlasReference, float height, float z, bool rotate = false)
	{
		icon.atlas = atlasReference;
		icon.spriteName = spriteName;
		icon.MakePixelPerfect();
		float multiplier = Mathf.Min((float)whiteLabel.lineWidth / icon.transform.localScale.x, height / icon.transform.localScale.y);
		icon.transform.localPosition = icon.transform.localPosition.ReplaceZ(z);
		icon.transform.localRotation = Quaternion.AngleAxis((!rotate) ? 0f : (-180f), Vector3.up);
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(multiplier);
	}

	public void StopAnimation()
	{
		TweenAlpha component = background.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		background.alpha = GuiElementSingle<PackContentDialog>.instance.lowAlpha;
	}

	public void StartAnimation()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(background.gameObject, GuiElementSingle<PackContentDialog>.instance.duration, GuiElementSingle<PackContentDialog>.instance.lowAlpha, GuiElementSingle<PackContentDialog>.instance.highAlpha);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void ShowFree(bool showFree)
	{
		freeSticker.SetActive(showFree);
	}
}
