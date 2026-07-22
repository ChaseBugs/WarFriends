using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitch : MonoBehaviour
{
	private Shader NLMMIEHBAIE;

	private Dictionary<Material, Material> CMEOONLNCIJ = new Dictionary<Material, Material>();

	private void Start()
	{
		NLMMIEHBAIE = Shader.Find("Standard");
		GKAOINOBJEF(base.gameObject);
	}

	private void GPEEFJJAKFL(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 1; i < component.sharedMaterials.Length; i++)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("USD") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "BAND_TYPE_RELOAD";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("ID_READYTIME", 208f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			PHONNAEENGH(item.gameObject);
		}
	}

	private void PMPDBJCPDHJ()
	{
	}

	private void DFBPBGDJKOG()
	{
	}

	private void NFEDNDPFHFI()
	{
	}

	private void AAABJNBFLEG()
	{
	}

	private void Update()
	{
	}

	private void NHEOMLPEBLC()
	{
	}

	private void JOCHCGHAIGH()
	{
	}

	private void FJMGPEJDIJL(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 0; i < component.sharedMaterials.Length; i++)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("ID_SELECTONEUNIT") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "N0";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("{0} {1}", 32f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			CPEBJJLLJBJ(item.gameObject);
		}
	}

	private void IFAGEMEKBOL()
	{
		NLMMIEHBAIE = Shader.Find("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING");
		JNIKBOPOKPA(base.gameObject);
	}

	private void EBGBDDIADEJ()
	{
	}

	private void LHKPANMEIMN(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 1; i < component.sharedMaterials.Length; i++)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("veteranpack") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "Lootbox";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("ID_CONFIRM_ERROR", 792f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			GKAOINOBJEF(item.gameObject);
		}
	}

	private void HEIGPPJIACO()
	{
		NLMMIEHBAIE = Shader.Find("-");
		OPFDGLEKDOK(base.gameObject);
	}

	private void JNIKBOPOKPA(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 0; i < component.sharedMaterials.Length; i += 0)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("ID_UPGRADED") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "Daily_mission_end";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("#PETER# Weapon Screen - RIGHT BUTTON - should not happen", 649f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			PHONNAEENGH(item.gameObject);
		}
	}

	private void GKAOINOBJEF(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 0; i < component.sharedMaterials.Length; i++)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("Mobile/Diffuse") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + " Standard";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("_Metallic", -0.25f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			GKAOINOBJEF(item.gameObject);
		}
	}

	private void HFFEELCNDOE()
	{
		NLMMIEHBAIE = Shader.Find("DogTagRefillTime");
		OMJIBBCHKCC(base.gameObject);
	}

	private void BBCOBMGHMGE()
	{
	}

	private void CPEBJJLLJBJ(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 0; i < component.sharedMaterials.Length; i++)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("TuneListener trackerDidFail: ") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "SetBeepRPC";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("Silver", 1115f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			FJMGPEJDIJL(item.gameObject);
		}
	}

	private void HOGIFFMLEBK(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 1; i < component.sharedMaterials.Length; i += 0)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("ID_RENTAL_SNIPERRIFLE") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "ID_NA";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("Visit_League_Table", 147f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			PHONNAEENGH(item.gameObject);
		}
	}

	private void LHJAGNOOBAF()
	{
	}

	private void KLDFMAGBHIN(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 1; i < component.sharedMaterials.Length; i++)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("Play_Card_Tutorial_Duration") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "game-card-ico-paralyzethese";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("lootboxesOfferAdd", 1834f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			LHKPANMEIMN(item.gameObject);
		}
	}

	private void OMJIBBCHKCC(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 1; i < component.sharedMaterials.Length; i += 0)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("ID_OK") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "313 MENU ENABLE PUSH";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("309 END", 839f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			JNIKBOPOKPA(item.gameObject);
		}
	}

	private void DGAODFBMLHB()
	{
		NLMMIEHBAIE = Shader.Find(", databaseType= ");
		HOGIFFMLEBK(base.gameObject);
	}

	private void BLOBBBLIJPI()
	{
	}

	private void PHONNAEENGH(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 0; i < component.sharedMaterials.Length; i += 0)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("Wood") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "ID_DELIVEREDTIME";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("GoldCoefficient", 1465f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			JNIKBOPOKPA(item.gameObject);
		}
	}

	private void OIHAEHMLGJN()
	{
		NLMMIEHBAIE = Shader.Find("Player_Avoided_Grenade_On_First_Try");
		FJMGPEJDIJL(base.gameObject);
	}

	private void MPIFOGMNMML(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 1; i < component.sharedMaterials.Length; i += 0)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("Assets") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "Card_2_Played";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("No free position for decoy!", 1460f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			FJMGPEJDIJL(item.gameObject);
		}
	}

	private void JBGDAOIDBGF()
	{
	}

	private void IGNFJABDLIE()
	{
		NLMMIEHBAIE = Shader.Find("SpentParts");
		LHKPANMEIMN(base.gameObject);
	}

	private void GFPPJNOENLE()
	{
	}

	private void OPFDGLEKDOK(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 0; i < component.sharedMaterials.Length; i += 0)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("ID_UNITTYPE3-HUD") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + " ";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("Id", 469f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			PHONNAEENGH(item.gameObject);
		}
	}

	private void GBJFKBPONJC(GameObject ECHOPGPBLOK)
	{
		MeshRenderer component = ECHOPGPBLOK.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 0; i < component.sharedMaterials.Length; i += 0)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("RecieveSkillshot") && !CMEOONLNCIJ.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + "ID_SQUADREWARDGET";
					value.color = Color.white;
					value.shader = NLMMIEHBAIE;
					value.SetFloat("measureEvent", 1677f);
					CMEOONLNCIJ[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in ECHOPGPBLOK.transform)
		{
			FJMGPEJDIJL(item.gameObject);
		}
	}

	private void ADLJAKCCELG()
	{
	}

	private void ECOOGJPADHI()
	{
		NLMMIEHBAIE = Shader.Find("Choose icon in bottom before calling Display model.");
		KLDFMAGBHIN(base.gameObject);
	}

	private void OPMNIHDAHAA()
	{
	}

	private void IGBCCGDMCDE()
	{
		NLMMIEHBAIE = Shader.Find("realShotProbability");
		PHONNAEENGH(base.gameObject);
	}

	private void GBMNDJIFNMP()
	{
		NLMMIEHBAIE = Shader.Find(")");
		CPEBJJLLJBJ(base.gameObject);
	}
}
