Shader "MatCap/Vertex/Gold Game" {
Properties {
 _Gain ("Gain", Float) = 3.5
 _Offset ("Offset", Range(-1,1)) = 0.04
 _MainTex ("Diffuse (RGB)", 2D) = "white" { }
 _MatCap ("MatCap (RGB)", 2D) = "white" { }
 _GoldMatCap ("Gold MatCap (RGB)", 2D) = "white" { }
 _GoldColor ("Gold Color", Color) = (0.95,0.7,0.1,1)
 _GoldGain ("Gold Gain", Float) = 1
 _GoldOffset ("Gold Offset", Range(-1,1)) = 0
 _GoldSaturation ("Gold Saturation", Range(0,1)) = 1
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