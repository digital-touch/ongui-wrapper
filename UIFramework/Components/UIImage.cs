using UnityEngine;
using UnityEditor;
using System.Collections;

[System.Serializable]
[ExecuteInEditMode]
public class UIImage : UIWidget
{

		public static readonly string IMAGE_FLAG = "uiimage-image";
		public static readonly string STYLE_FLAG = "uiimage-style";
		public static readonly string AUTO_SIZE_FLAG = "uiimage-auto-size";

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UIImage")]
		public static GameObject CreateUIImage ()
		{
				GameObject image = new GameObject ("GameObject");
				image.name = "UIImage";				
				
				UIImage uiImage = image.AddComponent<UIImage> ();
				uiImage.width = 100;
				uiImage.height = 100;				
								
					
				
			
				image.transform.parent = Selection.activeTransform;						
				
				return image;
		}
	#endif	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		Texture
				_image;

		public Texture image {
				get {
						return _image;
				}
				set {
					
						if (_image == value) {
								return;
						}
						_image = value;
						UIInvalidator.invalidate (gameObject, UIImage.IMAGE_FLAG);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

		[SerializeField]
		ScaleMode
				_scaleMode;

		public ScaleMode scaleMode {
				get {
						return _scaleMode;
				}
				set {
						
			
			
						if (_scaleMode == value) {
								return;
						}
						_scaleMode = value;
						UIInvalidator.invalidate (gameObject, UIImage.STYLE_FLAG);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

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
						UIInvalidator.invalidate (gameObject, UIImage.STYLE_FLAG);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////

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
						UIInvalidator.invalidate (gameObject, UIImage.STYLE_FLAG);
				}
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		bool
				_autoSize = false;
		
		public bool autoSize {
				get {
						return _autoSize;
				}
				set {
						if (_autoSize == value) {
								return;
						}
						_autoSize = value;
						UIInvalidator.invalidate (gameObject, UIImage.AUTO_SIZE_FLAG);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		override protected void Awake ()
		{	
				base.Awake ();
				UIInvalidator.invalidate (gameObject, UIImage.IMAGE_FLAG);
		
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
		
				
				bool isImageDirty = UIInvalidator.isInvalid (gameObject, UIImage.IMAGE_FLAG);
		
				bool isAutoSizeDirty = UIInvalidator.isInvalid (gameObject, UIImage.AUTO_SIZE_FLAG);
		
				if (isImageDirty || isAutoSizeDirty) {
						if (image != null && autoSize) {
								width = image.width;
								height = image.height;
						} else {
				
						}
			
				}
		
		
		}
    
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public override void Draw (UIWidget parentWidgetTransform)
		{		
		
				
		
				if (image == null) {
						return;
				}
		
		
				GUI.DrawTexture (screenBounds, image, scaleMode, alphaBlend, imageAspect);
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
