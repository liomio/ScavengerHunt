Shader "Custom/PosterShader" 
{

    Properties 
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Pixels ("Pixels on each axis", float) = 20
    }
 
    SubShader 
    {

        Pass 
        {
       
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
            fixed _Pixels;
            fixed4 _MainTex_ST;

            // vertex shader
            v2f vert (appdata input) 
            {
                v2f output;
                output.vertex = UnityObjectToClipPos(input.vertex);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                UNITY_TRANSFER_FOG(output, output.vertex);
                return output;
            }

            // fragment shader
            float4 frag (v2f input) : COLOR 
            {
            	float4 returnColor;

                // transform uvs into that of that larger pixel to get the color
                float newX = (int)(input.uv.x * _Pixels) / _Pixels;
                float newY = (int)(input.uv.y * _Pixels) / _Pixels;
                float2 newUV = float2(newX, newY);

                // get color at newUV
                returnColor = tex2D(_MainTex, newUV);

                // apply fog
                UNITY_APPLY_FOG(input.fogCoord, returnColor);

                return returnColor;
            }
 
            ENDCG
        }
    }
}