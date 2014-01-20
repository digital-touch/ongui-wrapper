using UnityEngine;
using UnityEditor;
using System.Collections;

[System.Serializable]
[ExecuteInEditMode]
public class UILabel : UIGameObject
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UILabel")]
		public static GameObject CreateUILabel ()
		{
				GameObject label = new GameObject ("GameObject");
				label.name = "UILabel";
				
				UILabel uiLabel = label.AddComponent<UILabel> ();
				uiLabel.width = 100;
				uiLabel.text = "label";
				uiLabel.height = 100;								
					
				UITextStyle style = label.AddComponent<UITextStyle> ();
				style.id = "default";				
				
				label.transform.parent = Selection.activeTransform;					
				return label;
		}
	#endif		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		protected override void Awake ()
		{
				base.Awake ();
				updateLabel ();						
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
						updateLabel ();						
				}
		}
		
		void OnTextStyleChange (UITextStyle style)
		{
				updateLabel ();
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void updateGUIStyle ()
		{
				style.normal.textColor = textStyle.textColor;
				style.font = textStyle.font;
				style.fontSize = textStyle.fontSize;
				style.alignment = textStyle.textAlignment;
				style.wordWrap = textStyle.wordWrap;
				style.richText = textStyle.richText;				
		}
	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
							
		public GUIContent
				content = new GUIContent ();		
						
		public GUIStyle
				style = new GUIStyle ();				
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		UIGameObject _backgroundSkin;

		public UIGameObject backgroundSkin {
				get {
						return _backgroundSkin;
				}
				set {
						_backgroundSkin = value;
						updateLabel ();
				}
		}
		
		void updateBackgroundSkin ()
		{
				if (backgroundSkin == null) {
						return;
				}
				backgroundSkin.width = width;
				backgroundSkin.height = height;
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		int _paddingLeft = 0;

		public int paddingLeft {
				get {
						return _paddingLeft;
				}
				set {
						if (_paddingLeft == value) {
								return;
						}
						_paddingLeft = value;
						updateLabel ();
				}
		}

		int _paddingRight = 0;

		public int paddingRight {
				get {
						return _paddingRight;
				}
				set {
						if (_paddingRight == value) {
								return;
						}
						_paddingRight = value;
						updateLabel ();
				}
		}

		int _paddingTop = 0;

		public int paddingTop {
				get {
						return _paddingTop;
				}
				set {
						if (_paddingTop == value) {
								return;
						}
						_paddingTop = value;
						updateLabel ();
				}
		}

		int _paddingBottom = 0;

		public int paddingBottom {
				get {
						return _paddingBottom;
				}
				set {
						if (_paddingBottom == value) {
								return;
						}
						_paddingBottom = value;
						updateLabel ();
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]	
		string
				_text;
	
		public string text {
				get {
						return _text;
				}
				set {	
						if (_text != value) {
								_text = value;
								content.text = value;
								updateLabel ();
						}
				}
		}
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void updateLabel ()
		{   				
		
				if (textStyle == null) {
						return;
				}
				updateGUIStyle ();
				measure ();
				updateBackgroundSkin ();
				FireLayoutDataChangedEvent ();
		}	
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		Rect labelRectHelper = new Rect ();
	
		public override void draw (UIGameObject parentChild)
		{		
				
				if (text == null) {
						return;
				}
				
				if (textStyle == null) {
						return;
				}
		
				if (backgroundSkin != null) {
						backgroundSkin.draw (this);
				}
		
				GUI.Label (labelRectHelper, content, style);
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		bool
				_explicitWidth = false;
	
		public bool explicitWidth {
				get {
						return _explicitWidth;
				}
				set {
						_explicitWidth = value;
						measure ();
				}
		}
		
		void measure ()
		{		
				if (!explicitWidth) {
						Vector2 s = style.CalcSize (content);
						
						s.x += paddingLeft;
						s.x += paddingRight;
						
						s.y += paddingTop;
						s.y += paddingBottom;
			
						setSize ((int)s.x, (int)s.y);			
				} else {			
						height = (int)style.CalcHeight (content, width) + paddingTop + paddingBottom;
				}
				
				labelRectHelper.x = screenRect.x + paddingLeft;
				labelRectHelper.y = screenRect.y + paddingTop;
				labelRectHelper.width = screenRect.width + paddingRight;
				labelRectHelper.height = screenRect.height + paddingBottom;
		}
	
}
