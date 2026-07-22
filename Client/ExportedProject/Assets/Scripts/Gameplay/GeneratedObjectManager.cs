using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GeneratedObjectManager : Core_BaseScript
{
	[FormerlySerializedAs("ILIOKFFCIFL")]
	public LinkedList<GeneratedGameObject> CFNHDBCKBGN = new LinkedList<GeneratedGameObject>();

	[FormerlySerializedAs("JPFKCMCCNCK")]
	public string OPGBMEOMAGK = "ObjectPool";

	[FormerlySerializedAs("KNALHJOIOMN")]
	public ObjectPool DBDMKGIBKJC;

	public virtual GeneratedGameObject Generate(GeneratedGameObject PNOGDLPMNKI, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		GeneratedGameObject generatedGameObject = (GeneratedGameObject)DBDMKGIBKJC.Instantiate(PNOGDLPMNKI, MPHCNMDIPAI, OOMCGGAFJNH);
		if (generatedGameObject != null)
		{
			generatedGameObject.GJLHIILKONF = CFNHDBCKBGN.AddLast(generatedGameObject);
			generatedGameObject.MJAEIDHNBIP = this;
			return generatedGameObject;
		}
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		DBDMKGIBKJC = ObjectPool.GetPool(OPGBMEOMAGK);
	}

	public virtual void EBGJFONPNGJ(GeneratedGameObject MEPBDCHCEAO)
	{
		if (MEPBDCHCEAO.GJLHIILKONF != null)
		{
			CFNHDBCKBGN.Remove(MEPBDCHCEAO.GJLHIILKONF);
		}
	}

	public virtual GeneratedGameObject JHJIDLKINGD(GeneratedGameObject PNOGDLPMNKI, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		GeneratedGameObject generatedGameObject = DBDMKGIBKJC.MEOJMCOPLAI(PNOGDLPMNKI, MPHCNMDIPAI, OOMCGGAFJNH) as GeneratedGameObject;
		if (generatedGameObject != null)
		{
			generatedGameObject.GJLHIILKONF = CFNHDBCKBGN.AddLast(generatedGameObject);
			generatedGameObject.MJAEIDHNBIP = this;
			return generatedGameObject;
		}
		return null;
	}

	public virtual void GGBGHIIEKPI(GeneratedGameObject MEPBDCHCEAO)
	{
		if (MEPBDCHCEAO.GJLHIILKONF != null)
		{
			CFNHDBCKBGN.Remove(MEPBDCHCEAO.GJLHIILKONF);
		}
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		DBDMKGIBKJC = ObjectPool.DBDJFIHHPAO(OPGBMEOMAGK);
	}

	public virtual GeneratedGameObject OFGJKOBEBBI(GeneratedGameObject PNOGDLPMNKI, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		GeneratedGameObject generatedGameObject = DBDMKGIBKJC.ReInstantiate(PNOGDLPMNKI, MPHCNMDIPAI, OOMCGGAFJNH) as GeneratedGameObject;
		if (generatedGameObject != null)
		{
			generatedGameObject.GJLHIILKONF = CFNHDBCKBGN.AddLast(generatedGameObject);
			generatedGameObject.MJAEIDHNBIP = this;
			return generatedGameObject;
		}
		return null;
	}

	public virtual void GCNMLOONPKD(GeneratedGameObject MEPBDCHCEAO)
	{
		if (MEPBDCHCEAO.GJLHIILKONF != null)
		{
			CFNHDBCKBGN.Remove(MEPBDCHCEAO.GJLHIILKONF);
		}
	}

	public virtual void Delete(GeneratedGameObject MEPBDCHCEAO)
	{
		if (MEPBDCHCEAO.GJLHIILKONF != null)
		{
			CFNHDBCKBGN.Remove(MEPBDCHCEAO.GJLHIILKONF);
		}
	}

	public virtual GeneratedGameObject ReGenerate(GeneratedGameObject PNOGDLPMNKI, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		GeneratedGameObject generatedGameObject = DBDMKGIBKJC.ReInstantiate(PNOGDLPMNKI, MPHCNMDIPAI, OOMCGGAFJNH) as GeneratedGameObject;
		if (generatedGameObject != null)
		{
			generatedGameObject.GJLHIILKONF = CFNHDBCKBGN.AddLast(generatedGameObject);
			generatedGameObject.MJAEIDHNBIP = this;
			return generatedGameObject;
		}
		return null;
	}

	public virtual void DIPIAHKAEAL(GeneratedGameObject MEPBDCHCEAO)
	{
		if (MEPBDCHCEAO.GJLHIILKONF != null)
		{
			CFNHDBCKBGN.Remove(MEPBDCHCEAO.GJLHIILKONF);
		}
	}
}
