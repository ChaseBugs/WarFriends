Shader "WFX/Scroll/Alpha Blended" {
Properties {
	_MainTex ("Looped Texture + Alpha Mask", 2D) = "white" {}
	_InvFade ("Soft Particles Factor", Range(0.01,3)) = 1
	_ScrollSpeed ("Scroll Speed", Float) = 2
}
Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha OneMinusSrcAlpha
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
float _ScrollSpeed;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.color = v.color;
	o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
	o.texcoord.x += _Time.y * _ScrollSpeed;
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	fixed4 col = tex2D(_MainTex, i.texcoord) * i.color;
	return col;
}
ENDCG
		}
	}
}
}
