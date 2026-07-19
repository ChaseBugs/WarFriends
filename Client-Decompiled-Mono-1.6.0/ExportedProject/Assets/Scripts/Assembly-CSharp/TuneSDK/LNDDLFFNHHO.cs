using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TuneSDK
{
	public class LNDDLFFNHHO
	{
		private static LNDDLFFNHHO MFDCIFEBHHF;

		private AndroidJavaClass CEKJBALBAHP = new AndroidJavaClass("com.tune.Tune");

		private AndroidJavaClass KNKIIAFGHPM = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		private AndroidJavaObject JICJKBHMCFN;

		public AndroidJavaObject MELPJMEEFFM;

		public static LNDDLFFNHHO FOFHIPOFFKG
		{
			get
			{
				if (MFDCIFEBHHF == null)
				{
					MFDCIFEBHHF = new LNDDLFFNHHO();
				}
				return MFDCIFEBHHF;
			}
		}

		public string AJPOIMKNMKB()
		{
			return MELPJMEEFFM.Call<string>("BeanstalkServerManager.PlayerDataWasLoaded - DONE (coroutines)", new object[0]);
		}

		public void CPELHCGAHNO(string EHCBDHDPNCH)
		{
			MELPJMEEFFM.Call("setAndroidIdMd5", EHCBDHDPNCH);
		}

		public void HIKLJAFCDID(string JBFIOHGJGHP)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = JBFIOHGJGHP;
			mELPJMEEFFM.Call("AtlasPreparer.LoadGameCoroutine", array);
		}

		public void EGDGJFBFLLA(bool DJGKFANKBAG)
		{
			MELPJMEEFFM.Call("opponent defense stop shooting", DJGKFANKBAG);
		}

		public void HCLCLMHMMIF(int BCJPNMIBDNM)
		{
			MELPJMEEFFM.Call("setAge", BCJPNMIBDNM);
		}

		public void LMJAINDBOEN(string JBFIOHGJGHP, FAOPKIDIODH EHBNNJEBJDI)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.TuneLocation", EHBNNJEBJDI.DNJIEJNCLFN, EHBNNJEBJDI.EIFDFLGHKNI);
			MELPJMEEFFM.Call("registerCustomProfileGeolocation", JBFIOHGJGHP, androidJavaObject);
		}

		public bool NLHDMFHGIGE()
		{
			return MELPJMEEFFM.Call<bool>("didUserManuallyDisablePush", new object[0]);
		}

		public void CHPJJONOCFB()
		{
			MELPJMEEFFM.Call("setReferralSources", JICJKBHMCFN);
			MELPJMEEFFM.Call("measureSession");
		}

		public void ONCKCDJINAO(string JBFIOHGJGHP, FAOPKIDIODH IDEBKDPMPGM)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.TuneLocation", IDEBKDPMPGM.DNJIEJNCLFN, IDEBKDPMPGM.EIFDFLGHKNI);
			MELPJMEEFFM.Call("setCustomProfileGeolocation", JBFIOHGJGHP, androidJavaObject);
		}

		public DateTime BJDGFOHINFK(string JBFIOHGJGHP)
		{
			AndroidJavaObject androidJavaObject = MELPJMEEFFM.Call<AndroidJavaObject>("getCustomProfileDate", new object[1] { JBFIOHGJGHP });
			if (androidJavaObject != null)
			{
				long num = androidJavaObject.Call<long>("getTime", new object[0]);
				return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(num);
			}
			return default(DateTime);
		}

		public string JEGDCICNIBC()
		{
			return MELPJMEEFFM.Call<string>("Starting match against bot", new object[1]);
		}

		public void NKBBFEICCKM(bool KIIGKBOKHKF)
		{
			MELPJMEEFFM.Call("setDebugMode", KIIGKBOKHKF);
		}

		public void BDLADADBFPP(string HCBBPKOIMKE)
		{
			MELPJMEEFFM.Call("setReferralUrl", HCBBPKOIMKE);
		}

		[SpecialName]
		public static LNDDLFFNHHO JGHIIBJHDJO()
		{
			if (MFDCIFEBHHF == null)
			{
				MFDCIFEBHHF = new LNDDLFFNHHO();
			}
			return MFDCIFEBHHF;
		}

		public void OBCBHFOIDIF(bool GLJFJHEFKBG)
		{
			if (GLJFJHEFKBG)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("bazooka_run", new object[1]);
				MELPJMEEFFM.Call("menu-arena-winico", androidJavaObject);
			}
		}

		public void OEONPJGJPND(string JBFIOHGJGHP, string EHBNNJEBJDI)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[2];
			array[0] = JBFIOHGJGHP;
			array[0] = EHBNNJEBJDI;
			mELPJMEEFFM.Call("name", array);
		}

		public void FLLLKJHKAOK(bool LLNNNBEAGBC)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = LLNNNBEAGBC;
			mELPJMEEFFM.Call("Received FB Friends from server: ", array);
		}

		public void LPKIKAEHOMM()
		{
			MELPJMEEFFM.Call("opponentState.willAttack = true", new object[1]);
		}

		public void GFPGHDBICNA(string PDJIMKGEINA)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = PDJIMKGEINA;
			mELPJMEEFFM.Call("ID_CONFIRM_SQUADLEAVEERROR", array);
		}

		public void LPJAIFMHIJP(string JBFIOHGJGHP, float IDEBKDPMPGM)
		{
			MELPJMEEFFM.Call("setCustomProfileNumber", JBFIOHGJGHP, IDEBKDPMPGM);
		}

		public Dictionary<string, KIHINHPLIEC> IPEJLAJAIKN()
		{
			Dictionary<string, KIHINHPLIEC> dictionary = new Dictionary<string, KIHINHPLIEC>();
			AndroidJavaObject androidJavaObject = MELPJMEEFFM.Call<AndroidJavaObject>("getPowerHookExperimentDetails", new object[0]);
			if (androidJavaObject != null)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("entrySet", new object[0]);
				AndroidJavaObject androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("iterator", new object[0]);
				while (androidJavaObject3.Call<bool>("hasNext", new object[0]))
				{
					AndroidJavaObject androidJavaObject4 = androidJavaObject3.Call<AndroidJavaObject>("next", new object[0]);
					string key = androidJavaObject4.Call<string>("getKey", new object[0]);
					AndroidJavaObject pLMNDEMGBIP = androidJavaObject4.Call<AndroidJavaObject>("getValue", new object[0]);
					dictionary.Add(key, new KIHINHPLIEC(pLMNDEMGBIP));
				}
			}
			return dictionary;
		}

		public void NGEOEKFDEMH(string CGAGIGNCBJM, bool BMHOFGFOGGA)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.tune.TuneDebugUtilities");
			androidJavaClass.CallStatic("forceSetUserInSegmentId", CGAGIGNCBJM, BMHOFGFOGGA);
		}

		public void NCOMEKJIFMP(bool BCEGHIHJEAK, long OGGDPMCDCLJ)
		{
			if (BCEGHIHJEAK)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityFirstPlaylistListener");
				MELPJMEEFFM.Call("onFirstPlaylistDownloaded", androidJavaObject, OGGDPMCDCLJ);
			}
		}

		public void OBKPBFJBAJI(string JBFIOHGJGHP, string EHBNNJEBJDI)
		{
			MELPJMEEFFM.Call("registerCustomProfileString", JBFIOHGJGHP, EHBNNJEBJDI);
		}

		public void LPJAIFMHIJP(string JBFIOHGJGHP, int IDEBKDPMPGM)
		{
			MELPJMEEFFM.Call("setCustomProfileNumber", JBFIOHGJGHP, IDEBKDPMPGM);
		}

		public void HPOFKAJOIJD(string ADNDMABPHOH)
		{
			MELPJMEEFFM.Call("FpsData", ADNDMABPHOH);
		}

		public void PMPBLJCALMH(string LCKFMHEOPKD, string FCKBANHBIKN, string EHBNNJEBJDI)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = LCKFMHEOPKD;
			array[1] = FCKBANHBIKN;
			array[1] = EHBNNJEBJDI;
			mELPJMEEFFM.Call("menu-warbucks", array);
		}

		public void LILJJJNGBOO(bool BCEGHIHJEAK, long OGGDPMCDCLJ)
		{
			if (BCEGHIHJEAK)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("ID_ARENARULES_SHIELDSBREAKFASTER", new object[1]);
				AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
				object[] array = new object[3];
				array[0] = androidJavaObject;
				array[0] = OGGDPMCDCLJ;
				mELPJMEEFFM.Call("#PETER# Removing squad joined message - message time:{0}, server time:{1}, isInSquad:{2}", array);
			}
		}

		public void KIJJKOHBKFA(OIGOLMMEFKH EOFMBNANALP)
		{
			object[] array = new object[0];
			array[0] = EOFMBNANALP.NPFLLLEFNGH;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("goldShields", array);
			if (EOFMBNANALP.AJEALDLONFJ != null)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject;
				object[] array2 = new object[0];
				array2[1] = EOFMBNANALP.AJEALDLONFJ;
				androidJavaObject = androidJavaObject2.Call<AndroidJavaObject>("111-222-3333", array2);
			}
			if (EOFMBNANALP.CAJFOEAGHGD != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_TOCOMPLETE", new object[1] { EOFMBNANALP.CAJFOEAGHGD });
			}
			if (EOFMBNANALP.EIDGJLAACPE != null)
			{
				AndroidJavaObject androidJavaObject3 = androidJavaObject;
				object[] array3 = new object[0];
				array3[0] = EOFMBNANALP.EIDGJLAACPE;
				androidJavaObject = androidJavaObject3.Call<AndroidJavaObject>("Total_Battles", array3);
			}
			if (EOFMBNANALP.MFLOKCDHGCO != null)
			{
				AndroidJavaObject androidJavaObject4 = androidJavaObject;
				object[] array4 = new object[1];
				array4[1] = EOFMBNANALP.MFLOKCDHGCO;
				androidJavaObject = androidJavaObject4.Call<AndroidJavaObject>("ExplodeDamage", array4);
			}
			if (EOFMBNANALP.BCFNCDEPOAO != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("_CameraWS", new object[1] { EOFMBNANALP.BCFNCDEPOAO });
			}
			if (EOFMBNANALP.IMIPAFPMBPC != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("Create_Squad", new object[1] { EOFMBNANALP.IMIPAFPMBPC });
			}
			if (EOFMBNANALP.MKMJLAFHJAD != null)
			{
				AndroidJavaObject androidJavaObject5 = androidJavaObject;
				object[] array5 = new object[1];
				array5[1] = EOFMBNANALP.MKMJLAFHJAD;
				androidJavaObject = androidJavaObject5.Call<AndroidJavaObject>("ID_SYSTEMMAINTENANCE", array5);
			}
			if (EOFMBNANALP.BNKCJBHIGMB != null)
			{
				AndroidJavaObject androidJavaObject6 = androidJavaObject;
				object[] array6 = new object[0];
				array6[1] = EOFMBNANALP.BNKCJBHIGMB;
				androidJavaObject = androidJavaObject6.Call<AndroidJavaObject>("S", array6);
			}
			if (EOFMBNANALP.MHINMPHEIBH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_", new object[1] { EOFMBNANALP.MHINMPHEIBH });
			}
			if (EOFMBNANALP.HDIFLJOLCFI != null)
			{
				AndroidJavaObject androidJavaObject7 = androidJavaObject;
				object[] array7 = new object[0];
				array7[1] = EOFMBNANALP.HDIFLJOLCFI;
				androidJavaObject = androidJavaObject7.Call<AndroidJavaObject>("ID_CONFIRM_RESTORE", array7);
			}
			if (EOFMBNANALP.KNIHMOHMMCL != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("bad card visuals for", new object[1] { EOFMBNANALP.KNIHMOHMMCL });
			}
			if (EOFMBNANALP.MNKEIAPDNPH != null)
			{
				AndroidJavaObject androidJavaObject8 = androidJavaObject;
				object[] array8 = new object[0];
				array8[1] = EOFMBNANALP.MNKEIAPDNPH;
				androidJavaObject = androidJavaObject8.Call<AndroidJavaObject>("player_level", array8);
			}
			if (EOFMBNANALP.LPDBPGJANAP != null)
			{
				AndroidJavaObject androidJavaObject9 = androidJavaObject;
				object[] array9 = new object[0];
				array9[0] = EOFMBNANALP.LPDBPGJANAP;
				androidJavaObject = androidJavaObject9.Call<AndroidJavaObject>("Notification_DailyRewards", array9);
			}
			if (EOFMBNANALP.PEOBBKMKKPH != null)
			{
				AndroidJavaObject androidJavaObject10 = androidJavaObject;
				object[] array10 = new object[1];
				array10[1] = EOFMBNANALP.PEOBBKMKKPH;
				androidJavaObject = androidJavaObject10.Call<AndroidJavaObject>("getErrorCode", array10);
			}
			if (EOFMBNANALP.BBCOJPFLOIL != null)
			{
				AndroidJavaObject androidJavaObject11 = androidJavaObject;
				object[] array11 = new object[1];
				array11[1] = EOFMBNANALP.BBCOJPFLOIL;
				androidJavaObject = androidJavaObject11.Call<AndroidJavaObject>("ID_LEAGUEPROMOTEHINT", array11);
			}
			if (EOFMBNANALP.BBGEPEOAJCO != null)
			{
				AndroidJavaObject androidJavaObject12 = androidJavaObject;
				object[] array12 = new object[0];
				array12[1] = EOFMBNANALP.BBGEPEOAJCO;
				androidJavaObject = androidJavaObject12.Call<AndroidJavaObject>("Player disconected 0001", array12);
			}
			if (EOFMBNANALP.FAHGOOKOCNE != null)
			{
				AndroidJavaObject androidJavaObject13 = androidJavaObject;
				object[] array13 = new object[0];
				array13[0] = EOFMBNANALP.FAHGOOKOCNE;
				androidJavaObject = androidJavaObject13.Call<AndroidJavaObject>("With", array13);
			}
			if (EOFMBNANALP.OCEJMMCCJMB != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("Sprite \"{0}\" was used in files:", new object[1] { EOFMBNANALP.OCEJMMCCJMB });
			}
			if (EOFMBNANALP.CNIKOPJGLCA != null)
			{
				AndroidJavaObject androidJavaObject14 = androidJavaObject;
				object[] array14 = new object[0];
				array14[1] = EOFMBNANALP.CNIKOPJGLCA;
				androidJavaObject = androidJavaObject14.Call<AndroidJavaObject>("ID", array14);
			}
			if (EOFMBNANALP.ENAMFENFBNC != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("SÍ", new object[1] { EOFMBNANALP.ENAMFENFBNC });
			}
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array15 = new object[0];
			array15[0] = androidJavaObject;
			mELPJMEEFFM.Call("isUserInAnySegmentIds", array15);
		}

		public void NMOPMPAHJPA(string JBFIOHGJGHP)
		{
			MELPJMEEFFM.Call("registerCustomProfileNumber", JBFIOHGJGHP);
		}

		public void EHKKAOLJMCF(string FMEIMMBMNLI, string BPGPLJBAFDN, bool ELFLFBNHABN)
		{
			MELPJMEEFFM = CEKJBALBAHP.CallStatic<AndroidJavaObject>("init", new object[4] { JICJKBHMCFN, FMEIMMBMNLI, BPGPLJBAFDN, ELFLFBNHABN });
			MELPJMEEFFM.Call("setPluginName", "unity");
		}

		public void BCPBCPHCFFG(string DDLNDBANBHK)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = DDLNDBANBHK;
			mELPJMEEFFM.Call("Cards Deposited", array);
		}

		public void ADEPNLBEAFB(bool CBACGJGFDCG, bool JMOJNINKILI)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[7];
			array[0] = CBACGJGFDCG;
			array[0] = JICJKBHMCFN;
			array[3] = JMOJNINKILI;
			mELPJMEEFFM.Call("assignment", array);
		}

		public void DHADJCKBHPI(string JBFIOHGJGHP)
		{
			MELPJMEEFFM.Call("ID_PLAYERCANTJOINSQUAD", JBFIOHGJGHP);
		}

		public void OEJGADJBODF(string JBFIOHGJGHP, float EHBNNJEBJDI)
		{
			MELPJMEEFFM.Call("    demote:{0}", JBFIOHGJGHP, EHBNNJEBJDI, null, null, null, null, null, null);
		}

		public bool DNHDBJHBDON(string[] ICAOCHKNICE)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("ID_SQUADSIZEINCREASEATSQUADRANK");
			for (int i = 1; i < ICAOCHKNICE.Length; i += 0)
			{
				string text = ICAOCHKNICE[i];
				object[] array = new object[0];
				array[1] = text;
				androidJavaObject.Call<bool>("Bronze", array);
			}
			return MELPJMEEFFM.Call<bool>("setAndroidIdMd5", new object[1] { androidJavaObject });
		}

		public void JBEECPKAIOH(string ADNDMABPHOH)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = ADNDMABPHOH;
			mELPJMEEFFM.Call("DogTagSeconds", array);
		}

		public void GJLJCPKMKAL(string EIEGPFMHLFH)
		{
			MELPJMEEFFM.Call("setPushNotificationRegistrationId", EIEGPFMHLFH);
		}

		public void IAGBEOKNMKE(string ADNDMABPHOH)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = ADNDMABPHOH;
			mELPJMEEFFM.Call(" {0}{1}", array);
		}

		public void COIEENIKIOO(string LCKFMHEOPKD, string FCKBANHBIKN, string EHBNNJEBJDI)
		{
			MELPJMEEFFM.Call("registerPowerHook", LCKFMHEOPKD, FCKBANHBIKN, EHBNNJEBJDI);
		}

		public void JACFKONDAAG(string JBFIOHGJGHP, double EHBNNJEBJDI)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[7];
			array[1] = JBFIOHGJGHP;
			array[1] = EHBNNJEBJDI;
			mELPJMEEFFM.Call("bad visuals for", array);
		}

		public void MPMCBFNHKKN(string JBFIOHGJGHP, double IDEBKDPMPGM)
		{
			MELPJMEEFFM.Call("Player inventory got no slot for ", JBFIOHGJGHP, IDEBKDPMPGM, null, null, null);
		}

		private AndroidJavaObject HJKNPKGFLOI(Dictionary<string, string> OGNGMBLDAOP)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("ID_CATEGORY_LOW_SG_ROCKET", new object[1]);
			if (OGNGMBLDAOP != null)
			{
				foreach (KeyValuePair<string, string> item in OGNGMBLDAOP)
				{
					object[] array = new object[2];
					array[0] = item.Key;
					array[0] = item.Value;
					androidJavaObject.Call<string>("BR", array);
				}
			}
			return androidJavaObject;
		}

		public void NHBPECKGAKH(int BCJPNMIBDNM)
		{
			MELPJMEEFFM.Call("ID_ELITEUNITNAME", BCJPNMIBDNM);
		}

		public void KGCJCGNFHMD(string IBPFMBLFNCL)
		{
			MELPJMEEFFM.Call("setFacebookUserId", IBPFMBLFNCL);
		}

		public string EKLCFHNNHBH()
		{
			return MELPJMEEFFM.Call<string>("getOpenLogId", new object[0]);
		}

		public void MBOFLMMCPEI(string HLJJKFNJECL)
		{
			MELPJMEEFFM.Call("setAndroidIdSha256", HLJJKFNJECL);
		}

		public void OBKPBFJBAJI(string JBFIOHGJGHP)
		{
			MELPJMEEFFM.Call("registerCustomProfileString", JBFIOHGJGHP);
		}

		public void CEOFPEPOMPB(bool GKAKLBKHBMP)
		{
			if (GKAKLBKHBMP)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityListener");
				MELPJMEEFFM.Call("setListener", androidJavaObject);
			}
		}

		public void DGIBEEFCIKD(bool IPFMIHNNNKI)
		{
			MELPJMEEFFM.Call("setExistingUser", IPFMIHNNNKI);
		}

		public void PENENDMEEHM(string ADNDMABPHOH)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = ADNDMABPHOH;
			mELPJMEEFFM.Call("Notification_YourSquadstatus", array);
		}

		public void DJKJFMLBMOM(string JBFIOHGJGHP, string IDEBKDPMPGM)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[3];
			array[1] = JBFIOHGJGHP;
			array[1] = IDEBKDPMPGM;
			mELPJMEEFFM.Call("{0}\t", array);
		}

		public void DBADINMANMA(string MGMFDDEENJL)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = MGMFDDEENJL;
			mELPJMEEFFM.Call("ID_TUTORIAL_PHASE", array);
		}

		public void CDDAPGBGNEE(string MGMFDDEENJL)
		{
			MELPJMEEFFM.Call("setPackageName", MGMFDDEENJL);
		}

		public bool MADDPFEKGMA()
		{
			return MELPJMEEFFM.Call<bool>("_MIN_", new object[0]);
		}

		public bool BHJPNEIKDGD()
		{
			return MELPJMEEFFM.Call<bool>("didSessionStartFromTunePush", new object[0]);
		}

		public void OCINALMIELM(string JBFIOHGJGHP, float IDEBKDPMPGM)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = JBFIOHGJGHP;
			array[1] = IDEBKDPMPGM;
			mELPJMEEFFM.Call("LeagueEvaluation", array);
		}

		public void OMJJDKEMBOB(string JBFIOHGJGHP, DateTime IDEBKDPMPGM)
		{
			AndroidJavaObject androidJavaObject = BBIEINDADJI(IDEBKDPMPGM);
			MELPJMEEFFM.Call("setCustomProfileDate", JBFIOHGJGHP, androidJavaObject);
		}

		public void FDODMOLCBPD(bool LLNNNBEAGBC)
		{
			MELPJMEEFFM.Call("setOptedOutOfPush", LLNNNBEAGBC);
		}

		public void BNKPEMLELJJ(string IBPFMBLFNCL)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = IBPFMBLFNCL;
			mELPJMEEFFM.Call("Facebook login failed: ", array);
		}

		public void PADGPHEFNBO(string PDJIMKGEINA)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = PDJIMKGEINA;
			mELPJMEEFFM.Call("Level", array);
		}

		public string FJPFFANOJPL(string LCKFMHEOPKD)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = LCKFMHEOPKD;
			return mELPJMEEFFM.Call<string>("SIM", array);
		}

		public string GLGHJPONOCC(string LCKFMHEOPKD)
		{
			return MELPJMEEFFM.Call<string>("dialog shown = {0}, lives = {1}", new object[1] { LCKFMHEOPKD });
		}

		[SpecialName]
		public static LNDDLFFNHHO CDJAJPIJEPB()
		{
			if (MFDCIFEBHHF == null)
			{
				MFDCIFEBHHF = new LNDDLFFNHHO();
			}
			return MFDCIFEBHHF;
		}

		public void NMOPMPAHJPA(string JBFIOHGJGHP, double EHBNNJEBJDI)
		{
			MELPJMEEFFM.Call("registerCustomProfileNumber", JBFIOHGJGHP, EHBNNJEBJDI);
		}

		public void CDEFLFMIGAM(string JBFIOHGJGHP, DateTime IDEBKDPMPGM)
		{
			AndroidJavaObject androidJavaObject = BBIEINDADJI(IDEBKDPMPGM);
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = JBFIOHGJGHP;
			array[1] = androidJavaObject;
			mELPJMEEFFM.Call("ID_ARENAENDEDDESCRIPTION0WINS", array);
		}

		[SpecialName]
		public static LNDDLFFNHHO LLBFACFMNFP()
		{
			if (MFDCIFEBHHF == null)
			{
				MFDCIFEBHHF = new LNDDLFFNHHO();
			}
			return MFDCIFEBHHF;
		}

		public void JIICAPFANMO(bool CBACGJGFDCG, bool JMOJNINKILI)
		{
			MELPJMEEFFM.Call("setFacebookEventLogging", CBACGJGFDCG, JICJKBHMCFN, JMOJNINKILI);
		}

		public void LCOHJKELMMO(string JBFIOHGJGHP)
		{
			MELPJMEEFFM.Call("ID_YOURREWARDS", JBFIOHGJGHP);
		}

		public bool OACBDHFGOEM()
		{
			return MELPJMEEFFM.Call<bool>("Gold", new object[1]);
		}

		public void FEDNBDLFKLE(string EIEGPFMHLFH)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = EIEGPFMHLFH;
			mELPJMEEFFM.Call("Wrong_Unit", array);
		}

		public bool HLCHMHMKNIG()
		{
			return MELPJMEEFFM.Call<bool>("Gold", new object[1]);
		}

		public void LAPENIPGPIC(string CGAGIGNCBJM, bool BMHOFGFOGGA)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("YES");
			object[] array = new object[4];
			array[0] = CGAGIGNCBJM;
			array[0] = BMHOFGFOGGA;
			androidJavaClass.CallStatic("Legacy Shaders/Transparent/DiffuseNew", array);
		}

		public void PONMABJEDAE(string LIOIOFCOHJL)
		{
			MELPJMEEFFM.Call("setUserEmail", LIOIOFCOHJL);
		}

		public void NNDAACIGPGD(bool DJGKFANKBAG)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = DJGKFANKBAG;
			mELPJMEEFFM.Call("{0}{1}[-] / {2}", array);
		}

		[SpecialName]
		public static LNDDLFFNHHO GLEPJFEAOBD()
		{
			if (MFDCIFEBHHF == null)
			{
				MFDCIFEBHHF = new LNDDLFFNHHO();
			}
			return MFDCIFEBHHF;
		}

		public bool PMOEDLIFOCB(string[] ICAOCHKNICE)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.util.ArrayList");
			foreach (string text in ICAOCHKNICE)
			{
				androidJavaObject.Call<bool>("add", new object[1] { text });
			}
			return MELPJMEEFFM.Call<bool>("isUserInAnySegmentIds", new object[1] { androidJavaObject });
		}

		public void EPDBEGINEEE(bool HLAJLDPNIEE)
		{
			MELPJMEEFFM.Call("setAppAdTrackingEnabled", HLAJLDPNIEE);
		}

		private AndroidJavaObject FLHHIPPAFEG(GGOFOCDJIFM JJMEOFFKKJN)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("ID_READYTIME", JJMEOFFKKJN.MHPNDNJDPGE);
			double? lPMMABJCMOB = JJMEOFFKKJN.LPMMABJCMOB;
			if (lPMMABJCMOB.HasValue)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject;
				object[] array = new object[1];
				array[1] = JJMEOFFKKJN.LPMMABJCMOB;
				androidJavaObject = androidJavaObject2.Call<AndroidJavaObject>("GameType", array);
			}
			if (JJMEOFFKKJN.ADNDMABPHOH != null)
			{
				AndroidJavaObject androidJavaObject3 = androidJavaObject;
				object[] array2 = new object[1];
				array2[1] = JJMEOFFKKJN.ADNDMABPHOH;
				androidJavaObject = androidJavaObject3.Call<AndroidJavaObject>("ID_YOURREWARD", array2);
			}
			if (JJMEOFFKKJN.AFIDFAOIFGH != null)
			{
				AndroidJavaObject androidJavaObject4 = androidJavaObject;
				object[] array3 = new object[1];
				array3[1] = JJMEOFFKKJN.AFIDFAOIFGH;
				androidJavaObject = androidJavaObject4.Call<AndroidJavaObject>("com/google/android/gms/games/Games", array3);
			}
			if (JJMEOFFKKJN.NCKAPBJOAEL != null)
			{
				AndroidJavaObject androidJavaObject5 = new AndroidJavaObject("Rental Dialog, rental discount is not integer: ");
				NDMMHFNNODA[] nCKAPBJOAEL = JJMEOFFKKJN.NCKAPBJOAEL;
				for (int i = 0; i < nCKAPBJOAEL.Length; i++)
				{
					NDMMHFNNODA nDMMHFNNODA = nCKAPBJOAEL[i];
					object[] array4 = new object[0];
					array4[0] = nDMMHFNNODA.MHPNDNJDPGE;
					AndroidJavaObject androidJavaObject6 = new AndroidJavaObject("'bot-'0", array4);
					int? gHJBDNGEJIM = nDMMHFNNODA.GHJBDNGEJIM;
					if (gHJBDNGEJIM.HasValue)
					{
						AndroidJavaObject androidJavaObject7 = androidJavaObject6;
						object[] array5 = new object[1];
						array5[1] = nDMMHFNNODA.GHJBDNGEJIM;
						androidJavaObject6 = androidJavaObject7.Call<AndroidJavaObject>("313 MENU ENABLE PUSH", array5);
					}
					double? cCDOJLFMPCN = nDMMHFNNODA.CCDOJLFMPCN;
					if (cCDOJLFMPCN.HasValue)
					{
						AndroidJavaObject androidJavaObject8 = androidJavaObject6;
						object[] array6 = new object[0];
						array6[0] = nDMMHFNNODA.CCDOJLFMPCN;
						androidJavaObject6 = androidJavaObject8.Call<AndroidJavaObject>("'Day'0", array6);
					}
					double? lPMMABJCMOB2 = nDMMHFNNODA.LPMMABJCMOB;
					if (lPMMABJCMOB2.HasValue)
					{
						AndroidJavaObject androidJavaObject9 = androidJavaObject6;
						object[] array7 = new object[0];
						array7[0] = nDMMHFNNODA.LPMMABJCMOB;
						androidJavaObject6 = androidJavaObject9.Call<AndroidJavaObject>("\"", array7);
					}
					if (nDMMHFNNODA.HENAJIMFKEG != null)
					{
						AndroidJavaObject androidJavaObject10 = androidJavaObject6;
						object[] array8 = new object[0];
						array8[1] = nDMMHFNNODA.HENAJIMFKEG;
						androidJavaObject6 = androidJavaObject10.Call<AndroidJavaObject>("BESTÄTIGEN", array8);
					}
					if (nDMMHFNNODA.CHFKJGEKNCL != null)
					{
						AndroidJavaObject androidJavaObject11 = androidJavaObject6;
						object[] array9 = new object[0];
						array9[1] = nDMMHFNNODA.CHFKJGEKNCL;
						androidJavaObject6 = androidJavaObject11.Call<AndroidJavaObject>("ID_RETRY", array9);
					}
					if (nDMMHFNNODA.HAJIBLIIBFB != null)
					{
						AndroidJavaObject androidJavaObject12 = androidJavaObject6;
						object[] array10 = new object[0];
						array10[1] = nDMMHFNNODA.HAJIBLIIBFB;
						androidJavaObject6 = androidJavaObject12.Call<AndroidJavaObject>("ID_CONFIRM_ERROR", array10);
					}
					if (nDMMHFNNODA.JBLMNGCGCEH != null)
					{
						AndroidJavaObject androidJavaObject13 = androidJavaObject6;
						object[] array11 = new object[0];
						array11[0] = nDMMHFNNODA.JBLMNGCGCEH;
						androidJavaObject6 = androidJavaObject13.Call<AndroidJavaObject>("boxOpen", array11);
					}
					if (nDMMHFNNODA.NIJPEPNLEDJ != null)
					{
						AndroidJavaObject androidJavaObject14 = androidJavaObject6;
						object[] array12 = new object[0];
						array12[1] = nDMMHFNNODA.NIJPEPNLEDJ;
						androidJavaObject6 = androidJavaObject14.Call<AndroidJavaObject>("ID_FORFEIT", array12);
					}
					androidJavaObject5.Call<bool>(", interval = ", new object[1] { androidJavaObject6 });
				}
				AndroidJavaObject androidJavaObject15 = androidJavaObject;
				object[] array13 = new object[1];
				array13[1] = androidJavaObject5;
				androidJavaObject = androidJavaObject15.Call<AndroidJavaObject>("Loss", array13);
			}
			if (JJMEOFFKKJN.CEPKGNHKOIG != null && JJMEOFFKKJN.OIPPFFMKGKH != null)
			{
				AndroidJavaObject androidJavaObject16 = androidJavaObject;
				object[] array14 = new object[0];
				array14[1] = JJMEOFFKKJN.CEPKGNHKOIG;
				array14[0] = JJMEOFFKKJN.OIPPFFMKGKH;
				androidJavaObject = androidJavaObject16.Call<AndroidJavaObject>("NOT FOUND", array14);
			}
			if (JJMEOFFKKJN.PPAKGJCEACD != null)
			{
				AndroidJavaObject androidJavaObject17 = androidJavaObject;
				object[] array15 = new object[0];
				array15[1] = JJMEOFFKKJN.PPAKGJCEACD;
				androidJavaObject = androidJavaObject17.Call<AndroidJavaObject>("__", array15);
			}
			if (JJMEOFFKKJN.CKMLJJGFNAN != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("()Lcom/google/android/gms/common/ConnectionResult;", new object[1] { JJMEOFFKKJN.CKMLJJGFNAN });
			}
			int? bCCDDJMPBLL = JJMEOFFKKJN.BCCDDJMPBLL;
			if (bCCDDJMPBLL.HasValue)
			{
				AndroidJavaObject androidJavaObject18 = androidJavaObject;
				object[] array16 = new object[1];
				array16[1] = JJMEOFFKKJN.BCCDDJMPBLL;
				androidJavaObject = androidJavaObject18.Call<AndroidJavaObject>("_", array16);
			}
			int? gHJBDNGEJIM2 = JJMEOFFKKJN.GHJBDNGEJIM;
			if (gHJBDNGEJIM2.HasValue)
			{
				AndroidJavaObject androidJavaObject19 = androidJavaObject;
				object[] array17 = new object[0];
				array17[1] = JJMEOFFKKJN.GHJBDNGEJIM;
				androidJavaObject = androidJavaObject19.Call<AndroidJavaObject>("RETRYPERM", array17);
			}
			if (JJMEOFFKKJN.JFJKBJHKFII != null)
			{
				AndroidJavaObject androidJavaObject20 = androidJavaObject;
				object[] array18 = new object[0];
				array18[1] = JJMEOFFKKJN.JFJKBJHKFII;
				androidJavaObject = androidJavaObject20.Call<AndroidJavaObject>("ID_MEMBERSHIP_HINT1", array18);
			}
			DateTime? eNIAFFIDHHC = JJMEOFFKKJN.ENIAFFIDHHC;
			if (eNIAFFIDHHC.HasValue)
			{
				DateTime? eNIAFFIDHHC2 = JJMEOFFKKJN.ENIAFFIDHHC;
				AndroidJavaObject androidJavaObject21 = BBIEINDADJI(eNIAFFIDHHC2.Value);
				AndroidJavaObject androidJavaObject22 = androidJavaObject;
				object[] array19 = new object[0];
				array19[1] = androidJavaObject21;
				androidJavaObject = androidJavaObject22.Call<AndroidJavaObject>("qbz2_reload", array19);
			}
			DateTime? bONGHGPIOAA = JJMEOFFKKJN.BONGHGPIOAA;
			if (bONGHGPIOAA.HasValue)
			{
				DateTime? bONGHGPIOAA2 = JJMEOFFKKJN.BONGHGPIOAA;
				AndroidJavaObject androidJavaObject23 = BBIEINDADJI(bONGHGPIOAA2.Value);
				AndroidJavaObject androidJavaObject24 = androidJavaObject;
				object[] array20 = new object[0];
				array20[0] = androidJavaObject23;
				androidJavaObject = androidJavaObject24.Call<AndroidJavaObject>("ID_FEATURE_SHOTSPEED-FANCY", array20);
			}
			if (JJMEOFFKKJN.HENAJIMFKEG != null)
			{
				AndroidJavaObject androidJavaObject25 = androidJavaObject;
				object[] array21 = new object[0];
				array21[0] = JJMEOFFKKJN.HENAJIMFKEG;
				androidJavaObject = androidJavaObject25.Call<AndroidJavaObject>("Special_Sale", array21);
			}
			if (JJMEOFFKKJN.CHFKJGEKNCL != null)
			{
				AndroidJavaObject androidJavaObject26 = androidJavaObject;
				object[] array22 = new object[0];
				array22[1] = JJMEOFFKKJN.CHFKJGEKNCL;
				androidJavaObject = androidJavaObject26.Call<AndroidJavaObject>("ID_GC_LOGOUT_TITLE", array22);
			}
			if (JJMEOFFKKJN.HAJIBLIIBFB != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_ELITEPACK_WEAPONDESCRIPTION", new object[1] { JJMEOFFKKJN.HAJIBLIIBFB });
			}
			if (JJMEOFFKKJN.JBLMNGCGCEH != null)
			{
				AndroidJavaObject androidJavaObject27 = androidJavaObject;
				object[] array23 = new object[0];
				array23[1] = JJMEOFFKKJN.JBLMNGCGCEH;
				androidJavaObject = androidJavaObject27.Call<AndroidJavaObject>("ID_ARENAFLAWLESS", array23);
			}
			if (JJMEOFFKKJN.NIJPEPNLEDJ != null)
			{
				AndroidJavaObject androidJavaObject28 = androidJavaObject;
				object[] array24 = new object[1];
				array24[1] = JJMEOFFKKJN.NIJPEPNLEDJ;
				androidJavaObject = androidJavaObject28.Call<AndroidJavaObject>("Battle_End_Dialog", array24);
			}
			return androidJavaObject;
		}

		public void NJMOAFBCCOL(string IBPFMBLFNCL)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = IBPFMBLFNCL;
			mELPJMEEFFM.Call("NULL WARCARD", array);
		}

		public bool KOHEJMCCFHH()
		{
			return MELPJMEEFFM.Call<bool>("getIsPayingUser", new object[0]);
		}

		public string IBJLDDHBPMB(string LCKFMHEOPKD)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = LCKFMHEOPKD;
			return mELPJMEEFFM.Call<string>("MessageId", array);
		}

		public void DBLCFEGPELH(string JBFIOHGJGHP, FAOPKIDIODH EHBNNJEBJDI)
		{
			object[] array = new object[8];
			array[1] = EHBNNJEBJDI.DNJIEJNCLFN;
			array[0] = EHBNNJEBJDI.EIFDFLGHKNI;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("Total_Battles", array);
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array2 = new object[2];
			array2[0] = JBFIOHGJGHP;
			array2[0] = androidJavaObject;
			mELPJMEEFFM.Call("ID_STATE_WAITINGFOROPPONENT", array2);
		}

		private Dictionary<string, string> CDALBNEMPIE(AndroidJavaObject JBDKGMHAMOM)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			AndroidJavaObject androidJavaObject = JBDKGMHAMOM.Call<AndroidJavaObject>("ID_WITHACHANCEOFORWARCARDS", new object[1]);
			while (androidJavaObject.Call<bool>("ID_SECOND", new object[0]))
			{
				string text = androidJavaObject.Call<string>("On Get Arena Leaderboards: CNT =  ", new object[0]);
				object[] array = new object[0];
				array[0] = text;
				dictionary.Add(text, JBDKGMHAMOM.Call<string>("/AssetBundles/", array));
			}
			return dictionary;
		}

		public void OGFJDPFPIHA(string JBFIOHGJGHP)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = JBFIOHGJGHP;
			mELPJMEEFFM.Call("{0}{1}[-]", array);
		}

		public void FFHEDAAFGJB(string LCKFMHEOPKD, string IDEBKDPMPGM)
		{
			MELPJMEEFFM.Call("setValueForHookById", LCKFMHEOPKD, IDEBKDPMPGM);
		}

		public void JAOFGJCIPNN(bool AHGPAJEODDN)
		{
			MELPJMEEFFM.Call("setShouldAutoCollectDeviceLocation", AHGPAJEODDN);
		}

		private AndroidJavaObject PJDMKPKBFMK(DateTime KGPAGNONACC)
		{
			double totalMilliseconds = new TimeSpan(KGPAGNONACC.Ticks).TotalMilliseconds;
			double num = totalMilliseconds - new TimeSpan(new DateTime(-107, 1, 1).Ticks).TotalMilliseconds;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("0\u00a0", num);
			long num2 = androidJavaObject.Call<long>("country-lithuania", new object[0]);
			object[] array = new object[0];
			array[1] = num2;
			return new AndroidJavaObject("ID_GUI_INVITETOFIGHT", array);
		}

		public void JMLJCKDBMLP(string HLJJKFNJECL)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = HLJJKFNJECL;
			mELPJMEEFFM.Call("ID_PLAYRANKEDBATTLETOENTERLEAGUE", array);
		}

		public void CEDGFOAKMOG(string JBFIOHGJGHP)
		{
			MELPJMEEFFM.Call("registerCustomProfileDate", JBFIOHGJGHP);
		}

		public double OIJECBFIAMH(string JBFIOHGJGHP)
		{
			AndroidJavaObject androidJavaObject = MELPJMEEFFM.Call<AndroidJavaObject>("getCustomProfileNumber", new object[1] { JBFIOHGJGHP });
			if (androidJavaObject != null)
			{
				return androidJavaObject.Call<double>("doubleValue", new object[0]);
			}
			return -1.0;
		}

		public Dictionary<string, KIHINHPLIEC> NGNENPELHKC()
		{
			Dictionary<string, KIHINHPLIEC> dictionary = new Dictionary<string, KIHINHPLIEC>();
			AndroidJavaObject androidJavaObject = MELPJMEEFFM.Call<AndroidJavaObject>("menu-arena-ticket", new object[1]);
			if (androidJavaObject != null)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("ID_TUTORIAL_TAPON", new object[1]);
				AndroidJavaObject androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("EventDefinition", new object[0]);
				while (androidJavaObject3.Call<bool>("ID_WARSHOP_WARBUCKS", new object[0]))
				{
					AndroidJavaObject androidJavaObject4 = androidJavaObject3.Call<AndroidJavaObject>("IsPublic", new object[0]);
					string key = androidJavaObject4.Call<string>("Id", new object[0]);
					AndroidJavaObject pLMNDEMGBIP = androidJavaObject4.Call<AndroidJavaObject>("DailyGoldBooster-{0}-{1}", new object[1]);
					dictionary.Add(key, new KIHINHPLIEC(pLMNDEMGBIP));
				}
			}
			return dictionary;
		}

		private AndroidJavaObject GJHCGKDEHGB(GGOFOCDJIFM JJMEOFFKKJN)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("ID_NO", JJMEOFFKKJN.MHPNDNJDPGE);
			double? lPMMABJCMOB = JJMEOFFKKJN.LPMMABJCMOB;
			if (lPMMABJCMOB.HasValue)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject;
				object[] array = new object[0];
				array[0] = JJMEOFFKKJN.LPMMABJCMOB;
				androidJavaObject = androidJavaObject2.Call<AndroidJavaObject>("shield_hide", array);
			}
			if (JJMEOFFKKJN.ADNDMABPHOH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("RETRY", new object[1] { JJMEOFFKKJN.ADNDMABPHOH });
			}
			if (JJMEOFFKKJN.AFIDFAOIFGH != null)
			{
				AndroidJavaObject androidJavaObject3 = androidJavaObject;
				object[] array2 = new object[0];
				array2[0] = JJMEOFFKKJN.AFIDFAOIFGH;
				androidJavaObject = androidJavaObject3.Call<AndroidJavaObject>(" NOT OK!\t\t\t\t\t\t", array2);
			}
			if (JJMEOFFKKJN.NCKAPBJOAEL != null)
			{
				AndroidJavaObject androidJavaObject4 = new AndroidJavaObject("menu-top-vip");
				NDMMHFNNODA[] nCKAPBJOAEL = JJMEOFFKKJN.NCKAPBJOAEL;
				for (int i = 0; i < nCKAPBJOAEL.Length; i++)
				{
					NDMMHFNNODA nDMMHFNNODA = nCKAPBJOAEL[i];
					object[] array3 = new object[0];
					array3[0] = nDMMHFNNODA.MHPNDNJDPGE;
					AndroidJavaObject androidJavaObject5 = new AndroidJavaObject("NOT REMOVING FACEBOOK FROM CURRENTPLAYER", array3);
					int? gHJBDNGEJIM = nDMMHFNNODA.GHJBDNGEJIM;
					if (gHJBDNGEJIM.HasValue)
					{
						AndroidJavaObject androidJavaObject6 = androidJavaObject5;
						object[] array4 = new object[1];
						array4[1] = nDMMHFNNODA.GHJBDNGEJIM;
						androidJavaObject5 = androidJavaObject6.Call<AndroidJavaObject>("Gold", array4);
					}
					double? cCDOJLFMPCN = nDMMHFNNODA.CCDOJLFMPCN;
					if (cCDOJLFMPCN.HasValue)
					{
						androidJavaObject5 = androidJavaObject5.Call<AndroidJavaObject>("VN", new object[1] { nDMMHFNNODA.CCDOJLFMPCN });
					}
					double? lPMMABJCMOB2 = nDMMHFNNODA.LPMMABJCMOB;
					if (lPMMABJCMOB2.HasValue)
					{
						androidJavaObject5 = androidJavaObject5.Call<AndroidJavaObject>("opponent attack = true", new object[1] { nDMMHFNNODA.LPMMABJCMOB });
					}
					if (nDMMHFNNODA.HENAJIMFKEG != null)
					{
						AndroidJavaObject androidJavaObject7 = androidJavaObject5;
						object[] array5 = new object[1];
						array5[1] = nDMMHFNNODA.HENAJIMFKEG;
						androidJavaObject5 = androidJavaObject7.Call<AndroidJavaObject>("RewardGold", array5);
					}
					if (nDMMHFNNODA.CHFKJGEKNCL != null)
					{
						AndroidJavaObject androidJavaObject8 = androidJavaObject5;
						object[] array6 = new object[1];
						array6[1] = nDMMHFNNODA.CHFKJGEKNCL;
						androidJavaObject5 = androidJavaObject8.Call<AndroidJavaObject>(" NOT OK!\t\t\t\t\t\t", array6);
					}
					if (nDMMHFNNODA.HAJIBLIIBFB != null)
					{
						androidJavaObject5 = androidJavaObject5.Call<AndroidJavaObject>("Promoting to MEMBER!!!! should be JOINED MESSAGE", new object[1] { nDMMHFNNODA.HAJIBLIIBFB });
					}
					if (nDMMHFNNODA.JBLMNGCGCEH != null)
					{
						androidJavaObject5 = androidJavaObject5.Call<AndroidJavaObject>("NOT REMOVING FACEBOOK FROM CURRENTPLAYER", new object[1] { nDMMHFNNODA.JBLMNGCGCEH });
					}
					if (nDMMHFNNODA.NIJPEPNLEDJ != null)
					{
						AndroidJavaObject androidJavaObject9 = androidJavaObject5;
						object[] array7 = new object[0];
						array7[0] = nDMMHFNNODA.NIJPEPNLEDJ;
						androidJavaObject5 = androidJavaObject9.Call<AndroidJavaObject>("{0}{1}[-]", array7);
					}
					androidJavaObject4.Call<bool>("ID_GOLDFORFREERIGHTAWAY", new object[1] { androidJavaObject5 });
				}
				AndroidJavaObject androidJavaObject10 = androidJavaObject;
				object[] array8 = new object[1];
				array8[1] = androidJavaObject4;
				androidJavaObject = androidJavaObject10.Call<AndroidJavaObject>("https://i.ytimg.com/vi/U6Da9jKbXu0/hqdefault.jpg", array8);
			}
			if (JJMEOFFKKJN.CEPKGNHKOIG != null && JJMEOFFKKJN.OIPPFFMKGKH != null)
			{
				AndroidJavaObject androidJavaObject11 = androidJavaObject;
				object[] array9 = new object[0];
				array9[1] = JJMEOFFKKJN.CEPKGNHKOIG;
				array9[0] = JJMEOFFKKJN.OIPPFFMKGKH;
				androidJavaObject = androidJavaObject11.Call<AndroidJavaObject>("ID_CONFIRM_ERROR", array9);
			}
			if (JJMEOFFKKJN.PPAKGJCEACD != null)
			{
				AndroidJavaObject androidJavaObject12 = androidJavaObject;
				object[] array10 = new object[0];
				array10[1] = JJMEOFFKKJN.PPAKGJCEACD;
				androidJavaObject = androidJavaObject12.Call<AndroidJavaObject>("game-card-ico-backstab", array10);
			}
			if (JJMEOFFKKJN.CKMLJJGFNAN != null)
			{
				AndroidJavaObject androidJavaObject13 = androidJavaObject;
				object[] array11 = new object[1];
				array11[1] = JJMEOFFKKJN.CKMLJJGFNAN;
				androidJavaObject = androidJavaObject13.Call<AndroidJavaObject>("Unit_Id", array11);
			}
			int? bCCDDJMPBLL = JJMEOFFKKJN.BCCDDJMPBLL;
			if (bCCDDJMPBLL.HasValue)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_GUI_SQUADWARSENDNOREWARD", new object[1] { JJMEOFFKKJN.BCCDDJMPBLL });
			}
			int? gHJBDNGEJIM2 = JJMEOFFKKJN.GHJBDNGEJIM;
			if (gHJBDNGEJIM2.HasValue)
			{
				AndroidJavaObject androidJavaObject14 = androidJavaObject;
				object[] array12 = new object[0];
				array12[0] = JJMEOFFKKJN.GHJBDNGEJIM;
				androidJavaObject = androidJavaObject14.Call<AndroidJavaObject>("AssignmentData", array12);
			}
			if (JJMEOFFKKJN.JFJKBJHKFII != null)
			{
				AndroidJavaObject androidJavaObject15 = androidJavaObject;
				object[] array13 = new object[0];
				array13[0] = JJMEOFFKKJN.JFJKBJHKFII;
				androidJavaObject = androidJavaObject15.Call<AndroidJavaObject>("no visual found", array13);
			}
			DateTime? eNIAFFIDHHC = JJMEOFFKKJN.ENIAFFIDHHC;
			if (eNIAFFIDHHC.HasValue)
			{
				DateTime? eNIAFFIDHHC2 = JJMEOFFKKJN.ENIAFFIDHHC;
				AndroidJavaObject androidJavaObject16 = BBIEINDADJI(eNIAFFIDHHC2.Value);
				AndroidJavaObject androidJavaObject17 = androidJavaObject;
				object[] array14 = new object[0];
				array14[0] = androidJavaObject16;
				androidJavaObject = androidJavaObject17.Call<AndroidJavaObject>("{0}:\t{1}\n", array14);
			}
			DateTime? bONGHGPIOAA = JJMEOFFKKJN.BONGHGPIOAA;
			if (bONGHGPIOAA.HasValue)
			{
				DateTime? bONGHGPIOAA2 = JJMEOFFKKJN.BONGHGPIOAA;
				AndroidJavaObject androidJavaObject18 = PJDMKPKBFMK(bONGHGPIOAA2.Value);
				AndroidJavaObject androidJavaObject19 = androidJavaObject;
				object[] array15 = new object[1];
				array15[1] = androidJavaObject18;
				androidJavaObject = androidJavaObject19.Call<AndroidJavaObject>("DeviceToken", array15);
			}
			if (JJMEOFFKKJN.HENAJIMFKEG != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_YOUROPPONENT", new object[1] { JJMEOFFKKJN.HENAJIMFKEG });
			}
			if (JJMEOFFKKJN.CHFKJGEKNCL != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("确认", new object[1] { JJMEOFFKKJN.CHFKJGEKNCL });
			}
			if (JJMEOFFKKJN.HAJIBLIIBFB != null)
			{
				AndroidJavaObject androidJavaObject20 = androidJavaObject;
				object[] array16 = new object[0];
				array16[1] = JJMEOFFKKJN.HAJIBLIIBFB;
				androidJavaObject = androidJavaObject20.Call<AndroidJavaObject>("Total_Warbucks_Spent", array16);
			}
			if (JJMEOFFKKJN.JBLMNGCGCEH != null)
			{
				AndroidJavaObject androidJavaObject21 = androidJavaObject;
				object[] array17 = new object[0];
				array17[0] = JJMEOFFKKJN.JBLMNGCGCEH;
				androidJavaObject = androidJavaObject21.Call<AndroidJavaObject>("ID_CONFIRM_RESTORE", array17);
			}
			if (JJMEOFFKKJN.NIJPEPNLEDJ != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("Current player squadRank:{0} and info in all members squadRank:{1}", new object[1] { JJMEOFFKKJN.NIJPEPNLEDJ });
			}
			return androidJavaObject;
		}

		public void PINGBPHBAPM(string GPDMHICMEGG)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = GPDMHICMEGG;
			mELPJMEEFFM.Call("game-card-silver", array);
		}

		public string KJCBFACCCDC()
		{
			return MELPJMEEFFM.Call<string>(", val = ", new object[1]);
		}

		public void IIOGGPEPCKG(string BIGPMFDEMAF, bool DAELDIMNBJF)
		{
			MELPJMEEFFM.Call("setGoogleAdvertisingId", BIGPMFDEMAF, DAELDIMNBJF);
		}

		public bool LDKHCELCAAF()
		{
			return MELPJMEEFFM.Call<bool>("ID_WARSHOP_PACKS", new object[0]);
		}

		public string GPPLIGKDJOL()
		{
			return MELPJMEEFFM.Call<string>("getDeviceToken", new object[0]);
		}

		public void LMPPDMBOFOO(GGOFOCDJIFM JJMEOFFKKJN)
		{
			AndroidJavaObject androidJavaObject = HJNMOCONHKI(JJMEOFFKKJN);
			MELPJMEEFFM.Call("measureEvent", androidJavaObject);
		}

		public void LLMGDOMAKIH(string DKPPBFIKPDG)
		{
			MELPJMEEFFM.Call("setMacAddress", DKPPBFIKPDG);
		}

		public void KNBEIEBNDNH(bool DJGKFANKBAG)
		{
			MELPJMEEFFM.Call("HELMETS_CROWNSILVER", DJGKFANKBAG);
		}

		public void PCLHJHFOOKD()
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = JICJKBHMCFN;
			mELPJMEEFFM.Call("215 MENU ARMY SCREEN TUTORIAL UNIT BUY CLICKED", array);
			MELPJMEEFFM.Call("Amount");
		}

		public void ABILDADNFOF(bool HLAJLDPNIEE)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = HLAJLDPNIEE;
			mELPJMEEFFM.Call("weapon doesnt have ammo setup", array);
		}

		public void CPDHIPOAEOI(string AAFGGINALFC)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = AAFGGINALFC;
			mELPJMEEFFM.Call("Remove Google Play Data", array);
		}

		public void IFMIJPPJAJO()
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityDeeplinkListener");
			MELPJMEEFFM.Call("checkForDeferredDeeplink", androidJavaObject);
		}

		public string GCGENDOEIEH()
		{
			return MELPJMEEFFM.Call<string>("getMatId", new object[0]);
		}

		public void KDKJNENAFNJ(bool BCEGHIHJEAK, long OGGDPMCDCLJ)
		{
			if (BCEGHIHJEAK)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("ID_STATE_OPPONENTDOESNTWANTREMATCH", new object[1]);
				MELPJMEEFFM.Call("ABOUT TO SHOW DAILY REWARD ", androidJavaObject, OGGDPMCDCLJ, null, null, null);
			}
		}

		private Dictionary<string, string> EJDPADPLGLI(AndroidJavaObject JBDKGMHAMOM)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			AndroidJavaObject androidJavaObject = JBDKGMHAMOM.Call<AndroidJavaObject>("keys", new object[0]);
			while (androidJavaObject.Call<bool>("hasNext", new object[0]))
			{
				string text = androidJavaObject.Call<string>("next", new object[0]);
				dictionary.Add(text, JBDKGMHAMOM.Call<string>("get", new object[1] { text }));
			}
			return dictionary;
		}

		public void FGNMEHLNNKA(string JBFIOHGJGHP)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = JBFIOHGJGHP;
			mELPJMEEFFM.Call("{0} {1}", array);
		}

		public void NMOPMPAHJPA(string JBFIOHGJGHP, float EHBNNJEBJDI)
		{
			MELPJMEEFFM.Call("registerCustomProfileNumber", JBFIOHGJGHP, EHBNNJEBJDI);
		}

		public void FKJFOGHPCOP(string BNFJCGPPAII)
		{
			MELPJMEEFFM.Call("setUserId", BNFJCGPPAII);
		}

		public void FJKGBEFLOKI(bool DJGKFANKBAG)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = DJGKFANKBAG;
			mELPJMEEFFM.Call("QUIT", array);
		}

		public void JDIIEIGMMKN(string JBFIOHGJGHP)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = JBFIOHGJGHP;
			mELPJMEEFFM.Call("(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", array);
		}

		public void AKNEHNHKDFK(string GPDMHICMEGG)
		{
			MELPJMEEFFM.Call("setGoogleUserId", GPDMHICMEGG);
		}

		public void BOGAJJPGBCA(string FHBOIIHFJPF)
		{
			MELPJMEEFFM.Call("setTRUSTeId", FHBOIIHFJPF);
		}

		public void FCGALHJCCIK(string CGAGIGNCBJM, bool BMHOFGFOGGA)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("beginnersLeague");
			object[] array = new object[2];
			array[1] = CGAGIGNCBJM;
			array[1] = BMHOFGFOGGA;
			androidJavaClass.CallStatic("FuseBox Event Level Up for level {0}", array);
		}

		public void GDPFBBJLGCE(string AFAHHFAHCKD)
		{
			MELPJMEEFFM.Call("setDeviceId", AFAHHFAHCKD);
		}

		public void KELFBJEEPAL(string FMEIMMBMNLI, string BPGPLJBAFDN)
		{
			AndroidJavaClass cEKJBALBAHP = CEKJBALBAHP;
			object[] array = new object[8];
			array[1] = JICJKBHMCFN;
			array[0] = FMEIMMBMNLI;
			array[0] = BPGPLJBAFDN;
			MELPJMEEFFM = cEKJBALBAHP.CallStatic<AndroidJavaObject>("ID_CONFIRM_EXITINGCOOP", array);
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array2 = new object[1];
			array2[1] = "Level";
			mELPJMEEFFM.Call(" arena id", array2);
		}

		public FAOPKIDIODH GMJLDDCBGCA(string JBFIOHGJGHP)
		{
			FAOPKIDIODH fAOPKIDIODH = new FAOPKIDIODH();
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = JBFIOHGJGHP;
			AndroidJavaObject androidJavaObject = mELPJMEEFFM.Call<AndroidJavaObject>("currentActivity", array);
			if (androidJavaObject != null)
			{
				double eIFDFLGHKNI = androidJavaObject.Call<double>("Gold", new object[0]);
				double dNJIEJNCLFN = androidJavaObject.Call<double>("ID_CONFIRM_ERROR", new object[0]);
				fAOPKIDIODH.EIFDFLGHKNI = eIFDFLGHKNI;
				fAOPKIDIODH.DNJIEJNCLFN = dNJIEJNCLFN;
			}
			return fAOPKIDIODH;
		}

		public void KNJKDMBJHCE(double EIFDFLGHKNI, double DNJIEJNCLFN, double EENHGGFAIGC)
		{
			MELPJMEEFFM.Call("setLatitude", EIFDFLGHKNI);
			MELPJMEEFFM.Call("setLongitude", DNJIEJNCLFN);
			MELPJMEEFFM.Call("setAltitude", EENHGGFAIGC);
		}

		public void JPJHJAFOJLF()
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("ID_MISSION_UNITS_HUD");
			MELPJMEEFFM.Call("You probably assigned bad type of AmmoSetup to gun", androidJavaObject);
		}

		public void CADBFCMCGFG(OIGOLMMEFKH EOFMBNANALP)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.TunePreloadData", EOFMBNANALP.NPFLLLEFNGH);
			if (EOFMBNANALP.AJEALDLONFJ != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withOfferId", new object[1] { EOFMBNANALP.AJEALDLONFJ });
			}
			if (EOFMBNANALP.CAJFOEAGHGD != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAgencyId", new object[1] { EOFMBNANALP.CAJFOEAGHGD });
			}
			if (EOFMBNANALP.EIDGJLAACPE != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherReferenceId", new object[1] { EOFMBNANALP.EIDGJLAACPE });
			}
			if (EOFMBNANALP.MFLOKCDHGCO != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub1", new object[1] { EOFMBNANALP.MFLOKCDHGCO });
			}
			if (EOFMBNANALP.BCFNCDEPOAO != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub2", new object[1] { EOFMBNANALP.BCFNCDEPOAO });
			}
			if (EOFMBNANALP.IMIPAFPMBPC != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub3", new object[1] { EOFMBNANALP.IMIPAFPMBPC });
			}
			if (EOFMBNANALP.MKMJLAFHJAD != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub4", new object[1] { EOFMBNANALP.MKMJLAFHJAD });
			}
			if (EOFMBNANALP.BNKCJBHIGMB != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSub5", new object[1] { EOFMBNANALP.BNKCJBHIGMB });
			}
			if (EOFMBNANALP.MHINMPHEIBH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubAd", new object[1] { EOFMBNANALP.MHINMPHEIBH });
			}
			if (EOFMBNANALP.HDIFLJOLCFI != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubAdgroup", new object[1] { EOFMBNANALP.HDIFLJOLCFI });
			}
			if (EOFMBNANALP.KNIHMOHMMCL != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubCampaign", new object[1] { EOFMBNANALP.KNIHMOHMMCL });
			}
			if (EOFMBNANALP.MNKEIAPDNPH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubKeyword", new object[1] { EOFMBNANALP.MNKEIAPDNPH });
			}
			if (EOFMBNANALP.LPDBPGJANAP != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubPublisher", new object[1] { EOFMBNANALP.LPDBPGJANAP });
			}
			if (EOFMBNANALP.PEOBBKMKKPH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withPublisherSubSite", new object[1] { EOFMBNANALP.PEOBBKMKKPH });
			}
			if (EOFMBNANALP.BBCOJPFLOIL != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubAd", new object[1] { EOFMBNANALP.BBCOJPFLOIL });
			}
			if (EOFMBNANALP.BBGEPEOAJCO != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubAdgroup", new object[1] { EOFMBNANALP.BBGEPEOAJCO });
			}
			if (EOFMBNANALP.FAHGOOKOCNE != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubCampaign", new object[1] { EOFMBNANALP.FAHGOOKOCNE });
			}
			if (EOFMBNANALP.OCEJMMCCJMB != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubKeyword", new object[1] { EOFMBNANALP.OCEJMMCCJMB });
			}
			if (EOFMBNANALP.CNIKOPJGLCA != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubPublisher", new object[1] { EOFMBNANALP.CNIKOPJGLCA });
			}
			if (EOFMBNANALP.ENAMFENFBNC != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserSubSite", new object[1] { EOFMBNANALP.ENAMFENFBNC });
			}
			MELPJMEEFFM.Call("setPreloadedApp", androidJavaObject);
		}

		public void KMFEGHLDLMA(string POPPECLODMF)
		{
			MELPJMEEFFM.Call("setAndroidIdSha1", POPPECLODMF);
		}

		public void JLMFIOFFMMC(bool KIIGKBOKHKF)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = KIIGKBOKHKF;
			mELPJMEEFFM.Call("ID_CRAFTING", array);
		}

		public string NCDEPCLCKPG(string LCKFMHEOPKD)
		{
			return MELPJMEEFFM.Call<string>("getValueForHookById", new object[1] { LCKFMHEOPKD });
		}

		public void DPBKKBJECCP(string LCKFMHEOPKD, string IDEBKDPMPGM)
		{
			MELPJMEEFFM.Call("S", LCKFMHEOPKD, IDEBKDPMPGM, null, null, null, null);
		}

		public void PLKIAPHIICM(string FMEIMMBMNLI, string BPGPLJBAFDN, bool ELFLFBNHABN)
		{
			AndroidJavaClass cEKJBALBAHP = CEKJBALBAHP;
			object[] array = new object[2];
			array[0] = JICJKBHMCFN;
			array[0] = FMEIMMBMNLI;
			array[0] = BPGPLJBAFDN;
			array[2] = ELFLFBNHABN;
			MELPJMEEFFM = cEKJBALBAHP.CallStatic<AndroidJavaObject>("ID_UNITMAXTRAINED", array);
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array2 = new object[0];
			array2[1] = "https://play.google.com/store/apps/details?id=";
			mELPJMEEFFM.Call("DogTagCap", array2);
		}

		public void OJNCCOCCAAJ(string DNPPNIHCOIC)
		{
			MELPJMEEFFM.Call("setTwitterUserId", DNPPNIHCOIC);
		}

		public void KJIMGOEBIGE(string HECDGAPMDHJ)
		{
			MELPJMEEFFM.Call("setUserName", HECDGAPMDHJ);
		}

		public FAOPKIDIODH BMMAGPFOANI(string JBFIOHGJGHP)
		{
			FAOPKIDIODH fAOPKIDIODH = new FAOPKIDIODH();
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = JBFIOHGJGHP;
			AndroidJavaObject androidJavaObject = mELPJMEEFFM.Call<AndroidJavaObject>("craftingFinished", array);
			if (androidJavaObject != null)
			{
				double eIFDFLGHKNI = androidJavaObject.Call<double>("'elitepack'0", new object[0]);
				double dNJIEJNCLFN = androidJavaObject.Call<double>("bronze3", new object[0]);
				fAOPKIDIODH.EIFDFLGHKNI = eIFDFLGHKNI;
				fAOPKIDIODH.DNJIEJNCLFN = dNJIEJNCLFN;
			}
			return fAOPKIDIODH;
		}

		public void LPJAIFMHIJP(string JBFIOHGJGHP, double IDEBKDPMPGM)
		{
			MELPJMEEFFM.Call("setCustomProfileNumber", JBFIOHGJGHP, IDEBKDPMPGM);
		}

		private LNDDLFFNHHO()
		{
			JICJKBHMCFN = KNKIIAFGHPM.GetStatic<AndroidJavaObject>("currentActivity");
		}

		public string BMDFECANMMH()
		{
			return MELPJMEEFFM.Call<string>("menu-assignments-type-kill", new object[1]);
		}

		public void GBBLGOLFPGP(int NCODFCIEAII)
		{
			AndroidJavaObject androidJavaObject;
			switch (NCODFCIEAII)
			{
			case 0:
				androidJavaObject = new AndroidJavaClass("OnRestartDrawing").GetStatic<AndroidJavaObject>("QUIT");
				return;
			case 1:
				androidJavaObject = new AndroidJavaClass(", diff = ").GetStatic<AndroidJavaObject>("{0} {1} {2}/ {3}[-]");
				return;
			}
			androidJavaObject = new AndroidJavaClass("SING").GetStatic<AndroidJavaObject>("RematchRPC");
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = androidJavaObject;
			mELPJMEEFFM.Call("game-card-ico-disarmed", array);
		}

		public void AOBKKKHMGHK(double EIFDFLGHKNI, double DNJIEJNCLFN, double EENHGGFAIGC)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = EIFDFLGHKNI;
			mELPJMEEFFM.Call("Buy_Lootboxes", array);
			AndroidJavaObject mELPJMEEFFM2 = MELPJMEEFFM;
			object[] array2 = new object[0];
			array2[0] = DNJIEJNCLFN;
			mELPJMEEFFM2.Call("ID_DEBUG_ASSIGNMENTUPDATE", array2);
			MELPJMEEFFM.Call("Total_Sessions", EENHGGFAIGC);
		}

		public string DCGEENENHNM(string LCKFMHEOPKD)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = LCKFMHEOPKD;
			return mELPJMEEFFM.Call<string>("can't find price for: ", array);
		}

		public void CLLJOEHKHJD(bool HLAJLDPNIEE)
		{
			MELPJMEEFFM.Call("Assignment: Error, task definition not found for id = ", HLAJLDPNIEE);
		}

		public string NLLHOIFBOMO()
		{
			return MELPJMEEFFM.Call<string>("ID_MONTH", new object[1]);
		}

		public void LEIPIEKONLF(string HLJJKFNJECL)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = HLJJKFNJECL;
			mELPJMEEFFM.Call("ID_CONFIRM_JOININGSQUAD_TEXT", array);
		}

		public void AANDLDHNFBC(string FMEIMMBMNLI, string BPGPLJBAFDN)
		{
			AndroidJavaClass cEKJBALBAHP = CEKJBALBAHP;
			object[] array = new object[0];
			array[1] = JICJKBHMCFN;
			array[1] = FMEIMMBMNLI;
			array[2] = BPGPLJBAFDN;
			MELPJMEEFFM = cEKJBALBAHP.CallStatic<AndroidJavaObject>("Game Login Manager: Login to FB", array);
			MELPJMEEFFM.Call("ID_READYTIME", ")");
		}

		public void CLEFIMHGGCB(string JBFIOHGJGHP)
		{
			MELPJMEEFFM.Call("clearCustomProfileVariable", JBFIOHGJGHP);
		}

		private AndroidJavaObject HJNMOCONHKI(GGOFOCDJIFM JJMEOFFKKJN)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.TuneEvent", JJMEOFFKKJN.MHPNDNJDPGE);
			double? lPMMABJCMOB = JJMEOFFKKJN.LPMMABJCMOB;
			if (lPMMABJCMOB.HasValue)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withRevenue", new object[1] { JJMEOFFKKJN.LPMMABJCMOB });
			}
			if (JJMEOFFKKJN.ADNDMABPHOH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withCurrencyCode", new object[1] { JJMEOFFKKJN.ADNDMABPHOH });
			}
			if (JJMEOFFKKJN.AFIDFAOIFGH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAdvertiserRefId", new object[1] { JJMEOFFKKJN.AFIDFAOIFGH });
			}
			if (JJMEOFFKKJN.NCKAPBJOAEL != null)
			{
				AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.util.ArrayList");
				NDMMHFNNODA[] nCKAPBJOAEL = JJMEOFFKKJN.NCKAPBJOAEL;
				for (int i = 0; i < nCKAPBJOAEL.Length; i++)
				{
					NDMMHFNNODA nDMMHFNNODA = nCKAPBJOAEL[i];
					AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("com.tune.TuneEventItem", nDMMHFNNODA.MHPNDNJDPGE);
					int? gHJBDNGEJIM = nDMMHFNNODA.GHJBDNGEJIM;
					if (gHJBDNGEJIM.HasValue)
					{
						androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withQuantity", new object[1] { nDMMHFNNODA.GHJBDNGEJIM });
					}
					double? cCDOJLFMPCN = nDMMHFNNODA.CCDOJLFMPCN;
					if (cCDOJLFMPCN.HasValue)
					{
						androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withUnitPrice", new object[1] { nDMMHFNNODA.CCDOJLFMPCN });
					}
					double? lPMMABJCMOB2 = nDMMHFNNODA.LPMMABJCMOB;
					if (lPMMABJCMOB2.HasValue)
					{
						androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withRevenue", new object[1] { nDMMHFNNODA.LPMMABJCMOB });
					}
					if (nDMMHFNNODA.HENAJIMFKEG != null)
					{
						androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute1", new object[1] { nDMMHFNNODA.HENAJIMFKEG });
					}
					if (nDMMHFNNODA.CHFKJGEKNCL != null)
					{
						androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute2", new object[1] { nDMMHFNNODA.CHFKJGEKNCL });
					}
					if (nDMMHFNNODA.HAJIBLIIBFB != null)
					{
						androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute3", new object[1] { nDMMHFNNODA.HAJIBLIIBFB });
					}
					if (nDMMHFNNODA.JBLMNGCGCEH != null)
					{
						androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute4", new object[1] { nDMMHFNNODA.JBLMNGCGCEH });
					}
					if (nDMMHFNNODA.NIJPEPNLEDJ != null)
					{
						androidJavaObject3 = androidJavaObject3.Call<AndroidJavaObject>("withAttribute5", new object[1] { nDMMHFNNODA.NIJPEPNLEDJ });
					}
					androidJavaObject2.Call<bool>("add", new object[1] { androidJavaObject3 });
				}
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withEventItems", new object[1] { androidJavaObject2 });
			}
			if (JJMEOFFKKJN.CEPKGNHKOIG != null && JJMEOFFKKJN.OIPPFFMKGKH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withReceipt", new object[2] { JJMEOFFKKJN.CEPKGNHKOIG, JJMEOFFKKJN.OIPPFFMKGKH });
			}
			if (JJMEOFFKKJN.PPAKGJCEACD != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withContentType", new object[1] { JJMEOFFKKJN.PPAKGJCEACD });
			}
			if (JJMEOFFKKJN.CKMLJJGFNAN != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withContentId", new object[1] { JJMEOFFKKJN.CKMLJJGFNAN });
			}
			int? bCCDDJMPBLL = JJMEOFFKKJN.BCCDDJMPBLL;
			if (bCCDDJMPBLL.HasValue)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withLevel", new object[1] { JJMEOFFKKJN.BCCDDJMPBLL });
			}
			int? gHJBDNGEJIM2 = JJMEOFFKKJN.GHJBDNGEJIM;
			if (gHJBDNGEJIM2.HasValue)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withQuantity", new object[1] { JJMEOFFKKJN.GHJBDNGEJIM });
			}
			if (JJMEOFFKKJN.JFJKBJHKFII != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withSearchString", new object[1] { JJMEOFFKKJN.JFJKBJHKFII });
			}
			DateTime? eNIAFFIDHHC = JJMEOFFKKJN.ENIAFFIDHHC;
			if (eNIAFFIDHHC.HasValue)
			{
				DateTime? eNIAFFIDHHC2 = JJMEOFFKKJN.ENIAFFIDHHC;
				AndroidJavaObject androidJavaObject4 = BBIEINDADJI(eNIAFFIDHHC2.Value);
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withDate1", new object[1] { androidJavaObject4 });
			}
			DateTime? bONGHGPIOAA = JJMEOFFKKJN.BONGHGPIOAA;
			if (bONGHGPIOAA.HasValue)
			{
				DateTime? bONGHGPIOAA2 = JJMEOFFKKJN.BONGHGPIOAA;
				AndroidJavaObject androidJavaObject5 = BBIEINDADJI(bONGHGPIOAA2.Value);
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withDate2", new object[1] { androidJavaObject5 });
			}
			if (JJMEOFFKKJN.HENAJIMFKEG != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute1", new object[1] { JJMEOFFKKJN.HENAJIMFKEG });
			}
			if (JJMEOFFKKJN.CHFKJGEKNCL != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute2", new object[1] { JJMEOFFKKJN.CHFKJGEKNCL });
			}
			if (JJMEOFFKKJN.HAJIBLIIBFB != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute3", new object[1] { JJMEOFFKKJN.HAJIBLIIBFB });
			}
			if (JJMEOFFKKJN.JBLMNGCGCEH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute4", new object[1] { JJMEOFFKKJN.JBLMNGCGCEH });
			}
			if (JJMEOFFKKJN.NIJPEPNLEDJ != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("withAttribute5", new object[1] { JJMEOFFKKJN.NIJPEPNLEDJ });
			}
			return androidJavaObject;
		}

		public void EDEAJKPAFPI(string PDJIMKGEINA)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = PDJIMKGEINA;
			mELPJMEEFFM.Call("ID_EARLYUNLOCK2", array);
		}

		public KMGHMNDLOBD FMHAHJLEHII()
		{
			string aOFCPIIJFEE = string.Empty;
			string oEFIJIDOMDN = string.Empty;
			Dictionary<string, string> pBLJBLLEAFN = new Dictionary<string, string>();
			try
			{
				AndroidJavaObject androidJavaObject = MELPJMEEFFM.Call<AndroidJavaObject>("getTunePushInfoForSession", new object[0]);
				aOFCPIIJFEE = androidJavaObject.Call<string>("getCampaignId", new object[0]);
				oEFIJIDOMDN = androidJavaObject.Call<string>("getPushId", new object[0]);
				AndroidJavaObject jBDKGMHAMOM = androidJavaObject.Call<AndroidJavaObject>("getExtrasPayload", new object[0]);
				pBLJBLLEAFN = EJDPADPLGLI(jBDKGMHAMOM);
			}
			catch (Exception)
			{
			}
			return new KMGHMNDLOBD(aOFCPIIJFEE, oEFIJIDOMDN, pBLJBLLEAFN);
		}

		public void BCJAGPDMFGH(string JBFIOHGJGHP, string EHBNNJEBJDI)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[6];
			array[1] = JBFIOHGJGHP;
			array[1] = EHBNNJEBJDI;
			mELPJMEEFFM.Call("BeginnersLeague", array);
		}

		public void PIMJCHHKPMG(bool DJGKFANKBAG)
		{
			MELPJMEEFFM.Call("setIsPayingUser", DJGKFANKBAG);
		}

		public void MBKLKFCMNLF(string JBFIOHGJGHP, DateTime IDEBKDPMPGM)
		{
			AndroidJavaObject androidJavaObject = PJDMKPKBFMK(IDEBKDPMPGM);
			MELPJMEEFFM.Call("damage", JBFIOHGJGHP, androidJavaObject, null, null, null);
		}

		public void KACOEDKINDH(string JBFIOHGJGHP, float IDEBKDPMPGM)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[3];
			array[1] = JBFIOHGJGHP;
			array[0] = IDEBKDPMPGM;
			mELPJMEEFFM.Call("{0} - {1}\n", array);
		}

		public Dictionary<string, KIHINHPLIEC> AABDNIHPMDI()
		{
			Dictionary<string, KIHINHPLIEC> dictionary = new Dictionary<string, KIHINHPLIEC>();
			AndroidJavaObject androidJavaObject = MELPJMEEFFM.Call<AndroidJavaObject>("ID_SECOND", new object[0]);
			if (androidJavaObject != null)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("_TranslucencyColor", new object[1]);
				AndroidJavaObject androidJavaObject3 = androidJavaObject2.Call<AndroidJavaObject>("\"", new object[0]);
				while (androidJavaObject3.Call<bool>("405 MENU WEAPON SCREEN BUY UPGRADE", new object[0]))
				{
					AndroidJavaObject androidJavaObject4 = androidJavaObject3.Call<AndroidJavaObject>("Server send power band reward id {0} which is null setting random {1}", new object[1]);
					string key = androidJavaObject4.Call<string>("damage", new object[0]);
					AndroidJavaObject pLMNDEMGBIP = androidJavaObject4.Call<AndroidJavaObject>("Country", new object[1]);
					dictionary.Add(key, new KIHINHPLIEC(pLMNDEMGBIP));
				}
			}
			return dictionary;
		}

		public void CCDOEDEMKOB(string AFAHHFAHCKD)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = AFAHHFAHCKD;
			mELPJMEEFFM.Call("java.util.ArrayList", array);
		}

		public void LMJAINDBOEN(string JBFIOHGJGHP)
		{
			MELPJMEEFFM.Call("registerCustomProfileGeolocation", JBFIOHGJGHP);
		}

		public void PDAPLMBKNLI(string HECDGAPMDHJ)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = HECDGAPMDHJ;
			mELPJMEEFFM.Call("About to show unit categories reminder", array);
		}

		public void MNFMKIGPMHN(string JBFIOHGJGHP, string IDEBKDPMPGM)
		{
			MELPJMEEFFM.Call("setCustomProfileStringValue", JBFIOHGJGHP, IDEBKDPMPGM);
		}

		private Dictionary<string, string> AJGPGCLHHGO(AndroidJavaObject JBDKGMHAMOM)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			AndroidJavaObject androidJavaObject = JBDKGMHAMOM.Call<AndroidJavaObject>("Card_1_Played", new object[0]);
			while (androidJavaObject.Call<bool>("Friend {0} {1}", new object[1]))
			{
				string text = androidJavaObject.Call<string>("YES", new object[0]);
				object[] array = new object[0];
				array[1] = text;
				dictionary.Add(text, JBDKGMHAMOM.Call<string>("bazooka_reload", array));
			}
			return dictionary;
		}

		public void JIFPCJGEGJF(string FHBOIIHFJPF)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = FHBOIIHFJPF;
			mELPJMEEFFM.Call("' already destroyed on application quit. Won't create again - returning null.", array);
		}

		private AndroidJavaObject GEPBBKJCOMA(Dictionary<string, string> OGNGMBLDAOP)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("AtlasPreparer.ClearMenuLoadGameCoroutine", new object[1]);
			if (OGNGMBLDAOP != null)
			{
				foreach (KeyValuePair<string, string> item in OGNGMBLDAOP)
				{
					object[] array = new object[3];
					array[1] = item.Key;
					array[1] = item.Value;
					androidJavaObject.Call<string>("Mobile/Diffuse", array);
				}
			}
			return androidJavaObject;
		}

		private AndroidJavaObject BBIEINDADJI(DateTime KGPAGNONACC)
		{
			double totalMilliseconds = new TimeSpan(KGPAGNONACC.Ticks).TotalMilliseconds;
			double num = totalMilliseconds - new TimeSpan(new DateTime(1970, 1, 1).Ticks).TotalMilliseconds;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.Double", num);
			long num2 = androidJavaObject.Call<long>("longValue", new object[0]);
			return new AndroidJavaObject("java.util.Date", num2);
		}

		public void HMALDMNHMCI(string PDJIMKGEINA)
		{
			MELPJMEEFFM.Call("setAndroidId", PDJIMKGEINA);
		}

		public void KOEFMLFLDDP(bool KFGLOHLBCIE)
		{
			MELPJMEEFFM.Call("setEmailCollection", KFGLOHLBCIE);
		}

		public void PMEONONIBEP(bool LLNNNBEAGBC)
		{
			MELPJMEEFFM.Call("UpdateIndicatorRPC", LLNNNBEAGBC);
		}

		public void NMOPMPAHJPA(string JBFIOHGJGHP, int EHBNNJEBJDI)
		{
			MELPJMEEFFM.Call("registerCustomProfileNumber", JBFIOHGJGHP, EHBNNJEBJDI);
		}

		public void BIBEBHHNHOA(bool GLJFJHEFKBG)
		{
			if (GLJFJHEFKBG)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityPowerHooksListener");
				MELPJMEEFFM.Call("onPowerHooksChanged", androidJavaObject);
			}
		}

		public void MLNFCBEDABI(string CGAGIGNCBJM, bool BMHOFGFOGGA)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("battleID");
			object[] array = new object[1];
			array[0] = CGAGIGNCBJM;
			array[0] = BMHOFGFOGGA;
			androidJavaClass.CallStatic("Amount", array);
		}

		public void FIMOEOGCHHN(string LCKFMHEOPKD, string FCKBANHBIKN, string EHBNNJEBJDI)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[3];
			array[0] = LCKFMHEOPKD;
			array[0] = FCKBANHBIKN;
			array[5] = EHBNNJEBJDI;
			mELPJMEEFFM.Call("Waiting too long for all playersFinish to loading", array);
		}

		public void LOPBEEHGIPG(string HECDGAPMDHJ)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[1] = HECDGAPMDHJ;
			mELPJMEEFFM.Call("Card_2_Played", array);
		}

		public string HFNFKGEEMGP()
		{
			return MELPJMEEFFM.Call<string>("$5-$10", new object[1]);
		}

		public void KIKBAPHOEOM(int BCJPNMIBDNM)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = BCJPNMIBDNM;
			mELPJMEEFFM.Call("[CardHealthChangeUnit] - used again after spawning start, but before finish!!!", array);
		}

		private AndroidJavaObject CMCJEBIKNGE(Dictionary<string, string> OGNGMBLDAOP)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.util.HashMap");
			if (OGNGMBLDAOP != null)
			{
				foreach (KeyValuePair<string, string> item in OGNGMBLDAOP)
				{
					androidJavaObject.Call<string>("put", new object[2] { item.Key, item.Value });
				}
			}
			return androidJavaObject;
		}

		public bool KEPHLOIAIKH()
		{
			return MELPJMEEFFM.Call<bool>("ID_NOTIFICATION_DAILYREWARD_MESSAGE", new object[0]);
		}

		public void EHKKAOLJMCF(string FMEIMMBMNLI, string BPGPLJBAFDN)
		{
			MELPJMEEFFM = CEKJBALBAHP.CallStatic<AndroidJavaObject>("init", new object[3] { JICJKBHMCFN, FMEIMMBMNLI, BPGPLJBAFDN });
			MELPJMEEFFM.Call("setPluginName", "unity");
		}

		public bool JMBCFJCMLCC(string CGAGIGNCBJM)
		{
			return MELPJMEEFFM.Call<bool>("isUserInSegmentId", new object[1] { CGAGIGNCBJM });
		}

		public void IBKJLIBBEKD(int NCODFCIEAII)
		{
			AndroidJavaObject androidJavaObject;
			switch (NCODFCIEAII)
			{
			case 0:
				androidJavaObject = new AndroidJavaClass("com.tune.TuneGender").GetStatic<AndroidJavaObject>("MALE");
				return;
			case 1:
				androidJavaObject = new AndroidJavaClass("com.tune.TuneGender").GetStatic<AndroidJavaObject>("FEMALE");
				return;
			}
			androidJavaObject = new AndroidJavaClass("com.tune.TuneGender").GetStatic<AndroidJavaObject>("UNKNOWN");
			MELPJMEEFFM.Call("setGender", androidJavaObject);
		}

		public void JAPFDONNBIF()
		{
			MELPJMEEFFM.Call("clearAllCustomProfileVariables");
		}

		public void PFCEOKIEKEJ(bool AHGPAJEODDN)
		{
			MELPJMEEFFM.Call("reloadTime", AHGPAJEODDN);
		}

		public void NDJDBDBCNNL(string BNFJCGPPAII)
		{
			MELPJMEEFFM.Call("Google2u.DBUpgradeSlotsAssaulter", BNFJCGPPAII);
		}

		public string IHFAEMDJNOJ(string LCKFMHEOPKD)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = LCKFMHEOPKD;
			return mELPJMEEFFM.Call<string>("CardId", array);
		}

		private AndroidJavaObject FOOIDGHHNDC(GGOFOCDJIFM JJMEOFFKKJN)
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("Particle with name: ", JJMEOFFKKJN.MHPNDNJDPGE);
			double? lPMMABJCMOB = JJMEOFFKKJN.LPMMABJCMOB;
			if (lPMMABJCMOB.HasValue)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject;
				object[] array = new object[0];
				array[1] = JJMEOFFKKJN.LPMMABJCMOB;
				androidJavaObject = androidJavaObject2.Call<AndroidJavaObject>("ID_VIPBENEFIT", array);
			}
			if (JJMEOFFKKJN.ADNDMABPHOH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("shield_unhide", new object[1] { JJMEOFFKKJN.ADNDMABPHOH });
			}
			if (JJMEOFFKKJN.AFIDFAOIFGH != null)
			{
				AndroidJavaObject androidJavaObject3 = androidJavaObject;
				object[] array2 = new object[0];
				array2[1] = JJMEOFFKKJN.AFIDFAOIFGH;
				androidJavaObject = androidJavaObject3.Call<AndroidJavaObject>("PNManager: Received event: ", array2);
			}
			if (JJMEOFFKKJN.NCKAPBJOAEL != null)
			{
				AndroidJavaObject androidJavaObject4 = new AndroidJavaObject("Chillingo: On Age Verification Pending Dialog Display ", new object[1]);
				NDMMHFNNODA[] nCKAPBJOAEL = JJMEOFFKKJN.NCKAPBJOAEL;
				for (int i = 1; i < nCKAPBJOAEL.Length; i += 0)
				{
					NDMMHFNNODA nDMMHFNNODA = nCKAPBJOAEL[i];
					object[] array3 = new object[0];
					array3[0] = nDMMHFNNODA.MHPNDNJDPGE;
					AndroidJavaObject androidJavaObject5 = new AndroidJavaObject(" 2", array3);
					int? gHJBDNGEJIM = nDMMHFNNODA.GHJBDNGEJIM;
					if (gHJBDNGEJIM.HasValue)
					{
						AndroidJavaObject androidJavaObject6 = androidJavaObject5;
						object[] array4 = new object[1];
						array4[1] = nDMMHFNNODA.GHJBDNGEJIM;
						androidJavaObject5 = androidJavaObject6.Call<AndroidJavaObject>("BAND_REWARD_HEALTH", array4);
					}
					double? cCDOJLFMPCN = nDMMHFNNODA.CCDOJLFMPCN;
					if (cCDOJLFMPCN.HasValue)
					{
						AndroidJavaObject androidJavaObject7 = androidJavaObject5;
						object[] array5 = new object[0];
						array5[0] = nDMMHFNNODA.CCDOJLFMPCN;
						androidJavaObject5 = androidJavaObject7.Call<AndroidJavaObject>("ID_FEATURE_RATE-FANCY", array5);
					}
					double? lPMMABJCMOB2 = nDMMHFNNODA.LPMMABJCMOB;
					if (lPMMABJCMOB2.HasValue)
					{
						AndroidJavaObject androidJavaObject8 = androidJavaObject5;
						object[] array6 = new object[0];
						array6[1] = nDMMHFNNODA.LPMMABJCMOB;
						androidJavaObject5 = androidJavaObject8.Call<AndroidJavaObject>("0", array6);
					}
					if (nDMMHFNNODA.HENAJIMFKEG != null)
					{
						AndroidJavaObject androidJavaObject9 = androidJavaObject5;
						object[] array7 = new object[0];
						array7[1] = nDMMHFNNODA.HENAJIMFKEG;
						androidJavaObject5 = androidJavaObject9.Call<AndroidJavaObject>("FuseSDK: Duplicate StartSession call. Ignoring.", array7);
					}
					if (nDMMHFNNODA.CHFKJGEKNCL != null)
					{
						androidJavaObject5 = androidJavaObject5.Call<AndroidJavaObject>("rookie3", new object[1] { nDMMHFNNODA.CHFKJGEKNCL });
					}
					if (nDMMHFNNODA.HAJIBLIIBFB != null)
					{
						AndroidJavaObject androidJavaObject10 = androidJavaObject5;
						object[] array8 = new object[0];
						array8[0] = nDMMHFNNODA.HAJIBLIIBFB;
						androidJavaObject5 = androidJavaObject10.Call<AndroidJavaObject>("SnapColt", array8);
					}
					if (nDMMHFNNODA.JBLMNGCGCEH != null)
					{
						androidJavaObject5 = androidJavaObject5.Call<AndroidJavaObject>("Chat: Trying to get messages from null or empty channelName", new object[1] { nDMMHFNNODA.JBLMNGCGCEH });
					}
					if (nDMMHFNNODA.NIJPEPNLEDJ != null)
					{
						AndroidJavaObject androidJavaObject11 = androidJavaObject5;
						object[] array9 = new object[0];
						array9[1] = nDMMHFNNODA.NIJPEPNLEDJ;
						androidJavaObject5 = androidJavaObject11.Call<AndroidJavaObject>("LevelGold", array9);
					}
					object[] array10 = new object[0];
					array10[0] = androidJavaObject5;
					androidJavaObject4.Call<bool>("Calling callback and setting it to null!!", array10);
				}
				AndroidJavaObject androidJavaObject12 = androidJavaObject;
				object[] array11 = new object[1];
				array11[1] = androidJavaObject4;
				androidJavaObject = androidJavaObject12.Call<AndroidJavaObject>("ID_STAT_MOSTSQUADPOINTS", array11);
			}
			if (JJMEOFFKKJN.CEPKGNHKOIG != null && JJMEOFFKKJN.OIPPFFMKGKH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_CREATESQUADUNLOCKED", new object[4] { JJMEOFFKKJN.CEPKGNHKOIG, JJMEOFFKKJN.OIPPFFMKGKH, null, null });
			}
			if (JJMEOFFKKJN.PPAKGJCEACD != null)
			{
				AndroidJavaObject androidJavaObject13 = androidJavaObject;
				object[] array12 = new object[0];
				array12[0] = JJMEOFFKKJN.PPAKGJCEACD;
				androidJavaObject = androidJavaObject13.Call<AndroidJavaObject>("OnPauseDrawing", array12);
			}
			if (JJMEOFFKKJN.CKMLJJGFNAN != null)
			{
				AndroidJavaObject androidJavaObject14 = androidJavaObject;
				object[] array13 = new object[0];
				array13[1] = JJMEOFFKKJN.CKMLJJGFNAN;
				androidJavaObject = androidJavaObject14.Call<AndroidJavaObject>("SoldierBehaviourSwitchWeapon", array13);
			}
			int? bCCDDJMPBLL = JJMEOFFKKJN.BCCDDJMPBLL;
			if (bCCDDJMPBLL.HasValue)
			{
				AndroidJavaObject androidJavaObject15 = androidJavaObject;
				object[] array14 = new object[1];
				array14[1] = JJMEOFFKKJN.BCCDDJMPBLL;
				androidJavaObject = androidJavaObject15.Call<AndroidJavaObject>("AccountType", array14);
			}
			int? gHJBDNGEJIM2 = JJMEOFFKKJN.GHJBDNGEJIM;
			if (gHJBDNGEJIM2.HasValue)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("RETRYPERM", new object[1] { JJMEOFFKKJN.GHJBDNGEJIM });
			}
			if (JJMEOFFKKJN.JFJKBJHKFII != null)
			{
				AndroidJavaObject androidJavaObject16 = androidJavaObject;
				object[] array15 = new object[0];
				array15[0] = JJMEOFFKKJN.JFJKBJHKFII;
				androidJavaObject = androidJavaObject16.Call<AndroidJavaObject>("Pack", array15);
			}
			DateTime? eNIAFFIDHHC = JJMEOFFKKJN.ENIAFFIDHHC;
			if (eNIAFFIDHHC.HasValue)
			{
				DateTime? eNIAFFIDHHC2 = JJMEOFFKKJN.ENIAFFIDHHC;
				AndroidJavaObject androidJavaObject17 = BBIEINDADJI(eNIAFFIDHHC2.Value);
				AndroidJavaObject androidJavaObject18 = androidJavaObject;
				object[] array16 = new object[0];
				array16[1] = androidJavaObject17;
				androidJavaObject = androidJavaObject18.Call<AndroidJavaObject>("#Mission Rewards# New missions data are loaded to client", array16);
			}
			DateTime? bONGHGPIOAA = JJMEOFFKKJN.BONGHGPIOAA;
			if (bONGHGPIOAA.HasValue)
			{
				DateTime? bONGHGPIOAA2 = JJMEOFFKKJN.BONGHGPIOAA;
				AndroidJavaObject androidJavaObject19 = PJDMKPKBFMK(bONGHGPIOAA2.Value);
				AndroidJavaObject androidJavaObject20 = androidJavaObject;
				object[] array17 = new object[1];
				array17[1] = androidJavaObject19;
				androidJavaObject = androidJavaObject20.Call<AndroidJavaObject>("ID_SELECTTWOUNITS", array17);
			}
			if (JJMEOFFKKJN.HENAJIMFKEG != null)
			{
				AndroidJavaObject androidJavaObject21 = androidJavaObject;
				object[] array18 = new object[0];
				array18[0] = JJMEOFFKKJN.HENAJIMFKEG;
				androidJavaObject = androidJavaObject21.Call<AndroidJavaObject>("10", array18);
			}
			if (JJMEOFFKKJN.CHFKJGEKNCL != null)
			{
				AndroidJavaObject androidJavaObject22 = androidJavaObject;
				object[] array19 = new object[0];
				array19[1] = JJMEOFFKKJN.CHFKJGEKNCL;
				androidJavaObject = androidJavaObject22.Call<AndroidJavaObject>("Warbucks", array19);
			}
			if (JJMEOFFKKJN.HAJIBLIIBFB != null)
			{
				AndroidJavaObject androidJavaObject23 = androidJavaObject;
				object[] array20 = new object[0];
				array20[0] = JJMEOFFKKJN.HAJIBLIIBFB;
				androidJavaObject = androidJavaObject23.Call<AndroidJavaObject>("ID_WARNING_BLACKMARKETERROR", array20);
			}
			if (JJMEOFFKKJN.JBLMNGCGCEH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("Name", new object[1] { JJMEOFFKKJN.JBLMNGCGCEH });
			}
			if (JJMEOFFKKJN.NIJPEPNLEDJ != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_READYTIME", new object[1] { JJMEOFFKKJN.NIJPEPNLEDJ });
			}
			return androidJavaObject;
		}

		public void BJDAIPJEJHA(string MGMFDDEENJL)
		{
			MELPJMEEFFM.Call("Sniper_Tutorial_Played", MGMFDDEENJL);
		}

		public DateTime EAGCJOHBGAD(string JBFIOHGJGHP)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = JBFIOHGJGHP;
			AndroidJavaObject androidJavaObject = mELPJMEEFFM.Call<AndroidJavaObject>("percent", array);
			if (androidJavaObject != null)
			{
				long num = androidJavaObject.Call<long>("sniper_reload", new object[0]);
				return new DateTime(186, 1, 1, 0, 0, 1, DateTimeKind.Utc).AddMilliseconds(num);
			}
			return default(DateTime);
		}

		public void LCMDKHDFAOE(string JBFIOHGJGHP, DateTime EHBNNJEBJDI)
		{
			AndroidJavaObject androidJavaObject = BBIEINDADJI(EHBNNJEBJDI);
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[6];
			array[1] = JBFIOHGJGHP;
			array[0] = androidJavaObject;
			mELPJMEEFFM.Call(" GC connect: ", array);
		}

		public FAOPKIDIODH BLCALEJBIGP(string JBFIOHGJGHP)
		{
			FAOPKIDIODH fAOPKIDIODH = new FAOPKIDIODH();
			AndroidJavaObject androidJavaObject = MELPJMEEFFM.Call<AndroidJavaObject>("getCustomProfileGeolocation", new object[1] { JBFIOHGJGHP });
			if (androidJavaObject != null)
			{
				double eIFDFLGHKNI = androidJavaObject.Call<double>("getLatitude", new object[0]);
				double dNJIEJNCLFN = androidJavaObject.Call<double>("getLongitude", new object[0]);
				fAOPKIDIODH.EIFDFLGHKNI = eIFDFLGHKNI;
				fAOPKIDIODH.DNJIEJNCLFN = dNJIEJNCLFN;
			}
			return fAOPKIDIODH;
		}

		public void NPEDJCLPMFI(bool BCEGHIHJEAK)
		{
			if (BCEGHIHJEAK)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("Reward {0:D2}", new object[1]);
				AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
				object[] array = new object[0];
				array[0] = androidJavaObject;
				mELPJMEEFFM.Call("ID_RATEAPPTEXT", array);
			}
		}

		public void LMPPDMBOFOO(string DDLNDBANBHK)
		{
			MELPJMEEFFM.Call("measureEvent", DDLNDBANBHK);
		}

		public bool AFOLJIGJAPB(string CGAGIGNCBJM)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = CGAGIGNCBJM;
			return mELPJMEEFFM.Call<bool>("Lcom/google/android/gms/games/event/Events;", array);
		}

		public void KOKIJANKFFJ(string AAFGGINALFC)
		{
			MELPJMEEFFM.Call("setPushNotificationSenderId", AAFGGINALFC);
		}

		public void OEJAKCMCBAF()
		{
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("card ", new object[1]);
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = androidJavaObject;
			mELPJMEEFFM.Call("ID_READYTIME", array);
		}

		public void OOGKHIBDJFE(string ADNDMABPHOH)
		{
			MELPJMEEFFM.Call("setCurrencyCode", ADNDMABPHOH);
		}

		public void DFILDAMGMKH(OIGOLMMEFKH EOFMBNANALP)
		{
			object[] array = new object[0];
			array[0] = EOFMBNANALP.NPFLLLEFNGH;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("View_Stats", array);
			if (EOFMBNANALP.AJEALDLONFJ != null)
			{
				AndroidJavaObject androidJavaObject2 = androidJavaObject;
				object[] array2 = new object[1];
				array2[1] = EOFMBNANALP.AJEALDLONFJ;
				androidJavaObject = androidJavaObject2.Call<AndroidJavaObject>("elite", array2);
			}
			if (EOFMBNANALP.CAJFOEAGHGD != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("Gold", new object[1] { EOFMBNANALP.CAJFOEAGHGD });
			}
			if (EOFMBNANALP.EIDGJLAACPE != null)
			{
				AndroidJavaObject androidJavaObject3 = androidJavaObject;
				object[] array3 = new object[0];
				array3[1] = EOFMBNANALP.EIDGJLAACPE;
				androidJavaObject = androidJavaObject3.Call<AndroidJavaObject>("\t\"TRUE\"", array3);
			}
			if (EOFMBNANALP.MFLOKCDHGCO != null)
			{
				AndroidJavaObject androidJavaObject4 = androidJavaObject;
				object[] array4 = new object[0];
				array4[1] = EOFMBNANALP.MFLOKCDHGCO;
				androidJavaObject = androidJavaObject4.Call<AndroidJavaObject>("MessageType", array4);
			}
			if (EOFMBNANALP.BCFNCDEPOAO != null)
			{
				AndroidJavaObject androidJavaObject5 = androidJavaObject;
				object[] array5 = new object[0];
				array5[0] = EOFMBNANALP.BCFNCDEPOAO;
				androidJavaObject = androidJavaObject5.Call<AndroidJavaObject>("1", array5);
			}
			if (EOFMBNANALP.IMIPAFPMBPC != null)
			{
				AndroidJavaObject androidJavaObject6 = androidJavaObject;
				object[] array6 = new object[1];
				array6[1] = EOFMBNANALP.IMIPAFPMBPC;
				androidJavaObject = androidJavaObject6.Call<AndroidJavaObject>("{0}\u00a0{1}", array6);
			}
			if (EOFMBNANALP.MKMJLAFHJAD != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("App not installed", new object[1] { EOFMBNANALP.MKMJLAFHJAD });
			}
			if (EOFMBNANALP.BNKCJBHIGMB != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_DAY", new object[1] { EOFMBNANALP.BNKCJBHIGMB });
			}
			if (EOFMBNANALP.MHINMPHEIBH != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("ID_CONFIRM_ERROR", new object[1] { EOFMBNANALP.MHINMPHEIBH });
			}
			if (EOFMBNANALP.HDIFLJOLCFI != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("Player_Avoided_Grenade_On_First_Try", new object[1] { EOFMBNANALP.HDIFLJOLCFI });
			}
			if (EOFMBNANALP.KNIHMOHMMCL != null)
			{
				AndroidJavaObject androidJavaObject7 = androidJavaObject;
				object[] array7 = new object[0];
				array7[0] = EOFMBNANALP.KNIHMOHMMCL;
				androidJavaObject = androidJavaObject7.Call<AndroidJavaObject>("Player_Had_To_Select_Grenade", array7);
			}
			if (EOFMBNANALP.MNKEIAPDNPH != null)
			{
				AndroidJavaObject androidJavaObject8 = androidJavaObject;
				object[] array8 = new object[0];
				array8[1] = EOFMBNANALP.MNKEIAPDNPH;
				androidJavaObject = androidJavaObject8.Call<AndroidJavaObject>("Average_Transaction_Amount", array8);
			}
			if (EOFMBNANALP.LPDBPGJANAP != null)
			{
				AndroidJavaObject androidJavaObject9 = androidJavaObject;
				object[] array9 = new object[0];
				array9[0] = EOFMBNANALP.LPDBPGJANAP;
				androidJavaObject = androidJavaObject9.Call<AndroidJavaObject>("0.0.0", array9);
			}
			if (EOFMBNANALP.PEOBBKMKKPH != null)
			{
				AndroidJavaObject androidJavaObject10 = androidJavaObject;
				object[] array10 = new object[1];
				array10[1] = EOFMBNANALP.PEOBBKMKKPH;
				androidJavaObject = androidJavaObject10.Call<AndroidJavaObject>("shield_hide", array10);
			}
			if (EOFMBNANALP.BBCOJPFLOIL != null)
			{
				AndroidJavaObject androidJavaObject11 = androidJavaObject;
				object[] array11 = new object[1];
				array11[1] = EOFMBNANALP.BBCOJPFLOIL;
				androidJavaObject = androidJavaObject11.Call<AndroidJavaObject>("ID_UPGRADED", array11);
			}
			if (EOFMBNANALP.BBGEPEOAJCO != null)
			{
				androidJavaObject = androidJavaObject.Call<AndroidJavaObject>("BattleRewards", new object[1] { EOFMBNANALP.BBGEPEOAJCO });
			}
			if (EOFMBNANALP.FAHGOOKOCNE != null)
			{
				AndroidJavaObject androidJavaObject12 = androidJavaObject;
				object[] array12 = new object[1];
				array12[1] = EOFMBNANALP.FAHGOOKOCNE;
				androidJavaObject = androidJavaObject12.Call<AndroidJavaObject>("ID_ARENARULES_TRIPLEAMMO", array12);
			}
			if (EOFMBNANALP.OCEJMMCCJMB != null)
			{
				AndroidJavaObject androidJavaObject13 = androidJavaObject;
				object[] array13 = new object[0];
				array13[1] = EOFMBNANALP.OCEJMMCCJMB;
				androidJavaObject = androidJavaObject13.Call<AndroidJavaObject>("menu-army-ammo-ico", array13);
			}
			if (EOFMBNANALP.CNIKOPJGLCA != null)
			{
				AndroidJavaObject androidJavaObject14 = androidJavaObject;
				object[] array14 = new object[1];
				array14[1] = EOFMBNANALP.CNIKOPJGLCA;
				androidJavaObject = androidJavaObject14.Call<AndroidJavaObject>("ID_GC_LOGIN_TUTORIAL_TITLE", array14);
			}
			if (EOFMBNANALP.ENAMFENFBNC != null)
			{
				AndroidJavaObject androidJavaObject15 = androidJavaObject;
				object[] array15 = new object[1];
				array15[1] = EOFMBNANALP.ENAMFENFBNC;
				androidJavaObject = androidJavaObject15.Call<AndroidJavaObject>("\n", array15);
			}
			MELPJMEEFFM.Call("longValue", androidJavaObject);
		}

		public void NCOMEKJIFMP(bool BCEGHIHJEAK)
		{
			if (BCEGHIHJEAK)
			{
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.tune.unityutils.TuneUnityFirstPlaylistListener");
				MELPJMEEFFM.Call("onFirstPlaylistDownloaded", androidJavaObject);
			}
		}

		public void FKLONNALOGE(string JBFIOHGJGHP)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[0];
			array[0] = JBFIOHGJGHP;
			mELPJMEEFFM.Call("Google2u.DBUpgradeSlotsShotgunner", array);
		}

		public void GMCPPOMONME(string FMEIMMBMNLI, string BPGPLJBAFDN, bool ELFLFBNHABN)
		{
			AndroidJavaClass cEKJBALBAHP = CEKJBALBAHP;
			object[] array = new object[8];
			array[1] = JICJKBHMCFN;
			array[0] = FMEIMMBMNLI;
			array[7] = BPGPLJBAFDN;
			array[1] = ELFLFBNHABN;
			MELPJMEEFFM = cEKJBALBAHP.CallStatic<AndroidJavaObject>("country-saudi-arabia", array);
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array2 = new object[0];
			array2[0] = "VALUE";
			mELPJMEEFFM.Call("isSuccess", array2);
		}

		public string AHHPAFFCJJI(string JBFIOHGJGHP)
		{
			return MELPJMEEFFM.Call<string>("getCustomProfileString", new object[1] { JBFIOHGJGHP });
		}

		public void MIGDOJBJJNB(string CPMIJFEFGDJ)
		{
			MELPJMEEFFM.Call("setPhoneNumber", CPMIJFEFGDJ);
		}

		public void HLJIBFHAGIA(string LCKFMHEOPKD, string IDEBKDPMPGM)
		{
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[8];
			array[0] = LCKFMHEOPKD;
			array[0] = IDEBKDPMPGM;
			mELPJMEEFFM.Call("ID_STAT_WINLOSSRATIO", array);
		}

		public void CEDGFOAKMOG(string JBFIOHGJGHP, DateTime EHBNNJEBJDI)
		{
			AndroidJavaObject androidJavaObject = BBIEINDADJI(EHBNNJEBJDI);
			MELPJMEEFFM.Call("registerCustomProfileDate", JBFIOHGJGHP, androidJavaObject);
		}

		public void GLACMPMOJML(string JBFIOHGJGHP, DateTime EHBNNJEBJDI)
		{
			AndroidJavaObject androidJavaObject = BBIEINDADJI(EHBNNJEBJDI);
			AndroidJavaObject mELPJMEEFFM = MELPJMEEFFM;
			object[] array = new object[1];
			array[1] = JBFIOHGJGHP;
			array[0] = androidJavaObject;
			mELPJMEEFFM.Call("ID_CONFIRM_DOGTAGSAREFULL_TEXT", array);
		}
	}
}
