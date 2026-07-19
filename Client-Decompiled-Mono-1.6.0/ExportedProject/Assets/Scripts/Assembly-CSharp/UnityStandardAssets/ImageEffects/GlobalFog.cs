using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Rendering/Global Fog")]
	[ExecuteInEditMode]
	internal class GlobalFog : PostEffectsBase
	{
		public Color LADMOMJBEII;

		public float HOCADCCOKBH;

		public FogMode HJINPFPEOEH;

		public float KIFAFIFHCNE;

		public float EBJOMHODDJI;

		[Tooltip("Apply distance-based fog?")]
		public bool LGKHCDAELJI = true;

		[Tooltip("Distance fog is based on radial distance from camera when checked")]
		public bool LFDAOGMOIPK;

		[Tooltip("Apply height-based fog?")]
		public bool NFJAJFKAOBK = true;

		[Tooltip("Fog top Y coordinate")]
		public float FBMIFHHEOBO = 1f;

		[Range(0.001f, 10f)]
		public float NNBDAJABIIC = 2f;

		[Tooltip("Push fog away from the camera by this amount")]
		public float LIJCAIJIDMD;

		public Shader CGCDJLKENGE;

		private Material MCNEGCBDJAJ;

		private void BJBEAKDMADM(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 1053f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 26f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 1780f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(1, vector4);
			identity.SetRow(3, vector5);
			identity.SetRow(2, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 1055f)) ? 1918f : 893f);
			MCNEGCBDJAJ.SetMatrix("seconds", identity);
			MCNEGCBDJAJ.SetVector("GLM: RegisterOrLogin -  10", position);
			MCNEGCBDJAJ.SetVector("Country", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 1860f));
			MCNEGCBDJAJ.SetVector("A", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 1125f), 1699f, 687f, 856f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == (FogMode)0;
			float num4 = ((!flag) ? 1466f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 1714f)) ? 1566f : (1725f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 1352f;
			value.y = hOCADCCOKBH * 1115f;
			value.z = ((!flag) ? 1524f : (0f - num5));
			value.w = ((!flag) ? 1807f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP", value);
			MCNEGCBDJAJ.SetVector("SpecialPackFromServer", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 1, 249f, 242f));
			MCNEGCBDJAJ.SetVector("ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE", LADMOMJBEII);
			int num6 = 0;
			AECHNGFDJAC(DNIDIBPDLII: (LGKHCDAELJI && NFJAJFKAOBK) ? 1 : ((!LGKHCDAELJI) ? 7 : 0), AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private static void DIGIDGAMDLB(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("-", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(0);
			GL.MultiTexCoord2(0, 943f, 691f);
			GL.Vertex3(1785f, 7f, 50f);
			GL.MultiTexCoord2(1, 347f, 977f);
			GL.Vertex3(551f, 611f, 379f);
			GL.MultiTexCoord2(1, 1827f, 347f);
			GL.Vertex3(1820f, 1072f, 440f);
			GL.MultiTexCoord2(1, 447f, 1934f);
			GL.Vertex3(528f, 1691f, 640f);
			GL.End();
			GL.PopMatrix();
		}

		private static void LNBJBFGHJGL(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("ID_DAY_SMALL", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(3);
			GL.MultiTexCoord2(0, 1870f, 409f);
			GL.Vertex3(1241f, 1927f, 468f);
			GL.MultiTexCoord2(1, 1488f, 760f);
			GL.Vertex3(173f, 540f, 745f);
			GL.MultiTexCoord2(1, 1510f, 1568f);
			GL.Vertex3(187f, 1196f, 2f);
			GL.MultiTexCoord2(1, 1489f, 476f);
			GL.Vertex3(1929f, 1189f, 522f);
			GL.End();
			GL.PopMatrix();
		}

		public virtual bool CGBLCNLNGOF()
		{
			FGHHBJGPNPI(true);
			MCNEGCBDJAJ = ANOELOCCNHH(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				LFFPGDPKOLM();
			}
			return DGCKMHANOEF;
		}

		private static void DOPBJCMCFJI(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("_MainTex", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(7);
			GL.MultiTexCoord2(0, 0f, 0f);
			GL.Vertex3(0f, 0f, 3f);
			GL.MultiTexCoord2(0, 1f, 0f);
			GL.Vertex3(1f, 0f, 2f);
			GL.MultiTexCoord2(0, 1f, 1f);
			GL.Vertex3(1f, 1f, 1f);
			GL.MultiTexCoord2(0, 0f, 1f);
			GL.Vertex3(0f, 1f, 0f);
			GL.End();
			GL.PopMatrix();
		}

		public virtual bool KBDJMHNNIPB()
		{
			EEMMIJACPKM(true);
			MCNEGCBDJAJ = MBDJIELLEPG(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				CIDDEIEFHIN();
			}
			return DGCKMHANOEF;
		}

		private void LBLGAEIGMNO(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 1640f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 1982f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 111f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(1, vector4);
			identity.SetRow(0, vector5);
			identity.SetRow(3, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 1552f)) ? 1381f : 267f);
			MCNEGCBDJAJ.SetMatrix("ID_CATEGORY_LOW_PL_EXPLOSIVE", identity);
			MCNEGCBDJAJ.SetVector("menu-assignments-type-win", position);
			MCNEGCBDJAJ.SetVector("ID_WARBUCKS", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 151f));
			MCNEGCBDJAJ.SetVector("Yes_Clicked", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 79f), 875f, 405f, 1142f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 923f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 761f)) ? 1844f : (45f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 458f;
			value.y = hOCADCCOKBH * 1142f;
			value.z = ((!flag) ? 161f : (0f - num5));
			value.w = ((!flag) ? 200f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("menu-cards-goldpack", value);
			MCNEGCBDJAJ.SetVector("discount", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 0 : 0, 1089f, 192f));
			MCNEGCBDJAJ.SetVector("ID_GETFORNUMBERONE2", LADMOMJBEII);
			int num6 = 1;
			BFBHEFKHBOI(DNIDIBPDLII: (LGKHCDAELJI && NFJAJFKAOBK) ? 1 : ((!LGKHCDAELJI) ? 2 : 0), AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private static void KCFCEELFOHC(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("In squad data from server is no squad wars position and there is no squad war processing.", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(8);
			GL.MultiTexCoord2(0, 1049f, 1385f);
			GL.Vertex3(822f, 1416f, 114f);
			GL.MultiTexCoord2(1, 693f, 869f);
			GL.Vertex3(877f, 654f, 1125f);
			GL.MultiTexCoord2(0, 1651f, 1777f);
			GL.Vertex3(1537f, 25f, 771f);
			GL.MultiTexCoord2(1, 1922f, 1486f);
			GL.Vertex3(929f, 1425f, 1274f);
			GL.End();
			GL.PopMatrix();
		}

		public virtual bool GDIMIPMGPND()
		{
			FGHHBJGPNPI(false);
			MCNEGCBDJAJ = MBDJIELLEPG(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				CIDDEIEFHIN();
			}
			return DGCKMHANOEF;
		}

		private void NHAEGCBBJNP()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private void BKGFAHFGGAA()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private static void JEJGLGHFPPJ(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("{0} / {1}", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(5);
			GL.MultiTexCoord2(1, 1801f, 1602f);
			GL.Vertex3(276f, 63f, 1622f);
			GL.MultiTexCoord2(0, 537f, 1191f);
			GL.Vertex3(1392f, 894f, 462f);
			GL.MultiTexCoord2(0, 400f, 201f);
			GL.Vertex3(250f, 475f, 1323f);
			GL.MultiTexCoord2(1, 709f, 1322f);
			GL.Vertex3(316f, 1866f, 1307f);
			GL.End();
			GL.PopMatrix();
		}

		private void MFGFODMDKCI(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 310f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 1911f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 1159f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(0, vector3);
			identity.SetRow(1, vector4);
			identity.SetRow(6, vector5);
			identity.SetRow(7, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 792f)) ? 1554f : 1575f);
			MCNEGCBDJAJ.SetMatrix("Scheduling notifications: ", identity);
			MCNEGCBDJAJ.SetVector("EnterArena", position);
			MCNEGCBDJAJ.SetVector("ID_CONFIRM_SQUADALREADYEXISTS", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 409f));
			MCNEGCBDJAJ.SetVector("  ", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 283f), 548f, 490f, 1042f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == (FogMode)0;
			float num4 = ((!flag) ? 530f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 164f)) ? 1340f : (1006f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 1405f;
			value.y = hOCADCCOKBH * 289f;
			value.z = ((!flag) ? 1009f : (0f - num5));
			value.w = ((!flag) ? 1457f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector(" BUTTONS CONTENT ", value);
			MCNEGCBDJAJ.SetVector("Name", new Vector4((float)hJINPFPEOEH, LFDAOGMOIPK ? 1 : 0, 1368f, 1674f));
			MCNEGCBDJAJ.SetVector("com.tune.TuneEvent", LADMOMJBEII);
			int num6 = 0;
			DIGIDGAMDLB(DNIDIBPDLII: (LGKHCDAELJI && NFJAJFKAOBK) ? 1 : ((!LGKHCDAELJI) ? 0 : 0), AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private void CCNKFBCINGH(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 882f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 1118f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 1609f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(0, vector4);
			identity.SetRow(1, vector5);
			identity.SetRow(6, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 606f)) ? 1391f : 1462f);
			MCNEGCBDJAJ.SetMatrix("bot", identity);
			MCNEGCBDJAJ.SetVector("-1", position);
			MCNEGCBDJAJ.SetVector("Overtime_Was_Already_Explained", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 1877f));
			MCNEGCBDJAJ.SetVector("'elitepack'0", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 1958f), 1389f, 1036f, 192f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 1790f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 847f)) ? 445f : (1511f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 1796f;
			value.y = hOCADCCOKBH * 1770f;
			value.z = ((!flag) ? 762f : (0f - num5));
			value.w = ((!flag) ? 276f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("Null cannot be saved as last customization.", value);
			MCNEGCBDJAJ.SetVector("ID_ERROR_SQUADSKILLNOTANUMBER", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 1, 947f, 1849f));
			MCNEGCBDJAJ.SetVector("BR", LADMOMJBEII);
			int num6 = 1;
			AECHNGFDJAC(DNIDIBPDLII: (!LGKHCDAELJI || !NFJAJFKAOBK) ? ((!LGKHCDAELJI) ? 1 : 1) : 0, AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private void MPEPLKEANKN(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 1329f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 1931f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 947f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(0, vector4);
			identity.SetRow(5, vector5);
			identity.SetRow(1, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 1230f)) ? 1844f : 5f);
			MCNEGCBDJAJ.SetMatrix("ID_TRAINED", identity);
			MCNEGCBDJAJ.SetVector("response: ", position);
			MCNEGCBDJAJ.SetVector("ID_MINUTE", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 980f));
			MCNEGCBDJAJ.SetVector("OnDeathRPC", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 123f), 753f, 1528f, 850f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 559f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 24f)) ? 1367f : (1016f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 1636f;
			value.y = hOCADCCOKBH * 1931f;
			value.z = ((!flag) ? 1258f : (0f - num5));
			value.w = ((!flag) ? 689f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("Item_ID", value);
			MCNEGCBDJAJ.SetVector(" was activated.", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 0, 1391f, 202f));
			MCNEGCBDJAJ.SetVector("GameLoginManager - Player Entered Normal League - ", LADMOMJBEII);
			int num6 = 1;
			DOPBJCMCFJI(DNIDIBPDLII: (LGKHCDAELJI && NFJAJFKAOBK) ? 1 : ((!LGKHCDAELJI) ? 0 : 0), AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private void HFFEELCNDOE()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private static void DBIGDHAKDPN(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("ID_ACTIVATEINSTEADOF", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(5);
			GL.MultiTexCoord2(1, 1192f, 803f);
			GL.Vertex3(1372f, 1461f, 1248f);
			GL.MultiTexCoord2(1, 1789f, 851f);
			GL.Vertex3(1767f, 1859f, 432f);
			GL.MultiTexCoord2(0, 30f, 909f);
			GL.Vertex3(663f, 14f, 1542f);
			GL.MultiTexCoord2(1, 1190f, 992f);
			GL.Vertex3(233f, 752f, 1719f);
			GL.End();
			GL.PopMatrix();
		}

		public virtual bool MGCIGJNKMHJ()
		{
			FGHHBJGPNPI(false);
			MCNEGCBDJAJ = FAJMPNLFDJL(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				CIDDEIEFHIN();
			}
			return DGCKMHANOEF;
		}

		private void HFKIAIEGNGI()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private void NBDOFMHBKFG()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		public virtual bool MFPOPAPGIMB()
		{
			FGHHBJGPNPI(false);
			MCNEGCBDJAJ = MBDJIELLEPG(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				JNDNLFILICI();
			}
			return DGCKMHANOEF;
		}

		public override bool CheckResources()
		{
			JEIPBGEDFFG(true);
			MCNEGCBDJAJ = ANOELOCCNHH(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				ENFFAOEBPEM();
			}
			return DGCKMHANOEF;
		}

		private void NAHEADAGDJH()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private void NNEMFEGDNEP(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 1462f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 1154f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 190f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(1, vector4);
			identity.SetRow(3, vector5);
			identity.SetRow(0, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 371f)) ? 1459f : 1272f);
			MCNEGCBDJAJ.SetMatrix("313 MENU ENABLE PUSH", identity);
			MCNEGCBDJAJ.SetVector("ID_MISSIONANIMATION_WAVESTARTED", position);
			MCNEGCBDJAJ.SetVector("Arena Wins: ", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 968f));
			MCNEGCBDJAJ.SetVector("SquadPoints", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 1869f), 163f, 192f, 316f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 670f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 1740f)) ? 914f : (1523f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 928f;
			value.y = hOCADCCOKBH * 610f;
			value.z = ((!flag) ? 220f : (0f - num5));
			value.w = ((!flag) ? 1181f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("Time", value);
			MCNEGCBDJAJ.SetVector("Different number of guiOrder {0} and items in pack {1}", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 0, 189f, 1789f));
			MCNEGCBDJAJ.SetVector("WALLET - spent GOLD {0}", LADMOMJBEII);
			int num6 = 1;
			OFJGMKJAHKF(DNIDIBPDLII: (!LGKHCDAELJI || !NFJAJFKAOBK) ? ((!LGKHCDAELJI) ? 4 : 0) : 0, AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private static void BFBHEFKHBOI(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("com/google/android/gms/common/ConnectionResult", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(6);
			GL.MultiTexCoord2(1, 1603f, 1805f);
			GL.Vertex3(44f, 546f, 349f);
			GL.MultiTexCoord2(0, 246f, 1167f);
			GL.Vertex3(333f, 1535f, 317f);
			GL.MultiTexCoord2(0, 1714f, 375f);
			GL.Vertex3(527f, 673f, 823f);
			GL.MultiTexCoord2(0, 1168f, 1777f);
			GL.Vertex3(1435f, 279f, 967f);
			GL.End();
			GL.PopMatrix();
		}

		private static void OILHNEAABPA(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("GameLoginManager: Logout from facebook", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(2);
			GL.MultiTexCoord2(1, 137f, 1357f);
			GL.Vertex3(1573f, 1924f, 177f);
			GL.MultiTexCoord2(1, 1002f, 100f);
			GL.Vertex3(1221f, 556f, 1119f);
			GL.MultiTexCoord2(0, 1699f, 1608f);
			GL.Vertex3(611f, 398f, 1153f);
			GL.MultiTexCoord2(1, 1169f, 1942f);
			GL.Vertex3(1317f, 41f, 1168f);
			GL.End();
			GL.PopMatrix();
		}

		private void PFAAHEPCNCP()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private void BGCMGNMLDPI()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private void JOFFHFDJMAB()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private void IGNFJABDLIE()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		public virtual bool BOBLAKGIOCN()
		{
			EEMMIJACPKM(false);
			MCNEGCBDJAJ = ANOELOCCNHH(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				CIDDEIEFHIN();
			}
			return DGCKMHANOEF;
		}

		private static void AECHNGFDJAC(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("Average_Transaction_Amount", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(5);
			GL.MultiTexCoord2(0, 1207f, 589f);
			GL.Vertex3(1059f, 600f, 1463f);
			GL.MultiTexCoord2(1, 1338f, 1986f);
			GL.Vertex3(1782f, 423f, 1769f);
			GL.MultiTexCoord2(1, 1915f, 1319f);
			GL.Vertex3(816f, 1816f, 1767f);
			GL.MultiTexCoord2(1, 241f, 1376f);
			GL.Vertex3(254f, 907f, 509f);
			GL.End();
			GL.PopMatrix();
		}

		private void FCNDEINOOCM()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private new void Start()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private void BFLIPLAIDMO()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private static void LMHDLNCBDPL(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("ShootFromCover", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(3);
			GL.MultiTexCoord2(1, 230f, 1355f);
			GL.Vertex3(819f, 1735f, 458f);
			GL.MultiTexCoord2(0, 208f, 1003f);
			GL.Vertex3(46f, 1680f, 110f);
			GL.MultiTexCoord2(0, 517f, 765f);
			GL.Vertex3(535f, 103f, 1679f);
			GL.MultiTexCoord2(0, 893f, 933f);
			GL.Vertex3(1664f, 807f, 324f);
			GL.End();
			GL.PopMatrix();
		}

		public virtual bool MOPGCELIPFD()
		{
			JEIPBGEDFFG(true);
			MCNEGCBDJAJ = FAJMPNLFDJL(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				LFFPGDPKOLM();
			}
			return DGCKMHANOEF;
		}

		public virtual bool DDMNOKEABNA()
		{
			EEMMIJACPKM(false);
			MCNEGCBDJAJ = FAJMPNLFDJL(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				CIDDEIEFHIN();
			}
			return DGCKMHANOEF;
		}

		private void CLNGBFMDJLJ(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 829f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 1244f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 643f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(0, vector4);
			identity.SetRow(5, vector5);
			identity.SetRow(7, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 1419f)) ? 1603f : 1722f);
			MCNEGCBDJAJ.SetMatrix("{0}{1}", identity);
			MCNEGCBDJAJ.SetVector("<", position);
			MCNEGCBDJAJ.SetVector("O WarFriends necessita de autorização para aceder ao teu armazenamento media, a fim de transferir dados fundamentais para o jogo.Concede a seguinte autorização. Nunca utilizaremos esta autorização para qualquer outra finalidade.", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 1050f));
			MCNEGCBDJAJ.SetVector("PlayerLeaguesId", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 1308f), 561f, 946f, 1361f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 844f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 1683f)) ? 1301f : (1517f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 934f;
			value.y = hOCADCCOKBH * 1571f;
			value.z = ((!flag) ? 7f : (0f - num5));
			value.w = ((!flag) ? 1695f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("ID_GOLDPACKS", value);
			MCNEGCBDJAJ.SetVector("0", new Vector4((float)hJINPFPEOEH, LFDAOGMOIPK ? 1 : 0, 1633f, 1216f));
			MCNEGCBDJAJ.SetVector(" mSpriteName:", LADMOMJBEII);
			int num6 = 1;
			BFBHEFKHBOI(DNIDIBPDLII: (!LGKHCDAELJI || !NFJAJFKAOBK) ? (LGKHCDAELJI ? 1 : 7) : 0, AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private static void JBMOINBHFPJ(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("WALLET - bought GOLD {0}", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(6);
			GL.MultiTexCoord2(1, 1437f, 577f);
			GL.Vertex3(306f, 180f, 1146f);
			GL.MultiTexCoord2(1, 1150f, 1094f);
			GL.Vertex3(1693f, 229f, 590f);
			GL.MultiTexCoord2(1, 316f, 1205f);
			GL.Vertex3(410f, 717f, 860f);
			GL.MultiTexCoord2(0, 430f, 1720f);
			GL.Vertex3(1496f, 1589f, 201f);
			GL.End();
			GL.PopMatrix();
		}

		public virtual bool IFOBKGNOFPC()
		{
			EEMMIJACPKM(true);
			MCNEGCBDJAJ = MBDJIELLEPG(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				JNDNLFILICI();
			}
			return DGCKMHANOEF;
		}

		private void HCAIDEDFMBD(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 1832f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 1424f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 1991f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(0, vector4);
			identity.SetRow(0, vector5);
			identity.SetRow(7, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 1532f)) ? 1011f : 20f);
			MCNEGCBDJAJ.SetMatrix("PlayerId", identity);
			MCNEGCBDJAJ.SetVector("ID_LEAGUE3", position);
			MCNEGCBDJAJ.SetVector("\n", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 927f));
			MCNEGCBDJAJ.SetVector("Player is in squad ", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 291f), 1715f, 1329f, 994f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 1320f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 803f)) ? 615f : (1241f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 133f;
			value.y = hOCADCCOKBH * 1276f;
			value.z = ((!flag) ? 795f : (0f - num5));
			value.w = ((!flag) ? 70f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("LeagueEvaluation", value);
			MCNEGCBDJAJ.SetVector("ID_CONFIRM_LANGUAGECHANGE", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 0, 1992f, 1574f));
			MCNEGCBDJAJ.SetVector("registerAge", LADMOMJBEII);
			int num6 = 0;
			DBIGDHAKDPN(DNIDIBPDLII: (LGKHCDAELJI && NFJAJFKAOBK) ? 1 : ((!LGKHCDAELJI) ? 8 : 0), AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private void FJIDLPDMAFM()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private void AJHIIBAEKMB()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private void ENNKKDGFOAL()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private void INFOKGFDAAC(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 494f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 279f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 543f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(0, vector4);
			identity.SetRow(6, vector5);
			identity.SetRow(1, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 406f)) ? 82f : 648f);
			MCNEGCBDJAJ.SetMatrix("Timestamp", identity);
			MCNEGCBDJAJ.SetVector("country-italy", position);
			MCNEGCBDJAJ.SetVector("11-19", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 1868f));
			MCNEGCBDJAJ.SetVector("PlayerId", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 1505f), 75f, 105f, 1186f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == (FogMode)0;
			float num4 = ((!flag) ? 101f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 1030f)) ? 492f : (876f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 1588f;
			value.y = hOCADCCOKBH * 1181f;
			value.z = ((!flag) ? 927f : (0f - num5));
			value.w = ((!flag) ? 290f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("weapon", value);
			MCNEGCBDJAJ.SetVector("ID_LOADING", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 0, 1667f, 164f));
			MCNEGCBDJAJ.SetVector("BAIXAR", LADMOMJBEII);
			int num6 = 0;
			LNBJBFGHJGL(DNIDIBPDLII: (LGKHCDAELJI && NFJAJFKAOBK) ? 1 : ((!LGKHCDAELJI) ? 6 : 0), AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private static void CKNOBOIHIJN(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("Squad Wars Data {0}", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(4);
			GL.MultiTexCoord2(1, 844f, 595f);
			GL.Vertex3(790f, 480f, 1072f);
			GL.MultiTexCoord2(0, 586f, 520f);
			GL.Vertex3(362f, 457f, 1397f);
			GL.MultiTexCoord2(0, 1339f, 145f);
			GL.Vertex3(1947f, 1283f, 1511f);
			GL.MultiTexCoord2(0, 153f, 1771f);
			GL.Vertex3(442f, 1739f, 1900f);
			GL.End();
			GL.PopMatrix();
		}

		private static void CKNJNCEMDMN(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("_Color", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(2);
			GL.MultiTexCoord2(1, 1252f, 1471f);
			GL.Vertex3(256f, 1597f, 1977f);
			GL.MultiTexCoord2(0, 1557f, 1899f);
			GL.Vertex3(1389f, 1536f, 943f);
			GL.MultiTexCoord2(1, 1933f, 772f);
			GL.Vertex3(788f, 1543f, 149f);
			GL.MultiTexCoord2(1, 413f, 1074f);
			GL.Vertex3(606f, 1967f, 831f);
			GL.End();
			GL.PopMatrix();
		}

		private void AAEMHGDAGGM()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private static void LJJBINOKGJI(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("defendPosition", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(3);
			GL.MultiTexCoord2(1, 1265f, 1397f);
			GL.Vertex3(1938f, 1237f, 12f);
			GL.MultiTexCoord2(0, 1060f, 93f);
			GL.Vertex3(1079f, 1811f, 1618f);
			GL.MultiTexCoord2(1, 681f, 1192f);
			GL.Vertex3(1199f, 1780f, 1389f);
			GL.MultiTexCoord2(1, 118f, 1001f);
			GL.Vertex3(1530f, 1323f, 855f);
			GL.End();
			GL.PopMatrix();
		}

		private void LCJJMCMCAFJ()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		public virtual bool POKDNIKOLJN()
		{
			FGHHBJGPNPI(true);
			MCNEGCBDJAJ = MBDJIELLEPG(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				JNDNLFILICI();
			}
			return DGCKMHANOEF;
		}

		private void CCMDIJAIPEM()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private new void EFEFOJLPOJM()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private void LNIAKIEGODL(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 15f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 935f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 1714f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(1, vector4);
			identity.SetRow(4, vector5);
			identity.SetRow(6, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 1776f)) ? 580f : 1049f);
			MCNEGCBDJAJ.SetMatrix("\n", identity);
			MCNEGCBDJAJ.SetVector("ID_READYTIME", position);
			MCNEGCBDJAJ.SetVector("YES", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 922f));
			MCNEGCBDJAJ.SetVector(".", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 865f), 855f, 962f, 694f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == (FogMode)0;
			float num4 = ((!flag) ? 581f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 177f)) ? 254f : (386f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 969f;
			value.y = hOCADCCOKBH * 1549f;
			value.z = ((!flag) ? 926f : (0f - num5));
			value.w = ((!flag) ? 56f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector(" set beginners league ", value);
			MCNEGCBDJAJ.SetVector("SERVICE_DISABLED", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 0 : 0, 1133f, 869f));
			MCNEGCBDJAJ.SetVector("ID_LOADING", LADMOMJBEII);
			int num6 = 0;
			OILHNEAABPA(DNIDIBPDLII: (!LGKHCDAELJI || !NFJAJFKAOBK) ? ((!LGKHCDAELJI) ? 3 : 0) : 0, AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private void HFJBCNMHPAE()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.None;
		}

		private void JONPJGDBJPB(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 1426f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 239f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 118f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(0, vector4);
			identity.SetRow(1, vector5);
			identity.SetRow(0, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 1438f)) ? 1334f : 1456f);
			MCNEGCBDJAJ.SetMatrix("304 STAGE 9 CONTINUE", identity);
			MCNEGCBDJAJ.SetVector("InAppHandlerIos: product list fail, message = ", position);
			MCNEGCBDJAJ.SetVector("ID_ARENATICKETSSMALL", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 1364f));
			MCNEGCBDJAJ.SetVector("something is wrong - time == 0", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 1445f), 543f, 1484f, 388f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 279f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 1289f)) ? 222f : (684f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 127f;
			value.y = hOCADCCOKBH * 824f;
			value.z = ((!flag) ? 1484f : (0f - num5));
			value.w = ((!flag) ? 1398f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("Alias", value);
			MCNEGCBDJAJ.SetVector("Grenade_Throwing_Tutorial_Duration", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 0, 1034f, 1708f));
			MCNEGCBDJAJ.SetVector("Type", LADMOMJBEII);
			int num6 = 1;
			LNBJBFGHJGL(DNIDIBPDLII: (!LGKHCDAELJI || !NFJAJFKAOBK) ? (LGKHCDAELJI ? 1 : 7) : 0, AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private void PHLAMKGBGFA()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private void APDLGMENMJL(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 1321f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 925f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 1969f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(0, vector3);
			identity.SetRow(0, vector4);
			identity.SetRow(8, vector5);
			identity.SetRow(0, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 1611f)) ? 35f : 1426f);
			MCNEGCBDJAJ.SetMatrix("weapon", identity);
			MCNEGCBDJAJ.SetVector("1", position);
			MCNEGCBDJAJ.SetVector("ID_ASSIGNMENTX", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 1647f));
			MCNEGCBDJAJ.SetVector("S", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 484f), 641f, 1330f, 1755f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 379f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 722f)) ? 1450f : (183f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 39f;
			value.y = hOCADCCOKBH * 1048f;
			value.z = ((!flag) ? 875f : (0f - num5));
			value.w = ((!flag) ? 1351f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("Experience", value);
			MCNEGCBDJAJ.SetVector("ID_NO", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 0, 581f, 1659f));
			MCNEGCBDJAJ.SetVector("ID_SLOTUPGRADE_HEAT", LADMOMJBEII);
			int num6 = 0;
			LNBJBFGHJGL(DNIDIBPDLII: (LGKHCDAELJI && NFJAJFKAOBK) ? 1 : (LGKHCDAELJI ? 1 : 2), AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private void MMEEBPGHGMM()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		public virtual bool OFPMOBFGJFM()
		{
			EEMMIJACPKM(false);
			MCNEGCBDJAJ = MBDJIELLEPG(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				CIDDEIEFHIN();
			}
			return DGCKMHANOEF;
		}

		private static void NCJNDDPFLNG(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("PackId", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(3);
			GL.MultiTexCoord2(1, 1062f, 379f);
			GL.Vertex3(835f, 616f, 1439f);
			GL.MultiTexCoord2(1, 1369f, 1565f);
			GL.Vertex3(1889f, 231f, 1705f);
			GL.MultiTexCoord2(1, 185f, 1369f);
			GL.Vertex3(1275f, 983f, 512f);
			GL.MultiTexCoord2(0, 1354f, 1185f);
			GL.Vertex3(549f, 111f, 389f);
			GL.End();
			GL.PopMatrix();
		}

		private void OnRenderImage(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 0.5f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * ((float)Math.PI / 180f)) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * ((float)Math.PI / 180f));
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(0, vector3);
			identity.SetRow(1, vector4);
			identity.SetRow(2, vector5);
			identity.SetRow(3, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 0f)) ? 0f : 1f);
			MCNEGCBDJAJ.SetMatrix("_FrustumCornersWS", identity);
			MCNEGCBDJAJ.SetVector("_CameraWS", position);
			MCNEGCBDJAJ.SetVector("_HeightParams", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 0.5f));
			MCNEGCBDJAJ.SetVector("_DistanceParams", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 0f), 0f, 0f, 0f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == FogMode.Linear;
			float num4 = ((!flag) ? 0f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 0.0001f)) ? 0f : (1f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 1.2011224f;
			value.y = hOCADCCOKBH * 1.442695f;
			value.z = ((!flag) ? 0f : (0f - num5));
			value.w = ((!flag) ? 0f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("_SceneFogParams", value);
			MCNEGCBDJAJ.SetVector("_SceneFogMode", new Vector4((float)hJINPFPEOEH, LFDAOGMOIPK ? 1 : 0, 0f, 0f));
			MCNEGCBDJAJ.SetVector("_FogColor", LADMOMJBEII);
			int num6 = 0;
			DOPBJCMCFJI(DNIDIBPDLII: (!LGKHCDAELJI || !NFJAJFKAOBK) ? (LGKHCDAELJI ? 1 : 2) : 0, AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		private static void NCOMLKEIFIH(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("Clicked buy on ", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(1);
			GL.MultiTexCoord2(1, 1657f, 944f);
			GL.Vertex3(1228f, 1038f, 182f);
			GL.MultiTexCoord2(0, 691f, 1968f);
			GL.Vertex3(1637f, 1974f, 729f);
			GL.MultiTexCoord2(1, 850f, 887f);
			GL.Vertex3(506f, 1078f, 779f);
			GL.MultiTexCoord2(0, 1623f, 735f);
			GL.Vertex3(492f, 683f, 220f);
			GL.End();
			GL.PopMatrix();
		}

		private void JFDCLPOJDHE(RenderTexture AEJJCMHDFBA, RenderTexture DANDPMBGFJC)
		{
			if (!CheckResources() || (!LGKHCDAELJI && !NFJAJFKAOBK))
			{
				Graphics.Blit(AEJJCMHDFBA, DANDPMBGFJC);
				return;
			}
			Camera component = GetComponent<Camera>();
			Transform transform = component.transform;
			float nearClipPlane = component.nearClipPlane;
			float farClipPlane = component.farClipPlane;
			float fieldOfView = component.fieldOfView;
			float aspect = component.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = fieldOfView * 1401f;
			Vector3 vector = transform.right * nearClipPlane * Mathf.Tan(num * 828f) * aspect;
			Vector3 vector2 = transform.up * nearClipPlane * Mathf.Tan(num * 50f);
			Vector3 vector3 = transform.forward * nearClipPlane - vector + vector2;
			float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = transform.forward * nearClipPlane + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = transform.forward * nearClipPlane + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = transform.forward * nearClipPlane - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(1, vector3);
			identity.SetRow(0, vector4);
			identity.SetRow(6, vector5);
			identity.SetRow(4, vector6);
			Vector3 position = transform.position;
			float num3 = position.y - FBMIFHHEOBO;
			float z = ((!(num3 <= 569f)) ? 1275f : 548f);
			MCNEGCBDJAJ.SetMatrix("DepositedCards", identity);
			MCNEGCBDJAJ.SetVector("Last weapon not choosen!!!!!", position);
			MCNEGCBDJAJ.SetVector("tc", new Vector4(FBMIFHHEOBO, num3, z, NNBDAJABIIC * 870f));
			MCNEGCBDJAJ.SetVector(", ", new Vector4(0f - Mathf.Max(LIJCAIJIDMD, 380f), 1850f, 977f, 491f));
			FogMode hJINPFPEOEH = HJINPFPEOEH;
			float hOCADCCOKBH = HOCADCCOKBH;
			float kIFAFIFHCNE = KIFAFIFHCNE;
			float eBJOMHODDJI = EBJOMHODDJI;
			bool flag = hJINPFPEOEH == (FogMode)0;
			float num4 = ((!flag) ? 693f : (eBJOMHODDJI - kIFAFIFHCNE));
			float num5 = ((!(Mathf.Abs(num4) > 1604f)) ? 1008f : (1166f / num4));
			Vector4 value = default(Vector4);
			value.x = hOCADCCOKBH * 86f;
			value.y = hOCADCCOKBH * 1158f;
			value.z = ((!flag) ? 126f : (0f - num5));
			value.w = ((!flag) ? 750f : (eBJOMHODDJI * num5));
			MCNEGCBDJAJ.SetVector("ID_READYTIME", value);
			MCNEGCBDJAJ.SetVector("SE", new Vector4((float)hJINPFPEOEH, (!LFDAOGMOIPK) ? 1 : 1, 1459f, 775f));
			MCNEGCBDJAJ.SetVector("{0} {1}", LADMOMJBEII);
			int num6 = 0;
			BFBHEFKHBOI(DNIDIBPDLII: (!LGKHCDAELJI || !NFJAJFKAOBK) ? (LGKHCDAELJI ? 1 : 6) : 0, AEJJCMHDFBA: AEJJCMHDFBA, DFPNKDKELEE: DANDPMBGFJC, BNNENCFGOKP: MCNEGCBDJAJ);
		}

		public virtual bool KLMBILDMPDJ()
		{
			FGHHBJGPNPI(true);
			MCNEGCBDJAJ = MBDJIELLEPG(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				MCKICFMNLLB();
			}
			return DGCKMHANOEF;
		}

		public virtual bool GBOIKOLDJHP()
		{
			EEMMIJACPKM(true);
			MCNEGCBDJAJ = ANOELOCCNHH(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				LFFPGDPKOLM();
			}
			return DGCKMHANOEF;
		}

		public virtual bool BBIKPJKHAAD()
		{
			FGHHBJGPNPI(false);
			MCNEGCBDJAJ = ANOELOCCNHH(CGCDJLKENGE, MCNEGCBDJAJ);
			if (!DGCKMHANOEF)
			{
				IAENECFMDDJ();
			}
			return DGCKMHANOEF;
		}

		private void CMDMNDCMBJO()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private static void OFJGMKJAHKF(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("VipStart", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(1);
			GL.MultiTexCoord2(1, 128f, 693f);
			GL.Vertex3(827f, 132f, 549f);
			GL.MultiTexCoord2(0, 20f, 466f);
			GL.Vertex3(1645f, 1819f, 980f);
			GL.MultiTexCoord2(1, 2f, 1358f);
			GL.Vertex3(1518f, 1479f, 466f);
			GL.MultiTexCoord2(1, 1462f, 931f);
			GL.Vertex3(1173f, 1722f, 296f);
			GL.End();
			GL.PopMatrix();
		}

		private void JCLABHIBIGK()
		{
			GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
		}

		private static void MGMGGLOCCKE(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("ID_CARDPACKDETAILS_DESCRIPTION", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(0);
			GL.MultiTexCoord2(0, 734f, 877f);
			GL.Vertex3(386f, 1397f, 46f);
			GL.MultiTexCoord2(0, 329f, 1514f);
			GL.Vertex3(1017f, 1384f, 127f);
			GL.MultiTexCoord2(1, 417f, 1222f);
			GL.Vertex3(1383f, 350f, 852f);
			GL.MultiTexCoord2(1, 1238f, 45f);
			GL.Vertex3(1172f, 1185f, 1157f);
			GL.End();
			GL.PopMatrix();
		}

		private static void NGINBFDMCMM(RenderTexture AEJJCMHDFBA, RenderTexture DFPNKDKELEE, Material BNNENCFGOKP, int DNIDIBPDLII)
		{
			RenderTexture.active = DFPNKDKELEE;
			BNNENCFGOKP.SetTexture("ID_INBRONZE2", AEJJCMHDFBA);
			GL.PushMatrix();
			GL.LoadOrtho();
			BNNENCFGOKP.SetPass(DNIDIBPDLII);
			GL.Begin(8);
			GL.MultiTexCoord2(1, 1685f, 1556f);
			GL.Vertex3(1369f, 1719f, 1714f);
			GL.MultiTexCoord2(1, 1489f, 1937f);
			GL.Vertex3(521f, 1618f, 171f);
			GL.MultiTexCoord2(1, 175f, 478f);
			GL.Vertex3(28f, 1917f, 311f);
			GL.MultiTexCoord2(1, 241f, 803f);
			GL.Vertex3(1213f, 1061f, 99f);
			GL.End();
			GL.PopMatrix();
		}
	}
}
