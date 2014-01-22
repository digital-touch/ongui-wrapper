using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIStackLayout : UILayout
{
		public UITween showEffect;
		
		public UITween hideEffect;
	
		[SerializeField]
		public List<UIGameObject>
				elements = new List<UIGameObject> ();

//		public List<UIGameObject> elements {
//				get {
//						return _elements;
//				}
//				set {
//						_elements = value;
//						Layout ();
//				}
//		}
		
		protected int lastSelectedIndex = -1;
		[SerializeField]
		int
				_selectedIndex = -1;

		[BindableAttribute]
		public int selectedIndex {
				get {
						return _selectedIndex;
				}
				set {
						if (_selectedIndex != value) {
								lastSelectedIndex = _selectedIndex;
								_selectedIndex = value;
								Layout ();
						}
				}
		}

		public override void Layout ()
		{				
				UIGameObject uIGameObject = GetComponent<UIGameObject> ();
				
				contentSize.Set (uIGameObject.width, uIGameObject.height);
				
				for (int i = 0; i < uIGameObject.numChildren; i++) {
				
						UIGameObject child = uIGameObject.getChild (i);
						
						if (child == null) {
								continue;
						}
						
						if (!child.includeInLayout) {
								continue;
						}
						
						if (i != selectedIndex) {
								hide (child);						
						} else {						
								show (child);								
						}																		
				}
			
		}

		void show (UIGameObject child)
		{		
				if (showEffect != null) {
						child.isVisible = true;
						showEffect.target = child;						
						showEffect.Play ();
				} else {
						child.isVisible = true;
				}
		}	
			
		void hide (UIGameObject child)
		{
				if (hideEffect != null) {
						hideEffect.target = child;
						hideEffect.CompletedEvent += (UITween obj) => {
								child.isVisible = false;
				
						};
						hideEffect.Play ();
				} else {
						child.isVisible = false;
				}
	
		}
}
