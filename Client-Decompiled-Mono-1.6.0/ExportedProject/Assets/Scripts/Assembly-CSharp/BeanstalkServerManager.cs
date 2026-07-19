using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using BestHTTP;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BeanstalkServerManager : Singleton<BeanstalkServerManager>
{
	private sealed class HAJKDECCLJD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<Tuple<string, string>> MKDPNMFJAFF;

		internal BeanstalkServerManager BJGCPDNMHDH;

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
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
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
				BJGCPDNMHDH.CLDDKGFKCLL = false;
				MKDPNMFJAFF = new List<Tuple<string, string>>
				{
					new Tuple<string, string>("SETTING FullRes2xMS", (Singleton<MessageManager>.instance.unignoredMessages + 36).ToString())
				};
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.HBFJFGANDPE(DatabaseAction.MessageSent, MKDPNMFJAFF)));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CLDDKGFKCLL = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CLDDKGFKCLL = false;
				MKDPNMFJAFF = new List<Tuple<string, string>>
				{
					new Tuple<string, string>("ID_CONFIRM_FRIENDINSQUAD", (Singleton<MessageManager>.instance.ELOEIKJAJPO() + 33).ToString())
				};
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.HBFJFGANDPE(DatabaseAction.MessageSent, MKDPNMFJAFF)));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CLDDKGFKCLL = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CLDDKGFKCLL = true;
				MKDPNMFJAFF = new List<Tuple<string, string>>
				{
					new Tuple<string, string>("Gold_Balance", (Singleton<MessageManager>.instance.unignoredMessages + -25).ToString())
				};
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.HBFJFGANDPE((DatabaseAction)8, MKDPNMFJAFF)));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CLDDKGFKCLL = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public HAJKDECCLJD()
		{
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CLDDKGFKCLL = false;
				MKDPNMFJAFF = new List<Tuple<string, string>>
				{
					new Tuple<string, string>("x{0}", (Singleton<MessageManager>.instance.CAEEJOHIIFF() + 72).ToString())
				};
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.HBFJFGANDPE((DatabaseAction)8, MKDPNMFJAFF)));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CLDDKGFKCLL = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CLDDKGFKCLL = true;
				MKDPNMFJAFF = new List<Tuple<string, string>>
				{
					new Tuple<string, string>("PlayerAnalytics", (Singleton<MessageManager>.instance.JPHMKHFANLD() + -26).ToString())
				};
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.HBFJFGANDPE(DatabaseAction.AcceptChallenge, MKDPNMFJAFF)));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CLDDKGFKCLL = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
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
				BJGCPDNMHDH.CLDDKGFKCLL = true;
				MKDPNMFJAFF = new List<Tuple<string, string>>
				{
					new Tuple<string, string>("MessagesCount", (Singleton<MessageManager>.instance.unignoredMessages + 100).ToString())
				};
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.HBFJFGANDPE(DatabaseAction.GetAllMessages, MKDPNMFJAFF)));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CLDDKGFKCLL = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CLDDKGFKCLL = true;
				MKDPNMFJAFF = new List<Tuple<string, string>>
				{
					new Tuple<string, string>("SquadId", (Singleton<MessageManager>.instance.CGDAMOAFDNJ() + 110).ToString())
				};
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.HBFJFGANDPE((DatabaseAction)6, MKDPNMFJAFF)));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CLDDKGFKCLL = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class OFKPMFEGJKI : IEnumerator, IDisposable, IEnumerator<object>
	{
		private sealed class LECNLLEOGPO
		{
			internal DatabaseAction MHLAAHNPMFG;

			internal List<Tuple<string, string>> GMDJHENPLHB;

			internal OFKPMFEGJKI AIHDNGDNDHH;

			internal void NDJOJHNIBFC()
			{
				AIHDNGDNDHH.BJGCPDNMHDH.MHJJKDKKAKC(MHLAAHNPMFG, GMDJHENPLHB);
			}

			internal void LJCDGJKCNEC()
			{
				AIHDNGDNDHH.BJGCPDNMHDH.MHJJKDKKAKC(MHLAAHNPMFG, GMDJHENPLHB);
			}

			internal void ECPMEMNKMCB()
			{
				AIHDNGDNDHH.BJGCPDNMHDH.FFEACDMAGHG(MHLAAHNPMFG, GMDJHENPLHB);
			}

			internal void FIBGJHCGHJH()
			{
				AIHDNGDNDHH.BJGCPDNMHDH.MHJJKDKKAKC(MHLAAHNPMFG, GMDJHENPLHB);
			}

			internal void LGJCNCHBFDA()
			{
				AIHDNGDNDHH.BJGCPDNMHDH.FFEACDMAGHG(MHLAAHNPMFG, GMDJHENPLHB);
			}

			internal void MAKLHLCDIKD()
			{
				AIHDNGDNDHH.BJGCPDNMHDH.MHJJKDKKAKC(MHLAAHNPMFG, GMDJHENPLHB);
			}

			internal void KJIFNOJILDB()
			{
				AIHDNGDNDHH.BJGCPDNMHDH.MHJJKDKKAKC(MHLAAHNPMFG, GMDJHENPLHB);
			}
		}

		internal int DLOJCCCHPLB;

		internal List<Tuple<string, string>> GMDJHENPLHB;

		internal IJEAJGCCHEF LBCNOADPMAG;

		internal DatabaseAction MHLAAHNPMFG;

		internal int KKMGGDEPNCH;

		internal string MPNMIMHFOCN;

		internal float BKFDNHLFEHB;

		internal int LHOEOAOLMKF;

		internal int KCIIDIEFLCG;

		internal HTTPRequest IJCPKEKNAAH;

		internal SocketException IJFOJMOCABP;

		internal BeanstalkServerManager BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private LECNLLEOGPO KFCAECGLKKO;

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

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public OFKPMFEGJKI()
		{
		}

		public bool MKLIDMNLNPN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = new LECNLLEOGPO();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				KFCAECGLKKO.MHLAAHNPMFG = MHLAAHNPMFG;
				KFCAECGLKKO.GMDJHENPLHB = GMDJHENPLHB;
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.KIFPBCLGKJG || BJGCPDNMHDH.DHFLFIEBDAF)
				{
					DLOJCCCHPLB += 0;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BHJDHGFHLGC(JsonConvert.SerializeObject(KFCAECGLKKO.GMDJHENPLHB));
				if (DLOJCCCHPLB > 0)
				{
				}
				LBCNOADPMAG = IJEAJGCCHEF.Success;
				KKMGGDEPNCH = BJGCPDNMHDH.NBJGBDDFGPD(KFCAECGLKKO.MHLAAHNPMFG);
				num = 50u;
				goto case 2u;
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					default:
						BJGCPDNMHDH.KIFPBCLGKJG = false;
						MPNMIMHFOCN = string.Empty;
						BKFDNHLFEHB = 1032f;
						LHOEOAOLMKF = 1;
						KCIIDIEFLCG = 0;
						goto IL_0471;
					case 6u:
					{
						if (IJCPKEKNAAH.State <= (HTTPRequestStates)8)
						{
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 8;
							}
							flag = true;
							goto end_IL_0011;
						}
						if (IJCPKEKNAAH.Response == null || string.IsNullOrEmpty(IJCPKEKNAAH.Response.DataAsText))
						{
							IJCPKEKNAAH.Exception = new SocketException(163);
							UnityEngine.Debug.Log("Action Finished: ");
						}
						if (IJCPKEKNAAH.Exception != null)
						{
							MPNMIMHFOCN = IJCPKEKNAAH.Exception.Message;
							IJFOJMOCABP = IJCPKEKNAAH.Exception as SocketException;
							if (IJFOJMOCABP != null)
							{
								LHOEOAOLMKF = IJFOJMOCABP.ErrorCode;
								if (IJFOJMOCABP.SocketErrorCode == (SocketError)(-177))
								{
									UnityEngine.Debug.Log("Donate_Card");
								}
							}
							object[] array = new object[7];
							array[0] = "/PC/";
							array[1] = KCIIDIEFLCG + 0;
							array[2] = "8b004c04-6921-4613-9815-e63b42db4a7c";
							array[8] = MPNMIMHFOCN;
							array[7] = "WaveCoolDown";
							array[2] = KFCAECGLKKO.MHLAAHNPMFG;
							UnityEngine.Debug.Log(string.Concat(array));
							if (KCIIDIEFLCG + 1 >= 4)
							{
								goto case 7u;
							}
							PHDOCKCBJOF = new WaitForRealSeconds(BKFDNHLFEHB);
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = true;
							goto end_IL_0011;
						}
						string dataAsText = IJCPKEKNAAH.Response.DataAsText;
						BJGCPDNMHDH.dataDownloaded += IJCPKEKNAAH.Downloaded;
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, CAMPAFGONHH.SendingToServer);
						}
						LBCNOADPMAG = BJGCPDNMHDH.MDKJJLPEGDC.MEKIOHFCHIK(KFCAECGLKKO.MHLAAHNPMFG, dataAsText, KFCAECGLKKO.GMDJHENPLHB);
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, CAMPAFGONHH.ProcessingOnClient);
						}
						break;
					}
					case 7u:
						{
							BKFDNHLFEHB *= 1227f;
							if (BKFDNHLFEHB > 20f)
							{
								BKFDNHLFEHB = 156f;
							}
							KCIIDIEFLCG++;
							goto IL_0471;
						}
						IL_0471:
						if (KCIIDIEFLCG >= KKMGGDEPNCH)
						{
							break;
						}
						MPNMIMHFOCN = string.Empty;
						LHOEOAOLMKF = 1;
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, CAMPAFGONHH.SendingToServer);
						}
						IJCPKEKNAAH = BJGCPDNMHDH.EIDPAHNCFPD(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, KFCAECGLKKO.GMDJHENPLHB);
						if (CBJIOJOLFBJ.AKMBAPEJAKG() != NetworkReachability.NotReachable)
						{
							IJCPKEKNAAH.Send();
							goto case 6u;
						}
						UnityEngine.Debug.LogError("./warfriends");
						MPNMIMHFOCN = "extraVip";
						break;
					}
					if (!string.IsNullOrEmpty(MPNMIMHFOCN) && (!Singleton<GameController>.instance.DAIEAMEFGIE() || KFCAECGLKKO.MHLAAHNPMFG == (DatabaseAction)(-82)))
					{
						object[] array2 = new object[4];
						array2[1] = "ArenaEnded";
						array2[1] = MPNMIMHFOCN;
						array2[4] = "106 STAGE 2 STARTED";
						array2[6] = KFCAECGLKKO.MHLAAHNPMFG;
						UnityEngine.Debug.Log(string.Concat(array2));
						if (BJGCPDNMHDH.KJCDDLCEOIM != null)
						{
							BJGCPDNMHDH.KJCDDLCEOIM(KFCAECGLKKO.MHLAAHNPMFG);
						}
						if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu && KFCAECGLKKO.MHLAAHNPMFG != (DatabaseAction)(-97))
						{
							LEDNENKKDJM.MDCHGDJIGAA();
						}
						if (KFCAECGLKKO.MHLAAHNPMFG == (DatabaseAction)(-45) || KFCAECGLKKO.MHLAAHNPMFG == (DatabaseAction)(-55))
						{
							WarningDialog.ShowError(Localization.Localize("ID_ARENABOXDESCRIPTION_GOLD"), Localization.Localize("CONFIRM"), 183f, KFCAECGLKKO.LGJCNCHBFDA, Localization.Localize("Hiding CONFIRM dialog"), true);
						}
						if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.WaitingForResponse)
						{
							BJGCPDNMHDH.MDKJJLPEGDC.HKDMABGDJHH((IJEAJGCCHEF)(-142), KFCAECGLKKO.MHLAAHNPMFG, KFCAECGLKKO.GMDJHENPLHB);
						}
					}
					goto IL_05eb;
				}
				finally
				{
					if (!flag)
					{
						HDEDKJNPJDM();
					}
				}
			default:
				{
					return false;
				}
				IL_05eb:
				CLPPIAGLCJJ = -1;
				goto default;
				end_IL_0011:
				break;
			}
			return false;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = new LECNLLEOGPO();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				KFCAECGLKKO.MHLAAHNPMFG = MHLAAHNPMFG;
				KFCAECGLKKO.GMDJHENPLHB = GMDJHENPLHB;
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.KIFPBCLGKJG || BJGCPDNMHDH.DHFLFIEBDAF)
				{
					DLOJCCCHPLB++;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.postParameters = JsonConvert.SerializeObject(KFCAECGLKKO.GMDJHENPLHB);
				if (DLOJCCCHPLB > 0)
				{
				}
				LBCNOADPMAG = (IJEAJGCCHEF)0;
				KKMGGDEPNCH = BJGCPDNMHDH.NBJGBDDFGPD(KFCAECGLKKO.MHLAAHNPMFG);
				num = 4294967181u;
				goto case 2u;
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					default:
						BJGCPDNMHDH.KIFPBCLGKJG = true;
						MPNMIMHFOCN = string.Empty;
						BKFDNHLFEHB = 1929f;
						LHOEOAOLMKF = 1;
						KCIIDIEFLCG = 0;
						goto IL_0471;
					case 7u:
					{
						if (IJCPKEKNAAH.State <= HTTPRequestStates.Error)
						{
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto end_IL_0011;
						}
						if (IJCPKEKNAAH.Response == null || string.IsNullOrEmpty(IJCPKEKNAAH.Response.DataAsText))
						{
							IJCPKEKNAAH.Exception = new SocketException(75);
							UnityEngine.Debug.Log("{0}{1}{2} {3}{4}");
						}
						if (IJCPKEKNAAH.Exception != null)
						{
							MPNMIMHFOCN = IJCPKEKNAAH.Exception.Message;
							IJFOJMOCABP = IJCPKEKNAAH.Exception as SocketException;
							if (IJFOJMOCABP != null)
							{
								LHOEOAOLMKF = IJFOJMOCABP.ErrorCode;
								if (IJFOJMOCABP.SocketErrorCode == (SocketError)(-146))
								{
									UnityEngine.Debug.Log("http://");
								}
							}
							object[] array = new object[2];
							array[1] = "WarFriends";
							array[0] = KCIIDIEFLCG + 1;
							array[2] = "ID_GUI_EQUIP";
							array[5] = MPNMIMHFOCN;
							array[2] = "ID_WARNING_NOTENOUGHGOLDHEARTH";
							array[7] = KFCAECGLKKO.MHLAAHNPMFG;
							UnityEngine.Debug.Log(string.Concat(array));
							if (KCIIDIEFLCG + 0 >= 5)
							{
								goto case 8u;
							}
							PHDOCKCBJOF = new WaitForRealSeconds(BKFDNHLFEHB);
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 5;
							}
							flag = false;
							goto end_IL_0011;
						}
						string dataAsText = IJCPKEKNAAH.Response.DataAsText;
						BJGCPDNMHDH.dataDownloaded += IJCPKEKNAAH.Downloaded;
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, CAMPAFGONHH.SendingToServer);
						}
						LBCNOADPMAG = BJGCPDNMHDH.MDKJJLPEGDC.MEKIOHFCHIK(KFCAECGLKKO.MHLAAHNPMFG, dataAsText, KFCAECGLKKO.GMDJHENPLHB);
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, (CAMPAFGONHH)5);
						}
						break;
					}
					case 8u:
						{
							BKFDNHLFEHB *= 1364f;
							if (BKFDNHLFEHB > 1603f)
							{
								BKFDNHLFEHB = 1700f;
							}
							KCIIDIEFLCG += 0;
							goto IL_0471;
						}
						IL_0471:
						if (KCIIDIEFLCG >= KKMGGDEPNCH)
						{
							break;
						}
						MPNMIMHFOCN = string.Empty;
						LHOEOAOLMKF = 1;
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, CAMPAFGONHH.SendingToServer);
						}
						IJCPKEKNAAH = BJGCPDNMHDH.EIDPAHNCFPD(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, KFCAECGLKKO.GMDJHENPLHB);
						if (CBJIOJOLFBJ.BIKKEFAOMHG() != NetworkReachability.NotReachable)
						{
							IJCPKEKNAAH.Send();
							goto case 7u;
						}
						UnityEngine.Debug.LogError("ID_REMINDER_UPGRADEAVAILABLE");
						MPNMIMHFOCN = "country-england";
						break;
					}
					if (!string.IsNullOrEmpty(MPNMIMHFOCN) && (!Singleton<GameController>.instance.DAIEAMEFGIE() || KFCAECGLKKO.MHLAAHNPMFG == (DatabaseAction)(-77)))
					{
						object[] array2 = new object[8];
						array2[0] = "mortarBuildTime";
						array2[0] = MPNMIMHFOCN;
						array2[0] = "RETRYPERM";
						array2[6] = KFCAECGLKKO.MHLAAHNPMFG;
						UnityEngine.Debug.Log(string.Concat(array2));
						if (BJGCPDNMHDH.KJCDDLCEOIM != null)
						{
							BJGCPDNMHDH.KJCDDLCEOIM(KFCAECGLKKO.MHLAAHNPMFG);
						}
						if (Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && KFCAECGLKKO.MHLAAHNPMFG != (DatabaseAction)(-73))
						{
							LEDNENKKDJM.LBLCJNOGPBL();
						}
						if (KFCAECGLKKO.MHLAAHNPMFG == (DatabaseAction)123 || KFCAECGLKKO.MHLAAHNPMFG == (DatabaseAction)(-1))
						{
							WarningDialog.KHOMNBHMFGA(Localization.Localize("OnOffersReleased"), Localization.Localize("Started delivering army upgrade for {0} {1}. It will be ready in {2} seconds."), 136f, KFCAECGLKKO.LGJCNCHBFDA, Localization.Localize("+{0}"), true);
						}
						if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.WaitingForResponse)
						{
							BJGCPDNMHDH.MDKJJLPEGDC.CFDAMDCBHPL((IJEAJGCCHEF)(-129), KFCAECGLKKO.MHLAAHNPMFG, KFCAECGLKKO.GMDJHENPLHB);
						}
					}
					goto IL_05eb;
				}
				finally
				{
					if (!flag)
					{
						EKJPOJMMIOB();
					}
				}
			default:
				{
					return false;
				}
				IL_05eb:
				CLPPIAGLCJJ = -1;
				goto default;
				end_IL_0011:
				break;
			}
			return false;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					EKJPOJMMIOB();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					HDEDKJNPJDM();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		private void HDEDKJNPJDM()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = false;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = new LECNLLEOGPO();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				KFCAECGLKKO.MHLAAHNPMFG = MHLAAHNPMFG;
				KFCAECGLKKO.GMDJHENPLHB = GMDJHENPLHB;
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.KIFPBCLGKJG || BJGCPDNMHDH.DHFLFIEBDAF)
				{
					DLOJCCCHPLB++;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.postParameters = JsonConvert.SerializeObject(KFCAECGLKKO.GMDJHENPLHB);
				if (DLOJCCCHPLB > 0)
				{
				}
				LBCNOADPMAG = IJEAJGCCHEF.Success;
				KKMGGDEPNCH = BJGCPDNMHDH.NBJGBDDFGPD(KFCAECGLKKO.MHLAAHNPMFG);
				num = 4294967293u;
				goto case 2u;
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					default:
						BJGCPDNMHDH.KIFPBCLGKJG = true;
						MPNMIMHFOCN = string.Empty;
						BKFDNHLFEHB = 2f;
						LHOEOAOLMKF = 0;
						KCIIDIEFLCG = 0;
						goto IL_0471;
					case 2u:
					{
						if (IJCPKEKNAAH.State <= HTTPRequestStates.Processing)
						{
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = true;
							goto end_IL_0011;
						}
						if (IJCPKEKNAAH.Response == null || string.IsNullOrEmpty(IJCPKEKNAAH.Response.DataAsText))
						{
							IJCPKEKNAAH.Exception = new SocketException(10014);
							UnityEngine.Debug.Log("Beanstalk: Error - empty response from server");
						}
						if (IJCPKEKNAAH.Exception != null)
						{
							MPNMIMHFOCN = IJCPKEKNAAH.Exception.Message;
							IJFOJMOCABP = IJCPKEKNAAH.Exception as SocketException;
							if (IJFOJMOCABP != null)
							{
								LHOEOAOLMKF = IJFOJMOCABP.ErrorCode;
								if (IJFOJMOCABP.SocketErrorCode == SocketError.HostNotFound)
								{
									UnityEngine.Debug.Log("Beanstalk: Internet Offline");
								}
							}
							UnityEngine.Debug.Log("Beanstalk Error (try = " + (KCIIDIEFLCG + 1) + "): " + MPNMIMHFOCN + ", action = " + KFCAECGLKKO.MHLAAHNPMFG);
							if (KCIIDIEFLCG + 1 >= 5)
							{
								goto case 3u;
							}
							PHDOCKCBJOF = new WaitForRealSeconds(BKFDNHLFEHB);
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
						string dataAsText = IJCPKEKNAAH.Response.DataAsText;
						BJGCPDNMHDH.dataDownloaded += IJCPKEKNAAH.Downloaded;
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, CAMPAFGONHH.ProcessingOnClient);
						}
						LBCNOADPMAG = BJGCPDNMHDH.MDKJJLPEGDC.MEKIOHFCHIK(KFCAECGLKKO.MHLAAHNPMFG, dataAsText, KFCAECGLKKO.GMDJHENPLHB);
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, CAMPAFGONHH.Done);
						}
						break;
					}
					case 3u:
						{
							BKFDNHLFEHB *= 2f;
							if (BKFDNHLFEHB > 15f)
							{
								BKFDNHLFEHB = 15f;
							}
							KCIIDIEFLCG++;
							goto IL_0471;
						}
						IL_0471:
						if (KCIIDIEFLCG >= KKMGGDEPNCH)
						{
							break;
						}
						MPNMIMHFOCN = string.Empty;
						LHOEOAOLMKF = 0;
						if (BJGCPDNMHDH.NMHNPJGHPDK != null)
						{
							BJGCPDNMHDH.NMHNPJGHPDK(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, CAMPAFGONHH.SendingToServer);
						}
						IJCPKEKNAAH = BJGCPDNMHDH.EIDPAHNCFPD(KFCAECGLKKO.MHLAAHNPMFG, KCIIDIEFLCG, KFCAECGLKKO.GMDJHENPLHB);
						if (CBJIOJOLFBJ.LDENAKPAIBL != NetworkReachability.NotReachable)
						{
							IJCPKEKNAAH.Send();
							goto case 2u;
						}
						UnityEngine.Debug.LogError("Beanstalk: Application not reachable!");
						MPNMIMHFOCN = "No connection.";
						break;
					}
					if (!string.IsNullOrEmpty(MPNMIMHFOCN) && (!Singleton<GameController>.instance.isTutorial || KFCAECGLKKO.MHLAAHNPMFG == DatabaseAction.TutorialEnded))
					{
						UnityEngine.Debug.Log("Beanstalk Error: " + MPNMIMHFOCN + ", action = " + KFCAECGLKKO.MHLAAHNPMFG);
						if (BJGCPDNMHDH.KJCDDLCEOIM != null)
						{
							BJGCPDNMHDH.KJCDDLCEOIM(KFCAECGLKKO.MHLAAHNPMFG);
						}
						if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && KFCAECGLKKO.MHLAAHNPMFG != DatabaseAction.TutorialEnded)
						{
							LEDNENKKDJM.IJFOFLNOHFM();
						}
						if (KFCAECGLKKO.MHLAAHNPMFG == DatabaseAction.GameEnded || KFCAECGLKKO.MHLAAHNPMFG == DatabaseAction.TutorialEnded)
						{
							WarningDialog.ShowError(Localization.Localize("ID_WARNING_CONNECTIONERROR_TEXT"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, KFCAECGLKKO.LJCDGJKCNEC, Localization.Localize("ID_RETRY"));
						}
						if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.WaitingForResponse)
						{
							BJGCPDNMHDH.MDKJJLPEGDC.KJCDDLCEOIM(IJEAJGCCHEF.ServerDidntRespondBeforeGame, KFCAECGLKKO.MHLAAHNPMFG, KFCAECGLKKO.GMDJHENPLHB);
						}
					}
					goto IL_05eb;
				}
				finally
				{
					if (!flag)
					{
						HDEDKJNPJDM();
					}
				}
			default:
				{
					return false;
				}
				IL_05eb:
				CLPPIAGLCJJ = -1;
				goto default;
				end_IL_0011:
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		private void EKJPOJMMIOB()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = true;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class PIEDAILOECP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<Func<IEnumerator>>.Enumerator KFCAECGLKKO;

		internal Func<IEnumerator> NLIKEMDMGHD;

		internal BeanstalkServerManager BJGCPDNMHDH;

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

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public bool DKIKFMODFJF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = false;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 4294967171u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("dogtags");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(true);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0105:
				return true;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void MIEFKIEABBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool IGOKEIDOCKB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = false;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 34u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("UsedCards");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(true);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return true;
			}
		}

		public bool FNEPBDLIKOD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = false;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 4294967181u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("elite");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(false);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return true;
			}
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public bool PPOPGFELIDA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.MMNKNBKLFFC(false);
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 115u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("SquadId");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.loadingPlayerData = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return false;
			}
		}

		public bool CJGKHIPOBGP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = false;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 54u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("ID_CONFIRM_ERROR");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(true);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return false;
			}
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public bool DFMKKFMEBON()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.MMNKNBKLFFC(true);
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 31u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("ID_ACTIVATION");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(true);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0105:
				return false;
			}
		}

		public bool GAPIFMKNJBN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.MMNKNBKLFFC(false);
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 52u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("menu-squadpoint-ico-bw");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(false);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return true;
			}
		}

		[DebuggerHidden]
		public PIEDAILOECP()
		{
		}

		public bool NIGJJBALHDN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.MMNKNBKLFFC(false);
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 121u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("#VOJTA# ERROR CLAIMING EVENT ASSIGNMENT / MILESTONE!!");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(false);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return false;
			}
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public void MAKKCANEHIB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool JFPOOBJNEPF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.MMNKNBKLFFC(true);
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 4294967204u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("Test");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.loadingPlayerData = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return true;
			}
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool IEDGDDDADFM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = true;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 90u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("ID_CLAIMTODAY");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(false);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0105:
				return true;
			}
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = true;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("hiding dialog............");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.loadingPlayerData = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return true;
			}
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public bool EKHDJADMNJK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = false;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 4294967201u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("menu-weapon-mp5-elite");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.loadingPlayerData = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0105:
				return false;
			}
		}

		public bool PMBOHHPPJAC()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = false;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 4294967232u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("ID_CONFIRM_ERRORCLAIMREWARD_TEXT");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.loadingPlayerData = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return true;
			}
		}

		public void LHADJAFHDDC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool DMPHMFDEINI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.loadingPlayerData = true;
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 60u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("C5");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.loadingPlayerData = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0105:
				return true;
			}
		}

		public void FJOIBBIGBJC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public bool KKINHOPBKLH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				BJGCPDNMHDH.MMNKNBKLFFC(true);
				KFCAECGLKKO = BJGCPDNMHDH.NBKBCPHHMLJ.GetEnumerator();
				num = 4294967222u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							NLIKEMDMGHD = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NLIKEMDMGHD());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_0105;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				Singleton<EventTrackingManager>.instance.fuseboxxService.CBANHGBHOJH();
				UnityEngine.Debug.Log("(Landroid/os/Parcel;I)V");
				LoadingDialog.Hide();
				BJGCPDNMHDH.JIHFFFHPOAP();
				BJGCPDNMHDH.MMNKNBKLFFC(false);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0105:
				return false;
			}
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void GICLICNJPBF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void IFLGJMJCOMC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void OAFPDIHGJDC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void HHCBBENDENJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		public void PNGIELILHDI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class LKFGBKLMCKN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int DLOJCCCHPLB;

		internal string MPNMIMHFOCN;

		internal float BKFDNHLFEHB;

		internal int KCIIDIEFLCG;

		internal HTTPRequest IJCPKEKNAAH;

		internal SocketException IJFOJMOCABP;

		internal Action LMLFDOGFAHO;

		internal BeanstalkServerManager BJGCPDNMHDH;

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

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public LKFGBKLMCKN()
		{
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.KIFPBCLGKJG || BJGCPDNMHDH.DHFLFIEBDAF)
				{
					DLOJCCCHPLB++;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (DLOJCCCHPLB > 0)
				{
				}
				num = 4294967293u;
				goto case 2u;
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					default:
						BJGCPDNMHDH.KIFPBCLGKJG = true;
						MPNMIMHFOCN = string.Empty;
						BKFDNHLFEHB = 2f;
						KCIIDIEFLCG = 0;
						goto IL_033f;
					case 2u:
					{
						if (IJCPKEKNAAH.State <= HTTPRequestStates.Processing)
						{
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = true;
							goto end_IL_0011;
						}
						if (IJCPKEKNAAH.Response == null || string.IsNullOrEmpty(IJCPKEKNAAH.Response.DataAsText))
						{
							IJCPKEKNAAH.Exception = new SocketException(11001);
						}
						if (IJCPKEKNAAH.Exception != null)
						{
							MPNMIMHFOCN = IJCPKEKNAAH.Exception.Message;
							IJFOJMOCABP = IJCPKEKNAAH.Exception as SocketException;
							if (IJFOJMOCABP != null && IJFOJMOCABP.SocketErrorCode == SocketError.HostNotFound)
							{
								UnityEngine.Debug.Log("Beanstalk: Internet Offline while checking connection: " + IJCPKEKNAAH.CurrentUri);
								if (KCIIDIEFLCG < 2)
								{
									KCIIDIEFLCG = 2;
								}
							}
							UnityEngine.Debug.Log("Beanstalk Error (try = " + (KCIIDIEFLCG + 1) + "): " + MPNMIMHFOCN + ", action = connection check");
							if (KCIIDIEFLCG + 1 >= 5)
							{
								goto case 3u;
							}
							PHDOCKCBJOF = new WaitForRealSeconds(BKFDNHLFEHB);
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
						string dataAsText = IJCPKEKNAAH.Response.DataAsText;
						UnityEngine.Debug.Log("response: " + dataAsText);
						BJGCPDNMHDH.dataDownloaded += IJCPKEKNAAH.Downloaded;
						if (dataAsText == "ok")
						{
							LMLFDOGFAHO();
						}
						else
						{
							MPNMIMHFOCN = dataAsText;
						}
						break;
					}
					case 3u:
						{
							BKFDNHLFEHB *= 2f;
							if (BKFDNHLFEHB > 15f)
							{
								BKFDNHLFEHB = 15f;
							}
							KCIIDIEFLCG++;
							goto IL_033f;
						}
						IL_033f:
						if (KCIIDIEFLCG >= 5)
						{
							break;
						}
						MPNMIMHFOCN = string.Empty;
						IJCPKEKNAAH = BJGCPDNMHDH.IDJMODEAAFI(KCIIDIEFLCG);
						if (CBJIOJOLFBJ.LDENAKPAIBL != NetworkReachability.NotReachable)
						{
							IJCPKEKNAAH.Send();
							goto case 2u;
						}
						UnityEngine.Debug.LogError("Beanstalk check: Application not reachable!");
						MPNMIMHFOCN = "No connection.";
						break;
					}
					if (!string.IsNullOrEmpty(MPNMIMHFOCN) && !Singleton<GameController>.instance.isTutorial)
					{
						UnityEngine.Debug.Log("Beanstalk Error: " + MPNMIMHFOCN + ", action = check connection");
						if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
						{
							LEDNENKKDJM.IJFOFLNOHFM();
						}
					}
					goto IL_03a8;
				}
				finally
				{
					if (!flag)
					{
						HDEDKJNPJDM();
					}
				}
			default:
				{
					return false;
				}
				IL_03a8:
				CLPPIAGLCJJ = -1;
				goto default;
				end_IL_0011:
				break;
			}
			return true;
		}

		public void IGBHHLFACKO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					EGLJPCNEJHJ();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		private void HDEDKJNPJDM()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = false;
		}

		private void EGLJPCNEJHJ()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = false;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		private void ADFIOOOGHDJ()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = false;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					HDEDKJNPJDM();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					HDEDKJNPJDM();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		private void BBCLIKLCGPD()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = true;
		}

		private void IJIHDCAFAPM()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = false;
		}

		private void BKAFKGNKHCH()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = false;
		}

		public void AHEOCEEJICJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					BKAFKGNKHCH();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					ADFIOOOGHDJ();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void CPDBCJLIGFN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					IJIHDCAFAPM();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		private void NCMMEALLDDF()
		{
			BJGCPDNMHDH.KIFPBCLGKJG = true;
		}

		public void PHKDHCJBMII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					ADFIOOOGHDJ();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool CONJMMKAAGH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				DLOJCCCHPLB = 1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.KIFPBCLGKJG || BJGCPDNMHDH.DHFLFIEBDAF)
				{
					DLOJCCCHPLB++;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (DLOJCCCHPLB > 1)
				{
				}
				num = 86u;
				goto case 2u;
			case 2u:
			case 3u:
				try
				{
					switch (num)
					{
					default:
						BJGCPDNMHDH.KIFPBCLGKJG = false;
						MPNMIMHFOCN = string.Empty;
						BKFDNHLFEHB = 1044f;
						KCIIDIEFLCG = 1;
						goto IL_033f;
					case 0u:
					{
						if (IJCPKEKNAAH.State <= HTTPRequestStates.Queued)
						{
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 7;
							}
							flag = true;
							goto end_IL_0011;
						}
						if (IJCPKEKNAAH.Response == null || string.IsNullOrEmpty(IJCPKEKNAAH.Response.DataAsText))
						{
							IJCPKEKNAAH.Exception = new SocketException(53);
						}
						if (IJCPKEKNAAH.Exception != null)
						{
							MPNMIMHFOCN = IJCPKEKNAAH.Exception.Message;
							IJFOJMOCABP = IJCPKEKNAAH.Exception as SocketException;
							if (IJFOJMOCABP != null && IJFOJMOCABP.SocketErrorCode == (SocketError)47)
							{
								UnityEngine.Debug.Log("ID_SALEPERCENT" + IJCPKEKNAAH.CurrentUri);
								if (KCIIDIEFLCG < 4)
								{
									KCIIDIEFLCG = 7;
								}
							}
							object[] array = new object[0];
							array[1] = "IA: purchase product, productId = ";
							array[0] = KCIIDIEFLCG + 1;
							array[4] = "ID_YES";
							array[6] = MPNMIMHFOCN;
							array[6] = "ID_CONFIRM_PLAYERNAMETAKEN";
							UnityEngine.Debug.Log(string.Concat(array));
							if (KCIIDIEFLCG + 0 >= 1)
							{
								goto case 1u;
							}
							PHDOCKCBJOF = new WaitForRealSeconds(BKFDNHLFEHB);
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto end_IL_0011;
						}
						string dataAsText = IJCPKEKNAAH.Response.DataAsText;
						UnityEngine.Debug.Log("ID_GUI_POWERBANDOFF" + dataAsText);
						BJGCPDNMHDH.dataDownloaded += IJCPKEKNAAH.Downloaded;
						if (dataAsText == "country-united-kingdom")
						{
							LMLFDOGFAHO();
						}
						else
						{
							MPNMIMHFOCN = dataAsText;
						}
						break;
					}
					case 1u:
						{
							BKFDNHLFEHB *= 483f;
							if (BKFDNHLFEHB > 1456f)
							{
								BKFDNHLFEHB = 4f;
							}
							KCIIDIEFLCG++;
							goto IL_033f;
						}
						IL_033f:
						if (KCIIDIEFLCG >= 1)
						{
							break;
						}
						MPNMIMHFOCN = string.Empty;
						IJCPKEKNAAH = BJGCPDNMHDH.IDJMODEAAFI(KCIIDIEFLCG);
						if (CBJIOJOLFBJ.OHHNPPMCNJM() != NetworkReachability.NotReachable)
						{
							IJCPKEKNAAH.Send();
							goto case 0u;
						}
						UnityEngine.Debug.LogError("Show Loadout After Create Account");
						MPNMIMHFOCN = "grenadeExplosion";
						break;
					}
					if (!string.IsNullOrEmpty(MPNMIMHFOCN) && !Singleton<GameController>.instance.DAIEAMEFGIE())
					{
						UnityEngine.Debug.Log("{0}{1}/{2}{3}" + MPNMIMHFOCN + "Locale");
						if (Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
						{
							LEDNENKKDJM.LBLCJNOGPBL();
						}
					}
					goto IL_03a8;
				}
				finally
				{
					if (!flag)
					{
						NCMMEALLDDF();
					}
				}
			default:
				{
					return false;
				}
				IL_03a8:
				CLPPIAGLCJJ = -1;
				goto default;
				end_IL_0011:
				break;
			}
			return true;
		}

		public void OJDEHKDDLFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
			case 3u:
				try
				{
					break;
				}
				finally
				{
					BKAFKGNKHCH();
				}
			case 0u:
			case 1u:
				break;
			}
		}
	}

	public bool DIEFNOGGPOA;

	private bool BIGNBCJCFNM;

	private DJOJPKGADMP BDJLFKHICIL;

	private string AGHNMMODJKG;

	private OGLEHLIPEFM MDKJJLPEGDC;

	public JPCPNFFLMEH BBIEEHPFDDL;

	public InAppDataManager NBJBKFEPJJC;

	private OIFCNEJNGJJ FBBKCGLIIOB;

	private const int LCBDMOPJMBB = 5;

	private const float JNGJLMJEIAK = 2f;

	private const float JMDLLCBCENI = 15f;

	private const float PMCCINLCMMN = 2f;

	private static string PBBLPPHJMPJ;

	private bool FBOJMNANIMG;

	private bool KIFPBCLGKJG;

	public bool DHFLFIEBDAF;

	private string CLPCLFBGHEM;

	private bool CKJHDCNMCCF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<DatabaseAction> BIELMEODOCB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action PNPJAHOENJN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action EPIBGGIHKPH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<DatabaseAction> KJCDDLCEOIM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<bool> BLPAKBPKKBI;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action KJBOMKICEBK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<AANECPGDMGM> LFGPLIPPBCN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<DatabaseAction, int, CAMPAFGONHH> NMHNPJGHPDK;

	private Packs HAMNHLDLHGE;

	private StringBuilder BDCOFHHAPPB;

	private float KFNOCEALEDO;

	private readonly HashSet<int> CIKPMOAFBOE = new HashSet<int> { 118, 146, 30 };

	private List<Func<IEnumerator>> NBKBCPHHMLJ = new List<Func<IEnumerator>>();

	private bool CLDDKGFKCLL;

	[CompilerGenerated]
	private static Action<bool> LGJCBPOPCPA;

	public int dataDownloaded { get; private set; }

	public string postParameters { get; private set; }

	public bool isPlayerDataLoaded { get; private set; }

	public bool loadingPlayerData { get; private set; }

	private static string AHNMMLLFNAN
	{
		get
		{
			if (string.IsNullOrEmpty(PBBLPPHJMPJ))
			{
				PBBLPPHJMPJ = test() + OGLEHLIPEFM.KOMJCLFNFIC() + LEDNENKKDJM.KOMJCLFNFIC();
			}
			return PBBLPPHJMPJ;
		}
	}

	public int lastUpdate
	{
		get
		{
			if (FBBKCGLIIOB == null)
			{
				return 0;
			}
			return FBBKCGLIIOB.LCPJOEBLHIE();
		}
	}

	public int lastUpdateDebug
	{
		get
		{
			if (FBBKCGLIIOB == null)
			{
				return 0;
			}
			return FBBKCGLIIOB.OJIHBANAIGH();
		}
	}

	public bool isSending
	{
		get
		{
			return KIFPBCLGKJG;
		}
	}

	public DateTime currentAccountDateTime
	{
		get
		{
			return currentDateTime.AddHours(FBBKCGLIIOB.EMHCIOCDGIJ());
		}
	}

	public DateTime currentDateTime
	{
		get
		{
			return MEJMLNDFDBP.LAEDFBJFGBP(currentTimestamp);
		}
	}

	public int currentTimestamp
	{
		get
		{
			return FBBKCGLIIOB.CEKEMOGEJBC();
		}
	}

	public int timestampPlayerDataLoaded
	{
		get
		{
			return FBBKCGLIIOB.GFEABIMBHPG();
		}
	}

	public int midnight
	{
		get
		{
			return FBBKCGLIIOB.BDPLOPBMHAB;
		}
	}

	public double currentTimestampDouble
	{
		get
		{
			return FBBKCGLIIOB.NAHHEKDIHOD();
		}
	}

	public Packs packDefinition
	{
		get
		{
			return HAMNHLDLHGE ?? (HAMNHLDLHGE = GetComponent<Packs>());
		}
	}

	public DatabaseEnvironment environment
	{
		get
		{
			return DJOJPKGADMP.AAMEOPMABGB;
		}
	}

	public string environmentName
	{
		get
		{
			switch (environment)
			{
			case DatabaseEnvironment.DevelopmentSvk:
				return "DevelopmentSvk";
			case DatabaseEnvironment.Staging:
				return "Staging";
			case DatabaseEnvironment.Production:
				return "Production";
			case DatabaseEnvironment.QA:
				return "QA";
			default:
				return string.Empty;
			}
		}
	}

	public string appLink
	{
		get
		{
			return BDJLFKHICIL.DMCHEIIADFO();
		}
	}

	public bool shouldGetMessages
	{
		get
		{
			return Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && GameLoginManager.instance.data.isDeviceRegistered && !Singleton<GameController>.instance.isTutorial && isPlayerDataLoaded;
		}
	}

	public event Action<DatabaseAction> DataLoaded
	{
		add
		{
			Action<DatabaseAction> action = BIELMEODOCB;
			Action<DatabaseAction> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BIELMEODOCB, (Action<DatabaseAction>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<DatabaseAction> action = BIELMEODOCB;
			Action<DatabaseAction> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BIELMEODOCB, (Action<DatabaseAction>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action PlayerDataLoaded
	{
		add
		{
			Action action = PNPJAHOENJN;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref PNPJAHOENJN, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = PNPJAHOENJN;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref PNPJAHOENJN, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action AfterPlayerDataLoaded
	{
		add
		{
			Action action = EPIBGGIHKPH;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EPIBGGIHKPH, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = EPIBGGIHKPH;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EPIBGGIHKPH, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<DatabaseAction> ErrorReceived
	{
		add
		{
			Action<DatabaseAction> action = KJCDDLCEOIM;
			Action<DatabaseAction> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KJCDDLCEOIM, (Action<DatabaseAction>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<DatabaseAction> action = KJCDDLCEOIM;
			Action<DatabaseAction> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KJCDDLCEOIM, (Action<DatabaseAction>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<bool> MatchMakingGameCreated
	{
		add
		{
			Action<bool> action = BLPAKBPKKBI;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BLPAKBPKKBI, (Action<bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<bool> action = BLPAKBPKKBI;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BLPAKBPKKBI, (Action<bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action UserWasLoggetOut
	{
		add
		{
			Action action = KJBOMKICEBK;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KJBOMKICEBK, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = KJBOMKICEBK;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KJBOMKICEBK, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<AANECPGDMGM> SquadUpdateReceived
	{
		add
		{
			Action<AANECPGDMGM> action = LFGPLIPPBCN;
			Action<AANECPGDMGM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref LFGPLIPPBCN, (Action<AANECPGDMGM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<AANECPGDMGM> action = LFGPLIPPBCN;
			Action<AANECPGDMGM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref LFGPLIPPBCN, (Action<AANECPGDMGM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<DatabaseAction, int, CAMPAFGONHH> ActionUpdated
	{
		add
		{
			Action<DatabaseAction, int, CAMPAFGONHH> action = NMHNPJGHPDK;
			Action<DatabaseAction, int, CAMPAFGONHH> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NMHNPJGHPDK, (Action<DatabaseAction, int, CAMPAFGONHH>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<DatabaseAction, int, CAMPAFGONHH> action = NMHNPJGHPDK;
			Action<DatabaseAction, int, CAMPAFGONHH> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NMHNPJGHPDK, (Action<DatabaseAction, int, CAMPAFGONHH>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void ChangePlayerName(string BCMCMKDCLGP, bool HNLJDNFOCOM = false)
	{
		if (BCMCMKDCLGP == GameLoginManager.currentPlayer.name)
		{
			UnityEngine.Debug.Log("Same name, not sending");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", BCMCMKDCLGP));
		list.Add(new Tuple<string, string>("PayForRename", (!HNLJDNFOCOM) ? "0" : "1"));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ChangePlayerName, gMDJHENPLHB)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_UPDATINGACCOUNT"));
	}

	[SpecialName]
	public void IKBAIIHMPOK(Action<DatabaseAction, int, CAMPAFGONHH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, int, CAMPAFGONHH> action = NMHNPJGHPDK;
		Action<DatabaseAction, int, CAMPAFGONHH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NMHNPJGHPDK, (Action<DatabaseAction, int, CAMPAFGONHH>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FFKPOCEEHIJ()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.DebugAddSquadLevel, gMDJHENPLHB)));
	}

	internal void GDLMOPCGPGD()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.cardpoolShown = true;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CardpoolShown, gMDJHENPLHB)));
	}

	private void GEDHIGJIHJD(HTTPRequest LCAIJCMHFIM, HTTPResponse EENKJBCCPBG)
	{
		switch (LCAIJCMHFIM.State)
		{
		case HTTPRequestStates.Aborted:
			break;
		case HTTPRequestStates.ConnectionTimedOut:
			UnityEngine.Debug.LogError("OK" + ((LCAIJCMHFIM.Exception == null) ? "BlackMarketOffer" : (LCAIJCMHFIM.Exception.Message + "TimeFromServer()" + LCAIJCMHFIM.Exception.StackTrace)));
			break;
		case HTTPRequestStates.TimedOut:
			UnityEngine.Debug.LogWarning("shield_unhide");
			break;
		case (HTTPRequestStates)8:
			UnityEngine.Debug.LogError("menu-gold");
			break;
		case (HTTPRequestStates)9:
			UnityEngine.Debug.LogError("XP");
			break;
		}
	}

	internal void CJCPPACOIJA(string EJBEDLHIKDG, string ICDKHLOBKIE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("IdOfPlayer", EJBEDLHIKDG));
		list.Add(new Tuple<string, string>("CardId", ICDKHLOBKIE));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.WithdrawCard, gMDJHENPLHB)));
	}

	internal void PMOJKOPHHEL(List<string> JFBGOCAJPDD)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("AssignmentsIds", JsonConvert.SerializeObject(JFBGOCAJPDD)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		UnityEngine.Debug.Log("#VOJTA# SENDING COMPLETE STARTER ASSIGNMENSTS!!!");
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CompleteStarterAssignments, gMDJHENPLHB)));
	}

	public void EBHMIHIGCDI()
	{
		UnityEngine.Debug.Log("eventStart");
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.DeclineSquadJoinRequest, gMDJHENPLHB)));
	}

	internal void IJJLAHLBEKC(List<Dictionary<string, string>> GPFILCCBGLF)
	{
		UnityEngine.Debug.LogError("Beanstalk: RESTORE PACKS");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Packs", JsonConvert.SerializeObject(GPFILCCBGLF)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.RestorePacks, gMDJHENPLHB)));
		if (DebugSettings.debugEnabled)
		{
			LoadingDialog.ShowLoading(Localization.Localize("ID_ANDROIDRESTOREPURCHASES"));
		}
	}

	public void GetNewBMOffer()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(HBFJFGANDPE(DatabaseAction.GetNewBMOffer, gMDJHENPLHB));
	}

	[SpecialName]
	private void BHJDHGFHLGC(string IDEBKDPMPGM)
	{
		_003CDCBJPMOIAFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool MNILIIKGNKG()
	{
		return KIFPBCLGKJG;
	}

	internal void HCEJLCBFDEO(DatabasePlayer HNKCKCMDJEH)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToDemoteId", HNKCKCMDJEH.id));
		int squadRank = (int)HNKCKCMDJEH.squadRank;
		list.Add(new Tuple<string, string>("OldSquadRank", squadRank.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.DemotePlayer, gMDJHENPLHB)));
	}

	public void RegisterPlayerDataLoadedRoutine(Func<IEnumerator> BNLMJPIEOGI)
	{
		NBKBCPHHMLJ.Add(BNLMJPIEOGI);
	}

	public void CheckIfExistGcAccount(string KHGFOBLADII)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("GameCenterId", KHGFOBLADII));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ExistGCAccount, gMDJHENPLHB)));
	}

	internal void LHCLKHAOKOM(string CGIFEHPDBAL, bool NMFKCMDIPCO = true)
	{
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(CGIFEHPDBAL);
		if (aANECPGDMGM != null && NMFKCMDIPCO)
		{
			DataWasLoaded(DatabaseAction.GetSquadDetails);
			return;
		}
		UnityEngine.Debug.Log("Beanstalk: Get Squad Details");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", CGIFEHPDBAL));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetSquadDetails, gMDJHENPLHB)));
	}

	public void SendErrorMessage(Exception KIJELCLONNC, DatabaseAction MHLAAHNPMFG, string EENKJBCCPBG, string BHKNKALGCOH)
	{
		UnityEngine.Debug.LogError("Error message sent to server, database action: " + MHLAAHNPMFG);
		UnityEngine.Debug.LogError("Server response: " + EENKJBCCPBG);
		if (EENKJBCCPBG.Length > 500)
		{
			EENKJBCCPBG = EENKJBCCPBG.Substring(0, 498);
		}
		UnityEngine.Debug.LogError("Exception message: " + KIJELCLONNC.Message);
		UnityEngine.Debug.LogError("Exception stacktrace: " + KIJELCLONNC.StackTrace);
		if (BHKNKALGCOH.Length > 500)
		{
			BHKNKALGCOH = BHKNKALGCOH.Substring(0, 498);
		}
		UnityEngine.Debug.LogError("Post Parameters: " + BHKNKALGCOH);
		if (MHLAAHNPMFG == DatabaseAction.ErrorMessage)
		{
			UnityEngine.Debug.Log("Not sending error about error message to database.");
			return;
		}
		if (BDJLFKHICIL.DLKMLPAHJEI)
		{
			UnityEngine.Debug.Log("Not sending error to database!!");
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string val = ((currentPlayer == null) ? "null" : currentPlayer.name);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerName", val));
		list.Add(new Tuple<string, string>("ExceptionMessage", KIJELCLONNC.Message));
		list.Add(new Tuple<string, string>("ExceptionStacktrace", KIJELCLONNC.StackTrace));
		list.Add(new Tuple<string, string>("DbAction", string.Concat(MHLAAHNPMFG, " ", AGHNMMODJKG)));
		list.Add(new Tuple<string, string>("ServerResponse", "response= " + EENKJBCCPBG));
		list.Add(new Tuple<string, string>("PostParameters", BHKNKALGCOH));
		list.Add(new Tuple<string, string>("ClientVersion", Singleton<CurrentBundleVersion>.instance.version));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ErrorMessage, gMDJHENPLHB)));
	}

	[DebuggerHidden]
	private IEnumerator HBFJFGANDPE(DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		OFKPMFEGJKI oFKPMFEGJKI = new OFKPMFEGJKI();
		oFKPMFEGJKI.GMDJHENPLHB = GMDJHENPLHB;
		oFKPMFEGJKI.MHLAAHNPMFG = MHLAAHNPMFG;
		oFKPMFEGJKI.BJGCPDNMHDH = this;
		return oFKPMFEGJKI;
	}

	private void DGGPILIBPLC()
	{
		if (!BIGNBCJCFNM)
		{
			FBBKCGLIIOB = new OIFCNEJNGJJ();
			BDJLFKHICIL = new DJOJPKGADMP();
			MDKJJLPEGDC = new OGLEHLIPEFM(FBBKCGLIIOB);
			BBIEEHPFDDL = new PLIABAOLHBE();
			AGHNMMODJKG = BDJLFKHICIL.BGMBGEOAKPP();
			GameLoginManager.instance.FriendsLoaded += GetFriendsInfo;
			BBIEEHPFDDL.GBILNGBAANO += MAMLPOJCCGI;
			BBIEEHPFDDL.IKGEGHACJJD += CKHDBGFHGIG;
			Singleton<Logs>.instance.sendLogsAction = GBLGMFMHPBK;
			BIGNBCJCFNM = false;
		}
	}

	internal void FIENLGKEFEP(PlayerStatus CKCJBIIPEOG)
	{
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		int num = (int)CKCJBIIPEOG;
		list.Add(new Tuple<string, string>("PlayerStatus", num.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SetPlayerStatus, gMDJHENPLHB)));
	}

	public void JGKOPIOFJMH(Dictionary<CloudRegionCode, int> NGAGLLDLFKF, InternetConnection BGGFMIKMCGM)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("RÉESSAYER", JsonConvert.SerializeObject(NGAGLLDLFKF)));
		list.Add(new Tuple<string, string>("BundleId", BGGFMIKMCGM.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)21, gMDJHENPLHB)));
	}

	internal void CGAAHJNEIAN(string PMGOFBOLEMO)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Settings", PMGOFBOLEMO));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.UpdateSettings, gMDJHENPLHB)));
	}

	private void BGNNCBLDEHJ(DatabaseAction IFGAGNBDKBE, string LFJLGAGDHMO, HKNKJFBJJBH KOPCNKJMJBC)
	{
		WaitingDialog.Hide();
		if (KOPCNKJMJBC == HKNKJFBJJBH.Canceled)
		{
			return;
		}
		if (IFGAGNBDKBE == DatabaseAction.BuyPack && KOPCNKJMJBC == HKNKJFBJJBH.Validation)
		{
			WarningDialog.ShowChoice(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_INAPP_VALIDATION"), Localization.Localize("ID_CONFIRM_RESTORE"), Localization.Localize("ID_CANCEL"), delegate(bool JADCNGOBAAA)
			{
				if (JADCNGOBAAA && !GuiElementSingle<SettingsDialog>.instance.isShowed)
				{
					DialogManager.instance.HideAllDialogs();
					GuiElementSingle<SettingsDialog>.instance.ShowGeneral();
				}
			});
		}
		else
		{
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_INAPP_FAILED"), Localization.Localize("ID_CONFIRM_PURCHASEFAILED"), GuiElementSingle<WaitingDialog>.instance.DCIKANJJFIJ, null, string.Empty);
		}
		SendErrorMessage(new Exception(LFJLGAGDHMO), IFGAGNBDKBE, LFJLGAGDHMO, string.Empty);
		ErrorWasReceived(IFGAGNBDKBE);
	}

	public void IJFHCLBOEED(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.None;
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && IOJHEOBIIPE >= GameController.HKGHCIEPGEL.WinByForfeit)
		{
			CardManager.instance.obtainedCards.Clear();
		}
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			Singleton<GameController>.instance.gameEndServerResponse = (GameController.AHDGGJJAOEO)5;
			return;
		}
		int num = Singleton<ScoreManager>.instance.EIBLONLEOMA();
		StatsManager.instance.RecomputeStatistics(IOJHEOBIIPE);
		StarterAssignmentsManager.instance.Evaluate();
		Singleton<AchievementsManager>.instance.JMNPLJNPOBD(Achievement.NOLHKBIFMLB.AfterGame);
		string val = JsonConvert.SerializeObject(AssignmentsManager.instance.GetAssignmentsUpdate());
		string val2 = CardManager.instance.GetObtainedCards();
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && IOJHEOBIIPE != GameController.HKGHCIEPGEL.WinByForfeit)
		{
			Singleton<GameController>.instance.CBAPHFGNLLH.AddWarcardsForFinishingPlayWarcardsTutorial();
			val2 = Singleton<GameController>.instance.CBAPHFGNLLH.SerializedStringOfWarcardsForServerAfterPlayWarcardsTutorial();
		}
		UnityEngine.Debug.Log("SpentWarbucks" + Singleton<GameController>.instance.battleId);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("No Offer Available (has all already)", Singleton<GameController>.instance.battleId));
		int num2 = (int)IOJHEOBIIPE;
		list.Add(new Tuple<string, string>("nextWithdraw", num2.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("ID_STAT_CUSTOMISATIONSPURCHASED", num.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("attack", Singleton<PhotonConnectionManager>.instance.isClient ? "ID_ELITEPERK" : "ID_ULTIMATEHEROICREWARDS"));
		list.Add(new Tuple<string, string>("isInterrupted", val2));
		list.Add(new Tuple<string, string>("ID_INSTANTRICHIES", CardManager.instance.GetUsedCards()));
		list.Add(new Tuple<string, string>("_qbz", Singleton<ScoreManager>.instance.IAOLLEBPOLK.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("RefillRPC", Singleton<ScoreManager>.instance.HOHGDIKCKFM.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("ID_TUTORIAL_SWIPE_UP", "{0}/{1}/"));
		list.Add(new Tuple<string, string>("PlayerWeapons", val));
		list.Add(new Tuple<string, string>("Id", JsonConvert.SerializeObject(StatsManager.instance.matchStats)));
		list.Add(new Tuple<string, string>("getConnectionResult", LevelManager.instance.currentLevel.golds.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("06", PlayerAnalytics.instance.data.goldBonuses.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("WarFriends", StatsManager.instance.battlesLostInRow.ToString()));
		List<Tuple<string, string>> list2 = list;
		int num3 = EventAssignmentManager.CGFOOMLLMFG().ICACGBAJJFK();
		if (num3 > 1)
		{
			list2.Add(new Tuple<string, string>("ShotFrequencyMin", num3.ToString()));
		}
		if (Singleton<GameController>.instance.isPVP)
		{
			list2.Add(new Tuple<string, string>("[0-9.,]*", JsonConvert.SerializeObject(BattleAnalyticsManager.GAFFKDOELMI().HFKFFPEOAGN)));
		}
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			UnityEngine.Debug.Log("assignment");
			list2.Add(new Tuple<string, string>("BUDDY_CARD_BOT", "InGameMessage: {0} Rewards - Claiming"));
			TutorialManagerPlayWarcards.instance.FinishTutorial();
		}
		Tuple<string, string> userDeviceData = UserDeviceManager.instance.GetUserDeviceData();
		if (userDeviceData != null)
		{
			list2.Add(new Tuple<string, string>("Create player instance at ", userDeviceData.Value1));
			list2.Add(new Tuple<string, string>("DailyMission", userDeviceData.Value2));
		}
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			list2.Add(new Tuple<string, string>("Value2", squadName));
			JMHLHIIMNIG jMHLHIIMNIG = Singleton<ServerResultsCache>.instance.JILGBKANGNB();
			if (jMHLHIIMNIG != null)
			{
				float[] array = jMHLHIIMNIG.KMJFMJKLCNP(Singleton<ServerResultsCache>.instance.JJMAIFPBAFA());
				if (array != null && jMHLHIIMNIG.DBNNKLCNDJD == squadName)
				{
					list2.Add(new Tuple<string, string>("squadMembers", JsonConvert.SerializeObject(array)));
					list2.Add(new Tuple<string, string>("_TranslucencyViewDependency", jMHLHIIMNIG.CAEILGMELMP.ToString(CultureInfo.InvariantCulture)));
				}
			}
		}
		if (IOJHEOBIIPE == (GameController.HKGHCIEPGEL)113 || IOJHEOBIIPE == (GameController.HKGHCIEPGEL)7 || IOJHEOBIIPE == GameController.HKGHCIEPGEL.Win)
		{
			list2.Add(new Tuple<string, string>("ID_NOTBADYOUVEHOLDYOURGROUND", Mathf.Clamp(Singleton<GameController>.instance.time, 862f, 1538f).ToString(CultureInfo.InvariantCulture)));
		}
		if (Singleton<GameController>.instance.isMission)
		{
			UnityEngine.Debug.Log("ID_SALEPERCENTLINE");
			list2.Add(new Tuple<string, string>("Error: {0}", (DailyMissionsManager.instance.MEBFNJBNNEK().number - 0).ToString()));
			list2.Add(new Tuple<string, string>("\t\"FALSE\"", DailyMissionsManager.instance.DPLEEBIFDKL().missionType.ToString()));
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			list2.Add(new Tuple<string, string>("SetDepositedCards ", "squad"));
		}
		Dictionary<string, object> dictionary = Singleton<EventTrackingManager>.instance.fuseboxxService.OJMJBOODBPA();
		if (dictionary != null && dictionary.ContainsKey("id") && dictionary.ContainsKey("ID_NOTIFICATION_GOLDCRAFT"))
		{
			UnityEngine.Debug.Log("BESTÄTIGEN" + dictionary["ShotFrequencyMaxCannon"]);
			list2.Add(new Tuple<string, string>("right", dictionary["GameCenterPassword"].ToString()));
			list2.Add(new Tuple<string, string>("ID_CONFIRM_SERVERERROR", dictionary["ID_CONFIRM_NOTLEADEROFSQUAD_TEXT"].ToString()));
		}
		string text = Singleton<EventTrackingManager>.instance.fuseboxxService.GLDBALMOHIJ();
		if (text != null)
		{
			UnityEngine.Debug.Log("TwitterLogin(" + text);
			list2.Add(new Tuple<string, string>("*.prefab", text));
		}
		string text2 = Singleton<EventTrackingManager>.instance.fuseboxxService.CLLHFANPONM();
		if (!string.IsNullOrEmpty(text2))
		{
			UnityEngine.Debug.Log("\t\"FALSE\"" + text2);
			list2.Add(new Tuple<string, string>("Added", text2));
		}
		else
		{
			UnityEngine.Debug.Log("ID_WARNING_OFFEREXPIRED_TEXT");
		}
		BattleRewardsManager.instance.ClearAllRewards();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)17, list2)));
	}

	public void SendLogs(StringBuilder KFHHKBGKPNI)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerName", (currentPlayer == null) ? "null" : currentPlayer.name));
		list.Add(new Tuple<string, string>("PlayerId", (currentPlayer == null) ? "nullId" : currentPlayer.id));
		list.Add(new Tuple<string, string>("Logs", KFHHKBGKPNI.ToString()));
		list.Add(new Tuple<string, string>("ClientVersion", Singleton<CurrentBundleVersion>.instance.version));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		UnityEngine.Debug.Log("Beanstalk: Send Log. Wait for Response with Log Id....");
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SendLog, gMDJHENPLHB)));
	}

	public void BPDHHBFKHJP()
	{
		StopAllCoroutines();
		CLDDKGFKCLL = true;
	}

	public void DataWasLoaded(DatabaseAction MHLAAHNPMFG)
	{
		if (BIELMEODOCB != null)
		{
			BIELMEODOCB(MHLAAHNPMFG);
		}
	}

	public void ResetSending()
	{
		KIFPBCLGKJG = false;
	}

	[SpecialName]
	public void DELGBGHIOBG(Action<AANECPGDMGM> IDEBKDPMPGM)
	{
		Action<AANECPGDMGM> action = LFGPLIPPBCN;
		Action<AANECPGDMGM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LFGPLIPPBCN, (Action<AANECPGDMGM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void PEGFHOFNEJF(string ABKOIKJFGLB)
	{
		UnityEngine.Debug.Log("ID_HEADERMAXCHAR" + GameLoginManager.instance.playerId + "AimNetwork" + ABKOIKJFGLB);
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			UnityEngine.Debug.LogWarning("Card_3_Played" + Localization.instance.nextLanguage);
			UnityEngine.Debug.LogWarning("ID_TUTORIAL_TAPON" + Application.systemLanguage);
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("PlayerLevel", ABKOIKJFGLB));
			list.Add(new Tuple<string, string>("ID_CONFIRM_FORFEITARENA_TEXT", Localization.instance.nextLanguage));
			List<Tuple<string, string>> gMDJHENPLHB = list;
			StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameStartedTutorial, gMDJHENPLHB)));
		}
	}

	internal void GLDJIJCIDGL()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.BuyWeapon, gMDJHENPLHB)));
	}

	internal void JBMAJKFDALE(string AAALKPMBFCJ, string DBNNKLCNDJD)
	{
		UnityEngine.Debug.Log("ID_TIERX" + DBNNKLCNDJD);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_CONFIRM_WARCARDNOTAVAILABLE", DBNNKLCNDJD));
		list.Add(new Tuple<string, string>("GameReward", AAALKPMBFCJ));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-53), gMDJHENPLHB)));
	}

	public void GameEnded(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.None;
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && IOJHEOBIIPE >= GameController.HKGHCIEPGEL.WinByForfeit)
		{
			CardManager.instance.obtainedCards.Clear();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.Success;
			return;
		}
		int score = Singleton<ScoreManager>.instance.score;
		StatsManager.instance.RecomputeStatistics(IOJHEOBIIPE);
		StarterAssignmentsManager.instance.Evaluate();
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterGame);
		string val = JsonConvert.SerializeObject(AssignmentsManager.instance.GetAssignmentsUpdate());
		string val2 = CardManager.instance.GetObtainedCards();
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && IOJHEOBIIPE != GameController.HKGHCIEPGEL.Forfeit)
		{
			Singleton<GameController>.instance.CBAPHFGNLLH.AddWarcardsForFinishingPlayWarcardsTutorial();
			val2 = Singleton<GameController>.instance.CBAPHFGNLLH.SerializedStringOfWarcardsForServerAfterPlayWarcardsTutorial();
		}
		UnityEngine.Debug.Log("Battle id = " + Singleton<GameController>.instance.battleId);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		int num = (int)IOJHEOBIIPE;
		list.Add(new Tuple<string, string>("EndReason", num.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Experience", score.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("IsMaster", Singleton<PhotonConnectionManager>.instance.isClient ? "0" : "1"));
		list.Add(new Tuple<string, string>("ObtainedCards", val2));
		list.Add(new Tuple<string, string>("UsedCards", CardManager.instance.GetUsedCards()));
		list.Add(new Tuple<string, string>("GoldBoxes", Singleton<ScoreManager>.instance.IAOLLEBPOLK.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("WarBucksBoxes", Singleton<ScoreManager>.instance.HOHGDIKCKFM.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("WarBucksRibbons", "0"));
		list.Add(new Tuple<string, string>("AssignmentsUpdate", val));
		list.Add(new Tuple<string, string>("Stats", JsonConvert.SerializeObject(StatsManager.instance.matchStats)));
		list.Add(new Tuple<string, string>("LevelReward", LevelManager.instance.currentLevel.golds.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("GoldBonusCount", PlayerAnalytics.instance.data.goldBonuses.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("LostGameInRow", StatsManager.instance.battlesLostInRow.ToString()));
		List<Tuple<string, string>> list2 = list;
		int num2 = EventAssignmentManager.instance.UpdateAssignment();
		if (num2 > 0)
		{
			list2.Add(new Tuple<string, string>("EventAssignmentUpdate", num2.ToString()));
		}
		if (Singleton<GameController>.instance.isPVP)
		{
			list2.Add(new Tuple<string, string>("BattleAnalytics", JsonConvert.SerializeObject(BattleAnalyticsManager.instance.HFKFFPEOAGN)));
		}
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			UnityEngine.Debug.Log("Beanstalk Server Manager: IS TUTORIAL TO PLAY WARCARDS RUNNING!");
			list2.Add(new Tuple<string, string>("TutorialWarcards", "1"));
			TutorialManagerPlayWarcards.instance.FinishTutorial();
		}
		Tuple<string, string> userDeviceData = UserDeviceManager.instance.GetUserDeviceData();
		if (userDeviceData != null)
		{
			list2.Add(new Tuple<string, string>("FpsDevice", userDeviceData.Value1));
			list2.Add(new Tuple<string, string>("FpsData", userDeviceData.Value2));
		}
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			list2.Add(new Tuple<string, string>("SquadId", squadName));
			JMHLHIIMNIG squadEventProgress = Singleton<ServerResultsCache>.instance.squadEventProgress;
			if (squadEventProgress != null)
			{
				float[] array = squadEventProgress.KMJFMJKLCNP(Singleton<ServerResultsCache>.instance.squadEventDefinition);
				if (array != null && squadEventProgress.DBNNKLCNDJD == squadName)
				{
					list2.Add(new Tuple<string, string>("SquadEventUpdate", JsonConvert.SerializeObject(array)));
					list2.Add(new Tuple<string, string>("SquadEventActiveTier", squadEventProgress.CAEILGMELMP.ToString(CultureInfo.InvariantCulture)));
				}
			}
		}
		if (IOJHEOBIIPE == GameController.HKGHCIEPGEL.MissionSuccess || IOJHEOBIIPE == GameController.HKGHCIEPGEL.Win || IOJHEOBIIPE == GameController.HKGHCIEPGEL.WinByForfeit)
		{
			list2.Add(new Tuple<string, string>("TimeBonus", Mathf.Clamp(Singleton<GameController>.instance.time, 0f, 999f).ToString(CultureInfo.InvariantCulture)));
		}
		if (Singleton<GameController>.instance.isMission)
		{
			UnityEngine.Debug.Log("Beanstalk Server Manager: Adding mission information to server request");
			list2.Add(new Tuple<string, string>("MissionIndex", (DailyMissionsManager.instance.currentMission.number - 1).ToString()));
			list2.Add(new Tuple<string, string>("MissionType", DailyMissionsManager.instance.currentMission.missionType.ToString()));
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			list2.Add(new Tuple<string, string>("IsWarArena", "1"));
		}
		Dictionary<string, object> dictionary = Singleton<EventTrackingManager>.instance.fuseboxxService.OJMJBOODBPA();
		if (dictionary != null && dictionary.ContainsKey("Win") && dictionary.ContainsKey("Loss"))
		{
			UnityEngine.Debug.Log("Beanstalk Server Manager: Found fuseboxx battle rewards = " + dictionary["Win"]);
			list2.Add(new Tuple<string, string>("WarbuckRewardWin", dictionary["Win"].ToString()));
			list2.Add(new Tuple<string, string>("WarbuckRewardLoss", dictionary["Loss"].ToString()));
		}
		string text = Singleton<EventTrackingManager>.instance.fuseboxxService.GLDBALMOHIJ();
		if (text != null)
		{
			UnityEngine.Debug.Log("Beanstalk Server Manager: Found Player Progress = " + text);
			list2.Add(new Tuple<string, string>("PlayerProgressRate", text));
		}
		string text2 = Singleton<EventTrackingManager>.instance.fuseboxxService.PCLODNEBIII();
		if (!string.IsNullOrEmpty(text2))
		{
			UnityEngine.Debug.Log("Beanstalk Server Manager: Sending starter pack days = " + text2);
			list2.Add(new Tuple<string, string>("StarterPackDays", text2));
		}
		else
		{
			UnityEngine.Debug.Log("Beanstalk Server Manager: NOT SENDING STARTER PACK DAYS");
		}
		BattleRewardsManager.instance.ClearAllRewards();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameEnded, list2)));
	}

	internal void GLNNBOPFJJC()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_TUTORIAL_START_PHASE2", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("HighLevel", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)152, gMDJHENPLHB)));
	}

	public void PhotonIsFull()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.PhotonIsFull, gMDJHENPLHB)));
	}

	public void JIPDCIDHLOI(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.Error;
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && IOJHEOBIIPE >= (GameController.HKGHCIEPGEL)7)
		{
			CardManager.instance.obtainedCards.Clear();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.Error;
			return;
		}
		int score = Singleton<ScoreManager>.instance.score;
		StatsManager.instance.RecomputeStatistics(IOJHEOBIIPE);
		StarterAssignmentsManager.instance.Evaluate();
		Singleton<AchievementsManager>.instance.POFPEJDDJAN(Achievement.NOLHKBIFMLB.None);
		string val = JsonConvert.SerializeObject(AssignmentsManager.instance.GetAssignmentsUpdate());
		string val2 = CardManager.instance.GetObtainedCards();
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && IOJHEOBIIPE != GameController.HKGHCIEPGEL.Killed)
		{
			Singleton<GameController>.instance.CBAPHFGNLLH.OKFMCCMNCHG();
			val2 = Singleton<GameController>.instance.CBAPHFGNLLH.SerializedStringOfWarcardsForServerAfterPlayWarcardsTutorial();
		}
		UnityEngine.Debug.Log("VipStart" + Singleton<GameController>.instance.battleId);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("before: critical: ", Singleton<GameController>.instance.battleId));
		int num = (int)IOJHEOBIIPE;
		list.Add(new Tuple<string, string>("ID_AFFECTEDOWNUNITS", num.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("KEVLARUP", score.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("ID_TOCOMPLETE", Singleton<PhotonConnectionManager>.instance.GHIKMFDGIHB() ? "ID_UPGRADEINPROGRESS" : "Cards_Owned_Bronze"));
		list.Add(new Tuple<string, string>("ID_PURCHASED", val2));
		list.Add(new Tuple<string, string>("MessagesCount", CardManager.instance.GetUsedCards()));
		list.Add(new Tuple<string, string>("Squad {0}", Singleton<ScoreManager>.instance.IAOLLEBPOLK.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("menu-weapon-benelli-starterpack", Singleton<ScoreManager>.instance.HOHGDIKCKFM.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("menu-arena-scrap-ico", "VipReward1"));
		list.Add(new Tuple<string, string>("doesnt exist", val));
		list.Add(new Tuple<string, string>("PlayTrailRPC", JsonConvert.SerializeObject(StatsManager.instance.matchStats)));
		list.Add(new Tuple<string, string>("category", LevelManager.instance.currentLevel.FMACCGDFPLJ().ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("SkillDifference", PlayerAnalytics.instance.data.goldBonuses.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("ID_ARENAREWARD_GOLD", StatsManager.instance.battlesLostInRow.ToString()));
		List<Tuple<string, string>> list2 = list;
		int num2 = EventAssignmentManager.PJDMNGIAPBE().ONFOFKGKKBF();
		if (num2 > 1)
		{
			list2.Add(new Tuple<string, string>("ID_STAT_MOSTSQUADPOINTS", num2.ToString()));
		}
		if (Singleton<GameController>.instance.isPVP)
		{
			list2.Add(new Tuple<string, string>("Got ", JsonConvert.SerializeObject(BattleAnalyticsManager.NPAJKFMCPPC().HFKFFPEOAGN)));
		}
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			UnityEngine.Debug.Log("Wrong_Unit");
			list2.Add(new Tuple<string, string>("SubscriptionNoChange", "ID_HEALTH"));
			TutorialManagerPlayWarcards.instance.FinishTutorial();
		}
		Tuple<string, string> userDeviceData = UserDeviceManager.instance.GetUserDeviceData();
		if (userDeviceData != null)
		{
			list2.Add(new Tuple<string, string>("null", userDeviceData.Value1));
			list2.Add(new Tuple<string, string>("No row IDs count not match with row count for: ", userDeviceData.Value2));
		}
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			list2.Add(new Tuple<string, string>("{0:D2}:{1:D2}", squadName));
			JMHLHIIMNIG jMHLHIIMNIG = Singleton<ServerResultsCache>.instance.JILGBKANGNB();
			if (jMHLHIIMNIG != null)
			{
				float[] array = jMHLHIIMNIG.KCNHAMPMCCE(Singleton<ServerResultsCache>.instance.JJMAIFPBAFA());
				if (array != null && jMHLHIIMNIG.DBNNKLCNDJD == squadName)
				{
					list2.Add(new Tuple<string, string>("Midnight", JsonConvert.SerializeObject(array)));
					list2.Add(new Tuple<string, string>("ID_WARNING_BUDDYCARDNOTREADY", jMHLHIIMNIG.CAEILGMELMP.ToString(CultureInfo.InvariantCulture)));
				}
			}
		}
		if (IOJHEOBIIPE == (GameController.HKGHCIEPGEL)(-61) || IOJHEOBIIPE == GameController.HKGHCIEPGEL.Kia || IOJHEOBIIPE == GameController.HKGHCIEPGEL.Forfeit)
		{
			list2.Add(new Tuple<string, string>("ID_YOUNEEDMONEYTODELIVERSPECIAL", Mathf.Clamp(Singleton<GameController>.instance.time, 274f, 280f).ToString(CultureInfo.InvariantCulture)));
		}
		if (Singleton<GameController>.instance.isMission)
		{
			UnityEngine.Debug.Log("ID_DEPLOYCOOLDOWNPERUNIT");
			list2.Add(new Tuple<string, string>("Weapon model not found! weaponprefab = '{0}' assetBundleName = '{1}'", (DailyMissionsManager.instance.currentMission.number - 1).ToString()));
			list2.Add(new Tuple<string, string>("ID_SLOTUPGRADE_POWER", DailyMissionsManager.instance.MEBFNJBNNEK().missionType.ToString()));
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			list2.Add(new Tuple<string, string>("globalPlayerLeaderboard", "ID_STATE_FRIENDDOESNTWANTREMATCH"));
		}
		Dictionary<string, object> dictionary = Singleton<EventTrackingManager>.instance.fuseboxxService.OJMJBOODBPA();
		if (dictionary != null && dictionary.ContainsKey("OnPauseDrawing") && dictionary.ContainsKey("Click on the ground to spawn the selected effect"))
		{
			UnityEngine.Debug.Log("ID_CARDPOOL" + dictionary["shotReal"]);
			list2.Add(new Tuple<string, string>("Desert", dictionary["armyPower"].ToString()));
			list2.Add(new Tuple<string, string>("GetCurrentMapDefinition", dictionary[" (#"].ToString()));
		}
		string text = Singleton<EventTrackingManager>.instance.fuseboxxService.IFKAGELCOHC();
		if (text != null)
		{
			UnityEngine.Debug.Log("ID_CONFIRM_ERROR" + text);
			list2.Add(new Tuple<string, string>("VisualType", text));
		}
		string text2 = Singleton<EventTrackingManager>.instance.fuseboxxService.JIOPALGEHON();
		if (!string.IsNullOrEmpty(text2))
		{
			UnityEngine.Debug.Log("Empty pack " + text2);
			list2.Add(new Tuple<string, string>("ArmyPower", text2));
		}
		else
		{
			UnityEngine.Debug.Log("getExperimentName");
		}
		BattleRewardsManager.instance.ClearAllRewards();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-60), list2)));
	}

	internal void EAAKDLHLCDE(string FIBOBOGCFCN, string LBMADCINIJG, string PGHCHNIDLNJ)
	{
		UnityEngine.Debug.LogError("ADD GOOGLE PLAY ACCOUNT WITH " + FIBOBOGCFCN + ", name = " + LBMADCINIJG + ", password = " + PGHCHNIDLNJ);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", LBMADCINIJG));
		list.Add(new Tuple<string, string>("GooglePlayId", FIBOBOGCFCN));
		list.Add(new Tuple<string, string>("GooglePlayPassword", PGHCHNIDLNJ));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AddGooglePlay, gMDJHENPLHB)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	public void NCKODKEJGHD(bool FPEPEFGHCGG)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_CONFIRM_ERROR", FPEPEFGHCGG.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AddGooglePlay, gMDJHENPLHB)));
	}

	internal void CPFGMLPIEFH(string PMGOFBOLEMO)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("M4B23N48RZF8CKPJ2QBR", PMGOFBOLEMO));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-158), gMDJHENPLHB)));
	}

	public void RestartTutorial()
	{
		if (BLPAKBPKKBI != null)
		{
			BLPAKBPKKBI(true);
		}
	}

	public static string test()
	{
		return "-----BEGIN CERTIFICATE-----MIIDwDCCAqgCCQCAhUcHjX7uoDANBgkqhkiG9w0BAQUFADCBoTELMAkGA1UEBhMCQ1oxDzANBgNVBAgMBlByYWd1ZTEPMA0GA1UEBwwGUHJhZ3VlMRIwEAYDVQQKDAlBYm91dCBGdW4xCzAJBgNVBAsMAklUMSswKQYDVQQDDCJ3YXJmcmllbmRzLWV1LmVsYXN0aWNiZWFuc3RhbGsuY29tMSIwIAY";
	}

	internal void EIOAPGKFBBP()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.customizationShown = true;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-51), gMDJHENPLHB)));
	}

	internal void GHOLOFNJNIN(string JODJNIDBCEE, string AAKEFDLNOIG, List<Card> MDHBFKALKHA)
	{
		UnityEngine.Debug.Log("Beanstalk: Deposit these cards = " + JODJNIDBCEE + ", remove these cards = " + AAKEFDLNOIG);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("AddedCards", JODJNIDBCEE));
		list.Add(new Tuple<string, string>("RemovedCards", AAKEFDLNOIG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.DepositCards, gMDJHENPLHB)));
		int[] rarityCounts = CardManager.instance.GetRarityCounts();
		foreach (Card item in MDHBFKALKHA)
		{
			string iCDKHLOBKIE = ((!item.isBuddyCard) ? item.id : "BuddyCard");
			Singleton<EventTrackingManager>.instance.AELDEBEBIJO(iCDKHLOBKIE, rarityCounts);
		}
	}

	public void GameStartedMaster(int BOPPHFBFOCO = -1)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("IsMatchMaking", (!Singleton<GameController>.instance.isRandomMatchMaking) ? "0" : "1"));
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		list.Add(new Tuple<string, string>("IsWarArenaBattle", (!Singleton<GameController>.instance.isWarArena) ? "0" : "1"));
		List<Tuple<string, string>> list2 = list;
		if (BOPPHFBFOCO != -1)
		{
			list2.Add(new Tuple<string, string>("BotId", BOPPHFBFOCO.ToString(CultureInfo.InvariantCulture)));
		}
		if (Singleton<GameController>.instance.isRandomMatchMaking && Singleton<GameController>.instance.isDeathMatchOffline)
		{
			list2.Add(new Tuple<string, string>("BotName", Singleton<GameController>.instance.opponent.EHHHBEMKGOE.MHPNDNJDPGE));
			list2.Add(new Tuple<string, string>("BotLevel", (Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL - 1).ToString()));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameStartedMaster, list2)));
	}

	public void FinishPlayerLeague()
	{
		UnityEngine.Debug.Log("BEANSTALK: FINISH PLAYER LEAGUE IN MENU SENT!!!!");
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.FinishPlayerLeague, gMDJHENPLHB)));
	}

	[SpecialName]
	public void CDLHKFMEJHL(Action IDEBKDPMPGM)
	{
		Action action = PNPJAHOENJN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PNPJAHOENJN, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void UserLoggedOut()
	{
		APKFMJHEGEB();
		if (KJBOMKICEBK != null)
		{
			KJBOMKICEBK();
		}
	}

	internal void ACDNEJLIBAP()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadWarsId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>(">", Singleton<DogTagManager>.instance.FDMCHFNPALJ().ToString()));
		list.Add(new Tuple<string, string>("withAdvertiserSubPublisher", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-112), gMDJHENPLHB)));
	}

	public void UpdateRegionPings(Dictionary<CloudRegionCode, int> NGAGLLDLFKF, InternetConnection BGGFMIKMCGM)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Regions", JsonConvert.SerializeObject(NGAGLLDLFKF)));
		list.Add(new Tuple<string, string>("Connection", BGGFMIKMCGM.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.UpdateRegionPings, gMDJHENPLHB)));
	}

	internal void CKBGIHJFGCD(List<string> JFBGOCAJPDD)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("[.,']*", JsonConvert.SerializeObject(JFBGOCAJPDD)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		UnityEngine.Debug.Log("GOT MAINTENANCE MESSAGE IN CREATE ACCOUNT");
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)50, gMDJHENPLHB)));
	}

	[SpecialName]
	public void BEEFCGKMAAL(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = BLPAKBPKKBI;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLPAKBPKKBI, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void CancelAllRequests()
	{
		StopAllCoroutines();
		CLDDKGFKCLL = false;
	}

	internal void OKFJPFGCKDG()
	{
		RequestBufferManager.instance.ForceSendClaimAssignment();
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-8), gMDJHENPLHB)));
	}

	internal void PDHFCIDODIP(long IOFHDGKGFBG, string EGLIJCPPLIP)
	{
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.LogError(string.Format("AddFacebookToCustomAccount ID: {0} PSWD: {1}", IOFHDGKGFBG, EGLIJCPPLIP));
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("FacebookId", IOFHDGKGFBG.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("FacebookPassword", EGLIJCPPLIP));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ExistFBAccount, gMDJHENPLHB)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	public void GetDailyMissions()
	{
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetNewDailyMissions, new List<Tuple<string, string>>())));
	}

	public void UpdateSquadInfo(string PNAKMCNGGHE, bool IOLNJBGOOLJ, int OHECBHDELEO)
	{
		UnityEngine.Debug.Log("Squad message = " + PNAKMCNGGHE);
		UnityEngine.Debug.Log("Is Public = " + ((!IOLNJBGOOLJ) ? "0" : "1"));
		UnityEngine.Debug.Log("Medals requirement = " + OHECBHDELEO);
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, true);
		if (aANECPGDMGM != null)
		{
			aANECPGDMGM.PNAKMCNGGHE = PNAKMCNGGHE;
			aANECPGDMGM.IOLNJBGOOLJ = IOLNJBGOOLJ;
			aANECPGDMGM.GDFOENAJEBA = OHECBHDELEO;
			Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("squad" + currentPlayer.squadName, aANECPGDMGM, DateTime.Now.AddMinutes(2.0));
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("IsPublic", (!IOLNJBGOOLJ) ? "0" : "1"));
		list.Add(new Tuple<string, string>("RequiredMedals", OHECBHDELEO.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(PNAKMCNGGHE))
		{
			list2.Add(new Tuple<string, string>("Message", PNAKMCNGGHE));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.UpdateSquad, list2)));
	}

	internal void KPGJOGPFNHD(string EJBEDLHIKDG)
	{
		UnityEngine.Debug.Log("Beanstalk: Kick Player Called!");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToKickId", EJBEDLHIKDG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.KickPlayer, gMDJHENPLHB)));
	}

	public void BuyInApp(string KDGOEKGADNK)
	{
		WaitingDialog.ShowDialog("ID_PURCHASINGINAPP");
		BBIEEHPFDDL.APLNKKDEJLN(KDGOEKGADNK);
	}

	internal void ECEAPNOAOEK(string MBBMHKBOKAI)
	{
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.CCPMCLFPCIF(MBBMHKBOKAI, true);
		if (list != null)
		{
			EFEEANDLLIN((DatabaseAction)(-116));
			return;
		}
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		list2.Add(new Tuple<string, string>("Weapon", MBBMHKBOKAI));
		List<Tuple<string, string>> gMDJHENPLHB = list2;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetFriendsInfo, gMDJHENPLHB)));
	}

	public void KHNDHKOBHIM(bool PPNMHPBMIJE = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Days_Since_Install", PPNMHPBMIJE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-110), gMDJHENPLHB)));
	}

	protected virtual void MDKKHOLHFLG()
	{
		base.Start();
		BBIEEHPFDDL.FJNMGNEACNE();
		NBJBKFEPJJC = GetComponent<InAppDataManager>();
		NBJBKFEPJJC.InitializeAfterStart();
	}

	internal void BFMNOBIMBFF()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.warpathShown = true;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.WarpathShownFirstTime, gMDJHENPLHB)));
	}

	private void APKFMJHEGEB()
	{
		isPlayerDataLoaded = false;
	}

	private void CKHDBGFHGIG(DatabaseAction IFGAGNBDKBE, string LFJLGAGDHMO, HKNKJFBJJBH KOPCNKJMJBC)
	{
		WaitingDialog.NDJPJBDKANE();
		if (KOPCNKJMJBC != (HKNKJFBJJBH)4)
		{
			if (IFGAGNBDKBE == (DatabaseAction)(-170) && KOPCNKJMJBC == HKNKJFBJJBH.Failed)
			{
				WarningDialog.LGJENJCMOIN(Localization.Localize("View_Completed"), Localization.Localize("PlayerLeaguesId"), Localization.Localize("a"), Localization.Localize("IsWarArena"), OPBNJHONMAL);
			}
			else
			{
				WarningDialog.ShowError(Localization.Localize("JP"), Localization.Localize("ID_GUI_BRONZE"), GuiElementSingle<WaitingDialog>.instance.DCIKANJJFIJ, null, string.Empty, true, true);
			}
			OEIIMGKKIFM(new Exception(LFJLGAGDHMO), IFGAGNBDKBE, LFJLGAGDHMO, string.Empty);
			ErrorWasReceived(IFGAGNBDKBE);
		}
	}

	public void OEIIMGKKIFM(Exception KIJELCLONNC, DatabaseAction MHLAAHNPMFG, string EENKJBCCPBG, string BHKNKALGCOH)
	{
		UnityEngine.Debug.LogError("ID_WARNING_WRONGPRICEFORHEART" + MHLAAHNPMFG);
		UnityEngine.Debug.LogError(", val = " + EENKJBCCPBG);
		if (EENKJBCCPBG.Length > -24)
		{
			EENKJBCCPBG = EENKJBCCPBG.Substring(0, 107);
		}
		UnityEngine.Debug.LogError("RewardMessage" + KIJELCLONNC.Message);
		UnityEngine.Debug.LogError(" :" + KIJELCLONNC.StackTrace);
		if (BHKNKALGCOH.Length > 40)
		{
			BHKNKALGCOH = BHKNKALGCOH.Substring(0, 141);
		}
		UnityEngine.Debug.LogError("Have discount {0} to upgrade {1}" + BHKNKALGCOH);
		if (MHLAAHNPMFG == DatabaseAction.FacebookLoginOk)
		{
			UnityEngine.Debug.Log("Manual_Unit_Spawn");
			return;
		}
		if (BDJLFKHICIL.LHOCBAKEBIM())
		{
			UnityEngine.Debug.Log("shield_unhide");
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string val = ((currentPlayer == null) ? "ID_CLOSE" : currentPlayer.name);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_MIN", val));
		list.Add(new Tuple<string, string>("Mouse Y", KIJELCLONNC.Message));
		list.Add(new Tuple<string, string>("menu-gold", KIJELCLONNC.StackTrace));
		list.Add(new Tuple<string, string>("ID_READYTIME", string.Concat(MHLAAHNPMFG, "LifeCount", AGHNMMODJKG)));
		list.Add(new Tuple<string, string>("GameController.StartGame '", "\r" + EENKJBCCPBG));
		list.Add(new Tuple<string, string>("ID_CONFIRM_SERVERERROR", BHKNKALGCOH));
		list.Add(new Tuple<string, string>("Chat Record For Height", Singleton<CurrentBundleVersion>.instance.EBLMAIDJCAO()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-20), gMDJHENPLHB)));
	}

	public void CBKCDKOEIJB(bool PPNMHPBMIJE = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_BATTLECANCELED", PPNMHPBMIJE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-7), gMDJHENPLHB)));
	}

	internal void NKCPEMBFGIE()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-13), gMDJHENPLHB)));
	}

	public void SquadUpdateWasReceived(AANECPGDMGM MIDDFOCJJOP)
	{
		if (LFGPLIPPBCN != null)
		{
			LFGPLIPPBCN(MIDDFOCJJOP);
		}
	}

	public void RestoreTransactions()
	{
		BBIEEHPFDDL.HACHKCEIADF();
	}

	internal void MKGIKEMBDAP()
	{
		UnityEngine.Debug.Log("122 MENU WEAPON SCREEN TUTORIAL WEAPON SELECTED");
		CKJHDCNMCCF = true;
	}

	internal void JCHLLCLOFHN()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerAnalytics", JsonConvert.SerializeObject(PlayerAnalytics.instance.GetUpdates())));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.UpdateAnalytics, gMDJHENPLHB)));
	}

	internal void CGLABODECCL()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CustomizationShown, gMDJHENPLHB)));
	}

	internal void MFMAIKBCEOF()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ExpandHitList, gMDJHENPLHB)));
	}

	internal void OBNPMDJHMJE(string FGIAEAFGIAE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_CONFIRM_EXITWARFRIENDS", FGIAEAFGIAE));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SendLog, gMDJHENPLHB)));
		WaitingDialog.ShowDialog("ID_DELIVERNOW");
	}

	internal void PBIEEJPJILH(string EJBEDLHIKDG)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerInfoId", EJBEDLHIKDG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetPlayerInfo, gMDJHENPLHB)));
	}

	internal void PFPODIDLBGJ()
	{
		RequestBufferManager.instance.ForceSendClaimAssignment();
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ClaimAssignmentMegaReward, gMDJHENPLHB)));
	}

	internal void HICNIGNNNAO()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.leagueLeaderboardsShown = true;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.LeagueLeaderboardShown, gMDJHENPLHB)));
	}

	internal void PIPLIJHJHFC(string ABKOIKJFGLB)
	{
		UnityEngine.Debug.Log("DeviceTokenUpdate, playerid = " + GameLoginManager.instance.playerId + ", token = " + ABKOIKJFGLB);
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			UnityEngine.Debug.LogWarning("Current Language = " + Localization.instance.nextLanguage);
			UnityEngine.Debug.LogWarning("Current Locale unity = " + Application.systemLanguage);
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("DeviceToken", ABKOIKJFGLB));
			list.Add(new Tuple<string, string>("Locale", Localization.instance.nextLanguage));
			List<Tuple<string, string>> gMDJHENPLHB = list;
			StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.UpdateDeviceToken, gMDJHENPLHB)));
		}
	}

	public void INNIDHNEKEA()
	{
		GMAOEMDBDPO();
		if (KJBOMKICEBK != null)
		{
			KJBOMKICEBK();
		}
	}

	public void GetScrapsReward(bool PPNMHPBMIJE = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("HeartDialogShown", PPNMHPBMIJE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetScrapsReward, gMDJHENPLHB)));
	}

	[SpecialName]
	public void IGIFDAFACDO(Action<AANECPGDMGM> IDEBKDPMPGM)
	{
		Action<AANECPGDMGM> action = LFGPLIPPBCN;
		Action<AANECPGDMGM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LFGPLIPPBCN, (Action<AANECPGDMGM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void OBJBMMCOABJ(long IOFHDGKGFBG, string EGLIJCPPLIP)
	{
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.LogError(string.Format("shield_shot", IOFHDGKGFBG, EGLIJCPPLIP));
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("starter", IOFHDGKGFBG.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Is Title Text Font Bold", EGLIJCPPLIP));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-43), gMDJHENPLHB)));
		LoadingDialog.PGFBMJFLHPC(Localization.Localize("UnitID"), true, true);
	}

	internal void BICJAICFDHB(long IOFHDGKGFBG, string BCMCMKDCLGP, string EGLIJCPPLIP)
	{
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.LogError(string.Format("AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}", IOFHDGKGFBG, BCMCMKDCLGP, EGLIJCPPLIP));
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", BCMCMKDCLGP));
		list.Add(new Tuple<string, string>("FacebookId", IOFHDGKGFBG.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("FacebookPassword", EGLIJCPPLIP));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AddFacebook, gMDJHENPLHB)));
		Singleton<EventTrackingManager>.instance.LoginToFacebook();
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	[SpecialName]
	public void CPOFECKKEGJ(Action<DatabaseAction, int, CAMPAFGONHH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, int, CAMPAFGONHH> action = NMHNPJGHPDK;
		Action<DatabaseAction, int, CAMPAFGONHH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NMHNPJGHPDK, (Action<DatabaseAction, int, CAMPAFGONHH>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void LCKDOMDFPIJ(string BCMCMKDCLGP, string PGHCHNIDLNJ)
	{
		UnityEngine.Debug.Log("Beanstalk: Change Name and Password");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", BCMCMKDCLGP));
		list.Add(new Tuple<string, string>("Password", PGHCHNIDLNJ));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ChangeNameAndPassword, gMDJHENPLHB)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_UPDATINGACCOUNT"));
	}

	internal void FGOGBNADPCE(int AMFJHAPGIJN)
	{
		UnityEngine.Debug.Log("BS: Update Army Power");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ArmyPower", AMFJHAPGIJN.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.UpdateArmyPower, gMDJHENPLHB)));
	}

	internal void FMDBCAFPPGP()
	{
		UnityEngine.Debug.Log("Beanstalk: Get Player " + GameLoginManager.currentPlayer.id);
		UnityEngine.Debug.Log("Current Language = " + Localization.instance.nextLanguage);
		UnityEngine.Debug.Log("Current Locale unity = " + Application.systemLanguage);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Buffers", RequestBufferManager.instance.GetJsonData()));
		list.Add(new Tuple<string, string>("Locale", Localization.instance.nextLanguage));
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		list.Add(new Tuple<string, string>("width", Screen.width.ToString()));
		list.Add(new Tuple<string, string>("height", Screen.height.ToString()));
		list.Add(new Tuple<string, string>("KochavaDeviceID", KochavaManager.GetKochavaDeviceId()));
		list.Add(new Tuple<string, string>("IDFA", KochavaManager.GetIDFA()));
		list.Add(new Tuple<string, string>("IDFV", KochavaManager.GetIDFV()));
		list.Add(new Tuple<string, string>("AndroidID", KochavaManager.GetAndroidID()));
		list.Add(new Tuple<string, string>("AndroidAdvertisingID", KochavaManager.GetAndroidAdvertisingID()));
		list.Add(new Tuple<string, string>("LocalPersistenceHandle", LocalPersistenceManager.GetLocalFileHandle()));
		List<Tuple<string, string>> list2 = list;
		if (BattleRewardsManager.instance.isSomeUnsentRewards)
		{
			UnityEngine.Debug.LogError("Beanstalk: Get Player Data - unset rewards set!");
			list2.Add(new Tuple<string, string>("UnsentRewards", JsonConvert.SerializeObject(BattleRewardsManager.instance.data)));
		}
		string text = Singleton<EventTrackingManager>.instance.fuseboxxService.OGJFIDANNMA();
		if (text != null)
		{
			UnityEngine.Debug.LogError("Fuseboxx Config Value = " + text);
			list2.Add(new Tuple<string, string>("FuseboxxConfigValue", text));
		}
		else
		{
			UnityEngine.Debug.LogError("NO Fuseboxx Config Value during GETPLAYERDATA!");
		}
		LoadingDialog.ShowLoading(Localization.Localize("ID_DOWNLOADINGDATA"), false, true);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetPlayerData, list2)));
	}

	internal void CLGKGOHGLGG(DatabasePlayer CIFDPOCBMHP)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToInviteId", CIFDPOCBMHP.id));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.InvitePlayerToSquad, gMDJHENPLHB)));
	}

	[SpecialName]
	private void IHAIMLFBHCJ(bool IDEBKDPMPGM)
	{
		_003CJIKKGJKGKGE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public string NLMOHLEJFHK()
	{
		return BDJLFKHICIL.OIJJGNMGEME();
	}

	public void PJDNNMGDLEC(AANECPGDMGM MIDDFOCJJOP)
	{
		if (LFGPLIPPBCN != null)
		{
			LFGPLIPPBCN(MIDDFOCJJOP);
		}
	}

	internal void JDKFJFALDOG()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.cardpoolShown = false;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-165), gMDJHENPLHB)));
	}

	[SpecialName]
	public int BKJJGHIODNF()
	{
		return FBBKCGLIIOB.LKIFCDILEHL();
	}

	public void ErrorWasReceived(DatabaseAction IFGAGNBDKBE)
	{
		if (KJCDDLCEOIM != null)
		{
			KJCDDLCEOIM(IFGAGNBDKBE);
		}
	}

	internal void LPHCPJHIAIB(string CGIFEHPDBAL)
	{
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(CGIFEHPDBAL);
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(CGIFEHPDBAL);
		if (aANECPGDMGM != null && list != null)
		{
			UnityEngine.Debug.LogError("Beanstalk: Squad Details is cached, returning ...");
			DataWasLoaded(DatabaseAction.GetFullSquadInfo);
			return;
		}
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		list2.Add(new Tuple<string, string>("SquadId", CGIFEHPDBAL));
		List<Tuple<string, string>> gMDJHENPLHB = list2;
		UnityEngine.Debug.Log("Get full squad id = " + CGIFEHPDBAL);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetFullSquadInfo, gMDJHENPLHB)));
	}

	private void EHKKAOLJMCF()
	{
		if (!BIGNBCJCFNM)
		{
			FBBKCGLIIOB = new OIFCNEJNGJJ();
			BDJLFKHICIL = new DJOJPKGADMP();
			MDKJJLPEGDC = new OGLEHLIPEFM(FBBKCGLIIOB);
			BBIEEHPFDDL = new PLIABAOLHBE();
			AGHNMMODJKG = BDJLFKHICIL.NPDIBOLPACA();
			GameLoginManager.instance.FriendsLoaded += GetFriendsInfo;
			BBIEEHPFDDL.GBILNGBAANO += MAMLPOJCCGI;
			BBIEEHPFDDL.IKGEGHACJJD += BGNNCBLDEHJ;
			Singleton<Logs>.instance.sendLogsAction = PILMMAHOHIB;
			BIGNBCJCFNM = true;
		}
	}

	internal void BIKCJBEEDMA()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameStartedCoopClient, gMDJHENPLHB)));
	}

	internal void CCPMCLFPCIF(string MBBMHKBOKAI)
	{
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.CCPMCLFPCIF(MBBMHKBOKAI);
		if (list != null)
		{
			DataWasLoaded(DatabaseAction.GetPlayerLeaguesDivision);
			return;
		}
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		list2.Add(new Tuple<string, string>("LeagueId", MBBMHKBOKAI));
		List<Tuple<string, string>> gMDJHENPLHB = list2;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetPlayerLeaguesDivision, gMDJHENPLHB)));
	}

	public void EBDJHAJGNNK()
	{
		UnityEngine.Debug.Log("0");
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.HitListPlayerLoggedIn, gMDJHENPLHB)));
	}

	private void PMDMLGKLMKO(HTTPRequest LCAIJCMHFIM, HTTPResponse EENKJBCCPBG)
	{
		switch (LCAIJCMHFIM.State)
		{
		case HTTPRequestStates.Finished:
			break;
		case HTTPRequestStates.Error:
			UnityEngine.Debug.LogError("Request Finished with Error! " + ((LCAIJCMHFIM.Exception == null) ? "No Exception" : (LCAIJCMHFIM.Exception.Message + "\n" + LCAIJCMHFIM.Exception.StackTrace)));
			break;
		case HTTPRequestStates.Aborted:
			UnityEngine.Debug.LogWarning("Request Aborted!");
			break;
		case HTTPRequestStates.ConnectionTimedOut:
			UnityEngine.Debug.LogError("Connection Timed Out!");
			break;
		case HTTPRequestStates.TimedOut:
			UnityEngine.Debug.LogError("Processing the request Timed Out!");
			break;
		}
	}

	internal void KKOKNNOPBEF()
	{
		KFNOCEALEDO = Time.realtimeSinceStartup + 1f;
	}

	public void SkipAssignment(int DFHAAIFFLOE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("AssignmentIndex", DFHAAIFFLOE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SkipDailyAssignment, gMDJHENPLHB)));
	}

	public void JoinSquadRequest(string DBNNKLCNDJD)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", DBNNKLCNDJD));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.JoinSquadRequest, gMDJHENPLHB)));
	}

	[SpecialName]
	public void OEMNLFFLFJA(Action<DatabaseAction> IDEBKDPMPGM)
	{
		Action<DatabaseAction> action = BIELMEODOCB;
		Action<DatabaseAction> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BIELMEODOCB, (Action<DatabaseAction>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void CBCLFBLOHAI(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = BLPAKBPKKBI;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLPAKBPKKBI, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void DIMIGOPEBLA(string BCMCMKDCLGP, bool HNLJDNFOCOM = false)
	{
		if (BCMCMKDCLGP == GameLoginManager.currentPlayer.name)
		{
			UnityEngine.Debug.Log("ID_TUTORIAL_GO_BUY_ARMY_2_DOWN");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("\"{0}\"", BCMCMKDCLGP));
		list.Add(new Tuple<string, string>("ID_SALEPERCENT", (!HNLJDNFOCOM) ? "Changed country to {0} from {1}." : "Unit {0} is not being delivered/upgrade/trained!!!"));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.DepositCards, gMDJHENPLHB)));
		LoadingDialog.ShowLoading(Localization.Localize("improper JSON formatting:"), true, true);
	}

	private void Update()
	{
		if (shouldGetMessages && !CLDDKGFKCLL && Time.realtimeSinceStartup > KFNOCEALEDO)
		{
			if (KIFPBCLGKJG)
			{
				KFNOCEALEDO = Time.realtimeSinceStartup + 1f;
				return;
			}
			KFNOCEALEDO = Time.realtimeSinceStartup + (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GetAllMessagesTimer).FLOATVALUE;
			StartCoroutine(DOOKHODNDPO());
		}
	}

	public string GetBuyOfferEventLocation()
	{
		string cLPCLFBGHEM = CLPCLFBGHEM;
		CLPCLFBGHEM = null;
		return cLPCLFBGHEM;
	}

	private void APFPOMFIMHK()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Logs.LogEntry logEntry in Singleton<Logs>.instance.logEntries)
		{
			string text = "Message";
			switch (logEntry.type)
			{
			case (LogType)5:
				text = "{0:0} mph \nGear: {1:0}/{2:0}\nRevs {3:0%}\nThrottle: {4:0%}\n";
				break;
			case LogType.Warning:
				text = "{0} {1}";
				break;
			}
			stringBuilder.AppendLine(" {0}{1}" + text + "{0} {1}");
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.type.ToString()));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.output));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.stack));
			stringBuilder.AppendLine("Enemy could not be spawned");
		}
		SendLogs(stringBuilder);
	}

	[CompilerGenerated]
	private static void LFNHIFMAOIA(bool JADCNGOBAAA)
	{
		if (JADCNGOBAAA && !GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			GuiElementSingle<SettingsDialog>.instance.ShowGeneral();
		}
	}

	public void JOABNLLMPHL()
	{
		if (BLPAKBPKKBI != null)
		{
			BLPAKBPKKBI(true);
		}
	}

	internal void PIFEDJADAJB(ICFCHEHNHEN PNAKMCNGGHE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("MessageId", PNAKMCNGGHE.NHHGDIDEIMM));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AcceptChallenge, gMDJHENPLHB)));
	}

	internal void CBPIKKDNHGP(string PDDLJMAMDCE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("T", PDDLJMAMDCE));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		UnityEngine.Debug.LogError("HitListItem" + PDDLJMAMDCE);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.TutorialEnded, gMDJHENPLHB)));
	}

	internal void PIFMMDGEGPK()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("isGameCenter", (!Singleton<GameCenterProvider>.instance.LCMAHPKKGOA) ? "0" : "1"));
		list.Add(new Tuple<string, string>("gameCenterId", Singleton<GameCenterProvider>.instance.PIIIKJJHJPN));
		list.Add(new Tuple<string, string>("gameCenterPassword", GameLoginManager.instance.data.playerAccount.passwordGC));
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.RemoveFacebook, list)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	public void claimDailyReward(int DFHAAIFFLOE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("claimRweard", DFHAAIFFLOE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ClaimDailyReward, gMDJHENPLHB)));
	}

	public void Challenge(DatabasePlayer NCFFGKHPJLH, string FBEAOHMDKDJ, int HLPHCDNMJLG = -1, string OKIIAAPDJIK = "", string ADBBOLJGLCA = "", string JLBLNDGIINB = "default")
	{
		Singleton<MapManager>.instance.SelectCurrentMap(FBEAOHMDKDJ);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ChallengedPlayerId", NCFFGKHPJLH.id));
		list.Add(new Tuple<string, string>("MapName", FBEAOHMDKDJ));
		list.Add(new Tuple<string, string>("GameType", ((int)Singleton<GameController>.instance.gameType).ToString(CultureInfo.InvariantCulture)));
		bool FGKIBJBEBJG;
		list.Add(new Tuple<string, string>("Region", ((int)PhotonConnectionManager.GetBestRegion(PhotonConnectionManager.IFOKPNHLEBP, NCFFGKHPJLH.bestRegions, out FGKIBJBEBJG)/*cast due to .constrained prefix*/).ToString()));
		list.Add(new Tuple<string, string>("roomName", JLBLNDGIINB));
		list.Add(new Tuple<string, string>("clientVersion", Singleton<CurrentBundleVersion>.instance.photonVersion));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(OKIIAAPDJIK))
		{
			list2.Add(new Tuple<string, string>("MissionType", OKIIAAPDJIK));
		}
		if (HLPHCDNMJLG >= 0)
		{
			list2.Add(new Tuple<string, string>("NumberOfMission", HLPHCDNMJLG.ToString()));
		}
		if (!string.IsNullOrEmpty(ADBBOLJGLCA))
		{
			list2.Add(new Tuple<string, string>("MissionData", ADBBOLJGLCA));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.MessageSent, list2)));
	}

	[SpecialName]
	public int CODBHMKCFIL()
	{
		if (FBBKCGLIIOB == null)
		{
			return 1;
		}
		return FBBKCGLIIOB.DLJPFLFNIDL();
	}

	[DebuggerHidden]
	private IEnumerator JIPONODIINO()
	{
		PIEDAILOECP pIEDAILOECP = new PIEDAILOECP();
		pIEDAILOECP.BJGCPDNMHDH = this;
		return pIEDAILOECP;
	}

	internal void BJNADDOCENE()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetNewAssignments, gMDJHENPLHB)));
	}

	internal void ABPLPIGOBNB(string CGIFEHPDBAL)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", CGIFEHPDBAL));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CheckUniqueSquadName, gMDJHENPLHB)));
	}

	internal void EOKBKABOIMI()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.customizationShown = true;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CustomizationShown, gMDJHENPLHB)));
	}

	[SpecialName]
	public void FKHHHMDONNC(Action<DatabaseAction, int, CAMPAFGONHH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, int, CAMPAFGONHH> action = NMHNPJGHPDK;
		Action<DatabaseAction, int, CAMPAFGONHH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NMHNPJGHPDK, (Action<DatabaseAction, int, CAMPAFGONHH>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal int PEBAKEPKGOD()
	{
		return FBBKCGLIIOB.PFOKONAEABB();
	}

	internal void MEBMHIOJAHC()
	{
		List<AANECPGDMGM> list = Singleton<ServerResultsCache>.instance.MOCMGBJJAHB();
		if (list != null)
		{
			DataWasLoaded(DatabaseAction.GetSquadsByExperience);
			return;
		}
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			list2.Add(new Tuple<string, string>("SquadId", GameLoginManager.currentPlayer.squadName));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetSquadsByExperience, list2)));
	}

	internal void GHJMGKMMKGD(DatabasePlayer CHGMPGCOBIL)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>(" THAT WAS ALREADY BOUGHT. ADDING PACK TO RESTORE", CHGMPGCOBIL.id));
		int squadRank = (int)CHGMPGCOBIL.squadRank;
		list.Add(new Tuple<string, string>("PNManager: Not rescheduling -> Beanstalk.currentTimestamp is zero!", squadRank.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-51), gMDJHENPLHB)));
	}

	internal void KAEMGAOPBPA(string DFHDOAEADKB, bool OJENCLCONOF)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadNameStart", DFHDOAEADKB));
		List<Tuple<string, string>> list2 = list;
		if (OJENCLCONOF)
		{
			list2.Add(new Tuple<string, string>("IsGlobal", "1"));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetSquads, list2)));
	}

	internal void BOHDKCDECMN(string EJBEDLHIKDG, int DABHIDEBIGE, int BOKNFIGPNOH, int LDGGCEHJIED, int GKJJOHDDCCE, int INPMGADLOBP, float NOONODAGCLH)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ReportedPlayerId", EJBEDLHIKDG));
		list.Add(new Tuple<string, string>("ReportType", DABHIDEBIGE.ToString()));
		list.Add(new Tuple<string, string>("MyArmyPower", MEJMLNDFDBP.GMIPFLIEOHD(BOKNFIGPNOH)));
		list.Add(new Tuple<string, string>("MyRank", LDGGCEHJIED.ToString()));
		list.Add(new Tuple<string, string>("OpponentArmyPower", MEJMLNDFDBP.GMIPFLIEOHD(INPMGADLOBP)));
		list.Add(new Tuple<string, string>("OpponentRank", GKJJOHDDCCE.ToString()));
		list.Add(new Tuple<string, string>("TimeOfMatch", MEJMLNDFDBP.GGDHFCCNAND(NOONODAGCLH)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ReportCheater, gMDJHENPLHB)));
	}

	public void AcceptRentalOffer(bool FPEPEFGHCGG)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("buyRentalDiscounted", FPEPEFGHCGG.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AcceptRentalOffer, gMDJHENPLHB)));
	}

	internal void OCNNDLCHFFI(string EJBEDLHIKDG, string PNAKMCNGGHE, int DABHIDEBIGE)
	{
		if (string.IsNullOrEmpty(EJBEDLHIKDG))
		{
			UnityEngine.Debug.LogError("SEND PLAYER REPORT ERROR - NO PLAYER ID");
			return;
		}
		if (string.IsNullOrEmpty(PNAKMCNGGHE))
		{
			UnityEngine.Debug.LogError("SEND PLAYER REPORT ERROR - NO MESSAGE");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ReportedPlayerId", EJBEDLHIKDG));
		list.Add(new Tuple<string, string>("Message", PNAKMCNGGHE));
		list.Add(new Tuple<string, string>("ReportType", DABHIDEBIGE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SendPlayerReport, gMDJHENPLHB)));
	}

	[SpecialName]
	public int AHEDBCHBDMN()
	{
		return FBBKCGLIIOB.IJHDDLNGLHK();
	}

	internal void FCCLNIOHOPK(string INFLHPGMEOB, int DENPBMNKPIH, int DBOLKNNJGMH = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Id", INFLHPGMEOB));
		list.Add(new Tuple<string, string>("discount", DBOLKNNJGMH.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.BuyLootboxes, gMDJHENPLHB)));
	}

	internal void DKNDEAIPIAA()
	{
		List<FHIPGDADNFG> list = Singleton<ServerResultsCache>.instance.FIHEPBCHELM();
		if (list != null)
		{
			DataWasLoaded(DatabaseAction.GetPlayersByExperience);
			return;
		}
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetPlayersByExperience, gMDJHENPLHB)));
	}

	internal void HLOIAKCBMCE(PlayerStatus CKCJBIIPEOG)
	{
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		int num = (int)CKCJBIIPEOG;
		list.Add(new Tuple<string, string>("C: ", num.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)99, gMDJHENPLHB)));
	}

	internal void FFEACDMAGHG(DatabaseAction IFGAGNBDKBE, List<Tuple<string, string>> ABMLHILNNDM)
	{
		UnityEngine.Debug.LogError("ID_PVP_BATTLE" + IFGAGNBDKBE);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(IFGAGNBDKBE, ABMLHILNNDM)));
	}

	internal void DMLJAFNMFHC()
	{
		UnityEngine.Debug.Log("Beanstalk: Dev access unlocked");
		CKJHDCNMCCF = true;
	}

	internal void FNALEDCINFK()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ClaimCraftedCard, gMDJHENPLHB)));
	}

	[SpecialName]
	public void MCDDIFFDBDN(Action IDEBKDPMPGM)
	{
		Action action = EPIBGGIHKPH;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EPIBGGIHKPH, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void GMAOEMDBDPO()
	{
		IHAIMLFBHCJ(false);
	}

	internal void OBKPFHKMELH(string FCBBDLHGHPB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerName", FCBBDLHGHPB));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SearchPlayers, gMDJHENPLHB)));
	}

	private int NBJGBDDFGPD(DatabaseAction MHLAAHNPMFG)
	{
		if (CIKPMOAFBOE.Contains((int)MHLAAHNPMFG) || MHLAAHNPMFG == DatabaseAction.SetPlayerStatus || MHLAAHNPMFG == DatabaseAction.GetPlayerData || MHLAAHNPMFG == DatabaseAction.GameEnded)
		{
			return 3;
		}
		return 5;
	}

	private void MAMLPOJCCGI(DatabaseAction IFGAGNBDKBE, string KDGOEKGADNK, bool GEMGDIJKHJO, List<Tuple<string, string>> GPDMDOBPKJI)
	{
		GuiElementSingle<InappScreen>.instance.NEOJGNEBGKB = true;
		UnityEngine.Debug.Log("BS: On In App Bought " + KDGOEKGADNK + " action:" + IFGAGNBDKBE);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		foreach (Tuple<string, string> item in GPDMDOBPKJI)
		{
			list.Add(item);
		}
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.BuyInApp:
			list.Add(new Tuple<string, string>("Id", KDGOEKGADNK));
			list.Add(new Tuple<string, string>("GoldBase", NBJBKFEPJJC.goldPrefix));
			list.Add(new Tuple<string, string>("WarbucksBase", NBJBKFEPJJC.warbucksPrefix));
			break;
		case DatabaseAction.BuyPack:
		{
			list.Add(new Tuple<string, string>("Id", KDGOEKGADNK));
			Tuple<float, string> tuple = BBIEEHPFDDL.LOIBJHKOPKP(KDGOEKGADNK);
			float value = tuple.Value1;
			if (GEMGDIJKHJO)
			{
				list.Add(new Tuple<string, string>("IsRestore", "1"));
				value = 0f;
			}
			break;
		}
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(IFGAGNBDKBE, list)));
	}

	public void SendErrorMessage(Exception KIJELCLONNC, object OMJLGCLJNBD, string CKGAHLKBKMI)
	{
		if (!DIEFNOGGPOA)
		{
			UnityEngine.Debug.LogError("Server message to parse: " + OMJLGCLJNBD);
			UnityEngine.Debug.LogError("Exception message: " + KIJELCLONNC.Message);
			UnityEngine.Debug.LogError("Exception stacktrace: " + CKGAHLKBKMI);
			if (BDJLFKHICIL.DLKMLPAHJEI)
			{
				UnityEngine.Debug.Log("Not sending error to database!!");
			}
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("PlayerName", (currentPlayer == null) ? "null" : currentPlayer.name));
			list.Add(new Tuple<string, string>("ExceptionMessage", KIJELCLONNC.Message));
			list.Add(new Tuple<string, string>("ExceptionStacktrace", KIJELCLONNC.StackTrace));
			list.Add(new Tuple<string, string>("MessageToParse", "message= " + OMJLGCLJNBD));
			list.Add(new Tuple<string, string>("ClientVersion", Singleton<CurrentBundleVersion>.instance.version));
			List<Tuple<string, string>> gMDJHENPLHB = list;
			StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ErrorMessage, gMDJHENPLHB)));
		}
	}

	public void SendSpecialOfferShowed(JPMLOCNCEGO[] JBFCNOHNEKF)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		List<string> list2 = new List<string>();
		for (int i = 0; i < JBFCNOHNEKF.Length; i++)
		{
			list2.Add(JBFCNOHNEKF[i].INFLHPGMEOB);
		}
		list.Add(new Tuple<string, string>("showedOffers", JToken.FromObject(list2).ToString()));
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SpecialOfferShowed, list)));
	}

	internal void PGKFHBDOGNA(DatabasePlayer ONLIAIPFAIO)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToPromoteId", ONLIAIPFAIO.id));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.PromotePlayerToFounder, gMDJHENPLHB)));
	}

	private int PACBAKNGKEK(int GGPPOJMKILJ, DatabaseAction IFGAGNBDKBE)
	{
		if ((CIKPMOAFBOE.Contains((int)IFGAGNBDKBE) || IFGAGNBDKBE == DatabaseAction.SetPlayerStatus || IFGAGNBDKBE == DatabaseAction.GetPlayerData) && GGPPOJMKILJ == 0)
		{
			return 10;
		}
		return 20;
	}

	private void IJEJJJIEGPO()
	{
		isPlayerDataLoaded = true;
	}

	internal void IIPKANOGHOA()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("SquadId", squadName));
			List<Tuple<string, string>> gMDJHENPLHB = list;
			StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.InformSquadLeaderAboutEvent, gMDJHENPLHB)));
		}
	}

	internal void CGLMJFMAJIG(string EJBEDLHIKDG, string ICDKHLOBKIE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Delete QuickPlay Data", EJBEDLHIKDG));
		list.Add(new Tuple<string, string>("ResyncTimeRPC", ICDKHLOBKIE));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-44), gMDJHENPLHB)));
	}

	internal void HBCBKAPGJKG(string PIIIKJJHJPN, bool PNHFNCDAJIJ = false)
	{
		string text = MEJMLNDFDBP.BGCDGDKEGBH(PIIIKJJHJPN + "banana");
		UnityEngine.Debug.Log("AddGameCenter with " + PIIIKJJHJPN + ", pass = " + text + ", remove older account = " + PNHFNCDAJIJ);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("GameCenterId", PIIIKJJHJPN));
		list.Add(new Tuple<string, string>("GameCenterPassword", text));
		List<Tuple<string, string>> list2 = list;
		if (PNHFNCDAJIJ)
		{
			list2.Add(new Tuple<string, string>("RemoveOld", "1"));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AddGameCenter, list2)));
	}

	internal void KLIPCELANKO(DatabasePlayer CIFDPOCBMHP)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_MISSIONANIMATION_WAVEIN", CIFDPOCBMHP.id));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.DebugAddLevel, gMDJHENPLHB)));
	}

	public void CreateAccount()
	{
		double num = OIFCNEJNGJJ.FMHAHEOJGLF();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("UtcOffset", num.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Locale", Localization.instance.nextLanguage));
		List<Tuple<string, string>> list2 = list;
		Dictionary<string, object> dictionary = Singleton<EventTrackingManager>.instance.fuseboxxService.EDKFAADPJAJ();
		if (dictionary != null && dictionary.ContainsKey("gold"))
		{
			UnityEngine.Debug.Log("Found starting gold currency = " + dictionary["gold"]);
			list2.Add(new Tuple<string, string>("StartingGold", dictionary["gold"].ToString()));
		}
		if (dictionary != null && dictionary.ContainsKey("warbucks"))
		{
			UnityEngine.Debug.Log("Found starting warbucks currency = " + dictionary["warbucks"]);
			list2.Add(new Tuple<string, string>("StartingWarbucks", dictionary["warbucks"].ToString()));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CreateAccount, list2)));
	}

	protected override void Awake()
	{
		base.Awake();
		EHKKAOLJMCF();
	}

	internal void PANLBEECIAB(DatabasePlayer CIFDPOCBMHP)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("menu-arena-scrap-ico", CIFDPOCBMHP.id));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)31, gMDJHENPLHB)));
	}

	internal void OHNDODHMCJB(string EJBEDLHIKDG)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Client has new config for: {0} with version {1}", EJBEDLHIKDG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-200), gMDJHENPLHB)));
	}

	public void CreateGcAccount(string PIIIKJJHJPN)
	{
		string text = MEJMLNDFDBP.BGCDGDKEGBH(PIIIKJJHJPN + "banana");
		UnityEngine.Debug.Log("CreateGcAccount with " + PIIIKJJHJPN + ", pass = " + text);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("GameCenterId", PIIIKJJHJPN));
		list.Add(new Tuple<string, string>("GameCenterPassword", text));
		list.Add(new Tuple<string, string>("UtcOffset", OIFCNEJNGJJ.FMHAHEOJGLF().ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Locale", Localization.instance.nextLanguage));
		List<Tuple<string, string>> list2 = list;
		Dictionary<string, object> dictionary = Singleton<EventTrackingManager>.instance.fuseboxxService.EDKFAADPJAJ();
		if (dictionary != null && dictionary.ContainsKey("gold"))
		{
			UnityEngine.Debug.Log("Found starting gold currency = " + dictionary["gold"]);
			list2.Add(new Tuple<string, string>("StartingGold", dictionary["gold"].ToString()));
		}
		if (dictionary != null && dictionary.ContainsKey("warbucks"))
		{
			UnityEngine.Debug.Log("Found starting warbucks currency = " + dictionary["warbucks"]);
			list2.Add(new Tuple<string, string>("StartingWarbucks", dictionary["warbucks"].ToString()));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CreateGcAccount, list2)));
	}

	internal void MACBHHMBCGM()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.JoinSquadEvent, gMDJHENPLHB)));
	}

	public void GLPABEDFIAA()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)1, gMDJHENPLHB)));
	}

	[SpecialName]
	public string NCGJDIOPLGC()
	{
		return _003CDCBJPMOIAFB_003Ek__BackingField;
	}

	public void CheckIfExistFbAccount(string GGDLEJDKGDC)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("FacebookId", GGDLEJDKGDC));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.TutorialCheckFBAccount, gMDJHENPLHB)));
	}

	internal void NGFICLMEOIN(string HGPGKHLOHEF)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Cards", HGPGKHLOHEF));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CraftCard, gMDJHENPLHB)));
	}

	public void TakeArenaLife()
	{
		UnityEngine.Debug.Log("Take player life!");
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.TakeArenaLife, gMDJHENPLHB)));
	}

	private void OCBLKIFKJEG()
	{
		if (DGBOELCCINL() && !CLDDKGFKCLL && Time.realtimeSinceStartup > KFNOCEALEDO)
		{
			if (KIFPBCLGKJG)
			{
				KFNOCEALEDO = Time.realtimeSinceStartup + 1501f;
				return;
			}
			KFNOCEALEDO = Time.realtimeSinceStartup + (float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SecondRenameGoldCost).FLOATVALUE;
			StartCoroutine(DOOKHODNDPO());
		}
	}

	public void MMNICHPDJPK(long NGPMJNJPNMB, int DBOLKNNJGMH, string EDKJOPECOFP, string ICIDFPHMBIF, bool LPGMLOCLBGP = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>(" is Opponent: ", NGPMJNJPNMB.ToString()));
		list.Add(new Tuple<string, string>("MineCards", DBOLKNNJGMH.ToString()));
		list.Add(new Tuple<string, string>("Gold", EDKJOPECOFP));
		list.Add(new Tuple<string, string>("ID_INELITE2", ICIDFPHMBIF));
		list.Add(new Tuple<string, string>("country-lithuania", Localization.instance.currentLanguage));
		list.Add(new Tuple<string, string>("special", Screen.width.ToString()));
		list.Add(new Tuple<string, string>("/", Screen.height.ToString()));
		list.Add(new Tuple<string, string>("Total_Gold_Spent", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("Unit", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> list2 = list;
		if (LPGMLOCLBGP)
		{
			list2.Add(new Tuple<string, string>("BR", "Rank"));
		}
		object[] array = new object[6];
		array[0] = EDKJOPECOFP;
		array[1] = NGPMJNJPNMB;
		array[4] = NGPMJNJPNMB - AHEDBCHBDMN();
		array[0] = DBOLKNNJGMH;
		UnityEngine.Debug.Log(string.Format("getSdkVariant", array));
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.JoinSquadRequest, list2)));
	}

	internal void OCDBJPIKJAK(string INFLHPGMEOB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadMemberId", INFLHPGMEOB));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.NotifyPlayerToDeposit, gMDJHENPLHB)));
	}

	private int KIBNHFFELBM(int GGPPOJMKILJ, DatabaseAction IFGAGNBDKBE)
	{
		if ((CIKPMOAFBOE.Contains((int)IFGAGNBDKBE) || IFGAGNBDKBE == DatabaseAction.FindSuggestedSquads || IFGAGNBDKBE == DatabaseAction.SearchPlayers) && GGPPOJMKILJ == 0)
		{
			return -57;
		}
		return -36;
	}

	private bool AACFNCKFCHO(HTTPRequest LCAIJCMHFIM, X509Certificate FJOOAEBHPAL, X509Chain LLAOOPMGBAG)
	{
		try
		{
			UnityEngine.Debug.Log("Custom Verification");
			X509Certificate x509Certificate = new X509Certificate();
			x509Certificate.Import(Encoding.UTF8.GetBytes(AHNMMLLFNAN));
			return x509Certificate.Equals(FJOOAEBHPAL);
		}
		catch (Exception)
		{
			return false;
		}
	}

	internal void HCDNHLKDNLB(string JDFLJCPDJGH)
	{
		List<AANECPGDMGM> list = Singleton<ServerResultsCache>.instance.MGHNLGHJPCP(JDFLJCPDJGH);
		if (list != null)
		{
			DataWasLoaded(DatabaseAction.GetSquadWarsDivision);
			return;
		}
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		list2.Add(new Tuple<string, string>("RoundId", JDFLJCPDJGH));
		List<Tuple<string, string>> gMDJHENPLHB = list2;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetSquadWarsDivision, gMDJHENPLHB)));
	}

	internal void IIFBHBOKGKA(string CGIFEHPDBAL, bool FHKKPEIDDJN = false)
	{
		UnityEngine.Debug.Log(string.Format("GetAllSquadMembers - squad {0} - force {1}", CGIFEHPDBAL, FHKKPEIDDJN));
		DatabaseAction databaseAction = DatabaseAction.GetAllSquadMembers;
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(CGIFEHPDBAL);
		if (list != null && !FHKKPEIDDJN)
		{
			DataWasLoaded(databaseAction);
			return;
		}
		if (Singleton<ServerResultsCache>.instance.HNBBPLCIGEC(databaseAction))
		{
			UnityEngine.Debug.Log(string.Concat("Beanstalk: Skipping ", databaseAction, ", action already scheduled"));
			return;
		}
		UnityEngine.Debug.Log("Beanstalk: Get All Squad Members");
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		list2.Add(new Tuple<string, string>("SquadId", CGIFEHPDBAL));
		List<Tuple<string, string>> list3 = list2;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(currentPlayer.squadRank, SquadRank.Veteran) >= 0;
		bool flag2 = !string.IsNullOrEmpty(currentPlayer.squadName) && flag;
		list3.Add(new Tuple<string, string>("CheckMessages", (!flag2) ? "0" : "1"));
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(databaseAction, list3)));
	}

	internal void CFACCPPIJOI(string ABKOIKJFGLB)
	{
		UnityEngine.Debug.Log("ID_CONFIRM_SQUADEVENT_TEXT" + GameLoginManager.instance.playerId + "1" + ABKOIKJFGLB);
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			UnityEngine.Debug.LogWarning("menu-event-gift" + Localization.instance.nextLanguage);
			UnityEngine.Debug.LogWarning("ID_WARNING_CANNOTINVITE_TEXT" + Application.systemLanguage);
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("reloadTime", ABKOIKJFGLB));
			list.Add(new Tuple<string, string>("no data", Localization.instance.nextLanguage));
			List<Tuple<string, string>> gMDJHENPLHB = list;
			StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-43), gMDJHENPLHB)));
		}
	}

	private static void OPBNJHONMAL(bool JADCNGOBAAA)
	{
		if (JADCNGOBAAA && !GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			DialogManager.instance.HideAllDialogs();
			GuiElementSingle<SettingsDialog>.instance.JGPCJJILAHG();
		}
	}

	internal void NFKMFBNGPNA(string KIHCHGPFOOF, string ICLNCDGCCJN = null)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("RewardId", KIHCHGPFOOF));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(ICLNCDGCCJN))
		{
			list2.Add(new Tuple<string, string>("Parameter", ICLNCDGCCJN));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AddOneTimeReward, list2)));
	}

	public void LEJDHBEFICL(int DFHAAIFFLOE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Wrong_Weapon", DFHAAIFFLOE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-92), gMDJHENPLHB)));
	}

	private void JIHFFFHPOAP()
	{
		UnityEngine.Debug.Log("BeanstalkServerManager: PlayerDataLoaded");
		if (PNPJAHOENJN != null)
		{
			Delegate[] invocationList = PNPJAHOENJN.GetInvocationList();
			foreach (Delegate obj in invocationList)
			{
				obj.Method.Invoke(obj.Target, new object[0]);
			}
		}
		UnityEngine.Debug.Log("BeanstalkServerManager: AfterPlayerDataLoaded");
		isPlayerDataLoaded = true;
		if (EPIBGGIHKPH != null)
		{
			Delegate[] invocationList2 = EPIBGGIHKPH.GetInvocationList();
			foreach (Delegate obj2 in invocationList2)
			{
				obj2.Method.Invoke(obj2.Target, new object[0]);
			}
		}
	}

	private HTTPRequest EIDPAHNCFPD(DatabaseAction MHLAAHNPMFG, int NOCEDALFEJM, IEnumerable<Tuple<string, string>> GMDJHENPLHB)
	{
		EHKKAOLJMCF();
		int num = PACBAKNGKEK(NOCEDALFEJM, MHLAAHNPMFG);
		string uriString = AGHNMMODJKG + (int)MHLAAHNPMFG + "/" + Singleton<CurrentBundleVersion>.instance.shortVersionDashed;
		HTTPRequest hTTPRequest = new HTTPRequest(new Uri(uriString), HTTPMethods.Post, PMDMLGKLMKO);
		hTTPRequest.Timeout = TimeSpan.FromSeconds(num);
		hTTPRequest.ConnectTimeout = TimeSpan.FromSeconds(num);
		hTTPRequest.DisableRetry = true;
		hTTPRequest.DisableCache = true;
		HTTPRequest hTTPRequest2 = hTTPRequest;
		hTTPRequest2.AddField("SheetConfig", (!string.IsNullOrEmpty(GameConfigurationManager.instance.data.sheetConfiguration)) ? GameConfigurationManager.instance.data.sheetConfiguration : "0");
		hTTPRequest2.CustomCertificationValidator += AACFNCKFCHO;
		hTTPRequest2.AddHeader("App-Version", Singleton<CurrentBundleVersion>.instance.shortVersion);
		int num2 = (int)MHLAAHNPMFG;
		hTTPRequest2.AddField("requestId", num2.ToString());
		hTTPRequest2.AddField("Version", Singleton<CurrentBundleVersion>.instance.version);
		hTTPRequest2.AddField("Os", "android");
		if (DebugSettings.debugEnabled && DebugSettings.isOurDevice)
		{
			hTTPRequest2.AddField("DebugEnabled", "1");
		}
		if (CKJHDCNMCCF)
		{
			hTTPRequest2.AddField("DevAccess", "true");
		}
		if (!CIKPMOAFBOE.Contains((int)MHLAAHNPMFG))
		{
			string accessToken = GameLoginManager.instance.accessToken;
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			hTTPRequest2.AddField("Token", (!string.IsNullOrEmpty(accessToken)) ? accessToken : "null");
			hTTPRequest2.AddField("PlayerId", (currentPlayer != null) ? currentPlayer.id : "null");
			if (Singleton<AntiCheatDetector>.instance.playerCheated)
			{
				hTTPRequest2.AddField("Cheat", Convert.ToString((int)Singleton<AntiCheatDetector>.instance.cheatType));
				Singleton<AntiCheatDetector>.instance.Clear();
			}
		}
		if (GMDJHENPLHB != null)
		{
			foreach (Tuple<string, string> item in GMDJHENPLHB)
			{
				string value = ((!string.IsNullOrEmpty(item.Value2)) ? item.Value2 : "null");
				hTTPRequest2.AddField(item.Value1, value);
			}
		}
		return hTTPRequest2;
	}

	protected override void Start()
	{
		base.Start();
		BBIEEHPFDDL.FJNMGNEACNE();
		NBJBKFEPJJC = GetComponent<InAppDataManager>();
		NBJBKFEPJJC.InitializeAfterStart();
	}

	internal void DPJMMFDOKEB(bool OJENCLCONOF)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		int skill = currentPlayer.skill;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Skill", skill.ToString()));
		List<Tuple<string, string>> list2 = list;
		if (OJENCLCONOF)
		{
			list2.Add(new Tuple<string, string>("IsGlobal", "1"));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.FindSuggestedSquads, list2)));
	}

	internal void MMMJHDJMFEB(string ABKOIKJFGLB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("DeviceToken", ABKOIKJFGLB));
		list.Add(new Tuple<string, string>("PlayerName", GameLoginManager.currentPlayer.name));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ProvokePlayer, gMDJHENPLHB)));
	}

	public void EFEEANDLLIN(DatabaseAction MHLAAHNPMFG)
	{
		if (BIELMEODOCB != null)
		{
			BIELMEODOCB(MHLAAHNPMFG);
		}
	}

	public void BuyArenaHearth()
	{
		UnityEngine.Debug.Log("New hearth bought!");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("hearthPrice", WarArena.instance.extraLiveCost.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.BuyArenaHearth, gMDJHENPLHB)));
	}

	public void AHANANFEHPI(Func<IEnumerator> BNLMJPIEOGI)
	{
		NBKBCPHHMLJ.Add(BNLMJPIEOGI);
	}

	public void BKPEOBBLCNG()
	{
		StopAllCoroutines();
		CLDDKGFKCLL = true;
	}

	internal void JKJOCCOGLAI(string CGIFEHPDBAL, bool FHKKPEIDDJN = false)
	{
		UnityEngine.Debug.Log(string.Format("CAUGHT AN MISSION EXCEPTION ", CGIFEHPDBAL, FHKKPEIDDJN));
		DatabaseAction databaseAction = (DatabaseAction)(-15);
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(CGIFEHPDBAL);
		if (list != null && !FHKKPEIDDJN)
		{
			EFEEANDLLIN(databaseAction);
			return;
		}
		if (Singleton<ServerResultsCache>.instance.HNBBPLCIGEC(databaseAction))
		{
			UnityEngine.Debug.Log(string.Concat("idle", databaseAction, ", token = "));
			return;
		}
		UnityEngine.Debug.Log("ID_WARNING_NOTENOUGHWARBUCKSFORELITE");
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		list2.Add(new Tuple<string, string>("pass", CGIFEHPDBAL));
		List<Tuple<string, string>> list3 = list2;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(currentPlayer.squadRank, SquadRank.Veteran) < 0;
		bool flag2 = !string.IsNullOrEmpty(currentPlayer.squadName) && flag;
		list3.Add(new Tuple<string, string>("\t\"FALSE\"", (!flag2) ? "AddFacebookToCustomAccount ID: {0} PSWD: {1}" : "ДА"));
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(databaseAction, list3)));
	}

	[SpecialName]
	public string JBJHMPLLANH()
	{
		switch (environment)
		{
		case (DatabaseEnvironment)0:
			return "SquadIcons/";
		case DatabaseEnvironment.DevelopmentSvk:
			return "+";
		case (DatabaseEnvironment)3:
			return "ID_STARTERASSIGNMENT";
		case DatabaseEnvironment.Staging:
			return "some_adv_sub_ad_id";
		default:
			return string.Empty;
		}
	}

	internal void DFMLCJMDLHJ(string NHHGDIDEIMM, string EJBEDLHIKDG)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("MessageId", NHHGDIDEIMM));
		list.Add(new Tuple<string, string>("Id", EJBEDLHIKDG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		UnityEngine.Debug.Log("Decline Squad Join Request = " + NHHGDIDEIMM);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.DeclineSquadJoinRequest, gMDJHENPLHB)));
	}

	internal void PKBHLABDPON()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("game-card-silver", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("SquadIcons/", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("Game shoootable entitiy without owner", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AddFacebook, gMDJHENPLHB)));
	}

	[SpecialName]
	public bool GIIFAMLDBNI()
	{
		return KIFPBCLGKJG;
	}

	public void GenerateSpecialOffer(long NGPMJNJPNMB, int DBOLKNNJGMH, string EDKJOPECOFP, string ICIDFPHMBIF, bool LPGMLOCLBGP = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("finish", NGPMJNJPNMB.ToString()));
		list.Add(new Tuple<string, string>("discount", DBOLKNNJGMH.ToString()));
		list.Add(new Tuple<string, string>("dbKey", EDKJOPECOFP));
		list.Add(new Tuple<string, string>("offerName", ICIDFPHMBIF));
		list.Add(new Tuple<string, string>("lang", Localization.instance.currentLanguage));
		list.Add(new Tuple<string, string>("width", Screen.width.ToString()));
		list.Add(new Tuple<string, string>("height", Screen.height.ToString()));
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> list2 = list;
		if (LPGMLOCLBGP)
		{
			list2.Add(new Tuple<string, string>("forceReplace", "1"));
		}
		UnityEngine.Debug.Log(string.Format("try generate special offer: {0}\n end {1} (duration {2})\ndiscount {3}", EDKJOPECOFP, NGPMJNJPNMB, NGPMJNJPNMB - currentTimestamp, DBOLKNNJGMH));
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GenerateSpecialOffer, list2)));
	}

	internal void BGMLCEPJOEO(DatabasePlayer CIFDPOCBMHP)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("119 LOADING MENU", CIFDPOCBMHP.id));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-68), gMDJHENPLHB)));
	}

	public void LENFCBJOKOP()
	{
		UnityEngine.Debug.Log("Result");
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-103), gMDJHENPLHB)));
	}

	public void CLLNFNIDCNF()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-164), gMDJHENPLHB)));
	}

	internal void DBDGCNFCOBI()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.chatShown = true;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ChatShownFirstTime, gMDJHENPLHB)));
	}

	public void GetFriendsInfo()
	{
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.BKHJHIILEFJ();
		if (list != null)
		{
			DataWasLoaded(DatabaseAction.GetFriendsInfo);
			return;
		}
		List<KFLKGGGJHIN.EBDBJAKJNLD> facebookFriends = GameLoginManager.instance.facebookFriends;
		UnityEngine.Debug.Log("Beanstalk: Get Friends Info, count = " + facebookFriends.Count);
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		int num = 0;
		for (int i = 0; i < facebookFriends.Count; i++)
		{
			UnityEngine.Debug.Log("Beanstalk: Hashed id of fb friend " + facebookFriends[i].DBKLEIJBGOG);
			UnityEngine.Debug.Log("Beanstalk: Name of FB friend " + facebookFriends[i].MHPNDNJDPGE);
			num++;
			list2.Add(new Tuple<string, string>("Friend" + i, facebookFriends[i].DBKLEIJBGOG.ToString(CultureInfo.InvariantCulture)));
		}
		list2.Add(new Tuple<string, string>("Count", num.ToString(CultureInfo.InvariantCulture)));
		if (GameLoginManager.currentPlayer != null)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName))
			{
				list2.Add(new Tuple<string, string>("SquadId", squadName));
			}
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetFriendsInfo, list2)));
	}

	internal int EPJIIHGOIHB()
	{
		return FBBKCGLIIOB.BPPLPHCDICD();
	}

	internal void DBAKBCEBKPK(string HGPGKHLOHEF)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Cards", HGPGKHLOHEF));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CraftAndClaimCard, gMDJHENPLHB)));
	}

	internal void LJEBBHOJLOL(int GNJFHBAKPAN, string INFLHPGMEOB, int DBOLKNNJGMH = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Id", INFLHPGMEOB));
		list.Add(new Tuple<string, string>("discount", DBOLKNNJGMH.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.BuyVip, gMDJHENPLHB)));
	}

	internal void FICNDIJIIFL(string FGIAEAFGIAE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Locale", FGIAEAFGIAE));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ChangeLanguage, gMDJHENPLHB)));
		WaitingDialog.ShowDialog("ID_CHANGINGLANGUAGE");
	}

	internal void FPDFCJKGAAM()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.craftingShown = true;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)137, gMDJHENPLHB)));
	}

	internal void PFGOADODBJF()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.RefillDogtags, gMDJHENPLHB)));
	}

	internal void AMIODDHOCEE(string AAALKPMBFCJ, string DBNNKLCNDJD)
	{
		UnityEngine.Debug.Log(" arena id" + DBNNKLCNDJD);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Grenade_Throwing_Tutorial_Duration", DBNNKLCNDJD));
		list.Add(new Tuple<string, string>("{0} {1}", AAALKPMBFCJ));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.InstantBattle, gMDJHENPLHB)));
	}

	[SpecialName]
	public void PLMFFEPGNKO(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = BLPAKBPKKBI;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLPAKBPKKBI, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MatchMakingGameWasCreated(bool FBFJNHLKJEC)
	{
		if (BLPAKBPKKBI != null)
		{
			BLPAKBPKKBI(FBFJNHLKJEC);
		}
	}

	private void CHNFKPCEMPD(DatabaseAction IFGAGNBDKBE, string LFJLGAGDHMO, HKNKJFBJJBH KOPCNKJMJBC)
	{
		WaitingDialog.KDLLKOJBGGO();
		if (KOPCNKJMJBC != (HKNKJFBJJBH)7)
		{
			if (IFGAGNBDKBE == (DatabaseAction)(-93) && KOPCNKJMJBC == HKNKJFBJJBH.Failed)
			{
				WarningDialog.LGJENJCMOIN(Localization.Localize("Name"), Localization.Localize("SquadId"), Localization.Localize("PlayerName"), Localization.Localize("game-card-ico-bulletsponge-full"), OPBNJHONMAL);
			}
			else
			{
				WarningDialog.KHOMNBHMFGA(Localization.Localize("Labels under Table:\n"), Localization.Localize("ID_ARENARULES_NOWARCARDS"), GuiElementSingle<WaitingDialog>.instance.DCIKANJJFIJ, null, string.Empty, true);
			}
			SendErrorMessage(new Exception(LFJLGAGDHMO), IFGAGNBDKBE, LFJLGAGDHMO, string.Empty);
			ErrorWasReceived(IFGAGNBDKBE);
		}
	}

	internal void KGKEPBPJDDA(string EJBEDLHIKDG)
	{
		UnityEngine.Debug.Log("3");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("width", EJBEDLHIKDG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.NotifyPlayerToDeposit, gMDJHENPLHB)));
	}

	internal void MHJJKDKKAKC(DatabaseAction IFGAGNBDKBE, List<Tuple<string, string>> ABMLHILNNDM)
	{
		UnityEngine.Debug.LogError("Beanstalk: Resending " + IFGAGNBDKBE);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(IFGAGNBDKBE, ABMLHILNNDM)));
	}

	internal void OIOKNCADLOK(string FGIAEAFGIAE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("《WarFriends》需要權限才能存取你的媒體儲存檔以便下載關鍵資料。請接受以下所示的權限對話，我們絕不會將此權限使用在其他用途。", FGIAEAFGIAE));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetFullSquadInfo, gMDJHENPLHB)));
		WaitingDialog.AJCILBFBNMK("ID_EXPIRED");
	}

	public void FPIOOBKMHFN(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.None;
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && IOJHEOBIIPE >= GameController.HKGHCIEPGEL.Win)
		{
			CardManager.instance.obtainedCards.Clear();
		}
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			Singleton<GameController>.instance.gameEndServerResponse = (GameController.AHDGGJJAOEO)3;
			return;
		}
		int num = Singleton<ScoreManager>.instance.EIBLONLEOMA();
		StatsManager.instance.RecomputeStatistics(IOJHEOBIIPE);
		StarterAssignmentsManager.instance.Evaluate();
		Singleton<AchievementsManager>.instance.PGCNEGKMFCJ(Achievement.NOLHKBIFMLB.None);
		string val = JsonConvert.SerializeObject(AssignmentsManager.instance.GetAssignmentsUpdate());
		string val2 = CardManager.instance.GetObtainedCards();
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && IOJHEOBIIPE != GameController.HKGHCIEPGEL.Win)
		{
			Singleton<GameController>.instance.CBAPHFGNLLH.KAFICDJOIND();
			val2 = Singleton<GameController>.instance.CBAPHFGNLLH.SerializedStringOfWarcardsForServerAfterPlayWarcardsTutorial();
		}
		UnityEngine.Debug.Log("Shotgunner spawned" + Singleton<GameController>.instance.battleId);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("RewardId", Singleton<GameController>.instance.battleId));
		int num2 = (int)IOJHEOBIIPE;
		list.Add(new Tuple<string, string>(",", num2.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("ID_WARNING_NOTENOUGHSCRAPS", num.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("BlackMarketOffer", Singleton<PhotonConnectionManager>.instance.KKLAPJPNLIJ() ? "menu-sidetab-challenge" : "\"NaN\""));
		list.Add(new Tuple<string, string>("registerEvent", val2));
		list.Add(new Tuple<string, string>("ID_ERROR_SHORTINPUT", CardManager.instance.GetUsedCards()));
		list.Add(new Tuple<string, string>("special", Singleton<ScoreManager>.instance.IAOLLEBPOLK.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("RETRY", Singleton<ScoreManager>.instance.HOHGDIKCKFM.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("LEAVING ARENA BATTLE", "GameControllerDeathmatch.StartGame DONE"));
		list.Add(new Tuple<string, string>("unlock level for: ", val));
		list.Add(new Tuple<string, string>("LevelName", JsonConvert.SerializeObject(StatsManager.instance.matchStats)));
		list.Add(new Tuple<string, string>("rocket", LevelManager.instance.currentLevel.MJABPEFBNKH().ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("S", PlayerAnalytics.instance.data.goldBonuses.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("AdDeclined(", StatsManager.instance.battlesLostInRow.ToString()));
		List<Tuple<string, string>> list2 = list;
		int num3 = EventAssignmentManager.CJOFBPIPJEP().OFMBCMKPDIE();
		if (num3 > 1)
		{
			list2.Add(new Tuple<string, string>("()I", num3.ToString()));
		}
		if (Singleton<GameController>.instance.isPVP)
		{
			list2.Add(new Tuple<string, string>("Processing the request Timed Out!", JsonConvert.SerializeObject(BattleAnalyticsManager.NPAJKFMCPPC().HFKFFPEOAGN)));
		}
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			UnityEngine.Debug.Log("game-neardeath-indicator");
			list2.Add(new Tuple<string, string>("Arena Expired - you gain scraps. You have {0} lives.", "FriendsListUpdated()"));
			TutorialManagerPlayWarcards.instance.FinishTutorial();
		}
		Tuple<string, string> userDeviceData = UserDeviceManager.instance.GetUserDeviceData();
		if (userDeviceData != null)
		{
			list2.Add(new Tuple<string, string>("false", userDeviceData.Value1));
			list2.Add(new Tuple<string, string>("BAND_REWARD_HEALTH", userDeviceData.Value2));
		}
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			list2.Add(new Tuple<string, string>("ACD: Speedhack detected!", squadName));
			JMHLHIIMNIG jMHLHIIMNIG = Singleton<ServerResultsCache>.instance.JILGBKANGNB();
			if (jMHLHIIMNIG != null)
			{
				float[] array = jMHLHIIMNIG.OEKPFGJLODF(Singleton<ServerResultsCache>.instance.JJMAIFPBAFA());
				if (array != null && jMHLHIIMNIG.DBNNKLCNDJD == squadName)
				{
					list2.Add(new Tuple<string, string>("ANDROID: PACK ", JsonConvert.SerializeObject(array)));
					list2.Add(new Tuple<string, string>("SETTING FullResNoMS", jMHLHIIMNIG.CAEILGMELMP.ToString(CultureInfo.InvariantCulture)));
				}
			}
		}
		if (IOJHEOBIIPE == (GameController.HKGHCIEPGEL)20 || IOJHEOBIIPE == (GameController.HKGHCIEPGEL)4 || IOJHEOBIIPE == GameController.HKGHCIEPGEL.Kia)
		{
			list2.Add(new Tuple<string, string>("Hidding ", Mathf.Clamp(Singleton<GameController>.instance.time, 1963f, 697f).ToString(CultureInfo.InvariantCulture)));
		}
		if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			UnityEngine.Debug.Log("RATE APP - counter set to max: ");
			list2.Add(new Tuple<string, string>("BatchSizeMin", (DailyMissionsManager.instance.LFFBCGDBGHH().number - 0).ToString()));
			list2.Add(new Tuple<string, string>("facebookFriends", DailyMissionsManager.instance.LFFBCGDBGHH().missionType.ToString()));
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			list2.Add(new Tuple<string, string>("setAltitude", "ID_"));
		}
		Dictionary<string, object> dictionary = Singleton<EventTrackingManager>.instance.fuseboxxService.OJMJBOODBPA();
		if (dictionary != null && dictionary.ContainsKey("Hearts") && dictionary.ContainsKey("init"))
		{
			UnityEngine.Debug.Log("Join_Request" + dictionary["ID_YOUVEENTEREDALEAGUE"]);
			list2.Add(new Tuple<string, string>("localPlayerLeaderboard", dictionary["PostParameters"].ToString()));
			list2.Add(new Tuple<string, string>("WRONG dynamic font size: {0} for scale: {1} for label: {2}", dictionary["ID_GUI_VIPMEMBERSHIP"].ToString()));
		}
		string text = Singleton<EventTrackingManager>.instance.fuseboxxService.IFKAGELCOHC();
		if (text != null)
		{
			UnityEngine.Debug.Log("ServerResponseHandler.LoadPlayerData" + text);
			list2.Add(new Tuple<string, string>("Id", text));
		}
		string text2 = Singleton<EventTrackingManager>.instance.fuseboxxService.CLLHFANPONM();
		if (!string.IsNullOrEmpty(text2))
		{
			UnityEngine.Debug.Log("PrepareBotForDeathMatch 10" + text2);
			list2.Add(new Tuple<string, string>("BlackMarketOffer", text2));
		}
		else
		{
			UnityEngine.Debug.Log("ID_RETRY");
		}
		BattleRewardsManager.instance.ClearAllRewards();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.BuyWeaponUpgrade, list2)));
	}

	internal void DIBMFGGICPM(string JODJNIDBCEE, string AAKEFDLNOIG, List<Card> MDHBFKALKHA)
	{
		UnityEngine.Debug.Log("<" + JODJNIDBCEE + "warbucks" + AAKEFDLNOIG);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Player_Avoided_Grenade_On_First_Try", JODJNIDBCEE));
		list.Add(new Tuple<string, string>("1", AAKEFDLNOIG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)144, gMDJHENPLHB)));
		int[] rarityCounts = CardManager.instance.GetRarityCounts();
		foreach (Card item in MDHBFKALKHA)
		{
			string iCDKHLOBKIE = ((!item.isBuddyCard) ? item.id : "D2");
			Singleton<EventTrackingManager>.instance.AELDEBEBIJO(iCDKHLOBKIE, rarityCounts);
		}
	}

	internal void NCNILFEFGMN()
	{
		RequestBufferManager.instance.ForceSendClaimAssignment();
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-129), gMDJHENPLHB)));
	}

	private HTTPRequest IDJMODEAAFI(int NOCEDALFEJM)
	{
		int num = PACBAKNGKEK(NOCEDALFEJM, DatabaseAction.CreateAccount);
		int num2 = AGHNMMODJKG.LastIndexOf('/');
		string uriString = AGHNMMODJKG.Substring(0, num2 + 1) + "check.php";
		HTTPRequest hTTPRequest = new HTTPRequest(new Uri(uriString), HTTPMethods.Post, PMDMLGKLMKO);
		hTTPRequest.Timeout = TimeSpan.FromSeconds(num);
		hTTPRequest.ConnectTimeout = TimeSpan.FromSeconds(num);
		hTTPRequest.DisableRetry = true;
		hTTPRequest.DisableCache = true;
		HTTPRequest hTTPRequest2 = hTTPRequest;
		hTTPRequest2.CustomCertificationValidator += AACFNCKFCHO;
		return hTTPRequest2;
	}

	private void PILMMAHOHIB()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Logs.LogEntry logEntry in Singleton<Logs>.instance.logEntries)
		{
			string text = "color=\"#DC143C\"";
			switch (logEntry.type)
			{
			case LogType.Log:
				text = "color=\"#333333\"";
				break;
			case LogType.Warning:
				text = "color=\"#FFD700\"";
				break;
			}
			stringBuilder.AppendLine("<font " + text + " >");
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.type.ToString()));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.output));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.stack));
			stringBuilder.AppendLine("\n</font>");
		}
		SendLogs(stringBuilder);
	}

	internal void HEIHBHKEAGA(string AAALKPMBFCJ, string DBNNKLCNDJD)
	{
		UnityEngine.Debug.Log("setGender" + DBNNKLCNDJD);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("registerEvent", DBNNKLCNDJD));
		list.Add(new Tuple<string, string>("Beginners League:{0}  LeagueMedals: {1}  GLobalMedals: {2}", AAALKPMBFCJ));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-37), gMDJHENPLHB)));
	}

	public void GameStartedClient()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("IsHitList", "0"));
		list.Add(new Tuple<string, string>("IsMatchMaking", (!Singleton<GameController>.instance.isRandomMatchMaking) ? "0" : "1"));
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		list.Add(new Tuple<string, string>("IsWarArenaBattle", (!Singleton<GameController>.instance.isWarArena) ? "0" : "1"));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameStartedClient, gMDJHENPLHB)));
	}

	internal void CDPEBDEJNFK()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameStartedMaster, gMDJHENPLHB)));
	}

	internal void MJDKPGKHNKH()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-188), gMDJHENPLHB)));
	}

	public void JHLNHMBEPHM()
	{
		UnityEngine.Debug.Log("FuseRewardedOptionKey_PostRollContinueButtonText");
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-181), gMDJHENPLHB)));
	}

	public string EKEPPFLNBBH()
	{
		string cLPCLFBGHEM = CLPCLFBGHEM;
		CLPCLFBGHEM = null;
		return cLPCLFBGHEM;
	}

	public void AcceptSpecialOffer()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AcceptSpecialOffer, gMDJHENPLHB)));
	}

	internal void NDMEFKMDMIO(ICFCHEHNHEN PNAKMCNGGHE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_STAT_MISSIONSHEROIC", PNAKMCNGGHE.NHHGDIDEIMM));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetAllMessages, gMDJHENPLHB)));
	}

	[SpecialName]
	public void NNDMMGIGLHH(Action<DatabaseAction, int, CAMPAFGONHH> IDEBKDPMPGM)
	{
		Action<DatabaseAction, int, CAMPAFGONHH> action = NMHNPJGHPDK;
		Action<DatabaseAction, int, CAMPAFGONHH> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NMHNPJGHPDK, (Action<DatabaseAction, int, CAMPAFGONHH>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void SendServerRequest(DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> ABMLHILNNDM)
	{
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(MHLAAHNPMFG, ABMLHILNNDM)));
	}

	internal void LCGHIEBJBKC()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", GameLoginManager.currentPlayer.name));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameStartedTutorial, gMDJHENPLHB)));
	}

	internal void ADHFEBMEPLO(string EJBEDLHIKDG, string PGHCHNIDLNJ, AccountType FEPHCHKJGHD)
	{
		UnityEngine.Debug.Log("Login: id = " + EJBEDLHIKDG + ", password = " + PGHCHNIDLNJ + ", account type = " + FEPHCHKJGHD);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Id", EJBEDLHIKDG));
		list.Add(new Tuple<string, string>("Password", PGHCHNIDLNJ));
		int num = (int)FEPHCHKJGHD;
		list.Add(new Tuple<string, string>("AccountType", num.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.LoginToCustomAccount, gMDJHENPLHB)));
	}

	internal void HCEPBIBJLMD(DatabasePlayer CHGMPGCOBIL)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToPromoteId", CHGMPGCOBIL.id));
		int squadRank = (int)CHGMPGCOBIL.squadRank;
		list.Add(new Tuple<string, string>("OldSquadRank", squadRank.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.PromotePlayer, gMDJHENPLHB)));
	}

	[SpecialName]
	public void BLEAEDFHNJD(Action<DatabaseAction> IDEBKDPMPGM)
	{
		Action<DatabaseAction> action = BIELMEODOCB;
		Action<DatabaseAction> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BIELMEODOCB, (Action<DatabaseAction>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	private static string IBMMEMIGPCF()
	{
		if (string.IsNullOrEmpty(PBBLPPHJMPJ))
		{
			PBBLPPHJMPJ = test() + OGLEHLIPEFM.KOMJCLFNFIC() + LEDNENKKDJM.MGNAHDCCOKL();
		}
		return PBBLPPHJMPJ;
	}

	public void EOAILOJFNJG()
	{
		StopAllCoroutines();
		CLDDKGFKCLL = false;
	}

	internal void PLJDHDMFPBJ(string BCMCMKDCLGP, string PGHCHNIDLNJ)
	{
		UnityEngine.Debug.Log("HEAVYTURRET");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadLeft", BCMCMKDCLGP));
		list.Add(new Tuple<string, string>("DogTags", PGHCHNIDLNJ));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.InstantBuyUnit, gMDJHENPLHB)));
		LoadingDialog.ShowLoading(Localization.Localize("Overtime_Was_Already_Explained"), true);
	}

	internal void ILOFCIKMFLH(PlayerStatus CKCJBIIPEOG)
	{
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		int num = (int)CKCJBIIPEOG;
		list.Add(new Tuple<string, string>("WarCards", num.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ActivateWeaponUpgrade, gMDJHENPLHB)));
	}

	internal void FBANDFJDDPJ()
	{
		if (Singleton<GameController>.instance.isTutorialInProgressOrPlaned)
		{
			UnityEngine.Debug.Log("#Google play# gpgs logout during tutorial - ignore");
			return;
		}
		UnityEngine.Debug.Log("BS: Remove Google Play");
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.RemoveGooglePlay, gMDJHENPLHB)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	public void ADNKFFBLMNG()
	{
		UnityEngine.Debug.Log("\n");
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-75), gMDJHENPLHB)));
	}

	public void LHMLILDBJAO(bool PPNMHPBMIJE = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("unit {0} start {1} end {2} current {3} activation needed {4} bought {5}", PPNMHPBMIJE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-41), gMDJHENPLHB)));
	}

	[DebuggerHidden]
	private IEnumerator DOOKHODNDPO()
	{
		HAJKDECCLJD hAJKDECCLJD = new HAJKDECCLJD();
		hAJKDECCLJD.BJGCPDNMHDH = this;
		return hAJKDECCLJD;
	}

	public void BILMBJOPADA(bool PPNMHPBMIJE = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("weapon doesnt have ammo setup", PPNMHPBMIJE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-131), gMDJHENPLHB)));
	}

	internal void EOGOBBFCINM(string JODJNIDBCEE, string AAKEFDLNOIG, List<Card> MDHBFKALKHA)
	{
		UnityEngine.Debug.Log("relog OK" + JODJNIDBCEE + "ID_PLAYWARPATH" + AAKEFDLNOIG);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_SLOTUPGRADE_ROF", JODJNIDBCEE));
		list.Add(new Tuple<string, string>("Squad Request Sent!", AAKEFDLNOIG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.RemoveFacebook, gMDJHENPLHB)));
		int[] rarityCounts = CardManager.instance.GetRarityCounts();
		foreach (Card item in MDHBFKALKHA)
		{
			string iCDKHLOBKIE = ((!item.isBuddyCard) ? item.id : "percent");
			Singleton<EventTrackingManager>.instance.AELDEBEBIJO(iCDKHLOBKIE, rarityCounts);
		}
	}

	[SpecialName]
	public bool CBDHGGLCDNE()
	{
		return Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu && GameLoginManager.instance.data.isDeviceRegistered && !Singleton<GameController>.instance.isTutorial && isPlayerDataLoaded;
	}

	internal void GHCOFGNAMDG(List<Dictionary<string, string>> ONODAKHMGKB)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Packs", JsonConvert.SerializeObject(ONODAKHMGKB)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.RefundPack, gMDJHENPLHB)));
	}

	[SpecialName]
	public void EAKNGBPDDAK(Action<DatabaseAction> IDEBKDPMPGM)
	{
		Action<DatabaseAction> action = BIELMEODOCB;
		Action<DatabaseAction> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BIELMEODOCB, (Action<DatabaseAction>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void LINEMJAIGMI(string IFFONNNPKOF, string NHHGDIDEIMM = "")
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("NewSquadId", IFFONNNPKOF));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(NHHGDIDEIMM))
		{
			list2.Add(new Tuple<string, string>("MessageId", NHHGDIDEIMM));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.JoinSquad, list2)));
		WaitingDialog.ShowDialog();
	}

	public static void LoadSquadMembers(IDictionary<string, object> FBFJNHLKJEC)
	{
		if (!FBFJNHLKJEC.ContainsKey("SquadMembers"))
		{
			return;
		}
		JArray jArray = (JArray)FBFJNHLKJEC["SquadMembers"];
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		foreach (JToken item in jArray)
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(item);
			list.Add(databasePlayer);
			if (databasePlayer.id == GameLoginManager.currentPlayer.id)
			{
				GameLoginManager.instance.UpdatePlayerSquadRank(databasePlayer.squadRank);
			}
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("squadMembers" + currentPlayer.squadName, list, DateTime.Now.AddMinutes(2.0), DatabaseAction.GetAllSquadMembers);
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
	}

	public void KOIOPACIMDM(Exception KIJELCLONNC, object OMJLGCLJNBD, string CKGAHLKBKMI)
	{
		if (!DIEFNOGGPOA)
		{
			UnityEngine.Debug.LogError("FuseSDK: Parsing error in _AdAvailabilityResponse" + OMJLGCLJNBD);
			UnityEngine.Debug.LogError("DogtagPrice" + KIJELCLONNC.Message);
			UnityEngine.Debug.LogError("TweetAboutWarfriends" + CKGAHLKBKMI);
			if (BDJLFKHICIL.DLKMLPAHJEI)
			{
				UnityEngine.Debug.Log("CX6896566GD");
			}
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("ID_SQUADINVITE", (currentPlayer == null) ? "NONE WARCARDS TO ADD FROM CARDPOOL" : currentPlayer.name));
			list.Add(new Tuple<string, string>("ID_ARENARULES_RANDOMUNITS", KIJELCLONNC.Message));
			list.Add(new Tuple<string, string>("placement", KIJELCLONNC.StackTrace));
			list.Add(new Tuple<string, string>("N", "NO" + OMJLGCLJNBD));
			list.Add(new Tuple<string, string>("ID_READYTIME", Singleton<CurrentBundleVersion>.instance.DPGPNPOOHJM()));
			List<Tuple<string, string>> gMDJHENPLHB = list;
			StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetSquadWarsDivision, gMDJHENPLHB)));
		}
	}

	internal void MOGOJFFMFED()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.LeaveSquad, gMDJHENPLHB)));
		WaitingDialog.ShowDialog("ID_LEAVINGSQUAD");
	}

	internal void EJEPBPMDBIJ()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("Scraps", squadName));
			List<Tuple<string, string>> gMDJHENPLHB = list;
			StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-146), gMDJHENPLHB)));
		}
	}

	internal void CLAOLIOKIPP()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.OnSubscriptionExpired, gMDJHENPLHB)));
	}

	internal void NFEKIEFPAOP(string PDDLJMAMDCE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("NewCountryCode", PDDLJMAMDCE));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		UnityEngine.Debug.LogError("changing country to " + PDDLJMAMDCE);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ChangePlayerCountry, gMDJHENPLHB)));
	}

	internal void ODDNJBFNKNN()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.craftingShown = true;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CraftingShown, gMDJHENPLHB)));
	}

	[DebuggerHidden]
	private IEnumerator HKHCPGEBIMH(Action LMLFDOGFAHO)
	{
		LKFGBKLMCKN lKFGBKLMCKN = new LKFGBKLMCKN();
		lKFGBKLMCKN.LMLFDOGFAHO = LMLFDOGFAHO;
		lKFGBKLMCKN.BJGCPDNMHDH = this;
		return lKFGBKLMCKN;
	}

	internal void COKLIJOFGOF()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		UnityEngine.Debug.Log("Beanstalk: Test");
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.Test, gMDJHENPLHB)));
	}

	[SpecialName]
	public void PMBFFAKGPNH(Action IDEBKDPMPGM)
	{
		Action action = KJBOMKICEBK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KJBOMKICEBK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	private void MMNKNBKLFFC(bool IDEBKDPMPGM)
	{
		_003CAKDLGLKJOKI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void DGPKFLNLFDD(Action<AANECPGDMGM> IDEBKDPMPGM)
	{
		Action<AANECPGDMGM> action = LFGPLIPPBCN;
		Action<AANECPGDMGM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LFGPLIPPBCN, (Action<AANECPGDMGM>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void PlayerDataWasLoaded(bool NBKAIPANLBM)
	{
		ALJKAAMHHLB.POPONJAMPDF("BeanstalkServerManager.PlayerDataWasLoaded START");
		if (NBKAIPANLBM)
		{
			StartCoroutine(JIPONODIINO());
			ALJKAAMHHLB.POPONJAMPDF("BeanstalkServerManager.PlayerDataWasLoaded - DONE (coroutines)");
		}
		else
		{
			JIHFFFHPOAP();
			ALJKAAMHHLB.POPONJAMPDF("BeanstalkServerManager.PlayerDataWasLoaded - DONE (events)");
		}
	}

	internal void GFHBHIJKMEE()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameStartedCampaign, gMDJHENPLHB)));
	}

	public void checkDaylyRewards()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.CheckDailyReward, gMDJHENPLHB)));
	}

	internal void AOHJMKNDNOD(string DANHNODMNLG)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Icon", DANHNODMNLG));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, true);
		if (aANECPGDMGM != null)
		{
			aANECPGDMGM.DAANKCOLJGJ = DANHNODMNLG;
			Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("squad" + currentPlayer.squadName, aANECPGDMGM, DateTime.Now.AddMinutes(2.0));
			DataWasLoaded(DatabaseAction.GetSquadDetails);
		}
		UnityEngine.Debug.Log("BS: Sending emblem = " + DANHNODMNLG);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.UpdateSquadEmblem, gMDJHENPLHB)));
	}

	internal void OLEBMHEAKEA(string LIKIBPHHEHH, string AOHCIOODGJI)
	{
		UnityEngine.Debug.Log("Beanstalk: Get Configuration called. Current Sheet Configuration = " + LIKIBPHHEHH + ", Client Verison = " + Singleton<CurrentBundleVersion>.instance.shortVersion);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("abTestVariant", AOHCIOODGJI));
		list.Add(new Tuple<string, string>("SheetConfiguraton", LIKIBPHHEHH));
		list.Add(new Tuple<string, string>("Language", Localization.instance.nextLanguage));
		List<Tuple<string, string>> list2 = list;
		if (DebugSettings.debugEnabled && DebugSettings.isOurDevice && !string.IsNullOrEmpty(DebugSettings.instance.data.configVersion))
		{
			UnityEngine.Debug.LogError("FORCE DEBUG CONFIG VERSION " + DebugSettings.instance.data.configVersion);
			list2.Add(new Tuple<string, string>("DebugVersion", DebugSettings.instance.data.configVersion));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GetConfigurations, list2)));
	}

	internal void GIDMODPKGEO()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("GooglePlayLogin(", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("Id", Singleton<DogTagManager>.instance.NDBIDBECHHF().ToString()));
		list.Add(new Tuple<string, string>("RETRY", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-13), gMDJHENPLHB)));
	}

	internal void AHOMAGJIGKM(MHNMOFPPKBN MOEMPHPNBLM)
	{
		Singleton<EventTrackingManager>.instance.SetSendingAdrewardGainedToServer();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		int num = (int)MOEMPHPNBLM;
		list.Add(new Tuple<string, string>("Reward", num.ToString()));
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AddVideoReward, gMDJHENPLHB)));
	}

	internal void NEBPIHAPLNK()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.OnVIPExpired, gMDJHENPLHB)));
	}

	internal void CJOBFMKPLBE(string HGPGKHLOHEF)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("{0}{1}", HGPGKHLOHEF));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-134), gMDJHENPLHB)));
	}

	internal void OGJDPPDGANP(string CGIFEHPDBAL, bool FHKKPEIDDJN = false)
	{
		UnityEngine.Debug.Log(string.Format("Session_start", CGIFEHPDBAL, FHKKPEIDDJN));
		DatabaseAction databaseAction = DatabaseAction.ErrorMessage;
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.OOCMLOAOOIB(CGIFEHPDBAL, true);
		if (list != null && !FHKKPEIDDJN)
		{
			DataWasLoaded(databaseAction);
			return;
		}
		if (Singleton<ServerResultsCache>.instance.OFLAEANDPHJ(databaseAction))
		{
			UnityEngine.Debug.Log(string.Concat("InfluencerAlias", databaseAction, "\""));
			return;
		}
		UnityEngine.Debug.Log("Click on the ground to spawn the selected effect");
		List<Tuple<string, string>> list2 = new List<Tuple<string, string>>();
		list2.Add(new Tuple<string, string>("ID_NEWASSIGNMENTIN", CGIFEHPDBAL));
		List<Tuple<string, string>> list3 = list2;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(currentPlayer.squadRank, SquadRank.Veteran) >= 1;
		bool flag2 = string.IsNullOrEmpty(currentPlayer.squadName) || flag;
		list3.Add(new Tuple<string, string>("bot", (!flag2) ? "ID_SELECTFRIENDERRORNORESULT" : "ID_WARNING_NOTENOUGHTLEVEL"));
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(databaseAction, list3)));
	}

	public void BuyPack(string KJBPJOMHNKB, string CBMKJAFIBKH = null)
	{
		WaitingDialog.ShowDialog("ID_PURCHASINGPACK");
		CLPCLFBGHEM = CBMKJAFIBKH;
		BBIEEHPFDDL.APLNKKDEJLN(KJBPJOMHNKB);
	}

	internal void GKDEHNNMFFH(PlayerStatus CKCJBIIPEOG)
	{
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		int num = (int)CKCJBIIPEOG;
		list.Add(new Tuple<string, string>("menu-warbucks", num.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-15), gMDJHENPLHB)));
	}

	internal void JEFCEEEJMLG(string HIECCJIAHJG, IDictionary<int, Request> ABIGJNAGLGI, int ONDILBFJEEK)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BufferId", HIECCJIAHJG));
		list.Add(new Tuple<string, string>("Count", ONDILBFJEEK.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Requests", JsonConvert.SerializeObject(ABIGJNAGLGI)));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SendRequestBuffer, gMDJHENPLHB)));
	}

	internal void NCKINFLCFKI()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.warpathShown = false;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-157), gMDJHENPLHB)));
	}

	public void TutorialEnded()
	{
		GameController.HKGHCIEPGEL hKGHCIEPGEL = GameController.HKGHCIEPGEL.Win;
		int score = Singleton<ScoreManager>.instance.score;
		GameLoginManager.instance.SetPlayerDataAfterBootcamps();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		int num = (int)hKGHCIEPGEL;
		list.Add(new Tuple<string, string>("EndReason", num.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Experience", score.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("GoldBoxes", Singleton<ScoreManager>.instance.IAOLLEBPOLK.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("WarBucksBoxes", Singleton<ScoreManager>.instance.HOHGDIKCKFM.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("ObtainedCards", CardManager.instance.GetObtainedCards()));
		list.Add(new Tuple<string, string>("UsedCards", "[]"));
		list.Add(new Tuple<string, string>("Warbucks", Singleton<Wallet>.instance.warBucks.ToString()));
		list.Add(new Tuple<string, string>("Gold", Singleton<Wallet>.instance.gold.ToString()));
		list.Add(new Tuple<string, string>("ArmyPower", LevelManager.instance.armyPower.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		UnityEngine.Debug.Log("#VOJTA# ARMY POWER = " + LevelManager.instance.armyPower);
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.TutorialEnded, gMDJHENPLHB)));
	}

	internal void GOIOELEKACC()
	{
		List<Tuple<string, string>> gMDJHENPLHB = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-32), gMDJHENPLHB)));
	}

	public void CheckIsOnline(Action LMLFDOGFAHO)
	{
		UnityEngine.Debug.Log("checking connection");
		StartCoroutine(RadicalRoutine.Run(HKHCPGEBIMH(LMLFDOGFAHO)));
	}

	internal string ILKCAOFCAMK()
	{
		string result = "UNKNOWN";
		switch (environment)
		{
		case DatabaseEnvironment.DevelopmentSvk:
			result = "DEV SVK";
			break;
		case DatabaseEnvironment.Staging:
			result = "STAG";
			break;
		case DatabaseEnvironment.Production:
			result = "PROD";
			break;
		case DatabaseEnvironment.QA:
			result = "QA";
			break;
		}
		return result;
	}

	internal void CMNMPMOKFLN(string CGIFEHPDBAL, string KBGHBHFOHFD, bool GPILKHHMOIL, string GDFOENAJEBA, string LOKHAAIPCDD)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", CGIFEHPDBAL));
		list.Add(new Tuple<string, string>("IsPublic", (!GPILKHHMOIL) ? "1" : "0"));
		list.Add(new Tuple<string, string>("Icon", LOKHAAIPCDD));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(KBGHBHFOHFD))
		{
			list2.Add(new Tuple<string, string>("Message", KBGHBHFOHFD));
		}
		list2.Add(new Tuple<string, string>("SkillRequirement", GDFOENAJEBA));
		StartCoroutine(HBFJFGANDPE(DatabaseAction.CreateSquad, list2));
	}

	private void GBLGMFMHPBK()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Logs.LogEntry logEntry in Singleton<Logs>.instance.logEntries)
		{
			string text = "1";
			switch (logEntry.type)
			{
			case LogType.Warning:
				text = "Gained_WB";
				break;
			case LogType.Log:
				text = "GameLaunch";
				break;
			}
			stringBuilder.AppendLine("Card_3_Played" + text + "Daily");
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.type.ToString()));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.output));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(SecurityElement.Escape(logEntry.stack));
			stringBuilder.AppendLine("AssignmentData");
		}
		SendLogs(stringBuilder);
	}

	[SpecialName]
	public void BEKKAGDJEEB(Action IDEBKDPMPGM)
	{
		Action action = PNPJAHOENJN;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PNPJAHOENJN, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal void FGIPNMHPLME(HHFHFANGCEJ PNAKMCNGGHE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("MessageId", PNAKMCNGGHE.NHHGDIDEIMM));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.ClaimReward, gMDJHENPLHB)));
	}

	internal void LLIDDCCBOII(string PIIIKJJHJPN)
	{
		string val = "0";
		string text = string.Empty;
		if (!string.IsNullOrEmpty(PIIIKJJHJPN))
		{
			text = MEJMLNDFDBP.BGCDGDKEGBH(PIIIKJJHJPN + "banana");
			val = "1";
		}
		UnityEngine.Debug.Log("updating GC to: " + PIIIKJJHJPN + " pass: " + text);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("haveGcId", val));
		list.Add(new Tuple<string, string>("GameCenterId", PIIIKJJHJPN));
		list.Add(new Tuple<string, string>("GameCenterPassword", text));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.RemoveOrUpdateGC, gMDJHENPLHB)));
	}

	internal void LAEDANHIGNM()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("EnteredLeague", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("Enemy could not be spawned", Singleton<DogTagManager>.instance.FDMCHFNPALJ().ToString()));
		list.Add(new Tuple<string, string>("ID_MEMBERS", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.DecalWasShown, gMDJHENPLHB)));
	}

	[SpecialName]
	public bool DGBOELCCINL()
	{
		return Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && GameLoginManager.instance.data.isDeviceRegistered && !Singleton<GameController>.instance.DAIEAMEFGIE() && isPlayerDataLoaded;
	}

	internal void AOHKOCKCDIF(string CMBEFJMJJMC)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("fuseData", CMBEFJMJJMC));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.SaveFuseConfigs, gMDJHENPLHB)));
	}

	[SpecialName]
	public bool GFFNKLKCHBA()
	{
		return _003CAKDLGLKJOKI_003Ek__BackingField;
	}

	internal void EBFOAELMCPG(string AAALKPMBFCJ, string DBNNKLCNDJD)
	{
		UnityEngine.Debug.Log("SquadId = " + DBNNKLCNDJD);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", DBNNKLCNDJD));
		list.Add(new Tuple<string, string>("PlayerToJoin", AAALKPMBFCJ));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AcceptSquadJoinRequest, gMDJHENPLHB)));
	}

	private IEnumerator GPDNFAIIGDP()
	{
		PIEDAILOECP pIEDAILOECP = new PIEDAILOECP();
		pIEDAILOECP.BJGCPDNMHDH = this;
		return pIEDAILOECP;
	}

	public void CheckIfExistGpgsAccount(string ILIBDMKPFKN)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("GooglePlayId", ILIBDMKPFKN));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.TutorialCheckGPGSAccount, gMDJHENPLHB)));
	}

	internal void EBPGOPEHDMP()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.GameStartedCoopMaster, gMDJHENPLHB)));
	}

	public void LFCAPPILEPB(int DFHAAIFFLOE)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ID_CONFIRM_LOGGEDOUT_TEXT", DFHAAIFFLOE.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE((DatabaseAction)(-185), gMDJHENPLHB)));
	}

	public void PayOneDogtag()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("DogTagRefillTime", Singleton<DogTagManager>.instance.constDogtagSeconds.ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", Singleton<DogTagManager>.instance.constDogtagCount.ToString()));
		List<Tuple<string, string>> gMDJHENPLHB = list;
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.PayOneDogTag, gMDJHENPLHB)));
	}

	public void HEMGJGBKPIF(string PNAKMCNGGHE, bool IOLNJBGOOLJ, int OHECBHDELEO)
	{
		UnityEngine.Debug.Log("ID_READYTIME" + PNAKMCNGGHE);
		UnityEngine.Debug.Log("ID_DELIVEREDTIME" + ((!IOLNJBGOOLJ) ? "Recieved {0} memory warnings in last 10 seconds" : "Id"));
		UnityEngine.Debug.Log("menu-weaponstats-rateoffire" + OHECBHDELEO);
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, true);
		if (aANECPGDMGM != null)
		{
			aANECPGDMGM.PNAKMCNGGHE = PNAKMCNGGHE;
			aANECPGDMGM.IOLNJBGOOLJ = IOLNJBGOOLJ;
			aANECPGDMGM.GDFOENAJEBA = OHECBHDELEO;
			Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("ID_STAT_MOSTSQUADPOINTS" + currentPlayer.squadName, aANECPGDMGM, DateTime.Now.AddMinutes(535.0), DatabaseAction.GameStartedCoopMaster);
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>(" = ", (!IOLNJBGOOLJ) ? "StartTime" : "Warper"));
		list.Add(new Tuple<string, string>("RejectFriend(", OHECBHDELEO.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(PNAKMCNGGHE))
		{
			list2.Add(new Tuple<string, string>("unit", PNAKMCNGGHE));
		}
		StartCoroutine(RadicalRoutine.Run(HBFJFGANDPE(DatabaseAction.AddFacebook, list2)));
	}
}
