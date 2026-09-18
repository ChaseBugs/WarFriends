Shader "Mobile/Particles/Alpha Blended" {
Properties {
	_MainTex ("Particle Texture", 2D) = "white" {}
}
Category {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha OneMinusSrcAlpha
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
