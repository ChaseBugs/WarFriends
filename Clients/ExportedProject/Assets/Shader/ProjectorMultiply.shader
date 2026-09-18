Shader "Projector/Multiply" {
	Properties {
		_ShadowTex ("Cookie", 2D) = "gray" {}
		_FalloffTex ("FallOff", 2D) = "white" {}
	}
	Subshader {
		Tags {"Queue"="Transparent-1"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend DstColor Zero
			Offset -1, -1

			SetTexture [_ShadowTex] {
				combine texture, texture alpha
			}
			SetTexture [_FalloffTex] {
				combine previous lerp (previous) constant
				ConstantColor (1,1,1,1)
			}
		}
	}
}
