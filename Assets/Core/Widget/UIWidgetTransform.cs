using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UIWidgetTransform : MonoBehaviour
{
		public Rect screenBounds = new Rect ();	

		[SerializeField]
		bool
				_isVisible = true;
				
		public bool isVisible {
				get {
						return _isVisible;
				}
				set {
						if (_isVisible == value) {
								return;
						}
						_isVisible = value;
				}
		}

	
	
		[SerializeField]
		public float
				alpha = 1;
	
		[SerializeField]
		public Color
				tint = Color.white;
		
		[SerializeField]
		public int
				_x;

		public int x {
				get {
						return _x;
				}
				set {
						if (_x == value) {
								return;
						}
						_x = value;
						widgetInvalidator.setDirty (UIWidget.POSITION_FLAG);
				}
		}
	
		[SerializeField]
		public int
				_y;

		public int y {
				get {
						return _y;
				}
				set {
						if (_y == value) {
								return;
						}
						_y = value;
						widgetInvalidator.setDirty (UIWidget.POSITION_FLAG);
				}
		}		

		[SerializeField]
		public int
				_width;

		public int width {
				get {
						return _width;
				}
				set {
						if (_width == value) {
								return;
						}
						_width = value;
						widgetInvalidator.setDirty (UIWidget.SIZE_FLAG);
				}
		}	
	
		[SerializeField]
		public int
				_height;

		public int height {
				get {
						return _height;
				}
				set {
						if (_height == value) {
								return;
						}
						_height = value;
						widgetInvalidator.setDirty (UIWidget.SIZE_FLAG);
				}
		}
	
		public bool isInvisible {
				get {
						return width == 0 || height == 0 || alpha == 0;
				}
		}
	
		protected UIWidget widget;		
		protected UIWidgetInvalidator widgetInvalidator;
	
		protected virtual void Awake ()
		{
				widgetInvalidator = GetComponent<UIWidgetInvalidator> ();
				widget = GetComponent<UIWidget> ();
				transform.hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector;
		}
	
		protected virtual void OnDestroy ()
		{
				widgetInvalidator = null;
				widget = null;
				transform.hideFlags = HideFlags.None;
		}
	
		[SerializeField]
		public float
				rotation = 0f;

		[SerializeField]
		public Vector2
				rotationPivotPoint = Vector2.zero;
		
		[SerializeField]
		public 	Vector2
				scale = Vector2.one;
		
		[SerializeField]
		public Vector2
				scalePivotPoint = Vector2.zero;
	
		
		public Vector2 globalToLocal (Vector2 position)
		{
				Vector2 global = Vector2.zero;
				
				Transform parent = transform.parent;				
				while (parent != null) {
				
						UIWidgetTransform parentTransform = parent.GetComponent<UIWidgetTransform> ();
			
						global.x -= parentTransform.x;
						global.y -= parentTransform.y;
									
						parent = parent.parent;						
				}
				global.x += position.x;
				global.y += position.y;
		
				return global;
		}
		
		public Vector2 localToGlobal (Vector2 position)
		{
				Vector2 local = Vector2.zero;
		
				Transform parent = transform.parent;				
				while (parent != null) {
			
						UIWidgetTransform parentTransform = parent.GetComponent<UIWidgetTransform> ();
			
						local.x += parentTransform.x;
						local.y += parentTransform.y;
			
						parent = parent.parent;						
				}
				local.x += position.x;
				local.y += position.y;
		
				return local;
		}
		
		public UIRootTransform rootTransform {
				get {
						Transform parent = transform.parent;
						while (parent != null) {
								if (parent.parent == null) {
										return parent.GetComponent<UIRootTransform> ();
								} else {
										parent = parent.parent;
								}
						}
						throw new UnityException ("no UIRoot");
				}
		}
}
