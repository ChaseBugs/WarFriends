Shader "atsVegetation Unlit-Wind" {
Properties {
	_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
	_Gain ("Gain", Float) = 1
	_SecondaryFactor ("Factor for up and fown bending", Float) = 2.5
}

SubShader {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	LOD 200
	Cull Off
	ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha

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
	float2 texcoord : TEXCOORD0;
};

sampler2D _MainTex;
float4 _MainTex_ST;
half _Gain;
half _SecondaryFactor;

v2f vert (appdata_t v)
{
	v2f o;
	float wind = sin(_Time.y * _SecondaryFactor + v.vertex.x + v.vertex.z) * _Gain * v.color.a * v.vertex.y;
	v.vertex.x += wind * 0.05;
	v.vertex.z += wind * 0.03;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	// Match the recovered plants material's transparent queue (3000).
	// Its legacy _Cutoff=1 would discard filtered foliage if used as a cutout.
	// Vertex color is reserved for wind weights in this uncolored variant.
	fixed4 col = tex2D(_MainTex, i.texcoord);
	return col;
}
ENDCG
	}
}
}
