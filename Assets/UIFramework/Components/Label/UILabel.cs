using UnityEngine;
using UnityEditor;
using System.Collections;

[System.Serializable]
[ExecuteInEditMode]
public class UILabel : UIWidget
{
		public static readonly string TEXT_STYLE_FLAG = "uilabel-text-style";
		public static readonly string BACKGROUND_SKIN_FLAG = "uilabel-background-skin";		
		public static readonly string TEXT_FLAG = "uilabel-text";
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UILabel")]
		public static GameObject CreateUILabel ()
		{
				GameObject label = new GameObject ("GameObject");
				label.name = "UILabel";
			
				UIWidgetTransform widgetTransform = label.AddComponent<UIWidgetTransform> ();
				widgetTransform.width = 100;
				widgetTransform.height = 100;	
				UILabel labelComponent = label.AddComponent<UILabel> ();
				label.AddComponent<UILabelValidator> ();					
				label.AddComponent<UILabelLayout> ();
				label.AddComponent<UILabelRenderer> ();
				label.AddComponent<UIWidgetInteraction> ();
				
				UITextStyle style = label.AddComponent<UITextStyle> ();
				style.id = "default";
				labelComponent.textStyle = style;
				
				label.transform.parent = Selection.activeTransform;					
				return label;
		}
	#endif		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		UITextStyle
				_textStyle;
		
		public UITextStyle textStyle {
				get {
						return _textStyle;
				}
				set {
						if (_textStyle == value) {
								return;
						}
						if (_textStyle) {
								_textStyle.ChangeEvent -= OnTextStyleChange;
						}
						_textStyle = value;
						if (_textStyle) {
								_textStyle.ChangeEvent -= OnTextStyleChange;
						}
						UIInvalidator.invalidate (this, UILabel.TEXT_STYLE_FLAG);
						
				}
		}
		
		void OnTextStyleChange (UITextStyle style)
		{
				UIInvalidator.isInvalid (this, UILabel.TEXT_STYLE_FLAG);
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		UIWidget
				_backgroundSkin;
		
		public UIWidget backgroundSkin {
				get {
						return _backgroundSkin;
				}
				set {
						if (_backgroundSkin != value) {
								_backgroundSkin = value;
								UIInvalidator.invalidate (this, UILabel.BACKGROUND_SKIN_FLAG);
						}
				}
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////
			
		[SerializeField]
		string
				_text;
		public GUIContent
				content = new GUIContent ();		
				
		[SerializeField]
		public GUIStyle
				style = new GUIStyle ();				
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public string text {
				get {
						return _text;
				}
				set {	
						if (_text != value) {
								_text = value;
								content.text = value;
								UIInvalidator.invalidate (this, UILabel.TEXT_FLAG);
						}
				}
		}
				
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
}
