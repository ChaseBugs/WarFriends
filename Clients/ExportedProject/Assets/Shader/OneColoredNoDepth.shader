Shader "AQUAS/Mobile/Single-Colored No Depth" {
Properties {
	[NoScaleOffset] _NormalTexture ("Normal Texture", 2D) = "white" {}
	_NormalTiling ("Normal Tiling", Float) = 1
	_DeepWaterColor ("Deep Water Color", Color) = (0.0431373,0.239216,0.462745,1)
	_DepthTransparency ("Depth Transparency", Float) = 1.5
	_ShoreFade ("Shore Fade", Float) = 0.3
	[HideInInspector] _ReflectionTex ("Reflection Tex", 2D) = "white" {}
	[MaterialToggle] _UseReflections ("Enable Reflections", Float) = 0.521569
	_Distortion ("Distortion", Range(0,2)) = 0.3
	_Refraction ("Refraction", Range(0,1)) = 0.67
	_WaveSpeed ("Wave Speed", Float) = 40
	_EmissiveColor ("Emissive Color", Color) = (0.5,0.5,0.5,1)
	_EmissionIntensity ("Emission Intensity", Float) = 0
	[HideInInspector] _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
half _Refraction;
half _WaveSpeed;
half _UseReflections;
fixed4 _DeepWaterColor;
fixed4 _EmissiveColor;
half _EmissionIntensity;
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

	fixed3 col = _DeepWaterColor.rgb * _AmbientColor.rgb;

	if (_UseReflections > 0.5)
	{
		float2 screenUv = i.screenPos.xy / i.screenPos.w + normal.xy * _Distortion * 0.05;
		fixed3 refl = tex2D(_ReflectionTex, screenUv).rgb;
		col = lerp(col, refl, _Refraction);
	}

	col += _EmissiveColor.rgb * _EmissionIntensity;
	return fixed4(col, _DeepWaterColor.a);
}
ENDCG
	}
}
}
