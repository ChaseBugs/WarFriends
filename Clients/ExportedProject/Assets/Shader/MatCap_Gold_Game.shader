Shader "MatCap/Vertex/Gold Game" {
Properties {
	_Gain ("Gain", Float) = 3.5
	_Offset ("Offset", Range(-1,1)) = 0.04
	_MainTex ("Diffuse (RGB)", 2D) = "white" {}
	_MatCap ("MatCap (RGB)", 2D) = "white" {}
	_GoldMatCap ("Gold MatCap (RGB)", 2D) = "white" {}
	_GoldColor ("Gold Color", Color) = (0.95,0.7,0.1,1)
	_GoldGain ("Gold Gain", Float) = 1
	_GoldOffset ("Gold Offset", Range(-1,1)) = 0
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

sampler2D _MatCap;
sampler2D _GoldMatCap;
sampler2D _MainTex;
float4 _MainTex_ST;
half _Gain;
half _Offset;
half _GoldGain;
half _GoldOffset;
fixed4 _GoldColor;

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
	fixed3 baseMat = tex2D(_MatCap, i.uv).rgb * _Gain + _Offset;
	fixed3 goldMat = tex2D(_GoldMatCap, i.uv).rgb * _GoldColor.rgb * _GoldGain + _GoldOffset;
	fixed3 col = saturate(tex.rgb * (baseMat + goldMat));
	return fixed4(col, tex.a);
}
ENDCG
	}
}
}
