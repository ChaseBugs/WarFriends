using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public static class FGMEIEBKNEK
{
	private sealed class AIJGDGDBGJA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<AudioSource> AFJACLNOKFE;

		internal List<AIObject>.Enumerator KFCAECGLKKO;

		internal float GDDDBAIDECN;

		internal float LADMMFLMOLE;

		internal float BHGHMDGFCOH;

		internal List<AudioSource>.Enumerator GHCPBBJDIBB;

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

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 1064f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1908f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 419f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1044f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 763f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1463f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IJBDKMGNEPK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DJIJFANFBCP()
		{
			return PHDOCKCBJOF;
		}

		public bool IGOAJGEADPH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 1588f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1675f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 525f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1429f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void CPEEDIDEKLA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BBOGBCNCIFN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object COEKBAFPBLD()
		{
			return PHDOCKCBJOF;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 13f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 789f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void HCPCOBKDMJA()
		{
			throw new NotSupportedException();
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BBDOFDBCILK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		public bool ECPGMIIEFDP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 1189f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1792f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool DAKMHLEGICB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 81f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1332f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GPJGKJCDFOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KPJIDBHHKFM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MJKLPCMKADD()
		{
			return PHDOCKCBJOF;
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 239f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 320f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public void IFBOOBLACGK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LHMPDOBMOLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 245f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 432f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FLJNAIIJAFO()
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
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 0.75f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object DFKJEOAPBGP()
		{
			return PHDOCKCBJOF;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 937f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 690f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MKEJDEGFKLC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LPMKMBAOMFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public void KAFNGNMNNOA()
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
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 1662f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1532f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public AIJGDGDBGJA()
		{
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENJAAMADMEH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OGHGAAFEEMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KPNBIPDNGOM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AJPFLBOOFNJ()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void EPIIDCKHCIN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public void NIEPBMPJEAE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 1990f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1983f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MFNFCFAJKCM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
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
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 1540f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1092f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ELNKFJHGFPD()
		{
			return PHDOCKCBJOF;
		}

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJKELIBGG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void EGAONBPLDAG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool MHCIOCPGMHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 1008f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1009f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool DNDHHHDOLMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 222f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 25f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MOOGINPIELE()
		{
			return PHDOCKCBJOF;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOLLIAAFOMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OIMAEBOAMDB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
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
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 773f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 546f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BOENAMNMOAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AFJACLNOKFE = new List<AudioSource>();
				KFCAECGLKKO = BEHIKCEBALL.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.GetAudioSources(AFJACLNOKFE);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GDDDBAIDECN = 47f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (Time.realtimeSinceStartup - LADMMFLMOLE <= GDDDBAIDECN)
				{
					BHGHMDGFCOH = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GDDDBAIDECN);
					GHCPBBJDIBB = AFJACLNOKFE.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							AudioSource current2 = GHCPBBJDIBB.Current;
							current2.volume = 1852f - BHGHMDGFCOH;
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
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

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EPIKLCFKOBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMLPPCCDELM()
		{
			return PHDOCKCBJOF;
		}
	}

	public static readonly List<AIObject> MJICJFBPOMH = new List<AIObject>();

	private static readonly List<AIObject> BEHIKCEBALL = new List<AIObject>();

	private static int GAEEKBKALBN;

	private static int LAEMBJAPOGF;

	public static void PCDHJCEAHBD()
	{
		Singleton<GameCamera>.instance.FKFDNNPBOFI.SetActive(false);
		try
		{
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (Singleton<LevelBehaviourManager>.instance.HHACPHOMPIL[behaviour].Count > 0)
				{
					AIObject aIObject = Singleton<LevelBehaviourManager>.instance.HHACPHOMPIL[behaviour][0];
					if (aIObject != null && aIObject.prefab != null)
					{
						ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(aIObject.prefab);
					}
				}
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	public static void EFAPJLOACKP()
	{
		try
		{
			List<Vector3> gDAFLEDIOJP = Singleton<GameCamera>.instance.GDAFLEDIOJP;
			List<Quaternion> jPMGIHOPPCH = Singleton<GameCamera>.instance.JPMGIHOPPCH;
			for (int i = 0; i < MJICJFBPOMH.Count; i++)
			{
				EnemyController enemyController = (EnemyController)MJICJFBPOMH[i];
				if (enemyController != null)
				{
					Transform transform = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
					Vector3 vector = ECMEFIJPCCG(PlayerController.OGMBJPKOPCB) + transform.transform.rotation * Quaternion.Euler(0f, 90f, 0f) * gDAFLEDIOJP[i];
					Vector3 vector2 = transform.forward * 2f;
					NavMeshHit hit;
					NavMesh.SamplePosition(vector + vector2, out hit, 10f, 1);
					enemyController.transform.position = hit.position;
					enemyController.transform.rotation = transform.transform.rotation * Quaternion.Euler(0f, 90f, 0f) * jPMGIHOPPCH[i];
					enemyController.transform.localScale = Vector3.one;
					enemyController.StartAnim(vector);
				}
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	public static void EHLIEODKCBF()
	{
		Singleton<GameCamera>.instance.StartCoroutine(EEELCHMGHFP());
		try
		{
			List<Vector3> gDAFLEDIOJP = Singleton<GameCamera>.instance.GDAFLEDIOJP;
			for (int i = 0; i < MJICJFBPOMH.Count; i++)
			{
				EnemyController enemyController = (EnemyController)MJICJFBPOMH[i];
				if (enemyController != null && enemyController.isInstantiated)
				{
					Transform transform = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
					Vector3 vector = ECMEFIJPCCG(PlayerController.OGMBJPKOPCB) + transform.transform.rotation * Quaternion.Euler(0f, 90f, 0f) * gDAFLEDIOJP[i];
					Vector3 vector2 = transform.forward * 3f;
					enemyController.StartAnim(vector + vector2);
				}
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	public static void EADCGMAPNDC()
	{
		foreach (AIObject item in BEHIKCEBALL)
		{
			BFOAAICAEMN bFOAAICAEMN = item as BFOAAICAEMN;
			if (bFOAAICAEMN != null && item.isInstantiated)
			{
				bFOAAICAEMN.DoReverseAnim();
			}
		}
	}

	public static Vector3 ECMEFIJPCCG(PlayerController NMDBNHBDMJO)
	{
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		Vector3 a = ((NMDBNHBDMJO.currentPlayerPoint.index <= 3) ? bBJMLOCKNHD[0].point.transform.position : bBJMLOCKNHD[4].point.transform.position);
		Vector3 b = ((NMDBNHBDMJO.currentPlayerPoint.index <= 3) ? bBJMLOCKNHD[3].point.transform.position : bBJMLOCKNHD[7].point.transform.position);
		return Vector3.Lerp(a, b, 0.5f);
	}

	public static Vector3 ILGFKGICJOK(PlayerController NMDBNHBDMJO, LevelBehaviour NCMHGPNPEJM)
	{
		bool flag = true;
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		Vector3 vector = ((NMDBNHBDMJO.currentPlayerPoint.index <= 3) ? bBJMLOCKNHD[0].point.transform.position : bBJMLOCKNHD[4].point.transform.position);
		Vector3 vector2 = ((NMDBNHBDMJO.currentPlayerPoint.index <= 3) ? bBJMLOCKNHD[3].point.transform.position : bBJMLOCKNHD[7].point.transform.position);
		vector -= NMDBNHBDMJO.currentPlayerPoint.point.transform.forward * 0.1f;
		vector2 -= NMDBNHBDMJO.currentPlayerPoint.point.transform.forward * 0.1f;
		if (NCMHGPNPEJM is HelicopterBehaviour || NCMHGPNPEJM is AssaultHelicopterBehaviour)
		{
			if (LAEMBJAPOGF > 0)
			{
				flag = false;
			}
			LAEMBJAPOGF++;
			Vector3 vector3 = (vector2 - vector).normalized;
			if (flag)
			{
				vector3 = -vector3;
			}
			if (flag)
			{
				return vector + vector3 + 2f * Vector3.up;
			}
			return vector2 + vector3 + 2f * Vector3.up + 0.3f * Vector3.up;
		}
		if (NCMHGPNPEJM is CarBehaviour || NCMHGPNPEJM is CarBuggyBehaviour || NCMHGPNPEJM is TankBehaviour || NCMHGPNPEJM is CarTransporterBehaviour)
		{
			Vector3 normalized = (vector - vector2).normalized;
			GAEEKBKALBN++;
			Vector3 zero = Vector3.zero;
			switch (GAEEKBKALBN)
			{
			case 1:
				normalized = (vector - vector2).normalized * 1.2f;
				zero = vector + normalized;
				break;
			case 2:
				normalized = (vector2 - vector).normalized * 1.2f;
				zero = vector2 + normalized;
				break;
			case 3:
				normalized = NMDBNHBDMJO.currentPlayerPoint.point.transform.forward * 1.8f + (vector - vector2).normalized * 0.3f;
				zero = vector + normalized;
				break;
			default:
				normalized = NMDBNHBDMJO.currentPlayerPoint.point.transform.forward * 1.8f + (vector2 - vector).normalized * 0.3f;
				zero = vector2 + normalized;
				break;
			}
			NavMeshHit hit;
			if (NavMesh.SamplePosition(zero, out hit, 10f, 1))
			{
				zero = hit.position;
			}
			Vector3 position = hit.position;
			return zero;
		}
		if (NCMHGPNPEJM is MechBehaviour)
		{
			Vector3 vector4 = NMDBNHBDMJO.currentPlayerPoint.point.transform.forward * 3f;
			Vector3 vector5 = Vector3.Lerp(vector, vector2, 0.5f);
			Vector3 vector6 = vector5 + vector4;
			NavMeshHit hit2;
			if (NavMesh.SamplePosition(vector6, out hit2, 10f, 1))
			{
				vector6 = hit2.position;
			}
			return vector6;
		}
		return Vector3.Lerp(vector, vector2, 0.5f) + Vector3.up * 0.5f + NMDBNHBDMJO.currentPlayerPoint.point.transform.forward * 1f + NMDBNHBDMJO.currentPlayerPoint.point.transform.right * 2.6f + 0.3f * Vector3.up;
	}

	public static void LJMGLMJBFKK()
	{
		Singleton<GameCamera>.instance.FKFDNNPBOFI.SetActive(false);
		MJICJFBPOMH.Clear();
		BEHIKCEBALL.Clear();
		int num = 0;
		List<LevelBehaviour> list = new List<LevelBehaviour>();
		List<LevelBehaviour> list2 = new List<LevelBehaviour>();
		PlayerController master = PlayerController.GetMaster();
		List<UnitUpgradeDefinition> list3 = master.EHHHBEMKGOE.KBBDGCLPOCJ;
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			if (levelBehaviour is SoldierBehaviour)
			{
				list.Add(levelBehaviour);
			}
		}
		for (int j = 0; j < LevelManager.instance.behaviours.Count; j++)
		{
			LevelBehaviour levelBehaviour2 = LevelManager.instance.behaviours[j];
			bool isEquipped = list3[j].isEquipped;
			if (!(levelBehaviour2 is SoldierBehaviour) && isEquipped)
			{
				list2.Add(levelBehaviour2);
			}
		}
		AnalyticsHelper.LeaveBreadcrumb("Generate army 1");
		try
		{
			for (int k = 0; k < list.Count; k++)
			{
				LevelBehaviour levelBehaviour3 = list[k];
				if (list3[levelBehaviour3.indexInLevelsManager].isEquipped)
				{
					AIObject aIObject = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(levelBehaviour3);
					if (aIObject != null && aIObject.prefab != null)
					{
						aIObject.LCDBACDIODH = true;
						aIObject.fraction = PlayerController.OGMBJPKOPCB.fraction;
						AIObject aIObject2 = (AIObject)ObjectPoolDatabase.networkPool.ReInstantiate(aIObject);
						MJICJFBPOMH.Add(aIObject2);
						aIObject2.transform.position = Vector3.zero;
						Vector3 position = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position;
						aIObject2.transform.rotation = Quaternion.LookRotation(position);
						aIObject2.LCDBACDIODH = true;
						aIObject2.UpdatePreview(true);
						num++;
					}
				}
				else
				{
					MJICJFBPOMH.Add(null);
				}
			}
			AnalyticsHelper.LeaveBreadcrumb("Generate army 2");
			LAEMBJAPOGF = 0;
			GAEEKBKALBN = 0;
			foreach (LevelBehaviour item in list2)
			{
				AIObject aIObject3 = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(item);
				if (aIObject3 != null && aIObject3.prefab != null)
				{
					aIObject3.LCDBACDIODH = true;
					aIObject3.fraction = PlayerController.OGMBJPKOPCB.fraction;
					AIObject aIObject4 = (AIObject)ObjectPoolDatabase.networkPool.ReInstantiate(aIObject3);
					ArmyUnit3DModel component = aIObject4.GetComponent<ArmyUnit3DModel>();
					Vector3 vector = ILGFKGICJOK(PlayerController.OGMBJPKOPCB, item);
					aIObject4.transform.position = vector;
					Vector3 forward = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position - vector;
					forward.y = 0f;
					aIObject4.transform.rotation = Quaternion.LookRotation(forward);
					aIObject4.LCDBACDIODH = true;
					aIObject4.UpdatePreview(true);
					BEHIKCEBALL.Add(aIObject4);
					num++;
				}
			}
			AnalyticsHelper.LeaveBreadcrumb("Generate army 3");
			EFAPJLOACKP();
			AnalyticsHelper.LeaveBreadcrumb("Generate army 4");
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	public static void AAILDANCKCG()
	{
		bool wasAlreadyUsed;
		LevelBehaviour lastBoughtUnit = PlayerAnalytics.instance.GetLastBoughtUnit(out wasAlreadyUsed);
		if (wasAlreadyUsed)
		{
			return;
		}
		for (int i = 0; i < MJICJFBPOMH.Count; i++)
		{
			EnemyController enemyController = (EnemyController)MJICJFBPOMH[i];
			if (enemyController != null && enemyController.IAJJBAJOGDM == lastBoughtUnit && lastBoughtUnit.upgradeSlots.unlockLevelIndex != 0)
			{
				AEGGGPPNGMO(enemyController);
			}
		}
		for (int j = 0; j < BEHIKCEBALL.Count; j++)
		{
			AIObject aIObject = BEHIKCEBALL[j];
			if (aIObject != null && aIObject.IAJJBAJOGDM == lastBoughtUnit && lastBoughtUnit.upgradeSlots.unlockLevelIndex != 0)
			{
				AEGGGPPNGMO(aIObject);
			}
		}
	}

	private static void AEGGGPPNGMO(AIObject KLHPCPKJGOC)
	{
		SkillShotController component = KLHPCPKJGOC.GetComponent<SkillShotController>();
		if (component != null)
		{
			NewUnitDisplayerItem newUnitDisplayerItem = UnityEngine.Object.Instantiate(Singleton<ObjectPoolDatabase>.instance.HPEONIPEEJJ);
			newUnitDisplayerItem.Play(KLHPCPKJGOC.ACLDFHJKBLI.unitName, component.JEGEBJNNHME.transform.position);
		}
		else
		{
			UnityEngine.Debug.LogError(KLHPCPKJGOC.gameObject.name + " has no SkillShotController");
		}
	}

	[DebuggerHidden]
	private static IEnumerator EEELCHMGHFP()
	{
		return new AIJGDGDBGJA();
	}
}
