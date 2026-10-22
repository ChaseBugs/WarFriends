Shader "Unlit/Transparent Colored (Packed) (AlphaClip)" {

Properties {
	_MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
}

SubShader {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Lighting Off
	Cull Off
	ZWrite Off
	Fog { Mode Off }
	Blend SrcAlpha OneMinusSrcAlpha
	ColorMask RGBA

	Pass {
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct appdata_t {
	float4 vertex : POSITION;
	fixed4 color : COLOR;
	float2 texcoord : TEXCOORD0;
};

struct v2f {
	float4 vertex : SV_POSITION;
	fixed4 color : COLOR;
	half2 texcoord : TEXCOORD0;
	float2 clipPosition : TEXCOORD1;
};

sampler2D _MainTex;
float4 _MainTex_ST;
// UIDrawCall stores panel-local clipping in _MainTex_ST, not atlas UVs.

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.color = v.color;
	o.texcoord = v.texcoord;
	o.clipPosition = v.vertex.xy * _MainTex_ST.xy + _MainTex_ST.zw;
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	fixed4 col = tex2D(_MainTex, i.texcoord) * i.color;
	float2 factor = abs(i.clipPosition) - 1.0;
	clip(-max(factor.x, factor.y));
	return col;
}
ENDCG
	}
}
}
