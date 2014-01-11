using UnityEngine;
using UnityEditor;
using System.Collections;

[System.Serializable]
[ExecuteInEditMode]
public class UILabel : UIWidget
{
		public static readonly string TEXT_STYLE_INVALIDATION_FLAG = "uilabel-text-style";
		public static readonly string BACKGROUND_SKIN_INVALIDATION_FLAG = "uilabel-background-skin";		
		public static readonly string TEXT_INVALIDATION_FLAG = "uilabel-text";
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UILabel")]
		public static GameObject CreateUILabel ()
		{
				GameObject label = new GameObject ("GameObject");
				label.name = "UILabel";
				
				UILabel uiLabel = label.AddComponent<UILabel> ();
				uiLabel.width = 100;
				uiLabel.height = 100;
								
					
				label.AddComponent<UILabelLayout> ();
				label.AddComponent<UILabelRenderer> ();
				label.AddComponent<UIWidgetInteraction> ();
				
				UITextStyle style = label.AddComponent<UITextStyle> ();
				style.id = "default";
				uiLabel.textStyle = style;
				
				label.transform.parent = Selection.activeTransform;					
				return label;
		}
	#endif		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected override void Awake ()
		{
				base.Awake ();
				invalidateLabel ();						
		}
		
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
						if (value) {
								value.ChangeEvent += OnTextStyleChange;
						}
						invalidateLabel ();						
						
				}
		}
		
		void OnTextStyleChange (UITextStyle style)
		{
				invalidateLabel ();
		}
		
		void invalidateLabel ()
		{
				UIInvalidator.invalidate (gameObject, UILabel.TEXT_STYLE_INVALIDATION_FLAG);
				UIInvalidator.invalidate (gameObject, UIWidget.POSITION_INVALIDATION_FLAG);
				UIInvalidator.invalidate (gameObject, UIWidget.SIZE_INVALIDATION_FLAG);
				UIInvalidator.invalidate (gameObject, UIWidget.LAYOUT_INVALIDATION_FLAG);
				
				if (parent != null) {
						UIInvalidator.invalidate (parent.gameObject, UIWidget.LAYOUT_INVALIDATION_FLAG);
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
								invalidateLabel ();
						}
				}
		}
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   				
				if (!gameObject.activeSelf) {					
						return;
				}
		
				base.Validate ();
		
				bool isTextStyleDirty = UIInvalidator.isInvalid (gameObject, UILabel.TEXT_STYLE_INVALIDATION_FLAG);
				bool isTextDirty = UIInvalidator.isInvalid (gameObject, UILabel.TEXT_INVALIDATION_FLAG);
		
				if (isTextDirty || isTextStyleDirty) {
						textStyle.updateGUIStyle (style);
				}
		
		}	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
}
