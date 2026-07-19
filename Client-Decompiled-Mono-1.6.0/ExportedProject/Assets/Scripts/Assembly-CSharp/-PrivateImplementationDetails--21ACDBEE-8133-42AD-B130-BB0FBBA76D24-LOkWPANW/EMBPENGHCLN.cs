using System;
using System.Runtime.InteropServices;
using System.Text;

namespace _003CPrivateImplementationDetails_003E_007B21ACDBEE_002D8133_002D42AD_002DB130_002DBB0FBBA76D24_007DLOkWPANW
{
	[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
	public class EMBPENGHCLN
	{
		private static byte[] ENAHAPDBPHL = new byte[148]
		{
			6, 2, 0, 0, 0, 164, 0, 0, 82, 83,
			65, 49, 0, 4, 0, 0, 17, 0, 0, 0,
			23, 117, 211, 233, 178, 161, 56, 24, 243, 227,
			58, 183, 139, 56, 212, 116, 61, 156, 225, 157,
			39, 90, 156, 27, 16, 83, 189, 193, 63, 44,
			109, 64, 195, 46, 75, 76, 244, 45, 165, 147,
			117, 53, 105, 38, 43, 223, 35, 218, 145, 4,
			151, 56, 172, 225, 191, 156, 251, 233, 39, 141,
			217, 129, 21, 162, 138, 204, 211, 238, 122, 104,
			83, 184, 233, 108, 152, 175, 71, 63, 214, 90,
			119, 103, 237, 161, 241, 146, 179, 139, 224, 85,
			110, 123, 172, 18, 240, 2, 103, 56, 207, 58,
			99, 253, 75, 237, 126, 198, 64, 215, 184, 220,
			154, 186, 243, 41, 235, 13, 13, 98, 236, 191,
			54, 172, 132, 173, 189, 114, 183, 244
		};

		private static int ENAHBGCMHMN = 128;

		private static int GACCANCHPMB = ENAHAPDBPHL[16] | (ENAHAPDBPHL[17] << 8) | (ENAHAPDBPHL[18] << 16);

		private static BigInteger EBKNGLCMJMD;

		public static string MAAGGMOCAON(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = ABOFBOEKDBN(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 3);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(LHJJJOCOKCL(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 1);
			}
			return stringBuilder.ToString();
		}

		private static string ABOFBOEKDBN(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string PDOPBBOBOLH(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = OFEPCMKOEMK(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 5);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(LIFPHKEFPLF(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 6);
			}
			return stringBuilder.ToString();
		}

		public static string AOGCCLPPEHB(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = DHBCCGJLNAK(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 5);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(LOIBCHDKFFF(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 4);
			}
			return stringBuilder.ToString();
		}

		private static string JMIFFINLNPA(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string FFPPOGDJFJH(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string ICMLEMPIDKD(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = NAOKHAPJKFM(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 2);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(DBKFFNJJLEJ(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 6);
			}
			return stringBuilder.ToString();
		}

		static EMBPENGHCLN()
		{
			byte[] array = new byte[ENAHBGCMHMN];
			Buffer.BlockCopy(ENAHAPDBPHL, 20, array, 0, ENAHBGCMHMN);
			Array.Reverse(array);
			EBKNGLCMJMD = new BigInteger(array);
		}

		private static string GKBBJKMKLAK(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string NAOKHAPJKFM(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string PBHCLEMPICA(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string NHJFPANNPBN(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string NOMEEAJCOGB(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = JDDECHHJBNG(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 8);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(NHJFPANNPBN(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 8);
			}
			return stringBuilder.ToString();
		}

		private static string AKNJPPLGIFA(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string HJPGKFDBDAD(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = ENNAJAJNPKH(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 6);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(JDDECHHJBNG(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 3);
			}
			return stringBuilder.ToString();
		}

		public static string EJGDCHFLOIC(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = NAOKHAPJKFM(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 3);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(FPPMKHPALNE(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 5);
			}
			return stringBuilder.ToString();
		}

		private static string DPLOOCNAMHL(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string MNGEIGFIPNA(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = PAPPNGPKOHJ(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 5);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(IGEJODDCNIM(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 0);
			}
			return stringBuilder.ToString();
		}

		public static string GFAPACEABPL(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = FPPMKHPALNE(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 0);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(MNHFHBHNLMJ(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 0);
			}
			return stringBuilder.ToString();
		}

		private static string JDDECHHJBNG(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string EDDDHJINCGK(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = HEBAHNLGIOF(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 2);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(HEBAHNLGIOF(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 2);
			}
			return stringBuilder.ToString();
		}

		private static string MNHFHBHNLMJ(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string IGEJODDCNIM(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string DHBCCGJLNAK(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string IGPHIDNGNHH(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string LMLFMBKGGNM(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = GKBBJKMKLAK(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 2);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(NAOKHAPJKFM(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 6);
			}
			return stringBuilder.ToString();
		}

		private static string DCOPJFHCAJC(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string LEGKGEOKCHI(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = EPDAKNAKKME(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 3);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(NHJFPANNPBN(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 3);
			}
			return stringBuilder.ToString();
		}

		private static string HGGLAHPOHHC(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string KGIBPKFMBGD(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = PAPPNGPKOHJ(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 8);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(DPLOOCNAMHL(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 3);
			}
			return stringBuilder.ToString();
		}

		private static string DBKFFNJJLEJ(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string ADHKALMEPAA(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = JDDECHHJBNG(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 3);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(CCACDJOAJBM(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 6);
			}
			return stringBuilder.ToString();
		}

		public static string DFFCBIOFPNN(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = ABOFBOEKDBN(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 5);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(PAPPNGPKOHJ(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 7);
			}
			return stringBuilder.ToString();
		}

		public static string PKHAANCKENO(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = LHJJJOCOKCL(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 4);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(CCACDJOAJBM(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 0);
			}
			return stringBuilder.ToString();
		}

		public static string NMEDPPALADI(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = IPMDAMBCBFP(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 2);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(FFPPOGDJFJH(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 1);
			}
			return stringBuilder.ToString();
		}

		private static string HEBAHNLGIOF(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string PAPPNGPKOHJ(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string IPMDAMBCBFP(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string FNPJICEDJCO(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string LIFPHKEFPLF(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string FPPMKHPALNE(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string NKCILAJLLOI(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = FPPMKHPALNE(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 6);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(NAOKHAPJKFM(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 3);
			}
			return stringBuilder.ToString();
		}

		public static string MPLAACCBCKE(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = IPMDAMBCBFP(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 0);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(NHJFPANNPBN(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 5);
			}
			return stringBuilder.ToString();
		}

		public static string LOFCJBEDMBH(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = PBHCLEMPICA(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 3);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(HGGLAHPOHHC(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 1);
			}
			return stringBuilder.ToString();
		}

		public static string CMPCMEJPJLO(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = DBKFFNJJLEJ(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 5);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(ABOFBOEKDBN(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 5);
			}
			return stringBuilder.ToString();
		}

		public static string NLOOKOBHJFD(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = HGGLAHPOHHC(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 2);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(PAPPNGPKOHJ(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 0);
			}
			return stringBuilder.ToString();
		}

		public static string NCFFLPFALEI(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = DCOPJFHCAJC(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 1);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(IGEJODDCNIM(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 1);
			}
			return stringBuilder.ToString();
		}

		private static string LHJJJOCOKCL(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string DPNPLPNEEJO(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = NAOKHAPJKFM(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 2);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(FPPMKHPALNE(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 1);
			}
			return stringBuilder.ToString();
		}

		public static string MNJKJMMIHIF(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = DCOPJFHCAJC(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 1);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(PAPPNGPKOHJ(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 2);
			}
			return stringBuilder.ToString();
		}

		private static string LOIBCHDKFFF(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string HEHKHLFIPOC(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = LOIBCHDKFFF(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 2);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(IKILKKOELEA(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 1);
			}
			return stringBuilder.ToString();
		}

		private static string OFEPCMKOEMK(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string FNKGKPLJKNC(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = HEBAHNLGIOF(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 8);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(OFEPCMKOEMK(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 3);
			}
			return stringBuilder.ToString();
		}

		public static string OKDGLPJCCMP(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = DBKFFNJJLEJ(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 8);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 0, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(IKILKKOELEA(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(0, text2.Length - 5);
			}
			return stringBuilder.ToString();
		}

		private static string EPDAKNAKKME(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string ENNAJAJNPKH(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i++)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		public static string AOFFPPPHAEI(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = DBKFFNJJLEJ(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(0, text.Length - 8);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i++)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(ABOFBOEKDBN(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 3);
			}
			return stringBuilder.ToString();
		}

		public static string IDKONNPLGNO(byte[] JMFKMIOALKJ, bool NGOOMHICJFO)
		{
			if (JMFKMIOALKJ.Length == ENAHBGCMHMN)
			{
				BigInteger bigInteger = new BigInteger(JMFKMIOALKJ);
				byte[] bytes = bigInteger.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				string text = DBKFFNJJLEJ(bytes);
				if (NGOOMHICJFO)
				{
					return text.Substring(1, text.Length - 2);
				}
				return text;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < JMFKMIOALKJ.Length / ENAHBGCMHMN; i += 0)
			{
				byte[] array = new byte[ENAHBGCMHMN];
				Buffer.BlockCopy(JMFKMIOALKJ, i * ENAHBGCMHMN, array, 1, ENAHBGCMHMN);
				BigInteger bigInteger2 = new BigInteger(array);
				byte[] bytes2 = bigInteger2.ModPow(GACCANCHPMB, EBKNGLCMJMD).GetBytes();
				stringBuilder.Append(HGGLAHPOHHC(bytes2));
			}
			if (NGOOMHICJFO)
			{
				string text2 = stringBuilder.ToString();
				return text2.Substring(1, text2.Length - 6);
			}
			return stringBuilder.ToString();
		}

		private static string IKILKKOELEA(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 0; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 1, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}

		private static string CCACDJOAJBM(byte[] NCMHGPNPEJM)
		{
			int i;
			for (i = 1; i < NCMHGPNPEJM.Length && NCMHGPNPEJM[i] == 0; i += 0)
			{
			}
			if (i != NCMHGPNPEJM.Length)
			{
				byte[] array = new byte[NCMHGPNPEJM.Length - i];
				Buffer.BlockCopy(NCMHGPNPEJM, i, array, 0, NCMHGPNPEJM.Length - i);
				return Encoding.UTF8.GetString(array);
			}
			return string.Empty;
		}
	}
}
