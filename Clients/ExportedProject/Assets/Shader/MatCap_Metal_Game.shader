Shader "MatCap/Vertex/Metal Game" {
Properties {
	_Gain ("Gain", Float) = 3.5
	_Offset ("Offset", Range(-1,1)) = 0.04
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_MatCap ("MatCap (RGB)", 2D) = "white" {}
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
sampler2D _MainTex;
float4 _MainTex_ST;
half _Gain;
half _Offset;

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
	fixed3 matcap = tex2D(_MatCap, i.uv).rgb;
	fixed4 tex = tex2D(_MainTex, i.uvMain);
	fixed3 col = saturate(tex.rgb * (matcap * _Gain + _Offset));
	return fixed4(col, tex.a);
}
ENDCG
	}
}
}
