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
#pragma surface surf Lambert noforwardadd vertex:vert

sampler2D _Control;
sampler2D _Splat0;
sampler2D _Splat1;
sampler2D _Splat2;
sampler2D _Splat3;
float4 _Control_ST;
float4 _Splat0_ST;
float4 _Splat1_ST;
float4 _Splat2_ST;
float4 _Splat3_ST;

struct Input {
	float2 splatUv;
};

void vert (inout appdata_full v, out Input o) {
	UNITY_INITIALIZE_OUTPUT(Input, o);
	// All five maps share UV0. Transform in the fragment shader to avoid
	// exceeding the mobile ForwardBase interpolator limit (11 out of 10).
	o.splatUv = v.texcoord.xy;
}

void surf (Input IN, inout SurfaceOutput o) {
	float2 uv = IN.splatUv;
	fixed4 splatControl = tex2D(_Control, uv * _Control_ST.xy + _Control_ST.zw);
	fixed3 col = fixed3(0,0,0);
	col += splatControl.r * tex2D(_Splat0, uv * _Splat0_ST.xy + _Splat0_ST.zw).rgb;
	col += splatControl.g * tex2D(_Splat1, uv * _Splat1_ST.xy + _Splat1_ST.zw).rgb;
	col += splatControl.b * tex2D(_Splat2, uv * _Splat2_ST.xy + _Splat2_ST.zw).rgb;
	col += splatControl.a * tex2D(_Splat3, uv * _Splat3_ST.xy + _Splat3_ST.zw).rgb;
	o.Albedo = col;
	o.Alpha = 1;
}
ENDCG
}

Fallback "Diffuse"
}
