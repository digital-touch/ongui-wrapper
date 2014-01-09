using UnityEngine;
using System.Collections;
using UnityEditor;

[System.Serializable]
[ExecuteInEditMode]
public class UIFill : UIWidget
{

		public static readonly string TEXTURE_COLOR_FLAG = "uifill-texture-color";
		public static readonly string TEXTURE_SIZE_FLAG = "uifill-texture-size";
		public static readonly string TEXTURE_FLAG = "uifill-texture";
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UIFill")]
		public static GameObject CreateUIFill ()
		{
				GameObject fill = new GameObject ("GameObject");
				fill.name = "UIFill";
				
				UIWidgetTransform widgetTransform = fill.AddComponent<UIWidgetTransform> ();
				widgetTransform.width = 100;
				widgetTransform.height = 100;
		
				fill.AddComponent<UIFill> ();
				fill.AddComponent<UIFillValidator> ();				
				fill.AddComponent<UIFillRenderer> ();
				fill.AddComponent<UIWidgetInteraction> ();				
				fill.transform.parent = Selection.activeTransform;
		
				return fill;
		}
	#endif		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		Color
				_textureColor = Color.white;
		
		public Color textureColor {
				get {
						return _textureColor;
				}
				set {
			
						if (_textureColor == value) {
								return;
						}
						_textureColor = value;
						UIInvalidator.invalidate (this, UIFill.TEXTURE_COLOR_FLAG);			
			
						//Debug.Log ("{" + this + "}->color:" + value);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		int
				_textureSize = 64;
		
		public int textureSize {
				get {
						return _textureSize;
				}
				set {
				
						if (_textureSize == value) {
								return;
						}
						
						_textureSize = value;
						
						UIInvalidator.invalidate (this, UIFill.TEXTURE_SIZE_FLAG);
						UIInvalidator.invalidate (this, UIFill.TEXTURE_FLAG);
						
						//Debug.Log ("{" + this + "}->textureSize:" + value);
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		Texture2D
				_texture;
		
		public Texture2D texture {
				get {
						return _texture;
				}
				set {
						if (_texture) {
								disposeTexture (value);
								UIInvalidator.invalidate (this, UIFill.TEXTURE_FLAG);
						}
						_texture = value;
						if (value) {
								initializeTexture (value);
								
								UIInvalidator.invalidate (this, UIFill.TEXTURE_FLAG);
						}
			
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		protected virtual void initializeTexture (Texture2D texture)
		{
		}
		
		protected virtual void disposeTexture (Texture2D texture)
		{
		}
		
		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
		override protected void Awake ()
		{	
				base.Awake ();
				UIInvalidator.invalidate (this, UIFill.TEXTURE_SIZE_FLAG);
				
		}	
	
		override protected void OnDestroy ()
		{
				base.OnDestroy ();
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
}
