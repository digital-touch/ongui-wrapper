

using UnityEngine;
using System.Collections;

public class CenterContentUILayout : UILayout
{
	
		public override void Layout ()
		{
				
				UIGameObject uiGameObject = GetComponent<UIGameObject> ();
		
		
		
				float contentWidth = uiGameObject.width;
				float contentHeight = uiGameObject.height;
				
				setContentSize (contentWidth, contentHeight);
		
		
		
				for (int i = 0; i < uiGameObject.numChildren; i++) {
			
						UIGameObject child = uiGameObject.getChild (i);
			
						if (child == null) {
								continue;
						}
			
						if (!child.includeInLayout) {
								continue;
						}
						
						child.x = (int) (uiGameObject.width - child.width) / 2;
			child.y = (int)(uiGameObject.height - child.height) / 2;
			
				}
		
		}
}
