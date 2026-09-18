Shader "MatCap/Bumped/Metal Mix" {
Properties {
	_Gain ("Gain", Float) = 3.5
	_MainTex ("Base (RGB)", 2D) = "white" {}
	_BumpMap ("Normal Map", 2D) = "bump" {}
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

sampler2D _MetalMatCap;
sampler2D _DielectricMatCap;
sampler2D _MainTex;
sampler2D _BumpMap;
float4 _MainTex_ST;
half _Gain;

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

	fixed3 metal = tex2D(_MetalMatCap, uv).rgb;
	fixed3 dielectric = tex2D(_DielectricMatCap, uv).rgb;
	fixed3 matcap = lerp(dielectric, metal, tex.a) * _Gain;
	return fixed4(saturate(tex.rgb * matcap), 1);
}
ENDCG
	}
}
}
