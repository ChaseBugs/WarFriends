Shader "Cartoon FX/Mobile Particles Additive Alpha8" {
Properties {
	_MainTex ("Particle Texture (Alpha8)", 2D) = "white" {}
}
Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha One
	ColorMask RGB
	Cull Off
	Lighting Off
	ZWrite Off

	SubShader {
		Pass {
			SetTexture [_MainTex] {
				combine texture * primary
			}
		}
	}
}
}
