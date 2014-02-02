using UnityEngine;
using System.Collections;

public class UIHorizontalLayout : UILinearLayout
{		
		public override void Layout ()
		{	
				setContentSize (0, 0);
		
				for (int i = 0; i < transform.childCount; i++) {
						
						Transform child = transform.GetChild (i);					
						
						UIGameObject childUIGameObject = child.GetComponent<UIGameObject> ();
						
						if (childUIGameObject == null) {
								continue;
						}
						if (!childUIGameObject.includeInLayout) {
								continue;
						}
												
						if (i > 0) {
								Transform prevChild = transform.GetChild (i - 1);
								UIGameObject prevChildTransform = prevChild.GetComponent<UIGameObject> ();						
								childUIGameObject.x = prevChildTransform.x + prevChildTransform.width + gap;
								childUIGameObject.y = 0;
						} else {
								childUIGameObject.x = 0;
								childUIGameObject.y = 0;
						}
			
						float contentWidth = Mathf.Max (contentSize.x, childUIGameObject.x + childUIGameObject.width);
						float contentHeight = Mathf.Max (contentSize.y, childUIGameObject.y + childUIGameObject.height);						
						setContentSize (contentWidth, contentHeight);
				}
		
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIGameObject childTransform = child.GetComponent<UIGameObject> ();							
						childTransform.x += (int)scrollPosition.x;
				}
		}
		
}
