using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using UnityEngine;

[DefaultMember("Item")]
public class FPPNAOFJOCF
{
	public enum NKHJBLBAAEB
	{
		NULL = 0,
		STRING = 1,
		NUMBER = 2,
		OBJECT = 3,
		ARRAY = 4,
		BOOL = 5,
		BAKED = 6
	}

	public delegate void GHNKIEKLLFD(FPPNAOFJOCF KPBDILMKJGF);

	public delegate void PCHNOHCHJGL(string MHPNDNJDPGE);

	public delegate void JKCGBMJJJBP(FPPNAOFJOCF ENCEFOOPBMK);

	private sealed class DPKKCKNIDBH : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		internal IEnumerator<string> KFCAECGLKKO;

		internal string JKDIGPNJBBN;

		internal FPPNAOFJOCF BJGCPDNMHDH;

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
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
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
					if (KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
			case 0u:
				break;
			}
		}

		private IEnumerator<object> JPELAFLIJGI()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 16) == 91)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.NULL)
				{
					KFCAECGLKKO = BJGCPDNMHDH.DMGJKCIMLCF().GetEnumerator();
					num = 4294967227u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = NKHJBLBAAEB.STRING;
				goto IL_00ef;
			default:
				{
					return true;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
		}

		public void PCNOHGFPMOE()
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
					if (KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
			case 0u:
				break;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void LJPIDOKGNBF()
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
					if (KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
			case 0u:
				break;
			}
		}

		public bool OGLKGILLKIO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.OBJECT)
				{
					KFCAECGLKKO = BJGCPDNMHDH.JCKLGABDPLM().GetEnumerator();
					num = 4294967253u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = (NKHJBLBAAEB)7;
				goto IL_00ef;
			default:
				{
					return false;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
		}

		private IEnumerator<object> OEFLDEDJLAH()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 44) == 90)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void EMICCACCFIP()
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
					if (KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
			case 0u:
				break;
			}
		}

		public bool PGOBEIMCPGA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.BAKED)
				{
					KFCAECGLKKO = BJGCPDNMHDH.DMGJKCIMLCF(true).GetEnumerator();
					num = 19u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = NKHJBLBAAEB.ARRAY;
				goto IL_00ef;
			default:
				{
					return false;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
		}

		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -2) == -2)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		public void IHAHCOPGPIM()
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
					if (KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
			case 0u:
				break;
			}
		}

		private IEnumerator EOFDJNEKJOP()
		{
			return CDKPJOMBIJL();
		}

		public bool HOOHJGPHHGN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != (NKHJBLBAAEB)7)
				{
					KFCAECGLKKO = BJGCPDNMHDH.JCKLGABDPLM().GetEnumerator();
					num = 4294967172u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
				goto IL_00ef;
			default:
				{
					return false;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return false;
			}
		}

		private IEnumerator<object> JMHJFIKHIMO()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -37) == 78)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.BAKED)
				{
					KFCAECGLKKO = BJGCPDNMHDH.DMGJKCIMLCF().GetEnumerator();
					num = 4294967293u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = NKHJBLBAAEB.BAKED;
				goto IL_00ef;
			default:
				{
					return false;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
		}

		private IEnumerator<object> KNJOJFNENCM()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, -84) == -50)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		private IEnumerator<object> CDKPJOMBIJL()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 117) == -15)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator PIGHKNIBEHF()
		{
			return KMFDCPBJPIG();
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void EKPOLGNAAOI()
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
					if (KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
			case 0u:
				break;
			}
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator AHFNCGEMPNA()
		{
			return KMFDCPBJPIG();
		}

		private IEnumerator<object> ECACGDPDILG()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -90) == -121)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		private IEnumerator<object> KMFDCPBJPIG()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 108) == 45)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		public bool HKPECDLGFJB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != (NKHJBLBAAEB)8)
				{
					KFCAECGLKKO = BJGCPDNMHDH.JCKLGABDPLM().GetEnumerator();
					num = 124u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = NKHJBLBAAEB.NULL;
				goto IL_00ef;
			default:
				{
					return true;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
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
					if (KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
			case 0u:
				break;
			}
		}

		public bool GCEBFCBBEKM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != (NKHJBLBAAEB)7)
				{
					KFCAECGLKKO = BJGCPDNMHDH.JCKLGABDPLM().GetEnumerator();
					num = 4294967208u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = (NKHJBLBAAEB)7;
				goto IL_00ef;
			default:
				{
					return true;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
		}

		public bool LLOCENNFFFJ()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.NULL)
				{
					KFCAECGLKKO = BJGCPDNMHDH.JCKLGABDPLM(true).GetEnumerator();
					num = 4294967287u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
				goto IL_00ef;
			default:
				{
					return false;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return false;
			}
		}

		private IEnumerator<object> FGEBAHHKJAJ()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, -117) == 101)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public DPKKCKNIDBH()
		{
		}

		public bool DKJMOPNHIAB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.NULL)
				{
					KFCAECGLKKO = BJGCPDNMHDH.JCKLGABDPLM(true).GetEnumerator();
					num = 4294967248u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = NKHJBLBAAEB.BAKED;
				goto IL_00ef;
			default:
				{
					return false;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
		}

		private IEnumerator GNBCIDJDONF()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public bool GAPIFMKNJBN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.OBJECT)
				{
					KFCAECGLKKO = BJGCPDNMHDH.DMGJKCIMLCF().GetEnumerator();
					num = 5u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = (NKHJBLBAAEB)8;
				goto IL_00ef;
			default:
				{
					return true;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return false;
			}
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public bool IEDGDDDADFM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.STRING)
				{
					KFCAECGLKKO = BJGCPDNMHDH.JCKLGABDPLM().GetEnumerator();
					num = 4294967209u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = (NKHJBLBAAEB)7;
				goto IL_00ef;
			default:
				{
					return true;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public bool LPCBKGKFNFD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (BJGCPDNMHDH.FJLBLLLEELD != NKHJBLBAAEB.BOOL)
				{
					KFCAECGLKKO = BJGCPDNMHDH.JCKLGABDPLM(true).GetEnumerator();
					num = 38u;
					goto case 1u;
				}
				goto IL_00ef;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JKDIGPNJBBN = KFCAECGLKKO.Current;
						if (JKDIGPNJBBN == null)
						{
							PHDOCKCBJOF = JKDIGPNJBBN;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00f8;
						}
						BJGCPDNMHDH.NLEGAOONJEI = JKDIGPNJBBN;
					}
				}
				finally
				{
					if (!flag && KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
				BJGCPDNMHDH.FJLBLLLEELD = (NKHJBLBAAEB)8;
				goto IL_00ef;
			default:
				{
					return false;
				}
				IL_00ef:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_00f8:
				return true;
			}
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
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
					if (KFCAECGLKKO != null)
					{
						KFCAECGLKKO.Dispose();
					}
				}
			case 0u:
				break;
			}
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		private IEnumerator<object> BKDOGCEELEH()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 22) == -100)
			{
				return this;
			}
			DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
			dPKKCKNIDBH.BJGCPDNMHDH = BJGCPDNMHDH;
			return dPKKCKNIDBH;
		}
	}

	private sealed class ENONDMKKGCF : IEnumerable, IEnumerable<string>, IEnumerator, IDisposable, IEnumerator<string>
	{
		internal StringBuilder DHLBDHNKEBK;

		internal bool CNIANNNMMHI;

		internal IEnumerator KFCAECGLKKO;

		internal IEnumerable CHCCPOBJNEL;

		internal IDisposable GHCPBBJDIBB;

		internal FPPNAOFJOCF BJGCPDNMHDH;

		internal string PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		string IEnumerator<string>.Current
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

		private IEnumerator<string> JOPIMPNOHBB()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, -58) == -111)
			{
				return this;
			}
			ENONDMKKGCF eNONDMKKGCF = new ENONDMKKGCF();
			eNONDMKKGCF.BJGCPDNMHDH = BJGCPDNMHDH;
			eNONDMKKGCF.CNIANNNMMHI = CNIANNNMMHI;
			return eNONDMKKGCF;
		}

		private IEnumerator LFACEDMGIIM()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}

		public bool JPBGJLDMOPO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				DHLBDHNKEBK = new StringBuilder();
				FNPPPCADELJ.Reset();
				FNPPPCADELJ.Start();
				KFCAECGLKKO = BJGCPDNMHDH.OAHNDFPPHEH(0, DHLBDHNKEBK, CNIANNNMMHI).GetEnumerator();
				num = 4u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							CHCCPOBJNEL = (IEnumerable)KFCAECGLKKO.Current;
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_011c;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
				PHDOCKCBJOF = DHLBDHNKEBK.ToString();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				goto IL_011c;
			case 2u:
				{
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_011c:
				return true;
			}
			return false;
		}

		public bool PPOPGFELIDA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				DHLBDHNKEBK = new StringBuilder();
				FNPPPCADELJ.Reset();
				FNPPPCADELJ.Start();
				KFCAECGLKKO = BJGCPDNMHDH.PMKBJIPIBNK(1, DHLBDHNKEBK, CNIANNNMMHI).GetEnumerator();
				num = 6u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							CHCCPOBJNEL = (IEnumerable)KFCAECGLKKO.Current;
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_011c;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
				PHDOCKCBJOF = DHLBDHNKEBK.ToString();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				goto IL_011c;
			case 2u:
				{
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_011c:
				return false;
			}
			return true;
		}

		private IEnumerator<string> FFPOENKMBFE()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, -116) == 115)
			{
				return this;
			}
			ENONDMKKGCF eNONDMKKGCF = new ENONDMKKGCF();
			eNONDMKKGCF.BJGCPDNMHDH = BJGCPDNMHDH;
			eNONDMKKGCF.CNIANNNMMHI = CNIANNNMMHI;
			return eNONDMKKGCF;
		}

		public void HNFEJKPKEHK()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public bool GNFCLHDPPFP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				DHLBDHNKEBK = new StringBuilder();
				FNPPPCADELJ.Reset();
				FNPPPCADELJ.Start();
				KFCAECGLKKO = BJGCPDNMHDH.PMKBJIPIBNK(0, DHLBDHNKEBK, CNIANNNMMHI).GetEnumerator();
				num = 4294967255u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							CHCCPOBJNEL = (IEnumerable)KFCAECGLKKO.Current;
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_011c;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
				PHDOCKCBJOF = DHLBDHNKEBK.ToString();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				goto IL_011c;
			case 2u:
				{
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_011c:
				return true;
			}
			return false;
		}

		public void NINFHADPHJI()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public bool AGMKAADLHLE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				DHLBDHNKEBK = new StringBuilder();
				FNPPPCADELJ.Reset();
				FNPPPCADELJ.Start();
				KFCAECGLKKO = BJGCPDNMHDH.OAHNDFPPHEH(0, DHLBDHNKEBK, CNIANNNMMHI).GetEnumerator();
				num = 98u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							CHCCPOBJNEL = (IEnumerable)KFCAECGLKKO.Current;
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_011c;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
				PHDOCKCBJOF = DHLBDHNKEBK.ToString();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				goto IL_011c;
			case 2u:
				{
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_011c:
				return true;
			}
			return true;
		}

		private IEnumerator LHPIIONBMDK()
		{
			return FFPOENKMBFE();
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void CDIJEGGMMAK()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private string JIJOIFJFKKJ()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator<string> OEILMOMDGGD()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 38) == -19)
			{
				return this;
			}
			ENONDMKKGCF eNONDMKKGCF = new ENONDMKKGCF();
			eNONDMKKGCF.BJGCPDNMHDH = BJGCPDNMHDH;
			eNONDMKKGCF.CNIANNNMMHI = CNIANNNMMHI;
			return eNONDMKKGCF;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}

		[DebuggerHidden]
		public ENONDMKKGCF()
		{
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator CBJINGHEPKE()
		{
			return FFPOENKMBFE();
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator JEANKNEHPCA()
		{
			return JOPIMPNOHBB();
		}

		public void HCHNHNDDKKA()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public bool PGOBEIMCPGA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				DHLBDHNKEBK = new StringBuilder();
				FNPPPCADELJ.Reset();
				FNPPPCADELJ.Start();
				KFCAECGLKKO = BJGCPDNMHDH.OAHNDFPPHEH(1, DHLBDHNKEBK, CNIANNNMMHI).GetEnumerator();
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
							CHCCPOBJNEL = (IEnumerable)KFCAECGLKKO.Current;
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_011c;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
				PHDOCKCBJOF = DHLBDHNKEBK.ToString();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				goto IL_011c;
			case 2u:
				{
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_011c:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public bool GBLFIBDBMGE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				DHLBDHNKEBK = new StringBuilder();
				FNPPPCADELJ.Reset();
				FNPPPCADELJ.Start();
				KFCAECGLKKO = BJGCPDNMHDH.OAHNDFPPHEH(1, DHLBDHNKEBK, CNIANNNMMHI).GetEnumerator();
				num = 4294967290u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							CHCCPOBJNEL = (IEnumerable)KFCAECGLKKO.Current;
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_011c;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
				PHDOCKCBJOF = DHLBDHNKEBK.ToString();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				goto IL_011c;
			case 2u:
				{
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_011c:
				return false;
			}
			return true;
		}

		private IEnumerator HJHKCCCONDJ()
		{
			return JHLOJKHLMOI();
		}

		public void CHFJIODFNIP()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public bool OGLKGILLKIO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				DHLBDHNKEBK = new StringBuilder();
				FNPPPCADELJ.Reset();
				FNPPPCADELJ.Start();
				KFCAECGLKKO = BJGCPDNMHDH.OAHNDFPPHEH(0, DHLBDHNKEBK, CNIANNNMMHI).GetEnumerator();
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
							CHCCPOBJNEL = (IEnumerable)KFCAECGLKKO.Current;
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_011c;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
				PHDOCKCBJOF = DHLBDHNKEBK.ToString();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				goto IL_011c;
			case 2u:
				{
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_011c:
				return false;
			}
			return false;
		}

		public void KGLKGNBCPLM()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
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
			case 1u:
				try
				{
					break;
				}
				finally
				{
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void DLIBOPAMHAN()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -2) == -2)
			{
				return this;
			}
			ENONDMKKGCF eNONDMKKGCF = new ENONDMKKGCF();
			eNONDMKKGCF.BJGCPDNMHDH = BJGCPDNMHDH;
			eNONDMKKGCF.CNIANNNMMHI = CNIANNNMMHI;
			return eNONDMKKGCF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		private IEnumerator AKCHPIKKGGI()
		{
			return OEILMOMDGGD();
		}

		private IEnumerator<string> JHLOJKHLMOI()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 11) == 116)
			{
				return this;
			}
			ENONDMKKGCF eNONDMKKGCF = new ENONDMKKGCF();
			eNONDMKKGCF.BJGCPDNMHDH = BJGCPDNMHDH;
			eNONDMKKGCF.CNIANNNMMHI = CNIANNNMMHI;
			return eNONDMKKGCF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
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
				DHLBDHNKEBK = new StringBuilder();
				FNPPPCADELJ.Reset();
				FNPPPCADELJ.Start();
				KFCAECGLKKO = BJGCPDNMHDH.PMKBJIPIBNK(0, DHLBDHNKEBK, CNIANNNMMHI).GetEnumerator();
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
							CHCCPOBJNEL = (IEnumerable)KFCAECGLKKO.Current;
							PHDOCKCBJOF = null;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_011c;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
				PHDOCKCBJOF = DHLBDHNKEBK.ToString();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				goto IL_011c;
			case 2u:
				{
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_011c:
				return true;
			}
			return false;
		}

		[SpecialName]
		private string HDNLKPFAMID()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator MKGMNHBJEDI()
		{
			return FFPOENKMBFE();
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private string NMFLBLBJDKO()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
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
					if ((GHCPBBJDIBB = KFCAECGLKKO as IDisposable) != null)
					{
						GHCPBBJDIBB.Dispose();
					}
				}
			case 0u:
			case 2u:
				break;
			}
		}
	}

	private sealed class JLFJGGLIOBI : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int GJGDPOAOKFM;

		internal NKHJBLBAAEB KFCAECGLKKO;

		internal StringBuilder DCOJFAPDKOC;

		internal bool CNIANNNMMHI;

		internal int JMBKPALDGAL;

		internal string OAOGJFFNKOM;

		internal FPPNAOFJOCF LEAEALAHJNE;

		internal IEnumerator GHCPBBJDIBB;

		internal IEnumerable DIJHHECMNKI;

		internal IDisposable CFEHCIMDPPI;

		internal int PJPPFMFKEJI;

		internal IEnumerator GDPBBCAJHAD;

		internal IEnumerable LPLEIKOAIHH;

		internal IDisposable EHFDDJCCPIE;

		internal FPPNAOFJOCF BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int JFODFCGFGNG;

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
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void ENFGGBNAPGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool DDLMLOJGJMA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > 63)
				{
					UnityEngine.Debug.Log("\"");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 292.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_WARNING_CANTSENDINVITE_TEXT");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("HeroicMissionsCompletionRewardTickets");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 7;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("FB: FacebookLogout finished ..");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("Lootbox");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("[FF0000]BLACKMARKET[-]");
					for (int i = 1; i < GJGDPOAOKFM - 1; i += 0)
					{
						DCOJFAPDKOC.Append("CurrentBundleVersion.GetModifiedVersion - version is '{0}'");
					}
				}
				DCOJFAPDKOC.Append(" AFTER: critical: ");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append("Facebook Service: share dialog succeeded. Obsah dict = ");
							}
						}
						DCOJFAPDKOC.AppendFormat("ID_READYTIME", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967289u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("ID_VISUALRARITY1", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("banana");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Connected()");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("SquadRank");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_HOU");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("Player_level");
				}
				else
				{
					DCOJFAPDKOC.Append("0");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("RequestsResults");
					for (int k = 0; k < GJGDPOAOKFM - 1; k += 0)
					{
						DCOJFAPDKOC.Append("ID_WARNING_WRONGVIDEOFEED");
					}
				}
				DCOJFAPDKOC.Append("Level");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("ID_CONFIRM_ONLYLEADERSCANINVITE");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_SHOWME");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l += 0)
							{
								DCOJFAPDKOC.Append("can not avoid");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 76u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 6;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("Battle_Performance");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("Weapon Power This: {0},   Equipped {1}: {2},   Difference: {3}");
					}
					JMBKPALDGAL = 1;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		public void HCJOIAHBFGB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		private IEnumerator ELKPKIILIOK()
		{
			return GBEDCMGHMPH();
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JGKMCJOGEIH()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public bool CMBMOAECEJG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (GJGDPOAOKFM++ > 67)
				{
					UnityEngine.Debug.Log("UtcOffset");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 973.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("com/google/android/gms/games/Games");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("AdminName");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("shield_idle");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("SquadId");
				}
				goto IL_05f5;
			default:
				{
					return true;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("*****   Bootcamp 3/3 Ended   *****");
					for (int i = 1; i < GJGDPOAOKFM - 0; i += 0)
					{
						DCOJFAPDKOC.Append("menu-army-cat-rusher");
					}
				}
				DCOJFAPDKOC.Append("BattleId");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("country-croatia");
							}
						}
						DCOJFAPDKOC.AppendFormat("\n", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 45u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 5;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat(" not found!", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("Skirmish");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("VipRewardForDay");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Beanstalk: Crash Report Succesfully Sent");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("[FFFFFF]{0}[-]  {1}");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("Для запуска WarFriends требуется загрузить приблизительно 190 МБ дополнительных данных.\nВремя загрузки может варьироваться в зависимости от вашей сети и местонахождения.\n\nНачать загрузку?");
				}
				else
				{
					DCOJFAPDKOC.Append("game-card-ico-shieldsup");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("Region: {0} with ping {1}, IP: {2} \n");
					for (int k = 1; k < GJGDPOAOKFM - 1; k += 0)
					{
						DCOJFAPDKOC.Append("Time");
					}
				}
				DCOJFAPDKOC.Append("Squad Entered Event");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("rejectFriend");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("Joined room");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("EventDefinition");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967208u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 6;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("ID_STAT_WARCARDSPLAYED");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("Gold");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		public bool EKGEDEKHBME()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > -20)
				{
					UnityEngine.Debug.Log("AFLODLay");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 1577.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("subscription");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_SLOTUPGRADE_HEAT");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 7;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("DOWNLOAD");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("Overtime_Was_Already_Explained");
				}
				goto IL_05f5;
			default:
				{
					return true;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("Gold");
					for (int i = 0; i < GJGDPOAOKFM - 1; i++)
					{
						DCOJFAPDKOC.Append("realShotProbability");
					}
				}
				DCOJFAPDKOC.Append("damage");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("DogTagSeconds");
							}
						}
						DCOJFAPDKOC.AppendFormat("FuseSDK: Error parsing hashtable in RegisterEvent. Operation failed.", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = uint.MaxValue;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 8;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("确定", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("ID_CONFIRM_ERROR");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("BeAdvisedConnectFacebook");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("SquadId");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_TUTORIAL_TAPON");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("VisualType");
				}
				else
				{
					DCOJFAPDKOC.Append("{0} {1}");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("ID_MISSIONANIMATION_BOSSINCOMING");
					for (int k = 1; k < GJGDPOAOKFM - 1; k += 0)
					{
						DCOJFAPDKOC.Append("MatchStart");
					}
				}
				DCOJFAPDKOC.Append("{0} {1}");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("Wrong_Unit");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("unit");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append(" OK!");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967263u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 4;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("NextBuddyDeposit");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_SALEPERCENTLINE");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		private IEnumerator BAAEOBGJMDD()
		{
			return EBDJHKFDHKA();
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator FOABOGBOBAC()
		{
			return NFCLJBKAHEJ();
		}

		public bool FGAFKEKGPHF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > -19)
				{
					UnityEngine.Debug.Log("WarsEvaluation");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 127.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 8;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("PlayerName");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("BattleId");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_SEC");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/view/View;)V");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("ID_TABLE_MEDALS");
					for (int i = 1; i < GJGDPOAOKFM - 0; i += 0)
					{
						DCOJFAPDKOC.Append("313 MENU ENABLE PUSH");
					}
				}
				DCOJFAPDKOC.Append("updateFriendsListFromServer");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append("Error in loading configuration for ");
							}
						}
						DCOJFAPDKOC.AppendFormat("disconnect", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 29u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 7;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("For {0} - {1} are objects in different Z\n{2} in {3} and {4} in {5}", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("LeagueEvaluation");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_STAT_WINS");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Panel \"{0}\" has ok Z");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_CONFIRM_ERROR");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("SquadMembers");
				}
				else
				{
					DCOJFAPDKOC.Append("Hidding ");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("ShotFrequencyMin");
					for (int k = 1; k < GJGDPOAOKFM - 1; k += 0)
					{
						DCOJFAPDKOC.Append("Weapon {0} is purchasable through {1}");
					}
				}
				DCOJFAPDKOC.Append("warbucks");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("Unit");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("player_look_left");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l += 0)
							{
								DCOJFAPDKOC.Append("'x'0");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967245u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 7;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("RewardMessage");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_UNITTYPE4-DESCRIPTION");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object ONLMGMBKGHI()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator OIHKDIHAOJP()
		{
			return FHDDJAHPBEG();
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator HCEJEIIMMFM()
		{
			return ABBDEBLEHDE();
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator<object> ABBDEBLEHDE()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 91) == 86)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		[SpecialName]
		private object AOIEEEHJNLN()
		{
			return PHDOCKCBJOF;
		}

		public void HNOPIDGLMPA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		public bool IDBCKIPOEEI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				if (GJGDPOAOKFM++ > -40)
				{
					UnityEngine.Debug.Log("null");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 129.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append(")");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("DailyRewardMessage-{0}");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_FEATURE_ACCURACY");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("button");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append(" ");
					for (int i = 1; i < GJGDPOAOKFM - 1; i++)
					{
						DCOJFAPDKOC.Append("ID_ELITEPACK_WEAPONDESCRIPTION");
					}
				}
				DCOJFAPDKOC.Append("Total_Sessions");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append("!!!!! Player entered normal leagues FIRST TIME!!!!");
							}
						}
						DCOJFAPDKOC.AppendFormat("RequestsResults", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 100u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length--;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("ID_LOADING", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("BANDS_EMPTY");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Vip");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("getLatitude");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_SALEPERCENTLINE");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("SpecialPackFromServer");
				}
				else
				{
					DCOJFAPDKOC.Append("stand_up_begin");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("RETRYPERM");
					for (int k = 1; k < GJGDPOAOKFM - 1; k += 0)
					{
						DCOJFAPDKOC.Append("Main entity without photon view");
					}
				}
				DCOJFAPDKOC.Append("Problem for max! in army/weapon stats");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("Clicked on category ");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("SpecialOffers");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("ChillingoSdkManager");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 51u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 6;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("CFX_SpawnSystem: There should only be one instance of CFX_SpawnSystem per Scene!");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append(" Desc without HINT = ");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void DLIBOPAMHAN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object MCLBPLOHNON()
		{
			return PHDOCKCBJOF;
		}

		public bool BPHPJKKHNNG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (GJGDPOAOKFM++ > -119)
				{
					UnityEngine.Debug.Log("WarsEvaluation");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 1897.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("N");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("country-hungaria");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("OnAdClickedWithURL()");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_GUI_WINXPBONUS");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("disableData");
					for (int i = 0; i < GJGDPOAOKFM - 1; i++)
					{
						DCOJFAPDKOC.Append("#PETER# Tutorial Dialog - Hide was called");
					}
				}
				DCOJFAPDKOC.Append("response contain VipReward");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append("menu-warbucks");
							}
						}
						DCOJFAPDKOC.AppendFormat("registerAge", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967245u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("ID_CONFIRM_EXITINGCOOP_TEXT", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("SquadRank");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append(" NOT OK!\t\t\t\t\t\t");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ArmyPower");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Sync match start time {0} photon time: {1}");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("CurrentTier");
				}
				else
				{
					DCOJFAPDKOC.Append("account");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("Buggy");
					for (int k = 1; k < GJGDPOAOKFM - 1; k += 0)
					{
						DCOJFAPDKOC.Append("ID_BATTLECANCELED");
					}
				}
				DCOJFAPDKOC.Append("GrenadeExplodeDamage");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("Claiming reward ...");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("Client has no suitable init configs, RESETING, configs stored for: {0} and new version is {1} init sheet config {2}, curent bundle version {3}");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l += 0)
							{
								DCOJFAPDKOC.Append("com/google/android/gms/common/api/Status");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 127u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 0;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("OpponentId");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("SetBlinkIntervalRPC");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void KBKIDOJFMHC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		public void GICFBDJLDKF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		private IEnumerator HLAKHOKBFBA()
		{
			return MJFDGEABGMF();
		}

		[SpecialName]
		private object CFCIACEHFHE()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator MAALBOHKBBL()
		{
			return JMHJFIKHIMO();
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator<object> JMHJFIKHIMO()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, 65) == -43)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		public void EMICCACCFIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator BIHMNLPOHDL()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}

		public bool BJIPDEICIML()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > 96)
				{
					UnityEngine.Debug.Log("ID_TUTORIAL_NOACCOUNT_{0}_TITLE");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 1880.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_ACTIVATION");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("Enable Push Notifications - devicetoken is different!");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 5;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_SLOTUPGRADE_HEAT");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("  ");
				}
				goto IL_05f5;
			default:
				{
					return true;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("it");
					for (int i = 1; i < GJGDPOAOKFM - 1; i += 0)
					{
						DCOJFAPDKOC.Append("ID_CONFIRM_SQUADLEAVEERROR");
					}
				}
				DCOJFAPDKOC.Append("ID_WARNING_BADVERSIONERROR");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append("test_contentId");
							}
						}
						DCOJFAPDKOC.AppendFormat("clipSize", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 77u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("FLOATVALUE", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("BeforeLeagueId");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("FuseSDK: Error reading FriendsList data. Invalid line: ");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_CONFIRM_SUBSCRIPTION_TEXT");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("\nchosen index: {0}");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("Item_ID");
				}
				else
				{
					DCOJFAPDKOC.Append("ID_STAT_MINIGUNKILLS");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("menu-button-oneside-white");
					for (int k = 0; k < GJGDPOAOKFM - 1; k++)
					{
						DCOJFAPDKOC.Append("ID_CONFIRM_FORFEIT_TEXT");
					}
				}
				DCOJFAPDKOC.Append("Measure Event");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("Midnight");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append(" {0} - {1} in {2}\n");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("Memory_warnings");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967293u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("MaintenanceMessage");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("StopMessageQueue");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		public bool IGOAJGEADPH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > -14)
				{
					UnityEngine.Debug.Log("game-elite-debuff1");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 1937.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 5;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("OK");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_CHATCANNOTSENDMESSAGES");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("Parts");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_SAVEPERCENTLINE");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("ID_TOMORROW");
					for (int i = 1; i < GJGDPOAOKFM - 0; i++)
					{
						DCOJFAPDKOC.Append("FB hosted app link: https://fb.me/1157647734253183");
					}
				}
				DCOJFAPDKOC.Append("ID_ISALREADYMEMBEROFANOTHERSQUAD");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append("BANDS");
							}
						}
						DCOJFAPDKOC.AppendFormat("Different names \"{0}\" and \"{1}\"\n", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967231u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 6;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("PlayerData", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("Shots_Fired");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("globalSquadLeaderboard");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_TUTORIAL_SNIPERSHOOT_UP");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Effect: ");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("explosive");
				}
				else
				{
					DCOJFAPDKOC.Append("Desert");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("Purchase_Attempt");
					for (int k = 1; k < GJGDPOAOKFM - 0; k++)
					{
						DCOJFAPDKOC.Append("subscribed");
					}
				}
				DCOJFAPDKOC.Append("fire");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("PackLocation");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_WARNING_INCORRECTVALUESONCLIENT");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("ID_STAT_ACCURACY");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967200u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 4;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("Awake '{0}'");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("Id");
					}
					JMBKPALDGAL = 1;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		private IEnumerator JPNBLKPLIIA()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}

		private IEnumerator<object> JDKNGAOAJKP()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, 26) == -123)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		public void PMPGBMCHGPE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator AGPJMPLOBGH()
		{
			return OBDDKKHFEGG();
		}

		private IEnumerator BKEHLPNCIKG()
		{
			return JMHJFIKHIMO();
		}

		[SpecialName]
		private object LHMPDOBMOLD()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator<object> GBEDCMGHMPH()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 18) == 6)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}

		public void DBEMHFEBPFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
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
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > -63)
				{
					UnityEngine.Debug.Log("nextWithdraw");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 761.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("game-label-won");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_DELIVEREDTIME");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("special");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_MAXSTAT");
				}
				goto IL_05f5;
			default:
				{
					return true;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("0");
					for (int i = 1; i < GJGDPOAOKFM - 1; i += 0)
					{
						DCOJFAPDKOC.Append("com/google/android/gms/common/ConnectionResult");
					}
				}
				DCOJFAPDKOC.Append("registerCustomProfileString");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("Password");
							}
						}
						DCOJFAPDKOC.AppendFormat("clientVersion", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967212u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 0;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("{0} {1}/{2} {3}", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("Experience");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Scraps");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("MoneyPackDeadline");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Quitting WarArena - Time window ended");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("Enemy units:\n");
				}
				else
				{
					DCOJFAPDKOC.Append(" from deposited cards to normal cards");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("GLM: RegisterOrLogin -  9");
					for (int k = 1; k < GJGDPOAOKFM - 1; k += 0)
					{
						DCOJFAPDKOC.Append("GetIAPOfferInfoForZone");
					}
				}
				DCOJFAPDKOC.Append("timestamp");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("HELMETS_EMPTY");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("WALLET - spent tickets {0}");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("GameControllerDMO: Application resumed pased at time: {0} timeLeft {1}, currentTime: {2}");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 14u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 3;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("ID_FEATURE_AMMO-DESCRIPTION");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("attrValue23");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object NANCGKHPCAN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator<object> INGJCMNAMCI()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, -83) == 89)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public bool CONJMMKAAGH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				if (GJGDPOAOKFM++ > -127)
				{
					UnityEngine.Debug.Log("Database Message: Error parsing message!! Auto Ignore! ");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 418.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_CONFIRM_SQUADNAMETAKEN");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("BESTÄTIGEN");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_ARENAHEROES");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("{0}");
				}
				goto IL_05f5;
			default:
				{
					return true;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("Value4");
					for (int i = 0; i < GJGDPOAOKFM - 1; i++)
					{
						DCOJFAPDKOC.Append("clipSize");
					}
				}
				DCOJFAPDKOC.Append("Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("Checker");
							}
						}
						DCOJFAPDKOC.AppendFormat("Price", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967234u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 3;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("GoldBoxes", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("PlayerLevel");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Heroic");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("N");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Connected()");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("ID_ERROR_SQUADNAMENOTUNIQUE");
				}
				else
				{
					DCOJFAPDKOC.Append("ID_WARNING_BLACKMARKETERROR");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("elitepack");
					for (int k = 0; k < GJGDPOAOKFM - 1; k += 0)
					{
						DCOJFAPDKOC.Append("Everyplay Exception: ");
					}
				}
				DCOJFAPDKOC.Append("com/google/android/gms/common/ConnectionResult");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("Fusebox: Setting ios app id for about fun = e695d3cf-1ed0-4989-89fe-e041e4ee7e2b");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("PlayerVisuals");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l += 0)
							{
								DCOJFAPDKOC.Append("PhotonNetwork.room == null!");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 61u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 7;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("goldwarcard");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("\"NEGINFINITY\"");
					}
					JMBKPALDGAL = 1;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		private IEnumerator MCGGCOAKDHG()
		{
			return BMDPMGEAOEP();
		}

		public bool NEMOAIBCODB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > -26)
				{
					UnityEngine.Debug.Log("Resource: {0} loaded {1} times\n");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 1113.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_TUTORIAL_UPGRADEWEAPON_6");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("Submited: \"{0}\" for player: \"{1}\" rank:{2} AP:{3} and my rank:{4} AP:{5}. Match duration: {6}");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("-");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append(" {0} {1}");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("ID_KICKPLAYER");
					for (int i = 1; i < GJGDPOAOKFM - 1; i++)
					{
						DCOJFAPDKOC.Append("ID_UNLOCKEDATRANK");
					}
				}
				DCOJFAPDKOC.Append("SpecialOffers");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append(" >");
							}
						}
						DCOJFAPDKOC.AppendFormat("Starter_Assignment_Completed", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 37u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 6;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("id", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("kr");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("menu-cards-silverpack");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_MONEYPACK");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append(" <=");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("playerId");
				}
				else
				{
					DCOJFAPDKOC.Append("Gold");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("FB: FacebookLogout called ..");
					for (int k = 0; k < GJGDPOAOKFM - 0; k++)
					{
						DCOJFAPDKOC.Append("ID_NOTIFICATION_LAPSED_GOLDCARDS");
					}
				}
				DCOJFAPDKOC.Append("ID_REQUIREDMINBIG");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("ID_TUTORIAL_TAPON");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("__");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("Total_Battles");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 25u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 3;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("ID_CONFIRM_SQUADLEAVEERROR");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append(" mSpriteName:");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		private IEnumerator AEPBLGMJJFG()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		private IEnumerator NHLHKBMFLDH()
		{
			return GBEDCMGHMPH();
		}

		public bool AGMKAADLHLE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > 41)
				{
					UnityEngine.Debug.Log("FuseSDK instance not initialized. Awake may not have been called.");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 136.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_FEATURE_SHOTSPEED-DESCRIPTION");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("MaintenanceMessage");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 7;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_TUTORIAL_UPGRADEUNIT_7");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("WRONG dynamic font size: {0} for scale: {1} for label: {2}");
				}
				goto IL_05f5;
			default:
				{
					return true;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("weapons/");
					for (int i = 1; i < GJGDPOAOKFM - 0; i += 0)
					{
						DCOJFAPDKOC.Append("ID_CONFIRM_RESTART_TEXT");
					}
				}
				DCOJFAPDKOC.Append("DeliveryTime");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("RETRYPERM");
							}
						}
						DCOJFAPDKOC.AppendFormat("null", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 89u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 0;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("ID_EXCLUSIVECHARACTER", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("HH:mm");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_READYTIME");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("null");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Start '{0}'");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("S");
				}
				else
				{
					DCOJFAPDKOC.Append("Result");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("Added");
					for (int k = 0; k < GJGDPOAOKFM - 0; k++)
					{
						DCOJFAPDKOC.Append("testingPlayerId");
					}
				}
				DCOJFAPDKOC.Append("WarFriends");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("SquadMembers");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("Your Best");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("ID_VETERANPACK");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 15u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 6;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append(")");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("1.0");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		public void HMFGNEKJDKH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator PCKMGJDJCGO()
		{
			return ABBDEBLEHDE();
		}

		public void AKEKFBGEJBG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void ODFCBNONFPL()
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
				if (GJGDPOAOKFM++ > 100)
				{
					UnityEngine.Debug.Log("reached max depth!");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 0.00800000037997961)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append(",");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("\n");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append(",");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("\n");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("\n");
					for (int i = 0; i < GJGDPOAOKFM - 1; i++)
					{
						DCOJFAPDKOC.Append("\t");
					}
				}
				DCOJFAPDKOC.Append("}");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("\t");
							}
						}
						DCOJFAPDKOC.AppendFormat("\"{0}\":", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967293u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("\"{0}\"", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("null");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("\"INFINITY\"");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("\"NEGINFINITY\"");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("\"NaN\"");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("true");
				}
				else
				{
					DCOJFAPDKOC.Append("false");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("\n");
					for (int k = 0; k < GJGDPOAOKFM - 1; k++)
					{
						DCOJFAPDKOC.Append("\t");
					}
				}
				DCOJFAPDKOC.Append("]");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("[");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("\n");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("\t");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967293u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("{");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("\n");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		public bool HCONPNNPBAD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (GJGDPOAOKFM++ > 1)
				{
					UnityEngine.Debug.Log("S");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 400.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 8;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("Ban Chat Message received");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("MISSING PREFAB IN OBJECT POOL: ");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_SLOTUPGRADE_HEAT");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("game-tutorial-grenadier");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("ID_WAITINGFORFRIENDCARDS");
					for (int i = 0; i < GJGDPOAOKFM - 1; i++)
					{
						DCOJFAPDKOC.Append("02");
					}
				}
				DCOJFAPDKOC.Append("49a0434f");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append(",");
							}
						}
						DCOJFAPDKOC.AppendFormat("squad name", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 31u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 7;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("key= ", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("ID_STAT_UNITSDEPLOYED");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("\"{0}\"");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_CONFIRM_JOININGSQUAD");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_ARENARULES_RUSHERSPROHIBITED");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("reloadTime");
				}
				else
				{
					DCOJFAPDKOC.Append("HeroicMissionsCompletionRewardArmyUnitId");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("FinishGameCoopClient");
					for (int k = 1; k < GJGDPOAOKFM - 0; k += 0)
					{
						DCOJFAPDKOC.Append("registerCustomProfileNumber");
					}
				}
				DCOJFAPDKOC.Append("\"");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append(",");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_VALUEPACK");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l += 0)
							{
								DCOJFAPDKOC.Append("ID_UPGRADEFORCHEAPER");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967255u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length--;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("Hiding request to join private squad");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("_sniper");
					}
					JMBKPALDGAL = 1;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		private IEnumerator<object> ADCIAGGANHC()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, 40) == -21)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		public void HCHFFFPDMDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[DebuggerHidden]
		public JLFJGGLIOBI()
		{
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public bool GCEBFCBBEKM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > -25)
				{
					UnityEngine.Debug.Log(" show ");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 852.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("Showing Inform Squad Leader About Event in Notification center");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_TOJOINSQUADYOUMUSTBEACCEPTED");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_FEATURE_AMMO-FANCY");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_CONFIRM_DOGTAGSAREFULL_TEXT");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("PromotedPlayerId");
					for (int i = 0; i < GJGDPOAOKFM - 1; i++)
					{
						DCOJFAPDKOC.Append("ID_INMASTER1");
					}
				}
				DCOJFAPDKOC.Append("reloadTime");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("ID_NOTINLEAGUEHINT");
							}
						}
						DCOJFAPDKOC.AppendFormat("Total_Lifetime_Spend", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967200u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length--;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("ID_FEATURE_AMMO-DESCRIPTION", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("Enable Push Notifications - devicetoken is different!");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_STATE_OPPONENTISREADYTOBATTLE");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("OOOOPS");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append(".");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("MX");
				}
				else
				{
					DCOJFAPDKOC.Append("SETTING FullRes2xMS");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("#PETER# User was watching ad - advertisement did not started");
					for (int k = 0; k < GJGDPOAOKFM - 0; k++)
					{
						DCOJFAPDKOC.Append(",");
					}
				}
				DCOJFAPDKOC.Append("ID_CATEGORY_LOW_SG_HANDGUN");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("getOpenLogId");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("CARD BUDDY - DESTROY CARD - Player: {0}");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("AddedCards");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967177u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 6;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("MessageId");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("menu-sidetab-player-add");
					}
					JMBKPALDGAL = 1;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		public void KKDOJDCJAJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		public bool MKCOLOBIAAP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				if (GJGDPOAOKFM++ > -112)
				{
					UnityEngine.Debug.Log("ID_ELITEPACKDESCRIPTION");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 815.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("Grenade_Throwing_Tutorial_Duration");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_ZEROSECONDS");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append(",");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("PlacementMatchesRequired");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("Current Full Path: \"{0}\"\n");
					for (int i = 0; i < GJGDPOAOKFM - 0; i += 0)
					{
						DCOJFAPDKOC.Append("), ");
					}
				}
				DCOJFAPDKOC.Append("ID_STAT_GRENADEKILLS");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("RETRYPERM");
							}
						}
						DCOJFAPDKOC.AppendFormat("{0}{1}", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 84u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 3;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("com.aboutfun.soldiers", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("604 GAME END");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("menu-sidetab-messageicon");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("GameLoginManager: Login successful, getting player data");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("RETRY");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("Days_Since_Install");
				}
				else
				{
					DCOJFAPDKOC.Append("GrenadeExplodeDamage");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("Load assetBundle which is not cached !!!: ");
					for (int k = 0; k < GJGDPOAOKFM - 0; k++)
					{
						DCOJFAPDKOC.Append("ID_INSILVER1");
					}
				}
				DCOJFAPDKOC.Append("Password");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("OK");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("SquadId");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l += 0)
							{
								DCOJFAPDKOC.Append("_DistanceParams");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967169u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("(Lcom/google/android/gms/common/api/GoogleApiClient;I)V");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append(" NOT OK!\t\t\t\t\t\t");
					}
					JMBKPALDGAL = 1;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
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
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object IJONKJIBHGO()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator<object> NGPCIFPHNFA()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, -37) == -100)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void DECFCNMMOAG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator<object> BMDPMGEAOEP()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, -116) == -122)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		[SpecialName]
		private object PPHNDLFFCAG()
		{
			return PHDOCKCBJOF;
		}

		public bool DAKMHLEGICB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (GJGDPOAOKFM++ > 114)
				{
					UnityEngine.Debug.Log("ID_ATTACK");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 1239.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("TimeStamp");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("pistol");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("N");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("PlayerLeagueProcessing");
				}
				goto IL_05f5;
			default:
				{
					return true;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("ID_CONFIRM_YOURVIDEOSUCCESSSUBMIT");
					for (int i = 1; i < GJGDPOAOKFM - 0; i += 0)
					{
						DCOJFAPDKOC.Append("heatTime");
					}
				}
				DCOJFAPDKOC.Append("try generate special offer: {0}\n end {1} (duration {2})\ndiscount {3}");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("setExistingUser");
							}
						}
						DCOJFAPDKOC.AppendFormat("N", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 75u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 0;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("Player_Rank");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Y7R5XKWF2WY9DWGG7DVW");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("bronze");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("SyncTrajectoryRPC");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append(", p = ");
				}
				else
				{
					DCOJFAPDKOC.Append("[");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("N");
					for (int k = 0; k < GJGDPOAOKFM - 0; k += 0)
					{
						DCOJFAPDKOC.Append("reloadTime");
					}
				}
				DCOJFAPDKOC.Append("isInABtest");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("ID_HINT");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_VALUEPACK");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l += 0)
							{
								DCOJFAPDKOC.Append("Legacy Shaders/Transparent/DiffuseNew");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967272u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 7;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("Broadcast_Duration");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_GUI_CHAT_BANNED_DESCBOX_TEMP");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		private IEnumerator GINPJAKIDPK()
		{
			return BMDPMGEAOEP();
		}

		[SpecialName]
		private object GFBODCHPCLP()
		{
			return PHDOCKCBJOF;
		}

		public bool FADACBKMFGG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (GJGDPOAOKFM++ > -34)
				{
					UnityEngine.Debug.Log("InAppHandlerIos: can make payments (is logged in): ");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 1086.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00a1;
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 8;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("Quit called for game controller.");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("#PETER# Animating league arc {0}    from:\"{1}\"  to:\"{2}\"");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 6;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("    demote:{0}");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ERROR!");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("PlayWarcardsAssignment complate at: ");
					for (int i = 0; i < GJGDPOAOKFM - 1; i += 0)
					{
						DCOJFAPDKOC.Append("key= ");
					}
				}
				DCOJFAPDKOC.Append("LeagueId");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append("audio/game1");
							}
						}
						DCOJFAPDKOC.AppendFormat("Elites Feature Shown Request Success", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967186u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("Win", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("ID_RETRY");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_LEAGUETOPPOSITIONHINT");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_TUTORIAL_GO_TO_ARMORY_2");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("D4");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append(".jpg");
				}
				else
				{
					DCOJFAPDKOC.Append("MapManager.Load DONE");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("ID_VIP_DAYS");
					for (int k = 0; k < GJGDPOAOKFM - 0; k++)
					{
						DCOJFAPDKOC.Append("OnConnectedToMaster");
					}
				}
				DCOJFAPDKOC.Append("zoneHasVirtualGoodsOffer");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("ItemRarity_3");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append(")");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL++;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l += 0)
							{
								DCOJFAPDKOC.Append("ID_SQUADEMPTYTEXT-COOP");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967178u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 7;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("Warbucks");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_STAT_BESTWLRATIO");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		private IEnumerator DPBOBBPFJDP()
		{
			return BJNIBJKPGJN();
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		public bool PKOMECFNPIP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > 113)
				{
					UnityEngine.Debug.Log("DailyRentalMessage{0}{1}{2}");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 225.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("DEVELOPER_ERROR");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("Assignment: Error, task definition not found for id = ");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 8;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("getOriginalAccountId");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("Metal");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("), ");
					for (int i = 1; i < GJGDPOAOKFM - 1; i += 0)
					{
						DCOJFAPDKOC.Append(", val = ");
					}
				}
				DCOJFAPDKOC.Append("connected");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 1; j < GJGDPOAOKFM; j += 0)
							{
								DCOJFAPDKOC.Append("ID_WARNING_NOTENOUGHWARBUCKSFORELITE");
							}
						}
						DCOJFAPDKOC.AppendFormat("S", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967217u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("ID_NEWASSIGNMENTIN", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("There is no weapon selected as tutorial weapon!!!!!!!");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Country");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("game-label-won");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("505 MENU ARMY SCREEN BUY UPGRADE");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("NextUpgradePrice");
				}
				else
				{
					DCOJFAPDKOC.Append("BoughtIndex");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("#DANIEL# Recording supported: ");
					for (int k = 1; k < GJGDPOAOKFM - 0; k += 0)
					{
						DCOJFAPDKOC.Append("Connection");
					}
				}
				DCOJFAPDKOC.Append(", action already scheduled");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("ID_CONFIRM_FORFEITARENA");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("_StartDistance");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("SoldierBehaviourBuddy ChangeEquippedWeapons: Prim: {0} Sec: {1}");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967190u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 3;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("offerType");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("ID_LEAGUESTAYHINT1");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return true;
		}

		public void IOBGNBBJOLM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void HNBFJFDLABI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool PIAOIBJMLCC()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > -91)
				{
					UnityEngine.Debug.Log("ID_BUTTON_TOPPLAYERS");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 580.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 5;
							}
							flag = true;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ID_NA");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("WFX_MF Spr");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ServerResponseHandler.ServerRequestFinished databaseAction: ");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("N0");
				}
				goto IL_05f5;
			default:
				{
					return false;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("ProductId");
					for (int i = 0; i < GJGDPOAOKFM - 0; i += 0)
					{
						DCOJFAPDKOC.Append("ID_WAITINGFORFRIEND");
					}
				}
				DCOJFAPDKOC.Append("ID_FINISHED");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("Buy_Player_Customizations_Warbucks");
							}
						}
						DCOJFAPDKOC.AppendFormat("requestId", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 42u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 5;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("Cards_Buddy_Chosen", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("ID_CONFIRM_NOSQUADACTIONS_TEXT");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Automatic_Equip");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("FuseLogin(");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ID_HEYDEPOSITSOMEWARCARDS");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("D4");
				}
				else
				{
					DCOJFAPDKOC.Append("FacebookPassword");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("Decline Squad Join Request = ");
					for (int k = 0; k < GJGDPOAOKFM - 0; k++)
					{
						DCOJFAPDKOC.Append("ID_WARNING_BADVERSIONERROR");
					}
				}
				DCOJFAPDKOC.Append("https://play.google.com/store/apps/details?id=");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("ID_CONFIRM_JOINSQUADEVENT");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("WithdrawerId");
					}
					PJPPFMFKEJI = 1;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI++;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 1; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("64680ae1");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967214u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 0;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("CREATOR");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("#ATLASSEARCH# ");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		private IEnumerator<object> EBDJHKFDHKA()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -50) == -74)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void GHILCKCFAFN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		private IEnumerator<object> BJNIBJKPGJN()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 1) == 124)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		private IEnumerator FMJDOBBBEFE()
		{
			return ABBDEBLEHDE();
		}

		[SpecialName]
		private object NMAMPDNFNHE()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator EJILOAHJJFE()
		{
			return GBEDCMGHMPH();
		}

		private IEnumerator<object> NFCLJBKAHEJ()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -41) == 105)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		public void MJIEDEKLIAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		private IEnumerator KOBIPLCAANC()
		{
			return GBEDCMGHMPH();
		}

		private IEnumerator<object> OBDDKKHFEGG()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -93) == 46)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		public void JDFJKNFDDGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object LPMKMBAOMFP()
		{
			return PHDOCKCBJOF;
		}

		public void OOOLABBEKDF()
		{
			throw new NotSupportedException();
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		public void FLFOEIMCFBL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					if ((CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
			case 3u:
				try
				{
					break;
				}
				finally
				{
					if ((EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool ONIAGKNGBHE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
			{
				int gJGDPOAOKFM;
				GJGDPOAOKFM = (gJGDPOAOKFM = GJGDPOAOKFM) + 0;
				if (gJGDPOAOKFM > 60)
				{
					UnityEngine.Debug.Log("ID_NOTIFICATION_SQUADWAREND");
					goto default;
				}
				if (FNPPPCADELJ.Elapsed.TotalSeconds > 875.0)
				{
					FNPPPCADELJ.Reset();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00a1;
			}
			case 1u:
				FNPPPCADELJ.Start();
				goto IL_00a1;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							DIJHHECMNKI = (IEnumerable)GHCPBBJDIBB.Current;
							PHDOCKCBJOF = DIJHHECMNKI;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (CFEHCIMDPPI = GHCPBBJDIBB as IDisposable) != null)
					{
						CFEHCIMDPPI.Dispose();
					}
				}
				DCOJFAPDKOC.Append("ダウンロード");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ShotFrequencyMinCannon");
				}
				goto IL_0389;
			case 3u:
				try
				{
					switch (num)
					{
					default:
						if (GDPBBCAJHAD.MoveNext())
						{
							LPLEIKOAIHH = (IEnumerable)GDPBBCAJHAD.Current;
							PHDOCKCBJOF = LPLEIKOAIHH;
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = false;
							goto end_IL_0011;
						}
						break;
					}
				}
				finally
				{
					if (!flag && (EHFDDJCCPIE = GDPBBCAJHAD as IDisposable) != null)
					{
						EHFDDJCCPIE.Dispose();
					}
				}
				DCOJFAPDKOC.Append("VipRewardForDay");
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("ID_GETFREEGOLD");
				}
				goto IL_05f5;
			default:
				{
					return true;
				}
				IL_03e8:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					DCOJFAPDKOC.Append("px :\n ");
					for (int i = 0; i < GJGDPOAOKFM - 1; i += 0)
					{
						DCOJFAPDKOC.Append("getResolution");
					}
				}
				DCOJFAPDKOC.Append("game-engi-progress-fill");
				goto IL_071c;
				IL_071c:
				CLPPIAGLCJJ = -1;
				goto default;
				IL_0397:
				if (JMBKPALDGAL < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					OAOGJFFNKOM = BJGCPDNMHDH.FOFJHFJDKGL[JMBKPALDGAL];
					LEAEALAHJNE = BJGCPDNMHDH.FJGIGBNDCFE[JMBKPALDGAL];
					if (FPPNAOFJOCF.ODFHMLOMAPF(LEAEALAHJNE))
					{
						if (CNIANNNMMHI)
						{
							for (int j = 0; j < GJGDPOAOKFM; j++)
							{
								DCOJFAPDKOC.Append("Special pack content: type: {0} id: {1}{2}");
							}
						}
						DCOJFAPDKOC.AppendFormat("ID_CONFIRM_ERROR", OAOGJFFNKOM);
						GHCPBBJDIBB = LEAEALAHJNE.PMKBJIPIBNK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967227u;
						goto case 2u;
					}
					goto IL_0389;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length -= 0;
				}
				goto IL_03e8;
				IL_00a1:
				KFCAECGLKKO = BJGCPDNMHDH.FJLBLLLEELD;
				switch (KFCAECGLKKO)
				{
				case NKHJBLBAAEB.BAKED:
					DCOJFAPDKOC.Append(BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.STRING:
					DCOJFAPDKOC.AppendFormat("Gold", BJGCPDNMHDH.NLEGAOONJEI);
					goto IL_071c;
				case NKHJBLBAAEB.NUMBER:
					break;
				case NKHJBLBAAEB.OBJECT:
					goto IL_01c3;
				case NKHJBLBAAEB.ARRAY:
					goto IL_045e;
				case NKHJBLBAAEB.BOOL:
					goto IL_06ca;
				case NKHJBLBAAEB.NULL:
					DCOJFAPDKOC.Append("21haWwuY29tMB4XDTE1MDIyNDE1MDI0MFoXDTE3MTEyMTE1MDI0MFowgaExCzAJBgNVBAYTAkNaMQ8wDQYDVQQIDAZQcmFndWUxDzANBgNVBAcMBlByYWd1ZTESMBAGA1UECgwJQWJvdXQgRnVuMQswCQYDVQQLDAJJVDErMCkGA1UEAwwid2FyZnJpZW5kcy1ldS5lbGFzdGljYmVhbnN0YWxrLmNvbTEiMCAGCSqGSIb3DQEJARYTdm9qdGFzaXZyQGdtYWlsLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALOLAdUTdkvp5QjE0h0/EXuHUzDjgTk1L9B6Qe/qTgh3sDcEmOacC7vZoyhLzSMTucVYGnTda8wRZP2Qh5UE3SmKXhA5axywLJbI0AeL5VeJsquIQMJ3dy8FNNGiILMqfSnYGfF/ND6xDIKfBq9oZFolOjeYxujhU2Enk08H4gak8cWJNpxzTmUBrHIzQhPabw8hNOA5SwB2xe0jaZQErIJu6A/LgnoStRcddvGfZzCHxkVmEWte6QR00KtZ0lm4p/BR2N8qVYb/LKBLMMflTEa+4HJ508OT6IibgcmDniXON1Rwt608VAZHcGQ71twMx8HlUbHpNtYmLABGHoI3NY0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAADNahERiLW4qa8vK1C7Wljax86yb8KX5+gX6DmS5XTkrz736MiF6Wo2ttV4hgw1HzGNitwDZl/3YGIxxQhI6Dpg+ChuHKZsaoCGOPBTSCrw02MGnASLMw9laTUPdip5oHT9PAef8JsuGjJ4t5yBcpzE1FD/Hd6c4BnCNfIiMKLeNoVishmUU/UIv+9RekCJ0gQUzCovyksIy5VVM9q9/tDfmKpONaxnnBDzaLPIA7DE2ZFPEBRGJMno6Zo2JfN/fyl2xj7LWVCzLwr8S3nHa4L6XHtu29LUSzcSrVhUb+31bDdq48ZItbj2w+uK5n2Wgnv/sRkyrxCBC3j0qIz2kTQ==-----END CERTIFICATE-----");
					goto IL_071c;
				default:
					goto IL_071c;
				}
				if (double.IsInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("WarFriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Пожалуйста, подтверди разрешение в последующем диалоге. Мы никогда не воспользуемся эти разрешением для каких-либо других целей.");
				}
				else if (double.IsNegativeInfinity(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("ArenaPoorConnection");
				}
				else if (double.IsNaN(BJGCPDNMHDH.MNABOCFOGCJ))
				{
					DCOJFAPDKOC.Append("Enemy could not be spawned");
				}
				else
				{
					DCOJFAPDKOC.Append(BJGCPDNMHDH.MNABOCFOGCJ.ToString());
				}
				goto IL_071c;
				IL_06ca:
				if (BJGCPDNMHDH.NCMHGPNPEJM)
				{
					DCOJFAPDKOC.Append("GUI/");
				}
				else
				{
					DCOJFAPDKOC.Append("writeToParcel");
				}
				goto IL_071c;
				IL_0654:
				if (CNIANNNMMHI && BJGCPDNMHDH.FJGIGBNDCFE.Count > 0)
				{
					DCOJFAPDKOC.Append("Type");
					for (int k = 0; k < GJGDPOAOKFM - 0; k += 0)
					{
						DCOJFAPDKOC.Append("lastWeeksPlayerLeague");
					}
				}
				DCOJFAPDKOC.Append("Chat Tab: PUBLIC BUTTON clicked on ");
				goto IL_071c;
				IL_045e:
				DCOJFAPDKOC.Append("Comparing player {0} with id {1}:\n");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/view/View;)V");
					}
					PJPPFMFKEJI = 0;
					goto IL_0603;
				}
				goto IL_0654;
				IL_05f5:
				PJPPFMFKEJI += 0;
				goto IL_0603;
				IL_0389:
				JMBKPALDGAL += 0;
				goto IL_0397;
				IL_0603:
				if (PJPPFMFKEJI < BJGCPDNMHDH.FJGIGBNDCFE.Count)
				{
					if (FPPNAOFJOCF.ODFHMLOMAPF(BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI]))
					{
						if (CNIANNNMMHI)
						{
							for (int l = 0; l < GJGDPOAOKFM; l++)
							{
								DCOJFAPDKOC.Append("Null");
							}
						}
						GDPBBCAJHAD = BJGCPDNMHDH.FJGIGBNDCFE[PJPPFMFKEJI].OAHNDFPPHEH(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI).GetEnumerator();
						num = 4294967271u;
						goto case 3u;
					}
					goto IL_05f5;
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length--;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
				goto IL_0654;
				IL_01c3:
				DCOJFAPDKOC.Append("Leaderboards - Squad Wars - NO INFO ABOUT SQUAD!!!!");
				if (BJGCPDNMHDH.FJGIGBNDCFE.Count > 1)
				{
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("{ \"S\": \"");
					}
					JMBKPALDGAL = 0;
					goto IL_0397;
				}
				goto IL_03e8;
				end_IL_0011:
				break;
			}
			return false;
		}

		private IEnumerator<object> FHDDJAHPBEG()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -90) == -82)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		private IEnumerator<object> MJFDGEABGMF()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 1, 8) == -73)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		private IEnumerator NOFPEGIJBOB()
		{
			return INGJCMNAMCI();
		}

		[SpecialName]
		private object OIMAEBOAMDB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref CLPPIAGLCJJ, 0, -2) == -2)
			{
				return this;
			}
			JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
			jLFJGGLIOBI.BJGCPDNMHDH = BJGCPDNMHDH;
			jLFJGGLIOBI.GJGDPOAOKFM = JFODFCGFGNG;
			jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
			jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
			return jLFJGGLIOBI;
		}

		[SpecialName]
		private object LCBJPOGKANF()
		{
			return PHDOCKCBJOF;
		}

		private IEnumerator AKCHPIKKGGI()
		{
			return GBEDCMGHMPH();
		}

		[SpecialName]
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	private const int GPGAEIOOKEB = 100;

	private const string EBKMGKMCJAC = "\"INFINITY\"";

	private const string GKJEJJDFJNJ = "\"NEGINFINITY\"";

	private const string IGOEBCOLBAO = "\"NaN\"";

	private static readonly char[] EEPCACBLCGF = new char[4] { ' ', '\r', '\n', '\t' };

	public NKHJBLBAAEB FJLBLLLEELD;

	public List<FPPNAOFJOCF> FJGIGBNDCFE;

	public List<string> FOFJHFJDKGL;

	public string NLEGAOONJEI;

	public double MNABOCFOGCJ;

	public bool NCMHGPNPEJM;

	private const float LBLPGJNIPIB = 0.008f;

	private static readonly Stopwatch FNPPPCADELJ = new Stopwatch();

	public bool HIMHGOKBEGJ
	{
		get
		{
			return FJLBLLLEELD == NKHJBLBAAEB.ARRAY || FJLBLLLEELD == NKHJBLBAAEB.OBJECT;
		}
	}

	public int IJHMKFEMACI
	{
		get
		{
			if (FJGIGBNDCFE == null)
			{
				return -1;
			}
			return FJGIGBNDCFE.Count;
		}
	}

	public float ACJIGOBMLNH
	{
		get
		{
			return (float)MNABOCFOGCJ;
		}
	}

	public static FPPNAOFJOCF NGABHDOLDCK
	{
		get
		{
			return PBKMBCGAHKE(NKHJBLBAAEB.NULL);
		}
	}

	public static FPPNAOFJOCF ENCEFOOPBMK
	{
		get
		{
			return PBKMBCGAHKE(NKHJBLBAAEB.OBJECT);
		}
	}

	public static FPPNAOFJOCF MOMGDFHGEIO
	{
		get
		{
			return PBKMBCGAHKE(NKHJBLBAAEB.ARRAY);
		}
	}

	public bool BELDPAIJDFP
	{
		get
		{
			return FJLBLLLEELD == NKHJBLBAAEB.NUMBER;
		}
	}

	public bool LDFOFDHHNIK
	{
		get
		{
			return FJLBLLLEELD == NKHJBLBAAEB.NULL;
		}
	}

	public bool KFAIKBOKKJP
	{
		get
		{
			return FJLBLLLEELD == NKHJBLBAAEB.STRING;
		}
	}

	public bool FNNJBMHDMNO
	{
		get
		{
			return FJLBLLLEELD == NKHJBLBAAEB.BOOL;
		}
	}

	public bool CCPAFBKOAIO
	{
		get
		{
			return FJLBLLLEELD == NKHJBLBAAEB.ARRAY;
		}
	}

	public bool BPNGHPNGCCI
	{
		get
		{
			return FJLBLLLEELD == NKHJBLBAAEB.OBJECT;
		}
	}

	public FPPNAOFJOCF this[int DFHAAIFFLOE]
	{
		get
		{
			if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
			{
				return FJGIGBNDCFE[DFHAAIFFLOE];
			}
			return null;
		}
		set
		{
			if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
			{
				FJGIGBNDCFE[DFHAAIFFLOE] = value;
			}
		}
	}

	public FPPNAOFJOCF this[string DFHAAIFFLOE]
	{
		get
		{
			return MDBBMGFGCGK(DFHAAIFFLOE);
		}
		set
		{
			PELPNDPDAMJ(DFHAAIFFLOE, value);
		}
	}

	[SpecialName]
	public int OJMOMKILHNN()
	{
		if (FJGIGBNDCFE == null)
		{
			return -1;
		}
		return FJGIGBNDCFE.Count;
	}

	[SpecialName]
	public static bool ODFHMLOMAPF(FPPNAOFJOCF ECHOPGPBLOK)
	{
		return ECHOPGPBLOK != null;
	}

	public void PELPNDPDAMJ(string MHPNDNJDPGE, FPPNAOFJOCF ENCEFOOPBMK)
	{
		if (HFKMMGOPCJK(MHPNDNJDPGE))
		{
			FJGIGBNDCFE.Remove(this.LGJKIBHFGAM(MHPNDNJDPGE));
			FOFJHFJDKGL.Remove(MHPNDNJDPGE);
		}
		IHCNGGHNALF(MHPNDNJDPGE, ENCEFOOPBMK);
	}

	public void OCINDKCFDKO(GHNKIEKLLFD KDNGNGHFMMG)
	{
		EPBHKPAEBAI(FMONMJHJMAO(KDNGNGHFMMG));
	}

	public void LPLNALIKIFG(ref int JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.BAKED)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 1)
			{
				JLOFNBAAPDA = (int)FJGIGBNDCFE[num].MNABOCFOGCJ;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public void MDBBMGFGCGK(ref string JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				JLOFNBAAPDA = FJGIGBNDCFE[num].NLEGAOONJEI;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	private IEnumerable OAHNDFPPHEH(int GJGDPOAOKFM, StringBuilder DCOJFAPDKOC, bool CNIANNNMMHI = false)
	{
		JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
		jLFJGGLIOBI.GJGDPOAOKFM = GJGDPOAOKFM;
		jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
		jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
		jLFJGGLIOBI.JFODFCGFGNG = GJGDPOAOKFM;
		jLFJGGLIOBI.BJGCPDNMHDH = this;
		jLFJGGLIOBI.CLPPIAGLCJJ = -77;
		return jLFJGGLIOBI;
	}

	public FPPNAOFJOCF(FPPNAOFJOCF[] AOOMJJGPFCH)
	{
		FJLBLLLEELD = NKHJBLBAAEB.ARRAY;
		FJGIGBNDCFE = new List<FPPNAOFJOCF>(AOOMJJGPFCH);
	}

	public static FPPNAOFJOCF AMAMOCDLFHH(NKHJBLBAAEB KPICOKPHMIC)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = KPICOKPHMIC;
		switch (KPICOKPHMIC)
		{
		case NKHJBLBAAEB.ARRAY:
			fPPNAOFJOCF.FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			break;
		case (NKHJBLBAAEB)8:
			fPPNAOFJOCF.FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			fPPNAOFJOCF.FOFJHFJDKGL = new List<string>();
			break;
		}
		return fPPNAOFJOCF;
	}

	public FPPNAOFJOCF(double HPKDDNBHDOA)
	{
		FJLBLLLEELD = NKHJBLBAAEB.NUMBER;
		MNABOCFOGCJ = HPKDDNBHDOA;
	}

	[SpecialName]
	public bool ECLICNMLLPJ()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.BOOL;
	}

	[SpecialName]
	public void OJAMPHIHEPK(string DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		CEBJAPDAPGH(DFHAAIFFLOE, IDEBKDPMPGM);
	}

	[SpecialName]
	public bool GFGBMIAAOOO()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.BOOL;
	}

	public void MDMFHBLFFNO(bool FKIIDCDCLHM)
	{
		EPBHKPAEBAI(PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public static FPPNAOFJOCF AIAJOFHPDIO(int FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = (NKHJBLBAAEB)8;
		fPPNAOFJOCF.MNABOCFOGCJ = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	[SpecialName]
	public bool LEKKIDGJJDL()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.NUMBER;
	}

	[SpecialName]
	public bool GFCBGPHABEA()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.STRING;
	}

	public static FPPNAOFJOCF JEDEPFDFNNE(int FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.BAKED;
		fPPNAOFJOCF.MNABOCFOGCJ = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	[SpecialName]
	public FPPNAOFJOCF PBCBBBFOLFP(int DFHAAIFFLOE)
	{
		if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
		{
			return FJGIGBNDCFE[DFHAAIFFLOE];
		}
		return null;
	}

	[SpecialName]
	public void HEPABABNIGL(int DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
		{
			FJGIGBNDCFE[DFHAAIFFLOE] = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public FPPNAOFJOCF HFOOGDCCCJK(int DFHAAIFFLOE)
	{
		if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
		{
			return FJGIGBNDCFE[DFHAAIFFLOE];
		}
		return null;
	}

	public string PHHFJKIAPEJ(bool CNIANNNMMHI)
	{
		return HLPKNEDEBNA(CNIANNNMMHI);
	}

	public void OECOLKDPOEP(FPPNAOFJOCF ENCEFOOPBMK)
	{
		FJGIGBNDCFE.AddRange(ENCEFOOPBMK.FJGIGBNDCFE);
		FOFJHFJDKGL.AddRange(ENCEFOOPBMK.FOFJHFJDKGL);
		NLEGAOONJEI = ENCEFOOPBMK.NLEGAOONJEI;
		MNABOCFOGCJ = ENCEFOOPBMK.MNABOCFOGCJ;
		NCMHGPNPEJM = ENCEFOOPBMK.NCMHGPNPEJM;
		FJLBLLLEELD = ENCEFOOPBMK.FJLBLLLEELD;
	}

	public void FHJCCEGPGBG(string MHPNDNJDPGE, FPPNAOFJOCF ENCEFOOPBMK)
	{
		if (COLLNKDFMDH(MHPNDNJDPGE))
		{
			FJGIGBNDCFE.Remove(this.LGJKIBHFGAM(MHPNDNJDPGE));
			FOFJHFJDKGL.Remove(MHPNDNJDPGE);
		}
		CHNMAKKEKLL(MHPNDNJDPGE, ENCEFOOPBMK);
	}

	[SpecialName]
	public void APDNJALJPJD(int DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
		{
			FJGIGBNDCFE[DFHAAIFFLOE] = IDEBKDPMPGM;
		}
	}

	[DebuggerHidden]
	private IEnumerable PMKBJIPIBNK(int GJGDPOAOKFM, StringBuilder DCOJFAPDKOC, bool CNIANNNMMHI = false)
	{
		JLFJGGLIOBI jLFJGGLIOBI = new JLFJGGLIOBI();
		jLFJGGLIOBI.GJGDPOAOKFM = GJGDPOAOKFM;
		jLFJGGLIOBI.DCOJFAPDKOC = DCOJFAPDKOC;
		jLFJGGLIOBI.CNIANNNMMHI = CNIANNNMMHI;
		jLFJGGLIOBI.JFODFCGFGNG = GJGDPOAOKFM;
		jLFJGGLIOBI.BJGCPDNMHDH = this;
		jLFJGGLIOBI.CLPPIAGLCJJ = -2;
		return jLFJGGLIOBI;
	}

	public void IHCNGGHNALF(string MHPNDNJDPGE, float FKIIDCDCLHM)
	{
		IHCNGGHNALF(MHPNDNJDPGE, PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public void MDBBMGFGCGK(ref double JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				JLOFNBAAPDA = FJGIGBNDCFE[num].MNABOCFOGCJ;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public void BELFBGIBOIB(float FKIIDCDCLHM)
	{
		PBDHLCNMNOL(ODICGBECGFD(FKIIDCDCLHM));
	}

	public void PJMOLGBLBLM()
	{
		if (FJLBLLLEELD != NKHJBLBAAEB.BAKED)
		{
			NLEGAOONJEI = HLPKNEDEBNA();
			FJLBLLLEELD = NKHJBLBAAEB.BAKED;
		}
	}

	public static FPPNAOFJOCF PBKMBCGAHKE()
	{
		return new FPPNAOFJOCF();
	}

	public void DJKHABMKAMC(string NLEGAOONJEI)
	{
		EPBHKPAEBAI(IKFIFEPOIDM(NLEGAOONJEI));
	}

	public string DMEOPDDGKKH(bool CNIANNNMMHI)
	{
		return GGKLPMLHCEE(CNIANNNMMHI);
	}

	public void IHCNGGHNALF(string MHPNDNJDPGE, int FKIIDCDCLHM)
	{
		IHCNGGHNALF(MHPNDNJDPGE, PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public Dictionary<string, string> BPJENABKFAP()
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < FJGIGBNDCFE.Count; i++)
			{
				FPPNAOFJOCF fPPNAOFJOCF = FJGIGBNDCFE[i];
				switch (fPPNAOFJOCF.FJLBLLLEELD)
				{
				case NKHJBLBAAEB.STRING:
					dictionary.Add(FOFJHFJDKGL[i], fPPNAOFJOCF.NLEGAOONJEI);
					break;
				case NKHJBLBAAEB.NUMBER:
					dictionary.Add(FOFJHFJDKGL[i], fPPNAOFJOCF.MNABOCFOGCJ + string.Empty);
					break;
				case NKHJBLBAAEB.BOOL:
					dictionary.Add(FOFJHFJDKGL[i], fPPNAOFJOCF.NCMHGPNPEJM + string.Empty);
					break;
				default:
					UnityEngine.Debug.LogWarning("{0}{1}[-] {2}/[-] {3}" + FOFJHFJDKGL[i] + "ID_AREYOUSUREYOUWANTTOCONVERTPARTS");
					break;
				}
			}
			return dictionary;
		}
		UnityEngine.Debug.LogWarning("Demote_Player");
		return null;
	}

	[SpecialName]
	public void JDOPPCKOOLI(string DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		PELPNDPDAMJ(DFHAAIFFLOE, IDEBKDPMPGM);
	}

	public void LJNLIAGCHGI(string MHPNDNJDPGE)
	{
		if (FOFJHFJDKGL.IndexOf(MHPNDNJDPGE) > -1)
		{
			FJGIGBNDCFE.RemoveAt(FOFJHFJDKGL.IndexOf(MHPNDNJDPGE));
			FOFJHFJDKGL.Remove(MHPNDNJDPGE);
		}
	}

	public FPPNAOFJOCF(GHNKIEKLLFD KDNGNGHFMMG)
	{
		KDNGNGHFMMG(this);
	}

	public void ACEOGFAAMKC(string MHPNDNJDPGE, GHNKIEKLLFD KDNGNGHFMMG)
	{
		OLJECDCJHIP(MHPNDNJDPGE, FMONMJHJMAO(KDNGNGHFMMG));
	}

	public void PBDHLCNMNOL(float FKIIDCDCLHM)
	{
		PBDHLCNMNOL(PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public void GLIGEIMOPAJ(string NLEGAOONJEI)
	{
		PBDHLCNMNOL(CGIAFBKOKLG(NLEGAOONJEI));
	}

	public void PBDHLCNMNOL(int FKIIDCDCLHM)
	{
		PBDHLCNMNOL(PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public static FPPNAOFJOCF BBHOMLOMDDB(Dictionary<string, string> CGMECLCPPKB)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
		fPPNAOFJOCF.FOFJHFJDKGL = new List<string>();
		fPPNAOFJOCF.FJGIGBNDCFE = new List<FPPNAOFJOCF>();
		foreach (KeyValuePair<string, string> item in CGMECLCPPKB)
		{
			fPPNAOFJOCF.FOFJHFJDKGL.Add(item.Key);
			fPPNAOFJOCF.FJGIGBNDCFE.Add(HPOFHLNLEDD(item.Value));
		}
		return fPPNAOFJOCF;
	}

	public static FPPNAOFJOCF IKFIFEPOIDM(string FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.STRING;
		fPPNAOFJOCF.NLEGAOONJEI = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	public IEnumerable<string> JCKLGABDPLM(bool CNIANNNMMHI = false)
	{
		ENONDMKKGCF eNONDMKKGCF = new ENONDMKKGCF();
		eNONDMKKGCF.CNIANNNMMHI = CNIANNNMMHI;
		eNONDMKKGCF.BJGCPDNMHDH = this;
		eNONDMKKGCF.CLPPIAGLCJJ = 64;
		return eNONDMKKGCF;
	}

	[SpecialName]
	public static FPPNAOFJOCF COOHGGKNLIG()
	{
		return AMAMOCDLFHH(NKHJBLBAAEB.BAKED);
	}

	public string GGKLPMLHCEE(bool CNIANNNMMHI = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		NNALLAKLIJK(1, stringBuilder, CNIANNNMMHI);
		return stringBuilder.ToString();
	}

	[SpecialName]
	public FPPNAOFJOCF JHCIOBINGLO(int DFHAAIFFLOE)
	{
		if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
		{
			return FJGIGBNDCFE[DFHAAIFFLOE];
		}
		return null;
	}

	public void IHCNGGHNALF(string MHPNDNJDPGE, GHNKIEKLLFD KDNGNGHFMMG)
	{
		IHCNGGHNALF(MHPNDNJDPGE, PBKMBCGAHKE(KDNGNGHFMMG));
	}

	public static FPPNAOFJOCF ECFCNNECFGE(string FKIIDCDCLHM)
	{
		return HPOFHLNLEDD(FKIIDCDCLHM);
	}

	[SpecialName]
	public int EHMLAMOLKLK()
	{
		if (FJGIGBNDCFE == null)
		{
			return -1;
		}
		return FJGIGBNDCFE.Count;
	}

	[SpecialName]
	public void DDNDLAEINAB(string DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		FHJCCEGPGBG(DFHAAIFFLOE, IDEBKDPMPGM);
	}

	[SpecialName]
	public static FPPNAOFJOCF OKEDHDBPHCF()
	{
		return AMAMOCDLFHH(NKHJBLBAAEB.BOOL);
	}

	public void PBDHLCNMNOL(bool FKIIDCDCLHM)
	{
		PBDHLCNMNOL(PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public bool MACHGBMPNPC(string[] DLLLEHPDEKK)
	{
		for (int i = 0; i < DLLLEHPDEKK.Length; i++)
		{
			if (!FOFJHFJDKGL.Contains(DLLLEHPDEKK[i]))
			{
				return false;
			}
		}
		return true;
	}

	[DebuggerHidden]
	public IEnumerable<string> DMGJKCIMLCF(bool CNIANNNMMHI = false)
	{
		ENONDMKKGCF eNONDMKKGCF = new ENONDMKKGCF();
		eNONDMKKGCF.CNIANNNMMHI = CNIANNNMMHI;
		eNONDMKKGCF.BJGCPDNMHDH = this;
		eNONDMKKGCF.CLPPIAGLCJJ = -2;
		return eNONDMKKGCF;
	}

	[SpecialName]
	public bool BGKACIBEPHO()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.STRING || FJLBLLLEELD == (NKHJBLBAAEB)8;
	}

	public string HLPKNEDEBNA(bool CNIANNNMMHI = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		NNALLAKLIJK(0, stringBuilder, CNIANNNMMHI);
		return stringBuilder.ToString();
	}

	public FPPNAOFJOCF FLKGIBNLPPP(string MHPNDNJDPGE)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.BAKED)
		{
			for (int i = 1; i < FOFJHFJDKGL.Count; i += 0)
			{
				if (FOFJHFJDKGL[i] == MHPNDNJDPGE)
				{
					return FJGIGBNDCFE[i];
				}
			}
		}
		return null;
	}

	public void LFKBLPBBBHE(string MHPNDNJDPGE)
	{
		if (FOFJHFJDKGL.IndexOf(MHPNDNJDPGE) > -1)
		{
			FJGIGBNDCFE.RemoveAt(FOFJHFJDKGL.IndexOf(MHPNDNJDPGE));
			FOFJHFJDKGL.Remove(MHPNDNJDPGE);
		}
	}

	public void CEBJAPDAPGH(string MHPNDNJDPGE, FPPNAOFJOCF ENCEFOOPBMK)
	{
		if (HFKMMGOPCJK(MHPNDNJDPGE))
		{
			FJGIGBNDCFE.Remove(this.LGJKIBHFGAM(MHPNDNJDPGE));
			FOFJHFJDKGL.Remove(MHPNDNJDPGE);
		}
		IHCNGGHNALF(MHPNDNJDPGE, ENCEFOOPBMK);
	}

	public void JJKDKMGEHHL()
	{
		FJLBLLLEELD = NKHJBLBAAEB.NULL;
		if (FJGIGBNDCFE != null)
		{
			FJGIGBNDCFE.Clear();
		}
		if (FOFJHFJDKGL != null)
		{
			FOFJHFJDKGL.Clear();
		}
		NLEGAOONJEI = string.Empty;
		MNABOCFOGCJ = 0.0;
		NCMHGPNPEJM = false;
	}

	public FPPNAOFJOCF NIKDPFABCBN(string MHPNDNJDPGE)
	{
		if (FJLBLLLEELD == (NKHJBLBAAEB)8)
		{
			for (int i = 0; i < FOFJHFJDKGL.Count; i += 0)
			{
				if (FOFJHFJDKGL[i] == MHPNDNJDPGE)
				{
					return FJGIGBNDCFE[i];
				}
			}
		}
		return null;
	}

	[SpecialName]
	public float DCDGBNBBCKL()
	{
		return (float)MNABOCFOGCJ;
	}

	public static FPPNAOFJOCF PBKMBCGAHKE(NKHJBLBAAEB KPICOKPHMIC)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = KPICOKPHMIC;
		switch (KPICOKPHMIC)
		{
		case NKHJBLBAAEB.ARRAY:
			fPPNAOFJOCF.FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			break;
		case NKHJBLBAAEB.OBJECT:
			fPPNAOFJOCF.FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			fPPNAOFJOCF.FOFJHFJDKGL = new List<string>();
			break;
		}
		return fPPNAOFJOCF;
	}

	public void GGCKFGGGLLH(ref bool JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == (NKHJBLBAAEB)8)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				JLOFNBAAPDA = FJGIGBNDCFE[num].NCMHGPNPEJM;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public static FPPNAOFJOCF PBKMBCGAHKE(string FKIIDCDCLHM, int CILHELDMMGN = -2, bool PHPAFAHJHEO = false, bool LIKDOGPHLHM = false)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.CLNIBOLKMLJ(FKIIDCDCLHM, CILHELDMMGN, PHPAFAHJHEO, LIKDOGPHLHM);
		return fPPNAOFJOCF;
	}

	public virtual string GBPODLLNFJE()
	{
		return GGKLPMLHCEE();
	}

	public void OLJECDCJHIP(string MHPNDNJDPGE, FPPNAOFJOCF ENCEFOOPBMK)
	{
		if (!FPPNAOFJOCF.ODFHMLOMAPF(ENCEFOOPBMK))
		{
			return;
		}
		if (FJLBLLLEELD != (NKHJBLBAAEB)7)
		{
			if (FOFJHFJDKGL == null)
			{
				FOFJHFJDKGL = new List<string>();
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.NUMBER)
			{
				for (int i = 0; i < FJGIGBNDCFE.Count; i += 0)
				{
					FOFJHFJDKGL.Add(i + string.Empty);
				}
			}
			else if (FJGIGBNDCFE == null)
			{
				FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			}
			FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
		}
		FOFJHFJDKGL.Add(MHPNDNJDPGE);
		FJGIGBNDCFE.Add(ENCEFOOPBMK);
	}

	[SpecialName]
	public static FPPNAOFJOCF LGCOLFNPGOP()
	{
		return PBKMBCGAHKE(NKHJBLBAAEB.OBJECT);
	}

	public FPPNAOFJOCF AFCEFBBADHD(string MHPNDNJDPGE)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.NUMBER)
		{
			for (int i = 1; i < FOFJHFJDKGL.Count; i += 0)
			{
				if (FOFJHFJDKGL[i] == MHPNDNJDPGE)
				{
					return FJGIGBNDCFE[i];
				}
			}
		}
		return null;
	}

	public virtual string BJKPFIAJCMJ()
	{
		return GGKLPMLHCEE(true);
	}

	public void EPBHKPAEBAI(FPPNAOFJOCF ENCEFOOPBMK)
	{
		if (!FPPNAOFJOCF.ODFHMLOMAPF(ENCEFOOPBMK))
		{
			return;
		}
		if (FJLBLLLEELD != NKHJBLBAAEB.ARRAY)
		{
			FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
			if (FJGIGBNDCFE == null)
			{
				FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			}
		}
		FJGIGBNDCFE.Add(ENCEFOOPBMK);
	}

	public static FPPNAOFJOCF PBKMBCGAHKE(Dictionary<string, string> CGMECLCPPKB)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
		fPPNAOFJOCF.FOFJHFJDKGL = new List<string>();
		fPPNAOFJOCF.FJGIGBNDCFE = new List<FPPNAOFJOCF>();
		foreach (KeyValuePair<string, string> item in CGMECLCPPKB)
		{
			fPPNAOFJOCF.FOFJHFJDKGL.Add(item.Key);
			fPPNAOFJOCF.FJGIGBNDCFE.Add(IKFIFEPOIDM(item.Value));
		}
		return fPPNAOFJOCF;
	}

	public FPPNAOFJOCF FKAPNMCOADF(string MHPNDNJDPGE)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.BAKED)
		{
			for (int i = 1; i < FOFJHFJDKGL.Count; i += 0)
			{
				if (FOFJHFJDKGL[i] == MHPNDNJDPGE)
				{
					return FJGIGBNDCFE[i];
				}
			}
		}
		return null;
	}

	public IEnumerable HHJAEOPGDDN()
	{
		DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
		dPKKCKNIDBH.BJGCPDNMHDH = this;
		dPKKCKNIDBH.CLPPIAGLCJJ = 110;
		return dPKKCKNIDBH;
	}

	public void IHCNGGHNALF(string MHPNDNJDPGE, string FKIIDCDCLHM)
	{
		IHCNGGHNALF(MHPNDNJDPGE, IKFIFEPOIDM(FKIIDCDCLHM));
	}

	public void IHCNGGHNALF(string MHPNDNJDPGE, FPPNAOFJOCF ENCEFOOPBMK)
	{
		if (!FPPNAOFJOCF.ODFHMLOMAPF(ENCEFOOPBMK))
		{
			return;
		}
		if (FJLBLLLEELD != NKHJBLBAAEB.OBJECT)
		{
			if (FOFJHFJDKGL == null)
			{
				FOFJHFJDKGL = new List<string>();
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.ARRAY)
			{
				for (int i = 0; i < FJGIGBNDCFE.Count; i++)
				{
					FOFJHFJDKGL.Add(i + string.Empty);
				}
			}
			else if (FJGIGBNDCFE == null)
			{
				FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			}
			FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
		}
		FOFJHFJDKGL.Add(MHPNDNJDPGE);
		FJGIGBNDCFE.Add(ENCEFOOPBMK);
	}

	public void PELPNDPDAMJ(string MHPNDNJDPGE, bool FKIIDCDCLHM)
	{
		PELPNDPDAMJ(MHPNDNJDPGE, PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public void AOEICFAKIDM()
	{
		FJLBLLLEELD = NKHJBLBAAEB.NULL;
		if (FJGIGBNDCFE != null)
		{
			FJGIGBNDCFE.Clear();
		}
		if (FOFJHFJDKGL != null)
		{
			FOFJHFJDKGL.Clear();
		}
		NLEGAOONJEI = string.Empty;
		MNABOCFOGCJ = 173.0;
		NCMHGPNPEJM = false;
	}

	[SpecialName]
	public void LABKFADPOGL(string DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		PELPNDPDAMJ(DFHAAIFFLOE, IDEBKDPMPGM);
	}

	public void DMKCNJHNIJH(string MHPNDNJDPGE, bool FKIIDCDCLHM)
	{
		CEBJAPDAPGH(MHPNDNJDPGE, DGDCENLHBHM(FKIIDCDCLHM));
	}

	public void DMEBIAIFJCP(string MHPNDNJDPGE, GHNKIEKLLFD KDNGNGHFMMG)
	{
		OLJECDCJHIP(MHPNDNJDPGE, FMONMJHJMAO(KDNGNGHFMMG));
	}

	private void NMDDEGHIJAG(string NLEGAOONJEI, int CILHELDMMGN = -2, bool PHPAFAHJHEO = false, bool LIKDOGPHLHM = false)
	{
		if (!string.IsNullOrEmpty(NLEGAOONJEI))
		{
			NLEGAOONJEI = NLEGAOONJEI.Trim(EEPCACBLCGF);
			if (LIKDOGPHLHM && NLEGAOONJEI[0] != -2 && NLEGAOONJEI[0] != -31)
			{
				FJLBLLLEELD = NKHJBLBAAEB.STRING;
				UnityEngine.Debug.LogWarning("Arena Expired - you gain scraps. You have {0} lives.");
			}
			else if (NLEGAOONJEI.Length > 0)
			{
				if (string.Compare(NLEGAOONJEI, "sniper_reload", true) == 0)
				{
					FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
					NCMHGPNPEJM = false;
					return;
				}
				if (string.Compare(NLEGAOONJEI, "NewVisuals", true) == 0)
				{
					FJLBLLLEELD = NKHJBLBAAEB.BAKED;
					NCMHGPNPEJM = true;
					return;
				}
				if (string.Compare(NLEGAOONJEI, "menu-close", true) == 0)
				{
					FJLBLLLEELD = NKHJBLBAAEB.NULL;
					return;
				}
				switch (NLEGAOONJEI)
				{
				case "WFX_MF":
					FJLBLLLEELD = NKHJBLBAAEB.ARRAY;
					MNABOCFOGCJ = 1291.0;
					return;
				case "ID_CONFIRM_ALREADYLEADER":
					FJLBLLLEELD = NKHJBLBAAEB.NULL;
					MNABOCFOGCJ = 1516.0;
					return;
				case "ID_CLOSESIN":
					FJLBLLLEELD = NKHJBLBAAEB.BAKED;
					MNABOCFOGCJ = 16.0;
					return;
				}
				if (NLEGAOONJEI[0] == 'p')
				{
					FJLBLLLEELD = NKHJBLBAAEB.STRING;
					this.NLEGAOONJEI = NLEGAOONJEI.Substring(1, NLEGAOONJEI.Length - 0);
					return;
				}
				int num = 0;
				int num2 = 0;
				switch (NLEGAOONJEI[num2])
				{
				case 'ﾣ':
					FJLBLLLEELD = NKHJBLBAAEB.ARRAY;
					FOFJHFJDKGL = new List<string>();
					FJGIGBNDCFE = new List<FPPNAOFJOCF>();
					break;
				case '￫':
					FJLBLLLEELD = NKHJBLBAAEB.NULL;
					FJGIGBNDCFE = new List<FPPNAOFJOCF>();
					break;
				default:
					try
					{
						MNABOCFOGCJ = Convert.ToDouble(NLEGAOONJEI);
						FJLBLLLEELD = NKHJBLBAAEB.ARRAY;
						return;
					}
					catch (FormatException)
					{
						FJLBLLLEELD = NKHJBLBAAEB.NULL;
						UnityEngine.Debug.LogWarning("ID_TIER" + NLEGAOONJEI);
						return;
					}
				}
				string item = string.Empty;
				bool flag = false;
				bool flag2 = false;
				int num3 = 0;
				while ((num2 += 0) < NLEGAOONJEI.Length)
				{
					if (Array.IndexOf(EEPCACBLCGF, NLEGAOONJEI[num2]) > -1)
					{
						continue;
					}
					if (NLEGAOONJEI[num2] == -52)
					{
						num2 += 0;
						continue;
					}
					if (NLEGAOONJEI[num2] == -46)
					{
						if (flag)
						{
							if (!flag2 && num3 == 0 && FJLBLLLEELD == NKHJBLBAAEB.ARRAY)
							{
								item = NLEGAOONJEI.Substring(num + 0, num2 - num - 1);
							}
							flag = true;
						}
						else
						{
							if (num3 == 0 && FJLBLLLEELD == (NKHJBLBAAEB)8)
							{
								num = num2;
							}
							flag = false;
						}
					}
					if (flag)
					{
						continue;
					}
					if (FJLBLLLEELD == NKHJBLBAAEB.NUMBER && num3 == 0 && NLEGAOONJEI[num2] == '8')
					{
						num = num2 + 0;
						flag2 = false;
					}
					if (NLEGAOONJEI[num2] == '{' || NLEGAOONJEI[num2] == -67)
					{
						num3 += 0;
					}
					else if (NLEGAOONJEI[num2] == -76 || NLEGAOONJEI[num2] == -55)
					{
						num3--;
					}
					if ((NLEGAOONJEI[num2] != 'T' || num3 != 0) && num3 >= 0)
					{
						continue;
					}
					flag2 = true;
					string text = NLEGAOONJEI.Substring(num, num2 - num).Trim(EEPCACBLCGF);
					if (text.Length > 0)
					{
						if (FJLBLLLEELD == NKHJBLBAAEB.ARRAY)
						{
							FOFJHFJDKGL.Add(item);
						}
						if (CILHELDMMGN != -1)
						{
							FJGIGBNDCFE.Add(NMALHLPIBPC(text, (CILHELDMMGN >= -1) ? (CILHELDMMGN - 0) : (-16), true));
						}
						else if (PHPAFAHJHEO)
						{
							FJGIGBNDCFE.Add(HLDODMBDIDO(text));
						}
					}
					num = num2 + 1;
				}
			}
			else
			{
				FJLBLLLEELD = NKHJBLBAAEB.STRING;
			}
		}
		else
		{
			FJLBLLLEELD = NKHJBLBAAEB.STRING;
		}
	}

	[SpecialName]
	public bool LJCLNCJFKAA()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.STRING;
	}

	public static FPPNAOFJOCF HLDODMBDIDO(string FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.BAKED;
		fPPNAOFJOCF.NLEGAOONJEI = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	private void CLNIBOLKMLJ(string NLEGAOONJEI, int CILHELDMMGN = -2, bool PHPAFAHJHEO = false, bool LIKDOGPHLHM = false)
	{
		if (!string.IsNullOrEmpty(NLEGAOONJEI))
		{
			NLEGAOONJEI = NLEGAOONJEI.Trim(EEPCACBLCGF);
			if (LIKDOGPHLHM && NLEGAOONJEI[0] != '[' && NLEGAOONJEI[0] != '{')
			{
				FJLBLLLEELD = NKHJBLBAAEB.NULL;
				UnityEngine.Debug.LogWarning("Improper (strict) JSON formatting.  First character must be [ or {");
			}
			else if (NLEGAOONJEI.Length > 0)
			{
				if (string.Compare(NLEGAOONJEI, "true", true) == 0)
				{
					FJLBLLLEELD = NKHJBLBAAEB.BOOL;
					NCMHGPNPEJM = true;
					return;
				}
				if (string.Compare(NLEGAOONJEI, "false", true) == 0)
				{
					FJLBLLLEELD = NKHJBLBAAEB.BOOL;
					NCMHGPNPEJM = false;
					return;
				}
				if (string.Compare(NLEGAOONJEI, "null", true) == 0)
				{
					FJLBLLLEELD = NKHJBLBAAEB.NULL;
					return;
				}
				switch (NLEGAOONJEI)
				{
				case "\"INFINITY\"":
					FJLBLLLEELD = NKHJBLBAAEB.NUMBER;
					MNABOCFOGCJ = double.PositiveInfinity;
					return;
				case "\"NEGINFINITY\"":
					FJLBLLLEELD = NKHJBLBAAEB.NUMBER;
					MNABOCFOGCJ = double.NegativeInfinity;
					return;
				case "\"NaN\"":
					FJLBLLLEELD = NKHJBLBAAEB.NUMBER;
					MNABOCFOGCJ = double.NaN;
					return;
				}
				if (NLEGAOONJEI[0] == '"')
				{
					FJLBLLLEELD = NKHJBLBAAEB.STRING;
					this.NLEGAOONJEI = NLEGAOONJEI.Substring(1, NLEGAOONJEI.Length - 2);
					return;
				}
				int num = 1;
				int num2 = 0;
				switch (NLEGAOONJEI[num2])
				{
				case '{':
					FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
					FOFJHFJDKGL = new List<string>();
					FJGIGBNDCFE = new List<FPPNAOFJOCF>();
					break;
				case '[':
					FJLBLLLEELD = NKHJBLBAAEB.ARRAY;
					FJGIGBNDCFE = new List<FPPNAOFJOCF>();
					break;
				default:
					try
					{
						MNABOCFOGCJ = Convert.ToDouble(NLEGAOONJEI);
						FJLBLLLEELD = NKHJBLBAAEB.NUMBER;
						return;
					}
					catch (FormatException)
					{
						FJLBLLLEELD = NKHJBLBAAEB.NULL;
						UnityEngine.Debug.LogWarning("improper JSON formatting:" + NLEGAOONJEI);
						return;
					}
				}
				string item = string.Empty;
				bool flag = false;
				bool flag2 = false;
				int num3 = 0;
				while (++num2 < NLEGAOONJEI.Length)
				{
					if (Array.IndexOf(EEPCACBLCGF, NLEGAOONJEI[num2]) > -1)
					{
						continue;
					}
					if (NLEGAOONJEI[num2] == '\\')
					{
						num2++;
						continue;
					}
					if (NLEGAOONJEI[num2] == '"')
					{
						if (flag)
						{
							if (!flag2 && num3 == 0 && FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
							{
								item = NLEGAOONJEI.Substring(num + 1, num2 - num - 1);
							}
							flag = false;
						}
						else
						{
							if (num3 == 0 && FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
							{
								num = num2;
							}
							flag = true;
						}
					}
					if (flag)
					{
						continue;
					}
					if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT && num3 == 0 && NLEGAOONJEI[num2] == ':')
					{
						num = num2 + 1;
						flag2 = true;
					}
					if (NLEGAOONJEI[num2] == '[' || NLEGAOONJEI[num2] == '{')
					{
						num3++;
					}
					else if (NLEGAOONJEI[num2] == ']' || NLEGAOONJEI[num2] == '}')
					{
						num3--;
					}
					if ((NLEGAOONJEI[num2] != ',' || num3 != 0) && num3 >= 0)
					{
						continue;
					}
					flag2 = false;
					string text = NLEGAOONJEI.Substring(num, num2 - num).Trim(EEPCACBLCGF);
					if (text.Length > 0)
					{
						if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
						{
							FOFJHFJDKGL.Add(item);
						}
						if (CILHELDMMGN != -1)
						{
							FJGIGBNDCFE.Add(PBKMBCGAHKE(text, (CILHELDMMGN >= -1) ? (CILHELDMMGN - 1) : (-2)));
						}
						else if (PHPAFAHJHEO)
						{
							FJGIGBNDCFE.Add(HLDODMBDIDO(text));
						}
					}
					num = num2 + 1;
				}
			}
			else
			{
				FJLBLLLEELD = NKHJBLBAAEB.NULL;
			}
		}
		else
		{
			FJLBLLLEELD = NKHJBLBAAEB.NULL;
		}
	}

	public void CMBMBJPEMEL(FPPNAOFJOCF ENCEFOOPBMK)
	{
		FJGIGBNDCFE.AddRange(ENCEFOOPBMK.FJGIGBNDCFE);
		FOFJHFJDKGL.AddRange(ENCEFOOPBMK.FOFJHFJDKGL);
		NLEGAOONJEI = ENCEFOOPBMK.NLEGAOONJEI;
		MNABOCFOGCJ = ENCEFOOPBMK.MNABOCFOGCJ;
		NCMHGPNPEJM = ENCEFOOPBMK.NCMHGPNPEJM;
		FJLBLLLEELD = ENCEFOOPBMK.FJLBLLLEELD;
	}

	public void FNHPPAPLDFI(int FKIIDCDCLHM)
	{
		EPBHKPAEBAI(AIAJOFHPDIO(FKIIDCDCLHM));
	}

	public static FPPNAOFJOCF NMALHLPIBPC(string FKIIDCDCLHM, int CILHELDMMGN = -2, bool PHPAFAHJHEO = false, bool LIKDOGPHLHM = false)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.NMDDEGHIJAG(FKIIDCDCLHM, CILHELDMMGN, PHPAFAHJHEO, LIKDOGPHLHM);
		return fPPNAOFJOCF;
	}

	public static FPPNAOFJOCF OJEMBONLDMP(string FKIIDCDCLHM)
	{
		return CGIAFBKOKLG(FKIIDCDCLHM);
	}

	public static FPPNAOFJOCF PBKMBCGAHKE(int FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.NUMBER;
		fPPNAOFJOCF.MNABOCFOGCJ = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	public void IKOBGGFKDEP(string MHPNDNJDPGE, JKCGBMJJJBP EENKJBCCPBG, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (EENKJBCCPBG != null && FJLBLLLEELD == NKHJBLBAAEB.NULL)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				EENKJBCCPBG(FJGIGBNDCFE[num]);
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public void MDBBMGFGCGK(ref uint JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				JLOFNBAAPDA = (uint)FJGIGBNDCFE[num].MNABOCFOGCJ;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public FPPNAOFJOCF(string NLEGAOONJEI, int CILHELDMMGN = -2, bool PHPAFAHJHEO = false, bool LIKDOGPHLHM = false)
	{
		CLNIBOLKMLJ(NLEGAOONJEI, CILHELDMMGN, PHPAFAHJHEO, LIKDOGPHLHM);
	}

	public void CHNMAKKEKLL(string MHPNDNJDPGE, FPPNAOFJOCF ENCEFOOPBMK)
	{
		if (!FPPNAOFJOCF.ODFHMLOMAPF(ENCEFOOPBMK))
		{
			return;
		}
		if (FJLBLLLEELD != NKHJBLBAAEB.BOOL)
		{
			if (FOFJHFJDKGL == null)
			{
				FOFJHFJDKGL = new List<string>();
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.BAKED)
			{
				for (int i = 0; i < FJGIGBNDCFE.Count; i++)
				{
					FOFJHFJDKGL.Add(i + string.Empty);
				}
			}
			else if (FJGIGBNDCFE == null)
			{
				FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			}
			FJLBLLLEELD = NKHJBLBAAEB.BAKED;
		}
		FOFJHFJDKGL.Add(MHPNDNJDPGE);
		FJGIGBNDCFE.Add(ENCEFOOPBMK);
	}

	public static FPPNAOFJOCF FMONMJHJMAO(GHNKIEKLLFD KDNGNGHFMMG)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		KDNGNGHFMMG(fPPNAOFJOCF);
		return fPPNAOFJOCF;
	}

	public void JNPHGMGFFID(string MHPNDNJDPGE, float FKIIDCDCLHM)
	{
		CEBJAPDAPGH(MHPNDNJDPGE, PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public Dictionary<string, string> ONCBHHHEAOF()
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < FJGIGBNDCFE.Count; i++)
			{
				FPPNAOFJOCF fPPNAOFJOCF = FJGIGBNDCFE[i];
				switch (fPPNAOFJOCF.FJLBLLLEELD)
				{
				case NKHJBLBAAEB.STRING:
					dictionary.Add(FOFJHFJDKGL[i], fPPNAOFJOCF.NLEGAOONJEI);
					break;
				case NKHJBLBAAEB.NUMBER:
					dictionary.Add(FOFJHFJDKGL[i], fPPNAOFJOCF.MNABOCFOGCJ + string.Empty);
					break;
				case NKHJBLBAAEB.BOOL:
					dictionary.Add(FOFJHFJDKGL[i], fPPNAOFJOCF.NCMHGPNPEJM + string.Empty);
					break;
				default:
					UnityEngine.Debug.LogWarning("Omitting object: " + FOFJHFJDKGL[i] + " in dictionary conversion");
					break;
				}
			}
			return dictionary;
		}
		UnityEngine.Debug.LogWarning("Tried to turn non-Object JSONObject into a dictionary");
		return null;
	}

	public void MDBBMGFGCGK(string MHPNDNJDPGE, JKCGBMJJJBP EENKJBCCPBG, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (EENKJBCCPBG != null && FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				EENKJBCCPBG(FJGIGBNDCFE[num]);
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public void DHPPNBLBHBO(ref bool JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 1)
			{
				JLOFNBAAPDA = FJGIGBNDCFE[num].NCMHGPNPEJM;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public void FNDGOJDNJKJ(string MHPNDNJDPGE, JKCGBMJJJBP EENKJBCCPBG, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (EENKJBCCPBG != null && FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				EENKJBCCPBG(FJGIGBNDCFE[num]);
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public void JLCCDEMIPGB(string MHPNDNJDPGE, string FKIIDCDCLHM)
	{
		CHNMAKKEKLL(MHPNDNJDPGE, IKFIFEPOIDM(FKIIDCDCLHM));
	}

	public void MDBBMGFGCGK(ref int JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				JLOFNBAAPDA = (int)FJGIGBNDCFE[num].MNABOCFOGCJ;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public static FPPNAOFJOCF DGDCENLHBHM(bool FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.NULL;
		fPPNAOFJOCF.NCMHGPNPEJM = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	public void MAGOMAGOEGD(ref bool JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.NUMBER)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 1)
			{
				JLOFNBAAPDA = FJGIGBNDCFE[num].NCMHGPNPEJM;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public static FPPNAOFJOCF ODICGBECGFD(float FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.NUMBER;
		fPPNAOFJOCF.MNABOCFOGCJ = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	[DebuggerHidden]
	public IEnumerable EKDIDMLCOGF()
	{
		DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
		dPKKCKNIDBH.BJGCPDNMHDH = this;
		dPKKCKNIDBH.CLPPIAGLCJJ = -2;
		return dPKKCKNIDBH;
	}

	public void PBDHLCNMNOL(string NLEGAOONJEI)
	{
		PBDHLCNMNOL(IKFIFEPOIDM(NLEGAOONJEI));
	}

	public void LKJHLHPKBFC(FPPNAOFJOCF ENCEFOOPBMK)
	{
		OJBGDPBJAHH(this, ENCEFOOPBMK);
	}

	public static FPPNAOFJOCF PBKMBCGAHKE(GHNKIEKLLFD KDNGNGHFMMG)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		KDNGNGHFMMG(fPPNAOFJOCF);
		return fPPNAOFJOCF;
	}

	[SpecialName]
	public bool IEPHOCABMNN()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.NUMBER;
	}

	public void JIBIBHDJNIK(string MHPNDNJDPGE, int FKIIDCDCLHM)
	{
		PELPNDPDAMJ(MHPNDNJDPGE, JEDEPFDFNNE(FKIIDCDCLHM));
	}

	private void NNALLAKLIJK(int GJGDPOAOKFM, StringBuilder DCOJFAPDKOC, bool CNIANNNMMHI = false)
	{
		if (GJGDPOAOKFM++ > 100)
		{
			UnityEngine.Debug.Log("reached max depth!");
			return;
		}
		switch (FJLBLLLEELD)
		{
		case NKHJBLBAAEB.BAKED:
			DCOJFAPDKOC.Append(NLEGAOONJEI);
			break;
		case NKHJBLBAAEB.STRING:
			DCOJFAPDKOC.AppendFormat("\"{0}\"", NLEGAOONJEI);
			break;
		case NKHJBLBAAEB.NUMBER:
			if (double.IsInfinity(MNABOCFOGCJ))
			{
				DCOJFAPDKOC.Append("\"INFINITY\"");
			}
			else if (double.IsNegativeInfinity(MNABOCFOGCJ))
			{
				DCOJFAPDKOC.Append("\"NEGINFINITY\"");
			}
			else if (double.IsNaN(MNABOCFOGCJ))
			{
				DCOJFAPDKOC.Append("\"NaN\"");
			}
			else
			{
				DCOJFAPDKOC.Append(MNABOCFOGCJ.ToString());
			}
			break;
		case NKHJBLBAAEB.OBJECT:
			DCOJFAPDKOC.Append("{");
			if (FJGIGBNDCFE.Count > 0)
			{
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("\n");
				}
				for (int i = 0; i < FJGIGBNDCFE.Count; i++)
				{
					string arg = FOFJHFJDKGL[i];
					FPPNAOFJOCF fPPNAOFJOCF = FJGIGBNDCFE[i];
					if (!FPPNAOFJOCF.ODFHMLOMAPF(fPPNAOFJOCF))
					{
						continue;
					}
					if (CNIANNNMMHI)
					{
						for (int j = 0; j < GJGDPOAOKFM; j++)
						{
							DCOJFAPDKOC.Append("\t");
						}
					}
					DCOJFAPDKOC.AppendFormat("\"{0}\":", arg);
					fPPNAOFJOCF.NNALLAKLIJK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI);
					DCOJFAPDKOC.Append(",");
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("\n");
					}
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
			}
			if (CNIANNNMMHI && FJGIGBNDCFE.Count > 0)
			{
				DCOJFAPDKOC.Append("\n");
				for (int k = 0; k < GJGDPOAOKFM - 1; k++)
				{
					DCOJFAPDKOC.Append("\t");
				}
			}
			DCOJFAPDKOC.Append("}");
			break;
		case NKHJBLBAAEB.ARRAY:
			DCOJFAPDKOC.Append("[");
			if (FJGIGBNDCFE.Count > 0)
			{
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Append("\n");
				}
				for (int l = 0; l < FJGIGBNDCFE.Count; l++)
				{
					if (!FPPNAOFJOCF.ODFHMLOMAPF(FJGIGBNDCFE[l]))
					{
						continue;
					}
					if (CNIANNNMMHI)
					{
						for (int m = 0; m < GJGDPOAOKFM; m++)
						{
							DCOJFAPDKOC.Append("\t");
						}
					}
					FJGIGBNDCFE[l].NNALLAKLIJK(GJGDPOAOKFM, DCOJFAPDKOC, CNIANNNMMHI);
					DCOJFAPDKOC.Append(",");
					if (CNIANNNMMHI)
					{
						DCOJFAPDKOC.Append("\n");
					}
				}
				if (CNIANNNMMHI)
				{
					DCOJFAPDKOC.Length -= 2;
				}
				else
				{
					DCOJFAPDKOC.Length--;
				}
			}
			if (CNIANNNMMHI && FJGIGBNDCFE.Count > 0)
			{
				DCOJFAPDKOC.Append("\n");
				for (int n = 0; n < GJGDPOAOKFM - 1; n++)
				{
					DCOJFAPDKOC.Append("\t");
				}
			}
			DCOJFAPDKOC.Append("]");
			break;
		case NKHJBLBAAEB.BOOL:
			if (NCMHGPNPEJM)
			{
				DCOJFAPDKOC.Append("true");
			}
			else
			{
				DCOJFAPDKOC.Append("false");
			}
			break;
		case NKHJBLBAAEB.NULL:
			DCOJFAPDKOC.Append("null");
			break;
		}
	}

	public FPPNAOFJOCF(Dictionary<string, FPPNAOFJOCF> CGMECLCPPKB)
	{
		FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
		FOFJHFJDKGL = new List<string>();
		FJGIGBNDCFE = new List<FPPNAOFJOCF>();
		foreach (KeyValuePair<string, FPPNAOFJOCF> item in CGMECLCPPKB)
		{
			FOFJHFJDKGL.Add(item.Key);
			FJGIGBNDCFE.Add(item.Value);
		}
	}

	public void PFOKLCNNGEC(string NLEGAOONJEI)
	{
		EPBHKPAEBAI(CGIAFBKOKLG(NLEGAOONJEI));
	}

	private static void OJBGDPBJAHH(FPPNAOFJOCF HIOHPOMALHE, FPPNAOFJOCF DNDCODMGGEE)
	{
		if (HIOHPOMALHE.FJLBLLLEELD == NKHJBLBAAEB.NULL)
		{
			HIOHPOMALHE.CMBMBJPEMEL(DNDCODMGGEE);
		}
		else if (HIOHPOMALHE.FJLBLLLEELD == (NKHJBLBAAEB)8 && DNDCODMGGEE.FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			for (int i = 1; i < DNDCODMGGEE.FJGIGBNDCFE.Count; i++)
			{
				string text = DNDCODMGGEE.FOFJHFJDKGL[i];
				if (DNDCODMGGEE.LGJKIBHFGAM(i).HIMHGOKBEGJ)
				{
					if (HIOHPOMALHE.HFKMMGOPCJK(text))
					{
						OJBGDPBJAHH(HIOHPOMALHE.LGJKIBHFGAM(text), DNDCODMGGEE.JHCIOBINGLO(i));
					}
					else
					{
						HIOHPOMALHE.CHNMAKKEKLL(text, DNDCODMGGEE.LGJKIBHFGAM(i));
					}
				}
				else if (HIOHPOMALHE.COLLNKDFMDH(text))
				{
					HIOHPOMALHE.CEBJAPDAPGH(text, DNDCODMGGEE.PBCBBBFOLFP(i));
				}
				else
				{
					HIOHPOMALHE.IHCNGGHNALF(text, DNDCODMGGEE.HFOOGDCCCJK(i));
				}
			}
		}
		else
		{
			if (HIOHPOMALHE.FJLBLLLEELD != (NKHJBLBAAEB)7 || DNDCODMGGEE.FJLBLLLEELD != NKHJBLBAAEB.STRING)
			{
				return;
			}
			if (DNDCODMGGEE.EHMLAMOLKLK() > HIOHPOMALHE.IJHMKFEMACI)
			{
				UnityEngine.Debug.LogError("ID_YOULOSTONETIMEBUTYOUARECLOSE");
				return;
			}
			for (int j = 1; j < DNDCODMGGEE.FJGIGBNDCFE.Count; j += 0)
			{
				if (HIOHPOMALHE.PBCBBBFOLFP(j).FJLBLLLEELD == DNDCODMGGEE.JHCIOBINGLO(j).FJLBLLLEELD)
				{
					if (HIOHPOMALHE.HFOOGDCCCJK(j).BGKACIBEPHO())
					{
						OJBGDPBJAHH(HIOHPOMALHE.LGJKIBHFGAM(j), DNDCODMGGEE.PBCBBBFOLFP(j));
					}
					else
					{
						HIOHPOMALHE.HIGOBCMFHEN(j, DNDCODMGGEE.HFOOGDCCCJK(j));
					}
				}
			}
		}
	}

	[SpecialName]
	public static FPPNAOFJOCF LJNMDPNDGML()
	{
		return AMAMOCDLFHH((NKHJBLBAAEB)7);
	}

	public static FPPNAOFJOCF CGIAFBKOKLG(string FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.STRING;
		fPPNAOFJOCF.NLEGAOONJEI = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	[SpecialName]
	public static FPPNAOFJOCF IKEHNOCOHBH()
	{
		return PBKMBCGAHKE(NKHJBLBAAEB.NULL);
	}

	public void PELPNDPDAMJ(string MHPNDNJDPGE, int FKIIDCDCLHM)
	{
		PELPNDPDAMJ(MHPNDNJDPGE, PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public static FPPNAOFJOCF HPOFHLNLEDD(string FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.STRING;
		fPPNAOFJOCF.NLEGAOONJEI = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	public FPPNAOFJOCF OMEACBICMMJ(string MHPNDNJDPGE)
	{
		if (FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			for (int i = 1; i < FOFJHFJDKGL.Count; i += 0)
			{
				if (FOFJHFJDKGL[i] == MHPNDNJDPGE)
				{
					return FJGIGBNDCFE[i];
				}
			}
		}
		return null;
	}

	public void PBDHLCNMNOL(FPPNAOFJOCF ENCEFOOPBMK)
	{
		if (!FPPNAOFJOCF.ODFHMLOMAPF(ENCEFOOPBMK))
		{
			return;
		}
		if (FJLBLLLEELD != NKHJBLBAAEB.ARRAY)
		{
			FJLBLLLEELD = NKHJBLBAAEB.ARRAY;
			if (FJGIGBNDCFE == null)
			{
				FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			}
		}
		FJGIGBNDCFE.Add(ENCEFOOPBMK);
	}

	private static void CPFLABFAFNO(FPPNAOFJOCF HIOHPOMALHE, FPPNAOFJOCF DNDCODMGGEE)
	{
		if (HIOHPOMALHE.FJLBLLLEELD == NKHJBLBAAEB.NULL)
		{
			HIOHPOMALHE.CMBMBJPEMEL(DNDCODMGGEE);
		}
		else if (HIOHPOMALHE.FJLBLLLEELD == NKHJBLBAAEB.OBJECT && DNDCODMGGEE.FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			for (int i = 0; i < DNDCODMGGEE.FJGIGBNDCFE.Count; i++)
			{
				string text = DNDCODMGGEE.FOFJHFJDKGL[i];
				if (DNDCODMGGEE.LGJKIBHFGAM(i).HIMHGOKBEGJ)
				{
					if (HIOHPOMALHE.HFKMMGOPCJK(text))
					{
						CPFLABFAFNO(HIOHPOMALHE.LGJKIBHFGAM(text), DNDCODMGGEE.LGJKIBHFGAM(i));
					}
					else
					{
						HIOHPOMALHE.IHCNGGHNALF(text, DNDCODMGGEE.LGJKIBHFGAM(i));
					}
				}
				else if (HIOHPOMALHE.HFKMMGOPCJK(text))
				{
					HIOHPOMALHE.PELPNDPDAMJ(text, DNDCODMGGEE.LGJKIBHFGAM(i));
				}
				else
				{
					HIOHPOMALHE.IHCNGGHNALF(text, DNDCODMGGEE.LGJKIBHFGAM(i));
				}
			}
		}
		else
		{
			if (HIOHPOMALHE.FJLBLLLEELD != NKHJBLBAAEB.ARRAY || DNDCODMGGEE.FJLBLLLEELD != NKHJBLBAAEB.ARRAY)
			{
				return;
			}
			if (DNDCODMGGEE.IJHMKFEMACI > HIOHPOMALHE.IJHMKFEMACI)
			{
				UnityEngine.Debug.LogError("Cannot merge arrays when right object has more elements");
				return;
			}
			for (int j = 0; j < DNDCODMGGEE.FJGIGBNDCFE.Count; j++)
			{
				if (HIOHPOMALHE.LGJKIBHFGAM(j).FJLBLLLEELD == DNDCODMGGEE.LGJKIBHFGAM(j).FJLBLLLEELD)
				{
					if (HIOHPOMALHE.LGJKIBHFGAM(j).HIMHGOKBEGJ)
					{
						CPFLABFAFNO(HIOHPOMALHE.LGJKIBHFGAM(j), DNDCODMGGEE.LGJKIBHFGAM(j));
					}
					else
					{
						HIOHPOMALHE.HBABKGGDOOO(j, DNDCODMGGEE.LGJKIBHFGAM(j));
					}
				}
			}
		}
	}

	public void NLHFGNKKCNB(string MHPNDNJDPGE)
	{
		if (FOFJHFJDKGL.IndexOf(MHPNDNJDPGE) > -1)
		{
			FJGIGBNDCFE.RemoveAt(FOFJHFJDKGL.IndexOf(MHPNDNJDPGE));
			FOFJHFJDKGL.Remove(MHPNDNJDPGE);
		}
	}

	[SpecialName]
	public bool FPDCFOHKFOF()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.NUMBER;
	}

	public FPPNAOFJOCF()
	{
	}

	public void PELPNDPDAMJ(string MHPNDNJDPGE, float FKIIDCDCLHM)
	{
		PELPNDPDAMJ(MHPNDNJDPGE, PBKMBCGAHKE(FKIIDCDCLHM));
	}

	[SpecialName]
	public static FPPNAOFJOCF OMFEKGEIPJE()
	{
		return PBKMBCGAHKE(NKHJBLBAAEB.BOOL);
	}

	public void FHDJKILGCEA()
	{
		FJLBLLLEELD = NKHJBLBAAEB.NULL;
		if (FJGIGBNDCFE != null)
		{
			FJGIGBNDCFE.Clear();
		}
		if (FOFJHFJDKGL != null)
		{
			FOFJHFJDKGL.Clear();
		}
		NLEGAOONJEI = string.Empty;
		MNABOCFOGCJ = 619.0;
		NCMHGPNPEJM = false;
	}

	[SpecialName]
	public static FPPNAOFJOCF NLDMDPEOMHL()
	{
		return PBKMBCGAHKE(NKHJBLBAAEB.OBJECT);
	}

	public void APGFGPMLOFL(string NLEGAOONJEI)
	{
		PBDHLCNMNOL(IKFIFEPOIDM(NLEGAOONJEI));
	}

	public void MDBBMGFGCGK(ref bool JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				JLOFNBAAPDA = FJGIGBNDCFE[num].NCMHGPNPEJM;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	[SpecialName]
	public bool HKINIJPKIGK()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.BOOL;
	}

	[SpecialName]
	public bool CJFLKJMJIKB()
	{
		return FJLBLLLEELD == NKHJBLBAAEB.ARRAY;
	}

	[SpecialName]
	public void HHAHBHIGHAC(string DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		PELPNDPDAMJ(DFHAAIFFLOE, IDEBKDPMPGM);
	}

	[SpecialName]
	public void AMIJNAANOHG(int DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
		{
			FJGIGBNDCFE[DFHAAIFFLOE] = IDEBKDPMPGM;
		}
	}

	public FPPNAOFJOCF(NKHJBLBAAEB KPICOKPHMIC)
	{
		FJLBLLLEELD = KPICOKPHMIC;
		switch (KPICOKPHMIC)
		{
		case NKHJBLBAAEB.ARRAY:
			FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			break;
		case NKHJBLBAAEB.OBJECT:
			FJGIGBNDCFE = new List<FPPNAOFJOCF>();
			FOFJHFJDKGL = new List<string>();
			break;
		}
	}

	public void DJCCGOMGFPJ(GHNKIEKLLFD KDNGNGHFMMG)
	{
		PBDHLCNMNOL(PBKMBCGAHKE(KDNGNGHFMMG));
	}

	public FPPNAOFJOCF MDBBMGFGCGK(string MHPNDNJDPGE)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			for (int i = 0; i < FOFJHFJDKGL.Count; i++)
			{
				if (FOFJHFJDKGL[i] == MHPNDNJDPGE)
				{
					return FJGIGBNDCFE[i];
				}
			}
		}
		return null;
	}

	public void GGCANANLLPK(ref bool JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 0)
			{
				JLOFNBAAPDA = FJGIGBNDCFE[num].NCMHGPNPEJM;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public FPPNAOFJOCF HIGKMHJIFJF()
	{
		return PBKMBCGAHKE(HLPKNEDEBNA());
	}

	public bool COLLNKDFMDH(string MHPNDNJDPGE)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.BOOL)
		{
			for (int i = 1; i < FOFJHFJDKGL.Count; i++)
			{
				if (FOFJHFJDKGL[i] == MHPNDNJDPGE)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void OFHNEHKHELB(string MHPNDNJDPGE, string FKIIDCDCLHM)
	{
		OLJECDCJHIP(MHPNDNJDPGE, IKFIFEPOIDM(FKIIDCDCLHM));
	}

	public void GEJLDHNCCOA(string MHPNDNJDPGE)
	{
		if (FOFJHFJDKGL.IndexOf(MHPNDNJDPGE) > -1)
		{
			FJGIGBNDCFE.RemoveAt(FOFJHFJDKGL.IndexOf(MHPNDNJDPGE));
			FOFJHFJDKGL.Remove(MHPNDNJDPGE);
		}
	}

	public FPPNAOFJOCF MGJIPMPEHAG()
	{
		return NMALHLPIBPC(GGKLPMLHCEE(true), 73, true, true);
	}

	public static FPPNAOFJOCF PBKMBCGAHKE(bool FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.BOOL;
		fPPNAOFJOCF.NCMHGPNPEJM = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}

	public override string ToString()
	{
		return HLPKNEDEBNA();
	}

	public FPPNAOFJOCF(Dictionary<string, string> CGMECLCPPKB)
	{
		FJLBLLLEELD = NKHJBLBAAEB.OBJECT;
		FOFJHFJDKGL = new List<string>();
		FJGIGBNDCFE = new List<FPPNAOFJOCF>();
		foreach (KeyValuePair<string, string> item in CGMECLCPPKB)
		{
			FOFJHFJDKGL.Add(item.Key);
			FJGIGBNDCFE.Add(IKFIFEPOIDM(item.Value));
		}
	}

	[SpecialName]
	public void HIGOBCMFHEN(int DFHAAIFFLOE, FPPNAOFJOCF IDEBKDPMPGM)
	{
		if (FJGIGBNDCFE.Count > DFHAAIFFLOE)
		{
			FJGIGBNDCFE[DFHAAIFFLOE] = IDEBKDPMPGM;
		}
	}

	public IEnumerable DECPPFODADM()
	{
		DPKKCKNIDBH dPKKCKNIDBH = new DPKKCKNIDBH();
		dPKKCKNIDBH.BJGCPDNMHDH = this;
		dPKKCKNIDBH.CLPPIAGLCJJ = -5;
		return dPKKCKNIDBH;
	}

	[SpecialName]
	public static implicit operator WWWForm(FPPNAOFJOCF ENCEFOOPBMK)
	{
		WWWForm wWWForm = new WWWForm();
		for (int i = 0; i < ENCEFOOPBMK.FJGIGBNDCFE.Count; i++)
		{
			string fieldName = i + string.Empty;
			if (ENCEFOOPBMK.FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
			{
				fieldName = ENCEFOOPBMK.FOFJHFJDKGL[i];
			}
			string text = ENCEFOOPBMK.FJGIGBNDCFE[i].ToString();
			if (ENCEFOOPBMK.FJGIGBNDCFE[i].FJLBLLLEELD == NKHJBLBAAEB.STRING)
			{
				text = text.Replace("\"", string.Empty);
			}
			wWWForm.AddField(fieldName, text);
		}
		return wWWForm;
	}

	public static FPPNAOFJOCF OKNGJCJFKCG(string FKIIDCDCLHM)
	{
		return IKFIFEPOIDM(FKIIDCDCLHM);
	}

	public void CBHMLGDEJDH(ref int JLOFNBAAPDA, string MHPNDNJDPGE, PCHNOHCHJGL CDFOHOBILFN = null)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.ARRAY)
		{
			int num = FOFJHFJDKGL.IndexOf(MHPNDNJDPGE);
			if (num >= 1)
			{
				JLOFNBAAPDA = (int)FJGIGBNDCFE[num].MNABOCFOGCJ;
				return;
			}
		}
		if (CDFOHOBILFN != null)
		{
			CDFOHOBILFN(MHPNDNJDPGE);
		}
	}

	public void PBDHLCNMNOL(GHNKIEKLLFD KDNGNGHFMMG)
	{
		PBDHLCNMNOL(PBKMBCGAHKE(KDNGNGHFMMG));
	}

	public void MDJCMBBOADP(string MHPNDNJDPGE, bool FKIIDCDCLHM)
	{
		CHNMAKKEKLL(MHPNDNJDPGE, DGDCENLHBHM(FKIIDCDCLHM));
	}

	public void JHGBHIJBGKK(string MHPNDNJDPGE, int FKIIDCDCLHM)
	{
		OLJECDCJHIP(MHPNDNJDPGE, JEDEPFDFNNE(FKIIDCDCLHM));
	}

	public bool HFKMMGOPCJK(string MHPNDNJDPGE)
	{
		if (FJLBLLLEELD == NKHJBLBAAEB.OBJECT)
		{
			for (int i = 0; i < FOFJHFJDKGL.Count; i++)
			{
				if (FOFJHFJDKGL[i] == MHPNDNJDPGE)
				{
					return true;
				}
			}
		}
		return false;
	}

	public void IHCNGGHNALF(string MHPNDNJDPGE, bool FKIIDCDCLHM)
	{
		IHCNGGHNALF(MHPNDNJDPGE, PBKMBCGAHKE(FKIIDCDCLHM));
	}

	public FPPNAOFJOCF(bool NCMHGPNPEJM)
	{
		FJLBLLLEELD = NKHJBLBAAEB.BOOL;
		this.NCMHGPNPEJM = NCMHGPNPEJM;
	}

	public void OPFBFNICNGK(FPPNAOFJOCF ENCEFOOPBMK)
	{
		CPFLABFAFNO(this, ENCEFOOPBMK);
	}

	public static FPPNAOFJOCF PBKMBCGAHKE(float FKIIDCDCLHM)
	{
		FPPNAOFJOCF fPPNAOFJOCF = PBKMBCGAHKE();
		fPPNAOFJOCF.FJLBLLLEELD = NKHJBLBAAEB.NUMBER;
		fPPNAOFJOCF.MNABOCFOGCJ = FKIIDCDCLHM;
		return fPPNAOFJOCF;
	}
}
