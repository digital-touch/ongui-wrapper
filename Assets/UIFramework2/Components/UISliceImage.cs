using UnityEngine;

using System.Collections;
using System;

[ExecuteInEditMode]
public class UISliceImage : UIImage
{

		
		///////////////////////////////////////////////////////////////////////////////////////////////////
						
		GUIStyle
				style = new GUIStyle ();
			
		protected void validateStyle ()
		{
				style.normal.background = image;
				if (style.border != _border) {
						style.border = _border;
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////
		
		public override void validate ()
		{
				validateStyle ();
				base.validate ();
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
						invalidate ();				
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
						invalidate ();
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
						invalidate ();
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
						invalidate ();
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
						invalidate ();
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
						invalidate ();
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
