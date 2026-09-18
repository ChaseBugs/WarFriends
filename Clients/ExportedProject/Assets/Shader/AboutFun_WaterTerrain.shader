Shader "AboutFun/WaterTerrain" {
Properties {
	_Layer0 ("Layer 1 (R)", 2D) = "white" {}
	_Layer1 ("Layer 2 (B) (Screen Space)", 2D) = "gray" {}
	_Control ("Control (RGB)", 2D) = "white" {}
	_Water ("Water Texture (RGB)", 2D) = "white" {}
	_SpeedX ("Water SpeedX", Float) = 3
	_SpeedY ("Water SpeedY", Float) = 3
	_Scale ("Water Scale", Range(0.005,0.2)) = 0.03
	_TileX ("Water TileX", Float) = 5
	_TileY ("Water TileY", Float) = 5
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

CGPROGRAM
#pragma surface surf Lambert noforwardadd

sampler2D _Layer0;
sampler2D _Layer1;
sampler2D _Control;
sampler2D _Water;
half _SpeedX;
half _SpeedY;
half _Scale;
half _TileX;
half _TileY;

struct Input {
	float2 uv_Control;
	float2 uv_Layer0;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed3 control = tex2D(_Control, IN.uv_Control).rgb;
	fixed3 land = tex2D(_Layer0, IN.uv_Layer0 * _TileX).rgb;

	float2 waterUv = IN.uv_Control * _TileY * _Scale * 10 + float2(_Time.y * _SpeedX, _Time.y * _SpeedY) * 0.05;
	fixed3 water = tex2D(_Water, waterUv).rgb;

	fixed3 col = lerp(land, water, control.b);
	o.Albedo = col;
	o.Alpha = 1;
}
ENDCG
}

Fallback "Diffuse"
}
