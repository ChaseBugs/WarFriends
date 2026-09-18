Shader "MatCap/Bumped/Gold" {
Properties {
	_Gain ("Gain", Float) = 3.5
	_Offset ("Offset", Range(-1,1)) = 0.04
	_MainTex ("Diffuse (RGB)", 2D) = "white" {}
	_BumpMap ("Normal Map", 2D) = "bump" {}
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
	float4 tangent : TANGENT;
	float2 texcoord : TEXCOORD0;
};

struct v2f {
	float4 pos : SV_POSITION;
	float2 uvMain : TEXCOORD0;
	float3 tangentToView0 : TEXCOORD1;
	float3 tangentToView1 : TEXCOORD2;
	float3 tangentToView2 : TEXCOORD3;
};

sampler2D _MatCap;
sampler2D _GoldMatCap;
sampler2D _MainTex;
sampler2D _BumpMap;
float4 _MainTex_ST;
half _Gain;
half _Offset;
half _GoldGain;
half _GoldOffset;
fixed4 _GoldColor;

v2f vert (appdata v) {
	v2f o;
	o.pos = UnityObjectToClipPos(v.vertex);
	o.uvMain = TRANSFORM_TEX(v.texcoord, _MainTex);

	float3 worldNormal = UnityObjectToWorldNormal(v.normal);
	float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
	float3 worldBitangent = cross(worldNormal, worldTangent) * v.tangent.w;

	float3x3 viewRot = (float3x3)UNITY_MATRIX_V;
	float3 vN = mul(viewRot, worldNormal);
	float3 vT = mul(viewRot, worldTangent);
	float3 vB = mul(viewRot, worldBitangent);

	o.tangentToView0 = float3(vT.x, vB.x, vN.x);
	o.tangentToView1 = float3(vT.y, vB.y, vN.y);
	o.tangentToView2 = float3(vT.z, vB.z, vN.z);
	return o;
}

fixed4 frag (v2f i) : SV_Target {
	fixed4 tex = tex2D(_MainTex, i.uvMain);
	fixed3 tangentNormal = UnpackNormal(tex2D(_BumpMap, i.uvMain));

	float3 viewNormal;
	viewNormal.x = dot(i.tangentToView0, tangentNormal);
	viewNormal.y = dot(i.tangentToView1, tangentNormal);
	viewNormal.z = dot(i.tangentToView2, tangentNormal);
	viewNormal = normalize(viewNormal);

	float2 uv = viewNormal.xy * 0.5 + 0.5;

	fixed3 baseMat = tex2D(_MatCap, uv).rgb * _Gain + _Offset;
	fixed3 goldMat = tex2D(_GoldMatCap, uv).rgb * _GoldColor.rgb * _GoldGain + _GoldOffset;
	fixed3 col = saturate(tex.rgb * (baseMat + goldMat));
	return fixed4(col, tex.a);
}
ENDCG
	}
}
}
