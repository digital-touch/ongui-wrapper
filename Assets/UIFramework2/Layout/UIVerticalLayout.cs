using UnityEngine;
using System.Collections;

public class UIVerticalLayout : UILinearLayout
{
		public override void Layout ()
		{				
				contentSize.Set (0, 0);
				
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
								childUIGameObject.x = 0;
								childUIGameObject.y = prevChildTransform.y + prevChildTransform.height + gap;
						} else {
								childUIGameObject.x = 0;
								childUIGameObject.y = 0;
						}
						
						
						contentSize.x = Mathf.Max (contentSize.x, childUIGameObject.x + childUIGameObject.width);
						contentSize.y = Mathf.Max (contentSize.y, childUIGameObject.y + childUIGameObject.height);						
				}
		
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIGameObject childTransform = child.GetComponent<UIGameObject> ();							
						childTransform.y += (int)scrollPosition.y;
				}
								
		}
}