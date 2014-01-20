using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

[ExecuteInEditMode]
public class UIWidget : MonoBehaviour
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public static readonly string LAYOUT_INVALIDATION_FLAG = "uiwidget-layout";
		public static readonly string POSITION_INVALIDATION_FLAG = "uiwidget-position";
		public static readonly string SIZE_INVALIDATION_FLAG = "uiwidget-size";
		public static readonly string DATA_INVALIDATION_FLAG = "uiwidget-data";
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	#if UNITY_EDITOR
	
		[MenuItem("UI/UIWidget")]
		public static GameObject createUIWidget ()
		{
				GameObject widget = new GameObject ("UIWidget");				
				UIWidget uiWidget = widget.AddComponent<UIWidget> ();
				uiWidget.width = 100;
				uiWidget.height = 100;
				
				widget.transform.parent = Selection.activeTransform;
				return widget;
		}
	
	#endif
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		Tool LastTool = Tool.None;
	
		void OnEnable ()
		{
		
				LastTool = Tools.current;
		
				Tools.current = Tool.None;
		
		}
	
		void OnDisable ()
		{
		
				Tools.current = LastTool;
		
		}
	
	#endif
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		public string
				id;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		public bool
				includeInLayout = true;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		protected virtual void Awake ()
		{				
			
				transform.hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector;	
				UIInvalidator.invalidate (gameObject, UIInvalidator.ALL_INVALIDATION_FLAG);
		}
	
		protected virtual void OnDestroy ()
		{				
											
				transform.hideFlags = HideFlags.None;	
		}			
	
	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIWidget> AddedEvent;
		public Action<UIWidget> RemovedEvent;
	
		UIWidget _parent;
	
		public virtual UIWidget parent {		
				get {
						return _parent;
				}	
				set {
						if (_parent == value) {
								return;
						}
						if (_parent != null) {
								if (RemovedEvent != null) {
										RemovedEvent (this);
								}						
								root = null;
						}
			
						_parent = value;
			
						if (_parent != null) {
								if (AddedEvent != null) {
										AddedEvent (this);
								}			
								root = _parent.root;			
						}
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIWidget> AddedToRootEvent;
		public Action<UIWidget> RemovedFromRootEvent;
	
		UIRoot _root;
	
		public virtual UIRoot root {		
				get {
						return _root;
				}	
				set {
						if (_root == value) {
								return;
						}
						if (_root != null) {
								if (RemovedFromRootEvent != null) {
										RemovedFromRootEvent (this);
								}						
						}
						
						_root = value;
						
						if (_root != null) {
								if (AddedToRootEvent != null) {
										AddedToRootEvent (this);
								}						
						}
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		object
				_data;
	
		public object data {
				get {
						return _data;
				}
				set {
						if (_data == value) {
								return;
						}
						_data = value;
						UIInvalidator.invalidate (gameObject, DATA_INVALIDATION_FLAG);                                   
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public void toFront ()
		{
//				Transform parent = transform.parent;
//				// store references
//				List<Transform> list = new List<Transform> ();
//				int count = parent.childCount;
//				for (int i = 0; i < count; i++) {				
//						Transform child = parent.GetChild (i);
//						list.Add (child);
//				}
//		
//				// detach				
//				for (int i = 0; i < list.Count; i++) {
//						Transform child = list [i];
//						child.parent = null;
//				}
//		
//				//sort
//				int index = list.IndexOf (transform);				
//				if (index < list.Count - 1) {
//						list.Remove (transform);
//						list.Insert (index + 1, transform);
//				}
//		
//				//attach		
//				for (int i = 0; i < list.Count; i++) {
//						Transform child = list [i];
//						child.parent = parent;
//				}
		}
	
		public void toBack ()
		{
//				Transform parent = transform.parent;
//				// store references
//				List<Transform> list = new List<Transform> ();
//				int count = parent.childCount;
//				for (int i = 0; i < count; i++) {				
//						Transform child = parent.GetChild (i);
//						list.Add (child);
//				}
//		
//				// detach				
//				for (int i = 0; i < list.Count; i++) {
//						Transform child = list [i];
//						child.parent = null;
//				}
//		
//				//sort
//				int index = list.IndexOf (transform);				
//				if (index > 0) {
//						list.Remove (transform);
//						list.Insert (index - 1, transform);
//				}
//		
//				//attach		
//				for (int i = 0; i < list.Count; i++) {
//						Transform child = list [i];
//						child.parent = parent;
//				}
		}
	
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

		///////////////////////////////////////////////////////////////////////////////////////////////////	
		
		public Rect screenBounds = new Rect ();	

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
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

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		public float
				alpha = 1;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		public Color
				tint = Color.white;
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		protected bool canInvalidate = true;
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
    
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
						if (canInvalidate) {
								UIInvalidator.invalidate (gameObject, UIWidget.POSITION_INVALIDATION_FLAG);
						}
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
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
						if (canInvalidate) {
								UIInvalidator.invalidate (gameObject, UIWidget.POSITION_INVALIDATION_FLAG);
						}
				}
		}	
		
		///////////////////////////////////////////////////////////////////////////////////////////////////	

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
						if (canInvalidate) {
								UIInvalidator.invalidate (gameObject, UIWidget.SIZE_INVALIDATION_FLAG);						
						}						
				}
		}	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
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
						if (canInvalidate) {
								UIInvalidator.invalidate (gameObject, UIWidget.SIZE_INVALIDATION_FLAG);						
						}
				}
		}
	
		public bool isInvisible {
				get {
						return width == 0 || height == 0 || alpha == 0;
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		public float
				rotation = 0f;

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		public Vector2
				rotationPivotPoint = Vector2.zero;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		public 	Vector2
				scale = Vector2.one;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		public Vector2
				scalePivotPoint = Vector2.zero;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public Vector2 globalToLocal (Vector2 position)
		{
				Vector2 global = Vector2.zero;
				
				Transform parent = transform.parent;				
				while (parent != null) {
				
						UIWidget parentTransform = parent.GetComponent<UIWidget> ();
			
						global.x -= parentTransform.x;
						global.y -= parentTransform.y;
									
						parent = parent.parent;						
				}
				global.x += position.x;
				global.y += position.y;
		
				return global;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public Vector2 localToGlobal (Vector2 position)
		{
				Vector2 local = Vector2.zero;
		
				Transform parent = transform.parent;				
				while (parent != null) {
			
						UIWidget parentTransform = parent.GetComponent<UIWidget> ();
			
						local.x += parentTransform.x;
						local.y += parentTransform.y;
			
						parent = parent.parent;						
				}
				local.x += position.x;
				local.y += position.y;
		
				return local;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public virtual void Validate ()
		{		
				if (!gameObject.activeSelf) {					
						return;
				}	
		
				validateTransformParent ();
				ValidateScreenBounds ();													
				validateLayout ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public virtual void validateLayout ()
		{
				bool isLayoutDirty = UIInvalidator.isInvalid (gameObject, UIWidget.LAYOUT_INVALIDATION_FLAG);
		
				if (!isLayoutDirty) {
						return;
				}
				
				UILayout[] widgetLayouts = GetComponents<UILayout> ();	
		
				for (int i = 0; i < widgetLayouts.Length; i++) {
						UILayout widgetLayout = widgetLayouts [i];
						widgetLayout.Layout ();
				}
				
				ValidateChildrenLayout ();
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void ValidateChildrenLayout ()
		{
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);		
						UILayout[] childLayouts = child.GetComponents<UILayout> ();
						foreach (UILayout childLayout in childLayouts) {
								childLayout.Layout ();
						}						
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void ValidateScreenBounds ()
		{
				bool isPositionDirty = UIInvalidator.isInvalid (gameObject, UIWidget.POSITION_INVALIDATION_FLAG);
				bool isSizeDirty = UIInvalidator.isInvalid (gameObject, UIWidget.SIZE_INVALIDATION_FLAG);
				
				if (isPositionDirty || isSizeDirty) {
						screenBounds.Set (x, y, width, height);			
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
		Transform lastTransformParent;
	
		void validateTransformParent ()
		{
				if (lastTransformParent == transform.parent) {
						return;
				}
				
				if (lastTransformParent != null) {
						parent = null;
				}
				
				lastTransformParent = transform.parent;
				
				if (lastTransformParent != null) {
						parent = lastTransformParent.GetComponent<UIWidget> ();
				}
		}
	
		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		public bool
				isTouchable = true;
	
	
		Rect tempRect = new Rect ();
	
		public virtual bool HitTest (UITouch touch)
		{				
				Vector2 global = globalToLocal (touch.position);
				tempRect.Set (x, y, width, height);
				bool contains = tempRect.Contains (global);
				return contains;
		}
	
		public Action<UIWidget, UITouch> TouchBeganEvent;
		public Action<UIWidget, UITouch> TouchMovedEvent;
		public Action<UIWidget, UITouch> TouchEndedEvent;
		public Action<UIWidget, UITouch> TouchCancelledEvent;
	
		public virtual void TouchBegan (UITouch touch)
		{						
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childWidget = child.GetComponent<UIWidget> ();
						if (childWidget == null) {
								continue;
						}			
						if (!childWidget.isTouchable) {
								continue;
						}
						if (!childWidget.HitTest (touch)) {
								continue;
						}
			
						childWidget.TouchBegan (touch);
				}
		
				if (TouchBeganEvent != null) {
						TouchBeganEvent (this, touch);
				}
		
		} 
	
		public virtual void TouchMoved (UITouch touch)
		{
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childWidget = child.GetComponent<UIWidget> ();
						if (childWidget == null) {
								continue;
						}	
						if (!childWidget.isTouchable) {
								continue;
						}
						if (!childWidget.HitTest (touch)) {
								continue;
						}
						childWidget.TouchMoved (touch);
				}
				if (TouchMovedEvent != null) {
						TouchMovedEvent (this, touch);
				}
		} 
	
		public virtual void TouchEnded (UITouch touch)
		{
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childWidget = child.GetComponent<UIWidget> ();
						if (childWidget == null) {
								continue;
						}	
						if (!childWidget.isTouchable) {
								continue;
						}
						if (!childWidget.HitTest (touch)) {
								continue;
						}
						childWidget.TouchEnded (touch);
				}
				if (TouchEndedEvent != null) {
						TouchEndedEvent (this, touch);
				}
		} 
	
		public virtual void TouchCancelled (UITouch touch)
		{
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childWidget = child.GetComponent<UIWidget> ();
						if (childWidget == null) {
								continue;
						}	
						if (!childWidget.isTouchable) {
								continue;
						}
						if (!childWidget.HitTest (touch)) {
								continue;
						}
						childWidget.TouchCancelled (touch);
				}
				if (TouchCancelledEvent != null) {
						TouchCancelledEvent (this, touch);
				}
		} 
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
	
		public virtual void Draw (UIWidget parentWidget)
		{
		
				GUI.BeginGroup (screenBounds);
		
				DrawChildren (parentWidget);
		
				GUI.EndGroup ();
		}
	
		protected  void DrawChildren (UIWidget parentWidget)
		{
				for (int i = 0; i < transform.childCount; i++) {
						DrawChild (i, parentWidget);
				}
		}
	
		protected  void DrawChild (int i, UIWidget parentWidget)
		{
				Transform child = transform.GetChild (i);
		
				UIWidget childWidget = child.GetComponent<UIWidget> ();
		
				if (childWidget == null) {
						return;
				}						
		
				
		
				if (!childWidget.isVisible) {
						return;
				}												
		
				if (childWidget.isInvisible) {
						return;
				}
		
				if (!child.gameObject.activeSelf) {					
						return;
				}
		
				Color old = GUI.color;
		
				Color newColor;
				
				if (parentWidget != null) {
						newColor = childWidget.tint * parentWidget.tint;
						newColor.a = GUI.color.a * childWidget.alpha * parentWidget.alpha;
				} else {
						newColor = childWidget.tint;
						newColor.a = GUI.color.a * childWidget.alpha;
				}
				
				GUI.color = newColor;
		
				if (childWidget.rotation != 0f || (childWidget.scale.x != 1 && childWidget.scale.y != 1)) {
						Matrix4x4 matrix = GUI.matrix;						
			
						GUIUtility.RotateAroundPivot (childWidget.rotation, childWidget.rotationPivotPoint);
						GUIUtility.ScaleAroundPivot (childWidget.scale, childWidget.scalePivotPoint);
			
						childWidget.Draw (this);
			
						GUI.matrix = matrix;
				} else {
						childWidget.Draw (this);
				}
		
				GUI.color = old;
		}
}
