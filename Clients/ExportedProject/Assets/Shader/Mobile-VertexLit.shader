Shader "Mobile/VertexLit" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 100

	Material {
		Diffuse (1,1,1,1)
		Ambient (1,1,1,1)
	}
	Lighting On

	Pass {
		SetTexture [_MainTex] {
			combine texture * primary DOUBLE
		}
	}
}
}
