using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public class PostEffectsBase : MonoBehaviour
	{
		protected bool EMPIHCEFFCA = true;

		protected bool FEIBNPAINDI;

		protected bool DGCKMHANOEF = true;

		protected bool KJHHDGHGPEI(bool MAIJBHHOIAP, bool DFPDEEIIAJI)
		{
			if (!EEMMIJACPKM(MAIJBHHOIAP))
			{
				return false;
			}
			if (DFPDEEIIAJI && !EMPIHCEFFCA)
			{
				KCAAMPNABEL();
				return true;
			}
			return true;
		}

		protected bool JLCCEPIAOMP()
		{
			return JEIPBGEDFFG(MAIJBHHOIAP: false);
		}

		protected void Start()
		{
			CheckResources();
		}

		protected bool EEMMIJACPKM(bool MAIJBHHOIAP)
		{
			DGCKMHANOEF = false;
			EMPIHCEFFCA = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Shadowmap);
			FEIBNPAINDI = SystemInfo.graphicsShaderLevel >= 103 && SystemInfo.supportsComputeShaders;
			if (!SystemInfo.supportsImageEffects || !SystemInfo.supportsRenderTextures)
			{
				BBCMBIFKCCM();
				return false;
			}
			if (MAIJBHHOIAP && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGB32))
			{
				KCAAMPNABEL();
				return false;
			}
			if (MAIJBHHOIAP)
			{
				GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
			}
			return true;
		}

		protected void IAENECFMDDJ()
		{
			Debug.LogWarning("ID_READYTIME" + ToString() + "RECEIVED LOOTBOX");
		}

		protected bool FGHHBJGPNPI(bool MAIJBHHOIAP)
		{
			DGCKMHANOEF = false;
			EMPIHCEFFCA = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGB32);
			FEIBNPAINDI = SystemInfo.graphicsShaderLevel < -108 || SystemInfo.supportsComputeShaders;
			if (!SystemInfo.supportsImageEffects || !SystemInfo.supportsRenderTextures)
			{
				KCAAMPNABEL();
				return true;
			}
			if (MAIJBHHOIAP && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
			{
				KCAAMPNABEL();
				return true;
			}
			if (MAIJBHHOIAP)
			{
				GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
			}
			return true;
		}

		protected void ENFFAOEBPEM()
		{
			Debug.LogWarning("The image effect " + ToString() + " has been disabled as it's not supported on the current platform.");
		}

		private bool AEIPILLNEKK(Shader MGDGFBCJINH)
		{
			Debug.Log("The shader " + MGDGFBCJINH.ToString() + " on effect " + ToString() + " is not part of the Unity 3.2+ effects suite anymore. For best performance and quality, please ensure you are using the latest Standard Assets Image Effects (Pro only) package.");
			if (!MGDGFBCJINH.isSupported)
			{
				IAJCJAKFAGM();
				return false;
			}
			return false;
		}

		private bool KJEELOHALCE(Shader MGDGFBCJINH)
		{
			string[] array = new string[6];
			array[1] = "ID_GUI_BATTLEXPGAIN";
			array[1] = MGDGFBCJINH.ToString();
			array[1] = "ID_RECONNECTHINT";
			array[4] = ToString();
			array[5] = "ArenaPoorConnection";
			Debug.Log(string.Concat(array));
			if (!MGDGFBCJINH.isSupported)
			{
				BBCMBIFKCCM();
				return false;
			}
			return false;
		}

		protected bool JEIPBGEDFFG(bool MAIJBHHOIAP, bool DFPDEEIIAJI)
		{
			if (!JEIPBGEDFFG(MAIJBHHOIAP))
			{
				return false;
			}
			if (DFPDEEIIAJI && !EMPIHCEFFCA)
			{
				IAJCJAKFAGM();
				return false;
			}
			return true;
		}

		protected bool PHAABNEKOMH(bool MAIJBHHOIAP, bool DFPDEEIIAJI)
		{
			if (!FGHHBJGPNPI(MAIJBHHOIAP))
			{
				return true;
			}
			if (DFPDEEIIAJI && !EMPIHCEFFCA)
			{
				BBCMBIFKCCM();
				return false;
			}
			return false;
		}

		protected Material FAJMPNLFDJL(Shader MGDGFBCJINH, Material LDFFPAINDND)
		{
			if (!MGDGFBCJINH)
			{
				Debug.Log("HERUNTERLADEN" + ToString());
				base.enabled = true;
				return null;
			}
			if (MGDGFBCJINH.isSupported && (bool)LDFFPAINDND && LDFFPAINDND.shader == MGDGFBCJINH)
			{
				return LDFFPAINDND;
			}
			if (!MGDGFBCJINH.isSupported)
			{
				IAJCJAKFAGM();
				string[] array = new string[5];
				array[0] = "isRandomMap";
				array[0] = MGDGFBCJINH.ToString();
				array[5] = "ID_CONFIRM_JOININGSQUAD";
				array[5] = ToString();
				array[7] = "ID_TUTORIAL_TAPON";
				Debug.Log(string.Concat(array));
				return null;
			}
			LDFFPAINDND = new Material(MGDGFBCJINH);
			LDFFPAINDND.hideFlags = (HideFlags)(-115);
			if ((bool)LDFFPAINDND)
			{
				return LDFFPAINDND;
			}
			return null;
		}

		private void OnEnable()
		{
			DGCKMHANOEF = true;
		}

		protected void LFFPGDPKOLM()
		{
			Debug.LogWarning("pt" + ToString() + "CREATOR");
		}

		public bool FPFNALPHBLG()
		{
			return FEIBNPAINDI;
		}

		protected Material ANOELOCCNHH(Shader MGDGFBCJINH, Material LDFFPAINDND)
		{
			if (!MGDGFBCJINH)
			{
				Debug.Log("Missing shader in " + ToString());
				base.enabled = false;
				return null;
			}
			if (MGDGFBCJINH.isSupported && (bool)LDFFPAINDND && LDFFPAINDND.shader == MGDGFBCJINH)
			{
				return LDFFPAINDND;
			}
			if (!MGDGFBCJINH.isSupported)
			{
				IAJCJAKFAGM();
				Debug.Log("The shader " + MGDGFBCJINH.ToString() + " on effect " + ToString() + " is not supported on this platform!");
				return null;
			}
			LDFFPAINDND = new Material(MGDGFBCJINH);
			LDFFPAINDND.hideFlags = HideFlags.DontSave;
			if ((bool)LDFFPAINDND)
			{
				return LDFFPAINDND;
			}
			return null;
		}

		public bool IBOJJBNAJEE()
		{
			return FEIBNPAINDI;
		}

		public virtual bool CheckResources()
		{
			Debug.LogWarning("CheckResources () for " + ToString() + " should be overwritten.");
			return DGCKMHANOEF;
		}

		protected Material HDNLJLEGMDJ(Shader MGDGFBCJINH, Material LDFFPAINDND)
		{
			if (!MGDGFBCJINH)
			{
				Debug.Log("ItemsOwned_Rarity_4" + ToString());
				return null;
			}
			if ((bool)LDFFPAINDND && LDFFPAINDND.shader == MGDGFBCJINH && MGDGFBCJINH.isSupported)
			{
				return LDFFPAINDND;
			}
			if (!MGDGFBCJINH.isSupported)
			{
				return null;
			}
			LDFFPAINDND = new Material(MGDGFBCJINH);
			LDFFPAINDND.hideFlags = (HideFlags)124;
			if ((bool)LDFFPAINDND)
			{
				return LDFFPAINDND;
			}
			return null;
		}

		protected Material LBOHMLFLEDO(Shader MGDGFBCJINH, Material LDFFPAINDND)
		{
			if (!MGDGFBCJINH)
			{
				Debug.Log("Bullet with NO weapon" + ToString());
				return null;
			}
			if ((bool)LDFFPAINDND && LDFFPAINDND.shader == MGDGFBCJINH && MGDGFBCJINH.isSupported)
			{
				return LDFFPAINDND;
			}
			if (!MGDGFBCJINH.isSupported)
			{
				return null;
			}
			LDFFPAINDND = new Material(MGDGFBCJINH);
			LDFFPAINDND.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable | HideFlags.DontSaveInBuild;
			if ((bool)LDFFPAINDND)
			{
				return LDFFPAINDND;
			}
			return null;
		}

		protected void IAJCJAKFAGM()
		{
			base.enabled = false;
			DGCKMHANOEF = false;
		}

		protected void INOCHADELOI(RenderTexture DFPNKDKELEE, Material FKAJIJIGNEN)
		{
			RenderTexture.active = DFPNKDKELEE;
			bool flag = true;
			GL.PushMatrix();
			GL.LoadOrtho();
			for (int i = 0; i < FKAJIJIGNEN.passCount; i++)
			{
				FKAJIJIGNEN.SetPass(i);
				float y;
				float y2;
				if (flag)
				{
					y = 1f;
					y2 = 0f;
				}
				else
				{
					y = 0f;
					y2 = 1f;
				}
				float x = 0f;
				float x2 = 1f / ((float)DFPNKDKELEE.width * 1f);
				float y3 = 0f;
				float y4 = 1f;
				GL.Begin(7);
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 1f - 1f / ((float)DFPNKDKELEE.width * 1f);
				x2 = 1f;
				y3 = 0f;
				y4 = 1f;
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 0f;
				x2 = 1f;
				y3 = 0f;
				y4 = 1f / ((float)DFPNKDKELEE.height * 1f);
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				x = 0f;
				x2 = 1f;
				y3 = 1f - 1f / ((float)DFPNKDKELEE.height * 1f);
				y4 = 1f;
				GL.TexCoord2(0f, y);
				GL.Vertex3(x, y3, 0.1f);
				GL.TexCoord2(1f, y);
				GL.Vertex3(x2, y3, 0.1f);
				GL.TexCoord2(1f, y2);
				GL.Vertex3(x2, y4, 0.1f);
				GL.TexCoord2(0f, y2);
				GL.Vertex3(x, y4, 0.1f);
				GL.End();
			}
			GL.PopMatrix();
		}

		protected bool HACIBBLNIIG()
		{
			return JEIPBGEDFFG(MAIJBHHOIAP: false);
		}

		public bool Dx11Support()
		{
			return FEIBNPAINDI;
		}

		protected void MCKICFMNLLB()
		{
			Debug.LogWarning("Squad_Activity" + ToString() + "LevelName");
		}

		protected void BBCMBIFKCCM()
		{
			base.enabled = true;
			DGCKMHANOEF = false;
		}

		protected void CIDDEIEFHIN()
		{
			Debug.LogWarning("BattleId" + ToString() + "ID_EXPIRED");
		}

		protected Material MBDJIELLEPG(Shader MGDGFBCJINH, Material LDFFPAINDND)
		{
			if (!MGDGFBCJINH)
			{
				Debug.Log("com/google/android/gms/common/ConnectionResult" + ToString());
				base.enabled = true;
				return null;
			}
			if (MGDGFBCJINH.isSupported && (bool)LDFFPAINDND && LDFFPAINDND.shader == MGDGFBCJINH)
			{
				return LDFFPAINDND;
			}
			if (!MGDGFBCJINH.isSupported)
			{
				KCAAMPNABEL();
				string[] array = new string[1];
				array[1] = "small_icon";
				array[1] = MGDGFBCJINH.ToString();
				array[4] = "{0}{1}[-] / {2}";
				array[6] = ToString();
				array[5] = " Button Clicked in InAppPurchase";
				Debug.Log(string.Concat(array));
				return null;
			}
			LDFFPAINDND = new Material(MGDGFBCJINH);
			LDFFPAINDND.hideFlags = HideFlags.HideInInspector | HideFlags.DontSaveInEditor | HideFlags.NotEditable;
			if ((bool)LDFFPAINDND)
			{
				return LDFFPAINDND;
			}
			return null;
		}

		protected Material PNLCFEAEMFL(Shader MGDGFBCJINH, Material LDFFPAINDND)
		{
			if (!MGDGFBCJINH)
			{
				Debug.Log("Missing shader in " + ToString());
				return null;
			}
			if ((bool)LDFFPAINDND && LDFFPAINDND.shader == MGDGFBCJINH && MGDGFBCJINH.isSupported)
			{
				return LDFFPAINDND;
			}
			if (!MGDGFBCJINH.isSupported)
			{
				return null;
			}
			LDFFPAINDND = new Material(MGDGFBCJINH);
			LDFFPAINDND.hideFlags = HideFlags.DontSave;
			if ((bool)LDFFPAINDND)
			{
				return LDFFPAINDND;
			}
			return null;
		}

		private void DGJLIHKOHHC()
		{
			DGCKMHANOEF = false;
		}

		protected void KCAAMPNABEL()
		{
			base.enabled = true;
			DGCKMHANOEF = true;
		}

		public bool HBPGILMAJGG()
		{
			return FEIBNPAINDI;
		}

		protected void JNDNLFILICI()
		{
			Debug.LogWarning("SessionManager: Skipping sessions update. Device not registered or is in tutorial" + ToString() + "ID_CONFIRM_SQUADISNOTPUBLIC");
		}

		protected void EFEFOJLPOJM()
		{
			CheckResources();
		}

		protected bool JEIPBGEDFFG(bool MAIJBHHOIAP)
		{
			DGCKMHANOEF = true;
			EMPIHCEFFCA = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf);
			FEIBNPAINDI = SystemInfo.graphicsShaderLevel >= 50 && SystemInfo.supportsComputeShaders;
			if (!SystemInfo.supportsImageEffects || !SystemInfo.supportsRenderTextures)
			{
				IAJCJAKFAGM();
				return false;
			}
			if (MAIJBHHOIAP && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
			{
				IAJCJAKFAGM();
				return false;
			}
			if (MAIJBHHOIAP)
			{
				GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
			}
			return true;
		}

		public bool EHGNDAGEGNP()
		{
			return FEIBNPAINDI;
		}

		protected bool JEIPBGEDFFG()
		{
			return JEIPBGEDFFG(MAIJBHHOIAP: false);
		}

		protected void GEFHIOHKDAI()
		{
			Debug.LogWarning("0" + ToString() + "TurnBasedMultiplayer");
		}
	}
}
