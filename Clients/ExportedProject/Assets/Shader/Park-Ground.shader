Shader "Mobile/Park Ground" {
Properties {
 _Layer0 ("Layer 1 (R)", 2D) = "white" { }
 _Layer1 ("Layer 2 (B) (Screen Space)", 2D) = "gray" { }
 _Control ("Control (RGB)", 2D) = "white" { }
 _Water ("Water Texture (RGB)", 2D) = "white" { }
 _SpeedX ("Water SpeedX", Float) = 3
 _SpeedY ("Water SpeedY", Float) = 3
 _Scale ("Water Scale", Range(0.005,0.2)) = 0.03
 _TileX ("Water TileX", Float) = 5
 _TileY ("Water TileY", Float) = 5
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