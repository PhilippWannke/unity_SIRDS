Shader "Unlit/DepthShader"
{
    SubShader
    {
        Cull Off
        ZWrite Off
        ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            //the depth texture
            sampler2D _CameraDepthTexture;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            //the vertex shader
            v2f vert(appdata v)
            {
	            v2f o;
				//convert the vertex positions from object space to clip space so they can be rendered
	            o.position = UnityObjectToClipPos(v.vertex);
	            o.uv = v.uv;
	            return o;
            }

            //the fragment shader
            fixed4 frag(v2f i) : SV_TARGET
            {
                // get depth from depth texture
	            float depth = tex2D(_CameraDepthTexture, i.uv).r;
    
                // linear depth between camera and far clipping plane
                // logarithmic values are desired in this case, hence unused
	            //depth = LinearEyeDepth(depth);    
    
				// depth as distance from camera in units
                // normalize value between 0 and 1
	            //depth = depth * _ProjectionParams.z;
	            //depth = (depth - 1) / 9;
	            //depth = 1 - depth;

	            return depth;
            }
            ENDCG
        }
    }
}
