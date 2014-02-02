using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]
public class UIGameObject : BindableObject
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIGameObject> ChildAddedToRootEvent;
	
		public void FireChildAddedToRootEvent (UIGameObject child)
		{
				if (ChildAddedToRootEvent != null) {
						ChildAddedToRootEvent (child);
				}				
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIGameObject> ChildRemovedFromRootEvent;
	
		public void FireChildRemovedFromRootEvent (UIGameObject child)
		{
				if (ChildRemovedFromRootEvent != null) {
						ChildRemovedFromRootEvent (child);
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		UnityEditor.Tool LastTool = UnityEditor.Tool.None;
	
		void OnEnable ()
		{
		
				LastTool = UnityEditor.Tools.current;
		
				UnityEditor.Tools.current = UnityEditor.Tool.None;
		
		}
	
		void OnDisable ()
		{
		
				UnityEditor.Tools.current = LastTool;
		
		}
	
	#endif
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIGameObject> ResizeEvent;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIGameObject> AddedEvent;
		public Action<UIGameObject> RemovedEvent;
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		Transform _parent;

		[BindableAttribute]
		public virtual Transform parent {
				get {
						return _parent;
				}
				set {
						_parent = value;
				}
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		UIGameObject _parentUIGameObject;

		[BindableAttribute]
		public virtual UIGameObject parentUIGameObject {
				get {
						return _parentUIGameObject;
				}
				set {
						_parentUIGameObject = value;
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		UIRoot _root;

		public virtual UIRoot root {
				get {
						return _root;
				}
				set {
						_root = value;
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public virtual void Awake ()
		{
				#if UNITY_EDITOR
				transform.hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector;	
				#endif
				addToParent ();								
		}
		
		protected virtual void Start ()
		{
				invalidate ();	
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		/*protected virtual void Update ()
		{
				if (parent == transform.parent) {
						return;
				}
				removeFromParent ();
				addToParent ();		
		}*/	
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected virtual void OnDestroy ()
		{
				#if UNITY_EDITOR
				transform.hideFlags = HideFlags.None;	
				#endif
				removeFromParent ();
				
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void addToParent ()
		{				
				if (transform.parent == null) {
						return;
				}
				UIGameObject newParentUIGameObject = transform.parent.GetComponent<UIGameObject> ();
				if (newParentUIGameObject == null) {
						return;
				}
				parent = transform.parent;
				parentUIGameObject = newParentUIGameObject;
				parentUIGameObject.addChild (this);
				if (AddedEvent != null) {
						AddedEvent (this);
				}				
		}
		
		void removeFromParent ()
		{
				if (parentUIGameObject != null) {						
						parentUIGameObject.removeChild (this);
						if (RemovedEvent != null) {
								RemovedEvent (this);
						}
				}
				parent = null;
				parentUIGameObject = null;						
		
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
				
		[SerializeField]
		int
				_depth = -1;
				
		[BindableAttribute]
		public virtual int depth {
				get {
						return _depth;
				}
				set {
						if (_depth == value) {
								return;
						}
						_depth = value;
				}
		}
		
		protected List<UIGameObject> children = new List<UIGameObject> ();
		
		public virtual void addChild (UIGameObject child)
		{
				if (child.depth == -1) {
						child.depth = children.Count;
				}
				children.Add (child);			
				child.MoveEvent += onChildMove;	
				child.ResizeEvent += onChildResize;
				
				if (root != null) {
						child.root = root;
						root.FireChildAddedToRootEvent (child);
						child.FireChildAddedToRootEvent (child);
				}							
				invalidate ();
		}
		
		public virtual void removeChild (UIGameObject child)
		{
				child.depth = -1;			
				children.Remove (child);
				child.MoveEvent -= onChildMove;	
				child.ResizeEvent -= onChildResize;
				
				if (child.root != null) {
						child.root.FireChildRemovedFromRootEvent (child);
						child.FireChildRemovedFromRootEvent (child);
						child.root = null;
				}
				invalidate ();
		}
				
		public virtual int numChildren {
				get {
						return children.Count;
				}
		}
		
		public virtual int getChildIndex (UIGameObject child)
		{
		
				return children.IndexOf (child);
				
		}
		
		public virtual UIGameObject getChild (int index)
		{
			
				return children [index];
			
		}
		
		public virtual UIGameObject getChildById (string name)
		{
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];			
						if (child.name == name) {
								return child;
						}
				}
				return null;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		bool
				_clipContent = false;
				
		[BindableAttribute]
		public virtual bool clipContent {
				get {
						return _clipContent;
				}
				set {
						if (_clipContent == value) {
								return;
						}
						_clipContent = value;
						invalidate ();
				}
		}		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
			
		Vector2 scaleHelper = Vector2.zero;
			
		public virtual void draw (UIGameObject parent)
		{
		
				
				GUI.BeginGroup (screenRect);
								
				
		
		drawChildren (parent);
								
				GUI.EndGroup ();
				
		}

	protected virtual void drawChildren(UIGameObject parent) {

		children.Sort (
			delegate(UIGameObject p1, UIGameObject p2) {
			return p1.depth.CompareTo (p2.depth);
		}
		);

		for (int i = 0; i < children.Count; i++) {
			
			UIGameObject child = children [i];
			
			drawChild (child, parent);
		}
	}

	[SerializeField]
	bool _manageChildrenVisibility = false;

	public bool manageChildrenVisibility {
		get {
			return _manageChildrenVisibility;
		}
		set {
			if (_manageChildrenVisibility == value) {
				return;
			}
			_manageChildrenVisibility = value;
			invalidate();
		}
	}

		protected void drawChild (UIGameObject child, UIGameObject parent)
		{
				if (child == null || !child.isVisible || child.alpha == 0 || !child.gameObject.activeSelf || !child.enabled) {
						return;
				}
		
				if (manageChildrenVisibility && !RectUtils.Intersect (screenRect, child.screenRect)) {												
						return;
				}
		
				Color old = GUI.color;
		
				Color newColor = Color.black;
		
				if (parent != null) {
			
						newColor.r = GUI.color.r * child.color.r * parent.color.r;
						newColor.g = GUI.color.g * child.color.g * parent.color.g;
						newColor.b = GUI.color.b * child.color.b * parent.color.b;
			
						newColor.a = GUI.color.a * child.alpha * parent.alpha;
				} else {
						newColor = child.color;
						newColor.a = GUI.color.a * child.alpha;
				}
		
				GUI.color = newColor;
		
				if (child.rotation != 0f || (child.scaleX != 1 && child.scaleY != 1)) {
			
						Vector2 rotationPivotTypePosition = pivotTypeToPosition (child.rotationPivotType, child);
						Vector2 scalePivotTypePosition = pivotTypeToPosition (child.rotationPivotType, child);
			
						Matrix4x4 matrix = GUI.matrix;						
						scaleHelper.Set (child.scaleX, child.scaleY);
			
						//Vector2 globalPosition = child.localToGlobal (child.position);
			
						GUIUtility.RotateAroundPivot (child.rotation, child.position + child.rotationPivot + rotationPivotTypePosition);
						GUIUtility.ScaleAroundPivot (scaleHelper, child.position + child.scalePivot + scalePivotTypePosition);
			
						child.draw (parent);
			
						GUI.matrix = matrix;
				} else {
						child.draw (parent);
				}
		
				GUI.color = old;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		public Vector2 globalToLocal (Vector2 position)
		{
				Vector2 global = Vector2.zero;
		
				Transform parent = transform.parent;				
				while (parent != null) {
			
						UIGameObject parentTransform = parent.GetComponent<UIGameObject> ();
			
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
			
						UIGameObject parentTransform = parent.GetComponent<UIGameObject> ();
			
						local.x += parentTransform.x;
						local.y += parentTransform.y;
			
						parent = parent.parent;						
				}
				local.x += position.x;
				local.y += position.y;
		
				return local;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		Vector2 pivotPositionHelper = Vector2.zero;
    
		Vector2 pivotTypeToPosition (PivotType pivotType, UIGameObject target)
		{
			
				switch (pivotType) {
				case PivotType.BOTTOM:
						pivotPositionHelper.Set (0.5f, 1);
						break;
				case PivotType.BOTTOM_LEFT:
						pivotPositionHelper.Set (1, 0.5f);
						break;
				case PivotType.BOTTOM_RIGHT:
						pivotPositionHelper.Set (1, 1);
						break;
				case PivotType.CENTER:
						pivotPositionHelper.Set (0.5f, 0.5f);
						break;
				case PivotType.LEFT:
						pivotPositionHelper.Set (0, 0.5f);
						break;
				case PivotType.RIGHT:
						pivotPositionHelper.Set (1, 0.5f);
						break;
				case PivotType.TOP:
						pivotPositionHelper.Set (0.5f, 0);
						break;
				case PivotType.TOP_LEFT:
						pivotPositionHelper.Set (0, 0);
						break;
				case PivotType.TOP_RIGHT:
						pivotPositionHelper.Set (1, 0);
						break;
				case PivotType.NONE:
						pivotPositionHelper.Set (0, 0);
						break;				
				}
			
				pivotPositionHelper.x *= target.width;
				pivotPositionHelper.y *= target.height;
				return pivotPositionHelper;
		}
    
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIGameObject> MoveEvent;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		protected Rect
				screenRect = new Rect ();
		
		[BindableAttribute]
		public virtual int x {
				set {
						if (screenRect.x == value) {
								return;
						}
						screenRect.x = value;
						_position.x = value;
						
						if (MoveEvent != null) {
								MoveEvent (this);
						}
				}
				get {
						return (int)screenRect.x;
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[BindableAttribute]
		public virtual int y {
				set {
						if (screenRect.y == value) {
								return;
						}
						screenRect.y = value;
						_position.y = value;
						
						if (MoveEvent != null) {
								MoveEvent (this);
						}
				}
				get {
						return (int)screenRect.y;
				}
		}
		
		Vector2 _position = Vector2.zero;
	
		[BindableAttribute]	
		public virtual Vector2 position {
				get {
						return _position;
				}
				set {
						setPosition ((int)value.x, (int)value.y);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[BindableAttribute]
		public virtual int width {
				set {
						if (screenRect.width == value) {
								return;
						}
						screenRect.width = value;
						
						if (ResizeEvent != null) {
								ResizeEvent (this);
						}
				}
				get {
						return (int)screenRect.width;
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[BindableAttribute]
		public virtual int height {
				set {
						if (screenRect.height == value) {
								return;
						}
						screenRect.height = value;
						
						if (ResizeEvent != null) {
								ResizeEvent (this);
						}
				}
				get {
						return (int)screenRect.height;
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		
		public virtual void setPosition (int x, int y)
		{
				bool moved = false;
				if (screenRect.x != x) {
						screenRect.x = x;
						_position.x = x;
						moved = true;
				}
				if (screenRect.y != y) {
						screenRect.y = y;
						_position.y = x;
						moved = true;
				}
				if (!moved) {
						return;
				}
				if (MoveEvent != null) {
						MoveEvent (this);
				}
				
		}
    
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public virtual void setSize (int width, int height)
		{
				bool resized = false;
				if (screenRect.width != width) {
						screenRect.width = width;
						resized = true;
				}
				
				if (screenRect.height != height) {
						screenRect.height = height;
						resized = true;
				}
				
				if (!resized) {
						return;
				}
		
				if (ResizeEvent != null) {
						ResizeEvent (this);
				}
			
				
		
		}
		
		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]	
		bool
				_includeInLayout = true;

		[BindableAttribute]
		public bool includeInLayout {
				get {
						return _includeInLayout;
				}
				set {
						if (_includeInLayout == value) {
								return;
						}
						_includeInLayout = value;
						invalidate ();
				}
		}
                
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public void  invalidate ()
		{
				if (root == null) {
						return;
				}
				
				root.invalidateTarget (this);				
		}
	
		public virtual void  validate ()
		{
		
				//Debug.Log (this + " validate");
				validateLayout ();			
				validateChildren ();
		}
		
		void validateChildren ()
		{
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
						child.validate ();
				}
		}
    
		bool ignoreChildChanges = false;
				
		void validateLayout ()
		{
				UILayout[] layouts = GetComponents<UILayout> ();
				
				if (layouts.Length == 0) {
						return;
				}
				
				ignoreChildChanges = true;
				
				for (int i = 0; i < layouts.Length; i++) {
						UILayout layout = layouts [i];
						layout.Layout ();
				}
				
				//childUIGameObject.isVisible = boundingContains(
				
				ignoreChildChanges = false;
								
		}
			
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		void onChildMove (UIGameObject child)
		{
				if (ignoreChildChanges) {
						return;
				}
				//invalidate ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////	
    
		void onChildResize (UIGameObject child)
		{
				if (ignoreChildChanges) {
						return;
				}
				invalidate ();
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		float
				_alpha = 1;

		[BindableAttribute]
		public float alpha {
				get {
						return _alpha;
				}
				set {
						if (_alpha == value) {
								return;
						}
						_alpha = value;
						invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		Color
				_color = Color.white;

		[BindableAttribute]
		public Color color {
				get {
						return _color;
				}
				set {
						if (_color == value) {
								return;
						}
						_color = value;
						invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		bool
				_isVisible = true;
		
		[BindableAttribute]
		public bool isVisible {
				get {
						return _isVisible;
				}
				set {
						if (_isVisible == value) {
								return;
						}
						_isVisible = value;
						invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
				
		public List<string>
				styleNames = new List<string> ();
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		float
				_rotation = 0;

		[BindableAttribute]
		public float rotation {
				get {
						return _rotation;
				}
				set {
						if (_rotation == value) {
								return;
						}
						_rotation = value;
						invalidate ();
				}
		}
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		float
				_scaleX = 1;

		[BindableAttribute]
		public float scaleX {
				get {
						return _scaleX;
				}
				set {
						if (_scaleX == value) {
								return;
						}
						_scaleX = value;
						invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		float
				_scaleY = 1;

		[BindableAttribute]
		public float scaleY {
				get {
						return _scaleY;
				}
				set {
						if (_scaleY == value) {
								return;
						}
						_scaleY = value;
						invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		Vector2
				_rotationPivot = Vector2.zero;
		
		[BindableAttribute]
		public Vector2 rotationPivot {
				get {
						return _rotationPivot;
				}
				set {
						if (_rotationPivot == value) {
								return;
						}
						_rotationPivot = value;
						invalidate ();
				}
		}

	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		PivotType
				_rotationPivotType = PivotType.NONE;

		[BindableAttribute]
		public PivotType rotationPivotType {
				get {
						return _rotationPivotType;
				}
				set {
						if (_rotationPivotType == value) {
								return;
						}
						_rotationPivotType = value;
						invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		[SerializeField]
		Vector2
				_scalePivot = Vector2.zero;
		
		[BindableAttribute]
		public Vector2 scalePivot {
				get {
						return _scalePivot;
				}
				set {
						if (_scalePivot == value) {
								return;
						}
						_scalePivot = value;
						invalidate ();
				}
		}

		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		PivotType
				_scalePivotType = PivotType.NONE;
	
		[BindableAttribute]
		public PivotType scalePivotType {
				get {
						return _scalePivotType;
				}
				set {
						if (_scalePivotType == value) {
								return;
						}
						_scalePivotType = value;
						invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		bool
				_isTouchable = true;

		[BindableAttribute]
		public bool isTouchable {
				get {
						return _isTouchable;
				}
				set {
						if (_isTouchable == value) {
								return;
						}
						_isTouchable = value;
						invalidate ();
				}
		}	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		bool
				_isQuickHitAreaEnabled = true;

		[BindableAttribute]
		public bool isQuickHitAreaEnabled {
				get {
						return _isQuickHitAreaEnabled;
				}
				set {
						if (_isQuickHitAreaEnabled == value) {
								return;
						}
						_isQuickHitAreaEnabled = value;
						invalidate ();
				}
		}	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		Rect tempRect = new Rect ();
	
		public virtual bool HitTest (UITouch touch)
		{				
				tempRect.Set (screenRect.x, screenRect.y, screenRect.width, screenRect.height);
				
				if (isQuickHitAreaEnabled) {				
						return tempRect.Contains (touch.position);
				} else {
						for (int i = 0; i < children.Count; i++) {
								UIGameObject child = children [i];
								if (child.HitTest (touch)) {
										return child;
								} else {
										continue;
								}
						}
				}
				return false;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public Action<UIGameObject, UITouch> TouchBeganEvent;
		public Action<UIGameObject, UITouch> TouchMovedEvent;
		public Action<UIGameObject, UITouch> TouchEndedEvent;
		public Action<UIGameObject, UITouch> TouchCancelledEvent;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public virtual void TouchBegan (UITouch touch)
		{					
				if (!isTouchable) {
						return;
				}
			
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
							
						if (!child.isTouchable) {
								continue;
						}
						if (child.HitTest (touch)) {
								child.TouchBegan (touch);
						}
						
				}
		
				if (TouchBeganEvent != null) {
						TouchBeganEvent (this, touch);
				}
		
		} 
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public virtual void TouchMoved (UITouch touch)
		{
		
				if (!isTouchable) {
						return;
				}
		
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
						if (!child.isTouchable) {
								continue;
						}
						
						child.TouchMoved (touch);
						
				}
				if (TouchMovedEvent != null) {
						TouchMovedEvent (this, touch);
				}
		} 
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public virtual void TouchEnded (UITouch touch)
		{
				if (!isTouchable) {
						return;
				}
		
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
						if (!child.isTouchable) {
								continue;
						}
						
						child.TouchEnded (touch);
						
				}
				if (TouchEndedEvent != null) {
						TouchEndedEvent (this, touch);
				}
		} 
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public virtual void TouchCancelled (UITouch touch)
		{
				if (!isTouchable) {
						return;
				}
		
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
						if (!child.isTouchable) {
								continue;
						}
						
						child.TouchCancelled (touch);
						
				}
				if (TouchCancelledEvent != null) {
						TouchCancelledEvent (this, touch);
				}
		} 
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
}

public enum PivotType
{
		NONE,
		CENTER,
		TOP_LEFT,
		TOP,
		TOP_RIGHT,
		RIGHT,
		BOTTOM_RIGHT,	
		BOTTOM,
		BOTTOM_LEFT,
		LEFT
}