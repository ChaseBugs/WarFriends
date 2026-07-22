using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Scripting;

public class RentalManager : DatabaseSerializedObjectGeneric<RentalManager.RentalData>
{
	[Preserve]
	public class RentalData
	{
		public int type;

		public int sale;

		public string id;

		public int rentEnd;

		public int saleEnd;

		public bool expired;

		public bool rentDialogShowed;

		public bool buyDialogShowed;

		public int buyDialogShowTime;

		public string equippedWeapon;

		public override string ToString()
		{
			return null;
		}
	}

	private sealed class NHDIBEAPCLL
	{
		public Action<GameObject> DEEFEKEFHJF;

		internal void ALPKAOPFMME(bool EGMJAECMHBP)
		{
		}
	}

	private sealed class JMFAKONJCIM
	{
		public Action<GameObject> DEEFEKEFHJF;

		internal void PEKOJABNEDD(bool EGMJAECMHBP)
		{
		}
	}

	private string EOJMLGMCNEG;

	private bool ALHPDLBMLOM;

	public bool IOLOFBHHPDJ;

	public WeaponLevelsSetup KPHAMMEHBIH;

	public LevelBehaviour NBNADFIJOMI;

	[CompilerGenerated]
	private Action AEJILHEIDHP;

	private bool OIGIAJACJLA;

	private bool FAGAEDDGLFA;

	private bool KKJMCLNHBBC;

	private static RentalManager DJDBDKFAKHN;

	public int discount => 0;

	public int rentalEquipEnd => 0;

	public int rentalSaleEnd => 0;

	public bool isRentalEquipTime => false;

	public bool isRentalActive => false;

	private bool HDKLGLKCNIL => false;

	private bool HDPGHNLEKFD => false;

	public static RentalManager instance => null;

	public event Action StateChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void OnDestroy()
	{
	}

	protected override void LoadEmpty()
	{
	}

	protected override void InitData()
	{
	}

	protected override void Load(Dictionary<string, object> FIMDMKAOBGJ)
	{
	}

	protected override void Load(JToken FIMDMKAOBGJ)
	{
	}

	protected override void TryLoad(JToken FIMDMKAOBGJ)
	{
	}

	protected override void Awake()
	{
	}

	private void ILCIDOAOJIB()
	{
	}

	private void LOHMGGPFOLL()
	{
	}

	private void HCOCHDHHLPC(GameController.ALOAMODMHMO DEOBGKMOKEN)
	{
	}

	private void IIHDPJHAKAM()
	{
	}

	public void DialogShown(JMOIBFIIKMM.NMCEJCEFGJD JFACCKJNHHC)
	{
	}

	public bool WasRental(WeaponLevelsSetup AEBEOCBIBFI)
	{
		return false;
	}

	public bool WasRental(LevelBehaviour NGEDOMFLLKI)
	{
		return false;
	}

	public bool IsRental(WeaponLevelsSetup AEBEOCBIBFI)
	{
		return false;
	}

	public bool IsRental(LevelBehaviour NGEDOMFLLKI)
	{
		return false;
	}

	public void EquipRentalUnit()
	{
	}

	private void FCNCNJFKMHC()
	{
	}

	public bool BuyRentalUnit(Action<GameObject> DEEFEKEFHJF)
	{
		return false;
	}

	public void EquipRentalWeapon()
	{
	}

	private void IAEGIMNHLCO()
	{
	}

	public bool BuyRentalWeapon(Action<GameObject> DEEFEKEFHJF)
	{
		return false;
	}
}
