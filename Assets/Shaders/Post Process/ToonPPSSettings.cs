// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess( typeof( ToonPPSRenderer ), PostProcessEvent.AfterStack, "Toon", true )]
public sealed class ToonPPSSettings : PostProcessEffectSettings
{
	[Tooltip( "Screen" )]
	public TextureParameter _MainTex = new TextureParameter {  };
	[Tooltip( "Highlight" )]
	public FloatParameter _Highlight = new FloatParameter { value = 0f };
	[Tooltip( "Light Tones" )]
	public FloatParameter _LightTones = new FloatParameter { value = 0f };
	[Tooltip( "Dark Tones" )]
	public FloatParameter _DarkTones = new FloatParameter { value = 0f };
	[Tooltip( "Light Tint" )]
	public ColorParameter _LightTint = new ColorParameter { value = new Color(1f,0.3963672f,0f,0f) };
	[Tooltip( "Dark Tint" )]
	public ColorParameter _DarkTint = new ColorParameter { value = new Color(0.207843f,0.009674203f,0f,0f) };
}

public sealed class ToonPPSRenderer : PostProcessEffectRenderer<ToonPPSSettings>
{
	public override void Render( PostProcessRenderContext context )
	{
		var sheet = context.propertySheets.Get( Shader.Find( "Toon" ) );
		if(settings._MainTex.value != null) sheet.properties.SetTexture( "_MainTex", settings._MainTex );
		sheet.properties.SetFloat( "_Highlight", settings._Highlight );
		sheet.properties.SetFloat( "_LightTones", settings._LightTones );
		sheet.properties.SetFloat( "_DarkTones", settings._DarkTones );
		sheet.properties.SetColor( "_LightTint", settings._LightTint );
		sheet.properties.SetColor( "_DarkTint", settings._DarkTint );
		context.command.BlitFullscreenTriangle( context.source, context.destination, sheet, 0 );
	}
}
#endif
