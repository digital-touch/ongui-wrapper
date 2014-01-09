using UnityEngine;
using System.Collections;

public class UISliceImageValidator : UIWidgetValidator
{

		public override void Validate ()
		{   				
				if (!gameObject.activeSelf) {					
						return;
				}
				
				base.Validate ();
		
				UISliceImage sliceImage = (UISliceImage)widget;
		
				bool borderDirty = UIInvalidator.isInvalid (widget, UISliceImage.BORDER_FLAG);
				if (borderDirty) {
			
						sliceImage.style.border = sliceImage.border;
			
					
				}
		
				bool imageDirty = UIInvalidator.isInvalid (widget, UISliceImage.IMAGE_FLAG);						
		
				if (imageDirty) {
						sliceImage.style.normal.background = sliceImage.image;
						
				}
				
		
		}
}
