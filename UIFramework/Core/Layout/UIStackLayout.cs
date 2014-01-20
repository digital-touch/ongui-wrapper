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
				
				contentSize.Set (widget.width, widget.height);
				
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childWidget = child.GetComponent<UIWidget> ();
						if (childWidget == null) {
								continue;
						}
						if (!childWidget.includeInLayout) {
								continue;
						}
						
						childWidget.width = widget.width;
						childWidget.height = widget.height;
			
						if (i != selectedIndex) {
								childWidget.isVisible = false;
						
						} else {						
								childWidget.isVisible = true;
						}																		
				}
			
		}
	
			
}
