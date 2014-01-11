using UnityEngine;
using System.Collections;

public class AnchorUILayoutData : MonoBehaviour
{
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]		
		bool
				_leftAnchor = false;

		public bool leftAnchor {
				get {
						return _leftAnchor;
				}
				set {
						if (_leftAnchor == value) {
								return;
						}
						if (value && horizontalAnchor) {
								horizontalAnchor = false;
						}
						_leftAnchor = value;
						change ();
				}
		}
	
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		UIWidget
				_leftTarget;

		public UIWidget leftTarget {
				get {
						return _leftTarget;
				}
				set {
						if (_leftTarget == value) {
								return;
						}
						_leftTarget = value;			
						change ();
				}
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		int
				_left = 0;

		public int left {
				get {
						return _left;
				}
				set {
						if (_left == value) {
								return;
						}
						_left = value;
						change ();
				}
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		bool
				_rightAnchor = false;

		public bool rightAnchor {
				get {
						return _rightAnchor;
				}
				set {
						if (_rightAnchor == value) {
								return;
						}
						_rightAnchor = value;
						if (value && horizontalAnchor) {
								horizontalAnchor = false;
						}
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		UIWidget
				_rightTarget;

		public UIWidget rightTarget {
				get {
						return _rightTarget;
				}
				set {
						if (_rightTarget == value) {
								return;
						}
						_rightTarget = value;
						change ();
				}
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		int
				_right = 0;

		public int right {
				get {
						return _right;
				}
				set {
						if (_right == value) {
								return;
						}
						_right = value;
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		bool
				_topAnchor = false;

		public bool topAnchor {
				get {
						return _topAnchor;
				}
				set {
						if (_topAnchor == value) {
								return;
						}
						_topAnchor = value;
						if (value && verticalAnchor) {
								verticalAnchor = false;
						}
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		UIWidget
				_topTarget;

		public UIWidget topTarget {
				get {
						return _topTarget;
				}
				set {
						if (_topTarget == value) {
								return;
						}
						_topTarget = value;
						change ();
				}
		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		int
				_top = 0;

		public int top {
				get {
						return _top;
				}
				set {
						if (_top == value) {
								return;
						}
						_top = value;
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		bool
				_bottomAnchor = false;

		public bool bottomAnchor {
				get {
						return _bottomAnchor;
				}
				set {
						if (_bottomAnchor == value) {
								return;
						}
						_bottomAnchor = value;
						if (value && verticalAnchor) {
								verticalAnchor = false;
						}
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		UIWidget
				_bottomTarget;

		public UIWidget bottomTarget {
				get {
						return _bottomTarget;
				}
				set {
						if (_bottomTarget == value) {
								return;
						}
						_bottomTarget = value;						
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		int
				_bottom = 0;

		public int bottom {
				get {
						return _bottom;
				}
				set {
						if (_bottom == value) {
								return;
						}
						_bottom = value;
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		bool
				_verticalAnchor = false;

		public bool verticalAnchor {
				get {
						return _verticalAnchor;
				}
				set {
						if (_verticalAnchor == value) {
								return;
						}
						_verticalAnchor = value;						
						if (value && topAnchor) {
								topAnchor = false;
						}
						if (value && bottomAnchor) {
								bottomAnchor = false;
						}
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		UIWidget
				_verticalTarget;

		public UIWidget verticalTarget {
				get {
						return _verticalTarget;
				}
				set {
						if (_verticalTarget == value) {
								return;
						}
						_verticalTarget = value;
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		int
				_vertical = 0;

		public int vertical {
				get {
						return _vertical;
				}
				set {
						if (_vertical == value) {
								return;
						}
						_vertical = value;
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		bool
				_horizontalAnchor = false;

		public bool horizontalAnchor {
				get {
						return _horizontalAnchor;
				}
				set {
						if (_horizontalAnchor == value) {
								return;
						}
						_horizontalAnchor = value;
						if (value && leftAnchor) {
								leftAnchor = false;
						}
						if (value && rightAnchor) {
								rightAnchor = false;
						}
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		[SerializeField]
		UIWidget
				_horizontalTarget;

		public UIWidget horizontalTarget {
				get {
						return _horizontalTarget;
				}
				set {
						if (_horizontalTarget == value) {
								return;
						}
						_horizontalTarget = value;
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		[SerializeField]
		int
				_horizontal = 0;

		public int horizontal {
				get {
						return _horizontal;
				}
				set {
						if (_horizontal == value) {
								return;
						}
						_horizontal = value;
						change ();
				}
		}
		
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	
		void change ()
		{
				if (gameObject.transform.parent == null) {
						return;
				}
				UIInvalidator.invalidate (gameObject.transform.parent.gameObject, UIWidget.LAYOUT_INVALIDATION_FLAG);
		}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
