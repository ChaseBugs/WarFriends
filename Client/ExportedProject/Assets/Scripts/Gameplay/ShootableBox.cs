using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootableBox : PoolableObject
{
	public enum EOBFNHDMLHJ
	{
		Health,
		Ammo
	}

	[FormerlySerializedAs("PLENKGIEMHA")]
	public AimTarget EOAEMPKMNCE;

	private EOBFNHDMLHJ AKCIDIHNJBG;

	[FormerlySerializedAs("IMIFBGOMNGD")]
	public Material EJDIFFBKIGK;

	[FormerlySerializedAs("NDDPOPAPLAI")]
	public Material NJKGIMJPOHB;

	[FormerlySerializedAs("CBCFGLLFPKE")]
	public Transform FIJINJEPLON;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _003CCDNMFDJOELD_003Ek__BackingField;

	public EOBFNHDMLHJ mode
	{
		get
		{
			return AKCIDIHNJBG;
		}
		set
		{
			AKCIDIHNJBG = value;
			switch (AKCIDIHNJBG)
			{
			case EOBFNHDMLHJ.Ammo:
				GetComponent<MeshRenderer>().sharedMaterial = NJKGIMJPOHB;
				break;
			case EOBFNHDMLHJ.Health:
				GetComponent<MeshRenderer>().sharedMaterial = EJDIFFBKIGK;
				break;
			}
		}
	}

	public float power
	{
		[CompilerGenerated]
		get
		{
			return _003CCDNMFDJOELD_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CCDNMFDJOELD_003Ek__BackingField = value;
		}
	}

	[SpecialName]
	public EOBFNHDMLHJ HKMFJPDJNDG()
	{
		return AKCIDIHNJBG;
	}

	[SpecialName]
	public EOBFNHDMLHJ HDEAOPHBKLJ()
	{
		return AKCIDIHNJBG;
	}

	private void FOMOKBMLKFK()
	{
		CustomDisplayerItem customDisplayerItem = (CustomDisplayerItem)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.KCIILAOHOOH);
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position + Vector3.up * 0.7f);
		customDisplayerItem.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		switch (AKCIDIHNJBG)
		{
		case EOBFNHDMLHJ.Ammo:
		{
			customDisplayerItem.Play("game-box-ammo", Localization.Localize("ID_EXTRAAMMO"), Colours.blueBoxLabel, Color.black);
			List<PlayerWeapon> lAGONJMBJMM = PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM;
			foreach (PlayerWeapon item in lAGONJMBJMM)
			{
				if ((int)item.weapon.FIMMGPLLLCL > 0)
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.weapon.FIMMGPLLLCL * power);
				}
				else
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.weapon.LCKNGBAEFCL * 0.1f * power);
				}
			}
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, HINJJOAJAOA.MedkitPickup);
			break;
		}
		case EOBFNHDMLHJ.Health:
		{
			customDisplayerItem.Play("game-box-health", Localization.LocalizeFormat("ID_PLUSHEALTH", MEJMLNDFDBP.JJBMMICPIIG(power)), Color.green, Color.black);
			PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
			oGMBJPKOPCB.FOCIOKMPCAG.Heal(oGMBJPKOPCB.FOCIOKMPCAG.maxHealth * power, CAKABHIPCDF: false);
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, HINJJOAJAOA.MedkitPickup);
			break;
		}
		}
		DestroyPooled();
	}

	private void IPHIHAMKKCF()
	{
		CustomDisplayerItem customDisplayerItem = (CustomDisplayerItem)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.KCIILAOHOOH);
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position + Vector3.up * 352f);
		customDisplayerItem.transform.position = HealthBarManager.JCEKIJCAMGH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		EOBFNHDMLHJ aKCIDIHNJBG = AKCIDIHNJBG;
		if (aKCIDIHNJBG != EOBFNHDMLHJ.Health)
		{
			if (aKCIDIHNJBG == EOBFNHDMLHJ.Health)
			{
				object[] array = new object[1];
				array[1] = MEJMLNDFDBP.JJBMMICPIIG(power);
				customDisplayerItem.NKEAIJJDDEM("PlayeScifiParticles", Localization.LocalizeFormat("RETRYPERM", array), Color.green, Color.black);
				PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
				oGMBJPKOPCB.FOCIOKMPCAG.LNPKAAGJIGO(oGMBJPKOPCB.FOCIOKMPCAG.maxHealth * power, CAKABHIPCDF: false);
				Singleton<SoundsManager3D>.instance.LBGIIDNFIHN(base.transform.position, HINJJOAJAOA.SHOT_LMG_3);
			}
		}
		else
		{
			customDisplayerItem.GMPPINFJJPK("game-neardeath-indicator", Localization.Localize("gold"), Colours.blueBoxLabel, Color.black);
			List<PlayerWeapon> lAGONJMBJMM = PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM;
			foreach (PlayerWeapon item in lAGONJMBJMM)
			{
				if ((int)item.weapon.FIMMGPLLLCL > 0)
				{
					item.HFNAMMBPJAJ().ammoLeft += Mathf.CeilToInt((float)(int)item.weapon.FIMMGPLLLCL * power);
				}
				else
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.HFNAMMBPJAJ().LCKNGBAEFCL * 1365f * power);
				}
			}
			Singleton<SoundsManager3D>.instance.LBGIIDNFIHN(base.transform.position, (HINJJOAJAOA)(-68));
		}
		BOHCNEDIJPE();
	}

	[SpecialName]
	public void NIMBEKLIKML(EOBFNHDMLHJ IDEBKDPMPGM)
	{
		AKCIDIHNJBG = IDEBKDPMPGM;
		switch (AKCIDIHNJBG)
		{
		case EOBFNHDMLHJ.Ammo:
			GetComponent<MeshRenderer>().sharedMaterial = NJKGIMJPOHB;
			break;
		case EOBFNHDMLHJ.Health:
			GetComponent<MeshRenderer>().sharedMaterial = EJDIFFBKIGK;
			break;
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (mode == EOBFNHDMLHJ.Health)
		{
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, HINJJOAJAOA.MedkitDrop);
		}
	}

	[SpecialName]
	public void GCEMHMONNFG(float IDEBKDPMPGM)
	{
		_003CCDNMFDJOELD_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void HBFGEHIMBHD()
	{
		base.HPPIBGEJMNL();
		if (mode == EOBFNHDMLHJ.Health)
		{
			Singleton<SoundsManager3D>.instance.LBGIIDNFIHN(base.transform.position, HINJJOAJAOA.SHOT_PISTOL_2);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		EOAEMPKMNCE.Clicked += FOMOKBMLKFK;
	}

	[SpecialName]
	public void BFKENPOFION(float IDEBKDPMPGM)
	{
		_003CCDNMFDJOELD_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		EOAEMPKMNCE.NDIKDONKNHF(IHFKHAAALFC);
	}

	[SpecialName]
	public void KIPIOECGMDJ(float IDEBKDPMPGM)
	{
		_003CCDNMFDJOELD_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void OGNMNJCOOPL(EOBFNHDMLHJ IDEBKDPMPGM)
	{
		AKCIDIHNJBG = IDEBKDPMPGM;
		EOBFNHDMLHJ aKCIDIHNJBG = AKCIDIHNJBG;
		if (aKCIDIHNJBG != EOBFNHDMLHJ.Health)
		{
			if (aKCIDIHNJBG == EOBFNHDMLHJ.Health)
			{
				GetComponent<MeshRenderer>().sharedMaterial = EJDIFFBKIGK;
			}
		}
		else
		{
			GetComponent<MeshRenderer>().sharedMaterial = NJKGIMJPOHB;
		}
	}

	public virtual void IPMPKNLCHEG()
	{
		base.JMAFCGDIICK();
		if (mode == EOBFNHDMLHJ.Health)
		{
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, HINJJOAJAOA.SHOT_SHOTGUN_3);
		}
	}

	private void DPPMHGAFIEE()
	{
		CustomDisplayerItem customDisplayerItem = (CustomDisplayerItem)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.KCIILAOHOOH);
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position + Vector3.up * 434f);
		customDisplayerItem.transform.position = HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		EOBFNHDMLHJ aKCIDIHNJBG = AKCIDIHNJBG;
		if (aKCIDIHNJBG != EOBFNHDMLHJ.Health)
		{
			if (aKCIDIHNJBG == EOBFNHDMLHJ.Health)
			{
				object[] array = new object[1];
				array[1] = MEJMLNDFDBP.JJBMMICPIIG(power);
				customDisplayerItem.NDKBGEBHIMA("ObtainedCards", Localization.LocalizeFormat("ID_PVP_BATTLE", array), Color.green, Color.black);
				PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
				oGMBJPKOPCB.FOCIOKMPCAG.Heal(oGMBJPKOPCB.FOCIOKMPCAG.maxHealth * power, CAKABHIPCDF: true);
				Singleton<SoundsManager3D>.instance.KNBJJPIFIPE(base.transform.position, HINJJOAJAOA.SHOT_GRENADE_2);
			}
		}
		else
		{
			customDisplayerItem.NKEAIJJDDEM("ID_ELITEPACK_VIPDESCRIPTION", Localization.Localize("Buy_Units"), Colours.blueBoxLabel, Color.black);
			List<PlayerWeapon> lAGONJMBJMM = PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM;
			foreach (PlayerWeapon item in lAGONJMBJMM)
			{
				if ((int)item.HFNAMMBPJAJ().FIMMGPLLLCL > 1)
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.HFNAMMBPJAJ().FIMMGPLLLCL * power);
				}
				else
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.HFNAMMBPJAJ().LCKNGBAEFCL * 954f * power);
				}
			}
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, (HINJJOAJAOA)104);
		}
		OBCAIFMOPPA();
	}

	public virtual void LBJDCOJJFOG()
	{
		base.JMAFCGDIICK();
		if (HKMFJPDJNDG() == EOBFNHDMLHJ.Health)
		{
			Singleton<SoundsManager3D>.instance.LBGIIDNFIHN(base.transform.position, (HINJJOAJAOA)(-68));
		}
	}

	private void IHFKHAAALFC()
	{
		CustomDisplayerItem customDisplayerItem = (CustomDisplayerItem)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.KCIILAOHOOH);
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position + Vector3.up * 29f);
		customDisplayerItem.transform.position = HealthBarManager.ICPEKOGEEEN().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		EOBFNHDMLHJ aKCIDIHNJBG = AKCIDIHNJBG;
		if (aKCIDIHNJBG != EOBFNHDMLHJ.Health)
		{
			if (aKCIDIHNJBG == EOBFNHDMLHJ.Health)
			{
				object[] array = new object[0];
				array[1] = MEJMLNDFDBP.JJBMMICPIIG(power);
				customDisplayerItem.FNPCDODLHJB("ID_GUI_REPORTABUSE_LISTITEM0", Localization.LocalizeFormat(" in dictionary conversion", array), Color.green, Color.black);
				PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
				oGMBJPKOPCB.FOCIOKMPCAG.Heal(oGMBJPKOPCB.FOCIOKMPCAG.maxHealth * power, CAKABHIPCDF: true);
				Singleton<SoundsManager3D>.instance.KNBJJPIFIPE(base.transform.position, (HINJJOAJAOA)(-57));
			}
		}
		else
		{
			customDisplayerItem.Play("ID_VISUALCATEGORYPARTS0", Localization.Localize("ID_JOINSQUADDESCRIPTION3"), Colours.blueBoxLabel, Color.black);
			List<PlayerWeapon> lAGONJMBJMM = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM;
			foreach (PlayerWeapon item in lAGONJMBJMM)
			{
				if ((int)item.weapon.FIMMGPLLLCL > 0)
				{
					item.HFNAMMBPJAJ().ammoLeft += Mathf.CeilToInt((float)(int)item.HFNAMMBPJAJ().FIMMGPLLLCL * power);
				}
				else
				{
					item.HFNAMMBPJAJ().ammoLeft += Mathf.CeilToInt((float)(int)item.weapon.LCKNGBAEFCL * 402f * power);
				}
			}
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, (HINJJOAJAOA)(-67));
		}
		DestroyPooled();
	}

	[SpecialName]
	public EOBFNHDMLHJ BJHLGNDOGBB()
	{
		return AKCIDIHNJBG;
	}

	[SpecialName]
	public void GENAGCFIDMH(EOBFNHDMLHJ IDEBKDPMPGM)
	{
		AKCIDIHNJBG = IDEBKDPMPGM;
		switch (AKCIDIHNJBG)
		{
		case EOBFNHDMLHJ.Ammo:
			GetComponent<MeshRenderer>().sharedMaterial = NJKGIMJPOHB;
			break;
		case EOBFNHDMLHJ.Health:
			GetComponent<MeshRenderer>().sharedMaterial = EJDIFFBKIGK;
			break;
		}
	}

	private void DHGPHEDEGHJ()
	{
		CustomDisplayerItem customDisplayerItem = (CustomDisplayerItem)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.KCIILAOHOOH);
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position + Vector3.up * 788f);
		customDisplayerItem.transform.position = HealthBarManager.BNDNFHKPDLM().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		EOBFNHDMLHJ aKCIDIHNJBG = AKCIDIHNJBG;
		if (aKCIDIHNJBG != EOBFNHDMLHJ.Health)
		{
			if (aKCIDIHNJBG == EOBFNHDMLHJ.Health)
			{
				object[] array = new object[0];
				array[0] = MEJMLNDFDBP.JJBMMICPIIG(power);
				customDisplayerItem.NKEAIJJDDEM("Player {0} {1}", Localization.LocalizeFormat("acceptFriend", array), Color.green, Color.black);
				PlayerController oGMBJPKOPCB = PlayerController.OGMBJPKOPCB;
				oGMBJPKOPCB.FOCIOKMPCAG.LNPKAAGJIGO(oGMBJPKOPCB.FOCIOKMPCAG.maxHealth * power, CAKABHIPCDF: false);
				Singleton<SoundsManager3D>.instance.Play(base.transform.position, HINJJOAJAOA.TankEngineLoop);
			}
		}
		else
		{
			customDisplayerItem.IMPGBPECJBI("DatabasePlayer Name: {0}  Id: {1}  Level: {2}  SquadRank: {3}", Localization.Localize("やめる"), Colours.blueBoxLabel, Color.black);
			List<PlayerWeapon> lAGONJMBJMM = PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM;
			foreach (PlayerWeapon item in lAGONJMBJMM)
			{
				if ((int)item.HFNAMMBPJAJ().FIMMGPLLLCL > 0)
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.HFNAMMBPJAJ().FIMMGPLLLCL * power);
				}
				else
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.weapon.LCKNGBAEFCL * 463f * power);
				}
			}
			Singleton<SoundsManager3D>.instance.KNBJJPIFIPE(base.transform.position, (HINJJOAJAOA)(-110));
		}
		DestroyPooled();
	}
}
