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
				widget.name = "UIScroller";
		
				UIScroller uiScroller = widget.AddComponent<UIScroller> ();
				uiScroller.width = 100;
				uiScroller.height = 100;
				

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
						UIInvalidator.invalidate (gameObject, SCROLL_POSITION_FLAG);
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
						UIInvalidator.invalidate (gameObject, SCROLL_POSITION_FLAG);
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
						UIInvalidator.invalidate (gameObject, SCROLL_POSITION_FLAG);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   				
				if (!gameObject.activeSelf) {					
						return;
				}
		
				
				UILayout layout = GetComponent<UILayout> ();
		
				bool isScrollPositionDirty = UIInvalidator.isInvalid (gameObject, UIScroller.SCROLL_POSITION_FLAG);
		
				if (isScrollPositionDirty) {
						layout.scrollPosition.x = scrollPositionX;
						layout.scrollPosition.y = scrollPositionY;
			
				}										
				base.Validate ();
		
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		Vector2 startPosition;
		Vector2 deltaPosititon;
		Vector2 lastPosition;
	
		protected override void Awake ()
		{
				base.Awake ();
				TouchBeganEvent += OnTouchBegan;
				TouchMovedEvent += OnTouchMoved;
				TouchEndedEvent += OnTouchEnded;
		}
	
		protected override void OnDestroy ()
		{
				TouchBeganEvent -= OnTouchBegan;
				TouchMovedEvent -= OnTouchMoved;
				TouchEndedEvent -= OnTouchEnded;
				base.OnDestroy ();
		}
	
		void OnTouchBegan (UIWidget target, UITouch touch)
		{
				lastPosition = touch.position;
				startPosition = touch.position;				
		
		}	
	
		void OnTouchMoved (UIWidget target, UITouch touch)
		{
				
				deltaPosititon = lastPosition - touch.position;
				lastPosition = touch.position;
				scrollPositionX -= deltaPosititon.x;
				scrollPositionY -= deltaPosititon.y;
		
		}
	
		void OnTouchEnded (UIWidget target, UITouch touch)
		{
				ThrowScroll ();
		}
	
		bool isThrowing = false;
	
		void Update ()
		{
				if (isThrowing) {
						
			
						scrollPositionX -= deltaPosititon.x / 8;
						scrollPositionY -= deltaPosititon.y / 8;
						deltaPosititon *= 0.95f;
			
						if (deltaPosititon.magnitude == 0) {
								isThrowing = false;
						}
				}
		}
	
		void ThrowScroll ()
		{		
				if ((deltaPosititon.magnitude > 0) && !isThrowing) {
						isThrowing = true;
			
				}
		}
}
