using UnityEngine;
using System.Collections;
using UnityEditor;

public class UIRootWidgetListWindow : EditorWindow
{

		[MenuItem ("UI/UIRootWidgetList")]
	
		static void Init ()
		{
				// Get existing open window or if none, make a new one:
				UIRootWidgetListWindow window = (UIRootWidgetListWindow)EditorWindow.GetWindow (typeof(UIRootWidgetListWindow));
		}
		
		void Update ()
		{
				Debug.Log (Selection.activeGameObject);
		}
		
		
	
}
