using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class UIFill : UIGameObject
{
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[UnityEditor.MenuItem ("UI/UIFill")]
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
	#endif		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action TextureColorChangedEvent;
	
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
						if (TextureColorChangedEvent != null) {
								TextureColorChangedEvent ();
						}	
						validateTexture ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action TextureSizeChangedEvent;
	
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
						if (TextureSizeChangedEvent != null) {
								TextureSizeChangedEvent ();
						}						
						validateTexture ();
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
						_texture = value;
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
		override protected void Awake ()
		{	
				base.Awake ();
				validateTexture ();
		}	
	
		override protected void OnDestroy ()
		{
				destroyTexture ();
				base.OnDestroy ();
		}
				
		void destroyTexture ()
		{
				if (texture != null) {
						#if UNITY_EDITOR
						Texture2D.DestroyImmediate (texture);
						#else  
			Texture2D.Destroy (texture);
#endif
						texture = null;
				}
		}
		
	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void validate ()
		{
				validateTexture ();
				base.validate ();
		}
	
		void validateTexture ()
		{   						
		
				if (textureSize == 0) {
						if (texture != null) {
								destroyTexture ();
						}
						return;
				}
				createTexture ();
				fillTexture ();			
		}
						
		void createTexture ()
		{
				if (texture != null) {			
						if (texture.width != textureSize || texture.height != textureSize) {
								texture.Resize (textureSize, textureSize);										
						}										
				} else {
						texture = new Texture2D (textureSize, textureSize);					
				}				
		}
		
		void fillTexture ()
		{
				
				Color[] pixels = texture.GetPixels ();
			
				for (var i = 0; i < pixels.Length; ++i) {
						pixels [i] = textureColor;
				}
			
				texture.SetPixels (pixels);			
				texture.Apply ();
		}
		
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public override void draw (UIGameObject parentChild)
		{						
				if (texture == null) {
						return;
				}
		
				GUI.DrawTexture (screenRect, texture);
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
