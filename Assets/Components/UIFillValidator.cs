using UnityEngine;
using System.Collections;

public class UIFillValidator : UIWidgetValidator
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   						
		
				base.Validate ();
		
				UIFill fill = (UIFill)widget;
		
				bool textureDirty = widgetInvalidator.isDirty (UIFill.TEXTURE_FLAG);
		
				bool textureSizeDirty = widgetInvalidator.isDirty (UIFill.TEXTURE_SIZE_FLAG);		
		
				if (textureDirty || textureSizeDirty) {
						if (fill.textureSize > 0) {
								if (fill.texture != null) {			
										fill.texture.Resize (fill.textureSize, fill.textureSize);										
								} else {
										fill.texture = new Texture2D (fill.textureSize, fill.textureSize);
					
								}				
								widgetInvalidator.clearDirty (UIFill.TEXTURE_SIZE_FLAG);												
								widgetInvalidator.setDirty (UIFill.TEXTURE_FLAG);
								widgetInvalidator.setDirty (UIFill.TEXTURE_COLOR_FLAG);												
						}
				}				
		
				bool colorDirty = widgetInvalidator.isDirty (UIFill.TEXTURE_COLOR_FLAG);
		
				if (colorDirty) {			
						Color[] pixels = fill.texture.GetPixels ();
			
						for (var i = 0; i < pixels.Length; ++i) {
								pixels [i] = fill.textureColor;
						}
			
						fill.texture.SetPixels (pixels);
			
						widgetInvalidator.clearDirty (UIFill.TEXTURE_COLOR_FLAG);												
						widgetInvalidator.setDirty (UIFill.TEXTURE_FLAG);
			
				}
		
				textureDirty = widgetInvalidator.isDirty (UIFill.TEXTURE_FLAG);
		
				if (textureDirty) { 
			
						fill.texture.Apply ();
						widgetInvalidator.clearDirty (UIFill.TEXTURE_FLAG);											
				}
		}
}
