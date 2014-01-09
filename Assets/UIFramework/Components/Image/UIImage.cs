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
				
				UIWidgetTransform widgetTransform = image.AddComponent<UIWidgetTransform> ();
				widgetTransform.width = 100;
				widgetTransform.height = 100;		
				image.AddComponent<UIImage> ();		
				image.AddComponent<UIImageValidator> ();			
				image.AddComponent<UIImageRenderer> ();
				image.AddComponent<UIWidgetInteraction> ();
			
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
						UIInvalidator.invalidate (this, UIImage.IMAGE_FLAG);
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
						UIInvalidator.invalidate (this, UIImage.STYLE_FLAG);
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
						UIInvalidator.invalidate (this, UIImage.STYLE_FLAG);
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
						UIInvalidator.invalidate (this, UIImage.STYLE_FLAG);
				}
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		bool
				_autoSize = true;
		
		public bool autoSize {
				get {
						return _autoSize;
				}
				set {
						if (_autoSize == value) {
								return;
						}
						_autoSize = value;
						UIInvalidator.invalidate (this, UIImage.AUTO_SIZE_FLAG);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		override protected void Awake ()
		{	
				base.Awake ();
				UIInvalidator.invalidate (this, UIImage.IMAGE_FLAG);
		
		}	
	
		override protected void OnDestroy ()
		{
				base.OnDestroy ();
		}
    
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
