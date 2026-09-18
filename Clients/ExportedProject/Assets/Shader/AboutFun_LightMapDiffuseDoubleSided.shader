Shader "AboutFun/LightMapDiffuseDoubleSided" {
Properties {
	_MainTex ("Texture 1", 2D) = "white" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	Cull Off
	LOD 200

CGPROGRAM
#pragma surface surf Lambert noforwardadd

sampler2D _MainTex;

struct Input {
	float2 uv_MainTex;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG
}

Fallback "Diffuse"
}
