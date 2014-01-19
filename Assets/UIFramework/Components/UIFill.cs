using UnityEngine;
using System.Collections;
using UnityEditor;

[System.Serializable]
[ExecuteInEditMode]
public class UIFill : UIWidget
{

		public static readonly string TEXTURE_COLOR_INVALIDATION_FLAG = "uifill-texture-color";
		public static readonly string TEXTURE_SIZE_INVALIDATION_FLAG = "uifill-texture-size";
		public static readonly string TEXTURE_INVALIDATION_FLAG = "uifill-texture";
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UIFill")]
		public static GameObject CreateUIFill ()
		{
				GameObject fill = new GameObject ("GameObject");
				fill.name = "UIFill";
				
				UIFill uiFill = fill.AddComponent<UIFill> ();
				uiFill.width = 100;
				uiFill.height = 100;						
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
						UIInvalidator.invalidate (gameObject, UIFill.TEXTURE_COLOR_INVALIDATION_FLAG);			
			
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
						
						UIInvalidator.invalidate (gameObject, UIFill.TEXTURE_SIZE_INVALIDATION_FLAG);
						UIInvalidator.invalidate (gameObject, UIFill.TEXTURE_INVALIDATION_FLAG);						
						
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
								
								UIInvalidator.invalidate (gameObject, UIFill.TEXTURE_INVALIDATION_FLAG);
						}
						_texture = value;
						if (value) {
							
								UIInvalidator.invalidate (gameObject, UIFill.TEXTURE_INVALIDATION_FLAG);
						}
			
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
		override protected void Awake ()
		{	
				base.Awake ();
				UIInvalidator.invalidate (gameObject, UIFill.TEXTURE_SIZE_INVALIDATION_FLAG);
				UIInvalidator.invalidate (gameObject, UIFill.TEXTURE_INVALIDATION_FLAG);
				
		}	
	
		override protected void OnDestroy ()
		{
				base.OnDestroy ();
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Validate ()
		{   						
		
				if (!gameObject.activeSelf) {					
						return;
				}
		
				base.Validate ();
		
				
				bool isTextureInvalid = UIInvalidator.isInvalid (gameObject, UIFill.TEXTURE_INVALIDATION_FLAG);
		
				bool isTextureSizeInvalid = UIInvalidator.isInvalid (gameObject, UIFill.TEXTURE_SIZE_INVALIDATION_FLAG);		
		
				if (isTextureInvalid || isTextureSizeInvalid) {
						if (textureSize > 0) {
								if (texture != null) {			
										texture.Resize (textureSize, textureSize);										
								} else {
										texture = new Texture2D (textureSize, textureSize);					
								}				
						}
				}				
		
				bool isColorInvalid = UIInvalidator.isInvalid (gameObject, UIFill.TEXTURE_COLOR_INVALIDATION_FLAG);
		
				if (isTextureInvalid || isTextureSizeInvalid || isColorInvalid) {			
						Color[] pixels = texture.GetPixels ();
			
						for (var i = 0; i < pixels.Length; ++i) {
								pixels [i] = textureColor;
						}
			
						texture.SetPixels (pixels);			
			
				}
		
				if (isTextureInvalid || isTextureSizeInvalid || isColorInvalid) { 
			
						texture.Apply ();
			
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void Draw (UIWidget parentWidgetTransform)
		{		
		
				UIFill fill = GetComponent<UIFill> ();
				if (fill.texture == null) {
						return;
				}
		
				GUI.DrawTexture (screenBounds, fill.texture);
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
