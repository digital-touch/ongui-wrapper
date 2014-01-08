using UnityEngine;
using System.Collections;

public class UIImageValidator : UIWidgetValidator
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   						
		
				base.Validate ();
		
				UIImage image = (UIImage)widget;
		
				bool isImageDirty = widgetInvalidator.isDirty (UIImage.IMAGE_FLAG);
		
				bool isAutoSizeDirty = widgetInvalidator.isDirty (UIImage.AUTO_SIZE_FLAG);
		
				if (isImageDirty || isAutoSizeDirty) {
						if (image.image != null && image.autoSize) {
								widgetTransform.width = image.image.width;
								widgetTransform.height = image.image.height;
						} else {
				
						}
						widgetInvalidator.clearDirty (UIImage.AUTO_SIZE_FLAG);												
						widgetInvalidator.clearDirty (UIImage.IMAGE_FLAG);												
				}
		
		
		}
}
