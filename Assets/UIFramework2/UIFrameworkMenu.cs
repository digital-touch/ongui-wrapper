using UnityEngine;
using System.Collections;
using TouchScript;
using TouchScript.InputSources;

public static class UIFrameworkMenu
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
		[UnityEditor.MenuItem ("UI/UIRoot")]
		public static GameObject CreateUIRoot ()
		{
				GameObject gameObject = new GameObject ("GameObject");
				gameObject.name = "UIRoot";
		
				UIRoot uiRoot = gameObject.AddComponent<UIRoot> ();
		
				uiRoot.width = Screen.width;
				uiRoot.height = Screen.height;						
		
				gameObject.AddComponent<TouchManager> ();
				gameObject.AddComponent<MouseInput> ();
		
				gameObject.AddComponent<FitToScreenUILayout> ();
		
				return gameObject;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
		[UnityEditor.MenuItem ("UI/UIGameObject")]
		public static GameObject CreateUIGameObject ()
		{
				GameObject gameObject = new GameObject ("GameObject");
				
				gameObject.transform.parent = UnityEditor.Selection.activeTransform;
				gameObject.name = "UIGameObject";
		
				gameObject.AddComponent<UIGameObject> ();
		
				return gameObject;
		}

	///////////////////////////////////////////////////////////////////////////////////////////////////
	/// 
	[UnityEditor.MenuItem ("UI/Skinning/UITextStyle")]
	public static GameObject CreateUITextStyle ()
	{
		GameObject gameObject = new GameObject ("GameObject");
		gameObject.transform.parent = UnityEditor.Selection.activeTransform;
		gameObject.name = "UITextStyle";
		
		UITextStyle textStyle = gameObject.AddComponent<UITextStyle> ();
		
		return gameObject;
	}

		///////////////////////////////////////////////////////////////////////////////////////////////////
		[UnityEditor.MenuItem ("UI/Containers/UISimplePanel")]
		public static GameObject CreateUISimplePanel ()
		{
				UIGameObject uiGameObject = CreateUIGameObject ().GetComponent<UIGameObject> ();
				uiGameObject.width = 300;
				uiGameObject.height = 300;
				uiGameObject.transform.parent = UnityEditor.Selection.activeTransform;
		
				uiGameObject.name = "UISimplePanel";
				uiGameObject.gameObject.AddComponent<AnchorUILayout> ();
		
				UIGameObject header = CreateUIHeader ().GetComponent<UIGameObject> ();		
				header.transform.parent = uiGameObject.transform;
		
				AnchorUILayoutData headerLayoutData = (AnchorUILayoutData)header.gameObject.AddComponent<AnchorUILayoutData> ();				
				headerLayoutData.leftAnchor = true;
				headerLayoutData.rightAnchor = true;				
				headerLayoutData.topAnchor = true;
		
				UIFill contentBackground = CreateUIFill ().GetComponent<UIFill> ();		
				contentBackground.alpha = 0.5f;
				contentBackground.transform.parent = uiGameObject.transform;
				
				AnchorUILayoutData contentBackgroundLayoutData = (AnchorUILayoutData)contentBackground.gameObject.AddComponent<AnchorUILayoutData> ();				
				contentBackgroundLayoutData.leftAnchor = true;
				contentBackgroundLayoutData.rightAnchor = true;				
				contentBackgroundLayoutData.topAnchor = true;
				contentBackgroundLayoutData.topTarget = header;
				contentBackgroundLayoutData.bottomAnchor = true;
		
				UIScroller content = CreateUIScroller ().GetComponent<UIScroller> ();		
				content.transform.parent = uiGameObject.transform;
		
				AnchorUILayoutData contentLayoutData = (AnchorUILayoutData)content.gameObject.AddComponent<AnchorUILayoutData> ();				
				contentLayoutData.leftAnchor = true;
				contentLayoutData.rightAnchor = true;				
				contentLayoutData.topAnchor = true;
				contentLayoutData.topTarget = header;
				contentLayoutData.bottomAnchor = true;
				
				//uiGameObject.Awake ();				
		
				return uiGameObject.gameObject;
		}
	
		[UnityEditor.MenuItem ("UI/Containers/UIHeader")]
		public static GameObject CreateUIHeader ()
		{
				
				UIGameObject header = CreateUIGameObject ().GetComponent<UIGameObject> ();
				header.transform.parent = UnityEditor.Selection.activeTransform;
				header.width = 200;
				header.height = 50;
		
				header.name = "UIHeader";
				header.gameObject.AddComponent<AnchorUILayout> ();
		
				UIFill headerBackground = CreateUIFill ().GetComponent<UIFill> ();
				headerBackground.transform.parent = header.transform;
				headerBackground.alpha = 0.3f;
				
				AnchorUILayoutData headerBackgroundLayoutData = (AnchorUILayoutData)headerBackground.gameObject.AddComponent<AnchorUILayoutData> ();				
				headerBackgroundLayoutData.leftAnchor = true;
				headerBackgroundLayoutData.rightAnchor = true;
				headerBackgroundLayoutData.bottomAnchor = true;
				headerBackgroundLayoutData.topAnchor = true;
		
				UILabel headerLabel = CreateUILabel ().GetComponent<UILabel> ();
				headerLabel.transform.parent = header.transform;
				headerLabel.text = "Panel";

				AnchorUILayoutData headerLabelLayoutData = (AnchorUILayoutData)headerLabel.gameObject.AddComponent<AnchorUILayoutData> ();				
				headerLabelLayoutData.verticalAnchor = true;
				headerLabelLayoutData.horizontalAnchor = true;
		
				//header.invalidate ();
		
				//header.Awake ();		
		
				return header.gameObject;
		}
		
		
	
	
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
		[UnityEditor.MenuItem("UI/Containers/UIScreenNavigator")]
		public static GameObject createUIScreenNavigator ()
		{
				GameObject widget = new GameObject ("UIScreenNavigator");
				widget.transform.parent = UnityEditor.Selection.activeTransform;
				widget.name = "UIScreenNavigator";
		
				widget.AddComponent<UIScreenNavigator> ();				
				widget.AddComponent<FitToScreenUILayout> ();								
				return widget;
		}
	
	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
		[UnityEditor.MenuItem("UI/Containers/UIScreen")]
		public static GameObject createUIScreen ()
		{
				GameObject widget = new GameObject ("UIScreen");
				widget.transform.parent = UnityEditor.Selection.activeTransform;
		
				widget.AddComponent<UIScreen> ();				
				widget.AddComponent<FitToScreenUILayout> ();								
				return widget;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
		[UnityEditor.MenuItem ("UI/Containers/UIScroller")]
		public static GameObject CreateUIScroller ()
		{
				GameObject gameObject = new GameObject ("GameObject");
				gameObject.transform.parent = UnityEditor.Selection.activeTransform;
				gameObject.name = "UIScroller";
		
		
				UIScroller scroller = (UIScroller)gameObject.AddComponent<UIScroller> ();
				scroller.width = 100;
				scroller.height = 100;
		
				return gameObject;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
		[UnityEditor.MenuItem ("UI/Components/UIButton")]
		public static GameObject CreateUIButton ()
		{
				GameObject button = new GameObject ("GameObject");
				button.transform.parent = UnityEditor.Selection.activeTransform;
				button.name = "UIButton";
		
				UIButton uiButton = button.AddComponent<UIButton> ();
				uiButton.width = 100;
				uiButton.height = 100;
		
				button.AddComponent<UIStackLayout> ();
		
		
				GameObject normalSkin = CreateUIImage ();
				normalSkin.name = "0.normal-skin";
				normalSkin.transform.parent = button.transform;
		
				GameObject downSkin = CreateUIImage ();
				downSkin.name = "1.down-skin";
				downSkin.transform.parent = button.transform;
		
				return button;
		
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[UnityEditor.MenuItem ("UI/Components/UIFill")]
		public static GameObject CreateUIFill ()
		{
				GameObject gameObject = new GameObject ("GameObject");
				gameObject.transform.parent = UnityEditor.Selection.activeTransform;
				gameObject.name = "UIFill";
		
				UIFill uiFill = gameObject.AddComponent<UIFill> ();
				uiFill.width = 100;
				uiFill.height = 100;						
		
				return gameObject;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[UnityEditor.MenuItem ("UI/Components/UIGradientFill")]
		public static GameObject CreateUIGradientFill ()
		{
				GameObject gameObject = new GameObject ("GameObject");
				gameObject.transform.parent = UnityEditor.Selection.activeTransform;
				gameObject.name = "UIGradientFill";
		
				UIGradientFill uiGradientFill = gameObject.AddComponent<UIGradientFill> ();
				uiGradientFill.width = 100;
				uiGradientFill.height = 100;						
		
				return gameObject;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[UnityEditor.MenuItem ("UI/Components/UIImage")]
		public static GameObject CreateUIImage ()
		{
				GameObject image = new GameObject ("GameObject");
				image.transform.parent = UnityEditor.Selection.activeTransform;						
				image.name = "UIImage";				
		
				UIImage uiImage = image.AddComponent<UIImage> ();
				uiImage.width = 100;
				uiImage.height = 100;				
		
		
				return image;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[UnityEditor.MenuItem ("UI/Components/UILabel")]
		public static GameObject CreateUILabel ()
		{
				GameObject label = new GameObject ("GameObject");
				label.transform.parent = UnityEditor.Selection.activeTransform;					
				label.name = "UILabel";
		
				UILabel uiLabel = label.AddComponent<UILabel> ();
				uiLabel.width = 100;
				uiLabel.text = "label";
				uiLabel.height = 100;								
		
				UITextStyle style = label.AddComponent<UITextStyle> ();
				style.id = "default";				
		
				return label;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
	
		[UnityEditor.MenuItem ("UI/Components/UISliceImage")]
		public static GameObject CreateUISliceImage ()
		{
				GameObject slice = new GameObject ("GameObject");
				slice.transform.parent = UnityEditor.Selection.activeTransform;						
				slice.name = "UISliceImage";
		
				UISliceImage uiImage = slice.AddComponent<UISliceImage> ();
				uiImage.width = 100;
				uiImage.height = 100;
		
				return slice;
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[UnityEditor.MenuItem ("UI/Components/UISkinnableObject")]
		public static GameObject CreateUISkinnableObject ()
		{
				GameObject gameObject = new GameObject ("GameObject");		
				gameObject.transform.parent = UnityEditor.Selection.activeTransform;
				gameObject.name = "UISkinnableObject";
		
				gameObject.AddComponent<UISkinnableObject> ();
		
				return gameObject;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		#endif
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
