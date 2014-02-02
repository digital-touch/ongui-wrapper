using UnityEngine;
using System.Collections;

public class FitToContentUILayout : UILayout
{
		
		public override void Layout ()
		{
		
				setContentSize (0, 0);						
		
				UIGameObject uiGameObject = GetComponent<UIGameObject> ();
				
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);						
						UIGameObject childTransform = child.GetComponent<UIGameObject> ();
						if (childTransform == null) {
								continue;
						}
			
						float contentWidth = Mathf.Max (contentSize.x, childTransform.x + childTransform.width);
						float contentHeight = Mathf.Max (contentSize.y, childTransform.y + childTransform.height);
			
						setContentSize (contentWidth, contentHeight);
						
				}
				
				uiGameObject.width = (int)contentSize.x;
				uiGameObject.height = (int)contentSize.y;
				
		}
}
