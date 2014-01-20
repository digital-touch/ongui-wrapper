using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public static class UIInvalidator
{		

		public static readonly string ALL_INVALIDATION_FLAG = "all";					
				
		public static void validate ()
		{
				while (invalidables.Count > 0) {
						Invalidable invalidable = invalidables [0];
						if (invalidable.gameObject != null) {
								UIWidget widget = invalidable.gameObject.GetComponent<UIWidget> ();
								widget.Validate ();
						}
						invalidables.RemoveAt (0);						
				}
		}
	
		public static void invalidate (GameObject gameObject)
		{
				invalidate (gameObject, ALL_INVALIDATION_FLAG);
		}
	
		public static bool isInvalid (GameObject gameObject, string flag)
		{
				Invalidable invalidable = getInvalidable (gameObject);
				if (invalidable == null) {
						return false;
				} else {
						if (flag == ALL_INVALIDATION_FLAG && invalidable.allFlag || invalidable.allFlag) {
								return true;
						} else {
								return invalidable.flags.Contains (flag);
						}
				}
		}
		
		public static void invalidate (GameObject gameObject, string flag)
		{				
				Invalidable invalidable = getInvalidable (gameObject);
				
				if (invalidable == null) {
						invalidable = new Invalidable (gameObject);
						invalidables.Add (invalidable);
				}
					
				if (flag == ALL_INVALIDATION_FLAG) {
						invalidable.allFlag = true;
				} else {
						invalidable.flags.Add (flag);
				}
				
#if UNITY_EDITOR
				EditorUtility.SetDirty (gameObject.gameObject);
#endif					
				
		}

		public static List<Invalidable> invalidables = new List<Invalidable> ();
		
		static Invalidable getInvalidable (GameObject gameObject)
		{
				for (int i = 0; i < invalidables.Count; i++) {
						Invalidable invalidable = invalidables [i];
						if (invalidable.gameObject == gameObject) {
								return invalidable;
						}
				}
				return null;				
		}
	
		
}
public class Invalidable
{
		public bool allFlag;
		public GameObject gameObject;
		public List<string> flags;
		
		public Invalidable (GameObject gameObject)
		{			
				this.gameObject = gameObject;
				flags = new List<string> ();
				allFlag = false;
		}
}
