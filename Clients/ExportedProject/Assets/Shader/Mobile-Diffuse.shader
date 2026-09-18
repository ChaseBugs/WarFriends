Shader "Mobile/Diffuse" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 150

	CGPROGRAM
	#pragma surface surf Lambert noforwardadd

	sampler2D _MainTex;

	struct Input {
		float2 uv_MainTex;
	};

	void surf (Input IN, inout SurfaceOutput o) {
		fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
		o.Albedo = tex.rgb;
		o.Alpha = tex.a;
	}
	ENDCG
}

Fallback "Mobile/VertexLit"
}
