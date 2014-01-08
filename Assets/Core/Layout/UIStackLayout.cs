using UnityEngine;
using System.Collections;

public class UIStackLayout : UILayout
{

		int _selectedIndex = -1;

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

		public override ContentSize Layout ()
		{				
				for (int i = 0; i < transform.childCount; i++) {
						Transform child = transform.GetChild (i);
						UIWidget childWidget = child.GetComponent<UIWidget> ();
						if (childWidget == null) {
								continue;
						}
						if (!childWidget.includeInLayout) {
								continue;
						}
						
						UIWidgetTransform childTransform = child.GetComponent<UIWidgetTransform> ();						
			
						if (i != selectedIndex) {
								childTransform.isVisible = false;
								//childTransform.width = (int)widgetTransform.width;
								//childTransform.height = (int)widgetTransform.height;
								continue;
						}
						childTransform.isVisible = true;
						
						//childTransform.width = (int)widgetTransform.width;
						//childTransform.height = (int)widgetTransform.height;
						
						//contentSize.x = Mathf.Max (contentSize.x, childTransform.width);
						//contentSize.y = Mathf.Max (contentSize.y, childTransform.height);
												
						
				}
				
				return null;
			
		}
	
			
}
