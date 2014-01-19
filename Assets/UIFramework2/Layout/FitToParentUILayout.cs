using UnityEngine;
using System.Collections;

public class FitToParentUILayout : UILayout
{
	
		public override void Layout ()
		{
				contentSize.Set (0, 0);
		
				UIGameObject uiGameObject = GetComponent<UIGameObject> ();
				UIGameObject parentTransform = transform.parent.GetComponent<UIGameObject> ();
		
				contentSize.x = parentTransform.width;
				contentSize.y = parentTransform.height;
				uiGameObject.width = (int)contentSize.x;
				uiGameObject.height = (int)contentSize.y;
		}
	
}
