using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitch : MonoBehaviour
{
	private Shader standard;

	private Dictionary<Material, Material> materials = new Dictionary<Material, Material>();

	private void Start()
	{
		standard = Shader.Find("Standard");
		Perform(base.gameObject);
	}

	private void Update()
	{
	}

	private void Perform(GameObject o)
	{
		MeshRenderer component = o.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] array = new Material[component.sharedMaterials.Length];
			for (int i = 0; i < component.sharedMaterials.Length; i++)
			{
				Material material = component.sharedMaterials[i];
				Material value = material;
				if (material.shader.name.StartsWith("Mobile/Diffuse") && !materials.TryGetValue(material, out value))
				{
					value = new Material(material);
					value.name = material.name + " Standard";
					value.color = Color.white;
					value.shader = standard;
					value.SetFloat("_Metallic", -0.25f);
					materials[material] = value;
				}
				array[i] = value;
				Debug.Log(material.shader.name);
			}
			component.sharedMaterials = array;
		}
		foreach (Transform item in o.transform)
		{
			Perform(item.gameObject);
		}
	}
}
