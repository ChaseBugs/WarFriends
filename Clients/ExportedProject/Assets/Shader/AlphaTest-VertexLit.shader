Shader "Legacy Shaders/Transparent/Cutout/VertexLit" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Spec Color", Color) = (1,1,1,0)
	_Emission ("Emissive Color", Color) = (0,0,0,0)
	_Shininess ("Shininess", Range(0.1,1)) = 0.7
	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}

SubShader {
	Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
	LOD 100

	Material {
		Diffuse [_Color]
		Ambient [_Color]
		Shininess [_Shininess]
		Specular [_SpecColor]
		Emission [_Emission]
	}
	Lighting On
	SeparateSpecular On
	AlphaTest Greater [_Cutoff]

	Pass {
		SetTexture [_MainTex] {
			combine texture * primary DOUBLE, texture * primary
		}
	}
}
}
