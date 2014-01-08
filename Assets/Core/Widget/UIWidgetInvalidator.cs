using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class UIWidgetInvalidator : MonoBehaviour
{

		///////////////////////////////////////////////////////////////////////////////////////////////////
	
		Dictionary<string, bool>
				dirtyFlags = new Dictionary<string, bool> ();
	
		public bool isDirty (string flag)
		{
				return dirtyFlags.ContainsKey (flag);
		}
	
		public void setDirty (string flag)
		{
				//Debug.Log ("{" + this + "}->setDirtyFlag flag:" + flag);
				dirtyFlags [flag] = true;
		
		}
		public void clearDirty (string flag)
		{
				if (dirtyFlags.ContainsKey (flag)) {
						//Debug.Log ("{" + this + "}->clearDirtyFlag flag:" + flag);
						dirtyFlags.Remove (flag);
				}
		}
		
}
