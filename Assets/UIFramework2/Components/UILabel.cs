using UnityEngine;

using System.Collections;

public class UILabel : UIGameObject
{
		
		public override int height {
				get {
						return base.height;
				}
				set {
						if (!explicitHeight) {
								return;
						}
				
						base.height = value;
				}
		}
		
		public override int width {
				get {
						return base.width;
				}
				set {
						if (!explicitWidth) {
								return;
						}
			
						base.width = value;
				}
		}

	[SerializeField]
	UITextStyle _textStyle;

	public UITextStyle textStyle {
		get {
			return _textStyle;
		}
		set {
			if (_textStyle == value) {
				return;
			}
			if (_textStyle != null) {
				_textStyle.ChangeEvent-=OnTextStyleChange;
			}
			_textStyle = value;
			if (value != null) {
				_textStyle.ChangeEvent+=OnTextStyleChange;
			}
			invalidate();
		}
	}

	void OnTextStyleChange (UITextStyle style)
	{
		invalidate ();
	}

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void validateGUIStyle ()
		{
				if (textStyle == null) {
						return;
				}
				
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
								invalidate ();
								parentUIGameObject.invalidate ();
						}
				}
		}
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void validate ()
		{				
						
				validateGUIStyle ();					
				validateSize ();																
				base.validate ();
		}	
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void draw (UIGameObject parentChild)
		{		
				
				if (text == null) {
						return;
				}								
				GUI.Label (screenRect, content, style);
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
						invalidate ();
						parentUIGameObject.invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		bool
				_explicitHeight = false;
	
		public bool explicitHeight {
				get {
						return _explicitHeight;
				}
				set {
						_explicitHeight = value;
						invalidate ();
						parentUIGameObject.invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		
		void validateSize ()
		{		
				if (!explicitWidth && !explicitHeight) {
						
						Vector2 s = style.CalcSize (content);					
						setSize (Mathf.CeilToInt (s.x + 1), Mathf.CeilToInt (s.y + 1));			
						
				} else if (explicitWidth && !explicitHeight) {
						
						int newHeight = Mathf.CeilToInt (style.CalcHeight (content, width));
						setSize (width, newHeight);                    
						
				} else {
					
				}
		}	
}
