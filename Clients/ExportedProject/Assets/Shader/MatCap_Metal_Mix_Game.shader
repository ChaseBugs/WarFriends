Shader "MatCap/Vertex/Metal Mix Game" {
Properties {
	_Gain ("Gain", Float) = 3.5
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_MetalMatCap ("Metal MatCap (RGB)", 2D) = "white" {}
	_DielectricMatCap ("Dielectric MatCap (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

	Pass {
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct appdata {
	float4 vertex : POSITION;
	float3 normal : NORMAL;
	float2 texcoord : TEXCOORD0;
};

struct v2f {
	float4 pos : SV_POSITION;
	float2 uv : TEXCOORD0;
	float2 uvMain : TEXCOORD1;
};

sampler2D _MetalMatCap;
sampler2D _DielectricMatCap;
sampler2D _MainTex;
float4 _MainTex_ST;
half _Gain;

v2f vert (appdata v) {
	v2f o;
	o.pos = UnityObjectToClipPos(v.vertex);
	float3 worldNorm = normalize(UnityObjectToWorldNormal(v.normal));
	float3 viewNorm = mul((float3x3)UNITY_MATRIX_V, worldNorm);
	o.uv = viewNorm.xy * 0.5 + 0.5;
	o.uvMain = TRANSFORM_TEX(v.texcoord, _MainTex);
	return o;
}

fixed4 frag (v2f i) : SV_Target {
	fixed4 tex = tex2D(_MainTex, i.uvMain);
	fixed3 metal = tex2D(_MetalMatCap, i.uv).rgb;
	fixed3 dielectric = tex2D(_DielectricMatCap, i.uv).rgb;
	fixed3 matcap = lerp(dielectric, metal, tex.a) * _Gain;
	return fixed4(saturate(tex.rgb * matcap), 1);
}
ENDCG
	}
}
}
