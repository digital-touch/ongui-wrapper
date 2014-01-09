using UnityEngine;
using System.Collections;

public class UIVerticalLayout : UILinearLayout
{
		public override void Layout ()
		{				
				contentSize.Set (0, 0);
				
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);					
						UIWidget childWidget = child.GetComponent<UIWidget> ();
						if (childWidget == null) {
								throw new UnityException ("LinearLayoutChildren must be UIWidget");
						}
						if (!childWidget.includeInLayout) {
								continue;
						}
			
						UIWidgetTransform childTransform = child.GetComponent<UIWidgetTransform> ();						
				
						if (i > 0) {
								Transform prevChild = transform.GetChild (i - 1);
								UIWidgetTransform prevChildTransform = prevChild.GetComponent<UIWidgetTransform> ();						
								childTransform.x = 0;
								childTransform.y = prevChildTransform.y + prevChildTransform.height + gap;
						} else {
								childTransform.x = 0;
								childTransform.y = 0;
						}
						
						
						contentSize.width = Mathf.Max (contentSize.width, childTransform.x + childTransform.width);
						contentSize.height = Mathf.Max (contentSize.height, childTransform.y + childTransform.height);						
				}
		
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidgetTransform childTransform = child.GetComponent<UIWidgetTransform> ();							
						childTransform.y += (int)scrollPosition.y;
				}
								
		}
}