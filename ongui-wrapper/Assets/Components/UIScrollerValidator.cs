using UnityEngine;
using System.Collections;

public class UIScrollerValidator : UIWidgetValidator
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   						
				UIScroller scroller = (UIScroller)widget;
				UILayout layout = widget.GetComponent<UILayout> ();
		
				bool isScrollPositionDirty = widgetInvalidator.isDirty (UIScroller.SCROLL_POSITION_FLAG);
		
				if (isScrollPositionDirty) {
						layout.scrollPosition.x = scroller.scrollPositionX;
						layout.scrollPosition.y = scroller.scrollPositionY;
						widgetInvalidator.clearDirty (UIScroller.SCROLL_POSITION_FLAG);								
				}										
				base.Validate ();
		
		}
}
