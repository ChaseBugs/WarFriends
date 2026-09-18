Shader "Unlit/Texture" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 100

	Pass {
		SetTexture [_MainTex] { combine texture }
	}
}
}
