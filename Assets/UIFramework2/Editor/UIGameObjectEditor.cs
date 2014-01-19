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
		
		protected void drawUIGameObjectInspector ()
		{
				UIGameObject uiGameObject = (UIGameObject)target;
		
				// transform
				transformFoldout = EditorGUILayout.Foldout (transformFoldout, "Transform");
		
				if (transformFoldout) {
			
			
						EditorGUI.indentLevel++;
						
						// bounding
						uiGameObject.x = EditorGUILayout.IntField ("x", uiGameObject.x);
						uiGameObject.y = EditorGUILayout.IntField ("y", uiGameObject.y);
						uiGameObject.width = EditorGUILayout.IntField ("width", uiGameObject.width);
						uiGameObject.height = EditorGUILayout.IntField ("height", uiGameObject.height);
						
						EditorGUILayout.Space ();
						
						// rotation
						uiGameObject.rotation = EditorGUILayout.FloatField ("Rotation", uiGameObject.rotation);
						uiGameObject.rotationPivot = EditorGUILayout.Vector2Field ("Rotation Pivot", uiGameObject.rotationPivot);
						uiGameObject.rotationPivotType = (PivotType)EditorGUILayout.EnumPopup ("Rotation Pivot Type", uiGameObject.rotationPivotType);
			
						EditorGUILayout.Space ();
						
						// scale
						uiGameObject.scaleX = EditorGUILayout.FloatField ("scaleX", uiGameObject.scaleX);
						uiGameObject.scaleY = EditorGUILayout.FloatField ("scaleY", uiGameObject.scaleY);
						uiGameObject.scalePivot = EditorGUILayout.Vector2Field ("Scale Pivot", uiGameObject.scalePivot);
						uiGameObject.scalePivotType = (PivotType)EditorGUILayout.EnumPopup ("Rotation Pivot Type", uiGameObject.scalePivotType);
			
						EditorGUILayout.Space ();			
						
						//depth
			
						EditorGUILayout.LabelField ("Depth", uiGameObject.depth.ToString ());
						EditorGUILayout.BeginHorizontal ();
						if (GUILayout.Button ("-")) {
								uiGameObject.depth--;
						}						
						if (GUILayout.Button ("+")) {
								uiGameObject.depth++;
						}
						EditorGUILayout.EndHorizontal ();
						
						EditorGUI.indentLevel--;
				}
				
				// render
				
				renderFoldout = EditorGUILayout.Foldout (renderFoldout, "Render");
		
				if (renderFoldout) {
			
						EditorGUI.indentLevel++;
			
						uiGameObject.isVisible = EditorGUILayout.Toggle ("Visible", uiGameObject.isVisible);
						uiGameObject.alpha = EditorGUILayout.Slider ("Alpha", uiGameObject.alpha, 0, 1);
						uiGameObject.color = EditorGUILayout.ColorField ("Color", uiGameObject.color);
						
						EditorGUI.indentLevel--;
				}
		}
}
