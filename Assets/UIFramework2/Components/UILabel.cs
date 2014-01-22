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
	#endif		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		void validateGUIStyle ()
		{
				UITextStyle textStyle = GetComponent<UITextStyle> ();
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
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		
		void validateSize ()
		{		
				if (!explicitWidth) {
						Vector2 s = style.CalcSize (content);					
						setSize ((int)s.x, (int)s.y);			
				} else {
						setSize (width, (int)style.CalcHeight (content, width));                    
				}
				
				
		
		}
	
}
