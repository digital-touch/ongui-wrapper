

using UnityEngine;
using System.Collections;

public class CenterContentUILayout : UILayout
{
	
		public override void Layout ()
		{
				
				UIGameObject uiGameObject = GetComponent<UIGameObject> ();
		
				contentSize.Set (uiGameObject.width, uiGameObject.height);
		
				for (int i = 0; i < 				
		     uiGameObject.numChildren; i++) {
			
						UIGameObject child = uiGameObject.getChild (i);
			
						if (child == null) {
								continue;
						}
			
						if (!child.includeInLayout) {
								continue;
						}
						
						child.x = (uiGameObject.width - child.width) / 2;
						child.y = (uiGameObject.height - child.height) / 2;
			
				}
		
		}
}
