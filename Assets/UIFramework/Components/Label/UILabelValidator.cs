using UnityEngine;
using System.Collections;

public class UILabelValidator : UIWidgetValidator
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   				
				if (!gameObject.activeSelf) {					
						return;
				}
				
				base.Validate ();
		
				UILabel label = (UILabel)widget;
		
				bool isTextStyleDirty = UIInvalidator.isInvalid (widget, UILabel.TEXT_STYLE_FLAG);
		
				if (isTextStyleDirty) {
						label.textStyle.updateGUIStyle (label.style);
																
				}						
		
				bool isTextDirty = UIInvalidator.isInvalid (widget, UILabel.TEXT_FLAG);
		
				if (isTextDirty) {
							
																	
			
				}						
		}
}
