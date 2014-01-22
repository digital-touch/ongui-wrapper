using UnityEngine;

using System.Collections;
using System;

public class UIImage : UIGameObject
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[UnityEditor.MenuItem ("UI/UIImage")]
		public static GameObject CreateUIImage ()
		{
				GameObject image = new GameObject ("GameObject");
				image.transform.parent = UnityEditor.Selection.activeTransform;						
				image.name = "UIImage";				
				
				UIImage uiImage = image.AddComponent<UIImage> ();
				uiImage.width = 100;
				uiImage.height = 100;				
			
				
				return image;
		}
	#endif	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		public Action<UIGameObject> ImageChangedEvent;
	
		[SerializeField]
		Texture2D
				_image;

		public virtual Texture2D image {
				get {
						return _image;
				}
				set {
					
						if (_image == value) {
								return;
						}
						_image = value;
						invalidate ();
						if (ImageChangedEvent != null) {
								ImageChangedEvent (this);
						}
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		public Action<UIGameObject> ScaleModeChangedEvent;
	
		[SerializeField]
		ScaleMode
				_scaleMode = ScaleMode.StretchToFill;

		public ScaleMode scaleMode {
				get {
						return _scaleMode;
				}
				set {
						
			
			
						if (_scaleMode == value) {
								return;
						}
						_scaleMode = value;
						invalidate ();
						if (ScaleModeChangedEvent != null) {
								ScaleModeChangedEvent (this);
						}
						
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		public Action<UIGameObject> AlphaBlendChangedEvent;
	
		[SerializeField]
		bool
				_alphaBlend = true;
		
		public bool alphaBlend {
				get {
						return _alphaBlend;
				}
				set {
						
			
			
						if (_alphaBlend == value) {
								return;
						}
						_alphaBlend = value;
						invalidate ();
						if (AlphaBlendChangedEvent != null) {
								AlphaBlendChangedEvent (this);
						}
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		public Action<UIGameObject> ImageAspectChangedEvent;
	
		[SerializeField]	
		float
				_imageAspect = 0;

		public float imageAspect {
				get {
						return _imageAspect;
				}
				set {
						
						
						if (_imageAspect == value) {
								return;
						}
						_imageAspect = value;
						invalidate ();
						if (ImageAspectChangedEvent != null) {
								ImageAspectChangedEvent (this);
						}
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public override void draw (UIGameObject parentChild)
		{				
				if (image == null) {
						return;
				}
				GUI.DrawTexture (screenRect, image, scaleMode, alphaBlend, imageAspect);
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
