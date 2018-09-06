Shader "Custom/WaterShader" 
{

    Properties 
    {
        _MainTex ("Main Texture", 2D) = "black" {}
        _FlowMap ("Flow Map", 2D) = "black" {}
        _Speed ("Speed", float) = 0.1
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
            sampler2D _FlowMap;
            fixed _Speed;
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

            // fragment shader, distorts the main texture into 2 interpolated layers based on the flowmap
            fixed4 frag (v2f input) : SV_Target 
            {
                fixed4 returnColor;

                // get vector from flowmap
                half3 flowmapVector = (tex2D(_FlowMap, input.uv) * 2.0f - 1.0f) * _Speed;

                // offset values
                float offset1 = frac(_Time.y * 0.25f + 0.5f);
                float offset2 = frac(_Time.y * 0.25f);

                // create 2 layers based on offset and flowmap values
                half4 layer1 = tex2D(_MainTex, input.uv - flowmapVector.xy * offset1);
                half4 layer2 = tex2D(_MainTex, input.uv - flowmapVector.xy * offset2);

                // set lerp value to have full interpolation halfway through cycle
                half lerpValue = abs((0.5f - offset1)/0.5f);

                // interpolate
                returnColor = lerp(layer1, layer2, lerpValue);

                // apply fog
                UNITY_APPLY_FOG(input.fogCoord, returnColor);

                return returnColor;
            }
 
            ENDCG
        }
    }
}