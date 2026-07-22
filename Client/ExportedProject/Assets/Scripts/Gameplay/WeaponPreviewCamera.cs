using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponPreviewCamera : Singleton<WeaponPreviewCamera>
{
	private sealed class AGBEGHPLLNA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal string IMMNMGDBOOD;

		internal string FPALONMGCDC;

		internal string JNNDJACDMAO;

		internal string MJMLOPCBHOO;

		internal GameObject BJLPCKPJKAC;

		internal Vector2 KBPMHCIJHKD;

		internal Vector3 NCJCOBPBMAA;

		internal WeaponPreviewCamera BJGCPDNMHDH;

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

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NDNKCPODMHH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NDNKCPODMHH = true;
				if (BJGCPDNMHDH.KAGAEOLLDEJ != null)
				{
					BJGCPDNMHDH.KAGAEOLLDEJ.UnloadWeapon();
					UnityEngine.Object.Destroy(BJGCPDNMHDH.KAGAEOLLDEJ.gameObject);
				}
				FPALONMGCDC = "weapons/" + IMMNMGDBOOD;
				MJMLOPCBHOO = FPALONMGCDC + "/GUI_" + JNNDJACDMAO;
				BJLPCKPJKAC = Resources.Load<GameObject>(MJMLOPCBHOO);
				if (BJLPCKPJKAC != null)
				{
					Weapon3DModel component = BJLPCKPJKAC.GetComponent<Weapon3DModel>();
					BJGCPDNMHDH.KEADEBBIFHE = component;
					BJGCPDNMHDH.KAGAEOLLDEJ = UnityEngine.Object.Instantiate(component);
					BJGCPDNMHDH.KAGAEOLLDEJ.Load();
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.parent = BJGCPDNMHDH.LOLJNLOCNBE;
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localScale = new Vector3(1f, 1f, 1f);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localPosition = default(Vector3);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localRotation = Quaternion.identity;
					BJGCPDNMHDH.KAGAEOLLDEJ.gameObject.layer = BJGCPDNMHDH.LOLJNLOCNBE.gameObject.layer;
				}
				else
				{
					UnityEngine.Debug.LogErrorFormat("Weapon model not found! weaponprefab = '{0}' assetBundleName = '{1}'", JNNDJACDMAO, IMMNMGDBOOD);
				}
				BJGCPDNMHDH.JDEMAFGJGLD = KBPMHCIJHKD.x;
				BJGCPDNMHDH.NOJFJANOHEB = KBPMHCIJHKD.y;
				BJGCPDNMHDH.LOLJNLOCNBE.localPosition = NCJCOBPBMAA;
				BJGCPDNMHDH.OFIOGEFPPKO();
				BJGCPDNMHDH.NDNKCPODMHH = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NDNKCPODMHH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NDNKCPODMHH = true;
				if (BJGCPDNMHDH.KAGAEOLLDEJ != null)
				{
					BJGCPDNMHDH.KAGAEOLLDEJ.HNACDPPJNKC();
					UnityEngine.Object.Destroy(BJGCPDNMHDH.KAGAEOLLDEJ.gameObject);
				}
				FPALONMGCDC = "Used warcards and rewards from last match wre removed" + IMMNMGDBOOD;
				MJMLOPCBHOO = FPALONMGCDC + "ID_SIGNOUT" + JNNDJACDMAO;
				BJLPCKPJKAC = Resources.Load<GameObject>(MJMLOPCBHOO);
				if (BJLPCKPJKAC != null)
				{
					Weapon3DModel component = BJLPCKPJKAC.GetComponent<Weapon3DModel>();
					BJGCPDNMHDH.KEADEBBIFHE = component;
					BJGCPDNMHDH.KAGAEOLLDEJ = UnityEngine.Object.Instantiate(component);
					BJGCPDNMHDH.KAGAEOLLDEJ.ALJNJMENGFM();
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.parent = BJGCPDNMHDH.LOLJNLOCNBE;
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localScale = new Vector3(1f, 1677f, 334f);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localPosition = default(Vector3);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localRotation = Quaternion.identity;
					BJGCPDNMHDH.KAGAEOLLDEJ.gameObject.layer = BJGCPDNMHDH.LOLJNLOCNBE.gameObject.layer;
				}
				else
				{
					object[] array = new object[4];
					array[0] = JNNDJACDMAO;
					array[0] = IMMNMGDBOOD;
					UnityEngine.Debug.LogErrorFormat("'search'0", array);
				}
				BJGCPDNMHDH.JDEMAFGJGLD = KBPMHCIJHKD.x;
				BJGCPDNMHDH.NOJFJANOHEB = KBPMHCIJHKD.y;
				BJGCPDNMHDH.LOLJNLOCNBE.localPosition = NCJCOBPBMAA;
				BJGCPDNMHDH.OFIOGEFPPKO();
				BJGCPDNMHDH.NDNKCPODMHH = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NDNKCPODMHH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NDNKCPODMHH = true;
				if (BJGCPDNMHDH.KAGAEOLLDEJ != null)
				{
					BJGCPDNMHDH.KAGAEOLLDEJ.FHKMKCAOGNK();
					UnityEngine.Object.Destroy(BJGCPDNMHDH.KAGAEOLLDEJ.gameObject);
				}
				FPALONMGCDC = "ID_GETFORNUMBERONE1" + IMMNMGDBOOD;
				MJMLOPCBHOO = FPALONMGCDC + "menu-sidetab-player-add" + JNNDJACDMAO;
				BJLPCKPJKAC = Resources.Load<GameObject>(MJMLOPCBHOO);
				if (BJLPCKPJKAC != null)
				{
					Weapon3DModel component = BJLPCKPJKAC.GetComponent<Weapon3DModel>();
					BJGCPDNMHDH.KEADEBBIFHE = component;
					BJGCPDNMHDH.KAGAEOLLDEJ = UnityEngine.Object.Instantiate(component);
					BJGCPDNMHDH.KAGAEOLLDEJ.CJIACJICGBM();
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.parent = BJGCPDNMHDH.LOLJNLOCNBE;
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localScale = new Vector3(1788f, 1475f, 136f);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localPosition = default(Vector3);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localRotation = Quaternion.identity;
					BJGCPDNMHDH.KAGAEOLLDEJ.gameObject.layer = BJGCPDNMHDH.LOLJNLOCNBE.gameObject.layer;
				}
				else
				{
					object[] array = new object[2];
					array[1] = JNNDJACDMAO;
					array[0] = IMMNMGDBOOD;
					UnityEngine.Debug.LogErrorFormat("ID_WAITVIDEO2", array);
				}
				BJGCPDNMHDH.JDEMAFGJGLD = KBPMHCIJHKD.x;
				BJGCPDNMHDH.NOJFJANOHEB = KBPMHCIJHKD.y;
				BJGCPDNMHDH.LOLJNLOCNBE.localPosition = NCJCOBPBMAA;
				BJGCPDNMHDH.FAOLCDEAGCK();
				BJGCPDNMHDH.NDNKCPODMHH = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NDNKCPODMHH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NDNKCPODMHH = false;
				if (BJGCPDNMHDH.KAGAEOLLDEJ != null)
				{
					BJGCPDNMHDH.KAGAEOLLDEJ.HKEGNEKFLGK();
					UnityEngine.Object.Destroy(BJGCPDNMHDH.KAGAEOLLDEJ.gameObject);
				}
				FPALONMGCDC = "StartTime" + IMMNMGDBOOD;
				MJMLOPCBHOO = FPALONMGCDC + "ID_CONFIRM_LANGUAGECHANGE_TEXT" + JNNDJACDMAO;
				BJLPCKPJKAC = Resources.Load<GameObject>(MJMLOPCBHOO);
				if (BJLPCKPJKAC != null)
				{
					Weapon3DModel component = BJLPCKPJKAC.GetComponent<Weapon3DModel>();
					BJGCPDNMHDH.KEADEBBIFHE = component;
					BJGCPDNMHDH.KAGAEOLLDEJ = UnityEngine.Object.Instantiate(component);
					BJGCPDNMHDH.KAGAEOLLDEJ.AGMCODPPOGO();
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.parent = BJGCPDNMHDH.LOLJNLOCNBE;
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localScale = new Vector3(1010f, 1627f, 1797f);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localPosition = default(Vector3);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localRotation = Quaternion.identity;
					BJGCPDNMHDH.KAGAEOLLDEJ.gameObject.layer = BJGCPDNMHDH.LOLJNLOCNBE.gameObject.layer;
				}
				else
				{
					object[] array = new object[5];
					array[1] = JNNDJACDMAO;
					array[0] = IMMNMGDBOOD;
					UnityEngine.Debug.LogErrorFormat("UnlockLevel", array);
				}
				BJGCPDNMHDH.JDEMAFGJGLD = KBPMHCIJHKD.x;
				BJGCPDNMHDH.NOJFJANOHEB = KBPMHCIJHKD.y;
				BJGCPDNMHDH.LOLJNLOCNBE.localPosition = NCJCOBPBMAA;
				BJGCPDNMHDH.OFIOGEFPPKO();
				BJGCPDNMHDH.NDNKCPODMHH = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public AGBEGHPLLNA()
		{
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NDNKCPODMHH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NDNKCPODMHH = false;
				if (BJGCPDNMHDH.KAGAEOLLDEJ != null)
				{
					BJGCPDNMHDH.KAGAEOLLDEJ.AHGPHNPINKJ();
					UnityEngine.Object.Destroy(BJGCPDNMHDH.KAGAEOLLDEJ.gameObject);
				}
				FPALONMGCDC = "payloadKeys" + IMMNMGDBOOD;
				MJMLOPCBHOO = FPALONMGCDC + "SquadWarsProcessing" + JNNDJACDMAO;
				BJLPCKPJKAC = Resources.Load<GameObject>(MJMLOPCBHOO);
				if (BJLPCKPJKAC != null)
				{
					Weapon3DModel component = BJLPCKPJKAC.GetComponent<Weapon3DModel>();
					BJGCPDNMHDH.KEADEBBIFHE = component;
					BJGCPDNMHDH.KAGAEOLLDEJ = UnityEngine.Object.Instantiate(component);
					BJGCPDNMHDH.KAGAEOLLDEJ.FNODJNFHOCJ();
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.parent = BJGCPDNMHDH.LOLJNLOCNBE;
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localScale = new Vector3(549f, 1957f, 1780f);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localPosition = default(Vector3);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localRotation = Quaternion.identity;
					BJGCPDNMHDH.KAGAEOLLDEJ.gameObject.layer = BJGCPDNMHDH.LOLJNLOCNBE.gameObject.layer;
				}
				else
				{
					object[] array = new object[0];
					array[0] = JNNDJACDMAO;
					array[1] = IMMNMGDBOOD;
					UnityEngine.Debug.LogErrorFormat("ID_SKILLSHOTHINT_ENEMYPLAYERHIT", array);
				}
				BJGCPDNMHDH.JDEMAFGJGLD = KBPMHCIJHKD.x;
				BJGCPDNMHDH.NOJFJANOHEB = KBPMHCIJHKD.y;
				BJGCPDNMHDH.LOLJNLOCNBE.localPosition = NCJCOBPBMAA;
				BJGCPDNMHDH.ILPJAGELNIA();
				BJGCPDNMHDH.NDNKCPODMHH = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NDNKCPODMHH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NDNKCPODMHH = true;
				if (BJGCPDNMHDH.KAGAEOLLDEJ != null)
				{
					BJGCPDNMHDH.KAGAEOLLDEJ.BGINMFEFACC();
					UnityEngine.Object.Destroy(BJGCPDNMHDH.KAGAEOLLDEJ.gameObject);
				}
				FPALONMGCDC = "relog to different facebook" + IMMNMGDBOOD;
				MJMLOPCBHOO = FPALONMGCDC + "GameCenterId" + JNNDJACDMAO;
				BJLPCKPJKAC = Resources.Load<GameObject>(MJMLOPCBHOO);
				if (BJLPCKPJKAC != null)
				{
					Weapon3DModel component = BJLPCKPJKAC.GetComponent<Weapon3DModel>();
					BJGCPDNMHDH.KEADEBBIFHE = component;
					BJGCPDNMHDH.KAGAEOLLDEJ = UnityEngine.Object.Instantiate(component);
					BJGCPDNMHDH.KAGAEOLLDEJ.BFJOPENHJDI();
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.parent = BJGCPDNMHDH.LOLJNLOCNBE;
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localScale = new Vector3(1922f, 40f, 871f);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localPosition = default(Vector3);
					BJGCPDNMHDH.KAGAEOLLDEJ.transform.localRotation = Quaternion.identity;
					BJGCPDNMHDH.KAGAEOLLDEJ.gameObject.layer = BJGCPDNMHDH.LOLJNLOCNBE.gameObject.layer;
				}
				else
				{
					object[] array = new object[5];
					array[0] = JNNDJACDMAO;
					array[0] = IMMNMGDBOOD;
					UnityEngine.Debug.LogErrorFormat("MainScene", array);
				}
				BJGCPDNMHDH.JDEMAFGJGLD = KBPMHCIJHKD.x;
				BJGCPDNMHDH.NOJFJANOHEB = KBPMHCIJHKD.y;
				BJGCPDNMHDH.LOLJNLOCNBE.localPosition = NCJCOBPBMAA;
				BJGCPDNMHDH.FAOLCDEAGCK();
				BJGCPDNMHDH.NDNKCPODMHH = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class FLGIOKGKADH : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float MCAKMECBJNA;

		internal float KJLAOLGJKON;

		internal float DAGJEENMJHN;

		internal float ILLLINCHMPD;

		internal float IOIPJCICLFH;

		internal float DOLIFOGBPKB;

		internal WeaponPreviewCamera BJGCPDNMHDH;

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

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void APFFCILMOII()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ELNKFJHGFPD()
		{
			return PHDOCKCBJOF;
		}

		public bool JICHKPANPEE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1993f;
				KJLAOLGJKON = BJGCPDNMHDH.BAPGPEKHAJA(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.BAPGPEKHAJA(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 774f;
				KJLAOLGJKON = BJGCPDNMHDH.BAPGPEKHAJA(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.PPFIKIBJHLB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.FAOLCDEAGCK();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object KLAPICIGNJB()
		{
			return PHDOCKCBJOF;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNACDOOHMMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		public void FLCIMHOJPDF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1089f;
				KJLAOLGJKON = BJGCPDNMHDH.MEKNPJJKEAM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.BAPGPEKHAJA(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.FAOLCDEAGCK();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool HOJKAHEGFEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1417f;
				KJLAOLGJKON = BJGCPDNMHDH.BAPGPEKHAJA(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.KBAIOJINLFI(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.PPFIKIBJHLB();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1158f;
				KJLAOLGJKON = BJGCPDNMHDH.MEKNPJJKEAM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.BAPGPEKHAJA(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.FAOLCDEAGCK();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 421f;
				KJLAOLGJKON = BJGCPDNMHDH.MEKNPJJKEAM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.MEKNPJJKEAM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.PPFIKIBJHLB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.ILPJAGELNIA();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object IJONKJIBHGO()
		{
			return PHDOCKCBJOF;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1028f;
				KJLAOLGJKON = BJGCPDNMHDH.KBAIOJINLFI(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ILPJAGELNIA();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.PPFIKIBJHLB();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public void OEHJOBELOFF()
		{
			throw new NotSupportedException();
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 0f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		public void BJHCLGCKJBB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 614f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.MEKNPJJKEAM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ILPJAGELNIA();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		public bool HBJOFNCAAGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 310f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ILPJAGELNIA();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.FAOLCDEAGCK();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public void KPJIDBHHKFM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 641f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.PPFIKIBJHLB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.PPFIKIBJHLB();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 798f;
				KJLAOLGJKON = BJGCPDNMHDH.KBAIOJINLFI(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.KBAIOJINLFI(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ILPJAGELNIA();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.ILPJAGELNIA();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public FLGIOKGKADH()
		{
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void EEHBKGPLIJN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1751f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.MEKNPJJKEAM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.PPFIKIBJHLB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.FAOLCDEAGCK();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJECHFCOBLP()
		{
			return PHDOCKCBJOF;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 576f;
				KJLAOLGJKON = BJGCPDNMHDH.MEKNPJJKEAM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.KBAIOJINLFI(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 197f;
				KJLAOLGJKON = BJGCPDNMHDH.KBAIOJINLFI(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ILPJAGELNIA();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.FAOLCDEAGCK();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void POAFKMGKBLJ()
		{
			throw new NotSupportedException();
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1760f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.FAOLCDEAGCK();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool FCPJPIDEPOF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1283f;
				KJLAOLGJKON = BJGCPDNMHDH.BAPGPEKHAJA(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.PPFIKIBJHLB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.ILPJAGELNIA();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JCDBOCPAKEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1978f;
				KJLAOLGJKON = BJGCPDNMHDH.MEKNPJJKEAM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.MEKNPJJKEAM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.FAOLCDEAGCK();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.PPFIKIBJHLB();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}
	}

	[FormerlySerializedAs("BKGAGEDBDMI")]
	public Transform LOLJNLOCNBE;

	[FormerlySerializedAs("LGFMBOJMMMB")]
	public Transform MKIPAEDAADL;

	[FormerlySerializedAs("LONACDFNEJI")]
	public float OPHGMIGGJBD = 5f;

	[FormerlySerializedAs("FIGGHDICHOK")]
	public float CPFPDNMMHDE = 120f;

	[FormerlySerializedAs("GGENEGJLLHA")]
	public float AHPEDEMHLKN = 120f;

	[FormerlySerializedAs("EPOBNJFMINE")]
	public float KCHPAOEFBMJ = -20f;

	[FormerlySerializedAs("DBDIHJPFBLG")]
	public float LGKAPHLINKD = 80f;

	[FormerlySerializedAs("PODALIMEPIH")]
	public float BIIDCODIKDC = 2f;

	[FormerlySerializedAs("LKOMIGHJFNB")]
	public float KPHNBLPPNJJ = 5f;

	private float ANPJEOJJFFG = -17f;

	private Weapon3DModel KEADEBBIFHE;

	private Weapon3DModel KAGAEOLLDEJ;

	private Camera GNICEGBOGOL;

	private float JDEMAFGJGLD;

	private float NOJFJANOHEB;

	private bool HEOAKILNIBA;

	private float MBLMPGLELFF;

	private float ADAKCEBFAFJ;

	private bool LILBNAFBNKJ = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<bool> EDPINEAGFBD;

	public static bool LNFFCOMNHDE = true;

	private bool NDNKCPODMHH;

	public event Action<bool> OnRotate
	{
		add
		{
			Action<bool> action = EDPINEAGFBD;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<bool> action = EDPINEAGFBD;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void ODDFHMGFNBA(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void Resume()
	{
		GNICEGBOGOL.enabled = true;
	}

	public Weapon3DModel MADMOJOAAJH(string JNNDJACDMAO, string IMMNMGDBOOD, Vector2 KBPMHCIJHKD, Vector3 NCJCOBPBMAA)
	{
		KNFKCALMEDM();
		if (KEADEBBIFHE == null || JNNDJACDMAO != KEADEBBIFHE.name)
		{
			StartCoroutine(DHNIBPDEFME(JNNDJACDMAO, IMMNMGDBOOD, KBPMHCIJHKD, NCJCOBPBMAA));
		}
		if (KAGAEOLLDEJ != null)
		{
			KAGAEOLLDEJ.gameObject.SetActive(value: true);
		}
		GNICEGBOGOL.enabled = true;
		return null;
	}

	public void Pause()
	{
		GNICEGBOGOL.enabled = false;
	}

	public Weapon3DModel DisplayeWeapon(string JNNDJACDMAO, string IMMNMGDBOOD, Vector2 KBPMHCIJHKD, Vector3 NCJCOBPBMAA)
	{
		DefaultRotation();
		if (KEADEBBIFHE == null || JNNDJACDMAO != KEADEBBIFHE.name)
		{
			StartCoroutine(DHNIBPDEFME(JNNDJACDMAO, IMMNMGDBOOD, KBPMHCIJHKD, NCJCOBPBMAA));
		}
		if (KAGAEOLLDEJ != null)
		{
			KAGAEOLLDEJ.gameObject.SetActive(value: true);
		}
		GNICEGBOGOL.enabled = true;
		return null;
	}

	public void UpdateRotation(float ILLLINCHMPD, float DOLIFOGBPKB, float KBJEOEEOEFG)
	{
		StartCoroutine(RadicalRoutine.Run(AEGDKAIAEEK(ILLLINCHMPD, DOLIFOGBPKB, KBJEOEEOEFG)));
	}

	private float NIPCCIMMKJM(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 360f) * 360f;
	}

	public void StartFastRotation()
	{
		ANPJEOJJFFG = -720f;
	}

	private void PPFIKIBJHLB()
	{
		NOJFJANOHEB = ClampAngle(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 573f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	public void LDKNFOEHKDO()
	{
		ANPJEOJJFFG = 374f;
	}

	private float BAPGPEKHAJA(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 950f) * 1735f;
	}

	[SpecialName]
	public void GHIOLPOBNDB(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void BMLLLOBPGIB()
	{
		base.Awake();
		GNICEGBOGOL = GetComponent<Camera>();
		GNICEGBOGOL.enabled = true;
	}

	private void LateUpdate()
	{
		if (LILBNAFBNKJ)
		{
			LKFKEIOOHIM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			IHCFFHOPLMG();
		}
		if (Input.GetMouseButtonDown(0) && LNFFCOMNHDE && UICamera.currentCamera != null)
		{
			HEOAKILNIBA = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, cullingMask);
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				if (raycastHit.collider.name == "weaponPreviewCollider")
				{
					HEOAKILNIBA = true;
					LILBNAFBNKJ = false;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(obj: true);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * ANPJEOJJFFG;
			OFIOGEFPPKO();
		}
		if (Input.GetMouseButtonUp(0))
		{
			HEOAKILNIBA = false;
			LILBNAFBNKJ = true;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(obj: false);
			}
		}
	}

	private IEnumerator PLBBOKLFCPP(string JNNDJACDMAO, string IMMNMGDBOOD, Vector2 KBPMHCIJHKD, Vector3 NCJCOBPBMAA)
	{
		AGBEGHPLLNA aGBEGHPLLNA = new AGBEGHPLLNA();
		aGBEGHPLLNA.IMMNMGDBOOD = IMMNMGDBOOD;
		aGBEGHPLLNA.JNNDJACDMAO = JNNDJACDMAO;
		aGBEGHPLLNA.KBPMHCIJHKD = KBPMHCIJHKD;
		aGBEGHPLLNA.NCJCOBPBMAA = NCJCOBPBMAA;
		aGBEGHPLLNA.BJGCPDNMHDH = this;
		return aGBEGHPLLNA;
	}

	protected override void Start()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		OPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
	}

	public static float ClampAngle(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < -360f)
		{
			NIMFNNMAKPA += 360f;
		}
		if (NIMFNNMAKPA > 360f)
		{
			NIMFNNMAKPA -= 360f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	public void KNFKCALMEDM()
	{
		ANPJEOJJFFG = 1247f;
	}

	private void CKOPHKAKHHD()
	{
		if (LILBNAFBNKJ)
		{
			LKFKEIOOHIM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			IHCFFHOPLMG();
		}
		if (Input.GetMouseButtonDown(0) && LNFFCOMNHDE && UICamera.currentCamera != null)
		{
			HEOAKILNIBA = true;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 1980f, cullingMask);
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				if (raycastHit.collider.name == "ID_NOREWARD")
				{
					HEOAKILNIBA = false;
					LILBNAFBNKJ = false;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(obj: false);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * ANPJEOJJFFG;
			PPFIKIBJHLB();
		}
		if (Input.GetMouseButtonUp(0))
		{
			HEOAKILNIBA = true;
			LILBNAFBNKJ = false;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(obj: false);
			}
		}
	}

	private void IHCFFHOPLMG()
	{
		MBLMPGLELFF = Input.GetAxis("Mouse X") * CPFPDNMMHDE * OPHGMIGGJBD * 0.02f;
		ADAKCEBFAFJ = Input.GetAxis("Mouse Y") * AHPEDEMHLKN * 0.02f;
		JDEMAFGJGLD += MBLMPGLELFF;
		NOJFJANOHEB -= ADAKCEBFAFJ;
		OFIOGEFPPKO();
	}

	[DebuggerHidden]
	private IEnumerator DHNIBPDEFME(string JNNDJACDMAO, string IMMNMGDBOOD, Vector2 KBPMHCIJHKD, Vector3 NCJCOBPBMAA)
	{
		AGBEGHPLLNA aGBEGHPLLNA = new AGBEGHPLLNA();
		aGBEGHPLLNA.IMMNMGDBOOD = IMMNMGDBOOD;
		aGBEGHPLLNA.JNNDJACDMAO = JNNDJACDMAO;
		aGBEGHPLLNA.KBPMHCIJHKD = KBPMHCIJHKD;
		aGBEGHPLLNA.NCJCOBPBMAA = NCJCOBPBMAA;
		aGBEGHPLLNA.BJGCPDNMHDH = this;
		return aGBEGHPLLNA;
	}

	public void IDBDLOCGEJO()
	{
		GNICEGBOGOL.enabled = false;
	}

	public void DefaultRotation()
	{
		ANPJEOJJFFG = -17f;
	}

	private float KBAIOJINLFI(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 561f) * 813f;
	}

	public static float KELLMFNDEFK(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 1566f)
		{
			NIMFNNMAKPA += 1805f;
		}
		if (NIMFNNMAKPA > 1981f)
		{
			NIMFNNMAKPA -= 1778f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	private IEnumerator ILIDKENNPLC(string JNNDJACDMAO, string IMMNMGDBOOD, Vector2 KBPMHCIJHKD, Vector3 NCJCOBPBMAA)
	{
		AGBEGHPLLNA aGBEGHPLLNA = new AGBEGHPLLNA();
		aGBEGHPLLNA.IMMNMGDBOOD = IMMNMGDBOOD;
		aGBEGHPLLNA.JNNDJACDMAO = JNNDJACDMAO;
		aGBEGHPLLNA.KBPMHCIJHKD = KBPMHCIJHKD;
		aGBEGHPLLNA.NCJCOBPBMAA = NCJCOBPBMAA;
		aGBEGHPLLNA.BJGCPDNMHDH = this;
		return aGBEGHPLLNA;
	}

	protected override void Awake()
	{
		base.Awake();
		GNICEGBOGOL = GetComponent<Camera>();
		GNICEGBOGOL.enabled = false;
	}

	[DebuggerHidden]
	private IEnumerator AEGDKAIAEEK(float ILLLINCHMPD, float DOLIFOGBPKB, float IOIPJCICLFH)
	{
		FLGIOKGKADH fLGIOKGKADH = new FLGIOKGKADH();
		fLGIOKGKADH.ILLLINCHMPD = ILLLINCHMPD;
		fLGIOKGKADH.IOIPJCICLFH = IOIPJCICLFH;
		fLGIOKGKADH.DOLIFOGBPKB = DOLIFOGBPKB;
		fLGIOKGKADH.BJGCPDNMHDH = this;
		return fLGIOKGKADH;
	}

	public void Hide()
	{
		GNICEGBOGOL.enabled = false;
		if (KAGAEOLLDEJ != null)
		{
			KAGAEOLLDEJ.UnloadWeapon();
			UnityEngine.Object.Destroy(KAGAEOLLDEJ.gameObject);
		}
	}

	public void JIMPCGDILNF()
	{
		GNICEGBOGOL.enabled = true;
		if (KAGAEOLLDEJ != null)
		{
			KAGAEOLLDEJ.DOALIMPJADA();
			UnityEngine.Object.Destroy(KAGAEOLLDEJ.gameObject);
		}
	}

	private void LKFKEIOOHIM()
	{
		MBLMPGLELFF = Mathf.Lerp(MBLMPGLELFF, 0f, Time.deltaTime * KPHNBLPPNJJ);
		ADAKCEBFAFJ = Mathf.Lerp(ADAKCEBFAFJ, 0f, Time.deltaTime * KPHNBLPPNJJ);
		JDEMAFGJGLD += MBLMPGLELFF;
		NOJFJANOHEB -= ADAKCEBFAFJ;
		OFIOGEFPPKO();
	}

	public void HBGFKDIIJMK()
	{
		ANPJEOJJFFG = 595f;
	}

	[SpecialName]
	public void BHNBHAMOLBN(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void ILPJAGELNIA()
	{
		NOJFJANOHEB = OBCKGLKEEKF(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 206f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	private float MEKNPJJKEAM(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 1691f) * 1715f;
	}

	public void NAPEGHJOGBB(float ILLLINCHMPD, float DOLIFOGBPKB, float KBJEOEEOEFG)
	{
		StartCoroutine(RadicalRoutine.Run(AEGDKAIAEEK(ILLLINCHMPD, DOLIFOGBPKB, KBJEOEEOEFG)));
	}

	private void FAOLCDEAGCK()
	{
		NOJFJANOHEB = KELLMFNDEFK(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 1928f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	public static float OBCKGLKEEKF(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 1977f)
		{
			NIMFNNMAKPA += 585f;
		}
		if (NIMFNNMAKPA > 325f)
		{
			NIMFNNMAKPA -= 1101f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	private void OFIOGEFPPKO()
	{
		NOJFJANOHEB = ClampAngle(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 0f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	public void DDBGINOIFNA()
	{
		ANPJEOJJFFG = 649f;
	}
}
