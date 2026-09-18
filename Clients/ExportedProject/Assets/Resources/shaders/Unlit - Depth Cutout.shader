Shader "Unlit/Depth Cutout" {

Properties {
	_MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
}

SubShader {
	Tags { "RenderType"="Opaque" "Queue"="Geometry-1" }
	Lighting Off
	Cull Off
	ZWrite On
	ColorMask 0

	Pass {
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct appdata_t {
	float4 vertex : POSITION;
	float2 texcoord : TEXCOORD0;
};

struct v2f {
	float4 vertex : SV_POSITION;
	half2 texcoord : TEXCOORD0;
};

sampler2D _MainTex;
float4 _MainTex_ST;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	fixed4 tex = tex2D(_MainTex, i.texcoord);
	clip(tex.a - 0.5);
	return fixed4(0,0,0,0);
}
ENDCG
	}
}
}
