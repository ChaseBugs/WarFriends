Shader "MatCap/Bumped/Metal Mix" {
Properties {
 _Gain ("Gain", Float) = 3.5
 _MainTex ("Base (RGB)", 2D) = "white" { }
 _BumpMap ("Normal Map", 2D) = "bump" { }
 _MetalMatCap ("Metal MatCap (RGB)", 2D) = "white" { }
 _DielectricMatCap ("Dielectric MatCap (RGB)", 2D) = "white" { }
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