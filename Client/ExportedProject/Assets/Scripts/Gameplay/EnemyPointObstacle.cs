using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPointObstacle : EnemyPoint
{
	[FormerlySerializedAs("GBOGADNOHHC")]
	public Transform BDDEHDDCDIC;

	[FormerlySerializedAs("PFADGGDFIID")]
	public Transform LDAJMHAGAIC;

	private Vector3 EGNBHPMJDFA;

	private Vector3 ODNAADFONLC;

	public override Vector3 position => EGNBHPMJDFA;

	protected virtual void PIIFEPFCOJF()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		KMPIAKMBIFL(LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1156f);
	}

	protected virtual void IOAEHDJGBJC()
	{
		CFGDCEOLKJG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Rusher;
		HBBKGCJEDNO(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1112f);
	}

	public virtual void GBNCABIDOHH()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1585f, 1052f));
		base.LBOKMMJILDB();
	}

	public virtual void EGNDCNIMCHG()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 921f, 1544f));
		base.LFDGGKIFGHP();
	}

	protected virtual void PAPFKMJEMML()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		IOIIEDDBIKD(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1626f);
	}

	[SpecialName]
	public virtual Vector3 CBGBMJLEANP()
	{
		return EGNBHPMJDFA;
	}

	protected override void Awake()
	{
		base.Awake();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		base.enemyPointType = LJGGJMAFEBN.Hiding;
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 0.5f);
	}

	[SpecialName]
	public virtual Vector3 PMEMBOFCJPL()
	{
		return EGNBHPMJDFA;
	}

	protected virtual void CIGLDDGDAPM()
	{
		CFGDCEOLKJG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		MMPAHCDHGCN(LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 227f);
	}

	public override void GeneratePosition()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 0f, 1f));
		base.GeneratePosition();
	}

	[SpecialName]
	public virtual Vector3 AHGNIMFDABM()
	{
		return EGNBHPMJDFA;
	}

	protected virtual void ACPHOCKEOII()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		KMPIAKMBIFL(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 649f);
	}

	public virtual void OEPAPAFBEEB()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1065f, 480f));
		base.JKAKFCELAHM();
	}

	protected virtual void GEPHFAECCII()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		IOIIEDDBIKD(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1316f);
	}

	public virtual void JFGBFLDLLGN()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 306f, 1510f));
		base.DNBCBNMOGIN();
	}

	[SpecialName]
	public virtual Vector3 HAMOLDFBLJJ()
	{
		return EGNBHPMJDFA;
	}

	protected virtual void JJEONLDHCLO()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		HBBKGCJEDNO(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1713f);
	}

	protected virtual void NOGLOKJINKN()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		MMPAHCDHGCN(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1306f);
	}

	public virtual void FBGJDMMIDCO()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1165f, 995f));
		base.DNBCBNMOGIN();
	}

	protected virtual void KALEMFKOGLE()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		CAEMAAMICOF(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 75f);
	}

	private void LLPLLJMMCBG()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 1364f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1026f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 395f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1106f);
	}

	private void HPKANLKCPKO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 286f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1836f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1430f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 410f);
	}

	[SpecialName]
	public virtual Vector3 AIOPJDHGCLL()
	{
		return EGNBHPMJDFA;
	}

	protected virtual void HCNOHLLOGBO()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		EMKAJOADOIH(LJGGJMAFEBN.Rusher);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1484f);
	}

	private void EDIGONDBCBH()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 1299f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 845f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1724f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 664f);
	}

	private void OONACPNEMFN()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 758f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1626f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 154f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 641f);
	}

	public virtual void GOOGPKNOAIP()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1265f, 845f));
		base.IPBMGHPLHIF();
	}

	protected virtual void FFBBKELEEIF()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		KMPIAKMBIFL(LJGGJMAFEBN.Hiding);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1047f);
	}

	private void OFGNGGCIAAE()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 1707f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 470f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 341f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1441f);
	}

	private void KIMIJAKGKBO()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 581f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 135f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 700f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1277f);
	}

	public virtual void AIICJIIOOHP()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1971f, 1651f));
		base.EGFMMANPHAK();
	}

	private void AHDPDKEJJGJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 596f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 491f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1529f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1927f);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 0.08f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 0.15f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 0.08f);
	}

	public virtual void KDHNFLIKEJP()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1884f, 1475f));
		base.MCHHJNPCBLA();
	}

	protected virtual void OIKLJGMKMAE()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		MMPAHCDHGCN(LJGGJMAFEBN.Car);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 233f);
	}

	protected virtual void BMLLLOBPGIB()
	{
		EALPHOPMAMP();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		KMPIAKMBIFL(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 208f);
	}

	[SpecialName]
	public virtual Vector3 OJHHDJIGGDL()
	{
		return EGNBHPMJDFA;
	}

	private void DMMNDFHGEJJ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 80f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1968f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 322f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1007f);
	}

	public virtual void NELMFJLBNJH()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1955f, 252f));
		base.IPBMGHPLHIF();
	}

	private void FKPBJPJDCNA()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 990f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 759f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 762f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1641f);
	}

	public virtual void LGBFNBEFDMF()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1036f, 1907f));
		base.GeneratePosition();
	}

	private void EIHPOMNCLBA()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 686f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1421f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1953f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1527f);
	}

	[SpecialName]
	public virtual Vector3 BIACPIDMMMA()
	{
		return EGNBHPMJDFA;
	}

	[SpecialName]
	public virtual Vector3 OBBPNKCOJNO()
	{
		return EGNBHPMJDFA;
	}

	public virtual void OBPEIIAEKOH()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 287f, 1083f));
		base.JKAKFCELAHM();
	}

	private void LKAACNCCDEL()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 927f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1945f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 94f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1323f);
	}

	protected virtual void PNCPCHDFBOB()
	{
		PJEMCLFLGBL();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Walk;
		base.enemyPointType = LJGGJMAFEBN.Rusher;
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 270f);
	}

	public override void GGACGAMGMEF()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1487f, 951f));
		base.GGACGAMGMEF();
	}

	public virtual void BBMIPEKPPBP()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 107f, 1904f));
		base.IAPJBOCGBGL();
	}

	protected virtual void EJFMJDFPGFE()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Helicopter;
		NGCBJNCNCCM(LJGGJMAFEBN.Car);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1487f);
	}

	[SpecialName]
	public virtual Vector3 PJJPAIEDOKL()
	{
		return EGNBHPMJDFA;
	}

	[SpecialName]
	public virtual Vector3 KAINOJNBFDF()
	{
		return EGNBHPMJDFA;
	}

	public virtual void IOCHCKADJKB()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1550f, 704f));
		base.LFDGGKIFGHP();
	}

	[SpecialName]
	public virtual Vector3 PDHFODNKEDB()
	{
		return EGNBHPMJDFA;
	}

	public virtual void POEFLDGAJNI()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 173f, 2f));
		base.IAPJBOCGBGL();
	}

	private void JKNOHDDDEAM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 979f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1621f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 296f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 669f);
	}

	[SpecialName]
	public virtual Vector3 JJPKDKFKKCE()
	{
		return EGNBHPMJDFA;
	}

	protected virtual void GDDCEHOJCEM()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		NGCBJNCNCCM(LJGGJMAFEBN.Car);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1392f);
	}

	[SpecialName]
	public virtual Vector3 COPICAFDJEJ()
	{
		return EGNBHPMJDFA;
	}

	private void PLGDNELNGBG()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 1865f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1199f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 555f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1775f);
	}

	[SpecialName]
	public virtual Vector3 EEPOBLDOCMC()
	{
		return EGNBHPMJDFA;
	}

	private void IIMEAFKAFIA()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 133f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1345f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 348f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1372f);
	}

	public virtual void MLMKOLJHLGJ()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 397f, 586f));
		base.ECHLJNJBHEC();
	}

	private void MAKPKDNNJKG()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 1936f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 330f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1299f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 42f);
	}

	public virtual void JFAFCCMBECI()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 535f, 35f));
		base.LFDGGKIFGHP();
	}

	protected virtual void NLOODGLGPHE()
	{
		KNLKFOHBCKI();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Vehicle;
		CAEMAAMICOF(LJGGJMAFEBN.Hiding);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 609f);
	}

	protected virtual void KINHAJCDKGN()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		CAEMAAMICOF(LJGGJMAFEBN.Hiding | LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1357f);
	}

	public virtual void PGFHLOBAGKE()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1045f, 298f));
		base.DMHGNJEHJJG();
	}

	private void EFNOBFKGECB()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 1026f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 811f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1421f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 255f);
	}

	protected virtual void NIAEEICNNHL()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Idle;
		CAEMAAMICOF(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1738f);
	}

	public virtual void BEFIMGPOKNN()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 997f, 1612f));
		base.DNBCBNMOGIN();
	}

	protected virtual void IOKMAFLIJEG()
	{
		AOJALKEHFCK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		CAEMAAMICOF(LJGGJMAFEBN.Hiding);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1510f);
	}

	protected virtual void KODJIPJGFPB()
	{
		IODPOHKAKNN();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Swat;
		NGCBJNCNCCM(LJGGJMAFEBN.Hiding);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1714f);
	}

	[SpecialName]
	public virtual Vector3 DACCMHECIFO()
	{
		return EGNBHPMJDFA;
	}

	protected virtual void FGOGGLDAKHL()
	{
		HLBLKFLJEIG();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		EMKAJOADOIH((LJGGJMAFEBN)0);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 1314f);
	}

	public override void PJDJCKGAAIK()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 1774f, 1176f));
		base.DNBCBNMOGIN();
	}

	protected virtual void DDJBFEJLMBP()
	{
		IBLPGJOHIAE();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.Parachute;
		NGCBJNCNCCM(LJGGJMAFEBN.Rusher | LJGGJMAFEBN.Corner);
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 443f);
	}

	[SpecialName]
	public virtual Vector3 KBGCDAFBGDG()
	{
		return EGNBHPMJDFA;
	}

	[SpecialName]
	public virtual Vector3 PBAOJODKOCN()
	{
		return EGNBHPMJDFA;
	}

	private void DFBFJJHABND()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 672f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 805f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1154f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 1620f);
	}

	protected virtual void NGGJHDCOLEC()
	{
		PBIJLBHDFOK();
		MJGBKHOFNHK = EnemyController.AJGFGCHCAPA.ObstacleHiding;
		base.enemyPointType = LJGGJMAFEBN.Rusher;
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, 160f);
	}

	[SpecialName]
	public virtual Vector3 MKGJCPKNEFI()
	{
		return EGNBHPMJDFA;
	}

	private void MGCGEMCAKLM()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 1690f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 310f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1351f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 546f);
	}

	private void FAIGHDJENIK()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(BDDEHDDCDIC.transform.position, Vector3.one * 1703f);
		Gizmos.DrawCube(BDDEHDDCDIC.transform.position, Vector3.one * 1660f);
		Gizmos.DrawLine(BDDEHDDCDIC.transform.position, LDAJMHAGAIC.transform.position);
		Gizmos.DrawWireCube(LDAJMHAGAIC.transform.position, Vector3.one * 1648f);
		Gizmos.DrawCube(LDAJMHAGAIC.transform.position, Vector3.one * 959f);
	}

	public virtual void GONEGFHMCOD()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 181f, 692f));
		base.ECHLJNJBHEC();
	}

	[SpecialName]
	public virtual Vector3 JCNLLIMAPFG()
	{
		return EGNBHPMJDFA;
	}

	public virtual void CDIHILOOHIL()
	{
		EGNBHPMJDFA = Vector3.Lerp(BDDEHDDCDIC.position, LDAJMHAGAIC.position, Mathf.Clamp(Random.value, 477f, 17f));
		base.DMHGNJEHJJG();
	}
}
