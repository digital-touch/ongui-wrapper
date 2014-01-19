using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class UITextStyle: MonoBehaviour
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UITextStyle> ChangeEvent;
	
		public void Change ()
		{
				if (ChangeEvent != null) {
						ChangeEvent (this);
				}							
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		string
				_id;

		public string id {
				get {
						return _id;
				}
				set {
						if (_id == value) {
								return;
						}
						_id = value;
						Change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		Color
				_textColor = Color.white;

		public Color textColor {
				get {
						return _textColor;
				}
				set {
						if (_textColor == value) {
								return;
						}
						_textColor = value;
						Change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		Font
				_font;

		public Font font {
				get {
						return _font;
				}
				set {
						if (_font == value) {
								return;
						}
						_font = value;
						Change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		[SerializeField]
		int
				_fontSize = 16;

		public int fontSize {
				get {
						return _fontSize;
				}
				set {
						if (_fontSize == value) {
								return;
						}
						_fontSize = value;
						Change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		[SerializeField]
		FontStyle
				_fontStyle = FontStyle.Normal;

		public FontStyle fontStyle {
				get {
						return _fontStyle;
				}
				set {
						if (_fontStyle == value) {
								return;
						}
						_fontStyle = value;
						Change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		TextAnchor
				_textAlignment = TextAnchor.MiddleCenter;
		
		public TextAnchor textAlignment {
				get {
						return _textAlignment;
				}
				set {
						if (_textAlignment == value) {
								return;
						}
						_textAlignment = value;
						Change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		[SerializeField]
		bool
				_wordWrap = false;

		public bool wordWrap {
				get {
						return _wordWrap;
				}
				set {
						if (_wordWrap == value) {
								return;
						}
						_wordWrap = value;
						Change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		[SerializeField]
		bool
				_richText = true;

		public bool richText {
				get {
						return _richText;
				}
				set {
						if (_richText == value) {
								return;
						}
						_richText = value;
						Change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		protected virtual void Awake ()
		{
				addToUIGameObject ();
		}
	
		Transform parent;	
	
		protected virtual void Update ()
		{		
				if (parent == transform.parent) {
						return;
				}
				removeFromUIGameObject ();						
				addToUIGameObject ();				
		}		
	
		protected virtual void OnDestroy ()
		{
				removeFromUIGameObject ();
		}
	
		protected UILabel uiGameObject;
	
		void addToUIGameObject ()
		{
				parent = transform.parent;
				UILabel newUIGameObject = transform.GetComponent<UILabel> ();
				if (newUIGameObject == null) {
						return;
				}
				uiGameObject = newUIGameObject;
				uiGameObject.textStyle = this;				
		}
	
		void removeFromUIGameObject ()
		{
				if (uiGameObject != null) {						
						uiGameObject.textStyle = null;
				}
				uiGameObject = null;	
				parent = null;			
		}
}
