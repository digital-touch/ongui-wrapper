using UnityEngine;
using System.Collections;

public class UIStackLayout : UILayout
{

		int _selectedIndex = 0;

		public int selectedIndex {
				get {
						return _selectedIndex;
				}
				set {
						if (_selectedIndex != value) {
								_selectedIndex = value;
								Layout ();
						}
				}
		}

		public override void Layout ()
		{				
				UIGameObject uIGameObject = GetComponent<UIGameObject> ();
				contentSize.Set (uIGameObject.width, uIGameObject.height);
				
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIGameObject childWidget = child.GetComponent<UIGameObject> ();
						if (childWidget == null) {
								continue;
						}
						if (!childWidget.includeInLayout) {
								continue;
						}
						
						childWidget.width = uIGameObject.width;
						childWidget.height = uIGameObject.height;
			
						if (i != selectedIndex) {
								childWidget.isVisible = false;
						
						} else {						
								childWidget.isVisible = true;
						}																		
				}
			
		}
	
			
}
