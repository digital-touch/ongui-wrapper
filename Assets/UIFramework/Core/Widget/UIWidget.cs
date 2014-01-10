using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

[ExecuteInEditMode]
[System.Serializable]
public class UIWidget : MonoBehaviour
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public static readonly string POSITION_FLAG = "uiwidget-position";
		public static readonly string SIZE_FLAG = "uiwidget-size";
		public static readonly string DATA_FLAG = "uiwidget-data";
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	#if UNITY_EDITOR
	
		[MenuItem("UI/UIWidget")]
		public static GameObject createUIWidget ()
		{
				GameObject widget = new GameObject ("UIWidget");				
				UIWidgetTransform widgetTransform = widget.AddComponent<UIWidgetTransform> ();
				widgetTransform.width = 100;
				widgetTransform.height = 100;
				widget.AddComponent<UIWidget> ();
				widget.AddComponent<UIWidgetValidator> ();
				widget.AddComponent<UIWidgetRenderer> ();
				widget.AddComponent<UIWidgetInteraction> ();								
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
			
		protected UIWidgetTransform widgetTransform;
	
		protected virtual void Awake ()
		{				
				widgetTransform = GetComponent<UIWidgetTransform> ();
				UIInvalidator.invalidate (this, UIInvalidator.ALL_INVALIDATION_FLAG);
		}
	
		protected virtual void OnDestroy ()
		{				
				widgetTransform = null;
		}			
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public UIWidget parent {
				get {
						return transform.parent.GetComponent<UIWidget> ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public UIRoot root {
				get {
						Transform parent = transform.parent;
						while (parent != null) {
								if (parent.parent == null) {
										return parent.GetComponent<UIRoot> ();
								}
								parent = parent.parent;
						}
						return GetComponent<UIRoot> ();
				}	
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		object _data;

		public object data {
				get {
						return _data;
				}
				set {
						if (_data == value) {
								return;
						}
						_data = value;
						UIInvalidator.invalidate (this, DATA_FLAG);                                   
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
