using UnityEngine;

using System.Collections;
using System;

[ExecuteInEditMode]
public class UISliceImage : UIImage
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
	#if UNITY_EDITOR
	
		[UnityEditor.MenuItem ("UI/UISliceImage")]
		public static GameObject CreateUISliceImage ()
		{
				GameObject slice = new GameObject ("GameObject");
				slice.name = "UISliceImage";
				
				UISliceImage uiImage = slice.AddComponent<UISliceImage> ();
				uiImage.width = 100;
				uiImage.height = 100;
						
				slice.transform.parent = UnityEditor.Selection.activeTransform;						
				return slice;
		}
	#endif	
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
						
		GUIStyle
				style = new GUIStyle ();
			
		void updateStyle ()
		{
				style.normal.background = image;
				if (style.border != _border) {
						style.border = _border;
				}
		}
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
						updateStyle ();						
						FireBorderChanged ();
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
						updateStyle ();	
						FireBorderChanged ();
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
						updateStyle ();	
						FireBorderChanged ();
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
						updateStyle ();	
						FireBorderChanged ();
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
						updateStyle ();	
						FireBorderChanged ();
				}
		}
	
		public Action<UIGameObject> FireBorderChangedEvent;
	
		void FireBorderChanged ()
		{
				if (FireBorderChangedEvent != null) {
						FireBorderChangedEvent (this);
				}
		}
		
		public override Texture2D image {
				get {
						return base.image;
				}
				set {
			
						if (base.image == value) {
								return;
						}
						base.image = value;
						updateStyle ();
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public override void draw (UIGameObject parentChild)
		{						
				if (image == null) {
						return;
				}				
				GUI.Box (screenRect, "", style);
		
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////
}
