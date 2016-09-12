Shader "Hidden/PaletteSwapLookup"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_PaletteTex("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _PaletteTex;

			fixed4 frag (v2f i) : SV_Target
			{
				float x = tex2D(_MainTex, i.uv).r;
				return tex2D(_PaletteTex, float2(x, 0));
			}

			ENDCG
		}
	}
}
