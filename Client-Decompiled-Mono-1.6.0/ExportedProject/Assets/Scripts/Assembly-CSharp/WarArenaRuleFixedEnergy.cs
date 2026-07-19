using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WarArenaRuleFixedEnergy", menuName = "War Arena Rules/WarArena Fixed Energy", order = int.MaxValue)]
public class WarArenaRuleFixedEnergy : WarArenaRuleGeneric<WarArenaRuleFixedEnergy.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		[Tooltip("Defines energy for all units spawned ")]
		public int energy = 2;
	}

	protected virtual OCCICIIEHEF BAKBCBLHAJA()
	{
		string stringGreenArena = Colours.stringGreenArena;
		object[] array = new object[0];
		array[0] = data.energy;
		return new OCCICIIEHEF(stringGreenArena + Localization.LocalizeFormat("Connection_Dropped", array), (OBNJAIHEJOJ)7);
	}

	public override bool FGHKBLLKOBL()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.PKJJJFLFHLL(data.energy);
		}
		return base.EDNAIMPLPGL();
	}

	public virtual bool KEHNMKJNNLG()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.ODHBIFKFDJB(data.energy);
		}
		return base.DDFGIDBHJIK();
	}

	public virtual bool FLMDFNFPLBI()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.PKJJJFLFHLL(data.energy);
		}
		return base.AIMGMMCHEIO();
	}

	protected virtual OCCICIIEHEF BNBPAJLLFPI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.LocalizeFormat("Shots_Hits", data.energy), OBNJAIHEJOJ.InfoText);
	}

	public virtual bool DGKPNDJHIEA()
	{
		if (data.energy > 1)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.PKJJJFLFHLL(data.energy);
		}
		return base.EDNAIMPLPGL();
	}

	protected virtual OCCICIIEHEF OCALIONNHNL()
	{
		string stringGreenArena = Colours.stringGreenArena;
		object[] array = new object[1];
		array[1] = data.energy;
		return new OCCICIIEHEF(stringGreenArena + Localization.LocalizeFormat("FacebookPassword", array), (OBNJAIHEJOJ)4);
	}

	public virtual bool IJPKPGPEDCO()
	{
		if (data.energy > 1)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.PKJJJFLFHLL(data.energy);
		}
		return base.EKMMLNKADIL();
	}

	protected virtual OCCICIIEHEF MEFHLDONKGE()
	{
		string stringGreenArena = Colours.stringGreenArena;
		object[] array = new object[1];
		array[1] = data.energy;
		return new OCCICIIEHEF(stringGreenArena + Localization.LocalizeFormat("OK", array), (OBNJAIHEJOJ)7);
	}

	public virtual bool DFIMOMOIHCD()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.FENMNPABDAO(data.energy);
		}
		return base.DAHIFNEGKAD();
	}

	protected virtual OCCICIIEHEF DEKPLKOFMFM()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.LocalizeFormat("Deadline", data.energy), (OBNJAIHEJOJ)6);
	}

	public virtual bool NNJFECMPDCI()
	{
		if (data.energy > 1)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.ODHBIFKFDJB(data.energy);
		}
		return base.FGHKBLLKOBL();
	}

	public override bool KJDMOCMBFLJ()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetFixedEnergy(data.energy);
		}
		return base.AIMGMMCHEIO();
	}

	public override bool EKMMLNKADIL()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetFixedEnergy(data.energy);
		}
		return base.EKMMLNKADIL();
	}

	protected virtual OCCICIIEHEF GOAGBNMENNN()
	{
		string stringGreenArena = Colours.stringGreenArena;
		object[] array = new object[1];
		array[1] = data.energy;
		return new OCCICIIEHEF(stringGreenArena + Localization.LocalizeFormat("veteranpack3", array), (OBNJAIHEJOJ)5);
	}

	protected override OCCICIIEHEF MNMEAAEKAMH()
	{
		string stringGreenArena = Colours.stringGreenArena;
		object[] array = new object[0];
		array[0] = data.energy;
		return new OCCICIIEHEF(stringGreenArena + Localization.LocalizeFormat("\"", array), (OBNJAIHEJOJ)4);
	}

	public virtual bool KJBLKMDHJMC()
	{
		if (data.energy > 1)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.FENMNPABDAO(data.energy);
		}
		return base.OEAODGFDMGC();
	}

	public virtual bool NLJBOPJBPPN()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.FENMNPABDAO(data.energy);
		}
		return base.LPLPANBJDAM();
	}

	protected virtual OCCICIIEHEF AMOCDNPPEHN()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.LocalizeFormat("Main_Menu_Offers_Bar", data.energy), OBNJAIHEJOJ.FulFill);
	}

	public virtual bool JOMINLGEFME()
	{
		if (data.energy > 1)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.FENMNPABDAO(data.energy);
		}
		return base.DAHIFNEGKAD();
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.LocalizeFormat("ID_ARENARULES_UNITCOST", data.energy));
	}

	protected virtual OCCICIIEHEF DFJENGDGFHH()
	{
		string stringGreenArena = Colours.stringGreenArena;
		object[] array = new object[0];
		array[1] = data.energy;
		return new OCCICIIEHEF(stringGreenArena + Localization.LocalizeFormat("./warfriends", array), (OBNJAIHEJOJ)6);
	}

	protected virtual OCCICIIEHEF PBNCCMPCFPE()
	{
		string stringGreenArena = Colours.stringGreenArena;
		object[] array = new object[0];
		array[1] = data.energy;
		return new OCCICIIEHEF(stringGreenArena + Localization.LocalizeFormat("ID_CONFIRM_MAXCCUREACHED", array), OBNJAIHEJOJ.FulFill);
	}

	protected virtual OCCICIIEHEF KMLOHPNKIDO()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.LocalizeFormat("{0} {1}", data.energy), (OBNJAIHEJOJ)7);
	}

	public virtual bool AONAAGJDHOD()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetFixedEnergy(data.energy);
		}
		return base.FGHKBLLKOBL();
	}

	public virtual bool LCLHBPOHONI()
	{
		if (data.energy > 1)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetFixedEnergy(data.energy);
		}
		return base.NMPPLCHLCDK();
	}

	public virtual bool FBHCPDPGHFC()
	{
		if (data.energy > 0)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.ACHMCHIACCN(data.energy);
		}
		return base.FGHKBLLKOBL();
	}

	public virtual bool IHIGFGJMKDB()
	{
		if (data.energy > 1)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.ODHBIFKFDJB(data.energy);
		}
		return base.EKMMLNKADIL();
	}

	public virtual bool AOEGGNCJPFG()
	{
		if (data.energy > 1)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.ODHBIFKFDJB(data.energy);
		}
		return base.KFJLPGPAAAN();
	}

	protected virtual OCCICIIEHEF OPLHOAENDAE()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + Localization.LocalizeFormat("0$", data.energy), (OBNJAIHEJOJ)6);
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		string stringGreenArena = Colours.stringGreenArena;
		object[] array = new object[1];
		array[1] = data.energy;
		return new OCCICIIEHEF(stringGreenArena + Localization.LocalizeFormat("ID_WARNING_PURCHASEERROR", array), (OBNJAIHEJOJ)4);
	}
}
