using UnityEngine;
using System.Collections;

public class FitToContent : UILayout
{
		
		public override void Layout ()
		{
		
				contentSize.Set (0, 0);
				
				for (int i = 0; i < widget.transform.childCount; i++) {
						Transform child = widget.transform.GetChild (i);						
						UIWidget childTransform = child.GetComponent<UIWidget> ();
						if (childTransform == null) {
								continue;
						}
			
						contentSize.width = Mathf.Max (contentSize.width, childTransform.x + childTransform.width);
						
						contentSize.height = Mathf.Max (contentSize.height, childTransform.y + childTransform.height);
						
				}
				
				widget.width = contentSize.width;
				widget.height = contentSize.height;
				
		}
}
