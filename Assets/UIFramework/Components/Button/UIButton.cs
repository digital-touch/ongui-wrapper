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
				
				UIButton uiButton = button.AddComponent<UIButton> ();
				uiButton.width = 100;
				uiButton.height = 100;
		
				button.AddComponent<UIButtonInteraction> ();				
				button.AddComponent<UIStackLayout> ();
				button.AddComponent<UIWidgetRenderer> ();
				button.transform.parent = Selection.activeTransform;
				
				GameObject normalSkin = UIImage.CreateUIImage ();
				normalSkin.name = "0.normal-skin";
				normalSkin.transform.parent = button.transform;
				
				GameObject downSkin = UIImage.CreateUIImage ();
				downSkin.name = "1.down-skin";
				downSkin.transform.parent = button.transform;
        		
				return button;
				
		}
    #endif		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected override void Awake ()
		{
				
				buttonInteraction = GetComponent<UIButtonInteraction> ();
				layout = GetComponent<UIStackLayout> ();
				
				base.Awake ();
		
				UIInvalidator.invalidate (gameObject, SKIN_FLAG);
		
		}
	
		protected override void OnDestroy ()
		{
				base.OnDestroy ();
				layout = null;
				buttonInteraction = null;				
		}	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		protected UIStackLayout layout;
		protected UIButtonInteraction buttonInteraction;
	
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		public override void Validate ()
		{
				if (!gameObject.activeSelf) {					
						return;
				}
		
				base.Validate ();
		
				bool isSkinDirty = UIInvalidator.isInvalid (gameObject, UIButton.SKIN_FLAG);
		
				if (isSkinDirty) {
						validateSkinIndex ();
			
				}
		}
	
		void validateSkinIndex ()
		{
				if (layout == null) {
						return;
				}
				if (buttonInteraction == null) {
						layout.selectedIndex = 0;
				}
				if (buttonInteraction.isDown) {
						//Debug.Log ("Skin 0");
						layout.selectedIndex = 1;	
				} else {
						//Debug.Log ("Skin 1");
						layout.selectedIndex = 0;
				}			
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
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
