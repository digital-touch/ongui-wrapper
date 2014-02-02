using UnityEngine;
using System.Collections;
using System;

public class UIGradientFill : UIImage
{		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action StartColorChangedEvent;
	
		[SerializeField]
		Color
				_startColor = Color.grey;
	
		public Color startColor {
				get {
						return _startColor;
				}
				set {
			
						if (_startColor == value) {
								return;
						}
						_startColor = value;
						if (StartColorChangedEvent != null) {
								StartColorChangedEvent ();
						}	
						invalidate ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action EndColorChangedEvent;
	
		[SerializeField]
		Color
				_endColor = new Color (0.3f, 0.3f, 0.3f);
	
		public Color endColor {
				get {
						return _endColor;
				}
				set {
			
						if (_endColor == value) {
								return;
						}
						_endColor = value;
						if (EndColorChangedEvent != null) {
								EndColorChangedEvent ();
						}
						invalidate ();
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action TextureDirectionChangedEvent;
	
		[SerializeField]
		TextureDirection
				_direction = TextureDirection.TOP;
	
		public TextureDirection direction {
				get {
						return _direction;
				}
				set {
			
						if (_direction == value) {
								return;
						}
			
						_direction = value;
						if (TextureDirectionChangedEvent != null) {
								TextureDirectionChangedEvent ();
						}						
						invalidate ();
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	
		public override void Awake ()
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
				if (image != null) {
						#if UNITY_EDITOR
						Texture2D.DestroyImmediate (image);
						#else  
			Texture2D.Destroy (texture);
						#endif
						image = null;
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
		
				createTexture ();
				fillTexture ();			
				
		}
	
		void createTexture ()
		{
				if (image != null) {		
						if (image.width != 2 || image.height != 2) {
								image.Resize (2, 2);										
						}										
				} else {
						image = new Texture2D (2, 2);					
						image.filterMode = FilterMode.Trilinear;
						image.wrapMode = TextureWrapMode.Clamp;
				}				
		}
	
		void fillTexture ()
		{		
				Color[] pixels = image.GetPixels ();
		
				if (direction == TextureDirection.TOP) {
						pixels [3] = startColor;
						pixels [2] = startColor;
						pixels [1] = endColor;
						pixels [0] = endColor;
				} else if (direction == TextureDirection.LEFT) {
						pixels [3] = endColor;
						pixels [2] = startColor;
						pixels [1] = endColor;
						pixels [0] = startColor;
				} else if (direction == TextureDirection.BOTTOM) {
						pixels [3] = endColor;
						pixels [2] = endColor;
						pixels [1] = startColor;
						pixels [0] = startColor;
				} else if (direction == TextureDirection.RIGHT) {
						pixels [3] = startColor;
						pixels [2] = endColor;
						pixels [1] = startColor;
						pixels [0] = endColor;
				}
		
				image.SetPixels (pixels);			
				image.Apply ();
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
}

public enum TextureDirection
{
		TOP,
		RIGHT,
		BOTTOM,
		LEFT
	
}