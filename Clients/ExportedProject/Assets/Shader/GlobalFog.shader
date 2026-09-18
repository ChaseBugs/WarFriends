Shader "Hidden/GlobalFog" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "black" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

	Pass {
		ZTest Always Cull Off ZWrite Off
		Fog { Mode Off }

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile FOG_LINEAR FOG_EXP FOG_EXP2
		#pragma multi_compile __ HEIGHT_FOG

		#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
		uniform sampler2D_float _CameraDepthTexture;
		uniform half4 _CameraWorldPosition;
		uniform half4x4 _FrustumCornersWS;
		uniform half4 _FogColor;
		uniform half4 unity_FogParams;
		uniform half _HeightFogHeight;
		uniform half _HeightFogDensity;

		struct v2f {
			float4 pos : SV_POSITION;
			float2 uv : TEXCOORD0;
			float2 uv_depth : TEXCOORD1;
			float4 interpolatedRay : TEXCOORD2;
		};

		float4 _MainTex_TexelSize;

		v2f vert (appdata_img v)
		{
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord.xy;
			o.uv_depth = v.texcoord.xy;

			#if UNITY_UV_STARTS_AT_TOP
			if (_MainTex_TexelSize.y < 0)
				o.uv.y = 1 - o.uv.y;
			#endif

			int index = v.vertex.z >= 0 ? 0 : (v.texcoord.x < 0.5 ? (v.texcoord.y < 0.5 ? 1 : 2) : (v.texcoord.y < 0.5 ? 3 : 0));
			o.interpolatedRay = _FrustumCornersWS[index];
			o.interpolatedRay.w = index;

			return o;
		}

		half4 ComputeFog (float d)
		{
			half fog = 1.0;
			#if FOG_LINEAR
				fog = (unity_FogParams.z - d) * unity_FogParams.w;
			#elif FOG_EXP
				fog = unity_FogParams.y * d;
				fog = exp2(-fog);
			#else // FOG_EXP2
				fog = unity_FogParams.x * d;
				fog = exp2(-fog*fog);
			#endif
			return saturate(fog);
		}

		fixed4 frag (v2f i) : SV_Target
		{
			float dpth = Linear01Depth(UNITY_SAMPLE_DEPTH(tex2D(_CameraDepthTexture, i.uv_depth)));
			float4 wsDir = dpth * i.interpolatedRay;
			float4 wsPos = _CameraWorldPosition + wsDir;

			half4 sceneColor = tex2D(_MainTex, i.uv);

			float g = 1.0;
			#if HEIGHT_FOG
				float bottom = wsPos.y - 0;
				float top = _HeightFogHeight;
				g = _HeightFogDensity * saturate((top - wsPos.y) / max(top - bottom, 0.0001));
			#endif

			float dist = length(wsDir.xyz);
			half4 fogColor = ComputeFog(dist * g) * (1 - _FogColor) + _FogColor;
			return sceneColor * fogColor;
		}
		ENDCG
	}
}

Fallback Off
}
