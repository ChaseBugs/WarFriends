Shader "AQUAS/Mobile/Single-Colored No Depth" {
Properties {
[NoScaleOffset]  _NormalTexture ("Normal Texture", 2D) = "white" { }
 _NormalTiling ("Normal Tiling", Float) = 1
 _DeepWaterColor ("Deep Water Color", Color) = (0.0431373,0.239216,0.462745,1)
 _DepthTransparency ("Depth Transparency", Float) = 1.5
 _ShoreFade ("Shore Fade", Float) = 0.3
[HideInInspector]  _ReflectionTex ("Reflection Tex", 2D) = "white" { }
[MaterialToggle]  _UseReflections ("Enable Reflections", Float) = 0.521569
 _Distortion ("Distortion", Range(0,2)) = 0.3
 _Refraction ("Refraction", Range(0,1)) = 0.67
 _WaveSpeed ("Wave Speed", Float) = 40
 _EmissiveColor ("Emissive Color", Color) = (0.5,0.5,0.5,1)
 _EmissionIntensity ("Emission Intensity", Float) = 0
[HideInInspector]  _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
 _AmbientColor ("Ambient Color", Color) = (0.647,1,1,1)
}
	//DummyShaderTextExporter
	
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Lambert
#pragma target 3.0
		sampler2D _MainTex;
		struct Input
		{
			float2 uv_MainTex;
		};
		void surf(Input IN, inout SurfaceOutput o)
		{
			float4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
		}
		ENDCG
	}
}