using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(UIGameObject), true)]
public class UIGameObjectEditor : Editor
{

		public override void OnInspectorGUI ()
		{
				drawUIGameObjectInspector ();
				updateRoot ();
		}
				
		protected void updateRoot ()
		{
				if (GUI.changed) {
						UIGameObject uiGameObject = (UIGameObject)target;
						if (uiGameObject.root == null) {
								return;
						}
						EditorUtility.SetDirty (uiGameObject.root);
				}
		}
			
			
		[SerializeField]
		bool
				transformFoldout = true;
				
		[SerializeField]
		bool
				renderFoldout = true;
				
		[SerializeField]
		bool
				rotationFoldout = false;
				
		[SerializeField]
		bool
				scaleFoldout = false;
		
		protected void drawUIGameObjectInspector ()
		{
				UIGameObject uiGameObject = (UIGameObject)target;
		
				// transform


//		GUIStyle foldout2 = EditorStyles.foldout;
//		Rect position = GUILayoutUtility.GetRect (EditorGUIUtility.fieldWidth, EditorGUIUtility.fieldWidth, 16f, 16f, foldout2);
//		EditorGUI.DrawRect (position, Color.red);
//		GUILayout.		



				transformFoldout = EditorGUILayout.Foldout (transformFoldout, "Transform");

				if (transformFoldout) {
			
			
						EditorGUI.indentLevel++;
						
						// bounding
						EditorGUILayout.BeginHorizontal ();
			
						uiGameObject.x = EditorGUILayout.IntField ("x", uiGameObject.x);
						uiGameObject.width = EditorGUILayout.IntField ("width", uiGameObject.width);
						
						EditorGUILayout.EndHorizontal ();	
						EditorGUILayout.BeginHorizontal ();
			
						uiGameObject.y = EditorGUILayout.IntField ("y", uiGameObject.y);
						uiGameObject.height = EditorGUILayout.IntField ("height", uiGameObject.height);
						
						EditorGUILayout.EndHorizontal ();	
							
						//depth
			
						EditorGUILayout.BeginHorizontal ();
			
						EditorGUILayout.LabelField ("Depth", uiGameObject.depth.ToString ());
			
						if (GUILayout.Button ("-")) {
								uiGameObject.depth--;
						}						
						if (GUILayout.Button ("+")) {
								uiGameObject.depth++;
						}
						EditorGUILayout.EndHorizontal ();
			
			
			
						// rotation
						rotationFoldout = EditorGUILayout.Foldout (rotationFoldout, "Rotation");
						
						if (rotationFoldout) {
								EditorGUI.indentLevel++;
			
								uiGameObject.rotation = EditorGUILayout.FloatField ("Angle", uiGameObject.rotation);
								
								
				
								uiGameObject.rotationPivot = EditorGUILayout.Vector2Field ("Pivot", uiGameObject.rotationPivot);
								uiGameObject.rotationPivotType = (PivotType)EditorGUILayout.EnumPopup ("Pivot Type", uiGameObject.rotationPivotType);
								
								
								
								EditorGUI.indentLevel--;								
						}
			
						
						// scale
						
						scaleFoldout = EditorGUILayout.Foldout (scaleFoldout, "Scale");
			
						if (scaleFoldout) {
								
								EditorGUI.indentLevel++;
								
								EditorGUILayout.BeginHorizontal ();
								
								uiGameObject.scaleX = EditorGUILayout.FloatField ("X", uiGameObject.scaleX);
								uiGameObject.scaleY = EditorGUILayout.FloatField ("Y", uiGameObject.scaleY);
								
								EditorGUILayout.EndHorizontal ();				
								
								
								uiGameObject.scalePivot = EditorGUILayout.Vector2Field ("Pivot", uiGameObject.scalePivot);
								uiGameObject.scalePivotType = (PivotType)EditorGUILayout.EnumPopup ("Pivot Type", uiGameObject.scalePivotType);
								
								
								
								EditorGUI.indentLevel--;
						}
						
						
						
												
						EditorGUI.indentLevel--;
				}
				
				// render
				
				renderFoldout = EditorGUILayout.Foldout (renderFoldout, "Render");
		
				if (renderFoldout) {
			
						EditorGUI.indentLevel++;

//			Rect space = EditorGUILayout.BeginHorizontal();
//			EditorGUILayout.TextArea(string.Empty, GUIStyle.none, GUILayout.Height(111));
//			EditorGUILayout.EndHorizontal();
			
			//GUI.Button(space, "space");

						uiGameObject.isTouchable = EditorGUILayout.Toggle ("Touchable", uiGameObject.isTouchable);

						uiGameObject.manageChildrenVisibility = EditorGUILayout.Toggle ("Manage Children Visibility", uiGameObject.manageChildrenVisibility);

						uiGameObject.includeInLayout = EditorGUILayout.Toggle ("Include In Layout", uiGameObject.includeInLayout);
			
						uiGameObject.isVisible = EditorGUILayout.Toggle ("Visible", uiGameObject.isVisible);
						
						EditorGUILayout.BeginHorizontal ();	
						uiGameObject.alpha = EditorGUILayout.Slider ("Alpha", uiGameObject.alpha, 0, 1);
						uiGameObject.color = EditorGUILayout.ColorField ("Color", uiGameObject.color);
						EditorGUILayout.EndHorizontal ();	
						
						EditorGUI.BeginChangeCheck ();
															
						// styleNames
						SerializedProperty styleNames = serializedObject.FindProperty ("styleNames");
						EditorGUILayout.PropertyField (styleNames, true);
						
						
						if (EditorGUI.EndChangeCheck ()) {
								serializedObject.ApplyModifiedProperties ();
						}
						EditorGUI.indentLevel--;
				}
		}
		
//		public void ListIterator (string propertyPath, ref bool visible)
//		{
//				SerializedProperty listProperty = serializedObject.FindProperty (propertyPath);
//				visible = EditorGUILayout.Foldout (visible, listProperty.name);
//				if (visible) {
//						EditorGUI.indentLevel++;
//						for (int i = 0; i < listProperty.arraySize; i++) {
//								SerializedProperty elementProperty = listProperty.GetArrayElementAtIndex (i);
//								Rect drawZone = GUILayoutUtility.GetRect (0f, 16f);
//								bool showChildren = EditorGUI.PropertyField (drawZone, elementProperty); 
//						}
//						EditorGUI.indentLevel--;
//				}
//		}
}
