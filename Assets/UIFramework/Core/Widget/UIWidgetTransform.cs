using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UIWidgetTransform : UIWidgetBehaviour
{
		public UIWidget getChildById (string id)
		{
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childWidget = child.GetComponent<UIWidget> ();
						if (childWidget.id == id) {
								return childWidget;
						}
				}
				return null;
		}

		public Matrix4x4 transformation = Matrix4x4.identity;
		
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
		int
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
						UIInvalidator.invalidate (widget, UIWidget.POSITION_FLAG);
				}
		}
	
		[SerializeField]
		int
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
						UIInvalidator.invalidate (widget, UIWidget.POSITION_FLAG);
				}
		}		

		[SerializeField]
		int
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
						UIInvalidator.invalidate (widget, UIWidget.SIZE_FLAG);
				}
		}	
	
		[SerializeField]
		int
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
						UIInvalidator.invalidate (widget, UIWidget.SIZE_FLAG);
				}
		}
	
		public bool isInvisible {
				get {
						return width == 0 || height == 0 || alpha == 0;
				}
		}
	
		override protected  void Awake ()
		{				
				base.Awake ();
				transform.hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector;
		}
	
		override protected  void OnDestroy ()
		{				
				base.OnDestroy ();
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
