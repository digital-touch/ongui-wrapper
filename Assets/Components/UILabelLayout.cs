using UnityEngine;
using System.Collections;

public class UILabelLayout : UILayout
{
		[SerializeField]
		public bool
				explicitWidth = false;

	
		public override ContentSize Layout ()
		{		
				UILabel label = (UILabel)widget;
				contentSize.Set (0, 0);
				if (!explicitWidth) {
						Vector2 s = label.style.CalcSize (label.content);
						contentSize.width = (int)s.x;
						contentSize.height = (int)s.y;
				} else {
						contentSize.width = widgetTransform.width;
						contentSize.height = (int)label.style.CalcHeight (label.content, widgetTransform.width);
				}
		
				return contentSize;
		}
	
		
}
