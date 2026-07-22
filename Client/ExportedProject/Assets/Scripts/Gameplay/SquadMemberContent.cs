using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadMemberContent : Core_BaseScript
{
	public class PANBDDEEANM
	{
		public int FJLBLLLEELD;

		public DatabasePlayer ALHCNAGDAKH;

		public int FAIFMIDDJME;

		public int JFHCIILADJL;

		public static PANBDDEEANM CKDJBOEMADO()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM LEEKCLALLIL(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 7;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM NBBGGNAEABC(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 2;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM IFPIEFOJIMA(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 4;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM JGMKFMEJONG(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM ALHDHNMIPAF(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 4;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM KNLIGGOPIGO(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 8;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM KGHGIIAFCMM(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 3;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM IBABGKJGLOP(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM MNJILBBCANF()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM KKEBJBOMMOE(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 2;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM FNNFEFPFHLA()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM EHODCCDELMB()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM OCPDDIAPJEG(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM AAPMFIHBKLP()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM ANAPOPCAJFP()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM JCDIEDHIKOL(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM EKFBKEPABOG(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM EEPJDIHMNAG(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM ADFMAENBAEK()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM KHMPGKIACOE(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM FFFIMHNDDLD(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM MBLOHBEEHBL(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 7;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM JDFPMBPIFLH(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 2;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM PDCPHCHKDND(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM OBPCPEDENIP(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM AMMPPMGGAPE(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM OFDDOBGHLAF(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM KNHKIALCEHJ(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 8;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM BLNDDFFEODG(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 6;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM ALJDMNMBPOG()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM GOMONJEJIHC(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM DFMJFCLFACH(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM IIBCGOOOGFE()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM IHJDHNCKBFG(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 4;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM KCKJONGIFJP(int IODOMBFEEJC, int NFMFCDDIBLC)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 8;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = IODOMBFEEJC;
			pANBDDEEANM.JFHCIILADJL = NFMFCDDIBLC;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM AMGPOFKEJND()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 0;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 0;
			pANBDDEEANM.JFHCIILADJL = 1;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM OCNNFPHBJLK()
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = null;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}

		public static PANBDDEEANM DAHEKNAHJKA(DatabasePlayer KHLGDCHJJPB)
		{
			PANBDDEEANM pANBDDEEANM = new PANBDDEEANM();
			pANBDDEEANM.FJLBLLLEELD = 1;
			pANBDDEEANM.ALHCNAGDAKH = KHLGDCHJJPB;
			pANBDDEEANM.FAIFMIDDJME = 1;
			pANBDDEEANM.JFHCIILADJL = 0;
			return pANBDDEEANM;
		}
	}

	public class HNKGNMGKMPH
	{
		public DatabaseAction IFGAGNBDKBE;

		public string EJBEDLHIKDG;

		public HNKGNMGKMPH(DatabaseAction HPJFBKEKJHB, string INFLHPGMEOB)
		{
			IFGAGNBDKBE = HPJFBKEKJHB;
			EJBEDLHIKDG = INFLHPGMEOB;
		}
	}

	private sealed class HLOPEJGKBKI
	{
		internal KeyValuePair<string, AwaitingSquadMembersManager.HJHILHFDMKP> ALHCNAGDAKH;

		internal bool LGJCNCHBFDA(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool HHLMDAKDHFK(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool DDHOKNIEACI(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool FHDOHCJJEMM(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool OKNCFDMEFGJ(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool BDCAFHOHEGM(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool MMEEJDGGAID(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool LKKLABBEOAG(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool LHPPLGOOLEC(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool MCFGAFBEJDK(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool BMCMDMKGHHO(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool AMIJFGBOCLC(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool MAKLHLCDIKD(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool NNIJEDKBPGJ(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool LJCDGJKCNEC(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool MFCNOIDCJME(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool CFJHDIHLIML(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool GMFJFMHNDMC(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}
	}

	private sealed class GBOBPBPIINP
	{
		internal KeyValuePair<string, AwaitingSquadMembersManager.HJHILHFDMKP> ALHCNAGDAKH;

		internal bool BBPKDMPNEDG(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool LJCDGJKCNEC(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool AMIJFGBOCLC(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool MAKLHLCDIKD(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool MFCNOIDCJME(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool KNJBDOADLDO(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool MPHECHCFCAN(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool CHDOECNGOPM(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool ECPMEMNKMCB(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool LGJCNCHBFDA(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool FHDOHCJJEMM(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool NNIJEDKBPGJ(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool MMEEJDGGAID(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}

		internal bool CFJHDIHLIML(DatabasePlayer ACLNBMACCLL)
		{
			return ACLNBMACCLL.id == ALHCNAGDAKH.Key;
		}
	}

	private sealed class ABNBBOGDMIG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal SquadMemberContent BJGCPDNMHDH;

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

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(734f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool AAOIPMCCPEM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1211f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1235f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object COEKBAFPBLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIFIOGBLLBE()
		{
			return PHDOCKCBJOF;
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public bool LGOHLNFJKNL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(728f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void EBAGFJMHLCB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BPFAJJGHCCD()
		{
			throw new NotSupportedException();
		}

		public void BJHCLGCKJBB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EPNOIENCFGA()
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
				PHDOCKCBJOF = new WaitForSeconds(729f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(535f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(908f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName, FHKKPEIDDJN: true);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public ABNBBOGDMIG()
		{
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NAAMAOJBKBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LHMPDOBMOLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IJONKJIBHGO()
		{
			return PHDOCKCBJOF;
		}

		public bool IGKACECJBEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(185f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(479f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		public bool EBLHEEKHANA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1487f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName, FHKKPEIDDJN: true);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public bool AKHEIOMMAJL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1635f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ECJHOPIBAMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1284f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void KPJIDBHHKFM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public bool FJKEEKBNKPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(206f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName, FHKKPEIDDJN: true);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void CBPDLFGDOHJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(401f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName, FHKKPEIDDJN: true);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMLPPCCDELM()
		{
			return PHDOCKCBJOF;
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(442f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool EEJLFIHFDLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(318f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
		}

		public bool ANIKAJEKMPM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1751f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public bool IBEPOFJDKLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1166f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMAMPDNFNHE()
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
				PHDOCKCBJOF = new WaitForSeconds(20f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1267f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName, FHKKPEIDDJN: true);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1805f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName, FHKKPEIDDJN: true);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void MEKLPMCIMBH()
		{
			throw new NotSupportedException();
		}

		public bool DIFNNJALIPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1607f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = true;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName, FHKKPEIDDJN: true);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(750f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(GameLoginManager.currentPlayer.squadName, FHKKPEIDDJN: true);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(772f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
				{
					if (BJGCPDNMHDH.BKGBIMDJOOF)
					{
						BJGCPDNMHDH.BKGBIMDJOOF = false;
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(GameLoginManager.currentPlayer.squadName);
					}
					goto case 0u;
				}
				BJGCPDNMHDH.EOEHKOPOCNK = null;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public void DECFCNMMOAG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}
	}

	[FormerlySerializedAs("PMAEEIJCAIA")]
	[Header("Members List")]
	public UIPanel CFFKHHJKBMJ;

	[FormerlySerializedAs("ICKPAEEPOBH")]
	public UIDraggablePanel NFLPPGKCOBL;

	[FormerlySerializedAs("JLKKODDOHEF")]
	public GameObject LEIDAILJEGN;

	[FormerlySerializedAs("BCOEAGDCDGC")]
	public UIPooledGrid IKKMIDCIFID;

	[FormerlySerializedAs("NAHEKJAEANB")]
	public MemberRecord IGDMPPIKNLJ;

	[Header("Waiting for server")]
	[FormerlySerializedAs("AGLEKOGCJEN")]
	public UIPanel KDABFAEMNMH;

	[FormerlySerializedAs("FELIFNDLKGH")]
	public UISprite NLAJOOOJNPL;

	private bool IHEPLEBDJCB;

	private List<PANBDDEEANM> KKCPGCBKHHJ = new List<PANBDDEEANM>();

	private int FKIOKBIJPPA;

	private RadicalRoutine EOEHKOPOCNK;

	private bool BKGBIMDJOOF;

	private List<HNKGNMGKMPH> POPGBMLLABG = new List<HNKGNMGKMPH>();

	private int DBMGOLNICDE;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> LGJCBPOPCPA;

	public bool canBePromotedToColeader => DBMGOLNICDE < 3;

	private int NHBNNDKDGKM(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB.skill != NCMHGPNPEJM.skill)
		{
			return NCMHGPNPEJM.skill.CompareTo(HPJFBKEKJHB.skill);
		}
		if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
		{
			return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? (-1) : 0;
		}
		return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
	}

	private bool HMNEAFIFNKD(PANBDDEEANM HDEGOGFCNAC, DatabasePlayer KHLGDCHJJPB)
	{
		if (HDEGOGFCNAC.FJLBLLLEELD == 0 && HDEGOGFCNAC.ALHCNAGDAKH.id == KHLGDCHJJPB.id)
		{
			return true;
		}
		return false;
	}

	private void KOGKOMPPIDH(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MemberRecord component = ENCEFOOPBMK.GetComponent<MemberRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public bool IsPlayerWaitingForServerResponse(string INFLHPGMEOB)
	{
		foreach (HNKGNMGKMPH item in POPGBMLLABG)
		{
			if (item.EJBEDLHIKDG == INFLHPGMEOB)
			{
				return true;
			}
		}
		return false;
	}

	private bool GPDONKMCJEG(PANBDDEEANM HDEGOGFCNAC, DatabasePlayer KHLGDCHJJPB)
	{
		if (HDEGOGFCNAC.FJLBLLLEELD == 0 && HDEGOGFCNAC.ALHCNAGDAKH.id == KHLGDCHJJPB.id)
		{
			return true;
		}
		return false;
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(KDABFAEMNMH.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f);
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					base.gameObject.SetActive(value: false);
					PPMCFMBJJHP();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	private void HACHCDIDAMG(List<DatabasePlayer> FHBAEAOCCDE)
	{
		if (!NLAJOOOJNPL.gameObject.activeSelf)
		{
			PHGOLEBEAPD(FHBAEAOCCDE);
			return;
		}
		IMHFDCLHJGC();
		IKKMIDCIFID.MakeEmpty();
		if (FHBAEAOCCDE == null)
		{
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM == null)
		{
			UnityEngine.Debug.LogError("Current squad information are not in server cache");
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
			return;
		}
		FKIOKBIJPPA = Singleton<GameVariables>.instance.GetSquadRankSize(aANECPGDMGM.IKJHAHJHLIH);
		int num = Mathf.Max(0, FKIOKBIJPPA - FHBAEAOCCDE.Count);
		KKCPGCBKHHJ.Clear();
		int num2 = 0;
		foreach (DatabasePlayer item in FHBAEAOCCDE)
		{
			KKCPGCBKHHJ.Add(PANBDDEEANM.JCDIEDHIKOL(item));
			if (item.GetRealStatus() != PlayerStatus.Offline)
			{
				num2++;
			}
		}
		int num3 = 0;
		List<string> list = new List<string>();
		using (Dictionary<string, AwaitingSquadMembersManager.HJHILHFDMKP>.Enumerator enumerator2 = Singleton<AwaitingSquadMembersManager>.instance.NNIKNEECAMM.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				HLOPEJGKBKI hLOPEJGKBKI = new HLOPEJGKBKI();
				hLOPEJGKBKI.ALHCNAGDAKH = enumerator2.Current;
				if (FHBAEAOCCDE.FindIndex(hLOPEJGKBKI.LJCDGJKCNEC) < 0)
				{
					KKCPGCBKHHJ.Add(PANBDDEEANM.JCDIEDHIKOL(hLOPEJGKBKI.ALHCNAGDAKH.Value.KHLGDCHJJPB));
					num3++;
				}
				else
				{
					list.Add(hLOPEJGKBKI.ALHCNAGDAKH.Key);
				}
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			Singleton<AwaitingSquadMembersManager>.instance.RemovePlayer(list[i]);
		}
		list.Clear();
		int num4 = num - num3;
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		if (aANECPGDMGM.IOLNJBGOOLJ || !flag)
		{
			for (int j = 0; j < num4; j++)
			{
				KKCPGCBKHHJ.Add(PANBDDEEANM.CKDJBOEMADO());
			}
		}
		KKCPGCBKHHJ.Add(PANBDDEEANM.NBBGGNAEABC(Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(aANECPGDMGM.IKJHAHJHLIH), aANECPGDMGM.IKJHAHJHLIH));
		GuiScreenSingle<SquadScreen>.instance.SetMembersButton(aANECPGDMGM.FOICGJEPBGL, FKIOKBIJPPA, num2);
		NLAJOOOJNPL.gameObject.SetActive(value: false);
		IKKMIDCIFID.init(KKCPGCBKHHJ.Count, LMKHBDELHEF, KOGKOMPPIDH, NFLPPGKCOBL);
		NFLPPGKCOBL.AlignToPos(instant: false);
	}

	private void CEDMBMKMOGE()
	{
		if (EOEHKOPOCNK == null)
		{
			EOEHKOPOCNK = RadicalRoutine.Create(CKJOOOLBNDD());
			StartCoroutine(EOEHKOPOCNK.enumerator);
		}
	}

	private void IMHFDCLHJGC()
	{
		if (EOEHKOPOCNK == null)
		{
			EOEHKOPOCNK = RadicalRoutine.Create(CKJOOOLBNDD());
			StartCoroutine(EOEHKOPOCNK.enumerator);
		}
	}

	private Transform LMKHBDELHEF(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < KKCPGCBKHHJ.Count)
		{
			PANBDDEEANM pANBDDEEANM = KKCPGCBKHHJ[DFHAAIFFLOE];
			switch (pANBDDEEANM.FJLBLLLEELD)
			{
			case 0:
			{
				MemberRecord memberRecord2 = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(IGDMPPIKNLJ, IKKMIDCIFID.gameObject, string.Format("{0} Squad Member {1}", DFHAAIFFLOE.ToString("D2"), pANBDDEEANM.ALHCNAGDAKH.name)) as MemberRecord;
				if (memberRecord2 != null)
				{
					memberRecord2.FNHHNELJEPH(pANBDDEEANM.ALHCNAGDAKH, DFHAAIFFLOE + 1);
					return memberRecord2.transform;
				}
				break;
			}
			case 1:
			{
				MemberRecord memberRecord3 = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(IGDMPPIKNLJ, IKKMIDCIFID.gameObject, string.Format("{0} Empty", DFHAAIFFLOE.ToString("D2"))) as MemberRecord;
				if (memberRecord3 != null)
				{
					memberRecord3.HFEIHFBIAHA();
					return memberRecord3.transform;
				}
				break;
			}
			case 2:
			{
				MemberRecord memberRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(IGDMPPIKNLJ, IKKMIDCIFID.gameObject, string.Format("{0} Summary", DFHAAIFFLOE.ToString("D2"))) as MemberRecord;
				if (memberRecord != null)
				{
					memberRecord.MIBBFNNMFDE(pANBDDEEANM.JFHCIILADJL, pANBDDEEANM.FAIFMIDDJME);
					return memberRecord.transform;
				}
				break;
			}
			}
		}
		return null;
	}

	private void ACFDANMKHNG()
	{
		OENPHGCLLDM();
		IKKMIDCIFID.MakeEmpty();
		KKCPGCBKHHJ.Clear();
		POPGBMLLABG.Clear();
	}

	private void CDMOMONPBGJ()
	{
		for (int i = 0; i < IKKMIDCIFID.containItems; i++)
		{
			Transform itemOnIndex = IKKMIDCIFID.GetItemOnIndex(i);
			if (!(itemOnIndex != null))
			{
				continue;
			}
			MemberRecord component = itemOnIndex.GetComponent<MemberRecord>();
			if (component != null)
			{
				component.FreeTexture();
				if (KKCPGCBKHHJ[i].FJLBLLLEELD == 0)
				{
					component.FNHHNELJEPH(KKCPGCBKHHJ[i].ALHCNAGDAKH, i + 1);
				}
				else if (KKCPGCBKHHJ[i].FJLBLLLEELD == 2)
				{
					component.MIBBFNNMFDE(KKCPGCBKHHJ[i].JFHCIILADJL, KKCPGCBKHHJ[i].FAIFMIDDJME);
				}
				else
				{
					component.HFEIHFBIAHA();
				}
			}
		}
	}

	private void CCIFKLOGPMN(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: true);
			PPMCFMBJJHP();
		}
	}

	public void AddAction(DatabaseAction IFGAGNBDKBE, string INFLHPGMEOB)
	{
		POPGBMLLABG.Add(new HNKGNMGKMPH(IFGAGNBDKBE, INFLHPGMEOB));
	}

	private static bool MLCJOMGPPNJ(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	public void InitGUIValues()
	{
		UnityEngine.Debug.Log("Called InitGuiValues in Member Content.");
		NLAJOOOJNPL.gameObject.SetActive(value: true);
		IKKMIDCIFID.MakeEmpty();
		Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(GameLoginManager.currentPlayer.squadName);
	}

	private void OEEBCDKJGCI(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MemberRecord component = ENCEFOOPBMK.GetComponent<MemberRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	public void DFMCKHMFNHO()
	{
		UnityEngine.Debug.Log("Time");
		NLAJOOOJNPL.gameObject.SetActive(value: true);
		IKKMIDCIFID.MakeEmpty();
		Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(GameLoginManager.currentPlayer.squadName);
	}

	public void ServerResponseCame(DatabaseAction IFGAGNBDKBE, string INFLHPGMEOB)
	{
		if (POPGBMLLABG == null || POPGBMLLABG.Count == 0)
		{
			return;
		}
		int index = -1;
		for (int i = 0; i < POPGBMLLABG.Count; i++)
		{
			HNKGNMGKMPH hNKGNMGKMPH = POPGBMLLABG[i];
			if (hNKGNMGKMPH.IFGAGNBDKBE == IFGAGNBDKBE && hNKGNMGKMPH.EJBEDLHIKDG == INFLHPGMEOB)
			{
				index = i;
				break;
			}
		}
		POPGBMLLABG.RemoveAt(index);
	}

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		IHEPLEBDJCB = false;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.MPDPBMIAEMP = (Action)Delegate.Combine(instance.MPDPBMIAEMP, new Action(HLLHNKCAELK));
		float activeWidthSafe = UIHelper.activeWidthSafe;
		int num = (int)UIHelper.activeHeight - 470;
		LEIDAILJEGN.transform.localPosition = LEIDAILJEGN.transform.localPosition.ReplaceX(activeWidthSafe / 2f - 60f);
		CFFKHHJKBMJ.clipRange = CFFKHHJKBMJ.clipRange.ReplaceYW((float)(-num) / 2f, num);
		NFLPPGKCOBL.transform.localPosition = NFLPPGKCOBL.transform.localPosition.ReplaceY(0f);
		IKKMIDCIFID.cellWidth = activeWidthSafe - 120f;
	}

	private static bool BDPFBNEKOLH(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private void OENPHGCLLDM()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (!GuiScreenSingle<SquadScreen>.instance.isShowed || !IHEPLEBDJCB)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.GetAllSquadMembers:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null)
			{
				DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
				int num = list.FindIndex((DatabasePlayer NGKBOFPJNAG) => NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id);
				if (num > -1)
				{
					list[num].playerVisuals = generatedCurrentPlayer.playerVisuals;
					list[num].country = generatedCurrentPlayer.country;
					list[num].level = generatedCurrentPlayer.level;
					list[num].squadRank = generatedCurrentPlayer.squadRank;
					list[num].armyPower = generatedCurrentPlayer.armyPower;
					list[num].leagueTier = generatedCurrentPlayer.leagueTier;
					list[num].beginnersLeague = generatedCurrentPlayer.beginnersLeague;
					list[num].remainingMatches = generatedCurrentPlayer.remainingMatches;
					list[num].skill = generatedCurrentPlayer.skill;
					list[num].visualType = generatedCurrentPlayer.visualType;
					list[num].visualTimestamp = generatedCurrentPlayer.visualTimestamp;
				}
				else
				{
					list.Add(generatedCurrentPlayer);
				}
				DBMGOLNICDE = 0;
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					if (string.IsNullOrEmpty(list[num2].name))
					{
						list.RemoveAt(num2);
					}
					else if (list[num2].squadRank == SquadRank.Coleader)
					{
						DBMGOLNICDE++;
					}
				}
				list.Sort(NHBNNDKDGKM);
			}
			else
			{
				list = new List<DatabasePlayer>();
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			HACHCDIDAMG(list);
			SkipListUpdate();
			break;
		}
		case DatabaseAction.GetSquadDetails:
			if (NLAJOOOJNPL.gameObject.activeSelf)
			{
				InitGUIValues();
			}
			break;
		}
	}

	[CompilerGenerated]
	private static bool OBHEGGJPDHP(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	private void PHGOLEBEAPD(List<DatabasePlayer> FHBAEAOCCDE)
	{
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		if (string.IsNullOrEmpty(generatedCurrentPlayer.squadName))
		{
			UnityEngine.Debug.Log("No longer in squad quit update the squad members");
			OENPHGCLLDM();
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(generatedCurrentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM == null)
		{
			UnityEngine.Debug.Log("no squad details in cache, skip this update");
			return;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < KKCPGCBKHHJ.Count; i++)
		{
			if (KKCPGCBKHHJ[i].FJLBLLLEELD == 0)
			{
				num++;
			}
			if (KKCPGCBKHHJ[i].FJLBLLLEELD == 1)
			{
				num2++;
			}
		}
		Dictionary<string, AwaitingSquadMembersManager.HJHILHFDMKP> dictionary = new Dictionary<string, AwaitingSquadMembersManager.HJHILHFDMKP>();
		using (Dictionary<string, AwaitingSquadMembersManager.HJHILHFDMKP>.Enumerator enumerator = Singleton<AwaitingSquadMembersManager>.instance.NNIKNEECAMM.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				GBOBPBPIINP gBOBPBPIINP = new GBOBPBPIINP();
				gBOBPBPIINP.ALHCNAGDAKH = enumerator.Current;
				if (FHBAEAOCCDE.FindIndex(gBOBPBPIINP.LJCDGJKCNEC) < 0)
				{
					dictionary.Add(gBOBPBPIINP.ALHCNAGDAKH.Key, gBOBPBPIINP.ALHCNAGDAKH.Value);
				}
			}
		}
		int num3 = FHBAEAOCCDE.Count + dictionary.Count;
		FKIOKBIJPPA = Singleton<GameVariables>.instance.GetSquadRankSize(aANECPGDMGM.IKJHAHJHLIH);
		int num4 = FKIOKBIJPPA - FHBAEAOCCDE.Count;
		int num5 = Mathf.Max(0, num4 - dictionary.Count);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
		{
			num5 = 0;
		}
		if (num + num2 != num3 + num5)
		{
			IKKMIDCIFID.MakeEmpty();
			NLAJOOOJNPL.gameObject.SetActive(value: true);
			HACHCDIDAMG(FHBAEAOCCDE);
			return;
		}
		int num6 = 0;
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		foreach (DatabasePlayer item in FHBAEAOCCDE)
		{
			list.Add(item);
			if (item.GetRealStatus() != PlayerStatus.Offline)
			{
				num6++;
			}
		}
		foreach (KeyValuePair<string, AwaitingSquadMembersManager.HJHILHFDMKP> item2 in dictionary)
		{
			list.Add(item2.Value.KHLGDCHJJPB);
		}
		for (int j = 0; j < num3; j++)
		{
			KKCPGCBKHHJ[j].FJLBLLLEELD = 0;
			KKCPGCBKHHJ[j].ALHCNAGDAKH = list[j];
		}
		for (int k = num3; k < num3 + num5; k++)
		{
			KKCPGCBKHHJ[k].FJLBLLLEELD = 1;
		}
		CDMOMONPBGJ();
		GuiScreenSingle<SquadScreen>.instance.SetMembersButton(aANECPGDMGM.FOICGJEPBGL, FKIOKBIJPPA, num6);
	}

	public void KOOIAAFBKDF()
	{
		BKGBIMDJOOF = false;
	}

	public void NHCPLGHKPNI(DatabaseAction IFGAGNBDKBE, string INFLHPGMEOB)
	{
		if (POPGBMLLABG == null || POPGBMLLABG.Count == 0)
		{
			return;
		}
		int index = -1;
		for (int i = 1; i < POPGBMLLABG.Count; i += 0)
		{
			HNKGNMGKMPH hNKGNMGKMPH = POPGBMLLABG[i];
			if (hNKGNMGKMPH.IFGAGNBDKBE == IFGAGNBDKBE && hNKGNMGKMPH.EJBEDLHIKDG == INFLHPGMEOB)
			{
				index = i;
				break;
			}
		}
		POPGBMLLABG.RemoveAt(index);
	}

	public void PDNOCMOJDIG(DatabaseAction IFGAGNBDKBE, string INFLHPGMEOB)
	{
		if (POPGBMLLABG == null || POPGBMLLABG.Count == 0)
		{
			return;
		}
		int index = -1;
		for (int i = 0; i < POPGBMLLABG.Count; i++)
		{
			HNKGNMGKMPH hNKGNMGKMPH = POPGBMLLABG[i];
			if (hNKGNMGKMPH.IFGAGNBDKBE == IFGAGNBDKBE && hNKGNMGKMPH.EJBEDLHIKDG == INFLHPGMEOB)
			{
				index = i;
				break;
			}
		}
		POPGBMLLABG.RemoveAt(index);
	}

	private void HLLHNKCAELK()
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && IHEPLEBDJCB)
		{
			CDMOMONPBGJ();
		}
	}

	public void CDFBHCPDGGG()
	{
		BKGBIMDJOOF = false;
	}

	[CompilerGenerated]
	private void PEELOMCBFDP(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			PPMCFMBJJHP();
		}
	}

	private static bool HECDKJCPPNO(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	[DebuggerHidden]
	private IEnumerator CKJOOOLBNDD()
	{
		ABNBBOGDMIG aBNBBOGDMIG = new ABNBBOGDMIG();
		aBNBBOGDMIG.BJGCPDNMHDH = this;
		return aBNBBOGDMIG;
	}

	public void UpdateShownRecord(string EJBEDLHIKDG)
	{
		for (int i = 0; i < IKKMIDCIFID.containItems; i++)
		{
			Transform itemOnIndex = IKKMIDCIFID.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				MemberRecord component = itemOnIndex.GetComponent<MemberRecord>();
				if (component != null && KKCPGCBKHHJ[i].FJLBLLLEELD == 0 && KKCPGCBKHHJ[i].ALHCNAGDAKH.id == EJBEDLHIKDG)
				{
					component.FNHHNELJEPH(KKCPGCBKHHJ[i].ALHCNAGDAKH, i + 1);
				}
			}
		}
	}

	public void SkipListUpdate()
	{
		BKGBIMDJOOF = true;
	}

	private void PPMCFMBJJHP()
	{
		OENPHGCLLDM();
		IKKMIDCIFID.MakeEmpty();
		KKCPGCBKHHJ.Clear();
		POPGBMLLABG.Clear();
	}

	private void ENPBKEABDLO(List<DatabasePlayer> FHBAEAOCCDE)
	{
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		if (string.IsNullOrEmpty(generatedCurrentPlayer.squadName))
		{
			UnityEngine.Debug.Log("ID_XMEDALSTOADVANCETOY");
			OENPHGCLLDM();
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(generatedCurrentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM == null)
		{
			UnityEngine.Debug.Log("LeagueId");
			return;
		}
		int num = 1;
		int num2 = 1;
		for (int i = 1; i < KKCPGCBKHHJ.Count; i++)
		{
			if (KKCPGCBKHHJ[i].FJLBLLLEELD == 0)
			{
				num++;
			}
			if (KKCPGCBKHHJ[i].FJLBLLLEELD == 0)
			{
				num2++;
			}
		}
		Dictionary<string, AwaitingSquadMembersManager.HJHILHFDMKP> dictionary = new Dictionary<string, AwaitingSquadMembersManager.HJHILHFDMKP>();
		using (Dictionary<string, AwaitingSquadMembersManager.HJHILHFDMKP>.Enumerator enumerator = Singleton<AwaitingSquadMembersManager>.instance.NNIKNEECAMM.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				GBOBPBPIINP gBOBPBPIINP = new GBOBPBPIINP();
				gBOBPBPIINP.ALHCNAGDAKH = enumerator.Current;
				if (FHBAEAOCCDE.FindIndex(gBOBPBPIINP.BBPKDMPNEDG) < 0)
				{
					dictionary.Add(gBOBPBPIINP.ALHCNAGDAKH.Key, gBOBPBPIINP.ALHCNAGDAKH.Value);
				}
			}
		}
		int num3 = FHBAEAOCCDE.Count + dictionary.Count;
		FKIOKBIJPPA = Singleton<GameVariables>.instance.LNDDCADBOLP(aANECPGDMGM.IKJHAHJHLIH);
		int num4 = FKIOKBIJPPA - FHBAEAOCCDE.Count;
		int num5 = Mathf.Max(0, num4 - dictionary.Count);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Veteran;
		if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
		{
			num5 = 0;
		}
		if (num + num2 != num3 + num5)
		{
			IKKMIDCIFID.MakeEmpty();
			NLAJOOOJNPL.gameObject.SetActive(value: false);
			HACHCDIDAMG(FHBAEAOCCDE);
			return;
		}
		int num6 = 1;
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		foreach (DatabasePlayer item in FHBAEAOCCDE)
		{
			list.Add(item);
			if (item.GetRealStatus() != PlayerStatus.Offline)
			{
				num6 += 0;
			}
		}
		foreach (KeyValuePair<string, AwaitingSquadMembersManager.HJHILHFDMKP> item2 in dictionary)
		{
			list.Add(item2.Value.KHLGDCHJJPB);
		}
		for (int j = 0; j < num3; j += 0)
		{
			KKCPGCBKHHJ[j].FJLBLLLEELD = 0;
			KKCPGCBKHHJ[j].ALHCNAGDAKH = list[j];
		}
		for (int k = num3; k < num3 + num5; k += 0)
		{
			KKCPGCBKHHJ[k].FJLBLLLEELD = 1;
		}
		CDMOMONPBGJ();
		GuiScreenSingle<SquadScreen>.instance.SetMembersButton(aANECPGDMGM.FOICGJEPBGL, FKIOKBIJPPA, num6);
	}

	public void InstantHideTab()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		PPMCFMBJJHP();
	}
}
