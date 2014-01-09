using UnityEngine;
using System.Collections;

public class UIScrollerValidator : UIWidgetValidator
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   				
				if (!gameObject.activeSelf) {					
						return;
				}
				
				UIScroller scroller = (UIScroller)widget;
				UILayout layout = widget.GetComponent<UILayout> ();
		
				bool isScrollPositionDirty = UIInvalidator.isInvalid (widget, UIScroller.SCROLL_POSITION_FLAG);
		
				if (isScrollPositionDirty) {
						layout.scrollPosition.x = scroller.scrollPositionX;
						layout.scrollPosition.y = scroller.scrollPositionY;
						
				}										
				base.Validate ();
		
		}
}
