using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class UIInvalidator
{		

		public static readonly string ALL_INVALIDATION_FLAG = "all";					
				
		public static void validate ()
		{
				while (invalidables.Count > 0) {
						Invalidable invalidable = invalidables [0];
						if (invalidable.widget != null) {
								UIWidgetValidator validator = invalidable.widget.GetComponent<UIWidgetValidator> ();
								if (validator == null) {
										return;
								}
								validator.Validate ();
						}
						invalidables.RemoveAt (0);						
				}
		}
	
		public static void invalidate (UIWidget widget)
		{
				invalidate (widget, ALL_INVALIDATION_FLAG);
		}
	
		public static bool isInvalid (UIWidget widget, string flag)
		{
				Invalidable invalidable = getInvalidable (widget);
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
		
		public static void invalidate (UIWidget widget, string flag)
		{
				Invalidable invalidable = getInvalidable (widget);
				if (invalidable == null) {
						invalidable = new Invalidable (widget);
						if (flag == ALL_INVALIDATION_FLAG) {
								invalidable.allFlag = true;
						} else {
								invalidable.flags.Add (flag);
						}
				}
				invalidables.Add (invalidable);
		}

		static List<Invalidable> invalidables = new List<Invalidable> ();
		
		static Invalidable getInvalidable (UIWidget widget)
		{
				for (int i = 0; i < invalidables.Count; i++) {
						Invalidable invalidable = invalidables [i];
						if (invalidable.widget == widget) {
								return invalidable;
						}
				}
				return null;				
		}
	
		
}
class Invalidable
{
		public bool allFlag;
		public UIWidget widget;
		public List<string> flags;
		
		public Invalidable (UIWidget widget)
		{			
				this.widget = widget;
				flags = new List<string> ();
				allFlag = false;
		}
}
