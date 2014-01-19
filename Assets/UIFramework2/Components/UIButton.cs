using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class UIButton : UIGameObject
{
		
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
							
				button.AddComponent<UIStackLayout> ();
				
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
								
				
				
				base.Awake ();
		
		
				//AddedToRootEvent += OnAddedToRoot;
				//RemovedFromRootEvent += OnRemovedFromRoot;
		
		}
	
		protected override void OnDestroy ()
		{
				base.OnDestroy ();
			
				
				//AddedToRootEvent -= OnAddedToRoot;
				//RemovedFromRootEvent -= OnRemovedFromRoot;
		}	
	
		public UIImage icon;
		
		public UILabel label;
		
		public UIGameObject normalSkin;
		
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		public void Validate ()
		{
				if (!gameObject.activeSelf) {					
						return;
				}
		
				//base.Validate ();
		
				//bool isSkinDirty = UIInvalidator.isInvalid (gameObject, UIButton.SKIN_FLAG);
		
				//if (isSkinDirty) {
				//		validateSkinIndex ();
			
				//}
		}
	
		void validateSkinIndex ()
		{
//				if (layout == null) {
//						return;
//				}
//				
//				if (isDown) {
//						//Debug.Log ("Skin 0");
//						layout.selectedIndex = 1;	
//				} else {
//						//Debug.Log ("Skin 1");
//						layout.selectedIndex = 0;
//				}			
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////	
	
		bool _isDown = false;
	
		public bool isDown {
				get {
						return _isDown;
				}
				set {
						if (_isDown == value) {
								return;
						}
						_isDown = value;
			
						
				}
		}
	
	
//		void OnAddedToRoot (UIWidget widget)
//		{
//				TouchBeganEvent += OnTouchBegan;	
//				root.TouchEndedEvent += OnTouchEnded;		
//		}		
//	
//		void OnRemovedFromRoot (UIWidget widget)
//		{
//				TouchBeganEvent -= OnTouchBegan;	
//				root.TouchEndedEvent -= OnTouchEnded;		
//		}		
	
	
	
//		void OnTouchBegan (UIWidget widget, UITouch touch)
//		{						
//				if (isDown) {
//						return;
//				}
//				isDown = true;
//		
//		
//		} 
	
//		void OnTouchEnded (UIWidget widget, UITouch touch)
//		{		
//				if (!isDown) {
//						return;
//				}
//				isDown = false;				
//		
//		}					        
}
