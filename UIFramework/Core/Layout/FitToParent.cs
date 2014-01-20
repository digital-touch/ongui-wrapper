using UnityEngine;
using System.Collections;

public class FitToParent : UILayout
{
	
		public override void Layout ()
		{
				contentSize.Set (0, 0);
		
				UIWidget parentTransform = widget.parent.GetComponent<UIWidget> ();
				contentSize.width = parentTransform.width;
				contentSize.height = parentTransform.height;
				widget.width = contentSize.width;
				widget.height = contentSize.height;
		}
	
}
