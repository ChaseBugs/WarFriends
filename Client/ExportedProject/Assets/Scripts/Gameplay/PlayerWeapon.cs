using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Weapon))]
public class PlayerWeapon : Core_BaseScript, TimeScaleIgnorable
{
	private sealed class FDFGELLNDDD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerWeapon BJGCPDNMHDH;

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
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public bool EKHDJADMNJK()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.PNBLBFIJDNN(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[1];
					array[1] = '\u0018';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "Chat - new notifications: {0}, selectedSquadChat: {1}, currentState: {2}" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "EndReason" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.LJPFCAAEOPN(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public bool LGLPPAENMGK()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[1] = 'R';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "assignmentCount" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "menu-weapon-benelli-starterpack" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.BEJPNGAMJLD(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void CPEEDIDEKLA()
		{
		}

		public bool CCOPPEKLJOB()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[0] = '\'';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "ID_SYSTEMMAINTENANCE" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "Cant generate buddy card for weapons: {0}, {1} and type {2}" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.IAGJEPGBOOM(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public bool HDGDKCMIOGK()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[1] = '\uffd8';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "{0}{1}{2} {3}{4} {5}{6}" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "DESTROYED REFERENCE" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.LJPFCAAEOPN(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
		}

		[SpecialName]
		private object KJGPLKJAIMC()
		{
			return PHDOCKCBJOF;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public bool KEBEGEDKIKM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[0] = '^';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "({0}\u00a0/\u00a0{1})" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "GetOriginalAccountId()" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.BGGNEJCEOAI(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void NFAMBMLLFGP()
		{
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		public void EGAONBPLDAG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AAAOCACGKIP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JNKDBMNFGJJ()
		{
			return PHDOCKCBJOF;
		}

		public bool PKOMECFNPIP()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[0] = '5';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "0" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "LevelName" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.IFHIFIEAHDH(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
		{
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public bool DFMKKFMEBON()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[0] = 'q';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "WARBUCKS PREFIX = " + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "Indicator {0}" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.OAMEGDAMGBP(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		public void CHFJIODFNIP()
		{
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
		}

		public bool NAOFKEEIFCG()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string text = BJGCPDNMHDH.IIMFFAADKCM.Split('￥')[0];
					string text2 = "NAME" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "ID_STAT_MOSTPOWERFULLARMY" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.ReloadMaterials(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public bool ACHIHMMCDNF()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string text = BJGCPDNMHDH.IIMFFAADKCM.Split('\uffef')[1];
					string text2 = "N" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "\"" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.OAMEGDAMGBP(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public bool HCONPNNPBAD()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[1] = '\ufff9';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "{0}{1}" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "]=" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.GLPIGFLKIEN(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		public void LFIGPJBHPBH()
		{
		}

		public bool GPIPJIDGCKM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.PNBLBFIJDNN(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[1];
					array[1] = 'ￃ';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "Uncover" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "ID_MORTARBUILDTIME" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.OAMEGDAMGBP(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		public void IKGBMDKKAPA()
		{
		}

		public bool EJKHEELJJFM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[1] = 'ￚ';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "Configurations error, there is {0} configurations of type {1}" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "guestId" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.BNELBGDFGPA(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		public bool ANIKAJEKMPM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string text = BJGCPDNMHDH.IIMFFAADKCM.Split('f')[0];
					string text2 = "ID_PURCHASED" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "player name" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.BNELBGDFGPA(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public bool FBMLBIOKKBE()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string text = BJGCPDNMHDH.IIMFFAADKCM.Split('r')[1];
					string text2 = "AtlasPreparer.LoadCommonCoroutine" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + " " + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.LJPFCAAEOPN(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		public bool PJJPPMIBNLN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.PNBLBFIJDNN(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[0] = '￪';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "WarArenaConfig" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "ID_NOTIFICATION_DAILYREWARD_CARDPACK" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.GLPIGFLKIEN(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string text = BJGCPDNMHDH.IIMFFAADKCM.Split('/')[1];
					string text2 = "Weapons/" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "/Player_" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.ReloadMaterials(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		public bool GCEBFCBBEKM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string text = BJGCPDNMHDH.IIMFFAADKCM.Split('2')[0];
					string text2 = "bronze3" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "customDouble" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.MBGNBALIDPA(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		public bool EBLHEEKHANA()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.PNBLBFIJDNN(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[1] = 'v';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "Tier" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "ID_GETFORREWARD1" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.IAGJEPGBOOM(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}

		public bool DDBCLDGNFBB()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[1];
					array[1] = 'ￇ';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "PARCELABLE_WRITE_RETURN_VALUE" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "ID_OFFERACTIVE" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.LACBJMIAHOG(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		public void PNGIELILHDI()
		{
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void OAFPDIHGJDC()
		{
		}

		[SpecialName]
		private object FCFHLDPLIDC()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public void PCNOHGFPMOE()
		{
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		public void LGCKODOHHIA()
		{
			throw new NotSupportedException();
		}

		public void CFLPOEJGKFF()
		{
			throw new NotSupportedException();
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void MKACBCOLNKD()
		{
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public bool CJGDOJHLOII()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[1];
					array[1] = 'ￌ';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "ID_TUTORIAL_KILLING_SCOPE" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "wasEquipped" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.MBGNBALIDPA(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[DebuggerHidden]
		public FDFGELLNDDD()
		{
		}

		public void CPEDOIELFMP()
		{
		}

		public bool EOLNOFMPMHI()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.PNBLBFIJDNN(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[1] = 'D';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "BeforeLeagueId" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "Chillingo SDK: activate offers" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.OAMEGDAMGBP(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public void CBPDLFGDOHJ()
		{
			throw new NotSupportedException();
		}

		public void FFNAPBHOACE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public bool AGMKAADLHLE()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[1];
					array[1] = '#';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "game-elite-debuff1" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "Gold" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.OAMEGDAMGBP(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		public bool NAMPBIHOFGI()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[0] = 'F';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "ID_SCHEDULEDMAINTENANCEOFSERVER" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "Display notifications" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.LJPFCAAEOPN(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		public void MOJGMBNBGHH()
		{
		}

		public void FJOIBBIGBJC()
		{
		}

		public void EEHBKGPLIJN()
		{
		}

		public void LPKDPNHBLGJ()
		{
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public void ELAJECMEMNC()
		{
			throw new NotSupportedException();
		}

		public bool JICHKPANPEE()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.PNBLBFIJDNN(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string text = BJGCPDNMHDH.IIMFFAADKCM.Split('\ufff9')[0];
					string text2 = "Area" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "extraVip" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.LJPFCAAEOPN(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		public bool FADACBKMFGG()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.GDKFPFBPIJM(BJGCPDNMHDH.HFNAMMBPJAJ().EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[1] = 'ￊ';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "special" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "{0}%" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.ReloadMaterials(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public bool JPAOKNLNFCB()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[1];
					array[1] = '\u000e';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "Total_Assignment_Issued" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "\n" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.FHMCPGJNAIC(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return false;
		}

		public void IDCJDJMGKFG()
		{
		}

		public void NPIDJAPKFLN()
		{
		}

		public bool AIFKBHCOIKG()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.PNBLBFIJDNN(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[1];
					array[1] = 'ﾴ';
					string text = iIMFFAADKCM.Split(array)[0];
					string text2 = "Awaiting players - Player was removed from awaiting members." + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "guestPassword" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.JCGGODPPHCO(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public bool AKHEIOMMAJL()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				Singleton<SoundsManager3D>.instance.UseSound(BJGCPDNMHDH.weapon.EGNEIDMAEKA);
				if (BJGCPDNMHDH.MHBCAAJBDLO == null)
				{
					string iIMFFAADKCM = BJGCPDNMHDH.IIMFFAADKCM;
					char[] array = new char[0];
					array[0] = '￠';
					string text = iIMFFAADKCM.Split(array)[1];
					string text2 = "Setting squad icon: {0}" + BJGCPDNMHDH.IMMNMGDBOOD;
					GameObject value = null;
					if (!KBBPGFFNEFM.TryGetValue(text, out value))
					{
						string path = text2 + "squad" + text;
						value = Resources.Load<GameObject>(path);
						if (value != null)
						{
							KBBPGFFNEFM[text] = value;
						}
					}
					if (value != null)
					{
						Quaternion localRotation = value.transform.localRotation;
						Vector3 localPosition = value.transform.localPosition;
						Vector3 localScale = value.transform.localScale;
						BJGCPDNMHDH.MHBCAAJBDLO = UnityEngine.Object.Instantiate(value);
						BJGCPDNMHDH.MHBCAAJBDLO.transform.parent = BJGCPDNMHDH.transform;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localRotation = localRotation;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localScale = localScale;
						BJGCPDNMHDH.MHBCAAJBDLO.transform.localPosition = localPosition;
					}
				}
				else if (BJGCPDNMHDH.MHBCAAJBDLO != null)
				{
					EnemyLeveledWeapon.FHMCPGJNAIC(BJGCPDNMHDH.MHBCAAJBDLO);
				}
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
		}

		public void HNBFJFDLABI()
		{
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}
	}

	[FormerlySerializedAs("LMBBOKMEPGI")]
	public string IMMNMGDBOOD;

	[FormerlySerializedAs("AMDHJAEJJGP")]
	public string IIMFFAADKCM;

	[FormerlySerializedAs("MHJDIIAIFMJ")]
	public CameraPlayerFollow.ThirdPersoncameraDefinition DFJLLCGEPGH;

	[FormerlySerializedAs("EMBGJHLOFEA")]
	public float KGEKIGAOKFD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlayerController _003CPPHPMJNFBDM_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CGEIKMCJBAKF_003Ek__BackingField;

	[FormerlySerializedAs("GMFMKLNJGLP")]
	public bool KLBAKPENKMM;

	protected GameObject MHBCAAJBDLO;

	private static Dictionary<string, GameObject> KBBPGFFNEFM = new Dictionary<string, GameObject>();

	private Weapon MDAJJIAMDGH;

	private bool IGOIANFGHGN;

	private PlayerInventory.InventorySlot FJPOKMGJCKF;

	[FormerlySerializedAs("HFJKJDPBHDM")]
	public string FPFCCDCGEHC;

	private WeaponLevelsSetup MIIJNHKBAEA;

	public PlayerController playerController
	{
		[CompilerGenerated]
		get
		{
			if ((object)_003CPPHPMJNFBDM_003Ek__BackingField == null)
			{
				_003CPPHPMJNFBDM_003Ek__BackingField = GetComponentInParent<PlayerController>();
			}
			return _003CPPHPMJNFBDM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CPPHPMJNFBDM_003Ek__BackingField = value;
		}
	}

	public bool isEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CGEIKMCJBAKF_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CGEIKMCJBAKF_003Ek__BackingField = value;
		}
	}

	public virtual bool isActiveWeapon
	{
		get
		{
			return IGOIANFGHGN;
		}
		set
		{
			IGOIANFGHGN = value;
			if (value)
			{
				playerController.soldierAnimator.SetWeaponType(weapon.BEACDIILBEG);
			}
		}
	}

	public Weapon weapon
	{
		get
		{
			if (MDAJJIAMDGH == null)
			{
				MDAJJIAMDGH = GetComponent<Weapon>();
			}
			return MDAJJIAMDGH;
		}
		set
		{
			MDAJJIAMDGH = value;
		}
	}

	public bool ignoreTimeScale
	{
		get
		{
			return weapon.ignoreTimeScale;
		}
		set
		{
			weapon.ignoreTimeScale = value;
		}
	}

	public WeaponLevelsSetup weaponLevelSetup
	{
		get
		{
			return MIIJNHKBAEA;
		}
		set
		{
			MIIJNHKBAEA = value;
			weapon.playerWeapon = this;
		}
	}

	public virtual void ShootForBot(Vector3 MPHCNMDIPAI)
	{
	}

	public virtual void UpdateWeapon()
	{
	}

	public virtual void MFGIHHMKGLA(Vector3 MPHCNMDIPAI)
	{
	}

	public void IAMMOGENHAD()
	{
		UnityEngine.Object.Destroy(MHBCAAJBDLO);
		MHBCAAJBDLO = null;
	}

	[SpecialName]
	public bool MIJFCJGLOGB()
	{
		return HFNAMMBPJAJ().ignoreTimeScale;
	}

	[DebuggerHidden]
	public IEnumerator LoadWeapon()
	{
		FDFGELLNDDD fDFGELLNDDD = new FDFGELLNDDD();
		fDFGELLNDDD.BJGCPDNMHDH = this;
		return fDFGELLNDDD;
	}

	protected void EIOLCOEACLN()
	{
		if (playerController.isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.ShootShake();
		}
	}

	[SpecialName]
	public Weapon HFNAMMBPJAJ()
	{
		if (MDAJJIAMDGH == null)
		{
			MDAJJIAMDGH = GetComponent<Weapon>();
		}
		return MDAJJIAMDGH;
	}

	[SpecialName]
	public void EHFBEDPNHNH(Weapon IDEBKDPMPGM)
	{
		MDAJJIAMDGH = IDEBKDPMPGM;
	}

	public virtual void ELDLIOIOMEK()
	{
	}

	protected void IHHGONCBBFI(Vector3 GCHPGKFPLGG)
	{
		if (playerController.isCurrentPlayer && Singleton<GameController>.instance.gameIsRunning)
		{
			GuiScreenSingle<HudScreen>.instance.PlayTouchCircleSmall(GCHPGKFPLGG);
		}
	}

	[SpecialName]
	public WeaponLevelsSetup AHIDNLGBAJP()
	{
		return MIIJNHKBAEA;
	}

	public virtual void MJNGGEJFMNF()
	{
	}

	protected void GEGFAHHIIPI()
	{
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.ShootShake();
		}
	}

	protected bool OOOJCFNEPIK(Vector3 MDOPFNNFLFB)
	{
		return Vector3.Angle(playerController.aimForward, MDOPFNNFLFB - playerController.transform.position) < 68f || !playerController.isCurrentPlayer;
	}

	[SpecialName]
	public virtual void IJNFCDPPENM(bool IDEBKDPMPGM)
	{
		IGOIANFGHGN = IDEBKDPMPGM;
		if (IDEBKDPMPGM)
		{
			playerController.GFCDMMGDFJK().SetWeaponType(HFNAMMBPJAJ().BEACDIILBEG);
		}
	}

	public virtual void AKGFAMMBHJD()
	{
	}

	public void GNLLHJIICFL()
	{
		UnityEngine.Object.Destroy(MHBCAAJBDLO);
		MHBCAAJBDLO = null;
	}

	[SpecialName]
	public void CAFCNECCIPB(WeaponLevelsSetup IDEBKDPMPGM)
	{
		MIIJNHKBAEA = IDEBKDPMPGM;
		weapon.playerWeapon = this;
	}

	[SpecialName]
	public bool IEODIONECDD()
	{
		return _003CGEIKMCJBAKF_003Ek__BackingField;
	}

	[SpecialName]
	public virtual void FHKGABMHOHI(bool IDEBKDPMPGM)
	{
		IGOIANFGHGN = IDEBKDPMPGM;
		if (IDEBKDPMPGM)
		{
			playerController.soldierAnimator.SetWeaponType(weapon.BEACDIILBEG);
		}
	}

	[SpecialName]
	public void FKLHCAEKKKP(WeaponLevelsSetup IDEBKDPMPGM)
	{
		MIIJNHKBAEA = IDEBKDPMPGM;
		HFNAMMBPJAJ().playerWeapon = this;
	}

	public bool IsLoaded()
	{
		return MHBCAAJBDLO != null;
	}

	public IEnumerator LGKMEHJBHKN()
	{
		FDFGELLNDDD fDFGELLNDDD = new FDFGELLNDDD();
		fDFGELLNDDD.BJGCPDNMHDH = this;
		return fDFGELLNDDD;
	}

	[SpecialName]
	public void FMAMBKLFDKH(bool IDEBKDPMPGM)
	{
		weapon.ignoreTimeScale = IDEBKDPMPGM;
	}

	public IEnumerator DLCGNAGKOOB()
	{
		FDFGELLNDDD fDFGELLNDDD = new FDFGELLNDDD();
		fDFGELLNDDD.BJGCPDNMHDH = this;
		return fDFGELLNDDD;
	}

	public virtual void DKBGLKHGMFE()
	{
	}

	public virtual void EGCKJGBGFJB()
	{
	}

	public virtual void ANCEHNGCFHI(Vector3 MPHCNMDIPAI)
	{
	}

	protected bool KPBILMGEJPP(Vector3 MDOPFNNFLFB)
	{
		return !(Vector3.Angle(playerController.aimForward, MDOPFNNFLFB - playerController.transform.position) < 1086f) && playerController.isCurrentPlayer;
	}

	[SpecialName]
	public bool HKGJAOLPFDI()
	{
		return weapon.ignoreTimeScale;
	}

	[SpecialName]
	public void EFANLNFJCCH(PlayerController IDEBKDPMPGM)
	{
		_003CPPHPMJNFBDM_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void AEFMJPKANLN(Vector3 GCHPGKFPLGG)
	{
		if (GLNCDIKMDEO().isCurrentPlayer && Singleton<GameController>.instance.gameIsRunning)
		{
			GuiScreenSingle<HudScreen>.instance.COCJENMJNKK(GCHPGKFPLGG);
		}
	}

	[SpecialName]
	public void KBFNNIBHJKE(bool IDEBKDPMPGM)
	{
		HFNAMMBPJAJ().ignoreTimeScale = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool IEKFIJOBJLE()
	{
		return _003CGEIKMCJBAKF_003Ek__BackingField;
	}

	[SpecialName]
	public virtual bool BPAOCKIKDMH()
	{
		return IGOIANFGHGN;
	}

	[SpecialName]
	public void ILDLMLKHPGE(bool IDEBKDPMPGM)
	{
		HFNAMMBPJAJ().ignoreTimeScale = IDEBKDPMPGM;
	}

	protected void HICJCHBHHDJ()
	{
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.ShootShake();
		}
	}

	public IEnumerator DFPMFLKKBAD()
	{
		FDFGELLNDDD fDFGELLNDDD = new FDFGELLNDDD();
		fDFGELLNDDD.BJGCPDNMHDH = this;
		return fDFGELLNDDD;
	}

	[SpecialName]
	public bool KAEPGOHFLEL()
	{
		return _003CGEIKMCJBAKF_003Ek__BackingField;
	}

	public virtual void HIBLOLNEACO()
	{
	}

	public static void HFGHHLIDKFD()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, GameObject> item in KBBPGFFNEFM)
		{
			list.Add(item.Key);
		}
		foreach (string item2 in list)
		{
			KBBPGFFNEFM[item2] = null;
		}
		KBBPGFFNEFM.Clear();
	}

	[SpecialName]
	public virtual bool OHKDJNIADMF()
	{
		return IGOIANFGHGN;
	}

	[SpecialName]
	public void IPJLEHMHPOO(Weapon IDEBKDPMPGM)
	{
		MDAJJIAMDGH = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HAGBKIDMPFN(bool IDEBKDPMPGM)
	{
		_003CGEIKMCJBAKF_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected bool GNONBGKLKMG(Vector3 MDOPFNNFLFB)
	{
		return !(Vector3.Angle(GLNCDIKMDEO().aimForward, MDOPFNNFLFB - playerController.transform.position) < 472f) && !GLNCDIKMDEO().isCurrentPlayer;
	}

	public bool PLBOBFDIBBJ()
	{
		return MHBCAAJBDLO != null;
	}

	protected void JKFBHMDKMNL()
	{
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.ShootShake();
		}
	}

	public static void HPJHOKJMNOC()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, GameObject> item in KBBPGFFNEFM)
		{
			list.Add(item.Key);
		}
		foreach (string item2 in list)
		{
			KBBPGFFNEFM[item2] = null;
		}
		KBBPGFFNEFM.Clear();
	}

	public bool ECBIINCONOI()
	{
		return MHBCAAJBDLO != null;
	}

	protected void JJALJKEMOJF()
	{
		if (playerController.isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.ShootShake();
		}
	}

	public virtual void OPEICEBMFLF()
	{
	}

	public void GMGKDLHDHLP()
	{
		UnityEngine.Object.Destroy(MHBCAAJBDLO);
		MHBCAAJBDLO = null;
	}

	[SpecialName]
	public bool NDAMDKNIEIG()
	{
		return weapon.ignoreTimeScale;
	}

	[SpecialName]
	public void MMAMNDMIIAD(bool IDEBKDPMPGM)
	{
		_003CGEIKMCJBAKF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EBHFPEJOKMP(PlayerController IDEBKDPMPGM)
	{
		_003CPPHPMJNFBDM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool AGFAIPGIKPP()
	{
		return _003CGEIKMCJBAKF_003Ek__BackingField;
	}

	public virtual void GFPIFCCPLIP()
	{
	}

	public void HKLGAPIDHEL()
	{
		UnityEngine.Object.Destroy(MHBCAAJBDLO);
		MHBCAAJBDLO = null;
	}

	protected void AFGBNEOKEEG()
	{
		if (playerController.isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.ShootShake();
		}
	}

	public virtual void CPIOHBLIMLH()
	{
	}

	public virtual void MouseUpAndNoUpdate()
	{
	}

	protected bool CEJHOFMPNAA(Vector3 MDOPFNNFLFB)
	{
		return Vector3.Angle(playerController.aimForward, MDOPFNNFLFB - playerController.transform.position) < 95f || !playerController.isCurrentPlayer;
	}

	[SpecialName]
	public PlayerController GLNCDIKMDEO()
	{
		return _003CPPHPMJNFBDM_003Ek__BackingField;
	}

	[SpecialName]
	public virtual bool NFJFHHCLNJP()
	{
		return IGOIANFGHGN;
	}

	public void AEDHBOCFJEM()
	{
		UnityEngine.Object.Destroy(MHBCAAJBDLO);
		MHBCAAJBDLO = null;
	}

	public static void HNLFCDHGDOH()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, GameObject> item in KBBPGFFNEFM)
		{
			list.Add(item.Key);
		}
		foreach (string item2 in list)
		{
			KBBPGFFNEFM[item2] = null;
		}
		KBBPGFFNEFM.Clear();
	}

	[SpecialName]
	public void BBFJLMIHGLC(Weapon IDEBKDPMPGM)
	{
		MDAJJIAMDGH = IDEBKDPMPGM;
	}

	public virtual void BNAEGDKLBBJ()
	{
	}

	public void DestroyModel()
	{
		UnityEngine.Object.Destroy(MHBCAAJBDLO);
		MHBCAAJBDLO = null;
	}

	public static void ClearModels()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, GameObject> item in KBBPGFFNEFM)
		{
			list.Add(item.Key);
		}
		foreach (string item2 in list)
		{
			KBBPGFFNEFM[item2] = null;
		}
		KBBPGFFNEFM.Clear();
	}

	public void EIDFJKJDHBL()
	{
		UnityEngine.Object.Destroy(MHBCAAJBDLO);
		MHBCAAJBDLO = null;
	}

	[SpecialName]
	public bool OMLJGCPOJHM()
	{
		return _003CGEIKMCJBAKF_003Ek__BackingField;
	}

	protected bool KELOGHNJDDI(Vector3 MDOPFNNFLFB)
	{
		return !(Vector3.Angle(playerController.aimForward, MDOPFNNFLFB - GLNCDIKMDEO().transform.position) < 1558f) && GLNCDIKMDEO().isCurrentPlayer;
	}

	protected void MGKACCCBEFF()
	{
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.ShootShake();
		}
	}

	protected bool AOCFFBGGFCP(Vector3 MDOPFNNFLFB)
	{
		return !(Vector3.Angle(playerController.aimForward, MDOPFNNFLFB - GLNCDIKMDEO().transform.position) < 546f) && !GLNCDIKMDEO().isCurrentPlayer;
	}

	public void IBNEIKFHJML()
	{
		UnityEngine.Object.Destroy(MHBCAAJBDLO);
		MHBCAAJBDLO = null;
	}

	public virtual void MNIJGBAKEKA(Vector3 MPHCNMDIPAI)
	{
	}

	[SpecialName]
	public void PKOHOODGICC(WeaponLevelsSetup IDEBKDPMPGM)
	{
		MIIJNHKBAEA = IDEBKDPMPGM;
		weapon.playerWeapon = this;
	}

	[SpecialName]
	public void DNAMMPGOJOC(PlayerController IDEBKDPMPGM)
	{
		_003CPPHPMJNFBDM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public WeaponLevelsSetup MKEBHAJCGIM()
	{
		return MIIJNHKBAEA;
	}

	[SpecialName]
	public bool CJKKFEMKFEN()
	{
		return weapon.ignoreTimeScale;
	}

	[SpecialName]
	public bool FOMEMICHEBC()
	{
		return _003CGEIKMCJBAKF_003Ek__BackingField;
	}
}
