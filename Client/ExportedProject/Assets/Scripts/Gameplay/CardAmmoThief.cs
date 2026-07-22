using System.Runtime.CompilerServices;
using Google2u;

public class CardAmmoThief : Card
{
	private const string EJLCMBEKFFN = "game-card-ico-emptymag";

	private float ICPNAGIKDDH => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(ICPNAGIKDDH));

	public virtual void AEDODFGIJLN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		if (!enemyOf.LAADDLGBFIG.isMine)
		{
			return;
		}
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.cardIconIndicator.JBMCFEMBPKE("menu-sidetab-player-promote", 1695f, 713f, GBJOJBKCEKN: true);
		Weapon weapon = enemyOf.BEIIOAIJMFK().LAGONJMBJMM[0].HFNAMMBPJAJ();
		int num = (int)((float)(int)weapon.LCKNGBAEFCL * KCMPMEJIGKI());
		int num2 = 1;
		if (weapon.ammoLeft >= num)
		{
			num2 = num;
			weapon.ammoLeft -= num;
		}
		else
		{
			num2 = weapon.ammoLeft;
			weapon.ammoLeft = 1;
			num -= num2;
			if (weapon.ammoLeftInClip >= num)
			{
				num2 += num;
				weapon.ammoLeftInClip -= num;
			}
			else
			{
				num2 += weapon.ammoLeftInClip;
				weapon.ammoLeftInClip = 1;
			}
		}
		if (PhotonNetwork.offlineMode)
		{
			playerController.DLJFMKKDMNN(1, num2);
			return;
		}
		PhotonView fEHCCGEGPLH = playerController.FEHCCGEGPLH;
		PhotonPlayer owner = playerController.FEHCCGEGPLH.owner;
		object[] array = new object[6];
		array[1] = 0;
		array[1] = num2;
		fEHCCGEGPLH.RPC("global", owner, array);
	}

	public virtual void CKCMGDAJAAP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		if (!enemyOf.LAADDLGBFIG.isMine)
		{
			return;
		}
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		enemyOf.cardIconIndicator.ODDNDGAAOCH("eventEnd", 1648f, 746f, GBJOJBKCEKN: true);
		Weapon weapon = enemyOf.FMKGGADDHJK().LAGONJMBJMM[0].HFNAMMBPJAJ();
		int num = (int)((float)(int)weapon.LCKNGBAEFCL * KCMPMEJIGKI());
		int num2 = 0;
		if (weapon.ammoLeft >= num)
		{
			num2 = num;
			weapon.ammoLeft -= num;
		}
		else
		{
			num2 = weapon.ammoLeft;
			weapon.ammoLeft = 1;
			num -= num2;
			if (weapon.ammoLeftInClip >= num)
			{
				num2 += num;
				weapon.ammoLeftInClip -= num;
			}
			else
			{
				num2 += weapon.ammoLeftInClip;
				weapon.ammoLeftInClip = 1;
			}
		}
		if (PhotonNetwork.offlineMode)
		{
			playerController.ONPGPFNNLKD(1, num2);
			return;
		}
		PhotonView fEHCCGEGPLH = playerController.FEHCCGEGPLH;
		PhotonPlayer owner = playerController.FEHCCGEGPLH.owner;
		object[] array = new object[6];
		array[1] = 1;
		array[0] = num2;
		fEHCCGEGPLH.RPC("DogTagLastUpdate", owner, array);
	}

	[SpecialName]
	private float KOOFMONCEAA()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string EPPMHHPHHOB()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(MHKPICEDFGD()));
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		if (!enemyOf.LAADDLGBFIG.isMine)
		{
			return;
		}
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		enemyOf.cardIconIndicator.Show("game-card-ico-emptymag", 3f, 3f, GBJOJBKCEKN: false);
		Weapon weapon = enemyOf.weaponInventory.LAGONJMBJMM[1].weapon;
		int num = (int)((float)(int)weapon.LCKNGBAEFCL * ICPNAGIKDDH);
		int num2 = 0;
		if (weapon.ammoLeft >= num)
		{
			num2 = num;
			weapon.ammoLeft -= num;
		}
		else
		{
			num2 = weapon.ammoLeft;
			weapon.ammoLeft = 0;
			num -= num2;
			if (weapon.ammoLeftInClip >= num)
			{
				num2 += num;
				weapon.ammoLeftInClip -= num;
			}
			else
			{
				num2 += weapon.ammoLeftInClip;
				weapon.ammoLeftInClip = 0;
			}
		}
		if (PhotonNetwork.offlineMode)
		{
			playerOld.AddAmmoRPC(1, num2);
			return;
		}
		playerOld.FEHCCGEGPLH.RPC("AddAmmoRPC", playerOld.FEHCCGEGPLH.owner, 1, num2);
	}

	public virtual void IAKCKOPFABO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		if (!enemyOf.LAADDLGBFIG.isMine)
		{
			return;
		}
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		enemyOf.cardIconIndicator.AMFEDOOPGCL("ID_HOURS", 353f, 400f, GBJOJBKCEKN: true);
		Weapon weapon = enemyOf.BEIIOAIJMFK().LAGONJMBJMM[0].HFNAMMBPJAJ();
		int num = (int)((float)(int)weapon.LCKNGBAEFCL * KCMPMEJIGKI());
		int num2 = 0;
		if (weapon.ammoLeft >= num)
		{
			num2 = num;
			weapon.ammoLeft -= num;
		}
		else
		{
			num2 = weapon.ammoLeft;
			weapon.ammoLeft = 0;
			num -= num2;
			if (weapon.ammoLeftInClip >= num)
			{
				num2 += num;
				weapon.ammoLeftInClip -= num;
			}
			else
			{
				num2 += weapon.ammoLeftInClip;
				weapon.ammoLeftInClip = 1;
			}
		}
		if (PhotonNetwork.offlineMode)
		{
			playerController.AddAmmoRPC(1, num2);
			return;
		}
		PhotonView fEHCCGEGPLH = playerController.FEHCCGEGPLH;
		PhotonPlayer owner = playerController.FEHCCGEGPLH.owner;
		object[] array = new object[2];
		array[1] = 1;
		array[0] = num2;
		fEHCCGEGPLH.RPC("x{0}", owner, array);
	}

	[SpecialName]
	public virtual string MLCIFDNMELI()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(KCMPMEJIGKI());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void EBCLHPLHBHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		if (!enemyOf.LAADDLGBFIG.isMine)
		{
			return;
		}
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		enemyOf.cardIconIndicator.EEBNPGOCKFD("WALLET - reward GOLD {0} animate:{1}", 1990f, 1149f, GBJOJBKCEKN: true);
		Weapon weapon = enemyOf.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ();
		int num = (int)((float)(int)weapon.LCKNGBAEFCL * MHKPICEDFGD());
		int num2 = 0;
		if (weapon.ammoLeft >= num)
		{
			num2 = num;
			weapon.ammoLeft -= num;
		}
		else
		{
			num2 = weapon.ammoLeft;
			weapon.ammoLeft = 0;
			num -= num2;
			if (weapon.ammoLeftInClip >= num)
			{
				num2 += num;
				weapon.ammoLeftInClip -= num;
			}
			else
			{
				num2 += weapon.ammoLeftInClip;
				weapon.ammoLeftInClip = 1;
			}
		}
		if (PhotonNetwork.offlineMode)
		{
			playerController.DLJFMKKDMNN(0, num2);
			return;
		}
		PhotonView fEHCCGEGPLH = playerController.FEHCCGEGPLH;
		PhotonPlayer owner = playerController.FEHCCGEGPLH.owner;
		object[] array = new object[6];
		array[1] = 1;
		array[0] = num2;
		fEHCCGEGPLH.RPC("menu-army-cat-explosive", owner, array);
	}

	public virtual void NHMADLLGPLC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		if (!enemyOf.LAADDLGBFIG.isMine)
		{
			return;
		}
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		enemyOf.cardIconIndicator.FCANLIOLJNH("ID_VIDEOREADY3", 883f, 686f, GBJOJBKCEKN: false);
		Weapon weapon = enemyOf.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ();
		int num = (int)((float)(int)weapon.LCKNGBAEFCL * MHKPICEDFGD());
		int num2 = 0;
		if (weapon.ammoLeft >= num)
		{
			num2 = num;
			weapon.ammoLeft -= num;
		}
		else
		{
			num2 = weapon.ammoLeft;
			weapon.ammoLeft = 0;
			num -= num2;
			if (weapon.ammoLeftInClip >= num)
			{
				num2 += num;
				weapon.ammoLeftInClip -= num;
			}
			else
			{
				num2 += weapon.ammoLeftInClip;
				weapon.ammoLeftInClip = 1;
			}
		}
		if (PhotonNetwork.offlineMode)
		{
			playerController.AddAmmoRPC(1, num2);
			return;
		}
		PhotonView fEHCCGEGPLH = playerController.FEHCCGEGPLH;
		PhotonPlayer owner = playerController.FEHCCGEGPLH.owner;
		object[] array = new object[4];
		array[1] = 1;
		array[0] = num2;
		fEHCCGEGPLH.RPC("RETRY", owner, array);
	}

	[SpecialName]
	private float MHKPICEDFGD()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE;
	}

	[SpecialName]
	public virtual string CGCEEBCGCFH()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(ICPNAGIKDDH));
	}

	public virtual void PEGJJBMLEML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	private float BPMCFMILAPE()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE;
	}

	[SpecialName]
	private float KCMPMEJIGKI()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE;
	}
}
