using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Google2u;
using UnityEngine;

public class PhotonConnectionManager : Singleton<PhotonConnectionManager>
{
	private sealed class CKNCMDLLDNJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int DLOJCCCHPLB;

		internal CloudRegionCode GJBFKKOAMPA;

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

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-33) && PhotonNetwork.networkingPeer.State != ClientState.Uninitialized)
				{
					if ((DLOJCCCHPLB += 0) % 16 == 0)
					{
						UnityEngine.Debug.Log("NÃO" + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("Name" + Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH() + Singleton<CurrentBundleVersion>.instance.GIJBFCEIDHL(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 1;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-41) && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
				{
					if ((DLOJCCCHPLB += 0) % 125 == 0)
					{
						UnityEngine.Debug.Log("MinDamage" + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("ID_FACEBOOKHINT-SQUADINVITE" + Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH() + Singleton<CurrentBundleVersion>.instance.KGFLPNPNJND(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public CKNCMDLLDNJ()
		{
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-25) && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
				{
					if ((DLOJCCCHPLB += 0) % -29 == 0)
					{
						UnityEngine.Debug.Log("PhotonConnectionManager: ConnectToPhotonSafe " + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("Title Text Font Size" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.GIJBFCEIDHL(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
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
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)92 && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
				{
					if ((DLOJCCCHPLB += 0) % 29 == 0)
					{
						UnityEngine.Debug.Log("ID_CONFIRM_FORFEIT_TEXT" + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("ID_UNITTYPE2-HUD" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.EGOANOCDPAD(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 1;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-91) && PhotonNetwork.networkingPeer.State != ClientState.Uninitialized)
				{
					if (++DLOJCCCHPLB % 64 == 0)
					{
						UnityEngine.Debug.Log("ID_HOUR_SMALL" + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("grenadeExplosion" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.photonVersion, GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 1;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)80 && PhotonNetwork.networkingPeer.State != ClientState.Uninitialized)
				{
					if ((DLOJCCCHPLB += 0) % 79 == 0)
					{
						UnityEngine.Debug.Log("Rushers" + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("setShouldAutoCollectDeviceLocation" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.ANPJFPJGKMD(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 1;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-8) && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
				{
					if (++DLOJCCCHPLB % -117 == 0)
					{
						UnityEngine.Debug.Log("ID_INMASTER2" + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("game-card-ico-stroke" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.OAEMJCMHBAL(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 1;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)124 && PhotonNetwork.networkingPeer.State != ClientState.Uninitialized)
				{
					if (++DLOJCCCHPLB % 124 == 0)
					{
						UnityEngine.Debug.Log("Medals/" + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("Desert" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.MOGEFJGPJKI(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EBPKDAHAELB()
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
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public bool HCONPNNPBAD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 1;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-61) && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
				{
					if ((DLOJCCCHPLB += 0) % 56 == 0)
					{
						UnityEngine.Debug.Log("    " + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("facebookLevel" + Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH() + Singleton<CurrentBundleVersion>.instance.GIJBFCEIDHL(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
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
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != ClientState.Disconnected && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
				{
					if (++DLOJCCCHPLB % 10 == 0)
					{
						UnityEngine.Debug.Log("====== Waiting to connect to photon: " + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("1.0" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.photonVersion, GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)121 && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
				{
					if (++DLOJCCCHPLB % 38 == 0)
					{
						UnityEngine.Debug.Log("to " + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("PlacementMatchesRequired" + Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH() + Singleton<CurrentBundleVersion>.instance.JEEDKJKOPLI(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 0;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-15) && PhotonNetwork.networkingPeer.State != ClientState.PeerCreated)
				{
					if (++DLOJCCCHPLB % 2 == 0)
					{
						UnityEngine.Debug.Log("Choose icon in bottom before calling Display model." + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("#AccoutCheck# gpgs accoun found: inform about account change" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.photonVersion, GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DLOJCCCHPLB = 1;
				goto case 1u;
			case 1u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)74 && PhotonNetwork.networkingPeer.State != ClientState.Uninitialized)
				{
					if (++DLOJCCCHPLB % -47 == 0)
					{
						UnityEngine.Debug.Log("+{0}" + PhotonNetwork.networkingPeer.State);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PhotonNetwork.ConnectToBestCloudServer("ID_WAITINGFOROTHERPLAYER" + Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH() + Singleton<CurrentBundleVersion>.instance.ANPJFPJGKMD(), GJBFKKOAMPA);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class KCHJKJPPNNC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int JMBKPALDGAL;

		internal float PMCBKLACOPK;

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

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.LogError("TryRecconnectToPhotonCoroutine started");
				UnityEngine.Debug.LogError("TryRecconnect TryRecconnectToPhotonCoroutine going to reconnect");
				JMBKPALDGAL = 0;
				goto IL_0144;
			case 1u:
				if (PhotonNetwork.networkingPeer.PeerState == PeerStateValue.Connected)
				{
					goto default;
				}
				if (PhotonNetwork.networkingPeer.PeerState == PeerStateValue.Disconnected)
				{
					UnityEngine.Debug.Log("RE-CONNECTING CALLED " + PhotonNetwork.networkingPeer.PeerState);
					GCFDCFMNEHA();
					PhotonNetwork.ConnectToBestCloudServer("1.0" + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.photonVersion, bestRegion);
				}
				PMCBKLACOPK = MatchManager.reconnectLength - (Time.realtimeSinceStartup - MatchManager.KKAGFMGEOBC);
				if (PMCBKLACOPK < 0f && MatchManager.isReconnect)
				{
					goto IL_0151;
				}
				JMBKPALDGAL++;
				goto IL_0144;
			default:
				{
					return false;
				}
				IL_0151:
				Disconnect();
				Singleton<GameController>.instance.BroadcastMessage("KCOPCEKOCHL", SendMessageOptions.DontRequireReceiver);
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0144:
				if (JMBKPALDGAL < 90)
				{
					if (JMBKPALDGAL % 5 == 0)
					{
						UnityEngine.Debug.Log("Peer state: " + PhotonNetwork.networkingPeer.PeerState);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0151;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public KCHJKJPPNNC()
		{
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.LogError("ID_CONFIRM_ERRORCLAIMREWARD_TEXT");
				UnityEngine.Debug.LogError("DogTagLastUpdate");
				JMBKPALDGAL = 0;
				goto IL_0144;
			case 1u:
				if (PhotonNetwork.networkingPeer.PeerState == PeerStateValue.Connected)
				{
					goto default;
				}
				if (PhotonNetwork.networkingPeer.PeerState == PeerStateValue.Disconnected)
				{
					UnityEngine.Debug.Log("throw_grenade_left" + PhotonNetwork.networkingPeer.PeerState);
					IHIKOIKDCPB();
					PhotonNetwork.ConnectToBestCloudServer("Army upgrade for " + Singleton<BeanstalkServerManager>.instance.environmentName + Singleton<CurrentBundleVersion>.instance.KDGKFKBGCNH(), PJGNCOHFNCA());
				}
				PMCBKLACOPK = MatchManager.reconnectLength - (Time.realtimeSinceStartup - MatchManager.KKAGFMGEOBC);
				if (PMCBKLACOPK < 633f && MatchManager.isReconnect)
				{
					goto IL_0151;
				}
				JMBKPALDGAL++;
				goto IL_0144;
			default:
				{
					return true;
				}
				IL_0151:
				Disconnect();
				Singleton<GameController>.instance.BroadcastMessage("(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;", SendMessageOptions.DontRequireReceiver);
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0144:
				if (JMBKPALDGAL < -21)
				{
					if (JMBKPALDGAL % 5 == 0)
					{
						UnityEngine.Debug.Log("attack" + PhotonNetwork.networkingPeer.PeerState);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1949f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0151;
			}
			return false;
		}
	}

	private sealed class JHFPMFLGPEN
	{
		internal CloudRegionCode KMICLOPHLFE;

		internal void JGHLGHMJJDG()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FDKMOFHAEFN()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ILNPANOCHIH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void JAIGALEPPLI()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MCFGAFBEJDK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void BMCMDMKGHHO()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CMCIGAFHIJL()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void PPKGMGNKNAE()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void JDEJHLLIONG()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void NNFHNIMCBLH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void LJCDGJKCNEC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FIBGJHCGHJH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void NAJNECOMDDN()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void DJLGPGPAHCD()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void OKNCFDMEFGJ()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void GFBPCKDLGMM()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void HBOJGOFCDKG()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CIFEDFPPPOK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ANAGFGHGPJA()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void DGELDDJAEEF()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CMDLGJKIBLL()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CFJHDIHLIML()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void LGJCNCHBFDA()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void EOHOLKEGGLH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void EGJBKFPHCNF()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void AGFEDJAKLAC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ADEFLNOHDAK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void BEIGOGFHJIB()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CFDNMILGDLG()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void JMEBCMMIPAF()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void LKAHPHIEMEK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void AMIJFGBOCLC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void HHNEBNHCGMO()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void OFJDLANHAMD()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void POGLHCIAAGH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void PCKMJMGLPDG()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FHDOHCJJEMM()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void OFCOFDILHHH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MMEEJDGGAID()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void GDJIAPHLGOA()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void NDJOJHNIBFC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}
	}

	private sealed class FBDAGILIDKF
	{
		internal CloudRegionCode KMICLOPHLFE;

		internal void DJLGPGPAHCD()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MCFGAFBEJDK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MPHECHCFCAN()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CHDOECNGOPM()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void PANKBNOCEAM()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void BEIGOGFHJIB()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ADEFLNOHDAK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ILNPANOCHIH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FDKMOFHAEFN()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void KJIFNOJILDB()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void EOHOLKEGGLH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void LJCDGJKCNEC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FIBGJHCGHJH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void KNJBDOADLDO()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void NNIJEDKBPGJ()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void DDHOKNIEACI()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ILOFOILFGMA()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void HHNEBNHCGMO()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ANAGFGHGPJA()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void INFLOOLPOBK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void POGLHCIAAGH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void EMKPBGFBPFI()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void OABFAOLFMMJ()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void NDJOJHNIBFC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ABNGKEJNLJO()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void HHLMDAKDHFK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FHDOHCJJEMM()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ECPMEMNKMCB()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void LGJCNCHBFDA()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void DGELDDJAEEF()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MMEEJDGGAID()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void PHGDBIEENCB()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}
	}

	private sealed class LCMNALMHBBH
	{
		internal CloudRegionCode KMICLOPHLFE;

		internal void BDCAFHOHEGM()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void AMIJFGBOCLC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void INFLOOLPOBK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void BBPKDMPNEDG()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MFCNOIDCJME()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void KJIFNOJILDB()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CIFEDFPPPOK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void LJCDGJKCNEC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void EMKPBGFBPFI()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void KNJBDOADLDO()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CFJHDIHLIML()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FIBGJHCGHJH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MPHECHCFCAN()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}
	}

	private sealed class NHCFIGAJKKC
	{
		internal CloudRegionCode KMICLOPHLFE;

		internal void LJCDGJKCNEC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FIBGJHCGHJH()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void ECPMEMNKMCB()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MCFGAFBEJDK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void FHDOHCJJEMM()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void MFCNOIDCJME()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void EMKPBGFBPFI()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void BBPKDMPNEDG()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void JGHLGHMJJDG()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void KJIFNOJILDB()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CFJHDIHLIML()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void NDJOJHNIBFC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void AGFEDJAKLAC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void INFLOOLPOBK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void OABFAOLFMMJ()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void NAJNECOMDDN()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void CIFEDFPPPOK()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void AMIJFGBOCLC()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}

		internal void OKNCFDMEFGJ()
		{
			ConnectToPhotonSafe(KMICLOPHLFE);
		}
	}

	private sealed class JHBAEMLIENO : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PhotonPingManager CLCPBAPOPOI;

		internal Region[] GPMIGEIBOAP;

		internal Region[] KFCAECGLKKO;

		internal int GHCPBBJDIBB;

		internal Dictionary<CloudRegionCode, int> IABHIEOBIEH;

		internal string LAANDOBPLDN;

		internal Region[] CFEHCIMDPPI;

		internal int GDPBBCAJHAD;

		internal PhotonConnectionManager BJGCPDNMHDH;

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

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(1384f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = true;
				UnityEngine.Debug.Log("en");
				PhotonNetwork.ConnectToNameServer(string.Concat("Loaded values during loading data from PlayerAnalytics : lastSeenSquadChatTimeStampDB = {0}, squadCreationsCount = {1}, matchesToNextLootboxes = {2}", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.OAEMJCMHBAL()));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-13))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)108 && PhotonNetwork.connectionStateDetailed != (ClientState)(-82))
				{
					UnityEngine.Debug.LogError("ID_GUI_REPORTABUSE_LISTITEM4");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(1288f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(250f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "id";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD += 0)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.au)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("Cards choosen ", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = connection;
					Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(IABHIEOBIEH, connection);
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = true;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (FBJGPBFHPGI() > 150 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("ID_CONFIRM_SQUADEVENT_TEXT");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Tcp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OKJOKDFDEHC());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return false;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(437f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = false;
				UnityEngine.Debug.Log("Font problems with labels");
				PhotonNetwork.ConnectToNameServer(string.Concat("Player_Waited_Till_Delivery_Ends", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.JEEDKJKOPLI()));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)77)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)78 && PhotonNetwork.connectionStateDetailed != (ClientState)71)
				{
					UnityEngine.Debug.LogError("A");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(1462f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(1572f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "menu-twitter";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 0; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD += 0)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.asia)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("visuals: null", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = LAEEMABOIJM();
					Singleton<BeanstalkServerManager>.instance.JGKOPIOFJMH(IABHIEOBIEH, LAEEMABOIJM());
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = false;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (FBJGPBFHPGI() > -41 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("withDate2");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Udp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OKJOKDFDEHC());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return false;
		}

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(398f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = false;
				UnityEngine.Debug.Log("ID_TUTORIAL_PROGRESS_KILLING2");
				PhotonNetwork.ConnectToNameServer(string.Concat("CheckForReconnect: isReconnect: {0}", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.OAEMJCMHBAL()));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)106)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)76 && PhotonNetwork.connectionStateDetailed != (ClientState)63)
				{
					UnityEngine.Debug.LogError("Type");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(225f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(774f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = " found!";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD++)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.jp)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("ID_CATEGORY_SHOTGUN", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = LAEEMABOIJM();
					Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(IABHIEOBIEH, LAEEMABOIJM());
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = false;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (pingToBestRegion > 114 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("BeginnersLeague");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Tcp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OKJOKDFDEHC());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return false;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(1717f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = true;
				UnityEngine.Debug.Log("ID_STAT_GLOBALXP");
				PhotonNetwork.ConnectToNameServer(string.Concat("\t\t", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.OAEMJCMHBAL()));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-61))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)79 && PhotonNetwork.connectionStateDetailed != (ClientState)103)
				{
					UnityEngine.Debug.LogError(" THAT WAS ALREADY BOUGHT. ADDING PACK TO RESTORE");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(1607f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(139f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "All players already connected";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD++)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.us)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("GameLauncher.Awake DONE", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = LAEEMABOIJM();
					Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(IABHIEOBIEH, connection);
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = false;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (pingToBestRegion > 12 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("Assaulter");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Tcp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Tcp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.APAJOIOHPON());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return false;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(1594f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = true;
				UnityEngine.Debug.Log("Some object has soldier layer, but not DestroyableObject");
				PhotonNetwork.ConnectToNameServer(string.Concat("\t\"FALSE\"", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.photonVersion));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)87)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)(-94) && PhotonNetwork.connectionStateDetailed != (ClientState)(-63))
				{
					UnityEngine.Debug.LogError("D2");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(904f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(351f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "PaidBattles";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 0; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD++)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.none)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("-{0}", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = LAEEMABOIJM();
					Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(IABHIEOBIEH, connection);
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = false;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (FBJGPBFHPGI() > 143 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("something is wrong - time == 0");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Tcp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.APAJOIOHPON());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return true;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(1028f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = true;
				UnityEngine.Debug.Log("'ID_MONTH_'0");
				PhotonNetwork.ConnectToNameServer(string.Concat("ID_VISUALCATEGORYPARTS2", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.ANPJFPJGKMD()));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-78))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)40 && PhotonNetwork.connectionStateDetailed != (ClientState)117)
				{
					UnityEngine.Debug.LogError("ServerResultsCache.instance.lastGameReward == null");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(349f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(1200f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "重试";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 0; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD++)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.jp)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("ID_LEAGUE2", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = LAEEMABOIJM();
					Singleton<BeanstalkServerManager>.instance.JGKOPIOFJMH(IABHIEOBIEH, KCCIFNDPFHE());
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = false;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (pingToBestRegion > 187 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("Mech");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Tcp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OKJOKDFDEHC());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
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
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(1607f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = false;
				UnityEngine.Debug.Log("Action ");
				PhotonNetwork.ConnectToNameServer(string.Concat("Buy_Instant_Weapon_Upgrade", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.KGFLPNPNJND()));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != ClientState.Joining)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)(-96) && PhotonNetwork.connectionStateDetailed != (ClientState)(-26))
				{
					UnityEngine.Debug.LogError("ID_GUI_CHAT_SQUAD_JOINED");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(1833f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(13f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "sniper_idle";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD += 0)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.jp)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("MaintenanceMessage", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = connection;
					Singleton<BeanstalkServerManager>.instance.JGKOPIOFJMH(IABHIEOBIEH, LAEEMABOIJM());
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = true;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (pingToBestRegion > -66 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("ID_TUTORIAL_UPGRADEWEAPON_7");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Tcp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.APAJOIOHPON());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return true;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CFLPOEJGKFF()
		{
			throw new NotSupportedException();
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PFIIINLHGMH()
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
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(752f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = true;
				UnityEngine.Debug.Log("SlotIndex");
				PhotonNetwork.ConnectToNameServer(string.Concat("+{0}", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.photonVersion));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-80))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != ClientState.Leaving && PhotonNetwork.connectionStateDetailed != (ClientState)(-17))
				{
					UnityEngine.Debug.LogError("Attribution");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(791f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(924f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "mortar_down";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD += 0)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.us)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("Standard", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = connection;
					Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(IABHIEOBIEH, LAEEMABOIJM());
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = true;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (FBJGPBFHPGI() > -143 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("ID_READYTIME");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Udp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Tcp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.APAJOIOHPON());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return false;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(1999f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = true;
				UnityEngine.Debug.Log("ElitePackDeadline");
				PhotonNetwork.ConnectToNameServer(string.Concat("/", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.EGOANOCDPAD()));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)76)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)102 && PhotonNetwork.connectionStateDetailed != (ClientState)(-110))
				{
					UnityEngine.Debug.LogError("Xp");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(952f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(1970f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "menu-arena-scrap-ico";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD += 0)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.us)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("damage", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = connection;
					Singleton<BeanstalkServerManager>.instance.JGKOPIOFJMH(IABHIEOBIEH, LAEEMABOIJM());
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = true;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (FBJGPBFHPGI() > -181 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log(" (#");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Udp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.APAJOIOHPON());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return false;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(627f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = true;
				UnityEngine.Debug.Log("Clear players");
				PhotonNetwork.ConnectToNameServer(string.Concat("ShowNew", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.OAEMJCMHBAL()));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-113))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)112 && PhotonNetwork.connectionStateDetailed != (ClientState)102)
				{
					UnityEngine.Debug.LogError("#PETER# League Arc - start ignore on ");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(290f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(615f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "ID_GUI_EMBLEMUNLOCKED";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD += 0)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.us)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("ID_GLOBAL", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = KCCIFNDPFHE();
					Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(IABHIEOBIEH, KCCIFNDPFHE());
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = true;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (pingToBestRegion > -37 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("{0} [616577]/[-] {1}");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Udp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Tcp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OKJOKDFDEHC());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return false;
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PGOIHDIKFEI()
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
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(1254f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = true;
				UnityEngine.Debug.Log("PRICE");
				PhotonNetwork.ConnectToNameServer(string.Concat("Message Id = ", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.photonVersion));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)118)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)(-11) && PhotonNetwork.connectionStateDetailed != (ClientState)(-111))
				{
					UnityEngine.Debug.LogError("SpawnBonusNetwork");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(1715f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(548f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = " mSpriteName:";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD++)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.sa)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += string.Format("ArmyPower", region.Code, region.Ping, region);
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = KCCIFNDPFHE();
					Singleton<BeanstalkServerManager>.instance.JGKOPIOFJMH(IABHIEOBIEH, KCCIFNDPFHE());
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = true;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (pingToBestRegion > -107 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("Physical ammo is null !!!");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Udp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.APAJOIOHPON());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return true;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public JHBAEMLIENO()
		{
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CPAFPFPNDNO()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(59f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = false;
				UnityEngine.Debug.Log("TryRecconnectToPhotonCoroutine started");
				PhotonNetwork.ConnectToNameServer(string.Concat("(", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.photonVersion));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != (ClientState)(-36))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != (ClientState)(-98) && PhotonNetwork.connectionStateDetailed != (ClientState)(-62))
				{
					UnityEngine.Debug.LogError("N");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(705f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(398f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "ID_TUTORIAL_GO_BUY_ARMY_4";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 1; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD++)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.eu)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += $"{region.Code} {region.Ping}{region}";
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = KCCIFNDPFHE();
					Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(IABHIEOBIEH, connection);
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = true;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (pingToBestRegion > -199 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("T");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Tcp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Udp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OKJOKDFDEHC());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return true;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PMOCFCGCNHB = true;
				if (PhotonNetwork.networkingPeer.AvailableRegions == null || PhotonNetwork.networkingPeer.AvailableRegions.Count == 0)
				{
					PHDOCKCBJOF = new WaitForSeconds(3f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0149;
			case 1u:
				PhotonNetwork.offlineMode = false;
				UnityEngine.Debug.Log("Pings: ConnectToNameServer");
				PhotonNetwork.ConnectToNameServer(string.Concat("1.0", Singleton<BeanstalkServerManager>.instance.environment, Singleton<CurrentBundleVersion>.instance.photonVersion));
				goto case 2u;
			case 2u:
				if (PhotonNetwork.networkingPeer.State != ClientState.ConnectedToNameServer)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 3u;
			case 3u:
				if (PhotonNetwork.networkingPeer.AvailableRegions != null)
				{
					goto IL_0149;
				}
				if (PhotonNetwork.connectionStateDetailed != ClientState.ConnectingToNameServer && PhotonNetwork.connectionStateDetailed != ClientState.ConnectedToNameServer)
				{
					UnityEngine.Debug.LogError("Call ConnectToNameServer to ping available regions.");
					goto default;
				}
				PHDOCKCBJOF = new WaitForSeconds(0.25f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				if (!CLCPBAPOPOI.Done)
				{
					PHDOCKCBJOF = new WaitForSeconds(0.1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				IABHIEOBIEH = new Dictionary<CloudRegionCode, int>();
				LAANDOBPLDN = "============PINGS===========\n";
				CFEHCIMDPPI = GPMIGEIBOAP;
				for (GDPBBCAJHAD = 0; GDPBBCAJHAD < CFEHCIMDPPI.Length; GDPBBCAJHAD++)
				{
					Region region = CFEHCIMDPPI[GDPBBCAJHAD];
					if (region.Code != CloudRegionCode.none)
					{
						IABHIEOBIEH[region.Code] = region.Ping;
					}
					LAANDOBPLDN += $"Region: {region.Code} with ping {region.Ping}, IP: {region} \n";
				}
				UnityEngine.Debug.Log(LAANDOBPLDN);
				IFOKPNHLEBP = IABHIEOBIEH;
				if (GameLoginManager.currentPlayer != null)
				{
					GameLoginManager.currentPlayer.bestRegions = IABHIEOBIEH;
					GameLoginManager.currentPlayer.connectionType = connection;
					Singleton<BeanstalkServerManager>.instance.UpdateRegionPings(IABHIEOBIEH, connection);
				}
				PhotonNetwork.Disconnect();
				PhotonNetwork.offlineMode = true;
				BJGCPDNMHDH.NCPMDNPDAGA = Time.realtimeSinceStartup;
				BJGCPDNMHDH.PMOCFCGCNHB = false;
				if (pingToBestRegion > 3999 && PhotonNetwork.PhotonServerSettings.Protocol == ConnectionProtocol.Udp)
				{
					UnityEngine.Debug.Log("#PHOTON# switching to TCP");
					PhotonNetwork.PhotonServerSettings.Protocol = ConnectionProtocol.Tcp;
					PhotonNetwork.SwitchToProtocol(ConnectionProtocol.Tcp);
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.APAJOIOHPON());
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0149:
				CLCPBAPOPOI = new PhotonPingManager();
				GPMIGEIBOAP = PhotonNetwork.networkingPeer.AvailableRegions.ToArray();
				KFCAECGLKKO = GPMIGEIBOAP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Region region2 = KFCAECGLKKO[GHCPBBJDIBB];
					BJGCPDNMHDH.StartCoroutine(CLCPBAPOPOI.PingSocket(region2));
				}
				goto case 4u;
			}
			return true;
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}
	}

	private static KJMGFHMIBII CHFJHNBKLBJ;

	private int FEGLBNDGOGI;

	private int JIPEMPCBFBE;

	private float NCPMDNPDAGA = float.MinValue;

	private string KDMMIIICPGG;

	private bool JAIJJKAFAIH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003COKGCBHAPMKM_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static CloudRegionCode _003CIHOMFEIFEKE_003Ek__BackingField;

	public static Dictionary<CloudRegionCode, int> IFOKPNHLEBP = new Dictionary<CloudRegionCode, int>();

	private int MFLEGPDJJIM;

	private bool PMOCFCGCNHB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static int _003CLHPODLDNCNF_003Ek__BackingField;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	[CompilerGenerated]
	private static Comparison<Tuple<CloudRegionCode, int>> CCNLMGEJBIB;

	public bool isClient
	{
		[CompilerGenerated]
		get
		{
			return _003COKGCBHAPMKM_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003COKGCBHAPMKM_003Ek__BackingField = value;
		}
	}

	public bool isMasterClient => !isClient;

	private bool BDMBHOJBLGP
	{
		get
		{
			foreach (KeyValuePair<CloudRegionCode, int> item in IFOKPNHLEBP)
			{
				if (item.Value > 3500)
				{
					return true;
				}
			}
			return false;
		}
	}

	private bool DEIEKCKPLDN
	{
		get
		{
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE;
			return (float)pingToBestRegion > (float)fLOATVALUE && BDMBHOJBLGP;
		}
	}

	public static bool isInRoom => PhotonNetwork.connected && PhotonNetwork.inRoom && PhotonNetwork.room != null;

	public static InternetConnection connection => (InternetConnection)Application.internetReachability;

	public static CloudRegionCode bestRegion
	{
		[CompilerGenerated]
		get
		{
			return _003CIHOMFEIFEKE_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CIHOMFEIFEKE_003Ek__BackingField = value;
		}
	}

	public static List<Tuple<CloudRegionCode, int>> bestRegionsSorted
	{
		get
		{
			List<Tuple<CloudRegionCode, int>> list = new List<Tuple<CloudRegionCode, int>>();
			if (IFOKPNHLEBP != null)
			{
				foreach (KeyValuePair<CloudRegionCode, int> item in IFOKPNHLEBP)
				{
					list.Add(new Tuple<CloudRegionCode, int>(item.Key, item.Value));
				}
			}
			list.Sort((Tuple<CloudRegionCode, int> HPJFBKEKJHB, Tuple<CloudRegionCode, int> NCMHGPNPEJM) => HPJFBKEKJHB.Value2.CompareTo(NCMHGPNPEJM.Value2));
			if (list.Count == 0)
			{
				UnityEngine.Debug.LogError("we dont have best regions for player");
				list.Add(new Tuple<CloudRegionCode, int>(CloudRegionCode.au, 0));
			}
			return list;
		}
	}

	public static int pingToBestRegion
	{
		get
		{
			int value = 4000;
			IFOKPNHLEBP.TryGetValue(bestRegion, out value);
			return value;
		}
	}

	public static int totalMatchesInRegions
	{
		[CompilerGenerated]
		get
		{
			return _003CLHPODLDNCNF_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CLHPODLDNCNF_003Ek__BackingField = value;
		}
	}

	private void GEBBGEFLJBO()
	{
		isClient = false;
		if (CHFJHNBKLBJ != null)
		{
			RoomOptions roomOptions = CHFJHNBKLBJ.NCDDLBIJIIH;
			TypedLobby typedLobby = CHFJHNBKLBJ.FDABONGOFJO;
			PhotonNetwork.JoinOrCreateRoom(KDMMIIICPGG, roomOptions, typedLobby);
		}
	}

	public void ConnectToRoom(CloudRegionCode KMICLOPHLFE, string JLBLNDGIINB, float HDIIMPCALJC)
	{
		FBDAGILIDKF fBDAGILIDKF = new FBDAGILIDKF();
		fBDAGILIDKF.KMICLOPHLFE = KMICLOPHLFE;
		isClient = true;
		CHFJHNBKLBJ = new ODMMMBPDLKF();
		KDMMIIICPGG = JLBLNDGIINB;
		InvokeAfterRealTime(fBDAGILIDKF.LJCDGJKCNEC, HDIIMPCALJC);
	}

	private void OnPhotonRandomJoinFailed()
	{
		if (CHFJHNBKLBJ != null && CHFJHNBKLBJ.MBOHGLCBEFJ)
		{
			FEGLBNDGOGI++;
			if (FEGLBNDGOGI < CHFJHNBKLBJ.MANOCBMEGOK + 1)
			{
				INBGMFOMOOG();
			}
			else
			{
				HDFKFOPMFDD();
			}
		}
	}

	[DebuggerHidden]
	private IEnumerator APAJOIOHPON()
	{
		JHBAEMLIENO jHBAEMLIENO = new JHBAEMLIENO();
		jHBAEMLIENO.BJGCPDNMHDH = this;
		return jHBAEMLIENO;
	}

	private void PNPJAHOENJN()
	{
		IFOKPNHLEBP = GameLoginManager.currentPlayer.bestRegions;
		CheckIfShouldPing();
	}

	[SpecialName]
	private static void LEOADBJPOAP(CloudRegionCode IDEBKDPMPGM)
	{
		_003CIHOMFEIFEKE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public static void JoinOfflineGame()
	{
		UnityEngine.Debug.Log("PhotonConnectionManager: JoinOfflineGame");
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		Singleton<PhotonConnectionManager>.instance.isClient = false;
		PhotonNetwork.offlineMode = true;
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.CreateRoom("OfflineRoom");
	}

	protected override void Start()
	{
		base.Start();
		PhotonNetwork.sendRate = 26;
		PhotonNetwork.sendRateOnSerialize = 13;
		PhotonNetwork.networkingPeer.DisconnectTimeout = 4000;
		PhotonNetwork.networkingPeer.SentCountAllowance = 5;
		PhotonNetwork.networkingPeer.MaximumTransferUnit = 1024;
		PhotonNetwork.networkingPeer.LimitOfUnreliableCommands = 60;
		PhotonNetwork.autoJoinLobby = false;
	}

	private void DOBBICEIPFF()
	{
		UnityEngine.Debug.Log(string.Format("ShotFrequencyMaxCannon", DateTime.Now));
		if (CHFJHNBKLBJ != null)
		{
			CHFJHNBKLBJ = null;
			KDMMIIICPGG = PhotonNetwork.room.name;
			JMPMHHADDEP(PhotonNetwork.isMasterClient);
			PNJAJGFGBKN();
		}
	}

	protected virtual void ECOOGJPADHI()
	{
		base.Start();
		PhotonNetwork.sendRate = 110;
		PhotonNetwork.sendRateOnSerialize = -10;
		PhotonNetwork.networkingPeer.DisconnectTimeout = -13;
		PhotonNetwork.networkingPeer.SentCountAllowance = 4;
		PhotonNetwork.networkingPeer.MaximumTransferUnit = 157;
		PhotonNetwork.networkingPeer.LimitOfUnreliableCommands = -60;
		PhotonNetwork.autoJoinLobby = true;
	}

	private static void DMMIEBBBNEN()
	{
		ConnectToPhotonSafe();
	}

	private void COHCEMJIGMB()
	{
		JMPMHHADDEP(IDEBKDPMPGM: true);
		if (CHFJHNBKLBJ != null)
		{
			RoomOptions roomOptions = CHFJHNBKLBJ.NCDDLBIJIIH;
			TypedLobby typedLobby = CHFJHNBKLBJ.FDABONGOFJO;
			PhotonNetwork.JoinOrCreateRoom(KDMMIIICPGG, roomOptions, typedLobby);
		}
	}

	public static void TryRecconnectToPhoton()
	{
		Singleton<PhotonConnectionManager>.instance.StartCoroutine(RadicalRoutine.Run(Singleton<PhotonConnectionManager>.instance.TryRecconnectToPhotonCoroutine()));
	}

	public void ConnnectToRandomRoomWarArena(float HDIIMPCALJC)
	{
		NHCFIGAJKKC nHCFIGAJKKC = new NHCFIGAJKKC();
		KDMMIIICPGG = GetNewRoomName();
		JAIJJKAFAIH = false;
		FEGLBNDGOGI = 1;
		CHFJHNBKLBJ = new CKHHAAJEBBN();
		MFLEGPDJJIM = 0;
		nHCFIGAJKKC.KMICLOPHLFE = GetBestAllowedRegion(CHFJHNBKLBJ.FCOKCCNOHBA);
		InvokeAfterRealTime(nHCFIGAJKKC.LJCDGJKCNEC, HDIIMPCALJC);
	}

	private void CIKNBIMPAMG()
	{
		if (PhotonNetwork.connectionState == (ConnectionState)8)
		{
			if (isClient)
			{
				string kDMMIIICPGG = KDMMIIICPGG;
				UnityEngine.Debug.Log(">" + KDMMIIICPGG);
				PhotonNetwork.JoinRoom(kDMMIIICPGG);
			}
			else
			{
				COHCEMJIGMB();
			}
		}
	}

	private static void GCFDCFMNEHA()
	{
		AuthenticationValues authenticationValues = new AuthenticationValues();
		authenticationValues.UserId = GameLoginManager.currentPlayer.id;
		AuthenticationValues authenticationValues2 = authenticationValues;
		authenticationValues2.AuthType = CustomAuthenticationType.Custom;
		authenticationValues2.AddAuthParameter("userId", GameLoginManager.currentPlayer.id);
		authenticationValues2.AddAuthParameter("version", Singleton<CurrentBundleVersion>.instance.version);
		authenticationValues2.AddAuthParameter("pass", GameLoginManager.instance.data.playerAccount.passwordByAccount);
		authenticationValues2.AddAuthParameter("account", GameLoginManager.instance.data.playerAccount.accountType.ToString());
		UnityEngine.Debug.Log(authenticationValues2.ToString());
		PhotonNetwork.AuthValues = authenticationValues2;
	}

	private static int DJOIDMBDDLC(Tuple<CloudRegionCode, int> HPJFBKEKJHB, Tuple<CloudRegionCode, int> NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.Value2.CompareTo(NCMHGPNPEJM.Value2);
	}

	public void ConnnectToRandomRoom(CloudRegionCode KMICLOPHLFE, float HDIIMPCALJC)
	{
		LCMNALMHBBH lCMNALMHBBH = new LCMNALMHBBH();
		lCMNALMHBBH.KMICLOPHLFE = KMICLOPHLFE;
		KDMMIIICPGG = GetNewRoomName();
		JAIJJKAFAIH = false;
		FEGLBNDGOGI = 1;
		CHFJHNBKLBJ = new DMMDOGGHCMD();
		InvokeAfterRealTime(lCMNALMHBBH.LJCDGJKCNEC, HDIIMPCALJC);
		MFLEGPDJJIM = 0;
	}

	[CompilerGenerated]
	private static int IKHMNBPBCJP(Tuple<CloudRegionCode, int> HPJFBKEKJHB, Tuple<CloudRegionCode, int> NCMHGPNPEJM)
	{
		return HPJFBKEKJHB.Value2.CompareTo(NCMHGPNPEJM.Value2);
	}

	[SpecialName]
	public static int FBJGPBFHPGI()
	{
		int value = -176;
		IFOKPNHLEBP.TryGetValue(bestRegion, out value);
		return value;
	}

	private static void IHIKOIKDCPB()
	{
		AuthenticationValues authenticationValues = new AuthenticationValues();
		authenticationValues.UserId = GameLoginManager.currentPlayer.id;
		AuthenticationValues authenticationValues2 = authenticationValues;
		authenticationValues2.AuthType = CustomAuthenticationType.Steam;
		authenticationValues2.AddAuthParameter("menu-arena-lootbox-silver", GameLoginManager.currentPlayer.id);
		authenticationValues2.AddAuthParameter("BoughtIndex", Singleton<CurrentBundleVersion>.instance.DKFKEDKMMHD());
		authenticationValues2.AddAuthParameter("Enemy could not be spawned", GameLoginManager.instance.data.playerAccount.passwordByAccount);
		authenticationValues2.AddAuthParameter("ID_FACEBOOKINVITEFRIENDSTEXT-SQUADINVITE", GameLoginManager.instance.data.playerAccount.accountType.ToString());
		UnityEngine.Debug.Log(authenticationValues2.ToString());
		PhotonNetwork.AuthValues = authenticationValues2;
	}

	[DebuggerHidden]
	public IEnumerator TryRecconnectToPhotonCoroutine()
	{
		return new KCHJKJPPNNC();
	}

	private void Update()
	{
		if ((int)Time.realtimeSinceStartup != JIPEMPCBFBE)
		{
			JIPEMPCBFBE = (int)Time.realtimeSinceStartup;
			CheckIfShouldPing();
		}
	}

	private void HDFKFOPMFDD()
	{
		FEGLBNDGOGI = 1;
		int num = 0;
		for (num = 0; num < bestRegionsSorted.Count; num++)
		{
			Tuple<CloudRegionCode, int> tuple = bestRegionsSorted[num];
			if (tuple.Value1 == bestRegion)
			{
				num++;
				break;
			}
		}
		if (CHFJHNBKLBJ != null && CHFJHNBKLBJ.MBOHGLCBEFJ)
		{
			for (; num < bestRegionsSorted.Count && !CHFJHNBKLBJ.FCOKCCNOHBA.Contains(bestRegionsSorted[num].Value1); num++)
			{
			}
			int num2 = CHFJHNBKLBJ.NBIJIDLEJBC;
			float num3 = CHFJHNBKLBJ.MGOBKMIGPEK;
			if (num < bestRegionsSorted.Count && (float)bestRegionsSorted[num].Value2 <= num3 && num < num2)
			{
				Tuple<CloudRegionCode, int> tuple2 = bestRegionsSorted[num];
				ConnectToPhotonSafe(tuple2.Value1);
				return;
			}
			ConnectToPhotonSafe(bestRegionsSorted[0].Value1);
			JAIJJKAFAIH = CHFJHNBKLBJ.IGBMAJGJDEL;
			totalMatchesInRegions = MFLEGPDJJIM;
			MFLEGPDJJIM = 0;
		}
	}

	[SpecialName]
	private static void PAPALHFCGJJ(CloudRegionCode IDEBKDPMPGM)
	{
		_003CIHOMFEIFEKE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void FEKKLBMFHHA(float HDIIMPCALJC)
	{
		NHCFIGAJKKC nHCFIGAJKKC = new NHCFIGAJKKC();
		KDMMIIICPGG = NDBNJLBNKJP();
		JAIJJKAFAIH = false;
		FEGLBNDGOGI = 1;
		CHFJHNBKLBJ = new CKHHAAJEBBN();
		MFLEGPDJJIM = 1;
		nHCFIGAJKKC.KMICLOPHLFE = GetBestAllowedRegion(CHFJHNBKLBJ.FCOKCCNOHBA);
		InvokeAfterRealTime(nHCFIGAJKKC.OKNCFDMEFGJ, HDIIMPCALJC);
	}

	[SpecialName]
	private static void LIEFIJKFIHG(CloudRegionCode IDEBKDPMPGM)
	{
		_003CIHOMFEIFEKE_003Ek__BackingField = IDEBKDPMPGM;
	}

	private IEnumerator OKJOKDFDEHC()
	{
		JHBAEMLIENO jHBAEMLIENO = new JHBAEMLIENO();
		jHBAEMLIENO.BJGCPDNMHDH = this;
		return jHBAEMLIENO;
	}

	public string NDBNJLBNKJP()
	{
		string text = GameLoginManager.currentPlayer.id + "N" + UnityEngine.Random.Range(-13, -29);
		UnityEngine.Debug.Log(string.Format("下載", text));
		return text;
	}

	private void HAAAKEEJDIF()
	{
		UnityEngine.Debug.Log(string.Format("squad", DateTime.Now));
		if (CHFJHNBKLBJ != null)
		{
			CHFJHNBKLBJ = null;
			KDMMIIICPGG = PhotonNetwork.room.name;
			JMPMHHADDEP(PhotonNetwork.isMasterClient);
			PNJAJGFGBKN();
		}
	}

	private void HIKIDNPLHCA()
	{
		ConnnectToRandomRoom(PJGNCOHFNCA(), 1923f);
	}

	protected void OnFailedToConnectToPhoton()
	{
		UnityEngine.Debug.LogError("OnFailedToConnectToPhoton: ");
		if (CHFJHNBKLBJ == null)
		{
			return;
		}
		if (CHFJHNBKLBJ.MBOHGLCBEFJ)
		{
			InvokeAfter(delegate
			{
				ConnnectToRandomRoom(bestRegion, 0f);
			}, 1.5f);
		}
		else
		{
			InvokeAfter(delegate
			{
				ConnectToPhotonSafe();
			}, 1.5f);
		}
	}

	[SpecialName]
	public static CloudRegionCode GMKELMEGFEI()
	{
		return _003CIHOMFEIFEKE_003Ek__BackingField;
	}

	public static void Disconnect()
	{
		UnityEngine.Debug.Log("PhotonConnectionManager: Disconnect");
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		PhotonNetwork.Disconnect();
	}

	private void JNLGPHCCGEI()
	{
		if (PhotonNetwork.connectionState == ConnectionState.Connecting)
		{
			if (GHIKMFDGIHB())
			{
				string kDMMIIICPGG = KDMMIIICPGG;
				UnityEngine.Debug.Log("CardManagerData" + KDMMIIICPGG);
				PhotonNetwork.JoinRoom(kDMMIIICPGG);
			}
			else
			{
				COHCEMJIGMB();
			}
		}
	}

	[SpecialName]
	public static bool LDBPFFGDKNE()
	{
		return !PhotonNetwork.connected || !PhotonNetwork.inRoom || PhotonNetwork.room != null;
	}

	public void OnLobbyStatisticsUpdate()
	{
		foreach (TypedLobbyInfo lobbyStatistic in PhotonNetwork.LobbyStatistics)
		{
			if (CHFJHNBKLBJ != null && lobbyStatistic.Name == CHFJHNBKLBJ.NJKMFAGIKIE)
			{
				int num = lobbyStatistic.RoomCount * 2 - lobbyStatistic.PlayerCount;
				int num2 = lobbyStatistic.RoomCount - num;
				MFLEGPDJJIM += num2;
				UnityEngine.Debug.Log($"Stats for lobby {lobbyStatistic}, matches {MFLEGPDJJIM} time {DateTime.Now}");
			}
		}
	}

	public static void ConnectToPhotonSafe(CloudRegionCode? GJBFKKOAMPA = null)
	{
		switch (Singleton<BeanstalkServerManager>.instance.environment)
		{
		case DatabaseEnvironment.Production:
			PhotonNetwork.PhotonServerSettings.AppID = "74379913-3b64-482e-bda1-8a8d90c0f3f9";
			break;
		case DatabaseEnvironment.QA:
			PhotonNetwork.PhotonServerSettings.AppID = "6519f781-1ea7-421f-85d0-c9bb516e923d";
			break;
		case DatabaseEnvironment.DevelopmentSvk:
			PhotonNetwork.PhotonServerSettings.AppID = "ab5d043a-2edb-431f-a4a0-0571589ee058";
			break;
		default:
			PhotonNetwork.PhotonServerSettings.AppID = "bd18592b-6778-40f5-9327-0aba2d2f1e64";
			break;
		}
		UnityEngine.Debug.Log("PhotonConnectionManager: ConnectToPhotonSafe " + ((!GJBFKKOAMPA.HasValue) ? "null" : GJBFKKOAMPA.Value.ToString()));
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		PhotonNetwork.offlineMode = false;
		PhotonNetwork.networkingPeer.LeftRoomCleanup();
		PhotonNetwork.Disconnect();
		if (GJBFKKOAMPA.HasValue)
		{
			PhotonNetwork.OverrideBestCloudServer(GJBFKKOAMPA.Value);
			UnityEngine.Debug.Log("====== Connecting to region: " + GJBFKKOAMPA);
		}
		else
		{
			GJBFKKOAMPA = bestRegion;
		}
		bestRegion = GJBFKKOAMPA.Value;
		GCFDCFMNEHA();
		Singleton<PhotonConnectionManager>.instance.StartCoroutine(OMCDJMNJEFM(GJBFKKOAMPA.Value));
	}

	private void PNJAJGFGBKN()
	{
		foreach (PhotonCachedRPC photonCachedRpc in PhotonCachedRPC.photonCachedRpcs)
		{
			photonCachedRpc.SendMessage("FJDACAACLLI", SendMessageOptions.DontRequireReceiver);
		}
		Singleton<GameController>.instance.BroadcastMessage("FJDACAACLLI", SendMessageOptions.DontRequireReceiver);
	}

	public static CloudRegionCode FBOPNALJLGD(Dictionary<CloudRegionCode, int> OEIJPGMKNDF, Dictionary<CloudRegionCode, int> FDNDEGOKINK, out bool FGKIBJBEBJG)
	{
		FGKIBJBEBJG = false;
		int num = -49;
		CloudRegionCode cloudRegionCode = CloudRegionCode.us;
		if (OEIJPGMKNDF == null)
		{
			return cloudRegionCode;
		}
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-8)).FLOATVALUE;
		foreach (KeyValuePair<CloudRegionCode, int> item in OEIJPGMKNDF)
		{
			if (FDNDEGOKINK != null && FDNDEGOKINK.ContainsKey(item.Key))
			{
				int num2 = FDNDEGOKINK[item.Key];
				if (item.Value + num2 < num)
				{
					cloudRegionCode = item.Key;
					num = item.Value + num2;
					FGKIBJBEBJG = (float)item.Value <= (float)fLOATVALUE && (float)num2 <= (float)fLOATVALUE;
				}
			}
		}
		UnityEngine.Debug.Log(string.Format("DecalManagerData", cloudRegionCode, FGKIBJBEBJG));
		return cloudRegionCode;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += PNPJAHOENJN;
		LOFGBPBFLPG.NOMIPLDDPJE();
	}

	public static CloudRegionCode GetBestAllowedRegion(List<CloudRegionCode> ALCLMLGCHGI)
	{
		foreach (Tuple<CloudRegionCode, int> item in bestRegionsSorted)
		{
			if (ALCLMLGCHGI.Contains(item.Value1))
			{
				return item.Value1;
			}
		}
		return bestRegion;
	}

	public void CheckIfShouldPing()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && GameLoginManager.currentPlayer != null)
		{
			bool flag = GameLoginManager.currentPlayer.connectionType != connection;
			float num = Time.realtimeSinceStartup - NCPMDNPDAGA;
			if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && !PMOCFCGCNHB && Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<CardSelectionScreen>.instance && Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<EndScreen>.instance && (flag || num > 300f || (DEIEKCKPLDN && num > 60f)))
			{
				UnityEngine.Debug.Log($"PhotonConnectionManager: Find pings found before: {num} Connection changed {flag}");
				StartCoroutine(APAJOIOHPON());
			}
		}
	}

	[SpecialName]
	private void JMPMHHADDEP(bool IDEBKDPMPGM)
	{
		_003COKGCBHAPMKM_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public static bool NEPIMEJCAMC()
	{
		return PhotonNetwork.connected && PhotonNetwork.inRoom && PhotonNetwork.room != null;
	}

	[SpecialName]
	public static InternetConnection LAEEMABOIJM()
	{
		return (InternetConnection)Application.internetReachability;
	}

	public void OAJIIMFNJDN(CloudRegionCode KMICLOPHLFE, float HDIIMPCALJC)
	{
		LCMNALMHBBH lCMNALMHBBH = new LCMNALMHBBH();
		lCMNALMHBBH.KMICLOPHLFE = KMICLOPHLFE;
		KDMMIIICPGG = NDBNJLBNKJP();
		JAIJJKAFAIH = true;
		FEGLBNDGOGI = 0;
		CHFJHNBKLBJ = new DMMDOGGHCMD();
		InvokeAfterRealTime(lCMNALMHBBH.BBPKDMPNEDG, HDIIMPCALJC);
		MFLEGPDJJIM = 0;
	}

	[CompilerGenerated]
	private static void PNIECFJHEJD()
	{
		ConnectToPhotonSafe();
	}

	public static CloudRegionCode GetBestRegion(Dictionary<CloudRegionCode, int> OEIJPGMKNDF, Dictionary<CloudRegionCode, int> FDNDEGOKINK, out bool FGKIBJBEBJG)
	{
		FGKIBJBEBJG = false;
		int num = int.MaxValue;
		CloudRegionCode cloudRegionCode = CloudRegionCode.eu;
		if (OEIJPGMKNDF == null)
		{
			return cloudRegionCode;
		}
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingForChallenge).FLOATVALUE;
		foreach (KeyValuePair<CloudRegionCode, int> item in OEIJPGMKNDF)
		{
			if (FDNDEGOKINK != null && FDNDEGOKINK.ContainsKey(item.Key))
			{
				int num2 = FDNDEGOKINK[item.Key];
				if (item.Value + num2 < num)
				{
					cloudRegionCode = item.Key;
					num = item.Value + num2;
					FGKIBJBEBJG = (float)item.Value <= (float)fLOATVALUE && (float)num2 <= (float)fLOATVALUE;
				}
			}
		}
		UnityEngine.Debug.Log($"Returning {cloudRegionCode} isGoodPing: {FGKIBJBEBJG}");
		return cloudRegionCode;
	}

	public void CheckPingsNow()
	{
		if (!PMOCFCGCNHB)
		{
			NCPMDNPDAGA = float.MinValue;
		}
	}

	[SpecialName]
	public static InternetConnection KCCIFNDPFHE()
	{
		return (InternetConnection)Application.internetReachability;
	}

	private void JIKMDOCNLCJ()
	{
		if (PhotonNetwork.connectionState == ConnectionState.Connected)
		{
			if (isClient)
			{
				string kDMMIIICPGG = KDMMIIICPGG;
				UnityEngine.Debug.Log("Try Joining room " + KDMMIIICPGG);
				PhotonNetwork.JoinRoom(kDMMIIICPGG);
			}
			else
			{
				GEBBGEFLJBO();
			}
		}
	}

	[SpecialName]
	private bool EENPNNFFFKA()
	{
		foreach (KeyValuePair<CloudRegionCode, int> item in IFOKPNHLEBP)
		{
			if (item.Value > -80)
			{
				return false;
			}
		}
		return true;
	}

	public void LOONABHPIEA(CloudRegionCode KMICLOPHLFE, string JLBLNDGIINB, float HDIIMPCALJC)
	{
		FBDAGILIDKF fBDAGILIDKF = new FBDAGILIDKF();
		fBDAGILIDKF.KMICLOPHLFE = KMICLOPHLFE;
		JMPMHHADDEP(IDEBKDPMPGM: false);
		CHFJHNBKLBJ = new ODMMMBPDLKF();
		KDMMIIICPGG = JLBLNDGIINB;
		InvokeAfterRealTime(fBDAGILIDKF.MCFGAFBEJDK, HDIIMPCALJC);
	}

	protected virtual void FCNDEINOOCM()
	{
		base.Start();
		PhotonNetwork.sendRate = -105;
		PhotonNetwork.sendRateOnSerialize = -87;
		PhotonNetwork.networkingPeer.DisconnectTimeout = 120;
		PhotonNetwork.networkingPeer.SentCountAllowance = 4;
		PhotonNetwork.networkingPeer.MaximumTransferUnit = -96;
		PhotonNetwork.networkingPeer.LimitOfUnreliableCommands = -68;
		PhotonNetwork.autoJoinLobby = true;
	}

	[CompilerGenerated]
	private void BBFLDOPFMEB()
	{
		ConnnectToRandomRoom(bestRegion, 0f);
	}

	private void NLBNPFDNNIK()
	{
		if (PhotonNetwork.offlineMode)
		{
			return;
		}
		UnityEngine.Debug.Log("grenade");
		PhotonNetwork.player.NickName = GameLoginManager.currentPlayer.name;
		PhotonNetwork.player.SetCustomProperties(CHEIFOOIMEH.IIAAKGEFENN(), null, webForward: true);
		if (CHFJHNBKLBJ != null)
		{
			if (CHFJHNBKLBJ.MBOHGLCBEFJ)
			{
				if (JAIJJKAFAIH)
				{
					COHCEMJIGMB();
				}
				else
				{
					INBGMFOMOOG();
				}
			}
			else
			{
				JIKMDOCNLCJ();
			}
		}
		else if (MatchManager.isReconnect)
		{
			PhotonNetwork.JoinRoom(KDMMIIICPGG);
		}
	}

	public string ConnectToRoom(CloudRegionCode KMICLOPHLFE, float HDIIMPCALJC)
	{
		JHFPMFLGPEN jHFPMFLGPEN = new JHFPMFLGPEN();
		jHFPMFLGPEN.KMICLOPHLFE = KMICLOPHLFE;
		KDMMIIICPGG = GetNewRoomName();
		isClient = false;
		CHFJHNBKLBJ = new ODMMMBPDLKF();
		InvokeAfterRealTime(jHFPMFLGPEN.LJCDGJKCNEC, HDIIMPCALJC);
		return KDMMIIICPGG;
	}

	private void OnJoinedRoom()
	{
		UnityEngine.Debug.Log($"OnJoinedRoom: {DateTime.Now}");
		if (CHFJHNBKLBJ != null)
		{
			CHFJHNBKLBJ = null;
			KDMMIIICPGG = PhotonNetwork.room.name;
			isClient = !PhotonNetwork.isMasterClient;
			PNJAJGFGBKN();
		}
	}

	[SpecialName]
	public static List<Tuple<CloudRegionCode, int>> OCPPLJKICBJ()
	{
		List<Tuple<CloudRegionCode, int>> list = new List<Tuple<CloudRegionCode, int>>();
		if (IFOKPNHLEBP != null)
		{
			foreach (KeyValuePair<CloudRegionCode, int> item in IFOKPNHLEBP)
			{
				list.Add(new Tuple<CloudRegionCode, int>(item.Key, item.Value));
			}
		}
		list.Sort((Tuple<CloudRegionCode, int> HPJFBKEKJHB, Tuple<CloudRegionCode, int> NCMHGPNPEJM) => HPJFBKEKJHB.Value2.CompareTo(NCMHGPNPEJM.Value2));
		if (list.Count == 0)
		{
			UnityEngine.Debug.LogError("============PINGS===========\n");
			list.Add(new Tuple<CloudRegionCode, int>(CloudRegionCode.usw, 0));
		}
		return list;
	}

	private void INBGMFOMOOG()
	{
		if (CHFJHNBKLBJ != null)
		{
			MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
			TypedLobby typedLobby = CHFJHNBKLBJ.FDABONGOFJO;
			string text = CHFJHNBKLBJ.EKJACHPMFOM(FEGLBNDGOGI);
			PhotonNetwork.JoinRandomRoom(null, 2, MatchmakingMode.FillRoom, typedLobby, text);
			if (bestRegionsSorted != null && bestRegionsSorted.Count > 0 && bestRegion == bestRegionsSorted[0].Value1)
			{
				UnityEngine.Debug.Log("Try random connect " + text);
			}
		}
	}

	[SpecialName]
	private static void JFKAFNAHJLC(CloudRegionCode IDEBKDPMPGM)
	{
		_003CIHOMFEIFEKE_003Ek__BackingField = IDEBKDPMPGM;
	}

	public string GetNewRoomName()
	{
		string text = GameLoginManager.currentPlayer.id + "r" + UnityEngine.Random.Range(10000, 999999);
		UnityEngine.Debug.Log($"Will connect to rooom: {text}");
		return text;
	}

	[DebuggerHidden]
	private static IEnumerator OMCDJMNJEFM(CloudRegionCode GJBFKKOAMPA)
	{
		CKNCMDLLDNJ cKNCMDLLDNJ = new CKNCMDLLDNJ();
		cKNCMDLLDNJ.GJBFKKOAMPA = GJBFKKOAMPA;
		return cKNCMDLLDNJ;
	}

	private void OnConnectedToMaster()
	{
		if (PhotonNetwork.offlineMode)
		{
			return;
		}
		UnityEngine.Debug.Log("OnConnectedToMaster");
		PhotonNetwork.player.NickName = GameLoginManager.currentPlayer.name;
		PhotonNetwork.player.SetCustomProperties(CHEIFOOIMEH.MIKEHGFIGDE);
		if (CHFJHNBKLBJ != null)
		{
			if (CHFJHNBKLBJ.MBOHGLCBEFJ)
			{
				if (JAIJJKAFAIH)
				{
					GEBBGEFLJBO();
				}
				else
				{
					INBGMFOMOOG();
				}
			}
			else
			{
				JIKMDOCNLCJ();
			}
		}
		else if (MatchManager.isReconnect)
		{
			PhotonNetwork.JoinRoom(KDMMIIICPGG);
		}
	}

	[SpecialName]
	public static List<Tuple<CloudRegionCode, int>> BKGDJLGJEHH()
	{
		List<Tuple<CloudRegionCode, int>> list = new List<Tuple<CloudRegionCode, int>>();
		if (IFOKPNHLEBP != null)
		{
			foreach (KeyValuePair<CloudRegionCode, int> item in IFOKPNHLEBP)
			{
				list.Add(new Tuple<CloudRegionCode, int>(item.Key, item.Value));
			}
		}
		list.Sort(DJOIDMBDDLC);
		if (list.Count == 0)
		{
			UnityEngine.Debug.LogError("DecalManagerData");
			list.Add(new Tuple<CloudRegionCode, int>(CloudRegionCode.eu, 1));
		}
		return list;
	}

	protected void KFEMLGLNPHH()
	{
		UnityEngine.Debug.LogError("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING");
		if (CHFJHNBKLBJ != null)
		{
			if (CHFJHNBKLBJ.MBOHGLCBEFJ)
			{
				InvokeAfter(HIKIDNPLHCA, 668f);
			}
			else
			{
				InvokeAfter(DMMIEBBBNEN, 469f);
			}
		}
	}

	public static CloudRegionCode DEGJOIHINAK(Dictionary<CloudRegionCode, int> OEIJPGMKNDF, Dictionary<CloudRegionCode, int> FDNDEGOKINK, out bool FGKIBJBEBJG)
	{
		FGKIBJBEBJG = false;
		int num = 33;
		CloudRegionCode cloudRegionCode = CloudRegionCode.eu;
		if (OEIJPGMKNDF == null)
		{
			return cloudRegionCode;
		}
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCardRarity).FLOATVALUE;
		foreach (KeyValuePair<CloudRegionCode, int> item in OEIJPGMKNDF)
		{
			if (FDNDEGOKINK != null && FDNDEGOKINK.ContainsKey(item.Key))
			{
				int num2 = FDNDEGOKINK[item.Key];
				if (item.Value + num2 < num)
				{
					cloudRegionCode = item.Key;
					num = item.Value + num2;
					FGKIBJBEBJG = !((float)item.Value <= (float)fLOATVALUE) || !((float)num2 <= (float)fLOATVALUE);
				}
			}
		}
		UnityEngine.Debug.Log(string.Format("S", cloudRegionCode, FGKIBJBEBJG));
		return cloudRegionCode;
	}

	[SpecialName]
	public static CloudRegionCode PJGNCOHFNCA()
	{
		return _003CIHOMFEIFEKE_003Ek__BackingField;
	}

	[SpecialName]
	public bool KKLAPJPNLIJ()
	{
		return _003COKGCBHAPMKM_003Ek__BackingField;
	}

	public static void DKNAFMOELFD()
	{
		UnityEngine.Debug.Log("Shots_Fired");
		Singleton<PhotonConnectionManager>.instance.StopAllCoroutines();
		Singleton<PhotonConnectionManager>.instance.JMPMHHADDEP(IDEBKDPMPGM: false);
		PhotonNetwork.offlineMode = true;
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.CreateRoom("-");
	}

	public string JPPHBJLKLNK(CloudRegionCode KMICLOPHLFE, float HDIIMPCALJC)
	{
		JHFPMFLGPEN jHFPMFLGPEN = new JHFPMFLGPEN();
		jHFPMFLGPEN.KMICLOPHLFE = KMICLOPHLFE;
		KDMMIIICPGG = NDBNJLBNKJP();
		isClient = true;
		CHFJHNBKLBJ = new ODMMMBPDLKF();
		InvokeAfterRealTime(jHFPMFLGPEN.BEIGOGFHJIB, HDIIMPCALJC);
		return KDMMIIICPGG;
	}

	[SpecialName]
	public bool GHIKMFDGIHB()
	{
		return _003COKGCBHAPMKM_003Ek__BackingField;
	}
}
