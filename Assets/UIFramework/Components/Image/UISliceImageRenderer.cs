using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class UISliceImageRenderer : UIWidgetRenderer
{		
		
		public override void Draw (UIWidget parentWidgetTransform)
		{		
				base.Draw (parentWidgetTransform);
				
				UISliceImage sliceImage = (UISliceImage)widget;
				if (sliceImage.image == null) {
						return;
				}				
				GUI.Box (widgetTransform.screenBounds, "", sliceImage.style);
				
		}
}
