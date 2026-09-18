Shader "Skybox/Procedural" {
Properties {
	[KeywordEnum(None, Simple, High Quality)] _SunDisk ("Sun", Float) = 2
	_SunSize ("Sun Size", Range(0,1)) = 0.04
	_SunSizeConvergence("Sun Size Convergence", Range(1,10)) = 5
	_AtmosphereThickness ("Atmoshpere Thickness", Range(0,5)) = 1
	_SkyTint ("Sky Tint", Color) = (0.5,0.5,0.5,1)
	_GroundColor ("Ground", Color) = (0.369,0.349,0.341,1)
	_Exposure ("Exposure", Range(0,8)) = 1.3
}

SubShader {
	Tags { "Queue"="Background" "RenderType"="Background" "PreviewType"="Skybox" }
	Cull Off ZWrite Off

	Pass {

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma multi_compile _SUNDISK_NONE _SUNDISK_SIMPLE _SUNDISK_HIGH_QUALITY

		#include "UnityCG.cginc"

		uniform half _SunSize;
		uniform half _SunSizeConvergence;
		uniform half _AtmosphereThickness;
		uniform half4 _SkyTint;
		uniform half4 _GroundColor;
		uniform half _Exposure;

		#define OUTER_RADIUS 1.025
		static const float kOuterRadius = OUTER_RADIUS;
		static const float kInnerRadius = 1.0;
		static const float kCameraHeight = 0.0001;
		static const half kRAYLEIGH = (lerp(0.0, 0.0025, pow(1,2.5)));
		static const half kMIE = 0.0010;
		static const half kSUN_BRIGHTNESS = 20.0;
		static const half kMAX_SCATTER = 50.0;

		static const half kHDSundiskIntensityFactor = 15.0;
		static const half kSimpleSundiskIntensityFactor = 27.0;
		static const half kSunScale = 400.0 * kSUN_BRIGHTNESS;
		static const float kKmESun = kMIE * kSUN_BRIGHTNESS;
		static const float kKm4PI = kMIE * 4.0 * 3.14159265;
		static const float kScale = 1.0 / (OUTER_RADIUS - 1.0);
		static const float kScaleDepth = 0.25;
		static const float kScaleOverScaleDepth = (1.0 / (OUTER_RADIUS - 1.0)) / 0.25;
		static const half kSamples = 2.0;
		static const half3 kDefaultScatteringWavelength = half3(0.65, 0.57, 0.475);
		static const half3 kVariableRangeForScatteringWavelength = half3(0.15, 0.15, 0.15);

		#define MIE_G (-0.990)
		#define MIE_G2 0.9801

		#define SKY_GROUND_THRESHOLD 0.02

		half getRayleighPhase(half eyeCos2) {
			return 0.75 + 0.75*eyeCos2;
		}

		half3 vertex_shared(float4 vertex, out float3 groundColor, out float3 skyColor)
		{
			float3 kSkyTintInGammaSpace = _SkyTint.rgb;
			float3 kScatteringWavelength = lerp (
				kDefaultScatteringWavelength - kVariableRangeForScatteringWavelength,
				kDefaultScatteringWavelength + kVariableRangeForScatteringWavelength,
				half3(1,1,1) - kSkyTintInGammaSpace);
			float3 kInvWavelength = 1.0 / pow(kScatteringWavelength, 4);

			float kKrESun = 0.0025 * kSUN_BRIGHTNESS;
			float kKr4PI = 0.0025 * 4.0 * 3.14159265;

			float3 cameraPos = float3(0, kInnerRadius + kCameraHeight, 0);

			float3 eyeRay = normalize(mul((float3x3)unity_ObjectToWorld, vertex.xyz));

			float far = 0.0;
			half3 cIn, cOut;

			if(eyeRay.y >= 0)
			{
				far = sqrt(kOuterRadius*kOuterRadius + kInnerRadius*kInnerRadius*eyeRay.y*eyeRay.y - kInnerRadius*kInnerRadius) - kInnerRadius*eyeRay.y;

				float3 pos = cameraPos + far * eyeRay;

				float height = kInnerRadius + kCameraHeight;
				float depth = exp(kScaleOverScaleDepth * (-kCameraHeight));
				float startAngle = dot(eyeRay, cameraPos) / height;
				float startOffset = depth*scale(startAngle);

				float sampleLength = far / kSamples;
				float scaledLength = sampleLength * kScale;
				float3 sampleRay = eyeRay * sampleLength;
				float3 samplePoint = cameraPos + sampleRay * 0.5;

				float3 frontColor = float3(0.0, 0.0, 0.0);
				for(int i=0; i<int(kSamples); i++)
				{
					float height2 = length(samplePoint);
					float depth2 = exp(kScaleOverScaleDepth * (kInnerRadius - height2));
					float lightAngle = dot(_WorldSpaceLightPos0.xyz, samplePoint) / height2;
					float cameraAngle = dot(eyeRay, samplePoint) / height2;
					float scatter = (startOffset + depth2*(scale(lightAngle) - scale(cameraAngle)));
					float3 attenuate = exp(-clamp(scatter, 0.0, kMAX_SCATTER) * (kInvWavelength * kKr4PI + kKm4PI));

					frontColor += attenuate * (depth2 * scaledLength);
					samplePoint += sampleRay;
				}

				cIn = frontColor * (kInvWavelength * kKrESun);
				cOut = frontColor * kKmESun;
			}
			else
			{
				far = (-kCameraHeight) / (min(-0.001, eyeRay.y));

				float3 pos = cameraPos + far * eyeRay;

				float depth = exp((-kCameraHeight) * (1.0/kScaleDepth));
				float cameraAngle = dot(-eyeRay, pos);
				float lightAngle = dot(_WorldSpaceLightPos0.xyz, pos);
				float cameraScale = scale(cameraAngle);
				float lightScale = scale(lightAngle);
				float cameraOffset = depth*cameraScale;
				float temp = (lightScale + cameraScale);

				float sampleLength = far / kSamples;
				float scaledLength = sampleLength * kScale;
				float3 sampleRay = eyeRay * sampleLength;
				float3 samplePoint = cameraPos + sampleRay * 0.5;

				float3 frontColor = float3(0.0, 0.0, 0.0);
				float3 attenuate;
				for(int i=0; i<int(kSamples); i++)
				{
					float height2 = length(samplePoint);
					float depth2 = exp(kScaleOverScaleDepth * (kInnerRadius - height2));
					float scatter = depth2*temp - cameraOffset;
					attenuate = exp(-clamp(scatter, 0.0, kMAX_SCATTER) * (kInvWavelength * kKr4PI + kKm4PI));
					frontColor += attenuate * (depth2 * scaledLength);
					samplePoint += sampleRay;
				}

				cIn = frontColor * (kInvWavelength * kKrESun + kKmESun);
				cOut = clamp(attenuate, 0.0, 1.0);
			}

			skyColor = cIn;
			groundColor = cIn + cOut * _GroundColor.rgb;

			return cOut;
		}

		float scale(float inCos)
		{
			float x = 1.0 - inCos;
			return 0.25 * exp(-0.00287 + x*(0.459 + x*(3.83 + x*(-6.80 + x*5.25))));
		}

		struct appdata_t {
			float4 vertex : POSITION;
		};

		struct v2f {
			float4 pos : SV_POSITION;
			half3 vertex : TEXCOORD0;
			half3 groundColor : TEXCOORD1;
			half3 skyColor : TEXCOORD2;
			half3 sunColor : TEXCOORD3;
		};

		v2f vert (appdata_t v)
		{
			v2f OUT;
			OUT.pos = UnityObjectToClipPos(v.vertex);
			OUT.vertex = v.vertex.xyz;

			float3 groundColor;
			float3 skyColor;
			vertex_shared(v.vertex, groundColor, skyColor);
			OUT.groundColor = groundColor;
			OUT.skyColor = skyColor;

			half3 sunColor = half3(1,1,1);
			#if defined(_SUNDISK_NONE)
			sunColor = half3(0,0,0);
			#endif
			OUT.sunColor = sunColor;

			return OUT;
		}

		half3 frag_shared(v2f IN, half3 ray) : SV_Target
		{
			half3 col = half3(0,0,0);
			half3 up = half3(0,1,0);
			half checkY = ray.y / SKY_GROUND_THRESHOLD;

			half3 sky = IN.skyColor;
			half3 ground = IN.groundColor;

			col = lerp(sky, ground, saturate(checkY < 0 ? 1 : 0));

			half sunAmount = max(dot(ray, _WorldSpaceLightPos0.xyz), 0.0);
			half3 sunDisk = pow(sunAmount, 256.0 / max(_SunSize, 0.0001)) * IN.sunColor;
			col += sunDisk;

			col *= _Exposure;
			return col;
		}

		fixed4 frag (v2f IN) : SV_Target
		{
			half3 ray = normalize(IN.vertex);
			half3 c = frag_shared(IN, ray);
			return half4(c, 1.0);
		}
		ENDCG
	}
}

Fallback Off
}
