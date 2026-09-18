Shader "GUI/Text Shader (SoftClip)" {

Properties {
	_MainTex ("Font Texture", 2D) = "white" {}
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
	float4 worldPos : TEXCOORD1;
};

sampler2D _MainTex;
float4 _MainTex_ST;
float4 _ClipRange0;
float2 _ClipArgs0;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.color = v.color;
	o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
	o.worldPos = mul(unity_ObjectToWorld, v.vertex);
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	fixed4 col = i.color;
	col.a *= tex2D(_MainTex, i.texcoord).a;
	half2 factor = (_ClipRange0.zw - abs(i.worldPos.xy - _ClipRange0.xy)) * _ClipArgs0.xy;
	factor = saturate(factor);
	col.a *= factor.x * factor.y;
	return col;
}
ENDCG
	}
}
}
