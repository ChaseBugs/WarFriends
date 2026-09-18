Shader "MatCap/Vertex/Textured Mix" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_MainMask ("Mix (Alpha)", 2D) = "white" {}
	_MatCapA ("MatCap Layer A (RGB)", 2D) = "white" {}
	_MatCapB ("MatCap Layer B (RGB)", 2D) = "white" {}
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

sampler2D _MatCapA;
sampler2D _MatCapB;
sampler2D _MainTex;
sampler2D _MainMask;
float4 _MainTex_ST;

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
	fixed3 matcapA = tex2D(_MatCapA, i.uv).rgb;
	fixed3 matcapB = tex2D(_MatCapB, i.uv).rgb;
	fixed4 tex = tex2D(_MainTex, i.uvMain);
	fixed mask = tex2D(_MainMask, i.uvMain).a;
	fixed3 matcap = lerp(matcapA, matcapB, mask);
	return fixed4(matcap * tex.rgb * 2, 1);
}
ENDCG
	}
}
}
