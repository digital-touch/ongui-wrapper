using UnityEngine;
using System.Collections;

public class UIVerticalLayout : UILinearLayout
{		
		public override void Layout ()
		{				
				if (transform.childCount == 0) {
						setContentSize (0, 0);
						return;
				}
				
				UIGameObject lastChild = null;
				
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
								childUIGameObject.x = prevChildTransform.x;
								childUIGameObject.y = prevChildTransform.y + prevChildTransform.height + gap;
						} else {
								childUIGameObject.x = (int)-scrollPosition.x;
								childUIGameObject.y = (int)-scrollPosition.y;
						}
						lastChild = childUIGameObject;			
				}
				
				if (lastChild == null) {
						return;
				}
		
				float contentWidth = (lastChild.x + lastChild.width) + scrollPosition.x;
				float contentHeight = (lastChild.y + lastChild.height) + scrollPosition.y;										
		
				setContentSize (contentWidth, contentHeight);
		}
}