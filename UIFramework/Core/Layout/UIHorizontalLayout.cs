using UnityEngine;
using System.Collections;

public class UIHorizontalLayout : UILinearLayout
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
			
						UIWidget childTransform = child.GetComponent<UIWidget> ();						
			
						if (i > 0) {
								Transform prevChild = transform.GetChild (i - 1);
								UIWidget prevChildTransform = prevChild.GetComponent<UIWidget> ();						
								childTransform.x = prevChildTransform.x + prevChildTransform.width + gap;
								childTransform.y = 0;
						} else {
								childTransform.x = 0;
								childTransform.y = 0;
						}
			
			
						contentSize.width = Mathf.Max (contentSize.width, childTransform.x + childTransform.width);
						contentSize.height = Mathf.Max (contentSize.height, childTransform.y + childTransform.height);						
				}
		
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childTransform = child.GetComponent<UIWidget> ();							
						childTransform.x += (int)scrollPosition.x;
				}
		}
		
}
