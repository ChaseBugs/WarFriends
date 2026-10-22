Shader "Unlit/GuiEffectShader" {
Properties {
	_MainTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
	_EffectTex ("Base (RGB), Alpha (A)", 2D) = "white" {}
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
	float2 effectCoord : TEXCOORD1;
};

struct v2f {
	float4 vertex : SV_POSITION;
	fixed4 color : COLOR;
	half2 texcoord : TEXCOORD0;
	float2 effectCoord : TEXCOORD1;
};

sampler2D _MainTex;
sampler2D _EffectTex;
float4 _MainTex_ST;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.color = v.color;
	o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
	// UIReflectionEffect supplies the animated shine sweep in the second UV channel.
	o.effectCoord = v.effectCoord;
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	fixed4 baseCol = tex2D(_MainTex, i.texcoord);
	fixed4 effect = tex2D(_EffectTex, i.effectCoord);
	// Both masks participate: outside the sweep the overlay must be transparent.
	return baseCol * effect * i.color;
}
ENDCG
	}
}
}
