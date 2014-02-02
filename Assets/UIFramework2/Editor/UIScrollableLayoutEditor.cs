using UnityEngine;
using UnityEditor;
using System.Collections;
	
[CustomEditor(typeof(UIScrollableLayout), true)]
public class UIScrollableLayoutEditor : UILayoutEditor
{
		
		public override void OnInspectorGUI ()
		{				
				drawUIScrollableLayoutInspector ();
				drawUILayoutInspector ();
			
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
		
		[SerializeField]
		bool
				scrollableLayoutFoldout = true;
		
		protected void drawUIScrollableLayoutInspector ()
		{
			
				UIScrollableLayout layout = (UIScrollableLayout)target;
			
				// button
				scrollableLayoutFoldout = EditorGUILayout.Foldout (scrollableLayoutFoldout, "Scrollable Layout");
			
				if (scrollableLayoutFoldout) {
				
						EditorGUI.indentLevel++;
				
				
				
						layout.lockMinScrollPosition = EditorGUILayout.ToggleLeft ("Lock Minimum Scroll Position", layout.lockMinScrollPosition);
				
						if (layout.lockMinScrollPosition) {
								layout.minScrollPosition = EditorGUILayout.Vector2Field ("Minimum Scroll Position", layout.minScrollPosition);
						}
				
						layout.lockMaxScrollPosition = EditorGUILayout.ToggleLeft ("Lock Maximum Scroll Position", layout.lockMaxScrollPosition);
				
						if (layout.lockMaxScrollPosition) {
								layout.maxScrollPosition = EditorGUILayout.Vector2Field ("Maximum Scroll Position", layout.maxScrollPosition);
						}
				
						if (layout.lockMaxScrollPosition && layout.lockMinScrollPosition) {
								float newScrollPositionX = EditorGUILayout.Slider ("Scroll Position X:", layout.scrollPosition.x, layout.minScrollPosition.x, layout.maxScrollPosition.x);
								float newScrollPositionY = EditorGUILayout.Slider ("Scroll Position Y:", layout.scrollPosition.y, layout.minScrollPosition.y, layout.maxScrollPosition.y);
								layout.setScrollPosition (newScrollPositionX, newScrollPositionY);
						} else {
								float newScrollPositionX = EditorGUILayout.FloatField ("Scroll Position X:", layout.scrollPosition.x);
								float newScrollPositionY = EditorGUILayout.FloatField ("Scroll Position Y:", layout.scrollPosition.y);
								layout.setScrollPosition (newScrollPositionX, newScrollPositionY);
						}
				
						EditorGUI.indentLevel--;
				}
		}			
		
		
}