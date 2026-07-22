using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerVisualHead : PlayerVisual
{
	public enum BLBNGIIJGFD
	{
		Forhead = 1,
		Eyes = 2,
		Mouth = 4,
		All = 16777215
	}

	[Serializable]
	public class CamoTransform
	{
		public string camoName;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;

		public static void BPMHDCJJHNC(GameObject MHOMLJFAFHO, CamoTransform BCJFEKCDBCN)
		{
		}
	}

	public string path;

	public BLBNGIIJGFD headPart;

	public List<CamoTransform> camoTransforms;

	public Dictionary<string, CamoTransform> camoTransformDict;

	public MeshRenderer mesh { get; private set; }

	public override void CDJFLJEACIP()
	{
	}

	public override void BMHGNPDPBGL()
	{
	}

	public override void OCNHEFIPELO()
	{
	}

	public override void DMNOEANLNHM(AFIKFLMIBBA HHCDBKJFPBD, bool LGJJGEBKKKF = false)
	{
	}

	public override void FPFDNHHGFPP()
	{
	}

	public MeshRenderer NHOBDNGBMLL()
	{
		return null;
	}
}
