
	
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

[CustomEditor(typeof(UIGameObjectInitializer))]
public class UIGameObjectInitializerEditor : Editor
{

		[SerializeField]
		List<Type>
				assignableTypes = new List<Type> ();
		
		[SerializeField]
		List<string>
				assignableTypeNames = new List<string> ();
	
		void Awake ()
		{
				createAssingableTypes ();
		}
		
		void createAssingableTypes ()
		{
				assignableTypes.Clear ();
				assignableTypeNames.Clear ();
				Type ti = typeof(UIGameObject);
				Assembly asm = Assembly.GetAssembly (ti);
				
				//Debug.Log (asm.GetName ());
				Type[] types = asm.GetTypes ();
				//Debug.Log (types.Length);
				foreach (Type t in types) {
						//Debug.Log (t.Name + ", " + t.IsSubclassOf (ti));
						if (t.IsSubclassOf (ti)) {
								assignableTypes.Add (t);
								assignableTypeNames.Add (t.Name);
						}
				}
				
		}

		
		public override void OnInspectorGUI ()
		{		
		
				drawUISkinStyleGUI ();
			
				if (GUI.changed) {
						EditorUtility.SetDirty (target);
				}
		}
		
		
		
		
		void drawUISkinStyleGUI ()
		{
				UIGameObjectInitializer uiSkinStyle = (UIGameObjectInitializer)target;
				
				// type
				
				int selectedIndex = -1;
				
				if (uiSkinStyle.target != null) {
						selectedIndex = assignableTypes.LastIndexOf (uiSkinStyle.target);
				}
		
				selectedIndex = EditorGUILayout.Popup ("Type", selectedIndex, assignableTypeNames.ToArray ());
				if (selectedIndex >= 0) {
						uiSkinStyle.target = assignableTypes [selectedIndex];
				}
				
				// style name
				
				uiSkinStyle.styleName = EditorGUILayout.TextField ("Style Name", uiSkinStyle.styleName);
		}			
		
}
