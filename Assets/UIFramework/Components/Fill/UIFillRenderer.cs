using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class UIFillRenderer : UIWidgetRenderer
{

		public override void Draw (UIWidgetTransform parentWidgetTransform)
		{		
		
				UIFill fill = GetComponent<UIFill> ();
				if (fill.texture == null) {
						return;
				}
				
				GUI.DrawTexture (widgetTransform.screenBounds, fill.texture);
		}
}
