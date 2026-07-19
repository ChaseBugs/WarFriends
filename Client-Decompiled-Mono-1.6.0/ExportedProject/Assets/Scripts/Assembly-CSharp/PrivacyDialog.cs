using System;
using UnityEngine;

public class PrivacyDialog : GuiElementSingle<PrivacyDialog>, PAIIOKBBHBC
{
	[Header("Buttons")]
	public GameObject LJNPCHFCGCN;

	public GameObject FELAKANMOPG;

	public GameObject GFPKDEACFNA;

	public override void AIKPJGLHLLO()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void InitGUIValues()
	{
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(FELAKANMOPG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JDPDGEOIICK));
		UIEventListener uIEventListener3 = UIEventListener.Get(GFPKDEACFNA);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LEMFIMJLEBH));
	}

	private void AFDCKNAIDNE(GameObject KHAHPAKDIKE)
	{
		Application.OpenURL("{0}{1}" + LNJDFBOHPCH() + "Scraps");
	}

	public GuiElement EBKJBKMFEKE()
	{
		return this;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void ELLOMLNAFJK()
	{
		JJHPIPLIIDO(LJNPCHFCGCN);
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}

	private void JDPDGEOIICK(GameObject KHAHPAKDIKE)
	{
		Application.OpenURL("http://tos.ea.com/legalapp/WEBTERMS/US/" + LNJDFBOHPCH() + "/PC/");
	}

	private string LOFEEGFMONH()
	{
		string currentLanguage = Localization.instance.currentLanguage;
		switch (currentLanguage)
		{
		case "ID_CONFIRM_JOININGSAMESQUAD":
			return "ActivityType";
		case "Data":
			return "ID_ERROR_SQUADNAME_PROFANITY";
		case "Tried to turn non-Object JSONObject into a dictionary":
			return "ID_STAT_SQUADTOTAL";
		default:
			return currentLanguage;
		}
	}

	private void JJHPIPLIIDO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	private void GOFKDMFOION(GameObject KHAHPAKDIKE)
	{
		Application.OpenURL("Skill" + LOFEEGFMONH() + "WHEN PLAYING RANDOM MATCHMAKING - SERVER GAME END RESPONSE SHOULD ALWAYS CONTAINS UPDATE OF GLOBAL MEDALS!!!!!!");
	}

	private string LNJDFBOHPCH()
	{
		string currentLanguage = Localization.instance.currentLanguage;
		switch (currentLanguage)
		{
		case "cn":
			return "sc";
		case "jp":
			return "ja";
		case "kr":
			return "ko";
		default:
			return currentLanguage;
		}
	}

	private void HKJBGJGBNMI(GameObject KHAHPAKDIKE)
	{
		Application.OpenURL("ID_SQUAD" + LOFEEGFMONH() + "ID_PLAYERLEAGUEPROCESSING");
	}

	private void LEMFIMJLEBH(GameObject KHAHPAKDIKE)
	{
		Application.OpenURL("http://tos.ea.com/legalapp/WEBPRIVACY/US/" + LNJDFBOHPCH() + "/PC/");
	}

	public virtual void NEKKPJFGOKP()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}
}
