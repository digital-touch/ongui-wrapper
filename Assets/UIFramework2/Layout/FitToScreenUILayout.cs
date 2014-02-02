using UnityEngine;
using System.Collections;

public class FitToScreenUILayout : UILayout
{
		
		public override void Layout ()
		{
						
				setContentSize (Screen.width, Screen.height);
		
				UIGameObject uiGameObject = GetComponent<UIGameObject> ();		

				if (uiGameObject.width != contentSize.x) {
						
						uiGameObject.width = (int)contentSize.x;
				}
				if (uiGameObject.height != contentSize.y) {
						
						uiGameObject.height = (int)contentSize.y;
				}
				
		}
	
}