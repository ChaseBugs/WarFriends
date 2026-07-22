using System;
using System.Collections.Generic;

public class WarArenaRuleWeapons : WarArenaRuleGeneric<WarArenaRuleWeapons.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public List<WeaponConfig> weapons = new List<WeaponConfig>();
	}

	[Serializable]
	public class WeaponConfig
	{
		public WeaponCategory category = WeaponCategory.Any;
	}

	public virtual void EEDEKPALGAA()
	{
		base.IBEGGCHBJGC();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	public virtual void BIKHKIMBJPH()
	{
		base.FBDFHHKIICO();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.LPMCOFOCCAH(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool APBHOHLKAAB()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].BIPKCHNEPGK();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	public virtual void DAEENKCCJHH()
	{
		base.APIJFIPABAO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	public virtual bool HLAEFDLJGLD()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].JCPKCKIHFBI();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	protected override OCCICIIEHEF OMDJEDGCGOM()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoText;
		bool flag = FGHKBLLKOBL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = (flag ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("bazooka_idle", list2.ToArray());
		string text = Localization.LocalizeFormat("GooglePlayId", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[6];
			array2[1] = Colours.stringGreenArena;
			array2[0] = string.Join("), ", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("goldwarcard", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[0];
			array3[0] = string.Join("ID_MAXUNITSFROMEACHCATEGORY", list4.ToArray());
			string item = Localization.LocalizeFormat("Humvee", array3);
			if (list4.Count < 4)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Id", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF NPEPOGICIDM()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)7;
		bool flag = MPNDBIBDOCD();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("#OFFERS# extra visual is null for ID {0}", list2.ToArray());
		string text = Localization.LocalizeFormat("ID_ERROR_SQUADNAMESHORT", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat("+", Colours.stringGreenArena, string.Join("Show Ground", list3.ToArray()), null, null, null, null);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
			}
			string item = Localization.LocalizeFormat("x", string.Join("YES", list4.ToArray()));
			if (list4.Count < 0)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join(" ID_", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF MMCKBEIOEAO()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.DoesNotMeet;
		bool flag = DAHIFNEGKAD();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = (flag ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("Assets", list2.ToArray());
		string text = Localization.LocalizeFormat("#AccoutCheck# now is in menu or in game", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat("Gold", Colours.stringGreenArena, string.Join("#PETER# League Arc - start ignore on ", list3.ToArray()), null, null, null, null);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
			}
			object[] array2 = new object[0];
			array2[0] = string.Join("-ABILITY", list4.ToArray());
			string item = Localization.LocalizeFormat("S", array2);
			if (list4.Count < 8)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Play_Card_Tutorial_Duration", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void OBGPNLJGPMN()
	{
		base.APIJFIPABAO();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.LOLDJPCCFKO(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool EBMFBLPEJBI()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].CKJOBHNNFAM();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return false;
	}

	protected virtual OCCICIIEHEF NKPLBFGHGCO()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.FulFill;
		bool flag = FGHKBLLKOBL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("USD", list2.ToArray());
		string text = Localization.LocalizeFormat("0", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat("_DESC", Colours.stringGreenArena, string.Join("Title Text Font Size", list3.ToArray()));
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			object[] array2 = new object[1];
			array2[1] = string.Join("ID_OFFERACTIVE", list4.ToArray());
			string item = Localization.LocalizeFormat("bazooka_idle", array2);
			if (list4.Count < 3)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("S", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void JNKLOBHLNNB()
	{
		base.ALJKKBMBBFM();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.BGIFMIBBJIB(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool DHFOKAIJMDN()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].weaponLevelsSetup;
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	public virtual void DEHMMBCLOFC()
	{
		base.FBDFHHKIICO();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LPMCOFOCCAH(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	protected virtual OCCICIIEHEF EPOLOANGNOI()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)5;
		bool flag = LPLPANBJDAM();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("ID_RELOG_TO_FB_DIALOG_TEXT", list2.ToArray());
		string text = Localization.LocalizeFormat("right", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[1];
			array2[0] = Colours.stringGreenArena;
			array2[0] = string.Join("ItemRarity_4", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("GoldReward{0}Max", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			object[] array3 = new object[1];
			array3[1] = string.Join("globalSquadLeaderboard", list4.ToArray());
			string item = Localization.LocalizeFormat("ID_ERROR_SQUADSKILLNOTANUMBER", array3);
			if (list4.Count < 0)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("302 GAME STARTED", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void DEBEAIAGAMC()
	{
		base.FBDFHHKIICO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.BGIFMIBBJIB(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool PLHBLDABGJA()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].PMJFFNLKKLB();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return false;
	}

	public override bool MPNDBIBDOCD()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].MJOAIHHAPFG();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void KKBBMPFNKGJ()
	{
		base.APIJFIPABAO();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LPMCOFOCCAH(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = EKMMLNKADIL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("ID_ARENARULES_ONLY", string.Join(" & ", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat("ID_YOUNEEDTOEQUIPWEAPON", Colours.stringGreenArena, string.Join(" & ", list3.ToArray()));
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			string item = Localization.LocalizeFormat("ID_ARENARULES_NO", string.Join(" & ", list4.ToArray()));
			if (list4.Count < 3)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("\n", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF EEOALKHGIOE()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoText;
		bool flag = EDNAIMPLPGL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("api/", list2.ToArray());
		string text = Localization.LocalizeFormat("ID_STAT_MOSTWINS", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[7];
			array2[1] = Colours.stringGreenArena;
			array2[1] = string.Join("NextWithdraw", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("Session: On GC authenticated! Result = ", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			object[] array3 = new object[0];
			array3[0] = string.Join("shotSniper", list4.ToArray());
			string item = Localization.LocalizeFormat("Localization", array3);
			if (list4.Count < 5)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_CATEGORY_LOW_PL_SMG", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool BLNECEIFKPL()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].ALEBNFNFOEP();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void LIEANPEIJHK()
	{
		base.ANCJEMCFEID();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LOLDJPCCFKO(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	protected virtual OCCICIIEHEF LLAMMNLFPGC()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)5;
		bool flag = FGHKBLLKOBL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("ID_BLACKMARKETMAXPOWER", list2.ToArray());
		string text = Localization.LocalizeFormat("BoughtIndex", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[5];
			array2[1] = Colours.stringGreenArena;
			array2[0] = string.Join("LogId", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("PromotedPlayer", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			string item = Localization.LocalizeFormat("ID_", string.Join("FuseSDK instance not initialized. Awake may not have been called.", list4.ToArray()));
			if (list4.Count < 8)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_ARENAPARTICIPATIONREWARD", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool ABFCMKAKMED()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].FPGNBPPHPKC();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool AONAAGJDHOD()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].FPGNBPPHPKC();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return false;
	}

	protected virtual OCCICIIEHEF CCCGIFMLEKF()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)6;
		bool flag = EKMMLNKADIL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("ID_SLOTUPGRADE_ROF", list2.ToArray());
		string text = Localization.LocalizeFormat("ItemsOwned_Rarity_3", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat("ID_MAXSTAT", Colours.stringGreenArena, string.Join("'friend'0", list3.ToArray()), null, null, null, null, null, null);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
			}
			string item = Localization.LocalizeFormat("WarArenaConfig", string.Join("order", list4.ToArray()));
			if (list4.Count < 6)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Cannot merge arrays when right object has more elements", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool AKCJIOOJHCG()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].ALEBNFNFOEP();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	protected virtual OCCICIIEHEF DEKPLKOFMFM()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)6;
		bool flag = OEAODGFDMGC();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("{0} {1}{2}", string.Join("UnitCategoriesReminder", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array = new object[2];
			array[1] = Colours.stringGreenArena;
			array[0] = string.Join("GameController: Application resumed", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("NULL WARCARD", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			string item = Localization.LocalizeFormat("ID_NOTENOUGHWARBUCKS", string.Join("Null cannot be saved as last unit.", list4.ToArray()));
			if (list4.Count < 4)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_GAMECENTERUSER", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool DANEHBKOOGF()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].DLNNBFIIJPA();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return false;
	}

	protected virtual OCCICIIEHEF HJHMLCPKGAB()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.FulFill;
		bool flag = EDNAIMPLPGL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.DoesNotMeet);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot remove it", list2.ToArray());
		string text = Localization.LocalizeFormat("Skipping next withdraw basecause player left squad", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[1];
			array2[1] = Colours.stringGreenArena;
			array2[1] = string.Join("isSuccess", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat(".", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[0];
			array3[0] = string.Join("FormerFullLeagueId", list4.ToArray());
			string item = Localization.LocalizeFormat("D", array3);
			if (list4.Count < 8)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join(".", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF DKBNNKANPLC()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = AKIJBMEBNNC();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = (flag ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("withRevenue", string.Join(" {0}/{1} ", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array = new object[2];
			array[1] = Colours.stringGreenArena;
			array[0] = string.Join("SetPlayer", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("Experience", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
			}
			object[] array2 = new object[0];
			array2[0] = string.Join("ID_VISUALRARITY3", list4.ToArray());
			string item = Localization.LocalizeFormat("ID_CLOSE", array2);
			if (list4.Count < 7)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_CONFIRM_ERROR", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected override OCCICIIEHEF NELJBJBMOLH()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)5;
		bool flag = CLPEMLCLDIJ();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("A", list2.ToArray());
		string text = Localization.LocalizeFormat("_", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[0];
			array2[0] = Colours.stringGreenArena;
			array2[0] = string.Join("Password", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("1", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[0];
			array3[0] = string.Join("withQuantity", list4.ToArray());
			string item = Localization.LocalizeFormat("DisplayNotifications()", array3);
			if (list4.Count < 7)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_CONFIRM_SQUADFULL", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF MHONCCANCOG()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.FulFill;
		bool flag = MPNDBIBDOCD();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.DoesNotMeet);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("-", list2.ToArray());
		string text = Localization.LocalizeFormat("ID_SLOTUPGRADE_ROF", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[8];
			array2[1] = Colours.stringGreenArena;
			array2[0] = string.Join("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat(" (", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[1];
			array3[1] = string.Join("warfriends-dev.eu-west-1.elasticbeanstalk.com/", list4.ToArray());
			string item = Localization.LocalizeFormat("PlayerName", array3);
			if (list4.Count < 4)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Finished", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF GOAGBNMENNN()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)7;
		bool flag = OEAODGFDMGC();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("ID_VALUEPACKCONTENTS", list2.ToArray());
		string text = Localization.LocalizeFormat("QUIT", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[3];
			array2[1] = Colours.stringGreenArena;
			array2[1] = string.Join("ID_READYTIME", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("1", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[0];
			array3[0] = string.Join("ID_READYTIME", list4.ToArray());
			string item = Localization.LocalizeFormat("NotificationAction()", array3);
			if (list4.Count < 1)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("menu-arena-scrap-ico", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool ABNFFOOKMDF()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].PMJFFNLKKLB();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	public virtual void NLGDPEIHILO()
	{
		base.GFJMJLMFPKO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LOLDJPCCFKO(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public override void GJFHGPMMDEM()
	{
		base.GJFHGPMMDEM();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	public virtual void HJGLJNHOKIB()
	{
		base.GFJMJLMFPKO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	protected virtual OCCICIIEHEF HAAAHIEENMA()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)6;
		bool flag = DDFGIDBHJIK();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("Regions", list2.ToArray());
		string text = Localization.LocalizeFormat("FacebookId", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat("ApplyVisuals Error, indices are null!", Colours.stringGreenArena, string.Join("getSessionPercentile", list3.ToArray()), null, null, null);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			string item = Localization.LocalizeFormat("Param", string.Join(" ", list4.ToArray()));
			if (list4.Count < 4)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_CONFIRM_NOTACTIVEEVENT", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void EGJJPHIFHHL()
	{
		base.FBDFHHKIICO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.BGIFMIBBJIB(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public override bool KFJLPGPAAAN()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].KBCDILLLFIJ();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	public virtual bool KABMAAKKFML()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].BHDJIJGIHCL();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool LDMCCCLPOML()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].ANOHEJKJAKG();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	public virtual void NCKLGINLMDP()
	{
		base.APIJFIPABAO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.HLOKMIDGPCA(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool NBMHHPPMACH()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].LFBDANCEFGE();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	public override bool DJDCOJHOBJP()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].DLNNBFIIJPA();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	protected virtual OCCICIIEHEF GJLFCGNCDMI()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.FulFill;
		bool flag = OAELLJPGBPC();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("ID_GOLD", string.Join("BlackMarketOffer", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array = new object[4];
			array[1] = Colours.stringGreenArena;
			array[0] = string.Join("#Mission Rewards# 5 Heroic Missions completed. Gained {0} warcards", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array2 = new object[0];
			array2[1] = string.Join("DeviceToken", list4.ToArray());
			string item = Localization.LocalizeFormat(" (#", array2);
			if (list4.Count < 3)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_LOADING", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void ILCHIKABJIC()
	{
		base.IBEGGCHBJGC();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LOLDJPCCFKO(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual void AGOIGAJMEAO()
	{
		base.HBPJJCDCPLG();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	protected virtual OCCICIIEHEF IGEPGGBBBGB()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)6;
		bool flag = DAHIFNEGKAD();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.DoesNotMeet);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("-", list2.ToArray());
		string text = Localization.LocalizeFormat("ID_UNLOCKEDATRANKX", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[0];
			array2[0] = Colours.stringGreenArena;
			array2[0] = string.Join("Player_Avoided_Grenade_On_First_Try", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("{0}Message-{1}", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
			}
			object[] array3 = new object[1];
			array3[1] = string.Join("'", list4.ToArray());
			string item = Localization.LocalizeFormat("{0}-{1:D6}", array3);
			if (list4.Count < 5)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join(" ", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void OFMFHAEKFPP()
	{
		base.IONJNJKPMHK();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LOLDJPCCFKO(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool OELICGFDFHL()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].BHDJIJGIHCL();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	public virtual void EDMOGJOEKDF()
	{
		base.HBPJJCDCPLG();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.BGIFMIBBJIB(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool JFABHCNMGDI()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].CKJOBHNNFAM();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	public virtual void KHHHKGNDABC()
	{
		base.EPDLHJFDJBE();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	public virtual bool MBBGMOGDAAM()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].ENBMDAIKKMM();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	public virtual bool JOMINLGEFME()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].HHMKPPOAOBJ();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool NLJBOPJBPPN()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].JEHGKOGGBCP();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	public override void EPDLHJFDJBE()
	{
		base.JMLIBCJJOIA();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	public virtual void PCIBFBKFKOF()
	{
		base.GFJMJLMFPKO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LOLDJPCCFKO(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	protected virtual OCCICIIEHEF AFENBKLIJDC()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = KFJLPGPAAAN();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("WarBucksRibbons", list2.ToArray());
		string text = Localization.LocalizeFormat("menu-crown-gold", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[0];
			array2[0] = Colours.stringGreenArena;
			array2[0] = string.Join("Awaiting Squad Member = ", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("ID_UNIT2TRAIN_UNIT1BUY", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
			}
			string item = Localization.LocalizeFormat("menu-army-cat-explosive", string.Join("withPublisherSubPublisher", list4.ToArray()));
			if (list4.Count < 3)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Setting unit delivery in ", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF CGLNKNAPHDD()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)6;
		bool flag = AKIJBMEBNNC();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.DoesNotMeet);
				}
			}
		}
		string text = Localization.LocalizeFormat("elitepack", string.Join("weapon", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array = new object[3];
			array[1] = Colours.stringGreenArena;
			array[1] = string.Join("banana", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat(",", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			object[] array2 = new object[0];
			array2[0] = string.Join("ID_CONFIRM_NOTENOUGHDOGTAGS", list4.ToArray());
			string item = Localization.LocalizeFormat("ARENA SCREEN CLOSED with mode: ", array2);
			if (list4.Count < 8)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("country-mexico", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF OPLHOAENDAE()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = DDFGIDBHJIK();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = (flag ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("+0", string.Join("ID_GUI_PLAYER", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array = new object[6];
			array[1] = Colours.stringGreenArena;
			array[0] = string.Join("ID_COMPLETEIN", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("ID_CARD_DESC_BUDDY", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
			}
			object[] array2 = new object[1];
			array2[1] = string.Join("ID_BRONZELOOTBOX", list4.ToArray());
			string item = Localization.LocalizeFormat("(", array2);
			if (list4.Count < 0)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Sniper_Tutorial_Duration", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF CCEKCBKLFAH()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)5;
		bool flag = DAHIFNEGKAD();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.DoesNotMeet);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("BONUS: size: ", list2.ToArray());
		string text = Localization.LocalizeFormat("ID_MISSIONANIMATION_WAVESTARTED", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[8];
			array2[1] = Colours.stringGreenArena;
			array2[0] = string.Join("ID_SUBSCRIPTIODETAILS_HINT4", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("Show Loadout After Create Account", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
			}
			string item = Localization.LocalizeFormat("set schedule gc check 1", string.Join("ID_NO", list4.ToArray()));
			if (list4.Count < 6)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Wins", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool NNJFECMPDCI()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].LMPIDJLMPLG();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return false;
	}

	protected virtual OCCICIIEHEF OIJBDMDPHGD()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = KJDMOCMBFLJ();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = (flag ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_WB", string.Join("null facebook friends", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array = new object[3];
			array[1] = Colours.stringGreenArena;
			array[1] = string.Join("globalSquadLeaderboard", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("#VAVRO# OnLeftRoom", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
			}
			object[] array2 = new object[1];
			array2[1] = string.Join("-", list4.ToArray());
			string item = Localization.LocalizeFormat("S", array2);
			if (list4.Count < 7)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Chat: Disconected: ", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void CHMFPJDKEIF()
	{
		base.FBDFHHKIICO();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.LPMCOFOCCAH(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	protected virtual OCCICIIEHEF GDAGBPNIJCD()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)7;
		bool flag = DJDCOJHOBJP();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = (flag ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("BuddyCard_", list2.ToArray());
		string text = Localization.LocalizeFormat("FuseSDK: Parsing error in _AdAvailabilityResponse", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[2];
			array2[1] = Colours.stringGreenArena;
			array2[1] = string.Join("id: ", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat(" - loggin goldCost: ", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
			}
			string item = Localization.LocalizeFormat("Used warcards and rewards from last match wre removed", string.Join("LT", list4.ToArray()));
			if (list4.Count < 1)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_ARENARULES_LESSPLAYERHP", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF IKAEPAPKLOB()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = AIMGMMCHEIO();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("ShotFrequencyMin", string.Join("Have discount {0} to buy {1}", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat("Updated Player League And Medals to BeginnersLeague:{0} NormalLeague:{1} GlobalMedals:{2} LeagueMedals:{3} RemainingMatches:{4}", Colours.stringGreenArena, string.Join("0", list3.ToArray()), null, null, null, null, null);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			object[] array = new object[0];
			array[0] = string.Join("Chillingo SDK: activate offers", list4.ToArray());
			string item = Localization.LocalizeFormat("withCurrencyCode", array);
			if (list4.Count < 8)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("CardsInCardPack", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool ICLPAPGALAC()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].CKJOBHNNFAM();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	public virtual void IPCGELBGCDO()
	{
		base.GFJMJLMFPKO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.BGIFMIBBJIB(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public override void GFJMJLMFPKO()
	{
		base.IBEGGCHBJGC();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LPMCOFOCCAH(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool JEDFEDLIJCH()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].ENBMDAIKKMM();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	protected virtual OCCICIIEHEF PKEGIGAEKNM()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)4;
		bool flag = AKIJBMEBNNC();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("GameType", list2.ToArray());
		string text = Localization.LocalizeFormat("Assignment ID: {0}\nERROR: {1}\nSTACKTRACE: {2}", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[1];
			array2[1] = Colours.stringGreenArena;
			array2[0] = string.Join("SpentWarbucks", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("LevelExperience", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
			}
			string item = Localization.LocalizeFormat(")", string.Join("ID_WARBUCKS", list4.ToArray()));
			if (list4.Count < 3)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("metalExplosion", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool OPEFGGIFJAN()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].LFBDANCEFGE();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	public virtual bool DOCIOINNLBP()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].MJOAIHHAPFG();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return false;
	}

	public virtual void EGEDKGLILBI()
	{
		base.APIJFIPABAO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.LOLDJPCCFKO(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	protected virtual OCCICIIEHEF HPNAENEAMLB()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)8;
		bool flag = LPLPANBJDAM();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("menu-weapon-benelli-starterpack", list2.ToArray());
		string text = Localization.LocalizeFormat("ID_STAT_MOSTPOWERFULLARMY", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[4];
			array2[1] = Colours.stringGreenArena;
			array2[1] = string.Join("ShootStandNew", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("https://twitter.com/WarFriendsGame", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
			}
			object[] array3 = new object[0];
			array3[1] = string.Join(".", list4.ToArray());
			string item = Localization.LocalizeFormat("ID_DOWNLOADING", array3);
			if (list4.Count < 6)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_EMPTYSQUADMESSAGE", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void JEFECFMGPMJ()
	{
		base.ALJKKBMBBFM();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.BGIFMIBBJIB(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	protected virtual OCCICIIEHEF ICHICEHGCHP()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)8;
		bool flag = EKMMLNKADIL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.DoesNotMeet);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("\"}", list2.ToArray());
		string text = Localization.LocalizeFormat("ID_WARNING_CANTSENDINVITE", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[3];
			array2[0] = Colours.stringGreenArena;
			array2[0] = string.Join("UIReflectionEffect reference missing for index ", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("Buy_VIP_Pack_With_Gold", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[0];
			array3[0] = string.Join("ID_CATEGORY_SHOTGUN", list4.ToArray());
			string item = Localization.LocalizeFormat("Beanstalk: Get Squad Details", array3);
			if (list4.Count < 2)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("N", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF OHNKNEHMLPB()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoText;
		bool flag = MPNDBIBDOCD();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("AtlasPreparer.ClearMenuLoadGameCoroutine", string.Join("BS: On Claim Assignment MegaReward", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array = new object[1];
			array[0] = Colours.stringGreenArena;
			array[0] = string.Join("menu-army-ammo-ico", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("ID_ERROR_SQUADSKILLNOTANUMBER", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			string item = Localization.LocalizeFormat("SquadIcons/", string.Join("com.tune.TunePreloadData", list4.ToArray()));
			if (list4.Count < 6)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("#AccoutCheck# GPGS login during tutorial", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)5;
		bool flag = EDNAIMPLPGL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = (flag ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("确定", list2.ToArray());
		string text = Localization.LocalizeFormat("Squad Wars Data {0}", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat(" 3", Colours.stringGreenArena, string.Join(" does not have defined look!!!!!!", list3.ToArray()));
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
			}
			string item = Localization.LocalizeFormat("S", string.Join("HELMETS_CROWNSILVER", list4.ToArray()));
			if (list4.Count < 6)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("NewLevelId", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public override bool EKMMLNKADIL()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].weaponLevelsSetup;
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	protected virtual OCCICIIEHEF BHOKFFBEAIC()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = AIMGMMCHEIO();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("ID_YOUNEEDMONEYTOTRAIN", list2.ToArray());
		string text = Localization.LocalizeFormat("OtherCards", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[0];
			array2[1] = Colours.stringGreenArena;
			array2[1] = string.Join("ID_BEGINNERSLEAGUE2", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("TR", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.AssaultRifle))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[0];
			array3[1] = string.Join("country-noflag", list4.ToArray());
			string item = Localization.LocalizeFormat("AA:BB:CC:DD:EE:FF", array3);
			if (list4.Count < 3)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ChillingoSdkManager", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool KGNCALOLAHJ()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].CKJOBHNNFAM();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	protected virtual OCCICIIEHEF MCCBBCDOOGK()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)6;
		bool flag = DJDCOJHOBJP();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("ID_DAYS", list2.ToArray());
		string text = Localization.LocalizeFormat("BonusHP", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[0];
			array2[1] = Colours.stringGreenArena;
			array2[1] = string.Join("ID_TRAIN", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("Finish broadcasting", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[1];
			array3[1] = string.Join("BlackMarketOffer", list4.ToArray());
			string item = Localization.LocalizeFormat("Grenade_Throwing_Tutorial_Duration", array3);
			if (list4.Count < 7)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("warfriends-staging.eu-west-1.elasticbeanstalk.com/", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void CLOBNFNOLNB()
	{
		base.APIJFIPABAO();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.BGIFMIBBJIB(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	public virtual bool NCIAEBEEDGJ()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].JCPKCKIHFBI();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool IJPKPGPEDCO()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].DLNNBFIIJPA();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool NAFCNBIPEKM()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].IDMPHABHMGI();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	public virtual void NHFPIDCJNFI()
	{
		base.JNEGPCHLGKD();
		bool flag = true;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	public virtual void IEFGEIGHFKJ()
	{
		base.APIJFIPABAO();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = true;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	public virtual bool IDCLHHDLCPJ()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j += 0)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].MJOAIHHAPFG();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	protected virtual OCCICIIEHEF LLKGHNIJOAN()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)4;
		bool flag = OEAODGFDMGC();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("Chat - new notifications: {0}, selectedSquadChat: {1}, currentState: {2}", list2.ToArray());
		string text = Localization.LocalizeFormat("OOOOPS", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[3];
			array2[0] = Colours.stringGreenArena;
			array2[0] = string.Join("Session_start", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("UA", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			object[] array3 = new object[0];
			array3[1] = string.Join("S", list4.ToArray());
			string item = Localization.LocalizeFormat("Id", array3);
			if (list4.Count < 7)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Event Tracking Manager - Tutorial Game Ended, Deploy clicks: {0}, Deployed units: {1}", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF OCHABKJJLKP()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)6;
		bool flag = KFJLPGPAAAN();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = (flag ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[1];
		array[1] = string.Join("Vip", list2.ToArray());
		string text = Localization.LocalizeFormat("ID_OPPONENTREFUSEDTHEREMATCH", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			cNMDFMGELLH = Localization.LocalizeFormat("DeviceToken", Colours.stringGreenArena, string.Join("ID_5SKIRMISHES", list3.ToArray()), null, null, null, null, null, null);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			object[] array2 = new object[0];
			array2[0] = string.Join("Pack_Id", list4.ToArray());
			string item = Localization.LocalizeFormat("some_adv_sub_ad_id", array2);
			if (list4.Count < 6)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Saved_data.csv", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	protected virtual OCCICIIEHEF JGFLFGKHPKH()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = NMPPLCHLCDK();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		object[] array = new object[0];
		array[1] = string.Join("SquadId", list2.ToArray());
		string text = Localization.LocalizeFormat(".", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array2 = new object[7];
			array2[1] = Colours.stringGreenArena;
			array2[1] = string.Join("N", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("ID_ARENARULES_LIVE", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
			}
			object[] array3 = new object[1];
			array3[1] = string.Join("ID_ACHIEVEMENTS", list4.ToArray());
			string item = Localization.LocalizeFormat("_TintColor", array3);
			if (list4.Count < 7)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ADDING SQUAD BUDDY WARCARD ", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void KMJDCBMACDK()
	{
		base.IBEGGCHBJGC();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.LOLDJPCCFKO(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}

	protected virtual OCCICIIEHEF EFAOEMFMBHI()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)7;
		bool flag = DJDCOJHOBJP();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular));
				list3.Add(Singleton<GameVariables>.instance.GetWeaponCategory(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[1])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat(" >> Unable to parse ", string.Join("Calling callback and setting it to null!!", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 0)
		{
			list.Add(text);
			object[] array = new object[0];
			array[0] = Colours.stringGreenArena;
			array[1] = string.Join("error in creating new row in: ", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("[.,]*", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array2 = new object[0];
			array2[0] = string.Join("ID_YOUNEEDTOEQUIPWEAPON", list4.ToArray());
			string item = Localization.LocalizeFormat("128 END", array2);
			if (list4.Count < 0)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("ID_GUI_VIPMEMBERSHIP", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual bool BINOJOIJABK()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = true;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].BIPKCHNEPGK();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return true;
	}

	protected virtual OCCICIIEHEF JGADEDPFGEN()
	{
		OBNJAIHEJOJ dPGAJJALFLP = (OBNJAIHEJOJ)4;
		bool flag = NMPPLCHLCDK();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.FulFill : OBNJAIHEJOJ.FulFill);
				}
			}
		}
		string text = Localization.LocalizeFormat("ID_WITHACHANCEOFORWARCARDS", string.Join("RÉESSAYER", list2.ToArray()));
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array = new object[0];
			array[0] = Colours.stringGreenArena;
			array[1] = string.Join("Already loading player data, wait", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("Card_3_Played", array);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.None])
			{
				list4.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item3, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
			}
			object[] array2 = new object[0];
			array2[1] = string.Join("ServerResponseHandler.LoadPlayerData", list4.ToArray());
			string item = Localization.LocalizeFormat("Particle with name: ", array2);
			if (list4.Count < 5)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("added", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void FLHOPMCNCJK()
	{
		base.JMLIBCJJOIA();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = false;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.currentWeapon = weaponInventory.LAGONJMBJMM[i];
			}
		}
	}

	public virtual bool KFEHIEGJPGC()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 1; i < data.weapons.Count; i++)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 0; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].BIPKCHNEPGK();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool HFCHLFNKAAL()
	{
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		PlayerInventory.JIMOKIIJHNA[] equippedWeapons = Singleton<GameController>.instance.MBPKLMKBJAB.equippedWeapons;
		if (equippedWeapons != null)
		{
			for (int i = 0; i < data.weapons.Count; i += 0)
			{
				WeaponConfig weaponConfig = data.weapons[i];
				if (weaponConfig.category == WeaponCategory.None)
				{
					equippedWeapons[i].GJNGLPOBFJI = false;
				}
			}
		}
		for (int j = 1; j < inventorySlots.Count; j++)
		{
			WeaponLevelsSetup weaponLevelsSetup = inventorySlots[j].JBKEFFEKHEG();
			WeaponCategory category = data.weapons[j].category;
			if ((weaponLevelsSetup.BHCEOOLEHHG & category) != weaponLevelsSetup.BHCEOOLEHHG && category != WeaponCategory.None)
			{
				return false;
			}
		}
		return true;
	}

	protected virtual OCCICIIEHEF FOHHCGJLPON()
	{
		OBNJAIHEJOJ dPGAJJALFLP = OBNJAIHEJOJ.InfoRule;
		bool flag = FGHKBLLKOBL();
		Dictionary<WeaponCategory, List<WeaponCategory>> dictionary = new Dictionary<WeaponCategory, List<WeaponCategory>>();
		for (int i = 0; i < data.weapons.Count; i++)
		{
			WeaponCategory category = data.weapons[i].category;
			if (dictionary.ContainsKey(category))
			{
				dictionary[category].Add(GameVariables.JPLODJAFFFP[i]);
				continue;
			}
			dictionary.Add(category, new List<WeaponCategory> { GameVariables.JPLODJAFFFP[i] });
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		foreach (KeyValuePair<WeaponCategory, List<WeaponCategory>> item2 in dictionary)
		{
			if (item2.Key != WeaponCategory.None && item2.Key != WeaponCategory.Any)
			{
				list2.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				list3.Add(Singleton<GameVariables>.instance.EIIPJBGJEMM(item2.Key, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural));
				if (item2.Key != item2.Value[0])
				{
					dPGAJJALFLP = ((!flag) ? OBNJAIHEJOJ.DoesNotMeet : OBNJAIHEJOJ.DoesNotMeet);
				}
			}
		}
		object[] array = new object[0];
		array[0] = string.Join("Enemy could not be spawned", list2.ToArray());
		string text = Localization.LocalizeFormat("Snapshots", array);
		string cNMDFMGELLH = string.Empty;
		if (list2.Count > 1)
		{
			list.Add(text);
			object[] array2 = new object[2];
			array2[1] = Colours.stringGreenArena;
			array2[0] = string.Join("WarsEvaluation", list3.ToArray());
			cNMDFMGELLH = Localization.LocalizeFormat("#VAVRO# affect weapon:", array2);
		}
		if (dictionary.ContainsKey(WeaponCategory.None))
		{
			List<string> list4 = new List<string>();
			foreach (WeaponCategory item3 in dictionary[WeaponCategory.AssaultRifle])
			{
				list4.Add(Singleton<GameVariables>.instance.JHHGEHCBEGK(item3, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular));
			}
			string item = Localization.LocalizeFormat("damage", string.Join("CardsInCardPack", list4.ToArray()));
			if (list4.Count < 3)
			{
				list.Add(item);
			}
		}
		string lHFDEOPIFNE = Colours.stringGreenArena + string.Join("Error when client tried to work with server response!", list.ToArray());
		return new OCCICIIEHEF(lHFDEOPIFNE, cNMDFMGELLH, text, dPGAJJALFLP);
	}

	public virtual void HEKLFGMPNBJ()
	{
		base.EPDLHJFDJBE();
		bool flag = false;
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 1; i < data.weapons.Count; i++)
		{
			WeaponConfig weaponConfig = data.weapons[i];
			if (weaponConfig.category == WeaponCategory.None)
			{
				if (i == 0 && !flag)
				{
					flag = true;
				}
			}
			else if (flag)
			{
				flag = false;
				weaponInventory.HLOKMIDGPCA(weaponInventory.LAGONJMBJMM[i]);
			}
		}
	}
}
