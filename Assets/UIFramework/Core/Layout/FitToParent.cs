using UnityEngine;
using System.Collections;

public class FitToParent : UILayout
{
	
		public override void Layout ()
		{
				contentSize.Set (0, 0);
		
				UIWidgetTransform parentTransform = widget.parent.GetComponent<UIWidgetTransform> ();
				contentSize.width = parentTransform.width;
				contentSize.height = parentTransform.height;
				widgetTransform.width = contentSize.width;
				widgetTransform.height = contentSize.height;
		}
	
}
