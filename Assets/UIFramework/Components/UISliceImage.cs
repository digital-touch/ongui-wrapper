using UnityEngine;
using UnityEditor;
using System.Collections;


[ExecuteInEditMode]
public class UISliceImage : UIWidget
{

		public static readonly string BORDER_FLAG = "uisliceimage-border";
		public static readonly string IMAGE_FLAG = "uisliceimage-image";

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[MenuItem ("UI/UISliceImage")]
		public static GameObject CreateUISliceImage ()
		{
				GameObject slice = new GameObject ("GameObject");
				slice.name = "UISliceImage";
				
				UISliceImage uiImage = slice.AddComponent<UISliceImage> ();
				uiImage.width = 100;
				uiImage.height = 100;
		
			
						
				slice.transform.parent = Selection.activeTransform;						
				return slice;
		}
	#endif	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
						
		public GUIStyle
				style = new GUIStyle ();
			
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		[SerializeField]
		RectOffset
				_border = new RectOffset ();
				
		public RectOffset border {
				get {
						return _border;
				}
				set {
						if (_border == value) {
								return;
						}
						_border = value;
						UIInvalidator.invalidate (gameObject, UISliceImage.BORDER_FLAG);
				}
		}
		
		public int borderLeft {
				get {
						return _border.left;
				}
				set {
						if (_border.left == value) {
								return;
						}
						_border.left = value;
						UIInvalidator.invalidate (gameObject, UISliceImage.BORDER_FLAG);
				}
		}
	
		public int borderRight {
				get {
						return _border.right;
				}
				set {
						if (_border.right == value) {
								return;
						}
						_border.right = value;
						UIInvalidator.invalidate (gameObject, UISliceImage.BORDER_FLAG);
				}
		}
	
		public int borderTop {
				get {
						return _border.top;
				}
				set {
						if (_border.top == value) {
								return;
						}
						_border.top = value;
						UIInvalidator.invalidate (gameObject, UISliceImage.BORDER_FLAG);
				}
		}
	
		public int borderBottom {
				get {
						return _border.bottom;
				}
				set {
						if (_border.bottom == value) {
								return;
						}
						_border.bottom = value;
						UIInvalidator.invalidate (gameObject, UISliceImage.BORDER_FLAG);
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		Texture2D
				_image;
		
		public Texture2D image {
				get {
						return _image;
				}
				set {
			
						if (_image == value) {
								return;
						}
						_image = value;						
						UIInvalidator.invalidate (gameObject, UISliceImage.IMAGE_FLAG);
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		override protected void Awake ()
		{	
				base.Awake ();				
		
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
		
				bool borderDirty = UIInvalidator.isInvalid (gameObject, UISliceImage.BORDER_FLAG);
				if (borderDirty) {
			
						style.border = border;
			
			
				}
		
				bool imageDirty = UIInvalidator.isInvalid (gameObject, UISliceImage.IMAGE_FLAG);						
		
				if (imageDirty) {
						style.normal.background = image;
			
				}
		
		
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public override void Draw (UIWidget parentWidgetTransform)
		{		
				base.Draw (parentWidgetTransform);
		
				
				if (image == null) {
						return;
				}				
				GUI.Box (screenBounds, "", style);
		
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
