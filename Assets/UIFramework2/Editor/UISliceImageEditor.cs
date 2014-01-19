using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UISliceImage))]

public class UISliceImageEditor : UIImageEditor
{

		public override void OnInspectorGUI ()
		{				
				drawUISliceImageInspector ();
				drawUIImageInspector ();
				drawUIGameObjectInspector ();
				updateRoot ();
		}
	
		[SerializeField]
		bool
				sliceImageFoldout = true;
	
	
		protected void drawUISliceImageInspector ()
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
						
						EditorGUI.indentLevel--;						
		
				}
		}
}
