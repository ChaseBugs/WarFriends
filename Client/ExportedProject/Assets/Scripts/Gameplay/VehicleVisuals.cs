using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class VehicleVisuals : Core_BaseScript
{
	[FormerlySerializedAs("IHOEHGMFODF")]
	public ModelAttachments BLHMGOMCDFG;

	[FormerlySerializedAs("MMIJOHKMAFL")]
	public Renderer BNNLNOIHAAM;

	[FormerlySerializedAs("EJGPJMGPMNI")]
	public List<MeshRenderer> KNEMCHNNOOC;

	public void BLDNPOIIJKI()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("): ", null);
		BLHMGOMCDFG.JDJGJKNKBIC();
	}

	public void EJJELHNIJPO()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("AssignmentData", null);
		BLHMGOMCDFG.EHODOJBGHFE();
	}

	public void CGKEEDINDBJ(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GJBCHFFALBJ(FKAJIJIGNEN);
	}

	public void IEPBCFNIKAI(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.SetAttachmentsMaterial(FKAJIJIGNEN);
	}

	public void EBEKCCMEBIH(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.ICJJOOFHEJC(FKAJIJIGNEN);
	}

	public void JLDMJDBIEJA(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.LEGDLNGKLGO(FKAJIJIGNEN);
	}

	public void IHBJGLKGGHE(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.FJMHEOLCFHE() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("eventStart", Singleton<MatCapTextures>.instance.BBFAKOCKHHA());
		BLHMGOMCDFG.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 3 || NEEEJOHOOEH[8] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[4];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void KHLOKIBKCMF(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GCHKDAIFKDG(FKAJIJIGNEN);
	}

	public void JJKMKKKHEPJ(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.PNNPGAFLMMP());
		BNNLNOIHAAM.material.SetTexture("WarBucks", Singleton<MatCapTextures>.instance.AJEMHHABPKP());
		BLHMGOMCDFG.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[3] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[6];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void CJPENLHICLJ()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_WARNING_NOTENOUGHTWARCARDS", null);
		BLHMGOMCDFG.EHODOJBGHFE();
	}

	public void KDAOCIJNNJK()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_ARENARULES_RANDOMUNITS", null);
		BLHMGOMCDFG.PADKBBBFNEA();
	}

	public void LMKNDGLMKNC()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_PHASEXOFY", null);
		BLHMGOMCDFG.NullTextures();
	}

	public void FECFDLOJGLF(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GCHKDAIFKDG(FKAJIJIGNEN);
	}

	public void JJIFIIGONEO(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.IKIKNCMAPHP(FKAJIJIGNEN);
	}

	public void AFALDPLJGON(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.SetAttachmentsMaterial(FKAJIJIGNEN);
	}

	public void KLBJOJLOPGF(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.IKIKNCMAPHP(FKAJIJIGNEN);
	}

	public void CCBIFFLGGGF(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.LEGDLNGKLGO(FKAJIJIGNEN);
	}

	public void LNCAEAGCJKM()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("BlackMarketOffer", null);
		BLHMGOMCDFG.NullTextures();
	}

	public void LPHOCDIMLPG()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ColumnNames", null);
		BLHMGOMCDFG.KKBKBEHEFCP();
	}

	public void GGOKHPIDODD(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GJBCHFFALBJ(FKAJIJIGNEN);
	}

	public void OFOIBPGDCLN(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GJBCHFFALBJ(FKAJIJIGNEN);
	}

	public void HDPMMPNOGGC()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("withAttribute4", null);
		BLHMGOMCDFG.JDJGJKNKBIC();
	}

	public void KNMEFFFNIID(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.AJAFDBLABMA(FKAJIJIGNEN);
	}

	public void OLHABGONDLM()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("Player_Had_To_Select_Grenade", null);
		BLHMGOMCDFG.ABJFHJGFPFF();
	}

	public void AHKACPILJNL(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.FJMHEOLCFHE() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("RequiredMedals", Singleton<MatCapTextures>.instance.AAIFAPBKIMP());
		BLHMGOMCDFG.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 5 || NEEEJOHOOEH[2] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[2];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void POJMPKKGCHB(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GCHKDAIFKDG(FKAJIJIGNEN);
	}

	public void NEPICFAGECC(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.ICJJOOFHEJC(FKAJIJIGNEN);
	}

	public void GGGALCBHHAH(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GCHKDAIFKDG(FKAJIJIGNEN);
	}

	public void PLCJBPHKMKF(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KBECDMNAIIF() : technologyVisualDefinition.PNNPGAFLMMP());
		BNNLNOIHAAM.material.SetTexture("ID_CONFIRM_LOGGEDOUT_TEXT", Singleton<MatCapTextures>.instance.OKPKEAHMABE());
		BLHMGOMCDFG.HOPMMFHKFBO();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[5] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[7];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void JHJIHMNELEM(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("No original weapon set for blackmarket weapon: ", Singleton<MatCapTextures>.instance.KBHCPHBCILH());
		BLHMGOMCDFG.MLGBHGMAKGC();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 7 || NEEEJOHOOEH[4] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[5];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void DCGLDACNHPA()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_CONFIRM_ERROR", null);
		BLHMGOMCDFG.LNCAEAGCJKM();
	}

	public void NullTextures()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("_MatCap", null);
		BLHMGOMCDFG.NullTextures();
	}

	public void OGMNMNKFMCH(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("ID_CONFIRM_JOININGSQUAD_TEXT", Singleton<MatCapTextures>.instance.GDCEFCOEGNM());
		BLHMGOMCDFG.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[5];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void GPELAIDIKFI(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.ICJJOOFHEJC(FKAJIJIGNEN);
	}

	public void FOHCFHAALNB(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.IKIKNCMAPHP(FKAJIJIGNEN);
	}

	public void GAIKDNBKBNN(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KBECDMNAIIF() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("IAPOfferInfo", Singleton<MatCapTextures>.instance.IAAKLIPOGOK());
		BLHMGOMCDFG.NMOADHMAAOE();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[7] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[4];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void FPAEKGLDPAP()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("Vip days = ", null);
		BLHMGOMCDFG.KKBKBEHEFCP();
	}

	public void GHBDGCCCIGB()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_AWESOME", null);
		BLHMGOMCDFG.ABJFHJGFPFF();
	}

	public void GHBOKGNFDBM(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.FJMHEOLCFHE() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("LEADERBOARDS - showing ", Singleton<MatCapTextures>.instance.MOGBPGLADOM());
		BLHMGOMCDFG.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 4 || NEEEJOHOOEH[7] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[6];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void EAHGEPGODAP(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("purchase", Singleton<MatCapTextures>.instance.GCJLDHFKJPO());
		BLHMGOMCDFG.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 4 || NEEEJOHOOEH[5] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[8];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void FNEGKOFCPFG(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.AJAFDBLABMA(FKAJIJIGNEN);
	}

	public void KAHKMKGNABM()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("withAttribute5", null);
		BLHMGOMCDFG.ABJFHJGFPFF();
	}

	public void JOAEJNDPIIH(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.ICJJOOFHEJC(FKAJIJIGNEN);
	}

	public void BDGFKFFKIGI(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture(" set league processing", Singleton<MatCapTextures>.instance.DLNAJHBLNHP());
		BLHMGOMCDFG.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 8 || NEEEJOHOOEH[2] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[6];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void MKKIDKFOAJL(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.FJMHEOLCFHE() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("Skipping next squad war notification", Singleton<MatCapTextures>.instance.AFHOPBALOPK());
		BLHMGOMCDFG.MLGBHGMAKGC();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 5 || NEEEJOHOOEH[4] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[6];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void AIOCNLJICML(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KBECDMNAIIF() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("ID_CONFIRM_NOTACTIVEEVENT", Singleton<MatCapTextures>.instance.KBHCPHBCILH());
		BLHMGOMCDFG.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 5 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[7];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void PGKBPJKAELD(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.LEGDLNGKLGO(FKAJIJIGNEN);
	}

	public void GHEIIECMEDK(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.AJAFDBLABMA(FKAJIJIGNEN);
	}

	public void EKNGDJOLOAF(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KPKLDCIAKLE() : technologyVisualDefinition.PNNPGAFLMMP());
		BNNLNOIHAAM.material.SetTexture("S", Singleton<MatCapTextures>.instance.DBIELLFLBLF());
		BLHMGOMCDFG.MLGBHGMAKGC();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[5] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[2];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void MJOJCGNIBOF(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.LEGDLNGKLGO(FKAJIJIGNEN);
	}

	public void BPJFMLIAHME(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.BHPOACJHNEJ(FKAJIJIGNEN);
	}

	public void IGHCFMMFBLF(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KPKLDCIAKLE() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture(" mSpriteName:", Singleton<MatCapTextures>.instance.GDCEFCOEGNM());
		BLHMGOMCDFG.MLGBHGMAKGC();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[6] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[4];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void IJLNLDFDHHD()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("_BumpMap", null);
		BLHMGOMCDFG.KKBKBEHEFCP();
	}

	public void IEAJILMHAED()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_ARENAWONXWINSTEXT", null);
		BLHMGOMCDFG.JDJGJKNKBIC();
	}

	public void AKKBEJLMADF(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GCHKDAIFKDG(FKAJIJIGNEN);
	}

	public void MAENAFIFLGK(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GCHKDAIFKDG(FKAJIJIGNEN);
	}

	public void ONHHLGGHGPN(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture(" ", Singleton<MatCapTextures>.instance.BBFAKOCKHHA());
		BLHMGOMCDFG.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 8 || NEEEJOHOOEH[5] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[0];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void NBDBCACOKNE(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KPKLDCIAKLE() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("ID_MAX", Singleton<MatCapTextures>.instance.AJEMHHABPKP());
		BLHMGOMCDFG.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 7 || NEEEJOHOOEH[4] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[3];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void NJEBCOBBCOO(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.ICJJOOFHEJC(FKAJIJIGNEN);
	}

	public void AENFNGOCMHN()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("id", null);
		BLHMGOMCDFG.PJEDDDLCHHJ();
	}

	public void DLDKNPJLKEG()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("#DOMINIK# weapon not found", null);
		BLHMGOMCDFG.PADKBBBFNEA();
	}

	public void CKBAECGEMGE(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.SetAttachmentsMaterial(FKAJIJIGNEN);
	}

	public void BOJHKJFINEG()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_TABLE_SQUADRANK", null);
		BLHMGOMCDFG.PADKBBBFNEA();
	}

	public void POPFHBPFPLO()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_SELECTONEUNIT", null);
		BLHMGOMCDFG.JDJGJKNKBIC();
	}

	public void JEAGNNNDPFL(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KBECDMNAIIF() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("ID_CONFIRMTRAILSUBSRIPTIONANDROIDTEXT", Singleton<MatCapTextures>.instance.MOPGMAKIAKP());
		BLHMGOMCDFG.IFMCHKEJPPE();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 7 || NEEEJOHOOEH[4] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[1];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void PBIEMLOIGJA(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.ICJJOOFHEJC(FKAJIJIGNEN);
	}

	public void IJNOIBMNNHP(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GJBCHFFALBJ(FKAJIJIGNEN);
	}

	public void LFKGKBKIEAA(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.LEGDLNGKLGO(FKAJIJIGNEN);
	}

	public void HDHOMEPHMBI(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.LEGDLNGKLGO(FKAJIJIGNEN);
	}

	public void PNHIEAJLNAP(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GJBCHFFALBJ(FKAJIJIGNEN);
	}

	public void IEKEKKEEGDG(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.BHPOACJHNEJ(FKAJIJIGNEN);
	}

	public void GGOMGFKECNA(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.LMBCANIGBGI() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("Shots_Fired", Singleton<MatCapTextures>.instance.PFHGOIBBFND());
		BLHMGOMCDFG.IFMCHKEJPPE();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 3 || NEEEJOHOOEH[5] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[4];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void BJPLICPLPFK()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("testingidsquadjoined", null);
		BLHMGOMCDFG.KKBKBEHEFCP();
	}

	public void ChangeMaterial(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.SetAttachmentsMaterial(FKAJIJIGNEN);
	}

	public void OKJOMPMOOEG()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("About to show GC Change Name Dialog", null);
		BLHMGOMCDFG.EHODOJBGHFE();
	}

	public void GJLENDCLGCL()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("otherInfo", null);
		BLHMGOMCDFG.PJEDDDLCHHJ();
	}

	public void DFFEBLDLODG(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GJBCHFFALBJ(FKAJIJIGNEN);
	}

	public void SetVisuals(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("_MatCap", Singleton<MatCapTextures>.instance.GetMatCap());
		BLHMGOMCDFG.HideAllAttachments();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 2 || NEEEJOHOOEH[2] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[2];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void PDEFNFFAMDN(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.ICJJOOFHEJC(FKAJIJIGNEN);
	}

	public void JHEMILOKGJH(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GCHKDAIFKDG(FKAJIJIGNEN);
	}

	public void ABKHAONGMCP(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("ID_CANCEL", Singleton<MatCapTextures>.instance.KLEMILHEFPO());
		BLHMGOMCDFG.HOPMMFHKFBO();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 3 || NEEEJOHOOEH[4] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[1];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void FIPLCMPHNLP(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("java.util.ArrayList", Singleton<MatCapTextures>.instance.ENHHFGHIMNC());
		BLHMGOMCDFG.HOPMMFHKFBO();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[4] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[0];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void LNECNIIMCIG()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_CONFIRM_NOTENOUGHMEDALSTOJOIN", null);
		BLHMGOMCDFG.PJEDDDLCHHJ();
	}

	public void MOIPPDPHEAI(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.IKIKNCMAPHP(FKAJIJIGNEN);
	}

	public void GJDNHPFEGKF(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GCHKDAIFKDG(FKAJIJIGNEN);
	}

	public void JDJGJKNKBIC()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("customDate", null);
		BLHMGOMCDFG.JDJGJKNKBIC();
	}

	public void BDEFKKNJOBD()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_SYSTEMMAINTENANCE", null);
		BLHMGOMCDFG.JDJGJKNKBIC();
	}

	public void MOKGOICFPOJ()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("No connection.", null);
		BLHMGOMCDFG.LNCAEAGCJKM();
	}

	public void LDBHONEGNME(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.BHPOACJHNEJ(FKAJIJIGNEN);
	}

	public void KOOPJHKHKMC(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KPKLDCIAKLE() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("ID_SALEPERCENT", Singleton<MatCapTextures>.instance.JODNMELOAGB());
		BLHMGOMCDFG.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 8 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[7];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void MGNMDOIBHLF()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("dataEnabled", null);
		BLHMGOMCDFG.ABJFHJGFPFF();
	}

	public void GGAMLLEHKMF(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.FJMHEOLCFHE() : technologyVisualDefinition.PNNPGAFLMMP());
		BNNLNOIHAAM.material.SetTexture("Weapon", Singleton<MatCapTextures>.instance.GetMatCap());
		BLHMGOMCDFG.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 6 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[8];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void ACBNOAIGMAE(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("0", Singleton<MatCapTextures>.instance.OIJIBGGENFN());
		BLHMGOMCDFG.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 6 || NEEEJOHOOEH[2] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[8];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void IDFDMLBCDPG(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KPKLDCIAKLE() : technologyVisualDefinition.PNNPGAFLMMP());
		BNNLNOIHAAM.material.SetTexture("squad", Singleton<MatCapTextures>.instance.IAOKLMBNBGM());
		BLHMGOMCDFG.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 6 || NEEEJOHOOEH[7] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[1];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void KKBKBEHEFCP()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_EMPTYFOUNDSQUADSGLOBAL", null);
		BLHMGOMCDFG.ABJFHJGFPFF();
	}

	public void IBLKAKBDGOG()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("Tickets", null);
		BLHMGOMCDFG.LNCAEAGCJKM();
	}

	public void PLPMPDBNJFH(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KBECDMNAIIF() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("ID_TABLE_MEMBERS", Singleton<MatCapTextures>.instance.BBFAKOCKHHA());
		BLHMGOMCDFG.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[3];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void MCNDAJACLHB()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_SELECTONEUNIT", null);
		BLHMGOMCDFG.KKBKBEHEFCP();
	}

	public void ALEGBKELHFN(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("Automatic_Equip", Singleton<MatCapTextures>.instance.DLNAJHBLNHP());
		BLHMGOMCDFG.IFMCHKEJPPE();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[3] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[6];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void LELBKBHOLBD(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.FJMHEOLCFHE() : technologyVisualDefinition.PNNPGAFLMMP());
		BNNLNOIHAAM.material.SetTexture("Sniper_Tutorial_Duration", Singleton<MatCapTextures>.instance.OFCHODNGGCP());
		BLHMGOMCDFG.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[7] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[1];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void PADKBBBFNEA()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("DailyGoldBooster-{0}-{1}", null);
		BLHMGOMCDFG.PADKBBBFNEA();
	}

	public void PNLHGBNDNMI()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("{0} {1}", null);
		BLHMGOMCDFG.LNCAEAGCJKM();
	}

	public void MJKJCOJPPCM()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_COMPLETED", null);
		BLHMGOMCDFG.KKBKBEHEFCP();
	}

	public void BHOBDIGFKNI()
	{
		BNNLNOIHAAM.material.mainTexture = null;
		BNNLNOIHAAM.material.SetTexture("ID_COLLECTONECHRISTMASCRATE", null);
		BLHMGOMCDFG.JDJGJKNKBIC();
	}

	public void CCFJLBNLJHC(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.AJAFDBLABMA(FKAJIJIGNEN);
	}

	public void EIODHKOKHLN(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.BHPOACJHNEJ(FKAJIJIGNEN);
	}

	public void LLGLEGJOADL(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("LeagueId", Singleton<MatCapTextures>.instance.PNOEOMBKMOH());
		BLHMGOMCDFG.HOPMMFHKFBO();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[3] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[7];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void EICJNDHHIPM(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.GJBCHFFALBJ(FKAJIJIGNEN);
	}

	public void CNGJOMINGBB(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.KBECDMNAIIF() : technologyVisualDefinition.materialTetxureBlue);
		BNNLNOIHAAM.material.SetTexture("Game_Type", Singleton<MatCapTextures>.instance.AFHOPBALOPK());
		BLHMGOMCDFG.MLGBHGMAKGC();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[8];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void ADEOFOJPFKI(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.PNNPGAFLMMP());
		BNNLNOIHAAM.material.SetTexture("Golden_Suitcase", Singleton<MatCapTextures>.instance.NIAGPMCOJKK());
		BLHMGOMCDFG.IFMCHKEJPPE();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[3] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[4];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void PJPDPOOFAID(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("-", Singleton<MatCapTextures>.instance.OKPKEAHMABE());
		BLHMGOMCDFG.MLGBHGMAKGC();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 2 || NEEEJOHOOEH[2] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[1];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}

	public void HECIENBDPGL(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.ICJJOOFHEJC(FKAJIJIGNEN);
	}

	public void HFNCABJIJOL(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.LEGDLNGKLGO(FKAJIJIGNEN);
	}

	public void HJIAJEAKCFM(Material FKAJIJIGNEN)
	{
		BNNLNOIHAAM.material = FKAJIJIGNEN;
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = FKAJIJIGNEN;
		}
		BLHMGOMCDFG.AJAFDBLABMA(FKAJIJIGNEN);
	}

	public void OHPHBOGOBFH(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
		BNNLNOIHAAM.material.mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.BIFIFGLIPIG());
		BNNLNOIHAAM.material.SetTexture("ID_GUI_REPORTABUSE_LISTITEM3", Singleton<MatCapTextures>.instance.NKLGCBOAODM());
		BLHMGOMCDFG.NMOADHMAAOE();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh.part, visualSlotMesh.visualSlotId, BNNLNOIHAAM.material);
			}
		}
		foreach (MeshRenderer item in KNEMCHNNOOC)
		{
			item.sharedMaterial = BNNLNOIHAAM.material;
		}
		if (NEEEJOHOOEH.Count > 1 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, BNNLNOIHAAM.material);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 6 || NEEEJOHOOEH[7] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = NEEEJOHOOEH[3];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				BLHMGOMCDFG.GCFEBGHLIMB(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, BNNLNOIHAAM.material);
			}
		}
	}
}
