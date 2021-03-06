using UnityEngine;
using System.Collections;

public class AnchorUILayout : UILayout
{

		public override void Layout ()
		{			
				contentSize.Set (0, 0);
		
				UIWidget targetTransform;

				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childTransform = child.GetComponent<UIWidget> ();
						if (widget == null) {
								continue;
						}
						if (!widget.includeInLayout) {
								continue;
						}
						
						AnchorUILayoutData data = child.GetComponent<AnchorUILayoutData> ();
						if (data == null) {
								continue;
						}
												
						

						if (data.leftAnchor) {
								if (data.leftTarget) {
										targetTransform = data.leftTarget.GetComponent<UIWidget> ();
										childTransform.x = (int)data.left + targetTransform.x + targetTransform.width;
								} else {
										childTransform.x = (int)data.left;
								}
						}
						if (data.topAnchor) {
								if (data.topTarget) {
										targetTransform = data.topTarget.GetComponent<UIWidget> ();
										childTransform.y = (int)data.top + targetTransform.y + targetTransform.height;
								} else {
										childTransform.y = (int)data.top;
								}
						}

						if (data.rightAnchor) {
								if (data.rightTarget) {
										throw new UnityException ("not implemented");
								} else {
										if (data.leftAnchor) {
												childTransform.width = (int)((widget.width - childTransform.x) - data.right);
										} else {
												childTransform.x = (int)((widget.width - childTransform.width) - data.right);
										}
								}
						}

						if (data.bottomAnchor) {
								if (data.bottomTarget) {
										throw new UnityException ("not implemented");
								} else {
										if (data.topAnchor) {
												childTransform.height = (int)((widget.height - childTransform.y) - data.bottom);
										} else {
												
												childTransform.y = (int)((widget.height - childTransform.height) - data.bottom);
										}
					
								}
						}

						if (data.horizontalAnchor) {
								if (data.horizontalTarget) {
										targetTransform = data.verticalTarget.GetComponent<UIWidget> ();
										childTransform.x = (int)(data.horizontal + targetTransform.x + (targetTransform.width / 2) - (childTransform.width / 2));
								} else {
										childTransform.x = (int)(data.horizontal + (widget.width / 2) - (childTransform.width / 2));
								}
						}	

						if (data.verticalAnchor) {
								if (data.verticalTarget) {
										targetTransform = data.verticalTarget.GetComponent<UIWidget> ();
										childTransform.y = (int)(data.vertical + targetTransform.y + (targetTransform.height / 2) - (childTransform.height / 2));
								} else {
										childTransform.y = (int)(data.vertical + (widget.height / 2) - (childTransform.height / 2));
								}				                          
						}				                          

						childTransform.x += (int)scrollPosition.x;
						childTransform.y += (int)scrollPosition.y;
			
						contentSize.width = Mathf.Max (contentSize.width, childTransform.x + childTransform.width);
						contentSize.height = Mathf.Max (contentSize.height, childTransform.y + childTransform.height);
			
				}
			
		}
}
