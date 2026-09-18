Shader "Standard" {
Properties {
	_Color ("Color", Color) = (1,1,1,1)
	_MainTex ("Albedo", 2D) = "white" {}

	_Cutoff ("Alpha Cutoff", Range(0,1)) = 0.5

	_Glossiness ("Smoothness", Range(0,1)) = 0.5
	[Gamma] _Metallic ("Metallic", Range(0,1)) = 0
	_MetallicGlossMap ("Metallic", 2D) = "white" {}

	_BumpScale ("Scale", Float) = 1
	_BumpMap ("Normal Map", 2D) = "bump" {}

	_Parallax ("Height Scale", Range(0.005,0.08)) = 0.02
	_ParallaxMap ("Height Map", 2D) = "black" {}

	_OcclusionStrength ("Strength", Range(0,1)) = 1
	_OcclusionMap ("Occlusion", 2D) = "white" {}

	_EmissionColor ("Color", Color) = (0,0,0,1)
	_EmissionMap ("Emission", 2D) = "white" {}

	_DetailMask ("Detail Mask", 2D) = "white" {}
	_DetailAlbedoMap ("Detail Albedo x2", 2D) = "grey" {}
	_DetailNormalMapScale ("Scale", Float) = 1
	_DetailNormalMap ("Normal Map", 2D) = "bump" {}

	[Enum(UV0,0,UV1,1)] _UVSec ("UV Set for secondary textures", Float) = 0

	[HideInInspector] _Mode ("__mode", Float) = 0
	[HideInInspector] _SrcBlend ("__src", Float) = 1
	[HideInInspector] _DstBlend ("__dst", Float) = 0
	[HideInInspector] _ZWrite ("__zw", Float) = 1
}

SubShader {
	Tags { "RenderType"="Opaque" "PerformanceChecks"="False" }
	LOD 300

	CGPROGRAM
	#pragma surface surf Standard fullforwardshadows vertex:vert
	#pragma target 3.0

	sampler2D _MainTex;
	sampler2D _BumpMap;
	sampler2D _MetallicGlossMap;
	sampler2D _OcclusionMap;
	sampler2D _EmissionMap;
	sampler2D _DetailMask;
	sampler2D _DetailAlbedoMap;
	sampler2D _DetailNormalMap;

	struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
		float2 uv2_DetailAlbedoMap;
		float2 uv2_DetailNormalMap;
	};

	half _Glossiness;
	half _Metallic;
	half _BumpScale;
	half _OcclusionStrength;
	half _DetailNormalMapScale;
	fixed4 _Color;
	fixed4 _EmissionColor;
	fixed _Cutoff;

	void vert (inout appdata_full v, out Input o) {
		UNITY_INITIALIZE_OUTPUT(Input, o);
	}

	void surf (Input IN, inout SurfaceOutputStandard o) {
		fixed4 albedo = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		fixed4 detailAlbedo = tex2D(_DetailAlbedoMap, IN.uv2_DetailAlbedoMap);
		fixed detailMask = tex2D(_DetailMask, IN.uv_MainTex).a;
		albedo.rgb = lerp(albedo.rgb, albedo.rgb * detailAlbedo.rgb * unity_ColorSpaceDouble.rgb, detailMask);

		o.Albedo = albedo.rgb;
		o.Alpha = albedo.a;

		fixed4 metallicGloss = tex2D(_MetallicGlossMap, IN.uv_MainTex);
		o.Metallic = metallicGloss.r * _Metallic;
		o.Smoothness = metallicGloss.a * _Glossiness;

		fixed occlusion = tex2D(_OcclusionMap, IN.uv_MainTex).g;
		o.Occlusion = lerp(1, occlusion, _OcclusionStrength);

		o.Emission = tex2D(_EmissionMap, IN.uv_MainTex).rgb * _EmissionColor.rgb;

		fixed3 normal = UnpackScaleNormal(tex2D(_BumpMap, IN.uv_BumpMap), _BumpScale);
		fixed3 detailNormal = UnpackScaleNormal(tex2D(_DetailNormalMap, IN.uv2_DetailNormalMap), _DetailNormalMapScale);
		o.Normal = normalize(fixed3(normal.xy + detailNormal.xy, normal.z * detailNormal.z));

		clip(albedo.a - _Cutoff);
	}
	ENDCG
}

FallBack "VertexLit"
}
