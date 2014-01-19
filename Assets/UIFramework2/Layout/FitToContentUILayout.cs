using UnityEngine;
using System.Collections;

public class FitToContentUILayout : UILayout
{
		
		public override void Layout ()
		{
		
				contentSize.Set (0, 0);
				
				UIGameObject uiGameObject = GetComponent<UIGameObject> ();
				
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);						
						UIGameObject childTransform = child.GetComponent<UIGameObject> ();
						if (childTransform == null) {
								continue;
						}
			
						contentSize.x = Mathf.Max (contentSize.x, childTransform.x + childTransform.width);
						
						contentSize.y = Mathf.Max (contentSize.y, childTransform.y + childTransform.height);
						
				}
				
				uiGameObject.width = (int)contentSize.x;
				uiGameObject.height = (int)contentSize.y;
				
		}
}
