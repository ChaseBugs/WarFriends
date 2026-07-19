using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class CardManager : DatabaseSerializedObjectGeneric<CardManager.CardManagerData>, GDCLLGDCODD
{
	public enum CardType
	{
		Bronze = 1,
		Silver = 2,
		Gold = 3,
		Buddy = 4
	}

	[Flags]
	[JsonConverter(typeof(StringEnumConverter))]
	public enum CardFilter
	{
		None = 0,
		Bronze = 1,
		Silver = 2,
		Gold = 4,
		Buddy = 8,
		Preselected = 0x10,
		Random = 0x20,
		All = 0xFFFFFF
	}

	public class CardData
	{
		public int amount;
	}

	[Serializable]
	public class BuddyCardData
	{
		public int amount;

		public string buddyName;

		public Dictionary<int, CamosManager.SavedPlayerVisualSlot> equippedVisuals;

		public LevelBehaviour.UnitType unityType;

		public int primaryWeapon;

		public int secondaryWeapon;

		public int armypower;

		public int level;
	}

	public class CardManagerData
	{
		public Dictionary<string, CardData> cardData = new Dictionary<string, CardData>();

		public Dictionary<string, BuddyCardData> buddyCardData = new Dictionary<string, BuddyCardData>();

		public int nextWithdraw;

		public int nextBuddyDeposit;

		public bool extraSlot;

		public int GetCardAmount()
		{
			if (cardData == null)
			{
				return 0;
			}
			int num = 0;
			foreach (KeyValuePair<string, CardData> cardDatum in cardData)
			{
				num += cardDatum.Value.amount;
			}
			return num;
		}
	}

	private sealed class PKPKHMGJCHF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal string AAOAKDPIEII;

		internal string[] EMGLPCIGMPO;

		internal bool NFIJPDAMBEL;

		internal string[] KFCAECGLKKO;

		internal int GHCPBBJDIBB;

		internal string FMGAAIEMDBE;

		internal bool CAPGLFMCEDK;

		internal Card PMOFBEFEGMO;

		internal CardManager BJGCPDNMHDH;

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
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
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
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[1] = 'ￊ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[2];
				array2[1] = "ID_GUI_UNLOCKEDAT";
				array2[1] = AAOAKDPIEII;
				array2[5] = "{0}\u00a0{1}";
				array2[1] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[1];
				array[1] = 'ﾫ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[2];
				array2[0] = "ID_CONFIRM_STARTTUTORIAL";
				array2[0] = AAOAKDPIEII;
				array2[4] = "Turret";
				array2[0] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[1] = '\ufff8';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[2];
				array2[0] = "iterator";
				array2[1] = AAOAKDPIEII;
				array2[6] = "dailyRewardData";
				array2[1] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[1];
				array[1] = '_';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[4];
				array2[0] = "[^\\d]";
				array2[0] = AAOAKDPIEII;
				array2[8] = "PlayerLevel";
				array2[0] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[1];
				array[1] = '\u0016';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[7];
				array2[0] = ". Correcting...";
				array2[0] = AAOAKDPIEII;
				array2[5] = "ID_GUI_BRONZE";
				array2[4] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public bool JPAOKNLNFCB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[0] = '1';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[4];
				array2[0] = "SquadId";
				array2[1] = AAOAKDPIEII;
				array2[2] = "currentMode: ";
				array2[1] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				EMGLPCIGMPO = AAOAKDPIEII.Split('ﾥ');
				object[] array = new object[8];
				array[0] = "ID_GUI_TIMEXPBONUS";
				array[0] = AAOAKDPIEII;
				array[6] = "\n";
				array[2] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void EHMOLOCPIGB()
		{
			throw new NotSupportedException();
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public PKPKHMGJCHF()
		{
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				EMGLPCIGMPO = AAOAKDPIEII.Split('ￆ');
				object[] array = new object[8];
				array[1] = "DailyMission";
				array[0] = AAOAKDPIEII;
				array[3] = "Name";
				array[3] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				EMGLPCIGMPO = AAOAKDPIEII.Split(';');
				UnityEngine.Debug.Log(string.Format("Init cards : " + AAOAKDPIEII + " is Opponent: " + NFIJPDAMBEL));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				EMGLPCIGMPO = AAOAKDPIEII.Split('\ufffe');
				object[] array = new object[7];
				array[0] = "RETRY";
				array[0] = AAOAKDPIEII;
				array[0] = "'ID'0";
				array[8] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FCFHLDPLIDC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[1] = 'D';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[2];
				array2[0] = "SetLabelDynamic - Done";
				array2[0] = AAOAKDPIEII;
				array2[6] = "smallURL";
				array2[2] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[0] = '\f';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[8];
				array2[1] = "Null photon view in PhotonLevelIDChanger";
				array2[0] = AAOAKDPIEII;
				array2[4] = "MegaReward";
				array2[8] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[1] = 'ﾶ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[0];
				array2[1] = "ID_WARCARDREADY";
				array2[0] = AAOAKDPIEII;
				array2[5] = "Cards_Buddy_Chosen";
				array2[3] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[0] = 'ﾖ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[5];
				array2[1] = "Recording: CheckModel version {0}";
				array2[0] = AAOAKDPIEII;
				array2[8] = "Application paused";
				array2[2] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[1];
				array[1] = 'ﾡ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[0];
				array2[0] = "globalSquadLeaderboard";
				array2[1] = AAOAKDPIEII;
				array2[7] = "ID_WARNING_INCORRECTELITEPARTSAMOUNT";
				array2[7] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[1];
				array[1] = 'ￜ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[8];
				array2[1] = "menu-army-cat-shooter";
				array2[0] = AAOAKDPIEII;
				array2[7] = "MessageId";
				array2[1] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[1] = 'ﾻ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[6];
				array2[1] = "ID_ARENARULES_EARLYOVERTIME";
				array2[0] = AAOAKDPIEII;
				array2[6] = "discount";
				array2[2] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[0] = 'ﾢ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[8];
				array2[0] = "YES";
				array2[1] = AAOAKDPIEII;
				array2[5] = "ID_WARNING_OFFEREXPIRED_TEXT";
				array2[3] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[1];
				array[1] = 'ￏ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[7];
				array2[0] = "weapon0";
				array2[1] = AAOAKDPIEII;
				array2[4] = "()Landroid/app/PendingIntent;";
				array2[3] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				EMGLPCIGMPO = AAOAKDPIEII.Split('\u0003');
				object[] array = new object[7];
				array[1] = "N";
				array[0] = AAOAKDPIEII;
				array[0] = "Loss";
				array[7] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[1];
				array[1] = 'i';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[5];
				array2[1] = "ID_WARNING_ARENADOESNTEXIST";
				array2[0] = AAOAKDPIEII;
				array2[0] = "ID_SECONDS";
				array2[2] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[1];
				array[1] = 'L';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[1];
				array2[0] = "Icon";
				array2[0] = AAOAKDPIEII;
				array2[4] = "Player_Waited_Till_Delivery_Ends";
				array2[0] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				EMGLPCIGMPO = AAOAKDPIEII.Split('ￓ');
				object[] array = new object[1];
				array[1] = "DogtagsRefillRankUp";
				array[1] = AAOAKDPIEII;
				array[6] = "No main position was set in map definition";
				array[1] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 0;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				EMGLPCIGMPO = AAOAKDPIEII.Split('\ufff6');
				object[] array = new object[5];
				array[0] = "ID_OPPONENTWASDISCONNECTED";
				array[0] = AAOAKDPIEII;
				array[7] = "Sniper_Tutorial_Duration";
				array[1] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				EMGLPCIGMPO = AAOAKDPIEII.Split('ﾗ');
				object[] array = new object[4];
				array[1] = "$20-$50";
				array[1] = AAOAKDPIEII;
				array[6] = "ID_CONFIRM_ERROR";
				array[2] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array)));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB += 0;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IOBGNBBJOLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				string aAOAKDPIEII = AAOAKDPIEII;
				char[] array = new char[0];
				array[0] = 'ﾨ';
				EMGLPCIGMPO = aAOAKDPIEII.Split(array);
				object[] array2 = new object[5];
				array2[1] = "ID_ACTIVATEINSTEADOF";
				array2[1] = AAOAKDPIEII;
				array2[8] = "{0}{1}[-] / {2}";
				array2[8] = NFIJPDAMBEL;
				UnityEngine.Debug.Log(string.Format(string.Concat(array2), new object[1]));
				KFCAECGLKKO = EMGLPCIGMPO;
				GHCPBBJDIBB = 1;
				goto IL_012c;
			}
			case 1u:
				GHCPBBJDIBB++;
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				if (GHCPBBJDIBB < KFCAECGLKKO.Length)
				{
					FMGAAIEMDBE = KFCAECGLKKO[GHCPBBJDIBB];
					if (!string.IsNullOrEmpty(FMGAAIEMDBE))
					{
						PMOFBEFEGMO = BJGCPDNMHDH.GetCardInstance(FMGAAIEMDBE, CAPGLFMCEDK);
						if (PMOFBEFEGMO != null)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PMOFBEFEGMO.InitCard(NFIJPDAMBEL));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							break;
						}
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}
	}

	private sealed class NFPDIHGDBGG
	{
		internal CardBuddy EPPKMFBEJHM;

		internal bool POGDLLFCOKO(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool EGJBKFPHCNF(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool CMCIGAFHIJL(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool MMEEJDGGAID(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool DJLGPGPAHCD(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool FDKMOFHAEFN(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool LKKLABBEOAG(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool AMIJFGBOCLC(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool ABNGKEJNLJO(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool DGELDDJAEEF(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool ILNPANOCHIH(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool NNFHNIMCBLH(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool NCLMPCCHDAM(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool KLJNEGDLOMG(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool CMDLGJKIBLL(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool MCFGAFBEJDK(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool BDCAFHOHEGM(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool ECPMEMNKMCB(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool INFLOOLPOBK(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool OFJDLANHAMD(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool LGJCNCHBFDA(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool GGJDILDIFPJ(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool PANKBNOCEAM(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool CIFEDFPPPOK(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool CFDNMILGDLG(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool PHGDBIEENCB(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool BBPKDMPNEDG(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool MFCNOIDCJME(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool JEDCBCPMJGI(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool FHDOHCJJEMM(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool LHPPLGOOLEC(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool BMCMDMKGHHO(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool GMFJFMHNDMC(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool PCKMJMGLPDG(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool LJCDGJKCNEC(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool CHDOECNGOPM(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool ADEFLNOHDAK(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool ALIBBKEHCFC(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool MPHECHCFCAN(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}

		internal bool CJIBPJPJLNB(string ICDKHLOBKIE)
		{
			return ICDKHLOBKIE == EPPKMFBEJHM.id;
		}
	}

	[Header("List for References to Cards in Scene")]
	public List<Card> cards;

	public List<Card> obtainedCards = new List<Card>();

	public List<Card> enemyCards = new List<Card>();

	public List<Card> cardUsedByMe = new List<Card>();

	[SerializeField]
	private CardBuddy mCardBuddyPrefab;

	private List<CardBuddy> mBuddyCards = new List<CardBuddy>();

	private List<CardBuddy> mBuddyCardsSquad = new List<CardBuddy>();

	private Transform mSquadCardsParent;

	private Dictionary<string, Card> mCardDictionary = new Dictionary<string, Card>();

	[HideInInspector]
	public List<Card> cardsByRarity = new List<Card>();

	public static int LowLevelTreshold = 7;

	public static int HighLevelTreshold = 10;

	private static CardManager mInstance;

	public CardDefinitions cardDefinitions;

	private PhotonView mPhotonView;

	private float mCooldown = 5f;

	private float mNextTime;

	private Dictionary<CardType, List<Card>> mCardsByQuality;

	private Dictionary<string, Card> mOtherPlayerCards = new Dictionary<string, Card>();

	private List<Card> mUsedCards = new List<Card>();

	private bool mCardUseInProgress;

	private string mIdLastGainedCard;

	private List<CardBuddy> mOtherBuddyCards;

	private CardBuddy mBuddyCard;

	public List<Card> cardsForGame
	{
		get
		{
			return Singleton<GameController>.instance.mainController.cardsForGame;
		}
	}

	public Card withdrawingCard { get; set; }

	public bool canUseCards
	{
		get
		{
			return Singleton<GameController>.instance.mainController.canDeployUnits;
		}
	}

	public int cardsInPack
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CardsInPack).FLOATVALUE;
		}
	}

	public int bronzePackBronzeCards
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackBronzeCards).FLOATVALUE;
		}
	}

	public CardType bronzePackMin
	{
		get
		{
			return CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackGuaranteedCardsType).FLOATVALUE);
		}
	}

	public CardType bronzePackMax
	{
		get
		{
			return CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).FLOATVALUE);
		}
	}

	public int silverPackSilverCards
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackSilverCards).FLOATVALUE;
		}
	}

	public CardType silverPackMin
	{
		get
		{
			return CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackGuaranteedCardsType).FLOATVALUE);
		}
	}

	public CardType silverPackMax
	{
		get
		{
			return CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackMaxRarityCardsType).FLOATVALUE);
		}
	}

	public int goldPackGoldCards
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldPackGoldCards).FLOATVALUE;
		}
	}

	public CardType goldPackMin
	{
		get
		{
			return CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldPackGuaranteedCardsType).FLOATVALUE);
		}
	}

	public CardType goldPackMax
	{
		get
		{
			return CardRarityConverter((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldPackMaxRarityCardsType).FLOATVALUE);
		}
	}

	public int nextWithdraw
	{
		get
		{
			return data.nextWithdraw;
		}
		set
		{
			data.nextWithdraw = value;
			if (this.WithdrawTimeChanged != null)
			{
				this.WithdrawTimeChanged();
			}
		}
	}

	public int nextBuddyDeposit
	{
		get
		{
			return data.nextBuddyDeposit;
		}
		set
		{
			data.nextBuddyDeposit = value;
		}
	}

	public bool isWithdrawAvailable
	{
		get
		{
			return nextWithdraw <= Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}

	public bool isBuddyDepositAvailable
	{
		get
		{
			return nextBuddyDeposit <= Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}

	public bool extraSlot
	{
		get
		{
			return data.extraSlot;
		}
	}

	public static CardManager instance
	{
		get
		{
			mInstance = mInstance ?? ((CardManager)UnityEngine.Object.FindObjectsOfType(typeof(CardManager))[0]);
			return mInstance;
		}
	}

	public PlayerWeapon grenadeSaved { get; set; }

	public PlayerWeapon savedWeapon { get; set; }

	public float timeLockWeaponSwitch { get; set; }

	public Card CurrentCard
	{
		get
		{
			return (cardsForGame.Count <= 0) ? null : cardsForGame[0];
		}
	}

	public bool NoMoreCards
	{
		get
		{
			return cardsForGame.Count == 0;
		}
	}

	public float Progress
	{
		get
		{
			if (mCardUseInProgress)
			{
				return 1f;
			}
			if (mNextTime == 0f || mCooldown == 0f)
			{
				return 0f;
			}
			return Mathf.Clamp01((mNextTime - TimeManager.realTimeWithoutPauses) / mCooldown);
		}
	}

	public CardBuddy buddyCard
	{
		get
		{
			return mBuddyCard;
		}
		private set
		{
			mBuddyCard = value;
		}
	}

	public static float availableLengthInSmallCard
	{
		get
		{
			return 154f;
		}
	}

	public string selectedCards
	{
		get
		{
			string text = string.Empty;
			foreach (Card item in cardsForGame)
			{
				text = text + item.id + ";";
			}
			return text.TrimEnd(';');
		}
	}

	public List<Tuple<string, BuddyCardData>> selectedBuddyCards
	{
		get
		{
			List<Tuple<string, BuddyCardData>> list = new List<Tuple<string, BuddyCardData>>();
			foreach (Card item in cardsForGame)
			{
				if (item is CardBuddy)
				{
					list.Add(new Tuple<string, BuddyCardData>(item.id, ((CardBuddy)item).buddyCardData));
				}
			}
			return list;
		}
	}

	public Dictionary<CardType, List<Card>> cardsByQuality
	{
		get
		{
			return mCardsByQuality;
		}
		set
		{
			mCardsByQuality = value;
		}
	}

	public event Action<Card, GHPGNELIDBM, bool> CardUsed;

	public event Action<bool> OnSyncWithServer;

	public event Action ErrorHappened;

	public event Action<Card> OnCardGainedInGame;

	public event Action CardPackBought;

	public event Action WithdrawTimeChanged;

	public CardManager()
	{
		timeLockWeaponSwitch = 0f;
	}

	public static CardFilter GetFilter(CardType cardType)
	{
		return (CardFilter)Math.Pow(2.0, (double)(cardType - 1));
	}

	public Card GetCardInstanceAll(string cardId, bool isCurrentPlayer = true)
	{
		if (mCardDictionary.ContainsKey(cardId))
		{
			return mCardDictionary[cardId];
		}
		if (mOtherPlayerCards.ContainsKey(cardId))
		{
			return mOtherPlayerCards[cardId];
		}
		string message = string.Format("Card ID \"{0}\" is not pressent in card dictionary.", cardId);
		UnityEngine.Debug.LogError(message);
		Exception exception = new Exception(message);
		AnalyticsHelper.LogHandledException(exception);
		return null;
	}

	public Card GetCardInstance(string cardId, bool isCurrentPlayer = true)
	{
		if (isCurrentPlayer)
		{
			if (mCardDictionary.ContainsKey(cardId))
			{
				return mCardDictionary[cardId];
			}
		}
		else if (mOtherPlayerCards.ContainsKey(cardId))
		{
			return mOtherPlayerCards[cardId];
		}
		string message = string.Format("Card ID \"{0}\" is not pressent in card dictionary.", cardId);
		UnityEngine.Debug.LogError(message);
		Exception exception = new Exception(message);
		AnalyticsHelper.LogHandledException(exception);
		return null;
	}

	public bool IsCardId(string cardId)
	{
		return mCardDictionary.ContainsKey(cardId);
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		cardDefinitions = GetComponent<CardDefinitions>();
		if (!Application.isPlaying)
		{
			return;
		}
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
		GameLoginManager.instance.PlayerLogOut += delegate
		{
			cardsForGame.Clear();
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (action == DatabaseAction.AddFacebook || action == DatabaseAction.SwitchToFacebook)
			{
				cardsForGame.Clear();
			}
		};
		mPhotonView = GetComponent<PhotonView>();
		InitCards();
		mInstance = this;
	}

	public bool CardsForGameContains(Card card)
	{
		if (cardsForGame == null || card == null)
		{
			return false;
		}
		for (int i = 0; i < cardsForGame.Count; i++)
		{
			if (cardsForGame[i].id == card.id)
			{
				return true;
			}
		}
		return false;
	}

	private int GetRandomRarity(CardType guaranteedRarity = CardType.Bronze, CardType maxRarity = CardType.Gold)
	{
		float min = 0f;
		float max = 1f;
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(LowLevelTreshold, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverCardRarityEarly).FLOATVALUE, HighLevelTreshold, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverCardRarity).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(LowLevelTreshold, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCardRarityEarly).FLOATVALUE, HighLevelTreshold, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCardRarity).FLOATVALUE);
		if (guaranteedRarity == CardType.Silver)
		{
			min = num;
		}
		if (guaranteedRarity == CardType.Gold)
		{
			min = num2;
		}
		if (maxRarity == CardType.Bronze)
		{
			max = num;
		}
		if (maxRarity == CardType.Silver)
		{
			max = num2;
		}
		float num3 = UnityEngine.Random.Range(min, max);
		if (num2 <= num3)
		{
			return 3;
		}
		return (!(num <= num3)) ? 1 : 2;
	}

	public Card AddRandomCard(CardType guaranteedRarity = CardType.Bronze, CardType maxRarity = CardType.Gold)
	{
		int randomRarity = GetRandomRarity(guaranteedRarity, maxRarity);
		int count = mCardsByQuality[(CardType)randomRarity].Count;
		Card card = mCardsByQuality[(CardType)randomRarity][UnityEngine.Random.Range(0, count)];
		mIdLastGainedCard = card.id;
		UnityEngine.Debug.Log(string.Format("Add RANDOM warcard - min {0} max {1} - {2} {3}", guaranteedRarity, maxRarity, card.rarity, card.cardName));
		card.AddCard();
		return card;
	}

	public Card AddRarityCard(CardType rarity)
	{
		int count = mCardsByQuality[rarity].Count;
		Card card = mCardsByQuality[rarity][UnityEngine.Random.Range(0, count)];
		mIdLastGainedCard = card.id;
		card.AddCard();
		UnityEngine.Debug.Log(string.Format("Add RARITY {0} warcard - {1}", rarity, card.cardName));
		return card;
	}

	public Card AddRandomCardDuringGame()
	{
		Card card = AddRandomCard();
		obtainedCards.Add(card);
		return card;
	}

	public void CardWasUsed(Card card, GHPGNELIDBM fraction)
	{
		if (fraction == PlayerController.OGMBJPKOPCB.fraction && mCardUseInProgress)
		{
			mNextTime = TimeManager.realTimeWithoutPauses + mCooldown;
			mCardUseInProgress = false;
		}
		if (this.CardUsed != null)
		{
			this.CardUsed(card, fraction, fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
		mPhotonView.RPC("CardWasUsedOnline", PhotonTargets.Others, card.id, (byte)fraction, card.playerId);
	}

	public void LoadData(JToken cardData)
	{
		LoadData((string)cardData);
	}

	public void LoadData(string cardData)
	{
		SerializedObject = JsonConvert.DeserializeObject<CardManagerData>(cardData);
		if (this.OnSyncWithServer != null)
		{
			this.OnSyncWithServer(true);
		}
		this.OnSyncWithServer = null;
	}

	public void ShowCardBotPlayed(Card card, GHPGNELIDBM fraction)
	{
		if (this.CardUsed != null)
		{
			this.CardUsed(card, fraction, false);
		}
		enemyCards.Add(card);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.EnemyCardPlayed);
	}

	internal void AddMultipleCards(string cardId, int num)
	{
		UnityEngine.Debug.Log(string.Format("CardManager: Added {0}x card {1}", num, cardId));
		if (mCardDictionary.ContainsKey(cardId))
		{
			Card card = mCardDictionary[cardId];
			card.AddCard(num);
		}
		else
		{
			UnityEngine.Debug.LogError(string.Format("failed add card {0} - not exit?", cardId));
		}
	}

	internal Card AddCard(string cardId)
	{
		UnityEngine.Debug.Log("CardManager: Added card " + cardId);
		Card card = mCardDictionary[cardId];
		card.AddCard();
		return card;
	}

	public void UseCard(Card card)
	{
		if (!mCardUseInProgress && !NoMoreCards && !(Progress > 0f) && CardsForGameContains(card))
		{
			mCardUseInProgress = true;
			mCooldown = card.cooldown;
			card.playerId = PhotonNetwork.player.ID;
			mPhotonView.RPC("PlayCardRPC", PhotonTargets.Others, card.id, (byte)PlayerController.OGMBJPKOPCB.fraction, PhotonNetwork.player.ID);
			card.UseCard(this, PlayerController.OGMBJPKOPCB.fraction);
			if (Singleton<GameController>.instance.mainController.cardsFilter != CardFilter.Preselected && Singleton<GameController>.instance.mainController.cardsFilter != CardFilter.Random)
			{
				card.RemoveCard();
				BattleRewardsManager.instance.ConsumeWarcardInMatch(card.id);
				mUsedCards.Add(card);
			}
			StatsManager.instance.matchStats.PlayCard(card);
			if (PhotonNetwork.offlineMode)
			{
				card.UseCardOnline(this, PlayerController.OGMBJPKOPCB.fraction);
			}
			cardUsedByMe.Add(card);
			cardsForGame.Remove(card);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardPlayed);
		}
	}

	public Card[] BuyThreeCards(int warbucks)
	{
		string text = NGNPIOOAHEH.ThreeCards.ToString();
		Card[] array = new Card[3];
		string[] array2 = new string[3];
		for (int i = 0; i < 3; i++)
		{
			array[i] = AddRandomCard();
			array2[i] = array[i].id;
		}
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary["cards"] = array2;
		dictionary["cardPack"] = Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.THREE_CARDS).NAME;
		string objData = JsonConvert.SerializeObject(dictionary);
		requestBuffer.AddRequest(DatabaseAction.BuyCardPack, objData, warbucks, 0, text);
		string text2 = string.Empty;
		Card[] array3 = array;
		foreach (Card card in array3)
		{
			string text3 = text2;
			text2 = text3 + "\n\t" + card.rarity.ToString() + " " + card.cardName;
		}
		UnityEngine.Debug.Log("BUYING CARD PACK " + text + text2);
		GuiScreenSingle<CardSelectionScreen>.instance.UpdateHeaderAndCards();
		return array;
	}

	internal int[] GetRarityCounts()
	{
		int[] array = new int[3];
		for (int i = 0; i < 3; i++)
		{
			List<Card> list = mCardsByQuality[(CardType)(i + 1)];
			foreach (Card item in list)
			{
				array[i] += item.amount;
			}
			UnityEngine.Debug.Log("Rarity " + i + " = " + array[i]);
		}
		return array;
	}

	public int GetWarcardsCount(CardType rarity)
	{
		int num = 0;
		List<Card> list = mCardsByQuality[rarity];
		if (list == null)
		{
			return 0;
		}
		for (int i = 0; i < list.Count; i++)
		{
			num += list[i].amount;
		}
		return num;
	}

	internal Card[] BuyCardPack(NGNPIOOAHEH cardTypePack, int warbucks, int gold, int discount)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy);
		string text = cardTypePack.ToString().ToUpper();
		string nAME = Singleton<GameVariables>.instance.GetCardPackRow(cardTypePack).NAME;
		int num;
		switch (cardTypePack)
		{
		case NGNPIOOAHEH.Gold:
			num = 3;
			break;
		case NGNPIOOAHEH.Silver:
			num = 2;
			break;
		default:
			num = 1;
			break;
		}
		CardType typeCardpack = (CardType)num;
		Card[] cardsFromCardpack = GetCardsFromCardpack(typeCardpack);
		string[] array = new string[cardsFromCardpack.Length];
		switch (cardTypePack)
		{
		case NGNPIOOAHEH.Bronze:
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseCardPack1);
			break;
		case NGNPIOOAHEH.Silver:
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseCardPack2);
			break;
		case NGNPIOOAHEH.Gold:
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseCardPack3);
			break;
		}
		string text2 = string.Format("BUYING CARD PACK: type:{0} -> cardType:{1}", text, typeCardpack.ToString());
		for (int i = 0; i < cardsFromCardpack.Length; i++)
		{
			array[i] = cardsFromCardpack[i].id;
			text2 += string.Format("\n\t{0} {1}", cardsFromCardpack[i].rarity.ToString(), cardsFromCardpack[i].cardName);
		}
		UnityEngine.Debug.Log(text2);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary["cards"] = array;
		dictionary["cardPack"] = nAME;
		dictionary["discount"] = discount;
		dictionary["StartTime"] = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		string objData = JsonConvert.SerializeObject(dictionary);
		requestBuffer.AddRequest(DatabaseAction.BuyCardPack, objData, warbucks, gold, text);
		return cardsFromCardpack;
	}

	public void CardPackBoughtEvent()
	{
		if (this.CardPackBought != null)
		{
			this.CardPackBought();
		}
	}

	public Card[] GetCardsFromCardpack(CardType typeCardpack)
	{
		int num = cardsInPack;
		CardType rarity = typeCardpack;
		int num2 = 5;
		CardType guaranteedRarity = CardType.Bronze;
		CardType maxRarity = CardType.Gold;
		CardPacks cardPacks = Singleton<GameVariables>.instance.cardPacks;
		switch (typeCardpack)
		{
		case CardType.Bronze:
			rarity = CardType.Bronze;
			num2 = bronzePackBronzeCards;
			guaranteedRarity = bronzePackMin;
			maxRarity = bronzePackMax;
			break;
		case CardType.Silver:
			rarity = CardType.Silver;
			num2 = silverPackSilverCards;
			guaranteedRarity = silverPackMin;
			maxRarity = silverPackMax;
			break;
		case CardType.Gold:
			rarity = CardType.Gold;
			num2 = goldPackGoldCards;
			guaranteedRarity = goldPackMin;
			maxRarity = goldPackMax;
			break;
		}
		UnityEngine.Debug.Log(string.Format("According to XLS Configuration -> Constants generating:\n{0} {1}\n{2} minimaly {3} maximaly {4}", num2.ToString(), rarity.ToString(), (num - num2).ToString(), guaranteedRarity.ToString(), maxRarity.ToString()));
		Card[] array = new Card[num];
		for (int i = 0; i < num2; i++)
		{
			array[i] = AddRarityCard(rarity);
		}
		for (int j = num2; j < num; j++)
		{
			array[j] = AddRandomCard(guaranteedRarity, maxRarity);
		}
		return array;
	}

	internal void ClearCardsForGame()
	{
		cardsForGame.Clear();
	}

	[PunRPC]
	private void CardWasUsedOnline(string cardId, byte fraction, int playerID)
	{
		Card cardInstance = GetCardInstance(cardId, false);
		if (playerID == PhotonNetwork.player.ID && mCardUseInProgress)
		{
			mNextTime = TimeManager.realTimeWithoutPauses + mCooldown;
			mCardUseInProgress = false;
		}
		if (this.CardUsed != null)
		{
			this.CardUsed(cardInstance, (GHPGNELIDBM)fraction, playerID == PhotonNetwork.player.ID);
		}
		enemyCards.Add(cardInstance);
	}

	private void InitCards()
	{
		GameObject gameObject = new GameObject("MineCards");
		gameObject.transform.parent = base.transform;
		foreach (Card card2 in cards)
		{
			if (card2 == null)
			{
				UnityEngine.Debug.LogError("There is NULL card in card manager -> cards");
				continue;
			}
			CardDefinitionsRow row = cardDefinitions.GetRow(card2.id);
			if (row == null)
			{
				UnityEngine.Debug.LogError(string.Format("There is no definition for card {0}", card2.id));
			}
			card2.Init(row);
			card2.transform.parent = gameObject.transform;
			mCardDictionary.Add(card2.id, card2);
		}
		GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject);
		gameObject2.transform.parent = base.transform;
		gameObject2.name = "OtherCards";
		Card[] componentsInChildren = gameObject2.GetComponentsInChildren<Card>(true);
		mOtherBuddyCards = new List<CardBuddy>();
		for (int i = 0; i < 4; i++)
		{
			CardBuddy cardBuddy = UnityEngine.Object.Instantiate(mCardBuddyPrefab);
			cardBuddy.gameObject.name = string.Format("Other Buddy Warcard {0}", i + 1);
			cardBuddy.gameObject.transform.parent = gameObject2.transform;
			mOtherBuddyCards.Add(cardBuddy);
		}
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			mOtherPlayerCards.Add(card.id, card);
			CardDefinitionsRow row2 = cardDefinitions.GetRow(card.id);
			card.Init(row2);
			if (row2 == null)
			{
				UnityEngine.Debug.LogError(string.Format("There is no definition for card {0}", card.id));
			}
		}
		mBuddyCard = UnityEngine.Object.Instantiate(mCardBuddyPrefab);
		mBuddyCard.gameObject.name = "Buddy Warcard Original";
		mBuddyCard.gameObject.transform.parent = cards[0].gameObject.transform.parent;
		mSquadCardsParent = new GameObject("SquadCards").transform;
		mSquadCardsParent.transform.parent = base.transform;
		Singleton<CardManagerDeathmatchOffline>.instance.InitCards();
	}

	public void InitializeBuddyWarcard()
	{
		mBuddyCard.Init(GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp, CardBuddy.CreateDataForCurrentPlayer());
	}

	public void ActualizeBuddyWarcardTime()
	{
		mBuddyCard.id = GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	private int SortByRarity(Card c1, Card c2)
	{
		if (c1.rarity < c2.rarity)
		{
			return 1;
		}
		if (c1.rarity > c2.rarity)
		{
			return -1;
		}
		return c1.cardName.CompareTo(c2.cardName);
	}

	private void InstanceOnGameEnded(GameController.HKGHCIEPGEL gameEndReason)
	{
		for (int num = cardsForGame.Count - 1; num >= 0; num--)
		{
			Card card = cardsForGame[num];
			if (card.amount < 1)
			{
				cardsForGame.RemoveAt(num);
			}
		}
		foreach (Card mUsedCard in mUsedCards)
		{
			mUsedCard.DisconnectEvents();
		}
		mCardUseInProgress = false;
	}

	private void InstanceOnGameStarted()
	{
		mCardUseInProgress = false;
		mUsedCards.Clear();
		obtainedCards.Clear();
		enemyCards.Clear();
		cardUsedByMe.Clear();
		PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
	}

	private void OnPlayerDataLoaded()
	{
		mCardsByQuality = new Dictionary<CardType, List<Card>>();
		mCardsByQuality[CardType.Bronze] = new List<Card>();
		mCardsByQuality[CardType.Silver] = new List<Card>();
		mCardsByQuality[CardType.Gold] = new List<Card>();
		cardsByRarity.Clear();
		foreach (Card card2 in cards)
		{
			if (card2.implemented)
			{
				mCardsByQuality[card2.rarity].Add(card2);
			}
			cardsByRarity.Add(card2);
		}
		cardsByRarity.Sort(SortByRarity);
		Card[] componentsInChildren = GetComponentsInChildren<Card>();
		cardsForGame.Clear();
		foreach (CardBuddy mBuddyCard in mBuddyCards)
		{
			mBuddyCard.RemoveCard();
		}
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			if (!card.isBuddyCard && !data.cardData.ContainsKey(card.id))
			{
				data.cardData[card.id] = new CardData
				{
					amount = 0
				};
			}
		}
		foreach (KeyValuePair<string, BuddyCardData> buddyCardDatum in data.buddyCardData)
		{
			AddBuddyCard(buddyCardDatum.Key, buddyCardDatum.Value);
		}
		Singleton<CardManagerDeathmatchOffline>.instance.Load();
		SavingLastSelected.instance.LoadSelectedCards();
	}

	[PunRPC]
	private void PlayCardRPC(string id, byte fraction, int playerId)
	{
		if (!mOtherPlayerCards.ContainsKey(id))
		{
			UnityEngine.Debug.LogError("Other Player Cards -> Card Manager -> does not contain id: " + id);
			return;
		}
		Card cardInstance = GetCardInstance(id, false);
		cardInstance.playerId = playerId;
		cardInstance.UseCardOnline(this, (GHPGNELIDBM)fraction);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.EnemyCardPlayed);
	}

	internal string GetUsedCards()
	{
		List<string> list = new List<string>();
		foreach (Card mUsedCard in mUsedCards)
		{
			list.Add(mUsedCard.id);
		}
		return JsonConvert.SerializeObject(list);
	}

	public int GetUsedCardsCount()
	{
		return mUsedCards.Count;
	}

	internal string GetObtainedCards()
	{
		string[] array = new string[obtainedCards.Count];
		for (int i = 0; i < obtainedCards.Count; i++)
		{
			array[i] = obtainedCards[i].id;
		}
		return JsonConvert.SerializeObject(array);
	}

	public Card RecentGainedCard()
	{
		if (string.IsNullOrEmpty(mIdLastGainedCard) || mCardDictionary.ContainsKey(mIdLastGainedCard))
		{
			return null;
		}
		return mCardDictionary[mIdLastGainedCard];
	}

	[DebuggerHidden]
	public IEnumerator InitGameCards(string chosenCards, bool isOpponnetCard, bool isCurrentPlayer)
	{
		PKPKHMGJCHF pKPKHMGJCHF = new PKPKHMGJCHF();
		pKPKHMGJCHF.AAOAKDPIEII = chosenCards;
		pKPKHMGJCHF.NFIJPDAMBEL = isOpponnetCard;
		pKPKHMGJCHF.CAPGLFMCEDK = isCurrentPlayer;
		pKPKHMGJCHF.BJGCPDNMHDH = this;
		return pKPKHMGJCHF;
	}

	public void ReleaseCards(string chosenCards, bool isOpponnetCard, bool isCurrentPlayer)
	{
		string[] array = chosenCards.Split(';');
		UnityEngine.Debug.Log(string.Format("Release cards : " + chosenCards + " is Opponent: " + isOpponnetCard));
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			Card cardInstance = GetCardInstance(text, isCurrentPlayer);
			if (cardInstance != null)
			{
				try
				{
					cardInstance.ReleaseCard(isOpponnetCard);
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
			}
		}
	}

	public static CardType CardRarityConverter(int rarity)
	{
		int result;
		switch (rarity)
		{
		case 3:
			return CardType.Gold;
		case 2:
			result = 2;
			break;
		default:
			result = 1;
			break;
		}
		return (CardType)result;
	}

	public void DebugAddEveryCard()
	{
		foreach (Card value in mCardDictionary.Values)
		{
			value.AddCard();
		}
	}

	public Card AddMineBuddyCardTest()
	{
		string id = GameLoginManager.currentPlayer.id + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		BuddyCardData buddyCardData = CardBuddy.CreateDataForCurrentPlayer();
		return AddBuddyCard(id, buddyCardData);
	}

	private CardBuddy GetEmptyBuddyCard(out bool exists)
	{
		exists = false;
		foreach (CardBuddy mBuddyCard in mBuddyCards)
		{
			if (mBuddyCard.amount == 0)
			{
				exists = true;
				return mBuddyCard;
			}
		}
		CardBuddy cardBuddy = UnityEngine.Object.Instantiate(mCardBuddyPrefab);
		cardBuddy.gameObject.name = string.Format("Buddy Warcard {0}", mBuddyCards.Count + 1);
		cardBuddy.gameObject.transform.parent = cards[0].gameObject.transform.parent;
		return cardBuddy;
	}

	public Card AddBuddyCard(string id, BuddyCardData buddyCardData)
	{
		if (!data.buddyCardData.ContainsKey(id))
		{
			data.buddyCardData.Add(id, buddyCardData);
		}
		Card value;
		if (!mCardDictionary.TryGetValue(id, out value))
		{
			bool exists;
			value = GetEmptyBuddyCard(out exists);
			if (!exists)
			{
				mBuddyCards.Add((CardBuddy)value);
				cards.Add(value);
				cardsByRarity.Add(value);
			}
		}
		CardBuddy cardBuddy = (CardBuddy)value;
		cardBuddy.Init(id, buddyCardData);
		mCardDictionary[id] = cardBuddy;
		cardsByRarity.Sort(SortByRarity);
		return value;
	}

	public List<CardBuddy> SetBuddyCardsOher(List<Tuple<string, BuddyCardData>> buddyCards)
	{
		foreach (CardBuddy mOtherBuddyCard in mOtherBuddyCards)
		{
			mOtherBuddyCard.DestroyCard();
			mOtherBuddyCard.Init("EMPTY", new BuddyCardData
			{
				amount = 0
			});
		}
		for (int i = 0; i < buddyCards.Count; i++)
		{
			Tuple<string, BuddyCardData> tuple = buddyCards[i];
			mOtherBuddyCards[i].Init(tuple.Value1, tuple.Value2);
			mOtherPlayerCards[tuple.Value1] = mOtherBuddyCards[i];
		}
		return mOtherBuddyCards;
	}

	public Card GetSquadCardInstance(string cardId, BuddyCardData buddyCardData = null)
	{
		if (buddyCardData == null)
		{
			if (mCardDictionary.ContainsKey(cardId))
			{
				return mCardDictionary[cardId];
			}
			UnityEngine.Debug.LogError(string.Format("Squad Card ID \"{0}\" is not pressent", cardId));
			return null;
		}
		CardBuddy squadBuddyCard = GetSquadBuddyCard(cardId);
		squadBuddyCard.Init(cardId, buddyCardData);
		return squadBuddyCard;
	}

	private CardBuddy GetSquadBuddyCard(string cardId)
	{
		foreach (CardBuddy item in mBuddyCardsSquad)
		{
			if (item.id == cardId)
			{
				return item;
			}
		}
		foreach (CardBuddy item2 in mBuddyCardsSquad)
		{
			if (item2.amount == 0)
			{
				return item2;
			}
		}
		CardBuddy cardBuddy = UnityEngine.Object.Instantiate(mCardBuddyPrefab);
		cardBuddy.gameObject.name = string.Format("Squad Buddy Warcard {0}", mBuddyCardsSquad.Count + 1);
		cardBuddy.gameObject.transform.parent = mSquadCardsParent;
		mBuddyCardsSquad.Add(cardBuddy);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log("ADDING SQUAD BUDDY WARCARD " + cardId);
		}
		return cardBuddy;
	}

	public void ResetSquadCards(List<string> keepBuddies = null)
	{
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log("RESETING SQUAD WARCARDS");
		}
		if (keepBuddies == null)
		{
			foreach (CardBuddy item in mBuddyCardsSquad)
			{
				item.DestroyCard();
				item.Init(string.Empty, new BuddyCardData
				{
					amount = 0
				});
			}
			return;
		}
		using (List<CardBuddy>.Enumerator enumerator2 = mBuddyCardsSquad.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				NFPDIHGDBGG nFPDIHGDBGG = new NFPDIHGDBGG();
				nFPDIHGDBGG.EPPKMFBEJHM = enumerator2.Current;
				if (keepBuddies.FindIndex(nFPDIHGDBGG.LJCDGJKCNEC) < 0)
				{
					nFPDIHGDBGG.EPPKMFBEJHM.DestroyCard();
					nFPDIHGDBGG.EPPKMFBEJHM.Init(string.Empty, new BuddyCardData
					{
						amount = 0
					});
				}
			}
		}
	}

	public static void AddCardForWinner()
	{
		CardConstants cardConstants = Singleton<GameVariables>.instance.cardConstants;
		float num = 0f;
		float fLOATVALUE = cardConstants.GetRow(CardConstants.rowIds.ChanceToGetcard1MaxLevel).FLOATVALUE;
		float fLOATVALUE2 = cardConstants.GetRow(CardConstants.rowIds.ChanceToGetcard2MaxLevel).FLOATVALUE;
		int displayNumber = LevelManager.instance.currentLevel.displayNumber;
		num = (((float)displayNumber <= fLOATVALUE) ? cardConstants.GetRow(CardConstants.rowIds.ChanceToGetCard1).FLOATVALUE : ((!((float)displayNumber <= fLOATVALUE2)) ? cardConstants.GetRow(CardConstants.rowIds.ChanceToGetCard3).FLOATVALUE : cardConstants.GetRow(CardConstants.rowIds.ChanceToGetCard2).FLOATVALUE));
		float value = UnityEngine.Random.value;
		if (value <= num && !LevelManager.instance.isWarcardsLocked && !TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			instance.AddRandomCardDuringGame();
		}
	}

	internal int BuddyCardChosen()
	{
		foreach (Card mUsedCard in mUsedCards)
		{
			if (mUsedCard.isBuddyCard)
			{
				return 1;
			}
		}
		foreach (Card item in cardsForGame)
		{
			if (item.isBuddyCard)
			{
				return 1;
			}
		}
		return 0;
	}

	internal int BuddyCardsOwned()
	{
		return data.buddyCardData.Count;
	}

	internal int BuddyCardPlayed()
	{
		int num = 0;
		foreach (Card mUsedCard in mUsedCards)
		{
			if (mUsedCard.isBuddyCard)
			{
				num++;
			}
		}
		return num;
	}

	public bool TutorialWarcardPlayed(int index)
	{
		bool flag = false;
		if (Singleton<GameController>.instance.CBAPHFGNLLH.CPLFJCDIIPG != null && Singleton<GameController>.instance.CBAPHFGNLLH.CPLFJCDIIPG.Count > index && Singleton<GameController>.instance.CBAPHFGNLLH.CPLFJCDIIPG[index] != null)
		{
			for (int i = 0; i < cardUsedByMe.Count; i++)
			{
				flag |= cardUsedByMe[i].id == Singleton<GameController>.instance.CBAPHFGNLLH.CPLFJCDIIPG[index].id;
			}
		}
		return flag;
	}
}
