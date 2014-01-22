using UnityEngine;

//using UnityEditor;

using System.Collections;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]
public class UIGameObject : BindableObject
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[UnityEditor.MenuItem ("UI/UIGameObject")]
		public static GameObject CreateUIGameObject ()
		{
				GameObject gameObject = new GameObject ("GameObject");
				gameObject.name = "UIGameObject";
		
		
				gameObject.AddComponent<UIGameObject> ();
				
				gameObject.AddComponent<FitToContentUILayout> ();
		
				gameObject.transform.parent = UnityEditor.Selection.activeTransform;
		
				return gameObject;
		}
	#endif		
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
		public Transform parent {
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
		public UIGameObject parentUIGameObject {
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
	
		protected virtual void Awake ()
		{
				#if UNITY_EDITOR
				transform.hideFlags = HideFlags.NotEditable | HideFlags.HideInInspector;	
				#endif
				addToParent ();				
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		protected virtual void Update ()
		{
				if (parent == transform.parent) {
						return;
				}
				removeFromParent ();
				addToParent ();
		
		}	
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected virtual void OnDestroy ()
		{
				#if UNITY_EDITOR
				transform.hideFlags = HideFlags.None;	
				#endif
				removeFromParent ();
				layoutDatas.Clear ();
				layouts.Clear ();
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
		public int depth {
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
		
		public void addChild (UIGameObject child)
		{
				if (child.depth == -1) {
						child.depth = children.Count;
				}
				children.Add (child);			
				child.MoveEvent += onChildMove;	
				child.ResizeEvent += onChildResize;
				child.LayoutDataChangedEvent += onChildLayoutDataChanged;
				if (root != null) {
						child.root = root;
						root.FireChildAddedEvent (child);
				}							
				updateLayout ();
		}
		
		public void removeChild (UIGameObject child)
		{
				child.depth = -1;			
				children.Remove (child);
				child.MoveEvent -= onChildMove;	
				child.ResizeEvent -= onChildResize;
				child.LayoutDataChangedEvent -= onChildLayoutDataChanged;
				if (child.root != null) {
						child.root.FireChildRemovedEvent (child);
						child.root = null;
				}
				updateLayout ();
		}
				
		public int numChildren {
				get {
						return children.Count;
				}
		}
		
		public int getChildIndex (UIGameObject child)
		{
		
				return children.IndexOf (child);
				
		}
		
		public UIGameObject getChild (int index)
		{
			
				return children [index];
			
		}
		
		public UIGameObject getChildById (string name)
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
		public bool clipContent {
				get {
						return _clipContent;
				}
				set {
						_clipContent = value;
				}
		}		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
			
		Vector2 scaleHelper = Vector2.zero;
			
		public virtual void draw (UIGameObject parentChild)
		{
		
				
				GUI.BeginGroup (screenRect);
								
				children.Sort (
					delegate(UIGameObject p1, UIGameObject p2) {
						return p1.depth.CompareTo (p2.depth);
				}
				);
		
				for (int i = 0; i < children.Count; i++) {
				
						UIGameObject child = children [i];
						
						if (child == null || !child.isVisible || child.alpha == 0 || !child.gameObject.activeSelf || !child.enabled) {
								continue;
						}
						
						Color old = GUI.color;
			
						Color newColor = Color.black;
			
						if (parentChild != null) {
								
								newColor.r = GUI.color.r * child.color.r * parentChild.color.r;
								newColor.g = GUI.color.g * child.color.g * parentChild.color.g;
								newColor.b = GUI.color.b * child.color.b * parentChild.color.b;
				
								newColor.a = GUI.color.a * child.alpha * parentChild.alpha;
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
				
								child.draw (this);
				
								GUI.matrix = matrix;
						} else {
								child.draw (this);
						}
			
						GUI.color = old;
			
						
				}
				
				
				GUI.EndGroup ();
				
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
		public int x {
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
		public int y {
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
		public Vector2 position {
				get {
						return _position;
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[BindableAttribute]
		public int width {
				set {
						if (screenRect.width == value) {
								return;
						}
						screenRect.width = value;
						updateLayout ();
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
		public int height {
				set {
						if (screenRect.height == value) {
								return;
						}
						screenRect.height = value;
						updateLayout ();
						if (ResizeEvent != null) {
								ResizeEvent (this);
						}
				}
				get {
						return (int)screenRect.height;
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public void setPosition (int x, int y)
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
	
		public void setSize (int width, int height, bool updateLayoutNow)
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
		
				if (updateLayoutNow) {
						updateLayout ();
				}
			
				if (ResizeEvent != null) {
						ResizeEvent (this);
				}
		
		}
		public void setSize (int width, int height)
		{
				this.setSize (width, height, true);
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
						_includeInLayout = value;
						updateLayout ();
				}
		}
                
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		List<UILayout> layouts = new List<UILayout> ();

		public void addLayout (UILayout layout)
		{
				layout.ChangedEvent += onLayoutChange;
				layouts.Add (layout);
				updateLayout ();
		}
		
		public void removeLayout (UILayout layout)
		{
				layout.ChangedEvent -= onLayoutChange;
				layouts.Remove (layout);
				updateLayout ();
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		List<UILayoutData> layoutDatas = new List<UILayoutData> ();
	
	
		public void addLayoutData (UILayoutData layoutData)
		{
		
				layoutDatas.Add (layoutData);
				layoutData.ChangedEvent += onLayoutDataChange;	
				FireLayoutDataChangedEvent ();
		}
	
		public void removeLayoutData (UILayoutData layoutData)
		{
				layoutData.ChangedEvent -= onLayoutDataChange;
				layoutDatas.Remove (layoutData);
				FireLayoutDataChangedEvent ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public void  updateLayout ()
		{
		
				if (layouts.Count == 0) {
						return;
				}
				ignoreChildChanges = true;
				for (int i = 0; i < layouts.Count; i++) {
						UILayout layout = layouts [i];
						layout.Layout ();
				}
				ignoreChildChanges = false;
				
				for (int i = 0; i <children.Count; i++) {
						UIGameObject child = children [i];
						child.updateLayout ();
				}
		}
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
			
		void onLayoutDataChange ()
		{
				FireLayoutDataChangedEvent ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public Action LayoutDataChangedEvent;
				
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected void FireLayoutDataChangedEvent ()
		{
				if (LayoutDataChangedEvent != null) {
						LayoutDataChangedEvent ();
				}
		}
    
		///////////////////////////////////////////////////////////////////////////////////////////////////
	    
		bool ignoreChildChanges = false;
    
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void onLayoutChange ()
		{
				if (ignoreChildChanges) {
						return;
				}
				updateLayout ();
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void onChildLayoutDataChanged ()
		{
				if (ignoreChildChanges) {
						return;
				}
				updateLayout ();
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		void onChildMove (UIGameObject child)
		{
				if (ignoreChildChanges) {
						return;
				}
				updateLayout ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////	
    
		void onChildResize (UIGameObject child)
		{
				if (ignoreChildChanges) {
						return;
				}
				updateLayout ();
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
						_alpha = value;
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
						_color = value;
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
						_isVisible = value;
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
						_rotation = value;
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
						_scaleX = value;
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
						_scaleY = value;
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
						_rotationPivot = value;
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
						_rotationPivotType = value;
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
						_scalePivot = value;
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
						_scalePivotType = value;
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
						_isTouchable = value;
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
						_isQuickHitAreaEnabled = value;
				}
		}	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		Rect tempRect = new Rect ();
	
		public virtual bool HitTest (UITouch touch)
		{				
				if (isQuickHitAreaEnabled) {
				
						tempRect.Set (x, y, width, height);
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
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
							
						if (!child.isTouchable) {
								continue;
						}
						if (!child.HitTest (touch)) {
								continue;
						}			
						child.TouchBegan (touch);
				}
		
				if (TouchBeganEvent != null) {
						TouchBeganEvent (this, touch);
				}
		
		} 
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public virtual void TouchMoved (UITouch touch)
		{
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
						if (!child.isTouchable) {
								continue;
						}
						if (!child.HitTest (touch)) {
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
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
						if (!child.isTouchable) {
								continue;
						}
						if (!child.HitTest (touch)) {
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
				for (int i = 0; i < children.Count; i++) {
						UIGameObject child = children [i];
						if (!child.isTouchable) {
								continue;
						}
						if (!child.HitTest (touch)) {
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