using UnityEngine;

using System.Collections;
using System;
using System.Reflection;
#if UNITY_EDITOR
public static class ToolSupport
{
		public static bool Hidden {
			
				get {
				
						Type type = typeof(UnityEditor.Tools);
				
						FieldInfo field = type.GetField ("s_Hidden", BindingFlags.NonPublic | BindingFlags.Static);
				
						return ((bool)field.GetValue (null));
				
				}
			
				set {
				
						Type type = typeof(UnityEditor.Tools);
				
						FieldInfo field = type.GetField ("s_Hidden", BindingFlags.NonPublic | BindingFlags.Static);
				
						field.SetValue (null, value);
				
				}
			
		}
		
	
}
#endif