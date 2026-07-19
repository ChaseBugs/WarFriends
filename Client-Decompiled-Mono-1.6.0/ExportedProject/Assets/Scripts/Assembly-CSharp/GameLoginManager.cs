using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class GameLoginManager : InGameSerializedObjectGeneric<GameLoginManager.LoginData>
{
	public class LoginData
	{
		public Dictionary<DatabaseEnvironment, EnvironmentData> mLoginData;

		private EnvironmentData currentEnvironment
		{
			get
			{
				if (mLoginData == null)
				{
					mLoginData = new Dictionary<DatabaseEnvironment, EnvironmentData>();
				}
				if (!mLoginData.ContainsKey(DJOJPKGADMP.AAMEOPMABGB))
				{
					mLoginData[DJOJPKGADMP.AAMEOPMABGB] = new EnvironmentData();
				}
				return mLoginData[DJOJPKGADMP.AAMEOPMABGB];
			}
		}

		[JsonIgnore]
		public DatabasePlayer currentPlayer
		{
			get
			{
				return currentEnvironment.currentPlayer;
			}
			set
			{
				currentEnvironment.currentPlayer = value;
			}
		}

		[JsonIgnore]
		public bool isDeviceRegistered
		{
			get
			{
				return currentEnvironment.isDeviceRegistered;
			}
			set
			{
				currentEnvironment.isDeviceRegistered = value;
			}
		}

		[JsonIgnore]
		public PlayerAccount playerAccount
		{
			get
			{
				return currentEnvironment.playerAccount;
			}
			set
			{
				currentEnvironment.playerAccount = value;
			}
		}
	}

	public class EnvironmentData
	{
		public DatabasePlayer currentPlayer;

		public bool isDeviceRegistered;

		public PlayerAccount playerAccount;
	}

	public class PlayerAccount
	{
		public string id;

		public string hashKey;

		public string password;

		public string hashKeyFB;

		public string passwordFB;

		public string hashKeyGP;

		public string passwordGP;

		public string hashKeyGC;

		public string passwordGC;

		public string hashKeyGuest;

		public string passwordGuest;

		public AccountType accountType;

		public string hashKeyByAccount
		{
			get
			{
				switch (accountType)
				{
				case AccountType.Facebook:
					return hashKeyFB;
				case AccountType.GameCenter:
					return hashKeyGC;
				case AccountType.GooglePlay:
					return hashKeyGP;
				default:
					return hashKeyGuest;
				}
			}
		}

		public string passwordByAccount
		{
			get
			{
				switch (accountType)
				{
				case AccountType.Facebook:
					return passwordFB;
				case AccountType.GameCenter:
					return passwordGC;
				case AccountType.GooglePlay:
					return passwordGP;
				default:
					return passwordGuest;
				}
			}
		}

		public bool UpdateByAccount()
		{
			if (!string.IsNullOrEmpty(hashKey) && !string.IsNullOrEmpty(password))
			{
				switch (accountType)
				{
				case AccountType.Facebook:
					hashKeyFB = hashKey;
					passwordFB = password;
					break;
				case AccountType.GameCenter:
					hashKeyGC = hashKey;
					passwordGC = password;
					break;
				default:
					hashKeyGuest = hashKey;
					passwordGuest = password;
					break;
				}
				hashKey = string.Empty;
				password = string.Empty;
				return true;
			}
			return false;
		}
	}

	private sealed class BFLDHOLADMC
	{
		internal bool IBKDBHAPOGC;

		internal GameLoginManager BJGCPDNMHDH;

		internal void NNIJEDKBPGJ(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("MissionType");
				BJGCPDNMHDH.mFacebookService.NCDPFLCNFKI(IBKDBHAPOGC);
			}
		}

		internal void CFJHDIHLIML(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("userPushNotification");
				BJGCPDNMHDH.mFacebookService.GONEJFFAEAJ(IBKDBHAPOGC);
			}
		}

		internal void GMFJFMHNDMC(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("unit");
				BJGCPDNMHDH.mFacebookService.KNNNIOLHMJM(IBKDBHAPOGC);
			}
		}

		internal void PHGDBIEENCB(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("Gold");
				BJGCPDNMHDH.mFacebookService.GONEJFFAEAJ(IBKDBHAPOGC);
			}
		}

		internal void LJCDGJKCNEC(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("GameLoginManager: Logout from facebook");
				BJGCPDNMHDH.mFacebookService.IHOGKPNDCOM(IBKDBHAPOGC);
			}
		}

		internal void MFCNOIDCJME(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("\t\"FALSE\"");
				BJGCPDNMHDH.mFacebookService.NCDPFLCNFKI(IBKDBHAPOGC);
			}
		}

		internal void FIBGJHCGHJH(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("HeartDialogShown");
				BJGCPDNMHDH.mFacebookService.KNNNIOLHMJM(IBKDBHAPOGC);
			}
		}

		internal void BDCAFHOHEGM(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("ID_TUTORIAL_UPGRADEUNIT_3");
				BJGCPDNMHDH.mFacebookService.IHOGKPNDCOM(IBKDBHAPOGC);
			}
		}

		internal void MAKLHLCDIKD(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("ID_INGOLD1");
				BJGCPDNMHDH.mFacebookService.NCDPFLCNFKI(IBKDBHAPOGC);
			}
		}

		internal void AMIJFGBOCLC(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("MyRank");
				BJGCPDNMHDH.mFacebookService.IHOGKPNDCOM(IBKDBHAPOGC);
			}
		}

		internal void EMKPBGFBPFI(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("was added");
				BJGCPDNMHDH.mFacebookService.KNNNIOLHMJM(IBKDBHAPOGC);
			}
		}

		internal void HHLMDAKDHFK(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("ID_OPPONENTPAUSED");
				BJGCPDNMHDH.mFacebookService.IHOGKPNDCOM(IBKDBHAPOGC);
			}
		}

		internal void OKNCFDMEFGJ(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("123 MENU WEAPON SCREEN TUTORIAL WEAPON BUY CLICKED");
				BJGCPDNMHDH.mFacebookService.NCDPFLCNFKI(IBKDBHAPOGC);
			}
		}

		internal void NDJOJHNIBFC(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				UnityEngine.Debug.Log("ID_SILVERWARCARDS");
				BJGCPDNMHDH.mFacebookService.IJIDBPILCKF(IBKDBHAPOGC);
			}
		}
	}

	private sealed class HNIDECFHCGF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool NPCNPNMPBGC;

		internal GameLoginManager BJGCPDNMHDH;

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
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		public bool PKOMECFNPIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("Weapon cost gold, we can buy it even if player is already upgrading");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != (GameController.AEMPHGEIJNH)7)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("Started delivering weapon upgrade for {0} {1}. It will be ready in {2} seconds.");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PPHNDLFFCAG()
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
				UnityEngine.Debug.Log("ID_CONFIRM_ERROR");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.WaitingForResponse)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log(",");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		public void CNMNAHEINED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EBCEAGIOPJD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LAICPPPPIKL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("Skipping next withdraw basecause player left squad");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Playing)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("ID_FEATURE_ACCURACY-WEAPONPREFIX");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public bool KEBEGEDKIKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("PlacementMatchesRequired");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.AFDJHMHONOH() != (GameController.AEMPHGEIJNH)5)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("menu-info-close-ico");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("Selected new room MAP id is: ");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.WaitingForResponse)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("remainingTimeForNextDogtag");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("DEPOSIT WARCARDS MESSAGE!!!");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("_Color");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("ID_ACTIVATEINSTEADOF");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.WaitingForResponse)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("Got ");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KOKJMKHECGK()
		{
			throw new NotSupportedException();
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("#Notifications# Received Registration Token: ");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.AFDJHMHONOH() != (GameController.AEMPHGEIJNH)6)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("warbucks");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("#PETER# End of lootbox coroutine - no rewards for game from server!");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Playing)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("《WarFriends》需要權限存取你的媒體存儲才能下載關鍵的遊戲資料。缺少此權限，遊戲就無法運作並會關閉。請重試或退出《WarFriends》。");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public bool FOKKNCCLABE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("ID_CATEGORY_LOW_SG_SMG");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("IsPaid");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public void NCHGDJDAHGC()
		{
			throw new NotSupportedException();
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EEHBKGPLIJN()
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
				UnityEngine.Debug.Log("#AccoutCheck# start waiting to be in menu or in game");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Playing)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("#AccoutCheck# now is in menu or in game");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("Card_3_Played");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("squad");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void ADLICCCIEGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOOGINPIELE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public bool HJHJCCFGJIH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("(");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.WaitingForResponse)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("ID_FRIENDREFUSEDREMATCHCOOP");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void AMPGDAMMPFJ()
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
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PGOIHDIKFEI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		public void FAOLFOHEEGF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public HNIDECFHCGF()
		{
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void HCHFFFPDMDA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLAOFCCAAEN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IILJADPOOCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMGAHAGANGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MJKLPCMKADD()
		{
			return PHDOCKCBJOF;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("PurchaseVerification(");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.WaitingForResponse)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("game-card-ico-mineyourstep-full");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MKEJDEGFKLC()
		{
			return PHDOCKCBJOF;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log(",[keys])");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.PEGCHNGBOAM() != (GameController.AEMPHGEIJNH)6)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("GPGS: Log In");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FFNFEAHBBLJ()
		{
			return PHDOCKCBJOF;
		}

		public void NNCBKIIJPMB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool ACHIHMMCDNF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("FuseSDK: Null or empty App ID. Make sure your App ID is entered in the FuseSDK prefab");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Playing)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("0.#");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("menu-button-small");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("realShotProbability");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IDBEGKHBNBC()
		{
			return PHDOCKCBJOF;
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log(" mSpriteName:");
				goto case 1u;
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != (GameController.AEMPHGEIJNH)8)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				UnityEngine.Debug.Log("Enemy could not be spawned");
				if (NPCNPNMPBGC)
				{
					long? cachedFbId = BJGCPDNMHDH.cachedFbId;
					if (cachedFbId.HasValue)
					{
						BJGCPDNMHDH.OnFacebookUserExistDuringTutorial(BJGCPDNMHDH.cachedFbId.ToString());
					}
					else if (BJGCPDNMHDH.cachedGpgsId != null)
					{
						BJGCPDNMHDH.OnGpgsUserExistDuringTutorial(BJGCPDNMHDH.cachedGpgsId);
					}
					else
					{
						BJGCPDNMHDH.OnGamecenterUserExistDuringTutorial(BJGCPDNMHDH.cachedGcId);
					}
				}
				else
				{
					BJGCPDNMHDH.ChangeAccountDialogCallback(null, false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}
	}

	private static GameLoginManager mInstance;

	private bool startingCurrencyPreset;

	private bool needGCchange;

	private string loginAccessToken = string.Empty;

	public string playerId;

	public bool changeGCAfterTutorialInProgress;

	public bool mAcountDataDownloadingInProgress;

	private string cachedGcId;

	private string askGcId;

	private long? askFbId;

	private long? cachedFbId;

	private string askGpgsId;

	private string cachedGpgsId;

	public string facebookName;

	private KFLKGGGJHIN mFacebookService;

	private ILEOBPDCGJB mICloudService;

	public bool wasInBeginnersLeague;

	public int wasBeginnerLeagueNumber;

	public static GameLoginManager instance
	{
		get
		{
			mInstance = mInstance ?? ((GameLoginManager)UnityEngine.Object.FindObjectsOfType(typeof(GameLoginManager))[0]);
			return mInstance;
		}
	}

	public string accessToken
	{
		get
		{
			return loginAccessToken;
		}
	}

	public bool acountDataDownloadingInProgress
	{
		get
		{
			return mAcountDataDownloadingInProgress;
		}
		set
		{
			UnityEngine.Debug.Log("GameLoginManager: Setting AccountDataDownloadingProgress = " + value);
			mAcountDataDownloadingInProgress = value;
			if (mAcountDataDownloadingInProgress && Singleton<EventTrackingManager>.instance.fuseboxxService != null)
			{
				Singleton<EventTrackingManager>.instance.fuseboxxService.FBAEFALKGLN();
			}
		}
	}

	public List<KFLKGGGJHIN.EBDBJAKJNLD> facebookFriends
	{
		get
		{
			return mFacebookService.GBLOAJIGOHF;
		}
	}

	public Dictionary<long, KFLKGGGJHIN.EBDBJAKJNLD> facebookFriendsDict
	{
		get
		{
			return mFacebookService.OLNAPDJGPEE;
		}
	}

	public long facebookId
	{
		get
		{
			return (data.currentPlayer == null) ? (-1) : data.currentPlayer.facebookId;
		}
	}

	public int medals
	{
		get
		{
			return (data.currentPlayer == null) ? (-1) : data.currentPlayer.skill;
		}
	}

	public bool canSendLogs
	{
		get
		{
			return data.currentPlayer != null && data.currentPlayer.canPlayerSendLogs;
		}
	}

	public static DatabasePlayer currentPlayer
	{
		get
		{
			return instance.data.currentPlayer;
		}
	}

	public static DatabasePlayer generatedCurrentPlayer
	{
		get
		{
			DatabasePlayer databasePlayer = instance.data.currentPlayer;
			if (databasePlayer != null)
			{
				databasePlayer.armyPower = LevelManager.instance.armyPower;
				databasePlayer.playerVisuals = CamosManager.instance.data.slots;
				databasePlayer.experience = LevelManager.instance.experience;
				databasePlayer.level = LevelManager.instance.currentLevel.index;
				databasePlayer.statisticsData = StatsManager.instance.data;
				databasePlayer.status = PlayerStatus.Online;
			}
			else
			{
				UnityEngine.Debug.LogError("Brutal fatal error - no current player");
			}
			return databasePlayer;
		}
	}

	public string squadIconName
	{
		get
		{
			if (string.IsNullOrEmpty(data.currentPlayer.squadName))
			{
				return string.Empty;
			}
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(data.currentPlayer.squadName, true);
			return (aANECPGDMGM != null) ? aANECPGDMGM.DAANKCOLJGJ : string.Empty;
		}
	}

	public string squadMessage
	{
		get
		{
			if (string.IsNullOrEmpty(data.currentPlayer.squadName))
			{
				return string.Empty;
			}
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(data.currentPlayer.squadName, true);
			return (aANECPGDMGM != null) ? aANECPGDMGM.PNAKMCNGGHE : string.Empty;
		}
	}

	public bool IsLoggedToFacebook
	{
		get
		{
			return mFacebookService.MEDEIMEPMFM();
		}
	}

	public event Action DeviceRegistered;

	public event Action<string> PlayerJoinedSquad;

	public event Action PlayerLeftSquad;

	public event Action LoginDataChanged;

	public event Action PlayerLogOut;

	public event Action FriendsLoaded;

	public void OnDestroy()
	{
		mInstance = null;
	}

	internal void AddOneTimeCallbackToShowGcChangeNameDialog()
	{
		KFLKGGGJHIN.KAJNLJJAJIJ += delegate
		{
			ShowGcChangeNameDialog();
		};
	}

	public void ShowGcChangeNameDialog()
	{
		UnityEngine.Debug.Log("#VOJTA# Tutorial state of current player account type: FB connect: " + data.currentPlayer.isFacebookConnected + " GC connect: " + data.currentPlayer.isGameCenterConnected);
		if (data.currentPlayer.isFacebookConnected || !data.currentPlayer.isGameCenterConnected)
		{
			return;
		}
		UnityEngine.Debug.Log("About to show GC Change Name Dialog");
		if (instance.HasGcName())
		{
			UnityEngine.Debug.Log("Has Gc Name!");
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			ConfirmDialog.IGCMBKLNIDB(Localization.Localize("ID_CONFIRM_GAMECENTER"), Localization.Localize("ID_CONFIRM_GAMECENTERNAMETEXT"), delegate(ConfirmDialog dialog, bool result)
			{
				if (result)
				{
					instance.ChangeToGcName();
				}
			}, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
		}
		else
		{
			UnityEngine.Debug.LogError("GC Name Is Missing, not showing dialog to change the name!");
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mFacebookService = new KFLKGGGJHIN();
		mICloudService = new ILEOBPDCGJB();
		Singleton<GooglePlayGameService>.instance.LoggedIn += GoogleLoggedIn;
		Singleton<GooglePlayGameService>.instance.LoggedOutExternaly += GoogleLoggedOutExternaly;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
	}

	internal void UpdateReputation(int reputation)
	{
		UnityEngine.Debug.Log("Updating reputation for current player = " + reputation);
		data.currentPlayer.reputation = reputation;
		Save();
	}

	public void CheckGpgsOnTutorialStart()
	{
		if (Singleton<GooglePlayGameService>.instance.isLoggedIn && string.IsNullOrEmpty(askGpgsId))
		{
			GoogleLoggedIn(true);
		}
	}

	private void GoogleLoggedIn(bool success)
	{
		UnityEngine.Debug.LogError("Game Login Manager: Google logged in " + ((!success) ? "ERROR!" : "succesfully"));
		if (!success)
		{
			return;
		}
		string id = Social.localUser.id;
		string lBMADCINIJG = data.currentPlayer.name;
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LFFKKOEMOFM();
		if (Singleton<GameController>.instance.isNotTutorialEnded)
		{
			UnityEngine.Debug.Log("#AccoutCheck# GPGS login during tutorial");
			if (data.playerAccount != null && data.isDeviceRegistered && askGpgsId != id)
			{
				if (!data.currentPlayer.isGooglePlayConnected || data.playerAccount.hashKeyGP != "GooglePlay" + id)
				{
					askGpgsId = id;
					UnityEngine.Debug.LogFormat("#AccoutCheck# GoogleLoggedIn tutorial - Check current gpgs on server : {0}", askGpgsId);
					Singleton<BeanstalkServerManager>.instance.CheckIfExistGpgsAccount(id);
				}
				else
				{
					UnityEngine.Debug.Log("#AccoutCheck# GoogleLoggedIn tutorial - ALL OK - logged to gpgs connectet to this account");
				}
			}
			else
			{
				UnityEngine.Debug.Log("#AccoutCheck# GoogleLoggedIn tutorial - wrong situation -> do nothing");
			}
		}
		else
		{
			string pGHCHNIDLNJ = MEJMLNDFDBP.BGCDGDKEGBH(id);
			if (!data.currentPlayer.isGooglePlayConnected || data.currentPlayer.GetOriginalGooglePlayId() != Social.localUser.id)
			{
				Singleton<BeanstalkServerManager>.instance.EAAKDLHLCDE(id, lBMADCINIJG, pGHCHNIDLNJ);
			}
		}
	}

	private void GoogleLoggedOutExternaly()
	{
		Singleton<BeanstalkServerManager>.instance.FBANDFJDDPJ();
		askGpgsId = string.Empty;
		cachedGpgsId = string.Empty;
	}

	protected override void Start()
	{
		base.Start();
		if (data.isDeviceRegistered)
		{
			playerId = data.currentPlayer.id;
		}
	}

	internal bool HasGcName()
	{
		return !string.IsNullOrEmpty(Singleton<GameCenterProvider>.instance.PJIOKCKLBJH);
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		switch (action)
		{
		case DatabaseAction.LoginToCustomAccount:
		case DatabaseAction.SwitchToFacebook:
		case DatabaseAction.AddGameCenter:
			UnityEngine.Debug.Log("GameLoginManager: Login successful, getting player data");
			data.isDeviceRegistered = true;
			Save();
			acountDataDownloadingInProgress = true;
			Singleton<BeanstalkServerManager>.instance.FMDBCAFPPGP();
			if (this.DeviceRegistered != null)
			{
				this.DeviceRegistered();
			}
			break;
		case DatabaseAction.GetConfigurations:
			UnityEngine.Debug.Log("GLM: OnDataLoaded - configurations.  is tutorial? " + Singleton<GameController>.instance.isTutorial);
			if (!Singleton<GameController>.instance.isTutorial && needGCchange)
			{
				needGCchange = false;
				if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA && !data.currentPlayer.isFacebookConnected)
				{
					Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(Singleton<GameCenterProvider>.instance.PIIIKJJHJPN);
				}
			}
			break;
		case DatabaseAction.AddGooglePlay:
			if (!(Social.localUser.userName != data.currentPlayer.name) || !data.currentPlayer.isGooglePlayConnected)
			{
				break;
			}
			ConfirmDialog.IGCMBKLNIDB(Localization.Localize("ID_CONFIRM_CONNECTTOGOOGLENAME"), Localization.Localize("ID_CONFIRM_CONNECTTOGOOGLENAMETEXT"), delegate(ConfirmDialog dialog, bool result)
			{
				if (result)
				{
					Singleton<BeanstalkServerManager>.instance.ChangePlayerName(Social.localUser.userName);
				}
			}, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
			break;
		}
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (!Singleton<GameController>.instance.isTutorial && mFacebookService != null)
		{
			mFacebookService.FNFKPACOCBJ();
		}
	}

	internal void ChangeToGcName()
	{
		Singleton<BeanstalkServerManager>.instance.ChangePlayerName(Singleton<GameCenterProvider>.instance.PJIOKCKLBJH);
	}

	public void LoginToFacebook(Action<bool> callback)
	{
		if (callback != null)
		{
			mFacebookService.FFKHLHBDMLD += callback;
		}
		LoginToFacebook();
	}

	public void LoginToFacebook()
	{
		mFacebookService.KLIKHGMGGNP();
	}

	public void LoginToGoogle()
	{
		Singleton<GooglePlayGameService>.instance.LogIn();
	}

	public void AfterTutorialLoginToFacebook()
	{
		mFacebookService.ANDPGGEINKL();
	}

	public void AfterTutorialGCcheck()
	{
		UnityEngine.Debug.Log("GLM: After tutorial GC check");
		changeGCAfterTutorialInProgress = false;
		needGCchange = false;
		if (data.currentPlayer.isFacebookConnected)
		{
			return;
		}
		if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA)
		{
			if (!data.currentPlayer.isGameCenterConnected || data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.PIIIKJJHJPN)
			{
				UnityEngine.Debug.Log("GLM: After tutorial GC check -> ADD GC");
				changeGCAfterTutorialInProgress = true;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(Singleton<GameCenterProvider>.instance.PIIIKJJHJPN);
			}
		}
		else if (data.currentPlayer.isGameCenterConnected)
		{
			changeGCAfterTutorialInProgress = true;
			UnityEngine.Debug.Log("GLM: After tutorial GC check -> REMOVE GC");
			Singleton<BeanstalkServerManager>.instance.LLIDDCCBOII(string.Empty);
		}
	}

	internal void SetDepositedCards(Dictionary<string, string> mDepositedCards)
	{
		UnityEngine.Debug.LogWarning("SetDepositedCards " + ((mDepositedCards != null) ? mDepositedCards.Count : (-1)));
		if (mDepositedCards == null)
		{
			UnityEngine.Debug.LogError("CURRENT PLAYER - SET DEPOSITED CARDS - deposited cards is null");
			return;
		}
		data.currentPlayer.depositedCardsDic = mDepositedCards;
		Save();
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log("#PETER# UPDATING CURRENT PLAYER DEPOSITED WARCARDS IN GAMELOGINMANAGER:\n" + data.currentPlayer.debugDepositedWarcards);
		}
	}

	public void RemoveCardFromDeposited(string cardId)
	{
		UnityEngine.Debug.LogWarning("RemoveCardFromDeposited " + cardId);
		if (string.IsNullOrEmpty(cardId))
		{
			UnityEngine.Debug.LogError("CURRENT PLAYER - REMOVE CARD FROM DEPOSITED CARDS - card id is null");
			return;
		}
		UnityEngine.Debug.Log(string.Format("REMOVING WARCARD: \"{0}\" FROM DEPOSITED WARCARDS", cardId));
		Dictionary<string, string> depositedCardsDic = data.currentPlayer.depositedCardsDic;
		if (depositedCardsDic != null)
		{
			if (depositedCardsDic.ContainsKey(cardId))
			{
				depositedCardsDic.Remove(cardId);
			}
			data.currentPlayer.depositedCardsDic = depositedCardsDic;
			Save();
		}
		else
		{
			UnityEngine.Debug.LogError("CURRENT PLAYER - depositedCardsDic is null");
		}
	}

	internal void SetDepositedCards(Dictionary<string, object> depositedCards)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (KeyValuePair<string, object> depositedCard in depositedCards)
		{
			dictionary[depositedCard.Key] = depositedCard.Value.ToString();
		}
		SetDepositedCards(dictionary);
	}

	public bool CheckGpgsAfterTutorial()
	{
		if (Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			GoogleLoggedIn(true);
			return true;
		}
		return false;
	}

	public bool CheckFacebookAfterTutorial()
	{
		return mFacebookService.PJENNBPCGHO();
	}

	public void LogoutFromGooglePlay(bool clientOnly)
	{
		UnityEngine.Debug.LogError("Remove Google Play " + ((!clientOnly) ? "On server" : "ClientOnly"));
		Singleton<GooglePlayGameService>.instance.LogOut();
		if (clientOnly)
		{
			return;
		}
		GuiElementSingle<FacebookDialog>.instance.ShowGooglePlayLogoutDialog(delegate(bool result)
		{
			if (result)
			{
				Singleton<BeanstalkServerManager>.instance.FBANDFJDDPJ();
			}
		});
	}

	public void LogoutFromFacebook(bool clientOnly)
	{
		BFLDHOLADMC bFLDHOLADMC = new BFLDHOLADMC();
		bFLDHOLADMC.IBKDBHAPOGC = clientOnly;
		bFLDHOLADMC.BJGCPDNMHDH = this;
		if (bFLDHOLADMC.IBKDBHAPOGC)
		{
			UnityEngine.Debug.Log("GameLoginManager: Logout from facebook");
			mFacebookService.IHOGKPNDCOM(bFLDHOLADMC.IBKDBHAPOGC);
			return;
		}
		bool fHLOIEFEIME = false;
		if (data.currentPlayer.isGameCenterConnected)
		{
			if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA)
			{
				if (data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.PIIIKJJHJPN)
				{
					fHLOIEFEIME = true;
				}
			}
			else
			{
				fHLOIEFEIME = true;
			}
		}
		GuiElementSingle<FacebookDialog>.instance.ShowLogoutDialog(fHLOIEFEIME, bFLDHOLADMC.LJCDGJKCNEC);
	}

	public void RelogToFacebook()
	{
		ConfirmDialog.ShowAlert(delegate
		{
			LoginToFacebook();
		}, Localization.Localize("ID_RELOG_TO_FB_DIALOG_TITLE"), Localization.LocalizeFormat("ID_RELOG_TO_FB_DIALOG_TEXT", facebookName));
	}

	public void OnPlayerDataLoadedSquadNameCheck(string squadName)
	{
		if (string.IsNullOrEmpty(data.currentPlayer.squadName))
		{
			UnityEngine.Debug.LogError("Player not in squad and should be in squad " + squadName + ". Correcting...");
		}
		else if (data.currentPlayer.squadName != squadName)
		{
			UnityEngine.Debug.LogError("Player is in squad " + data.currentPlayer.squadName + " and should be in squad " + squadName + ". Correcting...");
		}
		if (squadName != data.currentPlayer.squadName)
		{
			data.currentPlayer.squadName = squadName;
			Save();
			UnityEngine.Debug.Log("Corrected squad name for current player");
		}
	}

	internal void AddPlayerToSquad(string squadId, SquadRank squadRank)
	{
		data.currentPlayer.squadName = Regex.Replace(squadId, "-[0-9]*$", string.Empty);
		data.currentPlayer.squadRank = squadRank;
		if (this.PlayerJoinedSquad != null)
		{
			this.PlayerJoinedSquad(squadId);
		}
		Save();
	}

	internal void RemovePlayerFromSquad(List<string> cardList = null)
	{
		string text = ((cardList != null) ? string.Format("ADDING {0} WARCARD/-S FROM CARDPOOL", cardList.Count) : "NONE WARCARDS TO ADD FROM CARDPOOL");
		UnityEngine.Debug.LogWarning("REMOVING CURRENT PLAYER FROM SQUAD " + text);
		data.currentPlayer.squadName = null;
		data.currentPlayer.squadRank = SquadRank.None;
		if (data.currentPlayer.depositedCardsDic != null)
		{
			data.currentPlayer.depositedCardsDic.Clear();
		}
		if (cardList != null)
		{
			text = "Adding warcards from cardpool:\n";
			foreach (string card in cardList)
			{
				text = text + card + "\n";
				CardManager.instance.AddCard(card);
			}
			UnityEngine.Debug.Log(text);
		}
		Singleton<ServerResultsCache>.instance.squadEventProgress = null;
		if (this.PlayerLeftSquad != null)
		{
			this.PlayerLeftSquad();
		}
		Save();
	}

	public static void Relog(bool showScreen = true)
	{
		UnityEngine.Debug.Log("GameLoginManager: Reloging...");
		if (instance.PlayerLogOut != null)
		{
			instance.PlayerLogOut();
		}
		if (showScreen && (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu || Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.WaitingForResponse))
		{
			instance.InvokeAfterFrame(delegate
			{
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				instance.data.isDeviceRegistered = false;
				instance.Save();
				Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
				Singleton<BeanstalkServerManager>.instance.ResetSending();
				instance.RegisterOrLogin();
			});
		}
	}

	internal void UpdatePlayerByGC(string id, string password, AccountType accountType)
	{
		data.playerAccount.hashKeyGC = id;
		data.playerAccount.passwordGC = password;
		data.playerAccount.accountType = accountType;
		DatabasePlayer databasePlayer = data.currentPlayer;
		databasePlayer.gameCenterId = id;
		mICloudService.KDHILIAIIDF(data.playerAccount);
		UnityEngine.Debug.Log("Saving GC Player Account change!");
		Save();
		if (GuiElementSingle<LoadingDialog>.instance.DOOKCHBBBGA.text == Localization.Localize("ID_LOADING"))
		{
			LoadingDialog.Hide();
		}
	}

	internal void UpdateGCId(string gcId)
	{
		if (data.playerAccount == null)
		{
			data.playerAccount = new PlayerAccount();
		}
		data.playerAccount.hashKeyGC = gcId;
		if (!string.IsNullOrEmpty(gcId))
		{
			data.playerAccount.passwordGC = MEJMLNDFDBP.BGCDGDKEGBH(gcId + "banana");
		}
		else
		{
			data.playerAccount.passwordGC = string.Empty;
		}
	}

	internal void SavePlayer(DatabasePlayer databasePlayer, string id, string accessToken, string password, AccountType accountType)
	{
		data.currentPlayer = databasePlayer;
		playerId = databasePlayer.id;
		loginAccessToken = accessToken;
		UnityEngine.Debug.Log("set acces token: " + loginAccessToken);
		data.isDeviceRegistered = true;
		if (this.DeviceRegistered != null)
		{
			this.DeviceRegistered();
		}
		KochavaManager.LinkPlayer(playerId);
		if (data.playerAccount == null)
		{
			data.playerAccount = new PlayerAccount();
		}
		data.playerAccount.id = databasePlayer.id;
		switch (accountType)
		{
		case AccountType.Facebook:
			data.playerAccount.hashKeyFB = id;
			data.playerAccount.passwordFB = password;
			break;
		case AccountType.GameCenter:
			data.playerAccount.hashKeyGC = id;
			data.playerAccount.passwordGC = password;
			break;
		case AccountType.Guest:
			data.playerAccount.hashKeyGuest = id;
			data.playerAccount.passwordGuest = password;
			break;
		case AccountType.GooglePlay:
			data.playerAccount.hashKeyGP = id;
			data.playerAccount.passwordGP = password;
			break;
		default:
			UnityEngine.Debug.LogError("wrong account type: " + accountType);
			break;
		}
		data.playerAccount.accountType = accountType;
		mICloudService.KDHILIAIIDF(data.playerAccount);
		UnityEngine.Debug.Log("#PLAYERID# Saving Player Account with PlayerId = " + databasePlayer.id);
		Save();
	}

	internal void FacebookLogout()
	{
		UnityEngine.Debug.LogWarningFormat("FB: FacebookLogout called ..");
		if (data.currentPlayer.isGameCenterConnected)
		{
			UnityEngine.Debug.LogWarningFormat("FB: FacebookLogout GC connected");
			if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA)
			{
				if (data.playerAccount.hashKeyGC == Singleton<GameCenterProvider>.instance.PIIIKJJHJPN)
				{
					UnityEngine.Debug.LogWarningFormat("FB: FacebookLogout - RemoveFacebook - 1");
					Singleton<BeanstalkServerManager>.instance.PIFMMDGEGPK();
				}
				else
				{
					UnityEngine.Debug.LogWarningFormat("FB: FacebookLogout - DeletePlayerAccount - 1");
					DeletePlayerAccount();
					Relog();
				}
			}
			else
			{
				UnityEngine.Debug.LogWarningFormat("FB: FacebookLogout - DeletePlayerAccount - 2");
				DeletePlayerAccount();
				Relog();
			}
		}
		else
		{
			UnityEngine.Debug.LogWarningFormat("FB: FacebookLogout - RemoveFacebook - 2");
			Singleton<BeanstalkServerManager>.instance.PIFMMDGEGPK();
		}
		UnityEngine.Debug.LogWarningFormat("FB: FacebookLogout finished ..");
	}

	internal void RemoveLoginData(AccountType accountType, string playerName, string newGuestPassword, string newGuestId)
	{
		UnityEngine.Debug.Log("Game Login Manager: Remove Login Data");
		if (accountType != AccountType.Facebook)
		{
			data.currentPlayer.facebookId = -1L;
			UnityEngine.Debug.Log("Remove Facebook Data");
		}
		if (accountType != AccountType.GooglePlay)
		{
			data.currentPlayer.googlePlayId = null;
			UnityEngine.Debug.Log("Remove Google Play Data");
		}
		data.currentPlayer.accountName = playerName;
		data.currentPlayer.accountType = accountType;
		data.playerAccount.accountType = accountType;
		if (!string.IsNullOrEmpty(newGuestPassword) && !string.IsNullOrEmpty(newGuestId))
		{
			data.playerAccount.passwordGuest = newGuestPassword;
			data.playerAccount.hashKeyGuest = newGuestId;
		}
		mICloudService.KDHILIAIIDF(data.playerAccount);
		Save();
		if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA && (!data.currentPlayer.isGameCenterConnected || data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.PIIIKJJHJPN))
		{
			Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(Singleton<GameCenterProvider>.instance.PIIIKJJHJPN);
		}
	}

	public void SaveLoginData(string id, string playerName, string password, AccountType accountType)
	{
		UnityEngine.Debug.Log("Save Login Data " + id + ", name = " + playerName + ", password = " + password + ", accountType = " + accountType);
		data.currentPlayer.accountName = playerName;
		data.currentPlayer.accountType = accountType;
		switch (accountType)
		{
		case AccountType.Facebook:
			data.currentPlayer.facebookId = KHJJFPPACBP.OOAIMCEBPOK(id, 0L);
			data.playerAccount.hashKeyFB = id;
			data.playerAccount.passwordFB = password;
			break;
		case AccountType.GooglePlay:
			data.currentPlayer.googlePlayId = id;
			data.playerAccount.hashKeyGP = id;
			data.playerAccount.passwordGP = password;
			break;
		}
		if (accountType != AccountType.Facebook)
		{
			data.playerAccount.accountType = accountType;
		}
		mICloudService.KDHILIAIIDF(data.playerAccount);
		Save();
	}

	internal void UpdatePlayerSquadRank(SquadRank squadRank)
	{
		UnityEngine.Debug.Log(string.Concat("Squad rank updated from server, on client = ", data.currentPlayer.squadRank, ", on server = ", squadRank));
		data.currentPlayer.squadRank = squadRank;
		Save();
	}

	public void CreateNewAccount(bool gamecenter)
	{
		UnityEngine.Debug.Log("GLM: CreateNewAccount - GC: " + gamecenter);
		acountDataDownloadingInProgress = true;
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
		Singleton<MessageManager>.instance.ClearAllMessages();
		GameControllerTutorial.ResetTutorialProgress();
		loginAccessToken = string.Empty;
		if (gamecenter)
		{
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(Singleton<GameCenterProvider>.instance.PIIIKJJHJPN);
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.CreateAccount();
		}
	}

	private void prepareAccountChange()
	{
		acountDataDownloadingInProgress = true;
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
		Singleton<MessageManager>.instance.ClearAllMessages();
		TutorialManagerStage1.instance.FinishTutorial();
		TutorialManagerStage2.instance.FinishTutorial();
		TutorialManagerStage3.instance.FinishTutorial();
		GameControllerTutorial.ResetTutorialProgress();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		GuiElementSingle<TutorialFade>.instance.Hide();
		Singleton<TutorialProgressShower>.instance.Disable();
		GuiElementSingle<InventoryGuiElement>.instance.Show();
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		if (Singleton<GuiManager>.instance.AODFEHKBJIN != null)
		{
			Singleton<GuiManager>.instance.HideGui(Singleton<GuiManager>.instance.AODFEHKBJIN);
			Singleton<GuiManager>.instance.AODFEHKBJIN = null;
		}
		GuiElementSingle<MenuHeader>.instance.InTutorialAccountChange();
	}

	public void AccountChange()
	{
		if (mFacebookService.MEDEIMEPMFM())
		{
			long? num = cachedFbId;
			if (num.GetValueOrDefault() == mFacebookService.GPLCOIHJLDF() && num.HasValue)
			{
				UnityEngine.Debug.Log("#AccoutCheck# Switching to FB account");
				string pGHCHNIDLNJ = mFacebookService.JDKBICLPIIG();
				prepareAccountChange();
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(cachedFbId.ToString(), pGHCHNIDLNJ, AccountType.Facebook);
				cachedFbId = null;
				askFbId = null;
				return;
			}
		}
		if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA && cachedGcId == Singleton<GameCenterProvider>.instance.PIIIKJJHJPN)
		{
			UnityEngine.Debug.Log("#AccoutCheck# Switching to GC account");
			string pGHCHNIDLNJ2 = MEJMLNDFDBP.BGCDGDKEGBH(cachedGcId + "banana");
			prepareAccountChange();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(cachedGcId, pGHCHNIDLNJ2, AccountType.GameCenter);
			cachedGcId = string.Empty;
			askGcId = string.Empty;
		}
		else if (Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			string text = ((!cachedGpgsId.StartsWith("GooglePlay")) ? cachedGpgsId : cachedGpgsId.Substring("GooglePlay".Length));
			string id = Social.localUser.id;
			if (id == text)
			{
				UnityEngine.Debug.Log("#AccoutCheck# Switching to gpgs account");
				string pGHCHNIDLNJ3 = MEJMLNDFDBP.BGCDGDKEGBH(text);
				prepareAccountChange();
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(text, pGHCHNIDLNJ3, AccountType.GooglePlay);
				cachedGpgsId = string.Empty;
				askGpgsId = string.Empty;
			}
		}
		else
		{
			RegisterOrLogin();
		}
	}

	[DebuggerHidden]
	private IEnumerator WaitToLoadingFinish(bool ask)
	{
		HNIDECFHCGF hNIDECFHCGF = new HNIDECFHCGF();
		hNIDECFHCGF.NPCNPNMPBGC = ask;
		hNIDECFHCGF.BJGCPDNMHDH = this;
		return hNIDECFHCGF;
	}

	private void ChangeAccountDialogCallback(ConfirmDialog c, bool b)
	{
		if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Playing)
		{
			StartCoroutine(WaitToLoadingFinish(false));
		}
		else if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			AccountChange();
		}
		else
		{
			Singleton<GameController>.instance.ChangeAccountDuringTutorial();
		}
	}

	public void OnFacebookPlatformErrorDuringTutorial()
	{
		askFbId = null;
		if (Singleton<GameController>.instance.isLoadingOrPlaying)
		{
			Singleton<GameController>.instance.mainController.ResumeGame();
			GuiElementSingle<TutorialDialog>.instance.ReshowTutorialDialogAfterError();
		}
	}

	public void OnGpgsUserExistDuringTutorial(string gpgsId)
	{
		if (acountDataDownloadingInProgress)
		{
			UnityEngine.Debug.Log("#AccoutCheck# gpgs account found during account loading!!! - TODO!");
		}
		else if (Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			string text = "GooglePlay" + Social.localUser.id;
			if (text == gpgsId)
			{
				cachedGpgsId = gpgsId;
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Playing)
				{
					UnityEngine.Debug.LogFormat("#AccoutCheck# gpgs accoun found: loading wait - {0}", cachedGpgsId);
					StartCoroutine(WaitToLoadingFinish(true));
				}
				else
				{
					UnityEngine.Debug.Log("#AccoutCheck# gpgs accoun found: inform about account change");
					Singleton<GuiManager>.instance.TurnOnInputCompletly();
					ConfirmDialog.ShowAlert(ChangeAccountDialogCallback, Localization.Localize("ID_GPGS_LOGIN_TUTORIAL_TITLE"), Localization.Localize("ID_GPGS_LOGIN_TUTORIAL_TEXT"));
				}
			}
			else
			{
				UnityEngine.Debug.LogFormat("#AccoutCheck# check gpgs, but Id is not same {0} != {1}", text, gpgsId);
			}
		}
		else
		{
			UnityEngine.Debug.Log("#AccoutCheck# check gpgs but offline");
		}
	}

	public void OnAccoutNotExistAfterLoginServices(AccountType type)
	{
		if (acountDataDownloadingInProgress)
		{
			UnityEngine.Debug.Log("#AccoutCheck# Facebook account found during account loading!!! - TODO!");
			return;
		}
		switch (type)
		{
		case AccountType.Facebook:
			askFbId = null;
			cachedFbId = null;
			break;
		case AccountType.GooglePlay:
			askGpgsId = null;
			cachedGpgsId = null;
			break;
		}
		string arg = type.ToString().ToUpper();
		ConfirmDialog.ShowAlert(delegate
		{
			if (Singleton<GameController>.instance.isLoadingOrPlaying)
			{
				Singleton<GameController>.instance.mainController.ResumeGame();
				GuiElementSingle<TutorialDialog>.instance.ReshowTutorialDialogAfterError();
			}
		}, Localization.Localize(string.Format("ID_TUTORIAL_NOACCOUNT_{0}_TITLE", arg)), Localization.Localize(string.Format("ID_TUTORIAL_NOACCOUNT_{0}_TEXT", arg)));
		if (this.LoginDataChanged != null)
		{
			this.LoginDataChanged();
		}
	}

	public void OnFacebookUserExistDuringTutorial(string fbId)
	{
		if (acountDataDownloadingInProgress)
		{
			UnityEngine.Debug.Log("#AccoutCheck# Facebook account found during account loading!!! - TODO!");
			return;
		}
		long result = 0L;
		if (long.TryParse(fbId, out result))
		{
			if (mFacebookService.MEDEIMEPMFM() && result == mFacebookService.GPLCOIHJLDF())
			{
				cachedFbId = result;
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Playing)
				{
					UnityEngine.Debug.Log("#AccoutCheck# Facebook accoun found - invalid ID");
					StartCoroutine(WaitToLoadingFinish(true));
				}
				else
				{
					UnityEngine.Debug.Log("#AccoutCheck# Facebook accoun found: inform about account change");
					Singleton<GuiManager>.instance.TurnOnInputCompletly();
					ConfirmDialog.ShowAlert(ChangeAccountDialogCallback, Localization.Localize("ID_FB_LOGIN_TUTORIAL_TITLE"), Localization.Localize("ID_FB_LOGIN_TUTORIAL_TEXT"));
				}
			}
			else
			{
				UnityEngine.Debug.LogFormat("#AccoutCheck# Facebook  online:{2} accoun found: {0} != {1}", result, mFacebookService.GPLCOIHJLDF(), mFacebookService.MEDEIMEPMFM());
			}
		}
		else
		{
			UnityEngine.Debug.Log("#AccoutCheck# Facebook accoun found - invalid ID");
		}
	}

	public void OnGamecenterUserExistDuringTutorial(string gcId)
	{
		if (acountDataDownloadingInProgress)
		{
			Singleton<SessionManager>.instance.ScheduleGCCheck();
		}
		else if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA && gcId == Singleton<GameCenterProvider>.instance.PIIIKJJHJPN)
		{
			cachedGcId = gcId;
			if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu && Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Playing)
			{
				StartCoroutine(WaitToLoadingFinish(true));
				return;
			}
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
			ConfirmDialog.ShowAlert(ChangeAccountDialogCallback, Localization.Localize("ID_GC_LOGIN_TUTORIAL_TITLE"), Localization.Localize("ID_GC_LOGIN_TUTORIAL_TEXT"));
		}
	}

	public void FacebookLoginDuringTutorial(long fbId)
	{
		UnityEngine.Debug.Log("#AccoutCheck# FB login during tutorial");
		if (data.playerAccount != null && data.isDeviceRegistered && askFbId != fbId)
		{
			string text = fbId.ToString();
			if (!data.currentPlayer.isFacebookConnected || data.playerAccount.hashKeyFB != text)
			{
				UnityEngine.Debug.Log("#AccoutCheck# FacebookLoginDuringTutorial - Check current FB on server");
				askFbId = fbId;
				Singleton<BeanstalkServerManager>.instance.CheckIfExistFbAccount(text);
			}
			else
			{
				UnityEngine.Debug.Log("#AccoutCheck# FacebookLoginDuringTutorial - ALL OK - loged to FB connectet to this account");
			}
		}
		else
		{
			UnityEngine.Debug.Log("#AccoutCheck# FacebookLoginDuringTutorial - wrong situation -> do nothing");
		}
	}

	public void GamecenterChangeDuringTutorial()
	{
		UnityEngine.Debug.Log("#AccoutCheck# possibly change GC during tutorial");
		if (data.playerAccount != null && data.isDeviceRegistered && !data.currentPlayer.isFacebookConnected && askGcId != Singleton<GameCenterProvider>.instance.PIIIKJJHJPN && !mFacebookService.MEDEIMEPMFM())
		{
			if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA)
			{
				if (!data.currentPlayer.isGameCenterConnected || data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.PIIIKJJHJPN)
				{
					UnityEngine.Debug.Log("#AccoutCheck# GamecenterChangeDuringTutorial - Check current GC on server");
					askGcId = Singleton<GameCenterProvider>.instance.PIIIKJJHJPN;
					Singleton<BeanstalkServerManager>.instance.CheckIfExistGcAccount(Singleton<GameCenterProvider>.instance.PIIIKJJHJPN);
				}
				else
				{
					UnityEngine.Debug.Log("#AccoutCheck# GamecenterChangeDuringTutorial - ALL OK - loged to GC connectet to this account");
				}
			}
			else
			{
				UnityEngine.Debug.Log("#AccoutCheck# GamecenterChangeDuringTutorial - NOT connect -> ignore for this moment");
			}
		}
		else
		{
			UnityEngine.Debug.Log("#AccoutCheck# GamecenterChangeDuringTutorial - wrong situation -> do nothing");
		}
	}

	internal void RegisterOrLogin(SessionManager.MFGMKAJDCAI sessionUpdate = SessionManager.MFGMKAJDCAI.Full)
	{
		if (data.playerAccount == null)
		{
			data.playerAccount = mICloudService.HIKCCBMLNDE();
			Save();
		}
		if (data.playerAccount != null && data.playerAccount.UpdateByAccount())
		{
			mICloudService.KDHILIAIIDF(data.playerAccount);
			Save();
		}
		if (data.playerAccount == null)
		{
			UnityEngine.Debug.Log("GLM: RegisterOrLogin -  playerAccount == NULL");
			CreateNewAccount(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
			return;
		}
		if (data.isDeviceRegistered && !string.IsNullOrEmpty(loginAccessToken))
		{
			if (data.currentPlayer.isFacebookConnected)
			{
				UnityEngine.Debug.Log("GLM: RegisterOrLogin -  1");
				GetPlayerData(sessionUpdate, false);
			}
			else if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA)
			{
				if (data.currentPlayer.isGameCenterConnected)
				{
					if (data.playerAccount.hashKeyGC == Singleton<GameCenterProvider>.instance.PIIIKJJHJPN)
					{
						UnityEngine.Debug.Log("GLM: RegisterOrLogin -  4");
						GetPlayerData(sessionUpdate, false);
					}
					else
					{
						UnityEngine.Debug.Log("GLM: RegisterOrLogin -  5");
						CreateNewAccount(true);
					}
				}
				else if (Singleton<GameController>.instance.isTutorial)
				{
					UnityEngine.Debug.Log("GLM: RegisterOrLogin -  2");
					GetPlayerData(sessionUpdate, true);
				}
				else
				{
					UnityEngine.Debug.Log("GLM: RegisterOrLogin -  3");
					acountDataDownloadingInProgress = true;
					Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(Singleton<GameCenterProvider>.instance.PIIIKJJHJPN);
				}
			}
			else if (data.currentPlayer.isGameCenterConnected)
			{
				if (!Singleton<GameCenterProvider>.instance.HGKJLMMNDOE)
				{
					UnityEngine.Debug.Log("GLM: RegisterOrLogin - 6.5: no GC response, use stored values");
					GetPlayerData(sessionUpdate, false);
					return;
				}
				UnityEngine.Debug.Log("GLM: RegisterOrLogin -  6");
				acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.CheckIsOnline(delegate
				{
					ConfirmDialog.ShowAlert(delegate
					{
						CreateNewAccount(false);
					}, Localization.Localize("ID_GC_LOGOUT_TITLE"), Localization.Localize("ID_GC_LOGOUT_TEXT"));
				});
			}
			else
			{
				UnityEngine.Debug.Log("GLM: RegisterOrLogin -  7");
				GetPlayerData(sessionUpdate, false);
			}
			return;
		}
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
		bool flag = false;
		if (data.currentPlayer != null && !data.currentPlayer.isFacebookConnected)
		{
			if (Singleton<GameCenterProvider>.instance.LCMAHPKKGOA)
			{
				if (data.currentPlayer.isGameCenterConnected)
				{
					if (data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.PIIIKJJHJPN)
					{
						flag = true;
						UnityEngine.Debug.Log("GLM: RegisterOrLogin -  9");
						CreateNewAccount(true);
					}
				}
				else if (!Singleton<GameController>.instance.isTutorial)
				{
					needGCchange = true;
					UnityEngine.Debug.Log("GLM: RegisterOrLogin - need add GC");
				}
			}
			else if (data.currentPlayer.isGameCenterConnected)
			{
				UnityEngine.Debug.LogError(string.Format("hasResponse: {0}; hashKeyGC : {1} ; gcID : {2}", Singleton<GameCenterProvider>.instance.HGKJLMMNDOE, data.playerAccount.hashKeyGC, Singleton<GameCenterProvider>.instance.PIIIKJJHJPN));
				if (!Singleton<GameCenterProvider>.instance.HGKJLMMNDOE)
				{
					UnityEngine.Debug.Log("GLM: RegisterOrLogin - NOT GameCenterProvider.instance.hasResponse!!!, use saved!");
				}
				else
				{
					UnityEngine.Debug.Log("GLM: RegisterOrLogin -  10");
					flag = true;
					acountDataDownloadingInProgress = true;
					Singleton<BeanstalkServerManager>.instance.CheckIsOnline(delegate
					{
						ConfirmDialog.ShowAlert(delegate
						{
							CreateNewAccount(false);
						}, Localization.Localize("ID_GC_LOGOUT_TITLE"), Localization.Localize("ID_GC_LOGOUT_TEXT"));
					});
				}
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.Log("GLM: RegisterOrLogin -  8: " + data.playerAccount.accountType);
			acountDataDownloadingInProgress = true;
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(data.playerAccount.hashKeyByAccount, data.playerAccount.passwordByAccount, data.playerAccount.accountType);
		}
	}

	internal void DeletePlayerAccount()
	{
		data.playerAccount = null;
		Save();
		loginAccessToken = string.Empty;
		mICloudService.PMFKJLHAIGM();
	}

	internal void GetPlayerData(SessionManager.MFGMKAJDCAI sessionUpdate, bool changeGC)
	{
		switch (sessionUpdate)
		{
		case SessionManager.MFGMKAJDCAI.Light:
			Singleton<BeanstalkServerManager>.instance.FIENLGKEFEP((!Singleton<GameController>.instance.gameIsRunning) ? PlayerStatus.Online : PlayerStatus.InGame);
			if (changeGC)
			{
				needGCchange = true;
			}
			return;
		}
		if (changeGC)
		{
			needGCchange = true;
		}
		acountDataDownloadingInProgress = true;
		Singleton<BeanstalkServerManager>.instance.FMDBCAFPPGP();
	}

	public void UpdatePlayerLeagueAndMedals(int beginnersLeague, string league, int globalMedals, int leagueMedals, int remainingMatches)
	{
		string[] array = league.Split('-');
		League normalLeague = (League)Convert.ToInt32(array[0]);
		string leagueDivision = array[array.Length - 1];
		data.currentPlayer.leagueId = league;
		data.currentPlayer.leagueDivision = leagueDivision;
		UpdatePlayerLeagueAndMedals(beginnersLeague, normalLeague, globalMedals, leagueMedals, remainingMatches);
	}

	private void UpdatePlayerLeagueAndMedals(int beginnersLeague, League normalLeague, int globalMedals, int leagueMedals, int remainingMatches)
	{
		data.currentPlayer.beginnersLeague = beginnersLeague;
		data.currentPlayer.leagueTier = normalLeague;
		data.currentPlayer.skill = globalMedals;
		data.currentPlayer.medalsBalance = leagueMedals;
		data.currentPlayer.remainingMatches = remainingMatches;
		UnityEngine.Debug.LogFormat("Updated Player League And Medals to BeginnersLeague:{0} NormalLeague:{1} GlobalMedals:{2} LeagueMedals:{3} RemainingMatches:{4}", beginnersLeague, normalLeague, globalMedals, leagueMedals, remainingMatches);
		Save();
	}

	public void UpdatePlayerLeagueAndMedalsEnteredNormalLeague(string league, int beginnersLeague, int globalMedals, int leagueMedals, int remainingMatches, bool enteredNormalLeague)
	{
		wasInBeginnersLeague = false;
		bool flag = data.currentPlayer.beginnersLeague > 0 && beginnersLeague == 0;
		UpdatePlayerLeagueAndMedals(beginnersLeague, league, globalMedals, leagueMedals, remainingMatches);
		if (flag)
		{
			Singleton<MessageManager>.instance.AddMessage(new IMKNKBHECOD(data.currentPlayer.leagueTier));
		}
		if (enteredNormalLeague)
		{
			bool flag2 = StatsManager.instance.bestLeague == League.NoLeague;
			if (flag2)
			{
				UnityEngine.Debug.Log("!!!!! Player entered normal leagues FIRST TIME!!!!");
			}
			UnityEngine.Debug.Log("GameLoginManager - Player Entered Normal League - " + data.currentPlayer.leagueTier);
			Singleton<MessageManager>.instance.AddMessage(new IMKNKBHECOD(data.currentPlayer.leagueTier, flag2));
		}
	}

	public void UpdatePlayerLeagueAndMedalsEnteredBeginnersLeague(int beginnersLeague, int globalMedals, int leagueMedals, int remainingMatches)
	{
		wasInBeginnersLeague = currentPlayer.isInBeginnersLeague;
		wasBeginnerLeagueNumber = currentPlayer.beginnersLeague;
		bool flag = data.currentPlayer.beginnersLeague != beginnersLeague;
		UpdatePlayerLeagueAndMedals(beginnersLeague, data.currentPlayer.leagueTier, globalMedals, leagueMedals, remainingMatches);
		if (flag)
		{
			UnityEngine.Debug.Log("GameLoginManager - Player Entered Beginners League - " + data.currentPlayer.beginnersLeague);
			Singleton<MessageManager>.instance.AddMessage(new IMKNKBHECOD(data.currentPlayer.beginnersLeague));
			GuiScreenSingle<EndScreen>.instance.isEnteredBeginnersLeague = true;
		}
	}

	public void UpdatePlayerMedals(int globalMedals, int leagueMedals, int remainingMatches)
	{
		int skill = data.currentPlayer.skill;
		UpdatePlayerLeagueAndMedals(data.currentPlayer.beginnersLeague, data.currentPlayer.leagueTier, globalMedals, leagueMedals, remainingMatches);
		UnityEngine.Debug.Log("GameLoginManager - Global Medals update: " + skill + " -> " + globalMedals);
		Singleton<EventTrackingManager>.instance.fuseboxxService.AMBPGAPFKHD(LPDEOBOCICH.ADBKMBDIMNC.Medals, globalMedals);
	}

	public void RemovePlayerFromLeague(League newLeague)
	{
		Singleton<ServerResultsCache>.instance.RemovePlayerLeagueLeaderboard(data.currentPlayer.leagueId);
		int beginnersLeague = data.currentPlayer.beginnersLeague;
		int num = (int)newLeague;
		string league = num + "-placement";
		int skill = data.currentPlayer.skill;
		int leagueMedals = 0;
		int remainingMatches = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeaguePlacementMatches).FLOATVALUE;
		UpdatePlayerLeagueAndMedals(beginnersLeague, league, skill, leagueMedals, remainingMatches);
	}

	public void SavePlayerName(string playerName)
	{
		data.currentPlayer.accountName = playerName;
		Save();
	}

	public void RefreshFriends()
	{
		mFacebookService.PNAKFNJKLON();
	}

	public void OnFriendsLoaded()
	{
		if (this.FriendsLoaded != null)
		{
			this.FriendsLoaded();
		}
	}

	public void InviteFacebookFriends()
	{
		UnityEngine.Debug.Log("GameLoginManager: Invite Facebook Friends");
		mFacebookService.MEFKFFOLPBF();
	}

	internal void SaveGameCenterData(string gameCenterId)
	{
		data.currentPlayer.gameCenterId = gameCenterId;
		data.playerAccount.hashKeyGC = gameCenterId;
		if (data.currentPlayer.accountType == AccountType.Guest)
		{
			data.currentPlayer.accountType = AccountType.GameCenter;
		}
		mICloudService.KDHILIAIIDF(data.playerAccount);
		Save();
	}

	public void ResetStartingCurrencyPreset()
	{
		startingCurrencyPreset = false;
	}

	public void TryPresetStartingCurrency()
	{
		if (!startingCurrencyPreset)
		{
			Dictionary<string, object> dictionary = Singleton<EventTrackingManager>.instance.fuseboxxService.EDKFAADPJAJ();
			long result = Singleton<Wallet>.instance.gold;
			long result2 = Singleton<Wallet>.instance.warBucks;
			if (dictionary != null && dictionary.ContainsKey("gold") && dictionary["gold"] is string && long.TryParse(dictionary["gold"] as string, out result))
			{
				UnityEngine.Debug.Log("Found starting gold currency = " + dictionary["gold"]);
				Singleton<Wallet>.instance.GHPGMPNBJDB(result);
			}
			if (dictionary != null && dictionary.ContainsKey("warbucks") && dictionary["warbucks"] is string && long.TryParse(dictionary["warbucks"] as string, out result2))
			{
				UnityEngine.Debug.Log("Found starting warbucks currency = " + dictionary["warbucks"]);
				Singleton<Wallet>.instance.PLLPIAOOFFE(result2);
			}
			startingCurrencyPreset = true;
		}
	}

	public void SetPlayerDataAfterBootcamps()
	{
		data.currentPlayer.remainingMatches = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeaguePlacementMatches).FLOATVALUE;
		Save();
	}
}
