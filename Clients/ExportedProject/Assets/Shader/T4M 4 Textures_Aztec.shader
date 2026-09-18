Shader "T4MShaders/ShaderModel2/Diffuse/T4M 4 Textures Aztec" {
Properties {
	_Splat0 ("Layer 1", 2D) = "white" {}
	_Splat1 ("Layer 2", 2D) = "white" {}
	_Splat2 ("Layer 3", 2D) = "white" {}
	_Splat3 ("Layer 4", 2D) = "white" {}
	_Control ("Control (RGBA)", 2D) = "white" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

CGPROGRAM
#pragma surface surf Lambert noforwardadd

sampler2D _Control;
sampler2D _Splat0;
sampler2D _Splat1;
sampler2D _Splat2;
sampler2D _Splat3;

struct Input {
	float2 uv_Control;
	float2 uv_Splat0;
	float2 uv_Splat1;
	float2 uv_Splat2;
	float2 uv_Splat3;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 splatControl = tex2D(_Control, IN.uv_Control);
	fixed3 col = fixed3(0,0,0);
	col += splatControl.r * tex2D(_Splat0, IN.uv_Splat0).rgb;
	col += splatControl.g * tex2D(_Splat1, IN.uv_Splat1).rgb;
	col += splatControl.b * tex2D(_Splat2, IN.uv_Splat2).rgb;
	col += splatControl.a * tex2D(_Splat3, IN.uv_Splat3).rgb;
	o.Albedo = col;
	o.Alpha = 1;
}
ENDCG
}

Fallback "Diffuse"
}
