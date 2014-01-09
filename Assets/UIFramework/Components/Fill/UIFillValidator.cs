using UnityEngine;
using System.Collections;

public class UIFillValidator : UIWidgetValidator
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   						
		
				if (!gameObject.activeSelf) {					
						return;
				}
		
				base.Validate ();
		
				UIFill fill = (UIFill)this.widget;
		
				bool textureDirty = UIInvalidator.isInvalid (widget, UIFill.TEXTURE_FLAG);
		
				bool textureSizeDirty = UIInvalidator.isInvalid (widget, UIFill.TEXTURE_SIZE_FLAG);		
		
				if (textureDirty || textureSizeDirty) {
						if (fill.textureSize > 0) {
								if (fill.texture != null) {			
										fill.texture.Resize (fill.textureSize, fill.textureSize);										
								} else {
										fill.texture = new Texture2D (fill.textureSize, fill.textureSize);
					
								}				
																				
								UIInvalidator.invalidate (widget, UIFill.TEXTURE_FLAG);
								UIInvalidator.invalidate (widget, UIFill.TEXTURE_COLOR_FLAG);												
						}
				}				
		
				bool colorDirty = UIInvalidator.isInvalid (widget, UIFill.TEXTURE_COLOR_FLAG);
		
				if (colorDirty) {			
						Color[] pixels = fill.texture.GetPixels ();
			
						for (var i = 0; i < pixels.Length; ++i) {
								pixels [i] = fill.textureColor;
						}
			
						fill.texture.SetPixels (pixels);
			
																
						UIInvalidator.invalidate (widget, UIFill.TEXTURE_FLAG);
			
				}
		
				textureDirty = UIInvalidator.isInvalid (widget, UIFill.TEXTURE_FLAG);
		
				if (textureDirty) { 
			
						fill.texture.Apply ();
															
				}
		}
}
