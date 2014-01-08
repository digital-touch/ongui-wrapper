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
				slice.AddComponent<UIWidgetInvalidator> ();	
				UIWidgetTransform widgetTransform = slice.AddComponent<UIWidgetTransform> ();
				widgetTransform.width = 100;
				widgetTransform.height = 100;	
				slice.AddComponent<UISliceImage> ();		
				slice.AddComponent<UISliceImageValidator> ();			
				slice.AddComponent<UISliceImageRenderer> ();
				slice.AddComponent<UIWidgetInteraction> ();				
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
						widgetInvalidator.setDirty (UISliceImage.BORDER_FLAG);
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
						widgetInvalidator.setDirty (UISliceImage.BORDER_FLAG);
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
						widgetInvalidator.setDirty (UISliceImage.BORDER_FLAG);
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
						widgetInvalidator.setDirty (UISliceImage.BORDER_FLAG);
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
						widgetInvalidator.setDirty (UISliceImage.BORDER_FLAG);
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
						widgetInvalidator.setDirty (UISliceImage.IMAGE_FLAG);
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
}
