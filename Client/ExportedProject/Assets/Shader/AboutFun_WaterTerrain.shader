Shader "AboutFun/WaterTerrain" {
	Properties {
		_Layer0 ("Layer 1 (R)", 2D) = "white" {}
		_Layer1 ("Layer 2 (B) (Screen Space)", 2D) = "gray" {}
		_Control ("Control (RGB)", 2D) = "white" {}
		_Water ("Water Texture (RGB)", 2D) = "white" {}
		_SpeedX ("Water SpeedX", Float) = 3
		_SpeedY ("Water SpeedY", Float) = 3
		_Scale ("Water Scale", Range(0.005, 0.2)) = 0.03
		_TileX ("Water TileX", Float) = 5
		_TileY ("Water TileY", Float) = 5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
			};

			struct Vertex_Stage_Output
			{
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return float4(1.0, 1.0, 1.0, 1.0); // RGBA
			}

			ENDHLSL
		}
	}
}