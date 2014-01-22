using UnityEngine;
using System.Collections;

public class AnchorUILayout : UILayout
{

		public override void Layout ()
		{			
				if (uiGameObject == null) {					
						return;
				}		
				
				contentSize.Set (0, 0);
		
				UIGameObject targetTransform;

		
				for (int i = 0; i < uiGameObject.numChildren; i++) {
						
						
						UIGameObject child = uiGameObject.getChild (i);
						
						if (!child.includeInLayout) {
								continue;
						}

						if (!child.enabled) {
								continue;
						}

						if (!child.gameObject.activeSelf) {
								continue;
						}
						
						AnchorUILayoutData data = child.GetComponent<AnchorUILayoutData> ();
						
						if (data == null) {
								continue;
						}
												
						if (data.leftAnchor) {
								if (data.leftTarget) {
										targetTransform = data.leftTarget.GetComponent<UIGameObject> ();
										child.x = (int)data.left + targetTransform.x + targetTransform.width;
								} else {
										child.x = (int)data.left;
								}
						}
						if (data.topAnchor) {
								if (data.topTarget) {
										targetTransform = data.topTarget.GetComponent<UIGameObject> ();
										child.y = (int)data.top + targetTransform.y + targetTransform.height;
								} else {
										child.y = (int)data.top;
								}
						}

						if (data.rightAnchor) {
								if (data.rightTarget) {
										throw new UnityException ("not implemented");
								} else {
										if (data.leftAnchor) {
												child.width = (int)((uiGameObject.width - child.x) - data.right);
										} else {
												child.x = (int)((uiGameObject.width - child.width) - data.right);
										}
								}
						}

						if (data.bottomAnchor) {
								if (data.bottomTarget) {
										throw new UnityException ("not implemented");
								} else {
										if (data.topAnchor) {
												child.height = (int)((uiGameObject.height - child.y) - data.bottom);
										} else {
												
												child.y = (int)((uiGameObject.height - child.height) - data.bottom);
										}
					
								}
						}

						if (data.horizontalAnchor) {
								if (data.horizontalTarget) {
										targetTransform = data.verticalTarget.GetComponent<UIGameObject> ();
										child.x = (int)(data.horizontal + targetTransform.x + (targetTransform.width / 2) - (child.width / 2));
								} else {
										child.x = (int)(data.horizontal + (uiGameObject.width / 2) - (child.width / 2));
								}
						}	

						if (data.verticalAnchor) {
								if (data.verticalTarget) {
										targetTransform = data.verticalTarget.GetComponent<UIGameObject> ();
										child.y = (int)(data.vertical + targetTransform.y + (targetTransform.height / 2) - (child.height / 2));
								} else {
										child.y = (int)(data.vertical + (uiGameObject.height / 2) - (child.height / 2));
								}				                          
						}				                          

						child.x += (int)scrollPosition.x;
						child.y += (int)scrollPosition.y;
			
						contentSize.x = Mathf.Max (contentSize.x, child.x + child.width);
						contentSize.y = Mathf.Max (contentSize.y, child.y + child.height);
			
				}
			
		}
}
