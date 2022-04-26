Shader "TetaviShaderLit"
{
    Properties
    {
		[HideInInspector]_MainTex("Albedo, Metallic", 2D) = "white" {}
		[HideInInspector]_MS("Material segmentation", Float) = 0
		
		//Hair
		[HideInInspector][Toggle(SHOW_HAIR)]
		_ShowHair("Hair", Float) = 0
		_Color_hair("Color", Color) = (1, 1, 1, 1)
		_BumpMap_hair("Normal", 2D) = "bump"{}
		_BumpScale_hair("Scale", Range(0, 2)) = 1
		_MetallicBias_hair("Metallic Bias", Range(0, 1)) = 0
		_MetallicScale_hair("Metallic Scale", Range(0, 2)) = 0
		_SmoothnessBias_hair("Smoothness Bias", Range(0, 1)) = 0
		_SmoothnessScale_hair("Smoothness Scale", Range(0, 2)) = 0

        //Shoes
		[HideInInspector][Toggle(SHOW_SHOES)]
        _ShowShoes("Shoes", Float) = 0
         _Color_shoes ("Color", Color) = (1, 1, 1, 1)
         _BumpMap_shoes ("Normal", 2D) = "bump"{}
         _BumpScale_shoes("Scale", Range(0, 2)) = 1
         _MetallicBias_shoes ("Metallic Bias", Range(0, 1)) = 0
         _MetallicScale_shoes ("Metallic Scale", Range(0, 2)) = 0
         _SmoothnessBias_shoes ("Smoothness Bias", Range(0, 1)) = 0
         _SmoothnessScale_shoes ("Smoothness Scale", Range(0, 2)) = 0
        
        // Face
		
		[HideInInspector][Toggle(SHOW_FACE)]
        _ShowFace("Face", Float) = 0
         _Color_face ("Color", Color) = (1, 1, 1, 1)
         _BumpMap_face ("Normal", 2D) = "bump"{}
         _BumpScale_face("Scale", Range(0, 2)) = 1
         _MetallicBias_face ("Metallic Bias", Range(0, 1)) = 0
         _MetallicScale_face ("Metallic Scale", Range(0, 2)) = 0
         _SmoothnessBias_face ("Smoothness Bias", Range(0, 1)) = 0
         _SmoothnessScale_face ("Smoothness Scale", Range(0, 2)) = 0

        // upper clothes
		[HideInInspector][Toggle(SHOW_UPPER_CLOTHES)]
        _ShowUpper_Clothes("Upper clothes", Float) = 0
        _Color_upper_clothes ("Color", Color) = (1, 1, 1, 1)
        _BumpMap_upper_clothes ("Normal", 2D) = "bump"{}
        _BumpScale_upper_clothes("Scale", Range(0, 2)) = 1
        _MetallicBias_upper_clothes ("Metallic Bias", Range(0, 1)) = 0
        _MetallicScale_upper_clothes ("Metallic Scale", Range(0, 2)) = 0
        _SmoothnessBias_upper_clothes ("Smoothness Bias", Range(0, 1)) = 0
        _SmoothnessScale_upper_clothes ("Smoothness Scale", Range(0, 2)) = 0
		
		// lower clothes
		[HideInInspector][Toggle(SHOW_LOWER_CLOTHES)]
        _ShowLower_Clothes("Lower clothes", Float) = 0
        _Color_lower_clothes ("Color", Color) = (1, 1, 1, 1)
        _BumpMap_lower_clothes ("Normal", 2D) = "bump"{}
        _BumpScale_lower_clothes("Scale", Range(0, 2)) = 1
        _MetallicBias_lower_clothes ("Metallic Bias", Range(0, 1)) = 0
        _MetallicScale_lower_clothes ("Metallic Scale", Range(0, 2)) = 0
        _SmoothnessBias_lower_clothes ("Smoothness Bias", Range(0, 1)) = 0
        _SmoothnessScale_lower_clothes ("Smoothness Scale", Range(0, 2)) = 0

		// torso skin
		[HideInInspector][Toggle(SHOW_TORSO_SKIN)]
        _ShowTorso_Skin("Torso skin", Float) = 0
        _Color_torso_skin ("Color", Color) = (1, 1, 1, 1)
        _BumpMap_torso_skin ("Normal", 2D) = "bump"{}
        _BumpScale_torso_skin("Scale", Range(0, 2)) = 1
        _MetallicBias_torso_skin ("Metallic Bias", Range(0, 1)) = 0
        _MetallicScale_torso_skin ("Metallic Scale", Range(0, 2)) = 0
        _SmoothnessBias_torso_skin ("Smoothness Bias", Range(0, 1)) = 0
        _SmoothnessScale_torso_skin ("Smoothness Scale", Range(0, 2)) = 0

		// arms
		[HideInInspector][Toggle(SHOW_ARMS)]
        _ShowArms("Arms", Float) = 0
        _Color_arms ("Color", Color) = (1, 1, 1, 1)
        _BumpMap_arms ("Normal", 2D) = "bump"{}
        _BumpScale_arms("Scale", Range(0, 2)) = 1
        _MetallicBias_arms ("Metallic Bias", Range(0, 1)) = 0
        _MetallicScale_arms ("Metallic Scale", Range(0, 2)) = 0
        _SmoothnessBias_arms ("Smoothness Bias", Range(0, 1)) = 0
        _SmoothnessScale_arms ("Smoothness Scale", Range(0, 2)) = 0

		// legs
		[HideInInspector][Toggle(SHOW_LEGS)]
        _ShowLegs("Legs", Float) = 0
        _Color_legs ("Color", Color) = (1, 1, 1, 1)
        _BumpMap_legs ("Normal", 2D) = "bump"{}
        _BumpScale_legs("Scale", Range(0, 2)) = 1
        _MetallicBias_legs ("Metallic Bias", Range(0, 1)) = 0
        _MetallicScale_legs ("Metallic Scale", Range(0, 2)) = 0
        _SmoothnessBias_legs ("Smoothness Bias", Range(0, 1)) = 0
        _SmoothnessScale_legs ("Smoothness Scale", Range(0, 2)) = 0

		// mouth
		[HideInInspector][Toggle(SHOW_MOUTH)]
        _ShowMouth("Mouth", Float) = 0
        _Color_mouth ("Color", Color) = (1, 1, 1, 1)
        _BumpMap_mouth ("Normal", 2D) = "bump"{}
        _BumpScale_mouth("Scale", Range(0, 2)) = 1
        _MetallicBias_mouth ("Metallic Bias", Range(0, 1)) = 0
        _MetallicScale_mouth ("Metallic Scale", Range(0, 2)) = 0
        _SmoothnessBias_mouth ("Smoothness Bias", Range(0, 1)) = 0
        _SmoothnessScale_mouth ("Smoothness Scale", Range(0, 2)) = 0

		// eyes
		[HideInInspector][Toggle(SHOW_EYES)]
        _ShowEyes("Eyes", Float) = 0
        _Color_eyes ("Color", Color) = (1, 1, 1, 1)
        _BumpMap_eyes ("Normal", 2D) = "bump"{}
        _BumpScale_eyes("Scale", Range(0, 2)) = 1
        _MetallicBias_eyes ("Metallic Bias", Range(0, 1)) = 0
        _MetallicScale_eyes ("Metallic Scale", Range(0, 2)) = 0
        _SmoothnessBias_eyes ("Smoothness Bias", Range(0, 1)) = 0
        _SmoothnessScale_eyes ("Smoothness Scale", Range(0, 2)) = 0

        // socks
		[HideInInspector][Toggle(SHOW_SOCKS)]
        _ShowSocks("Socks", Float) = 0
        _Color_socks ("Color", Color) = (1, 1, 1, 1)
        _BumpMap_socks ("Normal", 2D) = "bump"{}
        _BumpScale_socks("Scale", Range(0, 2)) = 1
        _MetallicBias_socks ("Metallic Bias", Range(0, 1)) = 0
        _MetallicScale_socks ("Metallic Scale", Range(0, 2)) = 0
        _SmoothnessBias_socks ("Smoothness Bias", Range(0, 1)) = 0
        _SmoothnessScale_socks ("Smoothness Scale", Range(0, 2)) = 0


    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        
        CGPROGRAM
        #pragma shader_feature _MATERIAL_MASKED
        
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0
		#pragma shader_feature 

        // #include "PBRLib.cginc"

        sampler2D _TexY;
        sampler2D _TexUV;
		float _MS;
        
		// hair
		sampler2D _BumpMap_hair;
		half _BumpScale_hair;
		half4 _Color_hair;
		half _MetallicBias_hair;
		half _MetallicScale_hair;
		half _SmoothnessBias_hair;
		half _SmoothnessScale_hair;

		

        // shoes
        sampler2D _BumpMap_shoes;
        half _BumpScale_shoes;
        half4 _Color_shoes;
        half _MetallicBias_shoes;
        half _MetallicScale_shoes;
        half _SmoothnessBias_shoes;
        half _SmoothnessScale_shoes;
        // face
        sampler2D _BumpMap_face;
        half _BumpScale_face;
        half4 _Color_face;
        half _MetallicBias_face;
        half _MetallicScale_face;
        half _SmoothnessBias_face;
        half _SmoothnessScale_face;

        // upper_clothes
        sampler2D _BumpMap_upper_clothes;
        half _BumpScale_upper_clothes;
        half4 _Color_upper_clothes;
        half _MetallicBias_upper_clothes;
        half _MetallicScale_upper_clothes;
        half _SmoothnessBias_upper_clothes;
        half _SmoothnessScale_upper_clothes;

		// lower_clothes
		sampler2D _BumpMap_lower_clothes;
		half _BumpScale_lower_clothes;
		half4 _Color_lower_clothes;
		half _MetallicBias_lower_clothes;
		half _MetallicScale_lower_clothes;
		half _SmoothnessBias_lower_clothes;
		half _SmoothnessScale_lower_clothes;

		// torso_skin
		sampler2D _BumpMap_torso_skin;
		half _BumpScale_torso_skin;
		half4 _Color_torso_skin;
		half _MetallicBias_torso_skin;
		half _MetallicScale_torso_skin;
		half _SmoothnessBias_torso_skin;
		half _SmoothnessScale_torso_skin;

		// arms
		sampler2D _BumpMap_arms;
		half _BumpScale_arms;
		half4 _Color_arms;
		half _MetallicBias_arms;
		half _MetallicScale_arms;
		half _SmoothnessBias_arms;
		half _SmoothnessScale_arms;

		// legs
		sampler2D _BumpMap_legs;
		half _BumpScale_legs;
		half4 _Color_legs;
		half _MetallicBias_legs;
		half _MetallicScale_legs;
		half _SmoothnessBias_legs;
		half _SmoothnessScale_legs;

		// mouth
		sampler2D _BumpMap_mouth;
		half _BumpScale_mouth;
		half4 _Color_mouth;
		half _MetallicBias_mouth;
		half _MetallicScale_mouth;
		half _SmoothnessBias_mouth;
		half _SmoothnessScale_mouth;

		// eyes
		sampler2D _BumpMap_eyes;
		half _BumpScale_eyes;
		half4 _Color_eyes;
		half _MetallicBias_eyes;
		half _MetallicScale_eyes;
		half _SmoothnessBias_eyes;
		half _SmoothnessScale_eyes;

        // socks
        //sampler2D _BumpMap_socks;
        half _BumpScale_socks;
        half4 _Color_socks;
        half _MetallicBias_socks;
        half _MetallicScale_socks;
        half _SmoothnessBias_socks;
        half _SmoothnessScale_socks;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            
            float2 uv = IN.uv_MainTex;
			if (_MS) {
				uv.g = uv.g/2 + 0.5;
			}
            
            float y = tex2D(_TexY, uv).r;
            float2 UV_rg = tex2D(_TexUV, uv);
            float u = UV_rg.r * 0.872 - 0.436;
            float v = UV_rg.g * 1.230 - 0.615;

			float3 rgb;
			rgb.r = clamp(y + 1.13983 * v, 0.0, 1.0);
			rgb.g = clamp(y - 0.39465 * u - 0.58060 * v, 0.0, 1.0);
			rgb.b = clamp(y + 2.03211 * u, 0.0, 1.0);

			float4 col = float4(rgb, 1);

			o.Albedo = col;
			if (_MS != 1 ) {
                o.Albedo = float3(0, 0, 0);
				return;
			}

			float2 label = uv;
			label.g = label.g + 0.5;
			float yL = tex2D(_TexY, label).r;
			float2 LAbelUV_rg = tex2D(_TexUV, label);
			float uL = LAbelUV_rg.r;
			float vL = LAbelUV_rg.g;

            static int s[] = {0,0,0,0,1,2,2,2,2};

            int Label = 9 * s[int((yL *256 +16)/32)] + 3 * s[int((uL *256 +16)/32)] + s[int((vL*256 +16)/32)] ;
			
            

			if (Label == 2) {
				//hair
				o.Albedo = col * _Color_hair.rgb * 2;
				o.Normal = UnpackScaleNormal(tex2D(_BumpMap_hair, uv), _BumpScale_hair);
				o.Metallic = saturate(col.a * _MetallicScale_hair + _MetallicBias_hair);
				o.Smoothness = saturate(col.a * _SmoothnessScale_hair + _SmoothnessBias_hair);
				return;
			}

            if(Label == 18){
                //shoe
                o.Albedo = col * _Color_shoes.rgb*2;
                o.Normal = UnpackScaleNormal(tex2D(_BumpMap_shoes, uv), _BumpScale_shoes);
                o.Metallic = saturate(col.a * _MetallicScale_shoes + _MetallicBias_shoes);
                o.Smoothness = saturate(col.a * _SmoothnessScale_shoes + _SmoothnessBias_shoes);
                return;
            }
            if(Label == 13){
                //face
                o.Albedo = col * _Color_face.rgb*2;
                o.Normal = UnpackScaleNormal(tex2D(_BumpMap_face, uv), _BumpScale_face);
                o.Metallic = saturate(col.a * _MetallicScale_face + _MetallicBias_face);
                o.Smoothness = saturate(col.a * _SmoothnessScale_face + _SmoothnessBias_face);
                return;
            }
            if(Label == 5){
                // upper clothes
                o.Albedo = col * _Color_upper_clothes.rgb*2;
                o.Normal = UnpackScaleNormal(tex2D(_BumpMap_upper_clothes, uv), _BumpScale_upper_clothes);
                o.Metallic = saturate(col.a * _MetallicScale_upper_clothes + _MetallicBias_upper_clothes);
                o.Smoothness = saturate(col.a * _SmoothnessScale_upper_clothes + _SmoothnessBias_upper_clothes);
                return;
            }
			if (Label == 9) {
				// lower clothes
				o.Albedo = col * _Color_lower_clothes.rgb * 2;
				o.Normal = UnpackScaleNormal(tex2D(_BumpMap_lower_clothes, uv), _BumpScale_lower_clothes);
				o.Metallic = saturate(col.a * _MetallicScale_lower_clothes + _MetallicBias_lower_clothes);
				o.Smoothness = saturate(col.a * _SmoothnessScale_lower_clothes + _SmoothnessBias_lower_clothes);
				return;
			}

			if (Label == 10) {
				// torso skin
				o.Albedo = col * _Color_torso_skin.rgb * 2;
				o.Normal = UnpackScaleNormal(tex2D(_BumpMap_torso_skin, uv), _BumpScale_torso_skin);
				o.Metallic = saturate(col.a * _MetallicScale_torso_skin + _MetallicBias_torso_skin);
				o.Smoothness = saturate(col.a * _SmoothnessScale_torso_skin + _SmoothnessBias_torso_skin);
				return;
			}
			if (Label == 14) {
				// arms
				o.Albedo = col * _Color_arms.rgb * 2;
				o.Normal = UnpackScaleNormal(tex2D(_BumpMap_arms, uv), _BumpScale_arms);
				o.Metallic = saturate(col.a * _MetallicScale_arms + _MetallicBias_arms);
				o.Smoothness = saturate(col.a * _SmoothnessScale_arms + _SmoothnessBias_arms);
				return;
			}
			if (Label == 1) {
				// legs
				o.Albedo = col * _Color_legs.rgb * 2;
				o.Normal = UnpackScaleNormal(tex2D(_BumpMap_legs, uv), _BumpScale_legs);
				o.Metallic = saturate(col.a * _MetallicScale_legs + _MetallicBias_legs);
				o.Smoothness = saturate(col.a * _SmoothnessScale_legs + _SmoothnessBias_legs);
				return;
			}
			if (Label == 20) {
				// mouth
				o.Albedo = col * _Color_mouth.rgb * 2;
				o.Normal = UnpackScaleNormal(tex2D(_BumpMap_mouth, uv), _BumpScale_mouth);
				o.Metallic = saturate(col.a * _MetallicScale_mouth + _MetallicBias_mouth);
				o.Smoothness = saturate(col.a * _SmoothnessScale_mouth + _SmoothnessBias_mouth);
				return;
			}
			if (Label == 21) {
				// eyes
				o.Albedo = col * _Color_eyes.rgb * 2;
				o.Normal = UnpackScaleNormal(tex2D(_BumpMap_eyes, uv), _BumpScale_eyes);
				o.Metallic = saturate(col.a * _MetallicScale_eyes + _MetallicBias_eyes);
				o.Smoothness = saturate(col.a * _SmoothnessScale_eyes + _SmoothnessBias_eyes);
				return;
			}

            if(Label == 8){
                // socks
                o.Albedo = col * _Color_socks.rgb*2;
                //o.Normal = UnpackScaleNormal(tex2D(_BumpMap_socks, uv), _BumpScale_socks);
                o.Metallic = saturate(col.a * _MetallicScale_socks + _MetallicBias_socks);
                o.Smoothness = saturate(col.a * _SmoothnessScale_socks + _SmoothnessBias_socks);
                return;
            }

            
            
        }

        ENDCG
    } 
    FallBack "Diffuse"
    CustomEditor "TetaviShaderEditor"
}