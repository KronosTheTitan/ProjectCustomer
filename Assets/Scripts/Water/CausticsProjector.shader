// Upgrade NOTE: replaced '_Projector' with 'unity_Projector'
// Upgrade NOTE: replaced '_ProjectorClip' with 'unity_ProjectorClip'

Shader "Projector/Caustics" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_CausticTex1 ("Cookie", 2D) = "" {}
		_CausticTex2 ("Cookie", 2D) = "" {}
		_FalloffTex ("FallOff", 2D) = "" {}
		_timeScale ("Time Scale", float) = 1
	}
	
	Subshader {
		Tags {"Queue"="Transparent"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend DstColor One
			Offset -1, -1
	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			
			struct v2f {
				float4 uvShadow : TEXCOORD0;
				float4 uvFalloff : TEXCOORD1;
				UNITY_FOG_COORDS(2)
				float4 pos : SV_POSITION;
			};
			
			float4x4 unity_Projector;
			float4x4 unity_ProjectorClip;
			
			v2f vert (float4 vertex : POSITION)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(vertex);
				o.uvShadow = mul (unity_Projector, vertex);
				o.uvFalloff = mul (unity_ProjectorClip, vertex);
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}

			float _timeScale;
			
			fixed4 _Color;
			sampler2D _CausticTex1;
			sampler2D _CausticTex2;
			sampler2D _FalloffTex;
			
			fixed4 frag (v2f i) : SV_Target
			{
				float time = _Time.y * _timeScale;
				float4 uv1 = float4((i.uvShadow.x+time),i.uvShadow.y,i.uvShadow.z,i.uvShadow.w);
				float4 uv2 = float4(i.uvShadow.x,(i.uvShadow.y+time),i.uvShadow.z,i.uvShadow.w);
				fixed4 texS1 = tex2Dproj (_CausticTex1, UNITY_PROJ_COORD(uv1));
				fixed4 texS2 = tex2Dproj (_CausticTex1, UNITY_PROJ_COORD(uv2));

				fixed4 texS = clamp(texS1+texS2,0,1);

				texS = lerp((0,0,0,0),texS,step(0,i.uvShadow.w));
				
				texS.rgb *= _Color.rgb;
				texS.a = 1.0-texS.a;

				//return i.uvShadow.w;
	
				fixed4 texF = tex2Dproj (_FalloffTex, UNITY_PROJ_COORD(i.uvFalloff));
				fixed4 res = texS * texF.a;

				UNITY_APPLY_FOG_COLOR(i.fogCoord, res, fixed4(0,0,0,0));
				return res;
			}
			ENDCG
		}
	}
}
