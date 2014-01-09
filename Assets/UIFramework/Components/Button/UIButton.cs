using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class UIButton : UIWidget
{
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public static readonly string SKIN_FLAG = "uibutton-skin";
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UIButton")]
		public static GameObject CreateUIButton ()
		{
				GameObject button = new GameObject ("GameObject");
				button.name = "UIButton";
		
				UIWidgetTransform widgetTransform = button.AddComponent<UIWidgetTransform> ();
				widgetTransform.width = 100;
				widgetTransform.height = 100;
		
				button.AddComponent<UIButtonInteraction> ();				
				button.AddComponent<UIButton> ();
				button.AddComponent<UIButtonValidator> ();
				button.AddComponent<UIStackLayout> ();
				button.AddComponent<UIWidgetRenderer> ();
				button.transform.parent = Selection.activeTransform;
				
				GameObject normalSkin = UIImage.CreateUIImage ();
				normalSkin.name = "normal-skin";
				normalSkin.transform.parent = button.transform;
				
				GameObject downSkin = UIImage.CreateUIImage ();
				downSkin.name = "down-skin";
				downSkin.transform.parent = button.transform;
        		
				return button;
				;
		}
    #endif		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected override void Awake ()
		{
				base.Awake ();
				UIInvalidator.invalidate (this, SKIN_FLAG);
				
		
		}
	
		protected override void OnDestroy ()
		{
				base.OnDestroy ();
				
				widgetTransform = null;
		}	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
//		[SerializeField]
//		UIWidget
//				_normalSkin;
//
//		public UIWidget normalSkin {
//				get {
//						return _normalSkin;
//				}
//				set {
//						if (_normalSkin == value) {
//								return;
//						}
//						_normalSkin = value;
//						Invalidator.invalidate(widget,SKIN_FLAG);
//				}
//		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
//    
//		[SerializeField]
//		UIWidget
//				_downSkin;
//
//		public UIWidget downSkin {
//				get {
//						return _downSkin;
//				}
//				set {
//						if (_downSkin == value) {
//								return;
//						}
//						_downSkin = value;
//						Invalidator.invalidate(widget,SKIN_FLAG);
//				}
//		}
				        
}
