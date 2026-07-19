using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class AtlasPreparer : Singleton<AtlasPreparer>
{
	public enum MFGNHIOKOEB
	{
		Game = 0,
		Menu = 1,
		Both = 2,
		Tutorial = 3
	}

	public enum OGBMODMIJIC
	{
		Resource = 0,
		AssetBundle = 1
	}

	public enum IDLCAPBLGFB
	{
		Normal = 0,
		Translate = 1,
		EventDefault = 2,
		EventWinter = 3
	}

	[Serializable]
	public class TextureDatasNgui
	{
		public UIAtlas atlas;

		public MFGNHIOKOEB mode = MFGNHIOKOEB.Menu;

		public OGBMODMIJIC resourceMode = OGBMODMIJIC.AssetBundle;

		public IDLCAPBLGFB type;

		public Language language;

		public UIAtlas atlasReference;
	}

	[Serializable]
	public class TextureDatas2DToolkit
	{
		public Material material;

		public MFGNHIOKOEB mode = MFGNHIOKOEB.Menu;

		public string textureName;
	}

	private sealed class KGFDANPPFEI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TextureDatasNgui>.Enumerator KFCAECGLKKO;

		internal List<TextureDatas2DToolkit>.Enumerator GHCPBBJDIBB;

		internal AtlasPreparer BJGCPDNMHDH;

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

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							OIJAFNGGJFO(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.CBFCCPENDOO());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							IHDMGDHAEIE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MPBCIIABPOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ECJHOPIBAMO()
		{
			return PHDOCKCBJOF;
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							GNOGCHCOAMO(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.CBFCCPENDOO());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							OIJAFNGGJFO(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FHIONKIFEOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		public bool DEEBEBGBMKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NNLPPBEFOKN(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FHIONKIFEOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							GNOGCHCOAMO(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMenuCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							BAOPKCAJFCJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MPBCIIABPOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							GNOGCHCOAMO(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMenuCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							BNDFEBPJOPL(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JBGNGBHPPGG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NJNEHLJIFNA(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMenuCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							BNDFEBPJOPL(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FHIONKIFEOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
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
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KPIBOJFODBE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OCEHLPKFPAJ());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							GNOGCHCOAMO(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FHIONKIFEOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PGOIHDIKFEI()
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
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							BNDFEBPJOPL(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMenuCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public KGFDANPPFEI()
		{
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		public bool CGOKGPGALLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NJNEHLJIFNA(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NFIPGIGIJMC());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KPIBOJFODBE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MPBCIIABPOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public bool KEBEGEDKIKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							BNDFEBPJOPL(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NFIPGIGIJMC());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void HCHNHNDDKKA()
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
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGBGCFGNJLA()
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
		private object KKKMCHGLHLL()
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
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							BAOPKCAJFCJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MPBCIIABPOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public bool CMBMOAECEJG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KPIBOJFODBE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MPBCIIABPOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NNLPPBEFOKN(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FHIONKIFEOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							BAOPKCAJFCJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MPBCIIABPOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class GMMPLJFDLPD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TextureDatasNgui>.Enumerator KFCAECGLKKO;

		internal List<TextureDatas2DToolkit>.Enumerator GHCPBBJDIBB;

		internal AtlasPreparer BJGCPDNMHDH;

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

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void OPMABIIDKCN()
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
		private object NDIGINEEOMH()
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
				ALJKAAMHHLB.HGHDLLMKPEO("Chillingo SDK: deactivate offers");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							IHDMGDHAEIE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				ALJKAAMHHLB.AKJCKAKDOGM("null");
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DFAMNPGBICF("RenameCount");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							OIJAFNGGJFO(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FPLBNAIFODD());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				ALJKAAMHHLB.CLDAEILOMJG("updating GC to: ");
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DPDCBOLJKOI("Time");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							GNOGCHCOAMO(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FPLBNAIFODD());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				ALJKAAMHHLB.BDMJCGAGCEE("MessageId");
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.IIKFADEHJIL("VipReward2");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NJNEHLJIFNA(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FNJFACLKMPN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				ALJKAAMHHLB.CNOACHKNDCB("Grenade_Throwing_Tutorial_Duration");
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.NGNJHNBEKNA("after update GC still GC account, but no added or missing gcID or gcPassword");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KPIBOJFODBE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HBBBHLPJOEO());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				ALJKAAMHHLB.AKJCKAKDOGM("Slon");
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FOODPOJODAA()
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
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public GMMPLJFDLPD()
		{
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DBPMPJCMPCO("ID_UNIT");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							BAOPKCAJFCJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DNEPNJGOIBD());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				ALJKAAMHHLB.BDMJCGAGCEE("ID_CONFIRM_ERROR");
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

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DPDCBOLJKOI("AtlasPreparer.ClearMenuLoadGameCoroutine");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu)
						{
							Texture mainTexture = current.atlas.spriteMaterial.mainTexture;
							current.atlas.spriteMaterial.mainTexture = BJGCPDNMHDH.PKLHJHBIDAD;
							Resources.UnloadAsset(mainTexture);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (GHCPBBJDIBB.MoveNext())
					{
						TextureDatas2DToolkit current2 = GHCPBBJDIBB.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							NJNEHLJIFNA(current2);
						}
					}
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				ALJKAAMHHLB.PDICPJLEKBI("AtlasPreparer.ClearMenuLoadGameCoroutine");
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class GMKGECBMKKM : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal AtlasPreparer BJGCPDNMHDH;

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

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.FLMPAIEBDBB("ID_CONFIRM_ERROR");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MCEJEPINFCM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NFIPGIGIJMC());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				ALJKAAMHHLB.BDMJCGAGCEE("1");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.BJDOHGKEMJH(" is not present in resources using default");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BAPBJNKIDLI());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JBGNGBHPPGG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				ALJKAAMHHLB.EFGMODDNPHN("menu-gold");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DPDCBOLJKOI("AtlasPreparer.LoadImagesCoroutine");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadCommonCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMenuCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				ALJKAAMHHLB.PDICPJLEKBI("AtlasPreparer.LoadImagesCoroutine");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.PDJBNKAOBBG("ID_STAT_MISSIONSSOLO");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LGLLGEEMIAH());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NFIPGIGIJMC());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				ALJKAAMHHLB.AKJCKAKDOGM(", pass = ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.EBHAFIJJMIN("withPublisherSubAdgroup");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.COHGIIPMEPB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NFIPGIGIJMC());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				ALJKAAMHHLB.CNOACHKNDCB("beginnersLeague");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void OJDEHKDDLFD()
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

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.PDJBNKAOBBG("ID_WARNING_ERRORCLAIMASSIGNMENT");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MCEJEPINFCM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FHIONKIFEOE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				ALJKAAMHHLB.CLDAEILOMJG("playerId");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public GMKGECBMKKM()
		{
		}
	}

	private sealed class PCAPPOINPME : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TextureDatasNgui>.Enumerator KFCAECGLKKO;

		internal List<TextureDatasNgui>.Enumerator GHCPBBJDIBB;

		internal TextureDatasNgui MDNLMJDCHKG;

		internal AtlasPreparer BJGCPDNMHDH;

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
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		public bool ILNBJIJONKD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.HGHDLLMKPEO("whiteRectangle");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)8 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967250u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)4 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.PDICPJLEKBI("Warbucks");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		public void OKIANDBCDIB()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void AMPGDAMMPFJ()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public bool MPKAJACHAIC()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.JLHKEEALMJK("Location");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)5 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.HEPONLKLFGB(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 121u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AEHLEODHMGP("Please add object to pool, before instanciing it ::: prefab name = ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return false;
			}
		}

		public bool GNFCLHDPPFP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.FBBJOALCEJJ("Defenders");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Tutorial && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 12u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Both || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EEDNCCEAKDI("Manual_Unit_Spawn");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public void DLIBOPAMHAN()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public PCAPPOINPME()
		{
		}

		public bool CCOPPEKLJOB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.FBBJOALCEJJ("S");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.FDFCEKIIFKM(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 37u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)4 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AEHLEODHMGP("In queue");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return false;
			}
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		public bool DMPHMFDEINI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.HAMPOPGACPA("setCustomProfileStringValue");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)4 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967266u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)4 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.BDMJCGAGCEE("shield_shot");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public void HCHNHNDDKKA()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object CICPCKDCCEF()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
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
				ALJKAAMHHLB.DPDCBOLJKOI("AtlasPreparer.LoadCommonCoroutine");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Both && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Both || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.PDICPJLEKBI("AtlasPreparer.LoadCommonCoroutine");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public bool JNHFCKKAPJH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DBPMPJCMPCO("mortar_up");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)5 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.HEPONLKLFGB(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 68u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)4 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AEHLEODHMGP("tierCount");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return false;
			}
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void GFJIKANGNMC()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void JBHOCIFIMBH()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.HAMPOPGACPA(",");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)4 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967175u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)8 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.BDMJCGAGCEE("N");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public bool CONJMMKAAGH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.NOGHPDFNHOB("Bullet with NO weapon");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)6 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 24u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.PDICPJLEKBI("ID_TUTORIAL_PROGRES_THROW");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public bool DEEBEBGBMKK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.PDJBNKAOBBG("rejectFriend");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967212u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)5 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AKJCKAKDOGM("1122334455");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return false;
			}
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public bool AGMKAADLHLE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.NGNJHNBEKNA("Warbucks");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Tutorial && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 0u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)6 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.ELFCGAGEFLH("Achievement Record ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return false;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class FCHFHFHBPDC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TextureDatasNgui>.Enumerator KFCAECGLKKO;

		internal List<TextureDatasNgui>.Enumerator GHCPBBJDIBB;

		internal TextureDatasNgui MDNLMJDCHKG;

		internal AtlasPreparer BJGCPDNMHDH;

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
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DPDCBOLJKOI("AtlasPreparer.LoadTutorialCoroutine");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Tutorial && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Tutorial || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.PDICPJLEKBI("AtlasPreparer.LoadTutorialCoroutine");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		public bool CCOPPEKLJOB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.JHOMLIBOPJD("Failed to join room during or after match and MatchManager.isReconnect = FALSE");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.HEPONLKLFGB(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967245u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EEDNCCEAKDI("Skipping wararena notification");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public void BBBLJNFEACC()
		{
			throw new NotSupportedException();
		}

		public bool ACHIHMMCDNF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KEMMFEFOMLJ("S");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.HEPONLKLFGB(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 81u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.GHBPDBCICLM("BattleRewards");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public void JCDBOCPAKEC()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void JBHOCIFIMBH()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool CJGKHIPOBGP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KEMMFEFOMLJ("_qbz2");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)4 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.FDFCEKIIFKM(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967262u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Tutorial || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.PDICPJLEKBI("menu-weapon-mp5-elite");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return false;
			}
		}

		public void FMINPCPGBBG()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public void IDCJDJMGKFG()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool OKELILGDPLJ()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.ACOCPELKALN("shop");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)7 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.HEPONLKLFGB(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 111u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AKJCKAKDOGM("null");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		[SpecialName]
		private object IIJAMNPBACH()
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
				ALJKAAMHHLB.KPDABFIIJMN("facebookID");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)8 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = uint.MaxValue;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)8 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EEDNCCEAKDI(" ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public bool PMJICFJGOBE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.EBHAFIJJMIN("DailyMission");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.FDFCEKIIFKM(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 76u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AKJCKAKDOGM(" was not found in Notification Center to remove");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		public void HHCIHDMICFP()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
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
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public bool ECPGMIIEFDP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.FLMPAIEBDBB("S");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)8 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JCCOHHCPGME(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967270u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)6 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.ELFCGAGEFLH("ID_CONFIRM_ERROR");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void PNGIELILHDI()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public bool BPHPJKKHNNG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.HAMPOPGACPA("ID_FEATURE_MAGAZINE-WEAPONPREFIX");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Tutorial && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967275u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)7 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EFGMODDNPHN("globalPlayerLeaderboard");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DFKJEOAPBGP()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public bool NEMOAIBCODB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.ABLGNNLDNHC("ID_OPENLOOTBOX");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)8 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967236u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Both || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.GHBPDBCICLM("ID_SALEPERCENT");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public void ENFGGBNAPGG()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public void ODCIKOOGNFG()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public void GOGEDHILBIA()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void APFFCILMOII()
		{
			throw new NotSupportedException();
		}

		public void KGLHLHLLOEM()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		public bool FCPJPIDEPOF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.BJDOHGKEMJH("MaintenanceMessage");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)8 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JCCOHHCPGME(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 86u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)8 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EEDNCCEAKDI("SlowMotionForNetwork");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public void CDIJEGGMMAK()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
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

		[SpecialName]
		private object KLECLPIKEJK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ALJCNLJGABF()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool NEPEDBPDMGL()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.JLHKEEALMJK("r");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JCCOHHCPGME(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 119u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Both || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.CNOACHKNDCB("Android");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return false;
			}
		}

		public bool AKFKBNAMOAI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KPDABFIIJMN("NewVisuals");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Both && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967264u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)5 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EEDNCCEAKDI("PlayerVisuals");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void GOCCDFALOHI()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object LPMKMBAOMFP()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public bool IGKACECJBEB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.JLHKEEALMJK("ID_READYTIME");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)5 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 41u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.ELFCGAGEFLH("#DANIEL# Price: {0}\nFormatted price: {1}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public void LFIGPJBHPBH()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void GFLFJHIPBNP()
		{
			throw new NotSupportedException();
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public void EBCEAGIOPJD()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void NCHGDJDAHGC()
		{
			throw new NotSupportedException();
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		public void GICFBDJLDKF()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void BDPFKFGBNOH()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool FPMHODJKAKK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.ACOCPELKALN("PlayerArmyPower");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)7 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967253u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.GHBPDBCICLM("WFX_MF");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		public void LPKDPNHBLGJ()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object GLAOFCCAAEN()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KNALFHAOFBN("_Color");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967225u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)8 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EEDNCCEAKDI("ID_SALEPERCENTLINE");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return false;
			}
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FLJNAIIJAFO()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void PMPGBMCHGPE()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JNKDBMNFGJJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public FCHFHFHBPDC()
		{
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public bool HJHJCCFGJIH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.HGHDLLMKPEO("GameController.StartGame - LoadingStarted");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)7 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 67u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)6 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AKJCKAKDOGM(" OK!");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPAFPFPNDNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool IGOAJGEADPH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.HAMPOPGACPA("getOriginalAccountAlias");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)8 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967192u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)7 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EEDNCCEAKDI("D2");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return false;
			}
		}

		public bool DNDHHHDOLMO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.NOGHPDFNHOB("left");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Both && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 47u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)8 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.ELFCGAGEFLH("Current unit is not delivering at the moment!!!");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public bool LGLPPAENMGK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DAMPOCJOEMP("FLOATVALUE");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)4 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.HEPONLKLFGB(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967268u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AKJCKAKDOGM("ID_CONFIRM_OFFERTOOSHORTDURATION");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return false;
			}
		}

		public void ODPKEEIHOPK()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		public bool HOOHJGPHHGN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.PKNOCKCFNPD("ID_UNLOCKEDATRANK");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)6 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 67u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Both || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.GHBPDBCICLM("Ground texture: ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return false;
			}
		}

		public bool EKGEDEKHBME()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DPDCBOLJKOI("Setting weapon delivery in ");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)8 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.HEPONLKLFGB(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967216u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)8 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.GHBPDBCICLM("de");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool CBGPIONEKLM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.ACOCPELKALN("PlayerName");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)4 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JCCOHHCPGME(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967226u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)7 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.AKJCKAKDOGM("Player id: {0}, player userId {1}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public bool FJKEEKBNKPN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.HGHDLLMKPEO("RETRYPERM");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == (MFGNHIOKOEB)5 && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967266u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Tutorial || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.ELFCGAGEFLH("SCHEDULING PLAYER STATUS UPDATE!!");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0176:
				return true;
			}
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void FFNAPBHOACE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		public void FLFOEIMCFBL()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool DEEBEBGBMKK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.FBBJOALCEJJ("game-revenge-indicator");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967284u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != (MFGNHIOKOEB)6 || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_0176;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				ALJKAAMHHLB.EFGMODDNPHN("Row: Rank");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0176:
				return true;
			}
		}

		public void MPNLGDNLLKF()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class MPDHFNOKJDF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TextureDatasNgui>.Enumerator KFCAECGLKKO;

		internal List<TextureDatasNgui>.Enumerator GHCPBBJDIBB;

		internal TextureDatasNgui MDNLMJDCHKG;

		internal List<TextureDatas2DToolkit>.Enumerator CFEHCIMDPPI;

		internal AtlasPreparer BJGCPDNMHDH;

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
		private object ONLMGMBKGHI()
		{
			return PHDOCKCBJOF;
		}

		public bool BKJCILLNJLG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.PKNOCKCFNPD("MapName");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 21u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							APOEFCADODE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.AKJCKAKDOGM("Can not find player with fraction ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return false;
			}
		}

		public bool BIGKCFMEBJE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DAMPOCJOEMP("ID_");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967210u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CNOACHKNDCB("ID_FACEBOOKLOGOUT");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return false;
			}
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void CPDBCJLIGFN()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public bool PPOPGFELIDA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KPDABFIIJMN("2 RATE APP REMINDER\tLast game won: True\tVersion: {0}\tShown Times in this version: {1}/{2}\tTotal ranked wins: {3}?={4}\tIs level up: {5}\tLevel: {6}?={7}/{8}\tAfter update: {9}");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 125u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CLDAEILOMJG("ID_CONFIRM_DOGTAGSAREFULL_TEXT");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return true;
			}
		}

		public bool ILNBJIJONKD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.LCICIHAHFPO("ID_WARNING_ELITESLOTLOCKED");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967220u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							KBJMFHMMCDM(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.BDMJCGAGCEE("com.upsight.mediation.unity.FuseUnitySDK");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return true;
			}
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		public bool PIAOIBJMLCC()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DAMPOCJOEMP(" ");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 8u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.AEHLEODHMGP(", Value = ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return false;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void ODPKEEIHOPK()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DFAMNPGBICF("ID_TOJOINSQUADYOUMUSTBEACCEPTED");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 126u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							APOEFCADODE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CLDAEILOMJG("DailyAssignmentsReminder");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return false;
			}
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public void AKEKFBGEJBG()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public bool EJKHEELJJFM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.NGNJHNBEKNA("ItemRarity_1");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967294u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							APOEFCADODE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.EEDNCCEAKDI("Incoming: ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return false;
			}
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public void FLFOEIMCFBL()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool IDBCKIPOEEI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.EBHAFIJJMIN("MINE");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.DAHPFNJKDFE(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967286u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							KHDCNHLJFJH(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.PDICPJLEKBI(" {0}\u00a0{1}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return true;
			}
		}

		public bool JNHFCKKAPJH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KPDABFIIJMN("Sessions");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 102u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KBJMFHMMCDM(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.EEDNCCEAKDI("VGOfferInfo");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return true;
			}
		}

		public void JGKDJGIANIG()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object NMAMPDNFNHE()
		{
			return PHDOCKCBJOF;
		}

		public void KOEEOJGJNAO()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void PMPGBMCHGPE()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object CLDLJNHAEAB()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public void OEHJOBELOFF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public bool KIFNNJFJJCG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.PKNOCKCFNPD("Notification_PlayerBattleChallenges");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JCCOHHCPGME(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 120u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KHDCNHLJFJH(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CNOACHKNDCB("testingidsquadjoined");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return true;
			}
		}

		public void KGLHLHLLOEM()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool JPBGJLDMOPO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.ABLGNNLDNHC("Managers");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.FDFCEKIIFKM(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 72u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KBJMFHMMCDM(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CLDAEILOMJG("Total_Warbucks_Spent");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return false;
			}
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void BLOCBAKBHBF()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public MPDHFNOKJDF()
		{
		}

		public bool DFMKKFMEBON()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.EBHAFIJJMIN("ID_GUI_MESSAGEFORYOU");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967184u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KBJMFHMMCDM(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.AEHLEODHMGP("\t\"TRUE\"");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return true;
			}
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		public void LFIGPJBHPBH()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		public bool CCOPPEKLJOB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.NBJCJMJIPND("Total_Gold_Earned");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.FDFCEKIIFKM(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 104u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							APOEFCADODE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.AKJCKAKDOGM("ID_RANKEDBATTLE");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return false;
			}
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void INBELBGOCLD()
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
				ALJKAAMHHLB.DPDCBOLJKOI("AtlasPreparer.LoadMenuCoroutine");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.PDICPJLEKBI("AtlasPreparer.LoadMenuCoroutine");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return true;
			}
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public bool CMBMOAECEJG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.LCICIHAHFPO("CONFIRM");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 63u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							APOEFCADODE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.AKJCKAKDOGM("Win");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return true;
			}
		}

		public void CJLDNKALLLI()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object BJECHFCOBLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public bool ICKNHCBNOMG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.ABLGNNLDNHC("doubleValue");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 90u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							KHDCNHLJFJH(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CNOACHKNDCB("unlockLevel");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return false;
			}
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void DBEMHFEBPFM()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void JKOCLGOOBEK()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		public void MPKODAJAPFD()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool KKINHOPBKLH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DFAMNPGBICF("ID_GUI_SQUADDEMOTION");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.HEPONLKLFGB(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967221u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KHDCNHLJFJH(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.EFGMODDNPHN("Sessions");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return true;
			}
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void OLPILJFHMGD()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void JOEOMEJLEID()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		public bool BLHOCNMMPNP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.FBBJOALCEJJ("ChillingoSdkManager");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 4294967292u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							APOEFCADODE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.PDICPJLEKBI("PauseGame: Focus lost {0}, time: {1}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return true;
			}
		}

		public bool LPCBKGKFNFD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KPDABFIIJMN("$100-$200");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Menu && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 85u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Menu)
						{
							KHDCNHLJFJH(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.EEDNCCEAKDI("IDFV");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d6:
				return true;
			}
		}

		public void NCOPKHMOMMK()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public bool OOECALAHCFK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.NGNJHNBEKNA("Local");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				num = 125u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Menu || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d6;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.ELFCGAGEFLH("-");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d6:
				return false;
			}
		}

		public void NFAMBMLLFGP()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}
	}

	private sealed class IFNELCHJJAA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TextureDatasNgui>.Enumerator KFCAECGLKKO;

		internal List<TextureDatasNgui>.Enumerator GHCPBBJDIBB;

		internal TextureDatasNgui MDNLMJDCHKG;

		internal List<TextureDatas2DToolkit>.Enumerator CFEHCIMDPPI;

		internal AtlasPreparer BJGCPDNMHDH;

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

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
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
				ALJKAAMHHLB.FBBJOALCEJJ("{0} {1}{2} {3}");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JCCOHHCPGME(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = Singleton<AtlasPreparer>.instance.KILDHCLINOO.GetEnumerator();
				num = 4294967247u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01d2;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.EEDNCCEAKDI("null");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d2:
				return false;
			}
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void CPDBCJLIGFN()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
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
				ALJKAAMHHLB.DPDCBOLJKOI("AtlasPreparer.LoadGameCoroutine");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.LoadTextureForAtlas(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = Singleton<AtlasPreparer>.instance.KILDHCLINOO.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_01d2;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.PDICPJLEKBI("AtlasPreparer.LoadGameCoroutine");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d2:
				return true;
			}
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public IFNELCHJJAA()
		{
		}

		public void OJDEHKDDLFD()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool LGNMOMFLLPP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KNALFHAOFBN("registerCustomProfileDate");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = Singleton<AtlasPreparer>.instance.KILDHCLINOO.GetEnumerator();
				num = 4294967258u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_01d2;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CNOACHKNDCB("ID_GUI_GOLD");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d2:
				return false;
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool GNFCLHDPPFP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.KNALFHAOFBN("Changing send logs text to ");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = Singleton<AtlasPreparer>.instance.KILDHCLINOO.GetEnumerator();
				num = 73u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d2;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							APOEFCADODE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CLDAEILOMJG("{0} -> {1}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d2:
				return true;
			}
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool EKHDJADMNJK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.DFAMNPGBICF("{0}{1}[-] {2}/[-] {3}");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = Singleton<AtlasPreparer>.instance.KILDHCLINOO.GetEnumerator();
				num = 4294967183u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.Resource)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_01d2;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							NABGEGIJDDJ(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.ELFCGAGEFLH("Something went wrong in updating players in league");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d2:
				return true;
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
				ALJKAAMHHLB.HAMPOPGACPA("Reward {0:D2}");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.FDFCEKIIFKM(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = Singleton<AtlasPreparer>.instance.KILDHCLINOO.GetEnumerator();
				num = 98u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadTextureForAtlasCoroutine(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d2;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							APOEFCADODE(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.CLDAEILOMJG("com/google/android/gms/common/api/ResultCallback");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01d2:
				return true;
			}
		}

		public bool KHNDCDGBFJH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ALJKAAMHHLB.ACOCPELKALN("N");
				KFCAECGLKKO = BJGCPDNMHDH.KILDHCLINOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TextureDatasNgui current = KFCAECGLKKO.Current;
						if (current.mode == MFGNHIOKOEB.Game && current.resourceMode == OGBMODMIJIC.Resource)
						{
							BJGCPDNMHDH.JLMNKNBOLDA(current);
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GHCPBBJDIBB = Singleton<AtlasPreparer>.instance.KILDHCLINOO.GetEnumerator();
				num = 70u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (GHCPBBJDIBB.MoveNext())
					{
						MDNLMJDCHKG = GHCPBBJDIBB.Current;
						if (MDNLMJDCHKG.mode != MFGNHIOKOEB.Game || MDNLMJDCHKG.resourceMode != OGBMODMIJIC.AssetBundle)
						{
							continue;
						}
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HEEPIFDCINB(MDNLMJDCHKG.atlas));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01d2;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CFEHCIMDPPI = BJGCPDNMHDH.MGAICEDPPBF.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						TextureDatas2DToolkit current2 = CFEHCIMDPPI.Current;
						if (current2.mode == MFGNHIOKOEB.Game)
						{
							KHDCNHLJFJH(current2);
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				ALJKAAMHHLB.GHBPDBCICLM("RegisterBirthday()");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01d2:
				return true;
			}
		}

		public void MKIKEOOOLKL()
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
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
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}
	}

	private sealed class MGCPPBKHEPC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal UIAtlas EOBBMEFEOBN;

		internal string MJMLOPCBHOO;

		internal string JBDJMDHMIDE;

		internal AssetBundleReference LAMLFBJMLAJ;

		internal PKCDJCBCCDL LHGAKCGFJOI;

		internal Texture2D APOCEJDLEIN;

		internal AtlasPreparer BJGCPDNMHDH;

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
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[1];
				array[0] = "ID_ARENAREWARDREQUIREMENTS";
				array[1] = Screen.height;
				array[5] = "com/google/android/gms/common/ConnectionResult";
				array[5] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "resultMessage" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.HGLMJBEANEL(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.HGLMJBEANEL(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.BCAMEHFDDGF(JBDJMDHMIDE, true);
				EOBBMEFEOBN.pixelSize = 1693f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.LoadAssetAsync(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[1];
				array[1] = " ";
				array[1] = Screen.height;
				array[4] = "Not a player visual.";
				array[4] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "DOWNLOAD" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.UnloadAssetBundle(JBDJMDHMIDE);
				EOBBMEFEOBN.pixelSize = 1635f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.FPFDJJHHGNL(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			}
			return true;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[1];
				array[1] = "setValueForHookById";
				array[1] = Screen.height;
				array[7] = "ID_WARNING_CONNECTIONERROR";
				array[7] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "Fusebox: Bundle Id is chillingo! " + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.BJJBPFOOAKD(JBDJMDHMIDE);
				EOBBMEFEOBN.pixelSize = 1444f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.GDEFACFMDDP(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			}
			return true;
		}

		public void LICALBFPBLL()
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
			{
				object[] array = new object[1];
				array[0] = "ActivateBonusResultRPC";
				array[1] = Screen.height;
				array[8] = "PlayerProgressRate";
				array[7] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "Wrong_Unit" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.HGLMJBEANEL(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.BJJBPFOOAKD(JBDJMDHMIDE);
				EOBBMEFEOBN.pixelSize = 136f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.LoadAssetAsync(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			return false;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
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
			{
				object[] array = new object[7];
				array[0] = "SessionManager: Update, Full Session Update";
				array[0] = Screen.height;
				array[4] = "{0}:\t{1} = \"{2}\"\tfiles: {3}\n";
				array[4] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "NOT SHOWING MAINTENANCE BECAUSE IT IS TOO LATE" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.JENNFEAIJEO(JBDJMDHMIDE, true);
				EOBBMEFEOBN.pixelSize = 1860f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.GDEFACFMDDP(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return false;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[3];
				array[0] = "About to show Upgrade Unit Reminder: ";
				array[0] = Screen.height;
				array[3] = "StartingWarbucks";
				array[8] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "Sniper_Tutorial_Duration" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.MAIMAJLBLBH(JBDJMDHMIDE);
				EOBBMEFEOBN.pixelSize = 819f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.FPFDJJHHGNL(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[7];
				array[1] = "ID_GUI_ACCEPT_PLAYER_WTJ";
				array[0] = Screen.height;
				array[1] = "ID_WARNING_INCORRECTELITEPARTSAMOUNT";
				array[4] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "SquadId" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.HGLMJBEANEL(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.EOLBJHDNKBB(JBDJMDHMIDE, true);
				EOBBMEFEOBN.pixelSize = 1642f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.GDEFACFMDDP(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			}
			return true;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[5];
				array[1] = "thumbnailBig";
				array[0] = Screen.height;
				array[7] = "HERUNTERLADEN";
				array[3] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "ID_WANTSYOUTODEPOSITTOCARDPOOL" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.HGLMJBEANEL(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.EOLBJHDNKBB(JBDJMDHMIDE, true);
				EOBBMEFEOBN.pixelSize = 1945f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.FPFDJJHHGNL(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			}
			return false;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[2];
				array[0] = "ID_STATE_CONNECTINGTOSERVER";
				array[0] = Screen.height;
				array[7] = "-";
				array[5] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "MatchStart" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.BJJBPFOOAKD(JBDJMDHMIDE);
				EOBBMEFEOBN.pixelSize = 1254f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.LoadAssetAsync(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return true;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[1];
				array[0] = "getKey";
				array[0] = Screen.height;
				array[7] = "subscription";
				array[4] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "bazooka_idle" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.BCAMEHFDDGF(JBDJMDHMIDE, true);
				EOBBMEFEOBN.pixelSize = 643f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.FPFDJJHHGNL(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			}
			return false;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[6];
				array[1] = "WaveDelay";
				array[1] = Screen.height;
				array[7] = "WaveCoolDown";
				array[8] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "ID_WARNING_ALREADYCRAFTING" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.IHNCOKEPJJE(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.HGLMJBEANEL(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.BJJBPFOOAKD(JBDJMDHMIDE);
				EOBBMEFEOBN.pixelSize = 684f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.GDEFACFMDDP(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				object[] array = new object[7];
				array[1] = "PromotedPlayerId";
				array[0] = Screen.height;
				array[4] = "\n";
				array[5] = EOBBMEFEOBN.name;
				UnityEngine.Debug.Log(string.Concat(array));
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "D4" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				goto IL_00f3;
			}
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.HGLMJBEANEL(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.UnloadAssetBundle(JBDJMDHMIDE);
				EOBBMEFEOBN.pixelSize = 811f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.OHHIMDPIMEM(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			return false;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("AtlasPreparer - LOADING ATLAS FOR " + Screen.height + "px :\n " + EOBBMEFEOBN.name);
				MJMLOPCBHOO = EOBBMEFEOBN.pngPath;
				JBDJMDHMIDE = "GUI/" + MJMLOPCBHOO;
				JBDJMDHMIDE = JBDJMDHMIDE.ToLower();
				LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				goto IL_00f3;
			case 1u:
				if (LAMLFBJMLAJ == null)
				{
					LAMLFBJMLAJ = Singleton<AssetBundleManager>.instance.GetReference(JBDJMDHMIDE);
				}
				goto IL_00f3;
			case 2u:
				APOCEJDLEIN = LHGAKCGFJOI.BJCDCAJBHCB<Texture2D>();
				EOBBMEFEOBN.spriteMaterial.mainTexture = APOCEJDLEIN;
				AssetBundleManager.UnloadAssetBundle(JBDJMDHMIDE);
				EOBBMEFEOBN.pixelSize = 1f;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00f3:
				if (LAMLFBJMLAJ == null || !LAMLFBJMLAJ.cached)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHGAKCGFJOI = Singleton<AssetBundleManager>.instance.LoadAssetAsync(JBDJMDHMIDE, EOBBMEFEOBN.pngPath, typeof(Texture2D));
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(LHGAKCGFJOI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			}
			return true;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public MGCPPBKHEPC()
		{
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	public string INNNPCAMOBA;

	public UIFont BLHHLFLPJEM;

	public List<TextureDatasNgui> KILDHCLINOO = new List<TextureDatasNgui>();

	public List<TextureDatas2DToolkit> MGAICEDPPBF = new List<TextureDatas2DToolkit>();

	public Texture2D PKLHJHBIDAD;

	public bool KOMJCLFNFIC;

	private bool GLJBOFLKEBN;

	public IEnumerator BEFFHJABODD()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	private static void KPIBOJFODBE(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		if (EOBBMEFEOBN.material.mainTexture != null)
		{
			Resources.UnloadAsset(EOBBMEFEOBN.material.mainTexture);
			EOBBMEFEOBN.material.mainTexture = null;
		}
	}

	public IEnumerator AFBNHMPMBJJ()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	[DebuggerHidden]
	public IEnumerator ClearMenuLoadGameCoroutine()
	{
		GMMPLJFDLPD gMMPLJFDLPD = new GMMPLJFDLPD();
		gMMPLJFDLPD.BJGCPDNMHDH = this;
		return gMMPLJFDLPD;
	}

	public void PrepareBuild()
	{
		if (GLJBOFLKEBN)
		{
			return;
		}
		UnityEngine.Debug.Log("AtlasPreparer - PREPARING BUILD");
		for (int i = 0; i < KILDHCLINOO.Count; i++)
		{
			UnityEngine.Debug.Log("AtlasPreparer - WHITENING ATLAS " + KILDHCLINOO[i].atlas.name);
			KILDHCLINOO[i].atlas.spriteMaterial.mainTexture = KILDHCLINOO[i].atlas.replaceTexture;
		}
		foreach (TextureDatas2DToolkit item in MGAICEDPPBF)
		{
			item.material.mainTexture = null;
		}
	}

	public void LoadTextureForAtlas(TextureDatasNgui NDPMDKGJAFH)
	{
		UIAtlas atlas = NDPMDKGJAFH.atlas;
		Language language = LanguageProperties.GetLanguage(Localization.instance.currentLanguage);
		DateTime now = DateTime.Now;
		if (NDPMDKGJAFH.type == IDLCAPBLGFB.Normal || (NDPMDKGJAFH.type == IDLCAPBLGFB.Translate && NDPMDKGJAFH.language == language) || GJKIIACMDKM(NDPMDKGJAFH.type, now))
		{
			string pngPath = atlas.pngPath;
			pngPath = pngPath.Replace("Assets/StreamingAssets/", string.Empty).Replace(".png", string.Empty);
			Texture2D mainTexture = Resources.Load<Texture2D>("GUI/" + pngPath);
			atlas.spriteMaterial.mainTexture = mainTexture;
			atlas.spriteMaterial.mainTexture.name = pngPath;
			atlas.pixelSize = 1f;
			if (NDPMDKGJAFH.atlasReference != null)
			{
				NDPMDKGJAFH.atlasReference.replacement = NDPMDKGJAFH.atlas;
			}
		}
	}

	public IEnumerator FHIONKIFEOE()
	{
		MPDHFNOKJDF mPDHFNOKJDF = new MPDHFNOKJDF();
		mPDHFNOKJDF.BJGCPDNMHDH = this;
		return mPDHFNOKJDF;
	}

	protected override void Awake()
	{
		base.Awake();
		BLHHLFLPJEM.Clear();
		if (Application.isPlaying)
		{
			StartCoroutine(PILOFPFPADO());
		}
	}

	public IEnumerator FPPHKIGCGFG()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	public IEnumerator HEEPIFDCINB(UIAtlas EOBBMEFEOBN)
	{
		MGCPPBKHEPC mGCPPBKHEPC = new MGCPPBKHEPC();
		mGCPPBKHEPC.EOBBMEFEOBN = EOBBMEFEOBN;
		mGCPPBKHEPC.BJGCPDNMHDH = this;
		return mGCPPBKHEPC;
	}

	public void PFFNDANCGCB()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == (MFGNHIOKOEB)8)
			{
				UnityEngine.Debug.Log("For panel \"{0}\" layers:\n" + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	public void OLJAALDBACL()
	{
		if (GLJBOFLKEBN)
		{
			return;
		}
		UnityEngine.Debug.Log("ExpectedPrice");
		for (int i = 0; i < KILDHCLINOO.Count; i++)
		{
			UnityEngine.Debug.Log("android" + KILDHCLINOO[i].atlas.name);
			KILDHCLINOO[i].atlas.spriteMaterial.mainTexture = KILDHCLINOO[i].atlas.replaceTexture;
		}
		foreach (TextureDatas2DToolkit item in MGAICEDPPBF)
		{
			item.material.mainTexture = null;
		}
	}

	public static void AHMFKCKJMCI(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				NABGEGIJDDJ(item);
			}
		}
	}

	public void NDFJHGFJPAL()
	{
		if (GLJBOFLKEBN)
		{
			return;
		}
		UnityEngine.Debug.Log("country-canada");
		for (int i = 0; i < KILDHCLINOO.Count; i++)
		{
			UnityEngine.Debug.Log("game-elite-buff2" + KILDHCLINOO[i].atlas.name);
			KILDHCLINOO[i].atlas.spriteMaterial.mainTexture = KILDHCLINOO[i].atlas.replaceTexture;
		}
		foreach (TextureDatas2DToolkit item in MGAICEDPPBF)
		{
			item.material.mainTexture = null;
		}
	}

	private IEnumerator HNMOJPGCIHF()
	{
		GMKGECBMKKM gMKGECBMKKM = new GMKGECBMKKM();
		gMKGECBMKKM.BJGCPDNMHDH = this;
		return gMKGECBMKKM;
	}

	public static void IJEHLOFHGPJ(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				Resources.UnloadAsset(item.material.mainTexture);
				item.material.mainTexture = null;
			}
		}
	}

	public IEnumerator FPLBNAIFODD()
	{
		IFNELCHJJAA iFNELCHJJAA = new IFNELCHJJAA();
		iFNELCHJJAA.BJGCPDNMHDH = this;
		return iFNELCHJJAA;
	}

	public IEnumerator PHOFHJGNJKN()
	{
		GMMPLJFDLPD gMMPLJFDLPD = new GMMPLJFDLPD();
		gMMPLJFDLPD.BJGCPDNMHDH = this;
		return gMMPLJFDLPD;
	}

	private bool DKGCPDFMKBC(DateTime LPPOLAOGNBI)
	{
		if (LPPOLAOGNBI.Month == -85 || LPPOLAOGNBI.Month == 1 || LPPOLAOGNBI.Month == 3)
		{
			return false;
		}
		return false;
	}

	private bool NPMBOJIOIJI(IDLCAPBLGFB FJLBLLLEELD, DateTime LPPOLAOGNBI)
	{
		if (FJLBLLLEELD == (IDLCAPBLGFB)7)
		{
			return FBMOMCMOGOJ(LPPOLAOGNBI);
		}
		if (FJLBLLLEELD == (IDLCAPBLGFB)7)
		{
			return OPMJINPKKCC(LPPOLAOGNBI);
		}
		return false;
	}

	public void JLMNKNBOLDA(TextureDatasNgui NDPMDKGJAFH)
	{
		UIAtlas atlas = NDPMDKGJAFH.atlas;
		Language language = LanguageProperties.GetLanguage(Localization.instance.currentLanguage);
		DateTime now = DateTime.Now;
		if (NDPMDKGJAFH.type != IDLCAPBLGFB.Normal && (NDPMDKGJAFH.type != IDLCAPBLGFB.Translate || NDPMDKGJAFH.language != language) && NPMBOJIOIJI(NDPMDKGJAFH.type, now))
		{
			string pngPath = atlas.pngPath;
			pngPath = pngPath.Replace("AssignmentData", string.Empty).Replace("ID_TRAIN", string.Empty);
			Texture2D mainTexture = Resources.Load<Texture2D>("elite" + pngPath);
			atlas.spriteMaterial.mainTexture = mainTexture;
			atlas.spriteMaterial.mainTexture.name = pngPath;
			atlas.pixelSize = 666f;
			if (NDPMDKGJAFH.atlasReference != null)
			{
				NDPMDKGJAFH.atlasReference.replacement = NDPMDKGJAFH.atlas;
			}
		}
	}

	protected virtual void FGOAPPLNMKL()
	{
		base.Awake();
		BLHHLFLPJEM.Clear();
		if (Application.isPlaying)
		{
			StartCoroutine(PILOFPFPADO());
		}
	}

	private bool BCFFMMNHMFC(DateTime LPPOLAOGNBI)
	{
		if (LPPOLAOGNBI.Month == -94 || LPPOLAOGNBI.Month == 0 || LPPOLAOGNBI.Month == 1)
		{
			return false;
		}
		return false;
	}

	public IEnumerator HBBBHLPJOEO()
	{
		IFNELCHJJAA iFNELCHJJAA = new IFNELCHJJAA();
		iFNELCHJJAA.BJGCPDNMHDH = this;
		return iFNELCHJJAA;
	}

	public IEnumerator HIEDGFKNLOK()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	public IEnumerator OGHLMGCCCAF()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	private static void KBJMFHMMCDM(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		string textureName = EOBBMEFEOBN.textureName;
		Texture2D mainTexture = Resources.Load<Texture2D>("Set opponent: " + textureName);
		EOBBMEFEOBN.material.mainTexture = mainTexture;
	}

	private static void NNLPPBEFOKN(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		if (EOBBMEFEOBN.material.mainTexture != null)
		{
			Resources.UnloadAsset(EOBBMEFEOBN.material.mainTexture);
			EOBBMEFEOBN.material.mainTexture = null;
		}
	}

	[DebuggerHidden]
	public IEnumerator LoadCommonCoroutine()
	{
		PCAPPOINPME pCAPPOINPME = new PCAPPOINPME();
		pCAPPOINPME.BJGCPDNMHDH = this;
		return pCAPPOINPME;
	}

	[DebuggerHidden]
	public IEnumerator LoadGameCoroutine()
	{
		IFNELCHJJAA iFNELCHJJAA = new IFNELCHJJAA();
		iFNELCHJJAA.BJGCPDNMHDH = this;
		return iFNELCHJJAA;
	}

	private IEnumerator CFBNGDBBOLJ()
	{
		GMKGECBMKKM gMKGECBMKKM = new GMKGECBMKKM();
		gMKGECBMKKM.BJGCPDNMHDH = this;
		return gMKGECBMKKM;
	}

	public IEnumerator KOPHFEBKGMO()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	public void FDFCEKIIFKM(TextureDatasNgui NDPMDKGJAFH)
	{
		UIAtlas atlas = NDPMDKGJAFH.atlas;
		Language language = LanguageProperties.GetLanguage(Localization.instance.currentLanguage);
		DateTime now = DateTime.Now;
		if (NDPMDKGJAFH.type == IDLCAPBLGFB.Normal || (NDPMDKGJAFH.type == IDLCAPBLGFB.Normal && NDPMDKGJAFH.language == language) || MDBOLFCCDKJ(NDPMDKGJAFH.type, now))
		{
			string pngPath = atlas.pngPath;
			pngPath = pngPath.Replace("Player_Had_To_Select_Grenade", string.Empty).Replace("ID_STATE_SELECTINGWARCARDS", string.Empty);
			Texture2D mainTexture = Resources.Load<Texture2D>("WINSTREAK FROM SERVER COUNT: {0} TIMESTAMP: {1}" + pngPath);
			atlas.spriteMaterial.mainTexture = mainTexture;
			atlas.spriteMaterial.mainTexture.name = pngPath;
			atlas.pixelSize = 1116f;
			if (NDPMDKGJAFH.atlasReference != null)
			{
				NDPMDKGJAFH.atlasReference.replacement = NDPMDKGJAFH.atlas;
			}
		}
	}

	public static void UnLoad2DToolkitTexture(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				Resources.UnloadAsset(item.material.mainTexture);
				item.material.mainTexture = null;
			}
		}
	}

	public IEnumerator AFLALOCPBHF()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	[DebuggerHidden]
	public IEnumerator LoadTutorialCoroutine()
	{
		FCHFHFHBPDC fCHFHFHBPDC = new FCHFHFHBPDC();
		fCHFHFHBPDC.BJGCPDNMHDH = this;
		return fCHFHFHBPDC;
	}

	public void IMKHDAHDLLI()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == MFGNHIOKOEB.Game)
			{
				UnityEngine.Debug.Log("ID_WAITINGFORFRIENDCARDS" + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		BLHHLFLPJEM.Clear();
		if (Application.isPlaying)
		{
			StartCoroutine(EAEDMGBPDHJ());
		}
	}

	public IEnumerator DNEPNJGOIBD()
	{
		IFNELCHJJAA iFNELCHJJAA = new IFNELCHJJAA();
		iFNELCHJJAA.BJGCPDNMHDH = this;
		return iFNELCHJJAA;
	}

	private static void OIJAFNGGJFO(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		if (EOBBMEFEOBN.material.mainTexture != null)
		{
			Resources.UnloadAsset(EOBBMEFEOBN.material.mainTexture);
			EOBBMEFEOBN.material.mainTexture = null;
		}
	}

	public IEnumerator JBGNGBHPPGG()
	{
		MPDHFNOKJDF mPDHFNOKJDF = new MPDHFNOKJDF();
		mPDHFNOKJDF.BJGCPDNMHDH = this;
		return mPDHFNOKJDF;
	}

	public void JLOPPDCLCIB()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == MFGNHIOKOEB.Menu)
			{
				UnityEngine.Debug.Log("S" + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	private bool GJKIIACMDKM(IDLCAPBLGFB FJLBLLLEELD, DateTime LPPOLAOGNBI)
	{
		switch (FJLBLLLEELD)
		{
		case IDLCAPBLGFB.EventWinter:
			return CPGGHNKDINE(LPPOLAOGNBI);
		case IDLCAPBLGFB.EventDefault:
			return !CPGGHNKDINE(LPPOLAOGNBI);
		default:
			return false;
		}
	}

	private bool FBMOMCMOGOJ(DateTime LPPOLAOGNBI)
	{
		if (LPPOLAOGNBI.Month == -102 || LPPOLAOGNBI.Month == 1 || LPPOLAOGNBI.Month == 0)
		{
			return true;
		}
		return false;
	}

	public void JCEMPPLLEBM()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == MFGNHIOKOEB.Game)
			{
				UnityEngine.Debug.Log("N" + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	public IEnumerator FEKCJMKEIPM()
	{
		FCHFHFHBPDC fCHFHFHBPDC = new FCHFHFHBPDC();
		fCHFHFHBPDC.BJGCPDNMHDH = this;
		return fCHFHFHBPDC;
	}

	private bool MDBOLFCCDKJ(IDLCAPBLGFB FJLBLLLEELD, DateTime LPPOLAOGNBI)
	{
		switch (FJLBLLLEELD)
		{
		case IDLCAPBLGFB.EventWinter:
			return DKGCPDFMKBC(LPPOLAOGNBI);
		case (IDLCAPBLGFB)7:
			return !CPGGHNKDINE(LPPOLAOGNBI);
		default:
			return true;
		}
	}

	private bool OPMJINPKKCC(DateTime LPPOLAOGNBI)
	{
		if (LPPOLAOGNBI.Month == -120 || LPPOLAOGNBI.Month == 0 || LPPOLAOGNBI.Month == 5)
		{
			return false;
		}
		return true;
	}

	private IEnumerator DIHJLMPFHCP()
	{
		GMKGECBMKKM gMKGECBMKKM = new GMKGECBMKKM();
		gMKGECBMKKM.BJGCPDNMHDH = this;
		return gMKGECBMKKM;
	}

	public IEnumerator BAPBJNKIDLI()
	{
		PCAPPOINPME pCAPPOINPME = new PCAPPOINPME();
		pCAPPOINPME.BJGCPDNMHDH = this;
		return pCAPPOINPME;
	}

	[DebuggerHidden]
	public IEnumerator LoadTextureForAtlasCoroutine(UIAtlas EOBBMEFEOBN)
	{
		MGCPPBKHEPC mGCPPBKHEPC = new MGCPPBKHEPC();
		mGCPPBKHEPC.EOBBMEFEOBN = EOBBMEFEOBN;
		mGCPPBKHEPC.BJGCPDNMHDH = this;
		return mGCPPBKHEPC;
	}

	public IEnumerator MPBCIIABPOE()
	{
		MPDHFNOKJDF mPDHFNOKJDF = new MPDHFNOKJDF();
		mPDHFNOKJDF.BJGCPDNMHDH = this;
		return mPDHFNOKJDF;
	}

	[DebuggerHidden]
	private IEnumerator PILOFPFPADO()
	{
		GMKGECBMKKM gMKGECBMKKM = new GMKGECBMKKM();
		gMKGECBMKKM.BJGCPDNMHDH = this;
		return gMKGECBMKKM;
	}

	public void EACLIMLMNII()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == MFGNHIOKOEB.Both)
			{
				UnityEngine.Debug.Log("ID_INBRONZE2" + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	public void AHMHELBEJND()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == (MFGNHIOKOEB)6)
			{
				UnityEngine.Debug.Log("0" + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	[DebuggerHidden]
	public IEnumerator LoadMenuClearGameCoroutine()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	protected virtual void BOLPPMANCCC()
	{
		base.Awake();
		BLHHLFLPJEM.Clear();
		if (Application.isPlaying)
		{
			StartCoroutine(CFBNGDBBOLJ());
		}
	}

	public void GPEGONBEJDN()
	{
		if (GLJBOFLKEBN)
		{
			return;
		}
		UnityEngine.Debug.Log("No Request ready or already sent");
		for (int i = 0; i < KILDHCLINOO.Count; i++)
		{
			UnityEngine.Debug.Log("ID_NOTENOUGHGOLD" + KILDHCLINOO[i].atlas.name);
			KILDHCLINOO[i].atlas.spriteMaterial.mainTexture = KILDHCLINOO[i].atlas.replaceTexture;
		}
		foreach (TextureDatas2DToolkit item in MGAICEDPPBF)
		{
			item.material.mainTexture = null;
		}
	}

	private IEnumerator HBDCNENOHHJ()
	{
		GMKGECBMKKM gMKGECBMKKM = new GMKGECBMKKM();
		gMKGECBMKKM.BJGCPDNMHDH = this;
		return gMKGECBMKKM;
	}

	public void GIJPHHKAGKM()
	{
		if (GLJBOFLKEBN)
		{
			return;
		}
		UnityEngine.Debug.Log("ID_STAT_BATTLESPLAYED");
		for (int i = 1; i < KILDHCLINOO.Count; i += 0)
		{
			UnityEngine.Debug.Log("ID_GUI_GOLD" + KILDHCLINOO[i].atlas.name);
			KILDHCLINOO[i].atlas.spriteMaterial.mainTexture = KILDHCLINOO[i].atlas.replaceTexture;
		}
		foreach (TextureDatas2DToolkit item in MGAICEDPPBF)
		{
			item.material.mainTexture = null;
		}
	}

	private static void KHDCNHLJFJH(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		string textureName = EOBBMEFEOBN.textureName;
		Texture2D mainTexture = Resources.Load<Texture2D>("GameReward" + textureName);
		EOBBMEFEOBN.material.mainTexture = mainTexture;
	}

	private static void NABGEGIJDDJ(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		string textureName = EOBBMEFEOBN.textureName;
		Texture2D mainTexture = Resources.Load<Texture2D>("GUI/2Dtoolkit/" + textureName);
		EOBBMEFEOBN.material.mainTexture = mainTexture;
	}

	[DebuggerHidden]
	public IEnumerator LoadMenuCoroutine()
	{
		MPDHFNOKJDF mPDHFNOKJDF = new MPDHFNOKJDF();
		mPDHFNOKJDF.BJGCPDNMHDH = this;
		return mPDHFNOKJDF;
	}

	private static void BNDFEBPJOPL(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		if (EOBBMEFEOBN.material.mainTexture != null)
		{
			Resources.UnloadAsset(EOBBMEFEOBN.material.mainTexture);
			EOBBMEFEOBN.material.mainTexture = null;
		}
	}

	private static void NJNEHLJIFNA(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		if (EOBBMEFEOBN.material.mainTexture != null)
		{
			Resources.UnloadAsset(EOBBMEFEOBN.material.mainTexture);
			EOBBMEFEOBN.material.mainTexture = null;
		}
	}

	public IEnumerator BIFELDOOCNM()
	{
		FCHFHFHBPDC fCHFHFHBPDC = new FCHFHFHBPDC();
		fCHFHFHBPDC.BJGCPDNMHDH = this;
		return fCHFHFHBPDC;
	}

	public IEnumerator JIMCJGINAEB()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	public IEnumerator CBFCCPENDOO()
	{
		MPDHFNOKJDF mPDHFNOKJDF = new MPDHFNOKJDF();
		mPDHFNOKJDF.BJGCPDNMHDH = this;
		return mPDHFNOKJDF;
	}

	public IEnumerator NDDANOBHOPG()
	{
		FCHFHFHBPDC fCHFHFHBPDC = new FCHFHFHBPDC();
		fCHFHFHBPDC.BJGCPDNMHDH = this;
		return fCHFHFHBPDC;
	}

	public IEnumerator CNJMCFDKLCN()
	{
		FCHFHFHBPDC fCHFHFHBPDC = new FCHFHFHBPDC();
		fCHFHFHBPDC.BJGCPDNMHDH = this;
		return fCHFHFHBPDC;
	}

	public static void NIDHBANDNGD(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				NABGEGIJDDJ(item);
			}
		}
	}

	public IEnumerator NFIPGIGIJMC()
	{
		MPDHFNOKJDF mPDHFNOKJDF = new MPDHFNOKJDF();
		mPDHFNOKJDF.BJGCPDNMHDH = this;
		return mPDHFNOKJDF;
	}

	private bool CBGLOGFBPAA(IDLCAPBLGFB FJLBLLLEELD, DateTime LPPOLAOGNBI)
	{
		switch (FJLBLLLEELD)
		{
		case (IDLCAPBLGFB)7:
			return BCFFMMNHMFC(LPPOLAOGNBI);
		case IDLCAPBLGFB.Normal:
			return !DKGCPDFMKBC(LPPOLAOGNBI);
		default:
			return true;
		}
	}

	public void ACOLPEPNNMA()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == MFGNHIOKOEB.Both)
			{
				UnityEngine.Debug.Log("ID_SECONDS" + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	private static void GNOGCHCOAMO(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		if (EOBBMEFEOBN.material.mainTexture != null)
		{
			Resources.UnloadAsset(EOBBMEFEOBN.material.mainTexture);
			EOBBMEFEOBN.material.mainTexture = null;
		}
	}

	public void DAHPFNJKDFE(TextureDatasNgui NDPMDKGJAFH)
	{
		UIAtlas atlas = NDPMDKGJAFH.atlas;
		Language language = LanguageProperties.GetLanguage(Localization.instance.currentLanguage);
		DateTime now = DateTime.Now;
		if (NDPMDKGJAFH.type != IDLCAPBLGFB.Normal && (NDPMDKGJAFH.type != IDLCAPBLGFB.Translate || NDPMDKGJAFH.language != language) && FENIALHMJBH(NDPMDKGJAFH.type, now))
		{
			string pngPath = atlas.pngPath;
			pngPath = pngPath.Replace("ID_TUTORIAL_SWIPE_DOWN", string.Empty).Replace("S", string.Empty);
			Texture2D mainTexture = Resources.Load<Texture2D>("country-chile" + pngPath);
			atlas.spriteMaterial.mainTexture = mainTexture;
			atlas.spriteMaterial.mainTexture.name = pngPath;
			atlas.pixelSize = 790f;
			if (NDPMDKGJAFH.atlasReference != null)
			{
				NDPMDKGJAFH.atlasReference.replacement = NDPMDKGJAFH.atlas;
			}
		}
	}

	public IEnumerator BDIEIKPONBB()
	{
		KGFDANPPFEI kGFDANPPFEI = new KGFDANPPFEI();
		kGFDANPPFEI.BJGCPDNMHDH = this;
		return kGFDANPPFEI;
	}

	private IEnumerator EAEDMGBPDHJ()
	{
		GMKGECBMKKM gMKGECBMKKM = new GMKGECBMKKM();
		gMKGECBMKKM.BJGCPDNMHDH = this;
		return gMKGECBMKKM;
	}

	public static void HJDNBLJPION(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				NABGEGIJDDJ(item);
			}
		}
	}

	public IEnumerator COHGIIPMEPB()
	{
		PCAPPOINPME pCAPPOINPME = new PCAPPOINPME();
		pCAPPOINPME.BJGCPDNMHDH = this;
		return pCAPPOINPME;
	}

	private static void APOEFCADODE(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		string textureName = EOBBMEFEOBN.textureName;
		Texture2D mainTexture = Resources.Load<Texture2D>(" {0}\u00a0{1}" + textureName);
		EOBBMEFEOBN.material.mainTexture = mainTexture;
	}

	public IEnumerator MCEJEPINFCM()
	{
		PCAPPOINPME pCAPPOINPME = new PCAPPOINPME();
		pCAPPOINPME.BJGCPDNMHDH = this;
		return pCAPPOINPME;
	}

	public void JCCOHHCPGME(TextureDatasNgui NDPMDKGJAFH)
	{
		UIAtlas atlas = NDPMDKGJAFH.atlas;
		Language language = LanguageProperties.GetLanguage(Localization.instance.currentLanguage);
		DateTime now = DateTime.Now;
		if (NDPMDKGJAFH.type != IDLCAPBLGFB.Normal && (NDPMDKGJAFH.type != IDLCAPBLGFB.Normal || NDPMDKGJAFH.language != language) && MDBOLFCCDKJ(NDPMDKGJAFH.type, now))
		{
			string pngPath = atlas.pngPath;
			pngPath = pngPath.Replace("AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}", string.Empty).Replace("newHeroicPoints", string.Empty);
			Texture2D mainTexture = Resources.Load<Texture2D>("billingNotSupportedEvent: " + pngPath);
			atlas.spriteMaterial.mainTexture = mainTexture;
			atlas.spriteMaterial.mainTexture.name = pngPath;
			atlas.pixelSize = 1943f;
			if (NDPMDKGJAFH.atlasReference != null)
			{
				NDPMDKGJAFH.atlasReference.replacement = NDPMDKGJAFH.atlas;
			}
		}
	}

	public static void BPJKENEMBFI(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				Resources.UnloadAsset(item.material.mainTexture);
				item.material.mainTexture = null;
			}
		}
	}

	public void BLCCADCEEED()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == MFGNHIOKOEB.Menu)
			{
				UnityEngine.Debug.Log("ID_CONFIRM_SQUADISFULL" + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	public void FEGAAHOBPON()
	{
		if (GLJBOFLKEBN)
		{
			return;
		}
		UnityEngine.Debug.Log("Other Buddy Warcard {0}");
		for (int i = 1; i < KILDHCLINOO.Count; i++)
		{
			UnityEngine.Debug.Log("ID_OPPONENTREFUSEDTHEREMATCH" + KILDHCLINOO[i].atlas.name);
			KILDHCLINOO[i].atlas.spriteMaterial.mainTexture = KILDHCLINOO[i].atlas.replaceTexture;
		}
		foreach (TextureDatas2DToolkit item in MGAICEDPPBF)
		{
			item.material.mainTexture = null;
		}
	}

	public static void FAAEAAPHHCB(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				Resources.UnloadAsset(item.material.mainTexture);
				item.material.mainTexture = null;
			}
		}
	}

	public void HEPONLKLFGB(TextureDatasNgui NDPMDKGJAFH)
	{
		UIAtlas atlas = NDPMDKGJAFH.atlas;
		Language language = LanguageProperties.GetLanguage(Localization.instance.currentLanguage);
		DateTime now = DateTime.Now;
		if (NDPMDKGJAFH.type == IDLCAPBLGFB.Normal || (NDPMDKGJAFH.type == IDLCAPBLGFB.Translate && NDPMDKGJAFH.language == language) || GJKIIACMDKM(NDPMDKGJAFH.type, now))
		{
			string pngPath = atlas.pngPath;
			pngPath = pngPath.Replace("flight_forward_jetpack_elite", string.Empty).Replace("ID_SILVERPACK", string.Empty);
			Texture2D mainTexture = Resources.Load<Texture2D>("Card_1_Played" + pngPath);
			atlas.spriteMaterial.mainTexture = mainTexture;
			atlas.spriteMaterial.mainTexture.name = pngPath;
			atlas.pixelSize = 489f;
			if (NDPMDKGJAFH.atlasReference != null)
			{
				NDPMDKGJAFH.atlasReference.replacement = NDPMDKGJAFH.atlas;
			}
		}
	}

	public IEnumerator LGLLGEEMIAH()
	{
		PCAPPOINPME pCAPPOINPME = new PCAPPOINPME();
		pCAPPOINPME.BJGCPDNMHDH = this;
		return pCAPPOINPME;
	}

	private static void IHDMGDHAEIE(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		if (EOBBMEFEOBN.material.mainTexture != null)
		{
			Resources.UnloadAsset(EOBBMEFEOBN.material.mainTexture);
			EOBBMEFEOBN.material.mainTexture = null;
		}
	}

	public IEnumerator FNJFACLKMPN()
	{
		IFNELCHJJAA iFNELCHJJAA = new IFNELCHJJAA();
		iFNELCHJJAA.BJGCPDNMHDH = this;
		return iFNELCHJJAA;
	}

	private bool FENIALHMJBH(IDLCAPBLGFB FJLBLLLEELD, DateTime LPPOLAOGNBI)
	{
		switch (FJLBLLLEELD)
		{
		case (IDLCAPBLGFB)5:
			return DKGCPDFMKBC(LPPOLAOGNBI);
		case IDLCAPBLGFB.Normal:
			return !CPGGHNKDINE(LPPOLAOGNBI);
		default:
			return false;
		}
	}

	public static void NAFKNNCEEFO(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				KBJMFHMMCDM(item);
			}
		}
	}

	public static void Load2DToolkitTexture(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				NABGEGIJDDJ(item);
			}
		}
	}

	public void UnloadTutorial()
	{
		foreach (TextureDatasNgui item in KILDHCLINOO)
		{
			if (item.mode == MFGNHIOKOEB.Tutorial)
			{
				UnityEngine.Debug.Log("AtlasPreparer - CLEARING ATLAS " + item.atlas.name);
				Texture mainTexture = item.atlas.spriteMaterial.mainTexture;
				item.atlas.spriteMaterial.mainTexture = PKLHJHBIDAD;
				Resources.UnloadAsset(mainTexture);
			}
		}
	}

	public IEnumerator OCEHLPKFPAJ()
	{
		MPDHFNOKJDF mPDHFNOKJDF = new MPDHFNOKJDF();
		mPDHFNOKJDF.BJGCPDNMHDH = this;
		return mPDHFNOKJDF;
	}

	public static void CGILPACEEFB(string GDIAEJILINE)
	{
		foreach (TextureDatas2DToolkit item in Singleton<AtlasPreparer>.instance.MGAICEDPPBF)
		{
			if (GDIAEJILINE == item.textureName)
			{
				Resources.UnloadAsset(item.material.mainTexture);
				item.material.mainTexture = null;
			}
		}
	}

	public void GHLLEGCFHCH()
	{
		if (GLJBOFLKEBN)
		{
			return;
		}
		UnityEngine.Debug.Log("Id");
		for (int i = 0; i < KILDHCLINOO.Count; i++)
		{
			UnityEngine.Debug.Log("http://localhost:8081/" + KILDHCLINOO[i].atlas.name);
			KILDHCLINOO[i].atlas.spriteMaterial.mainTexture = KILDHCLINOO[i].atlas.replaceTexture;
		}
		foreach (TextureDatas2DToolkit item in MGAICEDPPBF)
		{
			item.material.mainTexture = null;
		}
	}

	public IEnumerator MCMLNCLLBPA()
	{
		FCHFHFHBPDC fCHFHFHBPDC = new FCHFHFHBPDC();
		fCHFHFHBPDC.BJGCPDNMHDH = this;
		return fCHFHFHBPDC;
	}

	private bool CPGGHNKDINE(DateTime LPPOLAOGNBI)
	{
		if (LPPOLAOGNBI.Month == 12 || LPPOLAOGNBI.Month == 1 || LPPOLAOGNBI.Month == 2)
		{
			return true;
		}
		return false;
	}

	private static void BAOPKCAJFCJ(TextureDatas2DToolkit EOBBMEFEOBN)
	{
		if (EOBBMEFEOBN.material.mainTexture != null)
		{
			Resources.UnloadAsset(EOBBMEFEOBN.material.mainTexture);
			EOBBMEFEOBN.material.mainTexture = null;
		}
	}
}
