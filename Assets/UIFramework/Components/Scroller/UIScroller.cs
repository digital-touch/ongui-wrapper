using UnityEngine;
using UnityEditor;
using System.Collections;

public class UIScroller : UIWidget
{

		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public static readonly string SCROLL_POSITION_FLAG = "uiscroller-scroll-position";	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	#if UNITY_EDITOR
	
		[MenuItem("UI/UIScroller")]
		public static GameObject createUIScroller ()
		{
				GameObject widget = new GameObject ("UIScroller");
				
				UIWidgetTransform widgetTransform = widget.AddComponent<UIWidgetTransform> ();
				widgetTransform.width = 100;
				widgetTransform.height = 100;
				widget.AddComponent<UIScroller> ();
				widget.AddComponent<UIScrollerValidator> ();
				widget.AddComponent<UIScrollerRenderer> ();
				widget.AddComponent<UIScrollerInteraction> ();								
				widget.transform.parent = Selection.activeTransform;
				return widget;
		}
	
	#endif

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		float
				_scrollPositionY = 0;
	
		public float scrollPositionY {
				get {
						return _scrollPositionY;
				}
				set {
						if (_scrollPositionY == value) {
								return;
						}
						_scrollPositionY = value;
						UIInvalidator.invalidate (this, SCROLL_POSITION_FLAG);
				}
		}
	
		float _scrollPositionX = 0;
	
		public float scrollPositionX {
				get {
						return _scrollPositionX;
				}
				set {
						if (_scrollPositionX == value) {
								return;
						}
						_scrollPositionX = value;
						UIInvalidator.invalidate (this, SCROLL_POSITION_FLAG);
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		float _throwDrag = 0.97f;

		public float throwDrag {
				get {
						return _throwDrag;
				}
				set {
						if (_throwDrag == value) {
								return;
						}
						_throwDrag = value;
						UIInvalidator.invalidate (this, SCROLL_POSITION_FLAG);
				}
		}
}
