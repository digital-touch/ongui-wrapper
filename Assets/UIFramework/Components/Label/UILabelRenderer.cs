using UnityEngine;
using System.Collections;

[System.Serializable]
[ExecuteInEditMode]
public class UILabelRenderer : UIWidgetRenderer
{
		public override void Draw (UIWidget parentWidgetTransform)
		{		
				UILabel label = (UILabel)widget;
				if (label.text == null) {
						return;
				}
				
				GUI.Label (widgetTransform.screenBounds, label.content, label.style);
		}
}
