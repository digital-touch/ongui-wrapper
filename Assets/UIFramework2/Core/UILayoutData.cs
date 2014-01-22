using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class UILayoutData : BindableObject
{

		public Action ChangedEvent;
	
		protected void FireChangedEvent ()
		{
				if (ChangedEvent != null) {
						ChangedEvent ();
				}
		}
	
		protected virtual void Awake ()
		{
				addToUIGameObject ();
		}
	
		Transform parent;	
	
		protected virtual void Update ()
		{
				if (parent == transform.parent) {
						return;
				}
				removeFromUIGameObject ();						
				addToUIGameObject ();				
		}		
	
		protected virtual void OnDestroy ()
		{
				removeFromUIGameObject ();
		}
	
		protected UIGameObject uiGameObject;
	
		void addToUIGameObject ()
		{
				parent = transform.parent;
				UIGameObject newUIGameObject = GetComponent<UIGameObject> ();
				if (newUIGameObject == null) {
						return;
				}
				uiGameObject = newUIGameObject;
				uiGameObject.addLayoutData (this);				
		}
	
		void removeFromUIGameObject ()
		{
				if (uiGameObject != null) {						
						uiGameObject.removeLayoutData (this);						
				}
				uiGameObject = null;	
				parent = null;			
		}
}
