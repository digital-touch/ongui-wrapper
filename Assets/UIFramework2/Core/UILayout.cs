using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public abstract class UILayout : BindableObject
{

		protected UIGameObject uiGameObject;	
		
		protected virtual void Awake ()
		{				
				uiGameObject = GetComponent<UIGameObject> ();
		}
		
		
		protected virtual void OnDestroy ()
		{
				uiGameObject = null;
		}
				
		protected void change ()
		{
				uiGameObject.invalidate ();				
		}	
		
		public Vector2 contentSize = Vector2.zero;
	
		public Vector2 scrollPosition = Vector2.zero;
	
		public abstract void Layout ();
}
