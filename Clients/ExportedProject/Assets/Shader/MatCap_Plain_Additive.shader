Shader "MatCap/Vertex/Plain Additive" {
Properties {
	_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
	_MatCap ("MatCap (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	LOD 200
	ZWrite Off
	Blend One One

	Pass {
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct appdata {
	float4 vertex : POSITION;
	float3 normal : NORMAL;
};

struct v2f {
	float4 pos : SV_POSITION;
	float2 uv : TEXCOORD0;
};

sampler2D _MatCap;
fixed4 _Color;

v2f vert (appdata v) {
	v2f o;
	o.pos = UnityObjectToClipPos(v.vertex);
	float3 worldNorm = normalize(UnityObjectToWorldNormal(v.normal));
	float3 viewNorm = mul((float3x3)UNITY_MATRIX_V, worldNorm);
	o.uv = viewNorm.xy * 0.5 + 0.5;
	return o;
}

fixed4 frag (v2f i) : SV_Target {
	fixed3 matcap = tex2D(_MatCap, i.uv).rgb;
	return fixed4(matcap * _Color.rgb * 2, 1);
}
ENDCG
	}
}
}
