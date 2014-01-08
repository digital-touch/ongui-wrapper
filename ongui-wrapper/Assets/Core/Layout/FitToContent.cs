using UnityEngine;
using System.Collections;

public class FitToContent : UILayout
{
		
		public override void Layout ()
		{
		
				contentSize.Set (0, 0);
				
				for (int i = 0; i < widgetTransform.transform.childCount; i++) {
						Transform child = widgetTransform.transform.GetChild (i);						
						UIWidgetTransform childTransform = child.GetComponent<UIWidgetTransform> ();
						if (childTransform == null) {
								continue;
						}
			
						contentSize.width = Mathf.Max (contentSize.width, childTransform.x + childTransform.width);
						
						contentSize.height = Mathf.Max (contentSize.height, childTransform.y + childTransform.height);
						
				}
				
				widgetTransform.width = contentSize.width;
				widgetTransform.height = contentSize.height;
				
		}
}
