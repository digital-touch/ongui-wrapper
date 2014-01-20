using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

[ExecuteInEditMode]
public class UIFill : UIGameObject
{
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UIFill")]
		public static GameObject CreateUIFill ()
		{
				GameObject gameObject = new GameObject ("GameObject");
				gameObject.name = "UIFill";
				
				UIFill uiFill = gameObject.AddComponent<UIFill> ();
				uiFill.width = 100;
				uiFill.height = 100;						
				gameObject.transform.parent = Selection.activeTransform;
		
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
						updateTexture ();
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
						updateTexture ();
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
				updateTexture ();
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
	
	
		void updateTexture ()
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