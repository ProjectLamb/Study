// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32920,y:32623,varname:node_4795,prsc:2|emission-1732-OUT,alpha-2162-OUT,clip-3576-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31899,y:32600,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c598daf3456bd85468631c0132729f5c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6663,x:31586,y:32947,ptovrint:False,ptlb:DissolveTex,ptin:_DissolveTex,varname:node_6663,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9ccdc7c4ed31e794280decf134ea7989,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:6768,x:31985,y:33027,varname:node_6768,prsc:2|A-6663-R,B-8618-OUT;n:type:ShaderForge.SFN_Slider,id:6014,x:31383,y:33229,ptovrint:False,ptlb:Dissolove,ptin:_Dissolove,varname:node_6014,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRange,id:8618,x:31826,y:33146,varname:node_8618,prsc:2,frmn:1,frmx:0,tomn:-1,tomx:1|IN-6014-OUT;n:type:ShaderForge.SFN_Clamp01,id:3576,x:32188,y:33027,varname:node_3576,prsc:2|IN-6768-OUT;n:type:ShaderForge.SFN_Multiply,id:3551,x:32409,y:32618,varname:node_3551,prsc:2|A-6074-RGB,B-3661-RGB;n:type:ShaderForge.SFN_Color,id:3661,x:32144,y:32675,ptovrint:False,ptlb:Base_Color,ptin:_Base_Color,varname:node_3661,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9428,x:31899,y:32827,ptovrint:False,ptlb:MaskTex,ptin:_MaskTex,varname:node_9428,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bbb42ea734bc605448976e8c1660545c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6887,x:32247,y:32853,varname:node_6887,prsc:2|A-6074-A,B-9428-A;n:type:ShaderForge.SFN_Multiply,id:1732,x:32678,y:32681,varname:node_1732,prsc:2|A-3551-OUT,B-5928-OUT;n:type:ShaderForge.SFN_Slider,id:5928,x:32371,y:32768,ptovrint:False,ptlb:Color_Power,ptin:_Color_Power,varname:node_5928,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:10;n:type:ShaderForge.SFN_Multiply,id:2162,x:32492,y:32850,varname:node_2162,prsc:2|A-3661-A,B-6887-OUT;proporder:6074-6663-6014-3661-9428-5928;pass:END;sub:END;*/

Shader "Effect/FxS_Disslove" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _DissolveTex ("DissolveTex", 2D) = "white" {}
        _Dissolove ("Dissolove", Range(0, 1)) = 0
        _Base_Color ("Base_Color", Color) = (1,1,1,1)
        _MaskTex ("MaskTex", 2D) = "white" {}
        _Color_Power ("Color_Power", Range(1, 10)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            sampler2D _MainTex; float4 _MainTex_ST;
            sampler2D _DissolveTex; float4 _DissolveTex_ST;
            float _Dissolove;
            float4 _Base_Color;
            sampler2D _MaskTex; float4 _MaskTex_ST;
            float _Color_Power;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _DissolveTex_var = tex2D(_DissolveTex,TRANSFORM_TEX(i.uv0, _DissolveTex));
                clip(_DissolveTex_var.r >= _Dissolove ? 1 : -1);
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 emissive = ((_MainTex_var.rgb*_Base_Color.rgb)*_Color_Power);
                float3 finalColor = emissive;
                float4 _MaskTex_var = tex2D(_MaskTex,TRANSFORM_TEX(i.uv0, _MaskTex));
                fixed4 finalRGBA = fixed4(finalColor,(_Base_Color.a*(_MainTex_var.a*_MaskTex_var.a)));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
