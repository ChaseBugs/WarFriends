using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerVisualCategoryCamos : PlayerVisualCategoryGeneric<PlayerVisualCategoryCamos.PlayerVisualCamo>
{
	[Serializable]
	public class PlayerVisualCamo : PlayerVisual
	{
		[SerializeField]
		private string modelPath;

		[SerializeField]
		private string previewModelPath;

		[SerializeField]
		private string camoTexturePath;

		[SerializeField]
		private string camoTextureSmallPath;

		private SkinnedMeshRenderer mMeshBody;

		private SkinnedMeshRenderer mPreviewMeshBody;

		private Texture2D mCamoTexture;

		private Texture2D mCamoTextureSmall;

		private List<MeshFilter> hairMeshes;

		public virtual void ODJIHKNEALO()
		{
			base.EFFFMHGIPGJ();
		}

		public Texture2D KLICALBHCAG()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		[CompilerGenerated]
		private static int PADJMNFBNKJ(MeshFilter JDEMAFGJGLD, MeshFilter NOJFJANOHEB)
		{
			return JDEMAFGJGLD.name.CompareTo(NOJFJANOHEB.name);
		}

		public SkinnedMeshRenderer OHJAFBCAPDB()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 0)
					{
						mMeshBody = componentsInChildren[0];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("ID_EXPIRED", modelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("ID_ARENARULES_NO", modelPath));
				}
				PCHCHFKDAPG(gameObject);
			}
			return mMeshBody;
		}

		public virtual void ALGBMPAMCGN()
		{
			base.EMLFJBOLENO();
			BEGPEOCKPPK();
			KLICALBHCAG();
		}

		private void DIEIKKPFMGL()
		{
			Resources.UnloadAsset(mCamoTexture);
		}

		public virtual void DCBBBJEHPHJ()
		{
			base.MBHMIBGFPEG();
			mMeshBody = null;
			mPreviewMeshBody = null;
			mCamoTextureSmall = null;
			mCamoTexture = null;
			hairMeshes = null;
		}

		public Mesh ECENCKKCOMD(int DFHAAIFFLOE)
		{
			if (hairMeshes != null && DFHAAIFFLOE < hairMeshes.Count)
			{
				return hairMeshes[DFHAAIFFLOE].sharedMesh;
			}
			return null;
		}

		private void HKKKDJFMJON()
		{
			Resources.UnloadAsset(mCamoTexture);
		}

		private void NJLDNIBIAPH()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		public SkinnedMeshRenderer JGLGCBIJFNL()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 1)
					{
						mMeshBody = componentsInChildren[0];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError($"PlayerVisualCamo Error - SkinnedMeshRenderer count is 0 at {modelPath}!");
					}
				}
				else
				{
					Debug.LogError($"Camo load error: {modelPath}");
				}
				FFDOGJEAPFA(gameObject);
			}
			return mMeshBody;
		}

		public Texture2D JAKDPHGMKBA()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		public virtual void LAOELJCICBN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			base.HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.FFDFHLOMECD((!OGKCIFGLKJJ) ? ALNNPOOLKDE() : FOCKMHBNHLP(), (!OGKCIFGLKJJ) ? PJMMBOKBKMA() : GJKKDBGJFGJ());
			if (Application.isPlaying)
			{
				if (DGJFKDADPHE.equippedCamo != null && DGJFKDADPHE.equippedCamo != this && OGKCIFGLKJJ)
				{
					DGJFKDADPHE.equippedCamo.JCAICDEOKAK();
					DGJFKDADPHE.equippedCamo.PGDPDMECOFD();
				}
				DGJFKDADPHE.equippedCamo = this;
				if (DGJFKDADPHE.equippedHelmet != null)
				{
					DGJFKDADPHE.equippedHelmet.MNEEDLCGAFN(DGJFKDADPHE);
				}
				if (DGJFKDADPHE.equippedHeadAccesory != null)
				{
					DGJFKDADPHE.equippedHeadAccesory.HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ: true);
				}
				if (DGJFKDADPHE.equippedPowerBand != null)
				{
					DGJFKDADPHE.equippedPowerBand.MNEEDLCGAFN(DGJFKDADPHE);
				}
			}
		}

		private void BDHACFFHHGN()
		{
			Resources.UnloadAsset(mCamoTexture);
		}

		public SkinnedMeshRenderer EEPAACGMAGL()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
					if (componentsInChildren.Length == 0)
					{
						mMeshBody = componentsInChildren[1];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("AdFailedToDisplay()", modelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("shield_idle", modelPath));
				}
				LOLKCEHHJAF(gameObject);
			}
			return mMeshBody;
		}

		private void AGFJKMCBKAM(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				if (meshFilter.name.Contains("country-ukraine"))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort(GNNJPPNMCLE);
		}

		public virtual void JEEMLFNAMME()
		{
			base.MBHMIBGFPEG();
			mMeshBody = null;
			mPreviewMeshBody = null;
			mCamoTextureSmall = null;
			mCamoTexture = null;
			hairMeshes = null;
		}

		public SkinnedMeshRenderer FOCKMHBNHLP()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
					if (componentsInChildren.Length == 1)
					{
						mMeshBody = componentsInChildren[1];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format(")", modelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format(" is not present in resources using default", modelPath));
				}
				LJKHKCDJEGH(gameObject);
			}
			return mMeshBody;
		}

		public SkinnedMeshRenderer DKIIMJDCNMG()
		{
			if (mPreviewMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(previewModelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
					if (componentsInChildren.Length == 1)
					{
						mPreviewMeshBody = componentsInChildren[0];
						mPreviewMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("MaxTiers", previewModelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("Name", previewModelPath));
				}
				FFDOGJEAPFA(gameObject);
			}
			return mPreviewMeshBody;
		}

		public virtual void NPIHLNHHFNO()
		{
			base.GGEBGAOFIIK();
			KALGOJEFLFM();
			HBECMMCCPOP();
		}

		private void PCHCHFKDAPG(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshFilter meshFilter = array[i];
				if (meshFilter.name.Contains("}"))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort(PELDIHELDMJ);
		}

		public SkinnedMeshRenderer JACFHMKCNJH()
		{
			if (mPreviewMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(previewModelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 1)
					{
						mPreviewMeshBody = componentsInChildren[1];
						mPreviewMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("Xp", previewModelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("SquadId", previewModelPath));
				}
				IJLOJGLHCOF(gameObject);
			}
			return mPreviewMeshBody;
		}

		public Mesh CELDDAMFEKK(int DFHAAIFFLOE)
		{
			if (hairMeshes != null && DFHAAIFFLOE < hairMeshes.Count)
			{
				return hairMeshes[DFHAAIFFLOE].sharedMesh;
			}
			return null;
		}

		public Texture2D CPEBPDBCKPK()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		public Mesh FOKOBFJBCAI(int DFHAAIFFLOE)
		{
			if (hairMeshes != null && DFHAAIFFLOE < hairMeshes.Count)
			{
				return hairMeshes[DFHAAIFFLOE].sharedMesh;
			}
			return null;
		}

		public Texture2D DDCELCLMKPG()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		public virtual void EFDAELJOFNF()
		{
			base.GGEBGAOFIIK();
			BEGPEOCKPPK();
			CHCIMNBKLJF();
		}

		public virtual void NDLOKBMNIPP()
		{
			base.CMMFDHDNOEO();
		}

		private void GGPBOBNMNAB()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		public Texture2D GMKDDHFHCOO()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		public Texture2D JNDIGIMAEKI()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		public override void EMLFJBOLENO()
		{
			base.EMLFJBOLENO();
			PMJEBJCPKJA();
			KGFKKJCJCON();
		}

		public override void MNEEDLCGAFN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.ChangeCamo((!OGKCIFGLKJJ) ? PMJEBJCPKJA() : JGLGCBIJFNL(), (!OGKCIFGLKJJ) ? KGFKKJCJCON() : MPBHLODJAFI());
			if (Application.isPlaying)
			{
				if (DGJFKDADPHE.equippedCamo != null && DGJFKDADPHE.equippedCamo != this && OGKCIFGLKJJ)
				{
					DGJFKDADPHE.equippedCamo.HOHDNHNHDKI();
					DGJFKDADPHE.equippedCamo.GGPBOBNMNAB();
				}
				DGJFKDADPHE.equippedCamo = this;
				if (DGJFKDADPHE.equippedHelmet != null)
				{
					DGJFKDADPHE.equippedHelmet.MNEEDLCGAFN(DGJFKDADPHE);
				}
				if (DGJFKDADPHE.equippedHeadAccesory != null)
				{
					DGJFKDADPHE.equippedHeadAccesory.MNEEDLCGAFN(DGJFKDADPHE);
				}
				if (DGJFKDADPHE.equippedPowerBand != null)
				{
					DGJFKDADPHE.equippedPowerBand.MNEEDLCGAFN(DGJFKDADPHE);
				}
			}
		}

		public virtual void MAFDFANNEAC()
		{
			base.MBHMIBGFPEG();
			mMeshBody = null;
			mPreviewMeshBody = null;
			mCamoTextureSmall = null;
			mCamoTexture = null;
			hairMeshes = null;
		}

		public Texture2D MBCJOELAADN()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		public Texture2D DAPPAKHOFHN()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		public Texture2D MPBHLODJAFI()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		private void AHDONHFDHHJ()
		{
			Resources.UnloadAsset(mCamoTexture);
		}

		public SkinnedMeshRenderer MKFHAHJJPHH()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 1)
					{
						mMeshBody = componentsInChildren[0];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("menu-button-small-white", modelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("ID_TUTORIAL_TAPON", modelPath));
				}
				GNEBLCGALCI(gameObject);
			}
			return mMeshBody;
		}

		private void KLBBNKAOHNM()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		public Texture2D FDPACBDLLPF()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		public Mesh GOAPCJMACAB(int DFHAAIFFLOE)
		{
			if (hairMeshes != null && DFHAAIFFLOE < hairMeshes.Count)
			{
				return hairMeshes[DFHAAIFFLOE].sharedMesh;
			}
			return null;
		}

		private void PGDPDMECOFD()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		private void LOLKCEHHJAF(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: false);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				if (meshFilter.name.Contains(" {0}/{1} "))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort(PELDIHELDMJ);
		}

		public Texture2D JBHPPPFPPNE()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		public Texture2D CHCIMNBKLJF()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		public Mesh KACGJBNNBPG(int DFHAAIFFLOE)
		{
			if (hairMeshes != null && DFHAAIFFLOE < hairMeshes.Count)
			{
				return hairMeshes[DFHAAIFFLOE].sharedMesh;
			}
			return null;
		}

		public virtual void PKJIPOABBFF()
		{
			base.JDLGJNAIFMM();
		}

		public virtual void MOGKEFJMCOO()
		{
			base.GGEBGAOFIIK();
			BEGPEOCKPPK();
			DAPPAKHOFHN();
		}

		public Texture2D GJKKDBGJFGJ()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		public virtual void MGMOJOBEJHP()
		{
			base.GGEBGAOFIIK();
			JACFHMKCNJH();
			JNDIGIMAEKI();
		}

		public virtual void INIMIAEBFIE()
		{
			base.GGEBGAOFIIK();
			JACFHMKCNJH();
			JAKDPHGMKBA();
		}

		public Texture2D CJDDNIMOCMA()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		public SkinnedMeshRenderer PMJEBJCPKJA()
		{
			if (mPreviewMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(previewModelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 1)
					{
						mPreviewMeshBody = componentsInChildren[0];
						mPreviewMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError($"PlayerVisualCamo Error - SkinnedMeshRenderer count is 0 at {previewModelPath}!");
					}
				}
				else
				{
					Debug.LogError($"Camo load error: {previewModelPath}");
				}
				FFDOGJEAPFA(gameObject);
			}
			return mPreviewMeshBody;
		}

		private void EJMFOKBKPLB()
		{
			Resources.UnloadAsset(mCamoTexture);
		}

		public virtual void FOFGNODACOO()
		{
			base.MBHMIBGFPEG();
			mMeshBody = null;
			mPreviewMeshBody = null;
			mCamoTextureSmall = null;
			mCamoTexture = null;
			hairMeshes = null;
		}

		public virtual void PGFMAOCAAON()
		{
			base.CMMFDHDNOEO();
		}

		public virtual void ABKPCPCCCPD(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.LDFCPCBPLJF((!OGKCIFGLKJJ) ? ALNNPOOLKDE() : FHJDNHKKIAH(), (!OGKCIFGLKJJ) ? KGFKKJCJCON() : CJDDNIMOCMA());
			if (Application.isPlaying)
			{
				if (DGJFKDADPHE.equippedCamo != null && DGJFKDADPHE.equippedCamo != this && OGKCIFGLKJJ)
				{
					DGJFKDADPHE.equippedCamo.MNGLHAKCACD();
					DGJFKDADPHE.equippedCamo.BLBLIJKAGEI();
				}
				DGJFKDADPHE.equippedCamo = this;
				if (DGJFKDADPHE.equippedHelmet != null)
				{
					DGJFKDADPHE.equippedHelmet.MNEEDLCGAFN(DGJFKDADPHE);
				}
				if (DGJFKDADPHE.equippedHeadAccesory != null)
				{
					DGJFKDADPHE.equippedHeadAccesory.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ: true);
				}
				if (DGJFKDADPHE.equippedPowerBand != null)
				{
					DGJFKDADPHE.equippedPowerBand.HGGLCMFPPIB(DGJFKDADPHE);
				}
			}
		}

		private void BLBLIJKAGEI()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		public SkinnedMeshRenderer BEGPEOCKPPK()
		{
			if (mPreviewMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(previewModelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
					if (componentsInChildren.Length == 1)
					{
						mPreviewMeshBody = componentsInChildren[1];
						mPreviewMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("smallThumbnailBig", previewModelPath));
					}
				}
				else
				{
					Debug.LogError($"Squad icon: {previewModelPath} already displayed");
				}
				LOLKCEHHJAF(gameObject);
			}
			return mPreviewMeshBody;
		}

		public virtual void BCAMNCDBFKJ()
		{
			base.MKKOFGFOFEE();
			mMeshBody = null;
			mPreviewMeshBody = null;
			mCamoTextureSmall = null;
			mCamoTexture = null;
			hairMeshes = null;
		}

		public virtual void LMEHJIPLIEE()
		{
			base.EFFFMHGIPGJ();
		}

		public virtual void LPDCJCHGBAG()
		{
			base.GGEBGAOFIIK();
			ALNNPOOLKDE();
			JAKDPHGMKBA();
		}

		public SkinnedMeshRenderer BIIAPLBEIKA()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
					if (componentsInChildren.Length == 1)
					{
						mMeshBody = componentsInChildren[1];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("PlayerId", modelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("Xp", modelPath));
				}
				AGFJKMCBKAM(gameObject);
			}
			return mMeshBody;
		}

		public Texture2D IIGMLHEHMBD()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		private void FGKLKMJPPKC(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: false);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshFilter meshFilter = array[i];
				if (meshFilter.name.Contains("Some error occurred. Please, try again later."))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort(GNNJPPNMCLE);
		}

		private void MNGLHAKCACD()
		{
			Resources.UnloadAsset(mCamoTexture);
		}

		public virtual void KGACOPBGFOA(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.FFDFHLOMECD((!OGKCIFGLKJJ) ? DKIIMJDCNMG() : GBOFHMKJFEG(), (!OGKCIFGLKJJ) ? HBECMMCCPOP() : DDCELCLMKPG());
			if (Application.isPlaying)
			{
				if (DGJFKDADPHE.equippedCamo != null && DGJFKDADPHE.equippedCamo != this && OGKCIFGLKJJ)
				{
					DGJFKDADPHE.equippedCamo.EJMFOKBKPLB();
					DGJFKDADPHE.equippedCamo.NPHDFMPAAFP();
				}
				DGJFKDADPHE.equippedCamo = this;
				if (DGJFKDADPHE.equippedHelmet != null)
				{
					DGJFKDADPHE.equippedHelmet.MNEEDLCGAFN(DGJFKDADPHE);
				}
				if (DGJFKDADPHE.equippedHeadAccesory != null)
				{
					DGJFKDADPHE.equippedHeadAccesory.HGGLCMFPPIB(DGJFKDADPHE);
				}
				if (DGJFKDADPHE.equippedPowerBand != null)
				{
					DGJFKDADPHE.equippedPowerBand.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ: true);
				}
			}
		}

		private void NPHDFMPAAFP()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		public virtual void JDCPEMMKMJA(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.FFDFHLOMECD((!OGKCIFGLKJJ) ? JACFHMKCNJH() : MKFHAHJJPHH(), (!OGKCIFGLKJJ) ? KLICALBHCAG() : IIGMLHEHMBD());
			if (Application.isPlaying)
			{
				if (DGJFKDADPHE.equippedCamo != null && DGJFKDADPHE.equippedCamo != this && OGKCIFGLKJJ)
				{
					DGJFKDADPHE.equippedCamo.EJMFOKBKPLB();
					DGJFKDADPHE.equippedCamo.NJLDNIBIAPH();
				}
				DGJFKDADPHE.equippedCamo = this;
				if (DGJFKDADPHE.equippedHelmet != null)
				{
					DGJFKDADPHE.equippedHelmet.HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ: true);
				}
				if (DGJFKDADPHE.equippedHeadAccesory != null)
				{
					DGJFKDADPHE.equippedHeadAccesory.HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ: true);
				}
				if (DGJFKDADPHE.equippedPowerBand != null)
				{
					DGJFKDADPHE.equippedPowerBand.HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ: true);
				}
			}
		}

		public SkinnedMeshRenderer FHJDNHKKIAH()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
					if (componentsInChildren.Length == 1)
					{
						mMeshBody = componentsInChildren[1];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("GameControllerPVP.StartGame DONE", modelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("game-card-ico-streakboost-full", modelPath));
				}
				IJLOJGLHCOF(gameObject);
			}
			return mMeshBody;
		}

		private void EANIOIEOBNM()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		public override void MBHMIBGFPEG()
		{
			base.MBHMIBGFPEG();
			mMeshBody = null;
			mPreviewMeshBody = null;
			mCamoTextureSmall = null;
			mCamoTexture = null;
			hairMeshes = null;
		}

		public virtual void LKHIKJJNLFK()
		{
			base.GGEBGAOFIIK();
			DKIIMJDCNMG();
			PJMMBOKBKMA();
		}

		private static int EKPJLEELBOE(MeshFilter JDEMAFGJGLD, MeshFilter NOJFJANOHEB)
		{
			return JDEMAFGJGLD.name.CompareTo(NOJFJANOHEB.name);
		}

		public Texture2D KGFKKJCJCON()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		private void LJKHKCDJEGH(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				MeshFilter meshFilter = array[i];
				if (meshFilter.name.Contains("fuseData"))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort(PELDIHELDMJ);
		}

		public Mesh HJLFDLBFMOI(int DFHAAIFFLOE)
		{
			if (hairMeshes != null && DFHAAIFFLOE < hairMeshes.Count)
			{
				return hairMeshes[DFHAAIFFLOE].sharedMesh;
			}
			return null;
		}

		private void FFDOGJEAPFA(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				if (meshFilter.name.Contains("hair"))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort((MeshFilter JDEMAFGJGLD, MeshFilter NOJFJANOHEB) => JDEMAFGJGLD.name.CompareTo(NOJFJANOHEB.name));
		}

		public Texture2D BDMGDJKMABG()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		private void GNEBLCGALCI(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				MeshFilter meshFilter = array[i];
				if (meshFilter.name.Contains("IsAdAvailableForZoneID"))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort(EKPJLEELBOE);
		}

		private static int MLKOINEKCCN(MeshFilter JDEMAFGJGLD, MeshFilter NOJFJANOHEB)
		{
			return JDEMAFGJGLD.name.CompareTo(NOJFJANOHEB.name);
		}

		public virtual void FCJGJKKEPCN()
		{
			base.JDLGJNAIFMM();
		}

		public virtual void PIJBAMHJCFF()
		{
			base.JDLGJNAIFMM();
		}

		private void HOHDNHNHDKI()
		{
			Resources.UnloadAsset(mCamoTexture);
		}

		private void IJLOJGLHCOF(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				MeshFilter meshFilter = array[i];
				if (meshFilter.name.Contains("WarFriendsは追加データを実行するため、約190MBをダウンロードする必要があります。\nダウンロード時間はネットワークと現在位置によって異なります。\n\n続行してもよいですか？"))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort(EKPJLEELBOE);
		}

		public SkinnedMeshRenderer GBOFHMKJFEG()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 0)
					{
						mMeshBody = componentsInChildren[0];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError($"JoinNowSquadMessage-{modelPath}");
					}
				}
				else
				{
					Debug.LogError(string.Format("ID_CONFIRM_ERROR", modelPath));
				}
				LJKHKCDJEGH(gameObject);
			}
			return mMeshBody;
		}

		public SkinnedMeshRenderer JCFOBFPMNJD()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
					if (componentsInChildren.Length == 1)
					{
						mMeshBody = componentsInChildren[1];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("Peer state: ", modelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("ID_WARCARDREADY", modelPath));
				}
				FGKLKMJPPKC(gameObject);
			}
			return mMeshBody;
		}

		public SkinnedMeshRenderer KALGOJEFLFM()
		{
			if (mPreviewMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(previewModelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
					if (componentsInChildren.Length == 1)
					{
						mPreviewMeshBody = componentsInChildren[1];
						mPreviewMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("VipReward1", previewModelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("have virtual goods offer:\n", previewModelPath));
				}
				ELBKGFEFNLC(gameObject);
			}
			return mPreviewMeshBody;
		}

		public override void JDLGJNAIFMM()
		{
			base.JDLGJNAIFMM();
		}

		public SkinnedMeshRenderer ALNNPOOLKDE()
		{
			if (mPreviewMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(previewModelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 1)
					{
						mPreviewMeshBody = componentsInChildren[1];
						mPreviewMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError(string.Format("VIP active: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}", previewModelPath));
					}
				}
				else
				{
					Debug.LogError(string.Format("FinishGameMultiplayerRPC", previewModelPath));
				}
				LOLKCEHHJAF(gameObject);
			}
			return mPreviewMeshBody;
		}

		private static int GNNJPPNMCLE(MeshFilter JDEMAFGJGLD, MeshFilter NOJFJANOHEB)
		{
			return JDEMAFGJGLD.name.CompareTo(NOJFJANOHEB.name);
		}

		public Texture2D PJMMBOKBKMA()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		private void ELBKGFEFNLC(GameObject NPAMLHLLIKC)
		{
			MeshFilter[] componentsInChildren = NPAMLHLLIKC.GetComponentsInChildren<MeshFilter>(includeInactive: false);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				if (meshFilter.name.Contains("ID_PHASEXOFY"))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort(MLKOINEKCCN);
		}

		public virtual void PCHEECHJHBA()
		{
			base.GGEBGAOFIIK();
			ALNNPOOLKDE();
			JAKDPHGMKBA();
		}

		private static int PELDIHELDMJ(MeshFilter JDEMAFGJGLD, MeshFilter NOJFJANOHEB)
		{
			return JDEMAFGJGLD.name.CompareTo(NOJFJANOHEB.name);
		}

		private void FDLONAECMBE()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		public virtual void KHDPMOICMOP()
		{
			base.MKKOFGFOFEE();
			mMeshBody = null;
			mPreviewMeshBody = null;
			mCamoTextureSmall = null;
			mCamoTexture = null;
			hairMeshes = null;
		}

		public Texture2D HBECMMCCPOP()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		private void JCAICDEOKAK()
		{
			Resources.UnloadAsset(mCamoTexture);
		}
	}
}
