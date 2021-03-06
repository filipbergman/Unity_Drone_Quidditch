Shader "Unlit/Nothing"
{
    Properties
    {
       // _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {

        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

			struct v2f {
		    float4 pos : SV_POSITION;
			};

		  v2f vert()
		  {
			  v2f o;
			  o.pos = fixed4(0,0,0,0);
			  return o;
		  }

		  fixed4 frag(v2f i) : COLOR0{ return fixed4(0,0,0,0); }

          ENDCG
        }
    }
}
