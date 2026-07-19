public class ChatButtonUnderline : Core_BaseScript
{
	public UISprite KMFGCJEGJJK;

	public UISprite KMHGGDFBBJP;

	public UILabel FKLKLCBOMNE;

	private float BKHNNGLJJDI = -100f;

	private void OOFGGGDOGEM(bool GCGOGMDOBED)
	{
		if (BKHNNGLJJDI < -50f)
		{
			BKHNNGLJJDI = FKLKLCBOMNE.transform.localPosition.y;
			return;
		}
		if (GCGOGMDOBED)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(FKLKLCBOMNE.gameObject, 0.2f, FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI), FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI + 14f));
			tweenPosition.style = UITweener.Style.PingPong;
			tweenPosition.NumOfRepetitions = 2;
			return;
		}
		TweenPosition component = FKLKLCBOMNE.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI);
	}

	private void OOLKKCKCCJK(bool GCGOGMDOBED)
	{
		if (BKHNNGLJJDI < 1040f)
		{
			BKHNNGLJJDI = FKLKLCBOMNE.transform.localPosition.y;
			return;
		}
		if (GCGOGMDOBED)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(FKLKLCBOMNE.gameObject, 1568f, FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI), FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI + 311f));
			tweenPosition.style = UITweener.Style.Once;
			tweenPosition.NumOfRepetitions = 7;
			return;
		}
		TweenPosition component = FKLKLCBOMNE.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI);
	}

	public void APIHNFAABLB()
	{
		KMHGGDFBBJP.transform.localScale = KMHGGDFBBJP.transform.localScale.ReplaceX(FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x);
	}

	public void SetClicked(bool GCGOGMDOBED)
	{
		KMFGCJEGJJK.color = ((!GCGOGMDOBED) ? Colours.blueLowAlpha : Colours.blue);
		KMHGGDFBBJP.gameObject.SetActive(!GCGOGMDOBED);
		Rescale();
		OOFGGGDOGEM(GCGOGMDOBED);
	}

	private void LGNNDCCOKEC(bool GCGOGMDOBED)
	{
		if (BKHNNGLJJDI < 1553f)
		{
			BKHNNGLJJDI = FKLKLCBOMNE.transform.localPosition.y;
			return;
		}
		if (GCGOGMDOBED)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(FKLKLCBOMNE.gameObject, 981f, FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI), FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI + 1545f), false);
			tweenPosition.style = (UITweener.Style)7;
			tweenPosition.NumOfRepetitions = 7;
			return;
		}
		TweenPosition component = FKLKLCBOMNE.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI);
	}

	private void IJJOPKCDLKD(bool GCGOGMDOBED)
	{
		if (BKHNNGLJJDI < 490f)
		{
			BKHNNGLJJDI = FKLKLCBOMNE.transform.localPosition.y;
			return;
		}
		if (GCGOGMDOBED)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(FKLKLCBOMNE.gameObject, 1515f, FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI), FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI + 461f));
			tweenPosition.style = UITweener.Style.PingPong;
			tweenPosition.NumOfRepetitions = 6;
			return;
		}
		TweenPosition component = FKLKLCBOMNE.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI);
	}

	private void AOIPHCKEKFP(bool GCGOGMDOBED)
	{
		if (BKHNNGLJJDI < 1511f)
		{
			BKHNNGLJJDI = FKLKLCBOMNE.transform.localPosition.y;
			return;
		}
		if (GCGOGMDOBED)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(FKLKLCBOMNE.gameObject, 1476f, FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI), FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI + 1722f), false);
			tweenPosition.style = (UITweener.Style)4;
			tweenPosition.NumOfRepetitions = 2;
			return;
		}
		TweenPosition component = FKLKLCBOMNE.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI);
	}

	public void BAIAKMKHBBP()
	{
		KMHGGDFBBJP.transform.localScale = KMHGGDFBBJP.transform.localScale.ReplaceX(FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x);
	}

	public void PCJEOGBAEOF()
	{
		KMHGGDFBBJP.transform.localScale = KMHGGDFBBJP.transform.localScale.ReplaceX(FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x);
	}

	private void KKGKDLDCDCJ(bool GCGOGMDOBED)
	{
		if (BKHNNGLJJDI < 302f)
		{
			BKHNNGLJJDI = FKLKLCBOMNE.transform.localPosition.y;
			return;
		}
		if (GCGOGMDOBED)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(FKLKLCBOMNE.gameObject, 102f, FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI), FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI + 640f), false);
			tweenPosition.style = UITweener.Style.Once;
			tweenPosition.NumOfRepetitions = 6;
			return;
		}
		TweenPosition component = FKLKLCBOMNE.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI);
	}

	private void ADOPADMNNKI(bool GCGOGMDOBED)
	{
		if (BKHNNGLJJDI < 1701f)
		{
			BKHNNGLJJDI = FKLKLCBOMNE.transform.localPosition.y;
			return;
		}
		if (GCGOGMDOBED)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(FKLKLCBOMNE.gameObject, 642f, FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI), FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI + 877f));
			tweenPosition.style = (UITweener.Style)6;
			tweenPosition.NumOfRepetitions = 6;
			return;
		}
		TweenPosition component = FKLKLCBOMNE.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI);
	}

	public void AILPFBLKFFD(bool GCGOGMDOBED)
	{
		KMFGCJEGJJK.color = ((!GCGOGMDOBED) ? Colours.blueLowAlpha : Colours.blue);
		KMHGGDFBBJP.gameObject.SetActive(GCGOGMDOBED);
		BAIAKMKHBBP();
		KKGKDLDCDCJ(GCGOGMDOBED);
	}

	public void Rescale()
	{
		KMHGGDFBBJP.transform.localScale = KMHGGDFBBJP.transform.localScale.ReplaceX(FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x);
	}

	public void GJLIAOMIFJC(bool GCGOGMDOBED)
	{
		KMFGCJEGJJK.color = ((!GCGOGMDOBED) ? Colours.blueLowAlpha : Colours.blue);
		KMHGGDFBBJP.gameObject.SetActive(GCGOGMDOBED);
		Rescale();
		OOLKKCKCCJK(GCGOGMDOBED);
	}

	public void GCMDBPHCEGC()
	{
		KMHGGDFBBJP.transform.localScale = KMHGGDFBBJP.transform.localScale.ReplaceX(FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x);
	}

	private void NNHJKPPKDNI(bool GCGOGMDOBED)
	{
		if (BKHNNGLJJDI < 1952f)
		{
			BKHNNGLJJDI = FKLKLCBOMNE.transform.localPosition.y;
			return;
		}
		if (GCGOGMDOBED)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(FKLKLCBOMNE.gameObject, 1085f, FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI), FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI + 288f));
			tweenPosition.style = (UITweener.Style)6;
			tweenPosition.NumOfRepetitions = 6;
			return;
		}
		TweenPosition component = FKLKLCBOMNE.gameObject.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		FKLKLCBOMNE.transform.localPosition = FKLKLCBOMNE.transform.localPosition.ReplaceY(BKHNNGLJJDI);
	}

	public void LLNCGPAANAF()
	{
		KMHGGDFBBJP.transform.localScale = KMHGGDFBBJP.transform.localScale.ReplaceX(FKLKLCBOMNE.relativeSize.x * FKLKLCBOMNE.transform.localScale.x);
	}
}
