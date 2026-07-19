using System.Collections.Generic;
using UnityEngine;

public static class NNOFPAGLFMM
{
	public static int FBMDPFHBDCG
	{
		get
		{
			return EventAssignmentManager.instance.currentDayIndex + 1;
		}
	}

	public static Color KOOOIBMPADB
	{
		get
		{
			return Colours.winterEventRed;
		}
	}

	public static string MPLPGMMEGIB
	{
		get
		{
			return Colours.stringWinterEventRed;
		}
	}

	public static string MNKLDLKGGID
	{
		get
		{
			return "menu-event-reward-progress-red";
		}
	}

	public static string DDLNDBANBHK
	{
		get
		{
			return Localization.Localize("ID_WINTEREVENT");
		}
	}

	public static string DKONKKDJPDB
	{
		get
		{
			return "menu-event-gift";
		}
	}

	public static Color FLOIALAJGAK
	{
		get
		{
			return Colours.winterEventBlue;
		}
	}

	public static bool ILDBNBEPBLI
	{
		get
		{
			return true;
		}
	}

	public static Dictionary<int, CamosManager.SavedPlayerVisualSlot> BHGDDCDEJJA
	{
		get
		{
			Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
			CamosManager.SavedPlayerVisualSlot savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
			savedPlayerVisualSlot.equippedID = "CAMOS_DEFAULT";
			dictionary.Add(0, savedPlayerVisualSlot);
			savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
			savedPlayerVisualSlot.equippedID = "HELMETS_SANTA";
			dictionary.Add(1, savedPlayerVisualSlot);
			savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
			savedPlayerVisualSlot.equippedID = "HEAD_SANTABEARD";
			dictionary.Add(2, savedPlayerVisualSlot);
			savedPlayerVisualSlot = new CamosManager.SavedPlayerVisualSlot();
			savedPlayerVisualSlot.equippedID = "BANDS_EMPTY";
			dictionary.Add(3, savedPlayerVisualSlot);
			return dictionary;
		}
	}
}
