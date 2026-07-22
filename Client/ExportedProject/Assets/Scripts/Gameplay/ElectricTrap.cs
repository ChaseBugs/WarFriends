using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class ElectricTrap : Core_BaseScript
{
	private sealed class APHOFFLBJGD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int GCCEBAEINOD;

		internal float CDGNPOCMPLB;

		internal ElectricTrap BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(1, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 767f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(75f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = (GCCEBAEINOD += 0) % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(639f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(0, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 1312f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(1435f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = (GCCEBAEINOD += 0) % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(272f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(1, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 1635f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(1689f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = (GCCEBAEINOD += 0) % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(463f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(1, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 1404f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(1702f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = (GCCEBAEINOD += 0) % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(1619f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(0, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 1f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(1f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = ++GCCEBAEINOD % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(0f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(0, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 332f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(868f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = ++GCCEBAEINOD % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(1205f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(0, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 538f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(233f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = (GCCEBAEINOD += 0) % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(1592f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(0, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 362f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(66f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = ++GCCEBAEINOD % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(1205f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(0, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 1737f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(421f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = ++GCCEBAEINOD % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(418f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(0, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 1516f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(689f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = (GCCEBAEINOD += 0) % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(793f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public APHOFFLBJGD()
		{
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GCCEBAEINOD = UnityEngine.Random.Range(1, BJGCPDNMHDH.DCEGGIBCFAN);
				CDGNPOCMPLB = 879f / (float)BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureScale = new Vector2(1781f, CDGNPOCMPLB);
				goto case 1u;
			case 1u:
				GCCEBAEINOD = ++GCCEBAEINOD % BJGCPDNMHDH.DCEGGIBCFAN;
				BJGCPDNMHDH.FJIHFFKPIFA.material.mainTextureOffset = new Vector2(1111f, CDGNPOCMPLB * (float)GCCEBAEINOD);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.NDPLIALMJFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}
	}

	[FormerlySerializedAs("NDLCIFFANEO")]
	public PhysicsEventsListener MPHGIDMPPPK;

	[FormerlySerializedAs("ENPBILNLGGE")]
	public Shield JPBBAIGNBAP;

	[FormerlySerializedAs("LOAGAOKNAPI")]
	public PhotonView LAADDLGBFIG;

	[FormerlySerializedAs("OOCBPFPMDDN")]
	public GameObject EIEHEBFBCMD;

	[FormerlySerializedAs("BANMOPEBKAP")]
	public Renderer FJIHFFKPIFA;

	[FormerlySerializedAs("HKPOHEBIPNP")]
	public float NDPLIALMJFG;

	[FormerlySerializedAs("JJLADHGBILE")]
	public int DCEGGIBCFAN;

	[FormerlySerializedAs("ILODBKEHHNO")]
	public GameObject BIGIABDIHJD;

	[FormerlySerializedAs("ALPBMGNECII")]
	public GameObject BMMJAPBBDND;

	[FormerlySerializedAs("AHFBNJHCANA")]
	public GameObject IPEGHONOCOJ;

	private DestroyableObject FFOAABONJNO;

	private bool JCKOBELDCGD;

	private IEnumerator DPGLPPFEOHO()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private void CJKMCLNCGPB(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1550f : 30f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 270f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1028f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 778f + 1726f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(PPLPLCAEHLF());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(GFLEEKKFGFA());
		}
	}

	private void DJADMOOHKJO(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1619f : 1563f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 345f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 426f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1238f + 858f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(IFAAOGKPGLO());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(GLDLDACFEIM());
		}
	}

	[PunRPC]
	protected void SetTrapRPC(bool HMCNKNCEDMA)
	{
		CDBOICPKGNB(HMCNKNCEDMA);
	}

	public void LOEBEINGEEI(bool HMCNKNCEDMA)
	{
		NBBPABNDMLB(HMCNKNCEDMA);
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[1];
		array[1] = HMCNKNCEDMA;
		lAADDLGBFIG.RPC("ID_COMPLETEIN", PhotonTargets.All, array);
	}

	private IEnumerator DOMDAJKLILC()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private void IBFLEAFLOFJ(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				GCHFGHAGJDG(component.transform.position);
			}
		}
	}

	private void NBBPABNDMLB(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1879f : 1142f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 724f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 604f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 517f + 281f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(CJFFGJLDOOD());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(LAIJGNPEDGH());
		}
	}

	private IEnumerator FFGDGNHLOLC()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private IEnumerator GLDLDACFEIM()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	public void SetTrap(bool HMCNKNCEDMA)
	{
		CDBOICPKGNB(HMCNKNCEDMA);
		LAADDLGBFIG.RPC("SetTrapRPC", PhotonTargets.Others, HMCNKNCEDMA);
	}

	protected void BAGNHGBOAEJ(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.Play(base.gameObject, HINJJOAJAOA.SHOT_LAUNCHER_2);
		Singleton<HitParticleSystem>.instance.OOGKGACIAHC(MPHCNMDIPAI, Vector3.up, "attrValue12");
		BENMCOJBKDL(HMCNKNCEDMA: true);
	}

	private void GBFEANMHKPA(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: true);
				DDLOHJKGEPG(component.transform.position);
			}
		}
	}

	private void DCLAJPLAICE(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1553f : 274f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 525f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 116f, 0);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1128f + 1789f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(FGJKGOGEBEM());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(ANOBBOGFFLO());
		}
	}

	protected void CLEBLOPPFPL(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[0] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("N", PhotonTargets.Others, array);
		FOBEJLACNGN(MPHCNMDIPAI);
	}

	private IEnumerator LAIJGNPEDGH()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private void NFAAKLKIBHI(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				KEIMKMNGICI(component.transform.position);
			}
		}
	}

	protected virtual void NIAEEICNNHL()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(NFAAKLKIBHI));
	}

	private void LHNMCACHNDH(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				CLEBLOPPFPL(component.transform.position);
			}
		}
	}

	private IEnumerator JJNPIFDBHAG()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	protected void DCPAIEEBHMB(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.IHNLJLDMPJL(base.gameObject, HINJJOAJAOA.RELOAD_ASSAULT);
		Singleton<HitParticleSystem>.instance.ECJBFHNKEAL(MPHCNMDIPAI, Vector3.up, "ID_GUI_INVITETOFIGHT");
		AMALADGJKCM(HMCNKNCEDMA: false);
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(LJNEFDCDKFM));
	}

	private void LJNEFDCDKFM(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				JPHFKOPEBJG(component.transform.position);
			}
		}
	}

	private void DEOGNFLDONC(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1573f : 704f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 391f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1566f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1586f + 871f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(GFLEEKKFGFA());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(CFJICMDLGFB());
		}
	}

	protected virtual void JGFKONKLEAG()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(NMPIDCNDCLA));
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(NFAAKLKIBHI));
	}

	protected void OFHLNPLCFFJ(bool HMCNKNCEDMA)
	{
		BDLOMOOAIPK(HMCNKNCEDMA);
	}

	protected void AABDAJIEBBO(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.BHPFDOOONEP(base.gameObject, (HINJJOAJAOA)(-91));
		Singleton<HitParticleSystem>.instance.MGGNDLBDKHM(MPHCNMDIPAI, Vector3.up, "seconds");
		GNOBDIMGANF(HMCNKNCEDMA: true);
	}

	protected void ADPAOMLCLOI(bool HMCNKNCEDMA)
	{
		CDBOICPKGNB(HMCNKNCEDMA);
	}

	private void PJPFGJGLBNF(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 483f : 493f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 1193f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 137f, 0);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1983f + 1819f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(FGJKGOGEBEM());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(CJFFGJLDOOD());
		}
	}

	private IEnumerator DANJCHNBGJF()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	protected void LBOMKCFHGDN(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.Play(base.gameObject, (HINJJOAJAOA)(-92));
		Singleton<HitParticleSystem>.instance.PlayParticle(MPHCNMDIPAI, Vector3.up, "ID_STAT_MOSTWINS");
		DNJBCOJJGJK(HMCNKNCEDMA: true);
	}

	protected void MGOHMDFNMNG(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.Play(base.gameObject, (HINJJOAJAOA)(-20));
		Singleton<HitParticleSystem>.instance.BPNIEDNNMMP(MPHCNMDIPAI, Vector3.up, "S");
		FDBCLHEOBNM(HMCNKNCEDMA: false);
	}

	protected void MEKPKDNNGKL(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.BLKAHLHEAFB(base.gameObject, HINJJOAJAOA.SHOT_SHOTGUN_3);
		Singleton<HitParticleSystem>.instance.DLJOJFODELB(MPHCNMDIPAI, Vector3.up, "PromotedPlayerId");
		LDLPFOEDLGN(HMCNKNCEDMA: false);
	}

	private void EBPEBCALIEH(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				GCHFGHAGJDG(component.transform.position);
			}
		}
	}

	private IEnumerator OOPMHIDBNFK()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private IEnumerator FGJKGOGEBEM()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private void CCJABONHOHF(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1285f : 802f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 1623f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 420f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 187f + 1496f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(PPLPLCAEHLF());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(GLDLDACFEIM());
		}
	}

	protected void AAOCPBAJLEO(bool HMCNKNCEDMA)
	{
		IIODICICEAC(HMCNKNCEDMA);
	}

	protected void FDELDLLEBML(bool HMCNKNCEDMA)
	{
		BDLOMOOAIPK(HMCNKNCEDMA);
	}

	private void AMALADGJKCM(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1361f : 1000f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 781f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1744f, 0);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1636f + 1440f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(JJNPIFDBHAG());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(PPLPLCAEHLF());
		}
	}

	protected void DNIHABOJOMI(Vector3 MPHCNMDIPAI)
	{
		LAADDLGBFIG.RPC(" 3", PhotonTargets.All, MPHCNMDIPAI);
		HNJAKHCIJLO(MPHCNMDIPAI);
	}

	protected void FKHMICCAFFA(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.IHNLJLDMPJL(base.gameObject, (HINJJOAJAOA)(-90));
		Singleton<HitParticleSystem>.instance.KNANLLHOLFB(MPHCNMDIPAI, Vector3.up, "ExtraWarBucks");
		GLALPOADGDI(HMCNKNCEDMA: false);
	}

	public void DBNMFHPGNJL(bool HMCNKNCEDMA)
	{
		BOOPJDADNAG(HMCNKNCEDMA);
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[1];
		array[1] = HMCNKNCEDMA;
		lAADDLGBFIG.RPC("trial", PhotonTargets.Others, array);
	}

	public void HHMPDOMLKEK(bool HMCNKNCEDMA)
	{
		LDLPFOEDLGN(HMCNKNCEDMA);
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[0] = HMCNKNCEDMA;
		lAADDLGBFIG.RPC(" {0}\u00a0{1}", PhotonTargets.Others, array);
	}

	protected void KHEBCFEFAII(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.LHMLDMINIPG(base.gameObject, (HINJJOAJAOA)108);
		Singleton<HitParticleSystem>.instance.OOGKGACIAHC(MPHCNMDIPAI, Vector3.up, "Wrong_Category");
		CONPLOGAHLF(HMCNKNCEDMA: false);
	}

	private IEnumerator IFAAOGKPGLO()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	protected void IIKGPDHOAOG(bool HMCNKNCEDMA)
	{
		DJADMOOHKJO(HMCNKNCEDMA);
	}

	private IEnumerator CFJICMDLGFB()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private void CAHCGAGJONJ(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1101f : 1693f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 581f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 335f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 728f + 644f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(DANJCHNBGJF());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(JJNPIFDBHAG());
		}
	}

	protected void LPIOGKCPNHF(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.BHPFDOOONEP(base.gameObject, (HINJJOAJAOA)(-106));
		Singleton<HitParticleSystem>.instance.ECJBFHNKEAL(MPHCNMDIPAI, Vector3.up, "UNSET_VALUE");
		CDBOICPKGNB(HMCNKNCEDMA: false);
	}

	private void EFKOJAAKINA(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				BHCDFCHPJMA(component.transform.position);
			}
		}
	}

	protected void LMBNALAPLME(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.LHMLDMINIPG(base.gameObject, (HINJJOAJAOA)(-115));
		Singleton<HitParticleSystem>.instance.KIAADIANGHA(MPHCNMDIPAI, Vector3.up, "GameController.Start DONE");
		MEDPBJMGHGP(HMCNKNCEDMA: false);
	}

	protected void FFEIBJEGHOI(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[1] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("GameControllerPVP.StartGame START", PhotonTargets.All, array);
		FOBEJLACNGN(MPHCNMDIPAI);
	}

	protected void OFHOKHDCKDM(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.IHNLJLDMPJL(base.gameObject, HINJJOAJAOA.ExplosionMolotov);
		Singleton<HitParticleSystem>.instance.ECJBFHNKEAL(MPHCNMDIPAI, Vector3.up, "<");
		BDLOMOOAIPK(HMCNKNCEDMA: false);
	}

	private void GBANDDGDJIG(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				BHCDFCHPJMA(component.transform.position);
			}
		}
	}

	private void DNJBCOJJGJK(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1234f : 1399f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 568f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1252f, 0);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1974f + 1333f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(LAIJGNPEDGH());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(PPLPLCAEHLF());
		}
	}

	protected void JPHFKOPEBJG(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[1] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("Time", PhotonTargets.Others, array);
		JNHMLCPLCIM(MPHCNMDIPAI);
	}

	protected override void Awake()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(EBPEBCALIEH));
	}

	protected void FCGAJMJEBCL(bool HMCNKNCEDMA)
	{
		PJPFGJGLBNF(HMCNKNCEDMA);
	}

	protected void HNJAKHCIJLO(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.Play(base.gameObject, (HINJJOAJAOA)(-49));
		Singleton<HitParticleSystem>.instance.OAJIMPBNGAO(MPHCNMDIPAI, Vector3.up, "false");
		DEOGNFLDONC(HMCNKNCEDMA: true);
	}

	protected void HOOJHIKJNAM(bool HMCNKNCEDMA)
	{
		BDLOMOOAIPK(HMCNKNCEDMA);
	}

	private void LDLPFOEDLGN(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 324f : 810f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 253f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 75f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 574f + 1713f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(JJNPIFDBHAG());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(CFJICMDLGFB());
		}
	}

	protected void HHDFDGFLMEL(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.LHMLDMINIPG(base.gameObject, (HINJJOAJAOA)(-82));
		Singleton<HitParticleSystem>.instance.EHHPGDDFKDA(MPHCNMDIPAI, Vector3.up, "WarFriends precisa descarregar aproximadamente 190MB de dados extra para correr.\nO tempo de download pode variar dependendo da rede e da localização.\n\nDesejas continuar?");
		CJKMCLNCGPB(HMCNKNCEDMA: false);
	}

	private void CDBOICPKGNB(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 0.05f : (-0.15f), EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 10f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 10f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 2f + 0.125f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(CJFFGJLDOOD());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(CJFFGJLDOOD());
		}
	}

	protected void OBPNMKIFLFM(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.BLKAHLHEAFB(base.gameObject, HINJJOAJAOA.SHOT_TURRET);
		Singleton<HitParticleSystem>.instance.FAJOJJGBPCC(MPHCNMDIPAI, Vector3.up, "AddedCards");
		BOOPJDADNAG(HMCNKNCEDMA: true);
	}

	protected void HBPJNJDPCHP(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[0] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("shield_idle", PhotonTargets.Others, array);
		KHEBCFEFAII(MPHCNMDIPAI);
	}

	private void MEDPBJMGHGP(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1711f : 7f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 1117f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 579f + 1257f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(PNBIAFMOGPK());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(PNBIAFMOGPK());
		}
	}

	protected void JNHMLCPLCIM(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.BHPFDOOONEP(base.gameObject, HINJJOAJAOA.HumveeEngineLoop);
		Singleton<HitParticleSystem>.instance.BGCIKMPGDAB(MPHCNMDIPAI, Vector3.up, "bigURL");
		AMALADGJKCM(HMCNKNCEDMA: true);
	}

	protected void HKKHHLKAFHF(bool HMCNKNCEDMA)
	{
		PJPFGJGLBNF(HMCNKNCEDMA);
	}

	protected void KEIMKMNGICI(Vector3 MPHCNMDIPAI)
	{
		LAADDLGBFIG.RPC("ID_DEBUG_STACKTRACEINCONSOLE", PhotonTargets.All, MPHCNMDIPAI);
		HHDFDGFLMEL(MPHCNMDIPAI);
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(NMPIDCNDCLA));
	}

	private void AOKHKDIKPPP(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: true);
				HBPJNJDPCHP(component.transform.position);
			}
		}
	}

	public void HBLIEOHIDNI(bool HMCNKNCEDMA)
	{
		DEOGNFLDONC(HMCNKNCEDMA);
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[0] = HMCNKNCEDMA;
		lAADDLGBFIG.RPC("PlayerName", PhotonTargets.Others, array);
	}

	protected void LDEMNJDAIDG(bool HMCNKNCEDMA)
	{
		GLALPOADGDI(HMCNKNCEDMA);
	}

	private IEnumerator PNBIAFMOGPK()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private void FDBCLHEOBNM(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1281f : 1676f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 414f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1592f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 336f + 1450f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(GFLEEKKFGFA());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(ANOBBOGFFLO());
		}
	}

	public void INHPDCIMIMB(bool HMCNKNCEDMA)
	{
		IIODICICEAC(HMCNKNCEDMA);
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[1];
		array[1] = HMCNKNCEDMA;
		lAADDLGBFIG.RPC("ID_LOGOUT", PhotonTargets.Others, array);
	}

	[PunRPC]
	protected void ExplodeRPC(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.Play(base.gameObject, HINJJOAJAOA.ElectricalBurst);
		Singleton<HitParticleSystem>.instance.PlayParticle(MPHCNMDIPAI, Vector3.up, "electricTrap");
		CDBOICPKGNB(HMCNKNCEDMA: false);
	}

	protected void GCHFGHAGJDG(Vector3 MPHCNMDIPAI)
	{
		LAADDLGBFIG.RPC("ExplodeRPC", PhotonTargets.Others, MPHCNMDIPAI);
		ExplodeRPC(MPHCNMDIPAI);
	}

	protected void AKPAJKLMDNH(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.BHPFDOOONEP(base.gameObject, HINJJOAJAOA.SHOT_SNIPER_3);
		Singleton<HitParticleSystem>.instance.GICCKFNEEAB(MPHCNMDIPAI, Vector3.up, "StepId");
		BDLOMOOAIPK(HMCNKNCEDMA: false);
	}

	private void CONPLOGAHLF(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 89f : 326f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 1648f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 532f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 223f + 860f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(CFJICMDLGFB());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(CFJICMDLGFB());
		}
	}

	protected void FMGIKMHLMNA(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.BHPFDOOONEP(base.gameObject, (HINJJOAJAOA)(-47));
		Singleton<HitParticleSystem>.instance.GICCKFNEEAB(MPHCNMDIPAI, Vector3.up, "placement");
		DEOGNFLDONC(HMCNKNCEDMA: false);
	}

	private IEnumerator ANOBBOGFFLO()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	public void NJAAMPDOGMM(bool HMCNKNCEDMA)
	{
		GNOBDIMGANF(HMCNKNCEDMA);
		LAADDLGBFIG.RPC("Count", PhotonTargets.All, HMCNKNCEDMA);
	}

	protected void NKLJFFPCELH(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[0] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("game-card-ico-criticalinsurance", PhotonTargets.Others, array);
		LPIOGKCPNHF(MPHCNMDIPAI);
	}

	public void GLHJHEBMLFK(bool HMCNKNCEDMA)
	{
		NBBPABNDMLB(HMCNKNCEDMA);
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[1];
		array[1] = HMCNKNCEDMA;
		lAADDLGBFIG.RPC("{0} {1}{2}", PhotonTargets.All, array);
	}

	private void JFMOGEHANIB(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 952f : 399f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 488f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 940f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 763f + 188f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(PPLPLCAEHLF());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(ANOBBOGFFLO());
		}
	}

	private void FNMMAIKMMPF(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				BIFAENHBHNF(component.transform.position);
			}
		}
	}

	protected void BHCDFCHPJMA(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[1];
		array[1] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("ID_EMPTYARENAHEROESCURRENT", PhotonTargets.Others, array);
		KHEBCFEFAII(MPHCNMDIPAI);
	}

	private void GLALPOADGDI(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1491f : 1968f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 881f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1f, 0);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1231f + 1770f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(GFLEEKKFGFA());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(FGJKGOGEBEM());
		}
	}

	protected void OOFINNGMBNJ(Vector3 MPHCNMDIPAI)
	{
		LAADDLGBFIG.RPC("ID_GC_LOGIN_TUTORIAL_TITLE", PhotonTargets.All, MPHCNMDIPAI);
		MGOHMDFNMNG(MPHCNMDIPAI);
	}

	protected void OFCAAMAJPOF(bool HMCNKNCEDMA)
	{
		AMALADGJKCM(HMCNKNCEDMA);
	}

	private void HDBCAPIHEOP(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				BIFAENHBHNF(component.transform.position);
			}
		}
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(EBPEBCALIEH));
	}

	protected void MBOKOHIEKGP(bool HMCNKNCEDMA)
	{
		DEOGNFLDONC(HMCNKNCEDMA);
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(LHNMCACHNDH));
	}

	private void CNCLLIJHAHF(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: true);
				HBPJNJDPCHP(component.transform.position);
			}
		}
	}

	protected void BIFAENHBHNF(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[1];
		array[1] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("Managers", PhotonTargets.All, array);
		OFHOKHDCKDM(MPHCNMDIPAI);
	}

	protected void FOBEJLACNGN(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.BLKAHLHEAFB(base.gameObject, HINJJOAJAOA.AssaultHelicopterEngineDeath);
		Singleton<HitParticleSystem>.instance.GICCKFNEEAB(MPHCNMDIPAI, Vector3.up, "FuseSDK instance not initialized. Awake may not have been called.");
		DJADMOOHKJO(HMCNKNCEDMA: true);
	}

	private void GNOBDIMGANF(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 823f : 643f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 769f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1645f, 0);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 157f + 1504f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(FGJKGOGEBEM());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(CJFFGJLDOOD());
		}
	}

	protected void DDLOHJKGEPG(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[1] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("N", PhotonTargets.All, array);
		JNHMLCPLCIM(MPHCNMDIPAI);
	}

	private void NMPIDCNDCLA(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: true);
				GCHFGHAGJDG(component.transform.position);
			}
		}
	}

	private void BOOPJDADNAG(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 776f : 1201f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 1656f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 613f, 0);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1060f + 1752f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(GFLEEKKFGFA());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			StopCoroutine(FFGDGNHLOLC());
		}
	}

	private IEnumerator GFLEEKKFGFA()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	public void AADAAMIOMBO(bool HMCNKNCEDMA)
	{
		AMALADGJKCM(HMCNKNCEDMA);
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[1] = HMCNKNCEDMA;
		lAADDLGBFIG.RPC("Excel {0} dont have row Tier!!!", PhotonTargets.All, array);
	}

	protected void LEEMKLGNLMD(Vector3 MPHCNMDIPAI)
	{
		Singleton<SoundsManager3D>.instance.LDKOGOEBMBA(base.gameObject, (HINJJOAJAOA)(-33));
		Singleton<HitParticleSystem>.instance.BPNIEDNNMMP(MPHCNMDIPAI, Vector3.up, "\n");
		CCJABONHOHF(HMCNKNCEDMA: true);
	}

	protected virtual void BAGCDJMLCPF()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(HDBCAPIHEOP));
	}

	[DebuggerHidden]
	private IEnumerator CJFFGJLDOOD()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	protected virtual void PBCDDNOCJOI()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(LJNEFDCDKFM));
	}

	protected void PDFGKPKBMAA(Vector3 MPHCNMDIPAI)
	{
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[0];
		array[0] = MPHCNMDIPAI;
		lAADDLGBFIG.RPC("squad", PhotonTargets.All, array);
		HHDFDGFLMEL(MPHCNMDIPAI);
	}

	private void IJDMHPLMCAD(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: false);
				HBPJNJDPCHP(component.transform.position);
			}
		}
	}

	protected void BKMAHKIOIBM(bool HMCNKNCEDMA)
	{
		MEDPBJMGHGP(HMCNKNCEDMA);
	}

	private IEnumerator PPLPLCAEHLF()
	{
		APHOFFLBJGD aPHOFFLBJGD = new APHOFFLBJGD();
		aPHOFFLBJGD.BJGCPDNMHDH = this;
		return aPHOFFLBJGD;
	}

	private void AONCLINMDNC(Collider APJKEKOEFHG)
	{
		if (TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && JPBBAIGNBAP.fraction != component.fraction && component.owner is EnemyController && LAADDLGBFIG.isMine)
			{
				component.Shiver(component.health, Vector3.zero, null, JPBBAIGNBAP, CAKABHIPCDF: true);
				NKLJFFPCELH(component.transform.position);
			}
		}
	}

	private void BENMCOJBKDL(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1482f : 651f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 1044f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 257f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 806f + 446f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(ANOBBOGFFLO());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(DANJCHNBGJF());
		}
	}

	protected virtual void JJBODEPAMBI()
	{
		base.Awake();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(IJDMHPLMCAD));
	}

	private void BDLOMOOAIPK(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1149f : 1592f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 1512f, 1);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1331f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 2f + 427f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = false;
				StartCoroutine(FGJKGOGEBEM());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(PPLPLCAEHLF());
		}
	}

	private void IIODICICEAC(bool HMCNKNCEDMA)
	{
		EIEHEBFBCMD.SetActive(HMCNKNCEDMA);
		if (HMCNKNCEDMA)
		{
			EIEHEBFBCMD.transform.localPosition = new Vector3(EIEHEBFBCMD.transform.localPosition.x, (!Singleton<MapManager>.instance.ALCHJDPKAID.JBCHDHOOBCO) ? 1986f : 182f, EIEHEBFBCMD.transform.localPosition.z);
			NavMesh.SamplePosition(BIGIABDIHJD.transform.position, out var hit, 367f, 0);
			BIGIABDIHJD.transform.position = hit.position;
			NavMesh.SamplePosition(BMMJAPBBDND.transform.position, out hit, 1311f, 1);
			BMMJAPBBDND.transform.position = hit.position;
			IPEGHONOCOJ.transform.localPosition = IPEGHONOCOJ.transform.localPosition.ReplaceY((BIGIABDIHJD.transform.localPosition.y + BMMJAPBBDND.transform.localPosition.y) / 1220f + 849f);
			if (!JCKOBELDCGD)
			{
				JCKOBELDCGD = true;
				StartCoroutine(GFLEEKKFGFA());
			}
		}
		else if (JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			StopCoroutine(PNBIAFMOGPK());
		}
	}

	protected void FBJMCLHEAFF(bool HMCNKNCEDMA)
	{
		DCLAJPLAICE(HMCNKNCEDMA);
	}
}
