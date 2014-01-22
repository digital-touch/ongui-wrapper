using UnityEngine;

using System.Collections;

public class UILabel : UIGameObject
{
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
	#if UNITY_EDITOR
	
		[UnityEditor.MenuItem ("UI/UILabel")]
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
				
				label.transform.parent = UnityEditor.Selection.activeTransform;					
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
				updateLayout ();				
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
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		
		void measure ()
		{		
				if (!explicitWidth) {
						Vector2 s = style.CalcSize (content);					
						setSize ((int)s.x, (int)s.y, false);			
				} else {
						setSize (width, (int)style.CalcHeight (content, width), false);                    
				}
				
				labelRectHelper.x = screenRect.x;
				labelRectHelper.y = screenRect.y;
				labelRectHelper.width = screenRect.width;
				labelRectHelper.height = screenRect.height;
		
		}
	
}
