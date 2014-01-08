using UnityEngine;
using System.Collections;

public class UILabelValidator : UIWidgetValidator
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   						
				base.Validate ();
		
				UILabel label = (UILabel)widget;
		
				bool isTextStyleDirty = widgetInvalidator.isDirty (UILabel.TEXT_STYLE_FLAG);
		
				if (isTextStyleDirty) {
						label.textStyle.updateGUIStyle (label.style);
						widgetInvalidator.clearDirty (UILabel.TEXT_STYLE_FLAG);												
				}						
		
				bool isTextDirty = widgetInvalidator.isDirty (UILabel.TEXT_FLAG);
		
				if (isTextDirty) {
							
						widgetInvalidator.clearDirty (UILabel.TEXT_FLAG);												
			
				}						
		}
}
