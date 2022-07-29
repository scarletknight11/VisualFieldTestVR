Shader "Hidden/GaussianBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #define PI 3.141592654
            #define E 2.71828182846


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            int _Iterations;
            float neighborhoodSize;

            float _StandardDeviation;


            float4 frag(v2f i) : SV_Target
            {
                //fail safe so we can use turn off the blur by setting the deviation to 0
                if (_StandardDeviation == 0)
                    return tex2D(_MainTex, i.uv);

                float4 col = 0;
                float sum = 0;

                for (int index = 0; index < _Iterations; index++) {
                    float offset = (index / (_Iterations - 1.0) - .5) * neighborhoodSize;

                    float2 uv = i.uv + float2(0, offset);

                    float variance = _StandardDeviation * _StandardDeviation;
                    float gaussian = (1 / sqrt(2 * PI * variance)) * pow(E, -((offset * offset) / (2 * variance)));
                
                    sum += gaussian;
                    
                    col += tex2D(_MainTex, uv) * gaussian;
                }

                col = col / sum;
                return col;
            }
            ENDCG
        }
    }
}
