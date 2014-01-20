using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIScroller))]

public class UIScrollerEditor : UIWidgetEditor
{
	
		public override void OnInspectorGUI ()
		{				
				drawUIScrollerInspector ();
		
				base.OnInspectorGUI ();		
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		bool scrollerFoldout = true;	
	
		void drawUIScrollerInspector ()
		{		
				UIScroller scroller = (UIScroller)target;
		
				// label
				scrollerFoldout = EditorGUILayout.Foldout (scrollerFoldout, "Scroller");
		
				if (scrollerFoldout) {
			
						EditorGUILayout.LabelField ("Scroll Position:", EditorStyles.boldLabel);
			
						scroller.scrollPositionX = EditorGUILayout.FloatField ("X", scroller.scrollPositionX);
						scroller.scrollPositionY = EditorGUILayout.FloatField ("Y", scroller.scrollPositionY);
						EditorGUILayout.Space ();
						scroller.throwDrag = EditorGUILayout.FloatField ("Throw Drag", scroller.throwDrag);
			
			
				}
		}
}
