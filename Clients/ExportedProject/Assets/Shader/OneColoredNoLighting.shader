Shader "AQUAS/Mobile/Single-Colored No Lighting" {
Properties {
[NoScaleOffset]  _NormalTexture ("Normal Texture", 2D) = "white" { }
 _NormalTiling ("Normal Tiling", Float) = 1
 _DepthTransparency ("Depth Transparency", Float) = 1.5
 _ShoreFade ("Shore Fade", Float) = 0.3
 _ShoreTransparency ("Shore Transparency", Float) = 0
[HideInInspector]  _ReflectionTex ("Reflection Tex", 2D) = "white" { }
 _Distortion ("Distortion", Range(0,2)) = 0.3
 _WaveSpeed ("Wave Speed", Float) = 40
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