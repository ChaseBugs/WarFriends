using System;

namespace TuneSDK
{
	internal struct FALEFGOPNKL
	{
		public string MHPNDNJDPGE;

		public string LPMMABJCMOB;

		public string ADNDMABPHOH;

		public string AFIDFAOIFGH;

		public string MDENIIHCMOA;

		public string PPAKGJCEACD;

		public string CKMLJJGFNAN;

		public string BCCDDJMPBLL;

		public string GHJBDNGEJIM;

		public string JFJKBJHKFII;

		public string JNFONCDHKPK;

		public string ENIAFFIDHHC;

		public string BONGHGPIOAA;

		public string HENAJIMFKEG;

		public string CHFKJGEKNCL;

		public string HAJIBLIIBFB;

		public string JBLMNGCGCEH;

		public string NIJPEPNLEDJ;

		private FALEFGOPNKL(int NBDHCDODKNK, int PFAJENCMBHK)
		{
			MHPNDNJDPGE = null;
			LPMMABJCMOB = null;
			ADNDMABPHOH = null;
			AFIDFAOIFGH = null;
			MDENIIHCMOA = null;
			PPAKGJCEACD = null;
			CKMLJJGFNAN = null;
			BCCDDJMPBLL = null;
			GHJBDNGEJIM = null;
			JFJKBJHKFII = null;
			JNFONCDHKPK = null;
			ENIAFFIDHHC = null;
			BONGHGPIOAA = null;
			HENAJIMFKEG = null;
			CHFKJGEKNCL = null;
			HAJIBLIIBFB = null;
			JBLMNGCGCEH = null;
			NIJPEPNLEDJ = null;
		}

		public FALEFGOPNKL(string MHPNDNJDPGE)
			: this(0, 0)
		{
			this.MHPNDNJDPGE = MHPNDNJDPGE;
		}

		public FALEFGOPNKL(GGOFOCDJIFM JJMEOFFKKJN)
		{
			MHPNDNJDPGE = JJMEOFFKKJN.MHPNDNJDPGE;
			AFIDFAOIFGH = JJMEOFFKKJN.AFIDFAOIFGH;
			HENAJIMFKEG = JJMEOFFKKJN.HENAJIMFKEG;
			CHFKJGEKNCL = JJMEOFFKKJN.CHFKJGEKNCL;
			HAJIBLIIBFB = JJMEOFFKKJN.HAJIBLIIBFB;
			JBLMNGCGCEH = JJMEOFFKKJN.JBLMNGCGCEH;
			NIJPEPNLEDJ = JJMEOFFKKJN.NIJPEPNLEDJ;
			CKMLJJGFNAN = ((JJMEOFFKKJN.CKMLJJGFNAN != null) ? JJMEOFFKKJN.CKMLJJGFNAN.ToString() : null);
			PPAKGJCEACD = JJMEOFFKKJN.PPAKGJCEACD;
			ADNDMABPHOH = JJMEOFFKKJN.ADNDMABPHOH;
			int? bCCDDJMPBLL = JJMEOFFKKJN.BCCDDJMPBLL;
			BCCDDJMPBLL = (bCCDDJMPBLL.HasValue ? JJMEOFFKKJN.BCCDDJMPBLL.ToString() : null);
			int? gHJBDNGEJIM = JJMEOFFKKJN.GHJBDNGEJIM;
			GHJBDNGEJIM = (gHJBDNGEJIM.HasValue ? JJMEOFFKKJN.GHJBDNGEJIM.ToString() : null);
			double? jNFONCDHKPK = JJMEOFFKKJN.JNFONCDHKPK;
			JNFONCDHKPK = (jNFONCDHKPK.HasValue ? JJMEOFFKKJN.JNFONCDHKPK.ToString() : null);
			double? lPMMABJCMOB = JJMEOFFKKJN.LPMMABJCMOB;
			LPMMABJCMOB = (lPMMABJCMOB.HasValue ? JJMEOFFKKJN.LPMMABJCMOB.ToString() : null);
			JFJKBJHKFII = JJMEOFFKKJN.JFJKBJHKFII;
			int? mDENIIHCMOA = JJMEOFFKKJN.MDENIIHCMOA;
			MDENIIHCMOA = (mDENIIHCMOA.HasValue ? JJMEOFFKKJN.MDENIIHCMOA.ToString() : null);
			ENIAFFIDHHC = null;
			BONGHGPIOAA = null;
			DateTime dateTime = new DateTime(1970, 1, 1);
			if (JJMEOFFKKJN.ENIAFFIDHHC.HasValue)
			{
				TimeSpan timeSpan = new TimeSpan(JJMEOFFKKJN.ENIAFFIDHHC.Value.Ticks);
				double totalMilliseconds = timeSpan.TotalMilliseconds;
				ENIAFFIDHHC = (totalMilliseconds - new TimeSpan(dateTime.Ticks).TotalMilliseconds).ToString();
			}
			if (JJMEOFFKKJN.BONGHGPIOAA.HasValue)
			{
				TimeSpan timeSpan2 = new TimeSpan(JJMEOFFKKJN.BONGHGPIOAA.Value.Ticks);
				double totalMilliseconds2 = timeSpan2.TotalMilliseconds;
				BONGHGPIOAA = (totalMilliseconds2 - new TimeSpan(dateTime.Ticks).TotalMilliseconds).ToString();
			}
		}
	}
}
