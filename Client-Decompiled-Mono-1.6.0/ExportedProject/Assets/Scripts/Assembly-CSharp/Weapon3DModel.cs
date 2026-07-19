using System;
using System.Collections.Generic;
using UnityEngine;

public class Weapon3DModel : Core_BaseScript
{
	[Serializable]
	public class WeaponSlot
	{
		public Transform slotPosition;

		public int slotID;
	}

	public List<WeaponSlot> FLLKOAEGNDE;

	public void KGEHKAOPKME()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_TUTORIAL_GO_TO_ARMORY_5");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void FAAIHMKLICF()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Squad was deleted.");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void BGPOIGKLDJE()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_JOINSQUAD");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void PKKDFDBLGGO()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_UNIT2UPGRADEABILITY_UNIT1UPGRADE");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void HKEGNEKFLGK()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_REMINDER_WEAPONUPGRADEREADY");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void FNODJNFHOCJ()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("rental for unexist visual: {0}");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void AGMCODPPOGO()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Gold");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void UnloadWeapon()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("_BumpMap");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void HNACDPPJNKC()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("PhotonNetwork.room == null!");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void IOEAIELCGPJ()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("SquadId");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void DOALIMPJADA()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("LICENSE_CHECK_FAILED");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void IBKOGCMFDCM()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_ARENARULES_STRONGERUNITS");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void EHDBFCGPFOG()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Conversion");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void DNJBDGPDHAO()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_WARNING_CANTSENDINVITE");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void NEFHANBODAO()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Action ");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void COEEHNJJBGA()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_SILVERLOOTBOXSMALL");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void ALEOGKEBLOE()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("DailyGold");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void NGPGDNNLHHN()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("gold");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void CKDOEBJBPCA()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("DailyRentalMessage{0}{1}{2}");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void CCCMELMFGLO()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_SUGGESTEDGLOBALSQUADS");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void AHGPHNPINKJ()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_BUTTONPREVIOUSHEROES");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void JCCNMFKAMDJ()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Pause status: {0}, WantedTimeScale: {1}, TimeScale: {2}, Freezed:  {3}");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void LBKGBFCHHCL()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_FRIENDREFUSEDREMATCHCOOP");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void LDGJMCKHGLH()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_WARNING_NOTENOUGHTGOLDFORWARBUCKS");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void PKNHHJJHAMA()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("menu-helmets-reaper");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void IFKKBFEKOIF()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("FacebookId");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void MHKFCOPOBPK()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("MissionData");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void HPBDMBNLFKI()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Vip status changed!");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void AFEEIBEANKN()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("VipRewardForDay");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void IFDEGELPKOG()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_SLOTUPGRADE_HEAT");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void BFJOPENHJDI()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("CardTrade_Deposit");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void OCAPKGEOBDB()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("#Mission# New Wawe comming");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void Load()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("_BumpMap");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void LACDOIBICGN()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Sheet ");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void KAMOMELNLPI()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("BANDS");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void CFAKFCKMDDJ()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_MEMBERS");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void BGINMFEFACC()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_WARNING_ACHIEVEMENTALREADYCLAIMED");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void FHKMKCAOGNK()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_ARENABOXDESCRIPTION_ELITEPARTS");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void ENMIHJIEPGF()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Squad Member record does not have DatabasePlayer");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void GHKHCACOPKI()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_ASSIGNMENTX");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void FCDOPHGCHML()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("PlacementMatchesRequired");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void KOCOEHOCPIH()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ExplodeDamage");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void PANFFMPAHOP()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("RweardModifierWB");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void DHMKENKKHAP()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		if (componentInChildren != null)
		{
			Resources.UnloadAsset(componentInChildren.sharedMesh);
		}
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_LEAGUENAME");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			if (mainTexture != null)
			{
				Resources.UnloadAsset(mainTexture);
			}
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void CJIACJICGBM()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Bad player statistics, data= ");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void GIIFJLGMBAO()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("Action");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}

	public void ALJNJMENGFM()
	{
		MeshFilter componentInChildren = GetComponentInChildren<MeshFilter>();
		Mesh sharedMesh = componentInChildren.sharedMesh;
		MeshRenderer componentInChildren2 = GetComponentInChildren<MeshRenderer>();
		if (componentInChildren2 != null)
		{
			Material sharedMaterial = componentInChildren2.sharedMaterial;
			Texture texture = sharedMaterial.GetTexture("ID_CONFIRM_INFO");
			if ((bool)texture)
			{
				int width = texture.width;
			}
			Texture mainTexture = sharedMaterial.mainTexture;
			int width2 = mainTexture.width;
			sharedMaterial.mainTexture = null;
			sharedMaterial.mainTexture = mainTexture;
			Resources.UnloadAsset(sharedMaterial);
		}
	}
}
