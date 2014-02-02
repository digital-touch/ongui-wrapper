using UnityEngine;
using System.Collections;

public class CenterInParentUILayout : UILayout {

	public bool vertically = true;
	public bool horizontally = true;

	public override void Layout ()
	{

		setContentSize (0, 0);


		UIGameObject uiGameObject = GetComponent<UIGameObject> ();

		UIGameObject parentTransform = transform.parent.GetComponent<UIGameObject> ();
		
		setContentSize (parentTransform.width, parentTransform.height);

		if (horizontally) {
						uiGameObject.x = (int)((contentSize.x - uiGameObject.width) / 2);
				}
		if (vertically) {
						uiGameObject.y = (int)((contentSize.y - uiGameObject.height) / 2);
				}
		
	}
}
