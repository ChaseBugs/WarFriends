Shader "atsVegetation Unlit-Lightmap-Wind Opaque" {
Properties {
	_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
	_SecondaryFactor ("Factor for up and fown bending", Float) = 2.5
}

SubShader {
	Tags { "Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout" }
	LOD 200
	Cull Off

	Pass {
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct appdata_t {
	float4 vertex : POSITION;
	fixed4 color : COLOR;
	float2 texcoord : TEXCOORD0;
	float2 texcoord1 : TEXCOORD1;
};

struct v2f {
	float4 vertex : SV_POSITION;
	fixed4 color : COLOR;
	float2 texcoord : TEXCOORD0;
	float2 lmap : TEXCOORD1;
};

sampler2D _MainTex;
float4 _MainTex_ST;
fixed _Cutoff;
half _SecondaryFactor;

v2f vert (appdata_t v)
{
	v2f o;
	float wind = sin(_Time.y * _SecondaryFactor + v.vertex.x + v.vertex.z) * v.color.a * v.vertex.y;
	v.vertex.x += wind * 0.05;
	v.vertex.z += wind * 0.03;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.color = v.color;
	o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
	o.lmap = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	fixed4 col = tex2D(_MainTex, i.texcoord) * i.color;
	clip(col.a - _Cutoff);
	fixed3 lm = DecodeLightmap(UNITY_SAMPLE_TEX2D(unity_Lightmap, i.lmap));
	col.rgb *= lm;
	return col;
}
ENDCG
	}
}
}
