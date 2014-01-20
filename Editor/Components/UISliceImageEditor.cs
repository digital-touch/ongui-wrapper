using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UISliceImage))]

public class UISliceImageEditor : UIWidgetEditor
{

		public override void OnInspectorGUI ()
		{				
				base.OnInspectorGUI ();
		
				drawUISliceImageInspector ();
		
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
	
		[SerializeField]
		bool
				sliceImageFoldout = true;
	
	
		void drawUISliceImageInspector ()
		{		
				UISliceImage sliceImage = (UISliceImage)target;
		
				// sliceimage
				sliceImageFoldout = EditorGUILayout.Foldout (sliceImageFoldout, "SliceImage");
		
				if (sliceImageFoldout) {
			
						EditorGUI.indentLevel++;
		
						sliceImage.borderLeft = EditorGUILayout.IntField ("left", sliceImage.borderLeft);
						sliceImage.borderRight = EditorGUILayout.IntField ("right", sliceImage.borderRight);
						sliceImage.borderTop = EditorGUILayout.IntField ("top", sliceImage.borderTop);
						sliceImage.borderBottom = EditorGUILayout.IntField ("bottom", sliceImage.borderBottom);
						
						sliceImage.image = (Texture2D)EditorGUILayout.ObjectField ("Texture", sliceImage.image, typeof(Texture2D), true);
				
						EditorGUI.indentLevel--;						
		
				}
		}
}
