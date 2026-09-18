Shader "Unlit/Depth" {

SubShader {
	Tags { "RenderType"="Opaque" "Queue"="Geometry-1" }
	Lighting Off
	Cull Off
	ZWrite On
	ColorMask 0

	Pass {
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

struct appdata_t {
	float4 vertex : POSITION;
};

struct v2f {
	float4 vertex : SV_POSITION;
};

v2f vert (appdata_t v)
{
	v2f o;
	o.vertex = UnityObjectToClipPos(v.vertex);
	return o;
}

fixed4 frag (v2f i) : SV_Target
{
	return fixed4(0,0,0,0);
}
ENDCG
	}
}
}
