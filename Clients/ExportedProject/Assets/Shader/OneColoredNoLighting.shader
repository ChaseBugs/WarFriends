Shader "AQUAS/Mobile/Single-Colored No Lighting" {
Properties {
	[NoScaleOffset] _NormalTexture ("Normal Texture", 2D) = "white" {}
	_NormalTiling ("Normal Tiling", Float) = 1
	_DepthTransparency ("Depth Transparency", Float) = 1.5
	_ShoreFade ("Shore Fade", Float) = 0.3
	_ShoreTransparency ("Shore Transparency", Float) = 0
	[HideInInspector] _ReflectionTex ("Reflection Tex", 2D) = "white" {}
	_Distortion ("Distortion", Range(0,2)) = 0.3
	_WaveSpeed ("Wave Speed", Float) = 40
	_AmbientColor ("Ambient Color", Color) = (0.647,1,1,1)
}

SubShader {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	LOD 200
	ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha

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
	float2 texcoord : TEXCOORD0;
	float4 screenPos : TEXCOORD1;
};

sampler2D _NormalTexture;
sampler2D _ReflectionTex;
half _NormalTiling;
half _Distortion;
half _WaveSpeed;
half _DepthTransparency;
half _ShoreFade;
half _ShoreTransparency;
fixed4 _AmbientColor;

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	o.texcoord = v.texcoord * _NormalTiling;
	o.screenPos = ComputeScreenPos(o.vertex);
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	float2 scroll = float2(_Time.y * _WaveSpeed * 0.01, _Time.y * _WaveSpeed * 0.007);
	fixed3 normal = UnpackNormal(tex2D(_NormalTexture, i.texcoord + scroll));

	float2 screenUv = i.screenPos.xy / i.screenPos.w + normal.xy * _Distortion * 0.05;
	fixed3 refl = tex2D(_ReflectionTex, screenUv).rgb;

	fixed3 col = lerp(_AmbientColor.rgb, refl, 0.5);
	return fixed4(col, saturate(_AmbientColor.a + _ShoreTransparency));
}
ENDCG
	}
}
}
