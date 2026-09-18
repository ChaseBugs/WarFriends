Shader "WFX/Scroll/Smoke" {
Properties {
	_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
	_MainTex ("Texture", 2D) = "white" {}
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
fixed4 _TintColor;
float _ScrollSpeed;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.color = v.color;
	o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
	o.texcoord.y += _Time.y * _ScrollSpeed;
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	fixed4 col = tex2D(_MainTex, i.texcoord) * i.color * _TintColor * 2.0f;
	return col;
}
ENDCG
		}
	}
}
}
