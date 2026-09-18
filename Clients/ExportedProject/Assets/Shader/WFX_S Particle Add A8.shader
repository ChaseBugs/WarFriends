Shader "WFX/Additive Alpha8" {
Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Particle Texture (alpha)", 2D) = "white" {}
	_InvFade ("Soft Particles Factor", Range(0.01,3)) = 1
}
Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha One
	ColorMask RGB
	Cull Off
	Lighting Off
	ZWrite Off

	SubShader {
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
	float2 texcoord : TEXCOORD0;
};

sampler2D _MainTex;
float4 _MainTex_ST;
fixed4 _TintColor;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.color = v.color;
	o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	fixed a = tex2D(_MainTex, i.texcoord).a;
	fixed4 col = 2.0f * i.color * _TintColor;
	col.a *= a;
	return col;
}
ENDCG
		}
	}
}
}
