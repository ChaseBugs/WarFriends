using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Crane : Core_BaseScript
{
	private sealed class FNILLKIJPLP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Vector3 AHDPAJOFCPG;

		internal Vector3 ACODLBAEEFE;

		internal float CENMAIHCDAJ;

		internal Crane BJGCPDNMHDH;

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

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HCHFFFPDMDA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = true;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = true;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.AAAPKKLNMEL();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(832f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.DLEOJNAMICH(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(387f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.JFEFIENIDMC(UnityEngine.Random.Range(52, -28));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = true;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = false;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.AAAPKKLNMEL();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1253f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.Drop(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(1295f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.FCIAFJACIDI(UnityEngine.Random.Range(77, -109));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = true;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = true;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.FMMDIMOOCJP();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1867f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.CNCDLHAGAMO(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(1602f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.JFEFIENIDMC(UnityEngine.Random.Range(-61, 62));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public bool NAMPBIHOFGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = false;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = false;
				BJGCPDNMHDH.GNHCNPPHCDM.CMDPKJCOJID(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.KCIMMIJLMEH();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(969f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.DLEOJNAMICH(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(106f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.JFEFIENIDMC(UnityEngine.Random.Range(-2, -42));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = false;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = true;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.IsUp();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1008f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.IGNFPCKFFLD(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(443f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.FCIAFJACIDI(UnityEngine.Random.Range(42, -121));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public bool LHBPPCGLHDI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = true;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = false;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.JDCANBPHCIJ();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1063f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.DLEOJNAMICH(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(351f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.FCIAFJACIDI(UnityEngine.Random.Range(-118, -9));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void FLCIMHOJPDF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EBLHEEKHANA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = false;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = false;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.AAAPKKLNMEL();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(309f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.Drop(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(482f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.JFEFIENIDMC(UnityEngine.Random.Range(8, 99));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBOGBCNCIFN()
		{
			return PHDOCKCBJOF;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.BCJEEIAAOPD(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = true;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = false;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.JDCANBPHCIJ();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(619f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.DLEOJNAMICH(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(66f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.JFEFIENIDMC(UnityEngine.Random.Range(-72, 53));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void CNMNAHEINED()
		{
			throw new NotSupportedException();
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public bool KIFNNJFJJCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = false;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = false;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.IsUp();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(753f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.DLEOJNAMICH(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(605f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.JFEFIENIDMC(UnityEngine.Random.Range(-25, 107));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public FNILLKIJPLP()
		{
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = false;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = false;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.OKNNPBPJCMM(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.IsUp();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1752f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.CNCDLHAGAMO(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(1757f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.FCIAFJACIDI(UnityEngine.Random.Range(-89, -95));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
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
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NIDLKNKKCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJDOHADMIEB()
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
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = false;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = false;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.JDCANBPHCIJ();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.KHDAPEALLNK(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1775f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.Drop(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(1623f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.JFEFIENIDMC(UnityEngine.Random.Range(-98, -24));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MJPEJLKAOEH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJBDKMGNEPK()
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
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				CENMAIHCDAJ = Vector3.Distance(BJGCPDNMHDH.CIPJHCFDLLJ.transform.position, BJGCPDNMHDH.GNHCNPPHCDM.CIPJHCFDLLJ.transform.position);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position - CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				BJGCPDNMHDH.GNHCNPPHCDM.GetComponent<Rigidbody>().isKinematic = true;
				BJGCPDNMHDH.GNHCNPPHCDM.PMOIABIGMLO = true;
				BJGCPDNMHDH.GNHCNPPHCDM.Pick(BJGCPDNMHDH.CIPJHCFDLLJ);
				ACODLBAEEFE = BJGCPDNMHDH.transform.position + CENMAIHCDAJ * Vector3.up;
				BJGCPDNMHDH.EJHIAMLBBCD = Vector3.Distance(AHDPAJOFCPG, ACODLBAEEFE) / BJGCPDNMHDH.JPNAINOGAMM;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				BJGCPDNMHDH.GNHCNPPHCDM.IsUp();
				AHDPAJOFCPG = BJGCPDNMHDH.transform.position;
				ACODLBAEEFE = BJGCPDNMHDH.ABAECAHEKGI.transform.position;
				ACODLBAEEFE.y = AHDPAJOFCPG.y;
				BJGCPDNMHDH.CIGDCLFILCH(AHDPAJOFCPG, ACODLBAEEFE);
				goto case 4u;
			case 4u:
				if (BJGCPDNMHDH.JCKOBELDCGD)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(2f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 5u:
				BJGCPDNMHDH.GNHCNPPHCDM.Drop(BJGCPDNMHDH.ABAECAHEKGI);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				if (BJGCPDNMHDH.FEHCCGEGPLH.isMine)
				{
					BJGCPDNMHDH.JFEFIENIDMC(UnityEngine.Random.Range(10, 15));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}
	}

	public List<DropPoint> DPFHEFKOOMH;

	public DropPoint CIGGEGAFPHE;

	private DropPoint ABAECAHEKGI;

	private MagneticObject GNHCNPPHCDM;

	public List<MagneticObject> KJHLMCEAGIL;

	public QuickRope2 NLIGPBPNHHP;

	public Transform CIPJHCFDLLJ;

	public float JPNAINOGAMM = 1f;

	public Transform DGCPAMBCPEN;

	public Transform BDHBNOOIIGO;

	private Vector3 GMENJOACKEO;

	private bool JCKOBELDCGD;

	private Vector3 NEIEJFFAJFH;

	private Vector3 ADIMNILKFDA;

	private float EJHIAMLBBCD;

	private float FHFJGAJHBJM;

	private PhotonView FEHCCGEGPLH;

	private float PHEADDEDEMG;

	private IEnumerator OHANHLMMAAG()
	{
		FNILLKIJPLP fNILLKIJPLP = new FNILLKIJPLP();
		fNILLKIJPLP.BJGCPDNMHDH = this;
		return fNILLKIJPLP;
	}

	private void MMJPOKIAMNI()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject item in KJHLMCEAGIL)
		{
			list.Add(item);
		}
		GNHCNPPHCDM = list[UnityEngine.Random.Range(0, list.Count)];
		int num = KJHLMCEAGIL.IndexOf(GNHCNPPHCDM);
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)num;
		fEHCCGEGPLH.RPC("Player wants to join squad, name =", PhotonTargets.Others, array);
	}

	protected virtual void IFAGEMEKBOL()
	{
		base.Start();
		ConfigurableJoint component = NLIGPBPNHHP.Joints[NLIGPBPNHHP.Joints.Count - 8].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = 144f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 480f
		};
		foreach (GameObject joint in NLIGPBPNHHP.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		}
	}

	private void KIHKLMMENCD()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject item in KJHLMCEAGIL)
		{
			list.Add(item);
		}
		GNHCNPPHCDM = list[UnityEngine.Random.Range(0, list.Count)];
		int num = KJHLMCEAGIL.IndexOf(GNHCNPPHCDM);
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
		FEHCCGEGPLH.RPC("DOWNLOADBTN", PhotonTargets.Others, (byte)num);
	}

	private void LIOAKGAMMNF()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject item in KJHLMCEAGIL)
		{
			list.Add(item);
		}
		GNHCNPPHCDM = list[UnityEngine.Random.Range(1, list.Count)];
		int num = KJHLMCEAGIL.IndexOf(GNHCNPPHCDM);
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)num;
		fEHCCGEGPLH.RPC("tierCount", PhotonTargets.Others, array);
	}

	protected virtual void OIKLJGMKMAE()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		GMENJOACKEO = base.transform.position;
	}

	private void HHEMFEPDPHI(byte DFHAAIFFLOE)
	{
		GNHCNPPHCDM = KJHLMCEAGIL[DFHAAIFFLOE];
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
	}

	private void ECIKBOPGGNF()
	{
		List<DropPoint> list = new List<DropPoint>();
		int num = 0;
		foreach (DropPoint item in DPFHEFKOOMH)
		{
			if (item.JKOGCJGMBEB != null && !item.KAJEIHOLMHI)
			{
				num++;
			}
		}
		foreach (DropPoint item2 in DPFHEFKOOMH)
		{
			if (num == 0)
			{
				if (item2.JKOGCJGMBEB == null)
				{
					list.Add(item2);
				}
			}
			else if (item2.JKOGCJGMBEB == null && item2.KAJEIHOLMHI)
			{
				list.Add(item2);
			}
		}
		ABAECAHEKGI = list[UnityEngine.Random.Range(0, list.Count)];
		int num2 = DPFHEFKOOMH.IndexOf(ABAECAHEKGI);
		FEHCCGEGPLH.RPC("PickDropPointRPC", PhotonTargets.Others, (byte)num2);
	}

	private void GMAIKNOIIJK(byte DFHAAIFFLOE)
	{
		ABAECAHEKGI = DPFHEFKOOMH[DFHAAIFFLOE];
	}

	private void KHDAPEALLNK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		JCKOBELDCGD = true;
		NEIEJFFAJFH = OEIICEJPGKI;
		ADIMNILKFDA = IIMDKHJAJGO;
		EJHIAMLBBCD = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) / JPNAINOGAMM;
		FHFJGAJHBJM = 838f;
	}

	private void OECMDJNKHFC()
	{
		Singleton<GameController>.instance.GameStarted -= ACLCPJHKHLL;
		if (FEHCCGEGPLH.isMine)
		{
			FCIAFJACIDI(1703f);
		}
	}

	private void BGLJJBKIPME()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject item in KJHLMCEAGIL)
		{
			list.Add(item);
		}
		GNHCNPPHCDM = list[UnityEngine.Random.Range(1, list.Count)];
		int num = KJHLMCEAGIL.IndexOf(GNHCNPPHCDM);
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)num;
		fEHCCGEGPLH.RPC("CONFIRM", PhotonTargets.Others, array);
	}

	[PunRPC]
	private void PickDropPointRPC(byte DFHAAIFFLOE)
	{
		ABAECAHEKGI = DPFHEFKOOMH[DFHAAIFFLOE];
	}

	private void CJGENDOJBAH()
	{
		Singleton<GameController>.instance.GameStarted -= OECMDJNKHFC;
	}

	protected virtual void DGAODFBMLHB()
	{
		base.Start();
		ConfigurableJoint component = NLIGPBPNHHP.Joints[NLIGPBPNHHP.Joints.Count - 6].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = 427f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 910f
		};
		foreach (GameObject joint in NLIGPBPNHHP.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		}
	}

	private void Update()
	{
		Vector3 forward = base.transform.position - DGCPAMBCPEN.position;
		forward.y = 0f;
		DGCPAMBCPEN.rotation = Quaternion.LookRotation(forward);
		Vector3 position = base.transform.position;
		position.y = GMENJOACKEO.y;
		Vector3 forward2 = position - BDHBNOOIIGO.position;
		BDHBNOOIIGO.rotation = Quaternion.LookRotation(forward2);
		if (PhotonNetwork.time > (double)PHEADDEDEMG && PHEADDEDEMG != 0f)
		{
			PHEADDEDEMG = 0f;
			StartCoroutine(DPANBKNCFLO());
		}
	}

	private void FIEHPMCFCNO()
	{
		Singleton<GameController>.instance.GameStarted -= NLEOKOIAACP;
	}

	private void LHBHCAEJIGH(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void OAAMIOCLIAP(byte DFHAAIFFLOE)
	{
		GNHCNPPHCDM = KJHLMCEAGIL[DFHAAIFFLOE];
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
	}

	private void LPFGBKIINMP()
	{
		Vector3 forward = base.transform.position - DGCPAMBCPEN.position;
		forward.y = 211f;
		DGCPAMBCPEN.rotation = Quaternion.LookRotation(forward);
		Vector3 position = base.transform.position;
		position.y = GMENJOACKEO.y;
		Vector3 forward2 = position - BDHBNOOIIGO.position;
		BDHBNOOIIGO.rotation = Quaternion.LookRotation(forward2);
		if (PhotonNetwork.time > (double)PHEADDEDEMG && PHEADDEDEMG != 1047f)
		{
			PHEADDEDEMG = 368f;
			StartCoroutine(BMKHLHDCHED());
		}
	}

	private void MDGDJADEEML(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void MFFHPLGEIPP()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject item in KJHLMCEAGIL)
		{
			list.Add(item);
		}
		GNHCNPPHCDM = list[UnityEngine.Random.Range(0, list.Count)];
		int num = KJHLMCEAGIL.IndexOf(GNHCNPPHCDM);
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = (byte)num;
		fEHCCGEGPLH.RPC("No main position was set in map definition", PhotonTargets.All, array);
	}

	private void FANEPODDMEF()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject item in KJHLMCEAGIL)
		{
			list.Add(item);
		}
		GNHCNPPHCDM = list[UnityEngine.Random.Range(1, list.Count)];
		int num = KJHLMCEAGIL.IndexOf(GNHCNPPHCDM);
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)num;
		fEHCCGEGPLH.RPC("BuddyCardData", PhotonTargets.All, array);
	}

	[DebuggerHidden]
	private IEnumerator DPANBKNCFLO()
	{
		FNILLKIJPLP fNILLKIJPLP = new FNILLKIJPLP();
		fNILLKIJPLP.BJGCPDNMHDH = this;
		return fNILLKIJPLP;
	}

	private void PMPDLGJBMIE(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	protected virtual void OBBHECACANB()
	{
		base.Start();
		ConfigurableJoint component = NLIGPBPNHHP.Joints[NLIGPBPNHHP.Joints.Count - 0].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = 1481f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 1257f
		};
		foreach (GameObject joint in NLIGPBPNHHP.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.None;
		}
	}

	[PunRPC]
	private void PickMagneticObjectRPC(byte DFHAAIFFLOE)
	{
		GNHCNPPHCDM = KJHLMCEAGIL[DFHAAIFFLOE];
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
	}

	private void FJDJFPKAKEF()
	{
		if (JCKOBELDCGD)
		{
			FHFJGAJHBJM += Time.fixedDeltaTime / EJHIAMLBBCD;
			base.transform.position = Vector3.Lerp(NEIEJFFAJFH, ADIMNILKFDA, FHFJGAJHBJM);
			if (FHFJGAJHBJM >= 714f)
			{
				JCKOBELDCGD = false;
			}
		}
		if (GNHCNPPHCDM != null && GNHCNPPHCDM.PMOIABIGMLO)
		{
			GNHCNPPHCDM.transform.rotation = CIPJHCFDLLJ.transform.rotation;
			GNHCNPPHCDM.transform.position = CIPJHCFDLLJ.transform.position - CIPJHCFDLLJ.transform.rotation * GNHCNPPHCDM.CIPJHCFDLLJ.transform.localPosition;
		}
	}

	protected virtual void LPKEGOIAEJC()
	{
		base.Start();
		ConfigurableJoint component = NLIGPBPNHHP.Joints[NLIGPBPNHHP.Joints.Count - 3].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = 25f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 257f
		};
		foreach (GameObject joint in NLIGPBPNHHP.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		}
	}

	protected virtual void BGCMGNMLDPI()
	{
		base.Start();
		ConfigurableJoint component = NLIGPBPNHHP.Joints[NLIGPBPNHHP.Joints.Count - 2].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = 763f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 1262f
		};
		foreach (GameObject joint in NLIGPBPNHHP.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		}
	}

	[PunRPC]
	protected void StartCraneAnimationRPC(float KBJEOEEOEFG)
	{
		PHEADDEDEMG = KBJEOEEOEFG;
	}

	protected void KAGNIDGEEEM(float KBJEOEEOEFG)
	{
		PHEADDEDEMG = KBJEOEEOEFG;
	}

	private void OKNNPBPJCMM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		JCKOBELDCGD = true;
		NEIEJFFAJFH = OEIICEJPGKI;
		ADIMNILKFDA = IIMDKHJAJGO;
		EJHIAMLBBCD = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) / JPNAINOGAMM;
		FHFJGAJHBJM = 698f;
	}

	private IEnumerator BMKHLHDCHED()
	{
		FNILLKIJPLP fNILLKIJPLP = new FNILLKIJPLP();
		fNILLKIJPLP.BJGCPDNMHDH = this;
		return fNILLKIJPLP;
	}

	private void ACLCPJHKHLL()
	{
		Singleton<GameController>.instance.GameStarted -= ACLCPJHKHLL;
		if (FEHCCGEGPLH.isMine)
		{
			JFEFIENIDMC(3f);
		}
	}

	private void OINCFGICMPL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private IEnumerator NLKDAAKEEBE()
	{
		FNILLKIJPLP fNILLKIJPLP = new FNILLKIJPLP();
		fNILLKIJPLP.BJGCPDNMHDH = this;
		return fNILLKIJPLP;
	}

	private void ECFIMCCNBBN()
	{
		Vector3 forward = base.transform.position - DGCPAMBCPEN.position;
		forward.y = 1913f;
		DGCPAMBCPEN.rotation = Quaternion.LookRotation(forward);
		Vector3 position = base.transform.position;
		position.y = GMENJOACKEO.y;
		Vector3 forward2 = position - BDHBNOOIIGO.position;
		BDHBNOOIIGO.rotation = Quaternion.LookRotation(forward2);
		if (PhotonNetwork.time > (double)PHEADDEDEMG && PHEADDEDEMG != 1878f)
		{
			PHEADDEDEMG = 1576f;
			StartCoroutine(NLKDAAKEEBE());
		}
	}

	protected virtual void PONMLKPPAPG()
	{
		base.Start();
		ConfigurableJoint component = NLIGPBPNHHP.Joints[NLIGPBPNHHP.Joints.Count - 4].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = 290f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 232f
		};
		foreach (GameObject joint in NLIGPBPNHHP.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		}
	}

	private void ONJHABLNHAL()
	{
		List<DropPoint> list = new List<DropPoint>();
		int num = 1;
		foreach (DropPoint item in DPFHEFKOOMH)
		{
			if (item.JKOGCJGMBEB != null && !item.KAJEIHOLMHI)
			{
				num += 0;
			}
		}
		foreach (DropPoint item2 in DPFHEFKOOMH)
		{
			if (num == 0)
			{
				if (item2.JKOGCJGMBEB == null)
				{
					list.Add(item2);
				}
			}
			else if (item2.JKOGCJGMBEB == null && item2.KAJEIHOLMHI)
			{
				list.Add(item2);
			}
		}
		ABAECAHEKGI = list[UnityEngine.Random.Range(0, list.Count)];
		int num2 = DPFHEFKOOMH.IndexOf(ABAECAHEKGI);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)num2;
		fEHCCGEGPLH.RPC("ID_MINUTES", PhotonTargets.Others, array);
	}

	private void FBDNPAEEFAL()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject item in KJHLMCEAGIL)
		{
			list.Add(item);
		}
		GNHCNPPHCDM = list[UnityEngine.Random.Range(1, list.Count)];
		int num = KJHLMCEAGIL.IndexOf(GNHCNPPHCDM);
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = (byte)num;
		fEHCCGEGPLH.RPC("DOWNLOAD", PhotonTargets.All, array);
	}

	private void JFEFIENIDMC(float KBJEOEEOEFG)
	{
		ECIKBOPGGNF();
		CHEKJOBOLBE();
		PHEADDEDEMG = KBJEOEEOEFG;
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("StartCraneAnimationRPC", PhotonTargets.Others, KBJEOEEOEFG);
		}
	}

	protected virtual void OJKBJGEEPBB()
	{
		base.Start();
		ConfigurableJoint component = NLIGPBPNHHP.Joints[NLIGPBPNHHP.Joints.Count - 6].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = 1563f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 765f
		};
		foreach (GameObject joint in NLIGPBPNHHP.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		}
	}

	private void ELJHCOHCAJI()
	{
		Vector3 forward = base.transform.position - DGCPAMBCPEN.position;
		forward.y = 598f;
		DGCPAMBCPEN.rotation = Quaternion.LookRotation(forward);
		Vector3 position = base.transform.position;
		position.y = GMENJOACKEO.y;
		Vector3 forward2 = position - BDHBNOOIIGO.position;
		BDHBNOOIIGO.rotation = Quaternion.LookRotation(forward2);
		if (PhotonNetwork.time > (double)PHEADDEDEMG && PHEADDEDEMG != 736f)
		{
			PHEADDEDEMG = 1668f;
			StartCoroutine(NIPBGNGJEKE());
		}
	}

	private void BBCOBMGHMGE()
	{
		Vector3 forward = base.transform.position - DGCPAMBCPEN.position;
		forward.y = 1720f;
		DGCPAMBCPEN.rotation = Quaternion.LookRotation(forward);
		Vector3 position = base.transform.position;
		position.y = GMENJOACKEO.y;
		Vector3 forward2 = position - BDHBNOOIIGO.position;
		BDHBNOOIIGO.rotation = Quaternion.LookRotation(forward2);
		if (PhotonNetwork.time > (double)PHEADDEDEMG && PHEADDEDEMG != 929f)
		{
			PHEADDEDEMG = 428f;
			StartCoroutine(DPANBKNCFLO());
		}
	}

	private void DAONNHPNCMP(byte DFHAAIFFLOE)
	{
		GNHCNPPHCDM = KJHLMCEAGIL[DFHAAIFFLOE];
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
	}

	private void FOFCJBGMPKP()
	{
		if (JCKOBELDCGD)
		{
			FHFJGAJHBJM += Time.fixedDeltaTime / EJHIAMLBBCD;
			base.transform.position = Vector3.Lerp(NEIEJFFAJFH, ADIMNILKFDA, FHFJGAJHBJM);
			if (FHFJGAJHBJM >= 694f)
			{
				JCKOBELDCGD = false;
			}
		}
		if (GNHCNPPHCDM != null && GNHCNPPHCDM.PMOIABIGMLO)
		{
			GNHCNPPHCDM.transform.rotation = CIPJHCFDLLJ.transform.rotation;
			GNHCNPPHCDM.transform.position = CIPJHCFDLLJ.transform.position - CIPJHCFDLLJ.transform.rotation * GNHCNPPHCDM.CIPJHCFDLLJ.transform.localPosition;
		}
	}

	private void OFDJHFMAJBI()
	{
		Vector3 forward = base.transform.position - DGCPAMBCPEN.position;
		forward.y = 1196f;
		DGCPAMBCPEN.rotation = Quaternion.LookRotation(forward);
		Vector3 position = base.transform.position;
		position.y = GMENJOACKEO.y;
		Vector3 forward2 = position - BDHBNOOIIGO.position;
		BDHBNOOIIGO.rotation = Quaternion.LookRotation(forward2);
		if (PhotonNetwork.time > (double)PHEADDEDEMG && PHEADDEDEMG != 81f)
		{
			PHEADDEDEMG = 370f;
			StartCoroutine(BNNCAIHJILA());
		}
	}

	private void BCJEEIAAOPD(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		JCKOBELDCGD = false;
		NEIEJFFAJFH = OEIICEJPGKI;
		ADIMNILKFDA = IIMDKHJAJGO;
		EJHIAMLBBCD = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) / JPNAINOGAMM;
		FHFJGAJHBJM = 1675f;
	}

	private void CIGDCLFILCH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		JCKOBELDCGD = true;
		NEIEJFFAJFH = OEIICEJPGKI;
		ADIMNILKFDA = IIMDKHJAJGO;
		EJHIAMLBBCD = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) / JPNAINOGAMM;
		FHFJGAJHBJM = 0f;
	}

	private void GKNNBNAEBHB(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void CHEKJOBOLBE()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject item in KJHLMCEAGIL)
		{
			list.Add(item);
		}
		GNHCNPPHCDM = list[UnityEngine.Random.Range(0, list.Count)];
		int num = KJHLMCEAGIL.IndexOf(GNHCNPPHCDM);
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
		FEHCCGEGPLH.RPC("PickMagneticObjectRPC", PhotonTargets.Others, (byte)num);
	}

	protected void FNGGCNHEJDG(float KBJEOEEOEFG)
	{
		PHEADDEDEMG = KBJEOEEOEFG;
	}

	protected void GDKEIOLNGCJ(float KBJEOEEOEFG)
	{
		PHEADDEDEMG = KBJEOEEOEFG;
	}

	private void OnDestroy()
	{
		Singleton<GameController>.instance.GameStarted -= ACLCPJHKHLL;
	}

	private void FixedUpdate()
	{
		if (JCKOBELDCGD)
		{
			FHFJGAJHBJM += Time.fixedDeltaTime / EJHIAMLBBCD;
			base.transform.position = Vector3.Lerp(NEIEJFFAJFH, ADIMNILKFDA, FHFJGAJHBJM);
			if (FHFJGAJHBJM >= 1f)
			{
				JCKOBELDCGD = false;
			}
		}
		if (GNHCNPPHCDM != null && GNHCNPPHCDM.PMOIABIGMLO)
		{
			GNHCNPPHCDM.transform.rotation = CIPJHCFDLLJ.transform.rotation;
			GNHCNPPHCDM.transform.position = CIPJHCFDLLJ.transform.position - CIPJHCFDLLJ.transform.rotation * GNHCNPPHCDM.CIPJHCFDLLJ.transform.localPosition;
		}
	}

	private IEnumerator NIPBGNGJEKE()
	{
		FNILLKIJPLP fNILLKIJPLP = new FNILLKIJPLP();
		fNILLKIJPLP.BJGCPDNMHDH = this;
		return fNILLKIJPLP;
	}

	private void GANLEAKLKNP(byte DFHAAIFFLOE)
	{
		GNHCNPPHCDM = KJHLMCEAGIL[DFHAAIFFLOE];
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
	}

	private IEnumerator MHBCEFPDLJE()
	{
		FNILLKIJPLP fNILLKIJPLP = new FNILLKIJPLP();
		fNILLKIJPLP.BJGCPDNMHDH = this;
		return fNILLKIJPLP;
	}

	protected void LHAIPOKIIBN(float KBJEOEEOEFG)
	{
		PHEADDEDEMG = KBJEOEEOEFG;
	}

	private IEnumerator BNNCAIHJILA()
	{
		FNILLKIJPLP fNILLKIJPLP = new FNILLKIJPLP();
		fNILLKIJPLP.BJGCPDNMHDH = this;
		return fNILLKIJPLP;
	}

	private void BJMNJHGHKAJ()
	{
		List<DropPoint> list = new List<DropPoint>();
		int num = 1;
		foreach (DropPoint item in DPFHEFKOOMH)
		{
			if (item.JKOGCJGMBEB != null && !item.KAJEIHOLMHI)
			{
				num++;
			}
		}
		foreach (DropPoint item2 in DPFHEFKOOMH)
		{
			if (num == 0)
			{
				if (item2.JKOGCJGMBEB == null)
				{
					list.Add(item2);
				}
			}
			else if (item2.JKOGCJGMBEB == null && item2.KAJEIHOLMHI)
			{
				list.Add(item2);
			}
		}
		ABAECAHEKGI = list[UnityEngine.Random.Range(0, list.Count)];
		int num2 = DPFHEFKOOMH.IndexOf(ABAECAHEKGI);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = (byte)num2;
		fEHCCGEGPLH.RPC("Metal", PhotonTargets.All, array);
	}

	protected override void Start()
	{
		base.Start();
		ConfigurableJoint component = NLIGPBPNHHP.Joints[NLIGPBPNHHP.Joints.Count - 2].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = -35f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 35f
		};
		foreach (GameObject joint in NLIGPBPNHHP.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		}
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
	}

	private void HBOBOGLLEGG()
	{
		List<DropPoint> list = new List<DropPoint>();
		int num = 1;
		foreach (DropPoint item in DPFHEFKOOMH)
		{
			if (item.JKOGCJGMBEB != null && !item.KAJEIHOLMHI)
			{
				num++;
			}
		}
		foreach (DropPoint item2 in DPFHEFKOOMH)
		{
			if (num == 0)
			{
				if (item2.JKOGCJGMBEB == null)
				{
					list.Add(item2);
				}
			}
			else if (item2.JKOGCJGMBEB == null && item2.KAJEIHOLMHI)
			{
				list.Add(item2);
			}
		}
		ABAECAHEKGI = list[UnityEngine.Random.Range(0, list.Count)];
		int num2 = DPFHEFKOOMH.IndexOf(ABAECAHEKGI);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = (byte)num2;
		fEHCCGEGPLH.RPC(" BOUGHT AND PRESENT IN ACCOUNT", PhotonTargets.All, array);
	}

	private void FCIAFJACIDI(float KBJEOEEOEFG)
	{
		ECIKBOPGGNF();
		FANEPODDMEF();
		PHEADDEDEMG = KBJEOEEOEFG;
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[0] = KBJEOEEOEFG;
			fEHCCGEGPLH.RPC("discount", PhotonTargets.Others, array);
		}
	}

	private void NLEOKOIAACP()
	{
		Singleton<GameController>.instance.GameStarted -= OECMDJNKHFC;
		if (FEHCCGEGPLH.isMine)
		{
			JFEFIENIDMC(1652f);
		}
	}

	private void JDPLILEGJDE(byte DFHAAIFFLOE)
	{
		GNHCNPPHCDM = KJHLMCEAGIL[DFHAAIFFLOE];
		if (GNHCNPPHCDM.OCOILNELFFK != null)
		{
			GNHCNPPHCDM.OCOILNELFFK.JKOGCJGMBEB = null;
			GNHCNPPHCDM.OCOILNELFFK = null;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		GMENJOACKEO = base.transform.position;
	}
}
