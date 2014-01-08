using UnityEngine;
using System.Collections;

public class UISliceImageValidator : UIWidgetValidator
{

		public override void Validate ()
		{   						
				base.Validate ();
		
				UISliceImage sliceImage = (UISliceImage)widget;
		
				bool borderDirty = widgetInvalidator.isDirty (UISliceImage.BORDER_FLAG);
				if (borderDirty) {
			
						sliceImage.style.border = sliceImage.border;
			
						widgetInvalidator.clearDirty (UISliceImage.BORDER_FLAG);	
				}
		
				bool imageDirty = widgetInvalidator.isDirty (UISliceImage.IMAGE_FLAG);						
		
				if (imageDirty) {
						sliceImage.style.normal.background = sliceImage.image;
						widgetInvalidator.clearDirty (UISliceImage.IMAGE_FLAG);	
				}
				
		
		}
}
