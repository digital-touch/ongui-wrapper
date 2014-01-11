using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class UIImageRenderer : UIWidgetRenderer
{		
	
		public override void Draw (UIWidget parentWidgetTransform)
		{		
		
				UIImage image = (UIImage)widget;
				
				if (image.image == null) {
						return;
				}
				
				
				GUI.DrawTexture (widgetTransform.screenBounds, image.image, image.scaleMode, image.alphaBlend, image.imageAspect);
		}
}
