using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class UILayoutData : BindableObject
{

		protected void change ()
		{		
				uiGameObject.parentUIGameObject.invalidate ();				
		}
	
		protected virtual void Awake ()
		{
				uiGameObject = GetComponent<UIGameObject> ();
				
		}
			
		protected UIGameObject uiGameObject;
	
		protected virtual void OnDestroy ()
		{
				uiGameObject = null;
		}
	
	
		
}
